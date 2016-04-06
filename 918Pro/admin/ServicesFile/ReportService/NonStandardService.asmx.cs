using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Model;
using BLL;

namespace admin.ServicesFile.ReportService
{
    /// <summary>
    /// NonStandardService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class NonStandardService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(true)]
        public string GetAllTolength(string league, string ballteam, string language)
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
            return OrderdetailouManager.GetAllToJson(leaguestr, ballteam.Replace(';', ','), language,"","");
        }

        [WebMethod(true)]
        public string GetDataByType(string table1, string table2, string type, string game)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return OrderdetailouManager.GetDataByType(table1, table2, type, game,"","");
        }

        [WebMethod(true)]
        public string GetData1x2(string league, string ballteam, string language)
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
            return OrderdetailouManager.GetData1x2(leaguestr, ballteam.Replace(';', ','), language,"","");
        }

        [WebMethod(true)]
        public string GetDataByType1(string table1, string table2, string game)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return OrderdetailouManager.GetDataByType(table1, table2, game);
        }
    }
}
