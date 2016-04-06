using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin
{
    public partial class BetaccountCopyWeb : admin.PageBase
    {
        //----定义权限变量---------
        protected bool viewAc = true;  //查看
        protected bool addAc = true;   //新增
        //protected bool mdfAc = true;   //修改
        protected bool deleteAc = true;  //删除
        protected bool passwordAc = true;  //详细
        protected bool slt = true;  //查找


        protected void Page_Load(object sender, EventArgs e)
        {
            //-----------权限控制开始-----------
            //当前角色
            int Rid = CurrentManager.RoleId;

            BLL.Sys_role_rightManager rrService = new BLL.Sys_role_rightManager();

            //查看权限
            if (!rrService.IsPermission(Rid, 17))
            {
                viewAc = false;
                Response.Write("<script>alert('非法操作，请返回!');history.go(-1);</script>");
                Response.End();
            }
            //增加权限
            if (!rrService.IsPermission(Rid, 91))
            {
                addAc = false;
            }
            //删除权限
            if (!rrService.IsPermission(Rid, 92))
            {
                deleteAc = false;
            }

            //详细
            if (!rrService.IsPermission(Rid, 93))
            {
                passwordAc = false;
            }

            //查找
            if (!rrService.IsPermission(Rid, 159))
            {
                slt = false;
            }
            //-----------权限控制结束-----------
        }
    }
}