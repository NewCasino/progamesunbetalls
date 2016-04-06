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
	public class RateManager
	{
		private static RateService rateService=new RateService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-11-1 11:56:35
		///</sumary>
		public static Rate GetRateByPK(object pk) 
		{
			try
			{
				return rateService.GetRateByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-11-1 11:56:35
		///</sumary>
		public static Boolean AddRate(Rate rate) 
		{
			try
			{
				return rateService.AddRate(rate);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-11-1 11:56:35
		///</sumary>
		public static Boolean UpdateRate(Rate rate) 
		{
			try
			{
				return rateService.UpdateRate(rate);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-11-1 11:56:35
		///</sumary>
        public static Boolean DeleteRateByPK(object pk) 
		{
			try
			{
                return rateService.DeleteRateByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-11-1 11:56:35
		///</sumary>
		public static DataTable GetMutilDTRate() 
		{
			try
			{
				return rateService.GetMutilDTRate();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-11-1 11:56:35
		///</sumary>
		public static IList<Rate> GetMutilILRate() 
		{
			try
			{
				return rateService.GetMutilILRate();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion

        public static string GetRateAll()
        {
            return ObjectToJson.ReaderToJson(rateService.GetRateAll());
        }

        public static string GetRateByLan(string language)
        {
            return rateService.GetRateByLan(language);
        }

        public static string GetRatetype(string Language)
        {
            return ObjectToJson.ReaderToJson(rateService.GetRatetype(Language));
        }


        public static bool CeliName(string Name, string Language)
        {
            return rateService.CeliName(Name, Language);
        }


        public static Boolean DeleteRate(object pk, string Name, string Language)
        {
            try
            {
                bool rest1 = rateService.DeleteRateByPK(pk);
                RatehistoryService ratehistoryService = new RatehistoryService();
                bool rest2 = ratehistoryService.DeleteRatehistory(Name, Language);
                if (rest1 || rest2)
                {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }
    }
}
