using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAL;
using System.Threading;
using System.Net;
using System.IO.Compression;
using System.IO;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Data;
using System.Drawing.Imaging;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Drawing;

namespace admin.Report
{
    public partial class CheckOrderOtherHistory : admin.PageBase
    {
        private static Dictionary<string, Orderotherhistory> ErrorOrders = new Dictionary<string, Orderotherhistory>();

        //线程计数器
        public static int tcount = 0;
        private static bool isContinueThread = true;
        public static Encoding big5 = Encoding.GetEncoding("big5");
        public static Encoding utf8 = Encoding.UTF8;
        public static Encoding gb2312 = Encoding.GetEncoding("gb2312");
        public string ip = "";
        //----定义权限变量---------
        protected bool viewAc = true;  //查看
        protected void Page_Load(object sender, EventArgs e)
        {
            ip = Request.ServerVariables["Remote_Addr"];
            //-----------权限控制开始-----------
            //当前角色
            int Rid = CurrentManager.RoleId;

            BLL.Sys_role_rightManager rrService = new BLL.Sys_role_rightManager();

            //查看权限
            if (!rrService.IsPermission(Rid, 181))
            {
                viewAc = false;
                Response.Write("<script>alert('非法操作，请返回!');window.close();</script>");
                Response.End();
            }
            //if (!IsPostBack)
            //{
            //    DataTable dt = DAL.MySqlHelper.ExecuteDataTable("select id,nametw from yafa.casino ");
            //    webWhereVal.DataSource = dt;
            //    webWhereVal.DataTextField = "nametw";
            //    webWhereVal.DataValueField = "id";
            //    webWhereVal.DataBind();
            //}
        }
        /// <summary>
        /// 输出到Excel
        /// </summary>
        /// <param name="page">page类</param>
        /// <param name="fileName">Excel文件名</param>
        /// <param name="table">表格html内容</param>
        protected void ExportToXls(Page page, string fileName, string table)
        {
            page.Response.Clear();
            page.Response.Buffer = true;
            //page.Response.Charset = "GB2312";
            page.Response.Charset = "UTF-8";
            page.Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName + System.DateTime.Now.ToString("_yyMMdd_hhmmss") + ".xls");
            //page.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");//设置输出流为简体中文
            page.Response.ContentEncoding = System.Text.Encoding.UTF8;
            page.Response.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。 
            page.EnableViewState = false;
            page.Response.Write(table);
            page.Response.End();
        }
        protected void excel_Click(object sender, EventArgs e)
        {
            string table = "";
            table = hfContent.Value;
            ExportToXls(this.Page, this.nameValue.Value, table);
        }
        private string Format(Dictionary<string, Orderotherhistory> orderOthers)
        {

            int i = 0;
            if (orderOthers.Count <= 0) return string.Empty;
            StringBuilder jsonString = new StringBuilder();
            jsonString.Append("[");
            //loop through all values
            foreach (Orderotherhistory orderOther in orderOthers.Values)
            {
                jsonString.Append("{");
                jsonString.Append("\"ID\":\"" + (++i) + "\",");
                jsonString.Append("\"Time\":\"" + orderOther.Time + "\",");
                jsonString.Append("\"UserName\":\"" + orderOther.UserName + "\",");
                jsonString.Append("\"OrderID\":\"" + orderOther.OrderID + "\",");
                jsonString.Append("\"WebUserName\":\"" + orderOther.WebUserName + "\",");
                jsonString.Append("\"WebOrderID\":\"" + orderOther.WebOrderID + "\",");
                jsonString.Append("\"League\":\"" + orderOther.Leaguetw + "\",");
                jsonString.Append("\"BeginTime\":\"" + orderOther.BeginTime + "\",");
                jsonString.Append("\"Home\":\"" + orderOther.Hometw + "\",");
                jsonString.Append("\"Away\":\"" + orderOther.Awaytw + "\",");
                jsonString.Append("\"BetType\":\"" + orderOther.BetType + "\",");
                jsonString.Append("\"Handicap\":\"" + orderOther.Handicap + "\",");
                jsonString.Append("\"BetItem\":\"" + orderOther.BetItem + "\",");
                jsonString.Append("\"Odds\":\"" + orderOther.Odds + "\",");
                jsonString.Append("\"Amount\":\"" + orderOther.Amount + "\",");
                jsonString.Append("\"ValidAmount\":\"" + orderOther.ValidAmount + "\",");
                jsonString.Append("\"Status\":\"" + orderOther.Status + "\",");
                jsonString.Append("\"WebSiteID\":\"" + orderOther.WebSiteiID + "\",");
                jsonString.Append("\"ErrorMessage\":\"" + orderOther.ErrorMessage + "\"");
                jsonString.Append("},");
            }
            if (jsonString.Length > 1)
            {
                jsonString.Remove(jsonString.Length - 1, 1);
            }
            jsonString.Append("]");
            return jsonString.ToString();
        }
        //protected void btnCheck_Click(object sender, EventArgs e)
        //{
        //    string time1 = time1WhereVal.Text;
        //    string time2 = time2WhereVal.Text;
        //    string casino = webWhereVal.SelectedValue;
        //    List<DateTime> date = new List<DateTime>();
        //    string s = string.Empty;
        //    int i = 0;
        //    if (time1 != "" && time2 != "")
        //    {
        //        DateTime one = Convert.ToDateTime(time1);
        //        DateTime two = Convert.ToDateTime(time2);
        //        int day = (two - one).Days;
        //        one = day > 0 ? one : two;
        //        for (i = 0; i <= day; i++)
        //        {
        //            DateTime d = one.AddDays(i);
        //            date.Add(d);
        //        }
        //    }
        //    else
        //    {
        //        DateTime time = Convert.ToDateTime(time1 == "" ? time2 : time1); ;
        //        for (i = 0; i < 3; i++)
        //        {
        //            DateTime d = time.AddDays(i - 1);
        //            date.Add(d);
        //        }
        //    }
        //    readHistory2(casino, date);
        //    s = Format(ErrorOrders);
        //    ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>ParseErrorOrders('" + (s == "[]" ? "" : s) + "');</script>");
        //}

        #region 下注历史对数
        public string readHistory2(string casino, List<DateTime> date)
        {
            string result = string.Empty;
            Dictionary<string, Orderotherhistory> dicTemp = new Dictionary<string, Orderotherhistory>();
            Dictionary<string, Orderotherhistory> ErrorOrders = new Dictionary<string, Orderotherhistory>();
            IList<Betaccount> allAccounts = new List<Betaccount>();
            try
            {
                AccountService accounts = new AccountService();
                //根据网站查找出所有的帐号
                allAccounts = accounts.GetBetAccount(casino);
                Dictionary<string, Orderotherhistory> orderHistorys = new Dictionary<string, Orderotherhistory>();
                //根据网站查找出所有的帐号的外调注单
                //orderHistorys = accounts.GetOrderListByWebsiteID(casino);
                foreach (Betaccount account in allAccounts)
                {
                    dicTemp = readTHistory(account, orderHistorys, date);
                    foreach (KeyValuePair<string, Orderotherhistory> k in dicTemp)
                    {
                        ErrorOrders.Add(k.Key, k.Value);
                    }
                }
                result = Format(ErrorOrders);
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public Dictionary<string, Orderotherhistory> readTHistory(Betaccount account, Dictionary<string, Orderotherhistory> orderHistorys, List<DateTime> date)
        {
            BetAccountOrderHistory betAccountOrderHistory = new BetAccountOrderHistory(account, date, orderHistorys);
            Dictionary<string, Orderotherhistory> dic = new Dictionary<string, Orderotherhistory>();
            switch (account.Casino)
            {
                case 1:

                    dic = huanguanReadHistory2(betAccountOrderHistory);
                    break;
                case 2:
                    //dic = lijiReadHistory2(betAccountOrderHistory);
                    break;
                case 3:
                    //dic = shabaReadHistory2(betAccountOrderHistory);
                    break;
                case 4:
                    dic = xinqiuReadHistory2(betAccountOrderHistory);
                    break;
                case 5:
                    //dic = yongliReadHistory2(betAccountOrderHistory);
                    break;
                case 6:
                    break;
                case 7:
                    dic = as3388ReadHistory2(betAccountOrderHistory);
                    break;
                case 8:
                    dic = huangchaoReadHistory2(betAccountOrderHistory);
                    break;
            }
            return dic;
        }

        //一次性从数据库取出所有注单，通过单个帐号获取对应的注单
        public static Dictionary<string, Orderotherhistory> GetDicByAccount(string accountName, Dictionary<string, Orderotherhistory> orderHistorys)
        {
            Dictionary<string, Orderotherhistory> allOrderHistorys = new Dictionary<string, Orderotherhistory>();
            var pf = from d in orderHistorys
                     where d.Value.WebUserName == accountName
                     select d.Value;
            foreach (var item in pf)
            {
                allOrderHistorys.Add(item.WebOrderID, item);
            }
            return allOrderHistorys;
        }

        public static void AddErrorDictionary(Orderotherhistory orderOtherHistory)
        {
            try
            {
                lock (orderOtherHistory)
                {
                    ErrorOrders.Add(orderOtherHistory.WebOrderID, orderOtherHistory);
                }
            }
            catch (Exception)
            {

            }
        }

        public static string GetRandomOrderId()
        {
            Random rand = new Random();
            string orderId = string.Empty;
            while (true)
            {
                orderId = rand.Next(1, 10000).ToString();
                if (!ErrorOrders.ContainsKey(orderId))
                    break;
            }
            return orderId;
        }

        #region
        public static Dictionary<string, Orderotherhistory> huanguanReadHistory2(BetAccountOrderHistory betAccountOrderHistory)
        {
            Dictionary<string, Orderotherhistory> dic = new Dictionary<string, Orderotherhistory>();
            
            //一次性从数据库取出所有注单，通过单个帐号获取对应的注单
            betAccountOrderHistory.OrderOtherHistorys = GetDicByAccount(betAccountOrderHistory.account.Userid, betAccountOrderHistory.OrderOtherHistorys);
            if (betAccountOrderHistory.OrderOtherHistorys.Count <= 0)
            {
                tcount++;
                return dic;
            }
            Orderotherhistory order1 = null;
            Orderotherhistory order2 = null;

            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string content = "";
            string url = null;
            string temp = "";
            string referer = null;
           
            string[] sar;
            byte[] bytes;
            int count = 0, page = 0, pagecount = 1;
            int count2 = 0;

            betAccountOrderHistory.account.islogin = 0;
            //string begintime = betAccountOrderHistory.date[0].AddDays(-1).ToString();
            //string endtime = betAccountOrderHistory.date[0].AddDays(+ (betAccountOrderHistory.date.Count - 1)).ToString();
        label10:
            if (betAccountOrderHistory.account.Cookie.Length < 10)
            {
              
                huangguanlogin(betAccountOrderHistory.account);
                if (betAccountOrderHistory.account.islogin != 1)
                {
                    if (count < 2)
                    {
                        count++;
                        betAccountOrderHistory.account.Cookie = "";
                        goto label10;
                    }
                    else
                    {

                        order1 = new Orderotherhistory();
                        order1.WebUserName = betAccountOrderHistory.account.Userid;
                        order1.WebOrderID = GetRandomOrderId();
                        order1.ErrorMessage = "帐号" + betAccountOrderHistory.account.Userid + "核对下注历史失败,账号无法登陆";
                        dic.Add(order1.WebOrderID, order1);
                        return dic;
                    }

                }
               
            }

           
            try
            {
                url = "http://" + betAccountOrderHistory.account.Address + "/app/member/history/history_data.php?uid=" + betAccountOrderHistory.account.Cookie + "&langx=zh-tw";
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                request.Referer = referer;
                request.Headers["Accept-Language"] = "zh-cn";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers["Accept-Encoding"] = "gzip,deflate,sdch";

                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET4.0C; .NET4.0E; CIBA; InfoPath.3)";
                request.KeepAlive = true;
                request.AllowAutoRedirect = false;
                response = (HttpWebResponse)request.GetResponse();
                if (response.Headers.Get("Content-Encoding") != null)
                {
                    stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    reader = new StreamReader(stream, utf8);
                }
                else
                {
                    reader = new StreamReader(response.GetResponseStream(), utf8);
                }
                content = reader.ReadToEnd();
                if (content.Contains("logout_warn.html") || content.Length == 0)
                {
                    if (count2 < 2)
                    {
                        betAccountOrderHistory.account.Cookie = "";
                        goto label10;
                    }
                    else
                    {
                        order1 = new Orderotherhistory();
                        order1.WebUserName = betAccountOrderHistory.account.Userid;
                        order1.WebOrderID = GetRandomOrderId();
                        order1.ErrorMessage = "帐号" + betAccountOrderHistory.account.Userid + "核对下注历史失败,账号已被登出";
                        dic.Add(order1.WebOrderID, order1);
                        return dic;
                    }
                }
                if (!content.Contains("<td class=\"b_fwn\"><font color=#CC0000>") && !content.Contains("<a href=\"history_view.php?uid="))
                {
                    if (count2 < 2)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {

                        order1 = new Orderotherhistory();
                        order1.WebUserName = betAccountOrderHistory.account.Userid;
                        order1.WebOrderID = GetRandomOrderId();
                        order1.ErrorMessage = "帐号" + betAccountOrderHistory.account.Userid + "核对下注历史失败";
                        dic.Add(order1.WebOrderID, order1);
                        return dic;
                    }
                }
                else if (content.Contains("<td class=\"b_fwn\"><font color=#CC0000>") && !content.Contains("<a href=\"history_view.php?uid="))
                {
                    order1 = new Orderotherhistory();
                    order1.WebUserName = betAccountOrderHistory.account.Userid;
                    order1.WebOrderID = GetRandomOrderId();
                    order1.ErrorMessage = "帐号" + betAccountOrderHistory.account.Userid + "没有投注，投注额为零";
                    dic.Add(order1.WebOrderID, order1);
                    return dic;
                }

            }
            catch(Exception e)
            {
                if (count2 < 2)
                {
                    count++;
                   
                    goto label10;
                }
                else if (count2 < 4)
                {
                    count++;
                    betAccountOrderHistory.account.Cookie = "";
                    goto label10;
                }
                else
                {
                    order1 = new Orderotherhistory();
                    order1.WebUserName = betAccountOrderHistory.account.Userid;
                    order1.WebOrderID = GetRandomOrderId();
                    order1.ErrorMessage = "帐号" + betAccountOrderHistory.account.Userid + "核对下注历史失败,账号已被登出";
                    dic.Add(order1.WebOrderID, order1);
                    return dic;
                }

            }
            finally
            {
                try
                {
                    response.Close();

                }
                catch
                {
                    ;
                }
                try
                {
                    reader.Close();
                }
                catch
                {
                    ;
                }
            }

            sar = content.Split(new string[] { "<td class=\"b_fwn\"><a href=\"" }, StringSplitOptions.None);

            for (int j = 1; j < sar.Length; j++)
            {


                string url2 = "history_view.php?" + substring(sar[j], "history_view.php?", "&page=");
               
                while (page < pagecount)
                {
                label20:
                    try
                    {
                        //http://www.hg0088.com/app/member/history/history_view.php?uid=4145005cm6261502l21363743&member_id=6261502&tmp_flag=Y&today_gmt=2011-03-23&gtype=ALL&gdate=2011-03-22&gdate1=2011-03-29&chk_date=2011-03-20&page=0
                        //url = "http://" + user.Address + "/app/member/history/history_view.php?uid=" + user.cookie + "&member_id=" + member_id + "&tmp_flag=Y&today_gmt=" + today_gmt + "&gtype=ALL&gdate=" + gdate + "&gdate1=" + gdate1 + "&chk_date=" + chk_date + "&page=" + page;
                        url = "http://" + betAccountOrderHistory.account.Address + "/app/member/history/" + url2 + "&page=" + page.ToString();
                        page++;
                        //referer = "http://" + betAccountOrderHistory.account.Address + "/app/member/history/history_data.php?uid=" + betAccountOrderHistory.account.Cookie + "&langx=zh-tw";
                        request = (HttpWebRequest)WebRequest.Create(url);
                        request.Method = "GET";
                        request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                        //request.Referer = referer;
                        request.Headers["Accept-Language"] = "zh-cn";

                        request.Headers["Accept-Encoding"] = "gzip,deflate";
                        request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET4.0C; .NET4.0E; CIBA; InfoPath.3)";
                        request.KeepAlive = true;
                        request.Timeout = 5000;

                        response = (HttpWebResponse)request.GetResponse();
                        if (response.Headers.Get("Content-Encoding") != null)
                        {
                            stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                            reader = new StreamReader(stream, utf8);
                        }
                        else
                        {
                            reader = new StreamReader(response.GetResponseStream(), utf8);
                        }
                        content = reader.ReadToEnd();
                        if (content.Trim().Length == 0 || content.Contains("logout_warn.html"))
                        {

                            if (count2 < 3)
                            {
                                count2++;
                                betAccountOrderHistory.account.Cookie = "";
                                Thread.Sleep(5000);
                                goto label10;
                            }
                            else
                            {
                                order2 = new Orderotherhistory();
                                order2.WebUserName = betAccountOrderHistory.account.Userid;
                                order1.WebOrderID = GetRandomOrderId();
                                order1.ErrorMessage = "帐号" + betAccountOrderHistory.account.Userid + "第" + j + "天核对下注历史失败,账号已被登出";
                                dic.Add(order2.WebOrderID, order2);
                                return dic;
                            }
                        }

                        if (!content.Contains("<tr class=\"b_rig\">"))
                        {
                            order2 = new Orderotherhistory();
                            order2.WebUserName = betAccountOrderHistory.account.Userid;
                            order1.WebOrderID = GetRandomOrderId();
                            order1.ErrorMessage = "皇冠帐号" + betAccountOrderHistory.account.Userid + "第" + j + "天第" + page + "页查询失败";
                            dic.Add(order2.WebOrderID, order2);
                            continue; ;
                        }
                        string type2 = "";
                        string[] str;
                        string handicap = "";
                        string WebOrderID = "";
                        page = int.Parse(substring(content, "<option value=\"0\" SELECTED>", "</option>").Trim());
                        pagecount = int.Parse(substring(content, "</select>&nbsp;&nbsp;/", "頁").Replace(" ", ""));
                        str = content.Split(new string[] { "<tr class=\"b_rig\">" }, StringSplitOptions.None);
                        for (int i = 1; i < str.Length - 1; i++)
                        {
                            try
                            {
                                WebOrderID = substring(str[i], "#0000CC\">", "</font>");
                                if (!WebOrderID.Contains("OU"))
                                    continue;
                                order1 = new Orderotherhistory();
                                order1.WebOrderID = WebOrderID;
                                type2 = substring(str[i], "nowrap>", "<BR>");
                                order1.Time = Convert.ToDateTime(substring(str[i], "<td align=\"center\">", "</td>").Replace("<br>", " "));

                                order1.Score = substring(str[i], "class=\"td_13_c\" color=\"red\"><B>&nbsp;&nbsp;", "</font>");
                                order1.Score = substring(str[i], "#009900\"><b>", "</b></font>").Trim();
                                order1.Odds = decimal.Parse(substring(str[i], "@&nbsp;<font color=#CC0000><B>", "</B></font>"));
                                order1.Leaguetw = substring(str[i], "<td>", "<br>");
                                order1.Handicap = substring(str[i], "<font color=#0000BB><b>", "</b></font>");
                                order1.Amount = decimal.Parse(substring(str[i], "<td><font color=\"#CC0000\">", "</font>"));
                                temp = substring(str[i], "<td><font color=\"#CC0000\">", "<td></td>");
                                order1.ValidAmount = decimal.Parse(substring(temp, "<td>", "</td>"));
                                switch (type2)
                                {
                                    case "足球讓球":
                                        order1.BetType = "0";
                                        order1.Hometw = substring(str[i], "]<br>", "<font").Replace(" ", "");
                                        order1.Awaytw = substring(str[i], "</b></font>", "<font class=").Replace(" ", "");
                                        order1.BetItem = substring(str[i], "</b></font><font color=#CC0000>", "</font>").Replace(" ", "");
                                        if (order1.Hometw == order1.BetItem)
                                        {
                                            order1.Handicap = "-" + order1.Handicap;
                                        }
                                        break;
                                    case "足球大小":
                                        order1.BetType = "1";
                                        order1.Hometw = substring(str[i], "]<br>", "<font").Replace(" ", "");
                                        order1.Awaytw = substring(str[i], "</b></font>", "<font class=").Replace(" ", "");
                                        order1.BetItem = substring(str[i], "</b></font><font color=#CC0000>", "</font>").Replace(" ", "");
                                        break;
                                    case "足球上半場讓球":
                                        order1.BetType = "2";
                                        order1.Hometw = substring(str[i], "]<br>", "<font").Replace(" ", "");
                                        order1.Awaytw = substring(str[i], "</b></font>", "<font class=").Replace(" ", "");
                                        order1.BetItem = substring(str[i], "</b></font><font color=#CC0000>", "</font>").Replace(" ", "");
                                        if (order1.Hometw == order1.BetItem)
                                        {
                                            order1.Handicap = "-" + order1.Handicap;
                                        }
                                        break;
                                    case "足球上半場大小":
                                        order1.BetType = "3";
                                        order1.Hometw = substring(str[i], "]<br>", "<font").Replace(" ", "");
                                        order1.Awaytw = substring(str[i], "</b></font>", "<font class=").Replace(" ", "");
                                        order1.BetItem = substring(str[i], "</b></font><font color=#CC0000>", "</font>").Replace(" ", "");
                                        break;
                                    case "足球滚球":
                                        order1.BetType = "4";
                                        order1.Hometw = substring(str[i], "]<br>", "<font").Replace(" ", "");
                                        order1.Awaytw = substring(str[i], "</b></font>", "<font class=").Replace(" ", "");
                                        order1.BetItem = substring(str[i], "</b></font><font color=#CC0000>", "</font>").Replace(" ", "");
                                        if (order1.Hometw == order1.BetItem)
                                        {
                                            order1.Handicap = "-" + order1.Handicap;
                                        }
                                        break;
                                    case "足球滾球大小":
                                        order1.BetType = "5";
                                        order1.Hometw = substring(str[i], "]<br>", "<font").Replace(" ", "");
                                        order1.Awaytw = substring(str[i], "</b></font>", "<font class=").Replace(" ", "");
                                        order1.BetItem = substring(str[i], "</b></font><font color=#CC0000>", "</font>").Replace(" ", "");
                                        break;
                                    case "足球上半滾球":
                                        order1.BetType = "6";
                                        order1.Hometw = substring(str[i], "]<br>", "<font").Replace(" ", "");
                                        order1.Awaytw = substring(str[i], "</b></font>", "<font class=").Replace(" ", "");
                                        order1.BetItem = substring(str[i], "</b></font><font color=#CC0000>", "</font>").Replace(" ", "");
                                        if (order1.Hometw == order1.BetItem)
                                        {
                                            order1.Handicap = "-" + order1.Handicap;
                                        }
                                        break;
                                    case "足球上半滾球大小":
                                        order1.BetType = "7";
                                        order1.Hometw = substring(str[i], "]<br>", "<font").Replace(" ", "");
                                        order1.Awaytw = substring(str[i], "</b></font>", "<font class=").Replace(" ", "");
                                        order1.BetItem = substring(str[i], "</b></font><font color=#CC0000>", "</font>").Replace(" ", "");
                                        break;
                                    case "足球早餐單式讓球":
                                        order1.BetType = "8";
                                        order1.Hometw = substring(str[i], "]<br>", "<font").Replace(" ", "");
                                        order1.Awaytw = substring(str[i], "</b></font>", "<font class=").Replace(" ", "");
                                        order1.BetItem = substring(str[i], "</b></font><font color=#CC0000>", "</font>").Replace(" ", "");
                                        if (order1.Hometw == order1.BetItem)
                                        {
                                            order1.Handicap = "-" + order1.Handicap;
                                        }
                                        break;
                                    case "足球早餐單式大小":
                                        order1.BetType = "9";
                                        order1.Hometw = substring(str[i], "]<br>", "<font").Replace(" ", "");
                                        order1.Awaytw = substring(str[i], "</b></font>", "<font class=").Replace(" ", "");
                                        order1.BetItem = substring(str[i], "</b></font><font color=#CC0000>", "</font>").Replace(" ", "");
                                        break;
                                    case "足球早餐上半讓球":
                                        order1.BetType = "10";
                                        order1.Hometw = substring(str[i], "]<br>", "<font").Replace(" ", "");
                                        order1.Awaytw = substring(str[i], "</b></font>", "<font class=").Replace(" ", "");
                                        order1.BetItem = substring(str[i], "</b></font><font color=#CC0000>", "</font>").Replace(" ", "");
                                        if (order1.Hometw == order1.BetItem)
                                        {
                                            order1.Handicap = "-" + order1.Handicap;
                                        }
                                        break;
                                    case "足球早餐上半大小":
                                        order1.BetType = "11";
                                        order1.Hometw = substring(str[i], "]<br>", "<font").Replace(" ", "");
                                        order1.Awaytw = substring(str[i], "</b></font>", "<font class=").Replace(" ", "");
                                        order1.BetItem = substring(str[i], "</b></font><font color=#CC0000>", "</font>").Replace(" ", "");
                                        break;
                                    case "足球獨贏":
                                        order1.BetType = "12";
                                        order1.Hometw = substring(str[i], "]<br>", "<b><font").Replace(" ", "");
                                        order1.Awaytw = substring(str[i], "</font></b>", "<font class=").Replace(" ", "");
                                        order1.BetItem = substring(str[i], "</b></font> <font color=#CC0000>", "</font>").Replace(" ", "");
                                        break;
                                    case "足球上半場獨贏":
                                        order1.BetType = "13";
                                        order1.Hometw = substring(str[i], "]<br>", "<b><font").Replace(" ", "");
                                        order1.Awaytw = substring(str[i], "</font></b>", "<font class=").Replace(" ", "");
                                        order1.BetItem = substring(str[i], "</b></font> <font color=#CC0000>", "</font>").Replace(" ", "");
                                        break;
                                    case "足球滚球独赢":
                                        order1.BetType = "14";
                                        order1.Hometw = substring(str[i], "]<br>", "<b><font").Replace(" ", "");
                                        order1.Awaytw = substring(str[i], "</font></b>", "<font class=").Replace(" ", "");
                                        order1.BetItem = substring(str[i], "</b></font> <font color=#CC0000>", "</font>").Replace(" ", "");
                                        break;
                                    case "足球上半場滾球獨贏":
                                        order1.BetType = "15";
                                        order1.Hometw = substring(str[i], "]<br>", "<b><font").Replace(" ", "");
                                        order1.Awaytw = substring(str[i], "</font></b>", "<font class=").Replace(" ", "");
                                        order1.BetItem = substring(str[i], "</b></font> <font color=#CC0000>", "</font>").Replace(" ", "");
                                        break;
                                    case "足球早餐單式獨贏":
                                        order1.BetType = "16";
                                        order1.Hometw = substring(str[i], "]<br>", "<b><font").Replace(" ", "");
                                        order1.Awaytw = substring(str[i], "</font></b>", "<font class=").Replace(" ", "");
                                        order1.BetItem = substring(str[i], "</b></font> <font color=#CC0000>", "</font>").Replace(" ", "");
                                        break;
                                    case "足球早餐上半獨贏":
                                        order1.BetType = "17";
                                        order1.Hometw = substring(str[i], "]<br>", "<b><font").Replace(" ", "");
                                        order1.Awaytw = substring(str[i], "</font></b>", "<font class=").Replace(" ", "");
                                        order1.BetItem = substring(str[i], "</b></font> <font color=#CC0000>", "</font>").Replace(" ", "");
                                        break;

                                }
                                order1.s = "<tr class=\"b_rig\">" + str[i];
                                order1.Odds = (decimal)(0.100);
                                try
                                {
                                    if (int.Parse(order1.BetType) < 12)
                                    {
                                        if (order1.Handicap.Contains("-"))
                                        {
                                            handicap = "-";

                                        }
                                        order1.Handicap = order1.Handicap.Replace(" ", "").Replace("+", "");
                                        if (order1.Handicap.Contains("/"))
                                        {

                                            handicap = handicap + ((Math.Abs(double.Parse(order1.Handicap.Substring(0, order1.Handicap.IndexOf("/")))) + double.Parse(order1.Handicap.Substring(order1.Handicap.IndexOf("/") + 1))) / 2).ToString();
                                            order1.Handicap = handicap;
                                        }

                                    }

                                    if (betAccountOrderHistory.OrderOtherHistorys.ContainsKey(order1.WebOrderID))
                                    {
                                        order2 = betAccountOrderHistory.OrderOtherHistorys[order1.WebOrderID];
                                        if (int.Parse(order1.BetType) < 12)
                                        {
                                            if (order1.Score != order2.Score || order1.Handicap != order2.Handicap || (int)(order1.Amount / 10) != (int)(order2.Amount / 10) || (int)(order1.ValidAmount / 10) != (int)(order2.ValidAmount / 10) || order1.Odds != order2.Odds || order1.BetType != order2.BetType)
                                            {
                                                order1.ErrorMessage = "皇冠网站的结算数据，结算的数据有差异";
                                                order2.ErrorMessage = "公司的结算数据，结算的数据有差异";
                                                order2.WebOrderID = order2.WebOrderID + "*";
                                                dic.Add(order1.WebOrderID, order1);
                                                dic.Add(order2.WebOrderID, order2);


                                            }

                                            betAccountOrderHistory.OrderOtherHistorys.Remove(order1.WebOrderID);

                                        }
                                        else
                                        {
                                            if (order1.Score != order2.Score || (int)(order1.Amount / 10) != (int)(order2.Amount / 10) || (int)(order1.ValidAmount / 10) != (int)(order2.ValidAmount / 10) || order1.Odds != order2.Odds || order1.BetType != order2.BetType)
                                            {
                                                order1.ErrorMessage = "皇冠网站的结算数据，结算的数据有差异";
                                                order2.ErrorMessage = "公司的结算数据，结算的数据有差异";
                                                order2.WebOrderID = order2.WebOrderID + "*";
                                                dic.Add(order1.WebOrderID, order1);
                                                dic.Add(order2.WebOrderID, order2);

                                            }

                                            betAccountOrderHistory.OrderOtherHistorys.Remove(order1.WebOrderID);

                                        }
                                    }
                                    else
                                    {
                                        order1.ErrorMessage = "没有在公司已结算的注单中找到这笔投注";
                                        dic.Add(order1.WebOrderID, order1);

                                    }
                                }
                                catch(Exception e)
                                {
                                    ;
                                }


                            }
                            catch (Exception e)
                            {

                                if (order1.WebOrderID.Length > 6)
                                {

                                    order1.WebUserName = betAccountOrderHistory.account.Userid;
                                    order1.ErrorMessage = "帐号" + betAccountOrderHistory.account.Userid + "的注单" + order1.WebOrderID + "因为数据分析过程中出现异常，核对下注历史失败,请手工核对" + str[i];
                                    order1.s = "<tr class=\"b_rig\">" + sar[i];
                                    dic.Add(order1.WebOrderID, order1);
                                }
                                else
                                {
                                    order2 = new Orderotherhistory();
                                    order2.WebUserName = betAccountOrderHistory.account.Userid;
                                    order1.WebOrderID = GetRandomOrderId();
                                    order2.ErrorMessage = "帐号" + betAccountOrderHistory.account.Userid + "的注单因为数据分析过程中出现异常，核对下注历史失败,请手工核对" + str[i];
                                    order2.s = "<tr class=\"b_rig\">" + sar[i];
                                    dic.Add(order2.WebOrderID, order2);

                                }
                            }
                        }
                        if (page >= pagecount)
                        {
                            break;
                        }
                    }
                    catch (Exception ee)
                    {

                        if (count2 < 4)
                        {
                            count2++;
                            goto label20;
                        }
                        else if (count2 < 6)
                        {
                            count2++;
                            betAccountOrderHistory.account.Cookie = "";
                            goto label10;

                        }
                        else
                        {
                            order2 = new Orderotherhistory();
                            order2.WebOrderID = GetRandomOrderId();
                            order2.WebUserName = betAccountOrderHistory.account.Userid;
                            order2.ErrorMessage = "帐号" + order1.WebUserName + "核对下注历史失败";
                            dic.Add(order2.WebOrderID, order2);
                            return dic;
                        }

                    }
                    finally
                    {
                        try
                        {
                            reader.Close();
                        }
                        catch
                        {
                            ;
                        }
                        try
                        {
                            response.Close();


                        }
                        catch
                        {
                            ;
                        }
                    }


                }
            }
            if (betAccountOrderHistory.account.islogin == 1)
            {
                huangguanlogout(betAccountOrderHistory.account);
            }
            try
            {
                foreach (string key in betAccountOrderHistory.OrderOtherHistorys.Keys)
                {
                    order2 = new Orderotherhistory();
                    order2.WebOrderID = key;
                    order2 = betAccountOrderHistory.OrderOtherHistorys[key];
                    order2.ErrorMessage = "没有在皇冠网站已结算的注单中找到这笔投注";
                    dic.Add(order2.WebOrderID, order2);
                }
            }
            catch(Exception e)
            {
                ;
            }
            return dic;

               
        }

