<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADList.aspx.cs" Inherits="admin.Report.ADList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type">
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
     <script type="text/javascript" src="/js/jQueryCommon.js"></script>
    <script src="/js/webBasicInfo/zh-CN.js" type="text/javascript"></script>
    <link href="/css/Default/cupertino/jquery-ui-1.8.2.custom.css" rel="stylesheet"  type="text/css" />
 
     <script type="text/javascript">

         $(document).ready(function () {
             SetDate();
//             $('#regTime1').val(CurentTime());
//             jQuery("#regTime1").datepicker();

//             $('#regTime2').val(CurentTime2());
//             jQuery("#regTime2").datepicker();
             $('#mageruser').val($('#spManagerId').val());

             function SetDate() {
                 var now = new Date();
                 var year = now.getFullYear();       //年
                 var month = now.getMonth() + 1;     //月
                 var day = now.getDate();       //日
                 month = (month < 9 ? ("0" + month) : month);
                 day = (day < 9 ? ("0" + day) : day);
                 $("#regTime1").val(year + "-" + month + "-01");
                 $("#regTime2").val(year + "-" + month + "-" + day);
             }

             LoadData();
            

             //             var data = "";
             //             jQuery.AjaxCommon("/ServicesFile/LoginService.asmx/IsSestlog", data, false, false, function (json) {
             //                 if (json.d) {
             //                     $('#sbtodata').css("display", 'none');
             //                 }
             //                 else {
             //                     $('#sbtodata').css("display", 'inline');
             //                 }
             //             });

             $('#sbtodata').click(function () {
                 if (confirm("你确定提交此次上班签到时间？\n系统将当天上班时间更新为当前时间！"))
                 {
                     var data = "LoginBegin:'',LoginTime:''";
                     jQuery.AjaxCommon("/ServicesFile/LoginService.asmx/AddSestlog", data, false, false, function (json) {
                         if (json.d) {
                             //$('#sbtodata').css("display", 'none');
                             alert('上班签到成功，信息已录数据库!');
                             LoadData();
                         }
                         else {
                             $('#sbtodata').css("display", 'inline');
                         }
                     });
                 }
                 
                
             });

             $('#searchData').click(function () {


                 var url = "/ServicesFile/LoginService.asmx/GetSestlog2";
                 var data = "manager:'" + $.trim($('#mageruser').val()) + "',time1:'" + $('#regTime1').val() + "',time2:'" + $('#regTime2').val() + "'";
                 var htm = "";
                 jQuery.AjaxCommon(url, data, false, false, function (json) {
                     if (json.d == ']') {
                         jQuery("#tab").html('<tr ><TD colspan="6">无相关信息</TD></TR>');
                         return false;
                     }
                     var result = jQuery.parseJSON(json.d);
                     // var result = resultAll.text[0];                

                     jQuery.each(result, function (i, n) {


                         htm += "<tr >";
                         htm += "<td>" + n.LoginTime + "</td>";
                         htm += "<td>" + n.LoginBegin + "</td>";
                         var ss = (n.LoginEnd == '') ? '--:--' : n.LoginEnd;
                         htm += "<td>" + ss + "</td>";
                         htm += "<td>" + n.magnerUser + "</td>";
                         htm += "<td>" + n.IP + "</td>";
                         if (n.LoginEnd == '' || n.LoginBegin == '') {
                             htm += "<td>/</td>";
                         } else {
                             var difftime = GetDateDiff(n.LoginBegin, n.LoginEnd, "hour");
                             htm += "<td>" + difftime + "</td>";
                         }

                         htm += "</td>";
                         htm += "</tr>";
                     });
                     jQuery("#tab").html(htm);
                 });

             });




         });
       
         function CurentTime() {
             var now = new Date();
             var year = now.getFullYear();       //年
             var month = now.getMonth();     //月


             var clock = year + "-";
             if (month < 10)
                 clock += "0";
             clock += month + "-";
             clock += "01";
             return (clock);
         }
         function CurentTime2() {
             var now = new Date();
             var year = now.getFullYear();       //年
             var month = now.getMonth() + 1;     //月
             var day = now.getDate();       //日


             var clock = year + "-";
             if (month < 10)
                 clock += "0";
             clock += month + "-";
             clock += day;
             return (clock);
         }





         function Xbtodata() {
             if (confirm("你确定提交此次下班时间？\n系统将当天下班时间更新为当前时间！")) {
                 var data = "LoginBegin:'',LoginTime:''";
                 jQuery.AjaxCommon("/ServicesFile/LoginService.asmx/UpdateSestlog", data, false, false, function (json) {
                     if (json.d) {
                         alert("下班时间已记录!");
                         LoadData();
                     }
                     else {
                         alert("请先点上班签到，下班时间灵入失败!");
                     }
                 });
             }
            
         }
         function GetDateDiff(startTime, endTime, diffType) {
             //将xxxx-xx-xx的时间格式，转换为 xxxx/xx/xx的格式 

             startTime = startTime.replace(/-/g, "/");

             endTime = endTime.replace(/-/g, "/");
             //将计算间隔类性字符转换为小写 
             diffType = diffType.toLowerCase();
             var sTime = new Date(startTime); //开始时间 
             var eTime = new Date(endTime); //结束时间 
             //作为除数的数字 
             var divNum = 1;
             switch (diffType) {
                 case "second":
                     divNum = 1000;
                     break;
                 case "minute":
                     divNum = 1000 * 60;
                     break;
                 case "hour":
                     divNum = 1000 * 3600;
                     break;
                 case "day":
                     divNum = 1000 * 3600 * 24;
                     break;
                 default:
                     break;
             }
             return ((eTime.getTime() - sTime.getTime()) / parseInt(divNum)).toFixed(1); //
         }





         function LoadData() {
             var url = "/ServicesFile/LoginService.asmx/GetSestlog";
             var data = "time1:'" + $('#regTime1').val() + "',time2:'" + $('#regTime2').val() + "'";
             var htm = "";
             jQuery.AjaxCommon(url, data, false, false, function (json) {
                 if (json.d == ']') {
                     jQuery("#tab").html('<tr ><TD colspan="6">无相关信息</TD></TR>');
                     return false;
                 }
                 var result = jQuery.parseJSON(json.d);
                 // var result = resultAll.text[0];                

                 jQuery.each(result, function (i, n) {

                     htm += "<tr >";
                     htm += "<td>" + n.LoginTime + "</td>";
                     htm += "<td>" + n.LoginBegin + "</td>";
                     var ss = (n.LoginEnd == '') ? '--:--' : n.LoginEnd;
                     htm += "<td>" + ss + "</td>";
                     htm += "<td>" + n.magnerUser + "</td>";
                     htm += "<td>" + n.IP + "</td>";
                     if (n.LoginEnd == '' || n.LoginBegin == '') {
                         htm += "<td>/</td>";
                     } else {
                         var difftime = GetDateDiff(n.LoginBegin, n.LoginEnd, "hour");
                         htm += "<td>" + difftime + "</td>";
                     }



                     htm += "</td>";
                     htm += "</tr>";
                 });
                 jQuery("#tab").html(htm);
             });
         }

       
    </script>
