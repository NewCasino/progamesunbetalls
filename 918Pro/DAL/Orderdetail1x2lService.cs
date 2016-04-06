using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class Orderdetail1x2lService
	{
        private const string SQL_INSERT = "insert into yafa.orderdetail1x2l (UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission)values(?UserName,?OrderID,?time,?leaguecn,?leaguetw,?leagueen,?leagueth,?leaguevn,?Homecn,?Hometw,?Homeen,?Hometh,?Homevn,?Awaycn,?Awaytw,?Awayen,?Awayth,?Awayvn,?BeginTime,?BetType,?IsHalf,?BetItem,?Score,?Handicap,?Odds,?OddsType,?Amount,?ValidAmount,?Status,?Agent,?AgentPercent,?AgentCommission,?ZAgentPercent,?ZAgent,?ZAgentCommission,?PartnerPercent,?PartnerCommission,?Partner,?CompanyPercent,?CompanyCommission,?IP,?SubCompany,?SubCompanyCommission,?SubCompanyPercent,?WebSiteiID,?UserLevel,?Coefficient,?Proportion,?Currency,?Reason,?gameid,?betflag,?MemberPercent,?MemberCommission)";
        private const string SQL_UPDATE = "update yafa.orderdetail1x2l set UserName=?UserName,OrderID=?OrderID,time=?time,leaguecn=?leaguecn,leaguetw=?leaguetw,leagueen=?leagueen,leagueth=?leagueth,leaguevn=?leaguevn,Homecn=?Homecn,Hometw=?Hometw,Homeen=?Homeen,Hometh=?Hometh,Homevn=?Homevn,Awaycn=?Awaycn,Awaytw=?Awaytw,Awayen=?Awayen,Awayth=?Awayth,Awayvn=?Awayvn,BeginTime=?BeginTime,BetType=?BetType,IsHalf=?IsHalf,BetItem=?BetItem,Score=?Score,Handicap=?Handicap,Odds=?Odds,OddsType=?OddsType,Amount=?Amount,ValidAmount=?ValidAmount,Status=?Status,Agent=?Agent,AgentPercent=?AgentPercent,AgentCommission=?AgentCommission,ZAgentPercent=?ZAgentPercent,ZAgent=?ZAgent,ZAgentCommission=?ZAgentCommission,PartnerPercent=?PartnerPercent,PartnerCommission=?PartnerCommission,Partner=?Partner,CompanyPercent=?CompanyPercent,CompanyCommission=?CompanyCommission,IP=?IP,SubCompany=?SubCompany,SubCompanyCommission=?SubCompanyCommission,SubCompanyPercent=?SubCompanyPercent,WebSiteiID=?WebSiteiID,UserLevel=?UserLevel,Coefficient=?Coefficient,Proportion=?Proportion,Currency=?Currency,Reason=?Reason,gameid=?gameid,betflag=?betflag,MemberPercent=?MemberPercent,MemberCommission=?MemberCommission where ID = ?ID";
        private const string SQL_SELECTBYPK = "select ID from yafa.orderdetail1x2l  where orderdetail1x2l.ID = ?ID";
        private const string SQL_SELECTALL = "select ID,UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission from yafa.orderdetail1x2l ";
        private const string SQL_DELETEBYPK = "delete  from yafa.orderdetail1x2l  where orderdetail1x2l.ID = ?ID";

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:16:33		
        ///</summary>		
        public Boolean AddOrderdetail1x2l(Orderdetail1x2l orderdetail1x2l)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetail1x2l.UserName),
				 new MySqlParameter("?OrderID",orderdetail1x2l.OrderID),
				 new MySqlParameter("?time",orderdetail1x2l.Time),
				 new MySqlParameter("?leaguecn",orderdetail1x2l.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetail1x2l.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetail1x2l.Leagueen),
				 new MySqlParameter("?leagueth",orderdetail1x2l.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetail1x2l.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetail1x2l.Homecn),
				 new MySqlParameter("?Hometw",orderdetail1x2l.Hometw),
				 new MySqlParameter("?Homeen",orderdetail1x2l.Homeen),
				 new MySqlParameter("?Hometh",orderdetail1x2l.Hometh),
				 new MySqlParameter("?Homevn",orderdetail1x2l.Homevn),
				 new MySqlParameter("?Awaycn",orderdetail1x2l.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetail1x2l.Awaytw),
				 new MySqlParameter("?Awayen",orderdetail1x2l.Awayen),
				 new MySqlParameter("?Awayth",orderdetail1x2l.Awayth),
				 new MySqlParameter("?Awayvn",orderdetail1x2l.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetail1x2l.BeginTime),
				 new MySqlParameter("?BetType",orderdetail1x2l.BetType),
				 new MySqlParameter("?IsHalf",orderdetail1x2l.IsHalf),
				 new MySqlParameter("?BetItem",orderdetail1x2l.BetItem),
				 new MySqlParameter("?Score",orderdetail1x2l.Score),
				 new MySqlParameter("?Handicap",orderdetail1x2l.Handicap),
				 new MySqlParameter("?Odds",orderdetail1x2l.Odds),
				 new MySqlParameter("?OddsType",orderdetail1x2l.OddsType),
				 new MySqlParameter("?Amount",orderdetail1x2l.Amount),
				 new MySqlParameter("?ValidAmount",orderdetail1x2l.ValidAmount),
				 new MySqlParameter("?Status",orderdetail1x2l.Status),
				 new MySqlParameter("?Agent",orderdetail1x2l.Agent),
				 new MySqlParameter("?AgentPercent",orderdetail1x2l.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetail1x2l.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetail1x2l.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetail1x2l.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetail1x2l.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetail1x2l.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetail1x2l.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetail1x2l.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetail1x2l.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetail1x2l.CompanyCommission),
				 new MySqlParameter("?IP",orderdetail1x2l.IP),
				 new MySqlParameter("?SubCompany",orderdetail1x2l.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetail1x2l.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetail1x2l.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetail1x2l.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetail1x2l.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetail1x2l.Coefficient),
				 new MySqlParameter("?Proportion",orderdetail1x2l.Proportion),
				 new MySqlParameter("?Currency",orderdetail1x2l.Currency),
				 new MySqlParameter("?Reason",orderdetail1x2l.Reason),
				 new MySqlParameter("?gameid",orderdetail1x2l.Gameid),
				 new MySqlParameter("?betflag",orderdetail1x2l.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetail1x2l.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetail1x2l.MemberCommission)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:16:33		
        ///</summary>		
        public Boolean UpdateOrderdetail1x2l(Orderdetail1x2l orderdetail1x2l)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetail1x2l.UserName),
				 new MySqlParameter("?OrderID",orderdetail1x2l.OrderID),
				 new MySqlParameter("?time",orderdetail1x2l.Time),
				 new MySqlParameter("?leaguecn",orderdetail1x2l.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetail1x2l.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetail1x2l.Leagueen),
				 new MySqlParameter("?leagueth",orderdetail1x2l.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetail1x2l.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetail1x2l.Homecn),
				 new MySqlParameter("?Hometw",orderdetail1x2l.Hometw),
				 new MySqlParameter("?Homeen",orderdetail1x2l.Homeen),
				 new MySqlParameter("?Hometh",orderdetail1x2l.Hometh),
				 new MySqlParameter("?Homevn",orderdetail1x2l.Homevn),
				 new MySqlParameter("?Awaycn",orderdetail1x2l.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetail1x2l.Awaytw),
				 new MySqlParameter("?Awayen",orderdetail1x2l.Awayen),
				 new MySqlParameter("?Awayth",orderdetail1x2l.Awayth),
				 new MySqlParameter("?Awayvn",orderdetail1x2l.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetail1x2l.BeginTime),
				 new MySqlParameter("?BetType",orderdetail1x2l.BetType),
				 new MySqlParameter("?IsHalf",orderdetail1x2l.IsHalf),
				 new MySqlParameter("?BetItem",orderdetail1x2l.BetItem),
				 new MySqlParameter("?Score",orderdetail1x2l.Score),
				 new MySqlParameter("?Handicap",orderdetail1x2l.Handicap),
				 new MySqlParameter("?Odds",orderdetail1x2l.Odds),
				 new MySqlParameter("?OddsType",orderdetail1x2l.OddsType),
				 new MySqlParameter("?Amount",orderdetail1x2l.Amount),
				 new MySqlParameter("?ValidAmount",orderdetail1x2l.ValidAmount),
				 new MySqlParameter("?Status",orderdetail1x2l.Status),
				 new MySqlParameter("?Agent",orderdetail1x2l.Agent),
				 new MySqlParameter("?AgentPercent",orderdetail1x2l.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetail1x2l.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetail1x2l.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetail1x2l.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetail1x2l.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetail1x2l.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetail1x2l.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetail1x2l.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetail1x2l.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetail1x2l.CompanyCommission),
				 new MySqlParameter("?IP",orderdetail1x2l.IP),
				 new MySqlParameter("?SubCompany",orderdetail1x2l.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetail1x2l.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetail1x2l.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetail1x2l.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetail1x2l.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetail1x2l.Coefficient),
				 new MySqlParameter("?Proportion",orderdetail1x2l.Proportion),
				 new MySqlParameter("?Currency",orderdetail1x2l.Currency),
				 new MySqlParameter("?Reason",orderdetail1x2l.Reason),
				 new MySqlParameter("?gameid",orderdetail1x2l.Gameid),
				 new MySqlParameter("?betflag",orderdetail1x2l.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetail1x2l.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetail1x2l.MemberCommission),
				 new MySqlParameter("?ID",orderdetail1x2l.ID)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:16:33		
        ///</summary>		
        public Boolean DeleteOrderdetail1x2lByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2011-1-21 20:16:33		
        ///</summary>		
        public Orderdetail1x2l GetOrderdetail1x2lByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

            return MySqlModelHelper<Orderdetail1x2l>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2011-1-21 20:16:33		
        ///</summary>		
        public IList<Orderdetail1x2l> GetMutilILOrderdetail1x2l()
        {
            return MySqlModelHelper<Orderdetail1x2l>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2011-1-21 20:16:33		
        ///</summary>		
        public DataTable GetMutilDTOrderdetail1x2l()
        {
            return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion 
	}
}
