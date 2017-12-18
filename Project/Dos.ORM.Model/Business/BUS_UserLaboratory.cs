/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_UserLaboratory
 * 创建时间：2017-02-15 11:06:10
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
	/// 实体类BUS_UserLaboratory 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BUS_UserLaboratory")]
	public partial class BUS_UserLaboratory : Entity 
	{
        public string TargetName { get; set; }

        public string BhzApi { get; set; }

        public string SyjApi { get; set; }
	    

		#region Model
		private Guid _ID;
		private Guid _AccountID;
		private Guid _TargetId;
		private Guid? _ParentId;
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
		public Guid AccountID
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
		public Guid TargetId
		{
			get{ return _TargetId; }
			set
			{
				this.OnPropertyValueChange(_.TargetId,_TargetId,value);
				this._TargetId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid? ParentId
		{
			get{ return _ParentId; }
			set
			{
				this.OnPropertyValueChange(_.ParentId,_ParentId,value);
				this._ParentId=value;
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
				_.TargetId,
				_.ParentId};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._AccountID,
				this._TargetId,
				this._ParentId};
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
			public readonly static Field All = new Field("*","BUS_UserLaboratory");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID","BUS_UserLaboratory","ID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field AccountID = new Field("AccountID","BUS_UserLaboratory","AccountID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field TargetId = new Field("TargetId","BUS_UserLaboratory","TargetId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ParentId = new Field("ParentId","BUS_UserLaboratory","ParentId");
		}
		#endregion

	}
}

