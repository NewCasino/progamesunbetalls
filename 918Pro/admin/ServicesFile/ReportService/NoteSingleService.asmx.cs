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
    /// NoteSingleService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class NoteSingleService : System.Web.Services.WebService
    {

        [WebMethod(true)]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// 即时监控（亚洲盘及大小盘）
        /// </summary>
        /// <param name="language">语言</param>
        /// <param name="league">联赛</param>
        /// <param name="gameId">队伍</param>
        /// <param name="limi">取记录数</param>
        /// <param name="btype">类型 all:全部，hf:半场，fl:全场</param>
        /// <returns></returns>
        [WebMethod(true)]
        public string GetHdpAndOu(string language, string league, string gameId, string limi, string btype)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            OrderdetailouManager om = new OrderdetailouManager();
            return om.GetHdpAndOu(language, league, gameId, "", "", limi, btype);
        }

        [WebMethod(true)]
        public string GetHdpAndOu2(string language, string league, string gameId, string limi, string btype, string mtype)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            OrderdetailouManager om = new OrderdetailouManager();
            return om.GetHdpAndOu2(language, league, gameId, "", "", limi, btype, mtype);
        }

        /// <summary>
        /// 即时监控（1x2）
        /// </summary>
        /// <param name="language">语言</param>
        /// <param name="league">联赛</param>
        /// <param name="gameId">队伍</param>
        /// <param name="limi">取记录数</param>
        /// <returns></returns>
        [WebMethod(true)]
        public string Get1x2(string language, string league, string gameId, string limi)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            OrderdetailouManager om = new OrderdetailouManager();
            return om.Get1x2(language, league, gameId, "", "", limi);
        }

        [WebMethod(true)]
        public string Get1x22(string language, string league, string gameId, string limi, string mtype)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            OrderdetailouManager om = new OrderdetailouManager();
            return om.Get1x22(language, league, gameId, "", "", limi, mtype);
        }

        /// <summary>
        /// 会员注单
        /// </summary>
        /// <param name="userName">上级代理帐号</param>
        /// <param name="roleId">当前角色ID</param>
        /// <returns></returns>
        [WebMethod(true)]
        public string GetUserOrder(string userName, string roleId)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            OrderdetailouManager om = new OrderdetailouManager();
            return om.GetUserOrder(userName, roleId);
        }

        [WebMethod(true)]
        public string GetAllTolength(string length, string league, string level, string type, string money, string ballteam, string language)
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
            return Orderdetail1x2hflManager.GetAllTolength(length, leaguestr, level, type, money, ballteam.Replace(';', ','),language,"","");
        }
        [WebMethod(true)]
        public string GetLeagueToJson(string language)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return MatchesManager.GetLeagueToJson(language);
        }

        [WebMethod(true)]
        public string GetBollToJson(string language)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return MatchesManager.GetBollToJson(language);
        }

        [WebMethod(true)]
        public string GetBollToJson1(string language)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return MatchesManager.GetBollToJson1(language);
        }

        [WebMethod(true)]
        public string GetUserLevel(string language)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return MatchesManager.GetUserLevel(language);
        }
    }
}
