using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
    public class CasinoService
    {
        private const string SQL_INSERT = "insert into yafa.casino (namecn,nametw,nameen,nameth,nametv,display,address,path,ord)values(?namecn,?nametw,?nameen,?nameth,?nametv,?display,?address,?path,?ord)";
        private const string SQL_UPDATE = "update yafa.casino set namecn=?namecn,nametw=?nametw,nameen=?nameen,nameth=?nameth,nametv=?nametv,display=?display,address=?address,path=?path,ord=?ord where id = ?id";
        private const string SQL_SELECTBYPK = "select id from yafa.casino  where casino.id = ?id";
        private const string SQL_SELECTALL = "select id,namecn,nametw,nameen,nameth,nametv,display,address,path,ord from yafa.casino ";
        private const string SQL_DELETEBYPK = "delete  from yafa.casino  where casino.id = ?id";
        private const string SQL_SELECTCASINOALL = "select id as a,namecn as b,nametw as c,nameen as d,nameth as e,nametv as f from yafa.casino where display=1 ";

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-9-12 14:23:31		
        ///</summary>		
        public Boolean AddCasino(Casino casino)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?namecn",casino.Namecn),
				 new MySqlParameter("?nametw",casino.Nametw),
				 new MySqlParameter("?nameen",casino.Nameen),
				 new MySqlParameter("?nameth",casino.Nameth),
				 new MySqlParameter("?nametv",casino.Nametv),
				 new MySqlParameter("?display",casino.Display),
				 new MySqlParameter("?address",casino.Address),
				 new MySqlParameter("?path",casino.Path),
				 new MySqlParameter("?ord",casino.Ord)
			};
            return MySqlHelper2.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-9-12 14:23:31		
        ///</summary>		
        public Boolean UpdateCasino(Casino casino)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?namecn",casino.Namecn),
				 new MySqlParameter("?nametw",casino.Nametw),
				 new MySqlParameter("?nameen",casino.Nameen),
				 new MySqlParameter("?nameth",casino.Nameth),
				 new MySqlParameter("?nametv",casino.Nametv),
				 new MySqlParameter("?display",casino.Display),
				 new MySqlParameter("?address",casino.Address),
				 new MySqlParameter("?path",casino.Path),
				 new MySqlParameter("?ord",casino.Ord),
				 new MySqlParameter("?id",casino.Id)
			};
            return MySqlHelper2.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-9-12 14:23:31		
        ///</summary>		
        public Boolean DeleteCasinoByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};
            return MySqlHelper2.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2010-9-12 14:23:31		
        ///</summary>		
        public Casino GetCasinoByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};

            return MySqlModelHelper2<Casino>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2010-9-12 14:23:31		
        ///</summary>		
        public IList<Casino> GetMutilILCasino()
        {
            return MySqlModelHelper2<Casino>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2010-9-12 14:23:31		
        ///</summary>		
        public DataTable GetMutilDTCasino()
        {
            return MySqlHelper2.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion

        #region 编写人:李毅
        public string getDataAll(int IDex, int IDexC)
        {
            return ObjectToJson.ReaderToJson(MySqlHelper2.ExecuteReader(SQL_SELECTALL + " limit " + IDex + "," + IDexC));
        }

        public string getDataAll()
        {
            return ObjectToJson.ReaderToJson(MySqlHelper2.ExecuteReader(SQL_SELECTALL));
        }

        public string selectInfo(string cn, string tw, string en, string th, string tv)
        {
            string str = "select count(*) from casino where namecn=?cn or nametw=?tw or nameen=?en or nameth=?th or nametv=?tv";
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?cn",cn),
                new MySqlParameter("?tw",tw),
                new MySqlParameter("?en",en),
                new MySqlParameter("?th",th),
                new MySqlParameter("?tv",tv)
            };
            return MySqlHelper2.ExecuteScalar(str, param).ToString();
        }

        public string getCount()
        {
            string str = "select count(*) from casino";
            return MySqlHelper2.ExecuteScalar(str).ToString();
        }
        #endregion
        
        public string getCasinoDataAll()
        {
            var json = ObjectToJson.ReaderToJson(MySqlHelper2.ExecuteReader(SQL_SELECTCASINOALL));
            return json == "[]" ? "none" : json;
        }
    }
}
