using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Ezun;
using Model;

namespace BLL.Ezun
{
    public  class UserManagers
    {
        private static UserServices userServices = new UserServices();
        public static bool CheckOldPwd(string oldPwd, int userId)
        {
            return userServices.CheckOldPwd(oldPwd, userId);
        }

        public static bool UpdatePassword(string newPwd, int userId)
        {
            return userServices.UpdatePassword(newPwd, userId);
        }

        public bool UpdateUserInfo(User info)
        {
            return userServices.UpdateUserInfo(info);
        }

        public  string GetBanks(string username)
        {
            return userServices.GetBanks(username);
        }
        public bool UpdateUserInfoS(string username, string bankName, string bankUserName, string bankCard)
        {
            return userServices.UpdateUserInfoS(username, bankName, bankUserName, bankCard);
        }
        public static bool Getpwds(string newold, string username, string type, string Names)
        {
            return userServices.Getpwds(newold, username, type, Names);
        }

        public static string GetPTinfo(string username)
        {
            return userServices.GetPTinfo(username);
        }

        public static bool GetPTpwdInfo(string username)
        {
            return userServices.GetPTpwdInfo(username);
        }
    }
}
