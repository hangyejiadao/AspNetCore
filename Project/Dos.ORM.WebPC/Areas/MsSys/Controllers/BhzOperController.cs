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
    public class BhzOperController : SubBaseController
    {

        #region 基础查询

        //拌合机下拉选择
        [HttpGet]
        public JsonResult GetBhzBhjList(string BhzApi,string TargetId)
        {

            List<BHZ_BHZBHJ> list = null;
            if (!string.IsNullOrEmpty(TargetId))
            {    
                string url = string.Format(BhzApi+BHZAPIHelper.GetBhzBhjAPI + "/{0}", TargetId);

                var OperModel = HttpClientHelper.Get<OperateList<BHZ_BHZBHJ>>(url);

                list = OperModel.Data;

                if (list != null && list.Count > 0)
                {
                    list = list.Where(s => s.ParentID != null).OrderBy(s => s.BlendNO).ToList();
                }
            }


            return Json(list, JsonRequestBehavior.AllowGet);

        }


        //拌合机下拉选择-未用
        [HttpGet]
        public JsonResult GetBhzBhjList1(string BhzApi,string TargetId)
        {
          
            string url = string.Format(BhzApi+BHZAPIHelper.GetBhzBhjAPI + "/{0}", TargetId);
            //var OperModel = HttpClientHelper.Get<OperateModel>(url);
            var OperModel = HttpClientHelper.Get<OperateList<BHZ_BHZBHJ>>(url);

            var list = OperModel.Data;

            var Model = (from r in list
                         where r.ParentID != null
                         orderby r.BlendNO
                         select new TreeNode
                         {
                             _parentId = r.ParentID,
                             id = r.ID,
                             value = r.BlendNO,
                             text = r.BlendName + "(" + r.BlendNO + ")",
                             type = (list.Single(s => s.ParentID == null && s.ID == r.ParentID).BlendName)
                         }).ToList();


            Model.Insert(0, new TreeNode { id = "", value = "", text = "--全部--" });

            return Json(Model, JsonRequestBehavior.AllowGet);

        }


        //获取强度等级-未用
        [HttpGet]
        public JsonResult GetBhzQddjList(string BhzApi)
        {
            if (string.IsNullOrEmpty(BhzApi)) return null;

            string url = string.Format(BhzApi + BHZAPIHelper.GetBhzQddjAPI);

            var OperModel = HttpClientHelper.Get<OperateModel>(url);

            return Json(OperModel.Data, JsonRequestBehavior.AllowGet);

        }

        //获取拌合站超标参数-未用       
        [HttpGet]
        public JsonResult GetBhzParmData(string BhzApi,string TargetId)
        {           
            string url = string.Format(BhzApi+BHZAPIHelper.GetBhzParamAPI + "/{0}", TargetId);

            var OperModel = HttpClientHelper.Get<OperateModel>(url);

            return Json(OperModel.Data, JsonRequestBehavior.AllowGet);

        }

        //获取列设置     
        [HttpGet]
        public JsonResult GetTabColSet(string BhzApi, string TableCode)
        {       
            if (string.IsNullOrEmpty(BhzApi)) return null;

            var UserID = LoginUser.User.ID;    
  
            string url = string.Format(BhzApi+BHZAPIHelper.GetTabColByAPI + "/{0}/{1}", TableCode, UserID);

            var OperModel = HttpClientHelper.Get<OperateModel>(url);

            return Json(OperModel.Data, JsonRequestBehavior.AllowGet);

        }

        //保存列设置    
        [HttpPost]
        public JsonResult SaveTabColSet(string BhzApi, string TabCol)
        {
            string url =BhzApi+ BHZAPIHelper.GetTabColSaveAPI;

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


        //动态监控-实时监控—BhzIndex1_1
        [HttpPost]
        public JsonResult GetBhzMx1Data(DgConModel dgCon)
        {

            var jsRst= Json(new DgListModel<object>(new List<object>(), 0), JsonRequestBehavior.AllowGet);

            var BhzApi = Request["BhzApi"] ?? "";
            if (string.IsNullOrEmpty(BhzApi)) return jsRst;

            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi != 1) return jsRst;

            var OrganID = Request["OrganID"] ?? "";
            var PostType = Request["PostType"] ?? "0";
            var StartDate = Request["StartDate"] ?? "";
            var EndDate = Request["EndDate"] ?? "";
            var BHJBH = Request["BHJBH"] ?? "";
            var QDDJ = Request["QDDJ"] ?? "";
            var FilterText = Request["FilterText"] ?? "";

            var queryCon = new JObject(
                new JProperty("OrganID", OrganID),
                new JProperty("PostType", PostType),
                new JProperty("StartDate", StartDate),
                new JProperty("EndDate", EndDate),
                new JProperty("BHJBH", BHJBH),
                new JProperty("QDDJ", QDDJ),
                new JProperty("FilterText", FilterText)
                );

            var OperModel = GetWabApiPageListForEasyDg<OperateModel<object>>(BhzApi+BHZAPIHelper.GetBhzMx1API, dgCon, queryCon);

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


        //动态监控-超标记录—BhzIndex1_2
        [HttpPost]
        public JsonResult GetBhzMx2Data(DgConModel dgCon)
        {
            var jsRst = Json(new DgListModel<object>(new List<object>(), 0), JsonRequestBehavior.AllowGet);

            var BhzApi = Request["BhzApi"] ?? "";
            if (string.IsNullOrEmpty(BhzApi)) return jsRst;

            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi != 1) return jsRst;

            var OrganID = Request["OrganID"] ?? "";
            var PostType = Request["PostType"] ?? "0";
            var StartDate = Request["StartDate"] ?? "";
            var EndDate = Request["EndDate"] ?? "";
            var BHJBH = Request["BHJBH"] ?? "";
            var QDDJ = Request["QDDJ"] ?? "";
            var FilterText = Request["FilterText"] ?? "";

            var queryCon = new JObject(
                new JProperty("OrganID", OrganID),
                new JProperty("PostType", PostType),
                new JProperty("StartDate", StartDate),
                new JProperty("EndDate", EndDate),
                new JProperty("BHJBH", BHJBH),
                new JProperty("QDDJ", QDDJ),
                new JProperty("FilterText", FilterText)
                );
            
            var OperModel = GetWabApiPageListForEasyDg<OperateModel<object>>(BhzApi+BHZAPIHelper.GetBhzMx2API, dgCon, queryCon);

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


        #region 生产任务

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

        public ActionResult BhzView(string KeyId, string BhzApi)
        {
            ViewBag.KeyId = KeyId;
            ViewBag.BhzApi = BhzApi;
            return View();
        }


        //生产任务-用量偏差—BhzIndex2_1 
        [HttpPost]
        public JsonResult GetBhzZbData(DgConModel dgCon)
        {
            var jsRst = Json(new DgListModel<object>(new List<object>(), 0), JsonRequestBehavior.AllowGet);

            var BhzApi = Request["BhzApi"] ?? "";
            if (string.IsNullOrEmpty(BhzApi)) return jsRst;

            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi != 1) return jsRst;
            
            var OrganID = Request["OrganID"] ?? "";
            var PostType = Request["PostType"] ?? "0";
            var StartDate = Request["StartDate"] ?? "";
            var EndDate = Request["EndDate"] ?? "";
            var QDDJ = Request["QDDJ"] ?? "";
            var FilterText = Request["FilterText"] ?? "";

            var queryCon = new JObject(
                new JProperty("OrganID", OrganID),
                new JProperty("PostType", PostType),
                new JProperty("StartDate", StartDate),
                new JProperty("EndDate", EndDate),
                new JProperty("QDDJ", QDDJ),
                new JProperty("FilterText", FilterText)
                );

            var OperModel = GetWabApiPageListForEasyDg<OperateModel<object>>(BhzApi+BHZAPIHelper.GetBhzZbAPI, dgCon, queryCon);

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

        //生产任务-用量偏差-明细表列  
        [HttpPost]
        public JsonResult GetBhzMxData(DgConModel dgCon)
        {
            var BhzApi = Request["bhzApi"] ?? "";
            if (string.IsNullOrEmpty(BhzApi)) return null;

            var ZBID = Request["id"] ?? "";
            var BHJBH = Request["code"] ?? "";

            var queryCon = new JObject(
                new JProperty("ZBID", ZBID),
                new JProperty("BHJBH", BHJBH)
                );

            var OperModel = GetWabApiPageListForEasyDg<OperateModel<object>>(BhzApi+BHZAPIHelper.GetBhzMxAPI, dgCon, queryCon);

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

        //生产任务-实际用量—BhzIndex2_2
        [HttpPost]
        public JsonResult GetBhzFlData(DgConModel dgCon)
        {
            var jsRst = Json(new DgListModel<object>(new List<object>(), 0), JsonRequestBehavior.AllowGet);

            var BhzApi = Request["BhzApi"] ?? "";
            if (string.IsNullOrEmpty(BhzApi)) return jsRst;

            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi != 1) return jsRst;

            var OrganID = Request["OrganID"] ?? "";
            var PostType = Request["PostType"] ?? "0";
            var StartDate = Request["StartDate"] ?? "";
            var EndDate = Request["EndDate"] ?? "";
            var QDDJ = Request["QDDJ"] ?? "";
            var FilterText = Request["FilterText"] ?? "";

            var queryCon = new JObject(
                new JProperty("OrganID", OrganID),
                new JProperty("PostType", PostType),
                new JProperty("StartDate", StartDate),
                new JProperty("EndDate", EndDate),
                new JProperty("QDDJ", QDDJ),
                new JProperty("FilterText", FilterText)
                );

            var OperModel = GetWabApiPageListForEasyDg<OperateModel<object>>(BhzApi+BHZAPIHelper.GetBhzFlAPI, dgCon, queryCon);

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


        #region 统计报表

        public ActionResult BhzIndex4_1(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult BhzIndex4_2(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult BhzIndex4_3(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }


        //统计报表-混凝土产量统计   
        [HttpGet]
        public JsonResult GetBhzRpt1Data()
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


            var OperModel = GetWabApiPageListForEasyDg<OperateModel>(BhzApi+BHZAPIHelper.GetBhzRpt1API, null, queryCon);

            if (OperModel.Result == OperateRetType.Success)
            {

                var QddjModel = HttpClientHelper.Get<OperateModel>(BhzApi+BHZAPIHelper.GetBhzQddjAPI);

                var Model = new
                {
                    columns = QddjModel.Data,
                    items = OperModel.Data
                };

                OperModel.Data = Model;
            }

            return Json(OperModel, JsonRequestBehavior.AllowGet);

        }

        //统计报表-混凝土超标统计   
        [HttpGet]
        public JsonResult GetBhzRpt2Data()
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


            var OperModel = GetWabApiPageListForEasyDg<OperateModel>(BhzApi + BHZAPIHelper.GetBhzRpt2API, null, queryCon);

            if (OperModel.Result == OperateRetType.Success)
            {

                var QddjModel = HttpClientHelper.Get<OperateModel>(BhzApi+BHZAPIHelper.GetBhzQddjAPI);

                var Model = new
                {
                    columns = QddjModel.Data,
                    items = OperModel.Data
                };

                OperModel.Data = Model;
            }

            return Json(OperModel, JsonRequestBehavior.AllowGet);

        }

        //统计报表-原材料消耗统计   
        [HttpGet]
        public JsonResult GetBhzRpt3Data()
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


            var OperModel = GetWabApiPageListForEasyDg<OperateModel>(BhzApi+BHZAPIHelper.GetBhzRpt3API, null, queryCon);


            return Json(OperModel, JsonRequestBehavior.AllowGet);

        }

        #endregion


        #region 智能监测

        public ActionResult BhzIndex5_1(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult BhzIndex5_2(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult BhzIndex5_3(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }


        //智能监测-拌合机联网状态/拌合机采集状态      
        [HttpGet]
        public JsonResult GetBhzBhjData(string BhzApi,string TargetId, int LoadApi)
        {
           
            if (string.IsNullOrEmpty(BhzApi)) return null;

            if (LoadApi != 1) return null;

            if (string.IsNullOrEmpty(TargetId)) TargetId = Guid.Empty.ToString();

            string url = string.Format(BhzApi+BHZAPIHelper.GetBhjStateAPI + "/{0}", TargetId);

            var OperModel = HttpClientHelper.Get<OperateModel>(url);

            return Json(OperModel.Data, JsonRequestBehavior.AllowGet);

        }

        //智能监测-数据上传异常提醒   
        [HttpGet]
        public JsonResult GetBhzTipData(string BhzApi, string TargetId, int LoadApi)
        {
            if (string.IsNullOrEmpty(BhzApi)) return null;

            if (LoadApi != 1) return null;

            if (string.IsNullOrEmpty(TargetId)) TargetId = Guid.Empty.ToString();

            string url = string.Format(BhzApi+BHZAPIHelper.GetBhjTipAPI + "/{0}", TargetId);

            var OperModel = HttpClientHelper.Get<OperateModel>(url);

            return Json(OperModel.Data, JsonRequestBehavior.AllowGet);

        }

        #endregion
                    

    }

}