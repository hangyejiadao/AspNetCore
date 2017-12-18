/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Web.App_Start
 * 类名称：TinyMapperConfig
 * 创建时间：2016-08-18 15:58:00
 * 创建人：Quber
 * 创建说明：注册实体映射配置关系
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Model.Base;
using Dos.ORM.Model.System;

namespace Dos.ORM.WebPC
{
    /// <summary>
    /// 注册实体映射配置关系
    /// </summary>
    public static class AutoMapperConfig
    {
        public static void InitConfig()
        {
            //SYS_Module to ZTreeModel
            AutoMapperHelper.CreateMapTo<SYS_Module, ZTreeModel>()
                .ConstructUsing(s => new ZTreeModel
                {
                    id = s.ModuleId,
                    pId = s.ParentId ?? Guid.Empty,
                    name = s.ModuleName,
                    src = s.ModulePath,
                    iconName = s.IconName,
                    icon = s.IconPath,
                    open = s.IsExpand == 1
                });

            //v_SYS_Module to ZTreeModel
            AutoMapperHelper.CreateMapTo<v_SYS_Module, ZTreeModel>()
                .ConstructUsing(s => new ZTreeModel
                {
                    id = s.ModuleId,
                    pId = s.ParentId ?? Guid.Empty,
                    name = s.ModuleName,
                    src = s.ModulePath,
                    iconName = s.IconName,
                    icon = s.IconPath,
                    open = s.IsExpand == 1
                });

            //SYS_Button to ZTreeModel
            AutoMapperHelper.CreateMapTo<SYS_Button, ZTreeModel>()
                .ConstructUsing(s => new ZTreeModel
                {
                    id = s.ButtonId,
                    pId = s.ButtonType,
                    name = s.ButtonName,
                    icon = s.IconPath
                });
        }
    }
}