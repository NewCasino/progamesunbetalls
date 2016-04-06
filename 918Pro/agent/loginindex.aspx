<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginindex.aspx.cs" Inherits="agent.loginindex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="../css/Agent/loginindex.css" rel="stylesheet" type="text/css" />
        <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/js/page/pageJs.js" type="text/javascript"></script>
  <%--  <script src="/js/jQueryCommon.js" type="text/javascript"></script>--%>
    <script src="/js/jQueryCommon_div.js" type="text/javascript"></script>
    <script src="/js/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
    <script src="/js/webBasicInfo/zh-CN.js" type="text/javascript"></script>
    <script src="../js/webBasicInfo/zh-CN.js" type="text/javascript"></script>

      <script type="text/javascript">


          function CurentTime() {
              var now = new Date();
              var year = now.getFullYear();       //年
              var month = now.getMonth() ;     //月


              var clock = year + "-";
              if (month < 10)
                  clock += "0";
              clock += month + "-";
              clock += "01";
              return (clock);
          }
          function CurentTime2() {
              var now = new Date();
              var year = now.getFullYear();       //年
              var month = now.getMonth() + 1;     //月
              var day = now.getDate();       //日


              var clock = year + "-";
              if (month < 10)
                  clock += "0";
              clock += month + "-";
              clock += day;
              return (clock);
          }
        $(function () {
            try {
                $('#time1WhereVal').val(CurentTime());
                jQuery("#time1WhereVal").datepicker();

                $('#time2WhereVal').val(CurentTime2());
                jQuery("#time2WhereVal").datepicker();
                LoadAgentInfo();
                $("#btnGetInfo").click(function () {
                    LoadAgentInfo();
                });

            } catch (e) {

            }




        });
        function LoadAgentInfo() {
            var url = "/ServicesFile/UserService.asmx/GetSumAgentInfo";
            var data="time1:'" + $("#time1WhereVal").val() + "',time2:'" + $("#time2WhereVal").val() + "'";
            var Wcount = 0;
//            $.AjaxCommon(url, "", true, false, function (json) {
            $.AjaxCommon({
                url: "/ServicesFile/UserService.asmx/GetSumAgentInfo",
                datas: data,
                beforeSend: function () {
                    ShowTipDiv(0);
                },
                complete: function () {
                    HideTipDiv();
                },
                toSuccess: function (json) {

                    if (json.d != "") {
                        var result = jQuery.parseJSON(json.d);
                        var MLamount = 0;
                        // debugger                  
                        // var UpHLamount = result[0].UpHLamount == "" ? 0 : parseFloat(result[0].UpHLamount);
                        // var UpFSamount = result[0].UpFSamount == "" ? 0 : parseFloat(result[0].UpFSamount);
                        // var UpYBamount = result[0].UpYBamount == "" ? 0 : parseFloat(result[0].UpYBamount);
                        //  var Upagentamount = result[0].Upagentamount == "" ? 0 : parseFloat(result[0].Upagentamount);
                        //  var Upamount = Upagentamount - UpHLamount - UpFSamount - UpYBamount;
                        $("#sptd1").html(result[0].regcount == "" ? 0 : parseInt(result[0].regcount));
                        $("#sptd2").html(parseInt(result[0].CGusercount));
                        Wcount = parseInt(result[0].regcount) - parseInt(result[0].CGusercount);
                        $("#sptd3").html(Wcount <= 0 ? 0 : Wcount);
                        $("#sptd4").html("0");
                        //$("#spmonth0").html(result[0].Heagentcount == "" ? 0 : parseFloat(result[0].Heagentcount).toFixed(2));
                       // $("#spmonth1").html(result[0].agentcount == "" ? 0 : parseFloat(result[0].agentcount).toFixed(2));
                        //  $("#spmonth2").html(Upamount.toFixed(2));
                      
                        var agentCgamount = result[0].agentCgamount == "" ? 0 : parseFloat(result[0].agentCgamount).toFixed(2),
                            agentQgamount = result[0].agentQgamount == "" ? 0 : parseFloat(result[0].agentQgamount).toFixed(2),
                            agentSamount = agentCgamount - agentQgamount,
                            agentHLamount = result[0].agentHLamount == "" ? 0 : parseFloat(result[0].agentHLamount).toFixed(2),
                            agentFSamount = result[0].agentFSamount == "" ? 0 : parseFloat(result[0].agentFSamount).toFixed(2),
                            agentscounts = agentSamount - agentHLamount - agentFSamount;

                        $("#spmonth3").html(result[0].agentSamount == "" ? 0 : agentSamount);
                        $("#spmonth4").html(agentHLamount);
                        $("#spmonth5").html(agentFSamount);
                        $("#spmonth6").html(parseFloat(result[0].agentpercent));
                        $("#spmonth8").html(parseFloat(result[0].agentYXamount));
                        
                        MLamount = agentscounts * parseFloat(result[0].agentpercent);
                        $("#spmonth7,#_ssmount").html(MLamount.toFixed(2) == "NaN" ? 0 : MLamount.toFixed(2));


                    }
                }

            });
        }

      </script>
