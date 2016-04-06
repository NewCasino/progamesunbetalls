using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class Matches_copyService
	{
        private const string SQL_INSERT = "insert into yafa.matches_copy (number,matchid,leaguecn,leaguetw,leagueen,leagueth,leaguevn,league1,color,time,begintime,homecn,hometw,homeen,hometh,homevn,home1,awaycn,awaytw,awayen,awayth,awayvn,away1,running,score,redcard,danger,dotime,isstart,state,display,resulthomescore,resultawayscore,halfhomescore,halfawayscore,updatetime,type,casino,reason,scoreinputtime,scoreinputuser,jstime,jsuser,resulthomescore2,resultawayscore2,halfhomescore2,halfawayscore2)values(?number,?matchid,?leaguecn,?leaguetw,?leagueen,?leagueth,?leaguevn,?league1,?color,?time,?begintime,?homecn,?hometw,?homeen,?hometh,?homevn,?home1,?awaycn,?awaytw,?awayen,?awayth,?awayvn,?away1,?running,?score,?redcard,?danger,?dotime,?isstart,?state,?display,?resulthomescore,?resultawayscore,?halfhomescore,?halfawayscore,?updatetime,?type,?casino,?reason,?scoreinputtime,?scoreinputuser,?jstime,?jsuser,?resulthomescore2,?resultawayscore2,?halfhomescore2,?halfawayscore2)";
        private const string SQL_UPDATE = "update yafa.matches_copy set number=?number,matchid=?matchid,leaguecn=?leaguecn,leaguetw=?leaguetw,leagueen=?leagueen,leagueth=?leagueth,leaguevn=?leaguevn,league1=?league1,color=?color,time=?time,begintime=?begintime,homecn=?homecn,hometw=?hometw,homeen=?homeen,hometh=?hometh,homevn=?homevn,home1=?home1,awaycn=?awaycn,awaytw=?awaytw,awayen=?awayen,awayth=?awayth,awayvn=?awayvn,away1=?away1,running=?running,score=?score,redcard=?redcard,danger=?danger,dotime=?dotime,isstart=?isstart,state=?state,display=?display,resulthomescore=?resulthomescore,resultawayscore=?resultawayscore,halfhomescore=?halfhomescore,halfawayscore=?halfawayscore,updatetime=?updatetime,type=?type,casino=?casino,reason=?reason,scoreinputtime=?scoreinputtime,scoreinputuser=?scoreinputuser,jstime=?jstime,jsuser=?jsuser,resulthomescore2=?resulthomescore2,resultawayscore2=?resultawayscore2,halfhomescore2=?halfhomescore2,halfawayscore2=?halfawayscore2 where id = ?id";
        private const string SQL_SELECTBYPK = "select id from yafa.matches_copy  where matches_copy.id = ?id";
        private const string SQL_SELECTALL = "select id,number,matchid,leaguecn,leaguetw,leagueen,leagueth,leaguevn,league1,color,time,begintime,homecn,hometw,homeen,hometh,homevn,home1,awaycn,awaytw,awayen,awayth,awayvn,away1,running,score,redcard,danger,dotime,isstart,state,display,resulthomescore,resultawayscore,halfhomescore,halfawayscore,updatetime,type,casino,reason,scoreinputtime,scoreinputuser,jstime,jsuser,resulthomescore2,resultawayscore2,halfhomescore2,halfawayscore2 from yafa.matches_copy ";
        private const string SQL_DELETEBYPK = "delete  from yafa.matches_copy  where matches_copy.id = ?id";
		
#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-6-1 14:31:11		
		///</summary>		
		public Boolean AddMatches_copy(Matches_copy matches_copy)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?number",matches_copy.Number),
				 new MySqlParameter("?matchid",matches_copy.Matchid),
				 new MySqlParameter("?leaguecn",matches_copy.Leaguecn),
				 new MySqlParameter("?leaguetw",matches_copy.Leaguetw),
				 new MySqlParameter("?leagueen",matches_copy.Leagueen),
				 new MySqlParameter("?leagueth",matches_copy.Leagueth),
				 new MySqlParameter("?leaguevn",matches_copy.Leaguevn),
				 new MySqlParameter("?league1",matches_copy.League1),
				 new MySqlParameter("?color",matches_copy.Color),
				 new MySqlParameter("?time",matches_copy.Time),
				 new MySqlParameter("?begintime",matches_copy.Begintime),
				 new MySqlParameter("?homecn",matches_copy.Homecn),
				 new MySqlParameter("?hometw",matches_copy.Hometw),
				 new MySqlParameter("?homeen",matches_copy.Homeen),
				 new MySqlParameter("?hometh",matches_copy.Hometh),
				 new MySqlParameter("?homevn",matches_copy.Homevn),
				 new MySqlParameter("?home1",matches_copy.Home1),
				 new MySqlParameter("?awaycn",matches_copy.Awaycn),
				 new MySqlParameter("?awaytw",matches_copy.Awaytw),
				 new MySqlParameter("?awayen",matches_copy.Awayen),
				 new MySqlParameter("?awayth",matches_copy.Awayth),
				 new MySqlParameter("?awayvn",matches_copy.Awayvn),
				 new MySqlParameter("?away1",matches_copy.Away1),
				 new MySqlParameter("?running",matches_copy.Running),
				 new MySqlParameter("?score",matches_copy.Score),
				 new MySqlParameter("?redcard",matches_copy.Redcard),
				 new MySqlParameter("?danger",matches_copy.Danger),
				 new MySqlParameter("?dotime",matches_copy.Dotime),
				 new MySqlParameter("?isstart",matches_copy.Isstart),
				 new MySqlParameter("?state",matches_copy.State),
				 new MySqlParameter("?display",matches_copy.Display),
				 new MySqlParameter("?resulthomescore",matches_copy.Resulthomescore),
				 new MySqlParameter("?resultawayscore",matches_copy.Resultawayscore),
				 new MySqlParameter("?halfhomescore",matches_copy.Halfhomescore),
				 new MySqlParameter("?halfawayscore",matches_copy.Halfawayscore),
				 new MySqlParameter("?updatetime",matches_copy.Updatetime),
				 new MySqlParameter("?type",matches_copy.Type),
				 new MySqlParameter("?casino",matches_copy.Casino),
				 new MySqlParameter("?reason",matches_copy.Reason),
				 new MySqlParameter("?scoreinputtime",matches_copy.Scoreinputtime),
				 new MySqlParameter("?scoreinputuser",matches_copy.Scoreinputuser),
				 new MySqlParameter("?jstime",matches_copy.Jstime),
				 new MySqlParameter("?jsuser",matches_copy.Jsuser),
				 new MySqlParameter("?resulthomescore2",matches_copy.Resulthomescore2),
				 new MySqlParameter("?resultawayscore2",matches_copy.Resultawayscore2),
				 new MySqlParameter("?halfhomescore2",matches_copy.Halfhomescore2),
				 new MySqlParameter("?halfawayscore2",matches_copy.Halfawayscore2)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-6-1 14:31:11		
		///</summary>		
		public Boolean UpdateMatches_copy(Matches_copy matches_copy)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?number",matches_copy.Number),
				 new MySqlParameter("?matchid",matches_copy.Matchid),
				 new MySqlParameter("?leaguecn",matches_copy.Leaguecn),
				 new MySqlParameter("?leaguetw",matches_copy.Leaguetw),
				 new MySqlParameter("?leagueen",matches_copy.Leagueen),
				 new MySqlParameter("?leagueth",matches_copy.Leagueth),
				 new MySqlParameter("?leaguevn",matches_copy.Leaguevn),
				 new MySqlParameter("?league1",matches_copy.League1),
				 new MySqlParameter("?color",matches_copy.Color),
				 new MySqlParameter("?time",matches_copy.Time),
				 new MySqlParameter("?begintime",matches_copy.Begintime),
				 new MySqlParameter("?homecn",matches_copy.Homecn),
				 new MySqlParameter("?hometw",matches_copy.Hometw),
				 new MySqlParameter("?homeen",matches_copy.Homeen),
				 new MySqlParameter("?hometh",matches_copy.Hometh),
				 new MySqlParameter("?homevn",matches_copy.Homevn),
				 new MySqlParameter("?home1",matches_copy.Home1),
				 new MySqlParameter("?awaycn",matches_copy.Awaycn),
				 new MySqlParameter("?awaytw",matches_copy.Awaytw),
				 new MySqlParameter("?awayen",matches_copy.Awayen),
				 new MySqlParameter("?awayth",matches_copy.Awayth),
				 new MySqlParameter("?awayvn",matches_copy.Awayvn),
				 new MySqlParameter("?away1",matches_copy.Away1),
				 new MySqlParameter("?running",matches_copy.Running),
				 new MySqlParameter("?score",matches_copy.Score),
				 new MySqlParameter("?redcard",matches_copy.Redcard),
				 new MySqlParameter("?danger",matches_copy.Danger),
				 new MySqlParameter("?dotime",matches_copy.Dotime),
				 new MySqlParameter("?isstart",matches_copy.Isstart),
				 new MySqlParameter("?state",matches_copy.State),
				 new MySqlParameter("?display",matches_copy.Display),
				 new MySqlParameter("?resulthomescore",matches_copy.Resulthomescore),
				 new MySqlParameter("?resultawayscore",matches_copy.Resultawayscore),
				 new MySqlParameter("?halfhomescore",matches_copy.Halfhomescore),
				 new MySqlParameter("?halfawayscore",matches_copy.Halfawayscore),
				 new MySqlParameter("?updatetime",matches_copy.Updatetime),
				 new MySqlParameter("?type",matches_copy.Type),
				 new MySqlParameter("?casino",matches_copy.Casino),
				 new MySqlParameter("?reason",matches_copy.Reason),
				 new MySqlParameter("?scoreinputtime",matches_copy.Scoreinputtime),
				 new MySqlParameter("?scoreinputuser",matches_copy.Scoreinputuser),
				 new MySqlParameter("?jstime",matches_copy.Jstime),
				 new MySqlParameter("?jsuser",matches_copy.Jsuser),
				 new MySqlParameter("?resulthomescore2",matches_copy.Resulthomescore2),
				 new MySqlParameter("?resultawayscore2",matches_copy.Resultawayscore2),
				 new MySqlParameter("?halfhomescore2",matches_copy.Halfhomescore2),
				 new MySqlParameter("?halfawayscore2",matches_copy.Halfawayscore2),
				 new MySqlParameter("?id",matches_copy.Id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-6-1 14:31:11		
		///</summary>		
		public Boolean DeleteMatches_copyByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2011-6-1 14:31:11		
		///</summary>		
		public Matches_copy GetMatches_copyByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?id",id)
			};

			return MySqlModelHelper<Matches_copy>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2011-6-1 14:31:11		
		///</summary>		
		public IList<Matches_copy> GetMutilILMatches_copy()
		{
			return MySqlModelHelper<Matches_copy>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2011-6-1 14:31:11		
		///</summary>		
		public DataTable GetMutilDTMatches_copy()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 
    }
}
