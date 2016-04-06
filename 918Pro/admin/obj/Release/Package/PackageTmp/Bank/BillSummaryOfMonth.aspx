<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillSummaryOfMonth.aspx.cs" Inherits="admin.Bank.BillSummaryOfMonth" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">    
    <title>存取款月汇总表</title>
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
            $("#time1WhereVal,#time2WhereVal").datepicker();
            SetDate();
            GetDetailData();
            $("#selectByWhere").click(function () {
                GetDetailData();

            });
            $(".inputWhere").keyup(function (e) {
                var currKey = 0, e = e || event;
                currKey = e.keyCode || e.which || e.charCode;
                if (currKey == 13) {
                    GetDetailData();
                    $(this).blur();
                }
            });
        });

        //存取款账目明细记录显示
        function GetDetailData() {
            $("#tb2>tbody").html("");
            $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/SumGetDayNoticeHistory", "username:'" + $.trim($("#memberSel").val()) + "',time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "'", true, false, function (json) {
                if (json.d != "") {
                    var re = jQuery.parseJSON(json.d);
                    // alert(json.d);
                    var html = "", total1 = 0, total2 = 0; total3 = 0;

                    $.each(re, function (i) {
                        total1 += parseFloat(re[i].Cgamount);
                        total2 += parseFloat(re[i].Qgamount);
                        total3 += parseFloat(re[i].Ylamount);
                        html += "<tr><td>" + (i + 1) + "</td>";
                        html += "<td>" + re[i].datetime.replace(" 0:00:00", "") + "</td>";
                        html += "<td>" + re[i].Cgamount + "</td>";
                        html += "<td>" + re[i].Qgamount + "</td>";
                        if (parseFloat(re[i].Ylamount) < 0) {
                            html += "<td style='color:red'>" + re[i].Ylamount + "</td>";
                        }
                        else {
                            html += "<td>" + re[i].Ylamount + "</td>";
                        }
                       
                        html += "</tr>";
                    });
                    html += "<tr><td>总计</td><td colspan='1'></td><td >" + total1.toFixed(2) + "</td><td >" + total2.toFixed(2) + "</td>";
                    if (total3.toFixed(2)<0) {
                      html +="<td style='color:red'>" + total3.toFixed(2) + "</td>";
                     }
                     else
                     {
                         html += "<td >" + total3.toFixed(2) + "</td>";
                     }
                   
                    html +="</tr>";
                    $("#tb2>tbody").html(html);


                } else {
                    $("#tb2>tbody").html("<tr><td colspan=\"15\">没有相应数据</td></tr>");
                }
            });           
           
        }
//        function setExcel(divId, hidenId) {
//            var temp = jQuery("#" + divId).html();
//            jQuery("#" + hidenId).val(temp);
//            jQuery("#nameValue").val("");            
//            return true;
//        }
        function SetDate() {
            var now = new Date();
            var year = now.getFullYear();       //年
            var month = now.getMonth() + 1;     //月
            var day = now.getDate();       //日
            month = (month < 9 ? ("0" + month) : month);
            day = (day < 9 ? ("0" + day) : day);
            $("#time1WhereVal").val(year + "-" + month + "-01");
            $("#time2WhereVal").val(year + "-" + month + "-" + day);
        }


    </script>
</head>
<body>
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="zdjs">存取款日报表</p></th>
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
    <a id="hy">帐号</a>&nbsp;&nbsp;<input type="text" id="memberSel" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="jysj">按日期从</a>&nbsp;&nbsp;<input type="text" id="time1WhereVal" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" readonly="readonly"  />－<input type="text" id="time2WhereVal" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" readonly="readonly"  />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in">查询</span></a>&nbsp;&nbsp;&nbsp;&nbsp;<span style=" color:Blue">(注：输入帐号后将查询出此帐号下数据,没输入则是所以玩家数据)</span>
   <%-- <asp:LinkButton runat="server" ID="excel"  OnClientClick="return setExcel('divExcel','hfContent')" Text="导出Excel" onclick="excel_Click"  ></asp:LinkButton>--%>
    <input type="hidden" runat="server" id="hfContent" />
    <input type="hidden" runat="server" id="nameValue" />
    </div>
    </form>
    <div id="divExcel">
    <table class='tab2' id='tb2' width='100%' border='0' cellpadding='0' cellspacing='0'>
    <thead>
    <tr>
    <th >序号</th>
    <th>日期</th>
    <th>日存款</th>
    <th>日取款</th>
    <th >日盈利</th>
    </tr>
    </thead>
    <tbody id='showInfo'>
    </tbody>
    </table>
    </div>
    
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
