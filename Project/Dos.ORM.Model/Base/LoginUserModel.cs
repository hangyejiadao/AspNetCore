/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2015-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：QUBER.Model.BusinessModel
 * 类名称：MsUserModel
 * 创建时间：2015-11-25 14:54:43
 * 创建人：Quber
 * 创建说明：用户相关信息实体（用于保存用户登录后的相关信息）
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using Dos.ORM.Model.System;
using Dos.ORM.Model.Business;

namespace Dos.ORM.Model.Base
{
    /// <summary>
    /// 用户相关信息实体（用于保存用户登录后的相关信息）
    /// </summary>
    public class LoginUserModel
    {
        /// <summary>
        /// 登录用户信息
        /// </summary>
        public BUS_User User { get; set; }

        /// <summary>
        /// 角色信息
        /// </summary>

        public BUS_Role Role { get; set; }    
        /// <summary>
        /// 角色信息
        /// </summary>
            
        public BUS_UserRole UserRole { get; set; }      

        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin
        {
            get { 
                return Role.RoleName == "管理员"; 
            }
        }


        private bool _IsEnableLog = true;
        /// <summary>
        /// 是否启用记录日志
        /// </summary>
        public bool IsEnableLog
        {
            get { return _IsEnableLog; }
            set { _IsEnableLog = value; }
        }


    }
}
