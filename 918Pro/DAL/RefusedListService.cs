using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class RefusedListService
	{
		private const string SQL_INSERT="insert into yafa.RefusedList (reasoncn,reasontw,reasonen,reasonth,reasonvn,isdate,operator,operationtime,ip)values(?reasoncn,?reasontw,?reasonen,?reasonth,?reasonvn,?isdate,?operator,?operationtime,?ip)";
		private const string SQL_UPDATE="update yafa.RefusedList set reasoncn=?reasoncn,reasontw=?reasontw,reasonen=?reasonen,reasonth=?reasonth,reasonvn=?reasonvn,isdate=?isdate,operator=?operator,operationtime=?operationtime,ip=?ip where ID = ?ID";
		private const string SQL_SELECTBYPK="select ID from yafa.RefusedList  where RefusedList.ID = ?ID";
		private const string SQL_SELECTALL="select ID,reasoncn,reasontw,reasonen,reasonth,reasonvn,isdate,operator,operationtime,ip from yafa.RefusedList ";
		private const string SQL_DELETEBYPK="delete  from yafa.RefusedList  where RefusedList.ID = ?ID";
		
		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-4-14 21:35:13		
		///</summary>		
		public Boolean AddRefusedList(RefusedList refusedList)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?reasoncn",refusedList.Reasoncn),
				 new MySqlParameter("?reasontw",refusedList.Reasontw),
				 new MySqlParameter("?reasonen",refusedList.Reasonen),
				 new MySqlParameter("?reasonth",refusedList.Reasonth),
				 new MySqlParameter("?reasonvn",refusedList.Reasonvn),
				 new MySqlParameter("?isdate",refusedList.Isdate),
				 new MySqlParameter("?operator",refusedList.Operator),
				 new MySqlParameter("?operationtime",refusedList.Operationtime),
				 new MySqlParameter("?ip",refusedList.Ip)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-4-14 21:35:13		
		///</summary>		
		public Boolean UpdateRefusedList(RefusedList refusedList)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?reasoncn",refusedList.Reasoncn),
				 new MySqlParameter("?reasontw",refusedList.Reasontw),
				 new MySqlParameter("?reasonen",refusedList.Reasonen),
				 new MySqlParameter("?reasonth",refusedList.Reasonth),
				 new MySqlParameter("?reasonvn",refusedList.Reasonvn),
				 new MySqlParameter("?isdate",refusedList.Isdate),
				 new MySqlParameter("?operator",refusedList.Operator),
				 new MySqlParameter("?operationtime",refusedList.Operationtime),
				 new MySqlParameter("?ip",refusedList.Ip),
				 new MySqlParameter("?ID",refusedList.ID)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2011-4-14 21:35:13		
		///</summary>		
		public Boolean DeleteRefusedListByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2011-4-14 21:35:13		
		///</summary>		
		public RefusedList GetRefusedListByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

			return MySqlModelHelper<RefusedList>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2011-4-14 21:35:13		
		///</summary>		
		public IList<RefusedList> GetMutilILRefusedList()
		{
			return MySqlModelHelper<RefusedList>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2011-4-14 21:35:13		
		///</summary>		
		public DataTable GetMutilDTRefusedList()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 
	}
}
