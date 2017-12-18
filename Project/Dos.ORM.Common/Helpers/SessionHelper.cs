/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2015-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：QUBER.Common.Helpers
 * 类名称：SessionHelper
 * 创建时间：2015-11-25 14:40:51
 * 创建人：Quber
 * 创建说明：Session帮助类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System.Web;

namespace Dos.ORM.Common.Helpers
{
    /// <summary>
    /// Session帮助类
    /// </summary>
    public static class SessionHelper
    {
        /// <summary>
        /// 设置Session
        /// </summary>
        /// <param name="key">Session名称</param>
        /// <param name="val">Session值</param>
        /// <param name="iExpires">过期时间（默认为30min）</param>
        public static void Set(string key, object val, int iExpires = 30)
        {
            HttpContext.Current.Session.Remove(key);
            HttpContext.Current.Session.Add(key, val);
            HttpContext.Current.Session.Timeout = iExpires;
        }

        /// <summary>
        /// 获取Session
        /// </summary>
        /// <param name="key">Session名称</param>
        /// <returns></returns>
        public static object Get(string key)
        {
            return HttpContext.Current.Session[key];
        }

        /// <summary>
        /// 删除Session
        /// </summary>
        /// <param name="key">Session名称</param>
        /// <returns></returns>
        public static void Delete(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }

        /// <summary>
        /// 删除所有的Session
        /// </summary>
        /// <returns></returns>
        public static void DeleteAll()
        {
            HttpContext.Current.Session.RemoveAll();
        }

        /// <summary>
        /// 清空所有的Session
        /// </summary>
        /// <returns></returns>
        public static void Clear()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}
