using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class OrderhistoryService
	{
        private const string SQL_INSERT = "insert into yafa.orderhistory (UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Scoreathalf,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,Result,Member,MemberPercent,MemberCommission,Scorehalf,rate)values(?UserName,?OrderID,?time,?leaguecn,?leaguetw,?leagueen,?leagueth,?leaguevn,?Homecn,?Hometw,?Homeen,?Hometh,?Homevn,?Awaycn,?Awaytw,?Awayen,?Awayth,?Awayvn,?BeginTime,?BetType,?IsHalf,?BetItem,?Scoreathalf,?Score,?Handicap,?Odds,?OddsType,?Amount,?ValidAmount,?Status,?Agent,?AgentPercent,?AgentCommission,?ZAgentPercent,?ZAgent,?ZAgentCommission,?PartnerPercent,?PartnerCommission,?Partner,?CompanyPercent,?CompanyCommission,?IP,?SubCompany,?SubCompanyCommission,?SubCompanyPercent,?WebSiteiID,?UserLevel,?Coefficient,?Proportion,?Currency,?Reason,?gameid,?betflag,?Result,?Member,?MemberPercent,?MemberCommission,?Scorehalf,?Rate)";
        private const string SQL_UPDATE = "update yafa.orderhistory set UserName=?UserName,OrderID=?OrderID,time=?time,leaguecn=?leaguecn,leaguetw=?leaguetw,leagueen=?leagueen,leagueth=?leagueth,leaguevn=?leaguevn,Homecn=?Homecn,Hometw=?Hometw,Homeen=?Homeen,Hometh=?Hometh,Homevn=?Homevn,Awaycn=?Awaycn,Awaytw=?Awaytw,Awayen=?Awayen,Awayth=?Awayth,Awayvn=?Awayvn,BeginTime=?BeginTime,BetType=?BetType,IsHalf=?IsHalf,BetItem=?BetItem,Scoreathalf=?Scoreathalf,Score=?Score,Handicap=?Handicap,Odds=?Odds,OddsType=?OddsType,Amount=?Amount,ValidAmount=?ValidAmount,Status=?Status,Agent=?Agent,AgentPercent=?AgentPercent,AgentCommission=?AgentCommission,ZAgentPercent=?ZAgentPercent,ZAgent=?ZAgent,ZAgentCommission=?ZAgentCommission,PartnerPercent=?PartnerPercent,PartnerCommission=?PartnerCommission,Partner=?Partner,CompanyPercent=?CompanyPercent,CompanyCommission=?CompanyCommission,IP=?IP,SubCompany=?SubCompany,SubCompanyCommission=?SubCompanyCommission,SubCompanyPercent=?SubCompanyPercent,WebSiteiID=?WebSiteiID,UserLevel=?UserLevel,Coefficient=?Coefficient,Proportion=?Proportion,Currency=?Currency,Reason=?Reason,gameid=?gameid,betflag=?betflag,Result=?Result,Member=?Member,MemberPercent=?MemberPercent,MemberCommission=?MemberCommission,Scorehalf=?Scorehalf where ID = ?ID";
        private const string SQL_SELECTBYPK = "select ID from yafa.orderhistory  where orderhistory.ID = ?ID";
        private const string SQL_SELECTALL = "select ID,UserName,OrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,Homecn,Hometw,Homeen,Hometh,Homevn,Awaycn,Awaytw,Awayen,Awayth,Awayvn,BeginTime,BetType,IsHalf,BetItem,Scoreathalf,Score,Handicap,Odds,OddsType,Amount,ValidAmount,Status,Agent,AgentPercent,AgentCommission,ZAgentPercent,ZAgent,ZAgentCommission,PartnerPercent,PartnerCommission,Partner,CompanyPercent,CompanyCommission,IP,SubCompany,SubCompanyCommission,SubCompanyPercent,WebSiteiID,UserLevel,Coefficient,Proportion,Currency,Reason,gameid,betflag,Result,Member,MemberPercent,MemberCommission,Scorehalf from yafa.orderhistory ";
        private const string SQL_DELETEBYPK = "delete  from yafa.orderhistory  where orderhistory.ID = ?ID";

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失�?	
        ///生成时间�?010-10-29 15:34:47		
        ///</summary>		
        public Boolean AddOrderhistory(Orderhistory orderhistory)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderhistory.UserName),
				 new MySqlParameter("?OrderID",orderhistory.OrderID),
				 new MySqlParameter("?time",orderhistory.Time),
				 new MySqlParameter("?leaguecn",orderhistory.Leaguecn),
				 new MySqlParameter("?leaguetw",orderhistory.Leaguetw),
				 new MySqlParameter("?leagueen",orderhistory.Leagueen),
				 new MySqlParameter("?leagueth",orderhistory.Leagueth),
				 new MySqlParameter("?leaguevn",orderhistory.Leaguevn),
				 new MySqlParameter("?Homecn",orderhistory.Homecn),
				 new MySqlParameter("?Hometw",orderhistory.Hometw),
				 new MySqlParameter("?Homeen",orderhistory.Homeen),
				 new MySqlParameter("?Hometh",orderhistory.Hometh),
				 new MySqlParameter("?Homevn",orderhistory.Homevn),
				 new MySqlParameter("?Awaycn",orderhistory.Awaycn),
				 new MySqlParameter("?Awaytw",orderhistory.Awaytw),
				 new MySqlParameter("?Awayen",orderhistory.Awayen),
				 new MySqlParameter("?Awayth",orderhistory.Awayth),
				 new MySqlParameter("?Awayvn",orderhistory.Awayvn),
				 new MySqlParameter("?BeginTime",orderhistory.BeginTime),
				 new MySqlParameter("?BetType",orderhistory.BetType),
				 new MySqlParameter("?IsHalf",orderhistory.IsHalf),
				 new MySqlParameter("?BetItem",orderhistory.BetItem),
				 new MySqlParameter("?Scoreathalf",orderhistory.Scoreathalf),
				 new MySqlParameter("?Score",orderhistory.Score),
				 new MySqlParameter("?Handicap",orderhistory.Handicap),
				 new MySqlParameter("?Odds",orderhistory.Odds),
				 new MySqlParameter("?OddsType",orderhistory.OddsType),
				 new MySqlParameter("?Amount",orderhistory.Amount),
				 new MySqlParameter("?ValidAmount",orderhistory.ValidAmount),
				 new MySqlParameter("?Status",orderhistory.Status),
				 new MySqlParameter("?Agent",orderhistory.Agent),
				 new MySqlParameter("?AgentPercent",orderhistory.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderhistory.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderhistory.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderhistory.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderhistory.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderhistory.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderhistory.PartnerCommission),
				 new MySqlParameter("?Partner",orderhistory.Partner),
				 new MySqlParameter("?CompanyPercent",orderhistory.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderhistory.CompanyCommission),
				 new MySqlParameter("?IP",orderhistory.IP),
				 new MySqlParameter("?SubCompany",orderhistory.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderhistory.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderhistory.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderhistory.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderhistory.UserLevel),
				 new MySqlParameter("?Coefficient",orderhistory.Coefficient),
				 new MySqlParameter("?Proportion",orderhistory.Proportion),
				 new MySqlParameter("?Currency",orderhistory.Currency),
				 new MySqlParameter("?Reason",orderhistory.Reason),
				 new MySqlParameter("?gameid",orderhistory.Gameid),
				 new MySqlParameter("?betflag",orderhistory.Betflag),
				 new MySqlParameter("?Result",orderhistory.Result),
				 new MySqlParameter("?Member",orderhistory.Member),
				 new MySqlParameter("?MemberPercent",orderhistory.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderhistory.MemberCommission),
				 new MySqlParameter("?Scorehalf",orderhistory.Scorehalf),
                 new MySqlParameter("?Rate",orderhistory.Rate)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失�?	
        ///生成时间�?010-10-29 15:34:47		
        ///</summary>		
        public Boolean UpdateOrderhistory(Orderhistory orderhistory)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderhistory.UserName),
				 new MySqlParameter("?OrderID",orderhistory.OrderID),
				 new MySqlParameter("?time",orderhistory.Time),
				 new MySqlParameter("?leaguecn",orderhistory.Leaguecn),
				 new MySqlParameter("?leaguetw",orderhistory.Leaguetw),
				 new MySqlParameter("?leagueen",orderhistory.Leagueen),
				 new MySqlParameter("?leagueth",orderhistory.Leagueth),
				 new MySqlParameter("?leaguevn",orderhistory.Leaguevn),
				 new MySqlParameter("?Homecn",orderhistory.Homecn),
				 new MySqlParameter("?Hometw",orderhistory.Hometw),
				 new MySqlParameter("?Homeen",orderhistory.Homeen),
				 new MySqlParameter("?Hometh",orderhistory.Hometh),
				 new MySqlParameter("?Homevn",orderhistory.Homevn),
				 new MySqlParameter("?Awaycn",orderhistory.Awaycn),
				 new MySqlParameter("?Awaytw",orderhistory.Awaytw),
				 new MySqlParameter("?Awayen",orderhistory.Awayen),
				 new MySqlParameter("?Awayth",orderhistory.Awayth),
				 new MySqlParameter("?Awayvn",orderhistory.Awayvn),
				 new MySqlParameter("?BeginTime",orderhistory.BeginTime),
				 new MySqlParameter("?BetType",orderhistory.BetType),
				 new MySqlParameter("?IsHalf",orderhistory.IsHalf),
				 new MySqlParameter("?BetItem",orderhistory.BetItem),
				 new MySqlParameter("?Scoreathalf",orderhistory.Scoreathalf),
				 new MySqlParameter("?Score",orderhistory.Score),
				 new MySqlParameter("?Handicap",orderhistory.Handicap),
				 new MySqlParameter("?Odds",orderhistory.Odds),
				 new MySqlParameter("?OddsType",orderhistory.OddsType),
				 new MySqlParameter("?Amount",orderhistory.Amount),
				 new MySqlParameter("?ValidAmount",orderhistory.ValidAmount),
				 new MySqlParameter("?Status",orderhistory.Status),
				 new MySqlParameter("?Agent",orderhistory.Agent),
				 new MySqlParameter("?AgentPercent",orderhistory.AgentPercent),
				 new MySqlParameter("?AgentCommission",orderhistory.AgentCommission),
				 new MySqlParameter("?ZAgentPercent",orderhistory.ZAgentPercent),
				 new MySqlParameter("?ZAgent",orderhistory.ZAgent),
				 new MySqlParameter("?ZAgentCommission",orderhistory.ZAgentCommission),
				 new MySqlParameter("?PartnerPercent",orderhistory.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",orderhistory.PartnerCommission),
				 new MySqlParameter("?Partner",orderhistory.Partner),
				 new MySqlParameter("?CompanyPercent",orderhistory.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",orderhistory.CompanyCommission),
				 new MySqlParameter("?IP",orderhistory.IP),
				 new MySqlParameter("?SubCompany",orderhistory.SubCompany),
				 new MySqlParameter("?SubCompanyCommission",orderhistory.SubCompanyCommission),
				 new MySqlParameter("?SubCompanyPercent",orderhistory.SubCompanyPercent),
				 new MySqlParameter("?WebSiteiID",orderhistory.WebSiteiID),
				 new MySqlParameter("?UserLevel",orderhistory.UserLevel),
				 new MySqlParameter("?Coefficient",orderhistory.Coefficient),
				 new MySqlParameter("?Proportion",orderhistory.Proportion),
				 new MySqlParameter("?Currency",orderhistory.Currency),
				 new MySqlParameter("?Reason",orderhistory.Reason),
				 new MySqlParameter("?gameid",orderhistory.Gameid),
				 new MySqlParameter("?betflag",orderhistory.Betflag),
				 new MySqlParameter("?Result",orderhistory.Result),
				 new MySqlParameter("?Member",orderhistory.Member),
				 new MySqlParameter("?MemberPercent",orderhistory.MemberPercent),
				 new MySqlParameter("?MemberCommission",orderhistory.MemberCommission),
				 new MySqlParameter("?Scorehalf",orderhistory.Scorehalf),
				 new MySqlParameter("?ID",orderhistory.ID)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失�?	
        ///生成时间�?010-10-29 15:34:47		
        ///</summary>		
        public Boolean DeleteOrderhistoryByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间�?010-10-29 15:34:47		
        ///</summary>		
        public Orderhistory GetOrderhistoryByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

            return MySqlModelHelper<Orderhistory>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间�?010-10-29 15:34:47		
        ///</summary>		
        public IList<Orderhistory> GetMutilILOrderhistory()
        {
            return MySqlModelHelper<Orderhistory>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间�?010-10-29 15:34:47		
        ///</summary>		
        public DataTable GetMutilDTOrderhistory()
        {
            return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion 
	
        public string GetMatchAll(string time1, string time2, string language, string status, string agentName, string roleId)
        {
            string time = "";
            if (time1 == time2)
            {
                time = time1;
            }
            string mysql = "";
            string group = "";
            if (language == "zh-cn" || language == "zh-CN")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
                group = " group by leaguetw,Hometw,Awaytw,BetType";
            }
            if (language == "zh-tw")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
                group = " group by leaguetw,Hometw,Awaytw,BetType";
            }
            if (language == "en-us")
            {
                mysql = "leagueen as league,Homeen as Home,Awayen as Away";
                group = " group by leagueen,Homeen,Awayen,BetType";
            }
            if (language == "th-th")
            {
                mysql = "leagueth as league,Hometh as Home,Awayth as Away";
                group = " group by leagueth,Homecn,Awayth,BetType";
            }
            if (language == "vi-vn")
            {
                mysql = "leaguevn as league,Homevn as Home,Awayvn as Away";
                group = " group by leaguevn,Homevn,Awayvn,BetType";
            }
            //string str = "select " + mysql + ",BeginTime,Score,Scorehalf,BetType,Odds,BetItem,Amount,ValidAmount,Result,Member,MemberPercent,MemberCommission,AgentPercent,AgentCommission,ZAgentPercent,ZAgentCommission,PartnerPercent,PartnerCommission,CompanyPercent,CompanyCommission,SubCompanyCommission,SubCompanyPercent,Reason,date(BeginTime) from yafa.orderhistory where Status='" + status + "'";
            string str = "select " + mysql + ",BeginTime,Score,Scorehalf,BetType,Odds,BetItem,max(gameid) as gameid,";
            //str += "sum(Amount) as Amount,sum(ValidAmount) as ValidAmount,sum(Result) as Result,Member,";
            //str += "sum((case when Result>0 then 0 else abs(Result)*SubCompanyCommission end)) as Commission,";
            //str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end)) as Members,";
            //str += "sum((case when Result>0 then 0 else (abs(Result)*AgentPercent * MemberCommission) end)) as MemberCommission,";
            //str += "sum((-(Result)* AgentPercent)) as Agent,";
            //str += "sum((case when Result>0 then 0 when MemberCommission=0  then  abs( Result ) *ZAgentPercent * AgentCommission   else  abs(Result) * ZAgentPercent *  AgentCommission -  abs( Result)  * AgentPercent* MemberCommission  end)) as AgentCommission,";
            //str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
            //str += "sum((case when Result>0 then 0 when AgentCommission=0  then  abs( Result ) *PartnerPercent* ZAgentCommission   else  abs(Result) *PartnerPercent* ZAgentCommission -  abs( Result)  * ZAgentPercent* AgentCommission end)) as ZAgentCommission,";
            //str += "sum(( -(Result)* PartnerPercent)) as Partner,";
            //str += "sum((case when Result>0 then 0 when ZAgentCommission=0  then  abs( Result ) *SubCompanyPercent* PartnerCommission  else abs(Result) *SubCompanyPercent* PartnerCommission -  abs( Result)  * PartnerPercent* ZAgentCommission end)) as PartnerCommission,";
            //str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
            //str += "sum(case when Result>0 then 0  when PartnerCommission=0 then  abs(Result)*CompanyPercent* SubCompanyCommission  else abs(Result) *CompanyPercent* SubCompanyCommission - abs( Result)*SubCompanyPercent*PartnerCommission  end)  as SubCompanyCommission,";
            //str += "sum((case when Result>0 then  -(Result) *CompanyPercent when SubCompanyCommission=0 then  abs(Result) *CompanyPercent  else abs(Result) *CompanyPercent - abs(Result) *CompanyPercent*SubCompanyCommission end)) as Companys,";
            //str += "sum((case when Result>0 then 0 else Result*SubCompanyCommission  end)) as CompanyCommission,";

            //str += "sum(Amount) as Amount,sum(ValidAmount) as ValidAmount,sum(abs(Result)) as Result,Member,";
            //str += "sum(abs(Result)*SubCompanyCommission) as Commission,";
            //str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end)) as Members,";
            //str += "sum((abs(Result)*AgentPercent * MemberCommission)) as MemberCommission,";
            //str += "sum((-(Result)* AgentPercent)) as Agent,";
            //str += "sum((case when MemberCommission=0  then  abs( Result ) *ZAgentPercent * AgentCommission   else  abs(Result) * ZAgentPercent *  AgentCommission -  abs( Result)  * AgentPercent* MemberCommission  end)) as AgentCommission,";
            //str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
            //str += "sum((case when AgentCommission=0  then  abs( Result ) *PartnerPercent* ZAgentCommission   else  abs(Result) *PartnerPercent* ZAgentCommission -  abs( Result)  * ZAgentPercent* AgentCommission end)) as ZAgentCommission,";
            //str += "sum(( -(Result)* PartnerPercent)) as Partner,";
            //str += "sum((case when ZAgentCommission=0  then  abs( Result ) *SubCompanyPercent* PartnerCommission  else abs(Result) *SubCompanyPercent* PartnerCommission -  abs( Result)  * PartnerPercent* ZAgentCommission end)) as PartnerCommission,";
            //str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
            //str += "sum(case  when PartnerCommission=0 then  abs(Result)*CompanyPercent* SubCompanyCommission  else abs(Result) *CompanyPercent* SubCompanyCommission - abs( Result)*SubCompanyPercent*PartnerCommission  end)  as SubCompanyCommission,";
            //str += "sum((case when SubCompanyCommission=0 then  -(Result) *CompanyPercent  else -(Result) *CompanyPercent - abs(Result) *CompanyPercent*SubCompanyCommission end)) as Companys,";
            //str += "sum(abs(Result)*CompanyPercent*SubCompanyCommission) as CompanyCommission,";

            str += "sum(Amount) as Amount,sum(ValidAmount) as ValidAmount,sum(abs(Result)) as Result,Member,";
            str += "sum((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*MemberCommission) as Commission,";
            str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end)) as Members,";
            str += "sum((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission) as MemberCommission,";
            str += "sum((-(Result)* AgentPercent)) as Agent,";
            str += "sum((case when MemberCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) * AgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) *  AgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission  end)) as AgentCommission,";
            str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
            str += "sum((case when AgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent)* AgentCommission end)) as ZAgentCommission,";
            str += "sum(( -(Result)* PartnerPercent)) as Partner,";
            str += "sum((case when ZAgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission end)) as PartnerCommission,";
            str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
            str += "sum(case when PartnerCommission=0 then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*CompanyPercent* SubCompanyCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent* SubCompanyCommission - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*(SubCompanyPercent+CompanyPercent)*PartnerCommission  end)  as SubCompanyCommission,";
            str += "sum((case when SubCompanyCommission=0 then  -(Result) *CompanyPercent  else -(Result) *CompanyPercent - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent*SubCompanyCommission end)) as Companys,";
            str += "sum(-((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*CompanyPercent*SubCompanyCommission)) as CompanyCommission,";

            str += "Reason,date(BeginTime) from yafa.orderhistory where Status='" + status + "'";
            if (!string.IsNullOrEmpty(agentName))
            {
                switch (roleId)
                {
                    case "2":
                        str += " and SubCompany='" + agentName + "' ";
                        break;
                    case "3":
                        str += " and Partner='" + agentName + "' ";
                        break;
                    case "4":
                        str += " and ZAgent='" + agentName + "' ";
                        break;
                    case "5":
                        str += " and Agent='" + agentName + "' ";
                        break;
                }
            }
            if (time != "")
            {
                str += " and date(BeginTime)='" + time + "'"+group;
            }
            else
            {
                str += " and date(BeginTime)>='" + time1 + "' and date(BeginTime)<= '" + time2 + "'"+group;
            }

            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        public string GetMatchAll2(string time1, string time2, string language, string status, string agentName, string roleId, string mtype)
        {
            string time = "";
            if (time1 == time2)
            {
                time = time1;
            }
            string mysql = "";
            string group = "";
            if (language == "zh-cn" || language == "zh-CN")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
                group = " group by leaguetw,Hometw,Awaytw,BetType";
            }
            if (language == "zh-tw")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
                group = " group by leaguetw,Hometw,Awaytw,BetType";
            }
            if (language == "en-us")
            {
                mysql = "leagueen as league,Homeen as Home,Awayen as Away";
                group = " group by leagueen,Homeen,Awayen,BetType";
            }
            if (language == "th-th")
            {
                mysql = "leagueth as league,Hometh as Home,Awayth as Away";
                group = " group by leagueth,Homecn,Awayth,BetType";
            }
            if (language == "vi-vn")
            {
                mysql = "leaguevn as league,Homevn as Home,Awayvn as Away";
                group = " group by leaguevn,Homevn,Awayvn,BetType";
            }
            //string str = "select " + mysql + ",BeginTime,Score,Scorehalf,BetType,Odds,BetItem,Amount,ValidAmount,Result,Member,MemberPercent,MemberCommission,AgentPercent,AgentCommission,ZAgentPercent,ZAgentCommission,PartnerPercent,PartnerCommission,CompanyPercent,CompanyCommission,SubCompanyCommission,SubCompanyPercent,Reason,date(BeginTime) from yafa.orderhistory where Status='" + status + "'";
            string str = "select " + mysql + ",BeginTime,Score,Scorehalf,BetType,Odds,BetItem,max(gameid) as gameid,";
            //str += "sum(Amount) as Amount,sum(ValidAmount) as ValidAmount,sum(Result) as Result,Member,";
            //str += "sum((case when Result>0 then 0 else abs(Result)*SubCompanyCommission end)) as Commission,";
            //str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end)) as Members,";
            //str += "sum((case when Result>0 then 0 else (abs(Result)*AgentPercent * MemberCommission) end)) as MemberCommission,";
            //str += "sum((-(Result)* AgentPercent)) as Agent,";
            //str += "sum((case when Result>0 then 0 when MemberCommission=0  then  abs( Result ) *ZAgentPercent * AgentCommission   else  abs(Result) * ZAgentPercent *  AgentCommission -  abs( Result)  * AgentPercent* MemberCommission  end)) as AgentCommission,";
            //str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
            //str += "sum((case when Result>0 then 0 when AgentCommission=0  then  abs( Result ) *PartnerPercent* ZAgentCommission   else  abs(Result) *PartnerPercent* ZAgentCommission -  abs( Result)  * ZAgentPercent* AgentCommission end)) as ZAgentCommission,";
            //str += "sum(( -(Result)* PartnerPercent)) as Partner,";
            //str += "sum((case when Result>0 then 0 when ZAgentCommission=0  then  abs( Result ) *SubCompanyPercent* PartnerCommission  else abs(Result) *SubCompanyPercent* PartnerCommission -  abs( Result)  * PartnerPercent* ZAgentCommission end)) as PartnerCommission,";
            //str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
            //str += "sum(case when Result>0 then 0  when PartnerCommission=0 then  abs(Result)*CompanyPercent* SubCompanyCommission  else abs(Result) *CompanyPercent* SubCompanyCommission - abs( Result)*SubCompanyPercent*PartnerCommission  end)  as SubCompanyCommission,";
            //str += "sum((case when Result>0 then  -(Result) *CompanyPercent when SubCompanyCommission=0 then  abs(Result) *CompanyPercent  else abs(Result) *CompanyPercent - abs(Result) *CompanyPercent*SubCompanyCommission end)) as Companys,";
            //str += "sum((case when Result>0 then 0 else Result*SubCompanyCommission  end)) as CompanyCommission,";

            //str += "sum(Amount) as Amount,sum(ValidAmount) as ValidAmount,sum(abs(Result)) as Result,Member,";
            //str += "sum(abs(Result)*SubCompanyCommission) as Commission,";
            //str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end)) as Members,";
            //str += "sum((abs(Result)*AgentPercent * MemberCommission)) as MemberCommission,";
            //str += "sum((-(Result)* AgentPercent)) as Agent,";
            //str += "sum((case when MemberCommission=0  then  abs( Result ) *ZAgentPercent * AgentCommission   else  abs(Result) * ZAgentPercent *  AgentCommission -  abs( Result)  * AgentPercent* MemberCommission  end)) as AgentCommission,";
            //str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
            //str += "sum((case when AgentCommission=0  then  abs( Result ) *PartnerPercent* ZAgentCommission   else  abs(Result) *PartnerPercent* ZAgentCommission -  abs( Result)  * ZAgentPercent* AgentCommission end)) as ZAgentCommission,";
            //str += "sum(( -(Result)* PartnerPercent)) as Partner,";
            //str += "sum((case when ZAgentCommission=0  then  abs( Result ) *SubCompanyPercent* PartnerCommission  else abs(Result) *SubCompanyPercent* PartnerCommission -  abs( Result)  * PartnerPercent* ZAgentCommission end)) as PartnerCommission,";
            //str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
            //str += "sum(case  when PartnerCommission=0 then  abs(Result)*CompanyPercent* SubCompanyCommission  else abs(Result) *CompanyPercent* SubCompanyCommission - abs( Result)*SubCompanyPercent*PartnerCommission  end)  as SubCompanyCommission,";
            //str += "sum((case when SubCompanyCommission=0 then  -(Result) *CompanyPercent  else -(Result) *CompanyPercent - abs(Result) *CompanyPercent*SubCompanyCommission end)) as Companys,";
            //str += "sum(abs(Result)*CompanyPercent*SubCompanyCommission) as CompanyCommission,";

            if (mtype == "1")
            {
                //本币（人民币）
                str += "sum(Amount * rate) as Amount,sum(ValidAmount * rate) as ValidAmount,sum(abs(Result) * rate) as Result,Member,";
                str += "sum((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*MemberCommission * rate) as Commission,";
                str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end) * rate) as Members,";
                str += "sum((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission * rate) as MemberCommission,";
                str += "sum((-(Result)* AgentPercent) * rate) as Agent,";
                str += "sum((case when MemberCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) * AgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) *  AgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission  end) * rate) as AgentCommission,";
                str += "sum((-(Result)* ZAgentPercent) * rate) as ZAgent,";
                str += "sum((case when AgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent)* AgentCommission end) * rate) as ZAgentCommission,";
                str += "sum(( -(Result)* PartnerPercent) * rate) as Partner,";
                str += "sum((case when ZAgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission end) * rate) as PartnerCommission,";
                str += "sum(( -(Result)* SubCompanyPercent) * rate) as SubCompany,";
                str += "sum((case when PartnerCommission=0 then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*CompanyPercent* SubCompanyCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent* SubCompanyCommission - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*(SubCompanyPercent+CompanyPercent)*PartnerCommission  end) * rate)  as SubCompanyCommission,";
                str += "sum((case when SubCompanyCommission=0 then  -(Result) *CompanyPercent  else -(Result) *CompanyPercent - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent*SubCompanyCommission end) * rate) as Companys,";
                str += "sum(-((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*CompanyPercent*SubCompanyCommission * rate)) as CompanyCommission,";
            }
            else
            {
                str += "sum(Amount) as Amount,sum(ValidAmount) as ValidAmount,sum(abs(Result)) as Result,Member,";
                str += "sum((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*MemberCommission) as Commission,";
                str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end)) as Members,";
                str += "sum((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission) as MemberCommission,";
                str += "sum((-(Result)* AgentPercent)) as Agent,";
                str += "sum((case when MemberCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) * AgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) *  AgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission  end)) as AgentCommission,";
                str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
                str += "sum((case when AgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent)* AgentCommission end)) as ZAgentCommission,";
                str += "sum(( -(Result)* PartnerPercent)) as Partner,";
                str += "sum((case when ZAgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission end)) as PartnerCommission,";
                str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
                str += "sum(case when PartnerCommission=0 then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*CompanyPercent* SubCompanyCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent* SubCompanyCommission - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*(SubCompanyPercent+CompanyPercent)*PartnerCommission  end)  as SubCompanyCommission,";
                str += "sum((case when SubCompanyCommission=0 then  -(Result) *CompanyPercent  else -(Result) *CompanyPercent - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent*SubCompanyCommission end)) as Companys,";
                str += "sum(-((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*CompanyPercent*SubCompanyCommission)) as CompanyCommission,";
            }

            str += "Reason,date(BeginTime) from yafa.orderhistory where Status='" + status + "'";
            if (!string.IsNullOrEmpty(agentName))
            {
                switch (roleId)
                {
                    case "2":
                        str += " and SubCompany='" + agentName + "' ";
                        break;
                    case "3":
                        str += " and Partner='" + agentName + "' ";
                        break;
                    case "4":
                        str += " and ZAgent='" + agentName + "' ";
                        break;
                    case "5":
                        str += " and Agent='" + agentName + "' ";
                        break;
                }
            }
            if (time != "")
            {
                str += " and date(BeginTime)='" + time + "'" + group;
            }
            else
            {
                str += " and date(BeginTime)>='" + time1 + "' and date(BeginTime)<= '" + time2 + "'" + group;
            }

            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }


        public string GetMatchAlls(string time1, string time2, string language, string status, string date, string user)
        {
            string time = "";
            if (time1 == time2)
            {
                time = time1;
            }
            string mysql = "";
            string group = "";
            if (language == "zh-cn" || language == "zh-CN")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
                group = " group by leaguetw,Hometw,Awaytw,ID";
            }
            if (language == "zh-tw")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
                group = " group by leaguetw,Hometw,Awaytw,ID";
            }
            if (language == "en-us")
            {
                mysql = "leagueen as league,Homeen as Home,Awayen as Away";
                group = " group by leagueen,Homeen,Awayen,ID";
            }
            if (language == "th-th")
            {
                mysql = "leagueth as league,Hometh as Home,Awayth as Away";
                group = " group by leagueth,Homecn,Awayth,ID";
            }
            if (language == "vi-vn")
            {
                mysql = "leaguevn as league,Homevn as Home,Awayvn as Away";
                group = " group by leaguevn,Homevn,Awayvn,ID";
            }
            string str = "select " + mysql + ",BeginTime,Score,Scorehalf,BetType,Odds,BetItem,Amount,ValidAmount,Result,Member,MemberPercent,MemberCommission,AgentPercent,AgentCommission,ZAgentPercent,ZAgentCommission,PartnerPercent,PartnerCommission,CompanyPercent,CompanyCommission,SubCompanyCommission,SubCompanyPercent,Reason,date(BeginTime) from yafa.orderhistory where Status='" + status + "'and "+date+"='"+user+"'";
            if (time != "")
            {
                str += " and date(BeginTime)='" + time + "'" + group;
            }
            else
            {
                str += " and date(BeginTime)>='" + time1 + "' and date(BeginTime)<= '" + time2 + "'" + group;
            }

            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        public IList<Orderhistory> GetMatchUser(string time, string language, string status, string ID)
        {
            string mysql = "";
            if (language == "zh-cn" || language == "zh-CN")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
            }
            if (language == "zh-tw")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
            }
            if (language == "en-us")
            {
                mysql = "leagueen as league,Homeen as Home,Awayen as Away";
            }
            if (language == "th-th")
            {
                mysql = "leagueth as league,Hometh as Home,Awayth as Away";
            }
            if (language == "vi-vn")
            {
                mysql = "leaguevn as league,Homevn as Home,Awayvn as Away";
            }
            string str = "select " + mysql + ",orderhistory.UserName,user.UpUserID as UpUserID,BeginTime,Score,Scorehalf,BetType,Odds,BetItem,Amount,ValidAmount,Result,Member,MemberPercent,MemberCommission,orderhistory.AgentPercent,orderhistory.AgentCommission,ZAgentPercent,ZAgentCommission,orderhistory.PartnerPercent,orderhistory.PartnerCommission,orderhistory.CompanyPercent,orderhistory.CompanyCommission,orderhistory.SubCompanyCommission,orderhistory.SubCompanyPercent,Reason,date(BeginTime) from yafa.orderhistory left join yafa.user on yafa.orderhistory.UserName=yafa.user.UserName where user.UpUserID = '" + ID + "' and orderhistory.Status='" + status + "'";
            if (time != "")
            {
                str += " and date(BeginTime)='" + time + "'";
            }
            return MySqlModelHelper<Orderhistory>.GetObjectsBySql(str);
        }

        public string GetMatchs(string time1, string time2,string language, string status, string type, string uptype,string UpUserName)
        {
            string time = "";
            if (time1 == time2)
            {
                time = time1;
            }
            string mysql = "";
            if (language == "zh-cn" || language == "zh-CN")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
            }
            if (language == "zh-tw")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
            }
            if (language == "en-us")
            {
                mysql = "leagueen as league,Homeen as Home,Awayen as Away";
            }
            if (language == "th-th")
            {
                mysql = "leagueth as league,Hometh as Home,Awayth as Away";
            }
            if (language == "vi-vn")
            {
                mysql = "leaguevn as league,Homevn as Home,Awayvn as Away";
            }
            string str = "select " + mysql + "," + type + " as UserName,";
            //str += "sum((case when Result>0 then  -(Result) *CompanyPercent when SubCompanyCommission=0 then  abs(Result) *CompanyPercent  else abs(Result) *CompanyPercent - abs(Result) *CompanyPercent*SubCompanyCommission end)) as Companys,";
            //str += "sum(case when Result>0 then 0  when PartnerCommission=0 then  abs(Result)*CompanyPercent* SubCompanyCommission  else abs(Result) *CompanyPercent* SubCompanyCommission - abs( Result)*SubCompanyPercent*PartnerCommission  end)  as SubCompanyCommission,";
            //str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
            //str += "sum((case when Result>0 then 0 when ZAgentCommission=0  then  abs( Result ) *SubCompanyPercent* PartnerCommission  else abs(Result) *SubCompanyPercent* PartnerCommission -  abs( Result)  * PartnerPercent* ZAgentCommission end)) as PartnerCommission,";
            //str += "sum(( -(Result)* PartnerPercent)) as Partner,";
            //str += "sum((case when Result>0 then 0 when AgentCommission=0  then  abs( Result ) *PartnerPercent* ZAgentCommission   else  abs(Result) *PartnerPercent* ZAgentCommission -  abs( Result)  * ZAgentPercent* AgentCommission end)) as ZAgentCommission,";
            //str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
            //str += "sum((case when Result>0 then 0 when MemberCommission=0  then  abs( Result ) *ZAgentPercent * AgentCommission   else  abs(Result) * ZAgentPercent *  AgentCommission -  abs( Result)  * AgentPercent* MemberCommission  end)) as AgentCommission,";
            //str += "sum((-(Result)* AgentPercent)) as Agent,";
            //str += "sum((case when Result>0 then 0 else (abs(Result)*AgentPercent * MemberCommission) end)) as MemberCommission,";
            //str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end)) as Members,";
            //str += "BeginTime,Score,Scorehalf,BetType,Odds,BetItem,sum(Amount) as Amount,sum(ValidAmount) as ValidAmount,sum(abs(Result)) as result,Member,MemberPercent,AgentPercent,ZAgentPercent,PartnerPercent,CompanyPercent,SubCompanyPercent,Reason,date(BeginTime) from yafa.orderhistory where orderhistory.Status='" + status + "'";

            str += "sum((case when SubCompanyCommission=0 then  -(Result) *CompanyPercent  else -(Result) *CompanyPercent - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent*SubCompanyCommission end)) as Companys,";
            str += "sum(case when PartnerCommission=0 then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*CompanyPercent* SubCompanyCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent* SubCompanyCommission - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*(SubCompanyPercent+CompanyPercent)*PartnerCommission  end)  as SubCompanyCommission,";
            str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
            str += "sum((case when ZAgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission end)) as PartnerCommission,";
            str += "sum(( -(Result)* PartnerPercent)) as Partner,";
            str += "sum((case when AgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent)* AgentCommission end)) as ZAgentCommission,";
            str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
            str += "sum((case when MemberCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) * AgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) *  AgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission  end)) as AgentCommission,";
            str += "sum((-(Result)* AgentPercent)) as Agent,";
            str += "sum((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission) as MemberCommission,";
            str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end)) as Members,";
            str += "BeginTime,Score,Scorehalf,BetType,Odds,BetItem,sum(Amount) as Amount,sum(ValidAmount) as ValidAmount,sum(abs(Result)) as result,Member,MemberPercent,AgentPercent,ZAgentPercent,PartnerPercent,CompanyPercent,SubCompanyPercent,Reason,date(BeginTime) from yafa.orderhistory where orderhistory.Status='" + status + "'";

            if (time != "")
            {
                str += " and date(BeginTime)='" + time + "'";
            }
            else
            {
                str += " and date(BeginTime)>='" + time1 + "' and date(BeginTime)<= '" + time2 + "'";
            }
            str += " and "+uptype+"='"+UpUserName+"'";
            str += " group by " + type;
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        public string GetMatchs2(string time1, string time2, string language, string status, string type, string uptype, string UpUserName, string mtype)
        {
            string time = "";
            string subsql = "";
            string subsql2 = "";
           // type = "UpUserName";
            if (time1 == time2)
            {
                time = time1;
            }
            //string mysql = "";
            //if (language == "zh-cn" || language == "zh-CN")
            //{
            //    mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
            //}
            //if (language == "zh-tw")
            //{
            //    mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
            //}
            //if (language == "en-us")
            //{
            //    mysql = "leagueen as league,Homeen as Home,Awayen as Away";
            //}
            //if (language == "th-th")
            //{
            //    mysql = "leagueth as league,Hometh as Home,Awayth as Away";
            //}
            //if (language == "vi-vn")
            //{
            //    mysql = "leaguevn as league,Homevn as Home,Awayvn as Away";
            //}
            if (string.IsNullOrEmpty(time1) || string.IsNullOrEmpty(time2))
            {
                return "";
            }
            else
            {
                subsql += " date(UpdateTime)>='" + time1 + "' and date(UpdateTime)<= '" + time2 + "'";
                subsql2 += " date(enddate)>='" + time1 + "' and date(enddate)<= '" + time2 + "'";
            }

            string str = "select aa." + type + " as UserName,";
            //str += "sum((case when Result>0 then  -(Result) *CompanyPercent when SubCompanyCommission=0 then  abs(Result) *CompanyPercent  else abs(Result) *CompanyPercent - abs(Result) *CompanyPercent*SubCompanyCommission end)) as Companys,";
            //str += "sum(case when Result>0 then 0  when PartnerCommission=0 then  abs(Result)*CompanyPercent* SubCompanyCommission  else abs(Result) *CompanyPercent* SubCompanyCommission - abs( Result)*SubCompanyPercent*PartnerCommission  end)  as SubCompanyCommission,";
            //str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
            //str += "sum((case when Result>0 then 0 when ZAgentCommission=0  then  abs( Result ) *SubCompanyPercent* PartnerCommission  else abs(Result) *SubCompanyPercent* PartnerCommission -  abs( Result)  * PartnerPercent* ZAgentCommission end)) as PartnerCommission,";
            //str += "sum(( -(Result)* PartnerPercent)) as Partner,";
            //str += "sum((case when Result>0 then 0 when AgentCommission=0  then  abs( Result ) *PartnerPercent* ZAgentCommission   else  abs(Result) *PartnerPercent* ZAgentCommission -  abs( Result)  * ZAgentPercent* AgentCommission end)) as ZAgentCommission,";
            //str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
            //str += "sum((case when Result>0 then 0 when MemberCommission=0  then  abs( Result ) *ZAgentPercent * AgentCommission   else  abs(Result) * ZAgentPercent *  AgentCommission -  abs( Result)  * AgentPercent* MemberCommission  end)) as AgentCommission,";
            //str += "sum((-(Result)* AgentPercent)) as Agent,";
            //str += "sum((case when Result>0 then 0 else (abs(Result)*AgentPercent * MemberCommission) end)) as MemberCommission,";
            //str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end)) as Members,";
            //str += "BeginTime,Score,Scorehalf,BetType,Odds,BetItem,sum(Amount) as Amount,sum(ValidAmount) as ValidAmount,sum(abs(Result)) as result,Member,MemberPercent,AgentPercent,ZAgentPercent,PartnerPercent,CompanyPercent,SubCompanyPercent,Reason,date(BeginTime) from yafa.orderhistory where orderhistory.Status='" + status + "'";

            //if (mtype == "1")
            //{
            //    //本币(人民币）
            //    str += "sum((case when SubCompanyCommission=0 then  -(Result) *CompanyPercent  else -(Result) *CompanyPercent - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent*SubCompanyCommission end) * rate) as Companys,";
            //    str += "sum((case when PartnerCommission=0 then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*CompanyPercent* SubCompanyCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent* SubCompanyCommission - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*(SubCompanyPercent+CompanyPercent)*PartnerCommission  end) * rate)  as SubCompanyCommission,";
            //    str += "sum(( -(Result)* SubCompanyPercent) * rate) as SubCompany,";
            //    str += "sum((case when ZAgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission end) * rate) as PartnerCommission,";
            //    str += "sum(( -(Result)* PartnerPercent) * rate) as Partner,";
            //    str += "sum((case when AgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent)* AgentCommission end) * rate) as ZAgentCommission,";
            //    str += "sum((-(Result)* ZAgentPercent) * rate) as ZAgent,";
            //    str += "sum((case when MemberCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) * AgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) *  AgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission  end) * rate) as AgentCommission,";
            //    str += "sum((-(Result)* AgentPercent) * rate) as Agent,";
            //    str += "sum(((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission) * rate) as MemberCommission,";
            //    str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end) * rate) as Members,";
            //    str += "BeginTime,Score,Scorehalf,BetType,Odds,BetItem,sum(Amount * rate) as Amount,sum(ValidAmount * rate) as ValidAmount,sum(abs(Result) * rate) as result,Member,MemberPercent,AgentPercent,ZAgentPercent,PartnerPercent,CompanyPercent,SubCompanyPercent,Reason,date(BeginTime) from yafa.orderhistory where orderhistory.Status='" + status + "'";
            //}
            //else
            //{
            //    str += "sum((case when SubCompanyCommission=0 then  -(Result) *CompanyPercent  else -(Result) *CompanyPercent - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent*SubCompanyCommission end)) as Companys,";
            //    str += "sum(case when PartnerCommission=0 then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*CompanyPercent* SubCompanyCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent* SubCompanyCommission - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*(SubCompanyPercent+CompanyPercent)*PartnerCommission  end)  as SubCompanyCommission,";
            //    str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
            //    str += "sum((case when ZAgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission end)) as PartnerCommission,";
            //    str += "sum(( -(Result)* PartnerPercent)) as Partner,";
            //    str += "sum((case when AgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent)* AgentCommission end)) as ZAgentCommission,";
            //    str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
            //    str += "sum((case when MemberCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) * AgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) *  AgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission  end)) as AgentCommission,";
            //    str += "sum((-(Result)* AgentPercent)) as Agent,";
            //    str += "sum((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission) as MemberCommission,";
            //    str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end)) as Members,";
            //    str += "BeginTime,Score,Scorehalf,BetType,Odds,BetItem,sum(Amount) as Amount,sum(ValidAmount) as ValidAmount,sum(abs(Result)) as result,Member,MemberPercent,AgentPercent,ZAgentPercent,PartnerPercent,CompanyPercent,SubCompanyPercent,Reason,date(BeginTime) from yafa.orderhistory where orderhistory.Status='" + status + "'";
            //}

            str += "  sum( if(aa.type='1', amount, 0 )  ) as 'ckamount', sum(  if(aa.type='2', amount, 0 )   ) as 'qkamount', sum(  if(aa.type='3', amount, 0 )   ) as 'hlamount', sum(   if(aa.type='4', amount, 0 )  ) as 'fsamount', sum(  if(aa.type='8', amount, 0 )   ) as 'winandlose', sum(  if(aa.type='4', validamount, 0 )   ) as 'validamount', sum(  if(aa.type='21', amount, 0 )   ) as 'winlose' from ";
            str += " ( ";
            str += " select b.username as username,b.SubCompany as SubCompany,b.Partner as partner,b.GeneralAgent as ZAgent,b.Agent as agent,a.type, a.amount, a.time ,a.validamount";
            str += " from";
            str += " ((select `billnoticehistory`.`UserName` AS `username`,`billnoticehistory`.`Type` AS `type`,`billnoticehistory`.`Amount` AS `amount`,`billnoticehistory`.`UpdateTime` AS `time`,`billnoticehistory`.validamount AS `validamount`  from `billnoticehistory` where ( " + subsql + " and  (`billnoticehistory`.`Status` <> _utf8'3') and (`billnoticehistory`.`Type` in (_utf8'1',_utf8'2',_utf8'3',_utf8'4',_utf8'8'))))   ) a ";
            str += " inner join `user` b on a.username=b.username";
            str += ")  as aa";
            str += " where 1=1 ";

            str += " and aa." + uptype + "='" + UpUserName + "'";
            str += " group by aa." + type;
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        public string GetMatchs2Agent(string time1, string time2, string language, string status, string type, string uptype, string UpUserName, string mtype)
        {
            string time = "";
            if (time1 == time2)
            {
                time = time1;
            }
            //string mysql = "";
            //if (language == "zh-cn" || language == "zh-CN")
            //{
            //    mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
            //}
            //if (language == "zh-tw")
            //{
            //    mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
            //}
            //if (language == "en-us")
            //{
            //    mysql = "leagueen as league,Homeen as Home,Awayen as Away";
            //}
            //if (language == "th-th")
            //{
            //    mysql = "leagueth as league,Hometh as Home,Awayth as Away";
            //}
            //if (language == "vi-vn")
            //{
            //    mysql = "leaguevn as league,Homevn as Home,Awayvn as Away";
            //}
            string str = "select aa." + type + " as UserName,";
            //str += "sum((case when Result>0 then  -(Result) *CompanyPercent when SubCompanyCommission=0 then  abs(Result) *CompanyPercent  else abs(Result) *CompanyPercent - abs(Result) *CompanyPercent*SubCompanyCommission end)) as Companys,";
            //str += "sum(case when Result>0 then 0  when PartnerCommission=0 then  abs(Result)*CompanyPercent* SubCompanyCommission  else abs(Result) *CompanyPercent* SubCompanyCommission - abs( Result)*SubCompanyPercent*PartnerCommission  end)  as SubCompanyCommission,";
            //str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
            //str += "sum((case when Result>0 then 0 when ZAgentCommission=0  then  abs( Result ) *SubCompanyPercent* PartnerCommission  else abs(Result) *SubCompanyPercent* PartnerCommission -  abs( Result)  * PartnerPercent* ZAgentCommission end)) as PartnerCommission,";
            //str += "sum(( -(Result)* PartnerPercent)) as Partner,";
            //str += "sum((case when Result>0 then 0 when AgentCommission=0  then  abs( Result ) *PartnerPercent* ZAgentCommission   else  abs(Result) *PartnerPercent* ZAgentCommission -  abs( Result)  * ZAgentPercent* AgentCommission end)) as ZAgentCommission,";
            //str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
            //str += "sum((case when Result>0 then 0 when MemberCommission=0  then  abs( Result ) *ZAgentPercent * AgentCommission   else  abs(Result) * ZAgentPercent *  AgentCommission -  abs( Result)  * AgentPercent* MemberCommission  end)) as AgentCommission,";
            //str += "sum((-(Result)* AgentPercent)) as Agent,";
            //str += "sum((case when Result>0 then 0 else (abs(Result)*AgentPercent * MemberCommission) end)) as MemberCommission,";
            //str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end)) as Members,";
            //str += "BeginTime,Score,Scorehalf,BetType,Odds,BetItem,sum(Amount) as Amount,sum(ValidAmount) as ValidAmount,sum(abs(Result)) as result,Member,MemberPercent,AgentPercent,ZAgentPercent,PartnerPercent,CompanyPercent,SubCompanyPercent,Reason,date(BeginTime) from yafa.orderhistory where orderhistory.Status='" + status + "'";

            //if (mtype == "1")
            //{
            //    //本币(人民币）
            //    str += "sum((case when SubCompanyCommission=0 then  -(Result) *CompanyPercent  else -(Result) *CompanyPercent - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent*SubCompanyCommission end) * rate) as Companys,";
            //    str += "sum((case when PartnerCommission=0 then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*CompanyPercent* SubCompanyCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent* SubCompanyCommission - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*(SubCompanyPercent+CompanyPercent)*PartnerCommission  end) * rate)  as SubCompanyCommission,";
            //    str += "sum(( -(Result)* SubCompanyPercent) * rate) as SubCompany,";
            //    str += "sum((case when ZAgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission end) * rate) as PartnerCommission,";
            //    str += "sum(( -(Result)* PartnerPercent) * rate) as Partner,";
            //    str += "sum((case when AgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent)* AgentCommission end) * rate) as ZAgentCommission,";
            //    str += "sum((-(Result)* ZAgentPercent) * rate) as ZAgent,";
            //    str += "sum((case when MemberCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) * AgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) *  AgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission  end) * rate) as AgentCommission,";
            //    str += "sum((-(Result)* AgentPercent) * rate) as Agent,";
            //    str += "sum(((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission) * rate) as MemberCommission,";
            //    str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end) * rate) as Members,";
            //    str += "BeginTime,Score,Scorehalf,BetType,Odds,BetItem,sum(Amount * rate) as Amount,sum(ValidAmount * rate) as ValidAmount,sum(abs(Result) * rate) as result,Member,MemberPercent,AgentPercent,ZAgentPercent,PartnerPercent,CompanyPercent,SubCompanyPercent,Reason,date(BeginTime) from yafa.orderhistory where orderhistory.Status='" + status + "'";
            //}
            //else
            //{
            //    str += "sum((case when SubCompanyCommission=0 then  -(Result) *CompanyPercent  else -(Result) *CompanyPercent - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent*SubCompanyCommission end)) as Companys,";
            //    str += "sum(case when PartnerCommission=0 then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*CompanyPercent* SubCompanyCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent* SubCompanyCommission - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*(SubCompanyPercent+CompanyPercent)*PartnerCommission  end)  as SubCompanyCommission,";
            //    str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
            //    str += "sum((case when ZAgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission end)) as PartnerCommission,";
            //    str += "sum(( -(Result)* PartnerPercent)) as Partner,";
            //    str += "sum((case when AgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent)* AgentCommission end)) as ZAgentCommission,";
            //    str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
            //    str += "sum((case when MemberCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) * AgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) *  AgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission  end)) as AgentCommission,";
            //    str += "sum((-(Result)* AgentPercent)) as Agent,";
            //    str += "sum((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission) as MemberCommission,";
            //    str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end)) as Members,";
            //    str += "BeginTime,Score,Scorehalf,BetType,Odds,BetItem,sum(Amount) as Amount,sum(ValidAmount) as ValidAmount,sum(abs(Result)) as result,Member,MemberPercent,AgentPercent,ZAgentPercent,PartnerPercent,CompanyPercent,SubCompanyPercent,Reason,date(BeginTime) from yafa.orderhistory where orderhistory.Status='" + status + "'";
            //}

            str += "  sum( if(aa.type='1', amount, 0 )  ) as 'ckamount', sum(  if(aa.type='2', amount, 0 )   ) as 'qkamount', sum(  if(aa.type='3', amount, 0 )   ) as 'hlamount', sum(   if(aa.type='4', amount, 0 )  ) as 'fsamount', sum(  if(aa.type='8', amount, 0 )   ) as 'winandlose', sum(  if(aa.type='20', amount, 0 )   ) as 'validamount', sum(  if(aa.type='21', amount, 0 )   ) as 'winlose' from ";
            str += " ( ";
            str += " select b.username as username,b.SubCompany as SubCompany,b.Partner as partner,b.GeneralAgent as ZAgent,b.Agent as agent,a.type, a.amount, a.`time`";
            str += " from";
            str += " v_billlist a ";
            str += " right join `user` b on a.username=b.username";
            str += ")  as aa";
            str += " where 1=1 ";

            if (time != "")
            {
                str += " and date(aa.time)='" + time + "'";
            }
            else
            {
                str += " and ((date(aa.time)>='" + time1 + "' and date(aa.time)<= '" + time2 + "') or aa.time is null )";
            }
            str += " and aa." + uptype + "='" + UpUserName + "'";
            str += " group by aa." + type;
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

         public string GetMatchs3(string time1, string time2, string language, string status, string type, string uptype, string UpUserName, string mtype)
        {
            string time = "";
            string percentStr = (type == "UserName" ? "" : type);
            if (time1 == time2)
            {
                time = time1;
            }

            string str = "select aa." + type + " as UserName,aa." + percentStr + "Percent as Percent, ";


            str += "  sum( if(aa.type='1', amount, 0 )  ) as 'ckamount', sum(  if(aa.type='2', amount, 0 )   ) as 'qkamount', sum(  if(aa.type='3', amount, 0 )   ) as 'hlamount', sum(   if(aa.type='4', amount, 0 )  ) as 'fsamount', sum(  if(aa.type='8', amount, 0 )   ) as 'winandlose', sum(  if(aa.type='20', amount, 0 )   ) as 'validamount', sum(  if(aa.type='21', amount, 0 )   ) as 'winlose' from ";
            str += " ( ";
            str += " select b.username as username,b.SubCompany as SubCompany,b.SubCompanyPercent as SubCompanyPercent,b.Partner as partner,b.PartnerPercent as PartnerPercent,b.GeneralAgent as ZAgent,b.GeneralAgentPercent as ZAgentPercent,b.Agent as agent,b.AgentPercent as AgentPercent, b.Percent as Percent,a.type, a.amount, a.`time`";
            str += " from";
            str += " v_billlist a ";
            str += " left join `user` b on a.username=b.username";
            str += ")  as aa";
            str += " where 1=1 ";

            if (time != "")
            {
                str += " and date(aa.time)='" + time + "'";
            }
            else
            {
                str += " and date(aa.time)>='" + time1 + "' and date(aa.time)<= '" + time2 + "'";
            }
            str += " and aa." + uptype + "='" + UpUserName + "'";
            str += " group by aa." + type;
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        public string GetUserName(string time1, string time2,string language, string status, string userName)
        {
            string mysql = "";
            string group = "";
            string time = "";
            if (time1 == time2)
            {
                time = time1;
            }
            if (language == "zh-cn" || language == "zh-CN")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
                group = " group by leaguetw,Hometw,Awaytw,ID";
            }
            if (language == "zh-tw")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
                group = " group by leaguetw,Hometw,Awaytw,ID";
            }
            if (language == "en-us")
            {
                mysql = "leagueen as league,Homeen as Home,Awayen as Away";
                group = " group by leagueen,Homeen,Awayen,ID";
            }
            if (language == "th-th")
            {
                mysql = "leagueth as league,Hometh as Home,Awayth as Away";
                group = " group by leagueth,Homecn,Awayth,ID";
            }
            if (language == "vi-vn")
            {
                mysql = "leaguevn as league,Homevn as Home,Awayvn as Away";
                group = " group by leaguevn,Homevn,Awayvn,ID";
            }
            string str = "select " + mysql + ",UserName,BetType,BetItem,Handicap,OddsType,";
            str += "(case when SubCompanyCommission=0 then sum( -Result *CompanyPercent ) else sum(-Result *CompanyPercent - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent*SubCompanyCommission) end) as Companys,";
            //str += "(case when Result>0 then 0 when PartnerCommission=0 then sum( abs(Result)*CompanyPercent* SubCompanyCommission ) else sum(abs(Result) *CompanyPercent* SubCompanyCommission - abs( Result)*SubCompanyPercent*PartnerCommission) end) as SubCompanyCommission,";
            str += "(case when PartnerCommission=0 then sum( (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*CompanyPercent* SubCompanyCommission ) else sum((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent* SubCompanyCommission - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*(SubCompanyPercent+CompanyPercent)*PartnerCommission) end) as SubCompanyCommission,";
            str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
            //str += "(case when Result>0 then 0 when ZAgentCommission=0  then sum( abs( Result ) *SubCompanyPercent* PartnerCommission )  else sum( abs(Result) *SubCompanyPercent* PartnerCommission -  abs( Result)  * PartnerPercent* ZAgentCommission) end) as PartnerCommission,";
            str += "(case when ZAgentCommission=0  then sum( (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission )  else sum( (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission) end) as PartnerCommission,";
            str += "sum(( -(Result)* PartnerPercent)) as Partner,";
            //str += "(case when Result>0 then 0 when AgentCommission=0  then sum( abs( Result ) *PartnerPercent* ZAgentCommission )  else sum( abs(Result) *PartnerPercent* ZAgentCommission -  abs( Result)  * ZAgentPercent* AgentCommission) end) as ZAgentCommission,";
            str += "(case when AgentCommission=0  then sum( (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission )  else sum( (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent)* AgentCommission) end) as ZAgentCommission,";
            str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
            //str += "(case when Result>0 then 0 when MemberCommission=0  then sum( abs( Result ) *ZAgentPercent * AgentCommission )  else sum( abs(Result) * ZAgentPercent *  AgentCommission -  abs( Result)  * AgentPercent* MemberCommission)  end) as AgentCommission,";
            str += "(case when MemberCommission=0  then sum( (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) * AgentCommission )  else sum( (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) *  AgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission)  end) as AgentCommission,";
            str += "sum((-(Result)* AgentPercent)) as Agent,";
            //str += "(case when Result>0 then 0 else (sum(abs(Result)*AgentPercent * MemberCommission)) end) as MemberCommission,";
            str += "(sum((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission)) as MemberCommission,";
            str += "(case when MemberPercent=0 then sum(Result) else sum(Result* MemberPercent) end) as Members,";
            str += "BeginTime,time,Score,Scorehalf,BetType,Odds,BetItem,Amount,ValidAmount,Result,AgentPercent,ZAgentPercent,PartnerPercent,SubCompanyPercent,IP,Reason,date(BeginTime) from yafa.orderhistory where Status='" + status + "' and UserName='" + userName + "'";
            if (time != "")
            {
                str += " and date(BeginTime)='" + time + "'" + group;
            }
            else
            {
                str += " and date(BeginTime)>='" + time1 + "' and date(BeginTime)<= '" + time2 + "'"+group;
            }

            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        public string GetUserName2(string time1, string time2, string language, string status, string userName, string mtype)
        {
            string mysql = "";
            string group = "";
            string time = "";
            if (time1 == time2)
            {
                time = time1;
            }
            if (language == "zh-cn" || language == "zh-CN")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
                group = " group by leaguetw,Hometw,Awaytw,ID";
            }
            if (language == "zh-tw")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
                group = " group by leaguetw,Hometw,Awaytw,ID";
            }
            if (language == "en-us")
            {
                mysql = "leagueen as league,Homeen as Home,Awayen as Away";
                group = " group by leagueen,Homeen,Awayen,ID";
            }
            if (language == "th-th")
            {
                mysql = "leagueth as league,Hometh as Home,Awayth as Away";
                group = " group by leagueth,Homecn,Awayth,ID";
            }
            if (language == "vi-vn")
            {
                mysql = "leaguevn as league,Homevn as Home,Awayvn as Away";
                group = " group by leaguevn,Homevn,Awayvn,ID";
            }
            string str = "select " + mysql + ",UserName,BetType,BetItem,Handicap,OddsType,Status,Scoreathalf,";

            if (mtype == "1")
            {
                str += "(case when SubCompanyCommission=0 then sum( -Result *CompanyPercent * rate ) else sum((-Result *CompanyPercent - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent*SubCompanyCommission) * rate) end) as Companys,";
                //str += "(case when Result>0 then 0 when PartnerCommission=0 then sum( abs(Result)*CompanyPercent* SubCompanyCommission ) else sum(abs(Result) *CompanyPercent* SubCompanyCommission - abs( Result)*SubCompanyPercent*PartnerCommission) end) as SubCompanyCommission,";
                str += "(case when PartnerCommission=0 then sum( (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*CompanyPercent* SubCompanyCommission * rate ) else sum((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent* SubCompanyCommission - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*(SubCompanyPercent+CompanyPercent)*PartnerCommission * rate) end) as SubCompanyCommission,";
                str += "sum(( -(Result)* SubCompanyPercent) * rate) as SubCompany,";
                //str += "(case when Result>0 then 0 when ZAgentCommission=0  then sum( abs( Result ) *SubCompanyPercent* PartnerCommission )  else sum( abs(Result) *SubCompanyPercent* PartnerCommission -  abs( Result)  * PartnerPercent* ZAgentCommission) end) as PartnerCommission,";
                str += "(case when ZAgentCommission=0  then sum( (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission * rate )  else sum( (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission * rate) end) as PartnerCommission,";
                str += "sum(( -(Result)* PartnerPercent) * rate) as Partner,";
                //str += "(case when Result>0 then 0 when AgentCommission=0  then sum( abs( Result ) *PartnerPercent* ZAgentCommission )  else sum( abs(Result) *PartnerPercent* ZAgentCommission -  abs( Result)  * ZAgentPercent* AgentCommission) end) as ZAgentCommission,";
                str += "(case when AgentCommission=0  then sum( (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission * rate )  else sum( (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent)* AgentCommission * rate) end) as ZAgentCommission,";
                str += "sum((-(Result)* ZAgentPercent) * rate) as ZAgent,";
                //str += "(case when Result>0 then 0 when MemberCommission=0  then sum( abs( Result ) *ZAgentPercent * AgentCommission )  else sum( abs(Result) * ZAgentPercent *  AgentCommission -  abs( Result)  * AgentPercent* MemberCommission)  end) as AgentCommission,";
                str += "(case when MemberCommission=0  then sum( (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) * AgentCommission * rate )  else sum( (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) *  AgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission * rate)  end) as AgentCommission,";
                str += "sum((-(Result)* AgentPercent) * rate) as Agent,";
                //str += "(case when Result>0 then 0 else (sum(abs(Result)*AgentPercent * MemberCommission)) end) as MemberCommission,";
                str += "(sum((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission * rate)) as MemberCommission,";
                str += "(case when MemberPercent=0 then sum(Result * rate) else sum(Result* MemberPercent * rate) end) as Members,";
                str += "BeginTime,time,Score,Scorehalf,BetType,Odds,BetItem,(Amount * rate) as Amount,(ValidAmount * rate) as ValidAmount,(Result * rate) as Result,AgentPercent,ZAgentPercent,PartnerPercent,SubCompanyPercent,IP,Reason,date(BeginTime) from yafa.orderhistory where Status='" + status + "' and UserName='" + userName + "'";
            }
            else
            {
                str += "(case when SubCompanyCommission=0 then sum( -Result *CompanyPercent ) else sum(-Result *CompanyPercent - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent*SubCompanyCommission) end) as Companys,";
                //str += "(case when Result>0 then 0 when PartnerCommission=0 then sum( abs(Result)*CompanyPercent* SubCompanyCommission ) else sum(abs(Result) *CompanyPercent* SubCompanyCommission - abs( Result)*SubCompanyPercent*PartnerCommission) end) as SubCompanyCommission,";
                str += "(case when PartnerCommission=0 then sum( (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*CompanyPercent* SubCompanyCommission ) else sum((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent* SubCompanyCommission - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*(SubCompanyPercent+CompanyPercent)*PartnerCommission) end) as SubCompanyCommission,";
                str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
                //str += "(case when Result>0 then 0 when ZAgentCommission=0  then sum( abs( Result ) *SubCompanyPercent* PartnerCommission )  else sum( abs(Result) *SubCompanyPercent* PartnerCommission -  abs( Result)  * PartnerPercent* ZAgentCommission) end) as PartnerCommission,";
                str += "(case when ZAgentCommission=0  then sum( (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission )  else sum( (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission) end) as PartnerCommission,";
                str += "sum(( -(Result)* PartnerPercent)) as Partner,";
                //str += "(case when Result>0 then 0 when AgentCommission=0  then sum( abs( Result ) *PartnerPercent* ZAgentCommission )  else sum( abs(Result) *PartnerPercent* ZAgentCommission -  abs( Result)  * ZAgentPercent* AgentCommission) end) as ZAgentCommission,";
                str += "(case when AgentCommission=0  then sum( (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission )  else sum( (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent)* AgentCommission) end) as ZAgentCommission,";
                str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
                //str += "(case when Result>0 then 0 when MemberCommission=0  then sum( abs( Result ) *ZAgentPercent * AgentCommission )  else sum( abs(Result) * ZAgentPercent *  AgentCommission -  abs( Result)  * AgentPercent* MemberCommission)  end) as AgentCommission,";
                str += "(case when MemberCommission=0  then sum( (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) * AgentCommission )  else sum( (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) *  AgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission)  end) as AgentCommission,";
                str += "sum((-(Result)* AgentPercent)) as Agent,";
                //str += "(case when Result>0 then 0 else (sum(abs(Result)*AgentPercent * MemberCommission)) end) as MemberCommission,";
                str += "(sum((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission)) as MemberCommission,";
                str += "(case when MemberPercent=0 then sum(Result) else sum(Result* MemberPercent) end) as Members,";
                str += "BeginTime,time,Score,Scorehalf,BetType,Odds,BetItem,Amount,ValidAmount,Result,AgentPercent,ZAgentPercent,PartnerPercent,SubCompanyPercent,IP,Reason,date(BeginTime) from yafa.orderhistory where Status='" + status + "' and UserName='" + userName + "'";

            }
            if (time != "")
            {
                str += " and date(BeginTime)='" + time + "'" + group;
            }
            else
            {
                str += " and date(BeginTime)>='" + time1 + "' and date(BeginTime)<= '" + time2 + "'" + group;
            }

            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }


        public string LeagueOrderDetail(string time1, string time2, string language, string status, string gameid, string betType,string agentName,string roleId)
        {
            string mysql = "";
            string group = "";
            string time = "";
            if (time1 == time2)
            {
                time = time1;
            }
            if (language == "zh-cn" || language == "zh-CN" || language=="zh-CN")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
                group = " group by leaguetw,Hometw,Awaytw,ID";
            }
            if (language == "zh-tw")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
                group = " group by leaguetw,Hometw,Awaytw,ID";
            }
            if (language == "en-us")
            {
                mysql = "leagueen as league,Homeen as Home,Awayen as Away";
                group = " group by leagueen,Homeen,Awayen,ID";
            }
            if (language == "th-th")
            {
                mysql = "leagueth as league,Hometh as Home,Awayth as Away";
                group = " group by leagueth,Homecn,Awayth,ID";
            }
            if (language == "vi-vn")
            {
                mysql = "leaguevn as league,Homevn as Home,Awayvn as Away";
                group = " group by leaguevn,Homevn,Awayvn,ID";
            }
            string str = "select " + mysql + ",UserName,BetType,BetItem,Handicap,OddsType,";
            //str += "(case when SubCompanyCommission=0 then sum( -Result *CompanyPercent ) else sum(-Result *CompanyPercent - (-Result) *CompanyPercent*SubCompanyCommission) end) as Companys,";
            //str += "(case when Result>0 then 0 when PartnerCommission=0 then sum( abs(Result)*CompanyPercent* SubCompanyCommission ) else sum(abs(Result) *CompanyPercent* SubCompanyCommission - abs( Result)*SubCompanyPercent*PartnerCommission) end) as SubCompanyCommission,";
            //str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
            //str += "(case when Result>0 then 0 when ZAgentCommission=0  then sum( abs( Result ) *SubCompanyPercent* PartnerCommission )  else sum( abs(Result) *SubCompanyPercent* PartnerCommission -  abs( Result)  * PartnerPercent* ZAgentCommission) end) as PartnerCommission,";
            //str += "sum(( -(Result)* PartnerPercent)) as Partner,";
            //str += "(case when Result>0 then 0 when AgentCommission=0  then sum( abs( Result ) *PartnerPercent* ZAgentCommission )  else sum( abs(Result) *PartnerPercent* ZAgentCommission -  abs( Result)  * ZAgentPercent* AgentCommission) end) as ZAgentCommission,";
            //str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
            //str += "(case when Result>0 then 0 when MemberCommission=0  then sum( abs( Result ) *ZAgentPercent * AgentCommission )  else sum( abs(Result) * ZAgentPercent *  AgentCommission -  abs( Result)  * AgentPercent* MemberCommission)  end) as AgentCommission,";
            //str += "sum((-(Result)* AgentPercent)) as Agent,";
            //str += "(case when Result>0 then 0 else (sum(abs(Result)*AgentPercent * MemberCommission)) end) as MemberCommission,";
            //str += "(case when MemberPercent=0 then sum(Result) else sum(Result* MemberPercent) end) as Members,";
            //str += "BeginTime,time,Score,Scorehalf,BetType,Odds,BetItem,Amount,ValidAmount,Result,AgentPercent,ZAgentPercent,PartnerPercent,SubCompanyPercent,IP,Reason,date(BeginTime) from yafa.orderhistory where Status='" + status + "' and gameid=" + gameid + "";
            
            //str += "(case when SubCompanyCommission=0 then sum( -Result *CompanyPercent ) else sum(-Result *CompanyPercent - (abs(Result)) *CompanyPercent*SubCompanyCommission) end) as Companys,";
            //str += "(case when PartnerCommission=0 then sum( abs(Result)*CompanyPercent* SubCompanyCommission ) else sum(abs(Result) *CompanyPercent* SubCompanyCommission - abs( Result)*SubCompanyPercent*PartnerCommission) end) as SubCompanyCommission,";
            //str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
            //str += "(case when ZAgentCommission=0  then sum( abs( Result ) *SubCompanyPercent* PartnerCommission )  else sum( abs(Result) *SubCompanyPercent* PartnerCommission -  abs( Result)  * PartnerPercent* ZAgentCommission) end) as PartnerCommission,";
            //str += "sum(( -(Result)* PartnerPercent)) as Partner,";
            //str += "(case when AgentCommission=0  then sum( abs( Result ) *PartnerPercent* ZAgentCommission )  else sum( abs(Result) *PartnerPercent* ZAgentCommission -  abs( Result)  * ZAgentPercent* AgentCommission) end) as ZAgentCommission,";
            //str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
            //str += "(case when MemberCommission=0  then sum( abs( Result ) *ZAgentPercent * AgentCommission )  else sum( abs(Result) * ZAgentPercent *  AgentCommission -  abs( Result)  * AgentPercent* MemberCommission)  end) as AgentCommission,";
            //str += "sum((-(Result)* AgentPercent)) as Agent,";
            //str += "sum(abs(Result)*AgentPercent * MemberCommission) as MemberCommission,";
            //str += "(case when MemberPercent=0 then sum(Result) else sum(Result* MemberPercent) end) as Members,";
            //str += "BeginTime,time,Score,Scorehalf,BetType,Odds,BetItem,Amount,ValidAmount,Result,AgentPercent,ZAgentPercent,PartnerPercent,SubCompanyPercent,IP,Reason,date(BeginTime) from yafa.orderhistory where Status='" + status + "' and gameid=" + gameid + "";

            str += "sum((case when SubCompanyCommission=0 then  -(Result) *CompanyPercent  else -(Result) *CompanyPercent - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent*SubCompanyCommission end)) as Companys,";
            str += "sum(case when PartnerCommission=0 then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*CompanyPercent* SubCompanyCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent* SubCompanyCommission - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*(SubCompanyPercent+CompanyPercent)*PartnerCommission  end)  as SubCompanyCommission,";
            str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
            str += "sum((case when ZAgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission end)) as PartnerCommission,";
            str += "sum(( -(Result)* PartnerPercent)) as Partner,";
            str += "sum((case when AgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent)* AgentCommission end)) as ZAgentCommission,";
            str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
            str += "sum((case when MemberCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) * AgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) *  AgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission  end)) as AgentCommission,";
            str += "sum((-(Result)* AgentPercent)) as Agent,";
            str += "sum((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission) as MemberCommission,";
            str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end)) as Members,";
            str += "BeginTime,time,Score,Scorehalf,BetType,Odds,BetItem,Amount,ValidAmount,Result,AgentPercent,ZAgentPercent,PartnerPercent,SubCompanyPercent,IP,Reason,date(BeginTime) from yafa.orderhistory where Status='" + status + "' and gameid=" + gameid + "";

            if (!string.IsNullOrEmpty(betType))
            {
                str += " and BetType='" + betType + "' ";
            }
            if (!string.IsNullOrEmpty(agentName))
            {
                switch (roleId)
                {
                    case "2":
                        str += " and SubCompany='" + agentName + "' ";
                        break;
                    case "3":
                        str += " and Partner='" + agentName + "' ";
                        break;
                    case "4":
                        str += " and ZAgent='" + agentName + "' ";
                        break;
                    case "5":
                        str += " and Agent='" + agentName + "' ";
                        break;
                }
            }
            if (time != "")
            {
                str += " and date(BeginTime)='" + time + "'" + group;
            }
            else
            {
                str += " and date(BeginTime)>='" + time1 + "' and date(BeginTime)<= '" + time2 + "'" + group;
            }

            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        public string LeagueOrderDetail2(string time1, string time2, string language, string status, string gameid, string betType, string agentName, string roleId, string mtype)
        {
            string mysql = "";
            string group = "";
            string time = "";
            if (time1 == time2)
            {
                time = time1;
            }
            if (language == "zh-cn" || language == "zh-CN" || language == "zh-CN")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
                group = " group by leaguetw,Hometw,Awaytw,ID";
            }
            if (language == "zh-tw")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
                group = " group by leaguetw,Hometw,Awaytw,ID";
            }
            if (language == "en-us")
            {
                mysql = "leagueen as league,Homeen as Home,Awayen as Away";
                group = " group by leagueen,Homeen,Awayen,ID";
            }
            if (language == "th-th")
            {
                mysql = "leagueth as league,Hometh as Home,Awayth as Away";
                group = " group by leagueth,Homecn,Awayth,ID";
            }
            if (language == "vi-vn")
            {
                mysql = "leaguevn as league,Homevn as Home,Awayvn as Away";
                group = " group by leaguevn,Homevn,Awayvn,ID";
            }
            string str = "select " + mysql + ",UserName,BetType,BetItem,Handicap,OddsType,Status,Scoreathalf,";
            //str += "(case when SubCompanyCommission=0 then sum( -Result *CompanyPercent ) else sum(-Result *CompanyPercent - (-Result) *CompanyPercent*SubCompanyCommission) end) as Companys,";
            //str += "(case when Result>0 then 0 when PartnerCommission=0 then sum( abs(Result)*CompanyPercent* SubCompanyCommission ) else sum(abs(Result) *CompanyPercent* SubCompanyCommission - abs( Result)*SubCompanyPercent*PartnerCommission) end) as SubCompanyCommission,";
            //str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
            //str += "(case when Result>0 then 0 when ZAgentCommission=0  then sum( abs( Result ) *SubCompanyPercent* PartnerCommission )  else sum( abs(Result) *SubCompanyPercent* PartnerCommission -  abs( Result)  * PartnerPercent* ZAgentCommission) end) as PartnerCommission,";
            //str += "sum(( -(Result)* PartnerPercent)) as Partner,";
            //str += "(case when Result>0 then 0 when AgentCommission=0  then sum( abs( Result ) *PartnerPercent* ZAgentCommission )  else sum( abs(Result) *PartnerPercent* ZAgentCommission -  abs( Result)  * ZAgentPercent* AgentCommission) end) as ZAgentCommission,";
            //str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
            //str += "(case when Result>0 then 0 when MemberCommission=0  then sum( abs( Result ) *ZAgentPercent * AgentCommission )  else sum( abs(Result) * ZAgentPercent *  AgentCommission -  abs( Result)  * AgentPercent* MemberCommission)  end) as AgentCommission,";
            //str += "sum((-(Result)* AgentPercent)) as Agent,";
            //str += "(case when Result>0 then 0 else (sum(abs(Result)*AgentPercent * MemberCommission)) end) as MemberCommission,";
            //str += "(case when MemberPercent=0 then sum(Result) else sum(Result* MemberPercent) end) as Members,";
            //str += "BeginTime,time,Score,Scorehalf,BetType,Odds,BetItem,Amount,ValidAmount,Result,AgentPercent,ZAgentPercent,PartnerPercent,SubCompanyPercent,IP,Reason,date(BeginTime) from yafa.orderhistory where Status='" + status + "' and gameid=" + gameid + "";

            //str += "(case when SubCompanyCommission=0 then sum( -Result *CompanyPercent ) else sum(-Result *CompanyPercent - (abs(Result)) *CompanyPercent*SubCompanyCommission) end) as Companys,";
            //str += "(case when PartnerCommission=0 then sum( abs(Result)*CompanyPercent* SubCompanyCommission ) else sum(abs(Result) *CompanyPercent* SubCompanyCommission - abs( Result)*SubCompanyPercent*PartnerCommission) end) as SubCompanyCommission,";
            //str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
            //str += "(case when ZAgentCommission=0  then sum( abs( Result ) *SubCompanyPercent* PartnerCommission )  else sum( abs(Result) *SubCompanyPercent* PartnerCommission -  abs( Result)  * PartnerPercent* ZAgentCommission) end) as PartnerCommission,";
            //str += "sum(( -(Result)* PartnerPercent)) as Partner,";
            //str += "(case when AgentCommission=0  then sum( abs( Result ) *PartnerPercent* ZAgentCommission )  else sum( abs(Result) *PartnerPercent* ZAgentCommission -  abs( Result)  * ZAgentPercent* AgentCommission) end) as ZAgentCommission,";
            //str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
            //str += "(case when MemberCommission=0  then sum( abs( Result ) *ZAgentPercent * AgentCommission )  else sum( abs(Result) * ZAgentPercent *  AgentCommission -  abs( Result)  * AgentPercent* MemberCommission)  end) as AgentCommission,";
            //str += "sum((-(Result)* AgentPercent)) as Agent,";
            //str += "sum(abs(Result)*AgentPercent * MemberCommission) as MemberCommission,";
            //str += "(case when MemberPercent=0 then sum(Result) else sum(Result* MemberPercent) end) as Members,";
            //str += "BeginTime,time,Score,Scorehalf,BetType,Odds,BetItem,Amount,ValidAmount,Result,AgentPercent,ZAgentPercent,PartnerPercent,SubCompanyPercent,IP,Reason,date(BeginTime) from yafa.orderhistory where Status='" + status + "' and gameid=" + gameid + "";

            if (mtype == "1")
            {
                //本币（人民币）
                str += "sum((case when SubCompanyCommission=0 then  -(Result) *CompanyPercent  else -(Result) *CompanyPercent - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent*SubCompanyCommission end) * rate) as Companys,";
                str += "sum((case when PartnerCommission=0 then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*CompanyPercent* SubCompanyCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent* SubCompanyCommission - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*(SubCompanyPercent+CompanyPercent)*PartnerCommission  end) * rate)  as SubCompanyCommission,";
                str += "sum(( -(Result)* SubCompanyPercent) * rate) as SubCompany,";
                str += "sum((case when ZAgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission end) * rate) as PartnerCommission,";
                str += "sum(( -(Result)* PartnerPercent) * rate) as Partner,";
                str += "sum((case when AgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent)* AgentCommission end) * rate) as ZAgentCommission,";
                str += "sum((-(Result)* ZAgentPercent) * rate) as ZAgent,";
                str += "sum((case when MemberCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) * AgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) *  AgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission  end) * rate) as AgentCommission,";
                str += "sum((-(Result)* AgentPercent) * rate) as Agent,";
                str += "sum((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission * rate) as MemberCommission,";
                str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end) * rate) as Members,";
                str += "BeginTime,time,Score,Scorehalf,BetType,Odds,BetItem,(Amount * rate) as Amount,(ValidAmount * rate) as ValidAmount,(Result * rate) as Result,AgentPercent,ZAgentPercent,PartnerPercent,SubCompanyPercent,IP,Reason,date(BeginTime) from yafa.orderhistory where Status='" + status + "' and gameid=" + gameid + "";
            }
            else
            {
                str += "sum((case when SubCompanyCommission=0 then  -(Result) *CompanyPercent  else -(Result) *CompanyPercent - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent*SubCompanyCommission end)) as Companys,";
                str += "sum(case when PartnerCommission=0 then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*CompanyPercent* SubCompanyCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent* SubCompanyCommission - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*(SubCompanyPercent+CompanyPercent)*PartnerCommission  end)  as SubCompanyCommission,";
                str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
                str += "sum((case when ZAgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission end)) as PartnerCommission,";
                str += "sum(( -(Result)* PartnerPercent)) as Partner,";
                str += "sum((case when AgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent)* AgentCommission end)) as ZAgentCommission,";
                str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
                str += "sum((case when MemberCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) * AgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) *  AgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission  end)) as AgentCommission,";
                str += "sum((-(Result)* AgentPercent)) as Agent,";
                str += "sum((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission) as MemberCommission,";
                str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end)) as Members,";
                str += "BeginTime,time,Score,Scorehalf,BetType,Odds,BetItem,Amount,ValidAmount,Result,AgentPercent,ZAgentPercent,PartnerPercent,SubCompanyPercent,IP,Reason,date(BeginTime) from yafa.orderhistory where Status='" + status + "' and gameid=" + gameid + "";
            }

            if (!string.IsNullOrEmpty(betType))
            {
                str += " and BetType='" + betType + "' ";
            }
            if (!string.IsNullOrEmpty(agentName))
            {
                switch (roleId)
                {
                    case "2":
                        str += " and SubCompany='" + agentName + "' ";
                        break;
                    case "3":
                        str += " and Partner='" + agentName + "' ";
                        break;
                    case "4":
                        str += " and ZAgent='" + agentName + "' ";
                        break;
                    case "5":
                        str += " and Agent='" + agentName + "' ";
                        break;
                }
            }
            if (time != "")
            {
                str += " and date(BeginTime)='" + time + "'" + group;
            }
            else
            {
                str += " and date(BeginTime)>='" + time1 + "' and date(BeginTime)<= '" + time2 + "'" + group;
            }

            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }


        public string GetMatch(string time1, string time2, string language, string status, string type)
        {
            string time = "";
            if (time1 == time2)
            {
                time = time1;
            }
            string mysql = "";
            if (language == "zh-cn" || language == "zh-CN")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
            }
            if (language == "zh-tw")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
            }
            if (language == "en-us")
            {
                mysql = "leagueen as league,Homeen as Home,Awayen as Away";
            }
            if (language == "th-th")
            {
                mysql = "leagueth as league,Hometh as Home,Awayth as Away";
            }
            if (language == "vi-vn")
            {
                mysql = "leaguevn as league,Homevn as Home,Awayvn as Away";
            }
            string str = "select " + mysql + "," + type + " as UserName,";
            //str += "sum((case when Result>0 then  -(Result) *CompanyPercent when SubCompanyCommission=0 then  abs(Result) *CompanyPercent  else abs(Result) *CompanyPercent - abs(Result) *CompanyPercent*SubCompanyCommission end)) as Companys,";
            //str += "sum(case when Result>0 then 0  when PartnerCommission=0 then  abs(Result)*CompanyPercent* SubCompanyCommission  else abs(Result) *CompanyPercent* SubCompanyCommission - abs( Result)*SubCompanyPercent*PartnerCommission  end)  as SubCompanyCommission,";
            //str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
            //str += "sum((case when Result>0 then 0 when ZAgentCommission=0  then  abs( Result ) *SubCompanyPercent* PartnerCommission  else abs(Result) *SubCompanyPercent* PartnerCommission -  abs( Result)  * PartnerPercent* ZAgentCommission end)) as PartnerCommission,";
            //str += "sum(( -(Result)* PartnerPercent)) as Partner,";
            //str += "sum((case when Result>0 then 0 when AgentCommission=0  then  abs( Result ) *PartnerPercent* ZAgentCommission   else  abs(Result) *PartnerPercent* ZAgentCommission -  abs( Result)  * ZAgentPercent* AgentCommission end)) as ZAgentCommission,";
            //str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
            //str += "sum((case when Result>0 then 0 when MemberCommission=0  then  abs( Result ) *ZAgentPercent * AgentCommission   else  abs(Result) * ZAgentPercent *  AgentCommission -  abs( Result)  * AgentPercent* MemberCommission  end)) as AgentCommission,";
            //str += "sum((-(Result)* AgentPercent)) as Agent,";
            //str += "sum((case when Result>0 then 0 else (abs(Result)*AgentPercent * MemberCommission) end)) as MemberCommission,";
            //str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end)) as Members,";
            //str +="BeginTime,Score,Scorehalf,BetType,Odds,BetItem,sum(Amount) as Amount,sum(ValidAmount) as ValidAmount,Result,Member,MemberPercent,AgentPercent,ZAgentPercent,PartnerPercent,CompanyPercent,SubCompanyPercent,Reason,date(BeginTime) from yafa.orderhistory where orderhistory.Status='" + status + "'";

            str += "sum((case when SubCompanyCommission=0 then  -(Result) *CompanyPercent  else -(Result) *CompanyPercent - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent*SubCompanyCommission end)) as Companys,";
            str += "sum(case when PartnerCommission=0 then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*CompanyPercent* SubCompanyCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent* SubCompanyCommission - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*(SubCompanyPercent+CompanyPercent)*PartnerCommission  end)  as SubCompanyCommission,";
            str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
            str += "sum((case when ZAgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission end)) as PartnerCommission,";
            str += "sum(( -(Result)* PartnerPercent)) as Partner,";
            str += "sum((case when AgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent)* AgentCommission end)) as ZAgentCommission,";
            str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
            str += "sum((case when MemberCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) * AgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) *  AgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission  end)) as AgentCommission,";
            str += "sum((-(Result)* AgentPercent)) as Agent,";
            str += "sum((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission) as MemberCommission,";
            str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end)) as Members,";
            str += "BeginTime,Score,Scorehalf,BetType,Odds,BetItem,sum(Amount) as Amount,sum(ValidAmount) as ValidAmount,sum(abs(Result)) as result,Member,MemberPercent,AgentPercent,ZAgentPercent,PartnerPercent,CompanyPercent,SubCompanyPercent,Reason,date(BeginTime) from yafa.orderhistory where orderhistory.Status='" + status + "'";

            if (time != "")
            {
                str += " and date(BeginTime)='" + time + "'";
            }
            else {
                str += " and date(BeginTime)>='" + time1 + "' and date(BeginTime)<= '" + time2 + "'";
            }
            str += " group by "+type;
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));

        }

        public string GetMatch2(string time1, string time2, string language, string status, string type, string mtype)
        {
            string time = "";
            string subsql = "";
            string subsql2 = "";

            if (time1 == time2)
            {
                time = time1;
            }
            //string mysql = "";
            //if (language == "zh-cn" || language == "zh-CN")
            //{
            //    mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
            //}
            //if (language == "zh-tw")
            //{
            //    mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
            //}
            //if (language == "en-us")
            //{
            //    mysql = "leagueen as league,Homeen as Home,Awayen as Away";
            //}
            //if (language == "th-th")
            //{
            //    mysql = "leagueth as league,Hometh as Home,Awayth as Away";
            //}
            //if (language == "vi-vn")
            //{
            //    mysql = "leaguevn as league,Homevn as Home,Awayvn as Away";
            //}
            if (string.IsNullOrEmpty(time1) || string.IsNullOrEmpty(time2))
            {
                return "";
            }
            else
            {
                subsql += " date(UpdateTime)>='" + time1 + "' and date(UpdateTime)<= '" + time2 + "'";
                subsql2 += " date(enddate)>='" + time1 + "' and date(enddate)<= '" + time2 + "'";
            }

            string str = "select aa." + type + " as UserName,";

            //if (mtype == "1")
            //{
            //    //本币(换算为人民币)
            //    str += "sum((case when SubCompanyCommission=0 then  -(Result) *CompanyPercent  else -(Result) *CompanyPercent - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent*SubCompanyCommission end) * rate) as Companys,";
            //    str += "sum((case when PartnerCommission=0 then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*CompanyPercent* SubCompanyCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent* SubCompanyCommission - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*(SubCompanyPercent+CompanyPercent)*PartnerCommission  end) * rate)  as SubCompanyCommission,";
            //    str += "sum(( -(Result)* SubCompanyPercent) * rate) as SubCompany,";
            //    str += "sum((case when ZAgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission end) * rate) as PartnerCommission,";
            //    str += "sum(( -(Result)* PartnerPercent) * rate) as Partner,";
            //    str += "sum((case when AgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent)* AgentCommission end) * rate) as ZAgentCommission,";
            //    str += "sum((-(Result)* ZAgentPercent) * rate) as ZAgent,";
            //    str += "sum((case when MemberCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) * AgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) *  AgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission  end) * rate) as AgentCommission,";
            //    str += "sum((-(Result)* AgentPercent) * rate) as Agent,";
            //    str += "sum(((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission) * rate) as MemberCommission,";
            //    str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end) * rate) as Members,";
            //    str += "BeginTime,Score,Scorehalf,BetType,Odds,BetItem,sum(Amount * rate) as Amount,sum(ValidAmount * rate) as ValidAmount,sum(abs(Result) * rate) as result,Member,MemberPercent,AgentPercent,ZAgentPercent,PartnerPercent,CompanyPercent,SubCompanyPercent,Reason,date(BeginTime) from yafa.orderhistory where orderhistory.Status='" + status + "'";
            //}
            //else
            //{
            //    //外币
            //    str += "sum((case when SubCompanyCommission=0 then  -(Result) *CompanyPercent  else -(Result) *CompanyPercent - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent*SubCompanyCommission end)) as Companys,";
            //    str += "sum(case when PartnerCommission=0 then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*CompanyPercent* SubCompanyCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent* SubCompanyCommission - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*(SubCompanyPercent+CompanyPercent)*PartnerCommission  end)  as SubCompanyCommission,";
            //    str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
            //    str += "sum((case when ZAgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission end)) as PartnerCommission,";
            //    str += "sum(( -(Result)* PartnerPercent)) as Partner,";
            //    str += "sum((case when AgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent)* AgentCommission end)) as ZAgentCommission,";
            //    str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
            //    str += "sum((case when MemberCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) * AgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) *  AgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission  end)) as AgentCommission,";
            //    str += "sum((-(Result)* AgentPercent)) as Agent,";
            //    str += "sum((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission) as MemberCommission,";
            //    str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end)) as Members,";
            //    str += "BeginTime,Score,Scorehalf,BetType,Odds,BetItem,sum(Amount) as Amount,sum(ValidAmount) as ValidAmount,sum(abs(Result)) as result,Member,MemberPercent,AgentPercent,ZAgentPercent,PartnerPercent,CompanyPercent,SubCompanyPercent,Reason,date(BeginTime) from yafa.orderhistory where orderhistory.Status='" + status + "'";
            //}

            str += "  sum( if(aa.type='1', amount, 0 )  ) as 'ckamount', sum(  if(aa.type='2', amount, 0 )   ) as 'qkamount', sum(  if(aa.type='3', amount, 0 )   ) as 'hlamount', sum(   if(aa.type='4', amount, 0 )  ) as 'fsamount', sum(  if(aa.type='8', amount, 0 )   ) as 'winandlose', sum(  if(aa.type='20', amount, 0 )   ) as 'validamount', sum(  if(aa.type='21', amount, 0 )   ) as 'winlose' from ";
            str+=" ( ";
            str+=" select b.username as username,b.SubCompany as SubCompany,b.Partner as partner,b.GeneralAgent as GeneralAgent,b.Agent as agent,a.type, a.amount, a.`time`";
            str += " from";
            str += " ((select `billnoticehistory`.`UserName` AS `username`,`billnoticehistory`.`Type` AS `type`,`billnoticehistory`.`Amount` AS `amount`,`billnoticehistory`.`UpdateTime` AS `time` from `billnoticehistory` where ( " + subsql + " and  (`billnoticehistory`.`Status` <> _utf8'3') and (`billnoticehistory`.`Type` in (_utf8'1',_utf8'2',_utf8'3',_utf8'4',_utf8'8')))) union (select gameinforeport_ea.`login` AS `login`,_utf8'20' AS `20`,gameinforeport_ea.`bet_amount` AS `handle`,gameinforeport_ea.`enddate` AS `enddate` from gameinforeport_ea where " + subsql2 + ") union (select gameinforeport_ea.`login` AS `login`,_utf8'21' AS `21`,gameinforeport_ea.`hold` AS `hold`,gameinforeport_ea.`enddate` AS `enddate` from gameinforeport_ea where " + subsql2 + ") union (select pt_gameinfo.`login` AS `login`,_utf8'20' AS `20`,pt_gameinfo.`bet_amount` AS `bet_amount`,pt_gameinfo.`enddate` AS `enddate` from pt_gameinfo where " + subsql2 + " ) union (select pt_gameinfo.`login` AS `login`,_utf8'21' AS `21`,pt_gameinfo.`hold` AS `hold`,pt_gameinfo.`enddate` AS `enddate` from pt_gameinfo where " + subsql2 + " )) a ";
            str += " inner join `user` b on a.username=b.username";
            str += ")  as aa";
            str += " where 1=1 ";

            str += " group by aa." + type;
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));

        }

        /// <summary>
        /// 月报表各级查询
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <param name="language"></param>
        /// <param name="status"></param>
        /// <param name="type"></param>
        /// <param name="mtype"></param>
        /// <returns></returns>
        public string GetMatch3(string time1, string time2, string language, string status, string type, string mtype)
        {
            string time = "";
            if (time1 == time2)
            {
                time = time1;
            }

            string str = "select aa." + type + " as UserName,aa." + type + "Percent as Percent, ";
            str += "  sum( if(aa.type='1', amount, 0 )  ) as 'ckamount', sum(  if(aa.type='2', amount, 0 )   ) as 'qkamount', sum(  if(aa.type='3', amount, 0 )   ) as 'hlamount', sum(   if(aa.type='4', amount, 0 )  ) as 'fsamount',  sum(  if(aa.type='8', amount, 0 )   ) as 'winandlose', sum(  if(aa.type='20', amount, 0 )   ) as 'validamount', sum(  if(aa.type='21', amount, 0 )   ) as 'winlose' from ";
            str += " ( ";
            str += " select b.username as username,b.SubCompany as SubCompany,b.SubCompanyPercent as SubCompanyPercent,b.Partner as partner,b.PartnerPercent as PartnerPercent,b.GeneralAgent as ZAgent,b.GeneralAgentPercent as ZAgentPercent,b.Agent as agent,b.AgentPercent as AgentPercent,a.type, a.amount, a.`time`";
            str += " from";
            str += " v_billlist a ";
            str += " left join `user` b on a.username=b.username";
            str += ")  as aa";
            str += " where 1=1 ";




            if (time != "")
            {
                str += " and date(aa.time)='" + time + "'";
            }
            else
            {
                str += " and date(aa.time)>='" + time1 + "' and date(aa.time)<= '" + time2 + "'";
            }
            str += " group by aa." + type;
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));

        }

        public string GetStatisticsT(string time1, string time2, string group, string sorts, string user,string ip)
        {
            string mysql = "";
            if (user != "")
            {
                mysql = " and userName='" + user + "'";
            }
            if (ip != "")
            {
                mysql = " and ip='" + ip + "'";
            }
            string str = "";
            if (time2 != "")
            {
                str = "select userName,ip,agent,zagent,partner,subCompany,userLevel,Coefficient,Proportion, count(*) as countNumber,sum(Amount) as amount";

                str += ",(case when(select count(*) as win from orderhistory as a where Result>0 and a.UserName=orderhistory.UserName";
                str += " and ('" + time1 + "')<=time and ('" + time2 + "')>time and status=1 group by UserName)is null then 0 else ";
                str += "(select count(*) as win from orderhistory as a where Result>0 and a.UserName=orderhistory.UserName";
                str += " and ('" + time1 + "')<=time and ('" + time2 + "')>time and status=1 group by UserName)end) as win";

                str += ",(case when(select count(*) as lost from orderhistory as a where Result<0 and a.UserName=orderhistory.UserName";
                str += " and ('" + time1 + "')<=time and ('" + time2 + "')>time and status=1 group by UserName)is null then 0 else ";
                str += "(select count(*) as lost from orderhistory as a where Result<0 and a.UserName=orderhistory.UserName";
                str += " and ('" + time1 + "')<=time and ('" + time2 + "')>time and status=1 group by UserName)end) as lost";

                str += ",(case when(select sum(Amount) as win from orderhistory as a where Result>0 and a.UserName=orderhistory.UserName";
                str += " and ('" + time1 + "')<=time and ('" + time2 + "')>time and status=1 group by UserName)is null then 0 else ";
                str += "(select sum(Amount) as win from orderhistory as a where Result>0 and a.UserName=orderhistory.UserName";
                str += " and ('" + time1 + "')<=time and ('" + time2 + "')>time and status=1 group by UserName)end) as winAmount";

                str += ",(case when(select sum(Amount)as lost from orderhistory as a where Result<0 and a.UserName=orderhistory.UserName";
                str += " and ('" + time1 + "')<=time and ('" + time2 + "')>time and status=1 group by UserName)is null then 0 else ";
                str += "(select sum(Amount)as lost from orderhistory as a where Result<0 and a.UserName=orderhistory.UserName";
                str += " and ('" + time1 + "')<=time and ('" + time2 + "')>time and status=1 group by UserName)end) as lostAmount,";

                str += "((case when(select count(*) as win from orderhistory as a where Result>0 and a.UserName=orderhistory.UserName and ('" + time1 + "')<=date(time) and ('" + time2 + "')>date(time) and status=1 group by UserName)is null then 0 else ";
                str += "(select count(*) as win from orderhistory as a where Result>0 and a.UserName=orderhistory.UserName and ('" + time1 + "')<=date(time) and ('" + time2 + "')>date(time) and status=1 group by UserName) / count(*)  end)) as lostRate ";

                str += "from orderhistory where ('" + time1 + "')<=time and ('" + time2 + "')>time" + mysql + " and status=1 group by UserName";
                str += " order by " + group + " " + sorts + "";
            }
            else {
                str = "select userName,ip,agent,zagent,partner,subCompany,userLevel, count(*) as countNumber,sum(Amount) as amount";

                str += ",(case when(select count(*) as win from orderhistory as a where Result>0 and a.UserName=orderhistory.UserName";
                str += " and ('" + time1 + "')=date(time) and status=1 group by UserName)is null then 0 else ";
                str += "(select count(*) as win from orderhistory as a where Result>0 and a.UserName=orderhistory.UserName";
                str += " and ('" + time1 + "')=date(time) and status=1 group by UserName)end) as win";

                str += ",(case when(select count(*) as lost from orderhistory as a where Result<0 and a.UserName=orderhistory.UserName";
                str += " and ('" + time1 + "')=date(time) and status=1 group by UserName)is null then 0 else ";
                str += "(select count(*) as lost from orderhistory as a where Result<0 and a.UserName=orderhistory.UserName";
                str += " and ('" + time1 + "')=date(time) and status=1 group by UserName)end) as lost";

                str += ",(case when(select sum(Amount) as win from orderhistory as a where Result>0 and a.UserName=orderhistory.UserName";
                str += " and ('" + time1 + "')=date(time) and status=1 group by UserName)is null then 0 else ";
                str += "(select sum(Amount) as win from orderhistory as a where Result>0 and a.UserName=orderhistory.UserName";
                str += " and ('" + time1 + "')=date(time) and status=1 group by UserName)end) as winAmount";

                str += ",(case when(select sum(Amount)as lost from orderhistory as a where Result<0 and a.UserName=orderhistory.UserName";
                str += " and ('" + time1 + "')=date(time) and status=1 group by UserName)is null then 0 else ";
                str += "(select sum(Amount)as lost from orderhistory as a where Result<0 and a.UserName=orderhistory.UserName";
                str += " and ('" + time1 + "')=date(time) and status=1 group by UserName)end) as lostAmount,";

                //str += "((case when(select count(*) as win from orderhistory as a where Result>0 and a.UserName=orderhistory.UserName and ('" + time1 + "')=date(time) group by UserName)is null then 0 else ";
                //str += "(select count(*) as win from orderhistory as a where Result>0 and a.UserName=orderhistory.UserName and ('" + time1 + "')=date(time) group by UserName)/count(*)  end)) as lostRate ";
                str += "((case when(select count(*) as win from orderhistory as a where Result>0 and a.UserName=orderhistory.UserName and ('" + time1 + "')=date(time) and status=1 group by UserName)is null then 0 else (select count(*) as win from orderhistory as a where Result>0 and a.UserName=orderhistory.UserName and ('" + time1 + "')=date(time) and status=1 group by UserName) / count(*)  end)) as lostRate ";
                str += "from orderhistory where ('" + time1 + "')=date(time)" + mysql + " and status=1 group by UserName";
                str += " order by " + group + " " + sorts + "";
            }

            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        public string GetStatisticsIpT(string time1, string time2, string group, string sorts, string user, string ip)
        {
            string mysql = "";
            if (user != "")
            {
                mysql = " and userName='" + user + "'";
            }
            if (ip != "")
            {
                mysql = " and ip='" + ip + "'";
            }
            string str = "";
            if (time2 != "")
            {
                str = "select distinct ip, count(*) as countNumber,sum(Amount) as amount";

                str += ",(case when(select count(*) as win from orderhistory as a where Result>0 and a.IP=orderhistory.IP";
                str += " and ('" + time1 + "')<=time and ('" + time2 + "')>time and status=1 group by IP)is null then 0 else ";
                str += "(select count(*) as win from orderhistory as a where Result>0 and a.IP=orderhistory.IP";
                str += " and ('" + time1 + "')<=time and ('" + time2 + "')>time and status=1 group by IP)end) as win";

                str += ",(case when(select count(*) as lost from orderhistory as a where Result<0 and a.IP=orderhistory.IP";
                str += " and ('" + time1 + "')<=time and ('" + time2 + "')>time and status=1 group by IP)is null then 0 else ";
                str += "(select count(*) as lost from orderhistory as a where Result<0 and a.IP=orderhistory.IP";
                str += " and ('" + time1 + "')<=time and ('" + time2 + "')>time and status=1 group by IP)end) as lost";

                str += ",(case when(select sum(Amount) as win from orderhistory as a where Result>0 and a.IP=orderhistory.IP";
                str += " and ('" + time1 + "')<=time and ('" + time2 + "')>time and status=1 group by IP)is null then 0 else ";
                str += "(select sum(Amount) as win from orderhistory as a where Result>0 and a.IP=orderhistory.IP";
                str += " and ('" + time1 + "')<=time and ('" + time2 + "')>time and status=1 group by IP)end) as winAmount";

                str += ",(case when(select sum(Amount)as lost from orderhistory as a where Result<0 and a.IP=orderhistory.IP";
                str += " and ('" + time1 + "')<=time and ('" + time2 + "')>time and status=1 group by IP)is null then 0 else ";
                str += "(select sum(Amount)as lost from orderhistory as a where Result<0 and a.IP=orderhistory.IP";
                str += " and ('" + time1 + "')<=time and ('" + time2 + "')>time and status=1 group by IP)end) as lostAmount,";

                str += "((case when(select count(*) as win from orderhistory as a where Result>0 and a.IP=orderhistory.IP and ('" + time1 + "')<=date(time) and ('" + time2 + "')>date(time) and status=1 group by IP)is null then 0 else ";
                str += "(select count(*) as win from orderhistory as a where Result>0 and a.IP=orderhistory.IP and ('" + time1 + "')<=date(time) and ('" + time2 + "')>date(time) and status=1 group by IP) / count(*)  end)) as lostRate ";

                str += "from orderhistory where ('" + time1 + "')<=time and ('" + time2 + "')>time" + mysql + " and status=1 group by IP";
                str += " order by " + group + " " + sorts + "";
            }
            else
            {
                str = "select userName,ip,agent,zagent,partner,subCompany,userLevel, count(*) as countNumber,sum(Amount) as amount";

                str += ",(case when(select count(*) as win from orderhistory as a where Result>0 and a.IP=orderhistory.IP";
                str += " and ('" + time1 + "')=date(time) and status=1  group by IP)is null then 0 else ";
                str += "(select count(*) as win from orderhistory as a where Result>0 and a.IP=orderhistory.IP";
                str += " and ('" + time1 + "')=date(time) and status=1  group by IP)end) as win";

                str += ",(case when(select count(*) as lost from orderhistory as a where Result<0 and a.IP=orderhistory.IP";
                str += " and ('" + time1 + "')=date(time) and status=1  group by IP)is null then 0 else ";
                str += "(select count(*) as lost from orderhistory as a where Result<0 and a.IP=orderhistory.IP";
                str += " and ('" + time1 + "')=date(time) and status=1  group by IP)end) as lost";

                str += ",(case when(select sum(Amount) as win from orderhistory as a where Result>0 and a.IP=orderhistory.IP";
                str += " and ('" + time1 + "')=date(time) and status=1  group by IP)is null then 0 else ";
                str += "(select sum(Amount) as win from orderhistory as a where Result>0 and a.IP=orderhistory.IP";
                str += " and ('" + time1 + "')=date(time) and status=1  group by IP)end) as winAmount";

                str += ",(case when(select sum(Amount)as lost from orderhistory as a where Result<0 and a.IP=orderhistory.IP";
                str += " and ('" + time1 + "')=date(time) and status=1  group by IP)is null then 0 else ";
                str += "(select sum(Amount)as lost from orderhistory as a where Result<0 and a.IP=orderhistory.IP";
                str += " and ('" + time1 + "')=date(time) and status=1  group by IP)end) as lostAmount,";

                //str += "((case when(select count(*) as win from orderhistory as a where Result>0 and a.UserName=orderhistory.UserName and ('" + time1 + "')=date(time) group by UserName)is null then 0 else ";
                //str += "(select count(*) as win from orderhistory as a where Result>0 and a.UserName=orderhistory.UserName and ('" + time1 + "')=date(time) group by UserName)/count(*)  end)) as lostRate ";
                str += "((case when(select count(*) as win from orderhistory as a where Result>0 and a.IP=orderhistory.IP and ('" + time1 + "')=date(time) and status=1  group by IP)is null then 0 else (select count(*) as win from orderhistory as a where Result>0 and a.IP=orderhistory.IP and ('" + time1 + "')=date(time) and status=1  group by IP) / count(*)  end)) as lostRate ";
                str += "from orderhistory where ('" + time1 + "')=date(time)" + mysql + " and status=1 group by IP";
                str += " order by " + group + " " + sorts + "";
            }
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        public string GetStatistics(int day1, int day2, string date, string time, string group, string sorts,string user,string ip)
        {
            string mysql = "";
            if (user!="")
            {
                mysql = " and userName='"+user+"'";
            }
            if (ip != "")
            {
                mysql = " and ip='" + ip + "'";
            }
            string str = "select date(time),userName,ip,agent,zagent,partner,subCompany,userLevel,Coefficient,Proportion, count(*) as countNumber,sum(Amount) as amount";

            str += ",(case when(select count(*) as win from orderhistory as a where Result>0 and a.UserName=orderhistory.UserName";
            str += " and (interval " + day1 + " " + date + " + '" + time + "')<=date(time) and (interval " + day2 + " " + date + " + '" + time + "')>=date(time) and status=1 group by UserName)is null then 0 else ";
            str += "(select count(*) as win from orderhistory as a where Result>0 and a.UserName=orderhistory.UserName";
            str += " and (interval " + day1 + " " + date + " + '" + time + "')<=date(time) and (interval " + day2 + " " + date + " + '" + time + "')>=date(time) and status=1 group by UserName)end) as win";

            str += ",(case when(select count(*) as lost from orderhistory as a where Result<0 and a.UserName=orderhistory.UserName";
            str += " and (interval " + day1 + " " + date + " + '" + time + "')<=date(time) and (interval " + day2 + " " + date + " + '" + time + "')>=date(time) and status=1 group by UserName)is null then 0 else ";
            str += "(select count(*) as lost from orderhistory as a where Result<0 and a.UserName=orderhistory.UserName";
            str += " and (interval " + day1 + " " + date + " + '" + time + "')<=date(time) and (interval " + day2 + " " + date + " + '" + time + "')>=date(time) and status=1 group by UserName)end) as lost";

            str += ",(case when(select sum(Amount) as win from orderhistory as a where Result>0 and a.UserName=orderhistory.UserName";
            str += " and (interval " + day1 + " " + date + " + '" + time + "')<=date(time) and (interval " + day2 + " " + date + " + '" + time + "')>=date(time) and status=1 group by UserName)is null then 0 else ";
            str += "(select sum(Amount) as win from orderhistory as a where Result>0 and a.UserName=orderhistory.UserName";
            str += " and (interval " + day1 + " " + date + " + '" + time + "')<=date(time) and (interval " + day2 + " " + date + " + '" + time + "')>=date(time) and status=1 group by UserName)end) as winAmount";

            str += ",(case when(select sum(Amount)as lost from orderhistory as a where Result<0 and a.UserName=orderhistory.UserName";
            str += " and (interval " + day1 + " " + date + " + '" + time + "')<=date(time) and (interval " + day2 + " " + date + " + '" + time + "')>=date(time) and status=1 group by UserName)is null then 0 else ";
            str += "(select sum(Amount)as lost from orderhistory as a where Result<0 and a.UserName=orderhistory.UserName";
            str += " and (interval " + day1 + " " + date + " + '" + time + "')<=date(time) and (interval " + day2 + " " + date + " + '" + time + "')>=date(time) and status=1 group by UserName)end) as lostAmount,";

            str += "((case when(select count(*) as win from orderhistory as a where Result>0 and a.UserName=orderhistory.UserName and (interval " + day1 + " " + date + " + '" + time + "')<=date(time) and (interval " + day2 + " " + date + " + '" + time + "')>=date(time) and status=1 group by UserName)is null then 0 else ";
            str += "(select count(*) as win from orderhistory as a where Result>0 and a.UserName=orderhistory.UserName and (interval " + day1 + " " + date + " + '" + time + "')<=date(time) and (interval " + day2 + " " + date + " + '" + time + "')>=date(time) and status=1 group by UserName) / count(*)  end)) as lostRate ";

            str += "from orderhistory where (interval " + day1 + " " + date + " + '" + time + "')<=date(time) and (interval " + day2 + " " + date + " + '" + time + "')>=date(time)" + mysql + " and status=1 group by UserName";
            str += " order by "+group+" "+sorts+"";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }


        public string GetMatch(string time1, string time2, string language, string status, string type, string user)
        {
            string time = "";
            if (time1 == time2)
            {
                time = time1;
            }
            string mysql = "";
            if (language == "zh-cn" || language == "zh-CN")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
            }
            if (language == "zh-tw")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
            }
            if (language == "en-us")
            {
                mysql = "leagueen as league,Homeen as Home,Awayen as Away";
            }
            if (language == "th-th")
            {
                mysql = "leagueth as league,Hometh as Home,Awayth as Away";
            }
            if (language == "vi-vn")
            {
                mysql = "leaguevn as league,Homevn as Home,Awayvn as Away";
            }
            string str = "select " + mysql + "," + type + " as UserName,";
            //str += "sum((case when Result>0 then  -(Result) *CompanyPercent when SubCompanyCommission=0 then  abs(Result) *CompanyPercent  else abs(Result) *CompanyPercent - abs(Result) *CompanyPercent*SubCompanyCommission end)) as Companys,";
            //str += "sum(case when Result>0 then 0  when PartnerCommission=0 then  abs(Result)*CompanyPercent* SubCompanyCommission  else abs(Result) *CompanyPercent* SubCompanyCommission - abs( Result)*SubCompanyPercent*PartnerCommission  end)  as SubCompanyCommission,";
            //str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
            //str += "sum((case when Result>0 then 0 when ZAgentCommission=0  then  abs( Result ) *SubCompanyPercent* PartnerCommission  else abs(Result) *SubCompanyPercent* PartnerCommission -  abs( Result)  * PartnerPercent* ZAgentCommission end)) as PartnerCommission,";
            //str += "sum(( -(Result)* PartnerPercent)) as Partner,";
            //str += "sum((case when Result>0 then 0 when AgentCommission=0  then  abs( Result ) *PartnerPercent* ZAgentCommission   else  abs(Result) *PartnerPercent* ZAgentCommission -  abs( Result)  * ZAgentPercent* AgentCommission end)) as ZAgentCommission,";
            //str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
            //str += "sum((case when Result>0 then 0 when MemberCommission=0  then  abs( Result ) *ZAgentPercent * AgentCommission   else  abs(Result) * ZAgentPercent *  AgentCommission -  abs( Result)  * AgentPercent* MemberCommission  end)) as AgentCommission,";
            //str += "sum((-(Result)* AgentPercent)) as Agent,";
            //str += "sum((case when Result>0 then 0 else (abs(Result)*AgentPercent * MemberCommission) end)) as MemberCommission,";
            //str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end)) as Members,";
            //str += "BeginTime,Score,Scorehalf,BetType,Odds,BetItem,sum(Amount) as Amount,sum(ValidAmount) as ValidAmount,Result,Member,MemberPercent,AgentPercent,ZAgentPercent,PartnerPercent,CompanyPercent,SubCompanyPercent,Reason,date(BeginTime) from yafa.orderhistory where orderhistory.Status='" + status + "'and " + type + "='" + user + "'";
            
            //str += "sum((case when SubCompanyCommission=0 then  -(Result) *CompanyPercent  else -(Result) *CompanyPercent - abs(Result) *CompanyPercent*SubCompanyCommission end)) as Companys,";
            //str += "sum(case  when PartnerCommission=0 then  abs(Result)*CompanyPercent* SubCompanyCommission  else abs(Result) *CompanyPercent* SubCompanyCommission - abs( Result)*SubCompanyPercent*PartnerCommission  end)  as SubCompanyCommission,";
            //str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
            //str += "sum((case when ZAgentCommission=0  then  abs( Result ) *SubCompanyPercent* PartnerCommission  else abs(Result) *SubCompanyPercent* PartnerCommission -  abs( Result)  * PartnerPercent* ZAgentCommission end)) as PartnerCommission,";
            //str += "sum(( -(Result)* PartnerPercent)) as Partner,";
            //str += "sum((case when AgentCommission=0  then  abs( Result ) *PartnerPercent* ZAgentCommission   else  abs(Result) *PartnerPercent* ZAgentCommission -  abs( Result)  * ZAgentPercent* AgentCommission end)) as ZAgentCommission,";
            //str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
            //str += "sum((case when MemberCommission=0  then  abs( Result ) *ZAgentPercent * AgentCommission   else  abs(Result) * ZAgentPercent *  AgentCommission -  abs( Result)  * AgentPercent* MemberCommission  end)) as AgentCommission,";
            //str += "sum((-(Result)* AgentPercent)) as Agent,";
            //str += "sum(abs(Result)*AgentPercent * MemberCommission) as MemberCommission,";
            //str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end)) as Members,";
            //str += "BeginTime,Score,Scorehalf,BetType,Odds,BetItem,sum(Amount) as Amount,sum(ValidAmount) as ValidAmount,sum(abs(Result)) as result,Member,MemberPercent,AgentPercent,ZAgentPercent,PartnerPercent,CompanyPercent,SubCompanyPercent,Reason,date(BeginTime) from yafa.orderhistory where orderhistory.Status='" + status + "'and " + type + "='" + user + "'";

            str += "sum((case when SubCompanyCommission=0 then  -(Result) *CompanyPercent  else -(Result) *CompanyPercent - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent*SubCompanyCommission end)) as Companys,";
            str += "sum(case when PartnerCommission=0 then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*CompanyPercent* SubCompanyCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *CompanyPercent* SubCompanyCommission - (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)*(SubCompanyPercent+CompanyPercent)*PartnerCommission  end)  as SubCompanyCommission,";
            str += "sum(( -(Result)* SubCompanyPercent)) as SubCompany,";
            str += "sum((case when ZAgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission  else (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(SubCompanyPercent+CompanyPercent)* PartnerCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission end)) as PartnerCommission,";
            str += "sum(( -(Result)* PartnerPercent)) as Partner,";
            str += "sum((case when AgentCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(PartnerPercent+SubCompanyPercent+CompanyPercent)* ZAgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end)  * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent)* AgentCommission end)) as ZAgentCommission,";
            str += "sum((-(Result)* ZAgentPercent)) as ZAgent,";
            str += "sum((case when MemberCommission=0  then  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) *(ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) * AgentCommission   else  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * (ZAgentPercent+PartnerPercent+SubCompanyPercent+CompanyPercent) *  AgentCommission -  (case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission  end)) as AgentCommission,";
            str += "sum((-(Result)* AgentPercent)) as Agent,";
            str += "sum((case when (ValidAmount/abs(Result))=2 then Amount/2 when (ValidAmount*Odds/abs(Result))=2 then Amount/2 when (Amount/abs(Result))=2 then Amount/2 when Result=0 then 0 else Amount  end) * MemberCommission) as MemberCommission,";
            str += "sum((case when MemberPercent=0 then Result else Result* MemberPercent end)) as Members,";
            str += "BeginTime,Score,Scorehalf,BetType,Odds,BetItem,sum(Amount) as Amount,sum(ValidAmount) as ValidAmount,sum(abs(Result)) as result,Member,MemberPercent,AgentPercent,ZAgentPercent,PartnerPercent,CompanyPercent,SubCompanyPercent,Reason,date(BeginTime) from yafa.orderhistory where orderhistory.Status='" + status + "'and " + type + "='" + user + "'";

            if (time != "")
            {
                str += " and date(BeginTime)='" + time + "'";
            }
            else
            {
                str += " and date(BeginTime)>='" + time1 + "' and date(BeginTime)<= '" + time2 + "'";
            }
            str += " group by " + type;
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        public string GetMatchResult(string time1, string time2, string language, string league, string home, string away, string status)
        {
            string time = string.Empty;
            string lan = string.Empty;
            if (language == "zh-cn" || language == "zh-CN")
            {
                lan = "cn";
            }
            else if (language == "zh-tw")
            {
                lan = "tw";
            }
            else if (language == "en-us")
            {
                lan = "en";
            }
            else if (language == "th-th")
            {
                lan = "th";
            }
            else if (language == "vi-vn")
            {
                lan = "vn";
            }
            string str = "select distinct league" + lan + " as league,Home" + lan + " as Home,Away" + lan + " as Away,BeginTime,score,halfhomescore,halfawayscore,resulthomescore,resultawayscore,date(BeginTime),scoreinputtime,scoreinputuser,jstime,jsuser from yafa.matches_copy where state='" + status + "'";
            if (league != "") {
                str += " and league"+lan+" like '%"+league+"%'";
            }
            if (home != "")
            {
                str += " and home" + lan + " like '%" + home + "%'";
            }
            if (away != "")
            {
                str += " and away" + lan + " like '%" + away + "%'";
            }
            if (time1 != "" && time2 != "")
            {
                if (DateTime.Compare(Convert.ToDateTime(time1), Convert.ToDateTime(time2)) > 0)
                {
                    time = time1; time1 = time2; time2 = time;
                }
                str += " and date(BeginTime)>='" + time1 + "' and date(BeginTime)<='" + time2 + "' group by league" + lan + ",Home" + lan + ",Away" + lan + ",ID order by BeginTime asc";
            }
            else
            {
                if (time1 !="" || time2 !="")
                {
                    time1 = time1 == "" ? time2 : time1;
                    time2 = time2 == "" ? time1 : time2;
                    str += " and date(BeginTime)>='" + time1 + "' and date(BeginTime)<='" + time2 + "' group by league" + lan + ",Home" + lan + ",Away" + lan + ",ID order by BeginTime asc";
                }
            }
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        public string GetMatchResults(string time1, string time2, string language, string status, string date, string user)
        {
            string time = "";
            if (time1 == time2)
            {
                time = time1;
            }
            string mysql = "";
            string group = "";
            if (language == "zh-cn" || language == "zh-CN")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
                group = " group by leaguetw,Hometw,Awaytw,ID";
            }
            if (language == "zh-tw")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
                group = " group by leaguetw,Hometw,Awaytw,ID";
            }
            if (language == "en-us")
            {
                mysql = "leagueen as league,Homeen as Home,Awayen as Away";
                group = " group by leagueen,Homeen,Awayen,ID";
            }
            if (language == "th-th")
            {
                mysql = "leagueth as league,Hometh as Home,Awayth as Away";
                group = " group by leagueth,Homecn,Awayth,ID";
            }
            if (language == "vi-vn")
            {
                mysql = "leaguevn as league,Homevn as Home,Awayvn as Away";
                group = " group by leaguevn,Homevn,Awayvn,ID";
            }
            string str = "select distinct " + mysql + ",BeginTime,Score,Scorehalf,date(BeginTime) from yafa.orderhistory where Status='" + status + "'and " + date + "='" + user + "'";
            if (time != "")
            {
                str += " and date(BeginTime)='" + time + "'" + group;
            }
            else
            {
                str += " and date(BeginTime)>='" + time1 + "' and date(BeginTime)<= '" + time2 + "'" + group;
            }

            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }



        public string GetStatisticsIpY(int day1, int day2, string date, string time, string group, string sorts, string user, string ip)
        {
            string mysql = "";
            if (user != "")
            {
                mysql = " and userName='" + user + "'";
            }
            if (ip != "")
            {
                mysql = " and ip='" + ip + "'";
            }
            string str = "select distinct ip, count(*) as countNumber,sum(Amount) as amount";

            str += ",(case when(select count(*) as win from orderhistory as a where Result>0 and a.IP=orderhistory.IP";
            str += " and (interval " + day1 + " " + date + " + '" + time + "')<=date(time) and (interval " + day2 + " " + date + " + '" + time + "')>=date(time) and status=1 group by IP)is null then 0 else ";
            str += "(select count(*) as win from orderhistory as a where Result>0 and a.IP=orderhistory.IP";
            str += " and (interval " + day1 + " " + date + " + '" + time + "')<=date(time) and (interval " + day2 + " " + date + " + '" + time + "')>=date(time) and status=1 group by IP)end) as win";

            str += ",(case when(select count(*) as lost from orderhistory as a where Result<0 and a.IP=orderhistory.IP";
            str += " and (interval " + day1 + " " + date + " + '" + time + "')<=date(time) and (interval " + day2 + " " + date + " + '" + time + "')>=date(time) and status=1 group by IP)is null then 0 else ";
            str += "(select count(*) as lost from orderhistory as a where Result<0 and a.IP=orderhistory.IP";
            str += " and (interval " + day1 + " " + date + " + '" + time + "')<=date(time) and (interval " + day2 + " " + date + " + '" + time + "')>=date(time) and status=1 group by IP)end) as lost";

            str += ",(case when(select sum(Amount) as win from orderhistory as a where Result>0 and a.IP=orderhistory.IP";
            str += " and (interval " + day1 + " " + date + " + '" + time + "')<=date(time) and (interval " + day2 + " " + date + " + '" + time + "')>=date(time) and status=1 group by IP)is null then 0 else ";
            str += "(select sum(Amount) as win from orderhistory as a where Result>0 and a.IP=orderhistory.IP";
            str += " and (interval " + day1 + " " + date + " + '" + time + "')<=date(time) and (interval " + day2 + " " + date + " + '" + time + "')>=date(time) and status=1 group by IP)end) as winAmount";

            str += ",(case when(select sum(Amount)as lost from orderhistory as a where Result<0 and a.IP=orderhistory.IP";
            str += " and (interval " + day1 + " " + date + " + '" + time + "')<=date(time) and (interval " + day2 + " " + date + " + '" + time + "')>=date(time) and status=1 group by IP)is null then 0 else ";
            str += "(select sum(Amount)as lost from orderhistory as a where Result<0 and a.IP=orderhistory.IP";
            str += " and (interval " + day1 + " " + date + " + '" + time + "')<=date(time) and (interval " + day2 + " " + date + " + '" + time + "')>=date(time) and status=1 group by IP)end) as lostAmount,";

            str += "((case when(select count(*) as win from orderhistory as a where Result>0 and a.IP=orderhistory.IP and (interval " + day1 + " " + date + " + '" + time + "')<=date(time) and (interval " + day2 + " " + date + " + '" + time + "')>=date(time) and status=1 group by IP)is null then 0 else ";
            str += "(select count(*) as win from orderhistory as a where Result>0 and a.IP=orderhistory.IP and (interval " + day1 + " " + date + " + '" + time + "')<=date(time) and (interval " + day2 + " " + date + " + '" + time + "')>=date(time) and status=1 group by IP) / count(*)  end)) as lostRate ";

            str += "from orderhistory where (interval " + day1 + " " + date + " + '" + time + "')<=date(time) and (interval " + day2 + " " + date + " + '" + time + "')>=date(time)" + mysql + " and status=1 group by IP";
            str += " order by " + group + " " + sorts + "";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        public string StatisticsIp(string Ip, string language)
        {
            string mysql = "";

            if (language == "cn")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
            }
            if (language == "tw")
            {
                mysql = "leaguetw as league,Hometw as Home,Awaytw as Away";
            }
            if (language == "en")
            {
                mysql = "leagueen as league,Homeen as Home,Awayen as Away";
            }
            if (language == "th")
            {
                mysql = "leagueth as league,Hometh as Home,Awayth as Away";
            }
            if (language == "vn")
            {
                mysql = "leaguevn as league,Homevn as Home,Awayvn as Away";
            }
            string str = "select " + mysql + ",UserName,Time,Odds,Amount,ValidAmount,Result from orderhistory where IP='" + Ip + "' and orderhistory.status=1";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        public string StatisticsIpT(string time1, string time2, string group, string sorts, string ip,string language)
        {
            string str = "select league" + language + " as league,Home" + language + " as Home,Away" + language + " as Away,UserName,time,Odds,Amount,ValidAmount,Result from orderhistory where IP='" + ip + "' and orderhistory.status=1";
            if (time2 != "")
            {
                str += " and ('" + time1 + "')<=date(time) and ('" + time2 + "')>=date(time)";
            }
            else {
                str += " and ('" + time1 + "')=date(time)";
            }
            str += " order by "+group+" "+sorts+"";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        public string StatisticsIpY(int day1, int day2, string date, string time, string group, string sorts, string ip,string language)
        {
            string str = "select league" + language + " as league,Home" + language + " as Home,Away" + language + " as Away,UserName,time,Odds,Amount,ValidAmount,Result from orderhistory where IP='" + ip + "' and orderhistory.status=1";
            str += " and (interval " + day1 + " " + date + " + '" + time + "')<=date(time) and (interval " + day2 + " " + date + " + '" + time + "')>=date(time)";
            str += " order by " + group + " " + sorts + "";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }
    }
}
