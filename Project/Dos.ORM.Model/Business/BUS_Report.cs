/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_Report
 * 创建时间：2017-02-21 18:32:54
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
	/// 实体类BUS_Report 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BUS_Report")]
	public partial class BUS_Report : Entity 
	{
		#region Model
		private Guid _ID;
		private Guid _ReportID;
		private Guid? _ProjectID;
		private Guid? _OrganID;
		private string _ReportNumber;
		private string _OrderNumber;
		private string _ReportDate;
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
		public string ReportDate
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
				_.SampleID};
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
				this._SampleID};
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
			public readonly static Field All = new Field("*","BUS_Report");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID","BUS_Report","ID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ReportID = new Field("ReportID","BUS_Report","ReportID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ProjectID = new Field("ProjectID","BUS_Report","ProjectID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OrganID = new Field("OrganID","BUS_Report","OrganID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ReportNumber = new Field("ReportNumber","BUS_Report","ReportNumber");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OrderNumber = new Field("OrderNumber","BUS_Report","OrderNumber");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ReportDate = new Field("ReportDate","BUS_Report","ReportDate");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ReportUrl = new Field("ReportUrl","BUS_Report","ReportUrl");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ExperimentName = new Field("ExperimentName","BUS_Report","ExperimentName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ExperimentGistList = new Field("ExperimentGistList","BUS_Report","ExperimentGistList");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Conclusion = new Field("Conclusion","BUS_Report","Conclusion");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field EngineeringName = new Field("EngineeringName","BUS_Report","EngineeringName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field DetermineGist = new Field("DetermineGist","BUS_Report","DetermineGist");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IssueDate = new Field("IssueDate","BUS_Report","IssueDate");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ConstructionUnit = new Field("ConstructionUnit","BUS_Report","ConstructionUnit");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SupervisionUnit = new Field("SupervisionUnit","BUS_Report","SupervisionUnit");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ExperimentUnit = new Field("ExperimentUnit","BUS_Report","ExperimentUnit");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ContractSection = new Field("ContractSection","BUS_Report","ContractSection");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ExperimentTimes = new Field("ExperimentTimes","BUS_Report","ExperimentTimes");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field EngineeringPurposes = new Field("EngineeringPurposes","BUS_Report","EngineeringPurposes");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field InstrumentEquipmentList = new Field("InstrumentEquipmentList","BUS_Report","InstrumentEquipmentList");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Note = new Field("Note","BUS_Report","Note");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IsDelete = new Field("IsDelete","BUS_Report","IsDelete");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IsQualified = new Field("IsQualified","BUS_Report","IsQualified");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ParameterResult = new Field("ParameterResult","BUS_Report","ParameterResult");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field NoParameterResult = new Field("NoParameterResult","BUS_Report","NoParameterResult");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ProcessingConditions = new Field("ProcessingConditions","BUS_Report","ProcessingConditions");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ExperimentUser = new Field("ExperimentUser","BUS_Report","ExperimentUser");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ProjectName = new Field("ProjectName","BUS_Report","ProjectName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SampleID = new Field("SampleID","BUS_Report","SampleID");
		}
		#endregion

	}
}

