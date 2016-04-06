<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WithDrawalHistory.aspx.cs" Inherits="admin.Bank.WithDrawalHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>提款历史记录</title>
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
    #cancelWithDrawal{display:none;}
    #bankInfo{display:none;}
    </style>
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

        var bankArr = new Array; 
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
            $("#withdrawalHistory").click(function () {
                    location = "/Bank/WithDrawalHistory.aspx";
                });
            $("#VerifyWithDrawal").click(function () {
                location = "/Bank/VerifyWithDrawal.aspx";
            })
            GetBankArr();
            //SelectByWhere();

            jQuery("#time1WhereVal").datepicker();
            $('#time1WhereVal').val(CurentTime2());
                jQuery("#time2WhereVal").datepicker();
                $('#time2WhereVal').val(CurentTime2());
                 SelectByWhere();
            $("#selectByWhere").click(function () {
                if ($.trim($("#memberSel").val()) != "" || $.trim($("#memberName").val()) != "" || $.trim($("#statusSel").val()) != "0" || $("#time1WhereVal").val() != "" || $("#time2WhereVal").val() != "") {
                    SelectByWhere();
                }
            });
            $(".inputWhere").keyup(function (e) {
                var currKey = 0, e = e || event;
                currKey = e.keyCode || e.which || e.charCode;
                if (currKey == 13) {
                    selectByWhere();
                    $(this).blur();
                }
            });
            $("#verifyWithDrawal").click(function () {
                location = "/Bank/VerifyWithDrawal.aspx";
            });
        });
        function SelectByWhere() {
            $("#tb2>tbody").html("");
            $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/GetWithDrawalHistoryByWhere", "userName:'" + $.trim($("#memberSel").val()) + "',name:'" + $.trim($("#memberName").val()) + "',status:'" + $.trim($("#statusSel").val()) + "',time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "'", true, false, function (json) {
                if (json.d != "]") {
                    var re = jQuery.parseJSON(json.d);
                    var html = "", total1 = 0, total2 = 0;
                    $.each(re, function (i) {
                        total1 += parseFloat(re[i].d);
                        total2 += parseFloat(re[i].sfee);
                        html += "<tr>";
                        html += "<td>" + (i + 1) + "</td>";
                        html += "<td>" + re[i].banknamec + "</td>";
                        html += "<td>" + re[i].banknoc + "</td>";
                        html += "<td>" + re[i].cardnoc + "</td>";
                        html += "<td>" + re[i].b + "</td>";
                        html += "<td>" + re[i].bankcn + "</td>";
                        html += "<td>" + re[i].names + "</td>";
                        html += "<td>" + re[i].cardno + "</td>";
                        html += "<td>" + re[i].k + "</td>";
                        html += "<td>" + re[i].l + "</td>";
                        html += "<td>" + re[i].m + "</td>";
                        html += "<td class='red'>" + re[i].d + "</td>";
                        html += "<td class='red'>" + re[i].sfee + "</td>";
                        html += "<td>" + re[i].h + "</td>";
                        html += "<td>" + re[i].e + "</td>";
                        html += "<td>" + re[i].f + "</td>";
                        html += "<td>" + (re[i].g == "1" ? "未审核" : (re[i].g == "2" ? "成功" : "拒绝")) + "</td>";

                        //                        html += "<td><a href='javascript:void(0)' style='color:#0075a9' onclick=\"window.open('/User/UserInfo.aspx?u=" + re[i].b + "','','width=600,height=270');\">" + re[i].b + "</a></td>";
                        //                        html += "<td>" + re[i].r + "</td><td>" + re[i].n + "</td>";
                        //                        html += "<td class='red'>" + re[i].d + "</td>";
                        //                        html += "<td>" + re[i].e + "</td>";
                        //                        html += "<td>" + re[i].f + "</td>";
                        //                        html += "<td>" + (re[i].g == "1" ? "未审核" : (re[i].g == "2" ? "成功" : "拒绝")) + "</td>";
                        //                        html += "<td>" + re[i].h + "</td>";
                        //                        html += "<td a='" + re[i].s + "' b='" + re[i].j + "' c='" + re[i].k + "' d='" + re[i].l + "' e='" + re[i].m + "'>" + re[i].i + "</td>";
                        html += "</tr>";
                    });
                    html += "<tr><td>总计</td><td colspan='10'></td><td class='red'>" + total1.toFixed(2) + "</td><td class='red'>" + total2.toFixed(2) + "</td><td colspan='6'></td></tr>";
                    $("#tb2>tbody").html(html);
                    $("#tb2>tbody>tr").mouseover(function () {
                        $(this).siblings().removeClass("trOver").end().addClass("trOver");
                    });
                    $("#tb2>tbody>tr>td[a]").unbind("click").bind("click", function () {
                        $("#lUserName").html($(this).attr("a"));
                        $("#lCardNo").html($(this).html());
                        $("#lType").html(bankArr[$(this).attr("b")]);
                        $("#lProvince").html($(this).attr("c"));
                        $("#lCity").html($(this).attr("d").toString().replace("@", ""));
                        $("#lBranch").html($(this).attr("e"));
                        $("#bankInfo").dialog({ modal: true, resizable: false });
                        $("#okBtn").unbind("click").bind("click", function () {
                            $("#bankInfo").dialog("close");
                        });
                    });
                    $(".cancel").unbind("click").bind("click", function () {
                        getReson();
                        var id = $(this).attr("attr");
                        $("#cancelWithDrawal").dialog({ modal: true, width: "330px" });
                        $("#submitBtn").unbind("click").bind("click", function () {
                            $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/CancelBNH", "id:'" + id + "',type:'2',reason:'" + $("#reason").val() + "'", true, false, function (json) {
                                if (json.d) {
                                    alert("撤消成功");
                                    $("#cancelWithDrawal").dialog("close");
                                    SelectByWhere();
                                } else {
                                    alert("发生意外，撤消失败");
                                }
                            });
                        });
                        $("#cancelBtn").unbind("click").bind("click", function () {
                            $("#cancelWithDrawal").dialog("close");
                        });
                    });
                } else {
                    $("#tb2>tbody").html("<tr><td colspan=\"11\">没有相应数据</td></tr>");
                }
            });
        }

        function GetBankArr() {
            $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/GetBankInfoAll", "lan:'" + lan + "'", true, false, function (json) {
                if (json.d != "") {
                    var r = jQuery.parseJSON(json.d);
                    $.each(r, function (i) {
                        bankArr[r[i].a] = r[i].b;
                    });
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
<th width="*" class="tab_top_m"><p id="zdjs">提款历史记录</p></th>
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
    <div  style="width:95%;padding:3px;margin:2px;"><span id="VerifyWithDrawal" class="btn_04"  style=" font-size:11px">&nbsp;&nbsp;未审核取款&nbsp;&nbsp;</span>&nbsp;<span id="withdrawalHistory" class="btn_04" style=" color:Yellow; font-size:13px; font-weight:600">&nbsp;&nbsp;已审核提款&nbsp;&nbsp;</span>&nbsp;&nbsp;
    <a id="hyzh">会员帐号</a>&nbsp;&nbsp;<input type="text" id="memberSel" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="hyxm">会员姓名</a>&nbsp;&nbsp;<input type="text" id="memberName" class="inputWhere text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="jysj">提交时间</a>&nbsp;&nbsp;<input type="text" id="time1WhereVal" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" readonly="readonly"  />－<input type="text" id="time2WhereVal" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" readonly="readonly"  />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="zt">状态</a>&nbsp;&nbsp;<select id="statusSel"><option value="1">全部</option>
        <option value="2" selected>成功</option><option value="3">拒绝</option>
    </select>&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in">搜索</span></a>
    </div>
    <table class="tab2" id="tb2" width="1500px" border="0" cellpadding="0" cellspacing="0">
    <thead>
                <tr>
             <th>序号</th>
                <th>银行</th>
                <th>账户</th>
                <th>银行卡号</th>
                <th>会员号</th>
                <th>银行（会员）</th>
                <th>账户（会员）</th>
                <th>卡号（会员）</th>
                <th>省</th>
                <th>市</th>
                <th>分行</th>
                <th>金额</th>
                <th>手续费</th>
                <th>备注</th>
                <th>提交时间</th>
                <th>处理时间</th>
                <th>状态</th>
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
<div id="bankInfo" title="银行卡信息">
<div class="showdiv">
<ul>
<li><p><span id="bUserName">户名</span>：</p><p><label id="lUserName"></label></p></li>
<li><p><span id="bCardNo">银行卡号</span>：</p><p><label id="lCardNo"></label></p></li>
<li><p><span id="bType">银行类型</span>：</p><p><label id="lType"></label></p></li>
<li><p><span id="bProvince">银行所在省</span>：</p><p><label id="lProvince"></label></p></li>
<li><p><span id="bCity">银行所在市</span>：</p><p><label id="lCity"></label></p></li>
<li><p><span id="bBranch">银行所在分行</span>：</p><p><label id="lBranch"></label></p></li>
<li><div align="center" class="mtop_30"><br />
    <input type="button" id="okBtn" class="btn_02" value="关闭" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></div></li>
</ul>
</div></div>
<div id="cancelWithDrawal" title="撤消提款">
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
