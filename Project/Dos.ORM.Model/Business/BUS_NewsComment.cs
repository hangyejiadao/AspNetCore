/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_NewsComment
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
	/// 实体类BUS_NewsComment 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BUS_NewsComment")]
	[Serializable]
	public partial class BUS_NewsComment : Entity 
	{
		#region Model
		private Guid _评论Id;
		private Guid _NewsInfoId;
		private Guid _MemberId;
		private int? _CommentType;
		private int? _PraiseCount;
		private int? _StampCount;
		private int? _CommentStatus;
		private string _DtlInfo;
		private int _Status;
		private DateTime _CrtTime;
		/// <summary>
		/// 
		/// </summary>
		public Guid 评论Id
		{
			get{ return _评论Id; }
			set
			{
				this.OnPropertyValueChange(_.评论Id,_评论Id,value);
				this._评论Id=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid NewsInfoId
		{
			get{ return _NewsInfoId; }
			set
			{
				this.OnPropertyValueChange(_.NewsInfoId,_NewsInfoId,value);
				this._NewsInfoId=value;
			}
		}
		/// <summary>
		/// 管理员Id
		/// </summary>
		public Guid MemberId
		{
			get{ return _MemberId; }
			set
			{
				this.OnPropertyValueChange(_.MemberId,_MemberId,value);
				this._MemberId=value;
			}
		}
		/// <summary>
		/// _0：对新闻信息的评论     1：对某人的评论进行回复
		/// </summary>
		public int? CommentType
		{
			get{ return _CommentType; }
			set
			{
				this.OnPropertyValueChange(_.CommentType,_CommentType,value);
				this._CommentType=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PraiseCount
		{
			get{ return _PraiseCount; }
			set
			{
				this.OnPropertyValueChange(_.PraiseCount,_PraiseCount,value);
				this._PraiseCount=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? StampCount
		{
			get{ return _StampCount; }
			set
			{
				this.OnPropertyValueChange(_.StampCount,_StampCount,value);
				this._StampCount=value;
			}
		}
		/// <summary>
		/// _0：未审核     1：审核通过     2：审核不通过
		/// </summary>
		public int? CommentStatus
		{
			get{ return _CommentStatus; }
			set
			{
				this.OnPropertyValueChange(_.CommentStatus,_CommentStatus,value);
				this._CommentStatus=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DtlInfo
		{
			get{ return _DtlInfo; }
			set
			{
				this.OnPropertyValueChange(_.DtlInfo,_DtlInfo,value);
				this._DtlInfo=value;
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
		#endregion

		#region Method
		/// <summary>
		/// 获取实体中的主键列
		/// </summary>
		public override Field[] GetPrimaryKeyFields()
		{
			return new Field[] {
				_.评论Id};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.评论Id,
				_.NewsInfoId,
				_.MemberId,
				_.CommentType,
				_.PraiseCount,
				_.StampCount,
				_.CommentStatus,
				_.DtlInfo,
				_.Status,
				_.CrtTime};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._评论Id,
				this._NewsInfoId,
				this._MemberId,
				this._CommentType,
				this._PraiseCount,
				this._StampCount,
				this._CommentStatus,
				this._DtlInfo,
				this._Status,
				this._CrtTime};
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
			public readonly static Field All = new Field("*","BUS_NewsComment");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field 评论Id = new Field("评论Id","BUS_NewsComment","评论Id");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field NewsInfoId = new Field("NewsInfoId","BUS_NewsComment","NewsInfoId");
			/// <summary>
			/// 管理员Id
			/// </summary>
			public readonly static Field MemberId = new Field("MemberId","BUS_NewsComment","管理员Id");
			/// <summary>
			/// _0：对新闻信息的评论     1：对某人的评论进行回复
			/// </summary>
			public readonly static Field CommentType = new Field("CommentType","BUS_NewsComment","_0：对新闻信息的评论     1：对某人的评论进行回复");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field PraiseCount = new Field("PraiseCount","BUS_NewsComment","PraiseCount");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field StampCount = new Field("StampCount","BUS_NewsComment","StampCount");
			/// <summary>
			/// _0：未审核     1：审核通过     2：审核不通过
			/// </summary>
			public readonly static Field CommentStatus = new Field("CommentStatus","BUS_NewsComment","_0：未审核     1：审核通过     2：审核不通过");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field DtlInfo = new Field("DtlInfo","BUS_NewsComment","DtlInfo");
			/// <summary>
			/// _1：正常数据（默认）     0：已删除数据
			/// </summary>
			public readonly static Field Status = new Field("Status","BUS_NewsComment","_1：正常数据（默认）     0：已删除数据");
			/// <summary>
			/// 创建时间
			/// </summary>
			public readonly static Field CrtTime = new Field("CrtTime","BUS_NewsComment","创建时间");
		}
		#endregion

	}
}

