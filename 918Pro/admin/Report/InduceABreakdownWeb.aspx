<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InduceABreakdownWeb.aspx.cs" Inherits="admin.Report.InduceABreakdownWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>外调明细</title>
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
        var typeList;
        var leagueName = "";
        var bollID = "";
        var languages = "";
        var result1=new Array();
        var olddata="";
        jQuery(function () {
        
        SetGlobal("");
        
            $("#time1WhereVal,#time2WhereVal").datepicker().click(function(){
                $(this).val("");
            });
            //$("#time2WhereVal").datepicker();
            $(".inputWhere").keyup(function (e) {
                var currKey = 0, e = e || event;
                currKey = e.keyCode || e.which || e.charCode;
                if (currKey == 13) {
                     <% if(searchAc) { %>
                var data = "league:'" + jQuery("#leagueInput").val()  + "',type:'" + jQuery("#type").val() + "',money:'" + jQuery("#money").val() + "',ballteam:'" + jQuery("#bollInput").val()  + "',language:'" + jQuery("#language").val() + "',time1:'"+jQuery("#time1WhereVal").val() +"',time2:'"+jQuery("#time2WhereVal").val() +"',account:'"+jQuery("#account").val() +"'";
                <% } else { %>
                var data = "league:'',type:'-1',money:'',ballteam:'',language:'" + jQuery("#language").val() + "',time1:'',time2:'',account:''";
                <% } %>
                setData(data);
                    $(this).blur();
                }
            });
            jQuery("#delet").hide();
            jQuery("#delet1").hide();
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
            var data = "league:'',type:'-1',money:'',ballteam:'',language:'"+jQuery("#language").val()+"',time1:'',time2:'',account:''";
            getCasino();
            setData(data);
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
            /*--------------球队信息-----------------*/
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
//                var t = "";
//                if ($("#DataLength").val() != "") {
//                    if (parseInt($("#DataLength").val()) > 200) {
//                        var setLang = "";
//                        setLang = $.SetOrGetLanguage(setLang, function () {
//                            languages = language;
//                            alert(languages["H1254"]);
//                        }, "/js/IndexGlobal/");
//                        t = "50";
//                    }
//                    else {
//                        t = $("#DataLength").val();
//                    }
//                }
//                else {
//                    t = "50";
//                }
                <% if(searchAc) { %>
                var data = "league:'" + jQuery("#leagueInput").val()  + "',type:'" + jQuery("#type").val() + "',money:'" + jQuery("#money").val() + "',ballteam:'" + jQuery("#bollInput").val()  + "',language:'" + jQuery("#language").val() + "',time1:'"+jQuery("#time1WhereVal").val() +"',time2:'"+jQuery("#time2WhereVal").val() +"',account:'"+jQuery("#account").val() +"'";
                <% } else { %>
                var data = "league:'',type:'-1',money:'',ballteam:'',language:'" + jQuery("#language").val() + "',time1:'',time2:'',account:''";
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
                jQuery("#qd").text(languages["H1161"]);
                jQuery("#sj").text(languages["H1056"]);
                jQuery("#zh").text(languages["H1083"]);
                jQuery("#ls").text(languages["H1130"]);
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
                jQuery("#tb2>thead>tr>th:eq(0)").text(languages["H1264"]);
                jQuery("#tb2>thead>tr>th:eq(1)").text(languages["H1083"]);
                jQuery("#tb2>thead>tr>th:eq(2)").text(languages["H1265"]);
                jQuery("#tb2>thead>tr>th:eq(3)").text(languages["H1130"]);
                jQuery("#tb2>thead>tr>th:eq(4)").text(languages["H1266"]);
                jQuery("#tb2>thead>tr>th:eq(5)").text(languages["H1259"]);
                jQuery("#tb2>thead>tr>th:eq(6)").text(languages["H1173"]);
                jQuery("#tb2>thead>tr>th:eq(7)").text(languages["H1171"]);
                jQuery("#tb2>thead>tr>th:eq(8)").text(languages["H1172"]);
                jQuery("#tb2>thead>tr>th:eq(9)").text(languages["H1263"]);
                jQuery("#tb2>thead>tr>th:eq(10)").text(languages["H1054"]);
                
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
        function setData(data) {
        
            jQuery.AjaxCommon("/ServicesFile/ReportService/InduceService.asmx/GetAllTolength1", data, true, false, function (json) {
            
                if (json.d != "none") {
                if(olddata == json.d)
                {
                    return;
                }
                olddata = json.d;
                    jQuery("#showInfo>tr").remove();
                    //alert(json.d);
                    var result = jQuery.parseJSON(json.d);
                    var arr=new Array();
                    languages = language;
                    jQuery.each(result, function (i) {
                        arr.push("<tr id='tr1'>");
                        arr.push("<td id='time'>");
                        arr.push(""+result[i].time);
                        arr.push("</td>");
                        arr.push("<td id='UserName'>");
                        arr.push(result[i].UserName + "<br/>" + result[i].OrderID);
                        arr.push("</td>");

                        arr.push("<td id='WebUserName'>");
                        arr.push("<a href=\"/Report/DataByCasinoAccount.aspx?a="+result[i].WebSiteiID+"&b="+result[i].WebUserName +"\" target=\"_blank\">"+result[i].WebUserName +"</a><br/>" + result[i].WebOrderID);
                        arr.push("</td>");

                         arr.push("<td id='league'>");
                         switch(jQuery("#language").val())
                         {
                            case "tw":
                                arr.push(result[i].leaguetw + "<br/>" + result[i].BeginTime);
                                break;
                            case "cn":
                                arr.push(result[i].leaguecn + "<br/>" + result[i].BeginTime);
                                break;
                            case "en":
                                arr.push(result[i].leagueen + "<br/>" + result[i].BeginTime);
                                break;
                            case "th":
                                arr.push(result[i].leagueth + "<br/>" + result[i].BeginTime);
                                break;
                            case "vn":
                                arr.push(result[i].leaguevn + "<br/>" + result[i].BeginTime);
                                break;
                         }
                        
                        arr.push("</td>");
                        arr.push("<td id='Home'>");
                        switch(jQuery("#language").val())
                         {
                            case "tw":
                                arr.push(result[i].Hometw + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awaytw + "<br/>" + result[i].Score);
                                break;
                            case "cn":
                                arr.push(result[i].Homecn + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awaycn + "<br/>" + result[i].Score);
                                break;
                            case "en":
                                arr.push(result[i].Homeen + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awayen + "<br/>" + result[i].Score);
                                break;
                            case "th":
                                arr.push(result[i].Hometh + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awayth + "<br/>" + result[i].Score);
                                break;
                            case "vn":
                                arr.push(result[i].Homevn + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awayvn + "<br/>" + result[i].Score);
                                break;
                         }
                        arr.push("</td>");
                        arr.push("<td id='BetType'>");
                        arr.push(typeList[parseInt(result[i].BetType)] + "<br/>" + (result[i].IsHalf == 1 ? languages["H1159"] : languages["H1160"]));
                        arr.push("</td>");

                        arr.push("<td id='Handicap'>");
                        arr.push(result[i].Handicap + "<br/>" + result[i].BetItem);
                        arr.push("</td>");

                        arr.push("<td id='Odds'>");
                        arr.push(result[i].Odds + "<br/>" + result[i].OddsType);
                        arr.push("</td>");

                        arr.push("<td id='UseAmount'>");
                        arr.push(result[i].Amount + "<br/>" + result[i].ValidAmount);
                        arr.push("</td>");

                        arr.push("<td id=''>");
                        arr.push("");
                        arr.push("</td>");
                        arr.push("<td id='WebSiteiID'>");
                        try
                        {
                        arr.push((result[i].Status == "1" ? languages["H1469"] : (result[i].Status == "2" ? languages["H1292"] : ["H1011"])) + "<br/>" + result1[result[i].WebSiteiID][jQuery("#language").val()]);
                        }catch(e)
                        {
                          arr.push("");
                        }
                        arr.push("</td>");
                        
                        
                    });
                    //jQuery("#showInfo>tr:eq(0)").remove();
                    var html=arr.join("\n\r");;
                    $("#showInfo").html(html);
                    jQuery("#tb2").alterBgColor({ odd: "odd", even: "even", selected: "selected", tdCss: "tdCss", istdClick: false });
                }else{
                    $("#showInfo").html("<tr><td colspan=\"11\">没有相应数据</td></tr>");
                }
            });
        }
        function setData3(data) {
            jQuery.AjaxCommon("/ServicesFile/ReportService/InduceService.asmx/GetAllTolength", data, true, false, function (json) {
                if (json.d != "none") {
                    jQuery("#showInfo>tr").remove();
                    //alert(json.d);
                    var result = jQuery.parseJSON(json.d);
                    jQuery.each(result, function (i) {
                        var tr = jQuery("#tr1").clone();
                        tr.find("#time").html("" + result[i].time);
                        tr.find("#UserName").html(result[i].UserName + "<br/>" + result[i].OrderID);
                        tr.find("#WebUserName").html("<a href=\"/Report/DataByCasinoAccount.aspx?a="+result[i].WebSiteiID+"&b="+result[i].WebUserName +"\" target=\"_blank\">"+result[i].WebUserName + "</a><br/>" + result[i].WebOrderID);
                        if (jQuery("#language").val() == "tw") {
                            tr.find("#league").html(result[i].leaguetw + "<br/>" + result[i].BeginTime);
                            tr.find("#Home").html(result[i].Hometw + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awaytw + "<br/>" + result[i].Score);
                        }
                        else if (jQuery("#language").val() == "cn") {
                            tr.find("#league").html(result[i].leaguecn + "<br/>" + result[i].BeginTime);
                            tr.find("#Home").html(result[i].Homecn + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awaycn + "<br/>" + result[i].Score);
                        }
                        else if (jQuery("#language").val() == "en") {
                            tr.find("#league").html(result[i].leagueen + "<br/>" + result[i].BeginTime);
                            tr.find("#Home").html(result[i].Homeen + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awayen + "<br/>" + result[i].Score);
                        }
                        else if (jQuery("#language").val() == "th") {
                            tr.find("#league").html(result[i].leagueth + "<br/>" + result[i].BeginTime);
                            tr.find("#Home").html(result[i].Hometh + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awayth + "<br/>" + result[i].Score);
                        }
                        else if (jQuery("#language").val() == "vn") {
                            tr.find("#league").html(result[i].leaguevn + "<br/>" + result[i].BeginTime);
                            tr.find("#Home").html(result[i].Homevn + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awayvn + "<br/>" + result[i].Score);
                        }
                        //tr.find("#BeginTime").html("" + );
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            tr.find("#BetType").html(typeList[parseInt(result[i].BetType)] + "<br/>" + (result[i].IsHalf == 1 ? languages["H1159"] : languages["H1160"]));
                        }, "/js/IndexGlobal/");
                        tr.find("#Handicap").html(result[i].Handicap + "<br/>" + result[i].BetItem);
                        tr.find("#Odds").html(result[i].Odds + "<br/>" + result[i].OddsType);
                        tr.find("#UseAmount").html(result[i].Amount + "<br/>" + result[i].ValidAmount);
                        //tr.find("#Company").html(result[i].Amount + "<br/>" + result[i].Amount);
                        $.AjaxCommon("/ServicesFile/webBasicInfo/WebInfoService.asmx/GetDate", "", true, false, function (json1) {
                            if (json1.d != "none") {
                            //debugger
                                var result1 = jQuery.parseJSON(json1.d);
                                $.each(result1, function (j) {
                                    if (result1[j].id == result[i].WebSiteiID) {
                                        if (jQuery("#language").val() == "tw") {
                                            var setLang = "";
                                            setLang = $.SetOrGetLanguage(setLang, function () {
                                                languages = language;
                                                tr.find("#WebSiteiID").html((result[i].Status == "1" ? languages["H1469"] : (result[i].Status == "2" ? languages["H1292"] : ["H1011"])) + "<br/>" + result1[j].nametw);
                                            }, "/js/IndexGlobal/");
                                        }
                                        else if (jQuery("#language").val() == "cn") {
                                            var setLang = "";
                                            setLang = $.SetOrGetLanguage(setLang, function () {
                                                languages = language;
                                                tr.find("#WebSiteiID").html((result[i].Status == "1" ? languages["H1469"] : (result[i].Status == "2" ? languages["H1292"] : ["H1011"]))+ "<br/>" + result1[j].namecn);
                                            }, "/js/IndexGlobal/");
                                        }
                                        else if (jQuery("#language").val() == "en") {
                                            var setLang = "";
                                            setLang = $.SetOrGetLanguage(setLang, function () {
                                                languages = language;
                                                tr.find("#WebSiteiID").html((result[i].Status == "1" ? languages["H1469"] : (result[i].Status == "2" ? languages["H1292"] : ["H1011"])) + "<br/>" + result1[j].nameen);
                                            }, "/js/IndexGlobal/");
                                        }
                                        else if (jQuery("#language").val() == "th") {
                                            var setLang = "";
                                            setLang = $.SetOrGetLanguage(setLang, function () {
                                                languages = language;
                                                tr.find("#WebSiteiID").html((result[i].Status == "1" ? languages["H1469"] : (result[i].Status == "2" ? languages["H1292"] : ["H1011"]))+ "<br/>" + result1[j].nameth);
                                            }, "/js/IndexGlobal/");
                                        }
                                        else if (jQuery("#language").val() == "vn") {
                                            var setLang = "";
                                            setLang = $.SetOrGetLanguage(setLang, function () {
                                                languages = language;
                                                tr.find("#WebSiteiID").html((result[i].Status == "1" ? languages["H1469"] : (result[i].Status == "2" ? languages["H1292"] : ["H1011"]))+ "<br/>" + result1[j].namevn);
                                            }, "/js/IndexGlobal/");
                                        }
                                    }
                                });
                            }
                        });
                        tr.appendTo("#showInfo");
                    });
                    //jQuery("#showInfo>tr:eq(0)").remove();
                    jQuery("#tb2").alterBgColor({ odd: "odd", even: "even", selected: "selected", tdCss: "tdCss", istdClick: false });
                }
            });
        }
        function getCasino()
        {
            $.AjaxCommon("/ServicesFile/webBasicInfo/WebInfoService.asmx/GetDate", "", false, false, function (json1) {
                            if (json1.d != "none") {
                            //debugger
                                var result = jQuery.parseJSON(json1.d);
                                $.each(result, function (j) {
                                    var arr=new Array();
                                    arr['tw']=result[j].nametw;
                                    arr['cn']=result[j].namecn;
                                    arr['en']=result[j].nameen;
                                    arr['th']=result[j].nameth;
                                    arr['vn']=result[j].nametv;
                                    result1[result[j].id]=arr;

                                   
                                });
                            }
                        });
        }
        var pd = 1;
        function Countdown(time) {
            $("#timeUp").text("" + time);
            if (parseInt(time) == 0) {
                //var t = "";
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
//                if ($("#DataLength").val() != "") {
//                    if (parseInt($("#DataLength").val()) > 200) {
//                        var setLang = "";
//                        setLang = $.SetOrGetLanguage(setLang, function () {
//                            languages = language;
//                            alert(languages["H1254"]);
//                        }, "/js/IndexGlobal/");
//                        t = "50";
//                    }
//                    else {
//                        t = $("#DataLength").val();
//                    }
//                }
//                else {
//                    t = "50";
//                }
                <% if(searchAc) { %>
                var data = "league:'" + jQuery("#leagueInput").val()  + "',type:'" + jQuery("#type").val() + "',money:'" + jQuery("#money").val() + "',ballteam:'" + jQuery("#bollInput").val()  + "',language:'" + jQuery("#language").val() + "',time1:'"+jQuery("#time1WhereVal").val() +"',time2:'"+jQuery("#time2WhereVal").val() +"',account:'"+jQuery("#account").val() +"'";
                <% } else { %>
                var data = "league:'',type:'-1',money:'',ballteam:'',language:'" + jQuery("#language").val() + "',time1:'',time2:'',account:''";
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
<th width="*" class="tab_top_m"><p>外调明细</p></th>
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
<%--<input id="leagueAll" type="button" value="选择联赛" />&nbsp;
    <input type="button" id="boll" value="选择球队" />&nbsp;--%>
    <a id="ls">联赛</a>:<input type="text" id="leagueInput" class="inputWhere text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" maxlength="4" />&nbsp;
    <a id="boll">球队</a>:<input type="text" id="bollInput" class="inputWhere text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" />&nbsp;<a id="zh">账号</a>:<input type="text" id="account" class="inputWhere text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" />&nbsp;
    <a id="sj">时间</a>:<input type="text" id="time1WhereVal" class="text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" readonly="readonly"  />－<input type="text" id="time2WhereVal" class="text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" readonly="readonly"  />  &nbsp;<a id="je">金额</a>:<input type="text" value="" id="money" class="inputWhere text_01_h w_30" onmouseover="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" />&nbsp;
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
    </select>
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in">搜索</span></a>
</div>
<% } %>
<div class="fr">
<input type="text" id="timeTxt" value="20" class="text_01 w_30" onmouseover="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" /><label id="timeUp">20</label>&nbsp;&nbsp;&nbsp;&nbsp;
<%--<input type="text" value="50" id="DataLength" class="text_01 w_60" onmouseover="this.className='text_01_h w_60'" onmouseout="this.className='text_01 w_60'" /><a id="tjl">条记录</a>--%>
    
</div>

</div>
    <table width="100%" class="tab2" id="tb2">
    <thead>
    <tr>
    <th>下注时间</th>
    <th>账号</th>
    <th>投注账号</th>
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
    <tbody id="showInfo" class="tc">
    
    </tbody>
    <tfoot>
    <tr id="tr1">
    <td id="time"></td>
    <td id="UserName"></td>
    <td id="WebUserName"></td>
    <td id="league"></td>
    <td id="Home"></td>
    <td id="BetType"></td>
    <td id="Handicap"></td>
    <td id="Odds"></td>
    <td id="UseAmount"></td>
    <td id=""></td>
    <td id="WebSiteiID"></td>
    </tr>
    </tfoot>
    </table>
    </form>

    <div id="delet" title="选择联赛">
    <div id="leagueDiv" class="showdiv">
    <table width="100%">
    <thead>
    <tr><th align="left"><input type="checkbox" id="allLeague" /><a id="qxqx"></a></th><th colspan="3" align="left"><a id="xzls">选择联赛</a></th></tr>
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
    <tr><th align="left"><input type="checkbox" id="againstAll" /><a id="qxqx1"></a></th><th colspan="2" align="left"><a id="xzdz">选择对阵双方</a></th></tr>
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
