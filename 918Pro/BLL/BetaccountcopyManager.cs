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
    public class BetaccountcopyManager
    {
        private static BetaccountcopyService betaccountcopyService = new BetaccountcopyService();
        #region 生成代码
        ///<sumary>
        ///通过id获得实体对象
        ///时间：2010-9-12 14:32:47
        ///</sumary>
        public static Betaccountcopy GetBetaccountcopyByPK(object pk)
        {
            try
            {
                return betaccountcopyService.GetBetaccountcopyByPK(pk);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return null;
            }
        }

        ///<sumary>
        ///添加信息
        ///时间：2010-9-12 14:32:47
        ///</sumary>
        public static Boolean AddBetaccountcopy(Betaccountcopy betaccountcopy)
        {
            try
            {
                return betaccountcopyService.AddBetaccountcopy(betaccountcopy);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///修改信息
        ///时间：2010-9-12 14:32:47
        ///</sumary>
        public static Boolean UpdateBetaccountcopy(Betaccountcopy betaccountcopy)
        {
            try
            {
                return betaccountcopyService.UpdateBetaccountcopy(betaccountcopy);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///删除信息
        ///时间：2010-9-12 14:32:47
        ///</sumary>
        public static Boolean DeleteBetaccountcopyByPK(object pk)
        {
            try
            {
                return betaccountcopyService.DeleteBetaccountcopyByPK(pk);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///获得所有信息，得到一张临时表
        ///时间：2010-9-12 14:32:47
        ///</sumary>
        public static DataTable GetMutilDTBetaccountcopy()
        {
            try
            {
                return betaccountcopyService.GetMutilDTBetaccountcopy();
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return null;
            }
        }

        ///<sumary>
        ///获得所有信息，返回泛型集合
        ///时间：2010-9-12 14:32:47
        ///</sumary>
        public static IList<Betaccountcopy> GetMutilILBetaccountcopy()
        {
            try
            {
                return betaccountcopyService.GetMutilILBetaccountcopy();
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
            return betaccountcopyService.getDataAll(IDex, IDexC, casino, dali, id, enable, webPoss, Company);
        }

        public static string getCount(string casino, string dali, string id, string enable, string webPoss, string Company)
        {
            return betaccountcopyService.getCount(casino, dali, id, enable, webPoss, Company);
        }
        #endregion
    }
}
