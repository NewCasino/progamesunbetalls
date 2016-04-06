using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using Util;

namespace Ezun.ServiceFile
{
    /// <summary>
    /// AgnetService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class AgnetService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// 会员注册添加会员
        /// </summary>
        /// <returns></returns>
        [WebMethod(true)]
        public string AddUser(string UserName, string Password, string nums, string Name, string question, string Answer, string CardNo, string bankname,
            string Tel, string Email, string qq)
        {
            Model.Joiner joiner = new Model.Joiner();

            if (!string.IsNullOrEmpty(Email))
            {
                if (DAL.UserService.IsExistEmailAgnet(Email))
                {
                    return "email";   //邮箱重复
                }
            }


            joiner.UserName = UserName;


            joiner.Password = Password;
            joiner.nums = nums;
            joiner.Name = Name;
            joiner.Question = question;
            joiner.Answer = Answer;
            joiner.Tel = Tel;
            joiner.Email = Email;
            joiner.qq = qq;


            joiner.CardNo = CardNo;
            joiner.bankname = bankname;

            joiner.Subtime = DateTime.Now;
            bool reval = DAL.UserService.AddAgentUserAgent(joiner);
            if (reval)
            {
                return "ok";
            }
            else
            {
                return "err";
            }
        }
    }
}
