using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;

namespace DAL
{
    public class BankInfoService
    {
        private const string SQL_INSERT = "insert into BankInfo(BankNamecn,BankNametw,BankNameen,BankNameth,BankNamevn,Currency,operator,operationtime,status,ip) values(?BankNamecn,?BankNametw,?BankNameen,?BankNameth,?BankNamevn,?Currency,?Operator,?OperationTime,?Status,?IP)";
        private const string SQL_SELECT = "select id as a,BankNamecn as b,BankNametw as c,BankNameen as d,BankNameth as e,BankNamevn as f,Currency as g,operator as h,operationtime as i,status as j,ip as k from BankInfo";
        private const string SQL_SELECTBYCURR = "select id as a,BankNamecn as b,BankNametw as c,BankNameen as d,BankNameth as e,BankNamevn as f,Currency as g,operator as h,operationtime as i,status as j,ip as k from BankInfo where Currency=?Currency";
        private const string SQL_UPDATE = "update BankInfo set BankNamecn=?BankNamecn,BankNametw=?BankNametw,BankNameen=?BankNameen,BankNameth=?BankNameth,BankNamevn=?BankNamevn,Currency=?Currency,operator=?Operator,operationtime=?OperationTime,status=?Status,ip=?IP where ID=?ID";
        private const string SQL_DELETE = "delete from BankInfo where ID=?ID";

        public bool AddBankInfo(BankInfo bankInfo)
        {
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?BankNamecn",bankInfo.BankNamecn),
                new MySqlParameter("?BankNametw",bankInfo.BankNametw),
                new MySqlParameter("?BankNameen",bankInfo.BankNameen),
                new MySqlParameter("?BankNameth",bankInfo.BankNameth),
                new MySqlParameter("?BankNamevn",bankInfo.BankNamevn),
                new MySqlParameter("?Currency",bankInfo.Currency),
                new MySqlParameter("?Operator",bankInfo.Operator),
                new MySqlParameter("?OperationTime",bankInfo.OperationTime),
                new MySqlParameter("?Status",bankInfo.Status),
                new MySqlParameter("?IP",bankInfo.IP)
            };
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, parm) > 0;
        }

        public bool DeleteBankInfo(string id)
        {
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?ID",id)
            };
            return MySqlHelper.ExecuteNonQuery(SQL_DELETE, parm) > 0;
        }

        public bool UpdateBankInfo(BankInfo bankInfo)
        {
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?BankNamecn",bankInfo.BankNamecn),
                new MySqlParameter("?BankNametw",bankInfo.BankNametw),
                new MySqlParameter("?BankNameen",bankInfo.BankNameen),
                new MySqlParameter("?BankNameth",bankInfo.BankNameth),
                new MySqlParameter("?BankNamevn",bankInfo.BankNamevn),
                new MySqlParameter("?Currency",bankInfo.Currency),
                new MySqlParameter("?Operator",bankInfo.Operator),
                new MySqlParameter("?OperationTime",bankInfo.OperationTime),
                new MySqlParameter("?Status",bankInfo.Status),
                new MySqlParameter("?IP",bankInfo.IP),
                new MySqlParameter("?ID",bankInfo.Id)
            };
            int i = 0;
            try
            {
                i = MySqlHelper.ExecuteNonQuery(SQL_UPDATE, parm);
            }
            catch (Exception) { }
            return i> 0;
        }

        public string SelectAll()
        {
            string json = string.Empty;
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? "" : json;
        }

        public string SelectByCurr(string currency)
        {
            string json = string.Empty;
            MySqlParameter[] parm = new MySqlParameter[] { 
                    new MySqlParameter("?Currency",currency)
                };
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECTBYCURR, parm))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "[]" ? "" : json;
        }
    }
}
