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
	public class BetaccountmaxManager
	{
		private static BetaccountmaxService betaccountmaxService=new BetaccountmaxService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2011-3-25 15:00:32
		///</sumary>
		public static Betaccountmax GetBetaccountmaxByPK(object pk) 
		{
			try
			{
				return betaccountmaxService.GetBetaccountmaxByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2011-3-25 15:00:32
		///</sumary>
		public static Boolean AddBetaccountmax(Betaccountmax betaccountmax) 
		{
			try
			{
				return betaccountmaxService.AddBetaccountmax(betaccountmax);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2011-3-25 15:00:32
		///</sumary>
		public static Boolean UpdateBetaccountmax(Betaccountmax betaccountmax) 
		{
			try
			{
				return betaccountmaxService.UpdateBetaccountmax(betaccountmax);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2011-3-25 15:00:32
		///</sumary>
		public static Boolean DeleteBetaccountmaxByPK(object pk) 
		{
			try
			{
				return betaccountmaxService.DeleteBetaccountmaxByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2011-3-25 15:00:32
		///</sumary>
		public static DataTable GetMutilDTBetaccountmax() 
		{
			try
			{
				return betaccountmaxService.GetMutilDTBetaccountmax();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2011-3-25 15:00:32
		///</sumary>
		public static IList<Betaccountmax> GetMutilILBetaccountmax() 
		{
			try
			{
				return betaccountmaxService.GetMutilILBetaccountmax();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion

        public static string getAllCount(string casino, string dali, string id, string enable, string webPoss, string Company)
        {
            return betaccountmaxService.getAllCount(casino, dali, id, enable, webPoss, Company);
        }

        public static string getCount(string username)
        {
            return betaccountmaxService.getCount(username);
        }

        public static string getDataAll(int IDex, int IDexC, string casino, string dali, string id, string enable, string webPoss, string Company)
        {
            return betaccountmaxService.getDataAll(IDex, IDexC, casino, dali, id, enable, webPoss, Company);
        }

        public static IList<Betaccountmax> GetBetaccountByID(int id)
        {
            return betaccountmaxService.GetBetaccountByID(id);
        }

	}
}
