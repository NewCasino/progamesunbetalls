<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankManager.aspx.cs" Inherits="admin.Bank.BankManageer" %>

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
            //多语言
            SetGlobal("");
            GetBankAll();
            getSelectBz();
        });
        var f1;
        //---------多语言处理-----------
        var languages = "";
        var lang;
        function SetGlobal(setLang) {

            setLang = $.SetOrGetLanguage(setLang, function () {
                //debugger
                languages = language;
            });
            lang = setLang;
        }
        //--------多语言处理结束---------

        function GetBankAll() {
            $("#tab").html("");
            var url = "/ServicesFile/BankService/BankService.asmx/SelectAll";
            var data = "";
            f1 = jQuery("#datarow").clone(true);
            jQuery.AjaxCommon(url, data, true, false, function (json) {
                if (json.d != "") {
                    var re = jQuery.parseJSON(json.d);
                    var html = "";
                    $.each(re, function (i) {
                        html += "<tr><td>" + (i + 1) + "</td><td>" + re[i].g + "</td><td>" + re[i].b + "</td><td>" + (re[i].j == "1" ? "显示" : "不显示") + "</td><td>" + re[i].h + "</td><td>" + re[i].i + "</td><td>" + re[i].k + "</td><td><a id=\"update\" style=\"cursor:hand\" onclick=\"updateBankInfo(this,'" + re[i].a + "')\"><img title=\"修改\" src=\"/images/Icon/Icon167.png\" /> 修改</a></td><td><a id=\"delete\" style=\"cursor:hand\" onclick=\"deleteBank(this,'" + re[i].a + "')\"><img title=\"删除\" src=\"/images/Icon/Icon141.png\" /> 删除</a></td></tr>";
                    });
                    $("#tab").html(html);
                    jQuery("#tab>tr").mouseover(function () {
                        $(this).siblings().removeClass("trOver").end().addClass("trOver");
                    });
                } else {
                    $("#tab").html("没有相应的数据");
                }
            });
        }
        function add() {
            jQuery("#add").show();
            jQuery("#AddButton").unbind("click");
            jQuery("#AddButton").bind("click", function () {
                var url = "/ServicesFile/BankService/BankService.asmx/AddBankInfo";
                var data = "currency:'" + jQuery("#UIDS").val() + "',bankcn:'" + $("#txtBankcn").val().replace("'", "‘") + "',banktw:'" + $("#txtBanktw").val().replace("'", "‘") + "',banken:'" + $("#txtBanken").val().replace("'", "‘") + "',bankth:'" + $("#txtBankth").val().replace("'", "‘") + "',bankvn:'" + $("#txtBankvn").val().replace("'", "‘") + "',status:'" + jQuery("#txtStatus").val() + "'";
                alert(data);
                jQuery.AjaxCommon(url, data, false, false, function (json) {
                    if (json.d) {
                        jQuery("#add").hide();
                        jQuery.MsgTip({ objId: "#divTip", msg: "新增成功！" });
                        jQuery("#updata").hide().appendTo("#form1");
                        GetBankAll();
                    } else {
                        jQuery.MsgTip({ objId: "#divTip", msg: "新增失败！" });
                    }
                });

            });
            jQuery("#AddCancel").unbind("click");
            jQuery("#AddCancel").bind("click", function () {
                jQuery("#add").hide();
            });
        }
        function updateBankInfo(obj, id) {
            jQuery("#updata").dialog({ modal: false,width: 800,height:220});
            jQuery("#upUIDS").val(jQuery(obj).parent().parent().find("td:eq(1)").text());
            jQuery("#upStatus").val((jQuery(obj).parent().parent().find("td:eq(7)").text() == "显示" ? "1" : "0"));
            jQuery("#upBankcn").val(jQuery(obj).parent().parent().find("td:eq(2)").text());
            jQuery("#upBanktw").val(jQuery(obj).parent().parent().find("td:eq(3)").text());
            jQuery("#upBanken").val(jQuery(obj).parent().parent().find("td:eq(4)").text());
            jQuery("#upBankth").val(jQuery(obj).parent().parent().find("td:eq(5)").text());
            jQuery("#upBankvn").val(jQuery(obj).parent().parent().find("td:eq(6)").text());
            jQuery("#updataButton").unbind("click").bind("click", function () {
                var url = "/ServicesFile/BankService/BankService.asmx/UpdateBankInfo";
                var data = "id:'" + id + "',currency:'" + jQuery("#updata select:eq(0)").val() + "',bankcn:'" + $("#upBankcn").val().replace("'", "‘") + "',banktw:'" + $("#upBanktw").val().replace("'", "‘") + "',banken:'" + $("#upBanken").val().replace("'", "‘") + "',bankth:'" + $("#upBankth").val().replace("'", "‘") + "',bankvn:'" + $("#upBankvn").val().replace("'", "‘") + "',status:'" + $("#upStatus").val() + "'";
                alert(data);
                jQuery.AjaxCommon(url, data, true, false, function (json) {
                    if (json.d) {
                        $.MsgTip({ objId: "#divTip", msg: "修改成功" });
                        $("#updata").dialog("close");
                        GetBankAll();
                    } else {
                        $.MsgTip({ objId: "#divTip", msg: "修改失败" });
                        $("#updata").dialog("close");
                    }
                });
            });
            jQuery("#escButton").unbind("click").bind("click", function () {
                $("#updata").dialog("close");
            });
        }
        function deleteBank(obj,id) {
            jQuery("#delet").dialog({ modal: false });
            jQuery("#deleteEsc").unbind("click");
            jQuery("#deleteEsc").bind("click", function () {
                jQuery("#delet").dialog("close");
            });
            jQuery("#deletebtn").unbind("click");
            jQuery("#deletebtn").bind("click", function () {
                jQuery("#delet").dialog("close");
                var typename = jQuery(obj).parent().parent().find("#tdname").text();
                var url = "/ServicesFile/BankService/BankService.asmx/DeleteBankInfo";
                var data = "id:'" + id + "'";
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
        function getSelectBz() {
            var html = "";
            var url = "/ServicesFile/RateService.asmx/GetRateByLan";
            var data = "language:'" + lang + "'";
            jQuery.AjaxCommon(url, data, true, false, function (json) {
                if (json.d != "none") {
                    var result = jQuery.parseJSON(json.d);
                    jQuery.each(result, function (i) {
                        html += "<option value=" + result[i].code + ">" + result[i].name + "</option>";
                    });
                    jQuery("#UIDS").html(html);
                    jQuery("#upUIDS").html(html);
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
<th width="*" class="tab_top_m"><p id="hlgl">客户银行管理</p></th>
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
<div class="f1"><input type="button" id="addBtn" onclick="add()" class="top_add" onmouseover="this.className='top_add_h'" onmouseout="this.className='top_add'"  value="新增银行卡" /></div>
<%} %>


</div>
<div class="cl"></div>
<div id="add" class="new_tr undis">
<div  title="新增客户银行" >
<div align="center">
<table width="85%"  border="0" cellpadding="1" cellspacing="1" id="addtable">
  <tr align="center" style="background-color:#CDEAFC">
    <td id="addkhyh" colspan="4">新增客户银行</td>
  </tr>
  <tr>
    <td align="right"><span id="khyxbz">币种</span>：</td>
    <td align="left"><select id="UIDS"></select>
    </td>
    <td align="right"><span id="status">状态</span>：</td>
    <td align="left">
         <select id="txtStatus">
            <option value="1">显示</option>
            <option value="0">不显示</option>
         </select>
    </td>
  </tr>
    <tr>
    <td align="right"><span id="hlz1">银行中文名称</span>：</td>
    <td align="left">
         <input type="text" name="txtBankcn" id="txtBankcn" onblur="IsNullByInfo(this,'twlb','不能为空');" class="text_01 h20" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
         <label id="bankcn" style="color:Red"></label>
    </td>
    <td align="right"><span id="Span1">银行繁体名称</span>：</td>
    <td align="left">
         <input type="text" name="txtBanktw" id="txtBanktw" onblur="IsNullByInfo(this,'twlb','不能为空');" class="text_01 h20" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
         <label id="banktw" style="color:Red"></label>
    </td>
  </tr>
    <tr>
    <td align="right"><span id="Span3">银行英文名称</span>：</td>
    <td align="left">
         <input type="text" name="txtBanken" id="txtBanken" onblur="IsNullByInfo(this,'twlb','不能为空');" class="text_01 h20" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
         <label id="banken" style="color:Red"></label>
    </td>
    <td align="right"><span id="Span4">银行泰语名称</span>：</td>
    <td align="left">
         <input type="text" name="txtBankth" id="txtBankth" onblur="IsNullByInfo(this,'twlb','不能为空');" class="text_01 h20" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
         <label id="bankth" style="color:Red"></label>
    </td>
  </tr>
    <tr>
    <td align="right"><span id="Span5">银行越语名称</span>：</td>
    <td align="left">
         <input type="text" name="txtBankvn" id="txtBankvn" onblur="IsNullByInfo(this,'twlb','不能为空');" class="text_01 h20" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
         <label id="bankvn" style="color:Red"></label>
    </td>
    <td align="right"></td>
    <td align="left"></td>
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

<div id="updata" class="new_tr undis" title="修改客户银行">
<div>
<div align="center">
<table width="85%"  border="0" cellpadding="1" cellspacing="1" id="updatetable">
  <tr align="center" style="background-color:#CDEAFC">
    <td colspan="6" id="uphlsz">修改客户银行</td>
  </tr>
  <tr>
    <td align="right"><span id="upcurr">币种</span>：</td>
    <td align="left" ><select id="upUIDS"></select>
    </td>
    <td align="right"><span id="Span6">状态</span>：</td>
    <td align="left">
         <select id="upStatus">
            <option value="1">显示</option>
            <option value="0">不显示</option>
         </select>
    </td>
  </tr>
    <tr>
    <td align="right"><span id="Span7">银行中文名称</span>：</td>
    <td align="left">
         <input type="text" name="upBankcn" id="upBankcn" onblur="IsNullByInfo(this,'twlb','不能为空');" class="text_01 h20" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
         <label id="lbankcn" style="color:Red"></label>
    </td>
    <td align="right"><span id="Span8">银行繁体名称</span>：</td>
    <td align="left">
         <input type="text" name="upBanktw" id="upBanktw" onblur="IsNullByInfo(this,'twlb','不能为空');" class="text_01 h20" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
         <label id="lbanktw" style="color:Red"></label>
    </td>
  </tr>
    <tr>
    <td align="right"><span id="Span9">银行英文名称</span>：</td>
    <td align="left">
         <input type="text" name="upBanken" id="upBanken" onblur="IsNullByInfo(this,'twlb','不能为空');" class="text_01 h20" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
         <label id="lbanken" style="color:Red"></label>
    </td>
    <td align="right"><span id="Span10">银行泰语名称</span>：</td>
    <td align="left">
         <input type="text" name="upBankth" id="upBankth" onblur="IsNullByInfo(this,'twlb','不能为空');" class="text_01 h20" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
         <label id="lbankth" style="color:Red"></label>
    </td>
  </tr>
    <tr>
    <td align="right"><span id="Span11">银行越语名称</span>：</td>
    <td align="left">
         <input type="text" name="upBankvn" id="upBankvn" onblur="IsNullByInfo(this,'twlb','不能为空');" class="text_01 h20" onmouseover="this.className='text_01_h h20'"  onmouseout="this.className='text_01 h20'" />
         <label id="lbankvn" style="color:Red"></label>
    </td>
    <td align="right"></td>
    <td align="left"></td>
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
        <th>序号</th>
        <th>币种</th>
        <th>银行中文名称</th>
       
        <th>状态</th>
        <th >操作人</th>
        <th>操作时间</th>
        <th >IP</th>
        <th>修改</th>
        <th>删除</th>
        </tr>
        </thead> 
        <tbody id="tab">
        <tr id="datarow">
        <td id="tdxh"></td>
        <td id="tdcode"></td>
        <td id="tdcn"></td>
       
        <td id="tdstatus"></td>
        <td id="tdoperator" style="width:80px"></td>
        <td id="tdoperationtime" style="width:80px"></td>
        <%if (upAc)
          { %>
        <td id="tdupdate" style="width:70px"></td>
        <%} %>
        <% if (deleteAc)
           { %>
        <td id="tddelete" style="width:70px"></td>
        <%} %>
        </tr>
        </tbody> 
        <tfoot>
        <tr>
        <td colspan="13">
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