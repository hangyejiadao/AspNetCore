﻿/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Common.Helpers
 * 类名称：TxtHelper
 * 创建时间：2016-09-01 17:05:00
 * 创建人：Quber
 * 创建说明：文本文件帮助类
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
    /// 文本文件帮助类
    /// </summary>
    public static class TxtHelper
    {
        #region 获取编码方式
        /// <summary>
        /// 取得文本文件的编码方式（如果无法在文件头部找到有效的前导符，Encoding.Default将被返回）
        /// </summary>
        /// <param name="filePath">文件物理路径</param>
        /// <returns></returns>
        public static Encoding GetEncoding(string filePath)
        {
            return GetEncoding(filePath, Encoding.Default);
        }

        /// <summary>
        /// 取得文本文件流的编码方式
        /// </summary>
        /// <param name="stream">文本文件流</param>
        /// <returns></returns>
        public static Encoding GetEncoding(FileStream stream)
        {
            return GetEncoding(stream, Encoding.Default);
        }

        /// <summary>
        /// 取得文本文件的编码方式
        /// </summary>
        /// <param name="filePath">文件物理路径</param>
        /// <param name="defaultEncoding">默认编码方式，当该方法无法从文件的头部取得有效的前导符时，将返回该编码方式</param>
        /// <returns></returns>
        public static Encoding GetEncoding(string filePath, Encoding defaultEncoding)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            Encoding targetEncoding = GetEncoding(fs, defaultEncoding);
            fs.Close();
            return targetEncoding;
        }

        /// <summary>
        /// 取得文本文件流的编码方式
        /// </summary>
        /// <param name="stream">文本文件流</param>
        /// <param name="defaultEncoding">默认编码方式，当该方法无法从文件的头部取得有效的前导符时，将返回该编码方式</param>
        /// <returns></returns>
        public static Encoding GetEncoding(FileStream stream, Encoding defaultEncoding)
        {
            Encoding targetEncoding = defaultEncoding;
            if (stream != null && stream.Length >= 2)
            {
                //保存文件流的前4个字节
                byte byte1 = 0;
                byte byte2 = 0;
                byte byte3 = 0;
                byte byte4 = 0;
                //保存当前Seek位置
                long origPos = stream.Seek(0, SeekOrigin.Begin);
                stream.Seek(0, SeekOrigin.Begin);

                int nByte = stream.ReadByte();
                byte1 = Convert.ToByte(nByte);
                byte2 = Convert.ToByte(stream.ReadByte());
                if (stream.Length >= 3)
                {
                    byte3 = Convert.ToByte(stream.ReadByte());
                }
                if (stream.Length >= 4)
                {
                    byte4 = Convert.ToByte(stream.ReadByte());
                }

                //根据文件流的前4个字节判断Encoding
                //Unicode {0xFF, 0xFE};
                //BE-Unicode {0xFE, 0xFF};
                //UTF8 = {0xEF, 0xBB, 0xBF};

                if (byte1 == 0xFE && byte2 == 0xFF)//UnicodeBe
                {
                    targetEncoding = Encoding.BigEndianUnicode;
                }
                if (byte1 == 0xFF && byte2 == 0xFE && byte3 != 0xFF)//Unicode
                {
                    targetEncoding = Encoding.Unicode;
                }
                if (byte1 == 0xEF && byte2 == 0xBB && byte3 == 0xBF)//UTF8
                {
                    targetEncoding = Encoding.UTF8;
                }

                //恢复Seek位置       
                stream.Seek(origPos, SeekOrigin.Begin);
            }
            return targetEncoding;
        }
        #endregion
    }
}
