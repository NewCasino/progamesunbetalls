using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class OrderotherhistoryService
	{
        private const string SQL_INSERT = "insert into yafa.orderotherhistory (Scoreathalf,UserName,WebUserName,OrderID,WebOrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,BeginTime,BetType,IsHalf,BetItem,Score,Awaycn,Awaytw,Awayen,Awayth,Awayvn,Homecn,Hometw,Homeen,Hometh,Homevn,Handicap,OddsType,Odds,Amount,ValidAmount,Status,WebSiteiID,agent,websitepossess,selfpossess,commission,multiple,gameid,betflag,Result,Reason,Scorehalf,MoreAmount)values(?Scoreathalf,?UserName,?WebUserName,?OrderID,?WebOrderID,?time,?leaguecn,?leaguetw,?leagueen,?leagueth,?leaguevn,?BeginTime,?BetType,?IsHalf,?BetItem,?Score,?Awaycn,?Awaytw,?Awayen,?Awayth,?Awayvn,?Homecn,?Hometw,?Homeen,?Hometh,?Homevn,?Handicap,?OddsType,?Odds,?Amount,?ValidAmount,?Status,?WebSiteiID,?agent,?websitepossess,?selfpossess,?commission,?multiple,?gameid,?betflag,?Result,?Reason,?Scorehalf,?MoreAmount)";
        private const string SQL_UPDATE = "update yafa.orderotherhistory set UserName=?UserName,WebUserName=?WebUserName,OrderID=?OrderID,WebOrderID=?WebOrderID,time=?time,leaguecn=?leaguecn,leaguetw=?leaguetw,leagueen=?leagueen,leagueth=?leagueth,leaguevn=?leaguevn,BeginTime=?BeginTime,BetType=?BetType,IsHalf=?IsHalf,BetItem=?BetItem,Score=?Score,Awaycn=?Awaycn,Awaytw=?Awaytw,Awayen=?Awayen,Awayth=?Awayth,Awayvn=?Awayvn,Homecn=?Homecn,Hometw=?Hometw,Homeen=?Homeen,Hometh=?Hometh,Homevn=?Homevn,Handicap=?Handicap,OddsType=?OddsType,Odds=?Odds,Amount=?Amount,ValidAmount=?ValidAmount,Status=?Status,WebSiteiID=?WebSiteiID,agent=?agent,websitepossess=?websitepossess,selfpossess=?selfpossess,commission=?commission,multiple=?multiple,gameid=?gameid,betflag=?betflag,Result=?Result,Reason=?Reason,Scorehalf=?Scorehalf,MoreAmount=?MoreAmount where ID = ?ID";
        private const string SQL_SELECTBYPK = "select ID from yafa.orderotherhistory  where orderotherhistory.ID = ?ID";
        private const string SQL_SELECTALL = "select ID,UserName,WebUserName,OrderID,WebOrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,BeginTime,BetType,IsHalf,BetItem,Score,Awaycn,Awaytw,Awayen,Awayth,Awayvn,Homecn,Hometw,Homeen,Hometh,Homevn,Handicap,OddsType,Odds,Amount,ValidAmount,Status,WebSiteiID,agent,websitepossess,selfpossess,commission,multiple,gameid,betflag,Result,Reason,Scorehalf,MoreAmount from yafa.orderotherhistory ";
        private const string SQL_DELETEBYPK = "delete from yafa.orderotherhistory  where orderotherhistory.ID = ?ID";

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-3-19 21:56:52		
        ///</summary>		
        public Boolean AddOrderotherhistory(Orderotherhistory orderotherhistory)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderotherhistory.UserName),
				 new MySqlParameter("?WebUserName",orderotherhistory.WebUserName),
				 new MySqlParameter("?OrderID",orderotherhistory.OrderID),
				 new MySqlParameter("?WebOrderID",orderotherhistory.WebOrderID),
				 new MySqlParameter("?time",orderotherhistory.Time),
				 new MySqlParameter("?leaguecn",orderotherhistory.Leaguecn),
				 new MySqlParameter("?leaguetw",orderotherhistory.Leaguetw),
				 new MySqlParameter("?leagueen",orderotherhistory.Leagueen),
				 new MySqlParameter("?leagueth",orderotherhistory.Leagueth),
				 new MySqlParameter("?leaguevn",orderotherhistory.Leaguevn),
				 new MySqlParameter("?BeginTime",orderotherhistory.BeginTime),
				 new MySqlParameter("?BetType",orderotherhistory.BetType),
				 new MySqlParameter("?IsHalf",orderotherhistory.IsHalf),
				 new MySqlParameter("?BetItem",orderotherhistory.BetItem),
				 new MySqlParameter("?Score",orderotherhistory.Score),
				 new MySqlParameter("?Awaycn",orderotherhistory.Awaycn),
				 new MySqlParameter("?Awaytw",orderotherhistory.Awaytw),
				 new MySqlParameter("?Awayen",orderotherhistory.Awayen),
				 new MySqlParameter("?Awayth",orderotherhistory.Awayth),
				 new MySqlParameter("?Awayvn",orderotherhistory.Awayvn),
				 new MySqlParameter("?Homecn",orderotherhistory.Homecn),
				 new MySqlParameter("?Hometw",orderotherhistory.Hometw),
				 new MySqlParameter("?Homeen",orderotherhistory.Homeen),
				 new MySqlParameter("?Hometh",orderotherhistory.Hometh),
				 new MySqlParameter("?Homevn",orderotherhistory.Homevn),
				 new MySqlParameter("?Handicap",orderotherhistory.Handicap),
				 new MySqlParameter("?OddsType",orderotherhistory.OddsType),
				 new MySqlParameter("?Odds",orderotherhistory.Odds),
				 new MySqlParameter("?Amount",orderotherhistory.Amount),
				 new MySqlParameter("?ValidAmount",orderotherhistory.ValidAmount),
				 new MySqlParameter("?Status",orderotherhistory.Status),
				 new MySqlParameter("?WebSiteiID",orderotherhistory.WebSiteiID),
				 new MySqlParameter("?agent",orderotherhistory.Agent),
				 new MySqlParameter("?websitepossess",orderotherhistory.Websitepossess),
				 new MySqlParameter("?selfpossess",orderotherhistory.Selfpossess),
				 new MySqlParameter("?commission",orderotherhistory.Commission),
				 new MySqlParameter("?multiple",orderotherhistory.Multiple),
				 new MySqlParameter("?gameid",orderotherhistory.Gameid),
				 new MySqlParameter("?betflag",orderotherhistory.Betflag),
				 new MySqlParameter("?Result",orderotherhistory.Result),
				 new MySqlParameter("?Reason",orderotherhistory.Reason),
				 new MySqlParameter("?Scorehalf",orderotherhistory.Scorehalf),
				 new MySqlParameter("?MoreAmount",orderotherhistory.MoreAmount),
                 new MySqlParameter("?Scoreathalf",orderotherhistory.Scoreathalf)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-3-19 21:56:52		
        ///</summary>		
        public Boolean UpdateOrderotherhistory(Orderotherhistory orderotherhistory)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderotherhistory.UserName),
				 new MySqlParameter("?WebUserName",orderotherhistory.WebUserName),
				 new MySqlParameter("?OrderID",orderotherhistory.OrderID),
				 new MySqlParameter("?WebOrderID",orderotherhistory.WebOrderID),
				 new MySqlParameter("?time",orderotherhistory.Time),
				 new MySqlParameter("?leaguecn",orderotherhistory.Leaguecn),
				 new MySqlParameter("?leaguetw",orderotherhistory.Leaguetw),
				 new MySqlParameter("?leagueen",orderotherhistory.Leagueen),
				 new MySqlParameter("?leagueth",orderotherhistory.Leagueth),
				 new MySqlParameter("?leaguevn",orderotherhistory.Leaguevn),
				 new MySqlParameter("?BeginTime",orderotherhistory.BeginTime),
				 new MySqlParameter("?BetType",orderotherhistory.BetType),
				 new MySqlParameter("?IsHalf",orderotherhistory.IsHalf),
				 new MySqlParameter("?BetItem",orderotherhistory.BetItem),
				 new MySqlParameter("?Score",orderotherhistory.Score),
				 new MySqlParameter("?Awaycn",orderotherhistory.Awaycn),
				 new MySqlParameter("?Awaytw",orderotherhistory.Awaytw),
				 new MySqlParameter("?Awayen",orderotherhistory.Awayen),
				 new MySqlParameter("?Awayth",orderotherhistory.Awayth),
				 new MySqlParameter("?Awayvn",orderotherhistory.Awayvn),
				 new MySqlParameter("?Homecn",orderotherhistory.Homecn),
				 new MySqlParameter("?Hometw",orderotherhistory.Hometw),
				 new MySqlParameter("?Homeen",orderotherhistory.Homeen),
				 new MySqlParameter("?Hometh",orderotherhistory.Hometh),
				 new MySqlParameter("?Homevn",orderotherhistory.Homevn),
				 new MySqlParameter("?Handicap",orderotherhistory.Handicap),
				 new MySqlParameter("?OddsType",orderotherhistory.OddsType),
				 new MySqlParameter("?Odds",orderotherhistory.Odds),
				 new MySqlParameter("?Amount",orderotherhistory.Amount),
				 new MySqlParameter("?ValidAmount",orderotherhistory.ValidAmount),
				 new MySqlParameter("?Status",orderotherhistory.Status),
				 new MySqlParameter("?WebSiteiID",orderotherhistory.WebSiteiID),
				 new MySqlParameter("?agent",orderotherhistory.Agent),
				 new MySqlParameter("?websitepossess",orderotherhistory.Websitepossess),
				 new MySqlParameter("?selfpossess",orderotherhistory.Selfpossess),
				 new MySqlParameter("?commission",orderotherhistory.Commission),
				 new MySqlParameter("?multiple",orderotherhistory.Multiple),
				 new MySqlParameter("?gameid",orderotherhistory.Gameid),
				 new MySqlParameter("?betflag",orderotherhistory.Betflag),
				 new MySqlParameter("?Result",orderotherhistory.Result),
				 new MySqlParameter("?Reason",orderotherhistory.Reason),
				 new MySqlParameter("?Scorehalf",orderotherhistory.Scorehalf),
				 new MySqlParameter("?MoreAmount",orderotherhistory.MoreAmount),
				 new MySqlParameter("?ID",orderotherhistory.ID)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-3-19 21:56:52		
        ///</summary>		
        public Boolean DeleteOrderotherhistoryByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2011-3-19 21:56:52		
        ///</summary>		
        public Orderotherhistory GetOrderotherhistoryByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

            return MySqlModelHelper<Orderotherhistory>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2011-3-19 21:56:52		
        ///</summary>		
        public IList<Orderotherhistory> GetMutilILOrderotherhistory()
        {
            return MySqlModelHelper<Orderotherhistory>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2011-3-19 21:56:52		
        ///</summary>		
        public DataTable GetMutilDTOrderotherhistory()
        {
            return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion 

        /// <summary>
        /// 外调输赢网站列表
        /// </summary>
        /// <param name="lan">多语言</param>
        /// <returns></returns>
        public string GetOrderGroupByWebsiteID(string stime,string etime, string lan, string yy, string websiteid, string agent, string webusername)
        {
            stime = stime.Replace("'", "");
            etime = etime.Replace("'", "");
            yy = yy.Replace("'", "");
            string sqlStr = "";
            string subStr = "";
            string subStr1 = "";
            if (!string.IsNullOrEmpty(websiteid))
            {
                subStr1 += " and WebSiteiID=" + websiteid;
            }
            if (!string.IsNullOrEmpty(agent))
            {
                subStr1 += " and agent='" + agent + "' ";
            }
            if (!string.IsNullOrEmpty(webusername))
            {
                subStr1 += " and WebUserName='" + webusername + "' ";
            }
            switch (lan)
            {
                case "zh-cn":
                    subStr = "namecn";
                    break;
                case "zh-tw":
                    subStr = "nametw";
                    break;
                case "en-us":
                    subStr = "nameen";
                    break;
                case "th-th":
                    subStr = "nameth";
                    break;
                case "vi-vn":
                    subStr = "nametv";
                    break;
                default:
                    subStr = "namecn";
                    break;
            }
            if (yy == "WebSiteiID")
            {
                sqlStr = "select (select " + subStr + " from casino where casino.id=orderotherhistory.WebSiteiID) as WebSiteName,WebSiteiID,agent,";
            }
            else
            {
                sqlStr = "select " + yy + " as WebSiteName,WebSiteiID,agent,";
            }
            sqlStr += "sum(Amount) as Amount,sum(ValidAmount) as ValidAmount,sum(Result) as Result,sum(MoreAmount) as MoreAmount ";
            sqlStr += " from orderotherhistory";
            sqlStr += " where BeginTime>='" + stime + "' and BeginTime<='" + etime + " 23:59:59' " + subStr1;
            sqlStr += " group by " + yy + " order by WebSiteiID,agent,WebUserName";

            string val = ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sqlStr));
            return val;
        }

        /// <summary>
        /// 返回外调注单列表，根据网站ID(websiteID)
        /// </summary>
        /// <param name="websiteID">网站ID</param>
        /// <param name="lan">多语言</param>
        /// <returns></returns>
        public string GetOrderByWebsiteID(int websiteID, string agent, string webusername, string stime,string etime, string lan)
        {
            stime = stime.Replace("'", "");
            etime = etime.Replace("'", "");
            string sqlStr = "";
            string subStr = "";
            string site = "";
            switch (lan)
            {
                case "zh-cn":
                    subStr = "leaguecn as league,Awaycn as away,Homecn as home";
                    site = "namecn";
                    break;
                case "zh-tw":
                    subStr = "leaguetw as league,Awaytw as away,Hometw as home";
                    site = "nametw";
                    break;
                case "en-us":
                    subStr = "leagueen as league,Awayen as away,Homeen as home";
                    site = "nameen";
                    break;
                case "th-th":
                    subStr = "leagueth as league,Awayth as away,Hometh as home";
                    site = "nameth";
                    break;
                case "vi-vn":
                    subStr = "leaguevn as Awayvn,Awaycn as away,Homevn as home";
                    site = "nametv";
                    break;
                default:
                    subStr = "leaguecn as league,Awaycn as away,Homecn as home";
                    site = "namecn";
                    break;
            }
            sqlStr += "select WebUserName,UserName,WebOrderID,OrderID,WebSiteiID,time,Status,Scoreathalf,";
            sqlStr += "(select " + site + " from casino where casino.id=orderotherhistory.WebSiteiID) as WebSiteName,";
            sqlStr += "agent,BetItem,Handicap,BetType,";
            sqlStr += subStr + ",";
            sqlStr += "BeginTime,Odds,OddsType,Amount,ValidAmount,Result,Score,Scorehalf,MoreAmount ";
            sqlStr += " from orderotherhistory where WebSiteiID=?WebSiteiID and agent=?agent and webusername=?webusername and BeginTime>='" + stime + "' and BeginTime<='" + etime + " 23:59:59' order by time desc";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?WebSiteiID",websiteID),
                new MySqlParameter("?agent",agent),
                new MySqlParameter("?webusername",webusername)
            };
            string val = ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sqlStr,param));
            return val;
        }

        /// <summary>
        /// 返回记录数
        /// </summary>
        /// <param name="websiteID"></param>
        /// <returns></returns>
        public int GetOrderCountByWebsiteID(int websiteID,string stime,string etime)
        {
            stime = stime.Replace("'", "");
            etime = etime.Replace("'", "");
            string sqlStr = "select count(*) as cot from orderotherhistory where WebSiteiID=?WebSiteiID and BeginTime>='" + stime + "' and BeginTime<='" + etime + " 23:59:59'";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?WebSiteiID",websiteID)
            };
            int val = Convert.ToInt32(MySqlHelper.ExecuteScalar(sqlStr, param));
            return val;
        }

	}
}
