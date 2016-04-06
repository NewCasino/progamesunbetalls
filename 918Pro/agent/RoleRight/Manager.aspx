<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="agent.RoleRight.Manager" %>

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
    <style type="text/css">
    .ui-effects-transfer { border: 2px dotted gray; } 
        #divTip
        {
        	left:45%;top:45%; 
        	
        	font-family:sans-serif; position:absolute; font-size:10px;padding:5px;background:#f3f3f3;color:gray;display:none;-moz-border-radius:5px;-webkit-border-radius:5px;border:1px solid #ccc
        }

    </style>
    <script type="text/javascript">
        jQuery(function () {

            SetGlobal("");

        });
        var bindAddRoleId = false;
        var bindMdfRoleId = false;

        //---------多语言处理-----------
        var languages = "";
        var lang;
        function SetGlobal(setLang) {

            setLang = $.SetOrGetLanguage(setLang, function () {
            //debugger
                languages = language;
                LoadData();

				$("#zhgl").html(languages.H1308);
				$("#addBtn").val(languages.H1309);
				$(".zh").html(languages.H1218);
				$(".js").html(languages.H1310);
				$(".cjsj").html(languages.H1311);
				$(".zt").html(languages.H1070);
				$(".pwd").html(languages.H1061);
				
				$(".xg").html(languages.H1009);
				$(".sc").html(languages.H1052);
				$("#qrmm1").html(languages.H1314);
				$("#addEnable option:eq(0)").html(languages.H1049);
				$("#addEnable option:eq(1)").html(languages.H1050);
				$("#AddButton").val(languages.H1315);
				$("#addCancel").val(languages.H1011);
				$("#edit").attr("title",languages.H1316);
				$("#button2").val(languages.H1315);
				
				$("#mdfCancel").val(languages.H1011);
				$("#cpwd").attr("title",languages.H1317);
				$("#mdfpasswordbtn").val(languages.H1315);
				$("#passwordCancel").val(languages.H1011);

				$("#delet").attr("title",languages.H1052);
				$("#qdyscm").html(languages.H1318);
				$("#deletebtn").val(languages.H1037);
				$("#deletecancel").val(languages.H1011);
                $("#add").attr("title",languages.H1309);
                $("#xgmm").html(languages.H1317);
                $("#qrmm").html(languages.H1314);

            });
            lang = setLang;
        }
        //--------多语言处理结束---------

        function LoadData() {
            var url = "/ServicesFile/UserService.asmx/GetSubAccount";
            var data = "roleID:'" + jQuery("#roleid").val() + "'";
            jQuery.AjaxCommon(url, data, true, false, function (json) {
                if (json.d != "none") {
                    var result = jQuery.parseJSON(json.d);
                    //var result = eval("(" + json.d + ")");
                    jQuery("#tab>tr:gt(0)").remove();

                    jQuery.each(result, function (i) {
                        //alert(result[i].ManagerId);
                        var f = jQuery("#datarow").clone(true);
                        f.find("#tdManagerId").text(result[i].UserName);

                        f.find("#tdRoleId").text(result[i].RoleName);

                        f.find("#tdCreateDate").text(result[i].RegistrationTime);
                        <% if(statusAc)
                        { %>
                        f.find("#tdEnable").html("<a href='javascript:void(0)' id='s" + result[i].ID + "' onclick='Cstatus(this);'>" + (result[i].Status == "1" ? languages.H1049 : languages.H1050) + "</a>");
                        <% } 
                        else {
                        %>
                        f.find("#tdEnable").html(result[i].Status == "1" ? languages.H1049 : languages.H1050);
                        <% } %>
                        <% if(passwordAc) { %>
                        f.find("#pwd").html("<a href=\"javascript:void(0)\" onclick=\"cpwd(this)\" id=p\"" + result[i].ID + "\" class=\"edit_01\" >" + languages.H1061 + "</a>");
                        <% } %>
                        <% if(mdfAc) { %>
                        f.find("#mdf").html("<a href=\"javascript:void(0)\" onclick=\"edit(this)\" id=m\"" + result[i].ID + "\" class=\"edit_01\" >" + languages.H1009 + "</a>");
                        <% } %>
                        <% if(deleteAc) { %>
                        if(result[i].UserName != "<%=CurrentManager.UserName.ToString()%>") {
                            f.find("#del").html("<a href=\"javascript:void(0)\" class=\"delet_01\" id=d\"" + result[i].ID + "\" onclick=\"delet(this)\">" + languages.H1052 + "</a>");
                        }
                        <% } %>

                        f.appendTo("#tab");

                    });
                    jQuery("#tab>tr:eq(0)").remove();
                }
                else {
                    
                }
            });

        }

        function add() {
            if (bindAddRoleId == false) {
                var url = "/ServicesFile/RoleRightService/RoleRightService.asmx/GetAgentRoleByAgentID";
                var data = "";
                jQuery.AjaxCommon(url, data, true, false, function (json) {
                    if (json.d != "none") {
                        var result = jQuery.parseJSON(json.d);
                        jQuery("#addRoleId>option:gt(0)").remove();
                        jQuery.each(result, function (i) {
                            var f = jQuery("#addRoleIdopt").clone(true);
                            f.val(result[i].Id);
                            f.html(result[i].RoleName);
                            f.appendTo("#addRoleId");

                        });
                        jQuery("#addRoleId>option:eq(0)").remove();
                        jQuery("#addRoleId>option:eq(0)").attr("selected","selected");
                        bindAddRoleId = true;
                    }
                    else {
                        
                    }
                });

                jQuery("#AddButton").unbind("click");
                jQuery("#AddButton").bind("click", function () {
                    //验证表单
                    var checkform = true;
                    jQuery.each(jQuery(this).parent().parent().parent().find(":text"), function (i, n) {
                        jQuery(n).blur();
                    });
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
                    var url = "/ServicesFile/UserService.asmx/AddAgentSubAccount";
                    var data = "UserName:'" + jQuery("#addManagerId").val() + "',Password:'" + jQuery("#addPassWord").val() + "',RoleName:'" + jQuery("#addRoleId :selected").text() + "',RoleId:" + jQuery("#addRoleId").val() + ",Status:" + jQuery("#addEnable").val();
                    jQuery.AjaxCommon(url, data, false, false, function (json) {
                        if (json.d == "ExistSubAccount") {
                            jQuery("#addErr1").text(languages.H1307);
                        }
                        else {
                            jQuery("#add").dialog("close");

                            if (json.d != "none") {
                                var result = jQuery.parseJSON(json.d);
                                jQuery.each(result, function (i) {
                                    var f = jQuery("#datarow").clone(true);
                                    f.find("#tdManagerId").text(result[i].UserName);

                                    //f.find("#tdRoleId").text(result[i].roleName);
                                    f.find("#tdRoleId").text(jQuery("#addRoleId :selected").text());

                                    f.find("#tdCreateDate").text(result[i].RegistrationTime);
                                    <% if(statusAc) { %>
                                    f.find("#tdEnable").html("<a href='javascript:void(0)' id='s" + result[i].ID + "' onclick='Cstatus(this);'>" + (result[i].Status == "1" ? languages.H1049 : languages.H1050) + "</a>");
                                    <% } else { %>
                                    f.find("#tdEnable").html(result[i].Status == "1" ? languages.H1049 : languages.H1050);
                                    <% } %>
                                    <% if(passwordAc) { %>
                                    f.find("#pwd").html("<a href=\"javascript:void(0)\" onclick=\"cpwd(this)\" id=p\"" + result[i].ID + "\" class=\"edit_01\" >" + languages.H1061 + "</a>");
                                    <% } %>
                                    <% if(mdfAc) { %>
                                    f.find("#mdf").html("<a href=\"javascript:void(0)\" onclick=\"edit(this)\" id=m\"" + result[i].ID + "\" class=\"edit_01\" >" + languages.H1009 + "</a>");
                                    <% } %>
                                    <% if(deleteAc) { %>
                                    f.find("#del").html("<a href=\"javascript:void(0)\" class=\"delet_01\" id=d\"" + result[i].ID + "\" onclick=\"delet(this)\">" + languages.H1052 + "</a>");
                                    <% } %>

                                    f.appendTo("#tab");
                                });
                                //tip("#divTip", "增加成功");
                                $.MsgTip({ objId: "#divTip", msg: languages.H1300, delayTime: "1000" });
                            }
                            else {
                                //tip("#divTip", "增加失败");
                                $.MsgTip({ objId: "#divTip", msg: languages.H1301, delayTime: "1000" });
                            }
                        }
                    }, "#loading");

                });

                jQuery("#addCancel").unbind("click");
                jQuery("#addCancel").bind("click", function () {
                    jQuery("#add").dialog("close");
                });

            }

            //清空数据
            jQuery.each(jQuery("#add :text"), function (i, n) {
                jQuery(n).val("");
            });
            jQuery.each(jQuery("#add :password"), function (i, n) {
                jQuery(n).val("");
            });
            jQuery.each(jQuery("#add label[id*=Err]"), function (i, n) {
                jQuery(n).html("");
            });

            jQuery("#add").dialog({ modal: false,width:333 });
        }
        

        function edit(obj) {
            if (bindMdfRoleId == false) {
                var url = "/ServicesFile/RoleRightService/RoleRightService.asmx/GetAgentRoleByAgentID";
                var data = "";
                jQuery.AjaxCommon(url, data, true, false, function (json) {
                    if (json.d != "none") {
                        var n = 0;
                        var result = jQuery.parseJSON(json.d);
                        jQuery("#mdfRoleId>option:gt(0)").remove();
                        jQuery.each(result, function (i) {
                            var f = jQuery("#mdfRoleIdopt").clone(true);
                            f.val(result[i].Id);
                            f.html(result[i].RoleName);
                            if (result[i].RoleName == $(obj).parent().siblings("td:eq(1)").text()) {
                                n = i;
                            }
                            f.appendTo("#mdfRoleId");

                        });
                        jQuery("#mdfRoleId>option:eq(0)").remove();
                        jQuery("#mdfRoleId>option:eq(" + n + ")").attr("selected","selected");
                        bindMdfRoleId = true;
                    }
                    else {

                    }
                });
            }
            jQuery("#mdfManagerId").text($(obj).parent().siblings("td:eq(0)").text());
            jQuery("#mdfRoleId").children().each(function () {
                if($(this).text()==$(obj).parent().siblings("td:eq(1)").text()){
                    $(this).attr("selected", "true");
                }
            });
            jQuery("#edit").dialog({ modal: false });

            jQuery("#button2").unbind("click");
            jQuery("#button2").bind("click", function () {
                jQuery("#edit").dialog("close");
                var currId = $(obj).attr("id").substr(1);
                var url = "/ServicesFile/UserService.asmx/UpdateAgentSubAccount";
                var data = "RoleName:'" + jQuery("#mdfRoleId :selected").text() + "',RoleId:" + jQuery("#mdfRoleId").val() + ",userName:'" + jQuery(obj).parent().parent().find("#tdManagerId").html() + "'";
                jQuery.AjaxCommon(url, data, false, false, function (json) {
                    if (json.d) {
                        $(obj).parent().siblings("td:eq(1)").text($("#mdfRoleId").find("option:selected").text());
                        $.MsgTip({ objId: "#divTip", msg: languages.H1302, delayTime: "2000" });
                    }
                    else {
                        $.MsgTip({ objId: "#divTip", msg: languages.H1303, delayTime: "2000" });
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
            jQuery("#cpwd").dialog({ modal: false,width: 333});

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
                var url = "/ServicesFile/UserService.asmx/UpdateAgentSubAccountPassword";
                var data = "pass:'" + $("#Password1").val() + "',userName:'" + jQuery(obj).parent().parent().find("#tdManagerId").html() + "'";
                jQuery.AjaxCommon(url, data, false, false, function (json) {
                    if (json.d) {
                        $.MsgTip({ objId: "#divTip", msg: languages.H1304, delayTime: "2000" });
                    }
                    else {
                        $.MsgTip({ objId: "#divTip", msg: languages.H1305, delayTime: "2000" });
                    }
                });
            });

            jQuery("#passwordCancel").unbind("click");
            jQuery("#passwordCancel").bind("click", function () {
                jQuery("#cpwd").dialog("close");
            });
        }

        function Cstatus(obj) {
            
            var currId = $(obj).attr("id").substr(1);
            var enabletxt = $(obj).text() == languages.H1049 ? "1" : "0";
            var url = "/ServicesFile/UserService.asmx/UpdateAgentStatus";
            var data = "userName:'" + jQuery(obj).parent().parent().find("#tdManagerId").html() + "',status:" + enabletxt;
            jQuery.AjaxCommon(url, data, false, false, function (json) {
                if (json.d) {
                    $(obj).text($(obj).text() == languages.H1049 ? languages.H1050 : languages.H1049);
                    //tip("#divTip", "操作成功");
                    $.MsgTip({objId:"#divTip",msg:languages.H1187,delayTime:"1000"});
                }
                else {
                    //tip("#divTip", "操作失败");
                    $.MsgTip({ objId: "#divTip", msg: languages.H1188, delayTime: "1000" });
                }
            });
        }

        function delet(obj) {

            jQuery("#delet").dialog({ modal: false
                //,close:function(){
                //var position= jQuery("#delet").position();
                //alert (jQuery("#delet").css("left"));
                //alert(position.top);

                // }

            });

            jQuery("#deletecancel").unbind("click");
            jQuery("#deletecancel").bind("click", function () {
                jQuery("#delet").dialog("close");
            });

            jQuery("#deletebtn").unbind("click");
            jQuery("#deletebtn").bind("click", function () {
                jQuery("#delet").dialog("close");
                var currId = $(obj).attr("id").substr(1);
                var url = "/ServicesFile/UserService.asmx/DeleteAgentSubAccount";
                var data = "ID:" + currId;
                jQuery.AjaxCommon(url, data, false, false, function (json) {
                    if (json.d) {
                        $(obj).parent().parent().remove();
                    }
                    else {
                        $.MsgTip({ objId: "#divTip", msg: languages.H1186 });
                    }
                });

            });
        }

        function callback() {


        };

        function edit_name() {
            document.getElementById("name").disabled = ""

        }

        function checkUser(obj) {
            var bb = IsNullByInfo(obj, "addErr1", languages.H1306);
            if (bb) {
                var url = "/ServicesFile/AgentService.asmx/IsExistSubAccount";
                var data = "userName:'" + jQuery(obj).val() + "'";
                jQuery.AjaxCommon(url, data, true, true, function (json) {
                    if (json.d) {
                        jQuery("#addErr1").html(languages.H1307);
                    }
                    else {
                        jQuery("#addErr1").html();
                    }
                });
            }
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
<th width="*" class="tab_top_m"><p id="zhgl">帐号管理</p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<!--主题部分开始=========================================================================================-->
<% if (addAc)
   { %>
<div class="top_banner h30">



<div class="f1"><input type="button" id="addBtn" onclick="add()" class="top_add" onmouseover="this.className='top_add_h'" onmouseout="this.className='top_add'"  value="增加用户" /></div>



</div>
<% } %>
<div class="cl"></div>
<table id="tab3" width=100% cellpadding=0 cellspacing="0" border=0 >
<thead> 
<tr>
<th class="zh">管理人员</th>
<th class="js">角色</th>
<th class="cjsj">创建日期</th>
<th class="zt">状态</th>
<% if (passwordAc)
   { %>
<th class="pwd">密码</th>
<% } %>
<% if (mdfAc)
   { %>
<th class="xg">修改</th>
<% } %>
<% if (deleteAc)
   { %>
<th class="sc">删除</th>
<% } %>
</tr>
</thead> 
<tbody id="tab">
<tr id="datarow">
<td id="tdManagerId"></td>
<td id="tdRoleId"></td>
<td id="tdCreateDate"></td>
<td id="tdEnable"></td>
<% if (passwordAc)
   { %>
<td id="pwd"></td>
<% } %>
<% if (mdfAc)
   { %>
<td id="mdf"></td>
<% } %>
<% if (deleteAc)
   { %>
<td id="del"></td>
<% } %>
</tr>
</tbody> 

<tfoot>
<tr>
<td colspan="10">

    &nbsp;</td>
</tr>
</tfoot>
</table>


<div class="undis">

<div id="add" title="增加用户" >
<div class="showdiv">
<ul>
<li><span class="zh">管理帐号：</span><p><input type="text" id="addManagerId" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="checkUser(this);" /> </p><label id="addErr1" style="color:Red"></label></li>
<li><span class="js">角色：</span><p>
    <select id="addRoleId">
        <option id="addRoleIdopt"></option>
    </select> </p></li>
<li><span class="pwd">密码：</span><p><input id="addPassWord" type="password" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="IsNullByInfo(this,'addErr2',languages.H1306);" /> </p><label id="addErr2" style="color:Red"></label></li>
<li><span id="qrmm1">确认密码：</span><p><input id="addPassWord1" type="password" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="PassWordCheck(this,'addPassWord','addErr3','','');" /> </p><label id="addErr3" style="color:Red"></label></li>
<li><span class="zt">状态：</span><p>
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
<li><span class="zh">管理帐号：</span><p id="mdfManagerId"> </p></li>
<li><span class="js">角色：</span><p>
    <select id="mdfRoleId">
        <option id="mdfRoleIdopt"></option>
    </select> </p></li>
<li><div align="center" class="mtop_30">
    <input type="button" id="button2" class="btn_02" value="提交" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="mdfCancel" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></div></li>
</ul>
</div>
</div>

<div id="cpwd" title="修改密码" >
<div class="showdiv">
<ul>
<li><span id="xgmm">修改密码：</span><input id="Password1" type="password" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="IsNullByInfo(this,'passErr1',languages.H1306);" /><label id="passErr1" style="color:Red"></label></li>
<li><span id="qrmm">确认密码：</span><input id="Password2" type="password" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="PassWordCheck(this,'Password1','passErr2','','');" /><label id="passErr2" style="color:Red"></label></li>
<li><div align="center" class="mtop_30">
    <input type="button" id="mdfpasswordbtn" class="btn_02" value="提交" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="passwordCancel" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></div></li>
</ul>
</div>
</div>

<div>
<table>
<tbody id="tab">
<tr id="datarow">
<td id="tdManagerId"></td>
<td id="tdRoleId"></td>
<td id="tdCreateDate"></td>
<td id="tdEnable"></td>
<% if (passwordAc)
   { %>
<td id="pwd"></td>
<% } %>
<% if (mdfAc)
   { %>
<td id="mdf"></td>
<% } %>
<% if (deleteAc)
   { %>
<td id="del"></td>
<% } %>
</tr>
</tbody> 
</table>
</div>

<div id="delet" title="删除" >
<div class="showdiv">
<p class="wrnning" id="qdyscm">确定要删除吗？</p>
<div align="center" class="mtop_50">
    <input type="button" id="deletebtn" class="btn_02" value="确定" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="deletecancel" class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="取消" />
</div>

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
