<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CasinoBetAccount.aspx.cs" Inherits="admin.webBasicInfo.CasinoBetAccount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jQueryCommon.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="/js/jquery.chromatable.js" type="text/javascript"></script>
    <script type="text/javascript">
        function OnResize() {
            $(".main_comp").height($(window).height() - 60);
            $(".left_comp").height($(window).height() - 60);
            $(".right_comp").height($(window).height() - 60);
            $(".right_comp").width($(".main_comp").width() - 220);
        }
        $(function () {
            SetGlobal("");
            objR.getCasinoAll();
            OnResize();
            var left_height = $(window).height() - 70;
            $("#username_box").chromatable({
                width: "183",
                height: left_height,
                scrolling: "yes"
            });

        });

        var languages = "";
        function SetGlobal(setLang) {
            setLang = $.SetOrGetLanguage(setLang, function () {
                languages = language;
                $(".H1060").html(languages.H1060);
            });
        }

        var objR = {
            url: "",
            data: "",
            getCasinoAll: function () {
                objR.data = "";
                var html = "";
                $.AjaxCommon("/ServicesFile/webBasicInfo/WebInfoService.asmx/GetCasinoData", objR.data, true, false, function (json) {
                    var $nav = $("#nav>ul"), i = 0;
                    if (json.d != "none") {
                        var lan = $.cookie("lan");
                        var r = jQuery.parseJSON(json.d), nameid = 0;
                        switch (lan) {
                            case "zh-cn":
                                nameid = 0; break; case "zh-tw": nameid = 1; break;
                            case "en-us": nameid = 2; break;
                            case "th-th": nameid = 3; break;
                            case "vi-vn": nameid = 4; break;
                            default: nameid = 0; break;
                        }
                        $.each(r, function (i) {
                            var arr = new Array(r[i].b, r[i].c, r[i].d, r[i].e, r[i].f);
                            html += "<li attr2='" + r[i].a + "'><a href='javascript:void(0)'><span>" + arr[nameid] + "</span></a></li>";
                        });
                    } else {
                        html = "<li>" + languages.H1013 + "</li>";
                    }
                    $nav.html(html);
                    $("li[attr2]:eq(0)>a").addClass("navColumn_fouce");
                    objR.getAccountById($("li[attr2]:eq(0)").attr("attr2"));
                    $("li[attr2]>a").bind("click", function () {
                        if (objR.data != $(this).parent("li").attr("attr2").toString()) {
                            objR.getAccountById($(this).parent("li").attr("attr2"));
                            $(this).addClass("navColumn_fouce").parent().siblings().find("a").removeClass("navColumn_fouce");
                        }
                        i = jQuery.inArray(this, $("li[attr2]>a"));
                    }).hover(function () {
                        $(this).addClass("navColumn_fouce").parent().siblings().find("a").removeClass("navColumn_fouce");
                    }, function () {
                        $("li[attr2]>a").eq(i).addClass("navColumn_fouce").parent().siblings().find("a").removeClass("navColumn_fouce");
                    });
                });
            },
            getAccountById: function (id) {
                objR.data = id;
                var html = "";
                $.AjaxCommon("/ServicesFile/webBasicInfo/AccountService.asmx/GetAccountData", "t:" + objR.data, true, false, function (json) {
                    var $tbody = $(".left_comp").find("table>tbody");
                    if (json.d != "none") {
                        var re = jQuery.parseJSON(json.d);
                        $.each(re, function (i) {
                            html += i % 2 ? "<td ids='" + re[i].b + "'><span>" + re[i].b + "</span></td></tr>"
                             : "<tr><td ids='" + re[i].b + "'><span>" + re[i].b + "</span></td>";
                        });
                        html += re.length % 2 == 0 ? "" : "<td></td></tr>";
                    } else {
                        html = "<tr><td colspan='2'><span>" + languages.H1013 + "</span></td></tr>";
                    }
                    $tbody.html(html);
                    $("table>tbody>tr>td[ids]").bind("click", function () {
                        objR.getCasinoAccountData(id, $(this).attr("ids"));
                    });
                });
            },
            getCasinoAccountData: function (casino, userid) {
                var $right_comp = $("div .right_comp"), html = "";
                $.AjaxCommon("/ServicesFile/webBasicInfo/AccountService.asmx/GetCasinoAccountData", "casino:'" + casino + "',userid:'" + userid + "'", true, false, function (json) {
                    if (json.d) {
                        html = (json.d).toString();
                    } else {
                        html = "" + languages.H1013 + "";
                    }
                    $right_comp.html(html);
                });
            }
        }
    </script>   
    <style type="text/css">
    html { overflow:hidden;  
           scrollbar-arrow-color: #419bbf;  /*三角箭头的颜色*/ 
           scrollbar-face-color: #c1e4fe;  /*立体滚动条的颜色*/ 
           scrollbar-3dlight-color: #eef3f7;  /*立体滚动条亮边的颜色*/ 
           scrollbar-highlight-color: #eef3f7;  /*滚动条空白部分的颜色*/ 
           scrollbar-shadow-color: #92c0e4;  /*立体滚动条阴影的颜色*/ 
           scrollbar-darkshadow-color: #cae7fd;  /*立体滚动条强阴影的颜色*/ 
           scrollbar-track-color: #e6f3fd;  /*立体滚动条背景颜色*/ }
   body{margin:0px;padding:0px;
         background-color:White;
         font-size:12px;color:#333; 
         line-height:150%;-webkit-text-size-adjust:none;
         font-family:"微软雅黑",Arial, Helvetica, sans-serif;}
    </style> 
</head>
<body onresize="OnResize()" >
<%if (viewAc)
  { %>
        <div class="comp_box">
<!--主题部分开始=========================================================================================-->
                <div class="top_comp">
                    <div class="cl navColumn">
                           <div class="navAdditional">
                                  <div id="nav">
                                      <ul>
                                        <!--<li><a href="#" class="navColumn_fouce"><span>沙霸</span></a></li>
                                        <li><a href="#"><span>永利高</span></a></li>-->
                                      </ul>
                                      </div>
                                  </div>
                      </div>
                </div>
            <div class="main_comp">
                <div class="left_comp">
                    <table class="tab2" id="username_box" border="0" width="183" cellpadding="5">
                        <thead>
                        <tr>
                        <th class="tit H1060" colspan="2">账号</th>
                        </tr>
                        </thead>
                        <tbody>
                        </tbody>
                        </table>
            </div>
        <div class="right_comp">

        </div>
        </div>

        <!--主题部分结束=========================================================-->
        </div>
        <%} %>
</body>
</html>