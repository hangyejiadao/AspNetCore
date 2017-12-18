using Dos.ORM.Common.Helpers;
using Dos.ORM.WebPC.Controllers.Base;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dos.ORM.WebPC.Areas.MsSys.Controllers
{
    public class EChartsController : SubBaseController
    {
    
        public ActionResult Index()
        {
            return View();
        }

        #region 平台


        //统计分析   
        public ActionResult EChartIndex(string TargetId, int LoadApi)
        {
            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }


        //根据类型年份查询统计报告 X坐标为月份      
        [HttpGet]
        public JsonResult GetEChartsReportByItem()
        {
            var TargetId = Request["TargetId"] ?? "";
            var ItemCode = Request["ItemCode"] ?? "";
            var Year = Request["Year"] ?? "";

            var queryCon = new JObject(
              new JProperty("OrganID", TargetId),
              new JProperty("ItemCode", ItemCode),
              new JProperty("Year", Year)
              );

            var OperModel = HttpClientHelper.Post(WebAPIHelper.GetRptItemAPI, JsonHelper.ObjectToJson(queryCon));

            return Json(OperModel, JsonRequestBehavior.AllowGet);
        }
        //根据类型年份查询统计报告 X坐标为月份      
        [HttpGet]
        public JsonResult GetEChartsReportByMonth()
        {
            var TargetId = Request["TargetId"] ?? "";
            var Month = Request["Month"] ?? "";

            var queryCon = new JObject(
              new JProperty("OrganID", TargetId),
              new JProperty("Month", Month)
              );

            var OperModel = HttpClientHelper.Post(WebAPIHelper.GetRptMonthAPI, JsonHelper.ObjectToJson(queryCon));

            return Json(OperModel, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region 拌合站


        public ActionResult EChartIndex1(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult EChartIndex2(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult EChartIndex3(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        //数据分析-产能分析       
        [HttpGet]
        public JsonResult GetEChartsAnalyze1()
        {
            var BhzApi = Request["BhzApi"] ?? "";
            if (string.IsNullOrEmpty(BhzApi)) return null;

            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi != 1) return null;

            var OrganID = Request["OrganID"] ?? "";
            var BHJBH = Request["BHJBH"] ?? "";
            var StartDate = Request["StartDate"] ?? "";
            var EndDate = Request["EndDate"] ?? "";

            var queryCon = new JObject(
              new JProperty("OrganID", OrganID),
              new JProperty("BHJBH", BHJBH),
              new JProperty("StartDate", StartDate),
              new JProperty("EndDate", EndDate)
              );

            var OperModel = HttpClientHelper.Post(BhzApi+BHZAPIHelper.GetEchartAnalyze1API, JsonHelper.ObjectToJson(queryCon));

            return Json(OperModel, JsonRequestBehavior.AllowGet);
        }

        //数据分析-材料趋势分析       
        [HttpGet]
        public JsonResult GetEChartsAnalyze2()
        {
            var BhzApi = Request["BhzApi"] ?? "";
            if (string.IsNullOrEmpty(BhzApi)) return null;

            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi != 1) return null;

            var OrganID = Request["OrganID"] ?? "";
            var BHJBH = Request["BHJBH"] ?? "";
            var QueryDate = Request["QueryDate"] ?? "";
            var StartHour = Request["StartHour"] ?? "0";
            var EndHour = Request["EndHour"] ?? "23";

            var queryCon = new JObject(
              new JProperty("OrganID", OrganID),
              new JProperty("BHJBH", BHJBH),
              new JProperty("QueryDate", QueryDate),
              new JProperty("StartHour", StartHour),
              new JProperty("EndHour", EndHour)
              );

            var OperModel = HttpClientHelper.Post(BhzApi+BHZAPIHelper.GetEchartAnalyze2API, JsonHelper.ObjectToJson(queryCon));

            return Json(OperModel, JsonRequestBehavior.AllowGet);
        }

        
        //统计报表-混凝土产量统计   
        [HttpGet]
        public JsonResult GetEChartsRpt1()
        {
            var BhzApi = Request["BhzApi"] ?? "";
            if (string.IsNullOrEmpty(BhzApi)) return null;

            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi == 0) return null;

            var OrganID = Request["OrganID"] ?? "";
            var PostType = Request["PostType"] ?? "0";
            var StartDate = Request["StartDate"] ?? "";
            var EndDate = Request["EndDate"] ?? "";

            var queryCon = new JObject(
                new JProperty("OrganID", OrganID),
                new JProperty("PostType", PostType),
                new JProperty("StartDate", StartDate),
                new JProperty("EndDate", EndDate)
                );

            var OperModel = HttpClientHelper.Post(BhzApi+BHZAPIHelper.GetEchartRpt1API, JsonHelper.ObjectToJson(queryCon));

            return Json(OperModel, JsonRequestBehavior.AllowGet);
        }


        //统计报表-混凝土产量统计   
        [HttpGet]
        public JsonResult GetEChartsRpt3()
        {
            var BhzApi = Request["BhzApi"] ?? "";
            if (string.IsNullOrEmpty(BhzApi)) return null;

            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi == 0) return null;

            var OrganID = Request["OrganID"] ?? "";
            var PostType = Request["PostType"] ?? "0";
            var StartDate = Request["StartDate"] ?? "";
            var EndDate = Request["EndDate"] ?? "";

            var queryCon = new JObject(
                new JProperty("OrganID", OrganID),
                new JProperty("PostType", PostType),
                new JProperty("StartDate", StartDate),
                new JProperty("EndDate", EndDate)
                );

            var OperModel = HttpClientHelper.Post(BhzApi+BHZAPIHelper.GetEchartRpt3API, JsonHelper.ObjectToJson(queryCon));

            return Json(OperModel, JsonRequestBehavior.AllowGet);
        }


        #endregion



    }
}