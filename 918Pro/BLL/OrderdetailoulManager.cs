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
	public class OrderdetailoulManager
	{
		private static OrderdetailoulService orderdetailoulService=new OrderdetailoulService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-9-24 21:03:00
		///</sumary>
		public static Orderdetailoul GetOrderdetailoulByPK(object pk) 
		{
			try
			{
				return orderdetailoulService.GetOrderdetailoulByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-9-24 21:03:00
		///</sumary>
		public static Boolean AddOrderdetailoul(Orderdetailoul orderdetailoul) 
		{
			try
			{
				return orderdetailoulService.AddOrderdetailoul(orderdetailoul);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-9-24 21:03:00
		///</sumary>
		public static Boolean UpdateOrderdetailoul(Orderdetailoul orderdetailoul) 
		{
			try
			{
				return orderdetailoulService.UpdateOrderdetailoul(orderdetailoul);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-9-24 21:03:00
		///</sumary>
		public static Boolean DeleteOrderdetailoulByPK(object pk) 
		{
			try
			{
				return orderdetailoulService.DeleteOrderdetailoulByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-9-24 21:03:00
		///</sumary>
		public static DataTable GetMutilDTOrderdetailoul() 
		{
			try
			{
				return orderdetailoulService.GetMutilDTOrderdetailoul();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-9-24 21:03:00
		///</sumary>
		public static IList<Orderdetailoul> GetMutilILOrderdetailoul() 
		{
			try
			{
				return orderdetailoulService.GetMutilILOrderdetailoul();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion
	}
}
