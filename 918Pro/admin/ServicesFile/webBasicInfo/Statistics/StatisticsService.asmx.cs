using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using Model;
 
namespace admin.ServicesFile.Statistics
{
    /// <summary>
    /// StatisticsService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class StatisticsService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        //等级的方法
        [WebMethod(true)]
        public string getGrade(string language)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return GradeManager.getJson(language);
        }

        [WebMethod(true)]
        public string addInfo(string n,string r,string lan)
        {

            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            GradeManager gradeManager = new GradeManager();
            if (gradeManager.IsExistGrade(n,lan))
            {
                return "会员等级已存在";
            }
            Grade g = new Grade();

            if (lan == "cn" || lan == "CN")
            {
                g.LevelNamecn = n;
            }
            if (lan == "tw")
            {
                g.LevelNametw = n;
            }
            if (lan == "en")
            {
                g.LevelNameen = n;
            }
            if (lan == "th")
            {
                g.LevelNameth = n;
            }
            if (lan == "vn")
            {
                g.LevelNamevn = n;
            }
            g.LevelRemark = r;
            return GradeManager.AddGrade(g,lan).ToString();
        }

        [WebMethod(true)]
        public string update(string n,string r,string i,string lan)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return GradeManager.Update(n, r, i,lan);
        }

        [WebMethod(true)]
        public string delete(string i)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return GradeManager.DeleteGradeByPK(int.Parse(i)).ToString();
        }
        
        /// <summary>
        /// 根据多语言返回json数据
        /// </summary>
        /// <param name="lan">多语言</param>
        /// <returns></returns>
        [WebMethod(true)]
        public string GetGradeByLan(string lan)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            GradeManager gm = new GradeManager();
            return gm.GetGradeByLan(lan);
        }
    }
}
