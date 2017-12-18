/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Common.Helpers
 * 类名称：HttpClientHelper
 * 创建时间：2017-02-13 17:04:56
 * 创建人：Quber
 * 创建说明：基于HttpClient的Http请求帮助类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Dos.ORM.Common.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class HttpClientHelper
    {
        #region Get请求
        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <returns>返回字符串</returns>
        public static string Get(string url)
        {
            if (url.StartsWith("https"))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            }

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = httpClient.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            return null;
        }

        /// <summary>
        /// Get请求（返回实体T对象）
        /// </summary>
        /// <typeparam name="T">将请求字符串结果转换为实体对象所需实体</typeparam>
        /// <param name="url">请求地址</param>
        /// <returns>返回实体T对象</returns>
        public static T Get<T>(string url) where T : class,new()
        {
            if (url.StartsWith("https"))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            }

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = httpClient.GetAsync(url).Result;

            T result = default(T);

            if (response.IsSuccessStatusCode)
            {
                Task<string> t = response.Content.ReadAsStringAsync();
                string s = t.Result;

                result = JsonConvert.DeserializeObject<T>(s);
            }
            return result;
        }
        #endregion

        #region Post请求
        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="postData">Post传递的参数（Json字符串）</param>
        /// <returns>返回字符串</returns>
        public static string Post(string url, string postData)
        {
            if (url.StartsWith("https"))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            }

            HttpContent httpContent = new StringContent(postData);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            return null;
        }

        /// <summary>
        /// Post请求（返回实体T对象）
        /// </summary>
        /// <typeparam name="T">将请求字符串结果转换为实体对象所需实体</typeparam>
        /// <param name="url">请求地址</param>
        /// <param name="postData">Post传递的参数（Json字符串）</param>
        /// <returns>返回实体T对象</returns>
        public static T Post<T>(string url, string postData) where T : class,new()
        {
            if (url.StartsWith("https"))
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            }

            HttpContent httpContent = new StringContent(postData);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpClient httpClient = new HttpClient();

            T result = default(T);

            HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;

            if (response.IsSuccessStatusCode)
            {
                Task<string> t = response.Content.ReadAsStringAsync();
                string s = t.Result;

                result = JsonConvert.DeserializeObject<T>(s);
            }
            return result;
        }
        #endregion
        #region 抓取html或者读取txt文件
        public static string GetStr(string url, Encoding encode)
        {
            string html = string.Empty;
            try
            {
                HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
                request.Timeout = 30 * 1000;//设置30秒的超时
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36";
                request.ContentType = "text/html; charset=utf-8";// "text/html;charset=gbk";// 
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {

                    try
                    {
                        StreamReader sr = new StreamReader(response.GetResponseStream());
                        html = sr.ReadToEnd();
                        sr.Close();
                    }
                    catch (Exception e)
                    {
                        html = null;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            return html;
        }
        #endregion

    }
}
