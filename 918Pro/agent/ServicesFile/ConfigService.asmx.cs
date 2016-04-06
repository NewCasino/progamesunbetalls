using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using Model;
using Newtonsoft.Json;

namespace agent.ServicesFile
{
    /// <summary>
    /// ConfigService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class ConfigService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(true)]
        public string CeliName(string Name)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return ConfigManager.CeliName(Name).ToString();
        }
        /// <summary>
        /// 添加：Config 数据
        /// </summary>
        /// <param name="otype"></param>
        /// <param name="oval"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string InsertConfig(string otype, string oval, string remark)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            try
            {
                Model.Config configModel = new Model.Config();
                configModel.Otype = otype;
                configModel.Oval = oval;
                configModel.Remark = remark;
                configModel.Status = "1";
                int configID = BLL.ConfigManager.InsertConfig(configModel);
                configModel.ID = configID;
                return DAL.ObjectToJson.ObjectsToJson(configModel);   
            }
            catch (Exception)
            {
                return "none";
            }
        }

        /// <summary>
        /// 获取：Config 数据
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetConfigAll()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return BLL.ConfigManager.GetConfigAll();
        }

        /// <summary>
        /// 修改：Config 数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="otype"></param>
        /// <param name="oval"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string updateConfig(string id, string otype,string name, string oval, string remark)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string json = "";
            if (otype != name)
            {
                if (ConfigManager.CeliName(otype))
                {
                    json = "stop";
                }
            }
            if (json != "stop")
            {
                json= ConfigManager.updateConfig(id, otype, oval, remark).ToString();
            }
            return json;
           
        }

        /// <summary>
        /// 修改：佣金A、B、C
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commissionA"></param>
        /// <param name="commissionB"></param>
        /// <param name="commissionC"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string updateCommission(string id, string commissionA, string commissionB, string commissionC)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return BLL.AgentManager.updateCommission(id, commissionA, commissionB, commissionC).ToString();
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
        /// 修改信用
        /// 编写时间: 2010-10-6 14:10
        /// 创建者：Mickey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="credit"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public bool updateCredit(string id, string credit, string userId, string userCredit, string roleId, decimal balance)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            if (roleId != "6")
            {
                return BLL.AgentManager.updateCredit(id, credit, userId, userCredit, balance);
            }
            else
            {
                return BLL.UserManager.updateCredit(id, credit, userId, userCredit, balance);
            }
        }

        /// <summary>
        /// 获取下级信用之和(最小信用)
        /// 编写时间: 2010-10-6 14:20
        /// 创建者：Mickey
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetMinCredit(string roleId)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return BLL.AgentManager.GetMinCredit(roleId);
        }
        [WebMethod(EnableSession = true)]
        public string GetUserMinCredit(string upId)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return BLL.AgentManager.GetUserMinCredit(upId);
        }
        /// <summary>
        /// 获取上级信用之和(最大信用)
        /// 编写时间: 2010-10-6 20:32
        /// 创建者：Mickey
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetMaxCredit(string Id)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return BLL.AgentManager.GetMaxCredit(Id);
        }

        [WebMethod(EnableSession = true)]
        public string GetBalance(string Id, int roleId)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string json;
            if (roleId != 6)
            {
                json = BLL.AgentManager.GetBalance(Id);
            }
            else {
                json = BLL.UserManager.GetBalance(Id);
            }
            return json;
        }
        /// <summary>
        /// 获取除指定ID 以外的信用总值
        /// 编写时间: 2010-10-7 14:00
        /// 创建者：Mickey
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetCredits(string Id, string userId, string roleId)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            if (roleId != "6")
            {
                return BLL.AgentManager.GetCredits(Id, userId);
            }
            else
            {
                return BLL.UserManager.GetUserCredits(Id,userId);
            }
        }


    }
}