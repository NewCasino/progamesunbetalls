<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InduceABreakdownWeb.aspx.cs" Inherits="agent.Report.InduceABreakdownWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>外调明细</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="/js/jQueryCommon.js" type="text/javascript"></script>
    <script type="text/javascript">
        var typeList;
        var leagueName = "";
        var bollID = "";
        jQuery(function () {
            jQuery("#delet").hide();
            jQuery("#delet1").hide();
            typeList = new Array();
            typeList[0] = "单式全场让球";
            typeList[1] = "单式全场大小";
            typeList[2] = "单式半场让球";
            typeList[3] = "单式半场大小";
            typeList[4] = "走地全场让球";
            typeList[5] = "走地全场大小";
            typeList[6] = "走地半场让球";
            typeList[7] = "走地半场大小";
            typeList[8] = "早餐全场让球";
            typeList[9] = "早餐全场大小";
            typeList[10] = "早餐半场让球";
            typeList[11] = "早餐半场大小";
            typeList[12] = "单式全场标准";
            typeList[13] = "单式半场标准";
            typeList[14] = "走地全场标准";
            typeList[15] = "走地半场标准";
            typeList[16] = "早餐全场标准";
            typeList[17] = "早餐半场标准";
            var data = "length:'50',league:'',type:'-1',money:'',ballteam:'',language:'tw'";
            setData(data);
            Countdown(jQuery("#timeTxt").val());

            /*-------------联赛信息-------------*/
            jQuery("#leagueAll").click(function () {

                data = "language:'" + jQuery("#language").val() + "'";
                jQuery.AjaxCommon("/ServicesFile/ReportService/NoteSingleService.asmx/GetLeagueToJson", data, true, false, function (json) {
                    if (json.d != "none") {
                        var tr = "<tr>";
                        jQuery("#tbody1").html("");
                        var result = jQuery.parseJSON(json.d);
                        jQuery.each(result, function (i) {
                            if (i != 0 && i % 4 == 0) {
                                tr += "</tr><tr>";
                            }
                            tr += "<td><input type=\"checkbox\" checked value=\"" + result[i].league + "\" />" + result[i].league + "</td>";
                        });
                        tr += "</tr>";
                        jQuery("#tbody1").html(tr);
                    }
                });
                jQuery("#delet").dialog({ width: 1000 });
                jQuery("#delet").dialog({ model: true });
                jQuery("#allLeague").attr("checked", "checked");
                //确定按钮
                jQuery("#btnSure").unbind("click");
                jQuery("#btnSure").click(function () {
                    jQuery.each(jQuery("#tbody1").find(":checkbox:checked"), function (i) {
                        if (i > 0) {
                            leagueName += ";";
                        }
                        leagueName += jQuery("#tbody1").find(":checkbox:checked:eq(" + i + ")").val();
                    });

                    if (jQuery("#allLeague").attr("checked") || jQuery("#tbody1").find(":checkbox:checked").length == 0) {
                        leagueName = "";
                    }
                    jQuery("#delet").dialog("close");
                });
                //取消按钮
                jQuery("#btnEsc").unbind("click");
                jQuery("#btnEsc").click(function () {
                    //leagueName = "";
                    jQuery("#delet").dialog("close");
                });
                //全选复选框
                jQuery("#allLeague").unbind("click");
                jQuery("#allLeague").click(function () {
                    jQuery("#tbody1").find(":checkbox").attr("checked", jQuery(this).attr("checked"));
                });
                //单项的复选框
                jQuery("#tbody1").find(":checkbox").unbind("click");
                jQuery("#tbody1").find(":checkbox").click(function () {
                    if (jQuery(this).attr("checked")) {
                        if (jQuery("#tbody1").find(":checkbox:checked").length == jQuery("#tbody1").find(":checkbox").length) {
                            jQuery("#allLeague").attr("checked", "checked");
                        }
                    }
                    else {
                        jQuery("#allLeague").removeAttr("checked");
                    }
                });
                //jQuery("#delet").attr("width","500px");
            });
            /*-----------联赛信息结束---------------------*/
            /*--------------球队信息-----------------*/
            jQuery("#boll").click(function () {
                data = "language:'" + jQuery("#language").val() + "'";
                jQuery.AjaxCommon("/ServicesFile/ReportService/NoteSingleService.asmx/GetBollToJson", data, true, false, function (json) {
                    if (json.d != "none") {
                        var tr = "<tr>";
                        jQuery("#tbody1").html("");
                        var result = jQuery.parseJSON(json.d);
                        jQuery.each(result, function (i) {
                            if (i != 0 && i % 3 == 0) {
                                tr += "</tr><tr>";
                            }
                            tr += "<td><input type=\"checkbox\" checked value=\"" + result[i].id + "\" />" + result[i].home + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].away + "</td>";
                        });
                        tr += "</tr>";
                        jQuery("#tbody2").html(tr);
                    }
                });
                jQuery("#delet1").dialog({ width: 800 });
                jQuery("#delet1").dialog({ model: true });
                jQuery("#againstAll").attr("checked", "checked");
                //确定按钮
                jQuery("#btnSure1").unbind("click");
                jQuery("#btnSure1").click(function () {
                    jQuery.each(jQuery("#tbody2").find(":checkbox:checked"), function (i) {
                        if (i > 0) {
                            bollID += ";";
                        }
                        bollID += jQuery("#tbody2").find(":checkbox:checked:eq(" + i + ")").val();
                    });

                    if (jQuery("#againstAll").attr("checked") || jQuery("#tbody2").find(":checkbox:checked").length == 0) {
                        bollID = "";
                    }
                    jQuery("#delet1").dialog("close");
                });
                //取消按钮
                jQuery("#btnEsc1").unbind("click");
                jQuery("#btnEsc1").click(function () {
                    //bollID = "";
                    jQuery("#delet1").dialog("close");
                });
                //全选复选框
                jQuery("#againstAll").unbind("click");
                jQuery("#againstAll").click(function () {
                    jQuery("#tbody2").find(":checkbox").attr("checked", jQuery(this).attr("checked"));
                });
                //单项的复选框 
                jQuery("#tbody2").find(":checkbox").unbind("click");
                jQuery("#tbody2").find(":checkbox").click(function () {
                    if (jQuery(this).attr("checked")) {
                        if (jQuery("#tbody2").find(":checkbox:checked").length == jQuery("#tbody2").find(":checkbox").length) {
                            jQuery("#againstAll").attr("checked", "checked");
                        }
                    }
                    else {
                        jQuery("#againstAll").removeAttr("checked");
                    }
                });
            });
            /*--------------球队信息结束-------------------*/
            jQuery("#selectByWhere").click(function () {
                var t = "";
                if ($("#DataLength").val() != "") {
                    if (parseInt($("#DataLength").val()) > 200) {
                        alert("注单不能超过两百条");
                        t = "50";
                    }
                    else {
                        t = $("#DataLength").val();
                    }
                }
                else {
                    t = "50";
                }
                <% if(searchAc) { %>
                var data = "length:'" + t + "',league:'" + leagueName + "',type:'" + jQuery("#type").val() + "',money:'" + jQuery("#money").val() + "',ballteam:'" + bollID + "',language:'" + jQuery("#language").val() + "'";
                <% } else { %>
                var data = "length:'" + t + "',league:'" + leagueName + "',type:'-1',money:'',ballteam:'" + bollID + "',language:'" + jQuery("#language").val() + "'";
                <% } %>
                setData(data);
            });
        })

        function setData(data) {
            jQuery.AjaxCommon("/ServicesFile/ReportService/InduceService.asmx/GetAllTolength", data, true, false, function (json) {
            debugger
                if (json.d != "none") {
                    jQuery("#showInfo>tr").remove();
                    //alert(json.d);
                    var result = jQuery.parseJSON(json.d);
                    jQuery.each(result, function (i) {
                        var tr = jQuery("#tr1").clone();
                        tr.find("#time").html("" + result[i].time);
                        tr.find("#UserName").html(result[i].UserName + "<br/>" + result[i].OrderID);
                        tr.find("#WebUserName").html(result[i].WebUserName + "<br/>" + result[i].WebOrderID);
                        if (jQuery("#language").val() == "tw") {
                            tr.find("#league").html(result[i].leaguetw + "<br/>" + result[i].BeginTime);
                            tr.find("#Home").html(result[i].Hometw + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awaytw + "<br/>" + result[i].Score);
                        }
                        else if (jQuery("#language").val() == "cn") {
                            tr.find("#league").html(result[i].leaguecn + "<br/>" + result[i].BeginTime);
                            tr.find("#Home").html(result[i].Homecn + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awaycn + "<br/>" + result[i].Score);
                        }
                        else if (jQuery("#language").val() == "en") {
                            tr.find("#league").html(result[i].leagueen + "<br/>" + result[i].BeginTime);
                            tr.find("#Home").html(result[i].Homeen + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awayen + "<br/>" + result[i].Score);
                        }
                        else if (jQuery("#language").val() == "th") {
                            tr.find("#league").html(result[i].leagueth + "<br/>" + result[i].BeginTime);
                            tr.find("#Home").html(result[i].Hometh + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awayth + "<br/>" + result[i].Score);
                        }
                        else if (jQuery("#language").val() == "vn") {
                            tr.find("#league").html(result[i].leaguevn + "<br/>" + result[i].BeginTime);
                            tr.find("#Home").html(result[i].Homevn + "&nbsp;&nbsp;&nbsp;VS&nbsp;&nbsp;&nbsp;" + result[i].Awayvn + "<br/>" + result[i].Score);
                        }
                        //tr.find("#BeginTime").html("" + );
                        tr.find("#BetType").html(typeList[parseInt(result[i].BetType)] + "<br/>" + (result[i].IsHalf == 1 ? "全场" : "半场"));

                        tr.find("#Handicap").html(result[i].Handicap + "<br/>" + result[i].BetItem);
                        tr.find("#Odds").html(result[i].Odds + "<br/>" + result[i].OddsType);
                        tr.find("#UseAmount").html(result[i].Amount + "<br/>" + result[i].ValidAmount);
                        //tr.find("#Company").html(result[i].Amount + "<br/>" + result[i].Amount);
                        $.AjaxCommon("/ServicesFile/webBasicInfo/WebInfoService.asmx/GetDate", "", true, false, function (json1) {
                            if (json1.d != "none") {
                                var result1 = jQuery.parseJSON(json1.d);
                                $.each(result1, function (j) {
                                    if (result1[j].id == result[i].WebSiteiID) {
                                        if (jQuery("#language").val() == "tw") {
                                            tr.find("#WebSiteiID").html((result[i].Status=="1"?"确认":"取消") + "<br/>" + result1[j].nametw);
                                        }
                                        else if (jQuery("#language").val() == "cn") {
                                            tr.find("#WebSiteiID").html((result[i].Status == "1" ? "确认" : "取消") + "<br/>" + result1[j].namecn);
                                        }
                                        else if (jQuery("#language").val() == "en") {
                                            tr.find("#WebSiteiID").html((result[i].Status == "1" ? "确认" : "取消") + "<br/>" + result1[j].nameen);
                                        }
                                        else if (jQuery("#language").val() == "th") {
                                            tr.find("#WebSiteiID").html((result[i].Status == "1" ? "确认" : "取消") + "<br/>" + result1[j].nameth);
                                        }
                                        else if (jQuery("#language").val() == "vn") {
                                            tr.find("#WebSiteiID").html((result[i].Status == "1" ? "确认" : "取消") + "<br/>" + result1[j].namevn);
                                        }
                                    }
                                });
                            }
                        });
                        tr.appendTo("#showInfo");
                    });
                    //jQuery("#showInfo>tr:eq(0)").remove();
                    jQuery("#tb2").alterBgColor({ odd: "odd", even: "even", selected: "selected", tdCss: "tdCss", istdClick: true });
                }
            });
        }

        var pd = 1;
        function Countdown(time) {
            $("#timeUp").text("" + time);
            if (parseInt(time) == 0) {
                var t = "";
                if ($("#timeHide").val() == "") {
                    $("#timeHide").val("5");
                    time = "5";
                }
                else {
                    var a = /^([1-9]|[1-9][0-9])&/;
                    if (!a.test($("#timeHide").val())) {
                        time = "5";
                        $("#timeHide").val("5");
                    }
                    else {
                        time = $("#timeHide").val();
                    }
                }
                if ($("#DataLength").val() != "") {
                    if (parseInt($("#DataLength").val()) > 200) {
                        alert("注单不能超过两百条");
                        t = "50";
                    }
                    else {
                        t = $("#DataLength").val();
                    }
                }
                else {
                    t = "50";
                }
                <% if(searchAc) { %>
                var data = "length:'" + t + "',league:'" + leagueName + "',type:'" + jQuery("#type").val() + "',money:'" + jQuery("#money").val() + "',ballteam:'" + bollID + "',language:'" + jQuery("#language").val() + "'";
                <% } else { %>
                var data = "length:'" + t + "',league:'" + leagueName + "',type:'-1',money:'',ballteam:'" + bollID + "',language:'" + jQuery("#language").val() + "'";
                <% } %>
                setData(data);
                if ($("#timeHide").val() != $("#timeTxt").val()) {
                    if (parseInt($("#timeTxt").val()) < 5) {
                        alert("刷新时间不能小于5秒");
                        $("#timeTxt").val("" + $("#timeHide").val());
                    }
                    $("#timeHide").val("" + $("#timeTxt").val());
                    pd = 1;
                }
            }
            else {
                time = parseInt(time) - 1;
            }
            
            if (pd) {
                if ($("#timeHide").val() == "") {
                    time = "5";
                }
                else {
                    time = $("#timeHide").val();
                }
                pd = 0;
            }
            setTimeout("Countdown(\"" + time + "\")", 1000);
        }
    </script>
