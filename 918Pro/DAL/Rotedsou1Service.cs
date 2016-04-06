using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class Rotedsou1Service
	{
		private const string SQL_INSERT="insert into yafa.rotedsou1 (allowchange,matchid,gameid,flag,favourite,handicap,homeodds,awayodds,homeid,awayid,time,state,MaxBet,MinBet,SingleMaxBet)values(?allowchange,?matchid,?gameid,?flag,?favourite,?handicap,?homeodds,?awayodds,?homeid,?awayid,?time,?state,?MaxBet,?MinBet,?SingleMaxBet)";
		private const string SQL_UPDATE="update yafa.rotedsou1 set allowchange=?allowchange,matchid=?matchid,gameid=?gameid,flag=?flag,favourite=?favourite,handicap=?handicap,homeodds=?homeodds,awayodds=?awayodds,homeid=?homeid,awayid=?awayid,time=?time,state=?state,MaxBet=?MaxBet,MinBet=?MinBet,SingleMaxBet=?SingleMaxBet where id = ?id";
		private const string SQL_SELECTBYPK="select id from yafa.rotedsou1  where rotedsou1.id = ?id";
		private const string SQL_SELECTALL="select id,allowchange,matchid,gameid,flag,cindex,favourite,handicap,homeodds,awayodds,homeid,awayid,time,state,MaxBet,MinBet,SingleMaxBet from yafa.rotedsou1 ";
		private const string SQL_DELETEBYPK="delete  from yafa.rotedsou1  where rotedsou1.id = ?id";
		
		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-2 10:27:02		
		///</summary>		
		public Boolean AddRotedsou1(Rotedsou1 rotedsou1)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?allowchange",rotedsou1.Allowchange),
				 new MySqlParameter("?matchid",rotedsou1.Matchid),
				 new MySqlParameter("?gameid",rotedsou1.Gameid),
				 new MySqlParameter("?flag",rotedsou1.Flag),
				 new MySqlParameter("?cindex",rotedsou1.Cindex),
				 new MySqlParameter("?favourite",rotedsou1.Favourite),
				 new MySqlParameter("?handicap",rotedsou1.Handicap),
				 new MySqlParameter("?homeodds",rotedsou1.Homeodds),
				 new MySqlParameter("?awayodds",rotedsou1.Awayodds),
				 new MySqlParameter("?homeid",rotedsou1.Homeid),
				 new MySqlParameter("?awayid",rotedsou1.Awayid),
				 new MySqlParameter("?time",rotedsou1.Time),
				 new MySqlParameter("?state",rotedsou1.State),
				 new MySqlParameter("?MaxBet",rotedsou1.MaxBet),
				 new MySqlParameter("?MinBet",rotedsou1.MinBet),
				 new MySqlParameter("?SingleMaxBet",rotedsou1.SingleMaxBet)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-2 10:27:02		
		///</summary>		
		public Boolean UpdateRotedsou1(Rotedsou1 rotedsou1)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?allowchange",rotedsou1.Allowchange),
				 new MySqlParameter("?matchid",rotedsou1.Matchid),
				 new MySqlParameter("?gameid",rotedsou1.Gameid),
				 new MySqlParameter("?flag",rotedsou1.Flag),
				 new MySqlParameter("?cindex",rotedsou1.Cindex),
				 new MySqlParameter("?favourite",rotedsou1.Favourite),
				 new MySqlParameter("?handicap",rotedsou1.Handicap),
				 new MySqlParameter("?homeodds",rotedsou1.Homeodds),
				 new MySqlParameter("?awayodds",rotedsou1.Awayodds),
				 new MySqlParameter("?homeid",rotedsou1.Homeid),
				 new MySqlParameter("?awayid",rotedsou1.Awayid),
				 new MySqlParameter("?time",rotedsou1.Time),
				 new MySqlParameter("?state",rotedsou1.State),
				 new MySqlParameter("?MaxBet",rotedsou1.MaxBet),
				 new MySqlParameter("?MinBet",rotedsou1.MinBet),
				 new MySqlParameter("?SingleMaxBet",rotedsou1.SingleMaxBet),
				 new MySqlParameter("?id",rotedsou1.Id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-2 10:27:02		
		///</summary>		
		public Boolean DeleteRotedsou1ByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2010-11-2 10:27:02		
		///</summary>		
		public Rotedsou1 GetRotedsou1ByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};

			return MySqlModelHelper<Rotedsou1>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2010-11-2 10:27:02		
		///</summary>		
		public IList<Rotedsou1> GetMutilILRotedsou1()
		{
			return MySqlModelHelper<Rotedsou1>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2010-11-2 10:27:02		
		///</summary>		
		public DataTable GetMutilDTRotedsou1()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 
	}
}
