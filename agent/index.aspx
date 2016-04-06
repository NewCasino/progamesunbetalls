<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="agent.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title> 918申博  代理管理</title>   
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/Agent/index.css" rel="stylesheet" type="text/css" />
      <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
          <script src="/js/jQueryCommon.js" type="text/javascript"></script>
    <script src="../js/AgentPage/index.js" type="text/javascript"></script>


    <script type="text/javascript">
        jQuery(function ($) {
            var ticd = 1;
            LoadManagerInfo();

            $("#LoginOuts").click(function () {

                fnLoginOut();

            });
        });


//        switch (ticd) {
//            case 1:
//                $('#td1').css("background-color", "#861327");
//                break;
//            case 2:
//                $('#td2').css("background-color", "#861327");
//                break;
//            case 3:
//                $('#td3').css("background-color", "#861327");
//                break;
//            case 6:
//                $('#td6').css("background-color", "#861327");
//                break;
//            case 7:
//                $('#td7').css("background-color", "#861327");
//                break;
//            default:
//                $('#td1').css("background-color", "#861327");

//        }


        //登出
        function fnLoginOut() {
            url = "/ServicesFile/LoginService.asmx/LoginOut";
            $.AjaxCommon(url, "", true, false, function (json) {
                if (json.d) {
                    alert("谢谢您的光临，已安全退出");
                    window.location.href = "login.htm";
                }

            });

        }

        function LoadManagerInfo() {
            var url = "/ServicesFile/LoginService.asmx/GetManageInfo";

            $.AjaxCommon(url, "", true, false, function (json) {
                if (json.d != "") {
                    if (json.d == 'shenbo09') {
                        $("#spnurl").text("http://www.618shenbovip.com");
                    } else {
                        $("#spnurl").text("http://www.618shenbovip.com/?tid=" + json.d);
                    }
                    $("#username").text(json.d);
                   
                }
            });

        }

     
    </script>
</head>
<body >
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td  align="center" valign="top" background="/images/bg.jpg"   style="background-repeat:repeat-x; height:80px">
    <table width="1054" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td><img src="../images/spacer.gif" width="20" height="8" border="0" alt="" /></td>
      </tr>
    </table>
        <table width="1054" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td height="86" style=" text-align:left; border:0"><a href="/index.aspx"><img src="/images/logo1.png" width="356" height="83"  style=" border:0"/></a></td>
            <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td align="right"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td height="15" align="right"><span id="username" style=" ; font-size:14px; font-weight:600"></span><font color="" style="  font-size:14px; font-weight:500;  ">欢迎您！</font></td>
                        <td align="center">|</td>
                        <td width="60" align="center" bgcolor="#FF9900"  onmouseover="this.bgColor='#FFFF00' "   onmouseout="this.bgColor='#FF9900'"><a  target="_blank" href="http://www.618shenbovip.com"><font color="#000000">申博官网</font></a></td>
                        <td align="center">|</td>
                        <td width="60" align="center" bgcolor="#FF9900" onmouseover="this.bgColor='#FFFF00' "   onmouseout="this.bgColor='#FF9900'"><a id="LoginOuts"  href="javascript:void(0);"  style=" font-size: 12px; color:#000000">[退出系统]</a></td>
                      </tr>
                  </table></td>
                </tr>
                <tr><td style=" height:10px"></td></tr>
                <tr>
                  <td align="right"><span style=" color:#FFFF99; font-size:13px; font-weight:500">您的代理网址：</span><span id="spnurl" style=" color:#FFFF99; font-size:13px; font-weight:500">
                   </span></td>
                </tr>
            </table></td>
          </tr>
              <tr>
            <td>
            <td><br /><br /><br /></td>
            </tr>
          <tr bgcolor="#151515"  style="border:1px solid #a9c9e2;background:#151515; ">
            <td colspan="2"><table width="1054" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td id="td1" width="111" height="30"     align="center"  class="check" ><a  href="loginindex.aspx" id="src1" class="tdhtml" target= "max" onclick="ChangeCss1()"><span style=" font-size:13px; font-weight:700">收入大纲</span></a></td>
                  <td width="6" align="center">|</td>
                  <td id="td2" width="111" align="center"   class="check"><a href="loginExpenses.aspx" id="src2"  target= "max" class="tdhtml" onclick="ChangeCss2()"><span class="STYLE4">费用支出</span></a></td>
                  <td width="6" align="center">|</td>
                  <td id="td3" width="111" align="center"   class="check"><a href="loginDetailed.aspx" id="src3"  target= "max" class="tdhtml" onclick="ChangeCss3()"><span class="STYLE4">会员详情</span></a></td>

                  <td width="6" align="center">|</td>
                  <td id="td6" width="111" align="center"   class="check"><a href="loginMember.aspx" id="src6"  target= "max" class="tdhtml" onclick="ChangeCss6()"><span class="STYLE4">帐号管理</span></a></td>
                  <td width="6" align="center" >|</td>
                  <td id="td7" width="111" align="center" ><a id="src7"  href="loginguanggao.aspx" target= "max"><span class="STYLE4" onclick="ChangeCss7()">广告资源</span></a></td>
                  <td width="6" align="center"   class="check">|</td>
                  <td width="111" align="center" >&nbsp;</td>
                  <td width="6" align="center">&nbsp;</td>
                  <td width="118" align="center">&nbsp;</td>
                </tr>
            </table></td>
          </tr>
      </table></td>
  </tr>
