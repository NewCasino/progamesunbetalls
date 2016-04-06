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
	public class JsnManager
	{
		private static JsnService jsnService=new JsnService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2011-6-1 20:36:15
		///</sumary>
		public static Jsn GetJsnByPK(object pk) 
		{
			try
			{
				return jsnService.GetJsnByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2011-6-1 20:36:15
		///</sumary>
		public static Boolean AddJsn(Jsn jsn) 
		{
			try
			{
				return jsnService.AddJsn(jsn);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2011-6-1 20:36:15
		///</sumary>
		public static Boolean UpdateJsn(Jsn jsn) 
		{
			try
			{
				return jsnService.UpdateJsn(jsn);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2011-6-1 20:36:15
		///</sumary>
		public static Boolean DeleteJsnByPK(object pk) 
		{
			try
			{
				return jsnService.DeleteJsnByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2011-6-1 20:36:15
		///</sumary>
		public static DataTable GetMutilDTJsn() 
		{
			try
			{
				return jsnService.GetMutilDTJsn();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2011-6-1 20:36:15
		///</sumary>
		public static IList<Jsn> GetMutilILJsn() 
		{
			try
			{
				return jsnService.GetMutilILJsn();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion

        public string GetJsnByWhere(string userName, string sn, string date1, string date2)
        {
            return jsnService.GetJsnByWhere(userName, sn, date1, date2);
        }
	}
}
