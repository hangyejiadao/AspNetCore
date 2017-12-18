/*****************************************************************************************************
 * 本代码版权归成都科信所有，All Rights Reserved (C) 2015-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：QUBER.Common.Helpers
 * 类名称：EntityHelper
 * 创建时间：2016-1-25 16:30:10
 * 创建人：Quber
 * 创建说明：实体转换帮助类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using NPOI.SS.Formula.Functions;

namespace KXFramework.Common
{
    /// <summary>
    /// 实体转换帮助类
    /// </summary>
    public class EntityHelper
    {
        /// <summary> 
        /// 利用反射将DataTable转换为List<T>对象
        /// </summary> 
        /// <param name="dt">DataTable 对象</param> 
        /// <returns>List<T>集合</returns> 
        public static List<T> DataTableToList<T>(DataTable dt) where T : class,new()
        {
            // 定义集合
            List<T> ts = new List<T>();
            //遍历DataTable中所有的数据行
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                // 获得此模型的公共属性
                PropertyInfo[] propertys = t.GetType().GetProperties();
                //遍历该对象的所有属性
                foreach (PropertyInfo pi in propertys)
                {
                    var tempName = pi.Name;
                    //检查DataTable是否包含此列（列名==对象的属性名）
                    if (dt.Columns.Contains(tempName))
                    {
                        //取值
                        object value = dr[tempName];
                        //如果非空，则赋给对象的属性
                        if (value != DBNull.Value)
                        {
                            value = value.GetType().Name == "Byte[]" ? "0x" + BitConverter.ToString(value as byte[]).Replace("-", "") : value;

                            pi.SetValue(t, value, null);
                        }
                    }
                }
                //对象添加到泛型集合中
                ts.Add(t);
            }
            return ts;
        }


        /// <summary>    
        /// 将泛型集合类转换成DataTable    
        /// </summary>    
        /// <typeparam name="T">集合项类型</typeparam>    
        /// <param name="list">集合</param>    
        /// <returns>数据集(表)</returns>    
        public static DataTable ToDataTable<T>(IList<T> list)
        {
            return ToDataTable<T>(list, null);

        }

        /// <summary>    
        /// 将泛型集合类转换成DataTable    
        /// </summary>    
        /// <typeparam name="T">集合项类型</typeparam>    
        /// <param name="list">集合</param>    
        /// <param name="propertyName">需要返回的列的列名</param>    
        /// <returns>数据集(表)</returns>    
        public static DataTable ToDataTable<T>(IList<T> list, params string[] propertyName)
        {
            List<string> propertyNameList = new List<string>();
            if (propertyName != null)
                propertyNameList.AddRange(propertyName);
            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    if (propertyNameList.Count == 0)
                    {
                        result.Columns.Add(pi.Name, pi.PropertyType);
                    }
                    else
                    {
                        if (propertyNameList.Contains(pi.Name))
                            result.Columns.Add(pi.Name, pi.PropertyType);
                    }
                }

                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        if (propertyNameList.Count == 0)
                        {
                            object obj = pi.GetValue(list[i], null);
                            tempList.Add(obj);
                        }
                        else
                        {
                            if (propertyNameList.Contains(pi.Name))
                            {
                                object obj = pi.GetValue(list[i], null);
                                tempList.Add(obj);
                            }
                        }
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }
        
        /// <summary>  
        /// DataReader转换为obj  
        /// </summary>  
        /// <typeparam name="T">泛型</typeparam>  
        /// <param name="rdr">datareader</param>  
        /// <returns>返回泛型类型</returns>  
        public static object DataReaderToObj<T>(SqlDataReader rdr)
        {
            T t = Activator.CreateInstance<T>();
            Type obj = t.GetType();

            if (rdr.Read())
            {
                // 循环字段  
                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    object tempValue = null;

                    if (rdr.IsDBNull(i))
                    {

                        string typeFullName = obj.GetProperty(rdr.GetName(i)).PropertyType.FullName;
                        tempValue = GetDBNullValue(typeFullName);

                    }
                    else
                    {
                        tempValue = rdr.GetValue(i);

                    }

                    obj.GetProperty(rdr.GetName(i)).SetValue(t, tempValue, null);

                }
                return t;
            }
            else
                return null;
        }

        /// <summary>  
        /// 返回值为DBnull的默认值  
        /// </summary>  
        /// <param name="typeFullName">数据类型的全称，类如：system.int32</param>  
        /// <returns>返回的默认值</returns>  
        private static object GetDBNullValue(string typeFullName)
        {

            typeFullName = typeFullName.ToLower();

            //if (typeFullName == DataType.String)
            //{
            //    return String.Empty;
            //}
            //if (typeFullName == DataType.Int32)
            //{
            //    return 0;
            //}
            //if (typeFullName == DataType.DateTime)
            //{
            //    return Convert.ToDateTime(BaseSet.DateTimeLongNull);
            //}
            //if (typeFullName == DataType.Boolean)
            //{
            //    return false;
            //}
            //if (typeFullName == DataType.Int)
            //{
            //    return 0;
            //}

            return null;
        }

    }
}