</table>



<div align="center" style=" height: 470px">
<iframe src="loginindex.aspx"  marginheight="0" 
        style=" border-style: none; border-color: inherit; border-width: 0; height: 100%;" 
        marginwidth="0" frameborder="0" scrolling="auto"id="maxsss" name="max" 
        
        width="100%" >
<table width="1054" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td height="50" valign="top" ><table width="100%" border="0" cellpadding="0" cellspacing="2" bgcolor="#353536">
      <tr>
        <td valign="top" background="/images/bg.jpg"   style="background-repeat:repeat-x; "><table width="100%" border="0" cellspacing="10" cellpadding="0">
          <tr>
            <td style="line-height:200%"><table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#353536">
              <tr>
                <td valign="top" bgcolor="#1C1C1C"><table width="100%" border="0" cellpadding="0" cellspacing="5">
                  <tr>
                    <td><table width="142" border="0" cellpadding="0" cellspacing="0">
                      <tr>
                        <td width="132" height="44" align="center" background="/images/gybj.png"><table border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td class="STYLE6">会员详情</td>
                          </tr>
                          <tr>
                            <td><img src="../images/spacer.gif" width="22" height="5" border="0" alt="" /></td>
                          </tr>
                        </table></td>
                      </tr>
                    </table></td>
                    <td>&nbsp;</td>
                  </tr>
                </table></td>
              </tr>
            </table></td>
          </tr>
          
          <tr>
            <td><table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#353536">
              <tr>
                <td height="40" bgcolor="#1C1C1C"><table width="1028" border="0" cellspacing="1" cellpadding="0">
                  <tr>
                    <td width="145" height="30" align="center" bgcolor="#666666" class="STYLE11">序号</td>
                    <td width="145" align="center" bgcolor="#666666" class="STYLE11">会员账号</td>
                    <td width="145" align="center" bgcolor="#666666" class="STYLE11">会员存款</td>
                    <td width="152" align="center" bgcolor="#666666" class="STYLE11">会员取款</td>
                    <td width="143" align="center" bgcolor="#666666" class="STYLE11">派发红利</td>
                    <td width="143" align="center" bgcolor="#666666" class="STYLE11">派发返水</td>
                    <td width="147" align="center" bgcolor="#666666" class="STYLE11">有效投注额</td>
                    <td width="147" align="center" bgcolor="#666666" class="STYLE11">公司输赢</td>
                  </tr>
                  <tr>
                    <td height="30" align="center" bgcolor="#2A2B2B">1</td>
                    <td height="30" align="center" bgcolor="#2A2B2B">1232131</td>
                    <td align="center" bgcolor="#2A2B2B">0.00</td>
                    <td align="center" bgcolor="#2A2B2B">0.00</td>
                    <td align="center" bgcolor="#2A2B2B">0.00</td>
                    <td align="center" bgcolor="#2A2B2B">0.00</td>
                    <td align="center" bgcolor="#2A2B2B">0.00</td>
                    <td align="center" bgcolor="#2A2B2B">0.00</td>
                  </tr>
                  <tr>
                    <td height="30" colspan="2" align="center" bgcolor="#2A2B2B">合计：</td>
                    <td align="center" bgcolor="#2A2B2B">&nbsp;</td>
                    <td align="center" bgcolor="#2A2B2B">&nbsp;</td>
                    <td align="center" bgcolor="#2A2B2B">&nbsp;</td>
                    <td align="center" bgcolor="#2A2B2B">&nbsp;</td>
                    <td align="center" bgcolor="#2A2B2B">&nbsp;</td>
                    <td align="center" bgcolor="#2A2B2B">&nbsp;</td>
                  </tr>
                </table></td>
              </tr>
            </table></td>
          </tr>
          <tr>
            <td><table width="1030" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="762">共1页，当前为第1页，每页10条</td>
                <td width="268" >首页 上一页 1 下一页 尾页 </td>
              </tr>
            </table></td>
          </tr>
        </table></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
  </tr>
</table>
</iframe>
</div>
<table width="1054" border="0" align="center" cellpadding="0" cellspacing="10">
  <tr>
    <td height="61" align="center" background="../images/footer.png" class="STYLE2"><a target="_blank" href="http://www.618shenbovip.com/about.html">关于我们</a> &nbsp;|&nbsp; <a target="_blank" href="http://www.618shenbovip.com/zhaopai.html">牌照展示</a> &nbsp;|&nbsp; <a target="_blank" href="http://www.618shenbovip.com/gameProject.html#/" class="STYLE2">游戏规则</a> &nbsp;|&nbsp; <a target="_blank" href="http://www.618shenbovip.com/transfers.aspx#/">存款提款 </a>  &nbsp;|&nbsp; <a target="_blank" href="http://f88.live800.com/live800/chatClient/chatbox.jsp?companyID=493978&jid=1206637488">联系我们</a></td>
  </tr>
  <tr>
    <td height="50" align="center" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="20" align="center">本网站所提供的资讯是面向全世界用户,浏览者需遵循所在地方相关法律，在任何情况下触犯所属地区法律，浏览者需自行承担风险。<br /></td>
      </tr>
      <tr>
        <td height="20" align="center">Copyright &copy;Interactive Gaming Licence 021</td>
      </tr>
    </table></td>
  </tr>
</table>
</body>
</html>