</head>
<body >



<table  id="tab3" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p><font class="st"> 您当前的位置：</font><a href="javascript:void(0)"><span> 首页</span></a><a href="javascript:void(0)"><span>考勤管理</span></a></p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<!--主题部分开始=========================================================================================-->

<script type="text/javascript">
    $(document).ready(function () {
        $(".stripe_tb tr").mouseover(function () { //如果鼠标移到class为stripe_tb的表格的tr上时，执行函数
            $(this).addClass("over");
        }).mouseout(function () { //给这行添加class值为over，并且当鼠标一出该行时执行函数
            $(this).removeClass("over");
        }) //移除该行的class
        $(".stripe_tb tr:even").addClass("alt"); //给class为stripe_tb的表格的偶数行添加class值为alt
    });
</script>

<style>
.stripe_tb th{background:#B5CBE6; color:#039; line-height:20px; height:30px}
.stripe_tb td{padding:6px 11px; border-bottom:1px solid #95bce2; vertical-align:top; text-align:center}
.stripe_tb td *{padding:6px 11px}
.stripe_tb tr.alt td{background:#ecf6fc} /*这行将给所有偶数行加上背景色*/
.stripe_tb tr.over td{background:#FEF3D1} /*这个将是鼠标高亮行的背景色*/

</style>
<div class="top_banner h30">
<div class="fl">
员工帐号：
<input type="text" class="text_01 h20 w_80"  id="mageruser" />
&nbsp;&nbsp;&nbsp;&nbsp;
时间：<input type="text" name="regTime1" id="regTime1" class="text_01 h20 w_80" />-
<input type="text" name="regTime2" id="regTime2" class="text_01 h20 w_80" />&nbsp;&nbsp;&nbsp;

<input type="button" class="btn_01" id="searchData" onmouseover="this.className='btn_01_h'" onmouseout="this.className='btn_01'" value="查找" />

</div>



<div class="fr">
    <input type="button" onclick="Sbtodata()" class="top_add" id="sbtodata" style=" " onmouseover="this.className='top_add_h'" onmouseout="this.className='top_add'"  value="上班签到" />
    <input type="button" onclick="Xbtodata()" class="top_add" onmouseover="this.className='top_add_h'" onmouseout="this.className='top_add'"  value="下班" />
</div>



</div>
<table id="tab2" class="stripe_tb" width=100% cellpadding=0 cellspacing="0" border=0 >

<thead> 
<tr>

<th>日期</th>
<th>上班时间</th>
<th>下班时间</th>
<th>员工</th>
<th>IP</th>
<th>工时</th>
</tr>
</thead> 
<tbody id="tab">
<tr>



</tr>
</tbody> 


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



</body>
</html>
