<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModuleOperate.aspx.cs" EnableViewState="false" Inherits="agent.RoleRight.MenuManager.ModuleOperate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>模块操作管理</title>
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
            function add() {
                jQuery("#add").dialog({ modal: false });

                jQuery("#AddCancel").unbind("click");
                jQuery("#AddCancel").bind("click", function () {
                    jQuery("#add").dialog("close");
                });

                jQuery("#AddButton").unbind("click");
                jQuery("#AddButton").bind("click", function () {
                    //验证表单
                    var checkform = true;
                    jQuery.each(jQuery(this).parent().parent().parent().find(":text"), function (i, n) {
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

                    jQuery("#add").dialog("close");
                    var url = "/ServicesFile/RoleRightService/RoleRightService.asmx/AddModuleOperate";
                    var data = "Operate_text:'" + $("#addOperate_text").val() + "',status:'1'";
                    jQuery.AjaxCommon(url, data, false, false, function (json) {
                        if (json.d != "none") {
                            var result = jQuery.parseJSON(json.d);
                            jQuery.each(result, function (i) {
                                var f = jQuery("#datarow").clone(true);
                                f.find("#tdOperate_text").text(result[i].Operate_text);

                                f.find("#tdstatus").text("启用");

                                f.appendTo("#tab");

                            });

                            jQuery.MsgTip({ objId: "#divTip", msg: "增加模块操作成功" });
                        }
                        else {
                            jQuery.MsgTip({ objId: "#divTip", msg: "增加模块操作失败" });
                        }
                    });

                    $("#addroleName").val("");
                    $("#addremark").val("");
                });
            }

            function edit(obj) {
                $("#mdfOperate_text").val($(obj).parent().parent().find("#tdOperate_text").text());
                jQuery("#edit").dialog({ modal: false });

                jQuery("#mdfcancel").unbind("click");
                jQuery("#mdfcancel").bind("click", function () {
                    jQuery("#edit").dialog("close");
                });

                jQuery("#mdfsubmit").unbind("click");
                jQuery("#mdfsubmit").bind("click", function () {
                    //验证表单
                    var checkform = true;
                    jQuery.each(jQuery(this).parent().parent().parent().find(":text"), function (i, n) {
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
                    var url = "/ServicesFile/RoleRightService/RoleRightService.asmx/UpdateModuleOperate";
                    var data = "Operate_text:'" + $("#mdfOperate_text").val() + "',OperateID:" + curId;
                    jQuery.AjaxCommon(url, data, false, false, function (json) {
                        if (json.d) {
                            $(obj).parent().parent().find("#tdOperate_text").text($("#mdfOperate_text").val());
                            jQuery.MsgTip({ objId: "#divTip", msg: "修改模块操作成功" });
                        }
                        else {
                            jQuery.MsgTip({ objId: "#divTip", msg: "修改模块操作失败" });
                        }
                    });
                });
            }

            function cstatus(obj) {
                var curId = $(obj).attr("id").substr(1);
                var url = "/ServicesFile/RoleRightService/RoleRightService.asmx/UpdateModuleOperateStatus";
                var data = "OperateID:" + curId;
                jQuery.AjaxCommon(url, data, false, false, function (json) {
                    if (json.d) {
                        $(obj).text($(obj).text() == "启用" ? "禁用" : "启用");
                        $.MsgTip({ objId: "#divTip", msg: "操作成功" });
                    }
                    else {
                        $.MsgTip({ objId: "#divTip", msg: "操作失败" });
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
<th width="*" class="tab_top_m"><p>模块操作管理</p></th>
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



<div class="f1"><input type="button" id="addBtn" onclick="add()" class="top_add" onmouseover="this.className='top_add_h'" onmouseout="this.className='top_add'"  value="新增操作" /></div>



</div>
<div class="cl"></div>
<asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
    <table id="tab3" width=100% cellpadding=0 cellspacing="0" border=0 >
        <thead> 
        <tr>
        <th>操作说明</th>
        <th>状态</th>
        <th>修改</th>
        </tr>
        </thead> 
        <tbody id="tab">
    </HeaderTemplate>
    <ItemTemplate>
        <tr id="datarow">
        <td id="tdOperate_text"><%# Eval("Operate_text") %></td>
        <td id="tdstatus"><a href="javascript:void(0)" onclick="cstatus(this)" id='s<%# Eval("OperateID") %>'><%# Eval("status").ToString()=="1"?"启用":"禁用" %></a></td>
        <td id="mdf"><a href="javascript:void(0)" onclick="edit(this)" id='m<%# Eval("OperateID") %>'>修改</a></td>
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

<div id="add" title="增加操作" >
<div class="showdiv">
<ul>
<li><span>操作说明：</span><p><input type="text" id="addOperate_text" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="IsNullByInfo(this,'addErr1','必填');" /> </p><label id="addErr1" style="color:Red"></label></li>
<li><div align="center" class="mtop_30">
    <input type="button" id="AddButton" class="btn_02" value="提交" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="AddCancel" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    </div></li>
</ul>
</div>
</div>


<div id="edit" title="修改操作" >
<div class="showdiv">
<ul>
<li><span>操作说明：</span><p><input type="text" id="mdfOperate_text" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="IsNullByInfo(this,'mdfErr1','必填');" /> </p><label id="mdfErr1" style="color:Red"></label></li>

<li><div align="center" class="mtop_30">
    <input type="button" id="mdfsubmit" class="btn_02" value="修改" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="mdfcancel" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    </div></li>
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

    </form>
</body>
</html>
