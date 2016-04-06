using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

namespace agent.Report
{
    public partial class NoteO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string data = "data2=";
            int id = int.Parse(Request["id"].ToString());
            int roid = int.Parse(Request["roid"].ToString());
            int IDex = int.Parse(Request["IDex"].ToString());
            int IDexC = int.Parse(Request["IDexC"].ToString());
            if (roid == 7)
            {
                string un = Request["un"].ToString();
                string lg = Request["lg"].ToString();
                data += AgentManager.getorder(un, lg, IDex, IDexC);
            }
            else
            {
                data += AgentManager.getAgent(id, roid, IDex, IDexC);
            }
            data += ";";
            Response.ContentType = "text/javascript";
            Response.Write(data);
            Response.End();
        }
    }
}