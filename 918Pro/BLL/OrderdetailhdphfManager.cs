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
	public class OrderdetailhdphfManager
	{
		private static OrderdetailhdphfService orderdetailhdphfService=new OrderdetailhdphfService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-9-24 20:58:47
		///</sumary>
		public static Orderdetailhdphf GetOrderdetailhdphfByPK(object pk) 
		{
			try
			{
				return orderdetailhdphfService.GetOrderdetailhdphfByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-9-24 20:58:47
		///</sumary>
		public static Boolean AddOrderdetailhdphf(Orderdetailhdphf orderdetailhdphf) 
		{
			try
			{
				return orderdetailhdphfService.AddOrderdetailhdphf(orderdetailhdphf);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-9-24 20:58:47
		///</sumary>
		public static Boolean UpdateOrderdetailhdphf(Orderdetailhdphf orderdetailhdphf) 
		{
			try
			{
				return orderdetailhdphfService.UpdateOrderdetailhdphf(orderdetailhdphf);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-9-24 20:58:47
		///</sumary>
		public static Boolean DeleteOrderdetailhdphfByPK(object pk) 
		{
			try
			{
				return orderdetailhdphfService.DeleteOrderdetailhdphfByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-9-24 20:58:47
		///</sumary>
		public static DataTable GetMutilDTOrderdetailhdphf() 
		{
			try
			{
				return orderdetailhdphfService.GetMutilDTOrderdetailhdphf();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-9-24 20:58:47
		///</sumary>
		public static IList<Orderdetailhdphf> GetMutilILOrderdetailhdphf() 
		{
			try
			{
				return orderdetailhdphfService.GetMutilILOrderdetailhdphf();
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
