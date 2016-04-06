using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
    public class System_role_rightService
    {
        private const string SQL_INSERT = "insert into system_role_right (RoleId,Module_right_id)values(?RoleId,?Module_right_id)";
        private const string SQL_UPDATE = "update system_role_right set RoleId=?RoleId,Module_right_id=?Module_right_id where role_right_id = ?role_right_id";
        private const string SQL_SELECTBYPK = "select role_right_id from system_role_right  where system_role_right.role_right_id = ?role_right_id";
        private const string SQL_SELECTALL = "select role_right_id,RoleId,Module_right_id from system_role_right ";
        private const string SQL_DELETEBYPK = "delete  from system_role_right  where system_role_right.role_right_id = ?role_right_id";

        private const string SQL_ROLEID = "select * from system_role_right where RoleId=@RoleId";
        private const string INSERT = "insert into system_role_right(RoleId,Module_right_id) values(@RoleId,@Module_right_id)";
        private const string DELETE = "delete FROM system_role_right where RoleId=@RoleId and module_right_id not in(@Module_right_id)";
        private const string SELETE_PN = "select * from system_role_right where RoleId=@RoleId and Module_right_id=@Module_right_id";

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-8-27 22:00:49		
        ///</summary>		
        public Boolean AddSystem_role_right(System_role_right system_role_right)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?RoleId",system_role_right.RoleId),
				 new MySqlParameter("?Module_right_id",system_role_right.Module_right_id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-8-27 22:00:49		
        ///</summary>		
        public Boolean UpdateSystem_role_right(System_role_right system_role_right)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?RoleId",system_role_right.RoleId),
				 new MySqlParameter("?Module_right_id",system_role_right.Module_right_id),
				 new MySqlParameter("?role_right_id",system_role_right.Role_right_id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-8-27 22:00:49		
        ///</summary>		
        public Boolean DeleteSystem_role_rightByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?role_right_id",id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2010-8-27 22:00:49		
        ///</summary>		
        public System_role_right GetSystem_role_rightByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?role_right_id",id)
			};

            return MySqlModelHelper<System_role_right>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2010-8-27 22:00:49		
        ///</summary>		
        public IList<System_role_right> GetMutilILSystem_role_right()
        {
            return MySqlModelHelper<System_role_right>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2010-8-27 22:00:49		
        ///</summary>		
        public DataTable GetMutilDTSystem_role_right()
        {
            return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
        }

        private DataTable GetDataBySql(string sql, params MySqlParameter[] param)
        {
            return MySqlHelper.ExecuteDataTable(sql, param);

        }

        /// <summary>
        /// 根据RoleId返回数据
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public DataTable GetDataByRoleId(int roleId)
        {
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@RoleId",roleId)
            };

            return GetDataBySql(SQL_ROLEID, param);
        }

        /// <summary>
        /// 添加角色权限
        /// </summary>
        /// <param name="RoleId">角色ID</param>
        /// <param name="Module_right_id">权限ID</param>
        /// <returns></returns>
        public bool AddRoleRight(int RoleId, int Module_right_id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@RoleId",RoleId),
                new MySqlParameter("@Module_right_id",Module_right_id)
            };

            return MySqlHelper.ExecuteNonQuery(INSERT, param) == 1;
        }

        /// <summary>
        /// 删除记录，用于修改角色权限时删除记录
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="Module_right_ids"></param>
        /// <returns></returns>
        public int DeleteRoleRights(int roleId, string Module_right_ids)
        {
            //MySqlParameter[] param = new MySqlParameter[]{
            //    new MySqlParameter("@RoleId",roleId),
            //    new MySqlParameter("@Module_right_id",Module_right_ids)
            //};

            string sql = "delete FROM system_role_right where RoleId=" + roleId + " and module_right_id not in(" + Module_right_ids + ")";

            return MySqlHelper.ExecuteNonQuery(sql, null);
        }

        public DataTable GetRoleRightByRoleIdAndMid(int RoleId, int Module_right_id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@RoleId",RoleId),
                new MySqlParameter("@Module_right_id",Module_right_id)
            };

            return GetDataBySql(SELETE_PN, param);
        }

        /// <summary>
        /// 判断角色是否有权限
        /// </summary>
        /// <param name="RoleId">角色ID</param>
        /// <param name="Module_right_id">模块权限ID</param>
        /// <returns>true：有权限 false：无权限</returns>
        public bool IsPermission(int RoleId, int Module_right_id)
        {

            DataTable dt = GetRoleRightByRoleIdAndMid(RoleId, Module_right_id);

            return dt.Rows.Count > 0;
        }

        #endregion
    }
}
