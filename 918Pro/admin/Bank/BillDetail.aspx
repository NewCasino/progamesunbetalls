<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillDetail.aspx.cs" Inherits="admin.Bank.BillDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title>账目明细</title>
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
            //SelectByWhere();
            $("#time1WhereVal,#time2WhereVal").datepicker().click(function () {
                $(this).val("");
            });
            $("#selectByWhere").click(function () {
                if ($.trim($("#memberSel").val()) != "" || $.trim($("#memberName").val()) != "" || $("#typeSel").val() != "0" || $("#time1WhereVal").val() != "" || $("#time2WhereVal").val() != "") {
                    SelectByWhere();
                }
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
        function SelectByWhere() {
            $("#tb2>tbody").html("");
            $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/GetBillDetailByWhere", "userName:'" + $.trim($("#memberSel").val()) + "',name:'" + $.trim($("#memberName").val()) + "',type:'" + $("#typeSel").val() + "',time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "'", true, false, function (json) {
                if (json.d != "") {
                    var re = jQuery.parseJSON(json.d);
                    var html = "", total2 = 0, total3 = 0;
                    $.each(re, function (i) {
                        total2 += parseFloat(re[i].d) - parseFloat(re[i].e);
                        html += "<tr><td>" + (i + 1) + "</td><td>" + re[i].b + "</td><td>" + re[i].j + "</td><td>" + (re[i].c == "1" ? "存款" : "取款") + "</td><td>" + re[i].i + "</td><td>" + (re[i].c == "1" ? ("+" + (parseFloat(re[i].d) == 0 ? "0.00" : parseFloat(re[i].d).toFixed(2))) : ("-" + (parseFloat(re[i].e) == 0 ? "0.00" : parseFloat(re[i].e).toFixed(2)))) + "</td><td>" + re[i].g + "</td><td>" + re[i].f + "</td><td>" + re[i].k + "</td></tr>";
                    });
                    html += "<tr><td>总计</td><td colspan='4'></td><td>" + total2.toFixed(2) + "</td><td colspan='3'></td></tr>";
                    $("#tb2>tbody").html(html);
                    $("#tb2>tbody>tr").mouseover(function () {
                        $(this).siblings().removeClass("trOver").end().addClass("trOver");
                    });
                } else {
                    $("#tb2>tbody").html("<tr><td colspan=\"9\">没有相应数据</td></tr>");
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
<th width="*" class="tab_top_m"><p id="zdjs">账目明细</p></th>
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
    <a id="hyzh">会员帐号</a>&nbsp;&nbsp;<input type="text" id="memberSel" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="hyxm">会员姓名</a>&nbsp;&nbsp;<input type="text" id="memberName" class="inputWhere text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="lx">类型</a>&nbsp;&nbsp;<select id="typeSel"><option value="0">全部</option>
        <option value="1">存款</option><option value="2">取款</option>
    </select>&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="jysj">交易时间</a>&nbsp;&nbsp;<input type="text" id="time1WhereVal" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" readonly="readonly"  />－<input type="text" id="time2WhereVal" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" readonly="readonly"  />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in">搜索</span></a>
    </div>
    <table class="tab2" id="tb2" width="100%" border="0" cellpadding="0" cellspacing="0">
    <thead>
                <tr>
                <th>序号</th>
                <th>会员帐号</th>
                <th>会员名称</th>
                <th>类型</th>
                <th>币种</th>
                <th>操作金额</th>
                <th>交易时间</th>
                <th>余额</th>
                <th>备注</th>
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
