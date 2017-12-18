/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Web
 * 类名称：IocNinjectMapping
 * 创建时间：2016-09-21 15:28:36
 * 创建人：Quber
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

//using Dos.ORM.Data.Business;
//using Dos.ORM.Data.System;
//using Dos.ORM.IData.Business;
//using Dos.ORM.IData.System;
using Ninject;

namespace Dos.ORM.WebPC
{
    /// <summary>
    /// 
    /// </summary>
    public static class IocNinjectMapping
    {
        /// <summary>
        /// 依赖注入配置方法（供IocNinjectConfig.cs中构造函数调用）
        /// </summary>
        /// <param name="kernel">Ninject.IKernel对象</param>
        public static void SetupResolveRules(IKernel kernel)
        {
            #region System           
                 
          
            #endregion

            #region Business
           
            #endregion
        }
    }
}