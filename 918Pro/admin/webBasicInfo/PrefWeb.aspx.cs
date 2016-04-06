using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

using MySql.Data.MySqlClient;

namespace admin.webBasicInfo
{
    public partial class PrefWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

     
        private void IntoAddNews()
        {
            string fileName ="";
            string fileName2 = "";
            string type22 = "";
            string id = this.tP0.Value.ToString();
            if (this.tP4.Text.ToString() == "" || this.tP5.Value.ToString() == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请输入活动标题,首页大图片，优惠页小图片);</script>");
            }
            else
            {
                string filePath = this.fileAccessories.PostedFile.FileName;
                if (filePath != "")
                {
                    fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);   //, filePath.Length-1
                    string serverPath = Server.MapPath("//ACC//") + fileName;
                    fileAccessories.SaveAs(serverPath);
                }
                else {
                    fileName = this.tP2.Text.ToString();
                }
               
                

                string FileUpload1SS = this.FileUpload1.PostedFile.FileName;
                if (FileUpload1SS != "")
                {
                    fileName2 = FileUpload1SS.Substring(FileUpload1SS.LastIndexOf("\\") + 1);   //, filePath.Length-1
                    string serverPath2 = Server.MapPath("//ACC//") + fileName2;
                    FileUpload1.SaveAs(serverPath2);
                }
                else
                {
                    fileName2 = this.tP3.Text.ToString();
                }








                if (this.tP1.Text.ToString().Trim() == "特殊优惠活动")
                {
                    type22 = "1";
                }
                else {
                    type22 = "0";
                }


                string SQL_UPDATE22 = "update yafa.pro_game set type=?type,BigPric=?BigPric,samlPric=?samlPric,title=?title,conent=?conent where ID = ?ID";
                MySqlParameter[] param = new MySqlParameter[]{
                                               
				         new MySqlParameter("?type", Convert.ToInt32(type22)),
				         new MySqlParameter("?BigPric",fileName),
				         new MySqlParameter("?samlPric",fileName2),
				         new MySqlParameter("?title",this.tP4.Text),
				         new MySqlParameter("?conent",this.tP5.Value),
                         new MySqlParameter("?ID", Convert.ToInt32(id))
			         };
                bool isture = MySqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString, SQL_UPDATE22, param) > 0;
                if (isture)
                {
                    Response.Redirect("PrefWeb.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('失败！');</script>");
                }

            }


        }

        protected void bntAddNews_Click(object sender, EventArgs e)
        {
            IntoAddNews();
        }
       
    }
}