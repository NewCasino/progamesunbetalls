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
    public class CasinoManager
    {
        private static CasinoService casinoService = new CasinoService();
        #region 生成代码
        ///<sumary>
        ///通过id获得实体对象
        ///时间：2010-9-12 14:24:06
        ///</sumary>
        public static Casino GetCasinoByPK(object pk)
        {
            try
            {
                return casinoService.GetCasinoByPK(pk);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return null;
            }
        }

        ///<sumary>
        ///添加信息
        ///时间：2010-9-12 14:24:06
        ///</sumary>
        public static Boolean AddCasino(Casino casino)
        {
            try
            {
                return casinoService.AddCasino(casino);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///修改信息
        ///时间：2010-9-12 14:24:06
        ///</sumary>
        public static Boolean UpdateCasino(Casino casino)
        {
            try
            {
                return casinoService.UpdateCasino(casino);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///删除信息
        ///时间：2010-9-12 14:24:06
        ///</sumary>
        public static Boolean DeleteCasinoByPK(object pk)
        {
            try
            {
                return casinoService.DeleteCasinoByPK(pk);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///获得所有信息，得到一张临时表
        ///时间：2010-9-12 14:24:06
        ///</sumary>
        public static DataTable GetMutilDTCasino()
        {
            try
            {
                return casinoService.GetMutilDTCasino();
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return null;
            }
        }

        ///<sumary>
        ///获得所有信息，返回泛型集合
        ///时间：2010-9-12 14:24:06
        ///</sumary>
        public static IList<Casino> GetMutilILCasino()
        {
            try
            {
                return casinoService.GetMutilILCasino();
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return null;
            }
        }
        #endregion
        #region 编写人:李毅
        public static string getDataAll(int IDex, int IDexC)
        {
            return casinoService.getDataAll(IDex, IDexC);
        }

        public static string getDataAll()
        {
            return casinoService.getDataAll();
        }

        public static string selectInfo(string cn, string tw, string en, string th, string tv)
        {
            return casinoService.selectInfo(cn, tw, en, th, tv);
        }

        public static string getCount()
        {
            return casinoService.getCount();
        }
        #endregion
        
        public static string getCasinoDataAll()
        {
            return casinoService.getCasinoDataAll();
        }

    }
}
