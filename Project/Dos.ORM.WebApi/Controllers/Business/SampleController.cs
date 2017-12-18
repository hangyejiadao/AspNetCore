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
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.WebApi.Controllers.Base;

namespace Dos.ORM.WebApi.Controllers.Business
{
    /// <summary>
    /// 样品API
    /// </summary>
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "sample")]
    public class SampleController : BaseApiController
    {
        [Ninject.Inject]
        private IBUS_SampleData SampleBll { get; set; }

        /// <summary>
        /// 获取样品列表
        /// </summary>
        /// <returns></returns>
        [GET("get/list")]
        public OperateModel GetList()
        {
            return SampleBll.GetList();
        }

        /// <summary>
        /// 根据主键Id(Guid)获取对象
        /// </summary>
        /// <param name="id">主键id(Guid)</param>
        /// <returns></returns>
        [GET("get/one/{id}")]
        public OperateModel GetOne(Guid id)
        {
            return SampleBll.GetOne(id);
        }

        /// <summary>
        /// 批量添加实验室
        /// </summary>
        /// <param name="modelList">实验室列表</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns></returns>
        [POST("addList/{projectId}/{timeStamp}")]
        public OperateModel AddModelList([FromBody]IList<BUS_Sample> modelList, Guid projectId, string timeStamp)
        {
            return SampleBll.AddModelList(modelList, projectId, timeStamp);
        }

        /// <summary>
        /// 分页获取样品列表
        /// </summary>
        /// <returns></returns>
        [POST("get/list1")]
        public OperateModel<BUS_Sample> SiampleList([FromBody]ModelPageConModel pageCon)
        {

            OperateModel<BUS_Sample> OperModel = null;
            if (string.IsNullOrWhiteSpace(pageCon.TargetId))
            {
                OperModel = new OperateModel<BUS_Sample>
                {
                    Result = OperateRetType.Fail,
                    Msg = "targetId不能为空，获取失败！"
                };
            }
            else
            {
                var exp = ExpHelper.Create<BUS_Sample>(s => s.OrganID == Guid.Parse(pageCon.TargetId));

                if (!string.IsNullOrWhiteSpace(pageCon.TypeId))
                    exp = exp.And(s => s.SampleTypeID == Guid.Parse(pageCon.TypeId));

                if (!string.IsNullOrWhiteSpace(pageCon.StartDate))
                {
                    DateTime? StartDate = Convert.ToDateTime(pageCon.StartDate + " 00:00:00");
                    exp = exp.And(s => s.SamplingDate >= StartDate);
                }

                if (!string.IsNullOrWhiteSpace(pageCon.EndDate))
                {
                    DateTime? EndDate = Convert.ToDateTime(pageCon.EndDate + " 23:59:59");
                    exp = exp.And(s => s.SamplingDate <= EndDate);
                }

                if (!string.IsNullOrWhiteSpace(pageCon.FilterText))
                    exp = exp.And(s => s.SampleName.Contains(pageCon.FilterText) || s.SampleNumber.Contains(pageCon.FilterText));


                var retList = SampleBll.GetPagesForDg(new DgConModel() { page = pageCon.PageIndex, rows = pageCon.PageSize }, "SamplingDate", exp);

                OperModel = new OperateModel<BUS_Sample>
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