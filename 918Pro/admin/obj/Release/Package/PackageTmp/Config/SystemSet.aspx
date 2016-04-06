<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemSet.aspx.cs" Inherits="admin.Config.SystemSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                loadData();
                
                $(".H1351").html(languages.H1351);
                $(".H1352").html(languages.H1352);
                $(".H1353").val(languages.H1353);
                $(".H1088").val(languages.H1088);
                $(".H1009").html(languages.H1009);
                $("#addBtn").val(languages.H1015);
                $(".H1015").attr("title", languages.H1015);
                $("#addButton").val(languages.H1315);
                $("#addCancel").val(languages.H1011);
                $(".H1052").attr("title", languages.H1052);
                $("#H1071").html(languages.H1071);
                $("#deletebtn").val(languages.H1037);
                $("#deletecancel").val(languages.H1011);

            });
            lang = setLang;
        }

        var Names;
        function loadData() {
            var url = "/ServicesFile/ConfigService.asmx/GetConfigAll";
            var data = "configId:'" + $("#configId").val() + "'";
            jQuery.AjaxCommon(url, data, true, false, function (json) {

                if (json.d != "none") {
                    var result = jQuery.parseJSON(json.d);
                    //var result = eval("(" + json.d + ")");
                    jQuery("#tab>tr:gt(0)").remove();

                    jQuery.each(result, function (i) {
                        var f = jQuery("#datarow").clone(true);
                        f.find("#tdotype").text(result[i].Otype);
                        f.find("#tdoval").text(result[i].Oval);
                        f.find("#tdremark").text(result[i].Remark);
                        f.find("#tdupdate").html("<a id=\"update\" style=\"cursor:hand\" onclick=\"bindClick(this,'" + result[i].ID + "')\"><img title=\"" + languages.H1009 + "\" src=\"/images/Icon/Icon167.png\" /> " + languages.H1009 + "</a>");
                        f.appendTo("#tab");

                    });
                    jQuery("#tab>tr:eq(0)").remove();
                }
                else {

                }
            });
        }

        function SelectName(name) {
            var data = "Name:'" + name + "'";
            jQuery.AjaxCommon("/ServicesFile/ConfigService.asmx/CeliName", data, false, false, function (json) {
                Names = json.d;
            });
        }

        function add() {
            jQuery("#add").dialog({ modal: false, width: 330, resizable: false });

            $("#addotype").blur(function () {
                if ($("#addotype").val() == "") {
                    $("#Span1").text(languages.H1306);
                    return false;
                }
                SelectName($("#addotype").val());
                if (Names == "True") {
                    $("#Span1").text(languages.H1347);
                    return false;
                } else {
                    $("#Span1").text("");
                }
            });

            jQuery("#addCancel").unbind("click");
            jQuery("#addCancel").bind("click", function () {
                jQuery.each(jQuery("#addDiv label"), function (i, n) {
                    $(n).text("");
                });
                $("#addotype").val("");
                $("#addoval").val("");
                $("#addremark").val("");
                jQuery("#add").dialog("close");
            });

            jQuery("#addButton").unbind("click");
            jQuery("#addButton").bind("click", function () {
                jQuery.each(jQuery("#addDiv :text"), function (i, n) {
                    $(n).blur();
                });
                var check = true;
                jQuery.each(jQuery("#addDiv label"), function (i, n) {
                    if ($(n).text() != "") {
                        check = false;
                    }
                });

                if (check == false) {
                    return;
                }
                jQuery("#add").dialog("close");
                var url = "/ServicesFile/ConfigService.asmx/InsertConfig";
                var data = "otype:'" + $("#addotype").val() + "',oval:'" + $("#addoval").val() + "',remark:'" + $("#addremark").val() + "'";
                jQuery.AjaxCommon(url, data, false, false, function (json) {
                    if (json.d != "none") {
                        var result = jQuery.parseJSON(json.d);
                        jQuery.each(result, function (i) {
                            var f = jQuery("#datarow").clone(true);
                            f.find("#tdotype").text(result[i].Otype);
                            f.find("#tdoval").text(result[i].Oval);
                            f.find("#tdremark").text(result[i].Remark);
                            f.find("#tdupdate").html("<a id=\"update\" style=\"cursor:hand\" onclick=\"bindClick(this,'" + result[i].ID + "')\"><img title=\"" + languages.H1009 + "\" src=\"/images/Icon/Icon167.png\" /> " + languages.H1009 + "</a>");
                            f.appendTo("#tab");
                        });

                        jQuery.MsgTip({ objId: "#divTip", msg: languages.H1348 });
                    }
                    else {
                        jQuery.MsgTip({ objId: "#divTip", msg: languages.H1349 });
                    }
                });

                $("#addotype").val("");
                $("#addoval").val("");
                $("#addremark").val("");
            });
        }

        var upName = "";
        function bindClick(tr, id) {
            var otype = jQuery(tr).parent().parent().find("#tdotype").text();
            var oval = jQuery(tr).parent().parent().find("#tdoval").text();
            var remark = jQuery(tr).parent().parent().find("#tdremark").text();
            upName = jQuery(tr).parent().parent().find("#tdotype").text();
            jQuery(tr).parent().parent().find("#tdotype").html("<input type=\"text\" id=\"otype\" value=\"" + otype + "\" class=\"text_01 h20 tc\" onblur=\"IsNullByInfo(this,'err1','"+languages.H1306+"');\" onmouseover=\"this.className='text_01_h h20 tc'\" onmouseout=\"this.className='text_01 h20 tc'\"/>&nbsp;<span id=\"err1\" style=\"color:Red\"/>");
            jQuery(tr).parent().parent().find("#tdoval").html("<input type=\"text\" id=\"oval\" value=\"" + oval + "\" class=\"text_01 h20 tc\" onblur=\"IsNullByInfo(this,'err2',languages.H1306);\"  onmouseover=\"this.className='text_01_h h20 tc'\" onmouseout=\"this.className='text_01 h20 tc'\"/>&nbsp;<span id=\"err2\" style=\"color:Red\"/>");
            jQuery(tr).parent().parent().find("#tdremark").html("<input type=\"text\" id=\"remark\" value=\"" + remark + "\" class=\"text_01 h20 tc\" onmouseover=\"this.className='text_01_h h20 tc'\" onmouseout=\"this.className='text_01 h20 tc'\" />");
            jQuery(tr).parent().parent().find("#tdupdate").html("<a style=\"cursor:hand\" id=\"saveA\" onclick=\"bindSave(this,'" + id + "')\" ><img src=\"/images/Icon/Icon321.png\" title=\"" + languages.H1025 + "\" />" + languages.H1025 + "</a>&nbsp;&nbsp;&nbsp;&nbsp;<a style=\"cursor:hand\" onclick=\"bindEsc(this,'" + otype + "','" + oval + "','" + remark + "','" + id + "')\" id=\"escA\"><img src=\"/images/Icon/Icon390.png\"  title=\"" + languages.H1011 + "\" /> " + languages.H1011 + "</a>");
        }

        function bindSave(tr, id) {
            jQuery.each(jQuery("#tab :text"), function (i, n) {
                $(n).blur();
            });
            var check = true;
            jQuery.each(jQuery("#tab span"), function (i, n) {
                if ($(n).text() != "") {
                    check = false;
                }
            });

            if (check == false) {
                return;
            }
            var otype = jQuery(tr).parent().parent().find("#tdotype").find("#otype").val();
            var oval = jQuery(tr).parent().parent().find("#tdoval").find("#oval").val();
            var remark = jQuery(tr).parent().parent().find("#tdremark").find("#remark").val();
            var data = "id:'" + id + "',otype:'" + otype + "',name:'" + upName + "',oval:'" + oval + "',remark:'" + remark + "'";
            jQuery.AjaxCommon("/ServicesFile/ConfigService.asmx/updateConfig", data, false, false, function (json) {
                if (json.d != "stop") {
                    if (json.d == "True") {
                        $.MsgTip({ objId: "#divTip", msg: languages.H1012 });
                        jQuery(tr).parent().parent().find("#tdotype").html("" + otype);
                        jQuery(tr).parent().parent().find("#tdoval").html("" + oval);
                        jQuery(tr).parent().parent().find("#tdremark").html("" + remark);
                        jQuery(tr).parent().parent().find("#tdupdate").html("<a style=\"cursor:hand\" id=\"update\"onclick=\"bindClick(this,'" + id + "')\"><img title=\"" + languages.H1009 + "\" src=\"/images/Icon/Icon167.png\" /> " + languages.H1009 + "</a>");
                    }
                } else {
                    $("#err1").text(languages.H1347);
                }

            });
           
        }

        function bindEsc(tr, otype, oval, remark, id) {
            jQuery(tr).parent().parent().find("#tdotype").html("" + otype);
            jQuery(tr).parent().parent().find("#tdoval").html("" + oval);
            jQuery(tr).parent().parent().find("#tdremark").html("" + remark);
            jQuery(tr).parent().parent().find("#tdupdate").html("<a style=\"cursor:hand\" id=\"update\"onclick=\"bindClick(this,'" + id + "')\"><img title=\"" + languages.H1009 + "\" src=\"/images/Icon/Icon167.png\" /> " + languages.H1009 + "</a>");
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
<th width="*" class="tab_top_m"><p class="H1351">系统设置</p></th>
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



<div class="f1"><input type="button" id="addBtn" onclick="add()" class="top_add" onmouseover="this.className='top_add_h'" onmouseout="this.className='top_add'"  value="新增" /></div>



</div>
<% } %>
<div class="cl"></div>
<table id="tab3" width=100% cellpadding=0 cellspacing="0" border=0 >
<thead> 
<tr>
<th class="H1352">类型名称</th>
<th class="H1353">值</th>
<th class="H1088">备注</th>
<% if (mdfAc)
   { %>
<th class="H1009">修改</th>
<% } %>
</tr>
</thead> 
<tbody id="tab">
<tr id="datarow">
<td id="tdotype"></td>
<td id="tdoval"></td>
<td id="tdremark"></td>
<% if (mdfAc)
   { %>
<td id="tdupdate" style="width:130px"></td>
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
<% if (addAc)
   { %>
<div id="add" class="H1015" title="新增" >
<div class="showdiv" id="addDiv">
<ul>
<li><span class="H1352">类型名称：</span><p><input id="addotype" type="text" class="text_01 h20 w_120"  onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" />&nbsp;<label id="Span1" style="color:Red"></label></p></li>
<li><span class="H1353">值：</span><p><input id="addoval" type="text" class="text_01 h20 w_120" onblur="IsNullByInfo(this,'Span2',languages.H1306);" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" />&nbsp;<label id="Span2" style="color:Red"></label></p></li>
<li><span class="remark">备注：</span><p><input id="addremark" type="text" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'"  /> </p></li>
<li><div align="center" class="mtop_10">
    <input type="button" id="addButton" class="btn_02" value="提交" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="addCancel" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    </div></li>
</ul>
</div>
</div>
<% } %>

<div class="H1052" title="删除" >
<div class="showdiv">
<p class="wrnning" id="H1071">确定要删除此项吗？</p>
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
<asp:hiddenfield ID="configId" runat="server"></asp:hiddenfield>
    </form>
</body>
</html>
