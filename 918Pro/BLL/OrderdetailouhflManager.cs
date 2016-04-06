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
	public class OrderdetailouhflManager
	{
		private static OrderdetailouhflService orderdetailouhflService=new OrderdetailouhflService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-9-24 21:02:25
		///</sumary>
		public static Orderdetailouhfl GetOrderdetailouhflByPK(object pk) 
		{
			try
			{
				return orderdetailouhflService.GetOrderdetailouhflByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-9-24 21:02:25
		///</sumary>
		public static Boolean AddOrderdetailouhfl(Orderdetailouhfl orderdetailouhfl) 
		{
			try
			{
				return orderdetailouhflService.AddOrderdetailouhfl(orderdetailouhfl);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-9-24 21:02:25
		///</sumary>
		public static Boolean UpdateOrderdetailouhfl(Orderdetailouhfl orderdetailouhfl) 
		{
			try
			{
				return orderdetailouhflService.UpdateOrderdetailouhfl(orderdetailouhfl);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-9-24 21:02:25
		///</sumary>
		public static Boolean DeleteOrderdetailouhflByPK(object pk) 
		{
			try
			{
				return orderdetailouhflService.DeleteOrderdetailouhflByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-9-24 21:02:25
		///</sumary>
		public static DataTable GetMutilDTOrderdetailouhfl() 
		{
			try
			{
				return orderdetailouhflService.GetMutilDTOrderdetailouhfl();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-9-24 21:02:25
		///</sumary>
		public static IList<Orderdetailouhfl> GetMutilILOrderdetailouhfl() 
		{
			try
			{
				return orderdetailouhflService.GetMutilILOrderdetailouhfl();
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
