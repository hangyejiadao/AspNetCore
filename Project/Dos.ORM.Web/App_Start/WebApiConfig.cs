using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Converters;

namespace Dos.ORM.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //重写返回的数据
            //config.MessageHandlers.Add(new WebApiAuthHandler());

            //定义将数据序列化为JSON格式
            var jsonFormatter = new JsonMediaTypeFormatter();
            //optional: set serializer settings here

            //jsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("json", "true", "text/json"));
            config.Services.Replace(typeof(IContentNegotiator), new WebApiJsonContentNegotiator(jsonFormatter));

            //设置返回时间格式
            var settings = jsonFormatter.SerializerSettings;
            IsoDateTimeConverter timeConverter = new IsoDateTimeConverter
            {
                DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss"
            };
            settings.Converters.Add(timeConverter);
            //配置返回的字段首字母小写
            //settings.ContractResolver = new CamelCasePropertyNamesContractResolver();


        }
    }
}
