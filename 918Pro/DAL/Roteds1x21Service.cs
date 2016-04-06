using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class Roteds1x21Service
	{
		private const string SQL_INSERT="insert into yafa.roteds1x21 (matchid,gameid,oddshome,oddsaway,oddsdraw,homeid,awayid,drawid,time,state,MinBet,MaxBet,SingleMaxBet,allowchange)values(?matchid,?gameid,?oddshome,?oddsaway,?oddsdraw,?homeid,?awayid,?drawid,?time,?state,?MinBet,?MaxBet,?SingleMaxBet,?allowchange)";
		private const string SQL_UPDATE="update yafa.roteds1x21 set matchid=?matchid,gameid=?gameid,oddshome=?oddshome,oddsaway=?oddsaway,oddsdraw=?oddsdraw,homeid=?homeid,awayid=?awayid,drawid=?drawid,time=?time,state=?state,MinBet=?MinBet,MaxBet=?MaxBet,SingleMaxBet=?SingleMaxBet,allowchange=?allowchange where id = ?id";
		private const string SQL_SELECTBYPK="select id from yafa.roteds1x21  where roteds1x21.id = ?id";
		private const string SQL_SELECTALL="select id,matchid,gameid,cindex,oddshome,oddsaway,oddsdraw,homeid,awayid,drawid,time,state,MinBet,MaxBet,SingleMaxBet,allowchange from yafa.roteds1x21 ";
		private const string SQL_DELETEBYPK="delete  from yafa.roteds1x21  where roteds1x21.id = ?id";
		
		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-2 10:26:58		
		///</summary>		
		public Boolean AddRoteds1x21(Roteds1x21 roteds1x21)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?matchid",roteds1x21.Matchid),
				 new MySqlParameter("?gameid",roteds1x21.Gameid),
				 new MySqlParameter("?cindex",roteds1x21.Cindex),
				 new MySqlParameter("?oddshome",roteds1x21.Oddshome),
				 new MySqlParameter("?oddsaway",roteds1x21.Oddsaway),
				 new MySqlParameter("?oddsdraw",roteds1x21.Oddsdraw),
				 new MySqlParameter("?homeid",roteds1x21.Homeid),
				 new MySqlParameter("?awayid",roteds1x21.Awayid),
				 new MySqlParameter("?drawid",roteds1x21.Drawid),
				 new MySqlParameter("?time",roteds1x21.Time),
				 new MySqlParameter("?state",roteds1x21.State),
				 new MySqlParameter("?MinBet",roteds1x21.MinBet),
				 new MySqlParameter("?MaxBet",roteds1x21.MaxBet),
				 new MySqlParameter("?SingleMaxBet",roteds1x21.SingleMaxBet),
				 new MySqlParameter("?allowchange",roteds1x21.Allowchange)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-2 10:26:58		
		///</summary>		
		public Boolean UpdateRoteds1x21(Roteds1x21 roteds1x21)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?matchid",roteds1x21.Matchid),
				 new MySqlParameter("?gameid",roteds1x21.Gameid),
				 new MySqlParameter("?cindex",roteds1x21.Cindex),
				 new MySqlParameter("?oddshome",roteds1x21.Oddshome),
				 new MySqlParameter("?oddsaway",roteds1x21.Oddsaway),
				 new MySqlParameter("?oddsdraw",roteds1x21.Oddsdraw),
				 new MySqlParameter("?homeid",roteds1x21.Homeid),
				 new MySqlParameter("?awayid",roteds1x21.Awayid),
				 new MySqlParameter("?drawid",roteds1x21.Drawid),
				 new MySqlParameter("?time",roteds1x21.Time),
				 new MySqlParameter("?state",roteds1x21.State),
				 new MySqlParameter("?MinBet",roteds1x21.MinBet),
				 new MySqlParameter("?MaxBet",roteds1x21.MaxBet),
				 new MySqlParameter("?SingleMaxBet",roteds1x21.SingleMaxBet),
				 new MySqlParameter("?allowchange",roteds1x21.Allowchange),
				 new MySqlParameter("?id",roteds1x21.Id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-2 10:26:58		
		///</summary>		
		public Boolean DeleteRoteds1x21ByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2010-11-2 10:26:58		
		///</summary>		
		public Roteds1x21 GetRoteds1x21ByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};

			return MySqlModelHelper<Roteds1x21>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2010-11-2 10:26:58		
		///</summary>		
		public IList<Roteds1x21> GetMutilILRoteds1x21()
		{
			return MySqlModelHelper<Roteds1x21>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2010-11-2 10:26:58		
		///</summary>		
		public DataTable GetMutilDTRoteds1x21()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 
        #region 编写人:李毅
        /// <summary>
        /// 单式
        /// </summary>
        /// <param name="languague"></param>
        /// <param name="gameid"></param>
        /// <returns></returns>
        public string getToHtml(string languague,string gameid)
        {
            string str = "select id,begintime,league"+languague+",home"+languague+",away"+languague+" from matches";
            List<int> matchid = new List<int>();
            List<string> time = new List<string>();
            List<string> league = new List<string>();
            List<string> home = new List<string>();
            List<string> away = new List<string>();
            MySqlDataReader read = MySqlHelper2.ExecuteReader(str);
            string where = "";
            if (gameid != "")
            {
                where = "where gameid in ("+gameid+")  ";
            }
            while (read.Read())
            {
                matchid.Add(Convert.ToInt32(read.GetString("id")));
                time.Add(read.GetString("begintime"));
                league.Add(read.GetString("league" + languague));
                home.Add(read.GetString("home" + languague));
                away.Add(read.GetString("away" + languague));
            }
            /*-----------------查询单式全场让球------------------*/
            string strdshdp1 = "select id,gameid,homeodds,awayodds,allowchange,handicap from rotedshdp1 " + where + " order by  gameid";
            List<Rotedshdp1> hdp1 = new List<Rotedshdp1>();
            MySqlDataReader readhdp1 = MySqlHelper.ExecuteReader(strdshdp1);
            while (readhdp1.Read())
            {
                Rotedshdp1 rotehdp1 = new Rotedshdp1();
                rotehdp1.Gameid = Convert.ToInt32(readhdp1.GetString("gameid"));
                rotehdp1.Id = Convert.ToInt32(readhdp1.GetString("id"));
                rotehdp1.Homeodds = Convert.ToDecimal(readhdp1.GetString("homeodds"));
                rotehdp1.Awayodds = Convert.ToDecimal(readhdp1.GetString("awayodds"));
                rotehdp1.Allowchange = Convert.ToInt32(readhdp1.GetString("allowchange"));
                rotehdp1.Handicap = readhdp1.GetString("handicap");
                hdp1.Add(rotehdp1);
            }
            /*-----------------查询单式全场让球结束------------------*/
            /*-----------------查询单式半场让球------------------*/
            string strdshdphf1 = "select id,gameid,homeodds,awayodds,allowchange,handicap from rotedshdphf1 " + where + " order by  gameid";
            List<Rotedshdphf1> hdphf1 = new List<Rotedshdphf1>();
            MySqlDataReader readhdphf1 = MySqlHelper.ExecuteReader(strdshdphf1);
            while (readhdphf1.Read())
            {
                Rotedshdphf1 rotehdphf1 = new Rotedshdphf1();
                rotehdphf1.Gameid = Convert.ToInt32(readhdphf1.GetString("gameid"));
                rotehdphf1.Id = Convert.ToInt32(readhdphf1.GetString("id"));
                rotehdphf1.Homeodds = Convert.ToDecimal(readhdphf1.GetString("homeodds"));
                rotehdphf1.Awayodds = Convert.ToDecimal(readhdphf1.GetString("awayodds"));
                rotehdphf1.Allowchange = Convert.ToInt32(readhdphf1.GetString("allowchange"));
                rotehdphf1.Handicap = readhdphf1.GetString("handicap");
                hdphf1.Add(rotehdphf1);
            }
            /*-----------------查询单式半场让球结束------------------*/
            /*-----------------查询单式全场大小------------------*/
            string strdsou1 = "select id,gameid,homeodds,awayodds,allowchange,handicap from rotedsou1 " + where + " order by  gameid";
            List<Rotedsou1> ou1 = new List<Rotedsou1>();
            MySqlDataReader readou1 = MySqlHelper.ExecuteReader(strdsou1);
            while (readou1.Read())
            {
                Rotedsou1 roteou1 = new Rotedsou1();
                roteou1.Gameid = Convert.ToInt32(readou1.GetString("gameid"));
                roteou1.Id = Convert.ToInt32(readou1.GetString("id"));
                roteou1.Homeodds = Convert.ToDecimal(readou1.GetString("homeodds"));
                roteou1.Awayodds = Convert.ToDecimal(readou1.GetString("awayodds"));
                roteou1.Allowchange = Convert.ToInt32(readou1.GetString("allowchange"));
                roteou1.Handicap = readou1.GetString("handicap");
                ou1.Add(roteou1);
            }
            /*-----------------查询单式全场大小结束------------------*/
            /*-----------------查询单式半场大小------------------*/
            string strdsouhf1 = "select id,gameid,homeodds,awayodds,allowchange,handicap from rotedsouhf1 " + where + " order by  gameid";
            List<Rotedsouhf1> ouhf1 = new List<Rotedsouhf1>();
            MySqlDataReader readouhf1 = MySqlHelper.ExecuteReader(strdsouhf1);
            while (readouhf1.Read())
            {
                Rotedsouhf1 roteouhf1 = new Rotedsouhf1();
                roteouhf1.Gameid = Convert.ToInt32(readouhf1.GetString("gameid"));
                roteouhf1.Id = Convert.ToInt32(readouhf1.GetString("id"));
                roteouhf1.Homeodds = Convert.ToDecimal(readouhf1.GetString("homeodds"));
                roteouhf1.Awayodds = Convert.ToDecimal(readouhf1.GetString("awayodds"));
                roteouhf1.Allowchange = Convert.ToInt32(readouhf1.GetString("allowchange"));
                roteouhf1.Handicap = readouhf1.GetString("handicap");
                ouhf1.Add(roteouhf1);
            }
            /*-----------------查询单式半场大小结束------------------*/
            /*-----------------查询单式全场标准------------------*/
            string strds1x21 = "select id,gameid,oddshome,oddsaway,oddsdraw,allowchange from roteds1x21 " + where + " order by  gameid";
            List<Roteds1x21> r1x21 = new List<Roteds1x21>();
            MySqlDataReader read1x21 = MySqlHelper.ExecuteReader(strds1x21);
            while (read1x21.Read())
            {
                Roteds1x21 rote1x21 = new Roteds1x21();
                rote1x21.Gameid = Convert.ToInt32(read1x21.GetString("gameid"));
                rote1x21.Id = Convert.ToInt32(read1x21.GetString("id"));
                rote1x21.Oddshome = Convert.ToDecimal(read1x21.GetString("oddshome"));
                rote1x21.Oddsaway = Convert.ToDecimal(read1x21.GetString("oddsaway"));
                rote1x21.Oddsdraw = Convert.ToDecimal(read1x21.GetString("oddsdraw"));
                rote1x21.Allowchange = Convert.ToInt32(read1x21.GetString("allowchange"));
                r1x21.Add(rote1x21);
            }
            /*-----------------查询单式全场标准结束------------------*/
            /*-----------------查询单式半场标准------------------*/
            string strds1x2hf1 = "select id,gameid,oddshome,oddsaway,oddsdraw,allowchange from roteds1x2hf1 " + where + " order by  gameid";
            List<Roteds1x2hf1> r1x2hf1 = new List<Roteds1x2hf1>();
            MySqlDataReader read1x2hf1 = MySqlHelper.ExecuteReader(strds1x2hf1);
            while (read1x2hf1.Read())
            {
                Roteds1x2hf1 rote1x2hf1 = new Roteds1x2hf1();
                rote1x2hf1.Gameid = Convert.ToInt32(read1x2hf1.GetString("gameid"));
                rote1x2hf1.Id = Convert.ToInt32(read1x2hf1.GetString("id"));
                rote1x2hf1.Oddshome = Convert.ToDecimal(read1x2hf1.GetString("oddshome"));
                rote1x2hf1.Oddsaway = Convert.ToDecimal(read1x2hf1.GetString("oddsaway"));
                rote1x2hf1.Oddsdraw = Convert.ToDecimal(read1x2hf1.GetString("oddsdraw"));
                rote1x2hf1.Allowchange = Convert.ToInt32(read1x2hf1.GetString("allowchange"));
                r1x2hf1.Add(rote1x2hf1);
            }
            /*-----------------查询单式半场标准结束------------------*/
            string toarray = "[";
            for (int i = 0; i < matchid.Count; i++)
            {
                if (i > 0)
                {
                    toarray += ",";
                }
                toarray += "[";
                toarray += "'" + matchid[i];
                toarray += "','" + time[i];
                toarray += "','" + league[i];
                toarray += "','" + home[i];
                toarray += "','" + away[i];
                toarray += "',";
                /*---------全场标准赔率-------------*/
                toarray += "[";
                if (i < r1x21.Count)
                {
                    bool pd = false;
                    for (int j = 0; j < r1x21.Count; j++)
                    {
                        if (r1x21[j].Gameid == matchid[i])
                        {
                            if (pd)
                            {
                                toarray += ",";
                            }
                            toarray += "[";
                            toarray += "'" + r1x21[j].Id;
                            toarray += "','" + r1x21[j].Gameid;
                            toarray += "','" + r1x21[j].Oddshome;
                            toarray += "','" + r1x21[j].Oddsaway;
                            toarray += "','" + r1x21[j].Oddsdraw;
                            toarray += "','" + r1x21[j].Allowchange;
                            string Hstr = "select sum(Amount) from orderdetail1x2 where gameid=" + r1x21[j].Gameid + " and BetType='12' and betflag='1'";
                            string munt1 = MySqlHelper.ExecuteScalar(Hstr).ToString();
                            toarray += "','" + (munt1 == "" ? "0" : munt1);
                            string Astr = "select sum(Amount) from orderdetail1x2 where gameid=" + r1x21[j].Gameid + " and BetType='12' and betflag='2'";
                            string munt2 = MySqlHelper.ExecuteScalar(Astr).ToString();
                            toarray += "','" + (munt2 == "" ? "0" : munt2);
                            string Xstr = "select sum(Amount) from orderdetail1x2 where gameid=" + r1x21[j].Gameid + " and BetType='12' and betflag='X'";
                            string muntX = MySqlHelper.ExecuteScalar(Xstr).ToString();
                            toarray += "','" + (muntX == "" ? "0" : muntX);
                            toarray += "']";
                            pd = true;
                        }
                    }
                }
                toarray += "]";
                toarray += ",";
                /*---------全场标准赔率结束-------------*/
                /*---------全场让球赔率-------------*/
                toarray += "[";
                if (i < hdp1.Count)
                {
                    bool pd = false;
                    for (int j = 0; j < hdp1.Count; j++)
                    {
                        if (hdp1[j].Gameid == matchid[i])
                        {
                            if (pd)
                            {
                                toarray += ",";
                            }
                            toarray += "[";
                            toarray += "'" + hdp1[j].Id;
                            toarray += "','" + hdp1[j].Gameid;
                            toarray += "','" + hdp1[j].Homeodds;
                            toarray += "','" + hdp1[j].Awayodds;
                            toarray += "','" + hdp1[j].Handicap;
                            toarray += "','" + hdp1[j].Allowchange;
                            string amount1 = hdp1[j].Handicap.IndexOf("/") == -1 ? hdp1[j].Handicap : ((double.Parse(hdp1[j].Handicap.Substring(0, hdp1[j].Handicap.IndexOf("/"))) + double.Parse(hdp1[j].Handicap.Substring(hdp1[j].Handicap.IndexOf("/") + 1))) / 2).ToString();
                            string amountcount = "select sum(Amount) from orderdetailhdp where gameid=" + hdp1[j].Gameid + " and BetType='0' and betflag='H'" + (amount1 != "" ? " and (handicap=" + amount1 + " or handicap=-" + amount1 + ")" : " ");
                            string Hmount = MySqlHelper.ExecuteScalar(amountcount).ToString();
                            toarray += "','" + (Hmount == "" ? "0" : Hmount);
                            string amountcount1 = "select sum(Amount) from orderdetailhdp where gameid=" + hdp1[j].Gameid + " and BetType='0' and betflag='A'" + (amount1 != "" ? " and (handicap=" + amount1 + " or handicap=-" + amount1 + ")" : " ");
                            string AmountA = MySqlHelper.ExecuteScalar(amountcount1).ToString();
                            toarray += "','" + (AmountA == "" ? "0" : AmountA);
                            toarray += "']";
                            pd = true;
                        }
                    }
                }
                toarray += "]";
                toarray += ",";
                /*---------全场让球赔率结束-------------*/
                /*---------全场大小赔率-------------*/
                toarray += "[";
                if (i < ou1.Count)
                {
                    bool pd = false;
                    for (int j = 0; j < ou1.Count; j++)
                    {
                        if (ou1[j].Gameid == matchid[i])
                        {
                            if (pd)
                            {
                                toarray += ",";
                            }
                            toarray += "[";
                            toarray += "'" + ou1[j].Id;
                            toarray += "','" + ou1[j].Gameid;
                            toarray += "','" + ou1[j].Homeodds;
                            toarray += "','" + ou1[j].Awayodds;
                            toarray += "','" + ou1[j].Handicap;
                            toarray += "','" + ou1[j].Allowchange;
                            string hand = ou1[j].Handicap;
                            string ostr = "select sum(Amount) from orderdetailou where gameid=" + ou1[j].Gameid + " and BetType='1' and betflag='O'" + (hand != "" ? " and handicap=1.5" : " ");
                            string omount = MySqlHelper.ExecuteScalar(ostr).ToString();
                            toarray += "','" + (omount == "" ? "0" : omount);
                            string ustr = "select sum(Amount) from orderdetailou where gameid=" + ou1[j].Gameid + " and BetType='1' and betflag='U'" + (hand != "" ? " and handicap=1.5" : " ");
                            string umount = MySqlHelper.ExecuteScalar(ustr).ToString();
                            toarray += "','" + (umount == "" ? "0" : umount);
                            toarray += "']";
                            pd = true;
                        }
                    }
                }
                toarray += "]";
                toarray += ",";
                /*---------全场大小赔率结束-------------*/
                /*---------半场标准赔率-------------*/
                toarray += "[";
                if (i < r1x2hf1.Count)
                {
                    bool pd = false;
                    for (int j = 0; j < r1x2hf1.Count; j++)
                    {
                        if (r1x2hf1[j].Gameid == matchid[i])
                        {
                            if (pd)
                            {
                                toarray += ",";
                            }
                            toarray += "[";
                            toarray += "'" + r1x2hf1[j].Id;
                            toarray += "','" + r1x2hf1[j].Gameid;
                            toarray += "','" + r1x2hf1[j].Oddshome;
                            toarray += "','" + r1x2hf1[j].Oddsaway;
                            toarray += "','" + r1x2hf1[j].Oddsdraw;
                            toarray += "','" + r1x2hf1[j].Allowchange;
                            string Hstr = "select sum(Amount) from orderdetail1x2hf where gameid=" + r1x2hf1[j].Gameid + " and BetType='13' and betflag='1'";
                            string munt1 = MySqlHelper.ExecuteScalar(Hstr).ToString();
                            toarray += "','" + (munt1 == "" ? "0" : munt1);
                            string Astr = "select sum(Amount) from orderdetail1x2hf where gameid=" + r1x2hf1[j].Gameid + " and BetType='13' and betflag='2'";
                            string munt2 = MySqlHelper.ExecuteScalar(Astr).ToString();
                            toarray += "','" + (munt2 == "" ? "0" : munt2);
                            string Xstr = "select sum(Amount) from orderdetail1x2hf where gameid=" + r1x2hf1[j].Gameid + " and BetType='13' and betflag='X'";
                            string muntX = MySqlHelper.ExecuteScalar(Xstr).ToString();
                            toarray += "','" + (muntX == "" ? "0" : muntX);
                            toarray += "']";
                            pd = true;
                        }
                    }
                }
                toarray += "]";
                toarray += ",";
                /*---------半场标准赔率结束-------------*/
                /*---------半场让球赔率-------------*/
                toarray += "[";
                if (i < hdphf1.Count)
                {
                    bool pd = false;
                    for (int j = 0; j < hdphf1.Count; j++)
                    {
                        if (hdphf1[j].Gameid == matchid[i])
                        {
                            if (pd)
                            {
                                toarray += ",";
                            }
                            toarray += "[";
                            toarray += "'" + hdphf1[j].Id;
                            toarray += "','" + hdphf1[j].Gameid;
                            toarray += "','" + hdphf1[j].Homeodds;
                            toarray += "','" + hdphf1[j].Awayodds;
                            toarray += "','" + hdphf1[j].Handicap;
                            toarray += "','" + hdphf1[j].Allowchange;
                            string amount1 = hdphf1[j].Handicap.IndexOf("/") == -1 ? hdphf1[j].Handicap : ((double.Parse(hdphf1[j].Handicap.Substring(0, hdphf1[j].Handicap.IndexOf("/"))) + double.Parse(hdphf1[j].Handicap.Substring(hdphf1[j].Handicap.IndexOf("/") + 1))) / 2).ToString();
                            string amountcount = "select sum(Amount) from orderdetailhdphf where gameid=" + hdphf1[j].Gameid + " and BetType='2' and betflag='H'" + (amount1 != "" ? " and (handicap=" + amount1 + " or handicap=-" + amount1 + ")" : " ");
                            string Hmount = MySqlHelper.ExecuteScalar(amountcount).ToString();
                            toarray += "','" + (Hmount == "" ? "0" : Hmount);
                            string amountcount1 = "select sum(Amount) from orderdetailhdphf where gameid=" + hdphf1[j].Gameid + " and BetType='2' and betflag='A'" + (amount1 != "" ? " and (handicap=" + amount1 + " or handicap=-" + amount1 + ")" : " ");
                            string AmountA = MySqlHelper.ExecuteScalar(amountcount1).ToString();
                            toarray += "','" + (AmountA == "" ? "0" : AmountA);
                            toarray += "']";
                            pd = true;
                        }
                    }
                }
                toarray += "]";
                toarray += ",";
                /*---------半场让球赔率结束-------------*/
                
                /*---------半场大小赔率-------------*/
                toarray += "[";
                if (i < ouhf1.Count)
                {
                    bool pd = false;
                    for (int j = 0; j < ouhf1.Count; j++)
                    {
                        if (ouhf1[j].Gameid == matchid[i])
                        {
                            if (pd)
                            {
                                toarray += ",";
                            }
                            toarray += "[";
                            toarray += "'" + ouhf1[j].Id;
                            toarray += "','" + ouhf1[j].Gameid;
                            toarray += "','" + ouhf1[j].Homeodds;
                            toarray += "','" + ouhf1[j].Awayodds;
                            toarray += "','" + ouhf1[j].Handicap;
                            toarray += "','" + ouhf1[j].Allowchange;
                            string hand = ouhf1[j].Handicap;
                            string ostr = "select sum(Amount) from orderdetailouhf where gameid=" + ouhf1[j].Gameid + " and BetType='3' and betflag='O'" + (hand != "" ? " and handicap=1.5" : " ");
                            string omount = MySqlHelper.ExecuteScalar(ostr).ToString();
                            toarray += "','" + (omount == "" ? "0" : omount);
                            string ustr = "select sum(Amount) from orderdetailouhf where gameid=" + ouhf1[j].Gameid + " and BetType='3' and betflag='U'" + (hand != "" ? " and handicap=1.5" : " ");
                            string umount = MySqlHelper.ExecuteScalar(ustr).ToString();
                            toarray += "','" + (umount == "" ? "0" : umount);
                            toarray += "']";
                            pd = true;
                        }
                    }
                }
                toarray += "]";
                /*---------半场大小赔率结束-------------*/
                toarray += ",'单式']";
            }
            toarray += "]";
            return toarray;
        }
        /// <summary>
        /// 早餐
        /// </summary>
        /// <param name="languague"></param>
        /// <param name="gameid"></param>
        /// <returns></returns>
        public string getzcToHtml(string languague, string gameid)
        {
            string str = "select id,begintime,league" + languague + ",home" + languague + ",away" + languague + " from matches";
            List<int> matchid = new List<int>();
            List<string> time = new List<string>();
            List<string> league = new List<string>();
            List<string> home = new List<string>();
            List<string> away = new List<string>();
            MySqlDataReader read = MySqlHelper2.ExecuteReader(str);
            string where = "";
            if (gameid != "")
            {
                where = "where gameid in (" + gameid + ")  ";
            }
            while (read.Read())
            {
                matchid.Add(Convert.ToInt32(read.GetString("id")));
                time.Add(read.GetString("begintime"));
                league.Add(read.GetString("league" + languague));
                home.Add(read.GetString("home" + languague));
                away.Add(read.GetString("away" + languague));
            }
            /*-----------------查询早餐全场让球------------------*/
            string strdshdp1 = "select id,gameid,homeodds,awayodds,allowchange,handicap from rotezchdp1 " + where + " order by  gameid";
            List<Rotezchdp1> hdp1 = new List<Rotezchdp1>();
            MySqlDataReader readhdp1 = MySqlHelper.ExecuteReader(strdshdp1);
            while (readhdp1.Read())
            {
                Rotezchdp1 rotehdp1 = new Rotezchdp1();
                rotehdp1.Gameid = Convert.ToInt32(readhdp1.GetString("gameid"));
                rotehdp1.Id = Convert.ToInt32(readhdp1.GetString("id"));
                rotehdp1.Homeodds = Convert.ToDecimal(readhdp1.GetString("homeodds"));
                rotehdp1.Awayodds = Convert.ToDecimal(readhdp1.GetString("awayodds"));
                rotehdp1.Allowchange = Convert.ToInt32(readhdp1.GetString("allowchange"));
                rotehdp1.Handicap = readhdp1.GetString("handicap");
                hdp1.Add(rotehdp1);
            }
            /*-----------------查询早餐全场让球结束------------------*/
            /*-----------------查询早餐半场让球------------------*/
            string strdshdphf1 = "select id,gameid,homeodds,awayodds,allowchange,handicap from rotezchdphf1 " + where + " order by  gameid";
            List<Rotezchdphf1> hdphf1 = new List<Rotezchdphf1>();
            MySqlDataReader readhdphf1 = MySqlHelper.ExecuteReader(strdshdphf1);
            while (readhdphf1.Read())
            {
                Rotezchdphf1 rotehdphf1 = new Rotezchdphf1();
                rotehdphf1.Gameid = Convert.ToInt32(readhdphf1.GetString("gameid"));
                rotehdphf1.Id = Convert.ToInt32(readhdphf1.GetString("id"));
                rotehdphf1.Homeodds = Convert.ToDecimal(readhdphf1.GetString("homeodds"));
                rotehdphf1.Awayodds = Convert.ToDecimal(readhdphf1.GetString("awayodds"));
                rotehdphf1.Allowchange = Convert.ToInt32(readhdphf1.GetString("allowchange"));
                rotehdphf1.Handicap = readhdphf1.GetString("handicap");
                hdphf1.Add(rotehdphf1);
            }
            /*-----------------查询早餐半场让球结束------------------*/
            /*-----------------查询早餐全场大小------------------*/
            string strdsou1 = "select id,gameid,homeodds,awayodds,allowchange,handicap from rotezcou1 " + where + " order by  gameid";
            List<Rotezcou1> ou1 = new List<Rotezcou1>();
            MySqlDataReader readou1 = MySqlHelper.ExecuteReader(strdsou1);
            while (readou1.Read())
            {
                Rotezcou1 roteou1 = new Rotezcou1();
                roteou1.Gameid = Convert.ToInt32(readou1.GetString("gameid"));
                roteou1.Id = Convert.ToInt32(readou1.GetString("id"));
                roteou1.Homeodds = Convert.ToDecimal(readou1.GetString("homeodds"));
                roteou1.Awayodds = Convert.ToDecimal(readou1.GetString("awayodds"));
                roteou1.Allowchange = Convert.ToInt32(readou1.GetString("allowchange"));
                roteou1.Handicap = readou1.GetString("handicap");
                ou1.Add(roteou1);
            }
            /*-----------------查询早餐全场大小结束------------------*/
            /*-----------------查询早餐半场大小------------------*/
            string strdsouhf1 = "select id,gameid,homeodds,awayodds,allowchange,handicap from rotezcouhf1 " + where + " order by  gameid";
            List<Rotezcouhf1> ouhf1 = new List<Rotezcouhf1>();
            MySqlDataReader readouhf1 = MySqlHelper.ExecuteReader(strdsouhf1);
            while (readouhf1.Read())
            {
                Rotezcouhf1 roteouhf1 = new Rotezcouhf1();
                roteouhf1.Gameid = Convert.ToInt32(readouhf1.GetString("gameid"));
                roteouhf1.Id = Convert.ToInt32(readouhf1.GetString("id"));
                roteouhf1.Homeodds = Convert.ToDecimal(readouhf1.GetString("homeodds"));
                roteouhf1.Awayodds = Convert.ToDecimal(readouhf1.GetString("awayodds"));
                roteouhf1.Allowchange = Convert.ToInt32(readouhf1.GetString("allowchange"));
                roteouhf1.Handicap = readouhf1.GetString("handicap");
                ouhf1.Add(roteouhf1);
            }
            /*-----------------查询早餐半场大小结束------------------*/
            /*-----------------查询早餐全场标准------------------*/
            string strds1x21 = "select id,gameid,oddshome,oddsaway,oddsdraw,allowchange from rotezc1x21 " + where + " order by  gameid";
            List<Rotezc1x21> r1x21 = new List<Rotezc1x21>();
            MySqlDataReader read1x21 = MySqlHelper.ExecuteReader(strds1x21);
            while (read1x21.Read())
            {
                Rotezc1x21 rote1x21 = new Rotezc1x21();
                rote1x21.Gameid = Convert.ToInt32(read1x21.GetString("gameid"));
                rote1x21.Id = Convert.ToInt32(read1x21.GetString("id"));
                rote1x21.Oddshome = Convert.ToDecimal(read1x21.GetString("oddshome"));
                rote1x21.Oddsaway = Convert.ToDecimal(read1x21.GetString("oddsaway"));
                rote1x21.Oddsdraw = Convert.ToDecimal(read1x21.GetString("oddsdraw"));
                rote1x21.Allowchange = Convert.ToInt32(read1x21.GetString("allowchange"));
                r1x21.Add(rote1x21);
            }
            /*-----------------查询早餐全场标准结束------------------*/
            /*-----------------查询早餐半场标准------------------*/
            string strds1x2hf1 = "select id,gameid,oddshome,oddsaway,oddsdraw,allowchange from rotezc1x2hf1 " + where + " order by  gameid";
            List<Rotezc1x2hf1> r1x2hf1 = new List<Rotezc1x2hf1>();
            MySqlDataReader read1x2hf1 = MySqlHelper.ExecuteReader(strds1x2hf1);
            while (read1x2hf1.Read())
            {
                Rotezc1x2hf1 rote1x2hf1 = new Rotezc1x2hf1();
                rote1x2hf1.Gameid = Convert.ToInt32(read1x2hf1.GetString("gameid"));
                rote1x2hf1.Id = Convert.ToInt32(read1x2hf1.GetString("id"));
                rote1x2hf1.Oddshome = Convert.ToDecimal(read1x2hf1.GetString("oddshome"));
                rote1x2hf1.Oddsaway = Convert.ToDecimal(read1x2hf1.GetString("oddsaway"));
                rote1x2hf1.Oddsdraw = Convert.ToDecimal(read1x2hf1.GetString("oddsdraw"));
                rote1x2hf1.Allowchange = Convert.ToInt32(read1x2hf1.GetString("allowchange"));
                r1x2hf1.Add(rote1x2hf1);
            }
            /*-----------------查询早餐半场标准结束------------------*/
            string toarray = "[";
            for (int i = 0; i < matchid.Count; i++)
            {
                if (i > 0)
                {
                    toarray += ",";
                }
                toarray += "[";
                toarray += "'" + matchid[i];
                toarray += "','" + time[i];
                toarray += "','" + league[i];
                toarray += "','" + home[i];
                toarray += "','" + away[i];
                toarray += "',";
                /*---------全场标准赔率-------------*/
                toarray += "[";
                if (i < r1x21.Count)
                {
                    bool pd = false;
                    for (int j = 0; j < r1x21.Count; j++)
                    {
                        if (r1x21[j].Gameid == matchid[i])
                        {
                            if (pd)
                            {
                                toarray += ",";
                            }
                            toarray += "[";
                            toarray += "'" + r1x21[j].Id;
                            toarray += "','" + r1x21[j].Gameid;
                            toarray += "','" + r1x21[j].Oddshome;
                            toarray += "','" + r1x21[j].Oddsaway;
                            toarray += "','" + r1x21[j].Oddsdraw;
                            toarray += "','" + r1x21[j].Allowchange;
                            string Hstr = "select sum(Amount) from orderdetail1x2 where gameid=" + r1x21[j].Gameid + " and BetType='16' and betflag='1'";
                            string munt1 = MySqlHelper.ExecuteScalar(Hstr).ToString();
                            toarray += "','" + (munt1 == "" ? "0" : munt1);
                            string Astr = "select sum(Amount) from orderdetail1x2 where gameid=" + r1x21[j].Gameid + " and BetType='16' and betflag='2'";
                            string munt2 = MySqlHelper.ExecuteScalar(Astr).ToString();
                            toarray += "','" + (munt2 == "" ? "0" : munt2);
                            string Xstr = "select sum(Amount) from orderdetail1x2 where gameid=" + r1x21[j].Gameid + " and BetType='16' and betflag='X'";
                            string muntX = MySqlHelper.ExecuteScalar(Xstr).ToString();
                            toarray += "','" + (muntX == "" ? "0" : muntX);
                            toarray += "']";
                            pd = true;
                        }
                    }
                }
                toarray += "]";
                toarray += ",";
                /*---------全场标准赔率结束-------------*/
                /*---------全场让球赔率-------------*/
                toarray += "[";
                if (i < hdp1.Count)
                {
                    bool pd = false;
                    for (int j = 0; j < hdp1.Count; j++)
                    {
                        if (hdp1[j].Gameid == matchid[i])
                        {
                            if (pd)
                            {
                                toarray += ",";
                            }
                            toarray += "[";
                            toarray += "'" + hdp1[j].Id;
                            toarray += "','" + hdp1[j].Gameid;
                            toarray += "','" + hdp1[j].Homeodds;
                            toarray += "','" + hdp1[j].Awayodds;
                            toarray += "','" + hdp1[j].Handicap;
                            toarray += "','" + hdp1[j].Allowchange;
                            string amount1 = hdp1[j].Handicap.IndexOf("/") == -1 ? hdp1[j].Handicap : ((double.Parse(hdp1[j].Handicap.Substring(0, hdp1[j].Handicap.IndexOf("/"))) + double.Parse(hdp1[j].Handicap.Substring(hdp1[j].Handicap.IndexOf("/") + 1))) / 2).ToString();
                            string amountcount = "select sum(Amount) from orderdetailhdp where gameid=" + hdp1[j].Gameid + " and BetType='8' and betflag='H'" + (amount1 != "" ? " and (handicap=" + amount1 + " or handicap=-" + amount1 + ")" : " ");
                            string Hmount = MySqlHelper.ExecuteScalar(amountcount).ToString();
                            toarray += "','" + (Hmount == "" ? "0" : Hmount);
                            string amountcount1 = "select sum(Amount) from orderdetailhdp where gameid=" + hdp1[j].Gameid + " and BetType='8' and betflag='A'" + (amount1 != "" ? " and (handicap=" + amount1 + " or handicap=-" + amount1 + ")" : " ");
                            string AmountA = MySqlHelper.ExecuteScalar(amountcount1).ToString();
                            toarray += "','" + (AmountA == "" ? "0" : AmountA);
                            toarray += "']";
                            pd = true;
                        }
                    }
                }
                toarray += "]";
                toarray += ",";
                /*---------全场让球赔率结束-------------*/
                /*---------全场大小赔率-------------*/
                toarray += "[";
                if (i < ou1.Count)
                {
                    bool pd = false;
                    for (int j = 0; j < ou1.Count; j++)
                    {
                        if (ou1[j].Gameid == matchid[i])
                        {
                            if (pd)
                            {
                                toarray += ",";
                            }
                            toarray += "[";
                            toarray += "'" + ou1[j].Id;
                            toarray += "','" + ou1[j].Gameid;
                            toarray += "','" + ou1[j].Homeodds;
                            toarray += "','" + ou1[j].Awayodds;
                            toarray += "','" + ou1[j].Handicap;
                            toarray += "','" + ou1[j].Allowchange;
                            string hand = ou1[j].Handicap;
                            string ostr = "select sum(Amount) from orderdetailou where gameid=" + ou1[j].Gameid + " and BetType='9' and betflag='O'" + (hand != "" ? " and handicap=1.5" : " ");
                            string omount = MySqlHelper.ExecuteScalar(ostr).ToString();
                            toarray += "','" + (omount == "" ? "0" : omount);
                            string ustr = "select sum(Amount) from orderdetailou where gameid=" + ou1[j].Gameid + " and BetType='9' and betflag='U'" + (hand != "" ? " and handicap=1.5" : " ");
                            string umount = MySqlHelper.ExecuteScalar(ustr).ToString();
                            toarray += "','" + (umount == "" ? "0" : umount);
                            toarray += "']";
                            pd = true;
                        }
                    }
                }
                toarray += "]";
                toarray += ",";
                /*---------全场大小赔率结束-------------*/
                /*---------半场标准赔率-------------*/
                toarray += "[";
                if (i < r1x2hf1.Count)
                {
                    bool pd = false;
                    for (int j = 0; j < r1x2hf1.Count; j++)
                    {
                        if (r1x2hf1[j].Gameid == matchid[i])
                        {
                            if (pd)
                            {
                                toarray += ",";
                            }
                            toarray += "[";
                            toarray += "'" + r1x2hf1[j].Id;
                            toarray += "','" + r1x2hf1[j].Gameid;
                            toarray += "','" + r1x2hf1[j].Oddshome;
                            toarray += "','" + r1x2hf1[j].Oddsaway;
                            toarray += "','" + r1x2hf1[j].Oddsdraw;
                            toarray += "','" + r1x2hf1[j].Allowchange;
                            string Hstr = "select sum(Amount) from orderdetail1x2hf where gameid=" + r1x2hf1[j].Gameid + " and BetType='17' and betflag='1'";
                            string munt1 = MySqlHelper.ExecuteScalar(Hstr).ToString();
                            toarray += "','" + (munt1 == "" ? "0" : munt1);
                            string Astr = "select sum(Amount) from orderdetail1x2hf where gameid=" + r1x2hf1[j].Gameid + " and BetType='17' and betflag='2'";
                            string munt2 = MySqlHelper.ExecuteScalar(Astr).ToString();
                            toarray += "','" + (munt2 == "" ? "0" : munt2);
                            string Xstr = "select sum(Amount) from orderdetail1x2hf where gameid=" + r1x2hf1[j].Gameid + " and BetType='17' and betflag='X'";
                            string muntX = MySqlHelper.ExecuteScalar(Xstr).ToString();
                            toarray += "','" + (muntX == "" ? "0" : muntX);
                            toarray += "']";
                            pd = true;
                        }
                    }
                }
                toarray += "]";
                toarray += ",";
                /*---------半场标准赔率结束-------------*/
                /*---------半场让球赔率-------------*/
                toarray += "[";
                if (i < hdphf1.Count)
                {
                    bool pd = false;
                    for (int j = 0; j < hdphf1.Count; j++)
                    {
                        if (hdphf1[j].Gameid == matchid[i])
                        {
                            if (pd)
                            {
                                toarray += ",";
                            }
                            toarray += "[";
                            toarray += "'" + hdphf1[j].Id;
                            toarray += "','" + hdphf1[j].Gameid;
                            toarray += "','" + hdphf1[j].Homeodds;
                            toarray += "','" + hdphf1[j].Awayodds;
                            toarray += "','" + hdphf1[j].Handicap;
                            toarray += "','" + hdphf1[j].Allowchange;
                            string amount1 = hdphf1[j].Handicap.IndexOf("/") == -1 ? hdphf1[j].Handicap : ((double.Parse(hdphf1[j].Handicap.Substring(0, hdphf1[j].Handicap.IndexOf("/"))) + double.Parse(hdphf1[j].Handicap.Substring(hdphf1[j].Handicap.IndexOf("/") + 1))) / 2).ToString();
                            string amountcount = "select sum(Amount) from orderdetailhdphf where gameid=" + hdphf1[j].Gameid + " and BetType='10' and betflag='H'" + (amount1 != "" ? " and (handicap=" + amount1 + " or handicap=-" + amount1 + ")" : " ");
                            string Hmount = MySqlHelper.ExecuteScalar(amountcount).ToString();
                            toarray += "','" + (Hmount == "" ? "0" : Hmount);
                            string amountcount1 = "select sum(Amount) from orderdetailhdphf where gameid=" + hdphf1[j].Gameid + " and BetType='10' and betflag='A'" + (amount1 != "" ? " and (handicap=" + amount1 + " or handicap=-" + amount1 + ")" : " ");
                            string AmountA = MySqlHelper.ExecuteScalar(amountcount1).ToString();
                            toarray += "','" + (AmountA == "" ? "0" : AmountA);
                            toarray += "']";
                            pd = true;
                        }
                    }
                }
                toarray += "]";
                toarray += ",";
                /*---------半场让球赔率结束-------------*/

                /*---------半场大小赔率-------------*/
                toarray += "[";
                if (i < ouhf1.Count)
                {
                    bool pd = false;
                    for (int j = 0; j < ouhf1.Count; j++)
                    {
                        if (ouhf1[j].Gameid == matchid[i])
                        {
                            if (pd)
                            {
                                toarray += ",";
                            }
                            toarray += "[";
                            toarray += "'" + ouhf1[j].Id;
                            toarray += "','" + ouhf1[j].Gameid;
                            toarray += "','" + ouhf1[j].Homeodds;
                            toarray += "','" + ouhf1[j].Awayodds;
                            toarray += "','" + ouhf1[j].Handicap;
                            toarray += "','" + ouhf1[j].Allowchange;
                            string hand = ouhf1[j].Handicap;
                            string ostr = "select sum(Amount) from orderdetailouhf where gameid=" + ouhf1[j].Gameid + " and BetType='11' and betflag='O'" + (hand != "" ? " and handicap=1.5" : " ");
                            string omount = MySqlHelper.ExecuteScalar(ostr).ToString();
                            toarray += "','" + (omount == "" ? "0" : omount);
                            string ustr = "select sum(Amount) from orderdetailouhf where gameid=" + ouhf1[j].Gameid + " and BetType='11' and betflag='U'" + (hand != "" ? " and handicap=1.5" : " ");
                            string umount = MySqlHelper.ExecuteScalar(ustr).ToString();
                            toarray += "','" + (umount == "" ? "0" : umount);
                            toarray += "']";
                            pd = true;
                        }
                    }
                }
                toarray += "]";
                /*---------半场大小赔率结束-------------*/
                toarray += ",'早餐']";
            }
            toarray += "]";
            return toarray;
        }

        /// <summary>
        /// 走地
        /// </summary>
        /// <param name="languague"></param>
        /// <param name="gameid"></param>
        /// <returns></returns>
        public string getzdToHtml(string languague, string gameid)
        {
            string str = "select id,begintime,league" + languague + ",home" + languague + ",away" + languague + " from matches";
            List<int> matchid = new List<int>();
            List<string> time = new List<string>();
            List<string> league = new List<string>();
            List<string> home = new List<string>();
            List<string> away = new List<string>();
            MySqlDataReader read = MySqlHelper2.ExecuteReader(str);
            string where = "";
            if (gameid != "")
            {
                where = "where gameid in (" + gameid + ")  ";
            }
            while (read.Read())
            {
                matchid.Add(Convert.ToInt32(read.GetString("id")));
                time.Add(read.GetString("begintime"));
                league.Add(read.GetString("league" + languague));
                home.Add(read.GetString("home" + languague));
                away.Add(read.GetString("away" + languague));
            }
            /*-----------------查询走地全场让球------------------*/
            string strdshdp1 = "select id,gameid,homeodds,awayodds,allowchange,handicap from rotezdhdp1 " + where + " order by  gameid";
            List<Rotezdhdp1> hdp1 = new List<Rotezdhdp1>();
            MySqlDataReader readhdp1 = MySqlHelper.ExecuteReader(strdshdp1);
            while (readhdp1.Read())
            {
                Rotezdhdp1 rotehdp1 = new Rotezdhdp1();
                rotehdp1.Gameid = Convert.ToInt32(readhdp1.GetString("gameid"));
                rotehdp1.Id = Convert.ToInt32(readhdp1.GetString("id"));
                rotehdp1.Homeodds = Convert.ToDecimal(readhdp1.GetString("homeodds"));
                rotehdp1.Awayodds = Convert.ToDecimal(readhdp1.GetString("awayodds"));
                rotehdp1.Allowchange = Convert.ToInt32(readhdp1.GetString("allowchange"));
                rotehdp1.Handicap = readhdp1.GetString("handicap");
                hdp1.Add(rotehdp1);
            }
            /*-----------------查询走地全场让球结束------------------*/
            /*-----------------查询走地半场让球------------------*/
            string strdshdphf1 = "select id,gameid,homeodds,awayodds,allowchange,handicap from rotezdhdphf1 " + where + " order by  gameid";
            List<Rotezdhdphf1> hdphf1 = new List<Rotezdhdphf1>();
            MySqlDataReader readhdphf1 = MySqlHelper.ExecuteReader(strdshdphf1);
            while (readhdphf1.Read())
            {
                Rotezdhdphf1 rotehdphf1 = new Rotezdhdphf1();
                rotehdphf1.Gameid = Convert.ToInt32(readhdphf1.GetString("gameid"));
                rotehdphf1.Id = Convert.ToInt32(readhdphf1.GetString("id"));
                rotehdphf1.Homeodds = Convert.ToDecimal(readhdphf1.GetString("homeodds"));
                rotehdphf1.Awayodds = Convert.ToDecimal(readhdphf1.GetString("awayodds"));
                rotehdphf1.Allowchange = Convert.ToInt32(readhdphf1.GetString("allowchange"));
                rotehdphf1.Handicap = readhdphf1.GetString("handicap");
                hdphf1.Add(rotehdphf1);
            }
            /*-----------------查询走地半场让球结束------------------*/
            /*-----------------查询走地全场大小------------------*/
            string strdsou1 = "select id,gameid,homeodds,awayodds,allowchange,handicap from rotezdou1 " + where + " order by  gameid";
            List<Rotezdou1> ou1 = new List<Rotezdou1>();
            MySqlDataReader readou1 = MySqlHelper.ExecuteReader(strdsou1);
            while (readou1.Read())
            {
                Rotezdou1 roteou1 = new Rotezdou1();
                roteou1.Gameid = Convert.ToInt32(readou1.GetString("gameid"));
                roteou1.Id = Convert.ToInt32(readou1.GetString("id"));
                roteou1.Homeodds = Convert.ToDecimal(readou1.GetString("homeodds"));
                roteou1.Awayodds = Convert.ToDecimal(readou1.GetString("awayodds"));
                roteou1.Allowchange = Convert.ToInt32(readou1.GetString("allowchange"));
                roteou1.Handicap = readou1.GetString("handicap");
                ou1.Add(roteou1);
            }
            /*-----------------查询走地全场大小结束------------------*/
            /*-----------------查询走地半场大小------------------*/
            string strdsouhf1 = "select id,gameid,homeodds,awayodds,allowchange,handicap from rotezdouhf1 " + where + " order by  gameid";
            List<Rotezdouhf1> ouhf1 = new List<Rotezdouhf1>();
            MySqlDataReader readouhf1 = MySqlHelper.ExecuteReader(strdsouhf1);
            while (readouhf1.Read())
            {
                Rotezdouhf1 roteouhf1 = new Rotezdouhf1();
                roteouhf1.Gameid = Convert.ToInt32(readouhf1.GetString("gameid"));
                roteouhf1.Id = Convert.ToInt32(readouhf1.GetString("id"));
                roteouhf1.Homeodds = Convert.ToDecimal(readouhf1.GetString("homeodds"));
                roteouhf1.Awayodds = Convert.ToDecimal(readouhf1.GetString("awayodds"));
                roteouhf1.Allowchange = Convert.ToInt32(readouhf1.GetString("allowchange"));
                roteouhf1.Handicap = readouhf1.GetString("handicap");
                ouhf1.Add(roteouhf1);
            }
            /*-----------------查询走地半场大小结束------------------*/
            /*-----------------查询走地全场标准------------------*/
            string strds1x21 = "select id,gameid,oddshome,oddsaway,oddsdraw,allowchange from rotezd1x21 " + where + " order by  gameid";
            List<Rotezd1x21> r1x21 = new List<Rotezd1x21>();
            MySqlDataReader read1x21 = MySqlHelper.ExecuteReader(strds1x21);
            while (read1x21.Read())
            {
                Rotezd1x21 rote1x21 = new Rotezd1x21();
                rote1x21.Gameid = Convert.ToInt32(read1x21.GetString("gameid"));
                rote1x21.Id = Convert.ToInt32(read1x21.GetString("id"));
                rote1x21.Oddshome = Convert.ToDecimal(read1x21.GetString("oddshome"));
                rote1x21.Oddsaway = Convert.ToDecimal(read1x21.GetString("oddsaway"));
                rote1x21.Oddsdraw = Convert.ToDecimal(read1x21.GetString("oddsdraw"));
                rote1x21.Allowchange = Convert.ToInt32(read1x21.GetString("allowchange"));
                r1x21.Add(rote1x21);
            }
            /*-----------------查询走地全场标准结束------------------*/
            /*-----------------查询走地半场标准------------------*/
            string strds1x2hf1 = "select id,gameid,oddshome,oddsaway,oddsdraw,allowchange from rotezd1x2hf1 " + where + " order by  gameid";
            List<Rotezd1x2hf1> r1x2hf1 = new List<Rotezd1x2hf1>();
            MySqlDataReader read1x2hf1 = MySqlHelper.ExecuteReader(strds1x2hf1);
            while (read1x2hf1.Read())
            {
                Rotezd1x2hf1 rote1x2hf1 = new Rotezd1x2hf1();
                rote1x2hf1.Gameid = Convert.ToInt32(read1x2hf1.GetString("gameid"));
                rote1x2hf1.Id = Convert.ToInt32(read1x2hf1.GetString("id"));
                rote1x2hf1.Oddshome = Convert.ToDecimal(read1x2hf1.GetString("oddshome"));
                rote1x2hf1.Oddsaway = Convert.ToDecimal(read1x2hf1.GetString("oddsaway"));
                rote1x2hf1.Oddsdraw = Convert.ToDecimal(read1x2hf1.GetString("oddsdraw"));
                rote1x2hf1.Allowchange = Convert.ToInt32(read1x2hf1.GetString("allowchange"));
                r1x2hf1.Add(rote1x2hf1);
            }
            /*-----------------查询走地半场标准结束------------------*/
            string toarray = "[";
            for (int i = 0; i < matchid.Count; i++)
            {
                if (i > 0)
                {
                    toarray += ",";
                }
                toarray += "[";
                toarray += "'" + matchid[i];
                toarray += "','" + time[i];
                toarray += "','" + league[i];
                toarray += "','" + home[i];
                toarray += "','" + away[i];
                toarray += "',";
                /*---------全场标准赔率-------------*/
                toarray += "[";
                if (i < r1x21.Count)
                {
                    bool pd = false;
                    for (int j = 0; j < r1x21.Count; j++)
                    {
                        if (r1x21[j].Gameid == matchid[i])
                        {
                            if (pd)
                            {
                                toarray += ",";
                            }
                            toarray += "[";
                            toarray += "'" + r1x21[j].Id;
                            toarray += "','" + r1x21[j].Gameid;
                            toarray += "','" + r1x21[j].Oddshome;
                            toarray += "','" + r1x21[j].Oddsaway;
                            toarray += "','" + r1x21[j].Oddsdraw;
                            toarray += "','" + r1x21[j].Allowchange;
                            string Hstr = "select sum(Amount) from orderdetail1x2l where gameid=" + r1x21[j].Gameid + " and betflag='1'";
                            string munt1 = MySqlHelper.ExecuteScalar(Hstr).ToString();
                            toarray += "','" + (munt1 == "" ? "0" : munt1);
                            string Astr = "select sum(Amount) from orderdetail1x2l where gameid=" + r1x21[j].Gameid + " and betflag='2'";
                            string munt2 = MySqlHelper.ExecuteScalar(Astr).ToString();
                            toarray += "','" + (munt2 == "" ? "0" : munt2);
                            string Xstr = "select sum(Amount) from orderdetail1x2l where gameid=" + r1x21[j].Gameid + " and betflag='X'";
                            string muntX = MySqlHelper.ExecuteScalar(Xstr).ToString();
                            toarray += "','" + (muntX == "" ? "0" : muntX);
                            toarray += "']";
                            pd = true;
                        }
                    }
                }
                toarray += "]";
                toarray += ",";
                /*---------全场标准赔率结束-------------*/
                /*---------全场让球赔率-------------*/
                toarray += "[";
                if (i < hdp1.Count)
                {
                    bool pd = false;
                    for (int j = 0; j < hdp1.Count; j++)
                    {
                        if (hdp1[j].Gameid == matchid[i])
                        {
                            if (pd)
                            {
                                toarray += ",";
                            }
                            toarray += "[";
                            toarray += "'" + hdp1[j].Id;
                            toarray += "','" + hdp1[j].Gameid;
                            toarray += "','" + hdp1[j].Homeodds;
                            toarray += "','" + hdp1[j].Awayodds;
                            toarray += "','" + hdp1[j].Handicap;
                            toarray += "','" + hdp1[j].Allowchange;
                            string amount1 = hdp1[j].Handicap.IndexOf("/") == -1 ? hdp1[j].Handicap : ((double.Parse(hdp1[j].Handicap.Substring(0, hdp1[j].Handicap.IndexOf("/"))) + double.Parse(hdp1[j].Handicap.Substring(hdp1[j].Handicap.IndexOf("/") + 1))) / 2).ToString();
                            string amountcount = "select sum(Amount) from orderdetailhdpl where gameid=" + hdp1[j].Gameid + " and BetType='8' and betflag='H'" + (amount1 != "" ? " and (handicap=" + amount1 + " or handicap=-" + amount1 + ")" : " ");
                            string Hmount = MySqlHelper.ExecuteScalar(amountcount).ToString();
                            toarray += "','" + (Hmount == "" ? "0" : Hmount);
                            string amountcount1 = "select sum(Amount) from orderdetailhdpl where gameid=" + hdp1[j].Gameid + " and BetType='8' and betflag='A'" + (amount1 != "" ? " and (handicap=" + amount1 + " or handicap=-" + amount1 + ")" : " ");
                            string AmountA = MySqlHelper.ExecuteScalar(amountcount1).ToString();
                            toarray += "','" + (AmountA == "" ? "0" : AmountA);
                            toarray += "']";
                            pd = true;
                        }
                    }
                }
                toarray += "]";
                toarray += ",";
                /*---------全场让球赔率结束-------------*/
                /*---------全场大小赔率-------------*/
                toarray += "[";
                if (i < ou1.Count)
                {
                    bool pd = false;
                    for (int j = 0; j < ou1.Count; j++)
                    {
                        if (ou1[j].Gameid == matchid[i])
                        {
                            if (pd)
                            {
                                toarray += ",";
                            }
                            toarray += "[";
                            toarray += "'" + ou1[j].Id;
                            toarray += "','" + ou1[j].Gameid;
                            toarray += "','" + ou1[j].Homeodds;
                            toarray += "','" + ou1[j].Awayodds;
                            toarray += "','" + ou1[j].Handicap;
                            toarray += "','" + ou1[j].Allowchange;
                            string hand = ou1[j].Handicap;
                            string ostr = "select sum(Amount) from orderdetailoul where gameid=" + ou1[j].Gameid + " and betflag='O'" + (hand != "" ? " and handicap=1.5" : " ");
                            string omount = MySqlHelper.ExecuteScalar(ostr).ToString();
                            toarray += "','" + (omount == "" ? "0" : omount);
                            string ustr = "select sum(Amount) from orderdetailoul where gameid=" + ou1[j].Gameid + " and betflag='U'" + (hand != "" ? " and handicap=1.5" : " ");
                            string umount = MySqlHelper.ExecuteScalar(ustr).ToString();
                            toarray += "','" + (umount == "" ? "0" : umount);
                            toarray += "']";
                            pd = true;
                        }
                    }
                }
                toarray += "]";
                toarray += ",";
                /*---------全场大小赔率结束-------------*/
                /*---------半场标准赔率-------------*/
                toarray += "[";
                if (i < r1x2hf1.Count)
                {
                    bool pd = false;
                    for (int j = 0; j < r1x2hf1.Count; j++)
                    {
                        if (r1x2hf1[j].Gameid == matchid[i])
                        {
                            if (pd)
                            {
                                toarray += ",";
                            }
                            toarray += "[";
                            toarray += "'" + r1x2hf1[j].Id;
                            toarray += "','" + r1x2hf1[j].Gameid;
                            toarray += "','" + r1x2hf1[j].Oddshome;
                            toarray += "','" + r1x2hf1[j].Oddsaway;
                            toarray += "','" + r1x2hf1[j].Oddsdraw;
                            toarray += "','" + r1x2hf1[j].Allowchange;
                            string Hstr = "select sum(Amount) from orderdetail1x2hf where gameid=" + r1x2hf1[j].Gameid + " and BetType='13' and betflag='1'";
                            string munt1 = MySqlHelper.ExecuteScalar(Hstr).ToString();
                            toarray += "','" + (munt1 == "" ? "0" : munt1);
                            string Astr = "select sum(Amount) from orderdetail1x2hf where gameid=" + r1x2hf1[j].Gameid + " and BetType='13' and betflag='2'";
                            string munt2 = MySqlHelper.ExecuteScalar(Astr).ToString();
                            toarray += "','" + (munt2 == "" ? "0" : munt2);
                            string Xstr = "select sum(Amount) from orderdetail1x2hf where gameid=" + r1x2hf1[j].Gameid + " and BetType='13' and betflag='X'";
                            string muntX = MySqlHelper.ExecuteScalar(Xstr).ToString();
                            toarray += "','" + (muntX == "" ? "0" : muntX);
                            toarray += "']";
                            pd = true;
                        }
                    }
                }
                toarray += "]";
                toarray += ",";
                /*---------半场标准赔率结束-------------*/
                /*---------半场让球赔率-------------*/
                toarray += "[";
                if (i < hdphf1.Count)
                {
                    bool pd = false;
                    for (int j = 0; j < hdphf1.Count; j++)
                    {
                        if (hdphf1[j].Gameid == matchid[i])
                        {
                            if (pd)
                            {
                                toarray += ",";
                            }
                            toarray += "[";
                            toarray += "'" + hdphf1[j].Id;
                            toarray += "','" + hdphf1[j].Gameid;
                            toarray += "','" + hdphf1[j].Homeodds;
                            toarray += "','" + hdphf1[j].Awayodds;
                            toarray += "','" + hdphf1[j].Handicap;
                            toarray += "','" + hdphf1[j].Allowchange;
                            string amount1 = hdphf1[j].Handicap.IndexOf("/") == -1 ? hdphf1[j].Handicap : ((double.Parse(hdphf1[j].Handicap.Substring(0, hdphf1[j].Handicap.IndexOf("/"))) + double.Parse(hdphf1[j].Handicap.Substring(hdphf1[j].Handicap.IndexOf("/") + 1))) / 2).ToString();
                            string amountcount = "select sum(Amount) from orderdetailhdphfl where gameid=" + hdphf1[j].Gameid + " and betflag='H'" + (amount1 != "" ? " and (handicap=" + amount1 + " or handicap=-" + amount1 + ")" : " ");
                            string Hmount = MySqlHelper.ExecuteScalar(amountcount).ToString();
                            toarray += "','" + (Hmount == "" ? "0" : Hmount);
                            string amountcount1 = "select sum(Amount) from orderdetailhdphfl where gameid=" + hdphf1[j].Gameid + " and betflag='A'" + (amount1 != "" ? " and (handicap=" + amount1 + " or handicap=-" + amount1 + ")" : " ");
                            string AmountA = MySqlHelper.ExecuteScalar(amountcount1).ToString();
                            toarray += "','" + (AmountA == "" ? "0" : AmountA);
                            toarray += "']";
                            pd = true;
                        }
                    }
                }
                toarray += "]";
                toarray += ",";
                /*---------半场让球赔率结束-------------*/

                /*---------半场大小赔率-------------*/
                toarray += "[";
                if (i < ouhf1.Count)
                {
                    bool pd = false;
                    for (int j = 0; j < ouhf1.Count; j++)
                    {
                        if (ouhf1[j].Gameid == matchid[i])
                        {
                            if (pd)
                            {
                                toarray += ",";
                            }
                            toarray += "[";
                            toarray += "'" + ouhf1[j].Id;
                            toarray += "','" + ouhf1[j].Gameid;
                            toarray += "','" + ouhf1[j].Homeodds;
                            toarray += "','" + ouhf1[j].Awayodds;
                            toarray += "','" + ouhf1[j].Handicap;
                            toarray += "','" + ouhf1[j].Allowchange;
                            string hand = ouhf1[j].Handicap;
                            string ostr = "select sum(Amount) from orderdetailouhfl where gameid=" + ouhf1[j].Gameid + " and betflag='O'" + (hand != "" ? " and handicap=1.5" : " ");
                            string omount = MySqlHelper.ExecuteScalar(ostr).ToString();
                            toarray += "','" + (omount == "" ? "0" : omount);
                            string ustr = "select sum(Amount) from orderdetailouhfl where gameid=" + ouhf1[j].Gameid + " and betflag='U'" + (hand != "" ? " and handicap=1.5" : " ");
                            string umount = MySqlHelper.ExecuteScalar(ustr).ToString();
                            toarray += "','" + (umount == "" ? "0" : umount);
                            toarray += "']";
                            pd = true;
                        }
                    }
                }
                toarray += "]";
                /*---------半场大小赔率结束-------------*/
                toarray += ",'走地']";
            }
            toarray += "]";
            return toarray;
        }
        #endregion
    }
}
