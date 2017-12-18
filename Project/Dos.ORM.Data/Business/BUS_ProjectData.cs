/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data.BusinessBusiness
 * 类名称：BUS_ProjectData
 * 创建时间：2017-02-09 15:42:10
 * 创建人：CDKX-ZC-2015051
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Data.Base;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.Business;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dos.ORM.Data.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class BUS_ProjectData : DBBase<BUS_Project>, IBUS_ProjectData
    {
        #region 获取项目基本数据

        /// <summary>
        /// 获取项目列表
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
                    var model = GetModel(m => m.ProjectID == id);
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

        #region 项目数据同步
        private static readonly object ObjBusProject = new object();
        /// <summary>
        /// 同步项目数据
        /// </summary>
        /// <param name="modelList">传入的list</param>
        /// <param name="projectId">项目Id</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns>结果对象</returns>
        public OperateModel AddModelList(IList<BUS_Project> modelList, Guid projectId, string timeStamp)
        {
            OperateModel resultInfo = new OperateModel();

            lock (ObjBusProject)
            {
                using (DbTrans trans = DB.DbCont.BeginTransaction())
                {
                    try
                    {
                        var proIds = modelList.Select(m => m.ProjectID).ToList();
                        var testerExit = GetModels(m => m.ProjectID.In(proIds));

                        if (testerExit != null && testerExit.Count > 0)
                        {
                            var testerExitNew = new List<BUS_Project>();

                            foreach (var item in testerExit)
                            {
                                var newItem = modelList.FirstOrDefault(m => m.ProjectID == item.ProjectID);
                                if (newItem != null)
                                {
                                    newItem.ID = item.ID;
                                    testerExitNew.Add(newItem);
                                }
                            }
                            UpdateModels(testerExitNew, trans);

                            var testerNon = proIds.Except(testerExit.Select(m => m.ProjectID)).ToList();
                            if (testerNon.Count > 0)
                            {
                                var nonList = (from a in modelList
                                               join b in testerNon on a.ProjectID equals b
                                               select a).ToList();
                                InsertModels(nonList, trans);
                            }
                        }
                        else
                        {
                            InsertModels(modelList.ToList(), trans);
                        }

                        if (API_SyncLogData.AddApiLog(projectId, timeStamp, "BUS_Project"))
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
                        API_SyncLogData.AddApiLog(projectId, timeStamp, "BUS_Project", false);
                        return resultInfo;
                    }
                }
            }
        }

        /// <summary>
        /// 批量增加测试人员数据
        /// </summary>
        /// <param name="modelList">传入的list</param>
        /// <param name="timeStamp">最大时间戳</param>
        /// <returns>结果对象</returns>
        public OperateModel AddModelList1(IList<BUS_Project> modelList, string timeStamp)
        {
            OperateModel resultInfo = new OperateModel();

            using (DbTrans trans = DB.DbCont.BeginTransaction())
            {
                try
                {
                    if (modelList.Count > 0 && !string.IsNullOrEmpty(timeStamp))
                    {
                        foreach (var lt1 in modelList)
                        {
                            var lt = lt1;
                            var tester = GetModel(m => m.ProjectID == lt.ProjectID);

                            if (tester == null)
                            {
                                tester = lt;
                                InsertModel(tester);
                            }
                            else
                            {
                                lt.ID = tester.ID;
                                tester = lt;
                                UpdateModel(tester, m => m.ProjectID == lt.ProjectID);
                            }
                        }

                        if (API_SyncLogData.AddApiLog(timeStamp, "BUS_Project"))
                        {
                            resultInfo.Result = OperateRetType.Success;
                            resultInfo.Msg = "操作成功";
                            resultInfo.Data = true;
                        }

                        trans.Commit();
                    }

                    return resultInfo;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    API_SyncLogData.AddApiLog(timeStamp, "BUS_Project", false);
                    return resultInfo;
                }
            }
        }

        #endregion

        #region 获取ZTreeModel
        [Ninject.Inject]
        private IBUS_LaboratoryData BusLab { get; set; }
        [Ninject.Inject]
        private IBUS_UserLaboratoryData BusUserLab { get; set; }
        [Ninject.Inject]
        private IBUS_ProjectLaboratoryData BusProjLab { get; set; }

        /// <summary>
        /// 获取用户管理所需项目和试验室
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="projName"></param>
        /// <param name="selectedIds"></param>
        /// <param name="isInit"></param>
        /// <returns></returns>
        public List<ZTreeModel> GetModulesForUser(Guid userId, string projName, string selectedIds, bool isInit)
        {
            var expProj = ExpHelper.Create<BUS_Project>(p => p.IsEnable == true);
            if (!string.IsNullOrWhiteSpace(projName))
                expProj = expProj.And(p => p.ProjectName.Contains(projName));
            var modelProj = this.GetModels(expProj);
            List<ZTreeModel> ztreeList = new List<ZTreeModel>();
            foreach (var item in modelProj)
            {
                ztreeList.Add(new ZTreeModel
                {
                    id = item.ProjectID,
                    pId = null,
                    isParent = true,
                    name = item.ProjectName,
                    open = false,
                    chkDisabled = false,
                    @checked = isInit && this.BusUserLab.GetModel(p => p.AccountID == userId && p.TargetId == item.ProjectID) != null || !isInit && selectedIds.Split(',').FirstOrDefault(p => p == item.ProjectID.ToString()) != null
                });
            }

            var expLab = ExpHelper.Create<BUS_Laboratory>(null);
            var modelLab = this.BusLab.GetModels(expLab).OrderBy(p => p.OrderNum).ThenBy(p => p.OrganShorName).ThenBy(p => p.OrganName).ToList();
            foreach (var item in modelLab)
            {
                var labProj = this.BusProjLab.GetModel(p => p.OrganID == item.OrganID);
                if (labProj != null && modelProj.FirstOrDefault(p => p.ProjectID == labProj.ProjectID) != null)
                {
                    ztreeList.Add(new ZTreeModel
                    {
                        id = item.OrganID,
                        pId = labProj.ProjectID,
                        isParent = false,
                        name = item.OrganShorName ?? item.OrganName,
                        open = false,
                        chkDisabled = false,
                        @checked = isInit && this.BusUserLab.GetModel(p => p.AccountID == userId && p.TargetId == item.OrganID) != null || !isInit && selectedIds.Split(',').FirstOrDefault(p => p == item.OrganID.ToString()) != null
                    });
                }
            }

            return ztreeList;
        }


        /// <summary>
        /// 获取用户管理中已选择项目和试验室
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<ZTreeModel> GetModulesSelectedForUser(Guid userId)
        {
            List<ZTreeModel> ztreeList = new List<ZTreeModel>();
            var userLab = this.BusUserLab.GetModels(p => p.AccountID == userId);

            var userLabLab = userLab.Where(p => p.ParentId != null);
            var userLabProj = userLab.Where(p => p.ParentId == null);

            List<BUS_Project> listProj = new List<BUS_Project>();
            foreach (var item in userLabProj)
            {
                var proj = this.GetModel(p => p.ProjectID == item.TargetId);
                if (proj.IsEnable != null && (bool)proj.IsEnable)
                    listProj.Add(proj);
            }
            List<BUS_Laboratory> listLab = new List<BUS_Laboratory>();
            foreach (var item in userLabLab)
            {
                var lab = this.BusLab.GetModel(p => p.OrganID == item.TargetId);
                var proj = this.GetModel(p => p.ProjectID == item.ParentId);
                if (proj.IsEnable != null && (bool)proj.IsEnable)
                    listLab.Add(lab);
            }
            listLab = listLab.OrderBy(p => p.OrderNum).ThenBy(p => p.OrganShorName).ThenBy(p => p.OrganName).ToList();

            foreach (var item in listProj)
            {
                ztreeList.Add(new ZTreeModel
                {
                    id = item.ProjectID,
                    pId = null,
                    isParent = true,
                    name = item.ProjectName,
                    open = true,
                    chkDisabled = true,
                    @checked = true
                });
            }
            foreach (var item in listLab)
            {
                var projlab = this.BusProjLab.GetModel(p => p.OrganID == item.OrganID);

                ztreeList.Add(new ZTreeModel
                {
                    id = item.OrganID,
                    pId = projlab.ProjectID,
                    isParent = false,
                    name = item.OrganShorName ?? item.OrganName,
                    open = true,
                    chkDisabled = true,
                    @checked = true
                });
            }

            //foreach (var item in userLab)
            //{
            //    BUS_Project proj;
            //    if (item.ParentId == null)
            //    {
            //        proj = this.GetModel(p => p.ProjectID == item.TargetId);
            //        item.TargetName = proj.ProjectName;
            //    }
            //    else
            //    {
            //        var lab = this.BusLab.GetModel(p => p.OrganID == item.TargetId);
            //        proj = this.GetModel(p => p.ProjectID == item.ParentId);
            //        item.TargetName = lab.OrganShorName ?? lab.OrganName;
            //    }
            //    if (proj.IsEnable != null && (bool)proj.IsEnable)
            //    {
            //        ztreeList.Add(new ZTreeModel
            //        {
            //            id = item.TargetId,
            //            pId = item.ParentId,
            //            isParent = item.ParentId == null,
            //            name = item.TargetName,
            //            open = true,
            //            chkDisabled = true,
            //            @checked = true
            //        });
            //    }
            //}

            return ztreeList;
        }

        /// <summary>
        /// 根据ID获取用户管理中的项目和试验室
        /// </summary>
        /// <param name="newIds"></param>
        /// <returns></returns>
        public List<ZTreeModel> GetModulesForUserFromID(string newIds)
        {
            List<ZTreeModel> ztreeList = new List<ZTreeModel>();
            if (string.IsNullOrWhiteSpace(newIds))
                return ztreeList;
            else
            {
                newIds = newIds.TrimEnd(',');
                newIds = newIds.TrimStart(',');
            }

            foreach (var item in newIds.Split(','))
            {
                var proj = this.GetModel(p => p.ProjectID == Guid.Parse(item));
                if (proj != null)
                {
                    ztreeList.Add(new ZTreeModel
                    {
                        id = proj.ProjectID,
                        pId = null,
                        isParent = true,
                        name = proj.ProjectName,
                        open = true,
                        chkDisabled = true,
                        @checked = true
                    });
                }
                else
                {
                    var lab = this.BusLab.GetModel(p => p.OrganID == Guid.Parse(item));
                    var labProj = this.BusProjLab.GetModel(p => p.OrganID == Guid.Parse(item));
                    ztreeList.Add(new ZTreeModel
                    {
                        id = lab.OrganID,
                        pId = labProj.ProjectID,
                        isParent = false,
                        name = lab.OrganShorName ?? lab.OrganName,
                        open = true,
                        chkDisabled = true,
                        @checked = true
                    });
                }
            }
            return ztreeList;
        }

        #endregion

    }

    #region 菜单项目

    /// <summary>
    /// 项目实验室菜单
    /// </summary>
    public class MenuItem
    {
        public Guid Id { get; set; }
        public Guid PId { get; set; }
        public bool IsParent { get; set; }
        public IList<MenuItem> LabList { get; set; }

        public string MenuName { get; set; }
        public string IconName { get; set; }

        //        #region  获取项目实验室菜单

        //        /// <summary>
        //        /// 获取帐号下项目实验室目录
        //        /// </summary>
        //        /// <param name="accountId">帐号Id</param>
        //        /// <returns>结果对象</returns>
        //        public OperateModel GetMenu(string accountId)
        //        {
        //            OperateModel resultInfo = new OperateModel();

        //            BUS_UserRelationData userRelationDal = new BUS_UserRelationData();
        //            BUS_ProjectLaboratoryData proLab = new BUS_ProjectLaboratoryData();
        //            BUS_LaboratoryData labDal = new BUS_LaboratoryData();

        //            try
        //            {
        //                Guid accid;
        //                if (!string.IsNullOrEmpty(accountId) && Guid.TryParse(accountId, out accid))
        //                {
        //                    IList<MenuItem> menuList;

        //                    var strSql = @"SELECT * FROM BUS_UserRelation A WHERE A.Type='2' AND A.AccountID='{0}'";
        //                    var valList = userRelationDal.GetModelsSql(string.Format(strSql, accid));

        //                    if (valList != null && valList.Count > 0)
        //                    {
        //                        var strLabSql = @"SELECT DISTINCT C.ProjectID,C.ProjectName FROM BUS_UserRelation A 
        //	                                    INNER JOIN BUS_ProjectLaboratory B ON A.TargetId=B.OrganID 
        //	                                    INNER JOIN BUS_Project C ON B.ProjectID=C.ProjectID 
        //	                                    INNER JOIN BUS_Laboratory D ON B.OrganID=D.OrganID WHERE A.Type='2' AND A.AccountID='{0}'";

        //                        var proList = GetModelsSql(string.Format(strLabSql, accid)).Distinct();

        //                        menuList = (from a in proList
        //                                    select new MenuItem
        //                                    {
        //                                        Id = a.ProjectID ?? Guid.Empty,
        //                                        IsParent = true,
        //                                        MenuName = a.ProjectName,
        //                                        LabList = (from b in valList
        //                                                   join c in proLab.GetModels() on b.TargetId equals c.OrganID
        //                                                   join d in labDal.GetModels() on c.OrganID equals d.OrganID
        //                                                   where a.ProjectID == c.ProjectID
        //                                                   select new MenuItem
        //                                                   {
        //                                                       Id = c.OrganID ?? Guid.Empty,
        //                                                       IsParent = false,
        //                                                       MenuName = d.OrganName
        //                                                   }).ToList()
        //                                    }).ToList();

        //                    }
        //                    else
        //                    {
        //                        menuList = (from a in userRelationDal.GetModels()
        //                                    join b in GetModels() on a.TargetId equals b.ProjectID
        //                                    select new MenuItem
        //                                    {
        //                                        Id = b.ProjectID ?? Guid.Empty,
        //                                        IsParent = true,
        //                                        MenuName = b.ProjectName,
        //                                        LabList = (from c in labDal.GetModels()
        //                                                   join d in proLab.GetModels() on c.OrganID equals d.OrganID
        //                                                   where a.TargetId == d.OrganID
        //                                                   select new MenuItem
        //                                                   {
        //                                                       Id = c.OrganID ?? Guid.Empty,
        //                                                       IsParent = false,
        //                                                       MenuName = c.OrganName
        //                                                   }).ToList()
        //                                    }).ToList();
        //                    }

        //                    resultInfo.Result = OperateRetType.Success;
        //                    resultInfo.Msg = "操作成功！";
        //                    resultInfo.Data = menuList;
        //                }

        //                return resultInfo;
        //            }
        //            catch (Exception ex)
        //            {
        //                return resultInfo;
        //            }
        //        }

        //        /// <summary>
        //        /// 获取帐号下项目实验室目录
        //        /// </summary>
        //        /// <param name="accountId">帐号Id</param>
        //        /// <returns>结果对象</returns>
        //        public OperateModel GetMenu1(string accountId)
        //        {
        //            OperateModel resultInfo = new OperateModel();

        //            try
        //            {
        //                var select1 = DB.DbCont.From<BUS_UserRelation>()
        //                        .InnerJoin<BUS_ProjectLaboratory>(BUS_UserRelation._.TargetId == BUS_ProjectLaboratory._.OrganID)
        //                        .InnerJoin<BUS_Project>(BUS_ProjectLaboratory._.ProjectID == BUS_Project._.ProjectID).Distinct()
        //                        .Select(BUS_BannerInfo._.All, BUS_BannerType._.BannerTypeName).ToList();
        //                return resultInfo;
        //            }
        //            catch (Exception ex)
        //            {
        //                return resultInfo;
        //            }
        //        }

        //        #endregion
    }

    #endregion


}
