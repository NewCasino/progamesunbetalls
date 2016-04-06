/*

Copyright ﹫2009-2010 Liu  
version :jQueryCommon 2.3

* 必须结合jQuery使用 通用的脚本函数
* AjaxCommon 函数的使用：
* 1.url 表示请求地址,datas表示请求的参数格式为(String类型:'字符串',Int类型:20)
* 2.asy 同步请求还是异步请求，true 为同步，false 为异步
* 3.cache 是否缓存页面,true为缓存,false为不缓存
* 4.toSuccess 请求成功的回调函数
* 5.loading 加载显示层的id 必须是 “#Id” 这种格式，此项可以为空，
*   如果设置 必须要设置leftLoading和topLoading的值，否则讲无效果
* 6.leftLoading 加载标识 离浏览器左边的距离 ，此项可为空
* 7.topLoading 加载标识 离浏览器上边的距离，此项可为空
* 8.调用方法：jQuery.AjaxCommon(params);
*/
(function ($) {
    $.extend({
        "toError": function (err, obj) {
            var strHtml = "<div style='color:Red;font-size:18px;' title='错误提示' ></div>";
            var $msg = $(strHtml);
            try {
                $msg.html(err.responseText);
            }
            catch (e) {
                $msg.html("由于你当前网络不稳定，暂时无法连接到服务器");

            }

            $msg.append("<input type='button' id='btnReRequest' value='重新请求' />");
            try {
                $msg.dialog({ modal: true });
                $("#btnReRequest").unbind("click");
                $("#btnReRequest").button();
                $("#btnReRequest").bind("click", function () {
                    $msg.dialog("close");
                    alert(obj);
                    $(obj).click();
                });
            } catch (e)
            { }

        },
        "SystemTip": function (options) {
            options = $.extend({
                divId: "divDel", titleStr: "", msgStr: "", triggerId: "txtHide"
            }, options);

            if ($("#" + options.divId).html() == null) {
                var htmlDiv = "<div id='" + options.divId + "' title='" + options.titleStr + "' style='display:none; text-align:center;'><p style='font-size:16px;'><b>" + options.msgStr + "</b></p><br /><input type='button' id='btnTipSure' value='确定' />&nbsp;&nbsp;&nbsp;&nbsp;<input type='button' id='btnTipCancel' value='取消' /></div>";
                $('body').append(htmlDiv);
            }
            try {
                $("#" + options.divId).dialog({ modal: true, resizable: false, close: function () {
                    $("#" + options.divId).dialog("destroy");
                }
                });
            } catch (e) {
                alert("请引入jQuery UI的脚本及样式");
            }
            $("#btnTipSure").val(languages.确定);
            $("#btnTipCancel").val(languages.取消);
            $("#btnTipSure").unbind("click");
            $("#btnTipCancel").unbind("click");
            $("#" + options.divId).find("b").html(options.msgStr);
            $("#ui-dialog-title-" + options.divId).html(options.titleStr);
            $("#btnTipSure").button().click(function () {
                $("#" + options.triggerId).triggerHandler("click");

            });
            $("#btnTipCancel").button().click(function () {
                $("#" + options.divId).dialog("close");
            });
        },
        "MsgTip": function (options) {
            options = $.extend({
                objId: "",
                msg: "",
                delayTime: 2500,
                hideTime: 1000,
                left: "45%",
                top: "35%",
                msgId: ""
            }, options);
            $(options.objId).css({ "opacity": 1, "left": options.left, "top": options.top });

            if ($(options.objId + ":not(:animated)")) {
                if (options.msgId != "") {
                    $(options.objId).find(options.msgId).html(options.msg);
                }
                else {
                    $(options.objId).html(options.msg);
                }
                $(options.objId).show().delay(options.delayTime).animate({ opacity: 0 }, options.hideTime, function () {
                    $(options.objId).hide();
                });
            }
        },
        "AjaxCommon": function (url, datas, asy, cache, toSuccess, loading, reqObjId) {

            var global = true;
            if (loading != undefined) {
                $(loading).ajaxStart(function () {
                    //$(this).css({ "background": "", "height":40 });
                    $(this).dialog({ modal: true, width: 60, height: 100, draggable: false, resizable: false, hide: "slide" });
                    $(this).dialog("widget").css({ "height": "60px", "width": "60px", "overflow": "hidden", "border": "none", "opacity": 0.5 });
                    $(this).prev().hide();
                }).ajaxStop(function () {
                    $(this).dialog('close');
                    $(this).dialog('destroy');
                }).ajaxError(function () {
                    $(this).dialog('close');
                    $(this).dialog('destroy');
                });
            }
            else {
                global = false;
            }
            $.ajax({
                contentType: "application/json",
                type: "POST",
                dataType: "json",
                url: url,
                cache: cache,
                data: "{" + datas + "}",
                async: asy,
                global: global,
                success: function (json) {
                    toSuccess(json);
                },
                beforeSend: function (xhr) { },
                complete: function (xhr) { },
                error: function (err) {
                    $.toError(err, reqObjId);
                }
            });
        }, "SetOrGetLanguage": function (setLang, setLanguage) {
            var lan = "";
            if (setLang == "") {
                lan = $.cookie("lan");
                if (!lan) {
                    lan = window.navigator.language;
                    if (!lan) {
                        lan = window.navigator.browserLanguage;
                    }
                }
            }
            else {
                lan = setLang;
            }
            $.cookie("lan", lan, { path: "/", expires: 10 });
            $.getScript("/js/Global/lang-" + lan + ".js", setLanguage);
            return lan;
        },
        "convertDate": function (date, formatter) {  //此方法暂时为测试方法
            var ds = eval("\"" + date + "\"");
            var i = ds.substring(6, 19);
            var dd = new Date(parseInt(i));
            return dd.format(formatter);
        },
        "cookie": function (name, value, options) {
            if (typeof value != 'undefined') {
                options = options || {};
                if (value === null) {
                    value = '';
                    options.expires = -1;
                }
                var expires = '';
                if (options.expires && (typeof options.expires == 'number' || options.expires.toUTCString)) {
                    var date;
                    if (typeof options.expires == 'number') {
                        date = new Date();
                        date.setTime(date.getTime() + (options.expires * 24 * 60 * 60 * 1000));
                    } else {
                        date = options.expires;
                    }
                    expires = '; expires=' + date.toUTCString();
                }

                var path = options.path ? '; path=' + (options.path) : '';
                var domain = options.domain ? '; domain=' + (options.domain) : '';
                var secure = options.secure ? '; secure' : '';
                document.cookie = [name, '=', encodeURIComponent(value), expires, path, domain, secure].join('');
            } else {
                var cookieValue = null;
                if (document.cookie && document.cookie != '') {
                    var cookies = document.cookie.split(';');
                    for (var i = 0; i < cookies.length; i++) {
                        var cookie = jQuery.trim(cookies[i]);
                        if (cookie.substring(0, name.length + 1) == (name + '=')) {
                            cookieValue = decodeURIComponent(cookie.substring(name.length + 1));
                            break;
                        }
                    }
                }
                return cookieValue;
            }
          }  

    });
    $.fn.extend({  //如果没有出现效果，请查看样式顺序是否与默认的顺序一致
        "alterBgColor": function (options) {   //表格的各行变色 和 选中变色
            options = $.extend({
                odd: "oddCss",   //默认的样式
                even: "evenCss",
                isSelected: true,  //是否启用选中的功能 ,默认为启用
                selected: "selectedCss",
                isOver: true,  //是否启用悬浮样式，默认为启用
                moveOver: "overCss",
                tdCss: "",
                istdClick: false
            }, options);
            $("tbody>tr:odd", this).addClass(options.odd);
            $("tbody>tr:even", this).addClass(options.even);
            var $curObj = $(this);
            if (options.isSelected) {
                if ($("tbody>tr", this).find(":checkbox").length == 0) {
                    if (options.istdClick) {
                        $("tbody>tr>td", this).click(function () {
                            if ($("tbody>tr>td").hasClass(options.tdCss)) {
                                $("tbody>tr>td").removeClass(options.tdCss);
                            }

                            $(this).addClass(options.tdCss);
                            $(this).parent().addClass(options.selected).siblings().removeClass(options.selected);
                            return false;
                        });
                    }
                    else {

                        $("tbody>tr", this).click(function () {
                            $(this).addClass(options.selected).siblings().removeClass(options.selected);
                        });
                    }
                }
                else {
                    $("thead>tr>th>input[type=checkbox]", this).click(function () {
                        $curObj.find("tbody>tr>td>input[type=checkbox]", this).attr("checked", this.checked);
                        $curObj.find("tbody>tr")[this.checked ? "addClass" : "removeClass"](options.selected);
                    });
                    $("tbody>tr>td>input[type=checkbox]", this).click(function () {
                        var $ter = $("tbody>tr>td>input[type=checkbox]");
                        $curObj.find("thead>tr>th>input[type=checkbox]").attr("checked", $ter.length == $ter.filter(':checked').length);
                    });
                    $("tbody>tr", this).click(function () {

                        var hasSelected = $(this).hasClass(options.selected);
                        $(this)[hasSelected ? "removeClass" : "addClass"](options.selected)
                            .find(":checkbox").attr("checked", !hasSelected);

                    });
                    $('tbody>tr:has(:checked)', this).addClass(options.selected);
                }

            }
            if (options.isOver) {
                $("tbody>tr", this).hover(function () {
                    $(this).addClass(options.moveOver);
                }, function () {
                    $(this).removeClass(options.moveOver);
                });
            }

            return this;
        },
        "treeView": function (options) {
            options = $.extend({
                selectedCss: "",   //选中节点的样式
                pTreeCss: "folder",  //父节点的样式
                cTreeCss: "file",   //子节点的样式
                moveCss: "",        //鼠标移动的样式
                shousuo: "shousuo"  //菜单收缩的样式
            }, options);
            var $currentObj = $(this);
            $currentObj.find("li>span").addClass(options.pTreeCss).siblings("ul").find("li").addClass(options.cTreeCss);
            if (options.moveCss != "") {
                $(this).find("ul>li").hover(function () {
                    $(this).addClass(options.moveCss);
                }, function () {
                    $(this).removeClass(options.moveCss);
                });
            }

            if (options.selectedCss != "") {
                $(this).find("ul>li").click(function () {
                    $currentObj.find("ul>li").removeClass(options.selectedCss);
                    $(this).addClass(options.selectedCss);
                });
            }
            $currentObj.find("li>span").click(function () {
                $(this).next().toggle().parent().toggleClass(options.shousuo);
            });
            return this;
        }
        ,
        "suoxiao": function (options) {
            options = $.extend({
                toObj: this.id, //默认是当前对象的id
                feed: 500  //默认时间是500毫秒
                //opactiy: 0.3  //默认透明度
            }, options);
            var left = $(options.toObj).offset().left;
            var top = $(options.toObj).offset().top;
            var height = $(options.toObj).height();
            var width = $(options.toObj).width();

            $(this).animate({ top: top, left: left, height: height, width: width }, options.feed, function () {
                $(this).hide();
            });
            return this; //表示还可进行链接操作
        }

    });

    //分页插件  结合/pagination.css 样式
    jQuery.fn.pagination = function (maxentries, opts) {
        opts = jQuery.extend({
            items_per_page: 20,
            num_display_entries: 10,
            current_page: 0,
            num_edge_entries: 0,
            link_to: "#",
            prev_text: "上一页",
            next_text: "下一页",
            ellipse_text: "...",
            prev_show_always: true,
            next_show_always: true,
            display_per_page: false,
            callback: function () { return false; }
        }, opts || {});

        return this.each(function () {
            function numPages() {
                return Math.ceil(maxentries / opts.items_per_page);
            }
            function getInterval() {
                var ne_half = Math.ceil(opts.num_display_entries / 2);
                var np = numPages();
                var upper_limit = np - opts.num_display_entries;
                var start = current_page > ne_half ? Math.max(Math.min(current_page - ne_half, upper_limit), 0) : 0;
                var end = current_page > ne_half ? Math.min(current_page + ne_half, np) : Math.min(opts.num_display_entries, np);
                return [start, end];
            }
            function pageSelected(page_id, evt) {
                current_page = page_id;
                drawLinks();
                var continuePropagation = opts.callback(page_id, panel);
                if (!continuePropagation) {
                    if (evt.stopPropagation) {
                        evt.stopPropagation();
                    }
                    else {
                        evt.cancelBubble = true;
                    }
                }
                return continuePropagation;
            }
            function drawLinks() {
                panel.empty();
                var interval = getInterval();
                var np = numPages();
                var getClickHandler = function (page_id) {
                    return function (evt) { return pageSelected(page_id, evt); }
                };
                panel.append($("<span>总共" + maxentries + "笔记录,每页" + opts.items_per_page + "笔,共" + np + "页</span>"));
                var appendItem = function (page_id, appendopts) {
                    page_id = page_id < 0 ? 0 : (page_id < np ? page_id : np - 1); // Normalize page id to sane value
                    appendopts = jQuery.extend({ text: page_id + 1, classes: "" }, appendopts || {});
                    if (page_id == current_page) {
                        var lnk = $("<span class='current'>" + (appendopts.text) + "</span>");
                    }
                    else {
                        var lnk = $("<a>" + (appendopts.text) + "</a>")
						.bind("click", getClickHandler(page_id))
						.attr('href', opts.link_to.replace(/__id__/, page_id));
                    }
                    if (appendopts.classes) { lnk.addClass(appendopts.classes); }
                    panel.append(lnk);
                };
                if (opts.prev_text && (current_page > 0 || opts.prev_show_always)) {
                    appendItem(current_page - 1, { text: opts.prev_text, classes: "prev" });
                }
                if (interval[0] > 0 && opts.num_edge_entries > 0) {
                    var end = Math.min(opts.num_edge_entries, interval[0]);
                    for (var i = 0; i < end; i++) {
                        appendItem(i);
                    }
                    if (opts.num_edge_entries < interval[0] && opts.ellipse_text) {
                        jQuery("<span>" + opts.ellipse_text + "</span>").appendTo(panel);
                    }
                }
                for (var i = interval[0]; i < interval[1]; i++) {
                    appendItem(i);
                }
                if (interval[1] < np && opts.num_edge_entries > 0) {
                    if (np - opts.num_edge_entries > interval[1] && opts.ellipse_text) {
                        jQuery("<span>" + opts.ellipse_text + "</span>").appendTo(panel);
                    }
                    var begin = Math.max(np - opts.num_edge_entries, interval[1]);
                    for (var i = begin; i < np; i++) {
                        appendItem(i);
                    }
                }
                if (opts.next_text && (current_page < np - 1 || opts.next_show_always)) {
                    appendItem(current_page + 1, { text: opts.next_text, classes: "next" });
                }

                if (opts.display_per_page) {
                    panel.append($("<span>每页显示<input id='new_per_page' type='text' value='" + opts.items_per_page + "'>笔&nbsp;<input id='display_per_pageId' type='button' value='确定'></span>"));
                    $("#display_per_pageId").unbind("click").bind("click", function () {
                        if ($("#new_per_page").val() > 1000) {
                            alert("每页记录不能大于1000笔");
                            return;
                        }
                        opts.items_per_page = $("#new_per_page").val();
                        drawLinks();
                    });
                }
            }
            var current_page = opts.current_page;
            maxentries = (!maxentries || maxentries < 0) ? 1 : maxentries;
            opts.items_per_page = (!opts.items_per_page || opts.items_per_page < 0) ? 1 : opts.items_per_page;
            var panel = jQuery(this);
            this.selectPage = function (page_id) { pageSelected(page_id); };
            this.prevPage = function () {
                if (current_page > 0) {
                    pageSelected(current_page - 1);
                    return true;
                }
                else {
                    return false;
                }
            };
            this.nextPage = function () {
                if (current_page < numPages() - 1) {
                    pageSelected(current_page + 1);
                    return true;
                }
                else {
                    return false;
                }
            };
            drawLinks();
        });
    }

})(jQuery);
Date.prototype.format = function(format) {
    var o = {
        "M+": this.getMonth() + 1,
        "d+": this.getDate(),
        "h+": this.getHours(),
        "m+": this.getMinutes(),
        "s+": this.getSeconds(),
        "q+": Math.floor((this.getMonth() + 3) / 3),
        "S": this.getMilliseconds()
    };

    if (/(y+)/.test(format)) {
        format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    }
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(format)) {
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
        }
    }
    return format;
}

