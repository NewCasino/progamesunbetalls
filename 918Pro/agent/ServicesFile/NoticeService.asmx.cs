using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DAL;
using Model;

namespace agent.ServicesFile
{
    /// <summary>
    /// NoticeService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class NoticeService : System.Web.Services.WebService
    {
        protected BLL.NoticeManager noticeManager = new BLL.NoticeManager();

        [WebMethod(true)]
        public string GetNoticeBylan(string lan)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            if (Session["window"] == null)
            {
                Session["window"] = "0";
            }
            IList<Notice> notices = noticeManager.GetNoticeBylan(lan);
            foreach (Notice info in notices)
            {
                if (Session["window"] == "0")
                {
                    if (info.Windowagent == "1" || info.Windowuser == "1")
                    {
                        Session["window"] = "1";
                    }
                }
            }

            string aa = "{\"data1\":";
            aa += ObjectToJson.ObjectListToJson<Model.Notice>(noticeManager.GetNoticeBylan(lan));
            aa += ",\"data2\":[{\"window\":\"" + Session["window"].ToString() + "\"}]}";

            return aa;
        }
    }
}
