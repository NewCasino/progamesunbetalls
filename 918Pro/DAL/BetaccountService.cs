using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
    public class BetaccountService
    {
        //private const string SQL_INSERT = "insert into yafa.betaccount (casino,userid,password,agent,loginname,betcount,websitePossess,selfPossess,commission,multiple,group1,address,address2,enable,credit,zemo,isquzhi,cookie,time,islogin,operator,operatortime,operatorip,anothername)values(?casino,?userid,?password,?agent,?loginname,?betcount,?websitePossess,?selfPossess,?commission,?multiple,?group1,?address,?address2,?enable,?credit,?zemo,?isquzhi,?cookie,?time,?islogin,?operator,?operatortime,?operatorip,?anothername)";
        private const string SQL_INSERT = "insert into yafa.betaccount (anothername,casino,userid,password,agent,websitePossess,selfPossess,commission,multiple,group1,address,address2,enable,zemo,isquzhi,cookie,time,operator,operatortime,operatorip)values(?anothername,?casino,?userid,?password,?agent,?websitePossess,?selfPossess,?commission,?multiple,?group1,?address,?address2,?enable,?zemo,?isquzhi,?cookie,?time,?operator,?operatortime,?operatorip)";
        //private const string SQL_UPDATE = "update yafa.betaccount set casino=?casino,userid=?userid,password=?password,agent=?agent,loginname=?loginname,betcount=?betcount,websitePossess=?websitePossess,selfPossess=?selfPossess,commission=?commission,multiple=?multiple,group1=?group1,address=?address,address2=?address2,enable=?enable,credit=?credit,zemo=?zemo,isquzhi=?isquzhi,cookie=?cookie,time=?time,islogin=?islogin,operator=?operator,operatortime=?operatortime,operatorip=?operatorip,anothername=?anothername where id = ?id";
        private const string SQL_UPDATE = "update yafa.betaccount set anothername=?anothername,casino=?casino,userid=?userid,password=?password,agent=?agent,websitePossess=?websitePossess,selfPossess=?selfPossess,commission=?commission,multiple=?multiple,group1=?group1,address=?address,address2=?address2,enable=?enable,zemo=?zemo,isquzhi=?isquzhi,cookie=?cookie,time=?time,operator=?operator,operatortime=?operatortime,operatorip=?operatorip where id = ?id";
        private const string SQL_SELECTBYPK = "select id from yafa.betaccount  where betaccount.id = ?id";
        private const string SQL_SELECTALL = "select id,casino,userid,password,agent,loginname,betcount,websitePossess,selfPossess,commission,multiple,group1,address,address2,enable,credit,zemo,isquzhi,cookie,time,islogin,operator,operatortime,operatorip,anothername from yafa.betaccount ";
        private const string SQL_DELETEBYPK = "delete  from yafa.betaccount  where betaccount.id = ?id";

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-5-5 21:16:16		
        ///</summary>		
        public Boolean AddBetaccount(Betaccount betaccount)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?casino",betaccount.Casino),
				 new MySqlParameter("?userid",betaccount.Userid),
				 new MySqlParameter("?password",betaccount.Password),
				 new MySqlParameter("?agent",betaccount.Agent),
				 new MySqlParameter("?websitePossess",betaccount.WebsitePossess),
				 new MySqlParameter("?selfPossess",betaccount.SelfPossess),
				 new MySqlParameter("?commission",betaccount.Commission),
				 new MySqlParameter("?multiple",betaccount.Multiple),
				 new MySqlParameter("?group1",betaccount.Group1),
				 new MySqlParameter("?address",betaccount.Address),
				 new MySqlParameter("?address2",betaccount.Address2),
				 new MySqlParameter("?enable",betaccount.Enable),
				 new MySqlParameter("?zemo",betaccount.Zemo),
				 new MySqlParameter("?isquzhi",betaccount.Isquzhi),
				 new MySqlParameter("?cookie",betaccount.Cookie),
				 new MySqlParameter("?time",betaccount.Time),
				 new MySqlParameter("?operator",betaccount.Operator),
				 new MySqlParameter("?operatortime",betaccount.Operatortime),
				 new MySqlParameter("?operatorip",betaccount.Operatorip),
                 new MySqlParameter("?anothername",betaccount.Anothername)

			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-5-5 21:16:16		
        ///</summary>		
        public Boolean UpdateBetaccount(Betaccount betaccount)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?casino",betaccount.Casino),
				 new MySqlParameter("?userid",betaccount.Userid),
				 new MySqlParameter("?password",betaccount.Password),
				 new MySqlParameter("?agent",betaccount.Agent),
				 new MySqlParameter("?websitePossess",betaccount.WebsitePossess),
				 new MySqlParameter("?selfPossess",betaccount.SelfPossess),
				 new MySqlParameter("?commission",betaccount.Commission),
				 new MySqlParameter("?multiple",betaccount.Multiple),
				 new MySqlParameter("?group1",betaccount.Group1),
				 new MySqlParameter("?address",betaccount.Address),
				 new MySqlParameter("?address2",betaccount.Address2),
				 new MySqlParameter("?enable",betaccount.Enable),
				 new MySqlParameter("?zemo",betaccount.Zemo),
				 new MySqlParameter("?isquzhi",betaccount.Isquzhi),
				 new MySqlParameter("?cookie",betaccount.Cookie),
				 new MySqlParameter("?time",betaccount.Time),
				 new MySqlParameter("?operator",betaccount.Operator),
				 new MySqlParameter("?operatortime",betaccount.Operatortime),
				 new MySqlParameter("?operatorip",betaccount.Operatorip),
				 new MySqlParameter("?id",betaccount.Id),
                 new MySqlParameter("?anothername",betaccount.Anothername)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2011-5-5 21:16:16		
        ///</summary>		
        public Boolean DeleteBetaccountByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2011-5-5 21:16:16		
        ///</summary>		
        public Betaccount GetBetaccountByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};

            return MySqlModelHelper<Betaccount>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2011-5-5 21:16:16		
        ///</summary>		
        public IList<Betaccount> GetMutilILBetaccount()
        {
            return MySqlModelHelper<Betaccount>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2011-5-5 21:16:16		
        ///</summary>		
        public DataTable GetMutilDTBetaccount()
        {
            return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion 

        #region 编写人:李毅
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
                return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(SQL_SELECTALL + " limit " + IDex + "," + IDexC));
            }
            else
            {
                return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(SQL_SELECTALL + where + " limit " + IDex + "," + IDexC));
            }
        }

        /// <summary>
        /// 根据ID获得单个实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<Betaccount> GetBetaccountByID(int id)
        {
            string str = SQL_SELECTALL + " where id=?id";
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};
            return MySqlModelHelper<Betaccount>.GetObjectsBySql(str, param);
        }

        public string getCount(string username)
        {
            string str = "select count(*) from betaccount where userid = ?username";
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?username",username)
            };
            return MySqlHelper.ExecuteScalar(str, param).ToString();
        }

        public string getAllCount(string casino, string dali, string id, string enable, string webPoss, string Company)
        {
            string str = "select count(*) from betaccount ";
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
                return MySqlHelper.ExecuteScalar(str).ToString();
            }
            else
            {
                return MySqlHelper.ExecuteScalar(str + where).ToString();
            }
        }
        #endregion

    }
}