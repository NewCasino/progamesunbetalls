<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="ClearingWeb.aspx.cs" Inherits="admin.ReleaseSite.ClearingWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="/js/page/pageJs.js" type="text/javascript"></script>
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="/js/jQueryCommon.js" type="text/javascript"></script>
    <script src="/js/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
    <script src="/js/webBasicInfo/zh-CN.js" type="text/javascript"></script>
    <link href="/css/Default/cupertino/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var data;
        jQuery(function () {
            //加载多语言
            SetGlobal("");
            setSel();
            setDate();
            var xf = true;

            $("#time1WhereVal,#time2WhereVal").datepicker().click(function () {
                $(this).val("");
            });
            //$("#time2WhereVal").datepicker();
            $("#selectByWhere").click(function () {
                if ($("#league").val() != "" || $("#home").val() != "" || $("#away").val() != "" || $("#time1WhereVal").val() != "" || $("#time2WhereVal").val() != "") {
                    selectByWhere();
                }
            });

            $(".inputWhere").keyup(function (e) {
                var currKey = 0, e = e || event;
                currKey = e.keyCode || e.which || e.charCode;
                if (currKey == 13) {
                    selectByWhere();
                    $(this).blur();
                }
            });

            $(".TbSel").click(function () {
                $.AjaxCommon("/ServicesFile/ReleaseSite/ReleaseSiteService.asmx/GetAllToJson4", "language:'" + jQuery("#langue").val() + "',time:'" + $(this).text() + "'", true, false, function (json) {
                    $("#tb2>tbody").html("");
                    if (json.d != "none") {
                        var r = $.parseJSON(json.d), html = "";
                        $.each(r, function (x) {
                            html += "<tr id=\"tr1\"><td id=\"checkboxTD\"><input type=\"checkbox\" value=\"" + r[x].a + "\" /><input id=\"allscore\" type=\"hidden\" value=\"" + r[x].resulthomescore2 + ":" + r[x].resultawayscore2 + "\"><input id=\"haftscore\" type=\"hidden\" value=\"" + r[x].halfhomescore2 + ":" + r[x].halfawayscore2 + "\"></td><td id=\"timeTD\">" + r[x].j + "</td><td id=\"leagueTD\">" + r[x].b + "</td><td id=\"homeTD\">" + r[x].c + "</td><td id=\"awayTD\">" + r[x].d + "</td><td id=\"scoreTD\">" + r[x].e + ":" + r[x].f + "</td><td id=\"halfscoreTD\">" + r[x].g + ":" + r[x].h + "</td></tr>";
                        });
                    } else {
                        html = "<tr id=\"tr1\" align=\"center\"></tr>";
                    }
                    $("#tb2>tbody").append(html);
                    jQuery("#tb2").alterBgColor({ odd: "odd", even: "even", selected: "selected", tdCss: "tdCss", istdClick: true });
                });
            });

            jQuery("#AllOrEsc").click(function () {
                if (jQuery("#AllOrEsc").attr("checked") == true) {
                    jQuery("#showInfo").find(":checkbox").attr("checked", "checked");
                    jQuery("#showInfo>tr").attr("class", "selected");
                }
                else {
                    jQuery("#showInfo").find(":checkbox").removeAttr("checked");
                    jQuery("#showInfo>tr").removeAttr("class", "selected");
                }
            });
            jQuery("#clear").click(function () {

                if ($("#showInfo").find(":checkbox:checked").length != 0) {
                    xf = true;
                    var html = "";
                    var bb = jQuery("#jstab tr").length - 2;
                    var cc = jQuery("#jstab tr").length - 1;

                    jQuery.each(jQuery("#jstab tr"), function (i, n) {
                        if (i != 0 && i != bb && i != cc) {
                            jQuery(n).remove();
                        }
                    });
                    jQuery.each($("#showInfo").find(":checkbox:checked"), function (i, n) {
                        html += "<tr>";
                        html += "<td align=\"right\">" + jQuery(n).parent().parent().find("td:eq(3)").html() + " <font color=blue>vs</font> " + jQuery(n).parent().parent().find("td:eq(4)").html() + "</td>";
                        html += "<td align=\"center\">HT " + jQuery(n).parent().parent().find("td:eq(6)").html() + "<br>FT " + jQuery(n).parent().parent().find("td:eq(5)").html() + "</td>";
                        html += "<td align=\"center\">HT " + jQuery(n).parent().parent().find("td:eq(0) #haftscore").val() + "<br>FT " + jQuery(n).parent().parent().find("td:eq(0) #allscore").val() + "</td>";
                        if (jQuery(n).parent().parent().find("td:eq(6)").html() != jQuery(n).parent().parent().find("td:eq(0) #haftscore").val() || jQuery(n).parent().parent().find("td:eq(5)").html() != jQuery(n).parent().parent().find("td:eq(0) #allscore").val()) {
                            html += "<td align=\"left\"><font color=red>比分不符</font></td>";
                            xf = false;
                        }
                        else {
                            html += "<td align=\"left\"></td>";
                        }
                        html += "</tr>";
                    });
                    jQuery("#jstab tr:eq(0)").after(html);
                }
                else {
                    alert("未选择比赛");
                    return;
                }
                jQuery("#add").dialog({ modal: true, width: 500 });

                //确认结算事件
                jQuery("#Button1").unbind().bind("click", function () {
                    if (!xf) {
                        if (!confirm("录入比分和抓取比分不相等，是否要继续结算？")) {
                            return;
                        }
                    }

                    if ($("#showInfo").find(":checkbox:checked").length != 0) {
                        $("#deleteID").val("");
                        $("#deleteS").val("");
                        $("#deleteQS").val("");
                        jQuery.each($("#showInfo").find(":checkbox:checked"), function (i) {
                            if ($("#deleteID").val() == "") {
                                $("#deleteID").val($("#showInfo").find(":checkbox:checked:eq(" + i + ")").val());
                                $("#deleteS").val($("#showInfo").find(":checkbox:checked:eq(" + i + ")").parent().parent().find("#halfscoreTD").text());
                                $("#deleteQS").val($("#showInfo").find(":checkbox:checked:eq(" + i + ")").parent().parent().find("#scoreTD").text());
                            }
                            else {
                                $("#deleteID").val($("#deleteID").val() + "," + $("#showInfo").find(":checkbox:checked:eq(" + i + ")").val());
                                $("#deleteS").val($("#deleteS").val() + "," + $("#showInfo").find(":checkbox:checked:eq(" + i + ")").parent().parent().find("#halfscoreTD").text());
                                $("#deleteQS").val($("#deleteQS").val() + "," + $("#showInfo").find(":checkbox:checked:eq(" + i + ")").parent().parent().find("#scoreTD").text());
                            }
                        });
                        jQuery("#Button1").val("正在结算...");
                        jQuery("#Button1").attr("disabled", "disabled");
                        jQuery("#Button2").attr("disabled", "disabled");
                        jQuery.AjaxCommon("/ServicesFile/ReleaseSite/ReleaseSiteService.asmx/jsff", "g:'" + jQuery("#deleteID").val() + "',hl:'" + $("#deleteS").val() + "',ss:'" + $("#deleteQS").val() + "'", true, false, function (json) {
                            if (json.d != "none") {
                                if (json.d.substr(0, 3) == "err") {
                                    alert(json.d);
                                }
                                else {
                                    jQuery.each($("#showInfo").find(":checkbox:checked"), function (i, n) {
                                        jQuery(n).parent().parent().remove();
                                    });
                                    jQuery("#add").dialog("close");
                                    alert(languages.H2006);
                                }
                            }
                            jQuery("#Button1").val("结算");
                            jQuery("#Button1").removeAttr("disabled");
                            jQuery("#Button2").removeAttr("disabled");
                            
                        });
                    } else {
                        alert(languages.H1192 + "" + languages.H1293);
                    }
                });

                //取消结算事件
                jQuery("#Button2").unbind().bind("click", function () {
                    jQuery("#add").dialog("close");
                });

            });
        });


        //---------多语言处理-----------
        var languages = "";
        var lang;
        function SetGlobal(setLang) {

            setLang = $.SetOrGetLanguage(setLang, function () {
                //debugger
                languages = language;
                
                $("#sj").text(languages.H1056);
                $("#AllOrEsc").attr("title", languages.H1166);
                $("#clear").attr("value", languages.H2001);
                $("#startTime").html(languages.H1178);
                $("#League").html(languages.H1130);
                $("#hometeam").html(languages.H1131);
                $("#visitors").html(languages.H1132);
                $("#score").html(languages.H1133);
                $("#scoreAtHalf").html(languages.H1180);
                $("#zdjs").html(languages.H2002);
                jQuery("#ls").text(languages.H1130);
                jQuery("#zd").text(languages.H1131);
                jQuery("#kd").text(languages.H1132);
            });
            lang = setLang;
        }
        //--------多语言处理结束---------

        function setSel() {
            var d = new TipDate();
            $("#lbl1").text(d.curr());
            $("#lbl2").text(d.prev1());
            $("#lbl3").text(d.prev2());
            $("#lbl4").text(d.prev3());
            $("#lbl5").text(d.prev4());
            $("#lbl6").text(d.prev5());
            $("#lbl7").text(d.prev6());
        }

        function TipDate() {
            function formatDate(d) {
                var _todayDate = d.getDate() < 10 ? "0" + d.getDate() : d.getDate();
                //var _year = d.getYear();
                var _month = d.getMonth() + 1;
                _month = _month < 10 ? "0" + _month : _month;
                return _month + "-" + _todayDate;
            }
            var now = new Date();
            function diffDate(m) {
                var dd = new Date();
                var datevalue = now.getDate() + m;
                var month = now.getMonth() + 1;
                if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) {
                    if (datevalue > 31) {
                        dd.setDate(datevalue - 31);
                        dd.setMonth(month);
                    }
                    else {
                        dd.setDate(datevalue);
                    }
                }
                else if (month == 4 || month == 6 || month == 9 || month == 11) {
                    if (datevalue > 30) {
                        dd.setDate(datevalue - 30);
                        dd.setMonth(month);
                    }
                    else {
                        dd.setDate(datevalue);
                    }
                }
                else if (month == 2) {
                    if (datevalue > 28) {
                        dd.setDate(datevalue - 28);
                        dd.setMonth(month);
                    }
                    else {
                        dd.setDate(datevalue);
                    }
                }
                return formatDate(dd);
            }
            return {
                curr: function () {
                    return diffDate(0);
                },
                prev1: function () {
                    return diffDate(-1);
                },
                prev2: function () {
                    return diffDate(-2);
                },
                prev3: function () {
                    return diffDate(-3);
                },
                prev4: function () {
                    return diffDate(-4);
                },
                prev5: function () {
                    return diffDate(-5);
                },
                prev6: function () {
                    return diffDate(-6);
                }
            };
        }

        function setDate(){
            $.AjaxCommon("/ServicesFile/ReleaseSite/ReleaseSiteService.asmx/GetAllToJson1", "language:'" + jQuery("#langue").val() + "'", true, false, function (json) {
                $("#tb2>tbody").html("");
                if (json.d != "") {
                    var r =jQuery.parseJSON(json.d), html = "";
                    $.each(r, function (x) {
                        html += "<tr id=\"tr1\"><td id=\"checkboxTD\"><input type=\"checkbox\" value=\"" + r[x].a + "\" /><input id=\"allscore\" type=\"hidden\" value=\"" + r[x].resulthomescore2 + ":" + r[x].resultawayscore2 + "\"><input id=\"haftscore\" type=\"hidden\" value=\"" + r[x].halfhomescore2 + ":" + r[x].halfawayscore2 + "\"></td><td id=\"timeTD\">" + r[x].j + "</td><td id=\"leagueTD\">" + r[x].b + "</td><td id=\"homeTD\">" + r[x].c + "</td><td id=\"awayTD\">" + r[x].d + "</td><td id=\"scoreTD\">" + r[x].e + ":" + r[x].f + "</td><td id=\"halfscoreTD\">" + r[x].g + ":" + r[x].h + "</td></tr>";
                    });
                } else {
                    html = "<tr id=\"tr1\" align=\"center\"></tr>";
                }
                $("#tb2>tbody").append(html);
                jQuery("#tb2").alterBgColor({ odd: "odd", even: "even", selected: "selected", tdCss: "tdCss", istdClick: true });
            });
            jQuery("#showInfo>tr").find("#checkboxTD").find(":checkbox").click(function () {
                if (jQuery(this).attr("checked") == false) {
                    $("#AllOrEsc").removeAttr("checked");
                }
                else {
                    if ($("#showInfo").find(":checkbox:checked").length == $("#showInfo").find(":checkbox").length) {
                        $("#AllOrEsc").attr("checked", "checked");
                    }
                }
            });
        }

        function selectByWhere() {
            $.AjaxCommon("/ServicesFile/ReleaseSite/ReleaseSiteService.asmx/GetLeagueByWhere", "language:'" + jQuery.trim($("#langue").val()) + "',league:'" + jQuery.trim($("#league").val()) + "',home:'" + jQuery.trim($("#home").val()) + "',away:'" + jQuery.trim($("#away").val()) + "',beginTime:'" + $("#time1WhereVal").val() + "',endTime:'" + $("#time2WhereVal").val() + "'", true, false, function (json) {
                $("#tb2>tbody").html("");
                if (json.d != "none") {
                    var r = $.parseJSON(json.d), html = "";
                    $.each(r, function (x) {
                        html += "<tr id=\"tr1\"><td id=\"checkboxTD\"><input type=\"checkbox\" value=\"" + r[x].a + "\" /><input id=\"allscore\" type=\"hidden\" value=\"" + r[x].resulthomescore2 + ":" + r[x].resultawayscore2 + "\"><input id=\"haftscore\" type=\"hidden\" value=\"" + r[x].halfhomescore2 + ":" + r[x].halfawayscore2 + "\"></td><td id=\"timeTD\">" + r[x].j + "</td><td id=\"leagueTD\">" + r[x].b + "</td><td id=\"homeTD\">" + r[x].c + "</td><td id=\"awayTD\">" + r[x].d + "</td><td id=\"scoreTD\">" + r[x].e + ":" + r[x].f + "</td><td id=\"halfscoreTD\">" + r[x].g + ":" + r[x].h + "</td></tr>";
                    });
                } else {
                    html = "<tr id=\"tr1\" align=\"center\"></tr>";
                }
                $("#tb2>tbody").append(html);
                jQuery("#tb2").alterBgColor({ odd: "odd", even: "even", selected: "selected", tdCss: "tdCss", istdClick: true });
//                $("#league").val(""); $("#home").val(""); $("#away").val("");
            });
        }
    </script>
