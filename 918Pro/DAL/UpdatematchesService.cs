using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class UpdatematchesService
	{
		private const string SQL_INSERT="insert into yafa.updatematches (type1,content,updatetime)values(?type1,?content,now())";
		private const string SQL_UPDATE="update yafa.updatematches set type1=?type1,content=?content,updatetime=?updatetime where id = ?id";
		private const string SQL_SELECTBYPK="select id from yafa.updatematches  where updatematches.id = ?id";
		private const string SQL_SELECTALL="select id,type1,content,updatetime from yafa.updatematches ";
		private const string SQL_DELETEBYPK="delete  from yafa.updatematches  where updatematches.id = ?id";
		
		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-1-9 20:45:38		
		///</summary>		
		public Boolean AddUpdatematches(Updatematches updatematches)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?type1",updatematches.Type1),
				 new MySqlParameter("?content",updatematches.Content)
				 
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-1-9 20:45:38		
		///</summary>		
		public Boolean UpdateUpdatematches(Updatematches updatematches)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?type1",updatematches.Type1),
				 new MySqlParameter("?content",updatematches.Content),
				 new MySqlParameter("?updatetime",updatematches.Updatetime),
				 new MySqlParameter("?id",updatematches.Id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-1-9 20:45:38		
		///</summary>		
		public Boolean DeleteUpdatematchesByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2011-1-9 20:45:38		
		///</summary>		
		public Updatematches GetUpdatematchesByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};

			return MySqlModelHelper<Updatematches>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2011-1-9 20:45:38		
		///</summary>		
		public IList<Updatematches> GetMutilILUpdatematches()
		{
			return MySqlModelHelper<Updatematches>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2011-1-9 20:45:38		
		///</summary>		
		public DataTable GetMutilDTUpdatematches()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 
	}
}