        public static Dictionary<string, Orderotherhistory> lijiReadHistory2(BetAccountOrderHistory betAccountOrderHistory)
        {
            Dictionary<string, Orderotherhistory> dic = new Dictionary<string, Orderotherhistory>();
            IList<Orderotherhistory> dataList = new List<Orderotherhistory>();
            Orderotherhistory orderOther = null;
            //一次性从数据库取出所有注单，通过单个帐号获取对应的注单
            betAccountOrderHistory.OrderOtherHistorys = GetDicByAccount(betAccountOrderHistory.account.Userid, betAccountOrderHistory.OrderOtherHistorys);
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            string content = string.Empty;
            string html = string.Empty;
            Encoding utf8 = Encoding.UTF8;
            string url = string.Empty;
            int count = 0;
            int errCount = 0;
            string[] item = null;
            string[] item2 = null;
            string betType = string.Empty;
            string insertTime = string.Empty;
            string beginTime = string.Empty;
            for (int i = 0; i < betAccountOrderHistory.date.Count; i++)
            {
                //time = Convert.ToDateTime(time).AddDays(i).ToString("MM/dd/yyyy");
            label20:
                try
                {
                    //http://cqqzmx3ycf0z.softnike.com/webroot/restricted/Betlist/BetList.aspx?d=04/07/2011&option=c
                    //http://ta602i96yeca.sbobet.com/webroot/restricted/Betlist/BetList.aspx?d=04/03/2011&option=c
                    url = "http://" + betAccountOrderHistory.account.Address2 + "/webroot/restricted/Betlist/BetList.aspx?d=" + Convert.ToDateTime(betAccountOrderHistory.date[i]).ToString("MM/dd/yyyy") + "&option=c";
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/QVOD, */*";
                    request.Referer = "http://" + betAccountOrderHistory.account.Address2 + "/webroot/restricted/Betlist/Statement.aspx";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.KeepAlive = true;
                    request.Timeout = 6000;
                    request.Headers["Cache-Control"] = "no-cache";
                    request.Headers["Cookie"] = betAccountOrderHistory.account.Cookie;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                        reader = new StreamReader(stream, utf8);
                    }
                    else
                    {
                        reader = new StreamReader(response.GetResponseStream(), utf8);
                    }
                    html = reader.ReadToEnd();
                    if (string.IsNullOrEmpty(html.Replace("\r", "").Replace("\n", "").Replace(" ", "").Trim()))
                    {
                        orderOther = new Orderotherhistory();
                        orderOther.WebUserName = betAccountOrderHistory.account.Userid;
                        orderOther.WebOrderID = GetRandomOrderId();
                        orderOther.ErrorMessage = "帐号" + orderOther.WebUserName + "核对下注历史失败,cookie失效";
                        dic.Add(orderOther.WebOrderID,orderOther);
                        return dic;
                    }
                    if (html.Contains("目前無符合資訊"))
                    {
                        continue;
                    }
                    if (html.Contains("Bet List (Running)"))
                    {
                        content = substring(html, "class=\"TableFrame\"", "class=\"TRTotal\"");
                        while (content.IndexOf("<tr bgColor") > 0)
                        {
                            orderOther = new Orderotherhistory();
                            count = 0;
                            content = substring(content, "<tr bgColo", "</tr>");
                            while (content.IndexOf("<td") > 0)
                            {
                                count++;
                                item = null;
                                if (count == 2)
                                {
                                    item = substring(content, "<td>", "</td>").Replace("/span>", "$").Split('$');
                                    orderOther.WebOrderID = substring(item[0], ">", "<").Trim();
                                    insertTime = substring(substring(item[2].Replace("\n", "").Replace("\r", "").Replace("\t", ""), "<span", "br/>"), ">", "<");
                                }
                                else if (count == 3)
                                {
                                    item = substring(content, "<td", "</td>").Replace("/span>", "$").Split('$');
                                    orderOther.Handicap = substring(item[0], "style=\"\">", "<").Split(' ')[1].Trim();
                                    betType = substring(item[1].Replace("<br />", ""), ">", "<");
                                    beginTime = substring("$" + item[4], "$", "<").Replace("\n", "").Replace("\r", "");
                                    orderOther.BeginTime =Convert.ToDateTime(beginTime);
                                    item2 = substring(item[2], "style=\"\">", "<").Replace("-vs-", "$").Replace(" ", "").Split('$');
                                    orderOther.Homecn = item2[0].Trim();
                                    orderOther.Awaycn = item2[1].Trim();
                                    orderOther.Leaguecn = substring(item[3], "FontNormal\">", "<span").Replace("\n","").Replace("\r","").Replace("\t","");
                                    if (item[0].Contains("滾球"))
                                    {
                                        //orderOther. = substring(item[0], ">", "<").Split('@')[3].Trim();
                                        switch (betType)
                                        {
                                            case "&#19978;&#21322;&#22580;&#22823;&#23567;":                //上半场大小
                                                orderOther.BetType = "7";
                                                break;
                                            case "&#19978;&#21322;&#22580;1X2":                            //上半場1X2 
                                                orderOther.BetType = "15";
                                                break;
                                            case "&#22823;&#23567;&#30436;":                                //全场大小盤
                                                orderOther.BetType = "5";
                                                break;
                                            case "&#20126;&#27954;&#30436;":                                //让球盘
                                                orderOther.BetType = "4";
                                                break;
                                            case "1X2":                                                     //全场标准盘
                                                orderOther.BetType = "14";
                                                break;
                                            case "&#19978;&#21322;&#22580;&#20126;&#27954;&#30436;":        //上半場让球盘
                                                orderOther.BetType = "6";
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        switch (betType)
                                        {
                                            case "&#19978;&#21322;&#22580;&#22823;&#23567;":                //早餐  单式  上半场大小
                                                orderOther.BetType = Convert.ToDateTime(insertTime) != Convert.ToDateTime(beginTime) ? "11" : "3";
                                                break;
                                            case "&#19978;&#21322;&#22580;1X2":                            //早餐  单式   上半場1X2 
                                                orderOther.BetType = Convert.ToDateTime(insertTime) != Convert.ToDateTime(beginTime) ? "17" : "13";
                                                break;
                                            case "&#22823;&#23567;&#30436;":                                //早餐  单式   全场大小盤
                                                orderOther.BetType = Convert.ToDateTime(insertTime) != Convert.ToDateTime(beginTime) ? "9" : "1";
                                                break;
                                            case "&#20126;&#27954;&#30436;":                                // 早餐  单式  让球盘
                                                orderOther.BetType = Convert.ToDateTime(insertTime) != Convert.ToDateTime(beginTime) ? "8" : "0";
                                                break;
                                            case "1X2":                                                     //早餐  单式  全场标准盘
                                                orderOther.BetType = Convert.ToDateTime(insertTime) != Convert.ToDateTime(beginTime) ? "16" : "12";
                                                break;
                                            case "&#19978;&#21322;&#22580;&#20126;&#27954;&#30436;":        //早餐  单式  上半場让球盤
                                                orderOther.BetType = Convert.ToDateTime(insertTime) != Convert.ToDateTime(beginTime) ? "10" : "2";
                                                break;
                                        }
                                    }
                                }
                                else if (count == 4)
                                {
                                    orderOther.Odds = Convert.ToDecimal(substring(substring(content, "<td", "</td>"), ">", "<br /><span").Trim());
                                }
                                else if (count == 5)
                                {
                                    item = substring(content, "<td", "</td>").Replace("<br />", "$").Split('$');
                                    orderOther.Amount = Convert.ToDecimal(substring(substring(item[0], "<span", "/span>"), ">", "<"));
                                }
                                else if (count == 6)
                                {
                                    item = substring(content, "<td", "</td>").Replace("<br />", "$").Split('$');
                                    orderOther.Result = Convert.ToDecimal(substring(substring(item[0], "<span", "/span>"), ">", "<"));
                                }
                                else if (count == 7)
                                {
                                    item = substring(content, "<td", "</td>").Replace("br />", "$").Split('$');
                                    //orderOther. = substring(item[0], ">", "<").Replace("\n", "").Replace("\r", "").Replace(" ", "");
                                    orderOther.Scorehalf = substring(item[1], ">", "<").Replace("HT", "").Replace(" ", "").Replace("\n", "").Replace("\r", "").Trim();
                                    orderOther.Score = substring(item[2], ">", "</span>").Replace("FT", "").Replace(" ", "").Replace("\n", "").Replace("\r", "").Trim();
                                }
                                content = substring2(content, "<td", "</td>");
                            }
                            html = substring2(html, "<tr bgColo", "</tr>");
                            string aa = orderOther.WebOrderID;
                            if (!betAccountOrderHistory.OrderOtherHistorys.ContainsKey(orderOther.WebOrderID))
                            {
                                orderOther = new Orderotherhistory();
                                orderOther.WebUserName = betAccountOrderHistory.account.Userid;
                                orderOther.ErrorMessage = "此单在Liji网站上有记录";
                                orderOther.WebOrderID = GetRandomOrderId();
                                dic.Add(orderOther.WebOrderID, orderOther);
                            }
                            else
                            {
                                Orderotherhistory otherHistory = betAccountOrderHistory.OrderOtherHistorys[orderOther.WebOrderID];
                                if (orderOther.WebOrderID != otherHistory.WebOrderID || orderOther.Odds != otherHistory.Odds || orderOther.Score != otherHistory.Score || orderOther.Scorehalf != otherHistory.Scorehalf || (Math.Abs(orderOther.Result) < Math.Abs(otherHistory.Result) - 5m && Math.Abs(orderOther.Result) > Math.Abs(otherHistory.Result) + 5m) || orderOther.Amount != otherHistory.Amount || orderOther.BetType != otherHistory.BetType)
                                {
                                    otherHistory.ErrorMessage = "比对出现了错误";
                                    dic.Add(otherHistory.WebOrderID, otherHistory);
                                }
                                //else
                                //{
                                //    //orderOther = new Orderotherhistory();
                                //    //orderOther.WebOrderID = GetRandomOrderId();
                                //    //orderOther.WebUserName = betAccountOrderHistory.account.Userid;
                                //    ////orderOther.OrderID = otherHistory.OrderID;
                                //    //orderOther.Homecn = otherHistory.Homecn;
                                //    //orderOther.Awaycn = otherHistory.Awaycn;
                                //    //orderOther.Odds = otherHistory.Odds;
                                //    //orderOther.BetType = otherHistory.BetType;
                                //    //orderOther.Score = otherHistory.Score;
                                //    //orderOther.Result = otherHistory.Result;
                                //    //orderOther.ErrorMessage = "帐号" + orderOther.WebUserName + "核对下注历史失败,请人工进行合对.";
                                //    //dic.Add(orderOther.WebOrderID, orderOther);
                                //    //return dic;
                                //}
                            }
                        }
                    }
                }
                catch
                {
                    errCount++;
                    if (errCount > 3)
                    {
                        orderOther = new Orderotherhistory();
                        orderOther.WebOrderID = GetRandomOrderId();
                        orderOther.WebUserName = betAccountOrderHistory.account.Userid;
                        orderOther.ErrorMessage = "帐号" + orderOther.WebUserName + "核对下注历史失败,获取页面异常或截取异常";
                        dic.Add(orderOther.WebOrderID,orderOther);
                        return dic;
                    }
                    else
                    {
                        goto label20;
                    }
                }
                finally
                {
                    try
                    {
                        response.Close();
                    }
                    catch
                    {
                        ;
                    }
                    try
                    {
                        reader.Close();
                    }
                    catch
                    {

                    }
                }
            }
            return dic;
        }


        public static Dictionary<string, Orderotherhistory> shabaReadHistory2(BetAccountOrderHistory betAccountOrderHistory)
        {
            Dictionary<string, Orderotherhistory> dic = new Dictionary<string, Orderotherhistory>();
            IList<Orderotherhistory> dataList = new List<Orderotherhistory>();
            Orderotherhistory orderOther = null;
            //一次性从数据库取出所有注单，通过单个帐号获取对应的注单
            betAccountOrderHistory.OrderOtherHistorys = GetDicByAccount(betAccountOrderHistory.account.Userid, betAccountOrderHistory.OrderOtherHistorys);
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            string content = string.Empty;
            string html = string.Empty;
            Encoding utf8 = Encoding.UTF8;
            string url = string.Empty;
            string[] item = null;
            string[] item2 = null;
            int count = 0;
            int errCount = 0;
            for (int i = 0; i < betAccountOrderHistory.date.Count; i++)
            {
            label20:
                try
                {
                    url = "http://" + betAccountOrderHistory.account.Address2 + "/DBetlist.aspx?fdate=" + Convert.ToDateTime(betAccountOrderHistory.date[i]).ToString("MM/dd/yyyy");
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Referer = "http://"+betAccountOrderHistory.account.Address2+"/AllStatement.aspx";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; GTB6.6; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; InfoPath.3)";
                    request.KeepAlive = true;
                    request.Timeout = 6000;
                    request.ServicePoint.ConnectionLimit = 100;
                    request.Headers["Cache-Control"] = "no-cache";
                    request.Headers["Cookie"] = betAccountOrderHistory.account.Cookie;
                    request.AllowAutoRedirect = false;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                        reader = new StreamReader(stream, utf8);
                    }
                    else
                    {
                        reader = new StreamReader(response.GetResponseStream(), utf8);
                    }
                    html = reader.ReadToEnd();
                    if (string.IsNullOrEmpty(html.Replace("\r", "").Replace("\n", "").Replace(" ", "").Trim()))
                    {
                        orderOther = new Orderotherhistory();
                        orderOther.WebUserName = betAccountOrderHistory.account.Userid;
                        orderOther.WebOrderID = GetRandomOrderId();
                        orderOther.ErrorMessage = "帐号" + orderOther.WebUserName + "核对下注历史失败,cookie失效";
                        dic.Add(orderOther.WebOrderID,orderOther);
                        return dic;
                    }
                    if (html.Contains("There are no information"))
                    {
                        continue;
                    }
                    if (html.Contains("class=\"tabstyle02 tabstyle03\""))
                    {
                        while (html.IndexOf("<tr") > 0)
                        {
                            orderOther = new Orderotherhistory();
                            count = 0;
                            content = substring(html, "<tr", "</tr>");
                            if (content.Contains("Ref No"))
                            {
                                while (content.IndexOf("<td") > 0)
                                {
                                    count++;
                                    item = null;
                                    if (count == 2)
                                    {
                                        item =substring(content,"<td","</td>").Replace("<br /", "").Replace("</b>", "$").Split('$');
                                        orderOther.WebOrderID = substring(item[0]+"#", "<b>", "#").Split(':')[1];
                                        //>>2011/4/11 上午 06:47:50</p>
                                        orderOther.BeginTime =Convert.ToDateTime(item[1].Split(' ')[0].Replace(">",""));
                                    }
                                    else if (count == 3)
                                    {
                                        item = substring(content, "<td", "</td>").Replace("/span>", "$").Split('$');
                                        orderOther.Handicap = substring(item[1], "<b>", "</b>");
                                        orderOther.Score = substring(item[2], ">", "<").Replace("[", "").Replace("]", "").Trim();
                                        orderOther.BetType = substring(item[4], "<strong>", "</strong>");
                                        if (item[5].Contains("<img"))
                                        {
                                            item2 = item[5].Replace("-VS-", "$").Replace(" ", "").Split('$');
                                            if (item2[0].Contains("<imgsrc"))
                                            {
                                                orderOther.Homecn = substring(item2[0], "betlist_B\">", "<imgsrc");
                                            }
                                            else if (item2[0].Contains("<spanclas") && !item2[0].Contains("<imgsrc"))
                                            {
                                                orderOther.Homecn = substring(item2[0] + "#", "betlist_B\">", "#");
                                            }
                                            else
                                            {
                                                orderOther.Homecn = substring(item2[0], "class=\"betlist_B\">", "<img").Trim();
                                            }
                                            orderOther.Awaycn = substring("#" + item2[1].Replace("<br>", ""), "#", "<").Trim();
                                        }
                                        else
                                        {
                                            item2 = substring(item[5].Replace("<br />", ""), ">", "<").Replace("-VS-", "$").Replace(" ", "").Split('$');
                                            orderOther.Homecn = item2[0];
                                            orderOther.Awaycn = item2[1];
                                        }
                                        orderOther.Leaguecn = substring(item[7],">","<");
                                    }
                                    else if (count == 4)
                                    {
                                        item = substring(content, "<td", "</td>").Replace("<br />", "$").Split('$');
                                        orderOther.Odds = Convert.ToDecimal(substring(substring(item[0], "<span", "/span>"), ">", "<"));
                                    }
                                    else if (count == 5)
                                    {
                                        orderOther.Amount = Convert.ToDecimal(substring(substring(content, "<td", "/td>"), ">", "<"));
                                    }
                                    else if (count == 6)
                                    {
                                        orderOther.Result = Convert.ToDecimal(substring(substring(substring(content, "<td", "</td>").Replace("<br /", "$").Split('$')[0], "<span", "/span>"), ">", "<"));
                                    }
                                    content = substring2(content, "<td", "</td>");
                                }
                            }
                            html = substring2(html, "<tr", "</tr>");
                            string aa = orderOther.WebOrderID;
                            if (orderOther.WebOrderID != null)
                            {
                                if (!betAccountOrderHistory.OrderOtherHistorys.ContainsKey(orderOther.WebOrderID))
                                {
                                    orderOther = new Orderotherhistory();
                                    orderOther.WebUserName = betAccountOrderHistory.account.Userid;
                                    orderOther.ErrorMessage = "此单在Shaba网站上有记录";
                                    //orderOther.WebOrderID = GetRandomOrderId();
                                    orderOther.WebOrderID = orderOther.WebOrderID;
                                    dic.Add(orderOther.WebOrderID, orderOther);
                                }
                                else
                                {
                                    Orderotherhistory otherHistory = betAccountOrderHistory.OrderOtherHistorys[orderOther.WebOrderID];
                                    if (orderOther.WebOrderID != otherHistory.WebOrderID || orderOther.Odds != otherHistory.Odds || orderOther.Amount != otherHistory.Amount || (Math.Abs(orderOther.Result) < Math.Abs(otherHistory.Result) - 5m && Math.Abs(orderOther.Result) > Math.Abs(otherHistory.Result) + 5m))
                                    {
                                        otherHistory.ErrorMessage = "比对出现了错误";
                                        dic.Add(otherHistory.WebOrderID, otherHistory);
                                    }
                                    //else
                                    //{
                                    //    orderOther = new Orderotherhistory();
                                    //    orderOther.WebUserName = betAccountOrderHistory.account.Userid;
                                    //    orderOther.OrderID = otherHistory.OrderID;
                                    //    orderOther.Homecn = otherHistory.Homecn;
                                    //    orderOther.Awaycn = otherHistory.Awaycn;
                                    //    orderOther.Odds = otherHistory.Odds;
                                    //    orderOther.BetType = otherHistory.BetType;
                                    //    orderOther.Score = otherHistory.Score;
                                    //    orderOther.Scorehalf = otherHistory.Scorehalf;
                                    //    orderOther.Result = otherHistory.Result;
                                    //    orderOther.ErrorMessage = "帐号" + orderOther.WebUserName + "核对下注历史失败,请人工进行合对。";
                                    //    dic.Add(orderOther.WebOrderID, orderOther);
                                    //    return dic;
                                    //}
                                }
                            }
                            
                        }
                    }
                }
                catch
                {
                    errCount++;
                    if (errCount > 3)
                    {
                        orderOther = new Orderotherhistory();
                        orderOther.WebUserName = betAccountOrderHistory.account.Userid;
                        orderOther.ErrorMessage = "帐号" + orderOther.WebUserName + "核对下注历史失败,获取页面异常或截取异常";
                        dic.Add(orderOther.WebOrderID,orderOther);
                        return dic;
                    }
                    else
                    {
                        goto label20;
                    }
                }
                finally
                {
                    try
                    {
                        response.Close();
                    }
                    catch
                    {
                        ;
                    }
                    try
                    {
                        reader.Close();
                    }
                    catch
                    {

                    }
                }
            }
            return dic;
        }


        public static Dictionary<string, Orderotherhistory> xinqiuReadHistory2(BetAccountOrderHistory betAccountOrderHistory)
        {
            Dictionary<string, Orderotherhistory> dic = new Dictionary<string, Orderotherhistory>();
            //一次性从数据库取出所有注单，通过单个帐号获取对应的注单
            betAccountOrderHistory.OrderOtherHistorys = GetDicByAccount(betAccountOrderHistory.account.Userid, betAccountOrderHistory.OrderOtherHistorys);
            if (betAccountOrderHistory.OrderOtherHistorys.Count <= 0)
            {
                tcount++;
                return dic;
            }
            Orderotherhistory order1 = new Orderotherhistory();
            Orderotherhistory order2 = new Orderotherhistory();
            int Count = 0;
            CheckOrderOtherHistory cho = new CheckOrderOtherHistory();
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string content = string.Empty;
            string url = string.Empty;
            string referer = string.Empty;
            byte[] bytes;
            int count = 0;
            int count2 = 0;
            string postdata = string.Empty;
            string __VIEWSTATE = string.Empty;
            string __EVENTVALIDATION = string.Empty;
            betAccountOrderHistory.account.islogin = 0;
           
        label10:
            if (betAccountOrderHistory.account.Cookie.Length < 10)
            {

                xinqiulogin(betAccountOrderHistory.account);
                if (betAccountOrderHistory.account.islogin != 1)
                {
                    if (count < 2)
                    {
                        count++;
                        betAccountOrderHistory.account.Cookie = "";
                        goto label10;
                    }
                    else
                    {

                        order1 = new Orderotherhistory();
                        order1.WebUserName = betAccountOrderHistory.account.Userid;
                        order1.WebOrderID = GetRandomOrderId();
                        order1.ErrorMessage = "帐号" + betAccountOrderHistory.account.Userid + "核对下注历史失败,账号已被登出";
                        dic.Add(order1.WebOrderID, order1);
                        return dic;
                    }

                }

            }

            url = "http://" + betAccountOrderHistory.account.Address2 + "/zh-tw/my-account/statement/betting-history/sports/settled-bets";
            referer = "http://" + betAccountOrderHistory.account.Address2 + "/zh-tw/my-account/statement/betting-history/sports/settled-bets";
        label20:
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Headers["x-requested-with"] = "XMLHttpRequest";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Referer = referer;
                request.Accept = "*/*";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; InfoPath.2; CIBA)";
                request.Timeout = 6000;
                request.KeepAlive = true;
                request.Headers["Cache-Control"] = "no-cache";
                request.Headers["Cookie"] = betAccountOrderHistory.account.Cookie;
                response = (HttpWebResponse)request.GetResponse();
                if (response.Headers.Get("Content-Encoding") != null)
                {
                    stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    reader = new StreamReader(stream, utf8);
                }
                else
                {
                    reader = new StreamReader(response.GetResponseStream(), utf8);
                }
                content = reader.ReadToEnd();

                if (content.Length == 0 || content.Contains("lostConn: true"))
                {
                    
                    if (count2 > 3)
                    {
                        order1 = new Orderotherhistory();
                        order1.WebOrderID = GetRandomOrderId();
                        order1.WebUserName = betAccountOrderHistory.account.Userid;
                        order1.ErrorMessage = "金宝博帐号" + betAccountOrderHistory.account.Userid + "帐号被登出，核对下注历史失败";
                        AddErrorDictionary(order1);
                        return dic;
                    }
                    else
                    {
                        count2++;
                        betAccountOrderHistory.account.Cookie = "";
                        goto label10;
                    }
                }
                if (content.Contains("name=\"__EVENTVALIDATION\" id=\"__EVENTVALIDATION\" value="))
                {
                    __VIEWSTATE = substring(content, "id=\"__VIEWSTATE\" value=\"/", "\" />");
                    __EVENTVALIDATION = substring(content, "id=\"__EVENTVALIDATION\" value=\"/", "\" />").Replace("/", "%2F").Replace("+", "%2B");
                }
                else
                {
                    order1 = new Orderotherhistory();
                    order1.WebOrderID = GetRandomOrderId();
                    order1.WebUserName = betAccountOrderHistory.account.Userid;
                    order1.ErrorMessage = "金宝博帐号" + betAccountOrderHistory.account.Userid + "没有查找到比赛数据";
                    dic.Add(order1.WebOrderID, order1);
                    return dic;

                }
            }
            catch
            {
                if (count2 < 2)
                {
                    count++;
                    goto label10;
                }
                else if (count2 < 4)
                {
                    count++;
                    betAccountOrderHistory.account.Cookie = "";
                    goto label10;
                }
                else
                {
                    order1 = new Orderotherhistory();
                    order1.WebUserName = betAccountOrderHistory.account.Userid;
                    order1.WebOrderID = GetRandomOrderId();
                    order1.ErrorMessage = "帐号" + betAccountOrderHistory.account.Userid + "核对下注历史失败,账号已被登出";
                    dic.Add(order1.WebOrderID, order1);
                    return dic;
                }
            }
            finally
            {
                try
                {
                    response.Close();

                    reader.Close();
                }
                catch
                {
                    ;
                }
            }
            postdata = "__EVENTTARGET=ctl00%24Content%24LinkBtnSubmit&__EVENTARGUMENT=&__VIEWSTATE=%2F" + __VIEWSTATE + "&__EVENTVALIDATION=%2F" + __EVENTVALIDATION + "&ctl00%24Content%24inputFromDatePicker=" + DateTime.Now.AddDays(-8).ToString("dd-MM-yyyy").Replace("-", "%2F") + "&ctl00%24Content%24inputToDatePicker=" + DateTime.Now.ToString("dd-MM-yyyy").Replace("-", "%2F") + "&daysInput=8&ctl00%24Content%24Todaydate0=" + DateTime.Now.ToString("dd-MM-yyyy").Replace("-", "%2F") + "&ctl00%24Content%24TopKey=statement";
            //if (t > 1)
            //{
            //    postdata = "__EVENTTARGET=ctl00%24Content%24LinkBtnSubmit&__EVENTARGUMENT=&__VIEWSTATE=%2F" + __VIEWSTATE + "&__EVENTVALIDATION=%2F" + __EVENTVALIDATION + "&ctl00%24Content%24inputFromDatePicker=" + DateTime.Now.AddDays(-8).ToString("dd-MM-yyyy").Replace("-", "%2F") + "&ctl00%24Content%24inputToDatePicker=" + DateTime.Now.ToString("dd-MM-yyyy").Replace("-", "%2F") + "&daysInput=8&ctl00%24Content%24Todaydate0=" + DateTime.Now.ToString("dd-MM-yyyy").Replace("-", "%2F") + "&ctl00%24Content%24TopKey=statement";
            //}
            //else
            //{
            //    postdata = "__EVENTTARGET=ctl00%24Content%24LinkBtnSubmit&__EVENTARGUMENT=&__VIEWSTATE=%2F" + __VIEWSTATE + "&__EVENTVALIDATION=%2F" + __EVENTVALIDATION + "&ctl00%24Content%24inputFromDatePicker=" + DateTime.Now.AddDays(-8).ToString("dd-MM-yyyy").Replace("-", "%2F") + "&ctl00%24Content%24inputToDatePicker=" + DateTime.Now.ToString("dd-MM-yyyy").Replace("-", "%2F") + "&daysInput=1&ctl00%24Content%24Todaydate0=" + DateTime.Now.ToString("dd-MM-yyyy").Replace("-", "%2F") + "&ctl00%24Content%24TopKey=statement";
            //}
            bytes = Encoding.ASCII.GetBytes(postdata);
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Headers["x-requested-with"] = "XMLHttpRequest";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Referer = referer;
                request.Accept = "*/*";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; InfoPath.2; CIBA)";
                request.Timeout = 6000;
                request.ContentLength = bytes.Length;
                request.KeepAlive = true;
                request.Headers["Cache-Control"] = "no-cache";
                request.Headers["Cookie"] = betAccountOrderHistory.account.Cookie;
                request.GetRequestStream().Write(bytes, 0, bytes.Length);
                response = (HttpWebResponse)request.GetResponse();

                if (response.Headers.Get("Content-Encoding") != null)
                {
                    stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    reader = new StreamReader(stream, utf8);
                }
                else
                {
                    reader = new StreamReader(response.GetResponseStream(), utf8);
                }
                content = reader.ReadToEnd();
                if (content.Contains("login.aspx") || content.Contains("lostConn:true") || content.Length == 0 || content.Contains("沒有記錄"))
                {
                    
                    if (count2 > 4)
                    {
                        order1 = new Orderotherhistory();
                        order1.WebOrderID = GetRandomOrderId();
                        order1.WebUserName = betAccountOrderHistory.account.Userid;
                        order1.ErrorMessage = "金宝博帐号" + order1.WebUserName + "核对下注历史失败";
                        AddErrorDictionary(order1);
                        return dic;
                    }
                    else
                    {
                        count2++;
                        betAccountOrderHistory.account.Cookie = "";
                        goto label20;
                    }
                }
                string type2 = "", tztime = "", kstime = "", temp2 = "", handicap = "", WebOrderID = "";
                string[] str;

                content = substring(content, " <td class=\"tac\">", "</tbody>");
                str = content.Split(new string[] { "<div>201" }, StringSplitOptions.None);
                for (int i = 1; i < str.Length; i++)
                {
                    try
                    {
                        str[i] = "<div>201" + str[i];
                        WebOrderID = substring(str[i], "<div>", "</div>");
                        if (!(WebOrderID.Length > 6))
                        {
                            continue;
                        }
                        order1 = new Orderotherhistory();
                        order1.WebOrderID = WebOrderID;
                        kstime = substring(str[i], "<div>", "</div>");//比赛时间
                        type2 = substring(str[i], "<td class=\"bet-type\">", "</td>").Trim();
                        temp2 = substring(str[i], "<br/>投注日期：", "\"><span").Trim();
                        tztime = temp2.Substring(0, temp2.IndexOf(","));


                        temp2 = substring(str[i], "</span><span class=\"pe o-v", "</span>");
                        order1.Odds = decimal.Parse(temp2.Substring(temp2.IndexOf(">") + 1));
                        order1.Hometw = substring(str[i], "<span class=\"participant\" title=\"", "\">").Replace(" ", "");
                        order1.Awaytw = substring(str[i], "v</span>", "</span>").Replace(" ", "");
                        order1.BetItem = substring(str[i], "<span class=\"bettype\" title=\"", "\">").Replace(" ", "");
                        order1.Leaguetw = substring(str[i], "<span class=\"tt\" title=\"足球 <br/>", "<br/>");
                        order1.Handicap = substring(str[i], "<span class=\"hd pe\">", "</span>");
                        order1.Amount = decimal.Parse(substring(str[i], "<td class=\"tar\">", "<br />").Replace("\r", "").Replace("\n", "").Replace(" ", ""));
                        temp2 = substring(str[i], "<td class=\"tar\">", "tac\"><span");
                        temp2 = substring(temp2, "<td class=\"tar\">", "<td class=").Replace("\r", "").Replace("\n", "").Replace(" ", "");
                        order1.ValidAmount = decimal.Parse(temp2.Substring(0, temp2.IndexOf("<")));

                        //string betResult = temp2.Substring(state.Length - 1);

                        switch (type2)
                        {
                            case "讓球":
                                if (kstime.Contains(tztime))
                                {
                                    order1.BetType = "0";
                                }
                                else
                                {
                                    order1.BetType = "8";
                                }
                                break;
                            case "大小盤":
                                if (kstime.Contains(tztime))
                                {
                                    order1.BetType = "1";
                                }
                                else
                                {
                                    order1.BetType = "9";
                                }
                                break;
                            case "讓球 - 上半場":
                                if (kstime.Contains(tztime))
                                {
                                    order1.BetType = "2";
                                }
                                else
                                {
                                    order1.BetType = "10";
                                }
                                break;
                            case "大小盤 - 上半場":
                                if (kstime.Contains(tztime))
                                {
                                    order1.BetType = "3";
                                }
                                else
                                {
                                    order1.BetType = "11";
                                }
                                break;
                            case "滾球讓球盤":
                                order1.BetType = "4";
                                order1.Score = order1.Awaytw.Substring(order1.Awaytw.IndexOf("(") + 1, order1.Awaytw.IndexOf(")"));
                                order1.Awaytw = order1.Awaytw.Substring(0, order1.Awaytw.IndexOf("(")).Replace(" ", "");
                                break;
                            case "滾球大小盤":
                                order1.BetType = "5";
                                order1.Score = order1.Awaytw.Substring(order1.Awaytw.IndexOf("(") + 1, order1.Awaytw.IndexOf(")"));
                                order1.Awaytw = order1.Awaytw.Substring(0, order1.Awaytw.IndexOf("(")).Replace(" ", "");
                                break;
                            case "滾球讓球盤 - 上半場":
                                order1.BetType = "6";
                                order1.Score = order1.Awaytw.Substring(order1.Awaytw.IndexOf("(") + 1, order1.Awaytw.IndexOf(")"));
                                order1.Awaytw = order1.Awaytw.Substring(0, order1.Awaytw.IndexOf("(")).Replace(" ", "");
                                break;
                            case "滾球大小盤 - 上半場":
                                order1.BetType = "7";
                                order1.Score = order1.Awaytw.Substring(order1.Awaytw.IndexOf("(") + 1, order1.Awaytw.IndexOf(")"));
                                order1.Awaytw = order1.Awaytw.Substring(0, order1.Awaytw.IndexOf("(")).Replace(" ", "");
                                break;

                            case "獨贏":
                                if (kstime.Contains(tztime))
                                {
                                    order1.BetType = "12";
                                }
                                else
                                {
                                    order1.BetType = "16";
                                }
                                break;
                            case "獨贏 - 上半場":
                                if (kstime.Contains(tztime))
                                {
                                    order1.BetType = "13";
                                }
                                else
                                {
                                    order1.BetType = "17";
                                }
                                break;
                            case "滾球獨贏盤":
                                order1.BetType = "14";
                                break;
                            case "滾球獨贏盤 - 上半場":
                                order1.BetType = "15";
                                break;
                        }
                        order1.s = str[i];
                        try
                        {
                            if (int.Parse(order1.BetType) < 12)
                            {
                                if (order1.Handicap.Contains("-"))
                                {
                                    handicap = "-";

                                }
                                order1.Handicap = order1.Handicap.Replace(" ", "").Replace("+", "");
                                if (order1.Handicap.Contains("/"))
                                {

                                    handicap = handicap + ((Math.Abs(double.Parse(order1.Handicap.Substring(0, order1.Handicap.IndexOf("/")))) + double.Parse(order1.Handicap.Substring(order1.Handicap.IndexOf("/") + 1))) / 2).ToString();
                                    order1.Handicap = handicap;
                                }

                            }


                            kstime = kstime.Replace(",", "").Replace("年", "-").Replace("月", "-").Replace("日", " ");
                            order1.Time = Convert.ToDateTime(kstime);
                            if (betAccountOrderHistory.OrderOtherHistorys.ContainsKey(order1.WebOrderID))
                            {
                                order2 = betAccountOrderHistory.OrderOtherHistorys[order1.WebOrderID];
                                if (int.Parse(order1.BetType) < 12)
                                {
                                    if (order1.Handicap != order2.Handicap || (int)(order1.Amount / 10) != (int)(order2.Amount / 10) || (int)(order1.ValidAmount / 10) != (int)(order2.ValidAmount / 10) || order1.Odds != order2.Odds || order1.BetType != order2.BetType)
                                    {
                                        order1.ErrorMessage = "金宝博网站的结算数据，结算的数据有差异";
                                        order2.ErrorMessage = "公司的结算数据，结算的数据有差异";
                                        order2.WebOrderID = order2.WebOrderID + "*";
                                        dic.Add(order1.WebOrderID, order1);
                                        dic.Add(order2.WebOrderID, order2);



                                    }
                                    
                                     betAccountOrderHistory.OrderOtherHistorys.Remove(order1.WebOrderID);

                                
                                }
                                else
                                {
                                    if ((int)(order1.Amount / 10) != (int)(order2.Amount / 10) || (int)(order1.ValidAmount / 10) != (int)(order2.ValidAmount / 10) || order1.Odds != order2.Odds || order1.BetType != order2.BetType)
                                    {
                                        order1.ErrorMessage = "金宝博网站的结算数据，结算的数据有差异";
                                        order2.ErrorMessage = "公司的结算数据，结算的数据有差异";
                                        order2.WebOrderID = order2.WebOrderID + "*";
                                        dic.Add(order1.WebOrderID, order1);
                                        dic.Add(order2.WebOrderID, order2);


                                    }
                                   
                                    betAccountOrderHistory.OrderOtherHistorys.Remove(order1.WebOrderID);

                                   
                                }
                            }
                            else
                            {
                                order1.ErrorMessage = "没有在公司已结算的注单中找到这笔投注";
                                dic.Add(order1.WebOrderID, order1);

                            }
                        }
                        catch(Exception e)
                        {
                            ;
                        }


                    }
                    catch (Exception e)
                    {

                        if (order1.WebOrderID.Length > 6)
                        {
                            
                            order1.WebUserName = betAccountOrderHistory.account.Userid;
                            order1.ErrorMessage = "帐号" + betAccountOrderHistory.account.Userid +"的注单" + order1.WebOrderID + "因为数据分析过程中出现异常，核对下注历史失败,请手工核对" + str[i];
                            order1.s = str[i];
                            dic.Add(order1.WebOrderID,order1);
                        }
                        else
                        {
                            order2 = new Orderotherhistory();
                            order2.WebUserName = betAccountOrderHistory.account.Userid;
                            order2.WebOrderID = GetRandomOrderId();
                            order2.ErrorMessage = "帐号" + betAccountOrderHistory.account.Userid + "的注单因为数据分析过程中出现异常，核对下注历史失败,请手工核对" + str[i];
                            order2.s = str[i];
                            dic.Add(order2.WebOrderID, order2);
                            
                        }
                    }

                }

            }
            catch (Exception ee)
            {
                if (count2 < 4)
                {
                    count2++;
                    goto label20;
                }
                else if (count2 < 6)
                {
                    count2++;
                    betAccountOrderHistory.account.Cookie = "";
                    goto label10;
                   
                }
                else
                {
                    order2 = new Orderotherhistory();
                    order2.WebOrderID = GetRandomOrderId();
                    order2.WebUserName = betAccountOrderHistory.account.Userid;
                    order2.ErrorMessage = "金宝博帐号" + order1.WebUserName + "核对下注历史失败";
                    dic.Add(order2.WebOrderID, order2);
                    return dic;
                }
            }

