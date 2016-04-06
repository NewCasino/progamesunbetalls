<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WincoinsManager.aspx.cs" Inherits="admin.User.WincoinsManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/jQueryCommon.js"></script>
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
        .over{background-color: rgb(220, 240, 253);}

    </style>
    <script type="text/javascript">
        jQuery(function () {
            SetGlobal("");
            $("#userName").keypress(function (e) {
                var currKey = 0, e = e || event;
                currKey = e.keyCode || e.which || e.charCode;
                if (currKey == 13) {
                    jQuery("#selectbutton").click();
                }
            });

            $("#txtname").keypress(function (e) {
                var currKey = 0, e = e || event;
                currKey = e.keyCode || e.which || e.charCode;
                if (currKey == 13) {
                    jQuery("#selectbutton").click();
                }
            });

        });

        //---------多语言处理-----------
        var languages = "";
        var lang;
        function SetGlobal(setLang) {
            //debugger
            setLang = $.SetOrGetLanguage(setLang, function () {
                languages = language;


                jQuery("#regTime1").datepicker();
                jQuery("#regTime2").datepicker();
                jQuery("#loginTime1").datepicker();
                jQuery("#loginTime2").datepicker();
                $("#cancel_btn").click(function () {
                    $(":text").val("");
                });
                jQuery("#selectbutton").click(function () {
                    var url = "/ServicesFile/UserService.asmx/GetUserByWhere_win";
                    var data = "name:'" + $("#txtname").val() + "',userName:'" + $("#userName").val() + "',status:'" + jQuery("#status").val() + "',regTime1:'" + jQuery("#regTime1").val() + "',regTime2:'" + jQuery("#regTime2").val() + "',loginTime1:'" + jQuery("#loginTime1").val() + "',loginTime2:'" + jQuery("#loginTime2").val() + "',agent:'" + jQuery("#agent").val() + "',ip:'" + jQuery("#ip").val() + "',tel:'" + $("#tel").val() + "',email:'" + $("#email").val() + "',wincount:'" + $("#wincount").val() + "'";
                    var htm = "";
                    jQuery.AjaxCommon(url, data, false, false, function (json) {
                        var result = jQuery.parseJSON(json.d);
                        jQuery.each(result, function (i, n) {
                            //  debugger
                            htm += "<tr height=\"30px\">";
                            htm += "<td  height=\"30px\" width=\"125px\" >";
                            htm += "<a style='color:#0075a9' href=\"javascript:void(0)\" onclick=\"cnsupdate(this)\"  id=m\"" + n.ID + "\" class=\"edit_01\" >增赢币</a>&nbsp;";
                            htm += "<a style='color:#0075a9' href=\"javascript:void(0)\" onclick=\"Updatecns(this)\"  id=m\"" + n.ID + "\" class=\"edit_01\" >审核</a>";
                            htm += "</td>";
                            htm += "<td height=\"30px\" width=\"111px\" ><a href='javascript:void(0)'  style='text-decoration: none;color: blue' onclick=\"window.open('/Statistics/UserAnalysis.aspx?u=" + n.UserName + "','','width='+(window.screen.availWidth-10)+',height='+(window.screen.availHeight-30)+ ',top=0,left=0,resizable=yes,status=yes,menubar=no,scrollbars=yes');\">" + n.UserName + "</a><input type='hidden' id='uid' value='" + n.ID + "'></td>";
                            htm += "<td>" + n.Name + "</td>";
                            htm += "<td>" + n.nicheng + "</td>";
                            htm += "<td class='red'>" + n.Balance + "</td>";
                            htm += "<td class='red'>" + n.Wincoins + "</td>";
                            htm += "<td>" + (n.status == "1" ? "启用" : "<span style='color:red'>禁用</span>") + "</td>";
                            //htm += "<td><font color=red>" + n.fstatus + "</font></td>";
//                            htm += "<td>" + n.qkcs + "</td>";
                            //                            htm += "<td>" + n.soucunsj + "</td>";  
//                            htm += "<td>" + n.RegistrationTime + "</td>";
                            //htm += "<td><a target='_blank' href='/Statistics/IP.aspx?ip2=" + n.regip + "' style='color:blue'>" + n.regip + "</a></td>";
                            htm += "<td><a href='javascript:void(0)' onclick=\"window.open('/Statistics/IP.aspx?ip2=" + n.regip + "','','width=720,height=550');\" style='color:blue'>" + n.regip + "</a></td>";

                            htm += "<td><a href='javascript:void(0)' onclick=\"window.open('/Statistics/IP.aspx?u=" + n.UserName + "','','width=720,height=550');\" style='color:blue'>" + n.LastLoginIP + "</a>&nbsp;<a href='javascript:void(0)' onclick=\"window.open('/Statistics/IP.aspx?ip1=" + n.LastLoginIP + "','','width=720,height=550');\" style='color:blue'>同IP</a></td>";



//                            htm += "<td>" + n.LastLoginTime + "</td>";
                            //htm += "<td><a target='_blank' href='/Statistics/IP.aspx?u=" + n.UserName + "' style='color:blue'>" + n.LastLoginIP + "</a>&nbsp;<a target='_blank' href='/Statistics/IP.aspx?ip1=" + n.LastLoginIP + "' style='color:blue'>同IP</a></td>";

                            htm += "<td>" + n.agent + "</td>";
                            htm += "<td>" + (n.UserLevel == "15" ? "普通会员" : (n.UserLevel == "12" ? "黄金VIP" : "铂金VIP")) + "</td>";
                            //                            htm += "<td>" + n.cunkuanfs + "</td>";
                            htm += "<td>" + n.email + "</td>";
                            htm += "<td>" + n.tel + "</td>";

                            htm += "</tr>";
                        });
                        jQuery("#tab").html(htm);
                    });
                });
            });
            lang = setLang;
            jQuery("#addbz").html(getSelectBz());
        }
        //--------多语言处理结束---------

        var bindAddRoleId = false;
        var bindMdfRoleId = false;





        function edit(obj) {
            var currId = $(obj).attr("id").substr(1);
            var url = "/ServicesFile/UserService.asmx/GetUserByID";
            var data = "ID:" + currId;
            jQuery.AjaxCommon(url, data, false, false, function (json) {
                if (json.d != "none") {
                    var result = jQuery.parseJSON(json.d);
                    jQuery.each(result, function (i, n) {

                        jQuery("#pp").html(result[i].SubCompany);
                        jQuery("#P1").html(result[i].Partner);
                        jQuery("#P2").html(result[i].GeneralAgent);
                        jQuery("#P3").html(result[i].Agent);
                        jQuery("#txtname2").val(result[i].Name);
                        jQuery("#txtquestion").val(result[i].question);
                        jQuery("#txtanswer").val(result[i].Answer);
                        jQuery("#txtnicheng").val(result[i].nicheng);
                        jQuery("#txtemail").val(result[i].Email);
                        jQuery("#txttel").val(result[i].Tel);
                        jQuery("#txtpost").val(result[i].post);
                        jQuery("#txtstatus").val(result[i].status);

                    });
                }
                else {

                }
            });

            jQuery("#edit").dialog({ modal: true, width: 500 });

            jQuery("#button2").unbind("click");
            jQuery("#button2").bind("click", function () {
                jQuery("#edit").dialog("close");
                var url = "/ServicesFile/UserService.asmx/UpdateUser2";
                var data = "txtname:'" + jQuery("#txtname2").val() + "',txtquestion:'" + jQuery("#txtquestion").val() + "',txtanswer:'" + jQuery("#txtanswer").val() + "',txtnicheng:'" + jQuery("#txtnicheng").val() + "',txtemail:'" + $("#txtemail").val() + "',txttel:'" + $("#txttel").val() + "',txtpost:'" + $("#txtpost").val() + "',txtstatus:" + $("#txtstatus").val() + ",ID:" + currId;
                jQuery.AjaxCommon(url, data, false, false, function (json) {
                    if (json.d) {
                        jQuery("#selectbutton").click();
                        //$.MsgTip({ objId: "#divTip", msg: "修改成功", delayTime: "2000" });
                        alert("修改成功");
                    }
                    else {
                        //$.MsgTip({ objId: "#divTip", msg: "修改失败", delayTime: "2000" });
                        alert("修改失败");
                    }
                });
            });

            jQuery("#mdfCancel").unbind("click");
            jQuery("#mdfCancel").bind("click", function () {
                jQuery("#edit").dialog("close");
            });
        }

        function cpwd(obj) {
            //清空数据
            jQuery.each(jQuery("#cpwd :password"), function (i, n) {
                jQuery(n).val("");
            });
            jQuery.each(jQuery("#cpwd label[id*=Err]"), function (i, n) {
                jQuery(n).html("");
            });
            jQuery("#cpwd").dialog({ modal: true, width: 333 });

            jQuery("#mdfpasswordbtn").unbind("click");
            jQuery("#mdfpasswordbtn").bind("click", function () {
                //验证表单
                var checkform = true;
                jQuery.each(jQuery(this).parent().parent().parent().find(":password"), function (i, n) {
                    jQuery(n).blur();
                });
                jQuery.each(jQuery(this).parent().parent().parent().find("label[id*=Err]"), function (i, n) {
                    if (jQuery(n).html() != "") {
                        checkform = false;
                    }
                });
                if (!checkform) {
                    return false;
                }

                jQuery("#cpwd").dialog("close");
                var currId = $(obj).attr("id").substr(1);
                var url = "/ServicesFile/UserService.asmx/UpdatePass";
                var data = "pass:'" + $("#Password1").val() + "',userName:'" + $(obj).parent().siblings("td:eq(0)").text() + "',roleId:6";
                jQuery.AjaxCommon(url, data, false, false, function (json) {
                    if (json.d) {
                        $.MsgTip({ objId: "#divTip", msg: "密码修改成功", delayTime: "2000" });
                    }
                    else {
                        $.MsgTip({ objId: "#divTip", msg: "密码修改失败", delayTime: "2000" });
                    }
                });
            });

            jQuery("#pwdManagerId").text($(obj).parent().siblings("td:eq(0)").text());
            jQuery("#passwordCancel").unbind("click");
            jQuery("#passwordCancel").bind("click", function () {
                jQuery("#cpwd").dialog("close");
            });
        }
        function getSelectBz() {
            var html = "<select id=\"txtcurrency\">";
            var url = "/ServicesFile/RateService.asmx/GetRateByLan";
            var data = "language:'" + lang + "'";
            html += "<option value=''>币种</option>";
            jQuery.AjaxCommon(url, data, false, false, function (json) {
                if (json.d != "none") {
                    var result = jQuery.parseJSON(json.d);
                    jQuery.each(result, function (i) {

                        html += "<option value=" + result[i].code + ">" + result[i].name + "</option>";

                    });
                    html += "</select>";
                }
                else {

                }
            });
            return html;
        }




        function cnsupdate(obj) {
            $("#txtwon2").val("");
            jQuery("#cnsupdate").dialog({ modal: true, width: 500 });
            var currId = $(obj).attr("id").substr(1);
            var url = "/ServicesFile/UserService.asmx/GetUserByID";
            var data = "ID:" + currId;
            jQuery.AjaxCommon(url, data, false, false, function (json) {
                if (json.d != "none") {
                    var re = jQuery.parseJSON(json.d);
                    //debugger
                    $("#cnsusername").val(re[0].UserName);
                    $("#cnsamount").val(re[0].Wincoins);
                    $("#cnsinfo").val(re[0].WincoinInfo);
                }
                else {

                }
            });
            jQuery("#btnsend1").unbind("click");
            jQuery("#btnsend1").bind("click", function () {
               
                var reg = /^-?\d+\.{0,}\d{0,}$/;
                if ($("#cnsamount").val() == "") {
                    alert("金额不能为空");
                    return false;
                }
                if (!reg.test($("#cnsamount").val())) {
                    alert("金额输入格式不对");
                    return false;
                }
                if ($("#txtwon2").val() == "") {
                    alert("金额不能为空");
                    return false;
                }
                if (!reg.test($("#txtwon2").val())) {
                    alert("金额输入格式不对");
                    return false;
                }
                var win1 = 0;  //要新增Y币
                win1 = parseFloat(jQuery("#txtwon2").val());

                var url = "/ServicesFile/UserService.asmx/AddYingb";
                // debugger
              
                var data = "yingb:'" + win1 + "',mark:'" + jQuery("#cnsinfo").val() + "',username:'" + jQuery("#cnsusername").val() + "'";
                jQuery.AjaxCommon(url, data, false, false, function (json) {
                    if (json.d) {
                        jQuery("#cnsupdate").dialog("close");
                        $.MsgTip({ objId: "#divTip", msg: "修改成功", delayTime: "2000" });
                        jQuery("#selectbutton").click();
                    }
                    else {
                        $.MsgTip({ objId: "#divTip", msg: "修改失败", delayTime: "2000" });
                        //alert("修改失败");
                    }
                });

            });
            jQuery("#btnsend2").bind("click", function () {
                $("#txtwon2").val("");
                jQuery("#cnsupdate").dialog("close");
            });

        }

        function Updatecns(obj) {
            jQuery("#Updatecns").dialog({ modal: false, width: 500 });
            var currId = $(obj).attr("id").substr(1);
            var url = "/ServicesFile/UserService.asmx/GetUserByID";
            var data = "ID:" + currId;
            jQuery.AjaxCommon(url, data, false, false, function (json) {
                if (json.d != "none") {
                    var re = jQuery.parseJSON(json.d);
                    //debugger
                    $("#txtUserName2").val(re[0].UserName);

                    $("#txtamount2").val(re[0].Balance);
                    $("#txtWincoins2").val(re[0].Wincoins);
                    $("#txtThwin").val(re[0].Wincoins);
                }
                else {

                }
            });
            jQuery("#Button1").unbind("click");
            jQuery("#Button1").bind("click", function () {

                $("#txtwon2").html("");
                var reg = /^-?\d+\.{0,}\d{0,}$/;
                if ($("#txtWincoins2").val() == "") {
                    alert("金额不能为空");
                    return false;
                }

                if ($("#txtThwin").val() == "") {
                    alert("兑换Y币金额不能为空");
                    return false;
                }
                if (!reg.test($("#txtWincoins2").val())) {
                    alert("金额输入格式不对");
                    return false;
                }
                if ($("#txtWincoinInfo2").val() == "") {
                    alert("兑换赢币备注不能为空");
                    return false;
                }
                //debugger
                var win1 = parseInt($("#txtThwin").val());  //要兑换币
                var win2 = parseInt($("#txtWincoins2").val());   //现有Y币
                var win3 = 0; //要兑换的Y币数

                if (win2 < win1) {
                    alert("兑换超过现有赢币数");
                    return false;
                }
                else {
                    win3 = win2 - win1;
                }

                var url = "/ServicesFile/UserService.asmx/UpdateUser8";
                // debugger
                var data = "UserName:'" + jQuery("#txtUserName2").val() + "',win2:" + win2 + ", win1:" + win1 + ",WincoinInfo:'" + jQuery("#txtWincoinInfo2").val() + "'";
                jQuery.AjaxCommon(url, data, false, false, function (json) {
                    if (json.d) {
                        jQuery("#Updatecns").dialog("close");
                        //$.MsgTip({ objId: "#divTip", msg: "", delayTime:"2000" });
                        jQuery("#selectbutton").click();
                        alert("审核成功，赢币已兑换成金额到用户帐户中");

                    }
                    else {
                        // $.MsgTip({ objId: "#divTip", msg: "审核失败", delayTime: "2000" });
                        alert("审核失败,兑换失败");
                    }
                });

            });
            jQuery("#Button3").bind("click", function () {
                jQuery("#Updatecns").dialog("close");
            });

        }



        function bankInfo(obj) {
            //debugger
            jQuery("#bankInfo").dialog({ modal: true, width: 500 });
            var url = "/ServicesFile/BankService/BankService.asmx/GetBankList";
            var usernames = jQuery(obj).attr("id");
            var datas = "username:'" + usernames + "'";

            jQuery.AjaxCommon(url, datas, false, false, function (json) {
                if (json.d) {
                    var result = jQuery.parseJSON(json.d);
                    $.each(result, function (i) {
                        //debugger

                        $("#txtusername").val(result[i].b);
                        // $("#txtusername").val(result[i].b).attr("readonly", "readonly");
                        $("#txtName").val(result[i].c).attr("readonly", "readonly");
                        $("#txtBank").val(result[i].e).attr("readonly", "readonly");
                        $("#txtProvince").val(result[i].f).attr("readonly", "readonly");
                        $("#txtCity").val(result[i].g).attr("readonly", "readonly");
                        //$("#txtCity").val((result[i].g).replace("@", "")).attr("readonly", "readonly");
                        $("#txtCardNo").val(result[i].d).attr("readonly", "readonly");
                        $("#txtBranch").val(result[i].h).attr("readonly", "readonly");
                    });
                }
                else {
                    $.MsgTip({ objId: "#divTip", msg: "银行卡资料", delayTime: "2000" });

                }
            });


            jQuery("#Bank_submit_no").unbind("click");
            jQuery("#Bank_submit_no").bind("click", function () {
                jQuery("#bankInfo").dialog("close");


            });
            jQuery("#Bank_submit_no").bind("click", function () {
                jQuery("#bankInfo").dialog("close");
            });

        }       
    </script>
    
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="zhgl">赢币管理</p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<!--主题部分开始=========================================================================================-->
<div class="top_banner">

