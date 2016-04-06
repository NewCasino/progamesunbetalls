<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BetMax.aspx.cs" Inherits="admin.webBasicInfo.BetMax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <script src="/js/page/pageJs.js" type="text/javascript"></script>
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="/js/jQueryCommon.js" type="text/javascript"></script>
    <script type="text/javascript">
        var web;
        var data = "";
        var count = 0;
        var page = 0;
        var languages = "";
        <%=(fzAcS+
        addAcS+
        deleteAcS+
        mdfAcS) %>
        $(function () {
        SetGlobal("");
            web = new Array();
            jQuery("#cookieDiv").hide();
            $("#delet").hide();
            $("#cookieDiv").hide();
            $("#AddInfoDiv").hide();
            $("#delet2").hide();
            
            $.AjaxCommon("/ServicesFile/webBasicInfo/WebInfoService.asmx/GetDate", "", false, false, function (json) {
                if (json.d != "none") {
                    var a="";
                    $("#webWhereVal").html("");
                    var result = jQuery.parseJSON(json.d);
                    
                    $.each(result, function (i) {
                        if (jQuery("#language").val() == "tw") {
                            web[result[i].id] = result[i].nametw;
                            a += "<option value=\"" + result[i].id + "\">" + result[i].nametw + "</option>";
                        }
                        else if (jQuery("#language").val() == "cn") {
                            web[result[i].id] = result[i].namecn;
                            a += "<option value=\"" + result[i].id + "\">" + result[i].namecn + "</option>";
                        }
                        else if (jQuery("#language").val() == "en") {
                            web[result[i].id] = result[i].nameen;
                            a += "<option value=\"" + result[i].id + "\">" + result[i].nameen + "</option>";
                        }
                        else if (jQuery("#language").val() == "th") {
                            web[result[i].id] = result[i].nameth;
                            a += "<option value=\"" + result[i].id + "\">" + result[i].nameth + "</option>";
                        }
                        else if (jQuery("#language").val() == "vn") {
                            web[result[i].id] = result[i].namevn;
                            a += "<option value=\"" + result[i].id + "\">" + result[i].namevn + "</option>";
                        }
                        //web[result[i].id] = result[i].namecn;
                        
                    });
                    var setLang="";
                    setLang = $.SetOrGetLanguage(setLang, function () {
                        languages = language;
                        var b = "<option value=\"0\">"+languages["H1040"]+"</option>";
                        $("#webWhereVal").html(b+a);
                    }, "/js/IndexGlobal/");
                }
            });
            data = "casino:'0',dali:'',id:'',enable:'-1',webPoss:'',Company:''";
            jQuery.AjaxCommon("/ServicesFile/webBasicInfo/BetaccountService.asmx/getAllCount1", data, false, false, function (json) {
                count = parseInt(json.d);
            });
            if (count % 20 == 0) {
                page = count / 20;
            }
            else {
                page = count / 20 + 1;
            }
            //debugger
            IsPage(parseInt(page), count, '20', 'IDex', 'IDexC');
            $("#closeButton").click(function () {
                jQuery("#delet2").dialog("close");
            });

            $("#AddButtonDiv").show();
            $("#AddInfo").click(function () {
                $("#AddInfoDiv").show();
                $("#selectAndInsert").hide();
                GetWeb();
            });
            $("#esc").click(function () {
                $("#addID").val("");
                $("#addPassword").val("");
                $("#addAddress").val("");
                $("#addAddress2").val("");
                $("#addGroup").val("");
                $("#AddCookie").val("");
                $("#addAgent").val("");
                $("#addWebsitepossess").val("");
                $("#addSelfpossess").val("");
                $("#addCommission").val("");
                $("#addMultiple").val("");
                $("#zemo").val("");
                $("#selectAndInsert").show();
                $("#AddInfoDiv").hide();
            });
            $("#sure").click(function () {
                var pd = 0;
                $.each($("#AddWebInfo").find(":text"), function (i) {
                //debugger
                    if(jQuery(this).attr("id")!="addAddress" && jQuery(this).attr("id")!="addAddress2" && jQuery(this).attr("id")!="AddCookie" && jQuery(this).attr("id")!="zemo"){

                        if ($("#AddWebInfo").find(":text:eq(" + i + ")").val() == "") {
                            var setLang="";
                            setLang = $.SetOrGetLanguage(setLang, function () {
                                languages = language;
                                alert(languages["H1004"]);
                            }, "/js/IndexGlobal/");
                            pd = 1;
                            return false;
                        }
                    }
                });
                if (pd) {
                    return false;
                }
                if ($("#addID").val().indexOf("'") != -1) {
                var setLang="";
                    setLang = $.SetOrGetLanguage(setLang, function () {
                        languages = language;
                        alert(languages["H1074"]);
                    }, "/js/IndexGlobal/");
                    
                    return false;
                }
                var zw = $("#addID").val();
                if (zw.replace(/[^\x00-\xff]/g, "aa").length != $("#addID").val().length) {
                var setLang="";
                    setLang = $.SetOrGetLanguage(setLang, function () {
                        languages = language;
                        alert(languages["H1043"]);
                    }, "/js/IndexGlobal/");
                    
                    return false;
                }
                var namePattern = /^(0|[1-9][0-9]*)$/;
                if (!namePattern.test($("#addGroup").val()) || $("#addGroup").val().length > 4) {
                var setLang="";
                    setLang = $.SetOrGetLanguage(setLang, function () {
                        languages = language;
                        alert(languages["H1041"]);
                    }, "/js/IndexGlobal/");
                    
                    return false;
                }
                var poss = /^(([0]\.[0-9]{1,3})|([1]))$/;
                if (!poss.test($("#addWebsitepossess").val())) {
                var setLang="";
                    setLang = $.SetOrGetLanguage(setLang, function () {
                        languages = language;
                        alert(languages["H1075"]);
                    }, "/js/IndexGlobal/");
                    
                    return false;
                }
                if (!poss.test($("#addSelfpossess").val())) {
                var setLang="";
                    setLang = $.SetOrGetLanguage(setLang, function () {
                        languages = language;
                        alert(languages["H1075"]);
                    }, "/js/IndexGlobal/");
                    
                    return false;
                }
                if (($("#addWebsitepossess").val() * 100.00 + $("#addSelfpossess").val() * 100.00) / 100.00 > 1) {
                    var setLang="";
                    setLang = $.SetOrGetLanguage(setLang, function () {
                        languages = language;
                        alert(languages["H1076"]);
                    }, "/js/IndexGlobal/");
                    return false;
                }
                var Comm = /^(0|([0-9]*\.[0-9]{0,3}))$/;
                if (!Comm.test($("#addCommission").val())) {
                var setLang="";
                    setLang = $.SetOrGetLanguage(setLang, function () {
                        languages = language;
                        alert(languages["H1077"]);
                    }, "/js/IndexGlobal/");
                    
                    return false;
                }
                var xs = /^(0|([0-9]*\.[0-9]{0,3})|([1-9][0-9]*))$/;
                if (!xs.test($("#addMultiple").val())) {
                var setLang="";
                    setLang = $.SetOrGetLanguage(setLang, function () {
                        languages = language;
                        alert(languages["H1078"]);
                    }, "/js/IndexGlobal/");
                    
                    return false;
                }
                var zemo = $("#zemo").val();
                if (zemo.replace(/[^\x00-\xff]/g, "aa").length > 100) {
                var setLang="";
                    setLang = $.SetOrGetLanguage(setLang, function () {
                        languages = language;
                        alert(languages["H1079"]);
                    }, "/js/IndexGlobal/");
                    
                    return false;
                }
                var cooke = $("#AddCookie").val();
                if (cooke.replace(/[^\x00-\xff]/g, "aa").length > 1000) {
                var setLang="";
                    setLang = $.SetOrGetLanguage(setLang, function () {
                        languages = language;
                        alert(languages["H1044"]);
                    }, "/js/IndexGlobal/");
                    
                    return false;
                }
                var dali = $("#addAgent").val();
                if (dali.replace(/[^\x00-\xff]/g, "aa").length > 30) {
                var setLang="";
                    setLang = $.SetOrGetLanguage(setLang, function () {
                        languages = language;
                        alert(languages["H1080"]);
                    }, "/js/IndexGlobal/");
                    return false;
                }
                data = "casino:'" + $("#addCasino").val() + "',userid:'" + $("#addID").val() + "',password:'" + $("#addPassword").val() + "',";
                data += "agent:'" + $("#addAgent").val().replace(/'/g, "Π") + "',websitepossess:'" + $("#addWebsitepossess").val() + "',selfpossess:'" + $("#addSelfpossess").val() + "',";
                data += "commission:'" + $("#addCommission").val() + "',multiple:'" + $("#addMultiple").val() + "',zemo:'" + $("#zemo").val().replace(/'/g, "Π") + "',";
                data += "group:'" + $("#addGroup").val() + "',address:'" + $("#addAddress").val().replace(/'/g, "Π") + "',address2:'" + $("#addAddress2").val().replace(/'/g, "Π") + "',";
                data += "cookie:'" + $("#AddCookie").val().replace(/'/g, "Π") + "',isquzhi:'" + ($("#addIsquzhi").attr("checked") == true ? 1 : 0) + "',";
                data += "enable:'" + ($("#addEnable").attr("checked") == true ? 1 : 0) + "',ip:'" + $("#IpAddress").val() + "'";
                $.AjaxCommon("/ServicesFile/webBasicInfo/BetaccountService.asmx/InsertInfo1", data, false, false, function (json) {
                    if (json.d != "none") {
                        if (json.d == "-1") {
                            jQuery("#delet2").dialog({ model: true });
                            var setLang="";
                    setLang = $.SetOrGetLanguage(setLang, function () {
                        languages = language;
                        jQuery("#delet2>div:eq(0)>div:eq(0)").text(languages["H1047"]);
                    }, "/js/IndexGlobal/");
                            
                            return false;
                        }
                        data = "casino:'0',dali:'',id:'',enable:'-1',webPoss:'',Company:''";
                        jQuery.AjaxCommon("/ServicesFile/webBasicInfo/BetaccountService.asmx/getAllCount1", data, false, false, function (json) {
                            count = parseInt(json.d);
                        });
                        if (count % 20 == 0) {
                            page = count / 20;
                        }
                        else {
                            page = count / 20 + 1;
                        }
                        IsPage(parseInt(page), count, '20', 'IDex', 'IDexC');
                    }
                });
                if ($("#IsContinuous").attr("checked")) {
                }
                else {
                    $("#addID").val("");
                    $("#addPassword").val("");
                    $("#addAddress").val("");
                    $("#addAddress2").val("");
                    $("#addGroup").val("");
                    $("#AddCookie").val("");
                    $("#addAgent").val("");
                    $("#addWebsitepossess").val("");
                    $("#addSelfpossess").val("");
                    $("#addCommission").val("");
                    $("#addMultiple").val("");
                    $("#zemo").val("");
                    $("#selectAndInsert").show();
                    $("#AddInfoDiv").hide();
                }

            });

            $("#selectSure").click(function () {
                data = "";
                data += "casino:'" + $("#webWhereVal").val() + "'";
                data += ",dali:'" + $("#daliWhereVal").val().replace(/'/g, "Π") + "'";
                data += ",id:'" + $("#idWhereVal").val() + "'";
                data += ",enable:'" + $("#enableWhereVal").val() + "'";
                var poss = /^(([0]\.[0-9]{1,3})|([1]))$/;
                if (!poss.test($("#webPossWhereVal").val()) && $("#webPossWhereVal").val() != "") {
                var setLang="";
                    setLang = $.SetOrGetLanguage(setLang, function () {
                        languages = language;
                        alert(languages["H1075"]);
                    }, "/js/IndexGlobal/");
                    
                    return false;
                }
                if (!poss.test($("#CompanyWhereVal").val()) && $("#CompanyWhereVal").val() != "") {
                    var setLang="";
                    setLang = $.SetOrGetLanguage(setLang, function () {
                        languages = language;
                        alert(languages["H1075"]);
                    }, "/js/IndexGlobal/");
                    return false;
                }
                data += ",webPoss:'" + $("#webPossWhereVal").val() + "'";
                data += ",Company:'" + $("#CompanyWhereVal").val() + "'";
                jQuery.AjaxCommon("/ServicesFile/webBasicInfo/BetaccountService.asmx/getAllCount1", data, false, false, function (json) {
                    count = parseInt(json.d);
                });
                if (count % 20 == 0) {
                    page = count / 20;
                }
                else {
                    page = count / 20 + 1;
                }
                //debugger
                IsPage(parseInt(page), count, '20', 'IDex', 'IDexC');
            });

        });
        
        function SetGlobal(setLang){
        setLang = $.SetOrGetLanguage(setLang, function () {
                languages = language;
                $("#tzzh").text(languages["网站最高投注帐号"]);
                $(".fa_add_in").text(languages["H1015"]);
                $("#wz").text(languages["H1054"]);
                $("#AddWebInfo>tr:eq(0)").find("td:eq(0)").text(languages["H1054"]);
                $("#AddWebInfo>tr:eq(1)").find("td:eq(0)").text(languages["H1060"]);
                $("#AddWebInfo>tr:eq(1)").find("td:eq(2)").text(languages["H1061"]);
                $("#AddWebInfo>tr:eq(2)").find("td:eq(0)").text(languages["H1086"]);
                $("#AddWebInfo>tr:eq(2)").find("td:eq(2)").text(languages["H1084"]);
                $("#AddWebInfo>tr:eq(3)").find("td:eq(0)").text(languages["H1085"]);
                $("#AddWebInfo>tr:eq(3)").find("td:eq(2)").text(languages["佣金"]);
                $("#AddWebInfo>tr:eq(4)").find("td:eq(0)").text(languages["H1087"]);
                $("#AddWebInfo>tr:eq(4)").find("td:eq(2)").text(languages["H1062"]);
                $("#AddWebInfo>tr:eq(5)").find("td:eq(0)").text(languages["H1063"]);
                $("#AddWebInfo>tr:eq(5)").find("td:eq(2)").text(languages["H1064"]);
                $("#AddWebInfo>tr:eq(6)").find("td:eq(0)").text(languages["H1088"]);
                //$("#AddWebInfo>tr:eq(6)").find("td:eq(2)").text(languages["H1054"]);
                $("#AddWebInfo>tr:eq(7)").find("td:eq(0)").text(languages["H1049"]);
                $("#AddWebInfo>tr:eq(7)").find("td:eq(2)").text(languages["H1065"]);
                $("#btnSure").val(languages["H1037"]);
                $("#btnEsc").val(languages["H1011"]);
                $(".wrnning").text(languages["H1092"]);
                $("#delet").attr("title",languages["H1052"]);
                //$("#cookieDiv").attr("title",languages["H1009"]);
                $("#delet2").attr("title",languages["H1052"]);
                $("#dl").text(languages["H1082"]);
                $("#zh").text(languages["H1083"]);
                $("#zt").text(languages["H1070"]);
                $("#lx").text(languages["H1059"]);
                $("#xz").text(languages["H1016"]);
                $("#wzzc").text(languages["H1084"]);
                $("#gszc").html(languages["H1085"]);
                $("#ss").html(languages["H1058"]);
                $("#enableWhereVal>option:eq(0)").text(languages["H1040"]);
                $("#enableWhereVal>option:eq(1)").text(languages["H1049"]);
                $("#enableWhereVal>option:eq(2)").text(languages["H1050"]);

//                $("#tb2>thead>tr>th:eq(0)").text(languages["H1026"]);
//                $("#tb2>thead>tr>th:eq(1)").text(languages["H1054"]);
//                $("#tb2>thead>tr>th:eq(2)").text(languages["H1083"]);
//                $("#tb2>thead>tr>th:eq(3)").text(languages["H1086"]);
//                $("#tb2>thead>tr>th:eq(4)").text(languages["H1084"]);
//                $("#tb2>thead>tr>th:eq(5)").text(languages["H1085"]);
//                $("#tb2>thead>tr>th:eq(6)").text(languages["佣金"]);
//                $("#tb2>thead>tr>th:eq(7)").text(languages["H1087"]);
//                $("#tb2>thead>tr>th:eq(8)").text(languages["H1064"]);
//                $("#tb2>thead>tr>th:eq(9)").text(languages["H1089"]);
//                $("#tb2>thead>tr>th:eq(10)").text(languages["H1090"]);
//                $("#tb2>thead>tr>th:eq(11)").text(languages["H1091"]);
//                $("#tb2>thead>tr>th:eq(12)").text(languages["H1069"]);
//                //$("#tb2>thead>tr>th:eq(13)").text();
//                $("#tb2>thead>tr>th:eq(14)").text(languages["H1027"]);

                $("#sy").text(languages["H1031"]);
                $("#wy").text(languages["H1034"]);
                $("#syy").text(languages["H1032"]);
                $("#xyy").text(languages["H1033"]);
                $("#zg").text(languages["H1028"]);
                $("#tjl").text(languages["H1029"]);
                $("#g").text(languages["H1028"]);
                $("#y").text(languages["H1030"]);
            }, "/js/IndexGlobal/");
            
            }
        function GetWeb() {
            $.AjaxCommon("/ServicesFile/webBasicInfo/WebInfoService.asmx/GetDate", "", true, false, function (json) {
                if (json.d != "none") {
                    $("#addCasino").html("");
                    var result = jQuery.parseJSON(json.d);
                    var a = "";
                    $.each(result, function (i) {
                        a += "<option value=\"" + result[i].id + "\">" + result[i].namecn + "</option>";
                    });
                    $("#addCasino").html(a);
                }
            });
        }

        function setDate(data1) {
            var data2 = data1 + "," + data;
            //alert(data2);
            //return;
            $.AjaxCommon("/ServicesFile/webBasicInfo/BetaccountService.asmx/GetDateAll1", data2, false, false, function (json) {
            
                if (json.d != "none") {
                //debugger
                    $("#ShowWebInfo>tr").remove();
                    var result = jQuery.parseJSON(json.d);
                    var tr1 = $("#tr1").clone();
                    $.each(result, function (i) {
                        var tr = $("#tr1").clone();
                        tr.find("#IDNumber").text("" + (i + 1));
                        tr.find("#webID").text(result[i].userid);
                        tr.find("#pwd").text(result[i].password);
                        tr.find("#casino").text(web[result[i].casino]);
                        tr.find("#daili").text((result[i].agent).replace(/Π/g, "'"));
                        tr.find("#webpossess").text(result[i].websitePossess);
                        tr.find("#casinopossess").text(result[i].selfPossess);
                        tr.find("#commission").text(result[i].commission);
                        tr.find("#multiple").text(result[i].multiple);
                        tr.find("#webIDGroup").text(result[i].group1);
                        tr.find("#address").text((result[i].address).replace(/Π/g, "'"));
                        tr.find("#address2").text((result[i].address2).replace(/Π/g, "'"));
                        var setLang="";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            tr.find("#cook").html("<a id=\"cookieVal\">"+languages["H1048"]+"</a>");
                            tr.find("#cook").find("#cookieVal").click(function () {
                                jQuery("#cookieDiv").dialog({ modal: false });
                                $("#cookieDiv").text((result[i].cookie).replace(/Π/g, "'"));
                            });
                            tr.find("#isManual").text("" + (result[i].isquzhi == 1 ? languages["H1007"] : languages["H1008"]));
                            tr.find("#isShow").text("" + (result[i].enable == 1 ? languages["H1049"] : languages["H1050"]));
                            tr.find("#updataInfo").html((addAc == 0?"<a id=\"ReAdd\"><img title=\""+languages["H1015"]+"\" src=\"/images/Icon/page_new.gif\" /></a>":"")+"&nbsp;&nbsp;&nbsp;&nbsp;"+(fzAc==0?"<a id=\"RepeatAdd\"><img title=\""+languages["H1051"]+"\" src=\"/images/Icon/note_new.gif\" class=\"hand\" /></a>":"")+"&nbsp;&nbsp;&nbsp;&nbsp;"+(mdfAc==0?"<a id=\"update\" ><img title=\""+languages["H1009"]+"\" class=\"hand\" src=\"/images/Icon/page_edit.gif\" /></a>":"")+"&nbsp;&nbsp;&nbsp;&nbsp;"+(deleteAc==0?"<a id=\"delete\"><img title=\""+languages["H1081"]+"\" class=\"hand\" src=\"/images/Icon/list_packages.gif\" /></a>":""));
                        
                        tr.find("#updataInfo").find("#ReAdd").bind("click",function () {
                            $("#AddInfoDiv").show();
                            $("#selectAndInsert").hide();
                            GetWeb();
                        });
                        tr.find("#updataInfo").find("#RepeatAdd").click(function () {

                            $("#addID").val(result[i].userid);
                            $("#addPassword").val(result[i].password);
                            $.AjaxCommon("/ServicesFile/webBasicInfo/WebInfoService.asmx/GetDate", "", true, false, function (json1) {
                                if (json1.d != "none") {
                                    $("#addCasino").html("");
                                    var result1 = jQuery.parseJSON(json1.d);
                                    var a = "";
                                    $.each(result1, function (j) {
                                        a += "<option value=\"" + result1[j].id + "\"";
                                        if (result1[j].id == result[i].casino) {
                                            a += " selected=\"selected\"";
                                        }
                                        a += ">" + result1[j].namecn + "</option>";
                                    });
                                    $("#addCasino").html(a);
                                }
                            });
                            $("#addAgent").val((result[i].agent).replace("Π", "'"));
                            $("#addWebsitepossess").val(result[i].websitePossess);
                            $("#addSelfpossess").val(result[i].selfPossess);
                            $("#addCommission").val(result[i].commission);
                            $("#addMultiple").val(result[i].multiple);
                            $("#zemo").val((result[i].zemo).replace("Π", "'"));
                            if (result[i].enable == true) {
                                $("#addEnable").css("checked", "checked");
                            }
                            else {
                                $("#addEnable").removeAttr("checked");
                            }
                            if (result[i].isquzhi == true) {
                                $("#addIsquzhi").css("checked", "checked");
                            }
                            else {
                                $("#addIsquzhi").removeAttr("checked");
                            }
                            $("#addAddress").val((result[i].address).replace("Π", "'"));
                            $("#addAddress2").val((result[i].address2).replace("Π", "'"));
                            $("#addGroup").val(result[i].group1);
                            $("#AddCookie").val((result[i].cookie).replace("Π", "'"));
                            $("#AddInfoDiv").show();
                            $("#selectAndInsert").hide();
                        });

                        tr.find("#updataInfo").find("#update").click(function () {
                            var div = $("#AddInfoDiv").clone();
                            div.find("#headTitle").text(languages["H1053"]);
                            div.find("#hideID").val(result[i].id);
                            div.find("#addID").val(result[i].userid);
                            div.find("#addPassword").val(result[i].password);
                            $.AjaxCommon("/ServicesFile/webBasicInfo/WebInfoService.asmx/GetDate", "", true, false, function (json1) {
                                if (json1.d != "none") {
                                    div.find("#addCasino").html("");
                                    var result1 = jQuery.parseJSON(json1.d);
                                    var a = "";
                                    $.each(result1, function (j) {
                                        a += "<option value=\"" + result1[j].id + "\"";
                                        if (result1[j].id == result[i].casino) {
                                            a += " selected=\"selected\"";
                                        }
                                        a += ">" + result1[j].namecn + "</option>";
                                    });
                                    div.find("#addCasino").html(a);
                                }
                            });
                            div.find("#addAgent").val((result[i].agent).replace("Π", "'"));
                            div.find("#addWebsitepossess").val(result[i].websitePossess);
                            div.find("#addSelfpossess").val(result[i].selfPossess);
                            div.find("#addCommission").val(result[i].commission);
                            div.find("#addMultiple").val(result[i].multiple);
                            div.find("#zemo").val((result[i].zemo).replace("Π", "'"));
                            div.find("#addGroup").val(result[i].group1);
                            div.find("#addAddress").val((result[i].address).replace("Π", "'"));
                            div.find("#addAddress2").val((result[i].address2).replace("Π", "'"));
                            div.find("#AddCookie").val((result[i].cookie).replace("Π", "'"));
                            if (result[i].enable == true) {
                                div.find("#addEnable").css("checked", "checked");
                            }
                            else {
                                div.find("#addEnable").removeAttr("checked");
                            }
                            if (result[i].isquzhi == true) {
                                div.find("#addIsquzhi").css("checked", "checked");
                            }
                            else {
                                div.find("#addIsquzhi").removeAttr("checked");
                            }
                            var setLang="";
                    setLang = $.SetOrGetLanguage(setLang, function () {
                        languages = language;
                        div.find("#trEnd").html("<td align=\"center\" colspan=\"4\"><input type=\"button\" id=\"upda\" class=\"btn_02\" onmouseover=\"this.className='btn_02_h'\" onmouseout=\"this.className='btn_02'\"  value=\""+languages["H1009"]+"\" /><input type=\"button\"  id=\"upEsc\" class=\"btn_02\" onmouseover=\"this.className='btn_02_h'\" onmouseout=\"this.className='btn_02'\" onclick=\"close_list()\" value=\""+languages["H1011"]+"\" /></td></td>");
                    
                            
                            div.show();
                            div.find("#trEnd").find("#upEsc").click(function () {
                                tr1.remove();
                            });
                            div.find("#trEnd").find("#upda").click(function () {
                                var pd = 0;
                                $.each(div.find("#AddWebInfo").find(":text"), function (i) {  
                                    if(jQuery(this).attr("id")!="addAddress" && jQuery(this).attr("id")!="addAddress2" && jQuery(this).attr("id")!="AddCookie" && jQuery(this).attr("id")!="zemo"){
                                        if (div.find("#AddWebInfo").find(":text:eq(" + i + ")").val() == "") {
                                            alert(languages["H1004"]);
                                            pd = 1;
                                            return false;
                                        }
                                    }
                                });
                                if (pd) {
                                    return false;
                                }
                                var namePattern = /^(0|[1-9][0-9]*)$/;
                                if (!namePattern.test(div.find("#addGroup").val()) || div.find("#addGroup").val().length > 4) {
                                    var setLang="";
                                    setLang = $.SetOrGetLanguage(setLang, function () {
                                        languages = language;
                                        alert(languages["H1041"]);
                                    }, "/js/IndexGlobal/");
                                    return false;
                                }
                                var poss = /^(([0]\.[0-9]{1,3})|([1]))$/;
                                if (!poss.test(div.find("#addWebsitepossess").val())) {
                                var setLang="";
                                    setLang = $.SetOrGetLanguage(setLang, function () {
                                        languages = language;
                                        alert(languages["H1075"]);
                                    }, "/js/IndexGlobal/"); 
                                    
                                    return false;
                                }
                                if (!poss.test(div.find("#addSelfpossess").val())) {
                                var setLang="";
                                    setLang = $.SetOrGetLanguage(setLang, function () {
                                        languages = language;
                                        alert(languages["H1075"]);
                                    }, "/js/IndexGlobal/");
                                    return false;
                                }
                                if ((div.find("#addWebsitepossess").val() * 100.00 + div.find("#addSelfpossess").val() * 100.00) / 100.00 > 1) {
                                    var setLang="";
                                    setLang = $.SetOrGetLanguage(setLang, function () {
                                        languages = language;
                                        alert(languages["H1076"]);
                                    }, "/js/IndexGlobal/");
                                    return false;
                                }
                                var Comm = /^(0|([1-9][0-9]*\.[0-9]{0,3})|([0-9]*\.[0-9]{0,3}))$/;
                                if (!Comm.test(div.find("#addCommission").val())) {
                                    var setLang="";
                                    setLang = $.SetOrGetLanguage(setLang, function () {
                                        languages = language;
                                        alert(languages["H1077"]);
                                    }, "/js/IndexGlobal/");
                                    return false;
                                }
                                if (!Comm.test(div.find("#addMultiple").val())) {
                                    var setLang="";
                                    setLang = $.SetOrGetLanguage(setLang, function () {
                                        languages = language;
                                        alert(languages["H1078"]);
                                    }, "/js/IndexGlobal/");
                                    
                                    return false;
                                }
                                data = "id:'" + div.find("#hideID").val() + "',casino:'" + div.find("#addCasino").val() + "',userid:'" + div.find("#addID").val() + "',password:'" + div.find("#addPassword").val() + "',";
                                data += "agent:'" + div.find("#addAgent").val().replace("'", "Π") + "',websitepossess:'" + div.find("#addWebsitepossess").val() + "',selfpossess:'" + div.find("#addSelfpossess").val() + "',";
                                data += "commission:'" + div.find("#addCommission").val() + "',multiple:'" + div.find("#addMultiple").val() + "',zemo:'" + div.find("#zemo").val().replace("'", "Π") + "',";
                                data += "group:'" + div.find("#addGroup").val() + "',address:'" + div.find("#addAddress").val().replace("'", "Π") + "',address2:'" + div.find("#addAddress2").val().replace("'", "Π") + "',";
                                data += "cookie:'" + div.find("#AddCookie").val().replace("'", "Π") + "',isquzhi:'" + (div.find("#addIsquzhi").attr("checked") == true ? 1 : 0) + "',";
                                data += "enable:'" + (div.find("#addEnable").attr("checked") == true ? 1 : 0) + "',ip:'" + $("#IpAddress").val() + "'";
                                $.AjaxCommon("/ServicesFile/webBasicInfo/BetaccountService.asmx/UpdateInfo1", data, false, false, function (json) {
                                    if (json.d != "none") {
                                    }
                                });
                                //debugger
                                data = "casino:'0',dali:'',id:'',enable:'-1',webPoss:'',Company:''";
                                jQuery.AjaxCommon("/ServicesFile/webBasicInfo/BetaccountService.asmx/getAllCount1", data, true, false, function (json) {
                                //debugger
                                    count = parseInt(json.d);
                                });
                                if (count % 20 == 0) {
                                    page = count / 20;
                                }
                                else {
                                    page = count / 20 + 1;
                                }
                                IsPage(parseInt(page), count, '20', 'IDex', 'IDexC');
                            });
                            }, "/js/IndexGlobal/");
                            tr1.find("td:gt(0)").remove();
                            tr1.find("td:eq(0)").attr("colspan", "16");
                            tr1.find("td:eq(0)").text("");
                            tr1.find("td:eq(0)").append(div);
                            tr.after(tr1);
                        });

                        tr.find("#updataInfo").find("#delete").click(function () {

                            jQuery("#delet").dialog({ modal: true });
                            jQuery("#btnSure").unbind("click");
                            jQuery("#btnSure").bind("click", function () {
                                $("#delet").dialog("close");
                                var data = "id:'" + result[i].id + "'";
                                $.AjaxCommon("/ServicesFile/webBasicInfo/BetaccountService.asmx/DeleteInfo1", data, false, false, function (json1) {
                                    if (json1.d != "none") {
                                        if (json1.d == "True") {
                                            data = "casino:'0',dali:'',id:'',enable:'-1',webPoss:'',Company:''";
                                            jQuery.AjaxCommon("/ServicesFile/webBasicInfo/BetaccountService.asmx/getAllCount1", data, false, false, function (json) {
                                                count = parseInt(json.d);
                                            });
                                            if (count % 20 == 0) {
                                                page = count / 20;
                                            }
                                            else {
                                                page = count / 20 + 1;
                                            }
                                            IsPage(parseInt(page), count, '20', 'IDex', 'IDexC');
                                        }
                                    }
                                });
                            });
                            jQuery("#btnEsc").unbind("click");
                            jQuery("#btnEsc").bind("click", function () {
                                $("#delet").dialog("close");
                            });
                        });
                        tr.appendTo("#ShowWebInfo");
                                                }, "/js/IndexGlobal/");
                    });
                    if (jQuery("#ShowWebInfo>tr") <= 0) {
                        var tr = jQuery("#tr1").clone();
                        tr.find("td:gt(0)").remove();
                        tr.find("td:eq(0)").attr("colspan", "15");
                        var setLang="";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            tr.find("td:eq(0)").text(languages["H1013"]);
                        }, "/js/IndexGlobal/");
                        jQuery("#tb2 tfoot tr:eq(1)").hide();
                    }
                    else
                    {
                        jQuery("#tb2 tfoot tr:eq(1)").show();
                    }
                    jQuery("#tb2").alterBgColor({ odd: "odd", even: "even", selected: "selected", tdCss: "tdCss" });
                }
            });
        }
    </script>
