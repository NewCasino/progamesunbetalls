<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetICBCData.aspx.cs" Inherits="admin.Bank.GetICBCData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/jQueryCommon.js"></script>
        <script src="/js/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
    <script src="/js/webBasicInfo/zh-CN.js" type="text/javascript"></script>
    <link href="/css/Default/cupertino/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .ui-effects-transfer { border: 2px dotted gray; } 
    </style>
    
    <title>工商自动到帐查询</title>
    <script type="text/javascript">
        function CurentTime1() {
            var now = new Date();
            var year = now.getFullYear();       //年
            var month = now.getMonth() + 1;     //月
            var day = now.getDate() - 1;       //日


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

            GetLoad();
            $("#username").keypress(function (e) {
                var currKey = 0, e = e || event;
                currKey = e.keyCode || e.which || e.charCode;
                if (currKey == 13) {
                    jQuery("#userBtn").click();
                }
            });
            $("#userBtn").click(function () {

                GetLoad();
            });


        });
        function GetLoad() {
            $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/GetICBCData", "userName:'" + $.trim($("#username").val()) + "',PaynumerID:'" + $.trim($("#PaynumerID").val()) + "',time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "'", true, false, function (json) {
                var result = $.parseJSON(json.d);
                // debugger
                if (json.d != "") {
                    var re = jQuery.parseJSON(json.d);
                    var html = "", total1 = 0, total2 = 0;
                    $.each(re, function (i) {
                        // debugger
                        total1 += parseFloat(re[i].payMoney);
                        total2 += parseFloat(re[i].payFree);
                        html += "<tr>";
                        html += "<td>" + (i + 1) + "</td>";
                        html += "<td>" + re[i].payNumID + "</td>";
                        html += "<td>" + re[i].userRealName + "</td>";
                        html += "<td>" + re[i].payUser + "</td>";

                        html += "<td>" + re[i].payMoney + "</td>";
                        html += "<td>" + re[i].payFree + "</td>";

                        html += "<td>工行汇款</td>";
                        html += "<td>" + re[i].payTime + "</td>";
                        html += "<td>" + re[i].createTime + "</td>";

                        html += "</tr>";
                    });

                    html += "<tr><td>总计</td><td colspan='3'></td><td class='red'>" + total1.toFixed(2) + "</td><td class='red'>" + total2.toFixed(2) + "</td><td colspan='3'></td></tr>";
                    jQuery("#tab2").html(html);

                }
            });
        }
    </script>
</head>
<body >
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p><font class="st"> 您当前的位置：</font><a href="javascript:void(0)"><span>中国工商银行到帐查询</span></a></p></th>
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
用户姓名：
<input type="text" id="username" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'"  />&nbsp;&nbsp;&nbsp;
流水号：
<input type="text" id="PaynumerID" class="text_01 h20" style="  width:180px" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'"  />&nbsp;&nbsp;&nbsp;

<input type="text" id="regIP" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'"  style=" display:none" />&nbsp;&nbsp;&nbsp;
到款时间:<input type="text" id="time1WhereVal" class="inputWhere text_01 w_120" onmouseover="this.className='text_01_h w_120'" onmouseout="this.className='text_01 w_120'" readonly="readonly"  />－<input type="text" id="time2WhereVal" class="inputWhere text_01 w_120" onmouseover="this.className='text_01_h w_120'" onmouseout="this.className='text_01 w_120'" readonly="readonly"  />&nbsp;&nbsp;&nbsp;&nbsp;
<input type="button" id="userBtn" class="btn_01" onmouseover="this.className='btn_01_h'" onmouseout="this.className='btn_01'" value="查 找" />

</div>


</div>
<div class="cl"></div>
<table id="tab3" width=100% cellpadding=0 cellspacing="0" border=0 >
<thead> 
<tr>
<th style=" width:40px">编号</th>
<th>流水号</th>
<th>用户姓名</th>
<th style=" width:70px">E尊帐号</th>
<th>金额</th>
<th>手续费</th>
<th>存款类型</th>
<th>存款时间</th>
<th>抓取时间</th>

</tr>
</thead> 
<tbody id="tab2">
<tr>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
</tr>
</tbody> 

<tfoot>
<tr>
<td colspan="9"></td>
</tr>
</tfoot>
</table>
<script src="/js/tab3.js" type="text/javascript"></script>



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
