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
	public class OrderdetailhdphflManager
	{
		private static OrderdetailhdphflService orderdetailhdphflService=new OrderdetailhdphflService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-9-24 20:59:36
		///</sumary>
		public static Orderdetailhdphfl GetOrderdetailhdphflByPK(object pk) 
		{
			try
			{
				return orderdetailhdphflService.GetOrderdetailhdphflByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-9-24 20:59:36
		///</sumary>
		public static Boolean AddOrderdetailhdphfl(Orderdetailhdphfl orderdetailhdphfl) 
		{
			try
			{
				return orderdetailhdphflService.AddOrderdetailhdphfl(orderdetailhdphfl);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-9-24 20:59:36
		///</sumary>
		public static Boolean UpdateOrderdetailhdphfl(Orderdetailhdphfl orderdetailhdphfl) 
		{
			try
			{
				return orderdetailhdphflService.UpdateOrderdetailhdphfl(orderdetailhdphfl);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-9-24 20:59:36
		///</sumary>
		public static Boolean DeleteOrderdetailhdphflByPK(object pk) 
		{
			try
			{
				return orderdetailhdphflService.DeleteOrderdetailhdphflByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-9-24 20:59:36
		///</sumary>
		public static DataTable GetMutilDTOrderdetailhdphfl() 
		{
			try
			{
				return orderdetailhdphflService.GetMutilDTOrderdetailhdphfl();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-9-24 20:59:36
		///</sumary>
		public static IList<Orderdetailhdphfl> GetMutilILOrderdetailhdphfl() 
		{
			try
			{
				return orderdetailhdphflService.GetMutilILOrderdetailhdphfl();
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
