/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_MixingPlan
 * 创建时间：2017-03-07 11:24:29
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
	/// 实体类BUS_MixingPlan 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BUS_MixingPlan")]
	public partial class BUS_MixingPlan : Entity 
	{
		#region Model
		private Guid _ID;
		private Guid? _ProjectID;
		private Guid? _OrganID;
		private string _Monitor;
		private string _Deviation;
		private string _Volume;
		private string _MaterialErrorUrl;
		private string _MaterialTrendUrl;
		private string _ProductivityUrl;
		private string _MixDataUrl;
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
		/// 
		/// </summary>
		public Guid? OrganID
		{
			get{ return _OrganID; }
			set
			{
				this.OnPropertyValueChange(_.OrganID,_OrganID,value);
				this._OrganID=value;
			}
		}
		/// <summary>
		/// 拌合站配比监控地址
		/// </summary>
		public string Monitor
		{
			get{ return _Monitor; }
			set
			{
				this.OnPropertyValueChange(_.Monitor,_Monitor,value);
				this._Monitor=value;
			}
		}
		/// <summary>
		/// 偏差查询
		/// </summary>
		public string Deviation
		{
			get{ return _Deviation; }
			set
			{
				this.OnPropertyValueChange(_.Deviation,_Deviation,value);
				this._Deviation=value;
			}
		}
		/// <summary>
		/// 方量统计
		/// </summary>
		public string Volume
		{
			get{ return _Volume; }
			set
			{
				this.OnPropertyValueChange(_.Volume,_Volume,value);
				this._Volume=value;
			}
		}
		/// <summary>
		/// 材料误差查询
		/// </summary>
		public string MaterialErrorUrl
		{
			get{ return _MaterialErrorUrl; }
			set
			{
				this.OnPropertyValueChange(_.MaterialErrorUrl,_MaterialErrorUrl,value);
				this._MaterialErrorUrl=value;
			}
		}
		/// <summary>
		/// 材料走势查询
		/// </summary>
		public string MaterialTrendUrl
		{
			get{ return _MaterialTrendUrl; }
			set
			{
				this.OnPropertyValueChange(_.MaterialTrendUrl,_MaterialTrendUrl,value);
				this._MaterialTrendUrl=value;
			}
		}
		/// <summary>
		/// 产能分析查询
		/// </summary>
		public string ProductivityUrl
		{
			get{ return _ProductivityUrl; }
			set
			{
				this.OnPropertyValueChange(_.ProductivityUrl,_ProductivityUrl,value);
				this._ProductivityUrl=value;
			}
		}
		/// <summary>
		/// 配合比数据查询
		/// </summary>
		public string MixDataUrl
		{
			get{ return _MixDataUrl; }
			set
			{
				this.OnPropertyValueChange(_.MixDataUrl,_MixDataUrl,value);
				this._MixDataUrl=value;
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
				_.OrganID,
				_.Monitor,
				_.Deviation,
				_.Volume,
				_.MaterialErrorUrl,
				_.MaterialTrendUrl,
				_.ProductivityUrl,
				_.MixDataUrl};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._ProjectID,
				this._OrganID,
				this._Monitor,
				this._Deviation,
				this._Volume,
				this._MaterialErrorUrl,
				this._MaterialTrendUrl,
				this._ProductivityUrl,
				this._MixDataUrl};
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
			public readonly static Field All = new Field("*","BUS_MixingPlan");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID","BUS_MixingPlan","ID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ProjectID = new Field("ProjectID","BUS_MixingPlan","ProjectID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OrganID = new Field("OrganID","BUS_MixingPlan","OrganID");
			/// <summary>
			/// 拌合站配比监控地址
			/// </summary>
			public readonly static Field Monitor = new Field("Monitor","BUS_MixingPlan","拌合站配比监控地址");
			/// <summary>
			/// 偏差查询
			/// </summary>
			public readonly static Field Deviation = new Field("Deviation","BUS_MixingPlan","偏差查询");
			/// <summary>
			/// 方量统计
			/// </summary>
			public readonly static Field Volume = new Field("Volume","BUS_MixingPlan","方量统计");
			/// <summary>
			/// 材料误差查询
			/// </summary>
			public readonly static Field MaterialErrorUrl = new Field("MaterialErrorUrl","BUS_MixingPlan","材料误差查询");
			/// <summary>
			/// 材料走势查询
			/// </summary>
			public readonly static Field MaterialTrendUrl = new Field("MaterialTrendUrl","BUS_MixingPlan","材料走势查询");
			/// <summary>
			/// 产能分析查询
			/// </summary>
			public readonly static Field ProductivityUrl = new Field("ProductivityUrl","BUS_MixingPlan","产能分析查询");
			/// <summary>
			/// 配合比数据查询
			/// </summary>
			public readonly static Field MixDataUrl = new Field("MixDataUrl","BUS_MixingPlan","配合比数据查询");
		}
		#endregion

	}
}

