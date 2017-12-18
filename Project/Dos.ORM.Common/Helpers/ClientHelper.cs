/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Common.Helpers
 * 类名称：ClientHelper
 * 创建时间：2016-08-31 21:31:59
 * 创建人：Quber
 * 创建说明：客户端帮助类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Text.RegularExpressions;
using System.Web;

namespace Dos.ORM.Common.Helpers
{
    /// <summary>
    /// 客户端帮助类
    /// </summary>
    public static class ClientHelper
    {
        /// <summary>
        /// 获取浏览器名称
        /// </summary>
        /// <returns></returns>
        public static string GetBrowserName()
        {
            return HttpContext.Current.Request.Browser.Browser;
        }

        /// <summary>
        /// 获取浏览器版本号
        /// </summary>
        /// <returns></returns>
        public static string GetBrowserVersion()
        {
            return HttpContext.Current.Request.Browser.Version;
        }

        /// <summary>
        /// 获取操作系统名称
        /// </summary>
        /// <returns></returns>
        public static string GetOsName()
        {
            string userAgent = HttpContext.Current.Request.UserAgent;

            string osVersion = string.Empty;

            if (userAgent != null)
                if (userAgent.Contains("NT 10.0"))
                    osVersion = "Windows 10";
                else if (userAgent.Contains("NT 6.3"))
                    osVersion = "Windows 8.1";
                else if (userAgent.Contains("NT 6.2"))
                    osVersion = "Windows 8";
                else if (userAgent.Contains("NT 6.1"))
                    osVersion = "Windows 7";
                else if (userAgent.Contains("NT 6.0"))
                    osVersion = "Windows Vista/Server 2008";
                else if (userAgent.Contains("NT 5.2"))
                    osVersion = userAgent.Contains("64") ? "Windows XP" : "Windows Server 2003";
                else if (userAgent.Contains("NT 5.1"))
                    osVersion = "Windows XP";
                else if (userAgent.Contains("NT 5"))
                    osVersion = "Windows 2000";
                else if (userAgent.Contains("NT 4"))
                    osVersion = "Windows NT4";
                else if (userAgent.Contains("Me"))
                    osVersion = "Windows Me";
                else if (userAgent.Contains("98"))
                    osVersion = "Windows 98";
                else if (userAgent.Contains("95"))
                    osVersion = "Windows 95";
                else if (userAgent.Contains("Mac"))
                    osVersion = "Mac";
                else if (userAgent.Contains("Unix"))
                    osVersion = "UNIX";
                else if (userAgent.Contains("Linux"))
                    osVersion = "Linux";
                else if (userAgent.Contains("SunOS"))
                    osVersion = "SunOS";
                else
                    osVersion = HttpContext.Current.Request.Browser.Platform;

            return osVersion;
        }

        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetClientIp()
        {
            //方式1
            //string strResult = HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null ?
            //    HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] :
            //    HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            //if (strResult.Length == 3)
            //{
            //    System.Net.IPHostEntry ipHost = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName());
            //    System.Net.IPAddress[] addr = ipHost.AddressList;
            //    strResult = addr[0].ToString().Trim();
            //}
            //return strResult;

            //方式2
            var strResult = "";
            try
            {
                strResult = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                //可能有代理 
                if (!string.IsNullOrWhiteSpace(strResult))
                {
                    //没有"." 肯定是非IP格式
                    if (strResult.IndexOf(".", StringComparison.Ordinal) == -1)
                        strResult = "";
                    else
                    {
                        //有","，估计多个代理。取第一个不是内网的IP。
                        if (strResult.IndexOf(",", System.StringComparison.Ordinal) != -1)
                        {
                            strResult = strResult.Replace(" ", string.Empty).Replace("\"", string.Empty);
                            var temparyip = strResult.Split(",;".ToCharArray());
                            if (temparyip.Length > 0)
                            {
                                foreach (var t in temparyip.Where(t => IsIpAddress(t)
                                        && t.Substring(0, 3) != "10."
                                        && t.Substring(0, 7) != "192.168"
                                        && t.Substring(0, 7) != "172.16."))
                                {
                                    return t == "::1" ? "127.0.0.1" : t;
                                }
                            }
                        }
                        //代理即是IP格式
                        else if (IsIpAddress(strResult))
                            return strResult == "::1" ? "127.0.0.1" : strResult;
                        //代理中的内容非IP
                        else
                            strResult = "";
                    }
                }
                if (string.IsNullOrWhiteSpace(strResult))
                    strResult = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                if (string.IsNullOrWhiteSpace(strResult))
                    strResult = HttpContext.Current.Request.UserHostAddress;
                return strResult == "::1" ? "127.0.0.1" : strResult;
            }
            catch (Exception)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(strResult))
                        strResult = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    if (string.IsNullOrWhiteSpace(strResult))
                        strResult = HttpContext.Current.Request.UserHostAddress;
                    return strResult == "::1" ? "127.0.0.1" : strResult;
                }
                catch (Exception ex)
                {
                    //return "获取IP失败:" + ex.Message;
                    return "";
                }
            }
        }
        private static bool IsIpAddress(string str)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(str) || str.Length < 7 || str.Length > 15)
                    return false;
                const string regformat = @"^\d{1,3}[\.]\d{1,3}[\.]\d{1,3}[\.]\d{1,3}{1}";
                var regex = new Regex(regformat, RegexOptions.IgnoreCase);
                return regex.IsMatch(str);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 获取客户端MAC地址
        /// </summary>
        /// <returns></returns>
        public static string GetClientMac()
        {
            string macAddress = string.Empty;
            var mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var moc = mc.GetInstances();
            foreach (var o in moc)
            {
                var mo = (ManagementObject)o;
                if (!(bool)mo["IPEnabled"]) continue;

                macAddress = mo["MacAddress"].ToString();
                break;
            }
            return macAddress;
        }
    }
}
