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
	public class UpdatematchesManager
	{
		private static UpdatematchesService updatematchesService=new UpdatematchesService(); 


		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2011-1-9 20:45:48
		///</sumary>
		public static Updatematches GetUpdatematchesByPK(object pk) 
		{
			try
			{
				return updatematchesService.GetUpdatematchesByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2011-1-9 20:45:48
		///</sumary>
		public static Boolean AddUpdatematches(Updatematches updatematches) 
		{
			try
			{
				return updatematchesService.AddUpdatematches(updatematches);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2011-1-9 20:45:48
		///</sumary>
		public static Boolean UpdateUpdatematches(Updatematches updatematches) 
		{
			try
			{
				return updatematchesService.UpdateUpdatematches(updatematches);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2011-1-9 20:45:48
		///</sumary>
		public static Boolean DeleteUpdatematchesByPK(object pk) 
		{
			try
			{
				return updatematchesService.DeleteUpdatematchesByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2011-1-9 20:45:48
		///</sumary>
		public static DataTable GetMutilDTUpdatematches() 
		{
			try
			{
				return updatematchesService.GetMutilDTUpdatematches();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2011-1-9 20:45:48
		///</sumary>
		public static IList<Updatematches> GetMutilILUpdatematches() 
		{
			try
			{
				return updatematchesService.GetMutilILUpdatematches();
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
