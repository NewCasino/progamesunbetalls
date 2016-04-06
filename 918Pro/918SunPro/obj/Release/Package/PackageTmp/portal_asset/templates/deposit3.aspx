<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deposit3.aspx.cs" Inherits="_10sunGameLogin.portal_asset.templates.deposit3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <noscript><style type="text/css">body{display:none;}</style></noscript>
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
    <title></title>
    <meta name="keywords" content="">
    <meta name="description" content="本娱乐城是亚洲区规模最大,最受玩家欢迎的的互联网现场视频，官方网站至今深受客户的青睐，msc更是多元化娱乐代表">
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
<body id="HFT" onSelectStart="self.event.returnValue=false"  >
    <%--<div class="contentT">
         <div class="broadcast">
              <span aria-hidden="true" class="glyphicon glyphicon-bullhorn bullhorn"></span>
              <marquee scrolldelay="100" onmouseout="javascript:this.start()" onmouseover="javascript:this.stop()" class="bctext">
                  <span class="bctextspan">為確保您的資金安全，請務必每次存款之前與客服確認存款銀行賬號，謝謝合作！快速体验 参观账号：sun16801 / sun16802 / sun16803 统一密码：bbee5566  JACKPOT奖金领取通知：中奖用户必须提供中奖编号、会员账号、中奖金额等详细信息，核对无误后方可领取奖金。 维护通知;申博官网每周一北京时间09:00H-15:00H进行维护，维护期间无法游戏</span>
              </marquee>
          </div>
    </div>--%>
  
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
                	<li><a href="#/Withdrawals" style=" font-size:14px" >快速取款</a></li>
                    <li><a href="/suncity-77-1.html" style=" font-size:14px" >常见问题</a></li>
                    
                </ul>
        <div class="fwbz2">
     		<a href="javascript:cs();"><img width="208" src="/statics/images/suncity/live8007.jpg"></a>   
        </div>        
        <div class="fwbz2" style="margin-top:-5px;">
          
	        
        </div>                
    	</div>
    </div>
        
        </td>
        <td>
      <div class="regmain">
    	<div class="regtit">
        	<div class="regmb"><span>网银转账</span><a href="#">&nbsp;&nbsp;&nbsp;<%--<img onclick="video_regist=window.open('video/cunkuan.html', 'video_regist','height=783,width=1330');" src="statics/images/suncity/vedio_open.gif" style="cursor:pointer" />--%></a>
            	<div class="mbxdh">您的位置：<a href="index.html" >首页</a>&nbsp;>&nbsp;<a href="suncity-76-1.html">网银转账</a></div>
            </div>
        </div>
    	<!-- regtit -->
		<div class="regcont">
     		<div class="regbt">银行转账汇款</div>
            	<br />
            	<span class="left20">1.汇款前，请联系客服索取最新的收款银行信息，认真核对后再汇出款项。</span><br />
                <span class="left20">2.当您转账成功之后，您可以直接提交下列存款信息，彩金部门即刻为您添加额度。</span><br />
                <span class="left20">3.您也可以及时联系【在线客服】，提供您的详细存款信息，我们即刻为您人工办理。</span>
<div class="regbt regtop">汇款信息</div>
            	<br />        
<form action="http://www.77sunbet.com/index.php?m=content&amp;c=index&amp;a=leave_deposit" enctype="multipart/form-data" method="post" onSubmit="return checkinput()">
<input type="hidden" name="action" value="post" />
<input type="hidden" name="diyid" value="2" />
<input type="hidden" name="check" value="1" />
<input type="hidden" id="bank_name" name="bank_name" value="工商银行" />
<input type="hidden" id="province" name="province" value="" />
<input type="hidden" id="city" name="city" value="" />
<input type="hidden" id="area" name="area" value="" />
<table width="701" style="margin-left:-40px; margin-top:15px;" border="0" cellspacing="5" cellpadding="5">

<tr>
<td width="211" height="34" align="right">游戏账号：</td>
<td width="452"> <input name="lyxzh" id="gameAccount" type="text" class="text text_width_200" onkeyup="value=value.replace(/[^_A-Za-z0-9]+/,'')"  /><span style="color:#999; " id="lyxzh_check"></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a style=" color:#999;">* 请输入您的游戏账号</a></td>
</tr>
<tr>
<td height="34" align="right">存款金额：</td> 
<td> <input type="text" class="text text_width_200" name="ckje" id="Amount" onKeyUp="value=value.replace(/[^0123456789.]/g,'')" /><span style="color:#999; width:200px; " id="ckje_check"></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a style=" color:#999;">* 请输入实际存款金额（如：8888.8）</a></td>
</tr>

             
<tr>
<td width="211" height="34" align="right">存入银行：</td>
<td>&nbsp;<select name="hyzhm" id="bankcode"  class="text2" style="background:#1b1b1b; width:206px; height:31px; border:1px solid #353535;">
            <OPTION value='0'>工商银行</OPTION><OPTION value='1'>农业银行</OPTION><OPTION value='2'>建设银行</OPTION>     </select>
	&nbsp;&nbsp;&nbsp;<a style=" color:#999;">* 请选择银行类型及户名</a> 
