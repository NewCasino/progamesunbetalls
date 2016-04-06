<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="ReleaseSiteWeb.aspx.cs" Inherits="admin.ReleaseSite.ReleaseSiteWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery.ui.datepicker.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="/js/jQueryCommon.js" type="text/javascript"></script>
    <script src="/js/webBasicInfo/zh-CN.js" type="text/javascript"></script>
    <script src="/js/ColorDialog-min.js" type="text/javascript"></script>
    <script src="/js/page/pageJs.js" type="text/javascript"></script>
    <script type="text/javascript">
     jQuery(function () {
            SetGlobal("");
        });

        var languages = "";
        var lang;
        function SetGlobal(setLang) {

            setLang = $.SetOrGetLanguage(setLang, function () {
                languages = language;
                
                $(".H1320").html(languages.H1320);
                $("#updatebutton").val(languages.H1009);
                $("#escbutton").val(languages.H1011); 
               $(".H1110").html(languages.H1110);
               $(".H1109").html(languages.H1109);
               $(".H1140").html(languages.H1140);
               $(".H1141").html(languages.H1141);
               $(".H1108").html(languages.H1108);
               $(".H1107").html(languages.H1107);
               $(".H1448").html(languages.H1448);
               $(".H1138").html(languages.H1138);
               $(".H1009").html(languages.H1009);
               $(".H1118").html(languages.H1118);
               $(".H1056").html(languages.H1056);
               $(".H1130").html(languages.H1130);
               $(".H1131").html(languages.H1131);
               $(".H1132").html(languages.H1132);
               $(".H1105").html(languages.H1105);
               $(".H1133").html(languages.H1133);
               $(".H1134").html(languages.H1134);
               $(".H1135").html(languages.H1135);
               $(".H1136").html(languages.H1136);
               $(".H1022").html(languages.H1022);
               $("#H1022").text(languages.H1022);
               $(".H1137").html(languages.H1137);
               $(".H1028").html(languages.H1028);
               $(".H1029").html(languages.H1029);
               $(".H1030").html(languages.H1030);
               $(".H1031").html(languages.H1031);
               $(".H1032").html(languages.H1032);
               $(".H1033").html(languages.H1033);
               $(".H1034").html(languages.H1034);
               $("#H1015").html(languages.H1015);
               $("#H1111").html(languages.H1111);
               $("#H1112").html(languages.H1112);
               $("#H1113").html(languages.H1113);
               $("#H1114").html(languages.H1114);
               $("#H1115").html(languages.H1115);
               $("#H1116").html(languages.H1116);
               $(".H1117").val(languages.H1117);
               $("#H1118").html(languages.H1118);
               $("#H1119").html(languages.H1119);
               $("#H1120").html(languages.H1120);
               $("#H1121").html(languages.H1121);
               $("#H1122").html(languages.H1122);
               $("#H1123").html(languages.H1123);
               $("#H1124").html(languages.H1124);
               $("#H1125").html(languages.H1125);
               $("#H1126").html(languages.H1126);
               $("#H1127").html(languages.H1127);
               $("#H1128").html(languages.H1128);
               $("#H1129").html(languages.H1129);
               $("#H1024").html(languages.H1024);
               $("#H1139").html(languages.H1139);
               $(".H1117").val(languages.H1117);
               $("#leaguetype option:eq(0)").text(languages.H1106);
               $("#leaguetype option:eq(1)").text(languages.H1105);
               $("#leaguetype option:eq(2)").text(languages.H1104);
               $("#updatebutton").val(languages.H1009);
               $("#escbutton").val(languages.H1011);
               $("#sure").val(languages.H1025);
               $("#esc").val(languages.H1011);
            });
            lang = setLang;
        }

        var data;
        var count1 = 1;
        var number1 = 0;
        var pageNum1 = 20;
        jQuery(function () {
            jQuery("#AddInfoDiv1").hide();
            
            jQuery.AjaxCommon("/ServicesFile/ReleaseSite/ReleaseSiteService.asmx/GetCount", "", true, false, function (json) {
                // alert(json.d);
                if (json.d != "none") {

                    number1 = parseInt(jQuery.parseJSON(json.d)[0].zs);
                }
            });
            if (number1 % pageNum1 == 0) {
                count1 = parseInt(number1 / pageNum1);
            }
            else {
                count1 = parseInt(number1 / pageNum1) + 1;
            }
            IsPage(count1, number1, pageNum1, "first", "end");
            var colorDialog = new ColorDialog("colorSelect");
            colorDialog.onColorSelected = function () {
                jQuery("#leaguecolor").val("" + colorDialog.selectedColor);
                document.getElementById("leaguecolor").style.backgroundColor = colorDialog.selectedColor;
            }
            colorDialog.create();
            var colorDialog1 = new ColorDialog("colorSelect1");
            colorDialog1.onColorSelected = function () {
                jQuery("#color1").val("" + colorDialog1.selectedColor);
                document.getElementById("color1").style.backgroundColor = colorDialog1.selectedColor;
            }
            colorDialog1.create();

            jQuery("#AddInfoDiv").hide();
            jQuery("#AddInfo").click(function () {
                jQuery("#AddButtonDiv").hide();
                jQuery("#AddInfoDiv").show();
            });
            jQuery("#sure").click(function () {
                var pd = 0;
                jQuery.each(jQuery("#AddleagueInfo").find(":text"), function (i) {
                    if (jQuery("#AddleagueInfo").find(":text:eq(" + i + ")").val() == "") {
                        alert(languages.H1004);
                        pd = 1;
                        return false;
                    }
                });
                if (pd) {
                    return false;
                }
                var data = "time:'" + jQuery("#day").val() + " " + jQuery("#hour").val() + ":" + jQuery("#minute").val() + ":00" + "',";
                data += "leaguecn:'" + jQuery("#leaguecn").val() + "',leaguetw:'" + jQuery("#leaguetw").val() + "',leagueen:'" + jQuery("#leagueen").val() + "',";
                data += "leagueth:'" + jQuery("#leagueth").val() + "',leaguevn:'" + jQuery("#leaguevn").val() + "',leaguecolor:'" + jQuery("#leaguecolor").val() + "',";
                data += "leaguetype:'" + jQuery("#leaguetype").val() + "',number:'" + jQuery("#number").val() + "',homecn:'" + jQuery("#homecn").val() + "',";
                data += "hometw:'" + jQuery("#hometw").val() + "',homeen:'" + jQuery("#homeen").val() + "',hometh:'" + jQuery("#hometh").val() + "',";
                data += "homevn:'" + jQuery("#homevn").val() + "',awaycn:'" + jQuery("#awaycn").val() + "',awaytw:'" + jQuery("#awaytw").val() + "',";
                data += "awayen:'" + jQuery("#awayen").val() + "',awayth:'" + jQuery("#awayth").val() + "',awayvn:'" + jQuery("#awayvn").val() + "',";
                data += "display:'" + (jQuery("#display").attr("checked") == true ? "1" : "0") + "',running:'" + (jQuery("#running").attr("checked") == true ? "1" : "0") + "'";
                jQuery.AjaxCommon("/ServicesFile/ReleaseSite/ReleaseSiteService.asmx/insertInfo", data, false, false, function (json) {

                });
                IsPage(count1, number1, pageNum1, "first", "end");
                jQuery("#AddButtonDiv").show();
                jQuery("#AddInfoDiv").hide();
            });
            jQuery("#esc").click(function () {
                jQuery("#AddButtonDiv").show();
                jQuery("#AddInfoDiv").hide();
            });
            $("#day").datepicker();
            $("#day").keydown(function () {
                if (window.event.keyCode == 8) {
                    $("#day").val("");
                }
                else {
                    alert(languages.H1095);
                    return false;
                }
            });
            $("#hour").focus(function () {
                if (!IsNullByInfo(document.getElementById("day"), "daylbl", languages.H1096)) return false;
            });
            $("#hour").blur(function () {
                if (!IsElJudge(this, "hourlbl", "hour", languages.H1097, languages.H1098, 0)) return false;
            });
            $("#day").blur(function () {
                if (!IsNullByInfo(this, "daylbl", languages.H1096)) return false;
            });
            $("#minute").focus(function () {
                if (!IsNullByInfo($("#day"), "daylbl", languages.H1096)) return false;
            });
            $("#minute").blur(function () {
                if (!IsElJudge(this, "minutelbl", "minute", languages.H1099, languages.H1100, 0)) return false;
            });


        })

        function setDate(data1) {
            //alert(data1);
            //var data = "language:'" + jQuery("#langue").val() + "'";
            jQuery.ajax({ url: "arrayData.aspx", type: "post", data: "langu=" + jQuery("#langue").val() + "&type=2&" + data1.replace(/:/g, "=").replace(/,/g, "&"), success: function (json) {
                //if (json.d != "none") {

                json;
                //debugger
                jQuery("#ShowInfo>tr:gt(0)").remove();
                var tr1 = jQuery("#tr1").clone();
                //var result = jQuery.parseJSON(json.d);
                var a = new Array();
                for (var i = 0; i < data.length; i++) {
                    a = data[i];
                    var tr = jQuery("#tr1").clone();
                    tr.find("#timeTD").text(a[4]);
                    tr.find("#leagueTD").text(a[2]);
                    tr.find("#leagueTD").css("background-color", "" + a[3]);
                    tr.find("#homeTD").text(a[6]);
                    tr.find("#awayTD").text(a[7]);
                    if (a[8] == "1") {
                        tr.find("#runningTD").html("<input type=\"checkbox\" disabled=\"disabled\" checked=\"checked\" />");
                    }
                    else {
                        tr.find("#runningTD").html("<input type=\"checkbox\" disabled=\"disabled\" />");
                    }
                    tr.find("#scoreTD").text(a[9]);
                    tr.find("#redcardTD").text(a[10]);
                    tr.find("#dangerTD").html("<input type=\"checkbox\" disabled=\"disabled\" " + (a[11] == 1 ? " checked=\"checked\"" : "") + " />");
                    tr.find("#stateTD").text(a[12] == 1 ? languages.H1101 : (a[12] == 0 ? languages.H1102 : languages.H1103));
                    if (a[13] == "1") {
                        tr.find("#displayTD").html("<input type=\"checkbox\" disabled=\"disabled\" checked=\"checked\" />");
                    }
                    else {
                        tr.find("#displayTD").html("<input type=\"checkbox\" disabled=\"disabled\" />");
                    }
                    tr.find("#typeTD").text(a[18] == 1 ? languages.H1104 : (a[18] == 2 ? languages.H1105 : languages.H1106));
                    tr.find("#casinoTD").text((a[19] == 0 ? "" : a[19]));
                    <%if(upAc){ %>
                    tr.find("#updateTD").html("<input type=\"hidden\" value=\"" + a[5].substr(0, 10) + "\" /><input type=\"hidden\" value=\"" + a[1] + "\" /><input type=\"hidden\" id=\"colorHide\" value=\"" + a[3] + "\" /><a id=\"A" + a[0] + "\" style=\"cursor:hand\"><img src=\"/images/Icon/page_edit.gif\" title=\""+languages.H1009+"\" /></a>");
                    <%} %>
                    jQuery("#day1").datepicker();
                    jQuery("#day1").keydown(function () {
                        if (window.event.keyCode == 8) {
                            jQuery("#day1").val("");
                        }
                        else {
                            alert(languages.H1095);
                            return false;
                        }
                    });
                    tr.appendTo("#ShowInfo");
                }
                jQuery("#ShowInfo>tr:eq(0)").remove();
                jQuery("#ShowInfo>tr").find("#updateTD").find("a").click(function () {
                    eida(jQuery(this));
                    tr1.find("td:gt(0)").remove();
                    tr1.find("td:eq(0)").attr("colspan", "13");
                    tr1.find("td:eq(0)").html("");
                    jQuery("#AddInfoDiv1").show().appendTo(tr1.find("td:eq(0)"));
                    jQuery(this).parent().parent().after(tr1);
                });
                //}
            } 
            });
        }
        function eida(obj) {
            jQuery("#AddInfoDiv1").find("#numberID").val(""+jQuery(obj).attr("id").substr(1));
            jQuery("#AddInfoDiv1").find("#homeScore").attr("disabled", "disabled");
            jQuery("#AddInfoDiv1").find("#awayScore").attr("disabled", "disabled");
            jQuery("#AddInfoDiv1").find("#redcard").attr("disabled", "disabled");
            jQuery("#AddInfoDiv1").find("#danger").attr("disabled", "disabled");
            (jQuery("#AddInfoDiv1").hide()).appendTo(jQuery("#form1"));
            jQuery("#AddInfoDiv1").find("#homeScore").val("");
            jQuery("#AddInfoDiv1").find("#awayScore").val("");
            jQuery("#AddInfoDiv1").find("#redcard").val("");
            jQuery("#AddInfoDiv1").find("#danger").removeAttr("checked");
            jQuery("#AddInfoDiv1").find("#display1").removeAttr("checked");
            jQuery("#AddInfoDiv1").find("#running1").removeAttr("checked");
            if (jQuery(obj).parent().parent().find("#dangerTD").find(":checkbox").attr("checked") == true) {
                jQuery("#AddInfoDiv1").find("#danger").attr("checked","checked");
            }
            else {
                jQuery("#AddInfoDiv1").find("#danger").removeAttr("checked");
            }
            var a = "<select id=\"type1\">";
            a += "<option value=\"3\" ";
            if (jQuery(obj).parent().parent().find("#typeTD").text() == languages.H1106) {
                a += " selected=\"selected\"";
            }
            a += ">"+ languages.H1106+"</option><option value=\"2\" ";
            if (jQuery(obj).parent().parent().find("#typeTD").text() ==languages.H1105) {
                a += " selected=\"selected\"";
            }
            a += ">"+ languages.H1105+"</option><option value=\"1\" ";
            if (jQuery(obj).parent().parent().find("#typeTD").text() == languages.H1104) {
                a += " selected=\"selected\"";
            }
            a+= ">"+ languages.H1104+"</option></select>";
            jQuery("#type1TD").html(a);
            //jQuery("#AddInfoDiv1").find("#type1TD").find("#type1").find("option:eq(" + (3 - parseInt(result[i].type)) + ")").css("selected", "selected");
            jQuery("#AddInfoDiv1").find("#day1").val(jQuery(obj).parent().find(":hidden:eq(0)").val());
            jQuery("#AddInfoDiv1").find("#hour1").val(jQuery(obj).parent().parent().find("#timeTD").text().substr(6, 2));
            jQuery("#AddInfoDiv1").find("#minute1").val(jQuery(obj).parent().parent().find("#timeTD").text().substr(9, 2));
            jQuery("#AddInfoDiv1").find("#leagueName").text(jQuery(obj).parent().parent().find("#leagueTD").text());
            jQuery("#AddInfoDiv1").find("#color1").val("" + jQuery(obj).parent().find("#colorHide").val());
            jQuery("#AddInfoDiv1").find("#color1").css("background-color", "" + jQuery(obj).parent().find("#colorHide").val());
            jQuery("#AddInfoDiv1").find("#PK").html(jQuery(obj).parent().parent().find("#homeTD").text() + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + jQuery(obj).parent().parent().find("#awayTD").text());
            jQuery("#AddInfoDiv1").find("#num1").val(jQuery(obj).parent().find(":hidden:eq(1)").val());
            if (jQuery(obj).parent().parent().find("#displayTD").find(":checkbox").attr("checked") == true) {
                jQuery("#AddInfoDiv1").find("#display1").attr("checked", "checked");
            }
            else {
                jQuery("#AddInfoDiv1").find("#display1").removeAttr("checked");
            }
            if (jQuery(obj).parent().parent().find("#runningTD").find(":checkbox").attr("checked") == true) {
                jQuery("#AddInfoDiv1").find("#running1").attr("checked", "checked");
            }
            else {
                jQuery("#AddInfoDiv1").find("#running1").removeAttr("checked");
            }
            if (jQuery(obj).parent().parent().find("#scoreTD").text() == "") {
                jQuery("#AddInfoDiv1").find("#homeScore").attr("disabled", "disabled");
                jQuery("#AddInfoDiv1").find("#awayScore").attr("disabled", "disabled");
                jQuery("#AddInfoDiv1").find("#redcard").attr("disabled", "disabled");
                jQuery("#AddInfoDiv1").find("#danger").attr("disabled", "disabled");
            }
            else {
                jQuery("#AddInfoDiv1").find("#homeScore").removeAttr("disabled");
                jQuery("#AddInfoDiv1").find("#awayScore").removeAttr("disabled");
                jQuery("#AddInfoDiv1").find("#redcard").removeAttr("disabled");
                jQuery("#AddInfoDiv1").find("#danger").removeAttr("disabled");
                jQuery("#AddInfoDiv1").find("#homeScore").val(jQuery(obj).parent().parent().find("#scoreTD").text().substr(0, jQuery(obj).parent().parent().find("#scoreTD").text().indexOf(":")));
                jQuery("#AddInfoDiv1").find("#awayScore").val(jQuery(obj).parent().parent().find("#scoreTD").text().substr(jQuery(obj).parent().parent().find("#scoreTD").text().indexOf(":") + 1));
                jQuery("#AddInfoDiv1").find("#redcard").val(jQuery(obj).parent().parent().find("#redcardTD").text());
            }
        }

        function saveUpda() {
            var data = "id:'" + jQuery("#AddInfoDiv1").find("#numberID").val() + "',time:'" + jQuery("#day1").val() + " " + jQuery("#hour1").val() + ":" + jQuery("#minute1").val() + ":00" + "',";
            data += "leaguecolor:'" + jQuery("#AddInfoDiv1").find("#color1").val() + "',";
            data += "leaguetype:'" + jQuery("#AddInfoDiv1").find("#type1TD").find("#type1").val() + "',";
            data += "display:'" + (jQuery("#AddInfoDiv1").find("#display1").attr("checked") == true ? "1" : "0") + "',";
            data += "running:'" + (jQuery("#AddInfoDiv1").find("#running1").attr("checked") == true ? "1" : "0") + "',";
            data += "score:'" + (jQuery("#AddInfoDiv1").find("#homeScore").val() + ":" + jQuery("#AddInfoDiv1").find("#awayScore").val()) + "',";
            data += "redcard:'" + jQuery("#AddInfoDiv1").find("#redcard").val() + "',";
            data += "danger:'" + (jQuery("#AddInfoDiv1").find("#danger").attr("checked") == true ? "1" : "0") + "',";
            data += "number:'" + jQuery("#AddInfoDiv1").find("#num1").val() + "'";
            (jQuery("#AddInfoDiv1").hide()).appendTo(jQuery("#form1"));
            jQuery(this).remove();
            jQuery.AjaxCommon("/ServicesFile/ReleaseSite/ReleaseSiteService.asmx/updateInfo", data, false, false, function (json) { 
                jQuery.AjaxCommon("/ServicesFile/ReleaseSite/ReleaseSiteService.asmx/GetCount", "", true, false, function (json) {
                // alert(json.d);
                if (json.d != "none") {

                    number1 = parseInt(jQuery.parseJSON(json.d)[0].zs);
                }
                });
                if (number1 % pageNum1 == 0) {
                    count1 = parseInt(number1 / pageNum1);
                }
                else {
                    count1 = parseInt(number1 / pageNum1) + 1;
                }
                IsPage(count1, number1, pageNum1, "first", "end");
             });
        }
        function saveEsc() {
            (jQuery("#AddInfoDiv1").hide()).appendTo(jQuery("#form1"));
            jQuery(this).remove();
        }
    </script>
