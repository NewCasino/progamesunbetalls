using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Model;

namespace DAL
{
    /// <summary>
    /// 此处是存款，取款，管理员操作后得动作记录到BillLog表中 
    /// </summary>
    class OperateLog
    {
        private const string INSERT = "insert into BillLog(UserName,Names,Type,Amount,SubmitTime,UpdateTime,Status,Reasoncn,Reasontw,Reasonen,Reasonth,Reasonvn,bankcn,banktw,banken,bankth,bankaccount,bankno,cardno,operator,operationtime,ip) values(@UserName,@Names,@Type,@Amount,@SubmitTime,@UpdateTime,@Status,@Reasoncn,@Reasontw,@Reasonen,@Reasonth,@Reasonvn,@bankcn,@banktw,@banken,@bankth,@bankaccount,@bankno,@cardno,@operator,@operationtime,@ip);";

        public static bool InsertLogMsg(BillNoticeHistory billNotice,string operer)
        {
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@UserName",billNotice.UserName),
                new MySqlParameter("@Names",billNotice.Names),
                new MySqlParameter("@Type",billNotice.Type),
                new MySqlParameter("@Amount",billNotice.Amount),
                new MySqlParameter("@SubmitTime",billNotice.SubmitTime),
                new MySqlParameter("@UpdateTime",billNotice.UpdateTime),
                new MySqlParameter("@Status",billNotice.Status),
                new MySqlParameter("@Reasoncn",billNotice.Reasoncn),
                new MySqlParameter("@Reasontw",billNotice.Reasontw),
                new MySqlParameter("@Reasonen",billNotice.Reasonen),
                new MySqlParameter("@Reasonth",billNotice.Reasonth),
                new MySqlParameter("@Reasonvn",billNotice.Reasonvn),
                new MySqlParameter("@bankcn",billNotice.Bankcn),
                new MySqlParameter("@banktw",billNotice.Banktw),
                new MySqlParameter("@banken",billNotice.Banken),
                new MySqlParameter("@bankth",billNotice.Bankth),
                new MySqlParameter("@bankaccount",billNotice.Bankaccount),
                new MySqlParameter("@bankno",billNotice.Bankno),
                new MySqlParameter("@cardno",billNotice.CardNo),
                new MySqlParameter("@operator",operer),
                new MySqlParameter("@operationtime",DateTime.Now),
                new MySqlParameter("@ip",Util.RequestHelper.GetIP())
			};
            return MySqlHelper.ExecuteNonQuery(INSERT, param) > 0;
        }

         public static bool InsertLogMsg2(BillNoticeHistory billNotice,string operer)
        {
            string INSERT2 = "insert into BillLog(UserName,Names,Type,Amount,SubmitTime,UpdateTime,Status,Reasoncn,Reasontw,Reasonen,Reasonth,Reasonvn,bankcn,banktw,banken,bankth,bankaccount,bankno,cardno,operator,operationtime,ip) values(@UserName,@Names,@Type,@Amount,@SubmitTime,@UpdateTime,@Status,@Reasoncn,@Reasontw,@Reasonen,@Reasonth,@Reasonvn,@bankcn,@banktw,@banken,@bankth,@bankaccount,@bankno,@cardno,@operator,@operationtime,@ip);";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@UserName",billNotice.UserName),
                new MySqlParameter("@Names",billNotice.Names),
                new MySqlParameter("@Type",billNotice.Type),
                new MySqlParameter("@Amount",billNotice.Amount),
                new MySqlParameter("@SubmitTime",billNotice.SubmitTime),
                new MySqlParameter("@UpdateTime",billNotice.UpdateTime),
                new MySqlParameter("@Status",billNotice.Status),
                new MySqlParameter("@Reasoncn",billNotice.Reasoncn),
                new MySqlParameter("@Reasontw",billNotice.Reasontw),
                new MySqlParameter("@Reasonen",billNotice.Reasonen),
                new MySqlParameter("@Reasonth",billNotice.Reasonth),
                new MySqlParameter("@Reasonvn",billNotice.Reasonvn),
                new MySqlParameter("@bankcn",billNotice.Bankcn),
                new MySqlParameter("@banktw",billNotice.Banktw),
                new MySqlParameter("@banken",billNotice.Banken),
                new MySqlParameter("@bankth",billNotice.Bankth),
                new MySqlParameter("@bankaccount",billNotice.Bankaccount),
                new MySqlParameter("@bankno",billNotice.Bankno),
                new MySqlParameter("@cardno",billNotice.CardNo),
                new MySqlParameter("@operator",operer),
                new MySqlParameter("@operationtime",DateTime.Now),
                new MySqlParameter("@ip","127.0.0.1")
			};
            return MySqlHelper.ExecuteNonQuery(INSERT2, param) > 0;
        }
    }
}
