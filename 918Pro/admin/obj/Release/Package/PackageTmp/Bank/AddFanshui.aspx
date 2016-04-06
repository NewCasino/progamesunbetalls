<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFanshui.aspx.cs" Inherits="admin.Bank.AddFanshui" %>

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
    <script src="/js/webBasicInfo/zh-CN.js" type="text/javascript"></script>
    <link href="/css/Default/cupertino/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .ui-effects-transfer { border: 2px dotted gray; } 
    </style>
    
    <title>返水申请</title>
    <script type="text/javascript">
        jQuery(function () {
            var arg = GetRequest();
            if (arg != undefined) {
                var u = arg["u"];
                if (u != undefined) {
                    $("#username").val(u);
                }
            }
            $("#txttz,#txtbl").blur(function () {
                jslse();
            });
            $("#txtdate1,#txtdate2").datepicker();
            SetTime(-1);
            $("#btnSubmit").click(function () {
                var username = $("#username").val();
                var txtamount = $("#txtamount").val();
                var txtdate1 = $("#txtdate1").val();
                var txttime1 = $("#txttime1").val();
                var txtdate2 = $("#txtdate2").val();
                var txttime2 = $("#txttime2").val();
                var txtbl = $("#txtbl").val();
                var mark = $("#txtmark").val();
                var txttz = $("#txttz").val();
                //验证输入
                var check = true;
                $.each($("#addtb :text"), function (i, n) {
                    $(n).blur();
                });
                $.each($("#addtb span[id*=err]"), function (i, n) {
                    if ($(n).text() != "") {
                        check = false;
                        return false;
                    }
                });
                if (check == false) {
                    return;
                }
                //提交数据
                var url = "/ServicesFile/BankService/BankService.asmx/AddFanShui";
                var data = "userName:'" + username + "',type:'" + $("#fstype").val() + "',amount:" + txtamount + ",status:'1',mark:'" + mark + "',fsbl:'" + txtbl + "',time1:'" + txtdate1 + " " + txttime1 + "',time2:'" + txtdate2 + " " + txttime2 + "',validamount:" + txttz;
                $.AjaxCommon(url, data, true, false, function (json) {
                    if (json.d) {
                        alert("添加返水成功！");
                        window.close();
                    } else {
                        alert("添加返水失败！");
                    }
                });
            });
            $("#btnCancel").click(function () {
                $.each($("#addtb :text"), function (i, n) {
                    if ($(n).attr("id") != "username") {
                        $(n).val("");
                    }
                });
                $.each($("#addtb span[id*=err]"), function (i, n) {
                    $(n).html("");
                });
            });
        });
        function jslse() {
            var txttz = $("#txttz").val();
            var txtbl = $("#txtbl").val();
            $("#hmoney,#bmoney").blur();
            if ($("#err4").html() == "" && $("#err5").html() == "") {
                //计算
                var fsje = parseFloat(txttz) * (parseFloat(txtbl) / 100);
                $("#txtamount").val(fsje.toFixed(2));
            }
        }
        function SetTime(n) {
            var date = new Date();
            $("#txtdate2").val(date.getYear()+"-"+(date.getMonth()+1)+"-"+date.getDate());
            date.setDate(date.getDate() + n);
            $("#txtdate1").val(date.getYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate());
            //$("#txttime1,#txttime2").val(date.toLocaleTimeString());
            $("#txttime1").val("12:00:00");
            $("#txttime2").val("11:59:59");
        }
    </script>
</head>
<body >
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p><font class="st"> 返水申请</font></p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<!--主题部分开始=========================================================================================-->

<div class="top_banner">
    <table id="addtb" width="100%" cellpadding="0" style="margin-top:10px;">
    <tr><td class="tr" width="30%" height="40px"><strong>游戏项目：</strong></td><td  class="tl"><select id="fstype"><option value="4">太阳城游戏</option><%--<option value="14">PT游戏</option>--%></select></td></tr>
    <tr><td class="tr" height="40px"><strong>会员号：</strong></td><td class="tl"><input type="text" readonly id="username" onblur="IsNullByInfo(this,'err1','必填');" class="input_out"/><span id="err1" style="color:Red"></span></td></tr>
    <tr><td class="tr" height="40px"><strong>有效投注起始时间：</strong></td><td class="tl">
        <input type="text" id="txtdate1" onblur="IsNullByInfo(this,'err2','必填');" class="input_out"/>
        <input type="text" id="txttime1" onblur="IsNullByInfo(this,'err2','必填');" class="input_out w_60"/><span id="err2" style="color:Red"></span>
    </td></tr>
    <tr><td class="tr" height="40px"><strong>有效投注结束时间：</strong></td><td class="tl">
        <input type="text" id="txtdate2" onblur="IsNullByInfo(this,'err3','必填');" class="input_out"/>
        <input type="text" id="txttime2" onblur="IsNullByInfo(this,'err3','必填');" class="input_out w_60"/><span id="err3" style="color:Red"></span>
    </td></tr>
    <tr><td class="tr" height="40px"><strong>有效投注额：</strong></td><td class="tl">
        <input type="text" id="txttz" onblur="IsElJudge(this,'err4','number','必填','错误',20);" class="input_out"/><span id="err4" style="color:Red"></span>
    </td></tr>
    <tr><td class="tr" height="40px"><strong>返水比率：</strong></td><td class="tl">
        <input type="text" id="txtbl" onblur="IsElJudge(this,'err5','decimal','必填','错误',20);" class="input_out w_30"/>%<span id="err5" style="color:Red"></span>
    </td></tr>
    <tr><td class="tr" height="40px"><strong>返水金额：</strong></td><td class="tl">
        <input type="text" id="txtamount" onblur="IsElJudge(this,'err6','number','必填','错误',20);" class="input_out"/><span id="err6" style="color:Red"></span>
    </td></tr>
    <tr><td class="tr" height="40px"><strong>备注：</strong></td><td class="tl">
    <textarea id="txtmark" cols="30" rows="5"></textarea>
    </td></tr>
    <tr><td colspan="2" align="center" height="80px"><input type="button" value="添加返水" class="btn_02_h"  id="btnSubmit" onmouseover="this.className='btn_02'" onmouseout="this.className='btn_02_h'" />  &nbsp;
    <input class="btn_02" type="button" value="取消" id="btnCancel" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'"  /></td></tr>
    </table>


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
</body>
</html>