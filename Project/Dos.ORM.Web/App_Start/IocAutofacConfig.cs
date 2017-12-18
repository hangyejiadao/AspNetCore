/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Web
 * 类名称：IocAutofacConfig
 * 创建时间：2016-09-22 11:38:44
 * 创建人：Quber
 * 创建说明：Autofac依赖注入类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System.Reflection;
using System.Web.Mvc;
using Autofac;
//using Autofac.Integration.Mvc;

namespace Dos.ORM.Web
{
    /// <summary>
    /// Autofac依赖注入类
    /// </summary>
    public class IocAutofacConfig
    {
        /// <summary>
        /// 初始化依赖注入方法（供Global.asax中Application_Start方法调用）
        /// </summary>
        public static void RegisterDependencies()
        {
            //var builder = new ContainerBuilder();
            //IocAutofacMapping.SetupResolveRules(builder);
            //builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //var container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}