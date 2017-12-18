/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data.BusinessBusiness
 * 类名称：BUS_UserData
 * 创建时间：2017-02-09 15:42:10
 * 创建人：CDKX-ZC-2015051
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using Dos.ORM.Data.Base;
using Dos.ORM.IData.Business;
using Dos.ORM.Model.Business;
using System;
using System.Collections.Generic;
using Dos.ORM.Common.Enums;
using Dos.ORM.Model.Base;

namespace Dos.ORM.Data.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class BUS_UserData : DBBase<BUS_User>, IBUS_UserData
    {
        [Ninject.Inject]
        private IBUS_UserRoleData BusUserRole { get; set; }

        #region 获取人员基本数据
        /// <summary>
        /// 获取人员列表
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
                    var model = GetModel(m => m.ID == id);
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

        /// <summary>
        /// 删除并添加账户角色关系
        /// </summary>
        /// <param name="roleIds"></param>
        /// <param name="accountId"></param>
        /// <param name="trans"></param>
        public void SaveRole(string roleIds, Guid accountId, DbTrans trans = null)
        {
            DeleteModelOther<BUS_UserRole>(m => m.AccountID == accountId);
            if (!string.IsNullOrWhiteSpace(roleIds) && Guid.Parse(roleIds) != Guid.Empty)
            {
                var addDepRe = new BUS_UserRole
                {
                    ID = Guid.NewGuid(),
                    AccountID = accountId,
                    RoleID = Guid.Parse(roleIds)
                };
                this.BusUserRole.InsertModel(addDepRe, trans);
            }
        }
    }
}
