using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class ServerService
	{
		private const string SQL_INSERT="insert into servers.server (ServerName,ip1,ip2,ip3,SubDomain,OnlineNumber,Area,status,UpdateDate,AddDate,ReMark)values(?ServerName,?ip1,?ip2,?ip3,?SubDomain,?OnlineNumber,?Area,?status,?UpdateDate,?AddDate,?ReMark)";
		private const string SQL_UPDATE="update servers.server set ServerName=?ServerName,ip1=?ip1,ip2=?ip2,ip3=?ip3,SubDomain=?SubDomain,OnlineNumber=?OnlineNumber,Area=?Area,status=?status,UpdateDate=?UpdateDate,AddDate=?AddDate,ReMark=?ReMark where ID = ?ID";
		private const string SQL_SELECTBYPK="select ID from servers.server  where server.ID = ?ID";
		private const string SQL_SELECTALL="select ID,ServerName,ip1,ip2,ip3,SubDomain,OnlineNumber,Area,Status,UpdateDate,AddDate,ReMark from servers.server ";
		private const string SQL_DELETEBYPK="delete  from servers.server  where server.ID = ?ID";


        private const string SQL_BYLOGIN = SQL_SELECTALL + " where SubDomain=?SubDomain ";
        private const string SQL_SELECTGUID = "select SubDomain from servers.server where server.SubDomain=?SubDomain";
        private const string SQL_UPDATESERVER = "update servers.server set ServerName=?ServerName,ip1=?ip1,ip2=?ip2,ip3=?ip3,Area=?Area,status=?status,UpdateDate=?UpdateDate,ReMark=?ReMark where ID = ?ID";

        /// <summary>
        /// 查询二级域名
        /// 编写时间: 2010-10-11 17:10
        /// 创建者：Mickey
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public bool SelectGuId(string guid)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?SubDomain",guid)
            };
            return MySqlHelper.ExecuteDataTable(SQL_SELECTGUID, param).Rows.Count>0;
        }

        /// <summary>
        /// 获取所有服务器
        /// 编写时间: 2010-10-10 14:00
        /// 创建者：Mickey
        /// </summary>
        /// <returns></returns>
        public System.Data.Common.DbDataReader GetServerAll()
        {
            return MySqlHelper.ExecuteReader(SQL_SELECTALL, null);
        }

        /// <summary>
        /// 修改服务器配置
        /// 编写时间: 2010-10-11 21:00
        /// 创建者：Mickey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="serverName"></param>
        /// <param name="ip1"></param>
        /// <param name="ip2"></param>
        /// <param name="ip3"></param>
        /// <param name="area"></param>
        /// <param name="status"></param>
        /// <param name="time"></param>
        /// <param name="reMark"></param>
        /// <returns></returns>
        public bool updateServer(int id, string serverName, string ip1, string ip2, string ip3, string area, string status,DateTime time, string reMark)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ServerName",serverName),
				 new MySqlParameter("?ip1",ip1),
                 new MySqlParameter("?ip2",ip2),
                 new MySqlParameter("?ip3",ip3),
                 new MySqlParameter("?Area",area),
                 new MySqlParameter("?Status",status),
                 new MySqlParameter("?ReMark",reMark),
                 new MySqlParameter("?UpdateDate",time),
                 new MySqlParameter("?ID",id)
            };
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATESERVER, param) > 0;
        }

		#region 常用方法

        /// <summary>
        /// 新增服务器
        /// 编写时间: 2010-12-11 22:00
        /// 创建者：Mickey 
        /// </summary>
        /// <param name="server"></param>
        /// <returns></returns>
		public Boolean AddServer(Server server)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ServerName",server.ServerName),
				 new MySqlParameter("?ip1",server.Ip1),
				 new MySqlParameter("?ip2",server.Ip2),
				 new MySqlParameter("?ip3",server.Ip3),
				 new MySqlParameter("?SubDomain",server.SubDomain),
				 new MySqlParameter("?OnlineNumber",server.OnlineNumber),
				 new MySqlParameter("?Area",server.Area),
				 new MySqlParameter("?status",server.Status),
				 new MySqlParameter("?UpdateDate",server.UpdateDate),
				 new MySqlParameter("?AddDate",server.AddDate),
				 new MySqlParameter("?ReMark",server.ReMark)
			};
			return MySqlHelper1.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-10-10 21:28:26		
		///</summary>		
		public Boolean UpdateServer(Server server)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ServerName",server.ServerName),
				 new MySqlParameter("?ip1",server.Ip1),
				 new MySqlParameter("?ip2",server.Ip2),
				 new MySqlParameter("?ip3",server.Ip3),
				 new MySqlParameter("?SubDomain",server.SubDomain),
				 new MySqlParameter("?OnlineNumber",server.OnlineNumber),
				 new MySqlParameter("?Area",server.Area),
				 new MySqlParameter("?status",server.Status),
				 new MySqlParameter("?UpdateDate",server.UpdateDate),
				 new MySqlParameter("?AddDate",server.AddDate),
				 new MySqlParameter("?ReMark",server.ReMark),
				 new MySqlParameter("?ID",server.ID)
			};
			return MySqlHelper1.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-10-10 21:28:26		
		///</summary>		
		public Boolean DeleteServerByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
			return MySqlHelper1.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2010-10-10 21:28:26		
		///</summary>		
		public Server GetServerByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

			return MySqlModelHelper1<Server>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2010-10-10 21:28:26		
		///</summary>		
		public IList<Server> GetMutilILServer()
		{
			return MySqlModelHelper1<Server>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2010-10-10 21:28:26		
		///</summary>		
		public DataTable GetMutilDTServer()
		{
			 return MySqlHelper1.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 
	
    
        public bool CeliName(string Name)
        {
            string SQL_SELECTNAEM = "select ServerName from servers.server where ServerName='" + Name + "'";
            return MySqlHelper.ExecuteDataTable(SQL_SELECTNAEM, null).Rows.Count > 0;
        }
    }
}
