<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberLevel.aspx.cs" Inherits="admin.User.MemberLevel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>投注</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.4.1.min.js"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/jQueryCommon.js"></script>
    <script src="/js/page/pageJs.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function(){
             jQuery(".tab2").alterBgColor({ odd: "odd", even: "even", selected: "selected", tdCss: "tdCss" });
        });
        var zm = "";
        var pd = 0;
        var count1 = 0;
        var pageCount = 20;
        var roleId = 2; //级别
        var upID = 0; //上级ID
        var upUserName = "";
        var aIndex = 0;
        var type;
        var gradeArr=new Array();
        jQuery(function () {
            jQuery("#tr1").hide();
            type = new Array();
            type[0] = "分公司";
            type[1] = "股东";
            type[2] = "总代";
            type[3] = "代理";
            type[4] = "会员";
            SetGlobal("");
        });

        //---------多语言处理-----------
        var languages = "";
        var lang;
        function SetGlobal(setLang) {
        //debugger
            setLang = $.SetOrGetLanguage(setLang, function () {
            //debugger
                languages = language;



            });
            //debugger
            lang = setLang;

                    jQuery.AjaxCommon("/ServicesFile/webBasicInfo/Statistics/StatisticsService.asmx/GetGradeByLan","lan:'" +lang+"'",false,false,function(json){
                    var result=jQuery.parseJSON(json.d);
                    jQuery.each(result,function(i){
                    //debugger
                        gradeArr[i]=new Array();
                        gradeArr[i][0] = result[i].ID;
                        gradeArr[i][1] = result[i].Lname;
                        gradeArr[i][2] = result[i].LevelRemark;
                    });
                });

                getpage();
                jQuery("#selectbutton").click(function () {
                    pd = 0;
                    getpage();
                });

                $("#tz").html(languages.H1355 + ":");
                $("#sy").html(languages.H1460);
                $("#H1218").html(languages.H1218);
                $("#stateSlt option:eq(0)").text(languages.H1040);
				$("#stateSlt option:eq(1)").text(languages.H1049);
				$("#stateSlt option:eq(2)").text(languages.H1050);
				$("#stateSlt option:eq(3)").text(languages.H1101);
                $("#selectbutton").val(languages.H1447);
                $("#Th1").html(languages.H1218);
				$("#H1449").html(languages.H1449);
				$("#H1454").html(languages.会员等级);
				$("#H1492").html(languages.H1492);
				$("#H1493").html(languages.H1493);
				$("#H1070").html(languages.H1070);
				$("#H1070").html(languages.H1070);
				$("#H1009").html(languages.H1009);
				
				$("#H1028").html(languages.H1028);
				$("#H1029").html(languages.H1029);
				$("#H10281").html(languages.H1028);
				$("#H1030").html(languages.H1030);
				$("#H1031").html(languages.H1031);
				$("#H1032").html(languages.H1032);
				$("#H1033").html(languages.H1033);
				$("#H1034").html(languages.H1034);
        }
        //--------多语言处理结束---------

        /*----------------获得该标记中账号下的子集账号----------*/
        function getCount1(name, id, Index) {
            pd = 1;
            if (Index == 0) {
                aIndex = Index;
                jQuery("#pathP>a:gt(" + Index + ")").remove();
            }
            else {
                aIndex = Index-1;
                jQuery("#pathP>a:gt(" + Index + ")").remove();
                jQuery("#pathP>a:eq(" + Index + ")").remove();
            }
            roleId = parseInt(id);
            upUserName = name;
            getpage();
        }

        /*--------------获得该标记中账号下的子集账号结束--------*/
        /*----------------获得该账号下的子集账号----------*/
        function getCount(name, id, id1) {
            pd = 1;
            roleId = parseInt(id);
            upID = id1;
            upUserName = name;
            getpage();
        }
        /*--------------获得该账号下的子集账号结束--------*/
        /*----------------获得分页-----------------------*/
        function getpage() {
            var data = "moneyType:'',upUserName:'" + upUserName + "',userName:'" + jQuery("#UserName").val() + "',status:'" + jQuery("#stateSlt").val() + "',roleId:" + roleId;
            jQuery.AjaxCommon("/ServicesFile/UserService.asmx/GetAgentsAcount", data, true, false, function (json) {
                var count = 0;
                if (json.d != "none") {
                    count1 = json.d;
                    if (count1 % pageCount == 0) {
                        count = parseInt(count1 / pageCount);
                    }
                    else {
                        count = parseInt(count1 / pageCount) + 1;
                    }
                }
                //参数:总页数,总记录数,每页记录数,查询的起始行变量名,查询数量变量名
                IsPage("" + count, "" + count1, "" + pageCount, "limitStart", "limitEnd");
            });
        }
        /*----------------获得分页结束-------------------*/

        /*-------------------------修改方法-----------------------------*/
        function up(obj, id) {
            var min = "";
            var max = "";
            var onemax = "";
            var str="<select>";
            var userName=jQuery(obj).parent().parent().find("#UID").text();
            min = jQuery(obj).parent().parent().find("#Umin").text();
            max = jQuery(obj).parent().parent().find("#Umax").text();
            onemax = jQuery(obj).parent().parent().find("#Uone").text();
            jQuery.each(gradeArr,function(i){
                str+="<option value=" + gradeArr[i][0];
                if(gradeArr[i][1] == min) {
                    str+=" selected";
                }
                str += ">" + gradeArr[i][1];
            });
            str += "</select>";
            jQuery(obj).parent().parent().find("#Umin").html(str);
            jQuery(obj).parent().parent().find("#Umax").html("<input onblur=\"min(this,'" + id + "','" + min + "','" + max + "','" + onemax + "')\" type=\"text\" value=\"" + max + "\" class=\"text_01 h20\" onmouseover=\"this.className='text_01_h h20'\" onmouseout=\"this.className='text_01 h20'\" />");
            jQuery(obj).parent().parent().find("#Uone").html("<input onblur=\"min(this,'" + id + "','" + min + "','" + max + "','" + onemax + "')\" type=\"text\" value=\"" + onemax + "\" class=\"text_01 h20\" onmouseover=\"this.className='text_01_h h20'\" onmouseout=\"this.className='text_01 h20'\" />");
            jQuery(obj).parent().parent().find("#upda").html("<a style=\"cursor:hand\" onclick=\"save(this,'" + id + "')\" id=\"saveA\" ><img src=\"/images/Icon/Icon321.png\" title=\"" + languages.H1025 + "\" /></a>&nbsp;&nbsp;&nbsp;&nbsp;<a style=\"cursor:hand\" id=\"escA\" onclick=\"esc(this,'" + id + "','" + min + "','" + max + "','" + onemax + "')\"><img src=\"/images/Icon/Icon390.png\"  title=\"" + languages.H1011 + "\" /></a>");
        }

        function min(obj, id, min, max, onemax) {
            jQuery.each(jQuery(obj).parent().find("label"),function(i,n){
                jQuery(n).remove();
            });
            jQuery(obj).after("<label id=\"err" + id + "\" style=\"color:red\"></label>");
            if(!IsElJudge(obj,("err"+id),"decimal",languages.H1306,languages.H1350,20)) {
                return false;
            }
                jQuery(obj).parent().parent().find("#Umax>label").remove();
                jQuery(obj).parent().parent().find("#Uone>label").remove();
        }

        function save(obj, id) {
            if (jQuery(obj).parent().parent().find("#Umin>label").length > 0 || jQuery(obj).parent().parent().find("#Umax>label").length > 0 || jQuery(obj).parent().parent().find("#Uone>label").length > 0) {
                return false;
            }
            //debugger
            var min = "";
            var max = "";
            var onemax = "";
            var userName=jQuery(obj).parent().parent().find("#UID").text();
            var txt = jQuery(obj).parent().parent().find("#Umin select :selected").text();
            min = jQuery(obj).parent().parent().find("#Umin select").val();
            max = jQuery(obj).parent().parent().find("#Umax>:text").val();
            onemax = jQuery(obj).parent().parent().find("#Uone>:text").val();
            jQuery(obj).parent().parent().find("#Umin").html(txt);
            jQuery(obj).parent().parent().find("#Umax").html(max);
            jQuery(obj).parent().parent().find("#Uone").html(onemax);
            <% if(mdfAc) { %>
            jQuery(obj).parent().parent().find("#upda").html("<a style=\"cursor:hand\" onclick=\"up(this,'"+id+"')\"><img title=\"" + languages.H1009 + "\" src=\"/images/Icon/page_edit.gif\" /></a>");
            <% } %>
            var data = "UserLevel:'" + min + "',Coefficient:" + max + ",Proportion:" + onemax + ",userName:'" + userName + "'";
            jQuery.AjaxCommon("/ServicesFile/UserService.asmx/UpdateUserLevel", data, false, false, function (json) { 
                
            });
        }

        function esc(obj, id, min, max, onemax) {
            jQuery(obj).parent().parent().find("#Umin").html(min);
            jQuery(obj).parent().parent().find("#Umax").html(max);
            jQuery(obj).parent().parent().find("#Uone").html(onemax);
            <% if(mdfAc) { %>
            jQuery(obj).parent().parent().find("#upda").html("<a style=\"cursor:hand\" onclick=\"up(this,'"+id+"')\"><img title=\"" + languages.H1009 + "\" src=\"/images/Icon/page_edit.gif\" /></a>");
            <% } %>
        }
        /*-------------------------修改方法结束-----------------------------*/



        /*--------------查询方法------------------------------*/
        
        function setDate(data) {
            <% if(searchAc) { %>
            var data = "moneyType:'',upUserName:'" + upUserName + "',userName:'" + jQuery("#UserName").val() + "',status:'" + jQuery("#stateSlt").val() + "'," + data + ",roleId:" + roleId;
            <% } else { %>
            var data = "moneyType:'',upUserName:'" + upUserName + "',userName:'',status:''," + data + ",roleId:" + roleId;
            <% } %>
            jQuery("#UserName").val("");
            jQuery.AjaxCommon("/ServicesFile/UserService.asmx/GetAgents", data, true, false, function (json) {
                if (json.d != "none") {
                    jQuery("#showInfo>tr").remove();
                    var result = jQuery.parseJSON(json.d);
                    if (pd) {
                        jQuery("#pathP").html(jQuery("#pathP").html() + (roleId != 2 ? "<a onmouseover=\"this.style.cursor='hand'\" onclick=\"getCount1('" + upUserName + "','" + roleId + "','" + (++aIndex) + "')" + "\"> >" + upUserName + "</a>" : ""));
                    }
                    pd = 0;
                    jQuery.each(result, function (i) {
                    //debugger
                        var tr = jQuery("#tr1").clone();
                        var gname = "";
                        var gId=result[i].UserLevel;
                        jQuery.each(gradeArr,function(j){
                        //debugger
                            if(gId==gradeArr[j][0]) {
                                gname = gradeArr[j][1];
                            }
                        });
                        tr.find("#UID").html((roleId != 6 ? "<a onmouseover=\"this.style.cursor='hand'\" " + ("onclick=\"getCount('" + result[i].UserName + "','" + (parseInt(result[i].RoleId) + 1) + "'," + result[i].ID + ")") + "\">" + result[i].UserName + "</a>" : "" + result[i].UserName));
                        tr.find("#UName").html("" + result[i].Name);
                        tr.find("#Umin").html(gname);
                        tr.find("#Umax").html(result[i].Coefficient);
                        tr.find("#Uone").html(result[i].Proportion);
                        tr.find("#Status").html(result[i].Status == "1" ? languages.H1049 : (result[i].Status == "0" ? languages.H1050 : languages.H1101));
                        <% if(mdfAc) { %>
                        if(roleId==6){
                            tr.find("#upda").html("<a style=\"cursor:hand\" onclick=\"up(this,'" + result[i].ID + "')\"><img title=\"" + languages.H1009 + "\" src=\"/images/Icon/page_edit.gif\" /></a>");
                        }
                        <% } %>
                        tr.show().appendTo("#showInfo");
                    });
                }
            });
        }
        /*--------------查询方法结束--------------------------*/
        
    </script>
    <style type="text/css">
    .ui-effects-transfer { border: 2px dotted gray; } 
        #divTip
        {
        	left:45%;top:45%; 
        	
        	font-family:sans-serif; position:absolute; font-size:10px;padding:5px;background:#f3f3f3;color:gray;display:none;-moz-border-radius:5px;-webkit-border-radius:5px;border:1px solid #ccc
        }

    </style>
