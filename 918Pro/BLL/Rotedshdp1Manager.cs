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
	public class Rotedshdp1Manager
	{
		private static Rotedshdp1Service rotedshdp1Service=new Rotedshdp1Service(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-11-2 10:27:10
		///</sumary>
		public static Rotedshdp1 GetRotedshdp1ByPK(object pk) 
		{
			try
			{
				return rotedshdp1Service.GetRotedshdp1ByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-11-2 10:27:10
		///</sumary>
		public static Boolean AddRotedshdp1(Rotedshdp1 rotedshdp1) 
		{
			try
			{
				return rotedshdp1Service.AddRotedshdp1(rotedshdp1);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-11-2 10:27:10
		///</sumary>
		public static Boolean UpdateRotedshdp1(Rotedshdp1 rotedshdp1) 
		{
			try
			{
				return rotedshdp1Service.UpdateRotedshdp1(rotedshdp1);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-11-2 10:27:10
		///</sumary>
		public static Boolean DeleteRotedshdp1ByPK(object pk) 
		{
			try
			{
				return rotedshdp1Service.DeleteRotedshdp1ByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-11-2 10:27:10
		///</sumary>
		public static DataTable GetMutilDTRotedshdp1() 
		{
			try
			{
				return rotedshdp1Service.GetMutilDTRotedshdp1();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-11-2 10:27:10
		///</sumary>
		public static IList<Rotedshdp1> GetMutilILRotedshdp1() 
		{
			try
			{
				return rotedshdp1Service.GetMutilILRotedshdp1();
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
