<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="transfers.aspx.cs" Inherits="_918SunPro.transfers" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <meta charset="utf-8" />
        <meta name="description" content="" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <title>存款提款</title>
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

                    <li><a href="http://www.11psb.com/air/air-bin/Sunbe.tGameSetup3.3.4.exe">&nbsp;客户端下载</a></li>
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



         <div class="content" style="height: 1033px">
        		<div class="cent_nav">
      				 <ul>
                        <li><a href="index.html" class="a"></a></li>
                        <li><a href="gameProject.html" class="b"></a></li>
                        <li><a href="transfers.aspx" class="c11"></a></li>
                        <li><a href="promotion.html" class="d"></a></li>
                        <li><a href="agent.html" class="f"></a></li>
                        <li><a href="transfers1.aspx" class="e" target="_blank"></a></li>

                    </ul>
        		</div>
        		<p class="tishi"> 
                      <marquee behavior="scroll" scrolldelay="200" onmouseout="this.start()" onmouseover="this.stop()" id="demo2"></marquee>

        		</p>
        		<div class="money">
					<ul>
						<li><a href="javascript:void(0)"><img src="images/text3_09.png" alt=""></a></li>
						
						<li><a href="javascript:void(0)"><img src="images/text2_07.png" alt=""></a></li>
                        <li><a href="javascript:void(0)"><img src="images/text1_11.png" alt="" /></a></li>
					</ul>
			    <div class="zx_zhifu" style="display:block">
				   <%-- -------------------------------------------------------银行转汇开始-------------------------------------------------------------%>
					<form  autocomplete="Off" enctype="multipart/form-data" method="post">
						<div class="zhifu_title">
							•银行汇款•
						</div>
						<div class="zhifu_input ">
						<img src="images/bank_07.png" alt="">
						<div action="">
							<table>
								
								<tr>
									<td  height="40">游戏账号:</td>
									<td  height="40" width="160"><input type="text"  id="gameAccount2" type="text"  onkeyup="value=value.replace(/[^_A-Za-z0-9]+/,'')"/></td>
									<td  height="40"></td>
								</tr>
								<tr>
									<td  height="40">存款金额:</td>
									<td  height="40" width="80"><input type="text"  id="Amount2" onKeyUp="value=value.replace(/[^0123456789.]/g,'')"/></td>
									<td  height="40">最低存款金额100,单笔最高50000.</p></td>
								</tr>	
								<tr>
									<td  height="40">银行名称:</td>
									<td  height="40" width="80">
                                        <select name="hyzhm" id="bankcode2"  class="text2" style="background: #6a0000; width: 260px; height: 31px; border: 1px solid #353535;font-size:13px; ">
                                                    <OPTION value='0'>工商银行</OPTION><OPTION value='1'>农业银行</OPTION><OPTION value='2'>建设银行</OPTION>  <OPTION value='3'>招商银行</OPTION>  <OPTION value='4'>支付宝</OPTION><OPTION value='5'>微信红包</OPTION>

                                        </select></td>
									<td  height="40">请联系在线客服,索要最新收款账号</p></td>
								</tr>	
                                <tr>
									<td  height="40">存款方式:</td>
									<td  height="40" width="80">
                                        <select name="ckfs" id="ckfs2" class="text2" style="background: #6a0000; width: 260px; height: 31px; border: 1px solid #353535;font-size:13px; ">
	                                        <option value="网银转帐1">网银转帐</option>
	                                        <option value="ATM机现金存款">ATM机现金存款</option>
	                                        <option value="跨行转账">跨行转账</option>
	                                        <option value="ATM机银行卡存款">ATM机银行卡存款</option>
	                                        <option value="手机转账">手机转账</option>
                                        </select>
									</td>
									<td  height="40">* 请选择您的存款方式.</p></td>
								</tr>	
                                <tr>
									<td  height="40">优惠内容：</td>
									<td  height="40" width="80">
                                        <select  class="text2" name="give_content" style="background: #6a0000; width: 260px; height: 31px; border: 1px solid #353535;font-size:13px; " id="yhhd2">
                                            <%-- <option value="无优惠">不申请优惠</option>
                                                <option value="首存一重礼，赠送100%">首存一重礼，赠送100%</option>
                                                <option value="首存二重礼，赠送50%">首存二重礼，赠送50%</option>
                                                <option value="首存三重礼，赠送30%">首存三重礼，赠送30%</option>--%>
                                          
                                        </select>
									</td>
									<td  height="40">更多优惠详情请点击网站上方的“特别优惠”按钮</td>
								</tr>																						
							</table>
							<div class="zhifu_sure huikuan_sure"><input id="J-submit2"   type="button" value="提交" style=" cursor: pointer;background: url('images/bgs_07.png') repeat-x scroll 0 0 rgba(0, 0, 0, 0); border-radius: 6px;height: 36px;border: medium none; width: 116px;"></div>
						</div>
						</div>
						</form>
                </div>
                    <%-- -------------------------------------------------------银行转汇结束-------------------------------------------------------------%>
                    <div class="zx_zhifu">
                        <div class="zhifu_title">
                            *申请提款*
                        </div>
                        <div class="zhifu_input ">
                     <%-- -------------------------------------------------------申请提款开始-------------------------------------------------------------%>
                            <form autoComplete="Off"  enctype="multipart/form-data" method="post" >
                                <table>
                                    <tr>
                                        <td height="40" width="80">提款金额:</td>
                                        <td height="40" width="160"><input type="text" id="price4" onkeyup="value=value.replace(/[^0123456789]/g,'')"   value="100" maxlength="20"/></td>
                                        <td height="40">*提款金额(大于100人民币)</td>
                                    </tr>
                                    <tr>
                                        <td height="40">提款会员:</td>
                                        <td height="40" width="160"><input type="text" id="username4"  onkeyup="value=value.replace(/[^_A-Za-z0-9]+/,'')" maxlength="20"/></td>
                                        <td height="40">*填写您开户时填写的账号</td>
                                    </tr>
                                    <tr>
                                        <td height="40">提款密码:</td>
                                        <td height="40" width="80"><input type="password" id="moneypassword4" onkeyup="value=value.replace(/[^0123456789.]/g,'')" maxlength="4"/></td>
                                        <td height="40">*填写您开户时填写的提款密码</p></td>
                                    </tr>
                                    <tr>
                                        <td height="40">开户银行:</td>
                                        <td height="40" width="80">
                                            <select id="bankcode4" style="background: #6a0000; width: 260px; height: 31px; border: 1px solid #353535;font-size:13px; ">
                                                 <option value="其它银行">其它银行</option>
								                <option value="农业银行">农业银行</option>
								                <option value="交通银行">交通银行</option>
								                <option value="建设银行">建设银行</option>
								                <option value="兴业银行">兴业银行</option>
								                <option value="招商银行">招商银行</option>
								                <option value="广州银行">广州银行</option>
								                <option selected="" value="工商银行">工商银行</option>
								                <option value="广发银行">广发银行</option>
								                <option value="中信银行">中信银行</option>
								                <option value="民生银行">民生银行</option>
								                <option value="平安银行">平安银行</option>								
								                <option value="中国银行">中国银行</option>
                                            </select></td>
                                        <td height="40">*选择您要提款的银行，如没有您要选的银行，请选其它银行后联系客服。</p></td>
                                    </tr>
                                    <tr>
                                        <td height="40">银行户名:</td>
                                        <td height="40" width="80"><input id="khname4" type="text" max="20" value="" name="khname"/></td>
                                        <td height="40">*填写银行帐户名.</p></td>
                                    </tr>
                                    <tr>
                                        <td height="40">银行账号:</td>
                                        <td height="40" width="80"><input  id="yhzh4" type="text" maxlength="50" value="" name="yhzh"  /></td>
                                        <td height="40"><span style="color:red">注：</span>填写好，提款会员，提款密码，银行户名，银行账号填好后，可绑定相关银行卡信息，点击<input type="button" id="btn-dataInfo" style="  cursor: pointer;background: url('images/bgs_07.png') repeat-x scroll 0 0 rgba(0, 0, 0, 0); border-radius: 6px;height: 25px;border: medium none; width: 60px;margin-top:-10px"  value="绑定"/></p></td>
                                    </tr>
                                    <tr>
                                        <td height="40">验证码:</td>
                                        <td height="40"><input type="text"  style="vertical-align: bottom; cursor: pointer;" name="yz" id="yzm4" maxlength="4"/></td> 
                                        <td height="40"><img src="/ValiCode.aspx?type=1"  id="imgCode3" style="vertical-align: bottom; cursor: pointer;border:;height:25px;"></p></td>
                                    </tr>

                                </table>
                                <div class="zy_shixiang">
                                    <span class="zy_shixiang_sp">【注意事项】</span><ul class="zy_ul">
                                        <li>1.填写金额请写整数，最低100RMB起，无封顶；</li>
                                        <li>2.账号填写您开户时的账号；</li>
                                        <li>3.请认真填写银行详细信息以便我们给您及时审核；</li>
                                    </ul>
                                    <div class="clear"></div>
                                </div>
                                <div class="clear"></div>
                                <div class="zhifu_sure zy_button">
                                    <input id="btn-qk"   type="button" value="提交" style=" cursor: pointer;background: url('images/bgs_07.png') repeat-x scroll 0 0 rgba(0, 0, 0, 0); border-radius: 6px;height: 36px;border: medium none; width: 116px;margin-top:-10px">
                                   </div>
                            </form>
                      <%-- -------------------------------------------------------申请提款结束-------------------------------------------------------------%>
                        </div>
                    </div>
        		</div>
		</div>
	<div class="footer">
        <div class="footer-text"><img src="images/bg.jpg" alt=""></div>
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
    </br></br>
    <p style=" text-align:center"><span style=" font-size:13px; color:red; text-align:center" id="TipData"></span></p>
    
    </div>  
    <div id="dialog3" title="温馨提示：" style="  display:none">
    </br>
     <p><span style=" font-size:12px;">&nbsp;&nbsp;&nbsp; 订单号：</span><span id="isNO" style=" font-size:13px;"></span></p>
     <p><span style=" font-size:12px;">&nbsp;游戏帐号：</span><span id="gameNO" style=" font-size:13px;"></span></p>
     <p><span style=" font-size:12px;">&nbsp;存款金额：</span><span id="gameMon" style=" font-size:13px;"></span></p></br>
     <p ><span style=" font-size:12px;color:red; ">充值成功后 ，5－10分钟将自动到账。登入会员中心可时时查询到账状态</span></p>
    
    </div> 

    <div id="dialog4" title="温馨提示：">
        </br></br>
        <p style=" text-align:center"><span style=" font-size:13px; color:red; text-align:center" id="TipData2"></span></p>
    
    </div>  
    <div id="dialog8" title="温馨提示：">
    </br>    
        <p><span style=" font-size:12px;">&nbsp;游戏帐号：</span><span id="gameNO2" style=" font-size:13px;"></span></p>
        <p><span style=" font-size:12px;">&nbsp;存款金额：</span><span id="gameMon2" style=" font-size:13px;"></span></p></br>
        <p ><span style=" font-size:12px;color:red; ">充值成功填写完申请后，请联系客服。登入会员中心可时时查询到账状态</span></p>
    
    </div>  
<div id="dialog10" title="温馨提示：">
<br/><br/>
<p style=" text-align:center"><span style=" font-size:13px; color:red; text-align:center" id="TipData10"></span></p>
    
</div>  
<div id="dialog11" title="温馨提示：">
<br/><br/>
<p style=" text-align:center"><span style=" font-size:13px; color:red; text-align:center" id="TipData11"></span></p>
    
</div>  
<div class="kefuBox33" id="" style="left: 20px; width: 133px; height: 150px; "><a style="color: #fbe7aa">+ 扫一扫 添加微信号</a> </div>
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

<script src="js/618sun/transfers.js"></script>
<script src="js/util.js"></script>
 <!-- Live800默认跟踪代码: 开始-->
 <script language="javascript" src="http://kf1.learnsaas.com/chat/chatClient/monitor.js?jid=1206637488&companyID=493978&configID=53063&codeType=custom"></script>
<!-- Live800默认跟踪代码: 结束-->
<script language="javascript" type="text/javascript" src="http://js.users.51.la/17747998.js"></script>

</body> 
</html>
