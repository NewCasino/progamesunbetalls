using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class RatehistoryService
	{
		private const string SQL_INSERT="insert into yafa.ratehistory (name_cn,name_tw,name_en,name_th,name_vn,rate,lasttime,operator,ip)values(?name_cn,?name_tw,?name_en,?name_th,?name_vn,?rate,?lasttime,?operator,?ip)";
		private const string SQL_UPDATE="update yafa.ratehistory set name_cn=?name_cn,name_tw=?name_tw,name_en=?name_en,name_th=?name_th,name_vn=?name_vn,rate=?rate,lasttime=?lasttime,operator=?operator,ip=?ip where id = ?id";
		private const string SQL_SELECTBYPK="select id from yafa.ratehistory  where ratehistory.id = ?id";
		private const string SQL_SELECTALL="select id,name_cn,name_tw,name_en,name_th,name_vn,rate,lasttime,operator,ip from yafa.ratehistory ";
		private const string SQL_DELETEBYPK="delete  from yafa.ratehistory  where ratehistory.id = ?id";
		
		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-1 11:56:51		
		///</summary>		
		public Boolean AddRatehistory(Rate ratehistory)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?name_cn",ratehistory.Name_cn),
				 new MySqlParameter("?name_tw",ratehistory.Name_tw),
				 new MySqlParameter("?name_en",ratehistory.Name_en),
				 new MySqlParameter("?name_th",ratehistory.Name_th),
				 new MySqlParameter("?name_vn",ratehistory.Name_vn),
				 new MySqlParameter("?rate",ratehistory.Rate1),
				 new MySqlParameter("?lasttime",ratehistory.Lasttime),
				 new MySqlParameter("?operator",ratehistory.Operator),
				 new MySqlParameter("?ip",ratehistory.Ip)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-1 11:56:51		
		///</summary>		
		public Boolean UpdateRatehistory(Ratehistory ratehistory)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?name_cn",ratehistory.Name_cn),
				 new MySqlParameter("?name_tw",ratehistory.Name_tw),
				 new MySqlParameter("?name_en",ratehistory.Name_en),
				 new MySqlParameter("?name_th",ratehistory.Name_th),
				 new MySqlParameter("?name_vn",ratehistory.Name_vn),
				 new MySqlParameter("?rate",ratehistory.Rate),
				 new MySqlParameter("?lasttime",ratehistory.Lasttime),
				 new MySqlParameter("?operator",ratehistory.Operator),
				 new MySqlParameter("?ip",ratehistory.Ip),
				 new MySqlParameter("?id",ratehistory.Id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-11-1 11:56:51		
		///</summary>		
		public Boolean DeleteRatehistoryByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2010-11-1 11:56:51		
		///</summary>		
		public Ratehistory GetRatehistoryByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};

			return MySqlModelHelper<Ratehistory>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2010-11-1 11:56:51		
		///</summary>		
		public IList<Ratehistory> GetMutilILRatehistory()
		{
			return MySqlModelHelper<Ratehistory>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2010-11-1 11:56:51		
		///</summary>		
		public DataTable GetMutilDTRatehistory()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 
	
        public string GetRate(string type, string time1, string time2, string language, string user)
        {
            string mysql = "";
            string types = "";
            string ifo = "";
            if (language == "cn")
            {
                mysql = "name_cn as name";
                types = "name_cn";
            }
            if (language == "tw")
            {
                mysql = "name_tw as name";
                types = "name_tw";
            }
            if (language == "en")
            {
                mysql = "name_en as name";
                types = "name_en";
            }
            if (language == "th")
            {
                mysql = "name_th as name";
                types = "name_th";
            }
            if (language == "vn")
            {
                mysql = "name_vn as name";
                types = "name_vn";
            }

            if (type != "")
            {
                ifo = " where " + types + "='" + type + "'";
            }

            if (time1 != "")
            {
                ifo = " where date(lasttime)= '" + time1 + "'";
            }
            if (time2 != "")
            {
                ifo = " where date(lasttime)= '" + time2 + "'";
            }
            if (time1 != "" && time2 != "")
            {
                ifo = "where date(lasttime)>= '" + time1 + "' and date(lasttime)<='" + time2 + "'";
            }
            if (user != "")
            {
                ifo = " where operator='" + user + "'";
            }

            if (type != "" && time1 != "" && time2 == "")
            {
                ifo = " where " + types + "='" + type + "' and date(lasttime)= '" + time1 + "'";
            }

            if (type != "" && time1 == "" && time2 != "")
            {
                ifo = " where " + types + "='" + type + "' and date(lasttime)<= '" + time2 + "'";
            }

            if (type != "" && time1 != "" && time2 != "")
            {
                ifo = " where " + types + "='" + type + "' and date(lasttime)>= '" + time1 + "' and date(lasttime)<= '" + time2 + "'";
            }

            if (type != "" && user != "")
            {
                ifo = " where " + types + "='" + type + "' and operator='" + user + "'";
            }
            if (user != "" && time1 != "" && time2=="")
            {
                ifo = "where date(lasttime)= '" + time1 + "' and operator='" + user + "'";
            }

            if (user != "" && time1 == "" && time2 != "")
            {
                ifo = "where date(lasttime)<= '" + time2 + "' and operator='" + user + "'";
            }

            if (type != "" && time1 != "" && time2 == "" && user != "")
            {
                ifo = " where " + types + "='" + type + "' and date(lasttime)= '" + time1 + "' and operator='" + user + "'";
            }

            if (type != "" && time1 == "" && time2 != "" && user != "")
            {
                ifo = " where " + types + "='" + type + "' and date(lasttime)<= '" + time2 + "' and operator='" + user + "'";
            }

            if (type != "" && time1 != "" && time2!="" && user != "")
            {
                ifo = " where " + types + "='" + type + "' and date(lasttime)>= '" + time1 + "' and date(lasttime)<='"+time2+ "' and operator='" + user + "'";
            }

            string str = "select id," + mysql + ",rate,date(lasttime),lasttime,operator,ip from yafa.ratehistory " + ifo + " order by " + types + " ,lasttime desc";

            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        public bool DeleteRatehistory(string Name, string Language)
        {
            string types = "";
            if (Language == "cn")
            {
                types = "name_cn";
            }
            if (Language == "tw")
            {
                types = "name_tw";
            }
            if (Language == "en")
            {
                types = "name_en";
            }
            if (Language == "th")
            {
                types = "name_th";
            }
            if (Language == "vn")
            {
                types = "name_vn";
            }
            string str = "delete  from yafa.ratehistory  where "+types+"='"+Name+"'";
            return MySqlHelper.ExecuteNonQuery(str, null) > 0;
        }
    }
}
