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
    public class BetaccountlogManager
    {
        private static BetaccountlogService betaccountlogService = new BetaccountlogService();
        #region 生成代码
        ///<sumary>
        ///通过id获得实体对象
        ///时间：2010-9-12 14:34:24
        ///</sumary>
        public static Betaccountlog GetBetaccountlogByPK(object pk)
        {
            try
            {
                return betaccountlogService.GetBetaccountlogByPK(pk);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return null;
            }
        }

        ///<sumary>
        ///添加信息
        ///时间：2010-9-12 14:34:24
        ///</sumary>
        public static Boolean AddBetaccountlog(Betaccountlog betaccountlog)
        {
            try
            {
                return betaccountlogService.AddBetaccountlog(betaccountlog);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///修改信息
        ///时间：2010-9-12 14:34:24
        ///</sumary>
        public static Boolean UpdateBetaccountlog(Betaccountlog betaccountlog)
        {
            try
            {
                return betaccountlogService.UpdateBetaccountlog(betaccountlog);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///删除信息
        ///时间：2010-9-12 14:34:24
        ///</sumary>
        public static Boolean DeleteBetaccountlogByPK(object pk)
        {
            try
            {
                return betaccountlogService.DeleteBetaccountlogByPK(pk);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///获得所有信息，得到一张临时表
        ///时间：2010-9-12 14:34:24
        ///</sumary>
        public static DataTable GetMutilDTBetaccountlog()
        {
            try
            {
                return betaccountlogService.GetMutilDTBetaccountlog();
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return null;
            }
        }

        ///<sumary>
        ///获得所有信息，返回泛型集合
        ///时间：2010-9-12 14:34:24
        ///</sumary>
        public static IList<Betaccountlog> GetMutilILBetaccountlog()
        {
            try
            {
                return betaccountlogService.GetMutilILBetaccountlog();
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
            return betaccountlogService.getDataAll(IDex,IDexC);
        }

        public static string getCount()
        {
            return betaccountlogService.getCount();
        }
        #endregion
    }
}