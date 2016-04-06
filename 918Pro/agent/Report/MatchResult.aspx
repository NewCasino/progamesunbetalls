<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MatchResult.aspx.cs" Inherits="agent.Report.MatchResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>赛事输赢</title>
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
             tr.find("#name").html("全部");
             tr.appendTo("#showInfo");

             $("#time1WhereVal").datepicker();

             $("#time2WhereVal").datepicker();

             jQuery("#selectByWhere").click(function () {
                 if ($("#time1WhereVal").val() == "") {
                     $.MsgTip({ objId: "#divTip", msg: "选择开始时间" });
                     return false;
                 }
                 if ($("#time2WhereVal").val() == "") {
                     $.MsgTip({ objId: "#divTip", msg: "选择结束时间" });
                     return false;
                 }
                 var data = "time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',language:'" + $("#language").val() + "',status:'1'";
                 setData(data);
             });

         });

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
                         tr.html("<td align=\"left\" class=\"fb\" colspan=\"20\"  style=\"background-color:#DCF0FD;text-align:left\">" + league + "</td>");
                         tr.appendTo("#showInfo");
                     }
                     tr = jQuery("#leagueInfo").clone();
                     tr.attr("class", "tc");
                     var type = Conversion(result[i].BetType);
                     tr.find("#BetType").html(type);
                     if (result[i].Result * 1 < 0) {
                         yj = result[i].Result * -1;
                     } else {
                         yj = result[i].Result;
                     }

                     tr.find("#Transfer").html(parseFloat(yj).toFixed(2));
                     Transfers += parseFloat(yj);

                     tr.find("#Commission").html(parseFloat(yj * result[i].SubCompanyCommission).toFixed(2));
                     Commissions += parseFloat(yj * result[i].SubCompanyCommission);

                     var MemberA = (result[i].Result * (1 - result[i].MemberPercent)).toFixed(2);

                     tr.find("#Member").html(MemberA);
                     if (parseFloat(result[i].Result) >= 0) {
                         tr.find("#Member").removeAttr("class");
                     } else {
                         tr.find("#Member").addClass("red");
                     }
                     Members += (result[i].Result * (1 - result[i].MemberPercent));
                     var MemberB = ((result[i].Result * result[i].AgentPercent * result[i].MemberCommission));
                     //debugger;
                     tr.find("#MemberCommission").html(parseFloat(MemberB).toFixed(2));
                     MemberCommissions += ((MemberB * 100) * 0.01);
                     var MemberC = ((MemberA * 100 + MemberB * 100) * 0.01).toFixed(2);
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
                     var SubCompanyA = (Results * result[i].SubCompanyPercent);
                     var rs = parseFloat(result[i].Result);
                     if (rs > -1) {
                         SubCompanyA = SubCompanyA * -1
                     }
                     tr.find("#SubCompany").html(parseFloat(SubCompanyA).toFixed(2));
                     if (SubCompanyA >= 0) {
                         tr.find("#SubCompany").removeAttr("class");
                     } else {
                         tr.find("#SubCompany").addClass("red");
                     }
                     SubCompanys += ((SubCompanyA * 100) * 0.01);
                     if (rs < 0) {
                         var SubCompanyB = "";
                         if (result[i].PartnerCommission * 1 != 0) {
                             SubCompanyB = round((Results * (result[i].CompanyPercent * 1) * (result[i].SubCompanyCommission * 1)) - (Results * (result[i].SubCompanyPercent * 1) * (result[i].PartnerCommission * 1)), 2);
                         } else {
                             SubCompanyB = (Results * (result[i].CompanyPercent * 1) * (result[i].SubCompanyCommission * 1));
                         }

                         tr.find("#SubCompanyCommission").html(parseFloat(SubCompanyB).toFixed(2));
                         SubCompanyCommissions += ((SubCompanyB * 100) * 0.01);
                         var SubCompanyC = parseFloat((SubCompanyA * 100 + SubCompanyB * 100) * 0.01).toFixed(2);
                         if (SubCompanyC >= 0) {
                             tr.find("#SubCompanyResult").removeAttr("class");
                         } else {
                             tr.find("#SubCompanyResult").addClass("red");
                         }
                         tr.find("#SubCompanyResult").html(parseFloat(SubCompanyC).toFixed(2));
                         SubCompanyResults += ((SubCompanyC * 100) * 0.01);
                         var CompanyCommission = parseFloat(Results * (result[i].CompanyPercent * 1) * (result[i].SubCompanyCommission * 1) * -1)
                         if (CompanyCommission >= 0) {
                             tr.find("#CompanyCommission").removeAttr("class");
                         } else {
                             tr.find("#CompanyCommission").addClass("red");
                         }
                         tr.find("#CompanyCommission").html(parseFloat(CompanyCommission).toFixed(2));

                         CompanyCommissions += ((SubCompanyB * 100) * -0.01);
                         var Company = "";
                         if (result[i].Result > -1) {
                             Company = ((Results * result[i].CompanyPercent) - (Results * (result[i].CompanyPercent * 1) * (result[i].SubCompanyCommission * 1))).toFixed(2);
                         } else {
                             var x = round((Results * result[i].CompanyPercent), 2);
                             var y = round((Results * (result[i].CompanyPercent * 1) * (result[i].SubCompanyCommission * 1)), 2);
                             Company = parseFloat(x - y).toFixed(2);
                         }
                         debugger;
                         if (result[i].SubCompanyCommission * 1 != 0) {
                             tr.find("#CompanyResult").html("-" + Company);
                         } else {
                             tr.find("#CompanyResult").html(parseFloat(Results*-1).toFixed(2));
                         }
                         Companys += Company * -1;
                     } else {
                         debugger;
                         tr.find("#SubCompanyCommission").html(parseFloat("0.00").toFixed(2));
                         tr.find("#SubCompanyResult").html(parseFloat(SubCompanyA).toFixed(2));
                         if (parseFloat(SubCompanyA) < 0) {
                             tr.find("#SubCompanyResult").addClass("red");
                         }
                         SubCompanyResults += ((SubCompanyA * 100) * 0.01);
                         tr.find("#CompanyCommission").html(parseFloat("0.00").toFixed(2));
                         tr.find("#CompanyResult").html("-" + parseFloat(Results * result[i].CompanyPercent).toFixed(2));
                         Companys += (Results * result[i].CompanyPercent) * -1;
                     }

                     var PartnerA = parseFloat(Results * result[i].PartnerPercent);

                     if (PartnerA != 0) {
                         if (rs > -1) {
                             PartnerA = PartnerA * -1
                         }
                         tr.find("#Partner").html(parseFloat(PartnerA).toFixed(2));
                         Partners += ((PartnerA * 100) * 0.01);
                         if (rs < 0) {
                             var PartnerB = "";
                             if (result[i].ZAgentCommission * 1 != 0) {
                                 PartnerB = (Results * (result[i].SubCompanyPercent * 1) * (result[i].PartnerCommission * 1)) - (Results * (result[i].PartnerPercent * 1) * (result[i].ZAgentCommission * 1));
                             } else {
                                 PartnerB = Results * (result[i].SubCompanyPercent * 1) * (result[i].PartnerCommission * 1);
                             }
                             tr.find("#PartnerCommission").html(parseFloat(PartnerB).toFixed(2));
                             PartnerCommissions += ((PartnerB * 100) * 0.01);
                             var PartnerC = ((PartnerA * 100 + PartnerB * 100) * 0.01).toFixed(2);
                             tr.find("#PartnerResult").html(PartnerC);
                             PartnerResults += ((PartnerC * 100) * 0.01);
                         } else {
                             tr.find("#PartnerCommission").html("0.00");
                             tr.find("#PartnerResult").html(parseFloat(PartnerA).toFixed(2));
                             tr.find("#Partner").addClass("red");
                             tr.find("#PartnerResult").addClass("red");
                             PartnerResults += PartnerA;
                         }
                     } else {
                         tr.find("#Partner").html("0.00");
                         tr.find("#PartnerCommission").html("0.00");
                         tr.find("#PartnerResult").html("0.00");
                         PartnerResults += 0.00;
                     }


                     var ZAgentA = parseFloat(Results * result[i].ZAgentPercent);
                     if (ZAgentA != 0) {
                         if (rs > -1) {
                             ZAgentA = ZAgentA * -1
                         }
                         tr.find("#ZAgent").html(parseFloat(ZAgentA).toFixed(2));
                         ZAgents += ((ZAgentA * 100) * 0.01);
                         if (rs < 0) {
                             var ZAgentB = "";
                             if (result[i].AgentCommission * 1 != 0) {
                                 ZAgentB = round((Results * (result[i].PartnerPercent * 1) * (result[i].ZAgentCommission * 1)) - (Results * (result[i].ZAgentPercent * 1) * (result[i].AgentCommission * 1)), 2);
                             } else {
                                 ZAgentB = round(Results * (result[i].PartnerPercent * 1) * (result[i].ZAgentCommission * 1), 2);
                             }
                             tr.find("#ZAgentCommission").html(parseFloat(ZAgentB).toFixed(2));
                             ZAgentCommissions += ((ZAgentB * 100) * 0.01);
                             var ZAgentC = ((ZAgentA * 100 + ZAgentB * 100) * 0.01).toFixed(2);
                             tr.find("#ZAgentResult").html(ZAgentC);
                             ZAgentResults += ((ZAgentC * 100) * 0.01);
                         } else {
                             tr.find("#ZAgentCommission").html("0.00");
                             tr.find("#ZAgentResult").html(parseFloat(ZAgentA).toFixed(2));
                             tr.find("#ZAgent").addClass("red");
                             tr.find("#ZAgentResult").addClass("red");
                             ZAgentResults += ZAgentA;
                         }
                     } else {
                         tr.find("#ZAgent").html("0.00");
                         tr.find("#ZAgentCommission").html("0.00");
                         tr.find("#ZAgentResult").html("0.00");
                         ZAgentResults += 0.00;
                     }


                     var AgentA = parseFloat(Results * result[i].AgentPercent);
                     if (AgentA != 0) {
                         if (rs > -1) {
                             AgentA = AgentA * -1
                         }
                         tr.find("#Agent").html(parseFloat(AgentA).toFixed(2));
                         Agents += ((AgentA * 100) * 0.01);
                         if (rs < 0) {
                             var AgentB = "";
                             if (result[i].MemberCommission * 1 != 0) {
                                 AgentB = round(Results * (result[i].ZAgentPercent * 1) * (result[i].AgentCommission * 1) - (Results * (result[i].AgentPercent * 1) * (result[i].MemberCommission * 1)), 2);
                             } else {
                                 AgentB = round(Results * (result[i].ZAgentPercent * 1) * (result[i].AgentCommission * 1), 2);
                             }
                             tr.find("#AgentCommission").html(parseFloat(AgentB).toFixed(2));
                             AgentCommissions += ((AgentB * 100) * 0.01);
                             var AgentC = ((AgentA * 100 + AgentB * 100) * 0.01).toFixed(2);
                             tr.find("#AgentResult").html(AgentC);
                             AgentResults += ((AgentC * 100) * 0.01);
                         } else {
                             tr.find("#AgentCommission").html("0.00");
                             tr.find("#AgentResult").html(parseFloat(AgentA).toFixed(2));
                             tr.find("#Agent").addClass("red");
                             tr.find("#AgentResult").addClass("red");
                             AgentResults += AgentA;
                         }
                     } else {
                         tr.find("#Agent").html("0.00");
                         tr.find("#AgentCommission").html("0.00");
                         tr.find("#AgentResult").html("0.00");
                         AgentResults += 0.00;
                     }





                     tr.appendTo("#showInfo");
                 });
                 tr = jQuery("#info").clone();
                 tr.attr("class", "tl");
                 if (result == "") {
                     tr.html("<td height=\"20\" colspan=\"20\" style=\"background-color:#DCF0FD\">没有当前输赢记录</td>");
                 } else {
                     tr.html("<td height=\"20\" colspan=\"20\" style=\"background-color:#DCF0FD\"></td>");
                 }
                 tr.appendTo("#showInfo");
                 tr = jQuery("#total").clone();
                 tr.attr("class", "tc");
                 tr.find("#name").html("全部");
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

                 jQuery(".tab2 tr>td").unbind("click");
                 jQuery(".tab2 tr>td").bind("click", function (a, b) {
                     //jQuery("td[class^='acss'],th[class^='acss']").removeClass("tdCss1");
                     //jQuery(".acss" + $(this).index()).addClass("tdCss1");

                     var ins = jQuery(this).index();
                     var $tr = jQuery(this).parent();
                     jQuery.each(jQuery(".tab2 tr"), function (i, n) {
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
             debugger;
             var commiss= (result * ((1 - myPartner - upPartner) * myCommissions) - result * (1 - upPartner) * upCommissions);
             return commiss;
         }

         function Conversion(parameter) {
             var status = ""
             if (parameter == "0") {
                 status = "单式全场让球";
             }
             else if (parameter == "1") {
                 status = "单式全场大小";
             }
             else if (parameter == "2") {
                 status = "单式半场让球";
             }
             else if (parameter == "3") {
                 status = "单式半场大小";
             }
             else if (parameter == "4") {
                 status = "走地全场让球";
             }
             else if (parameter == "5") {
                 status = "走地全场大小";
             }
             else if (parameter == "6") {
                 status = "走地半场让球";
             }
             else if (parameter == "7") {
                 status = "走地半场大小";
             }
             else if (parameter == "8") {
                 status = "早餐全场让球";
             }
             else if (parameter == "9") {
                 status = "早餐全场大小";
             }
             else if (parameter == "10") {
                 status = "早餐半场让球";
             }
             else if (parameter == "11") {
                 status = "早餐半场大小";
             }
             else if (parameter == "12") {
                 status = "单式全场1x2";
             }
             else if (parameter == "13") {
                 status = "单式半场1x2";
             }
             else if (parameter == "14") {
                 status = "走地全场1x2";
             }
             else if (parameter == "15") {
                 status = "走地半场1x2";
             }
             else if (parameter == "16") {
                 status = "早餐全场1x2";
             }
             else if (parameter == "17") {
                 status = "早餐半场1x2";
             }
             return status;
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
    时间:<input type="text" id="time1WhereVal" class="text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;-
    <input type="text" id="time2WhereVal" class="text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in">查询</span></a>
    </div>

</div>
<!-- 数据显示TABLE -->
<div id="divExcel">
    <table width="100%" class="tab2">
    <thead>
    <tr align="center">
    <th rowspan="2" style="width:130px">投注类型</th>
    <th rowspan="2" style="width:100px">移交</th>
    <th rowspan="2" style="width:100px">总佣金</th>
    <th colspan="3">会员</th>
    <th colspan="3">代理</th>
    <th colspan="3">总代</th>
    <th colspan="3">股东</th>
    <th colspan="3">分公司</th>
    <th colspan="2">公司</th>
    </tr>
    <tr>
    <th style="width:70px">赢</th>
    <th style="width:70px">佣金</th>
    <th style="width:70px">全部</th>
    <th style="width:70px">赢</th>
    <th style="width:70px">佣金</th>
    <th style="width:70px">全部</th>
    <th style="width:70px">赢</th>
    <th style="width:70px">佣金</th>
    <th style="width:70px">全部</th>
    <th style="width:70px">赢</th>
    <th style="width:70px">佣金</th>
    <th style="width:70px">全部</th>
    <th style="width:70px">赢</th>
    <th style="width:70px">佣金</th>
    <th style="width:70px">全部</th>
    <th style="width:70px">佣金</th>
    <th style="width:70px">全部</th>
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
