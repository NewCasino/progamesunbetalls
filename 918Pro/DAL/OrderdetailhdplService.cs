using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class OrderdetailhdplService
	{
        private const string SQL_INSERT = "insert into yafa.orderdetailhdpl (UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission)values(?UserName,?OrderID,?time,?leaguecn,?leaguetw,?leagueen,?leagueth,?leaguevn,?Homecn,?Hometw,?Homeen,?Hometh,?Homevn,?Awaycn,?Awaytw,?Awayen,?Awayth,?Awayvn,?BeginTime,?BetType,?IsHalf,?BetItem,?Score,?Handicap,?Odds,?OddsType,?Amount,?ValidAmount,?Status,?Agent,?AgentPercent,?AgentCommission,?ZAgentPercent,?ZAgent,?ZAgentCommission,?PartnerPercent,?PartnerCommission,?Partner,?CompanyPercent,?CompanyCommission,?IP,?SubCompany,?SubCompanyCommission,?SubCompanyPercent,?WebSiteiID,?UserLevel,?Coefficient,?Proportion,?Currency,?Reason,?gameid,?betflag,?MemberPercent,?MemberCommission)";
        private const string SQL_UPDATE = "update yafa.orderdetailhdpl set UserName=?UserName,OrderID=?OrderID,time=?time,leaguecn=?leaguecn,leaguetw=?leaguetw,leagueen=?leagueen,leagueth=?leagueth,leaguevn=?leaguevn,Homecn=?Homecn,Hometw=?Hometw,Homeen=?Homeen,Hometh=?Hometh,Homevn=?Homevn,Awaycn=?Awaycn,Awaytw=?Awaytw,Awayen=?Awayen,Awayth=?Awayth,Awayvn=?Awayvn,BeginTime=?BeginTime,BetType=?BetType,IsHalf=?IsHalf,BetItem=?BetItem,Score=?Score,Handicap=?Handicap,Odds=?Odds,OddsType=?OddsType,Amount=?Amount,ValidAmount=?ValidAmount,Status=?Status,Agent=?Agent,AgentPercent=?AgentPercent,AgentCommission=?AgentCommission,ZAgentPercent=?ZAgentPercent,ZAgent=?ZAgent,ZAgentCommission=?ZAgentCommission,PartnerPercent=?PartnerPercent,PartnerCommission=?PartnerCommission,Partner=?Partner,CompanyPercent=?CompanyPercent,CompanyCommission=?CompanyCommission,IP=?IP,SubCompany=?SubCompany,SubCompanyCommission=?SubCompanyCommission,SubCompanyPercent=?SubCompanyPercent,WebSiteiID=?WebSiteiID,UserLevel=?UserLevel,Coefficient=?Coefficient,Proportion=?Proportion,Currency=?Currency,Reason=?Reason,gameid=?gameid,betflag=?betflag,MemberPercent=?MemberPercent,MemberCommission=?MemberCommission where ID = ?ID";
        private const string SQL_SELECTBYPK = "select ID from yafa.orderdetailhdpl  where orderdetailhdpl.ID = ?ID";
        private const string SQL_SELECTALL = "select ID,UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission from yafa.orderdetailhdpl ";
        private const string SQL_DELETEBYPK = "delete  from yafa.orderdetailhdpl  where orderdetailhdpl.ID = ?ID";

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:20:24		
        ///</summary>		
        public Boolean AddOrderdetailhdpl(Orderdetailhdpl orderdetailhdpl)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetailhdpl.UserName),
				 new MySqlParameter("?OrderID",orderdetailhdpl.OrderID),
				 new MySqlParameter("?time",orderdetailhdpl.Time),
				 new MySqlParameter("?leaguecn",orderdetailhdpl.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetailhdpl.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetailhdpl.Leagueen),
				 new MySqlParameter("?leagueth",orderdetailhdpl.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetailhdpl.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetailhdpl.Homecn),
				 new MySqlParameter("?Hometw",orderdetailhdpl.Hometw),
				 new MySqlParameter("?Homeen",orderdetailhdpl.Homeen),
				 new MySqlParameter("?Hometh",orderdetailhdpl.Hometh),
				 new MySqlParameter("?Homevn",orderdetailhdpl.Homevn),
				 new MySqlParameter("?Awaycn",orderdetailhdpl.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetailhdpl.Awaytw),
				 new MySqlParameter("?Awayen",orderdetailhdpl.Awayen),
				 new MySqlParameter("?Awayth",orderdetailhdpl.Awayth),
				 new MySqlParameter("?Awayvn",orderdetailhdpl.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetailhdpl.BeginTime),
				 new MySqlParameter("?BetType",orderdetailhdpl.BetType),
				 new MySqlParameter("?IsHalf",orderdetailhdpl.IsHalf),
				 new MySqlParameter("?BetItem",orderdetailhdpl.BetItem),
				 new MySqlParameter("?Score",orderdetailhdpl.Score),
				 new MySqlParameter("?Handicap",orderdetailhdpl.Handicap),
				 new MySqlParameter("?Odds",orderdetailhdpl.Odds),
				 new MySqlParameter("?OddsType",orderdetailhdpl.OddsType),
				 new MySqlParameter("?Amount",orderdetailhdpl.Amount),
				 new MySqlParameter("?ValidAmount",orderdetailhdpl.ValidAmount),
				 new MySqlParameter("?Status",orderdetailhdpl.Status),
				 new MySqlParameter("?Agent",orderdetailhdpl.Agent),
				 new MySqlParameter("?AgentPercent",orderdetailhdpl.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetailhdpl.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetailhdpl.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetailhdpl.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetailhdpl.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetailhdpl.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetailhdpl.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetailhdpl.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetailhdpl.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetailhdpl.CompanyCommission),
				 new MySqlParameter("?IP",orderdetailhdpl.IP),
				 new MySqlParameter("?SubCompany",orderdetailhdpl.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetailhdpl.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetailhdpl.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetailhdpl.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetailhdpl.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetailhdpl.Coefficient),
				 new MySqlParameter("?Proportion",orderdetailhdpl.Proportion),
				 new MySqlParameter("?Currency",orderdetailhdpl.Currency),
				 new MySqlParameter("?Reason",orderdetailhdpl.Reason),
				 new MySqlParameter("?gameid",orderdetailhdpl.Gameid),
				 new MySqlParameter("?betflag",orderdetailhdpl.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetailhdpl.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetailhdpl.MemberCommission)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:20:24		
        ///</summary>		
        public Boolean UpdateOrderdetailhdpl(Orderdetailhdpl orderdetailhdpl)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetailhdpl.UserName),
				 new MySqlParameter("?OrderID",orderdetailhdpl.OrderID),
				 new MySqlParameter("?time",orderdetailhdpl.Time),
				 new MySqlParameter("?leaguecn",orderdetailhdpl.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetailhdpl.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetailhdpl.Leagueen),
				 new MySqlParameter("?leagueth",orderdetailhdpl.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetailhdpl.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetailhdpl.Homecn),
				 new MySqlParameter("?Hometw",orderdetailhdpl.Hometw),
				 new MySqlParameter("?Homeen",orderdetailhdpl.Homeen),
				 new MySqlParameter("?Hometh",orderdetailhdpl.Hometh),
				 new MySqlParameter("?Homevn",orderdetailhdpl.Homevn),
				 new MySqlParameter("?Awaycn",orderdetailhdpl.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetailhdpl.Awaytw),
				 new MySqlParameter("?Awayen",orderdetailhdpl.Awayen),
				 new MySqlParameter("?Awayth",orderdetailhdpl.Awayth),
				 new MySqlParameter("?Awayvn",orderdetailhdpl.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetailhdpl.BeginTime),
				 new MySqlParameter("?BetType",orderdetailhdpl.BetType),
				 new MySqlParameter("?IsHalf",orderdetailhdpl.IsHalf),
				 new MySqlParameter("?BetItem",orderdetailhdpl.BetItem),
				 new MySqlParameter("?Score",orderdetailhdpl.Score),
				 new MySqlParameter("?Handicap",orderdetailhdpl.Handicap),
				 new MySqlParameter("?Odds",orderdetailhdpl.Odds),
				 new MySqlParameter("?OddsType",orderdetailhdpl.OddsType),
				 new MySqlParameter("?Amount",orderdetailhdpl.Amount),
				 new MySqlParameter("?ValidAmount",orderdetailhdpl.ValidAmount),
				 new MySqlParameter("?Status",orderdetailhdpl.Status),
				 new MySqlParameter("?Agent",orderdetailhdpl.Agent),
				 new MySqlParameter("?AgentPercent",orderdetailhdpl.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetailhdpl.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetailhdpl.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetailhdpl.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetailhdpl.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetailhdpl.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetailhdpl.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetailhdpl.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetailhdpl.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetailhdpl.CompanyCommission),
				 new MySqlParameter("?IP",orderdetailhdpl.IP),
				 new MySqlParameter("?SubCompany",orderdetailhdpl.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetailhdpl.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetailhdpl.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetailhdpl.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetailhdpl.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetailhdpl.Coefficient),
				 new MySqlParameter("?Proportion",orderdetailhdpl.Proportion),
				 new MySqlParameter("?Currency",orderdetailhdpl.Currency),
				 new MySqlParameter("?Reason",orderdetailhdpl.Reason),
				 new MySqlParameter("?gameid",orderdetailhdpl.Gameid),
				 new MySqlParameter("?betflag",orderdetailhdpl.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetailhdpl.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetailhdpl.MemberCommission),
				 new MySqlParameter("?ID",orderdetailhdpl.ID)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:20:24		
        ///</summary>		
        public Boolean DeleteOrderdetailhdplByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2011-1-21 20:20:24		
        ///</summary>		
        public Orderdetailhdpl GetOrderdetailhdplByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

            return MySqlModelHelper<Orderdetailhdpl>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2011-1-21 20:20:24		
        ///</summary>		
        public IList<Orderdetailhdpl> GetMutilILOrderdetailhdpl()
        {
            return MySqlModelHelper<Orderdetailhdpl>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2011-1-21 20:20:24		
        ///</summary>		
        public DataTable GetMutilDTOrderdetailhdpl()
        {
            return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion 
	}
}
