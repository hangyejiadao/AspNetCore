/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_Sample
 * 创建时间：2017-02-17 11:12:13
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
	/// 实体类BUS_Sample 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BUS_Sample")]
	public partial class BUS_Sample : Entity 
	{
		#region Model
		private Guid _ID;
		private Guid? _SampleID;
		private string _SampleNumber;
		private string _BlindNumber;
		private string _SampleLogo;
		private string _TestObjectProperties;
		private Guid? _SampleTypeID;
		private string _SampleCode;
		private Guid? _ProjectID;
		private Guid _OrganID;
		private string _SampleName;
		private string _SampleDescribe;
		private string _EngineeringPurposes;
		private DateTime? _EntryDate;
		private DateTime? _SamplingDate;
		private string _SamplingUser;
		private int? _State;
		private string _Note;
		private DateTime? _CreatedDate;
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
		public string BlindNumber
		{
			get{ return _BlindNumber; }
			set
			{
				this.OnPropertyValueChange(_.BlindNumber,_BlindNumber,value);
				this._BlindNumber=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SampleLogo
		{
			get{ return _SampleLogo; }
			set
			{
				this.OnPropertyValueChange(_.SampleLogo,_SampleLogo,value);
				this._SampleLogo=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TestObjectProperties
		{
			get{ return _TestObjectProperties; }
			set
			{
				this.OnPropertyValueChange(_.TestObjectProperties,_TestObjectProperties,value);
				this._TestObjectProperties=value;
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
		/// <summary>
		/// 
		/// </summary>
		public string SampleCode
		{
			get{ return _SampleCode; }
			set
			{
				this.OnPropertyValueChange(_.SampleCode,_SampleCode,value);
				this._SampleCode=value;
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
		public Guid OrganID
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
		public string SampleDescribe
		{
			get{ return _SampleDescribe; }
			set
			{
				this.OnPropertyValueChange(_.SampleDescribe,_SampleDescribe,value);
				this._SampleDescribe=value;
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
		public DateTime? EntryDate
		{
			get{ return _EntryDate; }
			set
			{
				this.OnPropertyValueChange(_.EntryDate,_EntryDate,value);
				this._EntryDate=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SamplingDate
		{
			get{ return _SamplingDate; }
			set
			{
				this.OnPropertyValueChange(_.SamplingDate,_SamplingDate,value);
				this._SamplingDate=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SamplingUser
		{
			get{ return _SamplingUser; }
			set
			{
				this.OnPropertyValueChange(_.SamplingUser,_SamplingUser,value);
				this._SamplingUser=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? State
		{
			get{ return _State; }
			set
			{
				this.OnPropertyValueChange(_.State,_State,value);
				this._State=value;
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
		public DateTime? CreatedDate
		{
			get{ return _CreatedDate; }
			set
			{
				this.OnPropertyValueChange(_.CreatedDate,_CreatedDate,value);
				this._CreatedDate=value;
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
				_.SampleID,
				_.SampleNumber,
				_.BlindNumber,
				_.SampleLogo,
				_.TestObjectProperties,
				_.SampleTypeID,
				_.SampleCode,
				_.ProjectID,
				_.OrganID,
				_.SampleName,
				_.SampleDescribe,
				_.EngineeringPurposes,
				_.EntryDate,
				_.SamplingDate,
				_.SamplingUser,
				_.State,
				_.Note,
				_.CreatedDate};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._SampleID,
				this._SampleNumber,
				this._BlindNumber,
				this._SampleLogo,
				this._TestObjectProperties,
				this._SampleTypeID,
				this._SampleCode,
				this._ProjectID,
				this._OrganID,
				this._SampleName,
				this._SampleDescribe,
				this._EngineeringPurposes,
				this._EntryDate,
				this._SamplingDate,
				this._SamplingUser,
				this._State,
				this._Note,
				this._CreatedDate};
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
			public readonly static Field All = new Field("*","BUS_Sample");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID","BUS_Sample","ID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SampleID = new Field("SampleID","BUS_Sample","SampleID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SampleNumber = new Field("SampleNumber","BUS_Sample","SampleNumber");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field BlindNumber = new Field("BlindNumber","BUS_Sample","BlindNumber");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SampleLogo = new Field("SampleLogo","BUS_Sample","SampleLogo");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field TestObjectProperties = new Field("TestObjectProperties","BUS_Sample","TestObjectProperties");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SampleTypeID = new Field("SampleTypeID","BUS_Sample","SampleTypeID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SampleCode = new Field("SampleCode","BUS_Sample","SampleCode");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ProjectID = new Field("ProjectID","BUS_Sample","ProjectID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OrganID = new Field("OrganID","BUS_Sample","OrganID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SampleName = new Field("SampleName","BUS_Sample","SampleName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SampleDescribe = new Field("SampleDescribe","BUS_Sample","SampleDescribe");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field EngineeringPurposes = new Field("EngineeringPurposes","BUS_Sample","EngineeringPurposes");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field EntryDate = new Field("EntryDate","BUS_Sample","EntryDate");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SamplingDate = new Field("SamplingDate","BUS_Sample","SamplingDate");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SamplingUser = new Field("SamplingUser","BUS_Sample","SamplingUser");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field State = new Field("State","BUS_Sample","State");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Note = new Field("Note","BUS_Sample","Note");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CreatedDate = new Field("CreatedDate","BUS_Sample","CreatedDate");
		}
		#endregion

	}
}

