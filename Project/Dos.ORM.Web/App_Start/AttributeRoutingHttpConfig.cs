using System.Web.Http;
using AttributeRouting.Web.Http.WebHost;
using Dos.ORM.Web.App_Api;
using Dos.ORM.Web.App_Api.Business;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Dos.ORM.Web.AttributeRoutingHttpConfig), "Start")]

namespace Dos.ORM.Web
{
    public static class AttributeRoutingHttpConfig
    {
        public static void Start()
        {
            RegisterRoutes(GlobalConfiguration.Configuration.Routes);
        }

        private static void RegisterRoutes(HttpRouteCollection routes)
        {
            // See http://github.com/mccalltd/AttributeRouting/wiki for more options.
            // To debug routes locally using the built in ASP.NET development server, go to /routes.axd

            //routes.MapHttpAttributeRoutes();

            /*
             * 
             * 此处很重要，如果不配置此设置，则报错。
             * 具体解决办法可参考以下文章：
             * http://stackoverflow.com/questions/18446316/attributerouting-webapi-now-producing-errors
             * 
             */
            routes.MapHttpAttributeRoutes(cfg =>
            {
                cfg.InMemory = true;
                cfg.AutoGenerateRouteNames = true;

                //配置任何一个WebApi控制器的名称即可
                cfg.AddRoutesFromAssemblyOf<TesterController>();
            });
        }
    }
}
