using System.Web.Mvc;
using System.Web.Routing;

namespace Dos.ORM.WebPC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Dos.ORM.WebPC.Controllers" }//设置主路由的命名空间，防止与区域Area中控制器名称发生冲突
            );
        }
    }
}
