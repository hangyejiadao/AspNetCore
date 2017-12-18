using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Query;
using AttributeRouting.Web.Http;
using Dos.ORM.Common.Enums;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.WebApi.Controllers.Base;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Model.BusView;
using Newtonsoft.Json;

namespace Dos.ORM.WebApi.Controllers.Business
{
    /// <summary>
    /// 试验检测人员API
    /// </summary>
    [AttributeRouting.RoutePrefix(RouteConfig.BaseApi + "tester")]
    public class TesterController : BaseApiController
    {
        [Ninject.Inject]
        private IBUS_TesterData TesterBll { get; set; }


        #region 获取验检测人员列表
        /// <summary>
        /// 分页获取试验检测人员列表
        /// </summary>
        /// <param name="organId">机构Id</param>
        /// <param name="options">Odata参数</param>
        /// <returns></returns>
        [GET("get/plist/{organId}")]
        public OperateModel GetPList(Guid organId, ODataQueryOptions<BUS_Tester> options)
        {
            return GetPagerList(TesterBll.GetList(organId), options);
        }

        /// <summary>
        /// 分页获取试验检测人员列表,并自定义页大小
        /// </summary>
        /// <param name="pageSize">页大小</param>
        /// <param name="organId">机构Id</param>
        /// <param name="options">Odata参数</param>
        /// <returns></returns>
        [GET("get/pslist/{organId}/{pageSize}")]
        public OperateModel GetPgList(Guid organId, int pageSize, ODataQueryOptions<BUS_Tester> options)
        {
            return GetPagerList(TesterBll.GetList(organId), options, pageSize);
        }
        #endregion

        #region 获取人员以及对应照片列表
        /// <summary>
        /// 获取人员以及对应照片列表
        /// </summary>
        /// <returns></returns>
        [GET("get/listWPic")]
        public OperateModel GetListWPic()
        {
            return TesterBll.GetListWPic();
        }

        /// <summary>
        /// 分页获取人员以及对应照片列表
        /// </summary>
        /// <param name="organId">结构Id</param>
        /// <param name="options">Odata参数</param>
        /// <returns></returns>
        [GET("get/plistWPic/{organId}")]
        public OperateModel GetPListWPic(Guid organId, ODataQueryOptions<TesterView> options)
        {
            return GetPagerList(TesterBll.GetListWPic(organId), options);
        }
        #endregion

        #region 根据主键获取人员
        /// <summary>
        /// 根据主键Id(Guid)获取对象
        /// </summary>
        /// <param name="id">主键id(Guid)</param>
        /// <returns></returns>
        [GET("get/one/{id}")]
        public OperateModel GetOne(Guid id)
        {
            return TesterBll.GetOne(id);
        }

        /// <summary>
        /// 根据主键Id(Guid)获取对象及对应照片信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [GET("get/oneWPic/{id}")]
        public OperateModel GetOneWPic(Guid id)
        {
            return TesterBll.GetOneWPic(id);
        }
        #endregion

        #region 人员同步

        /// <summary>
        /// 批量添加试验检测人员
        /// </summary>
        /// <param name="modelList">检测人员列表</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns></returns>
        [POST("addList/{projectId}/{timeStamp}")]
        public OperateModel AddModelList([FromBody]IList<BUS_Tester> modelList, Guid projectId, string timeStamp)
        {
            if (modelList == null || modelList.Count <= 0)
                return new OperateModel(OperateRetType.Fail, "modelList不能为空");
            return TesterBll.AddModelList(modelList, projectId, timeStamp);
        }
        #endregion


        /// <summary>
        /// 获取试验检测人员列表
        /// </summary>
        /// <returns></returns>
        [POST("get/list1")]
        public OperateModel<BUS_Tester> TesterList([FromBody]ModelPageConModel pageCon)
        {
            OperateModel<BUS_Tester> OperModel = null;
            if (string.IsNullOrWhiteSpace(pageCon.TargetId))
            {
                OperModel = new OperateModel<BUS_Tester>
                {
                    Result = OperateRetType.Fail,
                    Msg = "targetId不能为空，获取失败！"
                };
            }
            else
            {
               
                var exp = ExpHelper.Create<BUS_Tester>(s => s.OrganID == Guid.Parse(pageCon.TargetId));

                if (!string.IsNullOrWhiteSpace(pageCon.FilterText))
                    exp = exp.And(s => s.Name.Contains(pageCon.FilterText) || s.Job.Contains(pageCon.FilterText));
                
                DgConModel dgCon = new DgConModel() { page = pageCon.PageIndex, rows = pageCon.PageSize, sort = "Name", order="asc" };
              
                var retList = TesterBll.GetList(dgCon, exp);                

               // var retList = TesterBll.GetPagesForDg(new DgConModel() { page = pageCon.PageIndex, rows = pageCon.PageSize }, "Name", exp);
                
                OperModel = new OperateModel<BUS_Tester>
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