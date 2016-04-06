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
	public class Sys_module_rightManager
	{
		private static Sys_module_rightService sys_module_rightService=new Sys_module_rightService();

        public DataTable GetModuleRightByModuleCode(string moduleCode)
        {
            return sys_module_rightService.GetModuleRightByModuleCode(moduleCode);
        }

        public static DataTable GetModuleRightOperateByCode(string moduleCode)
        {
            return sys_module_rightService.GetModuleRightOperateByCode(moduleCode);
        }

		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-8-27 22:01:16
		///</sumary>
		public static Sys_module_right GetSys_module_rightByPK(object pk) 
		{
			try
			{
				return sys_module_rightService.GetSys_module_rightByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-8-27 22:01:16
		///</sumary>
		public static Boolean AddSys_module_right(Sys_module_right sys_module_right) 
		{
			try
			{
				return sys_module_rightService.AddSys_module_right(sys_module_right);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-8-27 22:01:16
		///</sumary>
		public static Boolean UpdateSys_module_right(Sys_module_right sys_module_right) 
		{
			try
			{
				return sys_module_rightService.UpdateSys_module_right(sys_module_right);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-8-27 22:01:16
		///</sumary>
		public static Boolean DeleteSys_module_rightByPK(object pk) 
		{
			try
			{
				return sys_module_rightService.DeleteSys_module_rightByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-8-27 22:01:16
		///</sumary>
		public static DataTable GetMutilDTSys_module_right() 
		{
			try
			{
				return sys_module_rightService.GetMutilDTSys_module_right();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-8-27 22:01:16
		///</sumary>
		public static IList<Sys_module_right> GetMutilILSys_module_right() 
		{
			try
			{
				return sys_module_rightService.GetMutilILSys_module_right();
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
