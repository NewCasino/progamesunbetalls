<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deposit2.aspx.cs" Inherits="_10sunGameLogin.portal_asset.templates.deposit2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <noscript><style type="text/css">body{display:none;}</style></noscript>
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
    <title>优惠活动 - 申博 77Sunbet</title>
    <meta name="keywords" content="sunbet,申博,申博娱乐,申博太阳城">
    <meta name="description" content="申博娱乐城是亚洲区规模最大,最受玩家欢迎的的互联网现场视频，官方网站至今深受客户的青睐，msc更是多元化娱乐代表">
    <link rel="stylesheet"  href="/statics/css/suncity/ttstyle.css" type="text/css"/>
  

    <!--[if lte IE 6]>
    <div style="width:100%; height:3500px; background:#000; color:#FF3; font-size:14px; text-align:center">
    <p>系统检测到您正在使用 Internet Explorer 6 本站不支持此浏览器，建议您升级以下浏览器</p><br /><br />
    <a href="http://down.360safe.com/se/360se_setup.exe" target="_blank">360浏览器 点击下载</a><br /><br />
    <a href="http://www.microsoft.com/china/windows/internet-explorer/" target="_blank">Internet Explorer 8</a> <br /><br />
    <a href="http://www.firefox.com.cn/">火狐Firefox</a><br /><br />
    <a href="http://dlsw.baidu.com/sw-search-sp/soft/9d/14744/ChromeStandaloneSetup.1409816011.exe">谷歌Chrome</a><br /><br />
    </div>
        <script src="/statics/js/suncity/DD_belatedPNG_0.0.8a.js" type="text/javascript"></script>
        <script type="text/javascript">
        DD_belatedPNG.fix('div,ul,img,background,li,input,a,.img-png-l,.img-png-l-up');
        </script>
    <![endif]-->

    


</head>
<body id="HFT" onSelectStart="self.event.returnValue=false" >
  
