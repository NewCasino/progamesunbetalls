using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

namespace admin.Report
{
    public partial class DataByCasinoAccount : admin.PageBase
    {
        public string ip = "";
        //----定义权限变量---------
        protected bool viewAc = true;  //查看
        protected void Page_Load(object sender, EventArgs e)
        {

            string data = "";
            if (Request["a"] != "" && Request["b"] != "")
            {
                data = AccountManager.GetCasinoAccountData(Request["a"], Request["b"],Request["c"]);
            }
            //Response.ContentType = "";
            Response.Write("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\"><head runat=\"server\"><title></title><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"/><meta http-equiv=\"X-UA-Compatible\" content=\"IE=7\" /><link href=\"/css/Default/globle.css\" rel=\"stylesheet\" type=\"text/css\" /><link href=\"/css/Default/right_main.css\" rel=\"stylesheet\" type=\"text/css\" /><link href=\"/css/Default/tab.css\" rel=\"stylesheet\" type=\"text/css\" /><script src=\"/js/jquery-1.4.1.min.js\" type=\"text/javascript\"></script><script src=\"/js/jQueryCommon.js\" type=\"text/javascript\"></script><script src=\"/js/jquery-ui.min.js\" type=\"text/javascript\"></script><script src=\"/js/jquery.chromatable.js\" type=\"text/javascript\"></script><style type=\"text/css\">html { overflow:hidden; scrollbar-arrow-color: #419bbf;  /*三角箭头的颜色*/ scrollbar-face-color: #c1e4fe;  /*立体滚动条的颜色*/ scrollbar-3dlight-color: #eef3f7;  /*立体滚动条亮边的颜色*/ scrollbar-highlight-color: #eef3f7;  /*滚动条空白部分的颜色*/ scrollbar-shadow-color: #92c0e4;  /*立体滚动条阴影的颜色*/ scrollbar-darkshadow-color: #cae7fd;  /*立体滚动条强阴影的颜色*/ scrollbar-track-color: #e6f3fd;  /*立体滚动条背景颜色*/ }body{margin:0px;padding:0px;background-color:White; font-size:12px;color:#333; line-height:150%;-webkit-text-size-adjust:none;font-family:\"微软雅黑\",Arial, Helvetica, sans-serif;}</style></head><body><div class=\"comp_box\">");
            Response.Write(data);
            Response.Write("</div></body></html>"); 
            Response.End();

            ip = Request.ServerVariables["Remote_Addr"];
            //-----------权限控制开始-----------
            //当前角色
            int Rid = CurrentManager.RoleId;

            BLL.Sys_role_rightManager rrService = new BLL.Sys_role_rightManager();

            //查看权限
            if (!rrService.IsPermission(Rid, 16))
            {
                viewAc = false;
                Response.Write("<script>alert('非法操作，请返回!');window.close();</script>");
                Response.End();
            }
        }
    }
}