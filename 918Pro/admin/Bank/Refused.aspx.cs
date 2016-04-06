using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace admin.Bank
{
    public partial class Refused : PageBase
    {
        protected bool viewAc = true;
        protected bool addAc = true;
        protected bool upAc = true;
        protected bool deleteAc = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            //当前角色
            int Rid = CurrentManager.RoleId;

            BLL.Sys_role_rightManager rrService = new BLL.Sys_role_rightManager();
            //查看权限
            if (!rrService.IsPermission(Rid, 192))
            {
                viewAc = false;
                Response.Write("<script>alert('非法操作，请返回!');history.go(-1);</script>");
                Response.End();
            }
            //增加权限
            if (!rrService.IsPermission(Rid, 193))
            {
                addAc = false;
            }
            //修改权限
            if (!rrService.IsPermission(Rid, 194))
            {
                upAc = false;
            }
            //删除权限
            if (!rrService.IsPermission(Rid, 195))
            {
                deleteAc = false;
            }
        }
    }
}