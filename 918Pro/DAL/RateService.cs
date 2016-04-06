using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class RateService
	{
        private const string SQL_INSERT = "insert into yafa.rate (name_cn,name_tw,name_en,name_th,name_vn,rate,lasttime,operator,ip,code)values(?name_cn,?name_tw,?name_en,?name_th,?name_vn,?rate,?lasttime,?operator,?ip,?code)";
        private const string SQL_UPDATE = "update yafa.rate set name_cn=?name_cn,name_tw=?name_tw,name_en=?name_en,name_th=?name_th,name_vn=?name_vn,rate=?rate,lasttime=?lasttime,operator=?operator,ip=?ip,code=?code where id = ?id";
        private const string SQL_SELECTBYPK = "select id from yafa.rate  where rate.id = ?id";
        private const string SQL_SELECTALL = "select id,name_cn,name_tw,name_en,name_th,name_vn,rate,lasttime,operator,ip,code from yafa.rate ";
        private const string SQL_DELETEBYPK = "delete  from yafa.rate  where rate.id = ?id";

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-4-1 8:03:13		
        ///</summary>		
        public Boolean AddRate(Rate rate)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?name_cn",rate.Name_cn),
				 new MySqlParameter("?name_tw",rate.Name_tw),
				 new MySqlParameter("?name_en",rate.Name_en),
				 new MySqlParameter("?name_th",rate.Name_th),
				 new MySqlParameter("?name_vn",rate.Name_vn),
				 new MySqlParameter("?rate",rate.Rate1),
				 new MySqlParameter("?lasttime",rate.Lasttime),
				 new MySqlParameter("?operator",rate.Operator),
				 new MySqlParameter("?ip",rate.Ip),
				 new MySqlParameter("?code",rate.Code)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-4-1 8:03:13		
        ///</summary>		
        public Boolean UpdateRate(Rate rate)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?name_cn",rate.Name_cn),
				 new MySqlParameter("?name_tw",rate.Name_tw),
				 new MySqlParameter("?name_en",rate.Name_en),
				 new MySqlParameter("?name_th",rate.Name_th),
				 new MySqlParameter("?name_vn",rate.Name_vn),
				 new MySqlParameter("?rate",rate.Rate1),
				 new MySqlParameter("?lasttime",rate.Lasttime),
				 new MySqlParameter("?operator",rate.Operator),
				 new MySqlParameter("?ip",rate.Ip),
				 new MySqlParameter("?code",rate.Code),
				 new MySqlParameter("?id",rate.Id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-4-1 8:03:13		
        ///</summary>		
        public Boolean DeleteRateByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2011-4-1 8:03:13		
        ///</summary>		
        public Rate GetRateByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};

            return MySqlModelHelper<Rate>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2011-4-1 8:03:13		
        ///</summary>		
        public IList<Rate> GetMutilILRate()
        {
            return MySqlModelHelper<Rate>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2011-4-1 8:03:13		
        ///</summary>		
        public DataTable GetMutilDTRate()
        {
            return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion 
	
        public System.Data.Common.DbDataReader GetRateAll()
        {
            return MySqlHelper.ExecuteReader(SQL_SELECTALL, null);
        }

        public string GetRateByLan(string language)
        {
            string mysql = "";
            string sqlStr = "";
            if (language == "zh-cn" || language == "zh-CN")
            {
                mysql = "name_cn";
            }
            if (language == "zh-tw")
            {
                mysql = "name_tw";
            }
            if (language == "en-us")
            {
                mysql = "name_en";
            }
            if (language == "th-th")
            {
                mysql = "name_th";
            }
            if (language == "vi-vn")
            {
                mysql = "name_vn";
            }
            sqlStr = "select id," + mysql + " as name,rate,code from rate order by id";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sqlStr));
        }


        public System.Data.Common.DbDataReader GetRatetype(string Language)
        {
            string mysql = "";
            if (Language == "cn")
            {
                mysql = "name_cn";
            }
            if (Language == "tw")
            {
                mysql = "name_tw";
            }
            if (Language == "en")
            {
                mysql = "name_en";
            }
            if (Language == "th")
            {
                mysql = "name_th";
            }
            if (Language == "vn")
            {
                mysql = "name_vn";
            }
            string SQL_SELECTTYPE = "select distinct " + mysql + " from yafa.rate ";
            return MySqlHelper.ExecuteReader(SQL_SELECTTYPE, null);
        }

        public bool CeliName(string Name, string Language)
        {
            string mysql = "";
            if (Language == "cn")
            {
                mysql = "name_cn";
            }
            if (Language == "tw")
            {
                mysql = "name_tw";
            }
            if (Language == "en")
            {
                mysql = "name_en";
            }
            if (Language == "th")
            {
                mysql = "name_th";
            }
            if (Language == "vn")
            {
                mysql = "name_vn";
            }
            string SQL_SELECTNAEM = "select " + mysql + " from yafa.rate where "+mysql+"='"+Name+"'";

            return MySqlHelper.ExecuteDataTable(SQL_SELECTNAEM, null).Rows.Count > 0;
        }
    }
}
