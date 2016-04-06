using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace agent.RoleRight.MenuManager
{
    public partial class LeftMenu : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }
        
        private void BindData()
        {
            DAL.VRoleRightService vrs = new DAL.VRoleRightService();

            Repeater1.DataSource = vrs.GetDataByRole(CurrentManager.RoleId);
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRow dr = ((System.Data.DataRowView)e.Item.DataItem).Row;
                Repeater Repeater2 = (Repeater)e.Item.FindControl("Repeater2");
                DAL.VRoleRightService vrs = new DAL.VRoleRightService();

                Repeater2.DataSource = vrs.GetDataByRoleTree(CurrentManager.RoleId, dr["Module_code"].ToString());
                Repeater2.DataBind();
            }
        }

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal Literal1 = (Literal)e.Item.FindControl("Literal1");
                if (Literal1 != null)
                {
                    DataRow dr = ((System.Data.DataRowView)e.Item.DataItem).Row;
                    string target = "";
                    if (dr["Module_target"].ToString() == "1")
                    {
                        target = "main_right";
                    }
                    else if (dr["Module_target"].ToString() == "2")
                    {
                        target = "_blank";
                    }

                    if (dr["Module_text"].ToString() == "1 x 2")
                    {
                        Literal1.Text = "<li><a href=\"" + dr["Module_url"].ToString() + "\" target=\"" + target + "\">" + dr["Module_text"].ToString() + "</a></li>";
                    }
                    else
                    {
                        if (CurrentManager.MoneyType == "1")
                        {
                            ////信用代理
                            //if (dr["Module_code"].ToString() == "L0509")
                            //{

                            //}
                            //else
                            //{
                                Literal1.Text = "<li><a id='" + dr["Module_code"].ToString() + "' href=\"" + dr["Module_url"].ToString() + "\" target=\"" + target + "\">" + dr["Module_text"].ToString() + "</a></li>";
                            //}
                        }
                        else
                        {
                            //现金代理
                            //if (dr["Module_code"].ToString() == "L0501" || dr["Module_code"].ToString() == "L0504" || dr["Module_code"].ToString() == "L0507")
                            //{

                            //}
                            //else
                            //{
                                Literal1.Text = "<li><a id='" + dr["Module_code"].ToString() + "' href=\"" + dr["Module_url"].ToString() + "\" target=\"" + target + "\">" + dr["Module_text"].ToString() + "</a></li>";
                            //}
                        }
                    }

                    //Literal1.Text = "<a id=\"menuitem11\" onclick=\"menu_select(11);\" href=\"" + dr["Module_url"].ToString() + "\" target=\"" + target + "\" class=\"Bleft_Sub\">" + dr["Module_text"].ToString() + "</a>";
                    //Literal1.Text = "<li><a href=\"" + dr["Module_url"].ToString() + "\" target=\"" + target + "\">" + dr["Module_text"].ToString() + "</a></li>";
                }
            }
        }

    }
}