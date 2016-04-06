using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Model;
using BLL;

namespace admin.ServicesFile.ReleaseSite
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
            match.Time = time.Substring(5, time.Length - 3 - 5);
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
        public string GetAllToJson1(string language)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return MatchesManager.GetAllToJson1(language);
        }

        [WebMethod(EnableSession = true)]
        public string GetAllToJson2(string language,string first,string end)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return MatchesManager.GetAllToJson2(language,first,end);
        }

        [WebMethod(EnableSession = true)]
        public string GetAllToJson3(string language)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return MatchesManager.GetAllToJson3(language);
        }

        [WebMethod(EnableSession = true)]
        public string GetAllToJson4(string language,string time)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return MatchesManager.GetAllToJson4(language,time);
        }

        [WebMethod(EnableSession = true)]
        public string GetLeagueByWhere(string language,string league,string home,string away,string beginTime,string endTime)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return MatchesManager.GetLeagueByWhere(language, league, home, away, beginTime,endTime);
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

        /*---------这是比分录入的方法-------------*/
        [WebMethod(EnableSession = true)]
        public string updatescore(string id,string home,string away,string halfhome,string halfaway)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            PageBase page = new PageBase();
            return MatchesManager.updatescore(id, home, away, halfhome, halfaway,page. CurrentManager.ManagerId).ToString();
        }
        /*---------比分录入的方法结束-------------*/
        
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
            string scoreFull = "";
            string scoreCurr = "";
            decimal handcap = 0;
            string[] score_arr;
            decimal hscore = 0;   //主队比分
            decimal ascore = 0;   //客队比分
            decimal aa = 0;
            decimal scoretotal = 0; //总进球
            string[] scoreCurr_arr;
            decimal hscoreCurr = 0;
            decimal ascoreCurr = 0;

            int a = 0;
            double b = 0;

            //判断比赛是否有未确认注单
            for (int i = 0; i < gi.Length; i++)
            {
                List<Orderdetaillive> orders = OrderdetailliveManager.getorderAll(Convert.ToInt32(gi[i]));
                if (orders.Count > 0)
                {
                    return "err:" + orders[0].Hometw + " vs " + orders[0].Awaytw + " 比赛有走地未确认注单，请到“即时监控-走地未确认注单”确认";
                }
            }

            for (int i = 0; i < gi.Length; i++)
            {
                //会员注单结算
                List<Orderdetail1x2> order = Orderdetail1x2Manager.getorderAll(int.Parse(gi[i]));//获得该场比赛的所有注单
                for (int j = 0; j < order.Count; j++)
                {
                    Orderhistory h = new Orderhistory();
                    scoreCurr = order[j].Score;
                    order[j].Score = s1[i];
                    scoreFull = s1[i];
                    switch (int.Parse(order[j].BetType))
                    {
                        /*-----半场让球--------*/
                        case 2:
                        case 6:
                        case 10:

                            //清除注单
                            if (order[j].BetType == "6")
                            {
                                OrderdetailhdphflManager.DeleteOrderdetailhdphflByPK(order[j].ID);
                            }
                            else
                            {
                                OrderdetailhdphfManager.DeleteOrderdetailhdphfByPK(order[j].ID);
                            }

                            if (order[j].Status == "0")
                            {
                                h.Result = 0;
                                break;
                            }

                            handcap = Convert.ToDecimal(order[j].Handicap);
                            score_arr = hls[i].Split(':');
                            hscore = Convert.ToDecimal(score_arr[0]);   //主队比分
                            ascore = Convert.ToDecimal(score_arr[1]);   //客队比分
                            aa = 0;
                            if (order[j].BetType == "6")
                            {
                                //走地半场让球
                                scoreCurr_arr = scoreCurr.Split(':');
                                hscoreCurr = Convert.ToDecimal(scoreCurr_arr[0]);
                                ascoreCurr = Convert.ToDecimal(scoreCurr_arr[1]);
                                hscore = hscore - hscoreCurr;
                                ascore = ascore - ascoreCurr;
                            }
                            if (order[j].Betflag == "H")
                            {
                                //---投注是主队

                                //让球后的比分
                                hscore += handcap;

                                //计算输赢
                                aa = hscore - ascore;
                            }
                            else if (order[j].Betflag == "A")
                            {
                                //---客队

                                //让球后的比分
                                ascore += handcap;

                                //计算输赢
                                aa = ascore - hscore;
                            }

                            //--计算输赢
                            if (aa > 0)
                            {
                                if (aa == Convert.ToDecimal("0.25"))
                                {
                                    //赢一半
                                    h.Result = (order[j].Odds >= 0 ? order[j].ValidAmount : order[j].Amount) / 2;
                                }
                                else
                                {
                                    //全赢
                                    h.Result = order[j].Odds >= 0 ? order[j].ValidAmount : order[j].Amount;
                                }
                            }
                            else if (aa == 0)
                            {
                                //平
                                h.Result = 0;
                            }
                            else if (aa < 0)
                            {
                                if (aa == Convert.ToDecimal("-0.25"))
                                {
                                    //输一半
                                    h.Result = (order[j].Odds >= 0 ? -order[j].Amount : -order[j].ValidAmount) / 2;
                                }
                                else
                                {
                                    //全输
                                    h.Result = order[j].Odds >= 0 ? -order[j].Amount : -order[j].ValidAmount;
                                }
                            }

                            //-----结束--------



                            //if (order[j].BetType == "6")
                            //{
                            //    OrderdetailhdphflManager.DeleteOrderdetailhdphflByPK(order[j].ID);
                            //}
                            //else
                            //{
                            //    OrderdetailhdphfManager.DeleteOrderdetailhdphfByPK(order[j].ID);
                            //}
                            //if(order[j].Status == "0")
                            //{
                            //    break;
                            //}
                            //int a = 0;
                            //double b = 0;
                            //if (order[j].Handicap.IndexOf("-") != -1)
                            //{
                            //    /*-------选择主队时a与b的值---------*/
                            //    if (order[j].Betflag == "H")
                            //    {
                            //        a = int.Parse(hls[i].Substring(0, hls[i].IndexOf(':'))) - int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1));
                            //        b = a - double.Parse(order[j].Handicap.ToString().Substring(1));
                            //    }
                            //    /*-------选择客队时a与b的值--------*/
                            //    else if (order[j].Betflag == "A")
                            //    {
                            //        a = int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1)) - int.Parse(hls[i].Substring(0, hls[i].IndexOf(':')));
                            //        b = a - double.Parse(order[j].Handicap.ToString().Substring(1));
                            //    }
                            //    /*-------让球数有两个时即(一球/球半)这种情况--------*/
                            //    double za = double.Parse(order[j].Handicap.Substring(1)) / 0.5;
                            //    if (int.Parse(za.ToString().Substring(0, (za.ToString().IndexOf('.') == -1 ? za.ToString().Length : za.ToString().IndexOf('.')))) < za)
                            //    {
                            //        if (a < 0)
                            //        {
                            //            h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //        }
                            //        else if (b > 0)
                            //        {
                            //            if (b == 0.25)
                            //            {
                            //                //h.Result = Convert.ToDecimal((order[j].Odds > 0 ? order[j].Amount / 2 : order[j].ValidAmount / 2));
                            //                h.Result = Convert.ToDecimal(order[j].Amount / 2);
                            //            }
                            //            else if (b > 0.25)
                            //            {
                            //                //h.Result = Convert.ToDecimal((order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //                h.Result = Convert.ToDecimal(order[j].Amount);
                            //            }
                            //        }
                            //        else
                            //        {
                            //            if (b * (-1) == 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount / 2 : order[j].ValidAmount / 2));
                            //                //h.Result = Convert.ToDecimal("-" + order[j].ValidAmount / 2);
                            //            }
                            //            else if (b * (-1) > 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //            }
                            //        }
                            //    }
                            //    /*------让球只有一个的情况即(球半，一球)这种情况----------*/
                            //    else
                            //    {
                            //        if (b == 0)
                            //        {
                            //            h.Result = 0;
                            //        }
                            //        else if (b < 0)
                            //        {
                            //            h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //        }
                            //        else if (b > 0)
                            //        {
                            //            //h.Result = Convert.ToDecimal((order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //            h.Result = Convert.ToDecimal(order[j].Amount);
                            //        }
                            //    }
                            //}
                            //else
                            //{
                            //    /*-------选择主队时a与b的值---------*/
                            //    if (order[j].Betflag == "H")
                            //    {
                            //        a = int.Parse(hls[i].Substring(0, hls[i].IndexOf(':'))) - int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1));
                            //        b = a + double.Parse(order[j].Handicap.ToString().Length > 1 ? order[j].Handicap.ToString().Substring(1) : order[j].Handicap.ToString());
                            //    }
                            //    /*-------选择客队时a与b的值--------*/
                            //    else if (order[j].Betflag == "A")
                            //    {
                            //        a = int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1)) - int.Parse(hls[i].Substring(0, hls[i].IndexOf(':')));
                            //        b = a + double.Parse(order[j].Handicap.ToString().Length > 1 ? order[j].Handicap.ToString().Substring(1) : order[j].Handicap.ToString());
                            //    }
                            //    /*-------让球数有两个时即(一球/球半)这种情况--------*/
                            //    double za = double.Parse(order[j].Handicap) / 0.5;
                            //    if (int.Parse(za.ToString().Substring(0, (za.ToString().IndexOf('.') == -1 ? za.ToString().Length : za.ToString().IndexOf('.')))) < za)
                            //    {
                            //        if (a < 0)
                            //        {
                            //            h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //        }
                            //        else if (b > 0)
                            //        {
                            //            if (b == 0.25)
                            //            {
                            //                //h.Result = Convert.ToDecimal((order[j].Odds > 0 ? order[j].Amount / 2 : order[j].ValidAmount / 2));
                            //                h.Result = Convert.ToDecimal(order[j].Amount / 2);
                            //            }
                            //            else if (b > 0.25)
                            //            {
                            //                //h.Result = Convert.ToDecimal((order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //                h.Result = Convert.ToDecimal(order[j].Amount);
                            //            }
                            //        }
                            //        else
                            //        {
                            //            if (b * (-1) == 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount / 2 : order[j].ValidAmount / 2));
                            //                //h.Result = Convert.ToDecimal("-" + order[j].ValidAmount / 2);
                            //            }
                            //            else if (b * (-1) > 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //            }
                            //        }
                            //    }
                            //    /*------让球只有一个的情况即(球半，一球)这种情况----------*/
                            //    else
                            //    {
                            //        if (b == 0)
                            //        {
                            //            h.Result = 0;
                            //        }
                            //        else if (b < 0)
                            //        {
                            //            h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //        }
                            //        else if (b > 0)
                            //        {
                            //            //h.Result = Convert.ToDecimal((order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //            h.Result = Convert.ToDecimal(order[j].Amount);
                            //        }
                            //    }
                            //}
                            break;
                        /*---半场让球结束----------*/
                        /*---全场让球----------*/
                        case 0:
                        case 4:
                        case 8:

                            //---2011-4-5修改

                            //清除注单
                            if (order[j].BetType == "4")
                            {
                                OrderdetailhdplManager.DeleteOrderdetailhdplByPK(order[j].ID);
                            }
                            else
                            {
                                OrderdetailhdpManager.DeleteOrderdetailhdpByPK(order[j].ID);
                            }


                            if (order[j].Status == "0")
                            {
                                h.Result = 0;
                                break;
                            }

                            handcap = Convert.ToDecimal(order[j].Handicap);
                            score_arr = order[j].Score.Split(':');
                            hscore = Convert.ToDecimal(score_arr[0]);   //主队比分
                            ascore = Convert.ToDecimal(score_arr[1]);   //客队比分
                            aa = 0;
                            if (order[j].BetType == "4")
                            {
                                //走地全场让球
                                scoreCurr_arr = scoreCurr.Split(':');
                                hscoreCurr = Convert.ToDecimal(scoreCurr_arr[0]);
                                ascoreCurr = Convert.ToDecimal(scoreCurr_arr[1]);
                                hscore = hscore - hscoreCurr;
                                ascore = ascore - ascoreCurr;
                            }

                            if (order[j].Betflag == "H")
                            {
                                //---投注是主队

                                //让球后的比分
                                hscore += handcap;

                                //计算输赢
                                aa = hscore - ascore;
                            }
                            else if (order[j].Betflag == "A")
                            {
                                //---客队

                                //让球后的比分
                                ascore += handcap;

                                //计算输赢
                                aa = ascore - hscore;
                            }

                            //--计算输赢
                            if (aa > 0)
                            {
                                if (aa == Convert.ToDecimal("0.25"))
                                {
                                    //赢一半
                                    h.Result = (order[j].Odds >= 0 ? order[j].ValidAmount : order[j].Amount) / 2;
                                }
                                else
                                {
                                    //全赢
                                    h.Result = order[j].Odds >= 0 ? order[j].ValidAmount : order[j].Amount;
                                }
                            }
                            else if (aa == 0)
                            {
                                //平
                                h.Result = 0;
                            }
                            else if (aa < 0)
                            {
                                if (aa == Convert.ToDecimal("-0.25"))
                                {
                                    //输一半
                                    h.Result = (order[j].Odds >= 0 ? -order[j].Amount : -order[j].ValidAmount) / 2;
                                }
                                else
                                {
                                    //全输
                                    h.Result = order[j].Odds >= 0 ? -order[j].Amount : -order[j].ValidAmount;
                                }
                            }

                            //-----结束--------

                            //if (order[j].BetType == "4")
                            //{
                            //    OrderdetailhdplManager.DeleteOrderdetailhdplByPK(order[j].ID);
                            //}
                            //else
                            //{
                            //    OrderdetailhdpManager.DeleteOrderdetailhdpByPK(order[j].ID);
                            //}
                            //if(order[j].Status == "0")
                            //{
                            //    break;
                            //}
                            //a = 0;
                            //b = 0.0;
                            //if (order[j].Handicap.IndexOf("-") != -1)
                            //{
                            //    if (order[j].Betflag == "H")
                            //    {
                            //        a = int.Parse(order[j].Score.Substring(0, order[j].Score.IndexOf(':'))) - int.Parse(order[j].Score.Substring(order[j].Score.IndexOf(':') + 1));
                            //        b = a - double.Parse(order[j].Handicap.ToString().Length > 1 ? order[j].Handicap.ToString().Substring(1) : order[j].Handicap.ToString());
                            //    }
                            //    else if (order[j].Betflag == "A")
                            //    {
                            //        a = int.Parse(order[j].Score.Substring(order[j].Score.IndexOf(':') + 1)) - int.Parse(order[j].Score.Substring(0, order[j].Score.IndexOf(':')));
                            //        b = a - double.Parse(order[j].Handicap.ToString().Length > 1 ? order[j].Handicap.ToString().Substring(1) : order[j].Handicap.ToString());
                            //    }
                            //    double s = double.Parse(order[j].Handicap.Substring(1))/0.5;
                            //    if (int.Parse(s.ToString().Substring(0, (s.ToString().IndexOf('.') == -1 ? s.ToString().Length : s.ToString().IndexOf('.')))) < s)
                            //    {
                            //        //if (a < 0)
                            //        //{
                            //        //    h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //        //}
                            //        //else 
                            //        if (b > 0)
                            //        {
                            //            if (b == 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal(order[j].Amount / 2);
                            //            }
                            //            else if (b > 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal(order[j].Amount);
                            //            }
                            //        }
                            //        else
                            //        {
                            //            if (b * (-1) == 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount / 2 : order[j].ValidAmount / 2));
                            //            }
                            //            else if (b * (-1) > 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //            }
                            //        }
                            //    }
                            //    else
                            //    {
                            //        if (b == 0)
                            //        {
                            //            h.Result = 0;
                            //        }
                            //        else if (b < 0)
                            //        {
                            //            h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //        }
                            //        else if (b > 0)
                            //        {
                            //            //h.Result = Convert.ToDecimal((order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //            h.Result = Convert.ToDecimal(order[j].Amount);
                            //        }
                            //    }
                            //}
                            //else
                            //{
                            //    if (order[j].Betflag == "H")
                            //    {
                            //        a = int.Parse(order[j].Score.Substring(0, order[j].Score.IndexOf(':'))) - int.Parse(order[j].Score.Substring(order[j].Score.IndexOf(':') + 1));
                            //        b = a + double.Parse(order[j].Handicap.ToString().Length > 1 ? order[j].Handicap.ToString().Substring(1) : order[j].Handicap.ToString());
                            //    }
                            //    else if (order[j].Betflag == "A")
                            //    {
                            //        a = int.Parse(order[j].Score.Substring(order[j].Score.IndexOf(':') + 1)) - int.Parse(order[j].Score.Substring(0, order[j].Score.IndexOf(':')));
                            //        b = a + double.Parse(order[j].Handicap.ToString().Length > 1 ? order[j].Handicap.ToString().Substring(1) : order[j].Handicap.ToString());
                            //    }
                            //    double s = double.Parse(order[j].Handicap)/0.5;
                            //    if (int.Parse(s.ToString().Substring(0, (s.ToString().IndexOf('.') == -1 ? s.ToString().Length : s.ToString().IndexOf('.')))) < s)
                            //    {
                            //        //if (a < 0)
                            //        //{
                            //        //    h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //        //}
                            //        //else 
                            //        if (b > 0)
                            //        {
                            //            if (b == 0.25)
                            //            {
                            //                if (order[j].Handicap == "0.25")
                            //                {
                            //                    h.Result = Convert.ToDecimal(order[j].Amount / 2);
                            //                }
                            //                else
                            //                {
                            //                    h.Result = Convert.ToDecimal(order[j].Amount);
                            //                }
                            //            }
                            //            else if (b > 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal(order[j].Amount);
                            //            }
                            //        }
                            //        else
                            //        {
                            //            if (b * (-1) == 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount / 2 : order[j].ValidAmount / 2));
                            //            }
                            //            else if (b * (-1) > 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //            }
                            //        }
                            //    }
                            //    else
                            //    {
                            //        if (b == 0)
                            //        {
                            //            h.Result = 0;
                            //        }
                            //        else if (b < 0)
                            //        {
                            //            h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //        }
                            //        else if (b > 0)
                            //        {
                            //            //h.Result = Convert.ToDecimal((order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //            h.Result = Convert.ToDecimal(order[j].Amount);
                            //        }
                            //    }
                            //}
                            break;
                        /*---全场让球结束----------*/
                        /*---半场大小----------*/
                        case 3:
                        case 7:
                        case 11:

                            //清除注单
                            if (order[j].BetType == "7")
                            {
                                OrderdetailouhflManager.DeleteOrderdetailouhflByPK(order[j].ID);
                            }
                            else
                            {
                                OrderdetailouhfManager.DeleteOrderdetailouhfByPK(order[j].ID);
                            }

                            if (order[j].Status == "0")
                            {
                                h.Result = 0;
                                break;
                            }

                            handcap = Convert.ToDecimal(order[j].Handicap);
                            score_arr = hls[i].Split(':');
                            hscore = Convert.ToDecimal(score_arr[0]);   //主队比分
                            ascore = Convert.ToDecimal(score_arr[1]);   //客队比分
                            scoretotal = hscore + ascore;
                            aa = 0;
                            if (order[j].Betflag == "O")
                            {
                                //---投注是大

                                //计算输赢
                                aa = scoretotal - handcap;
                            }
                            else if (order[j].Betflag == "U")
                            {
                                //---小

                                //计算输赢
                                aa = handcap - scoretotal;
                            }

                            //--计算输赢
                            if (aa > 0)
                            {
                                if (aa == Convert.ToDecimal("0.25"))
                                {
                                    //赢一半
                                    h.Result = (order[j].Odds >= 0 ? order[j].ValidAmount : order[j].Amount) / 2;
                                }
                                else
                                {
                                    //全赢
                                    h.Result = order[j].Odds >= 0 ? order[j].ValidAmount : order[j].Amount;
                                }
                            }
                            else if (aa == 0)
                            {
                                //平
                                h.Result = 0;
                            }
                            else if (aa < 0)
                            {
                                if (aa == Convert.ToDecimal("-0.25"))
                                {
                                    //输一半
                                    h.Result = (order[j].Odds >= 0 ? -order[j].Amount : -order[j].ValidAmount) / 2;
                                }
                                else
                                {
                                    //全输
                                    h.Result = order[j].Odds >= 0 ? -order[j].Amount : -order[j].ValidAmount;
                                }
                            }


                            //if (order[j].BetType == "7")
                            //{
                            //    OrderdetailouhflManager.DeleteOrderdetailouhflByPK(order[j].ID);
                            //}
                            //else
                            //{
                            //    OrderdetailouhfManager.DeleteOrderdetailouhfByPK(order[j].ID);
                            //}
                            //if(order[j].Status == "0")
                            //{
                            //    break;
                            //}
                            //a = 0;
                            //a = int.Parse(hls[i].Substring(0, hls[i].IndexOf(':'))) + int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1));
                            //double s2 = double.Parse(order[j].Handicap) / 0.5;
                            //int ss2 = int.Parse(s2.ToString().IndexOf('.') != -1 ? s2.ToString().Substring(0, s2.ToString().IndexOf('.')) : s2.ToString());
                            //if (s2 == ss2)
                            //{
                            //    if (a > double.Parse(order[j].Handicap))
                            //    {
                            //        h.Result = (order[j].Betflag == "O" ? (order[j].Amount) : decimal.Parse("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount)));
                            //    }
                            //    else if (a < double.Parse(order[j].Handicap))
                            //    {
                            //        h.Result = (order[j].Betflag == "U" ? (order[j].Amount) : decimal.Parse("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount)));
                            //    }
                            //    else
                            //    {
                            //        h.Result = 0;
                            //    }
                            //}
                            //else
                            //{
                            //    if (order[j].Betflag == "O")
                            //    {
                            //        if (a > double.Parse(order[j].Handicap) + 0.25)
                            //        {
                            //            h.Result = order[j].Amount;
                            //        }
                            //        else if (a < double.Parse(order[j].Handicap) - 0.25)
                            //        {
                            //            h.Result = (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount);
                            //        }
                            //        else
                            //        {
                            //            if (a == double.Parse(order[j].Handicap) - 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount / 2 : order[j].ValidAmount / 2));
                            //            }
                            //            else if (a == double.Parse(order[j].Handicap) + 0.25)
                            //            {
                            //                h.Result = order[j].Amount / 2;
                            //            }
                            //        }
                            //    }
                            //    else
                            //    {
                            //        if (a < double.Parse(order[j].Handicap) - 0.25)
                            //        {
                            //            h.Result = order[j].Amount;
                            //        }
                            //        else if (a > double.Parse(order[j].Handicap) + 0.25)
                            //        {
                            //            h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //        }
                            //        else
                            //        {
                            //            if (a == double.Parse(order[j].Handicap) + 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount / 2 : order[j].ValidAmount / 2));
                            //            }
                            //            else if (a == double.Parse(order[j].Handicap) - 0.25)
                            //            {
                            //                h.Result = order[j].Amount / 2;
                            //            }
                            //        }
                            //    }
                            //}
                            break;
                        /*---半场大小结束----------*/
                        /*---全场大小----------*/
                        case 1:
                        case 5:
                        case 9:

                            //清除注单
                            if (order[j].BetType == "5")
                            {
                                OrderdetailoulManager.DeleteOrderdetailoulByPK(order[j].ID);
                            }
                            else
                            {
                                OrderdetailouManager.DeleteOrderdetailouByPK(order[j].ID);
                            }

                            if (order[j].Status == "0")
                            {
                                h.Result = 0;
                                break;
                            }

                            handcap = Convert.ToDecimal(order[j].Handicap);
                            score_arr = order[j].Score.Split(':');
                            hscore = Convert.ToDecimal(score_arr[0]);   //主队比分
                            ascore = Convert.ToDecimal(score_arr[1]);   //客队比分
                            scoretotal = hscore + ascore;
                            aa = 0;
                            if (order[j].Betflag == "O")
                            {
                                //---投注是大

                                //计算输赢
                                aa = scoretotal - handcap;
                            }
                            else if (order[j].Betflag == "U")
                            {
                                //---小

                                //计算输赢
                                aa = handcap - scoretotal;
                            }

                            //--计算输赢
                            if (aa > 0)
                            {
                                if (aa == Convert.ToDecimal("0.25"))
                                {
                                    //赢一半
                                    h.Result = (order[j].Odds >= 0 ? order[j].ValidAmount : order[j].Amount) / 2;
                                }
                                else
                                {
                                    //全赢
                                    h.Result = order[j].Odds >= 0 ? order[j].ValidAmount : order[j].Amount;
                                }
                            }
                            else if (aa == 0)
                            {
                                //平
                                h.Result = 0;
                            }
                            else if (aa < 0)
                            {
                                if (aa == Convert.ToDecimal("-0.25"))
                                {
                                    //输一半
                                    h.Result = (order[j].Odds >= 0 ? -order[j].Amount : -order[j].ValidAmount) / 2;
                                }
                                else
                                {
                                    //全输
                                    h.Result = order[j].Odds >= 0 ? -order[j].Amount : -order[j].ValidAmount;
                                }
                            }


                            //if (order[j].BetType == "5")
                            //{
                            //    OrderdetailoulManager.DeleteOrderdetailoulByPK(order[j].ID);
                            //}
                            //else
                            //{
                            //    OrderdetailouManager.DeleteOrderdetailouByPK(order[j].ID);
                            //}
                            //if(order[j].Status == "0")
                            //{
                            //    break;
                            //}
                            //a = 0;
                            //a = int.Parse(order[j].Score.Substring(0, order[j].Score.IndexOf(':'))) + int.Parse(order[j].Score.Substring(order[j].Score.IndexOf(':') + 1));
                            ////a = int.Parse(hls[i].Substring(0, hls[i].IndexOf(':'))) + int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1));
                            //double s3 = double.Parse(order[j].Handicap) / 0.5;
                            //int ss3 = int.Parse(s3.ToString().IndexOf('.') != -1 ? s3.ToString().Substring(0, s3.ToString().IndexOf('.')) : s3.ToString());
                            //if (s3 == ss3)
                            //{
                            //    if (a > double.Parse(order[j].Handicap))
                            //    {
                            //        h.Result = (order[j].Betflag == "O" ? (order[j].Amount) : decimal.Parse("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount)));
                            //    }
                            //    else if (a < double.Parse(order[j].Handicap))
                            //    {
                            //        h.Result = (order[j].Betflag == "U" ? (order[j].Amount) : decimal.Parse("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount)));
                            //    }
                            //    else
                            //    {
                            //        h.Result = 0;
                            //    }
                            //}
                            //else
                            //{
                            //    if (order[j].Betflag == "O")
                            //    {
                            //        if (a > double.Parse(order[j].Handicap) + 0.25)
                            //        {
                            //            h.Result = order[j].Amount;
                            //        }
                            //        else if (a < double.Parse(order[j].Handicap) - 0.25)
                            //        {
                            //            h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //        }
                            //        else
                            //        {
                            //            if (a == double.Parse(order[j].Handicap) - 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount / 2 : order[j].ValidAmount / 2));
                            //            }
                            //            else if (a == double.Parse(order[j].Handicap) + 0.25)
                            //            {
                            //                h.Result = order[j].Amount / 2;
                            //            }
                            //        }
                            //    }
                            //    else
                            //    {
                            //        if (a < double.Parse(order[j].Handicap) - 0.25)
                            //        {
                            //            h.Result = order[j].Amount;
                            //        }
                            //        else if (a > double.Parse(order[j].Handicap) + 0.25)
                            //        {
                            //            h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //        }
                            //        else
                            //        {
                            //            if (a == double.Parse(order[j].Handicap) + 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order[j].Odds > 0 ? order[j].Amount / 2 : order[j].ValidAmount / 2));
                            //            }
                            //            else if (a == double.Parse(order[j].Handicap) - 0.25)
                            //            {
                            //                h.Result = order[j].Amount / 2;
                            //            }
                            //        }
                            //    }
                            //}
                            break;
                        /*---全场大小结束----------*/
                        /*---半场标准----------*/
                        case 13:
                        case 15:
                        case 17:
                            //if (order[j].BetType == "15")
                            //{
                            //    Orderdetail1x2hflManager.DeleteOrderdetail1x2hflByPK(order[j].ID);
                            //}
                            //else
                            //{
                            //    Orderdetail1x2hfManager.DeleteOrderdetail1x2hfByPK(order[j].ID);
                            //}
                            //if(order[j].Status == "0")
                            //{
                            //    break;
                            //}
                            //a = 0;
                            ///*-------选择主队时a与b的值---------*/
                            //if (order[j].Betflag == "1")
                            //{
                            //    a = int.Parse(hls[i].Substring(0, hls[i].IndexOf(':'))) - int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1));
                            //}
                            ///*-------选择客队时a与b的值--------*/
                            //else if (order[j].Betflag == "2")
                            //{
                            //    a = int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1)) - int.Parse(hls[i].Substring(0, hls[i].IndexOf(':')));
                            //}
                            //else
                            //{
                            //    a = int.Parse(hls[i].Substring(0, hls[i].IndexOf(':'))) - int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1));
                            //}
                            //if (a < 0)
                            //{
                            //    h.Result = decimal.Parse("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //}
                            //else if (a > 0)
                            //{
                            //    h.Result = (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount);
                            //}
                            //else
                            //{
                            //    h.Result = 0;
                            //}
                            
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
                                h.Result = 0;
                                break;
                            }
                            a = 0;
                            if (order[j].Betflag == "1")
                            {
                                a = int.Parse(hls[i].Substring(0, hls[i].IndexOf(':'))) - int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1));
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
                                a = int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1)) - int.Parse(hls[i].Substring(0, hls[i].IndexOf(':')));
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
                                a = int.Parse(hls[i].Substring(0, hls[i].IndexOf(':'))) - int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1));
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
                                h.Result = 0;
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
                        if (order[j].BetType == "12" || order[j].BetType == "13" || order[j].BetType == "14" || order[j].BetType == "15" || order[j].BetType == "16" || order[j].BetType == "17")
                        {
                            h.Result = h.Result * (h.Odds < 0 ? 1 : (h.Odds-1));
                        }
                        else
                        {
                            h.Result = h.Result * (h.Odds < 0 ? 1 : h.Odds);
                        }
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
                    h.Scoreathalf = scoreCurr;
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
                    h.MemberPercent = order[j].MemberPercent;
                    h.MemberCommission = order[j].MemberCommission;
                    h.Rate = order[j].Rate;

                    //更新会员余额

                    //2011-3-30更改
                    if (order[j].Status != "0")
                    {
                        decimal yxAmount;
                        decimal comm;
                        if (h.Result == 0)
                        {
                            yxAmount = 0;
                        }
                        else if (Math.Abs(h.ValidAmount / h.Result) == 2 || Math.Abs(h.Amount / h.Result) == 2 || Math.Abs((h.Amount * h.Odds) / h.Result) == 2)
                        {
                            yxAmount = h.Amount / 2;
                        }
                        else
                        {
                            yxAmount = h.Amount;
                        }
                        comm = yxAmount * h.MemberCommission;

                        Orderdetail1x2hflManager.setBalance(h.UserName, (h.ValidAmount + h.Result + comm).ToString());
                    }

                    //if (h.Result > 0)
                    //{
                    //    if (h.Odds < 0)
                    //    {
                    //        if (h.Result == h.Amount * h.Odds * -1)
                    //        {
                    //            Orderdetail1x2hflManager.setBalance(h.UserName, (h.Result+h.Amount).ToString());
                    //        }
                    //        else if (h.Result == h.Amount / 2 * h.Odds * -1)
                    //        {
                    //            Orderdetail1x2hflManager.setBalance(h.UserName, (h.Result + h.Amount / 2 + h.Amount - h.ValidAmount).ToString());
                    //        }
                    //    }
                    //    else
                    //    {
                    //        if (h.Result == h.Amount * h.Odds)
                    //        {
                    //            Orderdetail1x2hflManager.setBalance(h.UserName, (h.Result + h.Amount).ToString());
                    //        }
                    //        else if (h.Result == h.Amount / 2 * h.Odds)
                    //        {
                    //            Orderdetail1x2hflManager.setBalance(h.UserName, (h.Result + h.Amount / 2).ToString());
                    //        }
                    //        else
                    //        {
                    //            Orderdetail1x2hflManager.setBalance(h.UserName, (h.Result + h.Amount).ToString());
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    if ((h.Amount + h.Result) != 0 && h.Status != "0")
                    //    {
                    //        Orderdetail1x2hflManager.setBalance(h.UserName, (h.Result + h.Amount).ToString());
                    //    }
                    //}

                    OrderhistoryManager.AddOrderhistory(h);
                }

                //外调注单结算
                OrderotherManager om = new OrderotherManager();
                IList<Orderother> order1 = om.GetOrderByGameId(int.Parse(gi[i]));
                for (int j = 0; j < order1.Count; j++)
                {
                    Orderotherhistory h = new Orderotherhistory();
                    scoreCurr = order1[j].Score;
                    order1[j].Score = s1[i];
                    scoreFull = s1[i];

                    switch (int.Parse(order1[j].BetType))
                    {
                        /*-----半场让球--------*/
                        case 2:
                        case 6:
                        case 10:

                            if (order1[j].Status == "0")
                            {
                                break;
                            }

                            handcap = Convert.ToDecimal(order1[j].Handicap);
                            score_arr = hls[i].Split(':');
                            hscore = Convert.ToDecimal(score_arr[0]);   //主队比分
                            ascore = Convert.ToDecimal(score_arr[1]);   //客队比分
                            aa = 0;
                            if (order1[j].BetType == "6")
                            {
                                //走地半场让球
                                scoreCurr_arr = scoreCurr.Split(':');
                                hscoreCurr = Convert.ToDecimal(scoreCurr_arr[0]);
                                ascoreCurr = Convert.ToDecimal(scoreCurr_arr[1]);
                                hscore = hscore - hscoreCurr;
                                ascore = ascore - ascoreCurr;
                            }

                            if (order1[j].Betflag == "H")
                            {
                                //---投注是主队

                                //让球后的比分
                                hscore += handcap;

                                //计算输赢
                                aa = hscore - ascore;
                            }
                            else if (order1[j].Betflag == "A")
                            {
                                //---客队

                                //让球后的比分
                                ascore += handcap;

                                //计算输赢
                                aa = ascore - hscore;
                            }

                            //--计算输赢
                            if (aa > 0)
                            {
                                if (aa == Convert.ToDecimal("0.25"))
                                {
                                    //赢一半
                                    h.Result = (order1[j].Odds >= 0 ? order1[j].ValidAmount : order1[j].Amount) / 2;
                                }
                                else
                                {
                                    //全赢
                                    h.Result = order1[j].Odds >= 0 ? order1[j].ValidAmount : order1[j].Amount;
                                }
                            }
                            else if (aa == 0)
                            {
                                //平
                                h.Result = 0;
                            }
                            else if (aa < 0)
                            {
                                if (aa == Convert.ToDecimal("-0.25"))
                                {
                                    //输一半
                                    h.Result = (order1[j].Odds >= 0 ? -order1[j].Amount : -order1[j].ValidAmount) / 2;
                                }
                                else
                                {
                                    //全输
                                    h.Result = order1[j].Odds >= 0 ? -order1[j].Amount : -order1[j].ValidAmount;
                                }
                            }

                            //-----结束--------



                            //if (order1[j].Status == "0")
                            //{
                            //    break;
                            //}
                            //int a = 0;
                            //double b = 0;
                            //if (order1[j].Handicap.IndexOf("-") != -1)
                            //{
                            //    /*-------选择主队时a与b的值---------*/
                            //    if (order1[j].Betflag == "H")
                            //    {
                            //        a = int.Parse(hls[i].Substring(0, hls[i].IndexOf(':'))) - int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1));
                            //        b = a - double.Parse(order1[j].Handicap.ToString().Substring(1));
                            //    }
                            //    /*-------选择客队时a与b的值--------*/
                            //    else if (order1[j].Betflag == "A")
                            //    {
                            //        a = int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1)) - int.Parse(hls[i].Substring(0, hls[i].IndexOf(':')));
                            //        b = a - double.Parse(order1[j].Handicap.ToString().Substring(1));
                            //    }
                            //    /*-------让球数有两个时即(一球/球半)这种情况--------*/
                            //    double za = double.Parse(order1[j].Handicap.Substring(1)) / 0.5;
                            //    if (int.Parse(za.ToString().Substring(0, (za.ToString().IndexOf('.') == -1 ? za.ToString().Length : za.ToString().IndexOf('.')))) < za)
                            //    {
                            //        if (a < 0)
                            //        {
                            //            h.Result = Convert.ToDecimal("-" + (order1[j].Odds > 0 ? order1[j].Amount : order1[j].ValidAmount));
                            //        }
                            //        else if (b > 0)
                            //        {
                            //            if (b == 0.25)
                            //            {
                            //                //h.Result = Convert.ToDecimal((order[j].Odds > 0 ? order[j].Amount / 2 : order[j].ValidAmount / 2));
                            //                h.Result = Convert.ToDecimal(order1[j].Amount / 2);
                            //            }
                            //            else if (b > 0.25)
                            //            {
                            //                //h.Result = Convert.ToDecimal((order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //                h.Result = Convert.ToDecimal(order1[j].Amount);
                            //            }
                            //        }
                            //        else
                            //        {
                            //            if (b * (-1) == 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order1[j].Odds > 0 ? order1[j].Amount / 2 : order1[j].ValidAmount / 2));
                            //                //h.Result = Convert.ToDecimal("-" + order[j].ValidAmount / 2);
                            //            }
                            //            else if (b * (-1) > 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order1[j].Odds > 0 ? order1[j].Amount : order1[j].ValidAmount));
                            //            }
                            //        }
                            //    }
                            //    /*------让球只有一个的情况即(球半，一球)这种情况----------*/
                            //    else
                            //    {
                            //        if (b == 0)
                            //        {
                            //            h.Result = 0;
                            //        }
                            //        else if (b < 0)
                            //        {
                            //            h.Result = Convert.ToDecimal("-" + (order1[j].Odds > 0 ? order1[j].Amount : order1[j].ValidAmount));
                            //        }
                            //        else if (b > 0)
                            //        {
                            //            //h.Result = Convert.ToDecimal((order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //            h.Result = Convert.ToDecimal(order1[j].Amount);
                            //        }
                            //    }
                            //}
                            //else
                            //{
                            //    /*-------选择主队时a与b的值---------*/
                            //    if (order1[j].Betflag == "H")
                            //    {
                            //        a = int.Parse(hls[i].Substring(0, hls[i].IndexOf(':'))) - int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1));
                            //        b = a + double.Parse(order1[j].Handicap.ToString().Length > 1 ? order1[j].Handicap.ToString().Substring(1) : order1[j].Handicap.ToString());
                            //    }
                            //    /*-------选择客队时a与b的值--------*/
                            //    else if (order1[j].Betflag == "A")
                            //    {
                            //        a = int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1)) - int.Parse(hls[i].Substring(0, hls[i].IndexOf(':')));
                            //        b = a + double.Parse(order1[j].Handicap.ToString().Length > 1 ? order1[j].Handicap.ToString().Substring(1) : order1[j].Handicap.ToString());
                            //    }
                            //    /*-------让球数有两个时即(一球/球半)这种情况--------*/
                            //    double za = double.Parse(order1[j].Handicap) / 0.5;
                            //    if (int.Parse(za.ToString().Substring(0, (za.ToString().IndexOf('.') == -1 ? za.ToString().Length : za.ToString().IndexOf('.')))) < za)
                            //    {
                            //        if (a < 0)
                            //        {
                            //            h.Result = Convert.ToDecimal("-" + (order1[j].Odds > 0 ? order1[j].Amount : order1[j].ValidAmount));
                            //        }
                            //        else if (b > 0)
                            //        {
                            //            if (b == 0.25)
                            //            {
                            //                //h.Result = Convert.ToDecimal((order[j].Odds > 0 ? order[j].Amount / 2 : order[j].ValidAmount / 2));
                            //                h.Result = Convert.ToDecimal(order1[j].Amount / 2);
                            //            }
                            //            else if (b > 0.25)
                            //            {
                            //                //h.Result = Convert.ToDecimal((order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //                h.Result = Convert.ToDecimal(order1[j].Amount);
                            //            }
                            //        }
                            //        else
                            //        {
                            //            if (b * (-1) == 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order1[j].Odds > 0 ? order1[j].Amount / 2 : order1[j].ValidAmount / 2));
                            //                //h.Result = Convert.ToDecimal("-" + order[j].ValidAmount / 2);
                            //            }
                            //            else if (b * (-1) > 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order1[j].Odds > 0 ? order1[j].Amount : order1[j].ValidAmount));
                            //            }
                            //        }
                            //    }
                            //    /*------让球只有一个的情况即(球半，一球)这种情况----------*/
                            //    else
                            //    {
                            //        if (b == 0)
                            //        {
                            //            h.Result = 0;
                            //        }
                            //        else if (b < 0)
                            //        {
                            //            h.Result = Convert.ToDecimal("-" + (order1[j].Odds > 0 ? order1[j].Amount : order1[j].ValidAmount));
                            //        }
                            //        else if (b > 0)
                            //        {
                            //            //h.Result = Convert.ToDecimal((order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //            h.Result = Convert.ToDecimal(order1[j].Amount);
                            //        }
                            //    }
                            //}
                            break;
                        /*---半场让球结束----------*/
                        /*---全场让球----------*/
                        case 0:
                        case 4:
                        case 8:

                            if (order1[j].Status == "0")
                            {
                                break;
                            }

                            handcap = Convert.ToDecimal(order1[j].Handicap);
                            score_arr = order1[j].Score.Split(':');
                            hscore = Convert.ToDecimal(score_arr[0]);   //主队比分
                            ascore = Convert.ToDecimal(score_arr[1]);   //客队比分
                            aa = 0;
                            if (order1[j].BetType == "4")
                            {
                                //走地全场让球
                                scoreCurr_arr = scoreCurr.Split(':');
                                hscoreCurr = Convert.ToDecimal(scoreCurr_arr[0]);
                                ascoreCurr = Convert.ToDecimal(scoreCurr_arr[1]);
                                hscore = hscore - hscoreCurr;
                                ascore = ascore - ascoreCurr;
                            }

                            if (order1[j].Betflag == "H")
                            {
                                //---投注是主队

                                //让球后的比分
                                hscore += handcap;

                                //计算输赢
                                aa = hscore - ascore;
                            }
                            else if (order1[j].Betflag == "A")
                            {
                                //---客队

                                //让球后的比分
                                ascore += handcap;

                                //计算输赢
                                aa = ascore - hscore;
                            }

                            //--计算输赢
                            if (aa > 0)
                            {
                                if (aa == Convert.ToDecimal("0.25"))
                                {
                                    //赢一半
                                    h.Result = (order1[j].Odds >= 0 ? order1[j].ValidAmount : order1[j].Amount) / 2;
                                }
                                else
                                {
                                    //全赢
                                    h.Result = order1[j].Odds >= 0 ? order1[j].ValidAmount : order1[j].Amount;
                                }
                            }
                            else if (aa == 0)
                            {
                                //平
                                h.Result = 0;
                            }
                            else if (aa < 0)
                            {
                                if (aa == Convert.ToDecimal("-0.25"))
                                {
                                    //输一半
                                    h.Result = (order1[j].Odds >= 0 ? -order1[j].Amount : -order1[j].ValidAmount) / 2;
                                }
                                else
                                {
                                    //全输
                                    h.Result = order1[j].Odds >= 0 ? -order1[j].Amount : -order1[j].ValidAmount;
                                }
                            }

                            //-----结束--------


                            //if (order1[j].Status == "0")
                            //{
                            //    break;
                            //}
                            //a = 0;
                            //b = 0.0;
                            //if (order1[j].Handicap.IndexOf("-") != -1)
                            //{
                            //    if (order1[j].Betflag == "H")
                            //    {
                            //        a = int.Parse(order1[j].Score.Substring(0, order1[j].Score.IndexOf(':'))) - int.Parse(order1[j].Score.Substring(order1[j].Score.IndexOf(':') + 1));
                            //        b = a - double.Parse(order1[j].Handicap.ToString().Length > 1 ? order1[j].Handicap.ToString().Substring(1) : order1[j].Handicap.ToString());
                            //    }
                            //    else if (order1[j].Betflag == "A")
                            //    {
                            //        a = int.Parse(order1[j].Score.Substring(order1[j].Score.IndexOf(':') + 1)) - int.Parse(order1[j].Score.Substring(0, order1[j].Score.IndexOf(':')));
                            //        b = a - double.Parse(order1[j].Handicap.ToString().Length > 1 ? order1[j].Handicap.ToString().Substring(1) : order1[j].Handicap.ToString());
                            //    }
                            //    double s = double.Parse(order1[j].Handicap.Substring(1)) / 0.5;
                            //    if (int.Parse(s.ToString().Substring(0, (s.ToString().IndexOf('.') == -1 ? s.ToString().Length : s.ToString().IndexOf('.')))) < s)
                            //    {
                            //        //if (a < 0)
                            //        //{
                            //        //    h.Result = Convert.ToDecimal("-" + (order1[j].Odds > 0 ? order1[j].Amount : order1[j].ValidAmount));
                            //        //}
                            //        //else 
                            //        if (b > 0)
                            //        {
                            //            if (b == 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal(order1[j].Amount / 2);
                            //            }
                            //            else if (b > 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal(order1[j].Amount);
                            //            }
                            //        }
                            //        else
                            //        {
                            //            if (b * (-1) == 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order1[j].Odds > 0 ? order1[j].Amount / 2 : order1[j].ValidAmount / 2));
                            //            }
                            //            else if (b * (-1) > 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order1[j].Odds > 0 ? order1[j].Amount : order1[j].ValidAmount));
                            //            }
                            //        }
                            //    }
                            //    else
                            //    {
                            //        if (b == 0)
                            //        {
                            //            h.Result = 0;
                            //        }
                            //        else if (b < 0)
                            //        {
                            //            h.Result = Convert.ToDecimal("-" + (order1[j].Odds > 0 ? order1[j].Amount : order1[j].ValidAmount));
                            //        }
                            //        else if (b > 0)
                            //        {
                            //            //h.Result = Convert.ToDecimal((order1[j].Odds > 0 ? order1[j].Amount : order1[j].ValidAmount));
                            //            h.Result = Convert.ToDecimal(order1[j].Amount);
                            //        }
                            //    }
                            //}
                            //else
                            //{
                            //    if (order1[j].Betflag == "H")
                            //    {
                            //        a = int.Parse(order1[j].Score.Substring(0, order1[j].Score.IndexOf(':'))) - int.Parse(order1[j].Score.Substring(order1[j].Score.IndexOf(':') + 1));
                            //        b = a + double.Parse(order1[j].Handicap.ToString().Length > 1 ? order1[j].Handicap.ToString().Substring(1) : order1[j].Handicap.ToString());
                            //    }
                            //    else if (order1[j].Betflag == "A")
                            //    {
                            //        a = int.Parse(order1[j].Score.Substring(order1[j].Score.IndexOf(':') + 1)) - int.Parse(order1[j].Score.Substring(0, order1[j].Score.IndexOf(':')));
                            //        b = a + double.Parse(order1[j].Handicap.ToString().Length > 1 ? order1[j].Handicap.ToString().Substring(1) : order1[j].Handicap.ToString());
                            //    }
                            //    double s = double.Parse(order1[j].Handicap) / 0.5;
                            //    if (int.Parse(s.ToString().Substring(0, (s.ToString().IndexOf('.') == -1 ? s.ToString().Length : s.ToString().IndexOf('.')))) < s)
                            //    {
                            //        //if (a < 0)
                            //        //{
                            //        //    h.Result = Convert.ToDecimal("-" + (order1[j].Odds > 0 ? order1[j].Amount : order1[j].ValidAmount));
                            //        //}
                            //        //else 
                            //        if (b > 0)
                            //        {
                            //            if (b == 0.25)
                            //            {
                            //                if (order1[j].Handicap == "0.25")
                            //                {
                            //                    h.Result = Convert.ToDecimal(order1[j].Amount / 2);
                            //                }
                            //                else
                            //                {
                            //                    h.Result = Convert.ToDecimal(order1[j].Amount);
                            //                }
                            //            }
                            //            else if (b > 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal(order1[j].Amount);
                            //            }
                            //        }
                            //        else
                            //        {
                            //            if (b * (-1) == 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order1[j].Odds > 0 ? order1[j].Amount / 2 : order1[j].ValidAmount / 2));
                            //            }
                            //            else if (b * (-1) > 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order1[j].Odds > 0 ? order1[j].Amount : order1[j].ValidAmount));
                            //            }
                            //        }
                            //    }
                            //    else
                            //    {
                            //        if (b == 0)
                            //        {
                            //            h.Result = 0;
                            //        }
                            //        else if (b < 0)
                            //        {
                            //            h.Result = Convert.ToDecimal("-" + (order1[j].Odds > 0 ? order1[j].Amount : order1[j].ValidAmount));
                            //        }
                            //        else if (b > 0)
                            //        {
                            //            //h.Result = Convert.ToDecimal((order1[j].Odds > 0 ? order1[j].Amount : order1[j].ValidAmount));
                            //            h.Result = Convert.ToDecimal(order1[j].Amount);
                            //        }
                            //    }
                            //}
                            break;
                        /*---全场让球结束----------*/
                        /*---半场大小----------*/
                        case 3:
                        case 7:
                        case 11:

                            if (order1[j].Status == "0")
                            {
                                break;
                            }

                            handcap = Convert.ToDecimal(order1[j].Handicap);
                            score_arr = hls[i].Split(':');
                            hscore = Convert.ToDecimal(score_arr[0]);   //主队比分
                            ascore = Convert.ToDecimal(score_arr[1]);   //客队比分
                            scoretotal = hscore + ascore;
                            aa = 0;
                            if (order1[j].Betflag == "O")
                            {
                                //---投注是大

                                //计算输赢
                                aa = scoretotal - handcap;
                            }
                            else if (order1[j].Betflag == "U")
                            {
                                //---小

                                //计算输赢
                                aa = handcap - scoretotal;
                            }

                            //--计算输赢
                            if (aa > 0)
                            {
                                if (aa == Convert.ToDecimal("0.25"))
                                {
                                    //赢一半
                                    h.Result = (order1[j].Odds >= 0 ? order1[j].ValidAmount : order1[j].Amount) / 2;
                                }
                                else
                                {
                                    //全赢
                                    h.Result = order1[j].Odds >= 0 ? order1[j].ValidAmount : order1[j].Amount;
                                }
                            }
                            else if (aa == 0)
                            {
                                //平
                                h.Result = 0;
                            }
                            else if (aa < 0)
                            {
                                if (aa == Convert.ToDecimal("-0.25"))
                                {
                                    //输一半
                                    h.Result = (order1[j].Odds >= 0 ? -order1[j].Amount : -order1[j].ValidAmount) / 2;
                                }
                                else
                                {
                                    //全输
                                    h.Result = order1[j].Odds >= 0 ? -order1[j].Amount : -order1[j].ValidAmount;
                                }
                            }



                            //if (order1[j].Status == "0")
                            //{
                            //    break;
                            //}
                            //a = 0;
                            //a = int.Parse(hls[i].Substring(0, hls[i].IndexOf(':'))) + int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1));
                            //double s2 = double.Parse(order1[j].Handicap) / 0.5;
                            //int ss2 = int.Parse(s2.ToString().IndexOf('.') != -1 ? s2.ToString().Substring(0, s2.ToString().IndexOf('.')) : s2.ToString());
                            //if (s2 == ss2)
                            //{
                            //    if (a > double.Parse(order1[j].Handicap))
                            //    {
                            //        h.Result = (order1[j].Betflag == "O" ? (order1[j].Amount) : decimal.Parse("-" + (order1[j].Odds > 0 ? order1[j].Amount : order1[j].ValidAmount)));
                            //    }
                            //    else if (a < double.Parse(order1[j].Handicap))
                            //    {
                            //        h.Result = (order1[j].Betflag == "U" ? (order1[j].Amount) : decimal.Parse("-" + (order1[j].Odds > 0 ? order1[j].Amount : order1[j].ValidAmount)));
                            //    }
                            //    else
                            //    {
                            //        h.Result = 0;
                            //    }
                            //}
                            //else
                            //{
                            //    if (order1[j].Betflag == "O")
                            //    {
                            //        if (a > double.Parse(order1[j].Handicap) + 0.25)
                            //        {
                            //            h.Result = order1[j].Amount;
                            //        }
                            //        else if (a < double.Parse(order1[j].Handicap) - 0.25)
                            //        {
                            //            h.Result = (order1[j].Odds > 0 ? order1[j].Amount : order1[j].ValidAmount);
                            //        }
                            //        else
                            //        {
                            //            if (a == double.Parse(order1[j].Handicap) - 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order1[j].Odds > 0 ? order1[j].Amount / 2 : order1[j].ValidAmount / 2));
                            //            }
                            //            else if (a == double.Parse(order1[j].Handicap) + 0.25)
                            //            {
                            //                h.Result = order1[j].Amount / 2;
                            //            }
                            //        }
                            //    }
                            //    else
                            //    {
                            //        if (a < double.Parse(order1[j].Handicap) - 0.25)
                            //        {
                            //            h.Result = order1[j].Amount;
                            //        }
                            //        else if (a > double.Parse(order1[j].Handicap) + 0.25)
                            //        {
                            //            h.Result = Convert.ToDecimal("-" + (order1[j].Odds > 0 ? order1[j].Amount : order1[j].ValidAmount));
                            //        }
                            //        else
                            //        {
                            //            if (a == double.Parse(order1[j].Handicap) + 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order1[j].Odds > 0 ? order1[j].Amount / 2 : order1[j].ValidAmount / 2));
                            //            }
                            //            else if (a == double.Parse(order1[j].Handicap) - 0.25)
                            //            {
                            //                h.Result = order1[j].Amount / 2;
                            //            }
                            //        }
                            //    }
                            //}
                            break;
                        /*---半场大小结束----------*/
                        /*---全场大小----------*/
                        case 1:
                        case 5:
                        case 9:

                            if (order1[j].Status == "0")
                            {
                                break;
                            }

                            handcap = Convert.ToDecimal(order1[j].Handicap);
                            score_arr = order1[j].Score.Split(':');
                            hscore = Convert.ToDecimal(score_arr[0]);   //主队比分
                            ascore = Convert.ToDecimal(score_arr[1]);   //客队比分
                            scoretotal = hscore + ascore;
                            aa = 0;
                            if (order1[j].Betflag == "O")
                            {
                                //---投注是大

                                //计算输赢
                                aa = scoretotal - handcap;
                            }
                            else if (order1[j].Betflag == "U")
                            {
                                //---小

                                //计算输赢
                                aa = handcap - scoretotal;
                            }

                            //--计算输赢
                            if (aa > 0)
                            {
                                if (aa == Convert.ToDecimal("0.25"))
                                {
                                    //赢一半
                                    h.Result = (order1[j].Odds >= 0 ? order1[j].ValidAmount : order1[j].Amount) / 2;
                                }
                                else
                                {
                                    //全赢
                                    h.Result = order1[j].Odds >= 0 ? order1[j].ValidAmount : order1[j].Amount;
                                }
                            }
                            else if (aa == 0)
                            {
                                //平
                                h.Result = 0;
                            }
                            else if (aa < 0)
                            {
                                if (aa == Convert.ToDecimal("-0.25"))
                                {
                                    //输一半
                                    h.Result = (order1[j].Odds >= 0 ? -order1[j].Amount : -order1[j].ValidAmount) / 2;
                                }
                                else
                                {
                                    //全输
                                    h.Result = order1[j].Odds >= 0 ? -order1[j].Amount : -order1[j].ValidAmount;
                                }
                            }





                            //if (order1[j].Status == "0")
                            //{
                            //    break;
                            //}
                            //a = 0;
                            //a = int.Parse(order1[j].Score.Substring(0, order1[j].Score.IndexOf(':'))) + int.Parse(order1[j].Score.Substring(order1[j].Score.IndexOf(':') + 1));
                            ////a = int.Parse(hls[i].Substring(0, hls[i].IndexOf(':'))) + int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1));
                            //double s3 = double.Parse(order1[j].Handicap) / 0.5;
                            //int ss3 = int.Parse(s3.ToString().IndexOf('.') != -1 ? s3.ToString().Substring(0, s3.ToString().IndexOf('.')) : s3.ToString());
                            //if (s3 == ss3)
                            //{
                            //    if (a > double.Parse(order1[j].Handicap))
                            //    {
                            //        h.Result = (order1[j].Betflag == "O" ? (order1[j].Amount) : decimal.Parse("-" + (order1[j].Odds > 0 ? order1[j].Amount : order1[j].ValidAmount)));
                            //    }
                            //    else if (a < double.Parse(order1[j].Handicap))
                            //    {
                            //        h.Result = (order1[j].Betflag == "U" ? (order1[j].Amount) : decimal.Parse("-" + (order1[j].Odds > 0 ? order1[j].Amount : order1[j].ValidAmount)));
                            //    }
                            //    else
                            //    {
                            //        h.Result = 0;
                            //    }
                            //}
                            //else
                            //{
                            //    if (order1[j].Betflag == "O")
                            //    {
                            //        if (a > double.Parse(order1[j].Handicap) + 0.25)
                            //        {
                            //            h.Result = order1[j].Amount;
                            //        }
                            //        else if (a < double.Parse(order1[j].Handicap) - 0.25)
                            //        {
                            //            h.Result = Convert.ToDecimal("-" + (order1[j].Odds > 0 ? order1[j].Amount : order1[j].ValidAmount));
                            //        }
                            //        else
                            //        {
                            //            if (a == double.Parse(order1[j].Handicap) - 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order1[j].Odds > 0 ? order1[j].Amount / 2 : order1[j].ValidAmount / 2));
                            //            }
                            //            else if (a == double.Parse(order1[j].Handicap) + 0.25)
                            //            {
                            //                h.Result = order1[j].Amount / 2;
                            //            }
                            //        }
                            //    }
                            //    else
                            //    {
                            //        if (a < double.Parse(order1[j].Handicap) - 0.25)
                            //        {
                            //            h.Result = order1[j].Amount;
                            //        }
                            //        else if (a > double.Parse(order1[j].Handicap) + 0.25)
                            //        {
                            //            h.Result = Convert.ToDecimal("-" + (order1[j].Odds > 0 ? order1[j].Amount : order1[j].ValidAmount));
                            //        }
                            //        else
                            //        {
                            //            if (a == double.Parse(order1[j].Handicap) + 0.25)
                            //            {
                            //                h.Result = Convert.ToDecimal("-" + (order1[j].Odds > 0 ? order1[j].Amount / 2 : order1[j].ValidAmount / 2));
                            //            }
                            //            else if (a == double.Parse(order1[j].Handicap) - 0.25)
                            //            {
                            //                h.Result = order1[j].Amount / 2;
                            //            }
                            //        }
                            //    }
                            //}
                            break;
                        /*---全场大小结束----------*/
                        /*---半场标准----------*/
                        case 13:
                        case 15:
                        case 17:
                            //if (order[j].BetType == "15")
                            //{
                            //    Orderdetail1x2hflManager.DeleteOrderdetail1x2hflByPK(order[j].ID);
                            //}
                            //else
                            //{
                            //    Orderdetail1x2hfManager.DeleteOrderdetail1x2hfByPK(order[j].ID);
                            //}
                            //if(order[j].Status == "0")
                            //{
                            //    break;
                            //}
                            //a = 0;
                            ///*-------选择主队时a与b的值---------*/
                            //if (order[j].Betflag == "1")
                            //{
                            //    a = int.Parse(hls[i].Substring(0, hls[i].IndexOf(':'))) - int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1));
                            //}
                            ///*-------选择客队时a与b的值--------*/
                            //else if (order[j].Betflag == "2")
                            //{
                            //    a = int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1)) - int.Parse(hls[i].Substring(0, hls[i].IndexOf(':')));
                            //}
                            //else
                            //{
                            //    a = int.Parse(hls[i].Substring(0, hls[i].IndexOf(':'))) - int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1));
                            //}
                            //if (a < 0)
                            //{
                            //    h.Result = decimal.Parse("-" + (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount));
                            //}
                            //else if (a > 0)
                            //{
                            //    h.Result = (order[j].Odds > 0 ? order[j].Amount : order[j].ValidAmount);
                            //}
                            //else
                            //{
                            //    h.Result = 0;
                            //}

                            if (order1[j].Status == "0")
                            {
                                break;
                            }
                            a = 0;
                            if (order1[j].Betflag == "1")
                            {
                                a = int.Parse(hls[i].Substring(0, hls[i].IndexOf(':'))) - int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1));
                                if (a > 0)
                                {
                                    h.Result = order1[j].Amount;
                                }
                                else
                                {
                                    h.Result = decimal.Parse("-" + order1[j].Amount);
                                }
                            }
                            else if (order1[j].Betflag == "2")
                            {
                                a = int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1)) - int.Parse(hls[i].Substring(0, hls[i].IndexOf(':')));
                                if (a > 0)
                                {
                                    h.Result = order1[j].Amount;
                                }
                                else
                                {
                                    h.Result = decimal.Parse("-" + order1[j].Amount);
                                }
                            }
                            else
                            {
                                a = int.Parse(hls[i].Substring(0, hls[i].IndexOf(':'))) - int.Parse(hls[i].Substring(hls[i].IndexOf(':') + 1));
                                if (a == 0)
                                {
                                    h.Result = order1[j].Amount;
                                }
                                else
                                {
                                    h.Result = decimal.Parse("-" + order1[j].Amount);
                                }
                            }

                            break;
                        /*---半场标准结束----------*/
                        /*---全场标准----------*/
                        case 12:
                        case 14:
                        case 16:
                            if (order1[j].Status == "0")
                            {
                                break;
                            }
                            a = 0;
                            if (order1[j].Betflag == "1")
                            {
                                a = int.Parse(order1[j].Score.Substring(0, order1[j].Score.IndexOf(':'))) - int.Parse(order1[j].Score.Substring(order1[j].Score.IndexOf(':') + 1));
                                if (a > 0)
                                {
                                    h.Result = order1[j].Amount;
                                }
                                else
                                {
                                    h.Result = decimal.Parse("-" + order1[j].Amount);
                                }
                            }
                            else if (order1[j].Betflag == "2")
                            {
                                a = int.Parse(order1[j].Score.Substring(order1[j].Score.IndexOf(':') + 1)) - int.Parse(order1[j].Score.Substring(0, order1[j].Score.IndexOf(':')));
                                if (a > 0)
                                {
                                    h.Result = order1[j].Amount;
                                }
                                else
                                {
                                    h.Result = decimal.Parse("-" + order1[j].Amount);
                                }
                            }
                            else
                            {
                                a = int.Parse(order1[j].Score.Substring(0, order1[j].Score.IndexOf(':'))) - int.Parse(order1[j].Score.Substring(order1[j].Score.IndexOf(':') + 1));
                                if (a == 0)
                                {
                                    h.Result = order1[j].Amount;
                                }
                                else
                                {
                                    h.Result = decimal.Parse("-" + order1[j].Amount);
                                }
                            }

                            break;
                        /*---全场标准结束----------*/
                    }

                    h.Odds = order1[j].Odds;
                    if (h.Result > 0)
                    {
                        if (order1[j].BetType == "12" || order1[j].BetType == "13" || order1[j].BetType == "14" || order1[j].BetType == "15" || order1[j].BetType == "16" || order1[j].BetType == "17")
                        {
                            h.Result = h.Result * (h.Odds < 0 ? 1 : (h.Odds - 1));
                        }
                        else
                        {
                            h.Result = h.Result * (h.Odds < 0 ? 1 : h.Odds);
                        }
                    }
                    h.Agent = order1[j].Agent;
                    h.Scorehalf = hls[i];
                    h.Amount = order1[j].Amount;
                    h.Awaycn = order1[j].Awaycn;
                    h.Awayen = order1[j].Awayen;
                    h.Awayth = order1[j].Awayth;
                    h.Awaytw = order1[j].Awaytw;
                    h.Awayvn = order1[j].Awayvn;
                    h.BeginTime = order1[j].BeginTime;
                    h.BetItem = order1[j].BetItem;
                    h.BetType = order1[j].BetType;
                    h.Gameid = order1[j].Gameid;
                    h.Handicap = order1[j].Handicap;
                    h.Homecn = order1[j].Homecn;
                    h.Homeen = order1[j].Homeen;
                    h.Hometh = order1[j].Hometh;
                    h.Hometw = order1[j].Hometw;
                    h.Homevn = order1[j].Homevn;
                    h.IsHalf = order1[j].IsHalf;
                    h.Leaguecn = order1[j].Leaguecn;
                    h.Leagueen = order1[j].Leagueen;
                    h.Leagueth = order1[j].Leagueth;
                    h.Leaguetw = order1[j].Leaguetw;
                    h.Leaguevn = order1[j].Leaguevn;
                    h.OddsType = order1[j].OddsType;
                    h.OrderID = order1[j].OrderID;
                    h.Score = order1[j].Score;
                    h.Status = order1[j].Status;
                    h.Time = order1[j].Time;
                    h.UserName = order1[j].UserName;
                    h.ValidAmount = order1[j].ValidAmount;
                    h.WebSiteiID = order1[j].WebSiteiID;
                    h.Betflag = order1[j].Betflag;
                    h.WebUserName = order1[j].WebUserName;
                    h.WebOrderID = order1[j].WebOrderID;
                    h.Websitepossess = order1[j].Websitepossess;
                    h.Selfpossess = order1[j].Selfpossess;
                    h.Commission = order1[j].Commission;
                    h.Multiple = order1[j].Multiple;
                    h.MoreAmount = order1[j].MoreAmount;
                    h.Scoreathalf = scoreCurr;

                    OrderotherhistoryManager.AddOrderotherhistory(h);
                    OrderotherManager.DeleteOrderotherByPK(order1[j].ID);

                }

                PageBase page = new PageBase();
                IList<Matches> ma = MatchesManager.GetMutilILMatches(int.Parse(gi[i]));
                Matches_copy macy = new Matches_copy();
                macy.Away1 = ma[0].Away1;
                macy.Awaycn = ma[0].Awaycn;
                macy.Awayen = ma[0].Awayen;
                macy.Awayth = ma[0].Awayth;
                macy.Awaytw = ma[0].Awaytw;
                macy.Awayvn = ma[0].Awayvn;
                macy.Begintime = ma[0].Begintime;
                macy.Casino = ma[0].Casino;
                macy.Color = ma[0].Color;
                macy.Danger = ma[0].Danger;
                macy.Display = ma[0].Display;
                macy.Dotime = ma[0].Dotime;
                macy.Halfawayscore = ma[0].Halfawayscore;
                macy.Halfhomescore = ma[0].Halfhomescore;
                macy.Home1 = ma[0].Home1;
                macy.Homecn = ma[0].Homecn;
                macy.Homeen = ma[0].Homeen;
                macy.Hometh = ma[0].Hometh;
                macy.Hometw = ma[0].Hometw;
                macy.Homevn = ma[0].Homevn;
                macy.Isstart = ma[0].Isstart;
                macy.League1 = ma[0].League1;
                macy.Leaguecn = ma[0].Leaguecn;
                macy.Leagueen = ma[0].Leagueen;
                macy.Leagueth = ma[0].Leagueth;
                macy.Leaguetw = ma[0].Leaguetw;
                macy.Leaguevn = ma[0].Leaguevn;
                macy.Matchid = ma[0].Matchid;
                macy.Number = ma[0].Number;
                macy.Redcard = ma[0].Redcard;
                macy.Resultawayscore = ma[0].Resultawayscore;
                macy.Resulthomescore = ma[0].Resulthomescore;
                macy.Running = ma[0].Running;
                macy.Score = ma[0].Score;
                macy.State = ma[0].State;
                macy.Time = ma[0].Time;
                macy.Type = ma[0].Type;
                macy.Updatetime = ma[0].Updatetime;
                macy.Scoreinputuser = ma[0].Scoreinputuser;
                macy.Scoreinputtime = ma[0].Scoreinputtime;
                macy.Resulthomescore2 = ma[0].Resulthomescore2;
                macy.Resultawayscore2 = ma[0].Resultawayscore2;
                macy.Halfhomescore2 = ma[0].Halfhomescore2;
                macy.Halfawayscore2 = ma[0].Halfawayscore2;
                macy.Jstime = DateTime.Now;
                macy.Jsuser = page.CurrentManager.ManagerId;
                Matches_copyManager.AddMatches_copy(macy);
                MatchesManager.DeleteMatchesByPK(int.Parse(gi[i]));
            }
            return "true";
        }
        /*-------------结算的方法结束-----------------*/

        /*-----------------取消比赛的方法-------------------*/
        [WebMethod(EnableSession = true)]
        public bool CancelLeague(string id, string reason, string zc, string isHalf, string webSiteiID, string orderID)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }
            bool flag = false;
            string whereSql = "";
            whereSql = "gameid=" + id;
            if (zc == "0")
            {
                if (orderID == "")
                {
                    if (!string.IsNullOrEmpty(isHalf))
                    {
                        whereSql += " and IsHalf in(" + isHalf + ") ";
                    }
                    if (!string.IsNullOrEmpty(webSiteiID))
                    {
                        whereSql += " and WebSiteiID in(" + webSiteiID + ") ";
                    }
                }
                else
                {
                    whereSql += " and OrderID in(" + orderID + ") ";
                }
            }
            
            //把该场比赛从[matches]表移动到[matches_copy]
            try
            {
                //把该场比赛所有的注单移动到orderhistory表，状态status设置为0，取消原因reason
                Orderhistory h = new Orderhistory();
                List<Orderdetaillive> orderlive = OrderdetailliveManager.GetOrderAllByWhere(whereSql);  //获得该场比赛走地的所有未确认注单
                for (int i = 0; i < orderlive.Count; i++)
                {
                    flag = OrderdetailliveManager.DeleteOrderdetailliveByPK(orderlive[i].ID);
                    h.Odds = orderlive[i].Odds;
                    h.Result = 0;
                    h.Agent = orderlive[i].Agent;
                    h.Scorehalf = "0";
                    h.AgentCommission = orderlive[i].AgentCommission;
                    h.AgentPercent = orderlive[i].AgentPercent;
                    h.Amount = orderlive[i].Amount;
                    h.Awaycn = orderlive[i].Awaycn;
                    h.Awayen = orderlive[i].Awayen;
                    h.Awayth = orderlive[i].Awayth;
                    h.Awaytw = orderlive[i].Awaytw;
                    h.Awayvn = orderlive[i].Awayvn;
                    h.BeginTime = orderlive[i].BeginTime;
                    h.BetItem = orderlive[i].BetItem;
                    h.BetType = orderlive[i].BetType;
                    h.Coefficient = orderlive[i].Coefficient;
                    h.CompanyCommission = orderlive[i].CompanyCommission;
                    h.CompanyPercent = orderlive[i].CompanyPercent;
                    h.Currency = orderlive[i].Currency;
                    h.Gameid = orderlive[i].Gameid;
                    h.Handicap = orderlive[i].Handicap;
                    h.Homecn = orderlive[i].Homecn;
                    h.Homeen = orderlive[i].Homeen;
                    h.Hometh = orderlive[i].Hometh;
                    h.Hometw = orderlive[i].Hometw;
                    h.Homevn = orderlive[i].Homevn;
                    h.IP = orderlive[i].IP;
                    h.IsHalf = orderlive[i].IsHalf;
                    h.Leaguecn = orderlive[i].Leaguecn;
                    h.Leagueen = orderlive[i].Leagueen;
                    h.Leagueth = orderlive[i].Leagueth;
                    h.Leaguetw = orderlive[i].Leaguetw;
                    h.Leaguevn = orderlive[i].Leaguevn;
                    h.OddsType = orderlive[i].OddsType;
                    h.OrderID = orderlive[i].OrderID;
                    h.Partner = orderlive[i].Partner;
                    h.PartnerCommission = orderlive[i].PartnerCommission;
                    h.PartnerPercent = orderlive[i].PartnerPercent;
                    h.Proportion = orderlive[i].Proportion;
                    h.Reason = reason;
                    h.Score = orderlive[i].Score;
                    h.Status = "0";
                    h.SubCompany = orderlive[i].SubCompany;
                    h.SubCompanyCommission = orderlive[i].SubCompanyCommission;
                    h.SubCompanyPercent = orderlive[i].SubCompanyPercent;
                    h.Time = orderlive[i].Time;
                    h.UserLevel = orderlive[i].UserLevel;
                    h.UserName = orderlive[i].UserName;
                    h.ValidAmount = orderlive[i].ValidAmount;
                    h.WebSiteiID = orderlive[i].WebSiteiID;
                    h.ZAgent = orderlive[i].ZAgent;
                    h.ZAgentCommission = orderlive[i].ZAgentCommission;
                    h.ZAgentPercent = orderlive[i].ZAgentPercent;
                    h.Betflag = orderlive[i].Betflag;
                    h.MemberPercent = orderlive[i].MemberPercent;
                    h.MemberCommission = orderlive[i].MemberCommission;
                    flag = OrderhistoryManager.AddOrderhistory(h);
                    flag = Convert.ToInt32(Orderdetail1x2hflManager.setBalance(h.UserName, (h.Amount).ToString())) > 0;                    
                }
                List<Orderdetail1x2> order = Orderdetail1x2Manager.getOrderAllByWhere(whereSql);  //获得该场比赛的所有注单
                for (int j = 0; j < order.Count; j++)
                {
                    switch (int.Parse(order[j].BetType))
                    {
                        /*-----半场让球--------*/
                        case 2:
                        case 6:
                        case 10:
                            if (order[j].BetType == "6")
                            {
                                flag = OrderdetailhdphflManager.DeleteOrderdetailhdphflByPK(order[j].ID);
                                h.Odds = order[j].Odds;
                                h.Result = 0;
                                h.Agent = order[j].Agent;
                                h.Scorehalf = "0";
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
                                h.Reason = reason;
                                h.Score = order[j].Score;
                                h.Status = "0";
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
                                h.MemberPercent = order[j].MemberPercent;
                                h.MemberCommission = order[j].MemberCommission;
                                flag = OrderhistoryManager.AddOrderhistory(h);
                                if (order[j].Status != "0") {
                                    flag = Convert.ToInt32(Orderdetail1x2hflManager.setBalance(h.UserName, (h.Amount).ToString())) > 0;
                                }
                            }
                            else
                            {
                                flag = OrderdetailhdphfManager.DeleteOrderdetailhdphfByPK(order[j].ID);
                                h.Odds = order[j].Odds;
                                h.Result = 0;
                                h.Agent = order[j].Agent;
                                h.Scorehalf = "0";
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
                                h.Reason = reason;
                                h.Score = order[j].Score;
                                h.Status = "0";
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
                                h.MemberPercent = order[j].MemberPercent;
                                h.MemberCommission = order[j].MemberCommission;
                                flag = OrderhistoryManager.AddOrderhistory(h);
                                if (order[j].Status != "0")
                                {
                                    flag = Convert.ToInt32(Orderdetail1x2hflManager.setBalance(h.UserName, (h.Amount).ToString())) > 0;
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
                                flag = OrderdetailhdplManager.DeleteOrderdetailhdplByPK(order[j].ID);
                                h.Odds = order[j].Odds;
                                h.Result = 0;
                                h.Agent = order[j].Agent;
                                h.Scorehalf = "0";
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
                                h.Reason = reason;
                                h.Score = order[j].Score;
                                h.Status = "0";
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
                                h.MemberPercent = order[j].MemberPercent;
                                h.MemberCommission = order[j].MemberCommission;
                                flag = OrderhistoryManager.AddOrderhistory(h);
                                if (order[j].Status != "0")
                                {
                                    flag = Convert.ToInt32(Orderdetail1x2hflManager.setBalance(h.UserName, (h.Amount).ToString())) > 0;
                                }
                            }
                            else
                            {
                                flag = OrderdetailhdpManager.DeleteOrderdetailhdpByPK(order[j].ID);
                                h.Odds = order[j].Odds;
                                h.Result = 0;
                                h.Agent = order[j].Agent;
                                h.Scorehalf = "0";
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
                                h.Reason = reason;
                                h.Score = order[j].Score;
                                h.Status = "0";
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
                                h.MemberPercent = order[j].MemberPercent;
                                h.MemberCommission = order[j].MemberCommission;
                                flag = OrderhistoryManager.AddOrderhistory(h);
                                if (order[j].Status != "0")
                                {
                                    flag = Convert.ToInt32(Orderdetail1x2hflManager.setBalance(h.UserName, (h.Amount).ToString())) > 0;
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
                                flag = OrderdetailouhflManager.DeleteOrderdetailouhflByPK(order[j].ID);
                                h.Odds = order[j].Odds;
                                h.Result = 0;
                                h.Agent = order[j].Agent;
                                h.Scorehalf = "0";
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
                                h.Reason = reason;
                                h.Score = order[j].Score;
                                h.Status = "0";
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
                                h.MemberPercent = order[j].MemberPercent;
                                h.MemberCommission = order[j].MemberCommission;
                                flag = OrderhistoryManager.AddOrderhistory(h);
                                if (order[j].Status != "0")
                                {
                                    flag = Convert.ToInt32(Orderdetail1x2hflManager.setBalance(h.UserName, (h.Amount).ToString())) > 0;
                                }
                            }
                            else
                            {
                                flag = OrderdetailouhfManager.DeleteOrderdetailouhfByPK(order[j].ID);
                                h.Odds = order[j].Odds;
                                h.Result = 0;
                                h.Agent = order[j].Agent;
                                h.Scorehalf = "0";
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
                                h.Reason = reason;
                                h.Score = order[j].Score;
                                h.Status = "0";
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
                                h.MemberPercent = order[j].MemberPercent;
                                h.MemberCommission = order[j].MemberCommission;
                                flag = OrderhistoryManager.AddOrderhistory(h);
                                if (order[j].Status != "0")
                                {
                                    flag = Convert.ToInt32(Orderdetail1x2hflManager.setBalance(h.UserName, (h.Amount).ToString())) > 0;
                                }
                            }
                            break;
                        /*---半场大小结束----------*/
                        /*---全场大小----------*/
                        case 1:
                        case 5:
                        case 9:
                            if (order[j].BetType == "5")
                            {
                                flag = OrderdetailoulManager.DeleteOrderdetailoulByPK(order[j].ID);
                                h.Odds = order[j].Odds;
                                h.Result = 0;
                                h.Agent = order[j].Agent;
                                h.Scorehalf = "0";
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
                                h.Reason = reason;
                                h.Score = order[j].Score;
                                h.Status = "0";
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
                                h.MemberPercent = order[j].MemberPercent;
                                h.MemberCommission = order[j].MemberCommission;
                                flag = OrderhistoryManager.AddOrderhistory(h);
                                if (order[j].Status != "0")
                                {
                                    flag = Convert.ToInt32(Orderdetail1x2hflManager.setBalance(h.UserName, (h.Amount).ToString())) > 0;
                                }
                            }
                            else
                            {
                                flag = OrderdetailouManager.DeleteOrderdetailouByPK(order[j].ID);
                                h.Odds = order[j].Odds;
                                h.Result = 0;
                                h.Agent = order[j].Agent;
                                h.Scorehalf = "0";
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
                                h.Reason = reason;
                                h.Score = order[j].Score;
                                h.Status = "0";
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
                                h.MemberPercent = order[j].MemberPercent;
                                h.MemberCommission = order[j].MemberCommission;
                                flag = OrderhistoryManager.AddOrderhistory(h);
                                if (order[j].Status != "0")
                                {
                                    flag = Convert.ToInt32(Orderdetail1x2hflManager.setBalance(h.UserName, (h.Amount).ToString())) > 0;
                                }
                            }
                            break;
                        /*---全场大小结束----------*/
                        /*---半场标准----------*/
                        case 13:
                        case 15:
                        case 17:
                            if (order[j].BetType == "15")
                            {
                                flag = Orderdetail1x2hflManager.DeleteOrderdetail1x2hflByPK(order[j].ID);
                                h.Odds = order[j].Odds;
                                h.Result = 0;
                                h.Agent = order[j].Agent;
                                h.Scorehalf = "0";
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
                                h.Reason = reason;
                                h.Score = order[j].Score;
                                h.Status = "0";
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
                                h.MemberPercent = order[j].MemberPercent;
                                h.MemberCommission = order[j].MemberCommission;
                                flag = OrderhistoryManager.AddOrderhistory(h);
                                if (order[j].Status != "0")
                                {
                                    flag = Convert.ToInt32(Orderdetail1x2hflManager.setBalance(h.UserName, (h.Amount).ToString())) > 0;
                                }
                            }
                            else
                            {
                                flag = Orderdetail1x2hfManager.DeleteOrderdetail1x2hfByPK(order[j].ID);
                                h.Odds = order[j].Odds;
                                h.Result = 0;
                                h.Agent = order[j].Agent;
                                h.Scorehalf = "0";
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
                                h.Reason = reason;
                                h.Score = order[j].Score;
                                h.Status = "0";
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
                                h.MemberPercent = order[j].MemberPercent;
                                h.MemberCommission = order[j].MemberCommission;
                                flag = OrderhistoryManager.AddOrderhistory(h);
                                if (order[j].Status != "0")
                                {
                                    flag = Convert.ToInt32(Orderdetail1x2hflManager.setBalance(h.UserName, (h.Amount).ToString())) > 0;
                                }
                            }
                            break;
                        /*---半场标准结束----------*/
                        /*---全场标准----------*/
                        case 12:
                        case 14:
                        case 16:
                            if (order[j].BetType == "14")
                            {
                                flag = Orderdetail1x2lManager.DeleteOrderdetail1x2lByPK(order[j].ID);
                                h.Odds = order[j].Odds;
                                h.Result = 0;
                                h.Agent = order[j].Agent;
                                h.Scorehalf = "0";
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
                                h.Reason = reason;
                                h.Score = order[j].Score;
                                h.Status = "0";
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
                                h.MemberPercent = order[j].MemberPercent;
                                h.MemberCommission = order[j].MemberCommission;
                                flag = OrderhistoryManager.AddOrderhistory(h);
                                if (order[j].Status != "0")
                                {
                                    flag = Convert.ToInt32(Orderdetail1x2hflManager.setBalance(h.UserName, (h.Amount).ToString())) > 0;
                                }
                            }
                            else
                            {
                                flag = Orderdetail1x2Manager.DeleteOrderdetail1x2ByPK(order[j].ID);
                                h.Odds = order[j].Odds;
                                h.Result = 0;
                                h.Agent = order[j].Agent;
                                h.Scorehalf = "0";
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
                                h.Reason = reason;
                                h.Score = order[j].Score;
                                h.Status = "0";
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
                                h.MemberPercent = order[j].MemberPercent;
                                h.MemberCommission = order[j].MemberCommission;
                                flag = OrderhistoryManager.AddOrderhistory(h);
                                if (order[j].Status != "0")
                                {
                                    flag = Convert.ToInt32(Orderdetail1x2hflManager.setBalance(h.UserName, (h.Amount).ToString())) > 0;
                                }
                            }
                            break;
                        /*---全场标准结束----------*/
                    }
                }

                if (zc == "1")
                {
                    IList<Matches> ma = MatchesManager.GetMutilILMatches(int.Parse(id));
                    Matches_copy macy = new Matches_copy();
                    macy.Away1 = ma[0].Away1;
                    macy.Awaycn = ma[0].Awaycn;
                    macy.Awayen = ma[0].Awayen;
                    macy.Awayth = ma[0].Awayth;
                    macy.Awaytw = ma[0].Awaytw;
                    macy.Awayvn = ma[0].Awayvn;
                    macy.Begintime = ma[0].Begintime;
                    macy.Casino = ma[0].Casino;
                    macy.Color = ma[0].Color;
                    macy.Danger = ma[0].Danger;
                    macy.Display = ma[0].Display;
                    macy.Dotime = ma[0].Dotime;
                    macy.Halfawayscore = ma[0].Halfawayscore;
                    macy.Halfhomescore = ma[0].Halfhomescore;
                    macy.Home1 = ma[0].Home1;
                    macy.Homecn = ma[0].Homecn;
                    macy.Homeen = ma[0].Homeen;
                    macy.Hometh = ma[0].Hometh;
                    macy.Hometw = ma[0].Hometw;
                    macy.Homevn = ma[0].Homevn;
                    macy.Isstart = ma[0].Isstart;
                    macy.League1 = ma[0].League1;
                    macy.Leaguecn = ma[0].Leaguecn;
                    macy.Leagueen = ma[0].Leagueen;
                    macy.Leagueth = ma[0].Leagueth;
                    macy.Leaguetw = ma[0].Leaguetw;
                    macy.Leaguevn = ma[0].Leaguevn;
                    macy.Matchid = ma[0].Matchid;
                    macy.Number = ma[0].Number;
                    macy.Redcard = ma[0].Redcard;
                    macy.Resultawayscore = ma[0].Resultawayscore;
                    macy.Resulthomescore = ma[0].Resulthomescore;
                    macy.Running = ma[0].Running;
                    macy.Score = ma[0].Score;
                    macy.State = 0;
                    macy.Time = ma[0].Time;
                    macy.Type = ma[0].Type;
                    macy.Updatetime = ma[0].Updatetime;
                    macy.Reason = reason;
                    flag = Matches_copyManager.AddMatches_copy(macy);
                    flag = MatchesManager.DeleteMatchesByPK(int.Parse(id));
                }

            }catch (Exception)
            { }
            return flag;
        } 
        /*---------------取消比赛的方法结束----------------*/

        [WebMethod(true)]
        public string GetOrderC(string isHalf, string webSiteiID, string userName, string orderID, string IP,
            string time1, string time2)
        {
            OrderdetailliveManager om = new OrderdetailliveManager();
            string s = om.GetOrderAllByWhere(isHalf, webSiteiID, userName, orderID, IP, time1, time2);

            return s;
        }

    }
}
