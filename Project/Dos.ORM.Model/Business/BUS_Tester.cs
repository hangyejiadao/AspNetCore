/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_Tester
 * 创建时间：2017-02-09 15:42:10
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
	/// 实体类BUS_Tester 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BUS_Tester")]
	public partial class BUS_Tester : Entity 
	{


        //扩展字段
        public string FilePath
        {
            get;
            set;
        }


		#region Model
		private Guid _ID;
		private Guid? _PersonID;
		private Guid? _ProjectID;
		private Guid? _OrganID;
		private string _Name;
		private bool? _Sex;
		private DateTime? _DateBirth;
		private string _Job;
		private string _Education;
		private string _Major;
		private string _Title;
		private int? _WorkYears;
		private string _CertificatNO;
		private bool? _Isregister;
		private string _ChangeContent;
		private string _IDType;
		private string _IDNum;
		private string _Nation;
		private string _Email;
		private string _TelePhone;
		private string _LocateProvince;
		private string _Postcode;
		private string _MailAddress;
		private string _EducationalBack;
		private DateTime? _GraduDate;
		private DateTime? _WorkTime;
		private DateTime? _EvaluTime;
		private string _OfficePhone;
		private string _fax;
		private string _ResumeAndPerform;
		private string _MainHonor;
		private string _Research;
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
		public Guid? PersonID
		{
			get{ return _PersonID; }
			set
			{
				this.OnPropertyValueChange(_.PersonID,_PersonID,value);
				this._PersonID=value;
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
		public string Name
		{
			get{ return _Name; }
			set
			{
				this.OnPropertyValueChange(_.Name,_Name,value);
				this._Name=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool? Sex
		{
			get{ return _Sex; }
			set
			{
				this.OnPropertyValueChange(_.Sex,_Sex,value);
				this._Sex=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DateBirth
		{
			get{ return _DateBirth; }
			set
			{
				this.OnPropertyValueChange(_.DateBirth,_DateBirth,value);
				this._DateBirth=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Job
		{
			get{ return _Job; }
			set
			{
				this.OnPropertyValueChange(_.Job,_Job,value);
				this._Job=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Education
		{
			get{ return _Education; }
			set
			{
				this.OnPropertyValueChange(_.Education,_Education,value);
				this._Education=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Major
		{
			get{ return _Major; }
			set
			{
				this.OnPropertyValueChange(_.Major,_Major,value);
				this._Major=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			get{ return _Title; }
			set
			{
				this.OnPropertyValueChange(_.Title,_Title,value);
				this._Title=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? WorkYears
		{
			get{ return _WorkYears; }
			set
			{
				this.OnPropertyValueChange(_.WorkYears,_WorkYears,value);
				this._WorkYears=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CertificatNO
		{
			get{ return _CertificatNO; }
			set
			{
				this.OnPropertyValueChange(_.CertificatNO,_CertificatNO,value);
				this._CertificatNO=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool? Isregister
		{
			get{ return _Isregister; }
			set
			{
				this.OnPropertyValueChange(_.Isregister,_Isregister,value);
				this._Isregister=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ChangeContent
		{
			get{ return _ChangeContent; }
			set
			{
				this.OnPropertyValueChange(_.ChangeContent,_ChangeContent,value);
				this._ChangeContent=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IDType
		{
			get{ return _IDType; }
			set
			{
				this.OnPropertyValueChange(_.IDType,_IDType,value);
				this._IDType=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IDNum
		{
			get{ return _IDNum; }
			set
			{
				this.OnPropertyValueChange(_.IDNum,_IDNum,value);
				this._IDNum=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Nation
		{
			get{ return _Nation; }
			set
			{
				this.OnPropertyValueChange(_.Nation,_Nation,value);
				this._Nation=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			get{ return _Email; }
			set
			{
				this.OnPropertyValueChange(_.Email,_Email,value);
				this._Email=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TelePhone
		{
			get{ return _TelePhone; }
			set
			{
				this.OnPropertyValueChange(_.TelePhone,_TelePhone,value);
				this._TelePhone=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LocateProvince
		{
			get{ return _LocateProvince; }
			set
			{
				this.OnPropertyValueChange(_.LocateProvince,_LocateProvince,value);
				this._LocateProvince=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Postcode
		{
			get{ return _Postcode; }
			set
			{
				this.OnPropertyValueChange(_.Postcode,_Postcode,value);
				this._Postcode=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MailAddress
		{
			get{ return _MailAddress; }
			set
			{
				this.OnPropertyValueChange(_.MailAddress,_MailAddress,value);
				this._MailAddress=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EducationalBack
		{
			get{ return _EducationalBack; }
			set
			{
				this.OnPropertyValueChange(_.EducationalBack,_EducationalBack,value);
				this._EducationalBack=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? GraduDate
		{
			get{ return _GraduDate; }
			set
			{
				this.OnPropertyValueChange(_.GraduDate,_GraduDate,value);
				this._GraduDate=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? WorkTime
		{
			get{ return _WorkTime; }
			set
			{
				this.OnPropertyValueChange(_.WorkTime,_WorkTime,value);
				this._WorkTime=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EvaluTime
		{
			get{ return _EvaluTime; }
			set
			{
				this.OnPropertyValueChange(_.EvaluTime,_EvaluTime,value);
				this._EvaluTime=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OfficePhone
		{
			get{ return _OfficePhone; }
			set
			{
				this.OnPropertyValueChange(_.OfficePhone,_OfficePhone,value);
				this._OfficePhone=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fax
		{
			get{ return _fax; }
			set
			{
				this.OnPropertyValueChange(_.fax,_fax,value);
				this._fax=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ResumeAndPerform
		{
			get{ return _ResumeAndPerform; }
			set
			{
				this.OnPropertyValueChange(_.ResumeAndPerform,_ResumeAndPerform,value);
				this._ResumeAndPerform=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MainHonor
		{
			get{ return _MainHonor; }
			set
			{
				this.OnPropertyValueChange(_.MainHonor,_MainHonor,value);
				this._MainHonor=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Research
		{
			get{ return _Research; }
			set
			{
				this.OnPropertyValueChange(_.Research,_Research,value);
				this._Research=value;
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
				_.PersonID,
				_.ProjectID,
				_.OrganID,
				_.Name,
				_.Sex,
				_.DateBirth,
				_.Job,
				_.Education,
				_.Major,
				_.Title,
				_.WorkYears,
				_.CertificatNO,
				_.Isregister,
				_.ChangeContent,
				_.IDType,
				_.IDNum,
				_.Nation,
				_.Email,
				_.TelePhone,
				_.LocateProvince,
				_.Postcode,
				_.MailAddress,
				_.EducationalBack,
				_.GraduDate,
				_.WorkTime,
				_.EvaluTime,
				_.OfficePhone,
				_.fax,
				_.ResumeAndPerform,
				_.MainHonor,
				_.Research};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._PersonID,
				this._ProjectID,
				this._OrganID,
				this._Name,
				this._Sex,
				this._DateBirth,
				this._Job,
				this._Education,
				this._Major,
				this._Title,
				this._WorkYears,
				this._CertificatNO,
				this._Isregister,
				this._ChangeContent,
				this._IDType,
				this._IDNum,
				this._Nation,
				this._Email,
				this._TelePhone,
				this._LocateProvince,
				this._Postcode,
				this._MailAddress,
				this._EducationalBack,
				this._GraduDate,
				this._WorkTime,
				this._EvaluTime,
				this._OfficePhone,
				this._fax,
				this._ResumeAndPerform,
				this._MainHonor,
				this._Research};
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
			public readonly static Field All = new Field("*","BUS_Tester");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID","BUS_Tester","ID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field PersonID = new Field("PersonID","BUS_Tester","PersonID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ProjectID = new Field("ProjectID","BUS_Tester","ProjectID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OrganID = new Field("OrganID","BUS_Tester","OrganID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Name = new Field("Name","BUS_Tester","Name");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Sex = new Field("Sex","BUS_Tester","Sex");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field DateBirth = new Field("DateBirth","BUS_Tester","DateBirth");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Job = new Field("Job","BUS_Tester","Job");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Education = new Field("Education","BUS_Tester","Education");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Major = new Field("Major","BUS_Tester","Major");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Title = new Field("Title","BUS_Tester","Title");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field WorkYears = new Field("WorkYears","BUS_Tester","WorkYears");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CertificatNO = new Field("CertificatNO","BUS_Tester","CertificatNO");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Isregister = new Field("Isregister","BUS_Tester","Isregister");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ChangeContent = new Field("ChangeContent","BUS_Tester","ChangeContent");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IDType = new Field("IDType","BUS_Tester","IDType");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field IDNum = new Field("IDNum","BUS_Tester","IDNum");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Nation = new Field("Nation","BUS_Tester","Nation");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Email = new Field("Email","BUS_Tester","Email");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field TelePhone = new Field("TelePhone","BUS_Tester","TelePhone");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field LocateProvince = new Field("LocateProvince","BUS_Tester","LocateProvince");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Postcode = new Field("Postcode","BUS_Tester","Postcode");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field MailAddress = new Field("MailAddress","BUS_Tester","MailAddress");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field EducationalBack = new Field("EducationalBack","BUS_Tester","EducationalBack");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field GraduDate = new Field("GraduDate","BUS_Tester","GraduDate");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field WorkTime = new Field("WorkTime","BUS_Tester","WorkTime");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field EvaluTime = new Field("EvaluTime","BUS_Tester","EvaluTime");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OfficePhone = new Field("OfficePhone","BUS_Tester","OfficePhone");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field fax = new Field("fax","BUS_Tester","fax");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ResumeAndPerform = new Field("ResumeAndPerform","BUS_Tester","ResumeAndPerform");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field MainHonor = new Field("MainHonor","BUS_Tester","MainHonor");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Research = new Field("Research","BUS_Tester","Research");
		}
		#endregion

	}
}

