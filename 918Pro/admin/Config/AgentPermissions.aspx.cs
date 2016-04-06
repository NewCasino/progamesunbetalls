using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace admin.Config
{
    public partial class AgentPermissions : PageBase
    {
        //----定义权限变量---------
        protected bool viewAc = true;
        protected bool sqAc = true;
        protected bool statusAc = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            //-----------权限控制开始-----------
            //当前角色
            int Rid = CurrentManager.RoleId;

            BLL.Sys_role_rightManager rrService = new BLL.Sys_role_rightManager();

            //查看权限
            if (!rrService.IsPermission(Rid, 73))
            {
                viewAc = false;
                Response.Write("<script>alert('非法操作，请返回!');history.go(-1);</script>");
                Response.End();
            }
            //增加权限
            if (!rrService.IsPermission(Rid, 108))
            {
                sqAc = false;
            }
            //启用禁用
            //if (!rrService.IsPermission(Rid, 156))
            //{
            //    statusAc = false;
            //}
            //-----------权限控制结束-----------

            BindData();
        }

        protected void BindData()
        {
            BLL.RoleManager roleManager = new BLL.RoleManager();
            Repeater1.DataSource = roleManager.GetAgentRole();
            Repeater1.DataBind();
        }
    }
}