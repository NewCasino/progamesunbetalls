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
	public class ServerManager
	{
		private static ServerService serverService=new ServerService();

        /// <summary>
        /// 查询二级域名
        /// 编写时间: 2010-10-11 17:10
        /// 创建者：Mickey
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static bool SelectGuId(string guid)
        {
            return serverService.SelectGuId(guid);
        }

        /// <summary>
        /// 修改服务器配置
        /// 编写时间: 2010-10-11 21:00
        /// 创建者：Mickey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ip1"></param>
        /// <param name="ip2"></param>
        /// <param name="ip3"></param>
        /// <param name="area"></param>
        /// <param name="status"></param>
        /// <param name="reMark"></param>
        /// <returns></returns>
        public static string updateServer(int id, string serverName, string ip1, string ip2, string ip3, string area, string status,DateTime time, string reMark)
        {
            if (serverService.updateServer(id, serverName, ip1, ip2, ip3, area, status, time, reMark))
            {
                return "ok";
            }
            else
            {
                return "修改失败";
            }
        }

        /// <summary>
        /// 获取所有服务器
        /// 编写时间: 2010-10-10 14:00
        /// 创建者：Mickey
        /// </summary>
        /// <returns></returns>
        public static string GetServerAll()
        {
            return ObjectToJson.ReaderToJson(serverService.GetServerAll());
        }

		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-10-10 20:13:38
		///</sumary>
		public static Server GetServerByPK(object pk) 
		{
			try
			{
				return serverService.GetServerByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

        /// <summary>
        /// 新增服务器
        /// 编写时间: 2010-12-11 22:00
        /// 创建者：Mickey
        /// </summary>
        /// <param name="server"></param>
        /// <returns></returns>
		public static Boolean AddServer(Server server) 
		{
			try
			{
				return serverService.AddServer(server);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-10-10 20:13:38
		///</sumary>
		public static Boolean UpdateServer(Server server) 
		{
			try
			{
				return serverService.UpdateServer(server);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-10-10 20:13:38
		///</sumary>
		public static Boolean DeleteServerByPK(object pk) 
		{
			try
			{
				return serverService.DeleteServerByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-10-10 20:13:38
		///</sumary>
		public static DataTable GetMutilDTServer() 
		{
			try
			{
				return serverService.GetMutilDTServer();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-10-10 20:13:38
		///</sumary>
		public static IList<Server> GetMutilILServer() 
		{
			try
			{
				return serverService.GetMutilILServer();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion

        /// <summary>
        /// JSON格式转换
        /// </summary>
        /// <param name="server"></param>
        /// <returns></returns>
        public static string ServerToJson(Server server)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("[");
            Json.Append("{");
            Json.Append("\"ID\":\"" + server.ID.ToString() + "\",");
            Json.Append("\"ServerName\":\"" + server.ServerName + "\",");
            Json.Append("\"Ip1\":\"" + server.Ip1 + "\",");
            Json.Append("\"Ip2\":\"" + server.Ip2 + "\",");
            Json.Append("\"Ip3\":\"" + server.Ip3 + "\",");
            Json.Append("\"SubDomain\":\"" + server.SubDomain.ToString() + "\",");
            Json.Append("\"OnlineNumber\":\"" + server.OnlineNumber.ToString() + "\",");
            Json.Append("\"Area\":\"" + server.Area + "\",");
            Json.Append("\"status\":\"" + server.Status + "\",");
            Json.Append("\"AddDate\":\"" + server.AddDate.ToString() + "\",");
            Json.Append("\"ReMark\":\"" + server.ReMark + "\"");
            Json.Append("}");
            Json.Append("]");
            return Json.ToString();
        }

        public static bool CeliName(string Name)
        {
            return serverService.CeliName(Name);
        }
    }
}
