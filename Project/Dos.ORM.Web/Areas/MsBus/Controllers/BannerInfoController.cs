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
    public class BannerInfoController : MsSysController
    {
        [Ninject.Inject]
        private IBUS_BannerTypeData BusBannerType { get; set; }
        [Ninject.Inject]
        private IBUS_BannerInfoData BusBannerInfo { get; set; }

        public ActionResult Index()
        {
            //获取所有横幅类型
            var exp = ExpHelper.Create<BUS_BannerType>(m => m.Status == 1 && m.IsEnable == 1);
            if (!MsSysUserModel.IsSuperAdmin) exp = exp.And(m => m.CompanyId == MsSysUserModel.CompanyId);
            ViewBag.BannerTypeIds = GetSelectListItem(BusBannerType.GetModels(exp), "BannerTypeName", "BannerTypeId");

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
            var bannerType = Request["bannerType"] ?? "";
            var keyName = Request["keyName"] ?? "";

            var exp = ExpHelper.Create<BUS_BannerInfo>(c => c.Status == 1);
            if (!string.IsNullOrWhiteSpace(keyName)) exp = exp.And(m => m.BannerInfoName.Contains(keyName));

            if (MsSysUserModel.IsSuperAdmin)
            {
                if (!string.IsNullOrWhiteSpace(Request["comId"]))
                    exp = exp.And(c => c.CompanyId == Guid.Parse(Request["comId"]));
            }
            else
                exp = exp.And(c => c.CompanyId == MsSysUserModel.CompanyId);

            if (!string.IsNullOrWhiteSpace(bannerType))
            {
                var bannerTypeId = Guid.Parse(bannerType);
                exp = exp.And(c => c.BannerTypeId == bannerTypeId);
            }

            var retList = BusBannerInfo.GetList(dgCon, exp);

            return Json(retList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost]
        [ResultLogFilter(OptType = OperateBtn.Delete)]
        public JsonResult DeleteData(List<BUS_BannerInfo> list)
        {
            var ret = BusBannerInfo.DeleteModels(list);

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail()
        {
            var gKeyId = Guid.Parse(KeyId);

            var dtlModel = OType == "add" ?
                new BUS_BannerInfo { BannerInfoId = gKeyId } :
                BusBannerInfo.GetModel(m => m.BannerInfoId == gKeyId);

            //获取所有横幅类型
            var exp = ExpHelper.Create<BUS_BannerType>(m => m.Status == 1 && m.IsEnable == 1);
            if (!MsSysUserModel.IsSuperAdmin) exp = exp.And(m => m.CompanyId == MsSysUserModel.CompanyId);
            ViewBag.BannerTypeIds = GetSelectListItem(BusBannerType.GetModels(exp), "BannerTypeName", "BannerTypeId");

            return View(dtlModel);
        }

        /// <summary>
        /// 根据公司Id获取其下的所有横幅类别
        /// </summary>
        /// <param name="comId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetBannerTypes(string comId)
        {
            //获取所有横幅类型
            var exp = ExpHelper.Create<BUS_BannerType>(m => m.Status == 1 && m.IsEnable == 1);
            if (!string.IsNullOrWhiteSpace(comId)) exp = exp.And(m => m.CompanyId == Guid.Parse(comId));

            var list = GetSelectListItem(BusBannerType.GetModels(exp), "BannerTypeName", "BannerTypeId");

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
        public JsonResult SaveData(BUS_BannerInfo model)
        {
            var gKeyId = Guid.Parse(KeyId);

            OperateModel ret;

            #region 检查数据是否存在
            var comId = MsSysUserModel.IsSuperAdmin ? model.CompanyId : MsSysUserModel.CompanyId;

            var exp = OType == "add" ?
               ExpHelper.Create<BUS_BannerInfo>(m => m.CompanyId == comId && m.BannerInfoName == model.BannerInfoName) :
               ExpHelper.Create<BUS_BannerInfo>(m => m.BannerInfoId != gKeyId && m.CompanyId == comId && m.BannerInfoName == model.BannerInfoName);
            var isExist = BusBannerInfo.IsExistEntity(exp);

            if (isExist)
            {
                return JsonSubmit(new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "该横幅标题已存在，不能保存！"
                });
            }
            #endregion

            if (OType == "add")
            {
                model.BannerInfoId = gKeyId;
                if (!MsSysUserModel.IsSuperAdmin) model.CompanyId = MsSysUserModel.CompanyId;
                model.CrtOptId = MsSysUserModel.Operator.OperatorId;

                ret = BusBannerInfo.InsertModel(model);
            }
            else
            {
                var updateExp = ExpHelper.Create<BUS_BannerInfo>(m => m.BannerInfoId == gKeyId);
                var oldModel = BusBannerInfo.GetModel(updateExp);

                if (MsSysUserModel.IsSuperAdmin) oldModel.CompanyId = model.CompanyId;

                oldModel.BannerTypeId = model.BannerTypeId;
                oldModel.BannerInfoName = model.BannerInfoName;
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

                ret = BusBannerInfo.UpdateModel(oldModel, updateExp);
            }

            return JsonSubmit(ret);
        }
    }
}