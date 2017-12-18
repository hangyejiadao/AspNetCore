/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.System
 * 类名称：SYS_ModuleButtonRelation
 * 创建时间：2016-11-04 15:07:58
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
	/// 实体类SYS_ModuleButtonRelation 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("SYS_ModuleButtonRelation")]
	[Serializable]
	public partial class SYS_ModuleButtonRelation : Entity 
	{
		#region Model
		private Guid _MbId;
		private Guid _ModuleId;
		private Guid _ButtonId;
		private DateTime _CrtTime;
		private Guid _CrtOptId;
		/// <summary>
		/// 
		/// </summary>
		public Guid MbId
		{
			get{ return _MbId; }
			set
			{
				this.OnPropertyValueChange(_.MbId,_MbId,value);
				this._MbId=value;
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
		/// 
		/// </summary>
		public Guid ButtonId
		{
			get{ return _ButtonId; }
			set
			{
				this.OnPropertyValueChange(_.ButtonId,_ButtonId,value);
				this._ButtonId=value;
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
				_.MbId};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.MbId,
				_.ModuleId,
				_.ButtonId,
				_.CrtTime,
				_.CrtOptId};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._MbId,
				this._ModuleId,
				this._ButtonId,
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
			public readonly static Field All = new Field("*","SYS_ModuleButtonRelation");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field MbId = new Field("MbId","SYS_ModuleButtonRelation","MbId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ModuleId = new Field("ModuleId","SYS_ModuleButtonRelation","ModuleId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ButtonId = new Field("ButtonId","SYS_ModuleButtonRelation","ButtonId");
			/// <summary>
			/// 创建时间
			/// </summary>
			public readonly static Field CrtTime = new Field("CrtTime","SYS_ModuleButtonRelation","创建时间");
			/// <summary>
			/// 创建人
			/// </summary>
			public readonly static Field CrtOptId = new Field("CrtOptId","SYS_ModuleButtonRelation","创建人");
		}
		#endregion

	}
}

