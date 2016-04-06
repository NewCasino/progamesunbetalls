<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnrecognizedWeb.aspx.cs" Inherits="agent.Report.UnrecognizedWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>走地未确认</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="/js/jQueryCommon.js" type="text/javascript"></script>
    <script type="text/javascript">
        var idList;
        var typeList;
        var info="";
        jQuery(function () {
            jQuery("#infoDiv").hide();
            jQuery("#oneInfoDiv").hide();
            idList = new Array();
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
            var data = "length:'50'";
            setData(data);
            Countdown(jQuery("#timeTxt").val());
            jQuery("#sureAll").click(function () {
                if (jQuery("#showInfo").find(":checkbox:checked").length == 0) {
                    jQuery("#labl").text("请选择注单之后再确认");
                    return false;
                }
                jQuery("#labl").text("");
                var id = "";
                var typeInfo = "";
                var j = 0;
                jQuery.each(jQuery("#showInfo").find(":checkbox:checked"), function (i) {
                    if (jQuery.inArray(jQuery("#showInfo").find(":checkbox:checked:eq(" + (i - j) + ")").attr("id").substr(1), idList) != -1) {

                        if (id != "") {
                            id += ";";
                            typeInfo += ";";
                        }
                        id += "" + idList[j];
                        typeInfo += "" + jQuery("#showInfo").find(":checkbox:checked:eq(" + (i - j) + ")").parent().parent().find(":checkbox").val();
                        j++;
                        (jQuery("#showInfo").find(":checkbox:eq(" + (i - j) + ")").parent().parent()).remove();
                    }
                });
                data = "id:'" + id + "',type:'1',info:'',typeInfo:'" + typeInfo + "'";
                jQuery.AjaxCommon("/ServicesFile/ReportService/UnrecognizedService.asmx/setUpData", data, false, false, function (json) { });
                idList = new Array();
            });
            jQuery("#escAll").click(function () {
                if (jQuery("#showInfo").find(":checkbox:checked").length == 0) {
                    jQuery("#labl").text("请选择注单之后再取消");
                    return false;
                }
                jQuery("#labl").text("");
                jQuery("#infoDiv").dialog({ modal: true });
            });
        });

        function setData(data) {
            jQuery.AjaxCommon("/ServicesFile/ReportService/UnrecognizedService.asmx/getAllToLength", data, true, false, function (json) {
                if (json.d != "none") {
                    jQuery("#showInfo>tr").remove();
                    var result = jQuery.parseJSON(json.d);
                    jQuery.each(result, function (i) {
                        var tr = jQuery("#tr1").clone();
                        tr.find("#check").html("<input type=\"checkbox\" value=\"" + typeList[parseInt(result[i].BetType)] + "\" id=\"A" + result[i].ID + "\"" + (jQuery.inArray(result[i].ID, idList) != -1 ? "checked" : "") + " />");
                        tr.find("#time").html(result[i].UserName + "<br/>" + result[i].OrderID + "<br/>" + result[i].time);
                        if (jQuery("#language").val() == "tw") {
                            tr.find("#league").html(result[i].leaguetw + "<br/>" + result[i].Hometw + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awaytw + "<br/>" + result[i].Score);
                        }
                        else if (jQuery("#language").val() == "cn") {
                            tr.find("#league").html(result[i].leaguecn + "<br/>" + result[i].Homecn + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awaycn + "<br/>" + result[i].Score);
                        }
                        else if (jQuery("#language").val() == "en") {
                            tr.find("#league").html(result[i].leagueen + "<br/>" + result[i].Homeen + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awayen + "<br/>" + result[i].Score);
                        }
                        else if (jQuery("#language").val() == "th") {
                            tr.find("#league").html(result[i].leagueth + "<br/>" + result[i].Hometh + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awayth + "<br/>" + result[i].Score);
                        }
                        else if (jQuery("#language").val() == "vn") {
                            tr.find("#league").html(result[i].leaguevn + "<br/>" + result[i].Homevn + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awayvn + "<br/>" + result[i].Score);
                        }
                        tr.find("#BetType").html(typeList[parseInt(result[i].BetType)] + "&nbsp;&nbsp;&nbsp;&nbsp;" + (result[i].IsHalf == 1 ? "全场" : "半场") + "<br/>" + result[i].BetItem);
                        tr.find("#Handicap").html(result[i].Handicap + "<br/>" + result[i].Odds + "<br/>" + result[i].OddsType);
                        tr.find("#ValidAmount").html(result[i].Amount + "<br/>" + result[i].ValidAmount);
                        $.AjaxCommon("/ServicesFile/webBasicInfo/WebInfoService.asmx/GetDate", "", true, false, function (json1) {
                            if (json1.d != "none") {
                                var result1 = jQuery.parseJSON(json1.d);
                                $.each(result1, function (j) {
                                    if (result1[j].id == result[i].WebSiteiID) {
                                        if (jQuery("#language").val() == "tw") {
                                            tr.find("#WebSiteiID").html(result1[j].nametw + "<br>" + result[i].IP);
                                        }
                                        else if (jQuery("#language").val() == "cn") {
                                            tr.find("#WebSiteiID").html(result1[j].namecn + "<br>" + result[i].IP);
                                        }
                                        else if (jQuery("#language").val() == "en") {
                                            tr.find("#WebSiteiID").html(result1[j].nameen + "<br>" + result[i].IP);
                                        }
                                        else if (jQuery("#language").val() == "th") {
                                            tr.find("#WebSiteiID").html(result1[j].nameth + "<br>" + result[i].IP);
                                        }
                                        else if (jQuery("#language").val() == "vn") {
                                            tr.find("#WebSiteiID").html(result1[j].namevn + "<br>" + result[i].IP);
                                        }
                                    }
                                });
                            }
                        });
                        tr.find("#opCa").html("<a onclick=\"sureOne(this)\">确认</a>&nbsp;&nbsp;&nbsp;&nbsp;<a onclick=\"escOne(this)\">取消</a>");
                        tr.appendTo("#showInfo");
                    });
                    jQuery("#checkAll1").unbind("click");
                    jQuery("#checkAll1").click(function () {
                        jQuery("#showInfo").find(":checkbox").attr("checked", jQuery("#checkAll1").attr("checked"));
                        idList = null;
                        idList = new Array();
                        if (jQuery("#checkAll1").attr("checked")) {
                            jQuery.each(jQuery("#showInfo>tr"), function (i) {
                                idList.push(jQuery("#showInfo>tr:eq(" + i + ")>td:eq(0) :checkbox").attr("id").substr(1));
                            });
                        }
                    });
                    jQuery("#showInfo>tr").find("td:eq(0)").find(":checkbox").click(function () {
                        if (jQuery(this).attr("checked") == true) {
                            idList.push(jQuery(this).attr("id").substr(1));
                            if (jQuery("#showInfo").find(":checkbox:checked").length == jQuery("#showInfo").find(":checkbox").length) {
                                jQuery("#checkAll1").attr("checked", "checked");
                            }
                        }
                        else {
                            idList.splice(jQuery.inArray(jQuery(this).attr("id").substr(1), idList), 1);
                            jQuery("#checkAll1").removeAttr("checked");
                        }
                    });
                    idList = new Array();
                    jQuery.each(jQuery("#showInfo").find(":checkbox"), function (i) {
                        if (jQuery("#showInfo").find(":checkbox:eq(" + i + ")").attr("checked") == true) {
                            idList.push(jQuery("#showInfo").find(":checkbox:eq(" + i + ")").attr("id").substr(1));
                        }
                    });
                }
            });
        };
        var pd = 1;
        function Countdown(time) {
            $("#timeUp").text("" + time);
            if (parseInt(time) == 0) {
                var t = "";
                if ($("#timeHide").val() == "") {
                    $("#timeHide").val("5");
                    time = "5";
                }
                else {
                    var a = /^([1-9]|[1-9][0-9])&/;
                    if (!a.test($("#timeHide").val())) {
                        time = "5";
                        $("#timeHide").val("5");
                    }
                    else {
                        time = $("#timeHide").val();
                    }
                }
                if ($("#DataLength").val() != "") {
                    if (parseInt($("#DataLength").val()) > 200) {
                        alert("注单不能超过两百条");
                        t = "50";
                    }
                    else {
                        t = $("#DataLength").val();
                    }
                }
                else {
                    t = "50";
                }
                var data = "length:'" + t + "'";
                setData(data);
                if ($("#timeHide").val() != $("#timeTxt").val()) {
                    if (parseInt($("#timeTxt").val()) < 5) {
                        alert("刷新时间不能小于5秒");
                        $("#timeTxt").val("" + $("#timeHide").val());
                    }
                    $("#timeHide").val("" + $("#timeTxt").val());
                    pd = 1;
                }
            }
            else {
                time = parseInt(time) - 1;
            }
            
            if (pd) {
                if ($("#timeHide").val() == "") {
                    time = "5";
                }
                else {
                    time = $("#timeHide").val();
                }
                pd = 0;
            }
            setTimeout("Countdown(\"" + time + "\")", 1000);
        };
        function sure() {
            if (jQuery("#escInfo").val() == "") {
                jQuery("#infolbl").text("请输入原因");
                return false;
            }
            jQuery("#infolbl").text("");
            info = jQuery("#escInfo").val();
            jQuery("#escInfo").val("");
            jQuery("#infoDiv").dialog("close");
            var id = "";
            var typeInfo = "";
            var j = 0;
            jQuery.each(jQuery("#showInfo").find(":checkbox:checked"), function (i) {
                if (jQuery.inArray(jQuery("#showInfo").find(":checkbox:checked:eq(" + (i - j) + ")").attr("id").substr(1), idList) != -1) {

                    if (id != "") {
                        id += ";";
                        typeInfo += ";";
                    }
                    id += "" + idList[j];
                    typeInfo += "" + jQuery("#showInfo").find(":checkbox:checked:eq(" + (i - j) + ")").parent().parent().find(":checkbox").val();
                    j++;
                    (jQuery("#showInfo").find(":checkbox:eq(" + (i - j) + ")").parent().parent()).remove();
                }
            });
            var data = "id:'" + id + "',type:'0',info:'" + info + "',typeInfo:'" + typeInfo + "'";
            jQuery.AjaxCommon("/ServicesFile/ReportService/UnrecognizedService.asmx/setUpData", data, false, false, function (json) { });
            idList = new Array();
            jQuery("#escInfo").val("");
            jQuery("#infoDiv").dialog("close");
        };
        function esc() {
            info = "";
            jQuery("#escInfo").val("");
            jQuery("#infoDiv").dialog("close");
        };

        function sureOne(obj) {
            jQuery("#labl").text("");
            var id = jQuery(obj).parent().parent().find(":checkbox").attr("id").substr(1);
            var typeInfo = jQuery(obj).parent().parent().find(":checkbox").val();
            var j = 0;
            var data = "id:'" + id + "',type:'1',info:'',typeInfo:'" + typeInfo + "'";
            jQuery.AjaxCommon("/ServicesFile/ReportService/UnrecognizedService.asmx/setUpData", data, false, false, function (json) { });
            idList = new Array();
            jQuery(obj).parent().parent().remove();
        };
        var id1 = "";
        var typeInfo1 = "";
        function escOne(obj) {
            jQuery("#labl").text("");
            id1 = jQuery(obj).parent().parent().find(":checkbox").attr("id").substr(1);
            typeInfo1 = jQuery(obj).parent().parent().find(":checkbox").val();
            jQuery("#oneInfoDiv").dialog({ modal: true });
            jQuery("#Button1").unbind("click");
            jQuery("#Button1").click(function () {
                if (jQuery("#oneEscInfo").val() == "") {
                    jQuery("#oneInfolbl").text("请输入原因");
                    return false;
                }
                jQuery("#oneInfolbl").text("");
                var j = 0;
                var data = "id:'" + id1 + "',type:'0',info:'" + jQuery("#oneEscInfo").val() + "',typeInfo:'" + typeInfo1 + "'";
                jQuery.AjaxCommon("/ServicesFile/ReportService/UnrecognizedService.asmx/setUpData", data, false, false, function (json) { });
                idList = new Array();
                jQuery("#oneEscInfo").val("");
                jQuery("#oneInfoDiv").dialog("close");
                jQuery(obj).parent().parent().remove();
            });
        };

        function oneEsc(obj) {
            info = "";
            jQuery("#oneEscInfo").val("");
            jQuery("#oneInfoDiv").dialog("close");
        };
    </script>
