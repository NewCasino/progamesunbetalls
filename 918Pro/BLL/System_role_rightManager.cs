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
    public class System_role_rightManager
    {
        private static System_role_rightService system_role_rightService = new System_role_rightService();

        public DataTable GetDataByRoleId(int roleId)
        {
            return system_role_rightService.GetDataByRoleId(roleId);
        }

        /// <summary>
        /// 判断角色是否有权限
        /// </summary>
        /// <param name="RoleId">角色ID</param>
        /// <param name="Module_right_id">模块权限ID</param>
        /// <returns>true：有权限 false：无权限</returns>
        public bool IsPermission(int RoleId, int Module_right_id)
        {
            return system_role_rightService.IsPermission(RoleId, Module_right_id);
        }

        #region 生成代码
        ///<sumary>
        ///通过id获得实体对象
        ///时间：2010-8-27 22:01:16
        ///</sumary>
        public static System_role_right GetSystem_role_rightByPK(object pk)
        {
            try
            {
                return system_role_rightService.GetSystem_role_rightByPK(pk);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return null;
            }
        }

        ///<sumary>
        ///添加信息
        ///时间：2010-8-27 22:01:16
        ///</sumary>
        public static Boolean AddSystem_role_right(System_role_right system_role_right)
        {
            try
            {
                return system_role_rightService.AddSystem_role_right(system_role_right);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///修改信息
        ///时间：2010-8-27 22:01:16
        ///</sumary>
        public static Boolean UpdateSystem_role_right(System_role_right system_role_right)
        {
            try
            {
                return system_role_rightService.UpdateSystem_role_right(system_role_right);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///删除信息
        ///时间：2010-8-27 22:01:16
        ///</sumary>
        public static Boolean DeleteSystem_role_rightByPK(object pk)
        {
            try
            {
                return system_role_rightService.DeleteSystem_role_rightByPK(pk);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///获得所有信息，得到一张临时表
        ///时间：2010-8-27 22:01:16
        ///</sumary>
        public static DataTable GetMutilDTSystem_role_right()
        {
            try
            {
                return system_role_rightService.GetMutilDTSystem_role_right();
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return null;
            }
        }

        ///<sumary>
        ///获得所有信息，返回泛型集合
        ///时间：2010-8-27 22:01:16
        ///</sumary>
        public static IList<System_role_right> GetMutilILSystem_role_right()
        {
            try
            {
                return system_role_rightService.GetMutilILSystem_role_right();
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return null;
            }
        }
        #endregion

    }
}
