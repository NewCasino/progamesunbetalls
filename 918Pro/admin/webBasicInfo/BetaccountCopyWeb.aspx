<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="BetaccountCopyWeb.aspx.cs" Inherits="Admin.BetaccountCopyWeb" %>

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
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="/js/page/pageJs.js" type="text/javascript"></script>
    <script src="/js/jQueryCommon.js" type="text/javascript"></script>
    <script type="text/javascript">
        var web;
        var data = "";
        var count = 0;
        var page = 0;
        $(function () {
            SetGlobal("");
            web = new Array();
            $("#cookieDiv").hide();
            $("#delet").hide();
            $.AjaxCommon("/ServicesFile/webBasicInfo/WebInfoService.asmx/GetDate", "", true, false, function (json) {
                if (json.d != "none") {
                    $("#webWhereVal").html("");
                    var result = jQuery.parseJSON(json.d);
                    var a = "";
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
                    });
                    var setLang = "";
                    setLang = $.SetOrGetLanguage(setLang, function () {
                        languages = language;
                        var b = "<option value=\"0\">" + languages["H1040"] + "</option>";
                        $("#webWhereVal").html(b + a);
                    }, "/js/IndexGlobal/");
                }
            });
            data = "casino:'0',dali:'',id:'',enable:'-1',webPoss:'',Company:''";
            jQuery.AjaxCommon("/ServicesFile/webBasicInfo/BetaccountCopyService.asmx/GetCount", data, false, false, function (json) {
                count = parseInt(json.d);
            });
            if (count % 20 == 0) {
                page = count / 20;
            }
            else {
                page = count / 20 + 1;
            }
            IsPage(parseInt(page), count, '20', 'IDex', 'IDexC');
            $("#allCheck").click(function () {
                $("#ShowWebInfo").find(":checkbox").attr("checked", $("#allCheck").attr("checked"));
            });


            $("#selectSure").click(function () {
                data = "";
                data += "casino:'" + $("#webWhereVal").val() + "'";
                data += ",dali:'" + $("#daliWhereVal").val() + "'";
                data += ",id:'" + $("#idWhereVal").val() + "'";
                data += ",enable:'" + $("#enableWhereVal").val() + "'";
                var poss = /^(([0]\.[0-9]{1,3})|([1]))$/;
                if (!poss.test($("#webPossWhereVal").val()) && $("#webPossWhereVal").val() != "") {
                    var setLang = "";
                    setLang = $.SetOrGetLanguage(setLang, function () {
                        languages = language;
                        alert(languages["H1075"]);
                    }, "/js/IndexGlobal/");
                    return false;
                }
                if (!poss.test($("#CompanyWhereVal").val()) && $("#CompanyWhereVal").val() != "") {
                    var setLang = "";
                    setLang = $.SetOrGetLanguage(setLang, function () {
                        languages = language;
                        alert(languages["H1075"]);
                    }, "/js/IndexGlobal/");
                    return false;
                }
                data += ",webPoss:'" + $("#webPossWhereVal").val() + "'";
                data += ",Company:'" + $("#CompanyWhereVal").val() + "'";
                jQuery.AjaxCommon("/ServicesFile/webBasicInfo/BetaccountCopyService.asmx/GetCount", data, false, false, function (json) {
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

            $("#deleteSelect").click(function () {
                $("#deleteID").val("");
                for (var i = 0; i < $("#ShowWebInfo").find(":checkbox").length; i++) {
                    if ($("#ShowWebInfo").find(":checkbox:eq(" + i + ")").attr("checked")) {
                        if ($("#deleteID").val() == "") {
                            $("#deleteID").val($("#deleteID").val() + $("#ShowWebInfo").find(":checkbox:eq(" + i + ")").val());
                        }
                        else {
                            $("#deleteID").val($("#deleteID").val() + "," + $("#ShowWebInfo").find(":checkbox:eq(" + i + ")").val());
                        }
                    }
                }

                jQuery("#delet").dialog({ modal: true });
                jQuery("#btnSure").unbind("click");
                jQuery("#btnSure").bind("click", function () {
                    $("#delet").dialog("close");
                    data = "id:'" + $("#deleteID").val() + "'";
                    $.AjaxCommon("/ServicesFile/webBasicInfo/BetaccountCopyService.asmx/DeleteInfo", data, false, false, function (json1) {
                        if (json1.d != "none") {
                            if (json1.d == "True") {
                                data = "casino:'0',dali:'',id:'',enable:'-1',webPoss:'',Company:''";
                                jQuery.AjaxCommon("/ServicesFile/webBasicInfo/BetaccountCopyService.asmx/GetCount", data, false, false, function (json) {
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

        })
        function SetGlobal(setLang) {
            setLang = $.SetOrGetLanguage(setLang, function () {
                languages = language;
                $("#ba").text(languages["备案账号查询"]);
                $(".fa_add_in").text(languages["H1015"]);
                $("#wz").text(languages["H1054"]);
                $("#btnSure").val(languages["H1037"]);
                $("#btnEsc").val(languages["H1011"]);
                $(".wrnning").text(languages["H1094"] + "?");
                $("#delet").attr("title", languages["H1052"]);
                $("#dl").text(languages["H1082"]);
                $("#zh").text(languages["H1083"]);
                $("#zt").text(languages["H1070"]);
                $("#lx").text(languages["H1059"]);
                $("#xz").text(languages["H1016"]);
                $("#wzzc").text(languages["H1084"]);
                $("#gszc").html(languages["H1085"]);
                $("#ss").html(languages["H1058"]);
                $("#scsx").text(languages["H1093"]);
                $("#enableWhereVal>option:eq(0)").text(languages["H1040"]);
                $("#enableWhereVal>option:eq(1)").text(languages["H1049"]);
                $("#enableWhereVal>option:eq(2)").text(languages["H1050"]);

                $("#tb2>thead>tr>th:eq(1)").text(languages["H1026"]);
                $("#tb2>thead>tr>th:eq(2)").text(languages["H1054"]);
                $("#tb2>thead>tr>th:eq(3)").text(languages["H1083"]);
                $("#tb2>thead>tr>th:eq(4)").text(languages["H1086"]);
                $("#tb2>thead>tr>th:eq(5)").text(languages["H1084"]);
                $("#tb2>thead>tr>th:eq(6)").text(languages["H1085"]);
                $("#tb2>thead>tr>th:eq(7)").text(languages["佣金"]);
                $("#tb2>thead>tr>th:eq(8)").text(languages["H1087"]);
                $("#tb2>thead>tr>th:eq(9)").text(languages["H1064"]);
                $("#tb2>thead>tr>th:eq(10)").text(languages["H1089"]);
                $("#tb2>thead>tr>th:eq(11)").text(languages["H1090"]);
                $("#tb2>thead>tr>th:eq(12)").text(languages["H1091"]);
                $("#tb2>thead>tr>th:eq(13)").text(languages["H1069"]);
                //$("#tb2>thead>tr>th:eq(13)").text();
                //$("#tb2>thead>tr>th:eq(14)").text(languages["H1027"]);

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
        function setDate(data1) {
            var data2 = data1 + "," + data;
            $.AjaxCommon("/ServicesFile/webBasicInfo/BetaccountCopyService.asmx/GetDateAll", data2, true, false, function (json) {
                if (json.d != "none") {

                    $("#ShowWebInfo>tr").remove();
                    var result = jQuery.parseJSON(json.d);
                    var tr1 = $("#tr1").clone();
                    $.each(result, function (i) {
                        var tr = $("#tr1").clone();
                        tr.find("#check").html("<input type=\"checkbox\" value=\"" + result[i].id + "\" />");
                        tr.find("#check").find(":checkbox").click(function () {
                            if (tr.find("#check").find(":checkbox").attr("checked") == false) {
                                $("#allCheck").removeAttr("checked");
                            }
                            else {
                                if ($("#ShowWebInfo").find(":checkbox:checked").length == $("#ShowWebInfo").find(":checkbox").length) {
                                    $("#allCheck").attr("checked", "checked");
                                }
                            }

                        });
                        tr.find("#IDNumber").text("" + (i + 1));
                        tr.find("#webID").text(result[i].userid);
                        tr.find("#casino").text(web[result[i].casino]);
                        tr.find("#daili").text((result[i].agent).replace(/Π/g, "'"));
                        tr.find("#webpossess").text(result[i].websitePossess);
                        tr.find("#casinopossess").text(result[i].selfPossess);
                        tr.find("#commission").text(result[i].commission);
                        tr.find("#multiple").text(result[i].multiple);
                        tr.find("#webIDGroup").text(result[i].group1);
                        tr.find("#address").text((result[i].address).replace(/Π/g, "'"));
                        tr.find("#address2").text((result[i].address2).replace(/Π/g, "'"));
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            tr.find("#cook").html("<a id=\"cookieVal\">" + languages["H1048"] + "</a>");
                            tr.find("#cook").find("#cookieVal").click(function () {
                                jQuery("#cookieDiv").dialog({ modal: false });
                                $("#cookieDiv").text((result[i].cookie).replace(/Π/g, "'"));
                            });
                            tr.find("#isManual").text("" + (result[i].isquzhi == 1 ? languages["H1007"] : languages["H1008"]));
                            tr.find("#isShow").text("" + (result[i].enable == 1 ? languages["H1049"] : languages["H1050"]));
                            }, "/js/IndexGlobal/");
                        tr.appendTo("#ShowWebInfo");
                    });
                    if (jQuery("#ShowWebInfo>tr").length == 0) {
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            jQuery("#ShowWebInfo").html("<tr><td colspan=\"" + jQuery("#tb2>thead>tr>th").length + "\" align=\"center\">"+languages["H1013"]+"</td></tr>");
                        }, "/js/IndexGlobal/");
                        
                        jQuery("#tb2 tfoot tr:eq(1)").hide();
                    }
                    else {
                        jQuery("#tb2 tfoot tr:eq(1)").show();
                    }
                    jQuery("#tb2").alterBgColor({ odd: "odd", even: "even", selected: "selected", moveOver: "over" });
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
<th width="*" class="tab_top_m"><p id="ba">备案账号查询</p></th>
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
    <input type="hidden" id="deleteID" />
    <div id="selectDiv" class="top_banner h24">
    <%if (slt)
      { %>
    <a id="wz">网站</a><select id="webWhereVal" class="text_01 w_60" ></select>&nbsp;&nbsp;&nbsp;
    <a id="dl">代理</a><input type="text" id="daliWhereVal" maxlength="30" class="text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" />&nbsp;&nbsp;&nbsp;
    <a id="zh">账号</a><input type="text" id="idWhereVal" maxlength="20" class="text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" />&nbsp;&nbsp;&nbsp;
    <a id="zt">状态</a><select id="enableWhereVal"><option value="-1">全部</option><option value="0">禁用</option><option value="1">启用</option></select>&nbsp;&nbsp;&nbsp;
    <a id="wzzc">网站占成</a><input type="text" id="webPossWhereVal" class="text_01 w_30" onmouseover="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" />&nbsp;&nbsp;&nbsp;
    <a id="gszc">公司占成</a><input type="text" id="CompanyWhereVal" class="text_01 w_30" onmouseover="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" />&nbsp;&nbsp;&nbsp;
    <a id="selectSure" class="fa_saurch"><span class="fa_saurch_in" id="ss">搜索</span></a>&nbsp;&nbsp;&nbsp;
    <%} %>
    <% if (deleteAc)
       { %><a id="deleteSelect" class="fa_delete"><span class="fa_delete_in" id="scsx">删除所选</span></a><%} %>
    </div>
    <table class="tab2" id="tb2" style="width:100%;text-align:center" border="0" cellpadding="0" cellspacing="0">
        <thead>
        <tr>
        <th><input type="checkbox" id="allCheck" /></th>
        <th>序号</th>
        <th>网站</th>
        <th>账号</th>
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
        </tr>
        </thead>
        <tbody id="ShowWebInfo">

        </tbody>
        <tfoot>
        <tr id="tr1">
            <td id="check"></td>
            <td id="IDNumber"></td>
            <td id="casino"></td>
            <td id="webID"></td>
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
            </tr>
            <tr class="tc"><td colspan="15"><div id="pageDiv" class="grayr"><span id="zg">总共</span><label id="infoCount"></label><span id="tjl">条记录</span>,<span id="g">共</span><label id="pageCount"></label><span id="y">页</span><a style="cursor:hand" id="sy"> 首页 </a><a style="cursor:hand" id="syy"> 上一页 </a><span id="pageSpan"></span><a style="cursor:hand" id="xyy"> 下一页 </a><a style="cursor:hand" id="wy"> 尾页 </a></div></td></tr>
        </tfoot>
    </table>
    <div id="cookieDiv"></div>
    <div id="delet" title="删除" >
<div class="showdiv">
<p class="wrnning">确定要删除这些项吗？</p>
<div align="center" class="mtop_50">
<input type="button" class="btn_02" id="btnSure" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="确定" />
<input type="button" class="btn_02" id="btnEsc" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="取消" />
</div>

</div>
</div>
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
