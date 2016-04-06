using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Model;
using DAL;
using System.Xml;
namespace BLL
{
		///<sumary>
		///业务逻辑类
		///</sumary>
	public class UserManager
	{
		private static UserService userService=new UserService();

        /// <summary>
        /// 重置会员信用
        /// </summary>
        /// <returns></returns>
        public bool RecoverUserCredit()
        {
            try
            {
                userService.RecoverUserCredit();
                return true;
            }
            catch
            {
                return false;
            }
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
            return userService.UpdateUserLevel(UserLevel, Coefficient, Proportion, userName);
        }

        /// <summary>
        /// 是否存在帐号
        /// By xzz 2010-11-8
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string IsExistUser(string userName)
        {
            DataTable dt = userService.IsExistUser(userName);
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
        public static string UpdatePercent(int ID, double percent)
        {
            if (userService.UpdatePercent(percent, ID))
            {
                return "ok";
            }
            else
            {
                return "更新失败";
            }
        }

        /// <summary>
        /// 修改会员信用
        /// 编写时间: 2010-10-6 14:10
        /// 创建者：Mickey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="credit"></param>
        /// <returns></returns>
        public static bool updateCredit(string id, string credit, string userId, string userCredit, decimal balance)
        {
            if (userService.updateUserCredit(id, credit, balance))
            {
                AgentService agentService = new AgentService();
                return agentService.updateUserCredit(userId, userCredit);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取除指定ID 以外的会员信用总值
        /// 编写时间: 2010-10-7 14:00
        /// 创建者：Mickey 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static string GetUserCredits(string Id,string userId)
        {
            return ObjectToJson.ReaderToJson(userService.GetUserCredits(Id,userId));
        }

        /// <summary>
        /// 修改会员佣金
        /// 编写时间：2010-10-4 14:30
        /// 创建者：Mickey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commission"></param>
        /// <returns></returns>
        public static bool updateUserCommission(string id, string commission)
        {
            return userService.updateUserCommission(id, commission);
        }

        #region 生成代码
        ///<sumary>
        ///通过id获得实体对象
        ///时间：2010-10-3 23:03:07
        ///</sumary>
        public static User GetUserByPK(object pk)
        {
            try
            {
                return userService.GetUserByPK(pk);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return null;
            }
        }

        ///<sumary>
        ///添加信息
        ///时间：2010-10-3 23:03:07
        ///</sumary>
        public static Boolean AddUser(User user)
        {
            try
            {
                return userService.AddUser(user);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///修改信息
        ///时间：2010-10-3 23:03:07
        ///</sumary>
        public static Boolean UpdateUser(User user)
        {
            try
            {
                return userService.UpdateUser(user);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///删除信息
        ///时间：2010-10-3 23:03:07
        ///</sumary>
        public static Boolean DeleteUserByPK(object pk)
        {
            try
            {
                return userService.DeleteUserByPK(pk);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///获得所有信息，得到一张临时表
        ///时间：2010-10-3 23:03:07
        ///</sumary>
        public static DataTable GetMutilDTUser()
        {
            try
            {
                return userService.GetMutilDTUser();
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return null;
            }
        }

        ///<sumary>
        ///获得所有信息，返回泛型集合
        ///时间：2010-10-3 23:03:07
        ///</sumary>
        public static IList<User> GetMutilILUser()
        {
            try
            {
                return userService.GetMutilILUser();
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return null;
            }
        }
        #endregion

        /// <summary>
        /// 更新会员密码
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
                return userService.UpdatePass(pass, userName);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 获得记录总数
        /// create by 肖军文
        /// create date 2010-09-28
        /// </summary>
        /// <param name="upUserName">上级归属</param>
        /// <param name="userName">账户名称</param>
        /// <param name="status">状态</param> 
        /// <returns></returns>
        public static int GetUserAcount(string upUserName,string userName,string status)
        {
            try
            {
                return userService.GetUserAcount(upUserName, userName, status);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// 更新会员信息
        /// create by 肖军文
        /// create date 2010-09-28
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="tel">电话</param>
        /// <param name="mobile">手机号</param>
        /// <param name="status">状态</param>
        /// <param name="userName">账户名</param>
        /// <returns></returns>
        public static bool UpdateUser(string name, string tel, string mobile, string status, string userName)
        {
            if (userService.UpdateUserByUserName(name, tel, mobile, status, userName))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 根据条件查询会员信息
        /// create by 肖军文
        /// create date 2010-09-28
        /// </summary>
        /// <param name="upUserName">上级归属</param>
        /// <param name="userName">账户名</param>
        /// <param name="status">状态</param>
        /// <param name="limitStart">索引开始</param>
        /// <param name="limitEnd">索引结束</param>
        /// <returns></returns>
        public static IList<User> GetUser(string upUserName, string userName, string status, int limitStart, int limitEnd)
        {
            IList<User> list = userService.GetUser(upUserName, userName, status, limitStart, limitEnd);
            if (list != null)
            {
                return list;
            }
            return null;
        }

        /// <summary>
        /// 增加会员信息
        /// create by 肖军文
        /// create date 2010-09-29
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int AddAgentUser(User user)
        {
            try
            {
                //计算各级代理占成
                user.SubCompanyPercent = user.SubCompanyPercent - user.PartnerPercent;
                user.PartnerPercent = user.PartnerPercent - user.GeneralAgentPercent;
                user.GeneralAgentPercent = user.GeneralAgentPercent - user.AgentPercent;
                user.AgentPercent = user.AgentPercent - user.Percent;
                //会员等级、跟投、吃货比例
                GradeManager gm = new GradeManager();
                ConfigManager cm = new ConfigManager();
                user.UserLevel = gm.GetDefaultGrade().ID.ToString();
                user.Coefficient = Convert.ToDecimal(cm.GetConfigByOtype("跟投系数").Oval);
                user.Proportion = Convert.ToDecimal(cm.GetConfigByOtype("吃货比例").Oval);

                int Id = userService.AddAgentUser(user);
                if(Id!=0)
                {
                    if (userService.UpdateAgentNumber(user.UpUserID))
                    {
                        AgentService agentService = new AgentService();
                        agentService.UpdateUserCredit(user.Credit, user.UpUserName);
                        return Id;
                    }
                    else {
                        return 0;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static bool AddAgentUser2(User user)
        {
            try
            {
                //计算各级代理占成
                user.SubCompanyPercent = user.SubCompanyPercent - user.PartnerPercent;
                user.PartnerPercent = user.PartnerPercent - user.GeneralAgentPercent;
                user.GeneralAgentPercent = user.GeneralAgentPercent - user.AgentPercent;
                user.AgentPercent = user.AgentPercent - user.Percent;
                //会员等级、跟投、吃货比例
                GradeManager gm = new GradeManager();
                ConfigManager cm = new ConfigManager();
                user.UserLevel = gm.GetDefaultGrade().ID.ToString();
                user.Coefficient = Convert.ToDecimal(cm.GetConfigByOtype("跟投系数").Oval);
                user.Proportion = Convert.ToDecimal(cm.GetConfigByOtype("吃货比例").Oval);

                return userService.AddAgentUser2(user);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string stringGetUserNamesA(string userName)
        {
            return ObjectToJson.ReaderToJson(userService.stringGetUserNamesA(userName));
        }

        public static bool UpdateUserLevel(string userName, string userLevel)
        {
            return userService.UpdateUserLevel(userName,userLevel);
        }

        public static string GetBalance(string Id)
        {
            return ObjectToJson.ReaderToJson(userService.GetBalance(Id));
        }

        public static string GetAccountInfo(string userName)
        {
            return userService.GetAccountInfo(userName);
        }

        public static string GetUserByWhere(string userName, string status, string currency, string time1, string time2, string agentType, string agent, string MoneyType)
        {
            return userService.GetUserByWhere(userName, status, currency, time1, time2, agentType, agent,MoneyType);
        }

        public static bool UpdateUser1(User info)
        {
            return userService.UpdateUser1(info);
        }

        public User GetUserByUserName(string userName)
        {
            return userService.GetUserByUserName(userName);
        }


        public static bool AddLogClient(string userName)
        {
            string ip = Util.RequestHelper.GetIP();
            string addr = "";
            string uri = "http://www.youdao.com/smartresult-xml/search.s?type=ip&q=" + ip;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(uri);
                XmlNodeList xnlist = xmlDoc.SelectNodes("//product");
                foreach (XmlNode xn in xnlist)
                {
                    addr = xn.SelectSingleNode("location").InnerText;
                }
            }
            catch
            {
                addr = "保留";
            }
            return DAL.UserService.AddLogClient(userName, DateTime.Now, ip, "登录", "登录", addr);
        }


        public static string[] GetUserInfo(int id)
        {
            
            return userService.GetUserInfo(id);
        }

        //试玩
        public static string[] GetUserInfoDemo(int id)
        {
            return userService.GetUserInfoDemo(id);
        }
        /// <summary>
        /// 用户进入验证
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool CheckLogin(string userName, string password, ref User user)
        {
            return userService.GetUserByLogin(userName, password, ref user);
        }

        public static bool CheckLoginClient(string userName, string password, ref User user)
        {
            return userService.GetUserByLoginClient(userName, password, ref user);
        }

        /// <summary>
        /// 单点进入验证
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool CheckWebLogin(string userName, string LastLoginIP, ref User user)
        {
            return userService.CheckWebLogin(userName, LastLoginIP, ref user);
        }




        public static string SelectUserInfo(string userName)
        {
            return userService.SelectUserInfo(userName);
        }

        /// <summary>
        /// 添加赢币
        /// </summary>
        /// <param name="yingb"></param>
        /// <param name="mark"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool AddYingb(decimal yingb, string type, string mark, string username)
        {
            bool reval = true;
            //更新赢币
            try
            {
                if (DAL.UserService.UpdateYingb(yingb, username))
                {
                    //插入赠送赢币记录
                    BillNoticeHistory billHistory = new BillNoticeHistory();
                    billHistory.UserName = username;
                    billHistory.Type = type;
                    billHistory.Amount = yingb;
                    billHistory.ValidAmount = yingb;
                    billHistory.SubmitTime = DateTime.Now;
                    billHistory.UpdateTime = DateTime.Now;
                    billHistory.Status = "2";
                    billHistory.Mark = mark;
                    reval = BLL.BankManager.InsertBillNoticeHistory(billHistory);
                }
            }
            catch
            {
                reval = false;
            }

            return reval;
        }



        public static string GetSumAgentInfo(string username, string time1, string time2)
        {
            return userService.GetSumAgentInfo(username, time1, time2);
        }

        public static string GetEVnMonInfo(string agentname)
        {
            return userService.GetEVnMonInfo(agentname);
        }

        public static string GetQGHis(string agentname)
        {
            return userService.GetQGHis(agentname);
        }
        public static string GetagentInfo(string agentname)
        {
            return userService.GetagentInfo(agentname);
        }
        public static bool CheckAgentamount(string agentname, string txtanswer, string Type, string amount, string Status, string Reasoncn, string mark)
        {
            return userService.CheckAgentamount(agentname,txtanswer ,Type, amount, Status, Reasoncn, mark);
        }

        public static string GetjoinerInfo(string agentname)
        {
            return userService.GetjoinerInfo(agentname);
        }

        public static bool UpdateAgentInfo(string agentname, string tel, string url, string add)
        {
            return userService.UpdateAgentInfo(agentname, tel, url, add);
        }

      
        public static bool CheckOldPwd(string oldPwd,string agentname)
        {
            return userService.CheckOldPwd(oldPwd, agentname);
        }

        public static bool UpdatePassword(string oldPwd, string agentname)
        {
            return userService.UpdatePassword(oldPwd, agentname);
        }
    }
}
