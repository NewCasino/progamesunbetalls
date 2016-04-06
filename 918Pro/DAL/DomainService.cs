using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class DomainService
	{
		private const string SQL_INSERT="insert into servers.domain (DomainName,ismain,status,UpdateDate,AddDate)values(?DomainName,?ismain,?status,?UpdateDate,?AddDate)";
		private const string SQL_UPDATE="update servers.domain set DomainName=?DomainName,ismain=?ismain,status=?status,UpdateDate=?UpdateDate where ID = ?ID";
		private const string SQL_SELECTBYPK="select ID from servers.domain  where domain.ID = ?ID";
		private const string SQL_SELECTALL="select ID,DomainName,ismain,status,UpdateDate,AddDate from servers.domain ";
		private const string SQL_DELETEBYPK="delete  from servers.domain  where domain.ID = ?ID";

        private const string SQL_INSERTDOMAIN = "insert into servers.domain (DomainName,ismain,status,AddDate)values(?DomainName,?ismain,?status,?AddDate);SELECT LAST_INSERT_ID()";

        /// <summary>
        /// 获取所有域名网址
        /// 编写时间: 2010-12-10 14:00
        /// 创建者：Mickey
        /// </summary>
        /// <returns></returns>
        public System.Data.Common.DbDataReader GetDomainAll()
        {
            return MySqlHelper.ExecuteReader(SQL_SELECTALL, null);
        }

        /// <summary>
        /// 新增域名网址
        /// 编写时间: 2010-12-10 14:30
        /// 创建者：Mickey
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public int InsertDomain(Domain domain)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?DomainName",domain.DomainName),
				 new MySqlParameter("?ismain",domain.Ismain),
                 new MySqlParameter("?status",domain.Status),
                 new MySqlParameter("?AddDate",domain.AddDate)
			};
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(SQL_INSERTDOMAIN, param));
        }

        /// <summary>
        /// 修改网址域名
        /// 编写时间: 2010-12-10 15:00
        /// 创建者：Mickey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="domainName"></param>
        /// <param name="ismain"></param>
        /// <param name="status"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public bool updateConfig(string id, string domainName, string ismain, string status, DateTime time)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?DomainName",domainName),
				 new MySqlParameter("?ismain",ismain),
                 new MySqlParameter("?status",status),
                 new MySqlParameter("?UpdateDate",time),
                 new MySqlParameter("?ID",id)
            };
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-10-10 20:16:28		
		///</summary>		
		public Boolean AddDomain(Domain domain)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?DomainName",domain.DomainName),
				 new MySqlParameter("?ismain",domain.Ismain),
				 new MySqlParameter("?status",domain.Status),
				 new MySqlParameter("?UpdateDate",domain.UpdateDate),
				 new MySqlParameter("?AddDate",domain.AddDate)
			};
			return MySqlHelper1.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-10-10 20:16:28		
		///</summary>		
		public Boolean UpdateDomain(Domain domain)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?DomainName",domain.DomainName),
				 new MySqlParameter("?ismain",domain.Ismain),
				 new MySqlParameter("?status",domain.Status),
				 new MySqlParameter("?UpdateDate",domain.UpdateDate),
				 new MySqlParameter("?AddDate",domain.AddDate),
				 new MySqlParameter("?ID",domain.ID)
			};
			return MySqlHelper1.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-10-10 20:16:28		
		///</summary>		
		public Boolean DeleteDomainByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
			return MySqlHelper1.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2010-10-10 20:16:28		
		///</summary>		
		public Domain GetDomainByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

			return MySqlModelHelper1<Domain>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2010-10-10 20:16:28		
		///</summary>		
		public IList<Domain> GetMutilILDomain()
		{
			return MySqlModelHelper1<Domain>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2010-10-10 20:16:28		
		///</summary>		
		public DataTable GetMutilDTDomain()
		{
			 return MySqlHelper1.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 
	
    
        public bool CeliName(string Name)
        {
            string SQL_SELECTNAEM = "select DomainName from servers.domain where DomainName='" + Name + "'";
            return MySqlHelper.ExecuteDataTable(SQL_SELECTNAEM, null).Rows.Count > 0;
        }
    }
}
