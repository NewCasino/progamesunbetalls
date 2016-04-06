<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlDiskWeb.aspx.cs" Inherits="admin.ReleaseSite.ControlDiskWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>控盘</title>
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
        jQuery(function () {
            SetGlobal("");
        });

        var languages = "";
        var lang;
        function SetGlobal(setLang) {

            setLang = $.SetOrGetLanguage(setLang, function () {
                languages = language;
                  
                $(".H1101").html(languages.H1101);
                $(".H1151").html(languages.H1151);
                $(".H1152").html(languages.H1152);
                $(".H1153").html(languages.H1153);
                $(".H1166").html(languages.H1166);
                $(".H1167").html(languages.H1167);
                $(".H1161").html(languages.H1161);
                $(".H1104").html(languages.H1104);
                $(".H1105").html(languages.H1105);
                $(".H1106").html(languages.H1106);
                $(".port2").html(languages.H1164 + "<font color='red'>(" + languages.H1163 + ")</font><br />" + languages.H1165 + "<font color='red'>(" + languages.H1163 + ")</font>");
                $(".port3").html(languages.H1142 + "<br />" + languages.H1162 + "<br />" + languages.H1056);
                $(".port4").html(languages.H1130 + "<br />" + languages.H1131 + "<br />" + languages.H1132);
                $(".H1451").html(languages.H1451);
                $(".H1168").html(languages.H1168);
                $(".H1169").html(languages.H1169);
                $(".H1170").html(languages.H1170);
                $(".H1171").html(languages.H1171);
                $(".H1172").html(languages.H1172);
                $(".H1173").html(languages.H1173);
                $(".H1174").html(languages.H1174);
                $(".H1175").html(languages.H1175);
                $(".H1176").html(languages.H1176);
                $(".H1070").html(languages.H1070);
                $(".H1026").html(languages.H1026);
                $("#updtbtn").val(languages.H1009);
                $("#closebtn").val(languages.H1039);
                $("#btnSure1").val(languages.H1037);
                $("#btnEsc1").val(languages.H1011);
                $(".H1156").val(languages.H1156);
                $(".H1157").val(languages.H1157);
                $(".H1158").val(languages.H1158);
                $(".H1156").html(languages.H1156);
                $(".H1157").html(languages.H1157);
                $(".H1158").html(languages.H1158);

            });
            lang = setLang;
        }
        
        var data;
        var bollID = "";
        var type = 4;
        var lty = 1;
        jQuery(function () {
            jQuery("#delet1").hide();
            jQuery("#delet2").hide();
            jQuery("#kong").hide();
            jQuery("#tab").alterBgColor({ odd: "odd", even: "even", selected: "selected", tdCss: "tdCss", istdClick: true });
            setDate();
            /*--------------球队信息-----------------*/
            jQuery("#boll").click(function () {
                data = "language:'" + jQuery("#language").val() + "'";
                jQuery.AjaxCommon("/ServicesFile/ReportService/NoteSingleService.asmx/GetBollToJson1", data, true, false, function (json) {
                    if (json.d != "none") {
                        var tr = "<tr>";
                        jQuery("#tbody2").html("");
                        var result = jQuery.parseJSON(json.d);
                        jQuery.each(result, function (i) {
                            if (i != 0 && i % 3 == 0) {
                                tr += "</tr><tr>";
                            }
                            tr += "<td><input type=\"checkbox\" checked value=\"" + result[i].matchid + "\" />" + result[i].home + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].away + "</td>";
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
                    if (jQuery("#againstAll").attr("checked") || jQuery("#tbody2").find(":checkbox:checked").length == 0) {
                        bollID = "";
                    }
                    else {
                        jQuery.each(jQuery("#tbody2").find(":checkbox:checked"), function (i) {
                            if (i > 0) {
                                bollID += ";";
                            }
                            bollID += jQuery("#tbody2").find(":checkbox:checked:eq(" + i + ")").val();
                        });
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

            /*------------单式按钮的单击事件-----------------*/
            jQuery("#ds").click(function () {
                type = 4;
                setDate();
            });
            /*------------单式按钮的单击事件结束-------------*/
            /*------------早餐按钮的单击事件-----------------*/
            jQuery("#zc").click(function () {
                type = 5;
                setDate();
            });
            /*------------早餐按钮的单击事件结束-------------*/
            /*------------走地按钮的单击事件-----------------*/
            jQuery("#zd").click(function () {
                type = 6;
                setDate();
            });
            /*------------走地按钮的单击事件结束-------------*/
            jQuery("#Button1").click(function () {
                jQuery("#kong").dialog("close");
            });


            jQuery("#closeButton").click(function () {
                jQuery("#delet2").dialog("close");
            });

            /*---------------修改投注额--------------------*/
            jQuery("#updtButton").click(function () {
                var a = "";
                var d = "";
                var oi = "";
                var oa = "";
                var ol = "";
                jQuery.each(jQuery("#showK>tr"), function (i) {
                    a += (jQuery("#showK>tr:eq(" + i + ")>td:eq(0)").attr("attr")) + ";";
                    d += jQuery("#showK>tr:eq(" + i + ")").attr("attr") + ";";
                    oi += jQuery("#showK>tr:eq(" + i + ")>td:eq(2)>:text").val() + ";";
                    oa += jQuery("#showK>tr:eq(" + i + ")>td:eq(3)>:text").val() + ";";
                    ol += jQuery("#showK>tr:eq(" + i + ")>td:eq(4)>:text").val() + ";";
                });
                a = a.substr(0, a.length - 1);
                d = d.substr(0, d.length - 1);
                oi = oi.substr(0, oi.length - 1);
                oa = oa.substr(0, oa.length - 1);
                ol = ol.substr(0, ol.length - 1);
                jQuery.AjaxCommon("/ServicesFile/ReleaseSite/ControlDiskService1.asmx/updaInfo", "a:'" + a + "',d:'" + d + "',oi:'" + oi + "',oa:'" + oa + "',ol:'" + ol + "',t:" + type + ",l:" + lty, false, false, function (json) {
                    alert(languages.H1012);
                    jQuery("#kong").dialog("close");
                });
            });
        });
        var setDate = function () {
            jQuery.ajax({ url: "arrayData.aspx", type: "post", data: "langu=" + jQuery("#language").val() + "&boll=" + bollID + "&type=" + type, success: function (json) {
                json;
                var a = new Array();
                jQuery("#showInfo>tr").remove();
                jQuery.each(data, function (i) {
                    var count = 0;
                    a = data[i];
                    count = a[5].length > count ? a[5].length : count;
                    count = a[6].length > count ? a[6].length : count;
                    count = a[7].length > count ? a[7].length : count;
                    count = a[8].length > count ? a[8].length : count;
                    count = a[9].length > count ? a[9].length : count;
                    count = a[10].length > count ? a[10].length : count;
                    var tr = jQuery("#tr1").clone();
                    tr.attr("attr", "" + a[0]);
                    tr.find("#sj").html("<input type=\"button\" value=\"" + language.H1142 + "\" style=\"width:40px\" />" + "<br />" + a[1].replace(" ", "<br />"));
                    tr.find("#sj").attr("rowspan", "" + (count == 0 ? 1 : count));
                    tr.find("#ls").html(a[11] + "<br/>" + a[2] + "<br />" + a[3] + "<br />" + a[4]);
                    tr.find("#ls").attr("rowspan", "" + (count == 0 ? 1 : count));
                    for (var j = 0; j < count; j++) {
                        var tr1;
                        if (j > 0) {
                            tr1 = jQuery("#tr1").clone();
                            tr1.attr("attr", "" + a[0]);
                            tr1.find("#sj").remove();
                            tr1.find("#ls").remove();
                            tr1.find("#bz").html(" ");
                            tr1.find("#bzpl").html(" ");
                            if (j < a[5].length) {
                                tr1.find("#bzpl").html("" + a[5][j][2] + "<font color=\"red\" attr=\"1;1\">(" + a[5][j][6] + ")</font><br />" + a[5][j][3] + "<font color=\"red\" attr=\"1;2\">(" + a[5][j][7] + ")</font><input title=\"" + language.H1143 + "\" style=\"height:30px\" attr=\"" + a[5][j][0] + ";1x2\" type=\"button\" value=\"" + (a[5][j][5] == "1" ? languages.H1144 : languages.H1145) + "\" /><br />" + a[5][j][4] + "<font color=\"red\" attr=\"1;X\">(" + a[5][j][8] + ")</font>");
                            }
                            tr1.find("#rq").html(" ");
                            tr1.find("#rqpl").html(" ");
                            if (j < a[6].length) {
                                tr1.find("#rq").html(" " + a[6][j][4]);
                                tr1.find("#rqpl").html("" + (a[6][j][2].toString().indexOf("-") == -1 ? "&nbsp;" + a[6][j][2] : a[6][j][2]) + "<font color=\"red\" attr=\"2;H\">(" + a[6][j][6] + ")</font><input title=\"" + language.H1143 + "\" style=\"height:30px\" attr=\"" + a[6][j][0] + ";hdp\" type=\"button\" value=\"" + (a[6][j][5] == "1" ? languages.H1144 : languages.H1145) + "\" /><br />" + (a[6][j][3].toString().indexOf("-") == -1 ? "&nbsp;" + a[6][j][3] : a[6][j][3]) + "<font color=\"red\" attr=\"2;A\">(" + a[6][j][7] + ")</font>");
                            }
                            tr1.find("#dx").html(" ");
                            tr1.find("#dxpl").html(" ");
                            if (j < a[7].length) {
                                tr1.find("#dx").html(" " + a[7][j][4]);
                                tr1.find("#dxpl").html("" + (a[7][j][2].toString().indexOf("-") == -1 ? "&nbsp;" + a[7][j][2] : a[7][j][2]) + "<font color=\"red\" attr=\"3;O\">(" + a[7][j][6] + ")</font><input title=\"" + language.H1143 + "\" style=\"height:30px\" attr=\"" + a[7][j][0] + ";ou\" type=\"button\" value=\"" + (a[7][j][5] == "1" ? languages.H1144 : languages.H1145) + "\" /><br />" + (a[7][j][3].toString().indexOf("-") == -1 ? "&nbsp;" + a[7][j][3] : a[7][j][3]) + "<font color=\"red\" attr=\"3;U\">(" + a[7][j][7] + ")</font>");
                            }
                            tr1.find("#bcbz").html(" ");
                            tr1.find("#bcbzpl").html(" ");
                            if (j < a[8].length) {
                                tr1.find("#bcbzpl").html(" " + a[8][j][2] + "<font color=\"red\" attr=\"4;1\">(" + a[8][j][6] + ")</font><br />" + a[8][j][3] + "<font color=\"red\" attr=\"4;2\">(" + a[8][j][7] + ")</font><input title=\"" + language.H1143 + "\" attr=\"" + a[8][j][0] + ";1x2hf\" style=\"height:30px\" type=\"button\" value=\"" + (a[8][j][5] == "1" ? languages.H1144 : languages.H1145) + "\" /><br />" + a[8][j][4] + "<font color=\"red\" attr=\"4;X\">(" + a[8][j][8] + ")</font>");
                            }
                            tr1.find("#bcrq").html(" ");
                            tr1.find("#bcrqpl").html(" ");
                            if (j < a[9].length) {
                                tr1.find("#bcrq").html(" " + a[9][j][4]);
                                tr1.find("#bcrqpl").html("" + (a[9][j][2].toString().indexOf("-") == -1 ? "&nbsp;" + a[9][j][2] : a[9][j][2]) + "<font color=\"red\" attr=\"5;H\">(" + a[9][j][6] + ")</font><input title=\"" + language.H1143 + "\" style=\"height:30px\" attr=\"" + a[9][j][0] + ";hdphf\" type=\"button\" value=\"" + (a[9][j][5] == "1" ? languages.H1144 : languages.H1145) + "\" /><br />" + (a[9][j][3].toString().indexOf("-") == -1 ? "&nbsp;" + a[9][j][3] : a[9][j][3]) + "<font color=\"red\" attr=\"5;A\">(" + a[9][j][7] + ")</font>");
                            }
                            tr1.find("#bcdx").html(" ");
                            tr1.find("#bcdxpl").html(" ");
                            if (j < a[10].length) {
                                tr1.find("#bcdx").html(" " + a[10][j][4]);
                                tr1.find("#bcdxpl").html("" + (a[10][j][2].toString().indexOf("-") == -1 ? "&nbsp;" + a[10][j][2] : a[10][j][2]) + "<font color=\"red\" attr=\"6;O\">(" + a[10][j][6] + ")</font><input title=\"" + language.H1143 + "\" style=\"height:30px\" attr=\"" + a[10][j][0] + ";ouhf\" type=\"button\" value=\"" + (a[10][j][5] == "1" ? languages.H1144 : languages.H1145) + "\" /><br />" + (a[10][j][3].toString().indexOf("-") == -1 ? "&nbsp;" + a[10][j][3] : a[10][j][3]) + "<font color=\"red\" attr=\"6;U\">(" + a[10][j][7] + ")</font>");
                            }
                            tr1.find("#zt").remove();
                            tr1.appendTo("#showInfo");
                        }
                        else {
                            tr.find("#bz").html(" ");
                            tr.find("#bzpl").html(" ");
                            if (j < a[5].length) {
                                tr.find("#bzpl").html("" + a[5][j][2] + "<font color=\"red\" attr=\"1;1\">(" + a[5][j][6] + ")</font><br />" + a[5][j][3] + "<font color=\"red\" attr=\"1;2\">(" + a[5][j][7] + ")</font><input title=\"" + language.H1143 + "\" style=\"height:30px\" attr=\"" + a[5][j][0] + ";1x2\" type=\"button\" value=\"" + (a[5][j][5] == "1" ? languages.H1144 : languages.H1145) + "\" /><br />" + a[5][j][4] + "<font color=\"red\" attr=\"1;X\">(" + a[5][j][8] + ")</font>");
                            }
                            tr.find("#rq").html(" ");
                            tr.find("#rqpl").html(" ");
                            if (j < a[6].length) {
                                tr.find("#rq").html(" " + a[6][j][4]);
                                tr.find("#rqpl").html("" + (a[6][j][2].toString().indexOf("-") == -1 ? "&nbsp;" + a[6][j][2] : a[6][j][2]) + "<font color=\"red\" attr=\"2;H\">(" + a[6][j][6] + ")</font><input title=\"" + language.H1143 + "\" style=\"height:30px\" attr=\"" + a[6][j][0] + ";hdp\" type=\"button\" value=\"" + (a[6][j][5] == "1" ? languages.H1144 : languages.H1145) + "\" /><br />" + (a[6][j][3].toString().indexOf("-") == -1 ? "&nbsp;" + a[6][j][3] : a[6][j][3]) + "<font color=\"red\" attr=\"2;A\">(" + a[6][j][7] + ")</font>");
                            }
                            tr.find("#dx").html(" ");
                            tr.find("#dxpl").html(" ");
                            if (j < a[7].length) {
                                tr.find("#dx").html(" " + a[7][j][4]);
                                tr.find("#dxpl").html("" + (a[7][j][2].toString().indexOf("-") == -1 ? "&nbsp;" + a[7][j][2] : a[7][j][2]) + "<font color=\"red\" attr=\"3;O\">(" + a[7][j][6] + ")</font><input title=\"" + language.H1143 + "\" style=\"height:30px\" attr=\"" + a[7][j][0] + ";ou\" type=\"button\" value=\"" + (a[7][j][5] == "1" ? languages.H1144 : languages.H1145) + "\" /><br />" + (a[7][j][3].toString().indexOf("-") == -1 ? "&nbsp;" + a[7][j][3] : a[7][j][3]) + "<font color=\"red\" attr=\"3;U\">(" + a[7][j][7] + ")</font>");
                            }
                            tr.find("#bcbz").html(" ");
                            tr.find("#bcbzpl").html(" ");
                            if (j < a[8].length) {
                                tr.find("#bcbzpl").html("" + a[8][j][2] + "<font color=\"red\" attr=\"4;1\">(" + a[8][j][6] + ")</font><br />" + a[8][j][3] + "<font color=\"red\" attr=\"4;2\">(" + a[8][j][7] + ")</font><input title=\"" + language.H1143 + "\" style=\"height:30px\" attr=\"" + a[8][j][0] + ";1x2hf\" type=\"button\" value=\"" + (a[8][j][5] == "1" ? languages.H1144 : languages.H1145) + "\" /><br />" + a[8][j][4] + "<font color=\"red\" attr=\"4;X\">(" + a[8][j][8] + ")</font>");
                            }
                            tr.find("#bcrq").html(" ");
                            tr.find("#bcrqpl").html(" ");
                            if (j < a[9].length) {
                                tr.find("#bcrq").html(" " + a[9][j][4]);
                                tr.find("#bcrqpl").html("" + (a[9][j][2].toString().indexOf("-") == -1 ? "&nbsp;" + a[9][j][2] : a[9][j][2]) + "<font color=\"red\" attr=\"5;H\">(" + a[9][j][6] + ")</font><input title=\"" + language.H1143 + "\" style=\"height:30px\" attr=\"" + a[9][j][0] + ";hdphf\" type=\"button\" value=\"" + (a[9][j][5] == "1" ? languages.H1144 : languages.H1145) + "\" /><br />" + (a[9][j][3].toString().indexOf("-") == -1 ? "&nbsp;" + a[9][j][3] : a[9][j][3]) + "<font color=\"red\" attr=\"5;A\">(" + a[9][j][7] + ")</font>");
                            }
                            tr.find("#bcdx").html(" ");
                            tr.find("#bcdxpl").html(" ");
                            if (j < a[10].length) {
                                tr.find("#bcdx").html(" " + a[10][j][4]);
                                tr.find("#bcdxpl").html("" + (a[10][j][2].toString().indexOf("-") == -1 ? "&nbsp;" + a[10][j][2] : a[10][j][2]) + "<font color=\"red\" attr=\"6;O\">(" + a[10][j][6] + ")</font><input title=\"" + language.H1143 + "\" style=\"height:30px\" attr=\"" + a[10][j][0] + ";ouhf\" type=\"button\" value=\"" + (a[10][j][5] == "1" ? languages.H1144 : languages.H1145) + "\" /><br />" + (a[10][j][3].toString().indexOf("-") == -1 ? "&nbsp;" + a[10][j][3] : a[10][j][3]) + "<font color=\"red\" attr=\"6;U\">(" + a[10][j][6] + ")</font>");
                            }
                            tr.find("#zt").html("<input type=\"button\" value=\"" + languages.H1101 + "\" style=\"width:40px\" />");
                            tr.find("#zt").attr("rowspan", "" + (count == 0 ? 1 : count));
                            tr.appendTo("#showInfo");
                        }
                    }
                });

                jQuery("#showInfo>tr").find("#zt").find("input:button").unbind("click");
                jQuery("#showInfo>tr").find("#zt").find("input:button").click(function () {
                    jQuery(this).val() == languages.H1101 ? jQuery(this).val(languages.H1449) : jQuery(this).val(languages.H1101);
                    var a = jQuery(this).parent().parent().attr("attr");
                    var mc = jQuery(this).val();
                    var n = 0;
                    jQuery.each(jQuery("#showInfo>tr"), function (i) {
                        if (jQuery("#showInfo>tr:eq(" + i + ")").attr("attr") == a) {
                            n++;
                            jQuery("#showInfo>tr:eq(" + i + ")").find("td:not(\"#zt\"):not(\"#sj\")").find("input:button").val("" + (mc == languages.H1101 ? languages.H1144 : languages.H1145));
                        }
                        else {
                            if (n > 0) {
                                return false;
                            }
                        }
                    });
                    jQuery.AjaxCommon("/ServicesFile/ReleaseSite/ControlDiskService1.asmx/pdt", "a:'" + a + "',t:'" + type + "',s:'" + (mc == languages.H1101 ? 1 : 0) + "'", true, false, function (json) {
                        if (json.d == "true") {
                            alert(mc == languages.H1101 ? languages.H1146 : languages.H1147);
                        }
                    })
                });
                jQuery("#showInfo>tr").find("td:not(\"#zt\"):not(\"#sj\")").find("input:button").unbind("click");
                jQuery("#showInfo>tr").find("td:not(\"#zt\"):not(\"#sj\")").find("input:button").click(function () {
                    jQuery(this).val() == languages.H1144 ? jQuery(this).val(languages.H1145) : jQuery(this).val(languages.H1144);
                    var info = "";
                    var t = jQuery(this).attr("attr").toString().substr(jQuery(this).attr("attr").toString().indexOf(";") + 1);
                    var i = jQuery(this).attr("attr").toString().substr(0, jQuery(this).attr("attr").toString().indexOf(";"));
                    switch (t) {
                        case "1x2":
                            info = languages.H1148;
                            break;
                        case "hdp":
                            info = languages.H1149;
                            break;
                        case "ou":
                            info = languages.H1150;
                            break;
                        case "1x2hf":
                            info = languages.H1151;
                            break;
                        case "hdphf":
                            info = languages.H1152;
                            break;
                        case "ouhf":
                            info = languages.H1153;
                            break;
                    }
                    jQuery.AjaxCommon("/ServicesFile/ReleaseSite/ControlDiskService1.asmx/pdto", "i:'" + i + "',t:'" + type + "',ty:'" + t + "',s:'" + (jQuery(this).val() == "关" ? 1 : 0) + "'", true, false, function (json) {
                        if (json.d != "none") {
                            alert((jQuery(this).val() == languages.H1144 ? languages.H1449 : languages.H1039) + languages.H1154 + info + languages.H1450);
                        }
                    });
                });
                jQuery("#showInfo>tr").find("font").unbind("click");
                jQuery("#showInfo>tr").find("font").click(function () {
                    var a = jQuery(this).attr("attr");
                    var l = jQuery(this).parent().parent().attr("attr");
                    var g = a.substr(a.indexOf(";") + 1);
                    if (jQuery(this).text() == "(0)") {
                        return false;
                    }
                    else {
                        jQuery.AjaxCommon("/ServicesFile/ReleaseSite/ControlDiskService1.asmx/getXX", "t:'" + type + "',l:'" + l + "',lg:'" + jQuery("#language").val() + "',g:'" + g + "',i:'"+a.substr(0,a.indexOf(";"))+"'", true, false, function (json) {
                            if (json.d != "none") {
                                jQuery("#delet2").dialog({ width: 1000 });
                                jQuery("#delet2").dialog({ model: true });
                                jQuery("#reportInfo>tr").remove();
                                var r = jQuery.parseJSON(json.d);
                                jQuery.each(r, function (i) {
                                    var tr = jQuery("#tr2").clone();
                                    tr.find("#ID").text("" + (i + 1));
                                    tr.find("#UserNameTD").html(r[i].a + "<br />" + r[i].o);
                                    tr.find("#teamTD").html(r[i].c + "<br />" + r[i].d + "  -VS-  " + r[i].e + "<br />" + r[i].b);
                                    tr.find("#Odds").html(r[i].h + "<br />" + r[i].i + "<br />" + r[i].j);
                                    tr.find("#AmountTD").html("" + r[i].k);
                                    tr.find("#StatusTD").text(languages.H1155);
                                    tr.find("#IPTD").html("" + r[i].l);
                                    tr.appendTo("#reportInfo");
                                });
                            }
                        });
                    }
                });
                jQuery("#showInfo>tr").find("td:eq(0)>:button").unbind("click");
                jQuery("#showInfo>tr").find("td:eq(0)>:button").click(function () {
                    var time = jQuery(this).parent().html().toString().substr(jQuery(this).parent().html().toString().indexOf("<br>") + 4);
                    jQuery("#kong").dialog({ width: 1200 });
                    jQuery("#kong").dialog({ model: true });

                    jQuery("#tab11>thead>tr:eq(0)>th:eq(0)").text("" + (type == 4 ? languages.H1104 : (type == 5 ? languages.H1106 : languages.H1105)));
                    jQuery("#tab11>thead>tr:eq(1)>th:eq(0)").text("" + (lty == 1 ? languages.H1156 : (lty == 2 ? languages.H1157 : languages.H1158)));
                    var obj = jQuery(this);
                    jQuery("#b1").click(function () {
                        lty = 1;
                        jQuery("#tab11>thead>tr:eq(1)>th:eq(0)").text("" + (lty == 1 ? languages.H1156 : (lty == 2 ? languages.H1157 : languages.H1158)));
                        set(jQuery(obj));
                    });
                    jQuery("#r1").click(function () {
                        lty = 2;
                        jQuery("#tab11>thead>tr:eq(1)>th:eq(0)").text("" + (lty == 1 ? languages.H1156 : (lty == 2 ? languages.H1157 : languages.H1158)));
                        set1(jQuery(obj));
                    });
                    jQuery("#d1").click(function () {
                        lty = 3;
                        jQuery("#tab11>thead>tr:eq(1)>th:eq(0)").text("" + (lty == 1 ? languages.H1156 : (lty == 2 ? languages.H1157 : languages.H1158)));
                        set2(jQuery(obj));
                    });
                    set(jQuery(this));
                });
                if (jQuery("#showInfo>tr").length == 0) {
                    var tr = jQuery("#tr1").clone();
                    tr.find("td:gt(0)").remove();
                    tr.find("td:eq(0)").attr("colspan", "15");
                    tr.attr("align", "center");
                    tr.find("td:eq(0)").text(languages.H1013);
                    tr.appendTo("#showInfo");
                }
            }
            });
        };
    var set = function (obj) {
            jQuery.AjaxCommon("/ServicesFile/ReleaseSite/ControlDiskService1.asmx/getInfo", "i:" + jQuery(obj).parent().parent().attr("attr") + ",t:" + type, true, false, function (json) {
                if (json.d != "none") {
                    jQuery("#showK>tr").remove();
                    var r = jQuery.parseJSON(json.d);
                    jQuery.each(r, function (i) {
                        var tr = jQuery("#trK").clone();
                        tr.attr("attr", r[i].id);
                        tr.find("#type1Td").attr("attr", (i == 0 ? "a" : "h"));
                        tr.find("#type1Td").text((i == 0 ? languages.H1159 : languages.H1160));
                        tr.find("#hand1Td").html("&nbsp;&nbsp;");
                        tr.find("#oneMin").html("<input type=\"text\" value=\"" + r[i].MinBet + "\" />");
                        tr.find("#oneMax").html("<input type=\"text\" value=\"" + r[i].MaxBet + "\" />");
                        tr.find("#oneAll").html("<input type=\"text\" value=\"" + r[i].SingleMaxBet + "\" />");
                        tr.appendTo("#showK");
                    });
                }
            });
        };

        var set1 = function (obj) {
            jQuery.AjaxCommon("/ServicesFile/ReleaseSite/ControlDiskService1.asmx/getrqInfo", "i:" + jQuery(obj).parent().parent().attr("attr") + ",t:" + type, true, false, function (json) {
                if (json.d != "none") {
                    jQuery("#showK>tr").remove();
                    var r = jQuery.parseJSON(json.d);
                    jQuery.each(r, function (i) {
                        var tr = jQuery("#trK").clone();
                        tr.attr("attr", r[i].d);
                        tr.find("#type1Td").attr("attr", r[i].c);
                        tr.find("#type1Td").text((r[i].c == "a" ? languages.H1159 : languages.H1160));
                        tr.find("#hand1Td").html("&nbsp;&nbsp;" + r[i].e);
                        tr.find("#oneMin").html("<input type=\"text\" value=\"" + r[i].f + "\" />");
                        tr.find("#oneMax").html("<input type=\"text\" value=\"" + r[i].g + "\" />");
                        tr.find("#oneAll").html("<input type=\"text\" value=\"" + r[i].h + "\" />");
                        tr.appendTo("#showK");
                    });
                }
            });
        };

        var set2 = function (obj) {
        jQuery.AjaxCommon("/ServicesFile/ReleaseSite/ControlDiskService1.asmx/getdxInfo", "i:" + jQuery(obj).parent().parent().attr("attr") + ",t:" + type, true, false, function (json) {
            if (json.d != "none") {
                jQuery("#showK>tr").remove();
                var r = jQuery.parseJSON(json.d);
                jQuery.each(r, function (i) {
                    var tr = jQuery("#trK").clone();
                    tr.attr("attr", r[i].d);
                    tr.find("#type1Td").attr("attr", r[i].c);
                    tr.find("#type1Td").text((r[i].c == "a" ? languages.H1159 : languages.H1160));
                    tr.find("#hand1Td").html("&nbsp;&nbsp;" + r[i].e);
                    tr.find("#oneMin").html("<input type=\"text\" value=\"" + r[i].f + "\" />");
                    tr.find("#oneMax").html("<input type=\"text\" value=\"" + r[i].g + "\" />");
                    tr.find("#oneAll").html("<input type=\"text\" value=\"" + r[i].h + "\" />");
                    tr.appendTo("#showK");
                });
            }
        });
    };
    </script>
</head>
<body>
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="nameP" class="H1451">控盘</p></th>
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
    <div class="top_banner h30">
        <a id="ds" class="btnblue"><span class="H1104">单式</span></a>&nbsp;&nbsp;&nbsp;&nbsp;
        <a id="zd" class="btnblue"><span class="H1105">走地</span></a>&nbsp;&nbsp;&nbsp;&nbsp;
        <a id="zc" class="btnblue"><span class="H1106">早餐</span></a>&nbsp;&nbsp;&nbsp;&nbsp;
        <a id="boll" class="btnblue"><span class="H1161">选择球队</span></a>&nbsp;&nbsp;&nbsp;&nbsp;
    </div>
    <!-- 联赛球队信息 -->
    <div>
    <table border="1" cellpadding="0" cellspacing="0" width="100%" id="tab" class="tab2">
    <thead>
    <tr>
    <th class="port3">设置<br />日期<br />时间</th>
    <th class="port4">联赛<br />主队<br />客队</th>
    <th class="H1156">标准</th>
    <th>1<font color="red">(<span class="H1163 ">注额</span>)</font><br />2<font color="red">(<span class="H1163 ">注额</span>)</font><br />X<font color="red">(<span class="H1163 ">注额</span>)</font></th>
    <th class="H1157">让球</th>
    <th class="port2">上盘<font color="red">(注额)</font><br />下盘<font color="red">(注额)</font></th>
    <th class="H1158">大小</th>
    <th class="port2">上盘<font color="red">(注额)</font><br />下盘<font color="red">(注额)</font></th>
    <th class="H1151">半场标准</th>
    <th>1<font color="red">(<span class="H1163 ">注额</span>)</font><br />2<font color="red">(<span class="H1163 ">注额</span>)</font><br />X<font color="red">(<span class="H1163 ">注额</span>)</font></th>
    <th class="H1152">半场让球</th>
    <th class="port2">上盘<font color="red">(注额)</font><br />下盘<font color="red">(注额)</font></th>
    <th class="H1153">半场大小</th>
    <th class="port2">上盘<font color="red">(注额)</font><br />下盘<font color="red">(注额)</font></th>
    <th class="H1101">暂停</th>
    </tr>
    </thead>
    <tbody id="showInfo"></tbody>
    <tfoot>
    <tr id="tr1">
    <td id="sj"></td>
    <td id="ls"></td>
    <td id="bz"></td>
    <td id="bzpl"></td>
    <td id="rq"></td>
    <td id="rqpl"></td>
    <td id="dx"></td>
    <td id="dxpl"></td>
    <td id="bcbz"></td>
    <td id="bcbzpl"></td>
    <td id="bcrq"></td>
    <td id="bcrqpl"></td>
    <td id="bcdx"></td>
    <td id="bcdxpl"></td>
    <td id="zt"></td>
    </tr>
    </tfoot>
    </table>
    </div>
    <!--联赛球队信息结束-->
    <!-- 球队选择DIV -->
    <div id="delet1" class="H1161" title="选择球队" >
    <div id="againstDiv" class="showdiv">
    <table>
    <thead>
    <tr><th align="left"><input type="checkbox" class="H1166" id="againstAll" />全选/取消</th><th colspan="2" align="left" class="H1167">选择对阵双方</th></tr>
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
    <div id="delet2" class="H1168" title="注单明细">

    <div id="reportDiv" class="showdiv">
    <div class=" h30">
    <!-- 查询条件选择DIV -->
<div class="fl">
</div>
<!-- 查询条件选择DIV结束 -->

<!-- 自动刷新DIV -->
<div class="fr">
</div>
<!-- 自动刷新DIV结束 -->

</div>
    <table  id="tb" width="100%" class="tab2">
    <thead>
    <tr>
    <th class="H1026">序号</th>
    <th class="H1169">资讯</th>
    <th class="H1170">比赛</th>
    <th class="H1171">赔率</th>
    <th class="H1172">投注金额</th>
    <th class="H1070">状态</th>
    <th >IP</th>
    </tr>
    </thead>
    <tbody id="reportInfo"></tbody>
    <tfoot>
    <tr id="tr2">
    <td id="ID"></td>
    <td id="UserNameTD"></td>
    <td id="teamTD"></td>
    <td id="Odds"></td>
    <td id="AmountTD"></td>
    <td id="StatusTD"></td>
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



    <!-- 控盘设置DIV -->
    <div id="kong" class="H1168" title="注单明细">

    <div id="k1" class="showdiv">
    <div class=" h30">
    <!-- 查询条件选择DIV -->
<div class="fl">
<input type="button" id="b1" class="H1156" value="标准" />&nbsp;&nbsp;&nbsp;&nbsp;
<input type="button" id="r1" class="H1157" value="让球" />&nbsp;&nbsp;&nbsp;&nbsp;
<input type="button" id="d1" class="H1158" value="大小" />&nbsp;&nbsp;&nbsp;&nbsp;
</div>
<!-- 查询条件选择DIV结束 -->

<!-- 自动刷新DIV -->
<div class="fr">
</div>
<!-- 自动刷新DIV结束 -->

</div>
    <table  id="tab11" width="100%" class="tab2">
    <thead>
    <tr><th colspan="5"></th></tr>
    <tr>
    <th></th>
    <th class="H1173">盘口</th>
    <th class="H1174">单注最低</th>
    <th class="H1175">单注最高</th>
    <th class="H1176">单场最高</th>
    </tr>
    </thead>
    <tbody id="showK"></tbody>
    <tfoot>
    <tr id="trK">
    <td id="type1Td"></td>
    <td id="hand1Td"></td>
    <td id="oneMin"></td>
    <td id="oneMax"></td>
    <td id="oneAll"></td>
    </tr>
    </tfoot>
    </table>
    <div align="center" class="mtop_50">
    <input type="button" class="btn_02" id="updtbtn" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="修改" />
<input type="button" class="btn_02" id="closebtn" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="关闭" />
</div>
</div>
    </div>
    <!-- 控盘设置DIV结束 -->
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
