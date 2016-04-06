using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class NoticeService
	{
		private const string SQL_INSERT="insert into yafa.notice (msgcn,msgtw,msgen,msgth,msgvn,displayuser,windowagent,windowuser,createdate,createuser,displayagent)values(?msgcn,?msgtw,?msgen,?msgth,?msgvn,?displayuser,?windowagent,?windowuser,?createdate,?createuser,?displayagent)";
		private const string SQL_UPDATE="update yafa.notice set msgcn=?msgcn,msgtw=?msgtw,msgen=?msgen,msgth=?msgth,msgvn=?msgvn,displayuser=?displayuser,windowagent=?windowagent,windowuser=?windowuser,createdate=?createdate,createuser=?createuser,displayagent=?displayagent where ID = ?ID";
		private const string SQL_SELECTBYPK="select ID from yafa.notice  where notice.ID = ?ID";
		private const string SQL_SELECTALL="select ID,msgcn,msgtw,msgen,msgth,msgvn,displayuser,windowagent,windowuser,createdate,createuser,displayagent from yafa.notice ";
		private const string SQL_DELETEBYPK="delete  from yafa.notice  where notice.ID = ?ID";

      
        private const string SQL_SELECTALL22 = "select ID,msgcn,msgtw,msgen,msgth,msgvn,displayuser,windowagent,windowuser,createdate,createuser,displayagent from yafa.notice_2 ";
        private const string SQL_UPDATE22 = "update yafa.notice_2 set msgcn=?msgcn,msgtw=?msgtw,msgen=?msgen,msgth=?msgth,msgvn=?msgvn,displayuser=?displayuser,windowagent=?windowagent,windowuser=?windowuser,createdate=?createdate,createuser=?createuser,displayagent=?displayagent where ID = ?ID";
		
		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-1-6 20:18:20		
		///</summary>		
		public Boolean AddNotice(Notice notice)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?msgcn",notice.Msgcn),
				 new MySqlParameter("?msgtw",notice.Msgtw),
				 new MySqlParameter("?msgen",notice.Msgen),
				 new MySqlParameter("?msgth",notice.Msgth),
				 new MySqlParameter("?msgvn",notice.Msgvn),
				 new MySqlParameter("?displayuser",notice.Displayuser),
				 new MySqlParameter("?windowagent",notice.Windowagent),
				 new MySqlParameter("?windowuser",notice.Windowuser),
				 new MySqlParameter("?createdate",notice.Createdate),
				 new MySqlParameter("?createuser",notice.Createuser),
				 new MySqlParameter("?displayagent",notice.Displayagent)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-1-6 20:18:20		
		///</summary>		
		public Boolean UpdateNotice(Notice notice)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?msgcn",notice.Msgcn),
				 new MySqlParameter("?msgtw",notice.Msgtw),
				 new MySqlParameter("?msgen",notice.Msgen),
				 new MySqlParameter("?msgth",notice.Msgth),
				 new MySqlParameter("?msgvn",notice.Msgvn),
				 new MySqlParameter("?displayuser",notice.Displayuser),
				 new MySqlParameter("?windowagent",notice.Windowagent),
				 new MySqlParameter("?windowuser",notice.Windowuser),
				 new MySqlParameter("?createdate",notice.Createdate),
				 new MySqlParameter("?createuser",notice.Createuser),
				 new MySqlParameter("?displayagent",notice.Displayagent),
				 new MySqlParameter("?ID",notice.ID)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}


        public Boolean UpdateNotice222(Notice notice)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?msgcn",notice.Msgcn),
				 new MySqlParameter("?msgtw",notice.Msgtw),
				 new MySqlParameter("?msgen",notice.Msgen),
				 new MySqlParameter("?msgth",notice.Msgth),
				 new MySqlParameter("?msgvn",notice.Msgvn),
				 new MySqlParameter("?displayuser",notice.Displayuser),
				 new MySqlParameter("?windowagent",notice.Windowagent),
				 new MySqlParameter("?windowuser",notice.Windowuser),
				 new MySqlParameter("?createdate",notice.Createdate),
				 new MySqlParameter("?createuser",notice.Createuser),
				 new MySqlParameter("?displayagent",notice.Displayagent),
				 new MySqlParameter("?ID",notice.ID)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE22, param) > 0;
        }
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-1-6 20:18:20		
		///</summary>		
		public Boolean DeleteNoticeByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}


        public Boolean  DeleteNoticeByPK222(object id)
        {
            string str = "delete  from yafa.pro_game  where pro_game.ID = ?ID";
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
            return MySqlHelper.ExecuteNonQuery(str, param) > 0;
        }
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2011-1-6 20:18:20		
		///</summary>		
		public Notice GetNoticeByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

			return MySqlModelHelper<Notice>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2011-1-6 20:18:20		
		///</summary>		
		public IList<Notice> GetMutilILNotice()
		{
			return MySqlModelHelper<Notice>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2011-1-6 20:18:20		
		///</summary>		
		public DataTable GetMutilDTNotice()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 
        
        public IList<Notice> GetNoticeBylan2(string lan)
        {
            string sql = "";
            string subSql = "";
            switch (lan)
            {
                case "zh-cn":
                    subSql = " msgcn, ";
                    break;
                case "zh-tw":
                    subSql = " msgtw, ";
                    break;
                case "en-us":
                    subSql = " msgen, ";
                    break;
                case "th-th":
                    subSql = " msgth, ";
                    break;
                case "vi-vn":
                    subSql = " msgvn, ";
                    break;
            }
            sql = "select " + subSql + " displayuser,windowagent,windowuser,createdate,displayagent from notice_2 order by ID desc";

            return MySqlModelHelper<Notice>.GetObjectsBySql(sql);
        }



        public IList<Notice> GetNoticeBylan(string lan)
        {
            string sql = "";
            string subSql = "";
            switch (lan)
            {
                case "zh-cn":
                    subSql = " msgcn, ";
                    break;
                case "zh-tw":
                    subSql = " msgtw, ";
                    break;
                case "en-us":
                    subSql = " msgen, ";
                    break;
                case "th-th":
                    subSql = " msgth, ";
                    break;
                case "vi-vn":
                    subSql = " msgvn, ";
                    break;
            }
            sql = "select " + subSql + " displayuser,windowagent,windowuser,createdate,displayagent from notice order by ID desc";

            return MySqlModelHelper<Notice>.GetObjectsBySql(sql);
        }

        #region 编写人:李毅

        public string getCount22()
        {
            string str = "select count(*) from notice_2";
            return MySqlHelper.ExecuteScalar(str).ToString();
        }


        public string getCount()
        {
            string str = "select count(*) from notice";
            return MySqlHelper.ExecuteScalar(str).ToString();
        }
        public string getDataAll(int IDex, int IDexC)
        {
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(SQL_SELECTALL + " limit " + IDex + "," + IDexC));
        }

       
         public string getDataAll_1()
        {
            string strs = "select id,type,BigPric,samlPric,title,conent from yafa.pro_game where type = 0";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(strs));
        }
         public string getDataAll_2()
        {
            string strs = "select id,type,BigPric,samlPric,title,conent from yafa.pro_game where type = 1";
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(strs));
        }
        public string getDataAll222()
        {
            return ObjectToJson.ReaderToJson(MySqlHelper.ExecuteReader(SQL_SELECTALL22));
        }
        #endregion

      
    }
}
