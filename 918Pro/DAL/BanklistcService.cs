using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class BanklistcService
	{
        private const string SQL_INSERT = "insert into yafa.banklistc (Currency,namecn,nametw,nameen,nameth,cardno,bank,Province,city,Branch,status,operator,operationtime,ip)values(?Currency,?namecn,?nametw,?nameen,?nameth,?cardno,?bank,?Province,?city,?Branch,?status,?operator,?operationtime,?ip)";
        private const string SQL_UPDATE = "update yafa.banklistc set Currency=?Currency,namecn=?namecn,nametw=?nametw,nameen=?nameen,nameth=?nameth,cardno=?cardno,bank=?bank,Province=?Province,city=?city,Branch=?Branch,status=?status,operator=?operator,operationtime=?operationtime,ip=?ip,amount=?amount where ID = ?ID";
		private const string SQL_SELECTBYPK="select * from yafa.banklistc  where banklistc.ID = ?ID";
		private const string SQL_SELECTALL="select ID,Currency,name,cardno,bank,Province,city,Branch,status,operator,operationtime,ip from yafa.banklistc ";
		private const string SQL_DELETEBYPK="delete  from yafa.banklistc  where banklistc.ID = ?ID";
		
		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-4-14 16:28:31		
		///</summary>		
		public Boolean AddBanklistc(Banklistc banklistc)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?Currency",banklistc.Currency),
				 new MySqlParameter("?namecn",banklistc.Namecn),
				 new MySqlParameter("?nametw",banklistc.Nametw),
				 new MySqlParameter("?nameen",banklistc.Nameen),
				 new MySqlParameter("?nameth",banklistc.Nameth),
				 new MySqlParameter("?cardno",banklistc.Cardno),
				 new MySqlParameter("?bank",banklistc.Bank),
				 new MySqlParameter("?Province",banklistc.Province),
				 new MySqlParameter("?city",banklistc.City),
				 new MySqlParameter("?Branch",banklistc.Branch),
				 new MySqlParameter("?status",banklistc.Status),
				 new MySqlParameter("?operator",banklistc.Operator),
				 new MySqlParameter("?operationtime",banklistc.Operationtime),
				 new MySqlParameter("?ip",banklistc.Ip)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-4-14 16:28:31		
		///</summary>		
		public Boolean UpdateBanklistc(Banklistc banklistc)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?Currency",banklistc.Currency),
				 new MySqlParameter("?namecn",banklistc.Namecn),
				 new MySqlParameter("?nametw",banklistc.Nametw),
				 new MySqlParameter("?nameen",banklistc.Nameen),
				 new MySqlParameter("?nameth",banklistc.Nameth),
				 new MySqlParameter("?cardno",banklistc.Cardno),
				 new MySqlParameter("?bank",banklistc.Bank),
				 new MySqlParameter("?Province",banklistc.Province),
				 new MySqlParameter("?city",banklistc.City),
				 new MySqlParameter("?Branch",banklistc.Branch),
				 new MySqlParameter("?status",banklistc.Status),
				 new MySqlParameter("?operator",banklistc.Operator),
				 new MySqlParameter("?operationtime",banklistc.Operationtime),
				 new MySqlParameter("?ip",banklistc.Ip),
				 new MySqlParameter("?ID",banklistc.ID),
                 new MySqlParameter("?amount",banklistc.amount)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}


        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-4-14 16:28:31		
        ///</summary>		
        public Boolean UpdateBanklistc_bank(Banklistc banklistc)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?Currency",banklistc.Currency),
				 new MySqlParameter("?namecn",banklistc.Namecn),
				 new MySqlParameter("?nametw",banklistc.Nametw),
				 new MySqlParameter("?nameen",banklistc.Nameen),
				 new MySqlParameter("?nameth",banklistc.Nameth),
				 new MySqlParameter("?cardno",banklistc.Cardno),
				 new MySqlParameter("?bank",banklistc.Bank),
				 new MySqlParameter("?Province",banklistc.Province),
				 new MySqlParameter("?city",banklistc.City),
				 new MySqlParameter("?Branch",banklistc.Branch),
				 new MySqlParameter("?status",banklistc.Status),
				 new MySqlParameter("?operator",banklistc.Operator),
				 new MySqlParameter("?operationtime",banklistc.Operationtime),
				 new MySqlParameter("?ip",banklistc.Ip),
				 new MySqlParameter("?ID",banklistc.ID),
                 new MySqlParameter("?amount",banklistc.amount)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-4-14 16:28:31		
		///</summary>		
		public Boolean DeleteBanklistcByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2011-4-14 16:28:31		
		///</summary>		
		public Banklistc GetBanklistcByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

			return MySqlModelHelper<Banklistc>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2011-4-14 16:28:31		
		///</summary>		
		public IList<Banklistc> GetMutilILBanklistc()
		{
            string SQL = "select ID,Currency,namecn,nametw,nameen,nameth,cardno,bank,Province,city,Branch,status,operator,operationtime,ip,amount from yafa.banklistc ";
			return MySqlModelHelper<Banklistc>.GetObjectsBySql(SQL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2011-4-14 16:28:31		
		///</summary>		
		public DataTable GetMutilDTBanklistc()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 

        public string GetBankListcBynamecn(string namecn)
        {
            string sql = "select * from banklistc where namecn=?namecn";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?namecn",namecn)
            };
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sql,param));
        }

        public string GetBankListcByCurrency(string currency)
        {
            string sql = "select * from banklistc where currency=?currency";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?currency",currency)
            };
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sql, param));
        }

        public bool IsWithDrawal(string userName)
        {
            Boolean isExist = false;
            DateTime today = System.DateTime.Now;
            string sqlBNH = "select ID from yafa.BillNoticeHistory where userName=?UserName and date(SubmitTime) = date(?Today) and Status='2'";
            MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?UserName",userName),
                new MySqlParameter("?Today",today)
            };
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(sqlBNH, parm))
            {
                if (reader.Read())
                    isExist = true;
                reader.Close();
            }
            return isExist;
        }

        public static string GetBanklistc(string type)
        {
            string substr = "";
            string sql = "";
            type = Util.SecurityHelper.InputValue(type);
            if (!string.IsNullOrEmpty(type))
            {
                substr = " and type='" + type + "' ";
            }
            sql = "select * from banklistc where 1=1 " + substr;
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sql));
        }

        public static Banklistc GetBankByCardno(string bankno)
        {
            string sql = "select * from banklistc where nameth=@bankno";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@bankno",bankno)
            };
            return MySqlModelHelper<Banklistc>.GetSingleObjectBySql(sql, param);
        }
	}
}
