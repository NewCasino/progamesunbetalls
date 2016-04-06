<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReasonManager.aspx.cs" Inherits="agent.Report.ReasonManager"%> 

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="/css/Default/globle.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/right_main.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/tab.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/Default/cupertino/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/jQueryCommon.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var row = jQuery("#DataRows").clone();
            function Loaddata() {
                var url = "../ServicesFile/ReportService/ReasonService.asmx/GetData";
                var data = "id:'1'";
                jQuery.AjaxCommon(url, data, true, false, function (jsonResult) {
                    if (jsonResult.d != "none") {
                        var json = jQuery.parseJSON(jsonResult.d);
                        jQuery.each(json, function (index) {
                            var rows = jQuery("#DataRows").clone();
                            if (index == 0) {
                                $("#tab3 tr:gt(0)").remove();
                            } 
                            rows.find("#tdID").text(json[index].ID);
                            rows.find("#tdTitle").text(decodeURI(json[index].Title));
                            rows.find("#tdRemark").text(decodeURI(json[index].Remark));
                            rows.find("#tdEdite").html("<a href=\"javascript:void(0)\" id=m\"" + json[index].ID + "\" class=\"edit_01\" >修改</a>");
                            rows.find("#tdEdite").find("a").click(function () {
                                updateInfo(json[index].ID, $(row).prev().find("#tdTitle").text(), $(row).prev().find("#tdRemark").text(), row);
                                row.find("td:gt(0)").remove();
                                row.find("td:eq(0)").attr("colspan", "5");
                                $("#divUpdate").slideDown("50000").appendTo(row.find("td:eq(0)"));
                                rows.after(row);
                            });
                            rows.find("#tdDelete").html("<a href=\"javascript:void(0)\" class=\"delet_01\" id=d\"" + json[index].ID + "\">删除</a>");
                            rows.find("#tdDelete").find("a").click(function () {
                                funDelete(json[index].ID, this);
                            });
                            rows.appendTo("#tab3");
                        });
                    }
                });
            }



            function updateInfo(id, title, remark, the) {
                $("#txtEditeID").val(id);
                $("#txtEditeTitle").val(title);
                $("#txtEditeRemark").val(remark);
                $("#btnEditeUpdate").click(function () {
                    var url = "../ServicesFile/ReportService/ReasonService.asmx/UpdateData";

                    var data = "id:'" + encodeURI($("#txtEditeID").val()) + "',title:'" + encodeURI($("#txtEditeTitle").val()) + "',remark:'" + encodeURI($("#txtEditeRemark").val()) + "'";
                    $.AjaxCommon(url, data, true, false, function (json) {
                        if (json.d == "success") {
                            //获取当前行的上一行  
                            $(the).prev().find("#tdTitle").text($("#txtEditeTitle").val());
                            $(the).prev().find("#tdRemark").text($("#txtEditeRemark").val());
                            $("#divUpdate").hide("slow");
                            $.MsgTip({ objId: "#divTip", msg: "更新成功", delayTime: "1000" });
                            the.remove();



                        }
                    });
                });
                //隐藏层
                $("#btnEditeCancel").click(function () {
                    $("#divUpdate").fadeOut("1000").appendTo(jQuery("#form1"));
                    the.remove();
                });
            }


            //执行删除操作
            function funDelete(id, the) {
                $("#divDelete").dialog("open");
                $("#btnDeleteSubmit").click(function () {
                    var url = "../ServicesFile/ReportService/ReasonService.asmx/DeleData";
                    var data = "id:'" + id + "'";
                    $.AjaxCommon(url, data, true, false, function (jsonStr) {
                        if (jsonStr.d == "success") { }
                        $("#divDelete").dialog("close");
                        $(the).parents("tr:eq(0)").remove();
                        $.MsgTip({ objId: "#divTip", msg: "删除成功", delayTime: "2000" });
                    });
                });
            }
            $("#btnAddInfo").click(function () {
                var url = "../ServicesFile/ReportService/ReasonService.asmx/AddReason";
                var data = "title:'" + encodeURI($("#txtAddTitle").val()) + "',remark:'" + encodeURI($("#txtAddRemark").val()) + "'";
                $.AjaxCommon(url, data, true, false, function (jsonStr) {
                    var json = $.parseJSON(jsonStr.d);
                    //debugger;
                    if (json != "error") {
                        var rows = jQuery("#DataRows").clone();
                        rows.find("#tdID").text(json);
                        rows.find("#tdTitle").text($("#txtAddTitle").val());
                        rows.find("#tdRemark").text($("#txtAddRemark").val());
                        rows.find("#tdEdite").html("<a href=\"javascript:void(0)\" id=m\"" + json + "\" class=\"edit_01\" >修改</a>");
                        rows.find("#tdEdite").find("a").click(function () {
                            // updateInfo(json.ID, json.Title, json.Remark,row);
                            updateInfo(json, $(row).prev().find("#tdTitle").text(), $(row).prev().find("#tdRemark").text(), row);
                            row.find("td:gt(0)").remove();
                            row.find("td:eq(0)").attr("colspan", "5");
                            $("#divUpdate").slideDown("50000").appendTo(row.find("td:eq(0)"));
                            rows.after(row);
                        });


                        rows.find("#tdDelete").html("<a href=\"javascript:void(0)\" class=\"delet_01\" id=d\"" + json.Id + "\">删除</a>");
                        rows.find("#tdDelete").find("a").click(function () {
                            funDelete(json, this);

                        });
                        rows.appendTo("#tab3");
                        $("#divAdd").dialog("close");
                        $.MsgTip({ objId: "#divTip", msg: "增加成功", delayTime: "1000" });
                    }
                });

            });

            $("#divUpdate").dialog({ autoOpen: false, width: 300, height: 500, modal: false, resizable: false, bgiframe: true });
            $("#divAdd").dialog({ autoOpen: false, width: 400, height: 450, resizable: false, bgiframe: true, modal: true });
            $("#divDelete").dialog({ autoOpen: false, modal: true, resizable: false, bgiframe: true });
            $("#btnDeleteCancel").click(function () { $("#divDelete").dialog("close"); });
            $("#btnEditeCancel").click(function () { $("#divUpdate").slideUp("50000"); });
            $("#btnAddCancel").click(function () { $("#divAdd").dialog("close"); });
            jQuery("#btnAdd").click(function () {
                jQuery("#divAdd").dialog("open").attr("title", "新增数据");
            });
            window.onload = Loaddata;
        });
    </script>
        <style type="text/css">
    .ui-effects-transfer { border: 2px dotted gray; } 
        #divTip
        {
        	left:45%;top:45%; 
        	
        	font-family:sans-serif; position:absolute; font-size:10px;padding:5px;background:#f3f3f3;color:gray;display:none;-moz-border-radius:5px;-webkit-border-radius:5px;border:1px solid #ccc
        }

    </style>
