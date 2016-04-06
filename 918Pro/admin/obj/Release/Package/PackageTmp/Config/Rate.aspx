<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rate.aspx.cs" Inherits="admin.Config.Rate" %>

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

            GetRateAll();
        });
        var f1;
        var Names;
        function GetRateAll() {
            var url = "/ServicesFile/RateService.asmx/GetRateAll";
            var data = "";
            f1 = jQuery("#datarow").clone(true);
            jQuery.AjaxCommon(url, data, true, false, function (json) {
                if (json.d != "none") {
                    var result = jQuery.parseJSON(json.d);
                    jQuery("#tab>tr:gt(0)").remove();
                    jQuery.each(result, function (i) {
                        var f = jQuery("#datarow").clone(true);
                        f.find("#tdname").text(result[i].name_cn);
                        f.find("#tdtw").text(result[i].name_tw);
                        f.find("#tden").text(result[i].name_en);
                        f.find("#tdth").text(result[i].name_th);
                        f.find("#tdvn").text(result[i].name_vn);
                        f.find("#tdcode").html(result[i].code);
                        f.find("#tdrate").html(result[i].rate);
                        f.find("#tdoperator").text(result[i].operator);
                        f.find("#tdupdate").html("<a id=\"update\" style=\"cursor:hand\" onclick=\"edit(this,'" + result[i].id + "')\"><img title=\"修改\" src=\"/images/Icon/Icon167.png\" /> "+languages.H1009+"</a>");
                        f.find("#tddelete").html("<a id=\"delete\" style=\"cursor:hand\" onclick=\"delet(this,'" + result[i].id + "')\"><img title=\"删除\" src=\"/images/Icon/Icon141.png\" /> "+languages.H1052+"</a>");
                        f.appendTo("#tab");

                    });
                    jQuery("#tab>tr:eq(0)").remove();
                }
                else {

                }
            });
        }

         //---------多语言处理-----------
        var languages = "";
        var lang;
        function SetGlobal(setLang) {

            setLang = $.SetOrGetLanguage(setLang, function () {
                //debugger
                languages = language;
                
               
                $("#addBtn").attr("value", languages.H1189);
                $("#AddButton").attr("value", languages.H1015);
                $("#AddCancel").attr("value", languages.H1011);
                $("#updataButton").attr("value", languages.H1037);
                $("#escButton").attr("value", languages.H1011);

                //$("#RetaType").html(languages.H1191);
                $("#ExchangeValue").html(languages.H1199);
                $("#Created").html(languages.H1200);
                $("#Operator").html(languages.H1201);
                $("#ip").html(languages.H1235);
                $("#up").html(languages.H1009);
                $("#del").html(languages.H1052);
                $("#hlgl").html(languages.H2003);

                $("#addhlsz").html(languages.H1190);
                $("#hllx").html(languages.H1191);
                $("#hlz").html(languages.H1199);

                $("#uphlsz").html(languages.H1190);
                $("#uphllx").html(languages.H1191);
                $("#uphlz").html(languages.H1199);
    

               
            });
            lang = setLang;
        }
        //--------多语言处理结束---------


        function SelectName(name) {
            var data = "Name:'" + name + "',Language:'" + $("#language").val() + "'";
            jQuery.AjaxCommon("/ServicesFile/RateService.asmx/CeliName", data, false, false, function (json) {
                Names = json.d;
            });
        }

        function add() {
            jQuery("#add").show();
            $("#Name").blur(function () {
                if ($("#Name").val() == "") {
                    //$("#Namelbl").html("不能为空");
                    $("#Namelbl").html(languages.H1000);
                    return false;
                }
                SelectName($("#Name").val());
                if (Names == "True") {
                   // $("#Namelbl").html("匯率類型已經存在");
                   $("#Namelbl").html(languages.H1181);
                    return false;
                } else {
                    $("#Namelbl").html("");
                }
            });
            $("#Rate").blur(function () {
                if ($("#Rate").val() == "") {
                    //$("#Ratelbl").html("不能为空");
                    $("#Ratelbl").html(languages.H1000);
                    return false;
                } else {
                    var namePattern = /^-?\d+\.?\d{0,4}$/;
                    if (!namePattern.test($("#Rate").val()) ) {
                        //$("#Ratelbl").html("非0数字,小数位不能超过4位");H1182
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

                //jQuery("#code").blur();
                var check = true;
                jQuery.each(jQuery("#addtable :text"),function(i,n){
                    jQuery(n).blur();
                });

                if ($("#Rate").val() == "") {
                    //$("#Ratelbl").html("不能为空");
                     $("#Ratelbl").html(languages.H1000);
                    return false;
                } else {
                    var namePattern = /^-?\d+\.?\d{0,4}$/;
                    if (!namePattern.test($("#Rate").val())) {
                       // $("#Ratelbl").html("非0数字,小数位不能超过4位");
                         $("#Ratelbl").html(languages.H1182);
                        return false;
                    } else {
                        $("#Ratelbl").html("");
                    }
                }

//                if(jQuery("#codelb").html() != ""){
//                    return false;
//                }
                jQuery.each(jQuery("#addtable label"),function(i,n){
                    if(jQuery(n).html() != ""){
                        check = false;
                    }
                });
                if(!check){
                    return check;
                }

                var url = "/ServicesFile/RateService.asmx/AddRate1";
                var data = "code:'" + jQuery("#code").val() + "',cn:'" + jQuery("#cn").val() +"',tw:'" + jQuery("#tw").val() + "',en:'" + jQuery("#en").val() + "',th:'" + jQuery("#th").val() + "',vn:'" + jQuery("#vn").val() + "',Rate:'" + jQuery("#Rate").val() + "'";
                jQuery.AjaxCommon(url, data, false, false, function (json) {
                    if (json.d != "none") {
                        jQuery("#add").hide();
                        var result = jQuery.parseJSON(json.d);
                        jQuery.each(result, function (i) {

                            var f = jQuery("#datarow").clone(true);
                            f.find("#tdname").text(result[i].name_cn);
                            f.find("#tdtw").text(result[i].name_tw);
                            f.find("#tden").text(result[i].name_en);
                            f.find("#tdth").text(result[i].name_th);
                            f.find("#tdvn").text(result[i].name_vn);
                            f.find("#tdcode").text(result[i].Code);
                            f.find("#tdrate").text(parseFloat(result[i].Rate).toFixed(4));
                            f.find("#tdlasttime").text(result[i].Lasttime);
                            f.find("#tdoperator").text(result[i].Operator);
                            f.find("#tdip").text(result[i].Ip);
                            <%if(upAc){ %>
                            f.find("#tdupdate").html("<a id=\"update\" style=\"cursor:hand\" onclick=\"edit(this,'" + result[i].Id + "')\"><img title=\"修改\" src=\"/images/Icon/Icon167.png\" /> "+languages.H1009+"</a>");
                            <%} %>
                            <%if(deleteAc){ %>
                            f.find("#tddelet").html("<a id=\"delet\" style=\"cursor:hand\" onclick=\"delet(this,'" + result[i].Id + "')\"><img title=\"删除\" src=\"/images/Icon/Icon141.png\" /> "+languages.H1052+"</a>");
                            <%} %>
                            f.appendTo("#tab");
                        });

                        //jQuery.MsgTip({ objId: "#divTip", msg: "增加汇率成功" });
                        jQuery.MsgTip({ objId: "#divTip", msg: languages.H1183 });
                        jQuery("#updata").hide().appendTo("#form1");
                        GetRateAll();
                    }
                    else {
                        //jQuery.MsgTip({ objId: "#divTip", msg: "增加汇率失败" });
                        jQuery.MsgTip({ objId: "#divTip", msg: languages.H1184 });
                    }
                });

                $("#Name").val("");
                $("#Rate").val("");
            });
            jQuery("#AddCancel").unbind("click");
            jQuery("#AddCancel").bind("click", function () {
                jQuery("#add").hide();
                $("#Namelbl").html("");
                $("#Ratelbl").html("");
            });
        }


        function edit(obj, id) {
            jQuery("#updata").hide().appendTo("#form1");
            f1.find("td:gt(0)").remove();
            f1.find("td:eq(0)").text("");
            f1.find("td:eq(0)").attr("colspan", "11");
            jQuery("#updata").show();
            $("#serverId").val(id);
            jQuery("#upcn").val(jQuery(obj).parent().parent().find("#tdname").text());
            jQuery("#uptw").val(jQuery(obj).parent().parent().find("#tdtw").text());
            jQuery("#upen").val(jQuery(obj).parent().parent().find("#tden").text());
            jQuery("#upth").val(jQuery(obj).parent().parent().find("#tdth").text());
            jQuery("#upvn").val(jQuery(obj).parent().parent().find("#tdvn").text());
            var uName = jQuery(obj).parent().parent().find("#tdname").text();
            jQuery("#uRate").val(jQuery(obj).parent().parent().find("#tdrate").text());
            jQuery("#mdfcode").val(jQuery(obj).parent().parent().find("#tdcode").html());
            f1.find("td:eq(0)").append(jQuery("#updata"));
            jQuery(obj).parent().parent().after(f1.show());
            $("#uName").blur(function () {
                if ($("#uName").val() == "") {
                    //$("#uNamelbl").html("不能为空");
                     $("#uNamelbl").html(languages.H1000);
                    return false;
                } else {
                    $("#uNamelbl").html("");
                }

            });

            $("#uRate").blur(function () {
                if ($("#uRate").val() == "") {
                    //$("#uRatelbl").html("不能为空");
                    $("#uRatelbl").html(languages.H1000);
                    return false;
                } else {
                    var namePattern = /^-?\d+\.?\d{0,4}$/;
                    if (!namePattern.test($("#uRate").val())) {
                        //$("#uRatelbl").html("非0数字,小数位不能超过4位");
                        $("#uRatelbl").html(languages.H1182);
                        return false;
                    }
                    else {
                        $("#uRatelbl").html("");
                    }
                }
            });
                jQuery("#updataButton").unbind("click");
                jQuery("#updataButton").bind("click", function () {
                    //var id = $("#serverId").val();

                    //jQuery("#mdfcode").blur();
                    var check = true;
                    jQuery.each(jQuery("#updatetable :text"),function(i,n){
                        jQuery(n).blur();
                    });

                    if ($("#uName").val() == "") {
                        //$("#uNamelbl").html("不能为空");
                        $("#uNamelbl").html(languages.H1000);
                        return false;
                    } else {
                        $("#uNamelbl").html("");
                    }

                    if ($("#uRate").val() == "") {
                        //$("#uRatelbl").html("不能为空");
                        $("#uRatelbl").html(languages.H1000);
                        return false;
                    } else {
                        var namePattern = /^-?\d+\.?\d{0,4}$/;
                        if (!namePattern.test($("#uRate").val())) {
                            //$("#uRatelbl").html("非0数字,小数位不能超过4位");
                             $("#uRatelbl").html(languages.H1182);
                            return false;
                        }
                        else {
                            $("#uRatelbl").html("");
                        }
                    }

                    jQuery.each(jQuery("#updatetable label"),function(i,n){
                        if(jQuery(n).html() != ""){
                            check = false;
                        }
                    });
                    if(!check){
                        return check;
                    }

                    var data = "code:'" + jQuery("#mdfcode").val() + "',Id:'" + id + "',cn:'" + jQuery("#upcn").val() + "',tw:'" + jQuery("#uptw").val() + "',en:'" + jQuery("#upen").val() + "',th:'" + jQuery("#upth").val() + "',vn:'" + jQuery("#upvn").val() + "',uName:'" + uName + "',Rate:'" + jQuery("#uRate").val() + "'";

                    jQuery.AjaxCommon("/ServicesFile/RateService.asmx/UpdateRate1", data, false, false, function (json) {
                        if (json.d != "stop") {
                            $("#uNamelbl").html("");
                            if (json.d != "none") {
                               // $.MsgTip({ objId: "#divTip", msg: "修改成功" });
                                $.MsgTip({ objId: "#divTip", msg: languages.H1012 });
                                jQuery("#updata").parent().parent().hide();
                                var result = jQuery.parseJSON(json.d);
                                jQuery.each(result, function (i) {
                                    jQuery(obj).parent().parent().find("#tdname").html(jQuery("#upcn").val());
                                    jQuery(obj).parent().parent().find("#tdtw").html(jQuery("#uptw").val());
                                    jQuery(obj).parent().parent().find("#tden").html(jQuery("#upen").val());
                                    jQuery(obj).parent().parent().find("#tdth").html(jQuery("#upth").val());
                                    jQuery(obj).parent().parent().find("#tdvn").html(jQuery("#upvn").val());
                                    jQuery(obj).parent().parent().find("#tdcode").html(jQuery("#mdfcode").val());
                                    jQuery(obj).parent().parent().find("#tdrate").html(parseFloat(result[i].Rate1).toFixed(4));
                                });
                            }
                            else {
                               // $.MsgTip({ objId: "#divTip", msg: "修改失败" });
                                $.MsgTip({ objId: "#divTip", msg: languages.H1013 });
                            }
                        } else {
                            //$("#uNamelbl").html("匯率類型已經存在");
                            $("#uNamelbl").html(languages.H1181);
                        }
                    });

                });
            
            jQuery("#escButton").unbind("click");
            jQuery("#escButton").bind("click", function () {
                $("#uNamelbl").html("");
                $("#uRatelbl").html("");
                jQuery("#updata").parent().parent().hide();
            });
        }

        function delet(obj,id) {
            jQuery("#delet").dialog({ modal: false });

            jQuery("#deleteEsc").unbind("click");
            jQuery("#deleteEsc").bind("click", function () {
                jQuery("#delet").dialog("close");
            });

            jQuery("#deletebtn").unbind("click");
            jQuery("#deletebtn").bind("click", function () {
                jQuery("#delet").dialog("close");
                var typename = jQuery(obj).parent().parent().find("#tdname").text();
                var url = "/ServicesFile/RateService.asmx/DeleteRole";
                var data = "Id:" + id + ",Name:'" + typename + "',Language:'" + $("#language").val() + "'";
                jQuery.AjaxCommon(url, data, false, false, function (json) {
                    if (json.d) {
                        $(obj).parent().parent().remove();
                        //$.MsgTip({ objId: "#divTip", msg: "删除成功" });
                        $.MsgTip({ objId: "#divTip", msg: languages.H1073 });
                    }
                    else {
                        //$.MsgTip({ objId: "#divTip", msg: "删除失败" });
                        $.MsgTip({ objId: "#divTip", msg: languages.H1186 });
                    }
                });
            });
        }

        function cstatus(obj) {
            var curId = $(obj).attr("id").substr(1);
            //var status = $(obj).text() == "启用" ? "1" : "0";
            var status = $(obj).text() == languages.H1049 ? "1" : "0";
            var url = "/ServicesFile/RoleRightService/RoleRightService.asmx/ChangeStatus";
            var data = "status:'" + status + "',Id:" + curId;
            jQuery.AjaxCommon(url, data, false, false, function (json) {
                if (json.d) {
                    //$(obj).text($(obj).text() == "启用" ? "禁用" : "启用");
                    $(obj).text($(obj).text() == languages.H1049 ? languages.H1050 : languages.H1049);
                    //$.MsgTip({ objId: "#divTip", msg: "操作成功" });
                    $.MsgTip({ objId: "#divTip", msg: languages.H1187 });
                }
                else {
                    //$.MsgTip({ objId: "#divTip", msg: "操作失败" });
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
<th width="*" class="tab_top_m"><p id="hlgl">汇率管理</p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<!--主题部分开始=========================================================================================-->
<input type="hidden" id="langue" value="tw" />
<div class="top_banner h30">


<%if (addAc)
  { %>
<div class="f1"><input type="button" id="addBtn" onclick="add()" class="top_add" onmouseover="this.className='top_add_h'" onmouseout="this.className='top_add'"  value="新增汇率" /></div>
<%} %>


</div>
<div class="cl"></div>
<div id="add" class="new_tr undis">

<div  title="新增汇率" >
<div align="center">
<table width="85%"  border="0" cellpadding="1" cellspacing="1" id="addtable">
  <tr align="center" style="background-color:#CDEAFC">
    <td id="addhlsz" colspan="6">汇率设置</td>
  </tr>
  <tr>
    <td align="right"><span id="hllx1">简体</span>：</td>
    <td align="left" id="UIDS">
        <input type="text" name="cn" id="cn" onblur="IsNullByInfo(this,'Namelbl','不能为空');" class="text_01 h20"  onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
        <label id="Namelbl" style="color:Red"></label>
    </td>

    <td align="right"><span id="hlz1">繁体</span>：</td>
    <td align="left">
         <input type="text" name="tw" id="tw" onblur="IsNullByInfo(this,'twlb','不能为空');" class="text_01 h20" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
         <label id="twlb" style="color:Red"></label>
    </td>

    <td align="right"><span id="Span1">英文</span>：</td>
    <td align="left">
         <input type="text" name="en" id="en" onblur="IsNullByInfo(this,'enlb','不能为空');" onblur="IsNullByInfo(this,'codelb','不能为空');" class="text_01 h20" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
         <label id="enlb" style="color:Red"></label>
    </td>

  </tr>

    <tr>
    <td align="right"><span id="Span3">泰文</span>：</td>
    <td align="left" id="Td1">
        <input type="text" name="th" id="th" onblur="IsNullByInfo(this,'thlb','不能为空');" class="text_01 h20"  onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
        <label id="thlb" style="color:Red"></label>
    </td>

    <td align="right"><span id="Span4">越南</span>：</td>
    <td align="left">
         <input type="text" name="vn" id="vn" onblur="IsNullByInfo(this,'vnlb','不能为空');" class="text_01 h20" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
         <label id="vnlb" style="color:Red"></label>
    </td>

    <td align="right"><span id="Span5"></span></td>
    <td align="left">
    </td>

  </tr>

  <tr>
    <td align="right"><span id="Span7">汇率值</span>：</td>
    <td align="left">
         <input type="text" name="Rate" id="Rate" class="text_01 h20" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
         <label id="Ratelbl" style="color:Red"></label>
    </td>

    <td align="right"><span id="Span8">汇率代码</span>：</td>
    <td align="left">
         <input type="text" name="code" id="code" onblur="IsNullByInfo(this,'codelb','不能为空');" class="text_01 h20" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
         <label id="codelb" style="color:Red"></label>
    </td>

    <td align="right"><span id="Span6"></span></td>
    <td align="left" id="Td2">
    </td>

  </tr>

  <tr>
    <td align="right" colspan="6" style="height:20px;"><input type="hidden" id="language" value="tw"/></td>
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
<div  title="修改汇率" >
<div align="center">
<table width="85%"  border="0" cellpadding="1" cellspacing="1" id="updatetable">
  <tr align="center" style="background-color:#CDEAFC">
    <td colspan="6" id="uphlsz">汇率设置</td>
  </tr>
  <tr>
    <td align="right"><span id="uphllx1">简体</span>：</td>
    <td align="left">
        <input type="text" name="upcn" id="upcn" class="text_01 h20" onblur="IsNullByInfo(this,'upcnlb','不能为空');"  onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
        <label id="upcnlb" style="color:Red"></label>
    </td>

    <td align="right"><span id="uphlz1">繁体</span>：</td>
    <td align="left">
         <input type="text" name="uptw" id="uptw" onblur="IsNullByInfo(this,'uptwlb','不能为空');" class="text_01 h20" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
         <label id="uptwlb" style="color:Red"></label>
    </td>

    <td align="right"><span id="Span2">英文</span>：</td>
    <td align="left">
         <input type="text" name="upen" id="upen" onblur="IsNullByInfo(this,'upenlb','不能为空');" onblur="IsNullByInfo(this,'mdfcodelb','不能为空');" class="text_01 h20" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
         <label id="upenlb" style="color:Red"></label>
    </td>

  </tr>

    <tr>
    <td align="right"><span id="Span9">泰文</span>：</td>
    <td align="left">
        <input type="text" name="upth" id="upth" onblur="IsNullByInfo(this,'upthlb','不能为空');" class="text_01 h20"  onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
        <label id="upthlb" style="color:Red"></label>
    </td>

    <td align="right"><span id="Span10">越南</span>：</td>
    <td align="left">
         <input type="text" name="upvn" id="upvn" onblur="IsNullByInfo(this,'upvnlb','不能为空');" class="text_01 h20" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
         <label id="upvnlb" style="color:Red"></label>
    </td>

    <td align="right"><span id="Span11"></span></td>
    <td align="left">
    </td>

  </tr>

  <tr>

    <td align="right"><span id="Span13">汇率值</span>：</td>
    <td align="left">
         <input type="text" name="uRate" id="uRate" class="text_01 h20" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
         <label id="uRatelbl" style="color:Red"></label>
    </td>

    <td align="right"><span id="Span14">汇率代码</span>：</td>
    <td align="left">
         <input type="text" name="mdfcode" id="mdfcode" onblur="IsNullByInfo(this,'mdfcodelb','不能为空');" class="text_01 h20" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
         <label id="mdfcodelb" style="color:Red"></label>
    </td>

    <td align="right"><span id="Span12"></span></td>
    <td align="left">
    </td>

  </tr>

  <tr style="height:20px">
  <td align="right" colspan="6" style="height:20px;"></td>
  </tr>
  <tr>
    <td colspan="6" align="center" >
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
        <th id="RetaType">简体</th>
        <th id="tdtw1">繁体</th>
        <th id="tden1">英文</th>
        <th id="tdth1">泰文</th>
        <th id="tdvn1">越南</th>
        <th id="Th1">代码</th>
        <th id="ExchangeValue">汇率值</th>
        <th id="Operator">操作人</th>
        <%if (upAc)
          { %>
        <th id="up">修改</th>
        <%} %>
        <%if (deleteAc)
          { %>
        <th id="del">删除</th>
        <%} %>
        </tr>
        </thead> 
        <tbody id="tab">
        <tr id="datarow">
        <td id="tdname"></td>
        <td id="tdtw"></td>
        <td id="tden"></td>
        <td id="tdth"></td>
        <td id="tdvn"></td>
        <td id="tdcode"></td>
        <td id="tdrate"></td>
        <td id="tdoperator" style="width:80px"></td>
         <%if (upAc)
           { %>
        <td id="tdupdate" style="width:70px"></td>
        <%} %>
         <%if (deleteAc)
           { %>
        <td id="tddelete" style="width:70px"></td>
        <%} %>
        </tr>
        </tbody> 
        <tfoot>
        <tr>
        <td colspan="9">

            &nbsp;</td>
        </tr>
        </tfoot>
        </table>

<div class="undis">

<div id="delet" title="删除提示" >
<div class="showdiv">
<p class="wrnning">确定要删除此项吗？</p>
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
