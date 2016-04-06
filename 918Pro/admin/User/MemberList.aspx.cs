using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace admin.User
{
    public partial class MemberList : PageBase
    {
        //----定义权限变量---------
        protected bool viewAc = true;
        protected bool addAc = true;
        protected bool mdfAc = true;
        protected bool searchAc = true;
        protected bool passwordAc = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            //-----------权限控制开始-----------
            //当前角色
            int Rid = CurrentManager.RoleId;

            BLL.Sys_role_rightManager rrService = new BLL.Sys_role_rightManager();

            //查看权限
            if (!rrService.IsPermission(Rid, 43))
            {
                viewAc = false;
                Response.Write("<script>alert('非法操作，请返回!');history.go(-1);</script>");
                Response.End();
            }
            //增加权限
            if (!rrService.IsPermission(Rid, 120))
            {
                addAc = false;
            }
            //修改权限
            if (!rrService.IsPermission(Rid, 121))
            {
                mdfAc = false;
            }
            //查找权限
            if (!rrService.IsPermission(Rid, 122))
            {
                searchAc = false;
            }

            //修改密码
            if (!rrService.IsPermission(Rid, 123))
            {
                passwordAc = false;
            }
            //-----------权限控制结束-----------
        }
    }
}