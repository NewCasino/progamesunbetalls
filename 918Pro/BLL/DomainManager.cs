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
	public class DomainManager
	{
		private static DomainService domainService=new DomainService();

        /// <summary>
        /// 获取所有域名网址
        /// 编写时间: 2010-12-10 14:00
        /// 创建者：Mickey
        /// </summary>
        /// <returns></returns>
        public static string GetDomainAll()
        {
            return ObjectToJson.ReaderToJson(domainService.GetDomainAll());
        }

        /// <summary>
        /// 新增域名网址
        /// 编写时间: 2010-12-10 14:30
        /// 创建者：Mickey
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public static int InsertDomain(Domain domain)
        {
            try
            {
                return domainService.InsertDomain(domain);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return 0;
            }
        }

        /// <summary>
        /// 修改网址域名
        /// 编写时间: 2010-12-10 15:00
        /// 创建者：Mickey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="domainName"></param>
        /// <param name="ismain"></param>
        /// <param name="status"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static bool updateDomain(string id, string domainName, string ismain, string status, DateTime time)
        {
            return domainService.updateConfig(id, domainName, ismain, status, time);
        }

		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-10-10 20:16:40
		///</sumary>
		public static Domain GetDomainByPK(object pk) 
		{
			try
			{
				return domainService.GetDomainByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-10-10 20:16:40
		///</sumary>
		public static Boolean AddDomain(Domain domain) 
		{
			try
			{
				return domainService.AddDomain(domain);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-10-10 20:16:40
		///</sumary>
		public static Boolean UpdateDomain(Domain domain) 
		{
			try
			{
				return domainService.UpdateDomain(domain);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-10-10 20:16:40
		///</sumary>
		public static Boolean DeleteDomainByPK(object pk) 
		{
			try
			{
				return domainService.DeleteDomainByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-10-10 20:16:40
		///</sumary>
		public static DataTable GetMutilDTDomain() 
		{
			try
			{
				return domainService.GetMutilDTDomain();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-10-10 20:16:40
		///</sumary>
		public static IList<Domain> GetMutilILDomain() 
		{
			try
			{
				return domainService.GetMutilILDomain();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}
		#endregion


        public static bool CeliName(string Name)
        {
            return domainService.CeliName(Name);
        }
    }
}
