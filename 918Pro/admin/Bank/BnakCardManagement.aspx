<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BnakCardManagement.aspx.cs" Inherits="admin.Bank.BnakCardManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
        <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
   <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
     <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
     <link href="/css/Default/pagination.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
        <script src="/js/jQueryCommon.js" type="text/javascript"></script>
    <script src="/js/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
    <script src="/js/webBasicInfo/zh-CN.js" type="text/javascript"></script>
    <link href="/css/Default/cupertino/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var per_page_number = 15;    //每页显示记录数
        function CurentTime2() {
            var now = new Date();
            var year = now.getFullYear();       //年
            var month = now.getMonth() + 1;     //月
            var day = now.getDate();       //日


            var clock = year + "-";
            if (month < 10)
                clock += "0";
            clock += month + "-";
            if (day<10) {
                clock += "0";
            }
            clock += day;
            return (clock);
        }

        jQuery(function () {

            jQuery("#bankInfo").dialog("close");
            $("#tabs").tabs();

            jQuery("#time1WhereVal").datepicker();
            $('#time1WhereVal').val(CurentTime2());
            jQuery("#time2WhereVal").datepicker();
            $('#time2WhereVal').val(CurentTime2());
            SelectByWhereInfo("0");
            $("#selectByWhere").click(function () {
                SelectByWhereInfo("0");

            });
            GetBank2();
            $("#bankBname").click(function () {
                GetBankInfo_6();
            });
         
            $("#txtbank1").click(function () {
                GetBankInfo_7();
            });
            $("#BtnAdd1").click(function () {
                if ($("#txtbank1").val() == "0") { alert("请选择银行卡别名"); return false; }
                if ($("#txtbank5").val() == "") {

                    alert("请输入出款金额");
                    return false
                }
                else {
                    var patrn = /^-?\d+\.{0,}\d{0,}$/;
                    if (!patrn.exec($("#txtbank5").val())) {
                        alert("您输入的出款金额格式不正确");
                        return false
                    }
                }
                if ($("#txtbank6").val() == "") {

                    alert("请输入手续费");
                    return false
                }
                else {
                    var patrn = /^-?\d+\.{0,}\d{0,}$/;
                    if (!patrn.exec($("#txtbank6").val())) {
                        alert("手续费输入格式不正确");
                        return false
                    }
                }

                var data = "bankTypeid:" + $("#txtbank1").val() + ",bankc:'" + $('#txtbank1 option:selected').text() + "',banknamec:'" + $("#txtbank2").val() + "',";
                data += "banknoc:'" + $("#txtbank3").val() + "',cardnoc:'" + $("#txtbank4").val() + "',";
                data += "Amount:'" + $("#txtbank5").val() + "',sfee:'" + $("#txtbank6").val() + "',Type:'11',Status:'2',Reasoncn:'" + $("#txtbank7").val() + "'";

                $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/InsertBillNoticeManagentC", data, true, false, function (json) {
                    if (json.d) {
                        $("#txtbank5").val("");
                        $("#txtbank6").val("");
                        $("#txtbank7").val("");
                        alert("手动存款提交成功!");
                      
                    }
                    else {
                        alert("手动存款失败！");
                    }


                });

            });
            $("#AddBankInfo").click(function () {
                //debugger
                if ($("#bankBname").val() == "0") { alert("请选择银行卡别名"); return false; }
                if ($("#txtCbank").val() == "") { alert("请输入出款银行名称"); return false; }
                if ($("#txtbankinfo").val() == "") { alert("请输入开户信息"); return false; }
                if ($("#txtCbankName").val() == "") { alert("请输入出款账户名称"); return false; }

                if ($("#txtCbankcard").val() == "") { alert("请输入出款银行卡号"); return false; }
                if ($("#txtCamount").val() == "") {

                    alert("请输入出款金额");
                    return false
                }
                else {
                    var patrn = /^-?\d+\.{0,}\d{0,}$/;
                    if (!patrn.exec($("#txtCamount").val())) {
                        alert("您输入的出款金额格式不正确");
                        return false
                    }
                }

                if ($("#txtsfee").val() == "") {

                    alert("请输入手续费");
                    return false
                }
                else {
                    var patrn = /^-?\d+\.{0,}\d{0,}$/;
                    if (!patrn.exec($("#txtsfee").val())) {
                        alert("手续费输入格式不正确");
                        return false
                    }
                }
                if ($("#taaBndkInfo").val() == "") { alert("请输入备注"); return false; }


                var data = "bankTypeid:" + $("#bankBname").val() + ",bankc:'" + $('#bankBname option:selected').text() + "',banknamec:'" + $("#txtbankname").val() + "',";
                data += "banknoc:'" + $("#txtname").val() + "',cardnoc:'" + $("#txtcard").val() + "',";
                data += "bankcn:'" + $("#txtCbank").val() + "',Names:'" + $("#txtbankinfo").val() + "',"; //出款银行名称,出款开户行信息
                data += "UserName:'System',CardNo:'" + $("#txtCbankcard").val() + "',"; //出款帐号名称，出款卡号
                data += "Amount:'" + $("#txtCamount").val() + "',sfee:'" + $("#txtsfee").val() + "',Type:'10',Status:'2',Reasoncn:'" + $("#taaBndkInfo").val() + "'";

                $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/InsertBillNoticeManagent", data, true, false, function (json) {
                    if (json.d) {
                        $("#txtCamount").val("");
                        $("#txtsfee").val("");
                        $("#taaBndkInfo").val("");
                        alert("手动出款成功");                     

                    }
                    else {
                        alert("手动出款失败！");
                    }


                });
            });
        });

        
        function GetBank2() {
            $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/GetBankNameInfo_1", "", true, false, function (json) {
                 if (json.d != "") {
               // debugger
                     var html = "<option  value=\"0\">---请选择银行别名---</option>";
                    var re = jQuery.parseJSON(json.d);
                    $.each(re, function (i) {
                        html += "<option value=\"" + re[i].a + "\" ";                      
                        html += ">" + re[i].c + "</option>";

                    });
                    $("#txtcardname").html(html);
                    $("#bankBname").html(html);
                    $("#txtbank1").html(html);

                }
            
            });
    }

    //选择时加载绑定信息
    function GetBankInfo_6() {
   
        var bankid = $("#bankBname").val();
        if (bankid != "" && bankid != "0") {
           // var data = "id:" + bankid + "";
            if (bankid != "" && bankid != "0") {
                $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/GetBankInfos", "id:"+bankid+"", true, false, function (json) {              
                    if (json.d != "") {
                        var result = jQuery.parseJSON(json.d);
                        //debugger


                        if ($("#bankBname").val() == bankid) {
                            $("#bankBname").attr("selected", "true");
                        }


                        $("#txtbankname").val(result[0].namecn);
                        $("#txtname").val(result[0].bank);
                        $("#txtcard").val(result[0].cardno);

                    }
                
                });

            }
        }

}

