using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Results;

namespace Dos.ORM.Web.App_Api.Base
{
    public class BaseApiController : ApiController
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
        }

        protected override ResponseMessageResult ResponseMessage(HttpResponseMessage response)
        {
            return base.ResponseMessage(response);
        }

        protected override OkResult Ok()
        {
            return base.Ok();
        }
    }
}
