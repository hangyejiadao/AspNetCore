/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data.BusinessBusiness
 * 类名称：BUS_ProjectLaboratoryData
 * 创建时间：2017-02-09 15:42:10
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
    public class BUS_ProjectLaboratoryData : DBBase<BUS_ProjectLaboratory>, IBUS_ProjectLaboratoryData
    {
        #region 项目实验室关系数据同步
        private static readonly object ObjBusProjectLaboratory = new object();
        /// <summary>
        /// 项目实验室关系数据同步
        /// </summary>
        /// <param name="modelList">传入的list</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns>结果对象</returns>
        public OperateModel AddModelList(IList<BUS_ProjectLaboratory> modelList, Guid projectId, string timeStamp)
        {
            OperateModel resultInfo = new OperateModel();

            lock (ObjBusProjectLaboratory)
            {
                using (DbTrans trans = DB.DbCont.BeginTransaction())
                {
                    try
                    {
                        var proIds = modelList.Select(m => new {m.OrganID, m.ProjectID}).ToList();
                        //var testerExit = GetModels(m => new {m.OrganID, m.ProjectID}.In(proIds));
                        //var testerExit = GetModels().Select(m => new {m.ID, m.OrganID,m.ProjectID }).Where(m=>new{m.OrganID,m.ProjectID}.In(proIds)).ToList();


                        var testerExit = (from a in GetModels()
                            join b in proIds on new {a.OrganID, a.ProjectID} equals new {b.OrganID, b.ProjectID}
                            select a).ToList();

                        if (testerExit.Count > 0)
                        {
                            var testerExitNew = new List<BUS_ProjectLaboratory>();

                            foreach (var item in testerExit)
                            {
                                var newItem =
                                    modelList.FirstOrDefault(
                                        m => (m.OrganID == item.OrganID && m.ProjectID == item.ProjectID));
                                if (newItem != null)
                                {
                                    newItem.ID = item.ID;
                                    testerExitNew.Add(newItem);
                                }
                            }
                            UpdateModels(testerExitNew, trans);

                            var testerNon = proIds.Except(testerExit.Select(m => new {m.OrganID, m.ProjectID})).ToList();
                            if (testerNon.Count > 0)
                            {
                                var nonList = (from a in modelList
                                    join b in testerNon on new {a.OrganID, a.ProjectID} equals
                                        new {b.OrganID, b.ProjectID}
                                    select a).ToList();
                                InsertModels(nonList, trans);
                            }
                        }
                        else
                        {
                            InsertModels(modelList.ToList(), trans);
                        }

                        if (API_SyncLogData.AddApiLog(projectId, timeStamp, "BUS_ProjectLaboratory"))
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
                        API_SyncLogData.AddApiLog(projectId, timeStamp, "BUS_ProjectLaboratory", false);
                        return resultInfo;
                    }
                }
            }
        }

        #endregion
    }
}
