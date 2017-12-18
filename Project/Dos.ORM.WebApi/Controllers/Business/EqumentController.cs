using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using AttributeRouting.Web.Http;
using Dos.ORM.Common.Enums;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.WebApi.Controllers.Base;
using Dos.ORM.Common.Helpers;
using System;
using Dos.ORM.Model.BusView;

namespace Dos.ORM.WebApi.Controllers.Business
{
    /// <summary>
    /// 设备API
    /// </summary>
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "equ")]
    public class EqumentController : BaseApiController
    {
        [Ninject.Inject]
        private IBUS_EqumentData EquBll { get; set; }


        #region 获取设备列表
        /// <summary>
        /// 分页获取设备列表
        /// </summary>
        /// <param name="organId">机构Id</param>
        /// <param name="options">Odata参数</param>
        /// <returns></returns>
        [GET("get/plist/{organId}")]                                                
        public OperateModel GetPList(Guid organId, ODataQueryOptions<BUS_Equment> options)
        {
            return GetPagerList(EquBll.GetList(organId), options);
        }

        /// <summary>
        /// 分页获取设备列表,并自定义页大小
        /// </summary>
        /// <param name="pageSize">页大小</param>
        /// <param name="organId">机构Id</param>
        /// <param name="options">Odata参数</param>
        /// <returns></returns>
        [GET("get/pslist/{organId}/{pageSize}")]
        public OperateModel GetPgList(Guid organId, int pageSize, ODataQueryOptions<BUS_Equment> options)
        {
            return GetPagerList(EquBll.GetList(organId), options, pageSize);
        }
        #endregion

        #region 获取设备及对应照片列表
        /// <summary>
        /// 分页获取设备以及对应照片列表
        /// </summary>
        /// <param name="organId">结构Id</param>
        /// <param name="options">Odata参数</param>
        /// <returns></returns>
        [GET("get/plistWPic/{organId}")]
        public OperateModel GetPListWPic(Guid organId, ODataQueryOptions<EquView> options)
        {
            return GetPagerList(EquBll.GetListWPic(organId), options);
        }

        /// <summary>
        /// 分页获取设备及照片列表,并自定义页大小
        /// </summary>
        /// <param name="organId">结构Id</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="options">Odata参数</param>
        /// <returns></returns>
        [GET("get/pslistWPic/{organId}/{pageSize}")]
        public OperateModel GetPsListWPic(Guid organId, int pageSize, ODataQueryOptions<EquView> options)
        {
            return GetPagerList(EquBll.GetListWPic(organId), options, pageSize);
        }
        #endregion

        #region 根据主键获取设备
        /// <summary>
        /// 根据主键Id(Guid)获取对象
        /// </summary>
        /// <param name="id">主键id(Guid)</param>
        /// <returns></returns>
        [GET("get/one/{id}")]
        public OperateModel GetOne(Guid id)
        {
            return EquBll.GetOne(id);
        }

        /// <summary>
        /// 根据主键Id(Guid)获取对象及对应照片信息
        /// </summary>
        /// <param name="id">主键id(Guid)</param>
        /// <returns></returns>
        [GET("get/oneWPic/{id}")]
        public OperateModel GetOneWPic(Guid id)
        {
            return EquBll.GetOneWPic(id);
        }
        #endregion

        #region 设备同步

        /// <summary>
        /// 批量添加设备
        /// </summary>
        /// <param name="modelList">设备列表</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns></returns>
        [POST("addList/{projectId}/{timeStamp}")]
        public OperateModel AddModelList([FromBody]IList<BUS_Equment> modelList, Guid projectId, string timeStamp)
        {
            return EquBll.AddModelList(modelList, projectId, timeStamp);
        }
        #endregion


        /// <summary>
        /// 分页获取设备列表
        /// </summary>
        /// <returns></returns>
        [POST("get/list1")]
        public OperateModel<BUS_Equment> EqumentList([FromBody]ModelPageConModel pageCon)
        {
            OperateModel<BUS_Equment> OperModel = null;
            if (string.IsNullOrWhiteSpace(pageCon.TargetId))
            {
                OperModel = new OperateModel<BUS_Equment>
                {
                    Result = OperateRetType.Fail,
                    Msg = "targetId不能为空，获取失败！"
                };
            }
            else
            {
                var exp = ExpHelper.Create<BUS_Equment>(s => s.OrganID == Guid.Parse(pageCon.TargetId));

                if (!string.IsNullOrWhiteSpace(pageCon.EquType))
                    exp = exp.And(s => s.Type==pageCon.EquType);

                if (!string.IsNullOrWhiteSpace(pageCon.FilterText))
                    exp = exp.And(s => s.EquipmentNO.Contains(pageCon.FilterText) || s.EquipmentName.Contains(pageCon.FilterText));

                DgConModel dgCon = new DgConModel() { page = pageCon.PageIndex, rows = pageCon.PageSize, sort = "EquipmentName", order = "asc" };

                var retList = EquBll.GetList(dgCon, exp);                
                
                //var retList = EquBll.GetPagesForDg(new DgConModel() { page = pageCon.PageIndex, rows = pageCon.PageSize }, "BuyDate", exp);

                OperModel = new OperateModel<BUS_Equment>
                {
                    Result = retList != null ? OperateRetType.Success : OperateRetType.Fail,
                    Msg = retList != null ? "获取成功！" : "获取失败！",
                    Data = retList
                };
            }
            return OperModel;
        }

    }
}