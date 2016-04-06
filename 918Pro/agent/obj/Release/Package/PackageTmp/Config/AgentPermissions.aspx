<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentPermissions.aspx.cs" EnableViewState="false" Inherits="agent.Config.AgentPermissions" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>代理权限</title>
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
    <% if(statusAc) { %>
        function cstatus(obj) {
            var curId = $(obj).attr("id").substr(1);
            var status = $(obj).text() == "启用" ? "1" : "0";
            var url = "/ServicesFile/RoleRightService/RoleRightService.asmx/ChangeStatus";
            var data = "status:'" + status + "',Id:" + curId;
            jQuery.AjaxCommon(url, data, true, false, function (json) {
                if (json.d) {
                    $(obj).text($(obj).text() == "启用" ? "禁用" : "启用");
                    $.MsgTip({ objId: "#divTip", msg: "操作成功" });
                }
                else {
                    $.MsgTip({ objId: "#divTip", msg: "操作失败" });
                }
            });
        }
    <% } %>

    </script>
</head>
<body>
    <form id="form1" runat="server">
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p>代理权限</p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<!--主题部分开始=========================================================================================-->
<div class="cl"></div>
<asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
    <table id="tab3" width=100% cellpadding=0 cellspacing="0" border=0 >
        <thead> 
        <tr>
        <th>代理</th>
        <th>状态</th>
        <th>备注</th>
        <% if (sqAc)
           { %>
        <th>授权</th>
        <% } %>
        </tr>
        </thead> 
        <tbody id="tab">
    </HeaderTemplate>
    <ItemTemplate>
        <tr id="datarow">
        <td id="tdroleName"><%# Eval("roleName") %></td>
        <% if (statusAc)
           { %>
        <td id="tdstatus"><a href="javascript:void(0)" onclick="cstatus(this)" id='s<%# Eval("Id") %>'><%# Eval("status").ToString()=="1"?"启用":"禁用" %></a></td>
        <% }
           else
           { %>
        <td id="td1"><%# Eval("status").ToString()=="1"?"启用":"禁用" %></td>
        <% } %>
        <td id="tdremark"><%# Eval("remark") %></td>
        <% if (sqAc)
           { %>
        <td id="sq"><a href="/RoleRight/AssignPermission/SetPermission.aspx?roleId=<%# Eval("Id") %>&bit=1">授权</a></td>
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
