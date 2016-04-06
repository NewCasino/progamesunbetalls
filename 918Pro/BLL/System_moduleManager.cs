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
    public class System_moduleManager
    {
        private static System_moduleService system_moduleService = new System_moduleService();
        #region 生成代码
        ///<sumary>
        ///通过id获得实体对象
        ///时间：2010-9-14 23:53:09
        ///</sumary>
        public static System_module GetSystem_moduleByPK(object pk)
        {
            try
            {
                return system_moduleService.GetSystem_moduleByPK(pk);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return null;
            }
        }

        ///<sumary>
        ///添加信息
        ///时间：2010-9-14 23:53:09
        ///</sumary>
        public static Boolean AddSystem_module(System_module system_module)
        {
            try
            {
                return system_moduleService.AddSystem_module(system_module);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///修改信息
        ///时间：2010-9-14 23:53:09
        ///</sumary>
        public static Boolean UpdateSystem_module(System_module system_module)
        {
            try
            {
                return system_moduleService.UpdateSystem_module(system_module);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///删除信息
        ///时间：2010-9-14 23:53:09
        ///</sumary>
        public static Boolean DeleteSystem_moduleByPK(object pk)
        {
            try
            {
                return system_moduleService.DeleteSystem_moduleByPK(pk);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///获得所有信息，得到一张临时表
        ///时间：2010-9-14 23:53:09
        ///</sumary>
        public static DataTable GetMutilDTSystem_module()
        {
            try
            {
                return system_moduleService.GetMutilDTSystem_module();
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return null;
            }
        }

        ///<sumary>
        ///获得所有信息，返回泛型集合
        ///时间：2010-9-14 23:53:09
        ///</sumary>
        public static IList<System_module> GetMutilILSystem_module()
        {
            try
            {
                return system_moduleService.GetMutilILSystem_module();
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
