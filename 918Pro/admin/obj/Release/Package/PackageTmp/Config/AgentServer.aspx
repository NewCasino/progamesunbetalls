<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgentServer.aspx.cs" Inherits="admin.Config.AgentServer" %>

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
        .over{background-color: rgb(220, 240, 253);}

    </style>
    <script type="text/javascript">
        jQuery(function () {

            SetGlobal("");
        });

        //---------多语言处理-----------
        var languages = "";
        var lang;
        function SetGlobal(setLang) {

            setLang = $.SetOrGetLanguage(setLang, function () {
                languages = language;
                LoadData();

//                $("#H1052").html(languages.H1052);
//                $("#delet").attr("title",languages.H1052);
//                $("#addEnable option:eq(0)").text(languages.H1049);
//                $("#addEnable option:eq(1)").text(languages.H1050);
//                $("#pwd").html(languages.H1061);
//                $("#H1061").html(languages.H1061);
//                $("#zhgl").html(languages.H1308);
//                $("#addBtn").val(languages.H1309);
//                $("#zh").html(languages.H1218);
//                $("#js").html(languages.H1310);
//                $("#cjsj").html(languages.H1311);
//                $("#gxsj").html(languages.H1312);
//                $("#cjr").html(languages.H1313);
//                $("#zt").html(languages.H1070);
//                $("#pwd").html(languages.H1061);
//                $("#H1009").html(languages.H1009);
//                $("#H1052").html(languages.H1052);
//                $("#add").attr("title",languages.H1309);
//                $("#addEnable option:eq(0)").text(languages.H1049);
//                $("#addEnable option:eq(1)").text(languages.H1050);
//                $("#edit").attr("title",languages.H1316);
//                $("#cpwd").attr("title",languages.H1317);
//                $("#delet").attr("title",languages.H1052);

//                $("#Azh").html(languages.H1218);
//                $("#Ajs").html(languages.H1310);
//                $("#H1061").html(languages.H1061);
//                $("#Aqrmm").html(languages.H1314);
//                $("#Azt").html(languages.H1070);
//                $("#AddButton").val(languages.H1315);
//                $("#addCancel").val(languages.H1011);
//                $("#Mzh").html(languages.H1218);
//                $("#Mmm").html(languages.H1218);

//                $("#Mjs").html(languages.H1310);
//                $("#button2").val(languages.H1315);
//                $("#mdfCancel").val(languages.H1011);
//                $("#xgmm").html(languages.H1317);
//                $("#qrmm").html(languages.H1314);
//                $("#mdfpasswordbtn").val(languages.H1315);
//                $("#passwordCancel").val(languages.H1011);
//                $("#qdyscm").html(languages.H1494+"&nbsp;<span id=\"delManagerId\" style=\"color:Red;\"></span>&nbsp;"+languages.H1495);
//                $("#deletebtn").val(languages.H1037);
//                $("#deletecancel").val(languages.H1011);
//                $("#add").attr("title",languages.H1309);
//                $("#xgmm").html(languages.H1317);
//                $("#qrmm").html(languages.H1314);
            });
            lang = setLang;
        }
        //--------多语言处理结束---------

        var bindAddRoleId = false;
        var bindMdfRoleId = false;

        function LoadData() {
            var url = "/ServicesFile/agentservers.asmx/GetServer";
            var data = "";
            jQuery.AjaxCommon(url, data, true, false, function (json) {
                if (json.d != "none") {
                    var result = jQuery.parseJSON(json.d);
                    //var result = eval("(" + json.d + ")");
                    jQuery("#tab>tr:gt(0)").remove();

                    jQuery.each(result, function (i) {
                        //alert(result[i].ManagerId);
                        var f = jQuery("#datarow").clone(true);
                        f.find("#sn").text(i+1);
                        f.find("#ip").text(result[i].Ip);
                            
                        f.find("#port").text(result[i].Port);

                        f.find("#tdEnable").html(result[i].Enable == "1" ? languages.H1049 : languages.H1050);                        <% if(mdfAc) { %>
                        f.find("#mdf").html("<a href=\"javascript:void(0)\" onclick=\"edit(this)\" id=m\"" + result[i].Id + "\" class=\"edit_01\" >" + languages.H1009 + "</a>");
                        <% } %>
                        <% if(deleteAc) { %>
                            f.find("#del").html("<a href=\"javascript:void(0)\" class=\"delet_01\" id=d\"" + result[i].Id + "\" onclick=\"delet(this)\">" + languages.H1052 + "</a>");
                        <% } %>

                        f.appendTo("#tab");

                    });
                    jQuery("#tab>tr:eq(0)").remove();
                    $("#tab>tr").mouseover(function(){
                        $(this).siblings().removeClass("over").end().addClass("over");
                    });
                }
                else {
                    
                }
            });

        }

        function add() {
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
                    var url = "/ServicesFile/agentservers.asmx/AddServer";
                    var data = "ip:'" + jQuery("#addip").val() + "',port:" + jQuery("#addport").val() + ",enable:" + jQuery("#addEnable").val();
                    jQuery.AjaxCommon(url, data, true, false, function (json) {
                        if(json.d) {
                            jQuery("#add").dialog("close");
                            LoadData();
                        }
                    });

                });

                jQuery("#addCancel").unbind("click");
                jQuery("#addCancel").bind("click", function () {
                    jQuery("#add").dialog("close");
                });


            //清空数据
            jQuery.each(jQuery("#add :text"), function (i, n) {
                jQuery(n).val("");
            });
            jQuery.each(jQuery("#add :password"), function (i, n) {
                jQuery(n).val("");
            });
            jQuery.each(jQuery("#add label[id*=Err]"), function (i, n) {
                jQuery(n).html("");
            });

            jQuery("#add").dialog({ modal: true,width:333 });
        }

        function edit(obj) {
            jQuery("#uip").val($(obj).parent().siblings("td:eq(1)").text());
            jQuery("#uport").val($(obj).parent().siblings("td:eq(2)").text());
            jQuery("#uEnable").val(($(obj).parent().siblings("td:eq(3)").text()=="启用"?"1":"0"));
            jQuery("#edit").dialog({ modal: true });

            jQuery("#button2").unbind("click");
            jQuery("#button2").bind("click", function () {
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
                var currId = $(obj).attr("id").substr(1);
                var url = "/ServicesFile/agentservers.asmx/UpdateServer";
                var data = "ip:'" + jQuery("#uip").val() + "',port:" + jQuery("#uport").val() + ",enable:" + jQuery("#uEnable").val() + ",id:" + currId;
                jQuery.AjaxCommon(url, data, true, false, function (json) {
                    if (json.d) {
                        LoadData();
                    }
                    else {
                        $.MsgTip({ objId: "#divTip", msg: languages.H1303, delayTime: "2000" });
                    }
                });
            });

            jQuery("#mdfCancel").unbind("click");
            jQuery("#mdfCancel").bind("click", function () {
                jQuery("#edit").dialog("close");
            });
        }

        function Cstatus(obj) {
            
            var currId = $(obj).attr("id").substr(1);
            var enabletxt = $(obj).text() == languages.H1049 ? "1" : "0";
            var url = "/ServicesFile/UserService.asmx/UpdateManagerStatus";
            var data = "Enable:" + enabletxt + ",ID:" + currId;
            jQuery.AjaxCommon(url, data, false, false, function (json) {
                if (json.d) {
                    $(obj).text($(obj).text() == languages.H1049 ? languages.H1050 : languages.H1049);
                    //tip("#divTip", "操作成功");
                    $.MsgTip({objId:"#divTip",msg:languages.H1187,delayTime:"1000"});
                }
                else {
                    //tip("#divTip", "操作失败");
                    $.MsgTip({ objId: "#divTip", msg: languages.H1188, delayTime: "1000" });
                }
            });
        }

        function delet(obj) {
             //jQuery("#delManagerId").html($(obj).parent().siblings("td:eq(0)").text());
            jQuery("#delet").dialog({ modal: true
                //,close:function(){
                //var position= jQuery("#delet").position();
                //alert (jQuery("#delet").css("left"));
                //alert(position.top);

                // }

            });
            jQuery("#deletecancel").unbind("click");
            jQuery("#deletecancel").bind("click", function () {
                jQuery("#delet").dialog("close");
            });

            jQuery("#deletebtn").unbind("click");
            jQuery("#deletebtn").bind("click", function () {
                jQuery("#delet").dialog("close");
                var currId = $(obj).attr("id").substr(1);
                var url = "/ServicesFile/agentservers.asmx/DeleteServer";
                var data = "id:" + currId;
                jQuery.AjaxCommon(url, data, false, false, function (json) {
                    if (json.d) {
                        $(obj).parent().parent().remove();
                    }
                    else {
                        $.MsgTip({ objId: "#divTip", msg: languages.H1186 });
                    }
                });

            });
        }

        function callback() {


        };

        function edit_name() {
            document.getElementById("name").disabled = ""

        }

        function checkUser(obj) {
            var bb = IsNullByInfo(obj, "addErr1", languages.H1306);
            if (bb) {
                var url = "/ServicesFile/UserService.asmx/IsExistManager";
                var data = "managerId:'" + jQuery(obj).val() + "'";
                jQuery.AjaxCommon(url, data, false, false, function (json) {
                    if (json.d) {
                        jQuery("#addErr1").html(languages.H1307);
                    }
                    else {
                        jQuery("#addErr1").html();
                    }
                });
            }
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
<th width="*" class="tab_top_m"><p id="zhgl">代理服务器</p></th>
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



<div class="f1"><input type="button" id="addBtn" onclick="add()" class="top_add" onmouseover="this.className='top_add_h'" onmouseout="this.className='top_add'"  value="增加服务器" /><input type="button" id="ref" onclick="window.open('http://www.158bet.com/agentservers.aspx');" class="top_add" onmouseover="this.className='top_add_h'" onmouseout="this.className='top_add'"  value="刷新" /></div>



</div>
<% } %>
<div class="cl"></div>
<table id="tab3" width=100% cellpadding=0 cellspacing="0" border=0 >
<thead> 
<tr>
<th id="zh">序号</th>
<th id="js">IP</th>
<th id="cjsj">端口</th>
<th id="zt">状态</th>
<% if (mdfAc)
   { %>
<th id="H1009">修改</th>
<% } %>
<% if (deleteAc)
   { %>
<th id="H1052">删除</th>
<% } %>
</tr>
</thead> 
<tbody id="tab">
<tr id="datarow">
<td id="sn"></td>
<td id="ip"></td>
<td id="port"></td>
<td id="tdEnable"></td>
<% if (mdfAc)
   { %>
<td id="mdf"></td>
<% } %>
<% if (deleteAc)
   { %>
<td id="del"></td>
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

<div id="add" title="增加" >
<div class="showdiv">
<ul>
<li><p><label id="Azh">　IP　</label>：</p><p><input type="text" id="addip" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="IsNull(this,'addErr1');" /> </p><label id="addErr1" style="color:Red"></label></li>
<li><p><label id="Ajs">端　口</label>：</p><p><input type="text" id="addport" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="IsNull(this,'addErr2');" /> </p><label id="addErr2" style="color:Red"></label></li>
<li><p><label id="Azt">状　态</label>：</p><p>
    <select id="addEnable">
        <option value="1">启用</option>
        <option value="0">禁用</option>
    </select> </p></li>
<li><div align="center" class="mtop_30">
    <input type="button" id="AddButton" class="btn_02" value="提交" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="addCancel" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    </div></li>
</ul>
</div>
</div>


<div id="edit" title="修改" >
<div class="showdiv">
<ul>
<li><p><label id="Label1">　IP　</label>：</p><p><input type="text" id="uip" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="IsNull(this,'mdfErr1');" /> </p><label id="mdfErr1" style="color:Red"></label></li>
<li><p><label id="Label3">端　口</label>：</p><p><input type="text" id="uport" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" onblur="IsNull(this,'mdfErr2');" /> </p><label id="mdfErr2" style="color:Red"></label></li>
<li><p><label id="Label5">状　态</label>：</p><p>
    <select id="uEnable">
        <option value="1">启用</option>
        <option value="0">禁用</option>
    </select> </p></li>
<li><div align="center" class="mtop_30">
    <input type="button" id="button2" class="btn_02" value="提交" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="mdfCancel" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></div></li>
</ul>
</div>
</div>


<div id="delet" title="删除" >
<div class="showdiv">
<p class="wrnning" id="qdyscm">确定要删除&nbsp;<span id="delManagerId" style="color:Red;"></span>&nbsp;吗？</p>
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
<asp:hiddenfield ID="roleid" runat="server"></asp:hiddenfield>
    </form>
</body>
</html>