<div  >
 

    <table style=" border-collapse:clolapse;  width:870; float:center;margin:2px auto auto;">
        <tr>
        <td  style="vertical-align: top;">
         <div class="regleft">
    	 <div class="regcen" >
    		<div class="fwbz"></div>
    			<ul>
                	<li><a href="#/register" style=" font-size:14px" >免费开户</a></li>
                	<li><a href="#/deposit" style=" font-size:14px;background:url('/statics/images/suncity/leftmenubga.jpg')" >在线存款</a></li>
                	<li><a href="#/Withdrawals/" style=" font-size:14px" >快速取款</a></li>
                    <li><a href="/suncity-77-1.html" style=" font-size:14px" >常见问题</a></li>
                    
                </ul>
        <div class="fwbz2">
     		<a href="javascript:cs();"><img width="208" src="/statics/images/suncity/live8007.jpg"></a>   
        </div>        
        <div class="fwbz2" style="margin-top:-5px;">
            <a href="#">		
	        
        </div>                
    	</div>
    </div>
        
        </td>
        <td>
       	<div class="regmain">
    	<div class="regtit">
        	<div class="regmb"><span>在线支付</span>
            	<div class="mbxdh">您的位置：<a href="/">首页</a>&nbsp;&gt;&nbsp;<a href="javascript:void(0)">在线支付</a></div>
            </div>
        </div>
    	<!-- regtit -->
		<div class="regcont">
               

            <form target="_blank"   method="post" id="myform" name="payForm" autocomplete="Off" action="http://paay.igou918.cn/YP/Payment2.aspx">  
                <input name="OrderDesc" type="hidden" value="环球娱乐"/>
                <input name="Remark" type="hidden" value="环球娱乐"/>
                <input name="AdviceURL" type="hidden" value="<%=AdviceURL%>"/>
                <input name="ReturnURL" type="hidden" value="<%=ReturnURL%>"/>
                <input name="BillNo"  id="order_nos" type="hidden" class="input" value="<%=BillNo%>"/>
                <input name="MerNo" type="hidden" class="input" value="<%=MerNo%>"/>
              <%-- <input name="Amount" type="hidden" class="input" value="<%=Amount%>"/>--%>
               
                <input name="defaultBankNumber" type="hidden" class="input" value="<%=defaultBankNumber%>"/>
                <input name="orderTime" type="hidden" class="input" value="<%=orderTime%>"/>
                <input type="hidden" name="products" value="<%=products%>"/> 
                <%--<div style="border-bottom:1px dotted #494949; width:100%; margin-bottom:10px; height:25px; line-height:25px;">支付银行</div>   
                <div id="bankBox">
	                <div class="division">
                      <ul>
                            <li> <input type="radio" value="ABC" name="bankcode"> <img title="农业银行" src="statics/images/banklogo/nongye.gif"></li>
                            <li> <input type="radio" value="ICBC" name="bankcode"> <img title="工商银行" src="statics/images/banklogo/gongshang.gif"></li>
                            <li> <input type="radio" value="CCB" name="bankcode"> <img title="建设银行" src="statics/images/banklogo/jianshe.gif"> </li>  
                            <li> <input type="radio" value="BOCSH" name="bankcode"> <img title="中国银行" src="statics/images/banklogo/zhongguo.gif"> </li>
                            <li> <input type="radio" value="CMBC" name="bankcode"> <img title="民生银行" src="statics/images/banklogo/minsheng.gif"> </li> 
                             <li> <input type="radio" value="PSBC" name="bankcode"> <img title="邮政储蓄" src="statics/images/banklogo/youzheng.gif"> </li>  
                       </ul>
                       <div style="clear:both; text-align:right; color:#ddcba5; padding-right:40px;" ><a href="javascript:void(0)" id="oneMore">更多&gt;&gt;</a></div>
                       <ul style="display:none;" id="moreBank">
       		               
                            <li> <input type="radio" value="CMB" name="bankcode"> <img title="招商银行" src="statics/images/banklogo/zhaoshang.gif"> </li> 
                            <li> <input type="radio" value="BOCOM" name="bankcode"> <img title="交通银行" src="statics/images/banklogo/jiaotong.gif"> </li> 
                            <li> <input type="radio" value="PAB" name="bankcode"> <img title="平安银行" src="statics/images/banklogo/pingan.gif"> </li> 
                            <li> <input type="radio" value="HXB" name="bankcode"> <img title="华夏银行" src="statics/images/banklogo/huaxia.gif"> </li>                           
                            
                           
                            <li> <input type="radio" value="SPDB" name="bankcode"> <img title="浦东发展银行" src="statics/images/banklogo/pufa.gif"> </li> 
                            <li> <input type="radio" value="CIB" name="bankcode"> <img title="兴业银行" src="statics/images/banklogo/xingye.gif"> </li>
                            
                            <li> <input type="radio" value="CNCB" name="bankcode"> <img title="中信银行" src="statics/images/banklogo/zhongxin.gif"></li>
	                   </ul>
                       <div style="clear:both; display:none; text-align:right; padding-right:40px;" id="twoMore"><a href="javascript:void(0)" >收起&gt;&gt;</a></div>
                       <div style="clear:both"></div> 
                   </div>
                </div> --%>
             
                <div style="border-bottom:1px dotted #494949; width:100%; margin-top:10px; height:25px; line-height:25px;">存款信息</div>
                <table cellspacing="2" cellpadding="0" border="0" width="100%" style=" margin-top:40px;">
                               <tbody>
                                <tr>
                                 <td align="right" height="12">&nbsp;</td>
                                 <td>&#12288;</td>
                                 <td width="281">&#12288;</td>
                              </tr>
                         <tr>
                                 <td width="247" height="34" align="right"><a style="color:#ddcba5; font-size:14px;">订单编号：</a></td>
                                 <td width="408" style="color:#666;">&nbsp;<%= BillNo%></td>
                
                 
                       </tr>
	                   <tr>
                                 <td align="right" width="546" height="40" style="color:#ddcba5; font-size:14px;">游戏帐号：</td>
                                 <td width="787">&nbsp;<input type="text" class="text text_width_200" id="gameAccount"" name="gameAccount" value="" onkeyup="value=value.replace(/[^_A-Za-z0-9]+/,'')">&nbsp;&nbsp;&nbsp;<%--<span id="yxzh_check" style="color:#CCC; ">温馨提示：账号是由"158"加您注册时的用户名"fa666"组成（如:158fa666)。</span>--%></td>
               
                               </tr>
                               <tr>
                                 <td align="right" height="40" style="color:#ddcba5; font-size:14px;">充值金额：</td>
                                 <td colspan="2">&nbsp;<input type="text" onkeyup="value=value.replace(/[^0123456789.]/g,'')" id="Amount" name="Amount"  onkeyup="this.value=this.value.replace(/[^\d]/g,'');" maxlength="6" onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" class="text text_width_200">&nbsp;&nbsp;&nbsp;<span id="money_check" style="color:#CCC; ">*最低存款金额100,单笔最高3000。</span></td>
                 
                               </tr>
			                   <tr>
			                   <td align="right" height="40" style="color:#ddcba5; font-size:14px;">优惠内容：</td>
					                <td>&nbsp;<select name="give_content1" class="text2" style="background:#1b1b1b; width:201px; height:31px; border:1px solid #353535;">
						                 <option value="无优惠">不申请优惠</option>
								                <option value="50%首存,20倍流水">50%首存,20倍流水</option><option value="30%二存,15倍流水">30%二存,15倍流水</option><option value="迎新春,存1000送300">迎新春,存1000送300</option><option value="迎新春,存3000送1000">迎新春,存3000送1000</option><option value="迎新春,存5000送2000">迎新春,存5000送2000</option><option value="迎新春,存10000送5000">迎新春,存10000送5000</option>						</select>
                                        &nbsp;&nbsp;&nbsp;<span id="money_check" style="color:#CCC; ">*请选择您参与的优惠活动。</span>
					                </td>
					                </tr>
				        
                               <tr>
                             <td align="right" height="40" style="color:#ddcba5; font-size:14px;">验证码：</td>
                                 <td>&nbsp;<input type="text" id="yzm" tabindex="4"   maxlength="4"  autocomplete="off"  style="vertical-align: bottom; cursor: pointer;" class="text text_width_200 text2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="/ValiCode.aspx?type=0"  id="imgCode" style="vertical-align: bottom; cursor: pointer;border:;height:25px;"></td> 
                               </tr>
               
                               <tr><td>&nbsp;</td></tr>
                               <tr>
                                 <td align="right" height="34">&#12288;</td>
                                 <td><input  id="J-submit" value="" class="tijiao_button">&nbsp;&nbsp;&nbsp;<input type="reset" value="" class="reset_button"></td>
                                 <td>&#12288;</td>
                               </tr>
                               <tr>
                                 <td align="left" height="66" colspan="3"></td>
                              </tr>
                            </tbody></table> 
                <div style="border-bottom:1px dotted #494949; width:100%; margin-top:10px; height:25px; line-height:25px;">温馨提示</div><br>
            	                <span class="left20">1.操作流程：点选银行-&gt;填写表单-&gt;进行网银充值-&gt;充值成功-&gt;登入游戏后可在会员中心查到状态。</span><br>
                                <span class="left20">2.支付成功但未到账，请及时联系【在线客服】为您补单处理。</span>   
                <br><br><br><br><br><br>                
                
                </form>
        </div>
        </td>
        
        </tr>
    </table>
   
    <!-- regmain -->
</div>
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
</body>

</html>


