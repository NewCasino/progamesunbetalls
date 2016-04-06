<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FanshuiHistory.aspx.cs" Inherits="admin.Bank.FanshuiHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>已审核返水</title>
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
        function CurentTime1() {
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
            jQuery("#time1WhereVal").datepicker();
            $('#time1WhereVal').val(CurentTime1());
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
                    SelectByWhere();
                    $(this).blur();
                }
            });
            $("#depositHistory").click(function () {
                location = "/Bank/FanshuiHistory.aspx";
            });
            $("#VerifyDeposit").click(function () {
                location = "/Bank/Fanshui.aspx";
            });
        });
        function SelectByWhere() {
            $("#tb2>tbody").html("");
            $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/GetHistoryByWhere", "userName:'" + $.trim($("#memberSel").val()) + "',lan:'" + lan + "',name:'" + $.trim($("#memberName").val()) + "',status:'" + $.trim($("#statusSel").val()) + "',time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',type:'" + $("#fstype").val() + "',mark:'" + $("#txtmark").val() + "'", true, false, function (json) {
                if (json.d != "]") {
                    var re = jQuery.parseJSON(json.d);
                    var html = "", total1 = 0, total2 = 0;
                    $.each(re, function (i) {
                        total1 += parseFloat(re[i].d);
                        total2 += parseFloat(re[i].z == "" ? 0 : re[i].z);
                        //html += "<tr><td>" + (i + 1) + "</td><td><a href='javascript:void(0)' style='color:#0075a9' onclick=\"window.open('/User/UserInfo.aspx?u=" + re[i].b + "','','width=600,height=270');\">" + re[i].b + "</a></td><td>" + re[i].l + "</td><td style='color:red'>" + re[i].d + "</td><td>" + re[i].o + "</td><td>" + re[i].p + "</td><td>" + re[i].e + "</td><td>" + re[i].f + "</td><td>" + (re[i].g == "1" ? "未审核" : (re[i].g == "2" ? "成功" : "拒绝")) + "</td><td>" + re[i].h + "</td>";//存入帐号<td>" + re[i].q + "</td>   mm
                        html += "<tr><td>" + (i + 1) + "</td><td><a href='javascript:void(0)' style='color:#0075a9' onclick=\"window.open('/User/UserInfo.aspx?u=" + re[i].b + "','','width=600,height=270');\">" + re[i].b + "</a></td><td>" + re[i].z + "</td><td>" + re[i].vv + "</td><td class='red'>" + re[i].d + "</td><td>" + re[i].n + "</td><td>" + re[i].r + "</td><td>" + re[i].e + "</td><td>" + re[i].f + "</td><td>" + (re[i].c == "4" ? "太阳城游戏返水" : "太阳城游戏返水") + "</td><td>" + (re[i].g == "1" ? "未审核" : (re[i].g == "2" ? "成功" : "拒绝")) + "</td><td>" + re[i].mm + "</td><td>" + re[i].h + "</td></td></tr>"; //存入帐号<td>" + re[i].j + "</td>
                        html += "</tr>";
                    });
                    html += "<tr><td>总计</td><td colspan='3'></td><td style='color:red'>" + total1.toFixed(2) + "</td><td colspan='9'></td></tr>";
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
<table  id="right_main" border="0" width="110%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="zdjs">已审核返水</p></th>
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
    <span id="VerifyDeposit" class="btn_04">&nbsp;&nbsp;未审核返水&nbsp;&nbsp;</span>
    <span id="depositHistory" class="btn_04">&nbsp;&nbsp;已审核返水&nbsp;&nbsp;</span>&nbsp;
    <a id="hyzh">会员帐号</a><input type="text" id="memberSel" class="inputWhere text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" />&nbsp;
    <a id="hyxm">会员姓名</a><input type="text" id="memberName" class="inputWhere text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" />&nbsp;
    <a>类型</a><select id="fstype"><option value="4">太阳城游戏返水</option><option value="14">太阳城游戏返水</option></select>&nbsp;
    <a id="jysj">提交时间</a><input type="text" id="time1WhereVal" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" readonly="readonly"  />－<input type="text" id="time2WhereVal" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" readonly="readonly"  />&nbsp;
    <a id="A1">活动</a><input type="text" id="txtmark" class="inputWhere text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" /><span style="  font-size:11px; color:Blue"></span>
    <a id="zt">状态</a><select id="statusSel"><option value="1">全部</option>
        <option value="2">成功</option><option value="3">拒绝</option>
    </select>&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="selectByWhere" class="fa_saurch" ><span class="fa_saurch_in">搜索</span></a>
    </div>
    <table class="tab2" id="tb2" width="100%" border="0" cellpadding="0" cellspacing="0">
    <thead>
                <tr>
    <th>序号</th>
    <th>会员帐号</th>
    <th>有效投注额</th>
    <th>计算比率</th>
    <th>返水金额</th>
     <th>有效开始时间</th>
     <th>有效结束时间</th>
     <th>申请时间</th>
     <th>审核时间</th>
     <th>游戏项目</th>
     <th>状态</th>
     <th>备注</th>
     <th>原因</th>
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
