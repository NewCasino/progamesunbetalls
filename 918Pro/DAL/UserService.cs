using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
using Util;
namespace DAL
{
    public class UserService
    {
        //private const string SQL_INSERT = "insert into user (UserName,Password,Name,Mobile,Currency,Email,Tel,Status,CompanyPercent,CompanyCommission,SubCompany,SubCompanyPercent,SubCompanyCommission,Partner,PartnerPercent,PartnerCommission,GeneralAgent,GeneralAgentPercent,GeneralAgentCommission,Agent,AgentPercent,AgentCommission,Percent,Commission,Credit,IsReport,MaxUser,Plate,RoleId,SubAccount,RegistrationTime,LastLoginTime,LastLoginIP,UpUserName,UpUserID,UpRoleId)values(?UserName,?Password,?Name,?Mobile,?Currency,?Email,?Tel,?Status,?CompanyPercent,?CompanyCommission,?SubCompany,?SubCompanyPercent,?SubCompanyCommission,?Partner,?PartnerPercent,?PartnerCommission,?GeneralAgent,?GeneralAgentPercent,?GeneralAgentCommission,?Agent,?AgentPercent,?AgentCommission,?Percent,?Commission,?Credit,?IsReport,?MaxUser,?Plate,?RoleId,?SubAccount,?RegistrationTime,?LastLoginTime,?LastLoginIP,?UpUserName,?UpUserID,?UpRoleId)";
        //private const string SQL_UPDATE = "update user set UserName=?UserName,Password=?Password,Name=?Name,Mobile=?Mobile,Currency=?Currency,Email=?Email,Tel=?Tel,Status=?Status,CompanyPercent=?CompanyPercent,CompanyCommission=?CompanyCommission,SubCompany=?SubCompany,SubCompanyPercent=?SubCompanyPercent,SubCompanyCommission=?SubCompanyCommission,Partner=?Partner,PartnerPercent=?PartnerPercent,PartnerCommission=?PartnerCommission,GeneralAgent=?GeneralAgent,GeneralAgentPercent=?GeneralAgentPercent,GeneralAgentCommission=?GeneralAgentCommission,Agent=?Agent,AgentPercent=?AgentPercent,AgentCommission=?AgentCommission,Percent=?Percent,Commission=?Commission,Credit=?Credit,IsReport=?IsReport,MaxUser=?MaxUser,Plate=?Plate,RoleId=?RoleId,SubAccount=?SubAccount,RegistrationTime=?RegistrationTime,LastLoginTime=?LastLoginTime,LastLoginIP=?LastLoginIP,UpUserName=?UpUserName,UpUserID=?UpUserID,UpRoleId=?UpRoleId where ID = ?ID";
        //private const string SQL_SELECTBYPK = "select ID from user  where user.ID = ?ID";b
        //private const string SQL_SELECTALL = "select ID,UserName,Password,Name,Mobile,Currency,Email,Tel,Status,CompanyPercent,CompanyCommission,SubCompany,SubCompanyPercent,SubCompanyCommission,Partner,PartnerPercent,PartnerCommission,GeneralAgent,GeneralAgentPercent,GeneralAgentCommission,Agent,AgentPercent,AgentCommission,Percent,Commission,Credit,IsReport,MaxUser,Plate,RoleId,SubAccount,RegistrationTime,LastLoginTime,LastLoginIP,UpUserName,UpUserID,UpRoleId from user ";
        //private const string SQL_DELETEBYPK = "delete  from user  where user.ID = ?ID";

        ////2010-10-3修改
        //private const string SQL_INSERT = "insert into yafa.user (UserName,Password,Balance,Name,Mobile,Currency,Email,Tel,Status,CompanyPercent,CompanyCommission,SubCompany,SubCompanyPercent,SubCompanyCommission,Partner,PartnerPercent,PartnerCommission,GeneralAgent,GeneralAgentPercent,GeneralAgentCommission,Agent,AgentPercent,AgentCommission,Percent,Commission,Credit,IsReport,MaxUser,Plate,RoleId,SubAccount,RegistrationTime,LastLoginTime,LastLoginIP,UpUserName,UpUserID,UpRoleId,ItemMin,ItemMax,ItemsMax,UserLevel,Coefficient,Proportion,Group)values(?UserName,?Password,?Balance,?Name,?Mobile,?Currency,?Email,?Tel,?Status,?CompanyPercent,?CompanyCommission,?SubCompany,?SubCompanyPercent,?SubCompanyCommission,?Partner,?PartnerPercent,?PartnerCommission,?GeneralAgent,?GeneralAgentPercent,?GeneralAgentCommission,?Agent,?AgentPercent,?AgentCommission,?Percent,?Commission,?Credit,?IsReport,?MaxUser,?Plate,?RoleId,?SubAccount,?RegistrationTime,?LastLoginTime,?LastLoginIP,?UpUserName,?UpUserID,?UpRoleId,?ItemMin,?ItemMax,?ItemsMax,?UserLevel,?Coefficient,?Proportion,?Group)";
        //private const string SQL_UPDATE = "update yafa.user set UserName=?UserName,Password=?Password,Balance=?Balance,Name=?Name,Mobile=?Mobile,Currency=?Currency,Email=?Email,Tel=?Tel,Status=?Status,CompanyPercent=?CompanyPercent,CompanyCommission=?CompanyCommission,SubCompany=?SubCompany,SubCompanyPercent=?SubCompanyPercent,SubCompanyCommission=?SubCompanyCommission,Partner=?Partner,PartnerPercent=?PartnerPercent,PartnerCommission=?PartnerCommission,GeneralAgent=?GeneralAgent,GeneralAgentPercent=?GeneralAgentPercent,GeneralAgentCommission=?GeneralAgentCommission,Agent=?Agent,AgentPercent=?AgentPercent,AgentCommission=?AgentCommission,Percent=?Percent,Commission=?Commission,Credit=?Credit,IsReport=?IsReport,MaxUser=?MaxUser,Plate=?Plate,RoleId=?RoleId,SubAccount=?SubAccount,RegistrationTime=?RegistrationTime,LastLoginTime=?LastLoginTime,LastLoginIP=?LastLoginIP,UpUserName=?UpUserName,UpUserID=?UpUserID,UpRoleId=?UpRoleId,ItemMin=?ItemMin,ItemMax=?ItemMax,ItemsMax=?ItemsMax,UserLevel=?UserLevel,Coefficient=?Coefficient,Proportion=?Proportion,Group=?Group where ID = ?ID";
        //private const string SQL_SELECTBYPK = "select ID from yafa.user  where user.ID = ?ID";
        //private const string SQL_SELECTALL = "select ID,UserName,Password,Balance,Name,Mobile,Currency,Email,Tel,Status,CompanyPercent,CompanyCommission,SubCompany,SubCompanyPercent,SubCompanyCommission,Partner,PartnerPercent,PartnerCommission,GeneralAgent,GeneralAgentPercent,GeneralAgentCommission,Agent,AgentPercent,AgentCommission,Percent,Commission,Credit,IsReport,MaxUser,Plate,RoleId,SubAccount,RegistrationTime,LastLoginTime,LastLoginIP,UpUserName,UpUserID,UpRoleId,ItemMin,ItemMax,ItemsMax,UserLevel,Coefficient,Proportion,Group from yafa.user ";
        //private const string SQL_DELETEBYPK = "delete  from yafa.user  where user.ID = ?ID";

        //2010-10-14修改
        //private const string SQL_INSERT = "insert into yafa.user (UserName,Password,Balance,Name,Mobile,Currency,Email,Tel,Status,CompanyPercent,CompanyCommission,SubCompany,SubCompanyPercent,SubCompanyCommission,Partner,PartnerPercent,PartnerCommission,GeneralAgent,GeneralAgentPercent,GeneralAgentCommission,Agent,AgentPercent,AgentCommission,Percent,Commission,Credit,IsReport,MaxUser,Plate,RoleId,SubAccount,RegistrationTime,LastLoginTime,LastLoginIP,UpUserName,UpUserID,UpRoleId,ItemMin,ItemMax,ItemsMax,UserLevel,Coefficient,Proportion,Group,key,ResetCredit)values(?UserName,?Password,?Balance,?Name,?Mobile,?Currency,?Email,?Tel,?Status,?CompanyPercent,?CompanyCommission,?SubCompany,?SubCompanyPercent,?SubCompanyCommission,?Partner,?PartnerPercent,?PartnerCommission,?GeneralAgent,?GeneralAgentPercent,?GeneralAgentCommission,?Agent,?AgentPercent,?AgentCommission,?Percent,?Commission,?Credit,?IsReport,?MaxUser,?Plate,?RoleId,?SubAccount,?RegistrationTime,?LastLoginTime,?LastLoginIP,?UpUserName,?UpUserID,?UpRoleId,?ItemMin,?ItemMax,?ItemsMax,?UserLevel,?Coefficient,?Proportion,?Group,?key,?ResetCredit)";
        //private const string SQL_UPDATE = "update yafa.user set UserName=?UserName,Password=?Password,Balance=?Balance,Name=?Name,Mobile=?Mobile,Currency=?Currency,Email=?Email,Tel=?Tel,Status=?Status,CompanyPercent=?CompanyPercent,CompanyCommission=?CompanyCommission,SubCompany=?SubCompany,SubCompanyPercent=?SubCompanyPercent,SubCompanyCommission=?SubCompanyCommission,Partner=?Partner,PartnerPercent=?PartnerPercent,PartnerCommission=?PartnerCommission,GeneralAgent=?GeneralAgent,GeneralAgentPercent=?GeneralAgentPercent,GeneralAgentCommission=?GeneralAgentCommission,Agent=?Agent,AgentPercent=?AgentPercent,AgentCommission=?AgentCommission,Percent=?Percent,Commission=?Commission,Credit=?Credit,IsReport=?IsReport,MaxUser=?MaxUser,Plate=?Plate,RoleId=?RoleId,SubAccount=?SubAccount,RegistrationTime=?RegistrationTime,LastLoginTime=?LastLoginTime,LastLoginIP=?LastLoginIP,UpUserName=?UpUserName,UpUserID=?UpUserID,UpRoleId=?UpRoleId,ItemMin=?ItemMin,ItemMax=?ItemMax,ItemsMax=?ItemsMax,UserLevel=?UserLevel,Coefficient=?Coefficient,Proportion=?Proportion,Group=?Group,key=?key,ResetCredit=?ResetCredit where ID = ?ID";
        //private const string SQL_SELECTBYPK = "select ID from yafa.user  where user.ID = ?ID";
        //private const string SQL_SELECTALL = "select ID,UserName,Password,Balance,Name,Mobile,Currency,Email,Tel,Status,CompanyPercent,CompanyCommission,SubCompany,SubCompanyPercent,SubCompanyCommission,Partner,PartnerPercent,PartnerCommission,GeneralAgent,GeneralAgentPercent,GeneralAgentCommission,Agent,AgentPercent,AgentCommission,Percent,Commission,Credit,IsReport,MaxUser,Plate,RoleId,SubAccount,RegistrationTime,LastLoginTime,LastLoginIP,UpUserName,UpUserID,UpRoleId,ItemMin,ItemMax,ItemsMax,UserLevel,Coefficient,Proportion,Group,key,ResetCredit from yafa.user ";
        //private const string SQL_DELETEBYPK = "delete  from yafa.user  where user.ID = ?ID";

        private const string SQL_INSERT = "insert into yafa.user (UserName,Password,Balance,Name,Mobile,Currency,Email,Tel,Status,CompanyPercent,CompanyCommission,SubCompany,SubCompanyPercent,SubCompanyCommission,Partner,PartnerPercent,PartnerCommission,GeneralAgent,GeneralAgentPercent,GeneralAgentCommission,Agent,AgentPercent,AgentCommission,Percent,Commission,Credit,IsReport,MaxUser,Plate,RoleId,SubAccount,RegistrationTime,LastLoginTime,LastLoginIP,UpUserName,UpUserID,UpRoleId,ItemMin,ItemMax,ItemsMax,UserLevel,Coefficient,Proportion,Group,key,ResetCredit,LastName,FirstName,sex,Birthday,country,addr,city,Province,post,LoginName,question,Answer,know,MoneyType)values(?UserName,?Password,?Balance,?Name,?Mobile,?Currency,?Email,?Tel,?Status,?CompanyPercent,?CompanyCommission,?SubCompany,?SubCompanyPercent,?SubCompanyCommission,?Partner,?PartnerPercent,?PartnerCommission,?GeneralAgent,?GeneralAgentPercent,?GeneralAgentCommission,?Agent,?AgentPercent,?AgentCommission,?Percent,?Commission,?Credit,?IsReport,?MaxUser,?Plate,?RoleId,?SubAccount,?RegistrationTime,?LastLoginTime,?LastLoginIP,?UpUserName,?UpUserID,?UpRoleId,?ItemMin,?ItemMax,?ItemsMax,?UserLevel,?Coefficient,?Proportion,?Group,?key,?ResetCredit,?LastName,?FirstName,?sex,?Birthday,?country,?addr,?city,?Province,?post,?LoginName,?question,?Answer,?know,?MoneyType)";
        private const string SQL_UPDATE = "update yafa.user set UserName=?UserName,Password=?Password,Balance=?Balance,Name=?Name,Mobile=?Mobile,Currency=?Currency,Email=?Email,Tel=?Tel,Status=?Status,CompanyPercent=?CompanyPercent,CompanyCommission=?CompanyCommission,SubCompany=?SubCompany,SubCompanyPercent=?SubCompanyPercent,SubCompanyCommission=?SubCompanyCommission,Partner=?Partner,PartnerPercent=?PartnerPercent,PartnerCommission=?PartnerCommission,GeneralAgent=?GeneralAgent,GeneralAgentPercent=?GeneralAgentPercent,GeneralAgentCommission=?GeneralAgentCommission,Agent=?Agent,AgentPercent=?AgentPercent,AgentCommission=?AgentCommission,Percent=?Percent,Commission=?Commission,Credit=?Credit,IsReport=?IsReport,MaxUser=?MaxUser,Plate=?Plate,RoleId=?RoleId,SubAccount=?SubAccount,RegistrationTime=?RegistrationTime,LastLoginTime=?LastLoginTime,LastLoginIP=?LastLoginIP,UpUserName=?UpUserName,UpUserID=?UpUserID,UpRoleId=?UpRoleId,ItemMin=?ItemMin,ItemMax=?ItemMax,ItemsMax=?ItemsMax,UserLevel=?UserLevel,Coefficient=?Coefficient,Proportion=?Proportion,Group=?Group,key=?key,ResetCredit=?ResetCredit,LastName=?LastName,FirstName=?FirstName,sex=?sex,Birthday=?Birthday,country=?country,addr=?addr,city=?city,Province=?Province,post=?post,LoginName=?LoginName,question=?question,Answer=?Answer,know=?know,MoneyType=?MoneyType where ID = ?ID";
        private const string SQL_SELECTBYPK = "select * from yafa.user  where user.ID = ?ID";
        private const string SQL_SELECTALL = "select ID,UserName,Password,Balance,Name,Mobile,Currency,Email,Tel,Status,CompanyPercent,CompanyCommission,SubCompany,SubCompanyPercent,SubCompanyCommission,Partner,PartnerPercent,PartnerCommission,GeneralAgent,GeneralAgentPercent,GeneralAgentCommission,Agent,AgentPercent,AgentCommission,Percent,Commission,Credit,IsReport,MaxUser,Plate,RoleId,SubAccount,RegistrationTime,LastLoginTime,LastLoginIP,UpUserName,UpUserID,UpRoleId,ItemMin,ItemMax,ItemsMax,UserLevel,Coefficient,Proportion,Group,key,ResetCredit,LastName,FirstName,sex,Birthday,country,addr,city,Province,post,LoginName,question,Answer,know,MoneyType from yafa.user ";
        private const string SQL_DELETEBYPK = "delete  from yafa.user  where user.ID = ?ID";

        private const string SQL_UPDATE2 = "update yafa.user set Commission=?Commission where ID = ?ID";
        private const string SQL_SELECTMINCREDITS = "select Sum(Credit) as Credit from yafa.user  where user.UpUserID = ?UpUserID and user.ID<>?ID";
        private const string SQL_UPDATECREDIT = "update yafa.user set Credit=?Credit,Balance=?Balance where ID = ?ID";
        private const string SQL_SELECTBALANCE = "select Balance from yafa.user  where user.ID = ?ID";
        private const string SQL_CHECKLOGIN = "select id,Wincoins,nicheng,UserName,LastLoginTime,Name,Currency,Balance,validAmount,CompanyPercent,CompanyCommission,SubCompany,SubCompanyPercent,SubCompanyCommission,Partner,PartnerPercent,PartnerCommission,GeneralAgent,GeneralAgentPercent,GeneralAgentCommission,Agent,AgentPercent,AgentCommission,Percent,Commission,Credit,UserLevel,coefficient,ItemMin,ItemMax,ItemsMax,Status,FirstName,LastName,Mobile,demo,parentcode from yafa.user where UserName=?userName and password=md5(?password) ";
        private const string SQL_UPDATE_LOGIN = "update yafa.user set LastLoginTime=now(),LastLoginIP=?LastLoginIP where id=?id";
        /// <summary>
        /// 重置会员信用
        /// </summary>
        /// <returns></returns>
        public bool RecoverUserCredit()
        {
            string sqlStr = "Update user set Balance=Credit where ResetCredit='1'";
            return MySqlHelper.ExecuteNonQuery(sqlStr, null) > 0;
        }

        /// <summary>
        /// 更新会员等级
        /// </summary>
        /// <param name="UserLevel">等级</param>
        /// <param name="Coefficient">跟投系数</param>
        /// <param name="Proportion">吃货比例</param>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public bool UpdateUserLevel(string UserLevel, string Coefficient, string Proportion, string userName)
        {
            string sql = "update user set UserLevel='" + UserLevel + "',Coefficient='" + Coefficient + "',Proportion='" + Proportion + "' where UserName='" + userName + "'";
            string str2 = "update yafa.orderhistory set yafa.orderhistory.UserLevel='" + UserLevel + "',Coefficient='" + Coefficient + "',Proportion='" + Proportion + "' where yafa.orderhistory.UserName='" + userName + "'";
            bool u1 = MySqlHelper.ExecuteNonQuery(sql, null) > 0;
            bool u2 = MySqlHelper.ExecuteNonQuery(str2, null) > 0;
            if (u1 && u2)
            {
                return true;
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// 更新重置信用设置（分公司）
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UpdateResetCreditBySubCompany(string userName, string resetCredit)
        {
            string sqlStr = "Update user set ResetCredit=?ResetCredit where SubCompany=?SubCompany";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?ResetCredit",resetCredit),
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
            string sqlStr = "Update user set ResetCredit=?ResetCredit where Partner=?Partner";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?ResetCredit",resetCredit),
                new MySqlParameter("?Partner",userName)
            };
            return MySqlHelper.ExecuteNonQuery(sqlStr, param) > 0;

        }

        /// <summary>
        /// 更新重置信用设置（总代）
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UpdateResetCreditByGeneralAgent(string userName, string resetCredit)
        {
            string sqlStr = "Update user set ResetCredit=?ResetCredit where GeneralAgent=?GeneralAgent";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?ResetCredit",resetCredit),
                new MySqlParameter("?GeneralAgent",userName)
            };
            return MySqlHelper.ExecuteNonQuery(sqlStr, param) > 0;

        }