</head>
<body>
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p>走地未确认</p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<!--主题部分开始=========================================================================================-->
<input type="hidden" value="" id="timeHide" />
<input type="hidden" id="language" value="tw" />
    <form id="form1" runat="server">
    <div class="top_banner h30">
<div class="fl">
</div>
<div class="fr"><input type="text" id="timeTxt" value="5" class="text_01 w_30" onmouseover="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" /><label id="timeUp">5</label>&nbsp;&nbsp;&nbsp;&nbsp;
    <input type="text" value="50" id="DataLength" class="text_01 w_60" onmouseover="this.className='text_01_h w_60'" onmouseout="this.className='text_01 w_60'" />条&nbsp;&nbsp;&nbsp;&nbsp;
    <% if (qrAc)
       { %>
    <input type="button" value="确认" id="sureAll" />&nbsp;&nbsp;&nbsp;&nbsp;
    <% } %>
    <% if (qxAc)
       { %>
    <input type="button" id="escAll" value="取消" />&nbsp;&nbsp;&nbsp;&nbsp;
    <% } %>
    <label id="labl" style="color:Red"></label>
</div>

</div>
    <table width="100%" class="tab2" id="tab3">
    <thead>
    <tr>
    <th><input type="checkbox" id="checkAll1" value="checkAll" />全选/取消</th>
    <th>下注</th>
    <th>比赛</th>
    <th>投注类型</th>
    <th>赔率</th>
    <th>投注金额</th>
    <th>公司金额</th>
    <th>网站</th>
    <th>操作</th>
    </tr>
    </thead>
    <tbody id="showInfo" class="tc">
    
    </tbody>
    <tfoot>
    <tr id="tr1">
    <td id="check"></td>
    <td id="time"></td>
    <td id="league"></td>
    <td id="BetType"></td>
    <td id="Handicap"></td>
    <td id="ValidAmount"></td>
    <td id="Company"></td>
    <td id="WebSiteiID"></td>
    <td id="opCa"></td>
    </tr>
    </tfoot>
    </table>
    </form>

    <div id="infoDiv" title="取消原因" >
<div class="showdiv tc">
<table>
<tr>
<td>取消原因:</td><td><textarea id="escInfo" cols="20" rows="10"  class="text_01" onmouseover="this.className='text_01_h'" onmouseout="this.className='text_01'" ></textarea></td>
</tr>
</table><br />
<label id="infolbl" style="color:Red"></label>
<div align="center" class="mtop_50">
<input type="button" class="btn_02" id="btnSure" onclick="sure()" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="确定" />
<input type="button" class="btn_02" id="btnEsc" onclick="esc()" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="取消" />
</div>

</div>
</div>

<div id="oneInfoDiv" title="取消原因" >
<div class="showdiv tc">
<table>
<tr>
<td>取消原因:</td><td><textarea id="oneEscInfo" cols="20" rows="10"  class="text_01" onmouseover="this.className='text_01_h'" onmouseout="this.className='text_01'" ></textarea></td>
</tr>
</table><br />
<label id="oneInfolbl" style="color:Red"></label>
<div align="center" class="mtop_50">
<input type="button" class="btn_02" id="Button1" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="确定" />
<input type="button" class="btn_02" id="Button2" onclick="oneEsc()" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="取消" />
</div>

</div>
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
