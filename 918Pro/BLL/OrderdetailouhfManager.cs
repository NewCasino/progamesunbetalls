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
	public class OrderdetailouhfManager
	{
		private static OrderdetailouhfService orderdetailouhfService=new OrderdetailouhfService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-9-24 21:01:52
		///</sumary>
		public static Orderdetailouhf GetOrderdetailouhfByPK(object pk) 
		{
			try
			{
				return orderdetailouhfService.GetOrderdetailouhfByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-9-24 21:01:52
		///</sumary>
		public static Boolean AddOrderdetailouhf(Orderdetailouhf orderdetailouhf) 
		{
			try
			{
				return orderdetailouhfService.AddOrderdetailouhf(orderdetailouhf);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-9-24 21:01:52
		///</sumary>
		public static Boolean UpdateOrderdetailouhf(Orderdetailouhf orderdetailouhf) 
		{
			try
			{
				return orderdetailouhfService.UpdateOrderdetailouhf(orderdetailouhf);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-9-24 21:01:52
		///</sumary>
		public static Boolean DeleteOrderdetailouhfByPK(object pk) 
		{
			try
			{
				return orderdetailouhfService.DeleteOrderdetailouhfByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-9-24 21:01:52
		///</sumary>
		public static DataTable GetMutilDTOrderdetailouhf() 
		{
			try
			{
				return orderdetailouhfService.GetMutilDTOrderdetailouhf();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-9-24 21:01:52
		///</sumary>
		public static IList<Orderdetailouhf> GetMutilILOrderdetailouhf() 
		{
			try
			{
				return orderdetailouhfService.GetMutilILOrderdetailouhf();
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
