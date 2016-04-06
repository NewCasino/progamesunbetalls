using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace agent.Report
{
    public partial class str : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string league = "";
            string ballteam = "";
            string language = "";
            league = Request["league"].ToString();
            ballteam = Request["ballteam"].ToString();
            language = Request["language"].ToString();
            string data = "data1=";
            PageBase page = new PageBase();
            List<string> ag = new List<string>();
            ag = getag();
            string leaguestr = "";
            if (league != "")
            {
                string[] leagueAll = league.Split(';');
                for (int i = 0; i < leagueAll.Length; i++)
                {
                    if (i != 0)
                    {
                        leaguestr += ",";
                    }
                    leaguestr += "'" + leagueAll[i] + "'";
                }
            }
            data += OrderdetailouManager.GetData1x2(leaguestr, ballteam.Replace(';', ','), language, page.agentUserName, ag[page.agentRoleID - 2]);
            if (data == "data1=]")
            {
                data = "data1=\"\"";
            }
            data += ";";
            Response.ContentType = "text/javascript";
            Response.Write(data);
            Response.End();
        }

        public List<string> getag()
        {
            List<string> ag = new List<string>();
            ag.Add("SubCompany");
            ag.Add("Partner");
            ag.Add("ZAgent");
            ag.Add("Agent");
            return ag;
        }
    }
}