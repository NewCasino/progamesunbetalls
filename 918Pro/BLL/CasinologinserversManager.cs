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
	public class CasinologinserversManager
	{
		private static CasinologinserversService casinologinserversService=new CasinologinserversService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2011-1-23 1:00:32
		///</sumary>
		public static Casinologinservers GetCasinologinserversByPK(object pk) 
		{
			try
			{
				return casinologinserversService.GetCasinologinserversByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2011-1-23 1:00:32
		///</sumary>
		public static Boolean AddCasinologinservers(Casinologinservers casinologinservers) 
		{
			try
			{
				return casinologinserversService.AddCasinologinservers(casinologinservers);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2011-1-23 1:00:32
		///</sumary>
		public static Boolean UpdateCasinologinservers(Casinologinservers casinologinservers) 
		{
			try
			{
				return casinologinserversService.UpdateCasinologinservers(casinologinservers);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2011-1-23 1:00:32
		///</sumary>
		public static Boolean DeleteCasinologinserversByPK(object pk) 
		{
			try
			{
				return casinologinserversService.DeleteCasinologinserversByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2011-1-23 1:00:32
		///</sumary>
		public static DataTable GetMutilDTCasinologinservers() 
		{
			try
			{
				return casinologinserversService.GetMutilDTCasinologinservers();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2011-1-23 1:00:32
		///</sumary>
		public static IList<Casinologinservers> GetMutilILCasinologinservers() 
		{
			try
			{
				return casinologinserversService.GetMutilILCasinologinservers();
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
