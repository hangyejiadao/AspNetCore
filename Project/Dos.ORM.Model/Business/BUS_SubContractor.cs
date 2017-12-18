/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_SubContractor
 * 创建时间：2017-02-22 09:34:14
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
	/// 实体类BUS_SubContractor 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BUS_SubContractor")]
	public partial class BUS_SubContractor : Entity 
	{
		#region Model
		private Guid _ID;
		private Guid _SubContractorID;
		private Guid? _ProjectID;
		private Guid? _OrganID;
		private Guid? _SampleID;
		private string _SampleName;
		private string _SampleNumber;
		private string _Specifications;
		private string _SamplingLocations;
		private string _SampleAmount;
		private DateTime? _EntrustDate;
		private string _CommissionedUnit;
		private string _CommissionedUnitNumber;
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
		public Guid SubContractorID
		{
			get{ return _SubContractorID; }
			set
			{
				this.OnPropertyValueChange(_.SubContractorID,_SubContractorID,value);
				this._SubContractorID=value;
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
		/// 
		/// </summary>
		public Guid? SampleID
		{
			get{ return _SampleID; }
			set
			{
				this.OnPropertyValueChange(_.SampleID,_SampleID,value);
				this._SampleID=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SampleName
		{
			get{ return _SampleName; }
			set
			{
				this.OnPropertyValueChange(_.SampleName,_SampleName,value);
				this._SampleName=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SampleNumber
		{
			get{ return _SampleNumber; }
			set
			{
				this.OnPropertyValueChange(_.SampleNumber,_SampleNumber,value);
				this._SampleNumber=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Specifications
		{
			get{ return _Specifications; }
			set
			{
				this.OnPropertyValueChange(_.Specifications,_Specifications,value);
				this._Specifications=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SamplingLocations
		{
			get{ return _SamplingLocations; }
			set
			{
				this.OnPropertyValueChange(_.SamplingLocations,_SamplingLocations,value);
				this._SamplingLocations=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SampleAmount
		{
			get{ return _SampleAmount; }
			set
			{
				this.OnPropertyValueChange(_.SampleAmount,_SampleAmount,value);
				this._SampleAmount=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EntrustDate
		{
			get{ return _EntrustDate; }
			set
			{
				this.OnPropertyValueChange(_.EntrustDate,_EntrustDate,value);
				this._EntrustDate=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CommissionedUnit
		{
			get{ return _CommissionedUnit; }
			set
			{
				this.OnPropertyValueChange(_.CommissionedUnit,_CommissionedUnit,value);
				this._CommissionedUnit=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CommissionedUnitNumber
		{
			get{ return _CommissionedUnitNumber; }
			set
			{
				this.OnPropertyValueChange(_.CommissionedUnitNumber,_CommissionedUnitNumber,value);
				this._CommissionedUnitNumber=value;
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
				_.SubContractorID,
				_.ProjectID,
				_.OrganID,
				_.SampleID,
				_.SampleName,
				_.SampleNumber,
				_.Specifications,
				_.SamplingLocations,
				_.SampleAmount,
				_.EntrustDate,
				_.CommissionedUnit,
				_.CommissionedUnitNumber,
				_.Note};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._SubContractorID,
				this._ProjectID,
				this._OrganID,
				this._SampleID,
				this._SampleName,
				this._SampleNumber,
				this._Specifications,
				this._SamplingLocations,
				this._SampleAmount,
				this._EntrustDate,
				this._CommissionedUnit,
				this._CommissionedUnitNumber,
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
			public readonly static Field All = new Field("*","BUS_SubContractor");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID","BUS_SubContractor","ID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SubContractorID = new Field("SubContractorID","BUS_SubContractor","SubContractorID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ProjectID = new Field("ProjectID","BUS_SubContractor","ProjectID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OrganID = new Field("OrganID","BUS_SubContractor","OrganID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SampleID = new Field("SampleID","BUS_SubContractor","SampleID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SampleName = new Field("SampleName","BUS_SubContractor","SampleName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SampleNumber = new Field("SampleNumber","BUS_SubContractor","SampleNumber");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Specifications = new Field("Specifications","BUS_SubContractor","Specifications");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SamplingLocations = new Field("SamplingLocations","BUS_SubContractor","SamplingLocations");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SampleAmount = new Field("SampleAmount","BUS_SubContractor","SampleAmount");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field EntrustDate = new Field("EntrustDate","BUS_SubContractor","EntrustDate");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CommissionedUnit = new Field("CommissionedUnit","BUS_SubContractor","CommissionedUnit");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CommissionedUnitNumber = new Field("CommissionedUnitNumber","BUS_SubContractor","CommissionedUnitNumber");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Note = new Field("Note","BUS_SubContractor","Note");
		}
		#endregion

	}
}

