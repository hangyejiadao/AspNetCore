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
using Dos.ORM.Web.Controllers.Base;

namespace Dos.ORM.Web.Areas.MsSys.Controllers
{
    public class ButtonController : MsSysController
    {
        [Ninject.Inject]
        private ISYS_ButtonData SysButton { get; set; }

        [Ninject.Inject]
        private ISYS_ModuleButtonRelationData SysModuleButtonRelation { get; set; }

        public ActionResult Index()
        {
            ViewBag.ButtonTypes = new SelectList(GetEnumDicList<OperateBtnType>(), "Key", "Value");

            return View();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="dgCon"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetList(DgConModel dgCon)
        {
            var buttonType = Request["buttonType"] ?? "";
            var keyName = Request["keyName"] ?? "";

            var exp = ExpHelper.Create<SYS_Button>(c => c.Status == 1);
            if (!string.IsNullOrWhiteSpace(keyName)) exp = exp.And(m => m.ButtonName.Contains(keyName));
            if (!string.IsNullOrWhiteSpace(buttonType)) exp = exp.And(c => c.ButtonType == Convert.ToInt32(buttonType));

            var retList = SysButton.GetPagesForDg(dgCon, "CrtTime", exp);
            return Json(retList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteData(List<SYS_Button> list)
        {
            OperateModel ret;

            //创建事务
            using (DbTrans trans = DB.DbCont.BeginTransaction())
            {
                #region 删除模块按钮关系
                var roleIds = list.Select(item => item.ButtonId).ToList();

                SysModuleButtonRelation.DeleteModelOther<SYS_ModuleButtonRelation>(m => m.ButtonId.In(roleIds), trans);
                #endregion

                ret = SysButton.DeleteModels(list, trans);

                //提交事务
                trans.Commit();
            }

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail()
        {
            var gKeyId = Guid.Parse(KeyId);

            var dtlModel = OType == "add" ?
                new SYS_Button { ButtonId = gKeyId } :
                SysButton.GetModel(m => m.ButtonId == gKeyId);

            ViewBag.FwTypes = new SelectList(GetEnumDicList<FrameworkType>(), "Key", "Value");
            ViewBag.OperateBtnTypes = new SelectList(GetEnumDicList<OperateBtnType>(), "Key", "Value");
            ViewBag.OperateBtns = new SelectList(GetEnumDicList<OperateBtn>(), "Key", "Value");

            return View(dtlModel);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="oType"></param>
        /// <param name="keyId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveData(SYS_Button model)
        {
            var gKeyId = Guid.Parse(KeyId);

            OperateModel ret;

            #region 检查数据是否存在
            var exp = OType == "add" ?
               ExpHelper.Create<SYS_Button>(m => m.FwType == model.FwType && (m.ButtonName == model.ButtonName || m.ButtonIdName == model.ButtonIdName)) :
               ExpHelper.Create<SYS_Button>(m => m.ButtonId != gKeyId && (m.FwType == model.FwType && m.ButtonName == model.ButtonName || m.ButtonIdName == model.ButtonIdName));
            var isExist = SysButton.IsExistEntity(exp);

            if (isExist)
            {
                return JsonSubmit(new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "按钮类型、按钮名称或按钮Id已存在，不能保存！"
                });
            }
            #endregion

            if (OType == "add")
            {
                model.ButtonId = gKeyId;
                model.CrtOptId = MsSysUserModel.Operator.OperatorId;

                ret = SysButton.InsertModel(model);
            }
            else
            {
                var updateExp = ExpHelper.Create<SYS_Button>(m => m.ButtonId == gKeyId);
                var oldModel = SysButton.GetModel(updateExp);

                oldModel.FwType = model.FwType;
                oldModel.ButtonType = model.ButtonType;
                oldModel.ButtonName = model.ButtonName;
                oldModel.ButtonIdName = model.ButtonIdName;
                oldModel.MarkName = model.MarkName;
                oldModel.IconName = model.IconName;
                oldModel.IconPath = model.IconPath;
                oldModel.OnClick = model.OnClick;
                oldModel.HrefClick = model.HrefClick;
                oldModel.SortNo = model.SortNo;
                oldModel.Desc = model.Desc;

                oldModel.ModOptId = MsSysUserModel.Operator.OperatorId;
                oldModel.ModTime = DateTime.Now;

                ret = SysButton.UpdateModel(oldModel, updateExp);
            }

            return JsonSubmit(ret);
        }
    }
}