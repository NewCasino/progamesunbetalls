using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class CasinologinserversService
	{
        private const string SQL_INSERT = "insert into yafa.casinologinservers (webserverid,casino,webserverip,loginserverip,status)values(?webserverid,?casino,?webserverip,?loginserverip,?status)";
        private const string SQL_UPDATE = "update yafa.casinologinservers set webserverid=?webserverid, casino=?casino,webserverip=?webserverip,loginserverip=?loginserverip,status=?status where id = ?id";
		private const string SQL_SELECTBYPK="select id from yafa.casinologinservers  where casinologinservers.id = ?id";
		private const string SQL_SELECTALL="select id,webserverid,casino,webserverip,loginserverip,status from yafa.casinologinservers order by id desc";
		private const string SQL_DELETEBYPK="delete  from yafa.casinologinservers  where casinologinservers.id = ?id";
		
		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-1-23 1:00:24		
		///</summary>		
		public Boolean AddCasinologinservers(Casinologinservers casinologinservers)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?webserverid",casinologinservers.Webserverid),
				 new MySqlParameter("?casino",casinologinservers.Casino),
				 new MySqlParameter("?webserverip",casinologinservers.Webserverip),
				 new MySqlParameter("?loginserverip",casinologinservers.Loginserverip),
				 new MySqlParameter("?status",casinologinservers.Status)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-1-23 1:00:24		
		///</summary>		
		public Boolean UpdateCasinologinservers(Casinologinservers casinologinservers)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?webserverid",casinologinservers.Webserverid),
				 new MySqlParameter("?casino",casinologinservers.Casino),
				 new MySqlParameter("?webserverip",casinologinservers.Webserverip),
				 new MySqlParameter("?loginserverip",casinologinservers.Loginserverip),
				 new MySqlParameter("?status",casinologinservers.Status),
				 new MySqlParameter("?id",casinologinservers.Id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-1-23 1:00:24		
		///</summary>		
		public Boolean DeleteCasinologinserversByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2011-1-23 1:00:24		
		///</summary>		
		public Casinologinservers GetCasinologinserversByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};

			return MySqlModelHelper<Casinologinservers>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2011-1-23 1:00:24		
		///</summary>		
		public IList<Casinologinservers> GetMutilILCasinologinservers()
		{
			return MySqlModelHelper<Casinologinservers>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2011-1-23 1:00:24		
		///</summary>		
		public DataTable GetMutilDTCasinologinservers()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 
	}
}
