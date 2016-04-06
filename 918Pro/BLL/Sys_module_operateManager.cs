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
	public class Sys_module_operateManager
	{
		private static Sys_module_operateService sys_module_operateService=new Sys_module_operateService();

        public static int InsertSys_module_operate(Sys_module_operate operate)
        {
            return sys_module_operateService.InsertSys_module_operate(operate);
        }

		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-8-27 22:01:15
		///</sumary>
		public static Sys_module_operate GetSys_module_operateByPK(object pk) 
		{
			try
			{
				return sys_module_operateService.GetSys_module_operateByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-8-27 22:01:15
		///</sumary>
		public static Boolean AddSys_module_operate(Sys_module_operate sys_module_operate) 
		{
			try
			{
				return sys_module_operateService.AddSys_module_operate(sys_module_operate);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-8-27 22:01:15
		///</sumary>
		public static Boolean UpdateSys_module_operate(Sys_module_operate sys_module_operate) 
		{
			try
			{
				return sys_module_operateService.UpdateSys_module_operate(sys_module_operate);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-8-27 22:01:15
		///</sumary>
		public static Boolean DeleteSys_module_operateByPK(object pk) 
		{
			try
			{
				return sys_module_operateService.DeleteSys_module_operateByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-8-27 22:01:15
		///</sumary>
		public static DataTable GetMutilDTSys_module_operate() 
		{
			try
			{
				return sys_module_operateService.GetMutilDTSys_module_operate();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-8-27 22:01:15
		///</sumary>
		public static IList<Sys_module_operate> GetMutilILSys_module_operate() 
		{
			try
			{
				return sys_module_operateService.GetMutilILSys_module_operate();
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
