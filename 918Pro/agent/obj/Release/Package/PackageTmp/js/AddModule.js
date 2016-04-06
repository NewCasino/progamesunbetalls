jQuery(function() {
    LoadData();
    
    $("#blk9").dialog({
        bgiframe: true,
        autoOpen: false,
        width: '500',
        height: '500'
    });
    jQuery("#btnCancel").click(function() {
        jQuery("#blk9").dialog("close");
    });
    jQuery("#btnSure").click(function() {
        var $name = jQuery("#txtModuleName");
        var $tip = jQuery("#txtModuleTip");
        var $url = jQuery("#txtModuleUrl");
       // debugger
        if (!ShowTip($name, $tip)) {
            return;
        }
        var operate = "";
        if (operateType == "add") {  //Add Module

            var $selModule = jQuery("#selModuleList :selected");
            var urlModule = "";

            var target = "";
            var status = jQuery("#selStatus :selected").val();
            if ($selModule.val() == "ROOT_MENU") { //Add Parent Module

            }
            else {
                //Add Child Module

                if (jQuery.trim($url.val()) == "") {
                    ShowAlert("模块添加提示", "地址不能为空");
                    $url.focus();
                    return;
                }
                if (jQuery.trim($url.val()).length > 200) {
                    $url.focus();
                    $url.select();
                    ShowAlert("模块添加提示", "地址长度不能大于200个字符");
                    return;
                }
                urlModule = $url.val();
                operate = GetChecked();
                status = jQuery.trim(jQuery("#a" + $selModule.val()).html()) == "禁用" ? "0" : "1";

            }
            target = jQuery("#selTarget :selected").val();
            var url = "/ServicesFile/RoleRightService/RoleRightService.asmx/AddModule";
            var data = "moduleParent:'" + $selModule.val() + "',text:'" + $name.val() + "',url:'" + urlModule + "',tip:'" + $tip.val() + "',target:'" + target + "',status:'" + status + "',operate:'" + operate + "'";
            AjaxCommon(url, data, false, false, function(json) {
                if (json.d != "none") {  //Add Success
                    LoadData();
                }

            }, toError);
            jQuery("#blk9").dialog("close");


        }
        else {   //sure update module
            if (codes.length == 3) {  //update parent module
            debugger
                var url = "/ServicesFile/RoleRightService/RoleRightService.asmx/UpdateParentModule";
                var data = "text:'" + $name.val() + "',tip:'" + $tip.val() + "',moduleCode:'" + codes + "'";
                AjaxCommon(url, data, false, false, function(json) {

                    if (json.d) {
                        LoadData();
                        num = 1;
                        aa = 1;
                    }
                }, toError);

            }
            else { 
           // debugger
                operate = GetChecked();

                var beforeOperate = jQuery("#img" + codes).parent().prev().children("input:hidden").val();
                
                operate = beforeOperate == operate ? "" : operate;
                var b = new Array();
                var o = new Array();
                b = beforeOperate.split(',');
                o = operate.split(',');

                var operateArr = new Array();
                operateArr = hebing(b, o);
                var newOperate = "";
                if (operateArr != "") {
                    for (var i = 0; i < operateArr.length; i++) {
                        if (operateArr[i] == 1) continue;
                        newOperate += operateArr[i] + ",";
                    }
                    newOperate = newOperate.substr(0, newOperate.length - 1);

                }


                var url = "/ServicesFile/RoleRightService/RoleRightService.asmx/UpdateChildModule";
                var data = "text:'" + $name.val() + "',url:'" + $url.val() + "',tip:'" + $tip.val() + "',target:" + jQuery("#selTarget :selected").val() + ",moduleCode:'" + codes + "',operate:'" + operate + "'";
                AjaxCommon(url, data, false, false, function(json) {
                    if (json.d) {
                        LoadData();
                    }
                }, toError);
            }
            jQuery("#blk9").dialog("close");

        }
        $name.val("");
        $tip.val("");
        $url.val("");
        jQuery("#selModuleList")[0].selectedIndex = 0;
        jQuery("input:checkbox:gt(0)").attr("checked", false);
        jQuery("#trOperate").hide();
        jQuery("#trTarget").hide();
        jQuery("#trUrl").hide();
    });

});

function hebing(a1,a2){
var newarr=new Array();
for (var k1 in a1){
 newarr[k1]=a1[k1];
 }
for (var k2 in a2){
 newarr[k2]=a2[k2];
 } 
 return newarr;
}

function GetChecked() {

    var a = "";
    var checkedBox = jQuery("input:checkbox");
    for (var i = 0; i < checkedBox.length; i++) {
        if (checkedBox[i].checked) {
            a += checkedBox[i].value + ",";
        }
    }
    a = a.substr(0, a.length - 1);
    
    return a;
}

