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
    public partial class PrefWeb2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void IntoAddNews()
        {
            if (this.txtTitle.Text.ToString() == "" || this.fileAccessories.PostedFile.FileName.ToString() == "" || this.FileUpload1.PostedFile.FileName.ToString() == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请输入活动标题,首页大图片，优惠页小图片);</script>");
            }
            else {
                string filePath = this.fileAccessories.PostedFile.FileName;
                string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);   //, filePath.Length-1
                string serverPath = Server.MapPath("//ACC//") + fileName;
                fileAccessories.SaveAs(serverPath);

                string FileUpload1SS = this.FileUpload1.PostedFile.FileName;
                string fileName2 = FileUpload1SS.Substring(FileUpload1SS.LastIndexOf("\\") + 1);   //, filePath.Length-1
                string serverPath2 = Server.MapPath("/ACC//") + fileName2;
                FileUpload1.SaveAs(serverPath2);

                string SQL_INSERT = "insert into yafa.pro_game (type,BigPric,samlPric,title,conent)values(?type,?BigPric,?samlPric,?title,?conent)";
                    MySqlParameter[] param = new MySqlParameter[]{
				         new MySqlParameter("?type", Convert.ToInt32(this.type_22.Value)),
				         new MySqlParameter("?BigPric",fileName),
				         new MySqlParameter("?samlPric",fileName2),
				         new MySqlParameter("?title",this.txtTitle.Text),
				         new MySqlParameter("?conent",this.FCKeditor.Value)
			         };
                    bool isture = MySqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString,SQL_INSERT, param) > 0;
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

        protected void Closebank_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrefWeb.aspx");
        }
      
    }
}