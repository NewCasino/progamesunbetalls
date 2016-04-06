<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillLog.aspx.cs" Inherits="admin.Bank.BillLog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>存款历史记录</title>
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="/js/page/pageJs.js" type="text/javascript"></script>
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="/js/jQueryCommon.js" type="text/javascript"></script>
    <script src="/js/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
    <script src="/js/webBasicInfo/zh-CN.js" type="text/javascript"></script>
    <link href="/css/Default/cupertino/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            SetGlobal("");
        });

        var languages = "";
        var lang;
        function SetGlobal(setLang) {

            setLang = $.SetOrGetLanguage(setLang, function () {
                languages = language;
                $("#time1WhereVal,#time2WhereVal").datepicker().click(function () {
                    $(this).val("");
                });
                $("#selectByWhere").click(function () {
                    SelectByWhere();
                });
                $(".inputWhere").keyup(function (e) {
                    var currKey = 0, e = e || event;
                    currKey = e.keyCode || e.which || e.charCode;
                    if (currKey == 13) {
                        SelectByWhere();
                        $(this).blur();
                    }
                });
            });
            lang = setLang;
        }

        function SelectByWhere() {
            $("#tb2>tbody").html("");
            var url = "/ServicesFile/BankService/BankService.asmx/GetLogbyWhere";
            var data = "typ:'" + jQuery("#txttyp").val() + "',operators:'" + jQuery("#txtoperator").val() + "',operationtimes:'" + jQuery("#time1WhereVal").val() + "',operationtimee:'" + jQuery("#time2WhereVal").val() + "',lan:'" + lang + "'";
            $.AjaxCommon(url, data, true, false, function (json) {
                if (json.d != "") {
                    var re = jQuery.parseJSON(json.d);
                    var html = "";
                    $.each(re, function (i) {
                        html += "<tr>";
                        html += "<td>" + i + 1 + "</td>";
                        html += "<td>" + re[i].UserName + "</td>";
                        html += "<td>" + re[i].Names + "</td>";
                        html += "<td>" + (re[i].Type == "1" ? "存款" : "取款") + "</td>";
                        html += "<td>" + re[i].Currency + "</td>";
                        html += "<td>" + re[i].Amount + "</td>";
                        html += "<td>" + re[i].bank + "</td>";
                        html += "<td>" + re[i].bankaccount + "</td>";
                        html += "<td>" + re[i].bankno + "</td>";
                        html += "<td>" + re[i].SubmitTime + "</td>";
                        html += "<td>" + re[i].UpdateTime + "</td>";
                        html += "<td>" + (re[i].Status == "2" ? "成功" : "拒绝") + "</td>";
                        html += "<td>" + re[i].reason + "</td>";
                        html += "<td>" + re[i].operator + "</td>";
                        html += "<td>" + re[i].operationtime + "</td>";
                        html += "<td>" + re[i].ip + "</td>";

                        html += "</tr>";
                    });
                    $("#tb2>tbody").html(html);
                    $("#tb2>tbody>tr").mouseover(function () {
                        $(this).siblings().removeClass("trOver").end().addClass("trOver");
                    });
                } else {
                    $("#tb2>tbody").html("<tr><td colspan=\"16\">没有相应数据</td></tr>");
                }
            });
        }
       </script>
</head>
<body>
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="zdjs">财务操作日志</p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
    <input type="hidden" id="langue" value="tw" />
    <form id="form1" runat="server">
    <div  style="width:95%;padding:3px;margin:2px;">
    <a id="zt">类型</a>&nbsp;&nbsp;<select id="txttyp"><option value="">请选择</option>
        <option value="1">存款</option><option value="2">取款</option>
    </select>&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="hy">操作人</a>&nbsp;&nbsp;<input type="text" id="txtoperator" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="jysj">时间</a>&nbsp;&nbsp;<input type="text" id="time1WhereVal" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" readonly="readonly"  />－<input type="text" id="time2WhereVal" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" readonly="readonly"  />&nbsp;&nbsp;&nbsp;&nbsp;
    
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in">搜索</span></a>
    </div>
    <table class="tab2" id="tb2" width="100%" border="0" cellpadding="0" cellspacing="0">
    <thead>
                <tr>
               <th>序号</th>
                <th>会员名称</th>
                <th>姓名</th>
                <th>类型</th>
                <th>币种</th>
                <th>金额</th>
                <th>存入银行</th>
                <th>存入帐号</th>
                <th>银行流水</th>
                <th>提交时间</th>
                <th>处理时间</th>
                <th>状态</th>
                <th>原因</th>
                <th>操作人</th>
                <th>操作时间</th>
                <th>IP</th>
    </tr>
    </thead>
    <tbody id="showInfo">
    </tbody>
    </table>
    </form>
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
</body>
</html>