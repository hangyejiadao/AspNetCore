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
    public class NewsInfoController : MsSysController
    {
        [Ninject.Inject]
        private IBUS_NewsTypeData BusNewsType { get; set; }
        [Ninject.Inject]
        private IBUS_NewsInfoData BusNewsInfo { get; set; }

        public ActionResult Index()
        {
            //获取所有新闻类型
            var exp = ExpHelper.Create<BUS_NewsType>(m => m.Status == 1 && m.IsEnable == 1);
            if (!MsSysUserModel.IsSuperAdmin) exp = exp.And(m => m.CompanyId == MsSysUserModel.CompanyId);
            ViewBag.NewsTypeIds = GetSelectListItem(BusNewsType.GetModels(exp), "NewsTypeName", "NewsTypeId");

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
            var newsType = Request["newsType"] ?? "";
            var keyName = Request["keyName"] ?? "";

            var exp = ExpHelper.Create<BUS_NewsInfo>(c => c.Status == 1);
            if (!string.IsNullOrWhiteSpace(keyName)) exp = exp.And(m => m.Title.Contains(keyName));

            if (MsSysUserModel.IsSuperAdmin)
            {
                if (!string.IsNullOrWhiteSpace(Request["comId"]))
                    exp = exp.And(c => c.CompanyId == Guid.Parse(Request["comId"]));
            }
            else
                exp = exp.And(c => c.CompanyId == MsSysUserModel.CompanyId);

            if (!string.IsNullOrWhiteSpace(newsType))
            {
                var newsTypeId = Guid.Parse(newsType);
                exp = exp.And(c => c.NewsTypeId == newsTypeId);
            }

            var retList = BusNewsInfo.GetList(dgCon, exp);

            return Json(retList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost]
        [ResultLogFilter(OptType = OperateBtn.Delete)]
        public JsonResult DeleteData(List<BUS_NewsInfo> list)
        {
            var ret = BusNewsInfo.DeleteModels(list);

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail()
        {
            var gKeyId = Guid.Parse(KeyId);

            var dtlModel = OType == "add" ?
                new BUS_NewsInfo { NewsInfoId = gKeyId } :
                BusNewsInfo.GetModel(m => m.NewsInfoId == gKeyId);

            //获取所有新闻类型
            var exp = ExpHelper.Create<BUS_NewsType>(m => m.Status == 1 && m.IsEnable == 1);
            if (!MsSysUserModel.IsSuperAdmin) exp = exp.And(m => m.CompanyId == MsSysUserModel.CompanyId);
            ViewBag.NewsTypeIds = GetSelectListItem(BusNewsType.GetModels(exp), "NewsTypeName", "NewsTypeId");

            return View(dtlModel);
        }

        /// <summary>
        /// 根据公司Id获取其下的所有新闻类别
        /// </summary>
        /// <param name="comId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetNewsTypes(string comId)
        {
            //获取所有新闻类型
            var exp = ExpHelper.Create<BUS_NewsType>(m => m.Status == 1 && m.IsEnable == 1);
            if (!string.IsNullOrWhiteSpace(comId)) exp = exp.And(m => m.CompanyId == Guid.Parse(comId));

            var list = GetSelectListItem(BusNewsType.GetModels(exp), "NewsTypeName", "NewsTypeId");

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
        public JsonResult SaveData(BUS_NewsInfo model)
        {
            var gKeyId = Guid.Parse(KeyId);

            OperateModel ret;

            #region 检查数据是否存在
            var comId = MsSysUserModel.IsSuperAdmin ? model.CompanyId : MsSysUserModel.CompanyId;

            var exp = OType == "add" ?
               ExpHelper.Create<BUS_NewsInfo>(m => m.CompanyId == comId && m.Title == model.Title) :
               ExpHelper.Create<BUS_NewsInfo>(m => m.NewsInfoId != gKeyId && m.CompanyId == comId && m.Title == model.Title);
            var isExist = BusNewsInfo.IsExistEntity(exp);

            if (isExist)
            {
                return JsonSubmit(new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "该新闻标题已存在，不能保存！"
                });
            }
            #endregion

            if (OType == "add")
            {
                model.NewsInfoId = gKeyId;
                if (!MsSysUserModel.IsSuperAdmin) model.CompanyId = MsSysUserModel.CompanyId;
                model.Author = string.IsNullOrWhiteSpace(MsSysUserModel.Operator.Nickname) ? string.IsNullOrWhiteSpace(MsSysUserModel.Operator.Realname) ? MsSysUserModel.Operator.Account : MsSysUserModel.Operator.Realname : MsSysUserModel.Operator.Nickname;
                model.CrtOptId = MsSysUserModel.Operator.OperatorId;

                ret = BusNewsInfo.InsertModel(model);
            }
            else
            {
                var updateExp = ExpHelper.Create<BUS_NewsInfo>(m => m.NewsInfoId == gKeyId);
                var oldModel = BusNewsInfo.GetModel(updateExp);

                if (MsSysUserModel.IsSuperAdmin) oldModel.CompanyId = model.CompanyId;

                oldModel.NewsTypeId = model.NewsTypeId;
                oldModel.Title = model.Title;
                oldModel.TitleColor = model.TitleColor;
                oldModel.TitleFont = model.TitleFont;
                oldModel.Subtitle = model.Subtitle;
                oldModel.Source = model.Source;
                oldModel.SourceLink = model.SourceLink;
                model.Author = string.IsNullOrWhiteSpace(MsSysUserModel.Operator.Nickname) ? string.IsNullOrWhiteSpace(MsSysUserModel.Operator.Realname) ? MsSysUserModel.Operator.Account : MsSysUserModel.Operator.Realname : MsSysUserModel.Operator.Nickname;
                oldModel.Keyword = model.Keyword;
                oldModel.Summary = model.Summary;
                oldModel.ImgWidth = model.ImgWidth;
                oldModel.ImgHeight = model.ImgHeight;
                oldModel.ImgPath = model.ImgPath;
                //oldModel.ViewCount = model.ViewCount;
                oldModel.IsTop = model.IsTop;
                oldModel.IsEnable = model.IsEnable;
                oldModel.DtlInfo = model.DtlInfo;

                oldModel.ModOptId = MsSysUserModel.Operator.OperatorId;
                oldModel.ModTime = DateTime.Now;

                ret = BusNewsInfo.UpdateModel(oldModel, updateExp);
            }

            return JsonSubmit(ret);
        }
    }
}