<div class="f1">
&nbsp;&nbsp;<span id="H1218">会员号</span>：<input type="text" name="userName" id="userName" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'"  style=" width:60px"/>

<select id="status">
    <option value="">状态</option>
    <option value="1">启用</option>
    <option value="0">禁用</option>
</select>&nbsp;&nbsp;&nbsp;&nbsp;
注册时间：<input type="text" name="regTime1" id="regTime1" class="text_01 h20 w_60" />-
<input type="text" name="regTime2" id="regTime2" class="text_01 h20 w_60" />&nbsp;&nbsp;&nbsp;
登录时间：<input type="text" name="loginTime1" id="loginTime1" class="text_01 h20 w_60" />-
<input type="text" name="loginTime2" id="loginTime2" class="text_01 h20 w_60" />&nbsp;&nbsp;&nbsp;
代理：<input type="text" name="agent" id="agent" class="text_01 h20 w_60" />&nbsp;
赢币数量：<input type="text" name="agent" id="wincount" class="text_01 h20 w_60" /><span style=" color:Blue; font-size:11px"></span>
<input id="selectbutton" type="button" class="btn_01" onmouseover="this.className='btn_01_h'" onmouseout="this.className='btn_01'" value="查找" />
<input id="cancel_btn" type="button" class="btn_01" onmouseover="this.className='btn_01_h'" onmouseout="this.className='btn_01'" value="重置" />
</div>
<div class="f1 h35" style=" display:none">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; I P：<input type="text" name="ip" id="ip" class="text_01 h20 w_100" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 姓名：<input type="text" name="tel" id="txtname" class="text_01 h20 w_100" />&nbsp;&nbsp;&nbsp;&nbsp 电话：<input type="text" name="tel" id="tel" class="text_01 h20 w_100" />&nbsp;&nbsp;&nbsp;&nbsp;
邮箱：<input type="text" name="email" id="email" class="text_01 h20 w_100" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;




