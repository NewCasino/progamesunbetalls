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
	public class ManagerManager
	{
		private static ManagerService managerService=new ManagerService();
        /// <summary>
        /// 验证登录
        /// Programmer:lxb
        /// time:08-27 23:46
        /// </summary>
        /// <param name="managerId"></param>
        /// <param name="password"></param>
        /// <param name="manager"></param>
        /// <returns></returns>
        public static bool CheckLogin(string managerId, string password, ref Manager manager)
        {
            Manager m = managerService.GetManagerByManagerId(managerId,password);
            if (m != null)
            {
                if (m.Enable == 1)
                {
                    manager = m;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 返回所有数据（Json)
        /// By xzz
        /// time:2010-8-31 22:48
        /// </summary>
        /// <returns></returns>
        public string GetManager()
        {
            return ObjectToJson.ReaderToJson(managerService.GetManagers());
        }

        /// <summary>
        /// 根据角色ID返回帐号(Json)
        /// By xzz
        /// Time:2010-9-6
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public string GetManagetsByRoleId(int roleId)
        {
            return ObjectToJson.ReaderToJson(managerService.GetManagetsByRoleId(roleId));
        }

        /// <summary>
        /// 更新管理员角色
        /// By xzz
        /// time:2010-9-1
        /// </summary>
        /// <param name="RoleId">角色Id</param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool UpdateManager(int RoleId, int ID)
        {
            Manager manager = managerService.GetManagerByPK(ID);
            manager.RoleId = RoleId;

            return managerService.UpdateManager(manager);
        }

        /// <summary>
        /// 更新管理员状态
        /// By xzz
        /// time:2010-9-1
        /// </summary>
        /// <param name="Enable"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool UpdateManagerStatus(int Enable, int ID)
        {
            Manager manager = managerService.GetManagerByPK(ID);
            if (manager.Enable == 1)
            {
                manager.Enable = 0;
            }
            else if (manager.Enable == 0)
            {
                manager.Enable = 1;
            }

            return managerService.UpdateManager(manager);
        }

        /// <summary>
        /// 修改管理员密码
        /// By xzz
        /// time:2010-9-1
        /// </summary>
        /// <param name="passWord"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool MdfPassword(string passWord, int id)
        {
            return managerService.MdfPassWord(passWord, id);
        }

        /// <summary>
        /// 通过帐号密码查询manager对象
        /// By xzz
        /// time:2010-9-2s
        /// </summary>
        /// <param name="managerId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static Manager GetManagerByManagerId(string managerId, string password)
        {
            return managerService.GetManagerByManagerId(managerId, password);
        }

        public static string ManagerToJson(Manager manager)
        {
            StringBuilder Json = new StringBuilder();
            Json.Append("[");
            Json.Append("{");
            Json.Append("\"ID\":\"" + manager.ID.ToString() + "\",");
            Json.Append("\"ManagerId\":\"" + manager.ManagerId + "\",");
            Json.Append("\"PassWord\":\"" + manager.PassWord + "\",");
            Json.Append("\"RoleId\":\"" + manager.RoleId.ToString() + "\",");
            Json.Append("\"CreateDate\":\"" + manager.CreateDate.ToString() + "\",");
            Json.Append("\"UpdateDate\":\"" + manager.UpdateDate.ToString() + "\",");
            Json.Append("\"CreateUser\":\"" + manager.CreateUser + "\",");
            Json.Append("\"IP\":\"" + manager.IP + "\",");
            Json.Append("\"Enable\":\"" + manager.Enable.ToString() + "\"");
            Json.Append("}");
            Json.Append("]");
            return Json.ToString();
        }

		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-8-27 22:01:08
		///</sumary>
		public static Manager GetManagerByPK(object pk) 
		{
			try
			{
				return managerService.GetManagerByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-8-27 22:01:08
		///</sumary>
		public static Boolean AddManager(Manager manager) 
		{
			try
			{
				return managerService.AddManager(manager);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-8-27 22:01:08
		///</sumary>
		public static Boolean UpdateManager(Manager manager) 
		{
			try
			{
				return managerService.UpdateManager(manager);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-8-27 22:01:08
		///</sumary>
		public static Boolean DeleteManagerByPK(object pk) 
		{
			try
			{
				return managerService.DeleteManagerByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-8-27 22:01:08
		///</sumary>
		public static DataTable GetMutilDTManager() 
		{
			try
			{
				return managerService.GetMutilDTManager();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-8-27 22:01:08
		///</sumary>
		public static IList<Manager> GetMutilILManager() 
		{
			try
			{
				return managerService.GetMutilILManager();
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
