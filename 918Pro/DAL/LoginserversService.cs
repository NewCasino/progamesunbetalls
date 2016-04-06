using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class LoginserversService
	{
		private const string SQL_INSERT="insert into yafa.loginservers (name,ip,status,webserverip,sessionid)values(?name,?ip,?status,?webserverip,?sessionid)";
		private const string SQL_UPDATE="update yafa.loginservers set name=?name,ip=?ip,status=?status,webserverip=?webserverip,sessionid=?sessionid where id = ?id";
		private const string SQL_SELECTBYPK="select id from yafa.loginservers  where loginservers.id = ?id";
        private const string SQL_SELECTALL = "select id,name,ip,status,webserverip,sessionid from yafa.loginservers order by id";
		private const string SQL_DELETEBYPK="delete  from yafa.loginservers  where loginservers.id = ?id";


        private const string SQL_UPDATESTATUS = "update yafa.loginservers set status=?status where id = ?id";

		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-2 13:38:52		
		///</summary>		
		public Boolean AddLoginservers(Loginservers loginservers)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?name",loginservers.Name),
				 new MySqlParameter("?ip",loginservers.Ip),
				 new MySqlParameter("?status",loginservers.Status),
				 new MySqlParameter("?webserverip",loginservers.Webserverip),
				 new MySqlParameter("?sessionid",loginservers.Sessionid)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-2 13:38:52		
		///</summary>		
		public Boolean UpdateLoginservers(Loginservers loginservers)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?name",loginservers.Name),
				 new MySqlParameter("?ip",loginservers.Ip),
				 new MySqlParameter("?status",loginservers.Status),
				 new MySqlParameter("?webserverip",loginservers.Webserverip),
				 new MySqlParameter("?sessionid",loginservers.Sessionid),
				 new MySqlParameter("?id",loginservers.Id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-2 13:38:52		
		///</summary>		
		public Boolean DeleteLoginserversByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2010-11-2 13:38:52		
		///</summary>		
		public Loginservers GetLoginserversByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};

			return MySqlModelHelper<Loginservers>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2010-11-2 13:38:52		
		///</summary>		
		public IList<Loginservers> GetMutilILLoginservers()
		{
			return MySqlModelHelper<Loginservers>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2010-11-2 13:38:52		
		///</summary>		
		public DataTable GetMutilDTLoginservers()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 
	
        public System.Data.Common.DbDataReader GetloginserversAll()
        {
            return MySqlHelper.ExecuteReader(SQL_SELECTALL, null);
        }

        public bool UpdateLoginServiceStatus(int Status, int ID)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?status",Status),
				 new MySqlParameter("?id",ID)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATESTATUS, param) > 0;
        }
        public static string GetRegIP(string regIP)
        {
            string sql = "select username,regip,RegistrationTime from user where regip='" + regIP + "'  group by username order by id desc";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sql));
        }
    }
}
