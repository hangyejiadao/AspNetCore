/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data.System
 * 类名称：SYS_ButtonData
 * 创建时间：2016-08-14 14:52:58
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
using Dos.ORM.Common.Enums;
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
    public class SYS_ButtonData : DBBase<SYS_Button>, ISYS_ButtonData
    {
        /// <summary>
        /// 获取模块管理所需的所有按钮
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="allBtns"></param>
        /// <param name="moduleButtonList"></param>
        /// <returns></returns>
        public List<ZTreeModel> GetButtonsForModule(Guid moduleId, List<SYS_Button> allBtns, List<SYS_ModuleButtonRelation> moduleButtonList)
        {
            var oldButtonList = allBtns.ToModelList<SYS_Button, ZTreeModel>();
            var newButtonList = oldButtonList.Select(item => new ZTreeModel
            {
                id = item.id,
                pId = item.pId,
                name = item.name,
                icon = item.icon,
                src = item.src,
                open = item.open,
                nocheck = item.nocheck,
                chkDisabled = false,
                @checked = moduleButtonList.Any(rm => rm.ModuleId == moduleId && rm.ButtonId == (Guid)item.id),
                halfCheck = item.halfCheck
            }).ToList();

            //添加按钮类型节点
            var btnTypes = EnumHelper.GetItemValueList<OperateBtnType>();
            newButtonList.AddRange(btnTypes.Select(item => new ZTreeModel
            {
                id = item.Key,
                pId = 0,
                name = item.Value,
                chkDisabled = true,
                open = true
            }));

            //增加主节点
            var mainNode = new ZTreeModel
            {
                id = 0,
                //pId = s.ParentId,
                name = "所有按钮",
                //src = s.ModulePath,
                open = true,
                @checked = false,
                chkDisabled = true
            };
            if (newButtonList.Count >= 0)
            {
                newButtonList.Add(mainNode);
            }
            return newButtonList;
        }
    }
}
