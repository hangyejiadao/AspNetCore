/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Data.Base
 * 类名称：DBBase
 * 创建时间：2016-06-15 10:49:02
 * 创建人：Quber
 * 创建说明：数据操作继承的基类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Dos.ORM.Common.Enums;
using Dos.ORM.IData.Base;
using Dos.ORM.Model.Base;

namespace Dos.ORM.Data.Base
{
    /// <summary>
    /// 数据操作继承的基类
    /// </summary>
    /// <typeparam name="T">数据实体，注意此实体继承自Entity（Dos.ORM）</typeparam>
    public class DBBase<T> : IDBBase<T> where T : Entity, new()
    {
        /* 方法、参数及调用说明
         * 
         * where：查询条件，如：
                        var where = new Where<SYS_Module>();
                        where.And(m => m.ModuleName.Like("日志"));
         * 
         * orderBy：排序字段，如：
                        var orderBy = SYS_Module._.CrtTime.Desc && SYS_Module._.ModuleName.Asc;
         * 
         * field：实体的某个字段，如：
                        SYS_Button._.ButtonIdName
         * 
         * whereLambda：查询条件Lambda，如：
                        var exp = ExpHelper.Create<SYS_Button>(m => m.ButtonId == 100);
         *                          删除条件Lambda，如：
                        var exp = ExpHelper.Create<SYS_Button>(m => m.ButtonId == 100);
                        var expIn = ExpHelper.Create<SYS_Button>(m => m.ButtonId.In(100, 101));
         * 
         * 
         */

        /* DbSession的其他简单辅助方法：
         * 
            SUM方法
                DbSession.Default.Sum<Products>(Products._.UnitPrice, Products._.CategoryID == 2);
                返回categroyid=2的unitprice合计。

            AVG方法
                DbSession.Default.Avg<Products>(Products._.UnitPrice, Products._.CategoryID == 2);
                返回categroyid=2的unitprice的平均值。
 
            COUNT方法
                DbSession.Default.Count<Products>(Products._.All, Products._.CategoryID == 2);
                返回categroyid=2的记录条数。
 
            MAX方法
                DbSession.Default.Max<Products>(Products._.UnitPrice, Products._.CategoryID == 2);
                返回categroyid=2的记录中最大的unitprice。
 
            MIN方法
                DbSession.Default.Min<Products>(Products._.UnitPrice, Products._.CategoryID == 2);
                返回categroyid=2的记录中最小的unitprice。
         * 
         * 
         */

        /* DbSession.Default.From<T>的各种方法使用说明：
         * 
         * DbSession.Default是一个默认的DbSession。在默认情况下会自动读取web.config/app.config配置文件中connectionStrings节点的最后一个配置。
            可以通过条用DbSession的SetDefault方法来修改这个Default。
         * 
            DbSession.Default.From<Products>()
                //.Select(Products._.ProductID) //查询返回ProductID字段
                //.GroupBy(Products._.CategoryID.GroupBy && Products._.ProductName.GroupBy)//按照CategoryID，ProductName分组
                //.InnerJoin<Suppliers>(Suppliers._.SupplierID == Products._.SupplierID)//关联Suppliers表   --CrossJoin   FullJoin  LeftJoin  RightJoin 同理
                //.OrderBy(Products._.ProductID.Asc)//按照ProductID正序排序
                //.Where((Products._.ProductName.Contain("apple") && Products._.UnitPrice > 1) || Products._.CategoryID == 2)//设置条件ProductName包含”apple”并且UnitPrice>1  或者CategoryID =2
                //.UnionAll(DbSession.Default.From<Products>().Select(Products._.ProductID))//union all查询
                //.Distinct() // Distinct
                //.Top(5)   //读取前5条
                //.Page(10, 2)//分页返回结果 每页10条返回第2页数据
                //.ToDataSet();   //返回DataSet
                //.ToDataReader(); //返回IDataReader
                //.ToDataTable(); //返回DataTable
                //.ToScalar();  //返回单个值
                .ToList();   //返回实体列表
         */

