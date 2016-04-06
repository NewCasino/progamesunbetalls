using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class AgentserversService
	{
		private const string SQL_INSERT="insert into yafa.agentservers (ip,port,enable)values(?ip,?port,?enable)";
		private const string SQL_UPDATE="update yafa.agentservers set ip=?ip,port=?port,enable=?enable where id = ?id";
		private const string SQL_SELECTBYPK="select ip,port,enable,id from yafa.agentservers  where agentservers.id = ?id";
		private const string SQL_SELECTALL="select ip,port,enable,id from yafa.agentservers ";
		private const string SQL_DELETEBYPK="delete  from yafa.agentservers  where agentservers.id = ?id";
		
		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-5-12 20:18:10		
		///</summary>		
		public Boolean AddAgentservers(Agentservers agentservers)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ip",agentservers.Ip),
				 new MySqlParameter("?port",agentservers.Port),
				 new MySqlParameter("?enable",agentservers.Enable)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-5-12 20:18:10		
		///</summary>		
		public Boolean UpdateAgentservers(Agentservers agentservers)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ip",agentservers.Ip),
				 new MySqlParameter("?port",agentservers.Port),
				 new MySqlParameter("?enable",agentservers.Enable),
				 new MySqlParameter("?id",agentservers.Id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-5-12 20:18:10		
		///</summary>		
		public Boolean DeleteAgentserversByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2011-5-12 20:18:10		
		///</summary>		
		public Agentservers GetAgentserversByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};

			return MySqlModelHelper<Agentservers>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2011-5-12 20:18:10		
		///</summary>		
		public IList<Agentservers> GetMutilILAgentservers()
		{
			return MySqlModelHelper<Agentservers>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2011-5-12 20:18:10		
		///</summary>		
		public DataTable GetMutilDTAgentservers()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 
	}
}