</head>
<body>
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p>外调明细</p></th>
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
<input type="hidden" id="language" value="tw" />
    <form id="form1" runat="server">
    <div class="top_banner h30">
    <% if (searchAc)
       { %>
<div class="fl">
<input id="leagueAll" type="button" value="选择联赛" />&nbsp;&nbsp;&nbsp;&nbsp;
    <input type="text" value="" id="money" class="text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />金额&nbsp;&nbsp;&nbsp;&nbsp;
    <input type="button" id="boll" value="选择球队" />&nbsp;&nbsp;&nbsp;&nbsp;
    投注类型:<select id="type">
    <option value="-1">全部</option>
    <option value="0">全场让球</option>
    <option value="1">全场大小</option>
    <option value="2">全场标准</option>
    <option value="3">半场让球</option>
    <option value="4">半场大小</option>
    <option value="5">半场标准</option>
    <option value="6">走地全场让球</option>
    <option value="7">走地全场大小</option>
    <option value="8">走地全场标准</option>
    <option value="9">走地半场让球</option>
    <option value="10">走地半场大小</option>
    <option value="11">走地半场标准</option>
    </select>&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in">搜索</span></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</div>
<% } %>
<div class="fr">
<input type="text" id="timeTxt" value="5" class="text_01 w_30" onmouseover="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" /><label id="timeUp">5</label>&nbsp;&nbsp;&nbsp;&nbsp;
<input type="text" value="50" id="DataLength" class="text_01 w_60" onmouseover="this.className='text_01_h w_60'" onmouseout="this.className='text_01 w_60'" />条
    
