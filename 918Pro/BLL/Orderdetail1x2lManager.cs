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
	public class Orderdetail1x2lManager
	{
		private static Orderdetail1x2lService orderdetail1x2lService=new Orderdetail1x2lService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-9-24 20:57:33
		///</sumary>
		public static Orderdetail1x2l GetOrderdetail1x2lByPK(object pk) 
		{
			try
			{
				return orderdetail1x2lService.GetOrderdetail1x2lByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-9-24 20:57:33
		///</sumary>
		public static Boolean AddOrderdetail1x2l(Orderdetail1x2l orderdetail1x2l) 
		{
			try
			{
				return orderdetail1x2lService.AddOrderdetail1x2l(orderdetail1x2l);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-9-24 20:57:33
		///</sumary>
		public static Boolean UpdateOrderdetail1x2l(Orderdetail1x2l orderdetail1x2l) 
		{
			try
			{
				return orderdetail1x2lService.UpdateOrderdetail1x2l(orderdetail1x2l);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-9-24 20:57:33
		///</sumary>
		public static Boolean DeleteOrderdetail1x2lByPK(object pk) 
		{
			try
			{
				return orderdetail1x2lService.DeleteOrderdetail1x2lByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-9-24 20:57:33
		///</sumary>
		public static DataTable GetMutilDTOrderdetail1x2l() 
		{
			try
			{
				return orderdetail1x2lService.GetMutilDTOrderdetail1x2l();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-9-24 20:57:33
		///</sumary>
		public static IList<Orderdetail1x2l> GetMutilILOrderdetail1x2l() 
		{
			try
			{
				return orderdetail1x2lService.GetMutilILOrderdetail1x2l();
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
