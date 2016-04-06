using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Model;
using DAL;

namespace BLL
{
		///<sumary>
		///业务逻辑类
		///</sumary>
	public class AgentManager
	{
		private static AgentService agentService=new AgentService();

        /// <summary>
        /// 处理字符串（testz 处理后：'te','tes','test','testz')
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string getUserNames(string userName)
        {
            string userNames = "";
            for (int i = 1; i < userName.Length; i++)
            {
                if (userNames == "")
                {
                    userNames = "'" + userName.Substring(0, i + 1) + "'";
                }
                else
                {
                    userNames += ",'" + userName.Substring(0, i + 1) + "'";
                }
            }
            return userNames;

        }

        /// <summary>
        /// 返回userName所有上级数据（包括userName)
        /// By xzz 2010-12-1
        /// </summary>
        /// <param name="userNames"></param>
        /// <returns></returns>
        public IList<Agent> GetAgentByUserNames(string userNames)
        {
            return agentService.GetAgentByUserNames(userNames);
        }

        public Agent GetAgentByUserName(string userName)
        {
            return agentService.GetAgentByUserName(userName);
        }

        /// <summary>
        /// 判断代理子帐号是否存在(重复)
        /// by xzz 2010-11-30
        /// </summary>
        /// <param name="agentUserName"></param>
        /// <returns></returns>
        public bool IsExistSubAccount(string userName, string agentUserName)
        {
            Agent agent = agentService.IsExistSubAccount(userName, agentUserName);
            if (agent == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 代理子帐号启用禁用
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UpdateAgentStatus(string userName, int status)
        {
            return agentService.UpdateAgentStatus(userName, status);
        }

        /// <summary>
        /// 修改代理子帐号
        /// </summary>
        /// <param name="RoleName"></param>
        /// <param name="RoleId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UpdateAgentSubAccount(string RoleName, int RoleId, string userName)
        {
            return agentService.UpdateAgentSubAccount(RoleName, RoleId, userName);
        }

        /// <summary>
        /// 增加代理子帐号
        /// By xzz 2010-11-26
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        public Agent AddAgentSubAccount(Agent agent)
        {
            int id = agentService.AddAgentSubAccount(agent.UserName, agent.Password, agent.Status, agent.RoleId, agent.RoleName, agent.SubAccount,
                agent.AgentID, agent.AgentUserName, agent.AgentRoleName, agent.AgentRoleID, agent.RegistrationTime, agent.UpUserName, agent.UpUserID,
                agent.UpRoleId, agent.UpRoleName);
            agent.ID = id;

            return agent;
        }

        /// <summary>
        /// 更新代理子帐号角色名称
        /// By xzz 2010-12-2
        /// </summary>
        /// <param name="RoleId">角色ID</param>
        /// <returns></returns>
        public int UpdateSubAccountRoleName(string roleName, int RoleId)
        {
            return agentService.UpdateSubAccountRoleName(roleName, RoleId);
        }

        /// <summary>
        /// 返回代理子帐号
        /// By xzz 2010-11-26
        /// </summary>
        /// <param name="agentUserName"></param>
        /// <returns></returns>
        public string GetSubAccount(string agentUserName)
        {
            string reStr = ObjectToJson.ObjectListToJson<Agent>(agentService.GetSubAccount(agentUserName));
            return reStr;
        }

        /// <summary>
        /// 根据角色ID返回代理子帐号
        /// By xzz 2010-11-26
        /// </summary>
        /// <param name="agentUserName"></param>
        /// <returns></returns>
        public IList<Agent> GetSubAccountByRoleID(int roleID)
        {
            return agentService.GetSubAccountByRoleID(roleID);
        }

        /// <summary>
        /// 验证代理帐号密码
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="agent"></param>
        /// <returns></returns>
        public static bool CheckLogin(string userName, string password, ref Agent agent)
        {
            Agent m = agentService.GetAgentByUserName(userName, password);
            if (m != null)
            {
                 agent = m;
                 return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 重置会员信用
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="resetCredit"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public bool UpdateResetCredit(string userName, string resetCredit, int roleID)
        {
            UserService userService = new UserService();
            bool updateAgent = true;
            bool updateUser = true;
            switch (roleID)
            {
                case 2:
                    //分公司
                    agentService.UpdateResetCreditBySubCompany(userName, resetCredit);
                    userService.UpdateResetCreditBySubCompany(userName, resetCredit);
                    break;
                case 3:
                    //股东
                    agentService.UpdateResetCreditByPartner(userName, resetCredit);
                    userService.UpdateResetCreditByPartner(userName, resetCredit);
                    break;
                case 4:
                    //总代
                    agentService.UpdateResetCreditByGeneralAgent(userName, resetCredit);
                    userService.UpdateResetCreditByGeneralAgent(userName, resetCredit);
                    break;
                case 5:
                    //代理
                    agentService.UpdateResetCreditByAgents(userName, resetCredit);
                    userService.UpdateResetCreditByAgent(userName, resetCredit);
                    break;
                case 6:
                    userService.UpdateResetCreditByUser(userName, resetCredit);
                    break;
            }

            if (updateAgent && updateUser)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 是否存在帐号
        /// By xzz 2010-11-8
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string IsExistUser(string userName)
        {
            DataTable dt = agentService.IsExistUser(userName);
            if (dt.Rows.Count > 0)
            {
                return "帐号已存在";
            }
            else
            {
                return "帐号可以使用";
            }
        }

        /// <summary>
        /// 更新占成
        /// By xzz
        /// 2010-10-8
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="percent"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static string UpdatePercent(int ID, double percent, int roleId)
        {
            double maxPercent = 0;
            double UpPercent = 10;
            object ob;
            if (roleId == 5)
            {
                UserService userService = new UserService();
                ob = userService.GetMaxPercentByUserName(ID);
                if (!Convert.IsDBNull(ob))
                {
                    maxPercent = Convert.ToDouble(ob);
                }
            }
            else
            {
                ob = agentService.GetMaxPercentByUserName(ID);
                if (!Convert.IsDBNull(ob))
                {
                    maxPercent = Convert.ToDouble(ob);
                }
            }

            Agent agent = GetAgentByPK(ID);
            if (agent != null)
            {
                if (roleId != 2)
                {
                    Agent upAgent = GetAgentByPK(agent.UpUserID);
                    if (upAgent != null)
                    {
                        UpPercent = upAgent.Percent;
                    }
                }
            }



            if (percent < maxPercent)
            {
                return "不能小于下级最大占成:" + maxPercent.ToString("");
            }
            else if(percent > UpPercent)
            {
                return "不能大于上级占成:" + UpPercent.ToString("");
            }
            else
            {
                if (agentService.UpdatePercent(percent, ID))
                {
                    //更新会员占成
                    if (roleId == 5)
                    {
                        agentService.UpdatePercentAll(UpPercent - percent, percent, agent.RoleId, agent.UserName);
                    }
                    else
                    {
                        IList<Agent> nextAgents = agentService.GetAgentByupUsername(agent.UserName);
                        foreach (Agent info in nextAgents)
                        {
                            agentService.UpdatePercentAll(UpPercent - percent, percent - info.Percent, agent.RoleId, info.UserName);
                        }
                    }
                    return "ok";
                }
                else
                {
                    return "更新失败";
                }
            }
        }

        /// <summary>
        /// 获取除指定ID 以外的信用总值
        /// 编写时间: 2010-10-7 14:00
        /// 创建者：Mickey
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetCredits(string Id, string userId)
        {
            return ObjectToJson.ReaderToJson(agentService.GetCredits(Id,userId));
        }

        /// <summary>
        /// 获取上级信用之和(最大信用)
        /// 编写时间: 2010-10-6 20:32
        /// 创建者：Mickey
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static string GetMaxCredit(string Id)
        {
            return ObjectToJson.ReaderToJson(agentService.GetMaxCredit(Id));
        }

        public static string GetBalance(string Id)
        {
            return ObjectToJson.ReaderToJson(agentService.GetBalance(Id));
        }

        /// <summary>
        /// 获取下级信用之和(最小信用)
        /// 编写时间: 2010-10-6 14:20
        /// 创建者：Mickey
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static string GetMinCredit(string roleId)
        {
            return ObjectToJson.ReaderToJson(agentService.GetMinCredit(roleId));
        }

        /// <summary>
        /// 修改信用
        /// 编写时间: 2010-10-6 14:10
        /// 创建者：Mickey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="credit"></param>
        /// <returns></returns>
        public static bool updateCredit(string id, string credit, string userId, string userCredit, decimal balance)
        {
            if (agentService.updateCredit(id, credit,balance))
            {
                return agentService.updateUserCredit(userId, userCredit);
            }
            else
            {
               return false;
            }

        }

        /// <summary>
        /// 获取子集最大佣金A、B、C
        /// 编写时间: 2010-10-4 17:00
        /// 创建者：Mickey
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static string GetRoleCommission(int roleId, int upUserID)
        {
            if (roleId == 5)
            {
                return ObjectToJson.ReaderToJson(agentService.GetMaxCommissionByUser(upUserID));
            }
            else
            {
                return ObjectToJson.ReaderToJson(agentService.GetRoleCommission(upUserID));
            }
        }

        /// <summary>
        /// 查询：Agent 数据（Json)
        /// 编写时间：2010-10-2
        /// 创建者：Mickey
        /// </summary>
        /// <returns></returns>
        public static string GetAgentAll()
        {
            return ObjectToJson.ReaderToJson(agentService.GetAgentAll());
        }

        /// <summary>
        /// 修改佣金
        /// 编写时间：2010-10-3
        /// 创建者：Mickey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commissionA"></param>
        /// <param name="commissionB"></param>
        /// <param name="commissionC"></param>
        /// <returns></returns>
        public static bool updateCommission(string id, string commissionA, string commissionB, string commissionC)
        {
            if (agentService.updateCommission(id, commissionA, commissionB, commissionC))
            {
                Agent info = agentService.GetAgentByPK(id);
                return agentService.UpdateLowerCommission(info.RoleId, info.UserName, commissionA);
            }
            else
            {
                return false;
            }
        }

		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-9-28 15:43:52
		///</sumary>
		public static Agent GetAgentByPK(object pk) 
		{
			try
			{
				return agentService.GetAgentByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-9-28 15:43:52
		///</sumary>
		public static Boolean AddAgent(Agent agent) 
		{
			try
			{
				return agentService.AddAgent(agent);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-9-28 15:43:52
		///</sumary>
		public static Boolean UpdateAgent(Agent agent) 
		{
			try
			{
				return agentService.UpdateAgent(agent);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-9-28 15:43:52
		///</sumary>
		public static Boolean DeleteAgentByPK(object pk) 
		{
			try
			{
				return agentService.DeleteAgentByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-9-28 15:43:52
		///</sumary>
		public static DataTable GetMutilDTAgent() 
		{
			try
			{
				return agentService.GetMutilDTAgent();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-9-28 15:43:52
		///</sumary>
		public static IList<Agent> GetMutilILAgent() 
		{
			try
			{
				return agentService.GetMutilILAgent();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion
        /// <summary>
        /// create by tank
        /// create date 2010-10-02 22:37
        /// decription  查询记录总数
        /// </summary>
        /// <param name="upUserName">上级名称</param>
        /// <param name="userName">账户名称</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public static int GetAgentAcount(string moneyType, string upUserName, string userName, string status)
        {
            try
            {
                if (upUserName != "")
                {
                    return agentService.GetAgentAcount(upUserName, userName, status);
                }
                return agentService.GetAgentAcount(moneyType, 2, userName, status);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 更新代理信息
        /// create by 肖军文
        /// create date 2010-09-28
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="tel">固话</param>
        /// <param name="mobile">手机号</param>
        /// <param name="status">状态</param>
        /// <param name="userName">账户名称</param>
        /// <returns></returns>
        public static bool UpdateAgent(string name, string tel, string mobile, string status, string userName)
        {
            try
            {
                return agentService.UpdateAgentByUserName(name, tel, mobile, status, userName);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 更改代理密码
        /// create by 肖军文
        /// create date 2010-09-28
        /// </summary>
        /// <param name="pass">密码</param>
        /// <param name="userName">账户名</param>
        /// <returns></returns>
        public static bool UpdatePass(string pass, string userName)
        {
            try
            {
                if (agentService.UpdatePass(pass, userName))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 根据条件查询代理信息
        /// create by 肖军文
        /// create date 2010-09-28
        /// </summary>
        /// <param name="upUserName"></param>
        /// <param name="userName"></param>
        /// <param name="status"></param>
        /// <param name="limitStart"></param>
        /// <param name="limitEnd"></param>
        /// <returns></returns>
        public static IList<Agent> GetAgents(string moneyType, string upUserName, string userName, string status, int limitStart, int limitEnd)
        {
             IList<Agent> list = null;
            if (upUserName == "")
            {
                list = agentService.GetAgents(moneyType, 2, userName, status, limitStart, limitEnd);
                
            }
            else {
                list = agentService.GetAgents(upUserName, userName, status, limitStart, limitEnd);
               
            }
            return list;
            
        }

        /// <summary>
        /// 增加代理信息
        /// create by 肖军文
        /// create date 2010-09-29
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        public static int AddAgentUser(Agent agent)
        {
            try
            {

                int Id = agentService.AddAgentUser(agent);
                if (Id != 0)
                {
                    if (agentService.UpdateAgentNumber(agent.UpUserID, agent.RoleId))
                    {
                        if (agent.RoleId != 2)
                        {
                            agentService.UpdateUserCredit(agent.Credit, agent.UpUserName);
                        }

                        return Id;
                    }
                    return 0;
                }
                else {
                    return 0;
                }
               
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #region 编写人:李毅
        public static string GetNextLevel(int id)
        {
            return agentService.GetNextLevel(id);
        }

        public static string GetNextAndUpLevel(int id,int roleid)
        {
            return agentService.GetNextAndUpLevel(id,roleid);
        }

        public static string GetUpLevel(int id)
        {
            return agentService.GetUpLevel(id);
        }

        public static List<string> GetNextAndUpLevelToList(int id,int roleid)
        {
            return agentService.GetNextAndUpLevelToList(id,roleid);
        }

        public static List<string> GetNextAndUpLevelToList1(int id)
        {
            return agentService.GetNextAndUpLevelToList1(id);
        }

        public static List<string> GetNextAndUpLevelToList2(int id)
        {
            return agentService.GetNextAndUpLevelToList2(id);
        }

        public static string update(int id, int min, int max, int onemax)
        {
            return agentService.update(id,min,max,onemax);
        }

        public static string updateUser(int id, int min, int max, int onemax)
        {
            return agentService.updateUser(id, min, max, onemax);
        }

        /*---------------会员注单------------*/

        public static string getAgent(int id, int roid, int IDex, int IDexC)
        {
            return agentService.getAgent(id, roid, IDex, IDexC);
        }

        public static string getorder(string un, string lg, int IDex, int IDexC)
        {
            return agentService.getorder(un, lg, IDex, IDexC);
        }
        /*---------------会员注单结束------------*/

        #endregion


        public static string GetUserMinCredit(string upId)
        {
            return ObjectToJson.ReaderToJson(agentService.GetUserMinCredit(upId));
        }
    }
}
