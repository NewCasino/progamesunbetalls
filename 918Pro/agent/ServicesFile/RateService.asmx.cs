using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using agent.Config;
using Util;
using System.Net;
using DAL;
using BLL;

namespace agent.ServicesFile
{
    /// <summary>
    /// RateService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class RateService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(true)]
        public string GetRateAll()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return RateManager.GetRateAll();
        }

        [WebMethod]
        public string GetRateByLan(string language)
        {
            return RateManager.GetRateByLan(language);
        }

        [WebMethod(true)]
        public string CeliName(string Name, string Language)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

           return RateManager.CeliName(Name, Language).ToString();
        }

        [WebMethod(true)]
        public string GetRatetype(string Language)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return RateManager.GetRatetype(Language);
        }
        [WebMethod(true)]
        public string GetRate(string type, string time1, string time2,string language,string user)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            string json = "";

            json=BLL.RatehistoryManager.GetRate(type, time1, time2,language,user);
            if (json == "[]")
            {
                json = "none";
            }
            return json;

        }

        [WebMethod(true)]
        public string AddRate(string Name, string Rate,string Language)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            Model.Rate rate = new Model.Rate();
            if(Language=="cn")
            {
                rate.Name_cn = Name;
            }
            if (Language == "tw")
            {
                rate.Name_tw = Name;
            }
            if (Language == "en")
            {
                rate.Name_en = Name;
            }
            if (Language == "th")
            {
                rate.Name_th = Name;
            }
            if (Language == "vn")
            {
                rate.Name_vn = Name;
            }
           
            rate.Rate1 =Convert.ToDecimal(Rate);
            rate.Lasttime = DateTime.Now;
            Model.Manager m=Session[ProjectConfig.ADMINUSER] as Model.Manager;
            rate.Operator = m.ManagerId;
            string strHostName = Dns.GetHostName();
            System.Net.IPAddress[] addressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
            rate.Ip = addressList[0].ToString();  
            bool reval = BLL.RateManager.AddRate(rate);
            if (reval)
            {
                Rates rates = new Rates();
                rates.Name = Name;
                rates.Rate = Convert.ToDecimal(Rate);
                rates.Lasttime = DateTime.Now;
                rates.Operator = m.ManagerId;
                rates.Ip = addressList[0].ToString();  
                return DAL.ObjectToJson.ObjectsToJson<Rates>(rates);
            }
            else
            {
                return "none";
            }
        }

        [WebMethod(true)]
        public string UpdateRate(string Id, string Name,string uName,string Rate, string Language)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

                string json = "";
                if (Name != uName)
                {
                    if (RateManager.CeliName(Name, Language))
                    {
                        json = "stop";
                    }
                }
                if (json != "stop")
                {
                    Model.Rate rate = new Model.Rate();
                    if (Language == "cn")
                    {
                        rate.Name_cn = Name;
                    }
                    if (Language == "tw")
                    {
                        rate.Name_tw = Name;
                    }
                    if (Language == "en")
                    {
                        rate.Name_en = Name;
                    }
                    if (Language == "th")
                    {
                        rate.Name_th = Name;
                    }
                    if (Language == "vn")
                    {
                        rate.Name_vn = Name;
                    }
                    rate.Id = Convert.ToInt32(Id);
                    rate.Rate1 = Convert.ToDecimal(Rate);
                    rate.Lasttime = DateTime.Now;
                    Model.Manager m = Session[ProjectConfig.ADMINUSER] as Model.Manager;
                    rate.Operator = m.ManagerId;
                    string strHostName = Dns.GetHostName();
                    System.Net.IPAddress[] addressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
                    rate.Ip = addressList[0].ToString();
                    bool reval = BLL.RateManager.UpdateRate(rate);

                    if (reval)
                    {
                        bool ret = BLL.RatehistoryManager.AddRatehistory(rate);
                        if (ret)
                        {
                            Rates rates = new Rates();
                            rates.Name = Name;
                            rates.Rate = Convert.ToDecimal(Rate);
                            rates.Lasttime = DateTime.Now;
                            rates.Operator = m.ManagerId;
                            rates.Ip = addressList[0].ToString();
                            json = DAL.ObjectToJson.ObjectsToJson<Rates>(rates);
                        }
                        else
                        {
                            json = "none";
                        }
                    }
                }
            
            return json;
        }

        [WebMethod(true)]
        public bool DeleteRole(int Id, string Name, string Language)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            return BLL.RateManager.DeleteRate(Id,Name,Language);
        }

        partial class Rates
        {
            public Int32 Id { get; set; }

            public String Name { get; set; }

            public Decimal Rate { get; set; }

            public DateTime Lasttime { get; set; }

            public String Operator { get; set; }

            public String Ip { get; set; }
        }

    }
}
