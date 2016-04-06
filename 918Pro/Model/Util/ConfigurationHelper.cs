using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Util
{
    /// <summary>
    /// 配置文件辅助类
    /// </summary>
    public class ConfigurationHelper
    {
        // 定义连接字符串常量
        private static readonly string DB_CONNECTION_STRING = "DbConnectionString";
        // 定义电子邮箱用户名
        private static readonly string EMAIL_USER_NAME = "EmailUserName";
        // 定义电子邮箱密码
        private static readonly string EMAIL_USER_PASSWORD = "EmailUserPassword";
        // 定义电子邮箱地址
        private static readonly string EMAIL_ADDRESS = "EmailAddress";
        // 定义SMTP服务器
        private static readonly string SMTP_SERVER = "SmtpServer";
        // 定义系统名称
        private static readonly string SYS_NAME = "SysName";

        /// <summary>
        /// 获得配置文件的连接字符串
        /// </summary>
        public static string DbConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings[DB_CONNECTION_STRING].ToString() ?? ""; }
        }

        /// <summary>
        /// 获得电子邮箱用户名
        /// </summary>
        public static string EmailUserName
        {
            get { return ConfigurationManager.AppSettings[EMAIL_USER_NAME] ?? ""; }
        }

        /// <summary>
        /// 获得电子邮箱密码
        /// </summary>
        public static string EmailUserPassword
        {
            get { return ConfigurationManager.AppSettings[EMAIL_USER_PASSWORD] ?? ""; }
        }

        /// <summary>
        /// 获得电子邮箱地址
        /// </summary>
        public static string EmailAddress
        {
            get { return ConfigurationManager.AppSettings[EMAIL_ADDRESS] ?? ""; }
        }

        /// <summary>
        /// 获得SMTP服务器
        /// </summary>
        public static string SmtpServer
        {
            get { return ConfigurationManager.AppSettings[SMTP_SERVER] ?? ""; }
        }

        /// <summary>
        /// 获得系统名称
        /// </summary>
        public static string SysName
        {
            get { return ConfigurationManager.AppSettings[SYS_NAME]; }
        }

    }
}
