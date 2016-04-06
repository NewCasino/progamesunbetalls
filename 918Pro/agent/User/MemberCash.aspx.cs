using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace agent.User
{
    public partial class MemberCash : PageBase
    {
        //----定义权限变量---------
        protected bool viewAc = true;
        protected bool addAc = true;
        protected bool mdfAc = true;
        protected bool searchAc = true;
        protected bool passwordAc = true;

        //代理初始值
        protected string Currency;
        protected string Credit;
        protected string UserCredit;
        protected string ResetCredit;
        protected string UserName;
        protected string RoleId;
        protected string Percent;
        protected string CommissionA;
        protected string CommissionB;
        protected string CommissionC;
        protected string ID;
        protected string ItemMin;
        protected string ItemMax;
        protected string ItemsMax;

        protected void Page_Load(object sender, EventArgs e)
        {
            //-----------权限控制开始-----------
            //当前角色
            int Rid = CurrentManager.RoleId;

            BLL.Sys_role_rightManager rrService = new BLL.Sys_role_rightManager();

            //查看权限
            if (!rrService.IsPermission(Rid, 180))
            {
                viewAc = false;
                Response.Write("<script>alert('非法操作，请返回!');history.go(-1);</script>");
                Response.End();
            }
            //增加权限
            if (!rrService.IsPermission(Rid, 120))
            {
                addAc = false;
            }
            //修改权限
            if (!rrService.IsPermission(Rid, 121))
            {
                mdfAc = false;
            }
            //查找权限
            if (!rrService.IsPermission(Rid, 122))
            {
                searchAc = false;
            }

            //修改密码
            if (!rrService.IsPermission(Rid, 123))
            {
                passwordAc = false;
            }
            //-----------权限控制结束-----------

            //代理初始化
            Model.Agent agent = BLL.AgentManager.GetAgentByPK(agentUserID);
            Credit = agent.Credit.ToString();
            UserCredit = agent.UserCredit.ToString();
            ResetCredit = agent.ResetCredit;
            UserName = agentUserName;
            RoleId = (agentRoleID + 1).ToString();
            Percent = (agent.Percent * 100).ToString();
            CommissionA = (agent.CommissionA * 100).ToString("0");
            CommissionB = (agent.CommissionB * 100).ToString("0");
            CommissionC = (agent.CommissionC * 100).ToString("0");
            ID = agentUserID.ToString();
            ItemMin = agent.ItemMin.ToString();
            ItemMax = agent.ItemMax.ToString();
            ItemsMax = agent.ItemsMax.ToString();
            Currency = agent.Currency;
        }
    }
}