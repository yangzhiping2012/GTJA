using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GTJA.Common.Core.Utility
{
    public class IPHelper
    {
        private static string WebServerIp = string.Empty;

        /// <summary>
        /// 获取IP地址的方式
        /// </summary>
        public enum IPAddressType
        {
            LAST,
            WAN,
            FULL
        }

        public static string GetAllIPAddress()
        {
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return ip;
        }

        /// <summary>
        /// 获取客户端IP
        /// </summary>
        /// <returns></returns>
        public static string GetClientIp()
        {
            string ip = string.Empty;
            try
            {
                OperationContext context = OperationContext.Current;
                if (context != null)
                {
                    MessageProperties properties = context.IncomingMessageProperties;
                    HttpRequestMessageProperty httpRequest = properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
                    if (httpRequest != null)
                    {
                        var header = httpRequest.Headers;
                        if (header != null)
                        {
                            // 经过F5转发的请求，源客户端IP会记录在X-Forwarded-For头中
                            ip = header.Get("X-Forwarded-For");
                            if (string.IsNullOrEmpty(ip))
                            {
                                RemoteEndpointMessageProperty endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                                ip = endpoint.Address;
                            }
                        }
                    }
                }
                else if (HttpContext.Current != null)
                {
                    var httpReq = HttpContext.Current.Request;
                    if (httpReq != null)
                    {
                        // 经过F5转发的请求，源客户端IP会记录在X-Forwarded-For头中
                        ip = httpReq.Headers.Get("X-Forwarded-For");
                        if (string.IsNullOrEmpty(ip))
                        {
                            ip = httpReq.UserHostAddress;
                        }
                    }
                }
                else
                {
                    ip = GetWebServerIp();
                }
            }
            catch
            {
            }
            if (ip == "::1")
            {
                ip = "127.0.0.1";
            }
            if (ip == string.Empty)
            {
                ip = GetVisitorIPAddress(IPAddressType.WAN);
            }
            return ip;
        }

        public static string GetOriginalRemoteIp()
        {
            string ip = string.Empty;
            try
            {
                OperationContext context = OperationContext.Current;
                if (context != null)
                {
                    MessageProperties properties = context.IncomingMessageProperties;
                    HttpRequestMessageProperty httpRequest = properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
                    if (httpRequest != null)
                    {
                        var header = httpRequest.Headers;
                        if (header != null)
                        {
                            // 经过F5转发的请求，源客户端IP会记录在X-Forwarded-For头中
                            ip = header.Get("ORIGINAL_REMOTE_HOST");
                            if (string.IsNullOrEmpty(ip))
                            {
                                RemoteEndpointMessageProperty endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                                ip = endpoint.Address;
                            }
                        }
                    }

                }
                else if (HttpContext.Current != null)
                {
                    var httpReq = HttpContext.Current.Request;
                    if (httpReq != null)
                    {
                        // 经过F5转发的请求，源客户端IP会记录在X-Forwarded-For头中
                        ip = httpReq.Headers.Get("ORIGINAL_REMOTE_HOST");
                        if (string.IsNullOrEmpty(ip))
                        {
                            ip = httpReq.UserHostAddress;
                        }
                    }
                }
                else
                {
                    ip = GetWebServerIp();
                }
            }
            catch
            {
            }
            if (ip == "::1")
            {
                ip = "127.0.0.1";
            }
            if (ip == string.Empty)
            {
                ip = GetVisitorIPAddress(IPAddressType.WAN);
            }
            return ip;
        }

        public static string GetIPAddress()
        {
            string ip = GetAllIPAddress();

            if (!string.IsNullOrEmpty(ip))
            {
                ip = ip.Split(',')[0];
            }
            return ip;
        }

        /// <summary>
        /// 获取访问者的IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetVisitorIPAddress(IPAddressType type)
        {
            string result = string.Empty;

            if (HttpContext.Current != null)
            {
                var sv = HttpContext.Current.Request.ServerVariables;
                result = sv["HTTP_X_FORWARDED_FOR1"];
                if (string.IsNullOrEmpty(result) || result.ToLower().IndexOf("unknown") > 0)
                {
                    result = sv["HTTP_XOR_FWARDED_FOR"];
                    if (string.IsNullOrEmpty(result) || result.ToLower().IndexOf("unknown") > 0)
                    {
                        result = sv["HTTP_X_FORWARDED_FOR"];
                        if (string.IsNullOrEmpty(result) || result.ToLower().IndexOf("unknown") > 0)
                        {
                            result = sv["HTTP_FOX_RWARDED_FOR"];
                            if (string.IsNullOrEmpty(result) || result.ToLower().IndexOf("unknown") > 0)
                            {
                                result = sv["HTTP_XOR_FWARDED_FOR"];
                                if (string.IsNullOrEmpty(result) || result.ToLower().IndexOf("unknown") > 0)
                                {
                                    result = sv["REMOTE_ADDR"];
                                    if (string.IsNullOrEmpty(result) || result.ToLower().IndexOf("unknown") > 0)
                                    {
                                        result = HttpContext.Current.Request.UserHostAddress;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(result))
            {
                //可能有代理
                if (result.IndexOf(".") == -1) //没有“.”肯定是非IPv4格式
                {
                    result = string.Empty;
                }
                else
                {
                    if (result.IndexOf(",") != -1)
                    {
                        //有“,”，估计多个代理。取第一个不是内网的IP。
                        result = result.Replace(" ", "").Replace("'", "");

                        string[] temparyip = result.Split(",;".ToCharArray());

                        switch (type)
                        {
                            case IPAddressType.FULL:
                                return result;

                            case IPAddressType.LAST:
                                return temparyip[temparyip.Length - 1];

                            case IPAddressType.WAN:
                                for (int i = 0; i < temparyip.Length; i++)
                                {
                                    if (temparyip[i].Substring(0, 3) != "10." && temparyip[i].Substring(0, 7) != "192.168" && temparyip[i].Substring(0, 7) != "172.16.")
                                    {
                                        return temparyip[i]; //找到不是内网的地址
                                    }
                                }
                                break;
                        }
                    }
                    else
                    {
                        return result;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 获取Web服务器IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetWebServerIp()
        {
            if (WebServerIp != string.Empty)
            {
                return WebServerIp;
            }

            try
            {
                if (System.Web.HttpContext.Current != null)
                {
                    WebServerIp = HttpContext.Current.Request.ServerVariables["Local_Addr"];
                }
                IPAddress[] ips = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList;

                int len = ips.Length;
                if (len > 0)
                {
                    foreach (var item in ips)
                    {
                        if (item.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            WebServerIp = item.ToString();
                            break;
                        }
                    }

                    //IP V6
                    //foreach (var item in ips)
                    //{
                    //    if (item.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                    //    {
                    //        ip += item.ToString() + " | ";
                    //    }
                    //}
                }

                if (WebServerIp == "::1")
                {
                    WebServerIp = "127.0.0.1";
                }
            }
            catch
            {
            }
            return WebServerIp;
        }
    }
}
