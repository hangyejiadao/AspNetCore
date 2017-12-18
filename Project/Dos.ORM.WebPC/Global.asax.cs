using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Web.Optimization;

namespace Dos.ORM.WebPC
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
           
            //注册实体映射配置关系
            //AutoMapperConfig.InitConfig();

            //启动日志
            //log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(Server.MapPath("/App_Config/plu.log4net.config")));

            //在应用程序启动时运行的代码
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}