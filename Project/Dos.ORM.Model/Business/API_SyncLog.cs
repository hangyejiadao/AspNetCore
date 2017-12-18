/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：API_SyncLog
 * 创建时间：2017-02-27 14:04:00
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
	/// 实体类API_SyncLog 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("API_SyncLog")]
	public partial class API_SyncLog : Entity 
	{
		#region Model
		private Guid _ID;
		private Guid? _ProjectID;
		private string _CurrentTimeStamp;
		private string _OperateType;
		private bool? _IsSuccess;
		private DateTime? _CreateTime;
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
		public Guid? ProjectID
		{
			get{ return _ProjectID; }
			set
			{
				this.OnPropertyValueChange(_.ProjectID,_ProjectID,value);
				this._ProjectID=value;
			}
		}
		/// <summary>
		/// 时间戳
		/// </summary>
		public string CurrentTimeStamp
		{
			get{ return _CurrentTimeStamp; }
			set
			{
				this.OnPropertyValueChange(_.CurrentTimeStamp,_CurrentTimeStamp,value);
				this._CurrentTimeStamp=value;
			}
		}
		/// <summary>
		/// 具体操作表
		/// </summary>
		public string OperateType
		{
			get{ return _OperateType; }
			set
			{
				this.OnPropertyValueChange(_.OperateType,_OperateType,value);
				this._OperateType=value;
			}
		}
		/// <summary>
		/// 操作结果
		/// </summary>
		public bool? IsSuccess
		{
			get{ return _IsSuccess; }
			set
			{
				this.OnPropertyValueChange(_.IsSuccess,_IsSuccess,value);
				this._IsSuccess=value;
			}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? CreateTime
		{
			get{ return _CreateTime; }
			set
			{
				this.OnPropertyValueChange(_.CreateTime,_CreateTime,value);
				this._CreateTime=value;
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
				_.ProjectID,
				_.CurrentTimeStamp,
				_.OperateType,
				_.IsSuccess,
				_.CreateTime};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._ProjectID,
				this._CurrentTimeStamp,
				this._OperateType,
				this._IsSuccess,
				this._CreateTime};
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
			public readonly static Field All = new Field("*","API_SyncLog");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID","API_SyncLog","ID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ProjectID = new Field("ProjectID","API_SyncLog","ProjectID");
			/// <summary>
			/// 时间戳
			/// </summary>
			public readonly static Field CurrentTimeStamp = new Field("CurrentTimeStamp","API_SyncLog","时间戳");
			/// <summary>
			/// 具体操作表
			/// </summary>
			public readonly static Field OperateType = new Field("OperateType","API_SyncLog","具体操作表");
			/// <summary>
			/// 操作结果
			/// </summary>
			public readonly static Field IsSuccess = new Field("IsSuccess","API_SyncLog","操作结果");
			/// <summary>
			/// 创建时间
			/// </summary>
			public readonly static Field CreateTime = new Field("CreateTime","API_SyncLog","创建时间");
		}
		#endregion

	}
}

