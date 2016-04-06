using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class RoleService
	{
		private const string SQL_INSERT="insert into role (roleName,remark,status,rootId,CreateUser,CreateDate,IP,agentId)values(?roleName,?remark,?status,?rootId,?CreateUser,?CreateDate,?IP,?agentId)";
		private const string SQL_UPDATE="update role set roleName=?roleName,remark=?remark,status=?status,rootId=?rootId,CreateUser=?CreateUser,CreateDate=?CreateDate,IP=?IP,agentId=?agentId where Id = ?Id";
        private const string SQL_SELECTBYPK = "select Id,roleName,remark,status,rootId,CreateUser,CreateDate,IP,agentId from role  where role.Id = ?Id";
		private const string SQL_SELECTALL="select Id,roleName,remark,status,rootId,CreateUser,CreateDate,IP,agentId from role ";
		private const string SQL_DELETEBYPK="delete  from role  where role.Id = ?Id";
        private const string SQL_SELECTBYAGENTID = "select * from role  where role.agentId = ?agentId";
        private const string SQL_SELECTROLE = "SELECT * FROM `role` where Id=?Id union select * from `role` where rootId=?Id";
        private const string SQL_INSERT_RETURNID = "insert into role (roleName,remark,status,rootId,CreateUser,CreateDate,IP,agentId)values(?roleName,?remark,?status,?rootId,?CreateUser,?CreateDate,?IP,?agentId);SELECT LAST_INSERT_ID()";



        /// <summary>
        /// 返回代理部门角色
        /// By xzz 2010-11-24
        /// </summary>
        /// <param name="rootId">当前代理角色ID</param>
        /// <param name="agentId">代理用户名</param>
        /// <returns></returns>
        public IList<Role> GetAgentRoleByAgentID(int rootId, string agentId)
        {
            string sqlStr = "select * from role where rootId=?rootId and agentId=?agentId order by id";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?rootId",rootId),
                new MySqlParameter("?agentId",agentId)
            };

            return MySqlModelHelper<Role>.GetObjectsBySql(sqlStr, param);
        }

        /// <summary>
        /// 角色是否存在
        /// </summary>
        /// <param name="roleName">角色名称</param>
        /// <param name="agentId">代理帐号</param>
        /// <returns></returns>
        public Role IsExistRole(string roleName, string agentId)
        {
            string sqlStr = "select * from role where roleName=?roleName and agentId=?agentId";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?roleName",roleName),
                new MySqlParameter("?agentId",agentId)
            };
            return MySqlModelHelper<Role>.GetSingleObjectBySql(sqlStr, param);
        }

        /// <summary>
        /// 返回代理角色
        /// </summary>
        /// <returns></returns>
        public IList<Role> GetAgentRole()
        {
            string sqlStr = "select * from role where rootId=0 and roleName<>'系统管理员' and roleName<>'会员'";
            return MySqlModelHelper<Role>.GetObjectsBySql(sqlStr, null);
        }

        /// <summary>
        /// 返回角色，根据代理ID
        /// By xzz
        /// 2010-8-31 23:56
        /// </summary>
        /// <param name="agentId">代理ID</param>
        /// <returns></returns>
        public IList<Role> GetRoleByAgentId(string agentId)
        {
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?agentId",agentId)
            };
            return MySqlModelHelper<Role>.GetObjectsBySql(SQL_SELECTBYAGENTID, param);
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
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?Id",Id)
            };
            return MySqlModelHelper<Role>.GetObjectsBySql(SQL_SELECTROLE, param);
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
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?roleName",role.RoleName),
				 new MySqlParameter("?remark",role.Remark),
				 new MySqlParameter("?status",role.Status),
				 new MySqlParameter("?rootId",role.RootId),
				 new MySqlParameter("?CreateUser",role.CreateUser),
				 new MySqlParameter("?CreateDate",role.CreateDate),
				 new MySqlParameter("?IP",role.IP),
				 new MySqlParameter("?agentId",role.AgentId)
			};
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(SQL_INSERT_RETURNID, param));
        }

		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-8-27 22:00:48		
		///</summary>		
		public Boolean AddRole(Role role)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?roleName",role.RoleName),
				 new MySqlParameter("?remark",role.Remark),
				 new MySqlParameter("?status",role.Status),
				 new MySqlParameter("?rootId",role.RootId),
				 new MySqlParameter("?CreateUser",role.CreateUser),
				 new MySqlParameter("?CreateDate",role.CreateDate),
				 new MySqlParameter("?IP",role.IP),
				 new MySqlParameter("?agentId",role.AgentId)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-8-27 22:00:48		
		///</summary>		
		public Boolean UpdateRole(Role role)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?roleName",role.RoleName),
				 new MySqlParameter("?remark",role.Remark),
				 new MySqlParameter("?status",role.Status),
				 new MySqlParameter("?rootId",role.RootId),
				 new MySqlParameter("?CreateUser",role.CreateUser),
				 new MySqlParameter("?CreateDate",role.CreateDate),
				 new MySqlParameter("?IP",role.IP),
				 new MySqlParameter("?agentId",role.AgentId),
				 new MySqlParameter("?Id",role.Id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-8-27 22:00:48		
		///</summary>		
		public Boolean DeleteRoleByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?Id",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2010-8-27 22:00:48		
		///</summary>		
		public Role GetRoleByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?Id",id)
			};

			return MySqlModelHelper<Role>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2010-8-27 22:00:48		
		///</summary>		
		public IList<Role> GetMutilILRole()
		{
			return MySqlModelHelper<Role>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2010-8-27 22:00:48		
		///</summary>		
		public DataTable GetMutilDTRole()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion 
	}
}