</div>

</div>
    <table width="100%" class="tab2" id="tb2">
    <thead>
    <tr>
    <th>下注时间</th>
    <th>账号</th>
    <th>投注账号</th>
    <th>联赛</th>
    <th>队伍</th>
    <th>投注类型</th>
    <th>盘口</th>
    <th>赔率</th>
    <th>投注金额</th>
    <th>公司金额</th>
    <th>网站</th>
    </tr>
    </thead>
    <tbody id="showInfo" class="tc">
    
    </tbody>
    <tfoot>
    <tr id="tr1">
    <td id="time"></td>
    <td id="UserName"></td>
    <td id="WebUserName"></td>
    <td id="league"></td>
    <td id="Home"></td>
    <td id="BetType"></td>
    <td id="Handicap"></td>
    <td id="Odds"></td>
    <td id="UseAmount"></td>
    <td id=""></td>
    <td id="WebSiteiID"></td>
    </tr>
    </tfoot>
    </table>
    </form>

    <div id="delet" title="选择联赛">
    <div id="leagueDiv" class="showdiv">
    <table width="100%">
    <thead>
    <tr><th align="left"><input type="checkbox" id="allLeague" /></th><th colspan="3" align="left">选择联赛</th></tr>
    </thead>
    <tbody id="tbody1">
    </tbody>
    </table>
    <div align="center" class="mtop_50">
<input type="button" class="btn_02" id="btnSure" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="确定" />
<input type="button" class="btn_02" id="btnEsc" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="取消" />
</div>
    </div>
    </div>


    <div id="delet1" title="选择球队" >
    <div id="againstDiv" class="showdiv">
    <table>
    <thead>
    <tr><th align="left"><input type="checkbox" id="againstAll" /></th><th colspan="2" align="left">选择对阵双方</th></tr>
    </thead>
    <tbody id="tbody2">
    </tbody>
    </table>
    <div align="center" class="mtop_50">
<input type="button" class="btn_02" id="btnSure1" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="确定" />
<input type="button" class="btn_02" id="btnEsc1" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="取消" />
</div>
    </div>
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
</body>
</html>
