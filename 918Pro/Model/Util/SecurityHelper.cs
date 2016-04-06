using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Util
{
    /// <summary>
    /// 安全相关操作类
    /// </summary>
    public class SecurityHelper
    {
        #region MD5加密

        /// <summary>
        /// 进行MD5加密
        /// </summary>
        /// <param name="inputString">需要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
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

        #region 使用正则表达式验证内容

        /// <summary>
        /// 电子邮件正则表达式。
        /// </summary>
        public const string EMAIL = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        /// <summary>
        /// 网址正则表达式。
        /// </summary>
        public const string URL = "^http[s]?:\\/\\/([\\w-]+\\.)+[\\w-]+([\\w-./?%&=]*)?$";
        /// <summary>
        /// 整数正则表达式。
        /// </summary>
        public const string INT = "^([+-]?)\\d+$";
        /// <summary>
        /// 正整数正则表达式。
        /// </summary>
        public const string INTPLUS = "^([+]?)\\d+$";
        /// <summary>
        /// 负整数正则表达式。
        /// </summary>
        public const string INTNEGATIVE = "^-\\d+$";
        /// <summary>
        /// 数字正则表达式。
        /// </summary>
        public const string NUMBER = "^([+-]?)\\d*\\.?\\d+$";
        /// <summary>
        /// 正数正则表达式。
        /// </summary>
        public const string NUMBERPLUS = "^([+]?)\\d*\\.?\\d+$";
        /// <summary>
        /// 负数正则表达式。
        /// </summary>
        public const string NUMBERNEGATIVE = "^-\\d*\\.?\\d+$";
        /// <summary>
        /// 浮点数正则表达式。
        /// </summary>
        public const string FLOAT = "^([+-]?)\\d*\\.\\d+$";
        /// <summary>
        /// 正浮点数正则表达式。
        /// </summary>
        public const string FLOATPLUS = "^([+]?)\\d*\\.\\d+$";
        /// <summary>
        /// 负浮点数正则表达式。
        /// </summary>
        public const string FLOATNEGATIVE = "^-\\d*\\.\\d+$";
        /// <summary>
        /// 颜色正则表达式。
        /// </summary>
        public const string COLOR = "^#[a-fA-F0-9]{6}";
        /// <summary>
        /// 仅中文正则表达式。
        /// </summary>
        public const string CHINESE = "^[\\u4E00-\\u9FA5\\uF900-\\uFA2D]+$";
        /// <summary>
        /// 仅ACSII字符正则表达式。
        /// </summary>
        public const string ASCII = "^[\\x00-\\xFF]+$";
        /// <summary>
        /// 邮编正则表达式。
        /// </summary>
        public const string ZIPCODE = "^\\d{6}$";
        /// <summary>
        /// 手机正则表达式。
        /// </summary>
        public const string MOBILE = "^0{0,1}13[0-9]{9}$";
        /// <summary>
        /// ip地址正则表达式。
        /// </summary>
        public const string IP4 = @"^\(([0-1]?\d{0,2})|(2[0-5]{0,2}))\.(([0-1]?\d{0,2})|(2[0-5]{0,2}))\.(([0-1]?\d{0,2})|(2[0-5]{0,2}))\.(([0-1]?\d{0,2})|(2[0-5]{0,2}))$";
        /// <summary>
        /// 非空正则表达式。
        /// </summary>
        public const string NOEMPTY = "^[^ ]+$";
        /// <summary>
        /// 图片正则表达式。
        /// </summary>
        public const string PICTURE = "(.*)\\.(jpg|bmp|gif|ico|pcx|jpeg|tif|png|raw|tga)$";
        /// <summary>
        /// 压缩文件正则表达式。
        /// </summary>
        public const string RAR = "(.*)\\.(rar|zip|7zip|tgz)$";
        /// <summary>
        /// 日期正则表达式。
        /// </summary>
        public const string DATE = @"^\d{4}(\-|\/|\.)\d{1,2}\1\d{1,2}$";


        /// <summary>
        /// 使用正则表达式验证内容
        /// </summary>
        /// <param name="reg">使用的正则表达式</param>
        /// <param name="inputString">要验证的内容</param>
        /// <returns>true,匹配;false,不匹配</returns>
        public static bool CheckContent(string reg, string inputString)
        {
            Regex regex = new Regex(reg);
            return regex.IsMatch(inputString);
        }

        #endregion

        #region 确保用户输入的内容没有恶意字符
        /// <summary>
        /// 确保用户输入的内容没有恶意字符
        /// </summary>
        /// <param name="text">输入的内容</param>
        /// <param name="maxLength">最大长度</param>
        /// <returns>干净的内容</returns>
        public static string InputText(string text, int maxLength)
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            if (text.Length > maxLength)
                text = text.Substring(0, maxLength);
            text = Regex.Replace(text, "[\\s]{2,}", " ");	// 除两个以上的空格
            text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	// 替换<br>
            text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//　替换&nbsp;
            text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);	//any other tags
            text = text.Replace("'", "''");
            return text;
        }
        /// <summary>
        /// 过滤内容中的恶意字符
        /// </summary>
        /// <param name="text">输入的内容</param>
        /// <returns>过滤后的内容</returns>
        public static string InputText(string text)
        {
            return InputText(text, text.Length);
        }

        /// <summary>
        /// 过滤内容中的恶意字符
        /// </summary>
        /// <param name="text">输入的内容</param>
        /// <param name="maxLength">最大长度</param>
        /// <returns>过滤后的内容</returns>
        public static string InputValue(string text, int maxLength)
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            if (text.Length > maxLength)
                text = text.Substring(0, maxLength);
            text = Regex.Replace(text, "[\\s]{2,}", " ");	// 除两个以上的空格
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
