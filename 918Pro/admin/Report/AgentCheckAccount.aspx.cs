using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
//using System.Web.UI.WebControls;
using Model;
using System.Net;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.IO;
using System.IO.Compression;
using DAL;
using Model;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;


namespace admin.Report
{
    public partial class AgentCheckAccount : PageBase
    {
        //public class AgentAccount
        //{
        //    public String Name { get; set; }
        //    public String Password { get; set; }
        //    public String Cookie { get; set; }
        //    private String WebAgentAddress;

        //    public String Address2
        //    {
        //        get { return WebAgentAddress; }
        //        set { WebAgentAddress = value; }
        //    }

        //    public AgentAccount(string webAgentUserName, string webAgentPassword)
        //    {
        //        this.Name = webAgentUserName;
        //        this.Password = webAgentPassword;
        //    }
        //}

        public class BetAccountOrderHistory
        {
            public IList<Betaccount> account { get; set; }
            public DateTime startTime { get; set; }
            public DateTime endTime { get; set; }
            public Dictionary<string, Orderotherhistory> OrderOtherHistorys { get; set; }
            public AgentAccount agent { get; set; }

            public BetAccountOrderHistory(IList<Betaccount> account, DateTime startTime, DateTime endTime, Dictionary<string, Orderotherhistory> OrderOtherHistorys, AgentAccount agent)
            {
                this.account = account;
                this.startTime = startTime;
                this.endTime = endTime;
                this.OrderOtherHistorys = OrderOtherHistorys;
                this.agent = agent;
            }
        }

        public class BetAccountOrderMoney
        {
            //会员帐号
            public String WebUserName { get; set; }
            private String WebOrderCustId;

            public String WebOrderCustId1
            {
                get { return WebOrderCustId; }
                set { WebOrderCustId = value; }
            }

            //会员所属代理
            public String WebAgentName { get; set; }

            //会员注单数量（数据库）
            public Int32 OwnerOrderCount { get; set; }

            //会员投注总金额（数据库）
            public Decimal OwnerTotalBetMoney { get; set; }

            //会员输赢总金额（数据库）
            public Decimal OwnerResultMoney { get; set; }

            //会员注单数量（网站）
            public Int32 WebsiteOrderCount { get; set; }

            //会员投注总金额（网站）
            public Decimal WebsiteTotalBetMoney { get; set; }

            //会员输赢总金额（网站）
            public Decimal WebsiteResultMoney { get; set; }

            //是否有错误的注单
            public Int32 IsErrorData { get; set; }

            public String AccountAddress { get; set; }
        }

