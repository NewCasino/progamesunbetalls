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
	public class BankhistoryManager
	{
		private static BankhistoryService bankhistoryService=new BankhistoryService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2011-4-14 16:29:56
		///</sumary>
		public static Bankhistory GetBankhistoryByPK(object pk) 
		{
			try
			{
				return bankhistoryService.GetBankhistoryByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2011-4-14 16:29:56
		///</sumary>
		public static Boolean AddBankhistory(Bankhistory bankhistory) 
		{
			try
			{
				return bankhistoryService.AddBankhistory(bankhistory);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2011-4-14 16:29:56
		///</sumary>
		public static Boolean UpdateBankhistory(Bankhistory bankhistory) 
		{
			try
			{
				return bankhistoryService.UpdateBankhistory(bankhistory);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2011-4-14 16:29:56
		///</sumary>
		public static Boolean DeleteBankhistoryByPK(object pk) 
		{
			try
			{
				return bankhistoryService.DeleteBankhistoryByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2011-4-14 16:29:56
		///</sumary>
		public static DataTable GetMutilDTBankhistory() 
		{
			try
			{
				return bankhistoryService.GetMutilDTBankhistory();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2011-4-14 16:29:56
		///</sumary>
		public static IList<Bankhistory> GetMutilILBankhistory() 
		{
			try
			{
				return bankhistoryService.GetMutilILBankhistory();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion

        public static string GetBankhistorybyWhere(string typ, string bank, string cardno, string time1, string time2)
        {
            return bankhistoryService.GetBankhistorybyWhere(typ, bank, cardno, time1, time2);
        }



        public static bool InsertBillNoticeManagent(BillNoticeHistory billNoticeHistory)
        {
            try
            {
                return bankhistoryService.InsertBillNoticeManagent(billNoticeHistory);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return false;
            }
        }


        public static bool InsertBillNoticeManagentC(BillNoticeHistory billNoticeHistory)
        {
            return bankhistoryService.InsertBillNoticeManagentC(billNoticeHistory);
        }
    }
}
