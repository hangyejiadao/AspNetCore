/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.IData.System
 * 类名称：ISYS_ModuleButtonRelationData
 * 创建时间：2016-09-21 16:30:50
 * 创建人：Quber
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System;
using System.Collections.Generic;
using Dos.ORM.IData.Base;
using Dos.ORM.Model.System;

namespace Dos.ORM.IData.System
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISYS_ModuleButtonRelationData : IDBBase<SYS_ModuleButtonRelation>
    {
        /// <summary>
        /// 管理模块按钮关系
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="listModuleButton"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        bool ModifyModuleButton(Guid moduleId, List<SYS_ModuleButtonRelation> listModuleButton, DbTrans trans = null);
    }
}
