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
    public class AccountManager
    {
        private static AccountService accountService = new AccountService();
        #region 生成代码
        ///<sumary>
        ///通过id获得实体对象
        ///时间：2010-9-12 14:21:46
        ///</sumary>
        public static Account GetAccountByPK(object pk)
        {
            try
            {
                return accountService.GetAccountByPK(pk);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return null;
            }
        }

        ///<sumary>
        ///添加信息
        ///时间：2010-9-12 14:21:46
        ///</sumary>
        public static Boolean AddAccount(Account account)
        {
            try
            {
                return accountService.AddAccount(account);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///修改信息
        ///时间：2010-9-12 14:21:46
        ///</sumary>
        public static Boolean UpdateAccount(Account account)
        {
            try
            {
                return accountService.UpdateAccount(account);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///删除信息
        ///时间：2010-9-12 14:21:46
        ///</sumary>
        public static Boolean DeleteAccountByPK(object pk)
        {
            try
            {
                return accountService.DeleteAccountByPK(pk);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }

        ///<sumary>
        ///获得所有信息，得到一张临时表
        ///时间：2010-9-12 14:21:46
        ///</sumary>
        public static DataTable GetMutilDTAccount()
        {
            try
            {
                return accountService.GetMutilDTAccount();
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return null;
            }
        }

        ///<sumary>
        ///获得所有信息，返回泛型集合
        ///时间：2010-9-12 14:21:46
        ///</sumary>
        public static IList<Account> GetMutilILAccount()
        {
            try
            {
                return accountService.GetMutilILAccount();
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return null;
            }
        }
        #endregion

        #region 编写人:李毅
        public static string getDataAll(int IDex, int IDexC, string casino, string group, string time1, string time2, string enable)
        {
            return accountService.getDataAll(IDex, IDexC, casino, group, time1, time2, enable);
        }

        public static string getCount(string casino, string group, string time1, string time2, string enable)
        {
            return accountService.getCount(casino, group, time1, time2, enable);
        }

        public static string getDataToID(string id)
        {
            return accountService.getDataToID(id);
        }

        public static string getInfo(string username)
        {
            return accountService.getInfo(username);
        }
        #endregion


        public static string GetAccountData(string id)
        {
            return accountService.GetAccountData(id);
        }

        public static string GetCasinoAccountData(string casino, string userid,string parm)
        {
            DateTime[] date = new DateTime[2];
            date[0] = Convert.ToDateTime(parm);
            date[1] = date[0].AddDays(1);
            return parm == null ? accountService.readResult(casino, userid) : accountService.readHistory(casino,userid,date);
        }

        public static void readHistory2(string casino,DateTime[] date)
        {
            accountService.readHistory2(casino, date);
        }
    }
}
