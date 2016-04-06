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
    public class System_module_operateManager
    {
        private static System_module_operateService system_module_operateService = new System_module_operateService();

        public static int InsertSystem_module_operate(System_module_operate operate)
        {
            return system_module_operateService.InsertSystem_module_operate(operate);
        }

        #region 生成代码
        ///<sumary>
        ///通过id获得实体对象
        ///时间：2010-8-27 22:01:15
        ///</sumary>
        public static System_module_operate GetSystem_module_operateByPK(object pk)
        {
            try
            {
                return system_module_operateService.GetSystem_module_operateByPK(pk);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return null;
            }
        }

        ///<sumary>
        ///添加信息
        ///时间：2010-8-27 22:01:15
        ///</sumary>
        public static Boolean AddSystem_module_operate(System_module_operate system_module_operate)
        {
            try
            {
                return system_module_operateService.AddSystem_module_operate(system_module_operate);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///修改信息
        ///时间：2010-8-27 22:01:15
        ///</sumary>
        public static Boolean UpdateSystem_module_operate(System_module_operate system_module_operate)
        {
            try
            {
                return system_module_operateService.UpdateSystem_module_operate(system_module_operate);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///删除信息
        ///时间：2010-8-27 22:01:15
        ///</sumary>
        public static Boolean DeleteSystem_module_operateByPK(object pk)
        {
            try
            {
                return system_module_operateService.DeleteSystem_module_operateByPK(pk);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///获得所有信息，得到一张临时表
        ///时间：2010-8-27 22:01:15
        ///</sumary>
        public static DataTable GetMutilDTSystem_module_operate()
        {
            try
            {
                return system_module_operateService.GetMutilDTSystem_module_operate();
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return null;
            }
        }

        ///<sumary>
        ///获得所有信息，返回泛型集合
        ///时间：2010-8-27 22:01:15
        ///</sumary>
        public static IList<System_module_operate> GetMutilILSystem_module_operate()
        {
            try
            {
                return system_module_operateService.GetMutilILSystem_module_operate();
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
