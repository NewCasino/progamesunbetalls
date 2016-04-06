<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddLi.aspx.cs" Inherits="admin.Bank.AddLi" %>

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
    
    <title>红利申请</title>
    <script type="text/javascript">
        jQuery(function () {
            var arg = GetRequest();
            if (arg != undefined) {
                var u = arg["u"];
                if (u != undefined) {
                    $("#username").val(u);
                }
            }
            $("#lsbs").blur(function () {
                jslse();
            });
            $("#btnSubmit").click(function () {
                var username = $("#username").val();
                var hmoney = $("#hmoney").val();
                var bmoney = $("#bmoney").val();
                var lsbs = $("#lsbs").val();
                var lse = $("#lse").val();
                var mark = $("#mark").val();
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
                debugger
                var url = "/ServicesFile/BankService/BankService.asmx/AddHongLi";
                var data = "userName:'" + username + "',type:'3',amount:" + hmoney + ",status:'1',mark:'" + mark + "'";
                $.AjaxCommon(url, data, true, false, function (json) {
                    if (json.d) {
                        alert("添加红利成功！");
                        window.close();
                    } else {
                        alert("添加红利失败！");
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
            var hmoney = $("#hmoney").val();
            var bmoney = $("#bmoney").val();
            var lsbs = $("#lsbs").val();
            $("#hmoney,#bmoney").blur();
            if ($("#err2").html() == "" && $("#err3").html() == "" && $("#err4").html() == "") {
                //计算
                $("#lse").val((parseFloat(hmoney) + parseFloat(bmoney)) * parseFloat(lsbs));
            }
        }
    </script>
</head>
<body >
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p><font class="st"> 红利申请</font></p></th>
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
    <tr><td class="tr" width="10%" height="40px"><strong>游戏项目：</strong></td><td  class="tl"><select><option>太阳城游戏</option></select></td></tr>
    <tr><td class="tr" height="40px"><strong>会员号：</strong></td><td class="tl"><input type="text" readonly id="username" onblur="IsNullByInfo(this,'err1','必填');" class="input_out"/><span id="err1" style="color:Red"></span></td></tr>
    <tr><td class="tr" height="40px"><strong>红利金额：</strong></td><td class="tl">
        <strong style="color:Blue;">（</strong><input type="text" id="hmoney" onblur="IsElJudge(this,'err2','number','必填','错误',20);" style="width:110px;" class="input_out"/><span id="err2" style="color:Red"></span> <strong style="color:Blue;">＋</strong> 本金<input type="text" style="width:110px;" id="bmoney" onblur="IsElJudge(this,'err3','number','必填','错误',20);" class="input_out"/><span id="err3" style="color:Red"></span>
        <strong style="color:Blue;">）X</strong> 流水倍数<input type="text" id="lsbs" onblur="IsElJudge(this,'err4','number','必填','错误',20);" style="width:50px;" class="input_out"/><span id="err4" style="color:Red"></span>
        <strong style="color:Blue;">＝</strong> 红利流水额<input type="text" readonly id="lse" style="width:110px;" class="input_out"/>
    </td></tr>
    <tr><td class="tr" height="40px"><strong>备注：</strong></td><td class="tl"><textarea id="mark" cols="30" rows="5"></textarea><br /></td></tr>
    <tr><td colspan="2" align="center" height="80px"><input type="button" value="添加红利" class="btn_02_h"  id="btnSubmit" onmouseover="this.className='btn_02'" onmouseout="this.className='btn_02_h'"    />  &nbsp;
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