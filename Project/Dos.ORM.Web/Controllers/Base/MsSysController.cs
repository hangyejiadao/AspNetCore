using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Data.System;
using Dos.ORM.IData.System;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.System;
using Dos.ORM.Web.App_Common.Auth;
using Dos.ORM.Web.App_Common.Filter;

namespace Dos.ORM.Web.Controllers.Base
{
    /// <summary>
    /// 系统管理主控制器
    /// 系统管理中的所有控制器都继承自该控制器
    /// </summary>
    [CheckLoginFilter]//检查登录
    //[ErrorAttributeFilter]//错误异常
    public class MsSysController : BaseController
    {
        [Ninject.Inject]
        private ISYS_LogInfoData SysLogInfo { get; set; }

        #region 属性
        /// <summary>
        /// 用户相关信息
        /// </summary>
        protected MsSysUserModel MsSysUserModel;

        /// <summary>
        /// 操作类型（add、modify、view）
        /// </summary>
        protected string OType;

        /// <summary>
        /// 数据Id
        /// </summary>
        protected string KeyId;

        #endregion

        #region 重写
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            MsSysUserModel = MsSysUserAuth.Get();
            if (MsSysUserModel == null)
            {
                //判断是否有来自客户端的ajax请求
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    var requestObj = filterContext.HttpContext.Request["requestObj"];

                    //EasyUI datagrid自带的ajax请求
                    if (requestObj != null && requestObj == "EasyUI-DG")
                    {
                        filterContext.Result = new JsonResult
                        {
                            //此处约定total为-340，方便datagrid的onLoadSuccess方法进行操作
                            Data = new DgListModel<DgConModel>(new List<DgConModel>(),
                                -Convert.ToInt32(OperateRetType.LoginTimeout))
                        };
                    }
                    //jQuery的ajax请求
                    else
                    {
                        filterContext.Result = new JsonResult
                        {
                            Data = new OperateModel
                            {
                                Result = OperateRetType.LoginTimeout,
                                Msg = "登录已过期，请重新登录！"
                            }
                        };
                    }
                }
                else
                {
                    //跳转至登录过期页面
                    //filterContext.Result = RedirectToAction("LoginTimeout", "Common");
                    //使用以下方式便于从其他区域跳转至该Action
                    filterContext.Result = RedirectToAction("LoginTimeout", new { area = "MsSys", controller = "Common" });
                }
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            //是否为超级管理员、管理员类型、管理员名称
            ViewBag.IsSuperAdmin = MsSysUserModel.IsSuperAdmin;
            ViewBag.AccountType = MsSysUserModel.AccountType;
            ViewBag.AdminName = MsSysUserModel.AdminName;
            //公司Id
            ViewBag.CompanyId = MsSysUserModel.CompanyId;

            #region 枚举数据列表
            ViewBag.StatusType = new SelectList(EnumHelper.GetItemValueList<StatusType>(), "Key", "Value");
            #endregion

            //操作类型（add、modify、view）和数据Id
            OType = Request["oType"];
            KeyId = Request["keyId"];

            ViewBag.oType = OType;
            ViewBag.keyId = KeyId;

            //声明视图为操作页面的集合 TODO：此处以后可做成配置文件
            //var optActions = new List<string> { "Index", "Detail", "SaveData" };
            //var thisActionName = filterContext.ActionDescriptor.ActionName;
            //if (optActions.Any(m => string.Equals(m, thisActionName, StringComparison.CurrentCultureIgnoreCase)))
            //{
            //设置操作类型和数据keyId
            //if (Request["oType"] != null)
            //{
            //    //操作类型（add、modify、view）和数据Id
            //    OType = Request["oType"];
            //    KeyId = Request["keyId"];

            //    ViewBag.oType = OType;
            //    ViewBag.keyId = KeyId;
            //}
            //else
            //{
            //    OType = null;
            //    KeyId = null;
            //}
            // }
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

            SysLogInfo = SysLogInfo ?? new SYS_LogInfoData();

            string requestPath = filterContext.HttpContext.Request.FilePath;

            //记录异常日志文件到文本文件和数据库
            SysLogInfo.CreateExceptionLogForMsSysController(
                MsSysUserModel,
                requestPath, filterContext.Exception);
        }
        #endregion

        #region 方法

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