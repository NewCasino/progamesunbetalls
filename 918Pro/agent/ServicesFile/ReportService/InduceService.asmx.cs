using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using Model;

namespace agent.ServicesFile.ReportService
{
    /// <summary>
    /// InduceService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class InduceService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(true)]
        public string GetAllTolength(string length, string league, string type, string money, string ballteam, string language)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

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
            return OrderotherManager.GetAllTolength(length, leaguestr, type, money, ballteam.Replace(';', ','), language, page.agentUserName, ag[page.agentRoleID - 2]);
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


        /*-----------会员注单------------------*/
        [WebMethod(true)]
        public string getCount(int id, int roid)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return OrderotherManager.getCount(id, roid);
        }

        [WebMethod(true)]
        public string getUserCount(string un)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return OrderotherManager.getUserCount(un);
        }
        /*-----------会员注单结束-----------------*/
    }
}