</div>

</div>
<div class="cl"></div>
<table id="tab3" width=1500px cellpadding=0 cellspacing="0" border=0 >
<thead> 
<tr>
<th id="pwd" style=" color:Blue; font-weight:600; ">操作</th>
<th id="zh">会员号</th>
<th id="js">姓名</th>
<th id="cjsj">昵称</th>
<th id="gxsj">余额</th>
<th id="wcs">赢币</th>
<th id="cjr">状态</th>
<%--<th id="Th1">返水状态</th>
%><th id="Th6">提款次数</th>--%>
<%--<th id="Th7">首存时间</th>--%>
<%--<th id="Th2">注册时间</th>--%>

<th id="Th3">注册IP</th>
<th id="Th5">最后登录IP</th>

<%--<th id="Th4">最后登录时间</th>--%>
<th id="Th8">代理</th>
<th id="Th9">会员等级</th>
<%--<th id="Th10">存款方式</th>--%>
<th id="Th11">Email</th>
<th id="Th12">Tel</th>

</tr>
</thead> 
<tbody id="tab">

</tbody> 

<tfoot>
<tr>
<td colspan="19">

    &nbsp;</td>
</tr>
</tfoot>
</table>


<div class="undis">

<div id="add" title="增加用户" >
<div class="showdiv">
<ul>
<li><p><label id="Azh">帐号</label>：</p><p><input type="text" id="addManagerId" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="checkUser(this);" /> </p><label id="addErr1" style="color:Red"></label></li>
<li><p><label id="Ajs">角色</label>：</p><p>
    <select id="addRoleId">
        <option id="addRoleIdopt"></option>
    </select> </p></li>
