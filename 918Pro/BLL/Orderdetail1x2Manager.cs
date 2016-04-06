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
	public class Orderdetail1x2Manager
	{
		private static Orderdetail1x2Service orderdetail1x2Service=new Orderdetail1x2Service(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-9-24 20:55:49
		///</sumary>
		public static Orderdetail1x2 GetOrderdetail1x2ByPK(object pk) 
		{
			try
			{
				return orderdetail1x2Service.GetOrderdetail1x2ByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-9-24 20:55:49
		///</sumary>
		public static Boolean AddOrderdetail1x2(Orderdetail1x2 orderdetail1x2) 
		{
			try
			{
				return orderdetail1x2Service.AddOrderdetail1x2(orderdetail1x2);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-9-24 20:55:49
		///</sumary>
		public static Boolean UpdateOrderdetail1x2(Orderdetail1x2 orderdetail1x2) 
		{
			try
			{
				return orderdetail1x2Service.UpdateOrderdetail1x2(orderdetail1x2);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-9-24 20:55:49
		///</sumary>
		public static Boolean DeleteOrderdetail1x2ByPK(object pk) 
		{
			try
			{
				return orderdetail1x2Service.DeleteOrderdetail1x2ByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-9-24 20:55:49
		///</sumary>
		public static DataTable GetMutilDTOrderdetail1x2() 
		{
			try
			{
				return orderdetail1x2Service.GetMutilDTOrderdetail1x2();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-9-24 20:55:49
		///</sumary>
		public static IList<Orderdetail1x2> GetMutilILOrderdetail1x2() 
		{
			try
			{
				return orderdetail1x2Service.GetMutilILOrderdetail1x2();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion

        #region 编写人:李毅
        public static List<Orderdetail1x2> getorderAll(int id)
        {
            return orderdetail1x2Service.getorderAll(id);
        }

        public static List<Orderdetail1x2> getEscAll(int id)
        {
            return orderdetail1x2Service.getEscAll(id);
        }
        #endregion

        public static List<Orderdetail1x2> getOrderAllByWhere(string whereSql)
        {
            return orderdetail1x2Service.getOrderAllByWhere(whereSql);
        }
	}
}
