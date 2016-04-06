using System;
using System.Collections.Generic;
using System.Text;

namespace Util
{
    /// <summary>
    /// 整形相关操作类
    /// </summary>
    public class IntHelper
    {
        /// <summary>
        /// 把字符串转换为Int
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <param name="defaultValue">转换失败时的默认值</param>
        /// <returns>转换后的结果</returns>
        public static int StrToInt32(string str, int defaultValue)
        {
            int i = 0;
            return Int32.TryParse(str, out i) ? i : defaultValue;
        }
    }
}
