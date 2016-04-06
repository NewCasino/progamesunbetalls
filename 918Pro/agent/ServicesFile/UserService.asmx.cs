using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using Model;
using Newtonsoft.Json;
using DAL;
using Util;


namespace agents.ServicesFile
{
    /// <summary>
    /// UserService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class UserService : System.Web.Services.WebService
    {

        /// <summary>
        /// 代理子帐号启用禁用
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool UpdateAgentStatus(string userName, int status)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            AgentManager agentManager = new AgentManager();
            int newStatus = (status == 1 ? 0 : 1);
            return agentManager.UpdateAgentStatus(userName, newStatus);
        }

        /// <summary>
        /// 修改代理子帐号
        /// </summary>
        /// <param name="RoleName"></param>
        /// <param name="RoleId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool UpdateAgentSubAccount(string RoleName, int RoleId, string userName)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            AgentManager agentManager = new AgentManager();
            return agentManager.UpdateAgentSubAccount(RoleName, RoleId, userName);
        }

        /// <summary>
        /// 删除代理子帐号
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool DeleteAgentSubAccount(int ID)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            return AgentManager.DeleteAgentByPK(ID);
        }

        /// <summary>
        /// 修改代理子帐号密码
        /// </summary>
        /// <param name="pass"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool UpdateAgentSubAccountPassword(string pass, string userName)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            return AgentManager.UpdatePass(pass, userName);
        }

        /// <summary>
        /// 返回代理子帐号
        /// By xzz 2010-11-26
        /// </summary>
        /// <param name="agentUserName"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetSubAccount(string roleID)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            AgentManager agentManager = new AgentManager();
            agent.PageBase pageBase = new agent.PageBase();

            if (!string.IsNullOrEmpty(roleID))
            {
                return ObjectToJson.ObjectListToJson<Agent>(agentManager.GetSubAccountByRoleID(Convert.ToInt32(roleID)));
            }
            else
            {
                return agentManager.GetSubAccount(pageBase.agentUserName);
            }
            
        }

        /// <summary>
        /// 增加代理子帐号
        /// By xzz 2010-11-26
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="RoleName"></param>
        /// <param name="RoleId"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        [WebMethod(EnableSession=true)]
        public string AddAgentSubAccount(string UserName, string Password, string RoleName, int RoleId, int Status)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            AgentManager agentManager = new AgentManager();
            agent.PageBase pageBase = new agent.PageBase();

            if (agentManager.IsExistSubAccount(UserName, pageBase.agentUserName))
            {
                //代理子帐号已存在
                return "ExistSubAccount";
            }

            Agent info = new Agent();
            info.UserName = UserName;
            info.Password = Password;
            info.Status = Status;
            info.RoleId = RoleId;
            info.RoleName = RoleName;
            info.SubAccount = "1";
            info.AgentID = pageBase.agentUserID;
            info.AgentUserName = pageBase.agentUserName;
            info.AgentRoleName = pageBase.agentRoleName;
            info.AgentRoleID = pageBase.agentRoleID;
            info.RegistrationTime = DateTime.Now;
            info.UpUserName = pageBase.CurrentManager.UpUserName;
            info.UpUserID = pageBase.CurrentManager.UpUserID;
            info.UpRoleId = pageBase.CurrentManager.UpRoleId;
            info.UpRoleName = pageBase.CurrentManager.UpRoleName;
            info = agentManager.AddAgentSubAccount(info);

            return ObjectToJson.ObjectsToJson<Agent>(info);
        }

        /// <summary>
        /// 重置会员信用
        /// </summary>
        /// <returns></returns>
        [WebMethod(true)]
        public bool RecoverUserCredit()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            UserManager userManager = new UserManager();
            return userManager.RecoverUserCredit();
        }


        /// <summary>
        /// 更新重置信用设置
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="resetCredit"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool UpdateResetCredit(string userName, string resetCredit, int roleID)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            AgentManager agentManager = new AgentManager();
            bool reVal = agentManager.UpdateResetCredit(userName, resetCredit, roleID);
            return reVal;
        } 

        /// <summary>
        /// 系统管理员帐号是否存在
        /// By xzz
        /// </summary>
        /// <param name="managerId"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool IsExistManager(string managerId)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            ManagerService managerService = new ManagerService();
            Manager info = managerService.GetManagerByManagerId(managerId);
            if (info == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        [WebMethod(true)]
        public bool IsExistRole(string roleName, string agentId)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            RoleManager roleManager = new RoleManager();
            return roleManager.IsExistRole(roleName, agentId);
        }

        /// <summary>
        /// 会员或者代理帐号是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string IsExistUser(string userName, int roleID)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            if (roleID == 6)
            {
                //会员
                UserManager userManager = new UserManager();
                return userManager.IsExistUser(userName);
            }
            else
            {
                //代理
                AgentManager agentManager = new AgentManager();
                return agentManager.IsExistUser(userName);
            }
        }

        /// <summary>
        /// 根据角色ID返回管理员(Json)
        /// By xzz
        /// time:2010-9-1 00:08
        /// </summary>
        /// <returns></returns>
        [WebMethod(true)]
        public string GetManagers(string roleId)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            ManagerManager managerBll = new ManagerManager();
            if (string.IsNullOrEmpty(roleId))
            {
                return managerBll.GetManager();
            }
            else
            {
                string aa = managerBll.GetManagetsByRoleId(Convert.ToInt32(roleId));
                return aa;
            }
            
        }


        /// <summary>
        /// 获取子集最大佣金A、B、C
        /// 编写时间: 2010-10-4 17:00
        /// 创建者：Mickey
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetRoleCommission(int roleId, int upUserID)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return BLL.AgentManager.GetRoleCommission(roleId, upUserID);
        }

        /// <summary>
        /// 修改会员佣金
        /// 编写时间：2010-10-4 14:30
        /// 创建者：Mickey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commission"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string updateUserCommission(string id, string commission)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return UserManager.updateUserCommission(id,commission).ToString();
        }

        /// <summary>
        /// 增加管理员帐号
        /// By xzz
        /// time:2010-9-1
        /// </summary>
        /// <param name="ManagerId"></param>
        /// <param name="PassWord"></param>
        /// <param name="RoleId"></param>
        /// <param name="Enable"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string AddManager(string ManagerId, string PassWord, int RoleId, int Enable)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            agent.PageBase pageBase = new agent.PageBase();
            //帐号是否存在
            ManagerService managerService = new ManagerService();
            Manager info1 = managerService.GetManagerByManagerId(ManagerId);
            if (info1 != null)
            {
                return "帐号已存在";
            }

            //Manager info = (Manager)Session[Util.ProjectConfig.ADMINUSER];
            Manager managerModel = new Manager();
            managerModel.ManagerId = ManagerId;
            managerModel.PassWord = PassWord;
            managerModel.RoleId = RoleId;
            managerModel.CreateDate = DateTime.Now;
            managerModel.UpdateDate = DateTime.Now;
            managerModel.CreateUser = pageBase.CurrentManager.UserName;
            managerModel.IP = Util.RequestHelper.GetIP();
            managerModel.Enable = Enable;

            string jsonStr = "";
            bool reval = ManagerManager.AddManager(managerModel);
            if (reval)
            {
                Manager info = ManagerManager.GetManagerByManagerId(ManagerId, PassWord);
                jsonStr = ManagerManager.ManagerToJson(info);
            }
            else
            {
                jsonStr = "none";
            }

            return jsonStr;
        }

        /// <summary>
        /// 更新管理员角色
        /// By xzz
        /// time:2010-9-1
        /// </summary>
        /// <param name="RoleId">角色Id</param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool UpdateManager(int RoleId, int ID)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            ManagerManager managerBll = new ManagerManager();
            return managerBll.UpdateManager(RoleId,ID);
        }

        /// <summary>
        /// 更新管理员状态
        /// By xzz
        /// time:2010-9-1
        /// </summary>
        /// <param name="Enable"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool UpdateManagerStatus(int Enable, int ID)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            ManagerManager managerBll = new ManagerManager();
            return managerBll.UpdateManagerStatus(Enable, ID);
        }

        /// <summary>
        /// 修改管理员密码
        /// By xzz
        /// time:2010-9-1
        /// </summary>
        /// <param name="passWord"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool MdfPassword(string passWord, int id)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            ManagerManager managerBll = new ManagerManager();
            return managerBll.MdfPassword(passWord, id);
        }

        /// <summary>
        /// 删除管理员
        /// By xzz
        /// time:2010-9-1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool DeleteManager(int id)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            return ManagerManager.DeleteManagerByPK(id);
        }

       /// <summary>
       /// 修改密码
        /// create by 肖军文
        /// create date 2010-09-28
       /// </summary>
       /// <param name="pass">密码</param>
       /// <param name="userName">账户名称</param>
       /// <returns></returns>
        [WebMethod(true)]
        public bool UpdatePass(string pass,string userName,int roleId)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            if ((pass == string.Empty && pass == "") || (userName == string.Empty && userName == "") || (roleId<0))
            {
                return false;
            }
            else
            {
                if (roleId == 6)
                {
                    return UserManager.UpdatePass(pass, userName);
                }
                else
                {
                    return AgentManager.UpdatePass(pass, userName);
                }
            }
        }
         
         
        /// <summary>
        /// 根据参数查询代理信息
        /// create by 肖军文
        /// create date 2010-09-28
        /// </summary>
        /// <param name="upUserName">上级归属</param>
        /// <param name="userName">账号名称</param>
        /// <param name="status">状态</param>
        /// <param name="limitStart">索引开始</param>
        /// <param name="limitEnd">索引结束</param>
        /// <returns></returns>
        [WebMethod(true)]
        public string GetAgents(string moneyType, string upUserName, string userName, string status, int limitStart, int limitEnd,int roleId)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            userName = userName.Replace("'", "");
            status = status.Replace("'", "");
                //会员
                if (roleId == 6)
                {
                    return ObjectToJson.ObjectListToJson<User>(UserManager.GetUser(upUserName, userName, status, limitStart, limitEnd));
                   
                }
                else
                {
                    //代理
                    return ObjectToJson.ObjectListToJson <Agent>(AgentManager.GetAgents(moneyType, upUserName, userName, status, limitStart, limitEnd));
                     
                    
                } 
           
        }


        /// <summary>
        /// 代理
        /// create by 肖军文
        /// create date 2010-09-28
        /// </summary>
        /// <param name="userName">代理代号</param>
        /// <param name="pass">密码</param>
        /// <param name="name">姓名</param>
        /// <param name="mobile">手机号码</param>
        /// <param name="email">电子邮箱</param>
        /// <param name="tel">固话</param>
        /// <param name="status">状态</param>
        /// <param name="subCompany">分公司</param>
        /// <param name="sCNumber">分公司人数</param>
        /// <param name="partner">股东</param>
        /// <param name="pNumber">股东人数</param>
        /// <param name="generaAgent">总代理</param>
        /// <param name="gaNumber">总代理人数</param>
        /// <param name="agents">代理</param>
        /// <param name="agentsNumber">代理人数</param>
        /// <param name="maxUser">会员人数上限</param>
        /// <param name="roleId">角色ID</param>
        /// <param name="roleName">角色名称</param>
        /// <param name="upUserName">上级归属</param>
        /// <param name="upUserId">上级归属ID</param>
        /// <param name="upRoleId">上级归属角色ID</param>
        /// <param name="upRoleName">上级归属角色名称</param>
        /// <param name="itemMin">单注最低</param>
        /// <param name="itemMax">单注最高</param>
        /// <param name="itemsmax">单场最高</param>
        /// <param name="percent">占成</param>
        /// <param name="credit">信用</param>
        /// <param name="commissionA">佣金A</param>
        /// <param name="commissionB">佣金B</param>
        /// <param name="commissionC">佣金C</param> 
        /// <returns></returns>
        [WebMethod(true)]
        public string AddAgent(string currency, string moneyType, string userName, string pass, string name, string mobile, string email
            , string tel, int status, string subCompany, int sCNumber, string partner, int pNumber,
            string generaAgent, string gaNumber, string agents, int agentsNumber, int maxUser, int roleId,
            string roleName, string upUserName, int upUserId, int upRoleId, string upRoleName, decimal itemMin,
            decimal itemMax, decimal itemsmax, double percent, decimal credit,
            decimal commissionA, decimal commissionB, decimal commissionC, string resetCredit)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            Agent agent = new Agent();
            agent.Currency = currency;
            agent.UserName = userName;
            agent.Password = pass;
            agent.Name = name;
            agent.Mobile = mobile;
            agent.Email = email;
            agent.Tel = tel;
            agent.Status = status;
            agent.SubCompany = subCompany;
            agent.SCnumber = sCNumber;
            agent.Partner = partner;
            agent.Pnumber = pNumber;
            agent.GeneralAgent = generaAgent;
            agent.Ganumber = Convert.ToInt32(gaNumber);
            agent.Agents = agents;
            agent.Agentsnumber = agentsNumber;
            agent.MaxUser = maxUser;
            agent.RoleId = roleId;
            agent.UpUserName = upUserName;
            agent.UpUserID = upUserId;
            agent.UpRoleId = upRoleId;
            agent.UpRoleName = upRoleName;
            agent.ItemMax = itemMax;
            agent.ItemMin = itemMin;
            agent.ItemsMax = itemsmax;
            agent.Percent = percent;
            agent.Credit = credit;
            agent.CommissionA = commissionA;
            agent.CommissionB = commissionB;
            agent.CommissionC = commissionC;
            agent.RegistrationTime = DateTime.Now;
            agent.SubAccount = "0";
            agent.LastLoginTime = DateTime.Now;
            agent.UserLevel = "5";
            agent.RoleName = roleName;
            agent.ResetCredit = resetCredit;
            agent.Balance = credit;
            agent.MoneyType = moneyType;

            AgentManager agentManager = new AgentManager();
            Agent info = agentManager.GetAgentByUserName(agent.UpUserName);
            if (info != null)
            {
                if (agent.Credit + info.UserCredit > info.Credit)
                {
                    return "[{\"mark\":\"信用不能大于\",\"xy\":\"" + (info.Credit - info.UserCredit).ToString("0") + "\"}]";
                }
            }

            int Id = AgentManager.AddAgentUser(agent);
            agent.ID = Id;
            //return JsonConvert.SerializeObject(agent);
            return ObjectToJson.ObjectsToJson<Agent>(agent);
        }


        /// <summary>
        /// 会员
        /// create by 肖军文
        /// create date 2010-09-28
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pass"></param>
        /// <param name="name"></param>
        /// <param name="mobile"></param>
        /// <param name="currency"></param>
        /// <param name="email"></param>
        /// <param name="tel"></param>
        /// <param name="status"></param>
        /// <param name="companyPercent"></param>
        /// <param name="companyCommission"></param>
        /// <param name="subCompany"></param>
        /// <param name="subCompanyPercent"></param>
        /// <param name="subCompanyCommission"></param>
        /// <param name="partner"></param>
        /// <param name="partnerPercent"></param>
        /// <param name="partnerCommission"></param>
        /// <param name="generalAgent"></param>
        /// <param name="generalAgentPercent"></param>
        /// <param name="generalAgentCommission"></param>
        /// <param name="agent"></param>
        /// <param name="agentPercent"></param>
        /// <param name="agentCommission"></param>
        /// <param name="percent"></param>
        /// <param name="commission"></param>
        /// <param name="credit"></param>
        /// <param name="upUserName"></param>
        /// <param name="upUserID"></param>
        /// <param name="upRoleId"></param>
        /// <param name="registrationTime"></param>
        /// <param name="ItemMin"></param>
        /// <param name="itemMax"></param>
        /// <param name="itemsMax"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string AddUser(string userName, string pass, string name, string mobile, string currency, string email
            , string tel, int status, Decimal companyPercent, decimal companyCommission, string subCompany, Decimal subCompanyPercent,
            decimal subCompanyCommission, string partner, Decimal partnerPercent, decimal partnerCommission,
            string generalAgent, Decimal generalAgentPercent, decimal generalAgentCommission, string agent
            , Decimal agentPercent, decimal agentCommission, Decimal percent, decimal commission, decimal credit,
             string upUserName, int upUserID, int upRoleId,
            decimal ItemMin, decimal itemMax, decimal itemsMax, string Group, string resetCredit)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            User user = new User();
            user.SubCompanyCommission = subCompanyCommission;
            user.Partner = partner;
            user.PartnerPercent = partnerPercent;
            user.PartnerCommission = partnerCommission;
            user.AgentPercent = agentPercent;
            user.AgentCommission = agentCommission;
            user.Percent = percent;
            user.Commission = commission;
            user.Credit = credit;
            user.Group = Group;

            user.UserName = userName;
            user.Password = pass;
            user.Name = name;
            user.Mobile = mobile;
            user.Currency = currency;
            user.Email = email;
            user.Tel = tel;
            user.Status = status;
            user.CompanyPercent = companyPercent;
            user.CompanyCommission = companyCommission;
            user.SubCompany = subCompany;
            user.SubCompanyPercent = subCompanyPercent;
            user.GeneralAgent = generalAgent;
            user.GeneralAgentPercent = generalAgentPercent;
            user.GeneralAgentCommission = generalAgentCommission;
            user.Agent = agent;
            user.UpUserName = upUserName;
            user.UpUserID = upUserID;
            user.UpRoleId = upRoleId;
            user.RegistrationTime = DateTime.Now;
            user.ItemMin = ItemMin;
            user.ItemMax = itemMax;
            user.ItemsMax = itemsMax;
            user.Group = Group;
            user.LastLoginTime = DateTime.Now;
            user.UserLevel = "5";
            user.Coefficient = 0;
            user.Proportion = 0;
            user.Balance = 0;
            user.RoleId = 6;
            user.ResetCredit = resetCredit;
            user.Balance = credit;

            AgentManager agentManager = new AgentManager();
            Agent info = agentManager.GetAgentByUserName(user.UpUserName);
            if (info != null)
            {
                if (user.Credit + info.UserCredit > info.Credit)
                {
                    return "[{\"mark\":\"信用不能大于\",\"xy\":\"" + (info.Credit - info.UserCredit).ToString("0") + "\"}]";
                }
            }

            int Id = UserManager.AddAgentUser(user);
            user.ID = Id;
            //return JsonConvert.SerializeObject(user);
            return ObjectToJson.ObjectsToJson<User>(user);
        }

         

        /// <summary>
        /// 返回记录数
        /// create by 肖军文
        /// create date 2010-09-28
        /// </summary>
        /// <param name="upUserName">上级归属</param>
        /// <param name="userName">账号名称</param>
        /// <param name="status">状态</param>
        /// <param name="limitStart">索引开始</param>
        /// <param name="limitEnd">索引结束</param>
        /// <returns></returns>
        [WebMethod(true)]
        public int GetAgentsAcount(string moneyType, string upUserName,string userName,string status,int roleId)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return 0;
            }

            if (roleId == 6)
            {
                return UserManager.GetUserAcount(upUserName,userName,status);
            }
            else {
                return AgentManager.GetAgentAcount(moneyType, upUserName, userName, status);

            }
             
        }

        /// <summary>
        /// 更新代理信息
        /// create by 肖军文
        /// create date 2010-09-28
        /// </summary>
        /// <param name="name">名字</param>
        /// <param name="tel">电话</param>
        /// <param name="mobile">手机号</param>
        /// <param name="status">状态</param>
        /// <param name="userName">账号名称</param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool UpdateAgent(string name, string tel, string mobile, string status, string userName,int roleId)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            User user = new User();
            if (roleId == 6)
            {
                return UserManager.UpdateUser(name, tel, mobile, status, userName);
            }
            else
            {
                return AgentManager.UpdateAgent(name,tel,mobile,status,userName);
            }
        }

        /// <summary>
        /// 返回config表所有数据
        /// </summary>
        /// <returns></returns>
        [WebMethod(true)]
        public string GetConfigAll()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return ConfigManager.GetConfigAll();
        }

        /// <summary>
        /// 更新占成
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="percent"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string UpdatePercent(int ID, double percent, int roleId)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            if (roleId == 6)
            {
                //会员
                return UserManager.UpdatePercent(ID, percent);
            }
            else
            {
                //代理
                return AgentManager.UpdatePercent(ID, percent, roleId);
            }
        }

        [WebMethod(true)]
        public string GetUserByWhere(string userName, string status, string currency, string time1, string time2, string agentType, string agents, string MoneyType)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            agent.PageBase page = new agent.PageBase();
            switch (page.agentRoleID)
            {
                case 2:
                    agentType = "SubCompany";
                    break;
                case 3:
                    agentType = "Partner";
                    break;
                case 4:
                    agentType = "GeneralAgent";
                    break;
                case 5:
                    agentType = "Agent";
                    break;
            }
            agents = page.agentUserName;
            return UserManager.GetUserByWhere(userName, status, currency, time1, time2, agentType, agents, MoneyType);
        }
        [WebMethod(true)]
        public bool UpdatePwdSend(string oldpwd, string newpwd)
        {

            if (Session[Util.ProjectConfig.ADMINUSER] != null)
            {
                Model.Agent user = Session[ProjectConfig.ADMINUSER] as Model.Agent;

                return DAL.UserService.UpdatePwdSend(user.UserName, oldpwd, newpwd);
            }
            else
            {
                return false;
            }
        }

        #region 新版代理佣金计算表
        [WebMethod(true)]
        public string GetSumAgentInfo(string time1, string time2)
        {
            if (Session[ProjectConfig.ADMINUSER] != null)
            {
                Agent manager = Session[ProjectConfig.ADMINUSER] as Agent;
                string username=manager.UserName;
                return UserManager.GetSumAgentInfo(username, time1, time2);
            }
            else
            {
                return "";
            }
             
        }
        
        [WebMethod(true)]
        public string GetEVnMonInfo()
        {
            if (Session[ProjectConfig.ADMINUSER] != null)
            {
                Agent manager = Session[ProjectConfig.ADMINUSER] as Agent;
                string agentname = manager.UserName;
                return UserManager.GetEVnMonInfo(agentname);
            }
            else
            {
                return "";
            }
             
        }

        [WebMethod(true)]
        public string GetQGHis()
        {
            if (Session[ProjectConfig.ADMINUSER] != null)
            {
                Agent manager = Session[ProjectConfig.ADMINUSER] as Agent;
                string agentname = manager.UserName;
                return UserManager.GetQGHis(agentname);
            }
            else
            {
                return "";
            }

        }

        [WebMethod(true)]
        public string GetagentInfo()
        {
            if (Session[ProjectConfig.ADMINUSER] != null)
            {
                Agent manager = Session[ProjectConfig.ADMINUSER] as Agent;
                string agentname = manager.UserName;
                return UserManager.GetagentInfo(agentname);
            }
            else
            {
                return "";
            }

        }


        [WebMethod(true)]
        public bool CheckAgentamount(string username, string Type, string txtanswer, string amount, string Status, string Reasoncn, string mark)
        {
            if (Session[ProjectConfig.ADMINUSER] != null)
            {
                Agent manager = Session[ProjectConfig.ADMINUSER] as Agent;
                string agentname = manager.UserName;
                return UserManager.CheckAgentamount(username, txtanswer, Type, amount, Status, Reasoncn, mark);
            }
            else
            {
                return false;
            }

        }
         [WebMethod(true)]
        public string GetjoinerInfo()
        {
            if (Session[ProjectConfig.ADMINUSER] != null)
            {
                Agent manager = Session[ProjectConfig.ADMINUSER] as Agent;
                string agentname = manager.UserName;
                return UserManager.GetjoinerInfo(agentname);
            }
            else
            {
                return "";
            }

        }
           [WebMethod(true)]
         public bool UpdateAgentInfo(string tel, string url, string add)
        {
            if (Session[ProjectConfig.ADMINUSER] != null)
            {
                Agent manager = Session[ProjectConfig.ADMINUSER] as Agent;
                string agentname = manager.UserName;
                return UserManager.UpdateAgentInfo(agentname, tel, url, add);
            }
            else
            {
                return false;
            }

        }

           [WebMethod(true)]
           public bool CheckOldPwd(string oldPwd)
           {
               if (Session[ProjectConfig.ADMINUSER] != null)
               {
                   Agent manager = Session[ProjectConfig.ADMINUSER] as Agent;
                   string agentname = manager.UserName;
                   return UserManager.CheckOldPwd(oldPwd, agentname);
               }
               else
               {
                   return false;
               }

           }
        
             [WebMethod(true)]
           public bool UpdatePassword(string oldPwd)
           {
               if (Session[ProjectConfig.ADMINUSER] != null)
               {
                   Agent manager = Session[ProjectConfig.ADMINUSER] as Agent;
                   string agentname = manager.UserName;
                   return UserManager.UpdatePassword(oldPwd, agentname);
               }
               else
               {
                   return false;
               }

           }
        #endregion

             [WebMethod(true)]
             public bool IsExistUsername(string username)
             {
                 return DAL.UserService.IsExistUsername(username.Trim());
             }

             [WebMethod(true)]
             public bool Updatgameuser(string agentname, string username)
             {
                


                 return DAL.UserService.Updatgameuser(agentname.Trim(), username.Trim());
             }
    }
}
