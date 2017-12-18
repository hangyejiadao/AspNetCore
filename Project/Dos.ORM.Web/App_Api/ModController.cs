using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Dos.ORM.IData.System;
using Dos.ORM.Model.System;

namespace Dos.ORM.Web.App_Api
{
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "mod")]
    public class ModController : ApiController
    {
        [Ninject.Inject]
        private ISYS_ModuleData SysModule { get; set; }

        [GET("get/list")]
        public List<SYS_Module> GetList()
        {
            var retList = SysModule.GetModels();

            return retList;
        }
    }
}
