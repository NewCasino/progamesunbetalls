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
	public class RoleManager
	{
		private static RoleService roleService=new RoleService();

        /// <summary>
        /// 添加代理部门角色
        /// </summary>
        /// <param name="roleName">部门名称</param>
        /// <param name="reMark">备注</param>
        /// <param name="rootId">代理ID</param>
        /// <param name="agentId">代理名称</param>
        /// <param name="CreateUser">创建人</param>
        /// <returns></returns>
        public string AddAgentRole(string roleName, string reMark, int rootId, string agentId, string CreateUser)
        {
            Role role = new Role();
            role.RoleName = roleName;
            role.Remark = reMark;
            role.Status = "1";
            role.RootId = rootId;
            role.AgentId = agentId;
            role.CreateUser = CreateUser;
            role.CreateDate = DateTime.Now;
            role.IP = Util.RequestHelper.GetIP();
            role.Id = InsertRole(role);

            return ObjectToJson.ObjectsToJson<Role>(role);
        }

        /// <summary>
        /// 返回代理部门角色
        /// By xzz 2010-11-24
        /// </summary>
        /// <param name="rootId">当前代理角色ID</param>
        /// <param name="agentId">代理用户名</param>
        /// <returns></returns>
        public IList<Role> GetAgentRoleByAgentID(int rootId, string agentId)
        {
            return roleService.GetAgentRoleByAgentID(rootId, agentId);
        }

        /// <summary>
        /// 返回代理角色
        /// </summary>
        /// <returns></returns>
        public IList<Role> GetAgentRole()
        {
            return roleService.GetAgentRole();
        }

        /// <summary>
        /// 返回角色，根据代理ID(Json)
        /// By xzz
        /// 2010-8-31 23:56
        /// </summary>
        /// <param name="agentId">代理ID</param>
        /// <returns></returns>
        public string GetRoles(string agentId)
        {
            RoleService roleService = new RoleService();
            return ObjectToJson.ObjectListToJson(roleService.GetRoleByAgentId(agentId));
        }

        /// <summary>
        /// 角色是否重复
        /// </summary>
        /// <param name="agentId">代理帐号</param>
        /// <returns></returns>
        public bool IsExistRole(string roleName, string agentId)
        {
            Role role = roleService.IsExistRole(roleName, agentId);
            if (role == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 根据Id返回所有角色，包括下级
        /// By xzz
        /// 2010-9-4
        /// </summary>
        /// <param name="Id">角色ID</param>
        /// <returns></returns>
        public IList<Role> GetRoleById(int Id)
        {
            return roleService.GetRoleById(Id);
        }

        /// <summary>
        /// 添加角色，返回新数据ID值
        /// By xzz
        /// Time:2010-9-5
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public int InsertRole(Role role)
        {
            return roleService.InsertRole(role);
        }

		#region 生成代码
		///<sumary>
		///通过id获得实体对象
		///时间：2010-8-27 22:01:15
		///</sumary>
		public static Role GetRoleByPK(object pk) 
		{
			try
			{
				return roleService.GetRoleByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return null;
			}
		}

		///<sumary>
		///添加信息
		///时间：2010-8-27 22:01:15
		///</sumary>
		public static Boolean AddRole(Role role) 
		{
			try
			{
				return roleService.AddRole(role);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///修改信息
		///时间：2010-8-27 22:01:15
		///</sumary>
		public static Boolean UpdateRole(Role role) 
		{
			try
			{
				return roleService.UpdateRole(role);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///删除信息
		///时间：2010-8-27 22:01:15
		///</sumary>
		public static Boolean DeleteRoleByPK(object pk) 
		{
			try
			{
				return roleService.DeleteRoleByPK(pk);
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return false;
			}
		}

		///<sumary>
		///获得所有信息，得到一张临时表
		///时间：2010-8-27 22:01:15
		///</sumary>
		public static DataTable GetMutilDTRole() 
		{
			try
			{
				return roleService.GetMutilDTRole();
			}
			catch(Exception ex)
			{
				//可以记录到异常日志
				return  null;
			}
		}

		///<sumary>
		///获得所有信息，返回泛型集合
		///时间：2010-8-27 22:01:15
		///</sumary>
		public static IList<Role> GetMutilILRole() 
		{
			try
			{
				return roleService.GetMutilILRole();
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
