using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
    public class MatchesService
    {
        private const string SQL_INSERT = "insert into yafa.matches (number,matchid,leaguecn,leaguetw,leagueen,leagueth,leaguevn,league1,color,time,begintime,homecn,hometw,homeen,hometh,homevn,home1,awaycn,awaytw,awayen,awayth,awayvn,away1,running,score,redcard,danger,dotime,isstart,state,display,resulthomescore,resultawayscore,halfhomescore,halfawayscore,updatetime,type,casino)values(?number,?matchid,?leaguecn,?leaguetw,?leagueen,?leagueth,?leaguevn,?league1,?color,?time,?begintime,?homecn,?hometw,?homeen,?hometh,?homevn,?home1,?awaycn,?awaytw,?awayen,?awayth,?awayvn,?away1,?running,?score,?redcard,?danger,?dotime,?isstart,?state,?display,?resulthomescore,?resultawayscore,?halfhomescore,?halfawayscore,?updatetime,?type,?casino)";
        private const string SQL_UPDATE = "update yafa.matches set number=?number,matchid=?matchid,leaguecn=?leaguecn,leaguetw=?leaguetw,leagueen=?leagueen,leagueth=?leagueth,leaguevn=?leaguevn,league1=?league1,color=?color,time=?time,begintime=?begintime,homecn=?homecn,hometw=?hometw,homeen=?homeen,hometh=?hometh,homevn=?homevn,home1=?home1,awaycn=?awaycn,awaytw=?awaytw,awayen=?awayen,awayth=?awayth,awayvn=?awayvn,away1=?away1,running=?running,score=?score,redcard=?redcard,danger=?danger,dotime=?dotime,isstart=?isstart,state=?state,display=?display,resulthomescore=?resulthomescore,resultawayscore=?resultawayscore,halfhomescore=?halfhomescore,halfawayscore=?halfawayscore,updatetime=?updatetime,type=?type,casino=?casino where id = ?id";
        private const string SQL_SELECTBYPK = "select * from yafa.matches  where matches.id = ?id";
        private const string SQL_SELECTALL = "select id,number,matchid,leaguecn,leaguetw,leagueen,leagueth,leaguevn,league1,color,time,begintime,homecn,hometw,homeen,hometh,homevn,home1,awaycn,awaytw,awayen,awayth,awayvn,away1,running,score,redcard,danger,dotime,isstart,state,display,resulthomescore,resultawayscore,halfhomescore,halfawayscore,updatetime,type,casino,reason,scoreinputtime,scoreinputuser,resulthomescore2,resultawayscore2,halfhomescore2,halfawayscore2 from yafa.matches ";
        private const string SQL_DELETEBYPK = "delete  from yafa.matches  where matches.id = ?id";

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-9-17 20:43:02		
        ///</summary>		
        public Boolean AddMatches(Matches matches)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?number",matches.Number),
				 new MySqlParameter("?matchid",matches.Matchid),
				 new MySqlParameter("?leaguecn",matches.Leaguecn),
				 new MySqlParameter("?leaguetw",matches.Leaguetw),
				 new MySqlParameter("?leagueen",matches.Leagueen),
				 new MySqlParameter("?leagueth",matches.Leagueth),
				 new MySqlParameter("?leaguevn",matches.Leaguevn),
				 new MySqlParameter("?league1",matches.League1),
				 new MySqlParameter("?color",matches.Color),
				 new MySqlParameter("?time",matches.Time),
				 new MySqlParameter("?begintime",matches.Begintime),
				 new MySqlParameter("?homecn",matches.Homecn),
				 new MySqlParameter("?hometw",matches.Hometw),
				 new MySqlParameter("?homeen",matches.Homeen),
				 new MySqlParameter("?hometh",matches.Hometh),
				 new MySqlParameter("?homevn",matches.Homevn),
				 new MySqlParameter("?home1",matches.Home1),
				 new MySqlParameter("?awaycn",matches.Awaycn),
				 new MySqlParameter("?awaytw",matches.Awaytw),
				 new MySqlParameter("?awayen",matches.Awayen),
				 new MySqlParameter("?awayth",matches.Awayth),
				 new MySqlParameter("?awayvn",matches.Awayvn),
				 new MySqlParameter("?away1",matches.Away1),
				 new MySqlParameter("?running",matches.Running),
				 new MySqlParameter("?score",matches.Score),
				 new MySqlParameter("?redcard",matches.Redcard),
				 new MySqlParameter("?danger",matches.Danger),
				 new MySqlParameter("?dotime",matches.Dotime),
				 new MySqlParameter("?isstart",matches.Isstart),
				 new MySqlParameter("?state",matches.State),
				 new MySqlParameter("?display",matches.Display),
				 new MySqlParameter("?resulthomescore",matches.Resulthomescore),
				 new MySqlParameter("?resultawayscore",matches.Resultawayscore),
				 new MySqlParameter("?halfhomescore",matches.Halfhomescore),
				 new MySqlParameter("?halfawayscore",matches.Halfawayscore),
				 new MySqlParameter("?updatetime",matches.Updatetime),
				 new MySqlParameter("?type",matches.Type),
				 new MySqlParameter("?casino",matches.Casino)
			};
            return MySqlHelper2.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-9-17 20:43:02		
        ///</summary>		
        public Boolean UpdateMatches(Matches matches)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?number",matches.Number),
				 new MySqlParameter("?matchid",matches.Matchid),
				 new MySqlParameter("?leaguecn",matches.Leaguecn),
				 new MySqlParameter("?leaguetw",matches.Leaguetw),
				 new MySqlParameter("?leagueen",matches.Leagueen),
				 new MySqlParameter("?leagueth",matches.Leagueth),
				 new MySqlParameter("?leaguevn",matches.Leaguevn),
				 new MySqlParameter("?league1",matches.League1),
				 new MySqlParameter("?color",matches.Color),
				 new MySqlParameter("?time",matches.Time),
				 new MySqlParameter("?begintime",matches.Begintime),
				 new MySqlParameter("?homecn",matches.Homecn),
				 new MySqlParameter("?hometw",matches.Hometw),
				 new MySqlParameter("?homeen",matches.Homeen),
				 new MySqlParameter("?hometh",matches.Hometh),
				 new MySqlParameter("?homevn",matches.Homevn),
				 new MySqlParameter("?home1",matches.Home1),
				 new MySqlParameter("?awaycn",matches.Awaycn),
				 new MySqlParameter("?awaytw",matches.Awaytw),
				 new MySqlParameter("?awayen",matches.Awayen),
				 new MySqlParameter("?awayth",matches.Awayth),
				 new MySqlParameter("?awayvn",matches.Awayvn),
				 new MySqlParameter("?away1",matches.Away1),
				 new MySqlParameter("?running",matches.Running),
				 new MySqlParameter("?score",matches.Score),
				 new MySqlParameter("?redcard",matches.Redcard),
				 new MySqlParameter("?danger",matches.Danger),
				 new MySqlParameter("?dotime",matches.Dotime),
				 new MySqlParameter("?isstart",matches.Isstart),
				 new MySqlParameter("?state",matches.State),
				 new MySqlParameter("?display",matches.Display),
				 new MySqlParameter("?resulthomescore",matches.Resulthomescore),
				 new MySqlParameter("?resultawayscore",matches.Resultawayscore),
				 new MySqlParameter("?halfhomescore",matches.Halfhomescore),
				 new MySqlParameter("?halfawayscore",matches.Halfawayscore),
				 new MySqlParameter("?updatetime",matches.Updatetime),
				 new MySqlParameter("?type",matches.Type),
				 new MySqlParameter("?casino",matches.Casino),
				 new MySqlParameter("?id",matches.Id)
			};
            return MySqlHelper2.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-9-17 20:43:02		
        ///</summary>		
        public Boolean DeleteMatchesByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};
            return MySqlHelper2.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2010-9-17 20:43:02		
        ///</summary>		
        public Matches GetMatchesByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};

            return MySqlModelHelper2<Matches>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2010-9-17 20:43:02		
        ///</summary>		
        public IList<Matches> GetMutilILMatches()
        {
            return MySqlModelHelper2<Matches>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2010-9-17 20:43:02		
        ///</summary>		
        public DataTable GetMutilDTMatches()
        {
            return MySqlHelper2.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion

        #region 编写人:李毅
        ///<summary>		
        ///根据ID获得所有数据，返回泛型集合		
        ///生成时间：2010-9-17 21:43:00		
        ///</summary>		
        public IList<Matches> GetMutilILMatches(int id)
        {
            string str = SQL_SELECTALL + " where id=@id";
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("@id",id)
            };
            return MySqlModelHelper2<Matches>.GetObjectsBySql(str, param);
        }



        /// <summary>
        /// 查询所有数据并根据number排序
        /// </summary>
        /// <returns></returns>
        public string GetAllToJson1(string language)
        {
            string leauge = "leaguecn";
            string home = "homecn";
            string away = "awaycn";
            string time = DateTime.Now.ToString("yyyy-MM-dd");
            if (language != null)
            {
                leauge = "league" + language;
                home = "home" + language;
                away = "away" + language;
            }
            string str = "select id as a," + leauge + " as b,time as i,begintime as j," + home + " as c," + away + " as d,resulthomescore as e,resultawayscore as f,halfhomescore as g,halfawayscore as h,resulthomescore2,resultawayscore2,halfhomescore2,halfawayscore2 from yafa.matches where date(begintime)='" + time + "'  order by begintime," + leauge;
            string json = string.Empty;
            using (MySqlDataReader reader = MySqlHelper2.ExecuteReader(str))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "]" ? string.Empty : json;
        }

        public string GetAllToJson2(string language, string first, string end)
        {
            string str = "select id,number,state,redcard,display,danger,leaguecn,leaguetw,leagueen,leagueth,leaguevn,time,begintime,homecn,hometw,homeen,hometh,homevn,awaycn,awaytw,awayen,awayth,awayvn,score,running,color,resulthomescore,resultawayscore,halfhomescore,halfawayscore,type,casino from yafa.matches " + "order by number limit " + first + "," + end;
            string json = "[";
            MySqlDataReader read = MySqlHelper2.ExecuteReader(str);
            bool pd = false;
            while (read.Read())
            {
                if (pd)
                {
                    json += ",";
                }
                json += "[";
                json += "'" + read.GetString("id") + "',";//0
                json += "'" + read.GetString("number") + "',";//1
                json += "'" + read.GetString("league" + language) + "',";//2
                if (read.GetString("color").IndexOf("#") != -1)
                {
                    json += "'" + read.GetString("color") + "',";//3
                }
                else
                {
                    string[] color = read.GetString("color").Split('.');
                    string color1 = "";
                    color1 = "#" + ((int.Parse(color[0])).ToString("X").Length == 1 ? "0" + (int.Parse(color[0])).ToString("X") : (int.Parse(color[0])).ToString("X"));
                    color1 += ((int.Parse(color[1])).ToString("X").Length == 1 ? "0" + (int.Parse(color[1])).ToString("X") : (int.Parse(color[1])).ToString("X"));
                    color1 += ((int.Parse(color[2])).ToString("X").Length == 1 ? "0" + (int.Parse(color[2])).ToString("X") : (int.Parse(color[2])).ToString("X"));
                    json += "'" + color1 + "',";//3
                }
                json += "'" + read.GetString("time") + "',";//4
                json += "'" + read.GetString("begintime") + "',";//5
                json += "'" + read.GetString("home" + language) + "',";//6
                json += "'" + read.GetString("away" + language) + "',";//7
                json += "'" + read.GetString("running") + "',";//8
                if (DateTime.Parse(read.GetString("begintime")) > DateTime.Now)
                {
                    json += "' ',";//9
                }
                else
                {
                    json += "'" + read.GetString("score") + "',";//9
                }
                json += "'" + read.GetString("redcard") + "',";//10
                json += "'" + read.GetString("danger") + "',";//11
                json += "'" + read.GetString("state") + "',";//12
                json += "'" + read.GetString("display") + "',";//13
                json += "'" + read.GetString("resulthomescore") + "',";//14
                json += "'" + read.GetString("resultawayscore") + "',";//15
                json += "'" + read.GetString("halfhomescore") + "',";//16
                json += "'" + read.GetString("halfawayscore") + "',";//17
                json += "'" + read.GetString("type") + "',";//18
                json += "'" + read.GetString("casino") + "'";//19
                json += "]";
                if (!pd)
                {
                    pd = true;
                }
            }
            json += "]";
            return json;
        }

        public string GetAllToJson3(string language)
        {
            string leauge = "leaguecn";
            string home = "homecn";
            string away = "awaycn";
            string beginTime = DateTime.Now.ToString("yyyy-MM-dd");
            if (language != null)
            {
                leauge = "league" + language;
                home = "home" + language;
                away = "away" + language;
            }
            string str = "select id as a," + leauge + " as b,time as i,begintime as j," + home + " as c," + away + " as d,resulthomescore as e,resultawayscore as f,halfhomescore as g,halfawayscore as h from yafa.matches where date(begintime)='" + beginTime + "' order by begintime," + leauge;
            string json = string.Empty;
            using (MySqlDataReader reader = MySqlHelper2.ExecuteReader(str))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "]" ? string.Empty : json;
        }

        public string GetAllToJson4(string language, string time)
        {
            string leauge = "leaguecn";
            string home = "homecn";
            string away = "awaycn";
            time = DateTime.Now.Year + "-" + time;
            if (language != null)
            {
                leauge = "league" + language;
                home = "home" + language;
                away = "away" + language;
            }
            string str = "select id as a," + leauge + " as b,time as i,begintime as j," + home + " as c," + away + " as d,resulthomescore as e,resultawayscore as f,halfhomescore as g,halfawayscore as h,resulthomescore2,resultawayscore2,halfhomescore2,halfawayscore2 from yafa.matches where date(begintime)='" + time + "' order by begintime," + leauge;
            string json = string.Empty;
            using (MySqlDataReader reader = MySqlHelper2.ExecuteReader(str))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "]" ? string.Empty : json;
        }

        public string GetLeagueByWhere(string language, string league, string home, string away, string beginTime, string endTime)
        {
            string leaguename = "leaguecn";
            string homename = "homecn";
            string awayname = "awaycn";
            string today = DateTime.Now.ToString("yyyy-mm-dd");
            bool flag = true;
            if (language != null)
            {
                leaguename = "league" + language;
                homename = "home" + language;
                awayname = "away" + language;
            }
            string sql = "select id as a," + leaguename + " as b,time as i,begintime as j," + homename + " as c," + awayname + " as d,resulthomescore as e,resultawayscore as f,halfhomescore as g,halfawayscore as h,resulthomescore2,resultawayscore2,halfhomescore2,halfawayscore2 from yafa.matches where 1=1 ";
            if (league != "")
            {
                flag = false;
                sql += " and " + leaguename + " like '%" + league + "%' ";
            }
            if (home != "")
            {
                flag = false;
                sql += " and " + homename + " like '%" + home + "%' ";
            }
            if (away != "")
            {
                flag = false;
                sql += " and " + awayname + " like '%" + away + "%' ";
            }
            if (beginTime != "" && endTime != "")
            {
                flag = false;
                sql += " and ('" + beginTime + "')<=date(begintime) and ('" + endTime + "')>=date(begintime)";
            }
            else
            {
                if (beginTime != "")
                {
                    flag = false;
                    sql += " and date(begintime)='" + beginTime + "'";
                }
                if (endTime != "")
                {
                    flag = false;
                    sql += " and date(begintime)='" + endTime + "'";
                }
            }
            if (flag)
            {
                sql += " and date(begintime)='" + today + "'";
            }
            sql += " order by begintime," + leaguename;
            string json = string.Empty;
            using (MySqlDataReader reader = MySqlHelper2.ExecuteReader(sql))
            {
                json = ObjectToJson.ReaderToJson(reader);
                reader.Close();
            }
            return json == "]" ? string.Empty : json;
        }

        /// <summary>
        /// 比分录入
        /// </summary>
        /// <param name="home">主队全场比分</param>
        /// <param name="away">客队全场比分</param>
        /// <param name="halfhome">主队半场比分</param>
        /// <param name="halfaway">客队半场比分</param>
        /// <returns></returns>
        public Boolean updatescore(string id, string home, string away, string halfhome, string halfaway, DateTime scoreinputtime, string scoreinputuser)
        {
            string str = "update yafa.matches set resulthomescore=?resulthomescore,resultawayscore=?resultawayscore,halfhomescore=?halfhomescore,halfawayscore=?halfawayscore,display=0,scoreinputtime=?scoreinputtime,scoreinputuser=?scoreinputuser where id = ?id";
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?resulthomescore",home),
				 new MySqlParameter("?resultawayscore",away),
				 new MySqlParameter("?halfhomescore",halfhome),
				 new MySqlParameter("?halfawayscore",halfaway),
                 new MySqlParameter("?scoreinputtime",scoreinputtime),
				 new MySqlParameter("?scoreinputuser",scoreinputuser),
				 new MySqlParameter("?id",id)
			};
            return MySqlHelper2.ExecuteNonQuery(str, param) > 0;
        }


        public Boolean updateInfo(string id, string time, string leaguecolor, string leaguetype, string display, string running, string score,
            string redcard, string danger, string number)
        {
            //string str = "update yafa.matches set ";
            //match.Color = leaguecolor;
            //match.Type = int.Parse(leaguetype);
            //match.Display = int.Parse(display);
            //match.Running = int.Parse(running);
            //match.Number = int.Parse(number);
            //    match.Score = score;
            //    match.Danger = int.Parse(danger);
            //    match.Redcard = redcard;
            //match.Begintime = DateTime.Now;
            //match.Time = time.Substring(5, time.Length - 3);
            return true;
        }

        public string GetCount()
        {
            string str = "select count(*) as zs from yafa.matches";
            return ObjectToJson.ReaderToJson(MySqlHelper2.ExecuteReader(str));
        }

        /// <summary>
        /// 查询联赛信息
        /// </summary>
        /// <returns></returns>
        public string GetLeagueToJson(string language)
        {
            string str = "select DISTINCT league" + language + " from matches";
            string json = "[";
            MySqlDataReader read = MySqlHelper2.ExecuteReader(str);
            bool pd = false;
            while (read.Read())
            {
                if (pd)
                {
                    json += ",";
                }
                json += "{";
                json += "\"league\":\"" + read.GetString("league" + language) + "\"";
                json += "}";
                if (!pd)
                {
                    pd = true;
                }
            }
            json += "]";
            return json;
        }

        /// <summary>
        /// 查询对战球队信息
        /// </summary>
        /// <returns></returns>
        public string GetBollToJson(string language)
        {
            string str = "select DISTINCT id,home" + language + ",away" + language + ",matchid from matches";
            string json = "[";
            MySqlDataReader read = MySqlHelper2.ExecuteReader(str);
            bool pd = false;
            while (read.Read())
            {
                if (pd)
                {
                    json += ",";
                }
                json += "{";
                json += "\"id\":\"" + read.GetString("id") + "\",";
                json += "\"home\":\"" + read.GetString("home" + language) + "\",";
                json += "\"away\":\"" + read.GetString("away" + language) + "\",";
                json += "\"matchid\":\"" + read.GetString("matchid") + "\"";
                json += "}";
                if (!pd)
                {
                    pd = true;
                }
            }
            json += "]";
            return json;
        }

        /// <summary>
        /// 查询对战球队信息
        /// </summary>
        /// <returns></returns>
        public string GetBollToJson1(string language)
        {
            string str = "select DISTINCT home" + language + ",away" + language + ",matchid from matches where display=1";
            string json = "[";
            MySqlDataReader read = MySqlHelper2.ExecuteReader(str);
            bool pd = false;
            while (read.Read())
            {
                if (pd)
                {
                    json += ",";
                }
                json += "{";
                json += "\"home\":\"" + read.GetString("home" + language) + "\",";
                json += "\"away\":\"" + read.GetString("away" + language) + "\",";
                json += "\"matchid\":\"" + read.GetString("matchid") + "\"";
                json += "}";
                if (!pd)
                {
                    pd = true;
                }
            }
            json += "]";
            return json;
        }
        #endregion

        public string GetUserLevel(string lan)
        {
            string str = "select id as a,LevelName" + lan + " as b from yafa.grade";
            return ObjectToJson.ReaderToJson(MySqlHelper2.ExecuteReader(str));
        }

    }
}
