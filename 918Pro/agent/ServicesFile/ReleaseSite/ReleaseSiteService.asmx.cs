using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Model;
using BLL;

namespace agent.ServicesFile.ReleaseSite
{
    /// <summary>
    /// ReleaseSiteService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class ReleaseSiteService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(EnableSession = true)]
        public string insertInfo(string time, string leaguecn, string leaguetw, string leagueen, string leagueth, string leaguevn, string leaguecolor, string leaguetype,
            string number, string homecn, string hometw, string homeen, string hometh, string homevn, string awaycn, string awaytw, string awayen, string awayth,
            string awayvn, string display, string running)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            Matches match = new Matches();
            /*默认数据*/
            match.Home1 = "";
            match.League1 = "";
            match.Away1 = "";
            match.Matchid = "";
            match.Score = "0:0";
            match.Redcard = "00";
            match.Danger = 0;
            match.Dotime = "0";
            match.Isstart = 0;
            match.State = 1;
            match.Resultawayscore = "0";
            match.Resulthomescore = "0";
            match.Halfawayscore = "0";
            match.Halfhomescore = "0";
            match.Updatetime = DateTime.Now;
            match.Casino = 0;

            /*新增页面的数据*/
            match.Time = time.Substring(5, time.Length - 3);
            match.Leaguecn = leaguecn;
            match.Leagueen = leagueen;
            match.Leagueth = leagueth;
            match.Leaguetw = leaguetw;
            match.Leaguevn = leaguevn;
            match.Homecn = homecn;
            match.Homeen = homeen;
            match.Hometh = hometh;
            match.Hometw = hometw;
            match.Homevn = homevn;
            match.Awaycn = awaycn;
            match.Awayen = awayen;
            match.Awayth = awayth;
            match.Awaytw = awaytw;
            match.Awayvn = awayvn;
            match.Begintime = DateTime.Parse(time);
            match.Number = int.Parse(number);
            match.Type = int.Parse(leaguetype);
            match.Running = int.Parse(running);
            match.Display = int.Parse(display);
            match.Color = leaguecolor;
            return MatchesManager.AddMatches(match).ToString();
        }

        //string leaguecn, string leaguetw, string leagueen, string leagueth, string leaguevn,
        //string homecn, string hometw, string homeen, string hometh, string homevn,
        //string awaycn, string awaytw, string awayen, string awayth, string awayvn,string number,
        [WebMethod(EnableSession = true)]
        public string updateInfo(string id,string time, string leaguecolor, string leaguetype, string display, string running,string score,
            string redcard, string danger,string number)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            int id1 = Convert.ToInt32(id);
            Matches match = MatchesManager.GetMatchesByPK(id1);
            
            match.Color = leaguecolor;
            match.Type = int.Parse(leaguetype);
            match.Display = int.Parse(display);
            match.Running = int.Parse(running);
            match.Number = int.Parse(number);

            if (match.Begintime < DateTime.Now)
            {
                match.Score = score;
                match.Danger = int.Parse(danger);
                match.Redcard = redcard;
            }
            match.Begintime = DateTime.Now;
            match.Time = time.Substring(5, time.Length - 3 - 5);
            
            return MatchesManager.UpdateMatches(match).ToString();
        }

        [WebMethod(EnableSession = true)]
        public string GetAllToJson(string language)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return MatchesManager.GetAllToJson1(language);
        }

        [WebMethod(EnableSession = true)]
        public string GetCount()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return MatchesManager.GetCount();
        }

        ///*---------这是比分录入的方法-------------*/
        //[WebMethod(EnableSession = true)]
        //public string updatescore(string id,string home,string away,string halfhome,string halfaway)
        //{
        //    if (Session[Util.ProjectConfig.ADMINUSER] == null)
        //    {
        //        return "";
        //    }

        //    return MatchesManager.updatescore(id, home, away, halfhome, halfaway).ToString();
        //}
        ///*---------比分录入的方法结束-------------*/

        /*---------------结算的方法-------------------*/
        [WebMethod(EnableSession = true)]
        public string jsff(string g, string hl,string ss)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string[] gi = g.Split(',');
            string[] hls = hl.Split(',');
            string[] s1 = ss.Split(',');
            for (int i = 0; i < gi.Length; i++)
            {
                List<Orderdetail1x2> order = Orderdetail1x2Manager.getorderAll(int.Parse(gi[i]));//获得该场比赛的所有注单
                for (int j = 0; j < order.Count; j++)
                {
                    Orderhistory h = new Orderhistory();
                    order[j].Score = s1[i];
                    switch (int.Parse(order[j].BetType))
                    {
                        /*-----半场让球--------*/
                        case 2:
                        case 6:
                        case 10:
                            if (order[j].BetType == "6")
                            {
                                OrderdetailhdphflManager.DeleteOrderdetailhdphflByPK(order[j].ID);
                            }
                            else
                            {
                                OrderdetailhdphfManager.DeleteOrderdetailhdphfByPK(order[j].ID);
                            }
                            if(order[j].Status == "0")
                            {
                                break;
                            }
                            int a = 0;
                            double b = 0;
                            if (order[j].Handicap.IndexOf("-") != -1)
                            {
                                /*-------选择主队时a与b的值---------*/
                                if (order[j].Betflag == "H")
                                {
                                    a = int.Parse(hls[i].Substring(0, hls[i].IndexOf(':'))) - int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1));
                                    b = a - double.Parse(order[j].Handicap.ToString().Substring(1));
                                }
                                /*-------选择客队时a与b的值--------*/
                                else if (order[j].Betflag == "A")
                                {
                                    a = int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1)) - int.Parse(hls[i].Substring(0, hls[i].IndexOf(':')));
                                    b = a - double.Parse(order[j].Handicap.ToString().Substring(1));
                                }
                                /*-------让球数有两个时即(一球/球半)这种情况--------*/
                                double za = double.Parse(order[j].Handicap.Substring(1)) / 0.5;
                                if (int.Parse(za.ToString().Substring(0, (za.ToString().IndexOf('.') == -1 ? za.ToString().Length : za.ToString().IndexOf('.')))) < za)
                                {
                                    if (a < 0)
                                    {
                                        h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                                    }
                                    else if (b > 0)
                                    {
                                        if (b == 0.25)
                                        {
                                            h.Result = Convert.ToDecimal((order[j].Odds > 0 ? order[j].Amount / 2 : order[j].ValidAmount / 2));
                                        }
                                        else if (b > 0.25)
                                        {
                                            h.Result = Convert.ToDecimal((order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                                        }
                                    }
                                    else
                                    {
                                        if (b * (-1) == 0.25)
                                        {
                                            h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount / 2 : order[j].ValidAmount / 2));
                                        }
                                        else if (b * (-1) > 0.25)
                                        {
                                            h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                                        }
                                    }
                                }
                                /*------让球只有一个的情况即(球半，一球)这种情况----------*/
                                else
                                {
                                    if (b == 0)
                                    {
                                        h.Result = 0;
                                    }
                                    else if (b < 0)
                                    {
                                        h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                                    }
                                    else if (b > 0)
                                    {
                                        h.Result = Convert.ToDecimal((order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                                    }
                                }
                            }
                            else
                            {
                                /*-------选择主队时a与b的值---------*/
                                if (order[j].Betflag == "H")
                                {
                                    a = int.Parse(hls[i].Substring(0, hls[i].IndexOf(':'))) - int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1));
                                    b = a + double.Parse(order[j].Handicap.ToString().Substring(1));
                                }
                                /*-------选择客队时a与b的值--------*/
                                else if (order[j].Betflag == "A")
                                {
                                    a = int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1)) - int.Parse(hls[i].Substring(0, hls[i].IndexOf(':')));
                                    b = a + double.Parse(order[j].Handicap.ToString().Substring(1));
                                }
                                /*-------让球数有两个时即(一球/球半)这种情况--------*/
                                double za = double.Parse(order[j].Handicap) / 0.5;
                                if (int.Parse(za.ToString().Substring(0, (za.ToString().IndexOf('.') == -1 ? za.ToString().Length : za.ToString().IndexOf('.')))) < za)
                                {
                                    if (a < 0)
                                    {
                                        h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                                    }
                                    else if (b > 0)
                                    {
                                        if (b == 0.25)
                                        {
                                            h.Result = Convert.ToDecimal((order[j].Odds > 0 ? order[j].Amount / 2 : order[j].ValidAmount / 2));
                                        }
                                        else if (b > 0.25)
                                        {
                                            h.Result = Convert.ToDecimal((order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                                        }
                                    }
                                    else
                                    {
                                        if (b * (-1) == 0.25)
                                        {
                                            h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount / 2 : order[j].ValidAmount / 2));
                                        }
                                        else if (b * (-1) > 0.25)
                                        {
                                            h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                                        }
                                    }
                                }
                                /*------让球只有一个的情况即(球半，一球)这种情况----------*/
                                else
                                {
                                    if (b == 0)
                                    {
                                        h.Result = 0;
                                    }
                                    else if (b < 0)
                                    {
                                        h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                                    }
                                    else if (b > 0)
                                    {
                                        h.Result = Convert.ToDecimal((order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                                    }
                                }
                            }
                            break;
                        /*---半场让球结束----------*/
                        /*---全场让球----------*/
                        case 0:
                        case 4:
                        case 8:
                            if (order[j].BetType == "4")
                            {
                                OrderdetailhdplManager.DeleteOrderdetailhdplByPK(order[j].ID);
                            }
                            else
                            {
                                OrderdetailhdpManager.DeleteOrderdetailhdpByPK(order[j].ID);
                            }
                            if(order[j].Status == "0")
                            {
                                break;
                            }
                            a = 0;
                            b = 0.0;
                            if (order[j].Handicap.IndexOf("-") != -1)
                            {
                                if (order[j].Betflag == "H")
                                {
                                    a = int.Parse(order[j].Score.Substring(0, order[j].Score.IndexOf(':'))) - int.Parse(order[j].Score.Substring(order[j].Score.IndexOf(':') + 1));
                                    b = a - double.Parse(order[j].Handicap.ToString().Substring(1));
                                }
                                else if (order[j].Betflag == "A")
                                {
                                    a = int.Parse(order[j].Score.Substring(order[j].Score.IndexOf(':') + 1)) - int.Parse(order[j].Score.Substring(0, order[j].Score.IndexOf(':')));
                                    b = a - double.Parse(order[j].Handicap.ToString().Substring(1));
                                }
                                double s = double.Parse(order[j].Handicap.Substring(1))/0.5;
                                if (int.Parse(s.ToString().Substring(0, (s.ToString().IndexOf('.') == -1 ? s.ToString().Length : s.ToString().IndexOf('.')))) < s)
                                {
                                    if (a < 0)
                                    {
                                        h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                                    }
                                    else if (b > 0)
                                    {
                                        if (b == 0.25)
                                        {
                                            h.Result = Convert.ToDecimal(order[j].Amount / 2);
                                        }
                                        else if (b > 0.25)
                                        {
                                            h.Result = Convert.ToDecimal(order[j].Amount);
                                        }
                                    }
                                    else
                                    {
                                        if (b * (-1) == 0.25)
                                        {
                                            h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount / 2 : order[j].ValidAmount / 2));
                                        }
                                        else if (b * (-1) > 0.25)
                                        {
                                            h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                                        }
                                    }
                                }
                                else
                                {
                                    if (b == 0)
                                    {
                                        h.Result = 0;
                                    }
                                    else if (b < 0)
                                    {
                                        h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                                    }
                                    else if (b > 0)
                                    {
                                        h.Result = Convert.ToDecimal((order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                                    }
                                }
                            }
                            else
                            {
                                if (order[j].Betflag == "H")
                                {
                                    a = int.Parse(order[j].Score.Substring(0, order[j].Score.IndexOf(':'))) - int.Parse(order[j].Score.Substring(order[j].Score.IndexOf(':') + 1));
                                    b = a + double.Parse(order[j].Handicap.ToString());
                                }
                                else if (order[j].Betflag == "A")
                                {
                                    a = int.Parse(order[j].Score.Substring(order[j].Score.IndexOf(':') + 1)) - int.Parse(order[j].Score.Substring(0, order[j].Score.IndexOf(':')));
                                    b = a + double.Parse(order[j].Handicap.ToString());
                                }
                                double s = double.Parse(order[j].Handicap)/0.5;
                                if (int.Parse(s.ToString().Substring(0, (s.ToString().IndexOf('.') == -1 ? s.ToString().Length : s.ToString().IndexOf('.')))) < s)
                                {
                                    if (a < 0)
                                    {
                                        h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                                    }
                                    else if (b > 0)
                                    {
                                        if (b == 0.25)
                                        {
                                            h.Result = Convert.ToDecimal(order[j].Amount / 2);
                                        }
                                        else if (b > 0.25)
                                        {
                                            h.Result = Convert.ToDecimal(order[j].Amount);
                                        }
                                    }
                                    else
                                    {
                                        if (b * (-1) == 0.25)
                                        {
                                            h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount / 2 : order[j].ValidAmount / 2));
                                        }
                                        else if (b * (-1) > 0.25)
                                        {
                                            h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                                        }
                                    }
                                }
                                else
                                {
                                    if (b == 0)
                                    {
                                        h.Result = 0;
                                    }
                                    else if (b < 0)
                                    {
                                        h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                                    }
                                    else if (b > 0)
                                    {
                                        h.Result = Convert.ToDecimal((order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                                    }
                                }
                            }
                            break;
                        /*---全场让球结束----------*/
                        /*---半场大小----------*/
                        case 3:
                        case 7:
                        case 11:
                            if (order[j].BetType == "7")
                            {
                                OrderdetailouhflManager.DeleteOrderdetailouhflByPK(order[j].ID);
                            }
                            else
                            {
                                OrderdetailouhfManager.DeleteOrderdetailouhfByPK(order[j].ID);
                            }
                            if(order[j].Status == "0")
                            {
                                break;
                            }
                            a = 0;
                            a = int.Parse(hls[i].Substring(0, hls[i].IndexOf(':'))) + int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1));
                            if (a > double.Parse(order[j].Handicap))
                            {
                                h.Result = (order[j].Betflag == "O" ? (order[j].Amount) : decimal.Parse("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount)));
                            }
                            else if (a < double.Parse(order[j].Handicap))
                            {
                                h.Result = (order[j].Betflag == "U" ? (order[j].Amount) : decimal.Parse("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount)));
                            }
                            else
                            {
                                h.Result = 0;
                            }
                            break;
                        /*---半场大小结束----------*/
                        /*---全场大小----------*/
                        case 1:
                        case 5:
                        case 9:
                            if (order[j].BetType == "5")
                            {
                                OrderdetailoulManager.DeleteOrderdetailoulByPK(order[j].ID);
                            }
                            else
                            {
                                OrderdetailouManager.DeleteOrderdetailouByPK(order[j].ID);
                            }
                            if(order[j].Status == "0")
                            {
                                break;
                            }
                            a = 0;
                            a = int.Parse(order[j].Score.Substring(0, order[j].Score.IndexOf(':'))) + int.Parse(order[j].Score.Substring(order[j].Score.IndexOf(':') + 1));
                            if (a > double.Parse(order[j].Handicap))
                            {
                                h.Result = (order[j].Betflag == "O" ? (order[j].Amount) : decimal.Parse("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount)));
                            }
                            else if (a < double.Parse(order[j].Handicap))
                            {
                                h.Result = (order[j].Betflag == "U" ? (order[j].Amount) : decimal.Parse("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount)));
                            }
                            else
                            {
                                h.Result = 0;
                            }
                            break;
                        /*---全场大小结束----------*/
                        /*---半场标准----------*/
                        case 13:
                        case 15:
                        case 17:
                            if (order[j].BetType == "15")
                            {
                                Orderdetail1x2hflManager.DeleteOrderdetail1x2hflByPK(order[j].ID);
                            }
                            else
                            {
                                Orderdetail1x2hfManager.DeleteOrderdetail1x2hfByPK(order[j].ID);
                            }
                            if(order[j].Status == "0")
                            {
                                break;
                            }
                            a = 0;
                            /*-------选择主队时a与b的值---------*/
                            if (order[j].Betflag == "1")
                            {
                                a = int.Parse(hls[i].Substring(0, hls[i].IndexOf(':'))) - int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1));
                            }
                            /*-------选择客队时a与b的值--------*/
                            else if (order[j].Betflag == "2")
                            {
                                a = int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1)) - int.Parse(hls[i].Substring(0, hls[i].IndexOf(':')));
                            }
                            else
                            {
                                a = int.Parse(hls[i].Substring(0, hls[i].IndexOf(':'))) - int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1));
                            }
                            if (a < 0)
                            {
                                h.Result = decimal.Parse("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            }
                            else if (a > 0)
                            {
                                h.Result = (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount);
                            }
                            else
                            {
                                h.Result = 0;
                            }
                            break;
                        /*---半场标准结束----------*/
                        /*---全场标准----------*/
                        case 12:
                        case 14:
                        case 16:
                            if (order[j].BetType == "14")
                            {
                                Orderdetail1x2lManager.DeleteOrderdetail1x2lByPK(order[j].ID);
                            }
                            else
                            {
                                Orderdetail1x2Manager.DeleteOrderdetail1x2ByPK(order[j].ID);
                            }
                            if(order[j].Status == "0")
                            {
                                break;
                            }
                            a = 0;
                            if (order[j].Betflag == "1")
                            {
                                a = int.Parse(order[j].Score.Substring(0, order[j].Score.IndexOf(':'))) - int.Parse(order[j].Score.Substring(order[j].Score.IndexOf(':') + 1));
                                if (a > 0)
                                {
                                    h.Result = order[j].Amount;
                                }
                                else
                                {
                                    h.Result = decimal.Parse("-" + order[j].Amount);
                                }
                            }
                            else if (order[j].Betflag == "2")
                            {
                                a = int.Parse(order[j].Score.Substring(order[j].Score.IndexOf(':') + 1)) - int.Parse(order[j].Score.Substring(0, order[j].Score.IndexOf(':')));
                                if (a > 0)
                                {
                                    h.Result = order[j].Amount;
                                }
                                else
                                {
                                    h.Result = decimal.Parse("-" + order[j].Amount);
                                }
                            }
                            else
                            {
                                a = int.Parse(order[j].Score.Substring(0, order[j].Score.IndexOf(':'))) - int.Parse(order[j].Score.Substring(order[j].Score.IndexOf(':') + 1));
                                if (a == 0)
                                {
                                    h.Result = order[j].Amount;
                                }
                                else
                                {
                                    h.Result = decimal.Parse("-" + order[j].Amount);
                                }
                            }
                            
                            break;
                        /*---全场标准结束----------*/
                    }
                    h.Odds = order[j].Odds;
                    if (h.Result > 0)
                    {
                        h.Result = h.Result * h.Odds;
                    }
                    h.Agent = order[j].Agent;
                    h.Scorehalf = hls[i];
                    h.AgentCommission = order[j].AgentCommission;
                    h.AgentPercent = order[j].AgentPercent;
                    h.Amount = order[j].Amount;
                    h.Awaycn = order[j].Awaycn;
                    h.Awayen = order[j].Awayen;
                    h.Awayth = order[j].Awayth;
                    h.Awaytw = order[j].Awaytw;
                    h.Awayvn = order[j].Awayvn;
                    h.BeginTime = order[j].BeginTime;
                    h.BetItem = order[j].BetItem;
                    h.BetType = order[j].BetType;
                    h.Coefficient = order[j].Coefficient;
                    h.CompanyCommission = order[j].CompanyCommission;
                    h.CompanyPercent = order[j].CompanyPercent;
                    h.Currency = order[j].Currency;
                    h.Gameid = order[j].Gameid;
                    h.Handicap = order[j].Handicap;
                    h.Homecn = order[j].Homecn;
                    h.Homeen = order[j].Homeen;
                    h.Hometh = order[j].Hometh;
                    h.Hometw = order[j].Hometw;
                    h.Homevn = order[j].Homevn;
                    h.IP = order[j].IP;
                    h.IsHalf = order[j].IsHalf;
                    h.Leaguecn = order[j].Leaguecn;
                    h.Leagueen = order[j].Leagueen;
                    h.Leagueth = order[j].Leagueth;
                    h.Leaguetw = order[j].Leaguetw;
                    h.Leaguevn = order[j].Leaguevn;
                    h.OddsType = order[j].OddsType;
                    h.OrderID = order[j].OrderID;
                    h.Partner = order[j].Partner;
                    h.PartnerCommission = order[j].PartnerCommission;
                    h.PartnerPercent = order[j].PartnerPercent;
                    h.Proportion = order[j].Proportion;
                    h.Reason = order[j].Reason;
                    h.Score = order[j].Score;
                    h.Status = order[j].Status;
                    h.SubCompany = order[j].SubCompany;
                    h.SubCompanyCommission = order[j].SubCompanyCommission;
                    h.SubCompanyPercent = order[j].SubCompanyPercent;
                    h.Time = order[j].Time;
                    h.UserLevel = order[j].UserLevel;
                    h.UserName = order[j].UserName;
                    h.ValidAmount = order[j].ValidAmount;
                    h.WebSiteiID = order[j].WebSiteiID;
                    h.ZAgent = order[j].ZAgent;
                    h.ZAgentCommission = order[j].ZAgentCommission;
                    h.ZAgentPercent = order[j].ZAgentPercent;
                    h.Betflag = order[j].Betflag;
                    if (h.Result > 0)
                    {
                        if (h.Odds < 0)
                        {
                            if (h.Result == h.Amount * h.Odds * -1)
                            {
                                Orderdetail1x2hflManager.setBalance(h.UserName, (h.Result+h.Amount).ToString());
                            }
                            else if (h.Result == h.Amount / 2 * h.Odds * -1)
                            {
                                Orderdetail1x2hflManager.setBalance(h.UserName, (h.Result + h.Amount / 2 + h.Amount - h.ValidAmount).ToString());
                            }
                        }
                        else
                        {
                            if (h.Result == h.Amount * h.Odds)
                            {
                                Orderdetail1x2hflManager.setBalance(h.UserName, (h.Result + h.Amount).ToString());
                            }
                            else if (h.Result == h.Amount / 2 * h.Odds)
                            {
                                Orderdetail1x2hflManager.setBalance(h.UserName, (h.Result + h.Amount / 2).ToString());
                            }
                        }
                    }
                    else
                    {
                        if ((h.Amount + h.Result) != 0 && h.Status != "0")
                        {
                            Orderdetail1x2hflManager.setBalance(h.UserName, (h.Result + h.Amount).ToString());
                        }
                    }
                    OrderhistoryManager.AddOrderhistory(h);
                }

            //    List<Orderdetail1x2> order1 = Orderdetail1x2Manager.getEscAll(int.Parse(gi[i]));
            //    for (int j = 0; j < order1.Count; j++)
            //    {
            //        Orderhistory h = new Orderhistory();
            //        h.Odds = order1[j].Odds;
            //        h.Agent = order1[j].Agent;
            //        h.AgentCommission = order1[j].AgentCommission;
            //        h.AgentPercent = order1[j].AgentPercent;
            //        h.Amount = order1[j].Amount;
            //        h.Awaycn = order1[j].Awaycn;
            //        h.Awayen = order1[j].Awayen;
            //        h.Awayth = order1[j].Awayth;
            //        h.Awaytw = order1[j].Awaytw;
            //        h.Awayvn = order1[j].Awayvn;
            //        h.BeginTime = order1[j].BeginTime;
            //        h.BetItem = order1[j].BetItem;
            //        h.BetType = order1[j].BetType;
            //        h.Coefficient = order1[j].Coefficient;
            //        h.CompanyCommission = order1[j].CompanyCommission;
            //        h.CompanyPercent = order1[j].CompanyPercent;
            //        h.Currency = order1[j].Currency;
            //        h.Gameid = order1[j].Gameid;
            //        h.Handicap = order1[j].Handicap;
            //        h.Homecn = order1[j].Homecn;
            //        h.Homeen = order1[j].Homeen;
            //        h.Hometh = order1[j].Hometh;
            //        h.Hometw = order1[j].Hometw;
            //        h.Homevn = order1[j].Homevn;
            //        h.IP = order1[j].IP;
            //        h.IsHalf = order1[j].IsHalf;
            //        h.Leaguecn = order1[j].Leaguecn;
            //        h.Leagueen = order1[j].Leagueen;
            //        h.Leagueth = order1[j].Leagueth;
            //        h.Leaguetw = order1[j].Leaguetw;
            //        h.Leaguevn = order1[j].Leaguevn;
            //        h.OddsType = order1[j].OddsType;
            //        h.OrderID = order1[j].OrderID;
            //        h.Partner = order1[j].Partner;
            //        h.PartnerCommission = order1[j].PartnerCommission;
            //        h.PartnerPercent = order1[j].PartnerPercent;
            //        h.Proportion = order1[j].Proportion;
            //        h.Reason = order1[j].Reason;
            //        h.Score = order1[j].Score;
            //        h.Status = order1[j].Status;
            //        h.SubCompany = order1[j].SubCompany;
            //        h.SubCompanyCommission = order1[j].SubCompanyCommission;
            //        h.SubCompanyPercent = order1[j].SubCompanyPercent;
            //        h.Time = order1[j].Time;
            //        h.UserLevel = order1[j].UserLevel;
            //        h.UserName = order1[j].UserName;
            //        h.ValidAmount = order1[j].ValidAmount;
            //        h.WebSiteiID = order1[j].WebSiteiID;
            //        h.ZAgent = order1[j].ZAgent;
            //        h.ZAgentCommission = order1[j].ZAgentCommission;
            //        h.ZAgentPercent = order1[j].ZAgentPercent;
            //        h.Betflag = order1[j].Betflag;
            //        OrderhistoryManager.AddOrderhistory(h);
            //    }
            }
            return "true";
        }
        /*-------------结算的方法结束-----------------*/
    }
}
