/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.IData.Business
 * 类名称：IBUS_LinkInfoData
 * 创建时间：2016-09-22 17:38:47
 * 创建人：QUBER-PC
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System;
using System.Linq.Expressions;
using Dos.ORM.IData.Base;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;

namespace Dos.ORM.IData.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBUS_LinkInfoData : IDBBase<BUS_LinkInfo>
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="dgCon"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        object GetList(DgConModel dgCon, Expression<Func<BUS_LinkInfo, bool>> whereLambda = null);
    }
}
