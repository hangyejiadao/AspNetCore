/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_Role
 * 创建时间：2017-02-09 15:42:10
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
	/// 实体类BUS_Role 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BUS_Role")]
	public partial class BUS_Role : Entity 
	{
        #region Model
        /// <summary>
        /// treegrid父节点Id
        /// </summary>
        public Nullable<Guid> _parentId
        {
            get { return Guid.Empty; }
        }
		private Guid _ID;
		private string _RoleName;
		private int? _Order;
		private string _Note;
		/// <summary>
		/// 
		/// </summary>
		public Guid ID
		{
			get{ return _ID; }
			set
			{
				this.OnPropertyValueChange(_.ID,_ID,value);
				this._ID=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoleName
		{
			get{ return _RoleName; }
			set
			{
				this.OnPropertyValueChange(_.RoleName,_RoleName,value);
				this._RoleName=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Order
		{
			get{ return _Order; }
			set
			{
				this.OnPropertyValueChange(_.Order,_Order,value);
				this._Order=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Note
		{
			get{ return _Note; }
			set
			{
				this.OnPropertyValueChange(_.Note,_Note,value);
				this._Note=value;
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
				_.RoleName,
				_.Order,
				_.Note};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._RoleName,
				this._Order,
				this._Note};
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
			public readonly static Field All = new Field("*","BUS_Role");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID","BUS_Role","ID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field RoleName = new Field("RoleName","BUS_Role","RoleName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Order = new Field("Order","BUS_Role","Order");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Note = new Field("Note","BUS_Role","Note");
		}
		#endregion

	}
}

