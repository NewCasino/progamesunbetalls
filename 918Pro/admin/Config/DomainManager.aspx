<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DomainManager.aspx.cs" Inherits="admin.Config.DomainManager" %>

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

        var languages = "";
        var lang;
        function SetGlobal(setLang) {

            setLang = $.SetOrGetLanguage(setLang, function () {
                languages = language;
                loadData();

                $(".H1329").attr("title".H1329);
                $("#addBtn").val(languages.H1015);
                $("#addismain option:eq(0)").text(languages.H1360);
                $("#addismain option:eq(1)").text(languages.H1361);
                $(".H1361").html(languages.H1361);
                $(".H1310").html(languages.H1310);
                $(".H1009").html(languages.H1009);
                $(".H1071").html(languages.H1071);
                $(".H1314").html(languages.H1314);
                $(".H1308").html(languages.H1308);
                $(".H1070").html(languages.H1070);
                $(".H1200").html(languages.H1200);
                $(".H1365").html(languages.H1365);
                $(".H1364").html(languages.H1364);
                $(".H1015").attr("title", languages.H1015);
                $(".H1316").attr("title", languages.H1316);
                $(".H1317").attr("title", languages.H1317);
                $(".H1052").attr("title", languages.H1052);
                $("#addstatus option:eq(0)").text(languages.H1049);
                $("#addstatus option:eq(1)").text(languages.H1050);
                $("#addButton").val(languages.H1015);
                $("#addCancel").val(languages.H1011);
                $("#mdfpasswordbtn").val(languages.H1315);
                $("#passwordCancel").val(languages.H1011);
                $("#mdfSubmit").val(languages.H1315);
                $("#mdfCancel").val(languages.H1011);
                $("#deletebtn").val(languages.H1037);
                $("#deletecancel").val(languages.H1011);

            });
            lang = setLang;
        }

        function loadData() {
            var url = "/ServicesFile/ServerService.asmx/GetDomainAll";
            var data = "";
            jQuery.AjaxCommon(url, data, true, false, function (json) {

                if (json.d != "none") {
                    var result = jQuery.parseJSON(json.d);
                    //var result = eval("(" + json.d + ")");
                   jQuery("#tab>tr:gt(0)").remove();

                    jQuery.each(result, function (i) {
                        var f = jQuery("#datarow").clone(true);
                        f.find("#tdDomainName").text(result[i].DomainName);
                        f.find("#tdismain").text(result[i].ismain == 1 ? languages.H1360 : languages.H1361);
                        f.find("#tdstatus").text(result[i].status == 1 ? languages.H1049 : languages.H1050);
                        f.find("#tdAddDate").text(result[i].AddDate);
                        f.find("#tdupdate").html("<a id=\"update\" style=\"cursor:hand\" onclick=\"bindClick(this,'" + result[i].ID + "')\"><img title=\" " + languages.H1009 + "\" src=\"/images/Icon/Icon167.png\" /> " + languages.H1009 + "</a>");
                        f.appendTo("#tab");

                    });
                    jQuery("#tab>tr:eq(0)").remove();
                }
                else {

                }
            });
        }
        function add() {
            jQuery("#add").dialog({ modal: false, width: 340, resizable: false });
            jQuery("#addCancel").unbind("click");
            jQuery("#addCancel").bind("click", function () {
                jQuery.each(jQuery("#addDiv label"), function (i, n) {
                    $(n).text("");
                });
                $("#addDomainName").val("");
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
                var url = "/ServicesFile/ServerService.asmx/InsertDomain";
                var data = "domainName:'" + $("#addDomainName").val() + "',ismain:'" + $("#addismain").val() + "',status:'" + $("#addstatus").val() + "'";
                jQuery.AjaxCommon(url, data, false, false, function (json) {
                    if (json.d != "none") {
                        var result = jQuery.parseJSON(json.d);
                        jQuery.each(result, function (i) {
                            var f = jQuery("#datarow").clone(true);
                            f.find("#tdDomainName").text(result[i].DomainName);
                            f.find("#tdismain").text(result[i].ismain);
                            f.find("#tdstatus").text(result[i].status);
                            f.find("#tdAddDate").text(result[i].AddDate);
                            f.find("#tdupdate").html("<a id=\"update\" style=\"cursor:hand\" onclick=\"bindClick(this,'" + result[i].ID + "')\"><img title=\" " + languages.H1009 + "\" src=\"/images/Icon/Icon167.png\" />  " + languages.H1009 + "</a>");
                            f.appendTo("#tab");
                        });

                        jQuery.MsgTip({ objId: "#divTip", msg: languages.H1006 });
                    }
                    else {
                        jQuery.MsgTip({ objId: "#divTip", msg: languages.H1362 }); 
                    }
                });

                $("#addDomainName").val("");
            });
        }

        function bindClick(tr, id) {
            var DomainName = jQuery(tr).parent().parent().find("#tdDomainName").text();
            var ismain = jQuery(tr).parent().parent().find("#tdismain").text() == languages.H1360 ? 1 : 0;
            var status = jQuery(tr).parent().parent().find("#tdstatus").text() == languages.H1049 ? 1 : 0;
            jQuery(tr).parent().parent().find("#tdDomainName").html("<input type=\"text\" id=\"DomainName\" value=\"" + DomainName + "\" class=\"text_01 h20 tc\" onblur=\"IsElJudge(this,'err1','DomainName','" + languages.H1306 + "','" + languages.H1363 + "',150);\" onmouseover=\"this.className='text_01_h h20 tc'\" onmouseout=\"this.className='text_01 h20 tc'\"/>&nbsp;<span id=\"err1\" style=\"color:Red\"/>");
            jQuery(tr).parent().parent().find("#tdismain").html("<select id=\"ismain\" class=\"selismain\"><option value=\"1\">" + languages.H1360 + "</option><option value=\"0\">" + languages.H1361 + "</option></select>");
            $(tr).parents("tr").children("td:eq(1)").find(".selismain").val(ismain);
            jQuery(tr).parent().parent().find("#tdstatus").html("<select id=\"status\" class=\"selstatus\"><option value=\"1\">" + languages.H1049 + "</option><option value=\"0\">" + languages.H1050 + "</option></select>");
            $(tr).parents("tr").children("td:eq(2)").find(".selstatus").val(status);
            jQuery(tr).parent().parent().find("#tdupdate").html("<a style=\"cursor:hand\" id=\"saveA\" onclick=\"bindSave(this,'" + id + "')\" ><img src=\"/images/Icon/Icon321.png\" title=\"" + languages.H1025 + "\" /> " + languages.H1025 + "</a>&nbsp;&nbsp;&nbsp;&nbsp;<a style=\"cursor:hand\" onclick=\"bindEsc(this,'" + DomainName + "','" + ismain + "','" + status + "','" + id + "')\" id=\"escA\"><img src=\"/images/Icon/Icon390.png\"  title=\"" + languages.H1011 + "\" /> " + languages.H1011 + "</a>");
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
            var DomainName = jQuery(tr).parent().parent().find("#tdDomainName").find("#DomainName").val();
            var ismain = jQuery(tr).parent().parent().find("#tdismain").find("#ismain").val();
            var status = jQuery(tr).parent().parent().find("#tdstatus").find("#status").val();
            jQuery(tr).parent().parent().find("#tdDomainName").html("" + DomainName);
            jQuery(tr).parent().parent().find("#tdismain").html("" + ismain == "1" ? languages.H1360 : languages.H1361);
            jQuery(tr).parent().parent().find("#tdstatus").html("" + status == "1" ? languages.H1049 : languages.H1050);
            var data = "id:'" + id + "',domainName:'" + DomainName + "',";
            data += "ismain:'" + ismain + "',";
            data += "status:'" + status + "'";
            jQuery.AjaxCommon("/ServicesFile/ServerService.asmx/updateDomain", data, false, false, function (json) { });
            jQuery(tr).parent().parent().find("#tdupdate").html("<a style=\"cursor:hand\" id=\"update\"onclick=\"bindClick(this,'" + id + "')\"><img title=\"" + languages.H1009 + "\" src=\"/images/Icon/Icon167.png\" /> " + languages.H1009 + "</a>");
        }

        function bindEsc(tr, DomainName, ismain, status, id) {
            jQuery(tr).parent().parent().find("#tdDomainName").html("" + DomainName);
            jQuery(tr).parent().parent().find("#tdismain").html("" + ismain == "1" ? languages.H1360 : languages.H1361);
            jQuery(tr).parent().parent().find("#tdstatus").html("" + status == "1" ? languages.H1049 : languages.H1050);
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
<th width="*" class="tab_top_m"><p class="H1361">备用网址</p></th>
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



<div class="f1"><input type="button" id="addBtn" onclick="add()" class="top_add" onmouseover="this.className='top_add_h'" onmouseout="this.className='top_add'"  value="新增" /></div>



</div>
<div class="cl"></div>
<table id="tab3" width="100%" cellpadding=0 cellspacing="0" border=0 >
<thead> 
<tr>
<th class="H1364">域名</th>
<th class="H1365">网址类型</th>
<th class="H1200">创建时间</th>
<th class="H1070">状态</th>
<th class="H1009">修改</th>
</tr>
</thead> 
<tbody id="tab">
<tr id="datarow">
<td id="tdDomainName"></td>
<td id="tdismain" style="width:120px"></td>
<td id="tdAddDate" style="width:160px"></td>
<td id="tdstatus" style="width:90px">></td>
<td id="tdupdate" style="width:130px"></td>
</tr>
</tbody> 

<tfoot>
<tr>
<td colspan="11">

    &nbsp;</td>
</tr>
</tfoot>
</table>


<div class="undis">

<div id="add" title="新增"  class="H1015">
<div class="showdiv" id="addDiv">
<ul>
<li><span class="H1364">域名：</span><p><input id="addDomainName" type="text" onblur="IsElJudge(this,'Span1','DomainName',languages.H1306,languages.H1363,150);" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" />&nbsp;<label id="Span1" style="color:Red"></label></p></li>
<li><span class="H1365">网址类型：</span><p>
    <select id="addismain">
        <option value="1">主网址</option>
        <option value="0">备用网址</option>
    </select>
 </p></li>
<li><span class="H1070">状态：</span><p>
    <select id="addstatus">
        <option value="1">启用</option>
        <option value="0">禁用</option>
    </select>
</p></li>
<li><div align="center" class="mtop_10">
    <input type="button" id="addButton" class="btn_02" value="提交" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="addCancel" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    </div></li>
</ul>
</div>
</div>


<div id="edit" class="H1316" title="修改帐号" >
<div class="showdiv">
<ul>
<li><span class="H1308">帐号管理：</span><p id="mdfManagerId"> </p></li>
<li><span class="H1310">角色：</span><p>
    <select id="mdfRoleId">
        <option id="mdfRoleIdopt"></option>
    </select> </p></li>
<li><div align="center" class="mtop_30">
    <input type="button" id="mdfSubmit" class="btn_02" value="提交" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="mdfCancel" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></div></li>
</ul>
</div>
</div>


<div id="cpwd"  class="H1317" title="修改密码" >
<div class="showdiv">
<ul>
<li><span class="H1317">修改密码：</span><input id="Password1" type="password" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" /></li>
<li><span class="H1314">确认密码：</span><input id="Password2" type="password" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" /></li>
<li><div align="center" class="mtop_30">
    <input type="button" id="mdfpasswordbtn" class="btn_02" value="提交" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="passwordCancel" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></div></li>
</ul>
</div>
</div>



<div id="delet"  class="H1052" title="删除" >
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
