/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_UserRole
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
	/// 实体类BUS_UserRole 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BUS_UserRole")]
	public partial class BUS_UserRole : Entity 
	{
		#region Model
		private Guid _ID;
		private Guid? _AccountID;
		private Guid? _RoleID;
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
		public Guid? AccountID
		{
			get{ return _AccountID; }
			set
			{
				this.OnPropertyValueChange(_.AccountID,_AccountID,value);
				this._AccountID=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid? RoleID
		{
			get{ return _RoleID; }
			set
			{
				this.OnPropertyValueChange(_.RoleID,_RoleID,value);
				this._RoleID=value;
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
				_.AccountID,
				_.RoleID};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._AccountID,
				this._RoleID};
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
			public readonly static Field All = new Field("*","BUS_UserRole");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID","BUS_UserRole","ID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field AccountID = new Field("AccountID","BUS_UserRole","AccountID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field RoleID = new Field("RoleID","BUS_UserRole","RoleID");
		}
		#endregion

	}
}

