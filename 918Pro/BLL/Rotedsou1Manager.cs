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
	public class Rotedsou1Manager
	{
		private static Rotedsou1Service rotedsou1Service=new Rotedsou1Service(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-11-2 10:27:12
		///</sumary>
		public static Rotedsou1 GetRotedsou1ByPK(object pk) 
		{
			try
			{
				return rotedsou1Service.GetRotedsou1ByPK(pk);
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
		public static Boolean AddRotedsou1(Rotedsou1 rotedsou1) 
		{
			try
			{
				return rotedsou1Service.AddRotedsou1(rotedsou1);
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
		public static Boolean UpdateRotedsou1(Rotedsou1 rotedsou1) 
		{
			try
			{
				return rotedsou1Service.UpdateRotedsou1(rotedsou1);
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
		public static Boolean DeleteRotedsou1ByPK(object pk) 
		{
			try
			{
				return rotedsou1Service.DeleteRotedsou1ByPK(pk);
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
		public static DataTable GetMutilDTRotedsou1() 
		{
			try
			{
				return rotedsou1Service.GetMutilDTRotedsou1();
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
		public static IList<Rotedsou1> GetMutilILRotedsou1() 
		{
			try
			{
				return rotedsou1Service.GetMutilILRotedsou1();
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
