using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;
using DAL;

namespace Admin.RoleRight.AssignPermission
{
    public partial class SetPermission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string bitStr = Request.QueryString["bit"];
            if (!string.IsNullOrEmpty(bitStr))
            {
                if (bitStr.ToString() == "1")
                {
                    btn1.Attributes.Add("onclick", "window.location='/Config/AgentPermissions.aspx'");
                    btn2.Attributes.Add("onclick", "window.location='/Config/AgentPermissions.aspx'");
                }
            }

            if (!IsPostBack)
            {
                BindData();
            }
        }

        //绑定数据
        protected void BindData()
        {
            string outHtml = "";
            string outHtmls = "";
            string inHtml = "";
            outHtmls += "<table id=\"tab3\" width=100% cellpadding=0 cellspacing=\"0\" border=0 >";

            //DAL.SysModuleService modulservice = new DAL.SysModuleService();
            //Sys_moduleManager modulservice = new Sys_moduleManager();
            DAL.Sys_moduleService modulservice = new DAL.Sys_moduleService();
            //Repeater1.DataSource = modulservice.GetSysModuleByStatus("1");
            //Repeater1.DataSource = modulservice.GetSysModules();
            //Repeater1.DataBind();
            //IList<Util.SysModule> modules = modulservice.GetSysModuleByStatus("1");
            IList<Sys_module> modules = modulservice.GetSysModuleByStatus("1");
            foreach (Sys_module sysModule in modules)
            {
                if (sysModule.Module_parent_code == "ROOT_MENU")
                {
                    //outHtml = "<tr align=\"center\"><td colspan=\"2\">" + sysModule.Module_text + "</td></tr>";
                    outHtml = "<table id=\"tab3\" width=100% cellpadding=0 cellspacing=\"0\" border=0 >";
                    outHtml += "<thead><tr>";
                    outHtml += "<th colspan=\"2\">" + sysModule.Module_text + "</th></tr></thead>";
                }
                else
                {
                    //当前角色
                    int Rid = 0;
                    string rid = Request.QueryString["roleId"];
                    if (!string.IsNullOrEmpty(rid))
                    {
                        Rid = Convert.ToInt32(rid);
                    }

                    //获取角色权限
                    //DAL.sysRoleRightService roleService = new DAL.sysRoleRightService();
                    //Sys_role_rightManager roleService = new Sys_role_rightManager();
                    DAL.Sys_role_rightService roleService = new DAL.Sys_role_rightService();
                    DataTable rolePermissions = roleService.GetDataByRoleId(Rid);

                    //获取模块权限
                    //DAL.SysModuleRightService moduleRightService = new DAL.SysModuleRightService();
                    //Sys_module_rightManager moduleRightService = new Sys_module_rightManager();
                    DAL.Sys_module_rightService moduleRightService = new DAL.Sys_module_rightService();
                    DataTable moduleRights = moduleRightService.GetModuleRightByModuleCode(sysModule.Module_code);

                    inHtml = "";
                    for (int i = 0; i < moduleRights.Rows.Count; i++)
                    {
                        inHtml += "<input type=\"checkbox\" name=\"moduleright\" id=\"moduleright\" value=\"" + moduleRights.Rows[i]["Module_right_id"].ToString() + "\" ";
                        for (int j = 0; j < rolePermissions.Rows.Count; j++)
                        {
                            if (moduleRights.Rows[i]["Module_right_id"].ToString() == rolePermissions.Rows[j]["Module_right_id"].ToString())
                            {
                                inHtml += " checked";
                                break;
                            }
                        }
                        inHtml += ">" + moduleRights.Rows[i]["Operate_text"].ToString() + "&nbsp;&nbsp;";
                    }

                    //outHtml = "<tr><td>" + sysModule.Module_text + "</td>";
                    //outHtml += "<td>" + inHtml + "</td></tr>";
                    outHtml = "<tbody id=\"tab\"><tr id=\"datarow\"><td width='255px'>";
                    outHtml += sysModule.Module_text + "</td><td align='left'>";
                    outHtml += inHtml + "</td></tr></tbody>";

                }
                outHtmls += outHtml;
            }

            outHtmls += "</table>";

            Literal2.Text = outHtmls;
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            //DAL.sysRoleRightService rrService = new DAL.sysRoleRightService();
            DAL.Sys_role_rightService rrService = new DAL.Sys_role_rightService();
            DAL.VRoleRightService vrrService = new DAL.VRoleRightService();
            //VRoleRightManager vrrService = new VRoleRightManager();
            DAL.Sys_module_rightService mrService = new DAL.Sys_module_rightService();
            //Sys_module_rightManager mrService = new Sys_module_rightManager();

            //当前角色
            int Rid = 0;
            string rid = Request.QueryString["roleId"];
            if (!string.IsNullOrEmpty(rid))
            {
                Rid = Convert.ToInt32(rid);
            }
            //要添加的模块权限id
            string roleRight = Request.Form["moduleright"];
            if (roleRight ==null)
            {
                BindData();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择要设置的权限');</script>");
                return;
            }
            string[] roleRight_arr = roleRight.Split(',');

            //删除不存在的权限
            rrService.DeleteRoleRights(Rid, roleRight);

            //获取当前角色权限
            DataTable CurrentRoleRight = rrService.GetDataByRoleId(Rid);
            //添加数据
            bool ins = true;
            foreach (string s in roleRight_arr)
            {
                ins = true;
                for (int i = 0; i < CurrentRoleRight.Rows.Count; i++)
                {
                    if (CurrentRoleRight.Rows[i]["Module_right_id"].ToString() == s)
                    {
                        ins = false;
                        break;
                    }
                }

                if (ins)
                {
                    rrService.AddRoleRight(Rid, Convert.ToInt32(s));
                }
            }

            //要添加的父级模块权限id
            string furoleRight = "";
            DataTable mCodes = mrService.GetModuleRightByMidAll(roleRight);
            for (int i = 0; i < mCodes.Rows.Count; i++)
            {
                //furoleRight[i] = mCodes.Rows[i]["Module_right_id"].ToString();
                if (furoleRight == "")
                {
                    furoleRight = mCodes.Rows[i]["Module_right_id"].ToString();
                }
                else
                {
                    furoleRight += "," + mCodes.Rows[i]["Module_right_id"].ToString();
                }
            }
            string[] furoleRight_arr = furoleRight.Split(',');

            //删除不存在的权限
            //rrService.DeleteRoleRights(Rid, furoleRight);

            //获取当前角色父级模块权限
            DataTable fuCurrentRoleRight = vrrService.GetDataByRole(Rid);
            //添加数据
            foreach (string s in furoleRight_arr)
            {
                ins = true;
                for (int i = 0; i < fuCurrentRoleRight.Rows.Count; i++)
                {
                    if (fuCurrentRoleRight.Rows[i]["Module_right_id"].ToString() == s)
                    {
                        ins = false;
                        break;
                    }
                }
                if (ins)
                {
                    rrService.AddRoleRight(Rid, Convert.ToInt32(s));
                }
            }

            BindData();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('操作成功!');</script>");

        }

    }
}