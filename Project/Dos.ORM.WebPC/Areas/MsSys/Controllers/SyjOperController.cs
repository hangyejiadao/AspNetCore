using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.WebPC.Controllers.Base;
using Dos.ORM.WebPC.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Dos.ORM.WebPC.Areas.MsSys.Controllers
{
    public class SyjOperController : SubBaseController
    {
        // GET: MsSys/Oper
     
        #region 基础查询 


        //获取强度等级
        [HttpGet]
        public JsonResult GetBhzQddjList(string BhzApi)
        {
            if (string.IsNullOrEmpty(BhzApi)) return null;

            string url = BhzApi+string.Format(BhzApi+SYJAPIHelper.GetBhzQddjAPI);

            var OperModel = HttpClientHelper.Get<OperateModel>(url);
 
            return Json(OperModel.Data, JsonRequestBehavior.AllowGet);

        }

        //获取列设置     
        [HttpGet]
        public JsonResult GetTabColSet(string BhzApi, string TableCode)
        {
            if (string.IsNullOrEmpty(BhzApi)) return null;

            var UserID = LoginUser.User.ID;

            string url = BhzApi + string.Format(SYJAPIHelper.GetTabColByAPI + "/{0}/{1}", TableCode, UserID);

            var OperModel = HttpClientHelper.Get<OperateModel>(url);

            return Json(OperModel.Data, JsonRequestBehavior.AllowGet);

        }

        //保存列设置    
        [HttpPost]
        public JsonResult SaveTabColSet(string BhzApi, string TabCol)
        {

            string url = BhzApi + SYJAPIHelper.GetTabColSaveAPI;

            var model = JsonHelper.JsonToObject<BHZ_TableColsSet>(TabCol);

            //var model = GetObject<BHZ_TableColsSet>();

            var OperModel = HttpClientHelper.Post<OperateModel>(url, JsonHelper.ObjectToJson<BHZ_TableColsSet>(model));

            return Json(OperModel, JsonRequestBehavior.AllowGet);
        }  
        #endregion


        #region 动态监控 
        public ActionResult BhzIndex1_1(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult BhzIndex1_2(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult BhzIndex1_3(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult BhzIndex1_4(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult BhzIndex1_5(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        //动态监控
        [HttpPost]
        public JsonResult GetSYJZBData(DgConModel dgCon)
        {
            var jsRst = Json(new DgListModel<object>(new List<object>(), 0), JsonRequestBehavior.AllowGet);

            var BhzApi = Request["BhzApi"] ?? "";
            if (string.IsNullOrEmpty(BhzApi)) return jsRst;

            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi != 1) return jsRst;

            var TableType = Request["TableType"] ?? "";//表类型(0=TW_YLJ 1=TW_WNJ)
            var OrganID = Request["OrganID"] ?? "";//标段
            var TestType = Request["TestType"] ?? "";//试验类型=混凝土
            var SBBH = Request["SBBH"] ?? "";//试验机编号
            var StartDate = Request["StartDate"] ?? "";//开始日期
            var EndDate = Request["EndDate"] ?? "";//结束日期

            var IsPass = Request["IsPass"] ?? "";//是否合格
            var SampleNum = Request["SampleNum"] ?? "";//样品编号
            var PlacePurpose = Request["PlacePurpose"] ?? "";//工程部位
            var GradeCode = Request["GradeCode"] ?? "";//强度等级
            var AgeDays = Request["AgeDays"] ?? "";//龄期(天)
            var MarkNum = Request["MarkNum"] ?? "";//牌号
            var StartScale = Request["StartScale"] ?? "";//28天达到强度比(%)
            var EndScale = Request["EndScale"] ?? "";//28天达到强度比(%)
            var FilterText = Request["FilterText"] ?? "";

            var queryCon = new JObject(
                new JProperty("TableType", TableType),
                new JProperty("OrganID", OrganID),
                new JProperty("TestType", TestType),
                new JProperty("SBBH", SBBH),
                new JProperty("StartDate", StartDate),
                new JProperty("EndDate", EndDate),
                new JProperty("IsPass", IsPass),
                new JProperty("SampleNum", SampleNum),
                new JProperty("PlacePurpose", PlacePurpose),
                new JProperty("GradeCode", GradeCode),
                new JProperty("AgeDays", AgeDays),
                new JProperty("MarkNum", MarkNum),
                new JProperty("StartScale", StartScale),
                new JProperty("EndScale", EndScale),
                new JProperty("FilterText", FilterText)
                );

            var OperModel = GetWabApiPageListForEasyDg<OperateModel<object>>(BhzApi + SYJAPIHelper.GetSyjZbAPI, dgCon, queryCon);

            DgListModel<object> Model = null;

            if (OperModel.Data == null)
            {
                Model = new DgListModel<object>(new List<object>(), 0);
            }
            else
            {
                Model = OperModel.Data;
            }

            return Json(Model, JsonRequestBehavior.AllowGet);
        }


        #endregion


        #region 数据分析

        public ActionResult BhzIndex2_1(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult BhzIndex2_2(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult BhzIndex2_3(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        //质量波动图--混凝土+砂浆     

        [HttpPost]
        public JsonResult GetHNTFx1Data()
        {
            var BhzApi = Request["BhzApi"] ?? "";
            if (string.IsNullOrEmpty(BhzApi)) return null;

            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi != 1) return null;

            var OrganID = Request["OrganID"] ?? "";
            var TestType = Request["TestType"] ?? "";
            var StartDate = Request["StartDate"] ?? "";
            var EndDate = Request["EndDate"] ?? "";
            var GradeCode = Request["GradeCode"] ?? "";
            var AgeDays = Request["AgeDays"] ?? "";

            var queryCon = new JObject(
                new JProperty("OrganID", OrganID),
                new JProperty("TestType", TestType),
                new JProperty("StartDate", StartDate),
                new JProperty("EndDate", EndDate),
                new JProperty("GradeCode", GradeCode),
                new JProperty("AgeDays", AgeDays)
                );

            var OperModel = GetWabApiPageListForEasyDg<OperateModel>(BhzApi+SYJAPIHelper.GetHNTFx1API, null, queryCon);

            return Json(OperModel, JsonRequestBehavior.AllowGet);

        }

        #endregion


        #region 统计报表

        public ActionResult BhzIndex3_1(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult BhzIndex3_2(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult BhzIndex3_3(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult BhzIndex3_4(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult BhzIndex3_5(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }


        #region 各试验数量统计

        //统计数据  
        [HttpPost]
        public JsonResult GetHNTRpt1Data()
        {
            var BhzApi = Request["BhzApi"] ?? "";
            if (string.IsNullOrEmpty(BhzApi)) return null;
                        
            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi != 1) return null;

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

            var OperModel = GetWabApiPageListForEasyDg<OperateModel>(BhzApi+SYJAPIHelper.GetHNTRpt1API, null, queryCon);

            return Json(OperModel, JsonRequestBehavior.AllowGet);

        }

        //统计图  
        [HttpGet]
        public JsonResult GetHNTRpt1EChart()
        {
            var BhzApi = Request["BhzApi"] ?? "";
            if (string.IsNullOrEmpty(BhzApi)) return null;                        

            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi != 1) return null;

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

            var OperModel = HttpClientHelper.Post(BhzApi+SYJAPIHelper.GetHNTRpt1EChart, JsonHelper.ObjectToJson(queryCon));

            return Json(OperModel, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 合格统计-混凝土+砂浆

        //统计报表   
        [HttpPost]
        public JsonResult GetHNTRpt2Data()
        {
            var BhzApi = Request["BhzApi"] ?? "";
            if (string.IsNullOrEmpty(BhzApi)) return null;    

            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi != 1) return null;

            var OrganID = Request["OrganID"] ?? "";
            var PostType = Request["PostType"] ?? "0";
            var TestType = Request["TestType"] ?? "";
            var StartDate = Request["StartDate"] ?? "";
            var EndDate = Request["EndDate"] ?? "";

            var queryCon = new JObject(
                new JProperty("OrganID", OrganID),
                new JProperty("PostType", PostType),
                new JProperty("TestType", TestType),
                new JProperty("StartDate", StartDate),
                new JProperty("EndDate", EndDate)
                );

            var OperModel = GetWabApiPageListForEasyDg<OperateModel>(BhzApi + SYJAPIHelper.GetSyjHNT2API, null, queryCon);

            return Json(OperModel, JsonRequestBehavior.AllowGet);

        }

        //统计图  
        [HttpGet]
        public JsonResult GetHNTRpt2EChart()
        {
            var BhzApi = Request["BhzApi"] ?? "";
            if (string.IsNullOrEmpty(BhzApi)) return null;  

            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi != 1) return null;

            var OrganID = Request["OrganID"] ?? "";
            var PostType = Request["PostType"] ?? "0";
            var TestType = Request["TestType"] ?? "";
            var StartDate = Request["StartDate"] ?? "";
            var EndDate = Request["EndDate"] ?? "";

            var queryCon = new JObject(
                new JProperty("OrganID", OrganID),
                new JProperty("PostType", PostType),
                new JProperty("TestType", TestType),
                new JProperty("StartDate", StartDate),
                new JProperty("EndDate", EndDate)
                );

            var OperModel = HttpClientHelper.Post(BhzApi+SYJAPIHelper.GetHNTRpt2EChart, JsonHelper.ObjectToJson(queryCon));

            return Json(OperModel, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 强度统计-混凝土+砂浆

        //统计报表   
        [HttpPost]
        public JsonResult GetHNTRpt3Data()
        {

            var BhzApi = Request["BhzApi"] ?? "";
            if (string.IsNullOrEmpty(BhzApi)) return null;  

            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi != 1) return null;

            var OrganID = Request["OrganID"] ?? "";
            var TestType = Request["TestType"] ?? "";
            var Year = Request["Year"] ?? "";
            var GradeCode = Request["GradeCode"] ?? "";

            var queryCon = new JObject(
              new JProperty("OrganID", OrganID),
              new JProperty("TestType", TestType),
              new JProperty("Year", Year),
              new JProperty("GradeCode", GradeCode)
              );

            var OperModel = GetWabApiPageListForEasyDg<OperateModel>(BhzApi + SYJAPIHelper.GetHNTRpt3API, null, queryCon);

            return Json(OperModel, JsonRequestBehavior.AllowGet);

        }


        //统计图  
        [HttpGet]
        public JsonResult GetHNTRpt3EChart()
        {

            var BhzApi = Request["BhzApi"] ?? "";
            if (string.IsNullOrEmpty(BhzApi)) return null;  

            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi != 1) return null;

            var OrganID = Request["OrganID"] ?? "";
            var TestType = Request["TestType"] ?? "";
            var Year = Request["Year"] ?? "";
            var GradeCode = Request["GradeCode"] ?? "";

            var queryCon = new JObject(
              new JProperty("OrganID", OrganID),
              new JProperty("TestType", TestType),
              new JProperty("Year", Year),
              new JProperty("GradeCode", GradeCode)
              );

            var OperModel = HttpClientHelper.Post(BhzApi + SYJAPIHelper.GetHNTRpt3EChart, JsonHelper.ObjectToJson(queryCon));

            return Json(OperModel, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #endregion



    }
}