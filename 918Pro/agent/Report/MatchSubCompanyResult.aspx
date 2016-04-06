<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MatchSubCompanyResult.aspx.cs" Inherits="agent.Report.MatchSubCompanyResult" %>

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
        
               .tdCss1
       {
    	 background-color:#ffff99;
    	}
    	.tdCss2
       {
    	 background-color:#ffff99;
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
                 if (date < 10) {
                     date = "0" + date;
                 }
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
                     if ($("#time1WhereVal").val() == "") {
                         $.MsgTip({ objId: "#divTip", msg: languages.H1382 });
                         return false;
                     }
                     if ($("#time2WhereVal").val() == "") {
                         $.MsgTip({ objId: "#divTip", msg: languages.H1383 });
                         return false;
                     }
                     var data = "time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',language:'" + $("#language").val() + "',status:'1',agentName:'<%=agentUserName %>',roleId:'<%=agentRoleID %>'";
                     setData(data);
                 });

                 $("#nameP").html(languages.H1390);
                 $("#H1056").html(languages.H1056);
                 $("#H1198").html(languages.H1198);
                 $("#H1259").html(languages.H1259);
                 $("#H1391").html(languages.H1391);
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

                 $("#H1026").html(languages.H1026);
                 $("#H1416").html(languages.H1416);
                 $("#H1284").html(languages.H1284);
                 $("#H1171").html(languages.H1171);
                 $("#H1172").html(languages.H1172);
                 $("#H1070").html(languages.H1070);
                 $("#Th1").html(languages.H1328);
                 $("#Th2").html(languages.H1082);
                 $("#Th3").html(languages.H1229);
                 $("#Th4").html(languages.H1228);
                 $("#Th5").html(languages.H1227);
                 $("#Th6").html(languages.H1393);
                 $("#H1417").html(languages.H1417);
                 $("#H1418").html(languages.H1418);

                 $("#H1419").html(languages.H1419);
                 $("#H1420").html(languages.H1420);
                 $(".classsy").html(languages.H1421);
                 $(".classyj").html(languages.H1395);
                 $("#OrderDetail").attr("title", languages.H1168);

                 var th = jQuery("#tb2 thead:eq(0)").clone();
                 jQuery(window).scroll(function () {
                     //debugger
                     var h = jQuery(window).scrollTop();
                     if (h >= 75) {
                         if (jQuery("#tb1 thead").length == 0) {
                             th.appendTo("#tb1");
                         }
                         jQuery("#gddiv").show();
                     }
                     else {
                         jQuery("#gddiv").hide();
                     }
                 });

             });
             lang = setLang;
         }
         //--------多语言处理结束---------

         function setData(data) {
             jQuery.AjaxCommon("/ServicesFile/ReportWebService.asmx/GetMatchAll", data, true, false, function (json) {
                 jQuery("#showInfo>tr").remove();
                 var result = jQuery.parseJSON(json.d);
                 var league = "";
                 var Transfers = 0;
                 var Commissions = 0.00;
                 var Members = 0;
                 var MemberCommissions = 0.00;
                 var MemberResults = 0;
                 var Agents = 0;
                 var AgentCommissions = 0.00;
                 var AgentResults = 0;
                 var ZAgents = 0;
                 var ZAgentCommissions = 0.00;
                 var ZAgentResults = 0;
                 var Partners = 0;
                 var PartnerCommissions = 0.00;
                 var PartnerResults = 0;
                 var SubCompanys = 0;
                 var SubCompanyCommissions = 0.00;
                 var SubCompanyResults = 0;
                 var CompanyCommissions = 0.00;
                 var Companys = 0;
                 var Results = 0;
                 var yj = 0;
                 jQuery.each(result, function (i) {
                     var tr;
                     var leagues = result[i].league + "----" + result[i].Home + "--vs--" + result[i].Away;
                     if (leagues != league) {
                         league = result[i].league + "----" + result[i].Home + "--vs--" + result[i].Away;
                         tr = jQuery("#leaguetr").clone();
                         tr.attr("class", "tl");
                         tr.html("<td align=\"left\" class=\"fb\" colspan=\"20\"  style=\"background-color:#DCF0FD;text-align:left\"><a href='javascript:void(0)' onclick=\"ShowDetail('" + result[i].gameid + "','','<%=agentUserName %>','<%=agentRoleID %>');\"><font color='#333333'>" + league + "</font></a></td>");
                         tr.appendTo("#showInfo");
                     }
                     tr = jQuery("#leagueInfo").clone();
                     tr.attr("class", "tc");
                     var type = Conversion(result[i].BetType);
                     tr.find("#BetType").html("<a href='javascript:void(0)' onclick=\"ShowDetail('" + result[i].gameid + "','" + result[i].BetType + "','<%=agentUserName %>','<%=agentRoleID %>');\"><font color='#333333'>" + type + "</font></a>");

                     if (result[i].Result * 1 < 0) {
                         yj = result[i].Result * -1;
                     } else {
                         yj = result[i].Result;
                     }

                     tr.find("#Transfer").html(parseFloat(yj).toFixed(2));
                     Transfers += parseFloat(yj);

                     /*
                     tr.find("#Commission").html(parseFloat(yj * result[i].SubCompanyCommission).toFixed(2));
                     Commissions += parseFloat(yj * result[i].SubCompanyCommission);
                     */
                     tr.find("#Commission").html(parseFloat(result[i].Commission).toFixed(2));
                     Commissions += parseFloat(result[i].Commission);

                     //var MemberA = (result[i].Result * (1 - result[i].MemberPercent)).toFixed(2);
                     var MemberA = parseFloat(result[i].Members).toFixed(2);

                     tr.find("#Member").html(MemberA);
                     if (MemberA >= 0) {
                         tr.find("#Member").removeAttr("class");
                     } else {
                         tr.find("#Member").addClass("red");
                     }
                     Members += parseFloat(result[i].Members);
                     //var MemberB = ((result[i].Result * result[i].AgentPercent * result[i].MemberCommission));
                     var MemberB = parseFloat(result[i].MemberCommission);
                     //debugger;
                     tr.find("#MemberCommission").html(parseFloat(MemberB).toFixed(2));
                     if (MemberB < 0) {
                         tr.find("#MemberCommission").addClass("red");
                     }
                     MemberCommissions += ((MemberB * 100) * 0.01);
                     var MemberC = parseFloat((MemberA * 100 + MemberB * 100) * 0.01).toFixed(2);

                     tr.find("#MemberResult").html(MemberC);
                     if (MemberC >= 0) {
                         tr.find("#MemberResult").removeAttr("class");
                     } else {
                         tr.find("#MemberResult").addClass("red");
                     }
                     MemberResults += ((MemberC * 100) * 0.01);

                     if (MemberC * 1 < 0) {
                         Results = MemberC * -1;
                     } else {
                         Results = MemberC;
                     }

                     var SubCompanyA = parseFloat(result[i].SubCompany);
                     /*
                     var rs = parseFloat(result[i].Result);
                     if (rs > -1) {
                     SubCompanyA = SubCompanyA * -1
                     }
                     */
                     tr.find("#SubCompany").html(parseFloat(SubCompanyA).toFixed(2));
                     if (SubCompanyA >= 0) {
                         tr.find("#SubCompany").removeAttr("class");
                     } else {
                         tr.find("#SubCompany").addClass("red");
                     }
                     SubCompanys += ((SubCompanyA * 100) * 0.01);
                     //分公司佣金
                     var SubCompanyB = parseFloat(result[i].SubCompanyCommission);
                     tr.find("#SubCompanyCommission").html(parseFloat(SubCompanyB).toFixed(2));
                     if (SubCompanyB < 0) {
                         tr.find("#SubCompanyCommission").addClass("red");
                     }
                     SubCompanyCommissions += ((SubCompanyB * 100) * 0.01);

                     var SubCompanyC = parseFloat((SubCompanyA * 100 + SubCompanyB * 100) * 0.01).toFixed(2);
                     if (SubCompanyC >= 0) {
                         tr.find("#SubCompanyResult").removeAttr("class");
                     } else {
                         tr.find("#SubCompanyResult").addClass("red");
                     }
                     tr.find("#SubCompanyResult").html(parseFloat(SubCompanyC).toFixed(2));
                     SubCompanyResults += ((SubCompanyC * 100) * 0.01);

                     //公司
                     var CompanyCommission = parseFloat(result[i].CompanyCommission);
                     if (CompanyCommission >= 0) {
                         tr.find("#CompanyCommission").removeAttr("class");
                     } else {
                         tr.find("#CompanyCommission").addClass("red");
                     }
                     tr.find("#CompanyCommission").html(parseFloat(CompanyCommission).toFixed(2));

                     CompanyCommissions += CompanyCommission;

                     var Company = parseFloat(result[i].Companys);
                     tr.find("#CompanyResult").html(parseFloat(Company).toFixed(2));
                     Companys += Company;


                     //股东
                     var PartnerA = parseFloat(result[i].Partner);
                     tr.find("#Partner").html(parseFloat(PartnerA).toFixed(2));
                     if (PartnerA < 0) {
                         tr.find("#Partner").addClass("red");
                     }
                     Partners += ((PartnerA * 100) * 0.01);

                     var PartnerB = parseFloat(result[i].PartnerCommission);
                     tr.find("#PartnerCommission").html(parseFloat(PartnerB).toFixed(2));
                     if (PartnerB < 0) {
                         tr.find("#PartnerCommission").addClass("red");
                     }
                     PartnerCommissions += ((PartnerB * 100) * 0.01);
                     var PartnerC = ((PartnerA * 100 + PartnerB * 100) * 0.01).toFixed(2);
                     tr.find("#PartnerResult").html(PartnerC);
                     if (PartnerC < 0) {
                         tr.find("#PartnerResult").addClass("red");
                     }
                     PartnerResults += ((PartnerC * 100) * 0.01);


                     //总代
                     var ZAgentA = parseFloat(result[i].ZAgent);
                     tr.find("#ZAgent").html(parseFloat(ZAgentA).toFixed(2));
                     if (ZAgentA < 0) {
                         tr.find("#ZAgent").addClass("red");
                     }
                     ZAgents += ((ZAgentA * 100) * 0.01);

                     var ZAgentB = parseFloat(result[i].ZAgentCommission);
                     tr.find("#ZAgentCommission").html(parseFloat(ZAgentB).toFixed(2));
                     if (ZAgentB < 0) {
                         tr.find("#ZAgentCommission").addClass("red");
                     }
                     ZAgentCommissions += ((ZAgentB * 100) * 0.01);
                     var ZAgentC = ((ZAgentA * 100 + ZAgentB * 100) * 0.01).toFixed(2);
                     tr.find("#ZAgentResult").html(ZAgentC);
                     if (ZAgentC < 0) {
                         tr.find("#ZAgentResult").addClass("red");
                     }
                     ZAgentResults += ((ZAgentC * 100) * 0.01);


                     //代理
                     var AgentA = parseFloat(result[i].Agent);
                     tr.find("#Agent").html(parseFloat(AgentA).toFixed(2));
                     if (AgentA < 0) {
                         tr.find("#Agent").addClass("red");
                     }
                     Agents += ((AgentA * 100) * 0.01);

                     var AgentB = parseFloat(result[i].AgentCommission);
                     tr.find("#AgentCommission").html(parseFloat(AgentB).toFixed(2));
                     if (AgentB < 0) {
                         tr.find("#AgentCommission").addClass("red");
                     }
                     AgentCommissions += ((AgentB * 100) * 0.01);
                     var AgentC = ((AgentA * 100 + AgentB * 100) * 0.01).toFixed(2);
                     tr.find("#AgentResult").html(AgentC);
                     if (AgentC < 0) {
                         tr.find("#AgentResult").addClass("red");
                     }
                     AgentResults += ((AgentC * 100) * 0.01);


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
                 if (Members > 0) {
                     tr.find("#Members").removeAttr("class");
                 } else {
                     tr.find("#Members").addClass("red");
                 }
                 tr.find("#MemberCommissions").html((MemberCommissions).toFixed(2));
                 tr.find("#MemberResults").html((MemberResults).toFixed(2));
                 if (MemberResults > 0) {
                     tr.find("#MemberResults").removeAttr("class");
                 } else {
                     tr.find("#MemberResults").addClass("red");
                 }
                 tr.find("#Agents").html((Agents).toFixed(2));
                 if (Agents > 0) {
                     tr.find("#Agents").removeAttr("class");

                 } else {
                     tr.find("#Agents").addClass("red");
                 }
                 tr.find("#AgentCommissions").html((AgentCommissions).toFixed(2));
                 tr.find("#AgentResults").html((AgentResults).toFixed(2));
                 if (AgentResults > 0) {
                     tr.find("#AgentResults").removeAttr("class");

                 } else {
                     tr.find("#AgentResults").addClass("red");
                 }

                 tr.find("#ZAgents").html((ZAgents).toFixed(2));
                 if (ZAgents > 0) {
                     tr.find("#ZAgents").removeAttr("class");

                 } else {
                     tr.find("#ZAgents").addClass("red");
                 }
                 tr.find("#ZAgentCommissions").html((ZAgentCommissions).toFixed(2));
                 tr.find("#ZAgentResults").html((ZAgentResults).toFixed(2));
                 if (ZAgentResults > 0) {
                     tr.find("#ZAgentResults").removeAttr("class");

                 } else {
                     tr.find("#ZAgentResults").addClass("red");
                 }

                 tr.find("#Partners").html((Partners).toFixed(2));
                 if (Partners > 0) {
                     tr.find("#Partners").removeAttr("class");

                 } else {
                     tr.find("#Partners").addClass("red");
                 }
                 tr.find("#PartnerCommissions").html((PartnerCommissions).toFixed(2));
                 tr.find("#PartnerResults").html((PartnerResults).toFixed(2));
                 if (PartnerResults > 0) {
                     tr.find("#PartnerResults").removeAttr("class");

                 } else {
                     tr.find("#PartnerResults").addClass("red");
                 }

                 tr.find("#SubCompanys").html((SubCompanys).toFixed(2));
                 if (SubCompanys > 0) {
                     tr.find("#SubCompanys").removeAttr("class");

                 } else {
                     tr.find("#SubCompanys").addClass("red");
                 }
                 tr.find("#SubCompanyCommissions").html((SubCompanyCommissions).toFixed(2));

                 if (SubCompanyCommissions > 0) {
                     tr.find("#SubCompanyCommissions").removeAttr("class");

                 } else {
                     tr.find("#SubCompanyCommissions").addClass("red");
                 }
                 tr.find("#SubCompanyResults").html((SubCompanyResults).toFixed(2));
                 if (SubCompanyResults > 0) {
                     tr.find("#SubComSubCompanyResultspanys").removeAttr("class");

                 } else {
                     tr.find("#SubCompanyResults").addClass("red");
                 }

                 tr.find("#CompanyCommissions").html((CompanyCommissions).toFixed(2));
                 if (CompanyCommissions > 0) {
                     tr.find("#CompanyCommissions").removeAttr("class");

                 } else {
                     tr.find("#CompanyCommissions").addClass("red");
                 }
                 tr.find("#Companys").html((Companys).toFixed(2));

                 tr.appendTo("#showInfo");

                 jQuery("#tb2 tr>td").unbind("click");
                 jQuery("#tb2 tr>td").bind("click", function (a, b) {
                     //jQuery("td[class^='acss'],th[class^='acss']").removeClass("tdCss1");
                     //jQuery(".acss" + $(this).index()).addClass("tdCss1");

                     var ins = jQuery(this).index();
                     var $tr = jQuery(this).parent();
                     jQuery.each(jQuery("#tb2 tr"), function (i, n) {
                         //列
                         jQuery.each(jQuery(n).find("td"), function (z, x) {
                             jQuery(x).removeClass("tdCss1");
                         });
                         jQuery(n).find("td:eq(" + ins + ")").addClass("tdCss1");

                         //行
                         jQuery(n).removeClass("tdCss2");
                     });
                     $tr.addClass("tdCss2");
                 });

             });
         }


         function round(v, e) {
             var t = 1;
             for (; e > 0; t *= 10, e--);
             for (; e < 0; t /= 10, e++);
             return Math.round(v * t) / t;
         }

         function Commiss(result, myPartner, upPartner, myCommissions, upCommissions) {
             var commiss = (result * ((1 - myPartner - upPartner) * myCommissions) - result * (1 - upPartner) * upCommissions);
             return commiss;
         }

         function Conversion(parameter) {
             var status = ""
             if (parameter == "0") {
                 status = languages.H1236;
             }
             else if (parameter == "1") {
                 status = languages.H1237;
             }
             else if (parameter == "2") {
                 status = languages.H1238;
             }
             else if (parameter == "3") {
                 status = languages.H1239;
             }
             else if (parameter == "4") {
                 status = languages.H1240;
             }
             else if (parameter == "5") {
                 status = languages.H1241;
             }
             else if (parameter == "6") {
                 status = languages.H1242;
             }
             else if (parameter == "7") {
                 status = languages.H1243;
             }
             else if (parameter == "8") {
                 status = languages.H1244;
             }
             else if (parameter == "9") {
                 status = languages.H1245;
             }
             else if (parameter == "10") {
                 status = languages.H1246;
             }
             else if (parameter == "11") {
                 status = languages.H1247;
             }
             else if (parameter == "12") {
                 status = languages.H1384;
             }
             else if (parameter == "13") {
                 status = languages.H1385;
             }
             else if (parameter == "14") {
                 status = languages.H1386;
             }
             else if (parameter == "15") {
                 status = languages.H1387;
             }
             else if (parameter == "16") {
                 status = languages.H1388;
             }
             else if (parameter == "17") {
                 status = languages.H1389;
             }
             return status;
         }
         function getUserName(data) {
             jQuery.AjaxCommon("/ServicesFile/ReportWebService.asmx/LeagueOrderDetail", data, true, false, function (json) {
                 jQuery("#OrderDetail").dialog({ modal: true, width: 1000, position: ['top', 'right'] });
                 jQuery("#closeButton").unbind("click");
                 jQuery("#closeButton").bind("click", function () {
                     jQuery("#OrderDetail").dialog("close");
                 });
                 jQuery("#TbodyUser>tr").remove();
                 var Sequence = 0;
                 var result = jQuery.parseJSON(json.d);
                 var pd = 0;
                 var btype;
                 jQuery.each(result, function (i) {
                     Sequence++;
                     tr = jQuery("#TrUser").clone();
                     tr.find("#SequenceId").html(Sequence);
                     var time = result[i].BeginTime;
                     //var DateTime = fomatdate(time);
                     tr.find("#Information").html(result[i].UserName + "<br/>" + languages.H1414 + "<br/>" + result[i].time);
                     //tr.find("#Options").html(result[i].Home + " -vs- " + result[i].Away + "<br/>" + result[i].league + "<br>" + time.substring(0, 10));
                     //debugger
                     btype = Conversion(result[i].BetType);
                     //tr.find("#DetailBetType").html(btype + "<br>" + result[i].BetItem + "@" + result[i].Handicap);
                     tr.find("#DetailBetType").html("<font color=red>" + result[i].BetItem + "@" + result[i].Handicap + "</font><br>" + btype + "<br><font color=blue>" + result[i].Home + " -vs- " + result[i].Away + "</font><br>" + result[i].league + "@" + time);
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

         function ShowDetail(gameid, betType, agentName, roleId) {
             var data = "time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',language:'" + $("#language").val() + "',status:'1',gameid:'" + gameid
             + "',betType:'" + betType + "',agentName:'" + agentName + "',roleId:'" + roleId + "'";
             getUserName(data);
         }
     </script>
</head>
<body>
    <table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="nameP">赛事输赢</p></th>
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

<div id="gddiv" style="top:expression(this.parentElement.parentElement.scrollTop);position:fixed;width:97.3%;display:none;">
 <table id="tb1" width="100%" class="tab2" style="border:0px;">
 </table>
</div>

<!-- 数据显示TABLE -->
<div id="divExcel">
    <table id="tb2" width="100%" class="tab2">
    <thead>
    <tr align="center">
    <th rowspan="2" style="width:10%" id="H1259">投注类型</th>
    <th rowspan="2" style="width:6%" id="H1391">移交</th>
    <th rowspan="2" style="width:6%" id="H1392">总佣金</th>
    <th colspan="3" id="H1328">会员</th>
    <th colspan="3" id="H1082">代理</th>
    <th colspan="3" id="H1229">总代</th>
    <th colspan="3" id="H1228">股东</th>
    <th colspan="3" id="H1227">分公司</th>
    <th colspan="2" id="H1393">公司</th>
    </tr>
    <tr>
    <th style="width:70px" class="H1394">赢</th>
    <th style="width:70px" class="H1395">佣金</th>
    <th style="width:70px" class="H1040">全部</th>
    <th style="width:70px" class="H1394">赢</th>
    <th style="width:70px" class="H1395">佣金</th>
    <th style="width:70px" class="H1040">全部</th>
    <th style="width:70px" class="H1394">赢</th>
    <th style="width:70px" class="H1395">佣金</th>
    <th style="width:70px" class="H1040">全部</th>
    <th style="width:70px" class="H1394">赢</th>
    <th style="width:70px" class="H1395">佣金</th>
    <th style="width:70px" class="H1040">全部</th>
    <th style="width:70px" class="H1394">赢</th>
    <th style="width:70px" class="H1395">佣金</th>
    <th style="width:70px" class="H1040">全部</th>
    <th style="width:70px" class="H1395">佣金</th>
    <th style="width:70px" class="H1040">全部</th>
    </tr>
    </thead>
    <tbody id="showInfo">
    
    </tbody>
    <tfoot>
    <tr id="leaguetr"></tr>
    <tr id="leagueInfo">
    <td id="BetType"></td>
    <td id="Transfer"></td>
    <td id="Commission"></td>
    <td id="Member"></td>
    <td id="MemberCommission"></td>
    <td id="MemberResult"></td>
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
    <td id="CompanyCommission" class="red"></td>
    <td id="CompanyResult" class="red"></td>
    </tr>
    <tr id="info"></tr>
    <tr id="total">
    <td id="name"></td>
    <td id="Transfers"></td>
    <td id="Commissions"></td>
    <td id="Members"></td>
    <td id="MemberCommissions"></td>
    <td id="MemberResults"></td>
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
    <td id="CompanyCommissions" class="red"></td>
    <td id="Companys" class="red"></td>
    </tr>
    </tfoot>
    </table>
    </div>
    </form>
            <div id="OrderDetail" title="注单明细" style="display:none">
        <div id="detailDiv" class="showdiv">
        <table width="100%" class="tab2" id="Myshow">
    <thead>
    <tr align="center">
    <th rowspan="2" id="H1026">序号</th>
    <th rowspan="2" id="H1416">資訊</th>
    <th rowspan="2" id="H1284">选择</th>
    <th rowspan="2" id="H1171">赔率</th>
    <th rowspan="2" id="H1172">投注金额</th>
    <th rowspan="2" id="H1070">状态</th>
    <th id="Th1">会员</th>
    <th id="Th2">代理</th>
    <th id="Th3">总代</th>
    <th id="Th4">股东</th>
    <th id="Th5">分公司</th>
    <th rowspan="2" id="Th6">公司</th>
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
        <div align="center" class="mtop_50">
        <input type="button" class="btn_02" id="closeButton" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="关闭" /><br /><br />
        </div>
    </div>
    </div>

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
