using System;
using System.Collections.Generic;
using System.Text;

namespace Util
{
    /// <summary>
    /// 字符串相关操作类
    /// </summary>
    public class StringHelper
    {
        #region 截取字符串

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <param name="length">最大长度</param>
        /// <returns>截取后的字符串</returns>
        public static string GetCut(string sourceString, int length)
        {
            return GetCut(sourceString, length, "");
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <param name="length">最大长度</param>
        /// <param name="replaceStr">替换被截取掉的字符串</param>
        /// <returns>截取后的字符串</returns>
        public static string GetCut(string sourceString, int length, string replaceStr)
        {
            if (!string.IsNullOrEmpty(sourceString) && sourceString.Length > length)
            {
                return sourceString.Substring(0, length) + replaceStr;
            }
            return sourceString;
        }

        #endregion

        #region 检查某集合中是否包含某字符串

        /// <summary>
        /// 检查某集合中是否包含某字符串(区分大小写)
        /// </summary>
        /// <param name="findString">要查询的字符串</param>
        /// <param name="allStr">被检查的集合</param>
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

        #region 生成编号
        /// <summary>
        /// 生成编号(登陆编号，存款编号,提款编号,检查客户编号,检查合营商编号)
        /// </summary>
        /// <param name="productType"></param>
        /// <returns></returns>
        public static string getOrder(string productType)
        {
            //获取编号
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


            //返回订单号
            return type + year + month + day + hour + minute + second + Millisecond;
        }
        /// <summary>
        /// 自定义方法，用来填充位数
        /// </summary>
        /// <param name="str">要填充的字符串</param>
        /// <param name="len">填充位数</param>
        /// <returns>返回填充后的字符串</returns>
        public static string addZ(string str, int len)
        {
            for (int i = 0; i < len; i++)
            {
                str = "0" + str;
            }
            return str;
        }
        /// <summary>
        /// 自定义方法，用来获取 类型编号
        /// </summary>
        /// <param name="prType">类型名称</param>
        /// <returns>返回类型名称对应的编号</returns>
        public static string getType(string prType)
        {
            switch (prType)
            {
                case "登陆": return "";
                case "存款": return "D";
                case "提款": return "W";
                case "检查客户": return "C";
                case "检查合营商": return "CF";
                case "财务中心": return "GT";
                case "密码认证": return "PWD";
                case "UUID":return "A0121H2F12W";
                default: return "";
            }
        }
        #endregion
                
    }
}
