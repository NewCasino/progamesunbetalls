<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginExpenses.aspx.cs" Inherits="agent.loginExpenses" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    
    <link href="../css/Agent/loginExpenses.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
    <script src="/js/page/pageJs.js" type="text/javascript"></script>
    <script src="/js/jQueryCommon_div.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        $(function () {
            GetEVnMonInfo();
        });

        function GetEVnMonInfo() {
//            var url = "/ServicesFile/UserService.asmx/GetEVnMonInfo";
//            var Wcount = 0;
//            $.AjaxCommon(url, "", true, false, function (json) {
            $.AjaxCommon({
                url: "/ServicesFile/UserService.asmx/GetEVnMonInfo",
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
                        var html = "", total1 = 0, total2 = 0; total3 = 0;
                        $.each(re, function (i) {
                            //debugger

                            // total1 += parseFloat(re[i].Cgamount);


                            html += "<tr><td style=' text-align:center;height:30px'>" + re[i].datetime + "</td>";
                            html += "<td style=' text-align:center;height:30px;bgcolor:#2A2B2B'>" + parseFloat(re[i].SYamount - re[i].Qgamount) + "</td>";
                            html += "<td style=' text-align:center;height:30px'>" + re[i].HLamount + "</td>";
                            html += "<td style=' text-align:center;height:30px'>" + re[i].FSamount + "</td>";

                            html += "<td style=' text-align:center;height:30px'>0</td>";
                            // debugger
                            var _YLamount = parseFloat(re[i].SYamount - re[i].Qgamount - re[i].HLamount - re[i].FSamount);
                            if (_YLamount < 0) {

                                html += "<td style='color:#FF5050;text-align:center;height:30px'>" + _YLamount + "</td>";
                            }
                            else {
                                html += "<td style=' text-align:center;height:30px'>" + _YLamount + "</td>";
                            }

                            html += "</tr>";
                        });
                        //  html += "<tr><td>总计</td><td colspan='1'></td><td >" + total1.toFixed(2) + "</td><td >" + total2.toFixed(2) + "</td>";
                        html += "</tr>";
                        $("#tb2>tbody").html(html);

                    }

                    else {

                        $("#tb2>tbody").html("<tr><td style=' text-align:center;' colspan=\"6\">没有相应数据</td></tr>");
                    }
                }
            });

        }

    </script>
</head>
<body style=" height:350px">
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
                                <td class="STYLE6">费用支出</td>
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
         
            <td>        
             <table class='tab2' id='tb2' width="100%" border="0" cellpadding="0" cellspacing="1" >
            <thead  bgcolor="#353536" style=" height:30px">
            <tr>
            <th  bgcolor="#666666" style="color:#E3D8B8">月份</th>
            <th  bgcolor="#666666" style="color:#E3D8B8">公司输赢</th>
            <th  bgcolor="#666666" style="color:#E3D8B8">红利</th>
            <th  bgcolor="#666666" style="color:#E3D8B8">返水</th>            
            <th  bgcolor="#666666" style="color:#E3D8B8">其他费用</th>
            <th  bgcolor="#666666" style="color:#E3D8B8">赢利</th>
            </tr>
            </thead>
            <tbody id='showInfo' bgcolor="#353536">
            </tbody>
            </table>
            
            </td>
          
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
