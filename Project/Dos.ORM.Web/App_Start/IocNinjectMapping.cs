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

using Dos.ORM.Data.Business;
using Dos.ORM.Data.System;

using Dos.ORM.IData.Business;
using Dos.ORM.IData.System;

using Ninject;

namespace Dos.ORM.Web
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
            kernel.Bind<ICON_AreaCodeData>().To<CON_AreaCodeData>();
            kernel.Bind<ISYS_ButtonData>().To<SYS_ButtonData>();
            kernel.Bind<ISYS_CompanyData>().To<SYS_CompanyData>();
            kernel.Bind<ISYS_DepartmentData>().To<SYS_DepartmentData>();
            kernel.Bind<ISYS_LogInfoData>().To<SYS_LogInfoData>();
            kernel.Bind<ISYS_LogTypeData>().To<SYS_LogTypeData>();
            kernel.Bind<ISYS_ModuleButtonRelationData>().To<SYS_ModuleButtonRelationData>();
            kernel.Bind<ISYS_ModuleData>().To<SYS_ModuleData>();
            kernel.Bind<ISYS_OperatorData>().To<SYS_OperatorData>();
            kernel.Bind<ISYS_OperatorPostRelationData>().To<SYS_OperatorPostRelationData>();
            kernel.Bind<ISYS_OperatorDepartmentRelationData>().To<SYS_OperatorDepartmentRelationData>();
            kernel.Bind<ISYS_OperatorRoleRelationData>().To<SYS_OperatorRoleRelationData>();
            kernel.Bind<ISYS_PostData>().To<SYS_PostData>();
            kernel.Bind<ISYS_RoleData>().To<SYS_RoleData>();
            kernel.Bind<ISYS_RoleModuleRelationData>().To<SYS_RoleModuleRelationData>();
            kernel.Bind<Iv_SYS_ButtonData>().To<v_SYS_ButtonData>();
            kernel.Bind<Iv_SYS_LogInfoRptData>().To<v_SYS_LogInfoRptData>();
            kernel.Bind<Iv_SYS_ModuleData>().To<v_SYS_ModuleData>();
            #endregion

          
            #region Business
            kernel.Bind<IBUS_RoleData>().To<BUS_RoleData>();
            kernel.Bind<IBUS_RoleModuleData>().To<BUS_RoleModuleData>();
            kernel.Bind<IBUS_ModuleData>().To<BUS_ModuleData>();
            kernel.Bind<IBUS_ProjectData>().To<BUS_ProjectData>();
            kernel.Bind<IBUS_LaboratoryData>().To<BUS_LaboratoryData>();
            kernel.Bind<IBUS_ProjectLaboratoryData>().To<BUS_ProjectLaboratoryData>();
            kernel.Bind<IBUS_UserData>().To<BUS_UserData>();
            kernel.Bind<IBUS_UserRoleData>().To<BUS_UserRoleData>();
            kernel.Bind<IBUS_UserLaboratoryData>().To<BUS_UserLaboratoryData>();

            kernel.Bind<IAPI_SyncLogData>().To<API_SyncLogData>();

            #endregion
        }
    }
}