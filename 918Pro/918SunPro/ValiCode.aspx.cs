using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _918SunPro
{
    public partial class ValiCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Request.QueryString["type"];
            if (string.IsNullOrEmpty(type))
            {
                type = "0";

            }
            Util.VerifyCodeHelper v = new Util.VerifyCodeHelper();
            v.FontSize = 15;

            v.CreateImageOnPage(v.CreateVerifyCode(4));

            switch (type)
            {
                case "0":
                    //登录验证码
                    Session[Util.ProjectConfig.VALIDATECODE] = v.VerifyCode;
                    break;
                case "1":
                    //注册验证码
                    Session["reg"] = v.VerifyCode;
                    break;
            }

            new Util.CookieHelper().ClearCookie(Util.ProjectConfig.VALIDATECODE);
            //Util.CookieHelper cook = new Util.CookieHelper();
            //cook.SetCookie(Util.ProjectConfig.VALIDATECODE, v.VerifyCode, TimeSpan.FromMinutes(20));

        }
    }
}