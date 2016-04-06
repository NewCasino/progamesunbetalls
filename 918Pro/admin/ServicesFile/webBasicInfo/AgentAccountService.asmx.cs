using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using Model;

namespace admin.ServicesFile.webBasicInfo
{
    /// <summary>
    /// AgentAccountService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class AgentAccountService : System.Web.Services.WebService
    {

        [WebMethod(true)]
        public string Insert(string name,string agentName,string pwd,string casino,string cookie,string addr,string addr2,string isEnable,string ip)
        { 
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "no";
            }
            admin.PageBase page = new admin.PageBase();
            string i = AccountManager.getInfo(name);
            if (i != "0")
            {
                return "-1";  //已存在该帐号名称
            }
            AgentAccount agentAcc = new AgentAccount();
            agentAcc.Name = name;
            agentAcc.AgentName = agentName;
            agentAcc.Password = pwd;
            agentAcc.Casino = casino;
            agentAcc.Cookie = cookie;
            agentAcc.Address = addr;
            agentAcc.Address2 = addr2;
            agentAcc.IsEnable = isEnable;
            agentAcc.Operator = page.CurrentManager.ManagerId;
            agentAcc.OperationTime = DateTime.Now;
            agentAcc.IP = ip;
            return BLL.AgentAccountManager.Insert(agentAcc) ? "yes" : "no";
        }

        [WebMethod(true)]
        public bool Update(string id,string name,string agentName, string pwd, string casino, string cookie, string addr, string addr2, string isEnable, string ip)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            } 
            admin.PageBase page = new admin.PageBase();
            AgentAccount agentAcc = new AgentAccount();
            agentAcc.ID = int.Parse(id);
            agentAcc.Name = name;
            agentAcc.AgentName = agentName;
            agentAcc.Password = pwd;
            agentAcc.Casino = casino;
            agentAcc.Cookie = cookie;
            agentAcc.Address = addr;
            agentAcc.Address2 = addr2;
            agentAcc.IsEnable = isEnable;
            agentAcc.Operator = page.CurrentManager.ManagerId;
            agentAcc.OperationTime = DateTime.Now;
            agentAcc.IP = ip;
            return BLL.AgentAccountManager.Update(agentAcc);        
        }

        [WebMethod(true)]
        public string SelectAll()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.AgentAccountManager.SelectAll();
        }

        [WebMethod(true)]
        public string SelectByWhere(string name,string casino,string isEnable)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.AgentAccountManager.SelectByWhere(name,casino,isEnable);
        }

        [WebMethod(true)]
        public bool Delete(string id)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }
            return BLL.AgentAccountManager.Delete(id);
        }

        [WebMethod(true)]
        public string getCount(string casino, string time1, string time2, string enable)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.AgentAccountManager.getCount(casino, time1, time2, enable);
        }

        [WebMethod(true)]
        public string GetDate(int IDex, int IDexC, string casino,string time1, string time2, string enable)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.AgentAccountManager.getDataAll(IDex, IDexC, casino, time1, time2, enable);
        }
    }
}