</head>
<body>
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="tzzh">网站最高投注账号</p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<!--主题部分开始=========================================================================================-->
<input type="hidden" id="language" value="tw" />


    <form id="form1" runat="server">
    <input type="hidden" value="<%=ip %>" id="IpAddress" />
    <div id="selectAndInsert" class="top_banner h24">
    <%if (addAc)
      { %>
    <div class="fl " id="AddButtonDiv">
    <a  id="AddInfo" class="fa_add"><span class="fa_add_in"></span></a>
    </div>
    <%} %>
    <%if (slt)
      { %>
    <div id="selectDiv" class="fl mleft_10">
    <a id="wz">网站</a><select id="webWhereVal"></select>&nbsp;&nbsp;&nbsp;
    <a id="dl">代理</a><input type="text" id="daliWhereVal"  class="text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'"   />&nbsp;&nbsp;&nbsp;
    <a id="zh">账号</a><input type="text" id="idWhereVal" class="text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'"   />&nbsp;&nbsp;&nbsp;
    <a id="zt">状态</a><select id="enableWhereVal"><option value="-1">全部</option><option value="0">禁用</option><option value="1">启用</option></select>&nbsp;&nbsp;&nbsp;
    <a id="wzzc">网站占成</a><input type="text" id="webPossWhereVal" class="text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'"  />&nbsp;&nbsp;&nbsp;
    <a id="gszc">公司占成</a><input type="text" id="CompanyWhereVal" class="text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'"  />
     <a  id="selectSure" class="fa_saurch"><span id="ss" class="fa_saurch_in">搜索</span></a>
    </div>
    <%} %>
    </div>
    <%if (addAc)
      { %>
    <div  class="tc" id="AddInfoDiv" style="display:none">
    <input type="hidden" value="" id="hideID" />

<div id="add_list" class="new_tr ">
<div align="center">
<table border="0" class="boder_none">
<tr>
<td class="" colspan="4" id="headTitle" ><input type="checkbox" id="IsContinuous"/><a id="lx">连续新增</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a id="xz">新增网站信息</a></td>
</tr>
<tbody id="AddWebInfo">
<tr>
<td class="tr">网站：</td>
<td><select id="addCasino" ></select></td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td class="tr">网站账号：</td>
<td><input type="text" id="addID" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" /></td>
<td class="tr">密码：</td>
<td><input type="text" id="addPassword" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" /></td>
</tr>
<tr>
<td class="tr">外来代理：</td>
<td><input id="addAgent" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" type="text" /></td>
<td class="tr">网站占成：</td>
<td><input id="addWebsitepossess" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" type="text" /></td>
</tr>
<tr>
<td class="tr">公司占成：</td>
<td><input  id="addSelfpossess" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" type="text" /></td>
<td class="tr">佣金：</td>
<td><input  id="addCommission" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" type="text" /></td>
</tr>
<tr>
<td class="tr">系数：</td>
<td><input  id="addMultiple"  class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" type="text" /></td>
<td class="tr">账号对应的网址：</td>
<td><input id="addAddress" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" type="text" /></td>
</tr>

<tr>
<td class="tr">账号登录后的网址：</td>
<td><input id="addAddress2" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" type="text" /></td>
<td class="tr">账号分组：</td>
<td><input id="addGroup" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" type="text" /></td>
</tr>
<tr>
<td class="tr">备注：</td>
<td><input id="zemo" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" type="text" /></td>
<td class="tr">Cookie：</td>
<td><input id="AddCookie" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'" type="text" /></td>
</tr>
<tr>
<td class="tr">启用：</td>
<td><input type="checkbox" checked id="addEnable" /></td>
<td class="tr">手工取值：</td>
<td><input type="checkbox" checked id="addIsquzhi" /></td>
</tr>

<tr  id="trEnd">
<td align="center" colspan="4">
<input type="button" id="sure" class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'"  value="保存" />
<input type="button"  id="esc" class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'"  value="取消" />
</td>
</tr>
</tbody>
</table>
</div>
<div class="new_trfoot"></div>
</div>




    
    </div>
    <%} %>
    <table class="tab2" id="tb2" style="width:100%;text-align:center" border="0" cellpadding="0" cellspacing="0">
        <thead>
        <tr>
        <th>序号</th>
        <th>网站</th>
        <th>账号</th>
        <th>密码</th>
        <th>外来代理</th>
        <th>网站占成</th>
        <th>公司占成</th>
        <th>佣金</th>
        <th>系数</th>
        <th>账号分组</th>
        <th>账号所属网站</th>
        <th>账号登录网站</th>
        <th>账号状态</th>
        <th>是否手工取值</th>
        <%if (passwordAc)
              { %>
        <th>Cookie</th>
        <%} %>
            <%if (fzAc || deleteAc || mdfAc || addAc)
              { %>
        <th>操作</th>
        <%} %>
        </tr>
        </thead>
        <tbody id="ShowWebInfo">
        </tbody>
        <tfoot>
        <tr id="tr1">
            <td id="IDNumber"></td>
            <td id="casino"></td>
            <td id="webID"></td>
            <td id="pwd"></td>
            <td id="daili"></td>
            <td id="webpossess"></td>
            <td id="casinopossess"></td>
            <td id="commission"></td>
            <td id="multiple"></td>
            <td id="webIDGroup"></td>
            <td id="address"></td>
            <td id="address2"></td>
            <td id="isShow"></td>
            <td id="isManual"></td>
            <%if (passwordAc)
              { %>
            <td id="cook"></td>
            <%} %>
            <%if (fzAc || deleteAc || mdfAc || addAc)
              { %>
            <td id="updataInfo"></td>
            <%} %>
            </tr>
            <tr class="tc"><td colspan="16"><div id="pageDiv" class="grayr"><span id="zg">总共</span><label id="infoCount"></label><span id="tjl">条记录</span>,<span id="g">共</span><label id="pageCount"></label><span id="y">页</span><a style="cursor:hand" id="sy"> 首页 </a><a style="cursor:hand" id="syy"> 上一页 </a><span id="pageSpan"></span><a style="cursor:hand" id="xyy"> 下一页 </a><a style="cursor:hand" id="wy"> 尾页 </a></div></td></tr>
        </tfoot>
    </table>
    <div id="cookieDiv" title="cookie" style="display:none">
<div class="showdiv">
</div>
</div>
    <div id="delet" title="删除" style="display:none">
<div class="showdiv">
<p class="wrnning">确定要转入备案吗？</p>
<div align="center" class="mtop_50">
<input type="button" class="btn_02" id="btnSure" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="确定" />
<input type="button" class="btn_02" id="btnEsc" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="取消" />
</div>

</div>
</div>

<!-- 消息提示DIV -->
    <div id="delet2" title="提示" style="display:none">

    <div id="reportDiv" class="showdiv">
    <div class=" h30">

</div>
    <div align="center" class="mtop_50">
<input type="button" class="btn_02" id="closeButton" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="关闭" />
</div>
</div>
    </div>
    <!-- 消息提示DIV结束 -->
    </form>
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