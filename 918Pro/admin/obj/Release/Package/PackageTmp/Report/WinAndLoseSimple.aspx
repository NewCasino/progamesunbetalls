<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WinAndLoseSimple.aspx.cs" Inherits="admin.Report.WinAndLoseSimple" %>

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
         var roleId = 2; //级别
         var upUserName = "";
         var aIndex = 0;
         var roleIds = 0;
         var pd = 0;
         var Id = 0;
         var userId;
         var typeList;
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

                 typeList = new Array();
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

                 $("#Myshow").hide();
                 var myDate = new Date();
                 var year = myDate.getFullYear().toString();
                 var moth = (myDate.getMonth() + 1).toString();
                 var date = myDate.getDate().toString();

                 var f;
                 f = jQuery("#Title").clone();
                 f.find("#Id").text(languages.H1218);
                 f.find("#Shift").text(languages.H1391);
                 f.find("#Effective").text(languages.H1396);
                 f.find("#Money").text(languages.H1397);
                 f.find("#Profit").text(languages.H1398);
                 f.find("#Commison").text(languages.H1399);
                 f.find("#Total").text(languages.H1298);
                 f.find("#Company").text(languages.H1393);
                 f.appendTo("#Tbody1");
                 var tr = jQuery("#info").clone();
                 tr.html("<td height=\"20\" colspan=\"20\" style=\"background-color:#DCF0FD\"></td>");
                 tr.appendTo("#showInfo");
                 tr = jQuery("#total").clone();
                 tr.attr("class", "tc");
                 tr.find("#name").html(languages.H1040);
                 tr.appendTo("#showInfo");

                 $("#time1WhereVal").datepicker();

                 $("#time2WhereVal").datepicker();

                 jQuery("#selectByWhere").click(function () {
                     getCount1('', '2', '0');
                     if ($("#time1WhereVal").val() == "") {
                         $.MsgTip({ objId: "#divTip", msg: languages.H1382 });
                         return false;
                     }
                     if ($("#time2WhereVal").val() == "") {
                         $.MsgTip({ objId: "#divTip", msg: languages.H1383 });
                         return false;
                     }
                     //var data = "time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',language:'" + $("#language").val() + "',status:'1',roleId:'" + roleId + "',ID:'0',UpUserName:'#'";
                     var data = "time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',language:'" + $("#language").val() + "',status:'1',roleId:'2',ID:'0',UpUserName:'#',mtype:'" + jQuery("#mtype").val() + "'";
                     setData(data);
                 });

                 $("#nameP").html(languages.H1052);
                 $("#H1056").html(languages.H1056);
                 $("#H1198").html(languages.H1198);
                 $("#H1259").html(languages.H1259);
                 $("#H1391").val(languages.H1391);
                 $("#H1392").html(languages.H1392);
                 $("#H1328").html(languages.H1328);
                 $("#H1082").html(languages.H1082);
                 $("#H1229").html(languages.H1229);
                 $("#H1228").html(languages.H1228);
                 $("#H1227").html(languages.H1227);
                 $("#H1393").html(languages.H1393);
                 $(".H1394").html(languages.H1394);
                 $(".H1395").html(languages.H1395);
                 $(".H1040").html(languages.H1040);
                 $("#name").html(languages.H1040);
                 $("#H1412").html(languages.H1412);
                 $("#H1460").html(languages.H1460);

                 $("#H1026").html(languages.H1026);
                 $("#H1416").html(languages.H1416);
                 $("#H1284").html(languages.H1284);
                 $("#H1171").html(languages.H1171);
                 $("#H1172").html(languages.H1172);
                 $("#H1070").html(languages.H1070);
                 $("#H1328").html(languages.H1328);
                 $("#H1082").html(languages.H1082);
                 $("#H1229").html(languages.H1229);
                 $("#H1228").html(languages.H1228);

                 $("#H1227").html(languages.H1227);
                 $("#H1393").html(languages.H1393);
                 $("#H1417").html(languages.H1417);
                 $("#H1418").html(languages.H1418);
                 $("#H1419").html(languages.H1419);
                 $("#H1420").html(languages.H1420);
                 $(".classsy").html(languages.H1421);
                 $(".classyj").html(languages.H1395);
             });
             lang = setLang;
         }
         //--------多语言处理结束---------

         function getCount(name, roleIds) {
             pd = 1;
             roleId = parseInt(roleIds) + 1;
//             if (roleId == 6) {
//                 var data = "time:'" + $("#time1WhereVal").val() + "',language:'" + $("#language").val() + "',status:'1',roleId:'" + roleIds + "',ID:'" + $("#ID").val() + "',UpUserName:'" + name + "'";
//             } else {
//                 var data = "time:'" + $("#time1WhereVal").val() + "',language:'" + $("#language").val() + "',status:'1',roleId:'" + roleIds + "',ID:'" + id + "',UpUserName:'" + name + "'";
             //             }

             if (roleId == 7) {
                 var data = "time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',language:'" + $("#language").val() + "',status:'1',userName:'" + name + "',mtype:'" + jQuery("#mtype").val() + "'";
                 upUserName = name;
                 $("#Tbal").hide();
                 $("#Myshow").show();
                 getUserName(data);
             } else {
             var data = "time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',language:'" + $("#language").val() + "',status:'1',roleId:'" + roleId + "',UpUserName:'" + name + "',mtype:'" + jQuery("#mtype").val() + "'";
                 upUserName = name;
                 // upIds = upId;
                 setData(data);
             }

         }
         /*--------------获得该账号下的子集账号结束--------*/
         /*----------------获得丢标记中账号下的子集账号----------*/
         function getCount1(name, roleIds, Index) {
             roleId = parseInt(roleIds);
             if(name == "")
             {
                 name = "#";
             }
             pd = 1;
             if (Index == 0) {
                // roleId = parseInt(id);
                 aIndex = 0;
                 jQuery("#pathP>a:gt(" + Index + ")").remove();
             }
             else {
                 aIndex = Index - 1;
                 jQuery("#pathP>a:gt(" + Index + ")").remove();
                 jQuery("#pathP>a:eq(" + Index + ")").remove();

             }
//             if (id == 6) {
//                 ID = userId;
//             } else {
//                 ID = "";
//             }
             //             roleId = parseInt(id);
             if (roleId == 7) {
                 var data = "time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',language:'" + $("#language").val() + "',status:'1',userName:'" + name + "',mtype:'" + jQuery("#mtype").val() + "'";
                 upUserName = name;
                 $("#Tbal").hide();
                 $("#Myshow").show();
                 getUserName(data);
             } else {
             var data = "time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',language:'" + $("#language").val() + "',status:'1',roleId:'" + roleId + "',UpUserName:'" + name + "',mtype:'" + jQuery("#mtype").val() + "'";
                 upUserName = name;
                 $("#Tbal").show();
                 $("#Myshow").hide();
                 setData(data);
             }

         }


         function round(v, e) {
             var t = 1;
             for (; e > 0; t *= 10, e--);
             for (; e < 0; t /= 10, e++);
             return Math.round(v * t) / t;
         }

         function setData(data) {
             if (roleId == 2) {
                 var f;
                 f = jQuery("#Title").clone();
                 f.find("#Id").text(languages.H1218);
                 f.find("#Shift").text(languages.H1391);
                 f.find("#Effective").text(languages.H1396);
                 f.find("#Money").text(languages.H1397);
                 f.find("#Profit").text(languages.H1398);
                 f.find("#Commison").text(languages.H1399);
                 f.find("#Total").text(languages.H1298);
                 f.find("#Company").text(languages.H1393);
                 //f.appendTo("#Tbody1");
                 $("#Tbody1>tr").remove();
             }
             if (roleId == 3) {
                 var f;
                 f = jQuery("#Title").clone();
                 f.find("#Id").text(languages.H1218);
                 f.find("#Shift").text(languages.H1391);
                 f.find("#Effective").text(languages.H1396);
                 f.find("#Money").text(languages.H1397);
                 f.find("#Profit").text(languages.H1400);
                 f.find("#Commison").text(languages.H1401);
                 f.find("#Total").text(languages.H1402);
                 f.find("#Company").text(languages.H1393);
                 //f.appendTo("#Tbody1");
                 $("#Tbody1>tr").remove();
             }
             if (roleId == 4) {
                 var f;
                 f = jQuery("#Title").clone();
                 f.find("#Id").text(languages.H1218);
                 f.find("#Shift").text(languages.H1391);
                 f.find("#Effective").text(languages.H1396);
                 f.find("#Money").text(languages.H1397);
                 f.find("#Profit").text(languages.H1403);
                 f.find("#Commison").text(languages.H1404);
                 f.find("#Total").text(languages.H1405);
                 f.find("#Company").text(languages.H1393);
                 //f.appendTo("#Tbody1");
                 $("#Tbody1>tr").remove();
             }
             if (roleId == 5) {
                 var f;
                 f = jQuery("#Title").clone();
                 f.find("#Id").text(languages.H1218);
                 f.find("#Shift").text(languages.H1391);
                 f.find("#Effective").text(languages.H1396);
                 f.find("#Money").text(languages.H1397);
                 f.find("#Profit").text(languages.H1406);
                 f.find("#Commison").text(languages.H1407);
                 f.find("#Total").text(languages.H1408);
                 f.find("#Company").text(languages.H1393);
                 //f.appendTo("#Tbody1");
                 $("#Tbody1>tr").remove();
             }
             if (roleId == 6) {
                 var f;
                 f = jQuery("#Title").clone();
                 f.find("#Id").text(languages.H1218);
                 f.find("#Shift").text(languages.H1391);
                 f.find("#Effective").text(languages.H1396);
                 f.find("#Money").text(languages.H1397);
                 f.find("#Profit").text(languages.H1409);
                 f.find("#Commison").text(languages.H1410);
                 f.find("#Total").text(languages.H1411);
                 f.find("#Company").text(languages.H1393);
                 //f.appendTo("#Tbody1");
                 $("#Tbody1>tr").remove();
             }
             f.appendTo("#Tbody1");
             jQuery.AjaxCommon("/ServicesFile/ReportWebService.asmx/GetMatch2", data, true, false, function (json) {
                 jQuery("#showInfo>tr").remove();
                 var result = jQuery.parseJSON(json.d);
                 var league = "";
                 var Transfers = 0;
                 var Commissions = 0;
                 var ValidAmounts=0;
                 var Members=0;
                 var Profites=0;
                 var Results=0;
                 var Companyes=0;
                 //debugger;
                 if (pd) {
                     jQuery("#pathP").html(jQuery("#pathP").html() + (roleId != 2 ? "<a onmouseover=\"this.style.cursor='hand'\" onclick=\"getCount1('" + upUserName + "','" + roleId + "','" + (++aIndex) + "')" + "\"> >" + upUserName + "</a>" : ""));
                 }
                 pd = 0;

                 jQuery.each(result, function (i) {
                     var tr;
                     tr = jQuery("#leagueInfo").clone();
                     $("#ID").val(result[i].ID);
                     //tr.find("#UserName").html((roleId != 6 ? "<a onmouseover=\"this.style.cursor='hand'\" " + ("onclick=\"getCount('" + result[i].UserName + "','" + (roleId) + "')") + "\">" + result[i].UserName + "</a>" : "" + result[i].UserName));
                     tr.find("#UserName").html("<a onmouseover=\"this.style.cursor='hand'\" " + ("onclick=\"getCount('" + result[i].UserName + "','" + (roleId) + "')") + "\">" + result[i].UserName + "</a>");
                     tr.find("#Transfer").html(result[i].result);
                     Transfers += parseFloat(result[i].result);
                     tr.find("#ValidAmount").html(result[i].ValidAmount);
                     ValidAmounts += parseFloat(result[i].ValidAmount);
                     tr.find("#Member").html(parseFloat(result[i].Members).toFixed(2));
                     Members += parseFloat(result[i].Members);

                     if (roleId == 2) {
                         tr.find("#Profits").html(parseFloat(result[i].SubCompany).toFixed(2));
                         Profites += parseFloat(result[i].SubCompany);
                         var SubCompanyCommission = round(result[i].SubCompanyCommission, 2);
                         tr.find("#Commission").html(parseFloat(SubCompanyCommission).toFixed(2));
                         Commissions += parseFloat(SubCompanyCommission);
                         tr.find("#Result").html(parseFloat(result[i].SubCompany * 1 + SubCompanyCommission).toFixed(2));
                         Results += parseFloat(result[i].SubCompany * 1 + SubCompanyCommission);
                     }

                     if (roleId == 3) {
                         tr.find("#Profits").html(parseFloat(result[i].Partner).toFixed(2));
                         Profites += parseFloat(result[i].Partner);
                         var PartnerCommission = round(result[i].PartnerCommission, 2);
                         tr.find("#Commission").html(parseFloat(PartnerCommission).toFixed(2));
                         Commissions += parseFloat(PartnerCommission);
                         tr.find("#Result").html(parseFloat(result[i].Partner * 1 + PartnerCommission).toFixed(2));
                         Results += parseFloat(result[i].Partner * 1 + PartnerCommission);
                     }

                     if (roleId == 4) {
                         tr.find("#Profits").html(parseFloat(result[i].ZAgent).toFixed(2));
                         Profites += parseFloat(result[i].ZAgent);
                         var ZAgentCommission = round(result[i].ZAgentCommission, 2);
                         tr.find("#Commission").html(parseFloat(ZAgentCommission).toFixed(2));
                         Commissions = parseFloat(ZAgentCommission);
                         tr.find("#Result").html(parseFloat(result[i].ZAgent * 1 + ZAgentCommission).toFixed(2));
                         Results += parseFloat(result[i].ZAgent * 1 + ZAgentCommission);
                     }

                     if (roleId == 5) {
                         tr.find("#Profits").html(parseFloat(result[i].Agent).toFixed(2));
                         Profites += parseFloat(result[i].Agent);
                         var AgentCommission = round(result[i].AgentCommission, 2);
                         tr.find("#Commission").html(parseFloat(AgentCommission).toFixed(2));
                         Commissions += parseFloat(AgentCommission);
                         tr.find("#Result").html(parseFloat(result[i].Agent * 1 + AgentCommission).toFixed(2));
                         Results += parseFloat(result[i].Agent * 1 + AgentCommission);
                     }

                     if (roleId == 6) {
                         tr.find("#Profits").html(parseFloat(result[i].Members).toFixed(2));
                         Profites += parseFloat(result[i].Members);
                         var MemberCommission = round(result[i].MemberCommission, 2);
                         tr.find("#Commission").html(parseFloat(MemberCommission).toFixed(2));
                         Commissions += parseFloat(MemberCommission);
                         tr.find("#Result").html(parseFloat(result[i].Members + MemberCommission).toFixed(2));
                         Results += parseFloat(result[i].Members + MemberCommission);
                     }
                     tr.find("#Companys").html(parseFloat(result[i].Companys).toFixed(2));
                     var Company = round(result[i].Companys, 2);
                     Companyes += parseFloat(Company);
                     tr.appendTo("#showInfo");
                 });
                 tr = jQuery("#info").clone();
                 tr.attr("class", "tl");
                 if (result == "") {
                     tr.html("<td height=\"20\" colspan=\"20\" style=\"background-color:#DCF0FD\"></td>");
                 } else {
                     tr.html("<td height=\"20\" colspan=\"20\" style=\"background-color:#DCF0FD\"></td>");
                 }
                 tr.appendTo("#showInfo");
                 tr = jQuery("#total").clone();
                 tr.attr("class", "tc");
                 tr.find("#name").html("全部");
                 tr.find("#Transfers").html((Transfers).toFixed(2));
                 tr.find("#ValidAmounts").html((ValidAmounts).toFixed(2));
                 tr.find("#Members").html((Members).toFixed(2));
                 tr.find("#Profites").html((Profites).toFixed(2));
                 tr.find("#Commissions").html((Commissions).toFixed(2));
                 tr.find("#Results").html((Results).toFixed(2));
                 tr.find("#Companyes").html((Companyes).toFixed(2));
                 
                 tr.appendTo("#showInfo");
             });
         }
         function getUserName(data) {
             jQuery.AjaxCommon("/ServicesFile/ReportWebService.asmx/GetUserName2", data, true, false, function (json) {
                 jQuery("#TbodyUser>tr").remove();
                 var Sequence = 0;
                 var result = jQuery.parseJSON(json.d);
                 if (pd) {
                     jQuery("#pathP").html(jQuery("#pathP").html() + (roleId != 2 ? "<a onmouseover=\"this.style.cursor='hand'\" onclick=\"getCount1('" + upUserName + "','" + roleId + "','" + (++aIndex) + "')" + "\"> >" + upUserName + "</a>" : ""));
                 }
                 pd = 0;
                 jQuery.each(result, function (i) {
                     Sequence++;
                     tr = jQuery("#TrUser").clone();
                     tr.find("#SequenceId").html(Sequence);
                     var time = result[i].BeginTime;
                     //var DateTime = fomatdate(time);
                     tr.find("#Information").html(result[i].UserName + "<br/>" + languages.H1414 + "<br/>" + result[i].time);
                     //tr.find("#Options").html(result[i].Home + " -vs- " + result[i].Away + "<br/>" + result[i].league + "<br>" + time.substring(0, 10));
                     //tr.find("#DetailBetType").html(typeList[parseInt(result[i].BetType)] + "<br>" + result[i].BetItem + "@" + result[i].Handicap);
                     tr.find("#DetailBetType").html("<font color=red>" + result[i].BetItem + "@" + result[i].Handicap + ((result[i].BetType == "4" || result[i].BetType == "5" || result[i].BetType == "6" || result[i].BetType == "7" || result[i].BetType == "14" || result[i].BetType == "15") ? ("&nbsp;" + result[i].Scoreathalf) : "") + "</font><br>" + typeList[parseInt(result[i].BetType)] + "<br><font color=blue>" + result[i].Home + " -vs- " + result[i].Away + "</font><br>" + result[i].league + "@" + time);
                     tr.find("#Odds").html(result[i].Odds + "<br>" + result[i].OddsType);
                     tr.find("#Amount").html(result[i].Amount + "<br/> <Label style=\"color:#A4A49D\">" + result[i].ValidAmount + "<Label/>");

                     var y = "";
                     if (parseFloat(result[i].Result) > 0) {
                         y = languages.H1394;
                     } else if (parseFloat(result[i].Result) < 0) {
                         y = languages.H1415;
                     }
                     else {
                         if (result[i].Status == "0") {
                             y = "取消";
                         }
                         else {
                             y = "平";
                         }
                     }
                     tr.find("#Status").html(y + "<br/> HT " + result[i].Scorehalf + "<br/> FT " + result[i].Score);
                     var MemberCommission = round(result[i].MemberCommission, 2);
                     tr.find("#Memberes").html(parseFloat(result[i].Members).toFixed(2) + "<br/>" + parseFloat(MemberCommission).toFixed(2));
                     var AgentCommission = round(result[i].AgentCommission, 2);
                     tr.find("#Agentes").html(parseFloat(result[i].Agent).toFixed(2) + "<br/>" + parseFloat(AgentCommission).toFixed(2));
                     var ZAgentCommission = round(result[i].ZAgentCommission, 2);
                     tr.find("#ZAgentes").html(parseFloat(result[i].ZAgent).toFixed(2) + "<br/>" + parseFloat(ZAgentCommission).toFixed(2));
                     var PartnerCommission = round(result[i].PartnerCommission, 2);
                     tr.find("#Partneres").html(parseFloat(result[i].Partner).toFixed(2) + "<br/>" + parseFloat(PartnerCommission).toFixed(2));
                     var SubCompanyCommission = round(result[i].SubCompanyCommission, 2);
                     tr.find("#SubCompanyes").html(parseFloat(result[i].SubCompany).toFixed(2) + "<br/>" + parseFloat(SubCompanyCommission).toFixed(2));
                     tr.find("#Td1").html(parseFloat(result[i].Companys).toFixed(2));
                     tr.find("#Percentes").html(parseFloat(result[i].SubCompanyPercent * 100).toFixed(2) + " %<br/>" + parseFloat(result[i].PartnerPercent * 100).toFixed(2) + " %<br/>" + parseFloat(result[i].ZAgentPercent * 100).toFixed(2) + " %<br/>" + parseFloat(result[i].AgentPercent * 100).toFixed(2) + " %");
                     tr.find("#IP").html(result[i].IP);
                     tr.appendTo("#TbodyUser");
                 });
             });
         }
     </script>
