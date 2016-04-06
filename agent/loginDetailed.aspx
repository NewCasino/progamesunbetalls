<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginDetailed.aspx.cs" Inherits="agent.loginDetailed" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="/js/jQueryCommon.js" type="text/javascript"></script>
    <script src="/js/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
    <script src="/js/webBasicInfo/zh-CN.js" type="text/javascript"></script>
    <link href="/css/Default/cupertino/jquery-ui-1.8.2.custom.css" rel="stylesheet"
        type="text/css" />
    <link href="../css/Agent/loginDetailed.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript">
        var roleId = <%=roleId %> + 1;
        var upUserName = "<%=username %>";
        var aIndex = 0;
        var roleIds = 0;
        var upIds = 0;
        var pd = 0;
        var Id = 0;
        var userId;
        var typeList;
          //----------------------------------------起始初始时间----------------------------------------
         function CurentTime() {
             var now = new Date();
             var year = now.getFullYear();       //年
             var month = now.getMonth() ;     //月


             var clock = year + "-";
             if (month < 10)
                 clock += "0";
             clock += month + "-";
             clock += "01";
             return (clock);
         }
         function CurentTime2() {
             var now = new Date();
             var year = now.getFullYear();       //年
             var month = now.getMonth() + 1;     //月
             var day = now.getDate();       //日


             var clock = year + "-";
             if (month < 10)
                 clock += "0";
             clock += month + "-";
             clock += day;
             return (clock);
         }
         //-----------------------------------------时间初始结束---------------------------------------
        $(function () {
            SetGlobal("");
            jQuery("#language").val(lang);

           
             $('#time1WhereVal').val(CurentTime());
             jQuery("#time1WhereVal").datepicker();

             $('#time2WhereVal').val(CurentTime2());
             jQuery("#time2WhereVal").datepicker();

             if ($("#time1WhereVal").val() == "" && $("#time2WhereVal").val() == "") {
                 alert("请选择查询日期");
                 return false;
             }
             var data = "time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',language:'" + $("#language").val() + "',status:'1',roleId:'" + roleId + "',ID:'0',UpUserName:'" + upUserName + "',mtype:'" + jQuery("#mtype").val() + "'";
             setData(data);
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
                    if ($("#time1WhereVal").val() == "" && $("#time2WhereVal").val() == "") {
                        alert("请选择查询日期");
                        return false;
                    }

                    //getCount1(upUserName, roleId, '0');
                    //var data = "time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',language:'" + $("#language").val() + "',status:'1',roleId:'" + roleId + "',ID:'0',UpUserName:'#'";
                    var data = "time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',language:'" + $("#language").val() + "',status:'1',roleId:'" + roleId + "',ID:'0',UpUserName:'" + upUserName + "',mtype:'" + jQuery("#mtype").val() + "'";
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

                //                 $("#H1412").html(languages.H1412);
                //                 $("#H1460").html(languages.H1460);
                //                 $("#H1056").html(languages.H1056);
                //                 $("#H1198").html(languages.H1198);
                //                 $("#zh").html(languages.H1218);
                //                 $("#yj").html(languages.H1391);
                //                 $("#yxje").html(languages.H1396);
                //                 $("#hysy").html(languages.H1409);
                //                 $("#hyyj").html(languages.H1410);
                //                 $("#hyhj").html(languages.H1411);
                //                 $("#dlyl").html(languages.H1406);
                //                 $("#dlyj").html(languages.H1407);
                //                 $("#dlhj").html(languages.H1408);
                //                 $("#zdlyl").html(languages.H1483);
                //                 $("#zdlyj").html(languages.H1484);
                //                 $("#zdlhj").html(languages.H1485);
                //                 $("#gdyl").html(languages.H1400);
                //                 $("#gdyj").html(languages.H1401);
                //                 $("#gdhj").html(languages.H1402);
                //                 $("#fgsyl").html(languages.H1398);
                //                 $("#fgsyj").html(languages.H1399);
                //                 $("#fgshj").html(languages.H1298);
                //                 $("#gs").html(languages.H1393);
                //                 $("#H1026").html(languages.H1026);
                //                 $("#H1416").html(languages.H1416);
                //                 $("#H1284").html(languages.H1284);
                //                 $("#H1171").html(languages.H1171);
                //                 $("#H1172").html(languages.H1172);
                //                 $("#H1070").html(languages.H1070);
                //                 $("#H1328").html(languages.H1328);
                //                 $("#H1082").html(languages.H1082);
                //                 $("#H1229").html(languages.H1229);
                //                 $("#H1228").html(languages.H1228);

                //                 $("#H1227").html(languages.H1227);
                //                 $("#H1393").html(languages.H1393);
                //                 $("#H1417").html(languages.H1417);
                //                 $("#H1418").html(languages.H1418);
                //                 $("#H1419").html(languages.H1419);
                //                 $("#H1420").html(languages.H1420);
                //                 $(".classsy").html(languages.H1421);
                //                 $(".classyj").html(languages.H1395);
            });
            lang = setLang;
        }
        //--------多语言处理结束---------

        function getCount(name, roleIds) {
            pd = 1;
            //debugger;
            roleId = parseInt(roleIds) + 1;
            if (roleId == 7) {
                var data = "time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',language:'" + $("#language").val() + "',status:'1',userName:'" + name + "',mtype:'" + jQuery("#mtype").val() + "'";
                upUserName = name;
                $("#Tbal").hide();
                $("#Myshow").show();
                getUserName(data);
            } else {
                var data = "time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',language:'" + $("#language").val() + "',status:'1',roleId:'" + roleId + "',UpUserName:'" + name + "',mtype:'" + jQuery("#mtype").val() + "'";
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
                var data = "time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',language:'" + $("#language").val() + "',status:'1',userName:'" + name + "',mtype:'" + jQuery("#mtype").val() + "'";
                upUserName = name;
                $("#Tbal").hide();
                $("#Myshow").show();
                getUserName(data);
            } else {
                var data = "time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',language:'" + $("#language").val() + "',status:'1',roleId:'" + roleId + "',UpUserName:'" + name + "',mtype:'" + jQuery("#mtype").val() + "'";
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
            jQuery.AjaxCommon("/ServicesFile/ReportWebService.asmx/GetMatch2", data, true, false, function (json) {
                jQuery("#showInfo>tr").remove();
                if(json.d!="]"){
                var result = jQuery.parseJSON(json.d);
                var totalckamount = 0;
                var totalqkamount = 0;
                var totalhlamount = 0;
                var totalfsamount = 0.00;
                var totalvalidamount = 0;
                var totalwinandlose = 0;
                //var totalwinb=0;

                if (pd) {
                    jQuery("#pathP").html(jQuery("#pathP").html() + (roleId != 2 ? "<a  style=\"color:#FF5050;font-size:14px;\" onmouseover=\"this.style.cursor='hand'\" onclick=\"getCount1('" + upUserName + "','" + roleId + "','" + (++aIndex) + "')" + "\"> >" + upUserName + "</a>" : ""));
                }
                pd = 0;

                jQuery.each(result, function (i) {
                    var tr;
                    tr = jQuery("#leagueInfo").clone();
                    tr.show();
                    tr.find("td:eq(0)").html(i+1);
                    if (roleId == "6") {
                        tr.find("#UserName").html(result[i].UserName);
                    }
                    else {
                        tr.find("#UserName").html("<a style=\"color:#FF5050;font-size:14px;\" onmouseover=\"this.style.cursor='hand'\" " + ("onclick=\"getCount('" + result[i].UserName + "','" + (roleId) + "')") + "\">" + result[i].UserName + "</a>");
                    }
                    tr.find("#ckamount").html(result[i].ckamount);
                    tr.find("#qkamount").html(result[i].qkamount);
                    tr.find("#hlamount").html(result[i].hlamount);
                    tr.find("#fsamount").html(result[i].fsamount);
                    //赢币
                   // tr.find("#winb").html(result[i].winandlose);
                    //投注额
                   tr.find("#validamount").html(result[i].validamount);
                    //输赢
                    var wl=(parseFloat(result[i].ckamount)-parseFloat(result[i].qkamount)-parseFloat(result[i].hlamount)-parseFloat(result[i].fsamount));
                    tr.find("#winandlose").html(wl);

                    totalckamount += parseFloat(result[i].ckamount);
                    totalqkamount += parseFloat(result[i].qkamount);
                    totalhlamount += parseFloat(result[i].hlamount);
                    totalfsamount += parseFloat(result[i].fsamount);
                   totalvalidamount += parseFloat(result[i].validamount);
                    totalwinandlose += parseFloat(wl);
                   // totalwinb+=parseFloat(result[i].winandlose);

                    tr.appendTo("#showInfo");
                });
                tr = jQuery("#info").clone();
                tr.show();
                tr.attr("class", "tl");
                if (result == "") {
                    tr.html("<td height=\"20\" colspan=\"20\" style=\"background-color:#DCF0FD\">" + languages.H1413 + "</td>");
                } else {
                    tr.html("<td height=\"20\" colspan=\"20\" style=\"background-color:#DCF0FD\"></td>");
                }
                tr.appendTo("#showInfo");
                tr = jQuery("#total").clone();
                tr.show();
                tr.attr("class", "tc");
                tr.find("#name").html(languages.H1040);
                //                     tr.find("#Transfers").html((Transfers).toFixed(2));
                tr.find("td:eq(1)").html((totalckamount).toFixed(2));
                tr.find("td:eq(2)").html((totalqkamount).toFixed(2));
                tr.find("td:eq(3)").html((totalhlamount).toFixed(2));
                tr.find("td:eq(4)").html((totalfsamount).toFixed(2));
                //tr.find("td:eq(5)").html((totalwinb).toFixed(2));
                tr.find("td:eq(5)").html((totalvalidamount).toFixed(2));
                tr.find("td:eq(6)").html((totalwinandlose).toFixed(2));

                tr.appendTo("#showInfo");
                }
            });
        }
        function getUserName(data) {
            jQuery.AjaxCommon("/ServicesFile/ReportWebService.asmx/GetUserName2", data, true, false, function (json) {
                //debugger
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
<body style=" height:380px">
<table width="1054"  border="0"  align="center" cellpadding="0" cellspacing="0">
  
  <tr>
    <td height="50" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="2" bgcolor="#353536">
      <tr>
        <td valign="top" bgcolor="#2A2B2B"><table width="100%" border="0" cellspacing="10" cellpadding="0">
          <tr>
            <td style="line-height:200%"><table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#353536">
              <tr>
                <td valign="top" bgcolor="#1C1C1C"><table width="100%" border="0" cellpadding="0" cellspacing="5">
                    <tr>
                      <td  style=" text-align:left"><table width="142" border="0" cellpadding="0" cellspacing="0"  style=" text-align:left">
                        <tr  style=" text-align:left">
                          <td width="132" height="44" align="center"  background="/images/gybj.png"><table border="0" cellspacing="0" cellpadding="0"  style=" text-align:left">
                              <tr  style=" text-align:left">
                                <td class="STYLE6" >会员详情</td>
                              </tr>
                              <tr>
                                <td><img src="../images/spacer.gif" width="22" height="5" border="0" alt="" /></td>
                              </tr>
                          </table></td>
                        </tr>
                      </table></td>
                      <td align="right">
                      时间：<input type="text" id="time1WhereVal" style="width:100px;" /> - <input type="text" id="time2WhereVal" style="width:100px;" />
                      <input id="selectByWhere" type="button" value="查询" />
                      </td>
                      </tr>
                </table></td>
              </tr>
            </table></td>
          </tr>
          <tr>
            <td><table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#353536">
              <tr>
                <td height="40" bgcolor="#1C1C1C"><table width="1028" border="0" cellspacing="1" cellpadding="0">
                  
                                    <tr>
                    <td height="30" colspan="8" align="left" class="STYLE11 STYLE12">
                    <table><tr><td>
                        <table width="100%" border="0" cellspacing="1" cellpadding="0">
                              <tr>
                                <td width="143" height="30" align="center" bgcolor="#FF8D1A" onclick="window.location='logindetailed.aspx';" style="cursor: pointer;"><span class="STYLE12">报表</span></td>
                                <td width="144" align="center" bgcolor="#666666" class="STYLE11" onclick="window.location='MemberList.aspx';" style="cursor: pointer;">会员</td>
                              </tr>
                                              </table></td>
                                           <td><p id="pathP" style="display:none;"><font class="st"> <span id="H1412">会员清单</span>：</font></p></td>   
                                              </tr></table>
                                              </td>
                          </tr>

                  <tr>
                    <td width="50" height="30" align="center" bgcolor="#666666" class="STYLE11">序号</td>
                          <td width="145" align="center" bgcolor="#666666" class="STYLE11">账号</td>
                          <td width="145" align="center" bgcolor="#666666" class="STYLE11">存款</td>
                          <td width="152" align="center" bgcolor="#666666" class="STYLE11">取款</td>
                          <td width="143" align="center" bgcolor="#666666" class="STYLE11">红利</td>
                          <td width="143" align="center" bgcolor="#666666" class="STYLE11">返水</td>                         
                          <td width="143" align="center" bgcolor="#666666" class="STYLE11">有效投注额</td> 
                          <td width="147" align="center" bgcolor="#666666" class="STYLE11">公司输赢</td>
                        </tr>
                        <tbody id="showInfo">
    
                        </tbody>
                  <tr id="leagueInfo" style="display:none;">
                    <td height="30" align="center" bgcolor="#2A2B2B">1</td>
                          <td  id="UserName" height="30" align="center" bgcolor="#2A2B2B">1232131</td>
                          <td id="ckamount" align="center" bgcolor="#2A2B2B">0.00</td>
                          <td id="qkamount" align="center" bgcolor="#2A2B2B">0.00</td>
                          <td id="hlamount" align="center" bgcolor="#2A2B2B">0.00</td>
                          <td id="fsamount" align="center" bgcolor="#2A2B2B">0.00</td>
                           <td id="validamount" align="center" bgcolor="#2A2B2B">0.00</td>
                         
                        
                          <td id="winandlose" align="center" bgcolor="#2A2B2B">0.00</td>
                        </tr>
                        
                  <tr id="total" style="display:none;">
                    <td height="30" colspan="2" align="center" bgcolor="#2A2B2B">合计：</td>
                    <td align="center" bgcolor="#2A2B2B">&nbsp;</td>
                    <td align="center" bgcolor="#2A2B2B">&nbsp;</td>
                    <td align="center" bgcolor="#2A2B2B">&nbsp;</td>
                    <td align="center" bgcolor="#2A2B2B">&nbsp;</td>
                     <td align="center" bgcolor="#2A2B2B">&nbsp;</td>
                     <td align="center" bgcolor="#2A2B2B">&nbsp;</td>
                  
                  </tr>
                  </table></td>
                  </tr>
            </table></td>
          </tr>
          
        </table>          </td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
  </tr>
</table>
</body>
</html>
