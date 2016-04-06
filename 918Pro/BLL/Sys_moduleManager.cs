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
    public class Sys_moduleManager
    {
        private static Sys_moduleService sys_moduleService = new Sys_moduleService();
        #region 生成代码
        ///<sumary>
        ///通过id获得实体对象
        ///时间：2010-9-14 23:53:09
        ///</sumary>
        public static Sys_module GetSys_moduleByPK(object pk)
        {
            try
            {
                return sys_moduleService.GetSys_moduleByPK(pk);
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
        public static Boolean AddSys_module(Sys_module sys_module)
        {
            try
            {
                return sys_moduleService.AddSys_module(sys_module);
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
        public static Boolean UpdateSys_module(Sys_module sys_module)
        {
            try
            {
                return sys_moduleService.UpdateSys_module(sys_module);
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
        public static Boolean DeleteSys_moduleByPK(object pk)
        {
            try
            {
                return sys_moduleService.DeleteSys_moduleByPK(pk);
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
        public static DataTable GetMutilDTSys_module()
        {
            try
            {
                return sys_moduleService.GetMutilDTSys_module();
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
        public static IList<Sys_module> GetMutilILSys_module()
        {
            try
            {
                return sys_moduleService.GetMutilILSys_module();
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
