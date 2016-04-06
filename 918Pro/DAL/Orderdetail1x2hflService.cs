using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class Orderdetail1x2hflService
	{
        private const string SQL_INSERT = "insert into yafa.orderdetail1x2hfl (UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission)values(?UserName,?OrderID,?time,?leaguecn,?leaguetw,?leagueen,?leagueth,?leaguevn,?Homecn,?Hometw,?Homeen,?Hometh,?Homevn,?Awaycn,?Awaytw,?Awayen,?Awayth,?Awayvn,?BeginTime,?BetType,?IsHalf,?BetItem,?Score,?Handicap,?Odds,?OddsType,?Amount,?ValidAmount,?Status,?Agent,?AgentPercent,?AgentCommission,?ZAgentPercent,?ZAgent,?ZAgentCommission,?PartnerPercent,?PartnerCommission,?Partner,?CompanyPercent,?CompanyCommission,?IP,?SubCompany,?SubCompanyCommission,?SubCompanyPercent,?WebSiteiID,?UserLevel,?Coefficient,?Proportion,?Currency,?Reason,?gameid,?betflag,?MemberPercent,?MemberCommission)";
        private const string SQL_UPDATE = "update yafa.orderdetail1x2hfl set UserName=?UserName,OrderID=?OrderID,time=?time,leaguecn=?leaguecn,leaguetw=?leaguetw,leagueen=?leagueen,leagueth=?leagueth,leaguevn=?leaguevn,Homecn=?Homecn,Hometw=?Hometw,Homeen=?Homeen,Hometh=?Hometh,Homevn=?Homevn,Awaycn=?Awaycn,Awaytw=?Awaytw,Awayen=?Awayen,Awayth=?Awayth,Awayvn=?Awayvn,BeginTime=?BeginTime,BetType=?BetType,IsHalf=?IsHalf,BetItem=?BetItem,Score=?Score,Handicap=?Handicap,Odds=?Odds,OddsType=?OddsType,Amount=?Amount,ValidAmount=?ValidAmount,Status=?Status,Agent=?Agent,AgentPercent=?AgentPercent,AgentCommission=?AgentCommission,ZAgentPercent=?ZAgentPercent,ZAgent=?ZAgent,ZAgentCommission=?ZAgentCommission,PartnerPercent=?PartnerPercent,PartnerCommission=?PartnerCommission,Partner=?Partner,CompanyPercent=?CompanyPercent,CompanyCommission=?CompanyCommission,IP=?IP,SubCompany=?SubCompany,SubCompanyCommission=?SubCompanyCommission,SubCompanyPercent=?SubCompanyPercent,WebSiteiID=?WebSiteiID,UserLevel=?UserLevel,Coefficient=?Coefficient,Proportion=?Proportion,Currency=?Currency,Reason=?Reason,gameid=?gameid,betflag=?betflag,MemberPercent=?MemberPercent,MemberCommission=?MemberCommission where ID = ?ID";
        private const string SQL_SELECTBYPK = "select ID from yafa.orderdetail1x2hfl  where orderdetail1x2hfl.ID = ?ID";
        private const string SQL_SELECTALL = "select ID,UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission from yafa.orderdetail1x2hfl ";
        private const string SQL_DELETEBYPK = "delete  from yafa.orderdetail1x2hfl  where orderdetail1x2hfl.ID = ?ID";
        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:14:08		
        ///</summary>		
        public Boolean AddOrderdetail1x2hfl(Orderdetail1x2hfl orderdetail1x2hfl)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetail1x2hfl.UserName),
				 new MySqlParameter("?OrderID",orderdetail1x2hfl.OrderID),
				 new MySqlParameter("?time",orderdetail1x2hfl.Time),
				 new MySqlParameter("?leaguecn",orderdetail1x2hfl.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetail1x2hfl.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetail1x2hfl.Leagueen),
				 new MySqlParameter("?leagueth",orderdetail1x2hfl.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetail1x2hfl.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetail1x2hfl.Homecn),
				 new MySqlParameter("?Hometw",orderdetail1x2hfl.Hometw),
				 new MySqlParameter("?Homeen",orderdetail1x2hfl.Homeen),
				 new MySqlParameter("?Hometh",orderdetail1x2hfl.Hometh),
				 new MySqlParameter("?Homevn",orderdetail1x2hfl.Homevn),
				 new MySqlParameter("?Awaycn",orderdetail1x2hfl.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetail1x2hfl.Awaytw),
				 new MySqlParameter("?Awayen",orderdetail1x2hfl.Awayen),
				 new MySqlParameter("?Awayth",orderdetail1x2hfl.Awayth),
				 new MySqlParameter("?Awayvn",orderdetail1x2hfl.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetail1x2hfl.BeginTime),
				 new MySqlParameter("?BetType",orderdetail1x2hfl.BetType),
				 new MySqlParameter("?IsHalf",orderdetail1x2hfl.IsHalf),
				 new MySqlParameter("?BetItem",orderdetail1x2hfl.BetItem),
				 new MySqlParameter("?Score",orderdetail1x2hfl.Score),
				 new MySqlParameter("?Handicap",orderdetail1x2hfl.Handicap),
				 new MySqlParameter("?Odds",orderdetail1x2hfl.Odds),
				 new MySqlParameter("?OddsType",orderdetail1x2hfl.OddsType),
				 new MySqlParameter("?Amount",orderdetail1x2hfl.Amount),
				 new MySqlParameter("?ValidAmount",orderdetail1x2hfl.ValidAmount),
				 new MySqlParameter("?Status",orderdetail1x2hfl.Status),
				 new MySqlParameter("?Agent",orderdetail1x2hfl.Agent),
				 new MySqlParameter("?AgentPercent",orderdetail1x2hfl.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetail1x2hfl.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetail1x2hfl.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetail1x2hfl.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetail1x2hfl.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetail1x2hfl.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetail1x2hfl.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetail1x2hfl.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetail1x2hfl.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetail1x2hfl.CompanyCommission),
				 new MySqlParameter("?IP",orderdetail1x2hfl.IP),
				 new MySqlParameter("?SubCompany",orderdetail1x2hfl.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetail1x2hfl.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetail1x2hfl.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetail1x2hfl.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetail1x2hfl.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetail1x2hfl.Coefficient),
				 new MySqlParameter("?Proportion",orderdetail1x2hfl.Proportion),
				 new MySqlParameter("?Currency",orderdetail1x2hfl.Currency),
				 new MySqlParameter("?Reason",orderdetail1x2hfl.Reason),
				 new MySqlParameter("?gameid",orderdetail1x2hfl.Gameid),
				 new MySqlParameter("?betflag",orderdetail1x2hfl.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetail1x2hfl.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetail1x2hfl.MemberCommission)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:14:08		
        ///</summary>		
        public Boolean UpdateOrderdetail1x2hfl(Orderdetail1x2hfl orderdetail1x2hfl)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetail1x2hfl.UserName),
				 new MySqlParameter("?OrderID",orderdetail1x2hfl.OrderID),
				 new MySqlParameter("?time",orderdetail1x2hfl.Time),
				 new MySqlParameter("?leaguecn",orderdetail1x2hfl.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetail1x2hfl.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetail1x2hfl.Leagueen),
				 new MySqlParameter("?leagueth",orderdetail1x2hfl.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetail1x2hfl.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetail1x2hfl.Homecn),
				 new MySqlParameter("?Hometw",orderdetail1x2hfl.Hometw),
				 new MySqlParameter("?Homeen",orderdetail1x2hfl.Homeen),
				 new MySqlParameter("?Hometh",orderdetail1x2hfl.Hometh),
				 new MySqlParameter("?Homevn",orderdetail1x2hfl.Homevn),
				 new MySqlParameter("?Awaycn",orderdetail1x2hfl.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetail1x2hfl.Awaytw),
				 new MySqlParameter("?Awayen",orderdetail1x2hfl.Awayen),
				 new MySqlParameter("?Awayth",orderdetail1x2hfl.Awayth),
				 new MySqlParameter("?Awayvn",orderdetail1x2hfl.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetail1x2hfl.BeginTime),
				 new MySqlParameter("?BetType",orderdetail1x2hfl.BetType),
				 new MySqlParameter("?IsHalf",orderdetail1x2hfl.IsHalf),
				 new MySqlParameter("?BetItem",orderdetail1x2hfl.BetItem),
				 new MySqlParameter("?Score",orderdetail1x2hfl.Score),
				 new MySqlParameter("?Handicap",orderdetail1x2hfl.Handicap),
				 new MySqlParameter("?Odds",orderdetail1x2hfl.Odds),
				 new MySqlParameter("?OddsType",orderdetail1x2hfl.OddsType),
				 new MySqlParameter("?Amount",orderdetail1x2hfl.Amount),
				 new MySqlParameter("?ValidAmount",orderdetail1x2hfl.ValidAmount),
				 new MySqlParameter("?Status",orderdetail1x2hfl.Status),
				 new MySqlParameter("?Agent",orderdetail1x2hfl.Agent),
				 new MySqlParameter("?AgentPercent",orderdetail1x2hfl.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetail1x2hfl.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetail1x2hfl.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetail1x2hfl.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetail1x2hfl.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetail1x2hfl.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetail1x2hfl.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetail1x2hfl.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetail1x2hfl.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetail1x2hfl.CompanyCommission),
				 new MySqlParameter("?IP",orderdetail1x2hfl.IP),
				 new MySqlParameter("?SubCompany",orderdetail1x2hfl.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetail1x2hfl.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetail1x2hfl.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetail1x2hfl.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetail1x2hfl.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetail1x2hfl.Coefficient),
				 new MySqlParameter("?Proportion",orderdetail1x2hfl.Proportion),
				 new MySqlParameter("?Currency",orderdetail1x2hfl.Currency),
				 new MySqlParameter("?Reason",orderdetail1x2hfl.Reason),
				 new MySqlParameter("?gameid",orderdetail1x2hfl.Gameid),
				 new MySqlParameter("?betflag",orderdetail1x2hfl.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetail1x2hfl.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetail1x2hfl.MemberCommission),
				 new MySqlParameter("?ID",orderdetail1x2hfl.ID)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:14:08		
        ///</summary>		
        public Boolean DeleteOrderdetail1x2hflByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2011-1-21 20:14:08		
        ///</summary>		
        public Orderdetail1x2hfl GetOrderdetail1x2hflByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

            return MySqlModelHelper<Orderdetail1x2hfl>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2011-1-21 20:14:08		
        ///</summary>		
        public IList<Orderdetail1x2hfl> GetMutilILOrderdetail1x2hfl()
        {
            return MySqlModelHelper<Orderdetail1x2hfl>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2011-1-21 20:14:08		
        ///</summary>		
        public DataTable GetMutilDTOrderdetail1x2hfl()
        {
            return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion 
        #region 编写人:李毅
        public string GetAllTolength(string length,string league,string level,string type,string money,string ballteam,string language,string username,string roid)
        {
            bool pd = false;
            string str = "select * from v_orderdetail where Status=1";
            if (username != "" && roid != "")
            {
                str += " and " + roid + "='" + username + "'";
            }
            if (level != "0")
            {
                str += " and UserLevel='" + level + "'";
            }
            if (type != "-1")
            {
                str += " and BetType=" + type;
            }
            if (money != "")
            {
                str += " and Amount>=" + money;
            }
            if (league != "")
            {
                pd = true;
                str += " and (league" + language + " in(" + league + ")";
            }
            if (ballteam != "")
            {
                if (pd)
                {
                    str += " or gameid in(" + ballteam + "))";
                }
                else
                {
                    str += " and (gameid in(" + ballteam + "))";
                }
            }
            else
            {
                if (pd)
                {
                    str += ")";
                }
            }
            str += " order by time desc limit 0,"+length;
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        public string setBalance(string username,string money)
        {
            string str = "update user set Balance=Balance+" + money + " where UserName=?username";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?username",username)
            };
            return MySqlHelper.ExecuteNonQuery(str,param).ToString();
        }
        #endregion
    }
}
