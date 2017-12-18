/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.IData.Base
 * 类名称：IDBBase
 * 创建时间：2016-09-21 14:28:47
 * 创建人：Quber
 * 创建说明：数据操作继承的接口基类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using Dos.ORM.Model.Base;

namespace Dos.ORM.IData.Base
{
    /// <summary>
    /// 数据操作继承的接口基类
    /// </summary>
    public interface IDBBase<T> where T : Entity, new()
    {
        #region 共有
        #region 获取排序条件、等
        /// <summary>
        /// 获取排序条件
        /// </summary>
        /// <param name="columnName">排序列名</param>
        /// <param name="orderType">排序方式（asc、desc）</param>
        /// <returns></returns>
        OrderByClip GetOrderByClip(string columnName, string orderType = "desc");

        /// <summary>
        /// 获取排序条件（easyui datagrid所需）
        /// </summary>
        /// <param name="dgCon"></param>
        /// <returns></returns>
        OrderByClip GetOrderByClip(DgConModel dgCon);
        #endregion

        #region 添加、修改、删除

        /// <summary>
        /// 添加单条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        OperateModel InsertModel(T model, DbTrans trans = null);

        /// <summary>
        /// 添加多条数据
        /// </summary>
        /// <param name="models">数据实体集合</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        OperateModel InsertModels(List<T> models, DbTrans trans = null);

        /// <summary>
        /// 修改单条数据
        /// </summary>
        /// <param name="model">修改的实体</param>
        /// <param name="whereLambda">修改条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        OperateModel UpdateModel(T model, Expression<Func<T, bool>> whereLambda, DbTrans trans = null);

        /// <summary>
        /// 修改单条数据的某一个字段（Field字段类型）
        /// </summary>
        /// <param name="field">修改的字段</param>
        /// <param name="value">修改的值</param>
        /// <param name="whereLambda">修改条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        OperateModel UpdateModel(Field field, object value, Expression<Func<T, bool>> whereLambda, DbTrans trans = null);

        /// <summary>
        /// 修改单条数据的某一个字段（string字段类型）
        /// </summary>
        /// <param name="field">修改的字段（不区分大小写）</param>
        /// <param name="value">修改的值</param>
        /// <param name="whereLambda">修改条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        OperateModel UpdateModel(string field, object value, Expression<Func<T, bool>> whereLambda, DbTrans trans = null);

        /// <summary>
        /// 修改多条数据
        /// </summary>
        /// <param name="models">修改的实体集合</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        OperateModel UpdateModels(List<T> models, DbTrans trans = null);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="whereLambda">删除条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        OperateModel DeleteModel(Expression<Func<T, bool>> whereLambda, DbTrans trans = null);

        /// <summary>
        /// 删除数据（指定实体）
        /// </summary>
        /// <typeparam name="TO">实体</typeparam>
        /// <param name="whereLambda">删除条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        OperateModel DeleteModelOther<TO>(Expression<Func<TO, bool>> whereLambda, DbTrans trans = null) where TO : Entity, new();

        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="models">删除的实体集合</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        OperateModel DeleteModels(List<T> models, DbTrans trans = null);

        /// <summary>
        /// 执行Sql语句（增、删、改）
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="optType">操作类型</param>
        /// <returns></returns>
        OperateModel ExecSql(string sql, string optType = "操作");
        #endregion

