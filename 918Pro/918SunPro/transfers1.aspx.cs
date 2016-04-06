using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _918SunPro
{
    public partial class transfers1 : System.Web.UI.Page
    {
        public string GetNumbers;//生成的编号
        public string Getdatetime = "";
        public string MD5key;        //md5key
        public string MerNo;        //商户号
        public string BillNo;        //[]商户网店订单号
        public string Amount;        //交易金额
        public string OrderDesc;	//[ѡ]
        public string ReturnURL;    //[]返回地址
        public string AdviceURL;
        public string md5src;        //加密
        public string SignInfo;        //[]MD5ܺ
        public string Remark;        //备注
        public string products;
        public string defaultBankNumber;	//'[选填]银行代码
        public string orderTime;   // '[必填]交易时间yyyyMMddHHmmss

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                GetNumbers = GetFormCode();
                Getdatetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                MD5key = "XvBuwJq^"; //              
                MerNo = "26270";	 //()
                BillNo = GetFormCode();
                Amount = Request.Form["Amount"];
                OrderDesc = "";
                ReturnURL = "http://pay.anhuitianyu.cn/PayResult.aspx";
                AdviceURL = "http://pay.anhuitianyu.cn/HCresult.aspx";  // '[必填]支付完成后，后台接收支付结果，可用来更新数据库值

                Remark = "";
                products = "东日升娱乐"; //'------------------物品信息
                defaultBankNumber = "";
                orderTime = Getdatetime;
            }
        }

        #region 生成单据号
        /// <summary> 
        /// 生成单据号 
        /// </summary> 
        /// <param name="pFromType"></param> 
        /// <returns></returns> 
        public static string GetFormCode()
        {
            string formcode = "";
            formcode += DateTime.Now.Year.ToString();
            formcode += DateTime.Now.Month.ToString().Length == 1 ? "0" + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString();
            formcode += DateTime.Now.Day.ToString().Length == 1 ? "0" + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString();
            formcode += DateTime.Now.Hour.ToString().Length == 1 ? "0" + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString();
            formcode += DateTime.Now.Minute.ToString().Length == 1 ? "0" + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString();
            formcode += DateTime.Now.Second.ToString().Length == 1 ? "0" + DateTime.Now.Second.ToString() : DateTime.Now.Second.ToString();
            if (DateTime.Now.Millisecond.ToString().Length == 1)
            {
                formcode += "00" + DateTime.Now.Millisecond.ToString();
            }
            else if (DateTime.Now.Millisecond.ToString().Length == 2)
            {
                formcode += "0" + DateTime.Now.Millisecond.ToString();
            }
            else
            {
                formcode += DateTime.Now.Millisecond.ToString();
            }
            return "918s" + formcode;
        }
        #endregion

    }
}