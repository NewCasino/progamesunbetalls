using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
    public class ProjectConfig
    {
        public  const string ADMINUSER = "managerUser";
        public const string VALIDATECODE = "vacode";
        public const string LANGUAGE_COOK = "language";
        public const string LOGINUSER = "currentUser";

        public const string REFRESHTIME_COOKIE = "lrt";

        public static void CheckLanCookieValue()
        {
            CookieHelper cooke = new CookieHelper();
            string lan = cooke.GetCookie(LANGUAGE_COOK);
            if (lan != "zh-cn" && lan != "zh-tw" && lan != "en-us" && lan != "th-th" && lan != "vi-vn")
            {//防止伪造Cookie
                cooke.SetCookie(LANGUAGE_COOK, "zh-tw");
            }

        }

        public static string GetLanCookieValue()
        {
            CheckLanCookieValue();
            CookieHelper cooke = new CookieHelper();
            string lan = cooke.GetCookie(LANGUAGE_COOK);
            lan = lan.Substring(lan.IndexOf('-') + 1);
            return lan == "us" ? "en" : lan;
        }
    }
}