        /// <summary>
        /// 更新重置信用设置（代理）
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UpdateResetCreditByAgent(string userName, string resetCredit)
        {
            string sqlStr = "Update user set ResetCredit=?ResetCredit where Agent=?Agent";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?ResetCredit",resetCredit),
                new MySqlParameter("?Agent",userName)
            };
            return MySqlHelper.ExecuteNonQuery(sqlStr, param) > 0;

        }

        /// <summary>
        /// 重置信用设置（会员）
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UpdateResetCreditByUser(string userName, string resetCredit)
        {
            string sqlStr = "Update user set ResetCredit=?ResetCredit where UserName=?UserName";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?ResetCredit",resetCredit),
                new MySqlParameter("?UserName",userName)
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
            string sqlStr = "select * from user where username=?username";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?username",userName)
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
            string sqlStr = "Update user set Percent=?Percent where ID=?ID";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?Percent",percent),
                new MySqlParameter("?ID",ID)
            };
            return MySqlHelper.ExecuteNonQuery(sqlStr, param) == 1;
        }


        /// <summary>
        /// 返回最大占�?
        /// </summary>
        /// <param name="upUserName"></param>
        /// <returns></returns>
        public object GetMaxPercentByUserName(int ID)
        {
            string sqlStr = "select Max(Percent) as Percent from user where UpUserID=?UpUserID";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?UpUserID",ID)
            };
            return MySqlHelper.ExecuteScalar(sqlStr, param);

        }

        /// <summary>
        /// 修改会员信用
        /// 编写时间: 2010-10-6 14:10
        /// 创建者：Mickey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="credit"></param>
        /// <returns></returns>
        public bool updateUserCredit(string id, string credit, decimal balance)
        {
            MySqlParameter[] param = new MySqlParameter[]{
			     new MySqlParameter("?Credit",credit),
                 new MySqlParameter("?Balance",balance),
				 new MySqlParameter("?ID",id)
            };
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATECREDIT, param) > 0;
        }

        /// <summary>
        /// 获取除指定ID 以外的会员信用总�?
        /// 编写时间: 2010-10-7 14:00
        /// 创建者：Mickey  
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public MySqlDataReader GetUserCredits(string Id,string userId)
        {
            MySqlParameter[] patam = new MySqlParameter[]{
                new MySqlParameter("?ID",Id),
                new MySqlParameter("?UpUserID",userId)
            };
            return MySqlHelper.ExecuteReader(SQL_SELECTMINCREDITS, patam);
        }

        public MySqlDataReader GetBalance(string Id)
        {
            MySqlParameter[] patam = new MySqlParameter[]{
                new MySqlParameter("?ID",Id)
            };
            return MySqlHelper.ExecuteReader(SQL_SELECTBALANCE, patam);
        }

        /// <summary>
        /// 修改会员佣金
        /// 编写时间�?010-10-4 14:30
        /// 创建者：Mickey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commission"></param>
        /// <returns></returns>
        public bool updateUserCommission(string id, string commission)
        {
            MySqlParameter[] param = new MySqlParameter[]{
			     new MySqlParameter("?Commission",commission),
				 new MySqlParameter("?ID",id)
            };
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE2, param) > 0;
        }

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-4-26 15:59:19		
        ///</summary>		
        public Boolean AddUser(User user)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",user.UserName),
				 new MySqlParameter("?Password",user.Password),
				 new MySqlParameter("?Balance",user.Balance),
				 new MySqlParameter("?Name",user.Name),
				 new MySqlParameter("?Mobile",user.Mobile),
				 new MySqlParameter("?Currency",user.Currency),
				 new MySqlParameter("?Email",user.Email),
				 new MySqlParameter("?Tel",user.Tel),
				 new MySqlParameter("?Status",user.Status),
				 new MySqlParameter("?CompanyPercent",user.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",user.CompanyCommission),
				 new MySqlParameter("?SubCompany",user.SubCompany),
				 new MySqlParameter("?SubCompanyPercent",user.SubCompanyPercent),
				 new MySqlParameter("?SubCompanyCommission",user.SubCompanyCommission),
				 new MySqlParameter("?Partner",user.Partner),
				 new MySqlParameter("?PartnerPercent",user.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",user.PartnerCommission),
				 new MySqlParameter("?GeneralAgent",user.GeneralAgent),
				 new MySqlParameter("?GeneralAgentPercent",user.GeneralAgentPercent),
				 new MySqlParameter("?GeneralAgentCommission",user.GeneralAgentCommission),
				 new MySqlParameter("?Agent",user.Agent),
				 new MySqlParameter("?AgentPercent",user.AgentPercent),
				 new MySqlParameter("?AgentCommission",user.AgentCommission),
				 new MySqlParameter("?Percent",user.Percent),
				 new MySqlParameter("?Commission",user.Commission),
				 new MySqlParameter("?Credit",user.Credit),
				 new MySqlParameter("?IsReport",user.IsReport),
				 new MySqlParameter("?MaxUser",user.MaxUser),
				 new MySqlParameter("?Plate",user.Plate),
				 new MySqlParameter("?RoleId",user.RoleId),
				 new MySqlParameter("?SubAccount",user.SubAccount),
				 new MySqlParameter("?RegistrationTime",user.RegistrationTime),
				 new MySqlParameter("?LastLoginTime",user.LastLoginTime),
				 new MySqlParameter("?LastLoginIP",user.LastLoginIP),
				 new MySqlParameter("?UpUserName",user.UpUserName),
				 new MySqlParameter("?UpUserID",user.UpUserID),
				 new MySqlParameter("?UpRoleId",user.UpRoleId),
				 new MySqlParameter("?ItemMin",user.ItemMin),
				 new MySqlParameter("?ItemMax",user.ItemMax),
				 new MySqlParameter("?ItemsMax",user.ItemsMax),
				 new MySqlParameter("?UserLevel",user.UserLevel),
				 new MySqlParameter("?Coefficient",user.Coefficient),
				 new MySqlParameter("?Proportion",user.Proportion),
				 new MySqlParameter("?Group",user.Group),
				 new MySqlParameter("?key",user.Key),
				 new MySqlParameter("?ResetCredit",user.ResetCredit),
				 new MySqlParameter("?LastName",user.LastName),
				 new MySqlParameter("?FirstName",user.FirstName),
				 new MySqlParameter("?sex",user.Sex),
				 new MySqlParameter("?Birthday",user.Birthday),
				 new MySqlParameter("?country",user.Country),
				 new MySqlParameter("?addr",user.Addr),
				 new MySqlParameter("?city",user.City),
				 new MySqlParameter("?Province",user.Province),
				 new MySqlParameter("?post",user.Post),
				 new MySqlParameter("?LoginName",user.LoginName),
				 new MySqlParameter("?question",user.Question),
				 new MySqlParameter("?Answer",user.Answer),
				 new MySqlParameter("?know",user.Know),
				 new MySqlParameter("?MoneyType",user.MoneyType)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-4-26 15:59:19		
        ///</summary>		
        public Boolean UpdateUser(User user)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",user.UserName),
				 new MySqlParameter("?Password",user.Password),
				 new MySqlParameter("?Balance",user.Balance),
				 new MySqlParameter("?Name",user.Name),
				 new MySqlParameter("?Mobile",user.Mobile),
				 new MySqlParameter("?Currency",user.Currency),
				 new MySqlParameter("?Email",user.Email),
				 new MySqlParameter("?Tel",user.Tel),
				 new MySqlParameter("?Status",user.Status),
				 new MySqlParameter("?CompanyPercent",user.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",user.CompanyCommission),
				 new MySqlParameter("?SubCompany",user.SubCompany),
				 new MySqlParameter("?SubCompanyPercent",user.SubCompanyPercent),
				 new MySqlParameter("?SubCompanyCommission",user.SubCompanyCommission),
				 new MySqlParameter("?Partner",user.Partner),
				 new MySqlParameter("?PartnerPercent",user.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",user.PartnerCommission),
				 new MySqlParameter("?GeneralAgent",user.GeneralAgent),
				 new MySqlParameter("?GeneralAgentPercent",user.GeneralAgentPercent),
				 new MySqlParameter("?GeneralAgentCommission",user.GeneralAgentCommission),
				 new MySqlParameter("?Agent",user.Agent),
				 new MySqlParameter("?AgentPercent",user.AgentPercent),
				 new MySqlParameter("?AgentCommission",user.AgentCommission),
				 new MySqlParameter("?Percent",user.Percent),
				 new MySqlParameter("?Commission",user.Commission),
				 new MySqlParameter("?Credit",user.Credit),
				 new MySqlParameter("?IsReport",user.IsReport),
				 new MySqlParameter("?MaxUser",user.MaxUser),
				 new MySqlParameter("?Plate",user.Plate),
				 new MySqlParameter("?RoleId",user.RoleId),
				 new MySqlParameter("?SubAccount",user.SubAccount),
				 new MySqlParameter("?RegistrationTime",user.RegistrationTime),
				 new MySqlParameter("?LastLoginTime",user.LastLoginTime),
				 new MySqlParameter("?LastLoginIP",user.LastLoginIP),
				 new MySqlParameter("?UpUserName",user.UpUserName),
				 new MySqlParameter("?UpUserID",user.UpUserID),
				 new MySqlParameter("?UpRoleId",user.UpRoleId),
				 new MySqlParameter("?ItemMin",user.ItemMin),
				 new MySqlParameter("?ItemMax",user.ItemMax),
				 new MySqlParameter("?ItemsMax",user.ItemsMax),
				 new MySqlParameter("?UserLevel",user.UserLevel),
				 new MySqlParameter("?Coefficient",user.Coefficient),
				 new MySqlParameter("?Proportion",user.Proportion),
				 new MySqlParameter("?Group",user.Group),
				 new MySqlParameter("?key",user.Key),
				 new MySqlParameter("?ResetCredit",user.ResetCredit),
				 new MySqlParameter("?LastName",user.LastName),
				 new MySqlParameter("?FirstName",user.FirstName),
				 new MySqlParameter("?sex",user.Sex),
				 new MySqlParameter("?Birthday",user.Birthday),
				 new MySqlParameter("?country",user.Country),
				 new MySqlParameter("?addr",user.Addr),
				 new MySqlParameter("?city",user.City),
				 new MySqlParameter("?Province",user.Province),
				 new MySqlParameter("?post",user.Post),
				 new MySqlParameter("?LoginName",user.LoginName),
				 new MySqlParameter("?question",user.Question),
				 new MySqlParameter("?Answer",user.Answer),
				 new MySqlParameter("?know",user.Know),
				 new MySqlParameter("?MoneyType",user.MoneyType),
				 new MySqlParameter("?ID",user.ID)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-4-26 15:59:19		
        ///</summary>		
        public Boolean DeleteUserByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2011-4-26 15:59:19		
        ///</summary>		
        public User GetUserByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

            return MySqlModelHelper<User>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2011-4-26 15:59:19		
        ///</summary>		
        public IList<User> GetMutilILUser()
        {
            return MySqlModelHelper<User>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2011-4-26 15:59:19		
        ///</summary>		
        public DataTable GetMutilDTUser()
        {
            return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion 

        /// <summary>
        /// 更新会员密码
        /// create by 肖军�?
        /// create date 2010-09-28
        /// </summary>
        /// <param name="pass">密码</param>
        /// <param name="userName">账户名称</param>
        /// <returns></returns>
        public bool UpdatePass(string pass, string userName)
        {
            string SQL_UPDATEPASS = "update yafa.user set Password=Md5(?pass) where UserName=?userName";
            MySqlParameter[] parameter = new MySqlParameter[] { 
             new MySqlParameter("?pass",pass),
             new MySqlParameter("?userName",userName)
            };

            return MySqlHelper.ExecuteNonQuery(SQL_UPDATEPASS, parameter)>0; 
        }

        
        /// <summary>
        /// 查询记录的总数
        /// create date 2010-09-28
        /// create by 肖军�?
        /// </summary>   
        /// <returns></returns>
        public int GetUserAcount(string upUserName,string userName,string status)
        {
            string SQL_SELECTACOUNT = "select count(*) from yafa.user where upUserName=?upUserName";
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
        /// 据条件查询会员信息，分页
        /// create date 2010-09-29
        /// create by 肖军�?
        /// update by 肖军�?
        /// update content 由于之前忽略了一些条件故增加了以下的一些if条件判断
        /// update date 2010-10-01
        /// </summary>
        /// <param name="upUserName"></param>
        /// <param name="userName"></param>
        /// <param name="status"></param>
        /// <param name="limitStart"></param>
        /// <param name="limitEnd"></param>
        /// <returns></returns>
        public IList<User> GetUser(string upUserName, string userName, string status, int limitStart, int limitEnd)
        {
            string SQL_SELECTBYCONDITION = "select * from yafa.user where upUserName=?upUserName ";
            MySqlParameter[] parameter = new MySqlParameter[] { 
                new MySqlParameter("?upUserName",upUserName), 
                new MySqlParameter("?limitStart",limitStart),
                new MySqlParameter("?limitEnd",limitEnd)
            };
            if (userName != "")
            {
                SQL_SELECTBYCONDITION += " and userName='" + userName + "'";
                //SQL_SELECTBYCONDITION += " and userName=?userName";
                //parameter[3] = new MySqlParameter("?userName", userName);
            }
            if (status != "")
            {
                SQL_SELECTBYCONDITION += " and  status='" + status + "'";
            }
            SQL_SELECTBYCONDITION += " order by ID desc ";
            SQL_SELECTBYCONDITION += " limit ?limitStart,?limitEnd";
             IList<User> list = null;
             try
             {
                  list = MySqlModelHelper<User>.GetObjectsBySql(SQL_SELECTBYCONDITION, parameter);
             }
            catch(MySqlException ex){
                throw ex; 
            }
            catch(NullReferenceException  ex){
                throw ex;
            }
            catch(InvalidOperationException ex){
                throw ex;
            }
             catch (Exception ex) 
             {
                 throw ex; 
             }
             return list;
        }

        /// <summary>
        /// 更新会员的基本信�?
        /// create date 2010-09-29
        /// create by 肖军�?
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tel"></param>
        /// <param name="mobile"></param>
        /// <param name="status"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UpdateUserByUserName(string name, string tel, string mobile, string status, string userName)
        {
            string SQL_UPDATEUSERBYUSERNAME = "update yafa.user set name=?name,tel=?tel,mobile=?mobile,status=?status where userName=?userName";
            MySqlParameter[] parameter = new MySqlParameter[]{
               new MySqlParameter("?name",name),
               new MySqlParameter("?tel",tel),
               new MySqlParameter("?mobile",mobile),
               new MySqlParameter("?status",status),
               new MySqlParameter("?userName",userName)
            };
            try
            {
                return MySqlHelper.ExecuteNonQuery(SQL_UPDATEUSERBYUSERNAME, parameter)>0;
            }catch(MySqlException ex){
                throw ex;
            }
            catch(InvalidExpressionException ex){
                throw ex;
            }
            catch(Exception ex){
                throw ex;
            }
            
        }

        /// <summary>
        /// 添加代理信息
        /// create by 肖军�?
        /// create date 2010-09-29
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddAgentUser(User user)
        {
            string SQL_INSERTUSER = "insert into user (UserName,`Password`,Name,Mobile,Currency,Email,Tel,Status,CompanyPercent,CompanyCommission,SubCompany,SubCompanyPercent,SubCompanyCommission,Partner,PartnerPercent,PartnerCommission,GeneralAgent,GeneralAgentPercent,GeneralAgentCommission,Agent,AgentPercent,AgentCommission,Percent,Commission,Credit,IsReport,MaxUser,Plate,RoleId,SubAccount,RegistrationTime,LastLoginTime,LastLoginIP,UpUserName,UpUserID,UpRoleId,ItemMin,ItemMax,ItemsMax,`Group`,ResetCredit,balance,UserLevel,Coefficient,Proportion,MoneyType) values (?UserName,md5(?Password),?Name,?Mobile,?Currency,?Email,?Tel,?Status,?CompanyPercent,?CompanyCommission,?SubCompany,?SubCompanyPercent,?SubCompanyCommission,?Partner,?PartnerPercent,?PartnerCommission,?GeneralAgent,?GeneralAgentPercent,?GeneralAgentCommission,?Agent,?AgentPercent,?AgentCommission,?Percent,?Commission,?Credit,?IsReport,?MaxUser,?Plate,?RoleId,?SubAccount,?RegistrationTime,?LastLoginTime,?LastLoginIP,?UpUserName,?UpUserID,?UpRoleId,?ItemMin,?ItemMax,?ItemsMax,?Group,?ResetCredit,?balance,?UserLevel,?Coefficient,?Proportion,?MoneyType);SELECT LAST_INSERT_ID();";
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",user.UserName),
				 new MySqlParameter("?Password",user.Password),
				 new MySqlParameter("?Name",user.Name),
				 new MySqlParameter("?Mobile",user.Mobile),
				 new MySqlParameter("?Currency",user.Currency),
				 new MySqlParameter("?Email",user.Email),
				 new MySqlParameter("?Tel",user.Tel),
				 new MySqlParameter("?Status",user.Status),
				 new MySqlParameter("?CompanyPercent",user.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",user.CompanyCommission),
				 new MySqlParameter("?SubCompany",user.SubCompany),
				 new MySqlParameter("?SubCompanyPercent",user.SubCompanyPercent),
				 new MySqlParameter("?SubCompanyCommission",user.SubCompanyCommission),
				 new MySqlParameter("?Partner",user.Partner),
				 new MySqlParameter("?PartnerPercent",user.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",user.PartnerCommission),
				 new MySqlParameter("?GeneralAgent",user.GeneralAgent),
				 new MySqlParameter("?GeneralAgentPercent",user.GeneralAgentPercent),
				 new MySqlParameter("?GeneralAgentCommission",user.GeneralAgentCommission),
				 new MySqlParameter("?Agent",user.Agent),
				 new MySqlParameter("?AgentPercent",user.AgentPercent),
				 new MySqlParameter("?AgentCommission",user.AgentCommission),
				 new MySqlParameter("?Percent",user.Percent),
				 new MySqlParameter("?Commission",user.Commission),
				 new MySqlParameter("?Credit",user.Credit),
				 new MySqlParameter("?IsReport",user.IsReport),
				 new MySqlParameter("?MaxUser",user.MaxUser),
				 new MySqlParameter("?Plate",user.Plate),
				 new MySqlParameter("?RoleId",user.RoleId),
				 new MySqlParameter("?SubAccount",user.SubAccount),
				 new MySqlParameter("?RegistrationTime",user.RegistrationTime),
				 new MySqlParameter("?LastLoginTime",user.LastLoginTime),
				 new MySqlParameter("?LastLoginIP",user.LastLoginIP),
				 new MySqlParameter("?UpUserName",user.UpUserName),
				 new MySqlParameter("?UpUserID",user.UpUserID),
				 new MySqlParameter("?UpRoleId",user.UpRoleId),
                 new MySqlParameter("?ItemMin",user.ItemMin),
                 new MySqlParameter("?ItemMax",user.ItemMax),
                 new MySqlParameter("?ItemsMax",user.ItemsMax),
                 new MySqlParameter("?Group",user.Group),
                 new MySqlParameter("?ResetCredit",user.ResetCredit),
                 new MySqlParameter("?balance",user.Balance),
                 new MySqlParameter("?UserLevel",user.UserLevel),
                 new MySqlParameter("?Coefficient",user.Coefficient),
                 new MySqlParameter("?Proportion",user.Proportion),
                 new MySqlParameter("?MoneyType",user.MoneyType)
			};
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(SQL_INSERTUSER, param));
        }

        /// <summary>
        /// 更新上级代理人数
        /// create by 肖军�?
        /// create date 2010-09-29
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool UpdateAgentNumber(int userId)
        {
            string SQL_UPDATEAGENTNUNMBER = "update yafa.agent set Agentsnumber=Agentsnumber+1 where ID=?userId";
            MySqlParameter[] parameter = new MySqlParameter[] { 
                  new MySqlParameter("?userId",userId)
                };
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATEAGENTNUNMBER, parameter) > 0;
        }


        public System.Data.Common.DbDataReader stringGetUserNamesA(string userName)
        {
            string SQL_SELECTUSERNAMES = " ";
            return MySqlHelper.ExecuteReader(SQL_SELECTUSERNAMES, null);
        }

        public bool UpdateUserLevel(string userName, string userLevel)
        {
            //string str = "update yafa.user,yafa.orderhistory,yafa.orderdetail1x2,yafa.orderdetail1x2hf,yafa.orderdetail1x2hfl,yafa.orderdetail1x2l,yafa.orderdetailhdp";
            //str += ",yafa.orderdetailhdphf,yafa.orderdetailhdpl,yafa.orderdetaillive,yafa.orderdetailou,yafa.orderdetailouhf,yafa.orderdetailouhfl";
            //str += ",yafa.orderdetailoul set ";
            //str += "yafa.user.UserLevel='" + userLevel + "',yafa.orderhistory.UserLevel='" + userLevel + "',yafa.orderdetail1x2.UserLevel='" + userLevel + "',yafa.orderdetail1x2hf.UserLevel='"+userLevel+"'";
            //str += ",yafa.orderdetail1x2hfl.UserLevel='" + userLevel + "',yafa.orderdetail1x2l.UserLevel='" + userLevel + "',yafa.orderdetailhdp.UserLevel='" + userLevel + "',yafa.orderdetailhdphf.UserLevel='"+userLevel+"'";
            //str += ",yafa.orderdetailhdphfl.UserLevel='" + userLevel + "',yafa.orderdetailhdpl.UserLevel='" + userLevel + "',yafa.orderdetaillive.UserLevel='" + userLevel + "',yafa.orderdetailou.UserLevel='"+userLevel+"'";
            //str += ",yafa.orderdetailouhf.UserLevel='" + userLevel + "',yafa.orderdetailouhfl.UserLevel='" + userLevel + "',yafa.orderdetailoul.UserLevel='"+userLevel+"' where ";

            //str += "yafa.user.UserName='" + userName + "'and yafa.orderhistory.UserName='" + userName + "'and yafa.orderdetail1x2.UserName='" + userName + "'and yafa.orderdetail1x2hf.UserName='" + userName + "' ";

            //str += "and yafa.orderdetail1x2hfl.UserName='" + userName + "'and yafa.orderdetail1x2l.UserName='" + userName + "'and yafa.orderdetailhdp.UserName='" + userName + "'and yafa.orderdetailhdphf.UserName='" + userName + "' ";
            //str += "and yafa.orderdetailhdphfl.UserName='" + userName + "'and yafa.orderdetailhdpl.UserName='" + userName + "'and yafa.orderdetaillive.UserName='" + userName + "'and yafa.orderdetailou.UserName='" + userName + "' ";
            //str += "and yafa.orderdetailouhf.UserName='" + userName + "'and yafa.orderdetailouhfl.UserName='" + userName + "'and yafa.orderdetailoul.UserName='" + userName + "'";

            //return MySqlHelper.ExecuteNonQuery(str, null) > 0;

            string str1 = "update yafa.user set yafa.user.UserLevel='" + userLevel + "' where yafa.user.UserName='" + userName + "'";
            string str2 = "update yafa.orderhistory set yafa.orderhistory.UserLevel='" + userLevel + "' where yafa.orderhistory.UserName='" + userName + "'";
            string str3 = "update yafa.orderdetail1x2 set yafa.orderdetail1x2.UserLevel='" + userLevel + "' where yafa.orderdetail1x2.UserName='" + userName + "'";
            string str4 = "update yafa.orderdetail1x2hf set yafa.orderdetail1x2hf.UserLevel='" + userLevel + "' where yafa.orderdetail1x2hf.UserName='" + userName + "'";
            string str5 = "update yafa.orderdetail1x2hfl set yafa.orderdetail1x2hfl.UserLevel='" + userLevel + "' where yafa.orderdetail1x2hfl.UserName='" + userName + "'";
            string str6 = "update yafa.orderdetail1x2l set yafa.orderdetail1x2l.UserLevel='" + userLevel + "' where yafa.orderdetail1x2l.UserName='" + userName + "'";
            string str7 = "update yafa.orderdetailhdp set yafa.orderdetailhdp.UserLevel='" + userLevel + "' where yafa.orderdetailhdp.UserName='" + userName + "'";
            string str8 = "update yafa.orderdetailhdphf set yafa.orderdetailhdphf.UserLevel='" + userLevel + "' where yafa.orderdetailhdphf.UserName='" + userName + "'";
            string str9 = "update yafa.orderdetailhdpl set yafa.orderdetailhdpl.UserLevel='" + userLevel + "' where yafa.orderdetailhdpl.UserName='" + userName + "'";
            string str10 = "update yafa.orderdetaillive set yafa.orderdetaillive.UserLevel='" + userLevel + "' where yafa.orderdetaillive.UserName='" + userName + "'";
            string str11 = "update yafa.orderdetailou set yafa.orderdetailou.UserLevel='" + userLevel + "' where yafa.orderdetailou.UserName='" + userName + "'";
            string str12 = "update yafa.orderdetailouhf set yafa.orderdetailouhf.UserLevel='" + userLevel + "' where yafa.orderdetailouhf.UserName='" + userName + "'";
            string str13 = "update yafa.orderdetailouhfl set yafa.orderdetailouhfl.UserLevel='" + userLevel + "' where yafa.orderdetailouhfl.UserName='" + userName + "'";
            string str14 = "update yafa.orderdetailoul set yafa.orderdetailoul.UserLevel='" + userLevel + "' where yafa.orderdetailoul.UserName='" + userName + "'";

            bool u1 = MySqlHelper.ExecuteNonQuery(str1, null) > 0;
            bool u2 = MySqlHelper.ExecuteNonQuery(str2, null) > 0;
            //bool u3 = MySqlHelper.ExecuteNonQuery(str3, null) > 0;
            //bool u4 = MySqlHelper.ExecuteNonQuery(str4, null) > 0;
            //bool u5 = MySqlHelper.ExecuteNonQuery(str5, null) > 0;
            //bool u6 = MySqlHelper.ExecuteNonQuery(str6, null) > 0;
            //bool u7 = MySqlHelper.ExecuteNonQuery(str7, null) > 0;
            //bool u8 = MySqlHelper.ExecuteNonQuery(str8, null) > 0;
            //bool u9 = MySqlHelper.ExecuteNonQuery(str9, null) > 0;
            //bool u10 = MySqlHelper.ExecuteNonQuery(str10, null) > 0;
            //bool u11 = MySqlHelper.ExecuteNonQuery(str11, null) > 0;
            //bool u12 = MySqlHelper.ExecuteNonQuery(str12, null) > 0;
            //bool u13 = MySqlHelper.ExecuteNonQuery(str13, null) > 0;
            //bool u14 = MySqlHelper.ExecuteNonQuery(str14, null) > 0;

            if (u1 && u2 )//&& u3 && u4 && u5 && u6 && u7 && u8 && u9 && u10 && u11 && u12 && u13 && u14)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetAccountInfo(string userName)
        {
            string SQL_SELECTACCOUNTINFO = "select id as a,UserName as b,SubCompany as c,Partner as d,GeneralAgent as e,Agent as f,UserLevel as r,Coefficient as g,Proportion as h from yafa.user where UserName='"+userName+"'";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(SQL_SELECTACCOUNTINFO));
        }

        /// <summary>
        /// 客户查找
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="status">状态</param>
        /// <param name="currency">币种</param>
        /// <param name="time1">注册日期1</param>
        /// <param name="time2">注册日期2</param>
        /// <param name="agentType">代理类型，如：代理agent</param>
        /// <param name="agent">代理名称</param>
        /// <returns></returns>
        public string GetUserByWhere(string userName, string status, string currency, string time1, string time2, string agentType, string agent, string MoneyType)
        {
            string sqlStr = "";
            string subSql = "";
            userName = userName.Replace("'", "");
            status = status.Replace("'", "");
            currency = currency.Replace("'", "");
            time1 = time1.Replace("'", "");
            time2 = time2.Replace("'", "");
            agentType = agentType.Replace("'", "");
            agent = agent.Replace("'", "");

            if (!string.IsNullOrEmpty(userName))
            {
                subSql += " and UserName like '%" + userName + "%' ";
            }
            if (!string.IsNullOrEmpty(status))
            {
                subSql += " and Status=" + status;
            }
            if (!string.IsNullOrEmpty(currency))
            {
                subSql += " and Currency='" + currency + "' ";
            }
            if (!string.IsNullOrEmpty(time1) && !string.IsNullOrEmpty(time2))
            {
                subSql += " and RegistrationTime>='" + time1 + "' and RegistrationTime<='" + time2 + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(agentType) && !string.IsNullOrEmpty(agent))
            {
                subSql += " and " + agentType + "='" + agent + "' ";
            }
            if (!string.IsNullOrEmpty(MoneyType))
            {
                subSql += " and MoneyType='" + MoneyType + "' ";
            }
            if (subSql == "")
            {
                return "";
            }
            sqlStr = "select ID,UserName,LastName,FirstName,sex,country,Mobile,Currency,Credit,Agent,Status,Balance,MoneyType,RegistrationTime,LastLoginTime from user where 1=1 " + subSql + " order by ID desc";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sqlStr));
        }

        public static string GetUserByWhere1(string userName, string status, string regTime1, string regTime2, string loginTime1, string loginTime2, string agent, string ip, string tel, string email)
        {
            string sqlStr = "";
            string subSql = "";
            userName = Util.SecurityHelper.InputValue(userName);
            status = Util.SecurityHelper.InputValue(status);
            regTime1 = Util.SecurityHelper.InputValue(regTime1);
            regTime2 = Util.SecurityHelper.InputValue(regTime2);
            loginTime1 = Util.SecurityHelper.InputValue(loginTime1);
            loginTime2 = Util.SecurityHelper.InputValue(loginTime2);
            agent = Util.SecurityHelper.InputValue(agent);
            ip = Util.SecurityHelper.InputValue(ip);
            tel = Util.SecurityHelper.InputValue(tel);
            email = Util.SecurityHelper.InputValue(email);

            if (!string.IsNullOrEmpty(userName))
            {
               
                subSql += " and UserName like '%" + userName + "%' ";
            }
            if (!string.IsNullOrEmpty(status))
            {
                subSql += " and status=" + status;
            }
            if (!string.IsNullOrEmpty(regTime1) & !string.IsNullOrEmpty(regTime2))
            {
                subSql += " and RegistrationTime>='" + regTime1 + "' and RegistrationTime<='" + regTime2 + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(loginTime1) & !string.IsNullOrEmpty(loginTime2))
            {
                subSql += " and LastLoginTime>='" + loginTime1 + "' and LastLoginTime<='" + loginTime2 + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(agent))
            {
                subSql += " and agent='" + agent + "' ";
            }
            if (!string.IsNullOrEmpty(ip))
            {
                subSql += " and LastLoginIP='" + ip + "' ";
            }
            if (!string.IsNullOrEmpty(tel))
            {
                subSql += " and tel like '%" + tel + "%' ";
            }
            if (!string.IsNullOrEmpty(email))
            {
                subSql += " and email like '%" + email + "%' ";
            }


            if (subSql == "")
            {
                return "";
            }
            sqlStr = "select ID,Name,UserName,FirstName,LastName,nicheng,Balance,status,fstatus,qkcs,soucunsj,RegistrationTime,regip,LastLoginTime,LastLoginIP,agent,UserLevel,cunkuanfs,email,tel from user where 1=1 " + subSql + " order by ID desc";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sqlStr));
        }


        public static string GetUserByWhere_info(string userName,string Name,string status, string regTime1, string regTime2, string loginTime1, string loginTime2, string agent, string ip, string tel, string email)
        {
            string sqlStr = "";
            string subSql = "";
            userName = Util.SecurityHelper.InputValue(userName);
            status = Util.SecurityHelper.InputValue(status);
            regTime1 = Util.SecurityHelper.InputValue(regTime1);
            regTime2 = Util.SecurityHelper.InputValue(regTime2);
            loginTime1 = Util.SecurityHelper.InputValue(loginTime1);
            loginTime2 = Util.SecurityHelper.InputValue(loginTime2);
            agent = Util.SecurityHelper.InputValue(agent);
            ip = Util.SecurityHelper.InputValue(ip);
            tel = Util.SecurityHelper.InputValue(tel);
            email = Util.SecurityHelper.InputValue(email);

            if (!string.IsNullOrEmpty(userName))
            {
               
                subSql += " and UserName like '%" + userName + "%' ";
            }
            if (!string.IsNullOrEmpty(Name))
            {

                subSql += " and Name like '%" + Name + "%' ";
            }
            if (!string.IsNullOrEmpty(status))
            {
                subSql += " and status=" + status;
            }
            if (!string.IsNullOrEmpty(regTime1) & !string.IsNullOrEmpty(regTime2))
            {
                subSql += " and RegistrationTime>='" + regTime1 + "' and RegistrationTime<='" + regTime2 + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(loginTime1) & !string.IsNullOrEmpty(loginTime2))
            {
                subSql += " and LastLoginTime>='" + loginTime1 + "' and LastLoginTime<='" + loginTime2 + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(agent))
            {
                subSql += " and agent='" + agent + "' ";
            }
            if (!string.IsNullOrEmpty(ip))
            {
                subSql += " and LastLoginIP='" + ip + "' ";
            }
            if (!string.IsNullOrEmpty(tel))
            {
                subSql += " and tel like '%" + tel + "%' ";
            }
            if (!string.IsNullOrEmpty(email))
            {
                subSql += " and email like '%" + email + "%' ";
            }


            if (subSql == "")
            {
                return "";
            }
            sqlStr = "select ID,Name,UserName,FirstName,LastName,nicheng,Balance,status,fstatus,qkcs,soucunsj,RegistrationTime,regip,LastLoginTime,LastLoginIP,agent,UserLevel,cunkuanfs,email,tel from user where 1=1 " + subSql + " order by ID desc";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sqlStr));
        }
        public static string GetUserByWhere_win(string name, string userName, string status, string regTime1, string regTime2, string loginTime1, string loginTime2, string agent, string ip, string tel, string email, string wincount)
        {
            string sqlStr = "";
            string subSql = "";
            name = Util.SecurityHelper.InputValue(name);
            userName = Util.SecurityHelper.InputValue(userName);
            status = Util.SecurityHelper.InputValue(status);
            regTime1 = Util.SecurityHelper.InputValue(regTime1);
            regTime2 = Util.SecurityHelper.InputValue(regTime2);
            loginTime1 = Util.SecurityHelper.InputValue(loginTime1);
            loginTime2 = Util.SecurityHelper.InputValue(loginTime2);
            agent = Util.SecurityHelper.InputValue(agent);
            ip = Util.SecurityHelper.InputValue(ip);
            tel = Util.SecurityHelper.InputValue(tel);
            email = Util.SecurityHelper.InputValue(email);
            wincount = Util.SecurityHelper.InputValue(wincount);
            if (!string.IsNullOrEmpty(name))
            {
                subSql += " and name like '%" + name + "%' ";
            }
            if (!string.IsNullOrEmpty(userName))
            {
                subSql += " and username like '%" + userName + "%' ";
            }
            if (!string.IsNullOrEmpty(wincount))
            {
                subSql += " and Wincoins>" + wincount + " ";
            }


            if (!string.IsNullOrEmpty(status))
            {
                subSql += " and status=" + status;
            }
            if (!string.IsNullOrEmpty(regTime1) & !string.IsNullOrEmpty(regTime2))
            {
                subSql += " and RegistrationTime>='" + regTime1 + "' and RegistrationTime<='" + regTime2 + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(loginTime1) & !string.IsNullOrEmpty(loginTime2))
            {
                subSql += " and LastLoginTime>='" + loginTime1 + "' and LastLoginTime<='" + loginTime2 + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(agent))
            {
                subSql += " and agent='" + agent + "' ";
            }
            if (!string.IsNullOrEmpty(ip))
            {
                subSql += " and LastLoginIP='" + ip + "' ";
            }
            if (!string.IsNullOrEmpty(tel))
            {
                subSql += " and tel like '%" + tel + "%' ";
            }
            if (!string.IsNullOrEmpty(email))
            {
                subSql += " and email like '%" + email + "%' ";
            }


            if (subSql == "")
            {
                return "";
            }
            sqlStr = "select ID,UserName,Name,FirstName,LastName,nicheng,Balance,Wincoins,status,fstatus,qkcs,soucunsj,RegistrationTime,regip,LastLoginTime,LastLoginIP,agent,UserLevel,cunkuanfs,email,tel from user where 1=1 " + subSql + " order by ID desc";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sqlStr));
        }
        public static string GetUserByWhere2(string name, string userName, string status, string regTime1, string regTime2, string loginTime1, string loginTime2, string agent, string ip, string tel, string email)
        {
            string sqlStr = "";
            string subSql = "";
            name = Util.SecurityHelper.InputValue(name);
            userName = Util.SecurityHelper.InputValue(userName);
            status = Util.SecurityHelper.InputValue(status);
            regTime1 = Util.SecurityHelper.InputValue(regTime1);
            regTime2 = Util.SecurityHelper.InputValue(regTime2);
            loginTime1 = Util.SecurityHelper.InputValue(loginTime1);
            loginTime2 = Util.SecurityHelper.InputValue(loginTime2);
            agent = Util.SecurityHelper.InputValue(agent);
            ip = Util.SecurityHelper.InputValue(ip);
            tel = Util.SecurityHelper.InputValue(tel);
            email = Util.SecurityHelper.InputValue(email);

            if (!string.IsNullOrEmpty(name))
            {
                subSql += " and name like '%" + name + "%' ";
            }
            if (!string.IsNullOrEmpty(userName))
            {
                subSql += " and username like '%" + userName + "%' ";
            }
            if (!string.IsNullOrEmpty(status))
            {
                subSql += " and status=" + status;
            }
            if (!string.IsNullOrEmpty(regTime1) & !string.IsNullOrEmpty(regTime2))
            {
                subSql += " and RegistrationTime>='" + regTime1 + "' and RegistrationTime<='" + regTime2 + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(loginTime1) & !string.IsNullOrEmpty(loginTime2))
            {
                subSql += " and LastLoginTime>='" + loginTime1 + "' and LastLoginTime<='" + loginTime2 + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(agent))
            {
                subSql += " and agent='" + agent + "' ";
            }
            if (!string.IsNullOrEmpty(ip))
            {
                subSql += " and LastLoginIP='" + ip + "' ";
            }
            if (!string.IsNullOrEmpty(tel))
            {
                subSql += " and tel like '%" + tel + "%' ";
            }
            if (!string.IsNullOrEmpty(email))
            {
                subSql += " and email like '%" + email + "%' ";
            }


            if (subSql == "")
            {
                return "";
            }
            sqlStr = "select ID,UserName,Name,FirstName,LastName,nicheng,Balance,Wincoins,status,fstatus,qkcs,soucunsj,RegistrationTime,regip,LastLoginTime,LastLoginIP,agent,UserLevel,cunkuanfs,email,tel from user where 1=1 " + subSql + " order by ID desc";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sqlStr));
        }

        public static string GetUserByWherePage2(int perPageNum, int page, string name, string userName, string status, string regTime1, string regTime2, string loginTime1, string loginTime2, string agent, string ip, string tel, string email)
        {
            string sqlStr = "";
            string subSql = "";
            int limit1 = perPageNum * page;
            name = Util.SecurityHelper.InputValue(name);
            userName = Util.SecurityHelper.InputValue(userName);
            status = Util.SecurityHelper.InputValue(status);
            regTime1 = Util.SecurityHelper.InputValue(regTime1);
            regTime2 = Util.SecurityHelper.InputValue(regTime2);
            loginTime1 = Util.SecurityHelper.InputValue(loginTime1);
            loginTime2 = Util.SecurityHelper.InputValue(loginTime2);
            agent = Util.SecurityHelper.InputValue(agent);
            ip = Util.SecurityHelper.InputValue(ip);
            tel = Util.SecurityHelper.InputValue(tel);
            email = Util.SecurityHelper.InputValue(email);

            if (!string.IsNullOrEmpty(name))
            {
                subSql += " and name like '%" + name + "%' ";
            }
            if (!string.IsNullOrEmpty(userName))
            {
                subSql += " and username like '%" + userName + "%' ";
            }
            if (!string.IsNullOrEmpty(status))
            {
                subSql += " and status=" + status;
            }
            if (!string.IsNullOrEmpty(regTime1) & !string.IsNullOrEmpty(regTime2))
            {
                subSql += " and RegistrationTime>='" + regTime1 + "' and RegistrationTime<='" + regTime2 + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(loginTime1) & !string.IsNullOrEmpty(loginTime2))
            {
                subSql += " and LastLoginTime>='" + loginTime1 + "' and LastLoginTime<='" + loginTime2 + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(agent))
            {
                subSql += " and agent='" + agent + "' ";
            }
            if (!string.IsNullOrEmpty(ip))
            {
                subSql += " and LastLoginIP='" + ip + "' ";
            }
            if (!string.IsNullOrEmpty(tel))
            {
                subSql += " and tel like '%" + tel + "%' ";
            }
            if (!string.IsNullOrEmpty(email))
            {
                subSql += " and email like '%" + email + "%' ";
            }

            //if (subSql == "")
            //{
            //    return "";
            //}
            string sql = "select count(*) from user where 1=1 " + subSql + " order by ID desc";
            int recordNum = Convert.ToInt32(MySqlHelper.ExecuteScalar(sql));
            sqlStr = "select ID,UserName,Name,FirstName,LastName,nicheng,Balance,Wincoins,status,fstatus,qkcs,soucunsj,RegistrationTime,regip,LastLoginTime,LastLoginIP,agent,UserLevel,cunkuanfs,email,tel,TCpassword,Post,Answer from user where 1=1 " + subSql + " order by ID desc limit " + limit1.ToString() + "," + perPageNum.ToString();
            string json = "{\"text\":[";
            json += ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sqlStr));
            json += "],\"count\":[{\"recordNum\":\"" + recordNum.ToString() + "\"}]}";

            return json;
        }

        public bool UpdateUser1(User info)
        {
            string sqlStr = "Update user set FirstName=?FirstName,LastName=?LastName,sex=?sex,Email=?Email,Birthday=?Birthday,country=?country,addr=?addr,Province=?Province,post=?post,Mobile=?Mobile,question=?question,Answer=?Answer where ID=?ID";
            MySqlParameter[] para = new MySqlParameter[]{
                new MySqlParameter("?FirstName",info.FirstName),
                new MySqlParameter("?LastName",info.LastName),
                new MySqlParameter("?sex",info.Sex),
                new MySqlParameter("?Email",info.Email),
                new MySqlParameter("?Birthday",info.Birthday),
                new MySqlParameter("?country",info.Country),
                new MySqlParameter("?addr",info.Addr),
                new MySqlParameter("?Province",info.Province),
                new MySqlParameter("?post",info.Post),
                new MySqlParameter("?Mobile",info.Mobile),
                new MySqlParameter("?question",info.Question),
                new MySqlParameter("?Answer",info.Answer),
                new MySqlParameter("?ID",info.ID)
            };
            return MySqlHelper.ExecuteNonQuery(sqlStr, para) > 0;
        }

        public static bool UpdateUser2(User info)
        {
            string sqlStr = "Update user set name=?name,question=?question,answer=?answer,nicheng=?nicheng,email=?email,tel=?tel,post=?post,status=?status where ID=?ID";
            MySqlParameter[] para = new MySqlParameter[]{
                new MySqlParameter("?name",info.Name),
                new MySqlParameter("?question",info.Question),
                new MySqlParameter("?answer",info.Answer),
                new MySqlParameter("?nicheng",info.nicheng),
                new MySqlParameter("?email",info.Email),
                new MySqlParameter("?tel",info.Tel),
                new MySqlParameter("?post",info.Post),
                new MySqlParameter("?status",info.Status),
                new MySqlParameter("?ID",info.ID)
            };
            return MySqlHelper.ExecuteNonQuery(sqlStr, para) > 0;
        }

        public static bool UpdateUser22(User info)
        {
            string sqlStr = "Update user set name=?name,question=?question,answer=?answer,nicheng=?nicheng,email=?email,tel=?tel,post=?post,status=?status,userlevel=?userlevel,mark=?mark where ID=?ID";
            MySqlParameter[] para = new MySqlParameter[]{
                new MySqlParameter("?name",info.Name),
                new MySqlParameter("?question",info.Question),
                new MySqlParameter("?answer",info.Answer),
                new MySqlParameter("?nicheng",info.nicheng),
                new MySqlParameter("?email",info.Email),
                new MySqlParameter("?tel",info.Tel),
                new MySqlParameter("?post",info.Post),
                new MySqlParameter("?status",info.Status),
                new MySqlParameter("?userlevel",info.UserLevel),
                new MySqlParameter("?mark",info.mark),
                new MySqlParameter("?ID",info.ID)
            };
            return MySqlHelper.ExecuteNonQuery(sqlStr, para) > 0;
        }


        /// <summary>
        /// IP统计
        /// </summary>
        /// <param name="username"></param>
        /// <param name="loginIP"></param>
        /// <returns></returns>
        public static string GetLoginLog(string username, string loginIP)
        {
            string sql = "";
            string str = "";
            username = Util.SecurityHelper.InputValue(username);
            loginIP = Util.SecurityHelper.InputValue(loginIP);
            if (!string.IsNullOrEmpty(username))
            {
                str += " and username like '%" + username + "%' ";
             
            }
            if (!string.IsNullOrEmpty(loginIP))
            {
                str += " and ip='" + loginIP + "' ";
            }
            if (str == "")
            {
                return "";
            }

            sql = "select username,ip,time1,mark from logclient where 1=1 " + str + "  group by username order by id desc";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sql));
        }
        public static string GetUserInfoByUserName(string userName)
        {
            string sql = "select ID,name,validAmount,UserName,FirstName,LastName,nicheng,Balance,status,fstatus,qkcs,soucunsj,RegistrationTime,regip,LastLoginTime,LastLoginIP,agent,UserLevel,cunkuanfs,email,tel,question,answer,birthday,post from user where username=@username";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@username",userName)
            };
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sql, param));
        }
        public static bool IsExistEmail(string mail)
        {
            string sql = "select count(*) from user where email=@email and moneytype='0'";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@email",mail)
            };
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(sql, param)) > 0;
        }

        public static bool IsExistTel(string tel)
        {
            string sql = "select count(*) from user where tel=@tel";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@tel",tel)
            };
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(sql, param)) > 0;
        }
        public static bool IsExistEmailAgent(string mail)
        {
            string sql = "select count(*) from joiner where email=@email";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@email",mail)
            };
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(sql, param)) > 0;
        }
        public static bool IsExistEmailAgnet(string mail)
        {
            string sql = "select count(*) from joiner where email=@email";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@email",mail)
            };
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(sql, param)) > 0;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User GetUserByUserName(string userName)
        {
            string sqlStr = "select * from user where username=?username";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?username",userName)
            };
            return MySqlModelHelper<User>.GetSingleObjectBySql(sqlStr, param);
             
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Boolean AddAgentUser2(User user)
        {


            string SQL_INSERTUSER = "insert into user (Country,UserName,Password,TCpassword,Birthday,Name,question,Answer,nicheng,Tel,Email,Status,post,MoneyType,CompanyPercent,CompanyCommission,SubCompany,SubCompanyPercent,SubCompanyCommission,Partner,PartnerPercent,PartnerCommission,GeneralAgent,GeneralAgentPercent,GeneralAgentCommission,Agent,AgentPercent,AgentCommission,Percent,Commission,Credit,IsReport,MaxUser,Plate,RoleId,SubAccount,RegistrationTime,LastLoginTime,LastLoginIP,UpUserName,UpUserID,UpRoleId,ItemMin,ItemMax,ItemsMax,`Group`,ResetCredit,balance,UserLevel,Coefficient,Proportion,regip,parentcode) values (?Country,?UserName,md5(?Password),?TCpassword,?Birthday,?Name,?question,?Answer,?nicheng,?Tel,?Email,?Status,?post,?MoneyType,?CompanyPercent,?CompanyCommission,?SubCompany,?SubCompanyPercent,?SubCompanyCommission,?Partner,?PartnerPercent,?PartnerCommission,?GeneralAgent,?GeneralAgentPercent,?GeneralAgentCommission,?Agent,?AgentPercent,?AgentCommission,?Percent,?Commission,?Credit,?IsReport,?MaxUser,?Plate,?RoleId,?SubAccount,?RegistrationTime,?LastLoginTime,?LastLoginIP,?UpUserName,?UpUserID,?UpRoleId,?ItemMin,?ItemMax,?ItemsMax,?Group,?ResetCredit,?balance,?UserLevel,?Coefficient,?Proportion,?regip,?parentcode)";
           
            MySqlParameter[] param = new MySqlParameter[]{
                 new MySqlParameter("?Country",user.Country),
				 new MySqlParameter("?UserName",user.UserName),
                 new MySqlParameter("?TCpassword",user.TCpassword),                 
				 new MySqlParameter("?Password",user.Password),
                 new MySqlParameter("?Birthday",user.Birthday),
				 new MySqlParameter("?Name",user.Name),	
		         new MySqlParameter("?question",user.Question),
                 new MySqlParameter("?Answer",user.Answer),			
                 new MySqlParameter("?nicheng",user.nicheng),
			 	 new MySqlParameter("?Tel",user.Tel),
                 new MySqlParameter("?Email",user.Email),
			     new MySqlParameter("?Status",user.Status),
                 new MySqlParameter("?post",user.Post),
                 new MySqlParameter("?MoneyType",user.MoneyType),

				 new MySqlParameter("?CompanyPercent",user.CompanyPercent),
				 new MySqlParameter("?CompanyCommission",user.CompanyCommission),
				 new MySqlParameter("?SubCompany",user.SubCompany),
				 new MySqlParameter("?SubCompanyPercent",user.SubCompanyPercent),
				 new MySqlParameter("?SubCompanyCommission",user.SubCompanyCommission),
				 new MySqlParameter("?Partner",user.Partner),
				 new MySqlParameter("?PartnerPercent",user.PartnerPercent),
				 new MySqlParameter("?PartnerCommission",user.PartnerCommission),
				 new MySqlParameter("?GeneralAgent",user.GeneralAgent),
				 new MySqlParameter("?GeneralAgentPercent",user.GeneralAgentPercent),
				 new MySqlParameter("?GeneralAgentCommission",user.GeneralAgentCommission),
				 new MySqlParameter("?Agent",user.Agent),
				 new MySqlParameter("?AgentPercent",user.AgentPercent),
				 new MySqlParameter("?AgentCommission",user.AgentCommission),
				 new MySqlParameter("?Percent",user.Percent),
				 new MySqlParameter("?Commission",user.Commission),
				 new MySqlParameter("?Credit",user.Credit),
				 new MySqlParameter("?IsReport",user.IsReport),
				 new MySqlParameter("?MaxUser",user.MaxUser),
				 new MySqlParameter("?Plate",user.Plate),
				 new MySqlParameter("?RoleId",user.RoleId),
				 new MySqlParameter("?SubAccount",user.SubAccount),
				 new MySqlParameter("?RegistrationTime",user.RegistrationTime),
				 new MySqlParameter("?LastLoginTime",user.LastLoginTime),
				 new MySqlParameter("?LastLoginIP",user.LastLoginIP),
				 new MySqlParameter("?UpUserName",user.UpUserName),
				 new MySqlParameter("?UpUserID",user.UpUserID),
				 new MySqlParameter("?UpRoleId",user.UpRoleId),
                 new MySqlParameter("?ItemMin",user.ItemMin),
                 new MySqlParameter("?ItemMax",user.ItemMax),
                 new MySqlParameter("?ItemsMax",user.ItemsMax),
                 new MySqlParameter("?Group",user.Group),
                 new MySqlParameter("?ResetCredit",user.ResetCredit),
                 new MySqlParameter("?balance",user.Balance),
                 new MySqlParameter("?UserLevel",user.UserLevel),
                 new MySqlParameter("?Coefficient",user.Coefficient),
                 new MySqlParameter("?Proportion",user.Proportion),    
                 new MySqlParameter("?regip",user.regip),
                 new MySqlParameter("?parentcode",user.parentcode)
                 
			
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERTUSER, param) > 0;
        }
        /// <summary>
        /// 用户进入记录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="time1"></param>
        /// <param name="IP"></param>
        /// <param name="module"></param>
        /// <param name="action"></param>
        /// <param name="mark"></param>
        /// <returns></returns>
        public static bool AddLogClient(string userName, DateTime time1, string IP, string module, string action, string mark)
        {
            string sql = "Insert into logclient(userName,time1,IP,module,action,mark) values(@userName,@time1,@IP,@module,@action,@mark)";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@userName",userName),
                new MySqlParameter("@time1",time1),
                new MySqlParameter("@IP",IP),
                new MySqlParameter("@module",module),
                new MySqlParameter("@action",action),
                new MySqlParameter("@mark",mark)
            };
            return MySqlHelper.ExecuteNonQuery(sql, param) > 0;
        }
        /// <summary>
        /// 用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string[] GetUserInfo(int id)
        {
            string str = "select itemMin,itemMax,Balance,Wincoins,(1-SubCompanyPercent-PartnerPercent-GeneralAgentPercent-AgentPercent) as percent,MoneyType from  user where status=1 and id=?id";
            string[] value = new string[6];
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?id",id)
            };
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(str, param))
            {
                if (reader.Read())
                {
                    value[0] = reader.GetString("itemMin");
                    value[1] = reader.GetString("itemMax");
                    value[2] = reader.GetString("Balance");
                    value[3] = reader.GetString("percent");
                    value[4] = reader.GetString("MoneyType");
                    value[5] = reader.GetString("Wincoins");
                }
                else
                    value = new string[0];
                reader.Close();
            }
            return value;

        }
        /// <summary>
        /// 试玩用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string[] GetUserInfoDemo(int id)
        {
         
            string[] value = new string[5];
            string sql = "select itemMin,itemMax,Balance,(1-SubCompanyPercent-PartnerPercent-GeneralAgentPercent-AgentPercent) as percent,MoneyType from  userdemo where status=1 and id=?id";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?id",id)
            };
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(sql, param))
            {
                if (reader.Read())
                {
                    value[0] = reader.GetString("itemMin");
                    value[1] = reader.GetString("itemMax");
                    value[2] = reader.GetString("Balance");
                    value[3] = reader.GetString("percent");
                    value[4] = reader.GetString("MoneyType");
                }
                else
                    value = new string[0];
                reader.Close();
            }
            return value;

        }

        public bool GetUserByLogin(string userName, string password, ref User user)
        {
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?userName",MySqlDbType.VarChar,25),
                new MySqlParameter("?password",MySqlDbType.VarChar,32)
            };
            param[0].Value = userName;
            param[1].Value = password;
            bool con = false;

            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_CHECKLOGIN, param))
            {
                if (reader.Read())
                {
                    user = new User();                  
                    user.ID = reader.GetInt32("id");
                    user.UserName = reader.GetString("UserName");
                    user.Name = reader.GetString("Name");
                   // user.Currency = reader.GetString("Currency");
                    user.Balance = reader.GetDecimal("Balance");
                   // user.ValidAmount = reader.GetDecimal("validAmount");
                   
                    user.CompanyPercent = reader.GetDecimal("CompanyPercent");
                    user.CompanyCommission = reader.GetDecimal("CompanyCommission");
                    user.SubCompany = reader.GetString("SubCompany");
                    user.SubCompanyPercent = reader.GetDecimal("SubCompanyPercent");

                  
                    user.SubCompanyCommission = reader.GetDecimal("SubCompanyCommission");
                    user.Partner = reader.GetString("Partner");
                    user.PartnerPercent = reader.GetDecimal("PartnerPercent");
                    user.PartnerCommission = reader.GetDecimal("PartnerCommission");
                    user.GeneralAgent = reader.GetString("GeneralAgent");
                  
                    user.GeneralAgentPercent = reader.GetDecimal("GeneralAgentPercent");
                    user.GeneralAgentCommission = reader.GetDecimal("GeneralAgentCommission");
                    user.Agent = reader.GetString("Agent");
                    user.AgentPercent = reader.GetDecimal("AgentPercent");
                 
                    user.AgentCommission = reader.GetDecimal("AgentCommission");
                    user.Percent = reader.GetDecimal("Percent");
                    user.Commission = reader.GetDecimal("Commission");
                    user.Credit = reader.GetDecimal("Credit");
                    user.UserLevel = reader.GetString("UserLevel");
                    user.Coefficient = reader.GetDecimal("coefficient");
                    user.ItemMin = reader.GetDecimal("ItemMin");
                    user.ItemMax = reader.GetDecimal("ItemMax");
                    user.ItemsMax = reader.GetDecimal("ItemsMax");
                    user.Status = reader.GetInt16("Status");
                    user.FirstName = reader.GetString("FirstName");
                    user.LastName = reader.GetString("LastName");
                   
                    user.Mobile = reader.GetString("Mobile");
                    user.Demo = reader.GetString("demo");
                    user.LastLoginTime = reader.GetDateTime("LastLoginTime");
                    //user.nicheng = reader.GetString("nicheng");
                   // user.Wincoins = reader.GetDecimal("Wincoins");
                    try
                    {
                        user.parentcode = reader.GetString("parentcode");
                    }
                    catch (Exception)
                    {

                        user.parentcode = "";
                    }
                   
                    reader.Close();
                    if (user.Status == 1)
                    {
                        UpdateLoginTime(user.ID, user.Key);
                    }
                  
                    con = true;
                }
                else
                {
                    reader.Close();
                    user = null;
                }

            }
            return con;
        }

        public bool GetUserByLoginClient(string userName, string password, ref User user)
        {
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?userName",MySqlDbType.VarChar,25),
                new MySqlParameter("?password",MySqlDbType.VarChar,32)
            };
            param[0].Value = userName;
            param[1].Value = password;
            bool con = false;

            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_CHECKLOGIN, param))
            {
                if (reader.Read())
                {
                    user = new User();
                    user.ID = reader.GetInt32("id");
                    user.UserName = reader.GetString("UserName");
                    user.Name = reader.GetString("Name");
                    user.Currency = reader.GetString("Currency");
                    user.Balance = reader.GetDecimal("Balance");
                    user.ValidAmount = reader.GetDecimal("validAmount");

                    user.CompanyPercent = reader.GetDecimal("CompanyPercent");
                    user.CompanyCommission = reader.GetDecimal("CompanyCommission");
                    user.SubCompany = reader.GetString("SubCompany");
                    user.SubCompanyPercent = reader.GetDecimal("SubCompanyPercent");


                    user.SubCompanyCommission = reader.GetDecimal("SubCompanyCommission");
                    user.Partner = reader.GetString("Partner");
                    user.PartnerPercent = reader.GetDecimal("PartnerPercent");
                    user.PartnerCommission = reader.GetDecimal("PartnerCommission");
                    user.GeneralAgent = reader.GetString("GeneralAgent");

                    user.GeneralAgentPercent = reader.GetDecimal("GeneralAgentPercent");
                    user.GeneralAgentCommission = reader.GetDecimal("GeneralAgentCommission");
                    user.Agent = reader.GetString("Agent");
                    user.AgentPercent = reader.GetDecimal("AgentPercent");

                    user.AgentCommission = reader.GetDecimal("AgentCommission");
                    user.Percent = reader.GetDecimal("Percent");
                    user.Commission = reader.GetDecimal("Commission");
                    user.Credit = reader.GetDecimal("Credit");
                    user.UserLevel = reader.GetString("UserLevel");
                    user.Coefficient = reader.GetDecimal("coefficient");
                    user.ItemMin = reader.GetDecimal("ItemMin");
                    user.ItemMax = reader.GetDecimal("ItemMax");
                    user.ItemsMax = reader.GetDecimal("ItemsMax");
                    user.Status = reader.GetInt16("Status");
                    user.FirstName = reader.GetString("FirstName");
                    user.LastName = reader.GetString("LastName");

                    user.Mobile = reader.GetString("Mobile");
                    user.Demo = reader.GetString("demo");
                    user.LastLoginTime = reader.GetDateTime("LastLoginTime");
                    user.nicheng = reader.GetString("nicheng");
                    user.Wincoins = reader.GetDecimal("Wincoins");
                    try
                    {
                        user.parentcode = reader.GetString("parentcode");
                    }
                    catch (Exception)
                    {

                        user.parentcode = "";
                    }

                    reader.Close();
                    //if (user.Status == 1)
                    //{
                    //    UpdateLoginTime(user.ID, user.Key);
                    //}

                    con = true;
                }
                else
                {
                    reader.Close();
                    user = null;
                }

            }
            return con;
        }

        /// <summary>
        /// 修改进入时间与ip
        /// </summary>
        /// <param name="id"></param>
        /// <param name="key"></param>
        private void UpdateLoginTime(int id, string key)
        {
            MySqlParameter[] param = new MySqlParameter[] { 
                
                new MySqlParameter("?LastLoginIP",Util.RequestHelper.GetIP()),
                new MySqlParameter("?id",id)
            };
            MySqlHelper.ExecuteNonQuery(SQL_UPDATE_LOGIN, param);
        }


        /// <summary>
        /// 获取用户
        /// </summary>
        /// <returns>json</returns>
        public string SelectUserInfo(string userName)
        {
            string sqls = "select UserName,Name,Balance,RegistrationTime,LastLoginTime,nicheng,question,Wincoins,UserLevel from user where username=?username";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?username",userName)
            };
            string json = "";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(sqls,param))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? string.Empty : json;    
        }

      
        /// <summary>
        /// 代理申请
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static Boolean AddAgentUserAgent(Joiner joiner)
        {
            string SQL_INSERTUSER = "insert into joiner (UserName,Password,nums,Name,Question,Answer,CardNo,bankname,Tel,Email,qq,Subtime) values (?UserName,?Password,?nums,?Name,?Question,?Answer,?CardNo,?bankname,?Tel,?Email,?qq,?Subtime)";
   
            MySqlParameter[] param = new MySqlParameter[]{               
                 new MySqlParameter("?UserName",joiner.UserName),                
                 new MySqlParameter("?Password",joiner.Password),
                 new MySqlParameter("?nums",joiner.nums),
                 new MySqlParameter("?Name",joiner.Name),	
                 new MySqlParameter("?question",joiner.Question),
                 new MySqlParameter("?Answer",joiner.Answer),
	             new MySqlParameter("?CardNo",joiner.CardNo),
                 new MySqlParameter("?bankname",joiner.bankname),
                 new MySqlParameter("?Tel",joiner.Tel),
                 new MySqlParameter("?Email",joiner.Email),			   
                 new MySqlParameter("?qq",joiner.qq),                
                new MySqlParameter("?subtime",joiner.Subtime)
                


			
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERTUSER, param) > 0;
        }


        /// <summary>
        /// 密码认证流水号
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool UpdateUserUpatePwd(string UserName, string PwdInfo, DateTime pwdInfoTime)
        {

            string sqlStr = "Update user set PwdInfo=?PwdInfo,pwdInfoTime=?pwdInfoTime where UserName=?UserName";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?PwdInfo",PwdInfo),
                new MySqlParameter("?pwdInfoTime",pwdInfoTime),
                 new MySqlParameter("?UserName",UserName)
            };
            return MySqlHelper.ExecuteNonQuery(sqlStr, param) > 0;

        }
        /// <summary>
        ///  根据密码认证流水号来取用户名(有效时间为二十四小时)
        /// </summary>
        /// <returns></returns>
        public static string Getusername(string PwdInfo)
        {
            string con = "";
            string sql = "select UserName,pwdInfoTime from user where PwdInfo='" + SecurityHelper.InputValue(PwdInfo) + "'";
           
            DataTable dt = MySqlHelper.ExecuteDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                DateTime nowtime = DateTime.Now;
                DateTime sendtime = Convert.ToDateTime(dt.Rows[0][1]);
                TimeSpan ts = nowtime.Subtract(sendtime);//时间差   
                if (ts.Days >= 1)
                {
                    con="-1"; //此密码流水号有效期超过一天
                   

                }
                else
                {
                    con = dt.Rows[0][0].ToString();
                   
                }
            }
            else
            {
                con ="-2"; //查无此流水号信息
              
            }

            return con;
                 
        }

        public static User GetUserByPwdInfo(string userName, string PwdInfo)
        {
            string sql = "select * from user where username=@username and PwdInfo=@PwdInfo";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@username",userName),
                new MySqlParameter("@PwdInfo",PwdInfo)
            };
            return MySqlModelHelper<User>.GetSingleObjectBySql(sql, param);
        }

        /// <summary>
        /// 验证安全提问，并修改密码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="Answer"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static string SendInfo(string username, string Answer, string Password)
        {
            string sqls = "select count(*) from yafa.user where UserName=?username and Answer=?Answer";
            MySqlParameter[] parameter = new MySqlParameter[] { 
                new MySqlParameter("?username",username),
                new MySqlParameter("?Answer",Answer)
            };

            int count= Convert.ToInt32(MySqlHelper.ExecuteScalar(sqls, parameter));
            if (count > 0)
            {
                string sqlupdate = "Update user set Password=md5(?Password) where UserName=?username";
                MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?Password",Password),    
                new MySqlParameter("?username",username)
                };
                bool isture = MySqlHelper.ExecuteNonQuery(sqlupdate, param) > 0;
                if (isture)
                {
                    return "ok";
                }
                else
                {
                    return "-2"; //修改密码出错
                }

            }
            else
            {
                return "-1"; //安全问题回答错误
            }
        }

        public static string GetPromotion()
        {
            string json = "";
            string sql = "select * from pro_game order by  id  desc";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(sql))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "]" ? string.Empty : json;
        }

        public static string GetImages()
        {
            string json = "";
            string sql = "select id,BigPric from pro_game order by  id  desc";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(sql))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "]" ? string.Empty : json;
        }

        //修改密码
        public static bool UpdatePwdSend(string username, string oldpwd, string newpwd)
        {
            string sqls = "select count(*) from agent where UserName=?username and Password=md5(?oldpwd)";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?username",username),
                 new MySqlParameter("?oldpwd",oldpwd)
            };
            int count = Convert.ToInt32(MySqlHelper.ExecuteScalar(sqls, param));
            if (count > 0)
            {
                try
                {
                    string sqlStr = "Update agent set Password=md5(?newpwd) where UserName=?username";
                    MySqlParameter[] paramss = new MySqlParameter[]{
                        new MySqlParameter("?username",username),
                       new MySqlParameter("?newpwd",newpwd)
                    };
                     return MySqlHelper.ExecuteNonQuery(sqlStr, paramss) > 0;
                }
                catch (Exception)
                {

                    return false;
                }           
               
            }
            else
            {
                return false;
            }


        }

        public static bool UpdateUser5(string UserName, decimal Wincoins, string WincoinInfo)       
        {
            string sqlStr = "Update user set Wincoins=?Wincoins,WincoinInfo=?WincoinInfo where UserName=?UserName";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?UserName",UserName),
                new MySqlParameter("?Wincoins",Wincoins),
                 new MySqlParameter("?WincoinInfo",WincoinInfo)
            };
            return MySqlHelper.ExecuteNonQuery(sqlStr, param) > 0;
        }

        //更新赢币
        public static bool UpdateYingb(decimal yingb, string username)
        {
            string sql = "Update user set Wincoins=Wincoins + @Wincoins where username=@username";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@Wincoins",yingb),
                new MySqlParameter("@username",username)
            };
            return MySqlHelper.ExecuteNonQuery(sql, param) > 0;
        }

      


        //更新首存时间
        public static bool UpdateUser(DateTime scsj, string username)
        {
            string sql = "update user set soucunsj=@soucunsj where username=@username";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@soucunsj",DateTime.Now),
                new MySqlParameter("@username",username)
            };
            return MySqlHelper.ExecuteNonQuery(sql, param) > 0;
        }

        
              /// <summary>
        /// 查出当前用户名的姓名
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string NameFormUsername(string username)
        {
            string sql = "select Name from user where UserName=@username ";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@username",username)
            };
            return Convert.ToString(MySqlHelper.ExecuteScalar(sql, param));
        }

        /// <summary>
        /// 判定用户名是否为一
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool IsExistUsername(string username)
        {
            string sql = "select count(*) from user where UserName=@username ";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@username",username)
            };
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(sql, param)) > 0;
        }
        /// <summary>
        /// 判定用子代理帐号是否为一
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool IsAgentUser(string username)
        {
            string sql = "select count(*) from joiner where UserName=@username ";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@username",username)
            };
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(sql, param)) > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="win2">现有赢币</param>
        /// <param name="win1">要兑换赢币</param>
        /// <param name="WincoinInfo">转换信息</param>
        /// <returns></returns>
        public static bool UpdateUser8(string UserName, decimal win2, decimal win1, string WincoinInfo)
        {
       
            decimal win3 = win2 - win1;
            bool istrue = true;
            //int balance2=
            string sqlStr = "Update user set Wincoins=" + win3 + ",Balance=Balance+"+win1+",WincoinInfo=?WincoinInfo where UserName=?UserName";
            sqlStr += "";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?UserName",UserName),                
                 new MySqlParameter("?WincoinInfo",WincoinInfo)
            };

            if (MySqlHelper.ExecuteNonQuery(sqlStr, param) > 0)
            {
                //插入赠送赢币记录
                BillNoticeHistory billHistory = new BillNoticeHistory();
                billHistory.UserName = UserName;
                billHistory.Type = "8";
                billHistory.Amount = win1; //将要兑换币放入
                billHistory.ValidAmount = win1;
                billHistory.SubmitTime = DateTime.Now;
                billHistory.UpdateTime = DateTime.Now;
                billHistory.Status = "2";
                billHistory.Mark = WincoinInfo;

                istrue = InsertBillNoticeHistory(billHistory);

            }
            else
            {
                return false;
            }



            return istrue;
        }

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="billNoticeHistory"></param>
        /// <returns></returns>
        private static bool InsertBillNoticeHistory(BillNoticeHistory billNoticeHistory)
        {
            string SQL_INSERTBILLNOTICEHISTORY = "insert into BillNoticeHistory(UserName,Type,Amount,SubmitTime,UpdateTime,Status,Reasoncn,Reasontw,Reasonen,Reasonth,Reasonvn,bankno,bankaccount,bankcn,banktw,banken,bankth,cardno,banktime,tel,Currency,validAmount,Names,mark,bankamount1,bankamount2,sfee,bankc,cardnoc,banknoc,banknamec) values(?UserName,?Type,?Amount,?SubmitTime,?UpdateTime,?Status,?Reasoncn,?Reasontw,?Reasonen,?Reasonth,?Reasonvn,?BankNo,?BankAccount,?Bankcn,?Banktw,?Banken,?Bankth,?CardNo,?BankTime,?Tel,?Currency,?ValidAmount,?Names,?mark,?bankamount1,?bankamount2,?sfee,?bankc,?cardnoc,?banknoc,?banknamec)";
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?UserName",MySqlDbType.VarChar,30),
                new MySqlParameter("?Type",MySqlDbType.VarChar,1),
                new MySqlParameter("?Amount",MySqlDbType.Decimal),
                new MySqlParameter("?SubmitTime",MySqlDbType.DateTime),
                new MySqlParameter("?UpdateTime",MySqlDbType.DateTime),
                new MySqlParameter("?Status",MySqlDbType.VarChar,1),
                new MySqlParameter("?Reasoncn",MySqlDbType.VarChar,200),
                new MySqlParameter("?Reasontw",MySqlDbType.VarChar,200),
                new MySqlParameter("?Reasonen",MySqlDbType.VarChar,200),
                new MySqlParameter("?Reasonth",MySqlDbType.VarChar,200),
                new MySqlParameter("?Reasonvn",MySqlDbType.VarChar,200),
                new MySqlParameter("?BankNo",MySqlDbType.VarChar,100),
                new MySqlParameter("?BankAccount",MySqlDbType.VarChar,100),
                new MySqlParameter("?Bankcn",MySqlDbType.VarChar,100),
                new MySqlParameter("?Banktw",MySqlDbType.VarChar,100),
                new MySqlParameter("?Banken",MySqlDbType.VarChar,100),
                new MySqlParameter("?Bankth",MySqlDbType.VarChar,100),
                new MySqlParameter("?CardNo",MySqlDbType.VarChar,30),
                new MySqlParameter("?BankTime",MySqlDbType.VarChar,30),
                new MySqlParameter("?Tel",MySqlDbType.VarChar,30),
                new MySqlParameter("?Currency",MySqlDbType.VarChar,10),
                new MySqlParameter("?ValidAmount",MySqlDbType.Decimal),
                new MySqlParameter("?mark",MySqlDbType.VarChar,500),
                new MySqlParameter("?Names",MySqlDbType.VarChar,30),
                new MySqlParameter("?bankamount1",MySqlDbType.Decimal),
                new MySqlParameter("?bankamount2",MySqlDbType.Decimal),
                new MySqlParameter("?sfee",MySqlDbType.Decimal),
                new MySqlParameter("?bankc",MySqlDbType.VarChar,50),
                new MySqlParameter("?cardnoc",MySqlDbType.VarChar,50),
                new MySqlParameter("?banknoc",MySqlDbType.VarChar,50),
                new MySqlParameter("?banknamec",MySqlDbType.VarChar,50)
            };
            parm[0].Value = billNoticeHistory.UserName;
            parm[1].Value = billNoticeHistory.Type;
            parm[2].Value = billNoticeHistory.Amount;
            parm[3].Value = billNoticeHistory.SubmitTime;
            parm[4].Value = billNoticeHistory.UpdateTime;
            parm[5].Value = billNoticeHistory.Status;
            parm[6].Value = billNoticeHistory.Reasoncn;
            parm[7].Value = billNoticeHistory.Reasontw;
            parm[8].Value = billNoticeHistory.Reasonen;
            parm[9].Value = billNoticeHistory.Reasonth;
            parm[10].Value = billNoticeHistory.Reasonvn;
            parm[11].Value = billNoticeHistory.Bankno;
            parm[12].Value = billNoticeHistory.Bankaccount;
            parm[13].Value = billNoticeHistory.Bankcn;
            parm[14].Value = billNoticeHistory.Banktw;
            parm[15].Value = billNoticeHistory.Banken;
            parm[16].Value = billNoticeHistory.Bankth;
            parm[17].Value = billNoticeHistory.CardNo;
            parm[18].Value = billNoticeHistory.BankTime;
            parm[19].Value = billNoticeHistory.Tel;
            parm[20].Value = billNoticeHistory.Currency;
            parm[21].Value = billNoticeHistory.ValidAmount;
            parm[22].Value = billNoticeHistory.Mark;
            parm[23].Value = billNoticeHistory.Names;

            parm[24].Value = billNoticeHistory.bankamount1;
            parm[25].Value = billNoticeHistory.bankamount2;
            parm[26].Value = billNoticeHistory.sfee;
            parm[27].Value = billNoticeHistory.bankc;
            parm[28].Value = billNoticeHistory.cardnoc;
            parm[29].Value = billNoticeHistory.banknoc;
            parm[30].Value = billNoticeHistory.banknamec;

            return MySqlHelper.ExecuteNonQuery(SQL_INSERTBILLNOTICEHISTORY, parm) > 0;
        }

        public static string UserStatistics()
        {
            string sql1 = "select count(*) from user;";     //注册会员
            string sql2 = "select count(distinct  username) from billnoticehistory where type='1' and status='2';"; //存款会员
            string sql3 = "select count(*) from user where date(RegistrationTime)=date('" + DateTime.Now.ToString() + "')";    //今日注册会员
            string sql4 = "select count(distinct  username), ifnull(sum(amount),0)  from  billnoticehistory where type='1' and status='2' and date(updatetime)=date('" + DateTime.Now.ToString() + "');";      //今日存款会员	今日存款金额
            string sql5 = "select count(distinct  username),ifnull( sum(amount),0)  from  billnoticehistory where type='2' and status='2' and date(updatetime)=date('" + DateTime.Now.ToString() + "');";      //今日取款会员	今日取款金额
            string sql6 = "select  ifnull(sum(amount),0)  from  billnoticehistory where type='3' and status='2' and date(updatetime)=date('" + DateTime.Now.ToString() + "');";    //今日红利
            string sql7 = "select  ifnull(sum(amount),0)  from  billnoticehistory where type='4' and status='2' and date(updatetime)=date('" + DateTime.Now.ToString() + "');";    //EA返水
            string sql8 = "select ifnull(sum(amount),0) from billnoticehistory where type='7' and status='2'";    //总赠送赢币
            string sql9 = "select ifnull(sum(amount),0) from billnoticehistory where type='7' and status='2' and date(updatetime)=date('" + DateTime.Now.ToString() + "');";    //今日赠送赢币
            //PT返水
            string sql10 = "select  ifnull(sum(amount),0)  from  billnoticehistory where type='14' and status='2' and date(updatetime)=date('" + DateTime.Now.ToString() + "');";
            //EA流水
            string sql11 = "select ifnull(sum(bet_amount),0 ) as betamount, ifnull( sum( handle ),0 ) as handle, ifnull( sum( hold ),0 ) as hold from gameinforeport_ea  where date(enddate)=date('" + DateTime.Now.ToString() + "' )";
            //PT流水
            string sql12 = "select ifnull(sum(bet_amount),0 ) as betamount, ifnull( sum( handle ),0 ) as handle, ifnull( sum( hold ),0 ) as hold from pt_gameinfo  where date(enddate)=date('" + DateTime.Now.ToString() + "' )";        
            string json = "{";
            MySqlDataReader reader = MySqlHelper.ExecuteReader(sql1);
            if (reader.Read())
            {
                json += "\"a\":\"" + reader.GetInt32(0) + "\",";
                reader.Close();
            }
            else
            {
                reader.Close();
            }
            reader = MySqlHelper.ExecuteReader(sql12);
            if (reader.Read())
            {
                //PT流水（和局)
                json += "\"ee\":\"" + reader.GetDecimal(0) + "\",";
                //PT流水
                json += "\"ff\":\"" + reader.GetDecimal(1) + "\",";
                //PT输赢
                json += "\"gg\":\"" + reader.GetDecimal(2) + "\",";
                reader.Close();
            }
            else
            {
                reader.Close();
            }
            reader = MySqlHelper.ExecuteReader(sql11);
            if (reader.Read())
            {
                //EA流水（和局)
                json += "\"bb\":\"" + reader.GetDecimal(0) + "\",";
                //EA流水
                json += "\"cc\":\"" + reader.GetDecimal(1) + "\",";
                //EA输赢
                json += "\"dd\":\"" + reader.GetDecimal(2) + "\",";
                reader.Close();
            }
            else
            {
                reader.Close();
            }
            reader = MySqlHelper.ExecuteReader(sql10);
            if (reader.Read())
            {
                //PT返水
                json += "\"aa\":\"" + reader.GetDecimal(0) + "\",";
                reader.Close();
            }
            else
            {
                reader.Close();
            }
            reader = MySqlHelper.ExecuteReader(sql2);
            if (reader.Read())
            {
                json += "\"b\":\"" + reader.GetInt32(0) + "\",";
                reader.Close();
            }
            else
            {
                reader.Close();
            }
            reader = MySqlHelper.ExecuteReader(sql3);
            if (reader.Read())
            {
                json += "\"c\":\"" + reader.GetInt32(0) + "\",";
                reader.Close();
            }
            else
            {
                reader.Close();
            }
            reader = MySqlHelper.ExecuteReader(sql4);
            if (reader.Read())
            {
                json += "\"d\":\"" + reader.GetInt32(0) + "\",";
                json += "\"e\":\"" + reader.GetInt32(1) + "\",";
                reader.Close();
            }
            else
            {
                reader.Close();
            }
            reader = MySqlHelper.ExecuteReader(sql5);
            if (reader.Read())
            {
                json += "\"f\":\"" + reader.GetInt32(0) + "\",";
                json += "\"g\":\"" + reader.GetInt32(1) + "\",";
                reader.Close();
            }
            else
            {
                reader.Close();
            }
            reader = MySqlHelper.ExecuteReader(sql6);
            if (reader.Read())
            {
                json += "\"h\":\"" + reader.GetInt32(0) + "\",";
                reader.Close();
            }
            else
            {
                reader.Close();
            }
            reader = MySqlHelper.ExecuteReader(sql7);
            if (reader.Read())
            {
                json += "\"i\":\"" + reader.GetInt32(0) + "\",";
                reader.Close();
            }
            else
            {
                reader.Close();
            }
            reader = MySqlHelper.ExecuteReader(sql8);
            if (reader.Read())
            {
                json += "\"j\":\"" + reader.GetInt32(0) + "\",";
                reader.Close();
            }
            else
            {
                reader.Close();
            }
            reader = MySqlHelper.ExecuteReader(sql9);
            if (reader.Read())
            {
                json += "\"k\":\"" + reader.GetInt32(0) + "\"";
                reader.Close();
            }
            else
            {
                reader.Close();
            }

            json += "}";
            return json;
        }

        public bool CheckWebLogin(string userName, string LastLoginIP, ref User user)
        {
            string SQL_CHECKLOGIN = "select id,Wincoins,nicheng,UserName,LastLoginTime,Name,Currency,Balance,validAmount,CompanyPercent,CompanyCommission,SubCompany,SubCompanyPercent,SubCompanyCommission,Partner,PartnerPercent,PartnerCommission,GeneralAgent,GeneralAgentPercent,GeneralAgentCommission,Agent,AgentPercent,AgentCommission,Percent,Commission,Credit,UserLevel,coefficient,ItemMin,ItemMax,ItemsMax,Status,FirstName,LastName,Mobile,demo,parentcode from yafa.user where UserName=?userName and LastLoginIP=?LastLoginIP";
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?userName",MySqlDbType.VarChar,25),
                new MySqlParameter("?LastLoginIP",MySqlDbType.VarChar,25)
            };
            param[0].Value = userName;
            param[1].Value = LastLoginIP;
            bool con = false;

            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_CHECKLOGIN, param))
            {
                if (reader.Read())
                {
                    user = new User();
                    user.ID = reader.GetInt32("id");
                    user.UserName = reader.GetString("UserName");
                    user.Name = reader.GetString("Name");
                    user.Currency = reader.GetString("Currency");
                    user.Balance = reader.GetDecimal("Balance");
                    user.ValidAmount = reader.GetDecimal("validAmount");

                    user.CompanyPercent = reader.GetDecimal("CompanyPercent");
                    user.CompanyCommission = reader.GetDecimal("CompanyCommission");
                    user.SubCompany = reader.GetString("SubCompany");
                    user.SubCompanyPercent = reader.GetDecimal("SubCompanyPercent");


                    user.SubCompanyCommission = reader.GetDecimal("SubCompanyCommission");
                    user.Partner = reader.GetString("Partner");
                    user.PartnerPercent = reader.GetDecimal("PartnerPercent");
                    user.PartnerCommission = reader.GetDecimal("PartnerCommission");
                    user.GeneralAgent = reader.GetString("GeneralAgent");

                    user.GeneralAgentPercent = reader.GetDecimal("GeneralAgentPercent");
                    user.GeneralAgentCommission = reader.GetDecimal("GeneralAgentCommission");
                    user.Agent = reader.GetString("Agent");
                    user.AgentPercent = reader.GetDecimal("AgentPercent");

                    user.AgentCommission = reader.GetDecimal("AgentCommission");
                    user.Percent = reader.GetDecimal("Percent");
                    user.Commission = reader.GetDecimal("Commission");
                    user.Credit = reader.GetDecimal("Credit");
                    user.UserLevel = reader.GetString("UserLevel");
                    user.Coefficient = reader.GetDecimal("coefficient");
                    user.ItemMin = reader.GetDecimal("ItemMin");
                    user.ItemMax = reader.GetDecimal("ItemMax");
                    user.ItemsMax = reader.GetDecimal("ItemsMax");
                    user.Status = reader.GetInt16("Status");
                    user.FirstName = reader.GetString("FirstName");
                    user.LastName = reader.GetString("LastName");

                    user.Mobile = reader.GetString("Mobile");
                    user.Demo = reader.GetString("demo");
                    user.LastLoginTime = reader.GetDateTime("LastLoginTime");
                    user.nicheng = reader.GetString("nicheng");
                    user.Wincoins = reader.GetDecimal("Wincoins");
                    try
                    {
                        user.parentcode = reader.GetString("parentcode");
                    }
                    catch (Exception)
                    {

                        user.parentcode = "";
                    }

                    reader.Close();
                    UpdateLoginTime(user.ID, user.Key);

                    con = true;
                }
                else
                {
                    reader.Close();
                    user = null;
                }

            }
            return con;
        }
        /// <summary>
        /// 获取会员中心数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userName"></param>
        /// <param name="status"></param>
        /// <param name="regTime1"></param>
        /// <param name="regTime2"></param>
        /// <param name="loginTime1"></param>
        /// <param name="loginTime2"></param>
        /// <param name="agent"></param>
        /// <param name="ip"></param>
        /// <param name="tel"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static string getAllCount(string name, string userName, string status, string regTime1, string regTime2, string loginTime1, string loginTime2, string agent, string ip, string tel, string email)
        {
            string sqlStr = "";
            string subSql = "";
            name = Util.SecurityHelper.InputValue(name);
            userName = Util.SecurityHelper.InputValue(userName);
            status = Util.SecurityHelper.InputValue(status);
            regTime1 = Util.SecurityHelper.InputValue(regTime1);
            regTime2 = Util.SecurityHelper.InputValue(regTime2);
            loginTime1 = Util.SecurityHelper.InputValue(loginTime1);
            loginTime2 = Util.SecurityHelper.InputValue(loginTime2);
            agent = Util.SecurityHelper.InputValue(agent);
            ip = Util.SecurityHelper.InputValue(ip);
            tel = Util.SecurityHelper.InputValue(tel);
            email = Util.SecurityHelper.InputValue(email);

            if (!string.IsNullOrEmpty(name))
            {
                subSql += " and name like '%" + name + "%' ";
            }
            if (!string.IsNullOrEmpty(userName))
            {
                subSql += " and username like '%" + userName + "%' ";
            }
            if (!string.IsNullOrEmpty(status))
            {
                subSql += " and status=" + status;
            }
            if (!string.IsNullOrEmpty(regTime1) & !string.IsNullOrEmpty(regTime2))
            {
                subSql += " and RegistrationTime>='" + regTime1 + "' and RegistrationTime<='" + regTime2 + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(loginTime1) & !string.IsNullOrEmpty(loginTime2))
            {
                subSql += " and LastLoginTime>='" + loginTime1 + "' and LastLoginTime<='" + loginTime2 + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(agent))
            {
                subSql += " and agent='" + agent + "' ";
            }
            if (!string.IsNullOrEmpty(ip))
            {
                subSql += " and LastLoginIP='" + ip + "' ";
            }
            if (!string.IsNullOrEmpty(tel))
            {
                subSql += " and tel like '%" + tel + "%' ";
            }
            if (!string.IsNullOrEmpty(email))
            {
                subSql += " and email like '%" + email + "%' ";
            }


            if (subSql == "")
            {
                return "";
            }
            sqlStr = "select count(*) from user where 1=1 " + subSql + " order by ID desc";
            return MySqlHelper.ExecuteScalar(sqlStr).ToString();
          //  return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sqlStr));
        }

        #region 新代理明细查询       
        /// <summary>
        /// 代理佣金计算表
        /// </summary>
        /// <param name="username"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        private string GetAgentInfo(string username, string time1, string time2)
        {
            StringBuilder GetSql = new StringBuilder();
           
            GetSql.Append("select  (select count(*) from user where RegistrationTime>='" + time1 + "' and RegistrationTime<='" + time2 + " 23:59:59'  and Agent='" + username + "') as regcount"); //注册会员人数
            GetSql.Append(",(select count(distinct A. username)   from billnoticehistory  as A left join user as B on A.username=B.username where A.type='1' and A.status='2'  and (A.UpdateTime>='" + time1 + "'  and A.UpdateTime<='" + time2 + " 23:59:59') and  B.agent='" + username + "') as CGusercount");//此时间内代理所有存款会员
            //GetSql.Append(",(select count(distinct  A.username) from billnoticehistory as A left join user as B on A.username=B.username where A.type='1' and A.status='2'  and B.agent='" + username + "' and A.Amount>=10000 and (A.UpdateTime >='" + time1 + "' and A.UpdateTime<='" + time2 + " 23:59:59' )) as Heagentcount ");//此时间内此代理活跃会员(此时间存款达到1w)
            GetSql.Append(",(select sum(handle) from " + GetgameinfoData(time1, time2) + " as A left join user as B on A.login=B.username where  B.Agent='" + username + "' and enddate >='" + time1 + "' and enddate<='" + time2 + " 23:59:59') as agentcount ");//此时间内此代理所有会员有效投注额
            //GetSql.Append(",(select sum(hold)*-1 from " + GetgameinfoData(time1, time2) + " as A left join user as B on A.login=B.username where  B.Agent='" + username + "' and date_format(A.enddate,'%Y-%m')=date_format(DATE_SUB(curdate(), INTERVAL 1 MONTH),'%Y-%m') ) as Upagentamount");
            //GetSql.Append(",(select sum(Amount) from billnoticehistory as A left join user as B on A.username=B.username where A.type='3' and A.status='2'  and B.agent='" + username + "' and date_format(A.UpdateTime,'%Y-%m')=date_format(DATE_SUB(curdate(), INTERVAL 1 MONTH),'%Y-%m')) as UpHLamount");  
            //GetSql.Append(",(select sum(Amount) from billnoticehistory as A left join user as B on A.username=B.username where A.type='4' and A.status='2'  and B.agent='" + username + "' and date_format(A.UpdateTime,'%Y-%m')=date_format(DATE_SUB(curdate(), INTERVAL 1 MONTH),'%Y-%m')) as UpFSamount");  
            //GetSql.Append(",(select sum(Amount) from billnoticehistory as A left join user as B on A.username=B.username where A.type='8' and A.status='2'  and B.agent='" + username + "' and date_format(A.UpdateTime,'%Y-%m')=date_format(DATE_SUB(curdate(), INTERVAL 1 MONTH),'%Y-%m')) as UpYBamount");  
            GetSql.Append(",(select percent from agent where username='" + username + "') as agentpercent "); //代理占成
            GetSql.Append(",(select sum(Amount) from billnoticehistory as A left join user as B on A.username=B.username where A.type='1' and A.status='2'  and B.agent='" + username + "' and (A.UpdateTime >='" + time1 + "'  and A.UpdateTime<='" + time2 + " 23:59:59')) as agentCgamount");//总存款
            GetSql.Append(",(select sum(Amount) from billnoticehistory as A left join user as B on A.username=B.username where A.type='2' and A.status='2'  and B.agent='" + username + "' and (A.UpdateTime >='" + time1 + "'  and A.UpdateTime<='" + time2 + " 23:59:59')) as agentQgamount");//总取款


            GetSql.Append(",(select sum(Amount) from billnoticehistory as A left join user as B on A.username=B.username where A.type='3' and A.status='2'  and B.agent='" + username + "' and (A.UpdateTime >='" + time1 + "'  and A.UpdateTime<='" + time2 + " 23:59:59')) as agentHLamount");//代理总红利润
            GetSql.Append(",(select sum(Amount) from billnoticehistory as A left join user as B on A.username=B.username where A.type='4' and A.status='2'  and B.agent='" + username + "' and (A.UpdateTime >='" + time1 + "'  and A.UpdateTime<='" + time2 + " 23:59:59')) as agentFSamount");//代理总返水
            GetSql.Append(",(select sum(Amount) from billnoticehistory as A left join user as B on A.username=B.username where A.type='8' and A.status='2'  and B.agent='" + username + "' and (A.UpdateTime >='" + time1 + "'  and A.UpdateTime<='" + time2 + " 23:59:59')) as agentYBamount");//代理总赢币
            GetSql.Append(",(select sum(hold)*-1 from " + GetgameinfoData(time1, time2) + " as A left join user as B on A.login=B.username where  B.Agent='" + username + "'   and enddate >='" + time1 + "' and enddate<='" + time2 + " 23:59:59') as agentamount");  //此时间内代理输赢

            string json = "";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(GetSql.ToString()))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }

            return json == "]" ? string.Empty : json;   

          
        }

        private string GetgameinfoData(string time1, string time2)
        {
           
            StringBuilder datas = new StringBuilder();
            //datas.Append("(select ea_gameinfo1.id,ea_gameinfo1.gameid,ea_gameinfo1.login,ea_gameinfo1.gamecode,ea_gameinfo1.dealcode,ea_gameinfo1.status,ea_gameinfo1.startdate,ea_gameinfo1.enddate,ea_gameinfo1.hold,ea_gameinfo1.handle,ea_gameinfo1.bet_amount,ea_gameinfo1.payout_amount,ea_gameinfo1.result,ea_gameinfo1.bank,ea_gameinfo1.player,ea_gameinfo1.tie,ea_gameinfo1.bankdp,ea_gameinfo1.playerdp,ea_gameinfo1.bankodd,ea_gameinfo1.bankeven,ea_gameinfo1.playerodd,ea_gameinfo1.playereven,ea_gameinfo1.big,ea_gameinfo1.small,ea_gameinfo1.super6 from ea_gameinfo1 where ea_gameinfo1.enddate >='" + time1 + "' and ea_gameinfo1.enddate<='" + time2 + " 23:59:59'");
            //datas.Append(" union all ");
            //datas.Append("select ea_gameinfo90002.id,ea_gameinfo90002.gameid,ea_gameinfo90002.login,ea_gameinfo90002.gamecode,ea_gameinfo90002.dealcode,ea_gameinfo90002.status,ea_gameinfo90002.startdate,ea_gameinfo90002.enddate,ea_gameinfo90002.hold,ea_gameinfo90002.handle,ea_gameinfo90002.bet_amount,ea_gameinfo90002.payout_amount,ea_gameinfo90002.result,ea_gameinfo90002.bank,ea_gameinfo90002.player,ea_gameinfo90002.tie,ea_gameinfo90002.bankdp,ea_gameinfo90002.playerdp,ea_gameinfo90002.bankodd,ea_gameinfo90002.bankeven,ea_gameinfo90002.playerodd,ea_gameinfo90002.playereven,ea_gameinfo90002.big,ea_gameinfo90002.small,ea_gameinfo90002.super6 FROM ea_gameinfo90002 where ea_gameinfo90002.enddate >='" + time1 + "' and ea_gameinfo90002.enddate<='" + time2 + " 23:59:59'");
            //datas.Append(" union all ");
            //datas.Append("select ea_gameinfo90001.id,ea_gameinfo90001.gameid,ea_gameinfo90001.login,ea_gameinfo90001.gamecode,ea_gameinfo90001.dealcode,ea_gameinfo90001.status,ea_gameinfo90001.startdate,ea_gameinfo90001.enddate,ea_gameinfo90001.hold,ea_gameinfo90001.handle,ea_gameinfo90001.bet_amount,ea_gameinfo90001.payout_amount,ea_gameinfo90001.result,ea_gameinfo90001.bank,ea_gameinfo90001.player,ea_gameinfo90001.tie,ea_gameinfo90001.bankdp,ea_gameinfo90001.playerdp,ea_gameinfo90001.bankodd,ea_gameinfo90001.bankeven,ea_gameinfo90001.playerodd,ea_gameinfo90001.playereven,ea_gameinfo90001.big,ea_gameinfo90001.small,ea_gameinfo90001.super6 FROM ea_gameinfo90001  where ea_gameinfo90001.enddate >='" + time1 + "' and ea_gameinfo90001.enddate<='" + time2 + " 23:59:59'");
            //datas.Append(" union all ");
            //datas.Append("select ea_gameinfo70001.id,ea_gameinfo70001.gameid,ea_gameinfo70001.login,ea_gameinfo70001.gamecode,ea_gameinfo70001.dealcode,ea_gameinfo70001.status,ea_gameinfo70001.startdate,ea_gameinfo70001.enddate,ea_gameinfo70001.hold,ea_gameinfo70001.handle,ea_gameinfo70001.bet_amount,ea_gameinfo70001.payout_amount,ea_gameinfo70001.result,ea_gameinfo70001.bank,ea_gameinfo70001.player,ea_gameinfo70001.tie,ea_gameinfo70001.bankdp,ea_gameinfo70001.playerdp,ea_gameinfo70001.bankodd,ea_gameinfo70001.bankeven,ea_gameinfo70001.playerodd,ea_gameinfo70001.playereven,ea_gameinfo70001.big,ea_gameinfo70001.small,ea_gameinfo70001.super6 from ea_gameinfo70001  where ea_gameinfo70001.enddate >='" + time1 + "' and ea_gameinfo70001.enddate<='" + time2 + " 23:59:59'");
            //datas.Append(" union all ");
            //datas.Append("select ea_gameinfo10002.id,ea_gameinfo10002.gameid,ea_gameinfo10002.login,ea_gameinfo10002.gamecode,ea_gameinfo10002.dealcode,ea_gameinfo10002.status,ea_gameinfo10002.startdate,ea_gameinfo10002.enddate,ea_gameinfo10002.hold,ea_gameinfo10002.handle,ea_gameinfo10002.bet_amount,ea_gameinfo10002.payout_amount,ea_gameinfo10002.result,ea_gameinfo10002.bank,ea_gameinfo10002.player,ea_gameinfo10002.tie,ea_gameinfo10002.bankdp,ea_gameinfo10002.playerdp,ea_gameinfo10002.bankodd,ea_gameinfo10002.bankeven,ea_gameinfo10002.playerodd,ea_gameinfo10002.playereven,ea_gameinfo10002.big,ea_gameinfo10002.small,ea_gameinfo10002.super6 from ea_gameinfo10002  where ea_gameinfo10002.enddate >='" + time1 + "' and ea_gameinfo10002.enddate<='" + time2 + " 23:59:59'");
            //datas.Append(" union all ");
            //datas.Append("select ea_gameinfo10001.id,ea_gameinfo10001.gameid,ea_gameinfo10001.login,ea_gameinfo10001.gamecode,ea_gameinfo10001.dealcode,ea_gameinfo10001.status,ea_gameinfo10001.startdate,ea_gameinfo10001.enddate,ea_gameinfo10001.hold,ea_gameinfo10001.handle,ea_gameinfo10001.bet_amount,ea_gameinfo10001.payout_amount,ea_gameinfo10001.result,ea_gameinfo10001.bank,ea_gameinfo10001.player,ea_gameinfo10001.tie,ea_gameinfo10001.bankdp,ea_gameinfo10001.playerdp,ea_gameinfo10001.bankodd,ea_gameinfo10001.bankeven,ea_gameinfo10001.playerodd,ea_gameinfo10001.playereven,ea_gameinfo10001.big,ea_gameinfo10001.small,ea_gameinfo10001.super6 from ea_gameinfo10001  where ea_gameinfo10001.enddate >='" + time1 + "' and ea_gameinfo10001.enddate<='" + time2 + " 23:59:59')");
            datas.Append("(select login,status,enddate,hold,handle,bet_amount,payout_amount from   gameinforeport_ea where  gameinforeport_ea.enddate >='" + time1 + "' and gameinforeport_ea.enddate<='" + time2 + " 23:59:59' ");
            datas.Append(" union all ");
            datas.Append("select login,status,enddate,hold,handle,bet_amount,payout_amount from   pt_gameinfo where  pt_gameinfo.enddate >='" + time1 + "' and pt_gameinfo.enddate<='" + time2 + " 23:59:59' )");
            return datas.ToString();

        }
        private string GetgameinfoData2()
        {

            StringBuilder datas = new StringBuilder();
            //datas.Append("(select ea_gameinfo1.id,ea_gameinfo1.gameid,ea_gameinfo1.login,ea_gameinfo1.gamecode,ea_gameinfo1.dealcode,ea_gameinfo1.status,ea_gameinfo1.startdate,ea_gameinfo1.enddate,ea_gameinfo1.hold,ea_gameinfo1.handle,ea_gameinfo1.bet_amount,ea_gameinfo1.payout_amount,ea_gameinfo1.result,ea_gameinfo1.bank,ea_gameinfo1.player,ea_gameinfo1.tie,ea_gameinfo1.bankdp,ea_gameinfo1.playerdp,ea_gameinfo1.bankodd,ea_gameinfo1.bankeven,ea_gameinfo1.playerodd,ea_gameinfo1.playereven,ea_gameinfo1.big,ea_gameinfo1.small,ea_gameinfo1.super6 from ea_gameinfo1 ");
            //datas.Append(" union all ");
            //datas.Append("select ea_gameinfo90002.id,ea_gameinfo90002.gameid,ea_gameinfo90002.login,ea_gameinfo90002.gamecode,ea_gameinfo90002.dealcode,ea_gameinfo90002.status,ea_gameinfo90002.startdate,ea_gameinfo90002.enddate,ea_gameinfo90002.hold,ea_gameinfo90002.handle,ea_gameinfo90002.bet_amount,ea_gameinfo90002.payout_amount,ea_gameinfo90002.result,ea_gameinfo90002.bank,ea_gameinfo90002.player,ea_gameinfo90002.tie,ea_gameinfo90002.bankdp,ea_gameinfo90002.playerdp,ea_gameinfo90002.bankodd,ea_gameinfo90002.bankeven,ea_gameinfo90002.playerodd,ea_gameinfo90002.playereven,ea_gameinfo90002.big,ea_gameinfo90002.small,ea_gameinfo90002.super6 FROM ea_gameinfo90002 ");
            //datas.Append(" union all ");
            //datas.Append("select ea_gameinfo90001.id,ea_gameinfo90001.gameid,ea_gameinfo90001.login,ea_gameinfo90001.gamecode,ea_gameinfo90001.dealcode,ea_gameinfo90001.status,ea_gameinfo90001.startdate,ea_gameinfo90001.enddate,ea_gameinfo90001.hold,ea_gameinfo90001.handle,ea_gameinfo90001.bet_amount,ea_gameinfo90001.payout_amount,ea_gameinfo90001.result,ea_gameinfo90001.bank,ea_gameinfo90001.player,ea_gameinfo90001.tie,ea_gameinfo90001.bankdp,ea_gameinfo90001.playerdp,ea_gameinfo90001.bankodd,ea_gameinfo90001.bankeven,ea_gameinfo90001.playerodd,ea_gameinfo90001.playereven,ea_gameinfo90001.big,ea_gameinfo90001.small,ea_gameinfo90001.super6 FROM ea_gameinfo90001  ");
            //datas.Append(" union all ");
            //datas.Append("select ea_gameinfo70001.id,ea_gameinfo70001.gameid,ea_gameinfo70001.login,ea_gameinfo70001.gamecode,ea_gameinfo70001.dealcode,ea_gameinfo70001.status,ea_gameinfo70001.startdate,ea_gameinfo70001.enddate,ea_gameinfo70001.hold,ea_gameinfo70001.handle,ea_gameinfo70001.bet_amount,ea_gameinfo70001.payout_amount,ea_gameinfo70001.result,ea_gameinfo70001.bank,ea_gameinfo70001.player,ea_gameinfo70001.tie,ea_gameinfo70001.bankdp,ea_gameinfo70001.playerdp,ea_gameinfo70001.bankodd,ea_gameinfo70001.bankeven,ea_gameinfo70001.playerodd,ea_gameinfo70001.playereven,ea_gameinfo70001.big,ea_gameinfo70001.small,ea_gameinfo70001.super6 from ea_gameinfo70001  ");
            //datas.Append(" union all ");
            //datas.Append("select ea_gameinfo10002.id,ea_gameinfo10002.gameid,ea_gameinfo10002.login,ea_gameinfo10002.gamecode,ea_gameinfo10002.dealcode,ea_gameinfo10002.status,ea_gameinfo10002.startdate,ea_gameinfo10002.enddate,ea_gameinfo10002.hold,ea_gameinfo10002.handle,ea_gameinfo10002.bet_amount,ea_gameinfo10002.payout_amount,ea_gameinfo10002.result,ea_gameinfo10002.bank,ea_gameinfo10002.player,ea_gameinfo10002.tie,ea_gameinfo10002.bankdp,ea_gameinfo10002.playerdp,ea_gameinfo10002.bankodd,ea_gameinfo10002.bankeven,ea_gameinfo10002.playerodd,ea_gameinfo10002.playereven,ea_gameinfo10002.big,ea_gameinfo10002.small,ea_gameinfo10002.super6 from ea_gameinfo10002  ");
            //datas.Append(" union all ");
            //datas.Append("select ea_gameinfo10001.id,ea_gameinfo10001.gameid,ea_gameinfo10001.login,ea_gameinfo10001.gamecode,ea_gameinfo10001.dealcode,ea_gameinfo10001.status,ea_gameinfo10001.startdate,ea_gameinfo10001.enddate,ea_gameinfo10001.hold,ea_gameinfo10001.handle,ea_gameinfo10001.bet_amount,ea_gameinfo10001.payout_amount,ea_gameinfo10001.result,ea_gameinfo10001.bank,ea_gameinfo10001.player,ea_gameinfo10001.tie,ea_gameinfo10001.bankdp,ea_gameinfo10001.playerdp,ea_gameinfo10001.bankodd,ea_gameinfo10001.bankeven,ea_gameinfo10001.playerodd,ea_gameinfo10001.playereven,ea_gameinfo10001.big,ea_gameinfo10001.small,ea_gameinfo10001.super6 from ea_gameinfo10001  )");
            datas.Append("(select login,status,enddate,hold,handle,bet_amount,payout_amount from   gameinforeport_ea");
             datas.Append(" union all ");
             datas.Append("select login,status,enddate,hold,handle,bet_amount,payout_amount from   pt_gameinfo)");
            return datas.ToString();

        }
        public string GetSumAgentInfo(string username, string time1, string time2)
        {
            int regcount = 0;//注册会员人数
            int CGusercount = 0;//此时间内代理所有存款会员  
          //  int Heagentcount = 0;//此时间内此代理活跃会员(此时间存款达到1w)
            decimal agentcount = 0;//此时间内此代理所有会员有效投注额
            //decimal Upagentamount = 0;//上月输赢
            //decimal UpHLamount = 0;//上月红利
            //decimal UpFSamount = 0;
            //decimal UpYBamount = 0;
            decimal agentpercent = 0; //代理占成
            decimal agentamount = 0;  //此时间内代理输赢
            decimal agentHLamount = 0;//代理总红利润
            decimal agentFSamount = 0;//代理总返水
            decimal agentYBamount = 0;//总赢币
            decimal agentYXamount = 0;
            decimal ylamount = 0;//此时间内毛利
            decimal evylamount = 0; //每个代理毛利
            decimal agentQgamount = 0;
            decimal agentCgamount = 0;
            DataTable dt;
            DataTable dt1;

            string agent;
            string Agetnsql = "select username from agent  where UserName='" + username + "'";
            dt = MySqlHelper.ExecuteDataTable(Agetnsql, null);
            if (dt.Rows.Count > 0)
            {
              
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    agent = dt.Rows[i]["username"].ToString();
                    if (agent != "" && agent != null)
                    {

                        dt1 = GetInfos(agent, time1, time2);
                        if (dt1.Rows.Count>0)
                        {
                            regcount += (dt1.Rows[0]["regcount"] == DBNull.Value ? 0 : Convert.ToInt32(dt1.Rows[0]["regcount"])); //总代注册人数据
                            CGusercount += (dt1.Rows[0]["CGusercount"] == DBNull.Value ? 0 : Convert.ToInt32(dt1.Rows[0]["CGusercount"]));//总代时间内代理所有存款会员  
                           // Heagentcount += (dt1.Rows[0]["Heagentcount"] == DBNull.Value ? 0 : Convert.ToInt32(dt1.Rows[0]["Heagentcount"]));//总活跃人数
                            agentcount += (dt1.Rows[0]["agentcount"] == DBNull.Value ? 0 : Convert.ToDecimal(dt1.Rows[0]["agentcount"])); //总有效投注额

                            //Upagentamount += (dt1.Rows[0]["Upagentamount"] == DBNull.Value ? 0 : Convert.ToDecimal(dt1.Rows[0]["Upagentamount"])); //上月总输赢
                            //UpHLamount += (dt1.Rows[0]["UpHLamount"] == DBNull.Value ? 0 : Convert.ToDecimal(dt1.Rows[0]["UpHLamount"])); //上月总红利
                            //UpFSamount += (dt1.Rows[0]["UpFSamount"] == DBNull.Value ? 0 : Convert.ToDecimal(dt1.Rows[0]["UpFSamount"])); //上月总返水
                            //UpYBamount += (dt1.Rows[0]["UpYBamount"] == DBNull.Value ? 0 : Convert.ToDecimal(dt1.Rows[0]["UpYBamount"])); //上月总赢币

                            agentamount += (dt1.Rows[0]["agentamount"] == DBNull.Value ? 0 : Convert.ToDecimal(dt1.Rows[0]["agentamount"]));//此时间内总代理输赢
                            evylamount = (dt1.Rows[0]["agentamount"] == DBNull.Value ? 0 : Convert.ToDecimal(dt1.Rows[0]["agentamount"]));//此时间内总代理输赢
                            agentHLamount += (dt1.Rows[0]["agentHLamount"] == DBNull.Value ? 0 : Convert.ToDecimal(dt1.Rows[0]["agentHLamount"]));//此时间内总代理红利
                            agentFSamount += (dt1.Rows[0]["agentFSamount"] == DBNull.Value ? 0 : Convert.ToDecimal(dt1.Rows[0]["agentFSamount"]));//此时间内总代理返水
                            agentYBamount += (dt1.Rows[0]["agentYBamount"] == DBNull.Value ? 0 : Convert.ToDecimal(dt1.Rows[0]["agentYBamount"]));//此时间内总代理赢币
                            agentYXamount += (dt1.Rows[0]["agentYXamount"] == DBNull.Value ? 0 : Convert.ToDecimal(dt1.Rows[0]["agentYXamount"]));//总有效投注额
                            agentpercent =(dt1.Rows[0]["agentpercent"] == DBNull.Value ? 0 : Convert.ToDecimal(dt1.Rows[0]["agentpercent"]));//此时间内占成
                            agentCgamount = (dt1.Rows[0]["agentCgamount"] == DBNull.Value ? 0 : Convert.ToDecimal(dt1.Rows[0]["agentCgamount"]));
                            agentQgamount = (dt1.Rows[0]["agentQgamount"] == DBNull.Value ? 0 : Convert.ToDecimal(dt1.Rows[0]["agentQgamount"]));


                            ylamount += (evylamount * agentpercent);//每个代理毛利=此时间内代理输赢*占成
                        }
                      


                    }
                }
                string json = "[{";
                json += "\"regcount\":\"" + regcount.ToString() + "\",";
                json += "\"CGusercount\":\"" + CGusercount.ToString() + "\",";
               // json += "\"Heagentcount\":\"" + Heagentcount.ToString() + "\",";
                json += "\"agentcount\":\"" + agentcount.ToString() + "\",";
                //json += "\"Upagentamount\":\"" + Upagentamount.ToString() + "\",";
                //json += "\"UpHLamount\":\"" + UpHLamount.ToString() + "\",";
                //json += "\"UpFSamount\":\"" + UpFSamount.ToString() + "\",";
                //json += "\"UpYBamount\":\"" + UpYBamount.ToString() + "\",";
                json += "\"agentamount\":\"" + agentamount.ToString() + "\",";
                json += "\"agentHLamount\":\"" + agentHLamount.ToString() + "\",";
                json += "\"agentFSamount\":\"" + agentFSamount.ToString() + "\",";
                json += "\"agentYBamount\":\"" + agentYBamount.ToString() + "\",";
                json += "\"agentYXamount\":\"" + agentYXamount.ToString() + "\",";
                json += "\"agentCgamount\":\"" + agentCgamount.ToString() + "\",";
                json += "\"agentQgamount\":\"" + agentQgamount.ToString() + "\",";
                json += "\"agentpercent\":\"" + agentpercent.ToString() + "\",";
                
                json += "\"ylamount\":\"" + ylamount.ToString() + "\"";
                json += "}]";
                return json;
            }
            else
            {
              return  GetAgentInfo(username, time1, time2);
            }

           

        }

        private DataTable GetInfos(string username,string time1,string time2)
        {
            StringBuilder GetSql = new StringBuilder();
            GetSql.Append("select  (select count(*) from user where RegistrationTime>='" + time1 + "' and RegistrationTime<='" + time2 + " 23:59:59'  and Agent='" + username + "') as regcount"); //注册会员人数
            GetSql.Append(",(select count(distinct A. username)   from billnoticehistory  as A left join user as B on A.username=B.username where A.type='1' and A.status='2'  and (A.UpdateTime>='" + time1 + "'  and A.UpdateTime<='" + time2 + " 23:59:59') and  B.agent='" + username + "') as CGusercount");//此时间内代理所有存款会员
            //GetSql.Append(",(select count(distinct  A.username) from billnoticehistory as A left join user as B on A.username=B.username where A.type='1' and A.status='2'  and B.agent='" + username + "' and A.Amount>=10000 and (A.UpdateTime >='" + time1 + "' and A.UpdateTime<='" + time2 + " 23:59:59' )) as Heagentcount ");//此时间内此代理活跃会员(此时间存款达到1w)
            GetSql.Append(",(select sum(handle) from " + GetgameinfoData(time1, time2) + " as A left join user as B on A.login=B.username where  B.Agent='" + username + "' and enddate >='" + time1 + "' and enddate<='" + time2 + " 23:59:59') as agentcount ");//此时间内此代理所有会员有效投注额
            //GetSql.Append(",(select sum(hold)*-1 from " + GetgameinfoData(time1, time2) + " as A left join user as B on A.login=B.username where  B.Agent='" + username + "' and date_format(A.enddate,'%Y-%m')=date_format(DATE_SUB(curdate(), INTERVAL 1 MONTH),'%Y-%m') ) as Upagentamount");
            //GetSql.Append(",(select sum(Amount) from billnoticehistory as A left join user as B on A.username=B.username where A.type='3' and A.status='2'  and B.agent='" + username + "' and date_format(A.UpdateTime,'%Y-%m')=date_format(DATE_SUB(curdate(), INTERVAL 1 MONTH),'%Y-%m')) as UpHLamount");
            //GetSql.Append(",(select sum(Amount) from billnoticehistory as A left join user as B on A.username=B.username where A.type='4' and A.status='2'  and B.agent='" + username + "' and date_format(A.UpdateTime,'%Y-%m')=date_format(DATE_SUB(curdate(), INTERVAL 1 MONTH),'%Y-%m')) as UpFSamount");
            //GetSql.Append(",(select sum(Amount) from billnoticehistory as A left join user as B on A.username=B.username where A.type='8' and A.status='2'  and B.agent='" + username + "' and date_format(A.UpdateTime,'%Y-%m')=date_format(DATE_SUB(curdate(), INTERVAL 1 MONTH),'%Y-%m')) as UpYBamount");
            GetSql.Append(",(select percent from agent where username='" + username + "') as agentpercent "); //代理占成
            GetSql.Append(",(select sum(Amount) from billnoticehistory as A left join user as B on A.username=B.username where A.type='1' and A.status='2'  and B.agent='" + username + "' and (A.UpdateTime >='" + time1 + "'  and A.UpdateTime<='" + time2 + " 23:59:59')) as agentCgamount");//代理总存
            GetSql.Append(",(select sum(Amount) from billnoticehistory as A left join user as B on A.username=B.username where A.type='2' and A.status='2'  and B.agent='" + username + "' and (A.UpdateTime >='" + time1 + "'  and A.UpdateTime<='" + time2 + " 23:59:59')) as agentQgamount");//代理总取


            GetSql.Append(",(select sum(Amount) from billnoticehistory as A left join user as B on A.username=B.username where A.type='3' and A.status='2'  and B.agent='" + username + "' and (A.UpdateTime >='" + time1 + "'  and A.UpdateTime<='" + time2 + " 23:59:59')) as agentHLamount");//代理总红利润
            GetSql.Append(",(select sum(Amount) from billnoticehistory as A left join user as B on A.username=B.username where A.type='4' and A.status='2'  and B.agent='" + username + "' and (A.UpdateTime >='" + time1 + "'  and A.UpdateTime<='" + time2 + " 23:59:59')) as agentFSamount");//代理总返水
            GetSql.Append(",(select sum(Amount) from billnoticehistory as A left join user as B on A.username=B.username where A.type='8' and A.status='2'  and B.agent='" + username + "' and (A.UpdateTime >='" + time1 + "'  and A.UpdateTime<='" + time2 + " 23:59:59')) as agentYBamount");//代理总赢币
            GetSql.Append(",(select sum(A.validamount) from billnoticehistory as A left join user as B on A.username=B.username where A.type='4' and A.status='2'  and B.agent='" + username + "' and (A.UpdateTime >='" + time1 + "'  and A.UpdateTime<='" + time2 + " 23:59:59')) as agentYXamount");//代理有效投注额
            GetSql.Append(",(select sum(hold)*-1 from " + GetgameinfoData(time1, time2) + " as A left join user as B on A.login=B.username where  B.Agent='" + username + "'   and enddate >='" + time1 + "' and enddate<='" + time2 + " 23:59:59') as agentamount");  //此时间内代理输赢
            DataTable dt = DAL.MySqlHelper.ExecuteDataTable(GetSql.ToString(), null);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 代理每月费用支出(所有)
        /// </summary>
        /// <param name="agentname"></param>
        /// <returns>SYamount:输赢,HLamount:红利，FSamount:返水,Ylamount:赢币,YLamount:赢利</returns>
        public string GetEVnMonInfo(string agentname)
        {
            DataTable dts = new DataTable();
            string agentnames = "";
           
            StringBuilder GetSql = new StringBuilder();
            string Agetnsql = "select count(*) from agent  where username='" + agentname + "'";
            dts = MySqlHelper.ExecuteDataTable(Agetnsql, null);
            if (dts.Rows.Count > 0)
            {
               
                GetSql.Append("select a.datetime,sum(a.SYamount) as SYamount,sum(a.Qgamount) as Qgamount,sum(a.HLamount) as HLamount,sum(a.FSamount) as FSamount ,sum(a.YBamount) as Ylamount, (sum(a.SYamount) -sum(a.HLamount)-sum(a.FSamount) -sum(a.YBamount)) as YLamount   from ( ");
                GetSql.Append("select   CONVERT(DATE_FORMAT(A.UpdateTime,'%Y%m') ,CHAR(10))  as datetime,sum(A.Amount) as  SYamount ,0 as Qgamount,0 as HLamount,0 as FSamount ,0 as YBamount   from billnoticehistory as A ");
                GetSql.Append("left join user as B on A.username=B.username where   A.type='1' and A.Status='2'  and  B.Agent in ('" + agentname + "') "); //存款总
                GetSql.Append("group by datetime union ");
                GetSql.Append("select   CONVERT(DATE_FORMAT(A.UpdateTime,'%Y%m') ,CHAR(10))  as datetime,0 as  SYamount ,sum(A.Amount) as Qgamount,0 as HLamount,0 as FSamount ,0 as YBamount   from billnoticehistory as A ");
                GetSql.Append("left join user as B on A.username=B.username where   A.type='2' and A.Status='2'  and  B.Agent in ('" + agentname + "') "); //取款总

                GetSql.Append("group by datetime union ");
                GetSql.Append("select   CONVERT(DATE_FORMAT(A.UpdateTime,'%Y%m') ,CHAR(10))  as datetime, 0 as SYamount,0 as Qgamount,sum(A.Amount) as HLamount,0 as FSamount,0 as YBamount  from billnoticehistory as A ");
                GetSql.Append("left join user as B on A.username=B.username where   A.type='3' and A.Status='2'  and  B.Agent in ('" + agentname + "') ");
                GetSql.Append("group by datetime  union  ");
                GetSql.Append("select   CONVERT(DATE_FORMAT(A.UpdateTime,'%Y%m') ,CHAR(10))  as datetime, 0 as SYamount,0 as Qgamount,0 as HLamount,sum(A.Amount)  as FSamount ,0 as YBamount from billnoticehistory as A ");
                GetSql.Append("left join user as B on A.username=B.username where   A.type='4' and A.Status='2'  and  B.Agent in ('" + agentname + "') ");
                GetSql.Append("group by datetime  union  ");
                GetSql.Append("select   CONVERT(DATE_FORMAT(A.UpdateTime,'%Y%m') ,CHAR(10))  as datetime, 0 as SYamount,0 as Qgamount,0  as HLamount,0 as FSamount,sum(A.Amount) as YBamount from billnoticehistory as A ");
                GetSql.Append("left join user as B on A.username=B.username where   A.type='8' and A.Status='2'  and  B.Agent in ('" + agentname + "') ");
                GetSql.Append("group by datetime  ) as a  ");
                GetSql.Append("group by a.datetime  ");

               
            }

            string json = "";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(GetSql.ToString()))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }

            return json == "]" ? string.Empty : json;   

           
      }

        /// <summary>
        /// 代理取款(先查询出绑定帐号，再查此游戏帐号取款成功信息)
        /// </summary>
        /// <param name="agentname"></param>
        /// <returns></returns>
        public string GetQGHis(string agentname)
        {
           string xsqls = "select gameUsername from joiner where username='"+agentname+"'  limit 1 ";
           DataTable dt = MySqlHelper.ExecuteDataTable(xsqls, null);
          if (dt.Rows.Count > 0)
          {
              string username = dt.Rows[0]["gameUsername"].ToString().Trim();

              if (username != "")
              {
                  return GetBillNotice(username, "2", "cn");
              }
              else
                  return "";
          }
          else
          {
              return "";
          }


         
        }


        public string GetBillNotice(string userName, string type, string lan)
        {
            string SQL_SELECT = "select Id as a,UserName as b,Type as c,Amount as d,SubmitTime as e,UpdateTime as f,Status as g,Reason" + lan + " as h,CardNo as i from billnoticehistory where UserName='" + userName + "' and Type ='" + type + "' and status='2'";

            SQL_SELECT += " order by UpdateTime desc";
            string json = "";
            try
            {
                using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT))
                {
                    json = ObjectToJson.ReaderToJson(reader);
                    reader.Close();
                }
            }
            catch (Exception) { }
            return json == "]" ? string.Empty : json;
        }
        /// <summary>
        /// 代理余额跟信息
        /// </summary>
        /// <param name="agentname"></param>
        /// <returns></returns>
        public string GetagentInfo(string agentname)
        {
            StringBuilder GetSql = new StringBuilder();
            GetSql.Append("select  A.username,B.Balance,A.question,A.gameUsername,C.id from joiner as A  left join  user as B on A.gameUsername=B.username  left join banklist as C on A.gameUsername=C.username where A.status='1' and A.username='" + agentname + "' ");
            string json = "";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(GetSql.ToString()))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }

            return json == "]" ? string.Empty : json;
        }
        public bool CheckAgentamount(string agentname,string txtanswer,string Type,string amount,string Status,string Reasoncn,string mark)
        {
            try
            {
                if (agentname=="")
                {
                    return false;
                }
                string Sqls = "select Balance from user where username='" + agentname + "' and answer='" + txtanswer.Trim() + "'";
                DataTable dt = MySqlHelper.ExecuteDataTable(Sqls);
                //int count =Convert.ToInt32(MySqlHelper.ExecuteScalar(Sqls));
                if (dt.Rows.Count > 0)
                {
                    decimal amounts = (dt.Rows[0]["Balance"].ToString() == "" ? 0 : Convert.ToDecimal(dt.Rows[0]["Balance"].ToString()));
                    if (amounts < Convert.ToDecimal(amount.Trim()))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
          

            StringBuilder GetSql = new StringBuilder();
            string Names = "";
            string Currency = "";
            string cardno = "";

            //GetSql.Append("select  A.username,B.amount,A.question from joiner as A left join  agent as B on A.username=B.username where A.status='1' and A.username='" + agentname + "' ");
            string banksql = "select * from banklist where username='" + agentname + "'";
            DataTable dt3 = MySqlHelper.ExecuteDataTable(banksql);
            if (dt3.Rows.Count > 0)
            {
                 Names = dt3.Rows[0]["Name"].ToString();
                 Currency = "RMB";
                 cardno = dt3.Rows[0]["CardNo"].ToString();
            }
            else
            {
                return false;
            }


            string SQL_INSERTBILLNOTICEHISTORY = "insert into billnotice(UserName,Type,Amount,SubmitTime,UpdateTime,Status,Reasoncn,mark,Names,Currency,cardno) values(?UserName,?Type,?Amount,?SubmitTime,?UpdateTime,?Status,?Reasoncn,?mark,?Names,?Currency,?cardno)";
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?UserName",agentname),
                new MySqlParameter("?Type",Type),
                new MySqlParameter("?Amount",amount),
                new MySqlParameter("?SubmitTime",DateTime.Now ),
                new MySqlParameter("?UpdateTime",DateTime.Now ),
                new MySqlParameter("?Status",Status),
                new MySqlParameter("?Reasoncn",Reasoncn),               
                new MySqlParameter("?mark",mark),
                 new MySqlParameter("?Names",Names),
                 new MySqlParameter("?Currency",Currency),
                 new MySqlParameter("?cardno",cardno)
            };
            bool istrue = MySqlHelper.ExecuteNonQuery(SQL_INSERTBILLNOTICEHISTORY, parm) > 0;
            if (istrue == true)
            {
                string sql = "update user set Balance=(Balance-@amount) where username=@agentname";
                MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@amount",amount),
                new MySqlParameter("@agentname",agentname)
                };
                bool istrue2 = MySqlHelper.ExecuteNonQuery(sql, param) > 0;
                if (istrue2 == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

          
        }

        /// <summary>
        /// 获取代理信息
        /// </summary>
        /// <param name="agentname"></param>
        /// <returns></returns>
        public string GetjoinerInfo(string agentname)
        {
            StringBuilder GetSql = new StringBuilder();
            GetSql.Append("select * from joiner  where username='" + agentname + "' and status='1'");
            string json = "";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(GetSql.ToString()))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }

            return json == "]" ? string.Empty : json;
        }


        public bool UpdateAgentInfo(string agentname, string tel, string url, string add)
        {
            string sql = "update joiner set tel=@tel,url=@url,addr=@add where username=@agentname and status=1";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@agentname",agentname),
                 new MySqlParameter("@tel",tel),
                new MySqlParameter("@url",url),
                new MySqlParameter("@add",add)
            };
            return MySqlHelper.ExecuteNonQuery(sql, param) > 0;
        }

        #endregion



        public bool CheckOldPwd(string oldPwd, string agentname)
        {
            string SQL_CHECKOLDPWD = "select count(*) from agent where Password=md5(?password) and username=?agentname and status='1'";
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?password",MySqlDbType.VarChar,32),
                new MySqlParameter("?agentname",MySqlDbType.VarChar,32),
            };
            param[0].Value = oldPwd;
            param[1].Value = agentname;

            return Convert.ToInt32(MySqlHelper.ExecuteScalar(SQL_CHECKOLDPWD, param)) > 0;


        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="newPwd"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool UpdatePassword(string newPwd, string agentname)
        {
            string sqlss = "update agent set Password=md5(?password) where username=?agentname and status='1'";
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?Password",newPwd),
                new MySqlParameter("?agentname",agentname)
            };
            return MySqlHelper.ExecuteNonQuery(sqlss, param) > 0;
        }

        /// <summary>
        /// 取用户申请pt账号、修改密码申请
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="type">类型</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public static string GetPtthing(string username, string type, string status, string time1, string time2)
        {
            username = SecurityHelper.InputValue(username);
            type = SecurityHelper.InputValue(type);
            status = SecurityHelper.InputValue(status);
            time1 = SecurityHelper.InputValue(time1);
            time2 = SecurityHelper.InputValue(time2);
            string sql = "select * from ptthing where 1=1 ";
            string subStr = "";
            if (!string.IsNullOrEmpty(username))
            {
                subStr += " and username='" + username + "' ";
            }
            if (!string.IsNullOrEmpty(type))
            {
                subStr += " and type='" + type + "' ";
            }
            if (!string.IsNullOrEmpty(status))
            {
                subStr += " and status='" + status + "' ";
            }
            if (!string.IsNullOrEmpty(time1) && !string.IsNullOrEmpty(time2))
            {
                subStr += " and date(submittime)>='" + time1 + "' and date(submittime)<='" + time2 + "' ";
            }

            if (string.IsNullOrEmpty(subStr))
            {
                return "";
            }
            else {

                subStr += "  order by submittime  desc ";
            }

            sql += subStr;
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sql));
        }

        /// <summary>
        /// 更新ptthing
        /// </summary>
        /// <param name="status"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool UpdatePtthing(string status, int ID)
        {
            string sql = "update ptthing set status=@status,updatetime=@updatetime where ID=@ID";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@status",status),
                new MySqlParameter("@updatetime",DateTime.Now),
                new MySqlParameter("@ID",ID)
            };
            return MySqlHelper.ExecuteNonQuery(sql,param) > 0;
        }
        
        public static bool UpdateUserStatus(string status, string userName)
        {
            string sql = "update user set Status=@status where UserName=@userName";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@status",status),
                new MySqlParameter("@userName",userName)
            };
            return MySqlHelper.ExecuteNonQuery(sql,param) > 0;
        }

        /// <summary>
        /// 获取PT转账申请
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public static string GetPTbillnoticehistory(string username, string type,string time1,string time2, string status)
        {
            type = SecurityHelper.InputValue(type);
            status = SecurityHelper.InputValue(status);
            username = SecurityHelper.InputValue(username);
            time1 = SecurityHelper.InputValue(time1);
            time2 = SecurityHelper.InputValue(time2);
            string sql = "select * from billnoticehistory where 1=1 ";
            string subStr = "";
            if (!string.IsNullOrEmpty(type))
            {
                subStr += " and type='" + type + "' ";
            }
            if (!string.IsNullOrEmpty(status))
            {
                subStr += " and status='" + status + "' ";
            }
            if (!string.IsNullOrEmpty(username))
            {
                subStr += " and username='" + username + "' ";
            }
            if (!string.IsNullOrEmpty(time1) && !string.IsNullOrEmpty(time2))
            {
                subStr += " and date(SubmitTime)>='" + time1 + "' and date(SubmitTime)<='" + time2 + "' ";
            }
            if (subStr == "")
            {
                return "";
            }
            sql += subStr;
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sql));
        }

        public static string GetPTbillnotice(string username, string type, string time1, string time2)
        {
            type = SecurityHelper.InputValue(type);
            username = SecurityHelper.InputValue(username);
            time1 = SecurityHelper.InputValue(time1);
            time2 = SecurityHelper.InputValue(time2);
            string sql = "select * from billnotice where 1=1 ";
            string subStr = "";
            if (!string.IsNullOrEmpty(type))
            {
                subStr += " and type='" + type + "' ";
            }
            if (!string.IsNullOrEmpty(username))
            {
                subStr += " and username='" + username + "' ";
            }
            if (!string.IsNullOrEmpty(time1) && !string.IsNullOrEmpty(time2))
            {
                subStr += " and date(SubmitTime)>='" + time1 + "' and date(SubmitTime)<='" + time2 + "' ";
            }
            if (subStr == "")
            {
                return "";
            }
            sql += subStr;
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sql));
        }

        public static bool Updatebillnoticehistory(string status, int ID)
        {
            string sql = "update billnoticehistory set status=@status where ID=@ID";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@status",status),
                new MySqlParameter("@ID",ID)
            };
            return MySqlHelper.ExecuteNonQuery(sql, param) > 0;
        }

        public static bool UpdatePtUser(string username, string pass)
        {
            string sql = "update user set ptusername=@ptusername,ptpassword=@ptpassword where username=@username";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@ptusername",username),
                new MySqlParameter("@ptpassword",pass),
                new MySqlParameter("@username",username)
            };
            return MySqlHelper.ExecuteNonQuery(sql, param) > 0;
 
        }

        public static bool UpdatePtPass(string username, string pass)
        {
            string sql = "update user set ptpassword=@ptpassword where ptusername=@ptusername";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@ptpassword",pass),
                new MySqlParameter("@ptusername",username)
            };
            return MySqlHelper.ExecuteNonQuery(sql, param) > 0;

        }

        public static bool Updatgameuser(string agentname,string username)
        {
            string sql = "select gameUsername from joiner where username='" + agentname + "'";
            string namelenths = MySqlHelper.ExecuteScalar(sql).ToString();

            if (namelenths.Length > 0)
            {
                return false;
            }

            string sqls = "update joiner set gameUsername=?username where username=?agentname";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?username",username),
                new MySqlParameter("?agentname",agentname)
            };
            return MySqlHelper.ExecuteNonQuery(sqls, param) > 0; 



        }

        public static string getPTUserInfo()
        {
            StringBuilder GetSql = new StringBuilder();
            GetSql.Append(" select (select count(*) from ptthing where type='1' and status='0') as aa1,");           
            GetSql.Append("(select count(*) from ptthing where type='2' and status='0') as aa2,");
            GetSql.Append("(select count(*) from billnotice where type='12' and status='1') as aa3,");
            GetSql.Append("(select count(*) from billnotice where type='13' and status='1' ) as aa4,");
            GetSql.Append("(select count(*) from billnotice where type='1' and status='1' ) as aa5,");
            GetSql.Append("(select count(*) from billnotice where type='2' and status='1' ) as aa6,");
            GetSql.Append("(select count(*) from billnotice where type='3' and status='1' ) as aa7");

            string json = "";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(GetSql.ToString()))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }

            return json == "]" ? "": json;   
        }
    }
}