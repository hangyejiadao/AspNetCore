/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data.System
 * 类名称：SYS_LogInfoData
 * 创建时间：2016-08-30 23:58:52
 * 创建人：QUBER-PC
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System;
using System.Linq;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Data.Base;
using Dos.ORM.IData.System;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.System;

namespace Dos.ORM.Data.System
{
    /// <summary>
    /// 
    /// </summary>
    public class SYS_LogInfoData : DBBase<SYS_LogInfo>, ISYS_LogInfoData
    {
        #region 过滤器ResultLogFilter所需记录的操作日志方法
        /// <summary>
        /// 过滤器ResultLogFilter所需记录的操作日志方法
        /// </summary>
        /// <param name="msSysUserModel">用户相关信息</param>
        /// <param name="logType">日志类型</param>
        /// <param name="optType">操作类型</param>
        /// <param name="requestPath">请求地址（如：/MsSys/Department/SaveData）</param>
        /// <param name="oType">操作类型</param>
        /// <param name="keyId">数据keyId</param>
        /// <param name="resultName">Result返回的类型名称</param>
        /// <param name="optRetType">Result返回的类型，如：((JsonResultOverride)filterContext.Result).Data</param>
        public void CreateResultLogForFilter(MsSysUserModel msSysUserModel, LogType logType, OperateBtn optType, string requestPath, string oType, string keyId, string resultName, object optRetType)
        {
            if (msSysUserModel != null && msSysUserModel.IsEnableLog)
            {
                //日志信息实体
                var logModel = new SYS_LogInfo()
                {
                    LogId = Guid.NewGuid(),
                    LogTypeId = (int)logType,
                    LogTypeName = EnumHelper.GetEnumTitle(logType),
                    CompanyId = msSysUserModel.CompanyId,
                    DataId = keyId,
                    OptUserId = msSysUserModel.Operator.OperatorId,
                    OptUserName = msSysUserModel.Operator.Realname,
                    OptTime = DateTime.Now,
                    OptSystem = ClientHelper.GetOsName(),
                    Browser = ClientHelper.GetBrowserName() + " " + ClientHelper.GetBrowserVersion(),
                    IP = ClientHelper.GetClientIp(),
                    Mac = ClientHelper.GetClientMac(),
                    Status = 1
                };

                string moduleName = string.Empty;
                //请求模块（如：/MsSys/Department）
                string requestModule = requestPath.Substring(0, requestPath.LastIndexOf("/", StringComparison.Ordinal));
                //请求方法名称（如：SaveData）
                string requestName = requestPath.Substring(requestPath.LastIndexOf("/", StringComparison.Ordinal) + 1);

                #region 获取模块名称
                var moduleList = msSysUserModel.ModuleList.Where(m => m.ModulePath != null && m.ModulePath.Contains(requestModule)).OrderBy(m => m.CrtTime).ToList();
                if (moduleList.Count > 0)
                {
                    moduleName = moduleList[0].ModuleName;
                }
                #endregion

                logModel.OptModuleName = moduleName;
                logModel.OptModulePath = requestPath;

                //保存的时候，区分是添加还是修改操作
                if (oType != null && requestName == "SaveData")
                {
                    optType = oType == "add" ? OperateBtn.Add : OperateBtn.Modify;
                }

                logModel.OptTypeId = (int)optType;
                logModel.OptTypeName = EnumHelper.GetEnumTitle(optType);

                if (resultName != null && resultName == "JsonResultOverride")
                {
                    if (optRetType.GetType().Name == "OperateModel")
                    {
                        var optRetInfo = (OperateModel)(optRetType);
                        logModel.OptResultId = (int)optRetInfo.Result;
                        logModel.OptResultName = EnumHelper.GetEnumTitle(optRetInfo.Result);
                        logModel.Desc = optRetInfo.Msg;
                    }
                    else if (optRetType.GetType().Name.Contains("DgListModel"))
                    {
                        logModel.OptResultId = (int)OperateRetType.Success;
                        logModel.OptResultName = EnumHelper.GetEnumTitle(OperateRetType.Success);
                        logModel.Desc = "数据查询成功！";
                    }
                }

                if (logType == LogType.LoginInOut && optType == OperateBtn.LoginIn)
                {
                    logModel.DataId = null;
                    logModel.OptModuleName = "登录系统";
                }
                else if (logType == LogType.LoginInOut && optType == OperateBtn.LoginOut)
                {
                    logModel.OptModuleName = "退出系統";
                    logModel.OptResultId = (int)OperateRetType.LoginOutSuccess;
                    logModel.OptResultName = EnumHelper.GetEnumTitle(OperateRetType.LoginOutSuccess);
                    logModel.Desc = "系统退出成功！";
                }

                var logRet = InsertModel(logModel);

                if (logRet.Result == OperateRetType.Success)
                {
                    string logTxt = EnumHelper.GetEnumTitle(logType) + "\r\n" +
                        "    日志描述：" + logModel.OptUserName + "对【" + logModel.OptModuleName + "】进行“" + logModel.OptTypeName + "”操作\r\n" +
                        (!string.IsNullOrWhiteSpace(logModel.DataId) ? "    数据主键：" + logModel.DataId + "\r\n" : "") +
                        "    操作人员：" + logModel.OptUserName + "[" + logModel.OptUserId + "]\r\n" +
                        "    操作地址：" + logModel.OptModulePath + "\r\n" +
                        "    操作结果：" + logModel.OptResultName + "\r\n" +
                        "    操作描述：" + logModel.Desc + "\r\n" +
                        "    IP地址：" + logModel.IP + "\r\n" +
                        "    浏览器：" + logModel.Browser + "\r\n" +
                        "    操作系统：" + logModel.OptSystem + "\r\n" +
                        "    记录时间：" + logModel.OptTime.ToString("yyyy MM dd HH:mm:ss:ffff") + "\r\n" +
                        "    详细数据：【" + JsonHelper.ObjectToJson(logModel) + "】";

                    //记录操作日志到文本文件
                    LogHelper.LogDefault(logTxt);
                }
            }
        }
        #endregion

