using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace GTJA.Common.Core.Encrypt
{
    /// <summary>
    /// MD5相关操作
    /// </summary>
    public static class MD5Encrypt
    {
        #region Methods

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="input">需要加密的字符串</param>
        /// <returns>加密后字符串</returns>
        public static string EncryptMD5(string input)
        {
            using (MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider())
            {
                return BitConverter.ToString(provider.ComputeHash(Encoding.UTF8.GetBytes(input))).Replace("-", string.Empty).ToLower(CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="input">需要加密的字符串</param>
        /// <returns>加密后字符串</returns>
        public static string EncryptShortMD5(string input)
        {
            string Md5string = EncryptMD5(input);
            return Md5string.Substring(8, 16);
        }

        /// <summary>
        /// MD5验证
        /// </summary>
        /// <param name="input">需要验证的字符串</param>
        /// <param name="encryptedValue">密文</param>
        /// <returns></returns>
        public static bool ValidateMD5(string input, string encryptedValue)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            if (encryptedValue.Length == 16)
            {
                return (string.Compare(EncryptShortMD5(input), encryptedValue, StringComparison.Ordinal) == 0);
            }
            else
            {
                return (string.Compare(EncryptMD5(input), encryptedValue, StringComparison.Ordinal) == 0);
            }
        }

        #endregion Methods
    }
}