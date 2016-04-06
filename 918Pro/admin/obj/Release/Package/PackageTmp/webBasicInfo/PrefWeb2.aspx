<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrefWeb2.aspx.cs" Inherits="admin.webBasicInfo.PrefWeb2" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type">
        <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
   <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
     <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
     <link href="/css/Default/pagination.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
        <script src="/js/jQueryCommon.js" type="text/javascript"></script>
    <script src="/js/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
    <script src="/js/webBasicInfo/zh-CN.js" type="text/javascript"></script>
    <link href="/css/Default/cupertino/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
      <script type="text/javascript">
          jQuery(function () {

              $('#Select1').change(function(){ 
                 var p1=$(this).children('option:selected').val();
                  $('#type_22').val(p1);
              }) 

              if ($('#Select1').val() == 0) {
                  $('#type_22').val('0');
              } else {
                  $('#type_22').val('1');
              }


          });
         

      </script>
</head>

<body>  

 <form id="form1" runat="server">
     <div id="fragment-2">
     <br />
     <span style=" font-size:16px; color:Blue; font-weight:800">新增活动:</span><br /> <br />
      <table border="1">
         <tr>
       <td><span>活动类型：</span></td>
       <td> 
           <select id="Select1" >
               <option  value=0  i selected>会员活动</option>
               <option value=1>特殊活动</option>
           </select><span style='color:red'>*必填项</span>
           <input type="hidden" value='' id="type_22"  runat=server/>
       </td>
       </tr>

       <tr>
       <td><span>活动标题：</span></td>
       <td> <asp:TextBox ID="txtTitle" CssClass="text h24 w_500" runat="server"></asp:TextBox><span style='color:red'>*必填项</span></td>
       </tr>
       <tr>
       <td><span>首页大图：</span></td>
       <td> <asp:FileUpload ID="fileAccessories" CssClass="file" runat="server"/><span style='color:red'>*必填项</span>
          </td>
       </tr>

        <tr>
       <td><span>优惠页小图：</span></td>
       <td><asp:FileUpload ID="FileUpload1" CssClass="file" runat="server"/><span style='color:red'>*必填项</span> 
          </td>
       </tr>

       

        <tr>
       <td><span>内 容：</span></td>
       <td> <FCKeditorV2:FCKeditor ID="FCKeditor" runat="server" Width="740px" Height="413px">
                    </FCKeditorV2:FCKeditor>&nbsp;&nbsp;<span style=" color:red">*</span></td>
       </tr>

       <tr>
       <td  colspan="2" style=" text-align:center">
       <asp:Button ID="bntAddNews" runat="server" CssClass="btn_04" Text="提 交" 
               style=" width:80px; height:30px; background-color: #CCCCFF;" 
               onclick="bntAddNews_Click" />
&nbsp;
 <asp:Button ID="Closebank" runat="server" CssClass="" Text="返回活动页" 
               style=" width:80px; height:30px;background-color: #CCCCFF;" 
               onclick="Closebank_Click"/>
       
       </td>
       
       </tr>
       </table>
     
    </div>
    </form> 
</body>
</html>
