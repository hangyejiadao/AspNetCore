using System;
using System.Runtime.Serialization;
using Dos.ORM.Common.Enums;
using Dos.ORM.Model.Business;

namespace Dos.ORM.Model.Base
{
    /// <summary>
    /// 登录结果实体
    /// </summary>
    [Serializable]
    [DataContract]
    public class LoginModel
    {
        public LoginModel()
        {
            
        }

         public LoginModel(OperateRetType result, string msg)
        {
            this._result = result;
            this._msg = msg;
        }

        private OperateRetType _result = OperateRetType.Fail;
        private string _msg = "操作失败！";

        /// <summary>
        /// 操作结果
        /// </summary>
        [DataMember]
        public OperateRetType Result {
            get { return _result; }
            set { _result = value; }
        }

        /// <summary>
        /// 提示信息
        /// </summary>
        [DataMember]
        public string Msg {
            get { return _msg; }
            set { _msg = value; }
        }

        /// <summary>
        /// 登录用户信息
        /// </summary>
        [DataMember]
        public BUS_User User { get; set; }

        /// <summary>
        /// 角色信息
        /// </summary>
        [DataMember]
        public BUS_Role Role { get; set; }

        /// <summary>
        /// 角色信息
        /// </summary>
        [DataMember]
        public BUS_UserRole UserRole { get; set; }  

    }
}
