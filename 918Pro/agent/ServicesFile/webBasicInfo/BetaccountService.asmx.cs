using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Model;
using BLL;

namespace agent.ServicesFile.webBasicInfo
{
    /// <summary>
    /// BetaccountService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class BetaccountService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(EnableSession = true)]
        public string InsertInfo(string casino, string userid, string password, string agent, string websitepossess, string selfpossess, string commission,
            string multiple, string zemo, string group, string address, string address2, string cookie, string isquzhi, string enable, string ip)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            DateTime time = DateTime.Now;
            string i = BetaccountManager.getCount(userid);
            if (i != "0")
            {
                return "-1";
            }
            Betaccount bet = new Betaccount();
            bet.Casino = int.Parse(casino);
            bet.Userid = userid;
            bet.Password = password;
            bet.Agent = agent;
            bet.WebsitePossess = decimal.Parse(websitepossess);
            bet.SelfPossess = decimal.Parse(selfpossess);
            bet.Commission = decimal.Parse(commission);
            bet.Multiple = decimal.Parse(multiple);
            bet.Zemo = zemo;
            bet.Group1 = int.Parse(group);
            bet.Address = address;
            bet.Address2 = address2;
            bet.Cookie = cookie;
            bet.Isquzhi = byte.Parse(isquzhi);
            bet.Enable = byte.Parse(enable);
            bet.Time = time;
            bet.Operator = "admin";
            bet.Operatorip = ip;
            bet.Operatortime = time;
            return BetaccountManager.AddBetaccount(bet).ToString();
        }

        [WebMethod(EnableSession = true)]
        public string UpdateInfo(string id,string casino, string userid, string password, string agent, string websitepossess, string selfpossess, string commission,
            string multiple, string zemo, string group, string address, string address2, string cookie, string isquzhi, string enable, string ip)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            DateTime time = DateTime.Now;
            /** 修改之前的信息插入修改日志表 **/
            Betaccount bet1 = BetaccountManager.GetBetaccountByID(int.Parse(id))[0];
            Betaccountlog betlog = new Betaccountlog();
            betlog.Casino = bet1.Casino;
            betlog.Userid = bet1.Userid;
            betlog.Password = bet1.Password;
            betlog.Agent = bet1.Agent;
            betlog.WebsitePossess = bet1.WebsitePossess;
            betlog.SelfPossess = bet1.SelfPossess;
            betlog.Commission = bet1.Commission;
            betlog.Multiple = bet1.Multiple;
            betlog.Zemo = bet1.Zemo;
            betlog.Group1 = bet1.Group1;
            betlog.Address = bet1.Address;
            betlog.Address2 = bet1.Address2;
            betlog.Cookie = bet1.Cookie;
            betlog.Isquzhi = bet1.Isquzhi;
            betlog.Enable = bet1.Enable;
            betlog.Time = bet1.Time;
            betlog.Operator = bet1.Operator;
            betlog.Operatorip = bet1.Operatorip;
            betlog.Operatortime = bet1.Operatortime;
            BetaccountlogManager.AddBetaccountlog(betlog);
            /** 插入完毕 **/

            /** 修改信息 **/
            Betaccount bet = new Betaccount();
            bet.Id = int.Parse(id);
            bet.Casino = int.Parse(casino);
            bet.Userid = userid;
            bet.Password = password;
            bet.Agent = agent;
            bet.WebsitePossess = decimal.Parse(websitepossess);
            bet.SelfPossess = decimal.Parse(selfpossess);
            bet.Commission = decimal.Parse(commission);
            bet.Multiple = decimal.Parse(multiple);
            bet.Zemo = zemo;
            bet.Group1 = int.Parse(group);
            bet.Address = address;
            bet.Address2 = address2;
            bet.Cookie = cookie;
            bet.Isquzhi = byte.Parse(isquzhi);
            bet.Enable = byte.Parse(enable);
            bet.Time = time;
            bet.Operator = "admin";
            bet.Operatorip = ip;
            bet.Operatortime = time;
            return BetaccountManager.UpdateBetaccount(bet).ToString();
        }

        [WebMethod(EnableSession = true)]
        public string DeleteInfo(string id)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            Betaccount bet = BetaccountManager.GetBetaccountByID(int.Parse(id))[0];

            //DateTime time = DateTime.Now;
            Betaccountcopy bet1 = new Betaccountcopy();
            bet1.Casino = bet.Casino;
            bet1.Userid = bet.Userid;
            bet1.Password = bet.Password;
            bet1.Agent = bet.Agent;
            bet1.WebsitePossess = bet.WebsitePossess;
            bet1.SelfPossess = bet.SelfPossess;
            bet1.Commission = bet.Commission;
            bet1.Multiple = bet.Multiple;
            bet1.Zemo = bet.Zemo;
            bet1.Group1 = bet.Group1;
            bet1.Address = bet.Address;
            bet1.Address2 = bet.Address2;
            bet1.Cookie = bet.Cookie;
            bet1.Isquzhi = bet.Isquzhi;
            bet1.Enable = bet.Enable;
            bet1.Time = bet.Time;
            bet1.Operator = bet.Operator;
            bet1.Operatorip = bet.Operatorip;
            bet1.Operatortime = bet.Operatortime;
            BetaccountcopyManager.AddBetaccountcopy(bet1);
            return BetaccountManager.DeleteBetaccountByPK(id).ToString();
        }

        [WebMethod(EnableSession = true)]
        public string GetDateAll(int IDex, int IDexC, string casino, string dali, string id, string enable, string webPoss, string Company)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return BetaccountManager.getDataAll(IDex, IDexC, casino, dali, id, enable, webPoss, Company);
        }

        [WebMethod(EnableSession = true)]
        public string getAllCount(string casino, string dali, string id, string enable, string webPoss, string Company)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return BetaccountManager.getAllCount(casino, dali, id, enable, webPoss, Company);
        }
    }
}
