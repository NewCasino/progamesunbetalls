using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class BetlogService
	{
		private const string SQL_INSERT="insert into yafa.betlog (userid,time,t1,t2,t3,t4,t5,t6,t7,casino,gametype)values(?userid,?time,?t1,?t2,?t3,?t4,?t5,?t6,?t7,?casino,?gametype)";
		private const string SQL_UPDATE="update yafa.betlog set userid=?userid,time=?time,t1=?t1,t2=?t2,t3=?t3,t4=?t4,t5=?t5,t6=?t6,t7=?t7,casino=?casino,gametype=?gametype where id = ?id";
		private const string SQL_SELECTBYPK="select id from yafa.betlog  where betlog.id = ?id";
		private const string SQL_SELECTALL="select id,userid,time,t1,t2,t3,t4,t5,t6,t7,casino,gametype from yafa.betlog ";
		private const string SQL_DELETEBYPK="delete  from yafa.betlog  where betlog.id = ?id";
		
		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-7-9 19:56:58		
		///</summary>		
		public Boolean AddBetlog(Betlog betlog)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?userid",betlog.Userid),
				 new MySqlParameter("?time",betlog.Time),
				 new MySqlParameter("?t1",betlog.T1),
				 new MySqlParameter("?t2",betlog.T2),
				 new MySqlParameter("?t3",betlog.T3),
				 new MySqlParameter("?t4",betlog.T4),
				 new MySqlParameter("?t5",betlog.T5),
				 new MySqlParameter("?t6",betlog.T6),
				 new MySqlParameter("?t7",betlog.T7),
				 new MySqlParameter("?casino",betlog.Casino),
				 new MySqlParameter("?gametype",betlog.Gametype)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-7-9 19:56:58		
		///</summary>		
		public Boolean UpdateBetlog(Betlog betlog)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?userid",betlog.Userid),
				 new MySqlParameter("?time",betlog.Time),
				 new MySqlParameter("?t1",betlog.T1),
				 new MySqlParameter("?t2",betlog.T2),
				 new MySqlParameter("?t3",betlog.T3),
				 new MySqlParameter("?t4",betlog.T4),
				 new MySqlParameter("?t5",betlog.T5),
				 new MySqlParameter("?t6",betlog.T6),
				 new MySqlParameter("?t7",betlog.T7),
				 new MySqlParameter("?casino",betlog.Casino),
				 new MySqlParameter("?gametype",betlog.Gametype),
				 new MySqlParameter("?id",betlog.Id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-7-9 19:56:58		
		///</summary>		
		public Boolean DeleteBetlogByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2011-7-9 19:56:58		
		///</summary>		
		public Betlog GetBetlogByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};

			return MySqlModelHelper<Betlog>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2011-7-9 19:56:58		
		///</summary>		
		public IList<Betlog> GetMutilILBetlog()
		{
			return MySqlModelHelper<Betlog>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2011-7-9 19:56:58		
		///</summary>		
		public DataTable GetMutilDTBetlog()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 

        public string GetBetlogByWhere(string userid, string casino, string gametype)
        {
            userid = userid.Replace("'", "");
            casino = casino.Replace("'", "");
            gametype = gametype.Replace("'", "");

            string sql = "";
            string subSql = "";
            if (!string.IsNullOrEmpty(userid))
            {
                subSql += " and userid='" + userid + "' ";
            }
            if (!string.IsNullOrEmpty(casino))
            {
                subSql += " and casino='" + casino + "' ";
            }
            if (!string.IsNullOrEmpty(gametype))
            {
                subSql += " and gametype='" + gametype + "' ";
            }
            if (subSql == "")
            {
                return "";
            }
            sql = "select * from betlog where 1=1 " + subSql + " order by id desc";
            string re = ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sql));
            if (re == "]")
            {
                re = "";
            }
            return re;
        }

        public bool DeleBetlog()
        {
            string sql = "delete from betlog";
            return MySqlHelper.ExecuteNonQuery(sql) > 0;
        }

	}
}
