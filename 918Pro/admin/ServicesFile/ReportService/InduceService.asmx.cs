using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using Model;

namespace admin.ServicesFile.ReportService
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
            return OrderotherManager.GetAllTolength(length, leaguestr, type, money, ballteam.Replace(';', ','), language,"","");
        }

        [WebMethod(true)]
        public string GetAllTolength1(string league, string type, string money, string ballteam, string language,string time1,string time2,string account)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return OrderotherManager.GetAllTolength1(league, type, money, ballteam, language, time1,time2, account);
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
