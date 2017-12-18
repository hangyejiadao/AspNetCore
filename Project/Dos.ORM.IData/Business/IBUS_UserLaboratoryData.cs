/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.IData.Business
 * 类名称：IBUS_UserLaboratoryData
 * 创建时间：2017-02-15 11:06:10
 * 创建人：zjg-PC
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using Dos.ORM.IData.Base;
using Dos.ORM.Model.Business;
using System.Collections.Generic;

namespace Dos.ORM.IData.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBUS_UserLaboratoryData : IDBBase<BUS_UserLaboratory>
    {

        List<BUS_UserLaboratory> GetUserLab(string AccountID);
        
    }
}
