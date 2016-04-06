<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AffVerifyWithDrawal.aspx.cs" Inherits="admin.Bank.AffVerifyWithDrawal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>代理提款审核</title>
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="/js/page/pageJs.js" type="text/javascript"></script>
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="/js/jQueryCommon.js" type="text/javascript"></script>
    <script src="/js/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
    <script src="/js/webBasicInfo/zh-CN.js" type="text/javascript"></script>
    <link href="/css/Default/cupertino/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #refuseDepoist{display:none;}
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


        var currID = "";
        var typeList;
        var bankArr = new Array;
        var langu = $.cookie("lan"), lan = "";
        switch (langu) {
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
        var result1 = new Array();
        $(function () {
            SetGlobal("");
            getCasino();
            GetBanklist();
            jQuery("#language").val(lang);
            GetBankArr();
            SelectByWhere();
            Countdown(jQuery("#timeTxt").val());
            jQuery("#time1WhereVal").datepicker();
            $('#time1WhereVal').val();
            jQuery("#time2WhereVal").datepicker();
            $('#time2WhereVal').val();
            $("#selectByWhere").click(function () {
                if ($.trim($("#memberSel").val()) != "" || $.trim($("#memberName").val()) != "" || $("#time1WhereVal").val() != "" || $("#time2WhereVal").val() != "") {
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
            $("#withdrawalHistory").click(function () {
                location = "/Bank/WithDrawalHistory.aspx";
            });
            $("#VerifyWithDrawal").click(function () {
                location = "/Bank/VerifyWithDrawal.aspx";
            });
        });

        var languages = "";
        var lang;
        function SetGlobal(setLang) {

            setLang = $.SetOrGetLanguage(setLang, function () {
                languages = language;
                typeList = new Array();
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
            });
            lang = setLang;
        }
        var re = "";
        function SelectByWhere() {
            $.AjaxCommon("/ServicesFile/agentservers.asmx/GetAgentWithdrawal0", "username:'" + $.trim($("#memberSel").val()) + "',name:'" + $.trim($("#memberName").val()) + "',time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',type:'1',status:'0'", true, false, function (json) {
                if (json.d == "-1") {
                    SysLoginOut();
                } else if (json.d != "]") {
                    re = jQuery.parseJSON(json.d);
                    var html = "", total1 = 0;
                    $.each(re, function (i) {
                        total1 += parseFloat(re[i].tamount);
                        html += "<tr><td>" + (i + 1) + "</td><td>" + re[i].username + "</td><td>" + re[i].name + "</td><td>" + re[i].rolename + "</td><td>" + "RMB" + "</td><td class='red'>" + re[i].tamount + "</td><td>" + re[i].times + "</td><td>" + re[i].cardno + "</td><td><a class=\"verify\" href=\"#\" attr=\"" + re[i].id + "\">审核</a></td></tr>";
                    });
                    html += "<tr><td>总计</td><td colspan='3'></td><td>" + total1.toFixed(2) + "</td><td colspan='5'></td></tr>";
                    $("#tab1>tbody").html(html);
                    $("#tab1>tbody>tr").mouseover(function () {
                        $(this).siblings().removeClass("trOver").end().addClass("trOver");
                    });
                    $(".verify").unbind("click").bind("click", function () {
                        $("#outfee").val("0.00");
                        currID = $(this).attr("attr");
                        var $tr = $(this).parent().parent().find("td");
                        var iii = $tr.eq(0).html() - 1;

                        $("#userAccount").html(re[iii].username);
                        $("#nicheng").html(re[iii].name);
                        $("#regtime").html(re[iii].times);
                        $("#lastlogintime").html(re[iii].city);
                        $("#tel").html(re[iii].tel);
                        $("#email").html(re[iii].email);
                        $("#userName").html(re[iii].bankname);
                        $("#cardNo").html(re[iii].cardno);
                        $("#type").html(re[iii].bank);
                        $("#city").html(re[iii].Ghbndk);
                        $("#branch").html(re[iii].Branch);

                        $("#currency").html("RMB");
                        $("#balance").html(re[iii].amount);
                        $("#money").html(re[iii].tamount);

                        $("#verify_list").dialog({ modal: true, width: "530px" });
//                        var selectHtm = "";
//                        $.each(bankList, function (i) {
//                            selectHtm += "<option value='" + bankList[i].ID + "' ";
//                            if (bankList[i].nameth == "客户提款卡") {
//                                selectHtm += " selected ";
//                            }
//                            selectHtm += ">" + bankList[i].nameth + "</option>";
//                        });
//                        $("#bankout").html(selectHtm);
                    });
                } else {
                    $("#tab1>tbody").html("<tr><td colspan=\"8\">没有相应数据</td></tr>");
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

        var bankList;
        function GetBanklist() {
            var url = "/ServicesFile/BankService/BankService.asmx/GetBanklistc1";
            var data = "type:''";
            $.AjaxCommon(url, data, true, false, function (json) {
                bankList = $.parseJSON(json.d);
            });
        }

        function acceptBtn() {
            //            var url = "/ServicesFile/BankService/BankService.asmx/IsWithDrawal";
            //            var data = "userName:'" + jQuery.trim($("#userAccount").html()) + "'";
            //            $.AjaxCommon(url, data, true, false, function (json) {
            //                if (json.d) {
            //                    alert("审核失败！该会员今天提款超过一次！");
            //                } else {
            if (confirm("您确定要接受该代理提款吗?")) {
                $("#AcceptBtn").attr("disabled", true);
                var url = "/ServicesFile/agentservers.asmx/UpdateWithdrawal";
                var data = "ID:" + currID + ",amount:" + $("#money").html() + ",status:'2',mark:''";
                $.AjaxCommon(url, data, true, false, function (json) {
                    if (json.d == "1") {
                        var re = jQuery.parseJSON(json.d);
                        //alert("审核成功\n当前帐户余额：" + (parseFloat(re.a)) + "\n本次提款金额：" + re.c + "");
                        alert("审核成功")
                        $("#verify_list").dialog("close");
                        SelectByWhere();
                    } else if (json.d == "-1") {
                        SysLoginOut();
                    } else {
                        alert("审核失败");
                    }
                    $("#AcceptBtn").attr("disabled", false);
                });
            }
            //}
            //});
        }
        function refuseBtn() {
            getReson();
            $("#refuseDepoist").dialog({ modal: false, resizable: false });
            $("#submitBtn").unbind("click").bind("click", function () {
                if (confirm("您确定要拒绝该代理提款吗?")) {
                    if ($.trim($("#reason").val()) == "") {
                        alert("拒绝理由不能为空");
                    } else {
                        $("#submitBtn").attr("disabled", true);
                        var url = "/ServicesFile/agentservers.asmx/UpdateWithdrawal";
                        var data = "ID:" + currID + ",amount:" + $("#money").html() + ",status:'3',mark:'" + $("#reason option :selected").text() + "'";
                        $.AjaxCommon(url, data, true, false, function (json) {
                            if (json.d == "1") {
                                var re = jQuery.parseJSON(json.d);
                                //alert("审核成功\n当前帐户余额：" + re.a + "");
                                alert("审核成功");
                                $("#verify_list").dialog("close");
                                SelectByWhere();
                                $("#refuseDepoist").dialog("close");
                            } else if (json.d == "-1") {
                                SysLoginOut();
                            } else {
                                alert("审核失败");
                                $("#refuseDepoist").dialog("close");
                            }
                            $("#submitBtn").attr("disabled", false);
                        });
                    }
                }
            });
            $("#cancelBtn").unbind("click").bind("click", function () {
                $("#refuseDepoist").dialog("close");
            });
        }
        function escBtn() {
            $("#verify_list").dialog("close");
        }

        function getUserInfo(userName) {
            var data = "userName:'" + userName + "'";
            $.AjaxCommon("/ServicesFile/UserService.asmx/GetUserInfo", data, true, false, function (json) {
                if (json.d != "") {
                    var result = jQuery.parseJSON(json.d);
                    $.each(result, function (i) {
                        $("#userAccount").html("<a href='javascript:void(0)' style='color:#0075a9;' onclick=\"window.open('/Statistics/UserAnalysis.aspx?u=" + result[i].UserName + "','','width='+(window.screen.availWidth-10)+',height='+(window.screen.availHeight-30)+ ',top=0,left=0,resizable=yes,status=yes,menubar=no,scrollbars=yes');\">" + result[i].UserName + "</a>");
                        $("#nicheng").html(result[i].nicheng == "" ? "--" : result[i].nicheng);
                        $("#regtime").html(result[i].RegistrationTime == "" ? "--" : result[i].RegistrationTime);
                        $("#lastlogintime").html(result[i].LastLoginTime == "" ? "--" : result[i].LastLoginTime);
                        $("#tel").html(result[i].tel == "" ? "--" : result[i].tel);
                        $("#email").html(result[i].email == "" ? "--" : result[i].email);
                        $("#balance").html(result[i].Balance == "" ? "--" : result[i].Balance);
                        $("#validAmount").html(result[i].validAmount == "" ? "--" : result[i].validAmount);
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
        function GetOH(data) {
            $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/GetOrderHistory", "userName:'" + data + "'", true, false, function (json) {
                if (json.d != "none") {
                    jQuery("#ohTbodyUser>tr").remove();
                    var Sequence = 0;
                    var result = jQuery.parseJSON(json.d);
                    var total1 = 0, total2 = 0, total3 = 0;
                    jQuery.each(result, function (i) {
                        Sequence++;
                        total1 += parseFloat(result[i].Amount);
                        total2 += parseFloat(result[i].ValidAmount);
                        total3 += parseFloat(result[i].Result);
                        tr = jQuery("#ohTrUser").clone();
                        tr.find("#ohSequenceId").html(Sequence);
                        var time = result[i].BeginTime;
                        tr.find("#ohInformation").html(result[i].UserName + "<br/>足球<br/>" + result[i].time);
                        tr.find("#ohDetailBetType").html("<font color=red>" + result[i].BetItem + "@" + result[i].Handicap + "</font><br>" + typeList[parseInt(result[i].BetType)] + "<br><font color=blue>" + result[i].Home + " -vs- " + result[i].Away + "</font><br>" + result[i].league + "@" + time);
                        tr.find("#ohOdds").html(result[i].Odds + "<br>" + result[i].OddsType);
                        tr.find("#ohAmount").html(result[i].Amount + "<br/> <Label style=\"color:#A4A49D\">" + result[i].ValidAmount + "<Label/>");
                        var y = "";
                        if (parseFloat(result[i].Result) > 0) {
                            y = "赢 ";
                        } else {
                            y = "输";
                        }
                        tr.find("#ohStatus").html(y + "<br/> HT " + result[i].Scorehalf + "<br/> FT " + result[i].Score);
                        tr.find("#ohResultTd").html(y + "<br/> " + Math.abs(result[i].Result));
                        tr.find("#ohPercentes").html(parseFloat(result[i].SubCompanyPercent * 100).toFixed(2) + " %<br/>" + parseFloat(result[i].PartnerPercent * 100).toFixed(2) + " %<br/>" + parseFloat(result[i].ZAgentPercent * 100).toFixed(2) + " %<br/>" + parseFloat(result[i].AgentPercent * 100).toFixed(2) + " %");
                        tr.find("#ohIP").html(result[i].IP);
                        tr.appendTo("#ohTbodyUser");
                    });
                    $("#ohTbodyUser").append("<tr><td>总计</td><td colspan=\"3\"></td><td>" + total1.toFixed(2) + "<br/>" + total2.toFixed(2) + "</td><td></td><td>" + (total3 > 0 ? "赢" : (total3.toFixed(2) == 0.00 ? "平" : "输")) + "<br/>" + total3.toFixed(2) + "</td><td colspan=\"2\"></td></tr>");
                } else {
                    $("#ohTbodyUser").html("<tr><td colspan=\"10\">没有相应数据</td></tr>");
                }
                jQuery("#ohTb").alterBgColor({ odd: "odd", even: "even", selected: "selected", tdCss: "tdCss", istdClick: false });
                $("#orderHistory").dialog({ modal: true, width: "1020px" });
                $("#closeOH").unbind("click").bind("click", function () {
                    $("#orderHistory").dialog("close");
                });
            });
        }
        function round(v, e) {
            var t = 1;
            for (; e > 0; t *= 10, e--);
            for (; e < 0; t /= 10, e++);
            return Math.round(v * t) / t;
        }
        function GetWDHistory(data) {
            $("#wdhTb>tbody").html("");
            $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/GetWithDrawalHistoryByWhere", "userName:'" + data + "',name:'',status:'',time1:'',time2:''", true, false, function (json) {
                if (json.d != "") {
                    var re = jQuery.parseJSON(json.d);
                    var html = "", total1 = 0;
                    $.each(re, function (i) {
                        total1 += parseFloat(re[i].d);
                        html += "<tr><td>" + (i + 1) + "</td><td>" + re[i].b + "</td><td>" + re[i].r + "</td><td>" + re[i].n + "</td><td>-" + re[i].d + "</td><td>" + re[i].e + "</td><td>" + re[i].f + "</td><td>" + (re[i].g == "1" ? "未审核" : (re[i].g == "2" ? "成功" : "拒绝")) + "</td><td>" + re[i].h + "</td><td a='" + re[i].s + "' b='" + re[i].j + "' c='" + re[i].k + "' d='" + re[i].l + "' e='" + re[i].m + "'>" + re[i].i + "</td></tr>";
                    });
                    html += "<tr><td>总计</td><td colspan='3'></td><td>-" + total1.toFixed(2) + "</td><td colspan='6'></td></tr>";
                    $("#wdhTb>tbody").html(html);
                    $("#wdhTb>tbody>tr").mouseover(function () {
                        $(this).siblings().removeClass("trOver").end().addClass("trOver");
                    });
                    $("#wdhTb>tbody>tr>td[a]").unbind("click").bind("click", function () {
                        $("#lUserName").html($(this).attr("a"));
                        $("#lCardNo").html($(this).html());
                        $("#lType").html(bankArr[$(this).attr("b")]);
                        $("#lProvince").html($(this).attr("c"));
                        $("#lCity").html($(this).attr("d").toString().replace("@", ""));
                        $("#lBranch").html($(this).attr("e"));
                        $("#bankInfo").dialog({ modal: false, resizable: false });
                        $("#okBtn").unbind("click").bind("click", function () {
                            $("#bankInfo").dialog("close");
                        });
                    });
                } else {
                    $("#wdhTb>tbody").html("<tr><td colspan=\"10\">没有相应数据</td></tr>");
                }
                $("#wdHistory").dialog({ modal: true, width: "1020px" });
                $("#closeWDH").unbind("click").bind("click", function () {
                    $("#wdHistory").dialog("close");
                });
            });
        }
        function GetDHistory(data) {
            $("#dhTb>tbody").html("");
            $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/GetDepositHistoryByWhere", "userName:'" + data + "',name:'',status:'',time1:'',time2:''", true, false, function (json) {
                if (json.d != "") {
                    var re = jQuery.parseJSON(json.d);
                    var html = "", total1 = 0;
                    $.each(re, function (i) {
                        total1 += parseFloat(re[i].d);
                        html += "<tr><td>" + (i + 1) + "</td><td>" + re[i].b + "</td><td>" + re[i].k + "</td><td>" + re[i].l + "</td><td>+" + re[i].d + "</td><td>+" + re[i].d + "</td><td>+" + re[i].d + "</td><td>+" + re[i].d + "</td><td>" + re[i].e + "</td><td>" + re[i].f + "</td><td>" + (re[i].g == "1" ? "未审核" : (re[i].g == "2" ? "成功" : "拒绝")) + "</td><td>" + re[i].h + "</td></tr>";
                    });
                    html += "<tr><td>总计</td><td colspan='3'></td><td>+" + total1.toFixed(2) + "</td><td colspan='8'></td></tr>";
                    $("#dhTb>tbody").html(html);
                    $("#dhTb>tbody>tr").mouseover(function () {
                        $(this).siblings().removeClass("trOver").end().addClass("trOver");
                    });
                } else {
                    $("#dhTb>tbody").html("<tr><td colspan=\"12\">没有相应数据</td></tr>");
                }
                $("#dHistory").dialog({ modal: true, width: "1020px" });
                $("#closeDH").unbind("click").bind("click", function () {
                    $("#dHistory").dialog("close");
                });
            });
        }
        function GetOA(data) {
            $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/GetOrderAll", "userName:'" + data + "'", true, false, function (json) {
                if (json.d != "none") {
                    jQuery("#oashowInfo>tr").remove();
                    var result = jQuery.parseJSON(json.d);
                    var arr = new Array();
                    var total1 = 0, total2 = 0;
                    jQuery.each(result, function (i) {
                        total1 += parseFloat(result[i].Amount);
                        total2 += parseFloat(result[i].ValidAmount);
                        arr.push("<tr id='oatr1'>");
                        arr.push("<td id='oatime'>");
                        arr.push("" + result[i].time);
                        arr.push("</td>");
                        arr.push("<td id='oaUserName'>");
                        arr.push(result[i].UserName + "<br/>" + result[i].OrderID);
                        arr.push("</td>");
                        arr.push("<td id='oaleague'>");
                        arr.push(result[i].leaguetw + "<br/>" + result[i].BeginTime);
                        arr.push("</td>");
                        arr.push("<td id='oaHome'>");
                        arr.push(result[i].Hometw + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awaytw + "<br/>" + result[i].Score);
                        arr.push("</td>");
                        arr.push("<td id='oaBetType'>");
                        arr.push(typeList[parseInt(result[i].BetType)] + "<br/>" + (result[i].IsHalf == 1 ? "全场" : "半场"));
                        arr.push("</td>");
                        arr.push("<td id='oaHandicap'>");
                        arr.push(result[i].Handicap + "<br/>" + result[i].BetItem);
                        arr.push("</td>");
                        arr.push("<td id='oaOdds'>");
                        arr.push(result[i].Odds + "<br/>" + result[i].OddsType);
                        arr.push("</td>");
                        arr.push("<td id='oaUseAmount'>");
                        arr.push(result[i].Amount + "<br/>" + result[i].ValidAmount);
                        arr.push("</td>");
                        arr.push("<td id=''>");
                        arr.push("");
                        arr.push("</td>");
                        arr.push("<td id='oaWebSiteiID'>");
                        try {
                            arr.push((result[i].Status == "1" ? "确认" : (result[i].Status == "2" ? "等待确认" : "取消")) + "<br/>" + result1[result[i].WebSiteiID]["tw"]);
                        } catch (e) {
                            arr.push("");
                        }
                        arr.push("</td>");
                    });
                    var html = arr.join("\n\r"); ;
                    html += "<tr><td>总计</td><td colspan=\"6\"></td><td>" + total1.toFixed(2) + "<br/>" + total2.toFixed(2) + "</td><td colspan=\"2\"></td></tr>";
                    $("#oashowInfo").html(html);
                    jQuery("#oaTb").alterBgColor({ odd: "odd", even: "even", selected: "selected", tdCss: "tdCss", istdClick: false });
                } else {
                    $("#oashowInfo").html("<tr><td colspan=\"10\">没有相应数据</td></tr>");
                }
                $("#orderAll").dialog({ modal: true, width: "1020px" });
                $("#closeOA").unbind("click").bind("click", function () {
                    $("#orderAll").dialog("close");
                });
            });
        }
        function getCasino() {
            $.AjaxCommon("/ServicesFile/webBasicInfo/WebInfoService.asmx/GetDate", "", false, false, function (json1) {
                if (json1.d != "none") {
                    //debugger
                    var result = jQuery.parseJSON(json1.d);
                    $.each(result, function (j) {
                        var arr = new Array();
                        arr['tw'] = result[j].nametw;
                        arr['cn'] = result[j].namecn;
                        arr['en'] = result[j].nameen;
                        arr['th'] = result[j].nameth;
                        arr['vn'] = result[j].nametv;
                        result1[result[j].id] = arr;
                    });
                }
            });
        }
        var pd = 1;
        function Countdown(time) {
            $("#timeUp").text("" + time);
            if (parseInt(time) == 0) {
                if ($("#timeHide").val() == "") {
                    $("#timeHide").val("20");
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
                SelectByWhere();
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
        }
    </script>
</head>
<body>
    <table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="zdjs">代理提款审核</p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<input type="hidden" value="" id="timeHide" />
<input type="hidden" id="language" value="tw"/>
    <input type="hidden" id="langue" value="tw" />
    <form id="form1" runat="server">
    <div  style="width:95%;padding:3px;margin:2px;"><span id="VerifyWithDrawal" class="btn_04"  style=" color:Yellow; font-size:13px; font-weight:600">&nbsp;&nbsp;未审核提款&nbsp;&nbsp;</span>&nbsp;<span id="withdrawalHistory" class="btn_04" style=" font-size:11px">&nbsp;&nbsp;账单记录&nbsp;&nbsp;</span>&nbsp;&nbsp;
        代理<a id="hyzh">帐号</a>&nbsp;&nbsp;<input type="text" id="memberSel" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;&nbsp;&nbsp;
        代理<a id="hyxm">姓名</a>&nbsp;&nbsp;<input type="text" id="memberName" class="inputWhere text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="jysj">提交时间</a>&nbsp;&nbsp;<input type="text" id="time1WhereVal" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" readonly="readonly"  />－<input type="text" id="time2WhereVal" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" readonly="readonly"  />&nbsp;&nbsp;&nbsp;&nbsp;
  <%--  <a id="zt">状态</a>&nbsp;&nbsp;<select id="statusSel"><option value="1">全部</option>
        <option value="2">成功</option><option value="3">拒绝</option>
    </select>&nbsp;&nbsp;&nbsp;&nbsp;--%>
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in">搜索</span></a>&nbsp;&nbsp;&nbsp;&nbsp;
    <input type="text" id="timeTxt" value="5" class="text_01 w_30" onmouseover="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" /><label id="timeUp">5</label>&nbsp;&nbsp;
    </div>
     <div id="verify_list" title="提款审核" class="new_tr undis">
<div align="center">
<table width="100%"  border="0" cellpadding="1" cellspacing="1" id="verifyTb">
  <tr align="center" style="background-color:#CDEAFC">
    <td colspan="4"><strong>会员资料</strong></td>
  </tr>
 <tr>
    <td align="right">代理帐号：</td>
    <td id="userAccount" align="left"></td>
    <td align="right">代理姓名：</td>
    <td id="nicheng" align="left"></td>
  </tr>
  <tr>
    <td align="right">开通时间：</td>
    <td id="regtime" align="left"></td>
    <td align="right">所在城市：</td>
    <td id="lastlogintime" align="left"></td>
  </tr>
  <tr>
    <td align="right">联系电话：</td>
    <td id="tel" align="left"></td>
    <td align="right">电子邮箱：</td>
    <td id="email" align="left"></td>
    <%--<td align="right">手机号码：</td>
    <td id="mobile" align="left"></td>--%>
  </tr>
  <tr align="center">
    <td colspan="4" style="background-color:#CDEAFC"><strong>银行卡信息</strong></td>
  </tr>
  <tr align="center" >
  <td colspan="1" align="right">户名：</td>
  <td colspan="3" id="userName" align="left"></td>
  </tr>
  <tr align="center">
  <td colspan="1" align="right">银行卡号：</td>
  <td id="cardNo" colspan="3" align="left"></td>
  </tr>
  <tr align="center">
  <td colspan="1" align="right">银行类型：</td>
  <td id="type" colspan="3" align="left"></td>
  </tr>
  <tr align="center">
  <td colspan="1" align="right">银行所在省份：</td>
  <td colspan="3" id="city" align="left"></td>
  </tr>
  <tr align="center">
  <td colspan="1" align="right">银行所在分行：</td>
  <td colspan="3" id="branch"  align="left"></td>
  </tr>
  <tr align="center" style="background-color:#CDEAFC">
    <td colspan="4"><strong>提款信息</strong></td>
  </tr>
  <tr>
    <td align="right">币种：</td>
    <td id="currency" align="left"></td>
    <td align="right">帐户余额：</td>
    <td id="balance" align="left"></td>
  </tr>
  <tr>
    <td align="right">提款金额：</td>
    <td id="money" align="left" class=red></td>
    <td align="right"></td>
    <td id="validAmount" align="left">&nbsp;</td>
  </tr>
  <tr style="display:none;">
    <td align="right">出款银行：</td>
    <td id="Td1" align="left">
        <select id="bankout">
    
        </select>
    </td>
    <td align="right">手续费：</td>
    <td id="Td2" align="left"><input id="outfee" type="text" class="text_01 w_60 red" value="0.00" /></td>
  </tr>
  <tr>
    <td colspan="4" align="center" id="result" class="red"></td>
 </tr>
  <tr>
  </tr>
  <tr>
    <td colspan="4" align="center" height="50px">
<input type="button" id="AcceptBtn" onclick="acceptBtn()" class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'"  value="接受" />
<input type="button" id="RefuseBtn" onclick="refuseBtn()" class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'"  value="拒绝" />
<input type="button" id="EscBtn" onclick="escBtn()" class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="取消" />	
	</td>
  </tr>
</table>
</div>
<div class="new_trfoot"></div>
</div>

    <table class="tab2" id="tab1" width="100%" border="0" cellpadding="0" cellspacing="0">
    <thead>
    <tr>
    <th>序号</th>
    <th>代理名称</th>
    <th>代理姓名</th>
    <th>级别</th>
    <th>币种</th>
     <th>金额</th>
     <th>提交时间</th>
      <th>银行卡号</th>
       <th>审核</th>
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
<%--总存款记录--%>
<div id="dHistory" title="总存款记录" class="undis">
<div class="showdiv">
<table class="tab2" id="dhTb" width="100%" border="0" cellpadding="0" cellspacing="0">
    <thead>
                <tr>
               <th>序号</th>
                <th>会员帐号</th>
                <th>会员名称</th>
                <th>币种</th>
                 <th>存入金额</th>
                 <th>存入银行</th>
                 <th>存入账号</th>
                 <th>交易序号</th>
                <th>提交时间</th>
                <th>处理时间</th>
                <th>状态</th>
                <th>原因</th>
    </tr>
    </thead>
    <tbody id="dhTbody">
    </tbody>
    <tfoot>    
    <tr><td colspan="12"><input type="button" id="closeDH" class="btn_02" value="关闭" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></td></tr>
    </tfoot>
    </table>
    </div>
</div>
<%--总提款记录--%>
<div id="wdHistory" title="总提款记录" class="undis">
    <table class="tab2" id="wdhTb" width="100%" border="0" cellpadding="0" cellspacing="0">
    <thead>
                <tr>
             <th>序号</th>
                <th>会员帐号</th>
                <th>会员名称</th>
                <th>币种</th>
                <th>金额</th>
                <th>提交时间</th>
                <th>处理时间</th>
                <th>状态</th>
                <th>原因</th>
                <th>银行卡号</th>
    </tr>
    </thead>
    <tbody id="wdhTbody">
    </tbody>
    <tfoot>    
    <tr><td colspan="10"><input type="button" id="closeWDH" class="btn_02" value="关闭" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></td></tr>
    </tfoot>
    </table>
</div>
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
    <input type="button" id="okBtn" class="btn_02" value="确认" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></div></li>
</ul>
</div></div>
<%--下注中注单记录--%>
<div id="orderAll" title="下注中注单记录" class="undis">
<div class="showdiv">
<table width="100%" class="tab2" id="oaTb">
    <thead>
    <tr>
    <th>下注时间</th>
    <th>账号</th>
   <%-- <th>投注账号</th>--%>
    <th>联赛</th>
    <th>队伍</th>
    <th>投注类型</th>
    <th>盘口</th>
    <th>赔率</th>
    <th>投注金额</th>
    <th>公司金额</th>
    <th>网站</th>
    </tr>
    </thead>
    <tbody id="oashowInfo" class="tc">    

    </tbody>
    <tfoot>   
     <tr id="oatr1">
    <td id="oatime"></td>
    <td id="oaUserName"></td>
    <%--<td id="oaWebUserName"></td>--%>
    <td id="oaleague"></td>
    <td id="oaHome"></td>
    <td id="oaBetType"></td>
    <td id="oaHandicap"></td>
    <td id="oaOdds"></td>
    <td id="oaUseAmount"></td>
    <td id=""></td>
    <td id="oaWebSiteiID"></td>
    </tr>
    <tr><td colspan="11"><input type="button" id="closeOA" class="btn_02" value="关闭" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></td></tr>
    </tfoot>
    </table>
    </div>
</div>
<%--下注历史记录--%>
<div id="orderHistory" title="下注历史记录" class="undis">
<div class="showdiv">
    <table width="100%" class="tab2" id="ohTb">
    <thead>
    <tr align="center">
    <th rowspan="2" id="H1026">序号</th>
    <th rowspan="2" id="H1416">資訊</th>
    <th rowspan="2" id="H1284">选择</th>
    <th rowspan="2" id="H1171">赔率</th>
    <th rowspan="2" id="H1172">投注金额</th>
    <th rowspan="2" id="H1070">状态</th>
    <th rowspan="2">输赢</th>
    <th rowspan="2"><span id="H1417">分公司占成</span><br /><span id="H1418">股东占成</span><br /><span id="H1419">总代占成</span><br /><span id="H1420">代理占成</span></th>
    <th rowspan="2">IP</th>
    </tr>
    </thead>
    <tbody id="ohTbodyUser">
    </tbody>
    <tfoot>
    <tr id="ohTrUser">
    <td id="ohSequenceId"></td>
    <td id="ohInformation"></td>
    <td id="ohDetailBetType"></td>
    <td id="ohOdds"></td>
    <td id="ohAmount"></td>
    <td id="ohStatus"></td>
    <td id="ohResultTd"></td>
    <td id="ohPercentes"></td>
    <td id="ohIP"></td>
    </tr>    
    <tr><td colspan="10"><input type="button" id="closeOH" class="btn_02" value="关闭" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></td></tr>
    </tfoot>
    </table>
    </div>
</div>
<div id="refuseDepoist" title="拒绝提款">
<div class="showdiv">
<ul>
<li><p><span id="refuseReason">拒绝原因</span>：</p><p><select id="reason"></select></p></li>
<li><div align="center" class="mtop_30"><br />
    <input type="button" id="submitBtn" class="btn_02" value="提交" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="cancelBtn" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></div></li>
</ul>
</div></div>
</body>
</html>
