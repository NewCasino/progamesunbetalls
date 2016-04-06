<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="Role.aspx.cs" Inherits="admin.RoleRight.Role" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>角色管理</title>
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

            var languages = "";
            var lang;
            function SetGlobal(setLang) {

                setLang = $.SetOrGetLanguage(setLang, function () {
                    languages = language;
                    $("#deletebtn").val(languages.H1037);
                    $("#deletecancel").val(languages.H1011);
                    $(".wrnning").html(languages.H1318);
                    $(".H1319").html(languages.H1319);
                    $(".H1009").html(languages.H1009);
                    $(".H1320").html(languages.H1320);
                    $(".wrnning").html(languages.H1318);
                    $(".wrnning").html(languages.H1318);
                    $(".H1326").html(languages.H1326); 
                    $(".H1328").html(languages.H1328);
                    $(".H1070").html(languages.H1070);
                    $(".H1088").html(languages.H1088); 
                    $(".H1310").html(languages.H1310);
                    $(".H1313").html(languages.H1313); 
                    $(".H1200").html(languages.H1200);
                    $(".H1052").html(languages.H1052);
                    $(".H1319").html(languages.H1319);
                    $("#add").attr("title",languages.H1486);
                    $("#edit").attr("title",languages.H1329);
                    $("#delet").attr("title",languages.H1052);
                    $("#addBtn").val(languages.H1327);
                    $("#mdfsubmit").val(languages.H1009);
                    $("#mdfcancel").val(languages.H1011);
                    $("#AddButton").val(languages.H1315);
                    $("#AddCancel").val(languages.H1011);
                });
                lang = setLang;
            }

        function add() {
            //清空数据
            jQuery.each(jQuery("#add :text"), function (i, n) {
                jQuery(n).val("");
            });
            jQuery.each(jQuery("#add label[id*=Err]"), function (i, n) {
                jQuery(n).html("");
            });
            jQuery("#add").dialog({ modal: false });

            jQuery("#AddCancel").unbind("click");
            jQuery("#AddCancel").bind("click", function () {
                jQuery("#add").dialog("close");
            });

            jQuery("#AddButton").unbind("click");
            jQuery("#AddButton").bind("click", function () {
                //表单验证
                var checkForm = true;
                jQuery.each(jQuery(this).parent().parent().parent().find(":text[id=addroleName]"), function (i, n) {
                    jQuery(n).blur();
                });
                jQuery.each(jQuery(this).parent().parent().parent().find("label[id*=Err]"), function (i, n) {
                    if (jQuery(n).html() != "") {
                        checkForm = false;
                    }
                });
                if (!checkForm) {
                    return false;
                }

                jQuery("#add").dialog("close");
                var url = "/ServicesFile/RoleRightService/RoleRightService.asmx/InsertRole";
                var data = "roleName:'" + $("#addroleName").val() + "',remark:'" + $("#addremark").val() + "'";
                jQuery.AjaxCommon(url, data, false, false, function (json) {
                    if (json.d != "none") {
                        var result = jQuery.parseJSON(json.d);
                        jQuery.each(result, function (i) {
                            var f = jQuery("#datarow").clone(true);
                            f.find("#tdroleName").text(result[i].RoleName);

                            f.find("#tdhy").html("<a href='Manager.aspx?rid=" + result[i].Id + "' target='_blank'>"+languages.H1319+"</a>");

                            <% if(statusAc){ %>
                            //f.find("#tdstatus").text(result[i].Status == "1" ? "启用" : "禁用");
                            f.find("#tdstatus").html("<a href=\"javascript:void(0)\" onclick=\"cstatus(this)\" id='s" + result[i].Id + "'>" + (result[i].Status == "1" ? languages.H1049 : languages.H1050) + "</a>");
                            <% } %>
                            f.find("#tdremark").text(result[i].Remark);
                            f.find("#tdCreateUser").text(result[i].CreateUser);
                            f.find("#tdCreateDate").text(result[i].CreateDate);
                            f.find("#tdIP").text(result[i].IP);
                            <% if(mdfAc) { %>
                            f.find("#mdf").html("<a href=\"javascript:void(0)\" onclick=\"edit(this)\" id='m" + result[i].Id + "'>"+languages.H1009+"</a>");
                            <% } %>
                            <% if(deleteAc) { %>
                            f.find("#del").html("<a href=\"javascript:void(0)\" onclick=\"delet(this)\" id='d" + result[i].Id + "'>"+languages.H1052+"</a>");
                            <% } %>
                            <% if(sqAc) { %>
                            f.find("#sq").html("<a href=\"/RoleRight/AssignPermission/SetPermission.aspx?roleId=" + result[i].Id + "\">"+languages.H1320+"</a>");
                            <% } %>

                            f.appendTo("#tab");
                        });

                        jQuery.MsgTip({ objId: "#divTip", msg: languages.H1321 });
                    }
                    else {
                        jQuery.MsgTip({ objId: "#divTip", msg: languages.H1322 });
                    }
                });

                $("#addroleName").val("");
                $("#addremark").val("");
            });
        }

        function edit(obj) {
            $("#mdfroleName").val($(obj).parent().parent().find("#tdroleName").text());
            $("#mdfremark").val($(obj).parent().parent().find("#tdremark").text());
            //清空数据
            jQuery.each(jQuery("#edit").find("label[id*=Err]"), function (i, n) {
                jQuery(n).html("");
            });
            jQuery("#edit").dialog({ modal: false });

            jQuery("#mdfcancel").unbind("click");
            jQuery("#mdfcancel").bind("click", function () {
                jQuery("#edit").dialog("close");
            });

            jQuery("#mdfsubmit").unbind("click");
            jQuery("#mdfsubmit").bind("click", function () {
                //验证表单
                var checkform = true;
                jQuery.each(jQuery(this).parent().parent().parent().find(":text[id=mdfroleName]"), function (i, n) {
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

                jQuery("#edit").dialog("close");
                var curId = $(obj).attr("id").substr(1);
                var url = "/ServicesFile/RoleRightService/RoleRightService.asmx/UpdateRole";
                var data = "roleName:'" + $("#mdfroleName").val() + "',remark:'" + $("#mdfremark").val() + "',Id:" + curId;
                jQuery.AjaxCommon(url, data, false, false, function (json) {
                    if (json.d) {
                        $(obj).parent().parent().find("#tdroleName").text($("#mdfroleName").val());
                        $(obj).parent().parent().find("#tdremark").text($("#mdfremark").val());
                        jQuery.MsgTip({ objId: "#divTip", msg: languages.H1323 });
                    }
                    else {
                        jQuery.MsgTip({ objId: "#divTip", msg: languages.H1324 });
                    }
                });
            });
        }

        function delet(obj) {
            jQuery("#delet").dialog({ modal: false });

            jQuery("#deletecancel").unbind("click");
            jQuery("#deletecancel").bind("click", function () {
                jQuery("#delet").dialog("close");
            });

            jQuery("#deletebtn").unbind("click");
            jQuery("#deletebtn").bind("click", function () {
                jQuery("#delet").dialog("close");
                var curId = $(obj).attr("id").substr(1);
                var url = "/ServicesFile/RoleRightService/RoleRightService.asmx/DeleteRole";
                var data = "Id:" + curId;
                jQuery.AjaxCommon(url, data, false, false, function (json) {
                    if (json.d) {
                        $(obj).parent().parent().remove();
                        $.MsgTip({ objId: "#divTip", msg: languages.H1073 });
                    }
                    else {
                        $.MsgTip({ objId: "#divTip", msg: languages.H1074 });
                    }
                });
            });
        }

        function cstatus(obj) {
            var curId = $(obj).attr("id").substr(1);
            var status = $(obj).text() == languages.H1049 ? "1" : "0";
            var url = "/ServicesFile/RoleRightService/RoleRightService.asmx/ChangeStatus";
            var data = "status:'" + status + "',Id:" + curId;
            jQuery.AjaxCommon(url, data, false, false, function (json) {
                if (json.d) {
                    $(obj).text($(obj).text() == languages.H1049 ? languages.H1050 : languages.H1049);
                    $.MsgTip({ objId: "#divTip", msg: languages.H1187 });
                }
                else {
                    $.MsgTip({ objId: "#divTip", msg: languages.H1188 });
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p class="H1326">角色管理</p></th>
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



<div class="f1"><input type="button" id="addBtn" onclick="add()" class="top_add" onmouseover="this.className='top_add_h'" onmouseout="this.className='top_add'"  value="新增角色" /></div>



</div>
<% } %>
<div class="cl"></div>
<asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
    <table id="tab3" width=100% cellpadding=0 cellspacing="0" border=0 >
        <thead> 
        <tr>
        <th class="H1310">角色</th>
        <th class="H1328">会员</th>
        <% if (statusAc)
           { %>
        <th class="H1070">状态</th>
        <% } %>
        <th class="H1088">备注</th>
        <th class="H1313">创建人</th>
        <th class="H1200">创建时间</th>
        <th>IP</th>
        <% if (mdfAc)
           { %>
        <th class="H1009">修改</th>
        <% } %>
        <% if (deleteAc)
           { %>
        <th class="H1052">删除</th>
        <% } %>
        <% if (sqAc)
           { %>
        <th class="H1320">授权</th>
        <% } %>
        </tr>
        </thead> 
        <tbody id="tab">
    </HeaderTemplate>
    <ItemTemplate>
        <tr id="datarow">
        <td id="tdroleName"><%# Eval("roleName") %></td>
        <td id="tdhy"><a href="Manager.aspx?rid=<%# Eval("Id") %>" class="H1319" target="_blank">查看</a></td>
        <% if (statusAc)
           { %>
        <td id="tdstatus"><a href="javascript:void(0)" onclick="cstatus(this)" id='s<%# Eval("Id") %>' class='<%# Eval("status") %>==1? H1049 : H1050 '></a></td>
        <% } %>
        <td id="tdremark"><%# Eval("remark") %></td>
        <td id="tdCreateUser"><%# Eval("CreateUser") %></td>
        <td id="tdCreateDate"><%# Eval("CreateDate")%></td>
        <td id="tdIP"><%# Eval("IP") %></td>
        <% if (mdfAc)
           { %>
        <td id="mdf"><a href="javascript:void(0)" class="H1009" onclick="edit(this)" id='m<%# Eval("Id") %>'>修改</a></td>
        <% } %>
        <% if (deleteAc)
           { %>
        <td id="del"><a href="javascript:void(0)" class="H1052" onclick="delet(this)" id='d<%# Eval("Id") %>'>删除</a></td>
        <% } %>
        <% if (sqAc)
           { %>
        <td id="sq"><a href="/RoleRight/AssignPermission/SetPermission.aspx?roleId=<%# Eval("Id") %>" class="H1320" >授权</a></td>
        <% } %>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody> 

        <tfoot>
        <tr>
        <td colspan="10">

            &nbsp;</td>
        </tr>
        </tfoot>
        </table>
    </FooterTemplate>
</asp:Repeater>


<div class="undis">

<% if (addAc)
   { %>
<div id="add" title="增加角色" >
<div class="showdiv">
<ul>
<li><span class="H1310">角色：</span><p><input type="text" id="addroleName" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="IsNullByInfo(this,'addErr1',languages.H1306);" /> </p><label id="addErr1" style="color:Red"></label></li>
<li><span class="H1088">备注：</span><p>
    <input type="text" id="addremark" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" /> </p></li>
<li><div align="center" class="mtop_30">
    <input type="button" id="AddButton" class="btn_02" value="提交" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="AddCancel" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    </div></li>
</ul>
</div>
</div>
<% } %>

<% if (mdfAc)
   { %>
<div id="edit" title="修改角色" >
<div class="showdiv">
<ul>
<li><span class="H1310">角色：</span><p><input type="text" id="mdfroleName" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="IsNullByInfo(this,'mdfErr1',languages.H1306);" /> </p><label id="mdfErr1" style="color:Red"></label></li>
<li><span class="H1088">备注：</span><p>
    <input type="text" id="mdfremark" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" /> </p></li>
<li><div align="center" class="mtop_30">
    <input type="button" id="mdfsubmit" class="btn_02" value="修改" onblur="" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="mdfcancel" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    </div></li>
</ul>
</div>
</div>
<% } %>

<% if (deleteAc)
   { %>
<div id="delet" title="删除" >
<div class="showdiv">
<p class="wrnning">确定要删除此项吗？</p>
<div align="center" class="mtop_50">
    <input type="button" id="deletebtn" class="btn_02" value="确定" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="deletecancel" class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="取消" />
</div>

</div>
</div>
<% } %>


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
    </form>
</body>
</html>
