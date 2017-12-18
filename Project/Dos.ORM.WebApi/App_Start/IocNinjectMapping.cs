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

using Dos.ORM.Data;
using Dos.ORM.Data.Business;
using Dos.ORM.Data.System;
using Dos.ORM.IData;
using Dos.ORM.IData.Business;
using Dos.ORM.IData.System;
using Ninject;

namespace Dos.ORM.WebApi
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
      
            kernel.Bind<IBUS_EqumentData>().To<BUS_EqumentData>();
            kernel.Bind<IBUS_LaboratoryData>().To<BUS_LaboratoryData>();   
            kernel.Bind<IBUS_MemberData>().To<BUS_MemberData>();

            kernel.Bind<IBUS_ModuleData>().To<BUS_ModuleData>();
            kernel.Bind<IBUS_UserLaboratoryData>().To<BUS_UserLaboratoryData>();
               
            kernel.Bind<IBUS_ProjectData>().To<BUS_ProjectData>();
            kernel.Bind<IBUS_ProjectLaboratoryData>().To<BUS_ProjectLaboratoryData>();
            kernel.Bind<IBUS_RoleData>().To<BUS_RoleData>();
            kernel.Bind<IBUS_RoleModuleData>().To<BUS_RoleModuleData>();

            kernel.Bind<IBUS_TesterData>().To<BUS_TesterData>();
            kernel.Bind<IBUS_UserData>().To<BUS_UserData>();          
            kernel.Bind<IBUS_UserRoleData>().To<BUS_UserRoleData>();
            kernel.Bind<IBUS_FileData>().To<BUS_FileData>();

            kernel.Bind<IBUS_SampleData>().To<BUS_SampleData>();
            kernel.Bind<IBUS_ReportData>().To<BUS_ReportData>();
            kernel.Bind<IBUS_ReportViewData>().To<BUS_ReportViewData>();
            
            kernel.Bind<IBUS_EquipmentTypeData>().To<BUS_EquipmentTypeData>();
            kernel.Bind<IBUS_SampleTypeData>().To<BUS_SampleTypeData>();

            kernel.Bind<IBUS_RecordData>().To<BUS_RecordData>();
            kernel.Bind<IBUS_SubContractorData>().To<BUS_SubContractorData>();
            
            kernel.Bind<IBUS_StatisticsTypeData>().To<BUS_StatisticsTypeData>();

            kernel.Bind<IAPI_SyncLogData>().To<API_SyncLogData>();
            kernel.Bind<IBUS_MixingPlanData>().To<BUS_MixingPlanData>();

            #endregion
        }
    }
}