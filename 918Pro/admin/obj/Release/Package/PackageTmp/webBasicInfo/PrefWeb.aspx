<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrefWeb.aspx.cs" Inherits="admin.webBasicInfo.PrefWeb"  validateRequest="false" EnableEventValidation="false" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <meta content="text/html; charset=utf-8" http-equiv="Content-Type">
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jQueryCommon.js" type="text/javascript"></script>
    <script src="/js/page/pageJs.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var count = 0;
        var page = 0;
        var languages = "";
        
        jQuery(function () {
            //SetGlobal("");
            jQuery("#addInfo").hide();
            //pageWeb();
            
            jQuery("#add").click(function () {
                jQuery("#add").hide();
                jQuery("#addInfo").show();
            });
            jQuery("#esc").click(function () {
                jQuery("#contextcn").text("");
                jQuery("#contexttw").text("");
                jQuery("#contexten").text("");
                jQuery("#contextth").text("");
                jQuery("#contextvn").text("");
                jQuery("#add").show();
                jQuery("#addInfo").hide();
            });
            jQuery("#sure").click(function () {
                var data = "";
                data += "cn:'" + jQuery("#contextcn").text().replace(/'/g, "Π") + "',tw:'',en:''";
                data += ",th:'',vn:'',disu:'" + (jQuery("#disus").attr("checked") == true ? "1" : "0") + "'";
                data += ",disa:'" + (jQuery("#disAgt").attr("checked") == true ? "1" : "0") + "',winu:'" + (jQuery("#winus").attr("checked") == true ? "1" : "0") + "'";
                data += ",wina:'" + (jQuery("#winAgt").attr("checked") == true ? "1" : "0") + "'";
                jQuery.AjaxCommon("/ServicesFile/webBasicInfo/noticeWebService.asmx/save", data, false, false, function (json) {
                    alert("添加成功");
                });
                //pageWeb();
                jQuery("#contextcn").text("");
                jQuery("#contexttw").text("");
                jQuery("#contexten").text("");
                jQuery("#contextth").text("");
                jQuery("#contextvn").text("");
                jQuery("#add").show();
                jQuery("#addInfo").hide();
            });
        });

        function SetGlobal(setLang) {
            setLang = $.SetOrGetLanguage(setLang, function () {
                languages = language;

                jQuery("#sure").val(languages["H1025"]);
                jQuery("#esc").val(languages["H1011"]);

                $("#sy").text(languages["H1031"]);
                $("#wy").text(languages["H1034"]);
                $("#syy").text(languages["H1032"]);
                $("#xyy").text(languages["H1033"]);
                $("#zg").text(languages["H1028"]);
                $("#tjl").text(languages["H1029"]);
                $("#g").text(languages["H1028"]);
                $("#y").text(languages["H1030"]);
            });
        }

        function deles(obj) {
            var data = "";
            data += "id:" + $(obj).parent().parent().siblings("td:eq(0)").text();
            if (confirm("是否要删除")) {
                jQuery.AjaxCommon("/ServicesFile/webBasicInfo/noticeWebService.asmx/delete222", data, true, false, function (json) {
                    if (json.d) {
                        alert("删除成功");
                        location.reload() 
                    } else {
                        alert("删除失败，请联系开发人员，谢谢！");
                    }
                    

                });
            }
        }

        function edit(obj) {
           
           // $('#form2')[0].reset();
            $(':input', '#form2')
             .not(':button, :submit, :reset')
             .val('')
             .removeAttr('checked')
             .removeAttr('selected');



            jQuery("#idss").text($(obj).parent().parent().siblings("td:eq(0)").text());

            $('#tP0').val($(obj).parent().parent().siblings("td:eq(0)").text());
            jQuery("#tP1").val($(obj).parent().parent().siblings("td:eq(1)").text());
            jQuery("#tP2").val($(obj).parent().parent().siblings("td:eq(2)").text());
            jQuery("#tP3").val($(obj).parent().parent().siblings("td:eq(3)").text());
            jQuery("#tP4").val($(obj).parent().parent().siblings("td:eq(4)").text());
            jQuery("#tP5").val($(obj).parent().parent().siblings("td:eq(6)").text());


            jQuery("#edit").dialog({ modal: true, width: 909, height: 520 });

            jQuery("#button2").unbind("click");
            jQuery("#button2").bind("click", function () {
                jQuery("#edit").dialog("close");
                var url = "/ServicesFile/UserService.asmx/UpdateUser22";
                var data = "level:'" + $("#userlevel").val() + "',txtname:'" + jQuery("#txtname2").val() + "',txtquestion:'" + jQuery("#txtquestion").val() + "',txtanswer:'" + jQuery("#txtanswer").val() + "',txtnicheng:'" + jQuery("#txtnicheng").val() + "',txtemail:'" + $("#txtemail").val() + "',txttel:'" + $("#txttel").val() + "',txtpost:'" + $("#txtpost").val() + "',txtstatus:" + $("#txtstatus").val() + ",txtmark:'" + $("#txtmark").val() + "',ID:" + currId;
                jQuery.AjaxCommon(url, data, false, false, function (json) {
                    if (json.d) {
                        jQuery("#selectbutton").click();
                        //$.MsgTip({ objId: "#divTip", msg: "修改成功", delayTime: "2000" });
                        alert("修改成功");
                    }
                    else {
                        //$.MsgTip({ objId: "#divTip", msg: "修改失败", delayTime: "2000" });
                        alert("修改失败");
                    }
                });
            });

            jQuery("#mdfCancel").unbind("click");
            jQuery("#mdfCancel").bind("click", function () {
                jQuery("#edit").dialog("close");
            });
        }



       
       //会员活动
        jQuery.AjaxCommon("/ServicesFile/webBasicInfo/noticeWebService.asmx/getDataAll_1", "", true, false, function (json) {
            if (json.d != "none") {
                jQuery("#Tbody1>tr").remove();
                var r = jQuery.parseJSON(json.d);

                jQuery.each(r, function (i) {
                    var tr = jQuery("#tr2").clone();
                    var tr1 = jQuery("#tr2").clone();
                    var tr2 = jQuery("#tr2").clone();
                    var tr3 = jQuery("#tr2").clone();
                    var tr4 = jQuery("#tr2").clone();
                    //tr.attr("attr", i);

                    var tyss = '';
                    if (r[i].type == 0) {
                        tyss = '会员优惠活动';
                    } else {
                        tyss = '特殊优惠活动';
                    }
                    tr.find("#Td0").text(r[i].id);
                    tr.find("#Td1").text(tyss);
                    tr.find("#Td2").text(r[i].BigPric);
                    tr.find("#Td3").text(r[i].samlPric);
                    tr.find("#Td4").text(r[i].title);
                    tr.find("#Td5").text(r[i].conent.substr(0, 50)+"...");
                    tr.find("#Td55").text(r[i].conent);


                    var aaa = "";

                    aaa += "<a ssu=\"update\" ><img title=\"" + "修改" + "\" onclick=\"edit(this)\"  class=\"hand\" src=\"/images/Icon/page_edit.gif\" /></a>&nbsp;<a ssn=\"dele_1\" ><img title=\"" + "删除" + "\" onclick=\"deles(this)\"  class=\"hand\" src=\"/images/Icon/list_packages.gif\" /></a>";

                    tr.find("#Td6").html(aaa);

                    tr.appendTo("#Tbody1");
                });
            }
        });




        //会员活动
        jQuery.AjaxCommon("/ServicesFile/webBasicInfo/noticeWebService.asmx/getDataAll_2", "", true, false, function (json) {
            if (json.d != "none") {
                jQuery("#Tbody2>tr").remove();
                var r = jQuery.parseJSON(json.d);

                jQuery.each(r, function (i) {
                    var tr = jQuery("#tr00").clone();
                    var tr1 = jQuery("#tr00").clone();
                    var tr2 = jQuery("#tr00").clone();
                    var tr3 = jQuery("#tr00").clone();
                    var tr4 = jQuery("#tr00").clone();
                    //tr.attr("attr", i);

                    var tyss = '';
                    if (r[i].type == 0) {
                        tyss = '会员优惠活动';
                    } else {
                        tyss = '特殊优惠活动';
                    }

                    tr.find("#Td7").text(r[i].id);
                    tr.find("#Td8").text(tyss);
                    tr.find("#Td9").text(r[i].BigPric);
                    tr.find("#Td10").text(r[i].samlPric);
                    tr.find("#Td11").text(r[i].title);
                    tr.find("#Td12").text(r[i].conent.substr(0, 50) + "...");
                    tr.find("#Td122").text(r[i].conent);


                    var aaa = "";

                    aaa += "<a ssu=\"update\" ><img title=\"" + "修改" + "\" onclick=\"edit(this)\"  class=\"hand\" src=\"/images/Icon/page_edit.gif\" /></a>&nbsp;<a ssn=\"dele_1\" ><img title=\"" + "删除" + "\" onclick=\"deles(this)\"  class=\"hand\" src=\"/images/Icon/list_packages.gif\" /></a>";

                    tr.find("#Td13").html(aaa);

                    tr.appendTo("#Tbody2");
                });
                

            }
        });




        jQuery.AjaxCommon("/ServicesFile/webBasicInfo/noticeWebService.asmx/getDataAll222", "", true, false, function (json) {
            if (json.d != "none") {
                jQuery("#showInfo>tr").remove();
                var r = jQuery.parseJSON(json.d);
                var div = jQuery("#addInfo").clone();
                jQuery.each(r, function (i) {
                    var tr = jQuery("#tr1").clone();
                    var tr1 = jQuery("#tr1").clone();
                    var tr2 = jQuery("#tr1").clone();
                    var tr3 = jQuery("#tr1").clone();
                    var tr4 = jQuery("#tr1").clone();
                    tr.attr("attr", r[i].ID);
                    tr.find("#xh").text(i + 1);
                    tr.find("#xh").attr("rowspan", "5");
                    tr.find("#sj").text(r[i].createdate);
                    tr.find("#sj").attr("rowspan", "5");
                    tr.find("#yy").text("中奖信息显示");
                    tr.find("#nr").text(r[i].msgcn);
                    tr.find("#nr").attr("class", "tl");
                    tr.find("#cz").attr("rowspan", "5");
                    //                        var setLang = "";
                    //                        setLang = $.SetOrGetLanguage(setLang, function () {
                    //                            languages = language;
                    //                            tr.find("#cz").html((addAc == 0 ? "<a id=\"ReAdd\"><img title=\"" + languages["H1015"] + "\" src=\"/images/Icon/page_new.gif\" /></a>" : "") + "&nbsp;&nbsp;&nbsp;&nbsp;" + (fzAc == 0 ? "<a id=\"RepeatAdd\"><img title=\"" + languages["H1051"] + "\" src=\"/images/Icon/note_new.gif\" class=\"hand\" /></a>" : "") + "&nbsp;&nbsp;&nbsp;&nbsp;" + (mdfAc == 0 ? "<a id=\"update\" ><img title=\"" + languages["H1009"] + "\" class=\"hand\" src=\"/images/Icon/page_edit.gif\" /></a>" : "") + "&nbsp;&nbsp;&nbsp;&nbsp;" + (deleteAc == 0 ? "<a id=\"delete\"><img title=\"" + languages["H1081"] + "\" class=\"hand\" src=\"/images/Icon/list_packages.gif\" /></a>" : ""));
                    //                        }, "/js/IndexGlobal/");
                    //tr.find("#cz").html((mdfAc == 0 ? "<a id=\"update\" ><img title=\"" + languages["H1009"] + "\" class=\"hand\" src=\"/images/Icon/page_edit.gif\" /></a>" : "") + "&nbsp;&nbsp;&nbsp;&nbsp;" + (deleteAc == 0 ? "<a id=\"delete\"><img title=\"" + languages["H1081"] + "\" class=\"hand\" src=\"/images/Icon/list_packages.gif\" /></a>" : ""));
                    var aaa = "";

                    aaa += "<a id=\"update\" ><img title=\"" + "修改" + "\" class=\"hand\" src=\"/images/Icon/page_edit.gif\" /></a>";

                    tr.find("#cz").html(aaa);

                    tr.appendTo("#showInfo");

                    tr.find("#cz").find("#update").click(function () {
                        var tra = jQuery("#tr1").clone();
                        tra.find("td:gt(0)").remove();
                        tra.find("td:eq(0)").attr("rowspan", "1");
                        tra.find("td:eq(0)").attr("colspan", "5");
                        tra.find("td:eq(0)").text("");
                        div.show().appendTo(tra.find("td:eq(0)"));
                        div.find("#xs").text("修改中奖者信息");
                        div.find("#contextcn").text(r[i].msgcn);
                        div.find("#contexttw").text(r[i].msgtw);
                        div.find("#contexten").text(r[i].msgen);
                        div.find("#contextth").text(r[i].msgth);
                        div.find("#contextvn").text(r[i].msgvn);
                        div.find(":checkbox:eq(0)").attr("checked", r[i].displayuser == "1" ? "checked" : "");
                        div.find(":checkbox:eq(1)").attr("checked", r[i].displayagent == "1" ? "checked" : "");
                        div.find(":checkbox:eq(2)").attr("checked", r[i].windowuser == "1" ? "checked" : "");
                        div.find(":checkbox:eq(3)").attr("checked", r[i].windowagent == "1" ? "checked" : "");
                        div.find("#esc").click(function () {
                            jQuery(this).parent().parent().parent().parent().parent().remove();
                        });
                        div.find("#sure").click(function () {
                            var data = "";
                            data += "id:" + r[i].ID;
                            data += ",cn:'" + div.find("#contextcn").val().replace(/'/g, "Π") + "',tw:'',en:''";
                            data += ",th:'',vn:'',disu:'" + (div.find("#disus").attr("checked") == true ? "1" : "0") + "'";
                            data += ",disa:'" + (div.find("#disAgt").attr("checked") == true ? "1" : "0") + "',winu:'" + (div.find("#winus").attr("checked") == true ? "1" : "0") + "'";
                            data += ",wina:'" + (div.find("#winAgt").attr("checked") == true ? "1" : "0") + "'";
                            jQuery.AjaxCommon("/ServicesFile/webBasicInfo/noticeWebService.asmx/update", data, true, false, function (json) {
                                div.find("#esc").click();
                                alert("修改成功");
                                // pageWeb();

                            });
                        });
                        $('#tr1').after(tra);
                    });

                    tr.find("#cz").find("#delete").click(function () {
                        var data = "";
                        data += "id:" + r[i].ID;
                        if (confirm("是否要删除")) {
                            jQuery.AjaxCommon("/ServicesFile/webBasicInfo/noticeWebService.asmx/delete", data, true, false, function (json) {
                                alert("删除成功");
                                // pageWeb();
                            });
                        }

                    });


                });
            }
        });
    

       
    </script>
    <style type="text/css">
        textarea{ font-family:微软雅黑; line-height:18px; font-size:12px;}
    </style>
</head>
<body>

<table id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
        <thead>
            <tr class="h30">
                <th width="12" class="tab_top_l">
                </th>
                <th width="*" class="tab_top_m">
                    <p id="wzxx">
                        优惠活动/中奖名单列表</p>
                </th>
                <th width="16" class="tab_top_r">
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td class="tab_middle_l">
                </td>
                <td>
                    <div id="main">
                        <!--主题部分开始=========================================================================================-->
   
   
    <div id="addDiv">
    
    </div>
   
     <div id="addInfo">
    <table border="0" class="boder_none tab2" style="width:100%">
        <thead>
        <tr>
        <th colspan="2"><span id="xs"></span></th>
        </tr>
        </thead>
        <tbody>
        <tr>
        <td width="10%" class="tr">修改中奖信息:</td>
        <td width="*"><textarea style="width:98%" id="contextcn" class="text_01" rows="3" /></textarea></td>
        </tr>
       <%-- <tr style=" display:nonoe">
        <td width="10%" class="tr">繁体中文公告:</td>
        <td  width="*"><textarea style="width:98%" id="contexttw" class="text_01"  rows="3" /></textarea></td>
        </tr>
         <tr style=" display:nonoe">
        <td width="10%" class="tr">英　　文公告:</td>
        <td  width="*"><textarea style="width:98%" id="contexten" class="text_01" rows="3"  /></textarea></td>
        </tr>
        </tr>
         <tr style=" display:nonoe">
        <td width="10%" class="tr">泰　　文公告:</td>
        <td  width="*"><textarea style="width:98%;" id="contextth" class="text_01" rows="3"  /></textarea></td>
        </tr>
         <tr style=" display:nonoe">
        <td width="10%" class="tr">越　　文公告:</td>
        <td  width="*"><textarea style="width:98%" id="contextvn" class="text_01" rows="3"  /></textarea></td>
        </tr>--%>
        <tr>
        <td colspan="2"  style=" display:nonoe">
        <input type="checkbox" checked id="disus" /><span id="disu">显示前台</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type="checkbox" checked id="disAgt" /><span id="disa">显示代理</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type="checkbox" checked id="winus" /><span id="winu">弹出前台</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input type="checkbox" checked id="winAgt" /><span id="wina">弹出代理</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
        </tr>
        </tbody>
        <tfoot>
        <tr>
        <td colspan="2">
        <input type="button" id="sure" class="btn_02" onmouseover="this.className='btn_02_h'"
            onmouseout="this.className='btn_02'" value="保存" />
        <input type="button" id="esc" class="btn_02" onmouseover="this.className='btn_02_h'"
            onmouseout="this.className='btn_02'" value="取消" />
        </td>
        </tr>
        </tfoot>
    </table>
    </div>
    <div>
     <br />
     <span style=" font-size:14px; color:Blue">中奖信息管理</span></p>
    <table id="tb2" class="tab2" style="width:100%">
    <thead>
    <tr>
    <th>序号</th>
    <th>时间</th>
    <th colspan="2">内容</th>
   
    <th>操作</th>
   
    </tr>
    </thead>
    <tbody id="showInfo">
    </tbody>
    <tfoot>
    <tr id="tr1">
    <td id="xh" width="10%"></td>
    <td id="sj" width="20%"></td>
    <td id="yy" width="10%"></td>
    <td id="nr" width="50%" class="tl"></td>
   
    <td id="cz" width="10%"></td>
   
    </tr>
   
    </tfoot>
    </table>


    <br /> <br />
    <span style=" font-size:14px; color:Blue">（会员优惠活动管理）--<a target="main_right" href="PrefWeb2.aspx">【新增】</a></p>
    <table id="Table1" class="tab2" style="width:100%">
    <thead>
    <tr>
    <th>ID</th>
    <th>活动</th>
    <th>首页大图</th>
    <th>优惠页小图</th>
     <th>标题</th>
    <th colspan="2">内容</th>   
    <th>操作</th>
   
    </tr>
    </thead>
    <tbody id="Tbody1">
    </tbody>
   <tfoot>
    <tr id="tr2">
    <td id="Td0"></td>
    <td id="Td1"></td>
    <td id="Td2" ></td>
    <td id="Td3" ></td>
    <td id="Td4"  ></td>
   
    <td id="Td5" colspan="2"></td>
    
    <td id="Td55"  style="  display:none"></td>
  <td id="Td6" ></td>
    </tr>
   
    </tfoot>
    </table>


     <br /> <br />
    <span style=" font-size:14px; color:Blue">（特别优惠活动管理）--<a target="main_right" href="PrefWeb2.aspx">【新增】</a></p>
    <table id="Table2" class="tab2" style="width:100%">
    <thead>
    <tr>
    <th>ID</th>
   <th>活动</th>
    <th>首页大图</th>
    <th>优惠页小图</th>
     <th>标题</th>
    <th colspan="2">内容</th>   
    <th>操作</th>
   
    </tr>
    </thead>
    <tbody id="Tbody2">
    </tbody>
    <tfoot>
    <tr id="tr00">
    <td id="Td7"></td>
    <td id="Td8"></td>
    <td id="Td9" ></td>
    <td id="Td10" ></td>
    <td id="Td11"  ></td>
   
    <td id="Td12" colspan="2" ></td>
    <td id="Td122"  style=" display:none"></td>
    
  <td id="Td13" ></td>
    </tr>
   
    </tfoot>
    </table>


    </div>
   
    <!--主题部分结束=========================================================================================-->
                    </div>
                </td>
                <td class="tab_middle_r">
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr class="h35">
                <td width="12" class="tab_foot_l">
                </td>
                <td width="*" class="tab_foot_m">
                </td>
                <td width="16" class="tab_foot_r">
                </td>
            </tr>
        </tfoot>
    </table>

 <div id="edit" title="修改活动"  style=" display:none">
 <form id="form2" runat="server" >
<div class="showdiv">
<ul>

 
 <input type="hidden"  id="tP0"  runat=server/>
<li><p><span id="Span0" > ID</span>：</p> <p   >  <asp:Label ID="idss" runat="server"  ></asp:Label></p></li>

<li><p><span id="Span1" >活动</span>：</p> <p><asp:TextBox ID="tP1" CssClass="text h24 w_500" runat="server"></asp:TextBox></p></li>
<li><p><span id="Span2">首页大图</span>：</p><p ><asp:TextBox ID="tP2" CssClass="text h24 w_500" runat="server"></asp:TextBox> </p><p style=" color:red">重新选择：</p><asp:FileUpload ID="fileAccessories"   CssClass="file" runat="server"/></li>
<li><p><span id="Span3">优惠页小图</span>：</p><p > <asp:TextBox ID="tP3" CssClass="text h24 w_500" runat="server"></asp:TextBox></p><p style=" color:red">重新选择：</p><asp:FileUpload ID="FileUpload1" CssClass="file" runat="server"/></li>
<li><p><span id="Span4">标题</span>：</p><asp:TextBox ID="tP4" CssClass="text h24 w_500" runat="server"></asp:TextBox></li>


<li><p><span id="Span5">内容：</span></p>
 <FCKeditorV2:FCKeditor id="tP5" runat="server" Width="770px" Height="260px">
                    </FCKeditorV2:FCKeditor>&nbsp;&nbsp;
</li>

<li><div align="center" >
    <asp:Button ID="bntAddNews" runat="server" CssClass="btn_04" Text="提 交" 
               style=" width:80px; height:30px; background-color: #CCCCFF;" onclick="bntAddNews_Click" 
                />
&nbsp;
  <input type="button" id="mdfCancel" class="btn_02" value="取消" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" /></div></li>
</ul>
</div>
</form>
</div>


</body>
</html>
 