using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;
namespace DAL
{
    public class System_module_rightService
    {
        private const string SQL_INSERT = "insert into system_module_right (Module_code,OperateID,status,right_page)values(?Module_code,?OperateID,?status,?right_page)";
        private const string SQL_UPDATE = "update system_module_right set Module_code=?Module_code,OperateID=?OperateID,status=?status,right_page=?right_page where Module_right_id = ?Module_right_id";
        private const string SQL_SELECTBYPK = "select Module_right_id from system_module_right  where system_module_right.Module_right_id = ?Module_right_id";
        private const string SQL_SELECTALL = "select Module_right_id,Module_code,OperateID,status,right_page from system_module_right ";
        private const string SQL_DELETEBYPK = "delete  from system_module_right  where system_module_right.Module_right_id = ?Module_right_id";

        private const string SQL_SELECTBYMODULECODE = "select Module_right_id,Module_code,OperateID,status,right_page from system_module_right where Module_code=?Module_code ";
        private const string SELECT_BYMODULECOD = "select a.*,b.Operate_text,b.status as OperateStatus from system_module_right a,system_module_operate b where a.OperateID=b.OperateID and a.Module_code=?Module_code and a.status='1' order by a.Module_right_id";

        private const String SELECT_MODULERIGHT = "select r.Module_right_id,r.module_code,r.status,r.OperateID,r.right_page from system_module_right r ";

        private const String ORDERBY = " order by r.Module_right_id ";

        private const String INSERT_MODULERIGHT = "insert into system_module_right(module_code,status,OperateID,right_page) values(?moduelCode,?status,?operateID,?rightPage)";

        private const String SELECT_BYCODE = SELECT_MODULERIGHT + " where r.status='1' and r.Module_code=?moduleCode and length(?moduleCode)=5";

        private const String SELECT_MIDALL = "select * from system_module_right where Module_code in(select distinct a.Module_parent_code from system_module a,system_module_right b where a.Module_code=b.Module_code and b.Module_right_id in(@Module_right_id))";

        private const String SELECT_BYMODULEANDOPERATEID = SELECT_MODULERIGHT + " where r.module_code=?moduleCode and r.OperateID=?operateId ";

        private const String UPDATE_BYMODULECODEANDSTATUS = "Update system_module_right set status=?status where module_code=?moduleCode and operateID=?operateId";
        private const string SELECTMRANDOPERATEBYMODULECODE = "select a.*,b.Operate_text from system_module_right a,system_module_operate b where a.OperateID=b.OperateID and a.Module_code=?Module_code";

        /// <summary>
        /// 修改模块时删除不选择的功能
        /// </summary>
        /// <param name="Module_code"></param>
        /// <param name="OperateID">模块操作ID，如2,5,8</param>
        /// <returns></returns>
        public bool DeleteByModuleCodeAndOperate(string Module_code, string OperateID)
        {
            string DELETEBYOPERATE = "delete from system_module_right where Module_code=?Module_code and OperateID not in(" + OperateID + ")";
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?Module_code",Module_code)
            };
            return MySqlHelper.ExecuteNonQuery(DELETEBYOPERATE, param) > 0;
        }

