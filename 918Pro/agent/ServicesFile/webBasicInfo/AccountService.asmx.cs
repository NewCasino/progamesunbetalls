using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using Model;

namespace agent.ServicesFile.webBasicInfo
{
    /// <summary>
    /// AccountService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class AccountService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(EnableSession=true)]
        public string GetDate(int IDex, int IDexC,string casino,string group,string time1,string time2,string enable)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return AccountManager.getDataAll(IDex, IDexC, casino, group, time1, time2, enable);
        }

        [WebMethod(EnableSession = true)]
        public string InsertInfo(string userid,string password,string casino,string group,string address,string address2,string cookie,string isquzhi,string enable,string ip)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            DateTime time = DateTime.Now;
            string i = AccountManager.getInfo(userid);
            if (i != "0")
            {
                return "-1";
            }
            Account account = new Account();
            account.Userid = userid;
            account.Password = password;
            account.Casino = int.Parse(casino);
            account.Group1 = int.Parse(group);
            account.Address = address;
            account.Time = time;
            account.Address2 = address2;
            account.Cookie = cookie;
            account.Isquzhi = byte.Parse(isquzhi);
            account.Enable = int.Parse(enable);
            account.Operat = "admin";
            account.Operatortime = time.ToString();
            account.Operatorip = ip;
            return AccountManager.AddAccount(account).ToString();
        }

        [WebMethod(EnableSession = true)]
        public string UpdateInfo(string id,string userid, string password, string casino, string group, string address, string address2, string cookie, string isquzhi, string enable, string ip)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            DateTime time = DateTime.Now;
            Account account = new Account();
            account.Id = int.Parse(id);
            account.Userid = userid;
            account.Password = password;
            account.Casino = int.Parse(casino);
            account.Group1 = int.Parse(group);
            account.Address = address;
            account.Address2 = address2;
            account.Cookie = cookie;
            account.Time = time;
            account.Isquzhi = byte.Parse(isquzhi);
            account.Enable = int.Parse(enable);
            account.Operat = "admin";
            account.Operatortime = time.ToString();
            account.Operatorip = ip;
            return AccountManager.UpdateAccount(account).ToString();
        }

        [WebMethod(EnableSession = true)]
        public string deleteInfo(string id)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return AccountManager.DeleteAccountByPK(int.Parse(id)).ToString();
        }

        [WebMethod(EnableSession = true)]
        public string GetDateToID(string id)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return AccountManager.getDataToID(id);
        }
    }
}
