using System;
using System.Collections.Generic;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.WebApi.Controllers.Base;

namespace Dos.ORM.WebApi.Controllers.Business
{
    /// <summary>
    /// 项目实验室关联API
    /// </summary>
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "prolab")]
    public class ProLabController : BaseApiController
    {
        [Ninject.Inject]
        private IBUS_ProjectLaboratoryData ProLabBll { get; set; }

        /// <summary>
        /// 批量添加关联信息
        /// </summary>
        /// <param name="modelList">关联信息列表</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns></returns>
        [POST("addList/{projectId}/{timeStamp}")]
        public OperateModel AddModelList([FromBody]IList<BUS_ProjectLaboratory> modelList, Guid projectId, string timeStamp)
        {
            return ProLabBll.AddModelList(modelList, projectId, timeStamp);
        }
    }
}