</head>
<body>
    <table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="pathP"><font class="st" id="tz"> 会员等级：</font><a onmouseover="this.style.cursor='hand'" onclick="getCount1('','2','0')"><span id="sy"> 首页</span></a></p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<% if (searchAc)
   { %>
<div class="top_banner h30">

&nbsp;&nbsp;<span id="H1218">帐号</span>：<input type="text" name="UserName" id="UserName" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" />
<select id="stateSlt">
    <option value="">全部</option>
    <option value="1">启用</option>
    <option value="0">禁用</option>
    <option value="2">暂停</option>
</select>
<input type="button" id="selectbutton" class="btn_01" onmouseover="this.className='btn_01_h'" onmouseout="this.className='btn_01'" value="查找" />
</div>
<% } %>

<div id="add_list" class="new_tr undis">
<div class="new_trfoot"></div>
</div>



<div class="cl"></div>

    <table width="100%" id="tb" cellpadding="0" class="tab2" >
        <thead>
            <tr>
                <th id="H1218">帐号</th>
                <th id="H1449">姓名</th>
                <th id="H1454">会员等级</th>
                <th id="H1492">跟投系数</th>
                <th id="H1493">吃货比例</th>
                <th id="H1070">状态</th>
                <% if (mdfAc)
                   { %>
                <th id="H1009">修改</th>
                <% } %>
            </tr>
        </thead>
        <tbody id="showInfo">
            
            
            </tbody>
          <tfoot><tr>
          <td colspan="9" >
              <div id="pageDiv" class="grayr"><span id="H1028">总共</span><label id="infoCount"></label><span id="H1029">条记录</span>,<span id="H10281">共</span><label id="pageCount"></label><span id="H1030">页</span><a style="cursor:hand"> <span id="H1031">首页</span> </a><a style="cursor:hand"> <span id="H1032">上一页</span> </a><span id="pageSpan"></span><a style="cursor:hand"> <span id="H1033">下一页</span> </a><a style="cursor:hand"> <span id="H1034">尾页</span> </a></div>
          </td>
          </tr>
          <tr id="tr1">
            <td id="UID"></td>
            <td id="UName"></td>
            <td id="Umin"></td>
            <td id="Umax"></td>
            <td id="Uone"></td>
            <td id="Status"></td>
            <% if (mdfAc)
               { %>
            <td id="upda"></td>
            <% } %>
            </tr>
          </tfoot>

    </table>
        
    
    
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