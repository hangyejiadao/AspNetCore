/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Common.Helpers
 * 类名称：CookieHelper
 * 创建时间：2016-11-11 15:52:17
 * 创建人：Quber
 * 创建说明：Cookie帮助类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Web;

namespace Dos.ORM.Common.Helpers
{
    /// <summary>
    /// Cookie帮助类
    /// </summary>
    public static class CookieHelper
    {
        /// <summary>  
        /// 添加一个Cookie（24小时过期）  
        /// </summary>  
        /// <param name="cookieName">名称</param>  
        /// <param name="cookieValue"></param>  
        public static void Set(string cookieName, string cookieValue)
        {
            Set(cookieName, cookieValue, DateTime.Now.AddDays(1.0));
        }

        /// <summary>  
        /// 添加一个Cookie  
        /// </summary>  
        /// <param name="cookieName">Cookie名称</param>  
        /// <param name="cookieValue">Cookie值</param>  
        /// <param name="expires">过期时间 DateTime</param>  
        public static void Set(string cookieName, string cookieValue, DateTime expires)
        {
            HttpCookie cookie = new HttpCookie(cookieName)
            {
                Value = cookieValue,
                Expires = expires
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>  
        /// 获取指定Cookie值  
        /// </summary>  
        /// <param name="cookieName">Cookie名称</param>  
        /// <returns></returns>  
        public static string Get(string cookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            string str = string.Empty;
            if (cookie != null)
            {
                str = cookie.Value;
            }
            return str;
        }

        /// <summary>  
        /// 删除指定Cookie  
        /// </summary>  
        /// <param name="cookieName">Cookie名称</param>  
        public static void Delete(string cookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddYears(-3);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
    }
}
