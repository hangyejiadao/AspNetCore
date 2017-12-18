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

namespace Dos.ORM.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            #region 依赖注入方式（Ninject和Autofac，注意：如果此处没有使用这2种方式，则使用的是IocNinjectWebCommon.cs依赖注入启动类）
            //Ninject依赖注入
            //DependencyResolver.SetResolver(new IocNinjectConfig());

            ////Autofac依赖注入
            //IocAutofacConfig.RegisterDependencies();
            #endregion

            //注册实体映射配置关系
            AutoMapperConfig.InitConfig();

            //启动日志
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(Server.MapPath("/App_Config/plu.log4net.config")));

            //在应用程序启动时运行的代码
            AreaRegistration.RegisterAllAreas();

            //注册WebApi配置
            GlobalConfiguration.Configure(WebApiConfig.Register);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //protected void Application_BeginRequest(Object sender, EventArgs e)
        //{
        //    Response.AddHeader("Access-Control-Allow-Origin", "*");
        //}

    }
}