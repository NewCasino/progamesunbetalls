<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoteOne.aspx.cs" Inherits="agent.Report.NoteOne" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/page/pageJs.js" type="text/javascript"></script>
    <script src="/js/jQueryCommon.js" type="text/javascript"></script>
    <script type="text/javascript">
        var typeList;
        var roid = <% =agentRoleID %>;
        var currName = "<% =agentUserName %>";
        var type;
        var web;
        var data1 = "";
        var data2 = "";
        var count = 0;
        var page = 0;
        var languages = "";
        <%=asu %>
        jQuery(function () {
        SetGlobal("");
            jQuery("#delet2").hide();
            roid=userI+1;
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
            typeList = new Array();
            type = new Array();
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
                type[0] = languages["H1227"];
                type[1] = languages["H1228"];
                type[2] = languages["H1229"];
                type[3] = languages["H1082"];
                type[4] = languages["H1328"];
            }, "/js/IndexGlobal/");
            zhsz();
            jQuery("#tb2>thead>tr>th:gt("+(7-userI)+")").remove();
            //alert(7-userI+1);
            jQuery("#tr1>td:gt("+(7-userI)+")").remove();
            data1 = "id="+userID+"&roid=" + (userI+1) + "&lg=" + jQuery("#language").val();
             jQuery("#nameP").html(jQuery("#nameP").html() + "<a style=\"cursor:hand\" onclick=\"d('0','" + roid + "',this,'1','" + currName + "','" + roid + "');\">" + userN + "</a>");
