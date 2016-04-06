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
	public class Orderdetail1x2hflManager
	{
		private static Orderdetail1x2hflService orderdetail1x2hflService=new Orderdetail1x2hflService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-9-24 20:56:59
		///</sumary>
		public static Orderdetail1x2hfl GetOrderdetail1x2hflByPK(object pk) 
		{
			try
			{
				return orderdetail1x2hflService.GetOrderdetail1x2hflByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-9-24 20:56:59
		///</sumary>
		public static Boolean AddOrderdetail1x2hfl(Orderdetail1x2hfl orderdetail1x2hfl) 
		{
			try
			{
				return orderdetail1x2hflService.AddOrderdetail1x2hfl(orderdetail1x2hfl);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-9-24 20:56:59
		///</sumary>
		public static Boolean UpdateOrderdetail1x2hfl(Orderdetail1x2hfl orderdetail1x2hfl) 
		{
			try
			{
				return orderdetail1x2hflService.UpdateOrderdetail1x2hfl(orderdetail1x2hfl);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-9-24 20:56:59
		///</sumary>
		public static Boolean DeleteOrderdetail1x2hflByPK(object pk) 
		{
			try
			{
				return orderdetail1x2hflService.DeleteOrderdetail1x2hflByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-9-24 20:56:59
		///</sumary>
		public static DataTable GetMutilDTOrderdetail1x2hfl() 
		{
			try
			{
				return orderdetail1x2hflService.GetMutilDTOrderdetail1x2hfl();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-9-24 20:56:59
		///</sumary>
		public static IList<Orderdetail1x2hfl> GetMutilILOrderdetail1x2hfl() 
		{
			try
			{
				return orderdetail1x2hflService.GetMutilILOrderdetail1x2hfl();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion
        #region 编写人:李毅
        public static string GetAllTolength(string length, string league, string level, string type, string money, string ballteam, string language,string username,string roid)
        {
            return orderdetail1x2hflService.GetAllTolength(length, league, level, type, money, ballteam, language, username, roid);
        }
        public static string setBalance(string username, string money)
        {
            return orderdetail1x2hflService.setBalance(username, money);
        }
        #endregion
	}
}
