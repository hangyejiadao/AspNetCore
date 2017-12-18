/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Business
 * 类名称：BUS_BannerType
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
    /// 实体类BUS_BannerType 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("BUS_BannerType")]
    [Serializable]
    public partial class BUS_BannerType : Entity
    {
        #region Model
        private Guid _BannerTypeId;
        private Guid? _CompanyId;
        private string _BannerTypeName;
        private int? _SortNo;
        private int _IsEnable = 1;
        private string _Desc;
        private int _Status;
        private DateTime _CrtTime;
        private Guid _CrtOptId;
        private DateTime? _ModTime;
        private Guid? _ModOptId;
        /// <summary>
        /// 
        /// </summary>
        public Guid BannerTypeId
        {
            get { return _BannerTypeId; }
            set
            {
                this.OnPropertyValueChange(_.BannerTypeId, _BannerTypeId, value);
                this._BannerTypeId = value;
            }
        }
        /// <summary>
        /// 公司Id
        /// </summary>
        public Guid? CompanyId
        {
            get { return _CompanyId; }
            set
            {
                this.OnPropertyValueChange(_.CompanyId, _CompanyId, value);
                this._CompanyId = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BannerTypeName
        {
            get { return _BannerTypeName; }
            set
            {
                this.OnPropertyValueChange(_.BannerTypeName, _BannerTypeName, value);
                this._BannerTypeName = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SortNo
        {
            get { return _SortNo; }
            set
            {
                this.OnPropertyValueChange(_.SortNo, _SortNo, value);
                this._SortNo = value;
            }
        }
        /// <summary>
        /// _1：是（默认）     0：否
        /// </summary>
        public int IsEnable
        {
            get { return _IsEnable; }
            set
            {
                this.OnPropertyValueChange(_.IsEnable, _IsEnable, value);
                this._IsEnable = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Desc
        {
            get { return _Desc; }
            set
            {
                this.OnPropertyValueChange(_.Desc, _Desc, value);
                this._Desc = value;
            }
        }
        /// <summary>
        /// _1：正常数据（默认）     0：已删除数据
        /// </summary>
        public int Status
        {
            get { return _Status; }
            set
            {
                this.OnPropertyValueChange(_.Status, _Status, value);
                this._Status = value;
            }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CrtTime
        {
            get { return _CrtTime; }
            set
            {
                this.OnPropertyValueChange(_.CrtTime, _CrtTime, value);
                this._CrtTime = value;
            }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public Guid CrtOptId
        {
            get { return _CrtOptId; }
            set
            {
                this.OnPropertyValueChange(_.CrtOptId, _CrtOptId, value);
                this._CrtOptId = value;
            }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModTime
        {
            get { return _ModTime; }
            set
            {
                this.OnPropertyValueChange(_.ModTime, _ModTime, value);
                this._ModTime = value;
            }
        }
        /// <summary>
        /// 修改人
        /// </summary>
        public Guid? ModOptId
        {
            get { return _ModOptId; }
            set
            {
                this.OnPropertyValueChange(_.ModOptId, _ModOptId, value);
                this._ModOptId = value;
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
				_.BannerTypeId};
        }
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
				_.BannerTypeId,
				_.CompanyId,
				_.BannerTypeName,
				_.SortNo,
				_.IsEnable,
				_.Desc,
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
				this._BannerTypeId,
				this._CompanyId,
				this._BannerTypeName,
				this._SortNo,
				this._IsEnable,
				this._Desc,
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
            public readonly static Field All = new Field("*", "BUS_BannerType");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field BannerTypeId = new Field("BannerTypeId", "BUS_BannerType", "BannerTypeId");
            /// <summary>
            /// 公司Id
            /// </summary>
            public readonly static Field CompanyId = new Field("CompanyId", "BUS_BannerType", "公司Id");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field BannerTypeName = new Field("BannerTypeName", "BUS_BannerType", "BannerTypeName");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field SortNo = new Field("SortNo", "BUS_BannerType", "SortNo");
            /// <summary>
            /// _1：是（默认）     0：否
            /// </summary>
            public readonly static Field IsEnable = new Field("IsEnable", "BUS_BannerType", "_1：是（默认）     0：否");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Desc = new Field("Desc", "BUS_BannerType", "Desc");
            /// <summary>
            /// _1：正常数据（默认）     0：已删除数据
            /// </summary>
            public readonly static Field Status = new Field("Status", "BUS_BannerType", "_1：正常数据（默认）     0：已删除数据");
            /// <summary>
            /// 创建时间
            /// </summary>
            public readonly static Field CrtTime = new Field("CrtTime", "BUS_BannerType", "创建时间");
            /// <summary>
            /// 创建人
            /// </summary>
            public readonly static Field CrtOptId = new Field("CrtOptId", "BUS_BannerType", "创建人");
            /// <summary>
            /// 修改时间
            /// </summary>
            public readonly static Field ModTime = new Field("ModTime", "BUS_BannerType", "修改时间");
            /// <summary>
            /// 修改人
            /// </summary>
            public readonly static Field ModOptId = new Field("ModOptId", "BUS_BannerType", "修改人");
        }
        #endregion

    }
}

