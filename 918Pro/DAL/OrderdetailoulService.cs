using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class OrderdetailoulService
	{
        private const string SQL_INSERT = "insert into yafa.orderdetailoul (UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission)values(?UserName,?OrderID,?time,?leaguecn,?leaguetw,?leagueen,?leagueth,?leaguevn,?Homecn,?Hometw,?Homeen,?Hometh,?Homevn,?Awaycn,?Awaytw,?Awayen,?Awayth,?Awayvn,?BeginTime,?BetType,?IsHalf,?BetItem,?Score,?Handicap,?Odds,?OddsType,?Amount,?ValidAmount,?Status,?Agent,?AgentPercent,?AgentCommission,?ZAgentPercent,?ZAgent,?ZAgentCommission,?PartnerPercent,?PartnerCommission,?Partner,?CompanyPercent,?CompanyCommission,?IP,?SubCompany,?SubCompanyCommission,?SubCompanyPercent,?WebSiteiID,?UserLevel,?Coefficient,?Proportion,?Currency,?Reason,?gameid,?betflag,?MemberPercent,?MemberCommission)";
        private const string SQL_UPDATE = "update yafa.orderdetailoul set UserName=?UserName,OrderID=?OrderID,time=?time,leaguecn=?leaguecn,leaguetw=?leaguetw,leagueen=?leagueen,leagueth=?leagueth,leaguevn=?leaguevn,Homecn=?Homecn,Hometw=?Hometw,Homeen=?Homeen,Hometh=?Hometh,Homevn=?Homevn,Awaycn=?Awaycn,Awaytw=?Awaytw,Awayen=?Awayen,Awayth=?Awayth,Awayvn=?Awayvn,BeginTime=?BeginTime,BetType=?BetType,IsHalf=?IsHalf,BetItem=?BetItem,Score=?Score,Handicap=?Handicap,Odds=?Odds,OddsType=?OddsType,Amount=?Amount,ValidAmount=?ValidAmount,Status=?Status,Agent=?Agent,AgentPercent=?AgentPercent,AgentCommission=?AgentCommission,ZAgentPercent=?ZAgentPercent,ZAgent=?ZAgent,ZAgentCommission=?ZAgentCommission,PartnerPercent=?PartnerPercent,PartnerCommission=?PartnerCommission,Partner=?Partner,CompanyPercent=?CompanyPercent,CompanyCommission=?CompanyCommission,IP=?IP,SubCompany=?SubCompany,SubCompanyCommission=?SubCompanyCommission,SubCompanyPercent=?SubCompanyPercent,WebSiteiID=?WebSiteiID,UserLevel=?UserLevel,Coefficient=?Coefficient,Proportion=?Proportion,Currency=?Currency,Reason=?Reason,gameid=?gameid,betflag=?betflag,MemberPercent=?MemberPercent,MemberCommission=?MemberCommission where ID = ?ID";
        private const string SQL_SELECTBYPK = "select ID from yafa.orderdetailoul  where orderdetailoul.ID = ?ID";
        private const string SQL_SELECTALL = "select ID,UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission from yafa.orderdetailoul ";
        private const string SQL_DELETEBYPK = "delete  from yafa.orderdetailoul  where orderdetailoul.ID = ?ID";

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:25:56		
        ///</summary>		
        public Boolean AddOrderdetailoul(Orderdetailoul orderdetailoul)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetailoul.UserName),
				 new MySqlParameter("?OrderID",orderdetailoul.OrderID),
				 new MySqlParameter("?time",orderdetailoul.Time),
				 new MySqlParameter("?leaguecn",orderdetailoul.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetailoul.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetailoul.Leagueen),
				 new MySqlParameter("?leagueth",orderdetailoul.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetailoul.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetailoul.Homecn),
				 new MySqlParameter("?Hometw",orderdetailoul.Hometw),
				 new MySqlParameter("?Homeen",orderdetailoul.Homeen),
				 new MySqlParameter("?Hometh",orderdetailoul.Hometh),
				 new MySqlParameter("?Homevn",orderdetailoul.Homevn),
				 new MySqlParameter("?Awaycn",orderdetailoul.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetailoul.Awaytw),
				 new MySqlParameter("?Awayen",orderdetailoul.Awayen),
				 new MySqlParameter("?Awayth",orderdetailoul.Awayth),
				 new MySqlParameter("?Awayvn",orderdetailoul.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetailoul.BeginTime),
				 new MySqlParameter("?BetType",orderdetailoul.BetType),
				 new MySqlParameter("?IsHalf",orderdetailoul.IsHalf),
				 new MySqlParameter("?BetItem",orderdetailoul.BetItem),
				 new MySqlParameter("?Score",orderdetailoul.Score),
				 new MySqlParameter("?Handicap",orderdetailoul.Handicap),
				 new MySqlParameter("?Odds",orderdetailoul.Odds),
				 new MySqlParameter("?OddsType",orderdetailoul.OddsType),
				 new MySqlParameter("?Amount",orderdetailoul.Amount),
				 new MySqlParameter("?ValidAmount",orderdetailoul.ValidAmount),
				 new MySqlParameter("?Status",orderdetailoul.Status),
				 new MySqlParameter("?Agent",orderdetailoul.Agent),
				 new MySqlParameter("?AgentPercent",orderdetailoul.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetailoul.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetailoul.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetailoul.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetailoul.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetailoul.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetailoul.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetailoul.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetailoul.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetailoul.CompanyCommission),
				 new MySqlParameter("?IP",orderdetailoul.IP),
				 new MySqlParameter("?SubCompany",orderdetailoul.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetailoul.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetailoul.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetailoul.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetailoul.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetailoul.Coefficient),
				 new MySqlParameter("?Proportion",orderdetailoul.Proportion),
				 new MySqlParameter("?Currency",orderdetailoul.Currency),
				 new MySqlParameter("?Reason",orderdetailoul.Reason),
				 new MySqlParameter("?gameid",orderdetailoul.Gameid),
				 new MySqlParameter("?betflag",orderdetailoul.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetailoul.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetailoul.MemberCommission)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:25:56		
        ///</summary>		
        public Boolean UpdateOrderdetailoul(Orderdetailoul orderdetailoul)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetailoul.UserName),
				 new MySqlParameter("?OrderID",orderdetailoul.OrderID),
				 new MySqlParameter("?time",orderdetailoul.Time),
				 new MySqlParameter("?leaguecn",orderdetailoul.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetailoul.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetailoul.Leagueen),
				 new MySqlParameter("?leagueth",orderdetailoul.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetailoul.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetailoul.Homecn),
				 new MySqlParameter("?Hometw",orderdetailoul.Hometw),
				 new MySqlParameter("?Homeen",orderdetailoul.Homeen),
				 new MySqlParameter("?Hometh",orderdetailoul.Hometh),
				 new MySqlParameter("?Homevn",orderdetailoul.Homevn),
				 new MySqlParameter("?Awaycn",orderdetailoul.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetailoul.Awaytw),
				 new MySqlParameter("?Awayen",orderdetailoul.Awayen),
				 new MySqlParameter("?Awayth",orderdetailoul.Awayth),
				 new MySqlParameter("?Awayvn",orderdetailoul.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetailoul.BeginTime),
				 new MySqlParameter("?BetType",orderdetailoul.BetType),
				 new MySqlParameter("?IsHalf",orderdetailoul.IsHalf),
				 new MySqlParameter("?BetItem",orderdetailoul.BetItem),
				 new MySqlParameter("?Score",orderdetailoul.Score),
				 new MySqlParameter("?Handicap",orderdetailoul.Handicap),
				 new MySqlParameter("?Odds",orderdetailoul.Odds),
				 new MySqlParameter("?OddsType",orderdetailoul.OddsType),
				 new MySqlParameter("?Amount",orderdetailoul.Amount),
				 new MySqlParameter("?ValidAmount",orderdetailoul.ValidAmount),
				 new MySqlParameter("?Status",orderdetailoul.Status),
				 new MySqlParameter("?Agent",orderdetailoul.Agent),
				 new MySqlParameter("?AgentPercent",orderdetailoul.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetailoul.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetailoul.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetailoul.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetailoul.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetailoul.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetailoul.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetailoul.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetailoul.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetailoul.CompanyCommission),
				 new MySqlParameter("?IP",orderdetailoul.IP),
				 new MySqlParameter("?SubCompany",orderdetailoul.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetailoul.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetailoul.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetailoul.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetailoul.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetailoul.Coefficient),
				 new MySqlParameter("?Proportion",orderdetailoul.Proportion),
				 new MySqlParameter("?Currency",orderdetailoul.Currency),
				 new MySqlParameter("?Reason",orderdetailoul.Reason),
				 new MySqlParameter("?gameid",orderdetailoul.Gameid),
				 new MySqlParameter("?betflag",orderdetailoul.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetailoul.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetailoul.MemberCommission),
				 new MySqlParameter("?ID",orderdetailoul.ID)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:25:56		
        ///</summary>		
        public Boolean DeleteOrderdetailoulByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2011-1-21 20:25:56		
        ///</summary>		
        public Orderdetailoul GetOrderdetailoulByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

            return MySqlModelHelper<Orderdetailoul>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2011-1-21 20:25:56		
        ///</summary>		
        public IList<Orderdetailoul> GetMutilILOrderdetailoul()
        {
            return MySqlModelHelper<Orderdetailoul>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2011-1-21 20:25:56		
        ///</summary>		
        public DataTable GetMutilDTOrderdetailoul()
        {
            return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion 
	}
}
