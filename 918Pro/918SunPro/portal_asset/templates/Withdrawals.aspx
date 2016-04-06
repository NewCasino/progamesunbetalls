<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Withdrawals.aspx.cs" Inherits="_10sunGameLogin.portal_asset.templates.Withdrawals" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <noscript><style type="text/css">body{display:none;}</style></noscript>
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
    <title>提现 - 申博 77Sunbet</title>
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
                	<li><a href="#/deposit" style=" font-size:14px" >在线存款</a></li>
                	<li><a href="#/Withdrawals/" style=" font-size:14px;background:url('/statics/images/suncity/leftmenubga.jpg')" >快速取款</a></li>
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
        	<div class="regmb"><span>快速取款</span>
            	<div class="mbxdh">您的位置：<a href="/">首页</a>&nbsp;&gt;&nbsp;<a href="javascript:void(0)">快速取款</a></div>
            </div>
        </div>
    	<!-- regtit -->
		<div class="regcont">
            	  <form autoComplete="Off" action="" enctype="multipart/form-data" method="post" >
          <input type="hidden" name="action" value="post" />
          <input type="hidden" name="diyid" value="1" />
          <input type="hidden" name="do" value="2" />
          
        	<div class="regbt">提款说明</div>
            	<br />
            	<span class="left20">1.单次提款最低100元以上，无上限，参与规定限制优惠活动除外，申博承担所有手续费用</span><br />
                <span class="left20">2.取款默认划入注册时绑定的银行，如不确定或遗失需更改请联络客服核实变更</span>
        	<div class="regbt regtop">提款信息</div><br />
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
               <tr>
                 <td height="12" align="right">&nbsp;</td>
                 <td>　</td>
                 <td width="16">　</td>
              </tr>
               <tr>
                 <td width="647" height="34" align="right" style="color:#ddcba5; font-size:14px;">游戏账号：</td>
                 <td width="959">&nbsp;<input name="yxzh" type="text" class="text text_width_200" id="username"  onkeyup="value=value.replace(/[^_A-Za-z0-9]+/,'')" maxlength="20"/>&nbsp;&nbsp;<span style=" color:#ccc;" id="yxzh_check"></span><a style=" color:#999;">* 请输入您的游戏账号</a></td>
               </tr>
               <tr>
                 <td height="34" align="right"  style="color:#ddcba5; font-size:14px;">提款金额：</td>
                 <td>&nbsp;<input type="text" class="text text_width_200" name="tkje" id="price" onkeyup="value=value.replace(/[^0123456789.]/g,'')"   value="100" maxlength="20"/>&nbsp;&nbsp;<span style="color:#ccc;" id="tkje_check"></span><a style=" color:#999;">* 请输入您的要提款金额</a></td>
               </tr>
                 <tr>
                 <td height="34" align="right"  style="color:#ddcba5; font-size:14px;">提款密码：</td>
                 <td>&nbsp;<input type="password" class="text text_width_200" name="" id="moneypassword" onkeyup="value=value.replace(/[^0123456789.]/g,'')" maxlength="4"/>&nbsp;&nbsp;<span style="color:#ccc;" ></span><a style=" color:#999;">* 请输入您的注册时选择的提款密码</a></td>
               </tr>              
            </table>
            <div class="regbt regtop">银行资料：</div><br />
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
               <tr>
                 <td height="12" align="right">&nbsp;</td>
                 <td>　</td>
                 <td width="16">　</td>
              </tr>
               <tr>
                 <td width="647" height="34" align="right" style="color:#ddcba5; font-size:14px;">开户银行：</td>
                 <td width="959">&nbsp;<select class="text2" style="background:#1b1b1b; width:206px; height:31px; border:1px solid #353535;" id="bankcode">
							    <option value="000">其它银行</option>
								<option value="ABC">农业银行</option>
								<option value="BCM">交通银行</option>
								<option value="CCB">建设银行</option>
								<option value="CIB">兴业银行</option>
								<option value="CMB">招商银行</option>
								<option value="GZCB">广州银行</option>
								<option selected="" value="ICBC">工商银行</option>
								<option value="CBGCH">广发银行</option>
								<option value="CITIC">中信银行</option>
								<option value="CMBC">民生银行</option>
								<option value="OTCBB">平安银行</option>								
								<option value="BBC">中国银行</option>
							</select>&nbsp;&nbsp;<span style=" color:#ccc;" id="yxzh_check"></span></td>
               </tr>
               <tr>
                 <td height="34" align="right"  style="color:#ddcba5; font-size:14px;">银行户名：</td>
                 <td>&nbsp;<input id="khname" type="text" max="20" value="" name="khname" class="text text_width_200">&nbsp;&nbsp;<span style="color:#ccc;" id="tkje_check"></span><a style=" color:#999;">* 请输入您的注册时填写的真实姓名</a></td>
               </tr>
                 <tr>
                 <td height="34" align="right"  style="color:#ddcba5; font-size:14px;">银行账号：</td>
                 <td>&nbsp;<input id="yhzh" type="text" maxlength="50" value="" name="yhzh" class="text text_width_200">&nbsp;&nbsp;<span style="color:#ccc;" ></span><a style=" color:#999;">* 请输入您的到账的银行卡号</a></td>
               </tr>
               <tr>
                 <td height="34" align="right" style="color:#ddcba5; font-size:14px;">验证码：</td>
                 <td>&nbsp;<input type="text" class="text text_width_200" style="vertical-align: bottom; cursor: pointer;" name="yz" id="yzm" maxlength="4"/>&nbsp;<img src="/ValiCode.aspx?type=0"  id="imgCode" style="vertical-align: bottom; cursor: pointer;border:;height:25px;"></td> 
                 <td></td>
               </tr>                
              
             

             
				<tr><td>&nbsp;</td></tr>
               <tr>
                 <td height="34" align="right">　</td>
                 <td>&nbsp;<input type="button" class="tijiao_button" value=""  id="btn-qk"/>&nbsp;&nbsp;&nbsp;<input type="reset" class="reset_button" value=""></td>
                 <td>　</td>
               </tr>
               <tr>
                 <td height="66" colspan="3" align="left"></td>
              </tr>
            </table>
                                
          </FORM>
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
<script>
  
</script> 
</body>

</html>



