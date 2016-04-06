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
	public class TestlogManager
	{
		private static TestlogService testlogService=new TestlogService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2011-7-9 19:58:42
		///</sumary>
		public static Testlog GetTestlogByPK(object pk) 
		{
			try
			{
				return testlogService.GetTestlogByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2011-7-9 19:58:42
		///</sumary>
		public static Boolean AddTestlog(Testlog testlog) 
		{
			try
			{
				return testlogService.AddTestlog(testlog);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2011-7-9 19:58:42
		///</sumary>
		public static Boolean UpdateTestlog(Testlog testlog) 
		{
			try
			{
				return testlogService.UpdateTestlog(testlog);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2011-7-9 19:58:42
		///</sumary>
		public static Boolean DeleteTestlogByPK(object pk) 
		{
			try
			{
				return testlogService.DeleteTestlogByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2011-7-9 19:58:42
		///</sumary>
		public static DataTable GetMutilDTTestlog() 
		{
			try
			{
				return testlogService.GetMutilDTTestlog();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2011-7-9 19:58:42
		///</sumary>
		public static IList<Testlog> GetMutilILTestlog() 
		{
			try
			{
				return testlogService.GetMutilILTestlog();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion

        public string GetTestlogByWhere(string userid)
        {
            return testlogService.GetTestlogByWhere(userid);
        }

        public bool DeleTestlog()
        {
            return testlogService.DeleTestlog();
        }

	}
}
