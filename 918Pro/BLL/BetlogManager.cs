using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Model;
using DAL;
namespace BLL
{
		///<sumary>
		///业务逻辑类
		///</sumary>
	public class BetlogManager
	{
		private static BetlogService betlogService=new BetlogService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2011-7-9 19:57:10
		///</sumary>
		public static Betlog GetBetlogByPK(object pk) 
		{
			try
			{
				return betlogService.GetBetlogByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2011-7-9 19:57:10
		///</sumary>
		public static Boolean AddBetlog(Betlog betlog) 
		{
			try
			{
				return betlogService.AddBetlog(betlog);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2011-7-9 19:57:10
		///</sumary>
		public static Boolean UpdateBetlog(Betlog betlog) 
		{
			try
			{
				return betlogService.UpdateBetlog(betlog);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2011-7-9 19:57:10
		///</sumary>
		public static Boolean DeleteBetlogByPK(object pk) 
		{
			try
			{
				return betlogService.DeleteBetlogByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2011-7-9 19:57:10
		///</sumary>
		public static DataTable GetMutilDTBetlog() 
		{
			try
			{
				return betlogService.GetMutilDTBetlog();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2011-7-9 19:57:10
		///</sumary>
		public static IList<Betlog> GetMutilILBetlog() 
		{
			try
			{
				return betlogService.GetMutilILBetlog();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion

        public string GetBetlogByWhere(string userid, string casino, string gametype)
        {
            return betlogService.GetBetlogByWhere(userid, casino, gametype);
        }

        public bool DeleBetlog()
        {
            return betlogService.DeleBetlog();
        }
	}
}
