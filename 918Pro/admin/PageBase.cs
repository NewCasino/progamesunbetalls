using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Util;
using Model;
using System.Web.Services;

namespace admin
{
    public class PageBase:Page
    {
        protected override void OnInit(EventArgs e)
        {
            //做处理
            if (Session[ProjectConfig.ADMINUSER] == null)
            {
                //ScriptHelper.ExecuteScript("window.parent.location.href='/login.htm'");
                Response.Write("<script>window.parent.location.href='/login.htm'</script>");
                Response.End();
            }
            else
            {

                //判断同一个账号是否多个地方登录
                if (Application[CurrentManager.ManagerId + "Session"].ToString() != this.Session.SessionID )
                {
                    //ScriptHelper.ExecuteScript("window.parent.location.href='/login.htm'");
                    Response.Write("<script>window.parent.location.href='/login.htm'</script>");
                    Response.End();
                }
            }
            
            base.OnInit(e);
        }
        /// <summary>
        /// 获得当前登录者对
        /// </summary>
        public Manager CurrentManager
        {
            get { return Session[ProjectConfig.ADMINUSER] as Manager; }
        }
    }
}