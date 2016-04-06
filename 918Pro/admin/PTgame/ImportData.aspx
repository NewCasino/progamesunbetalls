<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportData.aspx.cs" Inherits="admin.PTgame.ImportData" %>

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
    <script src="/js/webBasicInfo/zh-CN.js" type="text/javascript"></script>
    <link href="/css/Default/cupertino/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.blockUI.js" type="text/javascript"></script>
    <style type="text/css">
    .ui-effects-transfer { border: 2px dotted gray; } 
    </style>
    
    <title>导入PT数据</title>
    <script type="text/javascript">
        jQuery(function () {
            $("#uptime").datepicker().val(SetTime(-1));
            $("#Button2").click(function () {
                $.blockUI({
                    message: "<h1>正在导入，请稍等...</h1>",
                    overlayCSS: {
                        backgroundColor: '#000',
                        opacity: 0.3
                    }
                });
            });
        });
        function SetTime(n) {
            var date = new Date();
            var mon = "";
            var dat = "";
            date.setDate(date.getDate() + n);
            mon = date.getMonth() + 1;
            dat = date.getDate();
            mon = mon < 10 ? ("0" + mon) : mon;
            dat = dat < 10 ? ("0" + dat) : dat;
            return (date.getYear() + "-" + mon + "-" + dat);
        }
    </script>
</head>
<body >
<form runat="server">
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p><font class="st"> 导入PT数据</font></p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<!--主题部分开始=========================================================================================-->
<div class="top_banner" style="height:230px;">
<div class="fl">
<p>
<span style="color:Blue; font-weight:bold;">注意：</span>
<ul>
    <li>　导入的Excel文档必需是从PT代理平台导出</li>
    <li>　限制每天只能导入数据一次，必需每天导入数据</li>
</ul>
<br />
</p>
<p style="line-height:30px;">请选择PT Excel文档：<asp:FileUpload ID="FileUpload1" runat="server" /> &nbsp;&nbsp;&nbsp;&nbsp;</p>
<p style="line-height:30px;">请选择PT数据的日期：
<asp:TextBox ID="uptime" runat="server" CssClass="text_01 h20 w_100" onmouseover="this.className='text_01_h h20 w_100'" onmouseout="this.className='text_01 h20 w_100'" />
&nbsp;<span style="color:#999999">PT数据日期是指玩家游戏统计的日期，不是上传数据的日期</span>
</p>
<p style="line-height:50px;">　　　　　　　　　　　　　<asp:Button ID="Button2" CssClass="btn_01" onmouseover="this.className='btn_01_h'" onmouseout="this.className='btn_01'" runat="server" Text="导入数据" OnClick="Upload" /></p>
<p>　　<asp:Label ID="msg" runat="server" ForeColor="Red"></asp:Label></p>
</div>

</div>
<div class="cl"></div>


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
</form>
</body>
</html>