<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubCompanyWinAndLose.aspx.cs" Inherits="agent.Report.SubCompanyWinAndLoseSimple" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>输赢</title>
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
        var roleId = 2;
        var upUserName = "";
        var aIndex = 0;
        var roleIds = 0;
        var upIds = 0;
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
                if (date < 10) {
                    date = "0" + date;
                }
                var tr = jQuery("#info").clone();
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

                    var data = "time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',language:'" + $("#language").val() + "',status:'1',roleId:'" + roleId + "',ID:'0',UpUserName:'#'";
                    setData(data);
                });

                var tr = jQuery("#info").clone();
                tr.attr("class", "tl");
                tr.html("<td height=\"20\" colspan=\"20\" style=\"background-color:#DCF0FD\"></td>");
                tr.appendTo("#showInfo");
                var tb = jQuery("#total").clone();
                tb.attr("class", "tc");
                tb.find("#name").html(languages.H1040);
                tb.appendTo("#showInfo");

                $("#H1412").html(languages.H1412);
                $("#H1460").html(languages.H1460);
                $("#H1056").html(languages.H1056);
                $("#H1198").html(languages.H1198);
                $("#zh").html(languages.H1218);
                $("#yj").html(languages.H1391);
                $("#yxje").html(languages.H1396);
                $("#hysy").html(languages.H1409);
                $("#hyyj").html(languages.H1410);
                $("#hyhj").html(languages.H1411);
                $("#dlyl").html(languages.H1406);
                $("#dlyj").html(languages.H1407);
                $("#dlhj").html(languages.H1408);
                $("#zdlyl").html(languages.H1483);
                $("#zdlyj").html(languages.H1484);
                $("#zdlhj").html(languages.H1485);
                $("#gdyl").html(languages.H1400);
                $("#gdyj").html(languages.H1401);
                $("#gdhj").html(languages.H1402);
                $("#fgsyl").html(languages.H1398);
                $("#fgsyj").html(languages.H1399);
                $("#fgshj").html(languages.H1298);
                $("#gs").html(languages.H1393);
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
            //debugger;
            roleId = parseInt(roleIds) + 1;
            if (roleId == 7) {
                var data = "time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',language:'" + $("#language").val() + "',status:'1',userName:'" + name + "'";
                upUserName = name;
                $("#Tbal").hide();
                $("#Myshow").show();
                getUserName(data);
            } else {
                var data = "time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',language:'" + $("#language").val() + "',status:'1',roleId:'" + roleId + "',UpUserName:'" + name + "'";
                upUserName = name;
                upIds = roleId;
                setData(data);
            }
        }
        /*--------------获得该账号下的子集账号结束--------*/
        /*----------------获得丢标记中账号下的子集账号----------*/
        function getCount1(name, roleIds, Index) {
            roleId = parseInt(roleIds);
            if (name == "") {
                name = "#";
            }
            pd = 1;
            if (Index == 0) {
                aIndex = 0;
                jQuery("#pathP>a:gt(" + Index + ")").remove();
            }
            else {
                aIndex = Index - 1;
                jQuery("#pathP>a:gt(" + Index + ")").remove();
                jQuery("#pathP>a:eq(" + Index + ")").remove();
            }
            if (roleId == 7) {
                var data = "time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',language:'" + $("#language").val() + "',status:'1',userName:'" + name + "'";
                upUserName = name;
                $("#Tbal").hide();
                $("#Myshow").show();
                getUserName(data);
            } else {
                var data = "time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',language:'" + $("#language").val() + "',status:'1',roleId:'" + roleId + "',UpUserName:'" + name + "'";
                upUserName = name;
                setData(data);
                $("#Tbal").show();
                $("#Myshow").hide();
            }
        }

        function round(v, e) {
            var t = 1;
            for (; e > 0; t *= 10, e--);
            for (; e < 0; t /= 10, e++);
            return Math.round(v * t) / t;
        }

        function setData(data) {
            jQuery.AjaxCommon("/ServicesFile/ReportWebService.asmx/GetMatch", data, true, false, function (json) {
                jQuery("#showInfo>tr").remove();
                //debugger
                var result = jQuery.parseJSON(json.d);
                var league = "";
                var Transfers = 0;
                var Commissions = 0;
                var Members = 0;
                var MemberCommissions = 0.00;
                var MemberResults = 0;
                var Agents = 0;
                var AgentCommissions = 0;
                var AgentResults = 0;
                var ZAgents = 0;
                var ZAgentCommissions = 0;
                var ZAgentResults = 0;
                var Partners = 0;
                var PartnerCommissions = 0;
                var PartnerResults = 0;
                var SubCompanys = 0;
                var SubCompanyCommissions = 0;
                var SubCompanyResults = 0;
                var CompanyrResults = 0;

                if (pd) {
                    jQuery("#pathP").html(jQuery("#pathP").html() + (roleId != 2 ? "<a onmouseover=\"this.style.cursor='hand'\" onclick=\"getCount1('" + upUserName + "','" + roleId + "','" + (++aIndex) + "')" + "\"> >" + upUserName + "</a>" : ""));
                }
                pd = 0;

                jQuery.each(result, function (i) {
                    var tr;
                    tr = jQuery("#leagueInfo").clone();

                    tr.find("#UserName").html("<a onmouseover=\"this.style.cursor='hand'\" " + ("onclick=\"getCount('" + result[i].UserName + "','" + (roleId) + "')") + "\">" + result[i].UserName + "</a>");
                    tr.find("#BetType").html(result[i].BetType);
                    tr.find("#Transfer").html(result[i].result);
                    Transfers += parseFloat(result[i].result);
                    tr.find("#Commission").html(result[i].ValidAmount);
                    Commissions += parseFloat(result[i].ValidAmount);

                    tr.find("#Member").html(parseFloat(result[i].Members).toFixed(2));
                    Members += parseFloat(result[i].Members);
                    var MemberCommission = round(result[i].MemberCommission, 2);
                    tr.find("#MemberCommission").html(parseFloat(MemberCommission).toFixed(2));
                    MemberCommissions += parseFloat(MemberCommission);
                    tr.find("#MemberResult").html(parseFloat(result[i].Members * 1 + MemberCommission).toFixed(2));
                    MemberResults += parseFloat(result[i].Members + MemberCommission);

                    tr.find("#Agent").html(parseFloat(result[i].Agent).toFixed(2));
                    Agents += parseFloat(result[i].Agent);
                    var AgentCommission = round(result[i].AgentCommission, 2);
                    tr.find("#AgentCommission").html(parseFloat(AgentCommission).toFixed(2));
                    AgentCommissions += parseFloat(AgentCommission);
                    tr.find("#AgentResult").html(parseFloat(result[i].Agent * 1 + AgentCommission).toFixed(2));
                    AgentResults += parseFloat(result[i].Agent * 1 + AgentCommission);
                    // debugger;
                    tr.find("#ZAgent").html(parseFloat(result[i].ZAgent).toFixed(2));
                    ZAgents += parseFloat(result[i].ZAgent);
                    var ZAgentCommission = round(result[i].ZAgentCommission, 2);
                    tr.find("#ZAgentCommission").html(parseFloat(ZAgentCommission).toFixed(2));
                    ZAgentCommissions = parseFloat(ZAgentCommission);
                    tr.find("#ZAgentResult").html(parseFloat(result[i].ZAgent * 1 + ZAgentCommission).toFixed(2));
                    ZAgentResults += parseFloat(result[i].ZAgent * 1 + ZAgentCommission);

                    tr.find("#Partner").html(parseFloat(result[i].Partner).toFixed(2));
                    Partners += parseFloat(result[i].Partner);
                    var PartnerCommission = round(result[i].PartnerCommission, 2);
                    tr.find("#PartnerCommission").html(parseFloat(PartnerCommission).toFixed(2));
                    PartnerCommissions += parseFloat(PartnerCommission);
                    tr.find("#PartnerResult").html(parseFloat(result[i].Partner * 1 + PartnerCommission).toFixed(2));
                    PartnerResults += parseFloat(result[i].Partner * 1 + PartnerCommission);

                    tr.find("#SubCompany").html(parseFloat(result[i].SubCompany).toFixed(2));
                    SubCompanys += parseFloat(result[i].SubCompany);
                    var SubCompanyCommission = round(result[i].SubCompanyCommission, 2);
                    tr.find("#SubCompanyCommission").html(parseFloat(SubCompanyCommission).toFixed(2));
                    SubCompanyCommissions += parseFloat(SubCompanyCommission);
                    tr.find("#SubCompanyResult").html(parseFloat(result[i].SubCompany * 1 + SubCompanyCommission).toFixed(2));
                    SubCompanyResults += parseFloat(result[i].SubCompany * 1 + SubCompanyCommission);

                    tr.find("#CompanyrResult").html(parseFloat(result[i].Companys).toFixed(2));
                    var Company = round(result[i].Companys, 2);
                    CompanyrResults += parseFloat(Company);
                    tr.appendTo("#showInfo");
                });
                tr = jQuery("#info").clone();
                tr.attr("class", "tl");
                if (result == "") {
                    tr.html("<td height=\"20\" colspan=\"20\" style=\"background-color:#DCF0FD\">" + languages.H1413 + "</td>");
                } else {
                    tr.html("<td height=\"20\" colspan=\"20\" style=\"background-color:#DCF0FD\"></td>");
                }
                tr.appendTo("#showInfo");
                tr = jQuery("#total").clone();
                tr.attr("class", "tc");
                tr.find("#name").html(languages.H1040);
                tr.find("#Transfers").html((Transfers).toFixed(2));
                tr.find("#Commissions").html((Commissions).toFixed(2));
                tr.find("#Members").html((Members).toFixed(2));
                tr.find("#MemberCommissions").html((MemberCommissions).toFixed(2));
                tr.find("#MemberResults").html((MemberResults).toFixed(2));
                tr.find("#Agents").html((Agents).toFixed(2));
                tr.find("#AgentCommissions").html((AgentCommissions).toFixed(2));
                tr.find("#AgentResults").html((AgentResults).toFixed(2));
                tr.find("#ZAgents").html((ZAgents).toFixed(2));
                tr.find("#ZAgentCommissions").html((ZAgentCommissions).toFixed(2));
                tr.find("#ZAgentResults").html((ZAgentResults).toFixed(2));
                tr.find("#Partners").html((Partners).toFixed(2));
                tr.find("#PartnerCommissions").html((PartnerCommissions).toFixed(2));
                tr.find("#PartnerResults").html((PartnerResults).toFixed(2));
                tr.find("#SubCompanys").html((SubCompanys).toFixed(2));
                tr.find("#SubCompanyCommissions").html((SubCompanyCommissions).toFixed(2));
                tr.find("#SubCompanyResults").html((SubCompanyResults).toFixed(2));
                tr.find("#CompanyrResults").html((CompanyrResults).toFixed(2));
                tr.appendTo("#showInfo");
            });
        }
        function getUserName(data) {
            jQuery.AjaxCommon("/ServicesFile/ReportWebService.asmx/GetUserName", data, true, false, function (json) {
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
                    tr.find("#DetailBetType").html("<font color=red>" + result[i].BetItem + "@" + result[i].Handicap + "</font><br>" + typeList[parseInt(result[i].BetType)] + "<br><font color=blue>" + result[i].Home + " -vs- " + result[i].Away + "</font><br>" + result[i].league + "@" + time);
                    tr.find("#Odds").html(result[i].Odds + "<br>" + result[i].OddsType);
                    tr.find("#Amount").html(result[i].Amount + "<br/> <Label style=\"color:#A4A49D\">" + result[i].ValidAmount + "<Label/>");

                    var y = "";
                    if (parseFloat(result[i].Result) > 0) {
                        y = languages.H1394;
                    } else {
                        y = languages.H1415;
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
                    tr.find("#Companyes").html(parseFloat(result[i].Companys).toFixed(2));
                    tr.find("#Percentes").html(parseFloat(result[i].SubCompanyPercent * 100).toFixed(2) + " %<br/>" + parseFloat(result[i].PartnerPercent * 100).toFixed(2) + " %<br/>" + parseFloat(result[i].ZAgentPercent * 100).toFixed(2) + " %<br/>" + parseFloat(result[i].AgentPercent * 100).toFixed(2) + " %");
                    tr.find("#IP").html(result[i].IP);
                    tr.appendTo("#TbodyUser");
                });
            });
        }

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
                if (h < 10) {
                    h = "0" + h;
                }
                AorP = " PM";
            }
            else
                AorP = " AM";
            if (h >= 13) {
                h = h - 12;
            }
            //                 if (h < 10) {
            //                     h = "0" + h;
            //                 }
            if (s < 10) {
                s = "0" + s;
            }
            if (m < 10) {
                m = "0" + m;
            }
            var newDate = month + "/" + day + "/" + year + " " + h + ":" + m + ":" + s + "" + AorP;
            return newDate;
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

