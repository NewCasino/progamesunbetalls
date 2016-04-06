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
	public class BanklistcManager
	{
		private static BanklistcService banklistcService=new BanklistcService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2011-4-14 16:28:38
		///</sumary>
		public static Banklistc GetBanklistcByPK(object pk) 
		{
			try
			{
				return banklistcService.GetBanklistcByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2011-4-14 16:28:38
		///</sumary>
		public static Boolean AddBanklistc(Banklistc banklistc) 
		{
			try
			{
				return banklistcService.AddBanklistc(banklistc);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2011-4-14 16:28:38
		///</sumary>
		public static Boolean UpdateBanklistc(Banklistc banklistc) 
		{
			try
			{
				return banklistcService.UpdateBanklistc(banklistc);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}
        
		///<sumary>
		///修改信息
		///时间：2011-4-14 16:28:38
		///</sumary>
        public static Boolean UpdateBanklistc_bank(Banklistc banklistc) 
		{
			try
			{
                return banklistcService.UpdateBanklistc_bank(banklistc);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}
		///<sumary>
		///删除信息
		///时间：2011-4-14 16:28:38
		///</sumary>
		public static Boolean DeleteBanklistcByPK(object pk) 
		{
			try
			{
				return banklistcService.DeleteBanklistcByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2011-4-14 16:28:38
		///</sumary>
		public static DataTable GetMutilDTBanklistc() 
		{
			try
			{
				return banklistcService.GetMutilDTBanklistc();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2011-4-14 16:28:38
		///</sumary>
		public static IList<Banklistc> GetMutilILBanklistc() 
		{
			try
			{
				return banklistcService.GetMutilILBanklistc();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion

        public string GetBankListcBynamecn(string namecn)
        {
            return banklistcService.GetBankListcBynamecn(namecn);
        }

        public string GetBankListcByCurrency(string currency)
        {
            return banklistcService.GetBankListcByCurrency(currency);
        }

        public bool IsWithDrawal(string userName)
        {
            return banklistcService.IsWithDrawal(userName);
        }
	}
}
