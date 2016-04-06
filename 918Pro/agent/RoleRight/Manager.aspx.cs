using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace agent.RoleRight
{
    public partial class Manager : PageBase
    {
        //----定义权限变量---------
        protected bool viewAc = true;
        protected bool addAc = true;
        protected bool mdfAc = true;
        protected bool deleteAc = true;
        protected bool passwordAc = true;
        protected bool statusAc = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            //-----------权限控制开始-----------
            //当前角色
            int Rid = CurrentManager.RoleId;

            BLL.Sys_role_rightManager rrService = new BLL.Sys_role_rightManager();

            //查看权限
            if (!rrService.IsPermission(Rid, 20))
            {
                viewAc = false;
                Response.Write("<script>alert('非法操作，请返回!');history.go(-1);</script>");
                Response.End();
            }
            //增加权限
            if (!rrService.IsPermission(Rid, 95))
            {
                addAc = false;
            }
            //修改权限
            if (!rrService.IsPermission(Rid, 96))
            {
                mdfAc = false;
            }
            //删除权限
            if (!rrService.IsPermission(Rid, 97))
            {
                deleteAc = false;
            }

            //启用禁用
            if (!rrService.IsPermission(Rid, 99))
            {
                statusAc = false;
            }
            
            //修改密码
            if (!rrService.IsPermission(Rid, 98))
            {
                passwordAc = false;
            }
            //-----------权限控制结束-----------

            if (!IsPostBack)
            {
                string roleId = Request.QueryString["rid"];
                roleid.Value = roleId;
            }
        }

        protected void btn_02_Click(object sender, EventArgs e)
        {
            Util.ScriptHelper.ExecuteScript("alert('aaa');");
        }
    }
}