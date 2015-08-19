using System;
using System.Security.Cryptography;
using System.Text;

namespace GTJA.Common.Core.Encrypt
{
    /// <summary>
    /// DES����/�����ࡣ
    /// </summary>
    public class DESEncrypt
    {
        private const string _encryptKey = "yunanquan,com";

        public DESEncrypt()
        {
        }

        /// <summary>
        /// Ĭ��Key����(Key=yunanquan,com)
        /// </summary>
        /// <param name="Text">��Ҫ���ܵ�����</param>
        /// <returns>���ܵ�������</returns>
        public static string Encrypt(string Text)
        {
            return Encrypt(Text, _encryptKey);
        }
        /// <summary> 
        /// �������� 
        /// </summary> 
        /// <param name="Text">��Ҫ���ܵ�����</param> 
        /// <param name="sKey">��Կ</param> 
        /// <returns>���ܵ�������</returns> 
        public static string Encrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.UTF8.GetBytes(Text);
            des.Key = UTF8Encoding.UTF8.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = UTF8Encoding.UTF8.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }


        /// <summary>
        /// Ĭ��Key����(Key=yunanquan,com)
        /// </summary>
        /// <param name="Text">Ҫ���ܵ�����</param>
        /// <returns>���ܵ�����</returns>
        public static string Decrypt(string Text)
        {
            return Decrypt(Text, _encryptKey);
        }
        /// <summary> 
        /// �������� 
        /// </summary> 
        /// <param name="Text">Ҫ���ܵ�����</param> 
        /// <param name="sKey">��Կ</param> 
        /// <returns>���ܵ�����</returns> 
        public static string Decrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = Text.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            des.Key = UTF8Encoding.UTF8.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = UTF8Encoding.UTF8.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.UTF8.GetString(ms.ToArray());
        }


    }
}