</td>
<td width="4"> </td>
</tr>
<%--<tr>
<td height="34" align="right">收款人姓名：</td> 
<td> <input type="text" class="text text_width_200" name="member_name" id="member_name" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a style=" color:#999;">* 请输入转银行人姓名</a></td>
</tr>--%>

<tr>
<td height="34" align="right">存款方式：</td>
<td> <select name="ckfs" id="ckfs" class="text2" style="background:#1b1b1b; width:206px; height:31px; border:1px solid #353535;">
	<option value="网银转帐1">网银转帐</option>
	<option value="ATM机现金存款">ATM机现金存款</option>
	<option value="跨行转账">跨行转账</option>
	<option value="ATM机银行卡存款">ATM机银行卡存款</option>
	<option value="手机转账">手机转账</option>
</select>&nbsp;&nbsp;&nbsp;<a style=" color:#999;">* 请选择您的存款方式</a> 
</td>
<td> </td>
</tr>
<tr>
<td height="34" align="right">优惠内容：</td> 
<td>&nbsp;<select  class="text2" name="give_content" style="background:#1b1b1b; width:206px; height:31px; border:1px solid #353535;" id="yhhd">
     <option value="无优惠">不申请优惠</option>
	  <OPTION value='50%首存,20倍流水'>50%首存,20倍流水</OPTION><OPTION value='30%二存,15倍流水'>30%二存,15倍流水</OPTION><OPTION value='2%银行手续返还'>2%银行手续返还</OPTION><OPTION value='元旦狂欢赠送30%'>元旦狂欢赠送30%</OPTION></select>&nbsp;&nbsp;&nbsp;<a style=" color:#999;">* 请选择您需要的优惠</a> </td>
</tr>
<%--<tr>
<td height="34" align="right">其它备注：</td>
<td> <input type="text" class="text text_width_200" name="comment" id="comment" /> &nbsp;&nbsp;&nbsp;<a style=" color:#999;">可不填写</a></td>

</tr>--%>
<tr>
<td height="34" align="right"> </td>
</tr>
<tr>
<td height="66" colspan="3" align="left"><table width="696" height="36" border="0" cellpadding="0" cellspacing="0">
<tr>
<td width="237"> </td>
<td width="227"><input type="button" class="tijiao_button" value="" id="J-submit" />&nbsp;&nbsp;&nbsp;<input type="reset" class="reset_button" value=""></td>
<td width="232"> </td>
</tr>
<tr>
<td height="10"> </td>
<td> </td>
<td> </td>
</tr>
<tr>
<td colspan="3">
</td>
</tr>
</table></td>
</tr>
</table>
</form>
<div class="regbt">银行转账汇款</div>
<br />
<span class="left20">1.如果您存款成功并且已经填写存款表单，10分钟内未查询到您的额度，请您点击上面“在线咨询”，联系我们</span><br /><br /><br /><br /><br /><br />
 </div>
        <!-- regCont -->
    </div>
        </td>
        
        </tr>
    </table>
   
    <!-- regmain -->
</div>
<div id="dialog2" title="温馨提示：">
</br></br>
<p style=" text-align:center"><span style=" font-size:13px; color:red; text-align:center" id="TipData"></span></p>
    
</div>  
<div id="dialog3" title="温馨提示：">
</br>    
    <p><span style=" font-size:12px;">&nbsp;游戏帐号：</span><span id="gameNO" style=" font-size:13px;"></span></p>
    <p><span style=" font-size:12px;">&nbsp;存款金额：</span><span id="gameMon" style=" font-size:13px;"></span></p></br>
    <p ><span style=" font-size:12px;color:red; ">充值成功填写完申请后，请联系客服。登入会员中心可时时查询到账状态</span></p>
    
</div>  

    <div id="dialog4" title="温馨提示：">
</br></br>
<p style=" text-align:center"><span style=" font-size:13px; color:red; text-align:center" id="TipData2"></span></p>
    
</div>  
</body>

</html>


