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
	public class Rotedshdphf1Manager
	{
		private static Rotedshdphf1Service rotedshdphf1Service=new Rotedshdphf1Service(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-11-2 10:27:11
		///</sumary>
		public static Rotedshdphf1 GetRotedshdphf1ByPK(object pk) 
		{
			try
			{
				return rotedshdphf1Service.GetRotedshdphf1ByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-11-2 10:27:11
		///</sumary>
		public static Boolean AddRotedshdphf1(Rotedshdphf1 rotedshdphf1) 
		{
			try
			{
				return rotedshdphf1Service.AddRotedshdphf1(rotedshdphf1);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-11-2 10:27:11
		///</sumary>
		public static Boolean UpdateRotedshdphf1(Rotedshdphf1 rotedshdphf1) 
		{
			try
			{
				return rotedshdphf1Service.UpdateRotedshdphf1(rotedshdphf1);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-11-2 10:27:11
		///</sumary>
		public static Boolean DeleteRotedshdphf1ByPK(object pk) 
		{
			try
			{
				return rotedshdphf1Service.DeleteRotedshdphf1ByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-11-2 10:27:11
		///</sumary>
		public static DataTable GetMutilDTRotedshdphf1() 
		{
			try
			{
				return rotedshdphf1Service.GetMutilDTRotedshdphf1();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-11-2 10:27:11
		///</sumary>
		public static IList<Rotedshdphf1> GetMutilILRotedshdphf1() 
		{
			try
			{
				return rotedshdphf1Service.GetMutilILRotedshdphf1();
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
