<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginPassword.aspx.cs" Inherits="agent.loginPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="../css/Agent/loginPassword.css" rel="stylesheet" type="text/css" />
        <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/js/page/pageJs.js" type="text/javascript"></script>
      <script src="/js/jQueryCommon_div.js" type="text/javascript"></script>
      <script type="text/javascript">
          var istrue = true;
          $(function () {
              GetagentInfo();
              $("#changePwd").click(function () {

                  CheckInfo();
                
                  if (istrue == true) {
                     
                      fnUpdatePwd();
                  }

              });

          });

         function GetagentInfo() {
             var url = "/ServicesFile/UserService.asmx/GetagentInfo";

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
                         $("#spnusername").html(re[0].username);


                     } 
                 }


             });

         }



         function CheckInfo() {
             var newvalue1 = $.trim($("#oldpwd").val());
             var newvalue2 = $.trim($("#newpwd").val());
             var newvalue3 = $.trim($("#newpwd2").val());

             var length11 = newvalue1.length;
             var length12 = newvalue2.length;
             var length13 = newvalue3.length;
             if (newvalue2 == "" || length12 < 6 || length12.lenth > 10) {
                 alert("请输入正确的新密码");
                 $("#newpwd").focus();
                 istrue = false;
                 return false;
             }
             if (newvalue3 == "" || length13 < 6 || length13.lenth > 10) {
                 alert("请输入正确的确认新密码");
                 $("#newpwd2").focus();
                 istrue = false;
                 return false;
             }
             if (newvalue2 != newvalue3) {
                 alert("两次输入的密码不一致！");
                 istrue = false;
                 return false;
             }
             if (newvalue1 != "") {
            // debugger

            // $.AjaxCommon( "/ServicesFile/UserService.asmx/CheckOldPwd","oldPwd:'" + $("#oldpwd").val() + "'",
                //     true, false, function (json) {
             $.AjaxCommon({
                 url: "/ServicesFile/UserService.asmx/CheckOldPwd",
                 datas: "oldPwd:'" + $("#oldpwd").val() + "'",
                 beforeSend: function () {
                     ShowTipDiv(0);
                 },
                 complete: function () {
                     HideTipDiv();
                 },
                 toSuccess: function (json) {
                     if (json.d != true) {
                         // debugger
                         alert("您的原密码不正确！");
                         $("#oldpwd").focus();
                         istrue = false;
                         return false;

                     } 
                 }
             });

             }
             else {
                 alert("请输入原密码");
                 $("#oldpwd").focus();
                 istrue = false;
                 return false;
             }





         }


         function fnUpdatePwd() {

             var url = "/ServicesFile/UserService.asmx/UpdatePassword";
             var data = "oldPwd:'" + $("#newpwd2").val() + "'";
            // $.AjaxCommon(url, data, true, false, function (json) {

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
                     //debugger
                     if (json.d) {
                         $("#oldpwd").val("");
                         $("#newpwd").val("");
                         $("#newpwd2").val("");
                         alert("修改成功，请记住您的密码！");

                     }
                     else {
                         alert("修改失败！");
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
                                <td width="143" height="30" align="center" bgcolor="#666666"><a href="loginMember.aspx"><span class="STYLE11">帐号信息</span></a></td>
                                <td width="144" align="center" bgcolor="#FF8D1A" class="STYLE12">修改密码</td>
                              </tr>
                                              </table></td>
                          </tr>
                  <tr>
                    <td height="300" colspan="4" align="center" bgcolor="#2A2B2B" >
                    
                    <table  border="0" 
                           cellpadding="5" cellspacing="1" bgcolor="#353536" style="width: 380px">
                      <tr>
                        <td  height="30" align="center" bgcolor="#2A2B2B">帐号：</td>
                        <td align="left" bgcolor="#2A2B2B"><span id="spnusername" style=" color:#FF5050; font-size:14px"></span></td>
                      </tr>
                      <tr>
                        <td  height="30" align="center" bgcolor="#2A2B2B">旧密码：</td>
                        <td align="left" bgcolor="#2A2B2B"><input type="password" name="textfield" id="oldpwd" style=" width:200px;height:18px;"></td>
                      </tr>
                      <tr>
                        <td  height="30" align="center" bgcolor="#2A2B2B">新密码：</td>
                        <td align="left" bgcolor="#2A2B2B"><input type="password" name="textfield2" id="newpwd"  style=" width:200px;height:18px;"></td>
                      </tr>
                      <tr>
                        <td  height="30" align="center" bgcolor="#2A2B2B">确认密码：</td>
                        <td align="left" bgcolor="#2A2B2B"><input type="password" name="textfield3" id="newpwd2"  style=" width:200px;height:18px;"></td>
                      </tr>
                      <tr>
                       
                        <td align="center" bgcolor="#2A2B2B" colspan="2"><input  style=" height:28px" type="button" name="button" id="changePwd" value="提交修改"></td>
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
