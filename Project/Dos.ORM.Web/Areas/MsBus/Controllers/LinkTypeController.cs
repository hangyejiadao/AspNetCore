using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.Web.App_Common.Filter;
using Dos.ORM.Web.Controllers.Base;

namespace Dos.ORM.Web.Areas.MsBus.Controllers
{
    public class LinkTypeController : MsSysController
    {
        [Ninject.Inject]
        private IBUS_LinkTypeData BusLinkType { get; set; }

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

            var exp = ExpHelper.Create<BUS_LinkType>(c => c.Status == 1);
            if (!string.IsNullOrWhiteSpace(keyName)) exp = exp.And(m => m.LinkTypeName.Contains(keyName));

            if (MsSysUserModel.IsSuperAdmin)
            {
                if (!string.IsNullOrWhiteSpace(Request["comId"]))
                    exp = exp.And(c => c.CompanyId == Guid.Parse(Request["comId"]));
            }
            else
                exp = exp.And(c => c.CompanyId == MsSysUserModel.CompanyId);

            var retList = BusLinkType.GetPagesForDg(dgCon, "CrtTime", exp);

            return Json(retList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost]
        [ResultLogFilter(OptType = OperateBtn.Delete)]
        public JsonResult DeleteData(List<BUS_LinkType> list)
        {
            var ret = BusLinkType.DeleteModels(list);

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail()
        {
            var gKeyId = Guid.Parse(KeyId);

            var dtlModel = OType == "add" ?
                new BUS_LinkType { LinkTypeId = gKeyId } :
                BusLinkType.GetModel(m => m.LinkTypeId == gKeyId);

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
        public JsonResult SaveData(BUS_LinkType model)
        {
            var gKeyId = Guid.Parse(KeyId);

            OperateModel ret;

            #region 检查数据是否存在
            var comId = MsSysUserModel.IsSuperAdmin ? model.CompanyId : MsSysUserModel.CompanyId;

            var exp = OType == "add" ?
               ExpHelper.Create<BUS_LinkType>(m => m.CompanyId == comId && m.LinkTypeName == model.LinkTypeName) :
               ExpHelper.Create<BUS_LinkType>(m => m.LinkTypeId != gKeyId && m.CompanyId == comId && m.LinkTypeName == model.LinkTypeName);
            var isExist = BusLinkType.IsExistEntity(exp);

            if (isExist)
            {
                return JsonSubmit(new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "新闻类型名称已存在，不能保存！"
                });
            }
            #endregion

            if (OType == "add")
            {
                model.LinkTypeId = gKeyId;
                model.CompanyId = MsSysUserModel.IsSuperAdmin ? model.CompanyId : MsSysUserModel.CompanyId;
                model.CrtOptId = MsSysUserModel.Operator.OperatorId;

                ret = BusLinkType.InsertModel(model);
            }
            else
            {
                var updateExp = ExpHelper.Create<BUS_LinkType>(m => m.LinkTypeId == gKeyId);
                var oldModel = BusLinkType.GetModel(updateExp);

                if (MsSysUserModel.IsSuperAdmin) oldModel.CompanyId = model.CompanyId;

                oldModel.LinkTypeName = model.LinkTypeName;
                oldModel.SortNo = model.SortNo;
                oldModel.IsEnable = model.IsEnable;
                oldModel.Desc = model.Desc;

                oldModel.ModOptId = MsSysUserModel.Operator.OperatorId;
                oldModel.ModTime = DateTime.Now;

                ret = BusLinkType.UpdateModel(oldModel, updateExp);
            }

            return JsonSubmit(ret);
        }
    }
}