/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data
 * 类名称：BUS_EquipmentTypeData
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
using System.Linq;
using Dos.ORM.Common.Enums;
using Dos.ORM.Data.Base;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using System.Linq.Expressions;

namespace Dos.ORM.Data.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class BUS_EquipmentTypeData : DBBase<BUS_EquipmentType>, IBUS_EquipmentTypeData
    {
        #region 获取设备类型基本数据

        /// <summary>
        /// 获取设备类型列表
        /// </summary>
        /// <returns></returns>
        public List<BUS_EquipmentType> GetList(Guid organId)
        {
            return GetModels(m => m.OrganID == organId);
        }


        /// <summary>
        /// 根据主键Id(Guid)获取对象
        /// </summary>
        /// <param name="id">主键id(Guid)</param>
        /// <returns></returns>
        public OperateModel GetOne(Guid id)
        {
            OperateModel resultInfo = new OperateModel();

            try
            {
                if (!id.Equals(Guid.Empty))
                {
                    var model = GetModel(m => m.EquipmentTypeID == id);
                    if (model != null)
                    {
                        resultInfo.Result = OperateRetType.Success;
                        resultInfo.Msg = "操作成功！";
                        resultInfo.Data = model;
                    }
                }
                return resultInfo;
            }
            catch (Exception ex)
            {
                return resultInfo;
            }
        }

        #endregion

        #region 设备类型数据同步
        private static readonly object ObjBusEquipmentType = new object();
        /// <summary>
        /// 同步设备类型数据
        /// </summary>
        /// <param name="modelList">传入的list</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns>结果对象</returns>
        public OperateModel AddModelList(IList<BUS_EquipmentType> modelList, Guid projectId, string timeStamp)
        {
            OperateModel resultInfo = new OperateModel();

            lock (ObjBusEquipmentType)
            {
                using (DbTrans trans = DB.DbCont.BeginTransaction())
                {
                    var proIds = modelList.Select(m => m.EquipmentTypeID).ToList();
                    try
                    {
                        var testerExit = GetModels(m => m.EquipmentTypeID.In(proIds));
                        if (testerExit != null && testerExit.Count > 0)
                        {
                            var testerExitNew = new List<BUS_EquipmentType>();

                            foreach (var item in testerExit)
                            {
                                var newItem = modelList.FirstOrDefault(m => m.EquipmentTypeID == item.EquipmentTypeID);
                                if (newItem != null)
                                {
                                    newItem.ID = item.ID;
                                    testerExitNew.Add(newItem);
                                }
                            }
                            UpdateModels(testerExitNew, trans);

                            var testerNon = proIds.Except(testerExit.Select(m => m.EquipmentTypeID)).ToList();
                            if (testerNon.Count > 0)
                            {
                                var nonList = (from a in modelList
                                               join b in testerNon on a.EquipmentTypeID equals b
                                               select a).ToList();
                                InsertModels(nonList, trans);
                            }
                        }
                        else
                        {
                            InsertModels(modelList.ToList(), trans);
                        }

                        if (API_SyncLogData.AddApiLog(projectId, timeStamp, "BUS_EquipmentType"))
                        {
                            resultInfo.Result = OperateRetType.Success;
                            resultInfo.Msg = "操作成功";
                            resultInfo.Data = true;
                        }
                        trans.Commit();
                        return resultInfo;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        API_SyncLogData.AddApiLog(projectId, timeStamp, "BUS_EquipmentType", false);
                        return resultInfo;
                    }
                }
            }
        }

        #endregion


        public DgListModel<BUS_EquipmentType> GetList(DgConModel dgCon, Expression<Func<BUS_EquipmentType, bool>> whereLambda = null)
        {
            var section = DB.DbCont.From<BUS_EquipmentType>()
                .LeftJoin<BUS_File>((a, b) => a.EquipmentTypeID == b.ModuleDataId)
                .Select(BUS_EquipmentType._.All, BUS_File._.FilePath)
                .Where(whereLambda).OrderBy(GetOrderByClip(dgCon));

            var totalCount = section.Count();
            var retList = section.Page(dgCon.rows, dgCon.page).ToList();

            return new DgListModel<BUS_EquipmentType>(retList, totalCount);
        }
    }
}
