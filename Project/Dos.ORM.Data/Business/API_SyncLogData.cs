/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data.Business
 * 类名称：API_SyncLogData
 * 创建时间：2017-02-10 13:12:57
 * 创建人：CDKX-ZC-2015051
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System;
using Dos.ORM.Data.Base;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Business;

namespace Dos.ORM.Data.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class API_SyncLogData : DBBase<API_SyncLog>, IAPI_SyncLogData
    {
        /// <summary>
        /// 增加更新同步日志
        /// </summary>
        /// <param name="timeStamp">最大时间戳</param>
        /// <param name="tbName">操作表名</param>
        /// <param name="isSuccess">操作结果</param>
        /// <returns></returns>
        public static bool AddApiLog(string timeStamp,string tbName,bool isSuccess = true)
        {
            API_SyncLog log = new API_SyncLog();

            log.ID = Guid.NewGuid();
            log.CurrentTimeStamp = timeStamp;
            log.OperateType = tbName;
            log.IsSuccess = isSuccess;
            log.CreateTime = DateTime.Now;

            if (DB.DbCont.Insert<API_SyncLog>(log) > 0) return true;
            else return false;

        }

        /// <summary>
        /// 增加更新同步日志
        /// </summary>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <param name="tbName">操作表名</param>
        /// <param name="isSuccess">操作结果</param>
        /// <returns></returns>
        public static bool AddApiLog(Guid projectId, string timeStamp, string tbName, bool isSuccess = true)
        {
            API_SyncLog log = new API_SyncLog();

            log.ID = Guid.NewGuid();
            log.ProjectID = projectId;
            log.CurrentTimeStamp = timeStamp;
            log.OperateType = tbName;
            log.IsSuccess = isSuccess;
            log.CreateTime = DateTime.Now;

            if (DB.DbCont.Insert<API_SyncLog>(log) > 0) return true;
            else return false;

        }
    }
}
