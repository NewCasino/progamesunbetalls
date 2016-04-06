<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginWithd.aspx.cs" Inherits="agent.loginWithd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="../css/Agent/loginWithd.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/js/page/pageJs.js" type="text/javascript"></script>
    <script src="/js/jQueryCommon_div.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            GetQGHis();
        });

        function GetQGHis() {
           // var url = "/ServicesFile/UserService.asmx/GetQGHis";
            var Wcount = 0;
           // $.AjaxCommon(url, "", true, false, function (json) {

            $.AjaxCommon({
                url: "/ServicesFile/UserService.asmx/GetQGHis",
                datas: "",
                beforeSend: function () {
                    ShowTipDiv(0);
                },
                complete: function () {
                    HideTipDiv();
                },
                toSuccess: function (json) {


                    if (json.d != "") {
                        var re = jQuery.parseJSON(json.d);
                        // debugger
                        var html = "", total1 = 0;
                        $.each(re, function (i) {
                            //debugger

                            total1 += parseFloat(re[i].d);
                            html += "<tr><td style=' text-align:center;height:30px'>" + i + 1 + "</td>";
                            html += "<td style=' text-align:center;height:30px;color:#FF5050;'>" + re[i].d + "</td>";
                            html += "<td style=' text-align:center;height:30px'>" + re[i].f + "</td>";
                            html += "<td style=' text-align:center;height:30px'>取款成功</td>";

                            html += "</tr>";
                        });
                        html += "<tr><td style=' text-align:center;height:30px'>总计</td><td style=' text-align:center;height:30px;color:#FF5050;'>" + total1.toFixed(2) + "</td><td colspan=\"2\" style=''></td>";
                        html += "</tr>";
                        $("#tb2>tbody").html(html);

                    }

                    else {

                        $("#tb2>tbody").html("<tr><td style=' text-align:center;height:60px' colspan=\"4\">没有相应数据</td></tr>");
                    } 
                }
            });

        }
    </script>
</head>
<body style=" height:390px">
<table width="1054" border="0"  align="center" cellpadding="0" cellspacing="0">
  
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
                <td height="40" bgcolor="#1C1C1C">
                <table width="1028"  border="0" cellspacing="1" cellpadding="0">
                  
                  <tr>
                    <td height="30" colspan="4" align="left" class="STYLE11 STYLE12">
                    <table width="290" border="0" cellspacing="1" cellpadding="0">
                              <tr>
                                <td width="143" height="30" align="center" bgcolor="#FF8D1A"><span class="STYLE12">取款历史</span></td>
                                 <td width="144" align="center" bgcolor="#666666"><a href="loginWithdraw.aspx"><span class="STYLE11">我要取款</span></a></td>
                              </tr>
                    </table></td>
                   </tr>
                  <tr> 
                  <td>
                  <table class='tab2' id='tb2' width="100%" border="0" cellpadding="0" cellspacing="1" >
                    <thead  bgcolor="#353536" style=" height:30px">
                    <tr>
                    <th  bgcolor="#666666" style="color:#E3D8B8">序号</th>
                    <th  bgcolor="#666666" style="color:#E3D8B8">金额</th>
                    <th  bgcolor="#666666" style="color:#E3D8B8">时间</th>
                    <th  bgcolor="#666666" style="color:#E3D8B8">状态</th>           
                    </tr>
                    </thead>
                     <tbody id='showInfo' bgcolor="#353536">
                    </tbody>
                    </table>  
                   </td>              
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
