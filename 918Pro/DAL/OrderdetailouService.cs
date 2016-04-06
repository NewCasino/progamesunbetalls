using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class OrderdetailouService
	{
        private const string SQL_INSERT = "insert into yafa.orderdetailou (UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission)values(?UserName,?OrderID,?time,?leaguecn,?leaguetw,?leagueen,?leagueth,?leaguevn,?Homecn,?Hometw,?Homeen,?Hometh,?Homevn,?Awaycn,?Awaytw,?Awayen,?Awayth,?Awayvn,?BeginTime,?BetType,?IsHalf,?BetItem,?Score,?Handicap,?Odds,?OddsType,?Amount,?ValidAmount,?Status,?Agent,?AgentPercent,?AgentCommission,?ZAgentPercent,?ZAgent,?ZAgentCommission,?PartnerPercent,?PartnerCommission,?Partner,?CompanyPercent,?CompanyCommission,?IP,?SubCompany,?SubCompanyCommission,?SubCompanyPercent,?WebSiteiID,?UserLevel,?Coefficient,?Proportion,?Currency,?Reason,?gameid,?betflag,?MemberPercent,?MemberCommission)";
        private const string SQL_UPDATE = "update yafa.orderdetailou set UserName=?UserName,OrderID=?OrderID,time=?time,leaguecn=?leaguecn,leaguetw=?leaguetw,leagueen=?leagueen,leagueth=?leagueth,leaguevn=?leaguevn,Homecn=?Homecn,Hometw=?Hometw,Homeen=?Homeen,Hometh=?Hometh,Homevn=?Homevn,Awaycn=?Awaycn,Awaytw=?Awaytw,Awayen=?Awayen,Awayth=?Awayth,Awayvn=?Awayvn,BeginTime=?BeginTime,BetType=?BetType,IsHalf=?IsHalf,BetItem=?BetItem,Score=?Score,Handicap=?Handicap,Odds=?Odds,OddsType=?OddsType,Amount=?Amount,ValidAmount=?ValidAmount,Status=?Status,Agent=?Agent,AgentPercent=?AgentPercent,AgentCommission=?AgentCommission,ZAgentPercent=?ZAgentPercent,ZAgent=?ZAgent,ZAgentCommission=?ZAgentCommission,PartnerPercent=?PartnerPercent,PartnerCommission=?PartnerCommission,Partner=?Partner,CompanyPercent=?CompanyPercent,CompanyCommission=?CompanyCommission,IP=?IP,SubCompany=?SubCompany,SubCompanyCommission=?SubCompanyCommission,SubCompanyPercent=?SubCompanyPercent,WebSiteiID=?WebSiteiID,UserLevel=?UserLevel,Coefficient=?Coefficient,Proportion=?Proportion,Currency=?Currency,Reason=?Reason,gameid=?gameid,betflag=?betflag,MemberPercent=?MemberPercent,MemberCommission=?MemberCommission where ID = ?ID";
        private const string SQL_SELECTBYPK = "select ID from yafa.orderdetailou  where orderdetailou.ID = ?ID";
        private const string SQL_SELECTALL = "select ID,UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,MemberPercent,MemberCommission from yafa.orderdetailou ";
        private const string SQL_DELETEBYPK = "delete  from yafa.orderdetailou  where orderdetailou.ID = ?ID";

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:26:53		
        ///</summary>		
        public Boolean AddOrderdetailou(Orderdetailou orderdetailou)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetailou.UserName),
				 new MySqlParameter("?OrderID",orderdetailou.OrderID),
				 new MySqlParameter("?time",orderdetailou.Time),
				 new MySqlParameter("?leaguecn",orderdetailou.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetailou.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetailou.Leagueen),
				 new MySqlParameter("?leagueth",orderdetailou.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetailou.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetailou.Homecn),
				 new MySqlParameter("?Hometw",orderdetailou.Hometw),
				 new MySqlParameter("?Homeen",orderdetailou.Homeen),
				 new MySqlParameter("?Hometh",orderdetailou.Hometh),
				 new MySqlParameter("?Homevn",orderdetailou.Homevn),
				 new MySqlParameter("?Awaycn",orderdetailou.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetailou.Awaytw),
				 new MySqlParameter("?Awayen",orderdetailou.Awayen),
				 new MySqlParameter("?Awayth",orderdetailou.Awayth),
				 new MySqlParameter("?Awayvn",orderdetailou.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetailou.BeginTime),
				 new MySqlParameter("?BetType",orderdetailou.BetType),
				 new MySqlParameter("?IsHalf",orderdetailou.IsHalf),
				 new MySqlParameter("?BetItem",orderdetailou.BetItem),
				 new MySqlParameter("?Score",orderdetailou.Score),
				 new MySqlParameter("?Handicap",orderdetailou.Handicap),
				 new MySqlParameter("?Odds",orderdetailou.Odds),
				 new MySqlParameter("?OddsType",orderdetailou.OddsType),
				 new MySqlParameter("?Amount",orderdetailou.Amount),
				 new MySqlParameter("?ValidAmount",orderdetailou.ValidAmount),
				 new MySqlParameter("?Status",orderdetailou.Status),
				 new MySqlParameter("?Agent",orderdetailou.Agent),
				 new MySqlParameter("?AgentPercent",orderdetailou.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetailou.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetailou.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetailou.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetailou.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetailou.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetailou.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetailou.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetailou.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetailou.CompanyCommission),
				 new MySqlParameter("?IP",orderdetailou.IP),
				 new MySqlParameter("?SubCompany",orderdetailou.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetailou.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetailou.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetailou.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetailou.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetailou.Coefficient),
				 new MySqlParameter("?Proportion",orderdetailou.Proportion),
				 new MySqlParameter("?Currency",orderdetailou.Currency),
				 new MySqlParameter("?Reason",orderdetailou.Reason),
				 new MySqlParameter("?gameid",orderdetailou.Gameid),
				 new MySqlParameter("?betflag",orderdetailou.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetailou.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetailou.MemberCommission)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:26:53		
        ///</summary>		
        public Boolean UpdateOrderdetailou(Orderdetailou orderdetailou)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderdetailou.UserName),
				 new MySqlParameter("?OrderID",orderdetailou.OrderID),
				 new MySqlParameter("?time",orderdetailou.Time),
				 new MySqlParameter("?leaguecn",orderdetailou.Leaguecn),
				 new MySqlParameter("?leaguetw",orderdetailou.Leaguetw),
				 new MySqlParameter("?leagueen",orderdetailou.Leagueen),
				 new MySqlParameter("?leagueth",orderdetailou.Leagueth),
				 new MySqlParameter("?leaguevn",orderdetailou.Leaguevn),
				 new MySqlParameter("?Homecn",orderdetailou.Homecn),
				 new MySqlParameter("?Hometw",orderdetailou.Hometw),
				 new MySqlParameter("?Homeen",orderdetailou.Homeen),
				 new MySqlParameter("?Hometh",orderdetailou.Hometh),
				 new MySqlParameter("?Homevn",orderdetailou.Homevn),
				 new MySqlParameter("?Awaycn",orderdetailou.Awaycn),
				 new MySqlParameter("?Awaytw",orderdetailou.Awaytw),
				 new MySqlParameter("?Awayen",orderdetailou.Awayen),
				 new MySqlParameter("?Awayth",orderdetailou.Awayth),
				 new MySqlParameter("?Awayvn",orderdetailou.Awayvn),
				 new MySqlParameter("?BeginTime",orderdetailou.BeginTime),
				 new MySqlParameter("?BetType",orderdetailou.BetType),
				 new MySqlParameter("?IsHalf",orderdetailou.IsHalf),
				 new MySqlParameter("?BetItem",orderdetailou.BetItem),
				 new MySqlParameter("?Score",orderdetailou.Score),
				 new MySqlParameter("?Handicap",orderdetailou.Handicap),
				 new MySqlParameter("?Odds",orderdetailou.Odds),
				 new MySqlParameter("?OddsType",orderdetailou.OddsType),
				 new MySqlParameter("?Amount",orderdetailou.Amount),
				 new MySqlParameter("?ValidAmount",orderdetailou.ValidAmount),
				 new MySqlParameter("?Status",orderdetailou.Status),
				 new MySqlParameter("?Agent",orderdetailou.Agent),
				 new MySqlParameter("?AgentPercent",orderdetailou.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderdetailou.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderdetailou.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderdetailou.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderdetailou.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderdetailou.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderdetailou.PartnerCommission),
				 new MySqlParameter("?Partner",orderdetailou.Partner),
				 new MySqlParameter("?CompanyPercent",orderdetailou.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderdetailou.CompanyCommission),
				 new MySqlParameter("?IP",orderdetailou.IP),
				 new MySqlParameter("?SubCompany",orderdetailou.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderdetailou.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderdetailou.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderdetailou.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderdetailou.UserLevel),
				 new MySqlParameter("?Coefficient",orderdetailou.Coefficient),
				 new MySqlParameter("?Proportion",orderdetailou.Proportion),
				 new MySqlParameter("?Currency",orderdetailou.Currency),
				 new MySqlParameter("?Reason",orderdetailou.Reason),
				 new MySqlParameter("?gameid",orderdetailou.Gameid),
				 new MySqlParameter("?betflag",orderdetailou.Betflag),
				 new MySqlParameter("?MemberPercent",orderdetailou.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderdetailou.MemberCommission),
				 new MySqlParameter("?ID",orderdetailou.ID)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-1-21 20:26:53		
        ///</summary>		
        public Boolean DeleteOrderdetailouByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2011-1-21 20:26:53		
        ///</summary>		
        public Orderdetailou GetOrderdetailouByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

            return MySqlModelHelper<Orderdetailou>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2011-1-21 20:26:53		
        ///</summary>		
        public IList<Orderdetailou> GetMutilILOrderdetailou()
        {
            return MySqlModelHelper<Orderdetailou>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2011-1-21 20:26:53		
        ///</summary>		
        public DataTable GetMutilDTOrderdetailou()
        {
            return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion 

        /// <summary>
        /// 即时监控（亚洲盘及大小盘）
        /// </summary>
        /// <param name="language">语言</param>
        /// <param name="league">联赛</param>
        /// <param name="gameId">队伍</param>
        /// <param name="agentUserName">代理用户名</param>
        /// <param name="role">角色ID</param>
        /// <param name="limi">取记录数</param>
        /// <param name="btype">类型 all:全部，hf:半场，fl:全场</param>
        /// <returns></returns>
        public string GetHdpAndOu(string language,string league,string gameId,string agentUserName,string role,string limi,string btype)
        {
            //过虑处理
            language = language.Replace("'", "");
            agentUserName = agentUserName.Replace("'", "");
            role = role.Replace("'", "");
            limi = limi.Replace("'", "");
            if (!string.IsNullOrEmpty(league))
            {
                league = "'" + league;
                league = league.Replace(";", "','");
                league += "'";            
            }
            gameId = gameId.Replace(";",",");

            string lanSql = "";
            string whereSql = "";
            string sql = "";
            switch (language)
            {
                case "cn":
                    lanSql = ",leaguecn as league,Homecn as Home,Awaycn as Away";
                    if (!string.IsNullOrEmpty(league))
                    {
                        whereSql = " and leaguecn in(" + league + ") ";
                    }
                    break;
                case "tw":
                    lanSql = ",leaguetw as league,Hometw as Home,Awaytw as Away";
                    if (!string.IsNullOrEmpty(league))
                    {
                        whereSql = " and leaguetw in(" + league + ") ";
                    }

                    break;
                case "en":
                    lanSql = ",leagueen as league,Homeen as Home,Awayen as Away";
                    if (!string.IsNullOrEmpty(league))
                    {
                        whereSql = " and leagueen in(" + league + ") ";
                    }
                    break;
                case "th-th":
                    lanSql = ",leagueth as league,Hometh as Home,Awayth as Away";
                    if (!string.IsNullOrEmpty(league))
                    {
                        whereSql = " and leagueth in(" + league + ") ";
                    }
                    break;
                case "vi-vn":
                    lanSql = ",leaguevn as league,Homevn as Home,Awayvn as Away";
                    if (!string.IsNullOrEmpty(league))
                    {
                        whereSql = " and leaguevn in(" + league + ") ";
                    }
                    break;
                default:
                    lanSql = ",leaguetw as league,Hometw as Home,Awaytw as Away";
                    if (!string.IsNullOrEmpty(league))
                    {
                        whereSql = " and leaguetw in(" + league + ") ";
                    }
                    break;
            }
            if (!string.IsNullOrEmpty(gameId))
            {
                whereSql += " and gameid in(" + gameId + ") ";
            }
            if (btype == "fl")
            {
                whereSql += " and (Bettype='0' or Bettype='1' or Bettype='4' or Bettype='5' or Bettype='8' or Bettype='9') ";
            }
            if (btype == "hf")
            {
                whereSql += " and (Bettype='2' or Bettype='3' or Bettype='6' or Bettype='7' or Bettype='10' or Bettype='11') ";
            }
            if (!string.IsNullOrEmpty(agentUserName))
            {
                switch (role)
                {
                    case "2":
                        whereSql += " and SubCompany='" + agentUserName + "' ";
                        break;
                    case "3":
                        whereSql += " and Partner='" + agentUserName + "' ";
                        break;
                    case "4":
                        whereSql += " and ZAgent='" + agentUserName + "' ";
                        break;
                    case "5":
                        whereSql += " and Agent='" + agentUserName + "' ";
                        break;
                }
            }

            sql += "select begintime,gameid";
            sql += lanSql + "";
            if (btype == "fl" || btype == "all")
            {
                sql += ",sum(case when ((BetType='0' or BetType='4' or BetType='8') and betflag='H') then Amount  end) as homefeef";
                sql += ",sum(case when ((BetType='0' or BetType='4' or BetType='8') and betflag='A') then Amount end) as awayfeef";
                sql += ",sum(case when ((BetType='1' or BetType='5' or BetType='9') and betflag='O') then Amount end) as bigfeef";
                sql += ",sum(case when ((BetType='1' or BetType='5' or BetType='9') and betflag='U') then Amount end) as smallfeef";
            }
            if (btype == "hf" || btype == "all")
            {
                sql += ",sum(case when ((BetType='2' or BetType='6' or BetType='10') and betflag='H') then Amount end) as homefeeh";
                sql += ",sum(case when ((BetType='2' or BetType='6' or BetType='10') and betflag='A') then Amount end) as awayfeeh";
                sql += ",sum(case when ((BetType='3' or BetType='7' or BetType='11') and betflag='O') then Amount end) as bigfeeh";
                sql += ",sum(case when ((BetType='3' or BetType='7' or BetType='11') and betflag='U') then Amount end) as smallfeeh";
            }
            sql += " from orderdetail_v";
            sql += " where 1=1" + whereSql;
            sql += " group by leaguetw,gameid ";
            if (!string.IsNullOrEmpty(limi))
            {
                sql += " limit " + limi;
            }

            MySqlDataReader read = MySqlHelper.ExecuteReader(sql);
            string json = ObjectToJson.ReaderToJson(read);
            return json == string.Empty ? "none" : json;
        }

        public string GetHdpAndOu2(string language, string league, string gameId, string agentUserName, string role, string limi, string btype, string mtype)
        {
            //过虑处理
            language = language.Replace("'", "");
            agentUserName = agentUserName.Replace("'", "");
            role = role.Replace("'", "");
            limi = limi.Replace("'", "");
            if (!string.IsNullOrEmpty(league))
            {
                league = "'" + league;
                league = league.Replace(";", "','");
                league += "'";
            }
            gameId = gameId.Replace(";", ",");

            string lanSql = "";
            string whereSql = "";
            string sql = "";
            switch (language)
            {
                case "cn":
                    lanSql = ",leaguecn as league,Homecn as Home,Awaycn as Away";
                    if (!string.IsNullOrEmpty(league))
                    {
                        whereSql = " and leaguecn in(" + league + ") ";
                    }
                    break;
                case "tw":
                    lanSql = ",leaguetw as league,Hometw as Home,Awaytw as Away";
                    if (!string.IsNullOrEmpty(league))
                    {
                        whereSql = " and leaguetw in(" + league + ") ";
                    }

                    break;
                case "en":
                    lanSql = ",leagueen as league,Homeen as Home,Awayen as Away";
                    if (!string.IsNullOrEmpty(league))
                    {
                        whereSql = " and leagueen in(" + league + ") ";
                    }
                    break;
                case "th-th":
                    lanSql = ",leagueth as league,Hometh as Home,Awayth as Away";
                    if (!string.IsNullOrEmpty(league))
                    {
                        whereSql = " and leagueth in(" + league + ") ";
                    }
                    break;
                case "vi-vn":
                    lanSql = ",leaguevn as league,Homevn as Home,Awayvn as Away";
                    if (!string.IsNullOrEmpty(league))
                    {
                        whereSql = " and leaguevn in(" + league + ") ";
                    }
                    break;
                default:
                    lanSql = ",leaguetw as league,Hometw as Home,Awaytw as Away";
                    if (!string.IsNullOrEmpty(league))
                    {
                        whereSql = " and leaguetw in(" + league + ") ";
                    }
                    break;
            }
            if (!string.IsNullOrEmpty(gameId))
            {
                whereSql += " and gameid in(" + gameId + ") ";
            }
            if (btype == "fl")
            {
                whereSql += " and (Bettype='0' or Bettype='1' or Bettype='4' or Bettype='5' or Bettype='8' or Bettype='9') ";
            }
            if (btype == "hf")
            {
                whereSql += " and (Bettype='2' or Bettype='3' or Bettype='6' or Bettype='7' or Bettype='10' or Bettype='11') ";
            }
            if (!string.IsNullOrEmpty(agentUserName))
            {
                switch (role)
                {
                    case "2":
                        whereSql += " and SubCompany='" + agentUserName + "' ";
                        break;
                    case "3":
                        whereSql += " and Partner='" + agentUserName + "' ";
                        break;
                    case "4":
                        whereSql += " and ZAgent='" + agentUserName + "' ";
                        break;
                    case "5":
                        whereSql += " and Agent='" + agentUserName + "' ";
                        break;
                }
            }

            sql += "select begintime,gameid";
            sql += lanSql + "";
            if (btype == "fl" || btype == "all")
            {
                if (mtype == "1")
                {
                    //本币（人民币）
                    sql += ",sum((case when ((BetType='0' or BetType='4' or BetType='8') and betflag='H') then Amount  end) * rate) as homefeef";
                    sql += ",sum((case when ((BetType='0' or BetType='4' or BetType='8') and betflag='A') then Amount end) * rate) as awayfeef";
                    sql += ",sum((case when ((BetType='1' or BetType='5' or BetType='9') and betflag='O') then Amount end) * rate) as bigfeef";
                    sql += ",sum((case when ((BetType='1' or BetType='5' or BetType='9') and betflag='U') then Amount end) * rate) as smallfeef";
                }
                else
                {
                    sql += ",sum(case when ((BetType='0' or BetType='4' or BetType='8') and betflag='H') then Amount  end) as homefeef";
                    sql += ",sum(case when ((BetType='0' or BetType='4' or BetType='8') and betflag='A') then Amount end) as awayfeef";
                    sql += ",sum(case when ((BetType='1' or BetType='5' or BetType='9') and betflag='O') then Amount end) as bigfeef";
                    sql += ",sum(case when ((BetType='1' or BetType='5' or BetType='9') and betflag='U') then Amount end) as smallfeef";
                }
            }
            if (btype == "hf" || btype == "all")
            {
                if (mtype == "1")
                {
                    //本币（人民币）
                    sql += ",sum((case when ((BetType='2' or BetType='6' or BetType='10') and betflag='H') then Amount end) * rate) as homefeeh";
                    sql += ",sum((case when ((BetType='2' or BetType='6' or BetType='10') and betflag='A') then Amount end) * rate) as awayfeeh";
                    sql += ",sum((case when ((BetType='3' or BetType='7' or BetType='11') and betflag='O') then Amount end) * rate) as bigfeeh";
                    sql += ",sum((case when ((BetType='3' or BetType='7' or BetType='11') and betflag='U') then Amount end) * rate) as smallfeeh";
                }
                else
                {
                    sql += ",sum(case when ((BetType='2' or BetType='6' or BetType='10') and betflag='H') then Amount end) as homefeeh";
                    sql += ",sum(case when ((BetType='2' or BetType='6' or BetType='10') and betflag='A') then Amount end) as awayfeeh";
                    sql += ",sum(case when ((BetType='3' or BetType='7' or BetType='11') and betflag='O') then Amount end) as bigfeeh";
                    sql += ",sum(case when ((BetType='3' or BetType='7' or BetType='11') and betflag='U') then Amount end) as smallfeeh";
                }
            }
            sql += " from orderdetail_v";
            sql += " where 1=1" + whereSql;
            sql += " group by leaguetw,gameid ";
            if (!string.IsNullOrEmpty(limi))
            {
                sql += " limit " + limi;
            }

            MySqlDataReader read = MySqlHelper.ExecuteReader(sql);
            string json = ObjectToJson.ReaderToJson(read);
            return json == string.Empty ? "none" : json;
        }

        /// <summary>
        /// 即时监控（1x2）
        /// </summary>
        /// <param name="language">语言</param>
        /// <param name="league">联赛</param>
        /// <param name="gameId">队伍</param>
        /// <param name="agentUserName">代理用户名</param>
        /// <param name="role">角色ID</param>
        /// <param name="limi">取记录数</param>
        /// <returns></returns>
        public string Get1x2(string language, string league, string gameId, string agentUserName, string role, string limi)
        {
            //过虑处理
            language = language.Replace("'", "");
            agentUserName = agentUserName.Replace("'", "");
            role = role.Replace("'", "");
            limi = limi.Replace("'", "");

            string[] leagueArr = league.Split(';');
            for (int i = 0; i < leagueArr.Length; i++)
            {
                if (i == 0)
                {
                    league = "'" + leagueArr[i].ToString() + "'";
                }
                else
                {
                    league += ",'" + leagueArr[i].ToString() + "'";
                }
            }
            league = league.Replace("''", "");
            gameId = gameId.Replace(";", ",");
            string lanSql = "";
            string whereSql = "";
            string sql = "";
            switch (language)
            {
                case "cn":
                    lanSql = "leaguecn as league,Homecn as Home,Awaycn as Away";
                    if (!string.IsNullOrEmpty(league))
                    {
                        whereSql = " and leaguecn in(" + league + ") ";
                    }
                    break;
                case "tw":
                    lanSql = "leaguetw as league,Hometw as Home,Awaytw as Away";
                    if (!string.IsNullOrEmpty(league))
                    {
                        whereSql = " and leaguetw in(" + league + ") ";
                    }

                    break;
                case "en":
                    lanSql = "leagueen as league,Homeen as Home,Awayen as Away";
                    if (!string.IsNullOrEmpty(league))
                    {
                        whereSql = " and leagueen in(" + league + ") ";
                    }
                    break;
                case "th":
                    lanSql = "leagueth as league,Hometh as Home,Awayth as Away";
                    if (!string.IsNullOrEmpty(league))
                    {
                        whereSql = " and leagueth in(" + league + ") ";
                    }
                    break;
                case "vn":
                    lanSql = "leaguevn as league,Homevn as Home,Awayvn as Away";
                    if (!string.IsNullOrEmpty(league))
                    {
                        whereSql = " and leaguevn in(" + league + ") ";
                    }
                    break;
            }
            if (!string.IsNullOrEmpty(gameId))
            {
                whereSql += " and gameid in(" + gameId + ") ";
            }
            if (!string.IsNullOrEmpty(agentUserName))
            {
                switch (role)
                {
                    case "2":
                        whereSql += " and SubCompany='" + agentUserName + "' ";
                        break;
                    case "3":
                        whereSql += " and Partner='" + agentUserName + "' ";
                        break;
                    case "4":
                        whereSql += " and ZAgent='" + agentUserName + "' ";
                        break;
                    case "5":
                        whereSql += " and Agent='" + agentUserName + "' ";
                        break;
                }
            }

            sql += "select begintime,gameid,";
            sql += lanSql + ",";
            sql += "sum(case when ((BetType='12' or BetType='14' or BetType='16') and betflag='1') then Amount else 0 end) as fee1f,";
            sql += "sum(case when ((BetType='12' or BetType='14' or BetType='16') and betflag='X') then Amount else 0 end) as feeXf,";
            sql += "sum(case when ((BetType='12' or BetType='14' or BetType='16') and betflag='2') then Amount else 0 end) as fee2f,";
            sql += "sum(case when ((BetType='13' or BetType='15' or BetType='17') and betflag='1') then Amount else 0 end) as fee1h,";
            sql += "sum(case when ((BetType='13' or BetType='15' or BetType='17') and betflag='X') then Amount else 0 end) as feeXh,";
            sql += "sum(case when ((BetType='13' or BetType='15' or BetType='17') and betflag='2') then Amount else 0 end) as fee2h";
            sql += " from orderdetail1x2_v ";
            sql += " where 1=1 " + whereSql;
            sql += " group by leaguetw,gameid ";
            sql += " limit " + limi;

            MySqlDataReader read = MySqlHelper.ExecuteReader(sql);
            return ObjectToJson.ReaderToJson(read);
        }

        public string Get1x22(string language, string league, string gameId, string agentUserName, string role, string limi, string mtype)
        {
            //过虑处理
            language = language.Replace("'", "");
            agentUserName = agentUserName.Replace("'", "");
            role = role.Replace("'", "");
            limi = limi.Replace("'", "");

            string[] leagueArr = league.Split(';');
            for (int i = 0; i < leagueArr.Length; i++)
            {
                if (i == 0)
                {
                    league = "'" + leagueArr[i].ToString() + "'";
                }
                else
                {
                    league += ",'" + leagueArr[i].ToString() + "'";
                }
            }
            league = league.Replace("''", "");
            gameId = gameId.Replace(";", ",");
            string lanSql = "";
            string whereSql = "";
            string sql = "";
            switch (language)
            {
                case "cn":
                    lanSql = "leaguecn as league,Homecn as Home,Awaycn as Away";
                    if (!string.IsNullOrEmpty(league))
                    {
                        whereSql = " and leaguecn in(" + league + ") ";
                    }
                    break;
                case "tw":
                    lanSql = "leaguetw as league,Hometw as Home,Awaytw as Away";
                    if (!string.IsNullOrEmpty(league))
                    {
                        whereSql = " and leaguetw in(" + league + ") ";
                    }

                    break;
                case "en":
                    lanSql = "leagueen as league,Homeen as Home,Awayen as Away";
                    if (!string.IsNullOrEmpty(league))
                    {
                        whereSql = " and leagueen in(" + league + ") ";
                    }
                    break;
                case "th":
                    lanSql = "leagueth as league,Hometh as Home,Awayth as Away";
                    if (!string.IsNullOrEmpty(league))
                    {
                        whereSql = " and leagueth in(" + league + ") ";
                    }
                    break;
                case "vn":
                    lanSql = "leaguevn as league,Homevn as Home,Awayvn as Away";
                    if (!string.IsNullOrEmpty(league))
                    {
                        whereSql = " and leaguevn in(" + league + ") ";
                    }
                    break;
            }
            if (!string.IsNullOrEmpty(gameId))
            {
                whereSql += " and gameid in(" + gameId + ") ";
            }
            if (!string.IsNullOrEmpty(agentUserName))
            {
                switch (role)
                {
                    case "2":
                        whereSql += " and SubCompany='" + agentUserName + "' ";
                        break;
                    case "3":
                        whereSql += " and Partner='" + agentUserName + "' ";
                        break;
                    case "4":
                        whereSql += " and ZAgent='" + agentUserName + "' ";
                        break;
                    case "5":
                        whereSql += " and Agent='" + agentUserName + "' ";
                        break;
                }
            }

            sql += "select begintime,gameid,";
            sql += lanSql + ",";
            if (mtype == "1")
            {
                //本币（人民币）
                sql += "sum((case when ((BetType='12' or BetType='14' or BetType='16') and betflag='1') then Amount else 0 end) * rate) as fee1f,";
                sql += "sum((case when ((BetType='12' or BetType='14' or BetType='16') and betflag='X') then Amount else 0 end) * rate) as feeXf,";
                sql += "sum((case when ((BetType='12' or BetType='14' or BetType='16') and betflag='2') then Amount else 0 end) * rate) as fee2f,";
                sql += "sum((case when ((BetType='13' or BetType='15' or BetType='17') and betflag='1') then Amount else 0 end) * rate) as fee1h,";
                sql += "sum((case when ((BetType='13' or BetType='15' or BetType='17') and betflag='X') then Amount else 0 end) * rate) as feeXh,";
                sql += "sum((case when ((BetType='13' or BetType='15' or BetType='17') and betflag='2') then Amount else 0 end) * rate) as fee2h";
            }
            else
            {
                sql += "sum(case when ((BetType='12' or BetType='14' or BetType='16') and betflag='1') then Amount else 0 end) as fee1f,";
                sql += "sum(case when ((BetType='12' or BetType='14' or BetType='16') and betflag='X') then Amount else 0 end) as feeXf,";
                sql += "sum(case when ((BetType='12' or BetType='14' or BetType='16') and betflag='2') then Amount else 0 end) as fee2f,";
                sql += "sum(case when ((BetType='13' or BetType='15' or BetType='17') and betflag='1') then Amount else 0 end) as fee1h,";
                sql += "sum(case when ((BetType='13' or BetType='15' or BetType='17') and betflag='X') then Amount else 0 end) as feeXh,";
                sql += "sum(case when ((BetType='13' or BetType='15' or BetType='17') and betflag='2') then Amount else 0 end) as fee2h";
            }
            sql += " from orderdetail1x2_v ";
            sql += " where 1=1 " + whereSql;
            sql += " group by leaguetw,gameid ";
            sql += " limit " + limi;

            MySqlDataReader read = MySqlHelper.ExecuteReader(sql);
            return ObjectToJson.ReaderToJson(read);
        }

        /// <summary>
        /// 会员注单
        /// </summary>
        /// <param name="userName">上级代理帐号</param>
        /// <param name="roleId">当前角色ID</param>
        /// <returns></returns>
        public string GetUserOrder(string userName, string roleId)
        {
            userName = userName.Replace("'", "");
            roleId = roleId.Replace("'", "");

            string subSql = "";
            string whereSql = "";
            string sql = "";
            switch (roleId)
            {
                case "2":
                    subSql = "subcompany";
                    break;
                case "3":
                    subSql = "Partner";
                    whereSql = " where subcompany='" + userName + "' ";
                    break;
                case "4":
                    subSql = "ZAgent";
                    whereSql = " where Partner='" + userName + "' ";
                    break;
                case "5":
                    subSql = "Agent";
                    whereSql = " where ZAgent='" + userName + "' ";
                    break;
                case "6":
                    subSql = "UserName";
                    whereSql = " where Agent='" + userName + "' ";
                    break;
            }
            sql += "select " + subSql + " as userName,";
            sql += "sum(validamount) as amount,";
            sql += "sum(validamount*agentpercent) as agentAmount,";
            sql += "sum(validamount*ZagentPercent) as zagentAmount,";
            sql += "sum(validamount*PartnerPercent) as partnerAmount,";
            sql += "sum(validamount*SubcompanyPercent) as subcompanyAmount,";
            sql += "sum(validamount*CompanyPercent) as companyAmount";
            sql += " from orderall ";
            sql += whereSql;
            sql += " group by " + subSql;

            MySqlDataReader read = MySqlHelper.ExecuteReader(sql);
            return ObjectToJson.ReaderToJson(read);
        }


        #region 编写人:李毅
        /// <summary>
        /// 根据联赛名称，比赛ID，当前语言查询
        /// </summary>
        /// <param name="league">联赛名称</param>
        /// <param name="game">比赛ID</param>
        /// <param name="language">语言</param>
        /// <returns></returns>
        public string GetAllToJson(string league,string game,string language,string username,string roid)
        {
            bool pd = false;
            string str1 = "select distinct league" + language + ",gameid from orderdetail_v ";
            if (league != "")
            {
                str1 += " where (league" + language + " in(" + league + ") ";
                pd = true;
            }
            if (pd)
            {
                if (game != "")
                {
                    str1 += " or gameid in(" + game + "))";
                }
                else
                {
                    str1 += ")";
                }
            }
            else
            {
                if (game != "")
                {
                    str1 += " where (gameid in(" + game + "))";
                }
            }
            str1 += " group by league" + language + ",gameid ";
            MySqlDataReader read = MySqlHelper.ExecuteReader(str1);
            List<string> s = new List<string>();
            while (read.Read())
            {
                s.Add(read.GetString("gameid"));
            }
            string alist = "[";
            for (int i = 0; i < s.Count; i++)
            {
                string s1 = "select count(*) from orderdetail_v where gameid=" + s[i] + " and Status=1 ";
                if (username != "" && roid != "")
                {
                    s1 += " and " + roid + "='" + username + "'";
                }
                if (MySqlHelper.ExecuteScalar(s1).ToString() != "0")
                {
                    string s2 = "select distinct ID,UserName,OrderID,(case  when (BetType<8 and BetType>3) or BetType=14 or"
                    + " BetType=15 then '滚球' else ''  end) as IsGun,league" + language + " as league,Home" + language + " as Home,Away" + language + " as "
                    + " Away,BeginTime,betflag,IsHalf,gameid from orderdetail_v where gameid= " + s[i] + " and Status=1 ";
                    if (username != "" && roid != "")
                    {
                        s2 += " and " + roid + "='" + username + "'";
                    }
                    alist += "[";
                    MySqlDataReader r = MySqlHelper.ExecuteReader(s2);
                    while (r.Read())
                    {
                        alist += "'" + r.GetString("ID") + "',";//0
                        alist += "'" + r.GetString("UserName") + "',";//1
                        alist += "'" + r.GetString("OrderID") + "',";//2
                        alist += "'" + r.GetString("IsGun") + "',";//3
                        alist += "'" + r.GetString("league") + "',";//4
                        alist += "'" + r.GetString("Home") + "',";//5
                        alist += "'" + r.GetString("Away") + "',";//6
                        alist += "'" + r.GetString("BeginTime") + "',";//7
                        alist += "'" + r.GetString("betflag") + "',";//8
                        alist += "'" + r.GetString("IsHalf") + "',";//9
                        alist += "'" + r.GetString("gameid") + "',";//10
                        break;
                    }
                    r.Close();
                    s2 = "select distinct"
                        + "(case when (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=1 and betflag='H'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "")
                        + ") is null then '0' else (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=1 and betflag='H'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "") + " ) end) as a,"
+ "(case when (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=1 and betflag='A'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "")
+ ") is null then '0' else (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=1 and betflag='A'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "") + ") end) as b,"
+ "(case when (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=1 and betflag='O'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "")
+ ") is null then '0' else (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=1 and betflag='O'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "") + ") end) as c,"
+ "(case when (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=1 and betflag='U'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "")
+ ") is null then '0' else (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=1 and betflag='U'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "") + ") end) as d,"
+ "(case when (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=1 and betflag='1'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "")
+ ") is null then '0' else (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=1 and betflag='1'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "") + ") end) as e,"
+ "(case when (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=1 and betflag='X'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "")
+ ") is null then '0' else (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=1 and betflag='X'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "") + ") end) as f,"
+ "(case when (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=1 and betflag='2'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "")
+ ") is null then '0' else (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=1 and betflag='2'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "") + ") end) as g,"

