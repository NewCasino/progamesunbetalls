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
	public class RefusedListManager
	{
		private static RefusedListService refusedListService=new RefusedListService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2011-4-14 21:35:22
		///</sumary>
		public static RefusedList GetRefusedListByPK(object pk) 
		{
			try
			{
				return refusedListService.GetRefusedListByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2011-4-14 21:35:22
		///</sumary>
		public static Boolean AddRefusedList(RefusedList refusedList) 
		{
			try
			{
				return refusedListService.AddRefusedList(refusedList);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2011-4-14 21:35:22
		///</sumary>
		public static Boolean UpdateRefusedList(RefusedList refusedList) 
		{
			try
			{
				return refusedListService.UpdateRefusedList(refusedList);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2011-4-14 21:35:22
		///</sumary>
		public static Boolean DeleteRefusedListByPK(object pk) 
		{
			try
			{
				return refusedListService.DeleteRefusedListByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2011-4-14 21:35:22
		///</sumary>
		public static DataTable GetMutilDTRefusedList() 
		{
			try
			{
				return refusedListService.GetMutilDTRefusedList();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2011-4-14 21:35:22
		///</sumary>
		public static IList<RefusedList> GetMutilILRefusedList() 
		{
			try
			{
				return refusedListService.GetMutilILRefusedList();
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
