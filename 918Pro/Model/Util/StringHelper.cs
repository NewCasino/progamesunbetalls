using System;
using System.Collections.Generic;
using System.Text;

namespace Util
{
    /// <summary>
    /// �ַ�����ز�����
    /// </summary>
    public class StringHelper
    {
        #region ��ȡ�ַ���

        /// <summary>
        /// ��ȡ�ַ���
        /// </summary>
        /// <param name="sourceString">Դ�ַ���</param>
        /// <param name="length">��󳤶�</param>
        /// <returns>��ȡ����ַ���</returns>
        public static string GetCut(string sourceString, int length)
        {
            return GetCut(sourceString, length, "");
        }

        /// <summary>
        /// ��ȡ�ַ���
        /// </summary>
        /// <param name="sourceString">Դ�ַ���</param>
        /// <param name="length">��󳤶�</param>
        /// <param name="replaceStr">�滻����ȡ�����ַ���</param>
        /// <returns>��ȡ����ַ���</returns>
        public static string GetCut(string sourceString, int length, string replaceStr)
        {
            if (!string.IsNullOrEmpty(sourceString) && sourceString.Length > length)
            {
                return sourceString.Substring(0, length) + replaceStr;
            }
            return sourceString;
        }

        #endregion

        #region ���ĳ�������Ƿ����ĳ�ַ���

        /// <summary>
        /// ���ĳ�������Ƿ����ĳ�ַ���(���ִ�Сд)
        /// </summary>
        /// <param name="findString">Ҫ��ѯ���ַ���</param>
        /// <param name="allStr">�����ļ���</param>
        /// <returns>bool</returns>
        public static bool Contains(string findString,List<string> allStr)
        {
            foreach (string s in allStr)
            {
                if (s.Contains(findString))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region ���ɱ��
        /// <summary>
        /// ���ɱ��(��½��ţ������,�����,���ͻ����,����Ӫ�̱��)
        /// </summary>
        /// <param name="productType"></param>
        /// <returns></returns>
        public static string getOrder(string productType)
        {
            //��ȡ���
            string type = getType(productType);
            string year = DateTime.Now.Year.ToString();
            year = (2 - year.Length) != 0 ? addZ(year, 2 - year.Length) : year.ToString();  
            string month = DateTime.Now.Month.ToString();
            month = (2 - month.Length) != 0 ? addZ(month, 2 - month.Length) : month.ToString();           
            string day = DateTime.Now.Day.ToString();
            day = (2 - day.Length) != 0 ? addZ(day, 2 - day.Length) : day.ToString();          
            string hour = DateTime.Now.Hour.ToString();
            hour = (2 - hour.Length) != 0 ? addZ(hour, 2 - hour.Length) : hour.ToString();        
            string minute = DateTime.Now.Minute.ToString();
            minute = (2 - minute.Length) != 0 ? addZ(minute, 2 - minute.Length) : minute.ToString();         
            string second = DateTime.Now.Second.ToString();
            second = (2 - second.Length) != 0 ? addZ(second, 2 - second.Length) : second.ToString();
            string Millisecond = DateTime.Now.Millisecond.ToString();
            Millisecond = (3 - Millisecond.Length) != 0 ? addZ(Millisecond, 3 - Millisecond.Length) : Millisecond.ToString();


            //���ض�����
            return type + year + month + day + hour + minute + second + Millisecond;
        }
        /// <summary>
        /// �Զ��巽�����������λ��
        /// </summary>
        /// <param name="str">Ҫ�����ַ���</param>
        /// <param name="len">���λ��</param>
        /// <returns>����������ַ���</returns>
        public static string addZ(string str, int len)
        {
            for (int i = 0; i < len; i++)
            {
                str = "0" + str;
            }
            return str;
        }
        /// <summary>
        /// �Զ��巽����������ȡ ���ͱ��
        /// </summary>
        /// <param name="prType">��������</param>
        /// <returns>�����������ƶ�Ӧ�ı��</returns>
        public static string getType(string prType)
        {
            switch (prType)
            {
                case "��½": return "";
                case "���": return "D";
                case "���": return "W";
                case "���ͻ�": return "C";
                case "����Ӫ��": return "CF";
                case "��������": return "GT";
                case "������֤": return "PWD";
                case "UUID":return "A0121H2F12W";
                default: return "";
            }
        }
        #endregion
                
    }
}
