using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Model;

namespace DAL.Ezun
{
   public class UserServices
    {
       private const string SQL_CHECKOLDPWD = "select UserName,Name,Currency,Balance from user where Password=?password and id=?id and status=1";
       private const string SQL_UPDATEPWD = "update user set Password=?Password where id=?id and status=1";
       /// <summary>
       /// 验证旧密码是否正确
       /// </summary>
       /// <param name="oldPwd"></param>
       /// <param name="userId"></param>
       /// <returns></returns>
       public bool CheckOldPwd(string oldPwd, int userId)
       {
           MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?password",MySqlDbType.VarChar,32),
                new MySqlParameter("?id",MySqlDbType.Int32)
            };
           param[0].Value = oldPwd;
           param[1].Value = userId;
           bool con = false;

           using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_CHECKOLDPWD, param))
           {
               if (reader.Read())
               {
                   reader.Close();
                   con = true;
               }
           }
           return con;

          
       }

       /// <summary>
       /// 修改密码
       /// </summary>
       /// <param name="newPwd"></param>
       /// <param name="userId"></param>
       /// <returns></returns>
       public bool UpdatePassword(string newPwd, int userId)
       {
           MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?Password",newPwd),
                new MySqlParameter("?id",userId)
            };
           return MySqlHelper.ExecuteNonQuery(SQL_UPDATEPWD, param) > 0;
       }

       /// <summary>
       /// 修改用户信息
       /// </summary>
       /// <param name="info"></param>
       /// <returns></returns>
       public bool UpdateUserInfo(User info)
       {
          
           string sqlStr = "Update user set nicheng=?nicheng,Tel=?Tel,post=?post,mark=?mark where username=?username";
           MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?username",info.UserName),
                new MySqlParameter("?nicheng",info.nicheng),
               
                new MySqlParameter("?Tel",info.Tel),
                new MySqlParameter("?post",info.post),
                new MySqlParameter("?mark",info.mark)
              
               
            };
           return MySqlHelper.ExecuteNonQuery(sqlStr, param) > 0;
       }

       /// <summary>
       /// PT申请开通
       /// </summary>
       /// <param name="newold"></param>
       /// <param name="UserName"></param>
       /// <param name="type"></param>
       /// <param name="status"></param>
       /// <returns></returns>
       public bool Getpwds(string newold, string username, string type, string Names)
       {

           string sqls = "insert into ptthing(username,password,type,status,submittime,Names)values(?username,?password,?type,?status,?submittime,?Names)";
           MySqlParameter[] parm = new MySqlParameter[] { 
                new MySqlParameter("?username",username),
                new MySqlParameter("?password",newold),
                new MySqlParameter("?type",type),
                new MySqlParameter("?status","0"),
               new MySqlParameter("?submittime",DateTime.Now),
               new MySqlParameter("?Names",Names)
            };
           return MySqlHelper.ExecuteNonQuery(sqls, parm) > 0;
       }

       public string GetPTinfo(string username)
       {
           string json = string.Empty;
           string SQL_SELECT = "select username,status  from ptthing where username='" + username + "'  and type='1' and (ISNULL(updatetime) or status='1')";

           using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT))
           {
               json = ObjectToJson.ReaderToJson(reader);
               reader.Close();
           }
           return json == "]" ? string.Empty : json;
       }
       //查询出相关银行绑定信息
       public string GetBanks(string username)
       {
        
           string json = string.Empty;
           string SQL_SELECT = "select username,bankName,bankUserName,bankCard  from user where username='" + username + "' ";

           using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SQL_SELECT))
           {
               json = ObjectToJson.ReaderToJson(reader);
               reader.Close();
           }
           return json == "]" ? string.Empty : json;
       }

       /// <summary>
       /// 绑定修改银行卡信息
       /// </summary>
       /// <param name="info"></param>
       /// <returns></returns>
       public bool UpdateUserInfoS(string username, string bankName, string bankUserName, string bankCard)
       {

           string sqlStr = "Update user set bankName=?bankName,bankUserName=?bankUserName,bankCard=?bankCard where username=?username";
           MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?username",username),
                new MySqlParameter("?bankName",bankName),
               
                new MySqlParameter("?bankUserName",bankUserName),
                new MySqlParameter("?bankCard",bankCard)
               
            };
           return MySqlHelper.ExecuteNonQuery(sqlStr, param) > 0;
       }

       public bool GetPTpwdInfo(string username)
       {
           string SQL_SELECT = "select count(*)  from ptthing where username='" + username + "' and type='2' and status='0'";
           int count = 0;
           count = Convert.ToInt32(MySqlHelper.ExecuteScalar(SQL_SELECT));
           if (count > 0)
           {
               return true;
           }
           else
           {
               return false;

           }
         
       }
       
    }
}
