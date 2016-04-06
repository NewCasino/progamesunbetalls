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
	public class Sys_role_rightManager
	{
		private static Sys_role_rightService sys_role_rightService=new Sys_role_rightService();

        public DataTable GetDataByRoleId(int roleId)
        {
            return sys_role_rightService.GetDataByRoleId(roleId);
        }

        /// <summary>
        /// 判断角色是否有权限
        /// </summary>
        /// <param name="RoleId">角色ID</param>
        /// <param name="Module_right_id">模块权限ID</param>
        /// <returns>true：有权限 false：无权限</returns>
        public bool IsPermission(int RoleId, int Module_right_id)
        {
            return sys_role_rightService.IsPermission(RoleId, Module_right_id);
        }

		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-8-27 22:01:16
		///</sumary>
		public static Sys_role_right GetSys_role_rightByPK(object pk) 
		{
			try
			{
				return sys_role_rightService.GetSys_role_rightByPK(pk);
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
		public static Boolean AddSys_role_right(Sys_role_right sys_role_right) 
		{
			try
			{
				return sys_role_rightService.AddSys_role_right(sys_role_right);
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
		public static Boolean UpdateSys_role_right(Sys_role_right sys_role_right) 
		{
			try
			{
				return sys_role_rightService.UpdateSys_role_right(sys_role_right);
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
		public static Boolean DeleteSys_role_rightByPK(object pk) 
		{
			try
			{
				return sys_role_rightService.DeleteSys_role_rightByPK(pk);
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
		public static DataTable GetMutilDTSys_role_right() 
		{
			try
			{
				return sys_role_rightService.GetMutilDTSys_role_right();
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
		public static IList<Sys_role_right> GetMutilILSys_role_right() 
		{
			try
			{
				return sys_role_rightService.GetMutilILSys_role_right();
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
