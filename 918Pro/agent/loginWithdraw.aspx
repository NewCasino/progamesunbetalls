<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginWithdraw.aspx.cs" Inherits="agent.loginWithdraw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>index.jpg</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/js/page/pageJs.js" type="text/javascript"></script>
    <script src="/js/jQueryCommon_div.js" type="text/javascript"></script>
<style type="text/css">
td img {display: block;}body,td,th {
	font-size: 12px;
	color: #999999;
}
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	background-image: url();
	background-color: #000000;
}
a:link {
	color: #999999;
	text-decoration: none;
}
a:visited {
	text-decoration: none;
	color: #999999;
}
a:hover {
	text-decoration: none;
	color: #FF9900;
}
a:active {
	text-decoration: none;
}
#demo {
overflow:hidden;

width: 270px;
}
#demo1 {float: left;
}
#demo2 {float: left;
}
#indemo {float: left;
width: 800%;
}
.STYLE6 {
	color: #FF3300;
	font-weight: bold;
	font-size: 18px;
}
.STYLE11 {color: #E3D8B8; font-weight: 500; font-size: 12px; }
.STYLE12 {color: #000000; font-size: 12px;}
.STYLE14 {color: #FF9900; font-size: 12px;}
</style>
  <script type="text/javascript">
      var Bdtype = 0; //是否绑定银行
      var Gametype = 0; //是否有绑定游戏帐号
      var agentname = "";
      $(function () {
          try {
              $('#spngamename').attr("disabled", true);
              $("#btngamename").attr("disabled", true);
              $("#txtamount").focus();
              GetagentInfo();
              $("#txtanswer").keypress(function (e) {
                  var currKey = 0, e = e || event;
                  currKey = e.keyCode || e.which || e.charCode;
                  if (currKey == 13) {
                      jQuery("#BtnCheck").click();
                  }
              });

              $("#btngamename").click(function () {
                  if ($("#spngamename").val() == "") {
                      alert("请输入你要绑定的游戏帐号！");
                      $("#spngamename").focus();

                      return false;
                  }
                  else {
                      // jQuery.AjaxCommon("/ServicesFile/UserService.asmx/IsExistUsername", "", true, false, function (json) {
                      $.AjaxCommon({
                          url: "/ServicesFile/UserService.asmx/IsExistUsername",
                          datas: "username:'" + $("#spngamename").val() + "'",
                          beforeSend: function () {
                              ShowTipDiv(0);
                          },
                          complete: function () {
                              HideTipDiv();
                          },
                          toSuccess: function (json) {
                              //  alert(json.d);
                              if (!json.d) {
                                  alert("对不起，没查到有此游戏帐号，请确认");
                                  $("#btngamename").attr("disabled", false);
                                  $('#spngamename').attr("disabled", false);
                                  return false;

                              }
                              else {

                                  //   jQuery.AjaxCommon("/ServicesFile/UserService.asmx/Updatgameuser", "", true, false, function (json) {

                                  $.AjaxCommon({
                                      url: "/ServicesFile/UserService.asmx/Updatgameuser",
                                      datas: "agentname:'" + agentname + "',username:'" + $("#spngamename").val() + "'",
                                      beforeSend: function () {
                                          ShowTipDiv(0);
                                      },
                                      complete: function () {
                                          HideTipDiv();
                                      },
                                      toSuccess: function (json) {
                                          if (json.d) {
                                              alert("绑定成功，取款时请确定游戏帐号绑定了相关银行卡信息");
                                              window.location = "loginWithdraw.aspx";
                                          }
                                          else {
                                              $("#btngamename").attr("disabled", false);
                                              $('#spngamename').attr("disabled", false);


                                          }
                                      }
                                  });
                              } 
                          }

                      });

                  }

              });
              $("#BtnCheck").click(function () {
                  if (Bdtype == 0) {
                      alert("请将游戏帐号绑定银行卡信息");
                      return false;
                  }
                  if (Gametype == 0) {
                      alert("您还没有绑定游戏帐号，请联系工作人员");
                      return false;
                  }
                  if (isDigit($("#txtamount").val()) != true) {
                      alert("金额格式不对");
                      return false;
                  }

                  if ($("#txtamount").val() == "") {
                      alert("请输入您要提取的金额");
                      return false;
                  }
                  if (parseFloat($("#txtamount").val()) > parseFloat($("#spnamount").val())) {
                      alert("超出您的余额");
                      return false;
                  }


                  if (parseFloat($("#txtamount").val()) < 500 || parseFloat($("#txtamount").val()) > 200000) {
                      alert("取款金额低于500，高于200000");
                      return false;
                  }
                  if ($("#txtanswer").val() == "") {
                      alert("请填写安全提示答案");
                      return false;
                  }
                  //代理提交取金信息
                  //  alert($("#spngamename").hlml());
                  //var url = "/ServicesFile/UserService.asmx/CheckAgentamount";
                   var data = "username:'" + $("#spngamename").val() + "',Type:'2',txtanswer:'" + $("#txtanswer").val() + "',amount:'" + $("#txtamount").val() + "',Status:'0',Reasoncn:'',mark:'代理佣金'";

             


                  $.AjaxCommon({
                      url: "/ServicesFile/UserService.asmx/CheckAgentamount",
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
                              alert("您的取款申请提交成功，请联系我们工作人员");
                              window.location.href = "loginWithdraw.aspx";

                          }
                          else {
                              alert("您的取款申请提失败,请检查取款金额与安全回答是否正确");
                              return false;
                          }
                      }
                  });


              });
          } catch (e) {

          }
      });
        function GetagentInfo() {    
            $.AjaxCommon({
                url: "/ServicesFile/UserService.asmx/GetagentInfo",
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
                        agentname = re[0].username;
                        $("#spnusername").html(re[0].username);
                        $("#spnamount").html(re[0].Balance);
                        $("#txtanwer").html(re[0].question);
                        if (re[0].gameUsername == "") {

                            Gametype = 0;
                            alert("您还没绑定游戏帐号，请绑定");
                            $("#btngamename").attr("disabled", false);
                            $('#spngamename').attr("disabled", false);
                            return false;
                        }
                        else {
                            Gametype = 1;
                            $("#spngamename").val(re[0].gameUsername);
                            $("#btngamename").attr("disabled", true);
                            $('#spngamename').attr("disabled", true);
                        }


                        if (re[0].id == "") {
                            Bdtype = 0;
                            alert("您还没将游戏帐号绑定银行卡信息，请到官网绑定");
                            return false;
                        }
                        else {

                            Bdtype = 1;
                        }

                    } 
                }


            });

        }

        function isDigit(s) {
            var patrn = /^-?\d+\.{0,}\d{0,}$/;

            if (!patrn.exec(s)) {
                return false;
            } else {
            return true;
            }


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
                                <td class="STYLE6">取款中心</td>
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
                                <td width="143" height="30" align="center" bgcolor="#666666"><a href="loginwithd.aspx"><span class="STYLE11">取款历史</span></a></td>
                                <td width="144" align="center" bgcolor="#FF8D1A" class="STYLE12">我要取款</td>
                              </tr>
                                              </table></td>
                          </tr>
                  <tr>
                    <td colspan="4" align="center" bgcolor="#2A2B2B" class="STYLE11">
                  
                     <table  border="0" 
                           cellpadding="4" cellspacing="1" bgcolor="#353536" style="width: 450px">
                   
                      <tr>
                        <td style=" text-align:right"  height="30" align="center" bgcolor="#2A2B2B"> 代理帐号：</td>
                        <td style=" text-align:left"  height="30" align="center" bgcolor="#2A2B2B"><span id="spnusername" ></span></td>
                      </tr>
                        <tr>
                        <td style=" text-align:right"  height="30" align="center" bgcolor="#2A2B2B"> 绑定游戏帐号：</td>
                      <%--  <td style=" text-align:left"  height="30" align="center" bgcolor="#2A2B2B"><span id="spngamename"></span></td>--%>
                         <td style=" text-align:left"  height="30" align="center" bgcolor="#2A2B2B">
                         <input type="text" id="spngamename"  style=" width:150px"/>
                         <input type="button" id="btngamename" style=" width:45px"  value="绑定"/>
                         </td>
                      </tr>
                      <tr>
                        <td  style=" text-align:right"  height="30" align="center" bgcolor="#2A2B2B">提款金额：</td>
                        <td style="text-align:left"  height="30" align="center" bgcolor="#2A2B2B"><input name="textfield" type="text" id="txtamount" style=" width:150px; text-align:left"></td>
                      </tr>
                    <tr>
                        <td  style=" text-align:right"  height="30" align="center" bgcolor="#2A2B2B">帐号余额：</td>
                        <td style="text-align:left"  height="30" align="center" bgcolor="#2A2B2B"><span id="spnamount"></span></td>
                      </tr>
                      <tr>
                        <td  style=" text-align:right"  height="30" align="center" bgcolor="#2A2B2B">安全提示问题：</td>
                        <td style="text-align:left"  height="30" align="center" bgcolor="#2A2B2B"><span id="txtanwer"></span></td>
                      </tr>
                      <tr>
                        <td  style=" text-align:right"  height="30" align="center" bgcolor="#2A2B2B">安全提示答案：</td>
                        <td style="text-align:left"  height="30" align="center" bgcolor="#2A2B2B"><input name="textfield4" type="text" id="txtanswer" style=" width:150px"><span style=" color:#ffcc00">(游戏帐号安全答案)</span></td>
                      </tr>
                     
                      <tr>
                      <td colspan="2"  style=" text-align:left ; font-size:13px "  height="30" align="center" bgcolor="#2A2B2B"><span style="color:#FF9900;">注:提款成功审核通过后,此款项将打入您银行卡上<br />&nbsp;&nbsp;&nbsp;&nbsp;提款金额至少500，最多200,000</span></td>
                      </tr>
                        <tr>
                      <td colspan="2" style=" text-align:left; "  height="5" align="center" bgcolor="#2A2B2B">&nbsp;</td>
                      </tr>
                      <tr>
                       
                        <td colspan="2" style=" text-align:center"  height="30" align="center" bgcolor="#2A2B2B"><input type="button" name="button" id="BtnCheck" style=" height:25px" value="提交修改"></td>
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
