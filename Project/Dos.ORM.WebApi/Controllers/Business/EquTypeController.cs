using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData.Query;
using AttributeRouting.Web.Http;
using Dos.ORM.IData;
using Dos.ORM.IData.Business;
using Dos.ORM.Model;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.WebApi.Controllers.Base;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;

namespace Dos.ORM.WebApi.Controllers.Business
{
    /// <summary>
    /// 环境设施API
    /// </summary>
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "equtype")]
    public class EquTypeController : BaseApiController
    {
        [Ninject.Inject]
        private IBUS_EquipmentTypeData EquTypeBll { get; set; }

        #region 获取设备列表
        /// <summary>
        /// 分页获取环境设施列表
        /// </summary>
        /// <param name="organId">机构Id</param>
        /// <param name="options">Odata参数</param>
        /// <returns></returns>
        [GET("get/plist/{organId}")]
        public OperateModel GetPList(Guid organId, ODataQueryOptions<BUS_EquipmentType> options)
        {
            return GetPagerList(EquTypeBll.GetList(organId), options);
        }

        /// <summary>
        /// 分页获取环境设施列表,并自定义页大小
        /// </summary>
        /// <param name="pageSize">页大小</param>
        /// <param name="organId">机构Id</param>
        /// <param name="options">Odata参数</param>
        /// <returns></returns>
        [GET("get/pslist/{organId}/{pageSize}")]
        public OperateModel GetPgList(Guid organId, int pageSize, ODataQueryOptions<BUS_EquipmentType> options)
        {
            return GetPagerList(EquTypeBll.GetList(organId), options, pageSize);
        }
        #endregion

        /// <summary>
        /// 添加设备
        /// 根据主键Id(Guid)获取对象
        /// </summary>
        /// <param name="id">主键id(Guid)</param>
        /// <returns></returns>
        [GET("get/one/{id}")]
        public OperateModel GetOne(Guid id)
        {
            return EquTypeBll.GetOne(id);
        }

        /// <summary>
        /// 批量添加设备
        /// </summary>
        /// <param name="modelList">设备列表</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns></returns>
        [POST("addList/{projectId}/{timeStamp}")]
        public OperateModel AddModelList([FromBody]IList<BUS_EquipmentType> modelList, Guid projectId, string timeStamp)
        {
            return EquTypeBll.AddModelList(modelList,projectId, timeStamp);
        }

        /// <summary>
        /// 分页环境设施列表
        /// </summary>
        /// <returns></returns>
        [POST("get/list1")]
        public OperateModel<BUS_EquipmentType> EquTypeList([FromBody]ModelPageConModel pageCon)
        {
            OperateModel<BUS_EquipmentType> OperModel = null;
            if (string.IsNullOrWhiteSpace(pageCon.TargetId))
            {
                OperModel = new OperateModel<BUS_EquipmentType>
                {
                    Result = OperateRetType.Fail,
                    Msg = "targetId不能为空，获取失败！"
                };
            }
            else
            {
                var exp = ExpHelper.Create<BUS_EquipmentType>(s => s.OrganID == Guid.Parse(pageCon.TargetId));             

                if (!string.IsNullOrWhiteSpace(pageCon.FilterText))
                    exp = exp.And(s => s.EquipmentTypeName.Contains(pageCon.FilterText));

                DgConModel dgCon = new DgConModel() { page = pageCon.PageIndex, rows = pageCon.PageSize, sort = "EquipmentTypeSort", order = "asc" };

                var retList = EquTypeBll.GetList(dgCon, exp);                
                
                //var retList = EquTypeBll.GetPagesForDg(new DgConModel() { page = pageCon.PageIndex, rows = pageCon.PageSize }, "OrganID", exp);

                OperModel = new OperateModel<BUS_EquipmentType>
                {
                    Result = retList != null ? OperateRetType.Success : OperateRetType.Fail,
                    Msg = retList != null ? "获取成功！" : "获取失败！",
                    Data = retList
                };
            }
            return OperModel;
        }

        /// <summary>
        /// 获取环境设施列表
        /// </summary>
        /// <returns></returns>
        [GET("get/list/{targetId}")]
        public OperateList<BUS_EquipmentType> GetList(string TargetId)
        {

            var exp = ExpHelper.Create<BUS_EquipmentType>(s => s.OrganID == Guid.Parse(TargetId) && s.IsEnable==true);

            var list = EquTypeBll.GetModels(exp);

            var OperModel = new OperateList<BUS_EquipmentType>
            {
                Result = list != null ? OperateRetType.Success : OperateRetType.Fail,
                Msg = list != null ? "获取成功！" : "获取失败！",
                Data = list
            };

            return OperModel;

        }
    }
}