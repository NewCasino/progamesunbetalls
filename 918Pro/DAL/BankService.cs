using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using MySql.Data.MySqlClient;
using Util;
using System.Data;

namespace DAL
{
    public class BankService
    {
        public const string SQL_INSERTBILLNOTICEHISTORY = "insert into BillNoticeHistory(UserName,Type,Amount,SubmitTime,UpdateTime,Status,Reasoncn,Reasontw,Reasonen,Reasonth,Reasonvn,bankno,bankaccount,bankcn,banktw,banken,bankth,cardno,banktime,tel,Currency,validAmount,Names,mark,bankamount1,bankamount2,sfee,bankc,cardnoc,banknoc,banknamec) values(?UserName,?Type,?Amount,?SubmitTime,?UpdateTime,?Status,?Reasoncn,?Reasontw,?Reasonen,?Reasonth,?Reasonvn,?BankNo,?BankAccount,?Bankcn,?Banktw,?Banken,?Bankth,?CardNo,?BankTime,?Tel,?Currency,?ValidAmount,?Names,?mark,?bankamount1,?bankamount2,?sfee,?bankc,?cardnoc,?banknoc,?banknamec)";
        public const string SQL_INSERTBILLDETAIL = "insert into BillList(UserName,Type,InAmount,OutAmount,Balance,BillTime,CardNo,Currency,Names,remark) values(?UserName,?Type,?InAmount,?OutAmount,?Balance,?BillTime,?CardNo,?Currency,?Names,?Remark)";
        public const string SQL_SELECTBILLLISTBYUSERNAME = "select Id as a ,UserName as b,Type as c,InAmount as d,OutAmount as e,Balance as f,BillTime as g,CardNo as h from BillList where userName=?userName";
        public const string SQL_SELECTBILLDETAILALL = "select Id as a ,UserName as b,Type as c,InAmount as d,OutAmount as e,Balance as f,BillTime as g,CardNo as h from BillList";
        public const string SQL_SELECTBILLDETAILBYUSER = "select Id as a ,UserName as b,Type as c,InAmount as d,OutAmount as e,Balance as f,BillTime as g,CardNo as h from BillList where UserName=?UserName";
        public const string SQL_SELECTDEPOSITHISTORY = "select Id as a,UserName as b,Type as c,Amount as d,SubmitTime as e,UpdateTime as f,Status as g,Reason as h from BillNoticeHistory where Type='1'";
        public const string SQL_SELECTWITHDRAWALHISTORY = "select BNH.Id as a,BNH.UserName as b,BNH.Type as c,BNH.Amount as d,BNH.SubmitTime as e,BNH.UpdateTime as f,BNH.Status as g,BNH.Reason as h,BNH.CardNo as i,BL.BankID as j,BL.Province as k,BL.City as l,BL.Branch as m,BL.Name as n from BillNoticeHistory as BNH left join BankList as BL on BNH.UserName = BL.UserName where BNH.Type='2'";
        public const string SQL_DELETEBILLNOTICEBYID = "delete from BillNotice where ID=?ID";
        public const string SQL_SELECTBILLNOTICEBYID = "select Id as a,UserName as b,Type as c,Amount as d,SubmitTime as e,UpdateTime as f,Status as g,Reasoncn as h,CardNo as i,bankcn as j,banktw,banken,bankth,bankaccount as l,bankno as m,banktime as n,tel as r,Currency as s,Names from yafa.BillNotice where ID=?ID";
        public const string SQL_SELECTBILLDEPOSITNOTICE = "select Id as a,UserName as b,Type as c,Amount as d,SubmitTime as e,UpdateTime as f,Status as g,Reason as h,bank,bankaccount,bankno from yafa.BillNotice where Type=1";
        public const string SQL_SELECTBILLWITHDRAWALNOTICE = "select BN.Id as a,BN.UserName as b,BN.Type as c,BN.Amount as d,BN.SubmitTime as e,BN.UpdateTime as f,BN.Status as g,BN.Reason as h,BN.CardNo as i,BL.BankID as j,BL.Province as k,BL.City as l,BL.Branch as m,BL.Name as n from BillNotice as BN left join BankList as BL on BN.UserName = BL.UserName where BN.Type='2'";
        public const string SQL_SELECTBILLNOTICEBYUSER = "select Id as a,UserName as b,Type as c,Amount as d,SubmitTime as e,UpdateTime as f,Status as g,Reason as h,CardNo as i from yafa.BillNotice where UserName=?UserName";
        public const string SQL_SELECTBILLNOTICEALL = "select Id as a,UserName as b,Type as c,Amount as d,SubmitTime as e,UpdateTime as f,Status as g,Reason as h,CardNo as i from yafa.BillNotice";
        public const string SQL_INSERTBANKINFO = "insert into yafa.BankInfo(BankName) values(?BankName)";
        public const string SQL_UPDATEBANKINFO = "update yafa.BankInfo set BankName=?BankName where ID=?ID";
        public const string SQL_DELETEBANKINFO = "delete from yafa.BankInfo where ID=?ID";
        private const string SQL_GETUSERINFO = "select UserName as a,Name as b,Email as c,Tel as d,sex as e,Birthday as f,country as g,addr as h,city as i,Province as j,post as k,Currency as l,Mobile as m,Balance as n,(select sum(Amount) from BillNoticeHistory where Type='1' and Status='2' and UserName=?UserName) as o,(select sum(Amount) from BillNoticeHistory where Type='2' and Status='2' and UserName=?UserName) as p,(select sum(validamount) from orderall where UserName=?UserName and Status<>'0') as q,(select sum(ValidAmount) from orderhistory where UserName=?UserName) as r,(select sum(result) from orderhistory where UserName=?UserName) as s from yafa.user where UserName=?UserName ";
        private const string SQL_SELECTREASONBYID = "select * from yafa.RefusedList where ID=?ID";
        private const string SQL_SELECTRATE = "select * from yafa.rate where ID=?ID";
        private const string SQL_SELECTBNHBYID = "select * from yafa.BillNoticeHistory where ID=?ID";
        private const string sqls1 = "select max(id) as a,BankNamecn as b from BankInfo where status='1' and Currency=?currency  group by BankNamecn order by sort";

