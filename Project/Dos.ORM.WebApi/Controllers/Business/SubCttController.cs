using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData.Query;
using AttributeRouting.Web.Http;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.WebApi.Controllers.Base;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;

namespace Dos.ORM.WebApi.Controllers.Business
{   
    /// <summary>
    /// 外委试验台账API
    /// </summary>
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "subctt")]
    public class SubCttController : BaseApiController
    {
        [Ninject.Inject]
        private IBUS_SubContractorData SubCttBll { get; set; }

        /// <summary>
        /// 获取外委试验台账列表
        /// </summary>
        /// <returns></returns>
        [GET("get/list")]
        public OperateModel GetList()
        {
            return SubCttBll.GetList();
        }

        /// <summary>
        /// 获取分页外委试验台账列表
        /// </summary>
        /// <param name="options">Odata参数</param>
        /// <returns></returns>
        [GET("get/plist")]
        public OperateModel GetPList(ODataQueryOptions<BUS_SubContractor> options)
        {
            return GetPagerList(SubCttBll.GetModels(), options);
        }

        /// <summary>
        /// 批量添加外委试验台账
        /// </summary>
        /// <param name="modelList">外委试验台账列表</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns></returns>
        [POST("addList/{projectId}/{timeStamp}")]
        public OperateModel AddModelList([FromBody]IList<BUS_SubContractor> modelList, Guid projectId, string timeStamp)
        {
            return SubCttBll.AddModelList(modelList, projectId, timeStamp);
        }

        /// <summary>
        /// 分页获取外委台账列表
        /// </summary>
        /// <returns></returns>
        [POST("get/list1")]
        public OperateModel<BUS_SubContractor> SubScttList([FromBody]ModelPageConModel pageCon)
        {
            OperateModel<BUS_SubContractor> OperModel = null;
            if (string.IsNullOrWhiteSpace(pageCon.TargetId))
            {
                OperModel = new OperateModel<BUS_SubContractor>
                {
                    Result = OperateRetType.Fail,
                    Msg = "targetId不能为空，获取失败！"
                };
            }
            else
            {
                var exp = ExpHelper.Create<BUS_SubContractor>(s => s.OrganID == Guid.Parse(pageCon.TargetId));

                if (!string.IsNullOrWhiteSpace(pageCon.StartDate))
                {
                    DateTime? StartDate = Convert.ToDateTime(pageCon.StartDate + " 00:00:00");
                    exp = exp.And(s => s.EntrustDate >= StartDate);
                }

                if (!string.IsNullOrWhiteSpace(pageCon.EndDate))
                {
                    DateTime? EndDate = Convert.ToDateTime(pageCon.EndDate + " 23:59:59");
                    exp = exp.And(s => s.EntrustDate <= EndDate);
                }
                
                if (!string.IsNullOrWhiteSpace(pageCon.FilterText))
                    exp = exp.And(s => s.SampleName.Contains(pageCon.FilterText) || s.SampleNumber.Contains(pageCon.FilterText));

                var retList = SubCttBll.GetPagesForDg(new DgConModel() { page = pageCon.PageIndex, rows = pageCon.PageSize }, "EntrustDate", exp);

                OperModel = new OperateModel<BUS_SubContractor>
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