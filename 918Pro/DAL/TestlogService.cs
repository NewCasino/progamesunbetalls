using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class TestlogService
	{
		private const string SQL_INSERT="insert into yafa.testlog (userid,begintime,endtime,lengths,times)values(?userid,?begintime,?endtime,?lengths,?times)";
		private const string SQL_UPDATE="update yafa.testlog set userid=?userid,begintime=?begintime,endtime=?endtime,lengths=?lengths,times=?times where id = ?id";
		private const string SQL_SELECTBYPK="select id from yafa.testlog  where testlog.id = ?id";
		private const string SQL_SELECTALL="select id,userid,begintime,endtime,lengths,times from yafa.testlog ";
		private const string SQL_DELETEBYPK="delete  from yafa.testlog  where testlog.id = ?id";
		
		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-7-9 19:58:32		
		///</summary>		
		public Boolean AddTestlog(Testlog testlog)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?userid",testlog.Userid),
				 new MySqlParameter("?begintime",testlog.Begintime),
				 new MySqlParameter("?endtime",testlog.Endtime),
				 new MySqlParameter("?lengths",testlog.Lengths),
				 new MySqlParameter("?times",testlog.Times)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-7-9 19:58:32		
		///</summary>		
		public Boolean UpdateTestlog(Testlog testlog)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?userid",testlog.Userid),
				 new MySqlParameter("?begintime",testlog.Begintime),
				 new MySqlParameter("?endtime",testlog.Endtime),
				 new MySqlParameter("?lengths",testlog.Lengths),
				 new MySqlParameter("?times",testlog.Times),
				 new MySqlParameter("?id",testlog.Id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-7-9 19:58:32		
		///</summary>		
		public Boolean DeleteTestlogByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2011-7-9 19:58:32		
		///</summary>		
		public Testlog GetTestlogByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};

			return MySqlModelHelper<Testlog>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2011-7-9 19:58:32		
		///</summary>		
		public IList<Testlog> GetMutilILTestlog()
		{
			return MySqlModelHelper<Testlog>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2011-7-9 19:58:32		
		///</summary>		
		public DataTable GetMutilDTTestlog()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 

        public string GetTestlogByWhere(string userid)
        {
            userid = userid.Replace("'", "");

            string sql = "";
            string subSql = "";
            if (!string.IsNullOrEmpty(userid))
            {
                subSql += " and userid='" + userid + "' ";
            }
            if (subSql == "")
            {
                return "";
            }
            sql = "select * from testlog where 1=1 " + subSql + " order by id desc";
            string aa = ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sql));
            return aa == "]" ? "" : aa;
        }

        public bool DeleTestlog()
        {
            string sql = "delete from testlog";
            return MySqlHelper.ExecuteNonQuery(sql) > 0;
        }

	}
}
