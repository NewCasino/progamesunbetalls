<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginserver.aspx.cs" Inherits="admin.Config.loginserver" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                SetGlobal("");

                f1 = jQuery("#datarow").clone(true);
            });
            var Names
            var f1 = "";
        //---------多语言处理-----------
        var languages = "";
        var lang;
        function SetGlobal(setLang) {

            setLang = $.SetOrGetLanguage(setLang, function () {
                //debugger
                languages = language;
                GetInfo();
            });
            lang = setLang;
        }
        //--------多语言处理结束---------

        function GetInfo() {
            var url = "/ServicesFile/ConfigService.asmx/GetCasinoLogin";
            var data = "";
             //f1 = jQuery("#datarow").clone(true);
            jQuery.AjaxCommon(url, data, true, false, function (json) {
                if (json.d != "none") {
                    var result = jQuery.parseJSON(json.d);
                    var tr = "";
                    //jQuery("#tab>tr:gt(0)").remove();
                    jQuery.each(result, function (i) {
                        tr += "<tr>";
                        tr += "<td id=\"td1\">" + result[i].Webserverid + "</td>";
                        tr += "<td id=\"td2\">" + result[i].Casino + "</td>";
                        tr += "<td id=\"td3\">" + result[i].Webserverip + "</td>";
                        tr += "<td id=\"td4\">" + result[i].Loginserverip + "</td>";
                        tr += "<td id=\"td5\">" + (result[i].Status == "1" ? "启用" : "禁用") + "</td>";
                        tr += "<td><a id=\"update\" style=\"cursor:hand\" onclick=\"edit(this,'" + result[i].Id + "')\"><img title=\"修改\" src=\"/images/Icon/Icon167.png\" /> " + "修改" + "</a></td>";
                        tr += "<td><a id=\"delete\" style=\"cursor:hand\" onclick=\"delet(this,'" + result[i].Id + "')\"><img title=\"删除\" src=\"/images/Icon/Icon141.png\" /> " + languages.H1052 + "</a></td>";
                        tr += "</tr>";
                    });
                    jQuery("#tab").html(tr);
                }
                else {

                }
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
                 //debugger
                 var url = "/ServicesFile/ConfigService.asmx/AddCasinoLogin";
                 var data = "webserverid:'" + jQuery("#add1").val() + "',casino:'" + jQuery("#add2").val() + "',webserverip:'" + jQuery("#add3").val() + "',loginserverip:'" + jQuery("#add4").val() + "',status:" + jQuery("#enable").val();
                 jQuery.AjaxCommon(url, data, false, false, function (json) {
                     if (json.d) {
                         jQuery("#add").hide();
                         GetInfo();

                         jQuery.MsgTip({ objId: "#divTip", msg: languages.H1300 });

                     }
                     else {
                         jQuery.MsgTip({ objId: "#divTip", msg: languages.H1301 });
                     }
                 });

             });
             jQuery("#AddCancel").unbind("click");
             jQuery("#AddCancel").bind("click", function () {
                 jQuery.each(jQuery("#addtable span"), function (i, n) {
                     $(n).text("");
                 });
                 jQuery("#add").hide();
             });
        }


        function edit(obj, id) {
        //debugger
            jQuery("#updata").hide().appendTo("#form1");
            f1.find("td:gt(0)").remove();
            f1.find("td:eq(0)").attr("colspan", "7");
            jQuery("#mdf1").val(jQuery(obj).parent().parent().find("#td1").text());
            jQuery("#mdf2").val(jQuery(obj).parent().parent().find("#td2").text());
            jQuery("#mdf3").val(jQuery(obj).parent().parent().find("#td3").text());
            jQuery("#mdf4").val(jQuery(obj).parent().parent().find("#td4").text());
            jQuery("#mdf5").val(jQuery(obj).parent().parent().find("#td5").text() == languages.H1049 ? "1" : "0");
            jQuery("#updata").show();
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
                var data = "webserverid:'" + $("#mdf1").val() + "',casino:'" + $("#mdf2").val() + "',webserverip:'" + $("#mdf3").val() + "',loginserverip:'" + $("#mdf4").val() + "',status:'" + $("#mdf5").val() + "',id:" + id;
                jQuery.AjaxCommon("/ServicesFile/ConfigService.asmx/UpdateCasinoLogin", data, false, false, function (json) {
                    if (json.d) {
                        // $(".wrnning").html("<p>修改成功</p>");
                        jQuery("#updata").parent().parent().hide();
                        jQuery(obj).parent().parent().find("#td1").html($("#mdf1").val());
                        jQuery(obj).parent().parent().find("#td2").html($("#mdf2").val());
                        jQuery(obj).parent().parent().find("#td3").html($("#mdf3").val());
                        jQuery(obj).parent().parent().find("#td4").html($("#mdf4").val());
                        jQuery(obj).parent().parent().find("#td5").html($("#mdf5").val() == 1 ? languages.H1049 : languages.H1050);

                        $.MsgTip({ objId: "#divTip", msg: "更新成功" });
                    } else {
                        $.MsgTip({ objId: "#divTip", msg: "更新失败"});

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
        //debugger
            if (!confirm("确定要删除？")) {
                return;
            }

                var url = "/ServicesFile/ConfigService.asmx/DeleteCasinoLogin";
                var data = "id:" + id;
                jQuery.AjaxCommon(url, data, false, false, function (json) {
                    if (json.d) {
                        $(obj).parent().parent().remove();
                        $.MsgTip({ objId: "#divTip", msg: languages.H1073 });
                    }
                    else {
                        $.MsgTip({ objId: "#divTip", msg: languages.H1186 });
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
<th width="*" class="tab_top_m"><p id="fwqgl">登录服务器</p></th>
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
<div id="add" class="new_tr undis">

<div  title="新增" >
<div align="center">
<table width="90%"  border="0" cellpadding="1" cellspacing="1" id="addtable">
  <tr align="center" style="background-color:#CDEAFC">
    <td colspan="6"><strong id="fwqsz">登录服务器</strong></td>
  </tr>
  <tr>
    <td align="right" id="fwqmc">服务器代码：</td>
    <td align="left" id="UIDS">
        <input type="text" name="serverName" id="add1" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onblur="IsNullByInfo(this,'err1',languages.H1306);" onmouseout="this.className='text_01 h20'" />&nbsp;<span id="err1" style="color:Red"></span></td>
    <td align="right">网站</td>
    <td align="left">
        <input type="text" name="serverName" id="add2" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onblur="IsNullByInfo(this,'err2',languages.H1306);" onmouseout="this.className='text_01 h20'" />&nbsp;<span id="err2" style="color:Red"></span></td>
    <td align="right">&nbsp;</td>
    <td align="left">&nbsp;</td>
  </tr>
  <tr>
    <td align="right" id="ipdz1">服务器IP：</td>
    <td align="left"><input type="text" name="ip1" id="add3" class="text_01 h20" onblur="IsNullByInfo(this,'err3',languages.H1306);" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" />&nbsp;<span id="err3" style="color:Red"></span></td>
    <td align="right" id="ipdz2">登录服务器IP：</td>
    <td align="left"><input type="text" name="ip2" id="add4" class="text_01 h20" onblur="IsNullByInfo(this,'err4',languages.H1306);" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" />&nbsp;<span id="err4" style="color:Red"></span></td>
     <td align="right" id="ipdz3"></td>
    <td align="left"></td>
  </tr>
  <tr>
    <td align="right" id="szqy"></td>
    <td align="left"></td>
    <td align="right" id="bz">状态：</td>
    <td align="left"><select id="enable">
        <option value="1" id="qy">启用</option>
        <option value="0" id="jy">禁用</option>
    </select></td>
    <td align="right" id="zt"></td>
    <td align="left">
    </td>
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
<div  title="修改登录服务器" >
<div align="center">
<table width="90%"  border="0" cellpadding="1" cellspacing="1" id="uptable">
  <tr align="center" style="background-color:#CDEAFC">
    <td colspan="6"><strong id="up">修改</strong></td>
  </tr>
  <tr>
    <td align="right" id="Td1">服务器代码：</td>
    <td align="left" id="Td2">
        <input type="text" name="serverName" id="mdf1" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onblur="IsNullByInfo(this,'merr1',languages.H1306);" onmouseout="this.className='text_01 h20'" />&nbsp;<span id="merr1" style="color:Red"></span></td>
    <td align="right">网站</td>
    <td align="left">
        <input type="text" name="serverName" id="mdf2" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onblur="IsNullByInfo(this,'merr2',languages.H1306);" onmouseout="this.className='text_01 h20'" />&nbsp;<span id="merr2" style="color:Red"></span></td>
    <td align="right">&nbsp;</td>
    <td align="left">&nbsp;</td>
  </tr>
  <tr>
    <td align="right" id="Td3">服务器IP：</td>
    <td align="left"><input type="text" name="ip1" id="mdf3" class="text_01 h20" onblur="IsNullByInfo(this,'merr3',languages.H1306);" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" />&nbsp;<span id="merr3" style="color:Red"></span></td>
    <td align="right" id="Td4">登录服务器IP：</td>
    <td align="left"><input type="text" name="ip2" id="mdf4" class="text_01 h20" onblur="IsNullByInfo(this,'merr4',languages.H1306);" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" />&nbsp;<span id="merr4" style="color:Red"></span></td>
     <td align="right" id="Td5"></td>
    <td align="left"></td>
  </tr>
  <tr>
    <td align="right" id="Td6"></td>
    <td align="left"></td>
    <td align="right" id="Td7">状态：</td>
    <td align="left">
        <select id="mdf5">
        <option value="1" id="Option1">启用</option>
        <option value="0" id="Option2">禁用</option>
    </select>
    </td>
    <td align="right" id="Td8"></td>
    <td align="left"></td>
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
        <th id="fwqmc3">服务器代码</th>
        <th id="ip3dz1">网站</th>
        <th id="ip3dz2">服务器IP</th>
        <th id="ip3dz3">登录服务器IP</th>
        <th id="2jym">状态</th>
        <th id="up2">修改</th>
        <th id="Th1">删除</th>
        </tr>
        </thead> 
        <tbody id="tab">
        <tr id="datarow">
        <td id="td1"></td>
        <td id="td2"></td>
        <td id="td3"></td>
        <td id="td4"></td>
        <td id="td5"></td>
        <td id="td6"></td>
        <td id="td7"></td>
        </tr>

        </tbody> 
        <tfoot>
        <tr>
        <td colspan="11">

            &nbsp;</td>
        </tr>
        </tfoot>
        </table>


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
