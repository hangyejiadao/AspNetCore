/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2015-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：QUBER.Web.App_Common.Mvc
 * 类名称：JsonResultOverride
 * 创建时间：2015-11-25 15:53:04
 * 创建人：Quber
 * 创建说明：重写MVC的JsonResult
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.IO;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dos.ORM.Web.App_Common.Mvc
{
    /// <summary>
    /// 重写MVC的JsonResult
    /// </summary>
    public class JsonResultOverride : JsonResult
    {
        /// <summary>
        /// 格式化字符串
        /// </summary>
        public string FormateStr { get; set; }

        /// <summary>
        /// Newtonsoft.Json序列化配置
        /// </summary>
        public JsonSerializerSettings Settings { get; private set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        public JsonResultOverride()
        {
            Settings = new JsonSerializerSettings
            {
                //解决.Net MVC EntityFramework Json 序列化循环引用问题
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };
            //添加默认时间转换格式
            //Settings.Converters.Add(new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
        }

        /// <summary>
        /// 重写执行视图
        /// </summary>
        /// <param name="context">上下文</param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null) { throw new ArgumentNullException("context"); }
            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase)) { throw new InvalidOperationException("JSON GET is not allowed"); }
            var response = context.HttpContext.Response;
            response.ContentType = string.IsNullOrEmpty(ContentType) ? "application/json" : ContentType;
            if (ContentEncoding != null) { response.ContentEncoding = ContentEncoding; }
            if (Data == null) { return; }
            var scriptSerializer = JsonSerializer.Create(Settings);
            scriptSerializer.Converters.Add(new IsoDateTimeConverter { DateTimeFormat = FormateStr });
            using (var sw = new StringWriter())
            {
                scriptSerializer.Serialize(sw, Data);
                response.Write(sw.ToString());
            }
        }
    }
}