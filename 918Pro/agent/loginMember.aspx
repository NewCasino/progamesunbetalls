<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginMember.aspx.cs" Inherits="agent.loginMember" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>     
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/Agent/loginMember.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/js/page/pageJs.js" type="text/javascript"></script>
     <script src="/js/jQueryCommon_div.js" type="text/javascript"></script>
      <script type="text/javascript">
          $(function () {
              GetjoinerInfo();
              $("#txtanswer").keypress(function (e) {
                  var currKey = 0, e = e || event;
                  currKey = e.keyCode || e.which || e.charCode;
                  if (currKey == 13) {
                      jQuery("#BtnCheck").click();
                  }
              });
              $("#BtnCheck").click(function () {
                  var url = "/ServicesFile/UserService.asmx/UpdateAgentInfo";
                  var data = "tel:'" + $("#txttel").val() + "',url:'" + $("#txtparname").val() + "',add:'" + $("#txtadder").val() + "'";

                  //$.AjaxCommon(url, data, true, false, function (json) {

                  $.AjaxCommon({
                      url: url,
                      datas: data,
                      beforeSend: function () {
                          ShowTipDiv(0);
                      },
                      complete: function () {
                          HideTipDiv();
                      },
                      toSuccess: function (json) {
                          //  debugger
                          if (json.d == true) {
                              alert("修改成功");
                              window.location.href = "loginMember.aspx";

                          }
                          else {
                              alert("修改成功");
                          } 
                      }
                  });

              });
          });

      function GetjoinerInfo() {
          var url = "/ServicesFile/UserService.asmx/GetjoinerInfo";
         // $.AjaxCommon(url, "", true, false, function (json) {
          $.AjaxCommon({
              url: url,
              datas: "",
              beforeSend: function () {
                  ShowTipDiv(0);
              },
              complete: function () {
                  HideTipDiv();
              },
              toSuccess: function (json) {
                  // debugger
                  if (json.d != "") {
                      var re = jQuery.parseJSON(json.d);
                      $("#spnagnetname").html(re[0].name);
                      $("#txttel").val(re[0].tel);

                      $("#txtparname").val(re[0].url);
                      $("#txtadder").val(re[0].addr);
                  } 
              }


          });

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
                                <td class="STYLE6">帐号管理</td>
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
                    <td height="30" colspan="4" align="left" class="STYLE11 STYLE12"><table width="290" border="0" cellspacing="1" cellpadding="0">
                              <tr>
                                <td width="143" height="30" align="center" bgcolor="#FF8D1A" class="STYLE12">帐号信息</td>
                                <td width="144" align="center" bgcolor="#666666"><a href="loginPassword.aspx"><span class="STYLE11">修改密码</span></a></td>
                              </tr>
                                              </table></td>
                          </tr>
                  <tr>
                    <td height="300" colspan="4" align="center" bgcolor="#2A2B2B" >
                        <table  border="0" 
                           cellpadding="7" cellspacing="1" bgcolor="#353536" style="width: 380px">
                      <tr>
                        <td height="30" align="center" bgcolor="#2A2B2B">真实姓名：</td>
                        <td align="left" bgcolor="#2A2B2B"><span id="spnagnetname" style=" color:#FF5050; font-size:14px"></span></td>
                      </tr>
                     
                      <tr>
                        <td align="center" bgcolor="#2A2B2B">手机号码：</td>
                        <td align="left" bgcolor="#2A2B2B"><input style=" width:200px; height:18px; text-align:left"  type="text" name="textfield2" id="txttel"></td>
                      </tr>
                      <tr>
                        <td align="center" bgcolor="#2A2B2B">宣传网站：</td>
                        <td align="left" bgcolor="#2A2B2B"><input  style=" width:200px; height:18px; text-align:left" type="text" name="textfield3" id="txtparname"></td>
                      </tr>
                      <tr>
                        <td align="center" bgcolor="#2A2B2B">详细地址：</td>
                        <td align="left" bgcolor="#2A2B2B"><input style=" width:240px; height:18px; text-align:left" type="text" name="textfield4" id="txtadder"></td>
                      </tr>
                        <tr>
                        <td align="left" bgcolor="#2A2B2B" colspan="2"><span style=" font-size:12px; margin-top:3px">注：请填写以上信息，以便我们能为您提供更贴心的服务.</span></td>
                       
                      </tr>
                      <tr>
                        
                        <td align="center" bgcolor="#2A2B2B" colspan="2"><input type="submit" name="button" id="BtnCheck" style=" height:28px" value="提交修改"></td>
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
          
        </table>          </td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
  </tr>
</table>
</body>
</html>
