<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginGuanggao.aspx.cs" Inherits="agent.loginGuanggao" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <link href="../css/Agent/loginGuanggao.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript">
            var spManagerId = parent.document.getElementById("spnurl").innerHTML;
            $(function () {
                $("#adlink").html(spManagerId);
                $("#tab3 .btn_01").click(function () {
                    $("#linkcode").val($(this).parent().parent().find("td:eq(1)").html());
                    $("#add").dialog({
                        modal: false,
                        width: 650
                    });
                });
                $("#copylink").click(function () {
                    copy_code($("#adlink").html());
                });
                $("#adcode").click(function () {
                    copy_code($("#linkcode").val());
                });
                $("#tab3 a").attr("href", spManagerId);
            });

            function copy_code(copyText) {
                if (window.clipboardData) {
                    window.clipboardData.setData("Text", copyText)
                }
                else {
                    var flashcopier = 'flashcopier';
                    if (!document.getElementById(flashcopier)) {
                        var divholder = document.createElement('div');
                        divholder.id = flashcopier;
                        document.body.appendChild(divholder);
                    }
                    document.getElementById(flashcopier).innerHTML = '';
                    var divinfo = '<embed src="../js/_clipboard.swf" FlashVars="clipboard=' + encodeURIComponent(copyText) + '" width="0" height="0" type="application/x-shockwave-flash"></embed>';
                    document.getElementById(flashcopier).innerHTML = divinfo;
                }
                alert('成功复制到剪切板！');
            }
    </script>

</head>
<body>
<table width="1054" border="0" align="center" cellpadding="0" cellspacing="0">
  
  <tr>
    <td height="50" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="2" bgcolor="#353536">
      <tr>
        <td valign="top" bgcolor="#2A2B2B"><table width="100%" border="0" cellspacing="10" cellpadding="0">
          <tr>
            <td style="line-height:200%"><table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#353536">
              <tr>
                <td valign="top" bgcolor="#1C1C1C"><table width="100%" border="0" cellpadding="0" cellspacing="5">
                    <tr>
                      <td><table width="142" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                          <td width="132" height="44" align="center" background="/images/gybj.png"><table border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td class="STYLE6">广告资源</td>
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
                <td height="40" bgcolor="#1C1C1C">您的推广链接：<SPAN id="adlink"></SPAN>
                  <INPUT id="copylink" value="复制到剪切板" type="button"></td>
              </tr>
              <tr>
                <td height="40" bgcolor="#1C1C1C"><table id="tab3" width="1028" border="0" cellspacing="1" cellpadding="5">
                  
                  <tr>
                    <td height="30" align="center" bgcolor="#666666" class="STYLE11">序号</td>
                          <td align="center" bgcolor="#666666" class="STYLE11">缩略图</td>
                          <td align="center" bgcolor="#666666" class="STYLE11">图片规格</td>
                          <td align="center" bgcolor="#666666" class="STYLE11">图片类型</td>
                          <td align="center" bgcolor="#666666" class="STYLE11">操作</td>
                          </tr>
                  <tr>
                    <td height="30" align="center" bgcolor="#2A2B2B">1</td>
                          <td bgcolor="#2A2B2B"><a href="#" target="_blank"><img src="http://www.918shenbo.com/images/logo.png" width="120" height="60" border="0"></a></td>
                          <td align="center" bgcolor="#2A2B2B">120×60</td>
                          <td align="center" bgcolor="#2A2B2B">gif</td>
                          <td align="center" bgcolor="#2A2B2B"><input type="button" class="btn_01" name="button" id="button" value="生成链接"></td>
                          </tr>
                  <tr>
                    <td height="30" align="center" bgcolor="#2A2B2B">2</td>
                    <td bgcolor="#2A2B2B"><a href="#" target="_blank"><img src="http://www.918shenbo.com/images/logo.png" width="220" height="60" border="0"></a></td>
                    <td align="center" bgcolor="#2A2B2B">220×60</td>
                    <td align="center" bgcolor="#2A2B2B">gif</td>
                    <td align="center" bgcolor="#2A2B2B"><input type="button" class="btn_01" 
                            name="button7" id="button7" value="生成链接"></td>
                  </tr>
                  <tr>
                    <td height="30" align="center" bgcolor="#2A2B2B">3</td>
                    <td bgcolor="#2A2B2B"><a href="#" target="_blank"><img src="http://www.918shenbo.com/images/logo.png" width="220" height="100" border="0"></a></td>
                    <td align="center" bgcolor="#2A2B2B">220×100</td>
                    <td align="center" bgcolor="#2A2B2B">gif</td>
                    <td align="center" bgcolor="#2A2B2B"><input type="button" class="btn_01" 
                            name="button8" id="button8" value="生成链接"></td>
                  </tr>
                  <tr>
                    <td height="30" align="center" bgcolor="#2A2B2B">4</td>
                    <td bgcolor="#2A2B2B"><a href="#" target="_blank"><img src="http://www.918shenbo.com/images/logo.png" width="250" height="110" border="0"></a></td>
                    <td align="center" bgcolor="#2A2B2B">250×110</td>
                    <td align="center" bgcolor="#2A2B2B">gif</td>
                    <td align="center" bgcolor="#2A2B2B"><input type="button" class="btn_01" 
                            name="button9" id="button9" value="生成链接"></td>
                  </tr>
                  <tr>
                    <td height="30" align="center" bgcolor="#2A2B2B">5</td>
                    <td bgcolor="#2A2B2B"><a href="#" target="_blank"><img src="http://www.918shenbo.com/images/logo.png" width="468" height="60" border="0"></a></td>
                    <td align="center" bgcolor="#2A2B2B">468×60</td>
                    <td align="center" bgcolor="#2A2B2B">gif</td>
                    <td align="center" bgcolor="#2A2B2B"><input type="button" class="btn_01" 
                            name="button10" id="button10" value="生成链接"></td>
                  </tr>
                  <tr>
                    <td height="30" align="center" bgcolor="#2A2B2B">6</td>
                    <td bgcolor="#2A2B2B"><a href="#" target="_blank"><img src="http://www.918shenbo.com/images/logo.png" width="500" height="90" border="0"></a></td>
                    <td align="center" bgcolor="#2A2B2B">500×90</td>
                    <td align="center" bgcolor="#2A2B2B">gif</td>
                    <td align="center" bgcolor="#2A2B2B"><input type="button" class="btn_01" 
                            name="button11" id="button11" value="生成链接"></td>
                  </tr>
                  </table></td>
                  </tr>
            </table></td>
          </tr>
          <tr>
            <td>&nbsp;</td>
          </tr>
          
        </table>          </td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
  </tr>
</table>
<div class="undis" style="display:none;">

<div id="add" title="广告代码" >
<div class="showdiv">
    <table width="100%">
        <tr style="background-color:#CDEAFC;">
            <th>代码类型</th>
            <th>代码内容</th>
            <th>操作</th>
        </tr>
        <tr>
            <td>默认脚本</td>
            <td>
                <textarea id="linkcode" style="width:430px; height:88px;"></textarea>
            </td>
            <td><input id="adcode" type="button"  value="复制到剪切板" /></td>
        </tr>
    </table>
</div>
</div>

</div>

</body>
</html>
