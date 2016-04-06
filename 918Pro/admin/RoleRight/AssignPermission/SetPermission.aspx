<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetPermission.aspx.cs" EnableViewState="false" Inherits="Admin.RoleRight.AssignPermission.SetPermission" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>角色权限分配</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/jQueryCommon.js"></script><script type="text/javascript">  
            jQuery(function () {
                SetGlobal("");
            });

            var languages = "";
            var lang;
            function SetGlobal(setLang) {

                setLang = $.SetOrGetLanguage(setLang, function () {
                    languages = language;
                    $(".H2011").html(languages.H2011);
                    $("#Button1").val(languages.H1037);
                    $("#Button2").val(languages.H1037);
                    $("#btn1").val(languages.H1234);
                    $("#btn2").val(languages.H1234);
                });
                lang = setLang;
            }
</script>
</head>
<body>
    <form id="form1" runat="server">
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p class="H2011">角色权限分配</p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<!--主题部分开始=========================================================================================-->
<div class="top_banner h30">



<div class="f1" align="center">
    <asp:Button ID="Button2" runat="server" CssClass="btn_01" 
        EnableViewState="True" OnClick="Button1_Click" 
        onmouseout="this.className='btn_01'" onmouseover="this.className='btn_01_h'" 
        Text="确定" />
    <input type="button" runat="server" id="btn1" class="btn_01 w_120" onclick="window.location='/RoleRight/Role.aspx'" onmouseover="this.className='btn_01_h'" onmouseout="this.className='btn_01'" value="返回" /></div>



</div>
<div class="cl"></div>
<asp:Literal ID="Literal2" runat="server" EnableViewState="False"></asp:Literal>

<!--主题部分结束=========================================================================================-->
</div>
</td>
<td class="tab_middle_r"></td>
</tr>
</tbody>

<tfoot>
<tr class="h35">
<td width="12" class="tab_foot_l"></td>
<td width="*" class="tab_foot_m" align="center">
<asp:Button ID="Button1" CssClass="btn_01" runat="server" onmouseover="this.className='btn_01_h'" onmouseout="this.className='btn_01'" Text="确定" OnClick="Button1_Click" EnableViewState="True" />
<input type="button" runat="server" id="btn2" class="btn_01" onclick="window.location='/RoleRight/Role.aspx'" onmouseover="this.className='btn_01_h'" onmouseout="this.className='btn_01'" value="返回" />
    </td>
<td width="16" class="tab_foot_r"></td>
</tr>
</tfoot>
</table>

    </form>
</body>
</html>
