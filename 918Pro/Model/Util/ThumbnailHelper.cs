using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Util
{
    /// <summary>
    /// 缩略图操作辅助类
    /// </summary>
    public class ThumbnailHelper
    {
        public ThumbnailHelper()
        {
        }

        /// <summary>
        /// 创建缩略图
        /// </summary>
        /// <param name="src">来源页面,可以是相对地址或者绝对地址</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <returns>字节数组</returns>
        public static byte[] MakeThumbnail(string src, double width, double height)
        {
            Image image;

            // 相对路径从本机直接读取
            if (src.ToLower().IndexOf("http://") == -1)
            {
                src = HttpHelper.CurrentServer.MapPath(src);
                image = Image.FromFile(src, true);
            }
            else // 绝对路径从 Http 读取
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(src);
                req.Method = "GET";
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                Stream receiveStream = resp.GetResponseStream();
                image = Image.FromStream(receiveStream);
                resp.Close();
                receiveStream.Close();
            }
            double newWidth, newHeight;
            if (image.Width > image.Height)
            {
                newWidth = width;
                newHeight = image.Height * (newWidth / image.Width);
            }
            else
            {
                newHeight = height;
                newWidth = (newHeight / image.Height) * image.Width;
            }
            if (newWidth > width)
            {
                newWidth = width;
            }
            if (newHeight > height)
            {
                newHeight = height;
            }
            //取得图片大小
            Size size = new Size((int)newWidth, (int)newHeight);
            //新建一个bmp图片
            Image bitmap = new Bitmap(size.Width, size.Height);
            //新建一个画板
            Graphics g = Graphics.FromImage(bitmap);
            //设置高质量插值法
            g.InterpolationMode = InterpolationMode.High;
            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = SmoothingMode.HighQuality;
            //清空一下画布
            g.Clear(Color.White);
            //在指定位置画图
            g.DrawImage(image, new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                        new Rectangle(0, 0, image.Width, image.Height),
                        GraphicsUnit.Pixel);

            ////文字水印
            //System.Drawing.Graphics G = System.Drawing.Graphics.FromImage(bitmap);
            //System.Drawing.Font f = new Font("宋体", 10);
            //System.Drawing.Brush b = new SolidBrush(Color.Black);
            //G.DrawString("文字水印的测试", f, b, 10, 10);
            //G.Dispose();

            ////图片水印
            //System.Drawing.Image copyImage = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath("Bird.gif"));
            //Graphics a = Graphics.FromImage(bitmap);
            //a.DrawImage(copyImage, new Rectangle(bitmap.Width - copyImage.Width, bitmap.Height - copyImage.Height, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, GraphicsUnit.Pixel);
            //copyImage.Dispose();
            //a.Dispose();
            //copyImage.Dispose();

            //保存高清晰度的缩略图
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Jpeg);
            byte[] buffer = stream.GetBuffer();
            g.Dispose();
            image.Dispose();
            bitmap.Dispose();
            return buffer;
        }
    }
}