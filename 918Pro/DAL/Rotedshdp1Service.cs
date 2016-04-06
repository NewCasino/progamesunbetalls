using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class Rotedshdp1Service
	{
		private const string SQL_INSERT="insert into yafa.rotedshdp1 (allowchange,matchid,gameid,flag,favourite,handicap,homeodds,awayodds,homeid,awayid,time,state,MinBet,MaxBet,SingleMaxBet)values(?allowchange,?matchid,?gameid,?flag,?favourite,?handicap,?homeodds,?awayodds,?homeid,?awayid,?time,?state,?MinBet,?MaxBet,?SingleMaxBet)";
		private const string SQL_UPDATE="update yafa.rotedshdp1 set allowchange=?allowchange,matchid=?matchid,gameid=?gameid,flag=?flag,favourite=?favourite,handicap=?handicap,homeodds=?homeodds,awayodds=?awayodds,homeid=?homeid,awayid=?awayid,time=?time,state=?state,MinBet=?MinBet,MaxBet=?MaxBet,SingleMaxBet=?SingleMaxBet where id = ?id";
		private const string SQL_SELECTBYPK="select id from yafa.rotedshdp1  where rotedshdp1.id = ?id";
		private const string SQL_SELECTALL="select id,allowchange,matchid,gameid,flag,cindex,favourite,handicap,homeodds,awayodds,homeid,awayid,time,state,MinBet,MaxBet,SingleMaxBet from yafa.rotedshdp1 ";
		private const string SQL_DELETEBYPK="delete  from yafa.rotedshdp1  where rotedshdp1.id = ?id";
		
		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-2 10:27:01		
		///</summary>		
		public Boolean AddRotedshdp1(Rotedshdp1 rotedshdp1)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?allowchange",rotedshdp1.Allowchange),
				 new MySqlParameter("?matchid",rotedshdp1.Matchid),
				 new MySqlParameter("?gameid",rotedshdp1.Gameid),
				 new MySqlParameter("?flag",rotedshdp1.Flag),
				 new MySqlParameter("?cindex",rotedshdp1.Cindex),
				 new MySqlParameter("?favourite",rotedshdp1.Favourite),
				 new MySqlParameter("?handicap",rotedshdp1.Handicap),
				 new MySqlParameter("?homeodds",rotedshdp1.Homeodds),
				 new MySqlParameter("?awayodds",rotedshdp1.Awayodds),
				 new MySqlParameter("?homeid",rotedshdp1.Homeid),
				 new MySqlParameter("?awayid",rotedshdp1.Awayid),
				 new MySqlParameter("?time",rotedshdp1.Time),
				 new MySqlParameter("?state",rotedshdp1.State),
				 new MySqlParameter("?MinBet",rotedshdp1.MinBet),
				 new MySqlParameter("?MaxBet",rotedshdp1.MaxBet),
				 new MySqlParameter("?SingleMaxBet",rotedshdp1.SingleMaxBet)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-2 10:27:01		
		///</summary>		
		public Boolean UpdateRotedshdp1(Rotedshdp1 rotedshdp1)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?allowchange",rotedshdp1.Allowchange),
				 new MySqlParameter("?matchid",rotedshdp1.Matchid),
				 new MySqlParameter("?gameid",rotedshdp1.Gameid),
				 new MySqlParameter("?flag",rotedshdp1.Flag),
				 new MySqlParameter("?cindex",rotedshdp1.Cindex),
				 new MySqlParameter("?favourite",rotedshdp1.Favourite),
				 new MySqlParameter("?handicap",rotedshdp1.Handicap),
				 new MySqlParameter("?homeodds",rotedshdp1.Homeodds),
				 new MySqlParameter("?awayodds",rotedshdp1.Awayodds),
				 new MySqlParameter("?homeid",rotedshdp1.Homeid),
				 new MySqlParameter("?awayid",rotedshdp1.Awayid),
				 new MySqlParameter("?time",rotedshdp1.Time),
				 new MySqlParameter("?state",rotedshdp1.State),
				 new MySqlParameter("?MinBet",rotedshdp1.MinBet),
				 new MySqlParameter("?MaxBet",rotedshdp1.MaxBet),
				 new MySqlParameter("?SingleMaxBet",rotedshdp1.SingleMaxBet),
				 new MySqlParameter("?id",rotedshdp1.Id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-2 10:27:01		
		///</summary>		
		public Boolean DeleteRotedshdp1ByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2010-11-2 10:27:01		
		///</summary>		
		public Rotedshdp1 GetRotedshdp1ByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};

			return MySqlModelHelper<Rotedshdp1>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2010-11-2 10:27:01		
		///</summary>		
		public IList<Rotedshdp1> GetMutilILRotedshdp1()
		{
			return MySqlModelHelper<Rotedshdp1>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2010-11-2 10:27:01		
		///</summary>		
		public DataTable GetMutilDTRotedshdp1()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 
	}
}
