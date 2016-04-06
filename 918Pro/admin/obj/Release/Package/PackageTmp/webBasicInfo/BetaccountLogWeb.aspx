<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="BetaccountLogWeb.aspx.cs" Inherits="Admin.BetaccountLogWeb" %>

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
    <script src="/js/page/pageJs.js" type="text/javascript"></script>
    <script src="/js/jQueryCommon.js" type="text/javascript"></script>
    <script type="text/javascript">
        var web;
        var data = "";
        var count = 0;
        var page = 0;
        var languages = "";
        $(function () {
            SetGlobal("");
            $("#cookieDiv").hide();
            web = new Array();
            $.AjaxCommon("/ServicesFile/webBasicInfo/WebInfoService.asmx/GetDate", "", true, false, function (json) {
                if (json.d != "none") {
                    var result = jQuery.parseJSON(json.d);
                    $.each(result, function (i) {
                        if (jQuery("#language").val() == "tw") {
                            web[result[i].id] = result[i].nametw;
                        }
                        else if (jQuery("#language").val() == "cn") {
                            web[result[i].id] = result[i].namecn;
                        }
                        else if (jQuery("#language").val() == "en") {
                            web[result[i].id] = result[i].nameen;
                        }
                        else if (jQuery("#language").val() == "th") {
                            web[result[i].id] = result[i].nameth;
                        }
                        else if (jQuery("#language").val() == "vn") {
                            web[result[i].id] = result[i].namevn;
                        }
                    });
                }
            });
            jQuery.AjaxCommon("/ServicesFile/webBasicInfo/BetaccountlogService.asmx/getCount", "", false, false, function (json) {
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

        function SetGlobal(setLang) {
            setLang = $.SetOrGetLanguage(setLang, function () {
                languages = language;
                $("#wzrz").text(languages["网站日志"]);

                $("#tb2>thead>tr>th:eq(0)").text(languages["H1026"]);
                $("#tb2>thead>tr>th:eq(1)").text(languages["H1054"]);
                $("#tb2>thead>tr>th:eq(2)").text(languages["H1083"]);
                $("#tb2>thead>tr>th:eq(3)").text(languages["H1086"]);
                $("#tb2>thead>tr>th:eq(4)").text(languages["H1084"]);
                $("#tb2>thead>tr>th:eq(5)").text(languages["H1085"]);
                $("#tb2>thead>tr>th:eq(6)").text(languages["佣金"]);
                $("#tb2>thead>tr>th:eq(7)").text(languages["H1087"]);
                $("#tb2>thead>tr>th:eq(8)").text(languages["H1064"]);
                $("#tb2>thead>tr>th:eq(9)").text(languages["H1089"]);
                $("#tb2>thead>tr>th:eq(10)").text(languages["H1090"]);
                $("#tb2>thead>tr>th:eq(11)").text(languages["H1091"]);
                $("#tb2>thead>tr>th:eq(12)").text(languages["H1069"]);
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

        function setDate(data) {
            $.AjaxCommon("/ServicesFile/webBasicInfo/BetaccountlogService.asmx/GetDateAll", data, true, false, function (json) {
                if (json.d != "none") {
                    $("#ShowWebInfo>tr").remove();
                    var result = jQuery.parseJSON(json.d);
                    var tr1 = $("#tr1").clone();
                    $.each(result, function (i) {
                        var tr = $("#tr1").clone();
                        tr.find("#IDNumber").text("" + (i + 1));
                        tr.find("#webID").text(result[i].userid);
                        tr.find("#casino").text(web[result[i].casino]);
                        tr.find("#daili").text(result[i].agent);
                        tr.find("#webpossess").text(result[i].websitePossess);
                        tr.find("#casinopossess").text(result[i].selfPossess);
                        tr.find("#commission").text(result[i].commission);
                        tr.find("#multiple").text(result[i].multiple);
                        tr.find("#webIDGroup").text(result[i].group1);
                        tr.find("#address").text(result[i].address);
                        tr.find("#address2").text(result[i].address2);
                        tr.find("#cook").html("<a id=\"cookieVal\">详细</a>");
                        tr.find("#cook").find("#cookieVal").click(function () {
                            jQuery("#cookieDiv").dialog({ modal: false });
                            $("#cookieDiv").text((result[i].cookie).replace(/Π/g, "'"));
                        });
                        tr.find("#isManual").text("" + (result[i].isquzhi == true ? "是" : "否"));
                        tr.find("#isShow").text("" + (result[i].enable == true ? "是" : "否"));
                        tr.appendTo("#ShowWebInfo");
                    });
                    if (jQuery("#ShowWebInfo>tr").length == 0) {
                        jQuery("#ShowWebInfo").html("<tr><td colspan=\"" + jQuery("#tb2>thead>tr>th").length + "\" align=\"center\">没有任何数据</td></tr>");
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
<th width="*" class="tab_top_m"><p id="wzrz">网站日志</p></th>
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
    <table class="tab2" id="tb2" style="width:100%;text-align:center" border="0" cellpadding="0" cellspacing="0">
        <thead>
        <tr><th>序号</th><th>公司</th><th>账号</th><th>外来代理</th><th>网站占成</th><th>公司占成</th>
        <th>佣金</th><th>系数</th><th>账号分组</th><th>账号所属网站</th><th>账号登录网站</th><th>账号状态</th>
        <th>是否手工取值</th>
        <%if (passwordAc)
          { %>
        <th>Cookie</th>
        <%} %>
        <%--<th>操作</th>--%></tr>
        </thead>
        <tbody id="ShowWebInfo">
        </tbody>
        <tfoot>
        <tr id="tr1">
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
            <tr class="tc"><td colspan="14"><div id="pageDiv" class="grayr"><span id="zg">总共</span><label id="infoCount"></label><span id="tjl">条记录</span>,<span id="g">共</span><label id="pageCount"></label><span id="y">页</span><a style="cursor:hand" id="sy"> 首页 </a><a style="cursor:hand" id="syy"> 上一页 </a><span id="pageSpan"></span><a style="cursor:hand" id="xyy"> 下一页 </a><a style="cursor:hand" id="wy"> 尾页 </a></div></td></tr>
        </tfoot>
    </table>
    <div id="cookieDiv"></div>
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
