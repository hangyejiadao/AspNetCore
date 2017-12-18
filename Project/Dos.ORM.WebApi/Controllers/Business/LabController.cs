using System.Collections.Generic;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.WebApi.Controllers.Base;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using System;

namespace Dos.ORM.WebApi.Controllers.Business
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

        /// <summary>
        /// 根据主键Id(Guid)获取对象
        /// </summary>
        /// <param name="id">主键id(Guid)</param>
        /// <returns></returns>
        [GET("get/one/{id}")]
        public OperateModel GetOne(Guid id)
        {
            return LabBll.GetOne(id);
        }

        /// <summary>
        /// 批量添加实验室
        /// </summary>
        /// <param name="modelList">实验室列表</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns></returns>
        [POST("addList/{projectId}/{timeStamp}")]
        public OperateModel AddModelList([FromBody]IList<BUS_Laboratory> modelList,Guid projectId, string timeStamp)
        {
            #region 验证
            if (modelList == null || modelList.Count <= 0)
                return new OperateModel(OperateRetType.Fail, "modelList不能为空");
            #endregion
            return LabBll.AddModelList(modelList, projectId, timeStamp);
        }

        /// <summary>
        /// 获取实验室根据id
        /// </summary>
        /// <returns></returns>
        [GET("get/lab/{targetId}")]
        public OperateModel GetLab(string targetId)
        {
            OperateModel OperModel = null;
            if (string.IsNullOrWhiteSpace(targetId))
            {
                OperModel = new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "targetId不能为空，获取失败！"
                };
            }
            else
            {
                var exp = ExpHelper.Create<BUS_Laboratory>(s => s.OrganID == Guid.Parse(targetId));
                var model = LabBll.GetModel(exp);
                OperModel = new OperateModel
                {
                    Result = model != null ? OperateRetType.Success : OperateRetType.Fail,
                    Msg = model != null ? "获取成功！" : "获取失败！",
                    Data = model
                };

            }
            return OperModel;
        }
    }
}