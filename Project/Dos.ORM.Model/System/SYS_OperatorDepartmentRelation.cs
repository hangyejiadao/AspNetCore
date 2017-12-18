/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.System
 * 类名称：SYS_OperatorDepartmentRelation
 * 创建时间：2016-08-14 14:28:53
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
	/// 实体类SYS_OperatorDepartmentRelation 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("SYS_OperatorDepartmentRelation")]
	[Serializable]
	public partial class SYS_OperatorDepartmentRelation : Entity 
	{
		#region Model
		private Guid _OdId;
		private Guid _DepartmentId;
		private Guid _OperatorId;
		private DateTime _CrtTime;
		private Guid _CrtOptId;
		/// <summary>
		/// 
		/// </summary>
		public Guid OdId
		{
			get{ return _OdId; }
			set
			{
				this.OnPropertyValueChange(_.OdId,_OdId,value);
				this._OdId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid DepartmentId
		{
			get{ return _DepartmentId; }
			set
			{
				this.OnPropertyValueChange(_.DepartmentId,_DepartmentId,value);
				this._DepartmentId=value;
			}
		}
		/// <summary>
		/// 管理员Id
		/// </summary>
		public Guid OperatorId
		{
			get{ return _OperatorId; }
			set
			{
				this.OnPropertyValueChange(_.OperatorId,_OperatorId,value);
				this._OperatorId=value;
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
				_.OdId};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.OdId,
				_.DepartmentId,
				_.OperatorId,
				_.CrtTime,
				_.CrtOptId};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._OdId,
				this._DepartmentId,
				this._OperatorId,
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
			public readonly static Field All = new Field("*","SYS_OperatorDepartmentRelation");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OdId = new Field("OdId","SYS_OperatorDepartmentRelation","OdId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field DepartmentId = new Field("DepartmentId","SYS_OperatorDepartmentRelation","DepartmentId");
			/// <summary>
			/// 管理员Id
			/// </summary>
			public readonly static Field OperatorId = new Field("OperatorId","SYS_OperatorDepartmentRelation","管理员Id");
			/// <summary>
			/// 创建时间
			/// </summary>
			public readonly static Field CrtTime = new Field("CrtTime","SYS_OperatorDepartmentRelation","创建时间");
			/// <summary>
			/// 创建人
			/// </summary>
			public readonly static Field CrtOptId = new Field("CrtOptId","SYS_OperatorDepartmentRelation","创建人");
		}
		#endregion

	}
}

