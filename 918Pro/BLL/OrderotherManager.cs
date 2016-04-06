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
	public class OrderotherManager
	{
		private static OrderotherService orderotherService=new OrderotherService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-9-24 21:04:21
		///</sumary>
		public static Orderother GetOrderotherByPK(object pk) 
		{
			try
			{
				return orderotherService.GetOrderotherByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

        public static List<Orderother> getorderotherAll(int id)
        {
            try
            {
                return orderotherService.getorderotherAll(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

		///<sumary>
		///添加信息
		///时间：2010-9-24 21:04:21
		///</sumary>
		public static Boolean AddOrderother(Orderother orderother) 
		{
			try
			{
				return orderotherService.AddOrderother(orderother);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-9-24 21:04:21
		///</sumary>
		public static Boolean UpdateOrderother(Orderother orderother) 
		{
			try
			{
				return orderotherService.UpdateOrderother(orderother);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-9-24 21:04:21
		///</sumary>
		public static Boolean DeleteOrderotherByPK(object pk) 
		{
			try
			{
				return orderotherService.DeleteOrderotherByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-9-24 21:04:21
		///</sumary>
		public static DataTable GetMutilDTOrderother() 
		{
			try
			{
				return orderotherService.GetMutilDTOrderother();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-9-24 21:04:21
		///</sumary>
		public static IList<Orderother> GetMutilILOrderother() 
		{
			try
			{
				return orderotherService.GetMutilILOrderother();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion

        #region 编写人:李毅
        public static string GetAllTolength(string length, string league, string type, string money, string ballteam, string language,string username,string roid)
        {
            return orderotherService.GetAllTolength(length, league, type, money, ballteam, language, username, roid);
        }
        /*-----------会员注单------------------*/
        public static string getCount(int id, int roid)
        {
            return orderotherService.getCount(id, roid);
        }

        public static string getUserCount(string un)
        {
            return orderotherService.getUserCount(un);
        }
        /*-----------会员注单结束-----------------*/
        #endregion

        public static string GetAllTolength1(string league, string type, string money, string ballteam, string language, string time1,string time2, string account)
        {
            return orderotherService.GetAllTolength1(league, type, money, ballteam, language, time1,time2, account);
        }

        /// <summary>
        /// 根据gameid返回OrderOther
        /// </summary>
        /// <param name="gameid"></param>
        /// <returns></returns>
        public IList<Orderother> GetOrderByGameId(int gameid)
        {
            return orderotherService.GetOrderByGameId(gameid);
        }

        public static bool updateOrderotherStatus(int status, string id)
        {
            return orderotherService.updateOrderotherStatus(status, id);
        }
	}
}
