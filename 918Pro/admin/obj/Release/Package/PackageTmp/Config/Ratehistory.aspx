<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ratehistory.aspx.cs" Inherits="admin.Config.Ratehistory" %>

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

    </style>

    <script type="text/javascript">
        var option = "";
        jQuery(function () {
                //多语言
                SetGlobal("");

            <%if(selectAc){ %>
            GetRatetype();
            <%} %>
            $("#time1WhereVal").datepicker();

            $("#time2WhereVal").datepicker();

            jQuery("#selectByWhere").click(function () {
                //debugger;
                var type = $("#type").val()
                if (type != "-- "+languages.H1192+" --" || $("#time1WhereVal").val() != "" || $("#user").val() != "") {
                    if (type == "-- "+languages.H1192+" --") {
                        type = "";
                    }
                    var data = "type:'" + type + "',time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',language:'" + $("#language").val() + "',user:'" + $("#user").val() + "'";
                    //alert(data);
                    GetRate(data);
                } else {
                    jQuery("#tab>tr").remove();
                    tr = jQuery("#info").clone();
                    tr.html("<td height=\"20\" colspan=\"20\"></td>");
                    tr.appendTo("#tab");
                    //jQuery.MsgTip({ objId: "#divTip", msg: "請輸入查詢條件" });
                    jQuery.MsgTip({ objId: "#divTip", msg: languages.H1193 });
                }
            });

            tr = jQuery("#info").clone();
            tr.html("<td height=\"20\" colspan=\"20\"></td>");
            tr.appendTo("#tab");

        });

        //---------多语言处理-----------
        var languages = "";
        var lang;
        function SetGlobal(setLang) {

            setLang = $.SetOrGetLanguage(setLang, function () {
                //debugger
                languages = language;
                
                //$("#H1052").html(languages.H1052);
                $("#addBtn").attr("value", languages.H1189);
                $("#RetaType").html(languages.H1191);
                $("#ExchangeValue").html(languages.H1199);
                $("#Created").html(languages.H1200);
                $("#Operator").html(languages.H1201);
                $("#ip").html(languages.H1235);
                $("#up").html(languages.H1009);
                $("#del").html(languages.H1052);
                $("#hlgl").html(languages.H2003);
                $(".fa_saurch_in").html(languages.H1198);
                $("#Type").html(languages.H1118);
                $("#time").html(languages.H1056);
                $("#OperatorID").html(languages.H2004);
                $("#hghlls").html(languages.H2005);

               
            });
            lang = setLang;
        }
        //--------多语言处理结束---------

        function GetRate(data) {
            jQuery.AjaxCommon("/ServicesFile/RateService.asmx/GetRate", data, true, false, function (json) {
                var tr;
                var type = "";
                var count = 0;
                var td;
                if (json.d != "none") {
                    var result = jQuery.parseJSON(json.d);
                    jQuery("#tab>tr:gt(0)").remove();
                    jQuery.each(result, function (i) {
                        tr = jQuery("#datarow").clone();
                        if (result[i].name != type) {
                            if (type != "") {
                                td.attr("rowspan", "" + count);
                            }
                            type = result[i].name;
                            tr.find("#tdname").html(result[i].name);
                            td = tr.find("#tdname");
                            count = 0;
                        }
                        else {
                            //league = "";
                            tr.find("#tdname").remove();
                        }
                        //tr.find("#tdname").text(result[i].name);
                        tr.find("#tdrate").html(result[i].rate);
                        tr.find("#tdlasttime").text(result[i].lasttime);
                        tr.find("#tdoperator").text(result[i].operator);
                        tr.find("#tdip").text(result[i].ip);
                        tr.appendTo("#tab");
                        count++;
                    });
                    jQuery("#tab>tr:eq(0)").remove();
                    td.attr("rowspan", "" + count);
                }
                else {
                    jQuery("#tab>tr").remove();
                    tr = jQuery("#info").clone();
                    //tr.html("<td height=\"20\" colspan=\"20\">没有当前條件歷史</td>");
                    tr.html("<td height=\"20\" colspan=\"20\">"+ languages.H1194 +"</td>");
                    tr.appendTo("#tab");
                   // jQuery.MsgTip({ objId: "#divTip", msg: "暫無記錄" });
                   jQuery.MsgTip({ objId: "#divTip", msg: languages.H1195 });
                   
                }
            });
        }

        function GetRatetype() {
            jQuery.AjaxCommon("/ServicesFile/RateService.asmx/GetRatetype", "Language:'" + $("#language").val() + "'", false, false, function (json) {
                if (json.d != "none") {
                    var count = 0;
                    jQuery("#type>option:gt(0)").remove();
                    var result = jQuery.parseJSON(json.d);
                    jQuery.each(result, function (i) {
                        option = jQuery("#typeName").clone()
                        option.text(result[i].name_tw);
                        option.appendTo("#type");
                    });
                    jQuery("#type>option:eq(0)").text("-- "+languages.H1192+" --");
                    jQuery("#type>option:eq(0)").attr("selected", "selected");
                }
            });
        }
        var f1;
        function GetRateAll() {
            var url = "/ServicesFile/RateService.asmx/GetRateAll";
            var data = "Language:'" + $("#language").val() + "'";
            f1 = jQuery("#datarow").clone(true);
            jQuery.AjaxCommon(url, data, true, false, function (json) {
                if (json.d != "none") {
                    var result = jQuery.parseJSON(json.d);
                    jQuery("#tab>tr:gt(0)").remove();
                    jQuery.each(result, function (i) {
                        var f = jQuery("#datarow").clone(true);
                        f.find("#tdname").text(result[i].name_tw);
                        f.find("#tdrate").html(result[i].rate);
                        
                        f.find("#tdlasttime").text(result[i].lasttime);
                        f.find("#tdoperator").text(result[i].operator);
                        f.find("#tdip").text(result[i].ip);
                        f.appendTo("#tab");

                    });
                    jQuery("#tab>tr:eq(0)").remove();
                }
                else {

                }
            });
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="xghlls">汇率修改历史</p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<!--主题部分开始=========================================================================================-->
<div class="top_banner h30">
<%if (selectAc)
  { %>
<div class="f1">&nbsp;<label id="Type">类型</label>：<select id="type"><option id="typeName"></option></select><input type="hidden" id="language" value="tw"/>&nbsp;&nbsp;&nbsp;&nbsp;
<label id="time">時間</label>：<input type="text" id="time1WhereVal" class="text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;-
<input type="text" id="time2WhereVal" class="text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;&nbsp;
<label id="OperatorID">操作帐号</label>：<input type="text" id="user" class="text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;&nbsp;&nbsp;
<a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in">查詢</span></a>
</div>
<%} %>
</div>
<div class="cl"></div>
    <table width="100%" class="tab2">
    <thead>
     <tr>
        <th id="RetaType">汇率类型</th>
        <th id="ExchangeValue">汇率值</th>
        <th id="Created">创建时间</th>
        <th id="Operator">操作人</th>
        <th id="ip">IP</th>
        </tr>
    </thead>
    <tbody id="tab">
    
    </tbody>
    <tfoot>
     <tr id="datarow">
        <td id="tdname"></td>
        <td id="tdrate"></td>
        <td id="tdlasttime" style="width:160px"></td>
        <td id="tdoperator" style="width:80px"></td>
        <td id="tdip" style="width:140px"></td>
        </tr>
        <tr id="info"></tr>

        <tr>
        <td colspan="5">

            &nbsp;</td>
        </tr>
    <%--<tr id="total">
    <td id="name"></td>
    <td id="Transfers"></td>
    <td id="Commissions"></td>
    <td id="Td4"></td>
    </tr>--%>
    </tfoot>
    </table>

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
