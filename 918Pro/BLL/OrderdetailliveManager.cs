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
	public class OrderdetailliveManager
	{
		private static OrderdetailliveService orderdetailliveService=new OrderdetailliveService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-9-24 21:00:48
		///</sumary>
		public static Orderdetaillive GetOrderdetailliveByPK(object pk) 
		{
			try
			{
				return orderdetailliveService.GetOrderdetailliveByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-9-24 21:00:48
		///</sumary>
		public static Boolean AddOrderdetaillive(Orderdetaillive orderdetaillive) 
		{
			try
			{
				return orderdetailliveService.AddOrderdetaillive(orderdetaillive);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-9-24 21:00:48
		///</sumary>
		public static Boolean UpdateOrderdetaillive(Orderdetaillive orderdetaillive) 
		{
			try
			{
				return orderdetailliveService.UpdateOrderdetaillive(orderdetaillive);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-9-24 21:00:48
		///</sumary>
		public static Boolean DeleteOrderdetailliveByPK(object pk) 
		{
			try
			{
				return orderdetailliveService.DeleteOrderdetailliveByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-9-24 21:00:48
		///</sumary>
		public static DataTable GetMutilDTOrderdetaillive() 
		{
			try
			{
				return orderdetailliveService.GetMutilDTOrderdetaillive();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-9-24 21:00:48
		///</sumary>
		public static IList<Orderdetaillive> GetMutilILOrderdetaillive() 
		{
			try
			{
				return orderdetailliveService.GetMutilILOrderdetaillive();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion

        #region 编写人:李毅
        /// <summary>
        /// 根据需要的数据量查询
        /// </summary>
        /// <param name="length">多少条</param>
        /// <returns></returns>
        public static string getAllToLength(string length)
        {
            return orderdetailliveService.getAllToLength(length);
        }
        #endregion

        public static List<Orderdetaillive> getorderAll(int id)
        {
            try
            {
                return orderdetailliveService.getorderAll(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string GetOrderAllByWhere(string isHalf, string webSiteiID, string userName, string orderID, string IP,
    string time1, string time2)
        {
            return orderdetailliveService.GetOrderAllByWhere(isHalf, webSiteiID, userName, orderID, IP, time1, time2);
        }

        public static List<Orderdetaillive> GetOrderAllByWhere(string whereSql)
        {
            return orderdetailliveService.GetOrderAllByWhere(whereSql);
        }

	}
}