        /// <summary>
        /// Programmer:liuxubang
        /// time:7-19 19:42
        /// 更新状态
        /// </summary>
        /// <param name="code"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public Boolean UpdateStatusByCode(String code, String status, Int32 operateId)
        {
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?status",status),
                new MySqlParameter("?moduleCode",code),
                new MySqlParameter("?operateId",operateId)
            };
            return MySqlHelper.ExecuteNonQuery(UPDATE_BYMODULECODEANDSTATUS, param) > 0;
        }
        /// <summary>
        /// Programmer:liuxubang
        /// time:7-19 19:19
        /// 根据模块编号和操作Id获得模块权限状态
        /// </summary>
        /// <param name="code"></param>
        /// <param name="operateId"></param>
        /// <returns>1表示启用，0表示禁用</returns>
        public String GetModuleRightByCodeAndOperateId(String code, String operateId)
        {

            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?moduleCode",code),
                new MySqlParameter("?operateId",operateId)
            };
            String con = String.Empty;
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SELECT_BYMODULEANDOPERATEID, param))
            {
                if (reader.Read())
                {
                    con = reader.GetChar("status").ToString();
                }
                reader.Close();
            }
            return con;
        }

        /// <summary>
        /// Programmer:liuxubang
        /// time:7-17 18:31
        /// 添加模块权限数据
        /// </summary>
        /// <param name="moduleCode"></param>
        /// <param name="operateId"></param>
        /// <param name="right_page"></param>
        public void AddModuleRight(String moduleCode, Int32 operateId, String right_page)
        {
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?moduelCode",moduleCode),
                new MySqlParameter("?status","1"),
                new MySqlParameter("?operateID",operateId),
                new MySqlParameter("?rightPage",right_page)
            };
            MySqlHelper.ExecuteNonQuery(INSERT_MODULERIGHT, param);
        }

        public DataTable GetModuleRightOperateByCode(string moduleCode)
        {
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?Module_code",moduleCode)
            };
            return MySqlHelper.ExecuteDataTable(SELECTMRANDOPERATEBYMODULECODE, param);
        }

        /// <summary>
        /// Programmer:liuxubang
        /// time:7-18 15:47
        /// 通过子模块的编号获得相应的权限
        /// </summary>
        /// <param name="moduleCode"></param>
        /// <returns></returns>
        public IList<System_module_right> GetModuleRightByCode(String moduleCode)
        {
            IList<System_module_right> list = new List<System_module_right>();
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?moduleCode",moduleCode)
            };
            try
            {
                using (MySqlDataReader reader = MySqlHelper.ExecuteReader(SELECT_BYCODE, param))
                {
                    while (reader.Read())
                    {
                        System_module sysModule = new System_module();

                        sysModule.Module_code = reader.GetString(1);
                        System_module_operate sysModuleOperate = new System_module_operateService().GetModuleOperateByOperateId(reader.GetInt32(3));
                        //System_module_right sysModuleRight = new System_module_right(reader.GetInt32(0), sysModule, sysModuleOperate, reader.GetChar(2), reader.GetString(4));
                        System_module_right sysModuleRight = new System_module_right();
                        sysModuleRight.Module_right_id = reader.GetInt32("Module_right_id");
                        sysModuleRight.Module_code = reader.GetString("Module_code");
                        sysModuleRight.OperateID = reader.GetInt32("OperateID");
                        sysModuleRight.Status = reader.GetString("status");
                        sysModuleRight.Right_page = reader.GetString("right_page");
                        list.Add(sysModuleRight);
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return list;


        }

        /// <summary>
        /// Programmer:xzz
        /// time:7-18 14:16
        /// 根据模块编号返回模块权限
        /// </summary>
        /// <param name="Module_code">模块编号</param>
        /// <returns></returns>
        public DataTable GetModuleRightByModuleCode(string Module_code)
        {
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?Module_code",Module_code)
            };

            return GetModuleRightBySql(SELECT_BYMODULECOD, param);
        }

        public DataTable GetModuleRightBySql(string sql, params MySqlParameter[] param)
        {
            return MySqlHelper.ExecuteDataTable(sql, param);
        }

        /// <summary>
        /// 根据多个模块权限ID返回数据
        /// </summary>
        /// <param name="Module_right_ids">多个模块权限ID，如1,2,3</param>
        /// <returns></returns>
        public DataTable GetModuleRightByMidAll(string Module_right_ids)
        {
            //MySqlParameter[] param = new MySqlParameter[]{
            //    new MySqlParameter("@Module_right_id",Module_right_ids)
            //};

            string sql = "select * from system_module_right where Module_code in(select distinct a.Module_parent_code from system_module a,system_module_right b where a.Module_code=b.Module_code and b.Module_right_id in(" + Module_right_ids + "))";

            return GetModuleRightBySql(sql, null);
        }

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-8-27 22:00:49		
        ///</summary>		
        public Boolean AddSystem_module_right(System_module_right system_module_right)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?Module_code",system_module_right.Module_code),
				 new MySqlParameter("?OperateID",system_module_right.OperateID),
				 new MySqlParameter("?status",system_module_right.Status),
				 new MySqlParameter("?right_page",system_module_right.Right_page)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-8-27 22:00:49		
        ///</summary>		
        public Boolean UpdateSystem_module_right(System_module_right system_module_right)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?Module_code",system_module_right.Module_code),
				 new MySqlParameter("?OperateID",system_module_right.OperateID),
				 new MySqlParameter("?status",system_module_right.Status),
				 new MySqlParameter("?right_page",system_module_right.Right_page),
				 new MySqlParameter("?Module_right_id",system_module_right.Module_right_id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-8-27 22:00:49		
        ///</summary>		
        public Boolean DeleteSystem_module_rightByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?Module_right_id",id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2010-8-27 22:00:49		
        ///</summary>		
        public System_module_right GetSystem_module_rightByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?Module_right_id",id)
			};

            return MySqlModelHelper<System_module_right>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2010-8-27 22:00:49		
        ///</summary>		
        public IList<System_module_right> GetMutilILSystem_module_right()
        {
            return MySqlModelHelper<System_module_right>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2010-8-27 22:00:49		
        ///</summary>		
        public DataTable GetMutilDTSystem_module_right()
        {
            return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion
    }
}
