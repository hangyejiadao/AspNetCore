using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;

namespace Dos.ORM.WebApi.Controllers.Business
{
    /// <summary>
    /// 文件API
    /// </summary>
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "file")]
    public class FileController : ApiController
    {
        [Ninject.Inject]
        private IBUS_FileData FileBll { get; set; }

        /// <summary>
        /// 获取设备列表
        /// </summary>
        /// <returns></returns>
        [GET("get/list")]
        public OperateModel GetList()
        {
            return FileBll.GetList();
        }

        /// <summary>
        /// 根据主键Id(Guid)获取对象
        /// </summary>
        /// <param name="id">主键id(Guid)</param>
        /// <returns></returns>
        [GET("get/one/{id}")]
        public OperateModel GetOne(Guid id)
        {
            return FileBll.GetOne(id);
        }

        /// <summary>
        /// 批量添加文件
        /// </summary>
        /// <param name="modelList">实验室列表</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns></returns>
        [POST("addList/{projectId}/{timeStamp}")]
        public OperateModel AddModelList([FromBody]IList<BUS_File> modelList, Guid projectId, string timeStamp)
        {
            return FileBll.AddModelList(modelList, projectId, timeStamp);
        }

    }
}