function ShowTip($name, $tip) {
    if (jQuery.trim($name.val()) == "") {
        ShowAlert("模块添加提示", "模块名称不能为空");
        $name.focus();
        return false;
    }
    if (jQuery.trim($tip.val()) == "") {
        ShowAlert("模块添加提示", "模块提示说明不能为空");
        $tip.focus();
        return false;
    }
    if (jQuery.trim($name.val()).length > 50) {
        ShowAlert("模块添加提示", "模块名称长度不能大于50个字符");
        $name.focus();
        $name.select();
        return false;
    }

    if (jQuery.trim($tip.val()).length > 50) {
        ShowAlert("模块添加提示", "模块提示说明长度不能大于50个字符");
        $tip.focus();
        $tip.select();
        return false;
    }
    return true;
}

function ShowAlert(title,content) {
    var pop = new Popup({ contentType: 4, isReloadOnClose: false, width: 340, height: 80 });
    pop.setContent("title", title);
    pop.setContent("alertCon", content);
    pop.setContent("closeImage", "/Agent/agentImg/x.jpg");
    pop.setContent("bgImage", "/Agent/agentImg/bg_header02.jpg");
    pop.setContent("bgImageHeight", "22px");
    pop.setContent("tColor", "#CCCCCC"); 
    pop.build();
    pop.show();
}


var num = 1;
var operateType = "";
function addModule() {

    var $name = jQuery("#txtModuleName");
    var $tip = jQuery("#txtModuleTip");
    var $url = jQuery("#txtModuleUrl");
    
    jQuery("#trStatus").show();
    if (jQuery("#OperateType").text() == "修改数据") {
        $name.val("");
        $tip.val("");
        $url.val("");
        jQuery("input:checkbox:gt(0)").attr("checked",false);
        jQuery("#trOperate").hide();
        jQuery("#trTarget").hide();
        jQuery("#trUrl").hide();
        jQuery("#selModuleList")[0].selectedIndex=0;
    }
    jQuery("#blk9").dialog("open");
     operateType = "add";
     if (num == 1) {
         if(aa==1)
            LoadSelData();
         var count = 1;
         jQuery("#selModuleList").bind("change", function() {
             if (jQuery("#selModuleList :selected").val() == "ROOT_MENU") { 
                 jQuery("#trOperate").hide();
                 jQuery("#trTarget").hide();
                 jQuery("#trUrl").hide();
             }
             else {
                 if (count == 1 &&aa==1) { 
                     LoadOperate();
                 }
                 jQuery("#trTarget").show();
                 jQuery("#trOperate").show();
                 jQuery("#trUrl").show();
                 jQuery("input:checkbox:eq(0)").attr({ "disabled": "disabled", "checked": "checked" });
                 count++;
             }
         });
     }
     num++;
     
     jQuery("#OperateType").text("添加数据");
     jQuery("#selModuleList").attr("disabled","");
}

function LoadOperate() {
    jQuery("#tdOperate").html("");
    var url = "/ServicesFile/RoleRightService/RoleRightService.asmx/GetModuleOperate";
    AjaxCommon(url, "", false, false, function(json) {
        if (json.d != "none") {
            var result = eval("(" + json.d + ")");
            var strHtml = "";
            jQuery.each(result, function(i) {
                strHtml += "<input type='checkbox' value='" + result[i].OperateID + "' />" + result[i].Operate_text + "&nbsp;&nbsp;";
            });
            jQuery("#tdOperate").append(strHtml);
        }
    }, toError);
}

function LoadSelData() {
    jQuery("#selModuleList>option:gt(0)").remove();
    var url = "/ServicesFile/RoleRightService/RoleRightService.asmx/GetRootModule";
    AjaxCommon(url, "", false, false, function(json) {
        if (json.d != "none") {
            var result = eval("(" + json.d + ")");
            jQuery.each(result, function(i) {
                jQuery("#selModuleList").append("<option value='" + result[i].Module_code + "'>" + result[i].Module_text + "</option>");
            });
        }
    }, toError);
}

