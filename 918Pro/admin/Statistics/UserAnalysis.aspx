<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAnalysis.aspx.cs" Inherits="admin.Statistics.UserAnalysis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>会员分析</title><%--会员分析--%>
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../js/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/jQueryCommon.js"></script>  
    <script src="../js/webBasicInfo/zh-CN.js" type="text/javascript"></script>
    <link href="/css/Default/cupertino/jquery-ui-1.8.2.custom.css" rel="stylesheet"   type="text/css" />
    <style type="text/css">
        
    .ui-effects-transfer { border: 2px dotted gray; } 
    #divTip
    {
    left:45%;top:45%; 
        	
    font-family:sans-serif; position:absolute; font-size:10px;padding:5px;background:#f3f3f3;color:gray;display:none;-moz-border-radius:5px;-webkit-border-radius:5px;border:1px solid #ccc
    }
    #selected{ background:url(/images/default/main/tr_select.gif) bottom repeat-x #fff; border-bottom:1px solid #a8d8eb;}
    </style>
    <script type="text/javascript">
    //---------------------------起始p时间----------------------------------------
        function CurentTime() {
            var d = new Date()
            d.setDate(d.getDay() - 30);

            var year = d.getFullYear();       //年
            var month = d.getMonth() + 1;     //月          
            var day = d.getDate();       //日

            var clock = year + "-";
            if (month < 10)
                clock += "0";
            clock += month + "-";
            if (day < 10) {
                clock += "0";
            }
            clock += day;
            return (clock);
        }
        function CurentTime2() {
            var now = new Date();
            var year = now.getFullYear();       //年
            var month = now.getMonth() + 1;     //月
            var day = now.getDate();       //日


            var clock = year + "-";
            if (month < 10)
                clock += "0";
            clock += month + "-";
            if (day<10) {
                clock += "0";
            }
            clock += day;
            return (clock);
        }
