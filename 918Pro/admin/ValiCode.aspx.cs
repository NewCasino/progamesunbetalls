using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin
{
    public partial class ValiCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Util.VerifyCodeHelper v = new Util.VerifyCodeHelper();
            v.FontSize = 15;
            v.CreateImageOnPage(v.CreateVerifyCode(4));
            new Util.CookieHelper().ClearCookie(Util.ProjectConfig.VALIDATECODE);
            Util.CookieHelper cook = new Util.CookieHelper();
            
            cook.SetCookie(Util.ProjectConfig.VALIDATECODE, v.VerifyCode,TimeSpan.FromMinutes(20));

        }
    }
}