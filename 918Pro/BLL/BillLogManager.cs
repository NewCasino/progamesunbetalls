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
	public class BillLogManager
	{
		private static BillLogService billLogService=new BillLogService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2011-4-14 16:26:01
		///</sumary>
		public static BillLog GetBillLogByPK(object pk) 
		{
			try
			{
				return billLogService.GetBillLogByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2011-4-14 16:26:01
		///</sumary>
		public static Boolean AddBillLog(BillLog billLog) 
		{
			try
			{
				return billLogService.AddBillLog(billLog);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2011-4-14 16:26:01
		///</sumary>
		public static Boolean UpdateBillLog(BillLog billLog) 
		{
			try
			{
				return billLogService.UpdateBillLog(billLog);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2011-4-14 16:26:01
		///</sumary>
		public static Boolean DeleteBillLogByPK(object pk) 
		{
			try
			{
				return billLogService.DeleteBillLogByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2011-4-14 16:26:01
		///</sumary>
		public static DataTable GetMutilDTBillLog() 
		{
			try
			{
				return billLogService.GetMutilDTBillLog();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2011-4-14 16:26:01
		///</sumary>
		public static IList<BillLog> GetMutilILBillLog() 
		{
			try
			{
				return billLogService.GetMutilILBillLog();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion

        public static string GetLogbyWhere(string typ, string operators, string operationtimes, string operationtimee, string lan)
        {
            return billLogService.GetLogbyWhere(typ, operators, operationtimes, operationtimee, lan);
        }
	}
}
