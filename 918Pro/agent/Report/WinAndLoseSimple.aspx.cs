using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace agent.Report
{
    public partial class WinAndLoseSimple : PageBase
    {
        PageBase page = new PageBase();
        protected bool viewAc = true;
        protected int roleId;
        protected string user;

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
            user = page.agentUserName;
            
            //if (roleId == 2)
            //{
            //    Response.Redirect("SubCompanyWinAndLoseSimple.aspx");
            //}
            //if (roleId == 3)
            //{
            //    Response.Redirect("PartnerWinAndLoseSimple.aspx");
            //}
            //if (roleId == 4)
            //{
            //    Response.Redirect("ZAgentWinAndLoseSimple.aspx");
            //}
            //if (roleId == 5)
            //{
            //    Response.Redirect("AgentWinAndLoseSimple.aspx");
            //}
        }
    }
}