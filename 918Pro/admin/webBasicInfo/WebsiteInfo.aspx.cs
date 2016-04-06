using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin
{
    public partial class WebsiteInfo : admin.PageBase
    {
        public string ip = "";
        //----定义权限变量---------
        protected bool viewAc = true;  //查看
        protected bool addAc = true;   //新增
        protected bool mdfAc = true;   //修改

        protected void Page_Load(object sender, EventArgs e)
        {
            ip = Request.ServerVariables["Remote_Addr"];
            //-----------权限控制开始-----------
            //当前角色
            int Rid = CurrentManager.RoleId;

            BLL.Sys_role_rightManager rrService = new BLL.Sys_role_rightManager();

            //查看权限
            if (!rrService.IsPermission(Rid, 14))
            {
                viewAc = false;
                Response.Write("<script>alert('非法操作，请返回!');history.go(-1);</script>");
                Response.End();
            }
            //增加权限
            if (!rrService.IsPermission(Rid, 77))
            {
                addAc = false;
            }
            //修改
            if (!rrService.IsPermission(Rid, 78))
            {
                mdfAc = false;
            }
        }
    }
}