<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IP.aspx.cs" Inherits="admin.Statistics.IP" %>

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
    <style type="text/css">
    .ui-effects-transfer { border: 2px dotted gray; } 
    </style>
    
    <title>IP统计</title>
    <script type="text/javascript">
        jQuery(function () {


            $("#username").keypress(function (e) {
                var currKey = 0, e = e || event;
                currKey = e.keyCode || e.which || e.charCode;
                if (currKey == 13) {
                    jQuery("#userBtn").click();
                }
            });
            $("#userBtn").click(function () {
                if ($("#username").val() == "" & $("#loginIP").val() == "" & $("#regIP").val() == "") {
                    return;
                }
                var url = "/ServicesFile/UserService.asmx/IPStatistics";
                var data = "username:'" + $("#username").val() + "',loginIP:'" + $("#loginIP").val() + "',regIp:'" + $("#regIP").val() + "'";
                $.AjaxCommon(url, data, true, false, function (json) {
                    var result = $.parseJSON(json.d);
                    var html = "";
                    if ($("#regIP").val() == "") {
                        $("#tab3 tr:eq(0)").html("<th>序号</th><th>会员号</th><th>登录IP</th><th>登录时间</th><th>地址</th>");
                        $.each(result, function (i, n) {
                            html += "<tr>";
                            html += "<td>" + (i + 1) + "</td>";
                            html += "<td><a href='javascript:void(0)' style='color:#0075a9' onclick=\"window.open('/User/UserInfo.aspx?u=" + n.username + "','','width=600,height=270');\">" + n.username + "</a></td>";
                            html += "<td>" + n.ip + "</td>";
                            html += "<td>" + n.time1 + "</td>";
                            html += "<td>" + n.mark + "</td>";
                            html += "</tr>";
                        });
                    }
                    else {
                        $("#tab3 tr:eq(0)").html("<th>序号</th><th>会员号</th><th>注册IP</th><th>注册时间</th>");
                        $.each(result, function (i, n) {
                            html += "<tr>";
                            html += "<td>" + (i + 1) + "</td>";
                            html += "<td><a href='javascript:void(0)' style='color:#0075a9' onclick=\"window.open('/User/UserInfo.aspx?u=" + n.username + "','','width=600,height=270');\">" + n.username + "</a></td>";
                            html += "<td>" + n.regip + "</td>";
                            html += "<td>" + n.RegistrationTime + "</td>";
                            html += "</tr>";
                        });
                    }
                    $("#tab").html(html);
                });
            });
            var arg = GetRequest();
            if (arg != undefined) {
                var u = arg["u"];
                var loginIP = arg["ip1"]
                var regIP = arg["ip2"];
                u = (u == undefined ? "" : u);
                loginIP = (loginIP == undefined ? "" : loginIP);
                regIP = (regIP == undefined ? "" : regIP);

                $("#username").val(u);
                $("#loginIP").val(loginIP);
                $("#regIP").val(regIP);
                $("#userBtn").click();
            }
        });
    </script>
</head>
<body >
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p><font class="st"> 您当前的位置：</font><a href="javascript:void(0)"><span> IP统计</span></a></p></th>
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
会员号：
<input type="text" id="username" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'"  />
登录IP：
<input type="text" id="loginIP" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'"  />
注册IP：
<input type="text" id="regIP" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'"  />
<input type="button" id="userBtn" class="btn_01" onmouseover="this.className='btn_01_h'" onmouseout="this.className='btn_01'" value="查找用户" />

</div>


</div>
<div class="cl"></div>
<table id="tab3" width=100% cellpadding=0 cellspacing="0" border=0 >
<thead> 
<tr>
<th>序号</th>
<th>会员号</th>
<th>登录IP</th>
<th>登录时间</th>
<th>地址</th>
</tr>
</thead> 
<tbody id="tab">
<tr>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
</tr>
</tbody> 

<tfoot>
<tr>
<td colspan="5"></td>
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