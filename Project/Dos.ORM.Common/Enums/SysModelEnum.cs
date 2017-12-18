/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Common.Enums
 * 类名称：SysModelEnum
 * 创建时间：2016-06-14 15:07:04
 * 创建人：Quber
 * 创建说明：实体类所使用的枚举类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using Dos.ORM.Common.Helpers;

namespace Dos.ORM.Common.Enums
{
    /// <summary>
    /// 状态类型
    /// </summary>
    public enum StatusType
    {
        /// <summary>
        /// 是/True：1
        /// </summary>
        [EnumTitle("是")]
        Yes = 1,
        /// <summary>
        /// 否/False：0
        /// </summary>
        [EnumTitle("否")]
        No = 0
    }

    /// <summary>
    /// 数据操作结果类型
    /// </summary>
    public enum OperateRetType
    {
        /// <summary>
        /// 操作成功：100
        /// </summary>
        [EnumTitle("操作成功")]
        Success = 100,
        /// <summary>
        /// 操作失败：120
        /// </summary>
        [EnumTitle("操作失败")]
        Fail = 120,
        /// <summary>
        /// 操作异常：140
        /// </summary>
        [EnumTitle("操作异常")]
        Exception = 140,

        /// <summary>
        /// 登录成功：300
        /// </summary>
        [EnumTitle("登录成功")]
        LoginInSuccess = 300,
        /// <summary>
        /// 登录失败：320
        /// </summary>
        [EnumTitle("登录失败")]
        LoginInFail = 320,
        /// <summary>
        /// 登录过期：340
        /// </summary>
        [EnumTitle("登录过期")]
        LoginTimeout = 340,
        /// <summary>
        /// 登出成功：360
        /// </summary>
        [EnumTitle("退出成功")]
        LoginOutSuccess = 360,
        /// <summary>
        /// 登出失败：360
        /// </summary>
        [EnumTitle("退出失败")]
        LoginOutFail = 380
    }
}
