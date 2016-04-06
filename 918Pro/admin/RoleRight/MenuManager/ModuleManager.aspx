<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModuleManager.aspx.cs" EnableViewState="false" Inherits="admin.RoleRight.MenuManager.ModuleManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/jQueryCommon.js"></script>
    <script type="text/javascript" src="/js/jQueryCommon_min.js"></script>
    <script type="text/javascript" src="/js/AddModule.js"></script>
    <style type="text/css">
        .ParentMenu
        {
            font-size:22px;	
            font-weight:bold; 
            height:25px;
            text-align:center;
            cursor:pointer;
        }
        .editModueClass
        {
             cursor:pointer;	
        }
        .input_on{
padding:2px 8px 0pt 3px;
height:18px;
border:1px solid #4ac0f8;
background-color:#e0f8ff;
line-height:18px;
}
.input_off{
padding:2px 8px 0pt 3px;
height:18px;
border:1px solid #89c0f2;
background-color:#FFF;
line-height:18px;
}
.input_move{
padding:2px 8px 0pt 3px;
height:18px;
border:1px solid #4ac0f8;
background-color:#e0f8ff;
line-height:18px;
}
.input_out{
/*height:16px;默认高度*/
padding:2px 8px 0pt 3px;
height:18px;
border:1px solid #89c0f2;
background-color:#FFF;
line-height:18px;
}
        .btn_01{ width:59px; height:21px; border:0px; color:#09C; line-height:21px;}
.btn_01_h{ width:59px; height:21px; border:1px solid ;background-color:#e0f8ff;  color:#09C;line-height:21px;}

    </style>
   
</head>
<body>
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th id="module" width="*" class="tab_top_m"><p>模块管理</p></th>
<th width="16" class="tab_top_r"></th>
</tr>
</thead>

<tbody>
<tr>
<td class="tab_middle_l"></td>
<td >
<div id="main">
<!--主题部分开始=========================================================================================-->
<div class="top_banner h30">

<div class="f1"><input type="button" id="addBtn" onclick="addModule()" class="top_add" onmouseover="this.className='top_add_h'" onmouseout="this.className='top_add'"  value="添加模块" />
<input type="button" id="operBtn" onclick="window.location='ModuleOperate.aspx'" class="top_add" onmouseover="this.className='top_add_h'" onmouseout="this.className='top_add'"  value="模块操作管理" />
</div>



</div>
<div class="cl"></div>
    <table id="tab3" width=100% cellpadding=0 cellspacing="0" border=0 >
        <thead> 
        <tr>
        <th class="name">模块名称</th>
        <th class="url">模块链接地址</th>
        <th class="operate">模块所具有的操作</th>
        <th class="modify">修改</th>
        <th class="status">状态</th>
        </tr>
        </thead> 
        <tbody id="tbdRow">

        </tbody> 

        <tfoot>
        <tr>
        <td colspan="10">

            &nbsp;</td>
        </tr>
        </tfoot>
        </table>

            <div id="blk9" class="blk" style='display:none; '>
        <div class="head"><div class="head-right"></div></div>
            <div class="main">
                <table width="100%" cellpadding="5" >
                    <tr>
                        <th colspan='3' id="OperateType">添加数据</th>
                    </tr>
                    <tr>
                        <td class="select" align="right" width="130px">选择模块:</td> 
                        <td align="left"><select id="selModuleList"><option value="ROOT_MENU">添加一个父模块</option></select></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td class="name" align="right">模块名称:</td>
                        <td align="left"><input type="text" id="txtModuleName" size="40" class="input_out"onfocus="this.className='input_on';this.onmouseout=''" onblur="this.className='input_off';this.onmouseout=function(){this.className='input_out'};" onmousemove="this.className='input_move'" onmouseout="this.className='input_out'" /></td>
                        <td></td>
                    </tr>
                    <tr id="trUrl" style="display:none;">
                        <td id="corrurl" align="right">模块对应的地址(URL):</td>
                        <td align="left"><input type="text" id="txtModuleUrl" size="40" class="input_out"onfocus="this.className='input_on';this.onmouseout=''" onblur="this.className='input_off';this.onmouseout=function(){this.className='input_out'};" onmousemove="this.className='input_move'" onmouseout="this.className='input_out'" /></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td id="tips" align="right">模块提示说明:</td>
                        <td align="left"><input type="text" id="txtModuleTip" size="40" class="input_out"onfocus="this.className='input_on';this.onmouseout=''" onblur="this.className='input_off';this.onmouseout=function(){this.className='input_out'};" onmousemove="this.className='input_move'" onmouseout="this.className='input_out'" /></td>
                        <td></td>
                    </tr>
                    <tr id="trTarget" style="display:none;">
                        <td id="viewway" align="right">模块查看方式:</td>
                        <td align="left"><select id="selTarget"><option value="1">在框架中查看</option><option value="2">打开新的窗口查看</option></select></td>
                        <td></td>
                    </tr>
                    <tr id="trOperate" style="display:none;">
                        <td align="right" id="grant">模块授权:</td>
                        <td colspan="2" id="tdOperate" align="left"></td>
                    </tr>
                    <tr id="trStatus">
                        <td align="right" id="status">模块状态:</td>
                        <td align="left"><select id="selStatus"><option value="1">启用</option><option value="2">禁用</option></select></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="2" align="left"><br /><input type="button"  class="btn_02"  value="确 认" id="btnSure"/> &nbsp;&nbsp;<input type="button" class="btn_02" value="取 消" id="btnCancel" /></td>
                    </tr>
                </table>
            </div>
         <div class="foot"><div class="foot-right"></div></div>
    </div>




</div>
<!--主题部分结束=========================================================================================-->
</div>
</td>
<td class="tab_middle_r"></td>
</tr>
</tbody>
<tfoot>
<tr class="h35">
<td width="12" class="tab_foot_l"></td>
<td width="*" class="tab_foot_m">

</td>
<td width="16" class="tab_foot_r"></td>
</tr>
</tfoot>

</table>
<div id="loading"></div>
<div id="divTip" ></div>

</body>
</html>
