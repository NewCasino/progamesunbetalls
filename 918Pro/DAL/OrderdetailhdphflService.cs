using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class OrderdetailhdphflService
	{
        private const string SQL_INSERT = "insert into yafa.orderdetailhdphfl (UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission)values(?UserName,?OrderID,?time,?leaguecn,?leaguetw,?leagueen,?leagueth,?leaguevn,?Homecn,?Hometw,?Homeen,?Hometh,?Homevn,?Awaycn,?Awaytw,?Awayen,?Awayth,?Awayvn,?BeginTime,?BetType,?IsHalf,?BetItem,?Score,?Handicap,?Odds,?OddsType,?Amount,?ValidAmount,?Status,?Agent,?AgentPercent,?AgentCommission,?ZAgentPercent,?ZAgent,?ZAgentCommission,?PartnerPercent,?PartnerCommission,?Partner,?CompanyPercent,?CompanyCommission,?IP,?SubCompany,?SubCompanyCommission,?SubCompanyPercent,?WebSiteiID,?UserLevel,?Coefficient,?Proportion,?Currency,?Reason,?gameid,?betflag,?MemberPercent,?MemberCommission)";
        private const string SQL_UPDATE = "update yafa.orderdetailhdphfl set UserName=?UserName,OrderID=?OrderID,time=?time,leaguecn=?leaguecn,leaguetw=?leaguetw,leagueen=?leagueen,leagueth=?leagueth,leaguevn=?leaguevn,Homecn=?Homecn,Hometw=?Hometw,Homeen=?Homeen,Hometh=?Hometh,Homevn=?Homevn,Awaycn=?Awaycn,Awaytw=?Awaytw,Awayen=?Awayen,Awayth=?Awayth,Awayvn=?Awayvn,BeginTime=?BeginTime,BetType=?BetType,IsHalf=?IsHalf,BetItem=?BetItem,Score=?Score,Handicap=?Handicap,Odds=?Odds,OddsType=?OddsType,Amount=?Amount,ValidAmount=?ValidAmount,Status=?Status,Agent=?Agent,AgentPercent=?AgentPercent,AgentCommission=?AgentCommission,ZAgentPercent=?ZAgentPercent,ZAgent=?ZAgent,ZAgentCommission=?ZAgentCommission,PartnerPercent=?PartnerPercent,PartnerCommission=?PartnerCommission,Partner=?Partner,CompanyPercent=?CompanyPercent,CompanyCommission=?CompanyCommission,IP=?IP,SubCompany=?SubCompany,SubCompanyCommission=?SubCompanyCommission,SubCompanyPercent=?SubCompanyPercent,WebSiteiID=?WebSiteiID,UserLevel=?UserLevel,Coefficient=?Coefficient,Proportion=?Proportion,Currency=?Currency,Reason=?Reason,gameid=?gameid,betflag=?betflag,MemberPercent=?MemberPercent,MemberCommission=?MemberCommission where ID = ?ID";
        private const string SQL_SELECTBYPK = "select ID from yafa.orderdetailhdphfl  where orderdetailhdphfl.ID = ?ID";
        private const string SQL_SELECTALL = "select ID,UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission from yafa.orderdetailhdphfl ";
        private const string SQL_DELETEBYPK = "delete  from yafa.orderdetailhdphfl  where orderdetailhdphfl.ID = ?ID";

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:18:41		
        ///</summary>		
        public Boolean AddOrderdetailhdphfl(Orderdetailhdphfl orderdetailhdphfl)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetailhdphfl.UserName),
				 new MySqlParameter("?OrderID",orderdetailhdphfl.OrderID),
				 new MySqlParameter("?time",orderdetailhdphfl.Time),
				 new MySqlParameter("?leaguecn",orderdetailhdphfl.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetailhdphfl.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetailhdphfl.Leagueen),
				 new MySqlParameter("?leagueth",orderdetailhdphfl.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetailhdphfl.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetailhdphfl.Homecn),
				 new MySqlParameter("?Hometw",orderdetailhdphfl.Hometw),
				 new MySqlParameter("?Homeen",orderdetailhdphfl.Homeen),
				 new MySqlParameter("?Hometh",orderdetailhdphfl.Hometh),
				 new MySqlParameter("?Homevn",orderdetailhdphfl.Homevn),
				 new MySqlParameter("?Awaycn",orderdetailhdphfl.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetailhdphfl.Awaytw),
				 new MySqlParameter("?Awayen",orderdetailhdphfl.Awayen),
				 new MySqlParameter("?Awayth",orderdetailhdphfl.Awayth),
				 new MySqlParameter("?Awayvn",orderdetailhdphfl.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetailhdphfl.BeginTime),
				 new MySqlParameter("?BetType",orderdetailhdphfl.BetType),
				 new MySqlParameter("?IsHalf",orderdetailhdphfl.IsHalf),
				 new MySqlParameter("?BetItem",orderdetailhdphfl.BetItem),
				 new MySqlParameter("?Score",orderdetailhdphfl.Score),
				 new MySqlParameter("?Handicap",orderdetailhdphfl.Handicap),
				 new MySqlParameter("?Odds",orderdetailhdphfl.Odds),
				 new MySqlParameter("?OddsType",orderdetailhdphfl.OddsType),
				 new MySqlParameter("?Amount",orderdetailhdphfl.Amount),
				 new MySqlParameter("?ValidAmount",orderdetailhdphfl.ValidAmount),
				 new MySqlParameter("?Status",orderdetailhdphfl.Status),
				 new MySqlParameter("?Agent",orderdetailhdphfl.Agent),
				 new MySqlParameter("?AgentPercent",orderdetailhdphfl.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetailhdphfl.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetailhdphfl.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetailhdphfl.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetailhdphfl.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetailhdphfl.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetailhdphfl.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetailhdphfl.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetailhdphfl.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetailhdphfl.CompanyCommission),
				 new MySqlParameter("?IP",orderdetailhdphfl.IP),
				 new MySqlParameter("?SubCompany",orderdetailhdphfl.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetailhdphfl.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetailhdphfl.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetailhdphfl.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetailhdphfl.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetailhdphfl.Coefficient),
				 new MySqlParameter("?Proportion",orderdetailhdphfl.Proportion),
				 new MySqlParameter("?Currency",orderdetailhdphfl.Currency),
				 new MySqlParameter("?Reason",orderdetailhdphfl.Reason),
				 new MySqlParameter("?gameid",orderdetailhdphfl.Gameid),
				 new MySqlParameter("?betflag",orderdetailhdphfl.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetailhdphfl.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetailhdphfl.MemberCommission)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:18:41		
        ///</summary>		
        public Boolean UpdateOrderdetailhdphfl(Orderdetailhdphfl orderdetailhdphfl)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetailhdphfl.UserName),
				 new MySqlParameter("?OrderID",orderdetailhdphfl.OrderID),
				 new MySqlParameter("?time",orderdetailhdphfl.Time),
				 new MySqlParameter("?leaguecn",orderdetailhdphfl.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetailhdphfl.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetailhdphfl.Leagueen),
				 new MySqlParameter("?leagueth",orderdetailhdphfl.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetailhdphfl.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetailhdphfl.Homecn),
				 new MySqlParameter("?Hometw",orderdetailhdphfl.Hometw),
				 new MySqlParameter("?Homeen",orderdetailhdphfl.Homeen),
				 new MySqlParameter("?Hometh",orderdetailhdphfl.Hometh),
				 new MySqlParameter("?Homevn",orderdetailhdphfl.Homevn),
				 new MySqlParameter("?Awaycn",orderdetailhdphfl.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetailhdphfl.Awaytw),
				 new MySqlParameter("?Awayen",orderdetailhdphfl.Awayen),
				 new MySqlParameter("?Awayth",orderdetailhdphfl.Awayth),
				 new MySqlParameter("?Awayvn",orderdetailhdphfl.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetailhdphfl.BeginTime),
				 new MySqlParameter("?BetType",orderdetailhdphfl.BetType),
				 new MySqlParameter("?IsHalf",orderdetailhdphfl.IsHalf),
				 new MySqlParameter("?BetItem",orderdetailhdphfl.BetItem),
				 new MySqlParameter("?Score",orderdetailhdphfl.Score),
				 new MySqlParameter("?Handicap",orderdetailhdphfl.Handicap),
				 new MySqlParameter("?Odds",orderdetailhdphfl.Odds),
				 new MySqlParameter("?OddsType",orderdetailhdphfl.OddsType),
				 new MySqlParameter("?Amount",orderdetailhdphfl.Amount),
				 new MySqlParameter("?ValidAmount",orderdetailhdphfl.ValidAmount),
				 new MySqlParameter("?Status",orderdetailhdphfl.Status),
				 new MySqlParameter("?Agent",orderdetailhdphfl.Agent),
				 new MySqlParameter("?AgentPercent",orderdetailhdphfl.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetailhdphfl.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetailhdphfl.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetailhdphfl.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetailhdphfl.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetailhdphfl.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetailhdphfl.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetailhdphfl.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetailhdphfl.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetailhdphfl.CompanyCommission),
				 new MySqlParameter("?IP",orderdetailhdphfl.IP),
				 new MySqlParameter("?SubCompany",orderdetailhdphfl.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetailhdphfl.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetailhdphfl.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetailhdphfl.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetailhdphfl.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetailhdphfl.Coefficient),
				 new MySqlParameter("?Proportion",orderdetailhdphfl.Proportion),
				 new MySqlParameter("?Currency",orderdetailhdphfl.Currency),
				 new MySqlParameter("?Reason",orderdetailhdphfl.Reason),
				 new MySqlParameter("?gameid",orderdetailhdphfl.Gameid),
				 new MySqlParameter("?betflag",orderdetailhdphfl.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetailhdphfl.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetailhdphfl.MemberCommission),
				 new MySqlParameter("?ID",orderdetailhdphfl.ID)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:18:41		
        ///</summary>		
        public Boolean DeleteOrderdetailhdphflByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2011-1-21 20:18:41		
        ///</summary>		
        public Orderdetailhdphfl GetOrderdetailhdphflByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

            return MySqlModelHelper<Orderdetailhdphfl>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2011-1-21 20:18:41		
        ///</summary>		
        public IList<Orderdetailhdphfl> GetMutilILOrderdetailhdphfl()
        {
            return MySqlModelHelper<Orderdetailhdphfl>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2011-1-21 20:18:41		
        ///</summary>		
        public DataTable GetMutilDTOrderdetailhdphfl()
        {
            return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion 
	}
}
