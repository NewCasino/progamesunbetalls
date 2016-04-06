<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="ScoreInput.aspx.cs" Inherits="admin.ReleaseSite.ScoreInput" %>

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
    <script src="/js/jQueryCommon.js" type="text/javascript"></script>
    <script src="/js/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
    <script src="/js/webBasicInfo/zh-CN.js" type="text/javascript"></script>
    <link href="/css/Default/cupertino/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
   <style type="text/css">
      #divTip
        {
        	left:45%;top:45%; 
        	
        	font-family:sans-serif; position:absolute; font-size:10px;padding:5px;background:#f3f3f3;color:gray;display:none;-moz-border-radius:5px;-webkit-border-radius:5px;border:1px solid #ccc
        }
        
   </style>
    <script type="text/javascript">
        var data;
        var webSite1 = new Array()

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

        jQuery(function () {
            
            SetGlobal("");
            setSel();

            getCasino();
            
            $("#time1WhereVal,#time2WhereVal").datepicker().click(function () {
                $(this).val("");
            });
            $("#date1,#date2").datepicker().click(function () {
                $(this).val("");
            });
            $("#selectByWhere").click(function(){
                if($("#league").val() != "" || $("#home").val() != "" || $("#away").val() != "" || $("#time1WhereVal").val() != "" || $("#time2WhereVal").val() != ""){
                  selectByWhere();                    
                }
            });
            $(".inputWhere").keyup(function (e) {
                var currKey = 0, e = e || event;
                currKey = e.keyCode || e.which || e.charCode;
                if (currKey == 13) {
                  selectByWhere();  
                    $(this).blur();
                }
            });                    

            $(".TbSel").click(function () {
                $.AjaxCommon("/ServicesFile/ReleaseSite/ReleaseSiteService.asmx/GetAllToJson4", "language:'" + jQuery("#langue").val() + "',time:'"+$(this).text()+"'", true, false, function (json) {
                    $("#tb2>tbody").html("");
                    if (json.d != "") {
                         var r = $.parseJSON(json.d), html = "";
                    $.each(r, function (x) {
                        html += "<tr id=\"tr1\"><td id=\"numberTD\">"+(x+1)+"</td><td id=\"timeTD\">" + r[x].j + "</td><td id=\"leagueTD\">" + r[x].b + "</td><td id=\"homeTD\">" + r[x].c + "</td><td id=\"awayTD\">" + r[x].d + "</td><td id=\"scoreTD\">" + r[x].e + ":" + r[x].f + "</td><td id=\"halfscoreTD\">" + r[x].g + ":" + r[x].h + "</td><%if(upAc){ %><td id=\"updateTD\"><a id=\"update\" style=\"cursor:hand\" onclick=\"bindClick(this,'" +r[x].a + "')\"><img title=\""+languages.H1009+"\" src=\"/images/Icon/page_edit.gif\" /></a></td><td id=\"cancelTD\"><a id=\"cancel\" style=\"cursor:hand\" onclick=\"cancelLeague(this,'"+r[x].a+"')\">"+languages.H1011+"</a></td><%} %></tr>";
                    });
                } else {
                    html = "<tr id=\"tr1\" align=\"center\"></tr>";
                }
                    $("#tb2>tbody").append(html);
                    jQuery("#tb2").alterBgColor({ odd: "odd", even: "even", selected: "selected", tdCss: "tdCss", istdClick: true });
                });
            });
        });

        var languages = "";
        var lang;
        function SetGlobal(setLang) {

            setLang = $.SetOrGetLanguage(setLang, function () {
                languages = language;
                
                $("#sj").text(languages.H1056);
                $(".H1009").html(languages.H1009);
                $(".H1026").html(languages.H1026);
                $(".H1130").html(languages.H1130);
                $(".H1131").html(languages.H1131);
                $(".H1132").html(languages.H1132);
                $(".H1177").html(languages.H1177);
                $(".H1178").html(languages.H1178);
                $(".H1179").html(languages.H1179);
                $(".H1180").html(languages.H1180);
                 jQuery("#ls").text(languages.H1130);
                 jQuery("#zd").text(languages.H1131);
                 jQuery("#kd").text(languages.H1132);
            });
            lang = setLang;
            setDate();
        }
        
        function setSel() {
            var d = new TipDate();
            $("#lbl1").text(d.curr());
            $("#lbl2").text(d.prev1());
            $("#lbl3").text(d.prev2());
            $("#lbl4").text(d.prev3());
            $("#lbl5").text(d.prev4());
            $("#lbl6").text(d.prev5());
            $("#lbl7").text(d.prev6());
        }

         function TipDate() {
            function formatDate(d) {
                var _todayDate = d.getDate() < 10 ? "0" + d.getDate() : d.getDate();
                //var _year = d.getYear();
                var _month = d.getMonth() + 1;
                _month = _month < 10 ? "0" + _month : _month;
                return _month + "-" + _todayDate;
            }
            var now = new Date();
            function diffDate(m) {
                var dd = new Date();
                var datevalue = now.getDate() + m;
                var month = now.getMonth() + 1;
                if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) {
                    if (datevalue > 31) {
                        dd.setDate(datevalue - 31);
                        dd.setMonth(month);
                    }
                    else {
                        dd.setDate(datevalue);
                    }
                }
                else if (month == 4 || month == 6 || month == 9 || month == 11) {
                    if (datevalue > 30) {
                        dd.setDate(datevalue - 30);
                        dd.setMonth(month);
                    }
                    else {
                        dd.setDate(datevalue);
                    }
                }
                else if (month == 2) {
                    if (datevalue > 28) {
                        dd.setDate(datevalue - 28);
                        dd.setMonth(month);
                    }
                    else {
                        dd.setDate(datevalue);
                    }
                }
                return formatDate(dd);
            }
           return {
                curr: function () {
                    return diffDate(0);
                },
                prev1: function () {
                    return diffDate(-1);
                },
                prev2: function () {
                    return diffDate(-2);
                },
                prev3: function () {
                    return diffDate(-3);
                },
                prev4: function () {
                    return diffDate(-4);
                },
                prev5: function () {
                    return diffDate(-5);
                },
                prev6: function () {
                    return diffDate(-6);
                }
            };
        }

        function setDate() {
        $.AjaxCommon("/ServicesFile/ReleaseSite/ReleaseSiteService.asmx/GetAllToJson3", "language:'"+ jQuery("#langue").val() +"'", true, false, function (json) {
                $("#tb2>tbody").html("");
                if (json.d != "") {
                    var r = jQuery.parseJSON(json.d), html = "";
                    $.each(r, function (x) {
                        html += "<tr id=\"tr1\"><td id=\"numberTD\">"+(x+1)+"</td><td id=\"timeTD\">" + r[x].j + "</td><td id=\"leagueTD\">" + r[x].b + "</td><td id=\"homeTD\">" + r[x].c + "</td><td id=\"awayTD\">" + r[x].d + "</td><td id=\"scoreTD\">" + r[x].e + ":" + r[x].f + "</td><td id=\"halfscoreTD\">" + r[x].g + ":" + r[x].h + "</td><%if(upAc){ %><td id=\"updateTD\"><a id=\"update\" style=\"cursor:hand\" onclick=\"bindClick(this,'" +r[x].a + "')\"><img title=\""+languages.H1009+"\" src=\"/images/Icon/page_edit.gif\" /></a></td><td id=\"cancelTD\"><a id=\"cancel\" style=\"cursor:hand\" onclick=\"cancelLeague(this,'"+r[x].a+"')\">"+languages.H1011+"</a></td><%} %></tr>";
                    });
                } else {
                    html = "<tr id=\"tr1\" align=\"center\"></tr>";
                }
                $("#tb2>tbody").append(html);
                jQuery("#tb2").alterBgColor({ odd: "odd", even: "even", selected: "selected", tdCss: "tdCss", istdClick: true });
            });
        }

        function bindClick(tr,id) {
            var score = jQuery(tr).parent().parent().find("#scoreTD").text();
            var half = jQuery(tr).parent().parent().find("#halfscoreTD").text();
            jQuery(tr).parent().parent().find("#scoreTD").html(""+languages.H1131+"<input type=\"text\" id=\"home\" value=\"" + score.substr(0, score.indexOf(":")) + "\" class=\"w_30\" />&nbsp;&nbsp;:&nbsp;&nbsp;<input type=\"text\" id=\"away\" value=\"" + score.substr(score.indexOf(":") + 1) + "\" class=\"w_30\" />"+languages.H1132+"");
            jQuery(tr).parent().parent().find("#halfscoreTD").html(""+languages.H1131+"<input type=\"text\" id=\"halfhome\" value=\"" + half.substr(0, half.indexOf(":")) + "\" class=\"w_30\" />&nbsp;&nbsp;:&nbsp;&nbsp;<input type=\"text\" id=\"halfaway\" value=\"" + half.substr(half.indexOf(":") + 1) + "\" class=\"w_30\" />"+languages.H1132+"");
            jQuery(tr).parent().parent().find("#updateTD").html("<a style=\"cursor:hand\" id=\"saveA\" onclick=\"bindSave(this,'" + id + "')\" ><img src=\"/images/Icon/Icon321.png\" title=\""+languages.H1025+"\" /></a>&nbsp;&nbsp;&nbsp;&nbsp;<a style=\"cursor:hand\" onclick=\"bindEsc(this,'" + score + "','" + half + "','" + id + "')\" id=\"escA\"><img src=\"/images/Icon/Icon390.png\"  title=\""+languages.H1011+"\" /></a>");
        }

        function bindSave(tr,id) {
            var score = jQuery(tr).parent().parent().find("#scoreTD").find("#home").val()+":" + jQuery(tr).parent().parent().find("#scoreTD").find("#away").val();
            var half = jQuery(tr).parent().parent().find("#halfscoreTD").find("#halfhome").val() + ":" + jQuery(tr).parent().parent().find("#halfscoreTD").find("#halfaway").val();
            jQuery(tr).parent().parent().find("#scoreTD").html("" + score);
            jQuery(tr).parent().parent().find("#halfscoreTD").html("" + half);
            var data = "id:'" + id + "',home:'" + score.substr(0, score.indexOf(":")) + "',";
            data += "away:'" + score.substr(score.indexOf(":")+1) + "',";
            data += "halfhome:'" + half.substr(0, half.indexOf(":")) + "',";
            data += "halfaway:'" + half.substr(half.indexOf(":")+1) + "'";
            jQuery.AjaxCommon("/ServicesFile/ReleaseSite/ReleaseSiteService.asmx/updatescore", data, false, false, function (json) { });
            <%if(upAc){ %>
            jQuery(tr).parent().parent().find("#updateTD").html("<a style=\"cursor:hand\" id=\"update\"onclick=\"bindClick(this,'" + id + "')\"><img title=\""+languages.H1009+"\"  src=\"/images/Icon/page_edit.gif\" /></a>");
            <%} %>
        }

        function bindEsc(tr,score,half,id) {
            //var score = jQuery(tr).parent().parent().find("#scoreTD").find("#home").val() +":" + jQuery(tr).parent().parent().find("#scoreTD").find("#away").val();
            //var half = jQuery(tr).parent().parent().find("#scoreTD").find("#halfhome").val()+":" + jQuery(tr).parent().parent().find("#scoreTD").find("#halfaway").val();
            jQuery(tr).parent().parent().find("#scoreTD").html("" + score);
            jQuery(tr).parent().parent().find("#halfscoreTD").html("" + half);
            <%if(upAc){ %>
            jQuery(tr).parent().parent().find("#updateTD").html("<a style=\"cursor:hand\" id=\"update\"onclick=\"bindClick(this,'" + id + "')\"><img title=\""+languages.H1009+"\"  src=\"/images/Icon/page_edit.gif\" /></a>");
            <%} %>
        }

        function selectByWhere(){
            $.AjaxCommon("/ServicesFile/ReleaseSite/ReleaseSiteService.asmx/GetLeagueByWhere", "language:'" + jQuery.trim($("#langue").val()) + "',league:'" + jQuery.trim($("#league").val()) + "',home:'" + jQuery.trim($("#home").val()) + "',away:'" + jQuery.trim($("#away").val()) + "',beginTime:'"+$("#time1WhereVal").val()+"',endTime:'"+$("#time2WhereVal").val()+"'", true, false, function (json) {
                $("#tb2>tbody").html("");
                if (json.d != "") {
                    var r = $.parseJSON(json.d), html = "";
                    $.each(r, function (x) {
                        html += "<tr id=\"tr1\"><td id=\"numberTD\">"+(x+1)+"</td><td id=\"timeTD\">" + r[x].j + "</td><td id=\"leagueTD\">" + r[x].b + "</td><td id=\"homeTD\">" + r[x].c + "</td><td id=\"awayTD\">" + r[x].d + "</td><td id=\"scoreTD\">" + r[x].e + ":" + r[x].f + "</td><td id=\"halfscoreTD\">" + r[x].g + ":" + r[x].h + "</td><%if(upAc){ %><td id=\"updateTD\"><a id=\"update\" style=\"cursor:hand\" onclick=\"bindClick(this,'" +r[x].a + "')\"><img title=\""+languages.H1009+"\" src=\"/images/Icon/page_edit.gif\" /></a></td><td id=\"cancelTD\"><a id=\"cancel\" style=\"cursor:hand\" onclick=\"cancelLeague(this,'"+r[x].a+"')\">"+languages.H1011+"</a></td><%} %></tr>";
                    });
                } else {
                    html = "<tr id=\"tr1\" align=\"center\"></tr>";
                }
                $("#tb2>tbody").append(html);
                jQuery("#tb2").alterBgColor({ odd: "odd", even: "even", selected: "selected", tdCss: "tdCss", istdClick: true });
//              $("#league").val(""); $("#home").val(""); $("#away").val("");
            });            
        }

        function cancelLeague(obj,id)
        {
            //弹出窗口初始化
            jQuery.each(jQuery("#cancelInfo :checkbox"),function(i,n){
                if($(n).attr("checked") == true){
                    $(n).attr("checked",false);
                }
            });
            jQuery("#reason").val("");
            jQuery("#txtusername").val("");
            jQuery("#txtorderid").val("");
            jQuery("#txtip").val("");
            jQuery("#date1").val("");
            jQuery("#date2").val("");
            jQuery("#ot").show();
            jQuery("#qxdiv").html("");
            jQuery("#ol a").remove();

            $("#cancelInfo").dialog({modal: true, width:800});
            $("#reason").val("").focus();
            $("#zc").unbind("click").bind("click",function(){
                if($(this).attr("checked")==true){
                    $("#ot").hide();
                }
                else{
                    $("#ot").show();
                }
            });
            $("#qxbtn").unbind("click").bind("click",function(){
                //查找要取消的注单
                var username=$("#txtusername").val();
                var orderid = $("#txtorderid").val();
                var ip = $("#txtip").val();
                var date1 = $("#date1").val();
                var date2 = $("#date2").val();
                var time1 = $("#time1").val();
                var time2 = $("#time2").val();
                var gameid = id;
                var IsHalf = "";
                var websiteiID = "";
                var t1 = "";
                var t2 = "";

                if(username =="" && orderid=="" && ip=="" && (date1=="" || date2=="")){
                    return;
                }
                if(date1 != "" && date2 != ""){
                    t1 = date1 + " " + time1 + ":59:59";
                    t2 = date2 + " " + time2 + ":59:59";
                }
                if($("#bc").attr("checked")==true){
                    IsHalf += "'1'";
                }
                if($("#qc").attr("checked")==true){
                    if(IsHalf == ""){
                        IsHalf = "'0'";
                    }
                    else{
                        IsHalf += ",'0'";
                    }
                }
                jQuery.each(jQuery("#websites input"),function(i,n){
                    if(jQuery(n).attr("checked")==true){
                        if(websiteiID==""){
                            websiteiID=jQuery(n).attr("id");
                        }
                        else{
                            websiteiID+="," + jQuery(n).attr("id");
                        }
                    }
                });

                var url = "/ServicesFile/ReleaseSite/ReleaseSiteService.asmx/GetOrderC";
                var data = "isHalf:\"" + IsHalf + "\",webSiteiID:\"" + websiteiID + "\",userName:\"" + username + "\",orderID:\"" + orderid + "\",IP:\"" + ip + "\",time1:\"" + t1 + "\",time2:\"" + t2 + "\"";
                var html = "";
                jQuery.AjaxCommon(url,data,false,false,function(json){
                    //成功返回
                    var result = jQuery.parseJSON(json.d);
                    
                    //var result = json.d;
                    html = "<table class=\"tab2\" width=100% cellpadding=0 cellspacing=\"0\" border=0 >";
                    html += "<thead><tr>";
                    html += "<th><input  type=\"checkbox\" value=\"\" name=\"test\" title=\"全选/取消\"/></th>";
                    html += "<th>单号</th>";
                    html += "<th>会员</th>";
                    html += "<th>比赛</th>";
                    html += "<th>投注类型</th>";
                    html += "<th>投注金额</th>";
                    html += "<th>网站</th>";
                    html += "<th>投注时间</th>";
                    html += "</tr></thead>";
                    jQuery.each(result,function(i){
                    
                        html += "<tr>";
                        html += "<td><input name=\"orderid\" type=\"checkbox\" value=\"" + result[i].OrderID + "\" /> </td>";
                        html += "<td>" + result[i].OrderID + "</td>";
                        html += "<td>" + result[i].UserName + "</td>";
                        html += "<td>" + result[i].Hometw + " vs " + result[i].Awaytw + "</td>";
                        html += "<td>" + typeList[result[i].BetType] + "</td>";
                        html += "<td>" + result[i].Amount + "</td>";
                        html += "<td>" + webSite1[result[i].WebSiteiID] + "</td>";
                        html += "<td>" + result[i].time + "</td>";
                        html += "</tr>";
                    });
                    html += "</table>";
                });
                
                jQuery("#qxdiv").html(html);
                jQuery("#ol b").after("<a style=\"color:blue;\" href=\"javascript:void(0);\" onclick='$(\"#qxdiv\").html(\"\");$(\"#ol a\").remove();'>清除注单列表</a>");
                jQuery(".tab2").alterBgColor({ odd: "odd", even: "even", selected: "selected", moveOver: "over" });
            });
            $("#submitBtn").unbind("click").bind("click",function(){
                var IsHalf = "";
                var websiteiID = "";
                var zc;
                var orderID = "";
                var reason;

                reason = $("#reason").val();
                if(jQuery("#zc").attr("checked")==true){
                    zc = "1";
                }
                else{
                    zc = "0";
                }
                
                if(jQuery(":checkbox[name]=orderid").length > 0){
                    jQuery.each(jQuery(":checkbox[name]=orderid"),function(i,n){
                    
                        if(jQuery(n).attr("checked") == true){
                            if(orderID == ""){
                                orderID = "'" + jQuery(n).attr("value") + "'";
                            }
                            else{
                                orderID += ",'" + jQuery(n).attr("value") + "'";
                            }
                        }
                    });
                }
                if($("#bc").attr("checked")==true){
                    IsHalf += "'1'";
                }
                if($("#qc").attr("checked")==true){
                    if(IsHalf == ""){
                        IsHalf = "'0'";
                    }
                    else{
                        IsHalf += ",'0'";
                    }
                }
                jQuery.each(jQuery("#websites input"),function(i,n){
                    if(jQuery(n).attr("checked")==true){
                        if(websiteiID==""){
                            websiteiID=jQuery(n).attr("id");
                        }
                        else{
                            websiteiID+="," + jQuery(n).attr("id");
                        }
                    }
                });

                if(reason.length <=0){
                    alert(languages.H1270+""+languages.H1000);
                    $("#reason").focus();
                    return;
                }
                if(zc == "0"){
                    if(jQuery(":checkbox[name]=orderid").length > 0){
                        if(orderID == ""){
                            alert("请选择要取消的注单");
                            return;
                        }
                    }
                    else{
                        if(IsHalf=="" && websiteiID==""){
                            alert("请选择取消条件");
                            return;
                        }
                    }
                }
                
                var url = "/ServicesFile/ReleaseSite/ReleaseSiteService.asmx/CancelLeague";
                var data = "id:\"" + id + "\",reason:\"" + reason + "\",zc:\"" + zc + "\",isHalf:\"" + IsHalf + "\",webSiteiID:\"" + websiteiID + "\",orderID:\"" + orderID + "\"";
                $.AjaxCommon(url, data, true, false, function(json){
                    if(json.d)
                    {
                        $("#reason").val("");
                        alert(languages.H1187);
                        selectByWhere();
                        $("#cancelInfo").dialog("close");
                    }
                    else{
                        alert("取消比赛失败");
                    }
                });
                
            });
            $("#cancelBtn").click(function(){
                $("#cancelInfo").dialog("close");
            });
        }

        function getCasino() {
            $.AjaxCommon("/ServicesFile/webBasicInfo/WebInfoService.asmx/GetDate", "", false, false, function (json1) {
                if (json1.d != "none") {
                    var str = "";
                    var result = jQuery.parseJSON(json1.d);
                    $.each(result, function (j) {
                        webSite1[result[j].id] = result[j].nametw;
                        str += "<label><input type=\"checkbox\" id=\"" + result[j].id + "\">" + result[j].nametw + "</label>&nbsp;";
                    });
                    $("#websites").html(str);
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
<th width="*" class="tab_top_m"><p class="H1177">比赛结果</p></th>
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
    <form id="form1" runat="server">    
    <div class="users_ma_tit"><div  style="width:100%">
    &nbsp;&nbsp;<a id="ls">联赛</a>&nbsp;&nbsp;<input type="text" id="league" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'"/>&nbsp;&nbsp;
    <a id="zd">主队</a>&nbsp;&nbsp;<input type="text" id="home" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;
    <a id="kd">客队</a>&nbsp;&nbsp;<input type="text" id="away" class="inputWhere text_01 w_100" onmouseover="this.className='text_01_h w_100'" onmouseout="this.className='text_01 w_100'" />&nbsp;&nbsp;
    <a id="sj">时间</a>&nbsp;&nbsp;<input type="text" id="time1WhereVal" class="inputWhere text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" readonly="readonly" />－<input type="text" id="time2WhereVal" class="inputWhere text_01 w_80" onmouseover="this.className='text_01_h w_80'" onmouseout="this.className='text_01 w_80'" readonly="readonly" />&nbsp;&nbsp;
    <a id="selectByWhere" class="fa_saurch"><span class="fa_saurch_in">搜索</span></a>
    </div>
    <div class="fl h30" style="width:100%">
    <span class="TbSel" id="lbl7" d="7"></span>
    <span class="TbSel" id="lbl6" d="6"></span>
    <span class="TbSel" id="lbl5" d="5"></span>
    <span class="TbSel" id="lbl4" d="4"></span>
    <span class="TbSel" id="lbl3" d="3"></span>
    <span class="TbSel" id="lbl2" d="2"></span>
    <span class="TbSel" id="lbl1" d="1"></span>
        </div>
    </div>
    <table class="tab2" id="tb2" width="100%" border="0" cellpadding="0" cellspacing="0">
    <thead>
    <tr>
    <th class="H1026">序号</th>
    <th class="H1178">开始时间</th>
    <th class="H1130">联赛</th>
    <th class="H1131">主队</th>
    <th class="H1132">客队</th>
    <th class="H1179">全场比分</th>
    <th class="H1180">上半场比分</th>
    <%if (upAc)
      { %>
    <th class="H1009">修改</th>
    <th class="H1011H1170">取消比赛</th>
    <%} %>
    </tr>
    </thead>
    <tbody id="showInfo">
    <%--<tr id="tr1">
    <td id="numberTD"></td>
    <td id="timeTD"></td>
    <td id="leagueTD"></td>
    <td id="homeTD"></td>
    <td id="awayTD"></td>
    <td id="scoreTD"></td>
    <td id="halfscoreTD"></td>
    <%if (upAc)
      { %>
    <td id="updateTD"></td>
    <td id="cancelTD"></td>
    <%} %>
    </tr>--%>
    </tbody>
    </table>
    </form>
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

<div class="undis">
<div id="cancelInfo" title="取消比赛" >
<div class="showdiv">
<ul>
<li><h3>一、选择取消条件</h3></li>
<li>　1、<b>整场</b>　<label><input type="checkbox" id="zc" />取消整场赛事</label></li>
<label id="ot">
    <li>　2、<b>半场/全场</b>　<label><input type="checkbox" id="bc" />取消半场的投注</label>&nbsp;<label><input type="checkbox" id="qc" />取消全场的投注</label></li>
    <li>　3、<b>取消网站</b>
        <label id="websites"><label><input type="checkbox" />皇冠</label>&nbsp;<label><input type="checkbox" />皇冠</label></label>
    </li>
    <li id="ol">　4、<b>取消单笔注单&nbsp;&nbsp;</b>
    <div class="top_banner h24">
    <div class="fl">
    用户名
    <input type="text" class="text_01 h20 w_80" id="txtusername" />
    订单号
    <input type="text" class="text_01 h20 w_80" id="txtorderid" />
    IP
    <input type="text" id="txtip" class="text_01 h20 w_80" />
    投注时间
    <input type="text" id="date1" class="text_01 h20 w_60" /><input type="text" id="time1" value="0" class="text_01 h20 w_30" />-
    <input type="text" id="date2" class="text_01 h20 w_60" /><input type="text" id="time2" value="23" class="text_01 h20 w_30" />

    <input type="button" class="btn_01" id="qxbtn" onmouseover="this.className='btn_01_h'" onmouseout="this.className='btn_01'" value="查找" />
    </div>

    </div>

    <div id="qxdiv"></div>

    </li>
</label>
<li><h3>二、取消原因</h3>　<textarea id="reason" rows="5" cols="50" class="input"></textarea></li>
<li><div align="center" class="mtop_30">
    <input type="button" id="submitBtn" class="btn_02" value="提交" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
    <input type="button" id="cancelBtn" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></div></li>
</ul>
</div>
</div>
<div id="divTip" ></div>
</div>
</body>
</html>
