using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL.Ezun;
using Util;

namespace BLL.Ezun
{
     public class BankManager
    {
         public static BankService bankService = new BankService();
         public static string GetBankInfoAll()
        {
            return bankService.GetBankInfoAll();
        }
         public static string GetBankInfo()
         {
             return bankService.GetBankInfo();
         }
         public static string GetBankCByCurr()
         {
             return bankService.GetBankCByCurr();
         }
         public static bool UpdateBillNotice(string  bankno)
         {
             return bankService.UpdateBillNotice(bankno);
         }
         public static bool AddBillNotice(BillNotice billNotice)
         {
             return bankService.AddBillNotice(billNotice);
         }
         public static bool AddBillNotice2(BillNotice billNotice)
         {
             return bankService.AddBillNotice2(billNotice);
         }

         public static string GetBillNotice(string userName, string type, string time1, string time2, string lan)
         {
             return bankService.GetBillNotice(userName, type, time1, time2, lan);
         }

         public static string GetBillNoticeHistory(string userName, string type, string time1, string time2, string lan)
         {
             return bankService.GetBillNoticeHistory(userName, type, time1, time2, lan);
         }

         public static string GetBillNotice2(string p, string type, string time1, string time2, string lan)
         {
             throw new NotImplementedException();
         }

         public static string GetBillNoticeHistory2(string p, string type, string time1, string time2, string lan)
         {
             throw new NotImplementedException();
         }

         public static string GetBillNotice_sum(string userName, string time1, string time2, string lan)
         {
             return bankService.GetBillNotice_sum(userName,time1, time2, lan);
         }

         public static string GetBankInfos(int id)
         {
             return bankService.GetBankInfos(id);
         }

         public static string GetBankInfos4()
         {
             return bankService.GetBankInfos4();
         }



         public static string Getparentcode(string username)
         {
             return bankService.Getparentcode(username);
         }

         public static bool UpdateBillNotice2(string bankno, string amount)
         {
             return bankService.UpdateBillNotice2(bankno, amount);
         }
    }
}