</head>
<body>
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p class="H1448">放盘</p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<!--主题部分开始=========================================================================================-->
<input type="hidden" id="langue" value="tw" />
    <form id="form1" runat="server">
    <%if (addAc)
      { %>
    <div  id="AddButtonDiv">
    <a  id="AddInfo" class="fa_add"><span class="fa_add_in" id="H1015">新增</span></a>
    </div>
    <%} %>
    <div class="tc" id="AddInfoDiv">
    <input type="hidden" value="" id="hideID" />
    <div id="add_list" class="new_tr ">
<div align="center">
    <table cellpadding="0" cellspacing="0" class="boder_none" >
    <tr>
<td class="H1107" colspan="9" id="headTitle" >新增比赛信息</td>
</tr>
    <tbody id="AddleagueInfo">
    <tr>
    <td class="H1108">开赛时间:</td>
    <td class="tl" colspan="8">
    <input type="text" id="day" class="text_01 w_80" onmousemove="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" />
    &nbsp;&nbsp;<input type="text" id="hour" class="text_01 w_30" onmousemove="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" /><span  class="H1109">时</span>  
    &nbsp;&nbsp;<input type="text" id="minute" class="text_01 w_30" onmousemove="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" /><span  class="H1110">分</span>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <label id="daylbl" style="color:Red"></label>&nbsp;&nbsp;&nbsp;&nbsp;
    <label id="hourlbl" style="color:Red"></label>&nbsp;&nbsp;&nbsp;&nbsp;
    <label id="minutelbl" style="color:Red"></label>
    </td>
    </tr>
    <tr>
    <td class="tr" id="H1111">联赛简体中文名称</td>
    <td class="tl"><input type="text" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" id="leaguecn" maxlength="30" /></td>
    <td class="tl"><label id="leaguecnlbl" style="color:Red"></label></td>
    <td class="tr" id="H1112">联赛繁体中文名称</td>
    <td class="tl"><input type="text" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" id="leaguetw" maxlength="30" /></td>
    <td class="tl"><label id="leaguetwlbl" style="color:Red"></label></td>
    <td class="tr" id="H1113">联赛英文名称</td>
    <td class="tl"><input type="text" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" id="leagueen" maxlength="60" /></td>
    <td class="tl"><label id="leagueenlbl" style="color:Red"></label></td>
    </tr>
    <tr>
    <td class="tr" id="H1114">联赛泰文名称</td>
    <td class="tl"><input type="text" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" id="leagueth" maxlength="60" /></td>
    <td class="tl"><label id="leaguethlbl" style="color:Red"></label></td>
    <td class="tr" id="H1115">联赛越文名称</td>
    <td class="tl"><input type="text" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" id="leaguevn" maxlength="60" /></td>
    <td class="tl"><label id="leaguevnlbl" style="color:Red"></label></td>
    <td class="tr" id="H1116">联赛颜色</td>
    <td class="tl" colspan="2"><input type="text" disabled="disabled" id="leaguecolor" />
    <input type="button" value="选择颜色"  class="H1117" id="colorSelect" /></td>
    </tr>
    <tr>
    <td class="H1118">类型</td><%--class="tr" --%>
    <td class="tl" colspan="2"><select id="leaguetype"><option value="3">早餐</option><option value="2">走地</option><option value="1">单式</option></select></td>
    <td class="H1024">显示序号</td>
    <td class="tl"><input type="text" id="number" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" /></td>
    <td class="tl" colspan="4"><label id="numberlbl" style="color:Red"></label></td>
    </tr>
    <tr>
    <td class="tr"  id="H1119">主队简体中文名称</td>
    <td class="tl"><input type="text" id="homecn" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" maxlength="25" /></td>
    <td class="tl"><label id="homecnlbl" style="color:Red"></label></td>
    <td class="tr" id="H1120">主队繁体中文名称</td>
    <td class="tl"><input type="text" id="hometw" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" /></td>
    <td class="tl"><label id="hometwlbl" style="color:Red"></label></td>
    <td class="tr" id="H1121">主队英文名称</td>
    <td class="tl"><input type="text" id="homeen" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" /></td>
    <td class="tl"><label id="homernlbl" style="color:Red"></label></td>
    </tr>
    <tr>
    <td class="tr" id="H1122">主队泰文名称</td>
    <td class="tl"><input type="text" id="hometh" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" /></td>
    <td class="tl"><label id="homethlbl" style="color:Red"></label></td>
    <td class="tr" id="H1123">主队越文名称</td>
    <td class="tl"><input type="text" id="homevn" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" /></td>
    <td class="tl"><label id="homevnlbl" style="color:Red"></label></td>
    <td class="tr" id="H1124">客队简体中文名称</td>
    <td class="tl"><input type="text" id="awaycn" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" /></td>
    <td class="tl"><label id="awaycnlbl" style="color:Red"></label></td>
    </tr>
    <tr>
    <td class="tr" id="H1125">客队繁体中文名称</td>
    <td class="tl"><input type="text" id="awaytw" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" /></td>
    <td class="tl"><label id="awaytwlbl" style="color:Red"></label></td>
    <td class="tr" id="H1126">客队英文名称</td>
    <td class="tl"><input type="text" id="awayen" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" /></td>
    <td class="tl"><label id="awayenlbl" style="color:Red"></label></td>
    <td class="tr" id="H1127">客队泰文名称</td>
    <td class="tl"><input type="text" id="awayth" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" /></td>
    <td class="tl"><label id="awaythlbl" style="color:Red"></label></td>
    </tr>
    <tr>
    <td class="tr" id="H1128">客队越文名称</td>
    <td class="tl"><input type="text"  id="awayvn" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" /></td>
    <td class="tl"><label id="awayvnlbl" style="color:Red"></label></td>
    <td class="tr" id="H1022">是否显示</td>
    <td class="tl"><input type="checkbox" id="display" /></td>
    <td></td>
    <td class="tr" id="H1129">是否走地</td>
    <td class="tl"><input type="checkbox" id="running" /></td>
    <td></td>
    </tr>
    <tr id="trEnd">
    <td align="center" colspan="9">
