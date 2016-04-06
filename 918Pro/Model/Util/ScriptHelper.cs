using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Util
{
    /// <summary>
    /// 刘旭邦
    /// 脚本帮助工具类
    /// </summary>
    public class ScriptHelper
    {
        /// <summary>
        /// 当前页面对象
        /// </summary>
        private static Page CurrentPage
        {
            get
            {
                return ((Page)HttpContext.Current.Handler);
            }
        }

        /// <summary>
        /// 客户端脚本提示
        /// </summary> 
        /// <param name="message">要弹出的内容</param>
        public static void Alert(string message)
        {
            CurrentPage.ClientScript.RegisterStartupScript(CurrentPage.GetType(),"", "<script>alert(\"" + EncodeScriptText(message) + "\");</script>");
        }

        /// <summary>
        /// 编码脚本
        /// </summary>
        /// <param name="script">要编码的脚本</param>
        /// <returns></returns>
        private static string EncodeScriptText(string script)
        {
            return script.Replace(@"\", @"\\").Replace("\"", "\\\"").Replace("\n", @"\n").Replace("\t", @"\t").Replace("\a", @"\a").Replace("\b", @"\b");
        }


        /// <summary>
        /// 显示客户端消息并重定向某个URL
        /// </summary>
        /// <param name="message">要弹出的消息</param>
        /// <param name="url">重定向的URL</param>
        public static void ShowAndRedirect(string message, string url)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<script language='javascript'>");
            builder.AppendFormat("alert('{0}');", message);
            builder.AppendFormat("location.href='{0}'", url);
            builder.Append("</script>");
            CurrentPage.ClientScript.RegisterStartupScript(CurrentPage.GetType(), "", builder.ToString());
        }
        /// <summary>
        /// 跳转到某个地址
        /// </summary>
        /// <param name="scriptStr">脚本</param>
        public static void ExecuteScript(string scriptStr)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<script language='javascript'>");
            builder.Append(scriptStr);
            builder.Append("</script>");
            CurrentPage.ClientScript.RegisterStartupScript(CurrentPage.GetType(), "", builder.ToString());
        }

        /// <summary>
        /// 基于某个控件弹出选择提示消息
        /// </summary>
        /// <param name="Control">控件</param>
        /// <param name="message">显示的消息</param>
        public static void ShowConfirm(WebControl Control, string message)
        {
            Control.Attributes.Add("onclick", "return confirm('" + message + "');");
        }
    }
}
