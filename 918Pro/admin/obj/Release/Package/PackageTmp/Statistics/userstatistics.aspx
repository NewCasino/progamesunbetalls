<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userstatistics.aspx.cs" Inherits="admin.Statistics.userstatistics" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网站概况</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery-1.4.1.min.js"></script>
    <script src="/js/jQueryCommon.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(function () {
            getdata();
        });
        function getdata() {
            var data = "";
            var url = "/ServicesFile/UserService.asmx/UserStatistics";
            $.AjaxCommon(url, data, true, false, function (json) {
                if (json.d == "-1") {
                    SysLoginOut();
                } else {
                    var re = $.parseJSON(json.d);
                    var easy = -re.dd;
                    var ptsy = -re.gg;
                    $("#tab tr:eq(0) td:eq(1)").html("&nbsp;" + re.a);

                    $("#tab tr:eq(1) td:eq(1)").html("&nbsp;" + re.b);
                    $("#tab tr:eq(1) td:eq(3)").html("&nbsp;" + (re.a - re.b));

                    $("#tab tr:eq(2) td:eq(1)").html("&nbsp;" + re.c);

                    $("#tab tr:eq(3) td:eq(1)").html("&nbsp;" + re.d);
                    $("#tab tr:eq(3) td:eq(3)").html("&nbsp;" + re.e);

                    $("#tab tr:eq(4) td:eq(1)").html("&nbsp;" + re.f);
                    $("#tab tr:eq(4) td:eq(3)").html("&nbsp;" + re.g);

                    $("#tab tr:eq(5) td:eq(1)").html("&nbsp;" + re.bb + "&nbsp;<span style='color:#999999; font-weight:normal;'>(包括和局)</span>&nbsp;&nbsp;" + re.cc + "&nbsp;<span style='color:#999999;font-weight:normal;'>(不包括和局)</span>");
                    $("#tab tr:eq(5) td:eq(3)").html("&nbsp;" + easy);

                    //                    $("#tab tr:eq(6) td:eq(1)").html("&nbsp;" + re.ee + "&nbsp;<span style='color:#999999; font-weight:normal;'>(包括和局)</span>&nbsp;&nbsp;" + re.ff + "&nbsp;<span style='color:#999999;font-weight:normal;'>(不包括和局)</span>");
                    //                    $("#tab tr:eq(6) td:eq(3)").html("&nbsp;" + ptsy);

                    $("#tab tr:eq(7) td:eq(1)").html("&nbsp;" + (parseFloat(re.bb) + parseFloat(re.ee)).toFixed(2) + "&nbsp;<span style='color:#999999; font-weight:normal;'>(包括和局)</span>&nbsp;&nbsp;" + (parseFloat(re.cc) + parseFloat(re.ff)).toFixed(2) + "&nbsp;<span style='color:#999999;font-weight:normal;'>(不包括和局)</span>");
                    $("#tab tr:eq(7) td:eq(3)").html("&nbsp;" + (parseFloat(easy) + parseFloat(ptsy)).toFixed(2));

                    //$("#tab tr:eq(8) td:eq(3)").html("&nbsp;" + (re.e - re.g));


                    $("#tab tr:eq(8) td:eq(1)").html("&nbsp;" + re.h);
                    $("#tab tr:eq(8) td:eq(3)").html("&nbsp;" + (parseFloat(re.i) + parseFloat(re.aa)).toFixed(2) + "&nbsp;<span style='color:#999999; font-weight:normal;'>(太阳城:</span>&nbsp;" + re.i + "&nbsp;<span style='color:#999999; font-weight:normal;'>其它:</span>&nbsp;" + re.aa + "<span style='color:#999999; font-weight:normal;'>)</span>");
                    $("#tab tr:eq(9) td:eq(1)").html("&nbsp;" + (parseFloat(re.e) - parseFloat(re.g)).toFixed(2) + "&nbsp;<span style='color:green; font-weight:normal;'>(总输赢-红利-返水)</span>");
                }
            });
        }
    </script>
</head>
<body>
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p><font class="st"> 网站概况</font></p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<!--主题部分开始=========================================================================================-->
<table id="tab3" width=100% cellpadding=0 cellspacing="0" border=0 >
<thead> 
<tr>
<th colspan="4">网站概况</th>
</tr>
</thead> 
<tbody id="tab" style="font-weight:bold;">
<tr style="height:28px;">
<td style="text-align:right; width:20%;background-color:#d1f0ff;">注册会员：</td>
<td style="text-align:left; color:Blue; background-color:#fffff0;"><img src="/images/spinner.gif" /></td>
<td style="text-align:right; width:20%;background-color:#d1f0ff;"></td>
<td style="text-align:left; color:Blue; background-color:#fffff0;"></td>
</tr>
<tr style="height:28px;">
<td style="text-align:right; width:20%;background-color:#d1f0ff;">存款会员：</td>
<td style="text-align:left; color:Blue;"></td>
<td style="text-align:right; width:20%;background-color:#d1f0ff;">未存款会员：</td>
<td style="text-align:left; color:Blue;"></td>
</tr>
<tr style="height:28px;">
<td style="text-align:right; width:20%;background-color:#d1f0ff;">今日注册会员：</td>
<td style="text-align:left; color:Blue; background-color:#fffff0;"></td>
<td style="text-align:right; width:20%;background-color:#d1f0ff;"></td>
<td style="text-align:left; color:Blue; background-color:#fffff0;"></td>
</tr>
<tr style="height:28px;">
<td style="text-align:right; width:20%;background-color:#d1f0ff;">今日存款会员：</td>
<td style="text-align:left; color:Blue;"></td>
<td style="text-align:right; width:20%;background-color:#d1f0ff;">今日存款金额：</td>
<td style="text-align:left; color:Red;"></td>
</tr>

<tr style="height:28px;">
<td style="text-align:right; width:20%;background-color:#d1f0ff;">今日取款会员：</td>
<td style="text-align:left; color:Blue;"></td>
<td style="text-align:right; width:20%;background-color:#d1f0ff;">今日取款金额：</td>
<td style="text-align:left; color:Red;"></td>
</tr>

<tr style="height:28px;">
<td style="text-align:right; width:20%;background-color:#d1f0ff;">今日流水(太阳城)：</td>
<td style="text-align:left; color:Red;"></td>
<td style="text-align:right; width:20%;background-color:#d1f0ff;">今日输赢(太阳城)：</td>
<td style="text-align:left; color:Red;"></td>
</tr>
<tr style="height:1px;"></tr>

<tr style="height:28px;">
<td style="text-align:right; width:20%;background-color:#d1f0ff;">今日总流水：</td>
<td style="text-align:left; color:Red;"></td>
<td style="text-align:right; width:20%;background-color:#d1f0ff;">今日总输赢：</td>
<td style="text-align:left; color:Red;"></td>
</tr>



<tr style="height:28px;">
<td style="text-align:right; width:20%;background-color:#d1f0ff;">今日红利：</td>
<td style="text-align:left; color:Red;"></td>
<td style="text-align:right; width:20%;background-color:#d1f0ff;">今日返水：</td>
<td style="text-align:left; color:Red;"></td>
</tr>

<tr style="height:58px;">
<td style="text-align:right; width:20%;background-color:#d1f0ff;">今日盈利：</td>
<td style="text-align:left; color:Red; background-color:#fffff0;"></td>
<td style="text-align:right; width:20%;background-color:#d1f0ff;"></td>
<td style="text-align:left; color:Red; background-color:#fffff0;"></td>

</tr>

</tr>

</tbody> 

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
