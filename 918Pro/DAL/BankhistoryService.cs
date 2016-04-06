using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class BankhistoryService
	{
		private const string SQL_INSERT="insert into yafa.bankhistory (isdate,Currency,bank,cardno,Typ,amount,balance,operator,operationtime,ip)values(?isdate,?Currency,?bank,?cardno,?Typ,?amount,?balance,?operator,?operationtime,?ip)";
		private const string SQL_UPDATE="update yafa.bankhistory set isdate=?isdate,Currency=?Currency,bank=?bank,cardno=?cardno,Typ=?Typ,amount=?amount,balance=?balance,operator=?operator,operationtime=?operationtime,ip=?ip where ID = ?ID";
		private const string SQL_SELECTBYPK="select ID from yafa.bankhistory  where bankhistory.ID = ?ID";
		private const string SQL_SELECTALL="select ID,isdate,Currency,bank,cardno,Typ,amount,balance,operator,operationtime,ip from yafa.bankhistory ";
		private const string SQL_DELETEBYPK="delete  from yafa.bankhistory  where bankhistory.ID = ?ID";
		
		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-4-14 16:29:47		
		///</summary>		
		public Boolean AddBankhistory(Bankhistory bankhistory)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?isdate",bankhistory.Isdate),
				 new MySqlParameter("?Currency",bankhistory.Currency),
				 new MySqlParameter("?bank",bankhistory.Bank),
				 new MySqlParameter("?cardno",bankhistory.Cardno),
				 new MySqlParameter("?Typ",bankhistory.Typ),
				 new MySqlParameter("?amount",bankhistory.Amount),
				 new MySqlParameter("?balance",bankhistory.Balance),
				 new MySqlParameter("?operator",bankhistory.Operator),
				 new MySqlParameter("?operationtime",bankhistory.Operationtime),
				 new MySqlParameter("?ip",bankhistory.Ip)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-4-14 16:29:47		
		///</summary>		
		public Boolean UpdateBankhistory(Bankhistory bankhistory)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?isdate",bankhistory.Isdate),
				 new MySqlParameter("?Currency",bankhistory.Currency),
				 new MySqlParameter("?bank",bankhistory.Bank),
				 new MySqlParameter("?cardno",bankhistory.Cardno),
				 new MySqlParameter("?Typ",bankhistory.Typ),
				 new MySqlParameter("?amount",bankhistory.Amount),
				 new MySqlParameter("?balance",bankhistory.Balance),
				 new MySqlParameter("?operator",bankhistory.Operator),
				 new MySqlParameter("?operationtime",bankhistory.Operationtime),
				 new MySqlParameter("?ip",bankhistory.Ip),
				 new MySqlParameter("?ID",bankhistory.ID)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-4-14 16:29:47		
		///</summary>		
		public Boolean DeleteBankhistoryByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2011-4-14 16:29:47		
		///</summary>		
		public Bankhistory GetBankhistoryByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

			return MySqlModelHelper<Bankhistory>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2011-4-14 16:29:47		
		///</summary>		
		public IList<Bankhistory> GetMutilILBankhistory()
		{
			return MySqlModelHelper<Bankhistory>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2011-4-14 16:29:47		
		///</summary>		
		public DataTable GetMutilDTBankhistory()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 

        public string GetBankhistorybyWhere(string typ, string bank, string cardno, string time1, string time2)
        {
            string strSql;
            string strwhere = "";
            if (!string.IsNullOrEmpty(typ))
            {
                strwhere += " and Typ='" + typ + "' ";
            }
            if (!string.IsNullOrEmpty(bank))
            {
                strwhere += " and bank like '%" + bank + "%' ";
            }
            if (!string.IsNullOrEmpty(cardno))
            {
                strwhere += " and cardno='" + cardno + "' ";
            }
            if (!string.IsNullOrEmpty(time1) && !string.IsNullOrEmpty(time2))
            {
                strwhere += " and isdate>='" + time1 + "' and isdate<='" + time2 + " 23:59:59'";
            }
            if (strwhere == "")
            {
                return "";
            }
            strSql = "select ID,isdate,Currency,bank,cardno,Typ,amount,balance,operator,operationtime,ip from yafa.bankhistory ";
            strSql += " where 1=1 " + strwhere;
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(strSql));
        }


        /// <summary>
        /// 手动出帐调用此方法
        /// </summary>
        /// <param name="billNoticeHistory"></param>
        /// <returns></returns>
        public Boolean InsertBillNoticeManagent(BillNoticeHistory billNoticeHistory)
        {
            string sqlInsert = "insert into yafa.billnoticehistory (Currency,bankc,banknamec,banknoc,cardnoc,Bankcn,Reasoncn,UserName,CardNo,Amount,sfee,Type,Status,Mark,Names,SubmitTime,UpdateTime,bankamount1,bankamount2)values(?Currency,?bankc,?banknamec,?banknoc,?cardnoc,?Bankcn,?Reasoncn,?UserName,?CardNo,?Amount,?sfee,?Type,?Status,?Mark,?Names,?SubmitTime,?UpdateTime,?bankamount1,?bankamount2)";
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?Currency",billNoticeHistory.Currency),
                 new MySqlParameter("?bankc",billNoticeHistory.bankc),
                 new MySqlParameter("?banknamec",billNoticeHistory.banknamec),
                 new MySqlParameter("?banknoc",billNoticeHistory.banknoc),
                 new MySqlParameter("?cardnoc",billNoticeHistory.cardnoc),
                 new MySqlParameter("?Bankcn",billNoticeHistory.Bankcn),
                 new MySqlParameter("?Reasoncn",billNoticeHistory.Reasoncn),
                 new MySqlParameter("?UserName",billNoticeHistory.UserName),
                 new MySqlParameter("?CardNo",billNoticeHistory.CardNo),
                 new MySqlParameter("?Amount",billNoticeHistory.Amount),
                 new MySqlParameter("?sfee",billNoticeHistory.sfee),
                 new MySqlParameter("?Type",billNoticeHistory.Type),
                 new MySqlParameter("?Status",billNoticeHistory.Status),
                 new MySqlParameter("?Mark",billNoticeHistory.Mark),
                 new MySqlParameter("?Names",billNoticeHistory.Names),
                 new MySqlParameter("?SubmitTime",billNoticeHistory.SubmitTime),
                 new MySqlParameter("?UpdateTime",billNoticeHistory.UpdateTime),
                  new MySqlParameter("?bankamount1",billNoticeHistory.bankamount1),
                   new MySqlParameter("?bankamount2",billNoticeHistory.bankamount2)

				
			};
            return MySqlHelper.ExecuteNonQuery(sqlInsert, param) > 0;
        }



        public bool InsertBillNoticeManagentC(BillNoticeHistory billNoticeHistory)
        {
            string sqlInsert = "insert into yafa.billnoticehistory (Currency,bankc,banknamec,banknoc,cardnoc,Bankcn,Reasoncn,UserName,CardNo,Amount,sfee,Type,Status,Mark,Names,SubmitTime,UpdateTime,bankamount1,bankamount2)values(?Currency,?bankc,?banknamec,?banknoc,?cardnoc,?Bankcn,?Reasoncn,?UserName,?CardNo,?Amount,?sfee,?Type,?Status,?Mark,?Names,?SubmitTime,?UpdateTime,?bankamount1,?bankamount2)";
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?Currency",billNoticeHistory.Currency),
                 new MySqlParameter("?bankc",billNoticeHistory.bankc),
                 new MySqlParameter("?banknamec",billNoticeHistory.banknamec),
                 new MySqlParameter("?banknoc",billNoticeHistory.banknoc),
                 new MySqlParameter("?cardnoc",billNoticeHistory.cardnoc),
                 new MySqlParameter("?Bankcn",billNoticeHistory.Bankcn),
                 new MySqlParameter("?Reasoncn",billNoticeHistory.Reasoncn),
                 new MySqlParameter("?UserName",billNoticeHistory.UserName),
                 new MySqlParameter("?CardNo",billNoticeHistory.CardNo),
                 new MySqlParameter("?Amount",billNoticeHistory.Amount),
                 new MySqlParameter("?sfee",billNoticeHistory.sfee),
                 new MySqlParameter("?Type",billNoticeHistory.Type),
                 new MySqlParameter("?Status",billNoticeHistory.Status),
                 new MySqlParameter("?Mark",billNoticeHistory.Mark),
                 new MySqlParameter("?Names",billNoticeHistory.Names),
                 new MySqlParameter("?SubmitTime",billNoticeHistory.SubmitTime),
                 new MySqlParameter("?UpdateTime",billNoticeHistory.UpdateTime),
                  new MySqlParameter("?bankamount1",billNoticeHistory.bankamount1),
                   new MySqlParameter("?bankamount2",billNoticeHistory.bankamount2)

				
			};
            return MySqlHelper.ExecuteNonQuery(sqlInsert, param) > 0;
        }

        /// <summary>
        /// EZUN与EA相转时失败记录
        /// </summary>
        /// <param name="billNoticeHistory"></param>
        /// <returns></returns>
        public static bool InBillNoticeHistoryWrong(BillNoticeHistory billNoticeHistory)
        {

            string sqlInsert = "insert into yafa.billnoticehistory (Currency,UserName,Type,SubmitTime,UpdateTime,Status,Reasoncn,Names,Mark)values(?Currency,?UserName,?Type,?SubmitTime,?UpdateTime,?Status,?Reasoncn,?Names,?Mark)";
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?Currency",billNoticeHistory.Currency),
                 new MySqlParameter("?UserName",billNoticeHistory.UserName),
                 new MySqlParameter("?Type",billNoticeHistory.Type),
                 new MySqlParameter("?SubmitTime",billNoticeHistory.SubmitTime),
                 new MySqlParameter("?UpdateTime",billNoticeHistory.UpdateTime),
                 new MySqlParameter("?Status",billNoticeHistory.Status),
                 new MySqlParameter("?Reasoncn",billNoticeHistory.Reasoncn),
                 new MySqlParameter("?Names",billNoticeHistory.Names),
                 new MySqlParameter("?Mark",billNoticeHistory.Mark)
				
			};
            return MySqlHelper.ExecuteNonQuery(sqlInsert, param) > 0;
        }
    }
}
