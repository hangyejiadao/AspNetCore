/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BHZ_TableColsSet
 * 创建时间：2017-08-02 17:30:24
 * 创建人：Quber Tool
 * 创建说明：此代码由工具生成，请谨慎修改！
*****************************************************************************************************/

using System;
using System.Data;
using System.Data.Common;
using Dos.ORM;
using Dos.ORM.Common;

namespace Dos.ORM.Model.Business
{
    /// <summary>
    /// 实体类BHZ_TableColsSet 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("BHZ_TableColsSet")]
    public partial class BHZ_TableColsSet : Entity
    {
        #region Model
        private Guid _ID;
        private Guid? _UserID;
        private string _TableCode;
        private string _ColumnCode;
        /// <summary>
        /// 
        /// </summary>
        public Guid ID
        {
            get { return _ID; }
            set
            {
                this.OnPropertyValueChange(_.ID, _ID, value);
                this._ID = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid? UserID
        {
            get { return _UserID; }
            set
            {
                this.OnPropertyValueChange(_.UserID, _UserID, value);
                this._UserID = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TableCode
        {
            get { return _TableCode; }
            set
            {
                this.OnPropertyValueChange(_.TableCode, _TableCode, value);
                this._TableCode = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ColumnCode
        {
            get { return _ColumnCode; }
            set
            {
                this.OnPropertyValueChange(_.ColumnCode, _ColumnCode, value);
                this._ColumnCode = value;
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// 获取实体中的主键列
        /// </summary>
        public override Field[] GetPrimaryKeyFields()
        {
            return new Field[] {
				_.ID};
        }
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
				_.ID,
				_.UserID,
				_.TableCode,
				_.ColumnCode};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
				this._ID,
				this._UserID,
				this._TableCode,
				this._ColumnCode};
        }
        #endregion

        #region _Field
        /// <summary>
        /// 字段信息
        /// </summary>
        public class _
        {
            /// <summary>
            /// * 
            /// </summary>
            public readonly static Field All = new Field("*", "BHZ_TableColsSet");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ID = new Field("ID", "BHZ_TableColsSet", "ID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field UserID = new Field("UserID", "BHZ_TableColsSet", "UserID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field TableCode = new Field("TableCode", "BHZ_TableColsSet", "TableCode");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ColumnCode = new Field("ColumnCode", "BHZ_TableColsSet", "ColumnCode");
        }
        #endregion

    }
}

