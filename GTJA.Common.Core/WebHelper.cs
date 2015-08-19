using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace GTJA.Common.Core
{
    public class WebHelper
    {
        public static string GetHtml(string url)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                request.Method = "Get";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.125 Safari/537.36";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                request.ContentType = "application/x-www-form-urlencoded;";
                //request.Headers.Add("Cookie:" + cookies);

                //request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
                //request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
                //request.Headers.Add("Cache-control", "max-age=0");
                //request.KeepAlive = true;
                //request.CookieContainer = cookies; 

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    //response.Cookies = request.CookieContainer.GetCookies(request.RequestUri);
                    using (Stream receiveStream = response.GetResponseStream())
                    {
                        using (StreamReader readStream = new StreamReader(receiveStream, Encoding.Default))
                        {
                            return readStream.ReadToEnd();
                        }
                    }
                }
            }
            catch
            {

            }
            return null;

        }

        public static string HttpPost(string Url, string postDataStr)
        {
            var request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
            //request.CookieContainer = cookie;
            using (var myRequestStream = request.GetRequestStream())
            {
                using (var myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312")))
                {
                    myStreamWriter.Write(postDataStr);

                    using (var response = (HttpWebResponse)request.GetResponse())
                    {
                        //response.Cookies = cookie.GetCookies(response.ResponseUri);
                        using (Stream myResponseStream = response.GetResponseStream())
                        {
                            using (var myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8")))
                            {
                                string retString = myStreamReader.ReadToEnd();
                                return retString;
                            }

                        }

                    }
                }
            }

        }

        public string HttpGet(string Url, string postDataStr)
        {
            var request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream myResponseStream = response.GetResponseStream())
                {
                    using (
                        StreamReader myStreamReader = new StreamReader(myResponseStream,
                            Encoding.GetEncoding("utf-8")))
                    {
                        string retString = myStreamReader.ReadToEnd();

                        return retString;
                    }

                }

            }



        }
    }
}
