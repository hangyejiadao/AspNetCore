using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Data.Base;
using Dos.ORM.Data.System;
using Dos.ORM.IData.System;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.System;
using Dos.ORM.Web.App_Common.Filter;
using Dos.ORM.Web.Controllers.Base;

namespace Dos.ORM.Web.Areas.MsSys.Controllers
{
    public class DepartmentController : MsSysController
    {
        [Ninject.Inject]
        private ISYS_DepartmentData SysDepartment { get; set; }
        [Ninject.Inject]
        private ISYS_OperatorDepartmentRelationData SysOperatorDepartmentRelationData { get; set; }

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

            var exp = ExpHelper.Create<SYS_Department>(c => c.Status == 1);
            if (!string.IsNullOrWhiteSpace(keyName)) exp = exp.And(m => m.DepartmentName.Contains(keyName));

            if (MsSysUserModel.IsSuperAdmin)
            {
                if (!string.IsNullOrWhiteSpace(Request["comId"]))
                    exp = exp.And(c => c.CompanyId == Guid.Parse(Request["comId"]));
            }
            else
                exp = exp.And(c => c.CompanyId == MsSysUserModel.CompanyId);

            var retList = SysDepartment.GetPagesForDg(dgCon, "CrtTime", exp);

            return Json(retList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost]
        [ResultLogFilter(OptType = OperateBtn.Delete)]
        public JsonResult DeleteData(List<SYS_Department> list)
        {
            OperateModel ret;

            //创建事务
            using (DbTrans trans = DB.DbCont.BeginTransaction())
            {

                #region 删除管理员部门关系
                var roleIds = list.Select(item => item.DepartmentId).ToList();

                SysOperatorDepartmentRelationData.DeleteModelOther<SYS_OperatorDepartmentRelation>(m => m.DepartmentId.In(roleIds), trans);
                #endregion

                ret = SysDepartment.DeleteModels(list, trans);

                //提交事务
                trans.Commit();
            }

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 选择部门人员
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectOperator()
        {
            return View();
        }

        /// <summary>
        /// 根据部门Id获取其所有的操作人员（包括所有的人员）
        /// </summary>
        /// <param name="comId"></param>
        /// <param name="depId"></param>
        /// <returns></returns>
        public JsonResult GetDepOperators(Guid? comId, Guid depId)
        {
            var ret = SysDepartment.GetDepOperators(depId, comId == null || comId == Guid.Empty ? MsSysUserModel.CompanyId : comId);

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存部门下的人员（关系）
        /// </summary>
        /// <param name="depId"></param>
        /// <param name="opers"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveDepOperators(Guid depId, List<SYS_Operator> opers)
        {
            OperateModel ret;

            //创建事务
            using (DbTrans trans = DB.DbCont.BeginTransaction())
            {
                SysOperatorDepartmentRelationData.DeleteModel(m => m.DepartmentId == depId, trans);

                var insertList = new List<SYS_OperatorDepartmentRelation>();
                foreach (var item in opers)
                {
                    insertList.Add(new SYS_OperatorDepartmentRelation
                    {
                        OdId = Guid.NewGuid(),
                        DepartmentId = depId,
                        OperatorId = item.OperatorId,
                        CrtTime = DateTime.Now,
                        CrtOptId = MsSysUserModel.Operator.OperatorId
                    });
                }
                ret = SysOperatorDepartmentRelationData.InsertModels(insertList, trans);

                //提交事务
                trans.Commit();
            }

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail()
        {
            var gKeyId = Guid.Parse(KeyId);

            var dtlModel = OType == "add" ?
                new SYS_Department { DepartmentId = gKeyId } :
                SysDepartment.GetModel(m => m.DepartmentId == gKeyId);

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
        public JsonResult SaveData(SYS_Department model)
        {
            var gKeyId = Guid.Parse(KeyId);

            OperateModel ret;

            #region 检查数据是否存在
            var comId = MsSysUserModel.IsSuperAdmin ? model.CompanyId : MsSysUserModel.CompanyId;

            var exp = OType == "add" ?
               ExpHelper.Create<SYS_Department>(m => m.CompanyId == comId && m.DepartmentName == model.DepartmentName) :
               ExpHelper.Create<SYS_Department>(m => m.DepartmentId != gKeyId && m.CompanyId == comId && m.DepartmentName == model.DepartmentName);
            var isExist = SysDepartment.IsExistEntity(exp);

            if (isExist)
            {
                return JsonSubmit(new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "部门名称已存在，不能保存！"
                });
            }
            #endregion

            if (OType == "add")
            {
                model.DepartmentId = gKeyId;
                model.CompanyId = comId;
                model.CrtOptId = MsSysUserModel.Operator.OperatorId;

                ret = SysDepartment.InsertModel(model);
            }
            else
            {
                var updateExp = ExpHelper.Create<SYS_Department>(m => m.DepartmentId == gKeyId);
                var oldModel = SysDepartment.GetModel(updateExp);

                if (MsSysUserModel.IsSuperAdmin) oldModel.CompanyId = model.CompanyId;

                oldModel.DepartmentName = model.DepartmentName;
                oldModel.IsEnable = model.IsEnable;
                oldModel.Desc = model.Desc;

                oldModel.ModOptId = MsSysUserModel.Operator.OperatorId;
                oldModel.ModTime = DateTime.Now;

                ret = SysDepartment.UpdateModel(oldModel, updateExp);
            }

            return JsonSubmit(ret);
        }
    }
}