        /// <summary>
        /// 存取款月汇总
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="type"></param>
        /// <param name="currency"></param>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public string BillSummaryOfMonth(string userid, string type, string currency, string date1,string date2)
        {
            string json = "";
            string sql = "";
            switch (type)
            {
                case "0":
                    type=" and 1=1 ";
                    break;
                case "1":
                    type=" and type='1' ";
                    break;
                case "2":
                    type = " and type='2' ";
                    break;


            }
            userid=userid.Trim();
            if(userid.Length==0)
            {
                userid="";
            }
            if (currency == "0")
                sql = "SELECT date_format(BillTime,'%Y-%m') cmonth , currency,sum(InAmount) InAmount,sum(OutAmount) OutAmount,0 as InAmount2,0 as OutAmount2 FROM `BillList` where 1=1 ";
            else
                sql = "SELECT date_format(BillTime,'%Y-%m') cmonth , currency,sum(InAmount) InAmount,sum(OutAmount) OutAmount,sum(InAmount*`rate`.rate) InAmount2,sum(OutAmount*`rate`.rate) OutAmount2 FROM `BillList`,`rate`  where `BillList`.currency=`rate`.code  ";
           // sql="SELECT date_format(BillTime,'%Y%m') cmonth , currency,sum(InAmount) InAmount,sum(OutAmount) OutAmount FROM `BillList`,rate  where username like '%@UserName' and  group by cmonth,currency order by cmonth,currency";
            sql = sql + "  " + type + " and date_format(BillTime,'%Y-%m')>=date_format(?date1,'%Y-%m') and date_format(BillTime,'%Y-%m')<=date_format(?date2,'%Y-%m') group by cmonth,currency order by cmonth,currency ";
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?UserName",MySqlDbType.VarChar,30),
                new MySqlParameter("?date1",MySqlDbType.VarChar,30),
                new MySqlParameter("?date2",MySqlDbType.VarChar,30)
                
            };
            if (date1.Trim().Length == 0)
            {
                date1 = DateTime.Now.ToString();
            }
            if (date2.Trim().Length == 0)
            {
                date2 = DateTime.Now.ToString();
            }
            parm[0].Value = userid;
            parm[1].Value = date1;
            parm[2].Value = date2;
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(sql,parm))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? string.Empty : json;      
            
        }

        /// <summary>
        /// 将已审核的存取款记录转移到BillNoticeHistory
        /// </summary>
        /// <param name="billNoticeHistory">BillNoticeHistory</param>
        /// <returns></returns>
        public bool InsertBillNoticeHistory(BillNoticeHistory billNoticeHistory)
        {
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?UserName",MySqlDbType.VarChar,30),
                new MySqlParameter("?Type",MySqlDbType.VarChar,1),
                new MySqlParameter("?Amount",MySqlDbType.Decimal),
                new MySqlParameter("?SubmitTime",MySqlDbType.DateTime),
                new MySqlParameter("?UpdateTime",MySqlDbType.DateTime),
                new MySqlParameter("?Status",MySqlDbType.VarChar,1),
                new MySqlParameter("?Reasoncn",MySqlDbType.VarChar,200),
                new MySqlParameter("?Reasontw",MySqlDbType.VarChar,200),
                new MySqlParameter("?Reasonen",MySqlDbType.VarChar,200),
                new MySqlParameter("?Reasonth",MySqlDbType.VarChar,200),
                new MySqlParameter("?Reasonvn",MySqlDbType.VarChar,200),
                new MySqlParameter("?BankNo",MySqlDbType.VarChar,100),
                new MySqlParameter("?BankAccount",MySqlDbType.VarChar,100),
                new MySqlParameter("?Bankcn",MySqlDbType.VarChar,100),
                new MySqlParameter("?Banktw",MySqlDbType.VarChar,100),
                new MySqlParameter("?Banken",MySqlDbType.VarChar,100),
                new MySqlParameter("?Bankth",MySqlDbType.VarChar,100),
                new MySqlParameter("?CardNo",MySqlDbType.VarChar,30),
                new MySqlParameter("?BankTime",MySqlDbType.VarChar,30),
                new MySqlParameter("?Tel",MySqlDbType.VarChar,30),
                new MySqlParameter("?Currency",MySqlDbType.VarChar,10),
                new MySqlParameter("?ValidAmount",MySqlDbType.Decimal),
                new MySqlParameter("?mark",MySqlDbType.VarChar,500),
                new MySqlParameter("?Names",MySqlDbType.VarChar,30),
                new MySqlParameter("?bankamount1",MySqlDbType.Decimal),
                new MySqlParameter("?bankamount2",MySqlDbType.Decimal),
                new MySqlParameter("?sfee",MySqlDbType.Decimal),
                new MySqlParameter("?bankc",MySqlDbType.VarChar,50),
                new MySqlParameter("?cardnoc",MySqlDbType.VarChar,50),
                new MySqlParameter("?banknoc",MySqlDbType.VarChar,50),
                new MySqlParameter("?banknamec",MySqlDbType.VarChar,50)
            };
            parm[0].Value = billNoticeHistory.UserName;
            parm[1].Value = billNoticeHistory.Type;
            parm[2].Value = billNoticeHistory.Amount;
            parm[3].Value = billNoticeHistory.SubmitTime;
            parm[4].Value = billNoticeHistory.UpdateTime;
            parm[5].Value = billNoticeHistory.Status;
            parm[6].Value = billNoticeHistory.Reasoncn;
            parm[7].Value = billNoticeHistory.Reasontw;
            parm[8].Value = billNoticeHistory.Reasonen;
            parm[9].Value = billNoticeHistory.Reasonth;
            parm[10].Value = billNoticeHistory.Reasonvn;
            parm[11].Value = billNoticeHistory.Bankno;
            parm[12].Value = billNoticeHistory.Bankaccount;
            parm[13].Value = billNoticeHistory.Bankcn;
            parm[14].Value = billNoticeHistory.Banktw;
            parm[15].Value = billNoticeHistory.Banken;
            parm[16].Value = billNoticeHistory.Bankth;
            parm[17].Value = billNoticeHistory.CardNo;
            parm[18].Value = billNoticeHistory.BankTime;
            parm[19].Value = billNoticeHistory.Tel;
            parm[20].Value = billNoticeHistory.Currency;
            parm[21].Value = billNoticeHistory.ValidAmount;
            parm[22].Value = billNoticeHistory.Mark;
            parm[23].Value = billNoticeHistory.Names;

            parm[24].Value = billNoticeHistory.bankamount1;
            parm[25].Value = billNoticeHistory.bankamount2;
            parm[26].Value = billNoticeHistory.sfee;
            parm[27].Value = billNoticeHistory.bankc;
            parm[28].Value = billNoticeHistory.cardnoc;
            parm[29].Value = billNoticeHistory.banknoc;
            parm[30].Value = billNoticeHistory.banknamec;

            return MySqlHelper.ExecuteNonQuery(SQL_INSERTBILLNOTICEHISTORY, parm) > 0;
        }

        /// <summary>
        /// 审核后将信息插入账目明细BillList表中
        /// </summary>
        /// <param name="billDetail"></param>
        /// <returns></returns>
        public bool InsertBillDetail(BillDetail billDetail)
        {
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?UserName",MySqlDbType.VarChar,30),
                new MySqlParameter("?Type",MySqlDbType.VarChar,1),
                new MySqlParameter("?InAmount",MySqlDbType.Decimal),
                new MySqlParameter("?OutAmount",MySqlDbType.Decimal),
                new MySqlParameter("?Balance",MySqlDbType.Decimal),
                new MySqlParameter("?BillTime",MySqlDbType.DateTime),
                new MySqlParameter("?CardNo",MySqlDbType.VarChar,30),
                new MySqlParameter("?Currency",MySqlDbType.VarChar,10),
                new MySqlParameter("?Names",MySqlDbType.VarChar,30),
                new MySqlParameter("?Remark",MySqlDbType.VarChar,200)
            };
            parm[0].Value = billDetail.UserName;
            parm[1].Value = billDetail.Type;
            parm[2].Value = billDetail.InAmount;
            parm[3].Value = billDetail.OutAmount;
            parm[4].Value = billDetail.Balance;
            parm[5].Value = billDetail.BillTime;
            parm[6].Value = billDetail.CardNo;
            parm[7].Value = billDetail.Currency;
            parm[8].Value = billDetail.Names;
            parm[9].Value = billDetail.Remark;
            return MySqlHelper.ExecuteNonQuery(SQL_INSERTBILLDETAIL, parm) > 0;
        }

        /// <summary>
        /// 获取所有未审核的存取款通知
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<BillNotice> GetBillNoticeList()
        {
            List<BillNotice> billNoticeList = new List<BillNotice>();
            using(MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECTBILLNOTICEALL)){
                while(reader.Read()){
                    BillNotice billNotice = new BillNotice();
                    try
                    {
                        billNotice.Id = Convert.ToInt32(reader.GetString("a"));
                        billNotice.UserName = Convert.ToString(reader.GetString("b"));
                        billNotice.Type = Convert.ToString(reader.GetString("c"));
                        billNotice.Amount = Convert.ToDecimal(reader.GetString("d"));
                        billNotice.SubmitTime = Convert.ToDateTime(reader.GetString("e"));
                        billNotice.Status = Convert.ToString(reader.GetString("g"));
                        billNotice.CardNo = Convert.ToString(reader.GetString("i"));
                    }
                    catch (Exception)
                    { }
                    billNoticeList.Add(billNotice);
                }
            }
            return billNoticeList;
        }

        /// <summary>
        /// 获取所有已审核的存款记录
        /// </summary>
        /// <returns></returns>
        public string GetDepositHistory()
        {
            string json = "";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECTDEPOSITHISTORY))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? string.Empty : json;            
        }

        /// <summary>
        /// 获取所有已审核的取款记录
        /// </summary>
        /// <returns></returns>
        public string GetWithDrawalHistory()
        {
            string json = "";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECTWITHDRAWALHISTORY))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? string.Empty : json;
        }

        public string GetDepositHistoryByWhere(string userName,string lan,string name, string status, string time1, string time2)
        {
            string SQL_SELECT = "select BL.banknamec,BL.banknoc,BL.cardnoc,BL.names, BL.Id as a,BL.UserName as b,BL.Type as c,BL.Amount as d,BL.SubmitTime as e,BL.UpdateTime as f,BL.Status as g,BL.Reasoncn as h,BL.Reasontw as i,BL.Currency as j,BL.Names as k ,BL.banktime as n,BL.tel as r,BL.bank"+lan+" as o,BL.bankno as p,BL.bankaccount as q,BL.validamount as z,BL.Currency as l from BillNoticeHistory as BL where BL.Type='1'";
            if (userName != "")
            {
                SQL_SELECT += " and BL.UserName like '%" + userName + "%'";
            }
            if (name != "")
            {
                SQL_SELECT += " and BL.Names like '%" + name + "%'";
            }
            if (status != "" && status != "1")
            {
                SQL_SELECT += " and BL.Status='" + status + "'";
            }
            if (time1 != "" && time2 != "")
            {
                SQL_SELECT += " and '" + time1 + "'<=date(BL.UpdateTime) and date(BL.UpdateTime)<='" + time2 + "'";
            }
            else
            {
                if (time1 != "" || time2 != "")
                {
                    SQL_SELECT += " and '" + (time1 == "" ? time2 : time1) + "'=date(BL.UpdateTime)";
                }
            }
            SQL_SELECT += " order by BL.UpdateTime asc";
            string json = "";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? string.Empty : json;            
        }


        public static string GetHistoryByWhere(string userName, string lan, string name, string status, string time1, string time2, string type, string mark)
        {
            string SQL_SELECT = "select BL.mark as mm, BL.Id as a,BL.UserName as b,BL.Type as c,BL.Amount as d,BL.SubmitTime as e,BL.UpdateTime as f,BL.Status as g,BL.Reasoncn as h,BL.Reasontw as i,BL.Reasonvn as vv,BL.Currency as j,BL.Names as k ,BL.banktime as n,BL.tel as r,BL.bank" + lan + " as o,BL.bankno as p,BL.bankaccount as q,BL.validamount as z,BL.Currency as l from BillNoticeHistory as BL where BL.Type='" + type + "'";
            if (userName != "")
            {
                SQL_SELECT += " and BL.UserName like '%" + userName + "%'";
            }
            if (mark != "")
            {
                SQL_SELECT += " and BL.mark like '%" + mark + "%'";
            }
            if (name != "")
            {
                SQL_SELECT += " and BL.Names like '%" + name + "%'";
            }
            if (status != "" && status != "1")
            {
                SQL_SELECT += " and BL.Status='" + status + "'";
            }
            if (time1 != "" && time2 != "")
            {
                SQL_SELECT += " and '" + time1 + "'<=date(BL.UpdateTime) and date(BL.UpdateTime)<='" + time2 + "'";
            }
            else
            {
                if (time1 != "" || time2 != "")
                {
                    SQL_SELECT += " and '" + (time1 == "" ? time2 : time1) + "'=date(BL.UpdateTime)";
                }
            }
            SQL_SELECT += " order by BL.UpdateTime asc";
            string json = "";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? string.Empty : json;
        }

        public static string GetHistoryBy56(string userName, string lan, string name, string status, string time1, string time2, string type)
        {
            string SQL_SELECT = "select BL.mark as mm, BL.Id as a,BL.UserName as b,BL.Type as c,BL.Amount as d,BL.SubmitTime as e,BL.UpdateTime as f,BL.Status as g,BL.Reasoncn as h,BL.Reasontw as i,BL.Reasonvn as vv,BL.Currency as j,BL.Names as k ,BL.banktime as n,BL.tel as r,BL.bank" + lan + " as o,BL.bankno as p,BL.bankaccount as q,BL.validamount as z,BL.Currency as l from BillNoticeHistory as BL where BL.Type in(" + type + ") ";
            if (userName != "")
            {
                SQL_SELECT += " and BL.UserName like '%" + userName + "%'";
            }
            if (name != "")
            {
                SQL_SELECT += " and BL.Names like '%" + name + "%'";
            }
            if (status != "" && status != "1")
            {
                SQL_SELECT += " and BL.Status='" + status + "'";
            }
            if (time1 != "" && time2 != "")
            {
                SQL_SELECT += " and '" + time1 + "'<=date(BL.UpdateTime) and date(BL.UpdateTime)<='" + time2 + "'";
            }
            else
            {
                if (time1 != "" || time2 != "")
                {
                    SQL_SELECT += " and '" + (time1 == "" ? time2 : time1) + "'=date(BL.UpdateTime)";
                }
            }
            SQL_SELECT += " order by BL.SubmitTime desc";
            string json = "";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? string.Empty : json;
        }


        public string GetWithDrawalHistoryByWhere(string userName, string name, string status, string time1, string time2)
        {
            string SQL_SELECT = "select BNH.bankcn,BNH.names,BNH.cardno,BNH.sfee, BNH.banknamec,BNH.banknoc,BNH.cardnoc, BNH.Id as a,BNH.UserName as b,BNH.Type as c,BNH.Amount as d,BNH.SubmitTime as e,BNH.UpdateTime as f,BNH.Status as g,BNH.Reasoncn as h,BNH.CardNo as i,BL.BankID as j,BL.Province as k,BL.City as l,BL.Branch as m,BNH.Currency as n,BNH.Names as r,BL.Name as s from BillNoticeHistory as BNH left join BankList as BL on BNH.UserName = BL.UserName where BNH.Type='2'";
            if (userName != "")
            {
                SQL_SELECT += " and BNH.UserName like '%" + userName + "%'";
            }
            if (name != "")
            {
                SQL_SELECT += " and BNH.Names like '%" + name + "%'";
            }
            if (status != "" && status != "1")
            {
                SQL_SELECT += " and BNH.Status='" + status + "'";
            }
            if (time1 != "" && time2 != "")
            {
                SQL_SELECT += " and '" + time1 + "'<=date(BNH.UpdateTime) and date(BNH.UpdateTime)<='" + time2 + "'";
            }
            else
            {
                if (time1 != "" || time2 != "")
                {
                    SQL_SELECT += " and '" + (time1 == "" ? time2 : time1) + "'=date(BNH.UpdateTime)";
                }
            }
            SQL_SELECT += " order by BNH.UpdateTime asc";
            string json = "";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? string.Empty : json;
        }

        public string GetWithDrawalByWhere(string userName, string name,string time1, string time2)
        {
            string SQL_SELECT = "select BN.Id as a,BN.UserName as b,BN.Type as c,BN.Amount as d,BN.SubmitTime as e,BN.UpdateTime as f,BN.Status as g,BN.Reason as h,BN.cardno as i,BL.BankID as j,BL.Province as k,BL.City as l,BL.Branch as m,BL.Name as n,BN.Names as s,BN.Currency as r,BN.bankcn as oz from BillNotice as BN left join BankList as BL on BN.UserName = BL.UserName where BN.Type='2'";
            if (userName != "")
            {
                SQL_SELECT += " and BN.UserName like '%" + userName + "%'";
            }
            if (name != "")
            {
                SQL_SELECT += " and BN.Names like '%" + name + "%'";
            }
            if (time1 != "" && time2 != "")
            {
                SQL_SELECT += " and '" + time1 + "'<=date(BN.SubmitTime) and date(BN.SubmitTime)<='" + time2 + "'";
            }
            else
            {
                if (time1 != "" || time2 != "") {
                    SQL_SELECT += " and '" + (time1 == "" ? time2 : time1) + "'=date(BN.SubmitTime)";
                }
            }
            SQL_SELECT += " order by BN.SubmitTime desc";
            string json = "";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? string.Empty : json;
        }

        public string GetDepositByWhere(string userName,string lan, string name,string time1, string time2)
        {
            string SQL_SELECT = "select BN.cardno,BN.Id as a, BN.UserName as b, BN.Type as c, BN.Amount as d, BN.SubmitTime as e, BN.Status as g, BN.Reason as h, BN.bankcn as i, BN.bankaccount as j, BN.bankno as k, BN.Currency as l, BN.Names as m,BL.Name as n,BL.CardNo as o,BL.Province as p,BL.City as q,BL.Branch as r,BL.BankID as s,BN.banktime as x,BN.tel as y from BillNotice as BN left join BankList as BL on BN.UserName = BL.UserName where BN.Type='1' ";
            if (userName != "")
            {
                SQL_SELECT += " and BN.UserName like '%" + userName + "%'";
            }
            if (name != "")
            {
                SQL_SELECT += " and BN.Names like '%" + name + "%'";
            }
            if (time1 != "" && time2 != "")
            {
                SQL_SELECT += " and '" + time1 + "'<=date(BN.SubmitTime) and date(BN.SubmitTime)<='" + time2 + "'";
            }
            else
            {
                if (time1 != "" || time2 != "")
                {
                    SQL_SELECT += " and '" + (time1 == "" ? time2 : time1) + "'=date(BN.SubmitTime)";                
                }
            }
            SQL_SELECT += " order by BN.SubmitTime desc";
            string json = "";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "]" ? string.Empty : json;
           // return json;
        }

        /// <summary>
        /// 获取所有未审核的存取款通知
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public string GetBillNoticeByUser(string userName)
        {
            string json = "";
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?UserName",MySqlDbType.VarChar,30)
            };
            parm[0].Value = userName;
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECTBILLNOTICEBYUSER,parm))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? string.Empty : json;
        }

        public string GetBillWithDrawalNotice()
        {
            string json = "";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECTBILLWITHDRAWALNOTICE))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? string.Empty : json;
        }

        public string GetBillDepositNotice()
        {
            string json = "";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECTBILLDEPOSITNOTICE))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? string.Empty : json;
        }

        ///// <summary>
        ///// 根据ID获取存取款记录
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public BillNotice GetBillNotice(string id)
        //{
        //    BillNotice billNotice = new BillNotice();
        //    MySqlParameter[] parm = new MySqlParameter[] { 
        //        new MySqlParameter("?ID",MySqlDbType.Int32)
        //    };
        //    parm[0].Value = Convert.ToInt32(id);
        //    using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECTBILLNOTICEBYID, parm))
        //    {
        //        if (reader.Read())
        //        {
        //            try
        //            {
        //                billNotice.Id = Convert.ToInt32(reader.GetString("a"));
        //                billNotice.UserName = reader.GetString("b");
        //                billNotice.Type = reader.GetString("c");
        //                billNotice.Amount = Convert.ToDecimal(reader.GetString("d"));
        //                billNotice.SubmitTime = Convert.ToDateTime(reader.GetString("e"));
        //                billNotice.Status = reader.GetString("g");
        //                billNotice.CardNo = reader.GetString("i");
        //                billNotice.Currency = reader.GetString("s");
        //                billNotice.Tel = reader.GetString("r");
        //                billNotice.Names = reader.GetString("Names");
        //                billNotice.BankTime = reader.GetString("n");
        //                if (billNotice.Type == "1")
        //                {
        //                    billNotice.Bankcn = reader.GetString("j");
        //                    billNotice.Banktw = reader.GetString("banktw");
        //                    billNotice.Banken = reader.GetString("banken");
        //                    billNotice.Bankth = reader.GetString("bankth");
        //                    billNotice.Bankaccount = reader.GetString("l");
        //                    billNotice.Bankno = reader.GetString("m");
        //                }
        //            }
        //            catch (Exception) { }
        //        }
        //    }
        //    return billNotice;
        //}

        public BillNotice GetBillNotice(string id)
        {
            string sql = "select * from billnotice where id=@id";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@id",id)
            };
            return MySqlModelHelper<BillNotice>.GetSingleObjectBySql(sql, param);
        }
        public BillNotice GetBillNotices(string UserName)
        {
            string sql = "select * from billnotice where UserName=@UserName and Type='5' and Status='1'";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@UserName",UserName)
            };
            return MySqlModelHelper<BillNotice>.GetSingleObjectBySql(sql, param);
        }
        public BillNotice GetBillNoticesEZUN(string UserName)
        {
            string sql = "select * from billnotice where UserName=@UserName and Type='6' and Status='1'";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@UserName",UserName)
            };
            return MySqlModelHelper<BillNotice>.GetSingleObjectBySql(sql, param);
        }
        public BillNoticeHistory GetBillNoticeHistory(string id)
        {
            BillNoticeHistory bnh = new BillNoticeHistory();
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?ID",MySqlDbType.Int32)
            };
            parm[0].Value = Convert.ToInt32(id);
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECTBNHBYID, parm))
            {
                if (reader.Read())
                {
                    try
                    {
                        bnh.Id = Convert.ToInt32(reader.GetString("ID"));
                        bnh.UserName = reader.GetString("UserName");
                        bnh.Type = reader.GetString("Type");
                        bnh.Amount = Convert.ToDecimal(reader.GetString("Amount"));
                        bnh.ValidAmount = Convert.ToDecimal(reader.GetString("validamount"));
                        bnh.SubmitTime = Convert.ToDateTime(reader.GetString("SubmitTime"));
                        bnh.UpdateTime = Convert.ToDateTime(reader.GetString("UpdateTime"));
                        bnh.Status = reader.GetString("Status");
                        bnh.Currency = reader.GetString("Currency");
                        if (bnh.Type == "1")
                        {
                            try
                            {
                                bnh.Bankcn = reader.GetString("bankcn");
                            }
                            catch
                            {
                                bnh.Bankcn = "";
                            }
                            try
                            {
                                bnh.Banktw = reader.GetString("banktw");
                            }
                            catch
                            {
                                bnh.Banktw = "";
                            }
                            try
                            {
                                bnh.Banken = reader.GetString("banken");
                            }
                            catch
                            {
                                bnh.Banken = "";
                            }
                            try
                            {
                                bnh.Bankth = reader.GetString("bankth");
                            }
                            catch
                            {
                                bnh.Bankth = "";
                            }
                            bnh.Bankaccount = reader["bankaccount"] == DBNull.Value ? "" : reader["bankaccount"].ToString();
                            bnh.Bankno = reader["bankno"] == DBNull.Value ? "" : reader["bankno"].ToString();
                            bnh.BankTime = reader["banktime"] == DBNull.Value ? "" : reader["banktime"].ToString();
                            bnh.Tel = reader["tel"] == DBNull.Value ? "" : reader["tel"].ToString();
                            bnh.cardnoc = reader["cardnoc"] == DBNull.Value ? "" : reader["cardnoc"].ToString();
                        }
                        else
                        {
                            bnh.Reasoncn = reader.GetString("reasoncn");
                            bnh.Reasontw = reader.GetString("Reasontw");
                            bnh.Reasonen = reader.GetString("Reasonen");
                            bnh.Reasonth = reader.GetString("Reasonth");
                            bnh.Reasonvn = reader.GetString("Reasonvn");
                            bnh.CardNo = reader.GetString("CardNo");
                            bnh.cardnoc = reader.GetString("cardnoc");
                        }
                        bnh.Names = reader.GetString("Names");
                    }
                    catch (Exception) { }
                }
            }
            return bnh;
        }

        /// <summary>
        /// 审核后，根据ID删除存取款通知
        /// </summary>
        /// <param name="billNoticeId"></param>
        /// <returns></returns>
        public bool DeleteBillNoticeByID(string billNoticeId)
        {
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?ID",MySqlDbType.Int32)
            };
            parm[0].Value = Convert.ToInt32(billNoticeId);
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBILLNOTICEBYID,parm) > 0;
        }
        /// <summary>
        /// 对接EA返回为EORR时删除存款通知
        /// </summary>
        /// <param name="billNoticeId"></param>
        /// <returns></returns>
        public bool DeleteBillNoticeByIDEA(string UserName)
        {
            string sql = "delete from BillNotice where UserName=?UserName and Type='5' and Status='1'";
            MySqlParameter[] parm = new MySqlParameter[] { 
               new MySqlParameter("?UserName",UserName)
            };

            return MySqlHelper.ExecuteNonQuery(sql, parm) > 0;
        }
        /// <summary>
        /// 对接EA返回为EORR时删除提款通知
        /// </summary>
        /// <param name="billNoticeId"></param>
        /// <returns></returns>
        public bool DeleteBillNoticeByIDEZUN(string UserName)
        {
            string sql = "delete from BillNotice where UserName=?UserName and Type='6' and Status='1'";
            MySqlParameter[] parm = new MySqlParameter[] { 
               new MySqlParameter("?UserName",UserName)
            };

            return MySqlHelper.ExecuteNonQuery(sql, parm) > 0;
        }

        /// <summary>
        /// 根据会员名称获取账目明细
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string GetBillList(string userName)
        {
            string json = "";
            MySqlParameter[] parm = new MySqlParameter[]{
                    new MySqlParameter("?userName",userName)
            };
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECTBILLLISTBYUSERNAME, parm))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? string.Empty : json;
        }

        /// <summary>
        /// 获取所有的账目明细记录
        /// </summary>
        /// <returns></returns>
        public string GetBillDetailAll()
        {
            string json = "";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECTBILLDETAILALL))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? string.Empty : json;            
        }


        /// <summary>
        /// 根据会员名称获取账目明细记录
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string GetBillDetailByWhere(string userName,string name,string type,string time1,string time2)
        {
            string SQL_SELECT = "select Id as a ,UserName as b,Type as c,InAmount as d,OutAmount as e,Balance as f,BillTime as g,CardNo as h,Currency as i,Names as j,remark as k from BillList where 1=1";
            if (userName != "") {
                SQL_SELECT += " and UserName like '%"+userName+"%'";
            }
            if (name != "")
            {
                SQL_SELECT += " and Names like '%" + name + "%'";
            }
            if (type != "" && type != "0")
            {
                SQL_SELECT += " and Type='" + type + "'";
            }
            if (time1 != "" && time2 != "")
            {
                SQL_SELECT += " and '" + time1 + "'<=date(BillTime) and date(BillTime)<='" + time2 + "'";
            }
            else
            {
                if (time1 != "" || time2 != "")
                {
                    SQL_SELECT += " and '" + (time1 == "" ? time2 : time1) + "'=date(BillTime)";
                }
            }
            SQL_SELECT += " order by BillTime asc";
            string json = "";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? string.Empty : json;
        }   

        /// <summary>
        /// 更新会员帐户的余额
        /// </summary>
        /// <param name="money"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UpdateBalance(string money,string userName,string type)
        {
            string SQL_UPDATEBALANCE = "";
            if (type == "1")
            {
                SQL_UPDATEBALANCE = "update yafa.user set Balance=Balance+" + money + " where UserName='" + userName + "'";
            }
            else {
                SQL_UPDATEBALANCE = "update yafa.user set Balance= Balance-" + money + " where UserName='" + userName + "'";
            }            
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATEBALANCE) > 0;
        }

        /// <summary>
        /// 获取会员帐户的当前余额
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public decimal GetUserBalance(string userName)
        {
            decimal balance = 0;
            string SQL_GETUSERBALANCE = "select Balance from yafa.user where UserName='"+userName+"'";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_GETUSERBALANCE)) {
                if (reader.Read())
                {
                    balance = Convert.ToDecimal(reader.GetString("Balance"));
                }
                reader.Close();
            }
          return balance;
        }

        /// <summary>
        /// 获取银行信息
        /// </summary>
        /// <returns></returns>
        public string GetBankInfoAll(string lan)
        {
            string json = "";
            string SQL_SELECTBANKINFO = "select id as a,BankName"+lan+" as b from BankInfo";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECTBANKINFO))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            //return json == "[]" ? string.Empty : json;
            return json;
        }

        /// <summary>
        /// 获取银行信息
        /// </summary>
        /// <returns></returns>
        public  string GetBankInfoAll()
        {         
            string json = "";    
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?currency",MySqlDbType.VarChar,30)            
             
            };
            parm[0].Value = "RMB";

            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(sqls1, parm))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "]" ? string.Empty : json;
        }

        /// <summary>
        /// 插入一条新的银行信息
        /// </summary>
        /// <param name="bankName">银行名称</param>
        /// <param name="province">省</param>
        /// <param name="city">市</param>
        /// <param name="branch">分行</param>
        /// <returns></returns>
        public bool InsertBankInfo(string bankName)
        {
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?BankName",MySqlDbType.VarChar,30),
            };
            parm[0].Value = bankName;
            return MySqlHelper.ExecuteNonQuery(SQL_INSERTBANKINFO, parm) > 0;
        }

        /// <summary>
        /// 更新银行信息
        /// </summary>
        /// <param name="bankName">银行名称</param>
        /// <param name="province">省</param>
        /// <param name="city">市</param>
        /// <param name="branch">分行</param>
        /// <returns></returns>
        public bool UpdateBankInfo(string bankName, string id)
        {
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?BankName",MySqlDbType.VarChar,30),                
                new MySqlParameter("?ID",MySqlDbType.Int32)
            };
            parm[0].Value = bankName;
            parm[1].Value = id;
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATEBANKINFO, parm) > 0;
        }

        /// <summary>
        /// 删除银行信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteBankInfo(string id)
        {
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?ID",MySqlDbType.Int32)
            };
            parm[0].Value = id;
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBANKINFO, parm) > 0;
        }

        /// <summary>
        /// 根据会员帐号查询会员详细资料
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string GetUserInfo(string userName)
        {
            string json = string.Empty;
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?UserName",MySqlDbType.VarChar,25)
            };
            parm[0].Value = userName;
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_GETUSERINFO,parm))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? string.Empty : json;
        }

        /// <summary>
        /// 查询拒绝理由
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetReason()
        {
            string SQL_SELECTREASON = string.Empty;
            string json = string.Empty;
            SQL_SELECTREASON = "select id as a,reasoncn as b,reasontw as c,reasonen as d,reasonth as e,reasonvn as f from RefusedList order by ID";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECTREASON))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? string.Empty : json;
        }

        /// <summary>
        /// 根据ID获取拒绝理由
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public RefusedList GetReasonByID(string id)
        {
            RefusedList reason = new RefusedList();
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?ID",MySqlDbType.Int32)
            };
            parm[0].Value = Convert.ToInt32(id);
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECTREASONBYID, parm))
            {
                if (reader.Read())
                {
                    reason.ID = Convert.ToInt32(reader.GetString("ID"));
                    reason.Reasoncn = reader.GetString("reasoncn");
                    reason.Reasontw = reader.GetString("reasontw");
                    reason.Reasonen = reader.GetString("reasonen");
                    reason.Reasonth = reader.GetString("reasonth");
                    reason.Reasonvn = reader.GetString("reasonvn");
                }
            }
            return reason;        
        }

        /// <summary>
        /// 插入财务操作日志
        /// </summary>
        /// <param name="billNotice">存取款信息</param>
        /// <param name="operer">操作人</param>
        /// <returns></returns>
        public bool InsertOperateLog(BillNoticeHistory billNotice,string operer)
        {
            return DAL.OperateLog.InsertLogMsg(billNotice,operer);
        }

        public bool InsertOperateLog2(BillNoticeHistory billNotice, string operer)
        {
            return DAL.OperateLog.InsertLogMsg2(billNotice,operer);
        }
        /// <summary>
        /// 根据币种获取货币信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetCurrInfo(string code)
        {
            string json = string.Empty;
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?code",code)
            };
            using(MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECTRATE,parm))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? string.Empty : json;
        }

        /// <summary>
        /// 获取会员的存款记录
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string GetDHistory(string userName)
        {
            return "";
        }

        /// <summary>
        /// 获取会员的取款记录
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string GetWDHistory(string userName)
        {
            return "";
        }

        /// <summary>
        /// 获取会员下注中的注单记录
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string GetOrderAll(string userName)
        {
            string SQL_GETOA = "select * from orderall where UserName ='" + userName + "' and Status<>'0'";
            string json = string.Empty;
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_GETOA)) {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? "none" : json;
        }

        /// <summary>
        /// 获取会员的下注历史
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string GetOrderHistory(string userName)
        {
            string str = "select id,leaguetw as league,Hometw as Home,Awaytw as Away,UserName,BetType,BetItem,Handicap,OddsType,BeginTime,time,Score,Scorehalf,BetType,Odds,BetItem,Amount,ValidAmount,Result,AgentPercent,ZAgentPercent,PartnerPercent,SubCompanyPercent,IP,Reason,date(BeginTime) from yafa.orderhistory where UserName=?UserName";
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?UserName",userName)
            };
            string json = string.Empty;
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(str,parm))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? "none" : json;
        }
        
        /// <summary>
        /// 撤消存取款
        /// </summary>
        /// <param name="bnh"></param>
        /// <returns></returns>
        public bool CancelBNH(BillNoticeHistory bnh)
        {
            //Update BilNoticeHistory
            string sql = "update BillNoticeHistory set Status=?Status,Reasoncn=?Reasoncn,Reasontw=?Reasontw,Reasonen=?Reasonen,Reasonth=?Reasonth,Reasonvn=?Reasonvn,UpdateTime=?UpdateTime where ID=?ID";
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?Status",bnh.Status), 
                new MySqlParameter("?Reasoncn",bnh.Reasoncn), 
                new MySqlParameter("?Reasontw",bnh.Reasontw),
                new MySqlParameter("?Reasonen",bnh.Reasonen),
                new MySqlParameter("?Reasonth",bnh.Reasonth),
                new MySqlParameter("?Reasonvn",bnh.Reasonvn),
                new MySqlParameter("?UpdateTime",bnh.UpdateTime),
                new MySqlParameter("?ID",bnh.Id)
            };
            if (MySqlHelper.ExecuteNonQuery(sql, parm) > 0)
            {
                //Insert BillDetail
                BillDetail bd = new BillDetail();
                bd.UserName = bnh.UserName;
                if (bnh.Type == "1")
                {
                    bd.Type = "2";
                    bd.OutAmount = Convert.ToDecimal(bnh.ValidAmount);
                }
                else {
                    bd.Type = "1";
                    bd.InAmount = Convert.ToDecimal(bnh.ValidAmount);
                }
                bd.Balance = GetUserBalance(bnh.UserName);
                bd.BillTime = Convert.ToDateTime(DateTime.Now);
                bd.CardNo = bnh.CardNo;
                bd.Currency = bnh.Currency;
                bd.Names = bnh.Names;
                bd.Remark = bnh.Reasontw;
                return InsertBillDetail(bd);
            }
            else {
                return false;
            }
        }
        /// <summary>
        /// 添加红利
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="type"></param>
        /// <param name="amount"></param>
        /// <param name="submitTime"></param>
        /// <param name="status"></param>
        /// <param name="mark"></param>
        /// <returns></returns>
        public static bool AddHongLi(string userName, string type, decimal amount, string status, string mark)
        {
            string sql = "insert into billnotice(username,type,amount,submittime,status,mark) values(@username,@type,@amount,@submittime,@status,@mark)";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@username",userName),
                new MySqlParameter("@type",type),
                new MySqlParameter("@amount",amount),
                new MySqlParameter("@submittime",DateTime.Now),
                new MySqlParameter("@status",status),
                new MySqlParameter("@mark",mark)
            };
            return MySqlHelper.ExecuteNonQuery(sql, param) > 0;
        }

        /// <summary>
        /// 添加返水
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="type"></param>
        /// <param name="amount"></param>
        /// <param name="submitTime"></param>
        /// <param name="status"></param>
        /// <param name="mark"></param>
        /// <returns></returns>
        public static bool AddFanShui(string userName, string type, decimal amount, string status, string mark, string fsbl, string time1, string time2, decimal validamount)
        {
            string sql = "insert into billnotice(username,type,amount,submittime,status,mark,reasonvn,banktime,tel,validamount) values(@username,@type,@amount,@submittime,@status,@mark,@reasonvn,@banktime,@tel,@validamount)";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@username",userName),
                new MySqlParameter("@type",type),
                new MySqlParameter("@amount",amount),
                new MySqlParameter("@submittime",DateTime.Now),
                new MySqlParameter("@status",status),
                new MySqlParameter("@mark",mark),
                new MySqlParameter("@reasonvn",fsbl),
                new MySqlParameter("@banktime",time1),
                new MySqlParameter("@tel",time2),
                new MySqlParameter("@validamount",validamount)
            };
            return MySqlHelper.ExecuteNonQuery(sql, param) > 0;
        }

        /// <summary>
        /// 返回红利返水
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetList(string userName, string time1, string time2, string type)
        {
            string sql = "";
            string subsql = "";
            userName = Util.SecurityHelper.InputValue(userName);
            time1 = Util.SecurityHelper.InputValue(time1);
            time2 = Util.SecurityHelper.InputValue(time2);
            type = Util.SecurityHelper.InputValue(type);
            if (!string.IsNullOrEmpty(userName))
            {
                subsql += " and username='" + userName + "' ";
            }
            if (!string.IsNullOrEmpty(time1) && !string.IsNullOrEmpty(time2))
            {
                subsql += " and submittime>='" + time1 + "' and submittime<='" + time2 + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(type))
            {
                subsql += " and type='" + type + "' ";
            }
            sql = "select * from billnotice where 1=1 " + subsql + " order by id";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sql));
        }


        /// <summary>
        /// 查询已审核的存取款通知 
        /// </summary>
        /// <param name="userName">会员名称</param>
        /// <returns></returns>
        public string GetBillNoticeHistory(string userName, string type, string time1, string time2, string lan)
        {
            string SQL_SELECT = "select Id as a,UserName as b,Type as c,Amount as d,SubmitTime as e,UpdateTime as f,Status as g,Reason" + lan + " as h,CardNo as i,mark,bankno as x,OperatNo as y from BillNoticeHistory where UserName='" + userName + "' and Type ='" + type + "'";
            if (time1 != "" && time2 != "")
            {
                SQL_SELECT += " and '" + time1 + "'<=date(SubmitTime) and date(SubmitTime)<='" + time2 + "'";
            }
            else
            {
                if (time1 != "")
                {
                    SQL_SELECT += " and '" + time1 + "'=date(SubmitTime)";
                }
                if (time2 != "")
                {
                    SQL_SELECT += " and date(SubmitTime)='" + time2 + "'";
                }
            }
            SQL_SELECT += " order by UpdateTime desc";
            string json = "";          
            try
            {
                using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT))
                {
                    json = ObjectToJson.ReaderToJson(reader);
                    reader.Close();
                }
            }
            catch (Exception) { }
            return json == "]" ? string.Empty : json;
        }

        /// <summary>
        /// 查询已审核的存取款通知 (会员分析)
        /// </summary>
        /// <param name="userName">会员名称</param>
        /// <returns></returns>
        public string GetBillNoticeHistory_ok(string userName, string type, string time1, string time2, string lan)
        {
            string SQL_SELECT = "select Id as a,UserName as b,Type as c,Amount as d,SubmitTime as e,UpdateTime as f,Status as g,Reason" + lan + " as h,CardNo as i,mark,bankno as x,OperatNo as y,tel from BillNoticeHistory where UserName='" + userName + "' and Type ='" + type + "' and Status='2'";
            if (time1 != "" && time2 != "")
            {
                SQL_SELECT += " and '" + time1 + "'<=date(SubmitTime) and date(SubmitTime)<='" + time2 + "'";
            }
            else
            {
                if (time1 != "")
                {
                    SQL_SELECT += " and '" + time1 + "'=date(SubmitTime)";
                }
                if (time2 != "")
                {
                    SQL_SELECT += " and date(SubmitTime)='" + time2 + "'";
                }
            }
            SQL_SELECT += " order by UpdateTime";
            string json = "";
            try
            {
                using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT))
                {
                    json = ObjectToJson.ReaderToJson(reader);
                    reader.Close();
                }
            }
            catch (Exception) { }
            return json == "]" ? string.Empty : json;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName">会员名称</param>
        /// <returns></returns>
        public string GetBillNoticeHistory_okPE(string userName, string time1, string time2, string lan)
        {
            string SQL_SELECT = "select Id as a,UserName as b,Type as c,Amount as d,SubmitTime as e,UpdateTime as f,Status as g,Reason" + lan + " as h,CardNo as i,mark,bankno as x,OperatNo as y from BillNoticeHistory where UserName='" + userName + "' and Type in('4','14') and Status='2'";
            if (time1 != "" && time2 != "")
            {
                SQL_SELECT += " and '" + time1 + "'<=date(SubmitTime) and date(SubmitTime)<='" + time2 + "'";
            }
            else
            {
                if (time1 != "")
                {
                    SQL_SELECT += " and '" + time1 + "'=date(SubmitTime)";
                }
                if (time2 != "")
                {
                    SQL_SELECT += " and date(SubmitTime)='" + time2 + "'";
                }
            }
            SQL_SELECT += " order by UpdateTime";
            string json = "";
            try
            {
                using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT))
                {
                    json = ObjectToJson.ReaderToJson(reader);
                    reader.Close();
                }
            }
            catch (Exception) { }
            return json == "]" ? string.Empty : json;
        }

        public string GetBillNoticePt(string userName,string type, string time1, string time2, string lan)
        {
            string SQL_SELECT = "select Id as a,UserName as b,Type as c,Amount as d,SubmitTime as e,UpdateTime as f,Status as g,Reason" + lan + " as h,CardNo as i,mark,bankno as x,OperatNo as y from BillNoticeHistory where UserName='" + userName + "' and Type ='" + type + "' and Status='2'";
            if (time1 != "" && time2 != "")
            {
                SQL_SELECT += " and '" + time1 + "'<=date(SubmitTime) and date(SubmitTime)<='" + time2 + "'";
            }
            else
            {
                if (time1 != "")
                {
                    SQL_SELECT += " and '" + time1 + "'=date(SubmitTime)";
                }
                if (time2 != "")
                {
                    SQL_SELECT += " and date(SubmitTime)='" + time2 + "'";
                }
            }


            SQL_SELECT += " union ";
            SQL_SELECT += " select id as a,username as b,type as c,amount as d,SubmitTime as e,UpdateTime as f,Status as g,Reason" + lan + " as h,CardNo as i,mark,bankno as x,'' as y from billnotice where UserName='" + userName + "' and Type ='" + type + "'  and Status='1'";
            if (time1 != "" && time2 != "")
            {
                SQL_SELECT += " and '" + time1 + "'<=date(SubmitTime) and date(SubmitTime)<='" + time2 + "'";
            }
            else
            {
                if (time1 != "")
                {
                    SQL_SELECT += " and '" + time1 + "'=date(SubmitTime)";
                }
                if (time2 != "")
                {
                    SQL_SELECT += " and date(SubmitTime)='" + time2 + "'";
                }
            }
         
            string json = "";
            try
            {
                using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT))
                {
                    json = ObjectToJson.ReaderToJson(reader);
                    reader.Close();
                }
            }
            catch (Exception) { }
            return json == "]" ? string.Empty : json;
        }


        /// <summary>
        /// 会员会析（特殊：取款与未审核滴取款）
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="type"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <param name="lan"></param>
        /// <returns></returns>
        public string GetBillNoticeHistory_QK(string userName, string type, string time1, string time2, string lan)
        {
           // select Id as a,UserName as b,Type as c,Amount as d,SubmitTime as e,UpdateTime as f,Status as g,Reason" + lan + " as h,CardNo as i,mark,bankno as x,OperatNo as y from BillNoticeHistory where UserName='" + userName + "' and Type ='" + type + "' and Status='2'";
            string SQL_SELECT = "select Id as a,UserName as b,Type as c,Amount as d,SubmitTime as e,UpdateTime as f,Status as g,Reason" + lan + " as h,CardNo as i,mark,bankno as x,OperatNo as y from BillNoticeHistory where UserName='" + userName + "' and Type ='2' and Status='2' ";
            if (time1 != "" && time2 != "")
            {
                SQL_SELECT += " and '" + time1 + "'<=date(SubmitTime) and date(SubmitTime)<='" + time2 + "'";
            }
            else
            {
                if (time1 != "")
                {
                    SQL_SELECT += " and '" + time1 + "'=date(SubmitTime)";
                }
                if (time2 != "")
                {
                    SQL_SELECT += " and date(SubmitTime)='" + time2 + "'";
                }
            }
            SQL_SELECT +=" union ";
            SQL_SELECT +=" select id as a,username as b,type as c,amount as d,SubmitTime as e,UpdateTime as f,Status as g,Reason" + lan + " as h,CardNo as i,mark,bankno as x,'' as y from billnotice where UserName='" + userName + "' and Type ='2'  and Status='1'";
            if (time1 != "" && time2 != "")
            {
                SQL_SELECT += " and '" + time1 + "'<=date(SubmitTime) and date(SubmitTime)<='" + time2 + "'";
            }
            else
            {
                if (time1 != "")
                {
                    SQL_SELECT += " and '" + time1 + "'=date(SubmitTime)";
                }
                if (time2 != "")
                {
                    SQL_SELECT += " and date(SubmitTime)='" + time2 + "'";
                }
            }
          
            string json = "";
            try
            {
                using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT))
                {
                    json = ObjectToJson.ReaderToJson(reader);
                    reader.Close();
                }
            }
            catch (Exception) { }
            return json == "]" ? string.Empty : json;
        }

        public string SumGetBillNoticeHistory(string userName)
        {
            //
           // string SQL_SELECT = "select Id as a,UserName as b,Type as c,Amount as d,SubmitTime as e,UpdateTime as f,Status as g,Reason" + lan + " as h,CardNo as i,mark,bankno as x,OperatNo as y from BillNoticeHistory where UserName='" + userName + "' and Type ='" + type + "'";
            string SQL_SELECT = "";
            SQL_SELECT += "select (select sum(Balance) from User where username='" + userName + "')as Bjamount ,0,";
            SQL_SELECT += "(select sum(Amount)  from billnoticehistory where type='1' and Status='2' and  username='" + userName + "')   as sumCGamount, ";
            SQL_SELECT += "(select  sum(Amount) from billnoticehistory where type='2' and Status='2'  and  username='" + userName + "') as sumQgamount, ";
            SQL_SELECT += "(select sum(Amount)  from billnoticehistory where type='3' and Status='2'  and  username='" + userName + "')  as sumHlamount , ";
            SQL_SELECT += "(select sum(Amount)  from billnoticehistory where type in('4','14') and Status='2'  and  username='" + userName + "') as sumFSamount ";
           
           // SQL_SELECT += " order by UpdateTime desc";
            string json = "";
            try
            {
                using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT))
                {
                    json = ObjectToJson.ReaderToJson(reader);
                    reader.Close();
                }
            }
            catch (Exception) { }
            return json == "]" ? string.Empty : json;
        }

        /// <summary>
        ///  日报表(可按帐号查询问)
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static string SumGetDayNoticeHistory(string userName, string time1, string time2)
        {
            StringBuilder SQL_SELECT = new StringBuilder();
            if (userName.Trim() == "")
            {

                SQL_SELECT.Append("select a.datetime,sum(a.Cgamount) as Cgamount,sum(a.Qgamount) as Qgamount ,(sum(a.Cgamount)-sum(a.Qgamount)) as Ylamount  from  ");
                SQL_SELECT.Append("(select  date(UpdateTime)   as datetime, sum(Amount) as Cgamount,0 as Qgamount from billnoticehistory where type='1' and Status='2' ");
                if (time1.Trim() != "" && time2.Trim() != "")
                {
                    SQL_SELECT.Append("and date(UpdateTime) >= '" + time1 + "' and date(UpdateTime)<='" + time2 + "' ");
                }

                SQL_SELECT.Append("group by datetime ");
                SQL_SELECT.Append("union ");
                SQL_SELECT.Append("select  date(UpdateTime)   as datetime, 0 as Cgamount,sum(Amount) as Qgamount from billnoticehistory where type='2' and Status='2' ");
                if (time1.Trim() != "" && time2.Trim() != "")
                {
                    SQL_SELECT.Append("and date(UpdateTime)  >= '" + time1 + "' and date(UpdateTime)<='" + time2 + "' ");
                }
                SQL_SELECT.Append("group by datetime) as a ");
                SQL_SELECT.Append("group by a.datetime desc ");
            }
            else
            {


                SQL_SELECT.Append("select a.datetime,sum(a.Cgamount) as Cgamount,sum(a.Qgamount) as Qgamount ,(sum(a.Cgamount)-sum(a.Qgamount)) as Ylamount   from  ");
                SQL_SELECT.Append("(select  date(UpdateTime)   as datetime, sum(Amount) as Cgamount,0 as Qgamount from billnoticehistory where type='1' and Status='2' and username='" + userName + "' ");
                if (time1.Trim() != "" && time2.Trim() != "")
                {
                    SQL_SELECT.Append("and date(UpdateTime) >= '" + time1 + "' and date(UpdateTime)<='" + time2 + "' ");
                }
                SQL_SELECT.Append(" group by datetime ");
                SQL_SELECT.Append("union ");
                SQL_SELECT.Append("select  date(UpdateTime)   as datetime, 0 as Cgamount,sum(Amount) as Qgamount from billnoticehistory where type='2' and Status='2' and username='" + userName + "' ");
                if (time1.Trim() != "" && time2.Trim() != "")
                {
                    SQL_SELECT.Append("and date(UpdateTime)>= '" + time1 + "' and date(UpdateTime)<='" + time2 + "' ");
                }
                SQL_SELECT.Append(" group by datetime) as a ");
                SQL_SELECT.Append("group by a.datetime desc ");
            }

            string json = "";
            try
            {
                using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT.ToString()))
                {
                    json = ObjectToJson.ReaderToJson(reader);
                    reader.Close();
                }
            }
            catch (Exception) { }
            return json == "]" ? string.Empty : json;
        }

        /// <summary>
        /// 判定是否有billnotice
        /// </summary>
        /// <returns>BillNotice集合</returns>
        public BillNotice IsTrueNoticeHistory(string UserName)
        {
            string sql = "select * from billnotice where UserName=@UserName and Type='5'";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@UserName",UserName)
            };
            return MySqlModelHelper<BillNotice>.GetSingleObjectBySql(sql, param);
        }

        /// <summary>
        /// 判定是否有billnotice
        /// </summary>
        /// <returns>BillNotice集合</returns>
        public BillNotice IsTrueNoticeHistoryEZUN(string UserName)
        {
            string sql = "select * from billnotice where UserName=@UserName and Type='6'";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@UserName",UserName)
            };
            return MySqlModelHelper<BillNotice>.GetSingleObjectBySql(sql, param);
        }

        /// <summary>
        /// 找回密码，验证帐号跟邮箱是否存
        /// </summary>
        /// <param name="username"></param>
        /// <param name="eamil"></param>
        /// <returns></returns>
        public static string isEmailOk(string UserName, string Email)
        {

            string sql = "select question,Answer,UserName,Email from user where UserName='" + SecurityHelper.InputValue(UserName) + "' and Email='" + SecurityHelper.InputValue(Email) + "'";       
           
            string json = "";
            try
            {
                using (MySqlDataReader reader = MySqlHelper.ExecuteReader(sql))
                {
                    json = ObjectToJson.ReaderToJson(reader);
                    reader.Close();
                }
            }
            catch (Exception) { }
            return json == "]" ? string.Empty : json;
        }

        /// <summary>
        ///  通过用户名查询出密保提问
        /// </summary>
        /// <param name="username"></param>
        /// <param name="eamil"></param>
        /// <returns></returns>
        public static string GetAnswer1(string UserName)
        {

            string sql = "select question,Answer,UserName,Email from user where UserName='" + SecurityHelper.InputValue(UserName) + "'";

            string json = "";
            try
            {
                using (MySqlDataReader reader = MySqlHelper.ExecuteReader(sql))
                {
                    json = ObjectToJson.ReaderToJson(reader);
                    reader.Close();
                }
            }
            catch (Exception) { }
            return json == "]" ? string.Empty : json;
        }


      
        /// <summary>
        /// 查询会员的银行卡信息
        /// </summary>
        /// <param name="userName">会员名称</param>
        /// <returns></returns>
        public static string GetBankList(string userName)
        {
            string json = "";
            string SQL_SELECTBANKLIST = "select BankInfo.id as aa, BankList.Id as a,BankList.UserName as b,BankList.Name as c,BankList.CardNo as d,BankInfo.BankNamecn as e,BankList.Province as f,BankList.City as g,BankList.Branch as h from BankList inner join BankInfo on BankList.BankID=BankInfo.ID where BankList.UserName=?UserName";
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?UserName",MySqlDbType.VarChar,30)
            };
            parm[0].Value = userName;
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECTBANKLIST, parm))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "]" ? string.Empty : json;
        }

        /// <summary>
        /// 每天取款次数限制
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="times">取款次数</param>
        /// <returns></returns>
        public static int IsWithDrawal(string username)
        {
            string sql = "select count(*) as times from (select id,username,submittime from billnotice where type='2' union select id,username,submittime from billnoticehistory where type='2' and status='2' ) as a where a.username=@username and date(a.submittime)=date('" + DateTime.Now.ToShortDateString() + "')";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@username",username)
            };
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(sql, param));
        }

        /// <summary>
        /// 获取会员每日赠送赢币
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static decimal YingbPerDay(string username)
        {
            string sql = "select ifnull(sum(amount),0) as yingb from billnoticehistory where type='7' and status='2' and username=@username and date(updatetime)=date('" + DateTime.Now.ToShortDateString() + "')";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@username",username)
            };
            return Convert.ToDecimal(MySqlHelper.ExecuteScalar(sql, param));
        }

        /// <summary>
        /// 会员等级查询
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string IsUserLevel(string username)
        {
            string sql = "select UserLevel from user where username=@username";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@username",username)
            };
            return MySqlHelper.ExecuteScalar(sql, param).ToString();
        }
        /// <summary>
        /// 等级Leve
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string IsLevel(int UserLeve)
        {
            string sql = "select LevelNamecn from grade where ID=@UserLeve";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@UserLeve",UserLeve)
            };
            return MySqlHelper.ExecuteScalar(sql, param).ToString();
        }

        /// <summary>
        /// 银行卡查询(公司)
        /// </summary>
        /// <param name="bankcard">银行卡别名</param>
        /// <param name="lsname">流水号</param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static string GetHistoryByWhereSum(string bankcard, string lsname, string time1, string time2)
        {
            StringBuilder SQL_SELECT = new StringBuilder();
            SQL_SELECT.Append("select id,Type,bankc,banknamec,banknoc,cardnoc,bankamount1,Amount,bankamount2,SubmitTime,UpdateTime,sfee,mark,bankno from billnoticehistory where 1=1 and  Status='2' and (Type='1' or Type='2' or Type='10' or Type='11')");
            if (time1.Trim() != "" && time2.Trim() != "")
            {
                SQL_SELECT.Append("and date(SubmitTime) >= '" + time1 + "' and date(SubmitTime)<='" + time2 + "' ");
            }
            if (bankcard !="")
            {
                SQL_SELECT.Append("and  bankc='" + bankcard + "'");
            }
            if (lsname !="")
            {
                 SQL_SELECT.Append("and  bankno='" + lsname + "'");
            }
           

            string json = "";
            try
            {
                using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT.ToString()))
                {
                    json = ObjectToJson.ReaderToJson(reader);
                    reader.Close();
                }
            }
            catch (Exception) { }
            return json == "]" ? string.Empty : json;
        }

        public static string GetHistoryByWhereSumPage(int perPageNum, int page, string bankcard, string lsname, string time1, string time2)
        {
            int limit1 = perPageNum * page;
            StringBuilder SQL_SELECT = new StringBuilder();
            StringBuilder sql = new StringBuilder();
            SQL_SELECT.Append("select id,Type,bankc,banknamec,banknoc,cardnoc,bankamount1,Amount,bankamount2,SubmitTime,UpdateTime,sfee,mark,bankno from billnoticehistory where 1=1 and  Status='2' and (Type='1' or Type='2' or Type='10' or Type='11')");
            sql.Append("select count(*) from billnoticehistory where 1=1 and  Status='2' and (Type='1' or Type='2' or Type='10' or Type='11')");
            if (time1.Trim() != "" && time2.Trim() != "")
            {
                SQL_SELECT.Append("and date(UpdateTime) >= '" + time1 + "' and date(UpdateTime)<='" + time2 + "' ");
                sql.Append("and date(UpdateTime) >= '" + time1 + "' and date(UpdateTime)<='" + time2 + "' ");
            }
            if (bankcard != "")
            {
                SQL_SELECT.Append("and  bankc='" + bankcard + "'");
                sql.Append("and  bankc='" + bankcard + "'");
            }
            if (lsname != "")
            {
                SQL_SELECT.Append("and  bankno='" + lsname + "'");
                sql.Append("and  bankno='" + lsname + "'");
            }
            SQL_SELECT.Append(" limit " + limit1.ToString() + "," + perPageNum.ToString());
            int recordNum = Convert.ToInt32(MySqlHelper.ExecuteScalar(sql.ToString()));
            string json = "";
            try
            {
                using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT.ToString()))
                {
                    string json1 = ObjectToJson.ReaderToJson(reader);
                    if (json1 != "]")
                    {
                        json = "{\"text\":[";
                        json += json1;
                        json += "],\"count\":[{\"recordNum\":\"" + recordNum.ToString() + "\"}]}";
                    }
                    else
                    {
                        json = json1;
                    }

                    reader.Close();
                }
            }
            catch (Exception) { }
            //return json == "]" ? string.Empty : json;
            return json;
        }
    
        /// <summary>
        /// 银行卡查询(用户)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetUserBankList(int id)
        {           
            StringBuilder SQL_SELECT = new StringBuilder();
            SQL_SELECT.Append("select Type,UserName,bankcn,CardNo,Names,Amount,sfee from billnoticehistory where id=" + id + " and  Status='2'");        


            string json = "";
            try
            {
                using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT.ToString()))
                {
                    json = ObjectToJson.ReaderToJson(reader);
                    reader.Close();
                }
            }
            catch (Exception) { }
            return json == "]" ? string.Empty : json;
        }

        /// <summary>
        /// 获取银行信息(按别名)网站显示
        /// </summary>
        /// <returns></returns>
        public string GetBankNameInfo()
        {
            string sqls1 = "select max(id) as a,namecn as b,nameth as c from banklistc where status='1' and Currency='RMB'  group by namecn  order by ID";
            string json = "";
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?currency",MySqlDbType.VarChar,30)            
             
            };
            parm[0].Value = "RMB";

            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(sqls1, parm))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "]" ? string.Empty : json;
        }
        /// <summary>
        /// 公司做帐内部使用银行
        /// </summary>
        /// <returns></returns>
        public string GetBankNameInfo_1()
        {
            string sqls1 = "select max(id) as a,namecn as b,nameth as c from banklistc where  Currency='RMB'  group by namecn  order by ID";
            string json = "";
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?currency",MySqlDbType.VarChar,30)            
             
            };
            parm[0].Value = "RMB";

            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(sqls1, parm))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "]" ? string.Empty : json;
        }

        /// <summary>
        /// 选择银行后绑定卡号和户名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetBankInfos(int id)
        {
            string json = string.Empty;
            string SQL_SELECT = "select namecn,cardno,bank,nameth,bank  from banklistc where id=?id";
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?id",id)            
             
            };

            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT, parm))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "]" ? string.Empty : json;
        }

        public static bool isTureAnswer(string username, string TCpassword)
        {
            string sql = "select  count(*) from user where UserName='" + SecurityHelper.InputValue(username) + "' and TCpassword='" + SecurityHelper.InputValue(TCpassword) + "'";

           
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(sql))>0;
        }

      /// <summary>
      /// 用户存款记录(存款，红利，返水)
      /// </summary>
      /// <param name="userName"></param>
      /// <param name="type"></param>
      /// <param name="time1"></param>
      /// <param name="time2"></param>  
      /// <returns></returns>
        public string GetBillNoticeHistory_user(string userName, string type, string time1, string time2, string agent)
        {
            // select Id as a,UserName as b,Type as c,Amount as d,SubmitTime as e,UpdateTime as f,Status as g from BillNoticeHistory where UserName='" + userName + "' and Type ='" + type + "' and Status='2'";

            string SQL_SELECT = "select A.Id,A.UserName,A.Type,A.Amount,A.SubmitTime,A.UpdateTime,A.Status,B.Agent from BillNoticeHistory as A";
                   SQL_SELECT +=" left join user as B on A.UserName=B.UserName";
                   SQL_SELECT += " where A.Status='2' and A.UserName<>'System' and A.Type='" + type + "'";

            if (agent !="")
            {
                SQL_SELECT += " and B.Agent like '%" + agent + "%'";        
            }
            if (userName !="")
            {
                SQL_SELECT += " and  A.UserName like '%" + userName + "%'";   
            }
            if (time1 != "" && time2 != "")
            {
                SQL_SELECT += " and '" + time1 + "'<=date(A.UpdateTime) and date(A.UpdateTime)<='" + time2 + "'";
            }
            else
            {
                if (time1 != "")
                {
                    SQL_SELECT += " and '" + time1 + "'=date(A.UpdateTime)";
                }
                if (time2 != "")
                {
                    SQL_SELECT += " and date(A.UpdateTime)='" + time2 + "'";
                }
            }
            SQL_SELECT += " order by A.UpdateTime";
            string json = "";
            try
            {
                using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT))
                {
                    json = ObjectToJson.ReaderToJson(reader);
                    reader.Close();
                }
            }
            catch (Exception) { }
            return json == "]" ? string.Empty : json;
        }

        // 再查billnoticehistory字列bankno,status，
        public static DataTable Ishistory(string paynumid)
        {
            //string SQL_SELECTALL = "SELECT * from billnoticehistory  where Type='1' and Status='2' and cardnoc='bankezun88@gmail.com' and bankno=?paynumid";
            string SQL_SELECTALL = "SELECT * from billnoticehistory  where Type='1' and Status='2' and bankno=?paynumid";
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?paynumid",paynumid)
               
			};
            return DAL.MySqlHelper.ExecuteDataTable(SQL_SELECTALL, param);

        }

        /// <summary>
        /// 工商数据查询
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="PaynumerID"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public string GetICBCData(string userName, string PaynumerID, string time1, string time2)
        {
            string SQL_SELECT = "select * from payrecord where 1=1 ";
            if (userName != "")
            {
                SQL_SELECT += " and userRealName like '%" + userName + "%'";
            }
            if (PaynumerID != "")
            {
                SQL_SELECT += " and payNumID='" + PaynumerID + "'";
            }
            if (time1 != "" && time2 != "")
            {
                SQL_SELECT += " and '" + time1 + "'<=date(createTime) and date(createTime)<='" + time2 + "'";
            }
            else
            {
                if (time1 != "")
                {
                    SQL_SELECT += " and '" + time1 + "'=date(createTime)";
                }
                if (time2 != "")
                {
                    SQL_SELECT += " and date(createTime)='" + time2 + "'";
                }
            }

            SQL_SELECT += " order by payID";
            string json = "";
            try
            {
                using (MySqlDataReader reader = MySqlHelper3.ExecuteReader(SQL_SELECT))
                {
                    json = ObjectToJson.ReaderToJson(reader);
                    reader.Close();
                }
            }
            catch (Exception) { }
            return json == "]" ? string.Empty : json;

        }

        /// <summary>
        /// 赢币已况查询
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="name"></param>
        /// <param name="status"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public string GetWinHistoryByWhere(string userName, string name, string status, string time1, string time2)
        {
           // string SQL_SELECT = "select BNH.bankcn,BNH.names,BNH.cardno,BNH.sfee, BNH.banknamec,BNH.banknoc,BNH.cardnoc, BNH.Id as a,BNH.UserName as b,BNH.Type as c,BNH.Amount as d,BNH.SubmitTime as e,BNH.UpdateTime as f,BNH.Status as g,BNH.Reasoncn as h,BNH.CardNo as i,BL.BankID as j,BL.Province as k,BL.City as l,BL.Branch as m,BNH.Currency as n,BNH.Names as r,BL.Name as s,BNH.Mark from BillNoticeHistory as BNH left join BankList as BL on BNH.UserName = BL.UserName where BNH.Type='8'";
            string SQL_SELECT = "select A.UserName as b,B.name,A.Amount as d,A.SubmitTime as e,A.UpdateTime as f,A.Status as g,A.mark  from BillNoticeHistory as A  left join user as B on A.UserName=B.UserName where A.Type='8' ";
            if (userName != "")
            {
                SQL_SELECT += " and A.UserName like '%" + userName + "%'";
            }
            if (name != "")
            {
                SQL_SELECT += " and B.name like '%" + name + "%'";
            }
            if (status != "" && status != "1")
            {
                SQL_SELECT += " and A.Status='" + status + "'";
            }
            if (time1 != "" && time2 != "")
            {
                SQL_SELECT += " and '" + time1 + "'<=date(A.UpdateTime) and date(A.UpdateTime)<='" + time2 + "'";
            }
            else
            {
                if (time1 != "" || time2 != "")
                {
                    SQL_SELECT += " and '" + (time1 == "" ? time2 : time1) + "'=date(A.UpdateTime)";
                }
            }
            SQL_SELECT += " order by A.UpdateTime asc";
            string json = "";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "" ? string.Empty : json;
        }

        /// <summary>
        /// 返回代理提款数据
        /// </summary>
        /// <returns></returns>
        public static string GetAgentWithdrawal0(string username, string name, string time1, string time2, string type, string status)
        {
            string subSql = "";
            string sql = "select c.username,c.amount, c.rolename, a.name,a.times,a.city,a.tel,a.email,a.cardno,a.bankname,a.bank,a.Ghbndk,a.Branch, b.amount as tamount, b.id  from joiner a inner join billnoticehistory1 b on a.username=b.username inner join agent c on c.username=a.username where 1=1";
            if (!string.IsNullOrEmpty(type))
            {
                subSql += " and b.type='" + type + "' ";
            }
            if (!string.IsNullOrEmpty(status))
            {
                subSql += " and b.status='" + status + "' ";
            }
            if (!string.IsNullOrEmpty(username))
            {
                subSql += " and c.username='" + username + "' ";
            }
            if (!string.IsNullOrEmpty(name))
            {
                subSql += " and a.name='" + name + "' ";
            }
            if (!string.IsNullOrEmpty(time1) && !string.IsNullOrEmpty(time2))
            {
                subSql += " and date(a.times)>=" + time1 + " and date(a.times)<=" + time2 + " ";
            }
            sql += subSql;
            sql += "  order by b.SubmitTime";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sql));
        }

        /// <summary>
        /// 代理提款审核
        /// </summary>
        /// <param name="ID">提款ID</param>
        /// <param name="amount">提款金额</param>
        /// <returns></returns>
        public static bool AgentWithdrawalCheck(int ID, string status, string mark)
        {
            string sql = "update billnoticehistory1 set UpdateTime=@UpdateTime,Status=@Status,mark=@mark where ID=@ID";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@UpdateTime",DateTime.Now),
                new MySqlParameter("@Status",status),
                new MySqlParameter("@mark",mark),
                new MySqlParameter("@ID",ID)
            };
            return MySqlHelper.ExecuteNonQuery(sql, param) > 0;
        }

        public static MySqlDataReader GetFanshuis(string time1, string time2)
        {
            string sql = "select login, ifnull(sum(handle),0) as betamount, enddate from v_ea_gameinfo where enddate>=@time1 and enddate<=@time2 group by login";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@time1",time1),
                new MySqlParameter("@time2",time2)
            };
            return MySqlHelper.ExecuteReader(sql, param);
        }

        public static MySqlDataReader GetFanshuis1(string time1, string time2)
        {
            string sql = "select login, ifnull(sum(bet_amount),0) as betamount, enddate from gameinforeport_ea where enddate>=@time1 and enddate<=@time2 group by login";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@time1",time1),
                new MySqlParameter("@time2",time2)
            };
            return MySqlHelper.ExecuteReader(sql, param);
        }

        public static MySqlDataReader GetFanshuisPT(string time1, string time2)
        {
            string sql = "select login, ifnull(sum(bet_amount),0) as betamount, enddate from pt_gameinfo where enddate>=@time1 and enddate<=@time2 group by login";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@time1",time1),
                new MySqlParameter("@time2",time2)
            };
            return MySqlHelper.ExecuteReader(sql, param);
        }

        public static bool InsertPTLog(string UserName, decimal Amount, string operer)
        {
           
            string INSERT2 = "INSERT INTO log SET userName =@UserName, time1 = @time1, IP = @IP,Amount=@Amount,mark=@mark,operer=@operer";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@UserName",UserName),     
                new MySqlParameter("@time1",DateTime.Now),
                new MySqlParameter("@IP",Util.RequestHelper.GetIP()),
                new MySqlParameter("@Amount",Amount),
                new MySqlParameter("@mark","总帐转PT审核"),
                new MySqlParameter("@operer",operer)
			};
            return MySqlHelper.ExecuteNonQuery(INSERT2, param) > 0;
        }

        public static bool InsertPTLog2(string UserName, decimal Amount, string operer)
        {
            string INSERT2 = "INSERT INTO log SET userName =@UserName, time1 = @time1, IP = @IP,Amount=@Amount,mark=@mark,operer=@operer";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@UserName",UserName),     
                new MySqlParameter("@time1",DateTime.Now),
                new MySqlParameter("@IP",Util.RequestHelper.GetIP()),
                new MySqlParameter("@Amount",Amount),
                new MySqlParameter("@mark","PT转总帐审核"),
                new MySqlParameter("@operer",operer)
			};
            return MySqlHelper.ExecuteNonQuery(INSERT2, param) > 0;
        }
    }
}
