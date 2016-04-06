<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loginservers.aspx.cs" Inherits="admin.Config.Loginservers" %>

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
            loginserversAll();
        });


                                 //---------多语言处理-----------
        var languages = "";
        var lang;
        function SetGlobal(setLang) {

            setLang = $.SetOrGetLanguage(setLang, function () {
                //debugger
                languages = language;
   
                $("#fwqbd").text(languages.H1378);
                $("#ipdz").text(languages.H1235+":");
                $("#jqmc").html(languages.H1379+":");
                $("#fwqip").html(languages.H1491);
                $("#fwqzt").html(languages.H1381+":");
                $("#qy").html(languages.H1049);
                $("#jy").html(languages.H1050);
                $("#AddButton").val(languages.H1015);
                $("#AddCancel").val(languages.H1011);

                $("#fwqbd2").text(languages.H1378);
                $("#ipdz2").text(languages.H1235+":");
                $("#jqmc2").html(languages.H1379+":");
                $("#fwqip2").html(languages.H1491);
                $("#fwqzt2").html(languages.H1381+":");
                $("#qy2").html(languages.H1049);
                $("#jy2").html(languages.H1050);
                $("#updataButton").val(languages.H1037);
                $("#escButton").val(languages.H1011);
                
                
                $("#ipdz3").text(languages.H1235);
                $("#jqmc3").html(languages.H1379);
                $("#fwqip3").html(languages.H1491);
                $("#zt").html(languages.H1070);
                $("#up").html(languages.H1009);
                $("#de").html(languages.H1052);
                
                $("#queding").html(languages.H1071);
                $("#deletebtn").val(languages.H1037);
                $("#deleteEsc").val(languages.H1011);
                $("#addBtn").val(languages.H1377);
                

            });
            lang = setLang;
        }
        //--------多语言处理结束---------



        var f1;
        function loginserversAll() {
            var url = "/ServicesFile/LoginService.asmx/GetloginserversAll";
            var data = "";
            f1 = jQuery("#datarow").clone(true);
            jQuery.AjaxCommon(url, data, true, false, function (json) {
                if (json.d != "none") {
                    var result = jQuery.parseJSON(json.d);
                    jQuery("#tab>tr:gt(0)").remove();
                    jQuery.each(result, function (i) {
                        var f = jQuery("#datarow").clone(true);
                        f.find("#tdwebserverip").text(result[i].webserverip);
                        f.find("#tdname").text(result[i].name);
                        f.find("#tdip").text(result[i].ip);
                        <%if(statusAc){ %>
                        f.find("#tdstatus").html("<a id=\"status\" style=\"cursor:hand\" onclick=\"cstatus(this,'" + result[i].id + "')\">" + (result[i].status == "1" ? languages.H1049 : languages.H1050) + "</a>");
                        <%} %>
                        <%if(upAc){ %>
                        f.find("#tdupdate").html("<a id=\"update\" style=\"cursor:hand\" onclick=\"edit(this,'" + result[i].id + "')\"><img title=\"修改\" src=\"/images/Icon/Icon167.png\" /> "+languages.H1009+"</a>");
                        <%} %>
                        <%if(deleteAc){ %>
                        f.find("#tddelete").html("<a id=\"delete\" style=\"cursor:hand\" onclick=\"delet(this,'" + result[i].id + "')\"><img title=\"删除\" src=\"/images/Icon/Icon141.png\" /> "+languages.H1052+"</a>");
                        <%} %>
                        f.appendTo("#tab");

                    });
                    jQuery("#tab>tr:eq(0)").remove();
                }
                else {

                }
            });
        }

        function add() {
            jQuery("#add").show();
            $("#Addwebserverip").blur(function () {
                if ($("#Addwebserverip").val() == "") {
                    $("#Webserveriplbl").html(languages.H1000);
                    return false;
                }
                $("#Webserveriplbl").html("");
            });

            $("#Rate").blur(function () {
                if ($("#Rate").val() == "") {
                    $("#Ratelbl").html(languages.H1000);
                    return false;
                } else {
                    var namePattern = /^[0-9]+(.[0-9]{2})?/;
                    if (!namePattern.test($("#Rate").val()) || $("#Rate").val().length > 6) {
                        $("#Ratelbl").html(languages.H1182);
                        return false;
                    }
                    else {
                        $("#Ratelbl").html("");
                    }
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

                var url = "/ServicesFile/LoginService.asmx/AddLoginservers";
                var data = "Webserverip:'" + jQuery("#Addwebserverip").val() + "',Name:'" + jQuery("#Addname").val() + "',Ip:'" + $("#Addip").val() + "',Status:'" + jQuery("#enable").val() + "'";
                jQuery.AjaxCommon(url, data, false, false, function (json) {
                    if (json.d != "none") {
                        jQuery("#add").hide();
                        var result = jQuery.parseJSON(json.d);
                        jQuery.each(result, function (i) {

                            //var f = jQuery("#datarow").clone(true);
                            f1.find("#tdwebserverip").text(result[i].Webserverip);
                            f1.find("#tdname").text(result[i].Name);
                            f1.find("#tdip").text(result[i].Ip);
                            <%if(statusAc){ %>
                            f1.find("#tdstatus").html("<a id=\"status\" style=\"cursor:hand\" onclick=\"cstatus(this,'" + result[i].Id + "')\">" + (result[i].Status == "1" ? "啟用" : "禁用") + "</a>");
                            <%} %>
                            <%if(upAc){ %>
                            f1.find("#tdupdate").html("<a id=\"update\" style=\"cursor:hand\" onclick=\"edit(this,'" + result[i].Id + "')\"><img title=\"修改\" src=\"/images/Icon/Icon167.png\" />修改</a>");
                            <%} %>
                            <%if(deleteAc){ %>
                            f1.find("#tddelet").html("<a id=\"delet\" style=\"cursor:hand\" onclick=\"delet(this,'" + result[i].Id + "')\"><img title=\"删除\" src=\"/images/Icon/Icon141.png\" />刪除</a>");
                            <%} %>
                            f1.appendTo("#tab");
                        });

                        jQuery.MsgTip({ objId: "#divTip", msg: languages.H1375 });
                        jQuery("#updata").hide().appendTo("#form1");
                        loginserversAll();
                    }
                    else {
                        jQuery.MsgTip({ objId: "#divTip", msg: languages.H1376 });
                    }
                });

                $("#Addip").val("");
                $("#Addname").val("");
                $("#Addwebserverip").val("");
            });
            jQuery("#AddCancel").unbind("click");
            jQuery("#AddCancel").bind("click", function () {
                jQuery.each(jQuery("#addtable span"), function (i, n) {
                    $(n).text("");
                });
                $("#Addip").val("");
                $("#Addname").val("");
                $("#Addwebserverip").val("");
                jQuery("#add").hide();
            });
        }


        function edit(obj, id) {
            jQuery("#updata").hide().appendTo("#form1");
            f1.find("td:gt(0)").remove();
            f1.find("td:eq(0)").text("");
            f1.find("td:eq(0)").attr("colspan", "11");
            //debugger;
            jQuery("#updata").show();
            jQuery("#serverId").val(id);
            jQuery("#Uwebserverip").val(jQuery(obj).parent().parent().find("#tdwebserverip").text());
            jQuery("#Uname").val(jQuery(obj).parent().parent().find("#tdname").text());
            jQuery("#Uip").val(jQuery(obj).parent().parent().find("#tdip").text());
            jQuery("#Uname").val(jQuery(obj).parent().parent().find("#tdname").text());
            jQuery("#Ustatus").val(jQuery(obj).parent().parent().find("#tdstatus").text() == languages.H1049 ? "1" : "0");
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
                var data = "Id:'" + id + "',Webserverip:'" + jQuery("#Uwebserverip").val() + "',Name:'" + jQuery("#Uname").val() + "',Ip:'" + $("#Uip").val() + "',Status:'" + jQuery("#Ustatus").val() + "'";
                jQuery.AjaxCommon("/ServicesFile/LoginService.asmx/UpdateLoginservers", data, false, false, function (json) {
                    if (json.d != "none") {
                        $.MsgTip({ objId: "#divTip", msg: languages.H1012 });
                        jQuery("#updata").parent().parent().hide();
                        var result = jQuery.parseJSON(json.d);
                        jQuery.each(result, function (i) {
                            jQuery(obj).parent().parent().find("#tdwebserverip").html(result[i].Webserverip);
                            jQuery(obj).parent().parent().find("#tdname").html(result[i].Name);
                            jQuery(obj).parent().parent().find("#tdip").html(result[i].Ip);
                            jQuery(obj).parent().parent().find("#tdstatus").html("<a id=\"status\" style=\"cursor:hand\" onclick=\"cstatus(this,'" + result[i].Id + "')\">" + (result[i].Status == "1" ? "啟用" : "禁用") + "</a>");
                        });
                    }
                    else {
                        $.MsgTip({ objId: "#divTip", msg: languages.H1185 });
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

        function delet(obj, id) {
            jQuery("#delet").dialog({ modal: false });

            jQuery("#deleteEsc").unbind("click");
            jQuery("#deleteEsc").bind("click", function () {
                jQuery("#delet").dialog("close");
            });

            jQuery("#deletebtn").unbind("click");
            jQuery("#deletebtn").bind("click", function () {
                jQuery("#delet").dialog("close");
                var url = "/ServicesFile/LoginService.asmx/DeleteLoginService";
                var data = "Id:" + id;
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

        function cstatus(obj, id) {
            var curId = $(obj).attr("id").substr(1);
            var status = $(obj).text() == languages.H1049 ? "0" : "1";
            var url = "/ServicesFile/LoginService.asmx/UpdateLoginServiceStatus";
            var data = "status:'" + status + "',Id:" + id;
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
    <input type="hidden" id="Hidden1" value="tw"/>
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="fwqbd">服務器綁定</p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<!--主题部分开始=========================================================================================-->
<%if(addAc)
  {%>
<div class="top_banner h30">

<div class="f1"><input type="button" id="addBtn" onclick="add()" class="top_add" onmouseover="this.className='top_add_h'" onmouseout="this.className='top_add'"  value="服務器綁定" /></div>

</div>
<%} %>
<div class="cl"></div>
<div id="add" class="new_tr undis">

<div  title="服務器綁定" >
<div align="center">
<table width="60%"  border="0" cellpadding="1" cellspacing="1" id="addtable">
  <tr align="center" style="background-color:#CDEAFC">
    <td colspan="4" id="bdsz">綁定设置</td>
  </tr>
  <tr>
    <td align="right" id="ipdz">IP地址：</td>
    <td align="left" id="UIDS">
       <input type="text" name="Addip" id="Addip" class="text_01 h20" onblur="IsElJudge(this,'err1','ip','必填','IP格式错误',0);" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />&nbsp;<span id="err1" style="color:Red"></span></td>

    <td align="right" id="jqmc">機器名稱：</td>
    <td align="left">
         <input type="text" name="Addname" id="Addname" class="text_01 h20" onblur="IsNullByInfo(this,'err2','必填');" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />&nbsp;<span id="err2" style="color:Red"></span>
    </td>
  </tr>
  <tr>
    <td align="right" id="fwqip">服務器IP：</td>
    <td align="left">
        <input type="text" name="Addwebserverip" id="Addwebserverip" class="text_01 h20"  onblur="IsElJudge(this,'err3','ip','必填','IP格式错误',0);"  onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />&nbsp;<span id="err3" style="color:Red"></span></td>
    <td align="right" id="fwqzt">服務器狀態：</td>
    <td align="left">
    <select id="enable">
        <option value="1" id="qy">啟用</option>
        <option value="0" id="jy">禁用</option>
    </select>
    </td>
  </tr>
  <tr>
    <td align="right" colspan="4"><input type="hidden" id="language" value="tw"/></td>
  </tr>
  <tr>
    <td colspan="4" align="center">
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
<div  title="修改" >
<div align="center">
<table width="60%"  border="0" cellpadding="1" cellspacing="1" id="uptable">
  <tr align="center" style="background-color:#CDEAFC">
    <td colspan="4" id="bdsz2">綁定设置</td>
  </tr>
  <tr>
    <td align="right" id="ipdz2">IP地址：</td>
    <td align="left" id="Td1">
        <input type="text" name="Uip" id="Uip" class="text_01 h20" onblur="IsElJudge(this,'Span1','ip','必填','IP格式错误',0);" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />&nbsp;<span id="Span1" style="color:Red"/></td>

    <td align="right" id="jqmc2">機器名稱：</td>
    <td align="left">
         <input type="text" name="Uname" id="Uname" class="text_01 h20" onblur="IsNullByInfo(this,'Span2','必填');" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />&nbsp;<span id="Span2" style="color:Red"/>
         <label id="Label2" style="color:Red"></label>
    </td>
  </tr>
  <tr>
    <td align="right" id="fwqip2">服務器IP：</td>
    <td align="left">
        <input type="text" name="Uwebserverip" id="Uwebserverip" class="text_01 h20" onblur="IsElJudge(this,'Span3','ip','必填','IP格式错误',0);"  onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />&nbsp;<span id="Span3" style="color:Red"/></td>
    <td align="right" id="fwqzt2">服務器狀態：</td>
    <td align="left">
    <select id="Ustatus">
        <option value="1" id="qy2">啟用</option>
        <option value="0" id="jy2">禁用</option>
    </select>
    </td>
  </tr>
  <tr>
    <td colspan="4" align="center">
<input type="button" id="updataButton"  class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'"  value="确定" />
<input type="button" id="escButton"  class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="取消" />
	
	</td>
  </tr>
</table>
</div>
<div class="new_trfoot"></div>
</div>
</div>
    <table id="tab3" width="100%" cellpadding=0 cellspacing="0" border=0 >
        <thead> 
        <tr>
        <th id="ipdz3">&nbsp;IP地址</th>
        <th id="jqmc3">機器名稱</th>
        <th id="fwqip3">服務器IP</th>
        <%if (statusAc)
          { %>
        <th id="zt">狀態</th>
        <%} %>
        <%if (upAc)
           { %>
        <th id="up">修改</th>
        <%} %>
        <%if (deleteAc)
          { %>
        <th id="de">刪除</th>
        <%} %>
        </tr>
        </thead> 
        <tbody id="tab">
        <tr id="datarow">
        <td id="tdip"></td>
        <td id="tdname"></td>
        <td id="tdwebserverip" style="width:160px"></td>
        <%if (statusAc)
            { %>
        <td id="tdstatus" style="width:90px"></td>
        <%} %>
        <%if (upAc)
          { %>
        <td id="tdupdate" style="width:90px"></td>
        <%} %>
        <%if (deleteAc)
          { %>
        <td id="tddelete" style="width:90px"></td>
        <%} %>
        </tr>
        </tbody> 
        <tfoot>
        <tr>
        <td colspan="7">

            &nbsp;</td>
        </tr>
        </tfoot>
        </table>

<div class="undis">

<div id="delet" title="提示" >
<div class="showdiv">
<p class="wrnning" id="queding">确定要删除此项吗？</p>
<div align="center" class="mtop_50">
    <input type="button" id="deletebtn" class="btn_02" value="确定" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="deleteEsc" class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="取消" />
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

    </form>
</body>
</html>
