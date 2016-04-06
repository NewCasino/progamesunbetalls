using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Model;
using BLL;

namespace agent.ServicesFile.ReportService
{
    /// <summary>
    /// UnrecognizedService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class UnrecognizedService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(true)]
        public string getAllToLength(string length)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return OrderdetailliveManager.getAllToLength(length);
        }

        [WebMethod(true)]
        public string setUpData(string id, string type, string info, string typeInfo)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string[] idlist = id.Split(';');
            
            string[] typeInfolist = typeInfo.Split(';');
            for (int i = 0; i < idlist.Length; i++)
            {
                Orderdetaillive live = OrderdetailliveManager.GetOrderdetailliveByPK(int.Parse(idlist[i]));
                if (typeInfolist[i] == "走地全场让球")
                {
                    Orderdetailhdpl hdpl = new Orderdetailhdpl();
                    hdpl.Agent = live.Agent;
                    hdpl.AgentCommission = live.AgentCommission;
                    hdpl.AgentPercent = live.AgentPercent;
                    hdpl.Amount = live.Amount;
                    hdpl.Awaycn = live.Awaycn;
                    hdpl.Awayen = live.Awayen;
                    hdpl.Awayth = live.Awayth;
                    hdpl.Awaytw = live.Awaytw;
                    hdpl.Awayvn = live.Awayvn;
                    hdpl.BeginTime = live.BeginTime;
                    hdpl.BetItem = live.BetItem;
                    hdpl.BetType = live.BetType;
                    hdpl.Coefficient = live.Coefficient;
                    hdpl.CompanyCommission = live.CompanyCommission;
                    hdpl.CompanyPercent = live.CompanyPercent;
                    hdpl.Currency = live.Currency;
                    hdpl.Gameid = live.Gameid;
                    hdpl.Handicap = live.Handicap;
                    hdpl.Homecn = live.Homecn;
                    hdpl.Homeen = live.Homeen;
                    hdpl.Hometh = live.Hometh;
                    hdpl.Hometw = live.Hometw;
                    hdpl.Homevn = live.Homevn;
                    hdpl.IP = live.IP;
                    hdpl.IsHalf = live.IsHalf;
                    hdpl.Leaguecn = live.Leaguecn;
                    hdpl.Leagueen = live.Leagueen;
                    hdpl.Leagueth = live.Leagueth;
                    hdpl.Leaguetw = live.Leaguetw;
                    hdpl.Leaguevn = live.Leaguevn;
                    hdpl.Odds = live.Odds;
                    hdpl.OddsType = live.OddsType;
                    hdpl.OrderID = live.OrderID;
                    hdpl.Partner = live.Partner;
                    hdpl.PartnerCommission = live.PartnerCommission;
                    hdpl.PartnerPercent = live.PartnerPercent;
                    hdpl.Proportion = live.Proportion;
                    hdpl.Reason = info;
                    hdpl.Score = live.Score;
                    hdpl.Status = type;
                    hdpl.SubCompany = live.SubCompany;
                    hdpl.SubCompanyCommission = live.SubCompanyCommission;
                    hdpl.SubCompanyPercent = live.SubCompanyPercent;
                    hdpl.Time = live.Time;
                    hdpl.UserLevel = live.UserLevel;
                    hdpl.UserName = live.UserName;
                    hdpl.ValidAmount = live.ValidAmount;
                    hdpl.WebSiteiID = live.WebSiteiID;
                    hdpl.ZAgent = live.ZAgent;
                    hdpl.ZAgentCommission = live.ZAgentCommission;
                    hdpl.ZAgentPercent = live.ZAgentPercent;
                    hdpl.Betflag = live.Betflag;
                    OrderdetailhdplManager.AddOrderdetailhdpl(hdpl);
                }
                else if (typeInfolist[i] == "走地全场大小")
                {
                    Orderdetailoul loul = new Orderdetailoul();
                    loul.Agent = live.Agent;
                    loul.AgentCommission = live.AgentCommission;
                    loul.AgentPercent = live.AgentPercent;
                    loul.Amount = live.Amount;
                    loul.Awaycn = live.Awaycn;
                    loul.Awayen = live.Awayen;
                    loul.Awayth = live.Awayth;
                    loul.Awaytw = live.Awaytw;
                    loul.Awayvn = live.Awayvn;
                    loul.BeginTime = live.BeginTime;
                    loul.BetItem = live.BetItem;
                    loul.BetType = live.BetType;
                    loul.Coefficient = live.Coefficient;
                    loul.CompanyCommission = live.CompanyCommission;
                    loul.CompanyPercent = live.CompanyPercent;
                    loul.Currency = live.Currency;
                    loul.Gameid = live.Gameid;
                    loul.Handicap = live.Handicap;
                    loul.Homecn = live.Homecn;
                    loul.Homeen = live.Homeen;
                    loul.Hometh = live.Hometh;
                    loul.Hometw = live.Hometw;
                    loul.Homevn = live.Homevn;
                    loul.IP = live.IP;
                    loul.IsHalf = live.IsHalf;
                    loul.Leaguecn = live.Leaguecn;
                    loul.Leagueen = live.Leagueen;
                    loul.Leagueth = live.Leagueth;
                    loul.Leaguetw = live.Leaguetw;
                    loul.Leaguevn = live.Leaguevn;
                    loul.Odds = live.Odds;
                    loul.OddsType = live.OddsType;
                    loul.OrderID = live.OrderID;
                    loul.Partner = live.Partner;
                    loul.PartnerCommission = live.PartnerCommission;
                    loul.PartnerPercent = live.PartnerPercent;
                    loul.Proportion = live.Proportion;
                    loul.Reason = info;
                    loul.Score = live.Score;
                    loul.Status = type;
                    loul.SubCompany = live.SubCompany;
                    loul.SubCompanyCommission = live.SubCompanyCommission;
                    loul.SubCompanyPercent = live.SubCompanyPercent;
                    loul.Time = live.Time;
                    loul.UserLevel = live.UserLevel;
                    loul.UserName = live.UserName;
                    loul.ValidAmount = live.ValidAmount;
                    loul.WebSiteiID = live.WebSiteiID;
                    loul.ZAgent = live.ZAgent;
                    loul.ZAgentCommission = live.ZAgentCommission;
                    loul.ZAgentPercent = live.ZAgentPercent;
                    loul.Betflag = live.Betflag;
                    OrderdetailoulManager.AddOrderdetailoul(loul);
                }
                else if (typeInfolist[i] == "走地全场标准")
                {
                    Orderdetail1x2l lx2l = new Orderdetail1x2l();
                    lx2l.Agent = live.Agent;
                    lx2l.AgentCommission = live.AgentCommission;
                    lx2l.AgentPercent = live.AgentPercent;
                    lx2l.Amount = live.Amount;
                    lx2l.Awaycn = live.Awaycn;
                    lx2l.Awayen = live.Awayen;
                    lx2l.Awayth = live.Awayth;
                    lx2l.Awaytw = live.Awaytw;
                    lx2l.Awayvn = live.Awayvn;
                    lx2l.BeginTime = live.BeginTime;
                    lx2l.BetItem = live.BetItem;
                    lx2l.BetType = live.BetType;
                    lx2l.Coefficient = live.Coefficient;
                    lx2l.CompanyCommission = live.CompanyCommission;
                    lx2l.CompanyPercent = live.CompanyPercent;
                    lx2l.Currency = live.Currency;
                    lx2l.Gameid = live.Gameid;
                    lx2l.Handicap = live.Handicap;
                    lx2l.Homecn = live.Homecn;
                    lx2l.Homeen = live.Homeen;
                    lx2l.Hometh = live.Hometh;
                    lx2l.Hometw = live.Hometw;
                    lx2l.Homevn = live.Homevn;
                    lx2l.IP = live.IP;
                    lx2l.IsHalf = live.IsHalf;
                    lx2l.Leaguecn = live.Leaguecn;
                    lx2l.Leagueen = live.Leagueen;
                    lx2l.Leagueth = live.Leagueth;
                    lx2l.Leaguetw = live.Leaguetw;
                    lx2l.Leaguevn = live.Leaguevn;
                    lx2l.Odds = live.Odds;
                    lx2l.OddsType = live.OddsType;
                    lx2l.OrderID = live.OrderID;
                    lx2l.Partner = live.Partner;
                    lx2l.PartnerCommission = live.PartnerCommission;
                    lx2l.PartnerPercent = live.PartnerPercent;
                    lx2l.Proportion = live.Proportion;
                    lx2l.Reason = info;
                    lx2l.Score = live.Score;
                    lx2l.Status = type;
                    lx2l.SubCompany = live.SubCompany;
                    lx2l.SubCompanyCommission = live.SubCompanyCommission;
                    lx2l.SubCompanyPercent = live.SubCompanyPercent;
                    lx2l.Time = live.Time;
                    lx2l.UserLevel = live.UserLevel;
                    lx2l.UserName = live.UserName;
                    lx2l.ValidAmount = live.ValidAmount;
                    lx2l.WebSiteiID = live.WebSiteiID;
                    lx2l.ZAgent = live.ZAgent;
                    lx2l.ZAgentCommission = live.ZAgentCommission;
                    lx2l.ZAgentPercent = live.ZAgentPercent;
                    lx2l.Betflag = live.Betflag;
                    Orderdetail1x2lManager.AddOrderdetail1x2l(lx2l);
                }
                else if (typeInfolist[i] == "走地半场让球")
                {
                    Orderdetailhdphfl hdphfl = new Orderdetailhdphfl();
                    hdphfl.Agent = live.Agent;
                    hdphfl.AgentCommission = live.AgentCommission;
                    hdphfl.AgentPercent = live.AgentPercent;
                    hdphfl.Amount = live.Amount;
                    hdphfl.Awaycn = live.Awaycn;
                    hdphfl.Awayen = live.Awayen;
                    hdphfl.Awayth = live.Awayth;
                    hdphfl.Awaytw = live.Awaytw;
                    hdphfl.Awayvn = live.Awayvn;
                    hdphfl.BeginTime = live.BeginTime;
                    hdphfl.BetItem = live.BetItem;
                    hdphfl.BetType = live.BetType;
                    hdphfl.Coefficient = live.Coefficient;
                    hdphfl.CompanyCommission = live.CompanyCommission;
                    hdphfl.CompanyPercent = live.CompanyPercent;
                    hdphfl.Currency = live.Currency;
                    hdphfl.Gameid = live.Gameid;
                    hdphfl.Handicap = live.Handicap;
                    hdphfl.Homecn = live.Homecn;
                    hdphfl.Homeen = live.Homeen;
                    hdphfl.Hometh = live.Hometh;
                    hdphfl.Hometw = live.Hometw;
                    hdphfl.Homevn = live.Homevn;
                    hdphfl.IP = live.IP;
                    hdphfl.IsHalf = live.IsHalf;
                    hdphfl.Leaguecn = live.Leaguecn;
                    hdphfl.Leagueen = live.Leagueen;
                    hdphfl.Leagueth = live.Leagueth;
                    hdphfl.Leaguetw = live.Leaguetw;
                    hdphfl.Leaguevn = live.Leaguevn;
                    hdphfl.Odds = live.Odds;
                    hdphfl.OddsType = live.OddsType;
                    hdphfl.OrderID = live.OrderID;
                    hdphfl.Partner = live.Partner;
                    hdphfl.PartnerCommission = live.PartnerCommission;
                    hdphfl.PartnerPercent = live.PartnerPercent;
                    hdphfl.Proportion = live.Proportion;
                    hdphfl.Reason = info;
                    hdphfl.Score = live.Score;
                    hdphfl.Status = type;
                    hdphfl.SubCompany = live.SubCompany;
                    hdphfl.SubCompanyCommission = live.SubCompanyCommission;
                    hdphfl.SubCompanyPercent = live.SubCompanyPercent;
                    hdphfl.Time = live.Time;
                    hdphfl.UserLevel = live.UserLevel;
                    hdphfl.UserName = live.UserName;
                    hdphfl.ValidAmount = live.ValidAmount;
                    hdphfl.WebSiteiID = live.WebSiteiID;
                    hdphfl.ZAgent = live.ZAgent;
                    hdphfl.ZAgentCommission = live.ZAgentCommission;
                    hdphfl.ZAgentPercent = live.ZAgentPercent;
                    hdphfl.Betflag = live.Betflag;
                    OrderdetailhdphflManager.AddOrderdetailhdphfl(hdphfl);
                }
                else if (typeInfolist[i] == "走地半场大小")
                {
                    Orderdetailouhfl louhfl = new Orderdetailouhfl();
                    louhfl.Agent = live.Agent;
                    louhfl.AgentCommission = live.AgentCommission;
                    louhfl.AgentPercent = live.AgentPercent;
                    louhfl.Amount = live.Amount;
                    louhfl.Awaycn = live.Awaycn;
                    louhfl.Awayen = live.Awayen;
                    louhfl.Awayth = live.Awayth;
                    louhfl.Awaytw = live.Awaytw;
                    louhfl.Awayvn = live.Awayvn;
                    louhfl.BeginTime = live.BeginTime;
                    louhfl.BetItem = live.BetItem;
                    louhfl.BetType = live.BetType;
                    louhfl.Coefficient = live.Coefficient;
                    louhfl.CompanyCommission = live.CompanyCommission;
                    louhfl.CompanyPercent = live.CompanyPercent;
                    louhfl.Currency = live.Currency;
                    louhfl.Gameid = live.Gameid;
                    louhfl.Handicap = live.Handicap;
                    louhfl.Homecn = live.Homecn;
                    louhfl.Homeen = live.Homeen;
                    louhfl.Hometh = live.Hometh;
                    louhfl.Hometw = live.Hometw;
                    louhfl.Homevn = live.Homevn;
                    louhfl.IP = live.IP;
                    louhfl.IsHalf = live.IsHalf;
                    louhfl.Leaguecn = live.Leaguecn;
                    louhfl.Leagueen = live.Leagueen;
                    louhfl.Leagueth = live.Leagueth;
                    louhfl.Leaguetw = live.Leaguetw;
                    louhfl.Leaguevn = live.Leaguevn;
                    louhfl.Odds = live.Odds;
                    louhfl.OddsType = live.OddsType;
                    louhfl.OrderID = live.OrderID;
                    louhfl.Partner = live.Partner;
                    louhfl.PartnerCommission = live.PartnerCommission;
                    louhfl.PartnerPercent = live.PartnerPercent;
                    louhfl.Proportion = live.Proportion;
                    louhfl.Reason = info;
                    louhfl.Score = live.Score;
                    louhfl.Status = type;
                    louhfl.SubCompany = live.SubCompany;
                    louhfl.SubCompanyCommission = live.SubCompanyCommission;
                    louhfl.SubCompanyPercent = live.SubCompanyPercent;
                    louhfl.Time = live.Time;
                    louhfl.UserLevel = live.UserLevel;
                    louhfl.UserName = live.UserName;
                    louhfl.ValidAmount = live.ValidAmount;
                    louhfl.WebSiteiID = live.WebSiteiID;
                    louhfl.ZAgent = live.ZAgent;
                    louhfl.ZAgentCommission = live.ZAgentCommission;
                    louhfl.ZAgentPercent = live.ZAgentPercent;
                    louhfl.Betflag = live.Betflag;
                    OrderdetailouhflManager.AddOrderdetailouhfl(louhfl);
                }
                else if (typeInfolist[i] == "走地半场标准")
                {
                    Orderdetail1x2hfl lx2hfl = new Orderdetail1x2hfl();
                    lx2hfl.Agent = live.Agent;
                    lx2hfl.AgentCommission = live.AgentCommission;
                    lx2hfl.AgentPercent = live.AgentPercent;
                    lx2hfl.Amount = live.Amount;
                    lx2hfl.Awaycn = live.Awaycn;
                    lx2hfl.Awayen = live.Awayen;
                    lx2hfl.Awayth = live.Awayth;
                    lx2hfl.Awaytw = live.Awaytw;
                    lx2hfl.Awayvn = live.Awayvn;
                    lx2hfl.BeginTime = live.BeginTime;
                    lx2hfl.BetItem = live.BetItem;
                    lx2hfl.BetType = live.BetType;
                    lx2hfl.Coefficient = live.Coefficient;
                    lx2hfl.CompanyCommission = live.CompanyCommission;
                    lx2hfl.CompanyPercent = live.CompanyPercent;
                    lx2hfl.Currency = live.Currency;
                    lx2hfl.Gameid = live.Gameid;
                    lx2hfl.Handicap = live.Handicap;
                    lx2hfl.Homecn = live.Homecn;
                    lx2hfl.Homeen = live.Homeen;
                    lx2hfl.Hometh = live.Hometh;
                    lx2hfl.Hometw = live.Hometw;
                    lx2hfl.Homevn = live.Homevn;
                    lx2hfl.IP = live.IP;
                    lx2hfl.IsHalf = live.IsHalf;
                    lx2hfl.Leaguecn = live.Leaguecn;
                    lx2hfl.Leagueen = live.Leagueen;
                    lx2hfl.Leagueth = live.Leagueth;
                    lx2hfl.Leaguetw = live.Leaguetw;
                    lx2hfl.Leaguevn = live.Leaguevn;
                    lx2hfl.Odds = live.Odds;
                    lx2hfl.OddsType = live.OddsType;
                    lx2hfl.OrderID = live.OrderID;
                    lx2hfl.Partner = live.Partner;
                    lx2hfl.PartnerCommission = live.PartnerCommission;
                    lx2hfl.PartnerPercent = live.PartnerPercent;
                    lx2hfl.Proportion = live.Proportion;
                    lx2hfl.Reason = info;
                    lx2hfl.Score = live.Score;
                    lx2hfl.Status = type;
                    lx2hfl.SubCompany = live.SubCompany;
                    lx2hfl.SubCompanyCommission = live.SubCompanyCommission;
                    lx2hfl.SubCompanyPercent = live.SubCompanyPercent;
                    lx2hfl.Time = live.Time;
                    lx2hfl.UserLevel = live.UserLevel;
                    lx2hfl.UserName = live.UserName;
                    lx2hfl.ValidAmount = live.ValidAmount;
                    lx2hfl.WebSiteiID = live.WebSiteiID;
                    lx2hfl.ZAgent = live.ZAgent;
                    lx2hfl.ZAgentCommission = live.ZAgentCommission;
                    lx2hfl.ZAgentPercent = live.ZAgentPercent;
                    lx2hfl.Betflag = live.Betflag;
                    Orderdetail1x2hflManager.AddOrderdetail1x2hfl(lx2hfl);
                }
                if (type == "0")
                {
                    Orderdetail1x2hflManager.setBalance(live.UserName, live.Odds < 0 ? live.ValidAmount.ToString() : live.Amount.ToString());
                }
                OrderdetailliveManager.DeleteOrderdetailliveByPK(int.Parse(idlist[i]));
            }
            return "none";
        }
    }
}
