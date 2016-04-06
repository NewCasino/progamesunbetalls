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
	public class OrderotherhistoryManager
	{
		private static OrderotherhistoryService orderotherhistoryService=new OrderotherhistoryService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-9-24 21:04:56
		///</sumary>
		public static Orderotherhistory GetOrderotherhistoryByPK(object pk) 
		{
			try
			{
				return orderotherhistoryService.GetOrderotherhistoryByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-9-24 21:04:56
		///</sumary>
		public static Boolean AddOrderotherhistory(Orderotherhistory orderotherhistory) 
		{
			try
			{
				return orderotherhistoryService.AddOrderotherhistory(orderotherhistory);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-9-24 21:04:56
		///</sumary>
		public static Boolean UpdateOrderotherhistory(Orderotherhistory orderotherhistory) 
		{
			try
			{
				return orderotherhistoryService.UpdateOrderotherhistory(orderotherhistory);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-9-24 21:04:56
		///</sumary>
		public static Boolean DeleteOrderotherhistoryByPK(object pk) 
		{
			try
			{
				return orderotherhistoryService.DeleteOrderotherhistoryByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-9-24 21:04:56
		///</sumary>
		public static DataTable GetMutilDTOrderotherhistory() 
		{
			try
			{
				return orderotherhistoryService.GetMutilDTOrderotherhistory();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-9-24 21:04:56
		///</sumary>
		public static IList<Orderotherhistory> GetMutilILOrderotherhistory() 
		{
			try
			{
				return orderotherhistoryService.GetMutilILOrderotherhistory();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion

        public string GetOrderGroupByWebsiteID(string stime, string etime, string lan, string yy, string websiteid, string agent, string webusername)
        {
            return orderotherhistoryService.GetOrderGroupByWebsiteID(stime,etime,lan,yy,websiteid,agent,webusername);
        }

        public string GetOrderByWebsiteID(int websiteID, string agent, string webusername, string stime, string etime, string lan)
        {
            return orderotherhistoryService.GetOrderByWebsiteID(websiteID,agent,webusername,stime,etime,lan);
        }

        public int GetOrderCountByWebsiteID(int websiteID, string stime, string etime)
        {
            return orderotherhistoryService.GetOrderCountByWebsiteID(websiteID,stime,etime);
        }
	}
}
