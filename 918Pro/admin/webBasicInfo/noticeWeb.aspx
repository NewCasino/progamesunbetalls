<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="noticeWeb.aspx.cs" Inherits="admin.webBasicInfo.noticeWeb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
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
            pageWeb();

            jQuery('#btn-J-gameInfo').click(function () {
                var data = "";               
               
                data += "id:29";
                data += ",oval:'" + $('#urlWhere').val() + "'";

                jQuery.AjaxCommon("/ServicesFile/webBasicInfo/noticeWebService.asmx/UpdataPro_setup", data, false, false, function (json) {

                   
                });

                var data1 = "";

                data1 += "id:30";
                data1 += ",oval:'" + $('#yfWhere').val() + "'";

                jQuery.AjaxCommon("/ServicesFile/webBasicInfo/noticeWebService.asmx/UpdataPro_setup", data1, false, false, function (json) {

                    alert('更新成功！');
                });


                //

            });

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
                data += "cn:'" + jQuery("#contextcn").text().replace(/'/g, "Π") + "',tw:'" + jQuery("#contexttw").text().replace(/'/g, "Π") + "',en:'" + jQuery("#contexten").text().replace(/'/g, "Π") + "'";
                data += ",th:'" + jQuery("#contextth").text().replace(/'/g, "Π") + "',vn:'" + jQuery("#contextvn").text().replace(/'/g, "Π") + "',disu:'" + (jQuery("#disus").attr("checked") == true ? "1" : "0") + "'";
                data += ",disa:'" + (jQuery("#disAgt").attr("checked") == true ? "1" : "0") + "',winu:'" + (jQuery("#winus").attr("checked") == true ? "1" : "0") + "'";
                data += ",wina:'" + (jQuery("#winAgt").attr("checked") == true ? "1" : "0") + "'";
                jQuery.AjaxCommon("/ServicesFile/webBasicInfo/noticeWebService.asmx/save", data, false, false, function (json) {
                    alert("添加成功");
                });
                pageWeb();
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

        var setDate = function (data) {
            jQuery.AjaxCommon("/ServicesFile/webBasicInfo/noticeWebService.asmx/getDataAll", data, true, false, function (json) {
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
                        tr.find("#yy").text("简体中文");
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
                        <%if(mdfAc){ %>
                        aaa += "<a id=\"update\" ><img title=\"" + "修改" + "\" class=\"hand\" src=\"/images/Icon/page_edit.gif\" /></a>";
                        <%} %>
                        <%if(deleteAc) { %>
                        aaa += "&nbsp;&nbsp;&nbsp;&nbsp;" + "<a id=\"delete\"><img title=\"" + "删除" + "\" class=\"hand\" src=\"/images/Icon/list_packages.gif\" /></a>";
                        <%} %>
                        tr.find("#cz").html(aaa);
                        tr1.find("#xh").hide();
                        tr1.attr("attr", r[i].ID);
                        tr1.find("#sj").hide();
                        tr1.find("#yy").text("繁体中文");
                        tr1.find("#nr").text(r[i].msgtw);
                        tr1.find("#nr").attr("class", "tl");
                        tr1.find("#cz").hide();

                        tr2.find("#xh").hide();
                        tr2.find("#sj").hide();
                        tr2.attr("attr", r[i].ID);
                        tr2.find("#yy").text("英　　文");
                        tr2.find("#nr").text(r[i].msgen);
                        tr2.find("#nr").attr("class", "tl");
                        tr2.find("#cz").hide();

                        tr3.find("#xh").hide();
                        tr3.find("#sj").hide();
                        tr3.attr("attr", r[i].ID);
                        tr3.find("#yy").text("泰　　文");
                        tr3.find("#nr").text(r[i].msgth);
                        tr3.find("#nr").attr("class", "tl");
                        tr3.find("#cz").hide();

                        tr4.find("#xh").hide();
                        tr4.find("#sj").hide();
                        tr4.attr("attr", r[i].ID);
                        tr4.find("#yy").text("越　　文");
                        tr4.find("#nr").text(r[i].msgvn);
                        tr4.find("#nr").attr("class", "tl");
                        tr4.find("#cz").hide();
                        tr.appendTo("#showInfo");
                        tr1.appendTo("#showInfo");
                        tr2.appendTo("#showInfo");
                        tr3.appendTo("#showInfo");
                        tr4.appendTo("#showInfo");
                        tr.find("#cz").find("#update").click(function () {
                            var tra = jQuery("#tr1").clone();
                            tra.find("td:gt(0)").remove();
                            tra.find("td:eq(0)").attr("rowspan", "1");
                            tra.find("td:eq(0)").attr("colspan", "5");
                            tra.find("td:eq(0)").text("");
                            div.show().appendTo(tra.find("td:eq(0)"));
                            div.find("#xs").text("修改公告");
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
                                data += ",cn:'" + div.find("#contextcn").val().replace(/'/g, "Π") + "',tw:'" + div.find("#contexttw").val().replace(/'/g, "Π") + "',en:'" + div.find("#contexten").val().replace(/'/g, "Π") + "'";
                                data += ",th:'" + div.find("#contextth").val().replace(/'/g, "Π") + "',vn:'" + div.find("#contextvn").val().replace(/'/g, "Π") + "',disu:'" + (div.find("#disus").attr("checked") == true ? "1" : "0") + "'";
                                data += ",disa:'" + (div.find("#disAgt").attr("checked") == true ? "1" : "0") + "',winu:'" + (div.find("#winus").attr("checked") == true ? "1" : "0") + "'";
                                data += ",wina:'" + (div.find("#winAgt").attr("checked") == true ? "1" : "0") + "'";
                                jQuery.AjaxCommon("/ServicesFile/webBasicInfo/noticeWebService.asmx/update", data, true, false, function (json) {
                                    alert("修改成功");
                                    pageWeb();
                                });
                            });
                            tr4.after(tra);
                        });

                        tr.find("#cz").find("#delete").click(function () {
                            var data = "";
                            data += "id:" + r[i].ID;
                            if (confirm("是否要删除")) {
                                jQuery.AjaxCommon("/ServicesFile/webBasicInfo/noticeWebService.asmx/delete", data, true, false, function (json) {
                                    alert("删除成功");
                                    pageWeb();
                                });
                            }

                        });


                    });
                }
            });
        };

        var pageWeb = function () {
            jQuery.AjaxCommon("/ServicesFile/webBasicInfo/noticeWebService.asmx/getCount", "", true, false, function (json) {
                count = parseInt(json.d);
            });
            if (count % 20 == 0) {
                page = count / 20;
            }
            else {
                page = count / 20 + 1;
            }
            IsPage(parseInt(page), count, '20', 'IDex', 'IDexC');
        };

        var urlWhere = $('#urlWhere'),
            yfWhere = $('#yfWhere');
          
        starShow();
        function starShow() {

            jQuery.AjaxCommon("/ServicesFile/webBasicInfo/noticeWebService.asmx/GetPro_setup", "", true, false, function (json) {
               
                var result = $.parseJSON(json.d), arrys;
                $('#urlWhere').val(result[0].Oval);
                $('#yfWhere').val(result[1].Oval);
            });
        }
     
       
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
                        网站信息</p>
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
    <form id="form1" runat="server">
    <%if (addAc)
      { %>
    <div id="addDiv">
    <a id="add" class="fa_add"><span class="fa_add_in">新增</span></a>
    </div>
    <%} %>
    <div id="addInfo">
    <table border="0" class="boder_none tab2" style="width:100%">
        <thead>
        <tr>
        <th colspan="2"><span id="xs">新增公告</span></th>
        </tr>
        </thead>
        <tbody>
        <tr>
        <td width="10%" class="tr">简体中文公告:</td>
        <td width="*"><textarea style="width:98%" id="contextcn" class="text_01" rows="3" /></textarea></td>
        </tr>
        <tr>
        <td width="10%" class="tr">繁体中文公告:</td>
        <td  width="*"><textarea style="width:98%" id="contexttw" class="text_01"  rows="3" /></textarea></td>
        </tr>
        <tr>
        <td width="10%" class="tr">英　　文公告:</td>
        <td  width="*"><textarea style="width:98%" id="contexten" class="text_01" rows="3"  /></textarea></td>
        </tr>
        </tr>
        <tr>
        <td width="10%" class="tr">泰　　文公告:</td>
        <td  width="*"><textarea style="width:98%;" id="contextth" class="text_01" rows="3"  /></textarea></td>
        </tr>
        <tr>
        <td width="10%" class="tr">越　　文公告:</td>
        <td  width="*"><textarea style="width:98%" id="contextvn" class="text_01" rows="3"  /></textarea></td>
        </tr>
        <tr>
        <td colspan="2">
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
    <table id="tb2" class="tab2" style="width:100%">
    <thead>
    <tr>
    <th>序号</th>
    <th>时间</th>
    <th colspan="2">内容</th>
    <%if (mdfAc || deleteAc)
      { %>
    <th>操作</th>
    <%} %>
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
    <%if (mdfAc || deleteAc)
      { %>
    <td id="cz" width="10%"></td>
    <%} %>
    </tr>
    <tr class="tc"><td colspan="10"><div id="pageDiv" class="grayr"><span id="zg">总共</span><label id="infoCount"></label><span id="tjl">条记录</span>,<span id="g">共</span><label id="pageCount"></label><span id="y">页</span><a style="cursor:hand" id="sy"> 首页 </a><a style="cursor:hand" id="syy"> 上一页 </a><span id="pageSpan"></span><a style="cursor:hand" id="xyy"> 下一页 </a><a style="cursor:hand" id="wy"> 尾页 </a></div></td></tr>
    </tfoot>
    </table>
    </div>
    </form>
    <!--主题部分结束=========================================================================================-->
     </br> </br>
    <div  class="tab_top_m"><p style="color:green; font-size:15px">太阳城游戏安装端/活动优惠 设置</p> </div>
     
    </br>
     </br>
    游戏安装端路径:<input type="text" style="width:430px" id="urlWhere"/>
    </br> </br>
    太阳城活动优惠:<input type="text" style="width:430px" id="yfWhere"/><span style="color:red">注：以"/"分隔。示例：“3:首存三重礼，赠送30%/2:首存二重礼，赠送50%/1:首存一重礼，赠送100%”</span>
     </br> </br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <input type="button" id="btn-J-gameInfo" value="提交" />



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

   
</body>
</html>
