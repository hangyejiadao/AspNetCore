/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Model.Base
 * 类名称：OperateModel
 * 创建时间：2016-06-14 15:04:20
 * 创建人：Quber
 * 创建说明：数据操作结果实体
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Runtime.Serialization;
using Dos.ORM.Common.Enums;
using System.Collections.Generic;

namespace Dos.ORM.Model.Base
{
    /// <summary>
    /// 数据操作结果实体
    /// </summary>
    [Serializable]
    [DataContract]
    public class OperateModel
    {

        public OperateModel()
        {
            
        }

        public OperateModel(OperateRetType result, string msg)
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
        /// 返回对象
        /// </summary>
        [DataMember]
        public object Data { get; set; }
    }

    /// <summary>
    /// 数据操作结果实体
    /// </summary>
    [Serializable]
    [DataContract]
    public class OperateList<T> where T : class
    {

        public OperateList()
        {

        }

        public OperateList(OperateRetType result, string msg)
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
        public OperateRetType Result
        {
            get { return _result; }
            set { _result = value; }
        }

        /// <summary>
        /// 提示信息
        /// </summary>
        [DataMember]
        public string Msg
        {
            get { return _msg; }
            set { _msg = value; }
        }

        /// <summary>
        /// 返回对象
        /// </summary>
        [DataMember]
        public List<T> Data { get; set; }
    }

    /// <summary>
    /// 数据操作结果实体-分布返回数据
    /// </summary>
    [Serializable]
    [DataContract]
    public class OperateModel<T> where T : class
    {

        public OperateModel()
        {

        }

        public OperateModel(OperateRetType result, string msg)
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
        public OperateRetType Result
        {
            get { return _result; }
            set { _result = value; }
        }

        /// <summary>
        /// 提示信息
        /// </summary>
        [DataMember]
        public string Msg
        {
            get { return _msg; }
            set { _msg = value; }
        }

        /// <summary>
        /// 返回对象
        /// </summary>
        [DataMember]
        public DgListModel<T> Data { get; set; }
    }
    /// <summary>
    /// 数据操作结果实体
    /// </summary>
    [Serializable]
    [DataContract]
    public class OperateModel1<T> where T : class
    {

        public OperateModel1()
        {

        }

        public OperateModel1(OperateRetType result, string msg)
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
        public OperateRetType Result
        {
            get { return _result; }
            set { _result = value; }
        }

        /// <summary>
        /// 提示信息
        /// </summary>
        [DataMember]
        public string Msg
        {
            get { return _msg; }
            set { _msg = value; }
        }

        /// <summary>
        /// 返回对象
        /// </summary>
        [DataMember]
        public T Data { get; set; }
    }   
}
