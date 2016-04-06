using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using MySql.Data.MySqlClient;

namespace DAL.Ezun
{
    public class BankService
    {
        private const string SQL_INSERTBILLNOTICE = "insert into BillNotice(UserName,Type,Amount,SubmitTime,Status,CardNo,bankcn,banktw,banken,bankth,bankno,Currency,Names,banktime,tel) values(?UserName,?Type,?Amount,?SubmitTime,?Status,?CardNo,?bankcn,?banktw,?banken,?bankth,?bankno,?Currency,?Names,?BankTime,?Tel)";
        /// <summary>
        /// 公司银行
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        public string GetBankCByCurr()
        {
            string json = string.Empty;
            string SQL_SELECT = "select namecn,cardno,bank  from banklistc where id=51";

            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "]" ? string.Empty : json;
        }

        public bool UpdateBillNotice2(string bankno, string Amount)
        {
            string sql = "update billnotice set Status=2  where bankno=?bankno and Amount=?Amount";
            MySqlParameter[] param = new MySqlParameter[] {               
                new MySqlParameter("?bankno",bankno),
                new MySqlParameter("?Amount",Amount)
            };
            return MySqlHelper.ExecuteNonQuery(sql, param) > 0;
        }


        public bool UpdateBillNotice(string bankno)
        {
            string sql = "update billnotice set Status=2  where bankno=?bankno ";
            MySqlParameter[] param = new MySqlParameter[] {               
                new MySqlParameter("?bankno",bankno)
            };
            return MySqlHelper.ExecuteNonQuery(sql, param) > 0;
        }
        /// <summary>
        /// 插入一条新的存取款通知
        /// </summary>
        /// <param name="billNotice"></param>
        /// <returns></returns>
        public bool AddBillNotice(BillNotice billNotice)
        {
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?UserName",MySqlDbType.VarChar,30),
                new MySqlParameter("?Type",MySqlDbType.VarChar,1),
                new MySqlParameter("?Amount",MySqlDbType.Decimal),
                new MySqlParameter("?SubmitTime",MySqlDbType.DateTime),
                new MySqlParameter("?Status",MySqlDbType.VarChar,1),
                new MySqlParameter("?CardNo",MySqlDbType.VarChar,30),
                new MySqlParameter("?bankcn",MySqlDbType.VarChar,100),
                new MySqlParameter("?banktw",MySqlDbType.VarChar,100),
                new MySqlParameter("?banken",MySqlDbType.VarChar,100),
                new MySqlParameter("?bankth",MySqlDbType.VarChar,100),           
                new MySqlParameter("?bankno",MySqlDbType.VarChar,100),
                new MySqlParameter("?Currency",MySqlDbType.VarChar,10),
                new MySqlParameter("?Names",MySqlDbType.VarChar,30),
                new MySqlParameter("?BankTime",MySqlDbType.VarChar,30),
                new MySqlParameter("?Tel",MySqlDbType.VarChar,30),
              
            };

            parm[0].Value = billNotice.UserName;
            parm[1].Value = billNotice.Type;
            parm[2].Value = billNotice.Amount;
            parm[3].Value = billNotice.SubmitTime;
            parm[4].Value = billNotice.Status;
            parm[5].Value = billNotice.CardNo;
            parm[6].Value = billNotice.Bankcn;
            parm[7].Value = billNotice.Banktw;
            parm[8].Value = billNotice.Banken;
            parm[9].Value = billNotice.Bankth;          
            parm[10].Value = billNotice.Bankno;
            parm[11].Value = billNotice.Currency;
            parm[12].Value = billNotice.Names;
            parm[13].Value = billNotice.BankTime;
            parm[14].Value = billNotice.Tel;
         
            return MySqlHelper.ExecuteNonQuery(SQL_INSERTBILLNOTICE, parm) > 0;
        }


