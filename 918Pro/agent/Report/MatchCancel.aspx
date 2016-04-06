<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MatchCancel.aspx.cs" Inherits="agent.Report.MatchCancel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>取消投注歷史</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="/js/jQueryCommon.js" type="text/javascript"></script>
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
         $(function () {

             SetGlobal("");
             jQuery("#language").val(lang);
         });

         //---------多语言处理-----------
         var languages = "";
         var lang;
         function SetGlobal(setLang) {

             setLang = $.SetOrGetLanguage(setLang, function () {
                 languages = language;
                 var myDate = new Date();
                 var year = myDate.getFullYear().toString();
                 var moth = (myDate.getMonth() + 1).toString();
                 var date = myDate.getDate().toString();
                 //             $("#time1WhereVal").val(year + "-" + moth + "-" + date);
                 //             var data = "time:'" + $("#time1WhereVal").val() + "',language:'" + $("#language").val() + "',status:'0'";
                 //             setData(data);
                 $("#time1WhereVal").datepicker();

                 $("#time2WhereVal").datepicker();

                 jQuery("#selectByWhere").click(function () {
                     if ($("#time1WhereVal").val() == "") {
                         $.MsgTip({ objId: "#divTip", msg: languages.H1382 });
                         return false;
                     }
                     if ($("#time2WhereVal").val() == "") {
                         $.MsgTip({ objId: "#divTip", msg: languages.H1383 });
                         return false;
                     }
                     var data = "time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',language:'" + $("#language").val() + "',status:'0'";
                     setData(data);
                 });

                 $("#nameP").html(languages.H1426);
                 $("#H1056").html(languages.H1056);
                 $("#H1198").html(languages.H1198);
                 $("#H1130").html(languages.H1130);
                 $("#H1266").html(languages.H1266);
                 $("#H1108").html(languages.H1108);
                 $("#H1172").html(languages.H1172);

                 $("#H1270").html(languages.H1270);
                 $("#H1131").html(languages.H1131);
                 $("#H1132").html(languages.H1132);

             });
             lang = setLang;
         }
         //--------多语言处理结束---------

         function setData(data) {
             jQuery.AjaxCommon("/ServicesFile/ReportWebService.asmx/GetMatchAlls", data, false, false, function (json) {
                 jQuery("#showInfo>tr").remove();
                 var result = jQuery.parseJSON(json.d);
                 var league = "";
                 var count = 0;
                 var td;
                 jQuery.each(result, function (i) {
                     var tr;
                     var leagues = result[i].league;
                     tr = jQuery("#leagueInfo").clone();
                     if (result[i].league != league) {
                         if (league != "") {
                             td.attr("rowspan", "" + count);
                         }
                         league = leagues;
                         tr.find("#League").html(result[i].league);
                         td = tr.find("#League");
                         count = 0;
                     }
                     else {
                         //league = "";
                         tr.find("#League").remove();
                     }
                     tr.find("#Team").html(result[i].Home + "  -- vs --  " + result[i].Away);
                     tr.find("#BeginTime").html(result[i].BeginTime);
                     tr.find("#Amount").html(result[i].Amount);
                     tr.find("#Reason").html(result[i].Reason);
                     tr.appendTo("#showInfo");
                     count++;
                 });

                 tr = jQuery("#info").clone();
                 tr.attr("class", "tl");
                 if (result == "") {
                     tr.html("<td height=\"20\" colspan=\"20\" style=\"background-color:#DCF0FD\">" + languages.H1425 + "</td>");
                 }
                 tr.appendTo("#showInfo");
                 td.attr("rowspan", "" + count);
             });

             function fomatdate(time) {
                 var date = new Date(time);
                 var year = date.getYear();
                 var month = date.getMonth() > 8 ? date.getMonth() + 1 : "0" + (date.getMonth() + 1);
                 var day = date.getDate();
                 var h = date.getHours();
                 var m = date.getMinutes();
                 var s = date.getSeconds();
                 var AorP = " ";
                 if (h > 12) {
                     h = h - 12;
                     h = "0" + h;
                     AorP = " PM";
                 }
                 else
                     AorP = " AM";
                 if (h >= 13) {
                     h = h - 12;
                 }
                 if (h < 10) {
                     h = "0" + h;
                 }
                 if (s < 10) {
                     s = "0" + s;
                 }
                 if (m < 10) {
                     m = "0" + m;
                 }
                 var newDate = month + "/" + day + "/" + year + " " + h + ":" + m + ":" + s + ":" + AorP;
                 return newDate;
             }

         }
     </script>
</head>
<body>
    <table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="nameP">取消投注歷史</p></th>
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
<input type="hidden" id="language" value="tw"/>
    <form id="form1" runat="server">
    <div class="top_banner h30">
    <!-- 查询条件选择DIV -->
<%--<div class="fl">
<input id="leagueAll" type="button" value="选择联赛" />&nbsp;&nbsp;&nbsp;&nbsp;
    <input type="button" id="boll" value="选择球队" />&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton runat="server" ID="excel" 
        OnClientClick="return setExcel('divExcel','hfContent')" onclick="excel_Click" Text="导出Excel" />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in">搜索</span></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</div>--%>
<!-- 查询条件选择DIV结束 -->
<input type="hidden" runat="server" id="hfContent" />
<input type="hidden" runat="server" id="nameValue" />

    <div id="selectDiv" style="width:90%" >
        &nbsp;&nbsp;&nbsp;
    <span id="H1056">时间</span>:<input type="text" id="time1WhereVal" class="text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;-
    <input type="text" id="time2WhereVal" class="text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in" id="H1198">查询</span></a>
    </div>

</div>
<!-- 数据显示TABLE -->
<div id="divExcel">
    <table width="100%" class="tab2">
    <thead>
    <tr align="center">
    <th rowspan="2" id="H1130">联赛</th>
    <th colspan="2" id="H1266">队伍</th>
    <th rowspan="2" id="H1108">开赛时间</th>
    <th rowspan="2" id="H1172">投注金额</th>
    <th rowspan="2" id="H1270">取消原因</th>
    </tr>
    <tr>
    <th id="H1131">主队</th>
    <th id="H1132">客队</th>
    </tr>
    </thead>
    <tbody id="showInfo">
    
    </tbody>
    <tfoot>
    <tr id="leagueInfo">
    <td id="League" class="fb"></td>
    <td id="Team" colspan="2"></td>
    <td id="BeginTime"></td>
    <td id="Amount"></td>
    <td id="Reason"></td>
    </tr>
    <tr id="info"></tr>
    <%--<tr id="total">
    <td id="name"></td>
    <td id="Transfers"></td>
    <td id="Commissions"></td>
    <td id="Td4"></td>
    </tr>--%>
    </tfoot>
    </table>
    </div>
    </form>
    
    <!-- 数据显示TABLE结束 -->

    <!-- 联赛选择DIV -->
    <!-- 联赛选择DIV结束 -->


    <!-- 球队选择DIV -->
    <!-- 球队选择DIV结束 -->

    <!-- 注单详细DIV -->
    <!-- 注单详细DIV结束 -->
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
</body>
</html>
