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
using Dos.ORM.Model.System;
using Dos.ORM.Web.App_Common.Filter;
using Dos.ORM.Web.Controllers.Base;

namespace Dos.ORM.Web.Areas.MsBus.Controllers
{
    public class LinkInfoController : MsSysController
    {
        [Ninject.Inject]
        private IBUS_LinkTypeData BusLinkType { get; set; }
        [Ninject.Inject]
        private IBUS_LinkInfoData BusLinkInfo { get; set; }

        public ActionResult Index()
        {
            //获取所有链接类型
            var exp = ExpHelper.Create<BUS_LinkType>(m => m.Status == 1 && m.IsEnable == 1);
            if (!MsSysUserModel.IsSuperAdmin) exp = exp.And(m => m.CompanyId == MsSysUserModel.CompanyId);
            ViewBag.LinkTypeIds = GetSelectListItem(BusLinkType.GetModels(exp), "LinkTypeName", "LinkTypeId");

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
            var linkType = Request["linkType"] ?? "";
            var keyName = Request["keyName"] ?? "";

            var exp = ExpHelper.Create<BUS_LinkInfo>(c => c.Status == 1);
            if (!string.IsNullOrWhiteSpace(keyName)) exp = exp.And(m => m.LinkInfoName.Contains(keyName));

            if (MsSysUserModel.IsSuperAdmin)
            {
                if (!string.IsNullOrWhiteSpace(Request["comId"]))
                    exp = exp.And(c => c.CompanyId == Guid.Parse(Request["comId"]));
            }
            else
                exp = exp.And(c => c.CompanyId == MsSysUserModel.CompanyId);

            if (!string.IsNullOrWhiteSpace(linkType))
            {
                var linkTypeId = Guid.Parse(linkType);
                exp = exp.And(c => c.LinkTypeId == linkTypeId);
            }

            var retList = BusLinkInfo.GetList(dgCon, exp);

            return Json(retList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost]
        [ResultLogFilter(OptType = OperateBtn.Delete)]
        public JsonResult DeleteData(List<BUS_LinkInfo> list)
        {
            var ret = BusLinkInfo.DeleteModels(list);

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail()
        {
            var gKeyId = Guid.Parse(KeyId);

            var dtlModel = OType == "add" ?
                new BUS_LinkInfo { LinkInfoId = gKeyId } :
                BusLinkInfo.GetModel(m => m.LinkInfoId == gKeyId);

            //获取所有链接类型
            var exp = ExpHelper.Create<BUS_LinkType>(m => m.Status == 1 && m.IsEnable == 1);
            if (!MsSysUserModel.IsSuperAdmin) exp = exp.And(m => m.CompanyId == MsSysUserModel.CompanyId);
            ViewBag.LinkTypeIds = GetSelectListItem(BusLinkType.GetModels(exp), "LinkTypeName", "LinkTypeId");

            return View(dtlModel);
        }

        /// <summary>
        /// 根据公司Id获取其下的所有链接信息类别
        /// </summary>
        /// <param name="comId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetLinkTypes(string comId)
        {
            //获取所有链接类型
            var exp = ExpHelper.Create<BUS_LinkType>(m => m.Status == 1 && m.IsEnable == 1);
            if (!string.IsNullOrWhiteSpace(comId)) exp = exp.And(m => m.CompanyId == Guid.Parse(comId));

            var list = GetSelectListItem(BusLinkType.GetModels(exp), "LinkTypeName", "LinkTypeId");

            var retModel = new OperateModel
            {
                Result = OperateRetType.Success,
                Data = list
            };
            return Json(retModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [ResultLogFilter(OptType = OperateBtn.Save)]
        public JsonResult SaveData(BUS_LinkInfo model)
        {
            var gKeyId = Guid.Parse(KeyId);

            OperateModel ret;

            #region 检查数据是否存在
            var comId = MsSysUserModel.IsSuperAdmin ? model.CompanyId : MsSysUserModel.CompanyId;

            var exp = OType == "add" ?
               ExpHelper.Create<BUS_LinkInfo>(m => m.CompanyId == comId && m.LinkInfoName == model.LinkInfoName) :
               ExpHelper.Create<BUS_LinkInfo>(m => m.LinkInfoId != gKeyId && m.CompanyId == comId && m.LinkInfoName == model.LinkInfoName);
            var isExist = BusLinkInfo.IsExistEntity(exp);

            if (isExist)
            {
                return JsonSubmit(new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "该链接信息标题已存在，不能保存！"
                });
            }
            #endregion

            if (OType == "add")
            {
                model.LinkInfoId = gKeyId;
                model.CompanyId = comId;
                model.CrtOptId = MsSysUserModel.Operator.OperatorId;

                ret = BusLinkInfo.InsertModel(model);
            }
            else
            {
                var updateExp = ExpHelper.Create<BUS_LinkInfo>(m => m.LinkInfoId == gKeyId);
                var oldModel = BusLinkInfo.GetModel(updateExp);

                if (MsSysUserModel.IsSuperAdmin) oldModel.CompanyId = model.CompanyId;

                oldModel.LinkTypeId = model.LinkTypeId;
                oldModel.LinkInfoName = model.LinkInfoName;
                oldModel.ImgWidth = model.ImgWidth;
                oldModel.ImgHeight = model.ImgHeight;
                oldModel.ImgPath = model.ImgPath;

                oldModel.Url = model.Url;
                oldModel.Desc = model.Desc;
                oldModel.SortNo = model.SortNo;
                oldModel.IsTop = model.IsTop;
                oldModel.IsEnable = model.IsEnable;

                oldModel.ModOptId = MsSysUserModel.Operator.OperatorId;
                oldModel.ModTime = DateTime.Now;

                ret = BusLinkInfo.UpdateModel(oldModel, updateExp);
            }

            return JsonSubmit(ret);
        }
    }
}