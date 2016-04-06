using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class Rotedshdphf1Service
	{
		private const string SQL_INSERT="insert into yafa.rotedshdphf1 (allowchange,matchid,gameid,flag,favourite,handicap,homeodds,awayodds,homeid,awayid,time,state,MaxBet,MinBet,SingleMaxBet)values(?allowchange,?matchid,?gameid,?flag,?favourite,?handicap,?homeodds,?awayodds,?homeid,?awayid,?time,?state,?MaxBet,?MinBet,?SingleMaxBet)";
		private const string SQL_UPDATE="update yafa.rotedshdphf1 set allowchange=?allowchange,matchid=?matchid,gameid=?gameid,flag=?flag,favourite=?favourite,handicap=?handicap,homeodds=?homeodds,awayodds=?awayodds,homeid=?homeid,awayid=?awayid,time=?time,state=?state,MaxBet=?MaxBet,MinBet=?MinBet,SingleMaxBet=?SingleMaxBet where id = ?id";
		private const string SQL_SELECTBYPK="select id from yafa.rotedshdphf1  where rotedshdphf1.id = ?id";
		private const string SQL_SELECTALL="select id,allowchange,matchid,gameid,flag,cindex,favourite,handicap,homeodds,awayodds,homeid,awayid,time,state,MaxBet,MinBet,SingleMaxBet from yafa.rotedshdphf1 ";
		private const string SQL_DELETEBYPK="delete  from yafa.rotedshdphf1  where rotedshdphf1.id = ?id";
		
		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-2 10:27:02		
		///</summary>		
		public Boolean AddRotedshdphf1(Rotedshdphf1 rotedshdphf1)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?allowchange",rotedshdphf1.Allowchange),
				 new MySqlParameter("?matchid",rotedshdphf1.Matchid),
				 new MySqlParameter("?gameid",rotedshdphf1.Gameid),
				 new MySqlParameter("?flag",rotedshdphf1.Flag),
				 new MySqlParameter("?cindex",rotedshdphf1.Cindex),
				 new MySqlParameter("?favourite",rotedshdphf1.Favourite),
				 new MySqlParameter("?handicap",rotedshdphf1.Handicap),
				 new MySqlParameter("?homeodds",rotedshdphf1.Homeodds),
				 new MySqlParameter("?awayodds",rotedshdphf1.Awayodds),
				 new MySqlParameter("?homeid",rotedshdphf1.Homeid),
				 new MySqlParameter("?awayid",rotedshdphf1.Awayid),
				 new MySqlParameter("?time",rotedshdphf1.Time),
				 new MySqlParameter("?state",rotedshdphf1.State),
				 new MySqlParameter("?MaxBet",rotedshdphf1.MaxBet),
				 new MySqlParameter("?MinBet",rotedshdphf1.MinBet),
				 new MySqlParameter("?SingleMaxBet",rotedshdphf1.SingleMaxBet)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-2 10:27:02		
		///</summary>		
		public Boolean UpdateRotedshdphf1(Rotedshdphf1 rotedshdphf1)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?allowchange",rotedshdphf1.Allowchange),
				 new MySqlParameter("?matchid",rotedshdphf1.Matchid),
				 new MySqlParameter("?gameid",rotedshdphf1.Gameid),
				 new MySqlParameter("?flag",rotedshdphf1.Flag),
				 new MySqlParameter("?cindex",rotedshdphf1.Cindex),
				 new MySqlParameter("?favourite",rotedshdphf1.Favourite),
				 new MySqlParameter("?handicap",rotedshdphf1.Handicap),
				 new MySqlParameter("?homeodds",rotedshdphf1.Homeodds),
				 new MySqlParameter("?awayodds",rotedshdphf1.Awayodds),
				 new MySqlParameter("?homeid",rotedshdphf1.Homeid),
				 new MySqlParameter("?awayid",rotedshdphf1.Awayid),
				 new MySqlParameter("?time",rotedshdphf1.Time),
				 new MySqlParameter("?state",rotedshdphf1.State),
				 new MySqlParameter("?MaxBet",rotedshdphf1.MaxBet),
				 new MySqlParameter("?MinBet",rotedshdphf1.MinBet),
				 new MySqlParameter("?SingleMaxBet",rotedshdphf1.SingleMaxBet),
				 new MySqlParameter("?id",rotedshdphf1.Id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-2 10:27:02		
		///</summary>		
		public Boolean DeleteRotedshdphf1ByPK(object id)
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
		public Rotedshdphf1 GetRotedshdphf1ByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};

			return MySqlModelHelper<Rotedshdphf1>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2010-11-2 10:27:02		
		///</summary>		
		public IList<Rotedshdphf1> GetMutilILRotedshdphf1()
		{
			return MySqlModelHelper<Rotedshdphf1>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2010-11-2 10:27:02		
		///</summary>		
		public DataTable GetMutilDTRotedshdphf1()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 
	}
}
