/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2015-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：QUBER.Web.App_Common.Filter
 * 类名称：CheckLoginFilter
 * 创建时间：2015-11-25 15:52:30
 * 创建人：Quber
 * 创建说明：检查登录过滤器
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System.Web.Mvc;

namespace Dos.ORM.Web.App_Common.Filter
{
    /// <summary>
    /// 检查登录过滤器
    /// </summary>
    //[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]//此标记的作用：如果某控制器顶部和该控制器中的某个Action都是用了该过滤器，那么，该控制器下的这个Action会执行2次。反之则以使用该过滤器为标准来执行，一般情况不设置该标记。
    public class CheckLoginFilter : ActionFilterAttribute
    {
        /*
         * 可重写的Action：
         *      OnActionExecuting：Action执行之前
         *      OnActionExecuted：Action执行之后
         *      OnResultExecuting：返回Result之前
         *      OnResultExecuted：返回Result之后
         */

        /// <summary>
        /// 检查用户是否登录，否则跳转至登陆页
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //TODO...服务端检查登录逻辑...
            //if (1 == 2)
            //{
            //    filterContext.Result = new RedirectResult("/MsSys/Login/Index");
            //}
        }
    }
}