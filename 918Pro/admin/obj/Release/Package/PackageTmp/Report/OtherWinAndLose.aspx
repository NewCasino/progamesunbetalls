<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OtherWinAndLose.aspx.cs" Inherits="admin.Report.OtherWinAndLose" %>

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
        var roleId = 2;
        var upUserName = "";
        var upSite = "";
        var aIndex = 0;
        var roleIds = 0;
        var upIds = 0;
        var pd = 0;
        var Id = 0;
        var userId;
        var typeList;
        var webSiteID = "";
        var agent = "";
        var webUserName = "";
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
                //tr.appendTo("#showInfo");
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
                    var data = "stime:'" + $("#time1WhereVal").val() + "',etime:'" + $("#time2WhereVal").val() + "',lan:'" + $("#language").val() + "',yy:'WebSiteiID',websiteid:'',agent:'',webusername:''";
                    setData(data);
                });

                var tr = jQuery("#info").clone();
                tr.attr("class", "tl");
                tr.html("<td height=\"20\" colspan=\"20\" style=\"background-color:#DCF0FD\"></td>");
                //tr.appendTo("#showInfo");
                var tb = jQuery("#total").clone();
                tb.attr("class", "tc");
                tb.find("#name").html(languages.H1040);
                //tb.appendTo("#showInfo");

                $("#H1412").html(languages.外调输赢);
                $("#H1460").html(languages.H1460);
                $("#H1056").html(languages.H1056);
                $("#H1198").html(languages.H1198);
                //$("#zh").html(languages.H1218);
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

        function getCount(name, roleIds,siteName) {
            pd = 1;
            //debugger;
            roleId = parseInt(roleIds) + 1;
            if (roleId == 5) {
                webUserName = name;
                var data = "websiteID:'" + webSiteID + "',agent:'" + agent + "',webusername:'" + webUserName + "',stime:'" + $("#time1WhereVal").val() + "',etime:'" + $("#time2WhereVal").val() + "',lan:'" + $("#language").val() + "'";
                upUserName = name;
                upSite = siteName;
                $("#Tbal").hide();
                $("#Myshow").show();
                getUserName(data);
            }
            else {
                var yy = "";
                if (roleId == 2) {
                    yy = "WebSiteiID";
                }else if (roleId == 3) {
                    yy = "agent";
                    webSiteID = name;
                }
                else if (roleId == 4) {
                    yy = "WebUserName";
                    agent = name;
            }
            var data = "stime:'" + $("#time1WhereVal").val() + "',etime:'" + $("#time2WhereVal").val() + "',lan:'" + $("#language").val() + "',yy:'" + yy + "',websiteid:'" + webSiteID + "',agent:'" + agent + "',webusername:'" + webUserName + "'";
                upUserName = name;
                upSite = siteName;
                $("#Tbal").show();
                $("#Myshow").hide();
                setData(data);
            }
        }
        /*--------------获得该账号下的子集账号结束--------*/
        /*----------------获得丢标记中账号下的子集账号----------*/
        function getCount1(name, roleIds, Index, site) {
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
            if (roleId == 5) {
                var data = "websiteID:'" + webSiteID + "',agent:'" + agent + "',webusername:'" + webUserName + "',stime:'" + $("#time1WhereVal").val() + "',etime:'" + $("#time2WhereVal").val() + "',lan:'" + $("#language").val() + "'";
                upUserName = name;
                upSite = site;
                $("#Tbal").hide();
                $("#Myshow").show();
                getUserName(data);
            } else {
                var yy = "";
                if (roleId == 2) {
                    yy = "WebSiteiID";
                    webSiteID = "";
                    agent = "";
                    webUserName = "";
                } else if (roleId == 3) {
                    yy = "agent";
                    //webSiteID = name;
                    agent = "";
                    webUserName = "";
                }
                else if (roleId == 4) {
                    yy = "WebUserName";
                    //agent = name;
                    webUserName = "";
                }
                var data = "stime:'" + $("#time1WhereVal").val() + "',etime:'" + $("#time2WhereVal").val() + "',lan:'" + $("#language").val() + "',yy:'" + yy + "',websiteid:'" + webSiteID + "',agent:'" + agent + "',webusername:'" + webUserName + "'";
                upUserName = name;
                upSite = site;
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
            jQuery.AjaxCommon("/ServicesFile/ReportWebService.asmx/GetOrderGroupByWebsiteID", data, true, false, function (json) {
                jQuery("#showInfo>tr").remove();
                var result = jQuery.parseJSON(json.d);
                var totalamount = 0;
                var totalvalidamount = 0;
                var totalwinlose = 0;
                var totalmoreamount = 0;

                if (pd) {
                    jQuery("#pathP").html(jQuery("#pathP").html() + (roleId != 2 ? "<a onmouseover=\"this.style.cursor='hand'\" onclick=\"getCount1('" + upUserName + "','" + roleId + "','" + (++aIndex) + "','" + upSite + "')" + "\"> >" + upSite + "</a>" : ""));
                }
                pd = 0;
                var html = "";
                jQuery.each(result, function (i) {
                    var tr;
                    tr = jQuery("#leagueInfo").clone();

                    //                    if (roleId == 2) {
                    //                        tr.find("#website").html("<a onmouseover=\"this.style.cursor='hand'\" " + ("onclick=\"getCount('" + result[i].WebSiteiID + "','" + (roleId) + "','" + result[i].WebSiteName + "')") + "\">" + result[i].WebSiteName + "</a>");
                    //                    }
                    //                    else if (roleId == 3) {
                    //                        tr.find("#website").html("<a onmouseover=\"this.style.cursor='hand'\" " + ("onclick=\"getCount('" + result[i].agent + "','" + (roleId) + "','" + result[i].WebSiteName + "')") + "\">" + result[i].WebSiteName + "</a>");
                    //                    }
                    //                    tr.find("#amount").html(parseFloat(result[i].Amount).toFixed(2));
                    //                    tr.find("#validamount").html(parseFloat(result[i].ValidAmount).toFixed(2));
                    //                    tr.find("#moreamount").html(parseFloat(result[i].MoreAmount).toFixed(2));
                    //                    tr.find("#winlose").html(result[i].Result);
                    totalamount += parseFloat(result[i].Amount);
                    totalvalidamount += parseFloat(result[i].ValidAmount);
                    totalwinlose += parseFloat(result[i].Result);
                    totalmoreamount += parseFloat(result[i].MoreAmount);

                    //tr.appendTo("#showInfo");

                    html += "<tr>";
                    if (roleId == 2) {
                        html += "<td><a onmouseover=\"this.style.cursor='hand'\" " + ("onclick=\"getCount('" + result[i].WebSiteiID + "','" + (roleId) + "','" + result[i].WebSiteName + "')") + "\">" + result[i].WebSiteName + "</a></td>";
                    }
                    else if (roleId == 3) {
                        html += "<td><a onmouseover=\"this.style.cursor='hand'\" " + ("onclick=\"getCount('" + result[i].WebSiteName + "','" + (roleId) + "','" + result[i].WebSiteName + "')") + "\">" + result[i].WebSiteName + "</a></td>";
                    }
                    else if (roleId == 4) {
                        html += "<td><a onmouseover=\"this.style.cursor='hand'\" " + ("onclick=\"getCount('" + result[i].WebSiteName + "','" + (roleId) + "','" + result[i].WebSiteName + "')") + "\">" + result[i].WebSiteName + "</a></td>";
                    }

                    html += "<td>" + parseFloat(result[i].Amount).toFixed(2) + "</td>";
                    html += "<td>" + parseFloat(result[i].ValidAmount).toFixed(2) + "</td>";
                    html += "<td>" + parseFloat(result[i].MoreAmount).toFixed(2) + "</td>";
                    html += "<td>" + result[i].Result + "</td>";

                    html += "</tr>";

                });
                jQuery("#showInfo").html(html);
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
                tr.find("#website1").html(languages.H1040);
                tr.find("#amount1").html((totalamount).toFixed(2));
                tr.find("#validamount1").html((totalvalidamount).toFixed(2));
                tr.find("#moreamount1").html((totalmoreamount).toFixed(2));
                tr.find("#winlose1").html((totalwinlose).toFixed(2));
                tr.appendTo("#showInfo");
            });
        }
        function getUserName(data) {
            jQuery.AjaxCommon("/ServicesFile/ReportWebService.asmx/GetOrderByWebsiteID", data, true, false, function (json) {
                //debugger
                jQuery("#TbodyUser>tr").remove();
                var Sequence = 0;
                var result = jQuery.parseJSON(json.d);
                if (pd) {
                    jQuery("#pathP").html(jQuery("#pathP").html() + (roleId != 2 ? "<a onmouseover=\"this.style.cursor='hand'\" onclick=\"getCount1('" + upUserName + "','" + roleId + "','" + (++aIndex) + "','" + upSite + "')" + "\"> >" + upSite + "</a>" : ""));
                }
                pd = 0;
                jQuery.each(result, function (i) {
                    Sequence++;
                    tr = jQuery("#TrUser").clone();
                    tr.find("#SequenceId").html(Sequence);
                    var time = result[i].BeginTime;
                    //var DateTime = fomatdate(time);
                    tr.find("#zh").html("<a href=\"/Report/DataByCasinoAccount.aspx?a=" + result[i].WebSiteiID + "&b=" + result[i].WebUserName + "&c=" + result[i].BeginTime + "\" target=\"_blank\">" + result[i].WebUserName + "</a><br/>" + result[i].UserName);
                    tr.find("#dd").html(result[i].WebOrderID + "<br/>" + result[i].OrderID + "<br/>" + result[i].time);
                    tr.find("#wz").html(result[i].WebSiteName + "<br/>" + result[i].agent);

                    tr.find("#xz").html("<font color=red>" + result[i].BetItem + "@" + result[i].Handicap + ((result[i].BetType == "4" || result[i].BetType == "5" || result[i].BetType == "6" || result[i].BetType == "7" || result[i].BetType == "14" || result[i].BetType == "15") ? ("&nbsp;" + result[i].Scoreathalf) : "") + "</font><br>" + typeList[parseInt(result[i].BetType)] + "<br><font color=blue>" + result[i].home + " -vs- " + result[i].away + "</font><br>" + result[i].league + "@" + result[i].BeginTime);
                    tr.find("#odds").html(result[i].Odds + "<br>" + result[i].OddsType);
                    tr.find("#tzje").html(parseFloat(result[i].Amount).toFixed(2) + "<br/> <Label style=\"color:#A4A49D\">" + parseFloat(result[i].ValidAmount).toFixed(2) + "<Label/>");
                    tr.find("#jtje").html(result[i].MoreAmount);

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
                    tr.find("#sy").html(result[i].Result);
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
<th width="*" class="tab_top_m"><p id="pathP"><font class="st"> <span id="H1412">外调输赢</span>：</font><a onmouseover="this.style.cursor='hand'" onclick="getCount1('','2','0')"><span id="H1460"> 首页</span></a></p></th>
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
    <th id="zh1">网站</th>
    <th id="yj1">投注金额</th>
    <th id="yxje1">有效金额</th>
    <th>加投金额</th>
    <th id="hysy1">输赢</th>
    </tr>
    </thead>
    <tbody id="showInfo">
    
    </tbody>
    <tfoot>
    <tr id="leagueInfo">
    <td id="website"></td>
    <td id="amount"></td>
    <td id="validamount"></td>
    <td id="moreamount"></td>
    <td id="winlose" class="red"></td>

    </tr>
    <tr id="info"></tr>
    <tr id="total">
    <td id="website1"></td>
    <td id="amount1"></td>
    <td id="validamount1"></td>
    <td id="moreamount1"></td>
    <td id="winlose1" class="red"></td>
    </tr>
    </tfoot>
    </table>
    <table width="100%" class="tab2" id="Myshow">
    <thead>
    <tr align="center">
    <th  id="H1026">序号</th>
    <th >帐号</th>
    <th >订单</th>
    <th >网站</th>
    <th >选择</th>
    <th >赔率</th>
    <th >投注金额</th>
    <th>加投金额</th>
    <th >状态</th>
    <th >输赢</th>
    </tr>
    </thead>
    <tbody id="TbodyUser">
    
    </tbody>
    <tfoot>
    <tr id="TrUser">
    
    <td id="SequenceId"></td>
    <td id="zh"></td>
    <td id="dd"></td>
    <td id="wz"></td>
    <td id="xz"></td>
    <td id="odds"></td>
    <td id="tzje"></td>
    <td id="jtje"></td>
    <td id="Status"></td>
    <td id="sy"></td>
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
