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
    public class System_module_rightManager
    {
        private static System_module_rightService system_module_rightService = new System_module_rightService();

        public DataTable GetModuleRightByModuleCode(string moduleCode)
        {
            return system_module_rightService.GetModuleRightByModuleCode(moduleCode);
        }

        public static DataTable GetModuleRightOperateByCode(string moduleCode)
        {
            return system_module_rightService.GetModuleRightOperateByCode(moduleCode);
        }

        #region 生成代码
        ///<sumary>
        ///通过id获得实体对象
        ///时间：2010-8-27 22:01:16
        ///</sumary>
        public static System_module_right GetSystem_module_rightByPK(object pk)
        {
            try
            {
                return system_module_rightService.GetSystem_module_rightByPK(pk);
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
        public static Boolean AddSystem_module_right(System_module_right system_module_right)
        {
            try
            {
                return system_module_rightService.AddSystem_module_right(system_module_right);
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
        public static Boolean UpdateSystem_module_right(System_module_right system_module_right)
        {
            try
            {
                return system_module_rightService.UpdateSystem_module_right(system_module_right);
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
        public static Boolean DeleteSystem_module_rightByPK(object pk)
        {
            try
            {
                return system_module_rightService.DeleteSystem_module_rightByPK(pk);
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
        public static DataTable GetMutilDTSystem_module_right()
        {
            try
            {
                return system_module_rightService.GetMutilDTSystem_module_right();
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
        public static IList<System_module_right> GetMutilILSystem_module_right()
        {
            try
            {
                return system_module_rightService.GetMutilILSystem_module_right();
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
