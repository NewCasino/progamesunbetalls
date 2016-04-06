using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace Util
{
    /// <summary>
    /// 邮件相关操作类
    /// </summary>
    public class MailHelper
    {
        #region 发送电子邮件

        private static bool isSucceed;

        /// <summary>
        /// 发送电子邮件
        /// </summary>
        /// <param name="to">收件人</param>
        /// <param name="cc">抄送人</param>
        /// <param name="subject">主题</param>
        /// <param name="body">正文内容</param>
        /// <param name="mode">方式</param>
        /// <returns>true，成功；false，失败</returns>
        public static bool SendMail(string to, string cc, string subject, string body, IsHtmlFormat mode)
        {
            return SendMail(ConfigurationHelper.EmailAddress, to, cc, subject, body, mode);
        }

        /// <summary>
        /// 发送电子邮件
        /// </summary>
        /// <param name="to">收件人</param>
        /// <param name="cc">抄送人</param>
        /// <param name="subject">主题</param>
        /// <param name="body">正文内容</param>
        /// <param name="mode">方式</param>
        /// <param name="files">附件</param>
        /// <returns>true，成功；false，失败</returns>
        public static bool SendMail(string to, string cc, string subject, string body, IsHtmlFormat mode, params string[] files)
        {
            return SendMail(ConfigurationHelper.EmailAddress, to, cc, subject, body, mode, files);
        }

        /// <summary>
        /// 发送电子邮件
        /// </summary>
        /// <param name="from">发件人</param>
        /// <param name="to">收件人</param>
        /// <param name="cc">抄送人</param>
        /// <param name="subject">主题</param>
        /// <param name="body">正文内容</param>
        /// <param name="mode">方式</param>
        /// <param name="files">附件</param>
        /// <returns>true，成功；false，失败</returns>
        public static bool SendMail(string from, string to, string cc, string subject, string body, IsHtmlFormat mode, params string[] files)
        {
            try
            {
                // 创建电子邮件
                MailMessage mail = new MailMessage();

                // 设置发件人
                mail.From = new MailAddress(from);
                // 设置收件人(逗号分隔)
                if (to != "")
                {
                    string[] tos = to.Split(',');
                    foreach (string t in tos)
                    {
                        // 添加多个收件人
                        mail.To.Add(new MailAddress(t));
                    }
                }
                // 设置抄送人(逗号分隔)
                if (cc != "")
                {
                    string[] ccs = cc.Split(',');
                    foreach (string c in ccs)
                    {
                        // 添加多个抄送人
                        mail.CC.Add(new MailAddress(c));
                    }
                }
                // 设置主题
                mail.Subject = subject;
                // 设置正文内容
                mail.Body = body;
                // 设置邮件格式
                mail.IsBodyHtml = (mode == IsHtmlFormat.Yes);
                // 设置附件
                if (files.Length > 0)
                {
                    foreach (string f in files)
                    {
                        mail.Attachments.Add(new Attachment(f));
                    }
                }

                // 创建邮件服务器类
                SmtpClient smtp = new SmtpClient();
                // 设置SMTP服务器
                // 一般服务器名称为smtp+邮件后缀
                // 如：cj@163.com的服务器地址为：smtp.163.com
                if (String.IsNullOrEmpty(ConfigurationHelper.SmtpServer))
                {
                    smtp.Host = "smtp." + from.Substring(from.IndexOf("@") + 1);
                }
                else
                {
                    smtp.Host = ConfigurationHelper.SmtpServer;
                }
                // 设置SMTP的端口
                smtp.Port = 25;
                // 设置服务器的用户名和密码
                smtp.Credentials = new NetworkCredential(
                    ConfigurationHelper.EmailUserName, ConfigurationHelper.EmailUserPassword);

                //smtp.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);

                // 发送邮件
                smtp.SendAsync(mail, String.Empty);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        static void smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Cancelled || e.Error != null)
            {
                isSucceed = false;
            }
            isSucceed = true;
        }

        #endregion

        //发送邮件
        public static void SendEmail91(string email, string subject, string body)
        {

            try
            {

                Encoding encoding = Encoding.UTF8;

                MailMessage message = new MailMessage(
                    new MailAddress("alisa@918shenbo.com ", "菲律宾太阳城申博", encoding), //第一个是发件人的地址，第二个参数是显示的发信人
                    new MailAddress(email)
                );

                //MailMessage message = new MailMessage();

                //message.From = new MailAddress("info@51aspnet.net");
                //message.To.Add(new MailAddress(email));
                message.Subject = subject; //标题
                message.Body = body;

                message.SubjectEncoding = encoding;
                message.BodyEncoding = encoding;
                message.IsBodyHtml = true; ////邮箱内容识别html语言

                SmtpClient smtp = new SmtpClient();  //创建SmtpClient对象  信箱服务器
                smtp.Host = "smtp.ym.163.com";   //指定SMTP服务器

                //smtp.EnableSsl = true;
                smtp.Port = 25;
                //smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                ////NetworkCredential _cred = new NetworkCredential("xzz2000", "197993146", "126.com");
                smtp.Credentials = new NetworkCredential("alisa@918shenbo.com", "980329");

                smtp.Send(message);

            }
            catch (SmtpException ex)
            {
                throw new SmtpException(ex.Message);
            }

        }
    }

    /// <summary>
    /// 是否为Html格式
    /// </summary>
    public enum IsHtmlFormat
    {
        Yes,
        No
    }
}
