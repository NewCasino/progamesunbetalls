<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginTime.aspx.cs" Inherits="admin.test.LoginTime" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>登录时间</title>
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

                $("#selectByWhere").click(function () {
                    SelectByWhere();
                });

                $("#deleteData").click(function () {
                    if (confirm("确定要清空数据表？")) {
                        DeleteData();
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
            lang = setLang;
        }

        function DeleteData() {
            var url = "/ServicesFile/TestService.asmx/DeleTestlog";
            var data = "";
            $.AjaxCommon(url, data, true, false, function (json) {
                if (json.d) {
                    alert("清除成功！");
                }
                else {
                    alert("清除失败！");
                }
            });
        }

        function SelectByWhere() {
        
            $("#tb2>tbody").html("");
            var url = "/ServicesFile/TestService.asmx/GetTestlogByWhere";
            var data = "userid:'" + jQuery("#txtuserid").val() + "'";
            $.AjaxCommon(url, data, true, false, function (json) {
            
                if (json.d != "") {
                    var re = jQuery.parseJSON(json.d);
                    var html = "";
                    $.each(re, function (i) {
                    
                        html += "<tr>";
                        html += "<td>" + i + 1 + "</td>";
                        html += "<td>" + re[i].userid + "</td>";
                        html += "<td>" + re[i].begintime + "</td>";
                        html += "<td>" + re[i].endtime + "</td>";
                        html += "<td>" + re[i].lengths + "</td>";
                        html += "<td>" + re[i].times + "</td>";

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
<th width="*" class="tab_top_m"><p id="zdjs">登录时间</p></th>
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

    帐号&nbsp;&nbsp;<input type="text" id="txtuserid" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;&nbsp;&nbsp;
    
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in">搜索</span></a>&nbsp;&nbsp;
    <a id="deleteData"><span class="fa_saurch_in">清空数据</span></a>
    </div>
    <table class="tab2" id="tb2" width="100%" border="0" cellpadding="0" cellspacing="0">
    <thead>
                <tr>
               <th>序号</th>
                <th>帐号</th>
                <th>登录开始时间</th>
                <th>登录结束时间</th>
                <th>数据大小</th>
                <th>登录总时间</th>
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