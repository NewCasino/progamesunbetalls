using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace agent
{
    /// <summary>
    /// AjaxRequestTestService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class AjaxRequestTestService : WebService
    {

        [WebMethod(true)]
        public string GetLinkman()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

           //throw new Exception("message");
            System.Threading.Thread.Sleep(3000);
            String jsonData = String.Empty;
            //模拟数据库传的数据 定义一个bool类型 如果为真就表示在数据库中查到了相应的数据,否则反之。
            Boolean con=true;  // 模拟表示有数据
            if (con)
                jsonData = "[{\"Id\":\"1\",\"Name\":\"liu\",\"Sex\":\"男\",\"Age\":19,\"Birthday\":\"1987-10-01 00:00:00\"},{\"Id\":2,\"Name\":\"xu\",\"Sex\":\"男\",\"Age\":18,\"Birthday\":\"1988-10-01 00:00:00\"},{\"Id\":3,\"Name\":\"yi\",\"Sex\":\"女\",\"Age\":20,\"Birthday\":\"1990-10-01 00:00:00\"},{\"Id\":4,\"Name\":\"lin\",\"Sex\":\"女\",\"Age\":21,\"Birthday\":\"1987-10-01 00:00:00\"}]";
            else
                jsonData = "none";
            return jsonData;
        }
    }
}
