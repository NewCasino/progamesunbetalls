using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using Model;
using Newtonsoft.Json;
using DAL;
using System.Data;

namespace Admin.ServicesFile
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
        /// 更新会员等级
        /// </summary>
        /// <param name="UserLevel">等级</param>
        /// <param name="Coefficient">跟投系数</param>
        /// <param name="Proportion">吃货比例</param>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool UpdateUserLevel(string UserLevel, string Coefficient, string Proportion, string userName)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            bool json = false;
            UserManager um = new UserManager();
            bool reval = um.UpdateUserLevel(UserLevel, Coefficient, Proportion, userName);
            if (reval)
            {
                json = true;
            }
            else
            {
                json = false;
            }
            return json;
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

            return BLL.AgentManager.GetRoleCommission(roleId,upUserID);
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

            //帐号是否存在
            admin.PageBase pageBase = new admin.PageBase();
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
            managerModel.CreateUser = pageBase.CurrentManager.ManagerId;
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

        [WebMethod(true)]
        public bool IsExistRole(string roleName, string agentId)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            RoleManager roleManager = new RoleManager();
            bool reval = roleManager.IsExistRole(roleName, agentId);
            return reval;
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
                    string aa = ObjectToJson.ObjectListToJson<Agent>(AgentManager.GetAgents(moneyType, upUserName, userName, status, limitStart, limitEnd));
                    return aa;
                     
                    
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
            decimal commissionA, decimal commissionB, decimal commissionC, string resetCredit, string parentCode)
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
            agent.ParentCode = parentCode;

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
        public string AddUser(string moneyType, string userName, string pass, string name, string mobile, string currency, string email
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
            user.MoneyType = moneyType;

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
        public string GetAccountInfo(string userName)
        {
            return UserManager.GetAccountInfo(userName);
        }

        [WebMethod(true)]
        public string GetUserByWhere(string userName, string status, string currency, string time1, string time2, string agentType, string agents, string MoneyType)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return UserManager.GetUserByWhere(userName, status, currency, time1, time2, agentType, agents, MoneyType);
        }

        [WebMethod(true)]
        public string GetUserByWhere1(
            string userName,
            string status,
            string regTime1,
            string regTime2,
            string loginTime1,
            string loginTime2,
            string agent,
            string ip,
            string tel,
            string email)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return DAL.UserService.GetUserByWhere1(userName, status, regTime1, regTime2, loginTime1, loginTime2, agent, ip, tel, email);
        }

        [WebMethod(true)]
        public string GetUserByWhere2(
            string name,
            string userName,
            string status,
            string regTime1,
            string regTime2,
            string loginTime1,
            string loginTime2,
            string agent,
            string ip,
            string tel,
            string email)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return DAL.UserService.GetUserByWhere2(name, userName, status, regTime1, regTime2, loginTime1, loginTime2, agent, ip, tel, email);
        }

        [WebMethod(true)]
        public string GetUserByWherePage2(
            int perPageNum, 
            int page,
            string name,
            string userName,
            string status,
            string regTime1,
            string regTime2,
            string loginTime1,
            string loginTime2,
            string agent,
            string ip,
            string tel,
            string email)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return DAL.UserService.GetUserByWherePage2(perPageNum, page, name, userName, status, regTime1, regTime2, loginTime1, loginTime2, agent, ip, tel, email);
        }
        
        [WebMethod(true)]
        public string GetUserByWhere_win(
            string name,
            string userName,
            string status,
            string regTime1,
            string regTime2,
            string loginTime1,
            string loginTime2,
            string agent,
            string ip,
            string tel,
            string email,string wincount)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return DAL.UserService.GetUserByWhere_win(name, userName, status, regTime1, regTime2, loginTime1, loginTime2, agent, ip, tel, email,wincount);
        }


        [WebMethod(true)]
        public string GetUserByWhere_info(
            string userName,string Name,
            string status,
            string regTime1,
            string regTime2,
            string loginTime1,
            string loginTime2,
            string agent,
            string ip,
            string tel,
            string email)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return DAL.UserService.GetUserByWhere_info(userName,Name,status, regTime1, regTime2, loginTime1, loginTime2, agent, ip, tel, email);
        }

        [WebMethod(true)]
        public bool UpdateUser(string FirstName, string LastName, string sex, string Email, DateTime Birthday, string country,
            string addr, string city, string Province, string post, string Mobile, string question, string Answer, int ID)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            Model.User info = new User();
            info.FirstName = FirstName;
            info.LastName = LastName;
            info.Sex = sex;
            info.Email = Email;
            info.Birthday = Birthday;
            info.Country = country;
            info.Addr = addr;
            info.City = city;
            info.Province = Province;
            info.Post = post;
            info.Mobile = Mobile;
            info.Question = question;
            info.Answer = Answer;
            info.ID = ID;

            return UserManager.UpdateUser1(info);

        }

        [WebMethod(true)]
        public bool UpdateUser2(string txtname, string txtquestion, string txtanswer, string txtnicheng, string txtemail, string txttel,
            string txtpost, int txtstatus, int ID)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            Model.User info = new User();
            info.Name = txtname;
            info.Question = txtquestion;
            info.Answer = txtanswer;
            info.nicheng = txtnicheng;
            info.Email = txtemail;
            info.Tel = txttel;
            info.Post = txtpost;
            info.Status = txtstatus;
            info.ID = ID;

            return DAL.UserService.UpdateUser2(info);

        }

        [WebMethod(true)]
        public bool UpdateUser22(string level, string txtname, string txtquestion, string txtanswer, string txtnicheng, string txtemail, string txttel,
            string txtpost, int txtstatus, string txtmark, int ID)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            Model.User info = new User();
            info.Name = txtname;
            info.Question = txtquestion;
            info.Answer = txtanswer;
            info.nicheng = txtnicheng;
            info.Email = txtemail;
            info.Tel = txttel;
            info.Post = txtpost;
            info.Status = txtstatus;
            info.UserLevel = level;
            info.mark = txtmark;
            info.ID = ID;

            return DAL.UserService.UpdateUser22(info);

        }

        [WebMethod(true)]
        public string GetUserByID(int ID)
        {
            return ObjectToJson.ObjectsToJson<User>(UserManager.GetUserByPK(ID));
        }

        [WebMethod(true)]
        public string GetJym(int len)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return ObjectToJson.MakePassword(len);
        }
        [WebMethod(true)]
        public string IPStatistics(string username, string loginIP, string regIp)
        {
            string str = "";
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            if (string.IsNullOrEmpty(regIp))
            {
                //登录查询
                str = DAL.UserService.GetLoginLog(username, loginIP);
            }
            else
            {
                //注册查询
                str = DAL.LoginserversService.GetRegIP(regIp);
            }
            return str;
        }
        /// <summary>
        /// 获取用户资料
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string GetUserInfo(string userName)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return DAL.UserService.GetUserInfoByUserName(userName);
        }

        /// <summary>
        /// 修改赢币详细
        /// </summary>
        /// <param name="txtname"></param>
        /// <param name="txtquestion"></param>
        /// <param name="txtanswer"></param>
        /// <param name="txtnicheng"></param>
        /// <param name="txtemail"></param>
        /// <param name="txttel"></param>
        /// <param name="txtpost"></param>
        /// <param name="txtstatus"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool UpdateUser5(string UserName, string Wincoins, string WincoinInfo)       
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

           decimal Wincoins2 = Convert.ToDecimal(Wincoins);

           return DAL.UserService.UpdateUser5(UserName, Wincoins2, WincoinInfo);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="win2">现有赢币</param>
        /// <param name="win1">要兑换赢币</param>
        /// <param name="WincoinInfo">转换信息</param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool UpdateUser8(string UserName, decimal win2, decimal win1, string WincoinInfo)
        {
            //var win1 = parseInt($("#txtThwin").val());  //要兑换币
            //    var win2 
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }
            if (win2<win1)
            {
                return false;//兑换超过现有赢币数
            }

          // decimal Wincoins2 = Convert.ToDecimal(Wincoins);
           
            return DAL.UserService.UpdateUser8(UserName, win2,win1, WincoinInfo);

        }

        /// <summary>
        /// 添加赢币
        /// </summary>
        /// <param name="yingb"></param>
        /// <param name="mark"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool AddYingb(decimal yingb, string mark, string username)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }
            return BLL.UserManager.AddYingb(yingb, "7", mark, username);
        }

        /// <summary>
        /// 获取游戏平台金额
        /// </summary>
        /// <returns></returns>
        [WebMethod(true)]
        public string GetEAamount(string username)
        {

            string reval = BLL.BankManager.GetEAamount(username);
            if (reval == "ERR_INVALID_CLIENT")
            {
                reval = "0.00";
            }
            return reval;
        }

        [WebMethod(true)]
        public string UserStatistics()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "-1";
            }

            return DAL.UserService.UserStatistics();
        }

        [WebMethod(true)]
        public string GetPtthing(string username, string type, string status, string time1, string time2)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "-1";
            }
            return DAL.UserService.GetPtthing(username, type, status, time1, time2);
        }

        [WebMethod(true)]
        public string UpdatePtthing(string status, int ID)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "-1";
            }
            return DAL.UserService.UpdatePtthing(status, ID) ? "1" : "0";
        }
        [WebMethod(true)]
        public string UpdateUserStatus(string status, string userName)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "-1";
            }
            return DAL.UserService.UpdateUserStatus(status, userName) ? "1" : "0";
        }


        [WebMethod(true)]
        public string UpdatePtthingpass(string username, string pass, string status, int ID)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "-1";
            }
            bool rebit = DAL.UserService.UpdatePtthing(status, ID);
            if (rebit)
            {
                DAL.UserService.UpdatePtPass(username, pass);
            }
            return rebit ? "1" : "0";
        }

        [WebMethod(true)]
        public string UpdatePtthing1(string username, string pass, string status, int ID)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "-1";
            }
            bool rebit = DAL.UserService.UpdatePtthing(status, ID);
            if (rebit)
            {
                return DAL.UserService.UpdatePtUser(username, pass) ? "1" : "0";
            }
            return "0";
        }

        [WebMethod(true)]
        public string GetPTbillnoticehistory(string username, string type, string time1, string time2, string status)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "-1";
            }
            return DAL.UserService.GetPTbillnoticehistory(username, type, time1, time2, status);
        }

        [WebMethod(true)]
        public string Updatebillnoticehistory(string status, int ID)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "-1";
            }
            Manager manager = Session[Util.ProjectConfig.ADMINUSER] as Manager;
            //return DAL.UserService.Updatebillnoticehistory(status, ID) ? "1" : "0";
            BillNotice billNotice = BLL.BankManager.GetBillNotice(ID.ToString());
            Model.BillNoticeHistory billHistory = new BillNoticeHistory();
            billHistory.UserName = billNotice.UserName;
            billHistory.Type = billNotice.Type;
            billHistory.Amount = billNotice.Amount;
            billHistory.SubmitTime = billNotice.SubmitTime;
            billHistory.UpdateTime = DateTime.Now;
            billHistory.Status = status;
            bool rebit = BLL.BankManager.InsertBillNoticeHistory(billHistory);
            if (rebit)
            {
                bool reb = BLL.BankManager.DeleteBillNoticeByID(ID.ToString());
                if (status == "3")
                {
                    //拒绝
                    if (reb)
                    {
                        BLL.BankManager.UpdateBalance(billNotice.Amount.ToString(), billNotice.UserName, "1");
                      
                    }
                }
                else
                {
                    string operers = manager.ManagerId;
                    BLL.BankManager.InsertPTLog2(billNotice.UserName, billNotice.Amount, operers);
                }
              
            }
            return (rebit ? "1" : "0");
        }

        /// <summary>
        /// pt转总账
        /// </summary>
        /// <param name="status"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string PTtoAccount(string status, int ID)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "-1";
            }
            Manager manager = Session[Util.ProjectConfig.ADMINUSER] as Manager;
            //return DAL.UserService.Updatebillnoticehistory(status, ID) ? "1" : "0";
            BillNotice billNotice = BLL.BankManager.GetBillNotice(ID.ToString());
            Model.BillNoticeHistory billHistory = new BillNoticeHistory();
            billHistory.UserName = billNotice.UserName;
            billHistory.Type = billNotice.Type;
            billHistory.Amount = billNotice.Amount;
            billHistory.SubmitTime = billNotice.SubmitTime;
            billHistory.UpdateTime = DateTime.Now;
            billHistory.Status = status;
            bool rebit = BLL.BankManager.InsertBillNoticeHistory(billHistory);
            if (rebit)
            {
                bool reb = BLL.BankManager.DeleteBillNoticeByID(ID.ToString());
                if (status == "2")
                {
                    //接受
                    if (reb)
                    {
                        BLL.BankManager.UpdateBalance(billNotice.Amount.ToString(), billNotice.UserName, "1");

                       
                        string operer = manager.ManagerId;
                        BLL.BankManager.InsertPTLog(billNotice.UserName, billNotice.Amount,operer);
                       
                    }
                }
            }
            return (rebit ? "1" : "0");
        }

        [WebMethod(true)]
        public string GetPTbillnotice(string username, string type, string time1, string time2)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "-1";
            }

            return DAL.UserService.GetPTbillnotice(username, type, time1, time2);
        }

        //公告：获取所有待处理数据
        [WebMethod(true)]
        public string getPTUserInfo()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "-1";
            }

            return DAL.UserService.getPTUserInfo();
        }

        //IP分析
        [WebMethod(true)]
        public string GetIpinfo(string username)
        {
            try
            {
                string SQLx = "select regip,LastLoginIP from user where username='" + username + "'";
                string SQLy = "";
                string regip = "";
                string LastLoginIP = "";
                string usernames = "";
                DataTable dt = MySqlHelper.ExecuteDataTable(SQLx);
                if (dt.Rows.Count > 0)
                {
                    regip = dt.Rows[0]["regip"].ToString();
                    LastLoginIP = dt.Rows[0]["LastLoginIP"].ToString();
                    if (regip.Trim() == "127.0.0.1" && LastLoginIP.Trim() != "" && LastLoginIP.Trim() !="127.0.0.1")
                    {
                        SQLy = "select DISTINCT(username) from logclient where IP in ('" + LastLoginIP + "') ";
                        DataTable dt2 = MySqlHelper.ExecuteDataTable(SQLy);
                        if (dt2.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt2.Rows.Count; i++)
                            {
                                usernames += dt2.Rows[i]["username"].ToString() + ",";
                            }


                            return usernames.Substring(0, usernames.Length - 1) + "(" + LastLoginIP+")";
                        }
                        else
                        {
                            return "";
                        }
                    }
                    else if (regip.Trim() != "127.0.0.1" && LastLoginIP != "" && LastLoginIP.Trim() != "127.0.0.1")
                    {
                        SQLy = "select  DISTINCT(username) from logclient where IP in ('" + regip + "','" + LastLoginIP + "') ";
                        DataTable dt2 = MySqlHelper.ExecuteDataTable(SQLy);
                        if (dt2.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt2.Rows.Count; i++)
                            {
                                usernames += dt2.Rows[i]["username"].ToString() + ",";
                            }
                            if (regip != LastLoginIP)
                            {
                                return usernames.Substring(0, usernames.Length - 1) + " (" + regip + "," + LastLoginIP + ")";
                            }
                            else
                            {
                                return usernames.Substring(0, usernames.Length - 1) + "(" + LastLoginIP + ")";
                            }
                           
                        }
                        else
                        {
                            return "";
                        }
                    }
                    else
                        return "";


                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {

                return "";
            }
           
        }
    }
}
