using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using Model;
using System.Net;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Xml;
using MySql.Data.MySqlClient;

namespace BLL
{
    public class BankManager
    {
        public static BankService bankservice = new BankService();

        public static string BillSummaryOfMonth(string userid, string type, string currency, string date1,string date2)
        {
            return bankservice.BillSummaryOfMonth(userid, type, currency, date1, date2);

        }
        public static bool InsertBillNoticeHistory(BillNoticeHistory billNoticeHistory)
        {
            return bankservice.InsertBillNoticeHistory(billNoticeHistory);
        }

        public static bool InsertBillDetail(BillDetail billDetail)
        {
            return bankservice.InsertBillDetail(billDetail);
        }

        public static bool DeleteBillNoticeByID(string billNoticeId)
        {
            return bankservice.DeleteBillNoticeByID(billNoticeId);
        }

        public static bool DeleteBillNoticeByIDEA(string username)
        {
            return bankservice.DeleteBillNoticeByIDEA(username);
        }
        public static bool DeleteBillNoticeByIDEZUN(string username)
        {
            return bankservice.DeleteBillNoticeByIDEZUN(username);
        }
        public static string GetBillNoticeByUser(string userName)
        {
            return bankservice.GetBillNoticeByUser(userName);
        }

        public static string GetBillWithDrawalNotice()
        {
            return bankservice.GetBillWithDrawalNotice();
        }

        public static string GetBillDepositNotice()
        {
            return bankservice.GetBillDepositNotice();
        }

        public static List<BillNotice> GetBillNotice()
        {
            return bankservice.GetBillNoticeList();
        }

        public static BillNotice GetBillNotice(string id)
        {
            return bankservice.GetBillNotice(id);
        }
        public static BillNotice GetBillNotices(string UserName)
        {
            return bankservice.GetBillNotices(UserName);
        }
        public static BillNotice GetBillNoticesEZUN(string UserName)
        {
            return bankservice.GetBillNoticesEZUN(UserName);
        }
        public static BillNotice IsTrueNoticeHistory(string UserName)
        {
            return bankservice.IsTrueNoticeHistory(UserName);
        }

        public static BillNotice IsTrueNoticeHistoryEZUN(string UserName)
        {
            return bankservice.IsTrueNoticeHistoryEZUN(UserName);
        }
        public static BillNoticeHistory GetBillNoticeHistory(string id)
        {
            return bankservice.GetBillNoticeHistory(id);
        }

        public static string GetDepositHistory()
        {
            return bankservice.GetDepositHistory();
        }

        public static string GetWithDrawalHistory()
        {
            return bankservice.GetWithDrawalHistory();
        }

        public static string GetWithDrawalHistoryByWhere(string userName,string name, string status, string time1, string time2)
        {
            return bankservice.GetWithDrawalHistoryByWhere(userName, name,status, time1, time2);
        }

        public static string GetWinHistoryByWhere(string userName, string name, string status, string time1, string time2)
        {
            return bankservice.GetWinHistoryByWhere(userName, name, status, time1, time2);
        }
        public static string GetDepositHistoryByWhere(string userName,string lan,string name, string status, string time1, string time2)
        {
            return bankservice.GetDepositHistoryByWhere(userName,lan,name, status, time1, time2);
        }

        public static string GetDepositByWhere(string userName,string lan,string name,string time1, string time2)
        {
            return bankservice.GetDepositByWhere(userName,lan, name,time1, time2);
        }

        public static string GetWithDrawalByWhere(string userName,string name, string time1, string time2)
        {
            return bankservice.GetWithDrawalByWhere(userName, name,time1, time2);
        }

        public static string GetBillList(string userName)
        {
            return bankservice.GetBillList(userName);
        }

        public static string GetBillDetailAll()
        {
            return bankservice.GetBillDetailAll();
        }

        public static string GetBillDetailByWhere(string userName,string name,string type,string time1,string time2)
        {
            return bankservice.GetBillDetailByWhere(userName,name, type, time1, time2);
        }

        public static bool UpdateBalance(string money, string userName, string type)
        {
            return bankservice.UpdateBalance(money, userName,type);
        }

