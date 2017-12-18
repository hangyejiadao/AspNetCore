/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Web.App_Common.Filter
 * 类名称：ParameterFilter
 * 创建时间：2016-08-31 16:25:27
 * 创建人：Quber
 * 创建说明：参数过滤器
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

namespace Dos.ORM.Web.App_Common.Filter
{
    /// <summary>
    /// 参数过滤器
    /// </summary>
    public class ParameterFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}