</head>
<body>
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="zdjs">注单结算</p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<!--主题部分开始=========================================================================================-->
    <input type="hidden" id="langue" value="tw" />
    <input type="hidden" id="deleteID" />
    <input type="hidden" id="deleteS" />
    <input type="hidden" id="deleteQS" />
    <form id="form1" runat="server">
    <div class="users_ma_tit"><div  style="width:100%">
    <%if (clearingAc)
      { %>
    <%--<input type="button" id="clear" value="结算" style="margin-right:0px;" />--%>&nbsp;
    <span id="clear" class="btn_04">&nbsp;&nbsp;结算&nbsp;&nbsp;</span>
    <%} %>&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="ls">联赛</a>&nbsp;&nbsp;<input type="text" id="league" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="zd">主队</a>&nbsp;&nbsp;<input type="text" id="home" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="kd">客队</a>&nbsp;&nbsp;<input type="text" id="away" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="sj">时间</a>&nbsp;&nbsp;<input type="text" id="time1WhereVal" class="inputWhere text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" readonly="readonly"  />－<input type="text" id="time2WhereVal" class="inputWhere text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" readonly="readonly"  />&nbsp;&nbsp;
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in">搜索</span></a>
    </div>
    <div class="fl h30" style="width:100%">
    <span class="TbSel" id="lbl7" d="7"></span>
    <span class="TbSel" id="lbl6" d="6"></span>
    <span class="TbSel" id="lbl5" d="5"></span>
    <span class="TbSel" id="lbl4" d="4"></span>
    <span class="TbSel" id="lbl3" d="3"></span>
    <span class="TbSel" id="lbl2" d="2"></span>
    <span class="TbSel" id="lbl1" d="1"></span>
        </div>
      </div>
    <table class="tab2" id="tb2" width="100%" border="0" cellpadding="0" cellspacing="0">
    <thead>
    <tr>
    <th><input type="checkbox" id="AllOrEsc" title="全选/取消" /></th>
    <th id="startTime">开始时间</th>
    <th id="League">联赛</th>
    <th id="hometeam">主队</th>
    <th id="visitors">客队</th>
    <th id="score">比分</th>
    <th id="scoreAtHalf">上半场比分</th>
    </tr>
    </thead>
    <tbody id="showInfo">
    <%--<tr id="tr1">
    <td id="checkboxTD"></td>
    <td id="timeTD"></td>
    <td id="leagueTD"></td>
    <td id="homeTD"></td>
    <td id="awayTD"></td>
    <td id="scoreTD"></td>
    <td id="halfscoreTD"></td>
    </tr>--%>
    </tbody>
    </table>
    <%-- 分页的div --%>
    <%--<div id="pageDiv" class="grayr">总共<label id="infoCount"></label>条记录,共<label id="pageCount"></label>页<a style="cursor:hand"> 首页 </a><a style="cursor:hand"> 上一页 </a><span id="pageSpan"></span><a style="cursor:hand"> 下一页 </a><a style="cursor:hand"> 尾页 </a></div>--%>
    <%-- 分页的div结束 --%>
    </form>
    <!--主题部分结束=========================================================================================-->

    <div class="undis">
    <div id="add" title="结算确认" >
    <div class="showdiv">
    <table width="100%"  border="0" cellpadding="1" cellspacing="1" id="jstab" align="center">
  <tr align="center" style="background-color:#CDEAFC">
    <td id="Td1" >比赛</td>
    <td id="Td3" >录入比分</td>
    <td id="Td4" >抓取比分</td>
    <td id="Td5" ></td>
  </tr>
  <tr>
    <td align="right" colspan="4" style="height:20px;"></td>
  </tr>
  <tr>
    <td colspan="4" align="center">
<input type="button" id="Button1"  class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'"  value="结算" />
<input type="button" id="Button2"  class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="取消" />
	
	</td>
  </tr>
</table>

    </div>
    </div>
    </div>

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
