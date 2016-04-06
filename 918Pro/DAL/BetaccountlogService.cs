using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
    public class BetaccountlogService
    {
        private const string SQL_INSERT = "insert into yafa.betaccountlog (casino,userid,password,agent,websitePossess,selfPossess,commission,multiple,group1,address,address2,enable,zemo,isquzhi,cookie,time,operator,operatortime,operatorip)values(?casino,?userid,?password,?agent,?websitePossess,?selfPossess,?commission,?multiple,?group1,?address,?address2,?enable,?zemo,?isquzhi,?cookie,?time,?operator,?operatortime,?operatorip)";
        private const string SQL_UPDATE = "update yafa.betaccountlog set casino=?casino,userid=?userid,password=?password,agent=?agent,websitePossess=?websitePossess,selfPossess=?selfPossess,commission=?commission,multiple=?multiple,group1=?group1,address=?address,address2=?address2,enable=?enable,zemo=?zemo,isquzhi=?isquzhi,cookie=?cookie,time=?time,operator=?operator,operatortime=?operatortime,operatorip=?operatorip where id = ?id";
        private const string SQL_SELECTBYPK = "select id from yafa.betaccountlog  where betaccountlog.id = ?id";
        private const string SQL_SELECTALL = "select id,casino,userid,password,agent,websitePossess,selfPossess,commission,multiple,group1,address,address2,enable,zemo,isquzhi,cookie,time,operator,operatortime,operatorip from yafa.betaccountlog ";
        private const string SQL_DELETEBYPK = "delete  from yafa.betaccountlog  where betaccountlog.id = ?id";

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-9-12 14:33:48		
        ///</summary>		
        public Boolean AddBetaccountlog(Betaccountlog betaccountlog)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?casino",betaccountlog.Casino),
				 new MySqlParameter("?userid",betaccountlog.Userid),
				 new MySqlParameter("?password",betaccountlog.Password),
				 new MySqlParameter("?agent",betaccountlog.Agent),
				 new MySqlParameter("?websitePossess",betaccountlog.WebsitePossess),
				 new MySqlParameter("?selfPossess",betaccountlog.SelfPossess),
				 new MySqlParameter("?commission",betaccountlog.Commission),
				 new MySqlParameter("?multiple",betaccountlog.Multiple),
				 new MySqlParameter("?group1",betaccountlog.Group1),
				 new MySqlParameter("?address",betaccountlog.Address),
				 new MySqlParameter("?address2",betaccountlog.Address2),
				 new MySqlParameter("?enable",betaccountlog.Enable),
				 new MySqlParameter("?zemo",betaccountlog.Zemo),
				 new MySqlParameter("?isquzhi",betaccountlog.Isquzhi),
				 new MySqlParameter("?cookie",betaccountlog.Cookie),
				 new MySqlParameter("?time",betaccountlog.Time),
				 new MySqlParameter("?operator",betaccountlog.Operator),
				 new MySqlParameter("?operatortime",betaccountlog.Operatortime),
				 new MySqlParameter("?operatorip",betaccountlog.Operatorip)
			};
            return MySqlHelper2.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-9-12 14:33:48		
        ///</summary>		
        public Boolean UpdateBetaccountlog(Betaccountlog betaccountlog)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?casino",betaccountlog.Casino),
				 new MySqlParameter("?userid",betaccountlog.Userid),
				 new MySqlParameter("?password",betaccountlog.Password),
				 new MySqlParameter("?agent",betaccountlog.Agent),
				 new MySqlParameter("?websitePossess",betaccountlog.WebsitePossess),
				 new MySqlParameter("?selfPossess",betaccountlog.SelfPossess),
				 new MySqlParameter("?commission",betaccountlog.Commission),
				 new MySqlParameter("?multiple",betaccountlog.Multiple),
				 new MySqlParameter("?group1",betaccountlog.Group1),
				 new MySqlParameter("?address",betaccountlog.Address),
				 new MySqlParameter("?address2",betaccountlog.Address2),
				 new MySqlParameter("?enable",betaccountlog.Enable),
				 new MySqlParameter("?zemo",betaccountlog.Zemo),
				 new MySqlParameter("?isquzhi",betaccountlog.Isquzhi),
				 new MySqlParameter("?cookie",betaccountlog.Cookie),
				 new MySqlParameter("?time",betaccountlog.Time),
				 new MySqlParameter("?operator",betaccountlog.Operator),
				 new MySqlParameter("?operatortime",betaccountlog.Operatortime),
				 new MySqlParameter("?operatorip",betaccountlog.Operatorip),
				 new MySqlParameter("?id",betaccountlog.Id)
			};
            return MySqlHelper2.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-9-12 14:33:48		
        ///</summary>		
        public Boolean DeleteBetaccountlogByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};
            return MySqlHelper2.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2010-9-12 14:33:48		
        ///</summary>		
        public Betaccountlog GetBetaccountlogByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};

            return MySqlModelHelper2<Betaccountlog>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2010-9-12 14:33:48		
        ///</summary>		
        public IList<Betaccountlog> GetMutilILBetaccountlog()
        {
            return MySqlModelHelper2<Betaccountlog>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2010-9-12 14:33:48		
        ///</summary>		
        public DataTable GetMutilDTBetaccountlog()
        {
            return MySqlHelper2.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion

        #region 编写人:李毅
        public string getDataAll(int IDex, int IDexC)
        {
            return ObjectToJson.ReaderToJson(MySqlHelper2.ExecuteReader(SQL_SELECTALL + " limit " + IDex + "," + IDexC));
        }

        public string getCount()
        {
            string str = "select count(*) from betaccountlog";
            return MySqlHelper2.ExecuteScalar(str).ToString();
        }
        #endregion
    }
}