//-----------------------------------------时间初始结束---------------------------------------
        jQuery(function () {
            try {

                $('#regTime1').val(CurentTime());
                jQuery("#regTime1").datepicker();

                $('#regTime2').val(CurentTime2());
                jQuery("#regTime2").datepicker();

                GetUserInfo();
                GetUserInfo2();
                GetUserInfo3();
                GetUserInfo4();
                GetUserInfo7();
              
                jQuery(".tab1").alterBgColor({ odd: "odd", even: "even", selected: "selected", moveOver: "over" });
                jQuery(".tab3").alterBgColor({ odd: "odd", even: "even", selected: "selected", moveOver: "over" });
                jQuery("#selectByWhere").click(function () {
                    GetUserInfo();
                    GetUserInfo2();
                    GetUserInfo3();    
                    GetUserInfo4();
                    GetUserInfo7();
                });
            } catch (e) {
                alert("出现异常，请确定网络的稳定性");
            }

        });

        function GetUserInfo() {
        //alert("ee");
           // debugger
           var arg = GetRequest();
           if (arg != undefined) {
               var u = arg["u"];
               if ($("#username3").val()=="") {
                   $("#username3").val(u);
               }
              
               var htm = "", total1 = 0;
               var url = "/ServicesFile/BankService/BankService.asmx/GetBillNoticeHistory_ok";
               var datas = "username :'" + $("#username3").val() + "', type:'3',time1:'" + $("#regTime1").val() + "',time2:'" + $("#regTime2").val() + "',lan:'cn'";
               jQuery.AjaxCommon(url, datas, false, false, function (json) {
                   //alert(json.d);
                   if (json.d!="") {
                    var result = jQuery.parseJSON(json.d);
                   jQuery.each(result, function (i, n) {
                       total1 += parseFloat(n.d);
                       htm += "<tr>";
                       htm += "<td>" + (i + 1) + "</td>";
                       htm += "<td>红利</td>";
                       htm += "<td>" + n.f + "</td>";
                       htm += "<td class='red'>" + n.d + "</td>";
                       htm += "<td>" + n.mark + "</td>";
                       htm += "</tr>";
                   });
                   htm += "<tr><td>总计</td><td colspan='2'></td><td style='color:#997E11'>" + total1.toFixed(2) + "</td><td ></td></tr>";
                   }
                   else
                   { 
                       total1=0;
                       htm += "<tr>";
                       
                       htm += "<td style='text-align:center;' colspan='5'><span style='color:#224EFF'>---------无数据--------</span></td>";
                    
                       htm += "</tr>";
                   }
                  
                
                  
                   jQuery("#tab1").html(htm);

               });
           }
       }

      

       function GetUserInfo2() {
         
         //debugger
           var arg = GetRequest();
           if (arg != undefined) {
               var u = arg["u"];
               if ($("#username3").val() == "") {
                   $("#username3").val(u);
               }
               var htm = "", total1 = 0;
               var url = "/ServicesFile/BankService/BankService.asmx/GetBillNoticeHistory_okPE";
               var datas = "username :'" + $("#username3").val() + "',time1:'" + $("#regTime1").val() + "',time2:'" + $("#regTime2").val() + "',lan:'cn'";
               jQuery.AjaxCommon(url, datas, false, false, function (json) {
                   if (json.d != "") {
                       var result = jQuery.parseJSON(json.d);
                       jQuery.each(result, function (i, n) {
                           total1 += parseFloat(n.d);
                           htm += "<tr>";
                           htm += "<td>" + (i + 1) + "</td>";
                           htm += "<td>返水</td>";
                           htm += "<td>" + n.f + "</td>";
                           htm += "<td class='red'>" + n.d + "</td>";
                           htm += "<td>" + n.mark + "</td>";
                           htm += "</tr>";
                       });
                       htm += "<tr><td>总计</td><td colspan='2'></td><td style='color:#997E11'>" + total1.toFixed(2) + "</td><td ></td></tr>";
                   }
                   else {
                       total1 = 0;
                       htm += "<tr>";
                       htm += "<td  colspan='5' ><span style='color:#224EFF'>---------无数据--------</span></td>";

                       htm += "</tr>";
                   }
                  
                   jQuery("#tab2").html(htm);

               });
           }
       }


       function GetUserInfo3() {

           //debugger
           var arg = GetRequest();
           if (arg != undefined) {
               var u = arg["u"];
               if ($("#username3").val() == "") {
                   $("#username3").val(u);
               }
               var htm = "", total1 = 0;
               var url = "/ServicesFile/BankService/BankService.asmx/GetBillNoticeHistory_ok";
               var datas = "username :'" + $("#username3").val() + "', type:'1',time1:'" + $("#regTime1").val() + "',time2:'" + $("#regTime2").val() + "',lan:'cn'";
               jQuery.AjaxCommon(url, datas, false, false, function (json) {
                   if (json.d != "") {
                       var result = jQuery.parseJSON(json.d);
                       jQuery.each(result, function (i, n) {
                           total1 += parseFloat(n.d);
                           htm += "<tr>";
                           htm += "<td>" + (i + 1) + "</td>";
                           htm += "<td >存款</td>";
                           if (n.x == "") {
                               htm += "<td>--无流水号--</td>";
                           }
                           else {
                               htm += "<td>" + n.x + "</td>";
                           }


                           htm += "<td >" + n.f + "</td>";
                           htm += "<td >" + n.tel + "</td>";
                           htm += "<td class='red'>" + n.d + "</td>";
                           htm += "</tr>";
                       });
                       htm += "<tr><td>总计</td><td colspan='4'></td><td style='color:#997E11'>" + total1.toFixed(2) + "</td></tr>";
                   } else {
                       total1 = 0;
                       htm += "<tr>";
                       htm += "<td  colspan='6' ><span style='color:#224EFF'>---------无数据--------</span></td>";

                       htm += "</tr>";
                   }
                  
                   jQuery("#tab4").html(htm);

               });
           }
       }

       function GetUserInfo4() {

           //debugger
           var arg = GetRequest();
           if (arg != undefined) {
               var u = arg["u"];
               if ($("#username3").val() == "") {
                   $("#username3").val(u);
               }
               var htm = "", total1 = 0;
               var url = "/ServicesFile/BankService/BankService.asmx/GetBillNoticeHistory_QK";
               var datas = "username :'" + $("#username3").val() + "', type:'2',time1:'" + $("#regTime1").val() + "',time2:'" + $("#regTime2").val() + "',lan:'cn'";
               jQuery.AjaxCommon(url, datas, false, false, function (json) {
                   if (json.d != "") {
                       var result = jQuery.parseJSON(json.d);
                       jQuery.each(result, function (i, n) {
                           total1 += parseFloat(n.d);
                           htm += "<tr>";
                           htm += "<td>" + (i + 1) + "</td>";
                           htm += "<td >取款</td>";
                           htm += "<td >" + n.e + "</td>";
                           htm += "<td>" + n.f + "</td>";
                           htm += "<td>" + n.i + "</td>";
                           htm += "<td class='red'>" + n.d + "</td>";
                           htm += "</tr>";
                       });
                       htm += "<tr><td>总计</td><td colspan='4'></td><td style='color:#997E11'>" + total1.toFixed(2) + "</td></tr>";
                   }
                   else {
                       total1 = 0;
                       htm += "<tr>";
                       htm += "<td  colspan='6' ><span style='color:#224EFF'>---------无数据--------</span></td>";

                       htm += "</tr>";
                   }
                  
                   jQuery("#tab5").html(htm);

               });
           }
       }

       


       function GetUserInfo7() {

           //debugger
           var arg = GetRequest();
           if (arg != undefined) {
               var u = arg["u"];
               if ($("#username3").val() == "") {
                   $("#username3").val(u);
               }
               var htm = "", total1 = 0; total2 = 0; total3 = 0; total4 = 0; total5 = 0; total6 = 0;
               var url = "/ServicesFile/BankService/BankService.asmx/SumGetBillNoticeHistory";
               var datas = "username :'" + $("#username3").val() + "'";
               jQuery.AjaxCommon(url, datas, false, false, function (json) {
                   if (json.d != "") {
                       var result = jQuery.parseJSON(json.d);
                       jQuery.each(result, function (i, n) {
                           total1 += parseFloat(n.sumCGamount - n.sumQgamount);
                          
                           total3 += parseFloat(n.sumCGamount);
                           total4 += parseFloat(n.sumQgamount == '' ? '0' : n.sumQgamount);
                           total5 += parseFloat(n.sumHlamount);
                           total6 += parseFloat(n.sumFSamount);

                           htm += "<tr>";
                           htm += "<td>" + (i + 1) + "</td>";
                           //htm += "<td >总金额</td>";
                           htm += "<td >" + parseFloat(n.sumCGamount - n.sumQgamount) + "</td>";



                           htm += "<td class='red'>" + ((n.sumCGamount == '') ? '0' : parseFloat(n.sumCGamount)) + "</td>";
                           htm += "<td class='red'>" + ((n.sumQgamount == '') ? '0' : parseFloat(n.sumQgamount)) + "</td>";
                           htm += "<td >" +((n.sumHlamount == '') ? '0' : parseFloat(n.sumHlamount)) + "</td>";
                           htm += "<td >" +((n.sumFSamount == '') ? '0' : parseFloat(n.sumFSamount)) + "</td>";
                           htm += "</tr>";
                       });
                       htm += "<tr><td>总计</td><td style='color:#997E11'>" + total1.toFixed(2) + "</td><td style='color:#997E11'>" + total3.toFixed(2) + "</td><td style='color:#997E11'>" + total4.toFixed(2) + "</td><td style='color:#997E11'>" + total5.toFixed(2) + "</td><td style='color:#997E11'>" + total6.toFixed(2) + "</td></tr>";
                   }
                   else {
                       total1 = 0;
                       htm += "<tr>";
                       htm += "<td  colspan='5' ><span style='color:#224EFF'>---------无数据--------</span></td>";

                       htm += "</tr>";
                   }

                   jQuery("#tab8").html(htm);

               });
           }
       }
       function GetEAamount() {
         

       }
    </script>    

