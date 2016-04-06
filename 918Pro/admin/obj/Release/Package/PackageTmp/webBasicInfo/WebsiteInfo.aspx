<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="WebsiteInfo.aspx.cs"
    Inherits="Admin.WebsiteInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jQueryCommon.js" type="text/javascript"></script>
    <script src="/js/page/pageJs.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var data = "";
        var count = 0;
        var page = 0;
        var languages = "";
        $(function () {
            SetGlobal("");

        })

        var languages = "";
        function SetGlobal(setLang) {
            setLang = $.SetOrGetLanguage(setLang, function () {
                languages = language;

                $("#AddButtonDiv").show();
                $("#AddInfoDiv").hide();
                $("#delet").hide();
                $("#delet2").hide();
                jQuery.AjaxCommon("/ServicesFile/webBasicInfo/WebInfoService.asmx/getCount", "", false, false, function (json) {
                    count = parseInt(json.d);
                });
                if (count % 20 == 0) {
                    page = count / 20;
                }
                else {
                    page = count / 20 + 1;
                }
                IsPage(parseInt(page), count, '20', 'IDex', 'IDexC');
                $("#btnSure").click(function () {
                    $("#delet").dialog("close");
                });
                $("#closeButton").click(function () {
                    jQuery("#delet2").dialog("close");
                });
                $("#addNamecn").blur(function () {
                    if ($("#addNamecn").val() == "") {
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            $("#addNamecnlbl").html(languages["H1000"] + "&nbsp;&nbsp;&nbsp;");
                        }, "/js/IndexGlobal/");

                        return false;
                    }
                    var cn = $("#addNamecn").val();
                    if (cn.replace(/[^\x00-\xff]/g, "aa").length > 50) {
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            $("#addNamecnlbl").html(languages["H1001"] + "&nbsp;&nbsp;&nbsp;");
                        }, "/js/IndexGlobal/");

                        return false;
                    }
                    $("#addNamecnlbl").html("");
                });

                $("#addNametw").blur(function () {
                    if ($("#addNametw").val() == "") {
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            $("#addNametwlbl").html(languages["H1000"] + "&nbsp;&nbsp;&nbsp;");
                        }, "/js/IndexGlobal/");
                        return false;
                    }
                    var tw = $("#addNametw").val();
                    if (tw.replace(/[^\x00-\xff]/g, "aa").length > 50) {
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            $("#addNametwlbl").html(languages["H1001"] + "&nbsp;&nbsp;&nbsp;");
                        }, "/js/IndexGlobal/");
                        return false;
                    }
                    $("#addNametwlbl").html("");
                });
                $("#addNameen").blur(function () {
                    var en = $("#addNameen").val();
                    if ($("#addNameen").val() == "") {
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            $("#addNameenlbl").html(languages["H1000"] + "&nbsp;&nbsp;&nbsp;");
                        }, "/js/IndexGlobal/");
                        return false;
                    }
                    if (en.replace(/[^\x00-\xff]/g, "aa").length > 50) {
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            $("#addNameenlbl").html(languages["H1001"] + "&nbsp;&nbsp;&nbsp;");
                        }, "/js/IndexGlobal/");
                        return false;
                    }
                    $("#addNameenlbl").html("");
                });
                $("#addNameth").blur(function () {
                    var th = $("#addNameth").val();
                    if ($("#addNameth").val() == "") {
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            $("#addNamethlbl").html(languages["H1000"] + "&nbsp;&nbsp;&nbsp;");
                        }, "/js/IndexGlobal/");
                        return false;
                    }
                    if (th.replace(/[^\x00-\xff]/g, "aa").length > 50) {
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            $("#addNamethlbl").html(languages["H1001"] + "&nbsp;&nbsp;&nbsp;");
                        }, "/js/IndexGlobal/");
                        return false;
                    }
                    $("#addNamethlbl").html("");
                });
                $("#addNametv").blur(function () {
                    var tv = $("#addNametv").val();
                    if ($("#addNametv").val() == "") {
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            $("#addNametvlbl").html(languages["H1000"] + "&nbsp;&nbsp;&nbsp;");
                        }, "/js/IndexGlobal/");
                        return false;
                    }
                    if (tv.replace(/[^\x00-\xff]/g, "aa").length > 50) {
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            $("#addNametvlbl").html(languages["H1000"] + "&nbsp;&nbsp;&nbsp;");
                        }, "/js/IndexGlobal/");
                        return false;
                    }
                    $("#addNametvlbl").html("");
                });
                $("#addAddress").blur(function () {
                    var address = $("#addAddress").val();
                    if ($("#addAddress").val() == "") {
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            $("#addAddresslbl").html(languages["H1000"] + "&nbsp;&nbsp;&nbsp;");
                        }, "/js/IndexGlobal/");
                        return false;
                    }
                    if (address.replace(/[^\x00-\xff]/g, "aa").length > 60) {
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            $("#addAddresslbl").html(languages["H1002"] + "&nbsp;&nbsp;&nbsp;");
                        }, "/js/IndexGlobal/");
                        return false;
                    }
                    jQuery("#addAddresslbl").html("");
                });
                $("#addOrd").blur(function () {
                    var namePattern = /^(0|[1-9][0-9]*)$/;
                    if (!namePattern.test($("#addOrd").val()) || $("#addOrd").val().length >= 4) {
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            $("#addOrdlbl").html(languages["H1003"] + "&nbsp;&nbsp;&nbsp;");
                        }, "/js/IndexGlobal/");

                        return false;
                    }
                    $("#addOrdlbl").html("");
                });
                $("#AddInfo").click(function () {
                    $("#addNamecn").val("");
                    $("#addNametw").val("");
                    $("#addNameen").val("");
                    $("#addNameth").val("");
                    $("#addNametv").val("");
                    $("#addAddress").val("");
                    $("#addOrd").val("");
                    $("#AddInfoDiv").show();
                    $("#AddButtonDiv").hide();
                });
                $("#esc").click(function () {
                    $("#AddButtonDiv").show();
                    $("#AddInfoDiv").hide();
                });
                $("#sure").click(function () {
                    var pd = 0;
                    $.each($("#AddWebInfo").find(":text"), function (i) {
                        if ($("#AddWebInfo").find(":text:eq(" + i + ")").val() == "") {
                            var setLang = "";
                            setLang = $.SetOrGetLanguage(setLang, function () {
                                languages = language;
                                alert(languages["H1004"]);
                            }, "/js/IndexGlobal/");

                            pd = 1;
                            return false;
                        }
                    });
                    $.each($("#AddWebInfo").find("label"), function (i) {
                        if ($("#AddWebInfo").find("label:eq(" + i + ")").text() != "") {
                            $("#delet").dialog({ modal: true });
                            pd = 1;
                            return false;
                        }
                    });
                    if (pd) {
                        return false;
                    }
                    AddDate();
                    $("#AddButtonDiv").show();
                    $("#AddInfoDiv").hide();
                    jQuery.AjaxCommon("/ServicesFile/webBasicInfo/WebInfoService.asmx/getCount", "", true, false, function (json) {
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

                jQuery("#wzxx").text(languages["H1014"]);
                jQuery(".fa_add_in").text(languages["H1015"]);
                jQuery("#headTitle").text(languages["H1016"]);
                jQuery("#AddWebInfo>tr:eq(0)").find("td:eq(0)").text(languages["H1017"]);
                jQuery("#AddWebInfo>tr:eq(0)").find("td:eq(3)").text(languages["H1018"]);
                jQuery("#AddWebInfo>tr:eq(1)").find("td:eq(0)").text(languages["H1019"]);
                jQuery("#AddWebInfo>tr:eq(1)").find("td:eq(3)").text(languages["H1020"]);
                jQuery("#AddWebInfo>tr:eq(2)").find("td:eq(0)").text(languages["H1021"]);
                jQuery("#AddWebInfo>tr:eq(2)").find("td:eq(3)").text(languages["H1022"]);
                jQuery("#AddWebInfo>tr:eq(3)").find("td:eq(0)").text(languages["H1023"]);
                jQuery("#AddWebInfo>tr:eq(3)").find("td:eq(3)").text(languages["H1024"]);
                jQuery("#sure").val(languages["H1025"]);
                jQuery("#esc").val(languages["H1011"]);

                jQuery("#tb2>thead>tr>th:eq(0)").text(languages["H1026"]);
                jQuery("#tb2>thead>tr>th:eq(1)").text(languages["H1017"]);
                jQuery("#tb2>thead>tr>th:eq(2)").text(languages["H1018"]);
                jQuery("#tb2>thead>tr>th:eq(3)").text(languages["H1019"]);
                jQuery("#tb2>thead>tr>th:eq(4)").text(languages["H1020"]);
                jQuery("#tb2>thead>tr>th:eq(5)").text(languages["H1021"]);
                jQuery("#tb2>thead>tr>th:eq(6)").text(languages["H1022"]);
                jQuery("#tb2>thead>tr>th:eq(7)").text(languages["H1023"]);
                jQuery("#tb2>thead>tr>th:eq(8)").text(languages["H1024"]);
                jQuery("#tb2>thead>tr>th:eq(9)").text(languages["H1027"]);

                jQuery("#delet").attr("title", languages["H1035"]);
                jQuery("#delet2").attr("title", languages["H1038"]);
                jQuery(".wrnning").text(languages["H1036"]);
                jQuery("#btnSure").val(languages["H1037"]);
                jQuery("#closeButton").val(languages["H1039"]);

                $("#sy").text(languages["H1031"]);
                $("#wy").text(languages["H1034"]);
                $("#syy").text(languages["H1032"]);
                $("#xyy").text(languages["H1033"]);
                $("#zg").text(languages["H1028"]);
                $("#tjl").text(languages["H1029"]);
                $("#g").text(languages["H1028"]);
                $("#y").text(languages["H1030"]);
            });
        }


        function IsNull(obj, errobjId) {
            if (jQuery(obj).val() == "") {
                var setLang = "";
                setLang = $.SetOrGetLanguage(setLang, function () {
                    languages = language;
                    jQuery(obj).parent().parent().find("#" + errobjId).html(languages["H1000"]);
                }, "/js/IndexGlobal/");
                
                return false;
            }
        }

        function AddDate() {
            var data = "namecn:'" + $("#addNamecn").val() + "', nametw:'" + $("#addNametw").val() + "', nameen:'" + $("#addNameen").val().replace(/'/g, "Π") + "', nameth:'" + $("#addNameth").val().replace(/'/g, "Π") + "', nametv:'" + $("#addNametv").val().replace(/'/g, "Π") + "', display:'" + ($("#addDisplay").attr("checked") == true ? 1 : 0) + "', address:'" + $("#addAddress").val().replace(/'/g, "Π") + "', ord:'" + $("#addOrd").val() + "', ip:'" + $("#IpAddress").val() + "'";
            $.AjaxCommon("/ServicesFile/webBasicInfo/WebInfoService.asmx/insertInfo", data, false, false, function (json) {
                if (json.d != "none") {
                    if (json.d == "-1") {
                        jQuery("#delet2").dialog({ model: true });
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            jQuery("#delet2>div:eq(0)>div:eq(0)").text(languages["H1005"]);
                        }, "/js/IndexGlobal/");
                        
                        return false;
                    }
                }
                var setLang = "";
                setLang = $.SetOrGetLanguage(setLang, function () {
                    languages = language;
                    alert(languages["H1006"]);
                }, "/js/IndexGlobal/");
                
            });
        }

        function setDate(data) {
            jQuery.AjaxCommon("/ServicesFile/webBasicInfo/WebInfoService.asmx/GetDate", data, false, false, function (json) {
                if (json.d != "none") {
                    var result = jQuery.parseJSON(json.d);
                    jQuery("#ShowWebInfo>tr").remove();
                    var tr1 = jQuery("#tr1").clone(true);
                    jQuery.each(result, function (i) {
                        var tr = jQuery("#tr1").clone(true);
                        tr.find("#IDNumber").text("" + (i + 1));
                        tr.find("#NameCn").text(result[i].namecn);
                        tr.find("#NameTw").text(result[i].nametw);
                        tr.find("#NameEn").text((result[i].nameen).replace("Π", "'"));
                        tr.find("#NameTh").text((result[i].nameth).replace("Π", "'"));
                        tr.find("#NameTv").text((result[i].nametv).replace("Π", "'"));
                        var setLang = "";
                            tr.find("#IsShow").text(result[i].display == "true" ? languages["H1007"] : languages["H1008"]);
                            tr.find("#updataInfo").html("<a id=\"labUpdate\">" + languages["H1009"] + "</a>");

                        tr.find("#webPath").text((result[i].address).replace("Π", "'"));
                        tr.find("#showNumber").text(result[i].ord);

                        tr.find("#updataInfo").find("#labUpdate").unbind("click").bind("click", function () {
                            var div = $("#AddInfoDiv").clone();
                            var setLang = "";
                                div.find("#headTitle").text(languages["H1010"]);

                            div.find("#addNamecnlbl").html("");
                            div.find("#addNametwlbl").html("");
                            div.find("#addNameenlbl").html("");
                            div.find("#addNamethlbl").html("");
                            div.find("#addNametvlbl").html("");
                            div.find("#addAddresslbl").html("");
                            div.find("#addOrdlbl").html("");
                            div.find("#hideID").val(result[i].id);
                            div.find("#addNamecn").val(result[i].namecn);
                            div.find("#addNametw").val(result[i].nametw);
                            div.find("#addNameen").val((result[i].nameen).replace(/Π/g, "'"));
                            div.find("#addNameth").val((result[i].nameth).replace(/Π/g, "'"));
                            div.find("#addNametv").val((result[i].nametv).replace(/Π/g, "'"));
                            if (result[i].display == "true") {
                                div.find("#addDisplay").attr("checked", "checked");
                            }
                            else {
                                div.find("#addDisplay").removeAttr("checked");
                            }
                            div.find("#addDisplay").parent().css("align", "left");
                            div.find("#addAddress").val(result[i].address);
                            div.find("#addOrd").val(result[i].ord);
                            var setLang = "";
                                div.find("#trEnd").html("<td align=\"center\" colspan=\"4\"><input type=\"button\" id=\"upda\" class=\"btn_02\" onmouseover=\"this.className='btn_02_h'\" onmouseout=\"this.className='btn_02'\"  value=\"" + languages["H1009"] + "\" /><input type=\"button\"  id=\"upEsc\" class=\"btn_02\" onmouseover=\"this.className='btn_02_h'\" onmouseout=\"this.className='btn_02'\"  value=\"" + languages["H1011"] + "\" /></td></td>");

                            div.show();
                            div.find("#trEnd").find("#upEsc").click(function () {
                                tr1.remove();
                            });
                            div.find("#addNamecn").blur(function () {
                                if (div.find("#addNamecn") == "") {
                                    var setLang = "";
                                        $("#addNamecnlbl").html(languages["H1000"] + "&nbsp;&nbsp;&nbsp;");
                                    return false;
                                }
                                var cn = div.find("#addNamecn").val();
                                if (cn.replace(/[^\x00-\xff]/g, "aa").length > 50) {
                                    var setLang = "";
                                        $("#addNamecnlbl").html(languages["H1001"] + "&nbsp;&nbsp;&nbsp;");
                                    return false;
                                }
                                div.find("#addNamecnlbl").html("");
                            });

                            div.find("#addNametw").blur(function () {
                                if (div.find("#addNametw").val() == "") {
                                    var setLang = "";
                                        $("#addNametwlbl").html(languages["H1000"] + "&nbsp;&nbsp;&nbsp;");
                                    return false;
                                }
                                var tw = div.find("#addNametw").val();
                                if (tw.replace(/[^\x00-\xff]/g, "aa").length != div.find("#addNametw").val().length * 2) {
                                    var setLang = "";
                                        $("#addNametwlbl").html(languages["H1001"] + "&nbsp;&nbsp;&nbsp;");
                                    return false;
                                }
                                div.find("#addNametwlbl").html("");
                            });
                            div.find("#addNameen").blur(function () {
                                var en = $("#addNameen").val();
                                if (div.find("#addNameen").val() == "") {
                                    var setLang = "";
                                        $("#addNameenlbl").html(languages["H1000"] + "&nbsp;&nbsp;&nbsp;");
                                    return false;
                                }
                                if (en.replace(/[^\x00-\xff]/g, "aa").length > 50) {
                                    var setLang = "";
                                        $("#addNameenlbl").html(languages["H1001"] + "&nbsp;&nbsp;&nbsp;");
                                    return false;
                                }
                                div.find("#addNameenlbl").html("");
                            });
                            div.find("#addNameth").blur(function () {
                                var th = div.find("#addNameth").val();
                                if (div.find("#addNameth").val() == "") {
                                    var setLang = "";
                                        $("#addNamethlbl").html(languages["H1000"] + "&nbsp;&nbsp;&nbsp;");
                                    return false;
                                }
                                if (th.replace(/[^\x00-\xff]/g, "aa").length > 50) {
                                    var setLang = "";
                                        $("#addNamethlbl").html(languages["H1001"] + "&nbsp;&nbsp;&nbsp;");
                                    return false;
                                }
                                div.find("#addNamethlbl").html("");
                            });
                            div.find("#addNametv").blur(function () {
                                var tv = div.find("#addNametv").val();
                                if (div.find("#addNametv").val() == "") {
                                    var setLang = "";
                                        $("#addNametvlbl").html(languages["H1000"] + "&nbsp;&nbsp;&nbsp;");
                                    return false;
                                }
                                if (tv.replace(/[^\x00-\xff]/g, "aa").length > 50) {
                                    var setLang = "";
                                        $("#addNametvlbl").html(languages["H1001"] + "&nbsp;&nbsp;&nbsp;");
                                    return false;
                                }
                                div.find("#addNametvlbl").html("");
                            });
                            div.find("#addAddress").blur(function () {
                                var address = $("#addAddress").val();
                                if (div.find("#addAddress").val() == "") {
                                    var setLang = "";
                                        $("#addAddresslbl").html(languages["H1000"] + "&nbsp;&nbsp;&nbsp;");
                                    return false;
                                }
                                if (address.replace(/[^\x00-\xff]/g, "aa").length > 60) {
                                    var setLang = "";
                                        $("#addAddresslbl").html(languages["H1002"] + "&nbsp;&nbsp;&nbsp;");
                                    return false;
                                }
                                div.find("#addAddresslbl").html("");
                            });
                            div.find("#addOrd").blur(function () {
                                var namePattern = /^(0|[1-9][0-9]*)$/;
                                if (!namePattern.test(div.find("#addOrd").val()) || div.find("#addOrd").val().length >= 4) {
                                    var setLang = "";
                                        $("#addOrdlbl").html(languages["H1003"] + "&nbsp;&nbsp;&nbsp;");
                                    return false;
                                }
                                div.find("#addOrdlbl").html("");
                            });
                            div.find("#trEnd").find("#upda").click(function () {
                                var pd = 0;
                                $.each(div.find("#AddWebInfo").find(":text"), function (i) {
                                    if (div.find("#AddWebInfo").find(":text:eq(" + i + ")").val() == "") {
                                        var setLang = "";
                                            alert(languages["H1004"]);
                                        
                                        pd = 1;
                                        return false;
                                    }
                                });
                                $.each(div.find("#AddWebInfo").find("label"), function (i) {
                                    if (div.find("#AddWebInfo").find("label:eq(" + i + ")").text() != "") {
                                        $("#delet").dialog({ modal: true });
                                        pd = 1;
                                        return false;
                                    }
                                });
                                if (pd) {
                                    return false;
                                }
                                var data = "idNum:'" + div.find("#hideID").val() + "',namecn:'" + div.find("#addNamecn").val() + "', nametw:'" + div.find("#addNametw").val() + "', nameen:'" + div.find("#addNameen").val().replace("'", "Π") + "', nameth:'" + div.find("#addNameth").val().replace("'", "Π") + "', nametv:'" + div.find("#addNametv").val().replace("'", "Π") + "', display:'" + (div.find("#addDisplay").attr("checked") == true ? 1 : 0) + "', address:'" + div.find("#addAddress").val().replace("'", "Π") + "', ord:'" + div.find("#addOrd").val() + "', ip:'" + $("#IpAddress").val() + "'";
                                $.AjaxCommon("/ServicesFile/webBasicInfo/WebInfoService.asmx/UpdateInfo", data, false, false, function (json) {
                                    if (json.d != "none") {

                                    }
                                });
                                var setLang = "";
                                setLang = $.SetOrGetLanguage(setLang, function () {
                                    languages = language;
                                    alert(languages["H1012"]);
                                }, "/js/IndexGlobal/");
                                
                                jQuery.AjaxCommon("/ServicesFile/webBasicInfo/WebInfoService.asmx/getCount", "", false, false, function (json) {
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
                            tr1.find("td:gt(0)").remove();
                            tr1.find("td:eq(0)").attr("colspan", "10");
                            tr1.find("td:eq(0)").text("");
                            tr1.find("td:eq(0)").append(div);
                            tr.after(tr1);
                        });
                        tr.appendTo("#ShowWebInfo");
                    });s
                    jQuery("#tb2").alterBgColor({ odd: "odd", even: "even", selected: "selected", tdCss: "tdCss" });
                    if (jQuery("#ShowWebInfo>tr").length == 0) {
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            jQuery("#ShowWebInfo").html("<tr><td colspan=\"" + jQuery("#tb2>thead>tr>th").length + "\" align=\"center\">"+languages["H1013"]+"</td></tr>");
                        }, "/js/IndexGlobal/");
                        
                        jQuery("#tb2>tfoot>tr:eq(1)").hide();
                    }
                    else {
                        jQuery("#tb2>tfoot>tr:eq(1)").show();
                    }
                }
            });
        }
    </script>
</head>
<body>
    <table id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
        <thead>
            <tr class="h30">
                <th width="12" class="tab_top_l">
                </th>
                <th width="*" class="tab_top_m">
                    <p id="wzxx">
                        网站信息</p>
                </th>
                <th width="16" class="tab_top_r">
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td class="tab_middle_l">
                </td>
                <td>
                    <div id="main">
                        <!--主题部分开始=========================================================================================-->
                        <form id="form1" runat="server">
                        <input type="hidden" value="<%=ip %>" id="IpAddress" />
                        <%if (addAc)
                          { %>
                        <div class="top_banner h24" id="AddButtonDiv" style="display:none">
                            <a id="AddInfo" class="fa_add"><span class="fa_add_in">新增</span></a>
                        </div>
                        <%} %>
                        <div class="tc" id="AddInfoDiv" style="display:none">
                            <input type="hidden" value="" id="hideID" />
                            <div id="add_list" class="new_tr ">
                                <div align="center">
                                    <table border="0" class="boder_none">
                                    <thead>
                                        <tr>
                                            <th class="" colspan="6" id="headTitle">
                                                新增网站信息
                                            </th>
                                        </tr>
                                        </thead>
                                        <tbody id="AddWebInfo">
                                            <tr>
                                                <td class="tr">
                                                    简体中文名称
                                                </td>
                                                <td class="tl">
                                                    <input type="text" id="addNamecn" maxlength="50" class="text_01" onmousemove="this.className='text_01_h'"
                                                        onmouseout="this.className='text_01'" />
                                                </td>
                                                <td class="tl">
                                                    <label id="addNamecnlbl" style="color: Red">
                                                    </label>
                                                </td>
                                                <td class="tr">
                                                    繁体中文名称
                                                </td>
                                                <td class="tl">
                                                    <input type="text" id="addNametw" maxlength="50" class="text_01" onmousemove="this.className='text_01_h'"
                                                        onmouseout="this.className='text_01'" />
                                                </td>
                                                <td class="tl">
                                                    <label id="addNametwlbl" style="color: Red">
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tr">
                                                    英文名称
                                                </td>
                                                <td class="tl">
                                                    <input type="text" id="addNameen" maxlength="50" class="text_01" onmousemove="this.className='text_01_h'"
                                                        onmouseout="this.className='text_01'" />
                                                </td>
                                                <td class="tl">
                                                    <label id="addNameenlbl" style="color: Red">
                                                    </label>
                                                </td>
                                                <td class="tr">
                                                    泰文名称
                                                </td>
                                                <td class="tl">
                                                    <input type="text" id="addNameth" maxlength="50" class="text_01" onmousemove="this.className='text_01_h'"
                                                        onmouseout="this.className='text_01'" />
                                                </td>
                                                <td class="tl">
                                                    <label id="addNamethlbl" style="color: Red">
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tr">
                                                    越文名称
                                                </td>
                                                <td class="tl">
                                                    <input type="text" id="addNametv" maxlength="50" class="text_01" onmousemove="this.className='text_01_h'"
                                                        onmouseout="this.className='text_01'" />
                                                </td>
                                                <td class="tl">
                                                    <label id="addNametvlbl" style="color: Red">
                                                    </label>
                                                </td>
                                                <td class="tr">
                                                    是否显示
                                                </td>
                                                <td class="tl">
                                                    <input type="checkbox" checked id="addDisplay" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    默认网址
                                                </td>
                                                <td align="left">
                                                    <input type="text" class="text_01" onmousemove="this.className='text_01_h'" onmouseout="this.className='text_01'"
                                                        id="addAddress" maxlength="60" />
                                                </td>
                                                <td class="tl">
                                                    <label id="addAddresslbl" style="color: Red">
                                                    </label>
                                                </td>
                                                <td align="right">
                                                    显示序号
                                                </td>
                                                <td align="left">
                                                    <input type="text" id="addOrd" class="text_01" onmousemove="this.className='text_01_h'"
                                                        onmouseout="this.className='text_01'" />
                                                </td>
                                                <td class="tl">
                                                    <label id="addOrdlbl" style="color: Red">
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr id="trEnd">
                                                <td align="center" colspan="6">
                                                    <input type="button" id="sure" class="btn_02" onmouseover="this.className='btn_02_h'"
                                                        onmouseout="this.className='btn_02'" value="保存" />
                                                    <input type="button" id="esc" class="btn_02" onmouseover="this.className='btn_02_h'"
                                                        onmouseout="this.className='btn_02'" value="取消" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div class="new_trfoot">
                                </div>
                            </div>
                        </div>
                        <table class="tab2" id="tb2" style="width: 100%; text-align: center" border="0" cellpadding="0"
                            cellspacing="0">
                            <thead>
                                <tr>
                                    <th>
                                        序号
                                    </th>
                                    <th>
                                        简体中文
                                    </th>
                                    <th>
                                        繁体中文
                                    </th>
                                    <th>
                                        英文
                                    </th>
                                    <th>
                                        泰文
                                    </th>
                                    <th>
                                        越文
                                    </th>
                                    <th>
                                        是否显示
                                    </th>
                                    <th>
                                        默认网址
                                    </th>
                                    <th>
                                        显示序号
                                    </th>
                                    <%if (mdfAc)
                                      { %>
                                    <th>
                                        操作
                                    </th>
                                    <%} %>
                                </tr>
                            </thead>
                            <tbody id="ShowWebInfo">
                                
                            </tbody>
                            <tfoot>
                            <tr id="tr1">
                                    <td id="IDNumber">
                                    </td>
                                    <td id="NameCn">
                                    </td>
                                    <td id="NameTw">
                                    </td>
                                    <td id="NameEn">
                                    </td>
                                    <td id="NameTh">
                                    </td>
                                    <td id="NameTv">
                                    </td>
                                    <td id="IsShow">
                                    </td>
                                    <td id="webPath">
                                    </td>
                                    <td id="showNumber">
                                    </td>
                                    <%if (mdfAc)
                                      { %>
                                    <td id="updataInfo">
                                    </td>
                                    <%} %>
                                </tr>
                            <tr class="tc"><td colspan="10"><div id="pageDiv" class="grayr"><span id="zg">总共</span><label id="infoCount"></label><span id="tjl">条记录</span>,<span id="g">共</span><label id="pageCount"></label><span id="y">页</span><a style="cursor:hand" id="sy"> 首页 </a><a style="cursor:hand" id="syy"> 上一页 </a><span id="pageSpan"></span><a style="cursor:hand" id="xyy"> 下一页 </a><a style="cursor:hand" id="wy"> 尾页 </a></div></td></tr>
                            </tfoot>
                        </table>
                        <div id="delet" title="错误" style="display:none">
                            <div class="showdiv">
                                <p class="wrnning">
                                    请修正错误</p>
                                <div align="center" class="mtop_50">
                                    <input type="button" class="btn_02" id="btnSure" onmouseover="this.className='btn_02_h'"
                                        onmouseout="this.className='btn_02'" value="确定" />
                                </div>
                            </div>
                        </div>
                        <!-- 消息提示DIV -->
                        <div id="delet2" title="消息提示" style="display:none">
                            <div id="reportDiv" class="showdiv">
                                <div class=" h30">
                                </div>
                                <div align="center" class="mtop_50">
                                    <input type="button" class="btn_02" id="closeButton" onmouseover="this.className='btn_02_h'"
                                        onmouseout="this.className='btn_02'" value="关闭" />
                                </div>
                            </div>
                        </div>
                        <!-- 消息提示DIV结束 -->
                        </form>
                        <!--主题部分结束=========================================================================================-->
                    </div>
                </td>
                <td class="tab_middle_r">
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr class="h35">
                <td width="12" class="tab_foot_l">
                </td>
                <td width="*" class="tab_foot_m">
                </td>
                <td width="16" class="tab_foot_r">
                </td>
            </tr>
        </tfoot>
    </table>
</body>
</html>
