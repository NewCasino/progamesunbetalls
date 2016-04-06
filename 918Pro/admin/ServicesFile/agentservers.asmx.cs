using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Model;
using System.Text;
using BLL;

namespace admin.ServicesFile
{
    /// <summary>
    /// agentservers 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class agentservers : System.Web.Services.WebService
    {
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool AddServer(string ip, int port, int enable)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            Agentservers info = new Agentservers();
            info.Ip = ip;
            info.Port = port;
            info.Enable = enable;
            return BLL.AgentserversManager.AddAgentservers(info);
        }

        [WebMethod(true)]
        public bool UpdateServer(string ip, int port, int enable, int id)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            Agentservers info = new Agentservers();
            info.Ip = ip;
            info.Port = port;
            info.Enable = enable;
            info.Id = id;
            return BLL.AgentserversManager.UpdateAgentservers(info);

        }
        [WebMethod(true)]
        public bool DeleteServer(int id)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            return BLL.AgentserversManager.DeleteAgentserversByPK(id);
        }

        [WebMethod(true)]
        public string GetServer()
        {
            return DAL.ObjectToJson.ObjectListToJson<Agentservers>(BLL.AgentserversManager.GetMutilILAgentservers());
        }

        [WebMethod(true)]
        public string GetJoinerByWhere(string username, string name, string subtime1, string subtime2, string status)
        {
            return DAL.AgentService.GetJoinerByWhere(username, name, subtime1, subtime2, status);
        }

        [WebMethod(true)]
        public bool UpdateJoiner(string zagent, double percent, string username, string password, string question, string answer, string email,
            string tel, string qq, string country, string province, string city, string cardno, string bankname, string bank,
            string ghbndk, string branch, string name, string url, string status, int ID)
        {
            bool rebit = DAL.AgentService.UpdateJoiner(username, password, question, answer, email, tel, qq, country, province, city, cardno,
                bankname, bank, ghbndk, branch, name, url, status, ID);
            if ( rebit)
            {
                //开通代理
                AgentManager agentManager = new AgentManager();
                if (agentManager.IsExistUser(username) == "帐号已存在")
                {
                    //代理已存在
                    return rebit;
                }
                Agent info = agentManager.GetAgentByUserName(zagent);

                Agent agent = new Agent();
                agent.Currency = "RMB";
                agent.UserName = username;
                agent.Password = password;
                agent.Name = name;
                agent.Mobile = tel;
                agent.Email = email;
                agent.Tel = tel;
                agent.Status = 1;
                agent.SubCompany = info.SubCompany;
                agent.SCnumber = info.SCnumber;
                agent.Partner = info.Partner;
                agent.Pnumber = info.Pnumber;
                agent.GeneralAgent = zagent;
                agent.Ganumber = 0;
                agent.Agents = "";
                agent.Agentsnumber = 0;
                agent.MaxUser = 1000;
                agent.RoleId = 5;
                agent.UpUserName = zagent;
                agent.UpUserID = info.ID;
                agent.UpRoleId = 4;
                agent.UpRoleName = "总代";
                agent.ItemMax = info.ItemMax;
                agent.ItemMin = info.ItemMin;
                agent.ItemsMax = info.ItemsMax;
                agent.Percent = percent;
                agent.Credit = info.Credit;
                agent.CommissionA = 0;
                agent.CommissionB = 0;
                agent.CommissionC = 0;
                agent.RegistrationTime = DateTime.Now;
                agent.SubAccount = "0";
                agent.LastLoginTime = DateTime.Now;
                agent.UserLevel = "5";
                agent.RoleName = "代理";
                agent.ResetCredit = info.ResetCredit;
                agent.Balance = 0;
                agent.MoneyType = "1";
                agent.ParentCode = "";

                AgentManager.AddAgentUser(agent);
            }
            return rebit;
        }

        [WebMethod(true)]
        public string GetAgentWithdrawal0(string username, string name, string time1, string time2,string type, string status)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "-1";
            }
            return DAL.BankService.GetAgentWithdrawal0(username, name, time1, time2, type, status);
        }

        /// <summary>
        /// 代理提款审核
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string UpdateWithdrawal(int ID, decimal amount, string status, string mark)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "-1";
            }
            if (status == "3")
            {
                //拒绝提款
                //Agent ag = BLL.AgentManager.GetAgentByPK(ID);
                if (!DAL.AgentService.UpdateAmount(amount, ID))
                {
                    return "0";
                }
            }
            return DAL.BankService.AgentWithdrawalCheck(ID, status, mark) ? "1" : "0";
        }

        /// <summary>
        /// 返回总代列表
        /// </summary>
        /// <returns></returns>
        [WebMethod(true)]
        public string GetZagent()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "-1";
            }
            StringBuilder json = new StringBuilder();
            string partner = "";
            string zagent = "";
            BLL.ConfigManager cm = new BLL.ConfigManager();
            Model.Config config = cm.GetConfigByOtype("默认股东");
            partner = config.Oval;
            config = cm.GetConfigByOtype("默认总代");
            zagent = config.Oval;
            IList<Agent> lists = DAL.AgentService.GetAgentByPartner(partner);
            json.Append("{\"a\":[");
            foreach (Agent ag in lists)
            {
                json.Append("{\"zagent\":\"");
                json.Append(ag.UserName);
                json.Append("\"},");
            }
            json.Remove(json.Length - 1, 1);
            json.Append("],\"b\":[{\"z1\":\"" + zagent + "\"}]}");

            return json.ToString();
        }
    }
}
