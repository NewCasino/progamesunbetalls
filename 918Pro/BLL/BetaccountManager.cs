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
    public class BetaccountManager
    {
        private static BetaccountService betaccountService = new BetaccountService();
        #region 生成代码
        ///<sumary>
        ///通过id获得实体对象
        ///时间：2010-9-12 14:30:59
        ///</sumary>
        public static Betaccount GetBetaccountByPK(object pk)
        {
            try
            {
                return betaccountService.GetBetaccountByPK(pk);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return null;
            }
        }

        ///<sumary>
        ///添加信息
        ///时间：2010-9-12 14:30:59
        ///</sumary>
        public static Boolean AddBetaccount(Betaccount betaccount)
        {
            try
            {
                return betaccountService.AddBetaccount(betaccount);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///修改信息
        ///时间：2010-9-12 14:30:59
        ///</sumary>
        public static Boolean UpdateBetaccount(Betaccount betaccount)
        {
            try
            {
                return betaccountService.UpdateBetaccount(betaccount);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///删除信息
        ///时间：2010-9-12 14:30:59
        ///</sumary>
        public static Boolean DeleteBetaccountByPK(object pk)
        {
            try
            {
                return betaccountService.DeleteBetaccountByPK(pk);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///获得所有信息，得到一张临时表
        ///时间：2010-9-12 14:30:59
        ///</sumary>
        public static DataTable GetMutilDTBetaccount()
        {
            try
            {
                return betaccountService.GetMutilDTBetaccount();
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return null;
            }
        }

        ///<sumary>
        ///获得所有信息，返回泛型集合
        ///时间：2010-9-12 14:30:59
        ///</sumary>
        public static IList<Betaccount> GetMutilILBetaccount()
        {
            try
            {
                return betaccountService.GetMutilILBetaccount();
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return null;
            }
        }
        #endregion

        #region 编写人:李毅
        public static string getDataAll(int IDex, int IDexC, string casino, string dali, string id, string enable, string webPoss, string Company)
        {
            return betaccountService.getDataAll(IDex, IDexC, casino, dali, id, enable, webPoss, Company);
        }

        public static string getAllCount(string casino, string dali, string id, string enable, string webPoss, string Company)
        {
            return betaccountService.getAllCount(casino, dali, id, enable, webPoss, Company);
        }

        /// <summary>
        /// 根据ID获得单个实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IList<Betaccount> GetBetaccountByID(int id)
        {
            return betaccountService.GetBetaccountByID(id);
        }

        public static string getCount(string username)
        {
            return betaccountService.getCount(username);
        }
        #endregion
    }
}