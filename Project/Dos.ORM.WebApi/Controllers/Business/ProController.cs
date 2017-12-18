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
    /// 项目API
    /// </summary>
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "pro")]
    public class ProController : BaseApiController
    {
        [Ninject.Inject]
        private IBUS_ProjectData ProBll { get; set; }

        /// <summary>
        /// 项目列表
        /// </summary>
        /// <returns></returns>
        [GET("get/list")]
        public OperateModel GetList()
        {
            return ProBll.GetList();
        }

        /// <summary>
        /// 根据主键Id(Guid)获取对象
        /// </summary>
        /// <param name="id">主键id(Guid)</param>
        /// <returns></returns>
        [GET("get/one/{id}")]
        public OperateModel GetOne(Guid id)
        {
            return ProBll.GetOne(id);
        }

        /// <summary>
        /// 批量添加项目
        /// </summary>
        /// <param name="modelList">项目列表</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns></returns>
        [POST("addList/{projectId}/{timeStamp}")]
        public OperateModel AddModelList(Guid projectId, string timeStamp, string modeljson = "")
        {
            var modellist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BUS_Project>>(modeljson);
            return ProBll.AddModelList(modellist, projectId, timeStamp);
        }
    }
}