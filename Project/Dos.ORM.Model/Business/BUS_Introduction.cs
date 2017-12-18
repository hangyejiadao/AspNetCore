/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_Introduction
 * 创建时间：2016-09-22 17:38:47
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
	/// 实体类BUS_Introduction 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BUS_Introduction")]
	[Serializable]
	public partial class BUS_Introduction : Entity 
	{
		#region Model
		private int _IntId;
		private Guid? _CompanyId;
		private string _Summary;
		private string _DtlInfo;
		private int _Status;
		private DateTime _CrtTime;
		private Guid _CrtOptId;
		private DateTime? _ModTime;
		private Guid? _ModOptId;
		/// <summary>
		/// 固定类型有：     100：关于我们（公司介绍）     200：联系我们     300：发展历程     400：
		/// </summary>
		public int IntId
		{
			get{ return _IntId; }
			set
			{
				this.OnPropertyValueChange(_.IntId,_IntId,value);
				this._IntId=value;
			}
		}
		/// <summary>
		/// 公司Id
		/// </summary>
		public Guid? CompanyId
		{
			get{ return _CompanyId; }
			set
			{
				this.OnPropertyValueChange(_.CompanyId,_CompanyId,value);
				this._CompanyId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Summary
		{
			get{ return _Summary; }
			set
			{
				this.OnPropertyValueChange(_.Summary,_Summary,value);
				this._Summary=value;
			}
		}
		/// <summary>
		/// 详细信息
		/// </summary>
		public string DtlInfo
		{
			get{ return _DtlInfo; }
			set
			{
				this.OnPropertyValueChange(_.DtlInfo,_DtlInfo,value);
				this._DtlInfo=value;
			}
		}
		/// <summary>
		/// _1：正常数据（默认）     0：已删除数据
		/// </summary>
		public int Status
		{
			get{ return _Status; }
			set
			{
				this.OnPropertyValueChange(_.Status,_Status,value);
				this._Status=value;
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
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime? ModTime
		{
			get{ return _ModTime; }
			set
			{
				this.OnPropertyValueChange(_.ModTime,_ModTime,value);
				this._ModTime=value;
			}
		}
		/// <summary>
		/// 修改人
		/// </summary>
		public Guid? ModOptId
		{
			get{ return _ModOptId; }
			set
			{
				this.OnPropertyValueChange(_.ModOptId,_ModOptId,value);
				this._ModOptId=value;
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
				_.IntId};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.IntId,
				_.CompanyId,
				_.Summary,
				_.DtlInfo,
				_.Status,
				_.CrtTime,
				_.CrtOptId,
				_.ModTime,
				_.ModOptId};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._IntId,
				this._CompanyId,
				this._Summary,
				this._DtlInfo,
				this._Status,
				this._CrtTime,
				this._CrtOptId,
				this._ModTime,
				this._ModOptId};
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
			public readonly static Field All = new Field("*","BUS_Introduction");
			/// <summary>
			/// 固定类型有：     100：关于我们（公司介绍）     200：联系我们     300：发展历程     400：
			/// </summary>
			public readonly static Field IntId = new Field("IntId","BUS_Introduction","固定类型有：     100：关于我们（公司介绍）     200：联系我们     300：发展历程     400：");
			/// <summary>
			/// 公司Id
			/// </summary>
			public readonly static Field CompanyId = new Field("CompanyId","BUS_Introduction","公司Id");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Summary = new Field("Summary","BUS_Introduction","Summary");
			/// <summary>
			/// 详细信息
			/// </summary>
			public readonly static Field DtlInfo = new Field("DtlInfo","BUS_Introduction","详细信息");
			/// <summary>
			/// _1：正常数据（默认）     0：已删除数据
			/// </summary>
			public readonly static Field Status = new Field("Status","BUS_Introduction","_1：正常数据（默认）     0：已删除数据");
			/// <summary>
			/// 创建时间
			/// </summary>
			public readonly static Field CrtTime = new Field("CrtTime","BUS_Introduction","创建时间");
			/// <summary>
			/// 创建人
			/// </summary>
			public readonly static Field CrtOptId = new Field("CrtOptId","BUS_Introduction","创建人");
			/// <summary>
			/// 修改时间
			/// </summary>
			public readonly static Field ModTime = new Field("ModTime","BUS_Introduction","修改时间");
			/// <summary>
			/// 修改人
			/// </summary>
			public readonly static Field ModOptId = new Field("ModOptId","BUS_Introduction","修改人");
		}
		#endregion

	}
}

