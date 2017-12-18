/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Common.Enums
 * 类名称：SysEnum
 * 创建时间：2016-08-18 16:15:26
 * 创建人：Quber
 * 创建说明：系统所需要的枚举类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using Dos.ORM.Common.Helpers;

namespace Dos.ORM.Common.Enums
{
    /// <summary>
    /// 框架类型
    /// </summary>
    public enum FrameworkType
    {
        /// <summary>
        /// EasyUI框架：1
        /// </summary>
        [EnumTitle("EasyUI框架")]
        EasyUI = 1,
        /// <summary>
        /// AngularJS框架：2
        /// </summary>
        [EnumTitle("AngularJS框架")]
        AngularJS = 2,
        /// <summary>
        /// 原生框架：3
        /// </summary>
        [EnumTitle("原生框架")]
        Original = 3
    }

    /// <summary>
    /// 模块类型
    /// </summary>
    public enum ModuleType
    {
        /// <summary>
        /// 系统：100
        /// </summary>
        [EnumTitle("系统")]
        System = 100,
        /// <summary>
        /// 业务：101
        /// </summary>
        [EnumTitle("业务")]
        Business = 101,
        /// <summary>
        /// 其他：102
        /// </summary>
        [EnumTitle("其他")]
        Other = 102
    }

    /// <summary>
    /// 管理员类型
    /// </summary>
    public enum OperatorType
    {
        /// <summary>
        /// 超级管理员：1
        /// </summary>
        [EnumTitle("超级管理员")]
        SuperAdmin = 1,
        /// <summary>
        /// 公司总管理员：2
        /// </summary>
        [EnumTitle("公司总管理员")]
        CompanyAdmin = 2,
        /// <summary>
        /// 公司普通管理员：3
        /// </summary>
        [EnumTitle("公司普通管理员")]
        CompanyOrdinaryAdmin = 3
    }

    /// <summary>
    /// 操作页面类型
    /// </summary>
    public enum OperatePageType
    {
        /// <summary>
        /// 主页面：1
        /// </summary>
        [EnumTitle("主页面")]
        System = 1,
        /// <summary>
        /// 子页面：2
        /// </summary>
        [EnumTitle("子页面")]
        Business = 2
    }

    /// <summary>
    /// 日志类型
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// 登录登出日志：100
        /// </summary>
        [EnumTitle("登录登出")]
        LoginInOut = 100,
        /// <summary>
        /// 数据操作日志:101
        /// </summary>
        [EnumTitle("数据操作")]
        DataOperation = 101,
        /// <summary>
        /// 异常错误日志:102
        /// </summary>
        [EnumTitle("异常错误")]
        ExceptionError = 102,
        /// <summary>
        /// 一般信息日志:103
        /// </summary>
        [EnumTitle("一般信息")]
        General = 103,
        /// <summary>
        /// 其他信息日志:104
        /// </summary>
        [EnumTitle("其他信息")]
        Other = 104
    }

    /// <summary>
    /// 操作按钮类型
    /// </summary>
    public enum OperateBtnType
    {
        /// <summary>
        /// 列表常用：100
        /// </summary>
        [EnumTitle("列表常用")]
        ForList = 100,

        /// <summary>
        /// 编辑常用：200
        /// </summary>
        [EnumTitle("编辑常用")]
        ForEdit = 200,

        /// <summary>
        /// 其他常用：300
        /// </summary>
        [EnumTitle("其他常用")]
        ForOther = 300
    }

    /// <summary>
    /// 操作按钮集合
    /// </summary>
    public enum OperateBtn
    {
        /// <summary>
        /// 添加：1001
        /// </summary>
        [EnumTitle("添加")]
        Add = 1001,
        /// <summary>
        /// 修改:1002
        /// </summary>
        [EnumTitle("修改")]
        Modify = 1002,
        /// <summary>
        /// 查询:1003
        /// </summary>
        [EnumTitle("查询")]
        Search = 1003,
        /// <summary>
        /// 查看:1004
        /// </summary>
        [EnumTitle("查看")]
        View = 1004,
        /// <summary>
        /// 删除:1005
        /// </summary>
        [EnumTitle("删除")]
        Delete = 1005,
        /// <summary>
        /// 保存:1006
        /// </summary>
        [EnumTitle("保存")]
        Save = 1006,
        /// <summary>
        /// 取消:1007
        /// </summary>
        [EnumTitle("取消")]
        Cancel = 1007,
        /// <summary>
        /// 选择（如：选择部门的人员）:1008
        /// </summary>
        [EnumTitle("选择")]
        Select = 1008,

        /// <summary>
        /// 导入:1009
        /// </summary>
        [EnumTitle("导入")]
        Import = 1009,
        /// <summary>
        /// 导出:1010
        /// </summary>
        [EnumTitle("导出")]
        Export = 1010,

        /// <summary>
        /// 备份:1011
        /// </summary>
        [EnumTitle("备份")]
        Backup = 1011,

        /// <summary>
        /// 登录:2001
        /// </summary>
        [EnumTitle("登录")]
        LoginIn = 2001,
        /// <summary>
        /// 登出:2002
        /// </summary>
        [EnumTitle("登出")]
        LoginOut = 2002
    }
}
