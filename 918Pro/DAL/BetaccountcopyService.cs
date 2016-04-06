using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
    public class BetaccountcopyService
    {
        private const string SQL_INSERT = "insert into yafa.betaccountcopy (casino,userid,password,agent,websitePossess,selfPossess,commission,multiple,group1,address,address2,enable,zemo,isquzhi,cookie,time,operator,operatortime,operatorip)values(?casino,?userid,?password,?agent,?websitePossess,?selfPossess,?commission,?multiple,?group1,?address,?address2,?enable,?zemo,?isquzhi,?cookie,?time,?operator,?operatortime,?operatorip)";
        private const string SQL_UPDATE = "update yafa.betaccountcopy set casino=?casino,userid=?userid,password=?password,agent=?agent,websitePossess=?websitePossess,selfPossess=?selfPossess,commission=?commission,multiple=?multiple,group1=?group1,address=?address,address2=?address2,enable=?enable,zemo=?zemo,isquzhi=?isquzhi,cookie=?cookie,time=?time,operator=?operator,operatortime=?operatortime,operatorip=?operatorip where id = ?id";
        private const string SQL_SELECTBYPK = "select id from yafa.betaccountcopy  where betaccountcopy.id = ?id";
        private const string SQL_SELECTALL = "select id,casino,userid,password,agent,websitePossess,selfPossess,commission,multiple,group1,address,address2,enable,zemo,isquzhi,cookie,time,operator,operatortime,operatorip from yafa.betaccountcopy ";
        private const string SQL_DELETEBYPK = "delete  from yafa.betaccountcopy  where betaccountcopy.id = ?id";

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-9-12 14:32:18		
        ///</summary>		
        public Boolean AddBetaccountcopy(Betaccountcopy betaccountcopy)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?casino",betaccountcopy.Casino),
				 new MySqlParameter("?userid",betaccountcopy.Userid),
				 new MySqlParameter("?password",betaccountcopy.Password),
				 new MySqlParameter("?agent",betaccountcopy.Agent),
				 new MySqlParameter("?websitePossess",betaccountcopy.WebsitePossess),
				 new MySqlParameter("?selfPossess",betaccountcopy.SelfPossess),
				 new MySqlParameter("?commission",betaccountcopy.Commission),
				 new MySqlParameter("?multiple",betaccountcopy.Multiple),
				 new MySqlParameter("?group1",betaccountcopy.Group1),
				 new MySqlParameter("?address",betaccountcopy.Address),
				 new MySqlParameter("?address2",betaccountcopy.Address2),
				 new MySqlParameter("?enable",betaccountcopy.Enable),
				 new MySqlParameter("?zemo",betaccountcopy.Zemo),
				 new MySqlParameter("?isquzhi",betaccountcopy.Isquzhi),
				 new MySqlParameter("?cookie",betaccountcopy.Cookie),
				 new MySqlParameter("?time",betaccountcopy.Time),
				 new MySqlParameter("?operator",betaccountcopy.Operator),
				 new MySqlParameter("?operatortime",betaccountcopy.Operatortime),
				 new MySqlParameter("?operatorip",betaccountcopy.Operatorip)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-9-12 14:32:18		
        ///</summary>		
        public Boolean UpdateBetaccountcopy(Betaccountcopy betaccountcopy)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?casino",betaccountcopy.Casino),
				 new MySqlParameter("?userid",betaccountcopy.Userid),
				 new MySqlParameter("?password",betaccountcopy.Password),
				 new MySqlParameter("?agent",betaccountcopy.Agent),
				 new MySqlParameter("?websitePossess",betaccountcopy.WebsitePossess),
				 new MySqlParameter("?selfPossess",betaccountcopy.SelfPossess),
				 new MySqlParameter("?commission",betaccountcopy.Commission),
				 new MySqlParameter("?multiple",betaccountcopy.Multiple),
				 new MySqlParameter("?group1",betaccountcopy.Group1),
				 new MySqlParameter("?address",betaccountcopy.Address),
				 new MySqlParameter("?address2",betaccountcopy.Address2),
				 new MySqlParameter("?enable",betaccountcopy.Enable),
				 new MySqlParameter("?zemo",betaccountcopy.Zemo),
				 new MySqlParameter("?isquzhi",betaccountcopy.Isquzhi),
				 new MySqlParameter("?cookie",betaccountcopy.Cookie),
				 new MySqlParameter("?time",betaccountcopy.Time),
				 new MySqlParameter("?operator",betaccountcopy.Operator),
				 new MySqlParameter("?operatortime",betaccountcopy.Operatortime),
				 new MySqlParameter("?operatorip",betaccountcopy.Operatorip),
				 new MySqlParameter("?id",betaccountcopy.Id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-9-12 14:32:18		
        ///</summary>		
        public Boolean DeleteBetaccountcopyByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2010-9-12 14:32:18		
        ///</summary>		
        public Betaccountcopy GetBetaccountcopyByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};

            return MySqlModelHelper<Betaccountcopy>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2010-9-12 14:32:18		
        ///</summary>		
        public IList<Betaccountcopy> GetMutilILBetaccountcopy()
        {
            return MySqlModelHelper<Betaccountcopy>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2010-9-12 14:32:18		
        ///</summary>		
        public DataTable GetMutilDTBetaccountcopy()
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
                    where += " agent='" + dali.Replace("'", "") + "'";
                }
                else
                {
                    where += " and agent='" + dali.Replace("'", "") + "'";
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

        public string getCount(string casino, string dali, string id, string enable, string webPoss, string Company)
        {
            string str = "select count(*) from betaccountcopy ";
            string where = "where";
            if (casino != "0")
            {
                where += " casino=" + casino;
            }
            if (dali != "")
            {
                if (where == "where")
                {
                    where += " agent='" + dali.Replace("'", "") + "'";
                }
                else
                {
                    where += " and agent='" + dali.Replace("'", "") + "'";
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