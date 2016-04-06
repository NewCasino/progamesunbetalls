<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bank.aspx.cs" Inherits="admin.User.Bank" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.4.1.min.js"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/jQueryCommon.js"></script>
    <script type="text/javascript">
        $(function () {
            //审核存取款
            $("a[attr]").click(function () {
                $.AjaxCommon("/ServicesFile/User/BankService.asmx/VerifyBillNotice", "updateTime:'',status:'',reason:'',id:'" + $(this).attr("attr") + "'", true, false, function (json) {
                    if (json.d) {
                        alert("审核成功");
                        GetBillNotice();
                    } else {
                        alert("审核失败");
                    }
                });
            });
        });

        //未审核存款记录显示 
        function GetBillNotice() {
            $.AjaxCommon("/ServicesFile/User/BankService.asmx/GetBillNoticeByType", "type:'1'", true, false, function (json) {
                if (json.d != "") {
                    var re = jQuery.parseJSON(json.d);
                    var html = "";
                    $.each(re, function (i) {
                        html += "<tr><td>" + (i + 1) + "</td><td>" + re[i].b + "</td><td>" + (re[i].c=="1"?"存款":"取款") + "</td><td>" + re[i].d + "</td><td>" + re[i].e + "</td><td>" + (re[i].g=="1"?"未审核":"已审核") + "</td><td>" + re[i].i + "</td><td><a href=\"#\" attr=\"" + re[i].a + "\">审核</td></tr>";
                    });
                    $("#tab1>tbody").html(html);
                }
            });
        }

        //存取款账目明细记录显示
        function GetBillDetailAll() {
            $.AjaxCommon("/ServicesFile/User/BankService.asmx/GetBillDetailAll", "", true, false, function (json) {
                if (json.d != "") {
                    var re = jQuery.parseJSON(json.d);
                    var html = "";
                    $.each(re, function (i) {
                        html += "<tr><td>" + (i + 1) + "</td><td>" + re[i].b + "</td><td>" + (re[i].c == "1" ? "存款" : "取款") + "</td><td>" + re[i].d + "</td><td>" + re[i].e + "</td><td>" + re[i].g + "</td><td>" + re[i].f + "</td><td>" + re[i].i + "</td></tr>";
                    });
                    $("#tab2>tbody").html(html);
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table id="tab1">
        <thead>
            <tr>
                <th>序号</th>
                <th>会员名称</th>
                <th>类型</th>
                <th>金额</th>
                <th>提交时间</th>
                <th>状态</th>
                <th>银行卡号</th>
                <th>审核</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
    <table id="tab2">
        <thead>
            <tr>
                <th>序号</th>
                <th>会员名称</th>
                <th>类型</th>
                <th>存款金额</th>
                <th>取款金额</th>
                <th>交易时间</th>
                <th>余额</th>
                <th>银行卡号</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
    
    </div>
    </form>
</body>
</html>