//            jQuery.AjaxCommon("/ServicesFile/ReportService/InduceService.asmx/getCount", "id:"+userID+",roid:" + (userI+1), true, false, function (json) {
//                count = parseInt(json.d);
//            });
//            if (count % 20 == 0) {
//                page = count / 20;
//            }
//            else {
//                page = count / 20 + 1;
//            }
//            IsPage(parseInt(page), count, '20', 'IDex', 'IDexC');
            setDate();

        });
        var c = function (Id, obj, ind) {
        //debugger
            roid = parseInt(roid) + 1;
            currName = jQuery(obj).text();
            jQuery("#nameP").html(jQuery("#nameP").html() + "<a style=\"cursor:hand\" onclick=\"d('" + Id + "','" + roid + "',this,'" + ind + "','" + currName + "'," + roid + ")\">>" + jQuery(obj).text() + "</a>");
            data1 = "id=" + Id + "&roid=" + roid + "&lg=" + jQuery("#language").val();
            if (roid == 7) {
                data1 += "&un=" + jQuery(obj).text();
                jQuery.AjaxCommon("/ServicesFile/ReportService/InduceService.asmx/getUserCount", "un:'" + jQuery(obj).text() + "'", false, false, function (json) {
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
            else {
                jQuery.AjaxCommon("/ServicesFile/ReportService/InduceService.asmx/getCount", "id:0,roid:" + roid, false, false, function (json) {
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
            //setDate();
        };

        var d = function (Id, ro, obj, ind, cname, proid) {
        //debugger
            currName = cname;
            roid = proid;
            jQuery("#nameP a:gt(" + ind + ")").remove();
            //roid = parseInt(ro);
            data1 = "id=" + Id + "&roid=" + roid + "&lg=" + jQuery("#language").val();
            if (roid == 7) {
                data1 += "&un=" + jQuery(obj).text().substr(1, jQuery(obj).text().length - 1);
                jQuery.AjaxCommon("/ServicesFile/ReportService/InduceService.asmx/getUserCount", "un:'" + jQuery(obj).text().substr(1, jQuery(obj).text().length - 1) + "'", true, false, function (json) {
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
            else {
                jQuery.AjaxCommon("/ServicesFile/ReportService/InduceService.asmx/getCount", "id:0,roid:" + roid, true, false, function (json) {
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
        };
        var zhsz = function () {
         var setLang = "";
            setLang = $.SetOrGetLanguage(setLang, function () {
                languages = language;
            jQuery("#tb2").find("thead>tr>th:eq(0)").text(type[roid - 2] + languages["H1083"]);
            }, "/js/IndexGlobal/");
        };

        function SetGlobal(setLang) {
            setLang = $.SetOrGetLanguage(setLang, function () {
                languages = language;
                jQuery("#nameP span").text(languages["会员注单"]);
                jQuery(".fa_saurch_in").text(languages["H1058"]);
                jQuery("#zd1").text(languages["H1293"]);
                jQuery("#sy1").text(languages["H1460"]);

                jQuery("#delet2").attr("title", languages["H1168"]);
                jQuery("#tb2>thead>tr>th:eq(0)").text(languages["H1083"]);
                jQuery("#tb2>thead>tr>th:eq(1)").text(languages["H1294"]);
                jQuery("#tb2>thead>tr>th:eq(2)").text(languages["H1295"]);
                jQuery("#tb2>thead>tr>th:eq(3)").html(languages["H1296"]);
                jQuery("#tb2>thead>tr>th:eq(4)").text(languages["H1297"]);
                jQuery("#tb2>thead>tr>th:eq(5)").text(languages["H1298"]);
                jQuery("#tb2>thead>tr>th:eq(6)").html(languages["H1299"]);

                jQuery("#tb>thead>tr>th:eq(0)").text(languages["H1026"]);
                jQuery("#tb>thead>tr>th:eq(1)").text(languages["H1169"]);
                jQuery("#tb>thead>tr>th:eq(2)").text(languages["H1284"]);
                jQuery("#tb>thead>tr>th:eq(3)").html("<p>" + languages.H1173 + "</p><p>" + languages.H1171 + "</p>");
                jQuery("#tb>thead>tr>th:eq(4)").text(languages["H1172"]);
                jQuery("#tb>thead>tr>th:eq(5)").text(languages["H1070"]);
                <%if (agentRoleID == 2 || agentRoleID == 3 || agentRoleID == 4 || agentRoleID == 5)
      { %>
    jQuery("#tb>thead>tr>th:eq(6)").html("<p>" + languages.H1082 + "</p><p>" + languages.H1285 + "</p><p>" + languages.H1172 + "</p><p>" + languages.H1286 + "</p>");
    <% }%>
    <%if (agentRoleID == 2 || agentRoleID == 3 || agentRoleID == 4)
       { %>
    jQuery("#tb>thead>tr>th:eq(7)").html("<p>" + languages.H1287 + "</p><p>" + languages.H1285 + "</p><p>" + languages.H1172 + "</p><p>" + languages.H1286 + "</p>");
    <%} %>
     <%if (agentRoleID == 2 || agentRoleID == 3)
       { %>
    jQuery("#tb>thead>tr>th:eq(8)").html("<p>" + languages.H1228 + "</p><p>" + languages.H1285 + "</p><p>" + languages.H1172 + "</p><p>" + languages.H1286 + "</p>");
    <%} %>
    <%if (agentRoleID == 2)
      { %>
    jQuery("#tb>thead>tr>th:eq(9)").html("<p>" + languages.H1227 + "</p><p>" + languages.H1285 + "</p><p>" + languages.H1172 + "</p><p>" + languages.H1286 + "</p>");
    <%} %>

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

        var setDate = function (data) {
            if (roid != 7) {
                var url = "/ServicesFile/ReportService/NoteSingleService.asmx/GetUserOrder";
                var data = "userName:'" + currName + "',roleId:'" + roid + "'";
                //debugger
                jQuery.AjaxCommon(url, data, true, false, function (json) {
                    //debugger
                    var result = jQuery.parseJSON(json.d);
                        jQuery("#info").show();
                        jQuery("#delet2").hide();
                        zhsz();
                        jQuery("#showInfo>tr").remove();
                        //for (var i = 0; i < data2.length; i++) {
                        jQuery.each(result, function (i) {
                            //debugger
                            //var a = data2[i];
                            var tr = jQuery("#tr1").clone();
                            tr.find("#zh").html("<a style=\"cursor:hand\" onclick=\"c('0',this,'" + (roid - 1) + "')\">" + result[i].userName + "</a>");
                            tr.find("#hy").text(parseFloat(result[i].amount).toFixed(2));
                            tr.find("#dl").text(parseFloat(result[i].agentAmount).toFixed(2));
                            tr.find("#zd").text(parseFloat(result[i].zagentAmount).toFixed(2));
                            tr.find("#gd").text(parseFloat(result[i].partnerAmount).toFixed(2));
                            tr.find("#fgs").text(parseFloat(result[i].subcompanyAmount).toFixed(2));
                            tr.find("#gs").text(parseFloat(result[i].companyAmount).toFixed(2));
                            tr.appendTo("#showInfo");
                        });
                        if (jQuery("#showInfo>tr").length == 0) {
                            var tr = jQuery("#tr1").clone();
                            tr.find("td:gt(0)").remove();
                            tr.find("#zh").attr("colspan", "6");
                            var setLang = "";
                            setLang = $.SetOrGetLanguage(setLang, function () {
                                languages = language;
                                tr.find("#zh").text(languages["H1013"]);
                            }, "/js/IndexGlobal/");
                            tr.appendTo("#showInfo");
                            jQuery("#pageDiv").hide();
                        }
                        else {
                            jQuery("#pageDiv").show();
                        }
                        jQuery("#pageDiv").hide();

                });
            }
            else {
                jQuery.ajax({ url: "NoteO.aspx", type: "post", data: data1 + "&" + data.replace(/:/g, '=').replace(/,/g, '&'), success: function (json) {
                    json;
                    jQuery("#info").hide();
                    jQuery("#delet2").show();
                    jQuery("#reportInfo>tr").remove();
                    for (var i = 0; i < data2.length; i++) {
                        var a = data2[i];
                        var tr = jQuery("#tr2").clone();
                        tr.find("#ID").text("" + (i + 1));
                        tr.find("#UserNameTD").html("" + a[1] + "<br/>" + a[2] + "<br/>" + a[3]);
                        tr.find("#teamTD").html("" + a[8] + "</br>" + typeList[parseInt(a[0])].substr(2, typeList[parseInt(a[0])].length - 2) + "<br/>" + a[4] + "&nbsp;-VS-&nbsp;" + a[5] + "<br/>" + a[6] + "&nbsp;&nbsp;@&nbsp;&nbsp;" + a[9]);
                        tr.find("#Odds").html(a[10] + "</br>" + a[12] + "</br>" + a[11]);
                        tr.find("#AmountTD").html("" + a[13].substr(0, a[13].indexOf('.') + 3) + "<br/>" + a[14].substr(0, a[14].indexOf('.') + 3));
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            tr.find("#StatusTD").html("" + (a[21] == "1" ? languages["H1469"] : languages["H1292"]));
                        }, "/js/IndexGlobal/");
                        tr.find("#agent").html("" + (a[15] * 100) + "%<br/>" + parseFloat(a[14] * a[15]).toFixed(2) + "<br/>" + (a[12] < 0 ? ((a[14] * a[15]).toString().substr(0, (a[14] * a[15]).toString().indexOf('.') + 3)) : ((a[14] * a[15] * a[12]).toString().substr(0, (a[14] * a[15] * a[12]).toString().indexOf('.') + 3))));
                        tr.find("#zagent").html("" + (a[16] * 100) + "%<br/>" + parseFloat(a[14] * a[16]).toFixed(2) + "<br/>" + (a[12] < 0 ? ((a[14] * a[16]).toString().substr(0, (a[14] * a[16]).toString().indexOf('.') + 3)) : ((a[14] * a[16] * a[12]).toString().substr(0, (a[14] * a[16] * a[12]).toString().indexOf('.') + 3))));
                        tr.find("#partner").html("" + (a[17] * 100) + "%<br/>" + parseFloat(a[14] * a[17]).toFixed(2) + "<br/>" + (a[12] < 0 ? ((a[14] * a[17]).toString().substr(0, (a[14] * a[17]).toString().indexOf('.') + 3)) : ((a[14] * a[17] * a[12]).toString().substr(0, (a[14] * a[17] * a[12]).toString().indexOf('.') + 3))));
                        tr.find("#subCompany").html("" + (a[18] * 100) + "%<br/>" + parseFloat(a[14] * a[18]).toFixed(2) + "<br/>" + (a[12] < 0 ? ((a[14] * a[18]).toString().substr(0, (a[14] * a[18]).toString().indexOf('.') + 3)) : ((a[14] * a[18] * a[12]).toString().substr(0, (a[14] * a[18] * a[12]).toString().indexOf('.') + 3))));
                        tr.find("#IPTD").html("" + web[parseInt(a[19])] + "</br>" + a[20]);
                        tr.appendTo("#reportInfo");
                    }
                    if (jQuery("#reportInfo>tr").length == 0) {
                        var tr = jQuery("#tr2").clone();
                        tr.find("td:gt(0)").remove();
                        tr.find("#ID").attr("colspan", "11");
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            tr.find("#ID").text(languages["H1013"]);
                        }, "/js/IndexGlobal/");
                        tr.appendTo("#reportInfo");
                        jQuery("#pageDiv").hide();
                    }
                    else {
                        jQuery("#pageDiv").show();
                    }
                } 
                });
            }
        }
    </script>
</head>
<body>
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="nameP"><span>注单</span><a></a>&nbsp;&nbsp;&nbsp;&nbsp;</p></th>
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
    <div>
    
    </div>
    <div id="info">
    <table class="tab2" id="tb2" width="100%">
    <thead>
    <tr>
    <th>账号</th>
    <th>會員合计</th>
    <th>代理合计</th>
    <th>總代合计</th>
    <th>股東合计</th>
    <th>分公司合计</th>
    <th>公司合计</th>
    </tr>
    </thead>
    <tbody id="showInfo">
    
    </tbody>
    <tfoot>
    <tr id="tr1">
    <td id="zh"></td>
    <td id="hy"></td>
    <td id="dl"></td>
    <td id="zd"></td>
    <td id="gd"></td>
    <td id="fgs"></td>
    <td id="gs"></td>
    </tr>
    </tfoot>
    </table>
    </div>
    
    <!-- 注单详细DIV -->
    <div id="delet2" title="注单明细">

    <div id="reportDiv" class="showdiv">
    <div class=" h30">
    <!-- 查询条件选择DIV -->
<div class="fl">
</div>
<!-- 查询条件选择DIV结束 -->

<!-- 自动刷新DIV -->
<%--<div class="fr">
<input type="text" id="timeTxt1" value="5" class="text_01 w_30" onmouseover="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" /><label id="timeUp1">5</label>&nbsp;&nbsp;&nbsp;&nbsp;
<input type="text" value="50" id="DataLength1" class="text_01 w_60" onmouseover="this.className='text_01_h w_60'" onmouseout="this.className='text_01 w_60'" />条
    <input type="hidden" value="" id="timeHide1" />
</div>--%>
<!-- 自动刷新DIV结束 -->

</div>
    <table  id="tb" width="100%" class="tab2">
    <thead>
    <tr>
    <th>序号</th>
    <th>资讯</th>
    <th>选择</th>
    <th><p>盘口</p><p>赔率</p></th>
    <th>投注金额</th>
    <th>状态</th>
    <%if (agentRoleID == 2 || agentRoleID == 3 || agentRoleID == 4 || agentRoleID == 5)
      { %>
    <th><p>代理</p><p>占成数</p><p>投注金额</p><p>风险</p></th>
    <% }%>
    <%if (agentRoleID == 2 || agentRoleID == 3 || agentRoleID == 4)
       { %>
    <th><p>总代理</p><p>占成数</p><p>投注金额</p><p>风险</p></th>
    <%} %>
     <%if (agentRoleID == 2 || agentRoleID == 3)
       { %>
    <th><p>股东</p><p>占成数</p><p>投注金额</p><p>风险</p></th>
    <%} %>
    <%if (agentRoleID == 2)
      { %>
    <th><p>分公司</p><p>占成数</p><p>投注金额</p><p>风险</p></th>
    <%} %>
    <th>IP</th>
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
    <%if (agentRoleID == 2 || agentRoleID == 3 || agentRoleID == 4 || agentRoleID == 5)
       { %>
    <td id="agent"></td>
    <%} %>
    <%if (agentRoleID == 2 || agentRoleID == 3 || agentRoleID == 4)
       { %>
    <td id="zagent"></td>
    <%} %>
    <%if (agentRoleID == 2 || agentRoleID == 3)
       { %>
    <td id="partner"></td>
    <%} %>
    <%if (agentRoleID == 2)
      { %>
    <td id="subCompany"></td>
    <%} %>
    <td id="IPTD"></td>
    </tr>
    </tfoot>
    </table>
</div>
    </div>

    <div id="pageDiv" style="width:100%;text-align:center; display:none" class="grayr"><span id="zg">总共</span><label id="infoCount"></label><span id="tjl">条记录</span>,<span id="g">共</span><label id="pageCount"></label><span id="y">页</span><a style="cursor:hand" id="sy"> 首页 </a><a style="cursor:hand" id="syy"> 上一页 </a><span id="pageSpan"></span><a style="cursor:hand" id="xyy"> 下一页 </a><a style="cursor:hand" id="wy"> 尾页 </a></div>
    <!-- 注单详细DIV结束 -->
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
