using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class OrderotherService
	{
		private const string SQL_INSERT="insert into yafa.orderother (UserName,WebUserName,OrderID,WebOrderID,time,leaguecn,leaguetw,leagueen,leagueth,leaguevn,BeginTime,BetType,IsHalf,BetItem,Score,Awaycn,Awaytw,Awayen,Awayth,Awayvn,Homecn,Hometw,Homeen,Hometh,Homevn,Handicap,OddsType,Odds,Amount,ValidAmount,Status,WebSiteiID,agent,websitepossess,selfpossess,commission,multiple,gameid)values(?UserName,?WebUserName,?OrderID,?WebOrderID,?time,?leaguecn,?leaguetw,?leagueen,?leagueth,?leaguevn,?BeginTime,?BetType,?IsHalf,?BetItem,?Score,?Awaycn,?Awaytw,?Awayen,?Awayth,?Awayvn,?Homecn,?Hometw,?Homeen,?Hometh,?Homevn,?Handicap,?OddsType,?Odds,?Amount,?ValidAmount,?Status,?WebSiteiID,?agent,?websitepossess,?selfpossess,?commission,?multiple,?gameid)";
		private const string SQL_UPDATE="update yafa.orderother set UserName=?UserName,WebUserName=?WebUserName,OrderID=?OrderID,WebOrderID=?WebOrderID,time=?time,leaguecn=?leaguecn,leaguetw=?leaguetw,leagueen=?leagueen,leagueth=?leagueth,leaguevn=?leaguevn,BeginTime=?BeginTime,BetType=?BetType,IsHalf=?IsHalf,BetItem=?BetItem,Score=?Score,Awaycn=?Awaycn,Awaytw=?Awaytw,Awayen=?Awayen,Awayth=?Awayth,Awayvn=?Awayvn,Homecn=?Homecn,Hometw=?Hometw,Homeen=?Homeen,Hometh=?Hometh,Homevn=?Homevn,Handicap=?Handicap,OddsType=?OddsType,Odds=?Odds,Amount=?Amount,ValidAmount=?ValidAmount,Status=?Status,WebSiteiID=?WebSiteiID,agent=?agent,websitepossess=?websitepossess,selfpossess=?selfpossess,commission=?commission,multiple=?multiple,gameid=?gameid where ID = ?ID";
		private const string SQL_SELECTBYPK="select ID from yafa.orderother  where orderother.ID = ?ID";
		private const string SQL_SELECTALL="select * from yafa.orderother ";
		private const string SQL_DELETEBYPK="delete  from yafa.orderother  where orderother.ID = ?ID";
		
		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-9-24 21:04:12		
		///</summary>		
		public Boolean AddOrderother(Orderother orderother)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderother.UserName),
				 new MySqlParameter("?WebUserName",orderother.WebUserName),
				 new MySqlParameter("?OrderID",orderother.OrderID),
				 new MySqlParameter("?WebOrderID",orderother.WebOrderID),
				 new MySqlParameter("?time",orderother.Time),
				 new MySqlParameter("?leaguecn",orderother.Leaguecn),
				 new MySqlParameter("?leaguetw",orderother.Leaguetw),
				 new MySqlParameter("?leagueen",orderother.Leagueen),
				 new MySqlParameter("?leagueth",orderother.Leagueth),
				 new MySqlParameter("?leaguevn",orderother.Leaguevn),
				 new MySqlParameter("?BeginTime",orderother.BeginTime),
				 new MySqlParameter("?BetType",orderother.BetType),
				 new MySqlParameter("?IsHalf",orderother.IsHalf),
				 new MySqlParameter("?BetItem",orderother.BetItem),
				 new MySqlParameter("?Score",orderother.Score),
				 new MySqlParameter("?Awaycn",orderother.Awaycn),
				 new MySqlParameter("?Awaytw",orderother.Awaytw),
				 new MySqlParameter("?Awayen",orderother.Awayen),
				 new MySqlParameter("?Awayth",orderother.Awayth),
				 new MySqlParameter("?Awayvn",orderother.Awayvn),
				 new MySqlParameter("?Homecn",orderother.Homecn),
				 new MySqlParameter("?Hometw",orderother.Hometw),
				 new MySqlParameter("?Homeen",orderother.Homeen),
				 new MySqlParameter("?Hometh",orderother.Hometh),
				 new MySqlParameter("?Homevn",orderother.Homevn),
				 new MySqlParameter("?Handicap",orderother.Handicap),
				 new MySqlParameter("?OddsType",orderother.OddsType),
				 new MySqlParameter("?Odds",orderother.Odds),
				 new MySqlParameter("?Amount",orderother.Amount),
				 new MySqlParameter("?ValidAmount",orderother.ValidAmount),
				 new MySqlParameter("?Status",orderother.Status),
				 new MySqlParameter("?WebSiteiID",orderother.WebSiteiID),
				 new MySqlParameter("?agent",orderother.Agent),
				 new MySqlParameter("?websitepossess",orderother.Websitepossess),
				 new MySqlParameter("?selfpossess",orderother.Selfpossess),
				 new MySqlParameter("?commission",orderother.Commission),
				 new MySqlParameter("?multiple",orderother.Multiple),
				 new MySqlParameter("?gameid",orderother.Gameid)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-9-24 21:04:12		
		///</summary>		
		public Boolean UpdateOrderother(Orderother orderother)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?UserName",orderother.UserName),
				 new MySqlParameter("?WebUserName",orderother.WebUserName),
				 new MySqlParameter("?OrderID",orderother.OrderID),
				 new MySqlParameter("?WebOrderID",orderother.WebOrderID),
				 new MySqlParameter("?time",orderother.Time),
				 new MySqlParameter("?leaguecn",orderother.Leaguecn),
				 new MySqlParameter("?leaguetw",orderother.Leaguetw),
				 new MySqlParameter("?leagueen",orderother.Leagueen),
				 new MySqlParameter("?leagueth",orderother.Leagueth),
				 new MySqlParameter("?leaguevn",orderother.Leaguevn),
				 new MySqlParameter("?BeginTime",orderother.BeginTime),
				 new MySqlParameter("?BetType",orderother.BetType),
				 new MySqlParameter("?IsHalf",orderother.IsHalf),
				 new MySqlParameter("?BetItem",orderother.BetItem),
				 new MySqlParameter("?Score",orderother.Score),
				 new MySqlParameter("?Awaycn",orderother.Awaycn),
				 new MySqlParameter("?Awaytw",orderother.Awaytw),
				 new MySqlParameter("?Awayen",orderother.Awayen),
				 new MySqlParameter("?Awayth",orderother.Awayth),
				 new MySqlParameter("?Awayvn",orderother.Awayvn),
				 new MySqlParameter("?Homecn",orderother.Homecn),
				 new MySqlParameter("?Hometw",orderother.Hometw),
				 new MySqlParameter("?Homeen",orderother.Homeen),
				 new MySqlParameter("?Hometh",orderother.Hometh),
				 new MySqlParameter("?Homevn",orderother.Homevn),
				 new MySqlParameter("?Handicap",orderother.Handicap),
				 new MySqlParameter("?OddsType",orderother.OddsType),
				 new MySqlParameter("?Odds",orderother.Odds),
				 new MySqlParameter("?Amount",orderother.Amount),
				 new MySqlParameter("?ValidAmount",orderother.ValidAmount),
				 new MySqlParameter("?Status",orderother.Status),
				 new MySqlParameter("?WebSiteiID",orderother.WebSiteiID),
				 new MySqlParameter("?agent",orderother.Agent),
				 new MySqlParameter("?websitepossess",orderother.Websitepossess),
				 new MySqlParameter("?selfpossess",orderother.Selfpossess),
				 new MySqlParameter("?commission",orderother.Commission),
				 new MySqlParameter("?multiple",orderother.Multiple),
				 new MySqlParameter("?gameid",orderother.Gameid),
				 new MySqlParameter("?ID",orderother.ID)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-9-24 21:04:12		
		///</summary>		
		public Boolean DeleteOrderotherByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2010-9-24 21:04:12		
		///</summary>		
		public Orderother GetOrderotherByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

			return MySqlModelHelper<Orderother>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2010-9-24 21:04:12		
		///</summary>		
		public IList<Orderother> GetMutilILOrderother()
		{
			return MySqlModelHelper<Orderother>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2010-9-24 21:04:12		
		///</summary>		
		public DataTable GetMutilDTOrderother()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 

        #region 编写人:李毅
        public string GetAllTolength(string length, string league, string type, string money, string ballteam, string language,string username,string roid)
        {
            string str = "select * from orderother where 1=1 ";
            //if (username != "" && roid != "")
            //{
            //    str += " and " + roid + "='" + username + "'";
            //}
            if (type != "-1")
            {
                str += " and BetType=" + type;
            }
            if (money != "")
            {
                str += " and Amount>=" + money;
            }
            if (league != "")
            {
                str += " and league" + language + " in(" + league + ")";
            }
            if (ballteam != "")
            {
                str += " and gameid in(" + ballteam + ")";
            }
            str += " order by time desc limit 0," + length;
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        public string GetAllTolength1(string league, string type, string money, string ballteam, string language, string time1, string time2,string account)
        {
            string today = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            string str = "select * from orderother where 1=1 ";
            bool flag = true;
            if (type != "-1")
            {
                str += " and BetType=" + type;
            }
            if (money != "")
            {
                flag = false;
                str += " and Amount>=" + money;
            }
            if (league != "")
            {
                flag = false;
                str += " and league" + language + " like '%" + league + "%'";
            }
            if (ballteam != "")
            {
                flag = false;
                str += " and (Home" + language + " like '%" + ballteam + "%' or Away" + language + " like '%" + ballteam + "%' )";
            }
            if (time1 != "" && time2 != "")
            {
                flag = false;
                str += " and ('" + time1 + "'<=date(time) and date(time)<='" + time2 + "')";
            }else{
                if (time1 != "")
                {
                    flag = false;
                    str+=" and date(time)='"+time1+"'";
                }
                if (time2 != "")
                {
                    flag = false;
                    str+=" and date(time)='"+time2+"'";                    
                }
            }
            if (account != "")
            {
                flag = false;
                str += " and UserName like '%"+account+"%'";
            }
            if (flag)
            {
                str += " and  date(time)='" + today + "'";
            }
            str += " order by time desc ";
            string json = ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
            return json == "[]" ? "none" : json;
        }
        /*-----------会员注单------------------*/
        public string getCount(int id, int roid)
        {
            string str;
            if (roid != 6)
            {
                str = "select count(*) from agent where RoleId=?roid and UpUserID=?id";
            }
            else
            {
                str = "select count(*) from user where RoleId=?roid and UpUserID=?id";
            }
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?roid",roid),
                new MySqlParameter("?id",id)
            };
            return MySqlHelper.ExecuteScalar(str, param).ToString();
        }

        public string getUserCount(string un)
        {
            string str = "select count(*) from orderall where UserName=?un";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?un",un)
            };
            return MySqlHelper.ExecuteScalar(str, param).ToString();
        }
        /*-----------会员注单结束-----------------*/
        #endregion

        /// <summary>
        /// 根据gameid返回OrderOther
        /// </summary>
        /// <param name="gameid"></param>
        /// <returns></returns>
        public IList<Orderother> GetOrderByGameId(int gameid)
        {
            string sqlStr = "select * from orderother where gameid=?gameid";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?gameid",gameid)
            };
            return MySqlModelHelper<Orderother>.GetObjectsBySql(sqlStr, param);
        }

        public List<Orderother> getorderotherAll(int id)
        {
            List<Orderother> order = new List<Orderother>();
            string str = "select * from orderother where gameid=" + id + "";
            MySqlDataReader reder = MySqlHelper.ExecuteReader(str);
            while (reder.Read())
            {
                Orderother or = new Orderother();
                or.ID = Convert.ToInt32(reder.GetString("ID"));
                or.Agent = Convert.ToString(reder.GetString("Agent"));
                or.Amount = Convert.ToDecimal(reder.GetString("Amount"));
                or.Awaycn = Convert.ToString(reder.GetString("Awaycn"));
                or.Awayen = Convert.ToString(reder.GetString("Awayen"));
                or.Awayth = Convert.ToString(reder.GetString("Awayth"));
                or.Awaytw = Convert.ToString(reder.GetString("Awaytw"));
                or.Awayvn = Convert.ToString(reder.GetString("Awayvn"));
                or.BeginTime = Convert.ToDateTime(reder.GetString("BeginTime"));
                or.BetItem = Convert.ToString(reder.GetString("BetItem"));
                or.BetType = Convert.ToString(reder.GetString("BetType"));
                or.Gameid = Convert.ToInt32(reder.GetString("gameid"));
                or.Handicap = Convert.ToString(reder.GetString("Handicap"));
                or.Homecn = Convert.ToString(reder.GetString("Homecn"));
                or.Homeen = Convert.ToString(reder.GetString("Homeen"));
                or.Hometh = Convert.ToString(reder.GetString("Hometh"));
                or.Hometw = Convert.ToString(reder.GetString("Hometw"));
                or.Homevn = Convert.ToString(reder.GetString("Homevn"));
                or.IsHalf = Convert.ToString(reder.GetString("IsHalf"));
                or.Leaguecn = Convert.ToString(reder.GetString("leaguecn"));
                or.Leagueen = Convert.ToString(reder.GetString("leagueen"));
                or.Leagueth = Convert.ToString(reder.GetString("leagueth"));
                or.Leaguetw = Convert.ToString(reder.GetString("leaguetw"));
                or.Leaguevn = Convert.ToString(reder.GetString("leaguevn"));
                or.Odds = Convert.ToDecimal(reder.GetString("Odds"));
                or.OddsType = Convert.ToString(reder.GetString("OddsType"));
                or.OrderID = Convert.ToString(reder.GetString("OrderID"));
                or.Score = Convert.ToString(reder.GetString("Score"));
                or.Status = Convert.ToString(reder.GetString("Status"));
                or.Time = Convert.ToDateTime(reder.GetString("time"));
                or.UserName = Convert.ToString(reder.GetString("UserName"));
                or.ValidAmount = Convert.ToDecimal(reder.GetString("ValidAmount"));
                or.WebSiteiID = Convert.ToInt32(reder.GetString("WebSiteiID"));
                or.Betflag = Convert.ToString(reder.GetString("betflag"));
                order.Add(or);
            }
            return order;
        }

        public bool updateOrderotherStatus(int status,string id)
        {
            //string sqlStr = "update yafa.orderother set Status=?status where gameid=?gameid";
            string sqlStr = "update yafa.orderother set Status=?status where OrderID=?OrderID";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?status",status),
                new MySqlParameter("?OrderID",id)
            };
            return MySqlHelper.ExecuteNonQuery(sqlStr, param) > 0;
        }
    }
}
