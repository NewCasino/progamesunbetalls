using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin
{
    public partial class BetaccountLogWeb : admin.PageBase
    {
        //----定义权限变量---------
        protected bool viewAc = true;  //查看
        protected bool passwordAc = true;  //详细

        protected void Page_Load(object sender, EventArgs e)
        {
            //-----------权限控制开始-----------
            //当前角色
            int Rid = CurrentManager.RoleId;

            BLL.Sys_role_rightManager rrService = new BLL.Sys_role_rightManager();

            //查看权限
            if (!rrService.IsPermission(Rid, 18))
            {
                viewAc = false;
                Response.Write("<script>alert('非法操作，请返回!');history.go(-1);</script>");
                Response.End();
            }

            //详细
            if (!rrService.IsPermission(Rid, 94))
            {
                passwordAc = false;
            }
            //-----------权限控制结束-----------
        }
    }
}