            finally
            {
                try
                {
                    response.Close();

                    reader.Close();
                }
                catch
                {
                    ;
                }
            }
            if (betAccountOrderHistory.account.islogin == 1)
            {
                yonglilogout(betAccountOrderHistory.account);
            }
            try
            {
                foreach (string key in betAccountOrderHistory.OrderOtherHistorys.Keys)
                {
                    order2 = new Orderotherhistory();
                    order2.WebOrderID = key;
                    order2 = betAccountOrderHistory.OrderOtherHistorys[key];
                    order2.ErrorMessage = "没有在网站已结算的注单中找到这笔投注";
                    order2.WebOrderID = order2.WebOrderID + "*";
                    dic.Add(order2.WebOrderID, order2);
                }
            }
            catch(Exception e)
            {
                ;
            }

            return dic;

        }

        public static Dictionary<string, Orderotherhistory> yongliReadHistory2(BetAccountOrderHistory betAccountOrderHistory)
        {
            Dictionary<string, Orderotherhistory> dic = new Dictionary<string, Orderotherhistory>();
           
            //一次性从数据库取出所有注单，通过单个帐号获取对应的注单
            betAccountOrderHistory.OrderOtherHistorys = GetDicByAccount(betAccountOrderHistory.account.Userid, betAccountOrderHistory.OrderOtherHistorys);
            if (betAccountOrderHistory.OrderOtherHistorys.Count <= 0)
            {
                tcount++;
                return dic;
            }
            
            Orderotherhistory order1 = null;
            Orderotherhistory order2 = null;
            int errCount = 0;
            CheckOrderOtherHistory cho = new CheckOrderOtherHistory();
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding big5 = Encoding.GetEncoding("big5");
            string content = string.Empty;
            string url = string.Empty;
            string referer = string.Empty;
            int count = 0;
            int count2 = 0;
            betAccountOrderHistory.account.islogin = 0;
        label10:
            if (betAccountOrderHistory.account.Cookie.Length < 10)
            {

                yonglilogin(betAccountOrderHistory.account);
                if (betAccountOrderHistory.account.islogin != 1)
                {
                    if (count < 2)
                    {
                        count++;
                        betAccountOrderHistory.account.Cookie = "";
                        goto label10;
                    }
                    else
                    {

                        order1 = new Orderotherhistory();
                        order1.WebUserName = betAccountOrderHistory.account.Userid;
                        order1.WebOrderID = GetRandomOrderId();
                        order1.ErrorMessage = "帐号" + betAccountOrderHistory.account.Userid + "核对下注历史失败,账号已被登出";
                        dic.Add(order1.WebOrderID, order1);
                        return dic;
                    }

                }

            }

            try
            {
                // http://www.a1a888.com/right/history/ 2011-03-31
                url = "http://" + betAccountOrderHistory.account.Address + "/right/history/";
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Accept = "application/xml,application/xhtml+xml,text/html;q=0.9,text/plain;q=0.8,image/png,*/*;q=0.5";
                request.Referer = referer;
                request.Headers["Accept-Language"] = "zh-cn";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers["Accept-Encoding"] = "gzip,deflate,sdch";
                request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US) AppleWebKit/534.10 (KHTML, like Gecko) Chrome/8.0.552.224 Safari/534.10";
                request.KeepAlive = true;
                request.Headers["Cookie"] = betAccountOrderHistory.account.Cookie;
                response = (HttpWebResponse)request.GetResponse();
                if (response.Headers.Get("Content-Encoding") != null)
                {
                    stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    reader = new StreamReader(stream, big5);
                }
                else
                {
                    reader = new StreamReader(response.GetResponseStream(), big5);
                }
                content = reader.ReadToEnd();
                if (content.Contains("elf.parent.location='/logout.php'") || content.Length == 0 || content.Contains("系統繁忙, 請重新登入"))
                {
                    if (count2 < 2)
                    {
                        count++;
                        betAccountOrderHistory.account.Cookie = "";
                        goto label10;
                    }
                    else
                    {

                        order1 = new Orderotherhistory();
                        order1.WebUserName = betAccountOrderHistory.account.Userid;
                        order1.WebOrderID = GetRandomOrderId();
                        order1.ErrorMessage = "帐号" + betAccountOrderHistory.account.Userid + "核对下注历史失败,账号已被登出";
                        dic.Add(order1.WebOrderID, order1);
                        return dic;
                    }
                }
            }
            catch
            {
                if (count2 < 2)
                {
                    count++;

                    goto label10;
                }
                else if (count2 < 4)
                {
                    count++;
                    betAccountOrderHistory.account.Cookie = "";
                    goto label10;
                }
                else
                {
                    order1 = new Orderotherhistory();
                    order1.WebUserName = betAccountOrderHistory.account.Userid;
                    order1.WebOrderID = GetRandomOrderId();
                    order1.ErrorMessage = "帐号" + betAccountOrderHistory.account.Userid + "核对下注历史失败,账号已被登出";
                    dic.Add(order1.WebOrderID, order1);
                    return dic;
                }
            }
            finally
            {
                try { reader.Close(); }
                catch { ; }
                try
                {
                    if (stream != null) { stream.Close(); }
                }
                catch { ; }
                try { response.Close(); }
                catch { ; }
            }
            //int days = (betAccountOrderHistory.date[1].Subtract(betAccountOrderHistory.date[0])).Days;
            for (int j = 0; j < 2; j++)
            {
            label20:
                try
                {
                    //http://www.a1a888.com/right/history/info.php?dateShow=2011-03-24
                    url = "http://" + betAccountOrderHistory.account.Address + "/right/history/info.php?dateShow=" + DateTime.Now.AddDays(-j).ToString("yyyy-MM-dd");
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.Accept = "application/xml,application/xhtml+xml,text/html;q=0.9,text/plain;q=0.8,image/png,*/*;q=0.5";
                    request.Referer = referer;
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers["Accept-Encoding"] = "gzip,deflate,sdch";
                    request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US) AppleWebKit/534.10 (KHTML, like Gecko) Chrome/8.0.552.224 Safari/534.10";
                    //request.KeepAlive = true;
                    request.Headers["Cookie"] = betAccountOrderHistory.account.Cookie;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                        reader = new StreamReader(stream, big5);
                    }
                    else
                    {
                        reader = new StreamReader(response.GetResponseStream(), big5);
                    }
                    content = reader.ReadToEnd();
                    if (content.Trim().Length == 0 || content.Contains("系統繁忙, 請重新登入"))
                    {
                        if (errCount < 5)
                        {
                            errCount++;
                            goto label20;
                        }
                        else
                        {
                            order1 = new Orderotherhistory();
                            order1.WebUserName = betAccountOrderHistory.account.Userid;
                            order1.WebOrderID = GetRandomOrderId();
                            order1.ErrorMessage = "永利高帐号" + order1.UserName + "已被登出或者尚未登录";
                            AddErrorDictionary(order1);
                            return dic;
                        }
                    }
                    string type2 = "", content2 = "",handicap="";
                    string[] str;
                    if (content.Contains("<tr bgcolor='#FFFFFF' valign='top' align='right'>"))
                    {
                        //page = substring(content, "<option value=\"0\" SELECTED>", "</option>").Trim();
                        //pagecount = substring(content, "</select>&nbsp;&nbsp;/", "页").Trim();
                        content = substring(content, "<tr bgcolor='#FFFFFF' valign='top' align='right'>", "</table>");
                        str = content.Split(new string[] { "<tr bgcolor='#FFFFFF'" }, StringSplitOptions.None);
                        for (int i = 0; i < str.Length; i++)
                        {
                            order1 = new Orderotherhistory();
                            try
                            {
                                order1.Time = Convert.ToDateTime(substring(str[i], "<td align='left' nowrap>", "</td>").Replace("<br>", " "));
                                type2 = substring(str[i], "足球<br>", "</td>");
                                order1.WebOrderID = substring(str[i], "<font color=>", "</font></td>");
                                order1.Score = substring(str[i], "<b class='green'>(", ")</b>").Trim();//完场比分
                                order1.Odds = Convert.ToDecimal(substring(str[i], "<font class='odds'><b>", "</b></font>"));
                                order1.Leaguetw = substring(str[i], "</td><td>", "<br>");
                                content2 = substring(str[i], "</td><td>", "<font class='odds'");
                                order1.Awaytw = substring(content2, "</font>", "<b class='green'>").Replace(" ", "");
                                order1.Hometw = substring(content2, "<br>", "<font color='blue'>").Replace(" ", "");
                                order1.BetItem = substring(content2, "<font color='red'>", "</font>").Replace(" ", "");
                                order1.Handicap = substring(content2, "<font color='blue'>", "</font>").Trim();
                                order1.Amount = Convert.ToDecimal(substring(str[i], "</b></font></td><td>", "</td>").Trim());
                                string tempMoney = substring(str[i], "<td bgcolor='#FFCCFF'>", "</tr>");
                                order1.Result = Convert.ToDecimal(substring(tempMoney, "</td><td>", "</td>").Trim());
                                string result = substring(str[i], "<br><font class=blue>", "</font>");
                                if (order1.Hometw == order1.BetItem)
                                {
                                    order1.Handicap = "-" + order1.Handicap;
                                }
                                switch (type2)
                                {
                                    case "讓球":
                                        order1.BetType = "0";
                                        break;
                                    case "大小":
                                        order1.BetType = "1";
                                        break;
                                    case "上半場讓球":
                                        order1.BetType = "2";
                                        break;
                                    case "上半場大小":
                                        order1.BetType = "3";
                                        break;
                                    case "滾球":
                                        order1.BetType = "4";
                                        break;
                                    case "滾球大小":
                                        order1.BetType = "5";
                                        break;
                                    case "上半場滾球讓球":
                                        order1.BetType = "6";
                                        break;
                                    case "上半場滾球大小":
                                        order1.BetType = "7";
                                        break;
                                    case "早餐讓球":
                                        order1.BetType = "8";
                                        break;
                                    case "早餐大小":
                                        order1.BetType = "9";
                                        break;
                                    case "早餐上半場讓球":
                                        order1.BetType = "10";
                                        break;
                                    case "早餐上半場大小":
                                        order1.BetType = "11";
                                        break;
                                    case "标准盘":
                                        order1.BetType = "12";
                                        break;
                                    case "足球上半場獨贏":
                                        order1.BetType = "13";
                                        break;
                                    case "滚球标准盘":
                                        order1.BetType = "14";
                                        break;
                                    case "上半场滚球标准盘":
                                        order1.BetType = "15";
                                        break;
                                    case "早餐标准盘":
                                        order1.BetType = "16";
                                        break;
                                    case "足球早餐上半獨贏":
                                        order1.BetType = "17";
                                        break;
                                }
                                order1.s = "<tr bgcolor='#FFFFFF'" + str[i];
                               
                                try
                                {
                                    if (int.Parse(order1.BetType) < 12)
                                    {
                                        if (order1.Handicap.Contains("-"))
                                        {
                                            handicap = "-";

                                        }
                                        order1.Handicap = order1.Handicap.Replace(" ", "").Replace("+", "");
                                        if (order1.Handicap.Contains("/"))
                                        {

                                            handicap = handicap + ((Math.Abs(double.Parse(order1.Handicap.Substring(0, order1.Handicap.IndexOf("/")))) + double.Parse(order1.Handicap.Substring(order1.Handicap.IndexOf("/") + 1))) / 2).ToString();
                                            order1.Handicap = handicap;
                                        }

                                    }
                                    if (result.Contains("賽事延期"))
                                    {
                                        order2.WebUserName = betAccountOrderHistory.account.Userid;
                                        order2.WebOrderID = order1.WebOrderID;
                                        order2.ErrorMessage = "永利高帐号" + order1.UserName + "注单号" + order1.WebOrderID + "投注注单已被网站取消";
                                        dic.Add(order1.WebOrderID, order1);
                                        return dic;
                                    }
                                    if (betAccountOrderHistory.OrderOtherHistorys.ContainsKey(order1.WebOrderID))
                                    {
                                        order2 = betAccountOrderHistory.OrderOtherHistorys[order1.WebOrderID];
                                        if (int.Parse(order1.BetType) < 12)
                                        {
                                            if (order1.Score != order2.Score || order1.Handicap != order2.Handicap || (int)(order1.Amount / 10) != (int)(order2.Amount / 10) || (int)(order1.ValidAmount / 10) != (int)(order2.ValidAmount / 10) || order1.Odds != order2.Odds || order1.BetType != order2.BetType)
                                            {
                                                order1.ErrorMessage = "永利高网站的结算数据，结算的数据有差异";
                                                order2.ErrorMessage = "公司的结算数据，结算的数据有差异";
                                                order2.WebOrderID = order2.WebOrderID + "*";
                                                dic.Add(order1.WebOrderID, order1);
                                                dic.Add(order2.WebOrderID, order2);


                                            }

                                            betAccountOrderHistory.OrderOtherHistorys.Remove(order1.WebOrderID);


                                        }
                                        else
                                        {
                                            if (order1.Score != order2.Score || (int)(order1.Amount / 10) != (int)(order2.Amount / 10) || (int)(order1.ValidAmount / 10) != (int)(order2.ValidAmount / 10) || order1.Odds != order2.Odds || order1.BetType != order2.BetType)
                                            {
                                                order1.ErrorMessage = "永利高网站的结算数据，结算的数据有差异";
                                                order2.ErrorMessage = "公司的结算数据，结算的数据有差异";
                                                order2.WebOrderID = order2.WebOrderID + "*";
                                                dic.Add(order1.WebOrderID, order1);
                                                dic.Add(order2.WebOrderID, order2);

                                            }

                                            betAccountOrderHistory.OrderOtherHistorys.Remove(order1.WebOrderID);

                                        }
                                    }
                                    else
                                    {
                                        order1.ErrorMessage = "没有在公司已结算的注单中找到这笔投注";
                                        dic.Add(order1.WebOrderID, order1);

                                    }
                                }
                                catch
                                {
                                    ;
                                }


                            }
                            catch
                            {
                                 if (order1.WebOrderID.Length > 6)
                                {

                                    order1.WebUserName = betAccountOrderHistory.account.Userid;
                                    order1.ErrorMessage = "帐号" + betAccountOrderHistory.account.Userid + "的注单" + order1.WebOrderID + "因为数据分析过程中出现异常，核对下注历史失败,请手工核对" + str[i];
                                    order1.s = "<tr bgcolor='#FFFFFF'" + str[i];
                                    dic.Add(order1.WebOrderID, order1);
                                }
                                else
                                {
                                    order2 = new Orderotherhistory();
                                    order2.WebUserName = betAccountOrderHistory.account.Userid;
                                    order2.ErrorMessage = "帐号" + betAccountOrderHistory.account.Userid + "的注单因为数据分析过程中出现异常，核对下注历史失败,请手工核对" + str[i];
                                    order2.s = "<tr bgcolor='#FFFFFF'" + str[i];
                                    dic.Add(order2.WebOrderID, order2);

                                }
                            
                            }
                        }
                    }

                }
                catch
                {
                    if (count2 < 4)
                    {
                        count2++;
                        goto label20;
                    }
                    else if (count2 < 6)
                    {
                        count2++;
                        betAccountOrderHistory.account.Cookie = "";
                        goto label10;

                    }
                    else
                    {
                        order2 = new Orderotherhistory();
                        order2.WebOrderID = GetRandomOrderId();
                        order2.WebUserName = betAccountOrderHistory.account.Userid;
                        order2.ErrorMessage = "帐号" + order1.WebUserName + "核对下注历史失败";
                        dic.Add(order2.WebOrderID, order2);
                        return dic;
                    }
                }
                finally
                {
                    try { reader.Close(); }
                    catch { ; }
                    try
                    {
                        if (stream != null) { stream.Close(); }
                    }
                    catch { ; }
                    try { response.Close(); }
                    catch { ; }
                }
            }
            if (betAccountOrderHistory.account.islogin == 1)
            {
                yonglilogout(betAccountOrderHistory.account);
            }
            try
            {
                foreach (string key in betAccountOrderHistory.OrderOtherHistorys.Keys)
                {
                    order2 = new Orderotherhistory();
                    order2.WebOrderID = key;
                    order2 = betAccountOrderHistory.OrderOtherHistorys[key];
                    order2.ErrorMessage = "没有在金宝博网站已结算的注单中找到这笔投注";
                    order2.WebOrderID = order2.WebOrderID + "*";
                    dic.Add(order2.WebOrderID, order2);
                }
            }
            catch(Exception e)
            {
                ;
            }
            return dic;
        }
        #endregion

        public static Dictionary<string, Orderotherhistory> as3388ReadHistory2(BetAccountOrderHistory betAccountOrderHistory)
        {
            Dictionary<string, Orderotherhistory> dic = new Dictionary<string, Orderotherhistory>();
            Dictionary<string, Orderotherhistory> fianlDic = new Dictionary<string, Orderotherhistory>();
            //一次性从数据库取出所有注单，通过单个帐号获取对应的注单
            betAccountOrderHistory.OrderOtherHistorys = GetDicByAccount(betAccountOrderHistory.account.Userid, betAccountOrderHistory.OrderOtherHistorys);
            Orderotherhistory order1 = null;
            Orderotherhistory order2 = null;
            int errCount = 0;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string url = string.Empty;
            string content = string.Empty;
            string tr = string.Empty;
            string td = string.Empty;
            string betResult = string.Empty;
            for (int i = 0; i < betAccountOrderHistory.date.Count; i++)
            {
            label20:
                try
                {
                    betResult = "";
                    url = "http://www.sportsinfo8.com/user_sportsinfo8/traditional/index.php?p=user_bets_enquiry_action&fr_matchdate=" + betAccountOrderHistory.date[i].ToString("dd/MM/yyyy").Replace("-", "/") + "&fr_type=soccer&groupby=0&timezone=America/La_Paz";
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    request.Referer = "http://www.sportsinfo8.com/user_sportsinfo8/traditional/index.php?p=user_bets_enquiry&groupby=0&fr_type=soccer&fr_matchdate=" + betAccountOrderHistory.date[i].ToString("dd/MM/yyyy").Replace("-", "/");
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; InfoPath.3; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                    request.KeepAlive = true;
                    request.Headers["Cookie"] = "__utma=1.1840575922.1301636560.1302412187.1302412233.23; __utmz=1.1301636560.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none);" + betAccountOrderHistory.account.Cookie + "; __utmc=1";
                    request.AllowAutoRedirect = false;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                        reader = new StreamReader(stream, utf8);
                    }
                    else
                    {
                        reader = new StreamReader(response.GetResponseStream(), utf8);
                    }
                    content = reader.ReadToEnd();
                    if (string.IsNullOrEmpty(content.Replace("\r", "").Replace("\n", "").Replace(" ", "").Trim()))
                    {
                        errCount++;
                        if (errCount < 3)
                        {
                            goto label20;
                        }
                        else
                        {
                            order1 = new Orderotherhistory();
                            order1.WebUserName = betAccountOrderHistory.account.Userid;
                            order1.WebOrderID = GetRandomOrderId();
                            order1.ErrorMessage = "BW3388帐号" + order1.WebUserName + "获取日期为" + betAccountOrderHistory.date[i] + "的下注历史失败，帐号已被登出或者尚未登录";
                            dic.Add(order1.WebOrderID, order1);
                            continue;
                        }
                    }
                    content = ToUnicode(content);
                    if (content.Contains("oncontextmenu=\"return false;\">"))
                    {
                        errCount++;
                        if (errCount < 3)
                        {
                            goto label20;
                        }
                        else
                        {
                            order1 = new Orderotherhistory();
                            order1.WebUserName = betAccountOrderHistory.account.Userid;
                            order1.WebOrderID = GetRandomOrderId();
                            order1.ErrorMessage = "帐号" + order1.WebUserName + "核对" + betAccountOrderHistory.date[i] + "的下注历史失败，已被登出或者尚未登录";
                            dic.Add(order1.WebOrderID, order1);
                            continue;
                        }
                    }
                    content = substring(content, "$w_st=[];", "$ga[0]");
                    //没有比赛数据
                    if (content.Replace("\r", "").Replace("\n", "").Replace(" ", "").Trim() == "")
                        continue;
                    while (content.Contains("$be"))
                    {
                        tr = substring(content, "=[", "];"); 
                        string[] arrStr = tr.Split(new string[] { "','" }, StringSplitOptions.None);
                        order1 = new Orderotherhistory();
                        arrStr[1] = arrStr[1].Substring(6, 4)+"-"+arrStr[1].Substring(3,2)+"-"+arrStr[1].Substring(0,2);
                        string time = arrStr[1] + " " + arrStr[2].Replace("AM", "").Replace("PM", "").Trim();

                        
                        string betType = arrStr[3];
                        string[] strTemp = arrStr[12].Split(new string[] { "' ,'" }, StringSplitOptions.None);
                        order1.WebOrderID = arrStr[4].Replace(strTemp[2], "").Replace(" ", "").Trim();
                        order1.Leaguetw = substring(arrStr[5], "<u>", "</u>");
                        arrStr[5] = substring2(arrStr[5], "<u>", "</u>");
                        if (arrStr[5].Contains("<font color =\"red\">"))
                        {
                            string betScore = substring(arrStr[5], "<font color =\"red\">", "</font>");
                            arrStr[5] = substring2(arrStr[5], "<font color =\"red\">", "</font");
                        }
                        order1.Hometw = substring(arrStr[5], ">", "<span").Replace("&nbsp;", "").Replace(" ", "").Trim();
                        td = substring2(arrStr[5], ">", "<span");
                        if (!td.Contains("VS"))
                        {
                            order1.Handicap = substring(td, ">", "</span").Replace("-", "").Trim();
                        }
                        order1.Awaytw = substring(td, "</span>", "<br>");
                        string tempBetTeam = substring(td, "<span class=\"teambet\">", "</span>");
                        if (tempBetTeam.Contains("<b>"))
                        {
                            order1.BetItem = substring(tempBetTeam, "", "<b>");
                            order1.Handicap = substring(tempBetTeam, "<b>", "</b>").Replace("-", "").Trim();
                        }
                        else
                        {
                            order1.BetItem = tempBetTeam;
                        }
                        if (order1.Handicap.Contains("/"))
                        {
                            string[] strArr = order1.Handicap.Split('/');
                            order1.Handicap = ((Convert.ToDouble(strArr[0]) + Convert.ToDouble(strArr[1])) / 2).ToString();
                        }
                        order1.Odds = Convert.ToDecimal(substring(td, "<span class=\"odds\">", "</span>"));
                        order1.Amount = Convert.ToDecimal(arrStr[6]);
                        order1.Result = Convert.ToDecimal(arrStr[7]);
                        order1.ValidAmount = Convert.ToDecimal(arrStr[8]);
                        string result = strTemp[1];
                        betResult = "";
                        if (result.Length > 4)
                        {
                            betResult = substring(result, "", "*");
                            result = result + "|";
                            result = substring(result, "*", "|");
                        }
                        else
                        {
                            result = result + "|";
                            result = substring(result, "*", "|").Replace("*", ":");
                        }
                        order1.Score = result.Replace("*", ":");
                        dic.Add(order1.WebOrderID, order1);
                        content = substring2(content, "=[", "];");
                    }
                }
                catch (WebException wex)
                {
                    order1 = new Orderotherhistory();
                    order1.WebOrderID = GetRandomOrderId();
                    order1.WebUserName = betAccountOrderHistory.account.Userid;
                    order1.ErrorMessage = "帐号" + order1.WebUserName + "核对下注历史失败,获取页面异常:" + wex.Message;
                    dic.Add(order1.WebOrderID, order1);
                    return dic;
                }
                catch (Exception e)
                {
                    errCount++;
                    if (errCount > 5)
                    {
                        order1 = new Orderotherhistory();
                        order1.WebOrderID = GetRandomOrderId();
                        order1.WebUserName = betAccountOrderHistory.account.Userid;
                        order1.ErrorMessage = "帐号" + order1.WebUserName + "核对下注历史失败,获取页面异常或截取异常:" + e.Message;
                        dic.Add(order1.WebOrderID, order1);
                        return dic;
                    }
                    else
                    {
                        goto label20;
                    }
                }
                finally
                {
                    try { reader.Close(); }
                    catch { ; }
                    try
                    {
                        if (stream != null) { stream.Close(); }
                    }
                    catch { ; }
                    try { response.Close(); }
                    catch { ; }
                }
            }
            if (betAccountOrderHistory.OrderOtherHistorys.Count <= 0)
            {
                if (dic.Count > 0)
                {
                    foreach (KeyValuePair<string, Orderotherhistory> k1 in dic)
                    {
                        k1.Value.ErrorMessage =k1.Value.ErrorMessage.Contains("下注历史失败")?k1.Value.ErrorMessage:"此记录在BW3388上有记录，自己的网站上没有";
                        k1.Value.WebUserName = betAccountOrderHistory.account.Userid;
                        fianlDic.Add(k1.Key, k1.Value);
                    }
                }
            }
            else
            {
                if (dic.Count > 0)
                {
                    
                    foreach (KeyValuePair<string, Orderotherhistory> k2 in betAccountOrderHistory.OrderOtherHistorys)
                    {
                        if (dic.ContainsKey(k2.Key))
                        {
                            Orderotherhistory o = dic[k2.Key];
                            if (!betResult.Contains("取消"))
                            {
                                if (k2.Value.Score != o.Score || k2.Value.Handicap.Replace("-", "").Trim() != o.Handicap || k2.Value.Amount != o.Amount || (Math.Abs(o.Result) < Math.Abs(k2.Value.Result) - 1m && Math.Abs(o.Result) > Math.Abs(k2.Value.Result) + 1m) || k2.Value.Odds != o.Odds)
                                {
                                    o.ErrorMessage = "匹配出错";
                                    fianlDic.Add(o.WebOrderID, o);
                                }
                            }
                            else
                            {
                                //球赛已取消
                                o.WebUserName = betAccountOrderHistory.account.Userid;
                                o.ErrorMessage = "注单号" + o.WebOrderID + "的球赛已取消";
                                fianlDic.Add(o.WebOrderID, o);
                            }
                        }
                        else
                        {
                            k2.Value.ErrorMessage += "此记录在自己的网站上，在BW3388上没有记录,或是刷单失败";
                            k2.Value.WebUserName = betAccountOrderHistory.account.Userid;
                            fianlDic.Add(k2.Key, k2.Value);
                        }
                    }
                }
                else
                {
                    foreach (KeyValuePair<string, Orderotherhistory> k4 in betAccountOrderHistory.OrderOtherHistorys)
                    {
                        k4.Value.ErrorMessage += "此记录在自己的网站上，在BW3388上没有记录";
                        k4.Value.WebUserName = betAccountOrderHistory.account.Userid;
                        fianlDic.Add(k4.Key, k4.Value);
                    }
                }
            }
            return fianlDic;
        }

        public static Dictionary<string, Orderotherhistory> huangchaoReadHistory2(BetAccountOrderHistory betAccountOrderHistory)
        {
            Dictionary<string, Orderotherhistory> dic = new Dictionary<string, Orderotherhistory>();
            bool isSettlement = false;
            //一次性从数据库取出所有注单，通过单个帐号获取对应的注单
            betAccountOrderHistory.OrderOtherHistorys = GetDicByAccount(betAccountOrderHistory.account.Userid, betAccountOrderHistory.OrderOtherHistorys);
            Orderotherhistory order1 = null;
            Orderotherhistory order2 = null;
            int errCount = 0;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string url = string.Empty;
            string content = string.Empty;
            string tr = string.Empty;
            string td = string.Empty;
            string temp = string.Empty;
            string nextUrl = string.Empty;
            url = "https://" + betAccountOrderHistory.account.Address + "/sb2/me/list_bet_summary.jsp";
        label20:
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                request.Referer = "https://" + betAccountOrderHistory.account.Address + "/sb2/me/info.jsp?localeString=zh_tw";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; InfoPath.3; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                request.KeepAlive = true;
                request.Timeout = 6000;
                request.Headers["Cookie"] = betAccountOrderHistory.account.Cookie;
                ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;
                response = (HttpWebResponse)request.GetResponse();
                if (response.Headers.Get("Content-Encoding") != null)
                {
                    stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    reader = new StreamReader(stream, utf8);
                }
                else
                {
                    reader = new StreamReader(response.GetResponseStream(), utf8);
                }
                content = reader.ReadToEnd();
                if (content.Contains("Exception Error") || content.Contains("<frame src=\"logo.jsp"))
                {
                    errCount++;
                    if (errCount < 5)
                    {
                        Thread.Sleep(1000);
                        goto label20;
                    }
                    else
                    {
                        order1 = new Orderotherhistory();
                        order1.WebUserName = betAccountOrderHistory.account.Userid;
                        order1.WebOrderID = GetRandomOrderId();
                        order1.ErrorMessage = "皇朝帐号" + order1.UserName + "第" + errCount + "次获取下注历史失败,已被登出或者尚未登录";
                        dic.Add(order1.WebOrderID, order1);
                        return dic;
                    }
                }
                else
                {
                    content = substring(content, "<table", "</table>");
                    content = substring2(content, "<tr", "</tr>");
                    string[] str = content.Split(new string[] { "align=\"right\">" }, StringSplitOptions.None);
                    for (int i = 1; i < str.Length - 1; i++)
                    {
                        for (int j = 0; j < betAccountOrderHistory.date.Count; j++)
                        {
                            if (str[i].Contains(betAccountOrderHistory.date[j].ToString("yyyy-MM-dd")))
                            {
                                nextUrl = substring(str[i], "href=\"", "\">");
                                str[i] = substring2(str[i], "<td", "</td>");
                                str[i] = substring2(str[i], "<td", "</td>");
                                str[i] = substring2(str[i], "<td", "</td>");
                                string s = substring(str[i], ">", ".");
                                int money = Convert.ToInt32(s);
                                isSettlement = money > 0 ? true : false;
                                if (!isSettlement)
                                    continue;
                            label30:
                                try
                                {
                                    url = "https://" + betAccountOrderHistory.account.Address + "/sb2/me/" + nextUrl;
                                    request = (HttpWebRequest)WebRequest.Create(url);
                                    request.Method = "GET";
                                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                                    request.Referer = "https://" + betAccountOrderHistory.account.Address + "/sb2/me/info.jsp?localeString=zh_tw";
                                    request.Headers["Accept-Language"] = "zh-cn";
                                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; InfoPath.3; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                                    request.KeepAlive = true;
                                    request.ServicePoint.ConnectionLimit = 1000;
                                    request.Headers["Cookie"] = betAccountOrderHistory.account.Cookie;
                                    ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;
                                    response = (HttpWebResponse)request.GetResponse();
                                    if (response.Headers.Get("Content-Encoding") != null)
                                    {
                                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                                        reader = new StreamReader(stream, utf8);
                                    }
                                    else
                                    {
                                        reader = new StreamReader(response.GetResponseStream(), utf8);
                                    }
                                    content = reader.ReadToEnd();
                                    if (content.Contains("Exception Error") || content.Contains("<frame src=\"logo.jsp"))
                                    {
                                        errCount++;
                                        if (errCount < 5)
                                        {
                                            Thread.Sleep(1000);
                                            goto label30;
                                        }
                                        else
                                        {
                                            order1 = new Orderotherhistory();
                                            order1.WebUserName = betAccountOrderHistory.account.Userid;
                                            order1.WebOrderID = GetRandomOrderId();
                                            order1.ErrorMessage = "皇朝帐号" + order1.UserName + "核对下注历史" + betAccountOrderHistory.date[i].ToString() + "失败，已被登出或者尚未登录";
                                            dic.Add(order1.WebOrderID, order1);
                                            continue;
                                        }
                                    }
                                    content = substring2(content, "<form", "</form>");
                                    content = substring(content, "<table", "</table>");
                                    content = substring2(content, "<tr", "</tr>");
                                    while (content.Contains("<tr"))
                                    {
                                        tr = substring(content, "<tr", "</tr>");
                                        if (tr.Contains("class=\"listContent"))
                                        {
                                            break;
                                        }
                                        order1 = new Orderotherhistory();
                                        td = substring(tr, "<td", "/td>");
                                        order1.WebOrderID = substring(td, ">", "<br").Replace("AH", "").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "").Trim();
                                        string pankou = substring(td, "<br />", "<").Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                        tr = substring2(tr, "<td", "</td>");
                                        order1.Time = Convert.ToDateTime(substring(tr, ">", "</td>").Replace("\r", "").Replace("\n", "").Replace("\t", "").Trim());
                                        tr = substring2(tr, "<td", "</td>");
                                        td = substring(tr, "<span", "/span").Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                        string betType = td.Contains("(") ? substring(td, ">", "(") : substring(td, ">", "<");
                                        tr = substring2(tr, "<td", "</td>");
                                        td = substring(tr, "<td", "/td>");
                                        order1.Leaguetw = substring(td, "<span class=\"txtLeagueName\">", "</span>").Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                        td = substring2(td, "<span class=\"txtLeagueName\">", "</span>");
                                        order1.BeginTime = Convert.ToDateTime(substring(td, "<span class=\"txtBetDateTime\">", "</span>").Replace("(", "").Replace(")", "").Replace("\r", "").Replace("\n", "").Replace("\t", ""));
                                        switch (betType)
                                        {
                                            case "讓球":
                                                betType = ((Convert.ToDateTime(order1.Time)).ToString("yyyy-MM-dd") == (Convert.ToDateTime(order1.BeginTime)).ToString("yyyy-MM-dd")) ? "0" : "8";
                                                break;
                                            case "大/小":
                                                betType = ((Convert.ToDateTime(order1.Time)).ToString("yyyy-MM-dd") == (Convert.ToDateTime(order1.BeginTime)).ToString("yyyy-MM-dd")) ? "1" : "9";
                                                break;
                                            case "主客和":
                                                betType = "12";
                                                break;
                                            case "上半場大/小":
                                                betType = ((Convert.ToDateTime(order1.Time)).ToString("yyyy-MM-dd") == (Convert.ToDateTime(order1.BeginTime)).ToString("yyyy-MM-dd")) ? "3" : "11";
                                                break;
                                            case "上半場讓球":
                                                betType = ((Convert.ToDateTime(order1.Time)).ToString("yyyy-MM-dd") == (Convert.ToDateTime(order1.BeginTime)).ToString("yyyy-MM-dd")) ? "2" : "10";
                                                break;
                                            case "上半場主客和":
                                                betType = "13";
                                                break;
                                            case "走地大/小":
                                                betType = "5";
                                                break;
                                            case "走地讓球":
                                                betType = "4";
                                                break;
                                            case "走地主客和":
                                                betType = "14";
                                                break;
                                            case "走地上半場讓球":
                                                betType = "6";
                                                break;
                                            case "走地上半場大/小":
                                                betType = "7";
                                                break;
                                            case "走地上半場主客和":
                                                betType = "15";
                                                break;
                                        }
                                        order1.BetType = betType;
                                        td = substring2(td, "<span class=\"txtBetDateTime\">", "<br/>");
                                        if (td.Contains("betDetails_score"))
                                        {
                                            string betScore = substring(td, "<span class=\"betDetails_score\">", "</span>");
                                            td = substring2(td, "<span class=\"betDetails_score\">", "</span>");
                                        }
                                        order1.Hometw = substring(td, "<span class=\"txtTeam\">", "(").Replace("\r", "").Replace("\n", "");
                                        td = substring2(td, "<span class=\"txtTeam\">", "(");
                                        if (td.Contains("對"))
                                        {
                                            td = substring2(td, "<span class=\"txtBetDateTime\">", "</span");
                                        }
                                        else
                                        {
                                            order1.Handicap = substring(td, "<span class=\"betDetails_handicap\">", "</span>").Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                            td = substring2(td, "<span class=\"betDetails_handicap\">", "</span");
                                        }
                                        order1.Awaytw = substring(td, ">", "</span><br />").Replace("\n", "").Trim();
                                        order1.BetItem = substring(td, "<span class=\"txtTeam\">", "</span>").Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                        td = substring2(td, "<br />", "</span>");
                                        if (td.Contains("betDetails_handicap"))
                                        {
                                            order1.Handicap = substring(td, "<span class=\"betDetails_handicap\">", "</span>").Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                        }
                                        if (order1.Handicap.Contains("/"))
                                        {
                                            string[] strArr = order1.Handicap.Split('/');
                                            order1.Handicap = ((Convert.ToDouble(strArr[0]) + Convert.ToDouble(strArr[1])) / 2).ToString();
                                        }
                                        order1.Odds = Convert.ToDecimal(substring(td, "<span class=\"betDetails_price\">", "</span>").Replace("\r", "").Replace("\n", "").Replace("\t", ""));
                                        tr = substring2(tr, "<td", "</td>");
                                        order1.Amount = Convert.ToDecimal(substring(tr, ">", "</td>").Replace("\r", "").Replace("\n", "").Replace("\t", ""));
                                        tr = substring2(tr, "<td", "</td>");
                                        order1.Result = Convert.ToDecimal(substring(tr, ">", "</td>").Replace("\r", "").Replace("\n", "").Replace("\t", ""));
                                        tr = substring2(tr, "<td", "</td>");
                                        td = substring(tr, "<td", "</td>");
                                        temp = substring(td, ">", "<br/>");
                                        order1.Scorehalf = temp.Contains(":") ? substring(td, ":", "</span>") : substring(td, "<span class=\"txtHT\">", "</span>");
                                        td = substring2(td, "<span", "<br/>");
                                        order1.Score = td.Contains(":") ? substring(td, ":", "</span>") : substring(td, "<span class=\"txtFT\">", "</span>");
                                        if (!betAccountOrderHistory.OrderOtherHistorys.ContainsKey(order1.WebOrderID))
                                        {
                                            order1 = new Orderotherhistory();
                                            order1.ErrorMessage = "此单在皇朝网站上有记录";
                                            order1.WebUserName = betAccountOrderHistory.account.Userid;
                                            order1.WebOrderID = GetRandomOrderId();
                                            dic.Add(order1.WebOrderID, order1);
                                        }
                                        else
                                        {
                                            order2 = new Orderotherhistory();
                                            order2 = betAccountOrderHistory.OrderOtherHistorys[order1.WebOrderID];
                                            if (!order1.Score.Contains("該賽事的全部投注取消"))
                                            {
                                                td = substring2(td, ">", "</span><span");
                                                string result = substring(td, ">", "</span>").Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                                if (order2 != null)
                                                {
                                                    if (order1.BetType.Replace(" ", "").Trim() != order2.BetType.Replace(" ", "").Trim() || order1.Score.Replace(" ", "").Trim() != order2.Score.Replace(" ", "").Trim() || order2.Handicap.Replace("-", "").Replace(" ", "").Trim() != order1.Handicap.Replace(" ", "").Trim() || order2.Amount != order1.Amount || (Math.Abs(order1.Result) < Math.Abs(order2.Result) - 1m && Math.Abs(order1.Result) > Math.Abs(order2.Result) + 1m) || order2.Odds != order1.Odds)
                                                    {
                                                        order2.ErrorMessage = "匹配出错";
                                                        dic.Add(order2.WebOrderID, order2);
                                                    }
                                                }
                                                else
                                                {

                                                }
                                            }
                                            else
                                            {
                                                if (order2 != null)
                                                {
                                                    //球赛已取消
                                                    order2.WebUserName = betAccountOrderHistory.account.Userid;
                                                    order2.ErrorMessage = "皇朝注单号" + order1.WebOrderID + "的球赛已取消";
                                                    dic.Add(order2.WebOrderID, order2);
                                                }
                                            }
                                        }
                                        content = substring2(content, "<tr", "</tr>");
                                    }
                                }
                                catch (Exception)
                                {
                                    errCount++;
                                    if (errCount > 3)
                                    {
                                        order1 = new Orderotherhistory();
                                        order1.WebOrderID = GetRandomOrderId();
                                        order1.WebUserName = betAccountOrderHistory.account.Userid;
                                        order1.ErrorMessage = "皇朝帐号" + order1.WebUserName + "核对下注历史失败,获取页面异常或截取异常";
                                        dic.Add(order1.WebOrderID, order1);
                                        return dic;
                                    }
                                    else
                                    {
                                        Thread.Sleep(1000);
                                        goto label30;
                                    }
                                }
                                finally
                                {
                                    try { reader.Close(); }
                                    catch { ; }
                                    try
                                    {
                                        if (stream != null) { stream.Close(); }
                                    }
                                    catch { ; }
                                    try { response.Close(); }
                                    catch { ; }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                errCount++;
                if (errCount > 3)
                {
                    order1 = new Orderotherhistory();
                    order1.WebOrderID = GetRandomOrderId();
                    order1.WebUserName = betAccountOrderHistory.account.Userid;
                    order1.ErrorMessage = "帐号" + order1.WebUserName + "核对下注历史失败,获取页面异常或截取异常";
                    dic.Add(order1.WebOrderID, order1);
                    return dic;
                }
                else
                {
                    Thread.Sleep(1000);
                    goto label20;
                }
            }
            finally
            {
                try { reader.Close(); }
                catch { ; }
                try
                {
                    if (stream != null) { stream.Close(); }
                }
                catch { ; }
                try { response.Close(); }
                catch { ; }
            }
            return dic;
        }
     
        private static Betaccount huangguanlogin(Object o)
        {
            Betaccount user = (Betaccount)o;

        label10:
            HttpWebRequest request;
            HttpWebResponse response = null;

            CookieContainer cookies;
            cookies = new CookieContainer();
            string urlstr = "http://" + user.Address + "/app/member/index.php?langx=zh-tw";
            GZipStream stream = null;
            StreamReader reader = null;
            string postdata;
            string content;
            string uid;
            string cookie = "";
            int ireturn = 0;
            int count = 0;
            int count2 = 0;
            string fr_language = "zh-tw";
            string url = "";
            string cookiestr = "";
            try
            {
                try
                {//
                    url = " http://" + user.Address + "/";

                    request = (HttpWebRequest)WebRequest.Create(" http://" + user.Address + "/");
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, */*";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET4.0C; .NET4.0E)";
                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = false;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        reader = new StreamReader(new GZipStream(response.GetResponseStream(), CompressionMode.Decompress), big5);
                    }
                    else
                    {
                        reader = new StreamReader(response.GetResponseStream(), big5);
                    }
                    //reader = new StreamReader(stream, big5);
                    content = reader.ReadToEnd(); ;
                    count2 = 0;

                }
                catch (Exception ee)
                {
                    if (count2 < 8)
                    {
                        count2++;
                        goto label10;
                    }
                    else
                    {
                        user.islogin = -1;
                        return user;
                    }
                }
            }
            finally
            {

                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }


            try
            {
                try
                {//
                    cookiestr = response.Headers["Set-Cookie"];
                    //  users[iuserindex].host = "ra2288.com";
                    //cookiestr = getcookie(cookies.GetCookies(new Uri(url)));
                    request = (HttpWebRequest)WebRequest.Create(" http://" + user.Address + "/");
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, */*";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET4.0C; .NET4.0E)";
                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.Headers["Cookie"] = cookiestr;
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = false;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        reader = new StreamReader(new GZipStream(response.GetResponseStream(), CompressionMode.Decompress), big5);
                    }
                    else
                    {
                        reader = new StreamReader(response.GetResponseStream(), big5);
                    }
                    //reader = new StreamReader(stream, big5);
                    content = reader.ReadToEnd(); ;

                }
                catch (Exception ee)
                {
                    if (count2 < 8)
                    {
                        count2++;
                        goto label10;
                    }
                    else
                    {
                        user.islogin = -1;
                        return user;
                    }
                }
            }
            finally
            {

                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }
            try
            {
                request = (HttpWebRequest)WebRequest.Create(urlstr);
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/msword, */*";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["UA-CPU"] = "x86";
                request.Headers["Accept-Encoding"] = "gzip, deflate";

                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; msn OptimizedIE8;ZHCN)";
                request.KeepAlive = true;
                //request.ReadWriteTimeout = 5000;
                request.Headers["Cookie"] = cookiestr;


                response = (HttpWebResponse)request.GetResponse();
                if (response.Headers.Get("Content-Encoding") != null)
                {
                    stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    reader = new StreamReader(stream, big5);
                }
                else
                {
                    reader = new StreamReader(response.GetResponseStream(), big5);
                }
                content = reader.ReadToEnd();

                uid = substring(content, "name=\"uid\" value=\"", "\">");
                postdata = "uid=" + uid + "&langx=" + fr_language + "&username=" + user.Address2 + "&passwd=" + user.Password + "&number=4721&Submit2=%BDT%A9w";
                urlstr = "http://" + user.Address + "/app/member/login.php";
                request = (HttpWebRequest)WebRequest.Create(urlstr);
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/msword, */*";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["UA-CPU"] = "x86";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.Headers["Cookie"] = cookiestr;
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; msn OptimizedIE8;ZHCN)";
                request.KeepAlive = true;
                request.ContentType = "application/x-www-form-urlencoded";
                request.AllowAutoRedirect = true;
                request.ReadWriteTimeout = 5000;

                request.Method = "POST";
                //postdata = "uid="+uid+"&langx=zh-tw&mac=&ver=&JE=true&username="+user.userid+"&passwd="+user.password+"&number=0841";
                byte[] buffer = Encoding.ASCII.GetBytes(postdata);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                response = (HttpWebResponse)request.GetResponse();
                if (response.Headers.Get("Content-Encoding") != null)
                {
                    stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    reader = new StreamReader(stream, big5);
                }
                else
                {
                    reader = new StreamReader(response.GetResponseStream(), big5);
                }

                content = reader.ReadToEnd();


                if (content.Contains("Plaese wait 3 minutes and try again"))
                {
                   
                        user.islogin = -1;
                        return user;
                
                }

                if (content.Contains("Plaese check username/passwd"))
                {
                   
                        user.islogin = -1;
                        return user;
                  

                }

                cookie = substring(content, "uid=", "&");

            }
            catch (Exception ee)
            {
                if (count < 8)
                {
                    count++;
                    ireturn = 1;
                    goto label10;
                }
                else
                {
                    user.islogin = -1;
                    return user;
                  
                }

            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch
                {
                    ;
                }
            }


            user.Cookie = cookie;
            user.Address = cookiestr;
            user.islogin = 1;

            
            return user;

        }
        private static Betaccount huangguanlogout(Object o)
        {
            Betaccount user = (Betaccount)o;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            string url;
            string html;
            string cookiestr;
            string code = "";
            int count = 0;
            int iresult = -1;

            int ireturn = 0;
            DataRow[] rows;

           
            ///app/member/logout.php?uid=166564ddm5722615l1314429&langx=zh-cn
            string referer = "http://" + user.Address2 + "/app/member/FT_header.php?uid=" + user.Cookie + "&showtype=&langx=zh-tw&mtype=3";
            try
            {

                request = (HttpWebRequest)WebRequest.Create("http://" + user.Address2 + "/app/member/logout.php?uid=" + user.Cookie + "&langx=zh-tw");
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, */*";
                request.Referer = referer;
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["UA-CPU"] = "x86";
                //request.Headers["Cookie"] = user.cookie;
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
                //request.KeepAlive = true;
                request.Method = "GET";
                
                response = (HttpWebResponse)request.GetResponse();
                //reader = new StreamReader(response.GetResponseStream(), big5);
                //html = reader.ReadToEnd();


                user.Cookie = "";

                user.islogin = 0;

                return user;




            }
            catch (Exception e)
            {

                user.islogin = 0;

                return user;
            }

            finally
            {
                try
                {
                    reader.Close();
                }
                catch
                {
                    ;
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }
            user.Cookie = "";

            user.islogin = 0;
            return user;

        }
        public string LiJiGetCookieInfoGetNum(Bitmap bmp, int m)
        {
            Color pixel = bmp.GetPixel(0, 13);
            Color pixel201 = bmp.GetPixel(0, 9);
            Color color2 = bmp.GetPixel(4, 13);
            if ((pixel.R > 100) && (color2.R > 100) && (bmp.GetPixel(1, 4).R < 100))
            {
                return "2";
            }
            pixel = bmp.GetPixel(9, 0);
            color2 = bmp.GetPixel(5, 13);
            if (pixel.R > 180)
            {
                if ((color2.R < 200) && (bmp.GetPixel(2, 13).R > 100))
                {
                    return "7";
                }
                //  if ((bmp.GetPixel(8, 0).R > 200) && (bmp.GetPixel(0, 5).R < 100) && (bmp.GetPixel(4, 6).R < 200) && (bmp.GetPixel(0, 11).R > 100) && (bmp.GetPixel(8, 2).R < 100))
                if (bmp.GetPixel(9, 1).R < 200)
                {
                    return "5";
                }
            }
            pixel = bmp.GetPixel(2, 9);
            color2 = bmp.GetPixel(3, 9);
            if ((pixel.R > 200) && (color2.R > 200) && (bmp.GetPixel(2, 13).R < 100) && (bmp.GetPixel(0, 11).R < 100))
            {
                return "4";
            }
            if (bmp.GetPixel(6, 2).R > 200)
            {
                return "1";
            }
            //  if (bmp.GetPixel(5, 5).R > 200)
            //  {
            //    return "6";
            //  }
            //if ((bmp.GetPixel(6, 5).R > 200) && (bmp.GetPixel(5, 5).R > 100) && (bmp.GetPixel(8, 11).R > 100) && (bmp.GetPixel(1, 6).R > 100)&& (bmp.GetPixel(0, 5).R > 100))
            if ((bmp.GetPixel(6, 5).R > 200) && (bmp.GetPixel(5, 5).R > 100) && (bmp.GetPixel(8, 10).R > 100) && (bmp.GetPixel(8, 4).R < 200) && (bmp.GetPixel(8, 2).R > 100))
            {
                return "6";
            }
            if ((bmp.GetPixel(4, 8).R > 100) && (bmp.GetPixel(1, 4).R > 100))
            {
                return "9";
            }
            if (bmp.GetPixel(3, 5).R > 200 && (bmp.GetPixel(4, 6).R > 200))
            {
                return "8";
            }
            if ((bmp.GetPixel(5, 6).R > 200) && (bmp.GetPixel(1, 5).R < 100) && (bmp.GetPixel(8, 4).R > 100))
            {
                return "3";
            }
            return "0";
        }

        private int lijilogin(Object o)
        {
            Betaccount user = (Betaccount)o;
            string html;
            string str11;
            byte[] bytes;
            string tea = "";
            string page = "";


            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            string url;
            string yzmurl;
            string codeHash;
            string cookiestr;
            string code;
            string tzdiff = "";
            int count = 0;
            int count2 = 0;

            GZipStream stream2 = null;

            CookieContainer cookies = new CookieContainer();



        label10:
            url = "http://" + user.Address + "/";
            Uri uri = new Uri(url);
            //cookies.SetCookies(uri, "lang=zh-tw");
            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = false;
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.Headers.Add("UA-CPU", "x86");
                    request.Timeout = 5000;
                    request.ReadWriteTimeout = 5000;
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    response = (HttpWebResponse)request.GetResponse();
                    count2 = 0;

                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);

                    if (count2 < 8)
                    {
                        count2++;
                        goto label10;
                    }
                    else
                    {
                        user.islogin = -4;
                        return -4;
                    }
                }
            }
            finally
            {
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }
            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(url + "default.aspx?lang=zh-tw&p=sport");
                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = false;
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.Headers.Add("UA-CPU", "x86");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    response = (HttpWebResponse)request.GetResponse();

                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);

                    if (count < 8)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }
            string depositDay = "";
            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(url + "HomeTop.aspx?ip=&p=");
                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.CookieContainer = cookies;

                    request.Referer = url;
                    request.AllowAutoRedirect = false;
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.Headers.Add("Accept-Encoding", "gzip, deflate");
                    //request.Headers.Add("UA-CPU", "x86");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream2 = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                        reader = new StreamReader(stream2, utf8);
                    }
                    else
                    {
                        reader = new StreamReader(response.GetResponseStream(), utf8);
                    }
                    html = reader.ReadToEnd();

                    tea = substring(html, "name=\"tea\" type=\"hidden\" value=\"", "\"");
                    codeHash = substring(html, "<input id=\"key\" name=\"key\" type=\"hidden\" value=\"", "\"");
                    yzmurl = url + substring(html, "<img id=\"vc\" height=\"19\" onload=\"onloadVCode();\" src=\"", "\"");
                    page = substring(html, "name=\"page\" id=\"page\" value=\"", "\"");
                    depositDay = substring(html, "type='hidden' name='depositDay' value='", "'");
                    cookiestr = getcookie(cookies.GetCookies(uri));

                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);

                    if (count < 8)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }



            try
            {
                request = (HttpWebRequest)WebRequest.Create(yzmurl);
                request.KeepAlive = true;
                request.Method = "GET";
                request.CookieContainer = cookies;


                request.AllowAutoRedirect = false;
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, */*";
                request.Headers.Add("Accept-Language", "zh-cn");
                request.Headers.Add("Accept-Encoding", "gzip, deflate");

                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                response = (HttpWebResponse)request.GetResponse();
                //File.Delete("templiji.bmp");
                //WebClient client = new WebClient();

                //client.Headers.Add("Cookie", cookiestr);
                //client.DownloadFile(yzmurl, "templiji.bmp");

                Bitmap bitmap = new Bitmap(Bitmap.FromStream(response.GetResponseStream()));//new Bitmap("templiji.bmp");
                PixelFormat pixelFormat = bitmap.PixelFormat;
                Rectangle rect = new Rectangle(9, 7, 10, 14);
                Bitmap bmp = bitmap.Clone(rect, pixelFormat);
                code = "";
                code = code + LiJiGetCookieInfoGetNum(bmp, 1);
                rect = new Rectangle(20, 7, 10, 14);
                bmp = bitmap.Clone(rect, pixelFormat);
                code = code + LiJiGetCookieInfoGetNum(bmp, 2);
                rect = new Rectangle(32, 7, 10, 14);
                bmp = bitmap.Clone(rect, pixelFormat);
                code = code + LiJiGetCookieInfoGetNum(bmp, 3);
                rect = new Rectangle(44, 7, 10, 14);
                bmp = bitmap.Clone(rect, pixelFormat);
                code = code + LiJiGetCookieInfoGetNum(bmp, 4);
                bmp.Dispose();
                bitmap.Dispose();
                File.Delete("templiji.bmp");
            }
            catch (Exception ee)
            {
                System.Console.WriteLine(ee.Message);

                if (count < 8)
                {
                    count++;
                    goto label10;
                }
                else
                {
                    return -1;
                }
            }
            string id = "";
            string key = "";

            try
            {
                try
                {

                    //id=ar02310&password=aa1111&code=7667&page=default&lang=zh-tw&key=6943254820922&tea=189411&tzDiff=0
                    bytes = Encoding.ASCII.GetBytes("id=" + user.Userid + "&password=" + user.Password + "&code=" + code + "&page=" + page + "&lang=zh-tw&tea=" + tea + "&key=" + codeHash + "&tzDiff=0&sv=A02");
                    request = (HttpWebRequest)WebRequest.Create(url + "processlogin.aspx");
                    request.Method = "POST";
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/vnd.ms-excel, application/msword, application/x-shockwave-flash, */*";
                    request.Referer = url + "HomeTop.aspx";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers.Add("UA-CPU", "x86");
                    request.Headers.Add("Accept-Encoding", "gzip, deflate");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET4.0C; .NET4.0E; CIBA)";
                    request.KeepAlive = true;
                    request.Headers.Add("Cache-Control", "no-cache");
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = false;
                    //request.ServicePoint.Expect100Continue = false;
                    //request.Headers.Add("UA-CPU", "x86");
                    request.ContentLength = bytes.Length;
                    request.GetRequestStream().Write(bytes, 0, bytes.Length);
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        reader = new StreamReader(new GZipStream(response.GetResponseStream(), CompressionMode.Decompress), utf8);
                    }
                    else
                    {
                        reader = new StreamReader(response.GetResponseStream(), utf8);
                    }
                    html = reader.ReadToEnd();

                    if (html.Contains("input type='hidden' name='error' value='5'"))
                    {
                        if (count < 8)
                        {
                            count++;
                            goto label10;
                        }
                        else
                        {
                            user.islogin = -3;
                            return -3;
                        }
                    }
                    if (html.Contains("input type='hidden' name='error' value='6'"))
                    {

                        //System.Console.WriteLine("帐号:" + user.Userid + "密码错误!");
                        user.islogin = -1;
                        return -1;
                    }

                    count = 0;
                    user.Address2 = substring(html, "<form name='f' action='http://", "/welcome.aspx'");

                    id = substring(html, "input type='hidden' name='id' value='", "'");
                    key = substring(html, "<input type='hidden' name='key' value='", "' />");
                    tzdiff = substring(html, "<input type='hidden' name='tzDiff' value='", "' />");
                    //<input type='hidden' name='depositDay' value='0' /></form><script type="text/javascript">
                    depositDay = substring(html, "name='depositDay' value='", "'");
                    //<html><body onload='document.f.submit();'><form name='f' action='http://587o1pxe19g8.sbo222.com/welcome.aspx' method='get'><input type='hidden' name='key' value='xazahh45qrfgjvngvjhaut55' /><input type='hidden' name='id' value='7008' /><input type='hidden' name='lang' value='zh-tw' /><input type='hidden' name='tzDiff' value='0' /><input type='hidden' name='depositDay' value='0' /></form><script type="text/javascript">

                }
                catch (Exception ee)
                {
                    System.Console.WriteLine(ee.Message);

                    if (count < 8)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {

                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }
            string k = "";
            try
            {
                try
                {

                    //                                                                                                                                    /welcome.aspx?key=o50ssljo5a0upi55s0aov255&id=7008&lang=zh-tw&tzDiff=0&depositDay=0
                    request = (HttpWebRequest)WebRequest.Create("http://" + user.Address2 + "/welcome.aspx?key=" + key + "&id=" + id + "&lang=zh-tw&tzDiff=" + tzdiff + "&depositDay=" + depositDay + "&redirect=true&ldomain=" + user.Address);
                    request.Method = "GET";
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, */*";
                    request.Referer = "http://" + user.Address + "/processlogin.aspx";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers.Add("UA-CPU", "x86");
                    request.Headers.Add("Accept-Encoding", "gzip, deflate");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET4.0C; .NET4.0E; CIBA)";
                    request.KeepAlive = true;
                    request.Headers.Add("Cache-Control", "no-cache");
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = false;

                    response = (HttpWebResponse)request.GetResponse();
                    str11 = new StreamReader(response.GetResponseStream(), utf8).ReadToEnd();
                    str11 = System.Web.HttpUtility.UrlDecode(str11);
                    k = substring(str11, "?", "\">");
                    if (k == null)
                    {
                        k = substring(str11, "<a href=\"", "\">");
                    }
                    user.loginname = substring(str11, "loginname%3d", "\"");
                    if (str11.Contains("Logout.aspx"))
                    {


                        if (count < 8)
                        {
                            count++;
                            goto label10;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);

                    if (count < 8)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {

                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }
            try
            {
                try
                {
                    //http://i9utedfi6gxj.waternike.com/process-welcome.aspx?k=NqkrWdGiVAQseXlwxhINKHjTjzbXbviOmJgdUcLbCzXRu&lang=zh-tw&tzDiff=0
                    request = (HttpWebRequest)WebRequest.Create("http://" + user.Address2 + "/process-welcome.aspx?" + k);
                    request.Method = "GET";
                    request.Referer = "http://" + user.Address2 + "/welcome.aspx?lang=zh-cn";
                    request.KeepAlive = true;
                    request.AllowAutoRedirect = false;
                    request.ServicePoint.Expect100Continue = false;
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET4.0C; .NET4.0E; CIBA)";
                    request.CookieContainer = cookies;
                    response = (HttpWebResponse)request.GetResponse();
                    str11 = new StreamReader(response.GetResponseStream(), utf8).ReadToEnd();
                    user.loginname = substring(str11, "loginname%3d", "\">here");

                }
                catch (Exception ee)
                {
                    System.Console.WriteLine(ee.Message);

                    if (count < 20)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        user.Cookie = null;

                        System.Console.WriteLine(user.Userid + "登陆失败!");
                        return -1;

                    }
                }
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }



            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create("http://" + user.Address2 + "/webroot/restricted/misc/termandconditions.aspx");
                    request.Method = "GET";
                    request.Referer = "http://" + user.Address2 + "/welcome.aspx?lang=zh-cn";
                    request.KeepAlive = true;
                    request.AllowAutoRedirect = false;
                    request.ServicePoint.Expect100Continue = false;
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.CookieContainer = cookies;
                    response = (HttpWebResponse)request.GetResponse();
                    str11 = new StreamReader(response.GetResponseStream(), utf8).ReadToEnd();

                }
                catch (Exception ee)
                {
                    System.Console.WriteLine(ee.Message);

                    if (count < 8)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }
            try
            {
                try
                {//%E6%88%91%E5%90%8C%E6%84%8F
                    bytes = Encoding.ASCII.GetBytes("action=%E6%88%91%E5%90%8C%E6%84%8F");
                    request = (HttpWebRequest)WebRequest.Create("http://" + user.Address2 + "/webroot/restricted/misc/TermAndConditions.aspx");
                    request.Method = "POST";
                    request.Referer = "http://" + user.Address2 + "/webroot/restricted/misc/termandconditions.aspx";
                    request.KeepAlive = true;
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = false;
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.Headers.Add("UA-CPU", "x86");
                    request.Headers.Add("Cache-Control", "no-cache");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = bytes.Length;
                    request.GetRequestStream().Write(bytes, 0, bytes.Length);
                    response = (HttpWebResponse)request.GetResponse();
                    html = new StreamReader(response.GetResponseStream(), utf8).ReadToEnd();
                    html = html.Replace("%2f", "/").Replace("%3f", "?").Replace("%3d", "=");
                    user.loginname = substring(html, "loginname=", "%26");

                }
                catch (Exception ee)
                {
                    System.Console.WriteLine(ee.Message);

                    if (count < 8)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {

                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }

            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create("http://" + user.Address2 + "/webroot/restricted/DefaultFrame.aspx");
                    request.Method = "GET";
                    request.Referer = url + "webroot/restricted/misc/termandconditions.aspx";
                    request.KeepAlive = true;
                    request.AllowAutoRedirect = false;
                    request.CookieContainer = new CookieContainer();
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.Headers.Add("Accept-Encoding", "gzip, deflate");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.CookieContainer = cookies;
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (Exception ee)
                {
                    System.Console.WriteLine(ee.Message);

                    if (count < 8)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {
                //try
                //{
                //    reader.Close();
                //}
                //catch
                //{
                //}
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }
            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create("http://" + user.Address2 + "/webroot/restricted/Oddsdisplay/Main.aspx?op=t&sport=1");
                    request.Method = "GET";
                    request.Referer = "http://" + user.Address2 + "/" + "webroot/restricted/DefaultFrame.aspx";
                    request.KeepAlive = true;
                    request.AllowAutoRedirect = false;
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.Headers.Add("Accept-Encoding", "gzip, deflate");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.CookieContainer = cookies;
                    response = (HttpWebResponse)request.GetResponse();



                }
                catch (Exception ee)
                {
                    System.Console.WriteLine(ee.Message);

                    if (count < 8)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }


            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create("http://" + user.Address2 + "/webroot/restricted/Oddsdisplay/Main.aspx?op=t&sport=1");
                    request.Method = "GET";
                    request.Referer = "http://" + user.Address2 + "/" + "webroot/restricted/DefaultFrame.aspx";
                    request.KeepAlive = true;
                    request.AllowAutoRedirect = false;
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.Headers.Add("Accept-Encoding", "gzip, deflate");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.CookieContainer = cookies;

                    response = (HttpWebResponse)request.GetResponse();



                }
                catch (Exception ee)
                {
                    System.Console.WriteLine(ee.Message);

                    if (count < 8)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }


            try
            {
                try
                {//action=%E6%88%91%E5%90%8C%E6%84%8F
                    bytes = Encoding.ASCII.GetBytes("synid=-1&sportid=1&oddsStyle=Malay&dt=4&scope=1");
                    request = (HttpWebRequest)WebRequest.Create("http://" + user.Address2 + "/webroot/restricted/misc/TermAndConditions.aspx");
                    request.Method = "POST";
                    request.Referer = "http://" + user.Address2 + "/webroot/restricted/Oddsdisplay/Main.aspx?op=t&sport=1";
                    request.KeepAlive = true;
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = false;
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.Headers.Add("UA-CPU", "x86");
                    request.Headers.Add("Cache-Control", "no-cache");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = bytes.Length;
                    request.GetRequestStream().Write(bytes, 0, bytes.Length);
                    response = (HttpWebResponse)request.GetResponse();
                    html = new StreamReader(response.GetResponseStream(), utf8).ReadToEnd();

                }
                catch (Exception ee)
                {
                    System.Console.WriteLine(ee.Message);

                    if (count < 8)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {
                //try
                //{
                //    stream.Close();
                //}
                //catch
                //{
                //}
                //try
                //{
                //    reader.Close();
                //}
                //catch
                //{
                //}
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }
            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create("http://" + user.Address2 + "/webroot/restricted/odds/main.aspx?sport=&page=2");
                    request.Method = "GET";
                    request.Referer = "http://" + user.Address2 + "/" + "webroot/restricted/DefaultFrame.aspx";
                    request.KeepAlive = true;
                    request.AllowAutoRedirect = false;
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.Headers.Add("Accept-Encoding", "gzip, deflate");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.CookieContainer = cookies;

                    response = (HttpWebResponse)request.GetResponse();



                }
                catch
                {
                    if (count < 8)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }
            string sql = null;

            //user.Cookie = cookies;
            cookiestr = getcookie(cookies.GetCookies(new Uri("http://" + user.Address2 + "/")));
            user.Cookie = cookiestr;
            //user.Cookie = cookies;
            user.islogin = 1;
          
            return 1;


        }

        private static void lijilogout(Object o)
        {
            Betaccount user = (Betaccount)o;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            string url;
            string html;
            string cookiestr;
            string code = "";
            int count = 0;

            int ireturn = 0;


            string referer = "http://" + user.Address2 + "/webroot/restricted/HomeTop.aspx";
            try
            {
                //http://ra8888.com/app/member/logout.php?uid=16ff3de5m3c236fl5f34a38&langx=zh-tw
                request = (HttpWebRequest)WebRequest.Create("http://" + user.Address2 + "/logout.aspx");
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/vnd.ms-excel, application/msword, application/x-shockwave-flash, */*";
                request.Referer = referer;
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["UA-CPU"] = "x86";
                request.Headers["Cookie"] = user.Cookie;
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                request.KeepAlive = true;
                request.Method = "GET";

                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), big5);
                html = reader.ReadToEnd();

                user.Cookie = "";
                user.islogin = 0;

                return;

            }
            catch (Exception e)
            {
                user.islogin = 0;
                return;

            }

            finally
            {
                try
                {
                    reader.Close();
                }
                catch
                {
                    ;
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }

        }
        public string ShaBaGetCookieInfoGetNum(Bitmap bmp, int m)
        {

            // if ((bmp.GetPixel(0, 6).R < 100) && (bmp.GetPixel(0, 7).R > 180) && (bmp.GetPixel(0, 8).R < 100) && (bmp.GetPixel(1, 0).R > 200) && (bmp.GetPixel(0, 6).R < 100) && (bmp.GetPixel(6, 0).R > 100) && (bmp.GetPixel(6, 4).R > 200))
            if ((bmp.GetPixel(2, 1).R > 200) && (bmp.GetPixel(3, 1).R < 150) && (bmp.GetPixel(2, 0).R > 200) && (bmp.GetPixel(3, 0).R > 200) && (bmp.GetPixel(0, 3).R < 200))
            {
                return "5";
            }


            // if ((bmp.GetPixel(0, 0).R < 100) && (bmp.GetPixel(1, 0).R < 100) && (bmp.GetPixel(2, 0).R < 100) && (bmp.GetPixel(3, 0).R > 100) && (bmp.GetPixel(0, 4).R < 100))
            if ((bmp.GetPixel(2, 1).R > 180) && (bmp.GetPixel(2, 0).R < 200) && (bmp.GetPixel(3, 0).R > 200) && (bmp.GetPixel(3, 1).R > 200))
            {
                return "1";
            }


            if ((bmp.GetPixel(0, 8).R > 200) && (bmp.GetPixel(6, 8).R > 200))
            {
                return "2";
            }
            if ((bmp.GetPixel(0, 0).R > 150) && (bmp.GetPixel(6, 0).R > 100) && (bmp.GetPixel(2, 7).R > 100))
            {
                return "7";
            }
            if ((bmp.GetPixel(0, 1).R > 150) && (bmp.GetPixel(0, 4).R < 180) && (bmp.GetPixel(0, 7).R > 180) && (bmp.GetPixel(1, 4).R < 200))
            {
                return "3";
            }
            //  if ((bmp.GetPixel(6, 4).R < 100) && (bmp.GetPixel(6, 5).R > 100) && (bmp.GetPixel(6, 6).R < 100))
            if ((bmp.GetPixel(3, 8).R < 200) && (bmp.GetPixel(4, 8).R > 200) && (bmp.GetPixel(5, 8).R > 200) && (bmp.GetPixel(6, 8).R < 200))
            {
                return "4";
            }
            if ((bmp.GetPixel(0, 6).R > 180) && (bmp.GetPixel(2, 3).R > 100) && (bmp.GetPixel(3, 3).R > 100) && (bmp.GetPixel(4, 3).R > 100))
            {
                return "6";
            }
            if ((bmp.GetPixel(0, 4).R < 200) && (bmp.GetPixel(1, 4).R > 200) && (bmp.GetPixel(5, 4).R > 200) && (bmp.GetPixel(6, 4).R < 200))
            {
                return "8";

            }
            if ((bmp.GetPixel(0, 8).R < 200) && (bmp.GetPixel(1, 8).R > 200) && (bmp.GetPixel(4, 8).R > 200) && (bmp.GetPixel(5, 8).R < 100))
            {
                return "9";
            }



            return "0";


        }
        private string ShaBaGetCookieInfoLoginFunParseMap()
        {


            string str3 = "";
            Bitmap bitmap = new Bitmap("tempshaba.bmp");
            PixelFormat pixelFormat = bitmap.PixelFormat;
            Rectangle rect = new Rectangle(4, 6, 7, 9);
            Bitmap bmp = bitmap.Clone(rect, pixelFormat);
            str3 = str3 + ShaBaGetCookieInfoGetNum(bmp, 1);
            bmp.Dispose();
            rect = new Rectangle(12, 6, 7, 9);
            bmp = bitmap.Clone(rect, pixelFormat);
            str3 = str3 + ShaBaGetCookieInfoGetNum(bmp, 2); ;
            bmp.Dispose();
            rect = new Rectangle(20, 6, 7, 9);
            bmp = bitmap.Clone(rect, pixelFormat);
            str3 = str3 + ShaBaGetCookieInfoGetNum(bmp, 3); ;
            bmp.Dispose();
            rect = new Rectangle(28, 6, 7, 9);
            bmp = bitmap.Clone(rect, pixelFormat);
            str3 = str3 + ShaBaGetCookieInfoGetNum(bmp, 4); ;
            bmp.Dispose();
            bitmap.Dispose();
            return str3;
        }
        private int shabalogin(Object o)
        {

            Betaccount user = (Betaccount)o;
            string html = null;
            string str11 = "";
            byte[] bytes;

            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            string url;
            string yzmurl = "";
            string cookiestr;
            string code = "";
            string gx = "";
            string referer = "";
            int count = 0;
            int count2 = 0;
            int ireturn = 0;

            Uri uri;



            if (user.Address2 != null && user.Address2.Length > 0)
            {
                url = "http://" + user.Address2 + "/UnderOver_data.aspx?Market=t&DT=&RT=W&CT=&Game=0";
                referer = "http://" + user.Address2 + "/UnderOver.aspx?Sport=1&Market=t&DispVer=new&Game=0";
                try
                {
                    try
                    {
                        request = (HttpWebRequest)WebRequest.Create(url);
                        request.Method = "GET";
                        request.KeepAlive = true;
                        request.AllowAutoRedirect = true;
                        request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*";
                        request.Headers.Add("Accept-Language", "zh-cn");
                        request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                        request.Headers["Cookie"] = user.Cookie;
                        request.Referer = referer;
                        response = (HttpWebResponse)request.GetResponse();
                        str11 = new StreamReader(response.GetResponseStream(), utf8).ReadToEnd();

                    }
                    catch (Exception e)
                    {
                        str11 = "";

                    }
                }
                finally
                {
                    try
                    {
                        reader.Close();
                    }
                    catch
                    {
                    }
                    try
                    {
                        response.Close();
                    }
                    catch
                    {
                    }

                }
                if (str11.Contains("parent.ShowBetList("))
                {

                    return 1;
                }
            }

        label10:
            CookieContainer cookies = new CookieContainer();
            url = "http://" + user.Address + "/";
            uri = new Uri(url);

            try
            {
                try
                {
                    cookiestr = "__utma=55329267.1983777493960649200.1231942803.1236159453.1237220745.7; __utmz=55329267.1231942803.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none); LangKey=ch; RNRVersion-9033A5FC38964E9A388A4D21F835EB39=B66FF0540E7035D303CD9A2383A89EE2; AcceptBetterOdds-9033A5FC38964E9A388A4D21F835EB39=no; DispVer=3; MiniKey=max; RNRVersion-5083499BD0ABCAE2E42B2DE139E338CB=B66FF0540E7035D303CD9A2383A89EE2; AcceptBetterOdds-5083499BD0ABCAE2E42B2DE139E338CB=no; __utmb=55329267.1.10.1237220745; RNRVersion-675D59D14574190EAE6148178E1A1B64=B66FF0540E7035D303CD9A2383A89EE2; AcceptBetterOdds-675D59D14574190EAE6148178E1A1B64=no";
                    cookiestr = cookiestr.Replace(";", ",");
                    cookies.SetCookies(new Uri(url), cookiestr);
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/msword, */*";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Headers.Add("UA-CPU", "x86");
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = false;
                    response = (HttpWebResponse)request.GetResponse();

                }
                catch (Exception e)
                {
                    if (count2 < 8)
                    {
                        count2++;
                        goto label10;
                    }
                    else
                    {
                        user.islogin = -4;
                        return -4;
                    }
                }
            }
            finally
            {
                try
                {
                    response.Close();
                }
                catch
                {
                }

            }


            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(url + "head.aspx");
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/msword, */*";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Headers.Add("UA-CPU", "x86");
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.CookieContainer = cookies;
                    response = (HttpWebResponse)request.GetResponse();

                }
                catch (Exception e)
                {
                    if (count < 4)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }


            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(url + "ChangeLanguage.aspx");
                    bytes = Encoding.ASCII.GetBytes("hidSelLang=ch&hidIsLogin=no");
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/msword, */*";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Headers.Add("UA-CPU", "x86");
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers["Cache-Control"] = "no-cache";
                    request.KeepAlive = true;
                    request.Method = "POST";
                    request.CookieContainer = cookies;
                    request.ContentLength = bytes.Length;
                    request.GetRequestStream().Write(bytes, 0, bytes.Length);
                    response = (HttpWebResponse)request.GetResponse();
                    reader = new StreamReader(response.GetResponseStream(), utf8);
                    html = reader.ReadToEnd();


                }
                catch (Exception e)
                {
                    if (count < 4)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }



            try
            {
                try
                {
                    yzmurl = url + "index.aspx?";
                    request = (HttpWebRequest)WebRequest.Create(yzmurl);
                    request.Method = "GET";
                    request.KeepAlive = true;
                    request.AllowAutoRedirect = false;
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.CookieContainer = cookies;
                    response = (HttpWebResponse)request.GetResponse();
                    reader = new StreamReader(response.GetResponseStream(), utf8);
                    str11 = reader.ReadToEnd();

                }
                catch (Exception e)
                {
                    if (count < 4)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }


            string hidkey = "";
            string hidLowerCasePW = "";
            string hidServerKey = "";
            try
            {
                try
                {
                    yzmurl = url + "head.aspx";
                    request = (HttpWebRequest)WebRequest.Create(yzmurl);
                    request.Method = "GET";
                    request.KeepAlive = true;
                    request.AllowAutoRedirect = false;
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.CookieContainer = cookies;
                    response = (HttpWebResponse)request.GetResponse();
                    reader = new StreamReader(response.GetResponseStream(), utf8);
                    str11 = reader.ReadToEnd();
                    hidkey = substring(str11, "<input id = \"hidKey\" type=hidden name=\"hidKey\" value=\"", "\"");
                    hidLowerCasePW = substring(str11, "<input id = \"hidLowerCasePW\" type=hidden name=\"hidLowerCasePW\" value=\"", "");
                    hidServerKey = substring(str11, "<input type=hidden name=\"hidServerKey\" value=\"", "\"");
                }
                catch (Exception e)
                {
                    if (count < 4)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }



        label20:
            lock (gx)
            {
                try
                {
                    cookiestr = getcookie(cookies.GetCookies(new Uri(url)));
                    yzmurl = url + "login_code.aspx?";
                    File.Delete("tempshaba.bmp");
                    WebClient client = new WebClient();

                    client.Headers.Add("Cookie", cookiestr);
                    client.DownloadFile(yzmurl, "tempshaba.bmp");
                    Bitmap bitmap = new Bitmap("tempshaba.bmp");
                    PixelFormat pixelFormat = bitmap.PixelFormat;
                    Rectangle rect = new Rectangle(4, 6, 7, 9); ;
                    Bitmap bmp = bitmap.Clone(rect, pixelFormat);
                    code = "";
                    code = code + ShaBaGetCookieInfoGetNum(bmp, 1);
                    rect = new Rectangle(12, 6, 7, 9);
                    bmp = bitmap.Clone(rect, pixelFormat);
                    code = code + ShaBaGetCookieInfoGetNum(bmp, 2);
                    rect = new Rectangle(20, 6, 7, 9);
                    bmp = bitmap.Clone(rect, pixelFormat);
                    code = code + ShaBaGetCookieInfoGetNum(bmp, 3);
                    rect = new Rectangle(28, 6, 7, 9);
                    bmp = bitmap.Clone(rect, pixelFormat);
                    code = code + ShaBaGetCookieInfoGetNum(bmp, 4);
                    bmp.Dispose();
                    bitmap.Dispose();
                    ireturn = 0;
                    //File.Delete("tempshaba.bmp");
                }
                catch (Exception e)
                {
                    if (count < 4)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }


            try
            {
                try
                {

                    string cfskey = ConvertCode(user.Password);
                    string cfslowerkey = ConvertCode(user.Password.ToLower());
                    string validcode = code;
                    hidLowerCasePW = cfslowerkey + validcode;
                    hidkey = md5(cfskey + validcode);
                    string postdata = "selLang=ch&txtID=" + user.Userid + "&txtPW=" + user.Password + "&txtCode=" + code + "&hidKey=" + hidkey + "&hidLowerCasePW=" + hidLowerCasePW + "&hidServerKey=" + hidServerKey;
                    //selLang=ch&txtID=M312R24119&txtPW=3627D15D889AF86BB47DC76797A48F&txtCode=6929&hidKey=9ffbd77e56b0b8442ce397c214c78b36&hidLowerCasePW=9ffbd77e56b0b8442ce397c214c78b36&hidServerKey=609906.com
                    bytes = Encoding.ASCII.GetBytes(postdata);
                    request = (HttpWebRequest)WebRequest.Create(url + "ProcessLogin.aspx");
                    request.Method = "POST";
                    request.Referer = url + "head.aspx";
                    request.KeepAlive = true;
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = false;
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.Headers.Add("UA-CPU", "x86");
                    request.Headers.Add("Cache-Control", "no-cache");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = bytes.Length;
                    request.GetRequestStream().Write(bytes, 0, bytes.Length);
                    response = (HttpWebResponse)request.GetResponse();
                    reader = new StreamReader(response.GetResponseStream(), utf8);
                    html = reader.ReadToEnd();

                    if (html.Contains("登錄次數過於頻繁,請稍後再試"))
                    {
                        user.islogin = -6;
                        return -6;

                    }

                    if (html.Contains("不准許 在此地區登入"))
                    {
                        user.islogin = -5;
                        return -5;
                    }
                    //您的帳號已關閉請聯絡您的代理,開啟您的帳號
                    if (html.Contains("您的帳號已關閉請聯絡您的代理,開啟您的帳號"))
                    {
                        user.islogin = -2;
                        return -2;
                    }
                    if (html.Contains("帳號/密碼錯誤"))
                    {
                        user.islogin = -1;
                        return -1;
                    }
                    if (html.Contains("識別碼錯誤"))
                    {
                        if (count < 8)
                        {
                            //Display("第" + count.ToString() + "次验证码错误");
                            count++;
                            goto label20;
                        }
                        else
                        {
                            user.islogin = -3;
                            return -3;

                        }


                    }



                }
                catch (Exception e)
                {
                    if (count < 4)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {

                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }

            if (!html.Contains("rulesalert.aspx"))
            {
                if (count < 10)
                {
                    //Display("第" + count.ToString() + "次验证码错误");

                    count++;
                    Thread.Sleep(1000);
                    goto label20;
                }
                else
                {
                    return -1;

                }


            }


            try
            {
                try
                {
                    bytes = Encoding.ASCII.GetBytes("Accept=YES");
                    request = (HttpWebRequest)WebRequest.Create(url + "rulesalert.aspx");
                    request.Method = "POST";
                    request.Referer = url + "rulesalert.aspx";
                    request.KeepAlive = true;
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = false;
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.Headers.Add("UA-CPU", "x86");
                    request.Headers.Add("Cache-Control", "no-cache");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = bytes.Length;
                    request.GetRequestStream().Write(bytes, 0, bytes.Length);
                    response = (HttpWebResponse)request.GetResponse();
                    reader = new StreamReader(response.GetResponseStream(), utf8);
                    html = reader.ReadToEnd();
                    yzmurl = substring(html, "window.location='", "';</script>");
                    user.Address2 = substring(html, "window.location='http://", "/ValidateTicket.aspx");
                }
                catch (Exception e)
                {
                    if (count < 4)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {

                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }


            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(yzmurl);
                    request.Method = "GET";
                    request.KeepAlive = true;
                    request.AllowAutoRedirect = true;
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.CookieContainer = cookies;
                    response = (HttpWebResponse)request.GetResponse();
                    reader = new StreamReader(response.GetResponseStream(), utf8);
                    str11 = reader.ReadToEnd();



                }
                catch (Exception e)
                {
                    if (count < 4)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }

            }


            if (str11.Contains("window.location.replace("))
            {

                count++;
            }
            //if (user.pankou == "0")
            url = "http://" + user.Address2 + "/UnderOver_data.aspx?Market=t&DT=&RT=W&CT=&Game=0&OrderBy=0&OddsType=4";
            ////else
            //url = "http://" + user.Address2 + "/UnderOver_data.aspx?Market=t&DT=&RT=W&CT=&Game=0&OrderBy=0&OddsType=2";
            referer = "http://" + user.Address2 + "/UnderOver.aspx?Sport=1&Market=t&DispVer=new&Game=0";


            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.KeepAlive = true;
                    request.AllowAutoRedirect = true;
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.CookieContainer = cookies;
                    request.Referer = referer;
                    response = (HttpWebResponse)request.GetResponse();
                    reader = new StreamReader(response.GetResponseStream(), utf8);
                    str11 = reader.ReadToEnd();

                    //if (!str11.Contains("parent.ShowBetList("))
                    //{
                    //    if (count < 4)
                    //    {
                    //        count++;
                    //        goto label10;
                    //    }
                    //    else
                    //    {
                    //       return -1;
                    //    }
                    //}



                }
                catch (Exception e)
                {
                    if (count < 4)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }

                }
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }


            try
            {
                referer = "";
                string postdata = "accountUpdate=mini";
                url = "http://" + user.Address2 + "/leftAllInOneAccount_data.aspx";
                referer = "http://" + user.Address2 + "/LeftAllInOne.aspx";

                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/msword, */*";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["UA-CPU"] = "x86";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                request.KeepAlive = true;
                request.Referer = referer;
                request.ContentType = "application/x-www-form-urlencoded";
                request.AllowAutoRedirect = false;
                request.Timeout = 9000;
                request.Headers["Cookie"] = user.Cookie;
                bytes = Encoding.ASCII.GetBytes(postdata);
                request.ContentLength = bytes.Length;
                stream = request.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
                response = (HttpWebResponse)request.GetResponse();
                if (response.Headers.Get("Content-Encoding") != null)
                {
                    stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    reader = new StreamReader(stream, utf8);
                }
                else
                {
                    reader = new StreamReader(response.GetResponseStream(), utf8);
                }

                html = reader.ReadToEnd();

            }
            catch (Exception ee)
            {

            }
            finally
            {
                try
                {
                    response.Close();
                    if (stream != null)
                        stream.Close();
                    reader.Close();
                }
                catch
                {
                    ;
                }
            }

            cookiestr = getcookie(cookies.GetCookies(new Uri("http://" + user.Address2 + "/")));
            user.Cookie = cookiestr;
            user.islogin = 1;

            return 1;


        }
        public static string md5(string str)
        {

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] InBytes = Encoding.GetEncoding("GB2312").GetBytes(str);
            byte[] OutBytes = md5.ComputeHash(InBytes);
            string OutString = "";
            for (int i = 0; i < OutBytes.Length; i++)
            {
                OutString += OutBytes[i].ToString("x2");
            }

            return OutString;
        }



        private static int ConvertAscii(string text)
        {
            byte[] array = new byte[1];

            array = System.Text.Encoding.ASCII.GetBytes(text);
            int asciicode = (int)(array[0]);
            return asciicode;
        }
        /// <summary>
        /// 调用这个方法
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string ConvertCode(string code)
        {

            long codeLen = 30;
            long codeSpace;
            int cecr;
            int cecb;
            int cec;
            Double newCode = 1;
            string cfsStr = "";
            codeSpace = codeLen - code.Length;
            if (codeSpace > 1)
            {
                for (cecr = 1; cecr <= codeSpace; cecr++)
                {
                    code = code + Char.ConvertFromUtf32(21);
                }
            }
            long been = 0;
            for (cecb = 1; cecb <= codeLen; cecb++)
            {
                been = codeLen + ConvertAscii(code.Substring(cecb - 1, 1)) * cecb;
                newCode = Convert.ToDouble(newCode * been);
            }

            code = newCode.ToString().ToUpper();
            string newcode2 = "";

            for (cec = 1; cec <= code.Length; cec++)
            {

                if (code.Length - 1 <= cec)
                {
                    newcode2 += CfsCode(code.Substring(cec - 1));

                }
                else
                {
                    newcode2 = newcode2 + CfsCode(code.Substring(cec - 1, 3));
                }
            }

            for (cec = 20; cec <= newcode2.Length - 18; cec += 2)
            {
                cfsStr = cfsStr + newcode2.Substring(cec - 1, 1);
            }
            return cfsStr;

        }


        public static string CfsCode(string word)
        {
            int cc;
            string c = "";

            for (cc = 1; cc <= word.Length; cc++)
            {
                c = c + ConvertAscii(word.Substring(cc - 1, 1));

            }
            //Decimal d = Convert.ToDecimal(code);
            //code = d.ToString("x");
            c = String.Format("{0:X000}", int.Parse(c));
            return c;
        }

        private static void shabalogout(Object o)
        {
            Betaccount user = (Betaccount)o;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            string url;
            string html;
            string cookiestr;
            string code = "";
            int count = 0;

            int ireturn = 0;
            DataRow[] rows;
            

            string referer = "http://" + user.Address2 + "/topmenu.aspx";
            try
            {
                //http://ra8888.com/app/member/logout.php?uid=16ff3de5m3c236fl5f34a38&langx=zh-tw
                request = (HttpWebRequest)WebRequest.Create("http://" + user.Address2 + "/logout.aspx");
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/vnd.ms-excel, application/msword, application/x-shockwave-flash, */*";
                request.Referer = referer;
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["UA-CPU"] = "x86";
                request.Headers["Cookie"] = user.Cookie;
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                request.KeepAlive = true;
                request.Method = "GET";

                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), big5);
                html = reader.ReadToEnd();


                user.Cookie = "";

                user.islogin = 0;

                return;




            }
            catch (Exception e)
            {
                user.islogin = 0;
                return;

            }

            finally
            {
                try
                {
                    reader.Close();
                }
                catch
                {
                    ;
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }

          
        }

        private static Betaccount xinqiulogin(Object o)
        {
            Betaccount user = (Betaccount)o;
            string html;
            string str11;
            byte[] bytes;

            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            string url;
            string yzmurl;
            string codeHash;
            string cookiestr;
            string code = "";
            int count = 0;
            int ireturn = 0;
            int count2 = 0;
            CookieContainer cookies;

        label10:
            cookies = new CookieContainer();
            user.Address = "www.188bet.com";
            url = "http://" + user.Address + "/";
            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(url + "zh-tw/");
                    request.Accept = "*/*";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Headers["UA-CPU"] = "x86";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";

                    request.KeepAlive = true;
                    request.Method = "GET";

                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = true;
                    response = (HttpWebResponse)request.GetResponse();
                    count2 = 0;

                }
                catch (Exception e)
                {
                    if (count2 < 8)
                    {
                        count2++;
                        goto label10;
                    }
                    else
                    {
                        user.islogin = -1;
                        return user;
                    }
                }
            }
            finally
            {
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }




            string EVENTVALIDATION = "";
            string VIEWSTATE = "";




        label20:
            try
            {
                try
                {

                    bytes = Encoding.ASCII.GetBytes("Userid=" + user.Userid + "&Password=" + user.Password);
                    request = (HttpWebRequest)WebRequest.Create(url + "zh-tw/Service/UserService?Login");
                    request.Method = "POST";
                    request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; zh-CN; rv:1.9.2.10) Gecko/20100914 Firefox/3.6.10";
                    request.Accept = "*/*";
                    request.Headers.Add("Accept-Language", "zh-cn,zh;q=0.5");

                    request.Referer = url + "zh-tw/";///Common/SB2/Login_SB2.aspx?s11Lang=CHS
                    request.KeepAlive = true;
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = true;
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, */*";

                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("Cache-Control", "no-cache");
                    request.Headers.Add("Pragma", "no-cache");
                    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    request.ContentLength = bytes.Length;
                    request.GetRequestStream().Write(bytes, 0, bytes.Length);
                    response = (HttpWebResponse)request.GetResponse();
                    html = new StreamReader(response.GetResponseStream(), utf8).ReadToEnd();


                    if (html.Contains("<span id=\"MessageLabel\">用戶名無效或密碼錯誤。請重試。</span>"))
                    {

                        user.Cookie = null;
                        System.Console.WriteLine("帐号:" + user.Userid + "密码错误!,登陆失败");
                        user.islogin = 0;
                        return user;
                    }
                    if (html.Contains("<span id=\"MessageLabel\">無效的驗證碼。</span>"))
                    {
                        if (count < 8)
                        {
                            System.Console.WriteLine("第" + count.ToString() + "次验证码错误,正在尝试下一次识别");
                            count++;
                            goto label20;
                        }
                        else
                        {
                            System.Console.WriteLine("连续" + count.ToString() + "验证码错误,系统退出");

                            user.islogin = 0;
                            return user;

                        }


                    }


                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);
                    user.Cookie = null;

                    user.islogin = 0;
                    //System.Console.WriteLine("帐号" + user.Userid + "登陆失败");
                    return user;
                }
            }
            finally
            {
                try
                {
                    stream.Close();
                }
                catch
                {
                }
                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }
            string url2 = "http://welcome.188bet.com/LoginRedirect.aspx?q=" + substring(html, "q=", "\"");
            try
            {
                try
                {
                    yzmurl = url2;
                    request = (HttpWebRequest)WebRequest.Create(yzmurl);
                    request.Method = "GET";
                    request.KeepAlive = true;
                    request.AllowAutoRedirect = true;
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.CookieContainer = cookies;
                    response = (HttpWebResponse)request.GetResponse();
                    str11 = new StreamReader(response.GetResponseStream(), utf8).ReadToEnd();

                }
                catch (Exception e)
                {
                    if (count2 < 8)
                    {
                        count2++;
                        goto label10;
                    }
                    else
                    {
                        user.islogin = -1;
                        return user;
                    }
                }
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }
            try
            {
                try
                {

                    bytes = Encoding.ASCII.GetBytes("");
                    url2 = "http://welcome.188bet.com/zh-tw/Service/HomePageService?GetCurrentDateStrRefresh";
                    request = (HttpWebRequest)WebRequest.Create(url2);
                    request.Method = "POST";
                    request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; zh-CN; rv:1.9.2.10) Gecko/20100914 Firefox/3.6.10";
                    request.Accept = "*/*";
                    request.Headers.Add("Accept-Language", "zh-cn,zh;q=0.5");

                    request.Referer = url + "zh-tw/";///Common/SB2/Login_SB2.aspx?s11Lang=CHS
                    request.KeepAlive = true;
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = true;
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, */*";

                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("Cache-Control", "no-cache");
                    request.Headers.Add("Pragma", "no-cache");
                    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    request.ContentLength = bytes.Length;
                    request.GetRequestStream().Write(bytes, 0, bytes.Length);
                    response = (HttpWebResponse)request.GetResponse();
                    html = new StreamReader(response.GetResponseStream(), utf8).ReadToEnd();


                }
                catch (Exception e)
                {

                    if (count2 < 8)
                    {
                        count2++;
                        goto label10;
                    }
                    else
                    {
                        user.islogin = -1;
                        return user;
                    }
                }
            }
            finally
            {
                try
                {
                    stream.Close();
                }
                catch
                {
                }
                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }
            try
            {
                try
                {

                    bytes = Encoding.ASCII.GetBytes("");
                    url2 = "http://welcome.188bet.com/zh-tw/Service/SportMenuService?GetInplayCounter";
                    request = (HttpWebRequest)WebRequest.Create(url2);
                    request.Method = "POST";
                    request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; zh-CN; rv:1.9.2.10) Gecko/20100914 Firefox/3.6.10";
                    request.Accept = "*/*";
                    request.Headers.Add("Accept-Language", "zh-cn,zh;q=0.5");

                    request.Referer = url + "zh-tw/";///Common/SB2/Login_SB2.aspx?s11Lang=CHS
                    request.KeepAlive = true;
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = true;
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, */*";

                    request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                    request.Headers.Add("Cache-Control", "no-cache");
                    request.Headers.Add("Pragma", "no-cache");
                    request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                    request.ContentLength = bytes.Length;
                    request.GetRequestStream().Write(bytes, 0, bytes.Length);
                    response = (HttpWebResponse)request.GetResponse();
                    html = new StreamReader(response.GetResponseStream(), utf8).ReadToEnd();

                }
                catch (Exception e)
                {

                    if (count2 < 8)
                    {
                        count2++;
                        goto label10;
                    }
                    else
                    {
                        user.islogin = -1;
                        return user;
                    }
                }
            }
            finally
            {
                try
                {
                    stream.Close();
                }
                catch
                {
                }
                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }


            user.Address2 = "welcome.188bet.com";
            cookiestr = getcookie(cookies.GetCookies(new Uri("http://" + user.Address2 + "/")));
            user.Cookie = cookiestr;
            user.islogin = 1;
           
            return user;


        }
        private static Betaccount xinqiulogout(Object o)
        {
            Betaccount user = (Betaccount)o;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;

            string html;

           
            string referer = "http://" + user.Address + "/topmenu.aspx";
            try
            {
                //http://ra8888.com/app/member/logout.php?uid=16ff3de5m3c236fl5f34a38&langx=zh-tw
                request = (HttpWebRequest)WebRequest.Create("http://" + user.Address + "/Logout.aspx");
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/vnd.ms-excel, application/msword, application/x-shockwave-flash, */*";
                //request.Referer = referer;
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["UA-CPU"] = "x86";
                request.Headers["Cookie"] = user.Cookie;
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                request.KeepAlive = true;
                request.Method = "GET";

                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), big5);
                html = reader.ReadToEnd();
                user.Cookie = "";
                user.islogin = 0;

            }
            catch (Exception e)
            {
                user.islogin = 0;
                return user;

            }

            finally
            {
                try
                {
                    reader.Close();
                }
                catch
                {
                    ;
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }

            return user;


        }
        private static Betaccount yonglilogin(Object o)
        {
            Betaccount user = (Betaccount)o;
            DataRow[] rows;
            int ireturn = 0;


            string html = "";
            string str11;
            byte[] bytes;


            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            string url;
            string phpsessionid = null;
            string yzmurl = null;
            string codeHash;
            string cookiestr;
            string code;
            int count = 0;
        label10:
            CookieContainer cookies = new CookieContainer();
            user.Address = "www.a1a888.com";

            url = "http://" + user.Address + "/";
            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/msword, */*";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Headers.Add("UA-CPU", "x86");
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.Referer = url;
                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = true;
                    response = (HttpWebResponse)request.GetResponse();
                    html = new StreamReader(response.GetResponseStream(), gb2312).ReadToEnd();
                    //phpsessionid = "PHPSESSID=" + substring(html, "| <a href='", "' class=\"blue\">&#31616;&#20307;&#29256;</a>");
                }
                catch (Exception e)
                {
                    if (count < 4)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        user.islogin = -1;
                        return user;
                    }

                }
            }
            finally
            {
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }


            try
            {
                try
                {
                    yzmurl = url + phpsessionid;
                    if (html.Contains("home.html"))
                        request = (HttpWebRequest)WebRequest.Create(url + "home.html");
                    else
                        request = (HttpWebRequest)WebRequest.Create(url + "home.php");
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/msword, */*";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Headers.Add("UA-CPU", "x86");
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.Referer = url;
                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = true;
                    response = (HttpWebResponse)request.GetResponse();
                    html = new StreamReader(response.GetResponseStream(), gb2312).ReadToEnd();

                }
                catch (Exception e)
                {
                    if (count < 4)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return user;
                    }
                }
            }
            finally
            {
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }

           
            try
            {
                try
                {

                   
                    bytes = Encoding.ASCII.GetBytes("username=" + user.Userid + "&password=" + user.Password + "&login=%B5%C7%C8%EB");
                    request = (HttpWebRequest)WebRequest.Create(url + "login.php");
                    request.Method = "POST";
                    request.Referer = url + "home.php?lang=gb2312";
                    request.KeepAlive = true;
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = true;
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.Headers.Add("UA-CPU", "x86");
                    request.Headers.Add("Cache-Control", "no-cache");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = bytes.Length;
                    request.GetRequestStream().Write(bytes, 0, bytes.Length);
                    response = (HttpWebResponse)request.GetResponse();
                    yzmurl = response.ResponseUri.ToString();
                    reader = new StreamReader(response.GetResponseStream(), gb2312);
                    html = reader.ReadToEnd();
                    if (html.Contains("登入"))
                    {

                        return user;
                    }


                }
                catch
                {
                    if (count < 4)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return user;
                    }
                }
            }
            finally
            {

                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }

            }

            try
            {
                try
                {
                    bytes = Encoding.ASCII.GetBytes("agree=%CE%D2%CD%AC%D2%E2+O");
                    request = (HttpWebRequest)WebRequest.Create(yzmurl);
                    request.Method = "POST";
                    request.Referer = yzmurl;
                    request.KeepAlive = true;
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = false;
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.Headers.Add("UA-CPU", "x86");
                    request.Headers.Add("Cache-Control", "no-cache");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = bytes.Length;
                    request.GetRequestStream().Write(bytes, 0, bytes.Length);
                    response = (HttpWebResponse)request.GetResponse();
                    reader = new StreamReader(response.GetResponseStream(), gb2312);
                    html = reader.ReadToEnd();


                }
                catch
                {
                    if (count < 4)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return user;
                    }

                }
            }
            finally
            {

                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
               

            }


            try
            {
                try
                {
                    
                    request = (HttpWebRequest)WebRequest.Create(url + "right/type/?set_plan=mala&sport_id=1");
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/msword, */*";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Headers.Add("UA-CPU", "x86");
                    //request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.Referer = url;
                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = true;
                    response = (HttpWebResponse)request.GetResponse();
                    reader = new StreamReader(response.GetResponseStream(), gb2312);
                    html = reader.ReadToEnd();

                    
                    if (html.Contains("self.parent.location='/logout.php'"))
                    {
                        if (count < 4)
                        {
                            count++;
                            goto label10;
                        }
                        else
                        {
                            return user;
                        }

                    }


                }
                catch (Exception e)
                {
                    if (count < 4)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return user;
                    }
                }
            }
            finally
            {
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }


            cookiestr = getcookie(cookies.GetCookies(new Uri("http://" + user.Address + "/")));
            user.Cookie = cookiestr;
            user.islogin = 1;
            return user;


        }
        private static Betaccount yonglilogout(Object o)
        {
            Betaccount user = (Betaccount)o;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            string html;

            string referer = "http://" + user.Address + "/header.php?" + user.Cookie;
            try
            {
                //http://ra8888.com/app/member/logout.php?uid=16ff3de5m3c236fl5f34a38&langx=zh-tw
                request = (HttpWebRequest)WebRequest.Create("http://" + user.Address + "/logout.php");
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/vnd.ms-excel, application/msword, application/x-shockwave-flash, */*";
                request.Referer = referer;
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["UA-CPU"] = "x86";
                request.Headers["Cookie"] = user.Cookie;
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                //request.KeepAlive = true;
                request.Method = "GET";

                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), big5);
                html = reader.ReadToEnd();
                user.Cookie = "";
                user.islogin = 0;
                return user;




            }
            catch (Exception e)
            {
                user.islogin = 0;
                user.Cookie = "";
                return user;

            }

            finally
            {
                try
                {
                    reader.Close();
                }
                catch
                {
                    ;
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }

        }
        private int as3388login(Object o)
        {
            Betaccount user = (Betaccount)o;
            DataRow[] rows;


            string html;
            string str11;
            byte[] bytes;


            string cookiestr1;
            string cookiestr2;



            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            string url;
            string yzmurl;
            string cookiestr;
            string code = "";
            int count = 0;
            int count2 = 0;
            int ireturn = 0;
        label10:
            CookieContainer cookies = new CookieContainer();


            url = "http://" + user.Address + "/";
            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                    request.Headers["Accept-Language"] = "zh-cn,zh;q=0.5";
                    request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; zh-CN; rv:1.9.2.10) Gecko/20100914 Firefox/3.6.10";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.KeepAlive = true;

                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = true;
                    response = (HttpWebResponse)request.GetResponse();
                    count2 = 0;

                }
                catch (Exception e)
                {
                    if (count2 < 8)
                    {
                        count2++;
                        goto label10;

                    }
                    else
                    {
                        user.islogin = -4;
                        return -4;
                    }

                }
            }
            finally
            {
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }


            cookiestr1 = getcookie(cookies.GetCookies(new Uri(url)));



            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(url + "user_sportsinfo8/login_main.php?language=simplified");
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/msword, */*";
                    request.Referer = url + "/Login.aspx?ReturnUrl=%2fDefault.aspx";
                    request.Headers["Accept-Language"] = "zh-cn";

                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; zh-CN; rv:1.9.2.10) Gecko/20100914 Firefox/3.6.10";
                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = true;

                    response = (HttpWebResponse)request.GetResponse();
                    html = new StreamReader(response.GetResponseStream(), utf8).ReadToEnd();

                }
                catch (Exception e)
                {
                    if (count < 8)
                    {
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }





        label20:

            try
            {
                yzmurl = url + "user_sportsinfo8/draw_gd.php";
                request = (HttpWebRequest)WebRequest.Create(yzmurl);
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/msword, */*";
                request.Referer = url + "/Login.aspx?ReturnUrl=%2fDefault.aspx";
                request.Headers["Accept-Language"] = "zh-cn";

                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; zh-CN; rv:1.9.2.10) Gecko/20100914 Firefox/3.6.10";
                request.KeepAlive = true;
                request.Method = "GET";
                request.CookieContainer = cookies;
                request.AllowAutoRedirect = true;
                response = (HttpWebResponse)request.GetResponse();

                code = "";
                Bitmap bitmap = new Bitmap(response.GetResponseStream());

                code = getas3388Code(bitmap);


                bitmap.Dispose();

            }
            catch (Exception e)
            {
                if (count < 8)
                {
                    goto label10;
                }
                else
                {
                    return -1;
                }
            }

            try
            {
                try
                {
                    //fr_language=traditional&fr_username=wa4677&fr_password=aaa111&fr_gdcode=2647&fr_submit=Enter
                    bytes = Encoding.ASCII.GetBytes("fr_language=traditional&fr_username=" + user.Userid + "&fr_password=" + user.Password + "&fr_gdcode=" + code + "&fr_submit=Enter");
                    request = (HttpWebRequest)WebRequest.Create(url + "user_sportsinfo8/?p=login_action");
                    request.Method = "POST";
                    request.Referer = url + "user_sportsinfo8/login.php?file=&doc=&lang=traditional";
                    request.KeepAlive = true;
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = true;

                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/QVOD, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");

                    request.Headers.Add("Cache-Control", "no-cache");
                    request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; zh-CN; rv:1.9.2.10) Gecko/20100914 Firefox/3.6.10";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers.Add("Accept-Encoding", "gzip, deflate");
                    request.ContentLength = bytes.Length;
                    request.GetRequestStream().Write(bytes, 0, bytes.Length);
                    response = (HttpWebResponse)request.GetResponse();


                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                        reader = new StreamReader(stream, utf8);
                    }
                    else
                    {
                        reader = new StreamReader(response.GetResponseStream(), utf8);
                    }
                    html = reader.ReadToEnd();
                    try
                    {
                        html = ToUnicode(html);
                    }
                    catch
                    {
                        ;
                    }
                    if (html.Contains("用戶帳號暫時停用"))
                    {
                        user.islogin = -2;
                        return -2;
                    }

                    if (html.Contains("login_header.php?invalid=1&language=traditional"))
                    {
                        user.islogin = -1;
                        return -1;
                    }
                    if (html.Contains("login_header.php?invalid="))
                    {
                        if (count < 8)
                        {
                            //Display("第" + count.ToString() + "次验证码错误,正在尝试下一次识别");
                            count++;
                            goto label20;
                        }
                        else
                        {
                            user.islogin = -3;
                            return -3;
                        }
                    }
                    if (html.Contains("请更换你的密码"))
                    {
                        user.islogin = 1;
                    }
                    //if (!html.Contains("我同意"))
                    //{
                    //    if (count < 8)
                    //    {
                    //        Display("第" + count.ToString() + "次验证码错误,正在尝试下一次识别");
                    //        count++;
                    //        goto label20;
                    //    }
                    //    else
                    //    {
                    //        Display("连续" + count.ToString() + "验证码错误,系统退出");
                    //        this.isfinashed = 1;
                    //        return;

                    //    }


                    //}


                }
                catch
                {
                    if (count < 8)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {

                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }



            try
            {
                try
                {
                   
                    yzmurl = url + "/user_sportsinfo8/traditional/index.php?p=event_odds&act=autorefresh_n&vt=1&st=MY&og=c&lo=1&uco=my&sot=2&spt=1&mid=&timezone=America/La_Paz&wc=0";
                    request = (HttpWebRequest)WebRequest.Create(yzmurl);
                    request.Method = "GET";
                    request.KeepAlive = true;
                    request.AllowAutoRedirect = false;
                    request.KeepAlive = true;
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = true;
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/QVOD, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");

                    request.Headers.Add("Cache-Control", "no-cache");
                    request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; zh-CN; rv:1.9.2.10) Gecko/20100914 Firefox/3.6.10";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers.Add("Accept-Encoding", "gzip, deflate");

                    response = (HttpWebResponse)request.GetResponse();
                    reader = new StreamReader(response.GetResponseStream(), gb2312);
                    str11 = reader.ReadToEnd();


                    if (html.IndexOf("session-expired.php") > 0)
                    {
                        if (count < 8)
                        {
                            count++;
                            goto label10;
                        }
                        else
                        {
                            return -1;
                        }

                    }

                }
                catch
                {
                    if (count < 8)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }

            cookiestr = getcookie(cookies.GetCookies(new Uri(url)));
            //cookiestr = cookiestr + ";cookie_selected_league=ALL";
            //cookiestr2 = getcookie(cookies.GetCookies(new Uri(yzmurl)));
            ////cookiestr = cookiestr + ";cookie_selected_league=ALL";
            //int i = cookiestr2.IndexOf("user_onlinekey");
            //cookiestr2 = cookiestr2.Substring(i);
            //cookiestr = cookiestr1 + "; __utmc=1; __utma=1.808151845.1291088663.1299064459.1299066445.34; __utmz=1.1291088663.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none)" + "; "+ cookiestr2;





            user.Cookie = cookiestr;

            user.islogin = 1;

           
            return 1;


        }

        private static void as3388logout(Object o)
        {
            Betaccount user = (Betaccount)o;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;

            string html;


           

            //string referer = "http://" + user.Address + "/user_bw3388/";
            try
            {
                //http://ra8888.com/app/member/logout.php?uid=16ff3de5m3c236fl5f34a38&langx=zh-tw
                request = (HttpWebRequest)WebRequest.Create("http://" + user.Address + "/user_sportsinfo8/traditional/index.php?p=logout");
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/vnd.ms-excel, application/msword, application/x-shockwave-flash, */*";
                //request.Referer = referer;
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["UA-CPU"] = "x86";
                request.Headers["Cookie"] = user.Cookie;
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                request.KeepAlive = true;
                request.Method = "GET";

                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), big5);
                html = reader.ReadToEnd();


                user.Cookie = "";

                user.islogin = 0;

                return;




            }
            catch (Exception e)
            {
                user.islogin = 0;
                return;

            }

            finally
            {
                try
                {
                    reader.Close();
                }
                catch
                {
                    ;
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }


        }
        public static string getas3388Code(Bitmap bitmap)
        {
            int x, y, x1, y1, x2;
            string code = null;
            // Bitmap bitmap = new Bitmap(img);
            PixelFormat pixlFormat = bitmap.PixelFormat;

            x = getas3388NumX(bitmap);
            Rectangle rect = new Rectangle(x, 0, 8, 18);
            Bitmap map = bitmap.Clone(rect, pixlFormat);
            y = getas3388NumY(map);
            rect = new Rectangle(x, y, 8, 10);
            map = bitmap.Clone(rect, pixlFormat);
            code = GetCookieInfoGetNumAS3388(map);

            x1 = x + 8;
            x2 = 55 - 8 - x;
            rect = new Rectangle(x1, 0, x2, 18);
            map = bitmap.Clone(rect, pixlFormat);
            x = getas3388NumX(map);
            x1 = x + x1;
            rect = new Rectangle(x1, 0, 8, 18);
            map = bitmap.Clone(rect, pixlFormat);
            y = getas3388NumY(map);
            rect = new Rectangle(x1, y, 8, 10);
            map = bitmap.Clone(rect, pixlFormat);
            code = code + GetCookieInfoGetNumAS3388(map);

            x2 = 55 - 8 - x1;
            x1 = x1 + 8;
            rect = new Rectangle(x1, 0, x2, 18);
            map = bitmap.Clone(rect, pixlFormat);
            x = getas3388NumX(map);
            x1 = x + x1;
            rect = new Rectangle(x1, 0, 8, 18);
            map = bitmap.Clone(rect, pixlFormat);
            y = getas3388NumY(map);
            rect = new Rectangle(x1, y, 8, 10);
            map = bitmap.Clone(rect, pixlFormat);
            code = code + GetCookieInfoGetNumAS3388(map);

            x2 = 55 - 8 - x1;
            x1 = x1 + 8;
            rect = new Rectangle(x1, 0, x2, 18);
            map = bitmap.Clone(rect, pixlFormat);
            x = getas3388NumX(map);
            x1 = x + x1;
            rect = new Rectangle(x1, 0, 8, 18);
            map = bitmap.Clone(rect, pixlFormat);
            y = getas3388NumY(map);
            rect = new Rectangle(x1, y, 8, 10);
            map = bitmap.Clone(rect, pixlFormat);
            code = code + GetCookieInfoGetNumAS3388(map);


            bitmap.Dispose();
            map.Dispose();
            return code;
        }
        /// <summary>
        /// 指定的Y轴坐标与数字产生的焦点个数
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="vh"></param>
        /// <returns></returns>
        public static int getas3388NumY(Bitmap bitmap)
        {
            int width = bitmap.Size.Width;
            int height = bitmap.Size.Height;
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    if (bitmap.GetPixel(i, j).R == 239)
                    {
                        return j;
                    }
                }
            }
            return 0;
        }
        /// <summary>
        /// 指定的X轴坐标与数字产生的焦点个数
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="vh"></param>
        /// <returns></returns>
        public static int getas3388NumX(Bitmap bitmap)
        {
            int height = bitmap.Size.Height;
            int width = bitmap.Size.Width;
            for (int j = 0; j < width; j++)
            {
                for (int i = 0; i < height; i++)
                {
                    if (bitmap.GetPixel(j, i).R == 239)
                    {
                        return j;
                    }
                }
            }
            return 0;
        }
        public static string GetCookieInfoGetNumAS3388(Bitmap bmp)
        {
            int num = 0;


            for (int i = 0; i < 8; i++)
            {
                if (bmp.GetPixel(i, 0).B == 182) num = num + 1;
            }
            if ((num == 8) && (bmp.GetPixel(0, 9).B == 182))
            {
                return "7";
            }




            num = 0;
            if (bmp.GetPixel(0, 0).B == 182) return "5";

            for (int i = 0; i < 8; i++)
            {
                if (bmp.GetPixel(i, 9).B == 182) num = num + 1;
            }
            if (num == 8)
            {
                return "2";
            }
            if (num == 4)
            {
                if (bmp.GetPixel(7, 3).B == 182) return "9";


            }
            if (num == 5)
            {
                return "3";


            }
            if (num == 4)
            {
                if (bmp.GetPixel(0, 4).B == 182)
                {
                    return "6";
                }

                return "8";
            }
            num = 0;
            for (int i = 0; i < 8; i++)
            {
                if (bmp.GetPixel(i, 6).B == 182) num = num + 1;
            }
            if (num == 8)
            {
                return "4";
            }
            if (getas3388Num(bmp, 9) == 6)
            {
                return "1";
            }
            return "0";
        }

        public static int getas3388Num(Bitmap bitmap, int vh)
        {
            int num = 0;
            int width = bitmap.Size.Width;
            for (int i = 0; i < width; i++)
            {
                if (bitmap.GetPixel(i, vh).B == 182) num++;
            }
            return num;
        }
        public string GetCookieInfoGetNumAS3388(Bitmap bmp, int n)
        {
            int num = 0;


            for (int i = 0; i < 8; i++)
            {
                if (bmp.GetPixel(i, 0).B == 0) num = num + 1;
            }
            if ((num == 8) && (bmp.GetPixel(0, 9).B == 0))
            {
                return "7";
            }




            num = 0;
            if (bmp.GetPixel(0, 0).B == 0) return "5";

            for (int i = 0; i < 8; i++)
            {
                if (bmp.GetPixel(i, 9).B == 0) num = num + 1;
            }
            if (num == 8)
            {
                return "2";
            }
            if (num == 4)
            {
                if (bmp.GetPixel(7, 3).B == 0) return "9";


            }
            if (num == 5)
            {
                return "3";


            }

            if (num == 4)
            {
                if (bmp.GetPixel(0, 4).B == 0)
                {
                    return "6";
                }

                return "8";


            }

            num = 0;
            for (int i = 0; i < 8; i++)
            {
                if (bmp.GetPixel(i, 6).B == 0) num = num + 1;
            }
            if (num == 8)
            {
                return "4";
            }

            return "0";

        }
        private int heduilogin(Object o)
        {
            Betaccount user = (Betaccount)o;

            string html;

            byte[] bytes;


            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            string gx = "";
            string url;
            string yzmurl;
            string cookiestr;
            string code = "";
            int count = 0;
        label10:
            CookieContainer cookies = new CookieContainer();
            System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
            int ireturn = 0;


            url = "https://" + user.Address + "/";
            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(url + "/sb2/me/logo.jsp?localeString=zh_tw");
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/vnd.ms-excel, application/msword, application/x-shockwave-flash, */*";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Headers["UA-CPU"] = "x86";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = true;
                    response = (HttpWebResponse)request.GetResponse();

                }
                catch (Exception e)
                {
                    if (count < 8)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }


        label20:

            try
            {
                lock (gx)
                {
                    yzmurl = url + "sb2/me/generate_validation_code.jsp";
                    request = (HttpWebRequest)WebRequest.Create(yzmurl);
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/msword, */*";
                    request.Referer = url + "/Login.aspx?ReturnUrl=%2fDefault.aspx";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Headers.Add("UA-CPU", "x86");
                    //request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = true;
                    response = (HttpWebResponse)request.GetResponse();

                    code = "";
                    Bitmap bitmap = new Bitmap(response.GetResponseStream());

                    PixelFormat pixelFormat = bitmap.PixelFormat;

                    Rectangle rect = new Rectangle(7, 0, 11, 17);
                    Bitmap bmp = bitmap.Clone(rect, pixelFormat);
                    Bitmap bitmap3 = HeDuiGetCookie_GetSmollBitmap(bmp);
                    bmp.Dispose();
                    code = code + HeDuiGetCookie_GetNum(bitmap3);
                    bitmap3.Dispose();
                    rect = new Rectangle(20, 0, 11, 17);
                    bmp = bitmap.Clone(rect, pixelFormat);
                    bitmap3 = HeDuiGetCookie_GetSmollBitmap(bmp);
                    bmp.Dispose();
                    code = code + HeDuiGetCookie_GetNum(bitmap3);
                    bitmap3.Dispose();
                    rect = new Rectangle(33, 0, 11, 17);
                    bmp = bitmap.Clone(rect, pixelFormat);
                    bitmap3 = HeDuiGetCookie_GetSmollBitmap(bmp);
                    bmp.Dispose();
                    code = code + HeDuiGetCookie_GetNum(bitmap3);
                    bitmap3.Dispose();
                    rect = new Rectangle(46, 0, 11, 17);
                    bmp = bitmap.Clone(rect, pixelFormat);
                    bitmap3 = HeDuiGetCookie_GetSmollBitmap(bmp);
                    bmp.Dispose();
                    code = code + HeDuiGetCookie_GetNum(bitmap3);
                    bitmap3.Dispose();
                    bitmap.Dispose();
                }




            }
            catch (Exception e)
            {
                if (count < 8)
                {
                    count++;
                    goto label10;
                }
                else
                {
                    return -1;
                }
            }


            try
            {
                try
                {
                    //localeString=zh_tw&meLoginCode=cigawww11&password=aaa111&validationCode=8759

                    bytes = Encoding.ASCII.GetBytes("localeString=zh_tw&meLoginCode=" + user.Userid + "&password=" + user.Password + "&validationCode=" + code);
                    request = (HttpWebRequest)WebRequest.Create(url + "sb2/me/proceed_login.jsp");
                    request.Method = "POST";
                    request.Referer = url + "sb2/me/left.jsp?localeString=zh_tw";
                    request.KeepAlive = true;
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = true;
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.Headers.Add("UA-CPU", "x86");
                    request.Headers.Add("Cache-Control", "no-cache");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = bytes.Length;
                    request.GetRequestStream().Write(bytes, 0, bytes.Length);
                    response = (HttpWebResponse)request.GetResponse();
                    reader = new StreamReader(response.GetResponseStream(), utf8);
                    html = reader.ReadToEnd();
                    if (html.Contains("对不起, 用户帐号或者密码不对"))
                    {
                        return -1;
                    }
                    if (html.Contains("frame src=\"logo.jsp?localeString=zh_tw"))
                    {
                        if (count < 5)
                        {

                            count++;
                            goto label20;
                        }
                        else
                        {
                            return -1; ;

                        }


                    }


                }
                catch
                {
                    if (count < 8)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {

                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }



            string referer = "https://" + user.Address + "/sb2/me/info.jsp?localeString=zh_tw";

            try
            {
                request = (HttpWebRequest)WebRequest.Create("https://" + user.Address + "/sb2/me/list_evt_soccer_today_ah_old.jsp?evtTypeId=2");
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/vnd.ms-excel, application/msword, application/x-shockwave-flash, */*";
                request.Referer = referer;
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["UA-CPU"] = "x86";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                request.KeepAlive = true;
                request.Method = "GET";
                request.CookieContainer = cookies;
                request.AllowAutoRedirect = true;
                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), utf8);
                html = reader.ReadToEnd();
                if (html.IndexOf("logo.jsp") > 0)
                {
                    if (count < 8)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }

            }
            catch (Exception e)
            {
                if (count < 8)
                {
                    count++;
                    goto label10;
                }
                else
                {
                    return -1;
                }
            }

            finally
            {
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }


            try
            {
                try
                {
                    //localeString=zh_tw&meLoginCode=cigawww11&password=aaa111&validationCode=8759
                    //if (user.pankou == "1")
                    bytes = Encoding.ASCII.GetBytes("betProfileId=1");
                    //else
                    //    bytes = Encoding.ASCII.GetBytes("betProfileId=2");
                    request = (HttpWebRequest)WebRequest.Create(url + "sb2/me/proceed_update_bet_profile.jsp");
                    request.Method = "POST";
                    request.Referer = url + "sb2/me/view_personal_info.jsp";
                    request.KeepAlive = true;
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = true;
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.Headers.Add("UA-CPU", "x86");
                    request.Headers.Add("Cache-Control", "no-cache");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = bytes.Length;
                    request.GetRequestStream().Write(bytes, 0, bytes.Length);
                    response = (HttpWebResponse)request.GetResponse();
                    reader = new StreamReader(response.GetResponseStream(), utf8);
                    html = reader.ReadToEnd();




                }
                catch
                {
                    if (count < 8)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            finally
            {

                try
                {
                    reader.Close();
                }
                catch
                {
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }
            ;



            cookiestr = getcookie(cookies.GetCookies(new Uri("https://" + user.Address + "/sb2")));
            user.Cookie = cookiestr;

            user.islogin = 1;


            return 1;


        }
        public class MyPolicy : ICertificatePolicy
        {
            public bool CheckValidationResult(
            ServicePoint srvPoint
            , X509Certificate certificate
            , WebRequest request
            , int certificateProblem)
            {

                //Return True to force the certificate to be accepted. 
                return true;

            } // end CheckValidationResult 
        }
        private static void heduilogout(Object o)
        {
            Betaccount user = (Betaccount)o;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;

            string html;

            string referer = "https://" + user.Address + "/sb2/me/notice.jsp?localeString=zh_cn";
            try
            {
                //http://ra8888.com/app/member/logout.php?uid=16ff3de5m3c236fl5f34a38&langx=zh-tw
                request = (HttpWebRequest)WebRequest.Create("https://" + user.Address + "/sb2/me/proceed_logout.jsp?localeString=zh_cn");
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/vnd.ms-excel, application/msword, application/x-shockwave-flash, */*";
                request.Referer = referer;
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["UA-CPU"] = "x86";
                request.Headers["Cookie"] = user.Cookie;
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                request.KeepAlive = true;
                request.Method = "GET";

                response = (HttpWebResponse)request.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), big5);
                html = reader.ReadToEnd();


                user.Cookie = "";

                user.islogin = 0;

                return;




            }
            catch (Exception e)
            {
                user.islogin = 0;
                return;

            }

            finally
            {
                try
                {
                    reader.Close();
                }
                catch
                {
                    ;
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }


        }
        public static Bitmap HeDuiGetCookie_GetSmollBitmap(Bitmap bmp)
        {
            int num5;
            int num6;
            int y = -1;
            int num2 = -1;
            int x = -1;
            int num4 = -1;
            for (num5 = 0; num5 < bmp.Height; num5++)
            {
                num6 = 0;
                while (num6 < bmp.Width)
                {
                    if (bmp.GetPixel(num6, num5).G < 130)
                    {
                        y = num5;
                        break;
                    }
                    num6++;
                }
                if (y > -1)
                {
                    break;
                }
            }
            for (num5 = bmp.Height - 1; num5 > -1; num5--)
            {
                num6 = 0;
                while (num6 < bmp.Width)
                {
                    if (bmp.GetPixel(num6, num5).G < 130)
                    {
                        num2 = num5;
                        break;
                    }
                    num6++;
                }
                if (num2 > -1)
                {
                    break;
                }
            }
            for (num5 = 0; num5 < bmp.Width; num5++)
            {
                num6 = 0;
                while (num6 < bmp.Height)
                {
                    if (bmp.GetPixel(num5, num6).G < 130)
                    {
                        x = num5;
                        break;
                    }
                    num6++;
                }
                if (x > -1)
                {
                    break;
                }
            }
            for (num5 = bmp.Width - 1; num5 > -1; num5--)
            {
                for (num6 = 0; num6 < bmp.Height; num6++)
                {
                    if (bmp.GetPixel(num5, num6).G < 130)
                    {
                        num4 = num5;
                        break;
                    }
                }
                if (num4 > -1)
                {
                    break;
                }
            }
            PixelFormat pixelFormat = bmp.PixelFormat;
            Rectangle rect = new Rectangle(x, y, (num4 - x) + 1, (num2 - y) + 1);
            return bmp.Clone(rect, pixelFormat);
        }
        public static string HeDuiGetCookie_GetNum(Bitmap bmp)
        {
            int num3;
            int num4;
            PixelFormat pixelFormat = bmp.PixelFormat;
            int g = bmp.GetPixel(0, 0).G;
            int num2 = bmp.GetPixel(bmp.Width - 1, 0).G;
            if ((g < 130) && (num2 < 130))
            {
                num3 = 0;
                for (num4 = 0; num4 < bmp.Width; num4++)
                {
                    if (bmp.GetPixel(num4, bmp.Height - 1).G < 130)
                    {
                        num3++;
                    }
                }
                if (num3 < 4)
                {
                    return "7";
                }
                return "5";
            }
            g = bmp.GetPixel(0, bmp.Height - 1).G;
            num2 = bmp.GetPixel(bmp.Width - 1, bmp.Height - 1).G;
            if ((g < 130) && (num2 < 130))
            {
                num3 = 0;
                for (num4 = 0; num4 < bmp.Width; num4++)
                {
                    if (bmp.GetPixel(num4, 0).G < 130)
                    {
                        num3++;
                    }
                }
                if (num3 < 5)
                {
                    return "1";
                }
                return "2";
            }
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            for (num4 = 0; num4 < bmp.Height; num4++)
            {
                if (bmp.GetPixel(bmp.Width - 2, num4).G < 130)
                {
                    num5++;
                }
                if (bmp.GetPixel(bmp.Width - 3, num4).G < 130)
                {
                    num6++;
                }
                if (bmp.GetPixel(bmp.Width - 4, num4).G < 130)
                {
                    num7++;
                }
                if (bmp.GetPixel(bmp.Width - 5, num4).G < 130)
                {
                    num8++;
                }
            }
            if ((((num5 == bmp.Height) || (num6 == bmp.Height)) || (num7 == bmp.Height)) || (num8 == bmp.Height))
            {
                return "4";
            }
            num3 = 0;
            int y = bmp.Height / 2;
            int x = bmp.Width / 2;
            if (bmp.GetPixel(x, y).G < 130)
            {
                num3++;
            }
            if (bmp.GetPixel(x, y - 1).G < 130)
            {
                num3++;
            }
            if (bmp.GetPixel(x, y - 2).G < 130)
            {
                num3++;
            }
            if (bmp.GetPixel(x, y + 1).G < 130)
            {
                num3++;
            }
            if (bmp.GetPixel(x, y + 2).G < 130)
            {
                num3++;
            }
            if (num3 < 1)
            {
                return "0";
            }
            num3 = 0;
            y = bmp.Height / 2;
            x = 0;
            if (bmp.GetPixel(x, y).G < 130)
            {
                num3++;
            }
            if (bmp.GetPixel(x, y - 1).G < 130)
            {
                num3++;
            }
            if (bmp.GetPixel(x, y - 2).G < 130)
            {
                num3++;
            }
            if (bmp.GetPixel(x, y + 1).G < 130)
            {
                num3++;
            }
            if (bmp.GetPixel(x, y + 2).G < 130)
            {
                num3++;
            }
            if (num3 < 1)
            {
                return "3";
            }
            num3 = 0;
            y = (bmp.Height / 3) - 1;
            x = bmp.Width;
            if (bmp.GetPixel(x - 1, y).G < 130)
            {
                num3++;
            }
            if (bmp.GetPixel(x - 2, y).G < 130)
            {
                num3++;
            }
            if (bmp.GetPixel(x - 3, y).G < 130)
            {
                num3++;
            }
            if (bmp.GetPixel(x - 4, y).G < 130)
            {
                num3++;
            }
            if (num3 < 1)
            {
                return "6";
            }
            num3 = 0;
            y = ((bmp.Height / 3) * 2) + 1;
            x = 0;
            if (bmp.GetPixel(x, y).G < 130)
            {
                num3++;
            }
            if (bmp.GetPixel(x + 1, y).G < 130)
            {
                num3++;
            }
            if (bmp.GetPixel(x + 2, y).G < 130)
            {
                num3++;
            }
            if (bmp.GetPixel(x + 3, y).G < 130)
            {
                num3++;
            }
            if (num3 < 1)
            {
                return "9";
            }
            return "8";
        }
        public string HeDuiGetCookieInfoGetNum(Bitmap bmp, int n)
        {
            string s = "";
            int numtop = 0;
            int numbutom = 0;
            for (int i = 0; i < 10; i++)
            {
                if (bmp.GetPixel(i, 0).R < 130) numtop++;
                if (bmp.GetPixel(i, 12).R < 130) numbutom++;
            }
            if ((numtop == 5) && (numbutom == 8))
            {
                return "2";
            }
            if ((numtop == 8) && (numbutom == 2))
            {
                return "7";
            }
            if ((numtop == 3) && (numbutom == 3))
            {
                return "0";
            }
            if ((numtop == 5) && (numbutom == 5))
            {

                if (bmp.GetPixel(0, 2).R < 120)
                {
                    return "3";
                }

                return "8";
            }
            if ((numtop == 4) && (numbutom == 4))
            {
                if (bmp.GetPixel(0, 7).R < 120)
                {
                    return "6";
                }

                return "9";
            }
            if ((numtop == 8) && (numbutom == 5))
            {
                return "5";
            }
            if ((numtop == 2) && (numbutom == 2))
            {
                return "4";
            }
            if ((numtop == 3) && (numbutom > 6))
            {
                return "1";
            }
            return "0";


        }
        private static string getcookie(CookieCollection cookies)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Cookie cookie in cookies)
            {
                if (sb.Length > 0)
                    sb.Append(";");
                sb.Append(cookie.Name + "=" + cookie.Value);
            }

            return sb.ToString();

        }
        private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        public static string ToUnicode(string srcText)
        {
            string s;
            while (srcText.Contains("&#"))
            {
                s = substring(srcText, "&#", ";");
                srcText = srcText.Replace("&#" + s + ";", ((char)int.Parse(s)).ToString());

            }
            return srcText;
        }
        public static string substring(string s1, string s2, string s3)
        {
            int p1 = 0;
            int p2 = 0;
            try
            {
                p1 = s1.IndexOf(s2);
                p2 = s1.IndexOf(s3, p1 + s2.Length);
                if (p1 < 0)
                    return null;
                if (p2 < 0)
                    return null;
                if (p2 < p1)
                    return null;
                return s1.Substring(p1 + s2.Length, p2 - p1 - s2.Length);
            }
            catch (Exception)
            {
                return null;
            }

        }
        public static string substring2(string s1, string s2, string s3)
        {
            int p1 = 0;
            int p2 = 0;
            try
            {
                p1 = s1.IndexOf(s2);
                p2 = s1.IndexOf(s3, p1);
                if (p1 < 0)
                    return null;
                if (p2 < 0)
                    return null;
                if (p2 < p1)
                    return null;
                return s1.Substring(p2 + s3.Length, s1.Length - p2 - s3.Length);
            }
            catch
            {
                return null;
            }

        }
        #endregion
    }

    public class BetAccountOrderHistory
    {
        public Betaccount account { get; set; }
        public List<DateTime> date { get; set; }
        public Dictionary<string, Orderotherhistory> OrderOtherHistorys { get; set; }

        public BetAccountOrderHistory(Betaccount account, List<DateTime> date, Dictionary<string, Orderotherhistory> OrderOtherHistorys)
        {
            this.account = account;
            this.date = date;
            this.OrderOtherHistorys = OrderOtherHistorys;
        }
    }
}
