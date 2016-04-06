using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class BetaccountmaxService
	{
		private const string SQL_INSERT="insert into yafa.betaccountmax (casino,userid,password,agent,loginname,betcount,websitePossess,selfPossess,commission,multiple,group1,address,address2,enable,credit,zemo,isquzhi,cookie,time,islogin,operator,operatortime,operatorip)values(?casino,?userid,?password,?agent,?loginname,?betcount,?websitePossess,?selfPossess,?commission,?multiple,?group1,?address,?address2,?enable,?credit,?zemo,?isquzhi,?cookie,?time,?islogin,?operator,?operatortime,?operatorip)";
		private const string SQL_UPDATE="update yafa.betaccountmax set casino=?casino,userid=?userid,password=?password,agent=?agent,loginname=?loginname,betcount=?betcount,websitePossess=?websitePossess,selfPossess=?selfPossess,commission=?commission,multiple=?multiple,group1=?group1,address=?address,address2=?address2,enable=?enable,credit=?credit,zemo=?zemo,isquzhi=?isquzhi,cookie=?cookie,time=?time,islogin=?islogin,operator=?operator,operatortime=?operatortime,operatorip=?operatorip where id = ?id";
		private const string SQL_SELECTBYPK="select id from yafa.betaccountmax  where betaccountmax.id = ?id";
		private const string SQL_SELECTALL="select id,casino,userid,password,agent,loginname,betcount,websitePossess,selfPossess,commission,multiple,group1,address,address2,enable,credit,zemo,isquzhi,cookie,time,islogin,operator,operatortime,operatorip from yafa.betaccountmax ";
		private const string SQL_DELETEBYPK="delete  from yafa.betaccountmax  where betaccountmax.id = ?id";
		
		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-3-25 15:00:07		
		///</summary>		
		public Boolean AddBetaccountmax(Betaccountmax betaccountmax)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?casino",betaccountmax.Casino),
				 new MySqlParameter("?userid",betaccountmax.Userid),
				 new MySqlParameter("?password",betaccountmax.Password),
				 new MySqlParameter("?agent",betaccountmax.Agent),
				 new MySqlParameter("?loginname",betaccountmax.Loginname),
				 new MySqlParameter("?betcount",betaccountmax.Betcount),
				 new MySqlParameter("?websitePossess",betaccountmax.WebsitePossess),
				 new MySqlParameter("?selfPossess",betaccountmax.SelfPossess),
				 new MySqlParameter("?commission",betaccountmax.Commission),
				 new MySqlParameter("?multiple",betaccountmax.Multiple),
				 new MySqlParameter("?group1",betaccountmax.Group1),
				 new MySqlParameter("?address",betaccountmax.Address),
				 new MySqlParameter("?address2",betaccountmax.Address2),
				 new MySqlParameter("?enable",betaccountmax.Enable),
				 new MySqlParameter("?credit",betaccountmax.Credit),
				 new MySqlParameter("?zemo",betaccountmax.Zemo),
				 new MySqlParameter("?isquzhi",betaccountmax.Isquzhi),
				 new MySqlParameter("?cookie",betaccountmax.Cookie),
				 new MySqlParameter("?time",betaccountmax.Time),
				 new MySqlParameter("?islogin",betaccountmax.Islogin),
				 new MySqlParameter("?operator",betaccountmax.Operator),
				 new MySqlParameter("?operatortime",betaccountmax.Operatortime),
				 new MySqlParameter("?operatorip",betaccountmax.Operatorip)
			};
			return MySqlHelper2.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-3-25 15:00:07		
		///</summary>		
		public Boolean UpdateBetaccountmax(Betaccountmax betaccountmax)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?casino",betaccountmax.Casino),
				 new MySqlParameter("?userid",betaccountmax.Userid),
				 new MySqlParameter("?password",betaccountmax.Password),
				 new MySqlParameter("?agent",betaccountmax.Agent),
				 new MySqlParameter("?loginname",betaccountmax.Loginname),
				 new MySqlParameter("?betcount",betaccountmax.Betcount),
				 new MySqlParameter("?websitePossess",betaccountmax.WebsitePossess),
				 new MySqlParameter("?selfPossess",betaccountmax.SelfPossess),
				 new MySqlParameter("?commission",betaccountmax.Commission),
				 new MySqlParameter("?multiple",betaccountmax.Multiple),
				 new MySqlParameter("?group1",betaccountmax.Group1),
				 new MySqlParameter("?address",betaccountmax.Address),
				 new MySqlParameter("?address2",betaccountmax.Address2),
				 new MySqlParameter("?enable",betaccountmax.Enable),
				 new MySqlParameter("?credit",betaccountmax.Credit),
				 new MySqlParameter("?zemo",betaccountmax.Zemo),
				 new MySqlParameter("?isquzhi",betaccountmax.Isquzhi),
				 new MySqlParameter("?cookie",betaccountmax.Cookie),
				 new MySqlParameter("?time",betaccountmax.Time),
				 new MySqlParameter("?islogin",betaccountmax.Islogin),
				 new MySqlParameter("?operator",betaccountmax.Operator),
				 new MySqlParameter("?operatortime",betaccountmax.Operatortime),
				 new MySqlParameter("?operatorip",betaccountmax.Operatorip),
				 new MySqlParameter("?id",betaccountmax.Id)
			};
			return MySqlHelper2.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-3-25 15:00:07		
		///</summary>		
		public Boolean DeleteBetaccountmaxByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};
			return MySqlHelper2.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2011-3-25 15:00:07		
		///</summary>		
		public Betaccountmax GetBetaccountmaxByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};

			return MySqlModelHelper2<Betaccountmax>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2011-3-25 15:00:07		
		///</summary>		
		public IList<Betaccountmax> GetMutilILBetaccountmax()
		{
			return MySqlModelHelper2<Betaccountmax>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2011-3-25 15:00:07		
		///</summary>		
		public DataTable GetMutilDTBetaccountmax()
		{
			 return MySqlHelper2.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 

        public string getAllCount(string casino, string dali, string id, string enable, string webPoss, string Company)
        {
            string str = "select count(*) from betaccountmax ";
            string where = "where";
            if (casino != "0")
            {
                where += " casino=" + casino;
            }
            if (dali != "")
            {
                if (where == "where")
                {
                    where += " agent='" + dali + "'";
                }
                else
                {
                    where += " and agent='" + dali + "'";
                }
            }
            if (id != "")
            {
                if (where == "where")
                {
                    where += " userid='" + id.Replace("'", "") + "'";
                }
                else
                {
                    where += " and userid='" + id.Replace("'", "") + "'";
                }
            }
            if (enable != "-1")
            {
                if (where == "where")
                {
                    where += " enable=" + enable;
                }
                else
                {
                    where += " and enable=" + enable;
                }
            }
            if (webPoss != "")
            {
                if (where == "where")
                {
                    where += " websitepossess=" + webPoss;
                }
                else
                {
                    where += " and websitepossess=" + webPoss;
                }
            }
            if (Company != "")
            {
                if (where == "where")
                {
                    where += " selfpossess=" + Company;
                }
                else
                {
                    where += " and selfpossess=" + Company;
                }
            }
            if (where == "where")
            {
                return MySqlHelper2.ExecuteScalar(str).ToString();
            }
            else
            {
                return MySqlHelper2.ExecuteScalar(str + where).ToString();
            }
        }

        public string getCount(string username)
        {
            string str = "select count(*) from betaccountmax where userid = ?username";
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?username",username)
            };
            return MySqlHelper2.ExecuteScalar(str, param).ToString();
        }

        public string getDataAll(int IDex, int IDexC, string casino, string dali, string id, string enable, string webPoss, string Company)
        {
            string where = "where";
            if (casino != "0")
            {
                where += " casino=" + casino;
            }
            if (dali != "")
            {
                if (where == "where")
                {
                    where += " agent='" + dali + "'";
                }
                else
                {
                    where += " and agent='" + dali + "'";
                }
            }
            if (id != "")
            {
                if (where == "where")
                {
                    where += " userid='" + id.Replace("'", "") + "'";
                }
                else
                {
                    where += " and userid='" + id.Replace("'", "") + "'";
                }
            }
            if (enable != "-1")
            {
                if (where == "where")
                {
                    where += " enable=" + enable;
                }
                else
                {
                    where += " and enable=" + enable;
                }
            }
            if (webPoss != "")
            {
                if (where == "where")
                {
                    where += " websitepossess=" + webPoss;
                }
                else
                {
                    where += " and websitepossess=" + webPoss;
                }
            }
            if (Company != "")
            {
                if (where == "where")
                {
                    where += " selfpossess=" + Company;
                }
                else
                {
                    where += " and selfpossess=" + Company;
                }
            }
            if (where == "where")
            {
                return ObjectToJson.ReaderToJson(MySqlHelper2.ExecuteReader(SQL_SELECTALL + " limit " + IDex + "," + IDexC));
            }
            else
            {
                return ObjectToJson.ReaderToJson(MySqlHelper2.ExecuteReader(SQL_SELECTALL + where + " limit " + IDex + "," + IDexC));
            }
        }

        public IList<Betaccountmax> GetBetaccountByID(int id)
        {
            string str = SQL_SELECTALL + " where id=?id";
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};
            return MySqlModelHelper2<Betaccountmax>.GetObjectsBySql(str, param);
        }

	}
}
