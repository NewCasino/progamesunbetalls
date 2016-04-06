using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using Model;
using DAL;

namespace admin.ServicesFile.webBasicInfo
{
    /// <summary>
    /// noticeWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class noticeWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

       


        [WebMethod(true)]
        public string getCount()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return NoticeManager.getCount();
        }

        [WebMethod(true)]
        public string save(string cn,string tw,string en,string th,string vn,string disu,string disa,string winu,string wina)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            admin.PageBase page = new admin.PageBase();
            DateTime time = DateTime.Now;
            Notice no = new Notice();
            no.Createdate = time;
            no.Createuser = page.CurrentManager.ManagerId;
            no.Displayagent = disa;
            no.Displayuser = disu;
            no.Msgcn = cn;
            no.Msgen = en;
            no.Msgth = th;
            no.Msgtw = tw;
            no.Msgvn = vn;
            no.Windowagent = wina;
            no.Windowuser = winu;
            string reval = NoticeManager.AddNotice(no).ToString();
            if (reval == "True")
            {
                AddUpdatematches();
            }
            return reval;
        }


        [WebMethod(true)]
        public string save222(string cn, string tw, string en, string th, string vn, string disu, string disa, string winu, string wina)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            admin.PageBase page = new admin.PageBase();
            DateTime time = DateTime.Now;
            Notice no = new Notice();
            no.Createdate = time;
            no.Createuser = page.CurrentManager.ManagerId;
            no.Displayagent = disa;
            no.Displayuser = disu;
            no.Msgcn = cn;
            no.Msgen = en;
            no.Msgth = th;
            no.Msgtw = tw;
            no.Msgvn = vn;
            no.Windowagent = wina;
            no.Windowuser = winu;
            string reval = NoticeManager.AddNotice(no).ToString();
            if (reval == "True")
            {
                AddUpdatematches();
            }
            return reval;
        }


        [WebMethod(true)]
        public string update(int id,string cn, string tw, string en, string th, string vn, string disu, string disa, string winu, string wina)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            admin.PageBase page = new admin.PageBase();
            DateTime time = DateTime.Now;
            Notice no = new Notice();
            no.ID = id;
            no.Createdate = time;
            no.Createuser = page.CurrentManager.ManagerId;
            no.Displayagent = disa;
            no.Displayuser = disu;
            no.Msgcn = cn;
            no.Msgen = en;
            no.Msgth = th;
            no.Msgtw = tw;
            no.Msgvn = vn;
            no.Windowagent = wina;
            no.Windowuser = winu;
            string reval = NoticeManager.UpdateNotice(no).ToString();
            

            return reval;
        }


        public void AddUpdatematches2()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return;
            }

            string str = "13";
            IList<Model.Notice> notices = NoticeManager.GetMutilILNotice();
            foreach (Model.Notice info in notices)
            {
                str += "`" + info.Msgcn;
                str += "|" + info.Msgtw;
                str += "|" + info.Msgen;
                str += "|" + info.Msgth;
                str += "|" + info.Msgvn;
                str += "|" + info.Displayagent + info.Windowagent + info.Displayuser + info.Windowuser;
            }
            Model.Updatematches updatematches = new Updatematches();
            updatematches.Type1 = 13;
            updatematches.Content = str;
            updatematches.Updatetime = DateTime.Now;
            UpdatematchesManager.AddUpdatematches(updatematches);
        }

        
         [WebMethod(true)]
        public string delete222(int id)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string reval = NoticeManager.DeleteNoticeByPK22(id).ToString();            

            return reval;
        }

        [WebMethod(true)]
        public string delete(int id)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string reval = NoticeManager.DeleteNoticeByPK(id).ToString();
            if (reval == "True")
            {
                AddUpdatematches();
            }

            return reval;
        }

        [WebMethod(true)]
        public string getDataAll(int IDex, int IDexC)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return NoticeManager.getDataAll(IDex, IDexC);
        }
        [WebMethod(true)]
        public string getDataAll_2()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return NoticeManager.getDataAll_2();
        }
        
        [WebMethod(true)]
        public string getDataAll_1()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return NoticeManager.getDataAll_1();
        }

        //中奖信息
        [WebMethod(true)]
        public string getDataAll222()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return NoticeManager.getDataAll222();
        }
       

        public void AddUpdatematches()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return;
            }

            string str = "13";
            IList<Model.Notice> notices = NoticeManager.GetMutilILNotice();
            foreach (Model.Notice info in notices)
            {
                str += "`" + info.Msgcn;
                str += "|" + info.Msgtw;
                str += "|" + info.Msgen;
                str += "|" + info.Msgth;
                str += "|" + info.Msgvn;
                str += "|" + info.Displayagent + info.Windowagent + info.Displayuser + info.Windowuser;
            }
            Model.Updatematches updatematches = new Updatematches();
            updatematches.Type1 = 13;
            updatematches.Content = str;
            updatematches.Updatetime = DateTime.Now;
            UpdatematchesManager.AddUpdatematches(updatematches);
        }

     


        //配置设置读起
        [WebMethod(true)]
        public string GetPro_setup()
        {
            ConfigManager config = new ConfigManager();

            return ObjectToJson.ObjectListToJson<Model.Config>(config.GetPro_setup());

        }
        
        [WebMethod(true)]
        public bool UpdataPro_setup(string id, string oval)
        {
            ConfigManager config = new ConfigManager();

            return config.UpdataPro_setup(id,oval);

        }

    }
}