<li><p><label id="H1061">密码</label>：</p><p><input id="addPassWord" type="password" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="IsNullByInfo(this,'addErr2',languages.H1306);" /> </p><label id="addErr2" style="color:Red"></label></li>
<li><p><label id="Aqrmm">确认密码</label>：</p><p><input id="addPassWord1" type="password" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="PassWordCheck(this,'addPassWord','addErr3','','');" /> </p><label id="addErr3" style="color:Red"></label></li>
<li><p><label id="Azt">状态</label>：</p><p>
    <select id="addEnable">
        <option value="1">启用</option>
        <option value="0">禁用</option>
    </select> </p></li>
<li><div align="center" class="mtop_30">
    <input type="button" id="AddButton" class="btn_02" value="提交" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="addCancel" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    </div></li>
</ul>
</div>
</div>


<div id="edit" title="修改帐号" >
<div class="showdiv">
<ul>
<li><p><span id="Mzh">分公司</span>：</p><p id="pp"> </p></li>
<li><p><span id="Span1">股东</span>：</p><p id="P1"> </p></li>
<li><p><span id="Span2">总代</span>：</p><p id="P2"> </p></li>
<li><p><span id="Span3">代理</span>：</p><p id="P3"> </p></li>
<li><p><span id="Span4">姓名</span>：</p><input type="text" name="txtname" value="" class="text" id="txtname2"/></li>
<li><p><span id="Span5">安全问题</span>：
<select name="txtquestion" id="txtquestion" class="" style=" width:212px">
		<option value="我就读的第一所学校的名称？">我就读的第一所学校的名称？</option>
		<option value="我最喜欢的休闲运动是什么？">我最喜欢的休闲运动是什么？</option>
		<option value="我最欣赏的一位名人的名字？">我最欣赏的一位名人的名字？</option>
		<option value="我最喜欢的卡通人物名字？">我最喜欢的卡通人物名字？</option>
		<option value="我最喜欢的一句影视台词？">我最喜欢的一句影视台词？</option>
		<option value="我最喜欢的物品的名称？">我最喜欢的物品的名称？</option>
		<option value="我最喜欢的运动员是谁？">我最喜欢的运动员是谁？</option>
		<option value="我最喜欢的小说的名字？">我最喜欢的小说的名字？</option>
		<option value="我母亲/父亲的生日？">我母亲/父亲的生日？</option>
		<option value="我最爱的人的名字？">我最爱的人的名字？</option>
		<option value="我最喜爱的食物？">我最喜爱的食物？</option>
		<option value="我最喜欢的歌曲？">我最喜欢的歌曲？</option>
		<option value="我的座右铭是？">我的座右铭是？</option>
		<option value="我的初恋日期？">我的初恋日期？</option>
		<option value="我最爱的电影？">我最爱的电影？</option>
		<option value="您母亲的姓名是?">您母亲的姓名是?</option>
		<option value="您母亲的生日是?">您母亲的生日是?</option>
		<option value="您母亲的职业是?">您母亲的职业是?</option>
		<option value="您父亲的姓名是?">您父亲的姓名是?</option>
		<option value="您父亲的生日是?">您父亲的生日是?</option>
		<option value="您父亲的职业是?">您父亲的职业是?</option>
		<option value="您初中学校叫什么名字?">您初中学校叫什么名字?</option>
 
	</select>
