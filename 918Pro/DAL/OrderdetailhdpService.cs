using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class OrderdetailhdpService
	{
        private const string SQL_INSERT = "insert into yafa.orderdetailhdp (UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission)values(?UserName,?OrderID,?time,?leaguecn,?leaguetw,?leagueen,?leagueth,?leaguevn,?Homecn,?Hometw,?Homeen,?Hometh,?Homevn,?Awaycn,?Awaytw,?Awayen,?Awayth,?Awayvn,?BeginTime,?BetType,?IsHalf,?BetItem,?Score,?Handicap,?Odds,?OddsType,?Amount,?ValidAmount,?Status,?Agent,?AgentPercent,?AgentCommission,?ZAgentPercent,?ZAgent,?ZAgentCommission,?PartnerPercent,?PartnerCommission,?Partner,?CompanyPercent,?CompanyCommission,?IP,?SubCompany,?SubCompanyCommission,?SubCompanyPercent,?WebSiteiID,?UserLevel,?Coefficient,?Proportion,?Currency,?Reason,?gameid,?betflag,?MemberPercent,?MemberCommission)";
        private const string SQL_UPDATE = "update yafa.orderdetailhdp set UserName=?UserName,OrderID=?OrderID,time=?time,leaguecn=?leaguecn,leaguetw=?leaguetw,leagueen=?leagueen,leagueth=?leagueth,leaguevn=?leaguevn,Homecn=?Homecn,Hometw=?Hometw,Homeen=?Homeen,Hometh=?Hometh,Homevn=?Homevn,Awaycn=?Awaycn,Awaytw=?Awaytw,Awayen=?Awayen,Awayth=?Awayth,Awayvn=?Awayvn,BeginTime=?BeginTime,BetType=?BetType,IsHalf=?IsHalf,BetItem=?BetItem,Score=?Score,Handicap=?Handicap,Odds=?Odds,OddsType=?OddsType,Amount=?Amount,ValidAmount=?ValidAmount,Status=?Status,Agent=?Agent,AgentPercent=?AgentPercent,AgentCommission=?AgentCommission,ZAgentPercent=?ZAgentPercent,ZAgent=?ZAgent,ZAgentCommission=?ZAgentCommission,PartnerPercent=?PartnerPercent,PartnerCommission=?PartnerCommission,Partner=?Partner,CompanyPercent=?CompanyPercent,CompanyCommission=?CompanyCommission,IP=?IP,SubCompany=?SubCompany,SubCompanyCommission=?SubCompanyCommission,SubCompanyPercent=?SubCompanyPercent,WebSiteiID=?WebSiteiID,UserLevel=?UserLevel,Coefficient=?Coefficient,Proportion=?Proportion,Currency=?Currency,Reason=?Reason,gameid=?gameid,betflag=?betflag,MemberPercent=?MemberPercent,MemberCommission=?MemberCommission where ID = ?ID";
        private const string SQL_SELECTBYPK = "select ID from yafa.orderdetailhdp  where orderdetailhdp.ID = ?ID";
        private const string SQL_SELECTALL = "select ID,UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission from yafa.orderdetailhdp ";
        private const string SQL_DELETEBYPK = "delete  from yafa.orderdetailhdp  where orderdetailhdp.ID = ?ID";

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:21:44		
        ///</summary>		
        public Boolean AddOrderdetailhdp(Orderdetailhdp orderdetailhdp)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetailhdp.UserName),
				 new MySqlParameter("?OrderID",orderdetailhdp.OrderID),
				 new MySqlParameter("?time",orderdetailhdp.Time),
				 new MySqlParameter("?leaguecn",orderdetailhdp.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetailhdp.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetailhdp.Leagueen),
				 new MySqlParameter("?leagueth",orderdetailhdp.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetailhdp.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetailhdp.Homecn),
				 new MySqlParameter("?Hometw",orderdetailhdp.Hometw),
				 new MySqlParameter("?Homeen",orderdetailhdp.Homeen),
				 new MySqlParameter("?Hometh",orderdetailhdp.Hometh),
				 new MySqlParameter("?Homevn",orderdetailhdp.Homevn),
				 new MySqlParameter("?Awaycn",orderdetailhdp.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetailhdp.Awaytw),
				 new MySqlParameter("?Awayen",orderdetailhdp.Awayen),
				 new MySqlParameter("?Awayth",orderdetailhdp.Awayth),
				 new MySqlParameter("?Awayvn",orderdetailhdp.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetailhdp.BeginTime),
				 new MySqlParameter("?BetType",orderdetailhdp.BetType),
				 new MySqlParameter("?IsHalf",orderdetailhdp.IsHalf),
				 new MySqlParameter("?BetItem",orderdetailhdp.BetItem),
				 new MySqlParameter("?Score",orderdetailhdp.Score),
				 new MySqlParameter("?Handicap",orderdetailhdp.Handicap),
				 new MySqlParameter("?Odds",orderdetailhdp.Odds),
				 new MySqlParameter("?OddsType",orderdetailhdp.OddsType),
				 new MySqlParameter("?Amount",orderdetailhdp.Amount),
				 new MySqlParameter("?ValidAmount",orderdetailhdp.ValidAmount),
				 new MySqlParameter("?Status",orderdetailhdp.Status),
				 new MySqlParameter("?Agent",orderdetailhdp.Agent),
				 new MySqlParameter("?AgentPercent",orderdetailhdp.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetailhdp.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetailhdp.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetailhdp.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetailhdp.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetailhdp.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetailhdp.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetailhdp.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetailhdp.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetailhdp.CompanyCommission),
				 new MySqlParameter("?IP",orderdetailhdp.IP),
				 new MySqlParameter("?SubCompany",orderdetailhdp.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetailhdp.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetailhdp.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetailhdp.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetailhdp.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetailhdp.Coefficient),
				 new MySqlParameter("?Proportion",orderdetailhdp.Proportion),
				 new MySqlParameter("?Currency",orderdetailhdp.Currency),
				 new MySqlParameter("?Reason",orderdetailhdp.Reason),
				 new MySqlParameter("?gameid",orderdetailhdp.Gameid),
				 new MySqlParameter("?betflag",orderdetailhdp.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetailhdp.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetailhdp.MemberCommission)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:21:44		
        ///</summary>		
        public Boolean UpdateOrderdetailhdp(Orderdetailhdp orderdetailhdp)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetailhdp.UserName),
				 new MySqlParameter("?OrderID",orderdetailhdp.OrderID),
				 new MySqlParameter("?time",orderdetailhdp.Time),
				 new MySqlParameter("?leaguecn",orderdetailhdp.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetailhdp.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetailhdp.Leagueen),
				 new MySqlParameter("?leagueth",orderdetailhdp.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetailhdp.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetailhdp.Homecn),
				 new MySqlParameter("?Hometw",orderdetailhdp.Hometw),
				 new MySqlParameter("?Homeen",orderdetailhdp.Homeen),
				 new MySqlParameter("?Hometh",orderdetailhdp.Hometh),
				 new MySqlParameter("?Homevn",orderdetailhdp.Homevn),
				 new MySqlParameter("?Awaycn",orderdetailhdp.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetailhdp.Awaytw),
				 new MySqlParameter("?Awayen",orderdetailhdp.Awayen),
				 new MySqlParameter("?Awayth",orderdetailhdp.Awayth),
				 new MySqlParameter("?Awayvn",orderdetailhdp.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetailhdp.BeginTime),
				 new MySqlParameter("?BetType",orderdetailhdp.BetType),
				 new MySqlParameter("?IsHalf",orderdetailhdp.IsHalf),
				 new MySqlParameter("?BetItem",orderdetailhdp.BetItem),
				 new MySqlParameter("?Score",orderdetailhdp.Score),
				 new MySqlParameter("?Handicap",orderdetailhdp.Handicap),
				 new MySqlParameter("?Odds",orderdetailhdp.Odds),
				 new MySqlParameter("?OddsType",orderdetailhdp.OddsType),
				 new MySqlParameter("?Amount",orderdetailhdp.Amount),
				 new MySqlParameter("?ValidAmount",orderdetailhdp.ValidAmount),
				 new MySqlParameter("?Status",orderdetailhdp.Status),
				 new MySqlParameter("?Agent",orderdetailhdp.Agent),
				 new MySqlParameter("?AgentPercent",orderdetailhdp.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetailhdp.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetailhdp.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetailhdp.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetailhdp.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetailhdp.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetailhdp.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetailhdp.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetailhdp.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetailhdp.CompanyCommission),
				 new MySqlParameter("?IP",orderdetailhdp.IP),
				 new MySqlParameter("?SubCompany",orderdetailhdp.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetailhdp.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetailhdp.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetailhdp.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetailhdp.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetailhdp.Coefficient),
				 new MySqlParameter("?Proportion",orderdetailhdp.Proportion),
				 new MySqlParameter("?Currency",orderdetailhdp.Currency),
				 new MySqlParameter("?Reason",orderdetailhdp.Reason),
				 new MySqlParameter("?gameid",orderdetailhdp.Gameid),
				 new MySqlParameter("?betflag",orderdetailhdp.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetailhdp.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetailhdp.MemberCommission),
				 new MySqlParameter("?ID",orderdetailhdp.ID)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:21:44		
        ///</summary>		
        public Boolean DeleteOrderdetailhdpByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2011-1-21 20:21:44		
        ///</summary>		
        public Orderdetailhdp GetOrderdetailhdpByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

            return MySqlModelHelper<Orderdetailhdp>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2011-1-21 20:21:44		
        ///</summary>		
        public IList<Orderdetailhdp> GetMutilILOrderdetailhdp()
        {
            return MySqlModelHelper<Orderdetailhdp>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2011-1-21 20:21:44		
        ///</summary>		
        public DataTable GetMutilDTOrderdetailhdp()
        {
            return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion 
	}
}
