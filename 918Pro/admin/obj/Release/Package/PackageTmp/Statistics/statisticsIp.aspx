<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="statisticsIp.aspx.cs" Inherits="admin.Statistics.statisticsIp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
<meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
     <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/jQueryCommon.js"></script>
    <script src="/js/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
    <script src="/js/webBasicInfo/zh-CN.js" type="text/javascript"></script>
    <link href="/css/Default/cupertino/jquery-ui-1.8.2.custom.css" rel="stylesheet"
        type="text/css" />
    <style type="text/css">
    .ui-effects-transfer { border: 2px dotted gray; } 
        #divTip
        {
        	left:45%;top:45%; 
        	
        	font-family:sans-serif; position:absolute; font-size:10px;padding:5px;background:#f3f3f3;color:gray;display:none;-moz-border-radius:5px;-webkit-border-radius:5px;border:1px solid #ccc
        }
        #selected{ background:url(/images/default/main/tr_select.gif) bottom repeat-x #fff; border-bottom:1px solid #a8d8eb;}
    </style>

    <script type="text/javascript">

        jQuery(function () {
            //多语言
            SetGlobal("");
        });
        var option = "";
        var uplevel = "";
        var Levelid;
        var levelNames;
        var it = 0;

        //---------多语言处理-----------
        var languages = "";
        var lang;
        function SetGlobal(setLang) {

            setLang = $.SetOrGetLanguage(setLang, function () {
                //debugger
                languages = language;


                //$("#excel").text(languages.H1189);
                $("#ip2").html(languages.H1235);
                $("#countNumber").html(languages.H1219);
                $("#amount2").html(languages.H1220);
                $("#win").html(languages.H1221);
                $("#lost").html(languages.H1222);
                $("#winAmount").html(languages.H1223);
                $("#lostAmount").html(languages.H1224);
                $("#lostRate").html(languages.H1225);
                $(".fa_saurch_in").html(languages.H1198);
                $("#userN").html(languages.H1235);
                $("#sj").text(languages.H1056);
                $("#sjie").html(languages.H1217);

                $("#checkType").text(languages.H1214);
                $("#iptj").text(languages.H1232);
                $("#go").val(languages.H1234);



            });
            lang = setLang;
        }
        //--------多语言处理结束---------


        var setA = {
            select: function () {
                var a = "<option value=\"0\">-- " + languages.H1192 + " --</option>"; //请选择
                a += "<option value=\"wk\">" + languages.H1202 + "</option>"; //周
                a += "<option value=\"tenUp\">" + languages.H1203 + "</option>"; //上旬
                a += "<option value=\"tenIn\">" + languages.H1204 + "</option>"; //中旬
                a += "<option value=\"tenNext\">" + languages.H1205 + "</option>"; //下旬
                a += "<option value=\"halfUp\">" + languages.H1206 + "</option>"; //上半月
                a += "<option value=\"halfNext\">" + languages.H1207 + "</option>"; //下半月
                a += "<option value=\"allM\">" + languages.H1208 + "</option>"; //全月
                a += "<option value=\"oneQuarter\">"+languages.H1209+"</option>";

                jQuery("#type").html(a);
            }
        };
        var setB = {
            select: function () {
                var a = "";
                if (jQuery("#type").val() == "wk") {
                    for (var i = 1; i <= 52; i++) {
                        a += "<option value=\"" + i + "\">" + languages.H1210 + "" + i + "" + languages.H1202 + "</option>";
                    }
                }
                else if (jQuery("#type").val() == "tenUp" || jQuery("#type").val() == "tenIn" || jQuery("#type").val() == "tenNext" || jQuery("#type").val() == "halfUp" || jQuery("#type").val() == "halfNext" || jQuery("#type").val() == "allM") {
                    for (var i = 1; i <= 12; i++) {
                        a += "<option value=\"" + i + "\">" + languages.H1210 + "" + i + "" + languages.H1211 + "</option>";
                    }
                }
                else if (jQuery("#type").val() == "oneQuarter") {
                    for (var i = 1; i <= 4; i++) {
                        a += "<option value=\"" + i + "\">" + languages.H1210 + "" + i + "" + languages.H1209 + "</option>";
                    }
                }

                if (jQuery("#type").val() != "0") {
                    $("#where").show();
                    $("#where").html(a);
                } else {
                    $("#where").hide();
                }
            }
        };

        var group;
        jQuery(function () {
            $("#Myshow").hide();
            $("#go").hide();
            jQuery("#Thead>tr>th").click(function () {
                group = jQuery(this).attr("attr");
                selectByWhere();
                jQuery(this).attr("class", "selected").siblings().removeClass("selected");

            });

            //延时加载
            var t1 = setInterval(function () {
                setA.select();
                setB.select();
                clearInterval(t1);
            }, 100);

            jQuery("#type").change(function () {
                setB.select();
            });

            $("#time1WhereVal").datepicker();

            $("#time2WhereVal").datepicker();

            tr = jQuery("#info").clone();
            tr.html("<td height=\"20\" colspan=\"20\"></td>");
            tr.appendTo("#tab");
            $("#select1").click(function () {
                if ($("#select1").attr("checked")) {
                    $("#type").show();
                    $("#userN").show();
                    $("#ip").show();

                    group = "userName";
                    it = 1;
                    $("#time1WhereVal").val("");
                    $("#time2WhereVal").val("");
                    $("#time1WhereVal").hide();
                    $("#time2WhereVal").hide();
                    $("#sel2").hide();
                }
            });
            $("#select2").click(function () {
                if ($("#select2").attr("checked")) {
                    $("#type").hide();
                    $("#userN").show();
                    $("#ip").show();

                    group = "userName";
                    it = 2;
                    jQuery("#type>option:eq(0)").attr("selected", "selected");
                    $("#where").hide();
                    $("#time1WhereVal").show();
                    $("#time2WhereVal").show();
                    $("#sel2").show();
                }
            });

            jQuery("#ulevel").click(function () {
                jQuery.AjaxCommon("/ServicesFile/ReportWebService.asmx/GetGrade", "", true, false, function (json) {
                    if (json.d != "none") {
                        $("#userLevel").hide();
                        $("#ulevel").hide();
                        $("#cancel").hide();
                        $("#esc").show();
                        $("#level").show();
                        $("#update").show();
                        var count = 0;
                        jQuery("#level>option:gt(0)").remove();
                        var result = jQuery.parseJSON(json.d);
                        jQuery.each(result, function (i) {
                            option = jQuery("#levelName").clone()
                            if (levelNames == result[i].LevelName) {
                                option.attr("selected", "selected");
                            }
                            else {
                                option.removeAttr("selected");
                            }
                            option.text(result[i].LevelName);
                            option.appendTo("#level");
                        });
                        $("#levelName").val(levelNames);
                        jQuery("#level>option:eq(0)").remove();
                    }
                });
            });

            jQuery("#esc").click(function () {
                $("#userLevel").show();
                $("#ulevel").show();
                $("#cancel").show();
                $("#esc").hide();
                $("#level").hide();
                $("#update").hide();
            });
        });

        function GetStatisticsIpY(data) {
            jQuery.AjaxCommon("/ServicesFile/ReportWebService.asmx/GetStatisticsIpY", data, true, false, function (json) {
                if (json.d != "none") {
                    var result = jQuery.parseJSON(json.d);
                    jQuery("#tab>tr").remove();
                    jQuery.each(result, function (i) {
                        var tr = jQuery("#datarow").clone();
                        tr.find("#tduserIP").html("<a id=\"status\" style=\"cursor:hand\" onclick=\"showInfo(this,'" + result[i].ip + "')\">" + result[i].ip + "</a>");
                        //tr.find("#tduserIP").text(result[i].ip);
                        tr.find("#tdcountNumber").text(result[i].countNumber + " " + languages.H1215);
                        tr.find("#tdamount").text(result[i].amount + " ￥");
                        tr.find("#tdwin").text(result[i].win + " " + languages.H1215);
                        tr.find("#tdlost").text(result[i].lost + " " + languages.H1215);
                        tr.find("#tdwinAmount").text(result[i].winAmount + " ￥");
                        tr.find("#tdlostAmount").text(result[i].lostAmount + " ￥");
                        tr.find("#tdlostRate").text(parseFloat(result[i].lostRate).toFixed(2) + " %");
                        tr.appendTo("#tab");
                    });
                }
                else {
                    jQuery("#tab>tr").remove();
                    tr = jQuery("#info").clone();
                    tr.html("<td height=\"20\" colspan=\"20\"></td>");
                    tr.appendTo("#tab");
                    jQuery.MsgTip({ objId: "#divTip", msg: languages.H1195 });

                }
            });

        }

        function selectByWhere() {
            $("#Myshow").hide();
            $("#go").hide();
            $("#UIP").show();
            var type = $("#type").val();
            var where = $("#where").val();
            if (type != "0" || $("#time1WhereVal").val() != "" || $("#time2WhereVal").val() != "") {
                if (type == "0") {
                    type = "";
                }
                if ($("#time1WhereVal").val() == "" && $("#time2WhereVal").val() != "") {
                    jQuery("#tab>tr").remove();
                    tr = jQuery("#info").clone();
                    tr.html("<td height=\"20\" colspan=\"20\"></td>");
                    tr.appendTo("#tab");
                    jQuery.MsgTip({ objId: "#divTip", msg: languages.H1212 });
                } else {
                    if (it == 1) {
                        if (type != "") {
                            var data = "type:'" + type + "',number:" + where + ",group:'" + group + "',sort:" + 0 + ",user:''" + ",ip:'" + $("#ip").val() + "'";
                            GetStatisticsIpY(data);
                        } else {
                            jQuery("#tab>tr").remove();
                            tr = jQuery("#info").clone();
                            tr.html("<td height=\"20\" colspan=\"20\"></td>");
                            tr.appendTo("#tab");
                            jQuery.MsgTip({ objId: "#divTip", msg: languages.H1213 });
                        }
                    }
                    if (it == 2) {
                        var data = "time1:'" + $("#time1WhereVal").val() + " " + $("#time1").val() + "',time2:'" + $("#time2WhereVal").val() + " " + $("#time2").val() + "',group:'" + group + "',sort:" + 0 + ",user:''" + ",ip:'" + $("#ip").val() + "'";
                        GetStatisticsIpT(data);
                    }
                }
            } else {
                jQuery("#tab>tr").remove();
                tr = jQuery("#info").clone();
                tr.html("<td height=\"20\" colspan=\"20\"></td>");
                tr.appendTo("#tab");
                if (it == 1) {
                    jQuery.MsgTip({ objId: "#divTip", msg: languages.H1213 });
                }
                if (it == 2) {
                    jQuery.MsgTip({ objId: "#divTip", msg: languages.H1193 });
                }
                if (it == 0) {
                    jQuery.MsgTip({ objId: "#divTip", msg: languages.H1214 });
                }
            }
        }

        function GetStatisticsIpT(data) {
            jQuery.AjaxCommon("/ServicesFile/ReportWebService.asmx/GetStatisticsIpT", data, true, false, function (json) {
                if (json.d != "none") {
                    var result = jQuery.parseJSON(json.d);
                    jQuery("#tab>tr").remove();
                    jQuery.each(result, function (i) {
                        var tr = jQuery("#datarow").clone();
                        tr.find("#tduserIP").html("<a id=\"status\" style=\"cursor:hand\" onclick=\"showInfo(this,'" + result[i].ip + "')\">" + result[i].ip + "</a>");
                        //tr.find("#tduserIP").text(result[i].ip);
                        tr.find("#tdcountNumber").text(result[i].countNumber + " "+languages.H1215);
                        tr.find("#tdamount").text(result[i].amount + " ￥");
                        tr.find("#tdwin").text(result[i].win + " " + languages.H1215);
                        tr.find("#tdlost").text(result[i].lost + " " + languages.H1215);
                        tr.find("#tdwinAmount").text(result[i].winAmount + " ￥");
                        tr.find("#tdlostAmount").text(result[i].lostAmount + " ￥");
                        tr.find("#tdlostRate").text(parseFloat(result[i].lostRate).toFixed(2) + " %");
                        tr.appendTo("#tab");
                    });
                }
                else {
                    jQuery("#tab>tr").remove();
                    tr = jQuery("#info").clone();
                    tr.html("<td height=\"20\" colspan=\"20\"></td>");
                    tr.appendTo("#tab");
                    jQuery.MsgTip({ objId: "#divTip", msg: languages.H1195 });

                }
            });
        }

        function showInfo(obj, ip) {
            jQuery("#TbodyUser>tr").remove();
            $("#Myshow").show();
            $("#go").show();
            $("#UIP").hide();
            var data = "Ip:'" + ip + "',language:'" + $("#language").val() + "'";
            var url = "/ServicesFile/ReportWebService.asmx/StatisticsIp";
            var type = $("#type").val();
            var where = $("#where").val();
            if (type != "0" || $("#time1WhereVal").val() != "" || $("#time2WhereVal").val() != "") {
                if (type == "0") {
                    type = "";
                }
                if ($("#time1WhereVal").val() == "" && $("#time2WhereVal").val() != "") {
                    jQuery("#TbodyUser>tr").remove();
                    tr = jQuery("#info").clone();
                    tr.html("<td height=\"20\" colspan=\"20\"></td>");
                    tr.appendTo("#TbodyUser");
                    jQuery.MsgTip({ objId: "#divTip", msg: languages.H1212 });
                } else {
                    if (it == 1) {
                        if (type != "") {
                            data = "type:'" + type + "',number:" + where + ",group:'time',sort:" + 1 +  ",ip:'" + ip + "',language:'" + $("#language").val() + "'"; ;
                            url = "/ServicesFile/ReportWebService.asmx/StatisticsIpY";
                        } else {
                            jQuery("#TbodyUser>tr").remove();
                            tr = jQuery("#info").clone();
                            tr.html("<td height=\"20\" colspan=\"20\"></td>");
                            tr.appendTo("#TbodyUser");
                            jQuery.MsgTip({ objId: "#divTip", msg: languages.H1213 });
                        }
                    }
                    if (it == 2) {
                        data = "time1:'" + $("#time1WhereVal").val() + " " + $("#time1").val() + "',time2:'" + $("#time2WhereVal").val() + " " + $("#time2").val() + "',group:'time',sort:" +1 + ",ip:'" + ip + "',language:'" + $("#language").val() + "'"; ;
                        url = "/ServicesFile/ReportWebService.asmx/StatisticsIpT";
                    }
                }
            }
            jQuery.AjaxCommon(url, data, true, false, function (json) {
                if (json.d != "none") {
                    var result = jQuery.parseJSON(json.d);
                    var Sequence = 0;
                    jQuery("#TbodyUser>tr").remove();
                    jQuery.each(result, function (i) {
                        Sequence++;
                        var tr = jQuery("#TrUser").clone();
                        tr.find("#SequenceId").html(Sequence);
                        tr.find("#User").text(result[i].UserName);
                        tr.find("#Time").text(result[i].time);
                        tr.find("#Team").html(result[i].Home + " -vs- " + result[i].Away + "<br/>" + result[i].league);
                        tr.find("#Odds").html(result[i].Odds);
                        tr.find("#Amount").html(result[i].Amount + "<br/> <Label style=\"color:#A4A49D\">" + result[i].ValidAmount + "<Label/>");
                        var y = "";
                        if (parseFloat(result[i].Result) > 0) {
                            y = languages.H1394;
                        } else if (parseFloat(result[i].Result) == 0) {
                            y = "平";
                        }
                        else {
                            y = languages.H1415;
                        }
                        tr.find("#Status").html(y + "<br/> " + result[i].Result);
                        tr.appendTo("#TbodyUser");
                    });
                }
                else {
                    jQuery("#tab>tr").remove();
                    tr = jQuery("#info").clone();
                    tr.html("<td height=\"20\" colspan=\"20\"></td>");
                    tr.appendTo("#tab");
                    jQuery.MsgTip({ objId: "#divTip", msg: languages.H1195 });

                }
            });
        }

        function Esc() {
            $("#Myshow").hide();
            $("#go").hide();
            $("#UIP").show();
        }

        function setExcel(divId, hidenId) {
            jQuery("#" + hidenId).val(jQuery("#" + divId).html());
            jQuery("#nameValue").val(jQuery("#nameP").text());
            return true;
        }


      
    </script>
