using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace admin.Bank
{
    public partial class VerifyDeposit : admin.PageBase
    {
        public string ip = "";
        //----定义权限变量---------
        protected bool viewAc = true;  //查看
        //protected bool shAc = true;   //审核
        //protected bool historyAc = true;   //查看历史记录
        protected void Page_Load(object sender, EventArgs e)
        {
            ip = Request.ServerVariables["Remote_Addr"];
            //-----------权限控制开始-----------
            //当前角色
            int Rid = CurrentManager.RoleId;

            BLL.Sys_role_rightManager rrService = new BLL.Sys_role_rightManager();

            //查看权限
            if (!rrService.IsPermission(Rid, 176))
            {
                viewAc = false;
                Response.Write("<script>alert('非法操作，请返回!');history.go(-1);</script>");
                Response.End();
            }
            ////审核权限
            //if (!rrService.IsPermission(Rid, 85))
            //{
            //    shAc = false;
            //}
            ////删除权限
            //if (!rrService.IsPermission(Rid, 89))
            //{
            //    historyAc = false;
            //}
            //-----------权限控制结束-----------
        }
    }
}