/*
 *验证
 *编写人:李毅
 *
 *
 */
/*
 *验证对象的值是否为空
 *obj:要验证的对象
 *errarlbl:错误信息显示的对象ID
 *errarInfo:要显示的错误信息
 */
function IsNullByInfo(obj, errarlbl, errarInfo) {
    if (jQuery(obj).val() == "") {
        jQuery(obj).parent().parent().find("#" + errarlbl).html(errarInfo + "&nbsp;&nbsp;&nbsp;");
        return false;
    }
    jQuery(obj).parent().parent().find("#" + errarlbl).html("");
    return true;
}
/*
*验证对象的值是否为空
*obj:要验证的对象
*errarlbl:错误信息显示的对象ID
*/
function IsNull(obj, errarlbl) {
    if (jQuery(obj).val() == "") {
        jQuery(obj).parent().parent().find("#" + errarlbl).html("不能为空&nbsp;&nbsp;&nbsp;");
        return false;
    }
    jQuery(obj).parent().parent().find("#" + errarlbl).html("");
    return true;
}
/*
*验证对象的值是否为空
*obj:要验证的对象
*errarlbl:错误信息显示的对象ID
*eltype:要验证的类型
*isNullInfo:不能为空的错误提示不填则显示不能为空
*errarInfo:要显示的错误信息
*length:该值的最大长度
*/
function IsElJudge(obj, errarlbl, eltype, isNullInfo, errarInfo, length) {
    var Authentication;
    //debugger;
    switch (eltype) {
        case "number":
            Authentication = /^[0-9]+(.[0-9]{2})?$/;
            break;
        case "decimal":
            Authentication =/\.\d{1,2}$/;
            break;
        case "DomainName":
            Authentication = /^(?![^\.]*?[\u4e00-\u9fa5][^\.]*?\.)([a-zA-Z]+\.)?[\w-\u4e00-\u9fa5]+\.[a-zA-Z]+(\.[a-zA-Z]+)?$/;
            break;
        case "hour":
            Authentication = /^([0-1][0-9]{1}|[2][0-3]{1})$/;
            break;
        case "minute":
            Authentication = /^([0-5][0-9])$/;
            break;
        case "ip":
            Authentication = /^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$/;
    }
   //alert(jQuery(obj).val());
    //alert(Authentication.toString());
    if (jQuery(obj).val() == "") {
        jQuery(obj).parent().parent().find("#" + errarlbl).html(isNullInfo == "" ? "不能为空" : isNullInfo + "&nbsp;&nbsp;&nbsp;");
        return false;
    }
    if (!Authentication.test(jQuery(obj).val())) {
        jQuery(obj).parent().parent().find("#" + errarlbl).html(errarInfo + "&nbsp;&nbsp;&nbsp;");
        return false;
    }
    if (length!=0 && jQuery(obj).val().toString().length > length) {
        jQuery(obj).parent().parent().find("#" + errarlbl).html("长度必须小于"+length+"&nbsp;&nbsp;&nbsp;");
        return false;
    }
    jQuery(obj).parent().parent().find("#" + errarlbl).html("");
    return true;
}

