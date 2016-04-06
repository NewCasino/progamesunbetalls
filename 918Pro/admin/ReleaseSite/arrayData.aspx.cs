using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace admin.ReleaseSite
{
    public partial class arrayData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string data = "data=";
            if (Request["type"].ToString() == "1")
            {
                data += MatchesManager.GetAllToJson1(Request["langu"].ToString());
            }
            else if (Request["type"].ToString() == "2")
            {
                data += MatchesManager.GetAllToJson2(Request["langu"].ToString(), Request["first"].ToString(), Request["end"].ToString());
            }
            else if (Request["type"].ToString() == "3")
            {
                data += MatchesManager.GetAllToJson3(Request["langu"].ToString());
            }
            else if (Request["type"].ToString() == "4")
            {
                data += Roteds1x21Manager.getToHtml(Request["langu"].ToString(), Request["boll"].ToString());
            }
            else if (Request["type"].ToString() == "5")
            {
                data += Roteds1x21Manager.getzcToHtml(Request["langu"].ToString(), Request["boll"].ToString());
            }
            else if (Request["type"].ToString() == "6")
            {
                data += Roteds1x21Manager.getzdToHtml(Request["langu"].ToString(), Request["boll"].ToString());
            }
            data += ";";
            Response.ContentType = "text/javascript";
            Response.Write(data);
            Response.End();
        }
    }
}