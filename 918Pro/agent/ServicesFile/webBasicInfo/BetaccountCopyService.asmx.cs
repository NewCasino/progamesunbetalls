using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Model;
using BLL;

namespace agent.ServicesFile.webBasicInfo
{
    /// <summary>
    /// BetaccountCopyService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class BetaccountCopyService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(EnableSession = true)]
        public string DeleteInfo(string id)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string[] idlist = id.Split(',');
            for (int i = 0; i < idlist.Length; i++)
            {
                BetaccountcopyManager.DeleteBetaccountcopyByPK(idlist[i]);
            }
            return "True";
        }

        [WebMethod(EnableSession = true)]
        public string GetDateAll(int IDex, int IDexC, string casino, string dali, string id, string enable, string webPoss, string Company)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return BetaccountcopyManager.getDataAll(IDex, IDexC, casino, dali, id, enable, webPoss, Company);
        }

        [WebMethod(EnableSession = true)]
        public string GetCount(string casino, string dali, string id, string enable, string webPoss, string Company)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return BetaccountcopyManager.getCount(casino, dali, id, enable, webPoss, Company);
        }
    }
}
