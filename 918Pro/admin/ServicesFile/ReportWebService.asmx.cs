using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DAL;
using Model;
using BLL;

namespace admin.ServicesFile
{
    /// <summary>
    /// ReportWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class ReportWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(true)]
        public string GetMatchResult(string time1, string time2, string language,string league,string home,string away, string status)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return OrderhistoryManager.GetMatchResult(time1, time2, language,league, home, away, status);
        }

        [WebMethod(true)]
        public string GetMatchAll(string time1, string time2, string language, string status, string agentName, string roleId)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return OrderhistoryManager.GetMatchAll(time1,time2, language, status,agentName,roleId);
        }

        [WebMethod(true)]
        public string GetMatchAll2(string time1, string time2, string language, string status, string agentName, string roleId, string mtype)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return OrderhistoryManager.GetMatchAll2(time1, time2, language, status, agentName, roleId, mtype);
        }

        [WebMethod(true)]
        public string GetMatch(string time1,string time2 ,string language, string status, int roleId, string UpUserName)
        {
            //if (time1 == "")
            //{
            //    time1 = DateTime.Now.ToString("yyyy-MM-dd");
            //}
            //if (roleId == 6)
            //{
            //    //会员
            //    return ObjectToJson.ObjectListToJson<Orderhistory>(OrderhistoryManager.GetMatchUser(time1, language, status,"0"));

            //}
            //else
            //{
                //代理
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

                if (UpUserName == "#")
                {
                    return OrderhistoryManager.GetMatch(time1,time2, language, status, roleId);
                }
                else
                {
                    return OrderhistoryManager.GetMatchs(time1,time2, language, status, roleId, UpUserName);
                }
            //} 
        }

        [WebMethod(true)]
        public string GetMatch2(string time1, string time2, string language, string status, int roleId, string UpUserName, string mtype)
        {
            //if (time1 == "")
            //{
            //    time1 = DateTime.Now.ToString("yyyy-MM-dd");
            //}
            //if (roleId == 6)
            //{
            //    //会员
            //    return ObjectToJson.ObjectListToJson<Orderhistory>(OrderhistoryManager.GetMatchUser(time1, language, status,"0"));

            //}
            //else
            //{
            //代理
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return OrderhistoryManager.GetMatchs2(time1, time2, language, status, roleId, UpUserName, mtype);

            //if (UpUserName == "#")
            //{
            //    return OrderhistoryManager.GetMatch2(time1, time2, language, status, roleId, mtype);
            //}
            //else
            //{
            //    return OrderhistoryManager.GetMatchs2(time1, time2, language, status, roleId, UpUserName, mtype);
            //}
            //} 
        }

        [WebMethod(true)]
        public string GetMatch3(string time1, string time2, string language, string status, int roleId, string UpUserName, string mtype)
        {
            //if (time1 == "")
            //{
            //    time1 = DateTime.Now.ToString("yyyy-MM-dd");
            //}
            //if (roleId == 6)
            //{
            //    //会员
            //    return ObjectToJson.ObjectListToJson<Orderhistory>(OrderhistoryManager.GetMatchUser(time1, language, status,"0"));

            //}
            //else
            //{
            //代理
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            if (UpUserName == "#")
            {
                return OrderhistoryManager.GetMatch3(time1, time2, language, status, roleId, mtype);
            }
            else
            {
                return OrderhistoryManager.GetMatchs3(time1, time2, language, status, roleId, UpUserName, mtype);
            }
            //} 
        }

        [WebMethod(true)]
        public string LeagueOrderDetail(string time1, string time2, string language, string status, string gameid, string betType, string agentName, string roleId)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return OrderhistoryManager.LeagueOrderDetail(time1, time2, language, status, gameid, betType, agentName, roleId);
        }

        [WebMethod(true)]
        public string LeagueOrderDetail2(string time1, string time2, string language, string status, string gameid, string betType, string agentName, string roleId, string mtype)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return OrderhistoryManager.LeagueOrderDetail2(time1, time2, language, status, gameid, betType, agentName, roleId, mtype);
        }

        [WebMethod(true)]
        public string GetUserName(string time1,string time2, string language, string status, string userName)
        { 
            //if (time == "")
            //{
            //    time = DateTime.Now.ToString("yyyy-MM-dd");
            //}
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return OrderhistoryManager.GetUserName(time1,time2, language,status,userName);
        }

        [WebMethod(true)]
        public string GetUserName2(string time1, string time2, string language, string status, string userName, string mtype)
        {
            //if (time == "")
            //{
            //    time = DateTime.Now.ToString("yyyy-MM-dd");
            //}
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return OrderhistoryManager.GetUserName2(time1, time2, language, status, userName, mtype);
        }

        [WebMethod(true)]
        public string GetStatisticsT(string time1, string time2, string group, int sort, string user,string ip)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string json = "";

            json = OrderhistoryManager.GetStatisticsT(time1, time2, group, sort,user,ip);
            if (json == "[]")
            {
                json = "none";
            }
            return json;
        }
        [WebMethod(true)]
        public string GetStatisticsIpT(string time1, string time2, string group, int sort, string user, string ip)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string json = "";

            json = OrderhistoryManager.GetStatisticsIpT(time1, time2, group, sort, user, ip);
            if (json == "[]")
            {
                json = "none";
            }
            return json;
        }

        [WebMethod(true)]
        public string GetStatisticsY(string type, int number, string group, int sort, string user, string ip)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string json = "";

            json = OrderhistoryManager.GetStatisticsY(type, number, group, sort,user,ip);
            if (json == "[]")
            {
                json = "none";
            }
            return json;
        }
        [WebMethod(true)]
        public string StatisticsIp(string Ip, string language)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return OrderhistoryManager.StatisticsIp(Ip,language);
        }
        [WebMethod(true)]
        public string StatisticsIpT(string time1, string time2, string group, int sort, string ip,string language)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string json = "";

            json = OrderhistoryManager.StatisticsIpT(time1, time2, group, sort, ip,language);
            if (json == "[]")
            {
                json = "none";
            }
            return json;
        }
        [WebMethod(true)]
        public string StatisticsIpY(string type, int number, string group, int sort, string ip, string language)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string json = "";

            json = OrderhistoryManager.StatisticsIpY(type, number, group, sort, ip,language);
            if (json == "[]")
            {
                json = "none";
            }
            return json;
        }
        [WebMethod(true)]
        public string GetStatisticsIpY(string type, int number, string group, int sort, string user, string ip)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string json = "";

            json = OrderhistoryManager.GetStatisticsIpY(type, number, group, sort, user, ip);
            if (json == "[]")
            {
                json = "none";
            }
            return json;
        }
        [WebMethod(true)]
        public string GetGrade(string language)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return GradeManager.GetGrade(language);
        }
        [WebMethod(true)]
        public string stringGetUserNamesA(string userName)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return UserManager.stringGetUserNamesA(userName);
        }

        [WebMethod(true)]
        public string GetGradeName(int id,string language)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return GradeManager.GetGradeName(id,language);
        }
        [WebMethod(true)]
        public string GetGradeId(string name,string language)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return GradeManager.GetGradeId(name,language);
        }
        [WebMethod(true)]
        public string UpdateUserLevel(string userName, string userLevel)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string json = "";
            bool reval = UserManager.UpdateUserLevel(userName,userLevel);
            if (reval)
            {
                json = "ok";
            }
            else {
                json = "on";
            }
            return json;
        }

        [WebMethod(true)]
        public string GetOrderGroupByWebsiteID(string stime, string etime, string lan, string yy, string websiteid, string agent, string webusername)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            OrderotherhistoryManager om = new OrderotherhistoryManager();
            return om.GetOrderGroupByWebsiteID(stime,etime,lan,yy,websiteid,agent,webusername);
        }

        [WebMethod(true)]
        public string GetOrderByWebsiteID(int websiteID, string agent, string webusername, string stime, string etime, string lan)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            OrderotherhistoryManager om = new OrderotherhistoryManager();
            return om.GetOrderByWebsiteID(websiteID,agent,webusername,stime,etime,lan);
        }

        [WebMethod(true)]
        public int GetOrderCountByWebsiteID(int websiteID, string stime, string etime)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return 0;
            }

            OrderotherhistoryManager om = new OrderotherhistoryManager();
            return om.GetOrderCountByWebsiteID(websiteID,stime,etime);
        }
    }
}
