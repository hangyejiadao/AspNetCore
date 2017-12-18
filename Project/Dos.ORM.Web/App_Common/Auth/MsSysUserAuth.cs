/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2015-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：QUBER.Web.App_Common.Auth
 * 类名称：MsUserAuth
 * 创建时间：2015-11-25 15:50:30
 * 创建人：Quber
 * 创建说明：管理员相关信息管理
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using Dos.ORM.Common.Helpers;
using Dos.ORM.Model.Base;

namespace Dos.ORM.Web.App_Common.Auth
{
    /// <summary>
    /// 
    /// </summary>
    public class MsSysUserAuth
    {
        /// <summary>
        /// 存储管理员相关信息
        /// </summary>
        /// <param name="msUser">用户相关信息</param>
        public static void Set(MsSysUserModel msUser)
        {
            SessionHelper.Set("MS_SYS_USER", msUser);
        }

        /// <summary>
        /// 获取管理员相关信息
        /// </summary>
        /// <returns></returns>
        public static MsSysUserModel Get()
        {
            var msUser = SessionHelper.Get("MS_SYS_USER") as MsSysUserModel;
            return msUser;
        }

        /// <summary>
        /// 清除管理员相关信息
        /// </summary>
        public static void Clear()
        {
            if (SessionHelper.Get("MS_SYS_USER") != null)
            {
                SessionHelper.Delete("MS_SYS_USER");
            }
            if (SessionHelper.Get("SCREEN_ISLOCK") != null)
            {
                SessionHelper.Delete("SCREEN_ISLOCK");
            }
        }
    }
}