        /* DbSession.Default.FromSql的各种方法使用说明：
         * 
         * DbSession.Default是一个默认的DbSession。在默认情况下会自动读取web.config/app.config配置文件中connectionStrings节点的最后一个配置。
            可以通过条用DbSession的SetDefault方法来修改这个Default。
         * 
            DbSession.Default.FromSql("select * from products").ToDataTable();
            DbSession.Default.FromSql("select * from products where productid=pid").AddInParameter("pid", DbType.Int32, 1).ToDataTable();
            DbSession.Default.FromSql("select * from products where productid=pid or categoryid=cid")
                .AddInParameter("pid", DbType.Int32, 1)
                .AddInParameter("cid", DbType.Int32, 2)
                .ToDataTable();
         * 
         * 
         */

        /* WhereClipBuilder的使用方式
         * 
            使用WhereClipBuilder如下：
                WhereClipBuilder wherebuilder = new WhereClipBuilder();
                wherebuilder.And(Products._.ProductName.Contain("apple"));
                wherebuilder.And(Products._.UnitPrice > 1);
                wherebuilder.Or(Products._.CategoryID == 2);
            WhereClipBuilder是条件累加并不增加条件而创建新实例， 从而得到重用，节省资源。
        
            具体使用：
            Northwind.From<Products>()
                .Where(wherebuilder.ToWhereClip())
                .ToList();
         */

        #region 私有
        /// <summary>
        /// 获取FromSection<T>对象
        /// </summary>
        /// <param name="whereLambda">查询条件（Lambda表达式）</param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        private static FromSection<T> GetSection(Expression<Func<T, bool>> whereLambda, OrderByClip orderBy = null)
        {
            Expression<Func<T, bool>> exp = (m => true);
            whereLambda = whereLambda ?? exp;
            return DB.DbCont.From<T>().Where(whereLambda).OrderBy(orderBy);
        }

        /// <summary>
        /// 获取FromSection<T>对象
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        private static FromSection<T> GetSectionWhere(Where<T> where, OrderByClip orderBy = null)
        {
            where = @where ?? new Where<T>();

            return DB.DbCont.From<T>().Where(where).OrderBy(orderBy);
        }
        #endregion

        #region 共有

        #region 获取排序条件、等
        /// <summary>
        /// 获取排序条件
        /// </summary>
        /// <param name="columnName">排序列名</param>
        /// <param name="orderType">排序方式（asc、desc）</param>
        /// <returns></returns>
        public OrderByClip GetOrderByClip(string columnName, string orderType = "desc")
        {
            var entity = new T();
            PropertyInfo[] propertys = entity.GetType().GetProperties();

            var orderBy = string.IsNullOrWhiteSpace(columnName) ? null :
            (from pi in propertys
             where pi.Name == columnName
             select new Field(pi.Name, entity.GetTableName(), pi.Name)
                 into orderField
                 select orderType.ToLower() == "asc" ? orderField.Asc : orderField.Desc).FirstOrDefault();

            return orderBy;
        }

        /// <summary>
        /// 获取排序条件（easyui datagrid所需）
        /// </summary>
        /// <param name="dgCon"></param>
        /// <returns></returns>
        public OrderByClip GetOrderByClip(DgConModel dgCon)
        {
            var orderBy = GetOrderByClip(dgCon.sort, dgCon.order);

            return orderBy;
        }
        #endregion

        #region 添加、修改、删除

        /// <summary>
        /// 添加单条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public OperateModel InsertModel(T model, DbTrans trans = null)
        {
            var retCount = trans == null ? DB.DbCont.Insert(model) : DB.DbCont.Insert(trans, model);

            //TODO：数据保存失败后，是否需要记录日志？
            return new OperateModel
            {
                Result = retCount > 0 ? OperateRetType.Success : OperateRetType.Fail,
                Msg = retCount > 0 ? "数据保存成功！" : "数据保存失败，请稍后再试！",
                Data = model
            };
        }

        /// <summary>
        /// 添加多条数据
        /// </summary>
        /// <param name="models">数据实体集合</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public OperateModel InsertModels(List<T> models, DbTrans trans = null)
        {
            var retCount = trans == null ? DB.DbCont.Insert(models) : DB.DbCont.Insert(trans, models);

            //TODO：数据保存失败后，是否需要记录日志？
            return new OperateModel
            {
                Result = retCount > 0 ? OperateRetType.Success : OperateRetType.Fail,
                Msg = retCount > 0 ? "数据保存成功！" : "数据保存失败，请稍后再试！",
                Data = models
            };
        }

