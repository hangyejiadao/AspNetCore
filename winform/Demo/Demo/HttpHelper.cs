using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class HttpHelper
    {
        public static string Request(string url, Dictionary<string, dynamic> args, Dictionary<string, dynamic> header = null,
            HttpMethod method = HttpMethod.POST, string ContentType = "application/json")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = ContentType;
            request.Method = method.ToString();
            request.Timeout = 5000;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
            if (header != null)
            {
              
                    foreach (var item in header)
                    {
                        request.Headers.Add(item.Key, item.Value);
                    }
              
            }
            if (args != null)
            { 
                string json = JsonConvert.SerializeObject(JsonConvert.SerializeObject(args));
                byte[] data = Encoding.UTF8.GetBytes(json);
                request.ContentLength = data.Length;
                using (Stream writer = request.GetRequestStream())
                {
                    writer.Write(data, 0, data.Length);
                }
            }
            else
            {
                request.ContentLength = 0;
            }
            using (StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }
    }

    public enum HttpMethod
    {
        POST,
        PUT,
        DELETE,
        GET
    }
}