</li>
<li><p><span id="Span6">问题答案</span>：</p><input type="text" name="txtanswer" value="" class="text" id="txtanswer"/></li>
<li><p><span id="Span7">昵称</span>：<input type="text" name="txtnicheng" value="" class="text" id="txtnicheng"/></li>

<li><p><span id="Span9">电子邮箱</span>：</p><input type="text" name="txtemail" value="" class="text" id="txtemail"/></li>
<li><p><span id="Span10">联系电话</span>：</p><input type="text" name="txttel" value="" class="text" id="txttel"/></li>
<li><p><span id="Span11">QQ</span>：</p><input type="text" name="txtpost" value="" class="text" id="txtpost"/></li>
<li><p><span id="Span12">状态</span>：</p>
    <select id="txtstatus">
        <option value="1">启用</option>
        <option value="0">禁用</option>
    </select>
</li>

<li><div align="center" class="mtop_30">
    <input type="button" id="button2" class="btn_02" value="提交" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="mdfCancel" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></div></li>
</ul>
</div>
</div>

<div id="cpwd" title="修改密码" >
<div class="showdiv">
<ul>
<li><p><span id="Mmm">帐号</span>：</p><p id="pwdManagerId"> </p></li>
<li><span id="xgmm">修改密码</span>：<input id="Password1" type="password" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="IsNullByInfo(this,'passErr1',languages.H1306);" /><label id="passErr1" style="color:Red"></label></li>
<li><span id="qrmm">确认密码</span>：<input id="Password2" type="password" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="PassWordCheck(this,'Password1','passErr2','','');" /><label id="passErr2" style="color:Red"></label></li>
<li><div align="center" class="mtop_30">
    <input type="button" id="mdfpasswordbtn" class="btn_02" value="提交" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="passwordCancel" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></div></li>