function LoadData() {

    var url = "/ServicesFile/RoleRightService/RoleRightService.asmx/GetSysModules";
    AjaxCommon(url, "", false, false, function(json) {
        if (json.d != "none") {
            jQuery("#tbdRow").show();
            var result = eval("(" + json.d + ")");
            var strHtml = "";
            jQuery("#tbdRow").html("");
            jQuery.each(result, function(i) {
                var status = result[i].Status == "1" ? "启用" : "禁用";
                if (result[i].Module_code.length == 3) {
                    strHtml += "<tr class='ParentMenu' id='" + result[i].Module_code + "' ><td colspan='3'>" + result[i].Module_text + "</td><td><input type='hidden' value='" + result[i].Module_tip + "' /><img src='/images/icon/Icon414.png' title='修改' class='editModueClass' id='img" + result[i].Module_code + "' /></td><td><a href='javascript:void(0)' id='a" + result[i].Module_code + "' class='status'>" + status + " </a></td></tr>";
                }
                else {
                    
                    //var url1 = "/ServicesFile/RoleRightService/RoleRightService.asmx/GetModuleRightByCode";
                    var url1 = "/ServicesFile/RoleRightService/RoleRightService.asmx/GetModuleRightOperateByCode";
                    var data1 = "code:'" + result[i].Module_code + "'";
                    var operateStr = "";
                    var operateIdStr = "";

                    AjaxCommon(url1, data1, false, false, function(json1) {

                        if (json1.d != "none") {
                            var resultRight = eval("(" + json1.d + ")");
                            jQuery.each(resultRight, function (j) {
                            
                                operateStr += resultRight[j].Operate_text + ",";
                                operateIdStr += resultRight[j].OperateID + ",";
                            });

                        }
                        else {

                        }

                        operateStr = operateStr.substr(0, operateStr.length - 1);
                        operateIdStr = operateIdStr.substr(0, operateIdStr.length - 1);
                        strOperate = operateStr.length > 30 ? operateStr.substr(0, 30) + "..." : operateStr;
                        strHtml += "<tr class='child" + result[i].Module_code + "' align='center' bgcolor='#F6F8F9'><td>" + result[i].Module_text + "</td><td>" + result[i].Module_url + "</td>  <td><input type='hidden' value='" + operateIdStr + "' />" + strOperate + "</td><td><input type='hidden' value='" + result[i].Module_tip + "' /><img src='/images/icon/Icon414.png' title='修改' class='editModueClass' id='img" + result[i].Module_code + "' /><input type='hidden' value='" + result[i].Module_target + "' /></td><td><a href='javascript:void(0)' id='a" + result[i].Module_code + "' class='status'>" + status + " </a></td></tr>";
                    }, toError);


                }

            });

            
            $("#tbdRow").append(strHtml);
        }
        else {
            jQuery("#tbdRow").hide();
        }
    }, toError);
    jQuery("tr.ParentMenu").bind("click",function() {
        jQuery(this).siblings("tr[class^='child" + this.id + "']").toggle();
    });
    jQuery("a.status").bind("click", function () {
        var code = this.id.substr(1);
        var url = "/ServicesFile/RoleRightService/RoleRightService.asmx/UpdateStatus";
        var data = "status:'" + jQuery(this).text() + "',moduleCode:'" + code + "'";
        var $status = jQuery(this);
        AjaxCommon(url, data, false, false, function (json) {
            if (json.d != "none") {
                if (json.d == "all") {
                    LoadData();
                }
                else {
                    //$status.parent().parent().siblings("#" + $status.attr("id").substr(1, 3)).find("a.status").text("启用");
                    //                    if ($status.text() == "启用")
                    //                        $status.text("禁用");
                    //                    else
                    //                        $status.text("启用");

                    LoadData();

                }
            }
            else {
                alert("操作失败");
            }
        }, toError);
        return false;
    });
    jQuery("img.editModueClass").bind("click", function(event) {
        jQuery("#trStatus").hide();
        jQuery("#OperateType").text("修改数据");
        jQuery("#blk9").dialog("open");
        jQuery("#selModuleList").attr("disabled", "disabled");
        operateType = "update";
        codes = this.id.substr(3);
        var $currentObj = jQuery(this);
        var $moduleName = jQuery("#txtModuleName");
        var $moduleTip = jQuery("#txtModuleTip");
        var $moduleUrl = jQuery("#txtModuleUrl");
        var operateIdArr = new Array()
        if (codes.length == 3) { 
            jQuery("#selModuleList")[0].selectedIndex = 0;
            jQuery("#trOperate").hide();
            jQuery("#trTarget").hide();
            jQuery("#trUrl").hide();
            jQuery("input:checkbox:gt(0)").attr("checked", false);
            $moduleName.val($currentObj.parent().prev("td").text());
            $moduleUrl.val("");
        }
        else {  
            LoadOperate();
            if (num == 1 && aa == 1) {
                LoadSelData();
                
                jQuery("input:checkbox:eq(0)").attr({ "disabled": "disabled", "checked": "checked" });
            }
            
            jQuery("#trOperate").show();
            jQuery("#trTarget").show();
            jQuery("#trUrl").show();
            $moduleName.val($currentObj.parent().siblings("td:first").text());
            $moduleUrl.val($currentObj.parent().siblings("td:eq(1)").text());
            aa++;
            jQuery("#selTarget>option[value='" + $currentObj.next("input:hidden").val() + "']").attr("selected", "selected");
            jQuery("#selModuleList>option[value='" + codes.substr(0, 3) + "']").attr("selected", "selected");
            var ids = $currentObj.parent().prev().children("input:hidden").val();
            if (ids.length > 1)
                operateIdArr = ids.split(',');
            else
                operateIdArr[0] = ids;

        }

        jQuery("input:checkbox:gt(0)").attr("checked", false);
        jQuery("input:checkbox:eq(0)").attr({ "disabled": "disabled", "checked": "checked" });
        var $checkbox = jQuery("input:checkbox");
        for (var i = 0; i < operateIdArr.length; i++) {
            for (var j = 0; j < $checkbox.size(); j++) {
                if (operateIdArr[i] == $checkbox[j].value) {
                    $checkbox[j].checked = true;
                    break;
                }
            }
        }
        $moduleTip.val($currentObj.prev("input:hidden").val());
        return false;
    });
}
var codes="";
var aa = 1;
