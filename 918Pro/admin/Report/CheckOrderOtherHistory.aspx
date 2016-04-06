<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckOrderOtherHistory.aspx.cs" validateRequest="false" Inherits="admin.Report.CheckOrderOtherHistory" %>

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
    <script type="text/javascript">
        var flag = false;
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

        function SelectByWhere() {
            $.ajax({
                contentType: "application/json",
                type: "POST",
                dataType: "json",
                async: true,
                url: "/ServicesFile/webBasicInfo/AccountService.asmx/checkOrderOther",
                data: "{casino:'" + $("#casino").val() + "',time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "'}",
                beforeSend: function () {
                    $("#showInfo").html("<tr><td colspan=\"12\">核对中...请稍候！</td></tr>");
                    $("#selectByWhere").attr("disabled","disabled");
                },
                success: function (json) {
                    if (json.d != "") {
                        var result = jQuery.parseJSON(json.d);
                        var html = "";
                        $.each(result, function (i) {
                            html += "<tr align='center'><td>" + result[i].ID + "</td><td>" + result[i].Time + "</td><td>" + result[i].UserName + "<br/>" + result[i].OrderID + "</td><td>" + result[i].WebUserName + "<br/>" + result[i].WebOrderID + "</td><td>" + result[i].League + "<br/>" + result[i].BeginTime + "</td><td>" + result[i].Home + "-VS-" + result[i].Away + "</td><td>" + result[i].BetType + "</td><td>" + result[i].Handicap + "@" + result[i].BetItem + "</td><td>" + result[i].Odds + "</td><td>" + result[i].Amount + "<br/>" + result[i].ValidAmount + "</td><td>" + result[i].Status + "<br/>" + result[i].WebSiteID + "</td><td><a href=\"javascript:void(0)\" onmouseover=\"showDetails(this)\" onmouseout=\"hideDetails()\" class=\"errorMeg\" c=\"" + result[i].ErrorMessage + "\" >" + getLeftString(result[i].ErrorMessage.toString()) + "</a></td></tr>";
                        });
                        $("#showInfo").html(html);
                    } else {
                        $("#showInfo").html("<tr><td colspan=\"12\">核对成功</td></tr>");
                    }
                    flag = false;
                    $("#selectByWhere").attr("disabled", "");
                }
            });
        }

//        function CheckOrder() {
//            if (jQuery.trim($("#time1WhereVal").val()) != "" || jQuery.trim($("#time2WhereVal").val()) != "") {
//                $("#showInfo").html("<tr><td colspan=\"12\">Checking...</td></tr>");
//                document.getElementById("btnCheck2").click();
//            } else {
//                alert("请选择时间");
//            }
//        }

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
    <table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="nameP">核对投注历史</p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<input type="hidden" id="language" value="tw"/>
    <form id="form1" runat="server">
    <div class="top_banner h30">

    <div id="selectDiv" style="width:90%" >
        &nbsp;&nbsp;&nbsp;
    <span id="H1056">時間</span>:
    <input type="text" id="time1WhereVal" class="text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" readonly="readonly"  />－<input type="text" id="time2WhereVal" class="text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" readonly="readonly"  />&nbsp;&nbsp;
    <select id="casino"> </select>&nbsp;&nbsp;
    <button id="selectByWhere" class="btn_01_h">核 对</button>&nbsp;&nbsp;
    <asp:LinkButton runat="server" ID="excel" OnClientClick="return setExcel('divExcel','hfContent')" onclick="excel_Click" Text="导出Excel" />
    </div>
    </div>
<!-- 数据显示TABLE -->
<input type="hidden" runat="server" id="hfContent"/>
<input type="hidden" runat="server" id="nameValue" />
<div id="divExcel">
    <table width="100%" class="tab2">
    <thead>
    <tr align="center">
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
    <td>网站</td>
    <td>描述</td>
    </tr>
    </thead>
    <tbody id="showInfo">
    
    </tbody>
    <tfoot>
    <tr id="">
    </tr>
    <tr id="info"></tr>
    </tfoot>
    </table>
    </div>
    </form>
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
    <div class=" h30">请选择时间！</div>
<div align="center" class="mtop_50">
<input type="button" class="btn_02" id="closeButton" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="关闭" />
</div>
</div>
    </div>
</body>
</html>
