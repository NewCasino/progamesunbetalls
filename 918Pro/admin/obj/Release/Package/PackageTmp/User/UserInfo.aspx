<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="admin.User.UserInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会员资料</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="/js/jQueryCommon.js"></script>
        <script type="text/javascript">
            jQuery(function () {
                var u = "";
                var arg = GetRequest();
                if (arg != undefined) {
                    u = arg["u"];

                }

                var url = "/ServicesFile/UserService.asmx/GetUserInfo";
                var data = "userName:'" + u + "'";
                $.AjaxCommon(url, data, true, false, function (json) {
                    var result = $.parseJSON(json.d);
                    $.each(result, function (i, n) {
                        $("#txtuser tr:eq(0) td:eq(1)").html(n.UserName);
                        $("#txtuser tr:eq(0) td:eq(3)").html(n.name);
                        $("#txtuser tr:eq(1) td:eq(1)").html(n.nicheng);
                        $("#txtuser tr:eq(1) td:eq(3)").html(n.Balance);
                        $("#txtuser tr:eq(2) td:eq(1)").html(n.status == "1" ? "启用" : "禁用");
                        $("#txtuser tr:eq(2) td:eq(3)").html(n.fstatus);
                        $("#txtuser tr:eq(3) td:eq(1)").html(n.qkcs);
                        $("#txtuser tr:eq(3) td:eq(3)").html(n.soucunsj);
                        $("#txtuser tr:eq(4) td:eq(1)").html(n.RegistrationTime);
                        $("#txtuser tr:eq(4) td:eq(3)").html(n.regip);
                        $("#txtuser tr:eq(5) td:eq(1)").html(n.LastLoginTime);
                        $("#txtuser tr:eq(5) td:eq(3)").html(n.LastLoginIP);
                        $("#txtuser tr:eq(6) td:eq(1)").html(n.agent);
                        $("#txtuser tr:eq(6) td:eq(3)").html(n.UserLevel);
                        $("#txtuser tr:eq(7) td:eq(1)").html(n.cunkuanfs);
                        $("#txtuser tr:eq(7) td:eq(3)").html(n.email);
                        $("#txtuser tr:eq(8) td:eq(1)").html(n.tel);
                        $("#txtuser tr:eq(9) td:eq(1)").html(n.question);
                        $("#txtuser tr:eq(9) td:eq(3)").html(n.answer);
                        $("#txtuser tr:eq(10) td:eq(1)").html(n.birthday);
                        $("#txtuser tr:eq(10) td:eq(3)").html(n.post);
                    });
                });

            });
    </script>

</head>
<body>
<form action="">
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p><font class="st"> 您当前的位置：</font><a href="javascript:void(0)"><span> 会员资料</span></a></p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<center>
<div >
    <table id="txtuser" width="100%" cellpadding="0" style="margin-top:10px;">
    <tr><td class="tr">会员号：</td><td  class="tl"></td><td class="tr">姓名：</td><td class="tl"></td></tr>
    <tr><td class="tr">昵称：</td><td  class="tl"></td><td class="tr">余额：</td><td class="tl"></td></tr>
    <tr><td class="tr">状态：</td><td  class="tl"></td><td class="tr">返水状态：</td><td class="tl"></td></tr>
    <tr style=" display:none;"><td class="tr">提款次数：</td><td  class="tl"></td><td class="tr">首存时间：</td><td class="tl"></td></tr>
    <tr><td class="tr">注册时间：</td><td  class="tl"></td><td class="tr">注册IP：</td><td class="tl"></td></tr>
    <tr><td class="tr">最后登录时间：</td><td  class="tl"></td><td class="tr">最后登录IP：</td><td class="tl"></td></tr>
    <tr><td class="tr">代理：</td><td  class="tl"></td><td class="tr">会员等级：</td><td class="tl"></td></tr>
    <tr><td class="tr">存款方式：</td><td  class="tl"></td><td class="tr">Email：</td><td class="tl"></td></tr>
    <tr><td class="tr">联系电话：</td><td  class="tl"></td><td class="tr"></td><td class="tl"></td></tr>
    <tr><td class="tr">安全问题：</td><td  class="tl"></td><td class="tr">安全问题答案：</td><td class="tl"></td></tr>
    <tr><td class="tr">出生日期：</td><td  class="tl"></td><td class="tr">QQ：</td><td class="tl"></td></tr>
    </table>
    </div>
    </center>
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
    <div id="tip"></div>
</form>
</body>
</html>
