/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Base
 * 类名称：ComponentsModel
 * 创建时间：2016-06-14 16:59:24
 * 创建人：Quber
 * 创建说明：Web组件所需实体
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System.Collections.Generic;

namespace Dos.ORM.Model.Base
{
    #region zTree所需实体
    /// <summary>
    /// zTree实体
    /// </summary>
    public class ZTreeModel
    {
        /// <summary>
        /// 节点Id
        /// </summary>
        public object id { get; set; }
        /// <summary>
        /// 父节点Id
        /// </summary>
        public object pId { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 图标路径（最好使用绝对路径）
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// 图标名称
        /// </summary>
        public string iconName { get; set; }
        /// <summary>
        /// 操作页面地址
        /// </summary>
        public string src { get; set; }
        /// <summary>
        /// 节点展开或折叠状态（true：展开，false：折叠）
        /// </summary>
        public bool open { get; set; }
        /// <summary>
        /// 设置节点是否隐藏checkbox或radio（注：setting.check.enable = true 时有效）
        /// </summary>
        public bool nocheck { get; set; }
        /// <summary>
        /// 设置checkbox或radio是否为禁用状态（true：禁用，false启用）
        /// </summary>
        public bool chkDisabled { get; set; }
        /// <summary>
        /// 设置checkbox或radio为勾选状态（true：勾选中，false未勾选）
        /// </summary>
        public bool @checked { get; set; }
        /// <summary>
        /// 强制节点的checkbox或radio的半勾选状态（setting.check.enable = true & treeNode.nocheck = false 时有效）
        ///     true 表示节点的输入框 强行设置为半勾选
        ///     false 表示节点的输入框 根据 zTree 的规则自动计算半勾选状态
        /// </summary>
        public bool halfCheck { get; set; }
        /// <summary>
        /// 是否为父节点
        /// </summary>
        public bool isParent { get; set; }
    }

    /// <summary>
    /// ZTreeModel子父实体
    /// </summary>
    public class ZTreeModelRelation : ZTreeModel
    {
        public List<ZTreeModel> Sons { get; set; }
    }
    #endregion

    #region EasyUI所需实体
    /// <summary>
    /// EasyUI combobox所需数据实体
    /// </summary>
    public class Combobox
    {
        /// <summary>
        /// 值
        /// </summary>
        public object id { get; set; }
        /// <summary>
        /// 文本
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool selected { get; set; }
    }

    #region combotree所需实体
    /// <summary>
    /// combotree所需实体
    /// </summary>
    public class ComboTree
    {
        /// <summary>
        /// 值
        /// </summary>
        public object id { get; set; }
        /// <summary>
        /// 文本
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string iconCls { get; set; }

        //open：展开，closed：折叠
        private string _state = "open";
        /// <summary>
        /// 展开或折叠（当为closed时，点击展开节点时，会传递当前节点id数据到服务端，方便获取该节点下的子节点数据）
        /// </summary>
        public string state
        {
            get { return _state; }
            set { _state = value; }
        }
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool @checked { get; set; }
        /// <summary>
        /// 被添加到节点的自定义属性
        /// </summary>
        public object attributes { get; set; }

        /// <summary>
        /// 子项
        /// </summary>
        public List<ComboTree> children { get; set; }
    }

    public class ComboTreeSon
    {
        /// <summary>
        /// 值
        /// </summary>
        public object id { get; set; }
        /// <summary>
        /// 文本
        /// </summary>
        public string text { get; set; }

        private string _state = "open";
        /// <summary>
        /// 是否选中
        /// </summary>
        public string state
        {
            get { return _state; }
            set { _state = value; }
        }
    }
    #endregion

    /// <summary>
    /// EasyUI Datagrid查询条件实体
    /// </summary>
    public class DgConModel : DgOrderModel
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        private int _page = 1;
        /// <summary>
        /// 当前页码（默认为1）
        /// </summary>
        public int page
        {
            get { return _page; }
            set { _page = value; }
        }

        /// <summary>
        /// 当前页数量
        /// </summary>
        private int _rows = 15;
        /// <summary>
        /// 当前页数量（默认为15）
        /// </summary>
        public int rows
        {
            get { return _rows; }
            set { _rows = value; }
        }

        ///// <summary>
        ///// 排序字段
        ///// </summary>
        //private string _sort = "CrtTime";
        ///// <summary>
        ///// 排序字段（默认为CrtTime）
        ///// </summary>
        //public string sort
        //{
        //    get { return _sort; }
        //    set { _sort = value; }
        //}

        ///// <summary>
        ///// 排序方式（asc：升序，desc：降序）
        ///// </summary>
        //public string _order = "desc";
        ///// <summary>
        ///// 排序方式（默认为desc）
        ///// </summary>
        //public string order
        //{
        //    get { return _order; }
        //    set { _order = value; }
        //}
    }

    /// <summary>
    /// EasyUI Datagrid所需排序实体
    /// </summary>
    public class DgOrderModel
    {
        /// <summary>
        /// 是否触发了点击列排序
        /// </summary>
        private bool _isSortCol = false;
        /// <summary>
        /// 是否触发了点击列排序
        /// </summary>
        public bool isSortCol
        {
            get { return _isSortCol; }
            set { _isSortCol = value; }
        }

        /// <summary>
        /// 排序字段
        /// </summary>
        //private string _sort = "CrtTime";
        private string _sort;
        /// <summary>
        /// 排序字段
        /// </summary>
        public string sort
        {
            get { return _sort; }
            set { _sort = value; }
        }

        /// <summary>
        /// 排序方式（asc：升序，desc：降序）
        /// </summary>
        public string _order = "desc";
        /// <summary>
        /// 排序方式（默认为desc）
        /// </summary>
        public string order
        {
            get { return _order; }
            set { _order = value; }
        }
    }

    /// <summary>
    /// EasyUI Datagrid返回结果实体
    /// </summary>
    public class DgListModel<T> where T : class
    {
        /// <summary>
        /// 数据集List
        /// </summary>
        public List<T> rows { get; set; }

        /// <summary>
        /// 表格尾部数据集List
        /// </summary>
        public List<T> footer { get; set; }

        /// <summary>
        /// 数据总条数
        /// </summary>
        public int total { get; set; }

        public DgListModel(List<T> rowList, int rowCount, List<T> rowFooterList = null)
        {
            rows = rowList;
            total = rowCount;
            footer = rowFooterList;
        }
    }

    /// <summary>
    /// EasyUI Datagrid返回结果实体
    /// </summary>
    public class DgListModel
    {
        /// <summary>
        /// 数据集object（如List或DataTable）
        /// </summary>
        public object rows { get; set; }

        /// <summary>
        /// 表格尾部数据集object（如List或DataTable）
        /// </summary>
        public object footer { get; set; }

        /// <summary>
        /// 数据总条数
        /// </summary>
        public int total { get; set; }

        public DgListModel(object rowObj, int rowCount, object rowFooterObj = null)
        {
            rows = rowObj;
            total = rowCount;
            footer = rowFooterObj;
        }
    }
    #endregion
}
