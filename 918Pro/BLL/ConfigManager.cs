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
	public class ConfigManager
	{
		private static ConfigService configService=new ConfigService();

        /// <summary>
        /// 添加：config 数据
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static int InsertConfig(Config config)
        {
            try
            {
                return configService.InsertConfig(config);
            }
            catch (Exception ex)
            {
                //可以记录到异常日志
                return 0;
            }
        }

        /// <summary>
        /// 查询：config 数据（Json)
        /// </summary>
        /// <returns></returns>
        public static string GetConfigAll()
        {
            return ObjectToJson.ReaderToJson(configService.GetConfigAll());
        }

        /// <summary>
        /// 修改：config 数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="otype"></param>
        /// <param name="oval"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public static Boolean updateConfig(string id, string otype, string oval, string remark)
        {
            return configService.updateConfig(id,otype,oval,remark);
        }
		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-9-29 21:17:26
		///</sumary>
		public static Config GetConfigByPK(object pk) 
		{
			try
			{
				return configService.GetConfigByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-9-29 21:17:26
		///</sumary>
		public static Boolean AddConfig(Config config) 
		{
			try
			{
				return configService.AddConfig(config);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-9-29 21:17:26
		///</sumary>
		public static Boolean UpdateConfig(Config config) 
		{
			try
			{
				return configService.UpdateConfig(config);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-9-29 21:17:26
		///</sumary>
		public static Boolean DeleteConfigByPK(object pk) 
		{
			try
			{
				return configService.DeleteConfigByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-9-29 21:17:26
		///</sumary>
		public static DataTable GetMutilDTConfig() 
		{
			try
			{
				return configService.GetMutilDTConfig();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-9-29 21:17:26
		///</sumary>
		public static IList<Config> GetMutilILConfig() 
		{
			try
			{
				return configService.GetMutilILConfig();
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
            return configService.CeliName(Name);
        }

        public Config GetConfigByOtype(string otype)
        {
            return configService.GetConfigByOtype(otype);
        }
       
        public IList<Config> GetPro_setup()
        {
            return configService.GetPro_setup();
           
        }

        public bool UpdataPro_setup(string id, string oval)
        {
            return configService.UpdataPro_setup(id,oval);
        }
    }
}
