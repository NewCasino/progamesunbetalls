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
	public class RatehistoryManager
	{
		private static RatehistoryService ratehistoryService=new RatehistoryService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-11-1 11:56:56
		///</sumary>
		public static Ratehistory GetRatehistoryByPK(object pk) 
		{
			try
			{
				return ratehistoryService.GetRatehistoryByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-11-1 11:56:56
		///</sumary>
		public static Boolean AddRatehistory(Rate ratehistory) 
		{
			try
			{
				return ratehistoryService.AddRatehistory(ratehistory);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-11-1 11:56:56
		///</sumary>
		public static Boolean UpdateRatehistory(Ratehistory ratehistory) 
		{
			try
			{
				return ratehistoryService.UpdateRatehistory(ratehistory);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-11-1 11:56:56
		///</sumary>
		public static Boolean DeleteRatehistoryByPK(object pk) 
		{
			try
			{
				return ratehistoryService.DeleteRatehistoryByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-11-1 11:56:56
		///</sumary>
		public static DataTable GetMutilDTRatehistory() 
		{
			try
			{
				return ratehistoryService.GetMutilDTRatehistory();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-11-1 11:56:56
		///</sumary>
		public static IList<Ratehistory> GetMutilILRatehistory() 
		{
			try
			{
				return ratehistoryService.GetMutilILRatehistory();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion

        public static string GetRate(string type, string time1, string time2, string language, string user)
        {
            return ratehistoryService.GetRate(type, time1, time2, language, user);
        }
    }
}
