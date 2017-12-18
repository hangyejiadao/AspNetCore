/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_Laboratory
 * 创建时间：2017-02-09 15:42:09
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
    /// 实体类BUS_Laboratory 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("BUS_Laboratory")]
    public partial class BUS_Laboratory : Entity
    {
        public int? OrderNum { get; set; }

        #region Model
        private Guid _ID;
        private Guid? _OrganID;
        private string _OrganName;
        private string _OrganShorName;
        private string _CompanyName;
        private string _CompanyCertificate;
        private string _CertificateCode;
        private DateTime? _LabCreateDate;
        private int? _EngineerNumber;
        private int? _TestNumber;
        private int? _SeniorTitleNumber;
        private string _DirectorName;
        private string _DirectorCertificate;
        private string _Title;
        private string _Mobile;
        private string _Add;
        private string _Tel;
        private decimal? _Area;
        private string _BusinessRange;
        private string _Code;
        /// <summary>
        /// 
        /// </summary>
        public Guid ID
        {
            get { return _ID; }
            set
            {
                this.OnPropertyValueChange(_.ID, _ID, value);
                this._ID = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid? OrganID
        {
            get { return _OrganID; }
            set
            {
                this.OnPropertyValueChange(_.OrganID, _OrganID, value);
                this._OrganID = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrganName
        {
            get { return _OrganName; }
            set
            {
                this.OnPropertyValueChange(_.OrganName, _OrganName, value);
                this._OrganName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrganShorName
        {
            get { return _OrganShorName; }
            set
            {
                this.OnPropertyValueChange(_.OrganShorName, _OrganShorName, value);
                this._OrganShorName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CompanyName
        {
            get { return _CompanyName; }
            set
            {
                this.OnPropertyValueChange(_.CompanyName, _CompanyName, value);
                this._CompanyName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CompanyCertificate
        {
            get { return _CompanyCertificate; }
            set
            {
                this.OnPropertyValueChange(_.CompanyCertificate, _CompanyCertificate, value);
                this._CompanyCertificate = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CertificateCode
        {
            get { return _CertificateCode; }
            set
            {
                this.OnPropertyValueChange(_.CertificateCode, _CertificateCode, value);
                this._CertificateCode = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LabCreateDate
        {
            get { return _LabCreateDate; }
            set
            {
                this.OnPropertyValueChange(_.LabCreateDate, _LabCreateDate, value);
                this._LabCreateDate = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? EngineerNumber
        {
            get { return _EngineerNumber; }
            set
            {
                this.OnPropertyValueChange(_.EngineerNumber, _EngineerNumber, value);
                this._EngineerNumber = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TestNumber
        {
            get { return _TestNumber; }
            set
            {
                this.OnPropertyValueChange(_.TestNumber, _TestNumber, value);
                this._TestNumber = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SeniorTitleNumber
        {
            get { return _SeniorTitleNumber; }
            set
            {
                this.OnPropertyValueChange(_.SeniorTitleNumber, _SeniorTitleNumber, value);
                this._SeniorTitleNumber = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DirectorName
        {
            get { return _DirectorName; }
            set
            {
                this.OnPropertyValueChange(_.DirectorName, _DirectorName, value);
                this._DirectorName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DirectorCertificate
        {
            get { return _DirectorCertificate; }
            set
            {
                this.OnPropertyValueChange(_.DirectorCertificate, _DirectorCertificate, value);
                this._DirectorCertificate = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            get { return _Title; }
            set
            {
                this.OnPropertyValueChange(_.Title, _Title, value);
                this._Title = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mobile
        {
            get { return _Mobile; }
            set
            {
                this.OnPropertyValueChange(_.Mobile, _Mobile, value);
                this._Mobile = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Add
        {
            get { return _Add; }
            set
            {
                this.OnPropertyValueChange(_.Add, _Add, value);
                this._Add = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tel
        {
            get { return _Tel; }
            set
            {
                this.OnPropertyValueChange(_.Tel, _Tel, value);
                this._Tel = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Area
        {
            get { return _Area; }
            set
            {
                this.OnPropertyValueChange(_.Area, _Area, value);
                this._Area = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BusinessRange
        {
            get { return _BusinessRange; }
            set
            {
                this.OnPropertyValueChange(_.BusinessRange, _BusinessRange, value);
                this._BusinessRange = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Code
        {
            get { return _Code; }
            set
            {
                this.OnPropertyValueChange(_.Code, _Code, value);
                this._Code = value;
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
				_.OrganID,
				_.OrganName,
				_.OrganShorName,
				_.CompanyName,
				_.CompanyCertificate,
				_.CertificateCode,
				_.LabCreateDate,
				_.EngineerNumber,
				_.TestNumber,
				_.SeniorTitleNumber,
				_.DirectorName,
				_.DirectorCertificate,
				_.Title,
				_.Mobile,
				_.Add,
				_.Tel,
				_.Area,
				_.BusinessRange,
				_.Code};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
				this._ID,
				this._OrganID,
				this._OrganName,
				this._OrganShorName,
				this._CompanyName,
				this._CompanyCertificate,
				this._CertificateCode,
				this._LabCreateDate,
				this._EngineerNumber,
				this._TestNumber,
				this._SeniorTitleNumber,
				this._DirectorName,
				this._DirectorCertificate,
				this._Title,
				this._Mobile,
				this._Add,
				this._Tel,
				this._Area,
				this._BusinessRange,
				this._Code};
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
            public readonly static Field All = new Field("*", "BUS_Laboratory");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ID = new Field("ID", "BUS_Laboratory", "ID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field OrganID = new Field("OrganID", "BUS_Laboratory", "OrganID");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field OrganName = new Field("OrganName", "BUS_Laboratory", "OrganName");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field OrganShorName = new Field("OrganShorName", "BUS_Laboratory", "OrganShorName");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field CompanyName = new Field("CompanyName", "BUS_Laboratory", "CompanyName");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field CompanyCertificate = new Field("CompanyCertificate", "BUS_Laboratory", "CompanyCertificate");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field CertificateCode = new Field("CertificateCode", "BUS_Laboratory", "CertificateCode");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field LabCreateDate = new Field("LabCreateDate", "BUS_Laboratory", "LabCreateDate");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field EngineerNumber = new Field("EngineerNumber", "BUS_Laboratory", "EngineerNumber");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field TestNumber = new Field("TestNumber", "BUS_Laboratory", "TestNumber");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field SeniorTitleNumber = new Field("SeniorTitleNumber", "BUS_Laboratory", "SeniorTitleNumber");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DirectorName = new Field("DirectorName", "BUS_Laboratory", "DirectorName");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field DirectorCertificate = new Field("DirectorCertificate", "BUS_Laboratory", "DirectorCertificate");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Title = new Field("Title", "BUS_Laboratory", "Title");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Mobile = new Field("Mobile", "BUS_Laboratory", "Mobile");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Add = new Field("Add", "BUS_Laboratory", "Add");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Tel = new Field("Tel", "BUS_Laboratory", "Tel");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Area = new Field("Area", "BUS_Laboratory", "Area");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field BusinessRange = new Field("BusinessRange", "BUS_Laboratory", "BusinessRange");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Code = new Field("Code", "BUS_Laboratory", "Code");
        }
        #endregion

    }
}

