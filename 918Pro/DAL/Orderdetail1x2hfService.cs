using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class Orderdetail1x2hfService
	{
        private const string SQL_INSERT = "insert into yafa.orderdetail1x2hf (UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission)values(?UserName,?OrderID,?time,?leaguecn,?leaguetw,?leagueen,?leagueth,?leaguevn,?Homecn,?Hometw,?Homeen,?Hometh,?Homevn,?Awaycn,?Awaytw,?Awayen,?Awayth,?Awayvn,?BeginTime,?BetType,?IsHalf,?BetItem,?Score,?Handicap,?Odds,?OddsType,?Amount,?ValidAmount,?Status,?Agent,?AgentPercent,?AgentCommission,?ZAgentPercent,?ZAgent,?ZAgentCommission,?PartnerPercent,?PartnerCommission,?Partner,?CompanyPercent,?CompanyCommission,?IP,?SubCompany,?SubCompanyCommission,?SubCompanyPercent,?WebSiteiID,?UserLevel,?Coefficient,?Proportion,?Currency,?Reason,?gameid,?betflag,?MemberPercent,?MemberCommission)";
        private const string SQL_UPDATE = "update yafa.orderdetail1x2hf set UserName=?UserName,OrderID=?OrderID,time=?time,leaguecn=?leaguecn,leaguetw=?leaguetw,leagueen=?leagueen,leagueth=?leagueth,leaguevn=?leaguevn,Homecn=?Homecn,Hometw=?Hometw,Homeen=?Homeen,Hometh=?Hometh,Homevn=?Homevn,Awaycn=?Awaycn,Awaytw=?Awaytw,Awayen=?Awayen,Awayth=?Awayth,Awayvn=?Awayvn,BeginTime=?BeginTime,BetType=?BetType,IsHalf=?IsHalf,BetItem=?BetItem,Score=?Score,Handicap=?Handicap,Odds=?Odds,OddsType=?OddsType,Amount=?Amount,ValidAmount=?ValidAmount,Status=?Status,Agent=?Agent,AgentPercent=?AgentPercent,AgentCommission=?AgentCommission,ZAgentPercent=?ZAgentPercent,ZAgent=?ZAgent,ZAgentCommission=?ZAgentCommission,PartnerPercent=?PartnerPercent,PartnerCommission=?PartnerCommission,Partner=?Partner,CompanyPercent=?CompanyPercent,CompanyCommission=?CompanyCommission,IP=?IP,SubCompany=?SubCompany,SubCompanyCommission=?SubCompanyCommission,SubCompanyPercent=?SubCompanyPercent,WebSiteiID=?WebSiteiID,UserLevel=?UserLevel,Coefficient=?Coefficient,Proportion=?Proportion,Currency=?Currency,Reason=?Reason,gameid=?gameid,betflag=?betflag,MemberPercent=?MemberPercent,MemberCommission=?MemberCommission where ID = ?ID";
        private const string SQL_SELECTBYPK = "select ID from yafa.orderdetail1x2hf  where orderdetail1x2hf.ID = ?ID";
        private const string SQL_SELECTALL = "select ID,UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission from yafa.orderdetail1x2hf ";
        private const string SQL_DELETEBYPK = "delete  from yafa.orderdetail1x2hf  where orderdetail1x2hf.ID = ?ID";
		
#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-1-21 20:15:32		
		///</summary>		
		public Boolean AddOrderdetail1x2hf(Orderdetail1x2hf orderdetail1x2hf)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetail1x2hf.UserName),
				 new MySqlParameter("?OrderID",orderdetail1x2hf.OrderID),
				 new MySqlParameter("?time",orderdetail1x2hf.Time),
				 new MySqlParameter("?leaguecn",orderdetail1x2hf.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetail1x2hf.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetail1x2hf.Leagueen),
				 new MySqlParameter("?leagueth",orderdetail1x2hf.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetail1x2hf.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetail1x2hf.Homecn),
				 new MySqlParameter("?Hometw",orderdetail1x2hf.Hometw),
				 new MySqlParameter("?Homeen",orderdetail1x2hf.Homeen),
				 new MySqlParameter("?Hometh",orderdetail1x2hf.Hometh),
				 new MySqlParameter("?Homevn",orderdetail1x2hf.Homevn),
				 new MySqlParameter("?Awaycn",orderdetail1x2hf.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetail1x2hf.Awaytw),
				 new MySqlParameter("?Awayen",orderdetail1x2hf.Awayen),
				 new MySqlParameter("?Awayth",orderdetail1x2hf.Awayth),
				 new MySqlParameter("?Awayvn",orderdetail1x2hf.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetail1x2hf.BeginTime),
				 new MySqlParameter("?BetType",orderdetail1x2hf.BetType),
				 new MySqlParameter("?IsHalf",orderdetail1x2hf.IsHalf),
				 new MySqlParameter("?BetItem",orderdetail1x2hf.BetItem),
				 new MySqlParameter("?Score",orderdetail1x2hf.Score),
				 new MySqlParameter("?Handicap",orderdetail1x2hf.Handicap),
				 new MySqlParameter("?Odds",orderdetail1x2hf.Odds),
				 new MySqlParameter("?OddsType",orderdetail1x2hf.OddsType),
				 new MySqlParameter("?Amount",orderdetail1x2hf.Amount),
				 new MySqlParameter("?ValidAmount",orderdetail1x2hf.ValidAmount),
				 new MySqlParameter("?Status",orderdetail1x2hf.Status),
				 new MySqlParameter("?Agent",orderdetail1x2hf.Agent),
				 new MySqlParameter("?AgentPercent",orderdetail1x2hf.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetail1x2hf.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetail1x2hf.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetail1x2hf.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetail1x2hf.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetail1x2hf.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetail1x2hf.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetail1x2hf.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetail1x2hf.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetail1x2hf.CompanyCommission),
				 new MySqlParameter("?IP",orderdetail1x2hf.IP),
				 new MySqlParameter("?SubCompany",orderdetail1x2hf.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetail1x2hf.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetail1x2hf.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetail1x2hf.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetail1x2hf.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetail1x2hf.Coefficient),
				 new MySqlParameter("?Proportion",orderdetail1x2hf.Proportion),
				 new MySqlParameter("?Currency",orderdetail1x2hf.Currency),
				 new MySqlParameter("?Reason",orderdetail1x2hf.Reason),
				 new MySqlParameter("?gameid",orderdetail1x2hf.Gameid),
				 new MySqlParameter("?betflag",orderdetail1x2hf.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetail1x2hf.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetail1x2hf.MemberCommission)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-1-21 20:15:32		
		///</summary>		
		public Boolean UpdateOrderdetail1x2hf(Orderdetail1x2hf orderdetail1x2hf)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetail1x2hf.UserName),
				 new MySqlParameter("?OrderID",orderdetail1x2hf.OrderID),
				 new MySqlParameter("?time",orderdetail1x2hf.Time),
				 new MySqlParameter("?leaguecn",orderdetail1x2hf.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetail1x2hf.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetail1x2hf.Leagueen),
				 new MySqlParameter("?leagueth",orderdetail1x2hf.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetail1x2hf.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetail1x2hf.Homecn),
				 new MySqlParameter("?Hometw",orderdetail1x2hf.Hometw),
				 new MySqlParameter("?Homeen",orderdetail1x2hf.Homeen),
				 new MySqlParameter("?Hometh",orderdetail1x2hf.Hometh),
				 new MySqlParameter("?Homevn",orderdetail1x2hf.Homevn),
				 new MySqlParameter("?Awaycn",orderdetail1x2hf.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetail1x2hf.Awaytw),
				 new MySqlParameter("?Awayen",orderdetail1x2hf.Awayen),
				 new MySqlParameter("?Awayth",orderdetail1x2hf.Awayth),
				 new MySqlParameter("?Awayvn",orderdetail1x2hf.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetail1x2hf.BeginTime),
				 new MySqlParameter("?BetType",orderdetail1x2hf.BetType),
				 new MySqlParameter("?IsHalf",orderdetail1x2hf.IsHalf),
				 new MySqlParameter("?BetItem",orderdetail1x2hf.BetItem),
				 new MySqlParameter("?Score",orderdetail1x2hf.Score),
				 new MySqlParameter("?Handicap",orderdetail1x2hf.Handicap),
				 new MySqlParameter("?Odds",orderdetail1x2hf.Odds),
				 new MySqlParameter("?OddsType",orderdetail1x2hf.OddsType),
				 new MySqlParameter("?Amount",orderdetail1x2hf.Amount),
				 new MySqlParameter("?ValidAmount",orderdetail1x2hf.ValidAmount),
				 new MySqlParameter("?Status",orderdetail1x2hf.Status),
				 new MySqlParameter("?Agent",orderdetail1x2hf.Agent),
				 new MySqlParameter("?AgentPercent",orderdetail1x2hf.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetail1x2hf.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetail1x2hf.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetail1x2hf.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetail1x2hf.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetail1x2hf.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetail1x2hf.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetail1x2hf.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetail1x2hf.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetail1x2hf.CompanyCommission),
				 new MySqlParameter("?IP",orderdetail1x2hf.IP),
				 new MySqlParameter("?SubCompany",orderdetail1x2hf.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetail1x2hf.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetail1x2hf.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetail1x2hf.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetail1x2hf.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetail1x2hf.Coefficient),
				 new MySqlParameter("?Proportion",orderdetail1x2hf.Proportion),
				 new MySqlParameter("?Currency",orderdetail1x2hf.Currency),
				 new MySqlParameter("?Reason",orderdetail1x2hf.Reason),
				 new MySqlParameter("?gameid",orderdetail1x2hf.Gameid),
				 new MySqlParameter("?betflag",orderdetail1x2hf.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetail1x2hf.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetail1x2hf.MemberCommission),
				 new MySqlParameter("?ID",orderdetail1x2hf.ID)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-1-21 20:15:32		
		///</summary>		
		public Boolean DeleteOrderdetail1x2hfByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2011-1-21 20:15:32		
		///</summary>		
		public Orderdetail1x2hf GetOrderdetail1x2hfByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

			return MySqlModelHelper<Orderdetail1x2hf>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2011-1-21 20:15:32		
		///</summary>		
		public IList<Orderdetail1x2hf> GetMutilILOrderdetail1x2hf()
		{
			return MySqlModelHelper<Orderdetail1x2hf>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2011-1-21 20:15:32		
		///</summary>		
		public DataTable GetMutilDTOrderdetail1x2hf()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 
    }
}