</head>
<body style=" height:350px" >
<table width="1054" border="0" align="center" cellpadding="0" cellspacing="0" >
  
  <tr>
    <td height="50" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="2" bgcolor="#353536">
      <tr>
        <td valign="top" bgcolor="#2A2B2B"><table width="100%" border="0" cellspacing="10" cellpadding="0">
          <tr>
            <td style="line-height:200%"><table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#353536">
              <tr>
                <td valign="top" bgcolor="#1C1C1C"><table border="0" cellspacing="5" cellpadding="0">
                    <tr>
                      <td><table width="142" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                          <td width="132" height="44" align="center" background="/images/gybj.png"><table border="0" cellspacing="0" cellpadding="0">
                              <tr>
                                <td><span class="STYLE6">佣金计算表</span></td>
                              </tr>
                              <tr>
                                <td><img src="../images/spacer.gif" width="22" height="5" border="0" alt="" /></td>
                              </tr>
                          </table></td>
                        </tr>
                      </table></td>
                      <td width="450">&nbsp;</td>
                      <td>
                        日期：</td>
                     
                      <td><input type="text" id="time1WhereVal"  style=" width:100px; height:19px; font-size:14px" readonly="readonly"  />－<input type="text" id="time2WhereVal" style=" width:100px; height:19px; font-size:14px" readonly="readonly"  /></td>
                    
                      <td><input type="button" name="button" id="btnGetInfo" style=" width:70px; height:28px" value=" 提交 "></td>
                    </tr>
                </table></td>
              </tr>
            </table></td>
          </tr>
          <tr>
            <td><table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#353536">
              <tr>
                <td width="23%" height="40" align="center" bgcolor="#1C1C1C"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td height="10">  </td>
                    </tr>
                    <tr>
                      <td align="center"><img src="/images/tx.png" width="145" height="111"></td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                    </tr>
                  </table></td>
                <td width="77%" bgcolor="#1C1C1C"><table width="790" border="0" cellspacing="1" cellpadding="0">
                  <tr>
                    <td height="50" colspan="4" align="center" bgcolor="#6C1C2D"><span class="STYLE9">盈利:<span id="_ssmount"> 0.00 </span>&nbsp;【佣金=(存款-提款-红利-返水)*提成比例-各项费用】 </span></td>
                    </tr>
                  <tr>
                    <td width="197" height="30" align="center" bgcolor="#2A2B2B">注册会员 </td>
                    <td width="197" align="center" bgcolor="#2A2B2B">存款会员 </td>
                    <td width="197" align="center" bgcolor="#2A2B2B">未存款会员 </td>
                    <td width="199" align="center" bgcolor="#2A2B2B">支出费用 </td>
                  </tr>
                  <tr>
                    <td align="center" height="41" bgcolor="#2A2B2B"><span id="sptd1"></span></td>
                    <td align="center" height="41" bgcolor="#2A2B2B"><span id="sptd2"></span></td>
                    <td align="center" height="41" bgcolor="#2A2B2B"><span id="sptd3"></span></td>
                    <td align="center" height="41" bgcolor="#2A2B2B"><span id="sptd4">0</span></td>
                  </tr>
                </table></td>
              </tr>
            </table></td>
          </tr>
          <tr>
            <td style="line-height:180%"><table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#353536">
              <tr>
                <td height="40" bgcolor="#1C1C1C"><table width="1028" border="0" cellspacing="1" cellpadding="0">

                      <tr>
                      <%--  <td width="145" height="30" align="center" bgcolor="#666666"><span class="STYLE11">活跃会员</span></td>--%>
                     <%--   <td width="145" align="center" bgcolor="#666666" class="STYLE11">有效投注额</td>--%>
                      <%--  <td width="145" align="center" bgcolor="#666666" class="STYLE11">上月盈利</td>--%>
                        <td width="152" align="center" bgcolor="#666666" class="STYLE11">总输赢（总存款额-总取款额）</td>
                        <td width="143" align="center" bgcolor="#666666" class="STYLE11">派出红利</td>
                        <td width="143" align="center" bgcolor="#666666" class="STYLE11">派出返水</td>   
                        <td width="143" align="center" bgcolor="#666666" class="STYLE11">佣金比例 </td>   
                        <td width="143" align="center" bgcolor="#666666" class="STYLE11">总投注额 </td>                
                        <td width="147" align="center" bgcolor="#666666" class="STYLE11">毛利</td>
                      </tr>
                      <tr>
                      <%--  <td height="30"  align="center"   bgcolor="#2A2B2B"><span id="spmonth0"></span></td>--%>
                       <%-- <td align="center" height="30"  bgcolor="#2A2B2B"><span id="spmonth1"></span></td>--%>
                       <%-- <td align="center" bgcolor="#2A2B2B"><span id="spmonth2"></span></td>--%>
                        <td align="center" bgcolor="#2A2B2B"><span id="spmonth3"></span></td>
                        <td align="center" bgcolor="#2A2B2B"><span id="spmonth4"></span></td>
                        <td align="center" bgcolor="#2A2B2B"><span id="spmonth5"></span></td>   
                         <td align="center" bgcolor="#2A2B2B"><span id="spmonth6"></span></td> 
                          <td align="center" bgcolor="#2A2B2B"><span id="spmonth8"></span></td>                     
                        <td align="center" bgcolor="#2A2B2B"><span id="spmonth7" style=" color:#FF5050"></span></td>
                      </tr>
                                </table></td>
                </tr>
            </table></td>
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
