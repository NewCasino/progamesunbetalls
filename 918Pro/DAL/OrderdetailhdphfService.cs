using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class OrderdetailhdphfService
	{
        private const string SQL_INSERT = "insert into yafa.orderdetailhdphf (UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission)values(?UserName,?OrderID,?time,?leaguecn,?leaguetw,?leagueen,?leagueth,?leaguevn,?Homecn,?Hometw,?Homeen,?Hometh,?Homevn,?Awaycn,?Awaytw,?Awayen,?Awayth,?Awayvn,?BeginTime,?BetType,?IsHalf,?BetItem,?Score,?Handicap,?Odds,?OddsType,?Amount,?ValidAmount,?Status,?Agent,?AgentPercent,?AgentCommission,?ZAgentPercent,?ZAgent,?ZAgentCommission,?PartnerPercent,?PartnerCommission,?Partner,?CompanyPercent,?CompanyCommission,?IP,?SubCompany,?SubCompanyCommission,?SubCompanyPercent,?WebSiteiID,?UserLevel,?Coefficient,?Proportion,?Currency,?Reason,?gameid,?betflag,?MemberPercent,?MemberCommission)";
        private const string SQL_UPDATE = "update yafa.orderdetailhdphf set UserName=?UserName,OrderID=?OrderID,time=?time,leaguecn=?leaguecn,leaguetw=?leaguetw,leagueen=?leagueen,leagueth=?leagueth,leaguevn=?leaguevn,Homecn=?Homecn,Hometw=?Hometw,Homeen=?Homeen,Hometh=?Hometh,Homevn=?Homevn,Awaycn=?Awaycn,Awaytw=?Awaytw,Awayen=?Awayen,Awayth=?Awayth,Awayvn=?Awayvn,BeginTime=?BeginTime,BetType=?BetType,IsHalf=?IsHalf,BetItem=?BetItem,Score=?Score,Handicap=?Handicap,Odds=?Odds,OddsType=?OddsType,Amount=?Amount,ValidAmount=?ValidAmount,Status=?Status,Agent=?Agent,AgentPercent=?AgentPercent,AgentCommission=?AgentCommission,ZAgentPercent=?ZAgentPercent,ZAgent=?ZAgent,ZAgentCommission=?ZAgentCommission,PartnerPercent=?PartnerPercent,PartnerCommission=?PartnerCommission,Partner=?Partner,CompanyPercent=?CompanyPercent,CompanyCommission=?CompanyCommission,IP=?IP,SubCompany=?SubCompany,SubCompanyCommission=?SubCompanyCommission,SubCompanyPercent=?SubCompanyPercent,WebSiteiID=?WebSiteiID,UserLevel=?UserLevel,Coefficient=?Coefficient,Proportion=?Proportion,Currency=?Currency,Reason=?Reason,gameid=?gameid,betflag=?betflag,MemberPercent=?MemberPercent,MemberCommission=?MemberCommission where ID = ?ID";
        private const string SQL_SELECTBYPK = "select ID from yafa.orderdetailhdphf  where orderdetailhdphf.ID = ?ID";
        private const string SQL_SELECTALL = "select ID,UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission from yafa.orderdetailhdphf ";
        private const string SQL_DELETEBYPK = "delete  from yafa.orderdetailhdphf  where orderdetailhdphf.ID = ?ID";

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:19:29		
        ///</summary>		
        public Boolean AddOrderdetailhdphf(Orderdetailhdphf orderdetailhdphf)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetailhdphf.UserName),
				 new MySqlParameter("?OrderID",orderdetailhdphf.OrderID),
				 new MySqlParameter("?time",orderdetailhdphf.Time),
				 new MySqlParameter("?leaguecn",orderdetailhdphf.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetailhdphf.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetailhdphf.Leagueen),
				 new MySqlParameter("?leagueth",orderdetailhdphf.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetailhdphf.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetailhdphf.Homecn),
				 new MySqlParameter("?Hometw",orderdetailhdphf.Hometw),
				 new MySqlParameter("?Homeen",orderdetailhdphf.Homeen),
				 new MySqlParameter("?Hometh",orderdetailhdphf.Hometh),
				 new MySqlParameter("?Homevn",orderdetailhdphf.Homevn),
				 new MySqlParameter("?Awaycn",orderdetailhdphf.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetailhdphf.Awaytw),
				 new MySqlParameter("?Awayen",orderdetailhdphf.Awayen),
				 new MySqlParameter("?Awayth",orderdetailhdphf.Awayth),
				 new MySqlParameter("?Awayvn",orderdetailhdphf.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetailhdphf.BeginTime),
				 new MySqlParameter("?BetType",orderdetailhdphf.BetType),
				 new MySqlParameter("?IsHalf",orderdetailhdphf.IsHalf),
				 new MySqlParameter("?BetItem",orderdetailhdphf.BetItem),
				 new MySqlParameter("?Score",orderdetailhdphf.Score),
				 new MySqlParameter("?Handicap",orderdetailhdphf.Handicap),
				 new MySqlParameter("?Odds",orderdetailhdphf.Odds),
				 new MySqlParameter("?OddsType",orderdetailhdphf.OddsType),
				 new MySqlParameter("?Amount",orderdetailhdphf.Amount),
				 new MySqlParameter("?ValidAmount",orderdetailhdphf.ValidAmount),
				 new MySqlParameter("?Status",orderdetailhdphf.Status),
				 new MySqlParameter("?Agent",orderdetailhdphf.Agent),
				 new MySqlParameter("?AgentPercent",orderdetailhdphf.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetailhdphf.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetailhdphf.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetailhdphf.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetailhdphf.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetailhdphf.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetailhdphf.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetailhdphf.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetailhdphf.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetailhdphf.CompanyCommission),
				 new MySqlParameter("?IP",orderdetailhdphf.IP),
				 new MySqlParameter("?SubCompany",orderdetailhdphf.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetailhdphf.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetailhdphf.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetailhdphf.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetailhdphf.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetailhdphf.Coefficient),
				 new MySqlParameter("?Proportion",orderdetailhdphf.Proportion),
				 new MySqlParameter("?Currency",orderdetailhdphf.Currency),
				 new MySqlParameter("?Reason",orderdetailhdphf.Reason),
				 new MySqlParameter("?gameid",orderdetailhdphf.Gameid),
				 new MySqlParameter("?betflag",orderdetailhdphf.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetailhdphf.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetailhdphf.MemberCommission)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:19:29		
        ///</summary>		
        public Boolean UpdateOrderdetailhdphf(Orderdetailhdphf orderdetailhdphf)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetailhdphf.UserName),
				 new MySqlParameter("?OrderID",orderdetailhdphf.OrderID),
				 new MySqlParameter("?time",orderdetailhdphf.Time),
				 new MySqlParameter("?leaguecn",orderdetailhdphf.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetailhdphf.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetailhdphf.Leagueen),
				 new MySqlParameter("?leagueth",orderdetailhdphf.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetailhdphf.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetailhdphf.Homecn),
				 new MySqlParameter("?Hometw",orderdetailhdphf.Hometw),
				 new MySqlParameter("?Homeen",orderdetailhdphf.Homeen),
				 new MySqlParameter("?Hometh",orderdetailhdphf.Hometh),
				 new MySqlParameter("?Homevn",orderdetailhdphf.Homevn),
				 new MySqlParameter("?Awaycn",orderdetailhdphf.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetailhdphf.Awaytw),
				 new MySqlParameter("?Awayen",orderdetailhdphf.Awayen),
				 new MySqlParameter("?Awayth",orderdetailhdphf.Awayth),
				 new MySqlParameter("?Awayvn",orderdetailhdphf.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetailhdphf.BeginTime),
				 new MySqlParameter("?BetType",orderdetailhdphf.BetType),
				 new MySqlParameter("?IsHalf",orderdetailhdphf.IsHalf),
				 new MySqlParameter("?BetItem",orderdetailhdphf.BetItem),
				 new MySqlParameter("?Score",orderdetailhdphf.Score),
				 new MySqlParameter("?Handicap",orderdetailhdphf.Handicap),
				 new MySqlParameter("?Odds",orderdetailhdphf.Odds),
				 new MySqlParameter("?OddsType",orderdetailhdphf.OddsType),
				 new MySqlParameter("?Amount",orderdetailhdphf.Amount),
				 new MySqlParameter("?ValidAmount",orderdetailhdphf.ValidAmount),
				 new MySqlParameter("?Status",orderdetailhdphf.Status),
				 new MySqlParameter("?Agent",orderdetailhdphf.Agent),
				 new MySqlParameter("?AgentPercent",orderdetailhdphf.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetailhdphf.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetailhdphf.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetailhdphf.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetailhdphf.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetailhdphf.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetailhdphf.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetailhdphf.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetailhdphf.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetailhdphf.CompanyCommission),
				 new MySqlParameter("?IP",orderdetailhdphf.IP),
				 new MySqlParameter("?SubCompany",orderdetailhdphf.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetailhdphf.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetailhdphf.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetailhdphf.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetailhdphf.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetailhdphf.Coefficient),
				 new MySqlParameter("?Proportion",orderdetailhdphf.Proportion),
				 new MySqlParameter("?Currency",orderdetailhdphf.Currency),
				 new MySqlParameter("?Reason",orderdetailhdphf.Reason),
				 new MySqlParameter("?gameid",orderdetailhdphf.Gameid),
				 new MySqlParameter("?betflag",orderdetailhdphf.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetailhdphf.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetailhdphf.MemberCommission),
				 new MySqlParameter("?ID",orderdetailhdphf.ID)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:19:29		
        ///</summary>		
        public Boolean DeleteOrderdetailhdphfByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2011-1-21 20:19:29		
        ///</summary>		
        public Orderdetailhdphf GetOrderdetailhdphfByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

            return MySqlModelHelper<Orderdetailhdphf>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2011-1-21 20:19:29		
        ///</summary>		
        public IList<Orderdetailhdphf> GetMutilILOrderdetailhdphf()
        {
            return MySqlModelHelper<Orderdetailhdphf>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2011-1-21 20:19:29		
        ///</summary>		
        public DataTable GetMutilDTOrderdetailhdphf()
        {
            return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion 
	}
}
