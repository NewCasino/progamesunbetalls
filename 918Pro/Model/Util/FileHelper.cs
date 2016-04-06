using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Util
{
    /// <summary>
    /// 文件相关操作类
    /// </summary>
    public static class FileHelper
    {
        #region static string ReadLine(string fileName) 读取某个文件的一行内容

        /// <summary>
        /// 读取某个文件的一行内容
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>读取的内容</returns>
        public static string ReadLine(string fileName)
        {
            return ReadLine(fileName, Encoding.Default);
        }

        #endregion

        #region static string ReadLine(string fileName, Encoding coding) 用编码读取某个文件的一行内容

        /// <summary>
        /// 用编码读取某个文件的一行内容
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="coding">编码</param>
        /// <returns>读取的内容</returns>
        public static string ReadLine(string fileName, Encoding coding)
        {
            using (StreamReader reader = new StreamReader(fileName, coding))
            {
                return reader.ReadLine();
            }
        }

        #endregion

        #region static string ReadText(string fileName) 读取某个文件的所有内容

        /// <summary>
        /// 读取某个文件的所有内容
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>文件的所有内容</returns>
        public static string ReadText(string fileName)
        {
            return ReadText(fileName, Encoding.Default);
        }

        #endregion

        #region static string ReadText(string fileName, Encoding coding) 用编码读取某个文件的所有内容

        /// <summary>
        /// 用编码读取某个文件的所有内容
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="coding">编码</param>
        /// <returns>文件的所有内容</returns>
        public static string ReadText(string fileName, Encoding coding)
        {
            using (StreamReader reader = new StreamReader(fileName, coding))
            {
                return reader.ReadToEnd();
            }
        }

        #endregion

        #region static void WriteText(string fileName, string text, bool append) 把内容写入某个文件

        /// <summary>
        /// 把内容写入某个文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="text">要写入的内容</param>
        /// <param name="append">是否追加</param>
        public static void WriteText(string fileName, string text, bool append)
        {
            WriteText(fileName, text, append, Encoding.Default);
        }

        #endregion

        #region static void WriteText(string fileName, string text, bool append, Encoding coding) 用编码把内容写入某个文件

        /// <summary>
        /// 用编码把内容写入某个文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="text">要写入的内容</param>
        /// <param name="append">是否追加</param>
        /// <param name="coding">编码</param>
        public static void WriteText(string fileName, string text, bool append, Encoding coding)
        {
            using (StreamWriter writer = new StreamWriter(fileName, append, coding))
            {
                writer.WriteLine(text);
            }
        }

        #endregion
    }
}
