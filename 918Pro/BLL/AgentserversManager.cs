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
	public class AgentserversManager
	{
		private static AgentserversService agentserversService=new AgentserversService(); 
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2011-5-12 20:18:29
		///</sumary>
		public static Agentservers GetAgentserversByPK(object pk) 
		{
			try
			{
				return agentserversService.GetAgentserversByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2011-5-12 20:18:29
		///</sumary>
		public static Boolean AddAgentservers(Agentservers agentservers) 
		{
			try
			{
				return agentserversService.AddAgentservers(agentservers);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2011-5-12 20:18:29
		///</sumary>
		public static Boolean UpdateAgentservers(Agentservers agentservers) 
		{
			try
			{
				return agentserversService.UpdateAgentservers(agentservers);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2011-5-12 20:18:29
		///</sumary>
		public static Boolean DeleteAgentserversByPK(object pk) 
		{
			try
			{
				return agentserversService.DeleteAgentserversByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2011-5-12 20:18:29
		///</sumary>
		public static DataTable GetMutilDTAgentservers() 
		{
			try
			{
				return agentserversService.GetMutilDTAgentservers();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2011-5-12 20:18:29
		///</sumary>
		public static IList<Agentservers> GetMutilILAgentservers() 
		{
			try
			{
				return agentserversService.GetMutilILAgentservers();
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
