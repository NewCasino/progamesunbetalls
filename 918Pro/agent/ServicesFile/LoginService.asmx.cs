using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Model;
using BLL;
using Util;
namespace agent.ServicesFile
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
        [WebMethod(true)]
        public bool CheckCode(string code)
        {
            CookieHelper cook = new CookieHelper();
            if (cook.GetCookie(ProjectConfig.VALIDATECODE) != null)
            {

                if (cook.GetCookie(ProjectConfig.VALIDATECODE).Equals(code, StringComparison.OrdinalIgnoreCase))
                {
                    //cook.ClearCookie(Util.ProjectConfig.VALIDATECODE);
                    return true;
                }
                return false;
            }
                return false;
        }
        [WebMethod(true)]
        public string GetManageInfo()
        {
            if (Session[ProjectConfig.ADMINUSER] != null)
            {
                Agent manager = Session[ProjectConfig.ADMINUSER] as Agent;
                return manager.UserName;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 安全退出
        /// </summary>
        /// <returns></returns>
        [WebMethod(true)]
        public bool LoginOut()
        {
            if (Session[ProjectConfig.ADMINUSER] != null)
            {
                try
                {
                    Agent manager = Session[ProjectConfig.ADMINUSER] as Agent;
                    Session.Remove(ProjectConfig.ADMINUSER);
                    Application.Remove(manager.UserName + "Session");
                }
                catch (Exception)
                {
                    
                    throw;
                }
                
            }
            //ScriptHelper.ExecuteScript("window.parent.location.replace('/login.htm')");
            return true;
        }
        [WebMethod(true)]
        public bool CheckLogin(string messageId, string password,string language)
        {
            
            if(messageId==string.Empty||password==string.Empty)
            {
                return false;
            }
            Agent manager = null;
            if (AgentManager.CheckLogin(messageId, password, ref manager))
            {
                if (manager == null)
                {
                    return false;
                }
                Session[ProjectConfig.ADMINUSER] = manager;
                CookieHelper cook = new CookieHelper();
                cook.SetCookie(ProjectConfig.LANGUAGE_COOK, language,TimeSpan.FromDays(1));
                Application[manager.UserName + "Session"] = this.Session.SessionID;
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod(true)]
        public string AddLoginservers(string Webserverip, string Name, string Ip, string Status)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            Model.Loginservers loginservers = new Model.Loginservers();
            loginservers.Name = Name;
            loginservers.Ip = Ip;
            loginservers.Status = Convert.ToInt32(Status);
            loginservers.Webserverip = Webserverip;


            bool reval = BLL.LoginserversManager.AddLoginservers(loginservers);
            if (reval)
            {
                return DAL.ObjectToJson.ObjectsToJson<Loginservers>(loginservers);
            }
            else
            {
                return "none";
            }
        }

        [WebMethod(true)]
        public string UpdateLoginservers(string Id, string Webserverip, string Name, string Ip, string Status)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            Model.Loginservers loginservers = new Model.Loginservers();
            loginservers.Id = Convert.ToInt32(Id);
            loginservers.Name = Name;
            loginservers.Ip = Ip;
            loginservers.Status = Convert.ToInt32(Status);
            loginservers.Webserverip = Webserverip;
            bool reval = LoginserversManager.UpdateLoginservers(loginservers);
            string json = "";
            if (reval)
            {
                json = DAL.ObjectToJson.ObjectsToJson<Loginservers>(loginservers);
            }
            else {
                json = "none";
            }
            return json;
        }

        [WebMethod(true)]
        public string GetloginserversAll()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return LoginserversManager.GetloginserversAll();
        }
        

        [WebMethod(true)]
        public bool DeleteLoginService(int Id)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            return LoginserversManager.DeleteLoginserversByPK(Id);
        }
        [WebMethod(true)]
        public bool UpdateLoginServiceStatus(string status, string Id)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            int Status = Convert.ToInt32(status);
            int ID = Convert.ToInt32(Id);
            return LoginserversManager.UpdateLoginServiceStatus(Status, ID);
        }
        
        #region 新代理块调用
	    [WebMethod(true)]
        public string CheckLogins(string messageId, string password, string txtcode)
        {
            if (!CheckCode(txtcode))
            {
                return "-1";//验证码错误
            }

            if(messageId==string.Empty||password==string.Empty)
            {
                return "-2";
            }
            Agent manager = null;
            if (AgentManager.CheckLogin(messageId, password, ref manager))
            {
                if (manager == null)
                {
                    return "-3"; //帐号密码错误
                }
                Session[ProjectConfig.ADMINUSER] = manager;
                CookieHelper cook = new CookieHelper();
                cook.SetCookie(ProjectConfig.LANGUAGE_COOK, "cn",TimeSpan.FromDays(1));
                Application[manager.UserName + "Session"] = this.Session.SessionID;
                return "ok";
            }
            else
            {
                return "-3";
            }
        }



	    #endregion
    }
}
