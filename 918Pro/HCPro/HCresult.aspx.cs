using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _138SUN.YP
{
    public partial class HCresult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string BillNo = System.Web.HttpContext.Current.Request.Params["BillNo"];
                string Amount = System.Web.HttpContext.Current.Request.Params["Amount"];
                string Succeed = System.Web.HttpContext.Current.Request.Params["Succeed"];
                string Result = System.Web.HttpContext.Current.Request.Params["Result"];
                string SignMD5info = System.Web.HttpContext.Current.Request.Params["SignMD5info"];

                if (Succeed.ToString() == "88")
                {
                    //  callback方式:浏览器重定向n
                    //1：根据订单修改状态

                    if (BillNo.ToString() != "" && Result.ToString() != "" && Amount.ToString() != "")
                    {
                        BLL.Ezun.BankManager.UpdateBillNotice2(BillNo.ToString().Trim(), Amount.ToString().Trim());

                    }

                    Response.Write("ok");

                }
                else
                {

                    Response.Write("fail");
                  

                }
            }
        }
    }
}