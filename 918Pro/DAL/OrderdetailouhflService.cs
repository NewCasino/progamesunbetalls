using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class OrderdetailouhflService
	{
        private const string SQL_INSERT = "insert into yafa.orderdetailouhfl (UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission)values(?UserName,?OrderID,?time,?leaguecn,?leaguetw,?leagueen,?leagueth,?leaguevn,?Homecn,?Hometw,?Homeen,?Hometh,?Homevn,?Awaycn,?Awaytw,?Awayen,?Awayth,?Awayvn,?BeginTime,?BetType,?IsHalf,?BetItem,?Score,?Handicap,?Odds,?OddsType,?Amount,?ValidAmount,?Status,?Agent,?AgentPercent,?AgentCommission,?ZAgentPercent,?ZAgent,?ZAgentCommission,?PartnerPercent,?PartnerCommission,?Partner,?CompanyPercent,?CompanyCommission,?IP,?SubCompany,?SubCompanyCommission,?SubCompanyPercent,?WebSiteiID,?UserLevel,?Coefficient,?Proportion,?Currency,?Reason,?gameid,?betflag,?MemberPercent,?MemberCommission)";
        private const string SQL_UPDATE = "update yafa.orderdetailouhfl set UserName=?UserName,OrderID=?OrderID,time=?time,leaguecn=?leaguecn,leaguetw=?leaguetw,leagueen=?leagueen,leagueth=?leagueth,leaguevn=?leaguevn,Homecn=?Homecn,Hometw=?Hometw,Homeen=?Homeen,Hometh=?Hometh,Homevn=?Homevn,Awaycn=?Awaycn,Awaytw=?Awaytw,Awayen=?Awayen,Awayth=?Awayth,Awayvn=?Awayvn,BeginTime=?BeginTime,BetType=?BetType,IsHalf=?IsHalf,BetItem=?BetItem,Score=?Score,Handicap=?Handicap,Odds=?Odds,OddsType=?OddsType,Amount=?Amount,ValidAmount=?ValidAmount,Status=?Status,Agent=?Agent,AgentPercent=?AgentPercent,AgentCommission=?AgentCommission,ZAgentPercent=?ZAgentPercent,ZAgent=?ZAgent,ZAgentCommission=?ZAgentCommission,PartnerPercent=?PartnerPercent,PartnerCommission=?PartnerCommission,Partner=?Partner,CompanyPercent=?CompanyPercent,CompanyCommission=?CompanyCommission,IP=?IP,SubCompany=?SubCompany,SubCompanyCommission=?SubCompanyCommission,SubCompanyPercent=?SubCompanyPercent,WebSiteiID=?WebSiteiID,UserLevel=?UserLevel,Coefficient=?Coefficient,Proportion=?Proportion,Currency=?Currency,Reason=?Reason,gameid=?gameid,betflag=?betflag,MemberPercent=?MemberPercent,MemberCommission=?MemberCommission where ID = ?ID";
        private const string SQL_SELECTBYPK = "select ID from yafa.orderdetailouhfl  where orderdetailouhfl.ID = ?ID";
        private const string SQL_SELECTALL = "select ID,UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission from yafa.orderdetailouhfl ";
        private const string SQL_DELETEBYPK = "delete  from yafa.orderdetailouhfl  where orderdetailouhfl.ID = ?ID";

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:24:03		
        ///</summary>		
        public Boolean AddOrderdetailouhfl(Orderdetailouhfl orderdetailouhfl)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetailouhfl.UserName),
				 new MySqlParameter("?OrderID",orderdetailouhfl.OrderID),
				 new MySqlParameter("?time",orderdetailouhfl.Time),
				 new MySqlParameter("?leaguecn",orderdetailouhfl.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetailouhfl.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetailouhfl.Leagueen),
				 new MySqlParameter("?leagueth",orderdetailouhfl.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetailouhfl.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetailouhfl.Homecn),
				 new MySqlParameter("?Hometw",orderdetailouhfl.Hometw),
				 new MySqlParameter("?Homeen",orderdetailouhfl.Homeen),
				 new MySqlParameter("?Hometh",orderdetailouhfl.Hometh),
				 new MySqlParameter("?Homevn",orderdetailouhfl.Homevn),
				 new MySqlParameter("?Awaycn",orderdetailouhfl.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetailouhfl.Awaytw),
				 new MySqlParameter("?Awayen",orderdetailouhfl.Awayen),
				 new MySqlParameter("?Awayth",orderdetailouhfl.Awayth),
				 new MySqlParameter("?Awayvn",orderdetailouhfl.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetailouhfl.BeginTime),
				 new MySqlParameter("?BetType",orderdetailouhfl.BetType),
				 new MySqlParameter("?IsHalf",orderdetailouhfl.IsHalf),
				 new MySqlParameter("?BetItem",orderdetailouhfl.BetItem),
				 new MySqlParameter("?Score",orderdetailouhfl.Score),
				 new MySqlParameter("?Handicap",orderdetailouhfl.Handicap),
				 new MySqlParameter("?Odds",orderdetailouhfl.Odds),
				 new MySqlParameter("?OddsType",orderdetailouhfl.OddsType),
				 new MySqlParameter("?Amount",orderdetailouhfl.Amount),
				 new MySqlParameter("?ValidAmount",orderdetailouhfl.ValidAmount),
				 new MySqlParameter("?Status",orderdetailouhfl.Status),
				 new MySqlParameter("?Agent",orderdetailouhfl.Agent),
				 new MySqlParameter("?AgentPercent",orderdetailouhfl.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetailouhfl.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetailouhfl.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetailouhfl.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetailouhfl.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetailouhfl.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetailouhfl.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetailouhfl.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetailouhfl.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetailouhfl.CompanyCommission),
				 new MySqlParameter("?IP",orderdetailouhfl.IP),
				 new MySqlParameter("?SubCompany",orderdetailouhfl.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetailouhfl.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetailouhfl.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetailouhfl.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetailouhfl.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetailouhfl.Coefficient),
				 new MySqlParameter("?Proportion",orderdetailouhfl.Proportion),
				 new MySqlParameter("?Currency",orderdetailouhfl.Currency),
				 new MySqlParameter("?Reason",orderdetailouhfl.Reason),
				 new MySqlParameter("?gameid",orderdetailouhfl.Gameid),
				 new MySqlParameter("?betflag",orderdetailouhfl.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetailouhfl.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetailouhfl.MemberCommission)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:24:03		
        ///</summary>		
        public Boolean UpdateOrderdetailouhfl(Orderdetailouhfl orderdetailouhfl)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetailouhfl.UserName),
				 new MySqlParameter("?OrderID",orderdetailouhfl.OrderID),
				 new MySqlParameter("?time",orderdetailouhfl.Time),
				 new MySqlParameter("?leaguecn",orderdetailouhfl.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetailouhfl.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetailouhfl.Leagueen),
				 new MySqlParameter("?leagueth",orderdetailouhfl.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetailouhfl.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetailouhfl.Homecn),
				 new MySqlParameter("?Hometw",orderdetailouhfl.Hometw),
				 new MySqlParameter("?Homeen",orderdetailouhfl.Homeen),
				 new MySqlParameter("?Hometh",orderdetailouhfl.Hometh),
				 new MySqlParameter("?Homevn",orderdetailouhfl.Homevn),
				 new MySqlParameter("?Awaycn",orderdetailouhfl.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetailouhfl.Awaytw),
				 new MySqlParameter("?Awayen",orderdetailouhfl.Awayen),
				 new MySqlParameter("?Awayth",orderdetailouhfl.Awayth),
				 new MySqlParameter("?Awayvn",orderdetailouhfl.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetailouhfl.BeginTime),
				 new MySqlParameter("?BetType",orderdetailouhfl.BetType),
				 new MySqlParameter("?IsHalf",orderdetailouhfl.IsHalf),
				 new MySqlParameter("?BetItem",orderdetailouhfl.BetItem),
				 new MySqlParameter("?Score",orderdetailouhfl.Score),
				 new MySqlParameter("?Handicap",orderdetailouhfl.Handicap),
				 new MySqlParameter("?Odds",orderdetailouhfl.Odds),
				 new MySqlParameter("?OddsType",orderdetailouhfl.OddsType),
				 new MySqlParameter("?Amount",orderdetailouhfl.Amount),
				 new MySqlParameter("?ValidAmount",orderdetailouhfl.ValidAmount),
				 new MySqlParameter("?Status",orderdetailouhfl.Status),
				 new MySqlParameter("?Agent",orderdetailouhfl.Agent),
				 new MySqlParameter("?AgentPercent",orderdetailouhfl.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetailouhfl.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetailouhfl.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetailouhfl.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetailouhfl.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetailouhfl.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetailouhfl.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetailouhfl.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetailouhfl.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetailouhfl.CompanyCommission),
				 new MySqlParameter("?IP",orderdetailouhfl.IP),
				 new MySqlParameter("?SubCompany",orderdetailouhfl.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetailouhfl.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetailouhfl.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetailouhfl.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetailouhfl.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetailouhfl.Coefficient),
				 new MySqlParameter("?Proportion",orderdetailouhfl.Proportion),
				 new MySqlParameter("?Currency",orderdetailouhfl.Currency),
				 new MySqlParameter("?Reason",orderdetailouhfl.Reason),
				 new MySqlParameter("?gameid",orderdetailouhfl.Gameid),
				 new MySqlParameter("?betflag",orderdetailouhfl.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetailouhfl.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetailouhfl.MemberCommission),
				 new MySqlParameter("?ID",orderdetailouhfl.ID)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:24:03		
        ///</summary>		
        public Boolean DeleteOrderdetailouhflByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2011-1-21 20:24:03		
        ///</summary>		
        public Orderdetailouhfl GetOrderdetailouhflByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

            return MySqlModelHelper<Orderdetailouhfl>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2011-1-21 20:24:03		
        ///</summary>		
        public IList<Orderdetailouhfl> GetMutilILOrderdetailouhfl()
        {
            return MySqlModelHelper<Orderdetailouhfl>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2011-1-21 20:24:03		
        ///</summary>		
        public DataTable GetMutilDTOrderdetailouhfl()
        {
            return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion 
	}
}
