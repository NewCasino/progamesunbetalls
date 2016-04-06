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
	public class Orderdetail1x2hfManager
	{
		private static Orderdetail1x2hfService orderdetail1x2hfService=new Orderdetail1x2hfService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-9-24 20:56:24
		///</sumary>
		public static Orderdetail1x2hf GetOrderdetail1x2hfByPK(object pk) 
		{
			try
			{
				return orderdetail1x2hfService.GetOrderdetail1x2hfByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-9-24 20:56:24
		///</sumary>
		public static Boolean AddOrderdetail1x2hf(Orderdetail1x2hf orderdetail1x2hf) 
		{
			try
			{
				return orderdetail1x2hfService.AddOrderdetail1x2hf(orderdetail1x2hf);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-9-24 20:56:24
		///</sumary>
		public static Boolean UpdateOrderdetail1x2hf(Orderdetail1x2hf orderdetail1x2hf) 
		{
			try
			{
				return orderdetail1x2hfService.UpdateOrderdetail1x2hf(orderdetail1x2hf);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-9-24 20:56:24
		///</sumary>
		public static Boolean DeleteOrderdetail1x2hfByPK(object pk) 
		{
			try
			{
				return orderdetail1x2hfService.DeleteOrderdetail1x2hfByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-9-24 20:56:24
		///</sumary>
		public static DataTable GetMutilDTOrderdetail1x2hf() 
		{
			try
			{
				return orderdetail1x2hfService.GetMutilDTOrderdetail1x2hf();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-9-24 20:56:24
		///</sumary>
		public static IList<Orderdetail1x2hf> GetMutilILOrderdetail1x2hf() 
		{
			try
			{
				return orderdetail1x2hfService.GetMutilILOrderdetail1x2hf();
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
