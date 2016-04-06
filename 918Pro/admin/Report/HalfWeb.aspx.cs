using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace admin.Report
{
    public partial class HalfWeb : PageBase
    {
        //----定义权限变量---------
        protected bool viewAc = true;
        protected bool searchAc = true;
        protected bool excelAc = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            //-----------权限控制开始-----------
            //当前角色
            int Rid = CurrentManager.RoleId;

            BLL.Sys_role_rightManager rrService = new BLL.Sys_role_rightManager();

            //查看权限
            if (!rrService.IsPermission(Rid, 55))
            {
                viewAc = false;
                Response.Write("<script>alert('非法操作，请返回!');history.go(-1);</script>");
                Response.End();
            }
            //查找权限
            if (!rrService.IsPermission(Rid, 144))
            {
                searchAc = false;
            }
            //导出Excel权限
            if (!rrService.IsPermission(Rid, 145))
            {
                excelAc = false;
            }
            //-----------权限控制结束-----------
        }

        /// <summary>
        /// 输出到Excel
        /// </summary>
        /// <param name="page">page类</param>
        /// <param name="fileName">Excel文件名</param>
        /// <param name="table">表格html内容</param>
        protected void ExportToXls(Page page, string fileName, string table)
        {
            page.Response.Clear();
            page.Response.Buffer = true;
            //page.Response.Charset = "GB2312";
            page.Response.Charset = "UTF-8";
            page.Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName + System.DateTime.Now.ToString("_yyMMdd_hhmm") + ".xls");
            //page.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");//设置输出流为简体中文
            page.Response.ContentEncoding = System.Text.Encoding.UTF8;
            page.Response.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。 
            page.EnableViewState = false;
            page.Response.Write(table);
            page.Response.End();
        }

        protected void excel_Click(object sender, EventArgs e)
        {
            string table = "";
            table = hfContent.Value;
            ExportToXls(this.Page, this.nameValue.Value, table);
        }
    }
}