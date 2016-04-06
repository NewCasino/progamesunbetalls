using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace admin.Bank
{
    public partial class HongLiHistory : PageBase
    {
        public string ip = "";
        //----定义权限变量---------
        protected bool viewAc = true;  //查看
        protected bool cxAc = true;  //撤销

        protected void Page_Load(object sender, EventArgs e)
        {
            ip = Request.ServerVariables["Remote_Addr"];
            //-----------权限控制开始-----------
            //当前角色
            int Rid = CurrentManager.RoleId;

            BLL.Sys_role_rightManager rrService = new BLL.Sys_role_rightManager();

            //查看权限
            if (!rrService.IsPermission(Rid, 199))
            {
                viewAc = false;
                Response.Write("<script>alert('非法操作，请返回!');history.go(-1);</script>");
                Response.End();
            }
            //撤销权限
            if (!rrService.IsPermission(Rid, 206))
            {
                cxAc = false;
            }

            //-----------权限控制结束-----------
        }
    }
}