        public static decimal GetUserBalance(string userName)
        {
            return bankservice.GetUserBalance(userName);
        }

        public static string GetBankInfoAll(string lan)
        {
            return bankservice.GetBankInfoAll(lan);
        }

        public static bool InsertBankInfo(string bankName)
        {
            return bankservice.InsertBankInfo(bankName);
        }

        public static bool UpdateBankInfo(string bankName,string id)
        {
            return bankservice.UpdateBankInfo(bankName,id);
        }

        public static bool DeleteBankInfo(string id)
        {
            return bankservice.DeleteBankInfo(id);
        }

        public static string GetUserInfo(string userName)
        {
            return bankservice.GetUserInfo(userName);
        }

        public static RefusedList GetReasonByID(string id)
        {
            return bankservice.GetReasonByID(id);
        }

        public static bool InsertOperateLog(BillNoticeHistory billNotice,string operer)
        {
            return bankservice.InsertOperateLog(billNotice,operer);
        }
        public static bool InsertOperateLog2(BillNoticeHistory billNotice, string operer)
        {
            return bankservice.InsertOperateLog2(billNotice, operer);
        }



        public static string GetReason()
        {
            return bankservice.GetReason();
        }

        public static string GetCurrInfo(string code)
        {
            return bankservice.GetCurrInfo(code);
        }

        public static string GetWDHistory(string userName)
        {
            return bankservice.GetWDHistory( userName);
        }

        public static string GetDHistory(string userName)
        {
            return bankservice.GetDHistory(userName);
        }

        public static string GetOrderAll(string userName)
        {
            return bankservice.GetOrderAll(userName);
        }

        public static string GetOrderHistory(string userName)
        {
            return bankservice.GetOrderHistory(userName);
        }

        public static bool CancelBNH(BillNoticeHistory bnh)
        {
            return bankservice.CancelBNH(bnh);
        }



        public static string GetBillNoticeHistory(string username, string type, string time1, string time2, string lan)
        {
            return bankservice.GetBillNoticeHistory(username, type, time1, time2, lan);
        }

        public static string GetBillNoticeHistory_ok(string username, string type, string time1, string time2, string lan)
        {
            return bankservice.GetBillNoticeHistory_ok(username, type, time1, time2, lan);
        }
        public static string GetBillNoticeHistory_okPE(string username,  string time1, string time2, string lan)
        {
            return bankservice.GetBillNoticeHistory_okPE(username, time1, time2, lan);
        }


        public static string GetBillNoticePt(string username,string type, string time1, string time2, string lan)
        {
            return bankservice.GetBillNoticePt(username,type, time1, time2, lan);


        }

        public static string GetBillNoticeHistory_user(string username, string type, string time1, string time2, string agent)
        {
            return bankservice.GetBillNoticeHistory_user(username, type, time1, time2, agent);
        }
        public static string GetBillNoticeHistory_QK(string username, string type, string time1, string time2, string lan)
        {
            return bankservice.GetBillNoticeHistory_QK(username, type, time1, time2, lan);
        }
        public static string SumGetBillNoticeHistory(string username)
        {
            return bankservice.SumGetBillNoticeHistory(username);
        }

        /// <summary>
        /// 调用接口
        /// </summary>
        /// <param name="gateway">接口地址</param>
        /// <param name="data">发送数据</param>
        /// <returns></returns>
        public static string PostData(string gateway, string data, Encoding code)
        {
            try
            {
                HttpWebRequest req;
                byte[] dataByte = code.GetBytes(data);
                Uri url = new Uri(gateway);
                if (gateway.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                    req = (HttpWebRequest)WebRequest.Create(url);
                    req.ProtocolVersion = HttpVersion.Version10;
                }
                else
                {
                    req = (HttpWebRequest)WebRequest.Create(url);
                }
                req.Method = "POST";
                req.Headers.Add(HttpRequestHeader.ContentEncoding, code.HeaderName);
                req.ContentType = "text/xml";
                //SSL/TLS
                req.ContentLength = dataByte.Length;
                Stream wtr = (req.GetRequestStream());
                wtr.Write(dataByte, 0, dataByte.Length);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader rdr = new StreamReader(res.GetResponseStream(), code);
                string ouputStr = rdr.ReadToEnd();
                wtr.Close();
                rdr.Close();
                res.Close();
                return ouputStr;
            }
            catch (Exception ee)
            {
                //调用接口失败
                return "-1";
            }
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受   
        }

