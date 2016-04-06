<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="transfers1.aspx.cs" Inherits="_918SunPro.transfers1" %>

<!DOCTYPE html>
  <html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
      <meta charset="utf-8" />
      <meta name="description" content="" />
      <meta name="viewport" content="width=device-width, initial-scale=1" />
      <title>618官方娱乐（618shenbo.com）_现场娱乐_电子游艺_体育竞技 在线支付</title>
      <link rel="icon" href="/images/favicon.ico" type="image/x-icon" />
      <link type="text/css" rel="stylesheet" media="all" href="index.css" />
      <link type="text/css" rel="stylesheet" href="css/zuce.css" />
      <link rel="stylesheet" type="text/css" href="/portal_asset/css/style.css?t=20150930164800" />
      <link rel="stylesheet" type="text/css" href="/portal_asset/css/page/slider.css?t=20150929141600" />
      <link rel="stylesheet" type="text/css" href="/portal_asset/css/module/jquery.jscrollpane.css?t=20150929141600" />
      <link href="portal_asset/css/jquery-ui.css" rel="stylesheet" />

    </head>
    <body>
      <div xmlns:my="ignored" id="ng-app" ng-app="ctrlApp">
        <div class="nav">
          <div class="nav_small">
            <ul style="float:left">
              <li>
                <a href="help.html">常见问题</a>
              </li>
              <li>
                <span>&nbsp;|</span>
                <a href="freePay.html">&nbsp;免费参观</a>
              </li>
              <li>
                <span>&nbsp;|</span>
                <a href="about.html">&nbsp;关于我们</a>
              </li>
              <!--<li><a href="">手机投注<span>|</span></a></li>-->
              <li>
                <span>&nbsp;|</span>
                <a href="zhaopai.html">&nbsp;牌照展示</a>
              </li>
              <li>
                <span>&nbsp;|&nbsp;</span>
                <a my-checklogin="" href="javascript:void(0)" class="over" ng-if="status.isLoaded" href-link="#" is-check-login="true" lobby-type="live" target="_blank" action-text="banners.liveGame.btn_text_login" login-text="banners.liveGame.btn_text">登陆游戏</a>
              </li>

            </ul>

            <ul style="float:right">

              <li class="userInfo left" ng-show="isAuthorized">
                <div>

                  <p class="userInfo left white">
                    欢迎您：{{username}} &nbsp;&nbsp;<a href="memberCenter.aspx">【会员中心】</a> &nbsp;&nbsp;
                  </p>
                  <div class="clearFix"></div>
                </div>
              </li>


              <li class="LS-service" ng-show="isAuthorized" ng-click="tgpLogout(true)">
                <span style=" font-weight: 800; font-size: 14px; color: #3B240B;">【</span>
                <a href="" class="over" id="tgpLogout" data-i18n="button.logout" style=" font-weight: 800; font-size: 14px; color: #3B240B;"></a>
                <span style=" font-weight: 800; font-size: 14px; color: #3B240B;">】</span>
                </>
              </li>
              <!--<li><a href="">会员中心<span>|</span></a></li>-->

              <li>
                <a id="pro_setup" href="http://www.11psb.com/air/air-bin/SunbetGameSetup3.4.0.exe">&nbsp;客户端下载</a>
              </li>
              <li>
                <span>&nbsp;|</span>
                <a href="appGame.html" target="_blank">&nbsp;手机APP版</a>
              </li>
              <li>
                <div ng-hide="isAuthorized">
                  <span>&nbsp;|</span>
                  <a href="#" onclick="AddFavorite(window.location,document.title)">&nbsp;&nbsp;加入收藏</a>
                </div>
              </li>

              <li>
                <div ng-hide="isAuthorized">
                  <span>&nbsp;|</span>
                  <a href="javascript:void(0)" onclick="SetHome(this,window.location)">&nbsp;&nbsp;设为首页</a>
                </div>
              </li>
            </ul>
            <div class="yuan"></div>
          </div>
        </div>

        <div class="nav_bottm">
          <div class="logo">
            <a href="">
              <img src="images/logo.png" alt="" />
            </a>
          </div>
          <div class="kaitong">
            <a href="register.html">
              <img src="images/logo_icon_06.png" alt="" />
            </a>
          </div>

          <div class="login">
            <a my-checklogin="" id="sliderBtn" href="javascript:void(0)" class="over" ng-if="status.isLoaded" href-link="#" is-check-login="true" lobby-type="live" target="_blank" action-text="banners.liveGame.btn_text_login" login-text="banners.liveGame.btn_text"></a>
          </div>

          <div class="pelope">
            <a href="javascript:void(0);" onclick="openwin()">
              <img src="images/logo_icon_03.png" alt="" />
            </a>
          </div>
        </div>


        <div class="modal-overlay my-hidden" ng-show="isShowTnc">
          <div class="mask"></div>
          <div id="tncDetail" class="tnc-modal-detail">
            <div id="tncModal" class="modal-content">
              <div class="modal-title" data-i18n="login.userTnC"></div>
              <div class="clearfix"></div>
              <div id="tncContent" class="modal-inner-content">
                <div my-tnc="my-tnc"></div>
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



      <div class="content" style="height: 1033px">
        <div class="cent_nav">
          <ul>
            <li>
              <a href="index.html" class="a"></a>
            </li>
            <li>
              <a href="gameProject.html" class="b"></a>
            </li>
            <li>
              <a href="transfers.aspx" class="c"></a>
            </li>
            <li>
              <a href="promotion.html" class="d"></a>
            </li>
            <li>
              <a href="agent.html" class="f"></a>
            </li>
            <li>
              <a href="#" class="e11" ></a>
            </li>

          </ul>
        </div>
        <p class="tishi">
          <marquee behavior="scroll" scrolldelay="200" onmouseout="this.start()" onmouseover="this.stop()" id="demo2"></marquee>

        </p>
        <div class="money">
          <ul>
            <li>
              <a href="javascript:void(0)">
                <img src="images/text3_09.png" alt="">
              </a>
            </li>

            <li>
              <a href="javascript:void(0)">
                <img src="images/text2_07.png" alt="">
              </a>
            </li>
            <li>
              <a href="javascript:void(0)">
                <img src="images/text1_11.png" alt="" />
              </a>
            </li>
          </ul>
          <div class="zx_zhifu" style="display:block">
            <div class="zhifu_title" >
              *在线支付*
            </div>
            <div class="zhifu_input">

              <%-- -------------------------------------------------------http://pay.anhuitianyu.cn/Payment2.aspx在线支付开始http://paay.igou918.cn/YP/Payment2.aspx-------------------------------------------------------------%>
              <form target="_top" method="get" id="myform" name="payForm" autocomplete="Off" action="http://210.56.57.42:8080/Default.aspx" >


                <input name="order_no" id="order_nos" type="hidden" class="input" value="<%=BillNo%>" />

                  <input name="product_name" type="hidden" class="input" value="百事通娱乐在线" />


                <table>
                  <tr>
                    <td height="40" width="80">订单号:</td>
                    <td height="40">
                      <%= BillNo%>
                    </td>
                    <td height="40"></td>
                  </tr>
                  <tr>
                    <td height="40">游戏账号:</td>
                    <td height="40" width="160">
                      <input type="text" id="gameAccount"" name="gameAccount=""" value="" onkeyup="value="value.replace"(/[^_A-Za-z0-9]+/,'')" />
                    </td>
                    <td height="40"></td>
                  </tr>
                  <tr>
                    <td height="40">存款金额:</td>
                    <td height="40" width="80">
                      <input type="text" onkeyup="value=value.replace(/[^0123456789.]/g,'')" id="Amount" name="order_amount"  onkeyup="this.value=this.value.replace(/[^\d]/g,'');" maxlength="6" onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" />
                    </td>
                    <td height="40">
                      *最低存款金额100,单笔最高3000。</p>
                    </td>
                  </tr>
                  <tr>
                    <td height="40">优惠内容:</td>
                    <td height="40" width="80">
                      <select style="background: #6a0000; width: 260px; height: 31px; border: 1px solid #353535;font-size:13px; " class="text2" id="give_content1" name="give_content1">
                      <%--  <option value="无优惠" selected="">不申请优惠</option>
                        <option value="首存一重礼，赠送100%">首存一重礼，赠送100%</option>
                        <option value="首存二重礼，赠送50%">首存二重礼，赠送50%</option>
                        <option value="首存三重礼，赠送30%">首存三重礼，赠送30%</option>--%>
                        <%-- <option value="高额洗码1%周周返">2:高额洗码1%周周返</option>
                        <option value="保险礼金大回馈">3:保险礼金大回馈</option>--%>

                      </select>
                    </td>
                    <td height="40">*更多优惠详情请点击网站上方的“特别优惠”</td>
                  </tr>
                  <tr>
                    <td height="40">验证码:</td>
                    <td height="40" width="80">
                      <input type="text" autocomplete="off" maxlength="4" tabindex="4" id="yzm" />
                    </td>
                    <td height="40">
                      &nbsp;<img style="vertical-align: bottom; cursor: pointer;border:;height:25px;" id="imgCode" src="/ValiCode.aspx?type=0" />
                    </td>
                  </tr>
                </table>

                <div class="zhifu_sure">
                  <input type="button" style=" cursor: pointer;background: url('images/bgs_07.png') repeat-x scroll 0 0 rgba(0, 0, 0, 0); border-radius: 6px;height: 36px;border: medium none; width: 116px;" value="提交" id="J-submit">
                </div>

                <%--  <div class="zhifu_sure">
                  <input id="J-submit" value="在线支付维护中，请使用银行转账汇款！" style=" cursor: pointer;background: url('images/bgs_07.png') repeat-x scroll 0 0 rgba(0, 0, 0, 0); border-radius: 6px;height: 36px;border: medium none; width: 116px;">
                </div>-%>
              </form>

              <%-- -------------------------------------------------------在线支付结束-------------------------------------------------------------%>
            </div>
          </div>

        </div>
      </div>
      <div class="footer">
        <div class="footer-text">
          <img src="images/bg.jpg" alt="">
        </div>
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
      <div id="dialog2" title="温馨提示：" style=" display:none">
        </br>
        </br>
        <p style=" text-align:center">
          <span style=" font-size:13px; color:red; text-align:center" id="TipData"></span>
        </p>

      </div>
      <div id="dialog3" title="温馨提示：" style="  display:none">
        </br>
        <p>
          <span style=" font-size:12px;">&nbsp;&nbsp;&nbsp; 订单号：</span>
          <span id="isNO" style=" font-size:13px;"></span>
        </p>
        <p>
          <span style=" font-size:12px;">&nbsp;游戏帐号：</span>
          <span id="gameNO" style=" font-size:13px;"></span>
        </p>
        <p>
          <span style=" font-size:12px;">&nbsp;存款金额：</span>
          <span id="gameMon" style=" font-size:13px;"></span>
        </p>
        </br>
        <p >
          <span style=" font-size:12px;color:red; ">充值成功后 ，5－10分钟将自动到账。登入会员中心可时时查询到账状态</span>
        </p>

      </div>

      <div id="dialog4" title="温馨提示：">
        </br>
        </br>
        <p style=" text-align:center">
          <span style=" font-size:13px; color:red; text-align:center" id="TipData2"></span>
        </p>

      </div>
      <div id="dialog8" title="温馨提示：">
        </br>
        <p>
          <span style=" font-size:12px;">&nbsp;游戏帐号：</span>
          <span id="gameNO2" style=" font-size:13px;"></span>
        </p>
        <p>
          <span style=" font-size:12px;">&nbsp;存款金额：</span>
          <span id="gameMon2" style=" font-size:13px;"></span>
        </p>
        </br>
        <p >
          <span style=" font-size:12px;color:red; ">充值成功填写完申请后，请联系客服。登入会员中心可时时查询到账状态</span>
        </p>

      </div>
      <div id="dialog10" title="温馨提示：">
        <br/>
        <br/>
        <p style=" text-align:center">
          <span style=" font-size:13px; color:red; text-align:center" id="TipData10"></span>
        </p>

      </div>
      <div id="dialog11" title="温馨提示：">
        <br/>
        <br/>
        <p style=" text-align:center">
          <span style=" font-size:13px; color:red; text-align:center" id="TipData11"></span>
        </p>

      </div>
<div class="kefuBox33" id="" style="left: 20px; width: 133px; height: 150px; "><a style="color: #fbe7aa">+ 扫一扫 添加微信号</a> </div>
      <!--客服弹出框-->
      <div class="kefuBox" id="kefuBox" style="right: -190px;">
        <div class="kefu_left">
          <a href="javascript:void(0);">
            <img style="border:0;height: 293px" alt="" src="images/kefu_on.gif" />
          </a>
        </div>
        <div class="kefu_right">
          <div class="kefu_top">
            <a  href="#">
              <img style="border: 0; margin-left: -22px;margin-top:11px " alt="" src="images/chongzhi_on.png" />
            </a>
          </div>
          <div class="kefu_bot">
            <a onclick="openwin()" href="javascript:void(0);">
              <img style="border: 0; margin-left:-22px; margin-top:5px  " alt="" src="images/zaixian_on.png" />
            </a>
          </div>
          <div class="kefu_bot">
            <a target="_blank" href="http://wpa.qq.com/msgrd?v=3&amp;uin=9790181&amp;site=qq&amp;menu=yes">
              <img style="border: 0; margin-left: -22px; margin-top:5px " alt="" src="images/chongzhi_on2.png" />
            </a>
          </div>
          <div class="kefu_bot">
            <a target="_blank" href="http://wpa.qq.com/msgrd?v=3&amp;uin=9790581&amp;site=qq&amp;menu=yes">
              <img style="border: 0; margin-left:-22px; margin-top:5px " alt="" src="images/chongzhi_on3.png" />
            </a>
          </div>
          <div class="kefu_bot">
            <a href="javascript:void(0);">
              <img style="border: 0; margin-left: -22px; margin-top:11px" alt="" src="images/chongzhi_on4.png" />
            </a>
          </div>
        </div>
      </div>

      <script src="js/618sun/transfers1.js"></script>
      <script src="js/util.js"></script>
      <!-- Live800默认跟踪代码: 开始-->
      <script language="javascript" src="http://kf1.learnsaas.com/chat/chatClient/monitor.js?jid=1206637488&companyID=493978&configID=53063&codeType=custom"></script>
      <!-- Live800默认跟踪代码: 结束-->
      <script language="javascript" type="text/javascript" src="http://js.users.51.la/17747998.js"></script>

    </body>
  </html>

