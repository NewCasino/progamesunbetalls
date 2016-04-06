using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
using System.Net;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.IO.Compression;
using System.Threading;
namespace DAL
{
    public class AccountService
    {
        private const string SQL_INSERT = "insert into yafa.account (userid,casino,password,group1,address,address2,cookie,time,isquzhi,enable,operat,operatortime,operatorip)values(?userid,?casino,?password,?group1,?address,?address2,?cookie,?time,?isquzhi,?enable,?operat,?operatortime,?operatorip)";
        private const string SQL_UPDATE = "update yafa.account set userid=?userid,casino=?casino,password=?password,group1=?group1,address=?address,address2=?address2,cookie=?cookie,time=?time,isquzhi=?isquzhi,enable=?enable,operat=?operat,operatortime=?operatortime,operatorip=?operatorip where id = ?id";
        private const string SQL_SELECTBYPK = "select id from yafa.account  where account.id = ?id";
        private const string SQL_SELECTALL = "select id,userid,casino,password,group1,address,address2,cookie,time,isquzhi,enable,operat,operatortime,operatorip from yafa.account ";
        private const string SQL_DELETEBYPK = "delete  from yafa.account  where account.id = ?id";
        private const string SQL_SELECTBYCASINO = "select id as a,userid as b from betaccount where casino = ?casinoId";
        private const string SQL_SELECTALLBYCASINO = "select id,casino,userid,password,agent,websitePossess,selfPossess,commission,multiple,group1,address,address2,enable,zemo,isquzhi,cookie,time,operator,operatortime,operatorip from yafa.betaccount where casino=?casino";
        private const string SQL_READRESULT = "select * from betaccount where casino=?casino and userid = ?userid";
        private const string SQL_SELECTORDERBYCASINO = "select ID,UserName,WebUserName,OrderID,WebOrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,BeginTime,BetType,IsHalf,BetItem,Score,Awaycn,Awaytw,Awayen,Awayth,Awayvn,Homecn,Hometw,Homeen,Hometh,Homevn,Handicap,OddsType,Odds,Amount,ValidAmount,Status,WebSiteiID,agent,websitepossess,selfpossess,commission,multiple,gameid,betflag,Result,Reason,Scorehalf,MoreAmount from yafa.orderotherhistory where WebSiteiID = ?WebSiteiID and date(BeginTime) >= date(?startTime) and date(BeginTime) <= date(?endTime)";

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-9-12 14:17:55		
        ///</summary>		
        public Boolean AddAccount(Account account)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?userid",account.Userid),
				 new MySqlParameter("?casino",account.Casino),
				 new MySqlParameter("?password",account.Password),
				 new MySqlParameter("?group1",account.Group1),
				 new MySqlParameter("?address",account.Address),
				 new MySqlParameter("?address2",account.Address2),
				 new MySqlParameter("?cookie",account.Cookie),
				 new MySqlParameter("?time",account.Time),
				 new MySqlParameter("?isquzhi",account.Isquzhi),
				 new MySqlParameter("?enable",account.Enable),
				 new MySqlParameter("?operat",account.Operat),
				 new MySqlParameter("?operatortime",account.Operatortime),
				 new MySqlParameter("?operatorip",account.Operatorip)
			};
            return MySqlHelper2.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-9-12 14:17:55		
        ///</summary>		
        public Boolean UpdateAccount(Account account)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?userid",account.Userid),
				 new MySqlParameter("?casino",account.Casino),
				 new MySqlParameter("?password",account.Password),
				 new MySqlParameter("?group1",account.Group1),
				 new MySqlParameter("?address",account.Address),
				 new MySqlParameter("?address2",account.Address2),
				 new MySqlParameter("?cookie",account.Cookie),
				 new MySqlParameter("?time",account.Time),
				 new MySqlParameter("?isquzhi",account.Isquzhi),
				 new MySqlParameter("?enable",account.Enable),
				 new MySqlParameter("?operat",account.Operat),
				 new MySqlParameter("?operatortime",account.Operatortime),
				 new MySqlParameter("?operatorip",account.Operatorip),
				 new MySqlParameter("?id",account.Id)
			};
            return MySqlHelper2.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-9-12 14:17:55		
        ///</summary>		
        public Boolean DeleteAccountByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};
            return MySqlHelper2.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2010-9-12 14:17:55		
        ///</summary>		
        public Account GetAccountByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};

            return MySqlModelHelper2<Account>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2010-9-12 14:17:55		
        ///</summary>		
        public IList<Account> GetMutilILAccount()
        {
            return MySqlModelHelper2<Account>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2010-9-12 14:17:55		
        ///</summary>		
        public DataTable GetMutilDTAccount()
        {
            return MySqlHelper2.ExecuteDataTable(SQL_SELECTALL, null);
        }

        /// <summary>
        /// 根据网站获取所有帐号
        /// </summary>
        /// <param name="casino"></param>
        /// <returns></returns>
        public IList<Betaccount> GetBetAccount(string casino)
        {
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?casino",casino)
            };
            return MySqlModelHelper<Betaccount>.GetObjectsBySql(SQL_SELECTALLBYCASINO, parm);
        }

        /// <summary>
        /// 根据网站获取所有外调注单
        /// </summary>
        /// <param name="casino"></param>
        /// <returns></returns>
        public Dictionary<string, Orderotherhistory> GetOrderListByWebsiteID(string casino,string startTime,string endTime)
        {
            Dictionary<string, Orderotherhistory> orderHistory = new Dictionary<string, Orderotherhistory>();
            MySqlParameter[] parm = new MySqlParameter[] {
                new MySqlParameter("?WebSiteiID",casino),
                new MySqlParameter("?startTime",startTime),
                new MySqlParameter("?endTime",endTime)
            };
            IList<Orderotherhistory> order = MySqlModelHelper<Orderotherhistory>.GetObjectsBySql(SQL_SELECTORDERBYCASINO, parm);
            for (int j = 0; j < order.Count; j++)
            {
                if (order[j].WebOrderID != "")
                {
                    orderHistory.Add(order[j].WebOrderID, order[j]);
                }
            }
            return orderHistory;
        }

        #endregion

        #region 编写人:李毅
        public string getDataAll(int IDex, int IDexC, string casino, string group, string time1, string time2, string enable)
        {
            string where = "where";
            Casino ca = new Casino();

            if (casino != "0")
            {
                if (where == "where")
                {
                    where += " casino=" + casino.Replace("'", "") + "";
                }
            }
            if (group != "")
            {
                if (where == "where")
                {
                    where += " group1=" + group + "";
                }
                else
                {
                    where += " and group1=" + group + "";
                }
            }
            if (time1 != "")
            {
                if (where == "where")
                {
                    where += " date(time)>=date('" + DateTime.Parse(time1) + "')";
                }
                else
                {
                    where += " and date(time)>=date('" + DateTime.Parse(time1) + "')";
                }
            }
            if (time2 != "")
            {
                if (where == "where")
                {
                    where += " date(time)<=date('" + DateTime.Parse(time2) + "')";
                }
                else
                {
                    where += " and date(time)<=date('" + DateTime.Parse(time2) + "')";
                }
            }
            if (enable != "-1")
            {
                if (where == "where")
                {
                    where += " enable=" + enable + "";
                }
                else
                {
                    where += " and enable=" + enable + "";
                }
            }
            if (where == "where")
            {
                return ObjectToJson.ReaderToJson(MySqlHelper2.ExecuteReader(SQL_SELECTALL + " limit " + IDex + "," + IDexC));
            }
            else
            {
                string str = SQL_SELECTALL + " " + where;
                return ObjectToJson.ReaderToJson(MySqlHelper2.ExecuteReader(str + " limit " + IDex + "," + IDexC));
            }
        }

        public string getCount(string casino, string group, string time1, string time2, string enable)
        {
            string where = "where";
            string str = "select count(*) from account ";
            Casino ca = new Casino();

            if (casino != "0")
            {
                if (where == "where")
                {
                    where += " casino=" + casino.Replace("'", "") + "";
                }
            }
            if (group != "")
            {
                if (where == "where")
                {
                    where += " group1=" + group + "";
                }
                else
                {
                    where += " and group1=" + group + "";
                }
            }
            if (time1 != "")
            {
                if (where == "where")
                {
                    where += " date(time)>=date('" + DateTime.Parse(time1) + "')";
                }
                else
                {
                    where += " and date(time)>=date('" + DateTime.Parse(time1) + "')";
                }
            }
            if (time2 != "")
            {
                if (where == "where")
                {
                    where += " date(time)<=date('" + DateTime.Parse(time2) + "')";
                }
                else
                {
                    where += " and date(time)<=date('" + DateTime.Parse(time2) + "')";
                }
            }
            if (enable != "-1")
            {
                if (where == "where")
                {
                    where += " enable=" + enable + "";
                }
                else
                {
                    where += " and enable=" + enable + "";
                }
            }
            if (where == "where")
            {
                return MySqlHelper2.ExecuteScalar(str).ToString();
            }
            else
            {
                return MySqlHelper2.ExecuteScalar(str + " " + where).ToString();
            }
        }

        public string getDataToID(string id)
        {

            string str = SQL_SELECTALL + " where id=?id";
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?id",id)
            };

            return ObjectToJson.ReaderToJson(MySqlHelper2.ExecuteReader(str, param));
        }

        public string getInfo(string username)
        {
            string str = "select count(*) from account where userid=?username";
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?username",username)
            };
            return MySqlHelper2.ExecuteScalar(str, param).ToString();
        }
        #endregion


        #region

        /// <summary>
        /// 根据网站id获取其所有投注账号
        /// </summary>
        /// <param name="casinoId">网站id</param>
        /// <returns></returns>
        public string GetAccountData(string casinoId)
        {
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?casinoId",casinoId)
            };
            var json = ObjectToJson.ReaderToJson(MySqlHelper2.ExecuteReader(SQL_SELECTBYCASINO, parm));
            return json == "[]" ? "none" : json;
        }

        #endregion
        #region
        /// <summary>
        /// 根据网站id获取其所有投注账号
        /// 获取对应的下注状况
        /// </summary>
        /// <param name="casino">网站id</param>
        /// /// <param name="userid">网站帐号</param>
        /// <returns></returns>
        public string readResult(string casino, string userid)
        {
            string html = "";
            Betaccount account = new Betaccount();
            using (MySqlConnection cn = new MySqlConnection(MySqlHelper.ConnectionString))
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "select * from betaccount where casino='" + casino + "' and userid='" + userid + "'";
                MySqlDataReader rs = cmd.ExecuteReader();
                if (rs.Read())
                {
                    account.Casino = rs.GetInt16("casino");
                    account.Userid = rs.GetString("userid");
                    account.Password = rs.GetString("password");
                    account.Agent = rs.GetString("agent");
                    account.Address = rs.GetString("address");
                    account.Address2 = rs.GetString("address2");
                    account.Cookie = rs.GetString("cookie");
                    account.loginname = rs.GetString("loginname");
                    rs.Close();
                    if (account.Address.Trim().Length == 0)
                    {
                        cmd.CommandText = "select * from casino where id=" + casino;
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            account.Address = rs.GetString("address");
                        }
                        rs.Close();
                    }
                    switch (account.Casino)
                    {
                        case 1:
                            html = huanguanReadResult(account);
                            break;
                        case 2:
                            html = lijiReadResult(account);
                            break;
                        case 3:
                            html = shabaReadResult(account);
                            break;
                        case 4:
                            html = xinqiuReadResult(account);
                            break;
                        case 5:
                            html = yongliReadResult(account);
                            break;
                        case 6:
                            html = mmmReadResult(account);
                            break;
                        case 7:
                            html = as3388ReadResult(account);
                            break;
                        case 8:
                            html = huangchaoReadResult(account);
                            break;
                    }
                }
                else
                {
                    rs.Close();
                }
            }

            return html;
        }
        public static string huanguanReadResult(Betaccount user)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string content = "";
            string url = "";
            string referer = "";
            url = "http://" + user.Address + "/app/member/today/today_wagers.php?uid=" + user.Cookie + "&langx=zh-tw";
            referer = "http://" + user.Address + "/app/member/FT_header.php?uid=" + user.Cookie + "&showtype=&langx=zh-tw&mtype=3";
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/QVOD, */*";
                request.Referer = referer;
                request.Headers["Accept-Language"] = "zh-cn";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers["Accept-Encoding"] = "gzip, deflate";

                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; InfoPath.2; CIBA)";
                request.KeepAlive = false;
                request.Timeout = 5000;
                request.Headers["Cache-Control"] = "no-cache";


                response = (HttpWebResponse)request.GetResponse();


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
                if (content.Contains("<script>window.open('http://www.hg0088.com/tpl/logout_warn.html','_top')</script>"))
                {
                    content = "<center>帐号已被登出或还没有登录！</center>";
                }
                else
                {
                    content = content.Replace("/style/member/mem_body.css", "/css/Default/website/huangguan/mem_body.css");
                    content = content.Replace("<p", "<!--<p");
                    content = content.Replace("</p>", "</p>-->");
                    content = content.Replace("<input", "<!--<input");
                    content = content.Replace(";\">", "\">-->");
                    content = content.Replace("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" id=\"box\">", "<table width=\"530px\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" id=\"box\">");
                }
            }
            catch (Exception e)
            {
                return content;
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
                    if (stream != null)
                        stream.Close();
                }
                catch (Exception)
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
            return content;

        }
        public static string lijiReadResult(Betaccount user)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string url = "";
            string content = "";
            url = "http://" + user.Address2 + "/webroot/restricted/Betlist/BetList.aspx";
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/QVOD, */*";

                request.Headers["Accept-Language"] = "zh-cn";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers["Accept-Encoding"] = "gzip, deflate";

                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                request.KeepAlive = true;
                request.Timeout = 6000;
                request.Headers["Cache-Control"] = "no-cache";
                request.Headers["Cookie"] = user.Cookie;
                //request.GetRequestStream().Write(bytes, 0, bytes.Length);
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
                if (content.Contains("logout.aspx"))
                {
                    content = "<center>帐号已被登出或还没有登录！</center>";
                }
                else
                {
                    content = content.Replace("http://img-1-2.sbostatic.com/css/global.css?110202", "/css/Default/website/sbobet/global.css");
                    content = content.Replace("http://img-1-2.sbostatic.com/css/maincontent.css?110202", "/css/Default/website/sbobet/maincontent.css");
                    string s1 = "", s2 = "<script src=\"http://txt-1-2.sbostatic.com/js/common.js?110201\" type=\"text/JavaScript\"></script>";
                    int p1 = 0, p2 = 0;
                    p1 = content.IndexOf(s2);
                    s1 = content.Substring(0, p1);
                    s2 = content.Substring(p1 + s2.Length);
                    p2 = s2.IndexOf("</script>");
                    s2 = s2.Substring(p2 + 9);
                    content = s1 + "" + s2;
                }
                return content;
            }
            catch (Exception e)
            {
                return content;
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch (Exception e)
                {
                    ;
                }
                try
                {
                    if (stream != null)
                        stream.Close();
                }
                catch (Exception)
                {
                    ;
                }
                try
                {
                    response.Close();
                }
                catch (Exception e)
                {
                    ;
                }
            }
        }
        public static string shabaReadResult(Betaccount user)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string url = "";
            string content = "";
            try
            {
                url = "http://" + user.Address2 + "/BetList.aspx";
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/QVOD, */*";
                request.Referer = "http://" + user.Address2 + "/LeftAllInOne.aspx";
                request.Headers["Accept-Language"] = "zh-cn";

                request.Headers["Accept-Encoding"] = "gzip, deflate";

                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                request.KeepAlive = true;

                request.Headers["Cookie"] = user.Cookie;

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
                if (content.Contains("<BODY><P></BODY>") || content.Contains("top.window.location.href=") || content.Contains("Failed to verify login status"))
                {
                    content = "<center>帐号已被登出或者尚未登录</center>";
                }
                else
                {
                    content = "\r\n" + content;
                    content = content.Replace("template/ibcbet/public/css/table_w.css", "/css/Default/website/ibc/table_w.css");
                    content = content.Replace("template/ibcbet/public/css/button.css", "/css/Default/website/ibc/button.css");
                    content = content.Replace("<link href=\"template/ibcbet/public/css/oddsFamily.css\" rel=\"stylesheet\" type=\"text/css\" />", "");
                    content = content.Replace("<!-- <link href=\"css/table_w.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n\t<link href=\"css/button.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n\t<link href=\"css/oddsFamily.css\" rel=\"stylesheet\" type=\"text/css\" /> -->", "");
                    content = content.Replace("template/ibcbet/public/images/layout/title_soccer1.gif", "/images/website/ibc/title_soccer1.gif");
                    content = content.Replace("Betlist.aspx", "#");
                }

                return content;
            }
            catch (Exception e)
            {
                return content;
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch (Exception e)
                {
                    ;
                }
                try
                {
                    if (stream != null)
                        stream.Close();
                }
                catch (Exception)
                {
                    ;
                }
                try
                {
                    response.Close();
                }
                catch (Exception e)
                {
                    ;
                }

            }

        }
        public static string xinqiuReadResult(Betaccount user)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string url = "";
            string content = "";
            url = "http://welcome.188bet.com/zh-tw/my-account/statement/betting-history/sports/unsettled-bets";
            //url = "http://welcome.188bet.com/zh-tw/Service/MyBetService?GetMyBet";
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Headers["x-requested-with"] = "XMLHttpRequest";
                request.Headers["Accept-Language"] = "zh-cn";

                request.Referer = "http://welcome.188bet.com/zh-tw/sports/football/matches-by-date/today/asian-handicap-and-over-under";

                request.Accept = "*/*";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; InfoPath.2; CIBA)";

                //request.Timeout = 7000;


                request.KeepAlive = true;
                request.Headers["Cache-Control"] = "no-cache";
                request.Headers["Cookie"] = user.Cookie;

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
                if (content.Contains("{lostConn:true}"))
                {
                    content = "<center>帐号已被登出或者尚未登录</center>";
                }
                else
                {
                    content = substring3(content, "<div id=\"content-panel\">", "value=\"statement\" />");
                    StringBuilder sb = new StringBuilder();

                    sb.Append("\r\n<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
                    sb.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
                    sb.Append("<head>");
                    sb.Append("<title>无标题文档</title>");
                    sb.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
                    sb.Append("<link href=\"/css/Default/website/188bet/UserContents.css\" rel=\"stylesheet\" type=\"text/css\"/>");
                    sb.Append("</head>");
                    sb.Append("<body>");
                    sb.Append(content);
                    sb.Append("</body>");
                    sb.Append("</html>");

                    content = sb.ToString();
                    content = content.Replace("class=\"print\">打印</a>", "class=\"print\" onclick=\"window.print()\">打印</a>");
                }
                return content;
            }
            catch (Exception e)
            {
                return content;
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch (Exception e)
                {
                    ;
                }
                try
                {
                    if (stream != null)
                        stream.Close();
                }
                catch (Exception)
                {
                    ;
                }
                try
                {
                    response.Close();
                }
                catch (Exception e)
                {
                    ;
                }
            }
        }

        public static string substring3(string s1, string s2, string s3)
        {
            int p1 = 0;
            int p2 = 0;
            try
            {
                p1 = s1.IndexOf(s2);
                p2 = s1.IndexOf(s3);
                if (p1 < 0 || p2 < 0 || p2 < p1)
                    return null;
                return s1.Substring(p1, p2 + s3.Length - p1);
            }
            catch (Exception ee)
            {
                return null;
            }
        }

        public static string substring4(string s1, string s2, string s3)
        {
            int p1 = 0;
            int p2 = 0;
            try
            {
                p1 = s1.IndexOf(s2);
                p2 = s1.IndexOf(s3);
                if (p1 < 0 || p2 < 0 || p2 < p1)
                    return null;
                return s1.Substring(p1, p2 - p1);
            }
            catch (Exception ee)
            {
                return null;
            }
        }

        public static string yongliReadResult(Betaccount user)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string url = "";
            string content = "";
            Encoding big5 = Encoding.GetEncoding("big5");
            url = "http://" + user.Address + "/right/current/";
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/QVOD, */*";
                //request.Referer = referer;
                request.Headers["Accept-Language"] = "zh-cn";

                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.Headers["Cookie"] = user.Cookie;

                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                request.KeepAlive = true;
                //request.Timeout = 5000;
                request.Headers["Cache-Control"] = "no-cache";
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
                content = content.Replace("setTimeout('document.formmatch.submit()',180*1000);", "");
                if (content.Contains("系统繁忙, 请重新登入") || content.Contains("self.parent.location='/logout.php';"))
                {
                    content = "<center>帐号已被登出或者尚未登录</center>";
                }
                else
                {
                    content = content.Replace("/include/style.css", "/css/Default/website/a1a888/style.css");
                    content = content.Replace("../../images/notice-img/1.gif", "/images/website/a1a888/1.gif");
                    content = content.Replace("../../images/notice-img/bj.gif", "/images/website/a1a888/bj.gif");
                    content = content.Replace("../../right/news/index.php?marquee=true\"  target=\"right_wgo_1252978", "#");
                    content = content.Replace("clock.innerHTML", "document.getElementById(\"clock\").innerHTML");
                }
                return content;
            }
            catch (Exception e)
            {
                return content;
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch (Exception)
                {
                    ;
                }
                try
                {
                    if (stream != null)
                        stream.Close();
                }
                catch (Exception)
                {
                    ;
                }
                try
                {
                    response.Close();
                }
                catch (Exception e)
                {
                    ;
                }
            }
        }
        public static string mmmReadResult(Betaccount user)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string url = "";
            string content = "";
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.Length);
            sb.Append("<html><head><title></title><link href=\"http://333h2k.mmmbet.net/portal.css\" type=\"text/css\" rel=\"stylesheet\"></head>");
            sb.Append("<body style=\"background:;\">");
            //url = "http://" + user.Address + "/_norm/stake.aspx";
            url = "http://" + user.Address2 + "/_norm/Stake.aspx?userName=" + user.Userid;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                request.Headers["Accept-Language"] = "zh-CN";

                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.Headers["Cookie"] = user.Cookie;

                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; InfoPath.3; InfoPath.2)";
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
                if (content.Contains("Object moved to"))
                {
                    content = "<center>帐号已被登出或者尚未登录</center>";
                }
                else
                {
                    content = substring(content, "<table class=\"grid\"", "</table>");
                    content = content.Replace("href=\"javascript:__doPostBack('Stake_mb1$grdStake$ctl04$btnSubmit','')\"", "href=\"#\"");
                }
                sb.Append("<table class=\"grid\" style=\"width:740px;text-align:left;margin:0px;\"");
                sb.Append(content);
                sb.Append("</table>");
                sb.Append("</body></html>");
                return sb.ToString();
            }
            catch (Exception)
            {
                return sb.ToString();
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch (Exception)
                {
                    ;
                }
                try
                {
                    if (stream != null)
                        stream.Close();
                }
                catch (Exception)
                {
                    ;
                }
                try
                {
                    response.Close();
                }
                catch (Exception)
                {
                    ;
                }
            }
        }

        public static string as3388ReadResult(Betaccount user)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string url = "";
            string content = "";
            string referer = "";
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            //url = "http://" + user.Address + "/user_sportsinfo8/traditional/index.php?p=templet_pending_bets";
            url = "http://" + user.Address + "/user_sportsinfo8/traditional/index.php?p=user_bets_enquiry_action&fr_matchdate=&fr_type=soccer&groupby=0&timezone=America/La_Paz";
            //http://www.sportsinfo8.net/user_sportsinfo8/traditional/index.php?p=user_bets_enquiry
            //url = "http://" + user.Address + "/user_sportsinfo8/traditional/index.php?p=user_bets_enquiry";
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/QVOD, */*";
                request.Referer = referer;
                request.Headers["Accept-Language"] = "zh-cn";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers["Accept-Encoding"] = "gzip, deflate";

                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                request.KeepAlive = true;
                //request.Timeout = 5000;
                request.Headers["Cache-Control"] = "no-cache";
                //request.ContentLength = bytes.Length;
                request.Headers["Cookie"] = user.Cookie;
                request.AllowAutoRedirect = false;
                //request.GetRequestStream().Write(bytes, 0, bytes.Length);
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
                content = ToUnicode(content);
                //content=content.Replace("../user/javascript/user_bets_enquiry_interface.js","http://"+ user.Address + "/user/javascript/user_bets_enquiry_interface.js");
                //content = content.Replace("../user/javascript/user_bets_enquiry_function.js", "http://" + user.Address + "/user/javascript/user_bets_enquiry_function.js");
                //content = content.Replace("../user/javascript/active-mousemove.js", "http://" + user.Address + "/user/javascript/active-mousemove.js");
                //content = content.Replace("css/user.css", "http://" + user.Address + "/user_sportsinfo8/traditional/css/user.css");
                //content = content.Replace("?p=user_bets_enquiry_action&fr_matchdate=&fr_type=soccer&groupby=0&timezone=America/La_Paz", "http://" + user.Address + "/user_smartbets8/traditional/index.php?p=user_bets_enquiry_action&fr_matchdate=&fr_type=soccer&groupby=0&timezone=America/La_Paz");
                //content = content.Substring(0, content.IndexOf("</div><br><html>") + "</div><br><html>".Length);
                //content=content.Replace("<html>","").Replace("<head>","").Replace("<title></title>","").Replace("<body background=\"images/background.gif\" oncontextmenu=\"return false;\">","").Replace("<html>","");
                //content = content.Replace("display:none", "display:block");
                string[] arr;
                StringBuilder sb = new StringBuilder();

                sb.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
                sb.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
                sb.Append("<head>");
                sb.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
                sb.Append("<title>无标题文档</title>");
                sb.Append("</head>");
                sb.Append("<style>");
                sb.Append(".right_comp body{ font-size:12px; color:#333;}");
                sb.Append(".right_comp table {");
                sb.Append("    border-collapse: collapse;");
                sb.Append("}");
                sb.Append(".right_comp tr {");
                sb.Append("    background-color: #EFEFEF;");
                sb.Append("}");
                sb.Append(".right_comp .teambet {");
                sb.Append("    color: maroon;");
                sb.Append("    font-weight: normal;");
                sb.Append("}");
                sb.Append(".right_comp .odds {");
                sb.Append("    color: red;");
                sb.Append("    font-weight: bold;");
                sb.Append("}");
                sb.Append(".right_comp .hdp {");
                sb.Append("    color: blue;");
                sb.Append("    font-weight: bold;");
                sb.Append("}");
                sb.Append(".right_comp .matches td {");
                sb.Append("    font-size: 12px;");
                sb.Append("    padding: 2px 4px;");
                sb.Append("    text-align: left;");
                sb.Append("}");
                sb.Append("</style>");
                sb.Append("<body><br/>");
                sb.Append("<table width=\"70%\" cellspacing=\"0\" bordercolor=\"#000066\" border=\"1\" class=\"matches\">");
                sb.Append("<tbody>");
                sb.Append("<tr>");
                sb.Append("<th>號碼</th>");

                sb.Append("<th>時間</th>");
                sb.Append("<th>种类</th>");
                sb.Append("<th>詳情</th>");
                sb.Append("<th>注额</th>");
                sb.Append("<th>可贏額</th>");
                sb.Append("</tr>");
                double sum = 0.00, sum1 = 0.00;
                content = content.Replace("\'", "").Replace("\"", "");
                int i = 0;
                string s = "";
                while (content.Contains("$be[" + i.ToString() + "]=["))
                {
                    s = substring(content, "$be[" + i.ToString() + "]=[", "]");
                    content = substring2(content, "$be[" + i.ToString() + "]=[", "]");
                    arr = s.Split(',');
                    sb.Append("<td style=\"text-align: center;\">").Append(arr[0]).Append("</td>");
                    sb.Append("<td style=\"text-align: center;\">").Append(arr[1]).Append("<br>").Append(arr[2]).Append("</td>");
                    sb.Append("<td nowrap=\"\" style=\"text-align: center;\">").Append(arr[3]).Append("<br>").Append(arr[4]).Append("</td>");
                    sb.Append("<td style=\"text-align: right;\">").Append(arr[5]).Append("</td>");
                    sb.Append("<td style=\"text-align: right;\">").Append(arr[6]).Append("</td>");
                    sb.Append("<td style=\"text-align: right;\">").Append(arr[7]).Append("</td>    </tr>");
                    try
                    {
                        sum = sum + double.Parse(arr[6]);


                    }
                    catch (Exception e)
                    {

                    }
                    try
                    {
                        sum1 = sum1 + double.Parse(arr[7]);
                    }
                    catch (Exception e)
                    {

                    }
                    i++;

                }

                sb.Append("<tr style=\"background-color: rgb(233, 233, 233);\">");
                sb.Append("<td class=\"tdR\" colspan=\"4\">&nbsp;</td>");
                sb.Append("<td bgcolor=\"lightyellow\" style=\"text-align: right;\"><b style=\"font-size: 14px; color: brown;\">" + sum.ToString("F1") + "</b></td>");
                sb.Append("<td bgcolor=\"lightyellow\" style=\"text-align: right;\"><b style=\"font-size: 14px; color: brown;\">" + sum1.ToString("F1") + "</b></td>");
                sb.Append("</tr>");
                sb.Append("</tbody>");
                sb.Append("</table>");
                sb.Append("</body>");
                sb.Append("</html>");


                if (content == "\r\n")
                {
                    content = "<center>帐号已被登出或者尚未登录</center>";
                }
                content = sb.ToString();
                return content;
            }
            catch (Exception e)
            {
                return content;
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch (Exception)
                {
                    ;
                }
                try
                {
                    if (stream != null)
                        stream.Close();
                }
                catch (Exception)
                {
                    ;
                }
                try
                {
                    response.Close();
                }
                catch (Exception)
                {
                    ;
                }
            }
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

        public static string huangchaoReadResult(Betaccount user)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string url = "";
            string content = "";
            string referer = "";

            url = "https://" + user.Address + "/sb2/me/list_bet.jsp";
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/QVOD, */*";
                request.Referer = referer;
                request.Headers["Accept-Language"] = "zh-cn";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers["Accept-Encoding"] = "gzip, deflate";

                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                request.KeepAlive = true;
                request.Timeout = 6000;
                request.Headers["Cache-Control"] = "no-cache";

                request.Headers["Cookie"] = user.Cookie;
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
                if (content.Contains("Exception Error"))
                {
                    content = "<center>帐号已被登出或者尚未登录</center>";
                }
                else
                {
                    content = substring4(content, "<div class=\"pageTitleBar\">", "<div id=\"footer\">");
                    //content = substring4(content, "<div class=\"pageTitleBar\">", "<table width=\"736\">");
                    content = content.Replace("<button class=\"btnBackSimple\" onclick=\"doBack();\">返回</button>", "");
                    content = content.Replace("<button class=\"btnPrint\" onclick=\"printThisPage()\">列印</button>", "");
                    StringBuilder sb = new StringBuilder();
                    sb.Append("\r\n<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
                    sb.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
                    sb.Append("<head>");
                    sb.Append("<title>无标题文档</title>");
                    sb.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
                    sb.Append("<link href=\"/css/Default/website/huangchao/print.css\" rel=\"stylesheet\" type=\"text/css\"/>");
                    sb.Append("<link href=\"/css/Default/website/huangchao/style.css\" rel=\"stylesheet\" type=\"text/css\"/>");
                    sb.Append("</head>");
                    sb.Append("<body>");
                    sb.Append(content);
                    sb.Append("</body>");
                    sb.Append("</html>");

                    content = sb.ToString();
                    content = content.Replace("class=\"btnPrint \">打印</button>", "class=\"btnPrint\" onclick=\"window.print()\">打印</button>");
                }
                return content;
            }
            catch (Exception e)
            {
                return content;
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch (Exception)
                {
                    ;
                }
                try
                {
                    if (stream != null)
                        stream.Close();
                }
                catch (Exception)
                {
                    ;
                }
                try
                {
                    response.Close();
                }
                catch (Exception)
                {
                    ;
                }
            }
        }
        private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        #endregion

        #region
        /// <summary>
        /// 根据网站id获取其所有投注账号
        /// 获取对应的下注历史
        /// </summary>
        /// <param name="casino">网站id</param>
        /// <param name="userid">网站帐号</param>
        /// <returns></returns>
        public string readHistory(string casino, string userid, DateTime[] currentDay)
        {
            string html = "";
            Betaccount account = new Betaccount();
            using (MySqlConnection cn = new MySqlConnection(MySqlHelper2.ConnectionString))
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "select * from betaccount where casino='" + casino + "' and userid='" + userid + "'";
                MySqlDataReader rs = cmd.ExecuteReader();
                if (rs.Read())
                {
                    account.Casino = rs.GetInt16("casino");
                    account.Userid = rs.GetString("userid");
                    account.Password = rs.GetString("password");
                    account.Agent = rs.GetString("agent");
                    account.Address = rs.GetString("address");
                    account.Address2 = rs.GetString("address2");
                    account.Cookie = rs.GetString("cookie");
                    account.loginname = rs.GetString("loginname");
                    rs.Close();
                    if (account.Address.Trim().Length == 0)
                    {
                        cmd.CommandText = "select * from casino where id=" + casino;
                        rs = cmd.ExecuteReader();
                        if (rs.Read())
                        {
                            account.Address = rs.GetString("address");
                        }
                        rs.Close();
                    }
                    switch (account.Casino)
                    {
                        case 1:
                            html = huanguanReadHistory(account, currentDay);
                            break;
                        case 2:
                            html = lijiReadHistory(account, currentDay);
                            break;
                        case 3:
                            html = shabaReadHistory(account, currentDay);
                            break;
                        case 4:
                            html = xinqiuReadHistory(account, currentDay);
                            break;
                        case 5:
                            html = yongliReadHistory(account, currentDay);
                            break;
                        case 6:
                            break;
                        case 7:
                            html = as3388ReadHistory(account, currentDay);
                            break;
                        case 8:
                            html = huangchaoReadHistory(account, currentDay);
                            break;
                    }
                }
                else
                {
                    rs.Close();
                }
            }
            return html;
         }

        public static string huanguanReadHistory(Betaccount user, DateTime[] date)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string content = "";
            string url = "";
            string referer = "";
            string html;
            string[] sar;
            byte[] bytes;
            int count = 0, page = 0, pagecount = 1;
            string member_id = "", chk_date = "", postdata = "",tzje="",days="";
            url = "http://" + user.Address + "/app/member/history/history_data.php?uid=" + user.Cookie + "&langx=zh-cn";
            //url = "http://" + user.Address + "/app/member/today/today_wagers.php?uid=" + user.Cookie + "&langx=zh-tw";
            referer = "http://" + user.Address + "/app/member/FT_header.php?uid=" + user.Cookie + "&showtype=&langx=zh-tw&mtype=3";
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.Length);

            for (int i = 0; i < date.Length; i++)
            {
                //gtype=ALL&gdate=2011-03-24&gdate1=2011-03-31
                postdata = "gtype=ALL&gdate=" + date[i].ToString("yyyy-MM-dd") + "&gdate1=" + date[i].ToString("yyyy-MM-dd");
                try
                {
                    url = "http://" + user.Address + "/app/member/history/history_data.php?uid=" + user.Cookie + "&langx=zh-tw";
                    referer = "http://" + user.Address + "/app/member/history/history_data.php?uid=" + user.Cookie + "&langx=zh-tw";
                    bytes = Encoding.ASCII.GetBytes(postdata);
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "POST";
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    //request.Referer = referer;
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET4.0C; .NET4.0E; CIBA; InfoPath.3)";
                    request.KeepAlive = true;
                    request.Headers["Cache-Control"] = "no-cache";
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
                    content = reader.ReadToEnd();
                    html = substring(content, "<tr class=\"b_rig\">", "</table> ");
                    sar = html.Split(new string[] { "<tr class=\"b_rig\">" }, StringSplitOptions.None);
                    
                }
                catch (Exception)
                {
                    return sb.ToString();
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
                        if (stream != null)
                            stream.Close();
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
                int x = 0;
                while (x < sar.Length - 1)
                {
                    tzje = substring(sar[x], "<td>", "</td>");

                    if (tzje == "0")
                    {
                        days = substring(sar[x], "<td class=\"b_fwn\"><font color=#CC0000>", "</font></td>");
                        x++;
                        continue;
                    }
                    days = substring(sar[x], "<span class=\"td_fwn\">", "</span>");
                    string url2 = substring(sar[x], "<a href=\"", "&page=");
                    x++;
                    while (page < pagecount)
                    {
                        try
                        {
                            //http://www.hg0088.com/app/member/history/history_view.php?uid=4145005cm6261502l21363743&member_id=6261502&tmp_flag=Y&today_gmt=2011-03-23&gtype=ALL&gdate=2011-03-22&gdate1=2011-03-29&chk_date=2011-03-20&page=0
                            //url = "http://" + user.address + "/app/member/history/history_view.php?uid=" + user.cookie + "&member_id=" + member_id + "&tmp_flag=Y&today_gmt=" + today_gmt + "&gtype=ALL&gdate=" + gdate + "&gdate1=" + gdate1 + "&chk_date=" + chk_date + "&page=" + page;
                            url = "http://" + user.Address2 + "/app/member/history/" + url2 + "&page=" + page;
                            page++;
                            referer = "http://" + user.Address2 + "/app/member/history/history_data.php?uid=" + user.Cookie + "&langx=zh-tw";
                            request = (HttpWebRequest)WebRequest.Create(url);
                            request.Method = "GET";
                            request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                            request.Referer = referer;
                            request.Headers["Accept-Language"] = "zh-cn";
                            //request.ContentType = "application/x-www-form-urlencoded";
                            request.Headers["Accept-Encoding"] = "gzip,deflate";

                            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET4.0C; .NET4.0E; CIBA; InfoPath.3)";
                            request.KeepAlive = true;
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
                        catch (Exception)
                        {
                            return sb.ToString();
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
            }
            return sb.ToString();
        }

        public static string lijiReadHistory(Betaccount user, DateTime[] date)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            string content = string.Empty;
            Encoding utf8 = Encoding.UTF8;
            string url = string.Empty;
            StringBuilder sb = new StringBuilder();
            string temp = string.Empty;
            string table = string.Empty;
            string tr = string.Empty;
            string td = string.Empty;
            string div = string.Empty;
            int j = 0;
            decimal count = 0, commission = 0;
            decimal count1 = 0, commission1 = 0;
            sb.Remove(0, sb.Length);
            sb.Append("\r\n<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            sb.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            sb.Append("<head>");
            sb.Append("<title>无标题文档</title>");
            sb.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
            sb.Append("<link href=\"http://img-1-2.sbostatic.com/css/global.css?110401\" rel=\"stylesheet\" type=\"text/css\"/>");
            sb.Append("<link href=\"http://img-1-2.sbostatic.com/css/maincontent.css?110401\" rel=\"stylesheet\" type=\"text/css\"/>");
            sb.Append("</head>");
            sb.Append("<body>");
            for (int i = 0; i < date.Length; i++)
            {
                try
                {
                    url = "http://" + user.Address2 + "/webroot/restricted/Betlist/BetList.aspx?d=" + date[i].ToString("MM/dd/yyy") + "&option=c";
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/QVOD, */*";
                    request.Referer = "http://" + user.Address2 + "/webroot/restricted/Betlist/Statement.aspx";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                    request.KeepAlive = true;
                    request.Timeout = 6000;
                    request.Headers["Cache-Control"] = "no-cache";
                    request.Headers["Cookie"] = user.Cookie;
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
                    if (content.Contains("logout.aspx"))
                    {
                        content = i == 0 ? "<center>帐号已被登出或还没有登录！</center>" : "";
                    }
                    else
                    {
                        content = content.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                        if (i == 0)
                        {
                            temp = substring(content, "<body>", "<tr class=\"TRTotal\">");
                            table = substring2(content, "<table", "<!--Start of Table Border-->");
                            table = substring(table, "<table", "<div class=");
                            table = substring(table, "<table ", "</table><!");
                            tr = substring2(table, "<tr", "</tr>");
                            table = substring(tr, "<tr ", "</tr>");
                            div = substring2(tr, "<tr ", "</tr>");
                            while (table != null && !table.Contains("class=\"TRTotal\""))
                            {
                                td = table.Replace("<td class=\"FontNormal\">" + substring(table, ">", "</td>") + "</td>", (++j).ToString());
                                temp = temp.Replace(table, td);
                                table = substring(div, "<tr ", "</tr>");
                                div = substring2(div, "<tr ", "</tr>");
                            }
                            tr = substring(tr, "<tr class=\"TRTotal\">", "</tr>");
                            td = substring2(tr, "<td", "</td>");
                            div = substring2(td, ">", "<span");
                            count = Convert.ToDecimal(substring(div, ">", "<"));
                            div = substring2(div, ">", "<span");
                            commission = Convert.ToDecimal(substring(div, ">", "<"));
                            content = temp;
                        }
                        else
                        {
                            table = substring2(content, "<table", "<!--Start of Table Border-->");
                            table = substring(table, "<table", "<div class=");
                            table = substring(table, "<table ", "</table><!");
                            tr = substring2(table, "<tr", "</tr>");
                            if(tr.Contains("抱歉！目前無符合資訊！")){
                                content = "<tr class=\"TRTotal\"><td colspan=\"5\"><span class=\"Font12BlackBold\">總計 :</span></td>"+
                                    "<td><span class=\"FontBrown\">"+count+"</span><br /><span class=\"FontOrange Font9\">"+commission+"</span></td><td></td></tr>";
                            }
                            else
                            {
                                temp = "<tr " + substring(tr, "<tr ", "<tr class=\"TRTotal\">");
                                table = substring(tr, "<tr ", "</tr>");
                                div = substring2(tr, "<tr ", "</tr>");
                                while (table != null && !table.Contains("class=\"TRTotal\""))
                                {
                                    td = table.Replace(substring(table, ">", "</td>") + "</td>", "<td class=\"FontNormal\">" + (++j).ToString() + "</td>");
                                    temp = temp.Replace(table, td);
                                    table = substring(div, "<tr ", "</tr>");
                                    div = substring2(div, "<tr ", "</tr>");
                                }                                
                                td = substring2(table, "<td", "</td>");
                                div = substring2(td, ">", "<span");
                                count1 = Convert.ToDecimal(substring(div, ">", "<")) + count;
                                div = substring2(div, ">", "<span");
                                commission1 = Convert.ToDecimal(substring(div, ">", "<")) + commission;
                                content = temp + "<tr class=\"TRTotal\"><td colspan=\"5\"><span class=\"Font12BlackBold\">總計 :</span></td>" +
                                    "<td><span class=\"FontBrown\">" + count1 + "</span><br /><span class=\"FontOrange Font9\">" + commission1 + "</span></td><td></td></tr>";
                            }
                            content = content + "</table></body></html>";
                        }
                        content = content.Replace("<div align=\"center\" class=\"buttonstyle1\"", "<!--<div align=\"center\" class=\"buttonstyle1\"");
                        content = content.Replace("<!--End of Table Border-->", "--><!--End of Table Border-->");
                    }
                    sb.Append(content);
                }
                catch
                {
                    return sb.ToString();
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
                        if (stream != null)
                            stream.Close();
                    }
                    catch (Exception)
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
            return sb.ToString();
        }

        public static string shabaReadHistory(Betaccount user, DateTime[] date)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            string content = "";
            Encoding utf8 = Encoding.UTF8;
            string url = string.Empty;
            string temp= string.Empty;
            string table = string.Empty;
            string tr = string.Empty;
            string td = string.Empty;
            string div = string.Empty;
            string s = "", a = "";
            int j = 0;
            decimal count = 0, commission = 0, total = 0;
            decimal count1 = 0, commission1 = 0, total1 = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append("\r\n<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            sb.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            sb.Append("<head>");
            sb.Append("<title>无标题文档</title>");
            sb.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
            sb.Append("<link href=\"/css/Default/website/ibc/table_w.css\" rel=\"stylesheet\" type=\"text/css\"/>");
            sb.Append("<link href=\"/css/Default/website/ibc/button.css\" rel=\"stylesheet\" type=\"text/css\"/>");
            sb.Append("<link href=\"/css/Default/website/ibc/table_w.css\" rel=\"stylesheet\" type=\"text/css\"/>");
            sb.Append("</head>");
            sb.Append("<body>");
            for (int i = 0; i < date.Length; i++)
            {
                try
                {
                    url = "http://" + user.Address2 + "/DBetlist.aspx?fdate=" + date[i].ToString("MM/dd/yyyy");
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Referer = "http://" + user.Address2 + "/AllStatement.aspx";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; GTB6.6; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; InfoPath.3)";
                    request.KeepAlive = true;
                    request.Headers["Cache-Control"] = "no-cache";
                    request.Headers["Cookie"] = user.Cookie;
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
                    if (content == "" || content.Contains("<BODY><P></BODY>") || content.Contains("top.window.location.href=") || content.Contains("Failed to verify login status"))
                    {
                        content = i == 0 ? "<center>帐号已被登出或者尚未登录</center>" : "";
                    }
                    else
                    {
                        if (i == 0)
                        {
                            temp = substring(content, "<body>", "<td colspan=\"5\" align=\"right\" bgcolor=\"#d8d8d8\">");
                            table = substring2(content, "<table", "</table>");
                            table = substring(table, "<table", "</table");
                            tr = substring2(table, "<tr>", "</tr>");
                            table = substring(tr,"<tr align=\"center\"","</tr>");
                            div = substring2(tr, "<tr align=\"center\"", "</tr>");
                            while (table!=null)
                            {
                                td = table.Replace("<td valign=\"top\">"+substring(table, ">", "</td>")+"</td>",(++j).ToString());
                                temp = temp.Replace(table,td);
                                table = substring(div, "<tr align=\"center\"", "</tr>");
                                div = substring2(div, "<tr align=\"center\"", "</tr>");
                            }
                            tr = substring(tr, "<tr>", "</tr>");
                            td = substring2(tr, "<td", "</td>");
                            div = substring2(td, ">", "><span");                            
                            count = Convert.ToDecimal(substring(div, ">", "<"));
                            div = substring2(div, ">", "><span");
                            commission = Convert.ToDecimal(substring(div, ">", "<"));
                            div = substring2(div, ">", "><span");
                            content = temp.Replace("<a href=\"DBetlist.aspx?fdate", "<!--<a href=\"DBetlist.aspx?fdate");
                            content = content.Replace("刷新</span></a>", "刷新</span></a>-->");
                        }
                        else
                        {
                            table = substring2(content, "<table", "</table>");
                            table = substring(table, "<table", "</table");
                            tr = substring2(table, "<tr>", "</tr>");
                            temp = "</tr><tr align=\"center\"" + substring(tr, "<tr align=\"center\"", "</tr>") + "</tr>";
                            table = substring(tr, "<tr align=\"center\"", "</tr>");
                            div = substring2(tr, "<tr align=\"center\"", "</tr>");
                            while (table != null)
                            {
                                td = table.Replace(substring(table, ">", "</td>") + "</td>", "<td valign=\"top\">" + (++j).ToString() + "</td>");
                                temp = temp.Replace(table, td);
                                table = substring(div, "<tr align=\"center\"", "</tr>");
                                div = substring2(div, "<tr align=\"center\"", "</tr>");
                            }
                            tr = substring(tr, "<tr>", "</tr>");
                            s = substring(substring2(substring(tr, "<td", "</td>"), ">", "><span"), ">", "<");
                            temp += substring(tr,"","</td>")+ "</td>";
                            td = substring2(tr, "<td", "</td>");
                            div = substring2(td, ">", "><span");
                            count1 = Convert.ToDecimal(substring(div, ">", "<")) + count;
                            a = count1 < 0 ? "小計(輸):" : "小計(贏):";
                            div = substring2(div, ">", "><span");
                            commission1 = Convert.ToDecimal(substring(div, ">", "<")) + commission;
                            div = substring2(div, ">", "><span");
                            total1 = count1 + commission1;
                            content = temp + "<td align=\"right\" bgcolor=\"#C6D4F1\"><div class=\"DBetlist\"><span class=\"UdrDogOddsClass\">" + count1 + "</span></div>" +
                                "<div class=\"DBetlist\"><span class=\"UdrDogOddsClass\">" + commission1 + "</span></div><div class=\"DBetlist1\"><span class=\"UdrDogOddsClass\">" +
                                    total1+"</span></div></td></tr>";
                            content = content+"</table></body></html>";
                        }
                        content = content.Replace("template/ibcbet/public/images/layout/", "/images/website/ibc/");
                        content = content.Replace("<a id=\"resultPos","<!--<a id=\"resultPos");
                        content = content.Replace("賽果</a></span>", "賽果</a></span>-->");
                    }
                    sb.Append(content);
                }
                catch
                {
                    return sb.ToString();
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
                        if (stream != null)
                            stream.Close();
                    }
                    catch (Exception)
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
            return string.IsNullOrEmpty(s) ? sb.ToString() : sb.ToString().Replace(s, a);

        }

        public static string xinqiuReadHistory(Betaccount user, DateTime[] date)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string content = "";
            string url = "";
            string referer = "";
            byte[] bytes;
            string postdata = "";
            string __VIEWSTATE = "";
            string __EVENTVALIDATION = "";
            url = "http://" + user.Address2 + "/zh-tw/my-account/statement/betting-history/sports/settled-bets";
            referer = "http://" + user.Address2 + "/zh-tw/my-account/statement/betting-history/sports/settled-bets";
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.Length);
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
                request.Headers["Cookie"] = user.Cookie;
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
                if (content.Contains("name=\"__EVENTVALIDATION\" id=\"__EVENTVALIDATION\" value="))
                {
                    __VIEWSTATE = substring(content, "id=\"__VIEWSTATE\" value=\"/", "\" />");
                    __EVENTVALIDATION = substring(content, "id=\"__EVENTVALIDATION\" value=\"/", "\" />").Replace("/", "%2F").Replace("+", "%2B");
                }
            }
            catch
            {
                return sb.ToString();
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
            int x = 0;
            while (x < date.Length)
            {
                switch (x)
                {
                    case 0:
                        postdata = "__EVENTTARGET=ctl00%24Content%24LinkBtnSubmit&__EVENTARGUMENT=&__VIEWSTATE=%2F" + __VIEWSTATE + "&__EVENTVALIDATION=%2F" + __EVENTVALIDATION + "&ctl00%24Content%24inputFromDatePicker=" + DateTime.Now.ToString("dd-MM-yyyy").Replace("-", "%2F") + "&ctl00%24Content%24inputToDatePicker=" + DateTime.Now.ToString("dd-MM-yyyy").Replace("-", "%2F") + "&daysInput=0&ctl00%24Content%24Todaydate0=" + DateTime.Now.ToString("dd-MM-yyyy").Replace("-", "%2F") + "&ctl00%24Content%24TopKey=statement";
                        break;
                    case 1:
                        postdata = "__EVENTTARGET=ctl00%24Content%24LinkBtnSubmit&__EVENTARGUMENT=&__VIEWSTATE=%2F" + __VIEWSTATE + "&__EVENTVALIDATION=%2F" + __EVENTVALIDATION + "&ctl00%24Content%24inputFromDatePicker=" + DateTime.Now.ToString("dd-MM-yyyy").Replace("-", "%2F") + "&ctl00%24Content%24inputToDatePicker=" + DateTime.Now.ToString("dd-MM-yyyy").Replace("-", "%2F") + "&daysInput=1&ctl00%24Content%24Todaydate0=" + DateTime.Now.ToString("dd-MM-yyyy").Replace("-", "%2F") + "&ctl00%24Content%24TopKey=statement";
                        break;
                }
                x++;
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
                    request.Headers["Cookie"] = user.Cookie;
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
                    sb.Append(content);
                }
                catch (Exception)
                {
                    return sb.ToString();
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
                    try
                    {
                        if (stream != null)
                            stream.Close();
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    try
                    {
                            reader.Close();
                    }
                    catch (Exception)
                    {
                        ;
                    }

                }
            }
            return sb.ToString(); ;
        }

        public static string yongliReadHistory(Betaccount user, DateTime[] date)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string temp = string.Empty;
            decimal a= 0, b = 0, c = 0;
            decimal a1 = 0, b1 = 0, c1 = 0;
            int j = 0;
            string tab = string.Empty, tr = string.Empty, td = string.Empty,div=string.Empty;
            string url = string.Empty;
            string content = string.Empty;
            Encoding big5 = Encoding.GetEncoding("big5");
            StringBuilder sb = new StringBuilder();
            sb.Append("\r\n<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            sb.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            sb.Append("<head>");
            sb.Append("<title>无标题文档</title>");
            sb.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
            sb.Append("<link href=\"/css/Default/website/a1a888/style.css\" rel=\"stylesheet\" type=\"text/css\"/>");
            sb.Append("</head>");
            sb.Remove(0, sb.Length);
            for (int i = 0; i < date.Length; i++)
            {
                try
                {
                    url = "http://" + user.Address + "/right/history/info.php?dateShow=" + date[i].ToString("yyyy-MM-dd hh:mm:ss");
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.Accept = "application/xml,application/xhtml+xml,text/html;q=0.9,text/plain;q=0.8,image/png,*/*;q=0.5";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers["Accept-Encoding"] = "gzip,deflate,sdch";
                    request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US) AppleWebKit/534.10 (KHTML, like Gecko) Chrome/8.0.552.224 Safari/534.10";
                    request.KeepAlive = true;
                    request.Headers["Cookie"] = user.Cookie;
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
                    if (content.Contains("系统繁忙, 请重新登入") || content.Contains("self.parent.location='/logout.php';"))
                    {
                        content = i == 0 ? "<center>帐号已被登出或者尚未登录</center>" : "";
                    }
                    else
                    {
                        if (i == 0)
                        {
                            temp = "<body" + substring(content, "<body", "<tr bgcolor='#BDC7FF'");
                            tab = substring2(content, "<table", "id=\"clock\"");
                            tab = substring(tab, "<table", "<table");
                            tr = substring(tab, "<tr bgcolor='#BDC7FF'", "</tr>");
                            tab = substring(tab, "", "<tr bgcolor='#BDC7FF'");
                            tab = substring2(tab, "<tr ", "</tr>");
                            td = substring(tab, "<tr ", "</tr>");
                            div = substring2(tab, "<tr ", "</tr>");
                            while (td != null && !td.Contains("合計"))
                            {
                                j++;
                                td = substring(div, "<tr ", "</tr>");
                                div = substring2(div, "<tr ", "</tr>");
                            }
                            td = substring(tr, "<td>", "</td>");
                            a = Convert.ToDecimal(td);
                            td = substring2(tr, "<td>", "</td>");
                            b = Convert.ToDecimal(substring(td,"<td>","</td>"));
                            td = substring2(td,"<td>","</td>");
                            c = Convert.ToDecimal(substring(td, "<td>", "</td>"));
                            content = temp.Replace("clock.innerHTML", "document.getElementById(\"clock\").innerHTML");
                        }
                        else
                        {
                            tab = substring2(content, "", "id=\"clock\"");
                            tab = substring(tab, "<table", "<table");
                            tr = substring(tab, "<tr bgcolor='#BDC7FF'", "</tr>");
                            tab = substring2(tab, "<tr ", "</tr>");
                            tab = substring(tab, "<tr ", "</tr>");
                            div = substring2(tab, "<tr ", "</tr>");
                            while (tab != null && !tab.Contains("合計")) {
                                j++;
                                tab = substring(tab, "<tr ", "</tr>");
                                div = substring2(tab, "<tr ", "</tr>");
                            }
                            td = substring(tr, "<td>", "</td>");
                            a1 = Convert.ToDecimal(td)+a;
                            td = substring2(tr, "<td>", "</td>");
                            b1 = Convert.ToDecimal(substring(td, "<td>", "</td>")) + b;
                            td = substring2(td, "<td>", "</td>");
                            c1 = Convert.ToDecimal(substring(td, "<td>", "</td>")) + c;
                            content = "<tr bgcolor='#BDC7FF' align='right'><td colspan='4'>合計 : "+j+"</td><td>"+a1+"</td><td>"+b1+"</td><td>"+c1+"</td></tr>";
                            content = content + "</table></body></html>";
                        }
                        content = content.Replace("../../images/notice-img/", "/images/website/a1a888/");
                        content = content.Replace("../../right/news/index.php?marquee=true\"  target=\"right_wgo_1252978", "#");
                    }
                    sb.Append(content);
                }
                catch
                {
                    return sb.ToString();
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
                        if (stream != null)
                            stream.Close();
                    }
                    catch (Exception)
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
            return sb.ToString();
        }

        public static string as3388ReadHistory(Betaccount user, DateTime[] date)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string url = string.Empty;
            string content = string.Empty;
            double sum = 0.00, sum1 = 0.00;
            string temp = string.Empty;
            string data = string.Empty;
            int j = 0,k=0;
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            string[] arr;
            string s = string.Empty;
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.Length);
            sb.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            sb.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            sb.Append("<head>");
            sb.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
            sb.Append("<title>无标题文档</title>");
            sb.Append("</head>");
            sb.Append("<body><br/>");
            sb.Append("<table width=\"70%\" cellspacing=\"0\" bordercolor=\"#000066\" border=\"1\" class=\"matches\">");
            sb.Append("<tbody>");
            sb.Append("<tr>");
            sb.Append("<th>號碼</th>");
            sb.Append("<th>時間</th>");
            sb.Append("<th>种类</th>");
            sb.Append("<th>詳情</th>");
            sb.Append("<th>注额</th>");
            sb.Append("<th>可贏額</th>");
            sb.Append("</tr>");
            for (int i = 0; i < date.Length; i++)
            {
                try
                {
                    url = "http://www.sportsinfo8.com/user_sportsinfo8/traditional/index.php?p=user_bets_enquiry_action&fr_matchdate=" + date[i].ToString("dd/MM/yyyy") + "&fr_type=soccer&groupby=0&timezone=America/La_Paz";
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    request.Referer = "http://www.sportsinfo8.com/user_sportsinfo8/traditional/index.php?p=user_bets_enquiry&groupby=0&fr_type=soccer&fr_matchdate=" + date[i].ToString("dd/MM/yyyy") + "";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; InfoPath.3; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                    request.KeepAlive = true;
                    request.Headers["Cookie"] = user.Cookie;
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
                    content = ToUnicode(reader.ReadToEnd());
                    content = content.Replace("\'", "").Replace("\"", "");
                    if (content == "\r\n")
                    {
                        temp = "";
                    }
                    else {
                        if (i == 0)
                        {
                            data = "$be["+ substring(content, "$be[", "$ga[");
                            temp = data;
                            k = 0;
                            while (data.Contains("$be[" + k.ToString() + "]=["))
                            {
                                data = substring2(data, "$be[" + k.ToString() + "]=[", "]");
                                k++;
                            }
                        }
                        else {
                            data = "$be[" + substring(content, "$be[", "$ga[");
                            int l = 0;
                            while (data.Contains("$be[" + l.ToString() + "]=["))
                            {
                                s += "$be["+(l+k)+"]=["+substring(data, "$be[" + l.ToString() + "]=[", "]") + "]";
                                data = substring2(data, "$be[" + l.ToString() + "]=[", "]");
                                l++;
                            }
                            temp += s;
                        }

                    }
                }
                catch (Exception)
                {
                    return sb.ToString();
                }
                finally
                {
                    try
                    {
                        reader.Close();
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    try
                    {
                        if (stream != null)
                            stream.Close();
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    try
                    {
                        response.Close();
                    }
                    catch (Exception)
                    {
                        ;
                    }
                }
            }
            k = 0;
            while (temp.Contains("$be[" + k.ToString() + "]=["))
            {
                s = substring(temp, "$be[" + k.ToString() + "]=[", "]");
                temp = substring2(temp, "$be[" + k.ToString() + "]=[", "]");
                arr = s.Split(',');
                sb.Append("<td style=\"text-align: center;\">").Append(arr[0]).Append("</td>");
                sb.Append("<td style=\"text-align: center;\">").Append(arr[1]).Append("<br>").Append(arr[2]).Append("</td>");
                sb.Append("<td nowrap=\"\" style=\"text-align: center;\">").Append(arr[3]).Append("<br>").Append(arr[4]).Append("</td>");
                sb.Append("<td style=\"text-align: right;\">").Append(arr[5]).Append("</td>");
                sb.Append("<td style=\"text-align: right;\">").Append(arr[6]).Append("</td>");
                sb.Append("<td style=\"text-align: right;\">").Append(arr[7]).Append("</td>    </tr>");
                try
                {
                    sum = sum + double.Parse(arr[6]);
                }
                catch (Exception)
                {  }
                try
                {
                    sum1 = sum1 + double.Parse(arr[7]);
                }
                catch (Exception)
                {

                }
                k++;
            }
            sb.Append("<tr style=\"background-color: rgb(233, 233, 233);\">");
            sb.Append("<td class=\"tdR\" colspan=\"4\">&nbsp;</td>");
            sb.Append("<td bgcolor=\"lightyellow\" style=\"text-align: right;\"><b style=\"font-size: 14px; color: brown;\">" + sum.ToString("F1") + "</b></td>");
            sb.Append("<td bgcolor=\"lightyellow\" style=\"text-align: right;\"><b style=\"font-size: 14px; color: brown;\">" + sum1.ToString("F1") + "</b></td>");
            sb.Append("</tr>");
            sb.Append("</tbody>");
            sb.Append("</table>");
            sb.Append("</body>");
            sb.Append("</html>");
            return sb.ToString();
        }

        public static string huangchaoReadHistory(Betaccount user, DateTime[] date)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string url = string.Empty;
            string content = string.Empty;
            string temp= string.Empty;
            string tab = string.Empty;
            string tr = string.Empty;
            string td = string.Empty;
            string div = string.Empty;
            decimal count = 0, commission = 0;
            decimal count1 = 0, commission1 = 0;
            int j = 0;
            StringBuilder sb = new StringBuilder();
            sb.Append("\r\n<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            sb.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            sb.Append("<head>");
            sb.Append("<title>无标题文档</title>");
            sb.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
            sb.Append("<link href=\"/css/Default/website/huangchao/print.css\" rel=\"stylesheet\" type=\"text/css\"/>");
            sb.Append("<link href=\"/css/Default/website/huangchao/style.css\" rel=\"stylesheet\" type=\"text/css\"/>");
            sb.Append("</head>");
            sb.Append("<body class=\"contentFrame\">");    
            sb.Remove(0, sb.Length);
            for (int i = 0; i < date.Length; i++)
            {
                try
                {
                    url = "https://www.ed3688.com/sb2/me/list_bet.jsp?searchBetDateFrom=" + date[i].ToString("yyyy-MM-dd") + "&searchBetDateTo=" + date[i].ToString("yyyy-MM-dd");
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    request.Referer = "https://www.ed3688.com/sb2/me/info.jsp?localeString=zh_cn";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; InfoPath.3; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                    request.KeepAlive = true;
                    request.Timeout = 6000;
                    request.Headers["Cookie"] = user.Cookie;
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
                    if (content.Contains("Exception Error"))
                    {
                        content = i == 0 ? "<center>帐号已被登出或还没有登录！</center>" : "";
                    }
                    else {
                        if (i == 0)
                        {
                            tab = substring2(content, "<form", "</form>");
                            tab = substring(tab, "<table", "</table>");
                            temp = "<table" + substring(tab, "", "<tr class=\"listContent\"");
                            tr = substring(tab, "<tr class=\"listContent\"", "</tr>");
                            td = substring2(tr, "</td>", "<td");
                            count = Convert.ToDecimal(substring(td, ">", "<"));
                            td = substring2(td, "</td>", "<td");
                            commission = Convert.ToDecimal(substring(td, ">", "<"));
                            content = temp;
                        }
                        else
                        {
                            tab = substring2(content, "<form", "</form>");
                            tab = substring(tab, "<table", "</table>");
                            tr = substring2(tab, "<tr", "</tr>");
                            if (substring(tr, "<tr", "</tr>").Contains("class=\"listContent\""))
                            {
                                temp = "<tr class=\"listContent\" bgcolor=\"#000000\"><td colspan=\"4\" align=\"right\">&nbsp;</td><td class=\"txtNum\""+
                                    " align=\"right\">"+count+"</td><td class=\"txtNum\" align=\"right\">"+commission+"</td><td>&nbsp;</td></tr>";
                            }
                            else
                            {
                                td = substring(tab, "<tr class=\"listContent\"", "</tr>");
                                td = substring2(tr, "</td>", "<td");
                                count1 = Convert.ToDecimal(substring(td, ">", "<")) + count;
                                td = substring2(td, "</td>", "<td");
                                commission1 = Convert.ToDecimal(substring(td, ">", "<")) + commission;
                                temp = "<tr class=\"listContent\" bgcolor=\"#000000\"><td colspan=\"4\" align=\"right\">&nbsp;</td><td class=\"txtNum\"" +
                                    " align=\"right\">" + count1 + "</td><td class=\"txtNum\" align=\"right\">" + commission1 + "</td><td>&nbsp;</td></tr>";
                            }
                            content = temp;
                        }
                    }
                    sb.Append(content);
                }
                catch (Exception)
                {
                    return sb.ToString();
                }
                finally
                {
                    try
                    {
                        reader.Close();
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    try
                    {
                        if (stream != null)
                            stream.Close();
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    try
                    {
                        response.Close();
                    }
                    catch (Exception)
                    {
                        ;
                    }
                }
            }
            return sb.ToString();
        }



        /// <summary>
        /// 用于下注历史对数
        /// </summary>
        /// <param name="casino"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public void readHistory2(string casino, DateTime[] date)
        {
            try
            {
                string result = string.Empty;
                IList<Betaccount> allAccounts = new List<Betaccount>();
                //根据网站查找出所有的帐号
                allAccounts = GetBetAccount(casino);
                Dictionary<string, Orderotherhistory> orderHistorys = new Dictionary<string, Orderotherhistory>();
                //根据网站查找出所有的帐号的外调注单
                //orderHistorys = GetOrderListByWebsiteID(casino);
                foreach (Betaccount account in allAccounts)
                {
                    readTHistory(account, orderHistorys, date);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void readTHistory(Betaccount account, Dictionary<string, Orderotherhistory> orderHistorys, DateTime[] date)
        {
            BetAccountOrderHistory betAccountOrderHistory = new BetAccountOrderHistory(account, date, orderHistorys);
            switch (account.Casino)
            {
                case 1:
                    ThreadPool.QueueUserWorkItem(new WaitCallback(huanguanReadHistory2), betAccountOrderHistory);
                    break;
                case 2:
                    ThreadPool.QueueUserWorkItem(new WaitCallback(lijiReadHistory2), betAccountOrderHistory);
                    break;
                case 3:
                    ThreadPool.QueueUserWorkItem(new WaitCallback(shabaReadHistory2), betAccountOrderHistory);
                    break;
                case 4:
                    ThreadPool.QueueUserWorkItem(new WaitCallback(xinqiuReadHistory2), betAccountOrderHistory);
                    break;
                case 5:
                    ThreadPool.QueueUserWorkItem(new WaitCallback(yongliReadHistory2), betAccountOrderHistory);
                    break;
                case 6:
                    break;
                case 7:
                    ThreadPool.QueueUserWorkItem(new WaitCallback(as3388ReadHistory2), betAccountOrderHistory);
                    break;
                case 8:
                    ThreadPool.QueueUserWorkItem(new WaitCallback(huangchaoReadHistory2), betAccountOrderHistory);
                    break;
            }
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
                allOrderHistorys.Add(item.OrderID, item);
            }
            return allOrderHistorys;
        }

        private delegate void UpdateErrorBetList(Orderotherhistory orderOtherHistory);

        public static Dictionary<string, Orderotherhistory> ErrorOrders;

        public void AddErrorDictionary(Orderotherhistory orderOtherHistory)
        {
            lock (ErrorOrders)
            {
                ErrorOrders.Add(orderOtherHistory.OrderID, orderOtherHistory);
            }
        }

        public static void huanguanReadHistory2(Object o)
        {
            BetAccountOrderHistory betAccountOrderHistory = (BetAccountOrderHistory)o;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string content = "";
            string url = "";
            string referer = "";
            url = "http://" + betAccountOrderHistory.account.Address + "/app/member/history/history_data.php?uid=" + betAccountOrderHistory.account.Cookie + "&langx=zh-cn";
            //url = "http://" + user.Address + "/app/member/today/today_wagers.php?uid=" + user.Cookie + "&langx=zh-tw";
            referer = "http://" + betAccountOrderHistory.account.Address + "/app/member/FT_header.php?uid=" + betAccountOrderHistory.account.Cookie + "&showtype=&langx=zh-tw&mtype=3";
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/QVOD, */*";
                request.Referer = referer;
                request.Headers["Accept-Language"] = "zh-cn";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; InfoPath.2; CIBA)";
                request.KeepAlive = false;
                request.Timeout = 5000;
                request.Headers["Cache-Control"] = "no-cache";
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
                if (content.Contains("<script>window.open('http://www.hg0088.com/tpl/logout_warn.html','_top')</script>"))
                {
                    content = "<center>帐号已被登出或还没有登录！</center>";
                }
                else
                {
                    content = content.Replace("/style/member/mem_body.css", "/css/Default/website/huangguan/mem_body.css");
                    content = content.Replace("<p", "<!--<p");
                    content = content.Replace("</p>", "</p>-->");
                    content = content.Replace("<input", "<!--<input");
                    content = content.Replace(";\">", "\">-->");
                    content = content.Replace("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" id=\"box\">", "<table width=\"530px\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" id=\"box\">");
                }
            }
            catch (Exception e)
            {
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
                    if (stream != null)
                        stream.Close();
                }
                catch (Exception)
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

        public static void lijiReadHistory2(Object o)
        {
            BetAccountOrderHistory betAccountOrderHistory = (BetAccountOrderHistory)o;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string url = "";
            string content = "";
            url = "http://" + betAccountOrderHistory.account.Address2 + "/webroot/restricted/Betlist/Statement.aspx";
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/QVOD, */*";
                request.Headers["Accept-Language"] = "zh-cn";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                request.KeepAlive = true;
                request.Timeout = 6000;
                request.Headers["Cache-Control"] = "no-cache";
                request.Headers["Cookie"] = betAccountOrderHistory.account.Cookie;
                //request.GetRequestStream().Write(bytes, 0, bytes.Length);
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
                if (content.Contains("logout.aspx"))
                {
                    content = "<center>帐号已被登出或还没有登录！</center>";
                }
                else
                {
                    content = content.Replace("http://img-1-2.sbostatic.com/css/global.css?110202", "/css/Default/website/sbobet/global.css");
                    content = content.Replace("http://img-1-2.sbostatic.com/css/maincontent.css?110202", "/css/Default/website/sbobet/maincontent.css");
                    string s1 = "", s2 = "<script src=\"http://txt-1-2.sbostatic.com/js/common.js?110201\" type=\"text/JavaScript\"></script>";
                    int p1 = 0, p2 = 0;
                    p1 = content.IndexOf(s2);
                    s1 = content.Substring(0, p1);
                    s2 = content.Substring(p1 + s2.Length);
                    p2 = s2.IndexOf("</script>");
                    s2 = s2.Substring(p2 + 9);
                    content = s1 + "" + s2;
                }

            }
            catch (Exception e)
            {
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch (Exception e)
                {
                    ;
                }
                try
                {
                    if (stream != null)
                        stream.Close();
                }
                catch (Exception)
                {
                    ;
                }
                try
                {
                    response.Close();
                }
                catch (Exception)
                {
                    ;
                }
            }
        }

        public static void shabaReadHistory2(Object o)
        {
            BetAccountOrderHistory betAccountOrderHistory = (BetAccountOrderHistory)o;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string url = "";
            string content = "";
            try
            {
                url = "http://" + betAccountOrderHistory.account.Address2 + "/AllStatement.aspx";
                //url = "http://" + betAccountOrderHistory.account.Address2 + "/BetList.aspx";
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/QVOD, */*";
                request.Referer = "http://" + betAccountOrderHistory.account.Address2 + "/LeftAllInOne.aspx";
                request.Headers["Accept-Language"] = "zh-cn";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                request.KeepAlive = true;
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
                if (content.Contains("<BODY><P></BODY>") || content.Contains("top.window.location.href=") || content.Contains("Failed to verify login status"))
                {
                    content = "<center>帐号已被登出或者尚未登录</center>";
                }
                else
                {
                    content = "\r\n" + content;
                    content = content.Replace("template/ibcbet/public/css/table_w.css", "/css/Default/website/ibc/table_w.css");
                    content = content.Replace("template/ibcbet/public/css/button.css", "/css/Default/website/ibc/button.css");
                    content = content.Replace("<link href=\"template/ibcbet/public/css/oddsFamily.css\" rel=\"stylesheet\" type=\"text/css\" />", "");
                    content = content.Replace("<!-- <link href=\"css/table_w.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n\t<link href=\"css/button.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n\t<link href=\"css/oddsFamily.css\" rel=\"stylesheet\" type=\"text/css\" /> -->", "");
                    content = content.Replace("template/ibcbet/public/images/layout/title_soccer1.gif", "/images/website/ibc/title_soccer1.gif");
                    content = content.Replace("Betlist.aspx", "#");
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch (Exception e)
                {
                    ;
                }
                try
                {
                    if (stream != null)
                        stream.Close();
                }
                catch (Exception)
                {
                    ;
                }
                try
                {
                    response.Close();
                }
                catch (Exception e)
                {
                    ;
                }

            }

        }

        public static void xinqiuReadHistory2(Object o)
        {
            BetAccountOrderHistory betAccountOrderHistory = (BetAccountOrderHistory)o;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string content = "";
            string url = "";
            string referer = "";
            byte[] bytes;
            string postdata = "", begintime = "2010-03-28", endtime = "2010-03-31";
            string __VIEWSTATE = "";
            string __EVENTVALIDATION = "";
            url = "http://" + betAccountOrderHistory.account.Address2 + "/zh-tw/my-account/statement/betting-history/sports/settled-bets";
            referer = "http://" + betAccountOrderHistory.account.Address2 + "/zh-tw/my-account/statement/betting-history/sports/settled-bets";
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
                if (content.Contains("name=\"__EVENTVALIDATION\" id=\"__EVENTVALIDATION\" value="))
                {
                    __VIEWSTATE = substring(content, "id=\"__VIEWSTATE\" value=\"/", "\" />");
                    __EVENTVALIDATION = substring(content, "id=\"__EVENTVALIDATION\" value=\"/", "\" />").Replace("/", "%2F").Replace("+", "%2B");
                }
            }
            catch
            {
                ;
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
            TimeSpan t3 = Convert.ToDateTime(endtime).Subtract(Convert.ToDateTime(begintime));
            int y = t3.Days;
            if (y > 3)
            {
                y = 3;
            }
            int x = 0;
            while (x < y)
            {
                switch (x)
                {
                    case 0:
                        postdata = "__EVENTTARGET=ctl00%24Content%24LinkBtnSubmit&__EVENTARGUMENT=&__VIEWSTATE=%2F" + __VIEWSTATE + "&__EVENTVALIDATION=%2F" + __EVENTVALIDATION + "&ctl00%24Content%24inputFromDatePicker=" + DateTime.Now.ToString("dd-MM-yyyy").Replace("-", "%2F") + "&ctl00%24Content%24inputToDatePicker=" + DateTime.Now.ToString("dd-MM-yyyy").Replace("-", "%2F") + "&daysInput=0&ctl00%24Content%24Todaydate0=" + DateTime.Now.ToString("dd-MM-yyyy").Replace("-", "%2F") + "&ctl00%24Content%24TopKey=statement";
                        break;
                    case 1:
                        postdata = "__EVENTTARGET=ctl00%24Content%24LinkBtnSubmit&__EVENTARGUMENT=&__VIEWSTATE=%2F" + __VIEWSTATE + "&__EVENTVALIDATION=%2F" + __EVENTVALIDATION + "&ctl00%24Content%24inputFromDatePicker=" + DateTime.Now.ToString("dd-MM-yyyy").Replace("-", "%2F") + "&ctl00%24Content%24inputToDatePicker=" + DateTime.Now.ToString("dd-MM-yyyy").Replace("-", "%2F") + "&daysInput=1&ctl00%24Content%24Todaydate0=" + DateTime.Now.ToString("dd-MM-yyyy").Replace("-", "%2F") + "&ctl00%24Content%24TopKey=statement";
                        break;
                    case 2:
                        //__EVENTTARGET=ctl00%24Content%24LinkBtnSubmit&__EVENTARGUMENT=&__VIEWSTATE=%2FwEPDwULLTE1NTU3MTE3MjdkZPL5WpAtMhcZuaFOJiBsBOIzgSaF&__EVENTVALIDATION=%2FwEWBgK9l4WiCgL7lZmzBQKhn%2FKJCwKA3ZD2BAK90b2TDQKe8Y%2BfC4M5V2AzrC98HmPuhmoS%2FO6yJSQ%2B&ctl00%24Content%24inputFromDatePicker=23%2F03%2F2011&ctl00%24Content%24inputToDatePicker=30%2F03%2F2011&daysInput=8&ctl00%24Content%24Todaydate0=30%2F03%2F2011&ctl00%24Content%24TopKey=statement
                        postdata = "__EVENTTARGET=ctl00%24Content%24LinkBtnSubmit&__EVENTARGUMENT=&__VIEWSTATE=%2F" + __VIEWSTATE + "&__EVENTVALIDATION=%2F" + __EVENTVALIDATION + "&ctl00%24Content%24inputFromDatePicker=" + DateTime.Now.AddDays(-8).ToString("dd-MM-yyyy").Replace("-", "%2F") + "&ctl00%24Content%24inputToDatePicker=" + DateTime.Now.ToString("dd-MM-yyyy").Replace("-", "%2F") + "&daysInput=8&ctl00%24Content%24Todaydate0=" + DateTime.Now.ToString("dd-MM-yyyy").Replace("-", "%2F") + "&ctl00%24Content%24TopKey=statement";
                        break;
                }
                x++;
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
                    if (content.Contains("login.aspx") || content.Contains("lostConn:true"))
                    {
                        return;
                    }
                    if (content.Trim().Length == 0)
                    {
                        return;
                    }
                    if (content.Contains("沒有記錄"))
                    {
                        ;
                    }
                    string type2 = "", state = "", tztime = "", kstime = "";
                    string[] str;
                    if (content.Contains("投注日期"))
                    {

                        content = substring(content, " <td class=\"tac\">", "</tbody>");
                        str = content.Split(new string[] { "<div>2011年" }, StringSplitOptions.None);
                        for (int i = 1; i < str.Length; i++)
                        {
                            try
                            {
                                //str[i] = "<div>2011年" + str[i];
                                //kstime = substring(str[i], "<div>2011年", "</div>");//比赛时间
                                //type2 = substring(str[i], "<td class=\"bet-type\">", "</td>").Trim();
                                //tztime = substring(str[i], "<br/>投注日期：", "\"><span").Trim();
                                //tztime = tztime.Substring(0, tztime.IndexOf(","));
                                ////tzdata.result.orderid2 = substring(str[i], "<div>", "</div>");
                                ////tzdata.odds = substring(str[i], "</span><span class=\"pe o-v", "</span>");
                                ////tzdata.odds = tzdata.odds.Substring(tzdata.odds.IndexOf(">") + 1);
                                ////tzdata.home = substring(str[i], "<span class=\"participant\" title=\"", "\">").Replace(" ", "");
                                ////tzdata.away = substring(str[i], "v</span>", "</span>").Replace(" ", "");
                                ////tzdata.team = substring(str[i], "<span class=\"bettype\" title=\"", "\">").Replace(" ", "");
                                ////tzdata.league = substring(str[i], "<span class=\"tt\" title=\"足球 <br/>", "<br/>");
                                ////tzdata.handicap = substring(str[i], "<span class=\"hd pe\">", "</span>");
                                ////tzdata.xzje = substring(str[i], "<td class=\"tar\">", "<br />").Replace("\r", "").Replace("\n", "").Replace(" ", "");//下注金额
                                ////tzdata.xzje2 = substring(str[i], "<td class=\"tar\">", "tac\"><span");
                                ////tzdata.xzje2 = substring(tzdata.xzje2, "<td class=\"tar\">", "<td class=").Replace("\r", "").Replace("\n", "").Replace(" ", "");
                                ////tzdata.xzje2 = tzdata.xzje2.Substring(0, tzdata.xzje2.IndexOf("<"));//输赢金额
                                ////tzdata.user.userid = user.userid;
                                //state = substring(str[i], "<td class=\"tac\"><span class='", "</span>");
                                //state = state.Substring(state.Length - 1);//输赢状态
                                ////tzdata.yjje = substring(str[i], "<br /><span class=\"tt\" title=\"佣金\">[", "]</span>");
                                ////tzdata.ip=
                                //switch (type2)
                                //{
                                //    case "讓球":
                                //        if (kstime.Contains(tztime))
                                //        {
                                //            tzdata.type = "0";
                                //        }
                                //        else
                                //        {
                                //            tzdata.type = "8";
                                //        }
                                //        break;
                                //    case "大小盤":
                                //        if (kstime.Contains(tztime))
                                //        {
                                //            tzdata.type = "1";
                                //        }
                                //        else
                                //        {
                                //            tzdata.type = "9";
                                //        }
                                //        break;
                                //    case "讓球 - 上半場":
                                //        if (kstime.Contains(tztime))
                                //        {
                                //            tzdata.type = "2";
                                //        }
                                //        else
                                //        {
                                //            tzdata.type = "10";
                                //        }
                                //        break;
                                //    case "大小盤 - 上半場":
                                //        if (kstime.Contains(tztime))
                                //        {
                                //            tzdata.type = "3";
                                //        }
                                //        else
                                //        {
                                //            tzdata.type = "11";
                                //        }
                                //        break;
                                //    case "滾球讓球盤":
                                //        tzdata.type = "4";
                                //        tzdata.score = tzdata.away.Substring(tzdata.away.IndexOf("(") + 1, tzdata.away.IndexOf(")"));//投注时 的比分，新球没有完场比分
                                //        tzdata.away = tzdata.away.Substring(0, tzdata.away.IndexOf("(")).Replace(" ", "");
                                //        break;
                                //    case "滾球大小盤":
                                //        tzdata.type = "5";
                                //        tzdata.score = tzdata.away.Substring(tzdata.away.IndexOf("(") + 1, tzdata.away.IndexOf(")"));
                                //        tzdata.away = tzdata.away.Substring(0, tzdata.away.IndexOf("(")).Replace(" ", "");
                                //        break;
                                //    case "滾球讓球盤 - 上半場":
                                //        tzdata.type = "6";
                                //        tzdata.score = tzdata.away.Substring(tzdata.away.IndexOf("(") + 1, tzdata.away.IndexOf(")"));
                                //        tzdata.away = tzdata.away.Substring(0, tzdata.away.IndexOf("(")).Replace(" ", "");
                                //        break;
                                //    case "滾球大小盤 - 上半場":
                                //        tzdata.type = "7";
                                //        tzdata.score = tzdata.away.Substring(tzdata.away.IndexOf("(") + 1, tzdata.away.IndexOf(")"));
                                //        tzdata.away = tzdata.away.Substring(0, tzdata.away.IndexOf("(")).Replace(" ", "");
                                //        break;

                                //    case "獨贏":
                                //        if (kstime.Contains(tztime))
                                //        {
                                //            tzdata.type = "12";
                                //        }
                                //        else
                                //        {
                                //            tzdata.type = "16";
                                //        }
                                //        break;
                                //    case "獨贏 - 上半場":
                                //        if (kstime.Contains(tztime))
                                //        {
                                //            tzdata.type = "13";
                                //        }
                                //        else
                                //        {
                                //            tzdata.type = "17";
                                //        }
                                //        break;
                                //    case "滾球獨贏盤":
                                //        tzdata.type = "14";
                                //        break;
                                //    case "滾球獨贏盤 - 上半場":
                                //        tzdata.type = "15";
                                //        break;


                                //}
                                //if (tzdata.xzje.Contains("--"))
                                //{
                                //    tzdata.state = 0;//代表和局
                                //}
                            }
                            catch
                            {
                                //if (tzdata.result.orderid2 != null)
                                //{
                                //    tzdata.content = user.userid + "的" + tzdata.result.orderid2 + "注单查询失败";
                                //}
                                //else
                                //{
                                //    tzdata.content = str[i];

                                //}
                            }

                        }
                    }
                    else
                    {
                       // tzdata.content = "没有投注";
                    }
                }
                catch (Exception)
                {
                    //tzdata.content = user.userid + Convert.ToDateTime(endtime).AddDays(-x) + "天注单查询失败";
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
            }
            return;
        }

        public static void yongliReadHistory2(Object o)
        {
            BetAccountOrderHistory betAccountOrderHistory = (BetAccountOrderHistory)o;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string url = "";
            string content = "";
            Encoding big5 = Encoding.GetEncoding("big5");
            url = "http://" + betAccountOrderHistory.account.Address + "/right/history/";
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/QVOD, */*";
                //request.Referer = referer;
                request.Headers["Accept-Language"] = "zh-cn";

                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.Headers["Cookie"] = betAccountOrderHistory.account.Cookie;

                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Mozilla/4.0(Compatible Mozilla/4.0(Compatible-EmbeddedWB 14.59 http://bsalsa.com/ EmbeddedWB- 14.59  from: http://bsalsa.com/ ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                request.KeepAlive = true;
                //request.Timeout = 5000;
                request.Headers["Cache-Control"] = "no-cache";
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
                content = content.Replace("setTimeout('document.formmatch.submit()',180*1000);", "");
                if (content.Contains("系统繁忙, 请重新登入") || content.Contains("self.parent.location='/logout.php';"))
                {
                    content = "<center>帐号已被登出或者尚未登录</center>";
                }
                else
                {
                    content = content.Replace("/include/style.css", "/css/Default/website/a1a888/style.css");
                    content = content.Replace("../../images/notice-img/1.gif", "/images/website/a1a888/1.gif");
                    content = content.Replace("../../images/notice-img/bj.gif", "/images/website/a1a888/bj.gif");
                    content = content.Replace("../../right/news/index.php?marquee=true\"  target=\"right_wgo_1252978", "#");
                    content = content.Replace("clock.innerHTML", "document.getElementById(\"clock\").innerHTML");
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch (Exception)
                {
                    ;
                }
                try
                {
                    if (stream != null)
                        stream.Close();
                }
                catch (Exception)
                {
                    ;
                }
                try
                {
                    response.Close();
                }
                catch (Exception)
                {
                    ;
                }
            }
        }

        public static void as3388ReadHistory2(Object o)
        {
            BetAccountOrderHistory betAccountOrderHistory = (BetAccountOrderHistory)o;
            //一次性从数据库取出所有注单，通过单个帐号获取对应的注单
            betAccountOrderHistory.OrderOtherHistorys = GetDicByAccount(betAccountOrderHistory.account.Userid, betAccountOrderHistory.OrderOtherHistorys);
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string url = string.Empty;
            string content = string.Empty;
            string referer = string.Empty;
            string tr = string.Empty;
            string td = string.Empty;
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            url = "http://" + betAccountOrderHistory.account.Address + "/user_smartbets8/traditional/index.php?p=history";
            referer = "http://" + betAccountOrderHistory.account.Address + "/user_sportsinfo8/traditional/index.php?p=system";
            for (int i = 0; i < betAccountOrderHistory.date.Length; i++)
            {
                try
                {
                    url = "http://" + betAccountOrderHistory.account.Address + "/user_sportsinfo8/traditional/index.php?p=user_bets_enquiry_action&fr_matchdate=" + betAccountOrderHistory.date[i].ToString("dd/MM/yyyy") + "&fr_type=soccer&groupby=0&timezone=America/La_Paz";
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = "GET";
                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    request.Referer = "http://www.sportsinfo8.com/user_sportsinfo8/traditional/index.php?p=user_bets_enquiry&groupby=0&fr_type=soccer&fr_matchdate=28/03/2011" + betAccountOrderHistory.date[i].ToString("dd/MM/yyyy") + "";
                    request.Headers["Accept-Language"] = "zh-cn";
                    request.Headers["Accept-Encoding"] = "gzip, deflate";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; InfoPath.3; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                    request.KeepAlive = true;
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
                    content = reader.ReadToEnd();
                    content = ToUnicode(content);
                    content = substring(content, "$w_st=[];", "$ga[0]");
                    while (content.Contains("$be"))
                    {
                        tr = substring(content, "=[", "];");
                        string[] arrStr = tr.Split(new string[] { "','" }, StringSplitOptions.None);
                        Orderotherhistory order1 = new Orderotherhistory();
                        order1.Time = Convert.ToDateTime(arrStr[1] + " " + arrStr[2].Replace("AM", "").Replace("PM", "").Replace(" ", "").Trim());
                        string betType = arrStr[3];
                        switch (betType)
                        {
                            case "讓球":
                                //betType = ((Convert.ToDateTime(betTime)).ToString("yyyy-MM-dd") == (Convert.ToDateTime(beginGameTime)).ToString("yyyy-MM-dd")) ? "0" : "8";
                                break;
                            case "大/小":
                                //betType = ((Convert.ToDateTime(betTime)).ToString("yyyy-MM-dd") == (Convert.ToDateTime(beginGameTime)).ToString("yyyy-MM-dd")) ? "1" : "9";
                                break;
                            case "標準":
                                order1.BetType = "12";
                                break;
                            case "大小-上半場":
                                //betType = ((Convert.ToDateTime(betTime)).ToString("yyyy-MM-dd") == (Convert.ToDateTime(beginGameTime)).ToString("yyyy-MM-dd")) ? "3" : "11";
                                break;
                            case "讓球-上半場":
                                //betType = ((Convert.ToDateTime(betTime)).ToString("yyyy-MM-dd") == (Convert.ToDateTime(beginGameTime)).ToString("yyyy-MM-dd")) ? "2" : "10";
                                break;
                            case "標準-上半場":
                                order1.BetType = "13";
                                break;
                            case "走地－大小":
                                order1.BetType = "5";
                                break;
                            case "走地－讓球":
                                order1.BetType = "4";
                                break;
                            case "走地－標準":
                                order1.BetType = "14";
                                break;
                            case "走地讓球-上半場":
                                order1.BetType = "6";
                                break;
                            case "走地大小-上半場":
                                order1.BetType = "7";
                                break;
                            case "走地標準-上半場":
                                order1.BetType = "15";
                                break;
                        }
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
                            string handicap = substring(td, ">", "</span");
                        }
                        order1.Awaytw = substring(td, "</span>", "<br>");
                        string tempBetTeam = substring(td, "<span class=\"teambet\">", "</span>");
                        if (tempBetTeam.Contains("<b>"))
                        {
                            order1.BetItem = substring(tempBetTeam, "", "<b>");
                            string handicap = substring(tempBetTeam, "<b>", "</b>");
                        }
                        else
                        {
                            order1.BetItem = tempBetTeam;
                        }
                        order1.Odds = Convert.ToDecimal(substring(td, "<span class=\"odds\">", "</span>"));
                        order1.Amount = Convert.ToDecimal(arrStr[6]);
                        order1.Result = Convert.ToDecimal(arrStr[7]);
                        order1.ValidAmount = Convert.ToDecimal(arrStr[8]);
                        string result = strTemp[1];
                        string betResult = string.Empty;
                        if (result.Length > 4)
                        {
                            betResult = result.Substring(0, 1);
                            result = result.Substring(1, result.Length - 1) + "|";
                        }
                        order1.Score = substring(result, "*", "|").Replace("*",":");
                        Orderotherhistory order2 = betAccountOrderHistory.OrderOtherHistorys[order1.OrderID];
                        if (order2 != null)
                        {
                            if (order1.Score != order2.Score && order2.Handicap != order1.Handicap && order2.BetItem != order1.BetItem && order2.Amount != order1.Amount && order2.Result != order1.Result && order2.ValidAmount != order2.ValidAmount && order2.Odds != order1.Odds)
                            {
                                AccountService account = new AccountService();
                                account.AddErrorDictionary(order2);
                            }
                        }
                        content = substring2(content, "=[", "];");
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    try
                    {
                        reader.Close();
                    }
                    catch (Exception)
                    {
                        ;
                    }
                    try
                    {
                        response.Close();
                    }
                    catch (Exception)
                    {
                        ;
                    }
                }
            }
        }

        public static void huangchaoReadHistory2(Object o)
        {
            BetAccountOrderHistory betAccountOrderHistory = (BetAccountOrderHistory)o;
            //一次性从数据库取出所有注单，通过单个帐号获取对应的注单
            betAccountOrderHistory.OrderOtherHistorys = GetDicByAccount(betAccountOrderHistory.account.Userid, betAccountOrderHistory.OrderOtherHistorys);
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            GZipStream stream = null;
            StreamReader reader = null;
            Encoding utf8 = Encoding.UTF8;
            string url = string.Empty;
            string content = string.Empty;
            string tr = string.Empty;
            string td = string.Empty;
            string nextUrl = string.Empty;
            bool isSettlement = false;
            url = "https://" + betAccountOrderHistory.account.Address + "/sb2/me/list_bet_summary.jsp";
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                request.Referer = "https://www.ed3688.com/sb2/me/info.jsp?localeString=zh_cn";
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
                if (content.Contains("Exception Error"))
                {
                    content = "<center>帐号已被登出或者尚未登录</center>";
                }
                else
                {
                    content = substring(content, "<table", "</table>");
                    content = substring2(content, "<tr", "</tr>");
                    string[] str = content.Split(new string[] { "align=\"right\">" }, StringSplitOptions.None);
                    for (int i = 1; i < str.Length - 1; i++)
                    {
                        for (int j = 0; j < betAccountOrderHistory.date.Length; i++)
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
                                    break;
                                try
                                {
                                    url = "https://" + betAccountOrderHistory.account.Address + "/sb2/me/" + nextUrl;
                                    request = (HttpWebRequest)WebRequest.Create(url);
                                    request.Method = "GET";
                                    request.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                                    request.Referer = "https://" + betAccountOrderHistory.account.Address + "/sb2/me/info.jsp?localeString=zh_cn";
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
                                        Orderotherhistory order1 = new Orderotherhistory();
                                        td = substring(tr, "<td", "/td>");
                                        order1.WebSiteiID = Convert.ToInt32(substring(td, ">", "<br").Replace("AH", "").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "").Trim());
                                        string pankou = substring(td, "<br />", "<").Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                        tr = substring2(tr, "<td", "</td>");
                                        order1.Time = Convert.ToDateTime(substring(tr, ">", "</td>").Replace("\r", "").Replace("\n", "").Replace("\t", "").Replace(" ", "").Trim());
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
                                        order1.Odds = Convert.ToDecimal(substring(td, "<span class=\"betDetails_price\">", "</span>").Replace("\r", "").Replace("\n", "").Replace("\t", ""));
                                        tr = substring2(tr, "<td", "</td>");
                                        order1.Amount = Convert.ToDecimal(substring(tr, ">", "</td>").Replace("\r", "").Replace("\n", "").Replace("\t", ""));
                                        tr = substring2(tr, "<td", "</td>");
                                        order1.Result = Convert.ToDecimal(substring(tr, ">", "</td>").Replace("\r", "").Replace("\n", "").Replace("\t", ""));
                                        tr = substring2(tr, "<td", "</td>");
                                        td = substring(tr, "<td", "</td>");
                                        order1.Scorehalf = substring(td, ":", "</span>").Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                        td = substring2(td, "<span", "<br/>");
                                        order1.Score = substring(td, ":", "</span>").Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                        td = substring2(td, ">", "</span><span");
                                        string result = substring(td, ">", "</span>").Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                        Orderotherhistory order2 = betAccountOrderHistory.OrderOtherHistorys[order1.OrderID];
                                        //开始比较
                                        if (order2 != null)
                                        {
                                            if (order1.Score != order2.Score && order2.Handicap != order1.Handicap && order2.BetItem != order1.BetItem && order2.Amount != order1.Amount && order2.Result != order1.Result && order2.ValidAmount != order2.ValidAmount && order2.Odds != order1.Odds)
                                            {
                                                AccountService account = new AccountService();
                                                account.AddErrorDictionary(order2);
                                            }
                                        }
                                        content = substring2(content, "<tr", "</tr>");
                                    }
                                }
                                catch (Exception)
                                {
                                    return;
                                }
                                finally
                                {
                                    try
                                    {
                                        reader.Close();
                                    }
                                    catch (Exception)
                                    {
                                        ;
                                    }
                                    try
                                    {
                                        if (stream != null)
                                            stream.Close();
                                    }
                                    catch (Exception)
                                    {
                                        ;
                                    }
                                    try
                                    {
                                        response.Close();
                                    }
                                    catch (Exception)
                                    {
                                        ;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch (Exception)
                {
                    ;
                }
                try
                {
                    if (stream != null)
                        stream.Close();
                }
                catch (Exception)
                {
                    ;
                }
                try
                {
                    response.Close();
                }
                catch (Exception)
                {
                    ;
                }
            }
        }
        #endregion
    }

    public class BetAccountOrderHistory
    {
        public Betaccount account { get; set; }
        public DateTime[] date { get; set; }
        public Dictionary<string, Orderotherhistory> OrderOtherHistorys { get; set; }

        public BetAccountOrderHistory(Betaccount account, DateTime[] date, Dictionary<string, Orderotherhistory> OrderOtherHistorys)
        {
            this.account = account;
            this.date = date;
            this.OrderOtherHistorys = OrderOtherHistorys;
        }
    }
}
