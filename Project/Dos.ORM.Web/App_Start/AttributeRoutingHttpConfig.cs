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
             * �˴�����Ҫ����������ô����ã��򱨴�
             * �������취�ɲο��������£�
             * http://stackoverflow.com/questions/18446316/attributerouting-webapi-now-producing-errors
             * 
             */
            routes.MapHttpAttributeRoutes(cfg =>
            {
                cfg.InMemory = true;
                cfg.AutoGenerateRouteNames = true;

                //�����κ�һ��WebApi�����������Ƽ���
                cfg.AddRoutesFromAssemblyOf<TesterController>();
            });
        }
    }
}