        /// <summary>
        /// 返回客户在EA的信息（包括余额）
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static string GetEAamount(string userid)
        {
            string amount = "";
            string postXml = "";
            string xml = "";
            string sid = "3";
            //EA测试账号
            if (userid == "gstest01" || userid == "gstest02" || userid == "gstest03" || userid == "gstest04" || userid == "gstest05")
            {
                sid = "2";
            }
            //测试
            //string url = "https://testmis.ea3-mission.com/configs/external/checkclient/gs/server.php";
            //正式
            string url = "https://mis.ea3-mission.com/configs/external/checkclient/gs/server.php";
            string id = Util.StringHelper.getOrder("检查客户");
            #region 发送xml
            postXml += "<?xml version=\"1.0\"?>";
            postXml += "<request action=\"ccheckclient\">";
            postXml += "<element id=\"" + id + "\">";
            postXml += "<properties name=\"userid\">" + userid + "</properties>";
            postXml += "<properties name=\"vendorid\">" + sid + "</properties>";
            postXml += "<properties name=\"currencyid\">156</properties>";
            postXml += "</element>";
            postXml += "</request>";
            xml = PostData(url, postXml, Encoding.UTF8);
            xml = xml.Trim();
            #endregion
            #region 处理返回的xml
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                XmlNodeList xnList = doc.SelectNodes("/request/element/properties");
                amount = xnList[1].InnerText;
            }
            catch
            {
                amount = "";
            }
            #endregion
            return amount;
        }

        public static string GetBankNameInfo()
        {
            return bankservice.GetBankNameInfo();
        }
        public static string GetBankNameInfo_1()
        {
            return bankservice.GetBankNameInfo_1();
        }
        public static string GetBankInfos(int id)
        {
            return bankservice.GetBankInfos(id);
        }



        public static string GetICBCData(string userName, string PaynumerID, string time1, string time2)
        {
            return bankservice.GetICBCData(userName, PaynumerID, time1, time2);
        }

        /// <summary>
        /// 自动添加返水
        /// </summary>
        /// <param name="time1">投注起始时间</param>
        /// <param name="time2">投注结束时间</param>
        /// <param name="fsbl">返水比率</param>
        /// <param name="mark">备注</param>
        /// <returns></returns>
        public static string AutoFanshui(string time1, string time2, decimal fsbl, string mark, string gametype)
        {
            decimal down = 10;      //返水下限
            string username = "";
            decimal amount = 0;     //返水金额
            decimal validamount = 0;
            string type = gametype;
            MySqlDataReader reader = null;
            //查找时间段内有投注的会员
            try
            {
                if (gametype == "4")
                {
                    //ea返水
                    reader = BankService.GetFanshuis1(time1, time2);
                }
                else
                {
                    //pt
                    reader = BankService.GetFanshuisPT(time1, time2);
                }
                while (reader.Read())
                {
                    //遍历每个会员，把返水金额大于10元的插入返水审核表
                    username = reader.GetString("login");
                    validamount = reader.GetDecimal("betamount");
                    amount = validamount * fsbl / 100;
                    amount = Math.Round(amount, 2);
                    if (amount >= down)
                    {
                        //派发返水
                        //判断用户是否存在
                        if (UserService.IsExistUsername(username))
                        {
                            //用户存在则派发
                            BankService.AddFanShui(username, type, amount, "1", mark, fsbl.ToString(), time1, time2, validamount);
                        }
                    }
                }
                return "1";
            }
            catch
            {
                return "0";
            }
        }


        public static bool InsertPTLog(string UserName, decimal Amount, string operer)
        {
            return BankService.InsertPTLog(UserName, Amount, operer);
        }

        public static bool InsertPTLog2(string UserName, decimal Amount, string operer)
        {
            return BankService.InsertPTLog2(UserName, Amount, operer);
        }
    }
}
