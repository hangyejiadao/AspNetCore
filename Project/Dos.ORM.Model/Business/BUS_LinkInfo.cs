/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_LinkInfo
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
	/// 实体类BUS_LinkInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BUS_LinkInfo")]
	[Serializable]
	public partial class BUS_LinkInfo : Entity 
	{
		#region Model
		private Guid _LinkInfoId;
		private Guid? _LinkTypeId;
		private Guid? _CompanyId;
		private string _LinkInfoName;
		private int? _ImgWidth;
		private int? _ImgHeight;
		private string _ImgPath;
		private string _Url;
		private string _Desc;
		private int? _SortNo;
		private int? _IsTop=0;
		private int _IsEnable=1;
		private int _Status;
		private DateTime _CrtTime;
		private Guid _CrtOptId;
		private DateTime? _ModTime;
		private Guid? _ModOptId;
		/// <summary>
		/// 
		/// </summary>
		public Guid LinkInfoId
		{
			get{ return _LinkInfoId; }
			set
			{
				this.OnPropertyValueChange(_.LinkInfoId,_LinkInfoId,value);
				this._LinkInfoId=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid? LinkTypeId
		{
			get{ return _LinkTypeId; }
			set
			{
				this.OnPropertyValueChange(_.LinkTypeId,_LinkTypeId,value);
				this._LinkTypeId=value;
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
		public string LinkInfoName
		{
			get{ return _LinkInfoName; }
			set
			{
				this.OnPropertyValueChange(_.LinkInfoName,_LinkInfoName,value);
				this._LinkInfoName=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ImgWidth
		{
			get{ return _ImgWidth; }
			set
			{
				this.OnPropertyValueChange(_.ImgWidth,_ImgWidth,value);
				this._ImgWidth=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ImgHeight
		{
			get{ return _ImgHeight; }
			set
			{
				this.OnPropertyValueChange(_.ImgHeight,_ImgHeight,value);
				this._ImgHeight=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImgPath
		{
			get{ return _ImgPath; }
			set
			{
				this.OnPropertyValueChange(_.ImgPath,_ImgPath,value);
				this._ImgPath=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Url
		{
			get{ return _Url; }
			set
			{
				this.OnPropertyValueChange(_.Url,_Url,value);
				this._Url=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Desc
		{
			get{ return _Desc; }
			set
			{
				this.OnPropertyValueChange(_.Desc,_Desc,value);
				this._Desc=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SortNo
		{
			get{ return _SortNo; }
			set
			{
				this.OnPropertyValueChange(_.SortNo,_SortNo,value);
				this._SortNo=value;
			}
		}
		/// <summary>
		/// _1：是     0：否（默认）
		/// </summary>
		public int? IsTop
		{
			get{ return _IsTop; }
			set
			{
				this.OnPropertyValueChange(_.IsTop,_IsTop,value);
				this._IsTop=value;
			}
		}
		/// <summary>
		/// _1：是（默认）     0：否
		/// </summary>
		public int IsEnable
		{
			get{ return _IsEnable; }
			set
			{
				this.OnPropertyValueChange(_.IsEnable,_IsEnable,value);
				this._IsEnable=value;
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
				_.LinkInfoId};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.LinkInfoId,
				_.LinkTypeId,
				_.CompanyId,
				_.LinkInfoName,
				_.ImgWidth,
				_.ImgHeight,
				_.ImgPath,
				_.Url,
				_.Desc,
				_.SortNo,
				_.IsTop,
				_.IsEnable,
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
				this._LinkInfoId,
				this._LinkTypeId,
				this._CompanyId,
				this._LinkInfoName,
				this._ImgWidth,
				this._ImgHeight,
				this._ImgPath,
				this._Url,
				this._Desc,
				this._SortNo,
				this._IsTop,
				this._IsEnable,
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
			public readonly static Field All = new Field("*","BUS_LinkInfo");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field LinkInfoId = new Field("LinkInfoId","BUS_LinkInfo","LinkInfoId");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field LinkTypeId = new Field("LinkTypeId","BUS_LinkInfo","LinkTypeId");
			/// <summary>
			/// 公司Id
			/// </summary>
			public readonly static Field CompanyId = new Field("CompanyId","BUS_LinkInfo","公司Id");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field LinkInfoName = new Field("LinkInfoName","BUS_LinkInfo","LinkInfoName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ImgWidth = new Field("ImgWidth","BUS_LinkInfo","ImgWidth");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ImgHeight = new Field("ImgHeight","BUS_LinkInfo","ImgHeight");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ImgPath = new Field("ImgPath","BUS_LinkInfo","ImgPath");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Url = new Field("Url","BUS_LinkInfo","Url");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Desc = new Field("Desc","BUS_LinkInfo","Desc");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field SortNo = new Field("SortNo","BUS_LinkInfo","SortNo");
			/// <summary>
			/// _1：是     0：否（默认）
			/// </summary>
			public readonly static Field IsTop = new Field("IsTop","BUS_LinkInfo","_1：是     0：否（默认）");
			/// <summary>
			/// _1：是（默认）     0：否
			/// </summary>
			public readonly static Field IsEnable = new Field("IsEnable","BUS_LinkInfo","_1：是（默认）     0：否");
			/// <summary>
			/// _1：正常数据（默认）     0：已删除数据
			/// </summary>
			public readonly static Field Status = new Field("Status","BUS_LinkInfo","_1：正常数据（默认）     0：已删除数据");
			/// <summary>
			/// 创建时间
			/// </summary>
			public readonly static Field CrtTime = new Field("CrtTime","BUS_LinkInfo","创建时间");
			/// <summary>
			/// 创建人
			/// </summary>
			public readonly static Field CrtOptId = new Field("CrtOptId","BUS_LinkInfo","创建人");
			/// <summary>
			/// 修改时间
			/// </summary>
			public readonly static Field ModTime = new Field("ModTime","BUS_LinkInfo","修改时间");
			/// <summary>
			/// 修改人
			/// </summary>
			public readonly static Field ModOptId = new Field("ModOptId","BUS_LinkInfo","修改人");
		}
		#endregion

	}
}

