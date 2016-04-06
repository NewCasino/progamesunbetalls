using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class Rotedsouhf1Service
	{
		private const string SQL_INSERT="insert into yafa.rotedsouhf1 (allowchange,matchid,gameid,flag,favourite,handicap,homeodds,awayodds,homeid,awayid,time,state,MaxBet,MinBet,SingleMaxBet)values(?allowchange,?matchid,?gameid,?flag,?favourite,?handicap,?homeodds,?awayodds,?homeid,?awayid,?time,?state,?MaxBet,?MinBet,?SingleMaxBet)";
		private const string SQL_UPDATE="update yafa.rotedsouhf1 set allowchange=?allowchange,matchid=?matchid,gameid=?gameid,flag=?flag,favourite=?favourite,handicap=?handicap,homeodds=?homeodds,awayodds=?awayodds,homeid=?homeid,awayid=?awayid,time=?time,state=?state,MaxBet=?MaxBet,MinBet=?MinBet,SingleMaxBet=?SingleMaxBet where id = ?id";
		private const string SQL_SELECTBYPK="select id from yafa.rotedsouhf1  where rotedsouhf1.id = ?id";
		private const string SQL_SELECTALL="select id,allowchange,matchid,gameid,flag,cindex,favourite,handicap,homeodds,awayodds,homeid,awayid,time,state,MaxBet,MinBet,SingleMaxBet from yafa.rotedsouhf1 ";
		private const string SQL_DELETEBYPK="delete  from yafa.rotedsouhf1  where rotedsouhf1.id = ?id";
		
		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-2 10:27:03		
		///</summary>		
		public Boolean AddRotedsouhf1(Rotedsouhf1 rotedsouhf1)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?allowchange",rotedsouhf1.Allowchange),
				 new MySqlParameter("?matchid",rotedsouhf1.Matchid),
				 new MySqlParameter("?gameid",rotedsouhf1.Gameid),
				 new MySqlParameter("?flag",rotedsouhf1.Flag),
				 new MySqlParameter("?cindex",rotedsouhf1.Cindex),
				 new MySqlParameter("?favourite",rotedsouhf1.Favourite),
				 new MySqlParameter("?handicap",rotedsouhf1.Handicap),
				 new MySqlParameter("?homeodds",rotedsouhf1.Homeodds),
				 new MySqlParameter("?awayodds",rotedsouhf1.Awayodds),
				 new MySqlParameter("?homeid",rotedsouhf1.Homeid),
				 new MySqlParameter("?awayid",rotedsouhf1.Awayid),
				 new MySqlParameter("?time",rotedsouhf1.Time),
				 new MySqlParameter("?state",rotedsouhf1.State),
				 new MySqlParameter("?MaxBet",rotedsouhf1.MaxBet),
				 new MySqlParameter("?MinBet",rotedsouhf1.MinBet),
				 new MySqlParameter("?SingleMaxBet",rotedsouhf1.SingleMaxBet)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-2 10:27:03		
		///</summary>		
		public Boolean UpdateRotedsouhf1(Rotedsouhf1 rotedsouhf1)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?allowchange",rotedsouhf1.Allowchange),
				 new MySqlParameter("?matchid",rotedsouhf1.Matchid),
				 new MySqlParameter("?gameid",rotedsouhf1.Gameid),
				 new MySqlParameter("?flag",rotedsouhf1.Flag),
				 new MySqlParameter("?cindex",rotedsouhf1.Cindex),
				 new MySqlParameter("?favourite",rotedsouhf1.Favourite),
				 new MySqlParameter("?handicap",rotedsouhf1.Handicap),
				 new MySqlParameter("?homeodds",rotedsouhf1.Homeodds),
				 new MySqlParameter("?awayodds",rotedsouhf1.Awayodds),
				 new MySqlParameter("?homeid",rotedsouhf1.Homeid),
				 new MySqlParameter("?awayid",rotedsouhf1.Awayid),
				 new MySqlParameter("?time",rotedsouhf1.Time),
				 new MySqlParameter("?state",rotedsouhf1.State),
				 new MySqlParameter("?MaxBet",rotedsouhf1.MaxBet),
				 new MySqlParameter("?MinBet",rotedsouhf1.MinBet),
				 new MySqlParameter("?SingleMaxBet",rotedsouhf1.SingleMaxBet),
				 new MySqlParameter("?id",rotedsouhf1.Id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-2 10:27:03		
		///</summary>		
		public Boolean DeleteRotedsouhf1ByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2010-11-2 10:27:03		
		///</summary>		
		public Rotedsouhf1 GetRotedsouhf1ByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};

			return MySqlModelHelper<Rotedsouhf1>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2010-11-2 10:27:03		
		///</summary>		
		public IList<Rotedsouhf1> GetMutilILRotedsouhf1()
		{
			return MySqlModelHelper<Rotedsouhf1>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2010-11-2 10:27:03		
		///</summary>		
		public DataTable GetMutilDTRotedsouhf1()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 
	}
}
