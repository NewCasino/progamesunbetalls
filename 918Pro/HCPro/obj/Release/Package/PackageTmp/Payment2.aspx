<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment2.aspx.cs" Inherits="HCPro.Payment2s"  ResponseEncoding="UTF-8" %>

<%
                String MD5key;        //md5key
                MD5key = "XvBuwJq^";

                String MerNo;        //商户号
                MerNo = "26270";

                String BillNo;        //[]商户网店订单号
                BillNo = System.Web.HttpContext.Current.Request.Params["BillNo"].ToString();	 //()

                
                String Amount;        //交易金额
                Amount = System.Web.HttpContext.Current.Request.Params["Amount"].ToString();

                String OrderDesc;	//[ѡ]
                    OrderDesc="";
                    
                String ReturnURL;    //[]返回地址
                ReturnURL = "http://pay.anhuitianyu.cn/PayResult.aspx";
                String AdviceURL;
                // '[必填]支付完成后，后台接收支付结果，可用来更products新数据库值
                AdviceURL = "http://pay.anhuitianyu.cn/HCresult.aspx";  
                

                String md5src;        //加密
                md5src=MerNo+"&"+BillNo+"&"+Amount+"&"+ReturnURL+"&"+MD5key;


                String  SignInfo;        //[]MD5ܺ
                SignInfo = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(md5src, "MD5");

                String Remark;        //备注
                Remark = "东日升娱乐";
	
	            String products;
                products = "东日升娱乐";  //'------------------物品信息



	            String defaultBankNumber;	//'[选填]银行代码
	            defaultBankNumber="";

                String orderTime;   // '[必填]交易时间yyyyMMddHHmmss
                orderTime = System.Web.HttpContext.Current.Request.Params["orderTime"].ToString();

%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
    <title>send.net</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
</head>
<body>
<form id="form1" METHOD="post" action="https://pay.ecpss.com/sslpayment" name="pay">
<table >
    <tr>
  <td><input name="OrderDesc" type="hidden" value="<%=OrderDesc%>"></td></tr>
    <tr>
  <td><input name="Remark" type="hidden" value="<%=Remark%>"></td></tr>
    <tr>
  <td><input name="AdviceURL" type="hidden" value="<%=AdviceURL%>"></td></tr>
    <tr>
  <td><input name="ReturnURL" type="hidden" value="<%=ReturnURL%>"></td></tr>
  
    <tr>
  <td><input name="BillNo" type="hidden" class="input" value="<%=BillNo%>"></td></tr>
    <tr>
  <td><input name="MerNo" type="hidden" class="input" value="<%=MerNo%>"></td></tr>
    <tr>
  <td><input name="Amount" type="hidden" class="input" value="<%=Amount%>"></td></tr>
    <tr>
  <td><input name="SignInfo" type="hidden" class="input" value="<%=SignInfo%>"></td></tr>
  <tr>
  <td><input name="defaultBankNumber" type="hidden" class="input" value="<%=defaultBankNumber%>"></td></tr>
  <tr>
  <td><input name="orderTime" type="hidden" class="input" value="<%=orderTime%>"></td></tr>


        <tr>  
		<td><input type="hidden" name="products" value="<%=products%>"></td></tr>
    
   
   </table>
             
</form>
  <script type="text/javascript">
      document.getElementById('form1').submit();
    </script>
</body>
</html>