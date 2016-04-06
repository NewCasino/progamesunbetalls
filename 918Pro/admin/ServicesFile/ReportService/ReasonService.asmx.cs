using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using Model;
using Newtonsoft.Json;

namespace admin.ServicesFile.ReportService
{
    /// <summary>
    /// ReasonService 的摘要说明
    /// create by肖军文
    /// create date 2010-09-28
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class ReasonService : System.Web.Services.WebService
    {

        [WebMethod(true)]
        public string GetData(string id)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            try
            {
                IList<Reason> list = ReasonManager.GetMutilILReason();
                if (list != null && list.Count > 0)
                {
                    return JsonConvert.SerializeObject(list);
                }
                return "none";
            }
            catch (Exception ex) {
                return "error";
            }
        }

        [WebMethod(true)]
        public string AddReason(string title,string remark)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            Reason re = new Reason();
            re.Title = title;
            re.Remark = remark;
            try
            {
               // bool bol = ReasonManager.AddReason(re);
                int Id = ReasonManager.AddReasonInfo(re);
                if (Id!=0)
                {
                   // Reason reason = ReasonManager.GetReasonByMaxID();
                   // if (reason == null) { return "error"; } else { return JsonConvert.SerializeObject(reason); }
                    return Id.ToString();
                }
                else
                {
                    return "error";
                }
            }
            catch (Exception ex) {
                return "error";
            }
        }
        [WebMethod(true)]
        public string DeleData(string id) {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            try
            {
                if (ReasonManager.DeleteReasonByPK(id))
                {
                    return "success";
                }
                return "error";
            }
            catch (Exception ex) {
                return "error";
            }
        }

        [WebMethod(true)]
        public string UpdateData(string id,string title,string remark) {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            Reason re = new Reason();
            re.ID = Convert.ToInt32(id);
            re.Title = title;
            re.Remark = remark;
            try
            {
                if (ReasonManager.UpdateReason(re))
                {
                    return "success";
                }
                return "error";
            }
            catch (Exception ex) {
                return "error";
            }
        }
    }
}
