/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.IData.System
 * 类名称：ISYS_DepartmentData
 * 创建时间：2016-09-21 16:26:59
 * 创建人：Quber
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Dos.ORM.IData.Base;
using Dos.ORM.Model.System;

namespace Dos.ORM.IData.System
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISYS_DepartmentData : IDBBase<SYS_Department>
    {
        /// <summary>
        /// 根据管理员Id获取其部门列表
        /// </summary>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        List<SYS_Department> GetUserDepartments(Guid operatorId);

        /// <summary>
        /// 根据部门Id获取其所有的操作人员（包括所有的人员）
        /// </summary>
        /// <param name="depId"></param>
        /// <param name="comId"></param>
        /// <returns></returns>
        DataTable GetDepOperators(Guid depId, Guid? comId);
    }
}
