/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2015-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Common.Helpers
 * 类名称：JsonHelper
 * 创建时间：2015-11-25 14:38:58
 * 创建人：Quber
 * 创建说明：Json与对象操作类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Dos.ORM.Common.Helpers
{
    /// <summary>
    /// Json与对象操作类
    /// </summary>
    public static class JsonHelper
    {
        #region 无实体参与的方法
        /// <summary>
        /// 将Json字符串转换为键值对对象（JObject）
        /// </summary>
        /// <param name="jsonData">Json字符串</param>
        /// <returns></returns>
        public static JObject JsonToObject(string jsonData)
        {
            try
            {
                JObject jObject = JObject.Parse(jsonData);
                return jObject;
            }
            catch (Exception)
            {
                const string exInfo = @"请检查传递的参数是否为标准的Json对象，如：{""id"":""1001"",""name"":""quber""}";
                throw new Exception(exInfo);
            }
        }

        /// <summary>
        /// 将Json字符串转换为键值对数组对象（JObject）
        /// </summary>
        /// <param name="jsonData">Json字符串</param>
        /// <returns></returns>
        public static JArray JsonToObjectList(string jsonData)
        {
            try
            {
                JArray jArray = JArray.Parse(jsonData);
                return jArray;
            }
            catch (Exception)
            {
                const string exInfo = @"请检查传递的参数是否为标准的Json数组对象，如：[{""id"":""1001"",""name"":""quber""},{""id"":""1002"",""name"":""xmer""}]";
                throw new Exception(exInfo);
            }
        }
        #endregion

        #region 有实体参与的方法
        #region Json转换相关配置
        /// <summary>
        /// 添加时间转换器
        /// </summary>
        /// <param name="serializer"></param>
        private static void AddIsoDateTimeConverter(JsonSerializer serializer)
        {
            var idtc = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            serializer.Converters.Add(idtc);
        }

        /// <summary>
        /// Json转换配置
        /// </summary>
        /// <param name="serializer"></param>
        private static void SerializerSetting(JsonSerializer serializer)
        {
            serializer.DefaultValueHandling = DefaultValueHandling.Include;
            serializer.NullValueHandling = NullValueHandling.Include;
            serializer.ObjectCreationHandling = ObjectCreationHandling.Replace;
            serializer.MissingMemberHandling = MissingMemberHandling.Ignore;
            serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }
        #endregion

        #region Json转换方法
        /// <summary>
        /// 将对象（Single）转换为Json字符串
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="obj">实体对象值</param>
        /// <returns></returns>
        public static string ObjectToJson<T>(T obj)
        {
            var serializer = new JsonSerializer();
            SerializerSetting(serializer);
            AddIsoDateTimeConverter(serializer);

            using (TextWriter sw = new StringWriter())
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, obj);
                return sw.ToString();
            }
        }

        /// <summary>
        /// 将对象（List）转换为Json字符串
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="objList">实体对象值</param>
        /// <returns></returns>
        public static string ObjectListToJson<T>(List<T> objList)
        {
            var serializer = new JsonSerializer();
            SerializerSetting(serializer);
            AddIsoDateTimeConverter(serializer);

            using (TextWriter sw = new StringWriter())
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, objList);
                return sw.ToString();
            }
        }

        /// <summary>
        /// 将Json字符串转换为对象（Single）
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="jsonData">Json字符串</param>
        /// <returns></returns>
        public static T JsonToObject<T>(string jsonData)
        {
            var serializer = new JsonSerializer { MissingMemberHandling = MissingMemberHandling.Ignore };
            AddIsoDateTimeConverter(serializer);
            var sr = new StringReader(jsonData);
            return (T)serializer.Deserialize(sr, typeof(T));
        }

        /// <summary>
        /// 将Json字符串转换为对象（List）
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="jsonData">Json字符串</param>
        /// <returns></returns>
        public static List<T> JsonToObjectList<T>(string jsonData)
        {
            var serializer = new JsonSerializer { MissingMemberHandling = MissingMemberHandling.Ignore };
            AddIsoDateTimeConverter(serializer);
            var sr = new StringReader(jsonData);
            return (List<T>)serializer.Deserialize(sr, typeof(List<T>));
        }
        #endregion
        #endregion
    }
}
