using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
	public class ManagerService
	{
        private const string SQL_INSERT="insert into manager (ManagerId,PassWord,RoleId,CreateDate,UpdateDate,CreateUser,IP,Enable,SubAccount,UpUserName,UpUserID,UpRoleId)values(?ManagerId,md5(?PassWord),?RoleId,?CreateDate,?UpdateDate,?CreateUser,?IP,?Enable,?SubAccount,?UpUserName,?UpUserID,?UpRoleId)";
		private const string SQL_UPDATE="update manager set ManagerId=?ManagerId,PassWord=?PassWord,RoleId=?RoleId,CreateDate=?CreateDate,UpdateDate=?UpdateDate,CreateUser=?CreateUser,IP=?IP,Enable=?Enable,SubAccount=?SubAccount,UpUserName=?UpUserName,UpUserID=?UpUserID,UpRoleId=?UpRoleId where ID = ?ID";
		private const string SQL_SELECTBYPK="select * from manager  where manager.ID = ?ID";
		private const string SQL_SELECTALL="select ID,ManagerId,PassWord,RoleId,CreateDate,UpdateDate,CreateUser,IP,Enable,SubAccount,UpUserName,UpUserID,UpRoleId from manager ";
		private const string SQL_DELETEBYPK="delete  from manager  where manager.ID = ?ID";

        private const string SQL_BYLOGIN = SQL_SELECTALL + " where ManagerId=?ManagerId and password=md5(?password)";
        private const string SQL_MANAGERROLE = "select a.*,b.roleName from manager a,role b where a.RoleId=b.Id order by a.ID";
        private const string SQL_UPDATEPASSWORD = "update manager set PassWord=md5(?PassWord) where ID=?ID";
        private const string SQL_SELECTBYROLEID = "select a.*,b.roleName from manager a,role b where a.RoleId=b.Id and a.RoleId=?RoleId  order by a.ID";

        /// <summary>
        /// 根据用户帐号返回数据
        /// </summary>
        /// <param name="managerId"></param>
        /// <returns></returns>
        public Manager GetManagerByManagerId(string managerId)
        {
            string sqlStr = "select * from manager where ManagerId=?ManagerId";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?ManagerId",managerId)
            };
            return MySqlModelHelper<Manager>.GetSingleObjectBySql(sqlStr, param);
        }

        /// <summary>
        /// 用过登录名称获得登录对象
        /// Programmer：liuxbang
        /// time：2010-8-27 23：24
        /// </summary>
        /// <param name="managerId"></param>
        /// <returns></returns>
        public Manager GetManagerByManagerId(string managerId,string password)
        {
            MySqlParameter[] para = new MySqlParameter[] { 
                new MySqlParameter("?ManagerId", MySqlDbType.VarChar,30),
                new MySqlParameter("?password",MySqlDbType.VarChar,32)
            };
            para[0].Value = managerId;
            para[1].Value = password;
            return MySqlModelHelper<Manager>.GetSingleObjectBySql(SQL_BYLOGIN, para);
        }

        /// <summary>
        /// 返回所有数据（MySqlDataReader）
        /// By xzz
        /// time:2010-8-31 22:40
        /// </summary>
        /// <returns></returns>
        public MySqlDataReader GetManagers()
        {
            return MySqlHelper.ExecuteReader(SQL_MANAGERROLE, null);
        }
        
        /// <summary>
        /// 修改管理员密码
        /// By xzz
        /// time:2010-9-3
        /// </summary>
        /// <param name="passWord"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool MdfPassWord(string passWord, int ID)
        {
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?PassWord",passWord),
                new MySqlParameter("?ID",ID)
            };

            return MySqlHelper.ExecuteNonQuery(SQL_UPDATEPASSWORD, param) > 0;
        }

        public MySqlDataReader GetManagetsByRoleId(int roleId)
        {
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?RoleId",roleId)
            };
            return MySqlHelper.ExecuteReader(SQL_SELECTBYROLEID, param);
        }

		#region 常用方法
		///<summary>		
		///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-9-7 18:34:31		
		///</summary>		
		public Boolean AddManager(Manager manager)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ManagerId",manager.ManagerId),
				 new MySqlParameter("?PassWord",manager.PassWord),
				 new MySqlParameter("?RoleId",manager.RoleId),
				 new MySqlParameter("?CreateDate",manager.CreateDate),
				 new MySqlParameter("?UpdateDate",manager.UpdateDate),
				 new MySqlParameter("?CreateUser",manager.CreateUser),
				 new MySqlParameter("?IP",manager.IP),
				 new MySqlParameter("?Enable",manager.Enable),
				 new MySqlParameter("?SubAccount",manager.SubAccount),
				 new MySqlParameter("?UpUserName",manager.UpUserName),
				 new MySqlParameter("?UpUserID",manager.UpUserID),
				 new MySqlParameter("?UpRoleId",manager.UpRoleId)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_INSERT,param)>0;
		}
		
		///<summary>		
		///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-9-7 18:34:31		
		///</summary>		
		public Boolean UpdateManager(Manager manager)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ManagerId",manager.ManagerId),
				 new MySqlParameter("?PassWord",manager.PassWord),
				 new MySqlParameter("?RoleId",manager.RoleId),
				 new MySqlParameter("?CreateDate",manager.CreateDate),
				 new MySqlParameter("?UpdateDate",manager.UpdateDate),
				 new MySqlParameter("?CreateUser",manager.CreateUser),
				 new MySqlParameter("?IP",manager.IP),
				 new MySqlParameter("?Enable",manager.Enable),
				 new MySqlParameter("?SubAccount",manager.SubAccount),
				 new MySqlParameter("?UpUserName",manager.UpUserName),
				 new MySqlParameter("?UpUserID",manager.UpUserID),
				 new MySqlParameter("?UpRoleId",manager.UpRoleId),
				 new MySqlParameter("?ID",manager.ID)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_UPDATE,param)>0;
		}
		
		///<summary>		
		///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
		///生成时间：2010-9-7 18:34:31		
		///</summary>		
		public Boolean DeleteManagerByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};
			return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK,param)>0;
		}
		
		///<summary>		
		///根据ID得到相应的实体类对象		
		///生成时间：2010-9-7 18:34:31		
		///</summary>		
		public Manager GetManagerByPK(object id)
		{
			 MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?ID",id)
			};

			return MySqlModelHelper<Manager>.GetSingleObjectBySql(SQL_SELECTBYPK,param);
		}

		///<summary>		
		///获得所有数据，返回泛型集合		
		///生成时间：2010-9-7 18:34:31		
		///</summary>		
		public IList<Manager> GetMutilILManager()
		{
			return MySqlModelHelper<Manager>.GetObjectsBySql(SQL_SELECTALL, null);
		}

		///<summary>		
		///获得所有数据，返回DataTable		
		///生成时间：2010-9-7 18:34:31		
		///</summary>		
		public DataTable GetMutilDTManager()
		{
			 return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
		}

		#endregion
    }
}
