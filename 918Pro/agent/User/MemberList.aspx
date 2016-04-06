<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberList.aspx.cs" Inherits="agent.User.MemberList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
        var upCurrency = "";    //上级币种
        var upResetCredit = "0";
        var upUserName = "";
        var aIndex = 0;
        var type;
        var syComm; //剩余占成
        /*-------上一级占成，佣金--------*/
        var comm = 0;//占成
        var perA = 0;//佣金A
        var perB = 0;//佣金B
        var perC = 0; //佣金C
        var credit = 0; //信用
        var userCredit = 0; //已使用信用
        var itemMin = 0;    //上级单注最低
        var itemMax = 0;    //上级单注最高
        var itemsMax = 0;   //上级单场最高
        /*-------上一级占成，佣金--------*/
        /*-------公司占成，佣金--------*/
        var zgscomm = 0; //占成
        var zgsperA = 0; //佣金A
        var zgsperB = 0; //佣金B
        var zgsperC = 0; //佣金C
        /*-------公司占成，佣金--------*/
        /*-------分公司账号占成，佣金--------*/
        var fname = "";//分公司账号
        var fcomm = 0; //占成
        var fperA = 0; //佣金A
        var fperB = 0; //佣金B
        var fperC = 0; //佣金C
        /*-------分公司占成，佣金--------*/
        /*-------股东占成，佣金--------*/
        var gname = "";//股东账号
        var gcomm = 0; //占成
        var gperA = 0; //佣金A
        var gperB = 0; //佣金B
        var gperC = 0; //佣金C
        /*-------股东占成，佣金--------*/
        /*-------总代占成，佣金--------*/
        var zname = "";//总代账号
        var zcomm = 0; //占成
        var zperA = 0; //佣金A
        var zperB = 0; //佣金B
        var zperC = 0; //佣金C
        /*-------总代占成，佣金--------*/
        /*-------代理占成，佣金--------*/
        var dname = "";//代理账号
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

            SetGlobal("");
        });

                //---------多语言处理-----------
        var languages = "";
        var lang;
        function SetGlobal(setLang) {

            setLang = $.SetOrGetLanguage(setLang, function () {
            //debugger
                languages = language;
                
            jQuery("#tr1").hide();
            type = new Array();
            type[0] = "分公司";
            type[1] = "股东";
            type[2] = "总代";
            type[3] = "代理";
            type[4] = "会员";
            //setConfig();
            setZM();
            //getpage();

            getCount("<% =Currency %>","<% =Credit %>","<% =UserCredit %>","<% =ResetCredit %>","<% =UserName %>","<% =RoleId %>",<% =Percent %>,<% =CommissionA %>,<% =CommissionB %>,<% =CommissionC %>,<% =ID %>,<% =ItemMin %>,<% =ItemMax %>,<% =ItemsMax %>);

            jQuery("#selectbutton").click(function () {
                pd = 0;
                getpage();
            });

                $("#hyqd").html(languages.H1445);
				$("#sy").html(languages.H1460);
				//$("#addBtn").val(languages.H1446);
				$("#H1218").html(languages.H1218);
				$("#stateSlt option:eq(0)").text(languages.H1040);
				$("#stateSlt option:eq(1)").text(languages.H1049);
				$("#stateSlt option:eq(2)").text(languages.H1050);
				$("#stateSlt option:eq(3)").text(languages.H1101);
				$("#selectbutton").val(languages.H1447);
				$("#H1448").html(languages.H1448);
				$("#H1461").html(languages.H1461);
				$("#H1061").html(languages.H1061);
				$("#H1449").html(languages.H1449);
				$("#H1450").html(languages.H1450);
				$("#H1431").html(languages.H1431);
				//$("#H1462").html(languages.H1462);
				$("#H1451").html(languages.H1451);
				$("#H1436").html(languages.H1436);
				$("#H1454").html(languages.H1454);
				$("#H1455").html(languages.H1455);
				$("#H1452").html(languages.H1452);
				$("#H1456").html(languages.H1456);
				$("#H1395").html(languages.H1395);
				$("#yj1").html(languages.yj1);
				$("#yj2").html(languages.yj2);
				$("#yj3").html(languages.yj3);
				$("#AddButton").val(languages.H1459);
				$("#AddCancel").val(languages.H1011);
				$("#zh").html(languages.H1218);
				$("#xm").html(languages.H1449);
				$("#dh").html(languages.H1450);
				$("#xddh").html(languages.H1431);
				$("#zt").html(languages.H1070);
				$("#zhdl").html(languages.H1457);
				$("#mm").html(languages.H1458);
				$("#xg").html(languages.H1009);
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
        function setConfig(){
            jQuery.AjaxCommon("/ServicesFile/UserService.asmx/GetConfigAll", "", true, false, function (json) {
                if (json.d != "none") {
                    var count = 0;
                    var result = jQuery.parseJSON(json.d);
                    jQuery.each(result, function (i) {
                        if (result[i].Otype == "公司占成") {
                            comm = (100 - result[i].Oval * 100);
                            syComm = comm;
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
            var data = "moneyType:'1',upUserName:'" + upUserName + "',userName:'" + jQuery("#UserName").val() + "',status:'" + jQuery("#stateSlt").val() + "',roleId:" + roleId;
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
        function getCount(upcy, upCredit, upUserCredit, resetCredit, name, id, c, pa, pb, pc, id1, getItemMin, getItemMax, getItemsMax) {
        //debugger
            pd = 1;
            comm = c;
            syComm = syComm - comm;
            upResetCredit = resetCredit;
            upCurrency = upcy;
            perA = pa;
            perB = pb;
            perC = pc;
            roleId = parseInt(id);
            upID = id1;
            upUserName = name;
            credit = upCredit;
            userCredit = upUserCredit;
            itemMin = getItemMin;
            itemMax = getItemMax;
            itemsMax = getItemsMax;
            
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
        function getCount1(ct, ut, name, id, Index, c, pa, pb, pc,id1, upItemMin, upItemMax, upItemsMax, syComms) {
            pd = 1;
            if (Index == 0) {
                setConfig();
                aIndex = Index;
                jQuery("#pathP>a:gt(" + Index + ")").remove();
            }
            else {
                comm = c;
                syComm = syComms;
                //syComm = syComm - comm;
                perA = pa;
                perB = pb;
                perC = pc;
                aIndex = Index - 1;
                jQuery("#pathP>a:gt(" + Index + ")").remove();
                jQuery("#pathP>a:eq(" + Index + ")").remove();
            }
            
            roleId = parseInt(id);
            upID = id1;
            upUserName = name;
            credit = ct;
            userCredit = ut;
            itemMin = upItemMin;
            itemMax = upItemMax;
            itemsMax = upItemsMax;

            getpage();
        }
        /*--------------获得丢标记中账号下的子集账号结束--------*/
        /*--------------查询方法------------------------------*/
        var tr1;
        function setDate(data) {
            <% if(searchAc) { %>
            var data = "moneyType:'1',upUserName:'" + upUserName + "',userName:'" + jQuery("#UserName").val() + "',status:'" + jQuery("#stateSlt").val() + "'," + data + ",roleId:" + roleId;
            <% } else { %>
            var data = "moneyType:'1',upUserName:'" + upUserName + "',userName:'',status:''," + data + ",roleId:" + roleId;
            <% } %>
            jQuery.AjaxCommon("/ServicesFile/UserService.asmx/GetAgents", data, true, false, function (json) {
                if (json.d != "none") {
                    jQuery("#showInfo>tr").remove();
                    tr1 = jQuery("#tr1").clone();
                    var result = jQuery.parseJSON(json.d);
                    if (pd) {
                        jQuery("#pathP").html(jQuery("#pathP").html() + (roleId != 2 ? "<a onmouseover=\"this.style.cursor='hand'\" onclick=\"getCount1('" + credit + "','" + userCredit + "','" + upUserName + "','" + roleId + "','" + (++aIndex) + "'," + comm + "," + perA + "," + perB + "," + perC + "," + upID + "," + itemMin + "," + itemMax + "," + itemsMax + "," + syComm + ")" + "\"> > " + upUserName + "</a>" : ""));
                    }
                    pd = 0;
                    var txtStatus = "";
                    jQuery.each(result, function (i) {
                        var tr = jQuery("#tr1").clone();
                        tr.find("#UID").html((roleId != 6 ? "<a onmouseover=\"this.style.cursor='hand'\" " + ("onclick=\"getCount('" + result[i].Currency + "','" + result[i].Credit + "','" + result[i].UserCredit + "','" + result[i].ResetCredit + "','" + result[i].UserName + "','" + (parseInt(result[i].RoleId) + 1) + "'," + (result[i].Percent * 100) + "," + (result[i].CommissionA * 100) + "," + (result[i].CommissionB * 100) + "," + (result[i].CommissionC * 100) + "," + result[i].ID + "," + result[i].ItemMin + "," + result[i].ItemMax + "," + result[i].ItemsMax + ")") + "\">" + result[i].UserName + "</a>" : "" + result[i].UserName));
                        //tr.find("#UName").html("" + result[i].Name);
                        //tr.find("#UTel").html(result[i].Tel);
                        //tr.find("#UMobile").html(result[i].Mobile);
                        tr.find("#tdbz").html(result[i].Currency);
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
                        tr.show().appendTo("#showInfo");
                    });
                }

                if (roleId == 2) {
                    jQuery("#rCredit").html("<label><input type=\"checkbox\" id=\"resetCredit\" />" + languages.H1427 + "</label>");
                    jQuery("#addbz").html(getSelectBz());
                    upCurrency = "";
                }
                else {
                    if (upResetCredit == "1") {
                        jQuery("#rCredit").html("<label><input type=\"checkbox\" id=\"resetCredit\" checked />" + languages.H1427 + "</label>");
                    }
                    else {
                        jQuery("#rCredit").html("");
                    }

                    jQuery("#addbz").html(upCurrency);
                }

                /*------------修改---------------*/
                var $currentHide = "";
                var $CurrentObj = "";
                var seriaStr = "";
                var strInput = "";
                var preStr = "";

                jQuery(".edit").unbind("click");
                jQuery(".edit").click(function () {
                    if ($currentHide != "") {
                        if (jQuery("#txtCol4").val() == undefined) {
                            //密码是否有修改
                            //得到原先input的值
                            if (jQuery("#txtCol1").val() != "" || jQuery("#txtCol2").val() != "") {
                                if (confirm(languages.h1428)) {
                                    clearValue();
                                }
                                else {
                                    strInput = "";

                                    return;

                                }

                            }
                            else {
                                clearValue();
                            }

                        }
                        else {
                            //得到原先input的值
                            for (var i = 1; i <= 4; i++) {
                                strInput += jQuery("#txtCol" + i).val();
                            }

                            if (strInput != preStr) {
                                if (confirm(languages.h1428)) {
                                    clearValue();
                                }
                                else {
                                    strInput = "";

                                    return;

                                }

                            }
                            else {
                                clearValue();
                            }
                        }
                    }
                    $CurrentObj = jQuery(this);
                    var strHtml = "<tr > <td colspan='9' ><div class='new_tr' ><form><ul><li><span>" + languages.H1429 + "：</span><input type='text' id='txtCol1' onblur=\"IsNullByInfo(this,'mdfErr1','" + languages.H1306 + "');\" class='text_01 h20 w_120' onmouseover=\"this.className='text_01_h h20 w_120'\" onmouseout=\"this.className='text_01 h20 w_120'\"/>&nbsp;<label id=\"mdfErr1\" style=\"color:Red\"></label></li><li><span>" + languages.H1430 + "：</span><input type='text' id='txtCol2' onblur=\"IsNullByInfo(this,'mdfErr2','" + languages.H1306 + "');\" class=\"text_01 h20 w_120\" onmouseover=\"this.className='text_01_h h20 w_120'\" onmouseout=\"this.className='text_01 h20 w_120'\"/>&nbsp;<label id=\"mdfErr2\" style=\"color:Red\"></label></li><li><span>" + languages.H1431 + "：</span><input type='text' id='txtCol3' onblur=\"IsNullByInfo(this,'mdfErr3','" + languages.H1306 + "');\" class=\"text_01 h20 w_120\" onmouseover=\"this.className='text_01_h h20 w_120'\" onmouseout=\"this.className='text_01 h20 w_120'\"/>&nbsp;<label id=\"mdfErr3\" style=\"color:Red\"></label></li><li><span>" + languages.H1432 + "：</span><select id='txtCol4'><option value='1'>" + languages.H1049 + "</option><option value='0'>" + languages.H1050 + "</option><option value='2'>" + languages.H1101 + "<option></select><label></label></li></ul></form><br><input type='button' class='btn_02_h'   value='" + languages.H1025 + "' id='btnSave' />&nbsp;&nbsp;<input type='button' value='" + languages.H1011 + "' id='btnCancel' class='btn_02'  /><div class='new_trfoot'></div></div></td></tr>";
                    var str = "";
                    $CurrentObj.parent().parent().after(jQuery(strHtml));
                    for (var i = 1; i < 5; i++) {
                        if (i == 4) {
                            str = $CurrentObj.parent().parent().find("td:eq(" + i + ")").text() == languages.H1049 ? "1" : ($CurrentObj.parent().parent().find("td:eq(" + i + ")").text() == languages.H1050 ? "0" : "2");
                        }
                        else {
                            str = $CurrentObj.parent().parent().find("td:eq(" + i + ")").text();
                        }
                        preStr += str;
                        jQuery("#txtCol" + (i)).val(str);
                    }
                    //$CurrentObj.attr("disabled", "disabled");
                    $currentHide = $CurrentObj.parents("tr").next();
                    jQuery("#btnSave").unbind("click");
                    jQuery("#btnSave").bind("click", function () {
                        //验证表单
                        jQuery.each(jQuery(this).parents().find(":text"), function (i, n) {
                            jQuery(n).blur();
                        });
                        var checkform = true;
                        jQuery.each(jQuery(this).parents().find("label[id*=mdfErr]"), function (i, n) {
                            if (jQuery(n).text() != "") {
                                checkform = false;
                            }
                        });
                        if (checkform == false) {
                            return false;
                        }

                        //更新数据
                        var url = "/ServicesFile/UserService.asmx/UpdateAgent";
                        var data = "name:'" + jQuery("#txtCol1").val() + "',tel:'" + jQuery("#txtCol2").val() + "',mobile:'" + jQuery("#txtCol3").val() + "',status:" + jQuery("#txtCol4").val() + ",userName:'" + $CurrentObj.parent().parent().find("td:eq(0)").text() + "',roleId:" + roleId;
                        jQuery.AjaxCommon(url, data, false, false, function (json) {
                            if (json.d) {
                                $CurrentObj.parent().parent().find("td:eq(1)").text(jQuery("#txtCol1").val());
                                $CurrentObj.parent().parent().find("td:eq(2)").text(jQuery("#txtCol2").val());
                                $CurrentObj.parent().parent().find("td:eq(3)").text(jQuery("#txtCol3").val());
                                $CurrentObj.parent().parent().find("td:eq(4)").text(jQuery("#txtCol4").val() == "1" ? languages.H1049 : (jQuery("#txtCol4").val() == "0" ? languages.H1050 : languages.H1101));
                                jQuery.MsgTip({ objId: "#divTip", msg: languages.H1012 });
                            }
                            else {
                                jQuery.MsgTip({ objId: "#divTip", msg: languages.H1185 });
                            }
                        });
                        clearValue();
                    });
                    jQuery("#btnCancel").unbind("click");
                    jQuery("#btnCancel").bind("click", function () {
                        clearValue();
                    });



                    function clearValue() {
                        $currentHide.remove();
                        //$CurrentObj.attr("disabled", "");
                        $currentHide = "";
                        strInput = "";
                        preStr = "";
                    }

                    //seriaStr = jQuery("form").serialize();
                    //alert(seriaStr);
                });
                /*------------修改结束---------------*/

                /*-----------修改密码-------------*/
                jQuery(".pass").unbind("click");
                jQuery(".pass").click(function () {

                    if ($currentHide != "") {
                        if (jQuery("#txtCol4").val() == undefined) {
                            //得到原先input的值
                            if (jQuery("#txtCol1").val() != "" || jQuery("#txtCol2").val() != "") {
                                if (confirm(languages.h1428)) {
                                    clearValue();
                                }
                                else {
                                    strInput = "";

                                    return;

                                }

                            }
                            else {
                                clearValue();
                            }
                        }
                        else {
                            //会员资料是否有修改
                            //得到原先input的值
                            for (var i = 1; i <= 4; i++) {
                                strInput += jQuery("#txtCol" + i).val();
                            }

                            if (strInput != preStr) {
                                if (confirm(languages.h1428)) {
                                    clearValue();
                                }
                                else {
                                    strInput = "";

                                    return;

                                }

                            }
                            else {
                                clearValue();
                            }
                        }
                    }
                    $CurrentObj = jQuery(this);
                    var strHtml = "<tr > <td colspan='9' ><div class='new_tr' ><form><ul><li><span>" + languages.H1458 + "：</span><input type='password' id='txtCol1' class='text_01 h20 w_120' onmouseover=\"this.className='text_01_h h20 w_120'\" onmouseout=\"this.className='text_01 h20 w_120'\" onblur=\"IsNullByInfo(this,'passErr1','" + languages.H1306 + "');\" />&nbsp;<label id=\"passErr1\" style=\"color:Red\"></label></li><li><span>" + languages.H1314 + "：</span><input type='password' onblur=\"PassWordCheck(this,'txtCol1','passErr2','','');\" id='txtCol2' class=\"text_01 h20 w_120\" onmouseover=\"this.className='text_01_h h20 w_120'\" onmouseout=\"this.className='text_01 h20 w_120'\"/>&nbsp;<label id=\"passErr2\" style=\"color:Red\"></label></li></ul></form><br><input type='button' class='btn_02_h'   value='" + languages.H1025 + "' id='btnSave' />&nbsp;&nbsp;<input type='button' value='" + languages.H1011 + "' id='btnCancel' class='btn_02'  /><div class='new_trfoot'></div></div></td></tr>";
                    var str = "";
                    $CurrentObj.parent().parent().after(jQuery(strHtml));
                    //                    for (var i = 1; i < 5; i++) {
                    //                        if (i == 4) {
                    //                            str = $CurrentObj.parent().parent().find("td:eq(" + i + ")").text() == "启用" ? "1" : ($CurrentObj.parent().parent().find("td:eq(" + i + ")").text() == "禁用" ? "0" : "2");
                    //                        }
                    //                        else {
                    //                            str = $CurrentObj.parent().parent().find("td:eq(" + i + ")").text();
                    //                        }
                    //                        preStr += str;
                    //                        jQuery("#txtCol" + (i)).val(str);
                    //                    }
                    //                    //$CurrentObj.attr("disabled", "disabled");
                    $currentHide = $CurrentObj.parents("tr").next();
                    jQuery("#btnSave").unbind("click");
                    jQuery("#btnSave").bind("click", function () {
                        //表单验证
                        jQuery.each(jQuery(this).parent().parent().parent().find(":password"), function (i, n) {

                            jQuery(n).blur();
                        });
                        var checkform = true;
                        jQuery.each(jQuery(this).parent().parent().parent().find("label[id*=passErr]"), function (i, n) {

                            var aa = jQuery(n).text();
                            if (aa != "") {
                                checkform = false;
                            }
                        });

                        if (checkform == false) {
                            return false;
                        }

                        //更新数据
                        var url = "/ServicesFile/UserService.asmx/UpdatePass";
                        var data = "pass:'" + jQuery("#txtCol1").val() + "',userName:'" + $CurrentObj.parent().parent().find("td:eq(0)").text() + "',roleId:" + roleId;
                        jQuery.AjaxCommon(url, data, false, false, function (json) {
                            if (json.d) {
                                jQuery.MsgTip({ objId: "#divTip", msg: languages.H1433 });
                            }
                            else {
                                jQuery.MsgTip({ objId: "#divTip", msg: languages.H1458 });
                            }
                        });
                        clearValue();
                    });
                    jQuery("#btnCancel").unbind("click");
                    jQuery("#btnCancel").bind("click", function () {
                        clearValue();
                    });



                    function clearValue() {
                        $currentHide.remove();
                        //$CurrentObj.attr("disabled", "");
                        $currentHide = "";
                        strInput = "";
                        preStr = "";
                    }

                    //seriaStr = jQuery("form").serialize();
                    //alert(seriaStr);
                });
                /*------------修改密码结束---------------*/

            });
            jQuery("#add_list").hide();
            //jQuery("#commB").show();
            //jQuery("#commC").show();
            //debugger
            var typelan=new Array();
            typelan[0]=languages.H1227;
            typelan[1]=languages.H1228;
            typelan[2]=languages.H1229;
            typelan[3]=languages.H1082;
            typelan[4]=languages.H1328
            var aaa = languages.H1015 + " " + typelan[roleId - 2];
            jQuery("#addBtn").val(aaa);
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
            //清空数据
            jQuery.each(jQuery("#addtb span[id*=err]"), function (i, n) {
                jQuery(n).html("");
            });
            jQuery.each(jQuery("#addtb :text"), function (i, n) {
                jQuery(n).val("");
            });
            jQuery.each(jQuery("#addtb :password"), function (i, n) {
                jQuery(n).val("");
            });
            $("#Credit").val("0");
            $("#ItemMin").val("100");
            $("#ItemMax").val("1000");
            $("#ItemsMax").val("5000");

            if (roleId == 2) {
                jQuery("#UIDS").html("<select id=\"selectA\" onChange=\"onchangs();\">" + zm + "</select><select id=\"selectB\" onChange=\"onchangs();\">" + zm + "</select><span style=\"color:Green\" id=\"err0\"></span>");
                setC();
                jQuery("#SetCredit").find("span:gt(0)").remove();
                jQuery("#SetCredit :text:first").unbind("blur");
                jQuery("#SetCredit :text:first").bind("blur", function () {
                    IsElJudge(this, 'err5', 'number', languages.H1306, languages.H1459, 20);
                });
            }
            else if (roleId == 6) {
                jQuery("#UIDS").html(upUserName + "<select id=\"selectA\" onChange=\"onchangs();\"><option value=\"0\">0</option><option value=\"1\">1</option><option value=\"2\">2</option>" +
        "<option value=\"3\">3</option><option value=\"4\">4</option><option value=\"5\">5</option><option value=\"6\">6</option>" +
        "<option value=\"7\">7</option><option value=\"8\">8</option><option value=\"9\">9</option></select>" +
        "<select id=\"selectB\" onChange=\"onchangs();\"><option value=\"0\">0</option><option value=\"1\">1</option><option value=\"2\">2</option>" +
        "<option value=\"3\">3</option><option value=\"4\">4</option><option value=\"5\">5</option><option value=\"6\">6</option>" +
        "<option value=\"7\">7</option><option value=\"8\">8</option><option value=\"9\">9</option></select>"+
        "<select id=\"selectC\" onChange=\"onchangs();\"><option value=\"0\">0</option><option value=\"1\">1</option><option value=\"2\">2</option>" +
        "<option value=\"3\">3</option><option value=\"4\">4</option><option value=\"5\">5</option><option value=\"6\">6</option>" +
        "<option value=\"7\">7</option><option value=\"8\">8</option><option value=\"9\">9</option></select><span style=\"color:Green\" id=\"err0\"></span>");
                setCHY();
                jQuery("#SetCredit").find("span:gt(0)").remove();
                jQuery("#SetCredit").find("br:first").after("<span style=\"color:#666666\">" + languages.H1436 + ":<label id=\"credity\">" + (credit - userCredit) + "</label></span>");
                jQuery("#SetCredit :text:first").unbind("blur");
                jQuery("#SetCredit :text:first").bind("blur",function () {
                    CompareNumber(this, 'credity', 'Min', 'err5', languages.H1437 + $("#credity").text() );
                });
            }
            else {
                jQuery("#UIDS").html(upUserName + "<select id=\"selectA\" onChange=\"onchangs();\">" + zm + "</select><span style=\"color:Green\" id=\"err0\"></span>");
                setC();
                jQuery("#SetCredit").find("span:gt(0)").remove();
                jQuery("#SetCredit").find("br:first").after("<span style=\"color:#666666\">" + languages.H1436 + ":<label id=\"credity\">" + (credit - userCredit) + "</label></span>");
                jQuery("#SetCredit :text:first").unbind("blur");
                jQuery("#SetCredit :text:first").bind("blur", function () {
                    CompareNumber(this, 'credity', 'Min', 'err5', languages.H1437 + $("#credity").text());
                });

            }
            if(roleId !=2) {
                jQuery("#err6").html("不能小于" + itemMin);
                jQuery("#err7").html("不能大于" + itemMax);
                jQuery("#err8").html("不能大于" + itemsMax);
            }

            jQuery("#add_list").show();

        }
        /*--------------设置下拉列表中的值结束----------------*/
        /*--------------新增中的取消按钮方法--------------------*/
        function escbutton() {
            jQuery("#add_list").hide();
        }
        /*--------------新增中的取消按钮方法结束--------------------*/
        /*--------------新增中的确定按钮方法--------------------*/
        function surebutton() {
            //表单验证
            jQuery("#UIDS").find("select:eq(0)").change();
            jQuery.each(jQuery("#addtb :text"), function (i, n) {
                $(n).blur();
            });
            jQuery.each(jQuery("#addtb :password"), function(i,n){
                $(n).blur();
            });

            var check = true;
            jQuery.each(jQuery("#addtb span[id*=err]"), function (i, n) {
                if (i == 0) {
                    var aa = $(n).text();
                    if (aa != languages.H1438) {
                        check = false;
                    }
                }
                else {
                    if ($(n).text() != "") {
                        check = false;
                    }
                }
            });
            
            if(check == false) {
                return;
            }

            var data = "";
            var url = "";
            var curUserName = upUserName;
            var upRoleId = 0;       //上级角色ID
            var upRoleName = "";    //上级角色名称
            var resetCredit = "0";

            jQuery.each(jQuery("#UIDS").find("select"), function (i, n) {
                curUserName += $(n).val();
            });
            if (roleId - 2 > 0) {
                upRoleId = roleId - 1;
                upRoleName = type[upRoleId - 2];
            }

            //取重置会员信用值
            if (jQuery("#resetCredit").attr("checked") == null) {
                resetCredit = "0";
            }
            else {
                if (jQuery("#resetCredit").attr("checked")) {
                    resetCredit = "1";
                }
                else {
                    resetCredit = "0";
                }
            }

            var cyy = "";
            if(roleId == 2){
                cyy = jQuery("#addbz select").val();
            }
            else{
                cyy = upCurrency;
            }

            if (type[roleId - 2] == "会员") {
            
                var CompanyCommission = 0;      //公司佣金
                var SubCompanyCommission = 0;   //分公司佣金
                var PartnerCommission = 0;      //股东佣金
                var GeneralAgentCommission = 0; //总代佣金
                var AgentCommission = 0;        //代理佣金
                var userCommission = new Array();
                jQuery.each(jQuery("#commA").find("select"), function (i, n) {
                    //alert($(n).val());
                    userCommission[i] = $(n).val();
                });
                switch (userCommission[0]) {
                    case "A":
                        CompanyCommission = zgsperA;
                        SubCompanyCommission = fperA;
                        PartnerCommission = gperA;
                        GeneralAgentCommission = zperA;
                        AgentCommission = dperA;
                        break;
                    case "B":
                        CompanyCommission = zgsperB;
                        SubCompanyCommission = fperB;
                        PartnerCommission = gperB;
                        GeneralAgentCommission = zperB;
                        AgentCommission = dperB;
                        break;

                    case "C":
                        CompanyCommission = zgsperC;
                        SubCompanyCommission = fperC;
                        PartnerCommission = gperC;
                        GeneralAgentCommission = zperC;
                        AgentCommission = dperC;
                        break;
                }
                url = "/ServicesFile/UserService.asmx/AddUser";
                data = "moneyType:'1',userName:'" + curUserName + "',pass:'" + jQuery("#Password").val() + "',name:'" + jQuery("#Name").val() + "',mobile:'" + jQuery("#Mobile").val() + "',currency:'" + cyy + "',email:'',tel:'" + jQuery("#Tel").val() + "',status:1,companyPercent:" + (100 - zgscomm) / 100 + ",companyCommission:" + CompanyCommission / 100 + ",subCompany:'" + fname + "',subCompanyPercent:" + fcomm / 100 + ",subCompanyCommission:" + SubCompanyCommission / 100 + ",partner:'" + gname + "',partnerPercent:" + gcomm / 100 + ",partnerCommission:" + PartnerCommission / 100 + ",generalAgent:'" + zname + "',generalAgentPercent:" + zcomm / 100 + ",generalAgentCommission:" + GeneralAgentCommission / 100 + ",agent:'" + dname + "',agentPercent:" + dcomm / 100 + ",agentCommission:" + AgentCommission / 100 + ",percent:0,commission:" + userCommission[1] + ",credit:" + jQuery("#Credit").val() + ",upUserName:'" + upUserName + "',upUserID:" + upID + ",upRoleId:" + upRoleId + ",ItemMin:" + jQuery("#ItemMin").val() + ",itemMax:" + jQuery("#ItemMax").val() + ",itemsMax:" + jQuery("#ItemsMax").val() + ",Group:'" + userCommission[0] + "',resetCredit:'" + resetCredit + "'";

            }
            else {

                url = "/ServicesFile/UserService.asmx/AddAgent";
                data = "currency:'" + cyy + "',moneyType:'1',userName:'" + curUserName + "',pass:'" + jQuery("#Password").val() + "',name:'" + jQuery("#Name").val() + "',mobile:'" + jQuery("#Mobile").val() + "',email:'',tel:'" + jQuery("#Tel").val() + "',status:1,subCompany:'" + fname + "',sCNumber:0,partner:'" + gname + "',pNumber:0,generaAgent:'" + zname + "',gaNumber:0,agents:'" + dname + "',agentsNumber:0,maxUser:1000,roleId:" + roleId + ",roleName:'" + type[roleId - 2] + "',upUserName:'" + upUserName + "',upUserId:" + upID + ",upRoleId:" + upRoleId + ",upRoleName:'" + upRoleName + "',itemMin:" + jQuery("#ItemMin").val() + ",itemMax:" + jQuery("#ItemMax").val() + ",itemsmax:" + jQuery("#ItemsMax").val() + ",percent:" + jQuery("#preTD").find("select:eq(0)").val() + ",credit:" + jQuery("#Credit").val() + ",commissionA:" + jQuery("#commA").find("select:eq(0)").val() + ",commissionB:" + jQuery("#commB").find("select:eq(0)").val() + ",commissionC:" + jQuery("#commC").find("select:eq(0)").val() + ",resetCredit:'" + resetCredit + "'";
            }

            jQuery.AjaxCommon(url, data, false, false, function (json) {
                var result = jQuery.parseJSON(json.d);
                var txtStatus = "";
                var wx = false;
                jQuery.each(result, function (i) {
                //debugger
                    if(result[i].mark == "信用不能大于"){
                        jQuery("#credity").text(result[i].xy);
                        userCredit = credit - result[i].xy;
                        alert(languages.H1439 + ":" + result[i].xy);
                        wx = true;
                        return false;
                    }

//                    jQuery("#add_list").hide();
//                    var tr = jQuery("#tr1").clone();
//                    tr.find("#UID").html((roleId != 6 ? "<a " + ("onclick=\"getCount('" + result[i].UserName + "','" + (parseInt(result[i].RoleId) + 1) + "'," + (result[i].Percent * 100) + "," + (result[i].CommissionA * 100) + "," + (result[i].CommissionB * 100) + "," + (result[i].CommissionC * 100) + "," + result[i].ID + ")") + "\">" + result[i].UserName + "</a>" : "" + result[i].UserName));
//                    tr.find("#UName").html("" + result[i].Name);
//                    tr.find("#UTel").html(result[i].Tel);
//                    tr.find("#UMobile").html(result[i].Mobile);
//                    switch (result[i].Status) {
//                        case "0":
//                            txtStatus = "禁用";
//                            break;
//                        case "1":
//                            txtStatus = "启用";
//                            break;
//                        case "2":
//                            txtStatus = "暂停";
//                            break;

//                    }

//                    tr.find("#Status").html(txtStatus);
//                    tr.find("#Time").html(result[i].LastLoginTime);
//                    tr.find("#IP").html(result[i].LastLoginIP);
//                    //tr.find("#password").html(result[i].Password);
//                    //tr.find("#upda").html("<input type=\"button\" value=\"修改\" class=\"editCss\" onmouseover=\"this.className='editCss_l'\" onmouseout=\"this.className='editCss'\" align=\"middle\"/>");
//                    tr.find("#password").html("<img src='/images/Icon/page_edit.gif' onmouseover=\"this.style.cursor='hand'\" class='pass'>");
//                    tr.find("#upda").html("<img src='/images/Icon/page_edit.gif' onmouseover=\"this.style.cursor='hand'\" class='edit'>");

//                    //tr.show().appendTo("#showInfo");
//                    jQuery("#showInfo").find("tr:eq(0)").before(tr.show());

//                    $.MsgTip({ objId: "#divTip", msg: "增加" + type[roleId - 2] + "成功!" });

                                });

                if(!wx) {
                    //已使用信用
                    userCredit = parseInt(userCredit) + parseInt(jQuery("#Credit").val());
                    getpage();
                }
            });

        }
        /*--------------新增中的确定按钮方法结束--------------------*/
        /*--------------设置会员的占成，佣金下拉列表的值--------------------*/
        function setCHY() {
            jQuery("#preTD").html(zc);
            jQuery("#commA").html("<td align=\"right\"><select onchange=\"setCHY1()\" disabled><option value=\"A\">" + languages.H1395 + "A</option><option value=\"B\">" + languages.H1395 + "B</option>" +
            "<option value=\"C\">" + languages.H1395 + "C</option></select></td><td align=\"left\">"+yja+"</td>" +
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
            jQuery("#commA").html("<td align=\"right\">" + languages.H1395 + "A：</td><td align=\"left\">" + yja + "</td>" +
    "<td align=\"right\">&nbsp;</td><td>&nbsp;</td>");
            jQuery("#commB").html("<td align=\"right\">" + languages.H1395 + "B：</td><td align=\"left\">" + yjb + "</td>" +
    "<td align=\"right\">&nbsp;</td><td>&nbsp;</td>");
            jQuery("#commC").html("<td align=\"right\">" + languages.H1395 + "C：</td><td align=\"left\">" + yjc + "</td>" +
    "<td align=\"right\">&nbsp;</td><td>&nbsp;</td>");
        }
        /*--------------设置非会员的占成，佣金下拉列表的值结束--------------------*/
        /*--------------获取占成，佣金下拉列表的值--------------------*/
        function getC() {
        //debugger
                zc = "";
                if(roleId != 6){
                    $("#addBtn").show();
                    zc = "<select>";
                    for (var i = 0; i <= comm; i += 5) {
                    //for (var i = 0; i <= syComm; i += 5) {
                    //debugger
                        zc += "<option value=\"" + (i == 100 ? "1" : (i < 10 ? "0.0" + i : "0." + i)) + "\">" + (i == 100 ? "1" : (i < 10 ? "0.0" + i : "0." + i)) + "</option>";
                    }
                    zc += "</select>";
                }
                else {
                    $("#addBtn").hide();
                }
            yja = "<select>";
            for (var i = 0; i <= perA; i += 5) {
                yja += "<option value=\"" + (i == 100 ? "1" : (i < 10 ? "0.0" + i : "0." + i)) + "\">" + (i == 100 ? "1" : (i < 10 ? "0.0" + i : "0." + i)) + "</option>";
            }
            yja += "</select>%";
            yjb = "<select>";
            for (var i = 0; i <= perB; i += 5) {
                yjb += "<option value=\"" + (i == 100 ? "1" : (i < 10 ? "0.0" + i : "0." + i)) + "\">" + (i == 100 ? "1" : (i < 10 ? "0.0" + i : "0." + i)) + "</option>";
            }
            yjb += "</select>%";
            yjc = "<select>";
            for (var i = 0; i <= perC; i += 5) {
                yjc += "<option value=\"" + (i == 100 ? "1" : (i < 10 ? "0.0" + i : "0." + i)) + "\">" + (i == 100 ? "1" : (i < 10 ? "0.0" + i : "0." + i)) + "</option>";
            }
            yjc += "</select>%";
        }
        /*--------------获取占成，佣金下拉列表的值结束--------------------*/

        function onchangs() {
        
            var reval = checkuser();
            if (reval == "帐号已存在") {
                jQuery("#UIDS").find("span:eq(0)").attr("style", "color:Red");
                jQuery("#UIDS").find("span:eq(0)").text(reval);
            }
            else {
                jQuery("#UIDS").find("span:eq(0)").attr("style", "color:Green");
                jQuery("#UIDS").find("span:eq(0)").text(reval);
            }
        }

        //检测用户是否存在
        function checkuser() {
        
            var curUserName = upUserName;
            var reval = "";

            jQuery.each(jQuery("#UIDS").find("select"), function (i, n) {
                curUserName += $(n).val();
            });
            var url = "/ServicesFile/UserService.asmx/IsExistUser";
            var data = "userName:'" + curUserName + "',roleID:" + roleId;
            jQuery.AjaxCommon(url, data, false, false, function (json) {
                reval = json.d;
            });
            return reval;
        }

        //检查最小最大投注开始
        function checkItemMin(obj) {
            if(roleId != 2){
                if(CompareByNumber(obj,itemMin,'Max','err6',languages.H1440 + itemMin)) {
                    CompareNumber(obj,'ItemMax','Min','err6',languages.H1441);
                }
            }
            else {
                CompareNumber(obj,'ItemMax','Min','err6',languages.H1441);
            }
        }

        function checkItemMax(obj) {
            if(roleId !=2) {
                if(CompareByNumber(obj,itemMax,'Min','err7',languages.H1437 + itemMax)){ 
                    if(CompareNumber(obj,'ItemMin','Max','err7',languages.H1442)) {  
                        CompareNumber(obj,'ItemsMax','Min','err7',languages.H1443);
                    }
                }   
            }
            else{
                if(CompareNumber(obj,'ItemMin','Max','err7',languages.H1442)) {  
                    CompareNumber(obj,'ItemsMax','Min','err7',languages.H1443);
                }
            }
        }

        function checkItemsMax(obj){
            if(roleId != 2){
                if(CompareByNumber(obj,itemsMax,'Min','err8',languages.H1437 + itemsMax)) {
                    CompareNumber(obj,'ItemMax','Max','err8',languages.H1444);
                }
            }
            else{
                CompareNumber(obj,'ItemMax','Max','err8',languages.H1444);
            }
        }
        //检查最小最大投注结束

        function getSelectBz(){
            var html = "<select>";
            var url = "/ServicesFile/RateService.asmx/GetRateByLan";
            var data = "language:'" + lang + "'";
            jQuery.AjaxCommon(url, data, false, false, function (json) {
                if (json.d != "none") {
                    var result = jQuery.parseJSON(json.d);
                    jQuery.each(result, function (i) {

                        html += "<option value=" + result[i].code + ">" + result[i].name + "</option>";

                    });
                    html += "</select>";
                }
                else {

                }
            });
            return html;
        }
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
    <form id="form1" runat="server">
    <table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p id="pathP"><font class="st" id="hyqd"> 会员清单</font><a onmouseover="this.style.cursor=''" ></a></p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<% if (addAc || searchAc)
   { %>
<div class="top_banner h30">
<% if (addAc)
   { %>
<div class="fl" style="display:none;">
<input type="button" id="addBtn" class="top_add" onmouseover="this.className='top_add_h'" onmouseout="this.className='top_add'"  value="11" onclick="show_list()" />
</div>
<% } %>
<div class="fr">
&nbsp;</div>
<% if (searchAc)
   { %>
&nbsp;&nbsp;<span id="H1218">帐号</span>：<input type="text" name="UserName" id="UserName" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" />
<select id="stateSlt">
    <option value="">全部</option>
    <option value="1">启用</option>
    <option value="0">禁用</option>
    <option value="2">暂停</option>
</select>
<input id="selectbutton" type="button" class="btn_01" onmouseover="this.className='btn_01_h'" onmouseout="this.className='btn_01'" value="查找" />
<% } %>
</div>
<% } %>

<div id="add_list" class="new_tr undis">
<div align="center">
<table width="70%"  border="0" cellpadding="1" cellspacing="1" id="addtb">
  <tr align="center" style="background-color:#CDEAFC">
    <td colspan="4"><strong id="H1448">用户资讯</strong></td>
  </tr>
  <tr>
    <td align="right" id="H1461">帐户：</td>
    <td align="left" id="UIDS">
    <select id="selectA">
        <option value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="4">4</option>
        <option value="5">5</option>
        <option value="6">6</option>
        <option value="7">7</option>
        <option value="8">8</option>
        <option value="9">9</option>
    </select>
    <select id="selectB">
        <option value="0">0</option>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="4">4</option>
        <option value="5">5</option>
        <option value="6">6</option>
        <option value="7">7</option>
        <option value="8">8</option>
        <option value="9">9</option>
    </select>
    
    </td>
    <td align="right">&nbsp;</td>
    <td align="left">&nbsp;</td>
  </tr>
  <tr>
    <td align="right"><span id="H1061">密码</span>：</td>
    <td align="left"><input type="password" name="Password" id="Password1" onblur="IsNullByInfo(this,'err1',languages.H1306);" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" />&nbsp;<span id="err1" style="color:Red"></span></td>
    <td align="right"><span id="H1449">姓名</span>：</td>
    <td align="left"><input type="text" name="Name" id="Name"  class="text_01 h20" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" />&nbsp;<span id="err2" style="color:Red"></span></td>
  </tr>
  <tr>
    <td align="right"><span id="H1450">电话</span>：</td>
    <td align="left"><input type="text" name="Tel" id="Tel" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'"  />&nbsp;<span id="err3" style="color:Red"></span></td>
    <td align="right"><span id="H1431">行动电话</span>：</td>
    <td align="left"><input type="text" name="Mobile" id="Mobile" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'"  />&nbsp;<span id="err4" style="color:Red"></span></td>
  </tr>
  <tr>
    <td align="right"><span id="spbz">币种</span>：</td>
    <td align="left"><span id="addbz"></span></td>
    <td align="right"></td>
    <td align="left"></td>
  </tr>

  <tr align="center" style="background-color:#CDEAFC">
    <td colspan="4"><strong id="H1462">占成</strong></td>
  </tr>
  <tr style="display:none;">
    <td align="right"><span id="H1451">信用</span>：</td>
    <td align="left" id="SetCredit"><input type="text" name="Credit" id="Credit" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" />&nbsp;<span id="err5" style="color:Red"></span><br /><span style="color:#666666"><span id="H1436">上级信用余额</span>:<label id="credity">5000</label></span></td>
    <td align="right"><span id="H1454">最小投注</span>：</td>
    <td align="left"><input type="text" name="ItemMin" id="ItemMin" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" onblur="checkItemMin(this);" />&nbsp;<span id="err6" style="color:Red"></span></td>
  </tr>
  <tr style="display:none;">
    <td align="right"></td>
    <td align="left" id="rCredit"></td>
    <td align="right"><span id="H1455">最大投注</span>：</td>
    <td align="left"><input type="text" name="ItemMax" id="ItemMax" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" onblur="checkItemMax(this);" />&nbsp;<span id="err7" style="color:Red"></span></td>
  </tr>
  <tr>
    <td align="right"><span id="H1452">占成</span>：</td>
    <td align="left" id="preTD">
	<select id="Select1">
	<option>0.05</option>
	<option>0.1</option>
	</select>
    </td>
    <td align="right" style="display:none;"><span id="H1456">单场最高投注限额</span>：</td>
    <td align="left" style="display:none;"><input type="text" name="ItemsMax" id="ItemsMax" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" onblur="checkItemsMax(this);" />&nbsp;<span id="err8" style="color:Red"></span></td>
  </tr>
  <tr align="center" style="background-color:#CDEAFC">
    <td colspan="4"><strong id="H1395">佣金</strong></td>
  </tr>
  <tr id="commA">
    <td align="right"><span id="yj1">佣金</span>A：</td>
    <td align="left"><input type="text" name="CommissionA" id="CommissionA" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" /></td>
    <td align="right">&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr id="commB" style="display:none">
    <td align="right"><span id="yj2">佣金</span>B：</td>
    <td align="left"><input type="text" name="CommissionB" id="CommissionB" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" /></td>
    <td align="right">&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr id="commC" style="display:none">
    <td align="right"><span id="yj3">佣金</span>C：</td>
    <td align="left"><input type="text" name="CommissionC" id="CommissionC" class="text_01 h20" onmouseover="this.className='text_01_h h20'" onmouseout="this.className='text_01 h20'" /></td>
    <td align="right">&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td align="right">&nbsp;</td>
    <td>&nbsp;</td>
    <td align="right">&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td colspan="4" align="center">
<input type="button" id="AddButton" onclick="surebutton()" class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'"  value="增加" />
<input type="button" id="AddCancel" onclick="escbutton()" class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="取消" />
	
	</td>
  </tr>
</table>
</div>
<div class="new_trfoot"></div>
</div>



<div class="cl"></div>

    <table width="100%" id="tb" cellpadding="0" class="tab2" >
        <thead>
            <tr>
                <th id="zh">帐号</th>
<%--                <th id="xm">姓名</th>
                <th id="dh">电话</th>
                <th id="xddh">行动电话</th>
--%>                <th id="bz">币种</th>
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
            <td id="tdbz"></td>
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

    </form>
    <div id="divTip" ></div>
    </body>
</html>
