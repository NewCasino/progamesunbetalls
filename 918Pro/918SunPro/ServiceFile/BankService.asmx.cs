using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Model;
using BLL;
using Util;
using DAL;

using System.Text;
using System.IO;
using System.Xml;
using System.Web;

namespace Ezun.ServiceFile
{
    /// <summary>
    /// BankService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class BankService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(true)]
        public string GetBankInfoAll()
        {
            try
            {
                Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
                return BLL.Ezun.BankManager.GetBankInfoAll();
            }
            catch (Exception)
            {
                return "";
            }
        }
        [WebMethod(true)]
        public string GetBankInfo()
        {
            if (Session[ProjectConfig.LOGINUSER] == null)
            {
                return "";
            }
            try
            {
                Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
                return BLL.Ezun.BankManager.GetBankInfo();
            }
            catch (Exception)
            {
                return "";
            }
        }



        [WebMethod(true)]
        public string GetBankCByCurr()
        {
            if (Session[ProjectConfig.LOGINUSER] == null)
            {
                return "";
            }
            try
            {
                Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
                return BLL.Ezun.BankManager.GetBankCByCurr();
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// 存款申请
        /// </summary>
        /// <param name="money">申请金额</param>
        /// <param name="bank">银行</param>     
        /// <param name="bankno">流水号</param>
        /// <param name="type">1：存款申请</param>
        /// <param name="cardNo">银行卡号</param>
        /// <param name="bankTime">时间</param>
        /// <param name="tel">电话</param>     
        /// <returns></returns>
        [WebMethod(true)]
        public bool InsertBillNotice2s(string Amount, string bank, string bankno, string type, string cardNo, string Names, string UserName, string Tel, string Mark)
        {
            //if (Session[ProjectConfig.LOGINUSER] == null)
            //{
            //    return false;
            //}

            try
            {
                Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
                BillNotice billNotice = new BillNotice();

                if (string.IsNullOrEmpty(cardNo))
                {
                    return false;   //银行卡号为空
                }
                else
                {

                    billNotice.Bankno = DAL.Ezun.BankService.GetBankInfo(cardNo);
                }

                if (user != null)
                {
                    billNotice.UserName = user.UserName;
                }
                else
                {
                    billNotice.UserName = UserName;
                }
                billNotice.Bankcn = bank;
                billNotice.Banktw = bank;

                billNotice.Type = type;
                billNotice.Amount = Convert.ToDecimal(Amount);
                billNotice.SubmitTime = Convert.ToDateTime(DateTime.Now);
                billNotice.Status = "1";
                billNotice.CardNo = UserName;
                billNotice.Currency = "RMB";

                billNotice.Names = Names;
                billNotice.Tel = Tel;
                billNotice.Mark = Mark; //申请活动项目


                bool con = BLL.Ezun.BankManager.AddBillNotice2(billNotice);
                return con;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //修改存款状态
        [WebMethod(true)]
        public bool UpdateBillNotice(string bankno)
        {
            try
            {
                bool con = BLL.Ezun.BankManager.UpdateBillNotice(bankno);
                return con;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod(true)]
        public bool InsertBillNotice(string Amount, string bank, string bankno, string type, string cardNo, string Names, string UserName, string Tel)
        {
            //if (Session[ProjectConfig.LOGINUSER] == null)
            //{
            //    return false;
            //}

            try
            {
                if (string.IsNullOrEmpty(cardNo))
                {
                    return false;   //银行卡号为空
                }
                Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
                BillNotice billNotice = new BillNotice();
                if (user != null)
                {
                    billNotice.UserName = user.UserName;
                }
                else
                {
                    billNotice.UserName = UserName;
                }
                int counts = DAL.Ezun.BankService.SelectBillNoticenum(bankno);
                if (counts > 0)
                {
                    return false;
                }

                billNotice.Bankcn = bank;
                billNotice.Banktw = bank;

                billNotice.Type = type;
                billNotice.Amount = Convert.ToDecimal(Amount);
                billNotice.SubmitTime = Convert.ToDateTime(DateTime.Now);
                billNotice.Status = "1";
                billNotice.CardNo = cardNo;
                billNotice.Currency = "RMB";
                billNotice.Bankno = bankno;
                billNotice.Names = Names;
                billNotice.Tel = Tel;


                bool con = BLL.Ezun.BankManager.AddBillNotice(billNotice);
                return con;
            }
            catch (Exception)
            {
                return false;
            }
        }



        [WebMethod(true)]
        public string GetBankInfoAll1(string lan)
        {
            if (Session[ProjectConfig.LOGINUSER] == null)
            {
                return "";
            }

            try
            {
                Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
                //return BLL.BankManager.GetBankInfoAll(lan, user.Currency);
                return DAL.Ezun.BankService.GetBankInfoAll(lan, user.Currency);
            }
            catch (Exception)
            {
                return "";
            }
        }

        #region 存款，取款，红利，返水（查询）
        /// <summary>
        ///  查询出转向EA，转向总帐成功通过查询（一起查）
        /// </summary>
        /// <param name="type"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <param name="lan"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string GetBillNotice_sum(string time1, string time2, string lan)
        {
            if (Session[ProjectConfig.LOGINUSER] == null)
            {
                return "";
            }

            try
            {
                Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
                return BLL.Ezun.BankManager.GetBillNotice_sum(user.UserName, time1, time2, lan);
            }
            catch (Exception)
            {
                return "";
            }
        }
        [WebMethod(true)]
        public string GetBillNotice(string type, string time1, string time2, string lan,string acct_login, string acct_id)
        {
            if (acct_login == "" || acct_id == "")
            {
                return "";
            }
            else
            {
                try
                {                    

                    return BLL.Ezun.BankManager.GetBillNotice(acct_login, type, time1, time2, lan);
                }
                catch (Exception)
                {
                    return "";
                }
            }

          
        }
         [WebMethod(true)]
        public string GetBillNotice_918sun(string type, string time1, string time2, string lan, string acct_login, string acct_id)
        {


            string cookieId = System.Web.HttpContext.Current.Response.Cookies["acct_id"].Value;
            if (cookieId != acct_id && acct_login != "")
            {
                return "";
            }
            else {
                try
                {

                    return BLL.Ezun.BankManager.GetBillNotice(acct_login, type, time1, time2, lan);
                }
                catch (Exception)
                {
                    return "";
                }
            }

           
        }

        
         [WebMethod(EnableSession = true)]
         public string GetBillNoticeHistory(string type, string time1, string time2, string lan, string acct_login, string acct_id)
         {
            // HttpContext.Current.Response.Cookies.Add(new HttpCookie("a", "123"));
             //string cookieId = System.Web.HttpContext.Current.Response.Cookies["tgp_cuser"].Value;
             if (acct_login == "" || acct_id == "")
             {
                 return "";
             }
             else
             {
                 try
                 {

                     return BLL.Ezun.BankManager.GetBillNoticeHistory(acct_login, type, time1, time2, lan);
                 }
                 catch (Exception)
                 {
                     return "";
                 }
             }

           
         }






        [WebMethod(true)]
        public string GetBillAll(string type, string status, string time1, string time2, string lan, string limit)
        {
            if (Session[ProjectConfig.LOGINUSER] == null)
            {
                return "";
            }

            Model.User user = (Model.User)Session[ProjectConfig.LOGINUSER];
            DAL.Ezun.BankService bs = new DAL.Ezun.BankService();
            return bs.GetBillAll(user.UserName, type, status, time1, time2, lan, limit);
        }

        //[WebMethod(true)]
        //public string GetBillNoticeHistory(string type, string time1, string time2, string lan)
        //{
        //    if (Session[ProjectConfig.LOGINUSER] == null)
        //    {
        //        return "";
        //    }


        //    try
        //    {
        //        Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
        //        return BLL.Ezun.BankManager.GetBillNoticeHistory(user.UserName, type, time1, time2, lan);
        //    }
        //    catch (Exception)
        //    {
        //        return "";
        //    }
        //}
        #endregion

        /// <summary>
        /// 插入银行卡
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cardNo"></param>
        /// <param name="bankID"></param>
        /// <param name="province"></param>
        /// <param name="city"></param>
        /// <param name="branch"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool InsertBankList(string name, string cardNo, string bankID, string province, string city, string branch)
        {
            if (Session[ProjectConfig.LOGINUSER] == null)
            {
                return false;
            }
            name = name.Trim();
            cardNo = cardNo.Trim();
            try
            {
                Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
                string bit = DAL.Ezun.BankService.GetBankList(user.UserName, "cn");
                if (!string.IsNullOrEmpty(bit))
                {
                    return false;
                }
                return DAL.Ezun.BankService.InsertBankList(user.Name, user.UserName, cardNo, bankID, province, city, branch);
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 更新银行卡
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cardNo"></param>
        /// <param name="bankID"></param>
        /// <param name="province"></param>
        /// <param name="city"></param>
        /// <param name="branch"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool UpdateBankList(string name, string cardNo, string bankID, string province, string city, string branch)
        {
            if (Session[ProjectConfig.LOGINUSER] == null)
            {
                return false;
            }

            try
            {
                Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
                return DAL.Ezun.BankService.UpdateBankList(name, user.UserName, cardNo, bankID, province, city, branch);
            }
            catch (Exception)
            {
                return false;
            }
        }
        [WebMethod(true)]
        public string GetBankList(string lan)
        {
            if (Session[ProjectConfig.LOGINUSER] == null)
            {
                return "";
            }

            try
            {
                Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
                return DAL.Ezun.BankService.GetBankList(user.UserName, lan);
            }
            catch (Exception)
            {
                return "";
            }
        }
        //绑定银行卡信息操作
        [WebMethod(true)]
        public string InsertBanknfo(string username, string moneypassword)
        {
            bool isTCpassword = DAL.BankService.isTureAnswer(username, moneypassword);
            if (!isTCpassword)
            {
                return "0";  //密保不正确
            }
            else {
                return "1";
            }
        }

        #region  EZUN-->EA款项(对接)
        /// <summary>
        /// 提交提款
        /// </summary>
        /// <param name="money"></param>
        /// <param name="bank"></param>
        /// <param name="bankaccount"></param>
        /// <param name="bankno"></param>
        /// <param name="type"></param>
        /// <param name="cardNo"></param>
        /// <param name="bankTime"></param>
        /// <param name="tel"></param>
        /// <param name="payType"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string InsertBillNotice1(string userName, string TCpassword, string money, string bank, string bankaccount, string bankno, string type, string cardNo, string bankTime, string tel, string payType, string yzm)
        {
            if (userName == "")
            {
                return "";
            }

            try
            {
                string userNames = "";
                Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
                if (user != null)
                {
                    userNames = user.UserName;
                }
                else
                {
                    userNames = userName;
                }
                //判断取款安全密码是否正确
                bool isTCpassword = DAL.BankService.isTureAnswer(userName, TCpassword);
                if (!isTCpassword)
                {
                    return "113";  //密保不正确
                }
                //判断是否跟姓名一致bankaccount
                if (bankaccount != "")
                {
                    string Names = DAL.UserService.NameFormUsername(userNames);
                    if (bankaccount != Names)
                    {
                        return "1112";
                    }
                }
                else
                {
                    return "1111";
                }
                ////判断余额是否足够
                //Decimal balance = BLL.BankManager.GetUserBalance(user.UserName);
                //if (Convert.ToDecimal(money) > balance)
                //{
                //    return "112";   //余额不足
                //}

                #region 按级数限制取款次数
                string UserLeve = DAL.BankService.IsUserLevel(userNames);
                //if (UserLeve != "")
                //{
                //    string userNameLeve = "";
                //    try
                //    {
                //        userNameLeve = DAL.BankService.IsLevel(Convert.ToInt32(UserLeve));
                //    }
                //    catch (Exception)
                //    {

                //        userNameLeve = "普通会员";
                //    }

                //    if (userNameLeve == "普通会员")
                //    {
                //        int bit = 3;   //每天3次
                //        if (DAL.BankService.IsWithDrawal(userNames) > bit)
                //        {
                //            return "118";   //超出每天提款3次数
                //        }
                //    }
                //    else if (userNameLeve == "黄金VIP")
                //    {
                //        int bit = 5;   //每天5次
                //        if (DAL.BankService.IsWithDrawal(userNames) > bit)
                //        {
                //            return "119";   //超出每天提款5次数
                //        }
                //    }
                //    else
                //    {

                //    }
                //}
                #endregion
                int bit = 3;   //每天3次
                if (DAL.BankService.IsWithDrawal(userNames) >= bit)
                {
                    return "118";   //超出每天提款3次数
                }



                BillNotice billNotice = new BillNotice();
                if (bank != "")
                {
                    billNotice.Bankcn = bank;
                    billNotice.Banktw = bank;
                    billNotice.Banken = bank;
                    billNotice.Bankth = bank;
                }

                billNotice.UserName = userNames;
                billNotice.Type = type;
                billNotice.Amount = Convert.ToDecimal(money);
                billNotice.SubmitTime = Convert.ToDateTime(DateTime.Now);
                billNotice.Status = "1";
                billNotice.CardNo = cardNo;
                billNotice.Currency = "RMB";
                billNotice.Bankaccount = bankaccount;
                billNotice.Bankno = bankno;
                billNotice.BankTime = bankTime;
                billNotice.Tel = "";
                //billNotice.Names = user.FirstName + " " + user.LastName;
                billNotice.Names = bankaccount;
                billNotice.payType = "1";
                //bool con = BLL.BankManager.AddBillNotice(billNotice);
                string con = DAL.Ezun.BankService.AddBillNotice1(billNotice);
                //if (type == "2")
                //{
                //    if (con!="")
                //    {
                //        DAL.Ezun.BankService.UpdateBalance(user.ID, Convert.ToDecimal(money));
                //    }
                //}
                return con;
            }
            catch (Exception)
            {
                return "-1";
            }
        }

        /// <summary>
        /// 平台转入EA款
        /// </summary>
        /// <param name="money"></param>
        /// <param name="bank"></param>
        /// <param name="bankaccount"></param>
        /// <param name="bankno"></param>
        /// <param name="type"></param>
        /// <param name="cardNo"></param>
        /// <param name="bankTime"></param>
        /// <param name="tel"></param>
        /// <param name="payType"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string InsertBillNotice2(string money, string bank, string bankaccount, string bankno, string type, string bankTime, string tel, string payType, string username)
        {
            if (Session[ProjectConfig.LOGINUSER] == null)
            {
                return "";
            }

            string con = "ok";
            try
            {
                Decimal balance = BLL.BankManager.GetUserBalance(username);
                if (balance < Convert.ToDecimal(money))
                {
                    return "-8";
                }

                Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
                BillNotice billNotice = new BillNotice();
                billNotice.Bankcn = "";
                billNotice.UserName = user.UserName;
                billNotice.Type = type;
                billNotice.Amount = Convert.ToDecimal(money);
                billNotice.SubmitTime = Convert.ToDateTime(DateTime.Now);
                billNotice.Status = "1";
                billNotice.CardNo = "";
                billNotice.Currency = user.Currency;
                billNotice.Bankaccount = bankaccount;
                billNotice.Bankno = bankno;
                billNotice.BankTime = bankTime;
                billNotice.Tel = tel;
                billNotice.Names = "";
                billNotice.payType = payType;
                //叉入待定转款信息
                try
                {
                    BillNotice istureNotice = BLL.BankManager.IsTrueNoticeHistory(username);
                    if (istureNotice != null)
                    {

                        BillNoticeHistory billhistory = new BillNoticeHistory();
                        billhistory.Currency = "RMB";
                        billhistory.UserName = user.UserName;
                        billhistory.Type = type;
                        billhistory.SubmitTime = Convert.ToDateTime(DateTime.Now);
                        billhistory.UpdateTime = Convert.ToDateTime(DateTime.Now);
                        billhistory.Status = "3";
                        billhistory.Reasoncn = "EZUN转向EA款失败";
                        billhistory.Names = user.Name;
                        billhistory.Mark = "EZUN转向EA款失败";
                        bool istrue = DAL.BankhistoryService.InBillNoticeHistoryWrong(billhistory);
                        if (istrue)
                        {
                            BankManager.DeleteBillNoticeByID(istureNotice.Id.ToString());
                        }
                        return "-3";  //有待定存款信息


                    }
                    else
                    {
                        string istrue = DAL.Ezun.BankService.AddBillNotice1(billNotice);
                        if (istrue == "")
                        {
                            return "-1";
                        }
                    }


                }
                catch (Exception)
                {
                    return "-1"; //存款待定叉入失败
                }



                #region 接口调用
                //发送                  
                string id = StringHelper.getOrder("存款");
                string id2 = StringHelper.getOrder("");
                string xmls = "";
                string sid = "3";
                //EA测试账号
                if (user.UserName == "gstest01" || user.UserName == "gstest02" || user.UserName == "gstest03" || user.UserName == "gstest04" || user.UserName == "gstest05")
                {
                    sid = "2";
                }
                xmls += "<?xml version=\"1.0\"?>";
                xmls += "<request action=\"cdeposit\">";
                xmls += "<element id=\"" + id + "\">";
                xmls += "<properties name=\"userid\">" + user.UserName + "</properties>";
                xmls += "<properties name=\"acode\">" + user.parentcode + "</properties>";
                xmls += "<properties name=\"vendorid\">" + sid + "</properties>";
                xmls += "<properties name=\"currencyid\">156</properties>";
                xmls += "<properties name=\"amount\">" + Convert.ToDecimal(money) + "</properties>";
                xmls += "<properties name=\"refno\">" + id2 + "</properties>";

                xmls += "</element>";
                xmls += "</request>";
                //测试
                //string rxmls = BankManager.PostData("https://testmis.ea3-mission.com/configs/external/deposit/gs/server.php", xmls, System.Text.Encoding.UTF8);
                //正式
                string rxmls = BankManager.PostData("https://mis.ea3-mission.com/configs/external/deposit/gs/server.php", xmls, System.Text.Encoding.UTF8);

                string ids = "";
                string acode = "";// 合营商代
                string status = ""; //返回状态
                string paymentid = ""; //在真人娱乐场的交易ID
                string errdesc = ""; //错误信息非零答覆            

                XmlDocument doc = new XmlDocument();
                try
                {
                    //接受后解析XML
                    doc.LoadXml(rxmls.Trim());
                    XmlNode xn = doc.SelectSingleNode("/request/element");
                    XmlElement et = (XmlElement)xn;
                    ids = et.GetAttribute("id");
                    XmlNodeList xnList = doc.SelectNodes("/request/element/properties");
                    acode = xnList[0].InnerText;
                    status = xnList[1].InnerText;
                    paymentid = xnList[3].InnerText;
                    errdesc = xnList[4].InnerText;

                    // 接口通过，修改用户金额(减去)
                    if (status == "0")
                    {
                        if (con != "-1")
                        {
                            // DAL.Ezun.BankService.UpdateBalance(user.ID, Convert.ToDecimal(money));
                            VerifyBillNotice2("2", "", "", money, user.UserName);
                        }

                    }
                    else if (status == "003") { VerifyBillNoticeEZUN("3", "", "", money, user.UserName); con = "003"; }//错误：无效操作
                    else if (status == "201") { VerifyBillNoticeEZUN("3", "", "", money, user.UserName); con = "201"; }//(错误：无效请求)
                    else if (status == "202") { VerifyBillNoticeEZUN("3", "", "", money, user.UserName); con = "202"; }//(错误：数据库操作错误)
                    else if (status == "204") { VerifyBillNoticeEZUN("3", "", "", money, user.UserName); con = "204"; }//(错误：超出限定金额)
                    else if (status == "205") { VerifyBillNoticeEZUN("3", "", "", money, user.UserName); con = "205"; }//(错误：无效商家)
                    else if (status == "206") { VerifyBillNoticeEZUN("3", "", "", money, user.UserName); con = "206"; }//(错误：用户被锁定)
                    else if (status == "211") { VerifyBillNoticeEZUN("3", "", "", money, user.UserName); con = "211"; }//(错误：客户在游戏)
                    else if (status == "401") { VerifyBillNoticeEZUN("3", "", "", money, user.UserName); con = "401"; }//(错误：重复参考号码)
                    else if (status == "402") { VerifyBillNoticeEZUN("3", "", "", money, user.UserName); con = "402"; }//(错误：无效前缀|无效IP)
                    else if (status == "403") { VerifyBillNoticeEZUN("3", "", "", money, user.UserName); con = "403"; }//(错误：无效金额)
                    else if (status == "404") { VerifyBillNoticeEZUN("3", "", "", money, user.UserName); con = "404"; }//(错误：无效小数点)
                    else if (status == "505") { VerifyBillNoticeEZUN("3", "", "", money, user.UserName); con = "505"; }//(错误：返回无效合营商代码)
                    else if (status == "701") { VerifyBillNoticeEZUN("3", "", "", money, user.UserName); con = "701"; }//(错误：数据库控制)
                    else { VerifyBillNotice2("3", "", "", money, user.UserName); con = "-1"; }

                    //提交确认信息，看是否成功，以status=0为成功，其它EA当不成功
                    string xmls2 = "";
                    xmls2 += "<?xml version=\"1.0\"?>";
                    xmls2 += "<request action=\"cdeposit-confirm\">";
                    xmls2 += "<element id=\"" + ids + "\">";
                    xmls2 += "<properties name=\"acode\">" + user.parentcode + "</properties>";
                    xmls2 += "<properties name=\"status\">" + status + "</properties>";
                    xmls2 += "<properties name=\"paymentid\">" + paymentid + "</properties>";
                    xmls2 += "<properties name=\"errdesc\">" + errdesc + "</properties>";
                    xmls2 += "</element>";
                    xmls2 += "</request>";
                    string rxmls2 = BankManager.PostData("https://mis.ea3-mission.com/configs/external/deposit/gs/server.php", xmls2, System.Text.Encoding.UTF8);
                }

                catch (Exception ex)
                {
                    VerifyBillNotice2("3", "", "", money, user.UserName);
                    return "-2";  //接口加载xml失败  
                }

                #endregion


                return con;
            }
            catch (Exception)
            {
                return "-1";
            }
        }


        [WebMethod(true)]
        public string VerifyBillNotice(string status, string reason, string id, string validAmount, string username)
        {
            if (Session[ProjectConfig.LOGINUSER] == null)
            {
                return "";
            }

            //先判定billnotice表中，此用户是否有待定信息，没有将执行下面，有则此返回提示
            try
            {


                BillNotice billNotice = BLL.BankManager.GetBillNotice(id);
                RefusedList refuseReason = new RefusedList();
                string valid = validAmount == "" ? billNotice.Amount.ToString() : validAmount;
                Decimal balance = BLL.BankManager.GetUserBalance(billNotice.UserName);
                if (status == "2" && billNotice.Type == "2" && balance < Convert.ToDecimal(valid))
                {
                    return "nomoney";
                }
                try
                {
                    if (status == "3")//
                    {
                        // BLL.BankManager.UpdateBalance(valid, billNotice.UserName, "1");
                        balance += Convert.ToDecimal(valid);
                    }
                    if (reason != "")
                    {
                        refuseReason = BLL.BankManager.GetReasonByID(reason);
                    }
                    BillNoticeHistory billNoticeHistory = new BillNoticeHistory();
                    billNoticeHistory.UserName = billNotice.UserName;
                    billNoticeHistory.Type = billNotice.Type;
                    billNoticeHistory.Amount = billNotice.Amount;
                    billNoticeHistory.SubmitTime = billNotice.SubmitTime;
                    billNoticeHistory.UpdateTime = Convert.ToDateTime(DateTime.Now);
                    billNoticeHistory.Status = status;
                    billNoticeHistory.Reasoncn = refuseReason.Reasoncn;
                    billNoticeHistory.Reasontw = refuseReason.Reasontw;
                    billNoticeHistory.Reasonen = refuseReason.Reasonen;
                    billNoticeHistory.Reasonth = refuseReason.Reasonth;
                    billNoticeHistory.Reasonvn = refuseReason.Reasonvn;
                    billNoticeHistory.Bankcn = billNotice.Bankcn;
                    billNoticeHistory.Banktw = billNotice.Banktw;
                    billNoticeHistory.Banken = billNotice.Banken;
                    billNoticeHistory.Bankth = billNotice.Bankth;
                    billNoticeHistory.Bankno = billNotice.Bankno;
                    billNoticeHistory.CardNo = billNotice.CardNo;
                    billNoticeHistory.Bankaccount = billNotice.Bankaccount;
                    billNoticeHistory.BankTime = billNotice.BankTime;
                    billNoticeHistory.Currency = billNotice.Currency;
                    billNoticeHistory.Names = billNotice.Names;
                    billNoticeHistory.Tel = billNotice.Tel;
                    billNoticeHistory.ValidAmount = Convert.ToDecimal(valid);
                    BLL.BankManager.InsertBillNoticeHistory(billNoticeHistory);
                    BillDetail billDetail = new BillDetail();
                    billDetail.UserName = billNoticeHistory.UserName;
                    billDetail.Type = billNoticeHistory.Type;
                    billDetail.InAmount = billNoticeHistory.Type == "1" ? billNoticeHistory.ValidAmount : 0;
                    billDetail.OutAmount = billNoticeHistory.Type == "2" ? billNoticeHistory.ValidAmount : 0;
                    billDetail.Balance = BLL.BankManager.GetUserBalance(billNoticeHistory.UserName);
                    billDetail.BillTime = Convert.ToDateTime(DateTime.Now);
                    billDetail.CardNo = billNoticeHistory.CardNo;
                    billDetail.Currency = billNoticeHistory.Currency;
                    billDetail.Names = billNoticeHistory.Names;
                    if (status != "3")
                    {
                        BLL.BankManager.InsertBillDetail(billDetail);
                    }
                    BLL.BankManager.DeleteBillNoticeByID(id);

                }
                catch (Exception)
                {
                    return "-1";
                }
                return "{\"a\":\"" + balance + "\",\"b\":\"" + valid + "\",\"c\":\"" + billNotice.Amount + "\"}";
            }
            catch (Exception)
            {

                return "-1";
            }



        }


        /// <summary>
        /// 当跟EA对接失败或者返回EORR信息时，删除notice表中信息
        /// </summary>
        /// <param name="status"></param>
        /// <param name="reason"></param>
        /// <param name="id"></param>
        /// <param name="validAmount"></param>
        /// <param name="username"></param>
        /// <returns></returns>

        [WebMethod(true)]
        public string VerifyBillNotice2(string status, string reason, string id, string validAmount, string username)
        {
            if (Session[ProjectConfig.LOGINUSER] == null)
            {
                return "";
            }

            Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
            BillNotice billNotice = BLL.BankManager.GetBillNotices(username);
            RefusedList refuseReason = new RefusedList();
            //string valid = validAmount == "" ? "0" : validAmount;
            Decimal balance = BLL.BankManager.GetUserBalance(billNotice.UserName);
            if (balance < Convert.ToDecimal(validAmount))
            {
                return "nomoney";
            }
            try
            {
                if (status == "2" && billNotice.Type == "5")
                {

                    DAL.Ezun.BankService.UpdateBalance(user.ID, Convert.ToDecimal(validAmount));
                    // BLL.BankManager.UpdateBalance(valid, billNotice.UserName, "1");
                    balance = balance - Convert.ToDecimal(validAmount);
                }
                if (reason != "")
                {
                    refuseReason = BLL.BankManager.GetReasonByID(reason);
                }
                BillNoticeHistory billNoticeHistory = new BillNoticeHistory();
                billNoticeHistory.UserName = billNotice.UserName;
                billNoticeHistory.Type = billNotice.Type;
                billNoticeHistory.Amount = billNotice.Amount;
                billNoticeHistory.SubmitTime = billNotice.SubmitTime;
                billNoticeHistory.UpdateTime = Convert.ToDateTime(DateTime.Now);
                billNoticeHistory.Status = status;
                if (status == "2")
                {
                    billNoticeHistory.Reasoncn = "EZUN转向EA成功";
                    billNoticeHistory.Reasontw = "EZUN转向EA成功";
                    billNoticeHistory.Reasonen = "EZUN转向EA成功";
                    billNoticeHistory.Reasonth = "EZUN转向EA成功";
                    billNoticeHistory.Reasonvn = "EZUN转向EA成功";
                    billNoticeHistory.Mark = "EZUN转向EA成功";
                }
                else
                {
                    billNoticeHistory.Reasoncn = "EZUN转向EA失败";
                    billNoticeHistory.Reasontw = "EZUN转向EA失败";
                    billNoticeHistory.Reasonen = "EZUN转向EA失败";
                    billNoticeHistory.Reasonth = "EZUN转向EA失败";
                    billNoticeHistory.Reasonvn = "EZUN转向EA失败";
                    billNoticeHistory.Mark = "EZUN转向EA失败";
                }

                billNoticeHistory.Bankcn = billNotice.Bankcn;
                billNoticeHistory.Banktw = billNotice.Banktw;
                billNoticeHistory.Banken = billNotice.Banken;
                billNoticeHistory.Bankth = billNotice.Bankth;
                billNoticeHistory.Bankno = billNotice.Bankno;
                billNoticeHistory.CardNo = billNotice.CardNo;
                billNoticeHistory.Bankaccount = billNotice.Bankaccount;
                billNoticeHistory.BankTime = billNotice.BankTime;
                billNoticeHistory.Currency = "RMB";
                billNoticeHistory.Names = user.Name;
                billNoticeHistory.Tel = user.Tel;
                billNoticeHistory.ValidAmount = Convert.ToDecimal(validAmount);
                BLL.BankManager.InsertBillNoticeHistory(billNoticeHistory);
                BillDetail billDetail = new BillDetail();
                billDetail.UserName = billNoticeHistory.UserName;
                billDetail.Type = billNoticeHistory.Type;
                billDetail.InAmount = billNoticeHistory.Type == "1" ? billNoticeHistory.ValidAmount : 0;
                billDetail.OutAmount = billNoticeHistory.Type == "2" ? billNoticeHistory.ValidAmount : 0;
                billDetail.Balance = BLL.BankManager.GetUserBalance(billNoticeHistory.UserName);
                billDetail.BillTime = Convert.ToDateTime(DateTime.Now);
                billDetail.CardNo = billNoticeHistory.CardNo;
                billDetail.Currency = billNoticeHistory.Currency;
                billDetail.Names = billNoticeHistory.Names;
                if (status != "3")
                {
                    BLL.BankManager.InsertBillDetail(billDetail);
                }
                BLL.BankManager.DeleteBillNoticeByIDEA(username);

            }
            catch (Exception)
            {
                return "-1";
            }
            return "{\"a\":\"" + balance + "\",\"b\":\"" + validAmount + "\",\"c\":\"" + billNotice.Amount + "\"}";



        }

        #endregion

        #region EA-->EZUN款项(对接)
        /// <summary>
        /// 平台转入EA款
        /// </summary>
        /// <param name="money"></param>
        /// <param name="bank"></param>
        /// <param name="bankaccount"></param>
        /// <param name="bankno"></param>
        /// <param name="type"></param>
        /// <param name="cardNo"></param>
        /// <param name="bankTime"></param>
        /// <param name="tel"></param>
        /// <param name="payType"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string InsertBillNoticeEZUN(string money, string bank, string bankaccount, string bankno, string type, string bankTime, string tel, string payType, string username)
        {
            if (Session[ProjectConfig.LOGINUSER] == null)
            {
                return "";
            }

            string con = "";
            try
            {
                Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
                BillNotice billNotice = new BillNotice();
                billNotice.Bankcn = "";
                billNotice.UserName = user.UserName;
                billNotice.Type = type;
                billNotice.Amount = Convert.ToDecimal(money);
                billNotice.SubmitTime = Convert.ToDateTime(DateTime.Now);
                billNotice.Status = "1";
                billNotice.CardNo = "";
                billNotice.Currency = user.Currency;
                billNotice.Bankaccount = bankaccount;
                billNotice.Bankno = bankno;
                billNotice.BankTime = bankTime;
                billNotice.Tel = tel;
                billNotice.Names = "";
                billNotice.payType = payType;
                //叉入待定转款信息
                try
                {
                    BillNotice istureNotice = BLL.BankManager.IsTrueNoticeHistoryEZUN(username);
                    if (istureNotice != null)
                    {
                        BillNoticeHistory billhistory = new BillNoticeHistory();
                        billhistory.Currency = "RMB";
                        billhistory.UserName = user.UserName;
                        billhistory.Type = type;
                        billhistory.SubmitTime = Convert.ToDateTime(DateTime.Now);
                        billhistory.UpdateTime = Convert.ToDateTime(DateTime.Now);
                        billhistory.Status = "3";
                        billhistory.Reasoncn = "EA转向EZUN款失败";
                        billhistory.Names = user.Name;
                        billhistory.Mark = "EEA转向EZUN款失败";
                        bool istrue = DAL.BankhistoryService.InBillNoticeHistoryWrong(billhistory);
                        if (istrue)
                        {
                            BankManager.DeleteBillNoticeByID(istureNotice.Id.ToString());
                        }
                        return "-3";  //有待定存款信息

                    }
                    else
                    {
                        con = DAL.Ezun.BankService.AddBillNotice1(billNotice);
                    }


                }
                catch (Exception)
                {
                    return "-1"; //存款待定叉入失败
                }



                #region 接口调用
                //发送                  
                string id = StringHelper.getOrder("提款");
                string id2 = StringHelper.getOrder("");
                string xmls = "";
                string sid = "3";
                //EA测试账号
                if (user.UserName == "gstest01" || user.UserName == "gstest02" || user.UserName == "gstest03" || user.UserName == "gstest04" || user.UserName == "gstest05")
                {
                    sid = "2";
                }
                xmls += "<?xml version=\"1.0\"?>";
                xmls += "<request action=\"cwithdrawal\">";

                xmls += "<element id=\"" + id + "\">";
                xmls += "<properties name=\"userid\">" + user.UserName + "</properties>";
                xmls += "<properties name=\"vendorid\">" + sid + "</properties>";
                xmls += "<properties name=\"currencyid\">156</properties>";
                xmls += "<properties name=\"amount\">" + Convert.ToDecimal(money) + "</properties>";
                xmls += "<properties name=\"refno\">" + id2 + "</properties>";
                xmls += "</element>";
                xmls += "</request>";
                //测试
                //string rxmls = BankManager.PostData("https://testmis.ea3-mission.com/configs/external/withdrawal/gs/server.php", xmls, System.Text.Encoding.UTF8);
                //正式
                string rxmls = BankManager.PostData("https://mis.ea3-mission.com/configs/external/withdrawal/gs/server.php", xmls, System.Text.Encoding.UTF8);

                string ids = "";

                string status = ""; //返回状态
                string refno = "";//参考号码
                string paymentid = ""; //在真人娱乐场的交易ID
                string errdesc = ""; //错误信息非零答覆            

                XmlDocument doc = new XmlDocument();
                try
                {
                    //接受后解析XML
                    doc.LoadXml(rxmls.Trim());
                    XmlNode xn = doc.SelectSingleNode("/request/element");
                    XmlElement et = (XmlElement)xn;
                    ids = et.GetAttribute("id");
                    XmlNodeList xnList = doc.SelectNodes("/request/element/properties");

                    status = xnList[0].InnerText;
                    refno = xnList[1].InnerText;
                    paymentid = xnList[2].InnerText;
                    errdesc = xnList[3].InnerText;

                    // 接口通过，修改用户金额(减去)
                    if (status == "0")
                    {
                        if (con != "-1")
                        {
                            // DAL.Ezun.BankService.UpdateBalanceEZUN(user.ID, Convert.ToDecimal(money));
                            VerifyBillNoticeEZUN("2", "", "", money, user.UserName);
                        }

                    }
                    else if (status == "213") //在某些红利促销里，玩家需累积足够的押码总额方可以进行提款。请确定押码总额已经达到
                    {
                        VerifyBillNoticeEZUN("3", "", "", money, user.UserName);
                        con = "-7";
                    }
                    else if (status == "211")//(错误：客户在游戏)
                    {
                        VerifyBillNoticeEZUN("3", "", "", money, user.UserName);
                        con = "-4";
                    }
                    else if (status == "212") //(错误：每日最大提款数)
                    {
                        VerifyBillNoticeEZUN("3", "", "", money, user.UserName);
                        con = "-5";
                    }
                    else if (status == "203")//(错误：非验证客户)
                    {
                        VerifyBillNoticeEZUN("3", "", "", money, user.UserName);
                        con = "-6";
                    }
                    else if (status == "204")//错误：超出限定金额)
                    {
                        VerifyBillNoticeEZUN("3", "", "", money, user.UserName);
                        con = "-8";
                    }
                    else
                    {
                        VerifyBillNoticeEZUN("3", "", "", money, user.UserName);
                        con = "-1";
                    }

                }

                catch (Exception ex)
                {
                    VerifyBillNoticeEZUN("3", "", "", money, user.UserName);
                    return "-2";  //接口加载xml失败  
                }

                #endregion


                return con;
            }
            catch (Exception)
            {
                return "-1";
            }
        }

        /// <summary>
        /// 转向EA平台成功后扣钱
        /// </summary>
        /// <param name="status"></param>
        /// <param name="reason"></param>
        /// <param name="id"></param>
        /// <param name="validAmount"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string VerifyBillNoticeEZUN(string status, string reason, string id, string validAmount, string username)
        {
            if (Session[ProjectConfig.LOGINUSER] == null)
            {
                return "";
            }

            Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
            //先判定billnotice表中，此用户是否有待定信息，没有将执行下面，有则此返回提示
            try
            {


                BillNotice billNotice = BLL.BankManager.GetBillNoticesEZUN(username);
                RefusedList refuseReason = new RefusedList();
                // string valid = validAmount == "" ? "0" : validAmount;
                Decimal balance = BLL.BankManager.GetUserBalance(billNotice.UserName);
                //if (balance < Convert.ToDecimal(valid))
                //{
                //    return "nomoney";
                //}
                try
                {
                    if (status == "2" && billNotice.Type == "6")
                    {
                        //  DAL.Ezun.BankService.UpdateBalanceEZUN(user.ID, Convert.ToDecimal(valid));
                        DAL.Ezun.BankService.UpdateBalanceA(user.ID, Convert.ToDecimal(validAmount));
                        //  BLL.BankManager.UpdateBalance(valid, billNotice.UserName, "1");
                        balance += Convert.ToDecimal(validAmount);
                    }
                    if (reason != "")
                    {
                        refuseReason = BLL.BankManager.GetReasonByID(reason);
                    }
                    BillNoticeHistory billNoticeHistory = new BillNoticeHistory();
                    billNoticeHistory.UserName = billNotice.UserName;
                    billNoticeHistory.Type = billNotice.Type;
                    billNoticeHistory.Amount = billNotice.Amount;
                    billNoticeHistory.SubmitTime = billNotice.SubmitTime;
                    billNoticeHistory.UpdateTime = Convert.ToDateTime(DateTime.Now);
                    billNoticeHistory.Status = status;
                    if (status == "2")
                    {
                        billNoticeHistory.Reasoncn = "EZUN转向EA成功";
                        billNoticeHistory.Reasontw = "EZUN转向EA成功";
                        billNoticeHistory.Reasonen = "EZUN转向EA成功";
                        billNoticeHistory.Reasonth = "EZUN转向EA成功";
                        billNoticeHistory.Reasonvn = "EZUN转向EA成功";
                        billNoticeHistory.Mark = "EZUN转向EA成功";
                    }
                    else
                    {
                        billNoticeHistory.Reasoncn = "EZUN转向EA失败";
                        billNoticeHistory.Reasontw = "EZUN转向EA失败";
                        billNoticeHistory.Reasonen = "EZUN转向EA失败";
                        billNoticeHistory.Reasonth = "EZUN转向EA失败";
                        billNoticeHistory.Reasonvn = "EZUN转向EA失败";
                        billNoticeHistory.Mark = "EZUN转向EA失败";
                    }
                    billNoticeHistory.Bankcn = billNotice.Bankcn;
                    billNoticeHistory.Banktw = billNotice.Banktw;
                    billNoticeHistory.Banken = billNotice.Banken;
                    billNoticeHistory.Bankth = billNotice.Bankth;
                    billNoticeHistory.Bankno = billNotice.Bankno;
                    billNoticeHistory.CardNo = billNotice.CardNo;
                    billNoticeHistory.Bankaccount = billNotice.Bankaccount;
                    billNoticeHistory.BankTime = billNotice.BankTime;
                    billNoticeHistory.Currency = "RMB";
                    billNoticeHistory.Names = user.Name;
                    billNoticeHistory.Tel = user.Tel;
                    billNoticeHistory.ValidAmount = Convert.ToDecimal(validAmount);
                    BLL.BankManager.InsertBillNoticeHistory(billNoticeHistory);
                    BillDetail billDetail = new BillDetail();
                    billDetail.UserName = billNoticeHistory.UserName;
                    billDetail.Type = billNoticeHistory.Type;
                    billDetail.InAmount = billNoticeHistory.Type == "1" ? billNoticeHistory.ValidAmount : 0;
                    billDetail.OutAmount = billNoticeHistory.Type == "2" ? billNoticeHistory.ValidAmount : 0;
                    billDetail.Balance = BLL.BankManager.GetUserBalance(billNoticeHistory.UserName);
                    billDetail.BillTime = Convert.ToDateTime(DateTime.Now);
                    billDetail.CardNo = billNoticeHistory.CardNo;
                    billDetail.Currency = billNoticeHistory.Currency;
                    billDetail.Names = billNoticeHistory.Names;
                    if (status != "3")
                    {
                        BLL.BankManager.InsertBillDetail(billDetail);
                    }
                    BLL.BankManager.DeleteBillNoticeByIDEZUN(username);

                }
                catch (Exception)
                {
                    return "-1";
                }
                return "{\"a\":\"" + balance + "\",\"b\":\"" + validAmount + "\",\"c\":\"" + billNotice.Amount + "\"}";
            }
            catch (Exception)
            {

                return "-1";
            }



        }
        #endregion
        /// <summary>
        /// 选择银行后绑定卡号和户名
        /// </summary>
        /// <returns></returns>
        [WebMethod(true)]
        public string GetBankInfos(int id)
        {
            if (Session[ProjectConfig.LOGINUSER] == null)
            {
                return "";
            }

            try
            {
                Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
                return BLL.Ezun.BankManager.GetBankInfos(id);
            }
            catch (Exception)
            {
                return "";
            }
        }
        /// <summary>
        /// 初次加载工商银行与绑定数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string GetBankInfos4()
        {
            if (Session[ProjectConfig.LOGINUSER] == null)
            {
                return "";
            }

            try
            {
                Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
                return BLL.Ezun.BankManager.GetBankInfos4();
            }
            catch (Exception)
            {
                return "";
            }
        }

        #region PT对转
        [WebMethod(true)]
        public string PTInsertBillNotice(string money)
        {
            if (Session[ProjectConfig.LOGINUSER] == null)
            {
                return "";
            }

            try
            {

                Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
                Decimal balance = BLL.BankManager.GetUserBalance(user.UserName);//查询余额是否够转出
                if (balance < Convert.ToDecimal(money.Trim()))
                {
                    return "nomoney";
                }
                else
                {
                    DAL.Ezun.BankService.UpdateBalance(user.ID, Convert.ToDecimal(money.Trim()));  //如果余额可转，先扣除此笔款项目 
                }

                BillNotice billNotice = new BillNotice();
                billNotice.Bankcn = "";
                billNotice.UserName = user.UserName;
                billNotice.Type = "12";
                billNotice.Amount = Convert.ToDecimal(money.Trim());
                billNotice.SubmitTime = Convert.ToDateTime(DateTime.Now);
                billNotice.Status = "1";
                billNotice.CardNo = "";
                billNotice.Currency = user.Currency;
                billNotice.Bankaccount = "";
                billNotice.Bankno = "";
                billNotice.BankTime = DateTime.Now.ToString();
                billNotice.Tel = "";
                billNotice.Names = user.Name;
                billNotice.payType = "1";

                string istrue = DAL.Ezun.BankService.AddBillNotice1(billNotice);
                if (istrue != "-1")
                {
                    return "ok";
                }
                else
                {
                    return "-1";
                }

            }
            catch (Exception)
            {
                return "-1";
            }
        }
        /// <summary>
        /// PT转总帐
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string PTTOEZUNBillNotice(string money)
        {
            if (Session[ProjectConfig.LOGINUSER] == null)
            {
                return "";
            }
            try
            {
                Model.User user = Session[ProjectConfig.LOGINUSER] as Model.User;
                int counts = DAL.Ezun.BankService.GetPTttoezunInfo(user.UserName, "13");
                if (counts > 0)
                {
                    return "one";
                }

                BillNotice billNotice = new BillNotice();
                billNotice.Bankcn = "";
                billNotice.UserName = user.UserName;
                billNotice.Type = "13";
                billNotice.Amount = Convert.ToDecimal(money.Trim());
                billNotice.SubmitTime = Convert.ToDateTime(DateTime.Now);
                billNotice.Status = "1";
                billNotice.CardNo = "";
                billNotice.Currency = user.Currency;
                billNotice.Bankaccount = "";
                billNotice.Bankno = "";
                billNotice.BankTime = DateTime.Now.ToString();
                billNotice.Tel = "";
                billNotice.Names = user.Name;
                billNotice.payType = "1";

                string istrue = DAL.Ezun.BankService.AddBillNotice1(billNotice);
                if (istrue != "-1")
                {
                    return "ok";
                }
                else
                {
                    return "-1";
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
        #endregion

    }
}
