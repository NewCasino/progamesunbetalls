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
	public class Matches_copyManager
	{
		private static Matches_copyService matches_copyService=new Matches_copyService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-12-30 15:24:07
		///</sumary>
		public static Matches_copy GetMatches_copyByPK(object pk) 
		{
			try
			{
				return matches_copyService.GetMatches_copyByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-12-30 15:24:07
		///</sumary>
		public static Boolean AddMatches_copy(Matches_copy matches_copy) 
		{
			try
			{
				return matches_copyService.AddMatches_copy(matches_copy);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-12-30 15:24:07
		///</sumary>
		public static Boolean UpdateMatches_copy(Matches_copy matches_copy) 
		{
			try
			{
				return matches_copyService.UpdateMatches_copy(matches_copy);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-12-30 15:24:07
		///</sumary>
		public static Boolean DeleteMatches_copyByPK(object pk) 
		{
			try
			{
				return matches_copyService.DeleteMatches_copyByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-12-30 15:24:07
		///</sumary>
		public static DataTable GetMutilDTMatches_copy() 
		{
			try
			{
				return matches_copyService.GetMutilDTMatches_copy();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-12-30 15:24:07
		///</sumary>
		public static IList<Matches_copy> GetMutilILMatches_copy() 
		{
			try
			{
				return matches_copyService.GetMutilILMatches_copy();
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
