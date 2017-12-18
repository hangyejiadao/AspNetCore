using AttributeRouting.Web.Http;
using Dos.ORM.Common.Enums;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Models;
using Dos.ORM.WebApi.Controllers.Base;
using System;
using System.Web.Http;

namespace Dos.ORM.WebApi.Controllers.Business
{
    /// <summary>
    /// 模块API
    /// </summary>
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "echarts")]
    public class EChartsController : BaseApiController
    {


        [Ninject.Inject]
        private IBUS_ModuleData BusModule { get; set; }

        /// <summary>
        /// 按类型年份查询统计报告 X坐标为月份 
        /// </summary>
        /// <param name="pageCon"></param>
        /// <returns></returns>
        [POST("get/rptbyitem")]
        public Echart_Model PostEChartsReportByItem([FromBody]EChartsPageConModel pageCon)
        {
            var Model = BusModule.GetEChartsReportByItem(pageCon.OrganID, pageCon.ItemCode, pageCon.Year);

            return Model;
        }

        [POST("get/rptbymonth")]
        public Echart_Model PostEChartsReportByMonth([FromBody]EChartsPageConModel pageCon)
        {
            var Model = BusModule.GetEChartsReportByMonth(pageCon.OrganID, pageCon.Month);

            return Model;
        }


    }


}
