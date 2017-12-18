/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Web.App_Common.Filter
 * 类名称：LogFilter
 * 创建时间：2016-08-30 21:46:30
 * 创建人：Quber
 * 创建说明：日志信息过滤器
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Data.System;
using Dos.ORM.IData.System;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.System;
using Dos.ORM.Web.App_Common.Auth;
using Dos.ORM.Web.App_Common.Mvc;

namespace Dos.ORM.Web.App_Common.Filter
{
    /// <summary>
    /// 日志信息过滤器
    /// </summary>
    public class ResultLogFilter : ActionFilterAttribute
    {
        [Ninject.Inject]
        private ISYS_LogInfoData SysLogInfo { get; set; }

        /// <summary>
        /// 执行的OnResult，默认为2（1：OnResultExecuted、2：OnResultExecuting、3：OnActionExecuting、4：OnActionExecuted）
        /// </summary>
        public int ExecType = 2;

        /// <summary>
        /// 用户相关信息
        /// </summary>
        private static MsSysUserModel _msSysUserModel;

        /// <summary>
        /// 日志类型（默认为操作日志：DataOperation）
        /// </summary>
        public LogType LogType = LogType.DataOperation;

        /// <summary>
        /// 操作类型（默认为查询：Search）
        /// </summary>
        public OperateBtn OptType = OperateBtn.Search;

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);

            SysLogInfo = SysLogInfo ?? new SYS_LogInfoData();

            if (ExecType == 2)
            {
                string resultName = filterContext.Result.GetType().Name;
                var optRetType = new object();

                if (resultName == "JsonResultOverride")
                {
                    optRetType = ((JsonResultOverride)filterContext.Result).Data;
                }

                _msSysUserModel = MsSysUserAuth.Get();

                SysLogInfo.CreateResultLogForFilter(
                    _msSysUserModel,
                    LogType,
                    OptType,
                    filterContext.HttpContext.Request.FilePath,
                    filterContext.HttpContext.Request["oType"],
                    filterContext.HttpContext.Request["keyId"],
                    resultName,
                    optRetType);
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            SysLogInfo = SysLogInfo ?? new SYS_LogInfoData();

            if (ExecType == 3)
            {
                string resultName = filterContext.Result != null ? filterContext.Result.GetType().Name : null;
                var optRetType = new object();

                if (resultName == "JsonResultOverride")
                {
                    optRetType = ((JsonResultOverride)filterContext.Result).Data;
                }

                _msSysUserModel = MsSysUserAuth.Get();

                SysLogInfo.CreateResultLogForFilter(
                    _msSysUserModel,
                    LogType,
                    OptType,
                    filterContext.HttpContext.Request.FilePath,
                    filterContext.HttpContext.Request["oType"],
                    filterContext.HttpContext.Request["keyId"],
                    resultName,
                    optRetType);
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}