        #region 基类控制器MsSysController所需记录的异常日志方法
        /// <summary>
        /// 基类控制器MsSysController所需记录的异常日志方法
        /// </summary>
        /// <param name="msSysUserModel">用户相关信息</param>
        /// <param name="requestPath">请求地址（如：/MsSys/Department/SaveData）</param>
        /// <param name="ex">异常类对象</param>
        public void CreateExceptionLogForMsSysController(MsSysUserModel msSysUserModel, string requestPath, Exception ex)
        {
            if (msSysUserModel != null && msSysUserModel.IsEnableLog)
            {
                string moduleName = string.Empty;
                //请求模块（如：/MsSys/Department）
                string requestModule = requestPath.Substring(0, requestPath.LastIndexOf("/", StringComparison.Ordinal));

                #region 获取模块名称
                var moduleList = msSysUserModel.ModuleList.Where(m => m.ModulePath != null && m.ModulePath.Contains(requestModule)).OrderBy(m => m.CrtTime).ToList();
                if (moduleList.Count > 0)
                {
                    moduleName = moduleList[0].ModuleName;
                }
                #endregion

                var logModel = new SYS_LogInfo()
                {
                    LogId = Guid.NewGuid(),
                    LogTypeId = (int)LogType.ExceptionError,
                    LogTypeName = EnumHelper.GetEnumTitle(LogType.ExceptionError),
                    CompanyId = msSysUserModel.CompanyId,
                    OptUserId = msSysUserModel.Operator.OperatorId,
                    OptUserName = msSysUserModel.Operator.Realname,
                    OptTime = DateTime.Now,
                    OptModuleName = moduleName,
                    OptModulePath = requestPath,
                    //OptTypeId = ,
                    //OptTypeName = ,
                    OptResultId = (int)OperateRetType.Exception,
                    OptResultName = EnumHelper.GetEnumTitle(OperateRetType.Exception),
                    OptSystem = ClientHelper.GetOsName(),
                    Browser = ClientHelper.GetBrowserName() + " " + ClientHelper.GetBrowserVersion(),
                    IP = ClientHelper.GetClientIp(),
                    Mac = ClientHelper.GetClientMac(),
                    Desc = (ex.Message + "<br/>" + ex.StackTrace).Replace("\r\n", "<br/>").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;").Replace(" ", "&nbsp;"),
                    Status = 1
                };

                var logRet = InsertModel(logModel);

                if (logRet.Result == OperateRetType.Success)
                {
                    //记录异常日志到文本文件
                    LogHelper.LogException(EnumHelper.GetEnumTitle(OperateRetType.Exception), ex);
                }
            }
        }
        #endregion
    }
}
