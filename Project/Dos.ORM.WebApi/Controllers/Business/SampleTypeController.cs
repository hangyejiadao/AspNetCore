using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Dos.ORM.IData;
using Dos.ORM.IData.Business;
using Dos.ORM.Model;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.Common.Enums;
using Dos.ORM.WebApi.Controllers.Base;
using Dos.ORM.Common.Helpers;


namespace Dos.ORM.WebApi.Controllers.Business
{
    /// <summary>
    /// 样品类型API
    /// </summary>
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "sampletype")]
    public class SampleTypeController : BaseApiController
    {
        [Ninject.Inject]
        private IBUS_SampleTypeData BUS_SampleType { get; set; }

         [Ninject.Inject]
        private IBUS_StatisticsTypeData BUS_StatisticsType { get; set; }

        /// <summary>
        /// 获取样品列表
        /// </summary>
        /// <returns></returns>
        [GET("get/list")]
        public OperateModel GetList()
        {
            return BUS_SampleType.GetList();
        }

        /// <summary>
        /// 添加样品
        /// 根据主键Id(Guid)获取对象
        /// </summary>
        /// <param name="id">主键id(Guid)</param>
        /// <returns></returns>
        [GET("get/one/{id}")]
        public OperateModel GetOne(Guid id)
        {
            return BUS_SampleType.GetOne(id);
        }

        /// <summary>
        /// 批量添加样品
        /// </summary>
        /// <param name="modelList">样品列表</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns></returns>
        [POST("addList/{projectId}/{timeStamp}")]
        public OperateModel AddModelList([FromBody]IList<BUS_SampleType> modelList, Guid projectId, string timeStamp)
        {
            return BUS_SampleType.AddModelList(modelList, projectId, timeStamp);
        }

        /// <summary>
        /// 获取试验类型下拉选择
        /// </summary>
        /// <returns></returns>
        [GET("get/list2")]
        public OperateModel GetList2()
        {

            var list = BUS_SampleType.GetModels();

            var Model = (from r in list
                         where r.ParentID != null
                         orderby r.Order
                         select new
                         {
                             _parentId = r.ParentID,
                             id = r.ID,
                             value = r.ID,
                             text = r.TypeName,
                             type = (list.Single(s => s.ParentID == null && s.ID == r.ParentID).TypeName)
                         });

            var OperModel = new OperateModel()
            {
                Result = Model != null ? OperateRetType.Success : OperateRetType.Fail,
                Msg = Model != null ? "获取成功！" : "获取失败！",
                Data = Model
            };

            return OperModel;

        }

        /// <summary>
        /// 获取试验类型下拉选择
        /// </summary>
        /// <returns></returns>
        [GET("get/list1")]
        public OperateList<BUS_SampleType> GetList1()
        {
         
            var list = BUS_SampleType.GetModels();

            var OperModel = new OperateList<BUS_SampleType>
            {
                Result = list != null ? OperateRetType.Success : OperateRetType.Fail,
                Msg = list != null ? "获取成功！" : "获取失败！",
                Data = list
            };

            return OperModel;

        }

        
        /// <summary>
        /// 获取统计类型列表
        /// </summary>
        /// <returns></returns>
        [GET("get/typelist")]
        public OperateList<BUS_StatisticsType> GetTypeList()
        {
            
            var list = BUS_StatisticsType.GetModels().OrderBy(o=>o.Order).ToList();

            var OperModel = new OperateList<BUS_StatisticsType>
            {
                Result = list != null ? OperateRetType.Success : OperateRetType.Fail,
                Msg = list != null ? "获取成功！" : "获取失败！",
                Data = list
            };

            return OperModel;

        }
    }
    
}