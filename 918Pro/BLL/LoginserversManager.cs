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
	public class LoginserversManager
	{
		private static LoginserversService loginserversService=new LoginserversService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-11-2 13:39:04
		///</sumary>
		public static Loginservers GetLoginserversByPK(object pk) 
		{
			try
			{
				return loginserversService.GetLoginserversByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-11-2 13:39:04
		///</sumary>
		public static Boolean AddLoginservers(Loginservers loginservers) 
		{
			try
			{
				return loginserversService.AddLoginservers(loginservers);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-11-2 13:39:04
		///</sumary>
		public static Boolean UpdateLoginservers(Loginservers loginservers) 
		{
			try
			{
				return loginserversService.UpdateLoginservers(loginservers);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-11-2 13:39:04
		///</sumary>
		public static Boolean DeleteLoginserversByPK(object pk) 
		{
			try
			{
				return loginserversService.DeleteLoginserversByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-11-2 13:39:04
		///</sumary>
		public static DataTable GetMutilDTLoginservers() 
		{
			try
			{
				return loginserversService.GetMutilDTLoginservers();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-11-2 13:39:04
		///</sumary>
		public static IList<Loginservers> GetMutilILLoginservers() 
		{
			try
			{
				return loginserversService.GetMutilILLoginservers();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion

        public static string GetloginserversAll()
        {
            return ObjectToJson.ReaderToJson(loginserversService.GetloginserversAll());
        }

        public static bool UpdateLoginServiceStatus(int Status, int ID)
        {

            return loginserversService.UpdateLoginServiceStatus(Status,ID);
        }
    }
}
