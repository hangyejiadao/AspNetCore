using System.Collections.Generic;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.Web;
using Dos.ORM.Web.App_Api.Base;

namespace Dos.ORM.Web.App_Api.Business
{
    /// <summary>
    /// 设备API
    /// </summary>
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "equ")]
    public class EqumentController : BaseApiController
    {
        [Ninject.Inject]
        private IBUS_EqumentData EquBll { get; set; }

    }
}