using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
//using Dos.ORM.Data.System;
//using Dos.ORM.IData.System;
using Dos.ORM.Model.Base;
using Dos.ORM.WebPC.App_Common.Auth;
using Dos.ORM.WebPC.App_Common.Filter;
using Newtonsoft.Json.Linq;

namespace Dos.ORM.WebPC.Controllers.Base
{
    /// <summary>
    /// 系统管理主控制器
    /// 系统管理中的所有控制器都继承自该控制器
    /// </summary>
    [CheckLoginFilter]//检查登录
    //[ErrorAttributeFilter]//错误异常
    public class SubBaseController : BaseController
    {
       
        #region 属性

        protected LoginUserModel LoginUser = LoginUserAuth.Get();

        #endregion

        #region 重写
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            LoginUser = LoginUserAuth.Get();
            if (LoginUser == null)
            {
                string controllerName = filterContext.RouteData.Values["controller"].ToString().ToLower();
                string actionName = filterContext.RouteData.Values["action"].ToString().ToLower();
                if (controllerName == "login" && actionName == "index") return;
                if (controllerName == "login" && actionName == "checklogin") return;
                if (controllerName == "login" && actionName == "validatecode") return;
                              
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = Json(-401, JsonRequestBehavior.AllowGet);
                }
                else
                {                  
                    //filterContext.Result = new RedirectResult("/MsSys/Login/Index");
                    filterContext.Result = RedirectToAction("Index", new { area = "MsSys", controller = "Login" });
                }
            }

            base.OnAuthorization(filterContext);

        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {         

            //是否为超级管理员、管理员类型、管理员名称
            //ViewBag.IsAdmin = LoginUser.IsAdmin;

            //var LoginUser = LoginUserAuth.Get();
            //if (LoginUser != null)
            //{
            //    ViewBag._LoginUserID = LoginUser.UserID;
            //    ViewBag._ThemeNameID = LoginUser.ThemeName;
            //}

            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
          
        }
        #endregion

        #region 方法

        /// <summary>
        /// 获取WebApi接口提供的分页数据（EasyUI datagrid控件所用）
        /// </summary>
        /// <param name="strApiAddress">WebApi接口地址</param>
        /// <param name="dgCon">easyui datagrid控件默认分页参数实体</param>
        /// <param name="queryCon">数据查询条件</param>
        /// <returns></returns>
        public DgListModel GetWabApiPageListForEasyDg(string strApiAddress, DgConModel dgCon, JObject queryCon)
        {
            //返回EasyUI Datagrid所需数据实体对象
            DgListModel retModel = null;

            #region 组合条件
            JObject conObj = null;
            if (queryCon == null)
            {
                conObj = new JObject
                {
                    new JProperty("PageIndex", dgCon.page),
                    new JProperty("PageSize", dgCon.rows)
                };
            }
            else
            {
                conObj = queryCon;
                conObj.Add(new JProperty("PageIndex", dgCon.page));
                conObj.Add(new JProperty("PageSize", dgCon.rows));
            }
            #endregion

            var queryData = HttpClientHelper.Post<OperateModel>(strApiAddress, JsonHelper.ObjectToJson(conObj));

            if (queryData.Result == OperateRetType.Success)
            {
                var retObj = JsonHelper.JsonToObject<ApiPageRetModel>(JsonHelper.ObjectToJson(queryData.Data));
                retModel = new DgListModel(retObj.List, retObj.TotalCount);
            }

            return retModel;
        }


        public T GetWabApiPageListForEasyDg<T>(string strApiAddress, DgConModel dgCon, JObject queryCon) where T : class,new()
        {
            T result = default(T);

            #region 组合条件
            JObject conObj = null;
            if (queryCon == null)
            {
                conObj = new JObject
                {
                    new JProperty("PageIndex", dgCon.page),
                    new JProperty("PageSize", dgCon.rows)
                };
            }
            else
            {
                conObj = queryCon;
                if (dgCon != null)
                {
                    conObj.Add(new JProperty("PageIndex", dgCon.page));
                    conObj.Add(new JProperty("PageSize", dgCon.rows));
                }
            }
            #endregion

            result = HttpClientHelper.Post<T>(strApiAddress, JsonHelper.ObjectToJson(conObj));

            return result;
        }
        
        public T GetModelObject<T>() where T : class
        {
            var request = System.Web.HttpContext.Current.Request;
            var bytes = request.BinaryRead(request.ContentLength);
            var requestData = System.Text.Encoding.UTF8.GetString(bytes);
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(requestData);
            return obj;
        }

        #endregion
    }
}