</head>
<body>
    <form id="form1" runat="server">
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="iptj">IP统计</p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<!--主题部分开始=========================================================================================-->
<%if (selectAc || excelAc)
  { %>
<div class="top_banner h30">

<div class="f1">
<%if (selectAc)
  { %>
&nbsp;<span id="checkType">請選擇查詢方式</span>：&nbsp;&nbsp;&nbsp;&nbsp;<input id="select1" type="radio" value="1" name="group[1]" /><span id="sjie">時節</span>&nbsp;&nbsp;<select id="type" style="display:none"></select>&nbsp;&nbsp;<select id="where" style="display:none" ></select><input type="hidden" id="language" value="tw"/>&nbsp;&nbsp;
<input id="select2" type="radio" value="2" name="group[1]" /><span id="sj">时间</span>&nbsp;&nbsp;<span id="sel2" style="display:none"><input type="text" id="time1WhereVal" style="display:none" class="text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />小时<input type="text" id="time1" class="text_01 w_30" onmouseover="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" />-&nbsp;&nbsp;
<input type="text" id="time2WhereVal" style="display:none" class="text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />小时<input type="text" id="time2" class="text_01 w_30" onmouseover="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" /></span>&nbsp;&nbsp;&nbsp;
<span id="userN" style="display:none">IP：</span>&nbsp;&nbsp;<input type="text" id="ip" style="display:none" class="text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;&nbsp;&nbsp;
<a id="selectByWhere" class="fa_saurch" onclick="selectByWhere()"><span class="fa_saurch_in">查詢</span></a>&nbsp;&nbsp;&nbsp;&nbsp;
<input type="hidden" runat="server" id="hfContent" />
<input type="hidden" runat="server" id="nameValue" />
<%} %>
<%if (excelAc)
  { %>
<asp:LinkButton runat="server" ID="excel"  OnClientClick="return setExcel('divExcel','hfContent')" Text="导出Excel" onclick="excel_Click" />
<%} %>&nbsp;&nbsp;&nbsp;&nbsp;
<input type="button" id="go" onclick="Esc()" style="cursor:hand" class="btn_02" size="1"  value="<< 返回 " />
</div>
</div>
<%} %>
<div class="cl"></div>
<div id="divExcel">
    <table width="100%" class="tab2" id="UIP">
    <thead id="Thead">
     <tr style="cursor:hand">
       <th id="ip2" attr="ip">IP地址</th>
       <th id="countNumber" attr="countNumber">下注总笔数</th>
       <th id="amount2" attr="amount">下注总金额</th>
       <th id="win" attr="win">赢多少笔</th>
       <th id="lost" attr="lost">输多少笔</th>
       <th id="winAmount" attr="winAmount">赢多少钱</th>
       <th id="lostAmount" attr="lostAmount">输多少钱</th>
       <th id="lostRate" attr="lostRate">胜率</th>
    </tr>
    </thead>
    <tbody id="tab">
    
    </tbody>
    <tfoot>
     <tr id="datarow">
        <td id="tduserIP" style="text-align:center"></td>
        <td id="tdcountNumber" style="text-align:center"></td>
        <td id="tdamount" style="text-align:center"></td>
        <td id="tdwin" class="blue" style="text-align:center"></td>
        <td id="tdlost" class="red" style="text-align:center"></td>
        <td id="tdwinAmount" class="blue" style="text-align:center"></td>
        <td id="tdlostAmount" class="red" style="text-align:center"></td>
        <td id="tdlostRate" style="text-align:center"></td>
        </tr>
        <tr id="info"></tr>

        <tr>
        <td colspan="8">&nbsp;</td>
        </tr>
    </tfoot>
    </table>

    <table width="100%" class="tab2" id="Myshow">
    <thead>
    <tr align="center">
    <td>序号</td>
    <td>帐号</td>
    <td>时间</td>
    <td>选择队伍</td>
    <td>赔率</td>
    <td>投注金额</td>
    <td>状态</td>
    </tr>
    </thead>
    <tbody id="TbodyUser">
    
    </tbody>
    <tfoot>
    <tr id="TrUser">
    <td id="SequenceId"></td>
    <td id="User"></td>
    <td id="Time"></td>
    <td id="Team"></td>
    <td id="Odds"></td>
    <td id="Amount"></td>
    <td id="Status"></td>
    </tr>
    </tfoot>
    </table>
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
<div id="loading"></div>
<div id="divTip" ></div>

    </form>
</body>
</html>
