using System;
using System.Collections.Generic;
using System.Text;

namespace Util
{
    /// <summary>
    /// ������ز�����
    /// </summary>
    public class IntHelper
    {
        /// <summary>
        /// ���ַ���ת��ΪInt
        /// </summary>
        /// <param name="str">Ҫת�����ַ���</param>
        /// <param name="defaultValue">ת��ʧ��ʱ��Ĭ��ֵ</param>
        /// <returns>ת����Ľ��</returns>
        public static int StrToInt32(string str, int defaultValue)
        {
            int i = 0;
            return Int32.TryParse(str, out i) ? i : defaultValue;
        }
    }
}