        public class pub
        {
            // 随机获得字典订单编号
            public static string GetRandomOrderId()
            {
                Random rand = new Random();
                string orderId = string.Empty;
                int count = 0;
                while (true)
                {
                    orderId = rand.Next(1, 1000000).ToString();
                    foreach (KeyValuePair<string, Dictionary<string, Orderotherhistory>> key in finalDetailDic)
                    {
                        if (!key.Value.ContainsKey(orderId))
                            count++;
                    }
                    if (count == finalDetailDic.Count)
                        break;
                }
                return orderId;
            }
            public static string GetCookie(CookieCollection cookies)
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
                catch (Exception ee)
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
            public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                return true;
            }
            /*liji验证码   */
            public static void changeColorToGray(Bitmap bitmap)
            {
                int width = bitmap.Size.Width;
                int height = bitmap.Size.Height;
                int red = 0;
                int green = 0;
                int blue = 0;
                int avg = 0;
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        red = bitmap.GetPixel(i, j).R;
                        green = bitmap.GetPixel(i, j).G;
                        blue = bitmap.GetPixel(i, j).B;
                        avg = (red + green + blue) / 3;
                        bitmap.SetPixel(i, j, Color.FromArgb(avg, avg, avg));
                    }
                }
            }
            //变成黑白图片
            public static void changeColorToBlack(Bitmap bitmap)
            {
                int width = bitmap.Size.Width;
                int height = bitmap.Size.Height;
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (bitmap.GetPixel(i, j).R < 200)
                        {
                            bitmap.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                        }
                        else
                        {
                            bitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                        }
                    }
                }
            }
            //判断数字
            public static string returnValidaCode(Bitmap bitmap)
            {
                int topNum = getNum2(bitmap, 0);
                int butNum = getNum2(bitmap, 15);
                if (topNum == 11)
                {
                    return "7";
                }
                if (topNum >= 8)
                {
                    return "5";
                }
                if (topNum == 2)
                {
                    if (bitmap.GetPixel(4, 11).R == 0)
                    {
                        return "4";
                    }
                    return "1";
                }
                if (topNum == 3)
                {
                    return "4";
                }
                if (butNum >= 10)
                {
                    return "2";
                }
                if (bitmap.GetPixel(1, 10).R == 255)
                {
                    if (bitmap.GetPixel(5, 7).R == 0)
                    {
                        return "3";
                    }
                    if (bitmap.GetPixel(5, 9).R == 0)
                    {
                        return "9";
                    }
                }
                if (bitmap.GetPixel(5, 7).R == 0)
                {
                    return "8";
                }
                if (bitmap.GetPixel(10, 5).R == 255)
                {
                    return "6";
                }
                return "0";
            }
            public static int getNum2(Bitmap bitmap, int vh)
            {
                int num = 0;
                int width = bitmap.Size.Width;
                for (int i = 0; i < width; i++)
                {
                    if (bitmap.GetPixel(i, vh).R == 0) num++;
                }
                return num;
            }

            /*shaba验证码*/
            public static string getcode(Bitmap bitmap)
            {
                int x = 0, y = 0;
                x = getNumX(bitmap);
                y = getNumY(bitmap);
                string code = "";
                PixelFormat pixelFormat = bitmap.PixelFormat;
                Rectangle rect = new Rectangle(x, y, 9, 11);
                Bitmap map = bitmap.Clone(rect, pixelFormat);
                code += getCode(map);
                x = x + 10;
                rect = new Rectangle(x, y, 9, 11);
                map = bitmap.Clone(rect, pixelFormat);
                code += getCode(map);
                x = x + 10;
                rect = new Rectangle(x, y, 9, 11);
                map = bitmap.Clone(rect, pixelFormat);
                code += getCode(map);
                x = x + 10;
                rect = new Rectangle(x, y, 9, 11);
                map = bitmap.Clone(rect, pixelFormat);
                code += getCode(map);
                map.Dispose();
                return code;
            }
            public static string getCode(Bitmap bitmap)
            {
                int topNum = getNum3(bitmap, 0);
                int butNum = getNum3(bitmap, 10);
                if (topNum >= 7)
                {
                    if (butNum <= 2)
                    {
                        return "7";
                    }
                    return "5";
                }
                if (butNum >= 8)
                {
                    return "2";
                }
                if (topNum <= 2)
                {
                    if (butNum <= 2 && getNum3(bitmap, 7) >= 3)
                    {
                        return "4";
                    }
                    else
                    {
                        return "1";
                    }
                }
                if (topNum == 6)
                {
                    return "3";
                }
                if (topNum <= 5)
                {
                    if (butNum <= 6 && getNum3(bitmap, 3) <= 2 && getNum3(bitmap, 4) <= 2 && getNum3(bitmap, 5) <= 4 && getNum3(bitmap, 6) <= 2 && getNum4(bitmap, 3) == 2)
                    {
                        return "3";
                    }
                    if (butNum <= 5 && getNum3(bitmap, 3) >= 3 && getNum3(bitmap, 5) >= 4 && getNum3(bitmap, 4) >= 3 && getNum3(bitmap, 6) <= 4 && getNum4(bitmap, 2) >= 5)
                    {
                        return "8";
                    }
                    if (butNum <= 5 && getNum3(bitmap, 3) <= 2 && getNum3(bitmap, 4) >= 6 && getNum3(bitmap, 5) <= 4)
                    {
                        return "6";
                    }
                    if (butNum <= 5 && getNum3(bitmap, 6) >= 5)
                    {
                        return "9";
                    }
                }
                return "0";
            }
            public static int getNum3(Bitmap bitmap, int vh)
            {
                int num = 0;
                int width = bitmap.Size.Width;
                for (int i = 0; i < width; i++)
                {
                    if (bitmap.GetPixel(i, vh).R == 105 && bitmap.GetPixel(i, vh).G == 105 && bitmap.GetPixel(i, vh).B == 105) num++;
                }
                return num;
            }
            public static int getNum4(Bitmap bitmap, int vh)
            {
                int num = 0;
                int height = bitmap.Size.Height;
                for (int i = 0; i < height; i++)
                {
                    if (bitmap.GetPixel(vh, i).R == 105 && bitmap.GetPixel(vh, i).G == 105 && bitmap.GetPixel(vh, i).B == 105) num++;
                }
                return num;
            }
            public static int getNumX(Bitmap bitmap)
            {
                int width = bitmap.Size.Width;
                int height = bitmap.Height;
                List<string> lo = new List<string>();
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        lo.Add(bitmap.GetPixel(i, j).R.ToString() + "," + bitmap.GetPixel(i, j).R.ToString() + "," + bitmap.GetPixel(i, j).B.ToString());
                        if (bitmap.GetPixel(i, j).R == 105 && bitmap.GetPixel(i, j).G == 105 && bitmap.GetPixel(i, j).B == 105)
                        {
                            return i;
                        }
                    }
                }
                return 0;
            }
            public static int getNumY(Bitmap bitmap)
            {
                int width = bitmap.Size.Width;
                int height = bitmap.Height;
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        if (bitmap.GetPixel(i, j).R == 105 && bitmap.GetPixel(i, j).G == 105 && bitmap.GetPixel(i, j).B == 105)
                        {
                            return j;
                        }
                    }
                }
                return 0;
            }


            /*  皇朝验证码*/
            public static string getValidaCode(Bitmap bitmap)
            {
                string code = null;
                changeColorToGray(bitmap);
                changeColorToBlack2(bitmap);
                PixelFormat pixlFormat = bitmap.PixelFormat;
                Rectangle rect = new Rectangle(6, 1, 12, 15);
                Bitmap map = bitmap.Clone(rect, pixlFormat);
                code += returnValidaCode2(map);
                rect = new Rectangle(19, 1, 12, 15);
                map = bitmap.Clone(rect, pixlFormat);
                code += returnValidaCode2(map);
                rect = new Rectangle(32, 1, 12, 15);
                map = bitmap.Clone(rect, pixlFormat);
                code += returnValidaCode2(map);
                rect = new Rectangle(45, 1, 12, 15);
                map = bitmap.Clone(rect, pixlFormat);
                code += returnValidaCode2(map);
                bitmap.Dispose();
                map.Dispose();
                return code;
            }
            //变成黑白图片
            public static void changeColorToBlack2(Bitmap bitmap)
            {
                int width = bitmap.Size.Width;
                int height = bitmap.Size.Height;
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (bitmap.GetPixel(i, j).R >= 147)
                        {
                            bitmap.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                        }
                        else
                        {
                            bitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                        }
                    }
                }
            }
            public static string returnValidaCode2(Bitmap bitmap)
            {
                int buttomNum = getNum(bitmap, 14);
                if (buttomNum == 2)
                {
                    if (bitmap.GetPixel(2, 10).R == 0)
                    {
                        return "4";
                    }
                    return "7";
                }
                if (buttomNum >= 8)
                {
                    if (bitmap.GetPixel(1, 12).R == 0 || bitmap.GetPixel(2, 12).R == 0)
                    {
                        return "2";
                    }
                    return "1";
                }
                if ((bitmap.GetPixel(1, 12).R == 0 && bitmap.GetPixel(2, 12).R == 255 && bitmap.GetPixel(1, 11).R == 255) || (bitmap.GetPixel(2, 12).R == 0 && bitmap.GetPixel(3, 12).R == 255 && bitmap.GetPixel(2, 11).R == 255))
                {
                    if (bitmap.GetPixel(2, 12).R == 0)
                    {
                        if (bitmap.GetPixel(2, 6).R == 255)
                        {
                            return "3";
                        }
                        if (bitmap.GetPixel(2, 6).R == 0 && bitmap.GetPixel(1, 5).R == 0)
                        {
                            return "9";
                        }
                        return "5";
                    }
                    else if (bitmap.GetPixel(1, 12).R == 0)
                    {
                        if (bitmap.GetPixel(1, 6).R == 255)
                        {
                            return "3";
                        }
                        if (bitmap.GetPixel(1, 6).R == 0 && bitmap.GetPixel(0, 5).R == 0)
                        {
                            return "9";
                        }
                        return "5";
                    }
                }
                if (buttomNum >= 5)
                {
                    return "8";
                }
                if (bitmap.GetPixel(6, 7).R == 0 || bitmap.GetPixel(6, 6).R == 0)
                {
                    return "6";
                }
                return "0";
            }
            public static int getNum(Bitmap bitmap, int vh)
            {
                int num = 0;
                int width = bitmap.Size.Width;
                for (int i = 0; i < width; i++)
                {
                    if (bitmap.GetPixel(i, vh).R == 0) num++;
                }
                return num;
            }

            public static DateTime getTime(string s)
            {
                DateTime time = Convert.ToDateTime(s);
                string Ttime = string.Format("{0:s}", time);//"yyyy-MM-dd HH:MM:SS"
                return Convert.ToDateTime(Ttime.Replace("T", " "));
            }
            //判断是不是字符串中有没有数字
            public static int number(string str)
            {
                int ret = 0;
                Regex rex = new Regex("[0-9+-]");
                Match ma = rex.Match(str);
                if (ma.Success)
                {
                    ret = 1;
                }
                return ret;
            }
        }

        //存储全局的所有帐号的统计信息
        public static Dictionary<string, BetAccountOrderMoney> finalStatsDic = new Dictionary<string, BetAccountOrderMoney>();
        //存储全局的最终的错误注单信息
        public static Dictionary<string, Dictionary<string, Orderotherhistory>> finalDetailDic = new Dictionary<string, Dictionary<string, Orderotherhistory>>();

        protected bool viewAc = true;  //查看
        protected bool selectAc = true;
        protected bool excelAc = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            //-----------权限控制开始-----------
            //当前角色
            int Rid = CurrentManager.RoleId;

            BLL.Sys_role_rightManager rrService = new BLL.Sys_role_rightManager();

            //查看权限
            if (!rrService.IsPermission(Rid, 201))
            {
                viewAc = false;
                Response.Write("<script>alert('非法操作，请返回!');history.go(-1);</script>");
                Response.End();
            }
            //查看权限
            if (!rrService.IsPermission(Rid, 216))
            {
                selectAc = false;
            }
            //导出Excel
            if (!rrService.IsPermission(Rid, 217))
            {
                excelAc = false;
            }

            //-----------权限控制结束-----------
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
            page.Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName + System.DateTime.Now.ToString("_yyMMdd_hhmm") + ".xls");
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

        //格式化帐号列表统计，返回json格式字符串
        private static string FormatStats(Dictionary<string, BetAccountOrderMoney> betAccountOrderMoneys)
        {
            int i = 0;
            if (betAccountOrderMoneys.Count <= 0) return string.Empty;
            StringBuilder jsonString = new StringBuilder();
            jsonString.Append("[");
            //loop through all values
            foreach (BetAccountOrderMoney betAccountOrderMoney in betAccountOrderMoneys.Values)
            {
                jsonString.Append("{");
                jsonString.Append("\"ID\":\"" + (++i) + "\",");
                jsonString.Append("\"WebAgentName\":\"" + betAccountOrderMoney.WebAgentName + "\",");
                jsonString.Append("\"WebUserName\":\"" + betAccountOrderMoney.WebUserName + "\",");
                jsonString.Append("\"OwnerOrderCount\":\"" + betAccountOrderMoney.OwnerOrderCount + "\",");
                jsonString.Append("\"WebsiteOrderCount\":\"" + betAccountOrderMoney.WebsiteOrderCount + "\",");
                jsonString.Append("\"OwnerTotalBetMoney\":\"" + betAccountOrderMoney.OwnerTotalBetMoney + "\",");
                jsonString.Append("\"WebsiteTotalBetMoney\":\"" + betAccountOrderMoney.WebsiteTotalBetMoney + "\",");
                jsonString.Append("\"OwnerResultMoney\":\"" + betAccountOrderMoney.OwnerResultMoney + "\",");
                jsonString.Append("\"WebsiteResultMoney\":\"" + betAccountOrderMoney.WebsiteResultMoney + "\",");
                jsonString.Append("\"IsErrorData\":\"" + betAccountOrderMoney.IsErrorData + "\"");
                jsonString.Append("},");
            }
            if (jsonString.Length > 1)
            {
                jsonString.Remove(jsonString.Length - 1, 1);
            }
            jsonString.Append("]");
            return jsonString.ToString();
        }
        //格式化注单列表统计，返回json格式字符串
        private static string FormatDetail(Dictionary<string, Orderotherhistory> orderOthersHistory)
        {
            int i = 0;
            if (orderOthersHistory.Count <= 0) return string.Empty;
            StringBuilder jsonString = new StringBuilder();
            jsonString.Append("[");
            //loop through all values
            foreach (Orderotherhistory orderOther in orderOthersHistory.Values)
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
                jsonString.Append("\"Status\":\"" + orderOther.Status + "\",");
                jsonString.Append("\"Score\":\"" + orderOther.Score + "\",");
                jsonString.Append("\"Result\":\"" + orderOther.Result + "\",");
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

        //webservice调用单个帐号错误订单详细信息
        public static string GetSingAccountDetail(string accountName)
        {
            string result = string.Empty;
            try
            {
                if (finalDetailDic.ContainsKey(accountName))
                {
                    Dictionary<string, Orderotherhistory> dic = finalDetailDic[accountName];
                    result = FormatDetail(dic);
                }
            }
            catch (Exception)
            {
                return "[]";
            }
            return result;
        }
        //webservice嗲用匹配所有错误帐号的注单信息
        public static string ReadHistoryReport(string casino, string startTime, string endTime, IList<AgentAccount> agents)
        {
            try
            {
                finalStatsDic.Clear();
                finalDetailDic.Clear();
                IList<Betaccount> allAccounts = new List<Betaccount>();
                ////根据网站查找出所有的帐号
                AccountService accounts = new AccountService();
                allAccounts = accounts.GetBetAccount(casino);
                Dictionary<string, Orderotherhistory> orderHistorys = new Dictionary<string, Orderotherhistory>();
                ////根据网站查找出所有的帐号的外调注单
                startTime = startTime == "" ? startTime = endTime : startTime;
                endTime = endTime == "" ? endTime = startTime : endTime;
                orderHistorys = accounts.GetOrderListByWebsiteID(casino, startTime, endTime);
                string agentCookie = string.Empty;
                foreach (AgentAccount agent in agents)
                {
                    BetAccountOrderHistory betAccountOrderHistory = new BetAccountOrderHistory(allAccounts, Convert.ToDateTime(startTime), Convert.ToDateTime(endTime), orderHistorys, agent);
                    switch (casino)
                    {
                        case "1":
                            HuangGuanLogin(agent);
                            HuangGuanCheckHistoryReport(betAccountOrderHistory);
                            break;
                        case "2":
                            LiJiLogin(agent);
                            LiJiHistoryReport(betAccountOrderHistory);
                            break;
                        case "3":
                            ShaBaLogin(agent);
                            ShaBaHistoryReport(betAccountOrderHistory);
                            break;
                        case "4":
                            break;
                        case "5":
                            ylgLogin(agent);
                            YongLiGaoHistoryReport(betAccountOrderHistory);
                            break;
                        case "6":
                            MMMLogin(agent);
                            MMMCheckHistoryReport(betAccountOrderHistory);
                            break;
                            
                        case "7":
                            Bw3388Login(agent);
                            Bw3388CheckHistoryReport(betAccountOrderHistory);
                            break;
                        case "8":
                            HuangChaoLogin(agent);
                            HuangChaoHistoryReport(betAccountOrderHistory);
                            break;
                    }
                }
            }
            catch (Exception)
            {
                return "";
            }
            return FormatStats(finalStatsDic);
        }
        //MMM登陆
        private static void MMMLogin(AgentAccount agent)
        {
            
            Encoding utf8 = Encoding.UTF8;
            CookieContainer cookies = new CookieContainer();
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            string url = string.Empty;
            string yzmurl = string.Empty;
            string cookiestr = string.Empty;
            string code = string.Empty;
            int count = 0;
            string html = string.Empty;
            string nextUrl = string.Empty;
            string bytestr = string.Empty;
            byte[] bytes;
            Image img;
           
            string _VIEWSTATE = string.Empty;
            
        label20:
            url = "http://" +agent.Address + "/";
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/vnd.ms-xpsdocument, */*";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; InfoPath.3; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                request.KeepAlive = true;
                request.Method = "GET";
                request.CookieContainer = cookies;
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
                if (!html.Contains("__VIEWSTATE"))
                {
                    if (count < 10)
                    {
                        count++;
                        System.Console.WriteLine("获取登录页失败,1秒后重新登录...");
                        Thread.Sleep(1000);
                        goto label20;
                    }
                    else
                    {
                        Console.WriteLine("获取登录页失败次数超过10次退出");
                        return;
                    }
                }
                else
                {
                   
                    _VIEWSTATE = pub.substring(html, "__VIEWSTATE\" value=", "/>").Replace("\"", "").Replace("/", "%2F").Replace("+", "%2B").Replace("=", "%3D").Replace(" ", "").Trim();
                    
                }
            }
            catch (Exception e)
            {
                if (count < 10)
                {
                    count++;
                    goto label20;
                }
                else
                {
                    return;
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
                    if (stream != null)
                        stream.Close();
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
                yzmurl = url + "public/img.aspx";
                request = (HttpWebRequest)WebRequest.Create(yzmurl);
                request.Method = "GET";
                request.Accept = "*/*";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; InfoPath.3; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                request.KeepAlive = true;
                request.AllowAutoRedirect = false;
                request.CookieContainer = cookies;
                response = (HttpWebResponse)request.GetResponse();
                if (response.Headers.Get("Content-Encoding") != null)
                {
                    stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    img = Image.FromStream(stream);
                }
                else
                {
                    img = Image.FromStream(response.GetResponseStream());
                }
                //string code = MMMLoginValiCode.getCode_3M(img);
                code = string.Empty;
                Bitmap bitmap = new Bitmap(img);
                PixelFormat pixlFormat = bitmap.PixelFormat;
                Rectangle rect = new Rectangle(3, 3, 10, 15);
                Bitmap map = bitmap.Clone(rect, pixlFormat);
                code = GetCookieInfoGetNum3m(map);
                rect = new Rectangle(14, 3, 10, 15);
                map = bitmap.Clone(rect, pixlFormat);
                code += GetCookieInfoGetNum3m(map);
                rect = new Rectangle(25, 3, 10, 15);
                map = bitmap.Clone(rect, pixlFormat);
                code += GetCookieInfoGetNum3m(map);
                rect = new Rectangle(36, 3, 10, 15);
                map = bitmap.Clone(rect, pixlFormat);
                code += GetCookieInfoGetNum3m(map);
            }
            catch (Exception ex)
            {
                if (count < 10)
                {
                    count++;
                    goto label20;
                }
                else
                {
                    return;
                }
            }
            finally
            {
                try
                {
                    if (stream != null)
                        stream.Close();
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

                bytestr = "__VIEWSTATE=" + _VIEWSTATE + "&txtUserName=" + agent.Name + "&txtPassword=" + agent.Password + "&txtCode=" + code + "&btnSignIn.x=42&btnSignIn.y=11";
                bytes = Encoding.ASCII.GetBytes(bytestr);
                request = (HttpWebRequest)WebRequest.Create(url + "Default.aspx");
                request.Method = "POST";
                request.Referer = "http://www.333456.net/";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/vnd.ms-xpsdocument, */*";
                request.Headers.Add("Accept-Language", "zh-cn");
                request.Headers.Add("UA-CPU", "x86");
                request.Headers.Add("Cache-Control", "no-cache");
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; InfoPath.3; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                request.ContentLength = bytes.Length;
                request.KeepAlive = true;
                request.CookieContainer = cookies;
                request.AllowAutoRedirect = false;
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
                if (!html.Contains(url + "Alert.aspx?lang=eng"))
                {
                    if (count < 10)
                    {
                        count++;
                        goto label20;
                    }
                    else
                    {
                        return;
                    }
                }
                   
               
            }
            catch (Exception ex)
            {
                if (count < 10)
                {
                    count++;
                    goto label20;
                }
                else
                {
                    return;
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
                    if (stream != null)
                        stream.Close();
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
                request = (HttpWebRequest)WebRequest.Create(url + "Alert.aspx?lang=eng");
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/vnd.ms-xpsdocument, */*";
                request.Referer = "http://www.333456.net/";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; InfoPath.3; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                request.KeepAlive = true;
                request.CookieContainer = cookies;
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
                
            }
            catch (Exception e)
            {
                if (count < 10)
                {
                    count++;
                    goto label20;
                }
                else
                {
                    return;
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
                    if (stream != null)
                        stream.Close();
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
                request = (HttpWebRequest)WebRequest.Create(url + "main.aspx?lang=gb");
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/vnd.ms-xpsdocument, */*";
                request.Referer = "http://www.333456.net/";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; InfoPath.3; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                request.KeepAlive = true;
                request.CookieContainer = cookies;
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
                
            }
            catch (Exception e)
            {
                if (count < 10)
                {
                    count++;
                    goto label20;
                }
                else
                {
                    return;
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
                    if (stream != null)
                        stream.Close();
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
                request = (HttpWebRequest)WebRequest.Create(url + "_Age/Menu.aspx?id=account");
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/vnd.ms-xpsdocument, */*";
                request.Referer = "http://www.333456.net/";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; InfoPath.3; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                request.KeepAlive = true;
                request.CookieContainer = cookies;
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

            }
            catch (Exception e)
            {
                if (count < 10)
                {
                    count++;
                    goto label20;
                }
                else
                {
                    return;
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
                    if (stream != null)
                        stream.Close();
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
                request = (HttpWebRequest)WebRequest.Create(url + "accinfo.aspx");
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/vnd.ms-xpsdocument, */*";
                request.Referer = "http://www.333456.net/";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; InfoPath.3; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                request.KeepAlive = true;
                request.CookieContainer = cookies;
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

            }
            catch (Exception e)
            {
                if (count < 10)
                {
                    count++;
                    goto label20;
                }
                else
                {
                    return;
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
                    if (stream != null)
                        stream.Close();
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
                request = (HttpWebRequest)WebRequest.Create(url + "_Age/menu_c.aspx");
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/vnd.ms-xpsdocument, */*";
                request.Referer = "http://www.333456.net/";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; InfoPath.3; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                request.KeepAlive = true;
                request.CookieContainer = cookies;
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

            }
            catch (Exception e)
            {
                if (count < 10)
                {
                    count++;
                    goto label20;
                }
                else
                {
                    return;
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
                    if (stream != null)
                        stream.Close();
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
                request = (HttpWebRequest)WebRequest.Create(url + "AccHistory.aspx");
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/vnd.ms-xpsdocument, */*";
                request.Referer = "http://www.333456.net/";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; InfoPath.3; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                request.KeepAlive = true;
                request.CookieContainer = cookies;
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

            }
            catch (Exception e)
            {
                if (count < 10)
                {
                    count++;
                    goto label20;
                }
                else
                {
                    return;
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
                    if (stream != null)
                        stream.Close();
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
                request = (HttpWebRequest)WebRequest.Create(url + "AccHistory.aspx?role=ag&userName=" + agent.AgentName);
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/vnd.ms-xpsdocument, */*";
                request.Referer = "http://www.333456.net/";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; InfoPath.3; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                request.KeepAlive = true;
                request.CookieContainer = cookies;
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
               
            }
            catch (Exception e)
            {
                if (count < 10)
                {
                    count++;
                    goto label20;
                }
                else
                {
                    return;
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
                    if (stream != null)
                        stream.Close();
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
            agent.Cookie = pub.GetCookie(cookies.GetCookies(new Uri(url + "AccHistory.aspx")));
  
        }
        private static void MMMCheckHistoryReport(BetAccountOrderHistory betAccountOrderHistory)
        {

            Encoding utf8 = Encoding.UTF8;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            int count = 0;
            string nextPageUrl = string.Empty;
            string content = string.Empty;
            string tr = string.Empty;
            string td = string.Empty;
            string postdata = string.Empty;
            string urlstr = string.Empty;
            string url = "http://" + betAccountOrderHistory.agent.Address + "/";
            //string startday = Convert.ToDateTime(betAccountOrderHistory.startTime).ToString("MM/dd/yyyy");
            //string endday = Convert.ToDateTime(betAccountOrderHistory.endTime).ToString("MM/dd/yyyy");
            //TimeSpan t = Convert.ToDateTime(endday).Subtract(Convert.ToDateTime(startday));
            //int m=t.Days + 1;
            string[] sar;
            //我们数据库的订单
            Dictionary<string, Orderotherhistory> dicOwner = new Dictionary<string, Orderotherhistory>();
            //代理网站的订单
            Dictionary<string, Orderotherhistory> dicAgent = new Dictionary<string, Orderotherhistory>();

        label20:

            try
            {
                request = (HttpWebRequest)WebRequest.Create(url + "SubAccsSummary.aspx?role=ag&userName=" + betAccountOrderHistory.agent.AgentName + "&to=" + Convert.ToDateTime(betAccountOrderHistory.endTime).ToString("MM/dd/yyyy") + "&from=" + Convert.ToDateTime(betAccountOrderHistory.startTime).ToString("MM/dd/yyyy"));
                //request = (HttpWebRequest)WebRequest.Create(url + "SubAccsSummary.aspx?role=ag&userName=" + betAccountOrderHistory.agent.AgentName + "&to=" + Convert.ToDateTime(startday).AddDays(i).ToString("MM/dd/yyyy") + "&from=" + Convert.ToDateTime(startday).AddDays(i).ToString("MM/dd/yyyy"));
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/vnd.ms-xpsdocument, */*";
                request.Referer = "http://www.333456.net/";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; InfoPath.3; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                request.KeepAlive = true;
                request.Headers["Cookie"] = betAccountOrderHistory.agent.Cookie;
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
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                if (count < 10)
                {
                    count++;
                    goto label20;
                }
                else
                {
                    return;
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
                request = (HttpWebRequest)WebRequest.Create(url + "_Age_Sub/SubAccsSummary.aspx?role=ag&userName=" + betAccountOrderHistory.agent.AgentName + "&to=" + Convert.ToDateTime(betAccountOrderHistory.endTime).ToString("MM/dd/yyyy") + "&from=" + Convert.ToDateTime(betAccountOrderHistory.startTime).ToString("MM/dd/yyyy"));
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/vnd.ms-xpsdocument, */*";
                request.Referer = "http://www.333456.net/";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; InfoPath.3; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                request.KeepAlive = true;
                request.Headers["Cookie"] = betAccountOrderHistory.agent.Cookie;
                request.AllowAutoRedirect = true;
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
                if (content.Contains("_btnAcc"))
                {

                    foreach (Betaccount account in betAccountOrderHistory.account)
                    {
                        try
                        {
                            if (content.Contains(account.Userid))
                            {
                                BetAccountOrderMoney betAccountOrderMoney = new BetAccountOrderMoney();
                                betAccountOrderMoney.WebAgentName = account.Agent;
                                betAccountOrderMoney.WebUserName = account.Userid;
                                betAccountOrderMoney.OwnerOrderCount = betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == betAccountOrderMoney.WebUserName).Count();
                                betAccountOrderMoney.OwnerTotalBetMoney = betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == betAccountOrderMoney.WebUserName).Select(n => n.Value.Amount).Sum();
                                betAccountOrderMoney.OwnerResultMoney = betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == betAccountOrderMoney.WebUserName).Select(n => n.Value.Result).Sum();
                                tr = pub.substring(content, account.Userid, "</tr>");
                                betAccountOrderMoney.AccountAddress = account.Userid;
                                sar = tr.Split(new string[] { "/td>" }, StringSplitOptions.None);
                                //betAccountOrderMoney.WebsiteOrderCount = Convert.ToInt32(pub.substring(sar[1], "positive'>", "<"));
                                betAccountOrderMoney.WebsiteTotalBetMoney = Convert.ToDecimal(pub.substring(sar[1], "positive'>", "</SPAN>"));
                                betAccountOrderMoney.WebsiteResultMoney = Convert.ToDecimal(pub.substring(sar[2], "tive'>", "</SPAN>"));
                                finalStatsDic.Add(betAccountOrderMoney.WebUserName, betAccountOrderMoney);

                            }
                        }
                        catch
                        { }
                    }
                    foreach (KeyValuePair<string, BetAccountOrderMoney> item in finalStatsDic)
                    {
                        try
                        {
                            if (dicOwner == null)
                            {
                                dicOwner = new Dictionary<string, Orderotherhistory>();
                            }
                            else
                            {
                                dicOwner.Clear();
                            }
                            if (dicAgent == null)
                            {
                                dicAgent = new Dictionary<string, Orderotherhistory>();
                            }
                            else
                            {
                                dicAgent.Clear();
                            }
                            if (item.Value.WebAgentName == betAccountOrderHistory.agent.AgentName)
                            {
                                //我们数据库的订单
                                dicOwner = GetDicByAccount(item.Key, betAccountOrderHistory.OrderOtherHistorys);
                                if (!string.IsNullOrEmpty(item.Value.AccountAddress))
                                {
                                    //代理网站的订单
                                    dicAgent = MMMCheckHistoryReportDetails(betAccountOrderHistory, item.Value);
                                    Thread.Sleep(1000);
                                }
                                else
                                {
                                    if (betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == item.Key).Count() > 0)
                                    {
                                        Dictionary<string, Orderotherhistory> dic = null;
                                        foreach (KeyValuePair<string, Orderotherhistory> items in betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == item.Key).ToList())
                                        {
                                            dic = new Dictionary<string, Orderotherhistory>();
                                            dic.Add(items.Value.WebOrderID, items.Value);
                                        }
                                        finalDetailDic.Add(item.Key, dic);
                                    }
                                }
                                Dictionary<string, Orderotherhistory> dicTemp = new Dictionary<string, Orderotherhistory>();
                                try
                                {
                                    dicTemp = CheckError(dicOwner, dicAgent);
                                }
                                catch (Exception e)
                                { }
                                if (!finalDetailDic.ContainsKey(item.Key))
                                {
                                    if (dicTemp.Count > 0)
                                        finalDetailDic.Add(item.Key, dicTemp);
                                }
                            }
                        }
                        catch
                        { }
                    }
                    foreach (KeyValuePair<string, Dictionary<string, Orderotherhistory>> items in finalDetailDic)
                    {
                        finalStatsDic[items.Key].IsErrorData = items.Value.Count > 0 ? 1 : 0;
                    }
                }
                else
                {
                    if (count < 5)
                    {
                        count++;
                        goto label20;
                    }
                    else
                    {
                        return;
                    }
                }

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);

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


        }
        private static Dictionary<string, Orderotherhistory> MMMCheckHistoryReportDetails(BetAccountOrderHistory betAccountOrderHistory, BetAccountOrderMoney betAccountOrderMoney)
        {
            Dictionary<string, Orderotherhistory> dic = new Dictionary<string, Orderotherhistory>();
            Encoding utf8 = Encoding.UTF8;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            int count = 0;
            string nextPageUrl = string.Empty;
            string html = string.Empty;
            string type = string.Empty;
            string teamp = string.Empty;
            string postdata = string.Empty;
            string tzsj = string.Empty;
            string kssj = string.Empty;
            string url = "http://" + betAccountOrderHistory.agent.Address + "/";
            string handicap = string.Empty;
            string[] str2;
            string[] str3;
            //我们数据库的订单
            Dictionary<string, Orderotherhistory> dicOwner = new Dictionary<string, Orderotherhistory>();
            //代理网站的订单
            Dictionary<string, Orderotherhistory> dicAgent = new Dictionary<string, Orderotherhistory>();


        label20:
            try
            {

                request = (HttpWebRequest)WebRequest.Create(url + "_Age_Sub/SubAccsTrans.aspx?userName=" + betAccountOrderHistory.agent.AgentName + "&role=ag&userName2=" + betAccountOrderMoney.AccountAddress + "&to=" + Convert.ToDateTime(betAccountOrderHistory.endTime).ToString("MM/dd/yyyy") + "&from=" + Convert.ToDateTime(betAccountOrderHistory.startTime).ToString("MM/dd/yyyy"));
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/vnd.ms-xpsdocument, */*";
                request.Referer = "http://www.333456.net/";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; InfoPath.3; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                request.KeepAlive = true;
                request.Headers["Cookie"] = betAccountOrderHistory.agent.Cookie;
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
                if (html.Contains("Item\" align=\"Center"))
                {

                    str2 = html.Split(new string[] { "Item\" align=\"Center" }, StringSplitOptions.None);
                    betAccountOrderMoney.WebsiteOrderCount = str2.Length - 2;
                    for (int j = 1; j < str2.Length - 1; j++)
                    {
                        Orderotherhistory order1 = new Orderotherhistory();
                        try
                        {
                            str3 = str2[j].Split(new string[] { "<SPAN" }, StringSplitOptions.None);
                            order1.WebOrderID = pub.substring(str3[1], "class='bold'>", "</SPAN>");
                            tzsj = pub.substring(str3[1], "</SPAN><BR>", "m").Replace("a","").Replace("p","").Trim();
                            order1.Leaguetw = pub.substring(str3[2], "class='gb'>", "<br>");
                            order1.Hometw = pub.substring(str3[2], "<br>", "</SPAN>");
                            order1.Awaytw = pub.substring(str3[3], "class='gb'>", "</SPAN>");
                            kssj = pub.substring(str3[4], "class='bold'>", "</SPAN>");
                            order1.BetItem = pub.substring(str3[10], ">", "</SPAN>");
                            order1.Amount = decimal.Parse(pub.substring(str3[11], "> (1 x", "@").Replace(",", "").Replace(" ", ""));
                            order1.Handicap = pub.substring(str3[11], "</SPAN><BR>", "&nbsp;").Replace(" ", "");
                            order1.Odds = decimal.Parse(pub.substring(str3[12], ">", "</SPAN>").Replace(" ", ""));
                            order1.Result = decimal.Parse(pub.substring(str3[13], ">", "</SPAN>").Replace(" ", ""));
                            order1.ValidAmount = decimal.Parse(pub.substring(str3[12], "align=\"Right\">", "</td>").Replace(" ", "").Replace("/r", "").Replace("/n", ""));
                            if (order1.Handicap.Substring(1).Contains("-"))
                            {
                                order1.Handicap = ((Math.Abs(double.Parse(order1.Handicap.Substring(0, order1.Handicap.IndexOf("-")))) + double.Parse(order1.Handicap.Substring(order1.Handicap.IndexOf("-") + 1))) / 2).ToString();
                            }
                            if (order1.Handicap == "-0")
                            {
                                order1.Handicap = "0";
                            }
                            try
                            {
                                if (tzsj.Contains("p"))
                                {
                                    tzsj = tzsj.Replace("p", "").Trim();
                                    tzsj = tzsj.Substring(tzsj.IndexOf("/") + 1, 2) + "-" + tzsj.Substring(0, tzsj.IndexOf("/")) + tzsj.Substring(tzsj.IndexOf(" "));
                                    kssj = (kssj.Substring(kssj.IndexOf("/") + 1, 2) + "-" + kssj.Substring(0, kssj.IndexOf("/")));
                                    if (DateTime.Now.ToString("yyyy-MM").Substring(5, 1) == "0" && tzsj.Substring(0, 1) != "0")
                                    {
                                        order1.Time = Convert.ToDateTime(DateTime.Now.AddDays(-300).ToString("yyyy") + "-" + tzsj).AddHours(12);
                                        order1.BeginTime = Convert.ToDateTime(DateTime.Now.AddDays(-300).ToString("yyyy") + "-" + kssj);
                                    }
                                    else
                                    {
                                        order1.Time = Convert.ToDateTime(DateTime.Now.ToString("yyyy") + "-" + tzsj).AddHours(12);
                                        order1.BeginTime = Convert.ToDateTime(DateTime.Now.AddDays(-300).ToString("yyyy") + "-" + kssj);
                                    }
                                }
                                else
                                {
                                    tzsj = tzsj.Substring(tzsj.IndexOf("/") + 1, 2) + "-" + tzsj.Substring(0, tzsj.IndexOf("/")) + tzsj.Substring(tzsj.IndexOf(" "));

                                    kssj = (kssj.Substring(kssj.IndexOf("/") + 1, 2) + "-" + kssj.Substring(0, kssj.IndexOf("/")));
                                    if (DateTime.Now.ToString("yyyy-MM").Substring(5, 1) == "0" && tzsj.Substring(0, 1) != "0")
                                    {
                                        order1.Time = Convert.ToDateTime(DateTime.Now.AddDays(-300).ToString("yyyy") + "-" + tzsj);
                                        order1.BeginTime = Convert.ToDateTime(DateTime.Now.AddDays(-300).ToString("yyyy") + "-" + kssj);
                                    }
                                    else
                                    {
                                        order1.Time = Convert.ToDateTime(DateTime.Now.ToString("yyyy") + "-" + tzsj);
                                        order1.BeginTime = Convert.ToDateTime(DateTime.Now.AddDays(-300).ToString("yyyy") + "-" + kssj);
                                    }
                                }
                                if (order1.Awaytw.Contains("上半场"))
                                {
                                    order1.Scorehalf = pub.substring(str3[5], "Result :", "</SPAN>").Replace("-", ":").Replace(" ", "");
                                }
                                else
                                {
                                    order1.Score = pub.substring(str3[5], "Result :", "</SPAN>").Replace("-", ":").Replace(" ", "");
                                }
                                if (order1.Awaytw.Contains("(") && order1.Awaytw.Contains("-"))
                                {
                                    try
                                    {
                                        teamp = order1.Awaytw.Replace(" ", "").Replace("(", "").Replace(")", "");
                                        teamp = teamp.Substring(teamp.LastIndexOf("-") - 1).Replace("-", ":");
                                        if (int.Parse(teamp.Replace(":", "")) >= 0)
                                        {
                                            order1.Scoreathalf = teamp;
                                        }
                                    }
                                    catch
                                    { }
                                }
                            }
                            catch
                            { }
                            order1.UserName = betAccountOrderMoney.AccountAddress;
                           
                        }
                        catch (Exception e)
                        { }
                        try
                        {
                            if (order1.WebOrderID != null)
                            {
                                dic.Add(order1.WebOrderID, order1);
                            }
                            else
                            {
                                order1.ErrorMessage = "代理网站没有读取到注单号";
                                dic.Add(DateTime.Now.Ticks.ToString(), order1);
                            }
                        }
                        catch
                        { }
                    }
                }
                else
                {
                    if (count < 10)
                    {
                        count++;
                        goto label20;
                    }
                    else
                    {
                        return dic;
                    }
                }

            }
            catch (Exception e)
            {
                if (count < 10)
                {
                    count++;
                    goto label20;
                }
                else
                {
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
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }

            return dic;
        }
        // BW3388 历史查询核对
        private static string GetCookieInfoGetNum3m(Bitmap map)
        {
            if (getNum(map, 1) > 8)
            {
                return "7";
            }
            else if (getNum(map, 13) > 8)
            {
                return "2";
            }
            else if (getNum(map, 10) > 8 && getNum(map, 14) <= 2)
            {
                return "4";
            }
            else if (getNum(map, 1) > 6 && getNum(map, 13) > 5 && getNum(map, 6) > 5)
            {
                return "5";
            }
            else if (getNum(map, 6) > 7 && getNumY(map, 3) == 2 && getNumY(map, 4) == 1)
            {
                return "6";
            }
            else if (getNumY(map, 4) == 2 && getNumY(map, 9) == 2)
            {
                if (getNumX(map, 5) == 2)
                {
                    return "0";
                }
                else
                {
                    if (getNumY(map, 10) == 1)
                    {
                        return "9";
                    }
                    return "8";
                }
            }
            else if (getNum(map, 0) + getNum(map, 14) < 4)
            {
                if (getNumY(map, 7) == 2)
                {
                    return "4";
                }
                return "1";
            }
            else if (getNumY(map, 4) == 1 && getNumY(map, 9) == 1)
            {
                return "3";
            }
            return "X";
        }
        /// <summary>
        /// 指定的Y坐标与数字产生的焦点个数
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="vh"></param>
        /// <returns></returns>
        public static int getNumY(Bitmap bitmap, int vh)
        {
            int num = 0;
            int width = bitmap.Size.Width;
            for (int i = 0; i < width; i++)
            {
                if (bitmap.GetPixel(i, vh).B != 255)
                {
                    if (num == 0)
                    {
                        num = 1;
                    }
                    else
                    {
                        if (num == 1 && bitmap.GetPixel(i - 1, vh).B != 255)
                        {
                            num = 1;
                        }
                        else
                        {
                            if (bitmap.GetPixel(i - 1, vh).B != 255)
                            {

                            }
                            else
                            {
                                num++;
                            }
                        }
                    }
                }
            }
            return num;
        }
        /// <summary>
        /// 指定的X坐标与数字产生的焦点个数
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="vh"></param>
        /// <returns></returns>
        public static int getNumX(Bitmap bitmap, int vh)
        {
            int num = 0;
            int height = bitmap.Size.Height;
            for (int i = 0; i < height; i++)
            {
                if (bitmap.GetPixel(vh, i).B != 255)
                {
                    if (num == 0)
                    {
                        num = 1;
                    }
                    else
                    {
                        if (num == 1 && bitmap.GetPixel(vh, i - 1).B != 255)
                        {
                            num = 1;
                        }
                        else
                        {
                            if (bitmap.GetPixel(vh, i - 1).B != 255)
                            {

                            }
                            else
                            {
                                num++;
                            }
                        }
                    }
                }
            }
            return num;
        }
        /// <summary>
        /// y轴的某行有几个蓝色像素点
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="vh"></param>
        /// <returns></returns>
        public static int getNum(Bitmap bitmap, int vh)
        {
            int num = 0;
            int width = bitmap.Size.Width;
            for (int i = 0; i < width; i++)
            {
                if (bitmap.GetPixel(i, vh).B != 255) num++;
            }
            return num;
        }
        //huangguan登陆
        private static void HuangGuanLogin(AgentAccount agent)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Encoding big5 = Encoding.GetEncoding("big5");
            Encoding utf8 = Encoding.UTF8;
            int count = 0;
            string postdata;
            string content;
            string url = "";
            GZipStream stream = null;
            StreamReader reader = null;
            System.Net.ServicePointManager.CertificatePolicy = new pub.MyPolicy();
           
        label10:
            try
            {
                url = "https://" + agent.Address + "/";
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Accept = "*/*";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; GTB6.6; .NET CLR 2.0.50727; .NET4.0C; .NET4.0E; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
                request.KeepAlive = false;
                request.Method = "GET";
                //request.CookieContainer = cookies;
                request.AllowAutoRedirect = false;
                response = (HttpWebResponse)request.GetResponse();
                if (response.Headers.Get("Content-Encoding") != null)
                {
                    reader = new StreamReader(new GZipStream(response.GetResponseStream(), CompressionMode.Decompress), big5);
                }
                else
                {
                    reader = new StreamReader(response.GetResponseStream(), utf8);
                }

                content = reader.ReadToEnd(); ;
                if (content.Contains("更新"))
                {
                    System.Console.WriteLine("皇冠网站正在维护中,暂时不能提供服务，不便之处，敬请见谅");
                    Thread.Sleep(120000);
                    goto label10;
                }
            }
            catch (Exception e)
            {
                if (count < 10)
                {
                    count++;
                    goto label10;
                }
                else
                {
                    return;
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
                //https://203.148.92.62/ok.html
                request = (HttpWebRequest)WebRequest.Create("https://" + agent.Address + "/ok.html");
                request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, */*";
                request.Headers["Accept-Language"] = "zh-cn";
                //request.IfModifiedSince =Convert.ToDateTime( "Fri, 05 Jun 2009 08:02:51 GMT");
                //request.Headers["If-None-Match"] = "\"eadcc-0-48f57311180c0\"";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; GTB6.6; .NET CLR 2.0.50727; .NET4.0C; .NET4.0E; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
                request.KeepAlive = true;
                request.Method = "GET";
                request.AllowAutoRedirect = false;
                response = (HttpWebResponse)request.GetResponse();
                if (response.Headers.Get("Content-Encoding") != null)
                {
                    reader = new StreamReader(new GZipStream(response.GetResponseStream(), CompressionMode.Decompress), utf8);
                }
                else
                {
                    reader = new StreamReader(response.GetResponseStream(), utf8);
                }
                content = reader.ReadToEnd();
            }
            catch (Exception e)
            {
                if (count < 10)
                {
                    count++;
                    goto label10;
                }
                else
                {
                    return;
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
                postdata = "langx=zh-tw&radiobutton=radiobutton&username=" + agent.Name + "&passwd=" + agent.Password + "&passwd_safe=&Submit.x=35&Submit.y=9";
                //https://203.148.92.62/app/control/agents/login.php
                request = (HttpWebRequest)WebRequest.Create("https://" + agent.Address + "/app/control/agents/login.php");
                request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, */*";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["UA-CPU"] = "x86";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; GTB6.6; .NET CLR 2.0.50727; .NET4.0C; .NET4.0E; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
                request.KeepAlive = true;
                request.ContentType = "application/x-www-form-urlencoded";
                request.AllowAutoRedirect = false;
                request.Method = "POST";
                byte[] buffer = Encoding.ASCII.GetBytes(postdata);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
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
                //<frame name="topFrame" scrolling="NO" noresize src="header.php?langx=zh-cn&uid=34b779bbm1d676fleb14edxw">
                if (content.Contains("top.user_id ="))
                {

                     agent.Cookie = pub.substring(content, "top.user_id = '", "';");
                   
                }

            }
            catch (Exception e)
            {
                if (count < 10)
                {
                    count++;
                    goto label10;
                }
                else
                {
                    return;
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
                //https://203.148.92.62/app/control/agents/header.php?langx=zh-cn&uid=34b779bbm1d676fleb14edxw
                request = (HttpWebRequest)WebRequest.Create("https://" + agent.Address + "/app/control/agents/header.php?langx=zh-tw&uid=" + agent.Cookie);
                request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, */*";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; GTB6.6; .NET CLR 2.0.50727; .NET4.0C; .NET4.0E; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
                request.KeepAlive = true;
                request.Method = "GET";
                request.AllowAutoRedirect = false;
                response = (HttpWebResponse)request.GetResponse();
                if (response.Headers.Get("Content-Encoding") != null)
                {
                    reader = new StreamReader(new GZipStream(response.GetResponseStream(), CompressionMode.Decompress), utf8);
                }
                else
                {
                    reader = new StreamReader(response.GetResponseStream(), utf8);
                }
                content = reader.ReadToEnd();
            }
            catch (Exception e)
            {
                if (count < 10)
                {
                    count++;
                    goto label10;
                }
                else
                {
                    return;
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
                //https://203.148.92.62/app/control/agents/header.php?langx=zh-cn&uid=34b779bbm1d676fleb14edxw
                request = (HttpWebRequest)WebRequest.Create("https://" + agent.Address + "/app/control/agents/header.php?langx=zh-tw&uid=" + agent.Cookie);
                request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, */*";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; GTB6.6; .NET CLR 2.0.50727; .NET4.0C; .NET4.0E; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
                request.KeepAlive = true;
                request.Method = "GET";
                request.AllowAutoRedirect = false;
                response = (HttpWebResponse)request.GetResponse();
                if (response.Headers.Get("Content-Encoding") != null)
                {
                    reader = new StreamReader(new GZipStream(response.GetResponseStream(), CompressionMode.Decompress), utf8);
                }
                else
                {
                    reader = new StreamReader(response.GetResponseStream(), utf8);
                }
                content = reader.ReadToEnd();
            }
            catch (Exception e)
            {
                if (count < 10)
                {
                    count++;
                    goto label10;
                }
                else
                {
                    return;
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
                //https://203.148.92.62/app/control/agents/report_new/report.php?uid=34b779bbm1d676fleb14edxw
                request = (HttpWebRequest)WebRequest.Create("https://" + agent.Address + "/app/control/agents/report_new/report.php?uid=" + agent.Cookie);
                request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, */*";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; GTB6.6; .NET CLR 2.0.50727; .NET4.0C; .NET4.0E; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
                request.KeepAlive = true;
                request.Method = "GET";
                request.AllowAutoRedirect = false;
                response = (HttpWebResponse)request.GetResponse();
                if (response.Headers.Get("Content-Encoding") != null)
                {
                    reader = new StreamReader(new GZipStream(response.GetResponseStream(), CompressionMode.Decompress), utf8);
                }
                else
                {
                    reader = new StreamReader(response.GetResponseStream(), utf8);
                }
                content = reader.ReadToEnd();
                //	<input type="hidden" name="aid" value="1322122">
                agent.Address2 =pub.substring(content, "name=\"aid\" value=\"", "\">");
            }
            catch (Exception e)
            {
                if (count < 10)
                {
                    count++;
                    goto label10;
                }
                else
                {
                    return;
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
            return;
        }
        // BW3388 登录
        private static void Bw3388Login(AgentAccount agent)
        {
            string content = string.Empty;
            string hostUrl = "http://" + agent.Address + "/";//域名
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            byte[] bytes = null;
            string nextPageUrl = null;
            CookieContainer cookieList = new CookieContainer();
            Encoding UTF8 = Encoding.UTF8;
            int count = 0;
        label10:
            try
            {
                nextPageUrl = hostUrl + "manager/aglogin.php";
                request = (HttpWebRequest)WebRequest.Create(nextPageUrl);
                request.Method = "GET";
                request.Accept = "*/*";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
                request.KeepAlive = true;
                request.AllowAutoRedirect = false;
                request.CookieContainer = cookieList;
                response = (HttpWebResponse)request.GetResponse();
                if (response.Headers.Get("Content-Encoding") != null)
                {
                    stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    reader = new StreamReader(stream, UTF8);
                }
                else
                {
                    reader = new StreamReader(response.GetResponseStream(), UTF8);
                }
                content = reader.ReadToEnd();
                if (!content.Contains("fr_username"))
                {
                    if (count < 5)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch
            {
                if (count < 5)
                {
                    count++;
                    goto label10;
                }
                else
                {
                    return;
                }
            }
            finally
            {
                try
                {
                    response.Close();
                }
                catch { }
                try { reader.Close(); }
                catch { }
                try { if (stream != null) stream.Close(); }
                catch { }
            }

            try
            {
                bytes = Encoding.ASCII.GetBytes("fr_username=" + agent.Name + "&fr_password=" + agent.Password + "&fr_language=tw&fr_submit=Enter+%B5%C7%C8%EB&bypass=1");
                nextPageUrl = hostUrl + "manager/aglogin.php?";
                request = (HttpWebRequest)WebRequest.Create(nextPageUrl);
                request.Method = "POST";
                request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/msword, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, */*";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
                request.KeepAlive = true;
                request.ContentType = "application/x-www-form-urlencoded";
                request.AllowAutoRedirect = true;
                request.CookieContainer = cookieList;
                request.ContentLength = bytes.Length;
                request.Headers.Add("Cache-Control", "no-cache");
                request.GetRequestStream().Write(bytes, 0, bytes.Length);
                response = (HttpWebResponse)request.GetResponse();
                if (response.Headers.Get("Content-Encoding") != null)
                {
                    stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    reader = new StreamReader(stream, UTF8);
                }
                else
                {
                    reader = new StreamReader(response.GetResponseStream(), UTF8);
                }
                content = reader.ReadToEnd();
                if (content.Contains("<frame src=\"header.php?\""))
                {
                    agent.Cookie = pub.GetCookie(cookieList.GetCookies(new Uri(nextPageUrl)));
                }
                else
                {
                    if (count < 3)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception)
            {
                if (count < 5)
                {
                    count++;
                    goto label10;
                }
                else
                {
                    return;
                }
            }
            finally
            {
                try
                {
                    response.Close();
                }
                catch { }
                try { reader.Close(); }
                catch { }
                try { if (stream != null) stream.Close(); }
                catch { }
            }
        }
        // LiJi 登录
        private static void LiJiLogin(AgentAccount agent)
        {
            string strTemp = "SBOBET [";
            Encoding utf8 = Encoding.UTF8;
            CookieContainer cookies = new CookieContainer();
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            string host = agent.Address;
            string url = null;
            string yzmurl = null;
            string html = null;
            byte[] bytes;
            string code = null;
            string strcook = null;
            string bytestr = null;
            int count = 0;
        label10:
            url = "http://" + host + "/";
            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Accept = "*/*";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; msn OptimizedIE8;ZHCN)";
                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = false;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    }
                    else
                    {
                        stream = response.GetResponseStream();
                    }
                    reader = new StreamReader(stream, utf8);
                    html = reader.ReadToEnd();
                    if (html.Contains("name=\"username\""))
                    {

                    }
                    else
                    {
                        if (count < 4)
                        {
                            goto label10;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception ee)
                {
                    if (count < 4)
                    {
                        goto label10;
                    }
                    else
                    {
                        return;
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
            url = url + "ImgTextRefresh.aspx";
            try
            {
                try
                {
                    bytes = Encoding.ASCII.GetBytes("fromPage=default");
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "POST";
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/msword, application/vnd.ms-excel, application/vnd.ms-powerpoint, */*";
                    request.Referer = "http://" + host + "/";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; msn OptimizedIE8;ZHCN)";
                    request.KeepAlive = true;
                    request.ContentLength = bytes.Length;
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = false;
                    request.Headers.Add("Cache-Control", "no-cache");
                    request.GetRequestStream().Write(bytes, 0, bytes.Length);
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    }
                    else
                    {
                        stream = response.GetResponseStream();
                    }
                    reader = new StreamReader(stream, utf8);
                    html = reader.ReadToEnd();
                    try
                    {
                        yzmurl = pub.substring(html, "parent.updateImgText", "</script>").Replace("'", "").Replace("(", "").Replace(")", "").Replace(";", "").Replace(" ", "").Trim();
                        if (yzmurl == null)
                        {
                            if (count < 4)
                            {
                                goto label10;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    catch
                    {
                        Thread.Sleep(2000);
                        goto label10;
                    }
                }
                catch (Exception ee)
                {
                    if (count < 4)
                    {
                        goto label10;
                    }
                    else
                    {
                        return;
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
            yzmurl = "http://" + host + yzmurl;
            yzmurl = yzmurl.Replace(" ", "");
            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(yzmurl);
                    request.Accept = "*/*";
                    request.Referer = "http://" + host + "/";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; msn OptimizedIE8;ZHCN)";
                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = false;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    }
                    else
                    {
                        stream = response.GetResponseStream();
                    }
                    code = "";
                    Bitmap bitmap = new Bitmap(stream);
                    pub.changeColorToGray(bitmap);
                    pub.changeColorToBlack(bitmap);
                    PixelFormat pixlFormat = bitmap.PixelFormat;
                    Rectangle rect = new Rectangle(8, 2, 12, 16);
                    Bitmap map = bitmap.Clone(rect, pixlFormat);
                    code += pub.returnValidaCode(map);
                    rect = new Rectangle(22, 2, 12, 16);
                    map = bitmap.Clone(rect, pixlFormat);
                    code += pub.returnValidaCode(map);
                    rect = new Rectangle(36, 2, 12, 16);
                    map = bitmap.Clone(rect, pixlFormat);
                    code += pub.returnValidaCode(map);
                    rect = new Rectangle(50, 2, 12, 16);
                    map = bitmap.Clone(rect, pixlFormat);
                    code += pub.returnValidaCode(map);
                    bitmap.Dispose();
                    map.Dispose();
                    if (code == null)
                    {
                        if (count < 4)
                        {
                            goto label10;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception ee)
                {
                    if (count < 4)
                    {
                        goto label10;
                    }
                    else
                    {
                        return;
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

            url = "http://" + host + "/processlogin.aspx";
            string id = null;
            string key = null;
            string lang = null;
            string nextUrl = null;
            bytestr = "username=" + agent.Name + "&password=" + agent.Password + "&vcode=" + code + "&lang=zh-tw&page=default";
            try
            {
                try
                {
                    bytes = Encoding.ASCII.GetBytes(bytestr);
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "POST";
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/msword, application/vnd.ms-excel, application/vnd.ms-powerpoint, */*";
                    request.Referer = "http://" + host + "/default.aspx?lang=zh-tw";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers.Add("Accept-Encoding", "gzip, deflate");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; msn OptimizedIE8;ZHCN)";
                    request.ContentLength = bytes.Length;
                    request.KeepAlive = true;
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = false;
                    request.Headers.Add("Cache-Control", "no-cache");
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
                    nextUrl = pub.substring(html, "action=\'", "\'");
                    if (nextUrl == null)
                    {
                        if (count < 4)
                        {
                            goto label10;
                        }
                        else
                        {
                            return;
                        }
                    }
                    id = pub.substring(html, "name=\'id\' value=\'", "\'");
                    key = pub.substring(html, "name=\'key\' value=\'", "\'");
                    lang = pub.substring(html, "name=\'lang\' value=\'", "\'");
                }
                catch (Exception ee)
                {
                    if (count < 4)
                    {
                        goto label10;
                    }
                    else
                    {
                        return;
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
            url = (nextUrl + "?" + "id=" + id + "&key=" + key + "&lang=" + lang).Replace(" ", "").Trim();
            count = 0;
        label20:
            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.Headers.Add("Accept-Encoding", "gzip, deflate");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; QQPinyin 689; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; InfoPath.2)";
                    request.KeepAlive = true;
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = true;
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
                    if (html.Contains(strTemp))
                    {
                        agent.Cookie = pub.GetCookie(cookies.GetCookies(new Uri(nextUrl)));
                        agent.Address2 = pub.substring(nextUrl, "http://", "/");
                    }
                    else
                    {
                        if (count < 4)
                        {
                            goto label20;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception ee)
                {
                    if (count < 4)
                    {
                        goto label20;
                    }
                    else
                    {
                        return;
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
        }
        // ShaBa 登录
        private static void ShaBaLogin(AgentAccount agent)
        {
            string code = null;
            CookieContainer cookies = new CookieContainer();
            Encoding utf8 = Encoding.UTF8;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            string host2 = null;
            string url = null;
            string html = null;
            byte[] bytes;
            string topUrl = null;
            string thisNum = null;
            int count = 0;
            string host;
            string temp = null;
            string bytestr = null;
            string NextUrl = null;//下个网页的地址
            host2 = agent.Address;
        label10:
            url = "http://" + host2 + "/";
            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, */*";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; 360SE)";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.ServicePoint.ConnectionLimit = 30;
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = false;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    }
                    else
                    {
                        stream = response.GetResponseStream();
                    }
                    reader = new StreamReader(stream, utf8);
                    html = reader.ReadToEnd();
                    //这里处理当系统处于维护状态时的处理
                    if (!html.Contains("<title>Sign In</title>"))
                    {
                        return;
                    }
                    NextUrl = pub.substring(html, "href=\"", "\"");
                    thisNum = pub.substring(NextUrl, "/", "/");
                    if (NextUrl == null)
                    {
                        if (count < 10)
                        {
                            goto label10;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception ee)
                {
                    if (count < 10)
                    {
                        Thread.Sleep(500);
                        goto label10;

                    }
                    else
                    {
                        return;
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
            topUrl = url;
            url = "http://" + host2 + "/Handlers/Captcha.ashx";
            code = "";
            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Accept = "*/*";
                    request.Referer = topUrl;
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; 360SE)";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = true;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    }
                    else
                    {
                        stream = response.GetResponseStream();
                    }
                    Bitmap bitmap = new Bitmap(stream);
                    code = pub.getcode(bitmap);
                    bitmap.Dispose();

                    if (code == null)
                    {
                        if (count < 10)
                        {
                            Thread.Sleep(500);
                            goto label10;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception ee)
                {
                    if (count < 10)
                    {
                        Thread.Sleep(500);
                        goto label10;

                    }
                    else
                    {
                        return;
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
            bytestr = "hidLanguage=zh-TW&txtUserName=" + agent.Name + "&txtPassWord=" + agent.Password + "&txtCaptcha=" + code;
            url = topUrl;
            try
            {
                try
                {
                    bytes = Encoding.ASCII.GetBytes(bytestr);
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "POST";
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/msword, application/vnd.ms-excel, application/vnd.ms-powerpoint, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; 360SE)";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers.Add("Accept-Encoding", "gzip, deflate");
                    request.ContentLength = bytes.Length;
                    request.KeepAlive = true;
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = false;
                    request.Headers.Add("Cache-Control", "no-cache");
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
                    if (html.Contains("errCode':101"))
                    {
                        goto label10;
                    }
                    NextUrl = pub.substring(html, "<a href=\"", "\">here");
                    temp = pub.substring(NextUrl, "//", "/");
                }
                catch (Exception ee)
                {
                    if (count < 10)
                    {
                        Thread.Sleep(500);
                        goto label10;

                    }
                    else
                    {
                        return;
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
            cookies = new CookieContainer();
            url = NextUrl.Replace("amp;", "");
            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/msword, application/vnd.ms-excel, application/vnd.ms-powerpoint, */*";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; QQPinyin 686; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; msn OptimizedIE8;ZHCN; 360SE)";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.KeepAlive = true;
                    request.Headers.Add("Cache-Control", "no - cache");
                    request.Method = "GET";
                    request.AllowAutoRedirect = false;
                    request.CookieContainer = cookies;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    }
                    else
                    {
                        stream = response.GetResponseStream();
                    }
                    reader = new StreamReader(stream, utf8);
                    html = reader.ReadToEnd();
                    NextUrl = "";
                    NextUrl = pub.substring(html, "<a href=\"", "\">here<");
                    if (NextUrl == "")
                    {
                        if (count < 10)
                        {
                            Thread.Sleep(500);
                            goto label10;
                        }
                        else
                        {
                            return;
                        }
                    }
                    host = temp + "/" + pub.substring(NextUrl, "%2f", "%2f");
                }
                catch (Exception ee)
                {
                    if (count < 10)
                    {
                        Thread.Sleep(500);
                        goto label10;

                    }
                    else
                    {
                        return;
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
            url = "http://" + temp + NextUrl.Replace("%2f", "/").Replace("%3d", "=").Replace("%2b", "+").Replace("%3f", "?").Replace("%26", "&").Trim();
            cookies = new CookieContainer();
            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Accept = "application/x-shockwave-flash, image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    request.Referer = "http://" + host2 + "/";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; QQPinyin 686; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; msn OptimizedIE8;ZHCN; 360SE)";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.KeepAlive = true;
                    request.Headers.Add("Cache-Control", "no - cache");
                    request.Method = "GET";
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = true;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    }
                    else
                    {
                        stream = response.GetResponseStream();
                    }
                    reader = new StreamReader(stream, utf8);
                    html = reader.ReadToEnd();
                    if (html.Contains("src=\"_Header/Header.aspx\""))
                    {
                        agent.Cookie = pub.GetCookie(cookies.GetCookies(new Uri("http://" + host + "/")));
                        agent.Address2 = host;
                    }
                    else
                    {
                        if (count < 10)
                        {
                            Thread.Sleep(500);
                            goto label10;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception ee)
                {
                    if (count < 10)
                    {
                        Thread.Sleep(500);
                        goto label10;

                    }
                    else
                    {
                        return;
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
        }
        // YongLiGao 登录
        private static void ylgLogin(AgentAccount agent)
        {
            CookieContainer cookies = new CookieContainer();
            Encoding utf8 = Encoding.UTF8;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            string host2 = null;
            string url = null;
            string html = null;
            byte[] bytes;
            int count = 0;
            host2 = agent.Address+"/";
        label10:
            url = "http://" + host2 + "home.php";
            try
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Referer = "http://" + host2;
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; GTB6.6; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; InfoPath.3)";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.KeepAlive = true;
                    request.ServicePoint.ConnectionLimit = 120;
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = false;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    }
                    else
                    {
                        stream = response.GetResponseStream();
                    }
                    reader = new StreamReader(stream, utf8);
                    html = reader.ReadToEnd();
                    //这里处理当系统处于维护状态时的处理
                    if (!html.Contains("form.username.focus()"))
                    {
                        return;
                    }
                }
                catch (Exception ee)
                {
                    if (count < 10)
                    {
                        Thread.Sleep(500);
                        goto label10;

                    }
                    else
                    {
                        return;
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
                    url = "http://" + host2 + "login.php";
                    bytes = Encoding.ASCII.GetBytes("system=agent&username="+agent.Name+"&password="+agent.Password+"&LOGIN_STYLE=wg&login=%B5n%A4J");
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "POST";
                    request.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.Referer = "http://" + host2 + "home.php";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; GTB6.6; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; InfoPath.3)";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers.Add("Accept-Encoding", "gzip, deflate");
                    request.ContentLength = bytes.Length;
                    request.KeepAlive = true;
                    request.ServicePoint.ConnectionLimit = 120;
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = true;
                    request.Headers.Add("Cache-Control", "no-cache");
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
                    if (html.Contains("header.php?"))
                    {
                        agent.Cookie = pub.GetCookie(cookies.GetCookies(new Uri(url)));
                        agent.Address2 = host2;
                    }
                }
                catch (Exception ee)
                {
                    if (count < 10)
                    {
                        Thread.Sleep(500);
                        goto label10;

                    }
                    else
                    {
                        return;
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
        }
        //DongFangHuangChao 登录
        private static void HuangChaoLogin(AgentAccount agent)
        {
            string code = null;
            CookieContainer cookies = new CookieContainer();
            Encoding utf8 = Encoding.UTF8;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            string host2 = null;
            string url = null;
            string html = null;
            byte[] bytes;
            int count = 0;
            host2 = agent.Address;
        label10:
            url = "https://" + host2 + "/sb2/ag/login.jsp?localeString=zh_tw";
            try
            {
                try
                {
                    ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(pub.ValidateServerCertificate);
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Referer = "https://" + host2 + "/sb2/ag/login.jsp?localeString=zh_tw";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; GTB6.6; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; InfoPath.3)";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.KeepAlive = true;
                    request.ServicePoint.ConnectionLimit = 80;
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = false;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    }
                    else
                    {
                        stream = response.GetResponseStream();
                    }
                    reader = new StreamReader(stream, utf8);
                    html = reader.ReadToEnd();

                }
                catch (Exception ee)
                {
                    if (count < 5)
                    {
                        count++;
                        goto label10;

                    }
                    else
                    {
                        return;
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
                url = "https://" + host2 + "/sb2/ag/generate_validation_code.jsp";
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Referer = "https://" + host2 + "/sb2/ag/login.jsp?localeString=zh_tw";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; GTB6.6; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; InfoPath.3)";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.KeepAlive = true;
                request.ServicePoint.ConnectionLimit = 80;
                request.CookieContainer = cookies;
                request.AllowAutoRedirect = false;
                response = (HttpWebResponse)request.GetResponse();
                if (response.Headers.Get("Content-Encoding") != null)
                {
                    stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                }
                else
                {
                    stream = response.GetResponseStream();
                }
                Bitmap bitmap = new Bitmap(stream);
                code = pub.getValidaCode(bitmap);
                bitmap.Dispose();
            }
            catch (Exception ee)
            {
                if (count < 5)
                {
                    count++;
                    goto label10;
                }
                else
                {
                    return;
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
                    url = "https://" + host2 + "/sb2/ag/proceed_login.jsp";
                    bytes = Encoding.ASCII.GetBytes("localeString=zh_tw&agTypeId=30&agLoginCode=" + agent.Name + "&password=" + agent.Password + "&validationCode=" + code);
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "POST";
                    request.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.Referer = "http://" + host2 + "home.php";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; GTB6.6; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; InfoPath.3)";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers.Add("Accept-Encoding", "gzip, deflate");
                    request.ContentLength = bytes.Length;
                    request.KeepAlive = true;
                    request.ServicePoint.ConnectionLimit = 120;
                    request.CookieContainer = cookies;
                    request.AllowAutoRedirect = true;
                    request.Headers.Add("Cache-Control", "no-cache");
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
                    if (html.Contains("id=\"contentFrame\""))
                    {
                        agent.Cookie = pub.GetCookie(cookies.GetCookies(new Uri(url)));
                        agent.Address2 = "agent.ed3688.com";
                    }
                    if (html.Contains("驗證碼不正確"))
                    {
                        if (count < 5)
                        {
                            count++;
                            goto label10;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch (Exception ee)
                {
                    if (count < 5)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return;
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
        }

        //huangguan历史查询核对
        private static void HuangGuanCheckHistoryReport(BetAccountOrderHistory betAccountOrderHistory)
        {
           
            Encoding utf8 = Encoding.UTF8;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            int count = 0;
            string nextPageUrl = string.Empty;
            string content = string.Empty;
            string tr = string.Empty;
            string td = string.Empty;
            string postdata = string.Empty;
            string urlstr = string.Empty;
            string url = string.Empty;
            string[] sar; 
            //我们数据库的订单
            Dictionary<string, Orderotherhistory> dicOwner = new Dictionary<string, Orderotherhistory>();
            //代理网站的订单
            Dictionary<string, Orderotherhistory> dicAgent = new Dictionary<string, Orderotherhistory>();

           
        label20:
            try
            {
                postdata = "aid=" + betAccountOrderHistory.agent.Address2 + "&uid=" + betAccountOrderHistory.agent.Cookie + "&gtype=&date_start=" + Convert.ToDateTime(betAccountOrderHistory.startTime).ToString("yyyy-MM-dd") + "&date_end=" + Convert.ToDateTime(betAccountOrderHistory.endTime).ToString("yyyy-MM-dd") + "&report_kind=A&pay_type=&wtype=&result_type=Y";
                //https://203.148.92.62/app/control/agents/login.php
                request = (HttpWebRequest)WebRequest.Create("https://" + betAccountOrderHistory.agent.Address + "/app/control/agents/report_new/report_all.php");
                request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, */*";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["UA-CPU"] = "x86";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; GTB6.6; .NET CLR 2.0.50727; .NET4.0C; .NET4.0E; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
                request.KeepAlive = true;
                request.ContentType = "application/x-www-form-urlencoded";
                request.AllowAutoRedirect = false;
                request.Method = "POST";
                byte[] buffer = Encoding.ASCII.GetBytes(postdata);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
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
                //<td><A HREF="report_agent.php?uid=4cc5f37fm1e02e0lf6ff84xw&currency=1&report_kind=A&result_type=Y&sid=80908&aid=1322122&date_start=2011-04-28&date_end=2011-05-03&report_date=2011-04-24&report_daily=2011-05-04">161188.0</a></td>
                urlstr =pub.substring(content, "<td><A HREF=\"", "\">");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                if (count < 10)
                {
                    count++;
                    goto label20;
                }
                else
                {
                    return;
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


            url = "https://" + betAccountOrderHistory.agent.Address + "/app/control/agents/report_new/" + urlstr;

            try
            {
                //https://203.148.92.62/app/control/agents/report_new/report.php?uid=34b779bbm1d676fleb14edxw
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, */*";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; GTB6.6; .NET CLR 2.0.50727; .NET4.0C; .NET4.0E; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
                request.KeepAlive = true;
                request.Method = "GET";
                request.AllowAutoRedirect = false;
                //request.Headers["Cookie"] = cookiestr;
                response = (HttpWebResponse)request.GetResponse();
                if (response.Headers.Get("Content-Encoding") != null)
                {
                    reader = new StreamReader(new GZipStream(response.GetResponseStream(), CompressionMode.Decompress), utf8);
                }
                else
                {
                    reader = new StreamReader(response.GetResponseStream(), utf8);
                }
                content = reader.ReadToEnd();
                if (content.Contains("HREF=\"report_member.php?"))
                {
                   
                    foreach (Betaccount account in betAccountOrderHistory.account)
                    {
                        if (content.Contains(account.Userid))
                        {
                            BetAccountOrderMoney betAccountOrderMoney = new BetAccountOrderMoney();
                            betAccountOrderMoney.WebAgentName = account.Agent;
                            betAccountOrderMoney.WebUserName = account.Userid;
                            betAccountOrderMoney.OwnerOrderCount = betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == betAccountOrderMoney.WebUserName).Count();
                            betAccountOrderMoney.OwnerTotalBetMoney = betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == betAccountOrderMoney.WebUserName).Select(n => n.Value.Amount).Sum();
                            betAccountOrderMoney.OwnerResultMoney = betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == betAccountOrderMoney.WebUserName).Select(n => n.Value.Result).Sum();
                            tr = pub.substring(content, account.Userid, "</tr>");
                            sar = tr.Split(new string[] { "/td>" }, StringSplitOptions.None);
                            betAccountOrderMoney.WebsiteOrderCount = Convert.ToInt32(pub.substring(sar[1], "<td>", "<"));
                            betAccountOrderMoney.AccountAddress = pub.substring(sar[2], "HREF=\"report_member.php?", "\" onClick=");
                            betAccountOrderMoney.WebsiteTotalBetMoney = Convert.ToDecimal(pub.substring(sar[2], "\">", "</a>"));
                            betAccountOrderMoney.WebsiteResultMoney = Convert.ToDecimal(pub.substring(sar[4], "<td>", "<"));
                            finalStatsDic.Add(betAccountOrderMoney.WebUserName, betAccountOrderMoney);

                        }
                    }
                    foreach (KeyValuePair<string, BetAccountOrderMoney> item in finalStatsDic)
                    {
                        try
                        {
                            if (dicOwner == null)
                            {
                                dicOwner = new Dictionary<string, Orderotherhistory>();
                            }
                            else
                            {
                                dicOwner.Clear();
                            }
                            if (dicAgent == null)
                            {
                                dicAgent = new Dictionary<string, Orderotherhistory>();
                            }
                            else
                            {
                                dicAgent.Clear();
                            }
                            if (item.Value.WebAgentName == betAccountOrderHistory.agent.AgentName)
                            {
                                //我们数据库的订单
                                dicOwner = GetDicByAccount(item.Key, betAccountOrderHistory.OrderOtherHistorys);
                                if (!string.IsNullOrEmpty(item.Value.AccountAddress))
                                {
                                    //代理网站的订单
                                    dicAgent = HuangGuanCheckHistoryReportDetails(betAccountOrderHistory, item.Value);
                                    Thread.Sleep(1000);
                                }
                                else
                                {
                                    if (betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == item.Key).Count() > 0)
                                    {
                                        Dictionary<string, Orderotherhistory> dic = null;
                                        foreach (KeyValuePair<string, Orderotherhistory> items in betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == item.Key).ToList())
                                        {
                                            dic = new Dictionary<string, Orderotherhistory>();
                                            dic.Add(items.Value.WebOrderID, items.Value);
                                        }
                                        finalDetailDic.Add(item.Key, dic);
                                    }
                                }
                                Dictionary<string, Orderotherhistory> dicTemp = new Dictionary<string, Orderotherhistory>();
                                try
                                {
                                    dicTemp = HuangGuanCheckError(dicOwner, dicAgent);
                                }
                                catch (Exception e)
                                { }
                                if (!finalDetailDic.ContainsKey(item.Key))
                                {
                                    if (dicTemp.Count > 0)
                                        finalDetailDic.Add(item.Key, dicTemp);
                                }
                            }
                        }
                        catch
                        { }
                    }
                    foreach (KeyValuePair<string, Dictionary<string, Orderotherhistory>> items in finalDetailDic)
                    {
                        finalStatsDic[items.Key].IsErrorData = items.Value.Count > 0 ? 1 : 0;
                    }
                }
                else
                {
                    if (count < 5)
                    {
                        count++;
                        goto label20;
                    }
                    else
                    {
                        return;
                    }
                }

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);

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

        }
        private static Dictionary<string, Orderotherhistory> HuangGuanCheckHistoryReportDetails(BetAccountOrderHistory betAccountOrderHistory, BetAccountOrderMoney betAccountOrderMoney)
        {
            Dictionary<string, Orderotherhistory> dic = new Dictionary<string, Orderotherhistory>();
            Encoding utf8 = Encoding.UTF8;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            int count = 0;
            string nextPageUrl = string.Empty;
            string content = string.Empty;
            string type = string.Empty;
            string team = string.Empty;
            string postdata = string.Empty;
            string tzsj = string.Empty;
            string url = string.Empty;
            string username = string.Empty;
            string handicap = string.Empty;
            string[] str2;
            string[] str3;
            string[] str4;
            //我们数据库的订单
            Dictionary<string, Orderotherhistory> dicOwner = new Dictionary<string, Orderotherhistory>();
            //代理网站的订单
            Dictionary<string, Orderotherhistory> dicAgent = new Dictionary<string, Orderotherhistory>();


        label20:
           try
           {

               url = "https://" + betAccountOrderHistory.agent.Address + "/app/control/agents/report_new/report_member.php?" + betAccountOrderMoney.AccountAddress;
             
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, */*";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; GTB6.6; .NET CLR 2.0.50727; .NET4.0C; .NET4.0E; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
                request.KeepAlive = true;
                request.Method = "GET";
                request.AllowAutoRedirect = false;
                response = (HttpWebResponse)request.GetResponse();
                if (response.Headers.Get("Content-Encoding") != null)
                {
                    reader = new StreamReader(new GZipStream(response.GetResponseStream(), CompressionMode.Decompress), utf8);
                }
                else
                {
                    reader = new StreamReader(response.GetResponseStream(), utf8);
                }
                content = reader.ReadToEnd();


                if (content.Contains(betAccountOrderMoney.WebUserName))
                {
                    str2 = content.Split(new string[] { "<tr class=\"m_rig\"" }, StringSplitOptions.None);

                    str4 = str2[str2.Length - 1].Split(new string[] { "<td" }, StringSplitOptions.None);
                    for (int j = 1; j < str2.Length - 1; j++)
                    {
                        Orderotherhistory order1 = new Orderotherhistory();
                        try
                        {
                           
                            str3 = str2[j].Split(new string[] { "<td" }, StringSplitOptions.None);
                            tzsj = pub.substring(str3[1], "align=\"center\">", "</td>").Replace("<br>", " ").Replace("\r", "").Replace("\n", "").Replace("\t", "");
                            type = pub.substring(str3[3], "nowrap>", "<BR><font").Replace(" ", "").Replace("<fontcolor=\"green\">馬來盤</font><BR>", "");
                            switch (type)
                            {
                                case "足球讓球":
                                    order1.BetType = "0";
                                    order1.Leaguetw = pub.substring(str3[4], ">", "<BR>");
                                    order1.Hometw = pub.substring(str3[4], "<br>", "<font").Replace(" ", "");
                                    order1.Awaytw = pub.substring(str3[4], "</font>", "<font").Replace(" ", "");
                                    order1.BetItem = pub.substring(str3[4], "<font color=#CC0000>", "</font>").Replace(" ", "");
                                    order1.Handicap = pub.substring(str3[4], "<b>", "</b>").Replace(" ", "");
                                    if (order1.Hometw == order1.BetItem)
                                    {
                                        if (order1.Handicap != "0")
                                            order1.Handicap = "-" + order1.Handicap;
                                    }

                                    order1.Score = pub.substring(str3[4], "<font color=\"#009900\"><b>", "</b>").Replace(" ", "");
                                    if (!order1.Score.Contains(":"))
                                    {

                                        order1.ErrorMessage = "代理注单：" + order1.Score + ";";
                                    }
                                    break;
                                case "足球大小盤":
                                    order1.BetType = "1";
                                    order1.Leaguetw = pub.substring(str3[4], ">", "<BR>");
                                    order1.Hometw = pub.substring(str3[4], "<br>", "<font").Replace(" ", "");
                                    order1.Awaytw = pub.substring(str3[4], "</font>", "<font").Replace(" ", "");
                                    team = pub.substring(str3[4], "<font color=#CC0000>", "</font>").Replace(" ", "");
                                    order1.Handicap = team.Substring(1);
                                    order1.BetItem = team.Substring(0, 1);
                                    order1.Score = pub.substring(str3[4], "<font color=\"#009900\"><b>", "</b>").Replace(" ", "");
                                    if (!order1.Score.Contains(":"))
                                    {

                                        order1.ErrorMessage = "代理注单：" + order1.Score + ";";
                                    }
                                    if (order1.BetItem.Contains("大"))
                                    {
                                        order1.Betflag = "O";
                                    }
                                    else if (order1.BetItem.Contains("小"))
                                    {
                                        order1.Betflag = "U";
                                    }
                                    break;
                                case "足球半場讓球":
                                    order1.BetType = "2";
                                    order1.Leaguetw = pub.substring(str3[4], ">", "<BR>");
                                    order1.Hometw = pub.substring(str3[4], "<br>", "<font").Replace(" ", "");
                                    order1.Awaytw = pub.substring(str3[4], "</font>", "<font").Replace(" ", "");
                                    order1.BetItem = pub.substring(str3[4], "<font color=#CC0000>", "- <font").Replace(" ", "");
                                    order1.Handicap = pub.substring(str3[4], "<b>", "</b>").Replace(" ", "");
                                    if (order1.Hometw == order1.BetItem)
                                    {
                                        if (order1.Handicap != "0")
                                            order1.Handicap = "-" + order1.Handicap;

                                    }

                                    order1.Scorehalf = pub.substring(str3[4], "<font color=\"#009900\"><b>", "</b>").Replace(" ", "");
                                    if (!order1.Scorehalf.Contains(":"))
                                    {

                                        order1.ErrorMessage = "代理注单：" + order1.Scorehalf + ";";
                                    }
                                    break;
                                case "足球半場大小":
                                    order1.BetType = "3";
                                    order1.Leaguetw = pub.substring(str3[4], ">", "<BR>");
                                    order1.Hometw = pub.substring(str3[4], "<br>", "<font").Replace(" ", "");
                                    order1.Awaytw = pub.substring(str3[4], "</font>", "<font").Replace(" ", "");
                                    team = pub.substring(str3[4], "<font color=#CC0000>", "- <font").Replace(" ", "");
                                    order1.Handicap = team.Substring(1);
                                    order1.BetItem = team.Substring(0, 1);
                                    order1.Scorehalf = pub.substring(str3[4], "<font color=\"#009900\"><b>", "</b>").Replace(" ", "");
                                    if (!order1.Scorehalf.Contains(":"))
                                    {
                                        order1.ErrorMessage = "代理注单：" + order1.Scorehalf + ";";
                                    }
                                    if (order1.BetItem.Contains("大"))
                                    {
                                        order1.Betflag = "O";
                                    }
                                    else if (order1.BetItem.Contains("小"))
                                    {
                                        order1.Betflag = "U";
                                    }
                                    break;
                                case "足球滾球":
                                    order1.BetType = "4";
                                    if (tzsj.Contains("#ff0000>"))
                                        tzsj = pub.substring(tzsj, "#ff0000>", "</font>");
                                    order1.Leaguetw = pub.substring(str3[4], ">", "<BR>");
                                    order1.Hometw = pub.substring(str3[4], "<br>", "<font").Replace(" ", "");
                                    order1.Awaytw = pub.substring(str3[4], "</font>", "<font").Replace(" ", "");
                                    order1.Scoreathalf = pub.substring(str3[4], "<B>&nbsp;&nbsp;", "</B>").Replace(" ", "");
                                    order1.BetItem = pub.substring(str3[4], "<font color=#CC0000>", "</font>").Replace(" ", "");
                                    order1.Handicap = pub.substring(str3[4], "<font color=#0000BB><b>", "</b>").Replace(" ", "");
                                    if (order1.Hometw == order1.BetItem)
                                    {
                                        if (order1.Handicap != "0")
                                            order1.Handicap = "-" + order1.Handicap;

                                    }

                                    order1.Score = pub.substring(str3[4], "<font color=\"#009900\"><b>", "</b>").Replace(" ", "");
                                    if (!order1.Score.Contains(":"))
                                    {

                                        order1.ErrorMessage = "代理注单：" + order1.Score + ";";
                                    }
                                    break;
                                case "足球滾球大小":
                                    order1.BetType = "5";
                                    if (tzsj.Contains("#ff0000>"))
                                        tzsj = pub.substring(tzsj, "#ff0000>", "</font>");
                                    order1.Leaguetw = pub.substring(str3[4], ">", "<BR>");
                                    order1.Hometw = pub.substring(str3[4], "<br>", "<font").Replace(" ", "");
                                    order1.Awaytw = pub.substring(str3[4], "</font>", "<font").Replace(" ", "");
                                    order1.Scoreathalf = pub.substring(str3[4], "<B>&nbsp;&nbsp;", "</B>").Replace(" ", "");
                                    team = pub.substring(str3[4], "<font color=#CC0000>", "</font>").Replace(" ", "");
                                    order1.Handicap = team.Substring(1);
                                    order1.BetItem = team.Substring(0, 1);
                                    order1.Score = pub.substring(str3[4], "<font color=\"#009900\"><b>", "</b>").Replace(" ", "");
                                    if (!order1.Score.Contains(":"))
                                    {

                                        order1.ErrorMessage = "代理注单：" + order1.Score + ";";
                                    }
                                    if (order1.BetItem.Contains("大"))
                                    {
                                        order1.Betflag = "O";
                                    }
                                    else if (order1.BetItem.Contains("小"))
                                    {
                                        order1.Betflag = "U";
                                    }
                                    break;
                                case "足球上半滾球讓球":
                                    order1.BetType = "6";
                                    order1.Leaguetw = pub.substring(str3[4], ">", "<BR>");
                                    order1.Hometw = pub.substring(str3[4], "<br>", "<font").Replace(" ", "");
                                    order1.Awaytw = pub.substring(str3[4], "</font>", "<font").Replace(" ", "");
                                    order1.Scoreathalf = pub.substring(str3[4], "&nbsp;", "</B>").Replace(" ", "");
                                    order1.BetItem = pub.substring(str3[4], "<font color=#CC0000>", "- <font").Replace(" ", "");
                                    order1.Handicap = pub.substring(str3[4], "<font color=#0000BB><b>", "</b>").Replace(" ", "");
                                    if (order1.Hometw == order1.BetItem)
                                    {
                                        if (order1.Handicap != "0")
                                            order1.Handicap = "-" + order1.Handicap;

                                    }

                                    order1.Scorehalf = pub.substring(str3[4], "<font color=\"#009900\"><b>", "</b>").Replace(" ", "");
                                    if (!order1.Scorehalf.Contains(":"))
                                    {

                                        order1.ErrorMessage = "代理注单：" + order1.Scorehalf + ";";
                                    }
                                    break;
                                case "足球上半滾球大小":
                                    order1.BetType = "7";
                                    order1.Leaguetw = pub.substring(str3[4], ">", "<BR>");
                                    order1.Hometw = pub.substring(str3[4], "<br>", "<font").Replace(" ", "");
                                    order1.Awaytw = pub.substring(str3[4], "</font>", "<font").Replace(" ", "");
                                    order1.Scoreathalf = pub.substring(str3[4], "&nbsp;", "</B>").Replace(" ", "");
                                    order1.Awaytw = order1.Awaytw.Substring(0, order1.Awaytw.IndexOf("<")).Replace(" ", "");
                                    team = pub.substring(str3[4], "<font color=#CC0000>", "</font>").Replace(" ", "");
                                    order1.Handicap = team.Substring(1);
                                    order1.BetItem = team.Substring(0, 1);
                                    order1.Scorehalf = pub.substring(str3[4], "<font color=\"#009900\"><b>", "</b>").Replace(" ", "");
                                    if (!order1.Scorehalf.Contains(":"))
                                    {

                                        order1.ErrorMessage = "代理注单：" + order1.Scorehalf + ";";
                                    }
                                    if (order1.BetItem.Contains("大"))
                                    {
                                        order1.Betflag = "O";
                                    }
                                    else if (order1.BetItem.Contains("小"))
                                    {
                                        order1.Betflag = "U";
                                    }
                                    break;
                                case "足球早餐單式讓球":
                                    order1.BetType = "8";
                                    order1.Leaguetw = pub.substring(str3[4], ">", "<BR>");
                                    order1.Hometw = pub.substring(str3[4], "<br>", "<font").Replace(" ", "");
                                    order1.Awaytw = pub.substring(str3[4], "</font>", "<font").Replace(" ", "");
                                    order1.BetItem = pub.substring(str3[4], "<font color=#CC0000>", "</font>").Replace(" ", "");
                                    order1.Handicap = pub.substring(str3[4], "<b>", "</b>").Replace(" ", "");
                                    if (order1.Hometw == order1.BetItem)
                                    {
                                        if (order1.Handicap != "0")
                                            order1.Handicap = "-" + order1.Handicap;

                                    }

                                    order1.Score = pub.substring(str3[4], "<font color=\"#009900\"><b>", "</b>").Replace(" ", "");
                                    if (!order1.Score.Contains(":"))
                                    {

                                        order1.ErrorMessage = "代理注单：" + order1.Score + ";";
                                    }
                                    break;
                                case "足球早餐單式大小":
                                    order1.BetType = "9";
                                    order1.Leaguetw = pub.substring(str3[4], ">", "<BR>");
                                    order1.Hometw = pub.substring(str3[4], "<br>", "<font").Replace(" ", "");
                                    order1.Awaytw = pub.substring(str3[4], "</font>", "<font").Replace(" ", "");
                                    team = pub.substring(str3[4], "<font color=#CC0000>", "</font>").Replace(" ", "");
                                    order1.Handicap = team.Substring(1);
                                    order1.BetItem = team.Substring(0, 1);
                                    order1.Score = pub.substring(str3[4], "<font color=\"#009900\"><b>", "</b>").Replace(" ", "");
                                    if (!order1.Score.Contains(":"))
                                    {

                                        order1.ErrorMessage = "代理注单：" + order1.Score + ";";
                                    }
                                    if (order1.BetItem.Contains("大"))
                                    {
                                        order1.Betflag = "O";
                                    }
                                    else if (order1.BetItem.Contains("小"))
                                    {
                                        order1.Betflag = "U";
                                    }
                                    break;
                                case "足球早餐半場讓球":
                                    order1.BetType = "10";
                                    order1.Leaguetw = pub.substring(str3[4], ">", "<BR>");
                                    order1.Hometw = pub.substring(str3[4], "<br>", "<font").Replace(" ", "");
                                    order1.Awaytw = pub.substring(str3[4], "</font>", "<font").Replace(" ", "");
                                    order1.BetItem = pub.substring(str3[4], "<font color=#CC0000>", "- <font").Replace(" ", "");
                                    order1.Handicap = pub.substring(str3[4], "<b>", "</b>").Replace(" ", "");
                                    if (order1.Hometw == order1.BetItem)
                                    {
                                        if (order1.Handicap != "0")
                                            order1.Handicap = "-" + order1.Handicap;

                                    }

                                    order1.Scorehalf = pub.substring(str3[4], "<font color=\"#009900\"><b>", "</b>").Replace(" ", "");
                                    if (!order1.Scorehalf.Contains(":"))
                                    {
                                        order1.ErrorMessage = "代理注单：" + order1.Scorehalf + ";";
                                    }
                                    break;
                                case "足球早餐半場大小":
                                    order1.BetType = "11";
                                    order1.Leaguetw = pub.substring(str3[4], ">", "<BR>");
                                    order1.Hometw = pub.substring(str3[4], "<br>", "<font").Replace(" ", "");
                                    order1.Awaytw = pub.substring(str3[4], "</font>", "<font").Replace(" ", "");
                                    team = pub.substring(str3[4], "<font color=#CC0000>", "- <font").Replace(" ", "");
                                    order1.Handicap = team.Substring(1);
                                    order1.BetItem = team.Substring(0, 1);
                                    order1.Scorehalf = pub.substring(str3[4], "<font color=\"#009900\"><b>", "</b>").Replace(" ", "");
                                    if (!order1.Scorehalf.Contains(":"))
                                    {
                                        order1.ErrorMessage = "代理注单：" + order1.Scorehalf + ";";
                                    }
                                    if (order1.BetItem.Contains("大"))
                                    {
                                        order1.Betflag = "O";
                                    }
                                    else if (order1.BetItem.Contains("小"))
                                    {
                                        order1.Betflag = "U";
                                    }
                                    break;
                                case "足球獨贏":
                                    order1.BetType = "12";
                                    order1.Leaguetw = pub.substring(str3[4], ">", "<BR>");
                                    order1.Hometw = pub.substring(str3[4], "<br>", "<b>");
                                    order1.Awaytw = pub.substring(str3[4], "</b>", "<BR>").Replace(" ", "");
                                    order1.BetItem = pub.substring(str3[4].Replace("\"", ""), "<font color=#CC0000>", "</font>").Replace(" ", "");
                                    order1.Score = pub.substring(str3[4], "<font color=\"#009900\"><b>", "</b>").Replace(" ", "");
                                    if (!order1.Score.Contains(":"))
                                    {
                                        order1.ErrorMessage = "代理注单：" + order1.Score + ";";
                                    }
                                    if (order1.Hometw.Contains(order1.BetItem))
                                    {

                                        order1.Betflag = "1";
                                    }
                                    else if (order1.Awaytw.Contains(order1.BetItem))
                                    {
                                        order1.Betflag = "2";
                                    }
                                    else if (order1.BetItem.Contains("和局"))
                                    {
                                        order1.Betflag = "X";
                                    }
                                    break;
                                case "足球半場獨贏":
                                    order1.BetType = "13";
                                    order1.Leaguetw = pub.substring(str3[4], ">", "<BR>");
                                    order1.Hometw = pub.substring(str3[4], "<br>", "<b>").Replace(" ", "");
                                    order1.Awaytw = pub.substring(str3[4], "</b>", "<BR>").Replace(" ", "");
                                    order1.BetItem = pub.substring(str3[4].Replace("\"", ""), "<font color=#CC0000>", "- <font").Replace(" ", "");
                                    order1.Scorehalf = pub.substring(str3[4], "<font color=\"#009900\"><b>", "</b>").Replace(" ", "");
                                    if (!order1.Scorehalf.Contains(":"))
                                    {
                                        order1.ErrorMessage = "代理注单：" + order1.Scorehalf + ";";
                                    }
                                    if (order1.Hometw.Contains(order1.BetItem))
                                    {

                                        order1.Betflag = "1";
                                    }
                                    else if (order1.Awaytw.Contains(order1.BetItem))
                                    {
                                        order1.Betflag = "2";
                                    }
                                    else if (order1.BetItem.Contains("和局"))
                                    {
                                        order1.Betflag = "X";
                                    }
                                    break;
                                case "足球滾球獨贏":
                                    order1.BetType = "14";
                                    if (tzsj.Contains("#ff0000>"))
                                        tzsj = pub.substring(tzsj, "#ff0000>", "</font>");
                                    order1.Leaguetw = pub.substring(str3[4], ">", "<BR>");
                                    order1.Hometw = pub.substring(str3[4], "<br>", "<b>").Replace(" ", "");
                                    order1.Awaytw = pub.substring(str3[4], "</font></b>", "<font").Replace(" ", "");
                                    order1.BetItem = pub.substring(str3[4].Replace("\"", ""), "<font color=#CC0000>", "</font>").Replace(" ", "");
                                    order1.Scoreathalf = pub.substring(str3[4], "<B>&nbsp;&nbsp;", "</B>").Replace(" ", "");
                                    order1.Score = pub.substring(str3[4], "<font color=\"#009900\"><b>", "</b>").Replace(" ", "");
                                    if (!order1.Score.Contains(":"))
                                    {
                                        order1.ErrorMessage = "代理注单：" + order1.Score + ";";
                                    }
                                    if (order1.Hometw.Contains(order1.BetItem))
                                    {

                                        order1.Betflag = "1";
                                    }
                                    else if (order1.Awaytw.Contains(order1.BetItem))
                                    {
                                        order1.Betflag = "2";
                                    }
                                    else if (order1.BetItem.Contains("和局"))
                                    {
                                        order1.Betflag = "X";
                                    }
                                    break;
                                case "足球半場滾球獨贏":
                                    order1.BetType = "15";
                                    order1.Leaguetw = pub.substring(str3[4], ">", "<BR>");
                                    order1.Hometw = pub.substring(str3[4], "<br>", "<b>").Replace(" ", "");
                                    order1.Awaytw = pub.substring(str3[4], "</font></b>", "<font").Replace(" ", "");
                                    order1.BetItem = pub.substring(str3[4].Replace("\"", ""), "<font color=#CC0000>", "</font>").Replace(" ", "");
                                    order1.Scorehalf = pub.substring(str3[4], "<font color=\"#009900\"><b>", "</b>").Replace(" ", "");
                                    if (!order1.Scorehalf.Contains(":"))
                                    {
                                        order1.ErrorMessage = "代理注单：" + order1.Scorehalf + ";";
                                    }
                                    if (order1.Hometw.Contains(order1.BetItem))
                                    {

                                        order1.Betflag = "1";
                                    }
                                    else if (order1.Awaytw.Contains(order1.BetItem))
                                    {
                                        order1.Betflag = "2";
                                    }
                                    else if (order1.BetItem.Contains("和局"))
                                    {
                                        order1.Betflag = "X";
                                    }
                                    break;
                                case "足球早餐單式獨贏":
                                    order1.BetType = "16";
                                    order1.Leaguetw = pub.substring(str3[4], ">", "<BR>");
                                    order1.Hometw = pub.substring(str3[4], "<br>", "<b>").Replace(" ", "");
                                    order1.Awaytw = pub.substring(str3[4], "</b>", "<BR>").Replace(" ", "");
                                    order1.BetItem = pub.substring(str3[4].Replace("\"", ""), "<font color=#CC0000>", "</font>").Replace(" ", "");
                                    order1.Score = pub.substring(str3[4], "<font color=\"#009900\"><b>", "</b>").Replace(" ", "");
                                    if (!order1.Score.Contains(":"))
                                    {
                                        order1.ErrorMessage = "代理注单：" + order1.Score + ";";
                                    }
                                    if (order1.Hometw.Contains(order1.BetItem))
                                    {

                                        order1.Betflag = "1";
                                    }
                                    else if (order1.Awaytw.Contains(order1.BetItem))
                                    {
                                        order1.Betflag = "2";
                                    }
                                    else if (order1.BetItem.Contains("和局"))
                                    {
                                        order1.Betflag = "X";
                                    }
                                    break;
                                case "足球早餐半場獨贏":
                                    order1.BetType = "17";
                                    order1.Leaguetw = pub.substring(str3[4], ">", "<BR>");
                                    order1.Hometw = pub.substring(str3[4], "<br>", "<b>").Replace(" ", "");
                                    order1.Awaytw = pub.substring(str3[4], "</b>", "<BR>").Replace(" ", "");
                                    order1.BetItem = pub.substring(str3[4].Replace("\"",""), "<font color=#CC0000>", "- <font").Replace(" ", "");
                                    order1.Scorehalf = pub.substring(str3[4], "<font color=\"#009900\"><b>", "</b>").Replace(" ", "");
                                    if (!order1.Scorehalf.Contains(":"))
                                    {
                                        order1.ErrorMessage = "代理注单：" + order1.Scorehalf + ";";
                                    }
                                    if (order1.Hometw.Contains(order1.BetItem))
                                    {

                                        order1.Betflag = "1";
                                    }
                                    else if (order1.Awaytw.Contains(order1.BetItem))
                                    {
                                        order1.Betflag = "2";
                                    }
                                    else if (order1.BetItem.Contains("和局"))
                                    {
                                        order1.Betflag = "X";
                                    }
                                    break;

                            }
                            order1.Odds = decimal.Parse(pub.substring(str3[4], "<font color=#CC0000><B>", "</B>"));
                            order1.Hometw = order1.Hometw.Replace("[主]", "").Replace("[中]", "").Replace(" ", "").Replace(")", "").Replace("(", "");
                            order1.Awaytw = order1.Awaytw.Replace("[主]", "").Replace("[中]", "").Replace(" ", "").Replace(")", "").Replace("(", "");
                            if (str3[6].Contains("["))
                            {
                                order1.ErrorMessage ="皇冠代理中球赛" + pub.substring(str3[6], "[", "]");
                               
                            }
                            else
                            {
                                order1.Amount = decimal.Parse(pub.substring(str3[5], ">", "</td>"));
                                order1.ValidAmount = decimal.Parse(pub.substring(str3[5], ">", "</td>"));
                                order1.Result = decimal.Parse(pub.substring(str3[6], ">", "</td>"));
                            }
                            if (DateTime.Now.ToString("yyyy-MM").Substring(5, 1) == "0" && tzsj.Substring(0, 1) != "0")
                            {
                                order1.Time = Convert.ToDateTime(DateTime.Now.AddDays(-300).ToString("yyyy") + "-" + tzsj);
                            }
                            else
                            {
                                order1.Time = Convert.ToDateTime(DateTime.Now.ToString("yyyy") + "-" + tzsj);
                            }
                            order1.WebOrderID = order1.Time.ToString("yyyy-MM-dd hh:mm:ss");
                            order1.UserName = pub.substring(str3[2], "align=\"center\">", "<font");
                           
                        }
                        catch
                        { }
                        try
                        {
                            if (order1.WebOrderID != null)
                            {
                                dic.Add(order1.WebOrderID, order1);
                            }
                            else
                            {
                                dic.Add(DateTime.Now.Ticks.ToString(), order1);
                            }
                        }
                        catch
                        { }
                    }
 
                }
                else
                {
                    if (count < 10)
                    {
                        count++;
                        goto label20;
                    }
                    else
                    {
                        return null;
                    }
                }
  
            }
            catch (Exception e)
            {
                if (count < 10)
                {
                    count++;
                    goto label20;
                }
                else
                {
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
                }
                try
                {
                    response.Close();
                }
                catch
                {
                }
            }
       
            return dic;
        }
        // BW3388 历史查询核对
        private static void Bw3388CheckHistoryReport(BetAccountOrderHistory betAccountOrderHistory)
        {
            Encoding big5 = Encoding.GetEncoding("big5");
            string hostUrl = "http://" + betAccountOrderHistory.agent.Address + "/"; //域名
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            int count = 0;
            string nextPageUrl = string.Empty;
            string content = string.Empty;
            string tr = string.Empty;
            string td = string.Empty;
            string[] sar;
            //我们数据库的订单
            Dictionary<string, Orderotherhistory> dicOwner = new Dictionary<string, Orderotherhistory>();
            //代理网站的订单
            Dictionary<string, Orderotherhistory> dicAgent = new Dictionary<string, Orderotherhistory>();
        label20:
            try
            {

                nextPageUrl = hostUrl + "agency/report-ag.php?acc=bwt_" + betAccountOrderHistory.agent.AgentName + "&dts=" + betAccountOrderHistory.startTime.ToString("yyyy-MM-dd").Replace("-", "/") + "&dte=" + betAccountOrderHistory.endTime.ToString("yyyy-MM-dd").Replace("-", "/") + "&reporttype=ledger&cc=all&bettype=all&upline=&outright=all";
                request = (HttpWebRequest)WebRequest.Create(nextPageUrl);
                request.Method = "GET";
                request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/msword, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, */*";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
                request.KeepAlive = true;
                request.AllowAutoRedirect = true;
                request.Headers["Cookie"] = betAccountOrderHistory.agent.Cookie;
                request.Headers.Add("Cache-Control", "no-cache");
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
                if (content.Contains("<tr class=\"hover\">"))
                {
                    //string html = pub.substring(content, "<table", "</table>");
                    //html = pub.substring2(html, "<tr>", "</tr>");
                    //html = pub.substring2(html, "<tr>", "</tr>");
                    //html = pub.substring2(html, "<tr>", "</tr>");

                    foreach (Betaccount account in betAccountOrderHistory.account)
                    {

                        if (content.Contains(account.Userid))
                        {
                            try
                            {
                                BetAccountOrderMoney betAccountOrderMoney = new BetAccountOrderMoney();
                                betAccountOrderMoney.WebAgentName = account.Agent;
                                betAccountOrderMoney.WebUserName = account.Userid;
                                betAccountOrderMoney.OwnerOrderCount = betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == betAccountOrderMoney.WebUserName).Count();
                                betAccountOrderMoney.OwnerTotalBetMoney = betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == betAccountOrderMoney.WebUserName).Select(n => n.Value.Amount).Sum();
                                betAccountOrderMoney.OwnerResultMoney = betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == betAccountOrderMoney.WebUserName).Select(n => n.Value.Result).Sum();

                                tr = pub.substring(content, account.Userid, "</tr>");
                                sar = tr.Split(new string[] { "/td>" }, StringSplitOptions.None);
                                betAccountOrderMoney.WebsiteOrderCount = Convert.ToInt32(pub.substring(sar[2], "<td>", "<"));
                                betAccountOrderMoney.AccountAddress = pub.substring(sar[3], "<a href=\"", "\">");
                                betAccountOrderMoney.WebsiteTotalBetMoney = Convert.ToDecimal(pub.substring(sar[3], "\">", "<").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", ""));
                                betAccountOrderMoney.WebsiteResultMoney = Convert.ToDecimal(pub.substring(sar[5], "\">", "<"));
                                finalStatsDic.Add(betAccountOrderMoney.WebUserName, betAccountOrderMoney);
                            }
                            catch
                            { }
                        }
                        
                    }
                    foreach (KeyValuePair<string, BetAccountOrderMoney> item in finalStatsDic)
                    {
                        try
                        {
                            if (dicOwner == null)
                            {
                                dicOwner = new Dictionary<string, Orderotherhistory>();
                            }
                            else
                            {
                                dicOwner.Clear();
                            }
                            if (dicAgent == null)
                            {
                                dicAgent = new Dictionary<string, Orderotherhistory>();
                            }
                            else
                            {
                                dicAgent.Clear();
                            }
                            if (item.Value.WebAgentName == betAccountOrderHistory.agent.AgentName)
                            {
                                //我们数据库的订单
                                dicOwner = GetDicByAccount(item.Key, betAccountOrderHistory.OrderOtherHistorys);
                                if (!string.IsNullOrEmpty(item.Value.AccountAddress))
                                {
                                    //代理网站的订单
                                    dicAgent = Bw3388CheckHistoryReportDetails(betAccountOrderHistory, item.Value);
                                    Thread.Sleep(1000);
                                }
                                else
                                {
                                    if (betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == item.Key).Count() > 0)
                                    {
                                        Dictionary<string, Orderotherhistory> dic = null;
                                        foreach (KeyValuePair<string, Orderotherhistory> items in betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == item.Key).ToList())
                                        {
                                            dic = new Dictionary<string, Orderotherhistory>();
                                            dic.Add(items.Value.WebOrderID, items.Value);
                                        }
                                        finalDetailDic.Add(item.Key, dic);
                                    }
                                }
                                Dictionary<string, Orderotherhistory> dicTemp = new Dictionary<string, Orderotherhistory>();
                                try
                                {
                                    dicTemp = CheckError(dicOwner, dicAgent);
                                }
                                catch
                                { }
                                if (!finalDetailDic.ContainsKey(item.Key))
                                {
                                    if (dicTemp.Count > 0)
                                        finalDetailDic.Add(item.Key, dicTemp);
                                }
                            }
                        }
                        catch
                        { }
                    }
                    foreach (KeyValuePair<string, Dictionary<string, Orderotherhistory>> items in finalDetailDic)
                    {
                        finalStatsDic[items.Key].IsErrorData = items.Value.Count > 0 ? 1 : 0;
                    }
                }
                else
                {
                    if (count < 5)
                    {
                        count++;
                        goto label20;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                if (count < 5)
                {
                    count++;
                    goto label20;
                }
                else
                {
                    return;
                }
            }
            finally
            {
                try
                {
                    response.Close();
                }
                catch { }
                try { reader.Close(); }
                catch { }
                try { if (stream != null) stream.Close(); }
                catch { }
            }
        }
        private static Dictionary<string, Orderotherhistory> Bw3388CheckHistoryReportDetails(BetAccountOrderHistory betAccountOrderHistory, BetAccountOrderMoney betAccountOrderMoney)
        {
            Dictionary<string, Orderotherhistory> dic = new Dictionary<string, Orderotherhistory>();
            Encoding big5 = Encoding.GetEncoding("big5");
            string hostUrl = "http://" + betAccountOrderHistory.agent.Address + "/";//域名
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            int count = 0;
            //订单数量
            int orderCounts = 0;
            string nextPageUrl = string.Empty;
            string content = string.Empty;
            string tr = string.Empty;
            string td = string.Empty;
        label20:
            try
            {
                nextPageUrl = hostUrl + "agency/" + betAccountOrderMoney.AccountAddress;
                request = (HttpWebRequest)WebRequest.Create(nextPageUrl);
                request.Method = "GET";
                request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/msword, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, */*";
                request.Referer = hostUrl + "agency/report-ag.php?acc=bwt_" + betAccountOrderHistory.agent.Name + "&dts=" + betAccountOrderHistory.startTime.ToString("MM-dd-yyyy").Replace("-", "/") + "&dte=" + betAccountOrderHistory.endTime.ToString("MM-dd-yyyy").Replace("-", "/") + "&reporttype=soccer&cc=all&bettype=all&upline=&outright=all";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
                request.KeepAlive = true;
                request.AllowAutoRedirect = false;
                request.Headers["Cookie"] = betAccountOrderHistory.agent.Cookie;
                request.Headers.Add("Cache-Control", "no-cache");
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
                if (content.Contains("注單"))
                {
                    content = pub.substring(content, "<table", "</table>");
                    content = pub.substring2(content, "<tr>", "</tr>");
                    while (content.Contains("<tr class='hover"))
                    {
                        Orderotherhistory order1 = new Orderotherhistory();
                        try
                        {
                            orderCounts++;
                            tr = pub.substring(content, "</td>", "</tr>");

                            string time1 = pub.substring(tr, "<td>", "<br/>").Replace("AM", "").Replace("PM", "").Replace(" ", "").Trim();
                            time1 = time1.Substring(6, 4) + "-" + time1.Substring(3, 2) + "-" + time1.Substring(0, 2);
                            string time2 = pub.substring(tr, "<br/>", "</td>").Replace("AM", "").Replace("PM", "").Trim();
                            order1.Time = Convert.ToDateTime(time1 + " " + time2);

                            tr = pub.substring2(tr, "<td", "</td>");
                            order1.WebUserName = pub.substring(tr, "<td>", "&nbsp;").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("&nbsp;", "").Replace(" ", "").Trim();
                            tr = pub.substring2(tr, "<td", "</td>");

                            time1 = pub.substring(tr, "<td>", "<BR>").Replace("PM", "").Replace(" ", "").Trim();
                            time1 = time1.Substring(6, 4) + "-" + time1.Substring(3, 2) + "-" + time1.Substring(0, 2);
                            time2 = pub.substring(tr, "<BR>", "</td>").Replace("AM", "").Replace("PM", "").Replace(" ", "").Trim();
                            order1.BeginTime = Convert.ToDateTime(time1 + " " + time2);

                            tr = pub.substring2(tr, "<td", "</td>");
                            string betType = pub.substring(tr, "<td>", "<br>");
                            order1.WebOrderID = pub.substring(tr, "<br>", "<br></td>").Replace("ROUHT", "").Replace("RAHHT", "").Replace("OUHT", "").Replace("AHHT", "").Replace("1X2", "").Replace("ROU", "").Replace("RAH", "").Replace("AH", "").Replace("OU", "").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("&nbsp;", "").Replace(" ", "").Trim();
                            tr = pub.substring2(tr, "<td", "</td>");
                            td = pub.substring(tr, "<td class=\"tdR\">", "/td>");
                            order1.Leaguetw = pub.substring(td, ">", "</span").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("&nbsp;", "").Replace(" ", "").Trim(); ;
                            td = pub.substring2(td, "<span", "</span>");
                            if (td.Contains("<span class='score'>"))
                            {
                                td = "<br>" + pub.substring2(td, "<span class='score'>", "</span>");
                            }
                            if (tr.Contains("<span style=\"color:red;\">"))
                            {
                                order1.Score = pub.substring(tr, "<span style=\"color:red;\">", "<").Replace("-", ":").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("&nbsp;", "").Replace(" ", "").Trim();
                            }
                            order1.BetItem = pub.substring(td, "<span class='teambet'>", "</span>").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("&nbsp;", "").Replace(" ", "").Trim();
                            if (!pub.substring(td, "<span class='hdp'>", "</span>").Contains("VS"))
                            {
                                string temp = pub.substring(td, "<br", "<span").Replace("&nbsp;", "");
                                order1.Handicap = pub.substring(td, "'>", "</span>").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("&nbsp;", "").Replace(" ", "").Trim(); ;
                                if (!string.IsNullOrEmpty(order1.Handicap))
                                {
                                    if (order1.Handicap.Contains("/"))
                                    {
                                        string[] strArr = order1.Handicap.Split('/');
                                        order1.Handicap = ((Convert.ToDouble(strArr[0]) + Convert.ToDouble(strArr[1])) / 2).ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("&nbsp;", "").Replace(" ", "").Trim();
                                    }
                                }
                                if (temp.Contains("(H)"))
                                {
                                    order1.Hometw = pub.substring(temp, ">", "(").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "").Trim();
                                    order1.Awaytw = pub.substring(td, "</span>", "<br>").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("&nbsp;", "").Replace(" ", "").Trim();
                                    if (betType.Contains("讓球"))
                                    {
                                        if (order1.Handicap != "0")
                                        {
                                            if (order1.BetItem == order1.Hometw)
                                            {
                                                order1.Handicap = "-" + order1.Handicap;
                                            }
                                        }
                                    }
                                }
                                else if (temp.Contains("(客)"))
                                {
                                    order1.Score = "|" + order1.Score + "|";
                                    order1.Score = pub.substring(order1.Score, ":", "|") + ":" + pub.substring(order1.Score, "|", ":");
                                    order1.Awaytw = pub.substring(temp, ">", "(").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "").Trim(); ;
                                    order1.Hometw = pub.substring(td, "</span>", "<br>").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("&nbsp;", "").Replace(" ", "").Trim();
                                    if (betType.Contains("讓球"))
                                    {
                                        if (order1.Handicap != "0")
                                        {
                                            if (order1.BetItem == order1.Awaytw)
                                            {
                                                order1.Handicap = "-" + order1.Handicap;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    order1.Hometw = pub.substring(temp, ">", "(").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "").Trim();
                                    order1.Awaytw = pub.substring(td, "</span>", "<br>").Replace("(中)", "").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("&nbsp;", "").Replace(" ", "").Trim();
                                    if (betType.Contains("讓球"))
                                    {
                                        if (order1.Handicap != "0")
                                        {
                                            if (order1.BetItem == order1.Hometw)
                                            {
                                                order1.Handicap = "-" + order1.Handicap;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                string temp = pub.substring(td, "<br", "<span").Replace("&nbsp;", "");
                                order1.Hometw = pub.substring(temp, ">", "(").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "").Trim();
                                order1.Awaytw = pub.substring(td, "</span>", "<br>").Replace("(中)", "").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("&nbsp;", "").Replace(" ", "").Trim();
                            }
                            order1.Odds = Convert.ToDecimal(pub.substring(td, "<span class='odds'>", "</span>").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("&nbsp;", "").Replace(" ", "").Trim());
                            if (order1.BetItem.Contains("<strong>"))
                            {
                                order1.Handicap = pub.substring(order1.BetItem, "<strong>", "</strong>");
                                if (!string.IsNullOrEmpty(order1.Handicap))
                                {
                                    if (order1.Handicap.Contains("/"))
                                    {
                                        string[] strArr = order1.Handicap.Split('/');
                                        order1.Handicap = ((Convert.ToDouble(strArr[0]) + Convert.ToDouble(strArr[1])) / 2).ToString().Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("&nbsp;", "").Replace(" ", "").Trim();
                                    }
                                }
                                order1.BetItem = order1.BetItem.Substring(0, 1);
                            }
                            tr = pub.substring2(tr, "<td", "</td>");
                            tr = pub.substring2(tr, "<td", "</td>");
                            if (order1.Score != "X-X")
                            {
                                string amount = string.Empty;
                                string result = string.Empty;
                                amount = pub.substring(tr, "<td class=\"tdR\">", "</td>").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("&nbsp;", "").Replace(" ", "").Trim() == "-" ? "0" : pub.substring(tr, "<td class=\"tdR\">", "</td>").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("&nbsp;", "").Replace(" ", "").Trim();
                                order1.Amount = Convert.ToDecimal(amount);
                                if (tr.Contains("不接受"))
                                {
                                    order1.ErrorMessage = "代理网站不接受此注单，";
                                }
                                else if (tr.Contains("球賽取消"))
                                {
                                    order1.ErrorMessage = "代理网站此球賽取消,";
                                }
                                else
                                {
                                    tr = pub.substring2(tr, "<td", "</td>");
                                    tr = pub.substring2(tr, "<td", "</td>");
                                    result = tr.Contains("<font style='color:red'>") ? pub.substring(tr, "<font style='color:red'>", "</font></td>").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("&nbsp;", "").Replace(" ", "").Trim() : pub.substring(tr, "<td class=\"tdR\">", "</td>").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace("&nbsp;", "").Replace(" ", "").Trim();
                                    result = result == "-" ? "0" : result;
                                    order1.Result = Convert.ToDecimal(result);
                                }
                            }
                            
                            content = pub.substring2(content, "<tr class='hover", "</tr>");
                        }
                        catch(Exception e)
                        { }
                        try
                        {
                            if (order1.WebOrderID != null)
                            {
                                dic.Add(order1.WebOrderID, order1);
                            }
                            else
                            {
                                order1.ErrorMessage = "代理网站没有读取到注单号";
                                dic.Add(DateTime.Now.Ticks.ToString(), order1);
                            }
                        }
                        catch
                        { }
                    }
                    finalStatsDic[betAccountOrderMoney.WebUserName].WebsiteOrderCount = orderCounts;
                }
                else
                {
                    if (count < 5)
                    {
                        count++;
                        goto label20;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                if (count < 5)
                {
                    count++;
                    goto label20;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                try
                {
                    response.Close();
                }
                catch { }
                try { reader.Close(); }
                catch { }
                try { if (stream != null) stream.Close(); }
                catch { }
            }
            return dic;
        }

        // LiJi 历史查询核对
        private static void LiJiHistoryReport(BetAccountOrderHistory betAccountOrderHistory)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            Stream stream = null;
            string url = string.Empty;
            string html = string.Empty;
            string tmpId = string.Empty;
            string teamp = string.Empty;
            string custId = string.Empty;
            string[] itemStr = null;
            byte[] bytes;
            
            int errCon = 0;
            string p = null, ek = null, mode = null, ids = null;
            BetAccountOrderMoney betAccountOrderMoney = null;
            //我们数据库的订单
            Dictionary<string, Orderotherhistory> dicOwner = new Dictionary<string, Orderotherhistory>();
            //代理网站的订单
            Dictionary<string, Orderotherhistory> dicAgent = new Dictionary<string, Orderotherhistory>();
        label10:
            try
            {
                try
                {
                    url = "http://" + betAccountOrderHistory.agent.Address2 + "/webroot/restricted/report2/winlost.aspx";
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/msword, application/vnd.ms-excel, application/vnd.ms-powerpoint, */*";
                    request.Referer = "http://" + betAccountOrderHistory.agent.Address2 + "/webroot/restricted/homeleft.aspx";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.ServicePoint.ConnectionLimit = 50;
                    request.Headers["Cookie"] = betAccountOrderHistory.agent.Cookie;
                    request.AllowAutoRedirect = false;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    }
                    else
                    {
                        stream = response.GetResponseStream();
                    }
                    reader = new StreamReader(stream, utf8);
                    html = reader.ReadToEnd();
                    p = pub.substring(pub.substring(html, "id=\"p", "/>"), "value=\"", "\"").Trim();
                    if (p == null)
                    {
                        if (errCon < 3)
                        {
                            errCon++;
                            goto label10;
                        }
                        else
                        {
                            return;
                        }
                    }
                    ek = pub.substring(pub.substring(html, "id=\"ek", "/>"), "value=\"", "\"").Trim();
                    mode = "1";
                    ids = pub.substring(html, "name=\"ids\"", "/");
                }
                catch (Exception ee)
                {
                    if (errCon < 3)
                    {
                        errCon++;
                        goto label10;
                    }
                    else
                    {
                        return;
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
            url = "http://" + betAccountOrderHistory.agent.Address2 + "/webroot/restricted/report2/report_frame.aspx";
            try
            {
                try
                {
                    string data = "p=" + p + "&ek=" + ek + "&mode=" + mode + "&ids=&product=1&dpFrom=" + betAccountOrderHistory.startTime.ToString("MM-dd-yyyy").Replace("-", "%2F") + "&dpTo=" + betAccountOrderHistory.endTime.ToString("MM-dd-yyyy").Replace("-", "%2F");
                    bytes = Encoding.ASCII.GetBytes(data);
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "POST";
                    request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/msword, application/vnd.ms-excel, application/vnd.ms-powerpoint, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers.Add("Accept-Encoding", "gzip, deflate");
                    request.ContentLength = bytes.Length;
                    request.KeepAlive = true;
                    request.Headers["Cookie"] = betAccountOrderHistory.agent.Cookie;
                    request.AllowAutoRedirect = true;
                    request.Headers.Add("Cache-Control", "no-cache");
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
                    if (html.Contains("f(["))
                    {
   
                        try
                        {
                            foreach (Betaccount account in betAccountOrderHistory.account)
                            {
                                try
                                {
                                    if (html.Contains(account.Userid))
                                    {
                                        betAccountOrderMoney = new BetAccountOrderMoney();
                                        betAccountOrderMoney.WebAgentName = account.Agent;
                                        betAccountOrderMoney.WebUserName = account.Userid;
                                        betAccountOrderMoney.OwnerOrderCount = betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == betAccountOrderMoney.WebUserName).Count();
                                        betAccountOrderMoney.OwnerTotalBetMoney = betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == betAccountOrderMoney.WebUserName).Select(n => n.Value.Amount).Sum();
                                        betAccountOrderMoney.OwnerResultMoney = betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == betAccountOrderMoney.WebUserName).Select(n => n.Value.Result).Sum();
                                        teamp = pub.substring(html, "f([", account.Userid);
                                        teamp = teamp.Substring(teamp.LastIndexOf("r"));
                                        betAccountOrderMoney.WebOrderCustId1 = pub.substring(teamp, ",'", "',");
                                        itemStr = pub.substring(html, account.Userid, "])").Replace("','", "$").Split('$');
                                        betAccountOrderMoney.WebUserName = account.Userid;
                                        betAccountOrderMoney.WebsiteTotalBetMoney = Convert.ToDecimal(itemStr[1].Replace(",", "").Trim());
                                        betAccountOrderMoney.WebsiteResultMoney = Convert.ToDecimal(itemStr[3].Replace(",", "").Trim()) - Convert.ToDecimal(itemStr[2].Replace(",", "").Trim());
                                        finalStatsDic.Add(betAccountOrderMoney.WebUserName, betAccountOrderMoney);
                                    }
                                }
                                catch
                                { }
                            }
                            foreach (KeyValuePair<string, BetAccountOrderMoney> item in finalStatsDic)
                            {
                                try
                                {
                                    if (dicOwner == null)
                                    {
                                        dicOwner = new Dictionary<string, Orderotherhistory>();
                                    }
                                    else
                                    {
                                        dicOwner.Clear();
                                    }
                                    if (dicAgent == null)
                                    {
                                        dicAgent = new Dictionary<string, Orderotherhistory>();
                                    }
                                    else
                                    {
                                        dicAgent.Clear();
                                    }
                                    if (item.Value.WebAgentName == betAccountOrderHistory.agent.AgentName)
                                    {
                                        //我们数据库的订单
                                        dicOwner = GetDicByAccount(item.Key, betAccountOrderHistory.OrderOtherHistorys);
                                        dicAgent = LiJiHistoryReportDetail(betAccountOrderHistory, item.Value, ek, p, mode);
                                        //if (betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == item.Key).Count() > 0)
                                        //{
                                        //    Dictionary<string, Orderotherhistory> dic = new Dictionary<string, Orderotherhistory>();
                                        //    foreach (KeyValuePair<string, Orderotherhistory> items in betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == item.Key).ToList())
                                        //    {
                                        //        dic.Add(items.Value.WebOrderID, items.Value);
                                        //    }
                                        //    finalDetailDic.Add(item.Key, dic);
                                        //}
                                        Dictionary<string, Orderotherhistory> dicTemp = new Dictionary<string, Orderotherhistory>();
                                        try
                                        {
                                            dicTemp = CheckError(dicOwner, dicAgent);
                                        }
                                        catch (Exception e)
                                        { }
                                        if (!finalDetailDic.ContainsKey(item.Key))
                                        {
                                            if (dicTemp.Count > 0)
                                                finalDetailDic.Add(item.Key, dicTemp);
                                        }
                                    }
                                }
                                catch
                                { }
                            }
                            foreach (KeyValuePair<string, Dictionary<string, Orderotherhistory>> items in finalDetailDic)
                            {
                                finalStatsDic[items.Key].IsErrorData = items.Value.Count > 0 ? 1 : 0;
                            }
                        }
                        catch
                        {
                            return;
                        }
                    }
                    else
                    {
                        //display("代理" + agent.agentid + "暂无历史记录" + System.DateTime.Now);
                    }
                }
                catch (Exception ee)
                {
                    if (errCon < 5)
                    {
                        errCon++;
                        goto label10;
                    }
                    else
                    {
                        return;
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
        }
        private static Dictionary<string, Orderotherhistory> LiJiHistoryReportDetail(BetAccountOrderHistory betAccountOrderHistory, BetAccountOrderMoney betAccountOrderMoney, string ek, string p, string mode)
        {
            Dictionary<string, Orderotherhistory> dic = new Dictionary<string, Orderotherhistory>();
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            Stream stream = null;
            string url = string.Empty;
            string html = string.Empty;
            string betType = string.Empty;
            string[] item = null;
            byte[] bytes;
            int count = 0;
            int count2 = 0;
            url = "http://" + betAccountOrderHistory.agent.Address2 + "/webroot/restricted/report2/betlist_frame.aspx";
        label10:
            try
            {
                try
                {
                    bytes = Encoding.ASCII.GetBytes("p=" + p + "&ek=" + ek + "&mode=" + mode + "&ids=" + betAccountOrderMoney.WebOrderCustId1 + "&dpFrom=" + betAccountOrderHistory.startTime.ToString("MM-dd-yyyy").Replace("-", "%2F") + "&dpTo=" + betAccountOrderHistory.endTime.ToString("MM-dd-yyyy").Replace("-", "%2F"));
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "POST";
                    request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/msword, application/vnd.ms-excel, application/vnd.ms-powerpoint, */*";
                    request.Headers.Add("Accept-Language", "zh-cn");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers.Add("Accept-Encoding", "gzip, deflate");
                    request.ContentLength = bytes.Length;
                    request.KeepAlive = true;
                    request.Headers["Cookie"] = betAccountOrderHistory.agent.Cookie;
                    request.AllowAutoRedirect = false;
                    request.Headers.Add("Cache-Control", "no-cache");
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
                    count2 = 0;
                    html = pub.substring(html, "var d=[];", "parent.showData(d);");
                    if (html.IndexOf("f([") == -1 || html == null)
                    {
                        return null;
                    }
                    while (html.IndexOf("=f(") > -1)
                    {
                       
                        count2++;
                        Orderotherhistory order1 = new Orderotherhistory();
                        try
                        {
                            count = 0;
                            item = pub.substring(html, "=f(", "])").Replace("],[", ",'").Replace(",[", ",").Replace("],", "',").Replace("','", "$").Split('$');

                            if (item[0].Contains("'n"))
                            {
                                //order1.xm = item[1].Replace("'", "").Trim();
                                order1.Handicap = item[2].Replace("'", "").Trim();
                                if (item[4].Replace("'", "").Replace(" ", "") == "")
                                {
                                    betType = "";
                                    order1.BetType = item[3].Trim();
                                }
                                else
                                {
                                    // = item[3] + item[4].Split('!')[0].Replace("'", "").Replace(" ", "");
                                    order1.BetType = item[3];
                                    betType = item[4].Split('!')[0].Replace("'", "").Replace(" ", "");
                                    //order1.Score = item[4].Split('!')[1].Replace(" ", "").Trim();
                                }
                                order1.Hometw = item[5].Trim();
                                order1.Awaytw = item[6].Trim();
                                order1.Leaguetw = item[7].Trim();
                                order1.BeginTime = pub.getTime(item[8].Replace("'", "").Trim() + " 12:00:00");
                                order1.WebOrderID = item[11].Replace("i", "").Trim();
                                order1.Time = pub.getTime(item[13] + " " + item[14].Replace(",", "").Replace("'", "").Trim());
                                order1.Odds = Convert.ToDecimal(item[15].Trim());
                                //order1.handicaptype = item[16].Trim();
                                order1.Amount = Convert.ToDecimal(item[17].Replace(",", "").Trim());
                                order1.ValidAmount = Convert.ToDecimal(item[18].Replace(",", "").Trim());
                                order1.Score = item[20].Replace("FT", "").Replace(" ", "");
                                order1.Scorehalf = item[21].Replace("HT", "").Replace(" ", "");
                                if (item[19].Contains("<span"))
                                {
                                    order1.Betflag = pub.substring(item[19], ">", "<").Trim();
                                }
                                else
                                    order1.Betflag = item[19].Trim();
                                order1.Result = Convert.ToDecimal(item[22].Replace("'", "").Replace(",", "").Trim());
                            }
                            else if (item[0].Contains("'mp"))
                            {
                                //混合过关
                                while (true)
                                {
                                    if (item[count].Contains(betAccountOrderMoney.WebAgentName))
                                    {
                                        count++;
                                        break;
                                    }
                                    else
                                        count++;
                                }
                                order1.WebOrderID = item[count].Trim();
                                order1.BetType = item[count + 1].Trim();
                                order1.Time = pub.getTime(item[count + 2] + " " + item[count + 3]);
                                order1.BeginTime = order1.Time;
                                order1.Odds = Convert.ToDecimal(item[count + 4].Trim());
                                //order1.handicaptype = item[count + 5].Trim();
                                order1.OddsType = item[count + 5].Trim();
                                order1.Amount = Convert.ToDecimal(item[count + 7].Replace(",", "").Trim());
                                //total_je += Convert.ToDouble(order1.je);
                                if (item[count + 8].Contains("<span"))
                                {
                                    order1.Betflag = pub.substring(item[count + 8], ">", "<").Trim();
                                }
                                else
                                {
                                    order1.Betflag = item[count + 8].Trim();
                                }
                                order1.Result = Convert.ToDecimal(item[count + 11].Replace(",", "").Trim());
                            }
                            else if (item[0].Contains("'or"))
                            {
                                //优胜冠军
                                //order1.xm = item[1].Replace("'", "").Trim();
                                order1.BetType = item[2].Trim();
                                order1.Leaguecn = item[3].Trim();
                                order1.WebOrderID = item[6].Trim();
                                order1.Time = pub.getTime(item[8] + " " + item[9]);
                                order1.Odds = Convert.ToDecimal(item[10].Trim());
                                order1.Handicap = item[11].Replace("'", "").Trim();
                                order1.Amount = Convert.ToDecimal(item[13].Replace(",", "").Trim());
                                if (item[14].Contains("<span"))
                                {
                                    order1.Betflag = pub.substring(item[14], ">", "<").Trim();
                                }
                                else
                                    order1.Betflag = item[14].Trim();
                                order1.Result = Convert.ToDecimal(item[17].Replace(",", "").Trim());
                            }

                            switch (order1.Betflag)
                            {
                                case "Lose":
                                case "輸": order1.Betflag = "-1";
                                    break;
                                case "Won":
                                case "贏": order1.Betflag = "1";
                                    break;
                                case "Draw":
                                case "和局": order1.Betflag = "0";
                                    break;
                                case "危險作廢":
                                case "作廢":
                                case "取消":
                                    order1.ErrorMessage = "代理注单：" + order1.Betflag + ";";
                                    order1.Betflag = "-2";
                                    break;
                                default:
                                    order1.ErrorMessage = "代理注单：" + order1.Betflag + ";";
                                    order1.Betflag = "-2";
                                    break;
                            }

                            if (betType.Contains("滾球"))
                            {
                                switch (order1.BetType)
                                {
                                    case "&#19978;&#21322;&#22580;&#22823;&#23567;":                //上半场大小
                                        order1.BetType = "7";
                                        break;
                                    case "&#19978;&#21322;&#22580;1X2":                            //上半場1X2 
                                        order1.BetType = "15";
                                        break;
                                    case "&#22823;&#23567;&#30436;":                                //全场大小盤
                                        order1.BetType = "5";
                                        break;
                                    case "&#20126;&#27954;&#30436;":                                //让球盘
                                        order1.BetType = "4";
                                        break;
                                    case "1X2":                                                     //全场标准盘
                                        order1.BetType = "14";
                                        break;
                                    case "&#19978;&#21322;&#22580;&#20126;&#27954;&#30436;":        //上半場让球盘
                                        order1.BetType = "6";
                                        break;
                                }
                            }
                            else
                            {
                                switch (order1.BetType)
                                {
                                    case "&#19978;&#21322;&#22580;&#22823;&#23567;":                //早餐  单式  上半场大小
                                        order1.BetType = Convert.ToDateTime(order1.BeginTime.AddDays(1)) < Convert.ToDateTime(order1.Time) ? "11" : "3";
                                        break;
                                    case "&#19978;&#21322;&#22580;1X2":                            //早餐  单式   上半場1X2 
                                        order1.BetType = Convert.ToDateTime(order1.BeginTime.AddDays(1)) < Convert.ToDateTime(order1.Time) ? "17" : "13";
                                        break;
                                    case "&#22823;&#23567;&#30436;":                                //早餐  单式   全场大小盤
                                        order1.BetType = Convert.ToDateTime(order1.BeginTime.AddDays(1)) < Convert.ToDateTime(order1.Time) ? "9" : "1";
                                        break;
                                    case "&#20126;&#27954;&#30436;":                                // 早餐  单式  让球盘
                                        order1.BetType = Convert.ToDateTime(order1.BeginTime.AddDays(1)) < Convert.ToDateTime(order1.Time) ? "8" : "0";
                                        break;
                                    case "1X2":                                                     //早餐  单式  全场标准盘
                                        order1.BetType = Convert.ToDateTime(order1.BeginTime.AddDays(1)) < Convert.ToDateTime(order1.Time) ? "16" : "12";
                                        break;
                                    case "&#19978;&#21322;&#22580;&#20126;&#27954;&#30436;":        //早餐  单式  上半場让球盤
                                        order1.BetType = Convert.ToDateTime(order1.BeginTime.AddDays(1)) < Convert.ToDateTime(order1.Time) ? "10" : "2";
                                        break;
                                }
                            }
                        }
                        catch (Exception ee)
                        {
                            if (count < 3)
                            {
                                count++;
                                goto label10;
                            }
                            else
                            {
                                return null;
                            }
                        }
                        html = pub.substring2(html, "=f(", "])");
                        order1.WebUserName = betAccountOrderMoney.WebUserName;
                        try
                        {
                            if (order1.WebOrderID != null)
                            {
                                dic.Add(order1.WebOrderID, order1);
                            }
                            else
                            {
                                order1.ErrorMessage = "代理网站没有读取到注单号";
                                dic.Add(DateTime.Now.Ticks.ToString(), order1);
                            }
                        }
                        catch
                        { }
                    }
                    betAccountOrderMoney.WebsiteOrderCount = count2;
                }
                catch
                {
                    if (count < 3)
                    {
                        count++;
                        goto label10;
                    }
                    else
                    {
                        return null;
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
            return dic;
        }

        // ShaBa 历史查询核对
        private static void ShaBaHistoryReport(BetAccountOrderHistory betAccountOrderHistory)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            Stream stream = null;
            string url;
            string html = string.Empty;
            string custid = string.Empty;
            string content = string.Empty;
            string tr = string.Empty;
            string td = string.Empty;
            string[] sar;
            int count = 0;
            int errCon = 0;
            //我们数据库的订单
            Dictionary<string, Orderotherhistory> dicOwner = new Dictionary<string, Orderotherhistory>();
            //代理网站的订单
            Dictionary<string, Orderotherhistory> dicAgent = new Dictionary<string, Orderotherhistory>();
            BetAccountOrderMoney betAccountOrderMoney = null;
        label10:
            try
            {
                try
                {
                    url = "http://" + betAccountOrderHistory.agent.Address2 + "/_Reports/Winloss/WinLossDetailAgent.aspx";
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, */*";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; 360SE)";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.ServicePoint.ConnectionLimit = 50;
                    request.Headers["Cookie"] = betAccountOrderHistory.agent.Cookie;
                    request.AllowAutoRedirect = false;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    }
                    else
                    {
                        stream = response.GetResponseStream();
                    }
                    reader = new StreamReader(stream, utf8);
                    html = reader.ReadToEnd();
                    //截取custid
                    custid = pub.substring(html, "id=\"CustId\" value=\"", "\"");
                }
                catch
                {
                    if (errCon < 3)
                    {
                        errCon++;
                        goto label10;
                    }
                    else
                    {
                        return;
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
                    url = "http://" + betAccountOrderHistory.agent.Address2 + "/_Reports/Winloss/WinlossDetailAgent.aspx?fdate=" + betAccountOrderHistory.startTime.ToString("MM-dd-yyyy").Replace("-", "%2F") + "&tdate=" + betAccountOrderHistory.endTime.ToString("MM-dd-yyyy").Replace("-", "%2F") + "&chk_all=on&chk_showsb=on&chk_showrb=on&chk_showng=on&FilterPostback=postback&CustId=" + custid + "&IsHistoryReport=0&IsSwitch=0&OldView=0&UserName=&Type=WLByDate&WorkOnOldBetList=1";
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, */*";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; 360SE)";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.Headers["Cookie"] = betAccountOrderHistory.agent.Cookie;
                    request.AllowAutoRedirect = false;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    }
                    else
                    {
                        stream = response.GetResponseStream();
                    }
                    reader = new StreamReader(stream, utf8);
                    html = reader.ReadToEnd();
                    if (html.Contains("ViewDownlineWLReport("))
                    {
                        try
                        {
                            foreach (Betaccount account in betAccountOrderHistory.account)
                            {
                                if(html.IndexOf(account.Userid) > -1)
                                {
                                    try
                                    {
                                        betAccountOrderMoney = new BetAccountOrderMoney();
                                        betAccountOrderMoney.WebAgentName = account.Agent;
                                        betAccountOrderMoney.WebUserName = account.Userid;
                                        betAccountOrderMoney.OwnerOrderCount = betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == betAccountOrderMoney.WebUserName).Count();
                                        betAccountOrderMoney.OwnerTotalBetMoney = betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == betAccountOrderMoney.WebUserName).Select(n => n.Value.Amount).Sum();
                                        betAccountOrderMoney.OwnerResultMoney = betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == betAccountOrderMoney.WebUserName).Select(n => n.Value.Result).Sum();
                                        td = pub.substring(html, "ViewDownlineWLReport(", account.Userid);
                                        td = td.Substring(td.LastIndexOf(betAccountOrderHistory.endTime.ToString("MM-dd-yyyy").Replace("-", "/")));
                                        betAccountOrderMoney.WebOrderCustId1 = pub.substring(td, ",'", "',");
                                        tr = pub.substring(html, account.Userid, "</tr>");
                                        sar = tr.Split(new string[] { "/td>" }, StringSplitOptions.None);
                                        //betAccountOrderMoney.WebsiteOrderCount = Convert.ToInt32(pub.substring(sar[1], "positive'>", "<"));
                                        betAccountOrderMoney.WebsiteTotalBetMoney = Convert.ToDecimal(pub.substring(sar[1], "<td>", "<"));
                                        betAccountOrderMoney.WebsiteResultMoney = Convert.ToDecimal(pub.substring(sar[3], "<td>", "<"));
                                        finalStatsDic.Add(betAccountOrderMoney.WebUserName, betAccountOrderMoney);
                                    }
                                    catch
                                    { }
                                }
                            }
                            foreach (KeyValuePair<string, BetAccountOrderMoney> item in finalStatsDic)
                            {
                                try
                                {
                                    if (dicOwner == null)
                                    {
                                        dicOwner = new Dictionary<string, Orderotherhistory>();
                                    }
                                    else
                                    {
                                        dicOwner.Clear();
                                    }
                                    if (dicAgent == null)
                                    {
                                        dicAgent = new Dictionary<string, Orderotherhistory>();
                                    }
                                    else
                                    {
                                        dicAgent.Clear();
                                    }
                                    if (item.Value.WebAgentName == betAccountOrderHistory.agent.AgentName)
                                    {
                                        dicOwner = GetDicByAccount(item.Key, betAccountOrderHistory.OrderOtherHistorys);
                                        dicAgent = ShabaHistoryReportDetail(betAccountOrderHistory, item.Value);
                                        //if (betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == item.Key).Count() > 0)
                                        //{
                                        //    Dictionary<string, Orderotherhistory> dic = new Dictionary<string, Orderotherhistory>();
                                        //    foreach (KeyValuePair<string, Orderotherhistory> items in betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == item.Key).ToList())
                                        //    {
                                        //        dic.Add(items.Value.WebOrderID, items.Value);
                                        //    }
                                        //    finalDetailDic.Add(item.Key, dic);
                                        //}

                                        Dictionary<string, Orderotherhistory> dicTemp = new Dictionary<string, Orderotherhistory>();
                                        dicTemp = CheckError(dicOwner, dicAgent);
                                        if (!finalDetailDic.ContainsKey(item.Key))
                                        {
                                            if (dicTemp.Count > 0)
                                                finalDetailDic.Add(item.Key, dicTemp);
                                        }
                                    }
                                }
                                catch
                                { }
                            }
                            foreach (KeyValuePair<string, Dictionary<string, Orderotherhistory>> items in finalDetailDic)
                            {
                                finalStatsDic[items.Key].IsErrorData = items.Value.Count > 0 ? 1 : 0;
                            }

                        }
                        catch (Exception e)
                        {
                            return;
                        }

                    }
                }
                catch (Exception ee)
                {
                    if (errCon < 5)
                    {
                        errCon++;
                        goto label10;
                    }
                    else
                    {
                        return;
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
        }
        private static Dictionary<string, Orderotherhistory> ShabaHistoryReportDetail(BetAccountOrderHistory betAccountOrderHistory, BetAccountOrderMoney betAccountOrderMoney)
        {
            Dictionary<string, Orderotherhistory> dic = new Dictionary<string, Orderotherhistory>();
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            Encoding utf8 = Encoding.UTF8;
            string url = string.Empty;
            string html = string.Empty;
            string content = string.Empty;
            string score=string.Empty;
            string[] item1 = null;
            string ss = string.Empty;
            int count = 0;
            int count2 = 0;
            int errCon = 0;
        label10:
            try
            {
                try
                {
                    url = "http://" + betAccountOrderHistory.agent.Address2 + "/BetList/BetList.aspx?custid=" + betAccountOrderMoney.WebOrderCustId1 + "&fdate=" + betAccountOrderHistory.startTime.ToString("MM-dd-yyyy") + "&tdate=" + betAccountOrderHistory.endTime.ToString("MM-dd-yyyy") + "&type=WLByDate&IsHistotyReport=&username=" + betAccountOrderMoney.WebAgentName + "&showSB=1&showCasino=undefined&showP2P=undefined&showHR=1&showFI=undefined";
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Headers["UA-CPU"] = "x86";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; 360SE)";
                    request.AllowAutoRedirect = false;
                    request.KeepAlive = true;
                    request.Headers["Cookie"] = betAccountOrderHistory.agent.Cookie;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    }
                    else
                    {
                        stream = response.GetResponseStream();
                    }
                    reader = new StreamReader(stream, utf8);
                    html = reader.ReadToEnd();
                    count2 = 0;
                    html = pub.ToUnicode(html).Replace("\r", "").Replace("\n", "").Replace("&nbsp;", "").Replace("<div class=\"FirstGoal\"></div>", "").Replace("<div class=\"LastGoal\"></div>", "");//取出页面上的小标签图片（F），（L）
                    if (html.Contains("class='RptTB'"))
                    {
                        html = pub.substring(html, "佣金</td></tr>", "<tr class='RptTB'");
                    }
                    else if (html.Contains("class='RptTB'"))
                    {
                        html = pub.substring(html, "Comm</td></tr>", "<tr class='RptTB'");
                    }
                    try
                    {
                        while (html.IndexOf("onclick=\"ViewBetSlip") > -1)
                        {
                            Orderotherhistory order1 = new Orderotherhistory();
                            try
                            {
                                count2++;
                                count = 0;
                                string mid = null;
                                string s = pub.substring(html, "<tr", "</tr>");
                                html = pub.substring2(html, "<tr", "</tr>");
                                order1.WebOrderID = pub.substring(s, "ViewBetSlip('", "'");
                                //result.begintime = getTime(date + " 02:00:00");
                                while (s.IndexOf("<td") > -1)
                                {

                                    content = pub.substring(s, "<td", "</td>");
                                    switch (count)
                                    {
                                        case 1:
                                            order1.Time = pub.getTime(pub.substring(content, "<span class=\"bl_time\">", "</span>"));
                                            break;
                                        case 2:

                                            if (s.Contains("id=\"spEvent{row}\""))
                                            {
                                                ss = pub.substring(content + "</>", "class=\"{class}\">", "</>");
                                                //result.xm = ConvertXm(substring(ss, ">", "<"));
                                                order1.Handicap = pub.substring(ss, "<font color='#606060'>", "<");
                                                if (ss.Contains("[") && ss.Contains("]"))
                                                {
                                                    score = pub.substring(ss, "[", "]").Replace("-", ":").Replace(" ", "");
                                                }
                                                order1.BetType = pub.substring(ss, "<div class=\"bl_btype b\">", "</div>");
                                                item1 = pub.substring(s, "<div class=\"bl_match\">", "</div>").Replace("-vs-", "$").Split('$');
                                                if (item1.Length >= 3)
                                                {
                                                    if (item1.Length == 4)
                                                    {
                                                        order1.Hometw = item1[0] + "-vs-" + item1[1];
                                                        order1.Awaytw = item1[2] + "-vs-" + item1[3];
                                                    }
                                                }
                                                else
                                                {
                                                    order1.Hometw = item1[0].Replace("(N)", "").Trim();
                                                    order1.Awaytw = item1[1].Trim();
                                                }
                                                order1.Leaguetw = pub.substring(ss, "class=\"bl_stype blue\">", "</div>").Replace("</span>", "").Replace("足球", "").Replace(" ", "").Trim();
                                            }
                                            else
                                            {
                                                ss = pub.substring(content + "</>", "</div>", "</>");
                                            }
                                            if (s.Contains("ViewResult('"))
                                                mid = pub.substring(s, "ViewResult('", "'").Trim();

                                            break;
                                        case 3:
                                            ss = pub.substring2(content, ">", "<");
                                            order1.Odds = Convert.ToDecimal(pub.substring(ss, ">", "<"));
                                            ss = ss.Substring(ss.IndexOf("<br />") + "<br />".Length);
                                            order1.OddsType = pub.substring(ss, ">", "<");
                                            break;
                                        case 4:
                                            order1.Amount = Convert.ToDecimal(content.Substring(content.IndexOf(">") + 1).Replace(",", "").Trim());
                                            break;
                                        case 5:
                                            ss = pub.substring(content, "<div>", "</div>");
                                            order1.Result = Convert.ToDecimal(pub.substring(ss, ">", "<").Replace(",", "").Trim());
                                            ss = pub.substring2(content, "<div>", "</div>");
                                            ss = pub.substring(ss, "<div>", "</div>");
                                            // result.hy = substring(ss, ">", "<").Replace(",", "").Trim();
                                            break;
                                        case 6:
                                            order1.Betflag = pub.substring(content, "<div class=\"bl_status\">", "</div>");
                                            //result.ip = substring(content, "<br />", "</div>");
                                            //result.ip = substring(result.ip, ">", "<");
                                            switch (order1.Betflag)
                                            {
                                                case "輸":
                                                    order1.Betflag = "-1";
                                                    break;
                                                case "贏":
                                                    order1.Betflag = "1";
                                                    break;
                                                case "和":
                                                    order1.Betflag = "0";
                                                    break;
                                                case "作廢":
                                                case "危險作廢":
                                                case "腰斬":
                                                case "取消":
                                                case "退款":
                                                    order1.ErrorMessage = "代理注单：" + order1.Betflag + ";";
                                                    order1.Betflag = "-2";
                                                    break;
                                                default:
                                                    order1.ErrorMessage = "代理注单：" + order1.Betflag + ";";
                                                    order1.Betflag = "-2";
                                                    break;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    if (score != "")
                                    {
                                        switch (order1.BetType)
                                        {
                                            case "上半場大小盤":
                                                order1.BetType = "7";
                                                break;
                                            case "大小盤":
                                                order1.BetType = "5";
                                                break;
                                            case "上半場讓球":
                                                order1.BetType = "6";
                                                break;
                                            case "讓球":
                                                order1.BetType = "4";
                                                break;
                                            case "上半場.標準盤":
                                                order1.BetType = "15";
                                                break;
                                            case "全場.標準盤":
                                                order1.BetType = "14";
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        switch (order1.BetType)
                                        {
                                            case "上半場大小盤":
                                                order1.BetType = "7";
                                                break;
                                            case "大小盤":
                                                order1.BetType = "5";
                                                break;
                                            case "上半場讓球":
                                                order1.BetType = "6";
                                                break;
                                            case "讓球":
                                                order1.BetType = "4";
                                                break;
                                            case "上半場.標準盤":
                                                order1.BetType = "15";
                                                break;
                                            case "全場.標準盤":
                                                order1.BetType = "14";
                                                break;
                                        }
                                    }

                                    count++;
                                    s = pub.substring2(s, "<td", "</td>");
                                }
                               
                                order1.WebUserName = betAccountOrderMoney.WebUserName;
                               

                            }
                            catch (Exception ee)
                            {
                               
                            }
                            try
                            {
                                if (order1.WebOrderID != null)
                                {
                                    dic.Add(order1.WebOrderID, order1);
                                }
                                else
                                {
                                    order1.ErrorMessage = "代理网站没有读取到注单号";
                                    dic.Add(DateTime.Now.Ticks.ToString(), order1);
                                }
                            }
                            catch
                            { }
                        }
                        betAccountOrderMoney.WebsiteOrderCount = count2;
                    }
                    catch
                    {
                        if (errCon < 3)
                        {
                            errCon++;
                            goto label10;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch (Exception ee)
                {
                    if (errCon < 3)
                    {
                        errCon++;
                        goto label10;
                    }
                    else
                    {
                        return null;
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
            return dic;
        }

        // YongLiGao 历史查询核对
        private static void YongLiGaoHistoryReport(BetAccountOrderHistory betAccountOrderHistory)
        {
            Encoding big5 = Encoding.GetEncoding("big5");
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            string url = string.Empty;
            string html = string.Empty;
            string tr = string.Empty;
            string td = string.Empty;
            string custid = string.Empty;
            string content = string.Empty;
            string[] sar;
            int count = 0;
            int errCon = 0;
            //我们数据库的订单
            Dictionary<string, Orderotherhistory> dicOwner = new Dictionary<string, Orderotherhistory>();
            //代理网站的订单
            Dictionary<string, Orderotherhistory> dicAgent = new Dictionary<string, Orderotherhistory>();
            BetAccountOrderMoney betAccountOrderMoney = null;
        label10:
            try
            {
                try
                {
                    url = "http://" + betAccountOrderHistory.agent.Address2 + "content/report/";
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, */*";
                    request.Referer = "http://" + betAccountOrderHistory.agent.Address2 + "/header.php?PHPSESSID=" + betAccountOrderHistory.agent.Cookie;
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; 360SE)";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.ServicePoint.ConnectionLimit = 50;
                    request.Headers["Cookie"] = betAccountOrderHistory.agent.Cookie;
                    request.AllowAutoRedirect = false;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    }
                    else
                    {
                        stream = response.GetResponseStream();
                    }
                    reader = new StreamReader(stream, big5);
                    html = reader.ReadToEnd();
                }
                catch (Exception ee)
                {
                    if (errCon < 3)
                    {
                        errCon++;
                        goto label10;
                    }
                    else
                    {
                        return;
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
                    url = "http://" + betAccountOrderHistory.agent.Address2 + "content/report/agent_info.php?from_date=" + betAccountOrderHistory.startTime.ToString("yyyy-MM-dd") + "&to_date=" + betAccountOrderHistory.endTime.ToString("yyyy-MM-dd") + "&FB=0&report_type=.%2Fagent_info.php&valid=1&type=0&report=";
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, */*";
                    request.Referer = "http://" + betAccountOrderHistory.agent.Address2 + "content/report/";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; 360SE)";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.Headers["Cookie"] = betAccountOrderHistory.agent.Cookie;
                    request.AllowAutoRedirect = false;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    }
                    else
                    {
                        stream = response.GetResponseStream();
                    }
                    reader = new StreamReader(stream, big5);
                    html = reader.ReadToEnd();
                    if (html.Contains("onClick"))
                    {
                        try
                        {
                            
                            foreach (Betaccount account in betAccountOrderHistory.account)
                            {
                                if(html.IndexOf(account.Userid) > -1)
                                {
                                    try
                                    {
                                        betAccountOrderMoney = new BetAccountOrderMoney();
                                        betAccountOrderMoney.WebAgentName = account.Agent;
                                        betAccountOrderMoney.WebUserName = account.Userid;
                                        betAccountOrderMoney.OwnerOrderCount = betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == betAccountOrderMoney.WebUserName).Count();
                                        betAccountOrderMoney.OwnerTotalBetMoney = betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == betAccountOrderMoney.WebUserName).Select(n => n.Value.Amount).Sum();
                                        betAccountOrderMoney.OwnerResultMoney = betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == betAccountOrderMoney.WebUserName).Select(n => n.Value.Result).Sum();
                                        td = pub.substring(html, "onClick", account.Userid);
                                        td = td.Substring(td.LastIndexOf("php"));
                                        betAccountOrderMoney.WebOrderCustId1 = pub.substring(td, "id=", "&");
                                        tr = pub.substring(html, account.Userid, "</tr>");
                                        sar = tr.Split(new string[] { "/td>" }, StringSplitOptions.None);
                                        betAccountOrderMoney.WebsiteOrderCount = Convert.ToInt32(pub.substring(sar[1], "<td>", "<"));
                                        betAccountOrderMoney.WebsiteTotalBetMoney = Convert.ToDecimal(pub.substring(sar[2], "<td>", "<"));
                                        betAccountOrderMoney.WebsiteResultMoney = Convert.ToDecimal(pub.substring(sar[4], "<td>", "<"));
                                        finalStatsDic.Add(betAccountOrderMoney.WebUserName, betAccountOrderMoney);
                                    }
                                    catch
                                    { }
                                }
                            }
                            foreach (KeyValuePair<string, BetAccountOrderMoney> item in finalStatsDic)
                            {
                                try
                                {
                                    if (dicOwner == null)
                                    {
                                        dicOwner = new Dictionary<string, Orderotherhistory>();
                                    }
                                    else
                                    {
                                        dicOwner.Clear();
                                    }
                                    if (dicAgent == null)
                                    {
                                        dicAgent = new Dictionary<string, Orderotherhistory>();
                                    }
                                    else
                                    {
                                        dicAgent.Clear();
                                    }
                                    if (item.Value.WebAgentName == betAccountOrderHistory.agent.AgentName)
                                    {
                                        //我们数据库的订单
                                        dicOwner = GetDicByAccount(item.Key, betAccountOrderHistory.OrderOtherHistorys);

                                        //代理网站的订单
                                        dicAgent = YongLiGaoHistoryReportDetail(betAccountOrderHistory, item.Value);
                                        //if (betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == item.Key).Count() > 0)
                                        //{
                                        //    Dictionary<string, Orderotherhistory> dic = new Dictionary<string, Orderotherhistory>(); ;
                                        //    foreach (KeyValuePair<string, Orderotherhistory> items in betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == item.Key).ToList())
                                        //    {
                                        //        dic.Add(items.Value.WebOrderID, items.Value);
                                        //    }
                                        //    finalDetailDic.Add(item.Key, dic);
                                        //}
                                        Dictionary<string, Orderotherhistory> dicTemp = new Dictionary<string, Orderotherhistory>();
                                        dicTemp = CheckError(dicOwner, dicAgent);
                                        if (!finalDetailDic.ContainsKey(item.Key))
                                        {
                                            if (dicTemp.Count > 0)
                                                finalDetailDic.Add(item.Key, dicTemp);
                                        }
                                    }
                                }
                                catch
                                { }
                            }
                            foreach (KeyValuePair<string, Dictionary<string, Orderotherhistory>> items in finalDetailDic)
                            {
                                finalStatsDic[items.Key].IsErrorData = items.Value.Count > 0 ? 1 : 0;
                            }
                        }
                        catch (Exception e)
                        {
                            if (errCon < 3)
                            {
                                errCon++;
                                goto label10;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }
                catch (Exception ee)
                {
                    if (errCon < 3)
                    {
                        errCon++;
                        goto label10;
                    }
                    else
                    {
                        return;
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
        }
        private static Dictionary<string, Orderotherhistory> YongLiGaoHistoryReportDetail(BetAccountOrderHistory betAccountOrderHistory, BetAccountOrderMoney betAccountOrderMoney)
        {
            Dictionary<string, Orderotherhistory> dic = new Dictionary<string, Orderotherhistory>();
            Encoding big5 = Encoding.GetEncoding("big5");
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Stream stream = null;
            string url = string.Empty;
            string html = string.Empty;
            string content = string.Empty;
            string teamp = string.Empty;
            string hiandcap = string.Empty;
            string tzsj=string.Empty;
            string[] str2;
            string[] str3;
            int count2 = 0;
            int count = 0;
            int errCon = 0;
        label10:
            try
            {
                try
                {
                    url = "http://" + betAccountOrderHistory.agent.Address2 + "content/report/member_info.php?id=" +betAccountOrderMoney.WebOrderCustId1 + "&scheduleid=&from_date=" + betAccountOrderHistory.startTime + "&to_date=" + betAccountOrderHistory.endTime + "&type=0&match_id=&valid=1&FB=0";
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    request.Referer = "http://" + betAccountOrderHistory.agent.Address2 + "content/report/agent_info.php?from_date=" + betAccountOrderHistory.startTime + "&to_date=" + betAccountOrderHistory.endTime + "&FB=0&report_type=.%2Fagent_info.php&valid=1&type=0&report=";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Headers["UA-CPU"] = "x86";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; 360SE)";
                    request.AllowAutoRedirect = false;
                    request.KeepAlive = true;
                    request.Headers["Cookie"] = betAccountOrderHistory.agent.Cookie;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    }
                    else
                    {
                        stream = response.GetResponseStream();
                    }
                    reader = new StreamReader(stream, big5);
                    html = reader.ReadToEnd();
                    count2 = 0;
                    if (html.Contains("change_bg(this)"))
                    {
                        str2 = html.Split(new string[] { "change_bg(this)" }, StringSplitOptions.None);
                        betAccountOrderMoney.WebsiteOrderCount = str2.Length-1;
                        for (int i = 1; i < str2.Length; i++)
                        {
                            Orderotherhistory order1 = new Orderotherhistory();
                            try
                            {
                                str3 = str2[i].Split(new string[] { "/td>" }, StringSplitOptions.None);
                                order1.WebOrderID = pub.substring(str3[2], "class='", "<br>").Replace("green'>", "").Replace("red'>", "");
                                tzsj = pub.substring(str3[1].Replace("<br>", " "), ">", "<");
                                order1.Leaguetw = pub.substring(str3[4], "<td>", "<br>");
                                order1.Hometw = pub.substring(str3[4], "<br>", "<");
                                order1.Awaytw = pub.substring(str3[4], "</font>", "<").Trim();
                                order1.BetItem = pub.substring(str3[4], "color='red'>", "<");
                                order1.Odds = decimal.Parse(pub.substring(str3[4], "class='odds'><b>", "<").Replace(" ", ""));
                                order1.Amount = decimal.Parse(pub.substring(str3[5], "<td>", "<").Replace(",", "").Replace(" ", ""));
                                order1.Result = decimal.Parse(pub.substring(str3[6], ">", "<").Replace(" ", ""));
                                order1.BetType = pub.substring(str3[3].Replace("<br>", ""), "足球", "<").Replace("1", "").Replace("2", "").Replace("3","");
                                switch (order1.BetType)
                                {
                                    case "讓球":
                                        order1.BetType = "0";
                                        if (str3[4].Contains("class='green'>("))
                                        {
                                            order1.Score = pub.substring(str3[4], "class='green'>(", ")<").Replace(" ", "");
                                        }
                                        order1.Handicap = pub.substring(str3[4], "color='blue'>", "<").Replace(" ", "");
                                        if (order1.BetItem.Contains(order1.Hometw))
                                        {
                                            order1.Handicap = "-" + order1.Handicap;
                                        }
                                        break;
                                    case "大小":
                                        order1.BetType = "1";
                                        if (str3[4].Contains("class='green'>("))
                                        {
                                            order1.Score = pub.substring(str3[4], "class='green'>(", ")<").Replace(" ", "");
                                        }
                                        teamp = pub.substring(str3[4], "<font color='red'>", "class='odds'");
                                        order1.Handicap = pub.substring(teamp, "<font color='red'>", "<").Replace(" ", "").Replace("大", "").Replace("小", "");
                                        break;
                                    case "上半場讓球":
                                        order1.BetType = "2";
                                        if (str3[4].Contains("class='green'>("))
                                        {
                                            order1.Scorehalf = pub.substring(str3[4], "class='green'>(", ")<").Replace(" ", "");
                                        }
                                        order1.Handicap = pub.substring(str3[4], "color='blue'>", "<").Replace(" ", "");
                                        if (order1.BetItem.Contains(order1.Hometw))
                                        {
                                            order1.Handicap = "-" + order1.Handicap;
                                        }
                                        break;
                                    case "上半場大小":
                                        order1.BetType = "3";
                                        if (str3[4].Contains("class='green'>("))
                                        {
                                            order1.Scorehalf = pub.substring(str3[4], "class='green'>(", ")<").Replace(" ", "");
                                        }
                                        teamp = pub.substring(str3[4], "<font color='red'>", "class='odds'");
                                        order1.Handicap = pub.substring(teamp, "<font color='red'>", "<").Replace(" ", "").Replace("大", "").Replace("小", "");
                                        break;
                                    case "滾球讓球":
                                        order1.BetType = "4";
                                        if (str3[4].Contains("class='green'>("))
                                        {
                                            order1.Score = pub.substring(str3[4], "class='green'>(", ")<").Replace(" ", "");
                                        }
                                        order1.Handicap = pub.substring(str3[4], "color='blue'>", "<").Replace(" ", "");
                                        if (order1.BetItem.Contains(order1.Hometw))
                                        {
                                            order1.Handicap = "-" + order1.Handicap;
                                        }
                                        break;
                                    case "滾球大小":
                                        order1.BetType = "5";
                                        if (str3[4].Contains("class='green'>("))
                                        {
                                            order1.Score = pub.substring(str3[4], "class='green'>(", ")<").Replace(" ", "");
                                        }
                                        teamp = pub.substring(str3[4], "<font color='red'>", "class='odds'");
                                        order1.Handicap = pub.substring(teamp, "<font color='red'>", "<").Replace(" ", "").Replace("大", "").Replace("小", "");
                                        break;
                                    case "上半場滾球讓球":
                                        order1.BetType = "6";
                                        if (str3[4].Contains("class='green'>("))
                                        {
                                            order1.Scorehalf = pub.substring(str3[4], "class='green'>(", ")<").Replace(" ", "");
                                        }
                                        order1.Handicap = pub.substring(str3[4], "color='blue'>", "<").Replace(" ", "");
                                        if (order1.BetItem.Contains(order1.Hometw))
                                        {
                                            order1.Handicap = "-" + order1.Handicap;
                                        }
                                        break;
                                    case "上半場滾球大小":
                                        order1.BetType = "7";
                                        if (str3[4].Contains("class='green'>("))
                                        {
                                            order1.Scorehalf = pub.substring(str3[4], "class='green'>(", ")<").Replace(" ", "");
                                        }
                                        teamp = pub.substring(str3[4], "<font color='red'>", "class='odds'");
                                        order1.Handicap = pub.substring(teamp, "<font color='red'>", "<").Replace(" ", "").Replace("大", "").Replace("小", "");
                                        break;
                                    case "早餐讓球":
                                        order1.BetType = "8";
                                        if (str3[4].Contains("class='green'>("))
                                        {
                                            order1.Score = pub.substring(str3[4], "class='green'>(", ")<").Replace(" ", "");
                                        }
                                        order1.Handicap = pub.substring(str3[4], "color='blue'>", "<").Replace(" ", "");
                                        if (order1.BetItem.Contains(order1.Hometw))
                                        {
                                            order1.Handicap = "-" + order1.Handicap;
                                        }
                                        break;
                                    case "早餐大小":
                                        order1.BetType = "9";
                                        if (str3[4].Contains("class='green'>("))
                                        {
                                            order1.Score = pub.substring(str3[4], "class='green'>(", ")<").Replace(" ", "");
                                        }
                                        teamp = pub.substring(str3[4], "<font color='red'>", "class='odds'");
                                        order1.Handicap = pub.substring(teamp, "<font color='red'>", "<").Replace(" ", "").Replace("大", "").Replace("小", "");
                                        break;
                                    case "早餐上半場讓球":
                                        order1.BetType = "10";
                                        if (str3[4].Contains("class='green'>("))
                                        {
                                            order1.Scorehalf = pub.substring(str3[4], "class='green'>(", ")<").Replace(" ", "");
                                        }
                                        order1.Handicap = pub.substring(str3[4], "color='blue'>", "<").Replace(" ", "");
                                        if (order1.BetItem.Contains(order1.Hometw))
                                        {
                                            order1.Handicap = "-" + order1.Handicap;
                                        }
                                        break;
                                    case "早餐上半場大小":
                                        order1.BetType = "11";
                                        if (str3[4].Contains("class='green'>("))
                                        {
                                            order1.Scorehalf = pub.substring(str3[4], "class='green'>(", ")<").Replace(" ", "");
                                        }
                                        teamp = pub.substring(str3[4], "<font color='red'>", "class='odds'");
                                        order1.Handicap = pub.substring(teamp, "<font color='red'>", "<").Replace(" ", "").Replace("大", "").Replace("小", "");
                                        break;
                                    case "讓球標準盤":
                                        order1.BetType = "12";
                                        if (str3[4].Contains("class='green'>("))
                                        {
                                            order1.Score = pub.substring(str3[4], "class='green'>(", ")<").Replace(" ", "");
                                        }
                                        break;
                                    case "足球上半場標準盤":
                                        order1.BetType = "13";
                                        if (str3[4].Contains("class='green'>("))
                                        {
                                            order1.Scorehalf = pub.substring(str3[4], "class='green'>(", ")<").Replace(" ", "");
                                        }
                                        break;
                                    case "滾球標準盤":
                                        order1.BetType = "14";
                                        if (str3[4].Contains("class='green'>("))
                                        {
                                            order1.Score = pub.substring(str3[4], "class='green'>(", ")<").Replace(" ", "");
                                        }
                                        break;
                                    case "上半场滾球標準盤":
                                        order1.BetType = "15";
                                        if (str3[4].Contains("class='green'>("))
                                        {
                                            order1.Scorehalf = pub.substring(str3[4], "class='green'>(", ")<").Replace(" ", "");
                                        }
                                        break;
                                    case "早餐標準盤":
                                        order1.BetType = "16";
                                        if (str3[4].Contains("class='green'>("))
                                        {
                                            order1.Score = pub.substring(str3[4], "class='green'>(", ")<").Replace(" ", "");
                                        }
                                        break;
                                    case "早餐上半場標準盤":
                                        order1.BetType = "17";
                                        if (str3[4].Contains("class='green'>("))
                                        {
                                            order1.Scorehalf = pub.substring(str3[4], "class='green'>(", ")<").Replace(" ", "");
                                        }
                                        break;
                                }
                                if (order1.Handicap != null)
                                {
                                    hiandcap = "";
                                    if (order1.Handicap.Contains("-"))
                                    {
                                        hiandcap = "-";
                                    }
                                    if (order1.Handicap.Contains("/"))
                                    {
                                        string s = order1.Handicap.Substring(0, order1.Handicap.IndexOf("/"));
                                        order1.Handicap = hiandcap + ((Math.Abs(double.Parse(order1.Handicap.Substring(0, order1.Handicap.IndexOf("/")))) + double.Parse(order1.Handicap.Substring(order1.Handicap.IndexOf("/") + 1))) / 2).ToString();
                                    }
                                    else
                                    {
                                        order1.Handicap = order1.Handicap;
                                    }

                                    if (str3[4].Contains("<font color='#009933'>") && order1.Result == 0)
                                    {
                                        order1.ErrorMessage = "代理注单：" + pub.substring(str3[4], "<font color='#009933'>", "</font>");
                                    }
                                }
                                order1.Time = Convert.ToDateTime(tzsj);
                                order1.WebUserName = betAccountOrderMoney.WebUserName;   
                            }
                            catch (Exception e)
                            { 
                                
                            }
                            try
                            {
                                if (order1.WebOrderID != null)
                                {
                                    if (order1.WebOrderID.Length > 6)
                                    {
                                        dic.Add(order1.WebOrderID, order1);
                                    }
                                    else if (order1.WebOrderID.Length > 1)
                                    {
                                       
                                        order1.ErrorMessage = "代理注单：" + order1.WebOrderID;
                                        dic.Add(DateTime.Now.Ticks.ToString() + order1.WebOrderID, order1);
                                        

                                    }
                                }
                                else
                                {
                                    dic.Add(DateTime.Now.Ticks.ToString(), order1);
                                }

                            }
                            catch(Exception e)
                            { }
                        }
                       
                    }
                }
                catch (Exception ee)
                {
                    if (errCon < 3)
                    {
                        errCon++;
                        goto label10;
                    }
                    else
                    {
                        return null;
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
            return dic;
        }

        //DongFangHuangChao  历史查询核对
        private static void HuangChaoHistoryReport(BetAccountOrderHistory betAccountOrderHistory)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            Stream stream = null;
            string url = string.Empty; ;
            string html = string.Empty;
            string content = string.Empty;
            string custid = string.Empty;
            string tr = string.Empty;
            string td = string.Empty;
            string[] sar;
            int count = 0;
            int errCon = 0;
            BetAccountOrderMoney betAccountOrderMoney = null;
            //我们数据库的订单
            Dictionary<string, Orderotherhistory> dicOwner = new Dictionary<string, Orderotherhistory>();
            //代理网站的订单
            Dictionary<string, Orderotherhistory> dicAgent = new Dictionary<string, Orderotherhistory>();
        label10:
            try
            {
                try
                {
                    url = "https://" + betAccountOrderHistory.agent.Address2 + "/sb2/ag/view_daily_report_criteria.jsp";
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; GTB6.6; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; InfoPath.3)";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.ServicePoint.ConnectionLimit = 50;
                    request.Headers["Cookie"] = betAccountOrderHistory.agent.Cookie;
                    request.AllowAutoRedirect = false;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    }
                    else
                    {
                        stream = response.GetResponseStream();
                    }
                    reader = new StreamReader(stream, utf8);
                    html = reader.ReadToEnd();
                }
                catch (Exception ee)
                {
                    if (errCon < 3)
                    {
                        errCon++;
                        goto label10;
                    }
                    else
                    {
                        return;
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
                    url = "https://" + betAccountOrderHistory.agent.Address2 + "/sb2/ag/view_daily_report_sa.jsp?countLayer=1&shCodeReflection=&maCodeReflection=&saCodeReflection=&meCodeReflection=&searchDateFrom=" + betAccountOrderHistory.startTime.ToString("yyyy-MM-dd") + "&searchDateTo=" + betAccountOrderHistory.endTime.ToString("yyyy-MM-dd") + "&agentTypeId=30&searchMeCode=&searchSportId=-1&searchMktCode=&searchBetId=";
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; GTB6.6; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; InfoPath.3)";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.KeepAlive = true;
                    request.Method = "GET";
                    request.Headers["Cookie"] = betAccountOrderHistory.agent.Cookie;
                    request.AllowAutoRedirect = false;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    }
                    else
                    {
                        stream = response.GetResponseStream();
                    }
                    reader = new StreamReader(stream, utf8);
                    html = reader.ReadToEnd();
                }
                catch (Exception ee)
                {
                    if (errCon < 3)
                    {
                        errCon++;
                        goto label10;
                    }
                    else
                    {
                        return;
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
                url = "https://" + betAccountOrderHistory.agent.Address2 + "/sb2/ag/view_daily_report_me.jsp?searchDateFrom=" + betAccountOrderHistory.startTime.ToString("yyyy-MM-dd") + "&searchDateTo=" + betAccountOrderHistory.endTime.ToString("yyyy-MM-dd") + "&agentTypeId=30&searchShCode=&searchMaCode=&searchSaCode=" + betAccountOrderHistory.agent.AgentName + "&searchMeCode=&searchSportId=-1&searchMktCode=&searchBetId=-1&countLayer=2&shCodeReflection=&maCodeReflection=&saCodeReflection=&meCodeReflection=&containsIBrokerBets=";
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                request.Headers["Accept-Language"] = "zh-cn";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; GTB6.6; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; InfoPath.3)";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.KeepAlive = true;
                request.Method = "GET";
                request.Headers["Cookie"] = betAccountOrderHistory.agent.Cookie;
                request.AllowAutoRedirect = false;
                response = (HttpWebResponse)request.GetResponse();
                if (response.Headers.Get("Content-Encoding") != null)
                {
                    stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                }
                else
                {
                    stream = response.GetResponseStream();
                }
                reader = new StreamReader(stream, utf8);
                html = reader.ReadToEnd();
                if (html.Contains("hightlightRow"))
                {
                    try
                    {
                        foreach (Betaccount account in betAccountOrderHistory.account)
                        {

                            try
                            {
                                if (html.Contains(account.Userid))
                                {
                                    betAccountOrderMoney = new BetAccountOrderMoney();
                                    betAccountOrderMoney.WebAgentName = account.Agent;
                                    betAccountOrderMoney.WebUserName = account.Userid;
                                    betAccountOrderMoney.OwnerOrderCount = betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == betAccountOrderMoney.WebUserName).Count();
                                    betAccountOrderMoney.OwnerTotalBetMoney = betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == betAccountOrderMoney.WebUserName).Select(n => n.Value.Amount).Sum();
                                    betAccountOrderMoney.OwnerResultMoney = betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == betAccountOrderMoney.WebUserName).Select(n => n.Value.Result).Sum();
                                    tr = pub.substring(html, account.Userid, "</tr>");
                                    sar = tr.Split(new string[] { "/td>" }, StringSplitOptions.None);
                                    betAccountOrderMoney.WebsiteOrderCount = Convert.ToInt32(pub.substring(sar[1], "<td>", "<"));
                                    betAccountOrderMoney.WebsiteTotalBetMoney = Convert.ToDecimal(pub.substring(sar[3], "<td>", "<"));
                                    betAccountOrderMoney.WebsiteResultMoney = Convert.ToDecimal(pub.substring(sar[6], "<td>", "<"));
                                    finalStatsDic.Add(betAccountOrderMoney.WebUserName, betAccountOrderMoney);
                                }
                            }
                            catch
                            { }
                        }
                        foreach (KeyValuePair<string, BetAccountOrderMoney> item in finalStatsDic)
                        {
                            try
                            {
                                if (dicOwner == null)
                                {
                                    dicOwner = new Dictionary<string, Orderotherhistory>();
                                }
                                else
                                {
                                    dicOwner.Clear();
                                }
                                if (dicAgent == null)
                                {
                                    dicAgent = new Dictionary<string, Orderotherhistory>();
                                }
                                else
                                {
                                    dicAgent.Clear();
                                }
                                if (item.Value.WebAgentName == betAccountOrderHistory.agent.AgentName)
                                {
                                    //我们数据库的订单
                                    dicOwner = GetDicByAccount(item.Key, betAccountOrderHistory.OrderOtherHistorys);
                                    dicAgent = HuangChaoHistoryReportDetail(betAccountOrderHistory, item.Value);
                                    //if (betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == item.Key).Count() > 0)
                                    //{
                                    //    Dictionary<string, Orderotherhistory> dic = new Dictionary<string, Orderotherhistory>();
                                    //    foreach (KeyValuePair<string, Orderotherhistory> items in betAccountOrderHistory.OrderOtherHistorys.Where(n => n.Value.WebUserName == item.Key).ToList())
                                    //    {
                                    //        dic.Add(items.Value.WebOrderID, items.Value);
                                    //    }
                                    //    finalDetailDic.Add(item.Key, dic);
                                    //}
                                    Dictionary<string, Orderotherhistory> dicTemp = new Dictionary<string, Orderotherhistory>();
                                    try
                                    {
                                        dicTemp = CheckError(dicOwner, dicAgent);
                                    }
                                    catch
                                    { }
                                    if (!finalDetailDic.ContainsKey(item.Key))
                                    {

                                        if (dicTemp.Count > 0)
                                            finalDetailDic.Add(item.Key, dicTemp);

                                    }
                                }
                            }
                            catch(Exception e)
                            { }
                        }
                        foreach (KeyValuePair<string, Dictionary<string, Orderotherhistory>> items in finalDetailDic)
                        {
                            finalStatsDic[items.Key].IsErrorData = items.Value.Count > 0 ? 1 : 0;
                        }
                    }
                    catch (Exception e)
                    {
                        return;
                    }
                }
            }
            catch (Exception ee)
            {
                if (errCon < 3)
                {
                    errCon++;
                    goto label10;
                }
                else
                {
                    return;
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
        }
        private static Dictionary<string, Orderotherhistory> HuangChaoHistoryReportDetail(BetAccountOrderHistory betAccountOrderHistory, BetAccountOrderMoney betAccountOrderMoney)
        {
            Dictionary<string, Orderotherhistory> dic = new Dictionary<string, Orderotherhistory>();
            Orderotherhistory order1 = null;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            Stream stream = null;
            string url = string.Empty;
            string html = string.Empty;
            string content = string.Empty;
            string hiandcap = string.Empty;
            
            string[] item = null;
            string[] item2 = null;
            string[] item3 = null;
            int errCon = 0;
            int count = 0;
        label10:
            try
            {
                try
                {
                    url = "https://" + betAccountOrderHistory.agent.Address2 + "/sb2/ag/list_bet.jsp?searchDateFrom=" + betAccountOrderHistory.startTime.ToString("yyyy-MM-dd") + "&searchDateTo=" + betAccountOrderHistory.endTime.ToString("yyyy-MM-dd") + "&agentTypeId=30&searchShCode=&searchMaCode=&searchSaCode=" + betAccountOrderMoney.WebAgentName + "&searchMeCode=" + betAccountOrderMoney.WebUserName + "&searchSportId=-1&searchMktCode=&searchBetId=-1&countLayer=3&shCodeReflection=&maCodeReflection=&saCodeReflection=&meCodeReflection=&containsIBrokerBets=";
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Headers["UA-CPU"] = "x86";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; GTB6.6; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; InfoPath.3)";
                    request.AllowAutoRedirect = false;
                    request.KeepAlive = true;
                    request.Headers["Cookie"] = betAccountOrderHistory.agent.Cookie;
                    response = (HttpWebResponse)request.GetResponse();
                    if (response.Headers.Get("Content-Encoding") != null)
                    {
                        stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                    }
                    else
                    {
                        stream = response.GetResponseStream();
                    }
                    reader = new StreamReader(stream, utf8);
                    html = reader.ReadToEnd();
                    if (html.IndexOf("name=\"recordForm\"") > -1)
                    {
                        html = html.Replace("\n", "").Replace("\r", "").Replace("\t", "");
                        while (html.IndexOf("class=\"listContent \"") > -1)
                        {
                            order1 = new Orderotherhistory();
                            try
                            {
                                count = 0;
                                content = pub.substring(html, "class=\"listContent \"", "</tr><tr");
                                order1.ErrorMessage = pub.substring(content, "Status\">", "<").Replace(" ", "").Trim();
                                if (content.Contains("主客和"))
                                    order1.BetType = "主客和";
                                while (content.IndexOf("<td") > -1)
                                {
                                    count++;
                                    if (count > 9)
                                        break;
                                    if (count == 2)
                                    {
                                        order1.Time = Convert.ToDateTime(pub.substring(content, "<td>", "</td>").Replace("<br/>", "$").Split('$')[0]);
                                    }
                                    else if (count == 4)
                                    {
                                        order1.WebOrderID = pub.substring(content, "<td", "</td>").Replace("<br />", "$").Split('$')[1];
                                    }
                                    else if (count == 5)
                                    {
                                        item = pub.substring(content, "<td", "</td>").Replace("<br/>", "$").Split('$');
                                        order1.Leaguetw = pub.substring(item[0] + "#", ">", "#").Trim();
                                        item2 = item[2].Replace("<br />", "$").Split('$');
                                        order1.BeginTime = Convert.ToDateTime(item[1].Replace("(", "").Replace(")", ""));
                                        //<span class="betDetails_score">0 : 1</span> 水晶宮(主) <span class="betDetails_handicap">對</span> 諾定咸森林
                                        if (item2[0].Contains("betDetails_score"))
                                        {
                                            item3 = item2[0].Replace("/span>", "$").Split('$');
                                            order1.Scoreathalf = pub.substring(item3[0], ">", "<").Replace(" ", "").Trim();
                                            order1.Hometw = pub.substring("#" + item3[1], "#", "<span").Replace(" ", "").Replace("(主)","").Trim();
                                            order1.Awaytw = item3[2].Replace(" ", "").Trim();
                                            order1.BetItem =item2[1].Substring(0,item2[1].IndexOf("<")).Replace("@", "").Trim();
                                            order1.Odds = Convert.ToDecimal(pub.substring(item2[1], "price\">", "</span>"));
                                            order1.Handicap = pub.substring(item2[0].Replace("對", ""), "handicap\">", "</span>");
                                            if (order1.Handicap == "" && item2[1].Contains("_handicap"))
                                            {
                                                order1.Handicap = pub.substring(item2[1], "handicap\">", "</span>");
                                                order1.Odds = Convert.ToDecimal(pub.substring(item2[1], "price\">", "</span>"));
                                            }
                                            else
                                            {
                                                if (order1.BetItem.Contains(order1.Hometw) && order1.Handicap != "0")
                                                {
                                                    order1.Handicap = "-" + order1.Handicap;
                                                }
                                            }
                                           
                                           
                                        }
                                        else
                                        {
                                            order1.Hometw = pub.substring("#" + item2[0], "#", "<span").Replace("(主)", "").Trim();
                                            order1.Awaytw = pub.substring(item2[0] + "#", "</span>", "#").Trim();
                                            order1.Handicap = pub.substring(item2[0].Replace("對", ""), "handicap\">", "</span>");
                                            order1.BetItem = item2[1].Substring(0, item2[1].IndexOf("<")).Replace("@", "").Trim();
                                            order1.Odds = Convert.ToDecimal(pub.substring(item2[1], "price\">", "</span>"));
                                            if (order1.Handicap == "" && item2[1].Contains("_handicap"))
                                            {
                                                order1.Handicap = pub.substring(item2[1], "handicap\">", "</span>");

                                            }
                                            else
                                            {
                                                if (order1.BetItem.Contains(order1.Hometw) && order1.Handicap != "0")
                                                {
                                                    order1.Handicap = "-" + order1.Handicap;
                                                }
                                            }
                                           
                                        }
                                        if (order1.Handicap != null)
                                        {
                                            hiandcap = "";
                                            if (order1.Handicap.Contains("-"))
                                            {
                                                hiandcap = "-";
                                            }
                                            order1.Handicap = order1.Handicap.Replace(" ", "");
                                            if (order1.Handicap.Contains("/"))
                                            {
                                                string s = order1.Handicap.Substring(0, order1.Handicap.IndexOf("/"));
                                                order1.Handicap = hiandcap + ((Math.Abs(double.Parse(order1.Handicap.Substring(0, order1.Handicap.IndexOf("/")))) + double.Parse(order1.Handicap.Substring(order1.Handicap.IndexOf("/") + 1))) / 2).ToString();
                                            }
                                            else
                                            {
                                                order1.Handicap = order1.Handicap;
                                            }
                                        }
                                    }
                                    else if (count == 6)
                                    {
                                        order1.Amount = Convert.ToDecimal(pub.substring(pub.substring(content, "<td", "/td>"), ">", "<"));
                                    }
                                    else if (count == 8)
                                    {
                                        order1.Result = Convert.ToDecimal(pub.substring(pub.substring(content, "<td", "/td>"), ">", "<"));
                                    }
                                    else if (count == 9)
                                    {
                                        order1.Betflag = pub.substring(pub.substring(pub.substring(content, "class=\"txtResultText\">", "</td>"), "<span", "/span"), ">", "<");
                                    }
                                    content = pub.substring2(content, "<td", "</td>");
                                }
                                html = pub.substring2(html, "class=\"listContent \"", "</tr><tr");
                                order1.WebUserName = betAccountOrderMoney.WebUserName;
                                if (order1.BetType == "主客和")
                                {
                                    order1.Handicap = string.Empty;
                                }
                            }
                            catch
                            { }
                            try
                            {
                                if (order1.WebOrderID != null)
                                {
                                    dic.Add(order1.WebOrderID, order1);
                                }
                                else
                                {
                                    order1.ErrorMessage = "代理网站没有读取到注单号";
                                    dic.Add(DateTime.Now.Ticks.ToString(), order1);
                                }
                            }
                            catch
                            { }
                        }
                    }
                }
                catch (Exception ee)
                {
                    if (errCon < 3)
                    {
                        errCon++;
                        goto label10;
                    }
                    else
                    {
                        return null;
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
            return dic;
        }
        
        /// <summary>
        /// 公共匹配出错的方法
        /// </summary>
        /// <param name="dicOwner">自己数据库的订单字典</param>
        /// <param name="dicAgent">代理网站抓去到的订单字典</param>
        /// <returns>匹配出错的订单字典</returns>
        private static Dictionary<string, Orderotherhistory> CheckError(Dictionary<string, Orderotherhistory> dicOwner, Dictionary<string, Orderotherhistory> dicAgent)
        {
            double m1 = 0;
            double m2 = 0;
            double item1Handicap = 0;
            double oHandicap = 0;
            double item2Handicap = 0;
            Dictionary<string, Orderotherhistory> dic = new Dictionary<string, Orderotherhistory>();
            if (dicAgent == null)
            {
                foreach (KeyValuePair<string, Orderotherhistory> item3 in dicOwner)
                {
                    //我们网站上有数据，代理上没有
                    if (!dic.ContainsKey("o-" + item3.Key) && !dic.ContainsKey("a-" + item3.Key) && !dic.ContainsKey(item3.Key))
                    {
                        item3.Value.ErrorMessage += "158bet网站上有此订单，代理网站获取注单异常";
                        item3.Value.WebOrderID = "o-" + item3.Value.WebOrderID;
                        dic.Add("o-" + item3.Key, item3.Value);
                    }
                }
            }
            else
            {
                foreach (KeyValuePair<string, Orderotherhistory> item1 in dicOwner)
                {
                    try
                    {
                        if (dicAgent.ContainsKey(item1.Key))
                        {
                            //代理网站抓去到的实体信息

                            Orderotherhistory o = dicAgent[item1.Key];
                            if (int.Parse(item1.Value.BetType) < 12)
                            {
                                try
                                {
                                    item1Handicap = string.IsNullOrEmpty(item1.Value.Handicap) ? Convert.ToDouble("0") : Convert.ToDouble(item1.Value.Handicap);
                                    oHandicap = string.IsNullOrEmpty(o.Handicap) ? Convert.ToDouble("0") : Convert.ToDouble(o.Handicap);
                                }
                                catch(Exception e)
                                { }
                            }
                            //item1.Value.Score != o.Score ||
                            m1 = (double)(Math.Abs(o.Amount - item1.Value.Amount));
                            m2 = (double)(Math.Abs(o.Result - item1.Value.Result));
                            if (item1Handicap != oHandicap || m1 > 0.1 || m2 > 0.1 || item1.Value.Odds != o.Odds)
                            {
                                o.ErrorMessage += "；匹配出错";
                                if (item1Handicap != oHandicap)
                                {
                                    o.ErrorMessage += "；投注的盘口不同";

                                }
                                if (m1 > 0.1)
                                {
                                    o.ErrorMessage += "；投注金额不同";

                                }
                                if (m2 > 0.1)
                                {
                                    o.ErrorMessage += "；结算金额不同";

                                }
                                if (item1.Value.Odds != o.Odds)
                                {
                                    o.ErrorMessage += "；投注的赔率不同";

                                }
                                if (!dic.ContainsKey("o-" + item1.Key) && !dic.ContainsKey("a-" + item1.Key) && !dic.ContainsKey(item1.Key))
                                {
                                    o.WebOrderID = "a-" + o.WebOrderID;
                                    item1.Value.WebOrderID = "o-" + item1.Value.WebOrderID;
                                    dic.Add("a-" + o.WebOrderID, o);
                                    dic.Add("o-" + item1.Key, item1.Value);
                                }
                            }

                        }
                        else
                        {
                            //我们网站上有数据，代理上没有
                            if (!dic.ContainsKey("o-" + item1.Key) && !dic.ContainsKey("a-" + item1.Key) && !dic.ContainsKey(item1.Key))
                            {
                                item1.Value.ErrorMessage += " 158bet网站上有此订单，代理网站上没有";
                                item1.Value.WebOrderID = "o-" + item1.Value.WebOrderID;
                                dic.Add("o-" + item1.Key, item1.Value);
                            }
                        }
                    }
                    catch(Exception e)
                    { }
                }
                foreach (KeyValuePair<string, Orderotherhistory> item2 in dicAgent)
                {
                    try
                    {
                        if (dicOwner.ContainsKey(item2.Key))
                        {
                            //自己数据库的实体信息
                            Orderotherhistory o = dicOwner[item2.Key];
                            if (int.Parse(item2.Value.BetType) < 12)
                            {
                                try
                                {
                                    item2Handicap = string.IsNullOrEmpty(item2.Value.Handicap) ? Convert.ToDouble("0") : Convert.ToDouble(item2.Value.Handicap);
                                    oHandicap = string.IsNullOrEmpty(o.Handicap) ? Convert.ToDouble("0") : Convert.ToDouble(o.Handicap);
                                }
                                catch
                                { }
                            }
                            //item2.Value.Score != o.Score || 
                            m1 = (double)(Math.Abs(o.Amount - item2.Value.Amount));
                            m2 = (double)(Math.Abs(o.Result - item2.Value.Result));
                            if (item2Handicap != oHandicap || m1 > 0.1 || m2 > 0.1 || item2.Value.Odds != o.Odds)
                            {
                                o.ErrorMessage += "；匹配出错";
                                if (item2Handicap != oHandicap)
                                {
                                    o.ErrorMessage += "；投注的盘口不同";

                                }
                                if (m1 > 0.1)
                                {
                                    o.ErrorMessage += "；投注金额不同";

                                }
                                if (m2 > 0.1)
                                {
                                    o.ErrorMessage += "；结算金额不同";

                                }
                                if (item2.Value.Odds != o.Odds)
                                {
                                    o.ErrorMessage += "；投注的赔率不同";

                                }
                                if (!dic.ContainsKey("o-" + item2.Key) && !dic.ContainsKey("a-" + item2.Key) && !dic.ContainsKey(item2.Key))
                                {
                                    o.WebOrderID = "o-" + o.WebOrderID;
                                    item2.Value.WebOrderID = "a-" + item2.Value.WebOrderID;
                                    dic.Add("o-" + o.WebOrderID, o);
                                    dic.Add("a-" + item2.Key, item2.Value);
                                }
                            }
                        }
                        else
                        {
                            //我们网站上有没有数据，代理上有
                            if (!dic.ContainsKey("o-" + item2.Key) && !dic.ContainsKey("a-" + item2.Key) && !dic.ContainsKey(item2.Key))
                            {
                                item2.Value.ErrorMessage += " 代理网站上有此订单，158bet网站上没有";
                                item2.Value.WebOrderID = "a-" + item2.Value.WebOrderID;
                                dic.Add("a-" + item2.Key, item2.Value);
                            }
                        }
                    }
                    catch(Exception e)
                    { }
                }
            }
            return dic;
        }

        private static Dictionary<string, Orderotherhistory> HuangGuanCheckError(Dictionary<string, Orderotherhistory> dicOwner, Dictionary<string, Orderotherhistory> dicAgent)
        {
            Dictionary<string, Orderotherhistory> dic = new Dictionary<string, Orderotherhistory>();
            TimeSpan t;
            int n = 0;
            double m1 = 0;
            double m2 = 0;
            int count = 0;
            int count3 = 0;
            string Score = string.Empty;
            string Score2 = string.Empty;
            string Scoreeathalf = string.Empty;
            string handicap = string.Empty;
            if (dicAgent == null)
            {
                foreach (KeyValuePair<string, Orderotherhistory> item3 in dicOwner)
                {
                    //我们网站上有数据，代理上没有
                    if (!dic.ContainsKey("o-" + item3.Key) && !dic.ContainsKey("a-" + item3.Key) && !dic.ContainsKey(item3.Key))
                    {
                        item3.Value.ErrorMessage += "158bet网站上有此订单，代理网站获取注单异常";
                        item3.Value.WebOrderID = "o-" + item3.Value.WebOrderID;
                        dic.Add("o-" + item3.Key, item3.Value);
                    }
                }
            }
            else
            {
                foreach (KeyValuePair<string, Orderotherhistory> item1 in dicOwner)
                {

                    count = 0;

                    count3 = 0;
                    foreach (KeyValuePair<string, Orderotherhistory> item2 in dicAgent)
                    {
                        //代理网站抓去到的实体信息
                        try
                        {
                            t = Convert.ToDateTime(dicAgent[item2.Key].Time).Subtract(Convert.ToDateTime(dicOwner[item1.Key].Time));
                            n = t.Hours * 3600 + t.Minutes * 60 + t.Seconds;
                            if (n < 21 && n > -21)
                            {
                                Orderotherhistory o = dicAgent[item2.Key];
                                handicap = "";
                                try
                                {

                                    if (int.Parse(o.BetType) < 12)
                                    {
                                        if (o.Handicap.Contains("-"))
                                        {
                                            handicap = "-";

                                        }
                                        if (o.Handicap.Contains("/"))
                                        {

                                            handicap = handicap + ((Math.Abs(double.Parse(o.Handicap.Substring(0, o.Handicap.IndexOf("/")))) + double.Parse(o.Handicap.Substring(o.Handicap.IndexOf("/") + 1))) / 2).ToString();

                                        }
                                        else
                                        {
                                            handicap = o.Handicap;
                                        }

                                    }
                                    else
                                    {
                                        item1.Value.Handicap = "";
                                        handicap = "";

                                    }
                                    double item1Handicap = string.IsNullOrEmpty(item1.Value.Handicap) ? Convert.ToDouble("0") : Convert.ToDouble(item1.Value.Handicap);
                                    double oHandicap = string.IsNullOrEmpty(handicap) ? Convert.ToDouble("0") : Convert.ToDouble(handicap);
                                    if (int.Parse(item1.Value.BetType) < 12 && int.Parse(item1.Value.BetType) % 2 == 0)
                                    {
                                        o.Betflag = item1.Value.Betflag;
                                    }

                                    //if (!item1.Value.Hometw.Contains(o.Hometw) && item1.Value.Hometw.Contains(o.Awaytw))
                                    //{
                                    //    if (o.BetType =="0" ||  o.BetType =="4" || o.BetType =="8")
                                    //    {
                                    //        Score = o.Score.Substring(o.Score.IndexOf(":") + 1) + ":" + o.Score.Substring(0, o.Score.IndexOf(":"));
                                    //        Score2 = item1.Value.Score;
                                    //    }
                                    //    else if(o.BetType =="2" ||  o.BetType =="6" || o.BetType =="10")
                                    //    {
                                    //        Score = o.Scorehalf.Substring(o.Scorehalf.IndexOf(":") + 1) + ":" + o.Scorehalf.Substring(0, o.Scorehalf.IndexOf(":"));
                                    //        Score2 = item1.Value.Scorehalf;
                                    //    }

                                    //}
                                    //else
                                    //{
                                    //    if (o.BetType == "0" || o.BetType == "1" || o.BetType == "4" || o.BetType == "5" || o.BetType == "8" || o.BetType == "9" || o.BetType == "12" || o.BetType == "14" || o.BetType == "16")
                                    //    {
                                    //        Score = o.Score;
                                    //        Score2 = item1.Value.Score;
                                    //    }
                                    //    else
                                    //    {
                                    //        Score = o.Scorehalf;
                                    //        Score2 = item1.Value.Scorehalf;
                                    //    }

                                    //}
                                    if (item1.Value.Odds == -1)
                                    {
                                        item1.Value.Odds = 1;
                                    }
                                    if (o.Odds == -1)
                                    {
                                        o.Odds = 1;
                                    }
                                    m1 = (double)(Math.Abs(o.Amount - item1.Value.Amount));
                                    m2 = (double)(Math.Abs(o.Result - item1.Value.Result));
                                    if ((item1.Value.Hometw + item1.Value.Awaytw).Contains(o.Hometw))
                                    {
                                        if (item1.Value.Betflag != o.Betflag || item1Handicap != oHandicap || m1 > 0.1 || m2 > 0.1 || item1.Value.Odds != o.Odds)
                                        {
                                            if (count > 0)
                                            {
                                                o.ErrorMessage += "；注单有多笔";
                                            }
                                            o.ErrorMessage += "；匹配出错";
                                            if (item1.Value.Betflag != o.Betflag)
                                            {
                                                o.ErrorMessage += "；投注队伍或者类型不同";

                                            }
                                            if (item1Handicap != oHandicap)
                                            {
                                                o.ErrorMessage += "；投注的盘口不同";

                                            }
                                            if (m1 > 0.1)
                                            {
                                                o.ErrorMessage += "；投注金额不同";

                                            }
                                            if (m2 > 0.1)
                                            {
                                                o.ErrorMessage += "；结算金额不同";

                                            }
                                            if (item1.Value.Odds != o.Odds)
                                            {
                                                o.ErrorMessage += "；投注的赔率不同";

                                            }
                                           
                                            if (!dic.ContainsKey("o-" + item1.Key) && !dic.ContainsKey("a-" + item2.Key) && !dic.ContainsKey(item1.Key))
                                            {

                                                o.WebOrderID = "a-" + item2.Value.WebOrderID;
                                                item1.Value.WebOrderID = "o-" + item1.Value.WebOrderID;
                                                dic.Add("a-" + item2.Key, o);
                                                dic.Add("o-" + item1.Key, item1.Value);
                                            }
                                            count++;

                                        }
                                        else
                                        {
                                            count++;

                                        }

                                    }
                                }
                                catch
                                {
                                    count++;
                                    o.ErrorMessage += "；匹配时出现异常，请手工核对";
                                    if (!dic.ContainsKey("o-" + item1.Key) && !dic.ContainsKey("a-" + item2.Key) && !dic.ContainsKey(item1.Key))
                                    {
                                        o.WebOrderID = "a-" + item2.Value.WebOrderID;
                                        item1.Value.WebOrderID = "o-" + item1.Value.WebOrderID;
                                        dic.Add("a-" + item2.Key, o);
                                        dic.Add("o-" + item1.Key, item1.Value);
                                    }
                                }
                            }

                        }
                        catch
                        {

                        }
                    }
                    if (count == 0)
                    {
                        if (!dic.ContainsKey("o-" + item1.Key) && !dic.ContainsKey(item1.Key))
                        {
                            item1.Value.ErrorMessage += " 158bet网站上有此订单，代理网站上没有";
                            item1.Value.WebOrderID = "o-" + item1.Value.WebOrderID;
                            dic.Add("o-" + item1.Key, item1.Value);
                        }
                    }

                }
                foreach (KeyValuePair<string, Orderotherhistory> item1 in dicAgent)
                {
                    count = 0;

                    foreach (KeyValuePair<string, Orderotherhistory> item2 in dicOwner)
                    {
                        try
                        {
                            t = Convert.ToDateTime(dicAgent[item1.Key].Time).Subtract(Convert.ToDateTime(dicOwner[item2.Key].Time));
                            n = t.Hours * 3600 + t.Minutes * 60 + t.Seconds;
                            if (n < 21 && n > -21)
                            {

                                //自己数据库的实体信息
                                Orderotherhistory o = dicOwner[item2.Key];
                                handicap = "";
                                try
                                {
                                    if (int.Parse(o.BetType) < 12)
                                    {
                                        if (item1.Value.Handicap.Contains("-"))
                                        {
                                            handicap = "-";

                                        }
                                        if (item1.Value.Handicap.Contains("/"))
                                        {

                                            handicap = handicap + ((Math.Abs(double.Parse(item1.Value.Handicap.Substring(0, item1.Value.Handicap.IndexOf("/")))) + double.Parse(item1.Value.Handicap.Substring(item1.Value.Handicap.IndexOf("/") + 1))) / 2).ToString();

                                        }
                                        else
                                        {
                                            handicap = item1.Value.Handicap;
                                        }

                                    }
                                    else
                                    {
                                        o.Handicap = "";
                                        handicap = "";

                                    }
                                    double item1Handicap = string.IsNullOrEmpty(handicap) ? Convert.ToDouble("0") : Convert.ToDouble(handicap);
                                    double oHandicap = string.IsNullOrEmpty(o.Handicap) ? Convert.ToDouble("0") : Convert.ToDouble(o.Handicap);
                                    //if (!item1.Value.Hometw.Contains(o.Hometw) && item1.Value.Hometw.Contains(o.Awaytw))
                                    //{
                                    //    if (item1.Value.BetType == "0" || item1.Value.BetType == "4" || item1.Value.BetType == "8")
                                    //    {
                                    //        Score = item1.Value.Score.Substring(item1.Value.Score.IndexOf(":") + 1) + ":" + item1.Value.Score.Substring(0, item1.Value.Score.IndexOf(":"));
                                    //        Score2 = o.Score;
                                    //    }
                                    //    else if (item1.Value.BetType == "2" || item1.Value.BetType == "6" || item1.Value.BetType == "10")
                                    //    {
                                    //        Score = item1.Value.Scorehalf.Substring(item1.Value.Scorehalf.IndexOf(":") + 1) + ":" + item1.Value.Scorehalf.Substring(0, item1.Value.Scorehalf.IndexOf(":"));
                                    //        Score2 = o.Scorehalf;
                                    //    }

                                    //}
                                    //else
                                    //{
                                    //    if (item1.Value.BetType == "0" || item1.Value.BetType == "1" || item1.Value.BetType == "4" || item1.Value.BetType == "5" || item1.Value.BetType == "8" || item1.Value.BetType == "9" || item1.Value.BetType == "12" || item1.Value.BetType == "14" || item1.Value.BetType == "16")
                                    //    {
                                    //        Score = item1.Value.Score;
                                    //        Score2 = o.Score;
                                    //    }
                                    //    else
                                    //    {
                                    //        Score = item1.Value.Scorehalf;
                                    //        Score2 = o.Scorehalf;
                                    //    }

                                    //}
                                    if (int.Parse(item1.Value.BetType) < 12 && int.Parse(item1.Value.BetType) % 2 == 0)
                                    {
                                        item1.Value.Betflag = o.Betflag;
                                    }
                                    if (item1.Value.Odds == -1)
                                    {
                                        item1.Value.Odds = 1;
                                    }
                                    if (o.Odds == -1)
                                    {
                                        o.Odds = 1;
                                    }
                                    m1 = (double)(Math.Abs(o.Amount - item1.Value.Amount));
                                    m2 = (double)(Math.Abs(o.Result - item1.Value.Result));
                                    if ((item1.Value.Hometw + item1.Value.Awaytw).Contains(o.Hometw))
                                    {
                                        if (item1.Value.Betflag != o.Betflag || item1Handicap != oHandicap || m1 > 0.1 || m2 > 0.1 || item1.Value.Odds != o.Odds)
                                        {
                                            if (count > 0)
                                            {
                                                o.ErrorMessage += "；注单有多笔";
                                            }
                                            o.ErrorMessage += "；匹配出错";
                                            if (item1.Value.Betflag != o.Betflag)
                                            {
                                                o.ErrorMessage += "；投注队伍或者类型不同";

                                            }
                                            if (item1Handicap != oHandicap)
                                            {
                                                o.ErrorMessage += "；投注的盘口不同";

                                            }
                                            if (m1 > 0.1)
                                            {
                                                o.ErrorMessage += "；投注金额不同";

                                            }
                                            if (m2 > 0.1)
                                            {
                                                o.ErrorMessage += "；结算金额不同";

                                            }
                                            if (item1.Value.Odds != o.Odds)
                                            {
                                                o.ErrorMessage += "；投注的赔率不同";
                                            }

                                            if (!dic.ContainsKey("o-" + item2.Key) && !dic.ContainsKey("a-" + item1.Key) && !dic.ContainsKey(item2.Key))
                                            {
                                               
                                                o.WebOrderID = "o-" + item2.Value.WebOrderID;
                                                item1.Value.WebOrderID = "a-" + item1.Value.WebOrderID;
                                                dic.Add("a-" + item1.Key, item1.Value);
                                                dic.Add("o-" + item2.Key, o);
                                                count++;

                                            }

                                        }
                                        else
                                        {
                                            count++;

                                        }

                                    }
                                }
                                catch
                                {
                                    count++;
                                    o.ErrorMessage += "；匹配时出现异常，请手工核对";
                                    if (!dic.ContainsKey("o-" + item2.Key) && !dic.ContainsKey("a-" + item1.Key) && !dic.ContainsKey(item2.Key))
                                    {
                                        o.WebOrderID = "o-" + item2.Value.WebOrderID;
                                        item1.Value.WebOrderID = "a-" + item1.Value.WebOrderID;
                                        dic.Add("a-" + item1.Key, item1.Value);
                                        dic.Add("o-" + item2.Key, o);
                                       
                                    }
                                }
                            }

                        }
                        catch
                        {

                        }
                    }
                    if (count == 0)
                    {
                        //我们网站上有没有数据，代理上有
                        if (!dic.ContainsKey("a-" + item1.Key) && !dic.ContainsKey(item1.Key))
                        {
                            item1.Value.ErrorMessage += " 代理网站上有此订单，158bet网站上没有";
                            item1.Value.WebOrderID = "a-" + item1.Value.WebOrderID;
                            dic.Add("a-" + item1.Key, item1.Value);
                        }
                    }

                }
            }
            return dic;
        }
        /// <summary>
        /// 公共方法
        /// 一次性从数据库取出所有注单，通过单个帐号获取对应的注单
        /// </summary>
        /// <param name="accountName">帐号</param>
        /// <param name="orderHistorys">日期内所有的注单</param>
        /// <returns>帐号对应日期内的注单</returns>
        public static Dictionary<string, Orderotherhistory> GetDicByAccount(string accountName, Dictionary<string, Orderotherhistory> orderHistorys)
        {
            Dictionary<string, Orderotherhistory> allOrderHistorys = new Dictionary<string, Orderotherhistory>();
            var pf = from d in orderHistorys
                     where d.Value.WebUserName == accountName
                     select d.Value;
            foreach (var item in pf)
            {
                allOrderHistorys.Add(item.WebOrderID.Trim(), item);
            }
            return allOrderHistorys;
        }


    }


}
