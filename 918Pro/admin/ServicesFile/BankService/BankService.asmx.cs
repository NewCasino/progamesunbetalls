using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Model;
using Util;
using System.Data;

namespace admin.ServicesFile.BankService
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
        public string BillSummaryOfMonth(string userid, string type, string currency, string date1, string date2)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.BankManager.BillSummaryOfMonth(userid, type, currency, date1, date2);
        }
        [WebMethod(true)]
        public string VerifyBillNotice(string status, string reason, string id, string validAmount, string seef)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            BillNotice billNotice = BLL.BankManager.GetBillNotice(id);
            RefusedList refuseReason = new RefusedList();
            string valid = validAmount == "" ? billNotice.Amount.ToString() : validAmount;
            decimal userAmount = Convert.ToDecimal(valid) + Convert.ToDecimal(seef);
            Decimal balance = BLL.BankManager.GetUserBalance(billNotice.UserName);
            BillNoticeHistory billNoticeHistory = new BillNoticeHistory();
          
          
            try
            {
                if (billNotice.Type == "2")
                {
                    //取款
                    if (status == "3")
                    {
                        //拒绝
                       // BLL.BankManager.UpdateBalance(valid, billNotice.UserName, "1");
                       // balance += Convert.ToDecimal(valid);
                    }
                }
                else if (billNotice.Type == "1")
                {
                    //存款
                    if (status == "2")
                    {
                        //DataTable dt = DAL.BankService.Ishistory(billNotice.Bankno);
                        //if (dt.Rows.Count > 0)
                        //{
                        //    return "200";   //流水号已存在历史表（该笔存款已审核，不能重复审核）
                        //}
                        //存款接受
                        if (string.IsNullOrEmpty(billNotice.CardNo))
                        {
                            return "201";   //存入银行为空，拒绝该笔存款
                        }
                       
                      
                        
                        //更新首存时间
                        BLL.UserManager userBll = new BLL.UserManager();
                        Model.User user = userBll.GetUserByUserName(billNotice.UserName);
                        if (user.soucunsj == null)
                        {
                            DAL.UserService.UpdateUser(DateTime.Now, billNotice.UserName);
                        }


                    }
                }
                if (reason != "")
                {
                    refuseReason = BLL.BankManager.GetReasonByID(reason);
                }
                if (billNotice.Type == "1" && status == "2")
                {
                    //存款

                    //取银行卡计算期初余额
                    decimal bankamount1, bankamount2;
                    string nonums="";
                    //if (billNotice.Bankno.IndexOf("10s") != -1 && billNotice.Bankcn.IndexOf("刘成章") == -1)
                    //{
                    //    nonums = "汇潮支付";                                        
                    //}
                    //else if(billNotice.Bankno.IndexOf("10s") != -1 && billNotice.Bankcn.IndexOf("刘成章") != -1)
                    //{
                    //    nonums = "sammi@10sun.com";  
                    //}
                    //else {
                    //    nonums = billNotice.Bankno;                              
                    //}
                    nonums = billNotice.Bankcn;    
                    Banklistc bankInfo = DAL.BanklistcService.GetBankByCardno(nonums);
                    if (bankInfo != null)
                    {
                        bankamount1 = bankInfo.amount;
                        bankamount2 = bankInfo.amount + Convert.ToDecimal(valid) ;
                        bankInfo.amount = bankamount2;
                        //更新银行卡余额
                        BLL.BanklistcManager.UpdateBanklistc(bankInfo);

                        billNoticeHistory.sfee = Convert.ToDecimal(seef);
                        billNoticeHistory.bankamount1 = bankamount1;
                        billNoticeHistory.bankamount2 = bankamount2;
                        billNoticeHistory.bankc = bankInfo.Nameth;
                        billNoticeHistory.cardnoc = bankInfo.Cardno;
                        billNoticeHistory.banknoc = bankInfo.Bank;
                        billNoticeHistory.banknamec = bankInfo.Namecn;
                    }
                }
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
                //billNoticeHistory.Bankcn = billNotice.Bankcn;
                //billNoticeHistory.Banktw = billNotice.Banktw;
                //billNoticeHistory.Banken = billNotice.Banken;
                //billNoticeHistory.Bankth = billNotice.Bankth;
                billNoticeHistory.Bankno = billNotice.Bankno;
                billNoticeHistory.CardNo = billNotice.CardNo;
                billNoticeHistory.Bankaccount = billNotice.Bankaccount;
                billNoticeHistory.BankTime = billNotice.BankTime;
                billNoticeHistory.Currency = billNotice.Currency;
                billNoticeHistory.Names = billNotice.Names;
                billNoticeHistory.Tel = billNotice.Tel;
                billNoticeHistory.ValidAmount = Convert.ToDecimal(valid);
                billNoticeHistory.Mark = billNotice.Mark;
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
                Manager manager = Session[ProjectConfig.ADMINUSER] as Manager;
                string operer = manager.ManagerId;
                BLL.BankManager.InsertOperateLog(billNoticeHistory, operer);               

                if (status == "2")
                {
                    //存款接受，更新余额
                    BLL.BankManager.UpdateBalance(userAmount.ToString(), billNotice.UserName, "1");

                    //判断邀请码是否存

                }
            }
            catch (Exception)
            {
                return "false";
            }
            return "{\"a\":\"" + balance + "\",\"b\":\"" + valid + "\",\"c\":\"" + billNotice.Amount + "\"}";
        }



        [WebMethod(true)]
        public string VerifyBillNoticeCode(string status, string reason, string id, string validAmount, string seef ,string rcode)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            BillNotice billNotice = BLL.BankManager.GetBillNotice(id);
            RefusedList refuseReason = new RefusedList();
            string valid = validAmount == "" ? billNotice.Amount.ToString() : validAmount;
            decimal userAmount = Convert.ToDecimal(valid) + Convert.ToDecimal(seef);
            Decimal balance = BLL.BankManager.GetUserBalance(billNotice.UserName);
            BillNoticeHistory billNoticeHistory = new BillNoticeHistory();


            try
            {
                if (billNotice.Type == "2")
                {
                    //取款
                    if (status == "3")
                    {
                        //拒绝
                        // BLL.BankManager.UpdateBalance(valid, billNotice.UserName, "1");
                        // balance += Convert.ToDecimal(valid);
                    }
                }
                else if (billNotice.Type == "1")
                {
                    //存款
                    if (status == "2")
                    {
                        //DataTable dt = DAL.BankService.Ishistory(billNotice.Bankno);
                        //if (dt.Rows.Count > 0)
                        //{
                        //    return "200";   //流水号已存在历史表（该笔存款已审核，不能重复审核）
                        //}
                        //存款接受
                        if (string.IsNullOrEmpty(billNotice.CardNo))
                        {
                            return "201";   //存入银行为空，拒绝该笔存款
                        }



                        //更新首存时间
                        BLL.UserManager userBll = new BLL.UserManager();
                        Model.User user = userBll.GetUserByUserName(billNotice.UserName);
                        if (user.soucunsj == null)
                        {
                            DAL.UserService.UpdateUser(DateTime.Now, billNotice.UserName);
                        }


                    }
                }
                if (reason != "")
                {
                    refuseReason = BLL.BankManager.GetReasonByID(reason);
                }
                if (billNotice.Type == "1" && status == "2")
                {
                    //存款

                    //取银行卡计算期初余额
                    decimal bankamount1, bankamount2;
                    string nonums = "";
                    //if (billNotice.Bankno.IndexOf("10s") != -1 && billNotice.Bankcn.IndexOf("刘成章") == -1)
                    //{
                    //    nonums = "汇潮支付";                                        
                    //}
                    //else if(billNotice.Bankno.IndexOf("10s") != -1 && billNotice.Bankcn.IndexOf("刘成章") != -1)
                    //{
                    //    nonums = "sammi@10sun.com";  
                    //}
                    //else {
                    //    nonums = billNotice.Bankno;                              
                    //}
                    nonums = billNotice.Bankcn;
                    Banklistc bankInfo = DAL.BanklistcService.GetBankByCardno(nonums);
                    if (bankInfo != null)
                    {
                        bankamount1 = bankInfo.amount;
                        bankamount2 = bankInfo.amount + Convert.ToDecimal(valid);
                        bankInfo.amount = bankamount2;
                        //更新银行卡余额
                        BLL.BanklistcManager.UpdateBanklistc(bankInfo);

                        billNoticeHistory.sfee = Convert.ToDecimal(seef);
                        billNoticeHistory.bankamount1 = bankamount1;
                        billNoticeHistory.bankamount2 = bankamount2;
                        billNoticeHistory.bankc = bankInfo.Nameth;
                        billNoticeHistory.cardnoc = bankInfo.Cardno;
                        billNoticeHistory.banknoc = bankInfo.Bank;
                        billNoticeHistory.banknamec = bankInfo.Namecn;
                    }
                }
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
                //billNoticeHistory.Bankcn = billNotice.Bankcn;
                //billNoticeHistory.Banktw = billNotice.Banktw;
                //billNoticeHistory.Banken = billNotice.Banken;
                //billNoticeHistory.Bankth = billNotice.Bankth;
                billNoticeHistory.Bankno = billNotice.Bankno;
                billNoticeHistory.CardNo = billNotice.CardNo;
                billNoticeHistory.Bankaccount = billNotice.Bankaccount;
                billNoticeHistory.BankTime = billNotice.BankTime;
                billNoticeHistory.Currency = billNotice.Currency;
                billNoticeHistory.Names = billNotice.Names;
                billNoticeHistory.Tel = billNotice.Tel;
                billNoticeHistory.ValidAmount = Convert.ToDecimal(valid);
                billNoticeHistory.Mark = billNotice.Mark;
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
                Manager manager = Session[ProjectConfig.ADMINUSER] as Manager;
                string operer = manager.ManagerId;
                BLL.BankManager.InsertOperateLog(billNoticeHistory, operer);

                if (status == "2")
                {
                    //存款接受，更新余额
                    BLL.BankManager.UpdateBalance(userAmount.ToString(), billNotice.UserName, "1");

                    //判断邀请码是否存

                    bool rcodes = DAL.UserService.IsExistUsername(rcode);
                    decimal userAmounts = Convert.ToDecimal(valid) * Convert.ToDecimal(0.01);
                    if (rcodes)
                    {
                        DAL.BankService.AddHongLi(rcode, "3", userAmounts, "1", "推荐好友存款送1%");
                    }
                    else
                    { 
                        
                    }


                }
            }
            catch (Exception)
            {
                return "false";
            }
            return "{\"a\":\"" + balance + "\",\"b\":\"" + valid + "\",\"c\":\"" + billNotice.Amount + "\"}";
        }



        /// <summary>
        /// 提款
        /// </summary>
        /// <param name="status"></param>
        /// <param name="reason"></param>
        /// <param name="id"></param>
        /// <param name="validAmount"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string VerifyBillNotice8(string status, string reason, string id, string validAmount, int bankID, string outfee,
            string bankname, string cardNo, string type)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            BillNotice billNotice = BLL.BankManager.GetBillNotice(id);
            RefusedList refuseReason = new RefusedList();
            string valid = validAmount == "" ? billNotice.Amount.ToString() : validAmount;
            Decimal balance = BLL.BankManager.GetUserBalance(billNotice.UserName);
            
            try
            {
               
                if (billNotice.Type == "2")
                {
                    //取款扣钱
                    if (status == "2")
                    {
                        BLL.BankManager.UpdateBalance(valid, billNotice.UserName, "2");
                      
                    }
                }
                if (reason != "")
                {
                    refuseReason = BLL.BankManager.GetReasonByID(reason);
                }
                //取银行卡计算期初余额
                decimal bankamount1, bankamount2;
                decimal sfee1 = Convert.ToDecimal(outfee);
                Banklistc bankInfo = BLL.BanklistcManager.GetBanklistcByPK(bankID);
                bankamount1 = bankInfo.amount;
                bankamount2 = bankInfo.amount - Convert.ToDecimal(valid) - sfee1;
                bankInfo.amount = bankamount2;
                //更新银行卡余额
                BLL.BanklistcManager.UpdateBanklistc(bankInfo);
                
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
                billNoticeHistory.Mark = billNotice.Mark;
                billNoticeHistory.sfee = sfee1;
                billNoticeHistory.bankamount1 = bankamount1;
                billNoticeHistory.bankamount2 = bankamount2;
                billNoticeHistory.bankc = bankInfo.Nameth;
                billNoticeHistory.cardnoc = bankInfo.Cardno;
                billNoticeHistory.banknoc = bankInfo.Bank;
                billNoticeHistory.banknamec = bankInfo.Namecn;
                billNoticeHistory.Bankcn = type;
                billNoticeHistory.CardNo = cardNo;
                billNoticeHistory.Names = bankname;
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
                Manager manager = Session[ProjectConfig.ADMINUSER] as Manager;
                string operer = manager.ManagerId;
                BLL.BankManager.InsertOperateLog(billNoticeHistory, operer);
            }
            catch (Exception)
            {
                return "false";
            }
            return "{\"a\":\"" + balance + "\",\"b\":\"" + valid + "\",\"c\":\"" + billNotice.Amount + "\"}";
        }


        /// <summary>
        /// 红利
        /// </summary>
        /// <param name="status">2：接受　3：拒绝</param>
        /// <param name="reason"></param>
        /// <param name="id"></param>
        /// <param name="validAmount"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string VerifyBillNotice1(string status, string reason, string id, string validAmount)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
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
                if (status != "3")
                {
                    BLL.BankManager.UpdateBalance(valid, billNotice.UserName, "1");
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
                billNoticeHistory.Mark = billNotice.Mark;
                billNoticeHistory.Reasonvn = billNotice.Reasonvn;
                billNoticeHistory.Tel = billNotice.Tel;
                billNoticeHistory.BankTime = billNotice.BankTime;
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
                Manager manager = Session[ProjectConfig.ADMINUSER] as Manager;
                string operer = manager.ManagerId;
                BLL.BankManager.InsertOperateLog(billNoticeHistory, operer);
            }
            catch (Exception)
            {
                return "false";
            }
            return "{\"a\":\"" + balance + "\",\"b\":\"" + valid + "\",\"c\":\"" + billNotice.Amount + "\"}";
        }

        /// <summary>
        /// 返水
        /// </summary>
        /// <param name="status">2：接受　3：拒绝</param>
        /// <param name="reason"></param>
        /// <param name="id"></param>
        /// <param name="validAmount"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string VerifyBillNotice110(string status, string reason, string id, string validAmount)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            BillNotice billNotice = BLL.BankManager.GetBillNotice(id);
            RefusedList refuseReason = new RefusedList();
            string valid = validAmount == "" ? billNotice.Amount.ToString() : validAmount;
            Decimal balance = BLL.BankManager.GetUserBalance(billNotice.UserName);
            //if (status == "2" && billNotice.Type == "2" && balance < Convert.ToDecimal(valid))
            //{
            //    return "nomoney";
            //}
            try
            {
                if (status != "3")
                {
                    BLL.BankManager.UpdateBalance(valid, billNotice.UserName, "1");
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
                billNoticeHistory.ValidAmount = billNotice.validamount;
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
                billNoticeHistory.Mark = billNotice.Mark;
                billNoticeHistory.Reasonvn = billNotice.Reasonvn;
                billNoticeHistory.Tel = billNotice.Tel;
                billNoticeHistory.BankTime = billNotice.BankTime;
                //billNoticeHistory.ValidAmount = Convert.ToDecimal(valid);
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
                Manager manager = Session[ProjectConfig.ADMINUSER] as Manager;
                string operer = manager.ManagerId;
                BLL.BankManager.InsertOperateLog(billNoticeHistory, operer);
            }
            catch (Exception)
            {
                return "false";
            }
            return "{\"a\":\"" + balance + "\",\"b\":\"" + valid + "\",\"c\":\"" + billNotice.Amount + "\"}";
        }


        [WebMethod(true)]
        public string GetBillNoticeByUser(string userName)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.BankManager.GetBillNoticeByUser(userName);
        }

        [WebMethod(true)]
        public string GetBillWithDrawalNotice()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.BankManager.GetBillWithDrawalNotice();
        }

        [WebMethod(true)]
        public string GetBillDepositNotice()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.BankManager.GetBillDepositNotice();
        }

        [WebMethod(true)]
        public string GetDepositHistory()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.BankManager.GetDepositHistory();
        }

        [WebMethod(true)]
        public string GetWithDrawalHistory()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.BankManager.GetWithDrawalHistory();
        }

        [WebMethod(true)]
        public string GetWithDrawalHistoryByWhere(string userName, string name, string status, string time1, string time2)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.BankManager.GetWithDrawalHistoryByWhere(userName, name, status, time1, time2);
        }
        
        [WebMethod(true)]
        public string GetWinHistoryByWhere(string userName, string name, string status, string time1, string time2)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.BankManager.GetWinHistoryByWhere(userName, name, status, time1, time2);
        }

        [WebMethod(true)]
        public string GetDepositHistoryByWhere(string userName, string lan,string name, string status, string time1, string time2)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.BankManager.GetDepositHistoryByWhere(userName, lan,name, status, time1, time2);
        }

        /// <summary>
        /// 红利返水
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="lan"></param>
        /// <param name="name"></param>
        /// <param name="status"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string GetHistoryByWhere(string userName, string lan, string name, string status, string time1, string time2, string type,string mark)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return DAL.BankService.GetHistoryByWhere(userName, lan, name, status, time1, time2, type, mark);
        }

        /// <summary>
        /// 获取会员转账记录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="lan"></param>
        /// <param name="name"></param>
        /// <param name="status"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public string GetHistoryBy56(string userName, string lan, string name, string status, string time1, string time2)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return DAL.BankService.GetHistoryBy56(userName, lan, name, status, time1, time2, "'5','6'");
        }

        [WebMethod(true)]
        public string GetWithDrawalByWhere(string userName, string name, string time1, string time2)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "-1";
            }
            return BLL.BankManager.GetWithDrawalByWhere(userName, name, time1, time2);
        }

        [WebMethod(true)]
        public string GetDepositByWhere(string userName,string lan, string name, string time1, string time2)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "-1";
            }
            return BLL.BankManager.GetDepositByWhere(userName,lan, name, time1, time2);
        }

        [WebMethod(true)]
        public string GetBillDetailAll()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.BankManager.GetBillDetailAll();
        }

        [WebMethod(true)]
        public string GetBillDetailByWhere(string userName, string name, string type, string time1, string time2)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.BankManager.GetBillDetailByWhere(userName, name, type, time1, time2);
        }

        [WebMethod(true)]
        public string GetBankInfoAll(string lan)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.BankManager.GetBankInfoAll(lan);
        }

        [WebMethod(true)]
        public string GetUserInfo(string userName)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.BankManager.GetUserInfo(userName);
        }

        [WebMethod(true)]
        public string GetReason()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.BankManager.GetReason();
        }

        [WebMethod(true)]
        public string GetCurrInfo(string code)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.BankManager.GetCurrInfo(code);
        }



        [WebMethod(true)]
        public string GetLogbyWhere(string typ, string operators, string operationtimes, string operationtimee, string lan)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }

            return BLL.BillLogManager.GetLogbyWhere(typ, operators, operationtimes, operationtimee, lan);
        }

        [WebMethod(true)]
        public bool AddRefused(string reasoncn, string reasontw, string reasonen, string reasonth, string reasonvn)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }
            PageBase page = new PageBase();
            RefusedList rl = new RefusedList();
            rl.Reasoncn = reasoncn;
            rl.Reasonen = reasonen;
            rl.Reasonth = reasonth;
            rl.Reasontw = reasontw;
            rl.Reasonvn = reasonvn;
            rl.Isdate = DateTime.Now;
            rl.Operator = page.CurrentManager.ManagerId;
            rl.Operationtime = DateTime.Now;
            rl.Ip = Util.RequestHelper.GetIP();
            return BLL.RefusedListManager.AddRefusedList(rl);
        }

        [WebMethod(true)]
        public bool UpdateRefused(string reasoncn, string reasontw, string reasonen, string reasonth, string reasonvn, int ID)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }
            PageBase page = new PageBase();
            RefusedList rl = new RefusedList();
            rl.Reasoncn = reasoncn;
            rl.Reasonen = reasonen;
            rl.Reasonth = reasonth;
            rl.Reasontw = reasontw;
            rl.Reasonvn = reasonvn;
            rl.Isdate = DateTime.Now;
            rl.Operator = page.CurrentManager.ManagerId;
            rl.Operationtime = DateTime.Now;
            rl.Ip = Util.RequestHelper.GetIP();
            rl.ID = ID;
            return BLL.RefusedListManager.UpdateRefusedList(rl);
        }

        [WebMethod(true)]
        public bool DeleteRefused(int ID)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }

            return BLL.RefusedListManager.DeleteRefusedListByPK(ID);
        }

        [WebMethod(true)]
        public string GetRefused()
        {
            IList<RefusedList> info = BLL.RefusedListManager.GetMutilILRefusedList();
            return DAL.ObjectToJson.ObjectListToJson<RefusedList>(info);
        }

        [WebMethod(true)]
        public string GetBanklistc()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            IList<Banklistc> infos = BLL.BanklistcManager.GetMutilILBanklistc();
            return DAL.ObjectToJson.ObjectListToJson<Banklistc>(infos);
        }

        [WebMethod(true)]
        public bool AddBanklistc(string Currency, string namecn,string nametw,string nameen,string nameth, string cardno, string bank, string Province,
            string city, string Branch, string status)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }
            PageBase page = new PageBase();
            Banklistc info = new Banklistc();
            info.Currency = Currency;
            info.Namecn = namecn;
            info.Nametw = nametw;
            info.Nameen = nameen;
            info.Nameth = nameth;
            info.Cardno = cardno;
            info.Bank = bank;
            info.Province = Province;
            info.City = city;
            info.Branch = Branch;
            info.Status = status;
            info.Operator = page.CurrentManager.ManagerId;
            info.Operationtime = DateTime.Now;
            info.Ip = Util.RequestHelper.GetIP();
            return BLL.BanklistcManager.AddBanklistc(info);
        }

        [WebMethod(true)]
        public bool UpdateBanklistc(string Currency, string namecn, string nametw, string nameen, string nameth, string cardno, string bank, string Province,string city, string Branch, string status, int ID)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }
            PageBase page = new PageBase();
            Banklistc info = new Banklistc();
            info.Currency = Currency;
            info.Namecn = namecn;
            info.Nametw = nametw;
            info.Nameen = nameen;
            info.Nameth = nameth;
            info.Cardno = cardno;
            info.Bank = bank;
            info.Province = Province;
            info.City = city;
            info.Branch = Branch;
            info.Status = status;
            info.Operator = page.CurrentManager.ManagerId;
            info.Operationtime = DateTime.Now;
            info.Ip = Util.RequestHelper.GetIP();
            info.ID = ID;
            return BLL.BanklistcManager.UpdateBanklistc(info);
        }

        [WebMethod(true)]
        public bool DeleteBanklistc(int ID)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }
            return BLL.BanklistcManager.DeleteBanklistcByPK(ID);
        }

        [WebMethod(true)]
        public string GetBankhistory()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            IList<Bankhistory> infos = BLL.BankhistoryManager.GetMutilILBankhistory();
            return DAL.ObjectToJson.ObjectListToJson<Bankhistory>(infos);
        }

        [WebMethod(true)]
        public bool AddBankhistory(string Currency, string bank, string cardno, string Typ, decimal amount,
            decimal balance)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }
            PageBase page = new PageBase();
            Bankhistory info = new Bankhistory();
            info.Isdate = DateTime.Now;
            info.Currency = Currency;
            info.Bank = bank;
            info.Cardno = cardno;
            info.Typ = Typ;
            info.Amount = amount;
            info.Balance = balance;
            info.Operator = page.CurrentManager.ManagerId;
            info.Operationtime = DateTime.Now;
            info.Ip = Util.RequestHelper.GetIP();
            return BLL.BankhistoryManager.AddBankhistory(info);
        }

        [WebMethod(true)]
        public bool UpdateBankhistory(string Currency, string bank, string cardno, string Typ, decimal amount,
            decimal balance, int ID)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }
            PageBase page = new PageBase();
            Bankhistory info = new Bankhistory();
            info.Isdate = DateTime.Now;
            info.Currency = Currency;
            info.Bank = bank;
            info.Cardno = cardno;
            info.Typ = Typ;
            info.Amount = amount;
            info.Balance = balance;
            info.Operator = page.CurrentManager.ManagerId;
            info.Operationtime = DateTime.Now;
            info.Ip = Util.RequestHelper.GetIP();
            info.ID = ID;
            return BLL.BankhistoryManager.UpdateBankhistory(info);
        }

        [WebMethod(true)]
        public string GetBankhistorybyWhere(string typ, string bank, string cardno, string time1, string time2)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.BankhistoryManager.GetBankhistorybyWhere(typ, bank, cardno, time1, time2);
        }

        [WebMethod(true)]
        public string GetWDHistory(string userName)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.BankManager.GetWDHistory(userName);
        }

        [WebMethod(true)]
        public string GetDHistory(string userName)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.BankManager.GetDHistory(userName);
        }

        [WebMethod(true)]
        public string GetOrderAll(string userName)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.BankManager.GetOrderAll(userName);
        }

        [WebMethod(true)]
        public string GetOrderHistory(string userName)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.BankManager.GetOrderHistory(userName);
        }

        [WebMethod(true)]
        public bool CancelBNH(string id, string type, string reason)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }
            BillNoticeHistory bnh = BLL.BankManager.GetBillNoticeHistory(id);
            RefusedList refuseReason = new RefusedList();
            try
            {
                if (BLL.BankManager.UpdateBalance("-" + bnh.ValidAmount.ToString(), bnh.UserName, bnh.Type))
                {
                    //更新银行卡
                    //取银行卡计算期初余额
                    decimal bankamount1, bankamount2;
                    Banklistc bankInfo = DAL.BanklistcService.GetBankByCardno(bnh.cardnoc);
                    bankamount1 = bankInfo.amount;
                    bankamount2 = bankInfo.amount - bnh.Amount;
                    bankInfo.amount = bankamount2;
                    //更新银行卡余额
                    BLL.BanklistcManager.UpdateBanklistc(bankInfo);

                    refuseReason = BLL.BankManager.GetReasonByID(reason);
                    bnh.Reasoncn = refuseReason.Reasoncn;
                    bnh.Reasonen = refuseReason.Reasonen;
                    bnh.Reasontw = refuseReason.Reasontw;
                    bnh.Reasonth = refuseReason.Reasonth;
                    bnh.Reasonvn = refuseReason.Reasonvn;
                    bnh.Names = bnh.Names;
                    bnh.Currency = bnh.Currency;
                    bnh.CardNo = bnh.CardNo;
                    bnh.UpdateTime = Convert.ToDateTime(DateTime.Now);
                    bnh.Status = "3";
                    return BLL.BankManager.CancelBNH(bnh);
                }
                return false;
            }
            catch (Exception) {
                return false;
            }
        }

        [WebMethod(true)]
        public bool AddBankInfo(string currency,string bankcn, string banktw, string banken, string bankth, string bankvn, string status)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }
            PageBase page = new PageBase();
            BankInfo bankInfo = new BankInfo();
            bankInfo.Currency = currency;
            bankInfo.BankNamecn = bankcn;
            bankInfo.BankNametw = banktw;
            bankInfo.BankNameen = banken;
            bankInfo.BankNameth = bankth;
            bankInfo.BankNamevn = bankvn;
            bankInfo.Status = status;
            bankInfo.Operator = page.CurrentManager.ManagerId;
            bankInfo.OperationTime = DateTime.Now;
            bankInfo.IP = Util.RequestHelper.GetIP();
            return BLL.BankInfoManager.AddBankInfo(bankInfo);
        }

        [WebMethod(true)]
        public bool UpdateBankInfo(string id,string currency,string bankcn,string banktw,string banken,string bankth,string bankvn,string status)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }
            PageBase page = new PageBase();
            BankInfo bankInfo = new BankInfo();
            bankInfo.Id = Convert.ToInt32(id);
            bankInfo.Currency = currency;
            bankInfo.BankNamecn = bankcn;
            bankInfo.BankNametw = banktw;
            bankInfo.BankNameen = banken;
            bankInfo.BankNameth = bankth;
            bankInfo.BankNamevn = bankvn;
            bankInfo.Status = status;
            bankInfo.Operator = page.CurrentManager.ManagerId;
            bankInfo.OperationTime = DateTime.Now;
            bankInfo.IP = Util.RequestHelper.GetIP();
            return BLL.BankInfoManager.UpdateBankInfo(bankInfo);
        } 

        [WebMethod(true)]
        public string SelectByCurr(string currency)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.BankInfoManager.SelectByCurr(currency);
        }

        [WebMethod(true)]
        public string SelectAll()
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            return BLL.BankInfoManager.SelectAll();
        }

        [WebMethod(true)]
        public bool DeleteBankInfo(string id)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }
            return BLL.BankInfoManager.DeleteBankInfo(id);
        }

        [WebMethod(true)]
        public string GetBankListcBynamecn(string namecn)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return "";
            }
            BLL.BanklistcManager bm = new BLL.BanklistcManager();
            return bm.GetBankListcBynamecn(namecn);
        }

        [WebMethod(true)]
        public string GetBankListcByCurrency(string currency)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return null;
            }
            BLL.BanklistcManager bm = new BLL.BanklistcManager();
            return bm.GetBankListcByCurrency(currency);
        }

        [WebMethod(true)]
        public bool IsWithDrawal(string userName)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }
            BLL.BanklistcManager bm = new BLL.BanklistcManager();
            return bm.IsWithDrawal(userName);
        }
        /// <summary>
        /// 添加红利
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="type"></param>
        /// <param name="amount"></param>
        /// <param name="submitTime"></param>
        /// <param name="status"></param>
        /// <param name="mark"></param>
        /// <returns></returns>
        [WebMethod(true)]
        public bool AddHongLi(string userName, string type, decimal amount, string status, string mark)
        { 
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return false;
            }
            return DAL.BankService.AddHongLi(userName, type, amount, status, mark);
        }
        //添加返水
        [WebMethod(true)]
        public bool AddFanShui(string userName, string type, decimal amount, string status, string mark, string fsbl, string time1, string time2, decimal validamount)
        { 
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return   false;
            }
            return DAL.BankService.AddFanShui(userName, type, amount, status, mark, fsbl, time1, time2, validamount);
        }
        [WebMethod(true)]
        public string GetList(string userName, string time1, string time2, string type)
        {

            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return null;
            }
            return DAL.BankService.GetList(userName, time1, time2, type);
        }



        #region 存款，取款，红利，返水（查询）
        [WebMethod(true)]

        public string GetBillNoticeHistory(string username, string type, string time1, string time2, string lan)
        {
            try
            {

                return BLL.BankManager.GetBillNoticeHistory(username, type, time1, time2, lan);
            }
            catch (Exception)
            {
                return "";
            }
        }


        //存款，取款，红利，返水（查询）(会员分析)
         [WebMethod(true)]
        public string GetBillNoticeHistory_ok(string username, string type, string time1, string time2, string lan)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return null;
            }
            try
            {

                return BLL.BankManager.GetBillNoticeHistory_ok(username, type, time1, time2, lan);
            }
            catch (Exception)
            {
                return "";
            }
        }

        
        [WebMethod(true)]
         public string GetBillNoticeHistory_okPE(string username, string time1, string time2, string lan)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return null;
            }
            try
            {

                return BLL.BankManager.GetBillNoticeHistory_okPE(username, time1, time2, lan);
            }
            catch (Exception)
            {
                return "";
            }
        }



        [WebMethod(true)]
        public string GetBillNoticePt(string username, string type, string time1, string time2, string lan)
        {
            if (Session[Util.ProjectConfig.ADMINUSER] == null)
            {
                return null;
            }
            try
            {

                return BLL.BankManager.GetBillNoticePt(username,type, time1, time2, lan);
            }
            catch (Exception)
            {
                return "";
            }
        }





        
        /// <summary>
        ///用户存款查询（存，红利，返水）
        /// </summary>
        /// <param name="username"></param>
        /// <param name="type"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
       [WebMethod(true)]
         public string GetBillNoticeHistory_user(string username, string type, string time1, string time2, string agent)
        {
            //if (Session[Util.ProjectConfig.ADMINUSER] == null)
            //{
            //    return null;
            //}
            try
            {

                return BLL.BankManager.GetBillNoticeHistory_user(username, type, time1, time2, agent);
            }
            catch (Exception)
            {
                return "";
            }
        }
         [WebMethod(true)]
         public string GetBillNoticeHistory_QK(string username, string type, string time1, string time2, string lan)
        {
            try
            {

                return BLL.BankManager.GetBillNoticeHistory_QK(username, type, time1, time2, lan);
            }
            catch (Exception)
            {
                return "";
            }
        }
        #endregion


        /// <summary>
        /// 查询出用户总数据
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
       [WebMethod(true)]

        public string SumGetBillNoticeHistory(string username)
        {
            try
            {

                return BLL.BankManager.SumGetBillNoticeHistory(username);
            }
            catch (Exception)
            {
                return "";
            }
        }

       [WebMethod(true)]
       public string SumGetDayNoticeHistory(string username, string time1, string time2)
       {
           try
           {
               if (Session[Util.ProjectConfig.ADMINUSER] == null)
               {
                   return null;
               }
               return DAL.BankService.SumGetDayNoticeHistory(username, time1, time2);
           }
           catch (Exception)
           {
               return "";
           }
       }

        
      [WebMethod(true)]
       public string GetBankList(string username)
       {
           try
           {
               if (Session[Util.ProjectConfig.ADMINUSER] == null)
               {
                   return null;
               }
               return DAL.BankService.GetBankList(username);
           }
           catch (Exception)
           {
               return "";
           }
       }

      [WebMethod(true)]
      public string GetBanklistc1(string type)
      {
          return DAL.BanklistcService.GetBanklistc(type);
      }

        /// <summary>
        /// 银行卡查询
        /// </summary>
        /// <param name="bankcard">公司卡号</param>
        /// <param name="lsname">流水号</param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
      [WebMethod(true)]
      public string GetHistoryByWhereSum(string bankcard,string lsname, string time1, string time2)
      {
          try
          {
              if (Session[Util.ProjectConfig.ADMINUSER] == null)
              {
                  return null;
              }
              return DAL.BankService.GetHistoryByWhereSum(bankcard, lsname, time1, time2);
          }
          catch (Exception)
          {
              return "";
          }
      }

      [WebMethod(true)]
      public string GetHistoryByWhereSumPage(int perPageNum, int page, string bankcard, string lsname, string time1, string time2)
      {
          try
          {
              if (Session[Util.ProjectConfig.ADMINUSER] == null)
              {
                  return null;
              }
              return DAL.BankService.GetHistoryByWhereSumPage(perPageNum, page, bankcard, lsname, time1, time2);
          }
          catch (Exception)
          {
              return "";
          }
      }

      /// <summary>
      /// 银行卡查询
      /// </summary>
      /// <param name="bankcard">公司卡号</param>
      /// <param name="lsname">流水号</param>
      /// <param name="time1"></param>
      /// <param name="time2"></param>
      /// <returns></returns>
      [WebMethod(true)]
      public string GetUserBankList(int id)
      {
          try
          {
              if (Session[Util.ProjectConfig.ADMINUSER] == null)
              {
                  return null;
              }
              return DAL.BankService.GetUserBankList(id);
          }
          catch (Exception)
          {
              return "";
          }
      }

      [WebMethod(true)]
      public string GetBankNameInfo()
      {
          try
          {
                if (Session[Util.ProjectConfig.ADMINUSER] == null)
              {
                  return null;
              }
            
              return BLL.BankManager.GetBankNameInfo();
          }
          catch (Exception)
          {
              return "";
          }
      }
      [WebMethod(true)]
      public string GetBankNameInfo_1()
      {
          try
          {
              if (Session[Util.ProjectConfig.ADMINUSER] == null)
              {
                  return null;
              }

              return BLL.BankManager.GetBankNameInfo_1();
          }
          catch (Exception)
          {
              return "";
          }
      }
      /// <summary>
      /// 选择银行别名后绑定卡号和户名
      /// </summary>
      /// <returns></returns>
      [WebMethod(true)]
      public string GetBankInfos(int id)
      {
          try
          {
              if (Session[Util.ProjectConfig.ADMINUSER] == null)
              {
                  return null;
              }
             
              return BLL.BankManager.GetBankInfos(id);
          }
          catch (Exception)
          {
              return "";
          }
      }
        /// <summary>
        /// 手动出款
        /// </summary>
        /// <param name="bankTypeid"></param>
        /// <param name="bankc"></param>
        /// <param name="banknamec"></param>
        /// <param name="banknoc"></param>
        /// <param name="cardnoc"></param>
        /// <param name="bankcn"></param>
        /// <param name="Names"></param>
        /// <param name="UserName"></param>
        /// <param name="CardNo"></param>
        /// <param name="Amount"></param>
        /// <param name="sfee"></param>
        /// <param name="Type"></param>
        /// <param name="Status"></param>
        /// <param name="Reasoncn"></param>
        /// <returns></returns>
      [WebMethod(true)]
      public bool InsertBillNoticeManagent(int bankTypeid, string bankc, string banknamec, string banknoc, string cardnoc, string bankcn, string Names,
          string UserName, string CardNo, string Amount, string sfee, string Type, string Status, string Reasoncn)
      {
          try
          {              
         
              if (Session[Util.ProjectConfig.ADMINUSER] == null)
              {
                  return false;
              }
             // PageBase page = new PageBase();
              BillNoticeHistory billNoticeHistory = new BillNoticeHistory();
              billNoticeHistory.bankc = bankc;
              billNoticeHistory.banknamec = banknamec;
              billNoticeHistory.banknoc = banknoc;
              billNoticeHistory.cardnoc = cardnoc;
              billNoticeHistory.Bankcn = bankcn;
              billNoticeHistory.Reasoncn = Reasoncn;
              billNoticeHistory.UserName = UserName;
              billNoticeHistory.CardNo = CardNo;
              billNoticeHistory.Amount = Convert.ToDecimal(Amount);
              billNoticeHistory.sfee = Convert.ToDecimal(sfee);
              billNoticeHistory.Type = Type;
              billNoticeHistory.Status = Status;
              billNoticeHistory.Mark = Reasoncn;
              billNoticeHistory.Currency = "RMB";
              billNoticeHistory.Names = Names;
              billNoticeHistory.SubmitTime = DateTime.Now;
              billNoticeHistory.UpdateTime = DateTime.Now;
              billNoticeHistory.Reasoncn = Reasoncn;


              //取银行卡计算期初余额
              decimal bankamount1, bankamount2;
              decimal sfee1 = Convert.ToDecimal(sfee);
              decimal valid = Convert.ToDecimal(Amount);              
              Banklistc bankInfo = BLL.BanklistcManager.GetBanklistcByPK(bankTypeid);
              bankamount1 = bankInfo.amount;
              bankamount2 = bankInfo.amount - Convert.ToDecimal(valid) - sfee1;
              bankInfo.amount = bankamount2;
              billNoticeHistory.bankamount1 = bankamount1;
              billNoticeHistory.bankamount2 = bankamount2;

              //更新银行卡余额   
              Boolean istrue = BLL.BankhistoryManager.InsertBillNoticeManagent(billNoticeHistory);
              if (istrue == true)
              {
                  try
                  {
                      //BLL.BanklistcManager.UpdateBanklistc(bankInfo);
                      BLL.BanklistcManager.UpdateBanklistc_bank(bankInfo);
                      return true;
                  }
                  catch (Exception)
                  {

                      return false;
                  }
                 
              }
              else
              {
                  return false;
              }
          }
          catch (Exception)
          {
              return false;
          }
      }


        /// <summary>
        /// 手动存款
        /// </summary>
        /// <param name="bankTypeid"></param>
        /// <param name="bankc"></param>
        /// <param name="banknamec"></param>
        /// <param name="banknoc"></param>
        /// <param name="cardnoc"></param>
        /// <param name="bankcn"></param>
        /// <param name="Names"></param>
        /// <param name="UserName"></param>
        /// <param name="CardNo"></param>
        /// <param name="Amount"></param>
        /// <param name="sfee"></param>
        /// <param name="Type"></param>
        /// <param name="Status"></param>
        /// <param name="Reasoncn"></param>
        /// <returns></returns>
      [WebMethod(true)]
      public bool InsertBillNoticeManagentC(int bankTypeid, string bankc, string banknamec, string banknoc, string cardnoc, string Amount, string sfee, string Type, string Status, string Reasoncn)
      {
          try
          {               

              if (Session[Util.ProjectConfig.ADMINUSER] == null)
              {
                  return false;
              }
              // PageBase page = new PageBase();
              BillNoticeHistory billNoticeHistory = new BillNoticeHistory();
             
              billNoticeHistory.bankc = bankc;
              billNoticeHistory.banknamec = banknamec;
              billNoticeHistory.banknoc = banknoc;
              billNoticeHistory.cardnoc = cardnoc;
              billNoticeHistory.Bankcn = banknamec;
              billNoticeHistory.Reasoncn = Reasoncn;
              billNoticeHistory.UserName = "System";
              billNoticeHistory.CardNo = cardnoc;  
              billNoticeHistory.Amount = Convert.ToDecimal(Amount);
              billNoticeHistory.sfee = Convert.ToDecimal(sfee);
              billNoticeHistory.Type = Type;
              billNoticeHistory.Status = Status;
              billNoticeHistory.Mark = Reasoncn;
              billNoticeHistory.Currency = "RMB";
              billNoticeHistory.Names = banknoc;
              billNoticeHistory.SubmitTime = DateTime.Now;
              billNoticeHistory.UpdateTime = DateTime.Now;
              billNoticeHistory.Reasoncn = Reasoncn;


              //取银行卡计算期初余额
              decimal bankamount1, bankamount2;
              decimal sfee1 = Convert.ToDecimal(sfee);
              decimal valid = Convert.ToDecimal(Amount);
              Banklistc bankInfo = BLL.BanklistcManager.GetBanklistcByPK(bankTypeid);
              bankamount1 = bankInfo.amount;
              bankamount2 = bankInfo.amount + Convert.ToDecimal(valid) - sfee1;
              bankInfo.amount = bankamount2;
              billNoticeHistory.bankamount1 = bankamount1;
              billNoticeHistory.bankamount2 = bankamount2;

            
              Boolean istrue = BLL.BankhistoryManager.InsertBillNoticeManagentC(billNoticeHistory);
              if (istrue == true)
              {
                  try
                  {
                      //更新银行卡余额   
                      BLL.BanklistcManager.UpdateBanklistc_bank(bankInfo);
                      return true;
                  }
                  catch (Exception)
                  {

                      return false;
                  }

              }
              else
              {
                  return false;
              }
          }
          catch (Exception)
          {
              return false;
          }
      }

      [WebMethod(true)]
      public string GetICBCData(string userName, string PaynumerID, string time1, string time2)
      {
          if (Session[Util.ProjectConfig.ADMINUSER] == null)
          {
              return "";
          }
          return BLL.BankManager.GetICBCData(userName, PaynumerID, time1, time2);
      }

      [WebMethod(true)]
      public string AutoFanshui(string time1, string time2, decimal fsbl, string mark, string gametype)
      {
          if (Session[Util.ProjectConfig.ADMINUSER] == null)
          {
              return "-1";
          }

          return BLL.BankManager.AutoFanshui(time1, time2, fsbl, mark, gametype);
      }
    }
}
