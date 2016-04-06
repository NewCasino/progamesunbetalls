using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Util;
using Model;
using System.Web.Services;

namespace agent
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

                ////判断同一个账号是否多个地方登录
                //if (Application[CurrentManager.UserName + "Session"].ToString() != this.Session.SessionID )
                //{
                //    //ScriptHelper.ExecuteScript("window.parent.location.href='/login.htm'");
                //    Response.Write("<script>window.parent.location.href='/login.aspx'</script>");
                //    Response.End();
                //}
            }
            
            base.OnInit(e);
        }
        /// <summary>
        /// 获得当前登录者对象
        /// </summary>
        public Agent CurrentManager
        {
            get { return Session[ProjectConfig.ADMINUSER] as Agent; }
        }

        /// <summary>
        /// 当前代理角色名称
        /// </summary>
        public string agentRoleName
        {
            get
            {
                if (CurrentManager.SubAccount == "1")
                {
                    return CurrentManager.AgentRoleName;
                }
                else
                {
                    return CurrentManager.RoleName;
                }
            }
        }

        /// <summary>
        /// 当前代理角色ID
        /// </summary>
        public int agentRoleID
        {
            get
            {
                if (CurrentManager.SubAccount == "1")
                {
                    return CurrentManager.AgentRoleID;
                }
                else
                {
                    return CurrentManager.RoleId;
                }
            }
        }

        /// <summary>
        /// 当前代理用户名
        /// </summary>
        public string agentUserName
        {
            get
            {
                if (CurrentManager.SubAccount == "1")
                {
                    return CurrentManager.AgentUserName;
                }
                else
                {
                    return CurrentManager.UserName;
                }
            }
        }

        /// <summary>
        /// 当前代理ID
        /// </summary>
        public int agentUserID
        {
            get
            {
                if (CurrentManager.SubAccount == "1")
                {
                    return CurrentManager.AgentID;
                }
                else
                {
                    return CurrentManager.ID;
                }
            }
        }

        /// <summary>
        /// 上级代理名称
        /// </summary>
        public string upUsername
        {
            get
            {
                return CurrentManager.UpUserName;
            }
        }

    }
}