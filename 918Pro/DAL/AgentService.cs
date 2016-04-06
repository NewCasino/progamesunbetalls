using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class AgentService
	{
        //private const string SQL_INSERT="insert into yafa.agent (UserName,Password,Name,Mobile,Email,Tel,Status,SubCompany,SCnumber,Partner,Pnumber,GeneralAgent,Ganumber,Agents,Agentsnumber,MaxUser,RoleId,SubAccount,UpUserName,UpUserID,UpRoleId,RegistrationTime,LastLoginTime,LastLoginIP,ItemMin,ItemMax,ItemsMax,UserLevel,Coefficient,Proportion,Area,Percent,Credit,CommissionA,CommissionB,CommissionC,UpRoleName)values(?UserName,?Password,?Name,?Mobile,?Email,?Tel,?Status,?SubCompany,?SCnumber,?Partner,?Pnumber,?GeneralAgent,?Ganumber,?Agents,?Agentsnumber,?MaxUser,?RoleId,?SubAccount,?UpUserName,?UpUserID,?UpRoleId,?RegistrationTime,?LastLoginTime,?LastLoginIP,?ItemMin,?ItemMax,?ItemsMax,?UserLevel,?Coefficient,?Proportion,?Area,?Percent,?Credit,?CommissionA,?CommissionB,?CommissionC,?UpRoleName)";
        //private const string SQL_UPDATE="update yafa.agent set UserName=?UserName,Password=?Password,Name=?Name,Mobile=?Mobile,Email=?Email,Tel=?Tel,Status=?Status,SubCompany=?SubCompany,SCnumber=?SCnumber,Partner=?Partner,Pnumber=?Pnumber,GeneralAgent=?GeneralAgent,Ganumber=?Ganumber,Agents=?Agents,Agentsnumber=?Agentsnumber,MaxUser=?MaxUser,RoleId=?RoleId,SubAccount=?SubAccount,UpUserName=?UpUserName,UpUserID=?UpUserID,UpRoleId=?UpRoleId,RegistrationTime=?RegistrationTime,LastLoginTime=?LastLoginTime,LastLoginIP=?LastLoginIP,ItemMin=?ItemMin,ItemMax=?ItemMax,ItemsMax=?ItemsMax,UserLevel=?UserLevel,Coefficient=?Coefficient,Proportion=?Proportion,Area=?Area,Percent=?Percent,Credit=?Credit,CommissionA=?CommissionA,CommissionB=?CommissionB,CommissionC=?CommissionC,UpRoleName=?UpRoleName where ID = ?ID";
        //private const string SQL_SELECTBYPK="select ID from yafa.agent  where agent.ID = ?ID";
        //private const string SQL_SELECTALL="select ID,UserName,Password,Name,Mobile,Email,Tel,Status,SubCompany,SCnumber,Partner,Pnumber,GeneralAgent,Ganumber,Agents,Agentsnumber,MaxUser,RoleId,SubAccount,UpUserName,UpUserID,UpRoleId,RegistrationTime,LastLoginTime,LastLoginIP,ItemMin,ItemMax,ItemsMax,UserLevel,Coefficient,Proportion,Area,Percent,Credit,CommissionA,CommissionB,CommissionC,UpRoleName from yafa.agent ";
        //private const string SQL_DELETEBYPK="delete  from yafa.agent  where agent.ID = ?ID";

        //private const string SQL_INSERT = "insert into yafa.agent (UserName,Password,Name,Mobile,Email,Tel,Status,SubCompany,SCnumber,Partner,Pnumber,GeneralAgent,Ganumber,Agents,Agentsnumber,MaxUser,RoleId,SubAccount,UpUserName,UpUserID,UpRoleId,RegistrationTime,LastLoginTime,LastLoginIP,ItemMin,ItemMax,ItemsMax,UserLevel,Coefficient,Proportion,Area,Percent,Credit,CommissionA,CommissionB,CommissionC,UpRoleName,RoleName,UserCredit,Balance,ResetCredit)values(?UserName,?Password,?Name,?Mobile,?Email,?Tel,?Status,?SubCompany,?SCnumber,?Partner,?Pnumber,?GeneralAgent,?Ganumber,?Agents,?Agentsnumber,?MaxUser,?RoleId,?SubAccount,?UpUserName,?UpUserID,?UpRoleId,?RegistrationTime,?LastLoginTime,?LastLoginIP,?ItemMin,?ItemMax,?ItemsMax,?UserLevel,?Coefficient,?Proportion,?Area,?Percent,?Credit,?CommissionA,?CommissionB,?CommissionC,?UpRoleName,?RoleName,?UserCredit,?Balance,?ResetCredit)";
        //private const string SQL_UPDATE = "update yafa.agent set UserName=?UserName,Password=?Password,Name=?Name,Mobile=?Mobile,Email=?Email,Tel=?Tel,Status=?Status,SubCompany=?SubCompany,SCnumber=?SCnumber,Partner=?Partner,Pnumber=?Pnumber,GeneralAgent=?GeneralAgent,Ganumber=?Ganumber,Agents=?Agents,Agentsnumber=?Agentsnumber,MaxUser=?MaxUser,RoleId=?RoleId,SubAccount=?SubAccount,UpUserName=?UpUserName,UpUserID=?UpUserID,UpRoleId=?UpRoleId,RegistrationTime=?RegistrationTime,LastLoginTime=?LastLoginTime,LastLoginIP=?LastLoginIP,ItemMin=?ItemMin,ItemMax=?ItemMax,ItemsMax=?ItemsMax,UserLevel=?UserLevel,Coefficient=?Coefficient,Proportion=?Proportion,Area=?Area,Percent=?Percent,Credit=?Credit,CommissionA=?CommissionA,CommissionB=?CommissionB,CommissionC=?CommissionC,UpRoleName=?UpRoleName,RoleName=?RoleName,UserCredit=?UserCredit,Balance=?Balance,ResetCredit=?ResetCredit where ID = ?ID";
        //private const string SQL_SELECTBYPK = "select ID from yafa.agent  where agent.ID = ?ID";
        //private const string SQL_SELECTALL = "select ID,UserName,Password,Name,Mobile,Email,Tel,Status,SubCompany,SCnumber,Partner,Pnumber,GeneralAgent,Ganumber,Agents,Agentsnumber,MaxUser,RoleId,SubAccount,UpUserName,UpUserID,UpRoleId,RegistrationTime,LastLoginTime,LastLoginIP,ItemMin,ItemMax,ItemsMax,UserLevel,Coefficient,Proportion,Area,Percent,Credit,CommissionA,CommissionB,CommissionC,UpRoleName,RoleName,UserCredit,Balance,ResetCredit from yafa.agent ";
        //private const string SQL_DELETEBYPK = "delete  from yafa.agent  where agent.ID = ?ID";

        private const string SQL_INSERT = "insert into yafa.agent (UserName,Password,Name,Mobile,Email,Tel,Status,SubCompany,SCnumber,Partner,Pnumber,GeneralAgent,Ganumber,Agents,Agentsnumber,MaxUser,RoleId,SubAccount,UpUserName,UpUserID,UpRoleId,RegistrationTime,LastLoginTime,LastLoginIP,ItemMin,ItemMax,ItemsMax,UserLevel,Coefficient,Proportion,Area,Percent,Credit,CommissionA,CommissionB,CommissionC,UpRoleName,RoleName,UserCredit,Balance,ResetCredit,AgentID,AgentUserName,AgentRoleName,AgentRoleID)values(?UserName,?Password,?Name,?Mobile,?Email,?Tel,?Status,?SubCompany,?SCnumber,?Partner,?Pnumber,?GeneralAgent,?Ganumber,?Agents,?Agentsnumber,?MaxUser,?RoleId,?SubAccount,?UpUserName,?UpUserID,?UpRoleId,?RegistrationTime,?LastLoginTime,?LastLoginIP,?ItemMin,?ItemMax,?ItemsMax,?UserLevel,?Coefficient,?Proportion,?Area,?Percent,?Credit,?CommissionA,?CommissionB,?CommissionC,?UpRoleName,?RoleName,?UserCredit,?Balance,?ResetCredit,?AgentID,?AgentUserName,?AgentRoleName,?AgentRoleID)";
        private const string SQL_UPDATE = "update yafa.agent set UserName=?UserName,Password=?Password,Name=?Name,Mobile=?Mobile,Email=?Email,Tel=?Tel,Status=?Status,SubCompany=?SubCompany,SCnumber=?SCnumber,Partner=?Partner,Pnumber=?Pnumber,GeneralAgent=?GeneralAgent,Ganumber=?Ganumber,Agents=?Agents,Agentsnumber=?Agentsnumber,MaxUser=?MaxUser,RoleId=?RoleId,SubAccount=?SubAccount,UpUserName=?UpUserName,UpUserID=?UpUserID,UpRoleId=?UpRoleId,RegistrationTime=?RegistrationTime,LastLoginTime=?LastLoginTime,LastLoginIP=?LastLoginIP,ItemMin=?ItemMin,ItemMax=?ItemMax,ItemsMax=?ItemsMax,UserLevel=?UserLevel,Coefficient=?Coefficient,Proportion=?Proportion,Area=?Area,Percent=?Percent,Credit=?Credit,CommissionA=?CommissionA,CommissionB=?CommissionB,CommissionC=?CommissionC,UpRoleName=?UpRoleName,RoleName=?RoleName,UserCredit=?UserCredit,Balance=?Balance,ResetCredit=?ResetCredit,AgentID=?AgentID,AgentUserName=?AgentUserName,AgentRoleName=?AgentRoleName,AgentRoleID=?AgentRoleID where ID = ?ID";
        private const string SQL_SELECTBYPK = "select * from yafa.agent  where agent.ID = ?ID";
        private const string SQL_SELECTALL = "select ID,UserName,Password,Name,Mobile,Email,Tel,Status,SubCompany,SCnumber,Partner,Pnumber,GeneralAgent,Ganumber,Agents,Agentsnumber,MaxUser,RoleId,SubAccount,UpUserName,UpUserID,UpRoleId,RegistrationTime,LastLoginTime,LastLoginIP,ItemMin,ItemMax,ItemsMax,UserLevel,Coefficient,Proportion,Area,Percent,Credit,CommissionA,CommissionB,CommissionC,UpRoleName,RoleName,UserCredit,Balance,ResetCredit,AgentID,AgentUserName,AgentRoleName,AgentRoleID from yafa.agent ";
        private const string SQL_DELETEBYPK = "delete  from yafa.agent  where agent.ID = ?ID";

        private const string SQL_UPDATE2 = "update yafa.agent set CommissionA=?CommissionA,CommissionB=?CommissionB,CommissionC=?CommissionC where ID = ?ID";
        private const string SQL_UPDATECREDIT = "update yafa.agent set Credit=?Credit,Balance=?Balance where ID = ?ID";
        private const string SQL_SELECTCOMMISSION = "select Max(CommissionA) as CommissionA,Max(CommissionB) as CommissionB,Max(CommissionC)as CommissionC from yafa.agent  where agent.UpUserID = ?UpUserID";
        private const string SQL_SELECTMINCREDIT = "select Sum(Credit) as Credit from yafa.agent  where agent.UpUserID = ?UpUserID";
        private const string SQL_SELECTMAXCREDIT = "select Credit as Credit from yafa.agent  where agent.ID = ?ID";

        private const string SQL_SELECTMINCREDITS = "select Sum(Credit) as Credit from yafa.agent  where agent.UpUserID = ?UpUserID and agent.ID<>?ID";
        private const string SQL_UPDATEUSERCREDIT = "update yafa.agent set UserCredit=?UserCredit where ID = ?ID";
        private const string SQL_SELECTBALANCE = "select Balance from yafa.agent  where agent.ID = ?ID";
        private const string SQL_SELECTUSERMINCREDIT = "select Sum(Credit) as Credit from yafa.user  where user.UpUserID = ?UpUserID";

        public MySqlDataReader GetBalance(string Id)
        {
            MySqlParameter[] patam = new MySqlParameter[]{
                new MySqlParameter("?ID",Id)
            };
            return MySqlHelper.ExecuteReader(SQL_SELECTBALANCE, patam);
        }

        public IList<Agent> GetAgentByupUsername(string upUsername)
        {
            string sql = "select * from agent where UpUserName=?UpUserName";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?UpUserName",upUsername)
            };
            return MySqlModelHelper<Agent>.GetObjectsBySql(sql, param);
        }

        #region xzz编写

        /// <summary>
        /// 更新代理子帐号角色名称
        /// </summary>
        /// <param name="RoleId">角色ID</param>
        /// <returns></returns>
        public int UpdateSubAccountRoleName(string roleName, int RoleId)
        {
            string sqlStr = "update agent set RoleName=?RoleName where SubAccount='1' and RoleId=?RoleId";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?RoleName",roleName),
                new MySqlParameter("?RoleId",RoleId)
            };
            return MySqlHelper.ExecuteNonQuery(sqlStr, param);
        }

        /// <summary>
        /// 返回userName所有上级数据（包括userName)
        /// </summary>
        /// <param name="userNames"></param>
        /// <returns></returns>
        public IList<Agent> GetAgentByUserNames(string userNames)
        {
            string sqlStr = "select * from agent where UserName in(" + userNames + ") order by ID desc";
            return MySqlModelHelper<Agent>.GetObjectsBySql(sqlStr, null);
        }

        public Agent GetAgentByUserName(string userName)
        {
            string sqlStr = "select * from agent where UserName=?UserName order by ID desc";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?UserName",userName)
            };
            return MySqlModelHelper<Agent>.GetSingleObjectBySql(sqlStr, param);
        }

        /// <summary>
        /// 判断代理子帐号是否存在(重复)
        /// </summary>
        /// <param name="agentUserName"></param>
        /// <returns></returns>
        public Agent IsExistSubAccount(string userName, string agentUserName)
        {
            string sqlStr = "select * from agent where UserName=?UserName";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?UserName",userName)
            };
            return MySqlModelHelper<Agent>.GetSingleObjectBySql(sqlStr, param);
        }

        /// <summary>
        /// 代理子帐号启用禁�?
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UpdateAgentStatus(string userName, int status)
        {
            string sqlStr = "Update agent set Status=?Status where UserName=?UserName";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?Status",status),
                new MySqlParameter("?userName",userName)
            };
            return MySqlHelper.ExecuteNonQuery(sqlStr, param) == 1;
        }
        /// <summary>
        /// 修改代理子帐�?
        /// </summary>
        /// <param name="RoleName"></param>
        /// <param name="RoleId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UpdateAgentSubAccount(string RoleName, int RoleId, string userName)
        {
            string sqlStr = "Update agent set RoleId=?RoleId,RoleName=?RoleName where UserName=?UserName";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?RoleId",RoleId),
                new MySqlParameter("?RoleName",RoleName),
                new MySqlParameter("?UserName",userName)
            };
            return MySqlHelper.ExecuteNonQuery(sqlStr, param) == 1;

        }

        /// <summary>
        /// 增加代理子帐�?
        /// By xzz 2010-11-26
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="Password"></param>
        /// <param name="RoleId"></param>
        /// <param name="RoleName"></param>
        /// <param name="AgentID"></param>
        /// <param name="AgentUserName"></param>
        /// <param name="AgentRoleName"></param>
        /// <param name="AgentRoleID"></param>
        /// <param name="UpUserName"></param>
        /// <param name="UpUserID"></param>
        /// <param name="UpRoleId"></param>
        /// <param name="UpRoleName"></param>
        /// <returns></returns>
        public int AddAgentSubAccount(string UserName, string Password, int Status, int RoleId, string RoleName, string SubAccount, int AgentID, string AgentUserName, string AgentRoleName,
            int AgentRoleID, DateTime RegistrationTime, string UpUserName, int UpUserID, int UpRoleId, string UpRoleName)
        {
            string sqlStr = "insert into agent(UserName,Password,Status,RoleId,RoleName,SubAccount,AgentID,AgentUserName,AgentRoleName,AgentRoleID,UpUserName,UpUserID,UpRoleId,RegistrationTime,UpRoleName) values(?UserName,md5(?Password),?Status,?RoleId,?RoleName,?SubAccount,?AgentID,?AgentUserName,?AgentRoleName,?AgentRoleID,?UpUserName,?UpUserID,?UpRoleId,?RegistrationTime,?UpRoleName);SELECT LAST_INSERT_ID()";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?UserName",UserName),
                new MySqlParameter("?Password",Password),
                new MySqlParameter("?Status",Status),
                new MySqlParameter("?RoleId",RoleId),
                new MySqlParameter("?RoleName",RoleName),
                new MySqlParameter("?SubAccount",SubAccount),
                new MySqlParameter("?AgentID",AgentID),
                new MySqlParameter("?AgentUserName",AgentUserName),
                new MySqlParameter("?AgentRoleName",AgentRoleName),
                new MySqlParameter("?AgentRoleID",AgentRoleID),
                new MySqlParameter("?UpUserName",UpUserName),
                new MySqlParameter("?UpUserID",UpUserID),
                new MySqlParameter("?UpRoleId",UpRoleId),
                new MySqlParameter("?RegistrationTime",RegistrationTime),
                new MySqlParameter("?UpRoleName",UpRoleName)
            };
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(sqlStr, param));
        }

        /// <summary>
        /// 返回代理子帐�?
        /// By xzz 2010-11-26
        /// </summary>
        /// <param name="agentUserName"></param>
        /// <returns></returns>
        public IList<Agent> GetSubAccount(string agentUserName)
        {
            string sqlStr = "select * from agent where SubAccount='1' and AgentUserName=?AgentUserName order by ID";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?AgentUserName",agentUserName)
            };
            return MySqlModelHelper<Agent>.GetObjectsBySql(sqlStr, param);
        }


        /// <summary>
        /// 根据角色返回代理子帐�?
        /// By xzz 2010-11-28
        /// </summary>
        /// <param name="agentUserName"></param>
        /// <returns></returns>
        public IList<Agent> GetSubAccountByRoleID(int roleID)
        {
            string sqlStr = "select * from agent where RoleId=?RoleId order by ID";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?RoleId",roleID)
            };
            return MySqlModelHelper<Agent>.GetObjectsBySql(sqlStr, param);
        }

        /// <summary>
        /// 验证代理帐号密码
        /// </summary>
        /// <param name="userName">帐号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public Agent GetAgentByUserName(string userName, string password)
        {
            string sqlStr = "select * from agent where UserName=?UserName and Password=md5(?Password) and Status=1";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?UserName",userName),
                new MySqlParameter("?Password",password)
            };
            return MySqlModelHelper<Agent>.GetSingleObjectBySql(sqlStr, param);
        }

        /// <summary>
        /// 更新使用信用�?
        /// By xzz 2010-11-16
        /// </summary>
        /// <param name="credit"></param>
        /// <returns></returns>
        public bool UpdateUserCredit(decimal credit, string userName)
        {
            string sqlStr = "Update agent set UserCredit=UserCredit+?credit where UserName=?userName";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?credit",credit),
                new MySqlParameter("?userName",userName),
            };
            return MySqlHelper.ExecuteNonQuery(sqlStr, param) > 0;
        }

        /// <summary>
        /// 更新重置信用设置（分公司�?
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UpdateResetCreditBySubCompany(string userName, string resetCredit)
        {
            string sqlStr = "Update agent set ResetCredit=?ResetCredit where UserName=?UserName or SubCompany=?SubCompany";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?ResetCredit",resetCredit),
                new MySqlParameter("?UserName",userName),
                new MySqlParameter("?SubCompany",userName)
            };
            return MySqlHelper.ExecuteNonQuery(sqlStr, param) > 0;
        }

        /// <summary>
        /// 更新重置信用设置（股东）
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UpdateResetCreditByPartner(string userName, string resetCredit)
        {
            string sqlStr = "Update agent set ResetCredit=?ResetCredit where UserName=?UserName or Partner=?Partner";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?ResetCredit",resetCredit),
                new MySqlParameter("?UserName",userName),
                new MySqlParameter("?Partner",userName)
            };
            return MySqlHelper.ExecuteNonQuery(sqlStr, param) > 0;
        }

        /// <summary>
        /// 更新重置信用设置（总代�?
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UpdateResetCreditByGeneralAgent(string userName, string resetCredit)
        {
            string sqlStr = "Update agent set ResetCredit=?ResetCredit where UserName=?UserName or GeneralAgent=?GeneralAgent";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?ResetCredit",resetCredit),
                new MySqlParameter("?UserName",userName),
                new MySqlParameter("?GeneralAgent",userName)
            };
            return MySqlHelper.ExecuteNonQuery(sqlStr, param) > 0;
        }

        /// <summary>
        /// 更新重置信用设置（代理）
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UpdateResetCreditByAgents(string userName, string resetCredit)
        {
            string sqlStr = "Update agent set ResetCredit=?ResetCredit where UserName=?UserName or Agents=?Agents";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?ResetCredit",resetCredit),
                new MySqlParameter("?UserName",userName),
                new MySqlParameter("?Agents",userName)
            };
            return MySqlHelper.ExecuteNonQuery(sqlStr, param) > 0;
        }

        /// <summary>
        /// 是否存在帐号
        /// By xzz 2010-11-8
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable IsExistUser(string userName)
        {
            string sqlStr = "select * from agent where UserName=?UserName";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?UserName",userName)
            };
            return MySqlHelper.ExecuteDataTable(sqlStr, param);
        }

        /// <summary>
        /// 更新占成
        /// By xzz
        /// 2010-10-6
        /// </summary>
        /// <param name="percent"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UpdatePercent(double percent, int ID)
        {
            string sqlStr = "Update agent set Percent=?Percent where ID=?ID";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?Percent",percent),
                new MySqlParameter("?ID",ID)
            };
            return MySqlHelper.ExecuteNonQuery(sqlStr, param) == 1;
        }

        /// <summary>
        /// 更新占成时更新会员所属占成
        /// </summary>
        /// <param name="upPercent">上级占成</param>
        /// <param name="percent">占成</param>
        /// <param name="roleID">角色ID</param>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public bool UpdatePercentAll(double upPercent, double percent, int roleID, string userName)
        {
            string sql = "";
            MySqlParameter[] param = null;
            switch (roleID)
            {
                case 2:
                    sql = "update user set SubCompanyPercent=?SubCompanyPercent where Partner=?Partner";
                    param = new MySqlParameter[]{
                        new MySqlParameter("?SubCompanyPercent",percent),
                        new MySqlParameter("?Partner",userName)
                    };
                    break;
                case 3:
                    sql = "update user set SubCompanyPercent=?SubCompanyPercent,PartnerPercent=?PartnerPercent where GeneralAgent=?GeneralAgent";
                    param = new MySqlParameter[]{
                        new MySqlParameter("?SubCompanyPercent",upPercent),
                        new MySqlParameter("?PartnerPercent",percent),
                        new MySqlParameter("?GeneralAgent",userName)
                    };
                    break;
                case 4:
                    sql = "update user set PartnerPercent=?PartnerPercent,GeneralAgentPercent=?GeneralAgentPercent where Agent=?Agent";
                    param = new MySqlParameter[]{
                        new MySqlParameter("?PartnerPercent",upPercent),
                        new MySqlParameter("?GeneralAgentPercent",percent),
                        new MySqlParameter("?Agent",userName)
                    };
                    break;
                case 5:
                    sql = "update user set GeneralAgentPercent=?GeneralAgentPercent,AgentPercent=?AgentPercent where Agent=?Agent";
                    param = new MySqlParameter[]{
                        new MySqlParameter("?GeneralAgentPercent",upPercent),
                        new MySqlParameter("?AgentPercent",percent),
                        new MySqlParameter("?Agent",userName)
                    };
                    break;
            }
            return MySqlHelper.ExecuteNonQuery(sql, param) > 0;
        }

        #endregion

        /// <summary>
        /// 返回最大占成数
        /// </summary>
        /// <param name="upUserName"></param>
        /// <returns></returns>
        public object GetMaxPercentByUserName(int ID)
        {
            string sqlStr = "select Max(Percent) as Percent from agent where UpUserID=?UpUserID";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?UpUserID",ID)
            };
            return MySqlHelper.ExecuteScalar(sqlStr, param);
        }

        /// <summary>
        /// 修改下级信用总和
        /// 编写时间: 2010-10-7 15:10
        /// 创建者：Mickey 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="credit"></param>
        /// <returns></returns>
        public bool updateUserCredit(string userId, string userCredit)
        {
            MySqlParameter[] param = new MySqlParameter[]{
			     new MySqlParameter("?UserCredit",userCredit),
				 new MySqlParameter("?ID",userId)
            };
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATEUSERCREDIT, param) > 0;
        }

        /// <summary>
        /// 获取除指定ID 以外的信用总和
        /// 编写时间: 2010-10-7 14:00
        /// 创建者：Mickey 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public MySqlDataReader GetCredits(string Id, string userId)
        {
            MySqlParameter[] patam = new MySqlParameter[]{
                new MySqlParameter("?ID",Id),
                new MySqlParameter("?UpUserID",userId)
            };
            return MySqlHelper.ExecuteReader(SQL_SELECTMINCREDITS, patam);
        }

        /// <summary>
        /// 获取上级信用之和[最大信]
        /// 编写时间: 2010-10-6 20:32
        /// 创建者：Mickey
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public MySqlDataReader GetMaxCredit(string Id)
        {
            MySqlParameter[] patam = new MySqlParameter[]{
                new MySqlParameter("?ID",Id)
            };
            return MySqlHelper.ExecuteReader(SQL_SELECTMAXCREDIT, patam);
        }

        /// <summary>
        /// 获取下级信用之和[最小信]
        /// 编写时间: 2010-10-6 14:20
        /// 创建者：Mickey
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public MySqlDataReader GetMinCredit(string roleId)
        {
            MySqlParameter[] patam = new MySqlParameter[]{
                new MySqlParameter("?UpUserID",roleId)
            };
            return MySqlHelper.ExecuteReader(SQL_SELECTMINCREDIT, patam);
        }

        public MySqlDataReader GetUserMinCredit(string upId)
        {
            MySqlParameter[] patam = new MySqlParameter[]{
                new MySqlParameter("?UpUserID",upId)
            };
            return MySqlHelper.ExecuteReader(SQL_SELECTUSERMINCREDIT, patam);
        }
        /// <summary>
        /// 修改信用
        /// 编写时间: 2010-10-6 14:10
        /// 创建者：Mickey 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="credit"></param>
        /// <returns></returns>
        public bool updateCredit(string id, string credit, decimal balance)
        {
            MySqlParameter[] param = new MySqlParameter[]{
			     new MySqlParameter("?Credit",credit),
                 new MySqlParameter("?Balance",balance),
				 new MySqlParameter("?ID",id)
            };
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATECREDIT, param) > 0;
        }

        /// <summary>
        /// 获取子集最大佣金A、B、C
        /// 编写时间: 2010-10-4 17:00
        /// 创建者：Mickey 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public MySqlDataReader GetRoleCommission(int upUserID)
        {
            MySqlParameter[] patam = new MySqlParameter[]{
                new MySqlParameter("?UpUserID",upUserID)
            };
            return MySqlHelper.ExecuteReader(SQL_SELECTCOMMISSION, patam);
        }

        public MySqlDataReader GetMaxCommissionByUser(int upUserID)
        {
            string sql="select Max(Commission) as CommissionA,0 as CommissionB,0 as CommissionC from yafa.user  where UpUserID = ?UpUserID";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?UpUserID",upUserID)
            };
            return MySqlHelper.ExecuteReader(sql, param);
        }

        /// <summary>
        /// 修改佣金方法
        /// 编写时间: 2010-10-3 20:00
        /// 创建者：Mickey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commissionA"></param>
        /// <param name="commissionB"></param>
        /// <param name="commissionC"></param>
        /// <returns></returns>
        public bool updateCommission(string id, string commissionA, string commissionB, string commissionC)
        {
            MySqlParameter[] param = new MySqlParameter[]{
			     new MySqlParameter("?CommissionA",commissionA),
				 new MySqlParameter("?CommissionB",commissionB),
				 new MySqlParameter("?CommissionC",commissionC),
				 new MySqlParameter("?ID",id)
            };
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE2, param) > 0;
        }

        /// <summary>
        /// 修改佣金时更新会员代理佣金
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public bool UpdateLowerCommission(int roleId, string userName, string commissionA)
        {
            string sqlStr = "update user ";
            switch (roleId)
            {
                case 2:
                    sqlStr += " set SubCompanyCommission=?commissionA where SubCompany=?userName";
                    break;
                case 3:
                    sqlStr += " set PartnerCommission=?commissionA where Partner=?userName";
                    break;
                case 4:
                    sqlStr += " set GeneralAgentCommission=?commissionA where GeneralAgent=?userName";
                    break;
                case 5:
                    sqlStr += " set AgentCommission=?commissionA where Agent=?userName";
                    break;
            }
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?commissionA",commissionA),
                new MySqlParameter("?userName",userName)
            };
            return MySqlHelper.ExecuteNonQuery(sqlStr, param) > 0;
        }

        /// <summary>
        /// 查询方法
        /// 编写时间: 2010-10-2 17:30:00
        /// 创建者：Mickey
        /// </summary>
        /// <returns></returns>
        public MySqlDataReader GetAgentAll()
        {
            return MySqlHelper.ExecuteReader(SQL_SELECTALL, null);
        }


        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失�?	
        ///生成时间�?010-11-24 19:15:21		
        ///</summary>		
        public Boolean AddAgent(Agent agent)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",agent.UserName),
				 new MySqlParameter("?Password",agent.Password),
				 new MySqlParameter("?Name",agent.Name),
				 new MySqlParameter("?Mobile",agent.Mobile),
				 new MySqlParameter("?Email",agent.Email),
				 new MySqlParameter("?Tel",agent.Tel),
				 new MySqlParameter("?Status",agent.Status),
				 new MySqlParameter("?SubCompany",agent.SubCompany),
				 new MySqlParameter("?SCnumber",agent.SCnumber),
				 new MySqlParameter("?Partner",agent.Partner),
				 new MySqlParameter("?Pnumber",agent.Pnumber),
				 new MySqlParameter("?GeneralAgent",agent.GeneralAgent),
				 new MySqlParameter("?Ganumber",agent.Ganumber),
				 new MySqlParameter("?Agents",agent.Agents),
				 new MySqlParameter("?Agentsnumber",agent.Agentsnumber),
				 new MySqlParameter("?MaxUser",agent.MaxUser),
				 new MySqlParameter("?RoleId",agent.RoleId),
				 new MySqlParameter("?SubAccount",agent.SubAccount),
				 new MySqlParameter("?UpUserName",agent.UpUserName),
				 new MySqlParameter("?UpUserID",agent.UpUserID),
				 new MySqlParameter("?UpRoleId",agent.UpRoleId),
				 new MySqlParameter("?RegistrationTime",agent.RegistrationTime),
				 new MySqlParameter("?LastLoginTime",agent.LastLoginTime),
				 new MySqlParameter("?LastLoginIP",agent.LastLoginIP),
				 new MySqlParameter("?ItemMin",agent.ItemMin),
				 new MySqlParameter("?ItemMax",agent.ItemMax),
				 new MySqlParameter("?ItemsMax",agent.ItemsMax),
				 new MySqlParameter("?UserLevel",agent.UserLevel),
				 new MySqlParameter("?Coefficient",agent.Coefficient),
				 new MySqlParameter("?Proportion",agent.Proportion),
				 new MySqlParameter("?Area",agent.Area),
				 new MySqlParameter("?Percent",agent.Percent),
				 new MySqlParameter("?Credit",agent.Credit),
				 new MySqlParameter("?CommissionA",agent.CommissionA),
				 new MySqlParameter("?CommissionB",agent.CommissionB),
				 new MySqlParameter("?CommissionC",agent.CommissionC),
				 new MySqlParameter("?UpRoleName",agent.UpRoleName),
				 new MySqlParameter("?RoleName",agent.RoleName),
				 new MySqlParameter("?UserCredit",agent.UserCredit),
				 new MySqlParameter("?Balance",agent.Balance),
				 new MySqlParameter("?ResetCredit",agent.ResetCredit),
				 new MySqlParameter("?AgentID",agent.AgentID),
				 new MySqlParameter("?AgentUserName",agent.AgentUserName),
				 new MySqlParameter("?AgentRoleName",agent.AgentRoleName),
				 new MySqlParameter("?AgentRoleID",agent.AgentRoleID)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失�?	
        ///生成时间�?010-11-24 19:15:21		
        ///</summary>		
        public Boolean UpdateAgent(Agent agent)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",agent.UserName),
				 new MySqlParameter("?Password",agent.Password),
				 new MySqlParameter("?Name",agent.Name),
				 new MySqlParameter("?Mobile",agent.Mobile),
				 new MySqlParameter("?Email",agent.Email),
				 new MySqlParameter("?Tel",agent.Tel),
				 new MySqlParameter("?Status",agent.Status),
				 new MySqlParameter("?SubCompany",agent.SubCompany),
				 new MySqlParameter("?SCnumber",agent.SCnumber),
				 new MySqlParameter("?Partner",agent.Partner),
				 new MySqlParameter("?Pnumber",agent.Pnumber),
				 new MySqlParameter("?GeneralAgent",agent.GeneralAgent),
				 new MySqlParameter("?Ganumber",agent.Ganumber),
				 new MySqlParameter("?Agents",agent.Agents),
				 new MySqlParameter("?Agentsnumber",agent.Agentsnumber),
				 new MySqlParameter("?MaxUser",agent.MaxUser),
				 new MySqlParameter("?RoleId",agent.RoleId),
				 new MySqlParameter("?SubAccount",agent.SubAccount),
				 new MySqlParameter("?UpUserName",agent.UpUserName),
				 new MySqlParameter("?UpUserID",agent.UpUserID),
				 new MySqlParameter("?UpRoleId",agent.UpRoleId),
				 new MySqlParameter("?RegistrationTime",agent.RegistrationTime),
				 new MySqlParameter("?LastLoginTime",agent.LastLoginTime),
				 new MySqlParameter("?LastLoginIP",agent.LastLoginIP),
				 new MySqlParameter("?ItemMin",agent.ItemMin),
				 new MySqlParameter("?ItemMax",agent.ItemMax),
				 new MySqlParameter("?ItemsMax",agent.ItemsMax),
				 new MySqlParameter("?UserLevel",agent.UserLevel),
				 new MySqlParameter("?Coefficient",agent.Coefficient),
				 new MySqlParameter("?Proportion",agent.Proportion),
				 new MySqlParameter("?Area",agent.Area),
				 new MySqlParameter("?Percent",agent.Percent),
				 new MySqlParameter("?Credit",agent.Credit),
				 new MySqlParameter("?CommissionA",agent.CommissionA),
				 new MySqlParameter("?CommissionB",agent.CommissionB),
				 new MySqlParameter("?CommissionC",agent.CommissionC),
				 new MySqlParameter("?UpRoleName",agent.UpRoleName),
				 new MySqlParameter("?RoleName",agent.RoleName),
				 new MySqlParameter("?UserCredit",agent.UserCredit),
				 new MySqlParameter("?Balance",agent.Balance),
				 new MySqlParameter("?ResetCredit",agent.ResetCredit),
				 new MySqlParameter("?AgentID",agent.AgentID),
				 new MySqlParameter("?AgentUserName",agent.AgentUserName),
				 new MySqlParameter("?AgentRoleName",agent.AgentRoleName),
				 new MySqlParameter("?AgentRoleID",agent.AgentRoleID),
				 new MySqlParameter("?ID",agent.ID)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失�?	
        ///生成时间�?010-11-24 19:15:21		
        ///</summary>		
        public Boolean DeleteAgentByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间�?010-11-24 19:15:21		
        ///</summary>		
        public Agent GetAgentByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

            return MySqlModelHelper<Agent>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间�?010-11-24 19:15:21		
        ///</summary>		
        public IList<Agent> GetMutilILAgent()
        {
            return MySqlModelHelper<Agent>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间�?010-11-24 19:15:21		
        ///</summary>		
        public DataTable GetMutilDTAgent()
        {
            return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion 

        /// <summary>
        /// 更新代理密码
        ///create by 肖军�?
        ///create date 2010-09-28
        /// </summary>
        /// <param name="pass">密码</param>
        /// <param name="userName">账户名称</param>
        /// <returns></returns>
        public bool UpdatePass(string pass, string userName)
        {
            string SQL_UPDATEPASS = "update yafa.agent set Password=md5(?pass) where UserName=?userName"; 
            MySqlParameter[] parameter = new MySqlParameter[] { 
              new MySqlParameter("?pass",pass),
              new MySqlParameter("?userName",userName)
            };
            try
            {
                return MySqlHelper.ExecuteNonQuery(SQL_UPDATEPASS, parameter) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        /// <summary>
        /// create by 肖军�?
        /// create date 2010-09-29
        /// 新增代理信息
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        public int AddAgentUser(Agent agent)
        {
            string SQL_INSERTAGENT = "insert into yafa.agent (UserName,Password,Name,Mobile,Email,Tel,Status,SubCompany,SCnumber,Partner,Pnumber,GeneralAgent,Ganumber,Agents,Agentsnumber,MaxUser,RoleId,SubAccount,UpUserName,UpUserID,UpRoleId,RegistrationTime,LastLoginTime,LastLoginIP,ItemMin,ItemMax,ItemsMax,UserLevel,Coefficient,Proportion,Area,Percent,Credit,CommissionA,CommissionB,CommissionC,UpRoleName,RoleName,ResetCredit,balance,MoneyType,Currency,parentcode)values(?UserName,md5(?Password),?Name,?Mobile,?Email,?Tel,?Status,?SubCompany,?SCnumber,?Partner,?Pnumber,?GeneralAgent,?Ganumber,?Agents,?Agentsnumber,?MaxUser,?RoleId,?SubAccount,?UpUserName,?UpUserID,?UpRoleId,?RegistrationTime,?LastLoginTime,?LastLoginIP,?ItemMin,?ItemMax,?ItemsMax,?UserLevel,?Coefficient,?Proportion,?Area,?Percent,?Credit,?CommissionA,?CommissionB,?CommissionC,?UpRoleName,?RoleName,?ResetCredit,?balance,?MoneyType,?Currency,?parentcode);SELECT LAST_INSERT_ID();";
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",agent.UserName),
				 new MySqlParameter("?Password",agent.Password),
				 new MySqlParameter("?Name",agent.Name),
				 new MySqlParameter("?Mobile",agent.Mobile),
				 new MySqlParameter("?Email",agent.Email),
				 new MySqlParameter("?Tel",agent.Tel),
				 new MySqlParameter("?Status",agent.Status),
				 new MySqlParameter("?SubCompany",agent.SubCompany),
				 new MySqlParameter("?SCnumber",agent.SCnumber),
				 new MySqlParameter("?Partner",agent.Partner),
				 new MySqlParameter("?Pnumber",agent.Pnumber),
				 new MySqlParameter("?GeneralAgent",agent.GeneralAgent),
				 new MySqlParameter("?Ganumber",agent.Ganumber),
				 new MySqlParameter("?Agents",agent.Agents),
				 new MySqlParameter("?Agentsnumber",agent.Agentsnumber),
				 new MySqlParameter("?MaxUser",agent.MaxUser),
				 new MySqlParameter("?RoleId",agent.RoleId),
				 new MySqlParameter("?SubAccount",agent.SubAccount),
				 new MySqlParameter("?UpUserName",agent.UpUserName),
				 new MySqlParameter("?UpUserID",agent.UpUserID),
				 new MySqlParameter("?UpRoleId",agent.UpRoleId),
				 new MySqlParameter("?RegistrationTime",agent.RegistrationTime),
				 new MySqlParameter("?LastLoginTime",agent.LastLoginTime),
				 new MySqlParameter("?LastLoginIP",agent.LastLoginIP),
				 new MySqlParameter("?ItemMin",agent.ItemMin),
				 new MySqlParameter("?ItemMax",agent.ItemMax),
				 new MySqlParameter("?ItemsMax",agent.ItemsMax),
				 new MySqlParameter("?UserLevel",agent.UserLevel),
				 new MySqlParameter("?Coefficient",agent.Coefficient),
				 new MySqlParameter("?Proportion",agent.Proportion),
				 new MySqlParameter("?Area",agent.Area),
				 new MySqlParameter("?Percent",agent.Percent),
				 new MySqlParameter("?Credit",agent.Credit),
				 new MySqlParameter("?CommissionA",agent.CommissionA),
				 new MySqlParameter("?CommissionB",agent.CommissionB),
				 new MySqlParameter("?CommissionC",agent.CommissionC),
				 new MySqlParameter("?UpRoleName",agent.UpRoleName),
                 new MySqlParameter("?RoleName",agent.RoleName),
                 new MySqlParameter("?ResetCredit",agent.ResetCredit),
                 new MySqlParameter("?balance",agent.Balance),
                 new MySqlParameter("?MoneyType",agent.MoneyType),
                 new MySqlParameter("?Currency",agent.Currency),
                 new MySqlParameter("?parentcode",agent.ParentCode)
			};
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(SQL_INSERTAGENT, param));
        }

        /// <summary>
        /// 获取所有除了分公司和会员之外总的记录�?
        /// create by 肖军�?
        /// create date 2010-09-29
        /// </summary>
        /// <returns></returns>
        public  int GetAgentAcount(string upUserName, string userName, string status) 
        {
            string SQL_SELECTACOUNT = "select count(*) from yafa.agent where upUserName=?upUserName";
            MySqlParameter[] parameter = new MySqlParameter[] { 
                new MySqlParameter("?upUserName",upUserName) 
            };
            if (userName != "")
            {
                SQL_SELECTACOUNT += " and userName='" + userName + "'"; 
            }
            if (status != "")
            {
                SQL_SELECTACOUNT += " and  status='" + status + "'";
            }
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(SQL_SELECTACOUNT, parameter));
        }

        /// <summary>
        /// 获取最顶级代理的记录数(即所有分公司的记录数)
        /// create by 肖军�?
        /// create date 2010-10-02
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userName"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int GetAgentAcount(string moneyType, int roleId, string userName, string status)
        {
            string SQL_SELECTACOUNT;
            MySqlParameter[] parameter;
            if (string.IsNullOrEmpty(moneyType))
            {
                SQL_SELECTACOUNT = "select count(*) from yafa.agent where roleId=?roleId";
                parameter = new MySqlParameter[] { 
                new MySqlParameter("?roleId",roleId) 
                };
            }
            else
            {
                SQL_SELECTACOUNT = "select count(*) from yafa.agent where roleId=?roleId and MoneyType=?MoneyType";
                parameter = new MySqlParameter[] { 
                new MySqlParameter("?roleId",roleId),
                new MySqlParameter("?MoneyType",moneyType)
                };
            }

            if (userName != "")
            {
                SQL_SELECTACOUNT += " and userName='" + userName + "'";
            }
            if (status != "")
            {
                SQL_SELECTACOUNT += " and  status='" + status + "'";
            }
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(SQL_SELECTACOUNT,parameter));
        }

         
         
        /// <summary>
        /// 更新代理的基本信�?
        /// create by 肖军�?
        /// create date 2010-09-29
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tel"></param>
        /// <param name="mobile"></param>
        /// <param name="status"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UpdateAgentByUserName(string name, string tel, string mobile, string status, string userName)
        {
            string SQL_UPDATEUSERBYUSERNAME = "update yafa.agent set name=?name,tel=?tel,mobile=?mobile,status=?status where userName=?userName";
            MySqlParameter[] parameter = new MySqlParameter[]{
               new MySqlParameter("?name",name),
               new MySqlParameter("?tel",tel),
               new MySqlParameter("?mobile",mobile),
               new MySqlParameter("?status",status),
               new MySqlParameter("?userName",userName)
            };
            try
            {
                return MySqlHelper.ExecuteNonQuery(SQL_UPDATEUSERBYUSERNAME, parameter) > 0;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (InvalidExpressionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 更新代理人数
        /// create by 肖军�?
        /// create date 2010-09-29
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool UpdateAgentNumber(int userId, int roleId)
        {
            string SQL_UPDATEAGENTNUNMBER = "update yafa.agent set Agentsnumber=Agentsnumber+1 where ID=?userId";
            if (roleId != 2)
            {
                MySqlParameter[] parameter = new MySqlParameter[] { 
                  new MySqlParameter("?userId",userId)
                };
                return MySqlHelper.ExecuteNonQuery(SQL_UPDATEAGENTNUNMBER, parameter) > 0;
            }
            return false;
        }
        /// <summary>
        /// 查询代理信息，分�?
        ///create by 肖军�?
        ///create date 2010-09-28
        /// update by 肖军�?
        /// update content 由于之前忽略了一些条件故增加了以下的一些if条件判断
        /// update date 2010-10-01
        /// </summary>
        /// <param name="upUserName">上级归属</param>
        /// <param name="userName">账户名称</param>
        /// <param name="status">状�?/param>
        /// <param name="limitStart">索引开�?/param>
        /// <param name="limitEnd">索引结束</param>
        /// <returns></returns>
        public IList<Agent> GetAgents(string upUserName, string userName, string status, int limitStart, int limitEnd)
        {
            string SQL_SELECTBYCONDITION = "select * from yafa.agent where upUserName=?upUserName and SubAccount='0' "; 
            MySqlParameter[] parameter = new MySqlParameter[] { 
                new MySqlParameter("?upUserName",upUserName), 
                new MySqlParameter("?limitStart",limitStart),
                new MySqlParameter("?limitEnd",limitEnd)
            };  
            if(userName!="")
            {
                SQL_SELECTBYCONDITION += " and userName='"+userName+"'"; 
            }
            if(status!="")
            {
                SQL_SELECTBYCONDITION += " and  status='"+status+"'";  
            }
            SQL_SELECTBYCONDITION += " order by ID desc";
              SQL_SELECTBYCONDITION += " limit ?limitStart,?limitEnd";
              
            try
            {
                return MySqlModelHelper<Agent>.GetObjectsBySql(SQL_SELECTBYCONDITION, parameter);
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 查询最顶级的代理信�?即分公司的信�?
        /// create by 肖军�?
        ///  create date 2010-10-01
        /// update by 肖军�?
        /// update content 由于之前忽略了一些条件故增加了以下的一些if条件判断
        /// update date 2010-10-01
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userName"></param>
        /// <param name="status"></param>
        /// <param name="limitStart"></param>
        /// <param name="limitEnd"></param>
        /// <returns></returns>
        public IList<Agent> GetAgents(string moneyType, int roleId, string userName, string status, int limitStart, int limitEnd)
        {
            string SQL_SELECTAGENTS;
            MySqlParameter[] parameter;
            if (string.IsNullOrEmpty(moneyType))
            {
                SQL_SELECTAGENTS = "select * from yafa.agent where 1=1 and roleId=?roleId";
                parameter = new MySqlParameter[] { 
                new MySqlParameter("?roleId",roleId), 
                new MySqlParameter("?limitStart",limitStart),
                new MySqlParameter("?limitEnd",limitEnd)
                };
            }
            else
            {
                //SQL_SELECTAGENTS = "select * from yafa.agent where 1=1 and roleId=?roleId and MoneyType=?MoneyType";
                SQL_SELECTAGENTS = "select * from yafa.agent where 1=1 and roleId=?roleId ";
                parameter = new MySqlParameter[] { 
                new MySqlParameter("?roleId",roleId), 
                new MySqlParameter("?MoneyType",moneyType),
                new MySqlParameter("?limitStart",limitStart),
                new MySqlParameter("?limitEnd",limitEnd)
                };
            }

            if(userName!="")
            {
                SQL_SELECTAGENTS += " and userName='" + userName + "'";
            }
            if(status!="")
            {
                SQL_SELECTAGENTS += " and status='" + status + "'";
            }
            SQL_SELECTAGENTS += " order by ID desc ";
            SQL_SELECTAGENTS += " limit ?limitStart,?limitEnd";
            try
            {
                return MySqlModelHelper<Agent>.GetObjectsBySql(SQL_SELECTAGENTS, parameter);
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #region 编写�?李毅
        public string GetNextLevel(int id)
        {
            string str = "select min(ItemMin) as ItemMin,max(ItemMax) as ItemMax,max(ItemsMax) as ItemsMax from agent where UpUserID=?id";
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?id",id)
            };
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str, param));
        }
        public string GetNextAndUpLevel(int id,int roleid)
        {
            string str = "select (select ItemMin from agent where ID in (select UpUserID from agent where ID=?id)) as upItemMin,(select ItemMax from agent where ID in (select UpUserID from agent where ID=?id)) as upItemMax,(select ItemsMax from agent where ID in (select UpUserID from agent where ID=?id)) as upItemsMax,min(ItemMin) as ItemMin,max(ItemMax) as ItemMax,max(ItemsMax) as ItemsMax from "+(roleid == 5?"user":"agent")+" where UpUserID=?id";
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?id",id)
            };
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str, param));
        }

        public string GetUpLevel(int id)
        {
            string str = "select (select ItemMin from agent where ID in (select UpUserID from user where ID=?id)) as upItemMin,(select ItemMax from agent where ID in (select UpUserID from user where ID=?id)) as upItemMax,(select ItemsMax from agent where ID in (select UpUserID from user where ID=?id)) as upItemsMax";
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?id",id)
            };
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str, param));
        }

        public List<string> GetNextAndUpLevelToList(int id,int roleid)
        {
            string str = "select (case when (select ItemMin from agent where ID in (select UpUserID from agent where ID=?id)) is null then 0"
            + " else (select ItemMin from agent where ID in (select UpUserID from agent where ID=?id)) end) as upItemMin,"
            + "(case when (select ItemMax from agent where ID in (select UpUserID from agent where ID=?id)) is null then 0 else "
            + "(select ItemMax from agent where ID in (select UpUserID from agent where ID=?id)) end) as upItemMax,"
            + "(case when (select ItemsMax from agent where ID in (select UpUserID from agent where ID=?id)) is null then 0 else "
            + "(select ItemsMax from agent where ID in (select UpUserID from agent where ID=?id)) end) as upItemsMax,"
            + "(case when min(ItemMin) is null then 0 else min(ItemMin) end) as ItemMin,"
            + "(case when max(ItemMax) is null then 0 else max(ItemMax) end) as ItemMax,"
            + "(case when max(ItemsMax) is null then 0 else max(ItemsMax) end) as ItemsMax from "+(roleid==5?"user":"agent")+" where UpUserID=?id";
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?id",id)
            };
            List<string> tz = new List<string>();
            MySqlDataReader read = MySqlHelper.ExecuteReader(str, param);
            while (read.Read())
            {
                tz.Add(read.GetString("upItemMin"));
                tz.Add(read.GetString("upItemMax"));
                tz.Add(read.GetString("upItemsMax"));
                tz.Add(read.GetString("ItemMin"));
                tz.Add(read.GetString("ItemMax"));
                tz.Add(read.GetString("ItemsMax"));
            }
            return tz;
        }

        public List<string> GetNextAndUpLevelToList1(int id)
        {
            string str = "select  (case when min(ItemMin) is null then 0 else min(ItemMin) end) as ItemMin,(case when max(ItemMax) "
            + " is null then 0 else max(ItemMax) end) as ItemMax, (case when max(ItemsMax) is null then 0 else max(ItemsMax) end) as"
            + " ItemsMax from agent where UpUserID=?id";
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?id",id)
            };
            List<string> tz = new List<string>();
            MySqlDataReader read = MySqlHelper.ExecuteReader(str, param);
            while (read.Read())
            {
                tz.Add(read.GetString("ItemMin"));
                tz.Add(read.GetString("ItemMax"));
                tz.Add(read.GetString("ItemsMax"));
            }
            return tz;
        }

        public List<string> GetNextAndUpLevelToList2(int id)
        {
            string str = "select (case when (select ItemMin from agent where ID in (select UpUserID from user where ID=?id)) is null then 0 else "
            + "(select ItemMin from agent where ID in (select UpUserID from user where ID=?id)) end) as upItemMin,"
            + "(case when (select ItemMax from agent where ID in (select UpUserID from user where ID=?id)) is null then 0 else "
            + " (select ItemMax from agent where ID in (select UpUserID from user where ID=?id)) end) as upItemMax,"
            + "(case when (select ItemsMax from agent where ID in (select UpUserID from user where ID=?id)) is null then 0 else "
            + " (select ItemsMax from agent where ID in (select UpUserID from user where ID=?id)) end) as upItemsMax";
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?id",id)
            };
            List<string> tz = new List<string>();
            MySqlDataReader read = MySqlHelper.ExecuteReader(str, param);
            while (read.Read())
            {
                tz.Add(read.GetString("upItemMin"));
                tz.Add(read.GetString("upItemMax"));
                tz.Add(read.GetString("upItemsMax"));
            }
            return tz;
        }

        public string update(int id, int min, int max, int onemax)
        {
            string str = "update agent set ItemMin=?min,ItemMax=?max,ItemsMax=?onemax where ID=?id";
            MySqlParameter[] para = new MySqlParameter[] { 
                new MySqlParameter("?min",min),
                new MySqlParameter("?max",max),
                new MySqlParameter("?onemax",onemax),
                new MySqlParameter("?id",id)
            };
            return MySqlHelper.ExecuteNonQuery(str, para).ToString();
        }

        public string updateUser(int id, int min, int max, int onemax)
        {
            string str = "update user set ItemMin=?min,ItemMax=?max,ItemsMax=?onemax where ID=?id";
            MySqlParameter[] para = new MySqlParameter[] { 
                new MySqlParameter("?min",min),
                new MySqlParameter("?max",max),
                new MySqlParameter("?onemax",onemax),
                new MySqlParameter("?id",id)
            };
            return MySqlHelper.ExecuteNonQuery(str, para).ToString();
        }

        /*---------------会员注单------------*/

        public string getAgent(int id,int roid,int IDex,int IDexC)
        {
            string str = "";
            string array = "";
            List<string> cols = new List<string>();
            cols.Add("SubCompany");
            cols.Add("Partner");
            cols.Add("ZAgent");
            cols.Add("Agent");
            cols.Add("UserName");
            List<string> lid = new List<string>();
            List<string> lna = new List<string>();
            if (roid != 6)
            {
                str = "select ID,UserName from agent where RoleId=?roid and UpUserID=?id limit " + IDex + "," + IDexC;
            }
            else
            {
                str = "select ID,UserName from user where RoleId=?roid and UpUserID=?id limit " + IDex + "," + IDexC;
            }
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?roid",roid),
                new MySqlParameter("?id",id)
            };

            MySqlDataReader read = MySqlHelper.ExecuteReader(str, param);
            array = "[";
            while (read.Read())
            {
                //array += "[";
                //array += "'"+read.GetString("ID")+"',";
                //array += "'"+read.GetString("UserName")+"'";
                //array += "]";
                //array += ",";
                lid.Add(read.GetString("ID"));
                lna.Add(read.GetString("UserName"));
            }
            read.Close();
            read = null;
            string s = "";
            for (int i = 0; i < lid.Count; i++)
            {
                s = "select (case when (select sum(ValidAmount) from orderall where " + cols[roid - 2] + "='" + lna[i] + "') is null then '0' "
                + "else (select sum(ValidAmount) from orderall where " + cols[roid - 2] + "='" + lna[i] + "') end) as hy,"
    + "(case when (select sum(ValidAmount * AgentPercent) from orderall where " + cols[roid - 2] + "='" + lna[i] + "') is null then '0' "
                + "else (select sum(ValidAmount * AgentPercent) from orderall where " + cols[roid - 2] + "='" + lna[i] + "') end) as dl,"
    + "(case when (select sum(ValidAmount * ZAgentPercent) from orderall where " + cols[roid - 2] + "='" + lna[i] + "') is null then '0' "
                + "else (select sum(ValidAmount * ZAgentPercent) from orderall where " + cols[roid - 2] + "='" + lna[i] + "') end) as zd,"
    + "(case when (select sum(ValidAmount * PartnerPercent) from orderall where " + cols[roid - 2] + "='" + lna[i] + "') is null then '0' "
                + "else (select sum(ValidAmount * PartnerPercent) from orderall where " + cols[roid - 2] + "='" + lna[i] + "') end) as gd,"
    + "(case when (select sum(ValidAmount * SubCompanyPercent) from orderall where " + cols[roid - 2] + "='" + lna[i] + "') is null then '0' "
                + "else (select sum(ValidAmount * SubCompanyPercent) from orderall where " + cols[roid - 2] + "='" + lna[i] + "') end) as fgs,"
    + "(case when (select sum(ValidAmount * CompanyPercent) from orderall where " + cols[roid - 2] + "='" + lna[i] + "') is null then '0' "
                + "else (select sum(ValidAmount * CompanyPercent) from orderall where " + cols[roid - 2] + "='" + lna[i] + "') end) as gs";
                read = MySqlHelper.ExecuteReader(s);
                while (read.Read())
                {
                    array += "[";
                    array += "'" + lid[i] + "',";
                    array += "'" + lna[i] + "',";
                    array += "'" + read.GetString("hy") + "',";
                    array += "'" + read.GetString("dl") + "',";
                    array += "'" + read.GetString("zd") + "',";
                    array += "'" + read.GetString("gd") + "',";
                    array += "'" + read.GetString("fgs") + "',";
                    array += "'" + read.GetString("gs") + "'";
                    array += "]";
                }
                array += ",";
                read.Close();
                read = null;
            }
            if (array != "[")
            {
                array = array.Substring(0, array.Length - 1);
            }
            array += "]";
            return array;
        }

        public string getorder(string un, string lg, int IDex, int IDexC)
        {
            string array = "";
            string str = "select * from orderall where UserName=?un limit " + IDex + "," + IDexC;
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?un",un)
            };
            MySqlDataReader read = MySqlHelper.ExecuteReader(str, param);
            array = "[";
            while (read.Read())
            {
                array += "[";
                array += "'" + read.GetString("BetType") + "',";//0
                array += "'" + read.GetString("UserName") + "',";//1
                array += "'" + read.GetString("OrderID") + "',";//2
                array += "'" + read.GetString("time") + "',";//3
                array += "'" + read.GetString("Home"+lg) + "',";//4
                array += "'" + read.GetString("Away"+lg) + "',";//5
                array += "'" + read.GetString("league"+lg) + "',";//6
                array += "'" + read.GetString("Score") + "',";//7
                array += "'" + read.GetString("BetItem") + "',";//8
                array += "'" + read.GetString("BeginTime") + "',";//9
                array += "'" + read.GetString("Handicap") + "',";//10
                array += "'" + read.GetString("OddsType") + "',";//11
                array += "'" + read.GetString("Odds") + "',";//12
                array += "'" + read.GetString("Amount") + "',";//13
                array += "'" + read.GetString("ValidAmount") + "',";//14
                array += "'" + read.GetString("AgentPercent") + "',";//15
                array += "'" + read.GetString("ZAgentPercent") + "',";//16
                array += "'" + read.GetString("PartnerPercent") + "',";//17
                array += "'" + read.GetString("SubCompanyPercent") + "',";//18
                array += "'" + read.GetString("WebSiteiID") + "',";//19
                array += "'" + read.GetString("IP") + "',";//20
                array += "'" + read.GetString("Status") + "'";//21
                array += "]";
                array += ",";
            }
            if (array != "[")
            {
                array = array.Substring(0, array.Length - 1);
            }
            array += "]";
            return array;
        }

        /*---------------会员注单结束------------*/

        #endregion

        /// <summary>
        /// 返回代理加盟注册资料
        /// </summary>
        /// <param name="username"></param>
        /// <param name="name"></param>
        /// <param name="subtime1"></param>
        /// <param name="subtime2"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string GetJoinerByWhere(string username, string name, string subtime1, string subtime2, string status)
        {
            string sql = "";
            string substr = "";
            if (!string.IsNullOrEmpty(username))
            {
                substr += " and username='" + username + "' ";
            }
            if (!string.IsNullOrEmpty(name))
            {
                substr += " and name='" + name + "' ";
            }
            if (!string.IsNullOrEmpty(subtime1) && !string.IsNullOrEmpty(subtime2))
            {
                substr += " and date(subtime)>='" + subtime1 + "' and date(subtime)<='" + subtime2 + "' ";
            }
            if (!string.IsNullOrEmpty(status))
            {
                substr += " and status='" + status + "' ";
            }
            if (substr == "")
            {
                return "";
            }
            sql = "select * from joiner where 1=1 " + substr + " order by ID desc";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sql));
        }

        /// <summary>
        /// 更新代理加盟
        /// </summary>
        /// <returns></returns>
        public static bool UpdateJoiner(string username, string password, string question, string answer, string email,
            string tel, string qq, string country, string province, string city, string cardno, string bankname, string bank,
            string ghbndk, string branch, string name, string url, string status, int ID)
        {
            string sql = "update joiner set times=@times,username=@username,password=@password,question=@question,answer=@answer,email=@email,tel=@tel,qq=@qq,country=@country,province=@province,city=@city,cardno=@cardno,bankname=@bankname,bank=@bank,ghbndk=@ghbndk,branch=@branch,name=@name,url=@url,status=@status where ID=@ID";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@times",DateTime.Now),
                new MySqlParameter("@username",username),
                new MySqlParameter("@password",password),
                new MySqlParameter("@question",question),
                new MySqlParameter("@answer",answer),
                new MySqlParameter("@email",email),
                new MySqlParameter("@tel",tel),
                new MySqlParameter("@qq",qq),
                new MySqlParameter("@country",country),
                new MySqlParameter("@province",province),
                new MySqlParameter("@city",city),
                new MySqlParameter("@cardno",cardno),
                new MySqlParameter("@bankname",bankname),
                new MySqlParameter("@bank",bank),
                new MySqlParameter("@ghbndk",ghbndk),
                new MySqlParameter("@branch",branch),
                new MySqlParameter("@name",name),
                new MySqlParameter("@url",url),
                new MySqlParameter("@status",status),
                new MySqlParameter("@ID",ID)
            };
            return MySqlHelper.ExecuteNonQuery(sql, param) > 0;
        }

        /// <summary>
        /// 更新代理余额
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool UpdateAmount(decimal amount,int ID)
        {
            string sql = "update agent set amount=amount+@amount where ID=@ID";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@amount",amount),
                new MySqlParameter("@ID",ID)
            };
            return MySqlHelper.ExecuteNonQuery(sql, param) > 0;
        }

        /// <summary>
        /// 根据股东返回总代
        /// </summary>
        /// <param name="partner"></param>
        /// <returns></returns>
        public static IList<Agent> GetAgentByPartner(string partner)
        {
            string sql = "select * from agent where partner=@partner and RoleId=4";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@partner",partner)
            };
            return MySqlModelHelper<Agent>.GetObjectsBySql(sql, param);
        }
    }
}
