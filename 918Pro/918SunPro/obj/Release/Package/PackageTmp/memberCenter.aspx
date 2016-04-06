<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="memberCenter.aspx.cs" Inherits="_918SunPro.portal_asset.templates.memberCenter" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <meta charset="utf-8" />
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>会员中心</title>
    <link rel="icon" href="/images/favicon.ico" type="image/x-icon" />
    <link type="text/css" rel="stylesheet" media="all" href="index.css" />
    <link type="text/css" rel="stylesheet" href="css/huiyuan.css" />
     <link rel="stylesheet" type="text/css" href="/portal_asset/css/style.css?t=20150930164800" />
    <link rel="stylesheet" type="text/css" href="/portal_asset/css/page/slider.css" />
    <link rel="stylesheet" type="text/css" href="/portal_asset/css/module/jquery.jscrollpane.css" />
    <link href="portal_asset/css/jquery-ui.css" rel="stylesheet" />
   
   
</head>
<body>
    <div xmlns:my="ignored" id="ng-app" ng-app="ctrlApp">
         <div class="nav">
                 <div class="nav_small">
                <ul style="float:left">
                    <li><a href="help.html">常见问题</a></li>
                    <li><span>&nbsp;|</span><a href="freePay.html">&nbsp;免费参观</a></li>
                    <li><span>&nbsp;|</span><a href="about.html">&nbsp;关于我们</a></li>
                    <!--<li><a href="">手机投注<span>|</span></a></li>-->
                    <li><span>&nbsp;|</span><a href="zhaopai.html">&nbsp;牌照展示</a></li>
                    <li><span>&nbsp;|&nbsp;</span><a my-checklogin="" href="javascript:void(0)" class="over" ng-if="status.isLoaded" href-link="#" is-check-login="true" lobby-type="live" target="_blank" action-text="banners.liveGame.btn_text_login" login-text="banners.liveGame.btn_text">登陆游戏</a></li>

                </ul>

                <ul style="float:right">

                    <li class="userInfo left" ng-show="isAuthorized">
                        <div>

                            <p class="userInfo left white">欢迎您：{{username}} &nbsp;&nbsp;<a href="memberCenter.aspx">【会员中心】</a> &nbsp;&nbsp;</p>
                            <div class="clearFix"></div>
                        </div>
                    </li>


                    <li class="LS-service" ng-show="isAuthorized" ng-click="tgpLogout(true)">
                        <span style=" font-weight: 800; font-size: 14px; color: #3B240B;">【</span><a href="" class="over" id="tgpLogout" data-i18n="button.logout" style=" font-weight: 800; font-size: 14px; color: #3B240B;"></a><span style=" font-weight: 800; font-size: 14px; color: #3B240B;">】</span>
                        </>
                    </li>
                    <!--<li><a href="">会员中心<span>|</span></a></li>-->

                    <li><a id="pro_setup" href="http://www.11psb.com/air/air-bin/SunbetGameSetup3.4.0.exe">&nbsp;客户端下载</a></li>
                    <li><span>&nbsp;|</span><a href="appGame.html" target="_blank">&nbsp;手机APP版</a></li>
                    <li>
                        <div ng-hide="isAuthorized">
                            <span>&nbsp;|</span><a href="#" onclick="AddFavorite(window.location,document.title)">&nbsp;&nbsp;加入收藏</a>
                        </div>
                    </li>

                    <li>
                        <div ng-hide="isAuthorized">
                            <span>&nbsp;|</span><a href="javascript:void(0)" onclick="SetHome(this,window.location)">&nbsp;&nbsp;设为首页</a>
                        </div>
                    </li>
                </ul>
                <div class="yuan"></div>
            </div>
        </div>

        <div class="nav_bottm">
            <div class="logo">
                <a href=""><img src="images/logo.png" alt="" /></a>
            </div>
            <div class="kaitong">
                <a href="register.html"><img src="images/logo_icon_06.png" alt="" /></a>
            </div>

            <div class="login"><a my-checklogin="" id="sliderBtn" href="javascript:void(0)" class="over" ng-if="status.isLoaded" href-link="#" is-check-login="true" lobby-type="live" target="_blank" action-text="banners.liveGame.btn_text_login" login-text="banners.liveGame.btn_text"></a> </div>

            <div class="pelope">
                <a href="javascript:void(0);" onclick="openwin()"><img src="images/logo_icon_03.png" alt="" /></a>
            </div>
        </div>


        <div class="modal-overlay my-hidden" ng-show="isShowTnc">
            <div class="mask"></div>
            <div id="tncDetail" class="tnc-modal-detail">
                <div id="tncModal" class="modal-content">
                    <div class="modal-title" data-i18n="login.userTnC"></div>
                    <div class="clearfix"></div>
                    <div id="tncContent" class="modal-inner-content">
                        <div my-tnc=my-tnc></div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="modal-btn">
                        <a data-i18n="button.agree" ng-click="closeTnc()" class="btn-first button left"> </a>
                        <a data-i18n="button.disagree" ng-click="disagreeTnc()" class="btn-second button left"></a>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal-overlay my-hidden" ng-show="isShowConfirmLogout">
            <div class="mask" ng-click="cancelLogout()"></div>
            <div class="logout-modal-detail" ng-hide="logoutTGPLoading">
                <div class="modal-content">
                    <div>
                        <div class="btn-close" ng-click="cancelLogout()"></div>
                        <div class="clearfix"></div>
                        <div class="modal-title" data-i18n="login.confirmLogout"></div>
                        <div class="modal-btn">
                            <a data-i18n="button.confirm" ng-click="confirmLogout()" class="btn-first button "> </a>
                            <a data-i18n="button.cancel" ng-click="cancelLogout()" class="btn-second button "></a>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="logoutLoading" ng-show="logoutTGPLoading">
                <img src="/portal_asset/images/loading.gif" />
            </div>
        </div>


        <div class="modal-overlay my-hidden" ng-show="isShowPopupGame" style=" display:none">
            <div class="mask" ng-click="cancelPopupGame()"></div>
            <div class="logout-modal-detail">
                <div class="modal-content">
                    <div>
                        <div class="btn-close" ng-click="isShowPopupGame = false"></div>
                        <div class="clearfix"></div>
                        <div class="modal-title" data-i18n="button.enterNowConfirm"></div>
                        <div class="modal-btn">
                            <a data-i18n="button.confirm" ng-click="openUrl(currentPage)" class="btn-first button left"> </a>
                            <a data-i18n="button.cancel" ng-click="isShowPopupGame = false" class="btn-second button left"></a>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <my-hidden></my-hidden>
    </div>

   <div class="content" style="height:973px">
  <div class="cent_nav">
    <ul>
        <li><a href="index.html" class="a"></a></li>
        <li><a href="gameProject.html" class="b"></a></li>
        <li><a href="transfers.aspx" class="c"></a></li>
        <li><a href="promotion.html" class="d"></a></li>
        <li><a href="agent.html" class="f"></a></li>
        <li><a href="transfers1.aspx" class="e" target="_blank"></a></li>

    </ul>
  </div>
    <p class="tishi">
        <marquee behavior="scroll" scrolldelay="200" onmouseout="this.start()" onmouseover="this.stop()" id="demo2"></marquee>

    </p>
       <div class="main" style="height:792px">
           <div class="title"> 会员中心 </div>
    <div class="hy_content"> 
      <!--tag标题-->
      <ul id="nav4">
        <li><a href="javascript:void(0)" class="selected2">存款记录</a></li>
        <li><a href="javascript:void(0)" class="">取款记录</a></li>
        <li><a href="javascript:void(0)" class="">红利记录</a></li>
        <li><a href="javascript:void(0)" class="">返水记录</a></li>
       <%-- <li><a href="javascript:void(0)" class="">最新消息</a></li>--%>
      </ul>
      <!--二级菜单-->
      <div id="menu_con">
        <div class="tag" style="display:block">
          <table cellpadding="0" cellspacing="0">         
            <tr>
              <td width="40" height="40"  style='color:#333;'>时间：</td>
              <td width="110" height="40"><input name="textfield" id="time1WhereVal"  readonly="readonly" class="tet1" type="text" size="16" style=" height:24px; width:80px"></td>
              <td width="110" height="40"><input name="textfield2" id="time2WhereVal" readonly="readonly" readonly="readonly" class="tet1" type="text" size="16" style=" height:24px; width:80px"></td>
              <td width="80" height="40">
                   <select name="select" style=" height:24px; width:80px" id="status" name="cars">           
                    <option value="1" class="L192">未审核</option>
                    <option value="2" class="L193" selected>已审核</option>
                  </select>
                  </td>
              <td height="40">
                  
                  <button id="selectByWhere"><img src="images/tcx.png"  ></button></td>
            </tr>
           
          </table>
          <table cellpadding="0" cellspacing="1" bgcolor="#adadad" id="tab1">
            <thead>
                <tr>
                    <th width="50" height="30" bgcolor="#E7E7E7" align="center" style='color:#333;'>序号</th>
                    <th width="80" align="center" bgcolor="#E7E7E7" style='color:#333;'>类型</th>
                    <th width="120" align="center" bgcolor="#E7E7E7" style='color:#333;'>金额</th>
                    <th width="160" align="center" bgcolor="#E7E7E7" style='color:#333;'>提交时间</th>
                    <th width="160" align="center" bgcolor="#E7E7E7" style='color:#333;'>处理时间</th>
                    <th width="70" align="center" bgcolor="#E7E7E7" style='color:#333;'>状态</th>
                    <th width="60" align="center" bgcolor="#E7E7E7" style='color:#333;'>备注</th>
                </tr>
            </thead>
           <%-- <tr>
              <td width="50" height="30" align="center" bgcolor="#F2F2F2">1</td>
              <td width="80" align="center" bgcolor="#F2F2F2">存款</td>
              <td width="120" align="center" bgcolor="#F2F2F2">1000（RMB）</td>
              <td width="160" align="center" bgcolor="#F2F2F2">2015-4-24 11:59</td>
              <td width="160" align="center" bgcolor="#F2F2F2">2015-4-24 11:59</td>
              <td width="70" align="center" bgcolor="#F2F2F2">已审核</td>
              <td width="60" align="center" bgcolor="#F2F2F2">----</td>
            </tr>--%>
              <tbody height="">
                <tr> 
                  <td colspan="7" align="center" style='color:#333;'><font color="#fff">请选择时间后点击查询</font></td>
                </tr>
                </tbody>
          </table>
        </div>
        <div class="tag" style="display:none">
          <table cellpadding="0" cellspacing="0">
            <tr>
              <td width="40" height="40" style='color:#333;'>时间：</td>
              <td width="110" height="40"><input type="text" name="textfield" id="time3WhereVal"  readonly="readonly" class="tet1" type="text" size="16" style=" height:24px; width:80px"/></td>
              <td width="110" height="40"><input type="text" name="textfield" id="time4WhereVal"  readonly="readonly" class="tet1" type="text" size="16" style=" height:24px; width:80px"/></td>
              <td width="80" height="40"><select name="cars" id="status2" >
                <option value="1" class="L192">未审核</option>
                    <option value="2" class="L193" selected>已审核</option>
                </select></td>
              <td height="40">
                  <button id="selectByWhere2"><img src="images/tcx.png" alt=""></button></td>
            </tr>
          </table>
          <table cellpadding="0" cellspacing="1" bgcolor="#adadad"  id="tab2" >
            <thead>
                <tr>
                    <th width="50" height="30" align="center" bgcolor="#E7E7E7" style='color:#333;'>序号</th>
                    <th width="80" align="center" bgcolor="#E7E7E7" style='color:#333;'>类型</th>
                    <th width="120" align="center" bgcolor="#E7E7E7" style='color:#333;'>金额</th>
                    <th width="160" align="center" bgcolor="#E7E7E7" style='color:#333;'>提交时间</th>
                    <th width="160" align="center" bgcolor="#E7E7E7" style='color:#333;'>处理时间</th>
                    <th width="70" align="center" bgcolor="#E7E7E7" style='color:#333;'>状态</th>
                    <th width="60" align="center" bgcolor="#E7E7E7" style='color:#333;'>备注</th>
                </tr>
            </thead>
           <%-- <tr>
              <td width="50" height="30" align="center" bgcolor="#F2F2F2">1</td>
              <td width="80" align="center" bgcolor="#F2F2F2">存款</td>
              <td width="120" align="center" bgcolor="#F2F2F2">1000（RMB）</td>
              <td width="160" align="center" bgcolor="#F2F2F2">2015-4-24 11:59</td>
              <td width="160" align="center" bgcolor="#F2F2F2">2015-4-24 11:59</td>
              <td width="70" align="center" bgcolor="#F2F2F2">已审核</td>
              <td width="60" align="center" bgcolor="#F2F2F2">----</td>
            </tr>--%>
              <tbody height="">
                <tr> 
                  <td colspan="7" align="center" style='color:#333;'><font color="#fff">请选择时间后点击查询</font></td>
                </tr>
                </tbody>
          </table>
        </div>
        <div class="tag"  style="display:none">
          <table cellpadding="0" cellspacing="0">
            <tr>
              <td width="40" height="40" style='color:#333;'>时间：</td>
              <td width="110" height="40"><input type="text" name="textfield" id="time5WhereVal"  readonly="readonly" class="tet1" type="text" size="16" style=" height:24px; width:80px" /></td>
              <td width="110" height="40"><input type="text" name="textfield" id="time6WhereVal"  readonly="readonly" class="tet1" type="text" size="16" style=" height:24px; width:80px" /></td>
              <td width="80" height="40"><select name="cars" id="status3">
                 <option value="1" class="L192">未审核</option>
                    <option value="2" class="L193" selected>已审核</option>
                </select></td>
              <td height="40">
                  <button id="selectByWhere3"><img src="images/tcx.png" alt=""></button></td>
            </tr>
          </table>
          <table cellpadding="0" cellspacing="1" bgcolor="#adadad" id="tab3">
            <thead>
                <tr>
                    <th width="50" height="30" align="center" bgcolor="#E7E7E7" style='color:#333;'>序号</th>
                    <th width="80" align="center" bgcolor="#E7E7E7" style='color:#333;'>类型</th>
                    <th width="120" align="center" bgcolor="#E7E7E7" style='color:#333;'>金额</th>
                    <th width="160" align="center" bgcolor="#E7E7E7" style='color:#333;'>提交时间</th>
                    <th width="160" align="center" bgcolor="#E7E7E7" style='color:#333;'>处理时间</th>
                    <th width="70" align="center" bgcolor="#E7E7E7" style='color:#333;'>状态</th>
                    <th width="60" align="center" bgcolor="#E7E7E7" style='color:#333;'>备注</th>
                </tr>
            </thead>
           <%-- <tr>
              <td width="50" height="30" align="center" bgcolor="#F2F2F2">1</td>
              <td width="80" align="center" bgcolor="#F2F2F2">存款</td>
              <td width="120" align="center" bgcolor="#F2F2F2">1000（RMB）</td>
              <td width="160" align="center" bgcolor="#F2F2F2">2015-4-24 11:59</td>
              <td width="160" align="center" bgcolor="#F2F2F2">2015-4-24 11:59</td>
              <td width="70" align="center" bgcolor="#F2F2F2">已审核</td>
              <td width="60" align="center" bgcolor="#F2F2F2">----</td>
            </tr>--%>
              <tbody height="">
                <tr> 
                  <td colspan="7" align="center" style='color:#333;'><font color="#fff">请选择时间后点击查询</font></td>
                </tr>
                </tbody>
          </table>
        </div>
        <div class="tag"  style="display:none">
          <table cellpadding="0" cellspacing="0">
            <tr>
              <td width="40" height="40" style='color:#333;'>时间：</td>
              <td width="110" height="40" style='color:#333;'><input  type="text" name="textfield" id="time7WhereVal"  readonly="readonly" class="tet1" size="16" style=" height:24px; width:80px"  /></td>
              <td width="110" height="40" style='color:#333;'><input  type="text" name="textfield"  id="time8WhereVal"  readonly="readonly" class="tet1"  size="16" style=" height:24px; width:80px"/></td>
              <td width="80" height="40" style='color:#333;'><select name="cars" id="status4">
                  <option value="1" class="L192">未审核</option>
                    <option value="2" class="L193" selected>已审核</option>
                </select></td>
              <td height="40">
                  <button  id="selectByWhere4"><img src="images/tcx.png" alt=""></button>
                  
 </td>
            </tr>
          </table>
          <table cellpadding="0" cellspacing="1" bgcolor="#adadad" id="tab4">
          <thead>
                <tr>
                    <th width="50" height="30" align="center" bgcolor="#E7E7E7" style='color:#333;'>序号</th>
                    <th width="80" align="center" bgcolor="#E7E7E7" style='color:#333;'>类型</th>
                    <th width="120" align="center" bgcolor="#E7E7E7" style='color:#333;'>金额</th>
                    <th width="160" align="center" bgcolor="#E7E7E7" style='color:#333;'>提交时间</th>
                    <th width="160" align="center" bgcolor="#E7E7E7" style='color:#333;'>处理时间</th>
                    <th width="70" align="center" bgcolor="#E7E7E7" style='color:#333;'>状态</th>
                    <th width="60" align="center" bgcolor="#E7E7E7" style='color:#333;'>备注</th>
                </tr>
            </thead>
           <%-- <tr>
              <td width="50" height="30" align="center" bgcolor="#F2F2F2">1</td>
              <td width="80" align="center" bgcolor="#F2F2F2">存款</td>
              <td width="120" align="center" bgcolor="#F2F2F2">1000（RMB）</td>
              <td width="160" align="center" bgcolor="#F2F2F2">2015-4-24 11:59</td>
              <td width="160" align="center" bgcolor="#F2F2F2">2015-4-24 11:59</td>
              <td width="70" align="center" bgcolor="#F2F2F2">已审核</td>
              <td width="60" align="center" bgcolor="#F2F2F2">----</td>
            </tr>--%>
              <tbody height="">
                <tr> 
                  <td colspan="7" align="center" style='color:#333;'><font color="#fff">请选择时间后点击查询</font></td>
                </tr>
                </tbody>
          </table>
        </div>
      <input type="hidden" id="acct_id"   runat="server" name="acct_id"/>
      </div>
    </div>
    <script>
        var tabs = function () {
            function tag(name, elem) {
                return (elem || document).getElementsByTagName(name);
            }
            //获得相应ID的元素
            function id(name) {
                return document.getElementById(name);
            }
            function first(elem) {
                elem = elem.firstChild;
                return elem && elem.nodeType == 1 ? elem : next(elem);
            }
            function next(elem) {
                do {
                    elem = elem.nextSibling;
                } while (
                    elem && elem.nodeType != 1
                )
                return elem;
            }
            return {
                set: function (elemId, tabId) {
                    var elem = tag("li", id(elemId));
                    var tabs = tag("div", id(tabId));
                    var listNum = elem.length;
                    var tabNum = tabs.length;
                    for (var i = 0; i < listNum; i++) {
                        elem[i].onclick = (function (i) {
                            return function () {
                                for (var j = 0; j < tabNum; j++) {
                                    if (i == j) {
                                        tabs[j].style.display = "block";
                                        //alert(elem[j].firstChild);
                                        elem[j].firstChild.className = "selected2";
                                    }
                                    else {
                                        tabs[j].style.display = "none";
                                        elem[j].firstChild.className = "";
                                    }
                                }
                            }
                        })(i)
                    }
                }
            }
        }();
        tabs.set("nav4", "menu_con");//执行



