/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_Record
 * 创建时间：2017-02-21 18:32:55
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
	/// 实体类BUS_Record 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BUS_Record")]
	public partial class BUS_Record : Entity 
	{
		#region Model
		private Guid _ID;
		private Guid _RecordID;
		private string _RecordNumber;
		private Guid? _ReportID;
		private string _RecordUrl;
		private string _RecordName;
		private string _OrderNumber;
		private string _RecordDate;
		private string _ExperimentGistList;
		private string _SpecimenDescription;
		private bool _IsSave;
		private string _InstrumentEquipmentList;
		private string _Note;
		private int? _Sort;
		private string _ExperimentCondition;
		private bool? _IsShow;
		private string _SampleName;
		private string _SampleNumber;
		private string _SampleDescription;
		private string _EngineeringPurposes;
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
		public Guid RecordID
		{
			get{ return _RecordID; }
			set
			{
				this.OnPropertyValueChange(_.RecordID,_RecordID,value);
				this._RecordID=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RecordNumber
		{
			get{ return _RecordNumber; }
			set
			{
				this.OnPropertyValueChange(_.RecordNumber,_RecordNumber,value);
				this._RecordNumber=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid? ReportID
		{
			get{ return _ReportID; }
			set
			{
				this.OnPropertyValueChange(_.ReportID,_ReportID,value);
				this._ReportID=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RecordUrl
		{
			get{ return _RecordUrl; }
			set
			{
				this.OnPropertyValueChange(_.RecordUrl,_RecordUrl,value);
				this._RecordUrl=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RecordName
		{
			get{ return _RecordName; }
			set
			{
				this.OnPropertyValueChange(_.RecordName,_RecordName,value);
				this._RecordName=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrderNumber
		{
			get{ return _OrderNumber; }
			set
			{
				this.OnPropertyValueChange(_.OrderNumber,_OrderNumber,value);
				this._OrderNumber=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RecordDate
		{
			get{ return _RecordDate; }
			set
			{
				this.OnPropertyValueChange(_.RecordDate,_RecordDate,value);
				this._RecordDate=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ExperimentGistList
		{
			get{ return _ExperimentGistList; }
			set
			{
				this.OnPropertyValueChange(_.ExperimentGistList,_ExperimentGistList,value);
				this._ExperimentGistList=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SpecimenDescription
		{
			get{ return _SpecimenDescription; }
			set
			{
				this.OnPropertyValueChange(_.SpecimenDescription,_SpecimenDescription,value);
				this._SpecimenDescription=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsSave
		{
			get{ return _IsSave; }
			set
			{
				this.OnPropertyValueChange(_.IsSave,_IsSave,value);
				this._IsSave=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InstrumentEquipmentList
		{
			get{ return _InstrumentEquipmentList; }
			set
			{
				this.OnPropertyValueChange(_.InstrumentEquipmentList,_InstrumentEquipmentList,value);
				this._InstrumentEquipmentList=value;
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
		/// <summary>
		/// 
		/// </summary>
		public int? Sort
		{
			get{ return _Sort; }
			set
			{
				this.OnPropertyValueChange(_.Sort,_Sort,value);
				this._Sort=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ExperimentCondition
		{
			get{ return _ExperimentCondition; }
			set
			{
				this.OnPropertyValueChange(_.ExperimentCondition,_ExperimentCondition,value);
				this._ExperimentCondition=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool? IsShow
		{
			get{ return _IsShow; }
			set
			{
				this.OnPropertyValueChange(_.IsShow,_IsShow,value);
				this._IsShow=value;
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
		public string SampleDescription
		{
			get{ return _SampleDescription; }
			set
			{
				this.OnPropertyValueChange(_.SampleDescription,_SampleDescription,value);
				this._SampleDescription=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EngineeringPurposes
		{
			get{ return _EngineeringPurposes; }
			set
			{
				this.OnPropertyValueChange(_.EngineeringPurposes,_EngineeringPurposes,value);
				this._EngineeringPurposes=value;
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
				_.RecordID,
				_.RecordNumber,
				_.ReportID,
				_.RecordUrl,
				_.RecordName,
				_.OrderNumber,
				_.RecordDate,
				_.ExperimentGistList,
				_.SpecimenDescription,
				_.IsSave,
				_.InstrumentEquipmentList,
				_.Note,
				_.Sort,
				_.ExperimentCondition,
				_.IsShow,
				_.SampleName,
				_.SampleNumber,
				_.SampleDescription,
				_.EngineeringPurposes};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._RecordID,
				this._RecordNumber,
				this._ReportID,
				this._RecordUrl,
				this._RecordName,
				this._OrderNumber,
				this._RecordDate,
				this._ExperimentGistList,
				this._SpecimenDescription,
				this._IsSave,
				this._InstrumentEquipmentList,
				this._Note,
				this._Sort,
				this._ExperimentCondition,
				this._IsShow,
				this._SampleName,
				this._SampleNumber,
				this._SampleDescription,
				this._EngineeringPurposes};
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
			public readonly static Field All = new Field("*","BUS_Record");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID","BUS_Record","ID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field RecordID = new Field("RecordID","BUS_Record","RecordID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field RecordNumber = new Field("RecordNumber","BUS_Record","RecordNumber");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ReportID = new Field("ReportID","BUS_Record","ReportID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field RecordUrl = new Field("RecordUrl","BUS_Record","RecordUrl");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field RecordName = new Field("RecordName","BUS_Record","RecordName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OrderNumber = new Field("OrderNumber","BUS_Record","OrderNumber");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field RecordDate = new Field("RecordDate","BUS_Record","RecordDate");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ExperimentGistList = new Field("ExperimentGistList","BUS_Record","ExperimentGistList");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SpecimenDescription = new Field("SpecimenDescription","BUS_Record","SpecimenDescription");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IsSave = new Field("IsSave","BUS_Record","IsSave");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field InstrumentEquipmentList = new Field("InstrumentEquipmentList","BUS_Record","InstrumentEquipmentList");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Note = new Field("Note","BUS_Record","Note");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Sort = new Field("Sort","BUS_Record","Sort");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ExperimentCondition = new Field("ExperimentCondition","BUS_Record","ExperimentCondition");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IsShow = new Field("IsShow","BUS_Record","IsShow");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SampleName = new Field("SampleName","BUS_Record","SampleName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SampleNumber = new Field("SampleNumber","BUS_Record","SampleNumber");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SampleDescription = new Field("SampleDescription","BUS_Record","SampleDescription");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field EngineeringPurposes = new Field("EngineeringPurposes","BUS_Record","EngineeringPurposes");
		}
		#endregion

	}
}

