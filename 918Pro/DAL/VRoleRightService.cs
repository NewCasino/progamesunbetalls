using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;

namespace DAL
{
    public class VRoleRightService
    {
        private const string SQL_ROLE = "select * from v_role_right where RoleId=@RoleId and OperateID=0 order by sorts";
        private const string SQL_ROLE_TREE = "select * from v_role_right where RoleId=@RoleId and Module_parent_code=@Module_parent_code group by Module_code order by sorts desc,Module_code";
        private const string SQL_ROLE_MCODE = "select * from v_role_right where RoleId=@RoleId and Module_code=@Module_code";

        private DataTable GetDataBySql(string sql, params MySqlParameter[] param)
        {
            return MySqlHelper.ExecuteDataTable(sql, param);
        }

        /// <summary>
        /// 返回一级模块
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public DataTable GetDataByRole(int RoleId)
        {
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@RoleId",RoleId)
            };

            return GetDataBySql(SQL_ROLE, param);
        }

        /// <summary>
        /// 返回二级模块
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="Module_code"></param>
        /// <returns></returns>
        public DataTable GetDataByRoleTree(int RoleId, string Module_code)
        {
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@RoleId",RoleId),
                new MySqlParameter("@Module_parent_code",Module_code)
            };

            return GetDataBySql(SQL_ROLE_TREE, param);
        }

        /// <summary>
        /// 返回权限id，根据角色ID和模块编号
        /// </summary>
        /// <param name="roleId">角色id</param>
        /// <param name="Module_code">模块编号</param>
        /// <returns></returns>
        public DataTable GetDataByRoleMcode(int roleId, string Module_code)
        {
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@RoleId",roleId),
                new MySqlParameter("@Module_code",Module_code)
            };

            return GetDataBySql(SQL_ROLE_MCODE, param);
        }

    }
}
