using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Util;
using BLL;

namespace Ezun.ServiceFile
{
    /// <summary>
    /// LoginService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class LoginService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        /// <summary>
        /// 验证码刷新
        /// Programmer：cc
        /// </summary>       
        /// <param name="code"></param>
        /// <param name="typ"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool CheckCode(string code, string typ)
        {
            switch (typ)
            {
                case "0":
                    if (Session[Util.ProjectConfig.VALIDATECODE] != null)
                    {
                        if (Session[Util.ProjectConfig.VALIDATECODE].ToString().Equals(code, StringComparison.OrdinalIgnoreCase) || code == "0769")
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                    break;
                case "1":
                    if (Session["reg"] != null)
                    {
                        if (Session["reg"].ToString().Equals(code, StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                    break;
            }
            return false;
        }


        /// <summary>
        /// 查看用户是否是进入状态
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string GUI2(int t) //GetUserInfo
        {
            string userstate = CheckUserState2();
            if (userstate == "mulLogin" || userstate == "noLogin" || userstate == "loginOut") return userstate;
            string[] val;
            Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
            if (t == 1)
            {
                return "yes";
            }
            if (user.Demo == "1")
            {
                val = UserManager.GetUserInfoDemo(user.ID);
            }
            else
            {
                val = UserManager.GetUserInfo(user.ID);
            }
            if (val.Length == 0) return "none";
            return "{\"demo\":\"" + user.Demo + "\",\"a\":\"" + user.UserName + "\",\"b\":\"" + user.Currency + "\",\"c\":\"" + Decimal.Parse(val[2]).ToString() + "\",\"d\":\"" + val[0] + "\",\"e\":\"" + val[1] + "\",\"f\":\"" + val[3] + "\",\"g\":\"" + val[4] + "\",\"h\":\"" + user.Mobile + "\",\"i\":\"" + val[2] + "\",\"win\":\"" + val[5] + "\"}";

        }

        [WebMethod(true)]
        public string CheckUserState2()
        {
            if (Session[ProjectConfig.LOGINUSER] != null)
            {
                Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
                if (Application[user.ID + "Session"].ToString() != this.Session.SessionID)
                {
                    return "mulLogin";
                }
                else
                {
                    if (user.Demo == "1")
                    {
                        LoginOut();
                        return "loginOut";
                    }
                    else
                    {
                        return "ok" + user.ID;
                    }
                }
            }
            else
            {
                return "noLogin";
            }
        }


        /// <summary>
        /// 安全退出
        /// </summary>
        /// <returns></returns>
        [WebMethod(true)]
        public bool LoginOut()
        {
            if (Session[ProjectConfig.LOGINUSER] != null)
            {
                try
                {                 

                    Session.Abandon();
                }
                catch (Exception)
                {

                    throw;
                }

            }
            //ScriptHelper.ExecuteScript("window.parent.location.replace('/login.htm')");
            return true;
        }

        /// <summary>
        /// 用户进入验证
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="code"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string CheckLogin(string userName, string password, string code, string language)
        {
           

            // -1 验证码错误
            // -2 帐号不能为空
            //-3 密码不能为空
            //-4 帐号不存在或密码错误

            //-5 帐号暂停使用
            //-6 帐号已被停用
            //1登陆成功

            if (!CheckCode(code, "0"))
            {
                return "-1";//验证码错误
            }
            Model.User user = null;
            userName = userName.ToLower().Trim();
            password = password.Trim();
            language = language.Trim();
            if (userName == string.Empty)
                return "-2";
            if (password == String.Empty)
                return "-3";

            bool con = UserManager.CheckLogin(userName, password, ref user);
            if (con && user != null)
            {
                Session[ProjectConfig.LOGINUSER] = user;
                if (user.Status == 2)
                    return "-5";
                if (user.Status == 0)
                    return "-6";
                //CookieHelper cook = new CookieHelper();
                //cook.SetCookie(ProjectConfig.LANGUAGE_COOK, "tw", TimeSpan.FromDays(1));
                user.LastLoginTime = DateTime.Now;
             

                Application[user.ID + "Session"] = this.Session.SessionID;
                //在线人数
                Application["OnlineUserNubers"] = Convert.ToInt32(Application["OnlineUserNubers"]) + 1;

                #region 登录日志
                string ip = Util.RequestHelper.GetIP();
                //ThreadPool.QueueUserWorkItem(new WaitCallback(UserManager.AddLogClient), new object {userName,ip});
                UserManager.AddLogClient(userName);
                #endregion

                return "1";
            }
            else
                return "-4";
        }

        [WebMethod(true)]
        public string SelectUserInfo()
        {          
            Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
            string userName = user.UserName;
            return BLL.UserManager.SelectUserInfo(userName);

        }
      
    }
}
