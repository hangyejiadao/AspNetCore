using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Data.System;
using Dos.ORM.IData.System;
using Dos.ORM.Model.System;
using Dos.ORM.Web.App_Api.Base;
using HtmlAgilityPack;

namespace Dos.ORM.Web.App_Api
{
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "dep")]
    public class DepController : BaseApiController
    {
        [Ninject.Inject]
        private ISYS_DepartmentData SysDepartment { get; set; }

        //[GET("get/name")]
        //public string GetName()
        //{
        //    return "quber";
        //}

        [GET("get/name")]
        public HttpResponseMessage GetName()
        {
            var model = SysDepartment.GetModel(m => m.DepartmentName == "部门1");
            var modelStr = JsonHelper.ObjectToJson(model);

            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(modelStr, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }

        /// <summary>
        ///  获取列表
        /// </summary>
        /// <returns></returns>
        [GET("get/list")]
        public List<SYS_Department> GetList()
        {
            var retList = SysDepartment.GetModels();

            return retList;
        }

        //[GET("get/list/{depName}")]
        //public List<SYS_Department> GetList(string depName)
        //{
        //    var retList = SysDepartment.GetModels(m => m.DepartmentName.Like(depName));

        //    return retList;
        //}

        [GET("get/model/{depId}")]
        public SYS_Department GetModel(Guid depId)
        {
            var retModel = SysDepartment.GetModel(m => m.DepartmentId == depId);

            return retModel;
        }

        [POST("add")]
        public SYS_Department AddModel([FromBody]SYS_Department model)
        {
            model.DepartmentId = Guid.NewGuid();
            model.CompanyId = Guid.NewGuid();
            model.CrtOptId = Guid.NewGuid();
            model.CrtTime = DateTime.Now;
            model.ModTime = DateTime.Now;

            return model;
        }

        //TODO...此处PUT方式报 请求的资源不支持 http 方法“PUT” 错误
        [PUT("mod")]
        public SYS_Department ModifyModel([FromBody]SYS_Department model)
        {
            model.DepartmentName = model.DepartmentName + " - Modify";

            return model;
        }

        [DELETE("del/{depId}")]
        public SYS_Department DeleteModel(Guid depId)
        {
            var retModel = SysDepartment.GetModel(m => m.DepartmentId == depId);

            return retModel;
        }
    }
}
