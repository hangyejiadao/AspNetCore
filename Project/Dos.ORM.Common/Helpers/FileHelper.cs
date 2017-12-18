/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2015-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：QUBER.Common.Helpers
 * 类名称：FileHelper
 * 创建时间：2015-12-09 13:56:19
 * 创建人：Quber
 * 创建说明：文件帮助类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.IO;
using System.Text;
using System.Web;

namespace Dos.ORM.Common.Helpers
{
    /// <summary>
    /// 文件帮助类
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// 获取文件相对路径映射的物理路径
        /// </summary>
        /// <param name="virtualPath">文件的相对路径</param>
        public static string GetPath(string virtualPath)
        {
            return HttpContext.Current.Server.MapPath(virtualPath);
        }

        /// <summary>
        /// 检测指定文件是否存在，如果存在则返回true
        /// </summary>
        /// <param name="virtualPath">文件的相对路径</param>
        public static bool IsExistFile(string virtualPath)
        {
            return File.Exists(GetPath(virtualPath));
        }

        /// <summary>
        /// 检测指定目录是否存在
        /// </summary>
        /// <param name="virtualPath">文件的相对路径</param>
        /// <returns></returns>
        public static bool IsExistDirectory(string virtualPath)
        {
            string directoryPath = GetPath(virtualPath);
            return Directory.Exists(directoryPath);
        }

        /// <summary>
        /// 获取文件的后缀名（如：.png）
        /// </summary>
        /// <param name="filePathStr">字符串路径</param>
        /// <returns></returns>
        public static string GetFileExtension(string filePathStr)
        {
            return filePathStr.Length > 0 ?
                filePathStr.Substring(filePathStr.LastIndexOf(".", StringComparison.Ordinal), filePathStr.Length - filePathStr.LastIndexOf(".", StringComparison.Ordinal)) :
                filePathStr;
        }

        /// <summary>
        /// 获取指定目录中所有文件列表
        /// </summary>
        /// <param name="virtualPath">文件的相对路径</param>
        public static string[] GetFileNames(string virtualPath)
        {
            string directoryPath = GetPath(virtualPath);
            //如果目录不存在，则抛出异常
            if (!IsExistDirectory(virtualPath))
            {
                throw new FileNotFoundException();
            }

            //获取文件列表
            return Directory.GetFiles(directoryPath);
        }

        /// <summary>
        /// 从文件的相对路径中获取文件名（包含扩展名）
        /// </summary>
        /// <param name="virtualPath">文件的相对路径</param>
        public static string GetFileName(string virtualPath)
        {
            //获取文件的名称
            var fi = new FileInfo(GetPath(virtualPath));
            return fi.Name;
        }

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="dir">要创建的目录路径包括目录名（相对路径）</param>
        public static void CreateDir(string dir)
        {
            if (dir.Length == 0) return;
            if (!Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir))
                Directory.CreateDirectory(HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir);
        }

        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="dir">要删除的目录路径和名称（相对路径）</param>
        public static void DeleteDir(string dir)
        {
            if (dir.Length == 0) return;
            if (Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir))
                Directory.Delete(HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir);
        }

        /// <summary>
        /// 获取指定目录中所有子目录列表，若要搜索嵌套的子目录列表,请使用重载方法
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>
        public static string[] GetDirectories(string directoryPath)
        {
            try
            {
                return Directory.GetDirectories(GetPath(directoryPath));
            }
            catch (IOException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 检测指定目录是否为空
        /// </summary>
        /// <param name="virtualPath">文件的相对路径</param>
        public static bool IsEmptyDirectory(string virtualPath)
        {
            try
            {
                //判断是否存在文件
                string[] fileNames = GetFileNames(virtualPath);
                if (fileNames.Length > 0)
                {
                    return false;
                }

                //判断是否存在文件夹
                string[] directoryNames = GetDirectories(virtualPath);
                if (directoryNames.Length > 0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return true;
            }
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="dir">带后缀的文件名</param>
        /// <param name="fileContent">文件内容</param>
        /// <param name="isCover">是否覆盖已存在的文件</param>
        public static void CreateFile(string dir, string fileContent = null, bool isCover = true)
        {
            dir = dir.Replace("/", "\\");
            if (dir.IndexOf("\\", StringComparison.Ordinal) > -1)
                CreateDir(dir.Substring(0, dir.LastIndexOf("\\", StringComparison.Ordinal)));
            if ((!IsExistFile(dir) || !isCover) && (IsExistFile(dir))) return;
            var sw = new StreamWriter(HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir, false, Encoding.GetEncoding("GB2312"));
            sw.Write(fileContent);
            sw.Close();
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="file">要删除的文件路径和名称</param>
        public static void DeleteFile(string file)
        {
            if (File.Exists(HttpContext.Current.Request.PhysicalApplicationPath + file))
                File.Delete(HttpContext.Current.Request.PhysicalApplicationPath + file);
        }

        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="dirFrom">要复制的文件的路径已经全名（包括后缀）</param>
        /// <param name="dirTo">目标位置，并指定新的文件名</param>
        public static void CopyFile(string dirFrom, string dirTo)
        {
            dirFrom = dirFrom.Replace("/", "\\");
            dirTo = dirTo.Replace("/", "\\");
            if (!File.Exists(HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dirFrom)) return;
            if (dirTo.IndexOf("\\", StringComparison.Ordinal) > -1)
                CreateDir(dirTo.Substring(0, dirTo.LastIndexOf("\\", StringComparison.Ordinal)));
            File.Copy(HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dirFrom, HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dirTo, true);
        }

        /// <summary>
        /// 移动文件（剪切→粘贴）
        /// </summary>
        /// <param name="dirFrom">要移动的文件的路径及全名（包括后缀）</param>
        /// <param name="dirTo">文件移动到新的位置，并指定新的文件名</param>
        public static void MoveFile(string dirFrom, string dirTo)
        {
            dirFrom = dirFrom.Replace("/", "\\");
            dirTo = dirTo.Replace("/", "\\");
            if (!File.Exists(HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dirFrom)) return;
            if (dirTo.IndexOf("\\", StringComparison.Ordinal) > -1)
                CreateDir(dirTo.Substring(0, dirTo.LastIndexOf("\\", StringComparison.Ordinal)));
            File.Move(HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dirFrom, HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dirTo);
        }
    }
}
