/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.IData.Business
 * 类名称：IBUS_EqumentData
 * 创建时间：2017-02-09 15:42:09
 * 创建人：CDKX-ZC-2015051
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using Dos.ORM.IData.Base;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using Dos.ORM.Model.BusView;
using System.Linq.Expressions;

namespace Dos.ORM.IData.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBUS_EqumentData : IDBBase<BUS_Equment>
    {
        /// <summary>
        /// 获取设备列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<BUS_Equment> GetList(Guid organId);

        /// <summary>
        /// 获取设备以及对应照片列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<EquView> GetListWPic(Guid organId);

        /// <summary>
        /// 根据主键Id(Guid)获取对象
        /// </summary>
        /// <param name="id">主键id(Guid)</param>
        /// <returns></returns>
        OperateModel GetOne(Guid id);

        /// <summary>
        /// 根据主键Id(Guid)获取对象及对应照片信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        OperateModel GetOneWPic(Guid id);

        /// <summary>
        /// 同步设备数据
        /// </summary>
        /// <param name="modelList">传入的list</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns>结果对象</returns>
        OperateModel AddModelList(IList<BUS_Equment> modelList, Guid projectId, string timeStamp);

        DgListModel<BUS_Equment> GetList(DgConModel dgCon, Expression<Func<BUS_Equment, bool>> whereLambda = null);
    }
}