</ul>
</div>
</div>



<div id="cnsupdate" title="新增赢币" >
<div class="showdiv">
<ul>
<li><p><span id="Span8">帐号</span>：<input id="cnsusername"  type="text"  class="text_01 h20 w_120"  readonly="readonly"/></p></li>
<li><span id="Span13">赢币金额</span>：<input id="cnsamount" type="text" style=" background:#DDDDDD; color:Red"  readonly="readonly" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="IsNullByInfo(this,'passErr1',languages.H1306);" /><label id="Label1" style="color:Red">YB</label></li>
<li><span id="Span22">新增赢币</span>：<input id="txtwon2" type="text" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="IsNullByInfo(this,'passErr1',languages.H1306);" /><label id="Label9" style="color:Red">YB</label></li>
<li><span id="Span14">赢币备注</span>：<input id="cnsinfo" type="text" class="text_01 h20" style="  width:360px" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="PassWordCheck(this,'Password1','passErr2','','');" /><label id="Label2" style="color:Red"></label></li>
<li><div align="center" class="mtop_30">
    <input type="button" id="btnsend1" class="btn_02" value="提交" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="btnsend2" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></div></li>
</ul>

</div>
</div>

<div id="Updatecns" title="审核赢币到帐" >
<div class="showdiv">
<ul >
<li style="display:inline-block;float:left">会员帐号 &nbsp;&nbsp;&nbsp;:<input type="text" style=" background-color:#E6E6E6"  id="txtUserName2"   readonly="readonly" /></li>
<li style="display:inline-block; float:left">帐户金额 &nbsp;&nbsp;&nbsp;:<input type="text"  style=" background-color:#E6E6E6;color:Red"  id="txtamount2"   readonly="readonly"/><label id="Label10" style="color:Blue">RMB</label></li>
<li style=" display:inline-block; float:left">赢 币 数 &nbsp;&nbsp;&nbsp;:<input type="text"  style=" background-color:#E6E6E6;color:Red"   id="txtWincoins2"  readonly="readonly"/><label id="Label11" style="color:Blue">YB</label></li>
<li style=" display:inline-block;float:left">兑换赢币数 :<input id="txtThwin" type="text"  class="text_01 h20 w_130" style="  width:125px" onmouseover="this.className='text_01_h h20 w_130'" onmouseout="this.className='text_01 h20 w_100'" onblur="IsNullByInfo(this,'passErr1',languages.H1306);" /><label id="Label13" style="color:Blue">YB</label></li>
<li ">兑换赢币备注:<input id="txtWincoinInfo2" type="text" value="赢币到帐" class="text_01 h20" style="  width:360px" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="PassWordCheck(this,'Password1','passErr2','','');" /><label id="Label12" style="color:Red"></label></li>
<li >
<div align="center" class="mtop_30">
    <input type="button" id="Button1" class="btn_02" value="提交" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="Button3" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></div></li>
