<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManager.aspx.cs" Inherits="admin.User.UserManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/pagination.css" rel="stylesheet" type="text/css" />
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
        var per_page_number = 30;    //每页显示记录数
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

            LoadData("0");
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
                    LoadData("0");
                });
            });
            lang = setLang;
            GetLevel("cn");
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
                        jQuery("#userlevel").val(result[i].UserLevel);
                        jQuery("#txtmark").val(result[i].mark);
                    });
                }
                else {

                }
            });

            jQuery("#edit").dialog({ modal: true,width:500 });

            jQuery("#button2").unbind("click");
            jQuery("#button2").bind("click", function () {
                jQuery("#edit").dialog("close");
                var url = "/ServicesFile/UserService.asmx/UpdateUser22";
                var data = "level:'" + $("#userlevel").val() + "',txtname:'" + jQuery("#txtname2").val() + "',txtquestion:'" + jQuery("#txtquestion").val() + "',txtanswer:'" + jQuery("#txtanswer").val() + "',txtnicheng:'" + jQuery("#txtnicheng").val() + "',txtemail:'" + $("#txtemail").val() + "',txttel:'" + $("#txttel").val() + "',txtpost:'" + $("#txtpost").val() + "',txtstatus:" + $("#txtstatus").val() + ",txtmark:'" + $("#txtmark").val() + "',ID:" + currId;
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
            jQuery("#cpwd").dialog({ modal: true,width: 333});

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
                var url = "/ServicesFile/UserService.asmx/UpdateUser5";
                // debugger
                var data = "UserName:'" + jQuery("#cnsusername").val() + "',Wincoins:'" + jQuery("#cnsamount").val() + "',WincoinInfo:'" + jQuery("#cnsinfo").val() + "'";
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
                jQuery("#cnsupdate").dialog("close");
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
                $("#txtusername").val("");

                $("#txtName").val("");
                $("#txtBank").val("");
                $("#txtProvince").val("");
                $("#txtCity").val("");

                $("#txtCardNo").val("");
                $("#txtBranch").val("");
                jQuery("#bankInfo").dialog("close");
            

            });
            jQuery("#Bank_submit_no").bind("click", function () {
                $("#txtusername").val("");

                $("#txtName").val("");
                $("#txtBank").val("");
                $("#txtProvince").val("");
                $("#txtCity").val("");

                $("#txtCardNo").val("");
                $("#txtBranch").val("");
                jQuery("#bankInfo").dialog("close");
            });

        }
        var levelArr = new Array();
        function GetLevel(lan) {
            var url = "/ServicesFile/webBasicInfo/Statistics/StatisticsService.asmx/getGrade";
            var data = "language:'" + lan + "'";
            jQuery.AjaxCommon(url, data, true, false, function (json) {
                var result = $.parseJSON(json.d);
                var html = "";
                $.each(result, function (i) {
                    levelArr[result[i].a] = result[i].b;
                    html += "<option value='" + result[i].a + "'>" + result[i].b + "</option>";
                });
                $("#userlevel").html(html);
            });
        }
        function LoadData(pages) {
            var url = "/ServicesFile/UserService.asmx/GetUserByWherePage2";
            var data = "perPageNum:" + per_page_number + ",page:" + pages + ",name:'" + $("#txtname").val() + "',userName:'" + $("#userName").val() + "',status:'" + jQuery("#status").val() + "',regTime1:'" + jQuery("#regTime1").val() + "',regTime2:'" + jQuery("#regTime2").val() + "',loginTime1:'" + jQuery("#loginTime1").val() + "',loginTime2:'" + jQuery("#loginTime2").val() + "',agent:'" + jQuery("#agent").val() + "',ip:'" + jQuery("#ip").val() + "',tel:'" + $("#tel").val() + "',email:'" + $("#email").val() + "'";
            var htm = "";
            jQuery.AjaxCommon(url, data, false, false, function (json) {

                var resultAll = jQuery.parseJSON(json.d);
                var result = resultAll.text[0];
                var recordNum = resultAll.count[0].recordNum;
                $("#Pagination").pagination(recordNum, {
                    num_edge_entries: 2,
                    num_display_entries: 8,
                    current_page: pages,
                    items_per_page: per_page_number,
                    callback: LoadData
                });

                //var result = jQuery.parseJSON(json.d);
                jQuery.each(result, function (i, n) {

                    htm += "<tr height=\"30px\">";
                  
                    htm += "<td><a href='javascript:void(0)'  style='text-decoration: none;color: blue' onclick=\"window.open('/Statistics/UserAnalysis.aspx?u=" + n.UserName + "','','width='+(window.screen.availWidth-10)+',height='+(window.screen.availHeight-30)+ ',top=0,left=0,resizable=yes,status=yes,menubar=no,scrollbars=yes');\">" + n.UserName + "</a><input type='hidden' id='uid' value='" + n.ID + "'></td>";
                    htm += "<td>" + n.Name + "</td>";
//                    htm += "<td>" + n.nicheng + "</td>";
                    htm += "<td class='red'>" + n.Balance + "</td>";
//                    htm += "<td class='red'>" + n.Wincoins + "</td>";
                    htm += "<td>" + (n.status == "1" ? "启用" : "<span style='color:red'>禁用</span>") + "</td>";
                    //htm += "<td><font color=red>" + n.fstatus + "</font></td>";
                    htm += "<td>" + n.Answer + "</td>";
                    //                            htm += "<td>" + n.soucunsj + "</td>";  
                    htm += "<td>" + n.RegistrationTime + "</td>";
                    //htm += "<td><a target='_blank' href='/Statistics/IP.aspx?ip2=" + n.regip + "' style='color:blue'>" + n.regip + "</a></td>";
                    htm += "<td><a href='javascript:void(0)' onclick=\"window.open('/Statistics/IP.aspx?ip2=" + n.regip + "','','width=720,height=550');\" style='color:blue'>" + n.regip + "</a></td>";

                    htm += "<td>" + n.Post + "</td>";



                    htm += "<td>" + n.LastLoginTime + "</td>";
                    //htm += "<td><a target='_blank' href='/Statistics/IP.aspx?u=" + n.UserName + "' style='color:blue'>" + n.LastLoginIP + "</a>&nbsp;<a target='_blank' href='/Statistics/IP.aspx?ip1=" + n.LastLoginIP + "' style='color:blue'>同IP</a></td>";

                    htm += "<td>" + n.agent + "</td>";
                    //htm += "<td>" + (n.UserLevel == "15" ? "普通会员" : (n.UserLevel == "12" ? "黄金VIP" : "铂金VIP")) + "</td>";
                    htm += "<td>" + levelArr[n.UserLevel] + "</td>";
                    //                            htm += "<td>" + n.cunkuanfs + "</td>";
                    htm += "<td>" + n.email + "</td>";
                    htm += "<td>" + n.tel + "</td>";
                    htm += "<td>" + n.TCpassword + "</td>";
                    htm += "<td  height=\"30px\" width=\"245px\" >";
                    htm += "<a style='color:#0075a9; ' href=\"javascript:void(0)\" onclick=\"window.open('/bank/AddFanshui.aspx?u=" + n.UserName + "','','width=600,height=520');\" id=p\"" + n.ID + "\" class=\"edit_01\" >返水</a>";
                    htm += "<a style='color:#0075a9' href=\"javascript:void(0)\" onclick=\"window.open('/bank/addli.aspx?u=" + n.UserName + "','','width=880,height=345');\" id=p\"" + n.ID + "\" class=\"edit_01\" >红利</a>";
                    htm += "<a style='color:#0075a9' href=\"javascript:void(0)\" onclick=\"cpwd(this)\" id=p\"" + n.ID + "\" class=\"edit_01\" >密码</a>";
                    htm += "<a style='color:#0075a9;' href=\"javascript:void(0)\" onclick=\"edit(this)\" id=m\"" + n.ID + "\" class=\"edit_01\" >修改</a>";
                    //                    htm += "<a style='color:#0075a9' href=\"javascript:void(0)\" onclick=\"cnsupdate(this)\"  id=m\"" + n.ID + "\" class=\"edit_01\" >赢币</a>";
//                    htm += "<a style='color:#0075a9' href=\"javascript:void(0)\" onclick=\"bankInfo(this)\"  id='" + n.UserName + "'   class=\"edit_01\">银行</a>";
                    htm += "<a style='color:#0075a9' href=\"javascript:void(0)\" onclick=\"window.open('/User/UserInfo.aspx?u=" + n.UserName + "','','width=605,height=275');\"   class=\"edit_01\">详细</a>";
                    htm += "</td>";
                    htm += "</tr>";
                });
                jQuery("#tab").html(htm);
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
<th width="*" class="tab_top_m"><p id="zhgl">会员中心</p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody  style=" vertical-align:top; margin-top:-1px">
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main" >
<!--主题部分开始=========================================================================================-->
<div class="top_banner"  >

<div class="f1" >
&nbsp;&nbsp;<span id="H1218">会员号</span>：<input type="text" name="userName" id="userName" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'"  style=" width:90px"/>

<select id="status">
    <option value="">状态</option>
    <option value="1">启用</option>
    <option value="0">禁用</option>
</select>&nbsp;&nbsp;&nbsp;&nbsp;
注册时间：<input type="text" name="regTime1" id="regTime1" class="text_01 h20 w_80" />-
<input type="text" name="regTime2" id="regTime2" class="text_01 h20 w_80" />&nbsp;&nbsp;&nbsp;
登录时间：<input type="text" name="loginTime1" id="loginTime1" class="text_01 h20 w_80" />-
<input type="text" name="loginTime2" id="loginTime2" class="text_01 h20 w_80" />&nbsp;&nbsp;&nbsp;
代理：<input type="text" name="agent" id="agent" class="text_01 h20 w_100" />&nbsp;

</div>
<div class="f1 h35">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; I P：<input type="text" name="ip" id="ip" class="text_01 h20 w_100" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 姓名：<input type="text" name="tel" id="txtname" class="text_01 h20 w_100" />&nbsp;&nbsp;&nbsp;&nbsp 电话：<input type="text" name="tel" id="tel" class="text_01 h20 w_100" />&nbsp;&nbsp;&nbsp;&nbsp;
邮箱：<input type="text" name="email" id="email" class="text_01 h20 w_100" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<input id="selectbutton" type="button" class="btn_01" onmouseover="this.className='btn_01_h'" onmouseout="this.className='btn_01'" value="查找" />
<input id="cancel_btn" type="button" class="btn_01" onmouseover="this.className='btn_01_h'" onmouseout="this.className='btn_01'" value="重置" />



</div>

</div>
<div class="cl"></div>
<table id="tab3" width=1500px cellpadding=0 cellspacing="0" border=0 >
<thead> 
<tr>

<th id="zh">会员号</th>
<th id="js">姓名</th>
<%--<th id="cjsj">昵称</th>--%>
<th id="gxsj">余额</th>
<%--<th id="wcs">赢币</th>--%>
<th id="cjr">状态</th>
<%--<th id="Th1">返水状态</th>
--%><th id="Th6">邀请码</th>
<%--<th id="Th7">首存时间</th>--%>
<th id="Th2">注册时间</th>

<th id="Th3">注册IP</th>
<th id="Th5">联系QQ  </th>

<th id="Th4">最后登录时间</th>
<th id="Th8">代理</th>
<th id="Th9">会员等级</th>
<%--<th id="Th10">存款方式</th>--%>
<th id="Th11">Email</th>
<th id="Th12">Tel</th>
<th id="Th1">取款密码</th>
<th id="pwd" style=" color:Blue; font-weight:600; ">操作</th>
</tr>
</thead> 
<tbody id="tab">

</tbody> 

<tfoot>
<tr>
    <td colspan="19">
    <div id="Pagination" class="pagination">
</div>

    </td>
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

<li><p><span id="Span6">邀请码</span>：</p><input type="text" name="txtanswer" value="" class="text" id="txtanswer"/></li>
<%--<li><p><span id="Span7">昵称</span>：<input type="text" name="txtnicheng" value="" class="text" id="txtnicheng"/></li>--%>

<li><p><span id="Span9">电子邮箱</span>：</p><input type="text" name="txtemail" value="" class="text" id="txtemail"/></li>
<li><p><span id="Span10">联系电话</span>：</p><input type="text" name="txttel" value="" class="text" id="txttel"/></li>
<li><p><span id="Span11">QQ</span>：</p><input type="text" name="txtpost" value="" class="text" id="txtpost"/></li>
<li><p><span id="Span12">状态</span>：</p>
    <select id="txtstatus">
        <option value="1">启用</option>
        <option value="0">禁用</option>
    </select>
</li>
<li><p><span id="Span22">会员等级</span>：</p>
    <select id="userlevel">
    </select>
</li>
<li><p><span>备注：</span></p><textarea id="txtmark" style="height:55px; width:230px;"></textarea></li>

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



<div id="cnsupdate" title="修改赢币" >
<div class="showdiv">
<ul>
<li><p><span id="Span8">帐号</span>：<input id="cnsusername"  type="text"  class="text_01 h20 w_120"  readonly="readonly"/></p></li>
<li><span id="Span13">赢币金额</span>：<input id="cnsamount" type="text" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="IsNullByInfo(this,'passErr1',languages.H1306);" /><label id="Label1" style="color:Red"></label></li>
<li><span id="Span14">赢币备注</span>：<input id="cnsinfo" type="text" class="text_01 h20" style="  width:360px" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="PassWordCheck(this,'Password1','passErr2','','');" /><label id="Label2" style="color:Red"></label></li>
<li><div align="center" class="mtop_30">
    <input type="button" id="btnsend1" class="btn_02" value="提交" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="btnsend2" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></div></li>
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
