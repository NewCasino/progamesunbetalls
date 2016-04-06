using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class GradeService
	{
		private const string SQL_SELECTBYPK="select ID from yafa.grade  where grade.ID = ?ID";
		private const string SQL_SELECTALL="select ID,LevelName,LevelRemark from yafa.grade ";
		private const string SQL_DELETEBYPK="delete  from yafa.grade  where grade.ID = ?ID";

        /// <summary>
        /// 获取系统默认的会员等级
        /// </summary>
        /// <returns></returns>
        public Grade GetDefaultGrade()
        {
            string sqlStr = "select a.* from grade a,config b where a.LevelNamecn=b.Oval and b.Otype='会员等级'";
            return MySqlModelHelper<Grade>.GetSingleObjectBySql(sqlStr);
        }

        public Grade IsExistGrade(string levelName,string lan)
        {
            string sqlStr = "select * from grade where levelName"+lan+"=?levelName";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?levelName",levelName)
            };
            return MySqlModelHelper<Grade>.GetSingleObjectBySql(sqlStr, param);
        }

		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-10-20 21:48:02		
		///</summary>		
		public Boolean AddGrade(Grade grade,string lan)
		{
            string levelName = "";
            if (lan == "cn" || lan == "CN") {
                levelName = grade.LevelNamecn;
            }
            if (lan == "tw") {
                levelName = grade.LevelNamecn;
            }
            if (lan == "en")
            {
                levelName = grade.LevelNamecn;
            }
            if (lan == "th")
            {
                levelName = grade.LevelNamecn;
            }
            if (lan == "vn")
            {
                levelName = grade.LevelNamecn;
            }
		     string SQL_INSERT="insert into yafa.grade (LevelName"+lan+",LevelRemark)values(?LevelName,?LevelRemark)";
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?LevelName",levelName),
				 new MySqlParameter("?LevelRemark",grade.LevelRemark)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-10-20 21:48:02		
		///</summary>		
		public Boolean UpdateGrade(Grade grade,string lan)
        {
            string levelName = "";
            if (lan == "cn" || lan == "CN")
            {
                levelName = grade.LevelNamecn;
            }
            if (lan == "tw")
            {
                levelName = grade.LevelNametw;
            }
            if (lan == "en")
            {
                levelName = grade.LevelNameen;
            }
            if (lan == "th")
            {
                levelName = grade.LevelNameth;
            }
            if (lan == "vn")
            {
                levelName = grade.LevelNamevn;
            }
		     string SQL_UPDATE="update yafa.grade set LevelName"+lan+"=?LevelName,LevelRemark=?LevelRemark where ID = ?ID";
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?LevelName",levelName),
				 new MySqlParameter("?LevelRemark",grade.LevelRemark),
				 new MySqlParameter("?ID",grade.ID)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-10-20 21:48:02		
		///</summary>		
		public Boolean DeleteGradeByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2010-10-20 21:48:02		
		///</summary>		
		public Grade GetGradeByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

			return MySqlModelHelper<Grade>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2010-10-20 21:48:02		
		///</summary>		
		public IList<Grade> GetMutilILGrade()
		{
			return MySqlModelHelper<Grade>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2010-10-20 21:48:02		
		///</summary>		
		public DataTable GetMutilDTGrade()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 

        #region 编写人:李毅
        public string getJson(string lan)
        {
            string str = "select ID as a,LevelName"+lan+" as b,LevelRemark as c from yafa.grade ";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(str));
        }

        public string Update(string n,string r,string i,string lan)
        {
            string update= "update yafa.grade set LevelName" + lan + "=?LevelName,LevelRemark=?LevelRemark where ID = ?ID";
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?LevelName",n),
				 new MySqlParameter("?LevelRemark",r),
				 new MySqlParameter("?ID",i)
			};
            return (MySqlHelper.ExecuteNonQuery(update, param) > 0).ToString();
        }
        #endregion

        public System.Data.Common.DbDataReader GetGrade(string lan)
        {
            string SQL_SELECTLEVEL = "select distinct LevelName"+lan+" as b from yafa.grade ";
            return MySqlHelper.ExecuteReader(SQL_SELECTLEVEL, null);
        }

        public System.Data.Common.DbDataReader GetGradeName(int id,string lan)
        {
            string SQL_SELECTLEVELNAME = "select distinct LevelName"+lan+" as b from yafa.grade where ID='"+id+"'";
            return MySqlHelper.ExecuteReader(SQL_SELECTLEVELNAME, null);
        }

        public System.Data.Common.DbDataReader GetGradeId(string name,string lan)
        {
            string SQL_SELECTLEVELID = "select ID from yafa.grade where LevelName"+lan+"='" + name + "'";
            return MySqlHelper.ExecuteReader(SQL_SELECTLEVELID, null);
        }
        /// <summary>
        /// 根据多语言返回json数据
        /// </summary>
        /// <param name="lan">多语言</param>
        /// <returns></returns>
        public string GetGradeByLan(string lan)
        {
            string subSql = "";
            string sqlStr = "";
            switch (lan)
            {
                case "zh-cn":
                    subSql = "LevelNamecn as Lname,";
                    break;
                case "zh-tw":
                    subSql = "LevelNametw as Lname,";
                    break;
                case "en-us":
                    subSql = "LevelNameen as Lname,";
                    break;
                case "th-th":
                    subSql = "LevelNameth as Lname,";
                    break;
                case "vi-vn":
                    subSql = "LevelNamevn as Lname,";
                    break;
            }
            sqlStr = "select ID," + subSql + "LevelRemark from grade order by ID";
            string restr = ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(sqlStr));
            return restr;
        }

    }
}
