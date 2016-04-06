<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BetTime.aspx.cs" Inherits="admin.test.BetTime" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>投注时间</title>
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
        var webSite1 = new Array();

        var typeList = new Array();
        typeList[0] = "单式全场让球";
        typeList[1] = "单式全场大小";
        typeList[2] = "单式半场让球";
        typeList[3] = "单式半场大小";
        typeList[4] = "走地全场让球";
        typeList[5] = "走地全场大小";
        typeList[6] = "走地半场让球";
        typeList[7] = "走地半场大小";
        typeList[8] = "早餐全场让球";
        typeList[9] = "早餐全场大小";
        typeList[10] = "早餐半场让球";
        typeList[11] = "早餐半场大小";
        typeList[12] = "单式全场标准";
        typeList[13] = "单式半场标准";
        typeList[14] = "走地全场标准";
        typeList[15] = "走地半场标准";
        typeList[16] = "早餐全场标准";
        typeList[17] = "早餐半场标准";

        $(function () {
            getCasino();

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
            var url = "/ServicesFile/TestService.asmx/DeleBetlog";
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
            var url = "/ServicesFile/TestService.asmx/GetBetlogByWhere";
            var data = "userid:'" + jQuery("#txtuserid").val() + "',casino:'" + jQuery("#txtcasina").val() + "',gametype:'" + jQuery("#txtgametype").val() + "'";
            $.AjaxCommon(url, data, true, false, function (json) {
                if (json.d != "") {
                    var re = jQuery.parseJSON(json.d);
                    var html = "";
                    $.each(re, function (i) {
                        html += "<tr>";
                        html += "<td>" + i + 1 + "</td>";
                        html += "<td>" + webSite1[re[i].casino] + "</td>";
                        html += "<td>" + typeList[re[i].gametype] + "</td>";
                        html += "<td>" + re[i].userid + "</td>";
                        html += "<td>" + re[i].t1 + "</td>";
                        html += "<td>" + re[i].t2 + "</td>";
                        html += "<td>" + re[i].t3 + "</td>";
                        html += "<td>" + re[i].t4 + "</td>";
                        html += "<td>" + re[i].t5 + "</td>";
                        html += "<td>" + re[i].t6 + "</td>";
                        html += "<td>" + re[i].t7 + "</td>";
                        html += "<td>" + re[i].time + "</td>";

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

        function getCasino() {
            $.AjaxCommon("/ServicesFile/webBasicInfo/WebInfoService.asmx/GetDate", "", false, false, function (json1) {
                if (json1.d != "none") {
                    var str = "<option value=\"\">--网站--</option>";
                    var result = jQuery.parseJSON(json1.d);
                    $.each(result, function (j) {
                        webSite1[result[j].id] = result[j].nametw;
                        str += "<option value=\"" + result[j].id + "\">" + result[j].nametw + "</option>";
                    });
                    $("#txtcasina").html(str);
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
<th width="*" class="tab_top_m"><p id="zdjs">投注时间</p></th>
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
    <select id="txtcasina">
    </select>&nbsp;&nbsp;
    <select id="txtgametype">
        <option value="">--投注类型--</option>
    <option value="0">全场让球</option>
    <option value="1">全场大小</option>
    <option value="12">全场标准</option>
    <option value="2">半场让球</option>
    <option value="3">半场大小</option>
    <option value="13">半场标准</option>
    <option value="4">走地全场让球</option>
    <option value="5">走地全场大小</option>
    <option value="14">走地全场标准</option>
    <option value="6">走地半场让球</option>
    <option value="7">走地半场大小</option>
    <option value="15">走地半场标准</option>
    
    <option value="8">早餐全场让球</option>
    <option value="9">早餐全场大小</option>
    <option value="16">早餐全场1x2</option>
    <option value="10">早餐半场让球</option>
    <option value="11">早餐半场大小</option>
    <option value="17">早餐半场1x2</option>

    </select>&nbsp;&nbsp;
    帐号&nbsp;&nbsp;<input type="text" id="txtuserid" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;&nbsp;&nbsp;
    
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in">搜索</span></a>&nbsp;&nbsp;
    <a id="deleteData"><span class="fa_saurch_in">清空数据</span></a>
    </div>
    <table class="tab2" id="tb2" width="100%" border="0" cellpadding="0" cellspacing="0">
    <thead>
                <tr>
               <th>序号</th>
                <th>网站</th>
                <th>投注类型</th>
                <th>帐号</th>
                <th>投注前处理时间</th>
                <th>点水时间</th>
                <th>点后处理时间</th>
                <th>投注时间</th>
                <th>投注后时间</th>
                <th>备用</th>
                <th>总投注时间</th>
                <th>日期</th>
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