/*
确认密码验证
By xzz
thisobj:    当前对象
uobj:       密码文本框ID
errorlbl:   错误信息显示的对象ID
isNullInfo: 为空提示信息
errInfo:    错误提示信息
*/
function PassWordCheck(thisobj, uobj, errorlbl, isNullInfo, errInfo) {
    if ($(thisobj).val() == "") {
        if (isNullInfo == "") {
            jQuery(thisobj).parent().parent().find("#" + errorlbl).html("必填");
        }
        else {
            jQuery(thisobj).parent().parent().find("#" + errorlbl).html(isNullInfo);
        }
        return false;
    }
    if (jQuery(thisobj).val() != jQuery(thisobj).parents().find("#" + uobj).val()) {
        if (errInfo == "") {
            jQuery(thisobj).parent().parent().find("#" + errorlbl).html("密码前后不一致");
        }
        else {
            jQuery(thisobj).parent().parent().find("#" + errorlbl).html(errInfo);
        }
        return false;
    }

    jQuery(thisobj).parent().parent().find("#" + errorlbl).html("");
    return true;
}

/*
比较大小
By xzz 2010-11-16
obj:        当前对象
compareTo:  要比较的对象ID
MinOrMax:   比较大还是比较小 Min:小　Max:大
errId:      显示错误提示信息ID
errInfo:    错误提示信息
*/
function CompareNumber(obj, compareTo, MinOrMax, errId, errInfo) {
//debugger
    var compareVal;
    var vals;
    if (jQuery("#" + compareTo).val() == "") {
        compareVal = parseInt(jQuery("#" + compareTo).text());
    }
    else {
        compareVal = parseInt(jQuery("#" + compareTo).val());
    }
    if (jQuery(obj).val() == "") {
        vals = parseInt(jQuery(obj).text());
    }
    else {
        vals = parseInt(jQuery(obj).val());
    }

    if (MinOrMax == "Min") {
        if (IsElJudge(obj, errId, 'number', '必填', '必须是数字', 20)) {
            if (vals > compareVal) {
                jQuery("#"+errId).html(errInfo);
                return false;
            }
            else {
                jQuery("#"+errId).html("");
                return true;
            }
        }
    }
    else {
        if (IsElJudge(obj, errId, 'number', '必填', '必须是数字', 20)) {
            if (vals < compareVal) {
                jQuery("#"+errId).html(errInfo);
                return false;
            }
            else {
                jQuery("#"+errId).html("");
                return true;
            }
        }
    }
}

