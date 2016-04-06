using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Caching;
using System.Web;

namespace Util
{
    /// <summary>
    /// ���ݻ��渨����
    /// </summary>
    public class CacheHelper
    {
        /// <summary>
        /// ��û����ֵ
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>����Ķ���</returns>
        public static object GetCache(string value)
        {
            return HttpHelper.CurrentCache[value];
        }

        /// <summary>
        /// ���û���
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <param name="dt">�����ʱ��</param>
        public static void SetCache(string key, string value,DateTime dt)
        {
            SetCache(key, value, null, dt);
        }

        /// <summary>
        /// ���û���
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <param name="cd">����������</param>
        /// <param name="dt">�����ʱ��</param>
        public static void SetCache(string key, string value,CacheDependency cd,DateTime dt)
        {
            HttpHelper.CurrentCache.Insert(key, value, cd, dt, Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// ����ҳ�治������
        /// </summary>
        public static void SetPageNoCache()
        {
            HttpHelper.CurrentResponse.Buffer = true;
            HttpHelper.CurrentResponse.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            HttpHelper.CurrentResponse.Expires = 0;
            HttpHelper.CurrentResponse.CacheControl = "no-cache";
            HttpHelper.CurrentResponse.AddHeader("Pragma", "No-Cache");
        }

        /// <summary>
        /// ���ʣ�໺���С(M)
        /// </summary>
        public string Remains
        {
            get
            {
                return string.Format("{0}M", HttpHelper.CurrentCache.EffectivePrivateBytesLimit / 1024 / 1024);
            }
        }
    }
}
