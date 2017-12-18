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
    public class ModuleController : SubBaseController
    {

        //基本信息  
        public ActionResult BasicIndex(string TargetId, int LoadApi)
        {
            //string url = string.Format(WebAPIHelper.GetLabAPI + "/{0}", TargetId);

            //var OperModel = HttpClientHelper.Get<OperateModel_2<BUS_Laboratory>>(url);

            //var model = OperModel.Data;
            //return View("~/Views/ProjectHT/ProjectHTLoad.cshtml", HTViewModel);

            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        //获取实验室信息       
        [HttpGet]
        public JsonResult GetLab(string TargetId, int LoadApi)
        {
            if (string.IsNullOrEmpty(TargetId) || LoadApi == 0 ) return null;

            string url = string.Format(WebAPIHelper.GetLabAPI + "/{0}", TargetId);

            var OperModel = HttpClientHelper.Get<OperateModel>(url);

            return Json(OperModel.Data, JsonRequestBehavior.AllowGet, "yyyy-MM-dd");

        }


        //检测人员       
        public ActionResult TesterIndex(string TargetId, int LoadApi)
        {
            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult TesterIndex1(string TargetId, int LoadApi)
        {
            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }


        //查看检测人员       
        public ActionResult TesterView()
        {
            return View();
        }

        //获取样品台账   
        [HttpPost]
        public JsonResult GetTester(DgConModel dgCon)
        {
            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi == 0) return null;

            var TargetId = Request["TargetId"] ?? "";
            var FilterText = Request["FilterText"] ?? "";

            var queryCon = new JObject(
                new JProperty("TargetId", TargetId),
                new JProperty("FilterText", FilterText)
                );

            var OperModel = GetWabApiPageListForEasyDg<OperateModel<BUS_Tester>>(WebAPIHelper.GetTesterAPI, dgCon, queryCon);

            DgListModel<BUS_Tester> Model = null;

            if (OperModel.Data == null)
            {
                Model = new DgListModel<BUS_Tester>(new List<BUS_Tester>(), 0);
            }
            else
            {
                Model = OperModel.Data;
            }

            return Json(Model, JsonRequestBehavior.AllowGet, "yyyy-MM-dd");
        }

        //设备管理       
        public ActionResult EqumentIndex(string TargetId, int LoadApi)
        {
            //string url = string.Format(WebAPIHelper.GetEquTypeAPI + "/{0}", TargetId);
            //var OperModel = HttpClientHelper.Get<OperateList<BUS_EquipmentType>>(url);
            //ViewBag.EquType = OperModel.Data.ToList();

            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }


        public ActionResult EqumentIndex1(string TargetId, int LoadApi)
        {
            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        //查看设备管理      
        public ActionResult EqumentView()
        {
            return View();
        }

        //获取仪器设备     
        [HttpPost]
        public JsonResult GetEqument(DgConModel dgCon)
        {
            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi == 0) return null;

            var TargetId = Request["TargetId"] ?? "";
            var EquType = Request["EquType"] ?? "";
            var FilterText = Request["FilterText"] ?? "";

            var queryCon = new JObject(
                new JProperty("TargetId", TargetId),
                new JProperty("EquType", EquType),
                new JProperty("FilterText", FilterText)
                );

            var OperModel = GetWabApiPageListForEasyDg<OperateModel<BUS_Equment>>(WebAPIHelper.GetEqumentAPI, dgCon, queryCon);

            DgListModel<BUS_Equment> Model = null;

            if (OperModel.Data == null)
            {
                Model = new DgListModel<BUS_Equment>(new List<BUS_Equment>(), 0);
            }
            else
            {
                Model = OperModel.Data;
            }

            return Json(Model, JsonRequestBehavior.AllowGet, "yyyy-MM-dd");
        }


        //样品台账      
        public ActionResult SampleIndex(string TargetId, int LoadApi)
        {
            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        //查看样品台账      
        public ActionResult SampleView()
        {
            return View();
        }

        //获取样品台账   
        [HttpPost]
        public JsonResult GetSample(DgConModel dgCon)
        {
            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi == 0) return null;

            var TargetId = Request["TargetId"] ?? "";
            var TypeId = Request["TypeId"] ?? "";
            var FilterText = Request["FilterText"] ?? "";
            var StartDate = Request["StartDate"] ?? "";
            var EndDate = Request["EndDate"] ?? "";

            var queryCon = new JObject(
                new JProperty("TargetId", TargetId),
                new JProperty("TypeId", TypeId),
                new JProperty("FilterText", FilterText),
                new JProperty("StartDate", StartDate),
                new JProperty("EndDate", EndDate)
                );

            var OperModel = GetWabApiPageListForEasyDg<OperateModel<BUS_Sample>>(WebAPIHelper.GetSampleAPI, dgCon, queryCon);

            DgListModel<BUS_Sample> Model = null;

            if (OperModel.Data == null)
            {
                Model = new DgListModel<BUS_Sample>(new List<BUS_Sample>(), 0);
            }
            else
            {
                Model = OperModel.Data;
            }

            return Json(Model, JsonRequestBehavior.AllowGet, "yyyy-MM-dd");
        }


        public ActionResult ReportView()
        {
            return View();
        }

        //合格报告台账      
        public ActionResult Report1Index(string TargetId, int LoadApi)
        {
            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        //获取合格报告台账   
        [HttpPost]
        public JsonResult GetReport1(DgConModel dgCon)
        {
            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi == 0) return null;

            var TargetId = Request["TargetId"] ?? "";
            var TypeId = Request["TypeId"] ?? "";
            var FilterText = Request["FilterText"] ?? "";
            var StartDate = Request["StartDate"] ?? "";
            var EndDate = Request["EndDate"] ?? "";

            var queryCon = new JObject(
                new JProperty("TargetId", TargetId),
                new JProperty("TypeId", TypeId),
                new JProperty("FilterText", FilterText),
                new JProperty("StartDate", StartDate),
                new JProperty("EndDate", EndDate)
                );

            var OperModel = GetWabApiPageListForEasyDg<OperateModel<BUS_ReportView>>(WebAPIHelper.GetReport1API, dgCon, queryCon);

            DgListModel<BUS_ReportView> Model = null;

            if (OperModel.Data == null)
            {
                Model = new DgListModel<BUS_ReportView>(new List<BUS_ReportView>(), 0);
            }
            else
            {
                Model = OperModel.Data;
            }

            return Json(Model, JsonRequestBehavior.AllowGet, "yyyy-MM-dd");

        }

        //不合格报告台账      
        public ActionResult Report2Index(string TargetId, int LoadApi)
        {
            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        //获取不合格报告台账   
        [HttpPost]
        public JsonResult GetReport2(DgConModel dgCon)
        {
            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi == 0) return null;

            var TargetId = Request["TargetId"] ?? "";
            var TypeId = Request["TypeId"] ?? "";
            var FilterText = Request["FilterText"] ?? "";
            var StartDate = Request["StartDate"] ?? "";
            var EndDate = Request["EndDate"] ?? "";

            var queryCon = new JObject(
                new JProperty("TargetId", TargetId),
                new JProperty("TypeId", TypeId),
                new JProperty("FilterText", FilterText),
                new JProperty("StartDate", StartDate),
                new JProperty("EndDate", EndDate)
                );

            var OperModel = GetWabApiPageListForEasyDg<OperateModel<BUS_ReportView>>(WebAPIHelper.GetReport2API, dgCon, queryCon);

            DgListModel<BUS_ReportView> Model = null;

            if (OperModel.Data == null)
            {
                Model = new DgListModel<BUS_ReportView>(new List<BUS_ReportView>(), 0);
            }
            else
            {
                Model = OperModel.Data;
            }

            return Json(Model, JsonRequestBehavior.AllowGet, "yyyy-MM-dd");

        }

        //检测报告台账      
        public ActionResult Report3Index(string TargetId, int LoadApi)
        {
            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        //获取检测报告台账   
        [HttpPost]
        public JsonResult GetReport3(DgConModel dgCon)
        {
            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi == 0) return null;

            var TargetId = Request["TargetId"] ?? "";
            var TypeId = Request["TypeId"] ?? "";
            var FilterText = Request["FilterText"] ?? "";
            var StartDate = Request["StartDate"] ?? "";
            var EndDate = Request["EndDate"] ?? "";

            var queryCon = new JObject(
                new JProperty("TargetId", TargetId),
                new JProperty("TypeId", TypeId),
                new JProperty("FilterText", FilterText),
                new JProperty("StartDate", StartDate),
                new JProperty("EndDate", EndDate)
                );

            var OperModel = GetWabApiPageListForEasyDg<OperateModel<BUS_ReportView>>(WebAPIHelper.GetReport3API, dgCon, queryCon);

            DgListModel<BUS_ReportView> Model = null;

            if (OperModel.Data == null)
            {
                Model = new DgListModel<BUS_ReportView>(new List<BUS_ReportView>(), 0);
            }
            else
            {
                Model = OperModel.Data;
            }

            return Json(Model, JsonRequestBehavior.AllowGet, "yyyy-MM-dd");
        }

        //环境设施      
        public ActionResult EquTypeIndex(string TargetId, int LoadApi)
        {
            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        //环境设施      
        public ActionResult EquTypeIndex1(string TargetId, int LoadApi)
        {
            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        //获取环境设施     
        [HttpPost]
        public JsonResult GetEquType(DgConModel dgCon)
        {
            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi == 0) return null;

            var TargetId = Request["TargetId"] ?? "";
            var FilterText = Request["FilterText"] ?? "";

            var queryCon = new JObject(
                new JProperty("TargetId", TargetId),
                new JProperty("FilterText", FilterText)
                );

            var OperModel = GetWabApiPageListForEasyDg<OperateModel<BUS_EquipmentType>>(WebAPIHelper.GetEquType1API, dgCon, queryCon);

            DgListModel<BUS_EquipmentType> Model = null;

            if (OperModel.Data == null)
            {
                Model = new DgListModel<BUS_EquipmentType>(new List<BUS_EquipmentType>(), 0);
            }
            else
            {
                Model = OperModel.Data;
            }

            return Json(Model, JsonRequestBehavior.AllowGet, "yyyy-MM-dd");

        }

        //获取试验类型下拉选择
        [HttpGet]
        public JsonResult GetEquTypeList(string TargetId)
        {
            if (string.IsNullOrEmpty(TargetId)) return null;
            string url = string.Format(WebAPIHelper.GetEquTypeAPI + "/{0}", TargetId);
            //var OperModel = HttpClientHelper.Get<OperateModel>(url);
            var OperModel = HttpClientHelper.Get<OperateList<BUS_EquipmentType>>(url);
                     
            var list = (from item in OperModel.Data
                        select new TreeNode
                         {
                             id = item.EquipmentTypeID,
                             value = item.EquipmentTypeName,
                             text = item.EquipmentTypeName                            
                         }).ToList();
            
            list.Insert(0, new TreeNode{ id =  "",value="",text =  "--全部--" });

            return Json(list, JsonRequestBehavior.AllowGet);

        }

        //获取试验类型下拉选择
        [HttpGet]
        public JsonResult GetSampleType()
        {
            string url = string.Format(WebAPIHelper.GetSampleTypeAPI);

            var OperModel = HttpClientHelper.Get<OperateList<BUS_SampleType>>(url);
                                   
            var list = OperModel.Data;

            var Model = (from r in list
                         where r.ParentID != null
                         orderby r.Order
                         select new TreeNode
                         {
                             _parentId = r.ParentID,
                             id = r.ID,
                             value = r.ID,
                             text = r.TypeName,
                             type = (list.Single(s => s.ParentID == null && s.ID == r.ParentID).TypeName)
                         }).ToList();


            Model.Insert(0, new TreeNode { id = "", value = "", text = "--全部--" });

            return Json(Model, JsonRequestBehavior.AllowGet);

        }

        //获取试验类型下拉选择
        [HttpGet]
        public JsonResult GetStatisticsType()
        {
            string url = string.Format(WebAPIHelper.GetStatisticsTypeAPI);

            var OperModel = HttpClientHelper.Get<OperateModel>(url);

            return Json(OperModel.Data, JsonRequestBehavior.AllowGet);

        }

        //外委台账      
        public ActionResult SubScttIndex(string TargetId, int LoadApi)
        {
            ViewBag.TargetId = TargetId;
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        //查看外委台账    
        public ActionResult SubScttView()
        {
            return View();
        }

        //获取外委台账
        [HttpPost]
        public JsonResult GetSubSctt(DgConModel dgCon)
        {
            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi == 0) return null;

            var TargetId = Request["TargetId"] ?? "";
            var FilterText = Request["FilterText"] ?? "";
            var StartDate = Request["StartDate"] ?? "";
            var EndDate = Request["EndDate"] ?? "";

            var queryCon = new JObject(
                new JProperty("TargetId", TargetId),
                new JProperty("FilterText", FilterText),
                new JProperty("StartDate", StartDate),
                new JProperty("EndDate", EndDate)
                );

            var OperModel = GetWabApiPageListForEasyDg<OperateModel<BUS_SubContractor>>(WebAPIHelper.GetSubCttAPI, dgCon, queryCon);

            DgListModel<BUS_SubContractor> Model = null;

            if (OperModel.Data == null)
            {
                Model = new DgListModel<BUS_SubContractor>(new List<BUS_SubContractor>(), 0);
            }
            else
            {
                Model = OperModel.Data;
            }

            return Json(Model, JsonRequestBehavior.AllowGet, "yyyy-MM-dd");

        }

        //统计分析   
        public ActionResult EChartIndex(string TargetId, int LoadApi)
        {

            //string url = string.Format(WebAPIHelper.GetStatisticsTypeAPI);
            //var OperModel = HttpClientHelper.Get<OperateList<BUS_StatisticsType>>(url);
            //ViewBag.ItemType = OperModel.Data.ToList();

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


    }
}