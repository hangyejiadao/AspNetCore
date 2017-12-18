using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Dos.ORM.Web.App_Common.Mvc;

namespace Dos.ORM.Web
{
    public class RouteConfig
    {
        /// <summary>
        /// 使用AttributeRouting重写路由地址
        /// </summary>
        public const string BaseApi = "cdkx/api/";

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Dos.ORM.Web.Controllers" }//设置主路由的命名空间，防止与区域Area中控制器名称发生冲突
            );
        }
    }
}