</head>
<body style="text-align:center">
    <form id="form1" runat="server">
       <table>
           <thead>
            <tr class="h30">
            <th width="12" class="tab_top_l"></th>
            <th width="*" class="tab_top_m"><p>帐号管理</p></th>
            <th width="16" class="tab_top_r"></th>
            </tr>
            </thead>
            <tbody>
                <tr>
                    <td class="tab_middle_l"></td>
                    <td>
                        <div id="main">
                                <div class="top_banner h30">   
                                 <div class="f1"><input type="button" id="btnAdd"class="top_add" onmouseover="this.className='top_add_h'" onmouseout="this.className='top_add'"  value="增加原因" /></div> 
                                 </div>
                                 <div class="cl"></div>
                                 <table id="tab3" width="965" cellpadding=0 cellspacing="0" border=0 > 
                                        <tr>
                                            <th>标识符</th>
                                            <th>标题</th>
                                            <th>描述</th>
                                            <th>编辑</th>
                                            <th>删除</th>
                                        </tr>  
                                        <tr id="DataRows" style="text-align:center" class="datarow" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className=''">
                                            <td id="tdID" ></td>
                                            <td id="tdTitle" width="10%"></td>
                                            <td id="tdRemark"></td>
                                            <td id="tdEdite" width="6%"></td>
                                            <td id="tdDelete" width="6%"></td>
                                        </tr>  
                                    </table> 
                        </div>
                    </td>
                   <td class="tab_middle_r"></td></tr> 
            </tbody>
            <tfoot>
                <tr class="h35">
                <td width="12" class="tab_foot_l"></td>
                <td width="*" class="tab_foot_m"></td>
                <td width="16" class="tab_foot_r"></td>
                </tr>
                </tfoot>
       </table>
    </form> 
            <div id="divAdd" style="display:none; text-align:center;" title="新增数据">  
                        标题:<input  id="txtAddTitle" type="text" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'"/><br /><br /> 
                        内容: <textarea rows="7" cols="40" id="txtAddRemark"></textarea><br /><br /> 
                        <input  id="btnAddInfo" value="新增" type="button" class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'"/> 
                        <input  id="btnAddCancel" value="取消" type="button" class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'"/> 
                       
            </div>
            <div id="divUpdate" style="display:none; text-align:center" title="编辑数据"> 
                        <input  type="hidden" id="txtEditeID"/><br />
                        标题:<input  id="txtEditeTitle" type="text" class="text_01 h20 w_120" onmouseover="this.className='text_01_h h20 w_120'" onmouseout="this.className='text_01 h20 w_120'"/><br /><br /> 
                        内容:<textarea  id="txtEditeRemark" rows="7" cols="40"></textarea> <br /><br />  
                        <input  id="btnEditeUpdate" value="更新" type="button" class="btn_02"  onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'"/> 
                        <input  id="btnEditeCancel" value="取消" type="button" class="btn_02"  onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'"/>
                   
            </div>
            <div id="divDelete" style="text-align:center" title="删除提示">
                <p class="wrnning">确定要删除此项吗？</p>
                <div align="center" class="mtop_50">
                    <input type="button" id="btnDeleteSubmit" class="btn_02" value="确定" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" />
                    <input type="button" id="btnDeleteCancel" class="btn_02" onmouseover="this.className='btn_02_h'" onmouseout="this.className='btn_02'" value="取消" /> 
                </div>
            </div>
            <div id="divTip" ></div>
</body>
</html>
