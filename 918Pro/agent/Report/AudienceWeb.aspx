<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="AudienceWeb.aspx.cs" Inherits="agent.Report.AudienceWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>全场亚洲盘&大小盘</title>
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
        var leagueName = "";
        var bollID = "";
        var data1 = "";
        var limi = "";
        var btype = "fl";
        var languages = "";

        function SetGlobal(setLang) {
            setLang = $.SetOrGetLanguage(setLang, function () {
                languages = language;
                jQuery("#nameP").text(languages["全场亚洲盘及大小盘"]);
                jQuery(".fa_saurch_in").text(languages["H1058"]);
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

                jQuery("#delet2").attr("title", languages["H1168"]);
                jQuery("#tjl1").text(languages["H1029"]);
                jQuery("#tb2>thead>tr>th:eq(0)").text(languages["H1026"]);
                jQuery("#tb2>thead>tr>th:eq(1)").text(languages["H1169"]);
                jQuery("#tb2>thead>tr>th:eq(2)").text(languages["H1284"]);
                jQuery("#tb2>thead>tr>th:eq(3)").text(languages["H1171"]);
                jQuery("#tb2>thead>tr>th:eq(4)").text(languages["H1172"]);
                jQuery("#tb2>thead>tr>th:eq(5)").text(languages["H1070"]);
                jQuery("#tb2>thead>tr>th:eq(6)").html("<p>" + languages["H1082"] + "</p><p>" + languages["H1285"] + "</p><p>" + languages["H1172"] + "</p><p>" + languages["H1286"] + "</p>");
                jQuery("#tb2>thead>tr>th:eq(7)").html("<p>" + languages["H1287"] + "</p><p>" + languages["H1285"] + "</p><p>" + languages["H1172"] + "</p><p>" + languages["H1286"] + "</p>");
                jQuery("#tb2>thead>tr>th:eq(8)").html("<p>" + languages["H1228"] + "</p><p>" + languages["H1285"] + "</p><p>" + languages["H1172"] + "</p><p>" + languages["H1286"] + "</p>");
                jQuery("#tb2>thead>tr>th:eq(9)").html("<p>" + languages["H1227"] + "</p><p>" + languages["H1285"] + "</p><p>" + languages["H1172"] + "</p><p>" + languages["H1286"] + "</p>");
                //jQuery("#tab2>thead>tr>th:eq(10)").text();
                jQuery("#closeButton").val(languages["H1039"]);


                jQuery("#excel").text(languages["H1233"] + " Excel");
                jQuery("#tjl").text(languages["H1029"]);
                jQuery("#tab2>thead>tr>th:eq(0)").text(languages["H1056"]);
                jQuery("#tab2>thead>tr>th:eq(1)").text(languages["H1266"]);
                jQuery("#tab2>thead>tr>th:eq(2)").text(languages["H1271"]);
                jQuery("#tab2>thead>tr>th:eq(3)").text(languages["H1272"]);
                jQuery("#tab2>thead>tr>th:eq(4)").text(languages["H1282"]);
                jQuery("#tab2>thead>tr>th:eq(5)").text(languages["H1273"]);
                jQuery("#tab2>thead>tr>th:eq(6)").text(languages["H1274"]);
                jQuery("#tab2>thead>tr>th:eq(7)").text(languages["H1283"]);

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
                languages = jQuery("#language").val();
                setData();

            }, "/js/IndexGlobal/");

        }

        jQuery(function () {
            SetGlobal("");
            jQuery("#delet").hide();
            jQuery("#delet1").hide();
            jQuery("#delet2").hide();
            Countdown(jQuery("#timeTxt").val());
            $("#delet2").bind("dialogclose", function (event, ui) {
                div = 0;
            });
            jQuery("#closeButton").click(function () {
                div = 0;
                jQuery("#delet2").dialog("close");
            });
            /*-------------联赛信息-------------*/
            jQuery("#leagueAll").click(function () {
                var dataleague = "language:'" + jQuery("#language").val() + "'";
                jQuery.AjaxCommon("/ServicesFile/ReportService/NoteSingleService.asmx/GetLeagueToJson", dataleague, true, false, function (json) {
                    if (json.d != "none") {
                        var tr = "<tr>";
                        jQuery("#tbody2").html("");
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
                jQuery("#delet").dialog({ width: 1000, modal: true });
                jQuery("#delet").dialog({ modal: true });
                jQuery("#allLeague").attr("checked", "checked");
                //确定按钮
                jQuery("#btnSure").unbind("click");
                jQuery("#btnSure").click(function () {
                    leagueName = "";
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
                    setData();
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
            /*--------------球队信息-----------------*/
            jQuery("#boll").click(function () {
                var databoll = "language:'" + jQuery("#language").val() + "'";
                jQuery.AjaxCommon("/ServicesFile/ReportService/NoteSingleService.asmx/GetBollToJson", databoll, true, false, function (json) {
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
                jQuery("#delet1").dialog({ width: 800, modal: true });
                jQuery("#delet1").dialog({ modal: true });
                jQuery("#againstAll").attr("checked", "checked");
                //确定按钮
                jQuery("#btnSure1").unbind("click");
                jQuery("#btnSure1").click(function () {
                    leagueName = "";
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
                    setData();
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
                setData();
            });

            //            jQuery("#DataLength").keyup(function () {
            //                if (isNaN($(this).val())) {
            //                    alert(languages.H1435);
            //                    $("#DataLength").val("").focus();
            //                } else {
            //                    setData();
            //                }
            //            });
        })

        function setData() {
            limi = jQuery("#DataLength").val();
            var data = "language:'" + languages + "',league:'" + leagueName + "',gameId:'" + bollID + "',limi:'" + limi + "',btype:'" + btype + "'";
            jQuery.AjaxCommon("/ServicesFile/ReportService/NoteSingleService.asmx/GetHdpAndOu", data, true, false, function (json) {
                if (json.d != "none") {
                    jQuery("#showInfo>tr").remove();
                    var league = "";
                    var r = $.parseJSON(json.d);
                    $.each(r, function (i) {
                        var re = r[i];
                        if (r[i].league != league) {
                            league = re.league;
                            tr = jQuery("#leaguetr").clone();
                            tr.attr("class", "tl");
                            tr.html("<td colspan=\"14\" align=\"left\" style=\"background-color:#DCF0FD\">" + re.league + "</td>");
                            tr.appendTo("#showInfo");
                        }
                        tr = jQuery("#leagueInfo").clone();
                        tr.attr("class", "tc");
                        tr.attr("attr", "" + re.gameid);
                        tr.find("#time").html((re.begintime).substr(5) + "<input type=\"hidden\" value=\"" + re.begintime + "\" />");
                        tr.find("#team").html(re.Home + "&nbsp;&nbsp;-VS-&nbsp;&nbsp;" + re.Away);
                        tr.find("#AllHmoney").text(re.homefeef == "" ? "--" : parseInt(re.homefeef));
                        tr.find("#AllAmoney").text(re.awayfeef == "" ? "--" : parseInt(re.awayfeef));
                        tr.find("#AllHAsum").html("" + (parseInt(re.homefeef == "" ? "0" : re.homefeef) + parseInt(re.awayfeef == "" ? "0" : re.awayfeef)));
                        tr.find("#AllOmoney").text(re.bigfeef == "" ? "--" : parseInt(re.bigfeef));
                        tr.find("#AllUmoney").text(re.smallfeef == "" ? "--" : parseInt(re.smallfeef));
                        tr.find("#AllOUsum").html("" + (parseInt(re.bigfeef == "" ? "0" : re.bigfeef) + parseInt(re.smallfeef == "" ? "0" : re.smallfeef)));
                        tr.appendTo("#showInfo");
                    });
                    if(jQuery("#showInfo>tr").length <= 0) {
                        var tr = jQuery("#leagueInfo").clone();
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            tr.html("<td colspan=\"14\" align=\"left\" style=\"background-color:#DCF0FD\">" + languages["H1013"] + "</td>");
                        }, "/js/IndexGlobal/");
                        tr.appendTo("#showInfo");
                    }
                    //全场让球and走地全场让球 主队
                    jQuery("#showInfo>tr").find("#AllHmoney").unbind("click");
                    jQuery("#showInfo>tr").find("#AllHmoney").click(function () {
                        if (jQuery(this).text() == "--") return false;
                        jQuery("#delet2").dialog({ width: 1000, modal: true });
                        jQuery("#delet2").dialog({ modal: true });
                        var data = "table1:'orderdetailhdp',table2:'orderdetailhdpl',type:'H',game:'" + jQuery(this).parent().attr("attr") + "'";
                        repo(data, "主");
                        div = 1;
                        Countdown1(jQuery("#timeTxt1").val(), data, "主");
                    });
                    //全场让球and走地全场让球 客队
                    jQuery("#showInfo>tr").find("#AllAmoney").unbind("click");
                    jQuery("#showInfo>tr").find("#AllAmoney").click(function () {
                        if (jQuery(this).text() == "--") return false;
                        jQuery("#delet2").dialog({ width: 1000, modal: true });
                        jQuery("#delet2").dialog({ modal: true });
                        var data = "table1:'orderdetailhdp',table2:'orderdetailhdpl',type:'A',game:'" + jQuery(this).parent().attr("attr") + "'";
                        repo(data, "客");
                        div = 1;
                        Countdown1(jQuery("#timeTxt1").val(), data, "客");
                    });
                    //全场大小and走地全场大小 大
                    jQuery("#showInfo>tr").find("#AllOmoney").unbind("click");
                    jQuery("#showInfo>tr").find("#AllOmoney").click(function () {
                        if (jQuery(this).text() == "--") return false;
                        jQuery("#delet2").dialog({ width: 1000, modal: true });
                        jQuery("#delet2").dialog({ modal: true });
                        var data = "table1:'orderdetailou',table2:'orderdetailoul',type:'O',game:'" + jQuery(this).parent().attr("attr") + "'";
                        repo(data, "大");
                        div = 1;
                        Countdown1(jQuery("#timeTxt1").val(), data, "大");
                    });
                    //全场大小and走地全场大小 小
                    jQuery("#showInfo>tr").find("#AllUmoney").unbind("click");
                    jQuery("#showInfo>tr").find("#AllUmoney").click(function () {
                        if (jQuery(this).text() == "--") return false;
                        jQuery("#delet2").dialog({ width: 1000, modal: true });
                        jQuery("#delet2").dialog({ modal: true });
                        var data = "table1:'orderdetailou',table2:'orderdetailoul',type:'U',game:'" + jQuery(this).parent().attr("attr") + "'";
                        repo(data, "小");
                        div = 1;
                        Countdown1(jQuery("#timeTxt1").val(), data, "小");
                    });
                }
            });
        }

        /*------------注单明细--------------*/
        function repo(data, type) {
            jQuery.AjaxCommon("/ServicesFile/ReportService/NonStandardService.asmx/GetDataByType", data, true, false, function (json) {
                if (json.d != "none") {
                    jQuery("#reportInfo>tr").remove();
                    var result = jQuery.parseJSON(json.d);
                    jQuery.each(result, function (i) {
                        var tr = jQuery("#tr1").clone();
                        tr.find("#ID").text("" + (i + 1));
                        tr.find("#UserNameTD").html("" + result[i].UserName + "<br/>" + result[i].OrderID + "<br/>" + result[i].time);
                        if (jQuery("#language").val() == "tw") {
                            var setLang = "";
                            setLang = $.SetOrGetLanguage(setLang, function () {
                                languages = language;
                                tr.find("#teamTD").html((type.length == 1 ? type : type.substr(1)) + "<br/>" + (type.length == 1 ? (type == "主" || type == "客" ? languages["H1159"] + "&nbsp;&nbsp;&nbsp;" + languages["H1157"] : languages["H1159"] + "&nbsp;&nbsp;&nbsp;" + languages["H1279"]) : (type.substr(1) == "主" || type.substr(1) == "客" ? languages["H1160"] + "&nbsp;&nbsp;&nbsp;" + languages["H1157"] : languages["H1160"] + "&nbsp;&nbsp;&nbsp;" + languages["H1279"])) + "<br/>" + result[i].Hometw + "&nbsp;-VS-&nbsp;" + result[i].Awaytw + "<br/>" + result[i].leaguetw + "&nbsp;&nbsp;@&nbsp;&nbsp;" + result[i].BeginTime);
                            }, "/js/IndexGlobal/");
                        }
                        else if (jQuery("#language").val() == "cn") {
                            var setLang = "";
                            setLang = $.SetOrGetLanguage(setLang, function () {
                                languages = language;
                                tr.find("#teamTD").html((type.length == 1 ? type : type.substr(1)) + "<br/>" + (type.length == 1 ? (type == "主" || type == "客" ? languages["H1159"] + "&nbsp;&nbsp;&nbsp;" + languages["H1157"] : languages["H1159"] + "&nbsp;&nbsp;&nbsp;" + languages["H1279"]) : (type.substr(1) == "主" || type.substr(1) == "客" ? languages["H1160"] + "&nbsp;&nbsp;&nbsp;" + languages["H1157"] : languages["H1160"] + "&nbsp;&nbsp;&nbsp;" + languages["H1279"])) + "<br/>" + result[i].Homecn + "&nbsp;-VS-&nbsp;" + result[i].Awaycn + "<br/>" + result[i].leaguecn + "&nbsp;&nbsp;@&nbsp;&nbsp;" + result[i].BeginTime);
                            }, "/js/IndexGlobal/");
                        }
                        else if (jQuery("#language").val() == "en") {
                            var setLang = "";
                            setLang = $.SetOrGetLanguage(setLang, function () {
                                languages = language;
                                tr.find("#teamTD").html((type.length == 1 ? type : type.substr(1)) + "<br/>" + (type.length == 1 ? (type == "主" || type == "客" ? languages["H1159"] + "&nbsp;&nbsp;&nbsp;" + languages["H1157"] : languages["H1159"] + "&nbsp;&nbsp;&nbsp;" + languages["H1279"]) : (type.substr(1) == "主" || type.substr(1) == "客" ? languages["H1160"] + "&nbsp;&nbsp;&nbsp;" + languages["H1157"] : languages["H1160"] + "&nbsp;&nbsp;&nbsp;" + languages["H1279"])) + "<br/>" + result[i].Homeen + "&nbsp;-VS-&nbsp;" + result[i].Awayen + "<br/>" + result[i].leagueen + "&nbsp;&nbsp;@&nbsp;&nbsp;" + result[i].BeginTime);
                            }, "/js/IndexGlobal/");
                        }
                        else if (jQuery("#language").val() == "th") {
                            var setLang = "";
                            setLang = $.SetOrGetLanguage(setLang, function () {
                                languages = language;
                                tr.find("#teamTD").html((type.length == 1 ? type : type.substr(1)) + "<br/>" + (type.length == 1 ? (type == "主" || type == "客" ? languages["H1159"] + "&nbsp;&nbsp;&nbsp;" + languages["H1157"] : languages["H1159"] + "&nbsp;&nbsp;&nbsp;" + languages["H1279"]) : (type.substr(1) == "主" || type.substr(1) == "客" ? languages["H1160"] + "&nbsp;&nbsp;&nbsp;" + languages["H1157"] : languages["H1160"] + "&nbsp;&nbsp;&nbsp;" + languages["H1279"])) + "<br/>" + result[i].Hometh + "&nbsp;-VS-&nbsp;" + result[i].Awayth + "<br/>" + result[i].leagueth + "&nbsp;&nbsp;@&nbsp;&nbsp;" + result[i].BeginTime);
                            }, "/js/IndexGlobal/");
                        }
                        else if (jQuery("#language").val() == "vn") {
                            var setLang = "";
                            setLang = $.SetOrGetLanguage(setLang, function () {
                                languages = language;
                                tr.find("#teamTD").html((type.length == 1 ? type : type.substr(1)) + "<br/>" + (type.length == 1 ? (type == "主" || type == "客" ? languages["H1159"] + "&nbsp;&nbsp;&nbsp;" + languages["H1157"] : languages["H1159"] + "&nbsp;&nbsp;&nbsp;" + languages["H1279"]) : (type.substr(1) == "主" || type.substr(1) == "客" ? languages["H1160"] + "&nbsp;&nbsp;&nbsp;" + languages["H1157"] : languages["H1160"] + "&nbsp;&nbsp;&nbsp;" + languages["H1279"])) + "<br/>" + result[i].Homevn + "&nbsp;-VS-&nbsp;" + result[i].Awayvn + "<br/>" + result[i].leaguevn + "&nbsp;&nbsp;@&nbsp;&nbsp;" + result[i].BeginTime);
                            }, "/js/IndexGlobal/");
                        }
                        tr.find("#Odds").html("" + result[i].Odds);
                        tr.find("#AmountTD").html("" + parseInt(result[i].Amount) + "<br/>" + parseInt(result[i].ValidAmount));
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            tr.find("#StatusTD").html(languages["H1469"]);
                        }, "/js/IndexGlobal/");
                        tr.find("#agent").html("" + (result[i].AgentPercent * 100) + "%<br/>" + (result[i].Amount * result[i].AgentPercent) + "<br/>" + (result[i].Odds < 0 ? (result[i].Amount * result[i].AgentPercent) : (result[i].Amount * result[i].AgentPercent * result[i].Odds)));
                        tr.find("#zagent").html("" + (result[i].ZAgentPercent * 100) + "%<br/>" + (result[i].Amount * result[i].ZAgentPercent) + "<br/>" + (result[i].Odds < 0 ? (result[i].Amount * result[i].ZAgentPercent) : (result[i].Amount * result[i].ZAgentPercent * result[i].Odds)));
                        tr.find("#partner").html("" + (result[i].PartnerPercent * 100) + "%<br/>" + (result[i].Amount * result[i].PartnerPercent) + "<br/>" + (result[i].Odds < 0 ? (result[i].Amount * result[i].PartnerPercent) : (result[i].Amount * result[i].PartnerPercent * result[i].Odds)));
                        tr.find("#subCompany").html("" + (result[i].SubCompanyPercent * 100) + "%<br/>" + (result[i].Amount * result[i].SubCompanyPercent) + "<br/>" + (result[i].Odds < 0 ? (result[i].Amount * result[i].SubCompanyPercent) : (result[i].Amount * result[i].SubCompanyPercent * result[i].Odds)));
                        tr.find("#IPTD").html("" + result[i].IP);
                        tr.appendTo("#reportInfo");
                    });
                }
            });
        }
        /*------------注单明细结束----------*/

        /*------------自动刷新-------------*/
        var pd = 1;
        function Countdown(time) {
            $("#timeUp").text("" + time);
            if (parseInt(time) == 0) {
                var t = "";
                if ($("#timeHide").val() == "") {
                    $("#timeHide").val("60");
                    time = "60";
                }
                else {
                    var a = /^([1-9]|[1-9][0-9])&/;
                    if (!a.test($("#timeHide").val())) {
                        time = "60";
                        $("#timeHide").val("60");
                    } 
                    else {
                        time = $("#timeHide").val();
                    }
                }
                setData();
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
                    time = "60";
                }
                else {
                    time = $("#timeHide").val();
                }
                pd = 0;
            }
            setTimeout("Countdown(\"" + time + "\")", 1000);
        }
        /*------------自动刷新结束-------------*/

        /*------------自动刷新1-------------*/
        var pd1 = 1;
        var div = 1;
        function Countdown1(time, data, type) {
            $("#timeUp1").text("" + time);
            if (parseInt(time) == 0) {
                var t = "";
                if ($("#timeHide1").val() == "") {
                    $("#timeHide1").val("60");
                    time = "60";
                }
                else {
                    var a = /^([1-9]|[1-9][0-9])&/;
                    if (!a.test($("#timeHide1").val())) {
                        time = "60";
                        $("#timeHide1").val("60");
                    }
                    else {
                        time = $("#timeHide1").val();
                    }
                }
                repo(data, type);
                if ($("#timeHide1").val() != $("#timeTxt1").val()) {
                    if (parseInt($("#timeTxt1").val()) < 5) {
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            alert(languages["H1255"]);
                        }, "/js/IndexGlobal/");
                        $("#timeTxt1").val("" + $("#timeHide1").val());
                    }
                    $("#timeHide1").val("" + $("#timeTxt1").val());
                    pd = 1;
                }
            }
            else {
                time = parseInt(time) - 1;
            }

            if (pd1) {
                if ($("#timeHide1").val() == "") {
                    time = "60";
                }
                else {
                    time = $("#timeHide1").val();
                }
                pd1 = 0;
            }
            if (div) {
                setTimeout("Countdown1(\"" + time + "\",\"" + data + "\",\"" + type + "\")", 1000);
            }
        }
        /*------------自动刷新1结束-------------*/

        function setExcel(divId, hidenId) {
            jQuery("#" + hidenId).val(jQuery("#" + divId).html());
            jQuery("#nameValue").val(jQuery("#nameP").text());
            return true;
        }
    </script>
</head>
<body>
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="nameP">全场亚洲盘&大小盘</p></th>
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
    <!-- 查询条件选择DIV -->
    <% if (searchAc || excelAc)
       { %>
<div class="fl">
<% if (searchAc)
   { %>
<input id="leagueAll" type="button" value="选择联赛" />&nbsp;&nbsp;&nbsp;&nbsp;
    <input type="button" id="boll" value="选择球队" />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in">搜索</span></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <% } %>
    <% if (excelAc)
       { %>
    <asp:LinkButton runat="server" ID="excel" 
        OnClientClick="return setExcel('divExcel','hfContent')" Text="导出Excel" 
        onclick="excel_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
    <% } %>
</div>
<% } %>
<!-- 查询条件选择DIV结束 -->
<input type="hidden" runat="server" id="hfContent" />
<input type="hidden" runat="server" id="nameValue" />
<!-- 自动刷新DIV -->
<div class="fr">
<input type="text" id="timeTxt" value="60" class="text_01 w_30" onmouseover="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" /><label id="timeUp">60</label>&nbsp;&nbsp;&nbsp;&nbsp;
<input type="text" value="50" maxlength="3" id="DataLength" class="text_01 w_60" onmouseover="this.className='text_01_h w_60'" onmouseout="this.className='text_01 w_60'" /><a id="tjl">条记录</a>
    
</div>
<!-- 自动刷新DIV结束 -->

</div>
<!-- 数据显示TABLE -->
<div id="divExcel">
    <table width="100%" id="tab2" class="tab2">
    <thead>
    <tr align="center">
    <th>时间</th>
    <th>队伍</th>
    <th>主</th>
    <th>客</th>
    <th>亚洲盘总和</th>
    <th>大</th>
    <th>小</th>
    <th>大小盘总和</th>
    </tr>
    </thead>
    <tbody id="showInfo">
    
    </tbody>
    <tfoot>
    <tr id="leaguetr"></tr>
    <tr id="leagueInfo">
    <td id="time"></td>
    <td id="team"></td>
    <td id="AllHmoney"></td>
    <td id="AllAmoney"></td>
    <td id="AllHAsum"></td>
    <td id="AllOmoney"></td>
    <td id="AllUmoney"></td>
    <td id="AllOUsum"></td>
    </tr>
    </tfoot>
    </table>
    </div>
    </form>
    <!-- 数据显示TABLE结束 -->

    <!-- 联赛选择DIV -->
    <div id="delet" title="选择联赛">
    <div id="leagueDiv" class="showdiv">
    <table width="100%">
    <thead>
    <tr><th align="left"><input type="checkbox" id="allLeague" /><a id="qxqx">全选/取消</a></th><th colspan="3" align="left" id="xzls">选择联赛</th></tr>
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
    <!-- 联赛选择DIV结束 -->


    <!-- 球队选择DIV -->
    <div id="delet1" title="选择球队" >
    <div id="againstDiv" class="showdiv">
    <table>
    <thead>
    <tr><th align="left"><input type="checkbox" id="againstAll" /><a id="qxqx1">全选/取消</a></th><th colspan="2" align="left" id="xzdz">选择对阵双方</th></tr>
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
    <!-- 球队选择DIV结束 -->

    <!-- 注单详细DIV -->
    <div id="delet2" title="注单明细">

    <div id="reportDiv" class="showdiv">
    <div class=" h30">
    <!-- 查询条件选择DIV -->
<div class="fl">
</div>
<!-- 查询条件选择DIV结束 -->

<!-- 自动刷新DIV -->
<div class="fr">
<input type="text" id="timeTxt1" value="5" class="text_01 w_30" onmouseover="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" /><label id="timeUp1">5</label>&nbsp;&nbsp;&nbsp;&nbsp;
<input type="text" value="50" id="DataLength1" class="text_01 w_60" onmouseover="this.className='text_01_h w_60'" onmouseout="this.className='text_01 w_60'" /><a id="tjl1">条记录</a>
<input type="hidden" value="" id="timeHide1" />
</div>
<!-- 自动刷新DIV结束 -->

</div>
    <table width="100%" id="tb2" class="tab2">
    <thead>
    <tr>
    <th>序号</th>
    <th>资讯</th>
    <th>选择</th>
    <th>赔率</th>
    <th>投注金额</th>
    <th>状态</th>
    <th><p>代理</p><p>占成数</p><p>投注金额</p><p>风险</p></th>
    <th><p>总代理</p><p>占成数</p><p>投注金额</p><p>风险</p></th>
    <th><p>股东</p><p>占成数</p><p>投注金额</p><p>风险</p></th>
    <th><p>分公司</p><p>占成数</p><p>投注金额</p><p>风险</p></th>
    <th>IP</th>
    </tr>
    </thead>
    <tbody id="reportInfo"></tbody>
    <tfoot>
    <tr id="tr1">
    <td id="ID"></td>
    <td id="UserNameTD"></td>
    <td id="teamTD"></td>
    <td id="Odds"></td>
    <td id="AmountTD"></td>
    <td id="StatusTD"></td>
    <td id="agent"></td>
    <td id="zagent"></td>
    <td id="partner"></td>
    <td id="subCompany"></td>
    <td id="IPTD"></td>
    </tr>
    </tfoot>
    </table>
    <div align="center" class="mtop_50">
<input type="button" class="btn_02" id="closeButton" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="关闭" />
</div>
</div>
    </div>
    <!-- 注单详细DIV结束 -->
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
