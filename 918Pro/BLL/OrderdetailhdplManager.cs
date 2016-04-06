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
	public class OrderdetailhdplManager
	{
		private static OrderdetailhdplService orderdetailhdplService=new OrderdetailhdplService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-9-24 21:00:09
		///</sumary>
		public static Orderdetailhdpl GetOrderdetailhdplByPK(object pk) 
		{
			try
			{
				return orderdetailhdplService.GetOrderdetailhdplByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-9-24 21:00:09
		///</sumary>
		public static Boolean AddOrderdetailhdpl(Orderdetailhdpl orderdetailhdpl) 
		{
			try
			{
				return orderdetailhdplService.AddOrderdetailhdpl(orderdetailhdpl);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-9-24 21:00:09
		///</sumary>
		public static Boolean UpdateOrderdetailhdpl(Orderdetailhdpl orderdetailhdpl) 
		{
			try
			{
				return orderdetailhdplService.UpdateOrderdetailhdpl(orderdetailhdpl);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-9-24 21:00:09
		///</sumary>
		public static Boolean DeleteOrderdetailhdplByPK(object pk) 
		{
			try
			{
				return orderdetailhdplService.DeleteOrderdetailhdplByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-9-24 21:00:09
		///</sumary>
		public static DataTable GetMutilDTOrderdetailhdpl() 
		{
			try
			{
				return orderdetailhdplService.GetMutilDTOrderdetailhdpl();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-9-24 21:00:09
		///</sumary>
		public static IList<Orderdetailhdpl> GetMutilILOrderdetailhdpl() 
		{
			try
			{
				return orderdetailhdplService.GetMutilILOrderdetailhdpl();
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