<input type="hidden" runat="server" id="hfContent" />
<input type="hidden" runat="server" id="nameValue" />

    <div id="selectDiv" style="width:90%">
        &nbsp;&nbsp;&nbsp;
    <span id="H1056">时间</span>:<input type="text" id="time1WhereVal" class="text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;-
    <input type="text" id="time2WhereVal" class="text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in" id="H1198">查询</span></a>
    </div>
        
</div>
<!-- 数据显示TABLE -->
<div id="divExcel">
    <table width="100%" class="tab2" id="Tbal">
    <thead>
    <tr align="center">
    <th id="zh">帐号</th>
    <th id="yj">移交</th>
    <th id="yxje">有效投注</th>
    <th id="hysy">會員贏利</th>
    <th id="hyyj">會員傭金</th>
    <th id="hyhj">會員合計</th>
    <th id="dlyl">代理贏利</th>
    <th id="dlyj">代理傭金</th>
    <th id="dlhj">代理合計</th>
    <th id="zdlyl">總代理贏利</th>
    <th id="zdlyj">總代理傭金</th>
    <th id="zdlhj">總代理合計</th>
    <th id="gdyl">股東贏利</th>
    <th id="gdyj">股東傭金</th>
    <th id="gdhj">股東合計</th>
    <th id="fgsyl">分公司贏利</th>
    <th id="fgsyj">分公司傭金</th>
    <th id="fgshj">分公司合計</th>
    <th id="gs">公司</th>
    </tr>
    </thead>
    <tbody id="showInfo">
    
    </tbody>
    <tfoot>
    <tr id="leagueInfo">
    <td id="UserName"></td>
    <td id="Transfer"></td>
    <td id="Commission"></td>
    <td id="Member" class="red"></td>
    <td id="MemberCommission"></td>
    <td id="MemberResult" class="red"></td>
    <td id="Agent"></td>
    <td id="AgentCommission"></td>
    <td id="AgentResult"></td>
    <td id="ZAgent"></td>
    <td id="ZAgentCommission"></td>
    <td id="ZAgentResult"></td>
    <td id="Partner"></td>
    <td id="PartnerCommission"></td>
    <td id="PartnerResult"></td>
    <td id="SubCompany"></td>
    <td id="SubCompanyCommission"></td>
    <td id="SubCompanyResult"></td>
    <td id="CompanyrResult"></td>
    </tr>
    <tr id="info"></tr>
    <tr id="total">
    <td id="name"></td>
    <td id="Transfers"></td>
    <td id="Commissions"></td>
    <td id="Members" class="red"></td>
    <td id="MemberCommissions"></td>
    <td id="MemberResults" class="red"></td>
    <td id="Agents"></td>
    <td id="AgentCommissions"></td>
    <td id="AgentResults"></td>
    <td id="ZAgents"></td>
    <td id="ZAgentCommissions"></td>
    <td id="ZAgentResults"></td>
    <td id="Partners"></td>
    <td id="PartnerCommissions"></td>
    <td id="PartnerResults"></td>
    <td id="SubCompanys"></td>
    <td id="SubCompanyCommissions"></td>
    <td id="SubCompanyResults"></td>
    <td id="CompanyrResults"></td>
    </tr>
    </tfoot>
    </table>
    <table width="100%" class="tab2" id="Myshow">
    <thead>
    <tr align="center">
    <th rowspan="2" id="H1026">序号</th>
    <th rowspan="2" id="H1416">資訊</th>
    <th rowspan="2" id="H1284">选择队伍</th>
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
    <td id="Companyes"></td>
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

