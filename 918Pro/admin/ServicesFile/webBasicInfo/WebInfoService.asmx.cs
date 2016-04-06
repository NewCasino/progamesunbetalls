using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Model;
using BLL;

namespace Admin.ServicesFile.webBasicInfo
{
    /// <summary>
    /// WebInfoService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class WebInfoService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(EnableSession = true)]
        public string insertInfo(string namecn, string nametw, string nameen, string nameth, string nametv, string display, string address, string ord, string ip)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string i = CasinoManager.selectInfo(namecn, nametw, nameen, nameth, nametv);
            if (i != "0")
            {
                return "-1";
            }
            DateTime time = DateTime.Now;
            Casino webInfo = new Casino();
            webInfo.Namecn = namecn;
            webInfo.Nameen = nameen;
            webInfo.Nameth = nameth;
            webInfo.Nametv = nametv;
            webInfo.Nametw = nametw;
            webInfo.Display = byte.Parse(display);
            webInfo.Address = address;
            webInfo.Path = "none";
            webInfo.Ord = int.Parse(ord);
            //webInfo.operat = "admin";
            //webInfo.operatortime = time;
            //webInfo.operatorip = ip;
            return CasinoManager.AddCasino(webInfo).ToString();
        }

        [WebMethod(EnableSession = true)]
        public string UpdateInfo(string idNum, string namecn, string nametw, string nameen, string nameth, string nametv, string display, string address, string ord, string ip)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            DateTime time = DateTime.Now;
            Casino webInfo = new Casino();
            webInfo.Id = int.Parse(idNum);
            webInfo.Namecn = namecn;
            webInfo.Nameen = nameen;
            webInfo.Nameth = nameth;
            webInfo.Nametv = nametv;
            webInfo.Nametw = nametw;
            webInfo.Display = byte.Parse(display);
            webInfo.Address = address;
            webInfo.Path = "none";
            webInfo.Ord = int.Parse(ord);
            //webInfo.operat = "admin";
            //webInfo.operatortime = time;
            //webInfo.operatorip = ip;
            return CasinoManager.UpdateCasino(webInfo).ToString();
        }

        [WebMethod(EnableSession = true)]
        public string GetDate(int IDex, int IDexC)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return CasinoManager.getDataAll(IDex, IDexC);
        }

        [WebMethod(EnableSession = true)]
        public string GetDate()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return CasinoManager.getDataAll();
        }

        [WebMethod(EnableSession = true)]
        public string getCount()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return CasinoManager.getCount();
        }
        
        [WebMethod(EnableSession = true)]
        public string GetCasinoData()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return CasinoManager.getCasinoDataAll();
        }
    }
}
