using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class Orderdetail1x2Service
	{
        private const string SQL_INSERT = "insert into yafa.orderdetail1x2 (UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission)values(?UserName,?OrderID,?time,?leaguecn,?leaguetw,?leagueen,?leagueth,?leaguevn,?Homecn,?Hometw,?Homeen,?Hometh,?Homevn,?Awaycn,?Awaytw,?Awayen,?Awayth,?Awayvn,?BeginTime,?BetType,?IsHalf,?BetItem,?Score,?Handicap,?Odds,?OddsType,?Amount,?ValidAmount,?Status,?Agent,?AgentPercent,?AgentCommission,?ZAgentPercent,?ZAgent,?ZAgentCommission,?PartnerPercent,?PartnerCommission,?Partner,?CompanyPercent,?CompanyCommission,?IP,?SubCompany,?SubCompanyCommission,?SubCompanyPercent,?WebSiteiID,?UserLevel,?Coefficient,?Proportion,?Currency,?Reason,?gameid,?betflag,?MemberPercent,?MemberCommission)";
        private const string SQL_UPDATE = "update yafa.orderdetail1x2 set UserName=?UserName,OrderID=?OrderID,time=?time,leaguecn=?leaguecn,leaguetw=?leaguetw,leagueen=?leagueen,leagueth=?leagueth,leaguevn=?leaguevn,Homecn=?Homecn,Hometw=?Hometw,Homeen=?Homeen,Hometh=?Hometh,Homevn=?Homevn,Awaycn=?Awaycn,Awaytw=?Awaytw,Awayen=?Awayen,Awayth=?Awayth,Awayvn=?Awayvn,BeginTime=?BeginTime,BetType=?BetType,IsHalf=?IsHalf,BetItem=?BetItem,Score=?Score,Handicap=?Handicap,Odds=?Odds,OddsType=?OddsType,Amount=?Amount,ValidAmount=?ValidAmount,Status=?Status,Agent=?Agent,AgentPercent=?AgentPercent,AgentCommission=?AgentCommission,ZAgentPercent=?ZAgentPercent,ZAgent=?ZAgent,ZAgentCommission=?ZAgentCommission,PartnerPercent=?PartnerPercent,PartnerCommission=?PartnerCommission,Partner=?Partner,CompanyPercent=?CompanyPercent,CompanyCommission=?CompanyCommission,IP=?IP,SubCompany=?SubCompany,SubCompanyCommission=?SubCompanyCommission,SubCompanyPercent=?SubCompanyPercent,WebSiteiID=?WebSiteiID,UserLevel=?UserLevel,Coefficient=?Coefficient,Proportion=?Proportion,Currency=?Currency,Reason=?Reason,gameid=?gameid,betflag=?betflag,MemberPercent=?MemberPercent,MemberCommission=?MemberCommission where ID = ?ID";
        private const string SQL_SELECTBYPK = "select ID from yafa.orderdetail1x2  where orderdetail1x2.ID = ?ID";
        private const string SQL_SELECTALL = "select ID,UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission from yafa.orderdetail1x2 ";
        private const string SQL_DELETEBYPK = "delete  from yafa.orderdetail1x2  where orderdetail1x2.ID = ?ID";

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:17:30		
        ///</summary>		
        public Boolean AddOrderdetail1x2(Orderdetail1x2 orderdetail1x2)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetail1x2.UserName),
				 new MySqlParameter("?OrderID",orderdetail1x2.OrderID),
				 new MySqlParameter("?time",orderdetail1x2.Time),
				 new MySqlParameter("?leaguecn",orderdetail1x2.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetail1x2.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetail1x2.Leagueen),
				 new MySqlParameter("?leagueth",orderdetail1x2.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetail1x2.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetail1x2.Homecn),
				 new MySqlParameter("?Hometw",orderdetail1x2.Hometw),
				 new MySqlParameter("?Homeen",orderdetail1x2.Homeen),
				 new MySqlParameter("?Hometh",orderdetail1x2.Hometh),
				 new MySqlParameter("?Homevn",orderdetail1x2.Homevn),
				 new MySqlParameter("?Awaycn",orderdetail1x2.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetail1x2.Awaytw),
				 new MySqlParameter("?Awayen",orderdetail1x2.Awayen),
				 new MySqlParameter("?Awayth",orderdetail1x2.Awayth),
				 new MySqlParameter("?Awayvn",orderdetail1x2.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetail1x2.BeginTime),
				 new MySqlParameter("?BetType",orderdetail1x2.BetType),
				 new MySqlParameter("?IsHalf",orderdetail1x2.IsHalf),
				 new MySqlParameter("?BetItem",orderdetail1x2.BetItem),
				 new MySqlParameter("?Score",orderdetail1x2.Score),
				 new MySqlParameter("?Handicap",orderdetail1x2.Handicap),
				 new MySqlParameter("?Odds",orderdetail1x2.Odds),
				 new MySqlParameter("?OddsType",orderdetail1x2.OddsType),
				 new MySqlParameter("?Amount",orderdetail1x2.Amount),
				 new MySqlParameter("?ValidAmount",orderdetail1x2.ValidAmount),
				 new MySqlParameter("?Status",orderdetail1x2.Status),
				 new MySqlParameter("?Agent",orderdetail1x2.Agent),
				 new MySqlParameter("?AgentPercent",orderdetail1x2.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetail1x2.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetail1x2.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetail1x2.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetail1x2.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetail1x2.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetail1x2.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetail1x2.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetail1x2.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetail1x2.CompanyCommission),
				 new MySqlParameter("?IP",orderdetail1x2.IP),
				 new MySqlParameter("?SubCompany",orderdetail1x2.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetail1x2.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetail1x2.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetail1x2.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetail1x2.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetail1x2.Coefficient),
				 new MySqlParameter("?Proportion",orderdetail1x2.Proportion),
				 new MySqlParameter("?Currency",orderdetail1x2.Currency),
				 new MySqlParameter("?Reason",orderdetail1x2.Reason),
				 new MySqlParameter("?gameid",orderdetail1x2.Gameid),
				 new MySqlParameter("?betflag",orderdetail1x2.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetail1x2.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetail1x2.MemberCommission)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:17:30		
        ///</summary>		
        public Boolean UpdateOrderdetail1x2(Orderdetail1x2 orderdetail1x2)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetail1x2.UserName),
				 new MySqlParameter("?OrderID",orderdetail1x2.OrderID),
				 new MySqlParameter("?time",orderdetail1x2.Time),
				 new MySqlParameter("?leaguecn",orderdetail1x2.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetail1x2.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetail1x2.Leagueen),
				 new MySqlParameter("?leagueth",orderdetail1x2.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetail1x2.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetail1x2.Homecn),
				 new MySqlParameter("?Hometw",orderdetail1x2.Hometw),
				 new MySqlParameter("?Homeen",orderdetail1x2.Homeen),
				 new MySqlParameter("?Hometh",orderdetail1x2.Hometh),
				 new MySqlParameter("?Homevn",orderdetail1x2.Homevn),
				 new MySqlParameter("?Awaycn",orderdetail1x2.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetail1x2.Awaytw),
				 new MySqlParameter("?Awayen",orderdetail1x2.Awayen),
				 new MySqlParameter("?Awayth",orderdetail1x2.Awayth),
				 new MySqlParameter("?Awayvn",orderdetail1x2.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetail1x2.BeginTime),
				 new MySqlParameter("?BetType",orderdetail1x2.BetType),
				 new MySqlParameter("?IsHalf",orderdetail1x2.IsHalf),
				 new MySqlParameter("?BetItem",orderdetail1x2.BetItem),
				 new MySqlParameter("?Score",orderdetail1x2.Score),
				 new MySqlParameter("?Handicap",orderdetail1x2.Handicap),
				 new MySqlParameter("?Odds",orderdetail1x2.Odds),
				 new MySqlParameter("?OddsType",orderdetail1x2.OddsType),
				 new MySqlParameter("?Amount",orderdetail1x2.Amount),
				 new MySqlParameter("?ValidAmount",orderdetail1x2.ValidAmount),
				 new MySqlParameter("?Status",orderdetail1x2.Status),
				 new MySqlParameter("?Agent",orderdetail1x2.Agent),
				 new MySqlParameter("?AgentPercent",orderdetail1x2.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetail1x2.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetail1x2.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetail1x2.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetail1x2.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetail1x2.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetail1x2.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetail1x2.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetail1x2.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetail1x2.CompanyCommission),
				 new MySqlParameter("?IP",orderdetail1x2.IP),
				 new MySqlParameter("?SubCompany",orderdetail1x2.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetail1x2.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetail1x2.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetail1x2.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetail1x2.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetail1x2.Coefficient),
				 new MySqlParameter("?Proportion",orderdetail1x2.Proportion),
				 new MySqlParameter("?Currency",orderdetail1x2.Currency),
				 new MySqlParameter("?Reason",orderdetail1x2.Reason),
				 new MySqlParameter("?gameid",orderdetail1x2.Gameid),
				 new MySqlParameter("?betflag",orderdetail1x2.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetail1x2.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetail1x2.MemberCommission),
				 new MySqlParameter("?ID",orderdetail1x2.ID)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:17:30		
        ///</summary>		
        public Boolean DeleteOrderdetail1x2ByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2011-1-21 20:17:30		
        ///</summary>		
        public Orderdetail1x2 GetOrderdetail1x2ByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

            return MySqlModelHelper<Orderdetail1x2>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2011-1-21 20:17:30		
        ///</summary>		
        public IList<Orderdetail1x2> GetMutilILOrderdetail1x2()
        {
            return MySqlModelHelper<Orderdetail1x2>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2011-1-21 20:17:30		
        ///</summary>		
        public DataTable GetMutilDTOrderdetail1x2()
        {
            return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion 
        #region 编写人:李毅
        public List<Orderdetail1x2> getorderAll(int id)
        { 
            List<Orderdetail1x2> order = new List<Orderdetail1x2>();
            string str = "select * from orderall_v where gameid="+id +"";
            MySqlDataReader reder = MySqlHelper.ExecuteReader(str);
            while (reder.Read())
            {
                Orderdetail1x2 or = new Orderdetail1x2();
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
                or.Rate = Convert.ToDecimal(reder.GetString("rate"));
                order.Add(or);
            }
            return order;
        }

        public List<Orderdetail1x2> getEscAll(int id)
        {
            List<Orderdetail1x2> order = new List<Orderdetail1x2>();
            string str = "select * from orderall_v where gameid=" + id + " and Status=0";
            MySqlDataReader reder = MySqlHelper.ExecuteReader(str);
            while (reder.Read())
            {
                Orderdetail1x2 or = new Orderdetail1x2();
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
        #endregion

        public List<Orderdetail1x2> getOrderAllByWhere(string whereSql)
        {
            List<Orderdetail1x2> order = new List<Orderdetail1x2>();
            if(whereSql == "")
            {
                return order;
            }
            string str = "select * from orderall_v where " + whereSql;
            MySqlDataReader reder = MySqlHelper.ExecuteReader(str);
            while (reder.Read())
            {
                Orderdetail1x2 or = new Orderdetail1x2();
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
                or.Rate = Convert.ToDecimal(reder.GetString("rate"));
                order.Add(or);
            }
            return order;
        }

    }
}
