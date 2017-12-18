using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.WebApi.Controllers.Base;

namespace Dos.ORM.WebApi.Controllers.Business
{
    /// <summary>
    /// 记录API
    /// </summary>
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "record")]
    public class RecordController : BaseApiController
    {
        [Ninject.Inject]
        private IBUS_RecordData ReCordBll { get; set; }

        /// <summary>
        /// 获取报告列表
        /// </summary>
        /// <returns></returns>
        [GET("get/list")]
        public OperateModel GetList()
        {
            return ReCordBll.GetList();
        }

        /// <summary>
        /// 根据主键Id(Guid)获取对象
        /// </summary>
        /// <param name="id">主键id(Guid)</param>
        /// <returns></returns>
        [GET("get/one/{id}")]
        public OperateModel GetOne(Guid id)
        {
            return ReCordBll.GetOne(id);
        }

        /// <summary>
        /// 批量添加报告
        /// </summary>
        /// <param name="modelList">报告列表</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns></returns>
        [POST("addList/{projectId}/{timeStamp}")]
        public OperateModel AddModelList([FromBody]IList<BUS_Record> modelList, Guid projectId, string timeStamp)
        {
            if (modelList == null)
                return new OperateModel(Common.Enums.OperateRetType.Fail, "modelList不能为空");
            return ReCordBll.AddModelList(modelList, projectId, timeStamp);
        }
    }
}