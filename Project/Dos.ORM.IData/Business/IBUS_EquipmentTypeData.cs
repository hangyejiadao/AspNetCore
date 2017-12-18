/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.IData
 * 类名称：IBUS_EquipmentTypeData
 * 创建时间：2017-02-21 15:08:59
 * 创建人：CDKX-ZC-2015051
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System;
using System.Collections.Generic;
using Dos.ORM.IData.Base;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using System.Linq.Expressions;

namespace Dos.ORM.IData.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBUS_EquipmentTypeData : IDBBase<BUS_EquipmentType>
    {
        /// <summary>
        /// 获取设备类型列表
        /// </summary>
        /// <returns></returns>
        List<BUS_EquipmentType> GetList(Guid organId);

        /// <summary>
        /// 根据主键Id(Guid)获取对象
        /// </summary>
        /// <param name="id">主键id(Guid)</param>
        /// <returns></returns>
        OperateModel GetOne(Guid id);

        /// <summary>
        /// 同步设备类型数据
        /// </summary>
        /// <param name="modelList">传入的list</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns>结果对象</returns>
        OperateModel AddModelList(IList<BUS_EquipmentType> modelList, Guid projectId, string timeStamp);

        DgListModel<BUS_EquipmentType> GetList(DgConModel dgCon, Expression<Func<BUS_EquipmentType, bool>> whereLambda = null);
    }
}
