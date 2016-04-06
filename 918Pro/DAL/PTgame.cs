using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Model;
using Util;

namespace DAL
{
    public class PTgame
    {
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="gameinfo"></param>
        /// <returns></returns>
        public static bool InsertData(Model.PTgame gameinfo)
        {
            string sql = "insert into pt_gameinfo(gameid,login,gamecode,status,startdate,enddate,hold,handle,bet_amount,payout_amount) values(@gameid,@login,@gamecode,@status,@startdate,@enddate,@hold,@handle,@bet_amount,@payout_amount)";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@gameid",gameinfo.Gameid),
                new MySqlParameter("@login",gameinfo.Login),
                new MySqlParameter("@gamecode",gameinfo.Gamecode),
                new MySqlParameter("@status",gameinfo.Status),
                new MySqlParameter("@startdate",gameinfo.Startdate),
                new MySqlParameter("@enddate",gameinfo.Enddate),
                new MySqlParameter("@hold",gameinfo.Hold),
                new MySqlParameter("@handle",gameinfo.Handle),
                new MySqlParameter("@bet_amount",gameinfo.Bet_amount),
                new MySqlParameter("@payout_amount",gameinfo.Payout_amount)
            };
            return MySqlHelper.ExecuteNonQuery(sql, param) > 0;
        }
        public static bool IsExistData(string username, DateTime time, decimal hold, decimal bet_amount)
        {
            string sql = "select count(*) from pt_gameinfo where login=@login and enddate=@enddate and hold=@hold and bet_amount=@bet_amount";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@login",username),
                new MySqlParameter("@enddate",time),
                new MySqlParameter("@hold",hold),
                new MySqlParameter("@bet_amount",bet_amount)
            };
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(sql, param)) > 0;
        }
        public static Model.PTgame GetGameinfoReport_ea(string username, DateTime enddate)
        {
            string sql = "select * from gameinforeport_ea where login=@login and enddate=@enddate";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@login",username),
                new MySqlParameter("@enddate",enddate)
            };
            return MySqlModelHelper<Model.PTgame>.GetSingleObjectBySql(sql, param);
        }
        public static bool AddGameinfoReport_ea(Model.PTgame info)
        {
            string sql = "insert into gameinforeport_ea(login,status,enddate,hold,handle,bet_amount,payout_amount) values(@login,@status,@enddate,@hold,@handle,@bet_amount,@payout_amount)";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@login",info.Login),
                new MySqlParameter("@status","1"),
                new MySqlParameter("@enddate",info.Enddate),
                new MySqlParameter("@hold",info.Hold),
                new MySqlParameter("@handle",info.Handle),
                new MySqlParameter("@bet_amount",info.Bet_amount),
                new MySqlParameter("@payout_amount",info.Payout_amount)
            };
            return MySqlHelper.ExecuteNonQuery(sql, param) > 0;
        }
        public static bool UpdateGameinfoReport_ea(Model.PTgame info)
        {
            string sql = "update gameinforeport_ea set hold=hold+@hold,handle=handle+@handle,bet_amount=bet_amount+@bet_amount,payout_amount=payout_amount+@payout_amount where login=@login and enddate=@enddate";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@login",info.Login),
                new MySqlParameter("@enddate",info.Enddate),
                new MySqlParameter("@hold",info.Hold),
                new MySqlParameter("@handle",info.Handle),
                new MySqlParameter("@bet_amount",info.Bet_amount),
                new MySqlParameter("@payout_amount",info.Payout_amount)
            };
            return MySqlHelper.ExecuteNonQuery(sql, param) > 0;
        }

    }
}
