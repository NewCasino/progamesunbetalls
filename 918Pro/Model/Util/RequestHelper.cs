using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;


namespace Util
{
    /// <summary>
    /// ������ز�����
    /// </summary>
    public class RequestHelper
    {
        /// <summary>
        /// ��ò�ѯ�ַ�����ֵ
        /// </summary>
        /// <param name="name">����</param>
        /// <returns>ֵ</returns>
        public static string GetQueryString(string name)
        {
            if (HttpHelper.CurrentRequest.QueryString[name] == null)
            {
                return "";
            }
            return HttpHelper.CurrentRequest.QueryString[name];
        }

        /// <summary>
        /// ��ò�ѯ�ַ����е�Intֵ
        /// </summary>
        /// <param name="name">����</param>
        /// <returns>ֵ��ת��ʧ��ʱ��Ĭ��ֵΪ0��</returns>
        public static int GetQueryInt(string name)
        {
            return GetQueryInt(name, 0);
        }

        /// <summary>
        /// ��ò�ѯ�ַ����е�Intֵ
        /// </summary>
        /// <param name="name">����</param>
        /// <param name="defaultValue">ת��ʧ��ʱ��Ĭ��ֵ</param>
        /// <returns>ֵ</returns>
        public static int GetQueryInt(string name,int defaultValue)
        {
            return IntHelper.StrToInt32(HttpHelper.CurrentRequest.QueryString[name], defaultValue);
        }

        /// <summary>
        /// ��û�����URL
        /// </summary>
        /// <returns>������URL</returns>
        public static string GetBaseUrl()
        {
            if (HttpHelper.CurrentRequest.ApplicationPath == "/")
            {
                return "http://" + RequestHelper.GetServerString("HTTP_HOST");
            }
            return "http://" + RequestHelper.GetServerString("HTTP_HOST") + HttpHelper.CurrentRequest.ApplicationPath;
        }

        /// <summary>
        /// �滻Html���
        /// </summary>
        /// <param name="content">����</param>
        /// <returns>�滻�������</returns>
        public static string ReplaceHtml(string content)
        {
            string text = content.Trim();

            if (string.IsNullOrEmpty(text))
                return string.Empty;

            text = Regex.Replace(text, "[\\s]{2,}", " ");	// ���������ϵĿո�
            text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	// �滻<br>
            text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//���滻&nbsp;
            text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);	//any other tags

            return text;
        }

        /// <summary>
        /// ����ָ���ķ�����������Ϣ
        /// </summary>
        /// <param name="name">������������</param>
        /// <returns>������������Ϣ</returns>
        public static string GetServerString(string name)
        {
            if (HttpHelper.CurrentRequest.ServerVariables[name] == null)
            {
                return "";
            }
            return HttpHelper.CurrentRequest.ServerVariables[name].ToString();
        }

        /// <summary>
        /// �ж��Ƿ�����������������
        /// </summary>
        /// <returns>�Ƿ�����������������</returns>
        public static bool IsSearchEnginesGet()
        {
            if (HttpHelper.CurrentRequest.UrlReferrer == null)
            {
                return false;
            }
            string[] SearchEngine = { "google", "yahoo", "msn", "baidu", "sogou", "sohu", "sina", "163", "lycos", "tom", "yisou", "iask", "soso", "gougou", "zhongsou" };
            string tmpReferrer = HttpHelper.CurrentRequest.UrlReferrer.ToString().ToLower();
            for (int i = 0; i < SearchEngine.Length; i++)
            {
                if (tmpReferrer.IndexOf(SearchEngine[i]) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ��õ�ǰҳ�������
        /// </summary>
        /// <returns>��ǰҳ�������</returns>
        public static string GetPageName()
        {
            string pageName = string.Empty;

            string absolutePath = HttpHelper.CurrentRequest.Url.AbsolutePath;
            try
            {
                pageName = absolutePath.Substring(absolutePath.LastIndexOf("/") + 1).ToLower();
            }
            catch { }

            return pageName;
        }

        /// <summary>
        /// ��õ�ǰҳ��ͻ��˵�IP
        /// </summary>
        /// <returns>��ǰҳ��ͻ��˵�IP</returns>
        public static string GetIP()
        {
            string result = String.Empty;

            result = GetServerString("HTTP_X_FORWARDED_FOR");
            if (string.IsNullOrEmpty(result))
            {
                result = GetServerString("REMOTE_ADDR");
            }

            if (string.IsNullOrEmpty(result))
            {
                result = HttpHelper.CurrentRequest.UserHostAddress;
            }

            if (string.IsNullOrEmpty(result) || !IsIP(result))
            {
                return "127.0.0.1";
            }

            return result;

        }

        /// <summary>
        /// �Ƿ�Ϊip
        /// </summary>
        /// <param name="ip">Ҫ��֤��IP��ַ</param>
        /// <returns>boolֵ</returns>
        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");

        }

        /// <summary>
        /// �����û��ϴ����ļ�
        /// </summary>
        /// <param name="path">����·��</param>
        public static void SaveRequestFile(string path)
        {
            if (HttpHelper.CurrentRequest.Files.Count > 0)
            {
                HttpHelper.CurrentRequest.Files[0].SaveAs(path);
            }
        }
    }
}
