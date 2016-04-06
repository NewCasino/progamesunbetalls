using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace agent.User
{
    public partial class ResetCredit : PageBase
    {
        //----定义权限变量---------
        protected bool viewAc = true;
        protected bool mdfAc = true;
        protected bool searchAc = true;
        protected bool resetAc = true;

        //代理初始值
        protected string UserName;
        protected string RoleId;
        protected string Percent;
        protected string CommissionA;
        protected string CommissionB;
        protected string CommissionC;
        protected string ID;

        protected void Page_Load(object sender, EventArgs e)
        {
            //-----------权限控制开始-----------
            //当前角色
            int Rid = CurrentManager.RoleId;

            BLL.Sys_role_rightManager rrService = new BLL.Sys_role_rightManager();

            //查看权限
            if (!rrService.IsPermission(Rid, 74))
            {
                viewAc = false;
                Response.Write("<script>alert('非法操作，请返回!');history.go(-1);</script>");
                Response.End();
            }
            //修改权限
            if (!rrService.IsPermission(Rid, 133))
            {
                mdfAc = false;
            }
            //查找权限
            if (!rrService.IsPermission(Rid, 134))
            {
                searchAc = false;
            }
            //重置会员信用
            if (!rrService.IsPermission(Rid, 135))
            {
                resetAc = false;
            }
            //-----------权限控制结束-----------

            //代理初始化
            Model.Agent agent = BLL.AgentManager.GetAgentByPK(agentUserID);
            UserName = agentUserName;
            RoleId = (agentRoleID + 1).ToString();
            Percent = (agent.Percent * 100).ToString();
            CommissionA = (agent.CommissionA * 100).ToString("0");
            CommissionB = (agent.CommissionB * 100).ToString("0");
            CommissionC = (agent.CommissionC * 100).ToString("0");
            ID = agentUserID.ToString();

        }
    }
}