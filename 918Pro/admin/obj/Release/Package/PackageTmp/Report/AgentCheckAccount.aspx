<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="AgentCheckAccount.aspx.cs" Inherits="admin.Report.AgentCheckAccount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="/js/jQueryCommon.js" type="text/javascript"></script>
    <script src="/js/webBasicInfo/zh-CN.js" type="text/javascript"></script>
    <style type="text/css">
    body:{ background-color:White;}
    </style>
    <script type="text/javascript">
        var flag = false;
        var typeList;
        var web;
        typeList = new Array();
        typeList[0] = "单式全场让球";
        typeList[1] = "单式全场大小";
        typeList[2] = "单式半场让球";
        typeList[3] = "单式半场大小";
        typeList[4] = "走地全场让球";
        typeList[5] = "走地全场大小";
        typeList[6] = "走地半场让球";
        typeList[7] = "走地半场大小";
        typeList[8] = "早餐全场让球";
        typeList[9] = "早餐全场大小";
        typeList[10] = "早餐半场让球";
        typeList[11] = "早餐半场大小";
        typeList[12] = "单式全场标准";
        typeList[13] = "单式半场标准";
        typeList[14] = "走地全场标准";
        typeList[15] = "走地半场标准";
        typeList[16] = "早餐全场标准";
        typeList[17] = "早餐半场标准";
        jQuery(function ($) {
            $("#time1WhereVal,#time2WhereVal").datepicker();
            GetCasino();
            $("#selectByWhere").click(function () {
                if (jQuery.trim($("#time1WhereVal").val()) != "" || jQuery.trim($("#time2WhereVal").val()) != "") {
                    var html = jQuery.trim($("#showInfo").html());
                    if (html != "" && html.indexOf("核对成功") == -1 && !flag) {
                        flag = true;
                        if (confirm("重新核对之前，是否将该报表导出到excel？")) {
                            document.getElementById("excel").click();
                        } else {
                            SelectByWhere();
                        }
                    } else {
                        SelectByWhere();
                    }
                } else {
                    $("#warnDiv").dialog({ model: true });
                }
            });
            $("#closeButton").click(function () {
                $("#warnDiv").dialog("close");
            });
        });

        function GetCasino() {
            $.AjaxCommon("/ServicesFile/webBasicInfo/WebInfoService.asmx/GetDate", "", true, false, function (json) {
                web = new Array();
                if (json.d != "none") {
                    $("#casino").html("");
                    var result = jQuery.parseJSON(json.d);
                    var a = "";
                    $.each(result, function (i) {
                        web[result[i].id] = result[i].nametw;
                        a += "<option value=\"" + result[i].id + "\">" + result[i].nametw + "</option>";
                    });
                    $("#casino").html(a);
                }
            });
        }

        function GetDetailByAccount(accountUserName) {
            $.ajax({
                contentType: "application/json",
                type: "POST",
                dataType: "json",
                async: true,
                url: "/ServicesFile/webBasicInfo/AccountService.asmx/GetErrorDetailOrder",
                data: "{accountUserName:'" + accountUserName + "'}",
                beforeSend: function () {
                    $("#showDetail").html("<tr><td colspan=\"12\">查询中...请稍候！</td></tr>");
                },
                success: function (json) {
                    if (json.d != "") {
                        var result = jQuery.parseJSON(json.d);
                        var detailHtml = "";
                        var total1 = 0, total2 = 0;
                        $.each(result, function (i) {
                            total1 += parseFloat(result[i].Amount);
                            total2 += parseFloat(result[i].Result);
                            detailHtml += "<tr align='center'><td>" + result[i].ID + "</td><td>" + result[i].Time + "</td><td>" + result[i].UserName + "<br/>" + result[i].OrderID + "</td><td>" + result[i].WebUserName + "<br/>" + result[i].WebOrderID + "</td><td>" + result[i].League + "<br/>" + result[i].BeginTime + "</td><td>" + result[i].Home + "-VS-" + result[i].Away + "</td><td>" + (result[i].BetType == "" ? "--" : typeList[parseInt(result[i].BetType)]) + "</td><td>" + result[i].Handicap + "@" + result[i].BetItem + "</td><td>" + result[i].Odds + "</td><td>" + result[i].Amount + "</td><td>" + result[i].Score + "</td><td>" + result[i].Result + "</td><td><a href=\"javascript:void(0)\" onmouseover=\"showDetails(this)\" onmouseout=\"hideDetails()\" class=\"errorMeg\" c=\"" + result[i].ErrorMessage + "\" >" + getLeftString(result[i].ErrorMessage.toString()) + "</a></td></tr>";
                        });
                        detailHtml += "<tr align='center'><td>总计</td><td colspan=\"8\"></td><td>" + total1.toFixed(2) + "</td><td></td><td>" + total2.toFixed(2) + "</td><td></td></tr>";
                        $("#showDetail").html(detailHtml);
                        $("#showDetail>tr").hover(function () {
                            $(this).addClass("trOver");
                        }, function () {
                            $(this).removeClass("trOver");
                        });
                    } else {
                        $("#showDetail").html("<tr><td colspan=\"12\">核对失败</td></tr>");
                    }
                    $("#back").unbind("click").bind("click", function () {
                        $("#tab1").show();
                        $("#tab2").hide();
                        $("#backBtn").hide();
                    });
                    flag = false;
                }
            });
        }

        function SelectByWhere() {
            $.ajax({
                contentType: "application/json",
                type: "POST",
                dataType: "json",
                async: true,
                url: "/ServicesFile/webBasicInfo/AccountService.asmx/checkHistory",
                data: "{casino:'" + $("#casino").val() + "',startDate:'" + $("#time1WhereVal").val() + "',endDate:'" + $("#time2WhereVal").val() + "'}",
                beforeSend: function () {
                    $("#showInfo").html("<tr><td colspan=\"12\">核对中...请稍候！</td></tr>");
                    $("#selectByWhere").attr("disabled", "disabled");
                },
                success: function (json) {
                    if (json.d != "") {
                        var result = jQuery.parseJSON(json.d);
                        var html = "";
                        var total1 = 0, total2 = 0, total3 = 0, total4 = 0, total5 = 0, total6 = 0;
                        $.each(result, function (i) {
                            total1 += parseFloat(result[i].OwnerOrderCount);
                            total2 += parseFloat(result[i].WebsiteOrderCount);
                            total3 += parseFloat(result[i].OwnerTotalBetMoney);
                            total4 += parseFloat(result[i].WebsiteTotalBetMoney);
                            total5 += parseFloat(result[i].OwnerResultMoney);
                            total6 += parseFloat(result[i].WebsiteResultMoney);
                            var temp = result[i].IsErrorData == 0 ? result[i].WebUserName : "<a attr=\"" + result[i].WebUserName + "\" class=\"webUN\" style=\"text-decoration:underline;color:Red;\">" + result[i].WebUserName + "</a>";
                            var errorDataTemp = result[i].IsErrorData == 0 ? "否" : "是";
                            html += "<tr align='center'><td>" + result[i].ID + "</td><td>" + result[i].WebAgentName + "</td><td>" + temp + "</td><td>" + result[i].OwnerOrderCount + "</td><td>" + result[i].WebsiteOrderCount + "</td><td>" + result[i].OwnerTotalBetMoney + "</td><td>" + result[i].WebsiteTotalBetMoney + "</td><td>" + result[i].OwnerResultMoney + "</td><td>" + result[i].WebsiteResultMoney + "</td><td>" + errorDataTemp + "</td></tr>";
                        });
                        html += "<tr align='center'><td>总计</td><td></td><td></td><td>" + total1 + "</td><td>" + total2 + "</td><td>" + total3.toFixed(2) + "</td><td>" + total4.toFixed(2) + "</td><td>" + total5.toFixed(2) + "</td><td>" + total6.toFixed(2) + "</td><td></td></tr>";
                        $("#showInfo").html(html);
                        $("#showInfo>tr").hover(function () {
                            $(this).addClass("trOver");
                        }, function () {
                            $(this).removeClass("trOver");
                        });
                        $(".webUN").unbind("click").bind("click", function () {
                            $("#tab1").hide();
                            $("#tab2").show();
                            $("#backBtn").show();
                            GetDetailByAccount($(this).attr("attr"));
                        });
                    } else {
                        $("#showInfo").html("<tr><td colspan=\"12\">核对失败</td></tr>");
                    }
                    flag = false;
                    $("#selectByWhere").attr("disabled", "");
                }
            });
        }

        function hideDetails() {
            $("#divTip").hide();
        }

        function showDetails(thisObj) {
            var d = $(thisObj);
            var pos = d.offset();
            var t = pos.top + d.height() + 5;
            t = t > ($(window).height() - 35) ? t - 68 : t;
            var l = pos.left + d.width() - 200;
            $("#divTip").css({ "top": t, "left": l }).show();
            $("#divTip").html(" " + d.attr("c") + " ");
        }

        function getLeftString(s) {
            return s.substring(0, 4) + "......";
        }
        function setExcel(divId, hidenId) {
            jQuery("#" + hidenId).val(jQuery("#" + divId).html());
            jQuery("#nameValue").val("");
            return true;
        }
    </script>
    <style type="text/css">
        .pop{
        width: 200px;
        height:auto;
        border: 1px solid #06f;
        background-color:#fffeee;
        display: none;
        position:absolute;  
        padding:2px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="nameP">代理对帐</p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<input type="hidden" id="language" value="tw"/>
<%if (selectAc || excelAc)
  { %>
<div class="top_banner h30">
<%if (selectAc)
  { %>
    <div id="selectDiv" style="width:90%" >
        &nbsp;&nbsp;&nbsp;
    <span id="H1056">時間</span>:
    <input type="text" id="time1WhereVal" class="text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" readonly="readonly"  />－<input type="text" id="time2WhereVal" class="text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" readonly="readonly"  />&nbsp;&nbsp;
    <select id="casino"> </select>&nbsp;&nbsp;
    <span><button id="selectByWhere" class="btn_01_h">核 对</button></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span id="backBtn" class="undis"><button id="back" class="btn_01_h">返 回</button></span>&nbsp;&nbsp;&nbsp;&nbsp;
<input type="hidden" runat="server" id="hfContent"/>
<input type="hidden" runat="server" id="nameValue" />
<%} %>
<%if (excelAc)
  { %>
<asp:LinkButton runat="server" ID="excel"  OnClientClick="return setExcel('divExcel','hfContent')" Text="导出Excel" onclick="excel_Click" />
<%} %>
</div>
    </div><%} %>
<!-- 数据显示TABLE -->
<div id="divExcel">
<div id="tab1">
    <table width="100%" class="tab2">
    <thead id="divHeader">
    <tr align="center" style="background-color:#CDEAFC">
    <td>序号</td>
    <td>代理</td>
    <td>账号</td>
    <td>网站注单数量</td>
    <td>代理注单数量</td>
    <td>网站注额</td>
    <td>代理注额</td>
    <td>网站会员输赢结果</td>
    <td>代理会员输赢结果</td>
    <td>是否有错误数据</td>
    </tr>
    </thead>
    <tbody id="showInfo">
    
    </tbody>
    <tfoot>
    </tfoot>
    </table></div>
    <div id="tab2" style="display:none;">
     <table width="100%" class="tab2">
    <thead id="divHeaderDetail">
    <tr align="center" style="background-color:#CDEAFC">
    <td>序号</td>
    <td>下注时间</td>
    <td>账号</td>
    <td>投注账号</td>
    <td>联赛</td>
    <td>队伍</td>
    <td>投注类型</td>
    <td>盘口</td>
    <td>赔率</td>
    <td>投注金额</td>
    <td>比分</td>
    <td>输赢金额</td>
    <td>描述</td>
    </tr>
    </thead>
    <tbody id="showDetail">
    
    </tbody>
    <tfoot>
    </tfoot>
    </table>
    </div>
    </div>
</div>
</td>
<td class="tab_middle_r"></td>
</tr>
</tbody>
</table>
<div id="loading"></div>
<div id="divTip" class="pop"></div>
 <div id="warnDiv" title="消息提示" style="display:none;">
    <div id="reportDiv" class="showdiv">
    <div class=" h30">请输入时间！</div>
<div align="center" class="mtop_50">
<input type="button" class="btn_02" id="closeButton" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="关闭" />
</div>
</div>
    </div>
    </form>
</body>
</html>
