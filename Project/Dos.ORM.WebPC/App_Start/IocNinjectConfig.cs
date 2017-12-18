/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Web
 * 类名称：IocNinjectConfig
 * 创建时间：2016-09-21 15:26:33
 * 创建人：Quber
 * 创建说明：Ninject依赖注入类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System;
using System.Collections.Generic;
using Ninject;

namespace Dos.ORM.WebPC
{
    /// <summary>
    /// Ninject依赖注入类
    /// </summary>
    public class IocNinjectConfig : System.Web.Mvc.IDependencyResolver
    {
        #region 属性
        private readonly IKernel _kernel;
        #endregion

        #region 构造
        public IocNinjectConfig()
        {
            _kernel = new StandardKernel();

            /*
             * 下面这段代码的作用：
             *      如果控制器中使用的是属性注入的方式，而这时候接口成员的类型为private，
             *      那么这时候就需要设置下面这段代码。
             */
            _kernel.Settings.InjectNonPublic = true;

            IocNinjectMapping.SetupResolveRules(_kernel);
        }
        #endregion

        #region 方法
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
        #endregion
    }
}