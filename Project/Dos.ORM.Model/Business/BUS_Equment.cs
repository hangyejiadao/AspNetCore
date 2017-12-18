/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_Equment
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
	/// 实体类BUS_Equment 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BUS_Equment")]
	public partial class BUS_Equment : Entity 
	{

        //扩展字段
        public string FilePath
        {
            get;
            set;
        }


		#region Model
		private Guid _ID;
		private Guid _EquipmentID;
		private Guid? _ProjectID;
		private Guid? _OrganID;
		private string _EquipmentNO;
		private string _EquipmentName;
		private string _Type;
		private string _BelongDepartment;
		private string _Depositary;
		private string _MeasurePrecision;
		private string _MeasureRange;
		private string _Specs;
		private string _ResolvingPower;
		private string _Unit;
		private int? _Amount;
		private decimal? _UnitPrice;
		private DateTime? _BuyDate;
		private DateTime? _LeaveFactoryDate;
		private string _LeaveFactoryCode;
		private string _FactoryName;
		private string _Manager;
		private string _Dealer;
		private string _State;
		private string _Note;
		private DateTime? _CheckDate;
		private DateTime? _NextCheckDate;
		private int? _ifsubmit;
		private string _meterageAdmin;
		private string _RangeSize;
		private string _TechnicalParameter;

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
		public Guid EquipmentID
		{
			get{ return _EquipmentID; }
			set
			{
				this.OnPropertyValueChange(_.EquipmentID,_EquipmentID,value);
				this._EquipmentID=value;
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
		public string EquipmentNO
		{
			get{ return _EquipmentNO; }
			set
			{
				this.OnPropertyValueChange(_.EquipmentNO,_EquipmentNO,value);
				this._EquipmentNO=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EquipmentName
		{
			get{ return _EquipmentName; }
			set
			{
				this.OnPropertyValueChange(_.EquipmentName,_EquipmentName,value);
				this._EquipmentName=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Type
		{
			get{ return _Type; }
			set
			{
				this.OnPropertyValueChange(_.Type,_Type,value);
				this._Type=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BelongDepartment
		{
			get{ return _BelongDepartment; }
			set
			{
				this.OnPropertyValueChange(_.BelongDepartment,_BelongDepartment,value);
				this._BelongDepartment=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Depositary
		{
			get{ return _Depositary; }
			set
			{
				this.OnPropertyValueChange(_.Depositary,_Depositary,value);
				this._Depositary=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MeasurePrecision
		{
			get{ return _MeasurePrecision; }
			set
			{
				this.OnPropertyValueChange(_.MeasurePrecision,_MeasurePrecision,value);
				this._MeasurePrecision=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MeasureRange
		{
			get{ return _MeasureRange; }
			set
			{
				this.OnPropertyValueChange(_.MeasureRange,_MeasureRange,value);
				this._MeasureRange=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Specs
		{
			get{ return _Specs; }
			set
			{
				this.OnPropertyValueChange(_.Specs,_Specs,value);
				this._Specs=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ResolvingPower
		{
			get{ return _ResolvingPower; }
			set
			{
				this.OnPropertyValueChange(_.ResolvingPower,_ResolvingPower,value);
				this._ResolvingPower=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Unit
		{
			get{ return _Unit; }
			set
			{
				this.OnPropertyValueChange(_.Unit,_Unit,value);
				this._Unit=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Amount
		{
			get{ return _Amount; }
			set
			{
				this.OnPropertyValueChange(_.Amount,_Amount,value);
				this._Amount=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? UnitPrice
		{
			get{ return _UnitPrice; }
			set
			{
				this.OnPropertyValueChange(_.UnitPrice,_UnitPrice,value);
				this._UnitPrice=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? BuyDate
		{
			get{ return _BuyDate; }
			set
			{
				this.OnPropertyValueChange(_.BuyDate,_BuyDate,value);
				this._BuyDate=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LeaveFactoryDate
		{
			get{ return _LeaveFactoryDate; }
			set
			{
				this.OnPropertyValueChange(_.LeaveFactoryDate,_LeaveFactoryDate,value);
				this._LeaveFactoryDate=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LeaveFactoryCode
		{
			get{ return _LeaveFactoryCode; }
			set
			{
				this.OnPropertyValueChange(_.LeaveFactoryCode,_LeaveFactoryCode,value);
				this._LeaveFactoryCode=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FactoryName
		{
			get{ return _FactoryName; }
			set
			{
				this.OnPropertyValueChange(_.FactoryName,_FactoryName,value);
				this._FactoryName=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Manager
		{
			get{ return _Manager; }
			set
			{
				this.OnPropertyValueChange(_.Manager,_Manager,value);
				this._Manager=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Dealer
		{
			get{ return _Dealer; }
			set
			{
				this.OnPropertyValueChange(_.Dealer,_Dealer,value);
				this._Dealer=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string State
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
		public DateTime? CheckDate
		{
			get{ return _CheckDate; }
			set
			{
				this.OnPropertyValueChange(_.CheckDate,_CheckDate,value);
				this._CheckDate=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? NextCheckDate
		{
			get{ return _NextCheckDate; }
			set
			{
				this.OnPropertyValueChange(_.NextCheckDate,_NextCheckDate,value);
				this._NextCheckDate=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ifsubmit
		{
			get{ return _ifsubmit; }
			set
			{
				this.OnPropertyValueChange(_.ifsubmit,_ifsubmit,value);
				this._ifsubmit=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string meterageAdmin
		{
			get{ return _meterageAdmin; }
			set
			{
				this.OnPropertyValueChange(_.meterageAdmin,_meterageAdmin,value);
				this._meterageAdmin=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RangeSize
		{
			get{ return _RangeSize; }
			set
			{
				this.OnPropertyValueChange(_.RangeSize,_RangeSize,value);
				this._RangeSize=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TechnicalParameter
		{
			get{ return _TechnicalParameter; }
			set
			{
				this.OnPropertyValueChange(_.TechnicalParameter,_TechnicalParameter,value);
				this._TechnicalParameter=value;
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
				_.EquipmentID,
				_.ProjectID,
				_.OrganID,
				_.EquipmentNO,
				_.EquipmentName,
				_.Type,
				_.BelongDepartment,
				_.Depositary,
				_.MeasurePrecision,
				_.MeasureRange,
				_.Specs,
				_.ResolvingPower,
				_.Unit,
				_.Amount,
				_.UnitPrice,
				_.BuyDate,
				_.LeaveFactoryDate,
				_.LeaveFactoryCode,
				_.FactoryName,
				_.Manager,
				_.Dealer,
				_.State,
				_.Note,
				_.CheckDate,
				_.NextCheckDate,
				_.ifsubmit,
				_.meterageAdmin,
				_.RangeSize,
				_.TechnicalParameter};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._EquipmentID,
				this._ProjectID,
				this._OrganID,
				this._EquipmentNO,
				this._EquipmentName,
				this._Type,
				this._BelongDepartment,
				this._Depositary,
				this._MeasurePrecision,
				this._MeasureRange,
				this._Specs,
				this._ResolvingPower,
				this._Unit,
				this._Amount,
				this._UnitPrice,
				this._BuyDate,
				this._LeaveFactoryDate,
				this._LeaveFactoryCode,
				this._FactoryName,
				this._Manager,
				this._Dealer,
				this._State,
				this._Note,
				this._CheckDate,
				this._NextCheckDate,
				this._ifsubmit,
				this._meterageAdmin,
				this._RangeSize,
				this._TechnicalParameter};
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
			public readonly static Field All = new Field("*","BUS_Equment");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID","BUS_Equment","ID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field EquipmentID = new Field("EquipmentID","BUS_Equment","EquipmentID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ProjectID = new Field("ProjectID","BUS_Equment","ProjectID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field OrganID = new Field("OrganID","BUS_Equment","OrganID");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field EquipmentNO = new Field("EquipmentNO","BUS_Equment","EquipmentNO");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field EquipmentName = new Field("EquipmentName","BUS_Equment","EquipmentName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Type = new Field("Type","BUS_Equment","Type");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field BelongDepartment = new Field("BelongDepartment","BUS_Equment","BelongDepartment");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Depositary = new Field("Depositary","BUS_Equment","Depositary");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field MeasurePrecision = new Field("MeasurePrecision","BUS_Equment","MeasurePrecision");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field MeasureRange = new Field("MeasureRange","BUS_Equment","MeasureRange");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Specs = new Field("Specs","BUS_Equment","Specs");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ResolvingPower = new Field("ResolvingPower","BUS_Equment","ResolvingPower");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Unit = new Field("Unit","BUS_Equment","Unit");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Amount = new Field("Amount","BUS_Equment","Amount");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field UnitPrice = new Field("UnitPrice","BUS_Equment","UnitPrice");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field BuyDate = new Field("BuyDate","BUS_Equment","BuyDate");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field LeaveFactoryDate = new Field("LeaveFactoryDate","BUS_Equment","LeaveFactoryDate");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field LeaveFactoryCode = new Field("LeaveFactoryCode","BUS_Equment","LeaveFactoryCode");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field FactoryName = new Field("FactoryName","BUS_Equment","FactoryName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Manager = new Field("Manager","BUS_Equment","Manager");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Dealer = new Field("Dealer","BUS_Equment","Dealer");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field State = new Field("State","BUS_Equment","State");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Note = new Field("Note","BUS_Equment","Note");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field CheckDate = new Field("CheckDate","BUS_Equment","CheckDate");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field NextCheckDate = new Field("NextCheckDate","BUS_Equment","NextCheckDate");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ifsubmit = new Field("ifsubmit","BUS_Equment","ifsubmit");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field meterageAdmin = new Field("meterageAdmin","BUS_Equment","meterageAdmin");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field RangeSize = new Field("RangeSize","BUS_Equment","RangeSize");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field TechnicalParameter = new Field("TechnicalParameter","BUS_Equment","TechnicalParameter");
		}
		#endregion

	}
}

