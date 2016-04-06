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
	public class Rotedsouhf1Manager
	{
		private static Rotedsouhf1Service rotedsouhf1Service=new Rotedsouhf1Service(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-11-2 10:27:12
		///</sumary>
		public static Rotedsouhf1 GetRotedsouhf1ByPK(object pk) 
		{
			try
			{
				return rotedsouhf1Service.GetRotedsouhf1ByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-11-2 10:27:12
		///</sumary>
		public static Boolean AddRotedsouhf1(Rotedsouhf1 rotedsouhf1) 
		{
			try
			{
				return rotedsouhf1Service.AddRotedsouhf1(rotedsouhf1);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-11-2 10:27:12
		///</sumary>
		public static Boolean UpdateRotedsouhf1(Rotedsouhf1 rotedsouhf1) 
		{
			try
			{
				return rotedsouhf1Service.UpdateRotedsouhf1(rotedsouhf1);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-11-2 10:27:12
		///</sumary>
		public static Boolean DeleteRotedsouhf1ByPK(object pk) 
		{
			try
			{
				return rotedsouhf1Service.DeleteRotedsouhf1ByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-11-2 10:27:12
		///</sumary>
		public static DataTable GetMutilDTRotedsouhf1() 
		{
			try
			{
				return rotedsouhf1Service.GetMutilDTRotedsouhf1();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-11-2 10:27:12
		///</sumary>
		public static IList<Rotedsouhf1> GetMutilILRotedsouhf1() 
		{
			try
			{
				return rotedsouhf1Service.GetMutilILRotedsouhf1();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion
	}
}
