/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2015-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：QUBER.Common.Helpers
 * 类名称：LogHelper
 * 创建时间：2015-11-25 14:39:54
 * 创建人：Quber
 * 创建说明：日志帮助类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.IO;
using System.Xml;
using log4net;

namespace Dos.ORM.Common.Helpers
{
    /// <summary>
    /// 日志帮助类
    /// </summary>
    public static class LogHelper
    {
        #region 属性
        private static ILog _DefaultLoger, _ExceptionLoger, _ServerLoger, _DebugLoger;

        private static ILog ServerLoger
        {
            get { return _ServerLoger; }
        }

        private static ILog ExceptionLoger
        {
            get { return _ExceptionLoger; }
        }

        private static ILog DefaultLoger
        {
            get { return _DefaultLoger; }
        }

        private static Boolean _EnableAllLoger = true;
        private static Boolean _EnableDefaultLoger = true;
        private static Boolean _EnableExceptionLoger = true;
        private static Boolean _EnableServerLoger = true;
        private static Boolean _EnableDebugLoger = true;
        #endregion

        #region 构造
        /// <summary>
        /// 构造方法
        /// </summary>
        static LogHelper()
        {
            _DefaultLoger = LogManager.GetLogger("defaultLoger");
            _ExceptionLoger = LogManager.GetLogger("exceptionLoger");
            _ServerLoger = LogManager.GetLogger("serverLoger");
            _DebugLoger = LogManager.GetLogger("DebugLoger");
            SetlogEnable();
        }
        #endregion

        #region 方法
        private static void SetlogEnable()
        {
            try
            {
                var xmldoc = new XmlDocument();
                try
                {
                    xmldoc.Load(Directory.GetCurrentDirectory() + @"\App_Config\log4net.config");
                }
                catch
                {
                    xmldoc.Load(Directory.GetCurrentDirectory() + @"\log4net.config");
                }
                XmlNodeList xmlNdLst = xmldoc.SelectNodes("appSettings/add");
                for (int i = 0; i < xmlNdLst.Count; i++)
                {
                    XmlNode xmNd = xmlNdLst[i];
                    if (xmNd.Attributes["key"].Value == "EnableAllLoger")
                        _EnableAllLoger = Boolean.Parse(xmNd.Attributes["value"].Value);
                    if (xmNd.Attributes["key"].Value == "EnableDefaultLoger")
                        _EnableAllLoger = Boolean.Parse(xmNd.Attributes["value"].Value);
                    if (xmNd.Attributes["key"].Value == "EnableExceptionLoger")
                        _EnableAllLoger = Boolean.Parse(xmNd.Attributes["value"].Value);
                    if (xmNd.Attributes["key"].Value == "EnableServerLoger")
                        _EnableAllLoger = Boolean.Parse(xmNd.Attributes["value"].Value);
                    if (xmNd.Attributes["key"].Value == "EnableDebugLoger")
                        _EnableAllLoger = Boolean.Parse(xmNd.Attributes["value"].Value);
                }
            }
            catch (Exception e)
            {
                _ExceptionLoger.Error("是否开启日志文件的配置错误", e);
            }
        }

        /// <summary>
        /// 异常日志
        /// </summary>
        /// <param name="msg">异常信息说明</param>
        /// <param name="ex">异常对象</param>
        public static void LogException(string msg, Exception ex)
        {
            if (_EnableAllLoger && _EnableExceptionLoger)
                _ExceptionLoger.Error(msg, ex);
        }

        /// <summary>
        /// 普通日志
        /// </summary>
        /// <param name="msg">异常信息说明</param>
        public static void LogDefault(string msg)
        {
            if (_EnableAllLoger && _EnableDefaultLoger)
                _DefaultLoger.Info(msg);
        }

        /// <summary>
        /// 服务器日志
        /// </summary>
        /// <param name="msg">异常信息说明</param>
        public static void LogServer(string msg)
        {
            if (_EnableAllLoger && _EnableServerLoger)
                _ServerLoger.Info(msg);
        }

        /// <summary>
        /// 调试日志
        /// </summary>
        /// <param name="msg">异常信息说明</param>
        public static void LogDebug(string msg)
        {
            if (_EnableAllLoger && _EnableDebugLoger)
                _DebugLoger.Debug(msg);
        }
        #endregion
    }
}
