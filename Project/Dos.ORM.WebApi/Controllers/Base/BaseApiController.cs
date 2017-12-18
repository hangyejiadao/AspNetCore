using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;
using System.Web.Http.Results;
using Dos.ORM.Common.Enums;
using Dos.ORM.Data.Base;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using System.Linq.Expressions;

namespace Dos.ORM.WebApi.Controllers.Base
{
    /// <summary>
    /// Api基类
    /// </summary>
    public class BaseApiController : ApiController
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
        }

        protected override ResponseMessageResult ResponseMessage(HttpResponseMessage response)
        {
            return base.ResponseMessage(response);
        }

        protected override OkResult Ok()
        {
            return base.Ok();
        }

        #region  CommonOdata Pager

        /// <summary>
        ///  结果集分页
        /// </summary>
        /// <typeparam name="TEntity">实体</typeparam>
        /// <param name="options">筛选条件集合</param>
        /// <param name="list">待分页集合</param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageResult<TEntity> GetPager<TEntity>(List<TEntity> list, ODataQueryOptions<TEntity> options, int pageSize = 6) where TEntity : class
        {
            try
            {
                ODataQuerySettings settings = new ODataQuerySettings
                {
                    PageSize = pageSize
                };

                //因为没有[EnableQuery]，所以这里我们要自己来valid一下
                //ODataValidationSettings vSettings = new ODataValidationSettings()
                //{
                //    AllowedQueryOptions = AllowedQueryOptions.Format | AllowedQueryOptions.Filter   //support count and filter only      
                //};
                //options.Validate(vSettings); //这里fail会 throw ODataException

                IQueryable results = options.ApplyTo(list.AsQueryable(), settings);
                return new PageResult<TEntity>(
                    results as IEnumerable<TEntity>,
                    //Request.GetNextPageLink(),
                    //Request.GetInlineCount());
                    Request.ODataProperties().NextLink,
                    Request.ODataProperties().TotalCount
                    );
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        /// <summary>
        ///  结果集分页
        /// </summary>
        /// <typeparam name="TEntity">实体</typeparam>
        /// <param name="options">筛选条件集合</param>
        /// <param name="list">待分页集合</param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageResult<TEntity> GetPager<TEntity>(IEnumerable<TEntity> list, ODataQueryOptions<TEntity> options, int pageSize = 6) where TEntity : class
        {
            try
            {
                ODataQuerySettings settings = new ODataQuerySettings
                {
                    PageSize = pageSize
                };

                //因为没有[EnableQuery]，所以这里我们要自己来valid一下
                //ODataValidationSettings vSettings = new ODataValidationSettings()
                //{
                //    AllowedQueryOptions = AllowedQueryOptions.Format | AllowedQueryOptions.Filter   //support count and filter only      
                //};
                //options.Validate(vSettings); //这里fail会 throw ODataException

                IQueryable results = options.ApplyTo(list.AsQueryable(), settings);
                return new PageResult<TEntity>(
                    results as IEnumerable<TEntity>,
                    //Request.GetNextPageLink(),
                    //Request.GetInlineCount());
                    Request.ODataProperties().NextLink,
                    Request.ODataProperties().TotalCount
                    );
            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>
        /// 结果集统一输出
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public OperateModel GetPagerList<T>(IEnumerable<T> list, ODataQueryOptions<T> options) where T : class
        {
            return new OperateModel
            {
                Result = OperateRetType.Success,
                Msg = "操作成功！",
                Data = GetPager(list, options)
            };
        }

        /// <summary>
        /// 结果集统一输出
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public OperateModel GetPagerList<T>(List<T> list, ODataQueryOptions<T> options) where T : class
        {
            return new OperateModel
            {
                Result = OperateRetType.Success,
                Msg = "操作成功！",
                Data = GetPager(list, options)
            };
        }

        /// <summary>
        /// 结果集统一输出重载
        /// </summary>
        /// <param name="list"></param>
        /// <param name="options"></param>
        /// <param name="pageSize"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public OperateModel GetPagerList<T>(List<T> list, ODataQueryOptions<T> options, int pageSize) where T : class
        {
            return new OperateModel
            {
                Result = OperateRetType.Success,
                Msg = "操作成功！",
                Data = GetPager(list, options, pageSize)
            };
        }

        /// <summary>
        /// 结果集统一输出重载
        /// </summary>
        /// <param name="list"></param>
        /// <param name="options"></param>
        /// <param name="pageSize"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public OperateModel GetPagerList<T>(IEnumerable<T> list, ODataQueryOptions<T> options, int pageSize) where T : class
        {
            return new OperateModel
            {
                Result = OperateRetType.Success,
                Msg = "操作成功！",
                Data = GetPager(list, options, pageSize)
            };
        }

        #endregion

        #region 获取分页数据相关属性和方法

        /// <summary>
        /// 返回Lambda查询表达式
        /// </summary>
        /// <typeparam name="T">数据实体</typeparam>
        /// <returns></returns>
        public Expression<Func<T, bool>> GetPageExp<T>() where T : class
        {
            Expression<Func<T, bool>> exp = (m => true);

            return exp;
        }

        #endregion
    }
}