</script> 
           </div>
       
    </div>
    
    <div class="footer">
        <div class="footer-text"><img src="images/bg.jpg" alt="" /></div>
    </div>
    <div class="footer11">
        <div class="footer_column">
            <div class="column01">
                <div class="info_title01">信息</div>
                    <div class="line"></div>
                    <p>
                        <span> 注册</span>
                        点击立即开户即可享受所有的精彩游戏，更有机会获取高达100%的开户红利，最高可送￥18,888。
                    </p>
                    <p>
                        <span>协议条款</span>
                        我们提供最优秀的真人视讯平台，拥有正规牌照，并设置相关安全设施，确保游戏的公平。
                    </p>
                    <p>
                        <span>游客参观</span>
                        游戏平台全面开放，让您无需注册也可以一饱眼福。联系在线客服索要试玩账号
                    </p>
                </div>
                <div class="column02">
                    <div class="info_title02">产品</div>
                    <div class="line"></div>
                    <p>
                        <span> 现场娱乐</span>
                        我们强力首推，您可饱览整个游戏大厅和靓丽的SUNGIRL荷官。玩法众多,花样百变，赶快注册属于自己的账号吧！
                    </p>
                    <p>
                        <span>电子游戏</span>
                        我们拥有多种精彩电子游艺种类，画质精美，运行流畅，使您最大限度的拥有完美游戏体验
                    </p>
                    <p>
                        <span>体育竞技</span>
                        我们为您提供最专业的体育平台。每天多达300多场体育赛事，足球、篮球、网球等应有尽有，玩家可尽情享受体育投注乐趣。
                    </p>
                </div>
                <div class="column03">
                    <div class="info_title03">星级服务</div>
                    <div class="line"></div>
                    <p>
                        <span>联系我们</span>
                        如果您有任何关于游戏或者是娱乐场方面的疑问，您随时可通过在线客服、QQ客服或者电话客服获取帮助。
                    </p>
                    <p>
                        <span>优质服务承诺</span>
                        自成立至今，我们致力提供多元化的体育竞技及网上娱乐，让客户能每天24小时体验到最精采刺激的休闲享受，更藉以丰富奖赏，以回馈所有大众对我们的支持及热烈参与
                    </p>
                    <p>
                        <span>快速存取款</span>
                        我们提供各种安全简便的存款及提款选择给客户。我们希望所有的客户能够在一个安全愉快的环境中，享受本公司精心设计的产品和服务，并能够从中获利。我们欢迎如有需要，请通过电子邮件方式将相关讯息发送至电子邮箱：9790181@qq.com 我们将认真听取客户对我们提出的任何意见。
                    </p>

            </div>
            <div class="clear"></div>
        </div>
    </div>
    <div id="dialog4" title="温馨提示：">
        <br/><br/>
        <p style=" text-align:center"><span style=" font-size:13px; color:red; text-align:center" id="TipData"></span></p>

    </div>  
     <!--客服弹出框-->
    <div class="kefuBox" id="kefuBox" style="right: -190px;">
        <div class="kefu_left">
            <a href="javascript:void(0);"><img style="border:0;height: 293px" alt="" src="images/kefu_on.gif" /></a>
        </div>
        <div class="kefu_right">
            <div class="kefu_top">
                <a target="_blank" href="transfers1.aspx"><img style="border: 0; margin-left: -22px;margin-top:11px " alt="" src="images/chongzhi_on.png" /></a>
            </div>
            <div class="kefu_bot">
                <a onclick="openwin()" href="javascript:void(0);"><img style="border: 0; margin-left:-22px; margin-top:5px  " alt="" src="images/zaixian_on.png" /></a>
            </div>
            <div class="kefu_bot">
                <a target="_blank" href="http://wpa.qq.com/msgrd?v=3&amp;uin=9790181&amp;site=qq&amp;menu=yes"><img style="border: 0; margin-left: -22px; margin-top:5px " alt="" src="images/chongzhi_on2.png" /></a>
            </div>
            <div class="kefu_bot">
                <a target="_blank" href="http://wpa.qq.com/msgrd?v=3&amp;uin=9790581&amp;site=qq&amp;menu=yes"><img style="border: 0; margin-left:-22px; margin-top:5px " alt="" src="images/chongzhi_on3.png" /></a>
            </div>
            <div class="kefu_bot">
                <a href="javascript:void(0);"><img style="border: 0; margin-left: -22px; margin-top:11px" alt="" src="images/chongzhi_on4.png" /></a>
            </div>
        </div>
    </div>
   <script type="text/javascript" src="/portal_asset/js/libs/tgp.js?clientId=a8hHfj3ckdk4Djfi&t=20140930173901"></script>
    <script type="text/javascript" src="/portal_asset/js/libs/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="/portal_asset/js/libs/i18next-1.7.3.js"></script>
    <script type="text/javascript" src="/portal_asset/js/libs/jquery.jscrollpane.min.js"></script>
    <script type="text/javascript" src="/portal_asset/js/libs/jquery.mousewheel.js"></script>
    <script type="text/javascript" src="/portal_asset/js/libs/angular.js"></script>
    <script type="text/javascript" src="/portal_asset/js/libs/angular-route.js"></script>
    <script type="text/javascript" src="/portal_asset/js/libs/angular-cookies.js"></script>
    <script src="/portal_asset/js/libs/jquery.cookie.js" type="text/javascript"></script>
     <script src="portal_asset/js/jQueryCommon.min.js?t=201505161111111111111"></script>
    
    <script src="js/util.js"></script>
    <!-- Live800默认跟踪代码: 开始-->
    <script language="javascript" src="http://kf1.learnsaas.com/chat/chatClient/monitor.js?jid=1206637488&companyID=493978&configID=53063&codeType=custom"></script>
    <!-- Live800默认跟踪代码: 结束-->
    <script language="javascript" type="text/javascript" src="http://js.users.51.la/17747998.js"></script>
    <script type="text/javascript">
        function nTabs(thisObj, Num) {
            if (thisObj.className == "active") return;
            var tabList = document.getElementById("myTab").getElementsByTagName("li");
            for (i = 0; i < tabList.length; i++) {//点击之后，其他tab变成灰色，内容隐藏，只有点击的tab和内容有属性
                if (i == Num) {
                    thisObj.className = "active";
                    document.getElementById("myTab_Content" + i).style.display = "block";

                } else {
                    tabList[i].className = "normal";
                    document.getElementById("myTab_Content" + i).style.display = "none";

                }
            }
            if (Num == 0) {
                getDepositHistory("1", $("#time1WhereVal").val(), $("#time2WhereVal").val(), "#tab1>tbody");       //待处理 
            } else if (Num == 1) {
                getDepositHistory("2", $("#time3WhereVal").val(), $("#time4WhereVal").val(), "#tab2>tbody");       //待处理 
            } else if (Num == 2) {
                getDepositHistory("3", $("#time5WhereVal").val(), $("#time6WhereVal").val(), "#tab3>tbody");       //待处理 
            } else if (Num == 3) {
                getDepositHistory("4", $("#time7WhereVal").val(), $("#time8WhereVal").val(), "#tab4>tbody");       //待处理 
            }
        }

        

        function Mothrs(nums) {
            var isture;
            switch (nums) {
                case "1":
                    isture = "存款";
                    break;
                case "2":
                    isture = "取款";
                    break;
                case "3":
                    isture = "红利";
                    break;
                case "4":
                    isture = "返水";
                    break;
            }
            return isture;
        }

        function getDepositHistory(num, time1, time2, tab, acct_login, acct_id) {
            //debugger
           // $("#tab1>tbody").html("");
            $.AjaxCommon({
                url: "/ServiceFile/BankService.asmx/GetBillNotice", datas: "type:'" + num + "',time1:'" + time1 + "',time2:'" + time2 + "',lan:'cn',acct_login:'" + acct_login + "',acct_id:" + acct_id, beforeSend: function () {
                    ShowTipDiv(0);
                },
                complete: function () {
                    HideTipDiv();
                },
                toSuccess: function (json) {
                    if (json.d != "") {
                        var html = "";
                        var re = jQuery.parseJSON(json.d);
                        //debugger
                        $.each(re, function (i) {
                            html += "<tr ><td align='center' bgcolor=\"#F2F2F2\" style='color:#333;'   height=\"30\">" + (i + 1) + "</td><td align='center' bgcolor=\"#F2F2F2\" style='color:#333;'>" + (Mothrs(re[i].c)) + "</td><td align='center' bgcolor=\"#F2F2F2\" style='color:#333;'>" + re[i].d + "</td><td align='center' bgcolor=\"#F2F2F2\" style='color:#333;'>" + re[i].e + "</td><td align='center' bgcolor=\"#F2F2F2\" style='color:#333;'>" + (re[i].f == "" ? "" : re[i].f) + "</td><td align='center' bgcolor=\"#F2F2F2\" style='color:#333;'>" + (re[i].g == "1" ? "未审核" : (re[i].g == "2" ? "审核成功" : "审核失败")) + "</td><td align='center' bgcolor=\"#F2F2F2\" style='color:#333;'>" + re[i].h + "</td></tr>";
                        });
                        $(tab).html(html);
                    } else {
                        $(tab).html("<tr><td colspan=\"7\" align='center' style='color:#333;' >暂无相关数据</td></tr>");
                    }
                }
            });
        }



        function getDepositHistory1(num, time1, time2, tab, acct_login, acct_id) {
            //$("#tab1>tbody").html("");
            $.AjaxCommon({
                url: "/ServiceFile/BankService.asmx/GetBillNoticeHistory", datas: "type:'" + num + "',time1:'" + time1 + "',time2:'" + time2 + "',lan:'cn',acct_login:'" + acct_login + "',acct_id:" + acct_id,
                beforeSend: function () {
                    ShowTipDiv(0);
                },
                complete: function () {
                    HideTipDiv();
                },
                toSuccess: function (json) {
                    if (json.d != "") {
                        var html = "";
                        var re = jQuery.parseJSON(json.d);
                        $.each(re, function (i) {
                            html += "<tr><td   align='center' style='color:#333;'  bgcolor='#F2F2F2'  height=\"30\">" + (i + 1) + "</td><td  style='color:#333;' align='center'  bgcolor='#F2F2F2' >" + (Mothrs(re[i].c)) + "</td><td   align='center' style='color:#333;'  bgcolor='#F2F2F2' >" + re[i].d + "</td><td   align='center' style='color:#333;'  bgcolor='#F2F2F2' >" + re[i].e + "</td><td   align='center' style='color:#333;'  bgcolor='#F2F2F2' >" + (re[i].f == "" ? "" : re[i].f) + "</td><td   align='center' style='color:#333;'  bgcolor='#F2F2F2' >" + (re[i].g == "1" ? "未审核" : (re[i].g == "2" ? "审核成功" : "审核失败")) + "</td><td   align='center' style='color:#333;'  bgcolor='#F2F2F2' >" + re[i].h + "&nbsp;" + re[i].mark + "</td></tr>";
                        });
                        $(tab).html(html);
                    } else {
                        $(tab).html("<tr><td colspan=\"7\" align='center' style='color:#333;' >暂无相关数据</td></tr>");
                    }
                }
            });
        }


        $(document).ready(function () {
            var ss = "", aa = "";
            if (name !== "" && name != "{}") {
                ss = JSON.parse(name);
                aa = JSON.parse(ss.tgpjs_oauth);

                console.log(aa.acct_login);
                console.log(aa.acct_id);
            } else {
                window.location.href = "index.html";
            }
           
            $('#acct_id').val(aa.acct_id);

            $("#selectByWhere4").click(function () {
                //alert("eee");
                var status = $("#status4").val();
                if (status == "1") {
                    getDepositHistory("4", $("#time7WhereVal").val(), $("#time8WhereVal").val(), "#tab4>tbody", aa.acct_login, aa.acct_id);       //待处理        
                } else {
                    getDepositHistory1("4", $("#time7WhereVal").val(), $("#time8WhereVal").val(), "#tab4>tbody", aa.acct_login, aa.acct_id);  //已处理过
                }

            });
            $("#selectByWhere3").click(function () {
                //alert("eee");
                var status = $("#status3").val();
                if (status == "1") {
                    getDepositHistory("3", $("#time5WhereVal").val(), $("#time6WhereVal").val(), "#tab3>tbody", aa.acct_login, aa.acct_id);       //待处理        
                } {
                    getDepositHistory1("3", $("#time5WhereVal").val(), $("#time6WhereVal").val(), "#tab3>tbody", aa.acct_login, aa.acct_id);  //已处理过
                }

            });

            $("#selectByWhere2").click(function () {
                //alert("eee");
                var status = $("#status2").val();
                if (status == "1") {
                    getDepositHistory("2", $("#time3WhereVal").val(), $("#time4WhereVal").val(), "#tab2>tbody", aa.acct_login, aa.acct_id);       //待处理        
                } {
                    getDepositHistory1("2", $("#time3WhereVal").val(), $("#time4WhereVal").val(), "#tab2>tbody", aa.acct_login, aa.acct_id);  //已处理过
                }

            });


            function CurentTime2() {
                var now = new Date();
                var year = now.getFullYear();       //年
                var month = now.getMonth() + 1;     //月
                var day = now.getDate();       //日


                var clock = year + "-";
                if (month < 10)
                    clock += "0";
                clock += month + "-";
                if (day < 10) {
                    clock += "0";
                }
                clock += day;
                return (clock);
            }

            $("#time1WhereVal,#time2WhereVal,#time3WhereVal,#time4WhereVal,#time5WhereVal,#time6WhereVal,#time7WhereVal,#time8WhereVal").datepicker({ minDate: -30, maxDate: "0D", dateFormat: "yy-mm-dd" });
            $("#time1WhereVal,#time2WhereVal,#time3WhereVal,#time4WhereVal,#time5WhereVal,#time6WhereVal,#time7WhereVal,#time8WhereVal").val(CurentTime2());

          
            getDepositHistory1("1", $("#time1WhereVal").val(), $("#time2WhereVal").val(), "#tab1>tbody", aa.acct_login,aa.acct_id);  //已处理过



            $("#selectByWhere").click(function () {
                //alert("eee");
                var status = $("#status").val();
                if (status == "1") {
                    getDepositHistory("1", $("#time1WhereVal").val(), $("#time2WhereVal").val(), "#tab1>tbody", aa.acct_login, aa.acct_id);       //待处理        
                } else {
                    getDepositHistory1("1", $("#time1WhereVal").val(), $("#time2WhereVal").val(), "#tab1>tbody", aa.acct_login, aa.acct_id);  //已处理过
                }

            });

        });


</script>
</body>

</html>