</head>
<body>
    <table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="pathP"><font class="st"> <span id="H1412">輸贏</span>：</font><a onmouseover="this.style.cursor='hand'" onclick="getCount1('','2','0')"><span id="H1460"> 首页</span></a></p></th>
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
    <input type="text" id="time2WhereVal" class="text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />
    <select id="mtype">
        <option value="0" selected>外币</option>
        <option value="1">本币</option>
    </select>&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in" id="H1198">查询</span></a>
    </div>

</div>
<!-- 数据显示TABLE -->
<div id="divExcel">
    <table width="100%" class="tab2" id="Tbal">
    <thead id="Tbody1">
    <tr align="center" id="Title">
    <td id="Id"></td>
    <td id="Shift"></td>
    <td id="Effective"></td>
    <td id="Money"></td>
    <td id="Profit"></td>
    <td id="Commison"></td>
    <td id="Total"></td>
    <td id="Company"></td>
    </tr>
    </thead>

    <tbody id="showInfo">
    
    </tbody>
    <tfoot>
    <tr id="leagueInfo">
    <td id="UserName"></td>
    <td id="Transfer"></td>
    <td id="ValidAmount"></td>
    <td id="Member" class="red"></td>
    <td id="Profits"></td>
    <td id="Commission"></td>
    <td id="Result"></td>
    <td id="Companys"></td>
    </tr>
    <tr id="info"></tr>
    <tr id="total">
    <td id="name"></td>
    <td id="Transfers"></td>
    <td id="ValidAmounts"></td>
    <td id="Members"></td>
    <td id="Profites"></td>
    <td id="Commissions"></td>
    <td id="Results"></td>
    <td id="Companyes"></td>
    </tr>
    </tfoot>
    </table>
    <table width="100%" class="tab2" id="Myshow">
    <thead>
    <tr align="center">
    <th rowspan="2" id="H1026">序号</th>
    <th rowspan="2" id="H1416">資訊</th>
    <th rowspan="2" id="H1284">选择</th>
    <th rowspan="2" id="H1171">赔率</th>
    <th rowspan="2" id="H1172">投注金额</th>
    <th rowspan="2" id="H1070">状态</th>
    <th id="H1328">会员</th>
    <th id="H1082">代理</th>
    <th id="H1229">总代</th>
    <th id="H1228">股东</th>
    <th id="H1227">分公司</th>
    <th rowspan="2" id="H1393">公司</th>
    <th rowspan="2"><span id="H1417">分公司占成</span><br /><span id="H1418">股东占成</span><br /><span id="H1419">总代占成</span><br /><span id="H1420">代理占成</span></th>
    <th rowspan="2">IP</th>
    </tr>
    <tr>
    <th><span class="classsy">输赢</span><br/><span class="classyj">佣金</span></th>
    <th><span class="classsy">输赢</span><br/><span class="classyj">佣金</span></th>
    <th><span class="classsy">输赢</span><br/><span class="classyj">佣金</span></th>
    <th><span class="classsy">输赢</span><br/><span class="classyj">佣金</span></th>
    <th><span class="classsy">输赢</span><br/><span class="classyj">佣金</span></th>
    </tr>
    </thead>
    <tbody id="TbodyUser">
    
    </tbody>
    <tfoot>
    <tr id="TrUser">
    <td id="SequenceId"></td>
    <td id="Information"></td>
    <td id="DetailBetType"></td>
    <td id="Odds"></td>
    <td id="Amount"></td>
    <td id="Status"></td>
    <td id="Memberes"></td>
    <td id="Agentes"></td>
    <td id="ZAgentes"></td>
    <td id="Partneres"></td>
    <td id="SubCompanyes"></td>
    <td id="Td1"></td>
    <td id="Percentes"></td>
    <td id="IP"></td>
    </tr>
    </tfoot>
    </table>
    </div>
    <asp:hiddenfield ID="ID" runat="server"></asp:hiddenfield>
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
