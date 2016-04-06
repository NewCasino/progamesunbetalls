using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DAL;
using Model;
using BLL;

namespace agent.ServicesFile
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
        PageBase page = new PageBase();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
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
        public string GetMatchResults(string time1, string time2, string language, string status)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            int roleId = page.agentRoleID;
            string user = page.agentUserName;
            return OrderhistoryManager.GetMatchResults(time1, time2, language, status, roleId, user);
        }

        [WebMethod(true)]
        public string GetMatchAlls(string time1, string time2, string language, string status)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            int roleId = page.agentRoleID;
            string user = page.agentUserName;
            return OrderhistoryManager.GetMatchAlls(time1, time2, language, status,roleId,user);
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
        public string GetMatch(string time1, string time2, string language, string status, int roleId, string UpUserName)
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
                return OrderhistoryManager.GetMatch(time1, time2, language, status, roleId);
            }
            else
            {
                return OrderhistoryManager.GetMatchs(time1, time2, language, status, roleId, UpUserName);
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

            if (UpUserName == "#")
            {
                return OrderhistoryManager.GetMatch2(time1, time2, language, status, roleId, mtype);
            }
            else
            {
                return OrderhistoryManager.GetMatchs2(time1, time2, language, status, roleId, UpUserName, mtype);
            }
            //} 
        }

        [WebMethod(true)]
        public string GetMatch2Agent(string time1, string time2, string language, string status, int roleId, string UpUserName, string mtype)
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
                return OrderhistoryManager.GetMatch2(time1, time2, language, status, roleId, mtype);
            }
            else
            {
                return OrderhistoryManager.GetMatchs2Agent(time1, time2, language, status, roleId, UpUserName, mtype);
            }
            //} 
        }

        [WebMethod(true)]
        public string GetUserName(string time1,string time2, string language, string status, string userName)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            //if (time == "")
            //{
            //    time = DateTime.Now.ToString("yyyy-MM-dd");
            //}
            return OrderhistoryManager.GetUserName(time1,time2, language,status,userName);
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

            return GradeManager.GetGradeName(id, language);
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
    }
}
