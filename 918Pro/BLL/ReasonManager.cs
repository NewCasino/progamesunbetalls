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
	public class ReasonManager
	{
		private static ReasonService reasonService=new ReasonService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-9-26 12:11:08
		///</sumary>
		public static Reason GetReasonByPK(object pk) 
		{
			try
			{
				return reasonService.GetReasonByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-9-26 12:11:08
		///</sumary>
		public static Boolean AddReason(Reason reason) 
		{
			try
			{
				return reasonService.AddReason(reason);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-9-26 12:11:08
		///</sumary>
		public static Boolean UpdateReason(Reason reason) 
		{
			try
			{
				return reasonService.UpdateReason(reason);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-9-26 12:11:08
		///</sumary>
		public static Boolean DeleteReasonByPK(object pk) 
		{
			try
			{
				return reasonService.DeleteReasonByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-9-26 12:11:08
		///</sumary>
		public static DataTable GetMutilDTReason() 
		{
			try
			{
				return reasonService.GetMutilDTReason();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-9-26 12:11:08
		///</sumary>
		public static IList<Reason> GetMutilILReason() 
		{
			try
			{
				return reasonService.GetMutilILReason();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
        /// <summary>
        /// descripton:获得ID值最大的一条数据 返回一个实体对象
        /// create date 2010-09-26 21：47
        /// create by 肖军文
        /// </summary>
        /// <returns></returns>
        public static Reason GetReasonByMaxID()
        {
            try {

                Reason reason = reasonService.GetReasonByMaxID();
                if (reason != null) { return reason; } else { return null; }
            }
            catch(Exception ex){
                return null ;
            }
        }

		#endregion


        /// <summary>
        /// create by 肖军文
        /// create date 2010-09-30
        /// description 添加信息
        /// </summary>
        /// <param name="re"></param>
        /// <returns></returns>
        public static int AddReasonInfo(Reason re)
        {
            try
            {
                int Id =  reasonService.AddReasonInfo(re);
                if(Id!=0){
                    return Id;
                }
                return 0;
            }
            catch(Exception ex){
                return 0;
            }
        }
    }
}
