using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class Roteds1x2hf1Service
	{
		private const string SQL_INSERT="insert into yafa.roteds1x2hf1 (matchid,gameid,oddshome,oddsaway,oddsdraw,homeid,awayid,drawid,time,state,MaxBet,MinBet,SingleMaxBet,allowchange)values(?matchid,?gameid,?oddshome,?oddsaway,?oddsdraw,?homeid,?awayid,?drawid,?time,?state,?MaxBet,?MinBet,?SingleMaxBet,?allowchange)";
		private const string SQL_UPDATE="update yafa.roteds1x2hf1 set matchid=?matchid,gameid=?gameid,oddshome=?oddshome,oddsaway=?oddsaway,oddsdraw=?oddsdraw,homeid=?homeid,awayid=?awayid,drawid=?drawid,time=?time,state=?state,MaxBet=?MaxBet,MinBet=?MinBet,SingleMaxBet=?SingleMaxBet,allowchange=?allowchange where id = ?id";
		private const string SQL_SELECTBYPK="select id from yafa.roteds1x2hf1  where roteds1x2hf1.id = ?id";
		private const string SQL_SELECTALL="select id,matchid,gameid,cindex,oddshome,oddsaway,oddsdraw,homeid,awayid,drawid,time,state,MaxBet,MinBet,SingleMaxBet,allowchange from yafa.roteds1x2hf1 ";
		private const string SQL_DELETEBYPK="delete  from yafa.roteds1x2hf1  where roteds1x2hf1.id = ?id";
		
		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-2 10:27:01		
		///</summary>		
		public Boolean AddRoteds1x2hf1(Roteds1x2hf1 roteds1x2hf1)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?matchid",roteds1x2hf1.Matchid),
				 new MySqlParameter("?gameid",roteds1x2hf1.Gameid),
				 new MySqlParameter("?cindex",roteds1x2hf1.Cindex),
				 new MySqlParameter("?oddshome",roteds1x2hf1.Oddshome),
				 new MySqlParameter("?oddsaway",roteds1x2hf1.Oddsaway),
				 new MySqlParameter("?oddsdraw",roteds1x2hf1.Oddsdraw),
				 new MySqlParameter("?homeid",roteds1x2hf1.Homeid),
				 new MySqlParameter("?awayid",roteds1x2hf1.Awayid),
				 new MySqlParameter("?drawid",roteds1x2hf1.Drawid),
				 new MySqlParameter("?time",roteds1x2hf1.Time),
				 new MySqlParameter("?state",roteds1x2hf1.State),
				 new MySqlParameter("?MaxBet",roteds1x2hf1.MaxBet),
				 new MySqlParameter("?MinBet",roteds1x2hf1.MinBet),
				 new MySqlParameter("?SingleMaxBet",roteds1x2hf1.SingleMaxBet),
				 new MySqlParameter("?allowchange",roteds1x2hf1.Allowchange)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-2 10:27:01		
		///</summary>		
		public Boolean UpdateRoteds1x2hf1(Roteds1x2hf1 roteds1x2hf1)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?matchid",roteds1x2hf1.Matchid),
				 new MySqlParameter("?gameid",roteds1x2hf1.Gameid),
				 new MySqlParameter("?cindex",roteds1x2hf1.Cindex),
				 new MySqlParameter("?oddshome",roteds1x2hf1.Oddshome),
				 new MySqlParameter("?oddsaway",roteds1x2hf1.Oddsaway),
				 new MySqlParameter("?oddsdraw",roteds1x2hf1.Oddsdraw),
				 new MySqlParameter("?homeid",roteds1x2hf1.Homeid),
				 new MySqlParameter("?awayid",roteds1x2hf1.Awayid),
				 new MySqlParameter("?drawid",roteds1x2hf1.Drawid),
				 new MySqlParameter("?time",roteds1x2hf1.Time),
				 new MySqlParameter("?state",roteds1x2hf1.State),
				 new MySqlParameter("?MaxBet",roteds1x2hf1.MaxBet),
				 new MySqlParameter("?MinBet",roteds1x2hf1.MinBet),
				 new MySqlParameter("?SingleMaxBet",roteds1x2hf1.SingleMaxBet),
				 new MySqlParameter("?allowchange",roteds1x2hf1.Allowchange),
				 new MySqlParameter("?id",roteds1x2hf1.Id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-2 10:27:01		
		///</summary>		
		public Boolean DeleteRoteds1x2hf1ByPK(object id)
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
		public Roteds1x2hf1 GetRoteds1x2hf1ByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};

			return MySqlModelHelper<Roteds1x2hf1>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2010-11-2 10:27:01		
		///</summary>		
		public IList<Roteds1x2hf1> GetMutilILRoteds1x2hf1()
		{
			return MySqlModelHelper<Roteds1x2hf1>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2010-11-2 10:27:01		
		///</summary>		
		public DataTable GetMutilDTRoteds1x2hf1()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 
        #region 编写人:李毅
        public string updateAll(string a,string l,string s)
        {
            string str = "update rote" + l + "1x21,rote" + l + "1x2hf1,rote" + l + "hdp1,rote" + l + "hdphf1,rote" + l + "ou1,rote" + l + "ouhf1 ";
            str += " set rote" + l + "1x21.allowchange=" + s + ",rote" + l + "1x2hf1.allowchange=" + s + ",rote" + l + "hdp1.allowchange=" + s
                + ",rote" + l + "hdphf1.allowchange=" + s + ",rote" + l + "ou1.allowchange=" + s + ",rote" + l + "ouhf1.allowchange=" + s
                + " where rote" + l + "1x21.gameid=" + a + " and rote" + l + "1x2hf1.gameid=" + a + " and rote" + l + "hdp1.gameid=" + a + " and rote" + l
                + "hdphf1.gameid=" + a + " and rote" + l + "ou1.gameid=" + a + " and rote" + l + "ouhf1.gameid=" + a + " ";
            return MySqlHelper.ExecuteNonQuery(str).ToString();
        }

        public string updateOne(string i, string l, string t,string s)
        {
            string str = "update rote" + l + t + "1 set allowchange=" + s;
            return MySqlHelper.ExecuteNonQuery(str).ToString();
        }

        public string getXX(string t, string b, string l,string lg,string g)
        {
            string str = "select UserName as a,OrderID as o,time as b,league" + lg + " as c,Home" + lg + " as d,Away" 
                + lg + " as e,betflag as f,BetItem as g,Handicap as h,Odds as i,OddsType as j,Amount as k,IP as l from " 
                + b + " where gameid=" + l + " and Status='1' and betflag='" + g + "'" + (t != "" ? " and BetType='" + t + "'" : " ");
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        public string getInfo(int i, string t)
        {
            string str = "select id,MinBet,MaxBet,SingleMaxBet from rote" + t + "1x21 where gameid=" + i + " union All select id,MinBet,MaxBet,SingleMaxBet"
            + " from rote" + t + "1x2hf1 where gameid=" + i;
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        public string getrqInfo(int i, string t)
        {
            string str = "select id as d,handicap as e,MinBet as f,MaxBet as g,SingleMaxBet as h,'a' as c from rote" + t + "hdp1 where gameid=" + i + " group by d"
            + " union all select id as d,handicap as e,MinBet as f,MaxBet as g,SingleMaxBet as h,'h' as c from rote" + t + "hdphf1 where gameid=" + i + " group by d";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        public string getdxInfo(int i, string t)
        {
            string str = "select id as d,handicap as e,MinBet as f,MaxBet as g,SingleMaxBet as h,'a' as c from rote" + t + "ou1 where gameid=" + i + " group by d"
            + " union all select id as d,handicap as e,MinBet as f,MaxBet as g,SingleMaxBet as h,'h' as c from rote" + t + "ouhf1 where gameid=" + i + " group by d";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        public string updaInfo(string t,string mi,string ma,string sm,int i)
        {
            string str = "update " + t + " set MinBet=" + mi + ",maxBet=" + ma + ",SingleMaxBet=" + sm + " where id=" + i;
            return MySqlHelper.ExecuteNonQuery(str).ToString();
        }
        #endregion
    }
}
