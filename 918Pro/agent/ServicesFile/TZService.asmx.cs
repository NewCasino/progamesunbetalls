using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using Model;

namespace agent.ServicesFile
{
    /// <summary>
    /// TZService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class TZService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(EnableSession = true)]
        public string GetNextLevel(int id)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return AgentManager.GetNextLevel(id);
        }

        [WebMethod(EnableSession = true)]
        public string GetNextAndUpLevel(int id,int roleid)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return AgentManager.GetNextAndUpLevel(id, roleid);
        }

        [WebMethod(EnableSession = true)]
        public string GetUpLevel(int id)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return AgentManager.GetUpLevel(id);
        }

        [WebMethod(EnableSession = true)]
        public string Update(int roleid,int id, int min, int max, int onemax)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string i = "0";
            if (roleid == 2)
            {
                List<string> list = AgentManager.GetNextAndUpLevelToList1(id);
                if (min > int.Parse(list[0]))
                {
                    return "-1";
                }
                if (max < int.Parse(list[1]))
                {
                    return "-1";
                }
                if (onemax < int.Parse(list[2]))
                {
                    return "-1";
                }
            }
            else if (roleid == 6)
            {
                List<string> list = AgentManager.GetNextAndUpLevelToList2(id);
                if (min < int.Parse(list[0]))
                {
                    return "-1";
                }
                if (max > int.Parse(list[1]))
                {
                    return "-1";
                }
                if (onemax > int.Parse(list[2]))
                {
                    return "-1";
                }
            }
            else
            {
                List<string> list = AgentManager.GetNextAndUpLevelToList(id,roleid);
                if (min < int.Parse(list[0]) || min > double.Parse(list[3]))
                {
                    return "-1";
                }
                if (max > int.Parse(list[1]) && max < double.Parse(list[4]))
                {
                    return "-1";
                }
                if (onemax > int.Parse(list[2]) && onemax < double.Parse(list[5]))
                {
                    return "-1";
                }
            }
            if (roleid != 6)
            {
                i = AgentManager.update(id, min, max, onemax);
            }
            else
            {
                i = AgentManager.updateUser(id, min, max, onemax);
            }
            return i;
        }
    }
}
