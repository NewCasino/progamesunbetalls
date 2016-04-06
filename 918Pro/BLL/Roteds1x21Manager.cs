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
	public class Roteds1x21Manager
	{
		private static Roteds1x21Service roteds1x21Service=new Roteds1x21Service(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-11-2 10:27:08
		///</sumary>
		public static Roteds1x21 GetRoteds1x21ByPK(object pk) 
		{
			try
			{
				return roteds1x21Service.GetRoteds1x21ByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-11-2 10:27:08
		///</sumary>
		public static Boolean AddRoteds1x21(Roteds1x21 roteds1x21) 
		{
			try
			{
				return roteds1x21Service.AddRoteds1x21(roteds1x21);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-11-2 10:27:08
		///</sumary>
		public static Boolean UpdateRoteds1x21(Roteds1x21 roteds1x21) 
		{
			try
			{
				return roteds1x21Service.UpdateRoteds1x21(roteds1x21);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-11-2 10:27:08
		///</sumary>
		public static Boolean DeleteRoteds1x21ByPK(object pk) 
		{
			try
			{
				return roteds1x21Service.DeleteRoteds1x21ByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-11-2 10:27:08
		///</sumary>
		public static DataTable GetMutilDTRoteds1x21() 
		{
			try
			{
				return roteds1x21Service.GetMutilDTRoteds1x21();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-11-2 10:27:08
		///</sumary>
		public static IList<Roteds1x21> GetMutilILRoteds1x21() 
		{
			try
			{
				return roteds1x21Service.GetMutilILRoteds1x21();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion
        #region 编写人:李毅
        public static string getToHtml(string languague, string gameid)
        {
            return roteds1x21Service.getToHtml(languague,gameid);
        }

        public static string getzcToHtml(string languague, string gameid)
        {
            return roteds1x21Service.getzcToHtml(languague, gameid);
        }

        public static string getzdToHtml(string languague, string gameid)
        {
            return roteds1x21Service.getzdToHtml(languague, gameid);
        }
        #endregion
	}
}