+ "(case when (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=0 and betflag='H'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "")
+ ") is null then '0' else (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=0 and betflag='H'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "") + ") end) as h,"
+ "(case when (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=0 and betflag='A'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "")
+ ") is null then '0' else (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=0 and betflag='A'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "") + ") end) as i,"
+ "(case when (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=0 and betflag='O'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "")
+ ") is null then '0' else (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=0 and betflag='O'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "") + ") end) as j,"
+ "(case when (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=0 and betflag='U'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "")
+ ") is null then '0' else (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=0 and betflag='U'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "") + ") end) as k,"
+ "(case when (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=0 and betflag='1'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "")
+ ") is null then '0' else (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=0 and betflag='1'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "") + ") end) as l,"
+ "(case when (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=0 and betflag='X'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "")
+ ") is null then '0' else (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=0 and betflag='X'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "") + ") end) as m,"
+ "(case when (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=0 and betflag='2'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "")
+ ") is null then '0' else (select sum(Amount) from orderdetail_v where gameid=" + s[i] + " and Status=1 and IsHalf=0 and betflag='2'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "") + ") end) as n from orderdetail_v ";
                    MySqlDataReader r1 = MySqlHelper.ExecuteReader(s2);
                    while (r1.Read())
                    {
                        alist += "'" + r1.GetString("a") + "',";//11
                        alist += "'" + r1.GetString("b") + "',";//12
                        alist += "'" + r1.GetString("c") + "',";//13
                        alist += "'" + r1.GetString("d") + "',";//14
                        alist += "'" + r1.GetString("e") + "',";//15
                        alist += "'" + r1.GetString("f") + "',";//16
                        alist += "'" + r1.GetString("g") + "',";//17

                        alist += "'" + r1.GetString("h") + "',";//18
                        alist += "'" + r1.GetString("i") + "',";//19
                        alist += "'" + r1.GetString("j") + "',";//20
                        alist += "'" + r1.GetString("k") + "',";//21
                        alist += "'" + r1.GetString("l") + "',";//22
                        alist += "'" + r1.GetString("m") + "',";//23
                        alist += "'" + r1.GetString("n") + "'";//24
                    }
                    r1.Close();
                    alist += "],";
                }
            }
            alist = alist.Substring(0, alist.Length - 1);
            alist += "]";
            return alist;
        }

        /// <summary>
        /// 根据表名,比赛ID以及下注类型查询注单
        /// </summary>
        /// <param name="table1">表1名</param>
        /// <param name="table2">表2名</param>
        /// <param name="type">下注类型(H:主队,A:客队,O:大,U:小,X:标准)</param>
        /// <param name="game">比赛ID</param>
        /// <returns></returns>
        public string GetDataByType(string table1, string table2, string type, string game, string username, string roid)
        {

            string str = "select * from " + table1 + " where betflag='" + type + "' and Status=1 and gameid=" + game;
            if (username != "" && roid != "")
            {
                str += " and " + roid + "='" + username + "'";
            }
            str += " union select * from " + table2 + " where betflag='" + type + "' and Status=1 and gameid=" + game;
            if (username != "" && roid != "")
            {
                str += " and " + roid + "='" + username + "'";
            }
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        /// <summary>
        /// 根据表名,比赛ID查询注单
        /// </summary>
        /// <param name="table1">表1名</param>
        /// <param name="table2">表2名</param>
        /// <param name="game">比赛ID</param>
        /// <returns></returns>
        public string GetDataByType(string table1, string table2, string game)
        {

            string str = "select * from " + table1 + " union select * from " + table2 + " where gameid=" + game + " and Status=1";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        /// <summary>
        /// 标准盘信息
        /// </summary>
        /// <param name="league"></param>
        /// <param name="game"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public string GetData1x2(string league, string game, string language,string username,string roid)
        {
            string str1 = "select distinct league" + language + ",gameid from orderdetail1x2_v ";
            if (league != "")
            {
                str1 += " where league" + language + " in(" + league + ") ";
            }
            str1+=" group by league" + language+",gameid";
            MySqlDataReader read = MySqlHelper.ExecuteReader(str1);
            List<string> s = new List<string>();
            while (read.Read())
            {
                s.Add(read.GetString("gameid"));
            }
            string alist = "[";
            for (int i = 0; i < s.Count; i++)
            {
                string s1 = "select count(*) from orderdetail1x2_v where gameid=" + s[i] + " and Status=1 ";
                if (username != "" && roid != "")
                {
                    s1 += " and " + roid + "='" + username + "'";
                }
                if (MySqlHelper.ExecuteScalar(s1).ToString() != "0")
                {
                    string s2 = "select distinct ID,UserName,OrderID,(case  when (BetType<8 and BetType>3) or BetType=14 or"
                    + " BetType=15 then '滚球' else ''  end) as IsGun,league" + language + " as league,Home" + language + " as Home,Away" + language + " as "
                    + " Away,BeginTime,betflag,IsHalf,gameid from orderdetail1x2_v where gameid= " + s[i] + " and Status=1 ";
                    if (username != "" && roid != "")
                    {
                        s2 += " and " + roid + "='" + username + "'";
                    }
                    alist += "[";
                    MySqlDataReader r = MySqlHelper.ExecuteReader(s2);
                    while (r.Read())
                    {
                        alist += "'" + r.GetString("ID") + "',";//0
                        alist += "'" + r.GetString("UserName") + "',";//1
                        alist += "'" + r.GetString("OrderID") + "',";//2
                        alist += "'" + r.GetString("IsGun") + "',";//3
                        alist += "'" + r.GetString("league") + "',";//4
                        alist += "'" + r.GetString("Home") + "',";//5
                        alist += "'" + r.GetString("Away") + "',";//6
                        alist += "'" + r.GetString("BeginTime") + "',";//7
                        alist += "'" + r.GetString("betflag") + "',";//8
                        alist += "'" + r.GetString("IsHalf") + "',";//9
                        alist += "'" + r.GetString("gameid") + "',";//10
                        break;
                    }
                    r.Close();
                    s2 = "select distinct"
                        + "(case when (select sum(Amount) from orderdetail1x2_v where gameid=" + s[i] + " and Status=1 and IsHalf=1 and betflag='1'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "")
                        + ") is null then '0' else (select sum(Amount) from orderdetail1x2_v where gameid=" + s[i] + " and Status=1 and IsHalf=1 and betflag='1'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "") + " ) end) as a,"
+ "(case when (select sum(Amount) from orderdetail1x2_v where gameid=" + s[i] + " and Status=1 and IsHalf=1 and betflag='X'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "")
+ ") is null then '0' else (select sum(Amount) from orderdetail1x2_v where gameid=" + s[i] + " and Status=1 and IsHalf=1 and betflag='X'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "") + ") end) as b,"
+ "(case when (select sum(Amount) from orderdetail1x2_v where gameid=" + s[i] + " and Status=1 and IsHalf=1 and betflag='2'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "")
+ ") is null then '0' else (select sum(Amount) from orderdetail1x2_v where gameid=" + s[i] + " and Status=1 and IsHalf=1 and betflag='2'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "") + ") end) as c,"

