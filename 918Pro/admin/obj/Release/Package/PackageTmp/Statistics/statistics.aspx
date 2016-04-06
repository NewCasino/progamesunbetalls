<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="statistics.aspx.cs" Inherits="admin.Statistics.statistics" %>

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
        var languages = "",lang;
        jQuery(function () {
            //多语言
            SetGlobal("");
        })
        //---------多语言处理-----------

        function SetGlobal(setLang) {

            setLang = $.SetOrGetLanguage(setLang, function () {
                //debugger
                languages = language;


                $("#excel").attr("value", languages.H1189);
                $("#id").html(languages.H1218);
                $("#countNumber").html(languages.H1219);
                $("#amount").html(languages.H1220);
                $("#win").html(languages.H1221);
                $("#lost").html(languages.H1222);
                $("#winAmount").html(languages.H1223);
                $("#lostAmount").html(languages.H1224);
                $("#lostRate").html(languages.H1225);
                $(".fa_saurch_in").html(languages.H1198);
                $("#userN").html(languages.H1218);
                $("#sj").text(languages.H1056);
                $("#sjie").html(languages.H1217);

                $("#checkType").text(languages.H1214);
                $("#tjcx").text(languages.H1216);



            });
            lang = setLang;
            switch (lang) {
                case "zh-cn": case "zh-CN":
                    jQuery("#language").val("cn")
                    break;
                case "zh-tw":
                    jQuery("#language").val("tw")
                    break;
                case "en-us":
                    jQuery("#language").val("en")
                    break;
                default:
                    jQuery("#language").val("cn")
                    break;
            }
        }
        //--------多语言处理结束---------

        var option = "";
        var uplevel = "";
        var Levelid;
        var levelNames;
        var it = 0;
        var setA = {
            select: function () {
                
                var a = "<option value=\"0\">-- " + languages.H1192 + " --</option>"; //请选择
                a += "<option value=\"wk\">" + languages.H1202 + "</option>"; //周
                a += "<option value=\"tenUp\">" + languages.H1203 + "</option>"; //上旬
                a += "<option value=\"tenIn\">" + languages.H1204 + "</option>"; //中旬
                a += "<option value=\"tenNext\">" + languages.H1205 + "</option>"; //下旬
                a += "<option value=\"halfUp\">" + languages.H1206 + "</option>";
                a += "<option value=\"halfNext\">" + languages.H1207 + "</option>";
                a += "<option value=\"allM\">" + languages.H1208 + "</option>";
                a += "<option value=\"oneQuarter\">" + languages.H1209 + "</option>";

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

            jQuery("#Thead>tr>th").click(function () {
                group = jQuery(this).attr("attr");
                selectByWhere();
                jQuery(this).attr("class", "selected").siblings().removeClass("selected");

            });

            //延时执行
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
            jQuery("#selectByWhere1").click(function () {

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
                        jQuery.MsgTip({ objId: "#divTip", msg: languages.H1212 }); //查詢有條件未明確，請指定開始時間！
                    } else {
                        if (it == 1) {
                            debugger;
                            if (type != "") {
                                var data = "type:'" + type + "',number:" + where + ",group:'" + group + "',sort:" + $("#sort").val() + ",user:'" + $("#user").val() + "',ip:''";
                                GetStatisticsY(data);
                            } else {
                                jQuery("#tab>tr").remove();
                                tr = jQuery("#info").clone();
                                tr.html("<td height=\"20\" colspan=\"20\"></td>");
                                tr.appendTo("#tab");
                                jQuery.MsgTip({ objId: "#divTip", msg: languages.H1213 });
                            }
                        }
                        if (it == 2) {
                            var data = "time1:'" + $("#time1WhereVal").val() + " " + $("#time1").val() + "',time2:'" + $("#time2WhereVal").val() + " " + $("#time2").val() + "',group:'" + group + "',sort:" + $("#sort").val() + ",user:'" + $("#user").val() + "',ip:''";
                            GetStatisticsT(data);
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
                        jQuery.MsgTip({ objId: "#divTip", msg: languages.H1213 });
                    }
                    if (it == 0) {
                        jQuery.MsgTip({ objId: "#divTip", msg: languages.H1214 });
                    }
                }

            });
            $("#select1").click(function () {
                if ($("#select1").attr("checked")) {
                    $("#type").show();
                    $("#userN").show();
                    $("#user").show();

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
                    $("#user").show();

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
                jQuery.AjaxCommon("/ServicesFile/ReportWebService.asmx/GetGrade", "language:'" + jQuery("#language").val() + "'", true, false, function (json) {
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
                            option = jQuery("#levelName").clone();
                            if (levelNames == result[i].b) {
                                option.attr("selected", "selected");
                            }
                            else {
                                option.removeAttr("selected");
                            }
                            option.text(result[i].b);
                            option.appendTo("#level");
                        });
                        $("#levelName").val(levelNames);
                        jQuery("#level>option:eq(0)").remove();
                        // jQuery("#level>option:eq(1)").attr("会员", "会员");
                    }
                });
            });

            $("#utrack").click(function () {
                $("#userTrack").hide();
                $("#utrack").hide();
                $("#esc1").show();
                $("#cancel").hide();
                $("#track").show();
                $("#update").show();
                $("#confficient").focus();
            });
            $("#uscale").click(function () {
                $("#userScale").hide();
                $("#scale").show();
                $("#esc2").show();
                $("#cancel").hide();
                $("#uscale").hide();
                $("#update").show();
                $("#propotion").focus();
            });

            jQuery("#update").click(function () {
                var userLevels = "";
                var itUser = $("#level").val();
                var data1 = "name:'" + itUser + "',language:'" + jQuery("#language").val() + "'";
                jQuery.AjaxCommon("/ServicesFile/ReportWebService.asmx/GetGradeId", data1, true, false, function (json) {
                    if (json.d !== "") {
                        var result = jQuery.parseJSON(json.d);
                        jQuery.each(result, function (i) {
                            userLevels = result[i].ID;
                        });
                        if (!IsElJudge("#confficient", "err1", "decimal", languages.H1306, languages.H1350, 20) || !IsElJudge("#propotion", "err2", "decimal", languages.H1306, languages.H1350, 20)) {
                            return false;
                        }
                        var user = $("#tduser").text();
                        var data2 = "UserLevel:'" + userLevels + "',Coefficient:'" + $("#confficient").val() + "',Proportion:'" + $("#propotion").val() + "',userName:'" + user + "'";
                        jQuery.AjaxCommon("/ServicesFile/UserService.asmx/UpdateUserLevel", data2, false, false, function (json) {
                            if (json.d) {
                                jQuery.MsgTip({ objId: "#divTip", msg: languages.H1012 });
                                $("#tab>tr:eq(" + $("#tduser").attr("attr") + ")").removeAttr("attr");
                                $("#tab>tr:eq(" + $("#tduser").attr("attr") + ")").attr("attr", "" + $("#level").val());
                                uplevel = $("#level").val();
                                levelNames = uplevel;
                                $("#userLevel").text(uplevel);
                                $("#userTrack").text($("#confficient").val());
                                $("#userScale").text($("#propotion").val());
                                $("#level").hide();
                                $("#scale").hide();
                                $("#track").hide();
                                $("#esc").hide();
                                $("#esc1").hide();
                                $("#esc2").hide();
                                $("#update").hide();
                                $("#ulevel").show();
                                $("#utrack").show();
                                $("#uscale").show();
                                $("#userLevel").show();
                                $("#userTrack").show();
                                $("#userScale").show();
                                $("#cancel").show();
                                jQuery("#showInfo").dialog("close");
                                // uplevel = "";
                            }
                            else {
                                jQuery.MsgTip({ objId: "#divTip", msg: languages.H1185 });
                            }
                        });
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
            $("#esc1").click(function () {
                $("#userTrack").show();
                $("#utrack").show();
                $("#track").hide();
                $("#cancel").show();
                $("#update").hide();
                $("#esc1").hide();
            });
            $("#esc2").click(function () {
                $("#userScale").show();
                $("#uscale").show();
                $("#scale").hide();
                $("#cancel").show();
                $("#update").hide();
                $("#esc2").hide();
            });
        });

        function GetStatisticsY(data) {
            jQuery.AjaxCommon("/ServicesFile/ReportWebService.asmx/GetStatisticsY", data, true, false, function (json) {
                if (json.d != "none") {
                    var result = jQuery.parseJSON(json.d);
                    jQuery("#tab>tr").remove();
                    jQuery.each(result, function (i) {
                        var tr = jQuery("#datarow").clone();
                        tr.attr("attr", "" + result[i].userLevel);
                        tr.find("#tduserName").html("<a id=\"status\" style=\"cursor:hand\" onclick=\"showInfo(this,'" + result[i].userName + "','" + i + "')\">" + result[i].userName + "</a>");
                        tr.find("#tdcountNumber").text(result[i].countNumber + " " + languages.H1215);
                        tr.find("#tdamount").text(result[i].amount + " ￥");
                        tr.find("#tdwin").text(result[i].win + " " + languages.H1215);
                        tr.find("#tdlost").text(result[i].lost + " "+languages.H1215);
                        tr.find("#tdwinAmount").text(result[i].winAmount + " ￥");
                        tr.find("#tdlostAmount").text(result[i].lostAmount + " ￥");
                        tr.find("#tdlostRate").text(parseFloat(result[i].lostRate).toFixed(2) + " %");
                        tr.appendTo("#tab");
                    });
                }
                else {
                    jQuery("#tab>tr").remove();
                    var tr = jQuery("#info").clone();
                    tr.html("<td height=\"20\" colspan=\"20\"></td>");
                    tr.appendTo("#tab");
                    //jQuery.MsgTip({ objId: "#divTip", msg: "暫無記錄" });
                    jQuery.MsgTip({ objId: "#divTip", msg: languages.H1195 });
                }
            });
        
        }

        function selectByWhere() {
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
                    //jQuery.MsgTip({ objId: "#divTip", msg: "查詢有條件未明確，請指定開始時間！" });
                    jQuery.MsgTip({ objId: "#divTip", msg: languages.H1212 });
                } else {
                    if (it == 1) {
                        if (type != "") {
                            var data = "type:'" + type + "',number:" + where + ",group:'" + group + "',sort:" + 0 + ",user:'" + $("#user").val() + "',ip:''";
                            GetStatisticsY(data);
                        } else {
                            jQuery("#tab>tr").remove();
                            tr = jQuery("#info").clone();
                            tr.html("<td height=\"20\" colspan=\"20\"></td>");
                            tr.appendTo("#tab");
                            jQuery.MsgTip({ objId: "#divTip", msg: languages.H1213 });
                        }
                    }
                    if (it == 2) {
                        var data = "time1:'" + $("#time1WhereVal").val() + " " + $("#time1").val() + "',time2:'" + $("#time2WhereVal").val() + " " + $("#time2").val() + "',group:'" + group + "',sort:" + 0 + ",user:'" + $("#user").val() + "',ip:''";
                        GetStatisticsT(data);
                    }
                }
            } else {
                jQuery("#tab>tr").remove();
                tr = jQuery("#info").clone();
                tr.html("<td height=\"20\" colspan=\"20\"></td>");
                tr.appendTo("#tab");
                if (it == 1) {
                    jQuery.MsgTip({ objId: "#divTip", msg: languages.H1213 });
                    //jQuery.MsgTip({ objId: "#divTip", msg: "請選擇查詢條件" });
                }
                if (it == 2) {
                    jQuery.MsgTip({ objId: "#divTip", msg: languages.H1193 });
                }
                if (it == 0) {
                    jQuery.MsgTip({ objId: "#divTip", msg: languages.H1214 });
                }
            }
        }

        function GetStatisticsT(data) {
            jQuery.AjaxCommon("/ServicesFile/ReportWebService.asmx/GetStatisticsT", data, true, false, function (json) {
                if (json.d != "none") {
                    var result = jQuery.parseJSON(json.d);
                    jQuery("#tab>tr").remove();
                    jQuery.each(result, function (i) {
                        var tr = jQuery("#datarow").clone();
                        tr.attr("attr", "" + result[i].UserLevel);
                        tr.find("#tduserName").html("<a id=\"status\" style=\"cursor:hand\" onclick=\"showInfo(this,'" + result[i].userName + "','" + i + "')\">" + result[i].userName + "</a>");
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
                    var tr = jQuery("#info").clone();
                    tr.html("<td height=\"20\" colspan=\"20\"></td>");
                    tr.appendTo("#tab");
                    //jQuery.MsgTip({ objId: "#divTip", msg: "暫無記錄" });
                    jQuery.MsgTip({ objId: "#divTip", msg: languages.H1195 });
                }
            });
        }

        function showInfo(obj, userName, c) {//, agent, zagent, partner, subCompany, usertrack, userscale
            jQuery("#showInfo").dialog({ modal: false });
            $("#tduser").attr("attr", "" + c);
            $("#tduser").text(userName);
            var usertrack = "", userscale = "", levelNames="";
                $.AjaxCommon("/ServicesFile/UserService.asmx/GetAccountInfo", "userName:'"+userName+"'", true, false, function (json) {
                    if (json.d != "") {
                        var re = jQuery.parseJSON(json.d);
                        $.each(re, function (i) {
                            $("#tdagent").text(re[i].f);
                            $("#tdzagent").text(re[i].e);
                            $("#tdpartner").text(re[i].d);
                            $("#tdsubCompany").text(re[i].c);
                            $("#userTrack").text(re[i].g);
                            $("#userScale").text(re[i].h);
                            usertrack = re[i].g;
                            userscale = re[i].h;
                            $("#confficient").val(usertrack);
                            $("#propotion").val(userscale);
                            var data = "id:" +re[i].r + ",language:'" + jQuery("#language").val() + "'";
                            jQuery.AjaxCommon("/ServicesFile/ReportWebService.asmx/GetGradeName", data, true, false, function (json) {
                                if (json.d != "") {
                                    var result = jQuery.parseJSON(json.d);
                                    jQuery.each(result, function (i) {
                                        $("#userLevel").text(result[i].b);
                                        levelNames = result[i].b;
                                    });
                                }
                            });
                        });
                    }
                });

            jQuery("#cancel").unbind("click");
            jQuery("#cancel").bind("click", function () {
                $("#confficient").val(usertrack);
                $("#propotion").val(userscale);
                $("#userLevel").show();
                $("#ulevel").show();
                $("#cancel").show();
                $("#esc").hide();
                $("#level").hide();
                $("#update").hide();
                jQuery("#showInfo").dialog("close");
            });
            jQuery("#addButton").unbind("click");
            jQuery("#addButton").bind("click", function () {
         
                jQuery("#add").dialog("close");
            });
        }

        function CheckInt(obj) {
           // var v = obj;
            var pattern = /^[1-9]\d*|0$/; //匹配非负整数
           // v.value = v.value.replace(/[^\d]/g, "");

            if (!pattern.test(obj)) {
                // v.value = "";
                return false;
            } else {
            return true;
            }
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
<th width="*" class="tab_top_m"><p id="tjcx">統計查詢</p></th>
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
<%if (selectAc)
  { %>
<div class="f1">&nbsp;<span id="checkType">請選擇查詢方式</span>：&nbsp;&nbsp;&nbsp;&nbsp;<input id="select1" type="radio" value="1" name="group[1]" /><span id="sjie">時節</span>&nbsp;&nbsp;<select id="type" style="display:none"></select>&nbsp;&nbsp;<select id="where" style="display:none" ></select><input type="hidden" id="language" value="tw"/>&nbsp;&nbsp;
<input id="select2" type="radio" value="2" name="group[1]" /><span id="sj">时间</span><span id="sel2" style="display:none"> &nbsp;&nbsp;<input type="text" id="time1WhereVal" style="display:none" class="text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" />小时<input type="text" id="time1" class="text_01 w_30" onmouseover="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" />
<%--<script>
    document.write("<select id='time1'>");
    for (var i = 0; i < 24; i++) {
        document.write("<option value=" + (i + 1) + ">" + (i + 1));
    }
    document.write("</select>");
</script>
--%>-&nbsp;&nbsp;
<input type="text" id="time2WhereVal" style="display:none" class="text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />小时<input type="text" id="time2" class="text_01 w_30" onmouseover="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" />&nbsp;&nbsp;&nbsp;</span>
<span id="userN" style="display:none">帐号：</span>&nbsp;&nbsp;<input type="text" id="user" style="display:none" class="text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;&nbsp;&nbsp;
<a id="selectByWhere" class="fa_saurch" onclick="selectByWhere()"><span class="fa_saurch_in">查询</span></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<input type="hidden" runat="server" id="hfContent" />
<input type="hidden" runat="server" id="nameValue" />
<%} %>
<%if (excelAc)
  { %>
<asp:LinkButton runat="server" ID="excel"  OnClientClick="return setExcel('divExcel','hfContent')" Text="导出Excel" onclick="excel_Click" />
<%} %>
</div>

</div>
<%} %>
<div class="cl"></div>
<div id="divExcel">
    <table width="100%" class="tab2">
    <thead id="Thead">
     <tr style="cursor:hand">
       <th id="id" attr="userName">帐号</th>
       <th id="countNumber" attr="countNumber">下注总笔数</th>
       <th id="amount" attr="amount">下注总金额</th>
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
        <td id="tduserName" style="text-align:center"></td>
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
<div class="undis">
<div id="showInfo" title="帐号归属" >
<div class="showdiv">
       
<table id="inlevel" width="100%" border="0" cellpadding="1" cellspacing="1">
<tr>
<td align="right">分公司：</td>
<td id="tdsubCompany" style="width:60px;height:22px"></td>
<td align="right">股东：</td>
<td id="tdpartner" style="height:22px"></td>
<td></td>
</tr>
<tr>
<td align="right">总代：</td>
<td id="tdzagent" style="width:60px;height:22px"></td>
<td align="right">代理：</td>
<td id="tdagent" style="height:22px"></td>
<td></td>
</tr>
<tr>
<td align="right">帐号：</td>
<td id="tduser" style="height:22px"></td>
<td></td><td></td><td></td>
</tr>
<tr>
<td align="right">等级：</td>
<td align="left" colspan="2"><label id="userLevel"></label><select id="level" style="display:none"><option id="levelName"></option></select></td>
<td align="right" colspan="2"><a id="ulevel" style="cursor:hand;text-align:right">[修改等级]</a>&nbsp;&nbsp;&nbsp;<a id="esc" style="cursor:hand;display:none">[取消]</a></td>
</tr>
<tr>
<td align="right">跟踪系数：</td>
<td align="left" colspan="2"><label id="userTrack"></label><span id="track" style="display:none"><input type="text" id="confficient" size="8" value="" /><label id="err1" style="color:red"></label></span></td>
<td align="right" colspan="2"><a id="utrack" style="cursor:hand;text-align:right">[修改跟踪系数]</a>&nbsp;&nbsp;&nbsp;<a id="esc1" style="cursor:hand;display:none">[取消]</a></td>
</tr>
<tr>
<td align="right">吃货比例：</td>
<td align="left" colspan="2"><label id="userScale"></label><span id="scale" style="display:none"><input type="text" id="propotion" size="8" value="" /><label id="err2" style="color:red"></label></span></td>
<td align="right" colspan="2"><a id="uscale" style="cursor:hand;text-align:right">[修改吃货比例]</a>&nbsp;&nbsp;&nbsp;<a id="esc2" style="cursor:hand;display:none">[取消]</a></td>
</tr>
<tr>
<td colspan="5" align="center" style="height:28px">
 <input type="button" id="update" class="btn_02" value="保存" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" style="display:none"/>
 <input type="button" id="cancel" class="btn_02" value="確定" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
</td>
</tr>
</table>

</div>
</div>
</div>
    </form>
</body>
</html>
