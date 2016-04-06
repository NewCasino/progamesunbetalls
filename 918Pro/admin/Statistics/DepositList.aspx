<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepositList.aspx.cs" Inherits="admin.Statistics.DepositList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=7" />
     <title>用户存款记录</title>
        <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
   <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
     <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
        <script src="/js/jQueryCommon.js" type="text/javascript"></script>
        <script src="/js/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
    <script src="/js/webBasicInfo/zh-CN.js" type="text/javascript"></script>
    <style type="text/css">
 


    </style>    
   
    <script type="text/javascript">
      
        function CurentTime2() {
            var now = new Date();
            var year = now.getFullYear();       //年
            var month = now.getMonth() + 1;     //月
            var day = now.getDate();       //日


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
        jQuery(function () {
            jQuery("#time1WhereVal").datepicker();
            $('#time1WhereVal').val(CurentTime2());
            jQuery("#time2WhereVal").datepicker();
            $('#time2WhereVal').val(CurentTime2());

            $("#selectByWhere").click(function () {
                GetUserInfo0();
                GetUserInfo1();
                GetUserInfo2();
            });
          
        });
        function GetUserInfo0() {
            //alert("ee");
            //  debugger          

            var htm = "", total1 = 0;
            var url = "/ServicesFile/BankService/BankService.asmx/GetBillNoticeHistory_user";
            var datas = "username :'" + $("#username3").val() + "', type:'1',time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',agent:'" + $("#agent3").val() + "'";
            jQuery.AjaxCommon(url, datas, false, false, function (json) {
                //alert(json.d);
                if (json.d != "") {
                    var result = jQuery.parseJSON(json.d);
                    jQuery.each(result, function (i, n) {

                        htm += "<tr>";
                        htm += "<td>" + (i + 1) + "</td>";
                        htm += "<td>" + n.UserName + "</td>";
                        htm += "<td  class='red'>" + n.Amount + "</td>";
                        total1 += parseFloat(n.Amount);
                        htm += "<td>" + n.UpdateTime + "</td>";
                        var agneturl = "http://www.sunbo8.com:800/?";
                        htm += "<td>" + agneturl + "" + n.Agent + "</td>";
                        htm += "</tr>";
                    });
                    htm += "<tr><td>总计</td><td colspan='1'></td><td style='color:red'>" + total1.toFixed(2) + "</td><td ></td></tr>";
                }
                else {
                    total1 = 0;
                    htm += "<tr>";
                    htm += "<td  colspan='4' ><span style='color:#224EFF'>---------无数据--------</span></td>";

                    htm += "</tr>";
                }

                jQuery("#tab1").html(htm);
                $(document).ready(function () {
                    //=============================================表格1,须和jQueryCommon-min.js一起调用
                    jQuery(".tab1").alterBgColor({ odd: "odd", even: "even", selected: "selected", moveOver: "over", tdCss: "tdCss", istdClick: true });

                });
            });
        }

        function GetUserInfo1() {
            //alert("ee");
          //  debugger          

                var htm = "", total1 = 0;
                var url = "/ServicesFile/BankService/BankService.asmx/GetBillNoticeHistory_user";
                var datas = "username :'" + $("#username3").val() + "', type:'3',time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',agent:'"+$("#agent3").val()+"'";
                jQuery.AjaxCommon(url, datas, false, false, function (json) {
                    //alert(json.d);
                    if (json.d != "") {
                        var result = jQuery.parseJSON(json.d);
                        jQuery.each(result, function (i, n) {
                          
                            htm += "<tr>";
                            htm += "<td>" + (i + 1) + "</td>";
                            htm += "<td>"+n.UserName+"</td>";
                            htm += "<td  class='red'>" + n.Amount + "</td>";
                            total1 += parseFloat(n.Amount);
                            htm += "<td>" + n.UpdateTime + "</td>";
                            var agneturl = "http://www.sunbo8.com:800/?";
                            htm += "<td>"+agneturl+""+n.Agent+"</td>";
                            htm += "</tr>";
                        });
                        htm += "<tr><td>总计</td><td colspan='1'></td><td style='color:red'>" + total1.toFixed(2) + "</td><td ></td></tr>";
                    }
                    else {
                        total1 = 0;
                        htm += "<tr>";
                        htm += "<td  colspan='4' ><span style='color:#224EFF'>---------无数据--------</span></td>";

                        htm += "</tr>";
                    }

                    jQuery("#tab2").html(htm);
                    $(document).ready(function () {
                        //=============================================表格1,须和jQueryCommon-min.js一起调用
                        jQuery(".tab1").alterBgColor({ odd: "odd", even: "even", selected: "selected", moveOver: "over", tdCss: "tdCss", istdClick: true });

                    });
                });
            }
            function GetUserInfo2() {
                //alert("ee");
                //  debugger          

                var htm = "", total1 = 0;
                var url = "/ServicesFile/BankService/BankService.asmx/GetBillNoticeHistory_user";
                var datas = "username :'" + $("#username3").val() + "', type:'4',time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',agent:'" + $("#agent3").val() + "'";
                jQuery.AjaxCommon(url, datas, false, false, function (json) {
                    //alert(json.d);
                    if (json.d != "") {
                        var result = jQuery.parseJSON(json.d);
                        jQuery.each(result, function (i, n) {

                            htm += "<tr>";
                            htm += "<td>" + (i + 1) + "</td>";
                            htm += "<td>" + n.UserName + "</td>";
                            htm += "<td  class='red'>" + n.Amount + "</td>";
                            total1 += parseFloat(n.Amount);
                            htm += "<td>" + n.UpdateTime + "</td>";
                            var agneturl = "http://www.sunbo8.com:800/?";
                            htm += "<td>" + agneturl + "" + n.Agent + "</td>";
                            htm += "</tr>";
                        });
                        htm += "<tr><td>总计</td><td colspan='1'></td><td style='color:red'>" + total1.toFixed(2) + "</td><td ></td></tr>";
                    }
                    else {
                        total1 = 0;
                        htm += "<tr>";
                        htm += "<td  colspan='4' ><span style='color:#224EFF'>---------无数据--------</span></td>";

                        htm += "</tr>";
                    }

                    jQuery("#tab3").html(htm);
                    $(document).ready(function () {
                        //=============================================表格1,须和jQueryCommon-min.js一起调用
                        jQuery(".tab1").alterBgColor({ odd: "odd", even: "even", selected: "selected", moveOver: "over", tdCss: "tdCss", istdClick: true });

                    });
                });
            }
           
    </script>
</head>
<body >
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p><font class="st"> 用户存款记录</font></p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<!--主题部分开始=========================================================================================-->
<div class="top_banner h30">
<div class="fl">
按会员模糊查询：<input type="text" class="text_01 h20" id="username3" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'"  />&nbsp;&nbsp;
代理域名：<input type="text"  class="text_01 h20" id="agent3" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'"  />&nbsp;&nbsp;
按时间查询:<input type="text" id="time1WhereVal" class="inputWhere text_01 w_120" onmouseover="this.className='text_01_h w_120'" onmouseout="this.className='text_01 w_120'" readonly="readonly"  />－<input type="text" id="time2WhereVal" class="inputWhere text_01 w_120" onmouseover="this.className='text_01_h w_120'" onmouseout="this.className='text_01 w_120'" readonly="readonly"  />&nbsp;&nbsp;&nbsp;&nbsp;
<input type="button" class="btn_01" onmouseover="this.className='btn_01_h'" id="selectByWhere" onmouseout="this.className='btn_01'" value="查找用户" />

</div>



</div>
<div class="cl"></div>
<table  width="100%"><tr><td style=" text-align:center"><span style=" color:Blue; font-size:15px; font-weight:600">存  款</span></td>
<td style=" text-align:center"><span style=" color:Blue; font-size:15px; font-weight:600">红  利</span></td>
<td style=" text-align:center"><span style=" color:Blue; font-size:15px; font-weight:600">返  水</span></td>
</tr></table>
<table width="100%">
    <tr>
       <td valign="top" style=" width:33%">
       <table class="tab1" width=100% cellpadding=0 cellspacing="0" border=0 >

        <thead> 
        <tr>
        <th>序号</th>
        <th>会员号</th>
        <th>存款金额</th>
        <th>存款时间</th>
        <th>代理域名</th>
        </tr>
        </thead> 
        <tbody id="tab1" style=" border:1px; border-bottom-color:Black">
        </tbody> 
        <tfoot>   
        </tfoot>

        </table>

       </td>
       <td valign="top" style=" width:33%">
        <table class="tab1" width=100% cellpadding=0 cellspacing="0" border=0 >

        <thead> 
        <tr>
          <th>序号</th>
        <th>会员号</th>
        <th>红利金额</th>
        <th>红利时间</th>
        <th>代理域名</th>
        </tr>
        </thead> 
        <tbody id="tab2">
        </tbody> 
        <tfoot>   
        </tfoot>

</table>

        </td>
       <td valign="top" style=" width:33%">
        <table class="tab1" width=100% cellpadding=0 cellspacing="0" border=0 >

<thead> 
<tr>
 <th>序号</th>
<th>会员号</th>
<th>返水金额</th>
<th>返水时间</th>
<th>代理域名</th>
</tr>
</thead> 
 <tbody id="tab3">
        </tbody> 
        <tfoot>   
        </tfoot>

</table>

        </td>
    </tr>
</table>




</div>
<!--主题部分结束=========================================================================================-->
</div>
</td>
<td class="tab_middle_r"></td>
</tr>
</tbody>

<tfoot>
<tr class="h35">
<td width="12" class="tab_foot_l"></td>
<td width="*" class="tab_foot_m">

</td>
<td width="16" class="tab_foot_r"></td>
</tr>
</tfoot>
</table>
</body>
</html>