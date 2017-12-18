/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data.Business
 * 类名称：BUS_RecordData
 * 创建时间：2017-02-21 18:32:55
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

namespace Dos.ORM.Data.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class BUS_RecordData : DBBase<BUS_Record>, IBUS_RecordData
    {
        #region 获取记录基本数据

        /// <summary>
        /// 获取记录列表
        /// </summary>
        /// <returns></returns>
        public OperateModel GetList()
        {
            return new OperateModel
            {
                Result = OperateRetType.Success,
                Msg = "操作成功！",
                Data = GetModels()
            };
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
                    var model = GetModel(m => m.RecordID == id);
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

        #region 记录数据同步
        private static readonly object ObjBusRecord = new object();
        /// <summary>
        /// 同步记录数据
        /// </summary>
        /// <param name="modelList">传入的list</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns>结果对象</returns>
        public OperateModel AddModelList(IList<BUS_Record> modelList, Guid projectId, string timeStamp)
        {
            OperateModel resultInfo = new OperateModel();
            modelList = modelList.GroupBy(x => x.RecordID).Select(x => x.FirstOrDefault()).ToList();//去重复
            lock (ObjBusRecord)
            {
                using (DbTrans trans = DB.DbCont.BeginTransaction())
                {
                    var proIds = modelList.Select(m => m.RecordID).ToList();
                    var testerExit = GetModels(m => m.RecordID.In(proIds));
                    try
                    {
                        if (testerExit != null && testerExit.Count > 0)
                        {
                            var testerExitNew = new List<BUS_Record>();
                            foreach (var item in testerExit)
                            {
                                var newItem = modelList.FirstOrDefault(m => m.RecordID == item.RecordID);
                                if (newItem != null)
                                {
                                    newItem.ID = item.ID;
                                    testerExitNew.Add(newItem);
                                }
                            }
                            UpdateModels(testerExitNew, trans);
                            var nonList = modelList.Except(testerExitNew).ToList();
                            if (nonList.Count > 0)
                            {
                                InsertModels(nonList, trans);
                            }
                        }
                        else
                        {
                            InsertModels(modelList.ToList(), trans);
                        }

                        if (API_SyncLogData.AddApiLog(projectId, timeStamp, "BUS_Record"))
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
                        API_SyncLogData.AddApiLog(projectId, timeStamp, "BUS_Record", false);
                        resultInfo.Msg = ex.ToString();
                        return resultInfo;
                    }
                }
            }
        }

        #endregion
    }
}
