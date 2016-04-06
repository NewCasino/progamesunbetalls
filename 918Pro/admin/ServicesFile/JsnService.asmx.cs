using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace admin.ServicesFile
{
    /// <summary>
    /// JsnService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class JsnService : System.Web.Services.WebService
    {

        [WebMethod(true)]
        public bool AddJsn(string userName,string sn)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            PageBase page = new PageBase();
            Model.Jsn info = new Model.Jsn();
            info.UserName = userName;
            info.Sn = sn;
            info.Isdate = DateTime.Now;
            info.Cuser = page.CurrentManager.ManagerId;
            info.Ctime = DateTime.Now;
            return BLL.JsnManager.AddJsn(info);
        }

        [WebMethod(true)]
        public string GetJsn(string userName, string sn, string date1, string date2)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            BLL.JsnManager jm = new BLL.JsnManager();
            return jm.GetJsnByWhere(userName, sn, date1, date2);
        }
    }
}