</head>
<body>
    <form id="form1" runat="server">
   <table  id="right_main"  style=" width:100%; height:740px" border="0" width="100%" cellpadding="0" cellspacing="0" bordercolor="#999999">
   <thead>
<tr class="h30">

<th width="*" colspan="3" class="tab_top_m"><p id="iptj">会员分析</p></th>

</tr>
<tr>
<td  colspan="3" >
<div class="top_banner h20">

<div class="f1" style=" text-align:left">
<span style=" color:Black">会员：</span><input type="text" id="username3" />&nbsp;&nbsp;
&nbsp;<span id="checkType">时间</span>：<input type="text" name="regTime1" id="regTime1" class="text_01 h20 w_80" />-<input type="text" name="regTime2" id="regTime2" class="text_01 h20 w_80" />
<a id="selectByWhere" class="fa_saurch" ><span class="fa_saurch_in">查詢</span></a>

</div>
</div>
</td>
</tr>
</thead>
  <tr>
    <td valign="top">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
              




   
   
                </td>
            <td valign="top">
                <table width="100%" class="tab1"  border="0" cellspacing="0" cellpadding="0">    
        <thead >
      <tr >
        <th>项目</th>
        
        <th>本金余额</th>        
        <th>总存款</th>
        <th>总取款</th>
        <th>总赠红利</th>
        <th>总赠反水</th>
      </tr>
      </thead>
      <tbody id="tab8">
    </tbody> 
    <tfoot>

    </tfoot>
    </table>


    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
            <div style="height:220px; overflow-x:hidden;overflow-y:scroll; border:1px solid;">
            <table width="100%" class="tab1"  border="0" cellspacing="0" cellpadding="0">
      <caption  style=" text-align:left; font-size:14px; font-weight:700; background-color:#CCCCCC; border:1" >&nbsp;&nbsp;&nbsp;&nbsp; 存款记录</caption>
        <thead>
        <tr>
          <th align="center">项目</th>
           <th align="center">名称</th>
          <th align="center">单据编号</th>
          <th align="center">存款日期</th>
            <th align="center">优惠申请</th>
          <th align="center">金额</th>
        </tr>
        </thead>
       <tbody id="tab4">
    </tbody> 
    <tfoot>
   
    </tfoot>
          
      </table>
      </div>
            </td>
            <td>
            <div style="height:220px; overflow-x:hidden;overflow-y:scroll; border:1px solid;">
            <table width="100%" class="tab1"  border="0" cellspacing="0" cellpadding="0">
      <caption  style=" text-align:left; font-size:14px; font-weight:700; background-color:#CCCCCC;">&nbsp;&nbsp;&nbsp;&nbsp; 取款记录</caption>
         <thead>
        <tr>
          <th align="center">项目</th>
          <th align="center">名称</th>
          <th align="center">取款日期</th>
          <th align="center">审核日期</th>
          <th align="center">账户</th>
          <th align="center">金额</th>
        </tr>
        </thead>
       <tbody id="tab5">
       </tbody> 
       <tfoot>
     
        </tfoot>
      </table>
      </div>
            </td>
        </tr>
        <tr>
            <td>
              <div style="height:180px;overflow-x:hidden;overflow-y:scroll; border:1px solid;">
      <table class="tab1" width="100%" cellpadding="0" cellspacing="0" border="0" >
      <caption  style=" text-align:left; font-size:14px; font-weight:700; background-color:#BBBBBB"">&nbsp;&nbsp;&nbsp;<span style=" color:#224EFF">红利列表[已审核]</span> </caption>
       <thead>
         <tr>
        <th align="center" >序号</th>
         <th align="center">名称</th>
        <th align="center">操作时间</th>
        <th align="center" >金额</th>
        <th align="center" >备注</th>
      </tr>
       </thead>    
    
    
    <tbody id="tab1">
    </tbody> 
    <tfoot>
   
    </tfoot>

    </table>
    </div>
            </td>
            <td>
        <div style="height:180px;overflow-x:hidden;overflow-y:scroll; border:1px solid;">
     <table id="tab3" class="tab3" width="100%" cellpadding="0" cellspacing="0" border="0" >
      <caption style=" text-align:left;font-size:14px; font-weight:700; background-color:#BBBBBB;border-bottom-color:#18444E; border-left-color:#18444E">&nbsp;&nbsp;&nbsp;<span style=" color:#224EFF"> 反水列表[已审核]</span></caption>
       <thead>
      <tr>
        <th align="center">项目</th>
         <th align="center">名称</th>
        <th align="center">操作时间</th>
        <th align="center">金额</th>
        <th align="center">备注</th>
      </tr>
      </thead>
     
     <tbody id="tab2">
    </tbody> 
    <tfoot>

    </tfoot>
    </table>
    </div>
            </td>
        </tr>




          
        </table>
                </td>
        </tr>
    </table>
    </td>
   
  </tr>
</table>
    </form>
</body>
</html>
