<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADList.aspx.cs" Inherits="agent.Report.ADList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <style type="text/css">
    .ui-effects-transfer { border: 2px dotted gray; } 
    </style>
    <script type="text/javascript">
        var spManagerId = parent.document.getElementById("spManagerId").innerHTML;
        $(function () {
            $("#adlink").html("http://www.10sun.com/?aid=" + spManagerId);
            $("#tab3 .btn_01").click(function () {
                $("#linkcode").val($(this).parent().parent().find("td:eq(1)").html());
                $("#add").dialog({
                    modal: true,
                    width: 650
                });
            });
            $("#copylink").click(function () {
                copy_code($("#adlink").html());
            });
            $("#adcode").click(function () {
                copy_code($("#linkcode").val());
            });
            $("#tab3 a").attr("href", "http://agent.do44.com/?aid=" + spManagerId);
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
    
    <title>广告链接</title>
</head>
<body >
<table  id="right_main" border="0" width="100%" cellpadding="0" cellspacing="0">
<thead>
<tr class="h30">
<th width="12" class="tab_top_l"></th>
<th width="*" class="tab_top_m"><p><font class="st"> 您当前的位置：</font><a href="javascript:void(0)"><span> 广告链接</span></a></p></th>
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
<div class="fl">
您的推广链接：<span id="adlink">http://www.10sun.com/?aid=</span>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
<input type="button" id="copylink" class="btn_01" onmouseover="this.className='btn_01_h'" onmouseout="this.className='btn_01'" value="复制" />

</div>

</div>
<div class="cl"></div>
<table id="tab3" width=100% cellpadding=0 cellspacing="0" border=0 >
<thead> 
<tr>
<th>序号</th>
<th>广告图片</th>
<th>图片尺寸</th>
<th>图片类型</th>
<th>操作</th>
</tr>
</thead> 
<tbody id="tab">
<tr>
<td>1</td>
<td>
    <a href="#" target="_blank"><img src="http://agent.do44.com/images/AD/150x50.gif" /></a>
</td>
<td>150x50 </td>
<td>gif</td>
<td><input type="button" class="btn_01" onmouseover="this.className='btn_01_h'" onmouseout="this.className='btn_01'" value="生成链接" /></td>
</tr>
<tr>
<td>2</td>
<td><a href="#" target="_blank"><img src="http://agent.do44.com/images/AD/460ch90-127.gif" /></a></td>
<td>460x90 </td>
<td>gif</td>
<td><input type="button" class="btn_01" onmouseover="this.className='btn_01_h'" onmouseout="this.className='btn_01'" value="生成链接" /></td>
</tr>

</tbody> 

</table>
<script src="/js/tab3.js" type="text/javascript"></script>


<div class="undis">

<div id="add" title="广告代码" >
<div class="showdiv">
<ul>
<li>
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
</li>
</ul>
</div>
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
</body>
</html>