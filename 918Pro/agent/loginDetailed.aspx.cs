using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace agent
{
    public partial class loginDetailed : PageBase2
    {
        PageBase page = new PageBase();
        protected bool viewAc = true;
        protected int roleId;
        protected string username;
        protected string upUsername;

        protected void Page_Load(object sender, EventArgs e)
        {
            //当前角色
            int Rid = CurrentManager.RoleId;

            BLL.Sys_role_rightManager rrService = new BLL.Sys_role_rightManager();
            //查看权限
            if (!rrService.IsPermission(Rid, 63))
            {
                viewAc = false;
                Response.Write("<script>alert('非法操作，请返回!');history.go(-1);</script>");
                Response.End();
            }
            roleId = page.agentRoleID;
            username = page.agentUserName;
            upUsername = (page.upUsername == "" ? "#" : page.upUsername);

            //if (roleId == 2)
            //{
            //    Response.Redirect("SubCompanyWinAndLose.aspx");
            //}
            //if (roleId == 3)
            //{
            //    Response.Redirect("PartnerWinAndLose.aspx");
            //}
            //if (roleId == 4)
            //{
            //    Response.Redirect("ZAgentWinAndLose.aspx");
            //}
            //if (roleId == 5)
            //{
            //    Response.Redirect("AgentWinAndLose.aspx");
            //}
        }
    }
}