/*
比较大小（需要传入数值）
By xzz 2010-11-16
obj:        当前对象
compareNumber:  要比较的数值
MinOrMax:   比较大还是比较小 Min:小　Max:大
errId:      显示错误提示信息ID
errInfo:    错误提示信息
*/
function CompareByNumber(obj, compareTo, MinOrMax, errId, errInfo) {
    //debugger
    var compareVal;
    var vals;
    compareVal = compareTo;
    if (jQuery(obj).val() == "") {
        vals = parseInt(jQuery(obj).text());
    }
    else {
        vals = parseInt(jQuery(obj).val());
    }

    if (MinOrMax == "Min") {
        if (IsElJudge(obj, errId, 'number', '必填', '必须是数字', 20)) {
            if (vals > compareVal) {
                jQuery("#" + errId).html(errInfo);
                return false;
            }
            else {
                jQuery("#" + errId).html("");
                return true;
            }
        }
    }
    else {
        if (IsElJudge(obj, errId, 'number', '必填', '必须是数字', 20)) {
            if (vals < compareVal) {
                jQuery("#" + errId).html(errInfo);
                return false;
            }
            else {
                jQuery("#" + errId).html("");
                return true;
            }
        }
    }
}

function GetRequest() {
    var url = location.search; //获取url中"?"符后的字串  
    var json = {};
    if (url.indexOf("?") != -1) {
        var str = url.substr(1);
        strs = str.split("&");
        for (var i = 0; i < strs.length; i++) {
            json[strs[i].split("=")[0]] = unescape(strs[i].split("=")[1]);
        }
    }
    return json;
}  

/*----------------------验证结束---------------------------------------*/


function SysLoginOut() {
    alert("超时已被登出");
    parent.document.location = "/login.htm";
}


