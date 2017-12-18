using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Dos.ORM.Common.Enums;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.Web.App_Api.Base;

namespace Dos.ORM.Web.App_Api.Business
{
    /// <summary>
    /// 试验检测人员API
    /// </summary>
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "tester")]
    public class TesterController : BaseApiController
    {
        [Ninject.Inject]
        private IBUS_TesterData Tester { get; set; }
        [Ninject.Inject]
        private IAPI_SyncLogData LogBll { get; set; }

        /// <summary>
        /// 同步数据获取时间戳和阀值
        /// </summary>
        /// <param name="tbName">更新表名</param>
        /// <returns></returns>
        [GET("get/stamp/{tbName}")]
        public OperateModel GetStampAndSize(string tbName)
        {
            var maxStamp = string.Empty;
            var retList = LogBll.GetModels(m => m.OperateType.Equals(tbName));

            if (retList.Count > 0) maxStamp = retList.Max(m => m.CurrentTimeStamp);

            return new OperateModel
            {
                Result = OperateRetType.Success,
                Msg = "操作成功",
                Data = new { stamp = maxStamp, size = 30 }
            };
        }

        //[GET("get/stamp1")]
        //public string GetStampAndSize1(string tbName)
        //{
        //    OperateModel resultInfo = new OperateModel();
        //    var maxStamp = string.Empty;
        //    var retList = LogBll.GetModels(m => m.OperateType.Equals(tbName));

        //    if (retList.Count > 0) maxStamp = retList.Max(m => m.CurrentTimeStamp);


        //    resultInfo.Result = OperateRetType.Success;
        //    resultInfo.Msg = "操作成功";
        //    resultInfo.Data = "{\"stamp\":" + maxStamp + ",\"size\":" + 30 + "}";

        //    return JsonHelper.ObjectToJson(resultInfo);
        //}

        /// <summary>
        /// 添加试验检测人员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [POST("add")]
        public OperateModel AddModel([FromBody]BUS_Tester model)
        {
            var tester = model;
            tester.ID = Guid.NewGuid();
                                                                                                                                    
            return Tester.InsertModel(tester);
        }
    }
}

