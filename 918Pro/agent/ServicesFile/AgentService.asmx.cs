using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;

namespace agent.ServicesFile
{
    /// <summary>
    /// AgentService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class AgentService : System.Web.Services.WebService
    {
        private AgentManager agentManager = new AgentManager();
        /// <summary>
        /// 判断代理子帐号是否存在(重复)
        /// by xzz 2010-11-30
        /// </summary>
        /// <param name="agentUserName"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool IsExistSubAccount(string userName)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            PageBase pageBase = new PageBase();
            return agentManager.IsExistSubAccount(userName, pageBase.agentUserName);
        }

        /// <summary>
        /// 获取：Config 数据
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetAgentAll()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return BLL.AgentManager.GetAgentAll();
        }
    }
}
