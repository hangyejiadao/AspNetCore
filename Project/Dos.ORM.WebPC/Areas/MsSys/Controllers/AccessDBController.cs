using Dos.ORM.Common.Helpers;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.WebPC.Controllers.Base;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dos.ORM.WebPC.Areas.MsSys.Controllers
{
    public class AccessDBController : SubBaseController
    {

        //混凝土  
        public ActionResult AccessIndex1(string TargetId, int LoadApi)
        {
            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        //钢筋  
        public ActionResult AccessIndex2(string TargetId, int LoadApi)
        {
            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        //水泥  
        public ActionResult AccessIndex3(string TargetId, int LoadApi)
        {
            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        //砂浆  
        public ActionResult AccessIndex4(string TargetId, int LoadApi)
        {
            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        //获取样品台账   
        [HttpPost]
        public JsonResult GetAccessData(DgConModel dgCon)
        {
            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi == 0) return null;
                      
            var TableType = Request["TableType"] ?? "";
            var OrganID = Request["OrganID"] ?? "";
            var TypeCode = Request["TypeCode"] ?? "";
            var StartDate = Request["StartDate"] ?? "";
            var EndDate = Request["EndDate"] ?? "";

            var SampleNum = Request["SampleNum"] ?? "";
            var PlacePurpose = Request["PlacePurpose"] ?? "";
            var StrengthGrade = Request["StrengthGrade"] ?? "";
            var AgeDays = Request["AgeDays"] ?? "";
            var MarkNum = Request["MarkNum"] ?? "";
            
            var queryCon = new JObject(              
                new JProperty("TableType", TableType),
                new JProperty("OrganID", OrganID),
                new JProperty("TypeCode", TypeCode),
                new JProperty("StartDate", StartDate),
                new JProperty("EndDate", EndDate),
                new JProperty("SampleNum", SampleNum),
                new JProperty("PlacePurpose", PlacePurpose),
                new JProperty("StrengthGrade", StrengthGrade),
                new JProperty("AgeDays", AgeDays),
                 new JProperty("MarkNum", MarkNum)
                );

            var OperModel = GetWabApiPageListForEasyDg<OperateModel<TW_SYJZBModel>>(WebAPIHelper.GetAccessDbAPI, dgCon, queryCon);
            
            DgListModel<TW_SYJZBModel> Model=null;

            if (OperModel.Data == null)
            {
                Model = new DgListModel<TW_SYJZBModel>(new List<TW_SYJZBModel>(), 0);
            }
            else
            {
                Model = OperModel.Data;
            }

            return Json(Model, JsonRequestBehavior.AllowGet, "yyyy-MM-dd");
        }

    }
}