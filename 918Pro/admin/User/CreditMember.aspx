<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreditMember.aspx.cs" Inherits="admin.User.CreditMember" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        //var percet = 0;
        //var commission = 0;
        var pd = 0;
        var count1 = 0;
        var pageCount = 20;
        var roleId = 2; //级别
        var upID = 0; //上级ID
        var upUserName = "";
        var aIndex = 0;
        var type;
        /*-------上一级占成，佣金--------*/
        var comm = 0; //占成
        var perA = 0; //佣金A
        var perB = 0; //佣金B
        var perC = 0; //佣金C
        /*-------上一级占成，佣金--------*/
        /*-------公司占成，佣金--------*/
        var zgscomm = 0; //占成
        var zgsperA = 0; //佣金A
        var zgsperB = 0; //佣金B
        var zgsperC = 0; //佣金C
        /*-------公司占成，佣金--------*/
        /*-------分公司账号占成，佣金--------*/
        var fname = ""; //分公司账号
        var fcomm = 0; //占成
        var fperA = 0; //佣金A
        var fperB = 0; //佣金B
        var fperC = 0; //佣金C
        /*-------分公司占成，佣金--------*/
        /*-------股东占成，佣金--------*/
        var gname = ""; //股东账号
        var gcomm = 0; //占成
        var gperA = 0; //佣金A
        var gperB = 0; //佣金B
        var gperC = 0; //佣金C
        /*-------股东占成，佣金--------*/
        /*-------总代占成，佣金--------*/
        var zname = ""; //总代账号
        var zcomm = 0; //占成
        var zperA = 0; //佣金A
        var zperB = 0; //佣金B
        var zperC = 0; //佣金C
        /*-------总代占成，佣金--------*/
        /*-------代理占成，佣金--------*/
        var dname = ""; //代理账号
        var dcomm = 0; //占成
        var dperA = 0; //佣金A
        var dperB = 0; //佣金B
        var dperC = 0; //佣金C
        /*-------代理占成，佣金--------*/
        var zc = "";
        var yja = "";
        var yjb = "";
        var yjc = "";
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

            setLang = $.SetOrGetLanguage(setLang, function () {
                languages = language;
            setConfig();
            setZM();
            getpage();
            jQuery("#selectbutton").click(function () {
                pd = 0;
                getpage();
            });

                $("#yyye").html(languages.信用与户口余额);
                $("#H1460").html(languages.H1460);
                $("#H1218").html(languages.H1218);
				$("#stateSlt option:eq(0)").text(languages.H1040);
				$("#stateSlt option:eq(1)").text(languages.H1049);
				$("#stateSlt option:eq(2)").text(languages.H1050);
				$("#stateSlt option:eq(3)").text(languages.H1101);
				$("#selectbutton").val(languages.H1447);
				
				$("#zh").html(languages.H1218);
                $("#xm").html(languages.H1449);
                $("#xy").html(languages.H1451);
				$("#syxy").html(languages.H1476);
				$("#ye").html(languages.H1477);
                $("#zt").html(languages.H1070);
				$("#zhdl").html(languages.H1457);
				
				$("#H1028").html(languages.H1028);
				$("#H1029").html(languages.H1029);
				$("#H10281").html(languages.H1028);
				$("#H1030").html(languages.H1030);
				$("#H1031").html(languages.H1031);
				$("#H1032").html(languages.H1032);
				$("#H1033").html(languages.H1033);
				$("#H1034").html(languages.H1034);


            });
            lang = setLang;
        }
        //--------多语言处理结束---------

        /*----------------获得字母-----------------------*/
        function setZM() {
            zm = "";
            for (var c = 97; c < 123; c++) {
                zm += "<option value=\"" + String.fromCharCode(c) + "\">" + String.fromCharCode(c) + "</option>";
            }
        }
        /*----------------获得字母结束-------------------*/
        /*----------------设置分公司提成-----------------*/
        function setConfig() {
            jQuery.AjaxCommon("/ServicesFile/UserService.asmx/GetConfigAll", "", true, false, function (json) {
                if (json.d != "none") {
                    var count = 0;
                    var result = jQuery.parseJSON(json.d);
                    jQuery.each(result, function (i) {
                        if (result[i].Otype == "公司占成") {
                            comm = (100 - result[i].Oval * 100);
                            zgscomm = (100 - result[i].Oval * 100);
                            count++;
                        }
                        else if (result[i].Otype == "佣金A") {
                            perA = (result[i].Oval * 100);
                            zgsperA = (result[i].Oval * 100);
                            count++;
                        }
                        else if (result[i].Otype == "佣金B") {
                            perB = (result[i].Oval * 100);
                            zgsperB = (result[i].Oval * 100);
                            count++;
                        }
                        else if (result[i].Otype == "佣金C") {
                            perC = (result[i].Oval * 100);
                            zgsperC = (result[i].Oval * 100);
                            count++;
                        }
                        if (count == 4) {
                            return;
                        }
                    });
                }
            });
        }
        /*----------------设置分公司提成结束--------------*/
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
        /*----------------获得该账号下的子集账号----------*/
        function getCount(name, id, c, pa, pb, pc, id1) {
            pd = 1;
            comm = c;
            perA = pa;
            perB = pb;
            perC = pc;
            roleId = parseInt(id);
            upID = id1;
            upUserName = name;

            switch (roleId) {
                case 3:
                    /*-------分公司账号占成，佣金--------*/
                    fname = upUserName; //分公司账号
                    fcomm = comm; //占成
                    fperA = perA; //佣金A
                    fperB = perB; //佣金B
                    fperC = perC; //佣金C
                    /*-------分公司占成，佣金--------*/
                    break;
                case 4:
                    /*-------股东占成，佣金--------*/
                    gname = upUserName; //股东账号
                    gcomm = comm; //占成
                    gperA = perA; //佣金A
                    gperB = perB; //佣金B
                    gperC = perC; //佣金C
                    /*-------股东占成，佣金--------*/
                    break;
                case 5:
                    /*-------总代占成，佣金--------*/
                    zname = upUserName; //总代账号
                    zcomm = comm; //占成
                    zperA = perA; //佣金A
                    zperB = perB; //佣金B
                    zperC = perC; //佣金C
                    /*-------总代占成，佣金--------*/
                    break;
                case 6:
                    /*-------代理占成，佣金--------*/
                    dname = upUserName; //代理账号
                    dcomm = comm; //占成
                    dperA = perA; //佣金A
                    dperB = perB; //佣金B
                    dperC = perC; //佣金C
                    /*-------代理占成，佣金--------*/
                    break;
            }
            getpage();
        }
        /*--------------获得该账号下的子集账号结束--------*/
        /*----------------获得丢标记中账号下的子集账号----------*/
        function getCount1(name, id, Index, c, pa, pb, pc, id1) {
            pd = 1;
            if (Index == 0) {
                setConfig();
            }
            else {
                comm = c;
                perA = pa;
                perB = pb;
                perC = pc;
            }
            aIndex = Index;
            jQuery("#pathP>a:gt(" + Index + ")").remove();
            roleId = parseInt(id);
            upID = id1;
            upUserName = name;
            getpage();
        }
        /*--------------获得丢标记中账号下的子集账号结束--------*/
        /*--------------查询方法------------------------------*/
        var tr1;
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
                    tr1 = jQuery("#tr1").clone();
                    var result = jQuery.parseJSON(json.d);
                    if (pd) {
                        jQuery("#pathP").html(jQuery("#pathP").html() + (roleId != 2 ? "<a onmouseover=\"this.style.cursor='hand'\" onclick=\"getCount1('" + upUserName + "','" + roleId + "','" + (aIndex++) + "'," + comm + "," + perA + "," + perB + "," + perC + "," + upID + ")" + "\"> >" + upUserName + "</a>" : ""));
                    }
                    pd = 0;
                    var txtStatus = "";
                    jQuery.each(result, function (i) {

                        var tr = jQuery("#tr1").clone();
                        tr.find("#UID").html((roleId != 6 ? "<a onmouseover=\"this.style.cursor='hand'\" " + ("onclick=\"getCount('" + result[i].UserName + "','" + (parseInt(result[i].RoleId) + 1) + "'," + (result[i].Percent * 100) + "," + (result[i].CommissionA * 100) + "," + (result[i].CommissionB * 100) + "," + (result[i].CommissionC * 100) + "," + result[i].ID + ")") + "\">" + result[i].UserName + "</a>" : "" + result[i].UserName));
                        tr.find("#UName").html("" + result[i].Name);
                        tr.find("#UTel").html(result[i].Credit);
                        tr.find("#UMobile").html(result[i].UserCredit);
                        switch (result[i].Status) {
                            case "0":
                                txtStatus = languages.H1050;
                                break;
                            case "1":
                                txtStatus = languages.H1049;
                                break;
                            case "2":
                                txtStatus = languages.H1101;
                                break;

                        }
                        tr.find("#Status").html(txtStatus);
                        tr.find("#Time").html(result[i].LastLoginTime);
                        tr.find("#IP").html(result[i].LastLoginIP);
                        tr.find("#xjye").html(result[i].Balance);
                        tr.show().appendTo("#showInfo");
                    });
                }


            });
            jQuery("#add_list").hide();
            jQuery("#commB").show();
            jQuery("#commC").show();
            jQuery("#addBtn").val("新增" + type[roleId - 2]);
            getC();
            /*-------------修改内嵌-------------*/
            var Ahtml = "";
            jQuery("#showInfo>tr").find("#upda").find(":button").click(function () {
                Ahtml = "<div style=\"margin-left:40%\"><table><tr><td>aaaa</td><td>aaaa</td></tr><tr><td>aaaa</td><td>aaaa</td></tr><tr><td>aaaa</td>"
                Ahtml += "<td>aaaa</td></tr><tr><td>aaaa</td><td>aaaa</td></tr>";
                Ahtml += "<tr><td align=\"center\" colspan=\"2\">";
                Ahtml += "<input type=\"button\" id=\"AddButton\" onclick=\"savebutton()\" class=\"btn_02\" onmouseover=\"this.className='btn_02_h'\" onmouseout=\"this.className='btn_02'\"  value=\"增加\" />";
                Ahtml += "<input type=\"button\" id=\"AddCancel\" onclick=\"escsavebutton()\" class=\"btn_02\" onmouseover=\"this.className='btn_02_h'\" onmouseout=\"this.className='btn_02'\" value=\"取消\" /></td></tr>";
                Ahtml += "</table></div>";
                tr1.find("td:gt(0)").remove();
                tr1.find("td:eq(0)").attr("colspan", "9");
                tr1.find("td:eq(0)").html(Ahtml);
                jQuery(this).parent().parent().after(tr1);
            });
            /*-----------修改内嵌结束-----------*/
        }
        /*--------------查询方法结束--------------------------*/
        /*--------------内嵌中的保存按钮方法------------------*/
        function savebutton() {
            tr1.remove();
        }
        /*-------------内嵌中的保存按钮方法结束---------------*/
        /*--------------内嵌中的取消按钮方法------------------*/
        function escsavebutton() {
            tr1.remove();
        }
        /*-------------内嵌中的取消按钮方法结束---------------*/
        /*--------------设置下拉列表中的值--------------------*/
        function show_list() {
            if (roleId == 2) {
                jQuery("#UIDS").html("<select id=\"selectA\">" + zm + "</select><select id=\"selectB\">" + zm + "</select>");
                setC();
            }
            else if (roleId == 6) {
                jQuery("#UIDS").html(upUserName + "<select id=\"selectA\"><option value=\"0\">0</option><option value=\"1\">1</option><option value=\"2\">2</option>" +
        "<option value=\"3\">3</option><option value=\"4\">4</option><option value=\"5\">5</option><option value=\"6\">6</option>" +
        "<option value=\"7\">7</option><option value=\"8\">8</option><option value=\"9\">9</option></select>" +
        "<select id=\"selectB\"><option value=\"0\">0</option><option value=\"1\">1</option><option value=\"2\">2</option>" +
        "<option value=\"3\">3</option><option value=\"4\">4</option><option value=\"5\">5</option><option value=\"6\">6</option>" +
        "<option value=\"7\">7</option><option value=\"8\">8</option><option value=\"9\">9</option></select>" +
        "<select id=\"selectC\"><option value=\"0\">0</option><option value=\"1\">1</option><option value=\"2\">2</option>" +
        "<option value=\"3\">3</option><option value=\"4\">4</option><option value=\"5\">5</option><option value=\"6\">6</option>" +
        "<option value=\"7\">7</option><option value=\"8\">8</option><option value=\"9\">9</option></select>");
                setCHY();
            }
            else {
                jQuery("#UIDS").html(upUserName + "<select id=\"selectA\">" + zm + "</select>");
                setC();
            }
            jQuery("#add_list").show();
        }
        /*--------------设置下拉列表中的值结束----------------*/

        /*--------------设置会员的占成，佣金下拉列表的值--------------------*/
        function setCHY() {
            jQuery("#preTD").html(zc);
            jQuery("#commA").html("<td align=\"right\"><select onchange=\"setCHY1()\"><option value=\"A\">佣金A</option><option value=\"B\">佣金B</option>" +
            "<option value=\"C\">佣金C</option></select></td><td align=\"left\">" + yja + "</td>" +
    "<td align=\"right\">&nbsp;</td><td>&nbsp;</td>");
            jQuery("#commB").hide();
            jQuery("#commC").hide();
        }
        /*--------------设置会员的占成，佣金下拉列表的值结束--------------------*/
        /*--------------设置会员的佣金下拉列表的值--------------------*/
        function setCHY1() {
            if (jQuery(this).val() == "A") {
                jQuery("#commA").find("td:eq(1)").html(yja);
            }
            else if (jQuery(this).val() == "B") {
                jQuery("#commA").find("td:eq(1)").html(yjb);
            }
            else if (jQuery(this).val() == "C") {
                jQuery("#commA").find("td:eq(1)").html(yjc);
            }
        }
        /*--------------设置会员的佣金下拉列表的值结束--------------------*/
        /*--------------设置非会员的占成，佣金下拉列表的值-------------------*/
        function setC() {
            jQuery("#preTD").html(zc);
            jQuery("#commA").html("<td align=\"right\">佣金A：</td><td align=\"left\">" + yja + "</td>" +
    "<td align=\"right\">&nbsp;</td><td>&nbsp;</td>");
            jQuery("#commB").html("<td align=\"right\">佣金B：</td><td align=\"left\">" + yjb + "</td>" +
    "<td align=\"right\">&nbsp;</td><td>&nbsp;</td>");
            jQuery("#commC").html("<td align=\"right\">佣金C：</td><td align=\"left\">" + yjc + "</td>" +
    "<td align=\"right\">&nbsp;</td><td>&nbsp;</td>");
        }
        /*--------------设置非会员的占成，佣金下拉列表的值结束--------------------*/
        /*--------------获取占成，佣金下拉列表的值--------------------*/
        function getC() {
            zc = "<select>";
            for (var i = 0; i <= comm; i += 5) {
                zc += "<option value=\"" + (i == 100 ? "1" : (i < 10 ? "0.0" + i : "0." + i)) + "\">" + (i == 100 ? "1" : (i < 10 ? "0.0" + i : "0." + i)) + "</option>";
            }
            zc += "</select>";
            yja = "<select>";
            for (var i = 0; i <= perA; i += 5) {
                yja += "<option value=\"" + (i == 100 ? "1" : (i < 10 ? "0.0" + i : "0." + i)) + "\">" + (i == 100 ? "1" : (i < 10 ? "0.0" + i : "0." + i)) + "</option>";
            }
            yja += "</select>";
            yjb = "<select>";
            for (var i = 0; i <= perB; i += 5) {
                yjb += "<option value=\"" + (i == 100 ? "1" : (i < 10 ? "0.0" + i : "0." + i)) + "\">" + (i == 100 ? "1" : (i < 10 ? "0.0" + i : "0." + i)) + "</option>";
            }
            yjb += "</select>";
            yjc = "<select>";
            for (var i = 0; i <= perC; i += 5) {
                yjc += "<option value=\"" + (i == 100 ? "1" : (i < 10 ? "0.0" + i : "0." + i)) + "\">" + (i == 100 ? "1" : (i < 10 ? "0.0" + i : "0." + i)) + "</option>";
            }
            yjc += "</select>";
        }
        /*--------------获取占成，佣金下拉列表的值结束--------------------*/

    </script>
