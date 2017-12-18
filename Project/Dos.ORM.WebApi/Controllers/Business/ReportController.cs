using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using AttributeRouting.Web.Http;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.WebApi.Controllers.Base;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Model.BusView;

namespace Dos.ORM.WebApi.Controllers.Business
{
    /// <summary>
    /// 报告API
    /// </summary>
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "report")]
    public class ReportController : BaseApiController
    {
        [Ninject.Inject]
        private IBUS_ReportData RePortBll { get; set; }

        [Ninject.Inject]
        private IBUS_ReportViewData ReptViewBll { get; set; }

        #region 获取报告以及对应样品列表
        /// <summary>
        /// 分页获取报告以及对应样品列表
        /// </summary>
        /// <param name="organId">机构Id</param>
        /// <param name="options">Odata参数</param>
        /// <returns></returns>
        [GET("get/plistWSample/{organId}")]
        public OperateModel GetPListWSample(Guid organId, ODataQueryOptions<ReportView> options)
        {
            return GetPagerList(RePortBll.GetListWSample(organId), options);
        }

        /// <summary>
        /// 分页获取报告以及对应样品列表,并自定义页大小
        /// </summary>
        /// <param name="organId">机构Id</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="options">Odata参数</param>
        /// <returns></returns>
        [GET("get/pslistWSample/{organId}/{pageSize}")]
        public OperateModel GetPgListWSample(Guid organId, int pageSize, ODataQueryOptions<ReportView> options)
        {
            return GetPagerList(RePortBll.GetListWSample(organId), options, pageSize);
        }
        #endregion

        #region 根据主键获取报告
        /// <summary>
        /// 根据主键Id(Guid)获取对象
        /// </summary>
        /// <param name="id">主键id(Guid)</param>
        /// <returns></returns>
        [GET("get/one/{id}")]
        public OperateModel GetOne(Guid id)
        {
            return RePortBll.GetOne(id);
        }

        /// <summary>
        /// 根据主键Id(Guid)获取对象及对应样品信息
        /// </summary>
        /// <param name="id">主键id(Guid)</param>
        /// <returns></returns>
        [GET("get/oneWSample/{id}")]
        public OperateModel GetOneWSample(Guid id)
        {
            return RePortBll.GetOneWSample(id);
        }
        #endregion

        #region 报告同步

        /// <summary>
        /// 批量添加报告
        /// </summary>
        /// <param name="modelList">报告列表</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns></returns>
        [POST("addList/{projectId}/{timeStamp}")]
        public OperateModel AddModelList([FromBody]IList<BUS_Report> modelList, Guid projectId, string timeStamp)
        {
            return RePortBll.AddModelList(modelList, projectId, timeStamp);
        }
        #endregion


        #region 报告列表
        /// <summary>
        /// 分页获取报告列表
        /// </summary>
        /// <param name="organId">机构Id</param>
        /// <param name="options">Odata参数</param>
        /// <returns></returns>
        [GET("get/plist/{organId}")]
        public OperateModel GetPList(Guid organId, ODataQueryOptions<BUS_Report> options)
        {
            return GetPagerList(RePortBll.GetList(organId), options);
        }
        #endregion
        /// <summary>
        /// 分页获取合格报告列表
        /// </summary>
        /// <returns></returns>
        [POST("get/list1")]
        public OperateModel ReportList1([FromBody]ModelPageConModel pageCon)
        {
            OperateModel OperModel = null;
            if (string.IsNullOrWhiteSpace(pageCon.TargetId))
            {
                OperModel = new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "targetId不能为空，获取失败！"
                };
            }
            else
            {
                #region 条件拼接
                var exp = ExpHelper.Create<BUS_ReportView>(s => s.OrganID == Guid.Parse(pageCon.TargetId) && s.IsQualified == true);

                if (!string.IsNullOrWhiteSpace(pageCon.TypeId))
                    exp = exp.And(s => s.SampleTypeID == Guid.Parse(pageCon.TypeId));

                if (!string.IsNullOrWhiteSpace(pageCon.StartDate))
                {
                    DateTime? StartDate = Convert.ToDateTime(pageCon.StartDate);
                    exp = exp.And(s => s.ReportDate >= StartDate);
                }

                if (!string.IsNullOrWhiteSpace(pageCon.EndDate))
                {
                    DateTime? EndDate = Convert.ToDateTime(pageCon.EndDate);
                    exp = exp.And(s => s.ReportDate <= EndDate);
                }

                if (!string.IsNullOrWhiteSpace(pageCon.FilterText))
                    exp = exp.And(s => s.SampleName.Contains(pageCon.FilterText) || s.SampleNumber.Contains(pageCon.FilterText)
                        || s.ReportNumber.Contains(pageCon.FilterText) || s.ExperimentName.Contains(pageCon.FilterText));
                #endregion

                var retList = ReptViewBll.GetPagesForDg(new DgConModel() { page = pageCon.PageIndex, rows = pageCon.PageSize }, "ReportDate", exp);

                OperModel = new OperateModel
                {
                    Result = retList != null ? OperateRetType.Success : OperateRetType.Fail,
                    Msg = retList != null ? "获取成功！" : "获取失败！",
                    Data = retList
                };
            }
            return OperModel;
        }

        /// <summary>
        /// 分页获取不合格报告列表
        /// </summary>
        /// <returns></returns>
        [POST("get/list2")]
        public OperateModel ReportList2([FromBody]ModelPageConModel pageCon)
        {
            OperateModel OperModel = null;
            if (string.IsNullOrWhiteSpace(pageCon.TargetId))
            {
                OperModel = new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "targetId不能为空，获取失败！"
                };     
            }
            else
            {
                #region 条件拼接
                var exp = ExpHelper.Create<BUS_ReportView>(s => s.OrganID == Guid.Parse(pageCon.TargetId) && s.IsQualified == false);

                if (!string.IsNullOrWhiteSpace(pageCon.TypeId))
                    exp = exp.And(s => s.SampleTypeID == Guid.Parse(pageCon.TypeId));

                if (!string.IsNullOrWhiteSpace(pageCon.StartDate))
                {
                    DateTime? StartDate = Convert.ToDateTime(pageCon.StartDate);
                    exp = exp.And(s => s.ReportDate >= StartDate);
                }

                if (!string.IsNullOrWhiteSpace(pageCon.EndDate))
                {
                    DateTime? EndDate = Convert.ToDateTime(pageCon.EndDate);
                    exp = exp.And(s => s.ReportDate <= EndDate);
                }

                if (!string.IsNullOrWhiteSpace(pageCon.FilterText))
                    exp = exp.And(s => s.SampleName.Contains(pageCon.FilterText) || s.SampleNumber.Contains(pageCon.FilterText)
                        || s.ReportNumber.Contains(pageCon.FilterText) || s.ExperimentName.Contains(pageCon.FilterText));
                #endregion

                var retList = ReptViewBll.GetPagesForDg(new DgConModel() { page = pageCon.PageIndex, rows = pageCon.PageSize }, "ReportDate", exp);

                OperModel = new OperateModel
                {
                    Result = retList != null ? OperateRetType.Success : OperateRetType.Fail,
                    Msg = retList != null ? "获取成功！" : "获取失败！",
                    Data = retList
                };
            }
            return OperModel;
        }

        /// <summary>
        /// 分页获取检测报告列表
        /// </summary>
        /// <returns></returns>
        [POST("get/list3")]
        public OperateModel ReportList3([FromBody]ModelPageConModel pageCon)
        {
            OperateModel OperModel = null;
            if (string.IsNullOrWhiteSpace(pageCon.TargetId))
            {
                OperModel = new OperateModel
                {
                    Result = OperateRetType.Fail,
                    Msg = "targetId不能为空，获取失败！"
                };
            }
            else
            {
                var exp = ExpHelper.Create<BUS_ReportView>(s => s.OrganID == Guid.Parse(pageCon.TargetId));

                if (!string.IsNullOrWhiteSpace(pageCon.TypeId))
                    exp = exp.And(s => s.SampleTypeID == Guid.Parse(pageCon.TypeId));

                if (!string.IsNullOrWhiteSpace(pageCon.StartDate))
                {
                    DateTime? StartDate = Convert.ToDateTime(pageCon.StartDate);
                    exp = exp.And(s => s.ReportDate >= StartDate);
                }
                
                if (!string.IsNullOrWhiteSpace(pageCon.EndDate))
                {
                    DateTime? EndDate = Convert.ToDateTime(pageCon.EndDate);
                    exp = exp.And(s => s.ReportDate <= EndDate);
                }

                if (!string.IsNullOrWhiteSpace(pageCon.FilterText))
                    exp = exp.And(s => s.SampleName.Contains(pageCon.FilterText) || s.SampleNumber.Contains(pageCon.FilterText)
                        || s.ReportNumber.Contains(pageCon.FilterText) || s.ExperimentName.Contains(pageCon.FilterText));

                var retList = ReptViewBll.GetPagesForDg(new DgConModel() { page = pageCon.PageIndex, rows = pageCon.PageSize }, "ReportDate", exp);

                OperModel = new OperateModel
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