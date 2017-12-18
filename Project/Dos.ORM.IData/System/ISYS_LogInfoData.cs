/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.IData.System
 * 类名称：ISYS_LogInfoData
 * 创建时间：2016-09-21 16:28:06
 * 创建人：Quber
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System;
using Dos.ORM.Common.Enums;
using Dos.ORM.IData.Base;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.System;

namespace Dos.ORM.IData.System
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISYS_LogInfoData : IDBBase<SYS_LogInfo>
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
        void CreateResultLogForFilter(MsSysUserModel msSysUserModel, LogType logType, OperateBtn optType, string requestPath, string oType, string keyId, string resultName, object optRetType);
        #endregion

        #region 基类控制器MsSysController所需记录的异常日志方法
        /// <summary>
        /// 基类控制器MsSysController所需记录的异常日志方法
        /// </summary>
        /// <param name="msSysUserModel">用户相关信息</param>
        /// <param name="requestPath">请求地址（如：/MsSys/Department/SaveData）</param>
        /// <param name="ex">异常类对象</param>
        void CreateExceptionLogForMsSysController(MsSysUserModel msSysUserModel, string requestPath, Exception ex);
        #endregion
    }
}
