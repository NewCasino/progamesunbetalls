using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class OrderdetailliveService
	{
        private const string SQL_INSERT = "insert into yafa.orderdetaillive (UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission)values(?UserName,?OrderID,?time,?leaguecn,?leaguetw,?leagueen,?leagueth,?leaguevn,?Homecn,?Hometw,?Homeen,?Hometh,?Homevn,?Awaycn,?Awaytw,?Awayen,?Awayth,?Awayvn,?BeginTime,?BetType,?IsHalf,?BetItem,?Score,?Handicap,?Odds,?OddsType,?Amount,?ValidAmount,?Status,?Agent,?AgentPercent,?AgentCommission,?ZAgentPercent,?ZAgent,?ZAgentCommission,?PartnerPercent,?PartnerCommission,?Partner,?CompanyPercent,?CompanyCommission,?IP,?SubCompany,?SubCompanyCommission,?SubCompanyPercent,?WebSiteiID,?UserLevel,?Coefficient,?Proportion,?Currency,?Reason,?gameid,?betflag,?MemberPercent,?MemberCommission)";
        private const string SQL_UPDATE = "update yafa.orderdetaillive set UserName=?UserName,OrderID=?OrderID,time=?time,leaguecn=?leaguecn,leaguetw=?leaguetw,leagueen=?leagueen,leagueth=?leagueth,leaguevn=?leaguevn,Homecn=?Homecn,Hometw=?Hometw,Homeen=?Homeen,Hometh=?Hometh,Homevn=?Homevn,Awaycn=?Awaycn,Awaytw=?Awaytw,Awayen=?Awayen,Awayth=?Awayth,Awayvn=?Awayvn,BeginTime=?BeginTime,BetType=?BetType,IsHalf=?IsHalf,BetItem=?BetItem,Score=?Score,Handicap=?Handicap,Odds=?Odds,OddsType=?OddsType,Amount=?Amount,ValidAmount=?ValidAmount,Status=?Status,Agent=?Agent,AgentPercent=?AgentPercent,AgentCommission=?AgentCommission,ZAgentPercent=?ZAgentPercent,ZAgent=?ZAgent,ZAgentCommission=?ZAgentCommission,PartnerPercent=?PartnerPercent,PartnerCommission=?PartnerCommission,Partner=?Partner,CompanyPercent=?CompanyPercent,CompanyCommission=?CompanyCommission,IP=?IP,SubCompany=?SubCompany,SubCompanyCommission=?SubCompanyCommission,SubCompanyPercent=?SubCompanyPercent,WebSiteiID=?WebSiteiID,UserLevel=?UserLevel,Coefficient=?Coefficient,Proportion=?Proportion,Currency=?Currency,Reason=?Reason,gameid=?gameid,betflag=?betflag,MemberPercent=?MemberPercent,MemberCommission=?MemberCommission where ID = ?ID";
        private const string SQL_SELECTBYPK = "select * from yafa.orderdetaillive  where orderdetaillive.ID = ?ID";
        //private const string SQL_SELECTALL = "select ID,UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission from yafa.orderdetaillive ";
        private const string SQL_SELECTALL = "select a.ID,a.UserName,a.OrderID,a.`time`,a.leaguecn,a.leaguetw,a.leagueen,a.leagueth,a.leaguevn,a.Homecn,a.Hometw,a.Homeen,a.Hometh,a.Homevn,a.Awaycn,a.Awaytw,a.Awayen,a.Awayth,a.Awayvn,a.BeginTime,a.BetType,a.IsHalf,a.BetItem,a.Score,a.Handicap,a.Odds,a.OddsType,a.Amount,a.ValidAmount,a.Status,a.Agent,a.AgentPercent,a.AgentCommission,a.ZAgentPercent,a.ZAgent,a.ZAgentCommission,a.PartnerPercent,a.PartnerCommission,a.Partner,a.CompanyPercent,a.CompanyCommission,a.IP,a.SubCompany,a.SubCompanyCommission,a.SubCompanyPercent,a.WebSiteiID,a.UserLevel,a.Coefficient,a.Proportion,a.Currency,a.Reason,a.gameid,a.betflag,a.MemberPercent,a.MemberCommission,b.WebOrderID,b.WebUserName from yafa.orderdetaillive as a inner join yafa.orderother as b where a.OrderID = b.OrderID";
        private const string SQL_DELETEBYPK = "delete  from yafa.orderdetaillive  where orderdetaillive.ID = ?ID";

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:22:47		
        ///</summary>		
        public Boolean AddOrderdetaillive(Orderdetaillive orderdetaillive)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetaillive.UserName),
				 new MySqlParameter("?OrderID",orderdetaillive.OrderID),
				 new MySqlParameter("?time",orderdetaillive.Time),
				 new MySqlParameter("?leaguecn",orderdetaillive.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetaillive.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetaillive.Leagueen),
				 new MySqlParameter("?leagueth",orderdetaillive.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetaillive.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetaillive.Homecn),
				 new MySqlParameter("?Hometw",orderdetaillive.Hometw),
				 new MySqlParameter("?Homeen",orderdetaillive.Homeen),
				 new MySqlParameter("?Hometh",orderdetaillive.Hometh),
				 new MySqlParameter("?Homevn",orderdetaillive.Homevn),
				 new MySqlParameter("?Awaycn",orderdetaillive.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetaillive.Awaytw),
				 new MySqlParameter("?Awayen",orderdetaillive.Awayen),
				 new MySqlParameter("?Awayth",orderdetaillive.Awayth),
				 new MySqlParameter("?Awayvn",orderdetaillive.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetaillive.BeginTime),
				 new MySqlParameter("?BetType",orderdetaillive.BetType),
				 new MySqlParameter("?IsHalf",orderdetaillive.IsHalf),
				 new MySqlParameter("?BetItem",orderdetaillive.BetItem),
				 new MySqlParameter("?Score",orderdetaillive.Score),
				 new MySqlParameter("?Handicap",orderdetaillive.Handicap),
				 new MySqlParameter("?Odds",orderdetaillive.Odds),
				 new MySqlParameter("?OddsType",orderdetaillive.OddsType),
				 new MySqlParameter("?Amount",orderdetaillive.Amount),
				 new MySqlParameter("?ValidAmount",orderdetaillive.ValidAmount),
				 new MySqlParameter("?Status",orderdetaillive.Status),
				 new MySqlParameter("?Agent",orderdetaillive.Agent),
				 new MySqlParameter("?AgentPercent",orderdetaillive.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetaillive.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetaillive.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetaillive.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetaillive.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetaillive.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetaillive.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetaillive.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetaillive.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetaillive.CompanyCommission),
				 new MySqlParameter("?IP",orderdetaillive.IP),
				 new MySqlParameter("?SubCompany",orderdetaillive.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetaillive.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetaillive.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetaillive.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetaillive.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetaillive.Coefficient),
				 new MySqlParameter("?Proportion",orderdetaillive.Proportion),
				 new MySqlParameter("?Currency",orderdetaillive.Currency),
				 new MySqlParameter("?Reason",orderdetaillive.Reason),
				 new MySqlParameter("?gameid",orderdetaillive.Gameid),
				 new MySqlParameter("?betflag",orderdetaillive.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetaillive.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetaillive.MemberCommission)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:22:47		
        ///</summary>		
        public Boolean UpdateOrderdetaillive(Orderdetaillive orderdetaillive)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetaillive.UserName),
				 new MySqlParameter("?OrderID",orderdetaillive.OrderID),
				 new MySqlParameter("?time",orderdetaillive.Time),
				 new MySqlParameter("?leaguecn",orderdetaillive.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetaillive.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetaillive.Leagueen),
				 new MySqlParameter("?leagueth",orderdetaillive.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetaillive.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetaillive.Homecn),
				 new MySqlParameter("?Hometw",orderdetaillive.Hometw),
				 new MySqlParameter("?Homeen",orderdetaillive.Homeen),
				 new MySqlParameter("?Hometh",orderdetaillive.Hometh),
				 new MySqlParameter("?Homevn",orderdetaillive.Homevn),
				 new MySqlParameter("?Awaycn",orderdetaillive.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetaillive.Awaytw),
				 new MySqlParameter("?Awayen",orderdetaillive.Awayen),
				 new MySqlParameter("?Awayth",orderdetaillive.Awayth),
				 new MySqlParameter("?Awayvn",orderdetaillive.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetaillive.BeginTime),
				 new MySqlParameter("?BetType",orderdetaillive.BetType),
				 new MySqlParameter("?IsHalf",orderdetaillive.IsHalf),
				 new MySqlParameter("?BetItem",orderdetaillive.BetItem),
				 new MySqlParameter("?Score",orderdetaillive.Score),
				 new MySqlParameter("?Handicap",orderdetaillive.Handicap),
				 new MySqlParameter("?Odds",orderdetaillive.Odds),
				 new MySqlParameter("?OddsType",orderdetaillive.OddsType),
				 new MySqlParameter("?Amount",orderdetaillive.Amount),
				 new MySqlParameter("?ValidAmount",orderdetaillive.ValidAmount),
				 new MySqlParameter("?Status",orderdetaillive.Status),
				 new MySqlParameter("?Agent",orderdetaillive.Agent),
				 new MySqlParameter("?AgentPercent",orderdetaillive.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetaillive.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetaillive.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetaillive.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetaillive.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetaillive.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetaillive.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetaillive.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetaillive.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetaillive.CompanyCommission),
				 new MySqlParameter("?IP",orderdetaillive.IP),
				 new MySqlParameter("?SubCompany",orderdetaillive.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetaillive.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetaillive.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetaillive.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetaillive.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetaillive.Coefficient),
				 new MySqlParameter("?Proportion",orderdetaillive.Proportion),
				 new MySqlParameter("?Currency",orderdetaillive.Currency),
				 new MySqlParameter("?Reason",orderdetaillive.Reason),
				 new MySqlParameter("?gameid",orderdetaillive.Gameid),
				 new MySqlParameter("?betflag",orderdetaillive.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetaillive.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetaillive.MemberCommission),
				 new MySqlParameter("?ID",orderdetaillive.ID)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:22:47		
        ///</summary>		
        public Boolean DeleteOrderdetailliveByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2011-1-21 20:22:47		
        ///</summary>		
        public Orderdetaillive GetOrderdetailliveByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

            return MySqlModelHelper<Orderdetaillive>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2011-1-21 20:22:47		
        ///</summary>		
        public IList<Orderdetaillive> GetMutilILOrderdetaillive()
        {
            return MySqlModelHelper<Orderdetaillive>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2011-1-21 20:22:47		
        ///</summary>		
        public DataTable GetMutilDTOrderdetaillive()
        {
            return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion 
        #region 编写人:李毅
        /// <summary>
        /// 根据需要的数据量查询
        /// </summary>
        /// <param name="length">多少条</param>
        /// <returns></returns>
        public string getAllToLength(string length)
        {
            string str = SQL_SELECTALL + " order by time desc limit 0,@length";
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("@length",int.Parse(length))
            };
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str, param));
        }
        #endregion

        public List<Orderdetaillive> getorderAll(int id)
        {
            List<Orderdetaillive> order = new List<Orderdetaillive>();
            string str = "select * from orderdetaillive where gameid="+id +"";
            MySqlDataReader reder = MySqlHelper.ExecuteReader(str);
            while (reder.Read())
            {
                Orderdetaillive or = new Orderdetaillive();
                or.ID = Convert.ToInt32(reder.GetString("ID"));
                or.Agent = Convert.ToString(reder.GetString("Agent"));
                or.AgentCommission = Convert.ToDecimal(reder.GetString("AgentCommission"));
                or.AgentPercent = Convert.ToDecimal(reder.GetString("AgentPercent"));
                or.Amount = Convert.ToDecimal(reder.GetString("Amount"));
                or.Awaycn = Convert.ToString(reder.GetString("Awaycn"));
                or.Awayen = Convert.ToString(reder.GetString("Awayen"));
                or.Awayth = Convert.ToString(reder.GetString("Awayth"));
                or.Awaytw = Convert.ToString(reder.GetString("Awaytw"));
                or.Awayvn = Convert.ToString(reder.GetString("Awayvn"));
                or.BeginTime = Convert.ToDateTime(reder.GetString("BeginTime"));
                or.BetItem = Convert.ToString(reder.GetString("BetItem"));
                or.BetType = Convert.ToString(reder.GetString("BetType"));
                or.Coefficient = Convert.ToDecimal(reder.GetString("Coefficient"));
                or.CompanyCommission = Convert.ToDecimal(reder.GetString("CompanyCommission"));
                or.CompanyPercent = Convert.ToDecimal(reder.GetString("CompanyPercent"));
                or.Currency = Convert.ToString(reder.GetString("Currency"));
                or.Gameid = Convert.ToInt32(reder.GetString("gameid"));
                or.Handicap = Convert.ToString(reder.GetString("Handicap"));
                or.Homecn = Convert.ToString(reder.GetString("Homecn"));
                or.Homeen = Convert.ToString(reder.GetString("Homeen"));
                or.Hometh = Convert.ToString(reder.GetString("Hometh"));
                or.Hometw = Convert.ToString(reder.GetString("Hometw"));
                or.Homevn = Convert.ToString(reder.GetString("Homevn"));
                or.IP = Convert.ToString(reder.GetString("IP"));
                or.IsHalf = Convert.ToString(reder.GetString("IsHalf"));
                or.Leaguecn = Convert.ToString(reder.GetString("leaguecn"));
                or.Leagueen = Convert.ToString(reder.GetString("leagueen"));
                or.Leagueth = Convert.ToString(reder.GetString("leagueth"));
                or.Leaguetw = Convert.ToString(reder.GetString("leaguetw"));
                or.Leaguevn = Convert.ToString(reder.GetString("leaguevn"));
                or.Odds = Convert.ToDecimal(reder.GetString("Odds"));
                or.OddsType = Convert.ToString(reder.GetString("OddsType"));
                or.OrderID = Convert.ToString(reder.GetString("OrderID"));
                or.Partner = Convert.ToString(reder.GetString("Partner"));
                or.PartnerCommission = Convert.ToDecimal(reder.GetString("PartnerCommission"));
                or.PartnerPercent = Convert.ToDecimal(reder.GetString("PartnerPercent"));
                or.Proportion = Convert.ToDecimal(reder.GetString("Proportion"));
                or.Reason = Convert.ToString(reder.GetString("Reason"));
                or.Score = Convert.ToString(reder.GetString("Score"));
                or.Status = Convert.ToString(reder.GetString("Status"));
                or.SubCompany = Convert.ToString(reder.GetString("SubCompany"));
                or.SubCompanyCommission = Convert.ToDecimal(reder.GetString("SubCompanyCommission"));
                or.SubCompanyPercent = Convert.ToDecimal(reder.GetString("SubCompanyPercent"));
                or.Time = Convert.ToDateTime(reder.GetString("time"));
                or.UserLevel = Convert.ToString(reder.GetString("UserLevel"));
                or.UserName = Convert.ToString(reder.GetString("UserName"));
                or.ValidAmount = Convert.ToDecimal(reder.GetString("ValidAmount"));
                or.WebSiteiID = Convert.ToInt32(reder.GetString("WebSiteiID"));
                or.ZAgent = Convert.ToString(reder.GetString("ZAgent"));
                or.ZAgentCommission = Convert.ToDecimal(reder.GetString("ZAgentCommission"));
                or.ZAgentPercent = Convert.ToDecimal(reder.GetString("ZAgentPercent"));
                or.Betflag = Convert.ToString(reder.GetString("betflag"));
                or.MemberPercent = Convert.ToDecimal(reder.GetString("MemberPercent"));
                or.MemberCommission = Convert.ToDecimal(reder.GetString("MemberCommission"));
                order.Add(or);
            }
            return order;
        }

        public string GetOrderAllByWhere(string isHalf, string webSiteiID, string userName, string orderID, string IP,
            string time1, string time2)
        {
            webSiteiID = webSiteiID.Replace("'", "");
            userName = userName.Replace("'", "");
            orderID = orderID.Replace("'", "");
            IP = IP.Replace("'", "");
            time1 = time1.Replace("'", "");
            time2 = time2.Replace("'", "");

            string sql = "";
            string subSql = " 1=1 ";
            if (!string.IsNullOrEmpty(isHalf))
            {
                subSql += " and isHalf in(" + isHalf + ") ";
            }
            if (!string.IsNullOrEmpty(webSiteiID))
            {
                subSql += " and webSiteiID in(" + webSiteiID + ") ";
            }
            if (!string.IsNullOrEmpty(userName))
            {
                subSql += " and userName='" + userName + "' ";
            }
            if (!string.IsNullOrEmpty(orderID))
            {
                subSql += " and orderID='" + orderID + "' ";
            }
            if (!string.IsNullOrEmpty(IP))
            {
                subSql += " and IP='" + IP + "' ";
            }
            if (!(string.IsNullOrEmpty(time1) || string.IsNullOrEmpty(time2)))
            {
                subSql += " and `time`>='" + time1 + "' and `time`<='" + time2 + "' ";
            }

            if (subSql == " 1=1 ")
            {
                return "";
            }
            sql = "select * from orderall2 where " + subSql + " order by `time` desc";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sql));

        }

        public List<Orderdetaillive> GetOrderAllByWhere(string whereSql)
        {
            List<Orderdetaillive> order = new List<Orderdetaillive>();
            if (whereSql == "")
            {
                return order;
            }
            string str = "select * from orderdetaillive where " + whereSql;
            MySqlDataReader reder = MySqlHelper.ExecuteReader(str);
            while (reder.Read())
            {
                Orderdetaillive or = new Orderdetaillive();
                or.ID = Convert.ToInt32(reder.GetString("ID"));
                or.Agent = Convert.ToString(reder.GetString("Agent"));
                or.AgentCommission = Convert.ToDecimal(reder.GetString("AgentCommission"));
                or.AgentPercent = Convert.ToDecimal(reder.GetString("AgentPercent"));
                or.Amount = Convert.ToDecimal(reder.GetString("Amount"));
                or.Awaycn = Convert.ToString(reder.GetString("Awaycn"));
                or.Awayen = Convert.ToString(reder.GetString("Awayen"));
                or.Awayth = Convert.ToString(reder.GetString("Awayth"));
                or.Awaytw = Convert.ToString(reder.GetString("Awaytw"));
                or.Awayvn = Convert.ToString(reder.GetString("Awayvn"));
                or.BeginTime = Convert.ToDateTime(reder.GetString("BeginTime"));
                or.BetItem = Convert.ToString(reder.GetString("BetItem"));
                or.BetType = Convert.ToString(reder.GetString("BetType"));
                or.Coefficient = Convert.ToDecimal(reder.GetString("Coefficient"));
                or.CompanyCommission = Convert.ToDecimal(reder.GetString("CompanyCommission"));
                or.CompanyPercent = Convert.ToDecimal(reder.GetString("CompanyPercent"));
                or.Currency = Convert.ToString(reder.GetString("Currency"));
                or.Gameid = Convert.ToInt32(reder.GetString("gameid"));
                or.Handicap = Convert.ToString(reder.GetString("Handicap"));
                or.Homecn = Convert.ToString(reder.GetString("Homecn"));
                or.Homeen = Convert.ToString(reder.GetString("Homeen"));
                or.Hometh = Convert.ToString(reder.GetString("Hometh"));
                or.Hometw = Convert.ToString(reder.GetString("Hometw"));
                or.Homevn = Convert.ToString(reder.GetString("Homevn"));
                or.IP = Convert.ToString(reder.GetString("IP"));
                or.IsHalf = Convert.ToString(reder.GetString("IsHalf"));
                or.Leaguecn = Convert.ToString(reder.GetString("leaguecn"));
                or.Leagueen = Convert.ToString(reder.GetString("leagueen"));
                or.Leagueth = Convert.ToString(reder.GetString("leagueth"));
                or.Leaguetw = Convert.ToString(reder.GetString("leaguetw"));
                or.Leaguevn = Convert.ToString(reder.GetString("leaguevn"));
                or.Odds = Convert.ToDecimal(reder.GetString("Odds"));
                or.OddsType = Convert.ToString(reder.GetString("OddsType"));
                or.OrderID = Convert.ToString(reder.GetString("OrderID"));
                or.Partner = Convert.ToString(reder.GetString("Partner"));
                or.PartnerCommission = Convert.ToDecimal(reder.GetString("PartnerCommission"));
                or.PartnerPercent = Convert.ToDecimal(reder.GetString("PartnerPercent"));
                or.Proportion = Convert.ToDecimal(reder.GetString("Proportion"));
                or.Reason = Convert.ToString(reder.GetString("Reason"));
                or.Score = Convert.ToString(reder.GetString("Score"));
                or.Status = Convert.ToString(reder.GetString("Status"));
                or.SubCompany = Convert.ToString(reder.GetString("SubCompany"));
                or.SubCompanyCommission = Convert.ToDecimal(reder.GetString("SubCompanyCommission"));
                or.SubCompanyPercent = Convert.ToDecimal(reder.GetString("SubCompanyPercent"));
                or.Time = Convert.ToDateTime(reder.GetString("time"));
                or.UserLevel = Convert.ToString(reder.GetString("UserLevel"));
                or.UserName = Convert.ToString(reder.GetString("UserName"));
                or.ValidAmount = Convert.ToDecimal(reder.GetString("ValidAmount"));
                or.WebSiteiID = Convert.ToInt32(reder.GetString("WebSiteiID"));
                or.ZAgent = Convert.ToString(reder.GetString("ZAgent"));
                or.ZAgentCommission = Convert.ToDecimal(reder.GetString("ZAgentCommission"));
                or.ZAgentPercent = Convert.ToDecimal(reder.GetString("ZAgentPercent"));
                or.Betflag = Convert.ToString(reder.GetString("betflag"));
                or.MemberPercent = Convert.ToDecimal(reder.GetString("MemberPercent"));
                or.MemberCommission = Convert.ToDecimal(reder.GetString("MemberCommission"));
                order.Add(or);
            }
            return order;
        }
    }
}
