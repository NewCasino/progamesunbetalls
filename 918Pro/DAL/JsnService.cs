using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class JsnService
	{
		private const string SQL_INSERT="insert into yafa.jsn (UserName,sn,isdate,cuser,ctime)values(?UserName,?sn,?isdate,?cuser,?ctime)";
		private const string SQL_UPDATE="update yafa.jsn set UserName=?UserName,sn=?sn,isdate=?isdate,cuser=?cuser,ctime=?ctime where ID = ?ID";
		private const string SQL_SELECTBYPK="select ID from yafa.jsn  where jsn.ID = ?ID";
		private const string SQL_SELECTALL="select ID,UserName,sn,isdate,cuser,ctime from yafa.jsn ";
		private const string SQL_DELETEBYPK="delete  from yafa.jsn  where jsn.ID = ?ID";
		
		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-6-1 20:36:02		
		///</summary>		
		public Boolean AddJsn(Jsn jsn)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",jsn.UserName),
				 new MySqlParameter("?sn",jsn.Sn),
				 new MySqlParameter("?isdate",jsn.Isdate),
				 new MySqlParameter("?cuser",jsn.Cuser),
				 new MySqlParameter("?ctime",jsn.Ctime)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-6-1 20:36:02		
		///</summary>		
		public Boolean UpdateJsn(Jsn jsn)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",jsn.UserName),
				 new MySqlParameter("?sn",jsn.Sn),
				 new MySqlParameter("?isdate",jsn.Isdate),
				 new MySqlParameter("?cuser",jsn.Cuser),
				 new MySqlParameter("?ctime",jsn.Ctime),
				 new MySqlParameter("?ID",jsn.ID)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-6-1 20:36:02		
		///</summary>		
		public Boolean DeleteJsnByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2011-6-1 20:36:02		
		///</summary>		
		public Jsn GetJsnByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

			return MySqlModelHelper<Jsn>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2011-6-1 20:36:02		
		///</summary>		
		public IList<Jsn> GetMutilILJsn()
		{
			return MySqlModelHelper<Jsn>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2011-6-1 20:36:02		
		///</summary>		
		public DataTable GetMutilDTJsn()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 

        public string GetJsnByWhere(string userName, string sn, string date1, string date2)
        {
            userName = userName.Replace("'", "");
            sn = sn.Replace("'", "");

            string subSql = "";
            if (!string.IsNullOrEmpty(userName))
            {
                subSql += " and UserName like '%" + userName + "%' ";
            }
            if (!string.IsNullOrEmpty(sn))
            {
                subSql += " and sn='" + sn + "' ";
            }
            if (!string.IsNullOrEmpty(date1) || !string.IsNullOrEmpty(date2))
            {
                if (string.IsNullOrEmpty(date1)) {
                    date1 = date2;
                }if(string.IsNullOrEmpty(date2)){
                    date2 = date1;
                }
                subSql += " and date(isdate)>='" + date1 + "' and date(isdate)<='" + date2 +"'";
            }

            if (subSql == "")
            {
                return "";
            }
            string sql = "select * from jsn where 1=1 " + subSql + " order by id desc";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sql));
        }
	}
}
