using System.Collections.Generic;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.Web;
using Dos.ORM.Web.App_Api.Base;

namespace Dos.ORM.Web.App_Api.Business
{
    /// <summary>
    /// 实验室API
    /// </summary>
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "lab")]
    public class LabController : BaseApiController
    {
        [Ninject.Inject]
        private IBUS_LaboratoryData LabBll { get; set; }

        /// <summary>
        /// 获取试验室列表
        /// </summary>
        /// <returns></returns>
        [GET("get/list")]
        public OperateModel GetList()
        {
            return LabBll.GetList();
        }


    }
}