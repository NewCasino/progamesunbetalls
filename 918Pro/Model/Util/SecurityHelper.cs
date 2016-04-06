using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Util
{
    /// <summary>
    /// ��ȫ��ز�����
    /// </summary>
    public class SecurityHelper
    {
        #region MD5����

        /// <summary>
        /// ����MD5����
        /// </summary>
        /// <param name="inputString">��Ҫ���ܵ��ַ���</param>
        /// <returns>���ܺ���ַ���</returns>
        public static string MD5Encrypt(string inputString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encryptedBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(inputString));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                sb.AppendFormat("{0:x2}", encryptedBytes[i]);
            }
            return sb.ToString();
        }

        #endregion

        #region ʹ��������ʽ��֤����

        /// <summary>
        /// �����ʼ�������ʽ��
        /// </summary>
        public const string EMAIL = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        /// <summary>
        /// ��ַ������ʽ��
        /// </summary>
        public const string URL = "^http[s]?:\\/\\/([\\w-]+\\.)+[\\w-]+([\\w-./?%&=]*)?$";
        /// <summary>
        /// ����������ʽ��
        /// </summary>
        public const string INT = "^([+-]?)\\d+$";
        /// <summary>
        /// ������������ʽ��
        /// </summary>
        public const string INTPLUS = "^([+]?)\\d+$";
        /// <summary>
        /// ������������ʽ��
        /// </summary>
        public const string INTNEGATIVE = "^-\\d+$";
        /// <summary>
        /// ����������ʽ��
        /// </summary>
        public const string NUMBER = "^([+-]?)\\d*\\.?\\d+$";
        /// <summary>
        /// ����������ʽ��
        /// </summary>
        public const string NUMBERPLUS = "^([+]?)\\d*\\.?\\d+$";
        /// <summary>
        /// ����������ʽ��
        /// </summary>
        public const string NUMBERNEGATIVE = "^-\\d*\\.?\\d+$";
        /// <summary>
        /// ������������ʽ��
        /// </summary>
        public const string FLOAT = "^([+-]?)\\d*\\.\\d+$";
        /// <summary>
        /// ��������������ʽ��
        /// </summary>
        public const string FLOATPLUS = "^([+]?)\\d*\\.\\d+$";
        /// <summary>
        /// ��������������ʽ��
        /// </summary>
        public const string FLOATNEGATIVE = "^-\\d*\\.\\d+$";
        /// <summary>
        /// ��ɫ������ʽ��
        /// </summary>
        public const string COLOR = "^#[a-fA-F0-9]{6}";
        /// <summary>
        /// ������������ʽ��
        /// </summary>
        public const string CHINESE = "^[\\u4E00-\\u9FA5\\uF900-\\uFA2D]+$";
        /// <summary>
        /// ��ACSII�ַ�������ʽ��
        /// </summary>
        public const string ASCII = "^[\\x00-\\xFF]+$";
        /// <summary>
        /// �ʱ�������ʽ��
        /// </summary>
        public const string ZIPCODE = "^\\d{6}$";
        /// <summary>
        /// �ֻ�������ʽ��
        /// </summary>
        public const string MOBILE = "^0{0,1}13[0-9]{9}$";
        /// <summary>
        /// ip��ַ������ʽ��
        /// </summary>
        public const string IP4 = @"^\(([0-1]?\d{0,2})|(2[0-5]{0,2}))\.(([0-1]?\d{0,2})|(2[0-5]{0,2}))\.(([0-1]?\d{0,2})|(2[0-5]{0,2}))\.(([0-1]?\d{0,2})|(2[0-5]{0,2}))$";
        /// <summary>
        /// �ǿ�������ʽ��
        /// </summary>
        public const string NOEMPTY = "^[^ ]+$";
        /// <summary>
        /// ͼƬ������ʽ��
        /// </summary>
        public const string PICTURE = "(.*)\\.(jpg|bmp|gif|ico|pcx|jpeg|tif|png|raw|tga)$";
        /// <summary>
        /// ѹ���ļ�������ʽ��
        /// </summary>
        public const string RAR = "(.*)\\.(rar|zip|7zip|tgz)$";
        /// <summary>
        /// ����������ʽ��
        /// </summary>
        public const string DATE = @"^\d{4}(\-|\/|\.)\d{1,2}\1\d{1,2}$";


        /// <summary>
        /// ʹ��������ʽ��֤����
        /// </summary>
        /// <param name="reg">ʹ�õ�������ʽ</param>
        /// <param name="inputString">Ҫ��֤������</param>
        /// <returns>true,ƥ��;false,��ƥ��</returns>
        public static bool CheckContent(string reg, string inputString)
        {
            Regex regex = new Regex(reg);
            return regex.IsMatch(inputString);
        }

        #endregion

        #region ȷ���û����������û�ж����ַ�
        /// <summary>
        /// ȷ���û����������û�ж����ַ�
        /// </summary>
        /// <param name="text">���������</param>
        /// <param name="maxLength">��󳤶�</param>
        /// <returns>�ɾ�������</returns>
        public static string InputText(string text, int maxLength)
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            if (text.Length > maxLength)
                text = text.Substring(0, maxLength);
            text = Regex.Replace(text, "[\\s]{2,}", " ");	// ���������ϵĿո�
            text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	// �滻<br>
            text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//���滻&nbsp;
            text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);	//any other tags
            text = text.Replace("'", "''");
            return text;
        }
        /// <summary>
        /// ���������еĶ����ַ�
        /// </summary>
        /// <param name="text">���������</param>
        /// <returns>���˺������</returns>
        public static string InputText(string text)
        {
            return InputText(text, text.Length);
        }

        /// <summary>
        /// ���������еĶ����ַ�
        /// </summary>
        /// <param name="text">���������</param>
        /// <param name="maxLength">��󳤶�</param>
        /// <returns>���˺������</returns>
        public static string InputValue(string text, int maxLength)
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            if (text.Length > maxLength)
                text = text.Substring(0, maxLength);
            text = Regex.Replace(text, "[\\s]{2,}", " ");	// ���������ϵĿո�
            text = text.Replace("'", "''");
            text = text.Replace("%", "[%]");
            text = text.Replace("_", "[_]");
            return text;
        }
        public static string InputValue(string text)
        {
            return InputValue(text, text.Length);
        }
        #endregion
    }
}
