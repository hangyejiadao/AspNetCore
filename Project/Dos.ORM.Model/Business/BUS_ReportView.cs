/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_ReportView
 * 创建时间：2017-02-22 14:38:33
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
	/// 实体类BUS_ReportView 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BUS_ReportView")]
	public partial class BUS_ReportView : Entity 
	{
		#region Model
		private Guid _ID;
		private Guid _ReportID;
		private Guid? _ProjectID;
		private Guid? _OrganID;
		private string _ReportNumber;
		private string _OrderNumber;
        private DateTime? _ReportDate;
		private string _ReportUrl;
		private string _ExperimentName;
		private string _ExperimentGistList;
		private string _Conclusion;
		private string _EngineeringName;
		private string _DetermineGist;
		private string _IssueDate;
		private string _ConstructionUnit;
		private string _SupervisionUnit;
		private string _ExperimentUnit;
		private string _ContractSection;
		private string _ExperimentTimes;
		private string _EngineeringPurposes;
		private string _InstrumentEquipmentList;
		private string _Note;
		private bool? _IsDelete;
		private bool? _IsQualified;
		private string _ParameterResult;
		private string _NoParameterResult;
		private string _ProcessingConditions;
		private string _ExperimentUser;
		private string _ProjectName;
		private Guid? _SampleID;
		private string _SampleName;
		private string _SampleNumber;
		private Guid? _SampleTypeID;
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
		public Guid ReportID
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
		public string ReportNumber
		{
			get{ return _ReportNumber; }
			set
			{
				this.OnPropertyValueChange(_.ReportNumber,_ReportNumber,value);
				this._ReportNumber=value;
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
		public DateTime? ReportDate
		{
			get{ return _ReportDate; }
			set
			{
				this.OnPropertyValueChange(_.ReportDate,_ReportDate,value);
				this._ReportDate=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReportUrl
		{
			get{ return _ReportUrl; }
			set
			{
				this.OnPropertyValueChange(_.ReportUrl,_ReportUrl,value);
				this._ReportUrl=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ExperimentName
		{
			get{ return _ExperimentName; }
			set
			{
				this.OnPropertyValueChange(_.ExperimentName,_ExperimentName,value);
				this._ExperimentName=value;
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
		public string Conclusion
		{
			get{ return _Conclusion; }
			set
			{
				this.OnPropertyValueChange(_.Conclusion,_Conclusion,value);
				this._Conclusion=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EngineeringName
		{
			get{ return _EngineeringName; }
			set
			{
				this.OnPropertyValueChange(_.EngineeringName,_EngineeringName,value);
				this._EngineeringName=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DetermineGist
		{
			get{ return _DetermineGist; }
			set
			{
				this.OnPropertyValueChange(_.DetermineGist,_DetermineGist,value);
				this._DetermineGist=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IssueDate
		{
			get{ return _IssueDate; }
			set
			{
				this.OnPropertyValueChange(_.IssueDate,_IssueDate,value);
				this._IssueDate=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ConstructionUnit
		{
			get{ return _ConstructionUnit; }
			set
			{
				this.OnPropertyValueChange(_.ConstructionUnit,_ConstructionUnit,value);
				this._ConstructionUnit=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SupervisionUnit
		{
			get{ return _SupervisionUnit; }
			set
			{
				this.OnPropertyValueChange(_.SupervisionUnit,_SupervisionUnit,value);
				this._SupervisionUnit=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ExperimentUnit
		{
			get{ return _ExperimentUnit; }
			set
			{
				this.OnPropertyValueChange(_.ExperimentUnit,_ExperimentUnit,value);
				this._ExperimentUnit=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContractSection
		{
			get{ return _ContractSection; }
			set
			{
				this.OnPropertyValueChange(_.ContractSection,_ContractSection,value);
				this._ContractSection=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ExperimentTimes
		{
			get{ return _ExperimentTimes; }
			set
			{
				this.OnPropertyValueChange(_.ExperimentTimes,_ExperimentTimes,value);
				this._ExperimentTimes=value;
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
		public bool? IsDelete
		{
			get{ return _IsDelete; }
			set
			{
				this.OnPropertyValueChange(_.IsDelete,_IsDelete,value);
				this._IsDelete=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool? IsQualified
		{
			get{ return _IsQualified; }
			set
			{
				this.OnPropertyValueChange(_.IsQualified,_IsQualified,value);
				this._IsQualified=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ParameterResult
		{
			get{ return _ParameterResult; }
			set
			{
				this.OnPropertyValueChange(_.ParameterResult,_ParameterResult,value);
				this._ParameterResult=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NoParameterResult
		{
			get{ return _NoParameterResult; }
			set
			{
				this.OnPropertyValueChange(_.NoParameterResult,_NoParameterResult,value);
				this._NoParameterResult=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProcessingConditions
		{
			get{ return _ProcessingConditions; }
			set
			{
				this.OnPropertyValueChange(_.ProcessingConditions,_ProcessingConditions,value);
				this._ProcessingConditions=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ExperimentUser
		{
			get{ return _ExperimentUser; }
			set
			{
				this.OnPropertyValueChange(_.ExperimentUser,_ExperimentUser,value);
				this._ExperimentUser=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProjectName
		{
			get{ return _ProjectName; }
			set
			{
				this.OnPropertyValueChange(_.ProjectName,_ProjectName,value);
				this._ProjectName=value;
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
		public Guid? SampleTypeID
		{
			get{ return _SampleTypeID; }
			set
			{
				this.OnPropertyValueChange(_.SampleTypeID,_SampleTypeID,value);
				this._SampleTypeID=value;
			}
		}
		#endregion

		#region Method
		/// <summary>
		/// 是否只读
		/// </summary>
		public override bool IsReadOnly()
		{
			return true;
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.ID,
				_.ReportID,
				_.ProjectID,
				_.OrganID,
				_.ReportNumber,
				_.OrderNumber,
				_.ReportDate,
				_.ReportUrl,
				_.ExperimentName,
				_.ExperimentGistList,
				_.Conclusion,
				_.EngineeringName,
				_.DetermineGist,
				_.IssueDate,
				_.ConstructionUnit,
				_.SupervisionUnit,
				_.ExperimentUnit,
				_.ContractSection,
				_.ExperimentTimes,
				_.EngineeringPurposes,
				_.InstrumentEquipmentList,
				_.Note,
				_.IsDelete,
				_.IsQualified,
				_.ParameterResult,
				_.NoParameterResult,
				_.ProcessingConditions,
				_.ExperimentUser,
				_.ProjectName,
				_.SampleID,
				_.SampleName,
				_.SampleNumber,
				_.SampleTypeID};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._ReportID,
				this._ProjectID,
				this._OrganID,
				this._ReportNumber,
				this._OrderNumber,
				this._ReportDate,
				this._ReportUrl,
				this._ExperimentName,
				this._ExperimentGistList,
				this._Conclusion,
				this._EngineeringName,
				this._DetermineGist,
				this._IssueDate,
				this._ConstructionUnit,
				this._SupervisionUnit,
				this._ExperimentUnit,
				this._ContractSection,
				this._ExperimentTimes,
				this._EngineeringPurposes,
				this._InstrumentEquipmentList,
				this._Note,
				this._IsDelete,
				this._IsQualified,
				this._ParameterResult,
				this._NoParameterResult,
				this._ProcessingConditions,
				this._ExperimentUser,
				this._ProjectName,
				this._SampleID,
				this._SampleName,
				this._SampleNumber,
				this._SampleTypeID};
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
			public readonly static Field All = new Field("*","BUS_ReportView");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID","BUS_ReportView","ID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ReportID = new Field("ReportID","BUS_ReportView","ReportID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ProjectID = new Field("ProjectID","BUS_ReportView","ProjectID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OrganID = new Field("OrganID","BUS_ReportView","OrganID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ReportNumber = new Field("ReportNumber","BUS_ReportView","ReportNumber");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OrderNumber = new Field("OrderNumber","BUS_ReportView","OrderNumber");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ReportDate = new Field("ReportDate","BUS_ReportView","ReportDate");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ReportUrl = new Field("ReportUrl","BUS_ReportView","ReportUrl");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ExperimentName = new Field("ExperimentName","BUS_ReportView","ExperimentName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ExperimentGistList = new Field("ExperimentGistList","BUS_ReportView","ExperimentGistList");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Conclusion = new Field("Conclusion","BUS_ReportView","Conclusion");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field EngineeringName = new Field("EngineeringName","BUS_ReportView","EngineeringName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field DetermineGist = new Field("DetermineGist","BUS_ReportView","DetermineGist");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IssueDate = new Field("IssueDate","BUS_ReportView","IssueDate");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ConstructionUnit = new Field("ConstructionUnit","BUS_ReportView","ConstructionUnit");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SupervisionUnit = new Field("SupervisionUnit","BUS_ReportView","SupervisionUnit");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ExperimentUnit = new Field("ExperimentUnit","BUS_ReportView","ExperimentUnit");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ContractSection = new Field("ContractSection","BUS_ReportView","ContractSection");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ExperimentTimes = new Field("ExperimentTimes","BUS_ReportView","ExperimentTimes");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field EngineeringPurposes = new Field("EngineeringPurposes","BUS_ReportView","EngineeringPurposes");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field InstrumentEquipmentList = new Field("InstrumentEquipmentList","BUS_ReportView","InstrumentEquipmentList");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Note = new Field("Note","BUS_ReportView","Note");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IsDelete = new Field("IsDelete","BUS_ReportView","IsDelete");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IsQualified = new Field("IsQualified","BUS_ReportView","IsQualified");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ParameterResult = new Field("ParameterResult","BUS_ReportView","ParameterResult");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field NoParameterResult = new Field("NoParameterResult","BUS_ReportView","NoParameterResult");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ProcessingConditions = new Field("ProcessingConditions","BUS_ReportView","ProcessingConditions");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ExperimentUser = new Field("ExperimentUser","BUS_ReportView","ExperimentUser");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ProjectName = new Field("ProjectName","BUS_ReportView","ProjectName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SampleID = new Field("SampleID","BUS_ReportView","SampleID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SampleName = new Field("SampleName","BUS_ReportView","SampleName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SampleNumber = new Field("SampleNumber","BUS_ReportView","SampleNumber");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SampleTypeID = new Field("SampleTypeID","BUS_ReportView","SampleTypeID");
		}
		#endregion

	}
}

