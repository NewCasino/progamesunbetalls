using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _918SunPro.portal_asset.templates
{
    public partial class memberCenter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ////获得cookie
                //HttpCookie cookie = Request.Cookies["tgp_cuser"];
                ////确定是否存在用户输入的cookie
                //if (null == cookie)
                //{
                //    Response.Redirect("index.html");
                //    Response.End();
                //}                 
               


            }
          
        }
    }
}