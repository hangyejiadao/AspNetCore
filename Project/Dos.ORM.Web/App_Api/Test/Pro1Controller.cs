using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Dos.ORM.Common.Helpers;
using Dos.ORM.IData.Test;
using Dos.ORM.Model.Test;
using Dos.ORM.Web.App_Api.Base;
using HtmlAgilityPack;

namespace Dos.ORM.Web.App_Api.Test
{
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "pro1")]
    public class Pro1Controller : BaseApiController
    {
        [Ninject.Inject]
        private IPRO_InfoData SysDepartment { get; set; }

        [GET("get/name")]
        public HttpResponseMessage GetName()
        {
            var model = SysDepartment.GetModel(m => m.ProName == "华为");
            var modelStr = JsonHelper.ObjectToJson(model);

            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(modelStr, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }

        [GET("get/list")]
        public List<PRO_Info> GetList()
        {
            var retList = SysDepartment.GetModels();

            return retList;
        }

        [GET("get/list/{proName}")]
        public List<PRO_Info> GetList(string proName)
        {
            var retList = SysDepartment.GetModels(m => m.ProName.Like(proName));

            return retList;
        }

        [GET("get/model/{proId}")]
        public PRO_Info GetModel(int proId)
        {
            var retModel = SysDepartment.GetModel(m => m.ProId == proId);

            return retModel;
        }

        [POST("add")]
        public PRO_Info AddModel([FromBody]PRO_Info model)
        {
            model.ProName = model.ProName + " - add";
            model.CrtTime = DateTime.Now;

            return model;
        }

        //TODO...此处PUT方式报 请求的资源不支持 http 方法“PUT” 错误
        [PUT("mod")]
        public PRO_Info ModifyModel([FromBody]PRO_Info model)
        {
            model.ProName = model.ProName + " - Modify";

            return model;
        }

        [DELETE("del/{proId}")]
        public PRO_Info DeleteModel(int proId)
        {
            var retModel = SysDepartment.GetModel(m => m.ProId == proId);

            return retModel;
        }
    }
}
