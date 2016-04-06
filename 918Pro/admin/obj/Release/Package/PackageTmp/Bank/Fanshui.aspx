<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fanshui.aspx.cs" Inherits="admin.Bank.Fanshui" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>返水审核</title>
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
    <style type="text/css">
        #refuseDepoist{display:none;}
    </style>
    <script type="text/javascript">
        function CurentTime1() {
            var now = new Date();
            var year = now.getFullYear();       //年
            var month = now.getMonth() + 1;     //月
            var day = now.getDate() - 1;       //日


            var clock = year + "-";
            if (month < 10)
                clock += "0";
            clock += month + "-";
            if (day < 10) {
                clock += "0";
            }
            clock += day;
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
            if (day < 10) {
                clock += "0";
            }
            clock += day;
            return (clock);
        }
        var currID = "";
        var bankArr = new Array;
        var language = $.cookie("lan"), lan = "";
        switch (language) {
            case "zh-cn":
                lan = "cn"; break;
            case "zh-tw": lan = "tw"; break;
            case "en-us":
                lan = "en"; break;
            case "th-th":
                lan = "th"; break;
            case "vi-vn":
                lan = "vn"; break;
            default: lan = "cn"; break;
        }
        $(function () {
            $("#txtdate1").datepicker().val(SetTime(-1));
            $("#txtdate2").datepicker().val(SetTime(-1));
            $("#txttime1").val("00:00:00");
            $("#txttime2").val("23:59:59");
            $("#gametype").change(function () {
                if ($(this).val() == "4") {
                    $("#txtdate1").val(SetTime(-1));
                    $("#txtdate2").val(SetTime(-1));
                    $("#txttime1").val("00:00:00");
                    $("#txttime2").val("23:59:59");

                } else {
                    $("#txtdate1").val(SetTime(-1));
                    $("#txtdate2").val(SetTime(-1));
                    $("#txttime1").val("00:00:00");
                    $("#txttime2").val("23:59:59");

                }
            });
            //GetBankArr();
            SelectByWhere();
            //Countdown(jQuery("#timeTxt").val()); $("#language").val(lan);
            jQuery("#time1WhereVal").datepicker();
            //$('#time1WhereVal').val(CurentTime1());
            jQuery("#time2WhereVal").datepicker();
            //$('#time2WhereVal').val(CurentTime2());

            $("#selectByWhere").click(function () {
                SelectByWhere();
            });
            $("#addBtn").click(function () {
                $("#addfsdiv").dialog({
                    modal: false,
                    width: "500px",
                    beforeClose: function () {
                        $("#txtbl").val("");
                        $("#txtmark").val("");
                        $("#addfsdiv :button").attr("disabled", false);
                    }
                });
                $("#Button3").unbind("click").bind("click", function () {
                    $("#addfsdiv").dialog("close");
                });
                $("#Button1").unbind("click").bind("click", function () {
                    var txtdate1 = $("#txtdate1").val();
                    var txttime1 = $("#txttime1").val();
                    var txtdate2 = $("#txtdate2").val();
                    var txttime2 = $("#txttime2").val();
                    var txtbl = $("#txtbl").val();
                    var mark = $("#txtmark").val();

                    var check = true;
                    $.each($("#addfsdiv :text"), function (i, n) {
                        $(n).blur();
                    });
                    $.each($("#addfsdiv span[id*=err]"), function (i, n) {
                        if ($(n).text() != "") {
                            check = false;
                            return false;
                        }
                    });
                    if (check == false) {
                        return;
                    }
                    //提交数据
                    alert("点击\"确定\"后系统将自动添加返水，请耐心等待!");
                    $("#addfsdiv :button").attr("disabled", true);
                    var url = "/ServicesFile/BankService/BankService.asmx/AutoFanshui";
                    var data = "time1:'" + txtdate1 + " " + txttime1 + "',time2:'" + txtdate2 + " " + txttime2 + "',fsbl:" + txtbl + ",mark:'" + mark + "',gametype:'" + $("#gametype").val() + "'";
                    $.AjaxCommon(url, data, true, false, function (json) {
                        if (json.d == "1") {
                            //成功
                            $("#fstype").val($("#gametype").val());
                            SelectByWhere();
                            alert("返水添加成功!");
                            $("#addfsdiv").dialog("close");
                        } else if (json.d == "0") {
                            //失败
                            alert("返水添加失败，请联系技术");
                        } else if (json.d == "-1") {
                            //登出
                            SysLoginOut();
                        }
                        $("#addfsdiv :button").attr("disabled", false);
                    });
                });
            });
            $(".inputWhere").keyup(function (e) {
                var currKey = 0, e = e || event;
                currKey = e.keyCode || e.which || e.charCode;
                if (currKey == 13) {
                    SelectByWhere();
                    $(this).blur();
                }
            });
            $("#depositHistory").click(function () {
                location = "/Bank/FanshuiHistory.aspx";
            });
            $("#VerifyDeposit").click(function () {
                location = "/Bank/Fanshui.aspx";
            });
        });
        function SelectByWhere() {
            $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/GetList", "userName:'" + $.trim($("#memberSel").val()) + "',time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',type:'" + $("#fstype").val() + "'", true, false, function (json) {
                if (json.d != "]") {
                    var re = jQuery.parseJSON(json.d);
                    var html = "", total1 = 0;
                    $.each(re, function (i) {
                        total1 += parseFloat(re[i].Amount);
                        html += "<tr><td>" + (i + 1) + "</td><td><a href='javascript:void(0)' style='color:#0075a9' onclick=\"window.open('/User/UserInfo.aspx?u=" + re[i].UserName + "','','width=600,height=270');\">" + re[i].UserName + "</a></td><td>" + re[i].validamount + "</td><td>" + re[i].Reasonvn + "</td><td style='color:red;'>" + re[i].Amount + "</td><td>" + re[i].banktime + "</td><td>" + re[i].tel + "</td><td>" + re[i].SubmitTime + "</td><td>" + (re[i].Type == "4" ? "太阳城游戏" : "太阳城游戏") + "</td><td>" + re[i].mark + "</td><td><a class=\"verify\" href=\"#\" attr=\"" + re[i].ID + "\">审核</a></td></tr>"; //存入帐号<td>" + re[i].j + "</td>
                    });
                    html += "<tr><td>总计</td><td colspan='3'></td><td>" + total1.toFixed(2) + "</td><td colspan='10'></td></tr>";
                    $("#tab1>tbody").html(html);
                    $("#tab1>tbody>tr").mouseover(function () {
                        $(this).siblings().removeClass("trOver").end().addClass("trOver");
                    });
                    $(".verify").unbind("click").bind("click", function () {
                        currID = $(this).attr("attr");
                        var $tr = $(this).parent().parent().find("td");
                        //getUserInfo($tr.eq(1).html());
                        $("#username").html($tr.eq(1).html() == "" ? "--" : $tr.eq(1).html());
                        $("#validamount").html($tr.eq(2).html());
                        $("#Reasonvn").html($tr.eq(3).html() == "" ? "--" : $tr.eq(3).html());

                        $("#Amount").html($tr.eq(4).html());
                        $("#time1").html($tr.eq(5).html());
                        $("#time2").html($tr.eq(6).html());
                        $("#Submittime").html($tr.eq(7).html());
                        $("#xm").html($tr.eq(8).html());

                        $("#verify_list").dialog({ modal: true, width: "530px" });
                    });
                } else {
                    $("#tab1>tbody").html("<tr><td colspan=\"10\">没有相应数据</td></tr>");
                }
            });
        }
        function acceptBtn() {
            if (parseFloat($.trim($("#realMoney").val())) > parseFloat($("#money").html())) {
                alert("实际存入金额不能大于客户存入金额");
                $("#realMoney").val($("#money").html()).focus();
            } else {
                if (confirm("您确定要接受该返水吗?")) {
                    $("#AcceptBtn").attr("disabled", true);
                    $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/VerifyBillNotice110", "status:'2',reason:'',id:'" + currID + "',validAmount:'" + $.trim($("#balance").html()) + "'", true, false, function (json) {
                        if (json.d != "false" && json.d != "nomoney") {
                            var re = jQuery.parseJSON(json.d);
                            //alert("审核成功\n当前帐户余额：" + (parseFloat(re.a) + parseFloat(re.b)) + "\n本次返水金额：" + re.c + "\n实际存入金额：" + re.b + "");
                            alert("审核成功");
                            $("#verify_list").dialog("close");
                            SelectByWhere();
                        } else if (json.d == "nomoney") {
                            alert("余额不足");
                        } else {
                            alert("审核失败");
                        }
                        $("#AcceptBtn").attr("disabled", false);
                    });
                }
            }
        }
        function refuseBtn() {
            getReson();
            $("#refuseDepoist").dialog({ modal: false, resizable: false });
            $("#submitBtn").unbind("click").bind("click", function () {
                if (confirm("您确定要拒绝该返水吗?")) {
                    if ($.trim($("#reason").val()) == "") {
                        alert("拒绝理由不能为空");
                    } else {
                        $("#submitBtn").attr("disabled", true);
                        $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/VerifyBillNotice1", "status:'3',reason:'" + $("#reason").val() + "',id:'" + currID + "',validAmount:'" + $.trim($("#balance").val()) + "'", true, false, function (json) {
                            if (json.d != "false" && json.d != "nomoney") {
                                var re = jQuery.parseJSON(json.d);
                                alert("审核成功");
                                $("#verify_list").dialog("close");
                                SelectByWhere();
                                $("#refuseDepoist").dialog("close");
                            } else {
                                alert("审核失败");
                                $("#refuseDepoist").dialog("close");
                            }
                            $("#submitBtn").attr("disabled", false);
                        });
                    }
                }
            });
            $("#cancelBtn").unbind("click").bind("click", function () {
                $("#refuseDepoist").dialog("close");
            });
        }
        function escBtn() {
            $("#verify_list").dialog("close");
        }
        function getUserInfo(userName) {
            $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/GetUserInfo", "userName:'" + userName + "'", true, false, function (json) {
                if (json.d != "") {
                    var result = jQuery.parseJSON(json.d);
                    $.each(result, function (i) {
                        $("#userAccount").html(result[i].a);
                        $("#userName").html(result[i].b == "" ? "--" : ("<a href='#'>" + result[i].b + "</a>"));
                        $("#sex").html(result[i].e == "" ? "--" : result[i].e);
                        if (result[i].f != "") {
                            var birth = (result[i].f).toString().split(' ');
                            $("#birthday").html(birth[0]);
                        } else {
                            $("#birthday").html("--");
                        }
                        $("#tel").html(result[i].d == "" ? "--" : result[i].d);
                        $("#email").html(result[i].c == "" ? "--" : result[i].c);
                        $("#country").html(result[i].g == "" ? "--" : result[i].g);
                        $("#address").html(result[i].h == "" ? "--" : result[i].h);
                        //$("#mobile").html(result[i].m == "" ? "--" : result[i].m);
                        $("#balance").html(result[i].n == "" ? "--" : result[i].n);
                    });
                }
            });
        }
        function getReson() {
            $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/GetReason", "", true, false, function (json) {
                if (json.d != "") {
                    var result = jQuery.parseJSON(json.d);
                    var html = "";
                    $.each(result, function (i) {
                        html += "<option value=\"" + result[i].a + "\">" + result[i].b + "</option>";
                    });
                    $("#reason").html(html);
                }
            });
        }
        function GetBankArr() {
            $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/GetBankInfoAll", "lan:'" + lan + "'", true, false, function (json) {
                if (json.d != "") {
                    var r = jQuery.parseJSON(json.d);
                    $.each(r, function (i) {
                        bankArr[r[i].a] = r[i].b;
                    });
                }
            });
        }
        var pd = 1;
        function Countdown(time) {
            $("#timeUp").text("" + time);
            if (parseInt(time) == 0) {
                if ($("#timeHide").val() == "") {
                    $("#timeHide").val("20");
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
                SelectByWhere();
                if ($("#timeHide").val() != $("#timeTxt").val()) {
                    if (parseInt($("#timeTxt").val()) < 5) {
                        var setLang = "";
                        setLang = $.SetOrGetLanguage(setLang, function () {
                            languages = language;
                            alert(languages["H1255"]);
                        }, "/js/IndexGlobal/");
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
        function SetTime(n) {
            var date = new Date();
            date.setDate(date.getDate() + n);
            return (date.getYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate());
            //$("#txttime1,#txttime2").val(date.toLocaleTimeString());
        }
    </script>
</head>
<body>
    <table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="zdjs">未审核返水</p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<input type="hidden" value="" id="timeHide" />
    <input type="hidden" id="language" value="zh-tw"/>
    <form id="form1" runat="server">
    <div class="top_banner h30">
    <div class="fl"  style="width:95%;padding:3px;margin:2px;">
    <input type="button" id="addBtn" class="top_add" onmouseover="this.className='top_add_h'" onmouseout="this.className='top_add'"  value="添加返水" />&nbsp;&nbsp;
    <span id="VerifyDeposit" class="btn_04">&nbsp;&nbsp;未审核返水&nbsp;&nbsp;</span>
    <span id="depositHistory" class="btn_04">&nbsp;&nbsp;已审核返水&nbsp;&nbsp;</span>&nbsp;&nbsp;
    <a id="hyzh">会员帐号</a>&nbsp;&nbsp;<input type="text" id="memberSel" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;&nbsp;&nbsp;
    <a>类型</a><select id="fstype"><option value="4">太阳城游戏返水</option><option value="14">太阳城游戏返水</option></select>&nbsp;&nbsp;
    <a id="jysj">申请时间</a>&nbsp;&nbsp;<input type="text" id="time1WhereVal" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" readonly="readonly"  />－<input type="text" id="time2WhereVal" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" readonly="readonly"  />&nbsp;&nbsp;
    <%--<a id="zt">状态</a>&nbsp;&nbsp;<select id="statusSel"><option value="1">全部</option>
        <option value="2">成功</option><option value="3">拒绝</option>
    </select>&nbsp;&nbsp;&nbsp;&nbsp;--%>
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in">搜索</span></a>&nbsp;&nbsp;&nbsp;&nbsp;
    <div style="display:none;"><input type="text" id="timeTxt" value="5" class="text_01 w_30" onmouseover="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" /><label id="timeUp">5</label></div>&nbsp;&nbsp;
    </div>
    </div>
     <div id="verify_list" title="返水审核" class="new_tr undis">
<div align="center">
<table width="100%"  border="0" cellpadding="1" cellspacing="1" id="addtb">
  <tr align="center" style="background-color:#CDEAFC">
    <td colspan="4"><strong>返水信息</strong></td>
  </tr>
  <tr>
    <td align="right" >会员账号：</td>
    <td id="username" align="left" ></td>
    <td align="right">有效投注：</td>
    <td id="validamount"  align="left"></td>
  </tr>
  <tr>
    <td align="right" >计算比率：</td>
    <td id="Reasonvn"  align="left" ></td>
    <td align="right" >返水金额：</td>
    <td align="left" id="Amount" class="red"></td>
  </tr>
    <tr>
    <td align="right" >开始时间：</td>
    <td id="time1"  align="left"></td>
    <td align="right" >结束时间：</td>
    <td align="left" id="time2"></td>
  </tr>
    <tr>
    <td align="right" >申请时间：</td>
    <td id="Submittime"  align="left" ></td>
    <td align="right" >游戏项目：</td>
    <td align="left" id="xm"></td>
  </tr>
  <tr>
    <td></td>
    <td></td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
 </tr>
  <tr>
    <td colspan="4" align="center" style="height:50px">
<input type="button" id="AcceptBtn" onclick="acceptBtn()" class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'"  value="接受" />
<input type="button" id="RefuseBtn" onclick="refuseBtn()" class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'"  value="拒绝" />
<input type="button" id="EscBtn" onclick="escBtn()" class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="取消" />
	
	</td>
  </tr>
</table>
</div>
<div class="new_trfoot"></div>
</div>

     <div id="addfsdiv" title="自动添加返水" class="new_tr undis">
<div align="center">
<table width="100%"  border="0" cellpadding="1" cellspacing="1" id="Table1">
  <tr style="height:25px;">
    <td align="right" >游戏项目：</td>
    <td id="Td1" align="left" ><select id="gametype"><option value="4">太阳城游戏</option><option value="14">太阳城游戏</option></select></td>
  </tr>
  <tr style="height:25px;">
    <td align="right" >有效投注起始时间：</td>
    <td id="Td3"  align="left" >
        <input type="text" id="txtdate1" onblur="IsNullByInfo(this,'err2','必填');" class="input_out"/>
        <input type="text" id="txttime1" onblur="IsNullByInfo(this,'err2','必填');" class="input_out w_60"/><span id="err2" style="color:Red"></span>
    </td>
  </tr>
    <tr style="height:25px;">
    <td align="right" >有效投注结束时间：</td>
    <td id="Td5"  align="left">
        <input type="text" id="txtdate2" onblur="IsNullByInfo(this,'err3','必填');" class="input_out"/>
        <input type="text" id="txttime2" onblur="IsNullByInfo(this,'err3','必填');" class="input_out w_60"/><span id="err3" style="color:Red"></span>
    </td>
  </tr>
    <tr style="height:25px;">
    <td align="right" >返水比率：</td>
    <td id="Td7"  align="left" >
        <input type="text" id="txtbl" onblur="IsElJudge(this,'err5','decimal','必填','错误',20);" class="input_out w_30"/>%<span id="err5" style="color:Red"></span>
    </td>
  </tr>
      <tr>
    <td align="right" >备注：</td>
    <td id="Td2"  align="left" >
    <textarea id="txtmark" cols="30" rows="5"></textarea>
    </td>
  </tr>
  <tr>
    <td></td>
    <td></td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
 </tr>
  <tr>
    <td colspan="4" align="center" style="height:50px">
<input type="button" id="Button1" class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'"  value="添加返水" />
<input type="button" id="Button3" class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="取消" />
	
	</td>
  </tr>
</table>
</div>
<div class="new_trfoot"></div>
</div>


    <table class="tab2" id="tab1" width="100%" border="0" cellpadding="0" cellspacing="0">
    <thead>
    <tr>
    <th>序号</th>
    <th>会员帐号</th>
    <th>有效投注额</th>
    <th>计算比率</th>
    <th>返水金额</th>
     <th>有效开始时间</th>
     <th>有效结束时间</th>
     <th>申请时间</th>
     <th>游戏项目</th>
     <th>备注</th>
     <th>审核</th>
    </tr>
    </thead>
    <tbody id="showInfo">
    </tbody>
    </table>
    </form>
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
<div id="refuseDepoist" title="拒绝存款">
<div class="showdiv">
<ul>
<li><p><span id="refuseReason">拒绝原因</span>：</p><p><select id="reason"></select>
<%--<textarea id="reason" rows="4" cols="25" class="input"></textarea>--%>
</p></li>
<li><div align="center" class="mtop_30"><br />
    <input type="button" id="submitBtn" class="btn_02" value="提交" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="cancelBtn" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></div></li>
</ul>
</div></div>
</body>
</html>
