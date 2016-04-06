using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class OrderdetailouhfService
	{
        private const string SQL_INSERT = "insert into yafa.orderdetailouhf (UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission)values(?UserName,?OrderID,?time,?leaguecn,?leaguetw,?leagueen,?leagueth,?leaguevn,?Homecn,?Hometw,?Homeen,?Hometh,?Homevn,?Awaycn,?Awaytw,?Awayen,?Awayth,?Awayvn,?BeginTime,?BetType,?IsHalf,?BetItem,?Score,?Handicap,?Odds,?OddsType,?Amount,?ValidAmount,?Status,?Agent,?AgentPercent,?AgentCommission,?ZAgentPercent,?ZAgent,?ZAgentCommission,?PartnerPercent,?PartnerCommission,?Partner,?CompanyPercent,?CompanyCommission,?IP,?SubCompany,?SubCompanyCommission,?SubCompanyPercent,?WebSiteiID,?UserLevel,?Coefficient,?Proportion,?Currency,?Reason,?gameid,?betflag,?MemberPercent,?MemberCommission)";
        private const string SQL_UPDATE = "update yafa.orderdetailouhf set UserName=?UserName,OrderID=?OrderID,time=?time,leaguecn=?leaguecn,leaguetw=?leaguetw,leagueen=?leagueen,leagueth=?leagueth,leaguevn=?leaguevn,Homecn=?Homecn,Hometw=?Hometw,Homeen=?Homeen,Hometh=?Hometh,Homevn=?Homevn,Awaycn=?Awaycn,Awaytw=?Awaytw,Awayen=?Awayen,Awayth=?Awayth,Awayvn=?Awayvn,BeginTime=?BeginTime,BetType=?BetType,IsHalf=?IsHalf,BetItem=?BetItem,Score=?Score,Handicap=?Handicap,Odds=?Odds,OddsType=?OddsType,Amount=?Amount,ValidAmount=?ValidAmount,Status=?Status,Agent=?Agent,AgentPercent=?AgentPercent,AgentCommission=?AgentCommission,ZAgentPercent=?ZAgentPercent,ZAgent=?ZAgent,ZAgentCommission=?ZAgentCommission,PartnerPercent=?PartnerPercent,PartnerCommission=?PartnerCommission,Partner=?Partner,CompanyPercent=?CompanyPercent,CompanyCommission=?CompanyCommission,IP=?IP,SubCompany=?SubCompany,SubCompanyCommission=?SubCompanyCommission,SubCompanyPercent=?SubCompanyPercent,WebSiteiID=?WebSiteiID,UserLevel=?UserLevel,Coefficient=?Coefficient,Proportion=?Proportion,Currency=?Currency,Reason=?Reason,gameid=?gameid,betflag=?betflag,MemberPercent=?MemberPercent,MemberCommission=?MemberCommission where ID = ?ID";
        private const string SQL_SELECTBYPK = "select ID from yafa.orderdetailouhf  where orderdetailouhf.ID = ?ID";
        private const string SQL_SELECTALL = "select ID,UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission from yafa.orderdetailouhf ";
        private const string SQL_DELETEBYPK = "delete  from yafa.orderdetailouhf  where orderdetailouhf.ID = ?ID";

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:24:53		
        ///</summary>		
        public Boolean AddOrderdetailouhf(Orderdetailouhf orderdetailouhf)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetailouhf.UserName),
				 new MySqlParameter("?OrderID",orderdetailouhf.OrderID),
				 new MySqlParameter("?time",orderdetailouhf.Time),
				 new MySqlParameter("?leaguecn",orderdetailouhf.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetailouhf.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetailouhf.Leagueen),
				 new MySqlParameter("?leagueth",orderdetailouhf.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetailouhf.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetailouhf.Homecn),
				 new MySqlParameter("?Hometw",orderdetailouhf.Hometw),
				 new MySqlParameter("?Homeen",orderdetailouhf.Homeen),
				 new MySqlParameter("?Hometh",orderdetailouhf.Hometh),
				 new MySqlParameter("?Homevn",orderdetailouhf.Homevn),
				 new MySqlParameter("?Awaycn",orderdetailouhf.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetailouhf.Awaytw),
				 new MySqlParameter("?Awayen",orderdetailouhf.Awayen),
				 new MySqlParameter("?Awayth",orderdetailouhf.Awayth),
				 new MySqlParameter("?Awayvn",orderdetailouhf.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetailouhf.BeginTime),
				 new MySqlParameter("?BetType",orderdetailouhf.BetType),
				 new MySqlParameter("?IsHalf",orderdetailouhf.IsHalf),
				 new MySqlParameter("?BetItem",orderdetailouhf.BetItem),
				 new MySqlParameter("?Score",orderdetailouhf.Score),
				 new MySqlParameter("?Handicap",orderdetailouhf.Handicap),
				 new MySqlParameter("?Odds",orderdetailouhf.Odds),
				 new MySqlParameter("?OddsType",orderdetailouhf.OddsType),
				 new MySqlParameter("?Amount",orderdetailouhf.Amount),
				 new MySqlParameter("?ValidAmount",orderdetailouhf.ValidAmount),
				 new MySqlParameter("?Status",orderdetailouhf.Status),
				 new MySqlParameter("?Agent",orderdetailouhf.Agent),
				 new MySqlParameter("?AgentPercent",orderdetailouhf.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetailouhf.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetailouhf.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetailouhf.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetailouhf.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetailouhf.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetailouhf.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetailouhf.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetailouhf.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetailouhf.CompanyCommission),
				 new MySqlParameter("?IP",orderdetailouhf.IP),
				 new MySqlParameter("?SubCompany",orderdetailouhf.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetailouhf.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetailouhf.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetailouhf.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetailouhf.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetailouhf.Coefficient),
				 new MySqlParameter("?Proportion",orderdetailouhf.Proportion),
				 new MySqlParameter("?Currency",orderdetailouhf.Currency),
				 new MySqlParameter("?Reason",orderdetailouhf.Reason),
				 new MySqlParameter("?gameid",orderdetailouhf.Gameid),
				 new MySqlParameter("?betflag",orderdetailouhf.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetailouhf.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetailouhf.MemberCommission)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:24:53		
        ///</summary>		
        public Boolean UpdateOrderdetailouhf(Orderdetailouhf orderdetailouhf)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetailouhf.UserName),
				 new MySqlParameter("?OrderID",orderdetailouhf.OrderID),
				 new MySqlParameter("?time",orderdetailouhf.Time),
				 new MySqlParameter("?leaguecn",orderdetailouhf.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetailouhf.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetailouhf.Leagueen),
				 new MySqlParameter("?leagueth",orderdetailouhf.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetailouhf.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetailouhf.Homecn),
				 new MySqlParameter("?Hometw",orderdetailouhf.Hometw),
				 new MySqlParameter("?Homeen",orderdetailouhf.Homeen),
				 new MySqlParameter("?Hometh",orderdetailouhf.Hometh),
				 new MySqlParameter("?Homevn",orderdetailouhf.Homevn),
				 new MySqlParameter("?Awaycn",orderdetailouhf.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetailouhf.Awaytw),
				 new MySqlParameter("?Awayen",orderdetailouhf.Awayen),
				 new MySqlParameter("?Awayth",orderdetailouhf.Awayth),
				 new MySqlParameter("?Awayvn",orderdetailouhf.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetailouhf.BeginTime),
				 new MySqlParameter("?BetType",orderdetailouhf.BetType),
				 new MySqlParameter("?IsHalf",orderdetailouhf.IsHalf),
				 new MySqlParameter("?BetItem",orderdetailouhf.BetItem),
				 new MySqlParameter("?Score",orderdetailouhf.Score),
				 new MySqlParameter("?Handicap",orderdetailouhf.Handicap),
				 new MySqlParameter("?Odds",orderdetailouhf.Odds),
				 new MySqlParameter("?OddsType",orderdetailouhf.OddsType),
				 new MySqlParameter("?Amount",orderdetailouhf.Amount),
				 new MySqlParameter("?ValidAmount",orderdetailouhf.ValidAmount),
				 new MySqlParameter("?Status",orderdetailouhf.Status),
				 new MySqlParameter("?Agent",orderdetailouhf.Agent),
				 new MySqlParameter("?AgentPercent",orderdetailouhf.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetailouhf.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetailouhf.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetailouhf.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetailouhf.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetailouhf.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetailouhf.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetailouhf.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetailouhf.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetailouhf.CompanyCommission),
				 new MySqlParameter("?IP",orderdetailouhf.IP),
				 new MySqlParameter("?SubCompany",orderdetailouhf.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetailouhf.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetailouhf.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetailouhf.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetailouhf.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetailouhf.Coefficient),
				 new MySqlParameter("?Proportion",orderdetailouhf.Proportion),
				 new MySqlParameter("?Currency",orderdetailouhf.Currency),
				 new MySqlParameter("?Reason",orderdetailouhf.Reason),
				 new MySqlParameter("?gameid",orderdetailouhf.Gameid),
				 new MySqlParameter("?betflag",orderdetailouhf.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetailouhf.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetailouhf.MemberCommission),
				 new MySqlParameter("?ID",orderdetailouhf.ID)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:24:53		
        ///</summary>		
        public Boolean DeleteOrderdetailouhfByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2011-1-21 20:24:53		
        ///</summary>		
        public Orderdetailouhf GetOrderdetailouhfByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

            return MySqlModelHelper<Orderdetailouhf>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2011-1-21 20:24:53		
        ///</summary>		
        public IList<Orderdetailouhf> GetMutilILOrderdetailouhf()
        {
            return MySqlModelHelper<Orderdetailouhf>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2011-1-21 20:24:53		
        ///</summary>		
        public DataTable GetMutilDTOrderdetailouhf()
        {
            return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion 
	}
}
