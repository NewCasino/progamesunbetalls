<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="ServerManager.aspx.cs" Inherits="admin.Config.ServerManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
        //多语言
        SetGlobal("");

            GetServerAll();
        });
        var f1;
        var Names;
                 //---------多语言处理-----------
        var languages = "";
        var lang;
        function SetGlobal(setLang) {

            setLang = $.SetOrGetLanguage(setLang, function () {
                //debugger
                languages = language;
   

                $("#ipdz1").text(languages.H1235+"1:");
                $("#ipdz2").html(languages.H1235+"2:");
                $("#ipdz3").html(languages.H1235+"3:");
                $("#szqy").html(languages.H1371+":");
                $("#bz").html(languages.H1088+":");
                $("#zt").html(languages.H1070+":");
                $("#qy").html(languages.H1049);
                $("#jy").html(languages.H1050);
                $("#AddButton").val(languages.H1015);
                $("#AddCancel").val(languages.H1011);

                $("#ip2dz1").text(languages.H1235+"1:");
                $("#ip2dz2").html(languages.H1235+"2:");
                $("#ip2dz3").html(languages.H1235+"3:");
                $("#szqy2").html(languages.H1371+":");
                $("#bz2").html(languages.H1088+":");
                $("#zt2").html(languages.H1070+":");
                $("#qy2").html(languages.H1049);
                $("#jy2").html(languages.H1050);
                $("#updataButton").val(languages.H1037);
                $("#escButton").val(languages.H1011);

                $("#ip3dz1").text(languages.H1235+"1");
                $("#ip3dz2").html(languages.H1235+"2");
                $("#ip3dz3").html(languages.H1235+"3");
                $("#szqy3").html(languages.H1371);
                $("#bz3").html(languages.H1088);
                $("#zt3").html(languages.H1070);
                $("#2jym").html(languages.H1373);
                $("#zxrs").html(languages.H1374);
                $("#cjsj").html(languages.H1200);
                


                $("#fwqmc").text(languages.H1370);
                $("#fwqmc2").text(languages.H1370);
                $("#fwqmc3").text(languages.H1370);
                $("#fwqgl").text(languages.H1368);
                $("#fwqsz").text(languages.H1369);

                $("#up").text(languages.H1009);
                $("#up2").text(languages.H1009);

                


            });
            lang = setLang;
        }
        //--------多语言处理结束---------



        function GetServerAll() {
            var url = "/ServicesFile/ServerService.asmx/GetServerAll";
            var data = "";
             f1 = jQuery("#datarow").clone(true);
             jQuery.AjaxCommon(url, data, true, false, function (json) {
                 if (json.d != "none") {
                     var result = jQuery.parseJSON(json.d);
                     jQuery("#tab>tr:gt(0)").remove();
                     jQuery.each(result, function (i) {
                         var f = jQuery("#datarow").clone(true);
                         f.find("#tdserverName").text(result[i].ServerName);
                         f.find("#tdip1").text(result[i].ip1);
                         f.find("#tdip2").text(result[i].ip2);
                         f.find("#tdip3").text(result[i].ip3);
                         f.find("#tdsubDomain").text(result[i].SubDomain);
                         f.find("#tdonlineNumber").text(result[i].OnlineNumber);
                         f.find("#tdarea").text(result[i].Area);
                         f.find("#tdstatus").text(result[i].Status == "1" ? languages.H1049 : languages.H1050);
                         f.find("#tdaddDate").text(result[i].AddDate).toString("yyyy/MM/dd");
                         f.find("#tdreMark").text(result[i].ReMark);
                          <% if(upAc) { %>
                         f.find("#tdupdate").html("<a id=\"update\" style=\"cursor:hand\" onclick=\"edit(this,'" + result[i].ID + "')\"><img title=\"修改\" src=\"/images/Icon/Icon167.png\" /> "+languages.H1009+"</a>");
                         <% } %>
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
             jQuery.AjaxCommon("/ServicesFile/ServerService.asmx/CeliName", data, false, false, function (json) {
                 Names = json.d;
             });
         }
       
        function add() {
            jQuery("#add").show();
            $("#serverName").blur(function () {
                if ($("#serverName").val() == "") {
                    $("#err1").text(languages.H1306);
                    return false;
                }
                SelectName($("#serverName").val());
                if (Names == "True") {
                    $("#err1").text(languages.H1367);
                    return false;
                } else {
                    $("#err1").text("");
                }
            });
             jQuery("#AddButton").unbind("click");
             jQuery("#AddButton").bind("click", function () {
                 jQuery.each(jQuery("#addtable :text"), function (i, n) {
                     $(n).blur();
                 });
                 var check = true;
                 jQuery.each(jQuery("#addtable span"), function (i, n) {
                         if ($(n).text() != "") {
                             check = false;
                         }
                 });

                 if (check == false) {
                     return;
                 }

                 var url = "/ServicesFile/ServerService.asmx/AddServer";
                 var data = "serverName:'" + jQuery("#serverName").val() + "',ip1:'" + jQuery("#ip1").val() + "',ip2:'" + jQuery("#ip2").val() + "',ip3:'" + jQuery("#ip3").val() + "',area:'" + jQuery("#area").val() + "',status:'" + jQuery("#enable").val() + "',reMark:'" + jQuery("#reMark").val() + "'";
                 jQuery.AjaxCommon(url, data, false, false, function (json) {
                     if (json.d != "none") {
                         jQuery("#add").hide();
                         var result = jQuery.parseJSON(json.d);
                         jQuery.each(result, function (i) {
                             var f = jQuery("#datarow").clone(true);
                             f.find("#tdserverName").text(result[i].ServerName);
                             f.find("#tdip1").text(result[i].Ip1);
                             f.find("#tdip2").text(result[i].Ip2);
                             f.find("#tdip3").text(result[i].Ip3);
                             f.find("#tdsubDomain").text(result[i].SubDomain);
                             f.find("#tdonlineNumber").text(result[i].OnlineNumber);
                             f.find("#tdarea").text(result[i].Area);
                             f.find("#tdstatus").text(result[i].Status == "1" ? languages.H1049 : languages.H1050);
                             f.find("#tdaddDate").text(result[i].AddDate);
                             f.find("#tdreMark").text(result[i].ReMark);
                              <% if(upAc) { %>
                             f.find("#mdf").html("<a id=\"update\" style=\"cursor:hand\" onclick=\"edit(this)\"><img title=\"修改\" src=\"/images/Icon/page_edit.gif\" /></a>");
                             <% } %>
                             f.appendTo("#tab");
                         });

                         jQuery.MsgTip({ objId: "#divTip", msg: languages.H1300 });

                     }
                     else {
                         jQuery.MsgTip({ objId: "#divTip", msg: languages.H1301 });
                     }
                 });

                 $("#serverName").val("");
                 $("#ip1").val("");
                 $("#ip2").val("");
                 $("#ip3").val("");
                 $("#subDomain").val("");
                 $("#onlineNumber").val("");
                 $("#area").val("");
                 $("#status").val("");
                 $("#addDate").val("");
                 $("#reMark").val("");
             });
             jQuery("#AddCancel").unbind("click");
             jQuery("#AddCancel").bind("click", function () {
                 jQuery.each(jQuery("#addtable span"), function (i, n) {
                     $(n).text("");
                 });
                 $("#serverName").val("");
                 $("#ip1").val("");
                 $("#ip2").val("");
                 $("#ip3").val("");
                 $("#area").val("");
                 $("#reMark").val("");
                 jQuery("#add").hide();
             });
        }


        function edit(obj, id) {
            jQuery("#updata").hide().appendTo("#form1");
            f1.find("td:gt(0)").remove();
            f1.find("td:eq(0)").attr("colspan", "11");
            jQuery("#updata").show();
            $("#serverId").val(id);
            jQuery("#uServerName").val(jQuery(obj).parent().parent().find("#tdserverName").text());
            var upName = jQuery(obj).parent().parent().find("#tdserverName").text();
            jQuery("#uIP1").val(jQuery(obj).parent().parent().find("#tdip1").text());
            jQuery("#uIP2").val(jQuery(obj).parent().parent().find("#tdip2").text());
            jQuery("#uIP3").val(jQuery(obj).parent().parent().find("#tdip3").text());
            jQuery("#uArea").val(jQuery(obj).parent().parent().find("#tdarea").text());
            jQuery("#uSelect").val(jQuery(obj).parent().parent().find("#tdstatus").text()==languages.H1049 ?"1":"0");
            jQuery("#uReMark").val(jQuery(obj).parent().parent().find("#tdreMark").text());
            f1.find("td:eq(0)").append(jQuery("#updata"));
            jQuery(obj).parent().parent().after(f1.show());
            jQuery("#updataButton").unbind("click");
            jQuery("#updataButton").bind("click", function () {
                jQuery.each(jQuery("#uptable :text"), function (i, n) {
                    $(n).blur();
                });
                var check = true;
                jQuery.each(jQuery("#uptable span"), function (i, n) {
                    if ($(n).text() != "") {
                        check = false;
                    }
                });

                if (check == false) {
                    return;
                }
                var id = $("#serverId").val();
                var data = "id:'" + id + "',serverName:'" + $("#uServerName").val() + "',upName:'" + upName + "',ip1:'" + $("#uIP1").val() + "',ip2:'" + $("#uIP2").val() + "',ip3:'" + $("#uIP3").val() + "',area:'" + $("#uArea").val() + "',status:'" + $("#uSelect").val() + "',reMark:'" + $("#uReMark").val() + "'";
                jQuery.AjaxCommon("/ServicesFile/ServerService.asmx/updateServer", data, false, false, function (json) {
                    if (json.d != "stop") {
                        if (json.d == "ok") {
                            // $(".wrnning").html("<p>修改成功</p>");
                            $.MsgTip({ objId: "#divTip", msg: languages.H1012 });
                            jQuery("#updata").parent().parent().hide();
                            jQuery(obj).parent().parent().find("#tdserverName").html($("#uServerName").val());
                            jQuery(obj).parent().parent().find("#tdip1").html($("#uIP1").val());
                            jQuery(obj).parent().parent().find("#tdip2").html($("#uIP2").val());
                            jQuery(obj).parent().parent().find("#tdip3").html($("#uIP3").val());
                            jQuery(obj).parent().parent().find("#tdarea").html($("#uArea").val());
                            jQuery(obj).parent().parent().find("#tdstatus").html($("#uSelect").val() == 1 ? languages.H1049 : languages.H1050);
                            jQuery(obj).parent().parent().find("#tdreMark").html($("#uReMark").val());
                            jQuery("#delet").dialog({ modal: false });

                            jQuery("#deletecancel").unbind("click");
                            jQuery("#deletecancel").bind("click", function () {

                                jQuery("#delet").dialog("close");
                            });
                        }
                        else {
                            $.MsgTip({ objId: "#divTip", msg: languages.H1185 });
                        }
                    } else {
                        $("#Span1").text(languages.H1367);
                    }
                });

            });

            jQuery("#escButton").unbind("click");
            jQuery("#escButton").bind("click", function () {
                jQuery.each(jQuery("#uptable span"), function (i, n) {
                    $(n).text("");
                });
                jQuery("#updata").parent().parent().hide();
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
                        $.MsgTip({ objId: "#divTip", msg: languages.H1186 });
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
<th width="*" class="tab_top_m"><p id="fwqgl">服务器管理</p></th>
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
<div id="add" class="new_tr undis">

<div  title="新增" >
<div align="center">
<table width="90%"  border="0" cellpadding="1" cellspacing="1" id="addtable">
  <tr align="center" style="background-color:#CDEAFC">
    <td colspan="6"><strong id="fwqsz">服务器设置</strong></td>
  </tr>
  <tr>
    <td align="right" id="fwqmc">服务器名称：</td>
    <td align="left" id="UIDS">
        <input type="text" name="serverName" id="serverName" class="text_01 h20" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />&nbsp;<span id="err1" style="color:Red"></span></td>
    <td align="right">&nbsp;</td>
    <td align="left">&nbsp;</td>
    <td align="right">&nbsp;</td>
    <td align="left">&nbsp;</td>
  </tr>
  <tr>
    <td align="right" id="ipdz1">IP地址1：</td>
    <td align="left"><input type="text" name="ip1" id="ip1" class="text_01 h20" onblur="IsElJudge(this,'err2','ip','必填','IP格式错误',0);" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" />&nbsp;<span id="err2" style="color:Red"></span></td>
    <td align="right" id="ipdz2">IP地址2：</td>
    <td align="left"><input type="text" name="ip2" id="ip2" class="text_01 h20" onblur="IsElJudge(this,'err3','ip','必填','IP格式错误',0);" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" />&nbsp;<span id="err3" style="color:Red"></span></td>
     <td align="right" id="ipdz3">IP地址3：</td>
    <td align="left"><input type="text" name="ip3" id="ip3" class="text_01 h20" onblur="IsElJudge(this,'err4','ip','必填','IP格式错误',0);" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" />&nbsp;<span id="err4" style="color:Red"></span></td>
  </tr>
  <tr>
    <td align="right" id="szqy">所在区域：</td>
    <td align="left"><input type="text" name="area" id="area" class="text_01 h20" onblur="IsNullByInfo(this,'err5','必填');" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" />&nbsp;<span id="err5" style="color:Red"></span></td>
    <td align="right" id="bz">备注：</td>
    <td align="left"><input type="text" name="reMark" id="reMark" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" /></td>
    <td align="right" id="zt">状态：</td>
    <td align="left">
    <select id="enable">
        <option value="1" id="qy">启用</option>
        <option value="0" id="jy">禁用</option>
    </select></td>
  </tr>
  <tr>
    <td align="right" colspan="6">&nbsp;</td>
  </tr>
  <tr>
    <td colspan="6" align="center">
<input type="button" id="AddButton"  class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'"  value="增加" />
<input type="button" id="AddCancel"  class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="取消" />
	
	</td>
  </tr>
</table>
</div>
<div class="new_trfoot"></div>
</div>

</div>

<div id="updata" class="new_tr undis">
<div  title="修改服务器" >
<div align="center">
<table width="90%"  border="0" cellpadding="1" cellspacing="1" id="uptable">
  <tr align="center" style="background-color:#CDEAFC">
    <td colspan="6"><strong id="up">修改</strong></td>
  </tr>
  <tr>
    <td align="right" id="fwqmc2">服务器名称：</td>
    <td align="left" id="Td1">
        <input type="text" name="uServerName" id="uServerName" class="text_01 h20" onblur="IsNullByInfo(this,'Span1','必填');"  onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />&nbsp;<span id="Span1" style="color:Red"/></td>
    <td align="right">&nbsp;</td>
    <td align="left">
  <asp:hiddenfield ID="serverId" runat="server"></asp:hiddenfield>
      </td>
    <td align="right">&nbsp;</td>
    <td align="left">&nbsp;</td>
  </tr>
  <tr>
    <td align="right" id="ip2dz1">IP地址1：</td>
    <td align="left"><input type="text" name="uIP1" id="uIP1" class="text_01 h20" onblur="IsElJudge(this,'Span2','ip','必填','IP格式错误',0);" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" />&nbsp;<span id="Span2" style="color:Red"/></td>
    <td align="right" id="ip2dz2">IP地址2：</td>
    <td align="left"><input type="text" name="uIP2" id="uIP2" class="text_01 h20" onblur="IsElJudge(this,'Span3','ip','必填','IP格式错误',0);" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" />&nbsp;<span id="Span3" style="color:Red"/></td>
     <td align="right" id="ip2dz3">IP地址3：</td>
    <td align="left"><input type="text" name="uIP3" id="uIP3" class="text_01 h20" onblur="IsElJudge(this,'Span4','ip','必填','IP格式错误',0);" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" />&nbsp;<span id="Span4" style="color:Red"/></td>
  </tr>
  <tr>
    <td align="right" id="szqy2">所在区域：</td>
    <td align="left"><input type="text" name="uArea" id="uArea" class="text_01 h20" onblur="IsNullByInfo(this,'Span5','必填');" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" />&nbsp;<span id="Span5" style="color:Red"/></td>
    <td align="right" id="bz2">备注：</td>
    <td align="left"><input type="text" name="uReMark" id="uReMark" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" /></td>
    <td align="right" id="zt2">状态：</td>
    <td align="left">
    <select id="uSelect">
        <option value="1" id="qy2">启用</option>
        <option value="0" id="jy2">禁用</option>
    </select></td>
  </tr>
  <tr>
    <td align="right" colspan="6">&nbsp;</td>
  </tr>
  <tr>
    <td colspan="6" align="center">
<input type="button" id="updataButton"  class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'"  value="确定" />
<input type="button" id="escButton"  class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="取消" />
	
	</td>
  </tr>
</table>
</div>
<div class="new_trfoot"></div>
</div>
</div>
    <table id="tab3" width=100% cellpadding=0 cellspacing="0" border=0 >
        <thead> 
        <tr>
        <th id="fwqmc3">服务器名称</th>
        <th id="ip3dz1">IP地址1</th>
        <th id="ip3dz2">IP地址2</th>
        <th id="ip3dz3">IP地址3</th>
        <th id="2jym">二级域名</th>
        <th id="zxrs">在线人数</th>
        <th id="szqy3">所在区域</th>
        <th id="zt3">状态</th>
        <th id="cjsj">创建时间</th>
        <th id="bz3">备注</th>
         <% if (upAc)
           { %>
        <th id="up2">修改</th>
        <% } %>
        </tr>
        </thead> 
        <tbody id="tab">
        <tr id="datarow">
        <td id="tdserverName"></td>
        <td id="tdip1"></td>
        <td id="tdip2"></td>
        <td id="tdip3"></td>
        <td id="tdsubDomain"></td>
        <td id="tdonlineNumber"></td>
        <td id="tdarea"></td>
        <td id="tdstatus"></td>
        <td id="tdaddDate" style="width:140px"></td>
        <td id="tdreMark"></td>
        <% if (upAc)
          { %>
        <td id="tdupdate" style="width:70px"></td>
        <%} %>
        </tr>
        </tbody> 
        <tfoot>
        <tr>
        <td colspan="11">

            &nbsp;</td>
        </tr>
        </tfoot>
        </table>

<%--<div class="undis">
<div id="delet" title="温馨提示" >
<div class="showdiv">
<p class="wrnning"></p>
<div align="center" class="mtop_50">
    <input type="button" id="deletecancel" class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="确定" />
</div>
</div>
</div>
</div>--%>

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
