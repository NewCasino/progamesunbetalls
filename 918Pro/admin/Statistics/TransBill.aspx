<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransBill.aspx.cs" Inherits="admin.Statistics.TransBill" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>户内转账日志</title>
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/js/page/pageJs.js" type="text/javascript"></script>
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="/js/jQueryCommon.js" type="text/javascript"></script>
    <script src="/js/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
    <script src="/js/webBasicInfo/zh-CN.js" type="text/javascript"></script>
    <style type="text/css">
    #cancelDepoist{display:none;}
    </style>
    <script type="text/javascript">
        var language = $.cookie("lan"), lan = "";
        switch (language) {
            case "zh-cn":
                lan = "cn"; break;
            case "zh-tw": lan = "tw"; break;
            case "en-us":
                lan = "en"; break;
            case "th-th":
                lan = "th"; break;
            case "vi-vn":
                lan = "vn"; break;
            default: lan = "cn"; break;
        }
        $(function () {
            //SelectByWhere();
            $("#time1WhereVal,#time2WhereVal").datepicker().click(function () {
                $(this).val("");
            });
            $("#selectByWhere").click(function () {
                if ($.trim($("#memberSel").val()) != "" || $.trim($("#memberName").val()) != "" || $.trim($("#statusSel").val()) != "0" || $("#time1WhereVal").val() != "" || $("#time2WhereVal").val() != "") {
                    SelectByWhere();
                }
            });
            $(".inputWhere").keyup(function (e) {
                var currKey = 0, e = e || event;
                currKey = e.keyCode || e.which || e.charCode;
                if (currKey == 13) {
                    SelectByWhere();
                    $(this).blur();
                }
            });
            $("#depositHistory").click(function () {
                location = "/Bank/HongLiHistory.aspx";
            });
            $("#VerifyDeposit").click(function () {
                location = "/Bank/HongLi.aspx";
            });
        });
        function SelectByWhere() {
            $("#tb2>tbody").html("");
            $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/GetHistoryBy56", "userName:'" + $.trim($("#memberSel").val()) + "',lan:'" + lan + "',name:'" + $.trim($("#memberName").val()) + "',status:'" + $.trim($("#statusSel").val()) + "',time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "'", true, false, function (json) {
                if (json.d != "") {
                    var re = jQuery.parseJSON(json.d);
                    var html = "", total1 = 0, total2 = 0;
                    $.each(re, function (i) {
                        total1 += parseFloat(re[i].d);
                        total2 += parseFloat(re[i].z == "" ? 0 : re[i].z);
                        //html += "<tr><td>" + (i + 1) + "</td><td><a href='javascript:void(0)' style='color:#0075a9' onclick=\"window.open('/User/UserInfo.aspx?u=" + re[i].b + "','','width=600,height=270');\">" + re[i].b + "</a></td><td>" + re[i].l + "</td><td style='color:red'>" + re[i].d + "</td><td>" + re[i].o + "</td><td>" + re[i].p + "</td><td>" + re[i].e + "</td><td>" + re[i].f + "</td><td>" + (re[i].g == "1" ? "未审核" : (re[i].g == "2" ? "成功" : "拒绝")) + "</td><td>" + re[i].h + "</td>";//存入帐号<td>" + re[i].q + "</td>
                        html += "<tr>";
                        html += "<td>" + (i + 1) + "</td>";
                        html += "<td><a href='javascript:void(0)' style='color:#0075a9' onclick=\"window.open('/User/UserInfo.aspx?u=" + re[i].b + "','','width=600,height=270');\">" + re[i].b + "</a></td>";
                        html += "<td>" + (re[i].c == "5" ? "总账→EA账户" : "EA账户→总账") + "</td>";
                        html += "<td class='red'>" + re[i].d + "</td>";
                        html += "<td>" + re[i].f + "</td>";
                        html += "</tr>";
                    });
                    html += "<tr><td>总计</td><td colspan='2'></td><td style='color:red'>" + total1.toFixed(2) + "</td><td colspan='9'></td></tr>";
                    $("#tb2>tbody").html(html);
                    $("#tb2>tbody>tr").mouseover(function () {
                        $(this).siblings().removeClass("trOver").end().addClass("trOver");
                    });
                    $(".cancel").unbind("click").bind("click", function () {
                        getReson();
                        var id = $(this).attr("attr");
                        $("#cancelDepoist").dialog({ modal: true, width: "330px" });
                        $("#submitBtn").unbind("click").bind("click", function () {
                            $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/CancelBNH", "id:'" + id + "',type:'1',reason:'" + $("#reason").val() + "'", true, false, function (json) {
                                if (json.d) {
                                    alert("撤消成功");
                                    $("#cancelDepoist").dialog("close");
                                    SelectByWhere();
                                } else {
                                    alert("发生意外，撤消失败");
                                }
                            });
                        });
                        $("#cancelBtn").unbind("click").bind("click", function () {
                            $("#cancelDepoist").dialog("close");
                        });
                    });
                } else {
                    $("#tb2>tbody").html("<tr><td colspan=\"15\">没有相应数据</td></tr>");
                }
            });
        }

        function getReson() {
            $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/GetReason", "", true, false, function (json) {
                if (json.d != "") {
                    var result = jQuery.parseJSON(json.d);
                    var html = "";
                    $.each(result, function (i) {
                        html += "<option value=\"" + result[i].a + "\">" + result[i].b + "</option>";
                    });
                    $("#reason").html(html);
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
<th width="*" class="tab_top_m"><p id="zdjs">户内转账日志</p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
    <input type="hidden" id="langue" value="tw" />
    <form id="form1" runat="server">
    <div  style="width:95%;padding:3px;margin:2px;">
    <a id="hyzh">会员帐号</a>&nbsp;&nbsp;<input type="text" id="memberSel" class="inputWhere text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" />&nbsp;&nbsp;&nbsp;&nbsp; 
    <a id="jysj">时间</a>&nbsp;&nbsp;<input type="text" id="time1WhereVal" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" readonly="readonly"  />－<input type="text" id="time2WhereVal" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" readonly="readonly"  />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in">搜索</span></a>
    </div>
    <table class="tab2" id="tb2" width="100%" border="0" cellpadding="0" cellspacing="0">
    <thead>
                <tr>
    <th>序号</th>
    <th>会员帐号</th>
    <th>户内转账</th>
    <th>转账金额</th>
    <th>时间</th>
    </tr>
    </thead>
    <tbody id="showInfo">
    </tbody>
    </table>
    </form>
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

<div id="cancelDepoist" title="撤消存款">
<div class="showdiv">
<ul>
<li><p><span id="cancelReason">撤消原因</span>：</p><p><select id="reason"></select>
<%--<textarea id="reason" rows="4" cols="25" class="input"></textarea>--%>
</p></li>
<li><div align="center" class="mtop_30"><br />
    <input type="button" id="submitBtn" class="btn_02" value="提交" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="cancelBtn" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></div></li>
</ul>
</div></div>
</body>
</html>
