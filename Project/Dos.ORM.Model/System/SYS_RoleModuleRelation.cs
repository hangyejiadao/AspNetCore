/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.System
 * 类名称：SYS_RoleModuleRelation
 * 创建时间：2016-08-14 14:10:06
 * 创建人：Quber Tool
 * 创建说明：此代码由工具生成，请谨慎修改！
*****************************************************************************************************/

using System;
using System.Data;
using System.Data.Common;
using Dos.ORM;
using Dos.ORM.Common;

namespace Dos.ORM.Model.System
{
	/// <summary>
	/// 实体类SYS_RoleModuleRelation 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("SYS_RoleModuleRelation")]
	[Serializable]
	public partial class SYS_RoleModuleRelation : Entity 
	{
		#region Model
		private Guid _RmId;
		private Guid _RoleId;
		private Guid _ModuleId;
		private DateTime _CrtTime;
		private Guid _CrtOptId;
		/// <summary>
		/// 
		/// </summary>
		public Guid RmId
		{
			get{ return _RmId; }
			set
			{
				this.OnPropertyValueChange(_.RmId,_RmId,value);
				this._RmId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid RoleId
		{
			get{ return _RoleId; }
			set
			{
				this.OnPropertyValueChange(_.RoleId,_RoleId,value);
				this._RoleId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid ModuleId
		{
			get{ return _ModuleId; }
			set
			{
				this.OnPropertyValueChange(_.ModuleId,_ModuleId,value);
				this._ModuleId=value;
			}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CrtTime
		{
			get{ return _CrtTime; }
			set
			{
				this.OnPropertyValueChange(_.CrtTime,_CrtTime,value);
				this._CrtTime=value;
			}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public Guid CrtOptId
		{
			get{ return _CrtOptId; }
			set
			{
				this.OnPropertyValueChange(_.CrtOptId,_CrtOptId,value);
				this._CrtOptId=value;
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
				_.RmId};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.RmId,
				_.RoleId,
				_.ModuleId,
				_.CrtTime,
				_.CrtOptId};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._RmId,
				this._RoleId,
				this._ModuleId,
				this._CrtTime,
				this._CrtOptId};
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
			public readonly static Field All = new Field("*","SYS_RoleModuleRelation");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field RmId = new Field("RmId","SYS_RoleModuleRelation","RmId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field RoleId = new Field("RoleId","SYS_RoleModuleRelation","RoleId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ModuleId = new Field("ModuleId","SYS_RoleModuleRelation","ModuleId");
			/// <summary>
			/// 创建时间
			/// </summary>
			public readonly static Field CrtTime = new Field("CrtTime","SYS_RoleModuleRelation","创建时间");
			/// <summary>
			/// 创建人
			/// </summary>
			public readonly static Field CrtOptId = new Field("CrtOptId","SYS_RoleModuleRelation","创建人");
		}
		#endregion

	}
}

