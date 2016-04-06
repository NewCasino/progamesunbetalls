<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeftMenu.aspx.cs"  EnableSessionState="True" EnableViewState="false" Inherits="admin.RoleRight.MenuManager.LeftMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>左侧菜单</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<link href="/css/default/globle.css" type="text/css" rel="stylesheet" />
<link href="/css/default/Guide.css" type="text/css" rel="stylesheet" />
<link href="/css/default/index.css" type="text/css" rel="stylesheet" />
<link href="/css/default/MasterPage.css" type="text/css" rel="stylesheet" />
<link href="/css/default/xtree.css" type="text/css" rel="stylesheet" />
<script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="/js/jQueryCommon.js" type="text/javascript"></script>
<style>
html{ overflow-x:hidden;}
</style>
    <script type="text/javascript">
        jQuery(function () {
            SetGlobal("");
            jQuery.each(jQuery("div.guideexpand"), function (i, n) {
                if (jQuery(n).attr("id") != "L07") {
                    jQuery(n).click();
                }
            });

            //debugger
            //            var aa = jQuery("div.guide:eq(0)");
            //            var bb = jQuery("div.guide:eq(0)").find("a:eq(0)");
            //            jQuery("div.guide:eq(0)").find("a:eq(0)").click();
        });

        var languages = "";
        function SetGlobal(setLang) {

            setLang = $.SetOrGetLanguage(setLang, function () {
                languages = language;
//                $("#L01").html(languages.网站帐号);
//                $("#L0101").html(languages.网站基本信息);
//                $("#L0102").html(languages.网站刷水账号);
//                $("#L0103").html(languages.网站投注帐号);
//                $("#L0104").html(languages.备案帐号查询);
//                $("#L0105").html(languages.网站日志);
//                $("#L0106").html(languages.网站最高投注账号);
//                $("#L0107").html(languages.网站代理帐号);

//                $("#L02").html(languages.系统管理);
//                $("#L0201").html(languages.用户);
//                $("#L0202").html(languages.角色);
//                $("#L0203").html(languages.模块管理);
//                $("#L0204").html(languages.系统设定);
//                $("#L0205").html(languages.会员等级);
//                $("#L0206").html(languages.备用网址);
//                $("#L0207").html(languages.代理权限);
//                $("#L0208").html(languages.代理服务器);

//                $("#L03").html(languages.比赛赛事);
//                $("#L0301").html(languages.放盘);
//                $("#L0302").html(languages.控盘);
//                $("#L0303").html(languages.比分录入);

//                $("#L04").html(languages.结算);
//                $("#L0401").html(languages.注单结算);
//                $("#L0402").html(languages.汇率管理);
//                $("#L0403").html(languages.汇率修改历史);
//                //$("#L0404").html(languages.帐号统计结算);
//                //$("#L0405").html(languages.IP统计结算);

//                $("#L05").html(languages.会员管理);
//                $("#L0501").html(languages.户口清单);
//                $("#L0502").html(languages.投注);
//                $("#L0503").html(languages.佣金);
//                $("#L0504").html(languages.信用);
//                $("#L0505").html(languages.预设占成数);
//                $("#L0506").html(languages.信用与户口余额);
//                $("#L0507").html(languages.重置会员信用);
//                $("#L0508").html(languages.会员等级);
//                $("#L0509").html(languages.现金会员);
//                $("#L0510").html(languages.客户管理);

//                $("#L06").html(languages.即时监控);
//                $("#L0601").html(languages.即时注单明细);
//                $("#L0602").html(languages.外调明细);
//                $("#L0603").html(languages.走地未确认注单);
//                $("#L0604").html(languages.亚洲盘及大小盘);
//                $("#L0605").html(languages.全场亚洲盘及大小盘);
//                $("#L0606").html(languages.半场亚洲盘及大小盘);
//                $("#L0608").html(languages.会员注单);
//                $("#L0609").html(languages.外调下注状况);

//                $("#L07").html(languages.报表);
//                $("#L0701").html(languages.赛事输赢);
//                $("#L0702").html(languages.输赢简易);
//                $("#L0703").html(languages.输赢);
//                $("#L0704").html(languages.赛事结果);
//                $("#L0705").html(languages.取消投注历史);
//                $("#L0706").html(languages.外调输赢);
//                $("#L0707").html(languages.核对投注历史);
//                $("#L0708").html(languages.代理对帐);
//                $("#L0709").html(languages.帐号统计);
//                $("#L0710").html(languages.IP统计);

//                $("#L08").html(languages.服务器);
//                $("#L0801").html(languages.服务器管理);
//                $("#L0802").html(languages.服务器绑定);
//                $("#L0803").html(languages.登录服务器);

//                $("#L09").html(languages.资讯);
//                $("#L0901").html(languages.公告);

//                $("#L10").html(languages.财务);
//                $("#L1001").html(languages.存款);
//                $("#L1002").html(languages.取款);
//                $("#L1003").html(languages.账目明细);
//                $("#L1004").html(languages.公司银行帐号);
//                $("#L1005").html(languages.银行日记账);
//                $("#L1006").html(languages.拒绝理由管理);
//                $("#L1007").html(languages.操作日志);
//                $("#L1008").html(languages.存取款月汇总);
//                $("#L1009").html(languages.存款历史);
//                $("#L1010").html(languages.取款历史);
//                $("#L1011").html(languages.客户银行管理);
//                $("#L1012").html(languages.交易序号);

//                $("#L11").html(languages.网站测试);
//                $("#L1101").html(languages.投注时间);
//                $("#L1102").html(languages.登录时间);

                $("#Guide_toptext").html(languages.H1414);

            });
        }

        function JumpToMainRight(url) { parent.frames["main_right"].location = url; }
        function ReloadMainRight() { parent.frames["main_right"].location.reload(); }
        function Switch(obj) {
            obj.className = (obj.className == "guideexpand") ? "guidecollapse" : "guideexpand";
            var nextDiv;
            if (obj.nextSibling) {
                if (obj.nextSibling.nodeName == "DIV") {
                    nextDiv = obj.nextSibling;
                }
                else {
                    if (obj.nextSibling.nextSibling) {
                        if (obj.nextSibling.nextSibling.nodeName == "DIV") {
                            nextDiv = obj.nextSibling.nextSibling;
                        }
                    }
                }
                if (nextDiv) {
                    nextDiv.style.display = (nextDiv.style.display != "") ? "" : "none";
                }
            }
        }
        function keylock(evt) {
            if ((evt.keyCode == 13) && (this.OpenMainRight)) {
                this.OpenMainRight();
            }
        }
        String.prototype.trim = function () {
            // 用正则表达式将前后空格
            // 用空字符串替代。
            return this.replace(/(^\s*)|(\s*$)/g, "");
        }


    </script>
 <style type="text/css">
    <!--
        .skin1 {
            cursor:default;
            font:menutext;
            position:absolute;
            text-align:left;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 10pt;
            width:120px;
            background-color:#cccccc;
            border:1 solid buttonface;
            visibility:hidden;
            border:2 outset buttonhighlight;
        }
        .menuitems {
            padding-left:15px;
            padding-right:10px;
    }
    -->
    </style>

</head>
<body>
    <form id="form1" runat="server">
            <div id="Guide_back">
            <ul>
                <li id="Guide_top">
                    <div id="Guide_toptext">
                        
    娱乐场

                    </div>
                </li>
                <li id="Guide_main">
                    <div id="Guide_box">
     
    <asp:Repeater ID="Repeater1" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
        <ItemTemplate>
            <div id='<%# Eval("Module_code") %>' class="guideexpand" onclick="Switch(this)"><%# Eval("Module_text") %>
                </div>
            <div class="guide">
                <ul>
                    <asp:Repeater ID="Repeater2" OnItemDataBound="Repeater2_ItemDataBound" runat="server">
                        <ItemTemplate>
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </ItemTemplate>
    </asp:Repeater>

                    </div>
                </li>
                <li id="Guide_bottom"></li>
            </ul>
        </div>

    </form>
</body>
</html>
