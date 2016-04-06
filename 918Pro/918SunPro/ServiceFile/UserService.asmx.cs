using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using DAL;
using Util;
using BLL.Ezun;
using System.Text;
namespace Ezun.ServiceFile
{
    /// <summary>
    /// ServiceFile 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class ServiceFile : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        #region 接口文档注册用户名不能有滴字符检测
        private string[] strbadword()
        {
            string[] bad = new string[28];
            bad[0] = "'";
            bad[1] = "\"";
            bad[2] = ";";
            bad[3] = "--";
            bad[4] = ",";
            bad[5] = "!";
            bad[6] = "~";
            bad[7] = "@";
            bad[8] = "#";
            bad[9] = "$";
            bad[10] = "%";
            bad[11] = "^";
            bad[12] = "&";
            bad[13] = "  ";
            bad[14] = "_";
            bad[15] = "?";
            bad[16] = "SPACE";
            bad[17] = "DOUBLE";
            bad[18] = "BYTE";
            bad[19] = "CHAR";
            bad[20] = "TAB";
            bad[21] = "NULL";
            bad[22] = "LINE";
            bad[23] = "FEED";
            bad[24] = "\n";
            bad[25] = "/";
            bad[26] = ">";
            bad[27] = "<";
            return bad;
        }
        public bool ChkBadWord(string badword)
        {
            string[] bw = strbadword();
            bool isok = false;
            foreach (string str in bw)
            {
                if (badword.IndexOf(str) > -1)
                {
                    isok = true;
                    return isok;
                }

            }
            return isok;
        }
        #endregion


        /// <summary>
        /// 会员注册添加会员
        /// </summary>
        /// <returns></returns>
        [WebMethod(true)]
        public string AddUser(string UserName, string Password, string TCpassword, DateTime Birthday, string Name,
        string Tel, string Email, string Agent, string post, string Answer)
        {
            if (UserName.Trim() == "")
            {
                return "err8";
            }
            else
            {
                if (UserName.Trim().Length < 6 || UserName.Trim().Length > 15)
                {
                    return "err9";
                }
            }
            if (ChkBadWord(UserName.Trim()))//检测是否有非法字符
            {
                return "err8";
            }
            Model.User info = new Model.User();
            Model.Agent agent = null;
            Model.Agent subAgent = null;
            Model.Agent parAgent = null;
            Model.Agent zAgent = null;

            if (!string.IsNullOrEmpty(Email))
            {
                if (DAL.UserService.IsExistEmail(Email))
                {
                    return "err:email";   //邮箱重复
                }
            }


            AgentManager am = new AgentManager();
            if (string.IsNullOrEmpty(Agent) || Agent == "undefined")
            {
                //网站直接会员
                ConfigManager cm = new ConfigManager();
                string styp = "人民币";

                Model.Config config = cm.GetConfigByOtype(styp);
                Agent = config.Oval;


            }

            //代理会员
            agent = am.GetAgentByUserName(Agent);

            //if (agent==null)
            //{
            //     return "err2";

            //}
            //选择的币种是否与推荐人币种一致         
            //info.parentcode = agent.ParentCode;
            subAgent = am.GetAgentByUserName(agent.SubCompany);
            parAgent = am.GetAgentByUserName(agent.Partner);
            zAgent = am.GetAgentByUserName(agent.GeneralAgent);

            info.GeneralAgent = agent.GeneralAgent;
            info.GeneralAgentPercent = Convert.ToDecimal(zAgent.Percent);
            info.GeneralAgentCommission = zAgent.CommissionA;
            info.Agent = Agent;
            info.AgentPercent = Convert.ToDecimal(agent.Percent);
            info.AgentCommission = agent.CommissionA;

            info.CompanyPercent = 0;
            info.PartnerCommission = 0;
            info.SubCompany = agent.SubCompany;
            info.SubCompanyPercent = Convert.ToDecimal(subAgent.Percent);
            info.SubCompanyCommission = subAgent.CommissionA;
            info.Partner = agent.Partner;
            info.PartnerPercent = Convert.ToDecimal(parAgent.Percent);
            info.PartnerCommission = parAgent.CommissionA;
            info.Percent = 0;
            info.Commission = 0;
            info.Credit = 0;
            info.UpUserName = agent.UserName;
            info.UpUserID = agent.ID;
            info.UpRoleId = agent.RoleId;
            info.ItemMin = agent.ItemMin;
            info.ItemMax = agent.ItemMax;
            info.ItemsMax = agent.ItemsMax;
            info.Group = "A";
            info.ResetCredit = "0";
            info.RegistrationTime = DateTime.Now;
            info.LastLoginTime = DateTime.Now;
            info.UserLevel = "5";
            info.Coefficient = 0;
            info.Proportion = 0;
            info.Balance = 0;
            info.RoleId = 6;

            info.UserName = UserName.Trim();
            info.Password = Password;
            info.TCpassword = TCpassword;
            info.Birthday = Birthday;
            info.Name = Name.Trim();
            info.Tel = Tel;
            info.Email = Email;

            info.Agent = Agent.Trim();

            info.Status = 1;
            info.MoneyType = "0";
            info.regip = Util.RequestHelper.GetIP();
            info.Post = post.Trim();
            info.Answer = Answer.Trim();


            bool reval = UserManager.AddAgentUser2(info);
            if (reval)
            {
                //用户登录
                UserManager um = new UserManager();
                Model.User user = null;
                user = um.GetUserByUserName(info.UserName);
                if (user != null)
                {
                    Session[ProjectConfig.LOGINUSER] = user;
                    CookieHelper cook = new CookieHelper();
                    //cook.SetCookie(ProjectConfig.LANGUAGE_COOK, "tw", TimeSpan.FromDays(1));
                    Application[user.ID + "Session"] = this.Session.SessionID;
                    user.LastLoginIP = RequestHelper.GetIP();
                    UserManager.UpdateUser(user);
                    //会员登录日志
                    UserManager.AddLogClient(user.UserName);

                    //发送游戏帐号开通信息到后台

                    Boolean isOk = Getpwds(Password, "1");
                }

            }
            if (reval)
            {
                //当注册成功时，发送邮件。
                try
                {
                    string isok = SendEmail2(Email, UserName, Name);
                    if (isok != "ok") { return "1000"; }
                    //else return "ok";
                    return "ok";
                }
                catch (Exception)
                {

                    return "8008";
                }

            }
            else
            {
                return "err";
            }
        }






