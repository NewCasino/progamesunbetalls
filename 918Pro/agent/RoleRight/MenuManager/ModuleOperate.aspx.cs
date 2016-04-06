using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace agent.RoleRight.MenuManager
{
    public partial class ModuleOperate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            Repeater1.DataSource = Sys_module_operateManager.GetMutilILSys_module_operate();
            Repeater1.DataBind();
        }
    }
}