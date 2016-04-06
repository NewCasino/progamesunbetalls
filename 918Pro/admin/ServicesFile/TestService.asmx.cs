using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;

namespace admin.ServicesFile
{
    /// <summary>
    /// TestService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class TestService : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetBetlogByWhere(string userid, string casino, string gametype)
        {
            BetlogManager bm = new BetlogManager();
            return bm.GetBetlogByWhere(userid, casino, gametype);
        }

        [WebMethod]
        public bool DeleBetlog()
        {
            BetlogManager bm = new BetlogManager();
            return bm.DeleBetlog();
        }

        [WebMethod]
        public string GetTestlogByWhere(string userid)
        {
            TestlogManager tm = new TestlogManager();
            return tm.GetTestlogByWhere(userid);
        }

        [WebMethod]
        public bool DeleTestlog()
        {
            TestlogManager tm = new TestlogManager();
            return tm.DeleTestlog();
        }
       

    }
}
