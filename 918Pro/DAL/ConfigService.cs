using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
using System.Data.Common;
namespace DAL
{
	public class ConfigService
	{
		private const string SQL_INSERT="insert into yafa.config (Otype,Oval,Remark,Status)values(?Otype,?Oval,?Remark,?Status)";
		private const string SQL_UPDATE="update yafa.config set Otype=?Otype,Oval=?Oval,Remark=?Remark,Status=?Status where ID = ?ID";
		private const string SQL_SELECTBYPK="select ID from yafa.config  where config.ID = ?ID";
		private const string SQL_SELECTALL="select ID,Otype,Oval,Remark,Status from yafa.config ";
		private const string SQL_DELETEBYPK="delete  from yafa.config  where config.ID = ?ID";

        private const string SQL_INSERTCONFIG = "insert into config (Otype,Oval,Remark,Status)values(?Otype,?Oval,?Remark,?Status);SELECT LAST_INSERT_ID()";

        /// <summary>
        /// 查询方法
        /// 编写时间：2010-9-30 12:30:00 
        /// 创建者：Mickey
        /// </summary>
        /// <returns></returns>
        public MySqlDataReader GetConfigAll()
        {
            return MySqlHelper.ExecuteReader(SQL_SELECTALL, null);
        }

        /// <summary>
        /// 添加方法，返回int类型
        /// 编写时间：2010-9-29 23:10:00 
        /// 创建者：Mickey
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public int InsertConfig(Config config)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?Otype",config.Otype),
				 new MySqlParameter("?Oval",config.Oval),
                 new MySqlParameter("?Remark",config.Remark),
                 new MySqlParameter("?status",config.Status)
			};
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(SQL_INSERTCONFIG, param));
        }

        /// <summary>
        /// 修改方法，返回bool类型
        /// 编写时间：2010-9-30 16:20:00 
        /// 创建者：Mickey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="otype"></param>
        /// <param name="oval"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public bool updateConfig(string id, string otype, string oval, string remark)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?Otype",otype),
				 new MySqlParameter("?Oval",oval),
                 new MySqlParameter("?Remark",remark),
                 new MySqlParameter("?status",1),
                 new MySqlParameter("?ID",id)
            };
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-9-29 21:17:12		
		///</summary>		
		public Boolean AddConfig(Config config)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?Otype",config.Otype),
				 new MySqlParameter("?Oval",config.Oval),
				 new MySqlParameter("?Remark",config.Remark),
				 new MySqlParameter("?Status",config.Status)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-9-29 21:17:12		
		///</summary>		
		public Boolean UpdateConfig(Config config)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?Otype",config.Otype),
				 new MySqlParameter("?Oval",config.Oval),
				 new MySqlParameter("?Remark",config.Remark),
				 new MySqlParameter("?Status",config.Status),
				 new MySqlParameter("?ID",config.ID)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-9-29 21:17:12		
		///</summary>		
		public Boolean DeleteConfigByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2010-9-29 21:17:12		
		///</summary>		
		public Config GetConfigByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

			return MySqlModelHelper<Config>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2010-9-29 21:17:12		
		///</summary>		
		public IList<Config> GetMutilILConfig()
		{
			return MySqlModelHelper<Config>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2010-9-29 21:17:12		
		///</summary>		
		public DataTable GetMutilDTConfig()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 
	
    
        public bool CeliName(string Name)
        {
            string SQL_SELECTNAEM = "select Otype from yafa.config where Otype='" + Name + "'";
            return MySqlHelper.ExecuteDataTable(SQL_SELECTNAEM, null).Rows.Count > 0;
        }

        public Config GetConfigByOtype(string otype)
        {
            string sqlStr = "select ID,Otype,Oval,Remark,Status from config where Otype=?Otype";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?Otype",otype)
            };
            return MySqlModelHelper<Config>.GetSingleObjectBySql(sqlStr, param);
        }


        public IList<Config> GetPro_setup()
        {
            string sqlStr = "select ID,Otype,Oval,Remark,Status from config where ID=29 || ID=30;";


            return MySqlModelHelper<Config>.GetObjectsBySql(sqlStr);
        }




        public bool UpdataPro_setup(string id, string oval)
        {
             string saa="update yafa.config set Oval=?Oval where ID = ?ID";
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id),
				 new MySqlParameter("?Oval",oval)                
                
            };
            return MySqlHelper.ExecuteNonQuery(saa, param) > 0;
        }

    }
}
