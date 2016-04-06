<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPwd.aspx.cs" Inherits="agent.UserPwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>  
    <div>
    <ul>
     <li>
      <span  style=" color:Blue; font-size:15px; font-weight:700">修改密码</span>
     </li>
     <li><span style=" color:Blue; font-size:13px">原密码:</span>&nbsp;<input type="text" value="" /></li>
     <li><span style=" color:Blue; font-size:13px">新密码:</span>&nbsp;<input type="text" value="" /></li>
     <li><span style=" color:Blue; font-size:13px">确认密码:</span><input type="text" style="  margin-left:3px" value="" /></li>
     <li style=" text-align:left"> <input type="button" id="btnupdwd"  style="  margin-left:80px"  value="提交" />&nbsp;<input type="button" id="Button1"   value="关闭" /></li>
    </ul>
   
    </div>
    
</body>
</html>
