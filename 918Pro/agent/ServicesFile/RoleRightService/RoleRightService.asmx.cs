using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using Model;
using DAL;
using Newtonsoft.Json;
using System.Data;

namespace agent.ServicesFile.RoleRightService
{
    /// <summary>
    /// RoleRightService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class RoleRightService : System.Web.Services.WebService
    {

        /// <summary>
        /// 返回代理部门角色
        /// By xzz 2010-11-26
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetAgentRoleByAgentID()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            RoleManager roleManager = new RoleManager();
            agent.PageBase pageBase = new agent.PageBase();
            return ObjectToJson.ObjectListToJson<Role>(roleManager.GetAgentRoleByAgentID(pageBase.agentRoleID, pageBase.agentUserName));
        }

        /// <summary>
        /// 添加代理部门角色
        /// </summary>
        /// <param name="roleName">部门名称</param>
        /// <param name="reMark">备注</param>
        /// <param name="rootId">代理ID</param>
        /// <param name="agentId">代理名称</param>
        /// <param name="CreateUser">创建人</param>
        /// <returns></returns>
        [WebMethod(true)]
        public string AddAgentRole(string roleName, string reMark)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            PageBase pageBase = new PageBase();
            RoleManager roleManager = new RoleManager();
            string reStr = roleManager.AddAgentRole(roleName, reMark, pageBase.agentRoleID, pageBase.agentUserName, pageBase.CurrentManager.UserName);
            return reStr;
        }

        /// <summary>
        /// 返回系统管理员角色
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string GetRoleById(int Id)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            RoleManager roleManager = new RoleManager();
            return ObjectToJson.ObjectListToJson<Role>(roleManager.GetRoleById(Id));
        }

        /// <summary>
        /// 根据代理ID返回角色
        /// By xzz
        /// time:2010-9-1
        /// </summary>
        /// <param name="agentId">代理ID</param>
        /// <returns></returns>
        [WebMethod(true)]
        public string GetRoles(string agentId)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            RoleManager roleManager = new RoleManager();
            string jsontxt = roleManager.GetRoles(agentId);
            return jsontxt;
        }

        /// <summary>
        /// 修改角色状态
        /// By xzz
        /// 2010-9-5
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="Id">角色ID</param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool ChangeStatus(string status, int Id)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            Model.Role role = RoleManager.GetRoleByPK(Id);
            role.Status = role.Status == "1" ? "0" : "1";

            return RoleManager.UpdateRole(role);
        }

        /// <summary>
        /// 修改角色
        /// By xzz
        /// Time:2010-9-5
        /// </summary>
        /// <param name="roleName">角色名称</param>
        /// <param name="remark">备注</param>
        /// <param name="Id">角色Id</param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool UpdateRole(string roleName, string remark, int Id)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            AgentManager agentManager = new AgentManager();
            Role role = RoleManager.GetRoleByPK(Id);
            role.RoleName = roleName;
            role.Remark = remark;

            if (RoleManager.UpdateRole(role))
            {
                agentManager.UpdateSubAccountRoleName(roleName, Id);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除角色
        /// By xzz
        /// Time:2010-9-5
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string DeleteRole(int Id)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            AgentManager agentManager = new AgentManager();
            IList<Agent> agents = agentManager.GetSubAccountByRoleID(Id);
            if (agents.Count > 0)
            {
                return "角色已开会员，不能够删除";
            }
            else
            {
                if (RoleManager.DeleteRoleByPK(Id))
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            
        }

        [WebMethod(true)]
        public string InsertRole(string roleName, string remark)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            Role role = new Role();
            role.RoleName = roleName;
            role.Remark = remark;
            role.Status = "1";
            role.RootId = 1;
            role.AgentId = "admin";
            role.CreateDate = DateTime.Now;
            role.IP = Util.RequestHelper.GetIP();

            RoleManager roleManager = new RoleManager();
            int insertId = roleManager.InsertRole(role);
            role.Id = insertId;

            return DAL.ObjectToJson.ObjectsToJson(role);
        }

        /// <summary>
        /// 添加模块操作
        /// </summary>
        /// <param name="Operate_text">操作说明</param>
        /// <returns></returns>
        [WebMethod(true)]
        public string AddModuleOperate(string Operate_text, string status)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            try
            {
                Sys_module_operate operate = new Sys_module_operate();
                operate.Operate_text = Operate_text;
                operate.Status = status;
                int operateID = Sys_module_operateManager.InsertSys_module_operate(operate);
                operate.OperateID = operateID;

                return DAL.ObjectToJson.ObjectsToJson(operate);
            }
            catch(Exception)
            {
                return "none";
            }
        }

        /// <summary>
        /// 修改模块操作
        /// </summary>
        /// <param name="Operate_text">操作说明</param>
        /// <param name="OperateID">ID</param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool UpdateModuleOperate(string Operate_text, int OperateID)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            Sys_module_operate operate = Sys_module_operateManager.GetSys_module_operateByPK(OperateID);
            operate.Operate_text = Operate_text;
            return Sys_module_operateManager.UpdateSys_module_operate(operate);
        }

        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="OperateID">模块操作ID</param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool UpdateModuleOperateStatus(int OperateID)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            Sys_module_operate operate = Sys_module_operateManager.GetSys_module_operateByPK(OperateID);
            operate.Status = operate.Status == "1" ? "0" : "1";
            return Sys_module_operateManager.UpdateSys_module_operate(operate);
        }

        Sys_moduleService sysModuleService = new Sys_moduleService();
        Sys_module_operateService sysModuleOperateService = new Sys_module_operateService();
        Sys_module_rightService sysModuleRightService = new Sys_module_rightService();

        [WebMethod(true)]
        public string GetSysModules()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            IList<Sys_module> list = sysModuleService.GetSysModules();
            if (list == null || list.Count == 0)
            {
                return "none";
            }
            else
            {
                string str = JsonConvert.SerializeObject(list);
                return str;
            }
        }
        [WebMethod(true)]
        public String UpdateStatus(String status, String moduleCode)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            status = status.Trim() == "启用" ? "0" : "1";
            if (sysModuleService.UpdateStatus(status, moduleCode))
            {
                if (moduleCode.Length == 3)
                {
                    return "all";
                }
                else
                {
                    return "single";
                }
            }
            else
            {
                return "none";
            }
        }
        [WebMethod(true)]
        public String GetModuleRightByCode(String code)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            IList<Sys_module_right> list = sysModuleRightService.GetModuleRightByCode(code);
            if (list == null || list.Count == 0)
            {
                return "none";
            }
            else
            {
                return JsonConvert.SerializeObject(list);
            }
        }

        [WebMethod(true)]
        public string GetModuleRightOperateByCode(string code)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            DataTable dt = Sys_module_rightManager.GetModuleRightOperateByCode(code);
            if (dt.Rows.Count == 0)
            {
                return "none";
            }
            else
            {
                return ObjectToJson.DataTableToJson(dt);
            }
            
        }

        [WebMethod(true)]
        public String GetModuleOperate()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            IList<Sys_module_operate> list = sysModuleOperateService.GetModuleOperate(false);
            if (list == null || list.Count == 0)
            {
                return "none";
            }
            else
            {
                return JsonConvert.SerializeObject(list);
            }
        }
        [WebMethod(true)]
        public String AddModule(String moduleParent, String text, String url, String tip, String target, String status, String operate)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            Sys_module sysModule = new Sys_module();
            sysModule.Module_parent_code = moduleParent;
            sysModule.Module_url = url;
            sysModule.Module_type = moduleParent == "ROOT_MENU" ? "Folder" : "Document";
            sysModule.Module_text = text;
            sysModule.Module_tip = tip;
            sysModule.Status = status;
            sysModule.Module_target = target;
            sysModule = sysModuleService.AddModule(sysModule, operate);
            if (sysModule == null)
            {
                return "none";
            }
            else
            {
                return JsonConvert.SerializeObject(sysModule);
            }
        }
        [WebMethod(true)]
        public Boolean UpdateParentModule(String text, String tip, String moduleCode)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            Sys_module sysModule = new Sys_module();
            sysModule.Module_code = moduleCode;
            sysModule.Module_text = text;
            sysModule.Module_tip = tip;
            return sysModuleService.UpdateParentModule(sysModule);
        }
        [WebMethod(true)]
        public Boolean UpdateChildModule(String text, String url, String tip, Int32 target, String moduleCode, String operate)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            Sys_module sysModule = new Sys_module();
            sysModule.Module_code = moduleCode;
            sysModule.Module_text = text;
            sysModule.Module_tip = tip;
            sysModule.Module_url = url;

            return sysModuleService.UpdateChildModule(sysModule, target, operate);
        }


        [WebMethod(true)]
        public String GetRootModule()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            IList<Sys_module> list = sysModuleService.GetRootModule();
            if (list == null || list.Count == 0)
            {
                return "none";
            }
            else
            {
                return JsonConvert.SerializeObject(list);
            }
        }
    }
}
