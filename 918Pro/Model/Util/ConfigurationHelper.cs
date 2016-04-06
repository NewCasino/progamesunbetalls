using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Util
{
    /// <summary>
    /// �����ļ�������
    /// </summary>
    public class ConfigurationHelper
    {
        // ���������ַ�������
        private static readonly string DB_CONNECTION_STRING = "DbConnectionString";
        // ������������û���
        private static readonly string EMAIL_USER_NAME = "EmailUserName";
        // ���������������
        private static readonly string EMAIL_USER_PASSWORD = "EmailUserPassword";
        // ������������ַ
        private static readonly string EMAIL_ADDRESS = "EmailAddress";
        // ����SMTP������
        private static readonly string SMTP_SERVER = "SmtpServer";
        // ����ϵͳ����
        private static readonly string SYS_NAME = "SysName";

        /// <summary>
        /// ��������ļ��������ַ���
        /// </summary>
        public static string DbConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings[DB_CONNECTION_STRING].ToString() ?? ""; }
        }

        /// <summary>
        /// ��õ��������û���
        /// </summary>
        public static string EmailUserName
        {
            get { return ConfigurationManager.AppSettings[EMAIL_USER_NAME] ?? ""; }
        }

        /// <summary>
        /// ��õ�����������
        /// </summary>
        public static string EmailUserPassword
        {
            get { return ConfigurationManager.AppSettings[EMAIL_USER_PASSWORD] ?? ""; }
        }

        /// <summary>
        /// ��õ��������ַ
        /// </summary>
        public static string EmailAddress
        {
            get { return ConfigurationManager.AppSettings[EMAIL_ADDRESS] ?? ""; }
        }

        /// <summary>
        /// ���SMTP������
        /// </summary>
        public static string SmtpServer
        {
            get { return ConfigurationManager.AppSettings[SMTP_SERVER] ?? ""; }
        }

        /// <summary>
        /// ���ϵͳ����
        /// </summary>
        public static string SysName
        {
            get { return ConfigurationManager.AppSettings[SYS_NAME]; }
        }

    }
}
