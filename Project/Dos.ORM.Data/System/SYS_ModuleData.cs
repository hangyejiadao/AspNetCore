/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data.System
 * 类名称：SYS_ModuleData
 * 创建时间：2016-08-14 14:52:59
 * 创建人：QUBER-PC
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Data.Base;
using Dos.ORM.IData.System;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.System;

namespace Dos.ORM.Data.System
{
    /// <summary>
    /// 
    /// </summary>
    public class SYS_ModuleData : DBBase<SYS_Module>, ISYS_ModuleData
    {
        /// <summary>
        /// 获取模块管理所需模块
        /// </summary>
        /// <param name="moduleType"></param>
        /// <param name="moduleId"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<ZTreeModel> GetModulesForModule(int moduleType, Guid moduleId, Guid parentId)
        {
            var exp = ExpHelper.Create<SYS_Module>(c => c.Status == 1);
            if (moduleType > 0) exp = exp.And(m => m.ModuleType == moduleType);

            var oldModuleList = GetModels(exp).ToModelList<SYS_Module, ZTreeModel>();
            var newModuleList = oldModuleList.Select(item => new ZTreeModel
            {
                id = item.id,
                pId = item.pId,
                name = item.name,
                icon = item.icon,
                src = item.src,
                open = false,// item.open,
                nocheck = item.nocheck,
                chkDisabled = moduleId == (Guid)item.id || item.chkDisabled,
                @checked = parentId == (Guid)item.id || item.@checked,
                halfCheck = item.halfCheck
            }).ToList();

            //增加主节点
            var mainNode = new ZTreeModel
            {
                id = Guid.Empty,
                //pId = s.ParentId,
                name = "所有模块",
                //src = s.ModulePath,
                open = true,
                @checked = parentId == Guid.Empty
            };
            if (newModuleList.Count >= 0)
            {
                newModuleList.Add(mainNode);
            }
            return newModuleList;
        }

        /// <summary>
        /// 获取角色管理所需模块
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="moduleType"></param>
        /// <param name="roleModuleList"></param>
        /// <returns></returns>
        public List<ZTreeModel> GetModulesForRole(int moduleType, Guid roleId, List<SYS_RoleModuleRelation> roleModuleList)
        {
            var exp = ExpHelper.Create<SYS_Module>(c => c.Status == 1);
            if (moduleType > 0) exp = exp.And(m => m.ModuleType == moduleType);

            var oldModuleList = GetModels(exp).ToModelList<SYS_Module, ZTreeModel>();
            var newModuleList = oldModuleList.Select(item => new ZTreeModel
            {
                id = item.id,
                pId = item.pId,
                name = item.name,
                icon = item.icon,
                src = item.src,
                open = false,// item.open,
                nocheck = item.nocheck,
                chkDisabled = false,
                @checked = roleModuleList.Any(rm => rm.RoleId == roleId && rm.ModuleId == (Guid)item.id),
                halfCheck = item.halfCheck
            }).ToList();

            //增加主节点
            var mainNode = new ZTreeModel
            {
                id = Guid.Empty,
                //pId = s.ParentId,
                name = "所有模块",
                //src = s.ModulePath,
                open = true,
                @checked = false
            };
            if (newModuleList.Count >= 0)
            {
                newModuleList.Add(mainNode);
            }
            return newModuleList;
        }
    }
}
