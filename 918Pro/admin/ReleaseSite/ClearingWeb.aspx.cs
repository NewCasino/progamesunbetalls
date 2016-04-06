using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace admin.ReleaseSite
{
    public partial class ClearingWeb : PageBase
    {
        protected bool viewAc = true;
        protected bool clearingAc = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            int Rid = CurrentManager.RoleId;

            BLL.Sys_role_rightManager rrService = new BLL.Sys_role_rightManager();

            //查看权限
            if (!rrService.IsPermission(Rid, 33))
            {
                viewAc = false;
                Response.Write("<script>alert('非法操作，请返回!');history.go(-1);</script>");
                Response.End();
            }
            //增加权限
            if (!rrService.IsPermission(Rid, 111))
            {
                clearingAc = false;
            }
        }
    }
}