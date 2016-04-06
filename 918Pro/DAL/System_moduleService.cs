using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Model;

namespace DAL
{
    public class System_moduleService
    {
        private const string SQL_INSERT = "insert into yafa.system_module (Module_parent_code,Module_text,Module_url,Module_target,status,sorts,BetGamesID,Module_type,Module_tip)values(?Module_parent_code,?Module_text,?Module_url,?Module_target,?status,?sorts,?BetGamesID,?Module_type,?Module_tip)";
        private const string SQL_UPDATE = "update yafa.system_module set Module_parent_code=?Module_parent_code,Module_text=?Module_text,Module_url=?Module_url,Module_target=?Module_target,status=?status,sorts=?sorts,BetGamesID=?BetGamesID,Module_type=?Module_type,Module_tip=?Module_tip where Module_code = ?Module_code";
        private const string SQL_SELECTBYPK = "select Module_code from yafa.system_module  where system_module.Module_code = ?Module_code";
        private const string SQL_SELECTALL = "select Module_code,Module_parent_code,Module_text,Module_url,Module_target,status,sorts,BetGamesID,Module_type,Module_tip from yafa.system_module ";
        private const string SQL_DELETEBYPK = "delete  from yafa.system_module  where system_module.Module_code = ?Module_code";

        private const String SELECT_MODULE_ALL = "select m.Module_code,m.Module_parent_code,m.Module_type,m.Module_text,m.Module_url,m.Module_target,m.Module_tip,m.status from system_module m  ";

        private const String UPDATE_MODULE_STATUS = "update system_module set status=?status where Module_code like ?Module_code ";

        private const String SELECT_MODULE_TYPE_ALL = SELECT_MODULE_ALL + " where m.Module_type='Folder' and m.status='1' " + ORDERBY;

        private const String ORDERBY = "order by m.Module_code ";

        private const String SELECT_LASTMODULE_BYPARENTMODULE = "select m.Module_code from system_module m where m.Module_parent_code=?moduleParentCode " + ORDERBY + " desc limit 1";

        private const String INSERT_MODULE = "insert into system_module (Module_code,Module_parent_code,Module_type,Module_text,Module_url,Module_target,Module_tip,status) values(?ModuleCode,?ModuleParentCode,?ModuleType,?ModuleText,?ModuleUrl,?ModuleTarget,?ModuleTip,?status);";

        private const String UPDATE_PARENT_MODULE = "update system_module set module_text=?moduleText,module_tip=?moduleTip where module_code=?moduleCode";

        private const String UPDATE_CHILD_MODULE = "update system_module set module_text=?moduleText,module_tip=?moduleTip,module_url=?moduleUrl,module_target=?moduleTarget where module_code=?moduleCode";

        private const String SELECT_MODULE_STATUS = SELECT_MODULE_ALL + " where m.status=?status order by m.Module_code";

        private const String SELECT_BYPID = "select m.* from system_module m where m.Module_parent_code=?moduleParentCode";

        private System_module_rightService sysModuleRightService = new System_module_rightService();

        public Boolean UpdateChildModule(System_module sysModule, Int32 target, String operate)
        {
            Boolean con = false;
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?moduleText",sysModule.Module_text),
                new MySqlParameter("?moduleTip",sysModule.Module_tip),
                new MySqlParameter("?moduleUrl",sysModule.Module_url),
                new MySqlParameter("?moduleTarget",target),
                new MySqlParameter("?moduleCode",sysModule.Module_code)
            };

            con = MySqlHelper.ExecuteNonQuery(UPDATE_CHILD_MODULE, param) > 0;

            if (con)
            {
                if (operate != "")
                {
                    //删除不存在的模块操作
                    sysModuleRightService.DeleteByModuleCodeAndOperate(sysModule.Module_code, operate);

                    String[] operateStr = operate.Split(',');
                    for (int i = 0; i < operateStr.Length; i++)
                    {
                        if (operateStr[i] == "1") continue;

                        String status = sysModuleRightService.GetModuleRightByCodeAndOperateId(sysModule.Module_code, operateStr[i]);
                        if (status == String.Empty) //不存在这条记录
                        {
                            sysModuleRightService.AddModuleRight(sysModule.Module_code, Convert.ToInt32(operateStr[i]), sysModule.Module_url);
                        }
                        else
                        {
                            String num = status == "1" ? "1" : "0";
                            sysModuleRightService.UpdateStatusByCode(sysModule.Module_code, num, Convert.ToInt32(operateStr[i]));
                        }
                    }
                }

            }
            return con;
        }

