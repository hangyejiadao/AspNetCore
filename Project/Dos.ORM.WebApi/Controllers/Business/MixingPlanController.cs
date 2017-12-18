using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData.Query;
using AttributeRouting.Web.Http;
using Dos.ORM.Common.Enums;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.WebApi.Controllers.Base;

namespace Dos.ORM.WebApi.Controllers.Business
{
    /// <summary>
    /// 拌合站数据API
    /// </summary>
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "mixingplan")]
    public class MixingPlanController : BaseApiController
    {
        [Ninject.Inject]
        private IBUS_MixingPlanData MixingBll { get; set; }
        #region 
        /// <summary>
        /// 获取拌合站数据列表
        /// </summary>
        /// <param name="organId">机构Id</param>
        /// <param name="page">页码</param>
        /// <param name="pagesize">每页显示数</param>
        /// <returns></returns>
        [GET("get/plist/{organId}")]
        public OperateModel1<Page<BUS_MixingPlan>> GetPList(Guid organId, int page = 1, int pagesize = 10)
        {
            var r = MixingBll.GetList(organId, 1, 20);
            return new OperateModel1<Page<BUS_MixingPlan>>()
            {
                Data = r,
                Msg = "",
                Result = OperateRetType.Success
            };
        }
        #endregion
        #region 批量添加拌合站数据

        /// <summary>
        /// 批量添加拌合站数据
        /// </summary>
        /// <param name="modelList">待更新拌合站数据列表(一次最多20条)</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns></returns>
        [POST("addList/{projectId}/{timeStamp}")]
        public OperateModel AddModelList([FromBody]IList<BUS_MixingPlan> modelList, Guid projectId, string timeStamp)
        {
            if (modelList == null || modelList.Count <= 0)
                return new OperateModel(OperateRetType.Fail, "modelList不能为空");
            return MixingBll.AddModelList(modelList, projectId, timeStamp);
        }
        #endregion
    }
}
