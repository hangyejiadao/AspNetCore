using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.Model.Models;
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
    public class BhzSysController : SubBaseController
    {


        #region 拌合站设置

        public ActionResult BhzSysIndex1(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult BhzSysDetail1(string BhzApi,string TargetId, string KeyId)
        {
            ViewBag.BhzApi = BhzApi;
            ViewBag.TargetId = TargetId;
            ViewBag.KeyId = KeyId;
            return View();
        }

        //查询
        [HttpGet]
        public JsonResult GetBhzBhjList(string BhzApi,string TargetId, int LoadApi)
        {
            if (string.IsNullOrEmpty(BhzApi)) return null;

            if (LoadApi != 1) return null;

            if (string.IsNullOrEmpty(TargetId)) TargetId = Guid.Empty.ToString();

            string url = string.Format(BhzApi+BHZAPIHelper.GetBhjListAPI + "/{0}", TargetId);

            var OperModel = HttpClientHelper.Get<OperateList<BHZ_BHZBHJ>>(url);

            var model = new DgListModel<BHZ_BHZBHJ>(OperModel.Data, 1000);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //根据ID加载
        [HttpPost]
        public JsonResult GetBhzBhjByID(string BhzApi,string TargetId, string KeyId)
        {
            if (string.IsNullOrEmpty(BhzApi)) return null;

            //keyId为空时；新增 
            if (string.IsNullOrEmpty(KeyId)) KeyId = Guid.Empty.ToString();

            string url = string.Format(BhzApi+BHZAPIHelper.GetBhjGetAPI + @"/{0}/{1}", TargetId, KeyId);

            var OperModel = HttpClientHelper.Get<OperateModel>(url);

            return Json(OperModel, JsonRequestBehavior.AllowGet);

        }

        //保存       
        [HttpPost]
        public JsonResult SaveBhzBhjData(string BhzApi,string OType)
        {
            if (string.IsNullOrEmpty(BhzApi)) return null;

            string url = string.Format(BhzApi+BHZAPIHelper.GetBhjSaveAPI + "/{0}", OType);

            var Model = GetModelObject<BHZ_BHZBHJ>();

            var OperModel = HttpClientHelper.Post<OperateModel>(url, JsonHelper.ObjectToJson<BHZ_BHZBHJ>(Model));

            return Json(OperModel, JsonRequestBehavior.AllowGet);

        }

        //删除
        [HttpGet]
        public JsonResult DelBhzBhjByID(string BhzApi,string Id)
        {
            if (string.IsNullOrEmpty(BhzApi)) return null;

            if (string.IsNullOrEmpty(Id)) return null; ;

            string url = string.Format(BhzApi+BHZAPIHelper.GetBhjDelAPI + "/{0}", Id);

            var OperModel = HttpClientHelper.Get<OperateModel>(url);

            return Json(OperModel, JsonRequestBehavior.AllowGet);
        }


        #endregion


        #region 报警参数设置

        public ActionResult BhzSysIndex2(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        //获取    
        [HttpGet]
        public JsonResult GetBhzParmData(string BhzApi,string TargetId, int LoadApi)
        {
            if (string.IsNullOrEmpty(BhzApi)) return null;
            if (LoadApi != 1) return null;

            string url = string.Format(BhzApi+BHZAPIHelper.GetBhzParamAPI + "/{0}", TargetId);

            var OperModel = HttpClientHelper.Get<OperateModel>(url);

            return Json(OperModel.Data, JsonRequestBehavior.AllowGet);

        }

        //获取已设置参数的试验室列表     
        [HttpGet]
        public JsonResult GetParmSetLabs(string BhzApi)
        {
            var UserID = LoginUser.User.ID;

            string url = string.Format(BhzApi+BHZAPIHelper.GetParamSetLabsAPI);

            var OperModel = HttpClientHelper.Get<OperateModel>(url);

            return Json(OperModel.Data, JsonRequestBehavior.AllowGet);

        }

        //保存       
        [HttpPost]
        public JsonResult SaveBhzParmData(string BhzApi)
        {
            if (string.IsNullOrEmpty(BhzApi)) return null;

            string url = string.Format(BhzApi+BHZAPIHelper.GetSaveParamAPI);
            var model = GetModelObject<BHZ_ParamOverSet>();
            var OperModel = HttpClientHelper.Post<OperateModel>(url, JsonHelper.ObjectToJson<BHZ_ParamOverSet>(model));

            return Json(OperModel, JsonRequestBehavior.AllowGet);

        }

        #endregion


        #region 手机号配置
        public ActionResult BhzSysIndex3(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        //获取已设置参数-1     
        [HttpGet]
        public JsonResult GetSmsSetOneLabs(string BhzApi)
        {
            if (string.IsNullOrEmpty(BhzApi)) return null;
            string url = string.Format(BhzApi+BHZAPIHelper.GetSmsOneLabsAPI);

            var OperModel = HttpClientHelper.Get<OperateModel>(url);

            return Json(OperModel.Data, JsonRequestBehavior.AllowGet);

        }

        //获取已设置参数-2     
        [HttpGet]
        public JsonResult GetSmsSetTwoLabs(string BhzApi)
        {
            string url = string.Format(BhzApi+BHZAPIHelper.GetSmsTwoLabsAPI);

            var OperModel = HttpClientHelper.Get<OperateModel>(url);

            return Json(OperModel.Data, JsonRequestBehavior.AllowGet);

        }

        //获取已设置参数-3     
        [HttpGet]
        public JsonResult GetSmsSetThreeLabs(string BhzApi)
        {
            string url = string.Format(BhzApi+BHZAPIHelper.GetSmsThreeLabsAPI);

            var OperModel = HttpClientHelper.Get<OperateModel>(url);

            return Json(OperModel.Data, JsonRequestBehavior.AllowGet);

        }

        //获取1 
        [HttpGet]
        public JsonResult GetBhzSmsOneData(string BhzApi, string TargetId, int LoadApi)
        {
            if (string.IsNullOrEmpty(BhzApi)) return null;
            if (LoadApi != 1) return null;

            string url = string.Format(BhzApi+BHZAPIHelper.GetBhzSmsOneAPI + "/{0}", TargetId);

            var OperModel = HttpClientHelper.Get<OperateModel>(url);

            return Json(OperModel.Data, JsonRequestBehavior.AllowGet);

        }

        //获取2 
        [HttpGet]
        public JsonResult GetBhzSmsTwoData(string BhzApi, string TargetId, int LoadApi)
        {
            if (string.IsNullOrEmpty(BhzApi)) return null;
            if (LoadApi != 1) return null;

            string url = string.Format(BhzApi+BHZAPIHelper.GetBhzSmsTwoAPI + "/{0}", TargetId);

            var OperModel = HttpClientHelper.Get<OperateModel>(url);

            return Json(OperModel.Data, JsonRequestBehavior.AllowGet);

        }

        //获取3
        [HttpGet]
        public JsonResult GetBhzSmsThreeData(string BhzApi, string TargetId, int LoadApi)
        {
            if (string.IsNullOrEmpty(BhzApi)) return null;
            if (LoadApi != 1) return null;

            string url = string.Format(BhzApi+BHZAPIHelper.GetBhzSmsThreeAPI + "/{0}", TargetId);

            var OperModel = HttpClientHelper.Get<OperateModel>(url);

            return Json(OperModel.Data, JsonRequestBehavior.AllowGet);

        }


        //保存1     
        [HttpPost]
        public JsonResult SaveBhzSmsOneData(string BhzApi)
        {
            if (string.IsNullOrEmpty(BhzApi)) return null;
            string url = BhzApi+BHZAPIHelper.GetSaveSmsOneAPI;
            var model = GetModelObject<BHZ_SmsSetOne>();
            var OperModel = HttpClientHelper.Post<OperateModel>(url, JsonHelper.ObjectToJson<BHZ_SmsSetOne>(model));

            return Json(OperModel, JsonRequestBehavior.AllowGet);

        }


        //保存2     
        [HttpPost]
        public JsonResult SaveBhzSmsTwoData(string BhzApi)
        {
            if (string.IsNullOrEmpty(BhzApi)) return null;
            string url = BhzApi + BHZAPIHelper.GetSaveSmsTwoAPI;
            var model = GetModelObject<BHZ_SmsSetTwoModel>();
            var OperModel = HttpClientHelper.Post<OperateModel>(url, JsonHelper.ObjectToJson<BHZ_SmsSetTwoModel>(model));

            return Json(OperModel, JsonRequestBehavior.AllowGet);

        }


        //保存3     
        [HttpPost]
        public JsonResult SaveBhzSmsThreeData(string BhzApi)
        {
            if (string.IsNullOrEmpty(BhzApi)) return null;
            string url = BhzApi + BHZAPIHelper.GetSaveSmsThreeAPI;
            var model = GetModelObject<BHZ_SmsSetThree>();
            var OperModel = HttpClientHelper.Post<OperateModel>(url, JsonHelper.ObjectToJson<BHZ_SmsSetThree>(model));

            return Json(OperModel, JsonRequestBehavior.AllowGet);

        }



        #endregion


        #region 上传异常设置

        public ActionResult BhzSysIndex4(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        public ActionResult BhzSysDetail4(string BhzApi,string KeyId)
        {
            ViewBag.BhzApi = BhzApi;
            ViewBag.KeyId = KeyId;
            return View();
        }

        //查询
        [HttpGet]
        public JsonResult GetSmsSetExceptList(string BhzApi,string TargetId, int LoadApi)
        {

            if (string.IsNullOrEmpty(BhzApi)) return null;
            if (LoadApi != 1) return null;

            if (string.IsNullOrEmpty(TargetId)) TargetId = Guid.Empty.ToString();

            string url = string.Format(BhzApi+BHZAPIHelper.GetExceptListAPI + "/{0}", TargetId);

            var OperModel = HttpClientHelper.Get<OperateList<BHZ_SmsSetExceptModel>>(url);

            var model = new DgListModel<BHZ_SmsSetExceptModel>(OperModel.Data, 1000);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //根据ID加载
        [HttpGet]
        public JsonResult GetSmsExceptByID(string BhzApi,string KeyID)
        {
            if (string.IsNullOrEmpty(BhzApi)) return null;
            //keyId为空时；新增 
            if (string.IsNullOrEmpty(KeyID)) KeyID = Guid.Empty.ToString();

            string url = string.Format(BhzApi+BHZAPIHelper.GetExceptByIdAPI + @"/{0}", KeyID);

            var OperModel = HttpClientHelper.Get<OperateModel>(url);

            return Json(OperModel.Data, JsonRequestBehavior.AllowGet);
        }

        //保存       
        [HttpPost]
        public JsonResult SaveSmsExceptData(string BhzApi)
        {
            if (string.IsNullOrEmpty(BhzApi)) return null;

            string url = BhzApi+BHZAPIHelper.GetExceptSaveAPI;

            var Model = GetModelObject<BHZ_SmsSetExcept>();

            var OperModel = HttpClientHelper.Post<OperateModel>(url, JsonHelper.ObjectToJson<BHZ_SmsSetExcept>(Model));

            return Json(OperModel, JsonRequestBehavior.AllowGet);

        }

        #endregion


        #region 发送短信查询

        public ActionResult BhzSysIndex5(int LoadApi)
        {
            ViewBag.LoadApi = LoadApi;
            return View();
        }

        //查询
        [HttpPost]
        public JsonResult GetSmsRecordList(DgConModel dgCon)
        {
          
            var BhzApi = Request["BhzApi"] ?? "";
            if (string.IsNullOrEmpty(BhzApi)) return null;

            var LoadApi = Int32.Parse(Request["LoadApi"]);
            if (LoadApi != 1) return null;

            var OrganID = Request["OrganID"] ?? "";
            var StartDate = Request["StartDate"] ?? "";
            var EndDate = Request["EndDate"] ?? "";
            var SmsType = Request["SmsType"] ?? "";
            var Phone = Request["Phone"] ?? "";

            var queryCon = new JObject(
                new JProperty("OrganID", OrganID),
                new JProperty("StartDate", StartDate),
                new JProperty("EndDate", EndDate),
                new JProperty("SmsType", SmsType),
                new JProperty("Phone", Phone)
                );

            var OperModel = GetWabApiPageListForEasyDg<OperateModel<object>>(BhzApi+BHZAPIHelper.GetSmsRcdListAPI, dgCon, queryCon);

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



    }


}
