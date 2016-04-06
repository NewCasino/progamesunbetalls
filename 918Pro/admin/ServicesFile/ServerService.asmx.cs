using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DAL;
using Model;
using BLL;

namespace admin.ServicesFile
{
    /// <summary>
    /// ServerService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class ServerService : System.Web.Services.WebService
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

            return ServerManager.CeliName(Name).ToString();
        }

        [WebMethod(true)]
        public string CeliDomainName(string Name)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return DomainManager.CeliName(Name).ToString();
        }
        /// <summary>
        /// 新增域名网址
        /// 编写时间: 2010-12-10 14:30
        /// 创建者：Mickey
        /// </summary>
        /// <param name="domainName"></param>
        /// <param name="ismain"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string InsertDomain(string domainName, string ismain, string status)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            try
            {
                Model.Domain domainModel = new Model.Domain();
                domainModel.DomainName = domainName;
                domainModel.Ismain = ismain;
                domainModel.AddDate = DateTime.Now;
                domainModel.Status = status;
                int configID = BLL.DomainManager.InsertDomain(domainModel);
                domainModel.ID = configID;
                return DAL.ObjectToJson.ObjectsToJson(domainModel);
            }
            catch (Exception)
            {
                return "none";
            }
        }

        /// <summary>
        /// 修改网址域名
        /// 编写时间: 2010-12-10 15:00
        /// 创建者：Mickey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="domainName"></param>
        /// <param name="ismain"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string updateDomain(string id, string domainName, string ismain, string status)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            DateTime time = DateTime.Now;
            return BLL.DomainManager.updateDomain(id, domainName, ismain, status, time).ToString();
        }

        /// <summary>
        /// 获取所有域名网址
        /// 编写时间: 2010-12-10 14:00
        /// 创建者：Mickey
        /// </summary>
        /// <returns></returns>
        [WebMethod(true)]
        public string GetDomainAll()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return BLL.DomainManager.GetDomainAll();
        }

        /// <summary>
        /// 获取所有服务器
        /// 编写时间: 2010-10-10 14:00
        /// 创建者：Mickey
        /// </summary>
        /// <returns></returns>
        [WebMethod(true)]
        public string GetServerAll()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return BLL.ServerManager.GetServerAll();
        }

        /// <summary>
        /// 新增服务器
        /// 编写时间: 2010-12-11 17:10
        /// 创建者：Mickey
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="ip1"></param>
        /// <param name="ip2"></param>
        /// <param name="ip3"></param>
        /// <param name="area"></param>
        /// <param name="status"></param>
        /// <param name="reMark"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string AddServer(string serverName, string ip1, string ip2, string ip3, string area, string status, string reMark)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string guid = ((Guid.NewGuid().ToString()).Substring(0, 13)).Replace("-", "");
            bool ID= BLL.ServerManager.SelectGuId(guid);
            string subDomain = guid;
            for (var i = 0; ID.Equals(true); i++)
            {
                if (ID)
                {
                    string guids = ((Guid.NewGuid().ToString()).Substring(0, 12)).Replace("-", "");
                    ID = BLL.ServerManager.SelectGuId(guids);
                    subDomain = guids;
                }
            }
            Model.Server server = new Model.Server();
            server.ServerName = serverName;
            server.Ip1 = ip1;
            server.Ip2 = ip2;
            server.Ip3 = ip3;
            server.SubDomain = subDomain;
            server.OnlineNumber = 0;
            server.Area = area;
            server.Status = status;
            server.AddDate = DateTime.Now;
            server.UpdateDate = DateTime.Now;
            server.ReMark = reMark;

            string jsonStr = "";
            bool reval = BLL.ServerManager.AddServer(server);
            if (reval)
            {
                jsonStr = ObjectToJson.ObjectsToJson<Server>(server);
            }
            else
            {
                jsonStr = "none";
            }
            return jsonStr;      
        }

        /// <summary>
        /// 修改服务器配置
        /// 编写时间: 2010-10-11 21:00
        /// 创建者：Mickey 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="serverName"></param>
        /// <param name="ip1"></param>
        /// <param name="ip2"></param>
        /// <param name="ip3"></param>
        /// <param name="area"></param>
        /// <param name="status"></param>
        /// <param name="reMark"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string updateServer(int id, string serverName, string upName, string ip1, string ip2, string ip3, string area, string status, string reMark)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

             string json = "";
             if (serverName != upName)
                {
                    if (ServerManager.CeliName(serverName))
                    {
                        json = "stop";
                    }
                }
                if (json != "stop")
                {
                    DateTime time = DateTime.Now;
                    json = BLL.ServerManager.updateServer(id, serverName, ip1, ip2, ip3, area, status, time, reMark).ToString();
                }
                return json;
        }
    }
}
