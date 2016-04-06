using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Model;
using BLL;

namespace admin.ServicesFile.ReleaseSite
{
    /// <summary>
    /// ControlDiskService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class ControlDiskService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(true)]
        public string pdt(string a,string t, string s)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string l = "";
            switch (t)
            { 
                case "4":
                    l = "ds";
                    break;
                case "5":
                    l = "zc";
                    break;
                case "6":
                    l = "zd";
                    break;
            }
            Roteds1x2hf1Manager.updateAll(a, l, s);
            return "true";
        }

        [WebMethod(true)]
        public string pdto(string i, string t, string ty,string s)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string l = "";
            switch (t)
            {
                case "4":
                    l = "ds";
                    break;
                case "5":
                    l = "zc";
                    break;
                case "6":
                    l = "zd";
                    break;
            }
            Roteds1x2hf1Manager.updateOne(i, l, ty, s);
            return "true";
        }

        [WebMethod(true)]
        //t:类型  单式，早餐，走地
        //l:比赛ID  
        //lg:语言
        //g:类型  主队,客队…………
        //i:类型  全场让球，全场标准……
        public string getXX(string t,string l,string lg,string g,string i)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string type = "";
            string d = "";
            switch (i)
            {
                case "1":
                    if (t == "4")
                    {
                        type = "12";
                        d = "orderdetail1x2";
                    }
                    else if (t == "5")
                    {
                        type = "16";
                        d = "orderdetail1x2";
                    }
                    else
                    {
                        d = "orderdetail1x2l";
                    }
                    break;
                case "2":
                    if (t == "4")
                    {
                        type = "0";
                        d = "orderdetailhdp";
                    }
                    else if (t == "5")
                    {
                        type = "8";
                        d = "orderdetailhdp";
                    }
                    else
                    {
                        d = "orderdetailhdpl";
                    }
                    break;
                case "3":
                    if (t == "4")
                    {
                        type = "1";
                        d = "orderdetailou";
                    }
                    else if (t == "5")
                    {
                        type = "9";
                        d = "orderdetailou";
                    }
                    else
                    {
                        d = "orderdetailoul";
                    }
                    break;
                case "4":
                    if (t == "4")
                    {
                        type = "13";
                        d = "orderdetail1x2hf";
                    }
                    else if (t == "5")
                    {
                        type = "17";
                        d = "orderdetail1x2hf";
                    }
                    else
                    {
                        d = "orderdetail1x2hfl";
                    }
                    break;
                case "5":
                    if (t == "4")
                    {
                        type = "2";
                        d = "orderdetailhdphf";
                    }
                    else if (t == "5")
                    {
                        type = "10";
                        d = "orderdetailhdphf";
                    }
                    else
                    {
                        d = "orderdetailhdphfl";
                    }
                    break;
                case "6":
                    if (t == "4")
                    {
                        type = "3";
                        d = "orderdetailouhf";
                    }
                    else if (t == "5")
                    {
                        type = "11";
                        d = "orderdetailouhf";
                    }
                    else
                    {
                        d = "orderdetailouhfl";
                    }
                    break;
            }
            return Roteds1x2hf1Manager.getXX(type, d, l, lg, g);
        }

        [WebMethod(true)]
        public string getInfo(int i, int t)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string tp = getT(t);
            return Roteds1x2hf1Manager.getInfo(i, tp);
        }

        [WebMethod(true)]
        public string getrqInfo(int i, int t)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string tp = getT(t);
            return Roteds1x2hf1Manager.getrqInfo(i, tp);
        }

        [WebMethod(true)]
        public string getdxInfo(int i, int t)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string tp = getT(t);
            return Roteds1x2hf1Manager.getdxInfo(i, tp);
        }

        [WebMethod(true)]
        public string updaInfo(string a,string d,string oi,string oa,string ol, int t,int l)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string tp = getT(t);
            string[] al = a.Split(';');
            string[] dl = d.Split(';');
            string[] oil = oi.Split(';');
            string[] oal = oa.Split(';');
            string[] oll = ol.Split(';');
            for (int i = 0; i < al.Length; i++)
            {
                Roteds1x2hf1Manager.updaInfo("rote" + tp + (l == 1 ? "1x2" : (l == 2 ? "hdp" : "ou")) + (al[i] == "a" ? "" : "hf") + "1", oil[i], oal[i], oll[i], int.Parse(dl[i]));

            }
            return "";
        }

        public string getT(int t)
        {
            string s = "";
            switch (t)
            { 
                case 4:
                    s = "ds";
                    break;
                case 5:
                    s = "zc";
                    break;
                case 6:
                    s = "zd";
                    break;
            }
            return s;
            
        }
    }
}