        /// <summary>
        /// 修改单条数据
        /// </summary>
        /// <param name="model">修改的实体</param>
        /// <param name="whereLambda">修改条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public OperateModel UpdateModel(T model, Expression<Func<T, bool>> whereLambda, DbTrans trans = null)
        {
            var retCount = trans == null ? DB.DbCont.Update(model, whereLambda) : DB.DbCont.Update(trans, model, whereLambda);

            //TODO：数据保存失败后，是否需要记录日志？
            return new OperateModel
            {
                Result = retCount > 0 ? OperateRetType.Success : OperateRetType.Fail,
                Msg = retCount > 0 ? "数据保存成功！" : "数据保存失败，请稍后再试！",
                //Data = model
            };
        }

        /// <summary>
        /// 修改单条数据的某一个字段（Field字段类型）
        /// </summary>
        /// <param name="field">修改的字段</param>
        /// <param name="value">修改的值</param>
        /// <param name="whereLambda">修改条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public OperateModel UpdateModel(Field field, object value, Expression<Func<T, bool>> whereLambda, DbTrans trans = null)
        {
            var retCount = trans == null ? DB.DbCont.Update(field, value, whereLambda) : DB.DbCont.Update(trans, field, value, whereLambda);

            //TODO：数据保存失败后，是否需要记录日志？
            return new OperateModel
            {
                Result = retCount > 0 ? OperateRetType.Success : OperateRetType.Fail,
                Msg = retCount > 0 ? "数据保存成功！" : "数据保存失败，请稍后再试！",
                Data = value
            };
        }

        /// <summary>
        /// 修改单条数据的某一个字段（string字段类型）
        /// </summary>
        /// <param name="field">修改的字段（不区分大小写）</param>
        /// <param name="value">修改的值</param>
        /// <param name="whereLambda">修改条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public OperateModel UpdateModel(string field, object value, Expression<Func<T, bool>> whereLambda, DbTrans trans = null)
        {
            var entity = new T();
            PropertyInfo[] propertys = entity.GetType().GetProperties();
            Field thisField = (from item in propertys
                               where item.Name.ToLower() == field.ToLower()
                               select new Field(item.Name, entity.GetTableName(), item.Name)).FirstOrDefault();

            var retCount = trans == null ? DB.DbCont.Update(thisField, value, whereLambda) : DB.DbCont.Update(trans, thisField, value, whereLambda);

            //TODO：数据保存失败后，是否需要记录日志？
            return new OperateModel
            {
                Result = retCount > 0 ? OperateRetType.Success : OperateRetType.Fail,
                Msg = retCount > 0 ? "数据保存成功！" : "数据保存失败，请稍后再试！",
                Data = value
            };
        }