</head>
<body>
    <table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="pathP"><font class="st"> <span id="yyye">信用与户口余额</span>：</font><a onmouseover="this.style.cursor='hand'" onclick="getCount1('','2','0')"><span id="H1460"> 首页</span></a></p></th>
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
<div class="fl">
    
</div>
<div class="fr">
&nbsp;</div>

&nbsp;&nbsp;<span id="H1218">帐号</span>：<input type="text" name="UserName" id="UserName" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" />
<select id="stateSlt">
    <option value="">全部</option>
    <option value="1">启用</option>
    <option value="0">禁用</option>
    <option value="2">暂停</option>
</select>
<input id="selectbutton" type="button" class="btn_01" onmouseover="this.className='btn_01_h'" onmouseout="this.className='btn_01'" value="查 找" />
</div>
<% } %>



<div class="cl"></div>

    <table width="100%" id="tb" cellpadding="0" class="tab2" >
        <thead>
            <tr>
                <th id="zh">帐号</th>
                <th id="xm">姓名</th>
                <th id="xy">信用</th>
                <th id="syxy">使用信用</th>
                <th id="ye">现金余额</th>
                <th id="zt">状态</th>
                <th id="zhdl">最后登录</th>

                <th>IP</th>
                
            </tr>
        </thead>
        <tbody id="showInfo">
            
            
            </tbody>
          <tfoot>
          
            <tr>
          <td colspan="9" >
              <div id="pageDiv" class="grayr"><span id="H1028">总共</span><label id="infoCount"></label><span id="H1029">条记录</span>,<span id="H10281">共</span><label id="pageCount"></label><span id="H1030">页</span><a style="cursor:hand"> <span id="H1031">首页</span> </a><a style="cursor:hand"> <span id="H1032">上一页</span> </a><span id="pageSpan"></span><a style="cursor:hand"> <span id="H1033">下一页</span> </a><a style="cursor:hand"> <span id="H1034">尾页</span> </a></div>
          </td>
          </tr>
          <tr id="tr1">
            <td id="UID"></td>
            <td id="UName"></td>
            <td id="UTel"></td>
            <td id="UMobile"></td>
            <td id="xjye"></td>
            <td id="Status"></td>
            <td id="Time"></td>
            <td id="IP"></td>
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
