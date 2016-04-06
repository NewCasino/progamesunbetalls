<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerifyDeposit.aspx.cs" Inherits="admin.Bank.VerifyDeposit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>存款审核</title>
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
            var day = now.getDate()-1;       //日


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
         
            GetBankArr();
            SelectByWhere();
            Countdown(jQuery("#timeTxt").val()); $("#language").val(lan);
            jQuery("#time1WhereVal").datepicker();
            $('#time1WhereVal').val();
            jQuery("#time2WhereVal").datepicker();
            $('#time2WhereVal').val();

            $("#selectByWhere").click(function () {
                if ($.trim($("#memberSel").val()) != "" || $.trim($("#memberName").val()) != "" || $("#time1WhereVal").val() != "" || $("#time2WhereVal").val() != "") {
                    SelectByWhere();
                }
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
                location = "/Bank/DepositHistory.aspx";
            });
            $("#VerifyDeposit").click(function () {
                location = "/Bank/VerifyDeposit.aspx";
            });
        });
        function SelectByWhere() {
            $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/GetDepositByWhere", "userName:'" + $.trim($("#memberSel").val()) + "',lan:'" + lan + "',name:'" + $.trim($("#memberName").val()) + "',time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "'", true, false, function (json) {
                if (json.d == "-1") {
                    SysLoginOut();
                } else if (json.d != "") {
                    var re = jQuery.parseJSON(json.d);
                    var html = "", total1 = 0, istrue = "";
                    $.each(re, function (i) {
                        total1 += parseFloat(re[i].d);
                        istrue = "";
                        if (re[i].g == 2) {
                            istrue = "<a style='color:green;font-weight:800'>确定支付成功</a>";
                        } else {
                            istrue = "<a style='color:red;font-weight:400'>支付中...</a>";
                        }
                        html += "<tr><td>" + (i + 1) + "</td><td a='" + re[i].n + "' b='" + re[i].o + "' c='" + re[i].s + "' d='" + re[i].p + "' e='" + re[i].q + "' f='" + re[i].r + "'><a href='javascript:void(0)' style='color:#0075a9;' onclick=\"window.open('/Statistics/UserAnalysis.aspx?u=" + re[i].b + "','','width='+(window.screen.availWidth-10)+',height='+(window.screen.availHeight-30)+ ',top=0,left=0,resizable=yes,status=yes,menubar=no,scrollbars=yes');\">" + re[i].b + "</a></td><td>" + istrue + "</td><td>" + re[i].y + "</td><td style='color:red'>" + re[i].d + "</td><td>" + re[i].i + "</td><td>" + re[i].cardno + "<td>" + re[i].k + "</td><td>" + re[i].e + "</td><td><a class=\"verify\" href=\"#\" attr=\"" + re[i].a + "\">审核</a></td></tr>"; //存入帐号<td>" + re[i].j + "</td>
                    });
                    html += "<tr><td>总计</td><td colspan='3'></td><td style='color:red'>" + total1.toFixed(2) + "</td><td colspan='6'></td></tr>";
                    $("#tab1>tbody").html(html);
                    $("#tab1>tbody>tr").mouseover(function () {
                        $(this).siblings().removeClass("trOver").end().addClass("trOver");
                    });
                    $(".verify").unbind("click").bind("click", function () {
                        currID = $(this).attr("attr");
                        var $tr = $(this).parent().parent().find("td");
                        getUserInfo($tr.eq(1).find("a").html());
                        $("#userAccount").html($tr.eq(1).html() == "" ? "--" : $tr.eq(1).html());
                        $("#userName").html($tr.eq(2).html() == "" ? "--" : $tr.eq(2).html());
                        $("#currency").html($tr.eq(3).html() == "" ? "--" : $tr.eq(3).html());
                        $("#money").html($tr.eq(4).html() == "" ? "--" : $tr.eq(4).html());

                        $("#bank").html($tr.eq(5).html() == "" ? "--" : $tr.eq(5).html());
                        $("#nicheng").html($tr.eq(2).html() == "" ? "--" : $tr.eq(2).html());
                        //                        $("#account").html($tr.eq(6).html() == "" ? "--" : $tr.eq(6).html());
                        $("#dealID").html($tr.eq(7).html() == "" ? "--" : $tr.eq(7).html());
                        $("#name").html($tr.eq(1).attr("a") == "" ? "--" : $tr.eq(1).attr("a"));
                        $("#account").html($tr.eq(6).html() == "" ? "--" : $tr.eq(6).html());
                        $("#type").html($tr.eq(1).attr("c") == "" ? "--" : bankArr[$tr.eq(1).attr("c")]);
                        $("#province").html($tr.eq(1).attr("d") == "" ? "--" : $tr.eq(1).attr("d"));
                        $("#city").html($tr.eq(1).attr("e") == "" ? "--" : $tr.eq(1).attr("e").toString().replace("@", ""));
                        $("#branch").html($tr.eq(1).attr("f") == "" ? "--" : $tr.eq(1).attr("f"));
                        $("#bankTime").html($tr.eq(8).html() == "" ? "--" : $tr.eq(8).html());
                        //$("#bankTel").html($tr.eq(8).html() == "" ? "--" : $tr.eq(8).html());
                        var yingMax = 688;
                        //var yingb = 0;
                        var sfee = parseFloat($tr.eq(4).html()) * 0.006;
                        //yingb = sfee;
                        var sfee1 = Math.round(sfee * 100) / 100
                        var realmoney = parseFloat($tr.eq(4).html());

                        //yingb = yingb > yingMax ? yingMax : yingb;
                        if ($("#bank").html() == '汇潮支付') {
                            $("#realMoney").val(realmoney);
                            $("#txtsxf").val(sfee1);
                        } else {
                            $("#realMoney").val($tr.eq(4).html() == "" ? "--" : $tr.eq(4).html());
                            $("#txtsxf").val(0);
                        }

                        // $("#yingb").val(parseInt(yingb));
                        $("#verify_list").dialog({ modal: true, width: "730px" });
                        GetIP($tr.eq(1).find("a").html());



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
                if (confirm("您确定要接受该存款吗?")) {
                    $("#AcceptBtn").attr("disabled", true);
                   // alert($('#bank').html());

                    var CLAmount = parseFloat($.trim($("#realMoney").val()));
                    var txtsxf = $.trim($("#txtsxf").val()) == '' ? 0 : parseFloat($.trim($("#txtsxf").val()));
                    var aiffAmout = CLAmount - parseFloat(txtsxf);
                    var _rcode = $.trim($("#_rcode").html());
                    $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/VerifyBillNoticeCode", "status:'2',reason:'',id:'" + currID + "',validAmount:'" + aiffAmout + "',seef:'" + txtsxf + "',rcode:'" + _rcode + "'", true, false, function (json) {
                        if (json.d == "200") {
                            alert("该笔存款已审核，不能重复审核");
                        } else if (json.d == "201") {
                            alert("存入银行为空，拒绝该笔存款");
                        } else if (json.d != "false" && json.d != "nomoney") {
                            var re = jQuery.parseJSON(json.d);
                            alert("审核成功\n当前帐户余额：" + (parseFloat(re.a) + parseFloat(re.b)) + "\n玩家到帐金额：" + re.c + "\n公司银行实际存入金额：" + re.b + "");
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
                
                if (confirm("您确定要拒绝该存款吗?")) {
                    if ($.trim($("#reason").val()) == "") {
                        alert("拒绝理由不能为空");
                        $("#GetDepositByWhere").attr("disabled", false);
                    } else {
                        $("#submitBtn").attr("disabled", true);
                        $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/VerifyBillNotice", "status:'3',reason:'" + $("#reason").val() + "',id:'" + currID + "',validAmount:'" + $.trim($("#realMoney").val()) + "',seef:'0'", true, false, function (json) {
                            if (json.d != "false" && json.d != "nomoney") {
                                var re = jQuery.parseJSON(json.d);
                                alert("拒绝该存款成功\n该用户当前帐户余额：" + re.a + "");
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
            var data = "userName:'" + userName + "'";
            $.AjaxCommon("/ServicesFile/UserService.asmx/GetUserInfo", data, true, false, function (json) {
                if (json.d != "") {
                    var result = jQuery.parseJSON(json.d);
                    $.each(result, function (i) {
                        $("#userAccount").html(result[i].UserName);
                        
                        $("#regtime").html(result[i].RegistrationTime == "" ? "--" : result[i].RegistrationTime);
                        $("#lastlogintime").html(result[i].LastLoginTime == "" ? "--" : result[i].LastLoginTime);
                        $("#tel").html(result[i].tel == "" ? "--" : result[i].tel);
                        $("#email").html(result[i].email == "" ? "--" : result[i].email);
                        $("#_rcode").html(result[i].answer == "" ? "--" : result[i].answer);
                        $("#_qq").html(result[i].post == "" ? "--" : result[i].post);
                        

                        $("#balance").html(result[i].Balance == "" ? "--" : result[i].Balance);
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
                        html += "<option value=\"" + result[i].a +"\">" + result[i].b + "</option>";
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

        function GetIP(username) {
            $("#tduser").html("");
            $.AjaxCommon("/ServicesFile/UserService.asmx/GetIpinfo", "username:'" + username + "'", true, false, function (json) {
                // debugger
                if (json.d != "") {
                    $("#tduser").html(json.d);
                }
                else {
                    $("#tduser").html("");
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
    </script>
</head>
<body>
    <table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="zdjs">未审核存款</p></th>
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
    <span id="VerifyDeposit" class="btn_04" style=" color:Yellow; font-size:13px; font-weight:600">&nbsp;&nbsp;未审核存款&nbsp;&nbsp;</span>
    <span id="depositHistory" class="btn_04" style=" font-size:11px">&nbsp;&nbsp;已审核存款&nbsp;&nbsp;</span>&nbsp;&nbsp;
    <a id="hyzh">会员帐号</a>&nbsp;&nbsp;<input type="text" id="memberSel" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="hyxm">会员姓名</a>&nbsp;&nbsp;<input type="text" id="memberName" class="inputWhere text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="jysj">提交时间</a>&nbsp;&nbsp;<input type="text" id="time1WhereVal" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" readonly="readonly"  />－<input type="text" id="time2WhereVal" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" readonly="readonly"  />&nbsp;&nbsp;&nbsp;&nbsp;
    <%--<a id="zt">状态</a>&nbsp;&nbsp;<select id="statusSel"><option value="1">全部</option>
        <option value="2">成功</option><option value="3">拒绝</option>
    </select>&nbsp;&nbsp;&nbsp;&nbsp;--%>
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in">搜索</span></a>&nbsp;&nbsp;&nbsp;&nbsp;
    <input type="text" id="timeTxt" value="5" class="text_01 w_30" onmouseover="this.className='text_01_h w_30'" onmouseout="this.className='text_01 w_30'" /><label id="timeUp">5</label>&nbsp;&nbsp;
    </div>

     <div id="verify_list" title="存款审核" class="new_tr undis">
<div align="center">
<table width="100%"  border="0" cellpadding="1" cellspacing="1" id="addtb">
<tr align="center" style="background-color:#CDEAFC">
    <td colspan="4"><strong>会员资料</strong></td>
  </tr>
 <tr>
    <td align="right">会员帐号：</td>
    <td id="userAccount" align="left"></td>
    <td align="right">支付状态：</td>
    <td id="nicheng" align="left"></td>
  </tr>
  <tr>
    <td align="right">注册时间：</td>
    <td id="regtime" align="left"></td>
    <td align="right">最后登录时间：</td>
    <td id="lastlogintime" align="left"></td>
  </tr>
  <tr>
    <td align="right">联系电话：</td>
    <td id="tel" align="left"></td>
    <td align="right">电子邮箱：</td>
    <td id="email" align="left"></td>
    <%--<td align="right">手机号码：</td>
    <td id="mobile" align="left"></td>--%>
  </tr>
  <tr>
    <td align="right">邀请码：</td>
    <td  align="left"><span id="_rcode"></span></td>
       <td align="right">联系QQ：</td>
    <td id="_qq" align="left"></td>
  
  </tr>
  <tr align="center" style="background-color:#CDEAFC">
    <td colspan="4"><strong>存款信息</strong></td>
  </tr>
  <tr>
    <td align="right" >活动优惠：</td>
    <td id="currency" align="left" ></td>
    <td align="right" >帐户余额：</td>
    <td id="balance"  align="left" ></td>
  </tr>
  <tr>
    <td align="right" >存入金额：</td>
    <td id="money"  align="left"class="red" ></td>
    <td align="right" >实际存入金额：</td>
    <td align="left" ><input type="text"  id="realMoney" value="" class="red w_60" /></td>
  </tr>
  <tr>
    <td align="right" >存入银行：</td>
    <td id="bank" align="left" ></td>
    <td align="right" >手续费：</td>
    <td align="left" ><input type="text" id="txtsxf" value="" class="red w_60" onkeyup="value=value.replace(/[^\d\.]/g,'')"/></td>
  </tr>
    <tr>
    <td align="right" >存入帐号：</td>
    <td id="account" align="left" ></td>
    <%--<td align="right" >赠送赢币：</td>
    <td id="Td2" align="left" ><input type="text" id="yingb" value="" class="red w_60" readonly /></td>--%>
  </tr>
  <tr>
    <td align="right" >交易时间：</td>
    <td id="bankTime" align="left" ></td>
    <td align="right" >交易序号：</td>
    <td id="dealID" align="left" ></td>
  </tr>

   <tr align="center" style="background-color:#CDEAFC">
    <td colspan="4"><strong>IP信息</strong></td>
  </tr>
   <tr >
    <td align="left"  colspan="4"><span style=" color:Red">注：</span>有以下相同IP的会员：</td> 
   
  </tr>
 <tr>
  <td colspan="4" align="left" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span id="tduser" style=" text-align:left;  width:100%; font-weight:500; "></span></td>
  <%--<td align="left" colspan="4">
   <textarea cols="15" rows="2" id="tduser" style=" text-align:left; font-size:13px; width:100%; font-weight:600; color:Blue"></textarea></td>--%>
  </tr>
  <tr>
    <td></td>
    <td></td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
 </tr>
  <tr>
    <td colspan="4" align="center">
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
    <th>会员帐号</th>
    <th>支付状态</th>
    <th>活动优惠</th>
     <th>存入金额</th>
     <th>存入银行</th>
    <th>存入账号</th>
     <th>交易序号</th>
     <th>提交时间</th>
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
