using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Util
{
    /// <summary>
    /// �ļ���ز�����
    /// </summary>
    public static class FileHelper
    {
        #region static string ReadLine(string fileName) ��ȡĳ���ļ���һ������

        /// <summary>
        /// ��ȡĳ���ļ���һ������
        /// </summary>
        /// <param name="fileName">�ļ���</param>
        /// <returns>��ȡ������</returns>
        public static string ReadLine(string fileName)
        {
            return ReadLine(fileName, Encoding.Default);
        }

        #endregion

        #region static string ReadLine(string fileName, Encoding coding) �ñ����ȡĳ���ļ���һ������

        /// <summary>
        /// �ñ����ȡĳ���ļ���һ������
        /// </summary>
        /// <param name="fileName">�ļ���</param>
        /// <param name="coding">����</param>
        /// <returns>��ȡ������</returns>
        public static string ReadLine(string fileName, Encoding coding)
        {
            using (StreamReader reader = new StreamReader(fileName, coding))
            {
                return reader.ReadLine();
            }
        }

        #endregion

        #region static string ReadText(string fileName) ��ȡĳ���ļ�����������

        /// <summary>
        /// ��ȡĳ���ļ�����������
        /// </summary>
        /// <param name="fileName">�ļ���</param>
        /// <returns>�ļ�����������</returns>
        public static string ReadText(string fileName)
        {
            return ReadText(fileName, Encoding.Default);
        }

        #endregion

        #region static string ReadText(string fileName, Encoding coding) �ñ����ȡĳ���ļ�����������

        /// <summary>
        /// �ñ����ȡĳ���ļ�����������
        /// </summary>
        /// <param name="fileName">�ļ���</param>
        /// <param name="coding">����</param>
        /// <returns>�ļ�����������</returns>
        public static string ReadText(string fileName, Encoding coding)
        {
            using (StreamReader reader = new StreamReader(fileName, coding))
            {
                return reader.ReadToEnd();
            }
        }

        #endregion

        #region static void WriteText(string fileName, string text, bool append) ������д��ĳ���ļ�

        /// <summary>
        /// ������д��ĳ���ļ�
        /// </summary>
        /// <param name="fileName">�ļ���</param>
        /// <param name="text">Ҫд�������</param>
        /// <param name="append">�Ƿ�׷��</param>
        public static void WriteText(string fileName, string text, bool append)
        {
            WriteText(fileName, text, append, Encoding.Default);
        }

        #endregion

        #region static void WriteText(string fileName, string text, bool append, Encoding coding) �ñ��������д��ĳ���ļ�

        /// <summary>
        /// �ñ��������д��ĳ���ļ�
        /// </summary>
        /// <param name="fileName">�ļ���</param>
        /// <param name="text">Ҫд�������</param>
        /// <param name="append">�Ƿ�׷��</param>
        /// <param name="coding">����</param>
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
