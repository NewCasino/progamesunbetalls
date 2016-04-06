<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoteSingleDetailsWeb.aspx.cs" Inherits="admin.Report.NoteSingleDetailsWeb" %>

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
        var typeList;
        var leagueName="";
        var bollID="";
        var languages = "";
        var olddata="";
        var result1=new Array();
        jQuery(function () {
        SetGlobal("");
            jQuery("#delet").hide();
            jQuery("#delet1").hide();
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
            getCasino();
            var data = "length:'50',league:'',level:'0',type:'-1',money:'',ballteam:'',language:'"+jQuery("#language").val()+"'";
            setData(data);
            
            setLevel();
            Countdown(jQuery("#timeTxt").val());
            /*-------------联赛信息-------------*/
            jQuery("#leagueAll").click(function () {

                data = "language:'" + jQuery("#language").val() + "'";
                jQuery.AjaxCommon("/ServicesFile/ReportService/NoteSingleService.asmx/GetLeagueToJson", data, true, false, function (json) {
                    if (json.d != "none") {
                        var tr = "<tr>";
                        jQuery("#tbody1").html("");
                        var result = jQuery.parseJSON(json.d);
                        jQuery.each(result, function (i) {
                            if (i != 0 && i % 4 == 0) {
                                tr += "</tr><tr>";
                            }
                            tr += "<td><input type=\"checkbox\" checked value=\"" + result[i].league + "\" />" + result[i].league + "</td>";
                        });
                        tr += "</tr>";
                        jQuery("#tbody1").html(tr);
                    }
                });
                jQuery("#delet").dialog({ width: 1000 });
                jQuery("#delet").dialog({ model: true });
                jQuery("#allLeague").attr("checked", "checked");
                //确定按钮
                jQuery("#btnSure").unbind("click");
                jQuery("#btnSure").click(function () {
                    jQuery.each(jQuery("#tbody1").find(":checkbox:checked"), function (i) {
                        if (i > 0) {
                            leagueName += ";";
                        }
                        leagueName += jQuery("#tbody1").find(":checkbox:checked:eq(" + i + ")").val();
                    });

                    if (jQuery("#allLeague").attr("checked") || jQuery("#tbody1").find(":checkbox:checked").length == 0) {
                        leagueName = "";
                    }
                    jQuery("#delet").dialog("close");
                });
                //取消按钮
                jQuery("#btnEsc").unbind("click");
                jQuery("#btnEsc").click(function () {
                    //leagueName = "";
                    jQuery("#delet").dialog("close");
                });
                //全选复选框
                jQuery("#allLeague").unbind("click");
                jQuery("#allLeague").click(function () {
                    jQuery("#tbody1").find(":checkbox").attr("checked", jQuery(this).attr("checked"));
                });
                //单项的复选框
                jQuery("#tbody1").find(":checkbox").unbind("click");
                jQuery("#tbody1").find(":checkbox").click(function () {
                    if (jQuery(this).attr("checked")) {
                        if (jQuery("#tbody1").find(":checkbox:checked").length == jQuery("#tbody1").find(":checkbox").length) {
                            jQuery("#allLeague").attr("checked", "checked");
                        }
                    }
                    else {
                        jQuery("#allLeague").removeAttr("checked");
                    }
                });
                //jQuery("#delet").attr("width","500px");
            });
            /*-----------联赛信息结束---------------------*/
            /*----------------球队信息--------------------*/
            jQuery("#boll").click(function () {
                data = "language:'" + jQuery("#language").val() + "'";
                jQuery.AjaxCommon("/ServicesFile/ReportService/NoteSingleService.asmx/GetBollToJson", data, true, false, function (json) {
                    if (json.d != "none") {
                        var tr = "<tr>";
                        jQuery("#tbody1").html("");
                        var result = jQuery.parseJSON(json.d);
                        jQuery.each(result, function (i) {
                            if (i != 0 && i % 3 == 0) {
                                tr += "</tr><tr>";
                            }
                            tr += "<td><input type=\"checkbox\" checked value=\"" + result[i].id + "\" />" + result[i].home + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].away + "</td>";
                        });
                        tr += "</tr>";
                        jQuery("#tbody2").html(tr);
                    }
                });
                jQuery("#delet1").dialog({ width: 800 });
                jQuery("#delet1").dialog({ model: true });
                jQuery("#againstAll").attr("checked", "checked");
                //确定按钮
                jQuery("#btnSure1").unbind("click");
                jQuery("#btnSure1").click(function () {
                    jQuery.each(jQuery("#tbody2").find(":checkbox:checked"), function (i) {
                        if (i > 0) {
                            bollID += ";";
                        }
                        bollID += jQuery("#tbody2").find(":checkbox:checked:eq(" + i + ")").val();
                    });

                    if (jQuery("#againstAll").attr("checked") || jQuery("#tbody2").find(":checkbox:checked").length == 0) {
                        bollID = "";
                    }
                    jQuery("#delet1").dialog("close");
                });
                //取消按钮
                jQuery("#btnEsc1").unbind("click");
                jQuery("#btnEsc1").click(function () {
                    //bollID = "";
                    jQuery("#delet1").dialog("close");
                });
                //全选复选框
                jQuery("#againstAll").unbind("click");
                jQuery("#againstAll").click(function () {
                    jQuery("#tbody2").find(":checkbox").attr("checked", jQuery(this).attr("checked"));
                });
                //单项的复选框
                jQuery("#tbody2").find(":checkbox").unbind("click");
                jQuery("#tbody2").find(":checkbox").click(function () {
                    if (jQuery(this).attr("checked")) {
                        if (jQuery("#tbody2").find(":checkbox:checked").length == jQuery("#tbody2").find(":checkbox").length) {
                            jQuery("#againstAll").attr("checked", "checked");
                        }
                    }
                    else {
                        jQuery("#againstAll").removeAttr("checked");
                    }
                });
            });
            /*--------------球队信息结束-------------------*/
            jQuery("#selectByWhere").click(function () {
                var t = "";
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
                <% if(searchAc) { %>
                var data = "length:'" + t + "',league:'" + leagueName + "',level:'" + jQuery("#level").val() + "',type:'" + jQuery("#type").val() + "',money:'" + jQuery("#money").val() + "',ballteam:'" + bollID + "',language:'" + jQuery("#language").val() + "'";
                <% } else { %>
                var data = "length:'" + t + "',league:'" + leagueName + "',level:'0',type:'-1',money:'',ballteam:'" + bollID + "',language:'" + jQuery("#language").val() + "'";
                <% } %>
                setData(data);
            });
        })

        function SetGlobal(setLang) {
            setLang = $.SetOrGetLanguage(setLang, function () {
                languages = language;
                jQuery("#zd").text(languages["全场亚洲盘及大小盘"]);
                jQuery(".fa_saurch_in").text(languages["H1058"]);
                jQuery("#je").text(languages["H1257"]);
                jQuery("#hy").text(languages["H1258"]);
                //jQuery("#level>option:eq(0)").text(languages["H1040"]);
//                jQuery("#level>option:eq(1)").text(languages["H1260"]);
//                jQuery("#level>option:eq(2)").text(languages["H1261"]+"4");
//                jQuery("#level>option:eq(3)").text(languages["H1261"]+"3");
//                jQuery("#level>option:eq(4)").text(languages["H1261"]+"2");
//                jQuery("#level>option:eq(5)").text(languages["H1261"]+"1");
                jQuery("#tz").text(languages["H1259"]);
                jQuery("#type>option:eq(0)").text(languages["H1040"]);
                jQuery("#type>option:eq(1)").text(languages["H1149"]);
                jQuery("#type>option:eq(2)").text(languages["H1150"]);
                jQuery("#type>option:eq(3)").text(languages["H1148"]);
                jQuery("#type>option:eq(4)").text(languages["H1152"]);
                jQuery("#type>option:eq(5)").text(languages["H1153"]);
                jQuery("#type>option:eq(6)").text(languages["H1151"]);
                jQuery("#type>option:eq(7)").text(languages["H1240"]);
                jQuery("#type>option:eq(8)").text(languages["H1241"]);
                jQuery("#type>option:eq(9)").text(languages["H1250"]);
                jQuery("#type>option:eq(10)").text(languages["H1242"]);
                jQuery("#type>option:eq(11)").text(languages["H1243"]);
                jQuery("#type>option:eq(12)").text(languages["H1251"]);
                jQuery("#leagueAll").val(languages["H1256"]);
                jQuery("#boll").val(languages["H1161"]);

                jQuery("#delet").attr("title", languages["H1256"]);
                jQuery("#qxqx").text(languages["H1166"]);
                jQuery("#xzls").text(languages["H1256"]);
                jQuery("#btnSure").val(languages["H1037"]);
                jQuery("#btnEsc").val(languages["H1011"]);

                jQuery("#delet1").attr("title", languages["H1161"]);
                jQuery("#qxqx1").text(languages["H1166"]);
                jQuery("#xzdz").text(languages["H1167"]);
                jQuery("#btnSure1").val(languages["H1037"]);
                jQuery("#btnEsc1").val(languages["H1011"]);


                jQuery("#excel").text(languages["H1233"] + "Excel");
                jQuery("#tjl").text(languages["H1029"]);
                jQuery("#tb2>thead>tr>th:eq(0)").text(languages["H1262"]);
                jQuery("#tb2>thead>tr>th:eq(1)").text(languages["H1170"]);
                jQuery("#tb2>thead>tr>th:eq(2)").text(languages["H1108"]);
                jQuery("#tb2>thead>tr>th:eq(3)").text(languages["H1259"]);
                jQuery("#tb2>thead>tr>th:eq(4)").text(languages["H1173"]);
                jQuery("#tb2>thead>tr>th:eq(5)").text(languages["H1171"]);
                jQuery("#tb2>thead>tr>th:eq(6)").text(languages["H1172"]);
                jQuery("#tb2>thead>tr>th:eq(7)").text(languages["H1263"]);
                jQuery("#tb2>thead>tr>th:eq(8)").text(languages["H1054"]);

            }, "/js/IndexGlobal/");
                switch (setLang) {
                    case "zh-cn":case "zh-CN":
                        jQuery("#language").val("cn")
                        break;
                    case "zh-tw":
                        jQuery("#language").val("tw")
                        break;
                    case "en-us":
                        jQuery("#language").val("en")
                        break;
                    default:
                        jQuery("#language").val("cn")
                        break;
                }
        }
        function setData(data) {
            jQuery.AjaxCommon("/ServicesFile/ReportService/NoteSingleService.asmx/GetAllTolength", data, true, false, function (json) {
                if (json.d != "none") {
                    if(json.d==olddata)
                    {
                        return;
                    }
                    olddata=json.d;
                    jQuery("#showInfo>tr").remove();
                    //alert(json.d);
                    var result = jQuery.parseJSON(json.d);
                    var arr=new Array();
                    var lan1=jQuery("#language").val();
                    jQuery.each(result, function (i) {
                        arr.push("<tr id='tr1'>");

                        arr.push("<td id='time'>");
                        arr.push(result[i].UserName + "<br/>" + result[i].OrderID + "<br/>" + result[i].time);
                        arr.push("</td>");

                        arr.push("<td id='league'>");
                        switch(lan1)
                        {
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
                        arr.push("</td>");
                        arr.push("<td id='BeginTime'>");
                        arr.push(""+result[i].BeginTime);
                        arr.push("</td>");

                        arr.push("<td id='BetType'>");
                        arr.push(typeList[parseInt(result[i].BetType)] + "<br/>" + (result[i].IsHalf == 1 ? languages["H1159"] : languages["H1160"]));
                        arr.push("</td>");

                        arr.push("<td id='Handicap'>");
                        arr.push(result[i].BetItem + "<span class='red'>@</span>"+ result[i].Handicap);
                        arr.push("</td>");

                        arr.push("<td id='Odds'>");
                        arr.push(result[i].Odds + "<br/>" + result[i].OddsType);
                        arr.push("</td>");

                         arr.push("<td id='ValidAmount'>");
                        arr.push(result[i].Amount + "<br/>" + result[i].ValidAmount);
                        arr.push("</td>");

                        arr.push("<td id=''>");
                        arr.push((parseFloat(result[i].ValidAmount) * parseFloat(result[i].CompanyPercent)).toFixed(2));
                        arr.push("<br>" + parseFloat(result[i].CompanyPercent).toFixed(2) + "<br>");
                        arr.push((parseFloat(result[i].ValidAmount) * parseFloat(result[i].CompanyPercent) * parseFloat(result[i].rate)).toFixed(2));
                        arr.push("</td>");

                        arr.push("<td id='WebSiteiID'>");
                        arr.push(result1[result[i].WebSiteiID][lan1] + "<br>" + result[i].IP);
                        arr.push("</td>");

                        arr.push("</tr>");
                       
                       
//                        var setLang = "";
//                        setLang = $.SetOrGetLanguage(setLang, function () {
//                            languages = language;
//                            tr.find("#BetType").html(typeList[parseInt(result[i].BetType)] + "&nbsp;&nbsp;&nbsp;&nbsp;" + (result[i].IsHalf == 1 ? languages["H1159"] : languages["H1160"]) + "<br/>" + result[i].BetItem);
//                        }, "/js/IndexGlobal/");
                        
                        
                       
                    });
                    $("#showInfo").html(arr.join("\n\r"));
                    jQuery("#tb2").alterBgColor({ odd: "odd", even: "even", selected: "selected", tdCss: "tdCss", istdClick: true });
                }
            });
        }
        function getCasino()
        {
            $.AjaxCommon("/ServicesFile/webBasicInfo/WebInfoService.asmx/GetDate", "", false, false, function (json1) {
                            if (json1.d != "none") {
                                var result = jQuery.parseJSON(json1.d);
                                $.each(result, function (j) {
                                    var arr=new Array();
                                    arr["tw"]=result[j].nametw;
                                    arr["cn"]=result[j].namecn;
                                    arr["en"]=result[j].nameen;
                                    arr["th"]=result[j].nameth;
                                    arr["vn"]=result[j].namevn;
                                    
                                    result1[result[j].id]=arr;

                                });
                            }
                        });
        }
        function setData3(data) {
            jQuery.AjaxCommon("/ServicesFile/ReportService/NoteSingleService.asmx/GetAllTolength", data, true, false, function (json) {
                if (json.d != "none") {
                    jQuery("#showInfo>tr").remove();
                    //alert(json.d);
                    var result = jQuery.parseJSON(json.d);
                    jQuery.each(result, function (i) {
                        var tr = jQuery("#tr1").clone();
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
                        tr.find("#BeginTime").html(""+result[i].BeginTime);
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
                        tr.appendTo("#showInfo");
                    });
                    jQuery("#tb2").alterBgColor({ odd: "odd", even: "even", selected: "selected", tdCss: "tdCss", istdClick: true });
                }
            });
        }

        function setLevel()
        {
            $.AjaxCommon("/ServicesFile/ReportService/NoteSingleService.asmx/GetUserLevel","language:'"+jQuery("#language").val()+"'",true,false,function(json){
                if(json.d != "none"){
                    var html = "";
                    var re = jQuery.parseJSON(json.d);
                    $.each(re,function(i){
                        html += "<option value=\""+re[i].a+"\">"+re[i].b+"</option>";
                    })
                    html = "<option value=\"0\">"+languages["H1040"]+"</option>"+html;
                    $("#level").html(html);
                }            
            });
        }

        var pd = 1;
        function Countdown(time) {
            $("#timeUp").text("" + time);
            if (parseInt(time) == 0) {
                var t = "";
                if ($("#timeHide").val() == "") {
                    $("#timeHide").val("20");
                    time = "20";
                }
                else {
                var a = /^([1-9]|[1-9][0-9])&/;
                    if (!a.test($("#timeHide").val())) {
                        time = "20";
                        $("#timeHide").val("20");
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
                <% if(searchAc) { %>
                var data = "length:'" + t + "',league:'" + leagueName + "',level:'" + jQuery("#level").val() + "',type:'" + jQuery("#type").val() + "',money:'" + jQuery("#money").val() + "',ballteam:'" + bollID + "',language:'" + jQuery("#language").val() + "'";
                <% } else { %>
                var data = "length:'" + t + "',league:'" + leagueName + "',level:'0',type:'-1',money:'',ballteam:'" + bollID + "',language:'" + jQuery("#language").val() + "'";
                <% } %>
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
                    time = "20";
                }
                else {
                    time = $("#timeHide").val();
                }
                pd = 0;
            }
            setTimeout("Countdown(\"" + time + "\")", 1000);
        }
    </script>
</head>
<body>
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="zd">注单明细</p></th>
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
    <% if (searchAc)
       { %>
<div class="fl">
<input id="leagueAll" type="button" value="选择联赛" />&nbsp;&nbsp;&nbsp;&nbsp;
    
    <input type="button" id="boll" value="选择球队" />&nbsp;&nbsp;&nbsp;&nbsp;
    <input type="text" value="" id="money" class="text_01 w_60" onmouseover="this.className='text_01_h w_60'" onmouseout="this.className='text_01 w_60'" /><a id="je">金额</a>&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="hy">会员级别</a>:<select id="level">
    </select>&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="tz">投注类型</a>:<select id="type">
    <option value="-1">全部</option>
    <option value="0">全场让球</option>
    <option value="1">全场大小</option>
    <option value="12">全场标准</option>
    <option value="2">半场让球</option>
    <option value="3">半场大小</option>
    <option value="13">半场标准</option>
    <option value="4">走地全场让球</option>
    <option value="5">走地全场大小</option>
    <option value="14">走地全场标准</option>
    <option value="6">走地半场让球</option>
    <option value="7">走地半场大小</option>
    <option value="15">走地半场标准</option>
    </select>&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in">查询</span></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</div>
<% } %>
<div class="fr">
<input type="text" id="timeTxt" value="20" class="text_01 w_30" onmouseover="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" /><label id="timeUp">5</label>&nbsp;&nbsp;&nbsp;&nbsp;
    <input type="text" value="50" id="DataLength" class="text_01 w_60" onmouseover="this.className='text_01_h w_60'" onmouseout="this.className='text_01 w_60'" /><a id="tjl">条记录</a>
</div>

</div>
    <table width="100%" class="tab2" id="tb2">
    <thead>
    <tr>
    <th>下注</th>
    <th>比赛</th>
    <th>开赛时间</th>
    <th>投注类型</th>
    <th>盘口</th>
    <th>赔率</th>
    <th>投注金额</th>
    <th>公司金额</th>
    <th>网站</th>
    </tr>
    </thead>
    <tbody id="showInfo" class="tc">
    
    </tbody>
    <tfoot>
    <tr id='tr1'>
    <td id='time'></td>
    <td id='league'></td>
    <td id='BeginTime'></td>
    <td id='BetType'></td>
    <td id='Handicap'></td>
    <td id="Odds"></td>
    <td id='ValidAmount'></td>
    <td id=''></td>
    <td id='WebSiteiID'></td>
    </tr>
    </tfoot>
    </table>
    </form>

    <div id="delet" title="选择联赛">
    <div id="leagueDiv" class="showdiv">
    <table width="100%">
    <thead>
    <tr><th align="left"><input type="checkbox" id="allLeague" /><a id="qxqx">全选/取消</a></th><th colspan="3" align="left"><a id="xzls">选择联赛</a></th></tr>
    </thead>
    <tbody id="tbody1">
    </tbody>
    </table>
    <div align="center" class="mtop_50">
<input type="button" class="btn_02" id="btnSure" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="确定" />
<input type="button" class="btn_02" id="btnEsc" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="取消" />
</div>
    </div>
    </div>


    <div id="delet1" title="选择球队" >
    <div id="againstDiv" class="showdiv">
    <table>
    <thead>
    <tr><th align="left"><input type="checkbox" id="againstAll" /><a id="qxqx1">全选/取消</a></th><th colspan="2" align="left"><a id="xzdz">选择对阵双方</a></th></tr>
    </thead>
    <tbody id="tbody2">
    </tbody>
    </table>
    <div align="center" class="mtop_50">
<input type="button" class="btn_02" id="btnSure1" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="确定" />
<input type="button" class="btn_02" id="btnEsc1" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="取消" />
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
