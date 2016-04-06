using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace admin.Bank
{
    public partial class BillDetail : admin.PageBase
    {
        public string ip = "";
        //----定义权限变量---------
        protected bool viewAc = true;  //查看
        //protected bool addAc = true;   //新增
        //protected bool mdfAc = true;   //修改
        //protected bool deleteAc = true;  //删除
        //protected bool passwordAc = true;  //详细
        //protected bool fzAc = true;//复制新增
        //protected bool slt = true;//查找
        //protected string fzAcS = "";
        //protected string addAcS = "";
        //protected string deleteAcS = "";
        //protected string mdfAcS = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ip = Request.ServerVariables["Remote_Addr"];
            //-----------权限控制开始-----------
            //当前角色
            int Rid = CurrentManager.RoleId;

            BLL.Sys_role_rightManager rrService = new BLL.Sys_role_rightManager();

            //查看权限
            if (!rrService.IsPermission(Rid, 178))
            {
                viewAc = false;
                Response.Write("<script>alert('非法操作，请返回!');history.go(-1);</script>");
                Response.End();
            }
            ////增加权限
            //if (!rrService.IsPermission(Rid, 85))
            //{
            //    addAc = false;
            //    addAcS = "var addAc = 1;";
            //}
            //else
            //{
            //    addAcS = "var addAc = 0;";
            //}

            ////删除权限
            //if (!rrService.IsPermission(Rid, 89))
            //{
            //    deleteAc = false;
            //    deleteAcS = "var deleteAc=1;";
            //}
            //else
            //{
            //    deleteAcS = "var deleteAc=0;";
            //}

            ////详细
            //if (!rrService.IsPermission(Rid, 90))
            //{
            //    passwordAc = false;
            //}

            ////修改
            //if (!rrService.IsPermission(Rid, 86))
            //{
            //    mdfAc = false;
            //    mdfAcS = "var mdfAc=1;";
            //}
            //else
            //{
            //    mdfAcS = "var mdfAc=0;";
            //}

            ////查找
            //if (!rrService.IsPermission(Rid, 88))
            //{
            //    slt = false;
            //}

            ////复制新增
            //if (!rrService.IsPermission(Rid, 87))
            //{
            //    fzAc = false;
            //    fzAcS = "var fzAc=1;";
            //}
            //else
            //{
            //    fzAcS = "var fzAc=0;";
            //}
            //-----------权限控制结束-----------
        }
    }
}