<input type="button" id="sure" class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'"  value="保存" />
<input type="button"  id="esc" class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'"  value="取消" />
</td>
</tr>
    </tbody>
    </table>
    </div>
    </div>
    </div>
    <table class="tab2" id="tb2" width="100%" border="0" cellpadding="0" cellspacing="0">
    <thead>
    <tr>
    <th class="H1056">时间</th>
    <th class="H1130">联赛</th>
    <th class="H1131">主队</th>
    <th class="H1132">客队</th>
    <th class="H1105">走地</th>
    <th class="H1133">比分</th>
    <th class="H1134">红牌</th>
    <th class="H1135">危险球</th>
    <th class="H1136">比赛状态</th>
    <th class="H1022">是否显示</th>
    <th class="H1137">比赛类型</th>
    <th class="H1138">导入比赛的网站</th>
    <%if (upAc)
      { %>
    <th class="H1009">修改</th>
    <%} %>
    </tr>
    </thead>
    <tbody id="ShowInfo">
    <tr id="tr1">
    <td id="timeTD"></td>
    <td id="leagueTD"></td>
    <td id="homeTD"></td>
    <td id="awayTD"></td>
    <td id="runningTD"></td>
    <td id="scoreTD"></td>
    <td id="redcardTD"></td>
    <td id="dangerTD"></td>
    <td id="stateTD"></td>
    <td id="displayTD"></td>
    <td id="typeTD"></td>
    <td id="casinoTD"></td>
    <td id="updateTD"></td>
    </tr>
    </tbody>
    <tfoot><tr class="tc"><td colspan="13"><div id="pageDiv" class="grayr"><label  class="H1028">总共</label><label id="infoCount"></label><label class="H1029">条记录</label>,<label  class="H1447">共</label><label id="pageCount"></label><label class="H1030">页</label><a style="cursor:hand" class="H1031"> 首页 </a><a style="cursor:hand" class="H1032"> 上一页 </a><span id="pageSpan"></span><a style="cursor:hand" class="H1033"> 下一页 </a><a style="cursor:hand" class="H1034"> 尾页 </a></div></td></tr></tfoot>
    </table>
    </form>

    <div style="width:100%" class="tc" id="AddInfoDiv1"><input type="hidden" id="numberID" /><div style="width:100%" id="add_list1" class="new_tr "><div style="text-align:center;width:40%">
    <table width="100%" cellpadding="0" cellspacing="0" class="boder_none"><thead><tr><th colspan="9" class="H1139">修改比赛信息</th></tr></thead>
    <tbody id="tbody1">
    <tr>
    <td class="H1108">开赛时间:</td><td colspan="4"><input type="text" id="day1" class="text_01 w_80" onmousemove="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" />
    &nbsp;&nbsp;<input type="text" id="hour1" class="text_01 w_30" onmousemove="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" /><span  class="H1109">时</span>
    &nbsp;&nbsp;<input type="text" id="minute1" class="text_01 w_30"onmousemove="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" /><span  class="H1110">分</span>
    &nbsp;&nbsp;&nbsp;&nbsp;<label id="day1lbl" style="color:Red"></label>&nbsp;&nbsp;&nbsp;&nbsp;
    <label id="hour1lbl" style="color:Red"></label>&nbsp;&nbsp;&nbsp;&nbsp;<label id="minute1lbl" style="color:Red"></label></td>
    </tr>
    <tr>
    <td class="tr" id="H1130">联赛:</td>
    <td><label id="leagueName"></label></td>
    <td colspan="2"><input id="color1" disabled="disabled" type="text" />
    <input type="button" id="colorSelect1" class="H1117" value="选择颜色"/></td></tr>
    <tr>
    <td class="H1118">类型</td><%--class="tr "--%>
    <td class="tl" colspan="3" id="type1TD"></td>
    </tr>
    <tr>
    <td colspan="4"><label id="PK"></label></td>
    </tr>
    <tr>
    <td  class="H1024">显示序号</td>
    <td><input type="text" id="num1" /></td>
    <td class="H1022">是否显示<input id="display1" type="checkbox" /></td>
    <td class="H1105">走地<input id="running1" type="checkbox" /></td>
    </tr>
    <tr>
    <td class="H1140">主队得分:<input id="homeScore" disabled="disabled" type="text" class="text_01 w_30" onmousemove="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" /></td>
    <td class="H1141">客队得分:<input id="awayScore" disabled="disabled" type="text" class="text_01 w_30" onmousemove="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" /></td>
    <td class="H1134">红牌:<input id="redcard" disabled="disabled" type="text" class="text_01 w_30" onmousemove="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" /></td>
    <td class="H1135">危险球:<input type="checkbox" disabled="disabled" id="danger" /></td>
    </tr>
    <tr>
    <td class="tc" colspan="4">
    <input type="button" class="btn_02" onclick="saveUpda()" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="修改" id="updatebutton" />
    <input type="button" class="btn_02" onclick="saveEsc()" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="取消" id="escbutton" />
    </td>
    </tr>
    </tbody>
    
    </table>
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