//选择时加载绑定信息
function GetBankInfo_7() {

    var bankid = $("#txtbank1").val();
    if (bankid != "" && bankid != "0") {
        // var data = "id:" + bankid + "";
        if (bankid != "" && bankid != "0") {
            $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/GetBankInfos", "id:" + bankid + "", true, false, function (json) {
                if (json.d != "") {
                    var result = jQuery.parseJSON(json.d);
                    //debugger


                    if ($("#txtbank1").val() == bankid) {
                        $("#txtbank1").attr("selected", "true");
                    }


                    $("#txtbank2").val(result[0].namecn);
                    $("#txtbank3").val(result[0].bank);
                    $("#txtbank4").val(result[0].cardno);

                }

            });

        }
    }

}



function SelectByWhereInfo(pages) {
       // debugger
            $("#tb2>tbody").html("");
            if ($('#txtcardname option:selected').text() == "---请选择银行别名---") {
                var txtcardname = "";
            }
            else {
                var txtcardname = $('#txtcardname option:selected').text();
            }
            $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/GetHistoryByWhereSumPage", "perPageNum:" + per_page_number + ",page:" + pages + ",bankcard:'" + txtcardname + "',lsname:'" + $.trim($("#txtLsname").val()) + "',time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "'", true, false, function (json) {
                if (json.d != "]") {
                    var resultAll = jQuery.parseJSON(json.d);
                    var re = resultAll.text[0];
                    var recordNum = resultAll.count[0].recordNum;
                    $("#Pagination").pagination(recordNum, {
                        num_edge_entries: 2,
                        num_display_entries: 8,
                        current_page: pages,
                        items_per_page: per_page_number,
                        callback: SelectByWhereInfo
                    });
                    //var re = jQuery.parseJSON(json.d);
                    // alert(json.d);
                    var html = "", total0 = 0; total1 = 0, total2 = 0; total3 = 0; total4 = 0; total5 = 0;

                    $.each(re, function (i) {
                        //  debugger
                        html += "<tr><td>" + (i + 1) + "</td>";
                        html += "<td>" + re[i].bankc + "</td>";
                        html += "<td>" + re[i].banknamec + "</td>";
                        html += "<td>" + re[i].banknoc + "</td>";
                        html += "<td>" + re[i].cardnoc + "</td>";

                        html += "<td style='color:red'>" + parseFloat(re[i].bankamount1) + "</td>";
                        total0 += parseFloat(re[i].bankamount1);
                        if (re[i].Type == "1" || re[i].Type == "11") {
                            html += "<td style='color:red'>" + parseFloat(re[i].Amount) + "</td>";
                            html += "<td style='color:red'>0</td>";
                            total1 += parseFloat(re[i].Amount);
                        }
                        else {
                            html += "<td style='color:red'>0</td>";
                            html += "<td style='color:red'>" + parseFloat(re[i].Amount) + "</td>";
                            total2 += parseFloat(re[i].Amount);
                        }

                        html += "<td style='color:red'>" + parseFloat(re[i].bankamount2) + "</td>";
                        total3 += parseFloat(re[i].bankamount2);
                      
                        html += "<td style='color:red'>" + parseFloat(re[i].sfee) + "</td>";
                        total4 += parseFloat(re[i].sfee);
                      


                        html += "<td>" + re[i].SubmitTime.replace(" 0:00:00", "") + "</td>";
                        html += "<td>" + re[i].UpdateTime.replace(" 0:00:00", "") + "</td>";
                        //                            html += "<td>" + re[i].UserName + "</td>";
                        //                            html += "<td>" + re[i].bankcn + "</td>";
                        //                            html += "<td>" + re[i].CardNo + "</td>";
                        //                            html += "<td>" + re[i].Names + "</td>";
                        //                            
                        //                            html += "<td>" + parseFloat(re[i].Amount) + "</td>";
                        //                            html += "<td>" + parseFloat(re[i].sfee) + "</td>";
                        html += "<td>" + re[i].bankno + "</td>";                       
                        html += "<td>" + re[i].mark + "</td>";
                   
                        html += "<td ><a style='color:#0075a9' href=\"javascript:void(0)\" onclick=\"bankInfo(this)\"  id='" + re[i].id + "' >详细</a></td>";
                        //alert(re[i].id);



                    });
                    html += "<tr><td>总计</td><td colspan='4'></td><td style='color:red'>" + total0.toFixed(2) + "&nbsp;</td><td style='color:red'>" + total1.toFixed(2) + "&nbsp;</td><td style='color:red'>" + total2.toFixed(2) + "&nbsp;</td><td style='color:red'>" + total3.toFixed(2) + "&nbsp;</td><td style='color:red'>" + total4.toFixed(2) + "&nbsp;</td></tr>";
                    $("#tb2>tbody").html(html);


                } else {
                    $("#tb2>tbody").html("<tr><td colspan=\"15\">没有相应数据</td></tr>");
                }
            });
        }

        function bankInfo(obj) {
            //debugger
            jQuery("#bankInfo").dialog({ modal: false, width: 500 });
            var url = "/ServicesFile/BankService/BankService.asmx/GetUserBankList";
            var id = jQuery(obj).attr("id");
            var datas = "id:'" + id + "'";
            jQuery.AjaxCommon(url, datas, false, false, function (json) {
                if (json.d) {
                    var result = jQuery.parseJSON(json.d);
                    $.each(result, function (i) {
                        //debugger
                        if ( result[i].Type=="1") {
                           $("#txttype").val("存款").attr("readonly", "readonly");
                         }
                         else
                         {
                         $("#txttype").val("取款").attr("readonly", "readonly");
                     }
                       $("#txtusername").val(result[i].UserName).attr("readonly", "readonly");     
                         $("#txtCardNo").val(result[i].CardNo).attr("readonly", "readonly");
                         $("#txtname5").val(result[i].Names).attr("readonly", "readonly");
                         $("#txtBank3").val(result[i].bankcn).attr("readonly", "readonly");
                         $("#txtfree").val(result[i].sfee).attr("readonly", "readonly");
                         $("#txtamount").val(result[i].Amount).attr("readonly", "readonly");  
                    });
                }
                else {
                    $.MsgTip({ objId: "#divTip", msg: "无记录信息", delayTime: "2000" });

                }
            });


            jQuery("#Bank_submit_no").unbind("click");
            jQuery("#Bank_submit_no").bind("click", function () {
                jQuery("#bankInfo").dialog("close");


            });
            jQuery("#Bank_submit_no").bind("click", function () {
                jQuery("#bankInfo").dialog("close");
            });

        }      
    </script>
    <style type="text/css">  
    td{ text-align:left;height:30px; height:30px;  border-left:0px solid red; border-right:0px solid #a8d8eb; border-top:0px solid #a8d8eb; border-bottom:0px solid #a8d8eb;}
    </style>
</head>
<body >
<table  id="right_main" border="0" width="130%"  cellpadding="0" cellspacing="0" style="position:static; z-index:-211000;">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p><font class="st"> 银行卡管理</font><a href="javascript:void(0)"></a></p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<!--主题部分开始=========================================================================================-->
<div id="tabs" >
    <ul>
        <li><a href="#fragment-1"><span>银行卡查询</span></a></li>
        <li><a href="#fragment-2"><span>手工增加出款</span></a></li>
        <li><a href="#fragment-3"><span>手工增加存款</span></a></li>
    </ul>
    <div id="fragment-1">
    
  <table  id="Table1" border="0" width="100%" cellpadding="0" cellspacing="0">
  <tr>
<td >
<div id="Div1" >
   
    <form id="form1" runat="server">
    <div  style="padding:3px;margin:2px;">   
    <a id="hyzh">银行卡别名</a>&nbsp;&nbsp;<select id="txtcardname"  style=" width:200px;height:19p"></select><span style=" color:red">*</span>&nbsp;&nbsp; 
    <a id="hyxm">流水号</a>&nbsp;&nbsp;<input type="text" id="txtLsname" class="inputWhere text_01 w_150" style=" height:19px"  onmouseover="this.className='text_01_h w_150'" onmouseout="this.className='text_01 w_150'" />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="jysj">审核时间</a>&nbsp;&nbsp;<input type="text" id="time1WhereVal" class="inputWhere text_01 w_120" onmouseover="this.className='text_01_h w_120'" onmouseout="this.className='text_01 w_120'" readonly="readonly"  style=" height:19px" />－<input type="text" id="time2WhereVal" class="inputWhere text_01 w_120" onmouseover="this.className='text_01_h w_120'" onmouseout="this.className='text_01 w_120'" style=" height:19px"  readonly="readonly"  />&nbsp;&nbsp;&nbsp;&nbsp;
  
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in">搜索</span></a>
    </div>
    <table class="tab2" id="tb2"  style="margin-left:-2px" width="100%" border="0" cellpadding="0" cellspacing="0">
    <thead>
                <tr>
                <th style=" text-align:center">序号</th>
                <th  style=" text-align:center">银行卡别名</th>
                <th  style=" text-align:center">银行名称</th>
                <th  style=" text-align:center">账户名称</th>
                <th  style=" text-align:center">银行卡号</th>              
                <th  style=" text-align:center">期初金额</th>
                <th  style=" text-align:center">存款金额</th>
                <th  style=" text-align:center">提款金额</th>
                <th  style=" text-align:center">期未金额</th>   
                 <th  style=" text-align:center">手续费</th>                            
                <th  style=" text-align:center">提交日期</th>
                <th  style=" text-align:center">审核日期</th>

              <%--  <th>会员号</th>
                <th>银行名称(会员)</th>
                <th>银行卡号(会员)</th>
                <th>帐户名(会员)</th>               
                <th>金额(会员)</th>
               --%>
                <th>流水号</th>
                <th>备注</th>
                <th>来源详细</th>
               
    </tr>
    </thead>
    <tbody id="showInfo">
    </tbody>
    <tfoot>
        <tr>
            <td colspan="19">
                <div id="Pagination" class="pagination"></div>
            </td>
        </tr>
    </tfoot>
    </table>
    </form>
</div>
</td>

</tr>

</table>
   
   
    </div>
    <div id="fragment-2">
      <table >
       <tr>
       <td><span>银行卡别名：</span></td>
       <td><select id="bankBname"  style=" width:285px"></select><span style=" color:red">*</span></td>
       </tr>
       <tr>
       <td><span>银行名称：</span></td>
       <td><input type="text" id="txtbankname"  style=" width:280px"/><span style=" color:red">*</span></td>
       </tr>

        <tr>
       <td><span>账户名称：</span></td>
       <td><input type="text" id="txtname"  style=" width:280px"/><span style=" color:red">*</span></td>
       </tr>

        <tr>
       <td><span>银行卡号：</span></td>
       <td style=" height:40px"><input type="text" id="txtcard"  style=" width:280px"/><span style=" color:red">*</span></td>
       </tr>
         <tr style=" height:5px">
       <td style=" height:5px"></td>
       <td style=" height:5px"></td>
       </tr>
        <tr>
       <td><span style=" color:Red">出款银行名称：</span></td>
       <td><input type="text" id="txtCbank"  style=" width:280px"/><span style=" color:red">*</span></td>
       </tr>
        <tr>
       <td><span style=" color:Red">开户信息：</span></td>
       <td><input type="text" id="txtbankinfo"  style=" width:280px"/><span style=" color:red">*</span></td>
       </tr>
        <tr>
       <td><span style=" color:Red">出款账户名称：</span></td>
       <td><input type="text" id="txtCbankName"  style=" width:280px"/><span style=" color:red">*</span></td>
       </tr>

        <tr>
       <td><span style=" color:Red">出款银行卡号：</span></td>
       <td><input type="text" id="txtCbankcard"  style=" width:280px"/><span style=" color:red">*</span></td>
       </tr>
         <tr style=" height:5px">
       <td style=" height:5px"></td>
       <td style=" height:5px"></td>
       </tr>
       <tr>
       <td><span>出款金额：</span></td>
       <td><input type="text" id="txtCamount"  style=" width:280px"/><span style=" color:red">*</span></td>
       </tr>
        <tr>
       <td><span>手续费：</span></td>
       <td><input type="text" id="txtsfee"  style=" width:280px"/><span style=" color:red">*</span></td>
       </tr>
       <tr>
       <td><span>选择游戏：</span></td>
       <td><select style=" width:285px"><option>太阳城游戏</option></select><span style=" color:red">*</span></td>
       </tr>

        <tr>
       <td><span>备 注：</span></td>
       <td><textarea id="taaBndkInfo" rows="4" cols="1" style=" width:285px; height:48px"></textarea><span style=" color:red">*</span></td>
       </tr>

       <tr>
       <td  colspan="2" style=" text-align:center">
       <input type="button" value="添加出款" 
               style=" width:80px; height:30px; background-color: #CCCCFF;" id="AddBankInfo" />&nbsp;
       <input type="button" value=" 关 闭 " style=" width:80px; height:30px;background-color: #CCCCFF;" id="Closebank" />
       </td>
       
       </tr>
       </table>
     
    </div>
    <div id="fragment-3">
          <table >
       <tr>
       <td><span>银行卡别名：</span></td>
       <td><select id="txtbank1"  style=" width:285px"></select><span style=" color:red">*</span></td>
       </tr>
       <tr>
       <td><span>银行名称：</span></td>
       <td><input type="text" id="txtbank2"  style=" width:280px"/><span style=" color:red">*</span></td>
       </tr>

        <tr>
       <td><span>账户名称：</span></td>
       <td><input type="text" id="txtbank3"  style=" width:280px"/><span style=" color:red">*</span></td>
       </tr>

        <tr>
       <td><span>银行卡号：</span></td>
       <td style=" height:40px"><input type="text" id="txtbank4"  style=" width:280px"/><span style=" color:red">*</span></td>
       </tr>
         <tr style=" height:5px">
       <td style=" height:5px"></td>
       <td style=" height:5px"></td>
       </tr>
        <tr>
       <td><span >存款金额：</span></td>
       <td><input type="text" id="txtbank5"  style=" width:280px"/><span style=" color:red">*</span></td>
       </tr>
        <tr>
       <td><span>手续费：</span></td>
       <td><input type="text" id="txtbank6"  style=" width:280px"/><span style=" color:red">*</span></td>
       </tr>
        <tr>
       
       <td><span>选择游戏：</span></td>
       <td><select style=" width:285px"><option>太阳城游戏</option></select><span style=" color:red">*</span></td>
       </tr>

        <tr>
       <td><span>备 注：</span></td>
       <td><textarea id="txtbank7" rows="4" cols="1" style=" width:285px; height:60px"></textarea><span style=" color:red">*</span></td>
       </tr>

       <tr>
       <td  colspan="2" style=" text-align:center">
       <input type="button" value="添加存款" 
               style=" width:80px; height:30px; background-color: #CCCCFF;" id="BtnAdd1" />&nbsp;
       <input type="button" value=" 关 闭 " style=" width:80px; height:30px;background-color: #CCCCFF;" id="BtnAdd2" />
       </td>
       
       </tr>
       </table>
    </div>
</div>


<div id="bankInfo" style=" display:none" title="会员银行信息详细" >
<div class="showdiv">
<ul>
<li><p><span id="Span3">类型：</span>：<input id="txttype"    class="text_01 h20 w_120"  readonly="readonly"/></p></li>
<li><p><span id="Span15">会员帐号</span>：<input id="txtusername"    class="text_01 h20 w_120"  readonly="readonly"/></p></li>
<li><span id="Span16">银行卡号</span>：<input id="txtCardNo" type="text" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" /><label id="Label3" style="color:Red"></label></li>
<li><span id="Span21">户名</span>：<input id="txtname5" type="text" class="text_01 h20" style="  width:360px" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" /><label id="Label8" style="color:Red"></label></li>
<li><span id="Span17">开户银行名称</span>：<input id="txtBank3" type="text" class="text_01 h20" style="  width:360px" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" /><label id="Label4" style="color:Red"></label></li>
<li><span id="Span1">实际金额</span>：<input id="txtamount" type="text" class="text_01 h20" style="  width:360px" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'" /><label id="Label1" style="color:Red"></label></li>
<li><span id="Span2">手续费</span>：<input id="txtfree" type="text" class="text_01 h20" style="  width:360px" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'"  /><label id="Label2" style="color:Red"></label></li>

<li><div align="center" class="mtop_30">
   
 <input type="button" id="Bank_submit_no" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></div></li>
</ul>

</div>
</div>



<!--主题部分结束=========================================================================================-->
</div>
</td>

</tr>
</tbody>

<tfoot>

</tfoot>
</table>
</body>
</html>
