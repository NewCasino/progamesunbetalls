using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class BankInfoManager
    {
        public static BankInfoService bankInfoService = new BankInfoService();

        public static string SelectAll()
        {
            return bankInfoService.SelectAll();
        }

        public static string SelectByCurr(string currency)
        {
            return bankInfoService.SelectByCurr(currency);
        }

        public static bool AddBankInfo(BankInfo bankInfo)
        {
            return bankInfoService.AddBankInfo(bankInfo);
        }

        public static bool UpdateBankInfo(BankInfo bankInfo)
        {
            return bankInfoService.UpdateBankInfo(bankInfo);
        }

        public static bool DeleteBankInfo(string id)
        {
            return bankInfoService.DeleteBankInfo(id);
        }
    }
}
