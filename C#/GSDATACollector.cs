using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Web.Script.Serialization;
using CSharpUtils;
using CSharpUtils.DEncrypt;
using System.Net;
using System.IO;
using System.Configuration;

namespace GSDataAPI
{
    class GSDATACollector
    {
        //baseurl
        static string GSDataAPI_BaseURL = ConfigurationManager.AppSettings["GSDataAPI_BaseURL"];
        //app_id
        static string GSDataAPI_APP_ID = ConfigurationManager.AppSettings["GSDataAPI_APP_ID"];
        //app_key
        static string GSDataAPI_APP_KEY = ConfigurationManager.AppSettings["GSDataAPI_APP_KEY"];

        /// <summary>
        /// 接口的数据签名生成方法
        /// </summary>
        /// <param name="data"></param>
        /// <returns>string</returns>
        protected static string signature(IDictionary<string, string> data)
        {
            //字典排序
            data = data.OrderBy(c => c.Key).ToDictionary(o => o.Key, o => o.Value);
            //转json
            string jsonstr = (new JavaScriptSerializer()).Serialize(data).ToLower();
            //  
            return Md5Encrypt.Encrypt(jsonstr + GSDataAPI_APP_KEY, "").ToLower();
        }

        /// <summary>
        /// 接口的数据签名生成方法
        /// </summary>
        /// <param name="data"></param>
        /// <returns>string</returns>
        protected static string signatureEx(IDictionary<string, string> data)
        {
            //字典排序
            data = data.OrderBy(c => c.Key).ToDictionary(o => o.Key, o => o.Value);
            //转json
            string jsonstr = Json_Encode(data).ToLower();
            //  
            return Md5Encrypt.Encrypt(jsonstr + GSDataAPI_APP_KEY, "").ToLower();
        }

        /// <summary>
        /// 接口调用
        /// </summary>
        /// <param name="url">接口地址</param>
        /// <param name="data">post数据</param>
        /// <param name="raw"></param>
        /// <returns></returns>
        public static string call(string url, IDictionary<string, string> data, bool raw = true)
        {
            data.Add("appid", GSDataAPI_APP_ID);
            data.Add("signature", signature(data));
            //
            string json_str = (new JavaScriptSerializer()).Serialize(data);
            string post_string = Base64Encode((new JavaScriptSerializer()).Serialize(data));

            //
            return HttpPost(GSDataAPI_BaseURL + url, post_string);
        }

        /// <summary>
        /// 接口调用
        /// </summary>
        /// <param name="url">接口地址</param>
        /// <param name="data">post数据</param>
        /// <param name="raw"></param>
        /// <returns></returns>
        public static string callEx(string url, IDictionary<string, string> data, bool raw = true)
        {
            data.Add("appid", GSDataAPI_APP_ID);
            data.Add("signature", signatureEx(data));
            // 
            string json_str = Json_Encode(data);
            string post_string = Base64Encode(Json_Encode(data));
            //
            return HttpPost(GSDataAPI_BaseURL + url, post_string);
        }

        /// <summary>
        /// base64加密
        /// </summary>
        /// <param name="AStr"></param>
        /// <returns></returns>
        public static string Base64Encode(string AStr)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(AStr));
        }

        /// <summary>
        /// 模拟Post请求
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        private static string HttpPost(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("utf-8"));
            myStreamWriter.Write(postDataStr);
            myStreamWriter.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }

        /// <summary>
        /// 自定义Json_Encode
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static string Json_Encode(IDictionary<string, string> data)
        {
            string retString = "{";

            foreach (var item in data)
            {
                retString += "\"" + item.Key + "\":\"" + item.Value + "\",";
            }

            retString += "}";

            retString = retString.Replace(",}", "}");

            return retString;
        }
    }
}
