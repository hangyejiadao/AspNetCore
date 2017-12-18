/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Web.App_Start
 * 类名称：WebApiAuthHandler
 * 创建时间：2016-12-26 16:08:48
 * 创建人：Quber
 * 创建说明：为WebApi设置依赖注入配置
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Syntax;

namespace Dos.ORM.Web
{
    /// <summary>
    /// 为WebApi设置依赖注入配置
    /// </summary>
    public class IocNinjectDependencyResolverForWebApi : NinjectDependencyScope, IDependencyResolver
    {
        private readonly IKernel _kernel;

        public IocNinjectDependencyResolverForWebApi(IKernel kernel)
            : base(kernel)
        {
            if (kernel == null)
            {
                throw new ArgumentNullException("kernel");
            }
            this._kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(_kernel);
        }
    }

    public class NinjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot _resolver;

        internal NinjectDependencyScope(IResolutionRoot resolver)
        {
            Contract.Assert(resolver != null);

            this._resolver = resolver;
        }

        public void Dispose()
        {
            _resolver = null;
        }

        public object GetService(Type serviceType)
        {
            return _resolver.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolver.GetAll(serviceType);
        }
    }
}