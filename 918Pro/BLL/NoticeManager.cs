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
	public class NoticeManager
	{
		private static NoticeService noticeService=new NoticeService();


        public IList<Notice> GetNoticeBylan2(string lan)
        {
            return noticeService.GetNoticeBylan2(lan);
        }
        public IList<Notice> GetNoticeBylan(string lan)
        {
            return noticeService.GetNoticeBylan(lan);
        }
      

		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2011-1-6 20:18:29
		///</sumary>
		public static Notice GetNoticeByPK(object pk) 
		{
			try
			{
				return noticeService.GetNoticeByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2011-1-6 20:18:29
		///</sumary>
		public static Boolean AddNotice(Notice notice) 
		{
			try
			{
				return noticeService.AddNotice(notice);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}


        public static Boolean UpdateNotice222(Notice notice) 
		{
			try
			{
                return noticeService.UpdateNotice222(notice);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}
		///<sumary>
		///修改信息
		///时间：2011-1-6 20:18:29
		///</sumary>
		public static Boolean UpdateNotice(Notice notice) 
		{
			try
			{
				return noticeService.UpdateNotice(notice);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2011-1-6 20:18:29
		///</sumary>
		public static Boolean DeleteNoticeByPK(object pk) 
		{
			try
			{
				return noticeService.DeleteNoticeByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

        public static Boolean DeleteNoticeByPK22(object pk) 
		{
			try
			{
                return noticeService.DeleteNoticeByPK222(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

        

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2011-1-6 20:18:29
		///</sumary>
		public static DataTable GetMutilDTNotice() 
		{
			try
			{
				return noticeService.GetMutilDTNotice();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2011-1-6 20:18:29
		///</sumary>
		public static IList<Notice> GetMutilILNotice() 
		{
			try
			{
				return noticeService.GetMutilILNotice();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion
        #region 编写人:李毅



        public static string getCount22()
        {
            return noticeService.getCount22();
        }

        public static string getCount()
        {
            return noticeService.getCount();
        }
        public static string getDataAll(int IDex, int IDexC)
        {
            return noticeService.getDataAll(IDex, IDexC);
        }

        public static string getDataAll_2()
        {
            return noticeService.getDataAll_2();
        }
        public static string getDataAll_1()
        {
            return noticeService.getDataAll_1();
        }
        public static string getDataAll222()
        {
            return noticeService.getDataAll222();
        }
        #endregion

       
    }
}
