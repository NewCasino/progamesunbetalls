using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class BetgamesService
	{
		private const string SQL_INSERT="insert into betgames (BetName,Remark,RootId,Sorts)values(?BetName,?Remark,?RootId,?Sorts)";
		private const string SQL_UPDATE="update betgames set BetName=?BetName,Remark=?Remark,RootId=?RootId,Sorts=?Sorts where BetGamesID = ?BetGamesID";
		private const string SQL_SELECTBYPK="select BetGamesID from betgames  where betgames.BetGamesID = ?BetGamesID";
		private const string SQL_SELECTALL="select BetGamesID,BetName,Remark,RootId,Sorts from betgames ";
		private const string SQL_DELETEBYPK="delete  from betgames  where betgames.BetGamesID = ?BetGamesID";
        private const string SQL_NAME_IDBY_ROOTID = "select BetGamesID,BetName from Betgames where RootId=?rootId";
        /// <summary>
        /// 通过RootId获得当前的Name和主键Id
        /// Programmer:lxb
        /// time:08-31 17:24
        /// </summary>
        /// <param name="RootId"></param>
        /// <returns></returns>
        public IList<Betgames> GetNameAndIdByRootId(int rootId)
        {
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?rootId",MySqlDbType.Int32)
            };
            param[0].Value = rootId;
            return MySqlModelHelper<Betgames>.GetObjectsBySql(SQL_NAME_IDBY_ROOTID, param);
        }
		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-8-28 22:55:41		
		///</summary>		
		public Boolean AddBetgames(Betgames betgames)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?BetName",betgames.BetName),
				 new MySqlParameter("?Remark",betgames.Remark),
				 new MySqlParameter("?RootId",betgames.RootId),
				 new MySqlParameter("?Sorts",betgames.Sorts)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-8-28 22:55:41		
		///</summary>		
		public Boolean UpdateBetgames(Betgames betgames)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?BetName",betgames.BetName),
				 new MySqlParameter("?Remark",betgames.Remark),
				 new MySqlParameter("?RootId",betgames.RootId),
				 new MySqlParameter("?Sorts",betgames.Sorts),
				 new MySqlParameter("?BetGamesID",betgames.BetGamesID)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-8-28 22:55:41		
		///</summary>		
		public Boolean DeleteBetgamesByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?BetGamesID",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2010-8-28 22:55:41		
		///</summary>		
		public Betgames GetBetgamesByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?BetGamesID",id)
			};

			return MySqlModelHelper<Betgames>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2010-8-28 22:55:41		
		///</summary>		
		public IList<Betgames> GetMutilILBetgames()
		{
			return MySqlModelHelper<Betgames>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2010-8-28 22:55:41		
		///</summary>		
		public DataTable GetMutilDTBetgames()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 
	}
}
