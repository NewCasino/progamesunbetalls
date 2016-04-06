using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;

namespace DAL
{
    public class System_module_operateService
    {
        private const string SQL_INSERT = "insert into system_module_operate (Operate_text,status)values(?Operate_text,?status)";
        private const string SQL_UPDATE = "update system_module_operate set Operate_text=?Operate_text,status=?status where OperateID = ?OperateID";
        private const string SQL_SELECTBYPK = "select * from system_module_operate  where system_module_operate.OperateID = ?OperateID";
        private const string SQL_SELECTALL = "select OperateID,Operate_text,status from system_module_operate ";
        private const string SQL_DELETEBYPK = "delete  from system_module_operate  where system_module_operate.OperateID = ?OperateID";

        private const string SQL_INSERTRETURNID = "insert into system_module_operate (Operate_text,status)values(?Operate_text,?status);SELECT LAST_INSERT_ID()";

        private const string SQL_ADD = "insert into system_module_operate(Operate_text,status) values(@Operate_text,@status)";
        private const string SQL_UPDATE_old = "Update system_module_operate set Operate_text=@Operate_text where OperateID=@OperateID";
        private const string SQL_SELECT = "select OperateID,Operate_text,status from system_module_operate order by OperateID";
        private const string SQL_SELECT_BYID = "select OperateID,Operate_text,status from system_module_operate where OperateID=@OperateID order by OperateID";
        private const string SQL_UPDATE_STATUS = "Update system_module_operate set status=@status where OperateID=@OperateID";

        public int InsertSystem_module_operate(System_module_operate system_module_operate)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?Operate_text",system_module_operate.Operate_text),
				 new MySqlParameter("?status",system_module_operate.Status)
			};
            return Convert.ToInt32(MySqlHelper.ExecuteScalar(SQL_INSERTRETURNID, param));
        }

        public bool AddModuleOperate(string Operate_text, string status)
        {
            MySql.Data.MySqlClient.MySqlParameter[] param = new MySql.Data.MySqlClient.MySqlParameter[]{
                new MySql.Data.MySqlClient.MySqlParameter("@Operate_text",Operate_text),
                new MySql.Data.MySqlClient.MySqlParameter("@status",status)
            };
            return MySqlHelper.ExecuteNonQuery(SQL_ADD, param) == 1;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="Operate_text">操作说明</param>
        /// <param name="OperateID">ID</param>
        /// <returns></returns>
        public bool UpdateModuleOperate(string Operate_text, int OperateID)
        {
            MySql.Data.MySqlClient.MySqlParameter[] param = new MySql.Data.MySqlClient.MySqlParameter[]{
                new MySql.Data.MySqlClient.MySqlParameter("@Operate_text",Operate_text),
                new MySql.Data.MySqlClient.MySqlParameter("@OperateID",OperateID)
            };
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE_old, param) == 1;
        }

        public bool UpdateModuleOperateStatus(string status, int OperateID)
        {
            MySql.Data.MySqlClient.MySqlParameter[] param = new MySql.Data.MySqlClient.MySqlParameter[]{
                new MySql.Data.MySqlClient.MySqlParameter("@status",status),
                new MySql.Data.MySqlClient.MySqlParameter("@OperateID",OperateID)
            };
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE_STATUS, param) == 1;
        }

        /// <summary>
        /// 返回所有记录
        /// </summary>
        /// <returns>泛型集合</returns>
        public IList<System_module_operate> GetModuleOperate(Boolean IsStatus)
        {
            String sqlStr = String.Empty;
            if (!IsStatus)
            {
                sqlStr = SQL_SELECT + " where status=1";
            }
            return GetModuleOperateBySql(SQL_SELECT, null);
        }

        public System_module_operate GetModuleOperateByOperateId(int operateId)
        {
            IList<System_module_operate> list = GetModuleOperateById(operateId);
            if (list != null)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }

        public IList<System_module_operate> GetModuleOperateById(int OperateID)
        {
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("@OperateID",OperateID)
            };

            return GetModuleOperateBySql(SQL_SELECT_BYID, param);
        }

        public IList<System_module_operate> GetModuleOperateBySql(string sql, params MySqlParameter[] param)
        {
            IList<System_module_operate> list = new List<System_module_operate>();

            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(sql, param))
            {
                while (reader.Read())
                {
                    //System_module_operate systemmoduleOperate = new System_module_operate(reader.GetInt32("OperateID"), reader.GetString("Operate_text"), reader.GetChar("Status"));
                    System_module_operate systemmoduleOperate = new System_module_operate();
                    systemmoduleOperate.OperateID = reader.GetInt32("OperateID");
                    systemmoduleOperate.Operate_text = reader.GetString("Operate_text");
                    systemmoduleOperate.Status = reader.GetString("status");

                    list.Add(systemmoduleOperate);
                }
                reader.Close();
            }
            return list;
        }

        public bool Updatestatus(int OperateID)
        {
            IList<System_module_operate> smos = GetModuleOperateById(OperateID);
            bool reval = false;

            if (smos.Count > 0)
            {
                System_module_operate smo = smos[0];
                if (smo.Status.ToString() == "1")
                {
                    reval = UpdateModuleOperateStatus("0", OperateID);
                }
                else
                {
                    reval = UpdateModuleOperateStatus("1", OperateID);
                }
            }

            return reval;
        }

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-8-27 22:00:49		
        ///</summary>		
        public Boolean AddSystem_module_operate(System_module_operate system_module_operate)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?Operate_text",system_module_operate.Operate_text),
				 new MySqlParameter("?status",system_module_operate.Status)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-8-27 22:00:49		
        ///</summary>		
        public Boolean UpdateSystem_module_operate(System_module_operate system_module_operate)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?Operate_text",system_module_operate.Operate_text),
				 new MySqlParameter("?status",system_module_operate.Status),
				 new MySqlParameter("?OperateID",system_module_operate.OperateID)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-8-27 22:00:49		
        ///</summary>		
        public Boolean DeleteSystem_module_operateByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?OperateID",id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2010-8-27 22:00:49		
        ///</summary>		
        public System_module_operate GetSystem_module_operateByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?OperateID",id)
			};

            return MySqlModelHelper<System_module_operate>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2010-8-27 22:00:49		
        ///</summary>		
        public IList<System_module_operate> GetMutilILSystem_module_operate()
        {
            return MySqlModelHelper<System_module_operate>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2010-8-27 22:00:49		
        ///</summary>		
        public DataTable GetMutilDTSystem_module_operate()
        {
            return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion
    }
}