        /// <summary>
        /// Programmer:liuxubang
        /// time:7-18 22:10
        /// 更新父模块的信息
        /// </summary>
        /// <param name="sysModule"></param>
        /// <returns></returns>
        public Boolean UpdateParentModule(System_module sysModule)
        {
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?moduleText",sysModule.Module_text),
                new MySqlParameter("?moduleTip",sysModule.Module_tip),
                new MySqlParameter("?moduleCode",sysModule.Module_code)
            };
            return MySqlHelper.ExecuteNonQuery(UPDATE_PARENT_MODULE, param) > 0;
        }
        /// <summary>
        /// Programmer:liuxubang
        /// time:7-16 22:20
        /// 获得所有父模块
        /// </summary>
        /// <returns></returns>
        public IList<System_module> GetRootModule()
        {
            return GetAllModuleBySql(SELECT_MODULE_TYPE_ALL, null);
        }

        public DataTable GetRootModuleTable()
        {
            return MySqlHelper.ExecuteDataTable(SELECT_MODULE_TYPE_ALL, null);
        }

        /// <summary>
        /// Programmer:liuxubang
        /// time:7-16 15:05
        /// </summary>
        /// <param name="sysModule"></param>
        /// <returns></returns>
        public System_module AddModule(System_module sysModule, String operate)
        {
            Boolean con = false;
            String lastModule = GetLastModule(sysModule.Module_parent_code);
            String codeModule = String.Empty; //产生一个新的Module_code
            if (lastModule != "" && lastModule != null)//表示有父模块
            {
                Int32 codeNum = Convert.ToInt32(lastModule.Remove(0, 1)) + 1;

                if (sysModule.Module_parent_code == "ROOT_MENU")  //添加一个大的模块
                {
                    if (codeNum.ToString().Length == 1)
                    {
                        codeModule = "L0" + codeNum;
                    }
                    else
                    {
                        codeModule = "L" + codeNum;
                    }
                }
                else  //添加一个子模块
                {

                    codeModule = sysModule.Module_parent_code + codeNum.ToString().Substring(codeNum.ToString().Length - 2);
                }
            }
            else
            {
                if (sysModule.Module_parent_code == "ROOT_MENU")  //添加一个大的模块
                {
                    codeModule = "L01";
                }
                else  //添加一个子模块
                {

                    codeModule = sysModule.Module_parent_code + "01";
                }
            }
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?ModuleCode",codeModule),
                new MySqlParameter("?ModuleParentCode",sysModule.Module_parent_code),
                new MySqlParameter("?ModuleType",sysModule.Module_type),
                new MySqlParameter("?ModuleText",sysModule.Module_text),
                new MySqlParameter("?ModuleUrl",sysModule.Module_url),
                new MySqlParameter("?ModuleTarget",sysModule.Module_target),
                new MySqlParameter("?ModuleTip",sysModule.Module_tip),
                new MySqlParameter("?status",sysModule.Status)
            };
            con = MySqlHelper.ExecuteNonQuery(INSERT_MODULE, param) > 0;
            if (con)
            {
                if (operate != "" && sysModule.Module_parent_code != "ROOT_MENU")
                {
                    String[] OperateArr = operate.Split(',');
                    for (int i = 0; i < OperateArr.Length; i++)
                    {
                        new System_module_rightService().AddModuleRight(codeModule, int.Parse(OperateArr[i]), sysModule.Module_url);
                    }
                }
                else
                {
                    new System_module_rightService().AddModuleRight(codeModule, 0, "");
                }
                sysModule.Module_code = codeModule;
                return sysModule;

            }
            else
            { return null; }

        }
        /// <summary>
        /// Programmer:liuxubang
        /// time:7-17 14:42
        /// 通过传入的父模块，得到相应子模块的最后一个模块标识
        /// </summary>
        /// <returns></returns>
        public String GetLastModule(String parentModule)
        {
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?moduleParentCode",parentModule)
            };
            object obj = MySqlHelper.ExecuteScalar(SELECT_LASTMODULE_BYPARENTMODULE, param);
            if (obj == null)
            {
                return String.Empty;
            }
            else
            {
                return obj.ToString();
            }
        }
        /// <summary>
        /// programmer:liuxubang
        /// time:7-16 22:20
        /// 根据SQL语句获得相应的模块信息
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        private IList<System_module> GetAllModuleBySql(String sqlStr, params MySqlParameter[] param)
        {
            IList<System_module> list = new List<System_module>();
            using (MySqlDataReader reader = MySqlHelper.ExecuteReader(sqlStr, param))
            {
                while (reader.Read())
                {
                    //System_module sysModule = new System_module(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetChar(5), reader.GetString(6), reader.GetChar(7));
                    System_module sysModule = new System_module();
                    sysModule.Module_code = reader.GetString("Module_code");
                    sysModule.Module_parent_code = reader.GetString("Module_parent_code");
                    sysModule.Module_type = reader.GetString("Module_type");
                    sysModule.Module_text = reader.GetString("Module_text");
                    sysModule.Module_url = reader.GetString("Module_url");
                    sysModule.Module_target = reader.GetString("Module_target");
                    sysModule.Module_tip = reader.GetString("Module_tip");
                    sysModule.Status = reader.GetString("Status");

                    list.Add(sysModule);
                }
                reader.Close();
            }
            return list;
        }
        /// <summary>
        /// Programmer:liuxubang
        /// time:7-16 20:09
        /// 更新状态
        /// </summary>
        /// <param name="status"></param>
        /// <param name="moduleCode"></param>
        /// <returns></returns>
        public Boolean UpdateStatus(String status, String moduleCode)
        {
            moduleCode = moduleCode + "%";
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("?status",status),
                new MySqlParameter("?Module_code",moduleCode)
            };
            return MySqlHelper.ExecuteNonQuery(UPDATE_MODULE_STATUS, param) > 0;
        }

        /// <summary>
        /// Programmer:liuxubang
        /// time 7-16 0:08
        /// 获得所有的模块信息
        /// </summary>
        /// <returns>泛型集合</returns>
        public IList<System_module> GetSysModules()
        {
            return GetAllModuleBySql(SELECT_MODULE_ALL + ORDERBY, null);
        }

        public IList<System_module> GetSysModuleByStatus(string status)
        {
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?status",status)
            };

            return GetAllModuleBySql(SELECT_MODULE_STATUS, param);
        }

        public DataTable GetSysModuleByPid(string moduleParentCode)
        {
            MySqlParameter[] param = new MySqlParameter[]{
                new MySqlParameter("?moduleParentCode",moduleParentCode)
            };

            return MySqlHelper.ExecuteDataTable(SELECT_BYPID, param);
        }

        #region 常用方法
        ///<summary>		
        ///添加方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-9-18 13:49:34		
        ///</summary>		
        public Boolean AddSystem_module(System_module system_module)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?Module_parent_code",system_module.Module_parent_code),
				 new MySqlParameter("?Module_text",system_module.Module_text),
				 new MySqlParameter("?Module_url",system_module.Module_url),
				 new MySqlParameter("?Module_target",system_module.Module_target),
				 new MySqlParameter("?status",system_module.Status),
				 new MySqlParameter("?sorts",system_module.Sorts),
				 new MySqlParameter("?BetGamesID",system_module.BetGamesID),
				 new MySqlParameter("?Module_type",system_module.Module_type),
				 new MySqlParameter("?Module_tip",system_module.Module_tip)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_INSERT, param) > 0;
        }

        ///<summary>		
        ///修改方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-9-18 13:49:34		
        ///</summary>		
        public Boolean UpdateSystem_module(System_module system_module)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?Module_parent_code",system_module.Module_parent_code),
				 new MySqlParameter("?Module_text",system_module.Module_text),
				 new MySqlParameter("?Module_url",system_module.Module_url),
				 new MySqlParameter("?Module_target",system_module.Module_target),
				 new MySqlParameter("?status",system_module.Status),
				 new MySqlParameter("?sorts",system_module.Sorts),
				 new MySqlParameter("?BetGamesID",system_module.BetGamesID),
				 new MySqlParameter("?Module_type",system_module.Module_type),
				 new MySqlParameter("?Module_tip",system_module.Module_tip),
				 new MySqlParameter("?Module_code",system_module.Module_code)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_UPDATE, param) > 0;
        }

        ///<summary>		
        ///删除方法，返回Boolean类型，为true表示操作成功，否则操作失败		
        ///生成时间：2010-9-18 13:49:34		
        ///</summary>		
        public Boolean DeleteSystem_moduleByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?Module_code",id)
			};
            return MySqlHelper.ExecuteNonQuery(SQL_DELETEBYPK, param) > 0;
        }

        ///<summary>		
        ///根据ID得到相应的实体类对象		
        ///生成时间：2010-9-18 13:49:34		
        ///</summary>		
        public System_module GetSystem_moduleByPK(object id)
        {
            MySqlParameter[] param = new MySqlParameter[]{
				 new MySqlParameter("?Module_code",id)
			};

            return MySqlModelHelper<System_module>.GetSingleObjectBySql(SQL_SELECTBYPK, param);
        }

        ///<summary>		
        ///获得所有数据，返回泛型集合		
        ///生成时间：2010-9-18 13:49:34		
        ///</summary>		
        public IList<System_module> GetMutilILSystem_module()
        {
            return MySqlModelHelper<System_module>.GetObjectsBySql(SQL_SELECTALL, null);
        }

        ///<summary>		
        ///获得所有数据，返回DataTable		
        ///生成时间：2010-9-18 13:49:34		
        ///</summary>		
        public DataTable GetMutilDTSystem_module()
        {
            return MySqlHelper.ExecuteDataTable(SQL_SELECTALL, null);
        }

        #endregion
    }
}
