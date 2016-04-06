using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class ReasonService
	{
		private const string SQL_INSERT="insert into yafa.reason (title,remark)values(?title,?remark)";
		private const string SQL_UPDATE="update yafa.reason set title=?title,remark=?remark where ID = ?ID";
		private const string SQL_SELECTBYPK="select ID from yafa.reason  where reason.ID = ?ID";
		private const string SQL_SELECTALL="select ID,title,remark from yafa.reason ";
		private const string SQL_DELETEBYPK="delete  from yafa.reason  where reason.ID = ?ID";
        private const string SQL_SELECTMAXINFO = "select * from yafa.reason where yafa.reason.ID = (select max(ID) from reason)";
        private const string SQL_INSERTREASON = "insert into yafa.reason (title,remark)values(?title,?remark);SELECT LAST_INSERT_ID();";
		
		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-9-26 12:11:00		
		///</summary>		
		public Boolean AddReason(Reason reason)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?title",reason.Title),
				 new MySqlParameter("?remark",reason.Remark)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-9-26 12:11:00		
		///</summary>		
		public Boolean UpdateReason(Reason reason)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?title",reason.Title),
				 new MySqlParameter("?remark",reason.Remark),
				 new MySqlParameter("?ID",reason.ID)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-9-26 12:11:00		
		///</summary>		
		public Boolean DeleteReasonByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2010-9-26 12:11:00		
		///</summary>		
		public Reason GetReasonByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

			return MySqlModelHelper<Reason>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2010-9-26 12:11:00		
		///</summary>		
		public IList<Reason> GetMutilILReason()
		{
			return MySqlModelHelper<Reason>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2010-9-26 12:11:00		
		///</summary>		
		public DataTable GetMutilDTReason()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}
        
        /// <summary>
        /// descripton:获得ID值最大的一条数据 返回一个实体对象
        /// create date 2010-09-26 21：47
        /// create by 肖军文
        /// </summary>
        /// <returns></returns>
        public  Reason GetReasonByMaxID() {
            return MySqlModelHelper<Reason>.GetSingleObjectBySql(SQL_SELECTMAXINFO);
        }

		#endregion 
	

        /// <summary>
        /// create by 肖军文
        /// create date 2010-09-30
        /// description 添加信息
        /// </summary>
        /// <param name="reason"></param>
        /// <returns></returns>
        public int AddReasonInfo(Reason reason)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?title",reason.Title),
				 new MySqlParameter("?remark",reason.Remark)
			};
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(SQL_INSERTREASON, param));
        }
    }
}