+ "(case when (select sum(Amount) from orderdetail1x2_v where gameid=" + s[i] + " and Status=1 and IsHalf=0 and betflag='1'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "")
+ ") is null then '0' else (select sum(Amount) from orderdetail1x2_v where gameid=" + s[i] + " and Status=1 and IsHalf=0 and betflag='1'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "") + ") end) as d,"
+ "(case when (select sum(Amount) from orderdetail1x2_v where gameid=" + s[i] + " and Status=1 and IsHalf=0 and betflag='X'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "")
+ ") is null then '0' else (select sum(Amount) from orderdetail1x2_v where gameid=" + s[i] + " and Status=1 and IsHalf=0 and betflag='X'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "") + ") end) as e,"
+ "(case when (select sum(Amount) from orderdetail1x2_v where gameid=" + s[i] + " and Status=1 and IsHalf=0 and betflag='2'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "")
+ ") is null then '0' else (select sum(Amount) from orderdetail1x2_v where gameid=" + s[i] + " and Status=1 and IsHalf=0 and betflag='2'" + (username != "" && roid != "" ? "and " + roid + "='" + username + "'" : "") + ") end) as f "
+" from orderdetail1x2_v ";
                    MySqlDataReader r1 = MySqlHelper.ExecuteReader(s2);
                    while (r1.Read())
                    {
                        alist += "'" + r1.GetString("a") + "',";//11
                        alist += "'" + r1.GetString("b") + "',";//12
                        alist += "'" + r1.GetString("c") + "',";//13

                        alist += "'" + r1.GetString("d") + "',";//14
                        alist += "'" + r1.GetString("e") + "',";//15
                        alist += "'" + r1.GetString("f") + "'";//16
                    }
                    r1.Close();
                    alist += "],";
                }
            }
            alist = alist.Substring(0, alist.Length - 1);
            alist += "]";
            return alist;
        }
        #endregion
    }
}
