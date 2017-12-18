using System.Collections.Generic;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.Web.App_Api.Base;

namespace Dos.ORM.Web.App_Api.Business
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

    }
}