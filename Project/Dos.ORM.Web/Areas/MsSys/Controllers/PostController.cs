using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Data.Base;
using Dos.ORM.IData.System;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.System;
using Dos.ORM.Web.App_Common.Filter;
using Dos.ORM.Web.Controllers.Base;

namespace Dos.ORM.Web.Areas.MsSys.Controllers
{
    public class PostController : MsSysController
    {
        [Ninject.Inject]
        private ISYS_PostData SysPost { get; set; }
        [Ninject.Inject]
        private ISYS_OperatorPostRelationData SysOperatorPostRelationData { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="dgCon"></param>
        /// <returns></returns>
        [HttpPost]
        [ResultLogFilter(OptType = OperateBtn.Search)]
        public JsonResult GetList(DgConModel dgCon)
        {
            var keyName = Request["keyName"] ?? "";

            var exp = ExpHelper.Create<SYS_Post>(c => c.Status == 1);
            if (!string.IsNullOrWhiteSpace(keyName)) exp = exp.And(m => m.PostName.Contains(keyName));

            if (MsSysUserModel.IsSuperAdmin)
            {
                if (!string.IsNullOrWhiteSpace(Request["comId"]))
                    exp = exp.And(c => c.CompanyId == Guid.Parse(Request["comId"]));
            }
            else
                exp = exp.And(c => c.CompanyId == MsSysUserModel.CompanyId);

            var retList = SysPost.GetPagesForDg(dgCon, "CrtTime", exp);

            return Json(retList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost]
        [ResultLogFilter(OptType = OperateBtn.Delete)]
        public JsonResult DeleteData(List<SYS_Post> list)
        {
            OperateModel ret;

            //创建事务
            using (DbTrans trans = DB.DbCont.BeginTransaction())
            {

                #region 删除管理员岗位关系
                var postIds = list.Select(item => item.PostId).ToList();

                SysOperatorPostRelationData.DeleteModelOther<SYS_OperatorPostRelation>(m => m.PostId.In(postIds), trans);
                #endregion

                ret = SysPost.DeleteModels(list, trans);

                //提交事务
                trans.Commit();
            }

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 选择岗位人员
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectOperator()
        {
            return View();
        }

        /// <summary>
        /// 根据岗位Id获取其所有的操作人员（包括所有的人员）
        /// </summary>
        /// <param name="comId"></param>
        /// <param name="postId"></param>
        /// <returns></returns>
        public JsonResult GetPostOperators(Guid? comId, Guid postId)
        {
            var ret = SysPost.GetPostOperators(postId, comId == null || comId == Guid.Empty ? MsSysUserModel.CompanyId : comId);

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存岗位下的人员（关系）
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="opers"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SavePostOperators(Guid postId, List<SYS_Operator> opers)
        {
            OperateModel ret;

            //创建事务
            using (DbTrans trans = DB.DbCont.BeginTransaction())
            {
                SysOperatorPostRelationData.DeleteModel(m => m.PostId == postId, trans);

                var insertList = new List<SYS_OperatorPostRelation>();
                foreach (var item in opers)
                {
                    insertList.Add(new SYS_OperatorPostRelation
                    {
                        OpId = Guid.NewGuid(),
                        PostId = postId,
                        OperatorId = item.OperatorId,
                        CrtTime = DateTime.Now,
                        CrtOptId = MsSysUserModel.Operator.OperatorId
                    });
                }
                ret = SysOperatorPostRelationData.InsertModels(insertList, trans);

                //提交事务
                trans.Commit();
            }

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail()
        {
            var gKeyId = Guid.Parse(KeyId);

            var dtlModel = OType == "add" ?
                new SYS_Post { PostId = gKeyId } :
                SysPost.GetModel(m => m.PostId == gKeyId);

            return View(dtlModel);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [ResultLogFilter(OptType = OperateBtn.Save)]
        public JsonResult SaveData(SYS_Post model)
        {
            var gKeyId = Guid.Parse(KeyId);

            OperateModel ret;

            #region 检查数据是否存在
            var comId = MsSysUserModel.IsSuperAdmin ? model.CompanyId : MsSysUserModel.CompanyId;

            var exp = OType == "add" ?
               ExpHelper.Create<SYS_Post>(m => m.CompanyId == comId && m.PostName == model.PostName) :
               ExpHelper.Create<SYS_Post>(m => m.PostId != gKeyId && m.CompanyId == comId && m.PostName == model.PostName);
            var isExist = SysPost.IsExistEntity(exp);

            if (isExist)
            {
                return JsonSubmit(new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "岗位名称已存在，不能保存！"
                });
            }
            #endregion

            if (OType == "add")
            {
                model.PostId = gKeyId;
                model.CompanyId = comId;
                model.CrtOptId = MsSysUserModel.Operator.OperatorId;

                ret = SysPost.InsertModel(model);
            }
            else
            {
                var updateExp = ExpHelper.Create<SYS_Post>(m => m.PostId == gKeyId);
                var oldModel = SysPost.GetModel(updateExp);

                if (MsSysUserModel.IsSuperAdmin) oldModel.CompanyId = model.CompanyId;

                oldModel.PostName = model.PostName;
                oldModel.IsEnable = model.IsEnable;
                oldModel.Desc = model.Desc;

                oldModel.ModOptId = MsSysUserModel.Operator.OperatorId;
                oldModel.ModTime = DateTime.Now;

                ret = SysPost.UpdateModel(oldModel, updateExp);
            }

            return JsonSubmit(ret);
        }
    }
}