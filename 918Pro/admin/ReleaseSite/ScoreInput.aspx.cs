using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace admin.ReleaseSite
{
    public partial class ScoreInput : PageBase
    {
        protected bool viewAc = true;
        protected bool upAc = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            //当前角色
            int Rid = CurrentManager.RoleId;

            BLL.Sys_role_rightManager rrService = new BLL.Sys_role_rightManager();
            //查看权限
            if (!rrService.IsPermission(Rid, 26))
            {
                viewAc = false;
                Response.Write("<script>alert('非法操作，请返回!');history.go(-1);</script>");
                Response.End();
            }

            //修改权限
            if (!rrService.IsPermission(Rid, 110))
            {
                upAc = false;
            }
        }
    }
}