</ul>

</div>
</div>





<div id="bankInfo" title="客户绑定银行信息" >
<div class="showdiv">
<ul>
<li><p><span id="Span15">帐号</span>：<input id="txtusername"  type="text"  class="text_01 h20 w_120"  readonly="readonly"/></p></li>
<li><span id="Span16">银行账号</span>：<input id="txtCardNo" type="text" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="IsNullByInfo(this,'passErr1',languages.H1306);" /><label id="Label3" style="color:Red"></label></li>
<li><span id="Span21">户名</span>：<input id="txtName" type="text" class="text_01 h20" style="  width:360px" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="PassWordCheck(this,'Password1','passErr2','','');" /><label id="Label8" style="color:Red"></label></li>
<li><span id="Span17">开户银行名称</span>：<input id="txtBank" type="text" class="text_01 h20" style="  width:360px" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="PassWordCheck(this,'Password1','passErr2','','');" /><label id="Label4" style="color:Red"></label></li>
<li><span id="Span18">开户银行省份</span>：<input id="txtProvince" type="text" class="text_01 h20" style="  width:360px" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="PassWordCheck(this,'Password1','passErr2','','');" /><label id="Label5" style="color:Red"></label></li>
<li><span id="Span19">开户银行城市</span>：<input id="txtCity" type="text" class="text_01 h20" style="  width:360px" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="PassWordCheck(this,'Password1','passErr2','','');" /><label id="Label6" style="color:Red"></label></li>
<li><span id="Span20">银行网点</span>：<input id="txtBranch" type="text" class="text_01 h20" style="  width:360px" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="PassWordCheck(this,'Password1','passErr2','','');" /><label id="Label7" style="color:Red"></label></li>


<li><div align="center" class="mtop_30">
   
    <input type="button" id="Bank_submit_no" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></div></li>
</ul>

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
<div id="loading"></div>
<div id="divTip" ></div>
<asp:hiddenfield ID="roleid" runat="server"></asp:hiddenfield>
    </form>
</body>
</html>
