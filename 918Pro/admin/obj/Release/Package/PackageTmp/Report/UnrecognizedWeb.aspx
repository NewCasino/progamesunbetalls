<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnrecognizedWeb.aspx.cs" Inherits="admin.Report.UnrecognizedWeb" %>

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
    <script type="text/javascript">
        var idList;
        var typeList;
        var info = "";
        var languages = "";
        var result1 = new Array();
        var olddata = "";
        jQuery(function () {
            SetGlobal("");
            jQuery("#infoDiv").hide();
            jQuery("#oneInfoDiv").hide();
            idList = new Array();
            typeList = new Array();
            var setLang = "";
            setLang = $.SetOrGetLanguage(setLang, function () {
                languages = language;
                typeList[0] = languages["H1236"];
                typeList[1] = languages["H1237"];
                typeList[2] = languages["H1238"];
                typeList[3] = languages["H1239"];
                typeList[4] = languages["H1240"];
                typeList[5] = languages["H1241"];
                typeList[6] = languages["H1242"];
                typeList[7] = languages["H1243"];
                typeList[8] = languages["H1244"];
                typeList[9] = languages["H1245"];
                typeList[10] = languages["H1246"];
                typeList[11] = languages["H1247"];
                typeList[12] = languages["H1248"];
                typeList[13] = languages["H1249"];
                typeList[14] = languages["H1250"];
                typeList[15] = languages["H1251"];
                typeList[16] = languages["H1252"];
                typeList[17] = languages["H1253"];
            }, "/js/IndexGlobal/");
            var data = "length:'50'";
            getCasino();
            setData(data);
            Countdown(jQuery("#timeTxt").val());
            jQuery("#sureAll").click(function () {
                if (jQuery("#showInfo").find(":checkbox:checked").length == 0) {
                    var setLang = "";
                    setLang = $.SetOrGetLanguage(setLang, function () {
                        languages = language;
                        jQuery("#labl").text(languages["H1267"]);
                    }, "/js/IndexGlobal/");
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
                jQuery.AjaxCommon("/ServicesFile/ReportService/UnrecognizedService.asmx/setUpData", data, true, false, function (json) { });
                idList = new Array();
            });
            jQuery("#escAll").click(function () {
                if (jQuery("#showInfo").find(":checkbox:checked").length == 0) {
                    var setLang = "";
                    setLang = $.SetOrGetLanguage(setLang, function () {
                        languages = language;
                        jQuery("#labl").text(languages["H1268"]);
                    }, "/js/IndexGlobal/");
                    return false;
                }
                jQuery("#labl").text("");
                jQuery("#infoDiv").dialog({ modal: true });
            });
        });

        function SetGlobal(setLang) {
            setLang = $.SetOrGetLanguage(setLang, function () {
                languages = language;
                jQuery("#zd").text(languages["走地未确认注单"]);
                jQuery("#sureAll").val(languages["H1037"]);
                jQuery("#escAll").val(languages["H1011"]);
                jQuery("#btnSure").val(languages["H1037"]);
                jQuery("#btnEsc").val(languages["H1011"]);

                jQuery("#Button1").val(languages["H1037"]);
                jQuery("#Button2").val(languages["H1011"]);

                jQuery("#tjl").text(languages["H1029"]);
                jQuery("#qxqx").text(languages["H1166"]);
                jQuery("#tab3>thead>tr>th:eq(1)").text(languages["H1262"]);
                jQuery("#tab3>thead>tr>th:eq(2)").text(languages["H1265"]);
                jQuery("#tab3>thead>tr>th:eq(3)").text(languages["H1170"]);
                jQuery("#tab3>thead>tr>th:eq(4)").text(languages["H1259"]);
                jQuery("#tab3>thead>tr>th:eq(5)").text(languages["H1173"]);
                jQuery("#tab3>thead>tr>th:eq(6)").text(languages["H1171"]);
                jQuery("#tab3>thead>tr>th:eq(7)").text(languages["H1172"]);
                jQuery("#tab3>thead>tr>th:eq(8)").text(languages["H1263"]);
                jQuery("#tab3>thead>tr>th:eq(9)").text(languages["H1054"]);
                jQuery("#tab3>thead>tr>th:eq(10)").text(languages["H1027"]);

                jQuery("#infoDiv").attr("title", languages["H1270"]);
                jQuery("#infoDiv table>tr>td:eq(0)").text(languages["H1270"]+":");
                jQuery("#oneInfoDiv").attr("title", languages["H1270"]);
                jQuery("#oneInfoDiv table>tr>td:eq(0)").text(languages["H1270"]+":");

                switch (setLang) {
                    case "zh-cn":
                        jQuery("#language").val("cn")
                        break;
                    case "zh-tw":
                        jQuery("#language").val("tw")
                        break;
                    case "en-us":
                        jQuery("#language").val("en")
                        break;
                }

            }, "/js/IndexGlobal/");

        }

        var action = "stop";
        function setData(data) {
            jQuery.AjaxCommon("/ServicesFile/ReportService/UnrecognizedService.asmx/getAllToLength", data, true, false, function (json) {
                if (json.d != "none") {
                    //                    if (json.d == olddata)
                    //                        return;
                    olddata = json.d;
                    jQuery("#showInfo>tr").remove();
                    var result = jQuery.parseJSON(json.d);
                    var arr = new Array();
                    var lan1 = jQuery("#language").val();
                    action = "stop";
                    jQuery.each(result, function (i) {

                        var da = Date.parse(result[i].time.replace(/-/g, "/"));
                        da += 12 * 60 * 60 * 1000;
                        var date1 = new Date(da);
                        var date2 = new Date();
                        var diff = date2 - date1;
                        if (diff > 5 * 60 * 1000) {
                            action = "play";
                        }

                        arr.push("<tr id='tr1'>");
                        arr.push("<td id='check'>");
                        arr.push("<input type=\"checkbox\" value=\"" + typeList[parseInt(result[i].BetType)] + "\" id=\"A" + result[i].ID + "\"" + (jQuery.inArray(result[i].ID, idList) != -1 ? "checked" : "") + " />");
                        arr.push("</td>");
                        arr.push("<td id='time'>");
                        arr.push(result[i].UserName + "<br/>" + result[i].OrderID + "<br/>" + result[i].time);
                        arr.push("</td>");
                        arr.push("<td id='webUserName'>");
                        arr.push("<a href=\"/Report/DataByCasinoAccount.aspx?a=" + result[i].WebSiteiID + "&b=" + result[i].WebUserName + "\" target=\"_blank\">" + result[i].WebUserName + "</a><br/>" + result[i].WebOrderID);
                        arr.push("</td>");
                        arr.push("<td id='league'>");
                        switch (lan1) {
                            case "tw":
                                arr.push(result[i].leaguetw + "<br/>" + result[i].Hometw + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awaytw + "<br/>" + result[i].Score);
                                break;
                            case "cn":
                                arr.push(result[i].leaguecn + "<br/>" + result[i].Homecn + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awaycn + "<br/>" + result[i].Score);
                                break;
                            case "en":
                                arr.push(result[i].leagueen + "<br/>" + result[i].Homeen + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awayen + "<br/>" + result[i].Score);
                                break;
                            case "th":
                                arr.push(result[i].leagueth + "<br/>" + result[i].Hometh + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awayth + "<br/>" + result[i].Score);
                                break;
                            case "vn":
                                arr.push(result[i].leaguevn + "<br/>" + result[i].Homevn + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awayvn + "<br/>" + result[i].Score);
                                break;

                        }
                        arr.push();
                        arr.push("</td>");
                        arr.push("<td id='BetType'>");
                        arr.push(typeList[parseInt(result[i].BetType)] + "<br/>" + (result[i].IsHalf == 1 ? languages["H1159"] : languages["H1160"]));
                        arr.push("</td>");

                        arr.push("<td id='Handicap'>");
                        arr.push(result[i].BetItem + "<span class='red'>@</span>" + result[i].Handicap);
                        arr.push("</td>");

                        arr.push("<td id='Odds'>");
                        arr.push(result[i].Odds + "<br/>" + result[i].OddsType);
                        arr.push("</td>");

                        arr.push("<td id='ValidAmount'>");
                        arr.push(result[i].Amount + "<br/>" + result[i].ValidAmount);
                        arr.push("</td>");
                        arr.push("<td id='Company'>");
                        arr.push("");
                        arr.push("</td>");
                        arr.push("<td id='WebSiteiID'>");
                        arr.push(result1[result[i].WebSiteiID][lan1] + "<br>" + result[i].IP);
                        arr.push("<td id='opCa'>");
                        arr.push("<a onclick=\"sureOne(this)\">" + languages["H1037"] + "</a>&nbsp;&nbsp;&nbsp;&nbsp;<a onclick=\"escOne(this)\">" + languages["H1011"] + "</a>");
                        arr.push("</td>");
                        arr.push("</tr>");


                    });
                    //播放/暂停声音
                    //ManageSoundControl(action);
                    if (action == "play") {
                        jQuery("#replay").click();
                    }

                    $("#showInfo").html(arr.join("\n\r"));
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
        function setData3(data) {
            jQuery.AjaxCommon("/ServicesFile/ReportService/UnrecognizedService.asmx/getAllToLength", data, true, false, function (json) {
                if (json.d != "none") {
                    jQuery("#showInfo>tr").remove();
                    var result = jQuery.parseJSON(json.d);
                    jQuery.each(result, function (i) {
                        var tr = jQuery("#tr1").clone();
                        tr.find("#check").html("<input type=\"checkbox\" value=\"" + typeList[parseInt(result[i].BetType)] + "\" id=\"A" + result[i].ID + "\"" + (jQuery.inArray(result[i].ID, idList) != -1 ? "checked" : "") + " />");
                        tr.find("#time").html(result[i].UserName + "<br/>" + result[i].OrderID + "<br/>" + result[i].time);
                        tr.find("#WebUserName").html("<a href=\"/Report/DataByCasinoAccount.aspx?a=" + result[i].WebSiteiID + "&b=" + result[i].WebUserName + "\" target=\"_blank\">" + result[i].WebUserName + "</a><br/>" + result[i].WebOrderID);
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
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            tr.find("#BetType").html(typeList[parseInt(result[i].BetType)] + "&nbsp;&nbsp;&nbsp;&nbsp;" + (result[i].IsHalf == 1 ? languages["H1159"] : languages["H1160"]) + "<br/>" + result[i].BetItem);
                        }, "/js/IndexGlobal/");
                        tr.find("#Handicap").html(result[i].Handicap + "<br/>" + result[i].BetItem);
                        tr.find("#Odds").html(result[i].Odds + "<br/>" + result[i].OddsType);
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
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            tr.find("#opCa").html("<a onclick=\"sureOne(this)\">" + languages["H1037"] + "</a>&nbsp;&nbsp;&nbsp;&nbsp;<a onclick=\"escOne(this)\">" + languages["H1011"] + "</a>");
                        }, "/js/IndexGlobal/");
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
        function getCasino() {
            $.AjaxCommon("/ServicesFile/webBasicInfo/WebInfoService.asmx/GetDate", "", false, false, function (json1) {
                if (json1.d != "none") {
                    var result = jQuery.parseJSON(json1.d);
                    $.each(result, function (j) {
                        var arr = new Array();
                        arr["tw"] = result[j].nametw;
                        arr["cn"] = result[j].namecn;
                        arr["en"] = result[j].nameen;
                        arr["th"] = result[j].nameth;
                        arr["vn"] = result[j].namevn;

                        result1[result[j].id] = arr;

                    });
                }
            });
        }
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
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            alert(languages["H1254"]);
                        }, "/js/IndexGlobal/");
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
                    var setLang = "";
                    setLang = $.SetOrGetLanguage(setLang, function () {
                        languages = language;
                        alert(languages["H1255"]);
                    }, "/js/IndexGlobal/");
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
            var setLang = "";
            setLang = $.SetOrGetLanguage(setLang, function () {
                languages = language;
                jQuery("#infolbl").text(languages["H1269"]);
            }, "/js/IndexGlobal/");
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
            jQuery.AjaxCommon("/ServicesFile/ReportService/UnrecognizedService.asmx/setUpData", data, true, false, function (json) { });
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
            jQuery.AjaxCommon("/ServicesFile/ReportService/UnrecognizedService.asmx/setUpData", data, true, false, function (json) { });
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
                    var setLang = "";
                    setLang = $.SetOrGetLanguage(setLang, function () {
                        languages = language;
                        jQuery("#oneInfolbl").text(languages["H1269"]);
                    }, "/js/IndexGlobal/");
                    return false;
                }
                jQuery("#oneInfolbl").text("");
                var j = 0;
                var data = "id:'" + id1 + "',type:'0',info:'" + jQuery("#oneEscInfo").val() + "',typeInfo:'" + typeInfo1 + "'";
                jQuery.AjaxCommon("/ServicesFile/ReportService/UnrecognizedService.asmx/setUpData", data, true, false, function (json) { });
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

        function ManageSoundControl(action) {
            var soundControl = document.getElementById("soundControl");
            if (action == "play") {
                soundControl.play();
            }
            if (action == "stop") {
                soundControl.stop();
            }
        }
    </script>
</head>
<body>
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="zd">走地未确认注单</p></th>
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
    <input type="text" value="50" id="DataLength" class="text_01 w_60" onmouseover="this.className='text_01_h w_60'" onmouseout="this.className='text_01 w_60'" /><a id="tjl">条记录</a>&nbsp;&nbsp;&nbsp;&nbsp;
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
    <th><input type="checkbox" id="checkAll1" value="checkAll" /><a id="qxqx">全选/取消</a><a id="replay" href="#" onclick="ManageSoundControl('play');">&nbsp;</a></th>
    <th>下注</th>
    <th>投注账号</th>
    <th>比赛</th>
    <th>投注类型</th>
    <th>盘口</th>
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
     <td id="webUserName"></td>
    <td id="league"></td>
    <td id="BetType"></td>
    <td id="Handicap"></td>
    <td id="Odds"></td>
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
<embed id="soundControl" src="/images/wav/ring3.wav" mastersound hidden="true" loop="false" autostart="false"></embed>
</body>
</html>
