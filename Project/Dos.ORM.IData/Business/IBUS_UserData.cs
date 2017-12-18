/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.IData.Business
 * 类名称：IBUS_UserData
 * 创建时间：2017-02-09 15:42:10
 * 创建人：CDKX-ZC-2015051
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using Dos.ORM.IData.Base;
using Dos.ORM.Model.Business;
using System;
using Dos.ORM.Model.Base;

namespace Dos.ORM.IData.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBUS_UserData : IDBBase<BUS_User>
    {

        /// <summary>
        /// 获取人员列表
        /// </summary>
        /// <returns></returns>
        OperateModel GetList();

        /// <summary>
        /// 根据主键Id(Guid)获取对象
        /// </summary>
        /// <param name="id">主键id(Guid)</param>
        /// <returns></returns>
        OperateModel GetOne(Guid id);

        /// <summary>
        /// 删除并添加角色关系
        /// </summary>
        /// <param name="roleIds"></param>
        /// <param name="accountId"></param>
        /// <param name="trans"></param>
        void SaveRole(string roleIds, Guid accountId, DbTrans trans = null);
    }
}