        /// <summary>
        /// 修改多条数据
        /// </summary>
        /// <param name="models">修改的实体集合</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public OperateModel UpdateModels(List<T> models, DbTrans trans = null)
        {
            var retCount = trans == null ? DB.DbCont.Update(models) : DB.DbCont.Update(trans, models);

            //TODO：数据保存失败后，是否需要记录日志？
            return new OperateModel
            {
                Result = retCount > 0 ? OperateRetType.Success : OperateRetType.Fail,
                Msg = retCount > 0 ? "数据保存成功！" : "数据保存失败，请稍后再试！",
                Data = models
            };
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="whereLambda">删除条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public OperateModel DeleteModel(Expression<Func<T, bool>> whereLambda, DbTrans trans = null)
        {
            var retCount = trans == null ? DB.DbCont.Delete(whereLambda) : DB.DbCont.Delete(trans, whereLambda);

            //TODO：数据保存失败后，是否需要记录日志？
            return new OperateModel
            {
                Result = retCount > 0 ? OperateRetType.Success : OperateRetType.Fail,
                Msg = retCount > 0 ? "数据删除成功！" : "数据删除失败，请稍后再试！",
                Data = retCount
            };
        }

        /// <summary>
        /// 删除数据（指定实体）
        /// </summary>
        /// <typeparam name="TO">实体</typeparam>
        /// <param name="whereLambda">删除条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public OperateModel DeleteModelOther<TO>(Expression<Func<TO, bool>> whereLambda, DbTrans trans = null) where TO : Entity, new()
        {
            var retCount = trans == null ? DB.DbCont.Delete<TO>(whereLambda) : DB.DbCont.Delete<TO>(trans, whereLambda);

            //TODO：数据保存失败后，是否需要记录日志？
            return new OperateModel
            {
                Result = retCount > 0 ? OperateRetType.Success : OperateRetType.Fail,
                Msg = retCount > 0 ? "数据删除成功！" : "数据删除失败，请稍后再试！",
                Data = retCount
            };
        }

        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="models">删除的实体集合</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public OperateModel DeleteModels(List<T> models, DbTrans trans = null)
        {
            var retCount = trans == null ? DB.DbCont.Delete<T>(models) : DB.DbCont.Delete<T>(trans, models);

            //TODO：数据删除失败后，是否需要记录日志？
            return new OperateModel
            {
                Result = retCount > 0 ? OperateRetType.Success : OperateRetType.Fail,
                Msg = retCount > 0 ? "数据删除成功！" : "数据删除失败，请稍后再试！",
                Data = models
            };
        }

        /// <summary>
        /// 执行Sql语句（增、删、改）
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="optType">操作类型</param>
        /// <returns></returns>
        public OperateModel ExecSql(string sql, string optType = "操作")
        {
            var retCount = DB.DbCont.FromSql(sql).ExecuteNonQuery();

            //TODO：数据保存失败后，是否需要记录日志？
            return new OperateModel
            {
                Result = retCount > 0 ? OperateRetType.Success : OperateRetType.Fail,
                Msg = retCount > 0 ? "数据" + optType + "成功！" : "数据" + optType + "失败，请稍后再试！",
                Data = retCount
            };
        }
        #endregion

        #region 获取数据--Lambda表达式
        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="whereLambda">查询条件（Lambda表达式）</param>
        /// <returns></returns>
        public T GetModel(Expression<Func<T, bool>> whereLambda)
        {
            return GetSection(whereLambda).First();
        }

        /// <summary>
        /// 获取多条数据（返回List）
        /// </summary>
        /// <param name="whereLambda">查询条件（Lambda表达式）</param>
        /// <param name="orderBy">排序字段</param>
        /// <returns></returns>
        public List<T> GetModels(Expression<Func<T, bool>> whereLambda = null, OrderByClip orderBy = null)
        {
            return GetSection(whereLambda, orderBy).ToList();
        }

        /// <summary>
        /// 获取多条数据（返回DataTable）
        /// </summary>
        /// <param name="whereLambda">查询条件（Lambda表达式）</param>
        /// <param name="orderBy">排序字段</param>
        /// <returns></returns>
        public DataTable GetModelsToDt(Expression<Func<T, bool>> whereLambda = null, OrderByClip orderBy = null)
        {
            return GetSection(whereLambda, orderBy).ToDataTable();
        }

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
        public List<T> GetPages(int pageIndex, int pageSize, ref int totalCount, Expression<Func<T, bool>> whereLambda = null, OrderByClip orderBy = null, bool isPage = true)
        {
            var section = GetSection(whereLambda, orderBy);
            totalCount = section.Count();
            var r = section.Page(pageSize, pageIndex).ToString();
            return isPage ?
                section.Page(pageSize, pageIndex).ToList() :
                section.ToList();
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="totalCount">总条数</param>
        /// <param name="whereLambda">查询条件（Lambda表达式）</param>
        /// <param name="orderBy">排序字段</param>
        /// <returns></returns>
        public Page<T> ExtPage(int pageIndex, int pageSize, ref int totalCount, Expression<Func<T, bool>> whereLambda = null, OrderByClip orderBy = null)
        {
            var section = GetSection(whereLambda, orderBy);
            totalCount = section.Count();
            return new Page<T>(section.Page(pageSize, pageIndex).ToList(), pageIndex, pageSize, totalCount);
        }
        #endregion

        #region 获取数据--Where条件类
        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="where">查询条件（Where条件类）</param>
        /// <returns></returns>
        public T GetModelWhere(Where<T> where)
        {
            return GetSectionWhere(where).First();
        }

        /// <summary>
        /// 获取单条数据（Sql）
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public T GetModelSql(string sql)
        {
            return DB.DbCont.FromSql(sql).ToFirst<T>();
        }

        /// <summary>
        /// 获取多条数据
        /// </summary>
        /// <param name="where">查询条件（Where条件类）</param>
        /// <param name="orderBy">排序字段</param>
        /// <returns></returns>
        public List<T> GetModelsWhere(Where<T> where = null, OrderByClip orderBy = null)
        {
            return GetSectionWhere(where, orderBy).ToList();
        }

        /// <summary>
        /// 获取多条数据（Sql）
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public List<T> GetModelsSql(string sql)
        {
            return DB.DbCont.FromSql(sql).ToList<T>();
        }

        /// <summary>
        /// 获取多条数据（Sql）
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>返回DataTable</returns>
        public DataTable GetDataTableSql(string sql)
        {
            return DB.DbCont.FromSql(sql).ToDataTable();
        }

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
        public List<T> GetPagesWhere(int pageIndex, int pageSize, ref int totalCount, Where<T> where = null, OrderByClip orderBy = null, bool isPage = true)
        {
            var section = GetSectionWhere(where, orderBy);
            totalCount = section.Count();

            return isPage ?
                section.Page(pageSize, pageIndex).ToList() :
                section.ToList();
        }
        #endregion

        #region 检查是否存在
        /// <summary>
        /// 检查某数据是否存在
        /// </summary>
        /// <param name="whereLambda">查询条件（Lambda表达式）</param>
        /// <returns></returns>
        public bool IsExistEntity(Expression<Func<T, bool>> whereLambda)
        {
            //方式1
            //var isExist = GetModel(whereLambda) != null;

            //方式2
            var isExist = DB.DbCont.Exists<T>(whereLambda);

            return isExist;
        }

        /// <summary>
        /// 检查某数据是否存在（Where条件类型）
        /// </summary>
        /// <param name="where">查询条件（Where条件类）</param>
        /// <returns></returns>
        public bool IsExistEntityWhere(Where<T> where)
        {
            //方式1
            return GetModelWhere(where) != null;
        }

        /// <summary>
        /// 检查某数据是否存在（WhereClip条件类型）
        /// </summary>
        /// <param name="where">查询条件（Where条件类）</param>
        /// <returns></returns>
        public bool IsExistEntityWhere(WhereClip where)
        {
            //方式2
            return DB.DbCont.Exists<T>(where);
        }

        /// <summary>
        /// 检查某数据是否存在（WhereClipBuilder条件类型）
        /// </summary>
        /// <param name="where">查询条件（Where条件类）</param>
        /// <returns></returns>
        public bool IsExistEntityWhere(WhereClipBuilder where)
        {
            //方式3
            return DB.DbCont.Exists<T>(where.ToWhereClip());
        }
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
        public string BackupDb(string backPath, string backDbName, string backName = null, bool backPathIsDate = true, bool backNameIsTime = true)
        {
            var procSection = DB.DbCont.FromProc("SP_BackupDB")
                .AddInParameter("BackPath", DbType.String, backPath)
                .AddInParameter("BackDbName", DbType.String, backDbName)
                .AddInputOutputParameter("BackName", DbType.String, !string.IsNullOrWhiteSpace(backName) ? backName : backDbName)
                .AddInParameter("BackPathIsDate", DbType.Boolean, backPathIsDate)
                .AddInParameter("BackNameIsTime", DbType.Boolean, backNameIsTime);

            var dt = procSection.ToDataTable();

            string retBackDbName = dt.Rows[0]["BackName"].ToString();
            //Dictionary<string, object> returnValue = procSection.GetReturnValues();
            //foreach (KeyValuePair<string, object> kv in returnValue)
            //{
            //    if (kv.Key == "BackName")
            //        retBackDbName = kv.Value.ToString();
            //}

            return retBackDbName;
        }
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
        public DgListModel<T> GetPagesForDg(DgConModel dgCon, string defaultOrderCol, Expression<Func<T, bool>> whereLambda = null, bool isPage = true)
        {
            int totalCount = 0;
            var orderBy = GetOrderByClip(!string.IsNullOrWhiteSpace(defaultOrderCol) ? defaultOrderCol : dgCon.sort, dgCon.order);
            var retList = GetPages(dgCon.page, dgCon.rows, ref totalCount, whereLambda, orderBy, isPage);

            return new DgListModel<T>(retList, totalCount);
        }

        /// <summary>
        /// EasyUI datagrid所需分页数据
        /// </summary>
        /// <param name="dgCon"></param>
        /// <param name="defaultOrderCol">默认排序字段（比如初始化列表的时候）</param>
        /// <param name="defaultOrderType">默认排序方式（比如初始化列表的时候，desc或asc）</param>
        /// <param name="whereLambda">查询条件（Lambda表达式）</param>
        /// <param name="isPage">是否为分页（true：分页数据、false：返回所有数据）</param>
        /// <returns></returns>
        public DgListModel<T> GetPagesForDg(DgConModel dgCon, string defaultOrderCol, string defaultOrderType, Expression<Func<T, bool>> whereLambda = null, bool isPage = true)
        {
            int totalCount = 0;
            var orderBy = GetOrderByClip(
                !string.IsNullOrWhiteSpace(defaultOrderCol) ? defaultOrderCol : dgCon.sort,
                !string.IsNullOrWhiteSpace(defaultOrderType) ? defaultOrderType : dgCon.order);

            var retList = GetPages(dgCon.page, dgCon.rows, ref totalCount, whereLambda, orderBy, isPage);

            return new DgListModel<T>(retList, totalCount);
        }

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
        public DgListModel GetPagesForDgProc(DgConModel dgCon, string tbName, string orderCols, string where = "", bool orderDesc = true, string columns = "*")
        {
            int totalCount = 0;

            #region 点击列排序时
            orderCols = dgCon.isSortCol ? dgCon.sort : orderCols;
            int orderType = dgCon.isSortCol ? dgCon.order == "desc" ? 1 : 0 : orderDesc ? 1 : 0;
            #endregion

            var procSection = DB.DbCont.FromProc("SP_Pagination")
                .AddInParameter("TableInfos", DbType.String, tbName)
                .AddInParameter("ColumnInfos", DbType.String, columns)
                .AddInParameter("OrderInfos", DbType.String, orderCols)
                .AddInParameter("OrderType", DbType.Int32, orderType)
                .AddInParameter("WhereInfos", DbType.String, !string.IsNullOrWhiteSpace(where) ? "AND " + where : where)
                .AddInParameter("PageIndex", DbType.Int32, dgCon.page)
                .AddInParameter("PageSize", DbType.Int32, dgCon.rows)

                .AddInParameter("TCount", DbType.Int32, 0)
                .AddInParameter("OtherTable", DbType.String, "")

                .AddOutParameter("RecordCount", DbType.Int32, 1)
                .AddOutParameter("PageCount", DbType.Int32, 1);

            var dt = procSection.ToDataTable();

            Dictionary<string, object> returnValue = procSection.GetReturnValues();
            foreach (KeyValuePair<string, object> kv in returnValue)
            {
                if (kv.Key == "RecordCount")
                    totalCount = Convert.ToInt32(kv.Value);
            }

            return new DgListModel(dt, totalCount);
        }

        /// <summary>
        /// EasyUI datagrid所需分页数据
        /// </summary>
        /// <param name="dgCon"></param>
        /// <param name="where">查询条件（Where条件类）</param>
        /// <param name="isPage">是否为分页（true：分页数据、false：返回所有数据）</param>
        /// <returns></returns>
        public DgListModel<T> GetPagesForDgWhere(DgConModel dgCon, Where<T> where = null, bool isPage = true)
        {
            int totalCount = 0;
            var orderBy = GetOrderByClip(dgCon.sort, dgCon.order);
            var retList = GetPagesWhere(dgCon.page, dgCon.rows, ref totalCount, where, orderBy, isPage);

            return new DgListModel<T>(retList, totalCount);
        }
        #endregion
    }
}
