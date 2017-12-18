/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.IData.System
 * 类名称：ISYS_OperatorData
 * 创建时间：2016-09-21 16:32:34
 * 创建人：Quber
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System;
using Dos.ORM.IData.Base;
using Dos.ORM.Model.System;

namespace Dos.ORM.IData.System
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISYS_OperatorData : IDBBase<SYS_Operator>
    {
        /// <summary>
        /// 删除并添加部门、角色关系
        /// </summary>
        /// <param name="depIds"></param>
        /// <param name="roleIds"></param>
        /// <param name="postIds"></param>
        /// <param name="operatorId"></param>
        /// <param name="crtOptId"></param>
        /// <param name="trans"></param>
        void SaveDepRoleList(string depIds, string roleIds, string postIds, Guid operatorId, Guid crtOptId, DbTrans trans = null);
    }
}
