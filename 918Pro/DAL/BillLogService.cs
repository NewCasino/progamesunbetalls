using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class BillLogService
	{
		private const string SQL_INSERT="insert into yafa.BillLog (UserName,Names,Type,Amount,SubmitTime,UpdateTime,Status,Reasoncn,Reasontw,Reasonen,Reasonth,Reasonvn,bankID,bank,bankaccount,bankno,cardno,operator,operationtime,ip,Currency)values(?UserName,?Names,?Type,?Amount,?SubmitTime,?UpdateTime,?Status,?Reasoncn,?Reasontw,?Reasonen,?Reasonth,?Reasonvn,?bankID,?bank,?bankaccount,?bankno,?cardno,?operator,?operationtime,?ip,?Currency)";
		private const string SQL_UPDATE="update yafa.BillLog set UserName=?UserName,Names=?Names,Type=?Type,Amount=?Amount,SubmitTime=?SubmitTime,UpdateTime=?UpdateTime,Status=?Status,Reasoncn=?Reasoncn,Reasontw=?Reasontw,Reasonen=?Reasonen,Reasonth=?Reasonth,Reasonvn=?Reasonvn,bankID=?bankID,bank=?bank,bankaccount=?bankaccount,bankno=?bankno,cardno=?cardno,operator=?operator,operationtime=?operationtime,ip=?ip,Currency=?Currency where ID = ?ID";
		private const string SQL_SELECTBYPK="select ID from yafa.BillLog  where BillLog.ID = ?ID";
		private const string SQL_SELECTALL="select ID,UserName,Names,Type,Amount,SubmitTime,UpdateTime,Status,Reasoncn,Reasontw,Reasonen,Reasonth,Reasonvn,bankID,bank,bankaccount,bankno,cardno,operator,operationtime,ip,Currency from yafa.BillLog ";
		private const string SQL_DELETEBYPK="delete  from yafa.BillLog  where BillLog.ID = ?ID";
		
		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失�?	
		///生成时间�?011-4-14 16:25:47		
		///</summary>		
		public Boolean AddBillLog(BillLog billLog)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",billLog.UserName),
				 new MySqlParameter("?Names",billLog.Names),
				 new MySqlParameter("?Type",billLog.Type),
				 new MySqlParameter("?Amount",billLog.Amount),
				 new MySqlParameter("?SubmitTime",billLog.SubmitTime),
				 new MySqlParameter("?UpdateTime",billLog.UpdateTime),
				 new MySqlParameter("?Status",billLog.Status),
				 new MySqlParameter("?Reasoncn",billLog.Reasoncn),
				 new MySqlParameter("?Reasontw",billLog.Reasontw),
				 new MySqlParameter("?Reasonen",billLog.Reasonen),
				 new MySqlParameter("?Reasonth",billLog.Reasonth),
				 new MySqlParameter("?Reasonvn",billLog.Reasonvn),
				 new MySqlParameter("?bankID",billLog.BankID),
				 new MySqlParameter("?bank",billLog.Bank),
				 new MySqlParameter("?bankaccount",billLog.Bankaccount),
				 new MySqlParameter("?bankno",billLog.Bankno),
				 new MySqlParameter("?cardno",billLog.Cardno),
				 new MySqlParameter("?operator",billLog.Operator),
				 new MySqlParameter("?operationtime",billLog.Operationtime),
				 new MySqlParameter("?ip",billLog.Ip),
				 new MySqlParameter("?Currency",billLog.Currency)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失�?	
		///生成时间�?011-4-14 16:25:47		
		///</summary>		
		public Boolean UpdateBillLog(BillLog billLog)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",billLog.UserName),
				 new MySqlParameter("?Names",billLog.Names),
				 new MySqlParameter("?Type",billLog.Type),
				 new MySqlParameter("?Amount",billLog.Amount),
				 new MySqlParameter("?SubmitTime",billLog.SubmitTime),
				 new MySqlParameter("?UpdateTime",billLog.UpdateTime),
				 new MySqlParameter("?Status",billLog.Status),
				 new MySqlParameter("?Reasoncn",billLog.Reasoncn),
				 new MySqlParameter("?Reasontw",billLog.Reasontw),
				 new MySqlParameter("?Reasonen",billLog.Reasonen),
				 new MySqlParameter("?Reasonth",billLog.Reasonth),
				 new MySqlParameter("?Reasonvn",billLog.Reasonvn),
				 new MySqlParameter("?bankID",billLog.BankID),
				 new MySqlParameter("?bank",billLog.Bank),
				 new MySqlParameter("?bankaccount",billLog.Bankaccount),
				 new MySqlParameter("?bankno",billLog.Bankno),
				 new MySqlParameter("?cardno",billLog.Cardno),
				 new MySqlParameter("?operator",billLog.Operator),
				 new MySqlParameter("?operationtime",billLog.Operationtime),
				 new MySqlParameter("?ip",billLog.Ip),
				 new MySqlParameter("?Currency",billLog.Currency),
				 new MySqlParameter("?ID",billLog.ID)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失�?	
		///生成时间�?011-4-14 16:25:47		
		///</summary>		
		public Boolean DeleteBillLogByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间�?011-4-14 16:25:47		
		///</summary>		
		public BillLog GetBillLogByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

			return MySqlModelHelper<BillLog>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间�?011-4-14 16:25:47		
		///</summary>		
		public IList<BillLog> GetMutilILBillLog()
		{
			return MySqlModelHelper<BillLog>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间�?011-4-14 16:25:47		
		///</summary>		
		public DataTable GetMutilDTBillLog()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 

        public string GetLogbyWhere(string typ, string operators, string operationtimes, string operationtimee, string lan)
        {
            string subSql = "";
            string strSql;
            string strwhere = "";
            lan = lan.ToLower();
            switch (lan)
            {
                case "zh-cn":
                    subSql = " Reasoncn as reason,bankcn as bank";
                    break;
                case "zh-tw":
                    subSql = "Reasontw as reason,banktw as bank";
                    break;
                case "en-us":
                    subSql = "Reasonen as reason,banken as bank";
                    break;
                case "th-th":
                    subSql = "Reasonth as reason,bankth as bank";
                    break;
                case "vi-vn":
                    subSql = "Reasonvn as reason,banken as bank";
                    break;
                default:
                    subSql = " Reasoncn as reason,bankcn as bank";
                    break;
            }
            if (!string.IsNullOrEmpty(typ))
            {
                strwhere += " and Type='" + typ + "' ";
            }
            if (!string.IsNullOrEmpty(operators))
            {
                strwhere += " and operator like '%" + operators + "%' ";
            }
            if (!string.IsNullOrEmpty(operationtimes) && !string.IsNullOrEmpty(operationtimee))
            {
                strwhere += " and operationtime>='" + operationtimes + "' and operationtime<='" + operationtimee + " 23:59:59'";
            }
            if (strwhere == "")
            {
                return "";
            }
            strSql = "select " + subSql + ",ID,UserName,Names,Type,Amount,SubmitTime,UpdateTime,Status,bankID,bankaccount,bankno,cardno,operator,operationtime,ip,Currency from yafa.BillLog ";
            strSql += " where 1=1 " + strwhere;
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(strSql));
        }

	}
}