        public bool AddBillNotice2(BillNotice billNotice)
        {
            string SQL_INSERTBILLNOTICE = "insert into BillNotice(UserName,Type,Amount,SubmitTime,Status,CardNo,bankcn,banktw,banken,bankth,bankno,Currency,Names,banktime,tel,Mark) values(?UserName,?Type,?Amount,?SubmitTime,?Status,?CardNo,?bankcn,?banktw,?banken,?bankth,?bankno,?Currency,?Names,?BankTime,?Tel,?Mark)";
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?UserName",MySqlDbType.VarChar,30),
                new MySqlParameter("?Type",MySqlDbType.VarChar,1),
                new MySqlParameter("?Amount",MySqlDbType.Decimal),
                new MySqlParameter("?SubmitTime",MySqlDbType.DateTime),
                new MySqlParameter("?Status",MySqlDbType.VarChar,1),
                new MySqlParameter("?CardNo",MySqlDbType.VarChar,30),
                new MySqlParameter("?bankcn",MySqlDbType.VarChar,100),
                new MySqlParameter("?banktw",MySqlDbType.VarChar,100),
                new MySqlParameter("?banken",MySqlDbType.VarChar,100),
                new MySqlParameter("?bankth",MySqlDbType.VarChar,100),           
                new MySqlParameter("?bankno",MySqlDbType.VarChar,100),
                new MySqlParameter("?Currency",MySqlDbType.VarChar,10),
                new MySqlParameter("?Names",MySqlDbType.VarChar,30),
                new MySqlParameter("?BankTime",MySqlDbType.VarChar,30),
                new MySqlParameter("?Tel",MySqlDbType.VarChar,30),
                new MySqlParameter("?Mark",MySqlDbType.VarChar,30)
              
            };

            parm[0].Value = billNotice.UserName;
            parm[1].Value = billNotice.Type;
            parm[2].Value = billNotice.Amount;
            parm[3].Value = billNotice.SubmitTime;
            parm[4].Value = billNotice.Status;
            parm[5].Value = billNotice.CardNo;
            parm[6].Value = billNotice.Bankcn;
            parm[7].Value = billNotice.Banktw;
            parm[8].Value = billNotice.Banken;
            parm[9].Value = billNotice.Bankth;
            parm[10].Value = billNotice.Bankno;
            parm[11].Value = billNotice.Currency;
            parm[12].Value = billNotice.Names;
            parm[13].Value = billNotice.BankTime;
            parm[14].Value = billNotice.Tel;
            parm[15].Value = billNotice.Mark;
            