        #region 获取数据--Lambda表达式

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="whereLambda">查询条件（Lambda表达式）</param>
        /// <returns></returns>
        T GetModel(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 获取多条数据（返回List）
        /// </summary>
        /// <param name="whereLambda">查询条件（Lambda表达式）</param>
        /// <param name="orderBy">排序字段</param>
        /// <returns></returns>
        List<T> GetModels(Expression<Func<T, bool>> whereLambda = null, OrderByClip orderBy = null);

        /// <summary>
        /// 获取多条数据（返回DataTable）
        /// </summary>
        /// <param name="whereLambda">查询条件（Lambda表达式）</param>
        /// <param name="orderBy">排序字段</param>
        /// <returns></returns>
        DataTable GetModelsToDt(Expression<Func<T, bool>> whereLambda = null, OrderByClip orderBy = null);

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="totalCount">总条数</param>
        /// <param name="whereLambda">查询条件（Lambda表达式）</param>
        /// <param name="orderBy">排序字段</param>
        /// <param name="isPage">是否为分页（true：分页数据、false：返回所有数据）</param>
        /// <returns></returns>
        List<T> GetPages(int pageIndex, int pageSize, ref int totalCount, Expression<Func<T, bool>> whereLambda = null, OrderByClip orderBy = null, bool isPage = true);
        #endregion

        #region 获取数据--Where条件类
        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="where">查询条件（Where条件类）</param>
        /// <returns></returns>
        T GetModelWhere(Where<T> where);

        /// <summary>
        /// 获取单条数据（Sql）
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        T GetModelSql(string sql);

        /// <summary>
        /// 获取多条数据
        /// </summary>
        /// <param name="where">查询条件（Where条件类）</param>
        /// <param name="orderBy">排序字段</param>
        /// <returns></returns>
        List<T> GetModelsWhere(Where<T> where = null, OrderByClip orderBy = null);

        /// <summary>
        /// 获取多条数据（Sql）
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        List<T> GetModelsSql(string sql);

        /// <summary>
        /// 获取多条数据（Sql）
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>返回DataTable</returns>
        DataTable GetDataTableSql(string sql);

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="totalCount">总条数</param>
        /// <param name="where">查询条件（Where条件类）</param>
        /// <param name="orderBy">排序字段</param>
        /// <param name="isPage">是否为分页（true：分页数据、false：返回所有数据）</param>
        /// <returns></returns>
        List<T> GetPagesWhere(int pageIndex, int pageSize, ref int totalCount, Where<T> where = null, OrderByClip orderBy = null, bool isPage = true);
        #endregion

        #region 检查是否存在

        /// <summary>
        /// 检查某数据是否存在
        /// </summary>
        /// <param name="whereLambda">查询条件（Lambda表达式）</param>
        /// <returns></returns>
        bool IsExistEntity(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 检查某数据是否存在（Where条件类型）
        /// </summary>
        /// <param name="where">查询条件（Where条件类）</param>
        /// <returns></returns>
        bool IsExistEntityWhere(Where<T> where);

        /// <summary>
        /// 检查某数据是否存在（WhereClip条件类型）
        /// </summary>
        /// <param name="where">查询条件（Where条件类）</param>
        /// <returns></returns>
        bool IsExistEntityWhere(WhereClip where);

        /// <summary>
        /// 检查某数据是否存在（WhereClipBuilder条件类型）
        /// </summary>
        /// <param name="where">查询条件（Where条件类）</param>
        /// <returns></returns>
        bool IsExistEntityWhere(WhereClipBuilder where);
        #endregion
        #region 备份数据库

        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="backPath">备份路径，如：D:\Backup\</param>
        /// <param name="backDbName">需要备份的数据库名称</param>
        /// <param name="backName">备份后的数据库名称，不需要.bak后缀。若不传，则等同于@BackDbName</param>
        /// <param name="backPathIsDate">备份路径是否需要添加日期文件夹，默认添加</param>
        /// <param name="backNameIsTime">备份后的数据库名称是否需要追加当前时间，默认追加</param>
        /// <returns></returns>
        string BackupDb(string backPath, string backDbName, string backName = null, bool backPathIsDate = true, bool backNameIsTime = true);
        #endregion
        #endregion

        #region 共有（Web组件所需）

        /// <summary>
        /// EasyUI datagrid所需分页数据
        /// </summary>
        /// <param name="dgCon"></param>
        /// <param name="defaultOrderCol">默认排序字段（比如初始化列表的时候）</param>
        /// <param name="whereLambda">查询条件（Lambda表达式）</param>
        /// <param name="isPage">是否为分页（true：分页数据、false：返回所有数据）</param>
        /// <returns></returns>
        DgListModel<T> GetPagesForDg(DgConModel dgCon, string defaultOrderCol, Expression<Func<T, bool>> whereLambda = null, bool isPage = true);

        /// <summary>
        /// EasyUI datagrid所需分页数据
        /// </summary>
        /// <param name="dgCon"></param>
        /// <param name="defaultOrderCol">默认排序字段（比如初始化列表的时候）</param>
        /// <param name="defaultOrderType">默认排序方式（比如初始化列表的时候，desc或asc）</param>
        /// <param name="whereLambda">查询条件（Lambda表达式）</param>
        /// <param name="isPage">是否为分页（true：分页数据、false：返回所有数据）</param>
        /// <returns></returns>
        DgListModel<T> GetPagesForDg(DgConModel dgCon, string defaultOrderCol, string defaultOrderType, Expression<Func<T, bool>> whereLambda = null, bool isPage = true);

        /// <summary>
        /// EasyUI datagrid所需分页数据（存储过程）
        /// </summary>
        /// <param name="dgCon"></param>
        /// <param name="tbName">数据表或关联表，如：(SELECT a.* FROM A a LEFT JOIN B b ON a.ID=b.ID) AS TEMP</param>
        /// <param name="columns">查询列，默认为所有列*</param>
        /// <param name="where">查询条件</param>
        /// <param name="orderCols">排序字段，如：Time或Time Desc,Title</param>
        /// <param name="orderDesc">是否为降序</param>
        /// <returns></returns>
        DgListModel GetPagesForDgProc(DgConModel dgCon, string tbName, string orderCols, string where = "", bool orderDesc = true, string columns = "*");

        /// <summary>
        /// EasyUI datagrid所需分页数据
        /// </summary>
        /// <param name="dgCon"></param>
        /// <param name="where">查询条件（Where条件类）</param>
        /// <param name="isPage">是否为分页（true：分页数据、false：返回所有数据）</param>
        /// <returns></returns>
        DgListModel<T> GetPagesForDgWhere(DgConModel dgCon, Where<T> where = null, bool isPage = true);
        #endregion
    }
}
