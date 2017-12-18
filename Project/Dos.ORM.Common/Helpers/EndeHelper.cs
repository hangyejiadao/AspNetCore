/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
  * 命名空间：Dos.ORM.Common.Helpers
 * 类名称：EndeHelper
 * 创建时间：2016-07-31 9:59:38
 * 创建人：Quber
 * 创建说明：加密解密帮助类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.IO;
using System.Text;

namespace Dos.ORM.Common.Helpers
{
    /// <summary>
    /// 加密解密帮助类
    /// </summary>
    public static class EndeHelper
    {
        /// <summary>
        /// 解密解密8位密钥
        /// </summary>
        private const string EncryptionKey = "qubernet";

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="strTemp"></param>
        /// <returns></returns>
        public static string Encrypt(string strTemp)
        {
            var provider = new System.Security.Cryptography.DESCryptoServiceProvider
            {
                Key = Encoding.ASCII.GetBytes(EncryptionKey),
                IV = Encoding.ASCII.GetBytes(EncryptionKey)
            };
            var bytes = Encoding.GetEncoding("GB2312").GetBytes(strTemp);
            var mstream = new MemoryStream();
            var cstream = new System.Security.Cryptography.CryptoStream(mstream, provider.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
            cstream.Write(bytes, 0, bytes.Length);
            cstream.FlushFinalBlock();
            var builder = new StringBuilder();
            foreach (var num in mstream.ToArray())
            {
                builder.AppendFormat("{0:X2}", num);
            }
            mstream.Close();
            var rs = builder.ToString();
            return rs;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="strTemp"></param>
        /// <returns></returns>
        public static string Decrypt(string strTemp)
        {
            string rs;
            try
            {
                var provider = new System.Security.Cryptography.DESCryptoServiceProvider
                {
                    Key = Encoding.ASCII.GetBytes(EncryptionKey),
                    IV = Encoding.ASCII.GetBytes(EncryptionKey)
                };
                var buffer = new byte[strTemp.Length / 2];
                for (var i = 0; i < (strTemp.Length / 2); i++)
                {
                    var num = Convert.ToInt32(strTemp.Substring(i * 2, 2), 0x10);
                    buffer[i] = (byte)num;
                }
                var mstream = new MemoryStream();
                var cstream = new System.Security.Cryptography.CryptoStream(mstream, provider.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
                cstream.Write(buffer, 0, buffer.Length);
                cstream.FlushFinalBlock();
                mstream.Close();
                rs = Encoding.GetEncoding("GB2312").GetString(mstream.ToArray());
            }
            catch
            {
                rs = "-1";
            }
            return rs;
        }
    }
}
