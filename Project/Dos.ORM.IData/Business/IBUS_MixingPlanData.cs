/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.IData.Business
 * 类名称：IBUS_MixingPlanData
 * 创建时间：2017-03-07 11:24:29
 * 创建人：MS-20170220SVOI
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
using Dos.ORM.Model.BusView;

namespace Dos.ORM.IData.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBUS_MixingPlanData : IDBBase<BUS_MixingPlan>
    {
        /// <summary>
        /// 获取拌合站列表
        /// </summary>
        /// <returns></returns>
        Page<BUS_MixingPlan> GetList(Guid organId,int pageindex,int pagesize);
        /// <summary>
        /// 批量插入拌合站数据
        /// </summary>
        /// <param name="modelList">list</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">时间戳</param>
        /// <returns></returns>
        OperateModel AddModelList(IList<BUS_MixingPlan> modelList, Guid projectId, string timeStamp);
    }
}
