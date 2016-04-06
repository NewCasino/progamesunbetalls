using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using Util;

namespace Ezun.ServiceFile
{
    /// <summary>
    /// ClientService 对接EA平台专用
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class ClientService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string Getticket()
        {
                string id = StringHelper.getOrder("财务中心");
            
                string xmls = "";
                xmls += "<?xml version=\"1.0\"?>";
                xmls += "<request action=\"cgetticket\">";

                xmls += "<element id=\"" + id + "\">";

                xmls += "<properties name=\"username\"></properties>";
                xmls += "<properties name=\"date\">2</properties>";
                xmls += "<properties name=\"sign\">156</properties>";
             
                xmls += "</element>";
                xmls += "</request>";
                string rxmls = BankManager.PostData("https://testmis.ea3-mission.com/configs/external/withdrawal/gs/server.php", xmls, System.Text.Encoding.UTF8);
                return rxmls;
    }
            
    }
}