        #region 用户密码找回
        /// <summary>
        /// 判断email是否合法唯一
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool IsExistEmail(string mail)
        {
            return DAL.UserService.IsExistEmail(mail);
        }
        [WebMethod(true)]
        public bool IsExistEmailAgent(string mail)
        {
            return DAL.UserService.IsExistEmailAgent(mail);
        }


        [WebMethod(true)]
        public bool IsExistUsername(string username)
        {
            return DAL.UserService.IsExistUsername(username.Trim());
        }

        [WebMethod(true)]
        public bool IsAgentUser(string username)
        {
            return DAL.UserService.IsAgentUser(username);
        }
        [WebMethod(true)]
        public bool CheckOldPwd(string oldPwd)
        {
            if (Session[ProjectConfig.LOGINUSER] != null)
            {
                Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
                return BLL.Ezun.UserManagers.CheckOldPwd(oldPwd, user.ID);
            }
            else
            {
                return false;
            }

        }

        [WebMethod(true)]
        public bool UpdatePassword(string newPwd)
        {
            if (Session[ProjectConfig.LOGINUSER] != null)
            {
                Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
                return BLL.Ezun.UserManagers.UpdatePassword(newPwd, user.ID);
            }
            else
            {
                return false;
            }
            //Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
            //return BLL.UserManager.UpdatePassword(newPwd, user.ID);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [WebMethod(true)]
        public string GetLoginUser()
        {
            if (Session[ProjectConfig.LOGINUSER] == null)
            {
                return "";
            }
            Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
            UserManager um = new UserManager();
            Model.User info = um.GetUserByUserName(user.UserName);
            return ObjectToJson.ObjectsToJson<Model.User>(info);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="LastName"></param>
        /// <param name="FirstName"></param>
        /// <param name="sex"></param>
        /// <param name="Email"></param>
        /// <param name="Birthday"></param>
        /// <param name="country"></param>
        /// <param name="addr"></param>
        /// <param name="city"></param>
        /// <param name="Province"></param>
        /// <param name="post"></param>
        /// <param name="Mobile"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool UpdateUserInfo(string nicheng, string Tel, string post, string mark)
        {

            if (Session[ProjectConfig.LOGINUSER] == null)
            {
                return false;
            }
            Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
            UserManagers um = new UserManagers();
            Model.User info = new Model.User();
            info.UserName = user.UserName;
            info.nicheng = nicheng;

            info.Tel = Tel;
            info.post = post;
            info.mark = mark;

            return um.UpdateUserInfo(info);
        }
        [WebMethod(true)]
        public bool UpdateUserInfoS(string username, string bankName, string bankUserName, string bankCard)
        {

          
            //Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
            UserManagers um = new UserManagers();
            //Model.User info = new Model.User();
            //info.UserName = user.UserName;
            //info.bankName = bankName;

            //info.bankUserName = bankUserName;
            //info.bankCard = bankCard;

            return um.UpdateUserInfoS(username, bankName, bankUserName, bankCard);
        }
        
       [WebMethod(true)]
        public string GetBanks(string username)
        {

          
            //Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
            UserManagers um = new UserManagers();
            //Model.User info = new Model.User();
            //info.UserName = user.UserName;
            //info.bankName = bankName;

            //info.bankUserName = bankUserName;
            //info.bankCard = bankCard;
            
            return um.GetBanks(username);
        }
        
        [WebMethod(true)]
        public string GetEAamount()
        {
            Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
            string reval = BLL.BankManager.GetEAamount(user.UserName);
            if (reval == "ERR_INVALID_CLIENT")
            {
                reval = "0.00";
            }
            return reval;
        }

        /// <summary>
        /// 找回密码，验证帐号跟邮箱是否存
        /// </summary>
        /// <param name="username"></param>
        /// <param name="eamil"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string isEmailOk(string username, string eamil)
        {

            return DAL.BankService.isEmailOk(username, eamil);
        }

        [WebMethod(true)]
        public bool isTureAnswer(string username, string Answer)
        {

            return DAL.BankService.isTureAnswer(username, Answer);
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string SendEmail(string Email, string LoginName)
        {

            string idNO = StringHelper.getOrder("密码认证");

            //发邮件
            if (!string.IsNullOrEmpty(Email))
            {
                string subject = "太阳城（直营）找回密码！-www..net";
                string body = "";
                body += "<html xmlns='http://www.w3.org/1999/xhtml'><head>    <title>太阳城（直营）找回密码！</title>";
                body += "<style type='text/css'>*,body{margin:0px;padding:0px;}";
                body += "img {border:none;}body{ background:#fff;}*,body,form,ul,ol,li,p,h1,h2,h3,h4,h5,h6{margin:0px;padding:0px;}";
                body += "body, td, th, input, select,p,span,div,legend,label,b,small,h1,h2,h3,h4,h5,h6{font-family:'微软雅黑',Arial, Helvetica, sans-serif;}";
                body += "body,td,div{font-size:12px;color:#333; line-height:150%;-webkit-text-size-adjust:none;}";
                body += "a {blr:expression(this.onFocus=this.blur()); outline:none; font-family:'微软雅黑',Arial, Helvetica, sans-serif; font-size:12px; }";
                body += "a:link, a:visited {text-decoration:none;color:red; text-decoration:underline;}";
                body += "a:hover, a:active {text-decoration:none;color:#F00; text-decoration:underline;}";
                body += "ul,li,ol{list-style-type:none;}h1,h2,h3,h4,h5,h6{font-family:'微软雅黑',Arial, Helvetica, sans-serif;line-height:200%;}";
                body += ".gbox{ width:600px; margin:auto; clear:both; height:784px; }";
                body += ".TextBox p{ color:#00294c; font-size:12px; text-indent:2em; margin-bottom:10px;}";
                body += ".red{ color:Red; font-weight:bold;}.cr{  clear:right; text-align:right;}.fb{ font-weight:bold;}";
                body += "</style><script type='text/javascript' ></script>";
                body += "</head><body>";
                body += "<div >";
                body += "<div > <span>尊敬的会员<span class='red'>" + LoginName + "</span>,感谢您选择太阳城（直营）！</span>";
                body += "<h3>欢迎您的加入，相信您就是最大的赢家！</h3>";
                body += "<p>这是您的安全认证网址：</p>";
                body += "http://www..net/User/FindPwd.aspx?Pwdid=" + idNO + "";
                body += "</div></body></html>";

                //body += "会员注册成功！<br>会员账号：" + LoginName;
                try
                {
                    Util.MailHelper.SendEmail91(Email, subject, body);
                }
                catch
                {
                    return "error";
                    //发送邮件失败
                }
                DateTime time1 = DateTime.Now;
                bool istrue = DAL.UserService.UpdateUserUpatePwd(LoginName, idNO, time1);
                if (istrue == true)
                {
                    return "ok";
                }
                else
                {
                    return "error";
                }

            }
            return "ok";
        }


        [WebMethod(true)]
        public string GetAnswer1(string username)
        {

            return DAL.BankService.GetAnswer1(username);
        }

        /// <summary>
        /// 验证安全提问，并修改密码
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string SendInfo(string username, string Answer, string Password)
        {
            return DAL.UserService.SendInfo(username, Answer, Password);
        }
        #endregion

        [WebMethod(true)]
        public string GetNoticeBylan()
        {
            NoticeManager nobll = new NoticeManager();
            return ObjectToJson.ObjectListToJson<Model.Notice>(nobll.GetNoticeBylan("zh-cn"));
        }

        //配置设置读起
        [WebMethod(true)]
        public string GetPro_setup()
        {
            ConfigManager config = new ConfigManager();

            return ObjectToJson.ObjectListToJson<Model.Config>(config.GetPro_setup()); 
               
        }


        [WebMethod(true)]
        public string GetTime()
        {
            return DateTime.Now.ToString().Replace("-", "/");
        }


        /// <summary>
        /// 会员注册成功发送邮件
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="LoginName"></param>
        /// <param name="username"></param>
        /// <returns></returns>     
        private string SendEmail2(string Email, string LoginName, string username)
        {

            //发邮件
            if (!string.IsNullOrEmpty(Email))
            {
                string subject = "618shebo申博直营";
                StringBuilder sbr = new StringBuilder();
                sbr.Append("");
                sbr.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
                sbr.Append("<head runat=\"server\"> <title></title></head><body>");
                sbr.Append("<div>尊敬的用户：<br>您好，恭喜您注册成为618申博（www.618shenbo.com）会员。您的会员账号为：" + LoginName + "，初始密码为aa112233。为了保障您的账号资金安全，请您登陆游戏之后立即更改密码。<br/><br/> ");
                sbr.Append("<span> 新玩家首次存款即可申请首存三重礼，首存即送100%，最高奖金18888.首存之后还有二次存送，三次存送！<br/>每天都有保险礼金赠送，每周更有高额洗码派发。更多优惠尽在：www.618shenbo.com/promotion.html</span><br><br><br>");
                sbr.Append("<span>客服QQ：9790181  9790581</span><br/>");
                sbr.Append("<span>400热线：4006766836</span><br/>");
                sbr.Append("<span>官方网址：www.618shenbo.com</span><br/><br/>");
                sbr.Append("<span>618申博客服部</span><br/>");


                sbr.Append("</body></html>");
                try
                {
                    Util.MailHelper.SendEmail91(Email, subject, sbr.ToString());
                }
                catch
                {
                    return "error";

                }


            }
            return "ok";
        }


        [WebMethod(true)]
        public string Getparentcode(string agent)
        {
            try
            {

                return BLL.Ezun.BankManager.Getparentcode(agent);
            }
            catch (Exception)
            {
                return "";
            }
        }

        #region MyRegion

        #endregion

        private bool Getpwds(string newold, string type)
        {
            if (Session[ProjectConfig.LOGINUSER] != null)
            {
                Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
                return BLL.Ezun.UserManagers.Getpwds(newold, user.UserName, type, user.Name);
            }
            else
            {
                return false;
            }

        }
        [WebMethod(true)]
        public string GetPTinfo()
        {
            if (Session[ProjectConfig.LOGINUSER] != null)
            {
                Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
                return BLL.Ezun.UserManagers.GetPTinfo(user.UserName);
            }
            else
            {
                return "";
            }
        }
        [WebMethod(true)]
        public bool GetPTpwdInfo()
        {
            if (Session[ProjectConfig.LOGINUSER] != null)
            {
                Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
                return BLL.Ezun.UserManagers.GetPTpwdInfo(user.UserName);
            }
            else
            {
                return false;
            }

        }
    }
}



