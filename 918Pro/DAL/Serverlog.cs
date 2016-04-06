using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

using Model;
namespace DAL
{
    public class Serverlog
    {
        private const string SQL_INSERT = "insert into yafa.serverlog (IP,LoginBegin,LoginTime,magnerUser)values(?IP,NOW(),CURDATE(),?magnerUser)";
        private const string SQL_UPDATE = "update yafa.serverlog set LoginEnd=?LoginEnd where magnerUser = ?magnerUser";
        private const string SQL_SELECTALL = "select IP,LoginBegin,LoginEnd,LoginTime,magnerUser from yafa.serverlog ";
        //是否显示要新增
        public static Boolean IsSestlog(string mageruser)
        {
            
            string sqls = "select count(*) from yafa.serverlog where magnerUser=?magnerUser and LoginTime=CURDATE()";
            MySqlParameter[] parameter = new MySqlParameter[] { 
                new MySqlParameter("?magnerUser",mageruser)              
            };
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(sqls, parameter)) > 0;
           
          
        }
        //新增
        public static Boolean AddSestlog(string IP, string LoginBegin,string LoginTime, string magnerUser)
        {

            string sqls = "select count(*) from yafa.serverlog where magnerUser=?magnerUser and LoginTime=CURDATE()";
            MySqlParameter[] parameter = new MySqlParameter[] { 
                new MySqlParameter("?magnerUser",magnerUser),
                new MySqlParameter("?LoginTime",LoginTime)
            };

            int count = Convert.ToInt32(MySqlHelper.ExecuteScalar(sqls, parameter));
            if (count < 1)
            {
                MySqlParameter[] param = new MySqlParameter[]{
				     new MySqlParameter("?IP",IP),	
				     new MySqlParameter("?magnerUser",magnerUser)
			    };
                return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
            }
            else {
                string sqlupdate = "Update serverlog set LoginBegin=NOW() where magnerUser=?magnerUser and LoginTime=CURDATE()";
                MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?magnerUser",magnerUser)  
              
                };
                bool isture = MySqlHelper.ExecuteNonQuery(sqlupdate, param) > 0;
                if (isture)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
           
        }


        //修改
        public static Boolean UpdateSestlog(string magnerUser)
        {
            string sqls = "select count(*) from yafa.serverlog where magnerUser=?magnerUser and LoginTime=CURDATE()";
            MySqlParameter[] parameter = new MySqlParameter[] { 
                new MySqlParameter("?magnerUser",magnerUser)
             
            };

            int count = Convert.ToInt32(MySqlHelper.ExecuteScalar(sqls, parameter));
            if (count > 0)
            {
                string sqlupdate = "Update serverlog set LoginEnd=NOW() where magnerUser=?magnerUser and LoginTime=CURDATE()";
                MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?magnerUser",magnerUser)  
              
                };
                bool isture = MySqlHelper.ExecuteNonQuery(sqlupdate, param) > 0;
                if (isture)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                string IP = Util.RequestHelper.GetIP();
                string SQLS = "insert into yafa.serverlog (IP,LoginEnd,LoginTime,magnerUser)values(?IP,NOW(),CURDATE(),?magnerUser)";
                MySqlParameter[] param = new MySqlParameter[]{
				     new MySqlParameter("?IP",IP),	
				     new MySqlParameter("?magnerUser",magnerUser)
			    };
                return MySqlHelper.ExecuteNonQuery(SQLS, param) > 0;
            }
        }

        //查询
        public static string GetSestlog(string magnerUser,string time1, string time2)
        {

            string sql = "select * from serverlog where 1=1 ";
            string subStr = "";
            if (!string.IsNullOrEmpty(magnerUser))
            {
                subStr += " and magnerUser='" + magnerUser + "' ";
            }          
            if (!string.IsNullOrEmpty(time1) && !string.IsNullOrEmpty(time2))
            {
                subStr += " and date(LoginTime)>='" + time1 + "' and date(LoginTime)<='" + time2 + "' ";
            }
            if (subStr == "")
            {
                return "";
            }
            sql += subStr;
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sql));
        }
       
    }
}
