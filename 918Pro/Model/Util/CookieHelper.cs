using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Util
{
    /// <summary>
    /// Cookie��ظ�����
    /// </summary>
    public class CookieHelper
    {
        /// <summary>
        /// ����һ��Cookie(��ʱ��)
        /// </summary>
        /// <param name="cookieName">Cookie����</param>
        /// <param name="cookieValue">Cookieֵ</param>
        /// <param name="ts">ʱ����</param>
        public void SetCookie(string cookieName, string cookieValue)
        {
            SetCookie(cookieName, cookieValue, TimeSpan.Zero);
        }


        /// <summary>
        /// ����һ��Cookie(�־���)
        /// </summary>
        /// <param name="cookieName">Cookie����</param>
        /// <param name="cookieValue">Cookieֵ</param>
        /// <param name="ts">ʱ����</param>
        public void SetCookie(string cookieName, string cookieValue, TimeSpan ts)
        {
            HttpCookie cookie = new HttpCookie(cookieName, cookieValue);
            if (ts != TimeSpan.Zero)
                cookie.Expires = DateTime.Now.Add(ts);
            HttpHelper.CurrentResponse.Cookies.Add(cookie);
        }

        /// <summary>
        /// ȡ��CookieValue
        /// </summary>
        /// <param name="cookieName">Cookie����</param>
        /// <returns>Cookie��ֵ</returns>
        public string GetCookie(string cookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];

            if (cookie != null)
                return cookie.Value;
            else
                return null;
        }

        /// <summary>
        /// ���CookieValue
        /// </summary>
        /// <param name="cookieName">Cookie����</param>
        public void ClearCookie(string cookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpHelper.CurrentResponse.Cookies.Add(cookie);
            }
        }
    }
}
