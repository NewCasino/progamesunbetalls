<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JoinerManage.aspx.cs" Inherits="admin.User.JoinerManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>代理申请</title>
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/js/page/pageJs.js" type="text/javascript"></script>
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="/js/jQueryCommon.js" type="text/javascript"></script>
    <script src="/js/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
    <script src="/js/webBasicInfo/zh-CN.js" type="text/javascript"></script>
    <style type="text/css">
    #cancelDepoist{display:none;}
    </style>
    <script type="text/javascript">
        var language = $.cookie("lan"), lan = "";
        switch (language) {
            case "zh-cn":
                lan = "cn"; break;
            case "zh-tw": lan = "tw"; break;
            case "en-us":
                lan = "en"; break;
            case "th-th":
                lan = "th"; break;
            case "vi-vn":
                lan = "vn"; break;
            default: lan = "cn"; break;
        }
        $(function () {
            //SelectByWhere();
            //getdz();
            $("#time1WhereVal,#time2WhereVal").datepicker().click(function () {
                $(this).val("");
            });
            $("#selectByWhere").click(function () {
                if ($.trim($("#memberSel").val()) != "" || $.trim($("#memberName").val()) != "" || $.trim($("#statusSel").val()) != "" || $("#time1WhereVal").val() != "" || $("#time2WhereVal").val() != "") {
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
            $("#depositHistory").click(function () {
                location = "/Bank/DepositHistory.aspx";
            });
            $("#VerifyDeposit").click(function () {
                location = "/Bank/VerifyDeposit.aspx";
            });
            $("#selectByWhere").click();
        });
        var re;
        function SelectByWhere() {
       // debugger
            $("#tb2>tbody").html("");
            var data = "username:'" + $.trim($("#memberSel").val()) + "',name:'" + $.trim($("#memberName").val()) + "',status:'" + $.trim($("#statusSel").val()) + "',subtime1:'" + $("#time1WhereVal").val() + "',subtime2:'" + $("#time2WhereVal").val() + "'";
            $.AjaxCommon("/ServicesFile/agentservers.asmx/GetJoinerByWhere", data, true, false, function (json) {
                if (json.d != "]") {
                    re = jQuery.parseJSON(json.d);
                    var html = "";
                    $.each(re, function (i) {
                        html += "<tr>";
                        html += "<td>" + (i + 1) + "</td>";
                        html += "<td>" + re[i].username + "</td>";
                        html += "<td>" + re[i].name + "</td>";
                        html += "<td>" + re[i].province + "</td>";
                        html += "<td>" + re[i].tel + "</td>";
                        html += "<td>" + re[i].email + "</td>";
                        html += "<td>" + re[i].qq + "</td>";
                        html += "<td style=\"color:blue;\">" + (re[i].status == "0" ? "拒绝" : (re[i].status == "1" ? "审核通过" : (re[i].status == "2" ? "未审核" : "正在洽谈"))) + "</td>";
                        html += "<td>" + re[i].subtime + "</td>";
                        html += "<td>" + "<a href=\"javascript:void(0);\" ii=\"" + i + "\" class=\"cancel\" style='color:#0075A9;'>查看</a>" + "</td>";
                        html += "</tr>";
                    });
                    //html += "<tr><td>总计</td><td colspan='2'></td><td style='color:red'>" + total1.toFixed(2) + "</td><td colspan='9'></td></tr>";
                    $("#tb2>tbody").html(html);
                    $("#tb2>tbody>tr").mouseover(function () {
                        $(this).siblings().removeClass("trOver").end().addClass("trOver");
                    });
                    $(".cancel").unbind("click").bind("click", function () {
                        //getReson();
                        $("#zd").val('918su');
                        var index = $(this).attr("ii");

                        $("#t1").val(re[index].username);
                        $("#t2").val(re[index].Password);
                        $("#t3").val(re[index].question);
                        $("#t4").val(re[index].answer);
                        $("#t5").val(re[index].email);
                        $("#t6").val(re[index].tel);
                        $("#t7").val(re[index].qq);
                        $("#t8").val(re[index].country);
                        $("#t9").val(re[index].province);
                        $("#t10").val(re[index].city);
                        $("#t11").val(re[index].CardNo);
                        $("#t12").val(re[index].bankname);
                        $("#t13").val(re[index].Bank);
                        $("#t14").val(re[index].Ghbadk);
                        $("#t15").val(re[index].Branch);
                        $("#t16").val(re[index].name);
                        $("#t17").val(re[index].url);
                        $("#birthday").html(re[index].Birthday);//
                        $("#txtstatus").val(re[index].status);
                        $("#gameaccount").val(re[index].gameUsername);

                        if (re[index].status == "1") {
                            $("#txtstatus").attr("disabled", true);
                            $("#zdhtml").hide();
                        }

                        $("#cancelDepoist").dialog({
                            beforeclose: function () {
                                $("#cancelDepoist :text").val("");
                                $("#cancelDepoist select>option:eq(0)").attr("selected", "true");
                                $("#txtstatus").attr("disabled", false);
                                $("#zdhtml").show();
                            },
                            modal: true,
                            width: "600px"
                        });
                        $("#submitBtn").unbind("click").bind("click", function () {
                            var url = "/ServicesFile/agentservers.asmx/UpdateJoiner";
                            var data = "zagent:'918su',percent:" + $("#zc").val() + ",username:'" + $("#t1").val() + "',password:'" + $("#t2").val() + "',question:'" + $("#t3").val() + "'";
                            data += ",answer:'" + $("#t4").val() + "',email:'" + $("#t5").val() + "',tel:'" + $("#t6").val() + "'";
                            data += ",qq:'" + $("#t7").val() + "',country:'" + $("#t8").val() + "',province:'" + $("#t9").val() + "'";
                            data += ",city:'" + $("#t10").val() + "',cardno:'" + $("#t11").val() + "',bankname:'" + $("#t12").val() + "'";
                            data += ",bank:'" + $("#t13").val() + "',ghbndk:'" + $("#t14").val() + "',branch:'" + $("#t15").val() + "'";
                            data += ",name:'" + $("#t16").val() + "',url:'" + $("#t17").val() + "',status:'" + $("#txtstatus").val() + "',ID:" + re[index].ID;
                            $.AjaxCommon(url, data, true, false, function (json) {
                                if (json.d) {
                                    alert("更新成功！");
                                    $("#cancelDepoist").dialog("close");
                                    SelectByWhere();
                                } else {
                                    alert("发生意外，更新失败");
                                }
                            });
                        });
                        $("#cancelBtn").unbind("click").bind("click", function () {
                            $("#cancelDepoist").dialog("close");
                        });
                    });
                } else {
                    $("#tb2>tbody").html("<tr><td colspan=\"15\">没有相应数据</td></tr>");
                }
            });
        }

        function getReson() {
            $.AjaxCommon("/ServicesFile/BankService/BankService.asmx/GetReason", "", true, false, function (json) {
                if (json.d != "") {
                    var result = jQuery.parseJSON(json.d);
                    var html = "";
                    $.each(result, function (i) {
                        html += "<option value=\"" + result[i].a + "\">" + result[i].b + "</option>";
                    });
                    $("#reason").html(html);
                }
            });
        }
        var zd = "918su";
        function getdz() {
            var url = "/ServicesFile/agentservers.asmx/GetZagent";
            var data = "";
            $.AjaxCommon(url, data, false, true, function (json) {
                if (json.d != "-1") {
                    var lists = $.parseJSON(json.d);
                    zd = lists.b[0].z1;
                    var opstr = "";
                    $.each(lists.a, function (i) {
                        opstr += "<option value='" + lists.a[i].zagent + "'>" + lists.a[i].zagent + "</option>";
                    });
                    opstr += "<option value='waaa'>waaa</option>";
                    opstr += "<option value='waab'>waab</option>";
                    opstr += "<option value='waac'>waac</option>";
                    $("#zd").html('918su');
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
<th width="*" class="tab_top_m"><p id="zdjs">代理申请</p></th>
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
    <a id="hyzh">代理帐号</a>&nbsp;&nbsp;<input type="text" id="memberSel" class="inputWhere text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" />&nbsp;&nbsp;&nbsp;&nbsp; 
    <a id="hyxm">代理姓名</a>&nbsp;&nbsp;<input type="text" id="memberName" class="inputWhere text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="jysj">提交时间</a>&nbsp;&nbsp;<input type="text" id="time1WhereVal" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" readonly="readonly"  />－<input type="text" id="time2WhereVal" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" readonly="readonly"  />&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="zt">状态</a>&nbsp;&nbsp;<select id="statusSel">
        <option value="2">未审核</option>
        <option value="1">审核通过</option>
    <%--    <option value="3">正在洽谈</option>--%>
        <option value="0">已拒绝</option>
    </select>&nbsp;&nbsp;&nbsp;&nbsp;
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in">搜索</span></a>
    </div>
    <table class="tab2" id="tb2" width="100%" border="0" cellpadding="0" cellspacing="0">
    <thead>
         <tr>
            <th>序号</th>
            <th>代理号</th>
            <th>姓名</th>
            <th>省份</th>
            <th>电话</th>
            <th>电子邮箱</th>
            <th>QQ</th>
            <th>状态</th>
            <th>提交时间</th>
            <th>操作</th>
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

<div id="cancelDepoist" title="代理资料">
<div class="showdiv">
<table width="100%"  border="0" cellpadding="1" cellspacing="1" id="addtb">
<tr align="center" style="background-color:#CDEAFC">
    <td colspan="4"><strong>账号资料</strong></td>
  </tr>
 <tr>
    <td align="right">代理账号：</td>
    <td id="userAccount" align="left"><input readonly type="text" id="t1" class="inputWhere text_01 w_120" /></td>
    <td align="right" style="display:none;">登录密码：</td>
    <td id="nicheng" align="left" style="display:none;"><input type="text" id="t2" class="inputWhere text_01 w_120" /></td>
  </tr>

  <tr style="height:30px;">
    <td align="right">安全提示问题：</td>
    <td id="regtime" align="left">
    <select name="t3" id="t3" class="" style=" width:212px">
		<option value="我就读的第一所学校的名称？">我就读的第一所学校的名称？</option>
		<option value="我最喜欢的休闲运动是什么？">我最喜欢的休闲运动是什么？</option>
		<option value="我最欣赏的一位名人的名字？">我最欣赏的一位名人的名字？</option>
		<option value="我最喜欢的卡通人物名字？">我最喜欢的卡通人物名字？</option>
		<option value="我最喜欢的一句影视台词？">我最喜欢的一句影视台词？</option>
		<option value="我最喜欢的物品的名称？">我最喜欢的物品的名称？</option>
		<option value="我最喜欢的运动员是谁？">我最喜欢的运动员是谁？</option>
		<option value="我最喜欢的小说的名字？">我最喜欢的小说的名字？</option>
		<option value="我母亲/父亲的生日？">我母亲/父亲的生日？</option>
		<option value="我最爱的人的名字？">我最爱的人的名字？</option>
		<option value="我最喜爱的食物？">我最喜爱的食物？</option>
		<option value="我最喜欢的歌曲？">我最喜欢的歌曲？</option>
		<option value="我的座右铭是？">我的座右铭是？</option>
		<option value="我的初恋日期？">我的初恋日期？</option>
		<option value="我最爱的电影？">我最爱的电影？</option>
		<option value="您母亲的姓名是?">您母亲的姓名是?</option>
		<option value="您母亲的生日是?">您母亲的生日是?</option>
		<option value="您母亲的职业是?">您母亲的职业是?</option>
		<option value="您父亲的姓名是?">您父亲的姓名是?</option>
		<option value="您父亲的生日是?">您父亲的生日是?</option>
		<option value="您父亲的职业是?">您父亲的职业是?</option>
		<option value="您初中学校叫什么名字?">您初中学校叫什么名字?</option>
 
	</select> 

    </td>
    <td align="right">安全提示答案：</td>
    <td id="lastlogintime" align="left"><input readonly type="text" id="t4" class="inputWhere text_01 w_120" /></td>
  </tr>
 
   <tr id="zdhtml">
    <td align="right">总代：</td>
    <td id="Td8" align="left"><select id="zd"><option value="918su">918su</option></select></td>
    <td align="right">占成：</td>
    <td id="Td11" align="left">
        <select id="zc" >
            <option value="0.1">0.1</option>
            <option value="0.2">0.2</option>
            <option value="0.3" selected>0.3</option>
            <option value="0.4">0.4</option>
            <option value="0.5">0.5</option>
            <option value="0.6">0.6</option>
            <option value="0.7">0.7</option>
            <option value="0.8">0.8</option>
            <option value="0.9">0.9</option>
        </select>
    </td>
  </tr>

  <tr align="center" style="background-color:#CDEAFC">
    <td colspan="4"><strong>联系资料</strong></td>
  </tr>
  <tr>
    <td align="right" >电子邮箱：</td>
    <td id="currency" align="left" ><input type="text" id="t5" class="inputWhere text_01 w_120" /></td>
    <td align="right" >手机号码：</td>
    <td id="balance"  align="left" ><input type="text" id="t6" class="inputWhere text_01 w_120" /></td>
  </tr>
  <tr>
    <td align="right" >QQ：</td>
    <td id="money"  align="left"class="red" ><input type="text" id="t7" class="inputWhere text_01 w_120" /></td>
    <td align="right" >国家：</td>
    <td align="left" ><input type="text" id="t8" class="inputWhere text_01 w_120" /></td>
  </tr>
  <tr>
    <td align="right" >省份：</td>
    <td id="bank" align="left" ><input type="text" id="t9" class="inputWhere text_01 w_120" /></td>
    <td align="right" >城市</td>
    <td id="bankTel_1" align="left" ><input type="text" id="t10" class="inputWhere text_01 w_120" /></td>
  </tr>

  <tr align="center" style="background-color:#CDEAFC;">
    <td colspan="4"><strong>银行卡资料</strong></td>
  </tr>
  <tr >
    <td align="right" >银行卡号：</td>
    <td id="Td1" align="left" ><input type="text" id="t11" class="inputWhere text_01 w_120" /></td>
    <td align="right" >开户名</td>
    <td id="Td2" align="left" ><input type="text" id="t12" class="inputWhere text_01 w_120" /></td>
  </tr>
  <tr  style=" display:none">
    <td align="right" >银行：</td>
    <td id="Td3" align="left" ><input type="text" id="t13" class="inputWhere text_01 w_120" /></td>
   
  </tr>
   
    <tr align="center" style="background-color:#CDEAFC">
    <td colspan="4"><strong>其它资料</strong></td>
  </tr>
    <tr>
    <td align="right" >姓名：</td>
    <td id="Td7" align="left" ><input type="text" id="t16" class="inputWhere text_01 w_120" /></td>
    <td align="right" >出生日期：</td>
    <td id="birthday" align="left"></td>
  </tr>
    <tr>
    <td align="right" >网站：</td>
    <td id="Td9" align="left" ><input type="text" id="t17" class="inputWhere text_01 w_120" /></td>
    <td align="right" >状态：</td>
    <td id="Td10" align="left" >
    <select id="txtstatus">
        <option value="2">未审核</option>
        <option value="1">审核通过</option>
        <option value="0">已拒绝</option>
    </select>
    </td>
  </tr>

  <tr>
    <td></td>
    <td></td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
 </tr>
  <tr>
    <td colspan="4" align="center">
    <input type="button" id="submitBtn" class="btn_02" value="提交" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="cancelBtn" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></div></li>
	
	</td>
  </tr>
</table>
</div></div>
</body>
</html>
