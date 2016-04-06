<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeeHistory.aspx.cs" Inherits="admin.PTgame.FeeHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>太阳城转账历史</title>
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
            //GetBankArr();
            var arg = GetRequest();
            if (arg != undefined) {
                var typ = arg["type"];
                if (typ != undefined) {
                    $("#type").val(typ);
                }
            }
            Countdown(jQuery("#timeTxt").val()); $("#language").val(lan);
            jQuery("#time1WhereVal").datepicker();
            $('#time1WhereVal').val(SetTime(0));
            jQuery("#time2WhereVal").datepicker();
            $('#time2WhereVal').val(SetTime(0));

            SelectByWhere();

            $("#selectByWhere").click(function () {
                SelectByWhere();
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
                window.history.go(-1);
            });
            $("#VerifyDeposit").click(function () {
                location = "/Bank/HongLi.aspx";
            });
        });
        function SelectByWhere() {
            $.AjaxCommon("/ServicesFile/UserService.asmx/GetPTbillnoticehistory", "username:'" + $.trim($("#memberSel").val()) + "',type:'" + $("#type").val() + "',time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "',status:'" + $("#status").val() + "'", true, false, function (json) {
                if (json.d != "" && json.d != "]") {
                    var re = jQuery.parseJSON(json.d);
                    var html = "", total1 = 0;
                    $.each(re, function (i) {
                        total1 += parseFloat(re[i].Amount);
                        html += "<tr><td>" + (i + 1) + "</td><td>" + (re[i].Type == "12" ? "总账转太阳城" : "太阳城转总账") + "</td><td><a href='javascript:void(0)'  style='text-decoration: none;color: blue' onclick=\"window.open('/Statistics/UserAnalysis.aspx?u=" + re[i].UserName + "','','width='+(window.screen.availWidth-10)+',height='+(window.screen.availHeight-30)+ ',top=0,left=0,resizable=yes,status=yes,menubar=no,scrollbars=yes');\">" + re[i].UserName + "</a></td><td class='red'>" + re[i].Amount + "</td><td>" + (re[i].Status == "2" ? "已审核" : (re[i].Status == "3" ? "拒绝" : "未处理")) + "</td><td>" + re[i].SubmitTime + "</td><td>" + re[i].UpdateTime + "</td></tr>"; //存入帐号<td>" + re[i].j + "</td>
                    });
                    html += "<tr><td>总计</td><td colspan='2'></td><td>" + total1.toFixed(2) + "</td><td colspan='6'></td></tr>";
                    $("#tab1>tbody").html(html);
                    $("#tab1>tbody>tr").mouseover(function () {
                        $(this).siblings().removeClass("trOver").end().addClass("trOver");
                    });
                    $(".verify").unbind("click").bind("click", function () {
                        currID = $(this).attr("attr");
                        var $tr = $(this).parent().parent().find("td");
                        //getUserInfo($tr.eq(1).html());
                        $("#username").html($tr.eq(1).html() == "" ? "--" : ("" + $tr.eq(1).html() + ""));
                        $("#balance").html($tr.eq(2).html() == "" ? "--" : $tr.eq(2).html());
                        $("#htime").html($tr.eq(3).html() == "" ? "--" : $tr.eq(3).html());

                        $("#verify_list").dialog({ modal: true, width: "530px" });
                    });
                } else if (json.d == "-1") {
                    SysLoginOut();
                } else {
                    $("#tab1>tbody").html("<tr><td colspan=\"10\">没有相应数据</td></tr>");
                }
            });
        }
        function acceptBtn() {
            if (confirm("确定太阳城游戏平台密码修改？")) {
                $("#AcceptBtn").attr("disabled", true);
                $.AjaxCommon("/ServicesFile/userservice.asmx/UpdatePtthing", "status:'1',ID:" + currID + "", true, false, function (json) {
                    if (json.d == "1") {
                        var re = jQuery.parseJSON(json.d);
                        //alert("审核成功\n当前帐户余额：" + (parseFloat(re.a) + parseFloat(re.b)) + "\n本次红利金额：" + re.c + "\n实际存入金额：" + re.b + "");
                        alert("操作成功!");
                        $("#verify_list").dialog("close");
                        SelectByWhere();
                    } else if (json.d == "0") {
                        alert("操作失败");
                    } else {
                        SysLoginOut();
                    }
                    $("#AcceptBtn").attr("disabled", false);
                });
            }
        }
        function refuseBtn() {
            $("#refuseDepoist").dialog({ modal: false, resizable: false });
            $("#submitBtn").unbind("click").bind("click", function () {
                $("#submitBtn").attr("disabled", true);
                $.AjaxCommon("/ServicesFile/userservice.asmx/UpdatePtthing", "status:'2',ID:" + currID + "", true, false, function (json) {
                    if (json.d == "1") {
                        alert("操作成功");
                        $("#verify_list").dialog("close");
                        SelectByWhere();
                        $("#refuseDepoist").dialog("close");
                    } else if (json.d == "0") {
                        alert("审核失败");
                        $("#refuseDepoist").dialog("close");
                    } else {
                        SysLoginOut();
                    }
                    $("#submitBtn").attr("disabled", false);
                });
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
                    time = "20";
                }
                else {
                    var a = /^([1-9]|[1-9][0-9])&/;
                    if (!a.test($("#timeHide").val())) {
                        time = "20";
                        $("#timeHide").val("20");
                    }
                    else {
                        time = $("#timeHide").val();
                    }
                }
                SelectByWhere();
                if ($("#timeHide").val() != $("#timeTxt").val()) {
                    if (parseInt($("#timeTxt").val()) < 20) {
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
                    time = "20";
                }
                else {
                    time = $("#timeHide").val();
                }
                pd = 0;
            }
            //setTimeout("Countdown(\"" + time + "\")", 1000);
        }
        function SetTime(n) {
            var date = new Date();
            var mon = "";
            var dat = "";
            date.setDate(date.getDate() + n);
            mon = date.getMonth() + 1;
            dat = date.getDate();
            mon = mon < 10 ? ("0" + mon) : mon;
            dat = dat < 10 ? ("0" + dat) : dat;
            return (date.getYear() + "-" + mon + "-" + dat);
        }
    </script>
</head>
<body>
    <table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="zdjs">太阳城游戏平台转账历史</p></th>
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
    <div  style="width:95%;padding:3px;margin:2px;">
    <span id="depositHistory" class="btn_04">&nbsp;&nbsp;返回&nbsp;&nbsp;</span>&nbsp;&nbsp;
    <a id="hyzh">会员帐号</a>&nbsp;&nbsp;<input type="text" id="memberSel" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="jysj">申请时间</a>&nbsp;&nbsp;<input type="text" id="time1WhereVal" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" readonly="readonly"  />－<input type="text" id="time2WhereVal" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" readonly="readonly"  />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="A1">类型</a>&nbsp;&nbsp;<select id="type">
        <option value="12">总账转太阳城游戏平台</option><option value="13">太阳城游戏平台转总账</option>
    </select>&nbsp;
    <a id="zt">状态</a>&nbsp;&nbsp;<select id="status"><option value="">全部</option>
        <option value="2" selected>成功</option><option value="3">拒绝</option>
    </select>&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in">搜索</span></a>&nbsp;&nbsp;&nbsp;&nbsp;
    <div style="display:none;"><input type="text" id="timeTxt" value="20" class="text_01 w_30" onmouseover="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" /><label id="timeUp">20</label></div>&nbsp;&nbsp;
    </div>

     <div id="verify_list" title="修改密码" class="new_tr undis">
<div align="center">
<table width="100%"  border="0" cellpadding="1" cellspacing="1" id="addtb">
  <tr align="center" style="background-color:#CDEAFC">
    <td colspan="4"><strong>修改密码</strong></td>
  </tr>
  <tr>
    <td align="right" >会员账号：</td>
    <td id="username" align="left" ></td>
    <td align="right">密码：</td>
    <td id="balance"  align="left"></td>
  </tr>
  <tr>
    <td align="right" >申请时间：</td>
    <td id="htime"  align="left" ></td>
    <td align="right" ></td>
    <td align="left" ></td>
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

    <table class="tab2" id="tab1" width="100%" border="0" cellpadding="0" cellspacing="0">
    <thead>
    <tr>
    <th>序号</th>
    <th>类型</th>
    <th>会员帐号</th>
    <th>转账金额</th>
    <th>状态</th>
    <th>申请时间</th>
       <th>审核时间</th>
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
<div id="refuseDepoist" title="拒绝申请">
<div class="showdiv">
<ul>
<li><p>您确定要拒绝该申请吗？
</p></li>
<li><div align="center" class="mtop_30"><br />
    <input type="button" id="submitBtn" class="btn_02" value="确定" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="cancelBtn" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></div></li>
</ul>
</div></div>
</body>
</html>