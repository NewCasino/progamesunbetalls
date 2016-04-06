using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace admin.PTgame
{
    public partial class ImportData : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Upload(object sender, EventArgs e)
        {
            try
            {
                //string uptime = Request.Form["uptime"];
                string txtuptime = uptime.Text;
                if (string.IsNullOrEmpty(txtuptime))
                {
                    msg.Text = "请选择日期";
                    return;
                }
                DateTime uptime1 = Convert.ToDateTime(txtuptime);
                //判断文件类型
                string restr = "";
                string format = ".xls|.csv";
                HttpPostedFile postedFile = FileUpload1.PostedFile;
                string fileName = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(fileName);
                if (postedFile.ContentLength == 0)
                {
                    restr = "请选择上传文件";
                    msg.Text = restr;
                    return;
                }
                if (format.IndexOf(fileExtension) == -1)
                {
                    restr = "上传文档格式不合法";
                    msg.Text = restr;
                    return;
                }
                //判断文件不能超过10M
                if (postedFile.ContentLength > 10485760)
                {
                    restr = "上传文档超出10M";
                    msg.Text = restr;
                    return;
                }
                //上传文件
                System.DateTime date = DateTime.Now;
                //生成随机文件名
                string saveName = date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + date.Hour.ToString() + date.Minute.ToString()

                    + date.Second.ToString() + date.Millisecond.ToString();
                fileName = saveName + fileExtension;
                string phyPath = HttpContext.Current.Request.MapPath("~/data/PT");
                postedFile.SaveAs(phyPath + "\\" + fileName);
                //导入数据
                int isexistcount = 0;
                if (BLL.PTgameManager.ExcelToData(phyPath, fileName, uptime1, ref isexistcount))
                {
                    if (isexistcount == 0)
                    {
                        restr = "上传数据成功!";
                    }
                    else
                    {
                        restr = "上传数据成功!　(有" + isexistcount.ToString() + "笔数据重复没有插入)";
                    }
                    msg.Text = restr;
                }
                else
                {
                    restr = "上传数据失败";
                    msg.Text = restr;
                }
            }
            catch
            {
                msg.Text = "上传文件异常，请重新上传";
            }
        }

    }
}