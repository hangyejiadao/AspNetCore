/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_RoleModule
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
	/// 实体类BUS_RoleModule 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BUS_RoleModule")]
	public partial class BUS_RoleModule : Entity 
	{
		#region Model
		private Guid _ID;
		private Guid? _RoleID;
		private Guid? _ModuleID;
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
		public Guid? RoleID
		{
			get{ return _RoleID; }
			set
			{
				this.OnPropertyValueChange(_.RoleID,_RoleID,value);
				this._RoleID=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid? ModuleID
		{
			get{ return _ModuleID; }
			set
			{
				this.OnPropertyValueChange(_.ModuleID,_ModuleID,value);
				this._ModuleID=value;
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
				_.RoleID,
				_.ModuleID};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._RoleID,
				this._ModuleID};
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
			public readonly static Field All = new Field("*","BUS_RoleModule");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID","BUS_RoleModule","ID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field RoleID = new Field("RoleID","BUS_RoleModule","RoleID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ModuleID = new Field("ModuleID","BUS_RoleModule","ModuleID");
		}
		#endregion

	}
}

