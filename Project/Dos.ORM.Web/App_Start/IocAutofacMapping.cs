/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Web
 * 类名称：IocAutofacMapping
 * 创建时间：2016-09-22 11:38:51
 * 创建人：Quber
 * 创建说明：Autofac依赖注入配置类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using Autofac;
using Dos.ORM.Data.System;
using Dos.ORM.IData.System;

namespace Dos.ORM.Web
{
    /// <summary>
    /// Autofac依赖注入配置类
    /// </summary>
    public class IocAutofacMapping
    {
        /// <summary>
        /// 依赖注入配置方法（供IocAutofacConfig.cs中RegisterDependencies方法调用）
        /// </summary>
        /// <param name="builder"></param>
        public static void SetupResolveRules(ContainerBuilder builder)
        {
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //.Where(t => t.Name.EndsWith("Repository"))
            //.AsImplementedInterfaces();
            builder.RegisterType<SYS_ButtonData>().As<ISYS_ButtonData>();
            builder.RegisterType<SYS_CompanyData>().As<ISYS_CompanyData>();
        }
    }
}