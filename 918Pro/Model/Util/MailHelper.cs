using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace Util
{
    /// <summary>
    /// �ʼ���ز�����
    /// </summary>
    public class MailHelper
    {
        #region ���͵����ʼ�

        private static bool isSucceed;

        /// <summary>
        /// ���͵����ʼ�
        /// </summary>
        /// <param name="to">�ռ���</param>
        /// <param name="cc">������</param>
        /// <param name="subject">����</param>
        /// <param name="body">��������</param>
        /// <param name="mode">��ʽ</param>
        /// <returns>true���ɹ���false��ʧ��</returns>
        public static bool SendMail(string to, string cc, string subject, string body, IsHtmlFormat mode)
        {
            return SendMail(ConfigurationHelper.EmailAddress, to, cc, subject, body, mode);
        }

        /// <summary>
        /// ���͵����ʼ�
        /// </summary>
        /// <param name="to">�ռ���</param>
        /// <param name="cc">������</param>
        /// <param name="subject">����</param>
        /// <param name="body">��������</param>
        /// <param name="mode">��ʽ</param>
        /// <param name="files">����</param>
        /// <returns>true���ɹ���false��ʧ��</returns>
        public static bool SendMail(string to, string cc, string subject, string body, IsHtmlFormat mode, params string[] files)
        {
            return SendMail(ConfigurationHelper.EmailAddress, to, cc, subject, body, mode, files);
        }

        /// <summary>
        /// ���͵����ʼ�
        /// </summary>
        /// <param name="from">������</param>
        /// <param name="to">�ռ���</param>
        /// <param name="cc">������</param>
        /// <param name="subject">����</param>
        /// <param name="body">��������</param>
        /// <param name="mode">��ʽ</param>
        /// <param name="files">����</param>
        /// <returns>true���ɹ���false��ʧ��</returns>
        public static bool SendMail(string from, string to, string cc, string subject, string body, IsHtmlFormat mode, params string[] files)
        {
            try
            {
                // ���������ʼ�
                MailMessage mail = new MailMessage();

                // ���÷�����
                mail.From = new MailAddress(from);
                // �����ռ���(���ŷָ�)
                if (to != "")
                {
                    string[] tos = to.Split(',');
                    foreach (string t in tos)
                    {
                        // ��Ӷ���ռ���
                        mail.To.Add(new MailAddress(t));
                    }
                }
                // ���ó�����(���ŷָ�)
                if (cc != "")
                {
                    string[] ccs = cc.Split(',');
                    foreach (string c in ccs)
                    {
                        // ��Ӷ��������
                        mail.CC.Add(new MailAddress(c));
                    }
                }
                // ��������
                mail.Subject = subject;
                // ������������
                mail.Body = body;
                // �����ʼ���ʽ
                mail.IsBodyHtml = (mode == IsHtmlFormat.Yes);
                // ���ø���
                if (files.Length > 0)
                {
                    foreach (string f in files)
                    {
                        mail.Attachments.Add(new Attachment(f));
                    }
                }

                // �����ʼ���������
                SmtpClient smtp = new SmtpClient();
                // ����SMTP������
                // һ�����������Ϊsmtp+�ʼ���׺
                // �磺cj@163.com�ķ�������ַΪ��smtp.163.com
                if (String.IsNullOrEmpty(ConfigurationHelper.SmtpServer))
                {
                    smtp.Host = "smtp." + from.Substring(from.IndexOf("@") + 1);
                }
                else
                {
                    smtp.Host = ConfigurationHelper.SmtpServer;
                }
                // ����SMTP�Ķ˿�
                smtp.Port = 25;
                // ���÷��������û���������
                smtp.Credentials = new NetworkCredential(
                    ConfigurationHelper.EmailUserName, ConfigurationHelper.EmailUserPassword);

                //smtp.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);

                // �����ʼ�
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

        //�����ʼ�
        public static void SendEmail91(string email, string subject, string body)
        {

            try
            {

                Encoding encoding = Encoding.UTF8;

                MailMessage message = new MailMessage(
                    new MailAddress("alisa@918shenbo.com ", "���ɱ�̫�����격", encoding), //��һ���Ƿ����˵ĵ�ַ���ڶ�����������ʾ�ķ�����
                    new MailAddress(email)
                );

                //MailMessage message = new MailMessage();

                //message.From = new MailAddress("info@51aspnet.net");
                //message.To.Add(new MailAddress(email));
                message.Subject = subject; //����
                message.Body = body;

                message.SubjectEncoding = encoding;
                message.BodyEncoding = encoding;
                message.IsBodyHtml = true; ////��������ʶ��html����

                SmtpClient smtp = new SmtpClient();  //����SmtpClient����  ���������
                smtp.Host = "smtp.ym.163.com";   //ָ��SMTP������

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
    /// �Ƿ�ΪHtml��ʽ
    /// </summary>
    public enum IsHtmlFormat
    {
        Yes,
        No
    }
}
