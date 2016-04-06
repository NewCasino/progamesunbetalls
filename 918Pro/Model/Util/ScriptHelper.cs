using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Util
{
    /// <summary>
    /// �����
    /// �ű�����������
    /// </summary>
    public class ScriptHelper
    {
        /// <summary>
        /// ��ǰҳ�����
        /// </summary>
        private static Page CurrentPage
        {
            get
            {
                return ((Page)HttpContext.Current.Handler);
            }
        }

        /// <summary>
        /// �ͻ��˽ű���ʾ
        /// </summary> 
        /// <param name="message">Ҫ����������</param>
        public static void Alert(string message)
        {
            CurrentPage.ClientScript.RegisterStartupScript(CurrentPage.GetType(),"", "<script>alert(\"" + EncodeScriptText(message) + "\");</script>");
        }

        /// <summary>
        /// ����ű�
        /// </summary>
        /// <param name="script">Ҫ����Ľű�</param>
        /// <returns></returns>
        private static string EncodeScriptText(string script)
        {
            return script.Replace(@"\", @"\\").Replace("\"", "\\\"").Replace("\n", @"\n").Replace("\t", @"\t").Replace("\a", @"\a").Replace("\b", @"\b");
        }


        /// <summary>
        /// ��ʾ�ͻ�����Ϣ���ض���ĳ��URL
        /// </summary>
        /// <param name="message">Ҫ��������Ϣ</param>
        /// <param name="url">�ض����URL</param>
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
        /// ��ת��ĳ����ַ
        /// </summary>
        /// <param name="scriptStr">�ű�</param>
        public static void ExecuteScript(string scriptStr)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<script language='javascript'>");
            builder.Append(scriptStr);
            builder.Append("</script>");
            CurrentPage.ClientScript.RegisterStartupScript(CurrentPage.GetType(), "", builder.ToString());
        }

        /// <summary>
        /// ����ĳ���ؼ�����ѡ����ʾ��Ϣ
        /// </summary>
        /// <param name="Control">�ؼ�</param>
        /// <param name="message">��ʾ����Ϣ</param>
        public static void ShowConfirm(WebControl Control, string message)
        {
            Control.Attributes.Add("onclick", "return confirm('" + message + "');");
        }
    }
}
