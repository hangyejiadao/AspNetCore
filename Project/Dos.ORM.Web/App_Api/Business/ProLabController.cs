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
    /// 项目实验室关联API
    /// </summary>
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "prolab")]
    public class ProLabController : BaseApiController
    {
        [Ninject.Inject]
        private IBUS_ProjectLaboratoryData ProLabBll { get; set; }

    }
}