            return MySqlHelper.ExecuteNonQuery(SQL_INSERTBILLNOTICE, parm) > 0;
        }

        /// <summary>
        /// 获取银行信息
        /// </summary>
        /// <returns></returns>
        public string GetBankInfoAll()
        {
            string sqls1 = "select max(id) as a,BankNamecn as b from BankInfo where status='1' and Currency=?currency  group by BankNamecn order by sort";
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
        /// 查询未审核的存取款通知 
        /// </summary>
        /// <param name="userName">会员名称</param>
        /// <returns></returns>
        public string GetBillNotice(string userName, string type, string time1, string time2, string lan)
        {
            string SQL_SELECT = "select Id as a,UserName as b,Type as c,Amount as d,SubmitTime as e,UpdateTime as f,Status as g,Reason" + lan + " as h,CardNo as i from BillNotice where UserName='" + userName + "' and Type ='" + type + "'";
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
            SQL_SELECT += " order by SubmitTime desc";
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

        public string GetBillAll(string userName, string type, string status, string time1, string time2, string lan, string limit)
        {
            userName = userName.Replace("'", "‘");
            type = type.Replace("'", "’");
            time1 = time1.Replace("'", "‘");
            time2 = time2.Replace("'", "’");
            lan = lan.Replace("'", "‘");
            limit = limit.Replace("'", "’");
            status = status.Replace("'", "‘");

            string sql = "select * from (select Id as a,UserName as b,Type as c,Amount as d,SubmitTime as e,UpdateTime as f,Status as g,Reason" + lan + " as h,CardNo as i,'' as mark from BillNotice union select Id as a,UserName as b,Type as c,Amount as d,SubmitTime as e,UpdateTime as f,Status as g,Reason" + lan + " as h,CardNo as i,mark from BillNoticeHistory) as a ";
            string sqlWhere = "";
            if (!string.IsNullOrEmpty(userName))
            {
                sqlWhere += " and a.b='" + userName + "' ";
            }
            if (!string.IsNullOrEmpty(type))
            {
                sqlWhere += " and a.c='" + type + "' ";
            }
            if (!string.IsNullOrEmpty(status))
            {
                sqlWhere += " and a.g='" + status + "' ";
            }
            if (!string.IsNullOrEmpty(time1) && !string.IsNullOrEmpty(time2))
            {
                sqlWhere += " and a.e>='" + time1 + "' and a.e<='" + time2 + " 23:59:59'";
            }
            if (sqlWhere == "")
            {
                return "";
            }
            sql += " where 1=1 " + sqlWhere + " order by a.e desc ";
            if (!string.IsNullOrEmpty(limit))
            {
                sql += " limit 0," + limit;
            }
            string json = ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sql));
            return json == "]" ? string.Empty : json;
        }

        /// <summary>
        /// 查询已审核的存取款通知 
        /// </summary>
        /// <param name="userName">会员名称</param>
        /// <returns></returns>
        public string GetBillNoticeHistory(string userName, string type, string time1, string time2, string lan)
        {
            string SQL_SELECT = "select Id as a,UserName as b,Type as c,Amount as d,SubmitTime as e,UpdateTime as f,Status as g,Reason" + lan + " as h,CardNo as i,mark from BillNoticeHistory where UserName='" + userName + "' and Type ='" + type + "'";
            if (time1 != "" && time2 != "")
            {
                SQL_SELECT += " and '" + time1 + "'<=date(UpdateTime) and date(UpdateTime)<='" + time2 + "'";
            }
            else
            {
                if (time1 != "")
                {
                    SQL_SELECT += " and '" + time1 + "'=date(UpdateTime)";
                }
                if (time2 != "")
                {
                    SQL_SELECT += " and date(UpdateTime)='" + time2 + "'";
                }
            }
            if (type=="3" || type=="4" || type=="14")
            {
                SQL_SELECT += "  and Status='2'";
            }
            SQL_SELECT += " order by UpdateTime desc";
            string json = "";
            //MySqlParameter[] parm = new MySqlParameter[] { 
            //    new MySqlParameter("?UserName",MySqlDbType.VarChar,30)
            //};
            //parm[0].Value = userName;
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
        //通过 ID获取卡号
        public static string GetBankInfo(string id)
        {
          
            string SQL_SELECT = "select cardno from banklistc where id=?id";
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?id",id)
             
            };
            return Convert.ToString(MySqlHelper.ExecuteScalar(SQL_SELECT, param));


        }

        /// <summary>
        /// 获取银行信息
        /// </summary>
        /// <returns></returns>
        public static string GetBankInfoAll(string lan, string currency)
        {
            string json = "";
            string sql = "select max(id) as a,BankName" + lan + " as b from BankInfo where status='1' and Currency='" + currency + "' group by BankName" + lan + " order by sort";
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(sql))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "]" ? string.Empty : json;
        }

        /// <summary>
        /// 插入银行卡信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userName"></param>
        /// <param name="cardNo"></param>
        /// <param name="bankID"></param>
        /// <param name="province"></param>
        /// <param name="city"></param>
        /// <param name="branch"></param>
        /// <returns></returns>
        public static bool InsertBankList(string name, string userName, string cardNo, string bankID, string province, string city, string branch)
        {
            string sql = "insert into BankList(UserName,Name,CardNo,BankID,Province,City,Branch) values(?UserName,?Name,?CardNo,?BankID,?Province,?City,?Branch)";
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?UserName",MySqlDbType.VarChar,30),
                new MySqlParameter("?Name",MySqlDbType.VarChar,30),
                new MySqlParameter("?CardNo",MySqlDbType.VarChar,30),
                new MySqlParameter("?BankID",MySqlDbType.Int32),
                new MySqlParameter("?Province",MySqlDbType.VarChar,30),
                new MySqlParameter("?City",MySqlDbType.VarChar,30),                
                new MySqlParameter("?Branch",MySqlDbType.VarChar,200)
            };
            parm[0].Value = userName;
            parm[1].Value = name;
            parm[2].Value = cardNo;
            parm[3].Value = bankID;
            parm[4].Value = province;
            parm[5].Value = city;
            parm[6].Value = branch;
            return MySqlHelper.ExecuteNonQuery(sql, parm) > 0;
        }
        /// <summary>
        /// 更新银行卡
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userName"></param>
        /// <param name="cardNo"></param>
        /// <param name="bankID"></param>
        /// <param name="province"></param>
        /// <param name="city"></param>
        /// <param name="branch"></param>
        /// <returns></returns>
        public static bool UpdateBankList(string name, string userName, string cardNo, string bankID, string province, string city, string branch)
        {
            string sql = "update BankList set Name=?Name,CardNo=?CardNo,BankID=?BankID,Province=?Province,City=?City,Branch=?Branch where UserName=?UserName";
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?Name",MySqlDbType.VarChar,30),
                new MySqlParameter("?CardNo",MySqlDbType.VarChar,30),
                new MySqlParameter("?BankID",MySqlDbType.Int32),
                new MySqlParameter("?Province",MySqlDbType.VarChar,30),
                new MySqlParameter("?City",MySqlDbType.VarChar,30),                
                new MySqlParameter("?Branch",MySqlDbType.VarChar,200),
                new MySqlParameter("?UserName",MySqlDbType.VarChar,30)
            };
            parm[0].Value = name;
            parm[1].Value = cardNo;
            parm[2].Value = bankID;
            parm[3].Value = province;
            parm[4].Value = city;
            parm[5].Value = branch;
            parm[6].Value = userName;
            return MySqlHelper.ExecuteNonQuery(sql, parm) > 0;
        }

        /// <summary>
        /// 查询会员的银行卡信息
        /// </summary>
        /// <param name="userName">会员名称</param>
        /// <returns></returns>
        public static string GetBankList(string userName, string lan)
        {
            string json = "";
            string SQL_SELECTBANKLIST = "select BankInfo.id as aa, BankList.Id as a,BankList.UserName as b,BankList.Name as c,BankList.CardNo as d,BankInfo.BankName" + lan + " as e,BankList.Province as f,BankList.City as g,BankList.Branch as h from BankList inner join BankInfo on BankList.BankID=BankInfo.ID where BankList.UserName=?UserName";
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Model.Banklistc GetBankCByID(string id)
        {
            string sql = "select ID,Currency,namecn,nametw,nameen,nameth,cardno,bank,Province,city,Branch,status,operator,operationtime,ip from yafa.banklistc where ID=?ID";
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?ID",id)
            };
            return MySqlModelHelper<Model.Banklistc>.GetSingleObjectBySql(sql, parm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="billNotice"></param>
        /// <returns></returns>
        
        public static string AddBillNotice1(BillNotice billNotice)
        {
            string sql = "insert into BillNotice(payType,UserName,Type,Amount,SubmitTime,Status,CardNo,bankcn,banktw,banken,bankth,bankaccount,bankno,Currency,Names,banktime,tel) values(?payType,?UserName,?Type,?Amount,?SubmitTime,?Status,?CardNo,?bankcn,?banktw,?banken,?bankth,?bankaccount,?bankno,?Currency,?Names,?BankTime,?Tel);SELECT LAST_INSERT_ID();";
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?UserName",MySqlDbType.VarChar,30),
                new MySqlParameter("?Type",MySqlDbType.VarChar,1),
                new MySqlParameter("?Amount",MySqlDbType.Decimal),
                new MySqlParameter("?SubmitTime",MySqlDbType.DateTime),
                new MySqlParameter("?Status",MySqlDbType.VarChar,1),
                new MySqlParameter("?CardNo",MySqlDbType.VarChar,30),
                new MySqlParameter("?bankcn",MySqlDbType.VarChar,100),
                new MySqlParameter("?banktw",MySqlDbType.VarChar,100),
                new MySqlParameter("?banken",MySqlDbType.VarChar,100),
                new MySqlParameter("?bankth",MySqlDbType.VarChar,100),
                new MySqlParameter("?bankaccount",MySqlDbType.VarChar,100),
                new MySqlParameter("?bankno",MySqlDbType.VarChar,100),
                new MySqlParameter("?Currency",MySqlDbType.VarChar,10),
                new MySqlParameter("?Names",MySqlDbType.VarChar,30),
                new MySqlParameter("?BankTime",MySqlDbType.VarChar,30),
                new MySqlParameter("?Tel",MySqlDbType.VarChar,30),
                new MySqlParameter("?payType",MySqlDbType.VarChar,30)
            };
            parm[0].Value = billNotice.UserName;
            parm[1].Value = billNotice.Type;
            parm[2].Value = billNotice.Amount;
            parm[3].Value = billNotice.SubmitTime;
            parm[4].Value = billNotice.Status;
            parm[5].Value = billNotice.CardNo;
            parm[6].Value = billNotice.Bankcn;
            parm[7].Value = billNotice.Banktw;
            parm[8].Value = billNotice.Banken;
            parm[9].Value = billNotice.Bankth;
            parm[10].Value = billNotice.Bankaccount;
            parm[11].Value = billNotice.Bankno;
            parm[12].Value = billNotice.Currency;
            parm[13].Value = billNotice.Names;
            parm[14].Value = billNotice.BankTime;
            parm[15].Value = billNotice.Tel;
            parm[16].Value = billNotice.payType;

            return MySqlHelper.ExecuteScalar(sql,parm).ToString();
        }
        /// <summary>
        /// 更新余额（转出减钱）
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public static bool UpdateBalance(int userId, decimal money)
        {
            string sql = "update user set Balance=Balance-?b  where id=?id ";
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?b",money),
                new MySqlParameter("?id",userId)
            };
            return MySqlHelper.ExecuteNonQuery(sql, param) > 0;
        }
        /// <summary>
        /// 更新余额（转进加钱）
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public static bool UpdateBalanceA(int userId, decimal money)
        {
            string sql = "update user set Balance=Balance+?b  where id=?id ";
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?b",money),
                new MySqlParameter("?id",userId)
            };
            return MySqlHelper.ExecuteNonQuery(sql, param) > 0;
        }
        /// <summary>
        /// 更新余额EZUN
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public static bool UpdateBalanceEZUN(int userId, decimal money)
        {
            string sql = "update user set Balance=Balance+?b  where id=?id ";
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?b",money),
                new MySqlParameter("?id",userId)
            };
            return MySqlHelper.ExecuteNonQuery(sql, param) > 0;
        }

        /// <summary>
        /// 转向EA，转向总帐成功通过查询
        /// </summary>
        /// <param name="userName">会员名称</param>
        /// <returns></returns>
        public string GetBillNotice_sum(string userName,string time1, string time2, string lan)
        {
            string SQL_SELECT = "select Id as a,UserName as b,Type as c,Amount as d,SubmitTime as e,UpdateTime as f,Status as g,Reason" + lan + " as h,CardNo as i from billnoticehistory where UserName='" + userName + "' and  (Type ='5' or Type='6') and status='2'";
            if (time1 != "" && time2 != "")
            {
                SQL_SELECT += " and '" + time1 + "'<=date(UpdateTime) and date(UpdateTime)<='" + time2 + "'";
            }
            else
            {
                if (time1 != "")
                {
                    SQL_SELECT += " and '" + time1 + "'=date(UpdateTime)";
                }
                if (time2 != "")
                {
                    SQL_SELECT += " and date(UpdateTime)='" + time2 + "'";
                }
            }
            SQL_SELECT += " order by SubmitTime desc";
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
        /// 获取银行信息
        /// </summary>
        /// <returns></returns>
        public string GetBankInfo()
        {
            string sqls1 = "select max(id) as a,namecn as b,nameth as d from banklistc where status='1' and Currency='RMB'  group by namecn  order by ID";
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
            string SQL_SELECT = "select namecn,cardno,bank  from banklistc where id=?id";
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

        public string GetBankInfos4()
        {
            string json = string.Empty;
            string SQL_SELECT = "select namecn,cardno,bank  from banklistc where namecn='中国工商银行' and status='1'";
           

            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "]" ? string.Empty : json;
        }



        public string Getparentcode(string username)
        {
            string json = string.Empty;
            string SQL_SELECT = "select parentcode  from agent where UserName='" + username + "'";


            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "]" ? string.Empty : json;
        }

        public static int GetPTttoezunInfo(string  username,string type)
        {
            string str = "select count(*) from billnotice where UserName=?username and Type=?type";
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?username",username),
                new MySqlParameter("?type",type)
            };
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(str, param));
        }

        public static int SelectBillNoticenum(string bankno)
        {
            string sql = "select count(*) from billnotice  where bankno=?bankno ";
            MySqlParameter[] param = new MySqlParameter[] {               
                new MySqlParameter("?bankno",bankno)
            };
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(sql, param));
        }

    }
}
