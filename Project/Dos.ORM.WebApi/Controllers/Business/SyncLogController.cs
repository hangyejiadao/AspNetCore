using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;

namespace Dos.ORM.WebApi.Controllers.Business
{
    /// <summary>
    /// 同步日志API
    /// </summary>
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "syncLog")]
    public class SyncLogController : ApiController
    {
        [Ninject.Inject]
        private IAPI_SyncLogData LogBll { get; set; }

        /// <summary>
        /// 同步数据获取时间戳和阀值
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="tbName">更新表名</param>
        /// <returns></returns>
        [GET("get/stamp/{projectId}/{tbName}")]
        public OperateModel GetStampAndSize(Guid projectId, string tbName)
        {
            var maxStamp = string.Empty;
            var retList = LogBll.GetModels(m => m.OperateType.Equals(tbName) && m.ProjectID == projectId);

            if (retList.Count > 0) maxStamp = retList.Max(m => m.CurrentTimeStamp);

            return new OperateModel
            {
                Result = OperateRetType.Success,
                Msg = "操作成功",
                Data = new { stamp = maxStamp, size = 30 }
            };
        }

        /// <summary>
        /// 保留学习
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        [NonAction]
        public string GetStampAndSize1(string tbName)
        {
            OperateModel resultInfo = new OperateModel();
            var maxStamp = string.Empty;
            var retList = LogBll.GetModels(m => m.OperateType.Equals(tbName));

            if (retList.Count > 0) maxStamp = retList.Max(m => m.CurrentTimeStamp);

            resultInfo.Result = OperateRetType.Success;
            resultInfo.Msg = "操作成功";
            resultInfo.Data = "{\"stamp\":" + maxStamp + ",\"size\":" + 30 + "}";

            return JsonHelper.ObjectToJson(resultInfo);
        }
    }
}