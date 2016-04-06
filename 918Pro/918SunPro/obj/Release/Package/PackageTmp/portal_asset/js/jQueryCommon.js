(function ($) {
    $.extend({ "toError": function (err) {
        try { }
        catch (e) { }
    }, "ShowTime": function (options) {
        options = jQuery.extend({ hour: 0, format: "yyyy-MM-dd hh:mm:ss", isWeek: false, newDate: null, showObj: "" }, options); var date = new Date(), week = ""; if (options.hour != 0) {
            var a; if (options.hour > 0) { a = new Date().getTime() + (options.hour * 60 * 60 * 1000); }
            else { a = new Date() - (Math.abs(options.hour) * 60 * 60 * 1000); }
            date = new Date(a);
        }
        else { date = new Date(); }
        if (options.newDate) { var ds = eval("\"" + options.newDate + "\""); var i = ds.substring(6, 19); date = new Date(parseInt(i)); }
        if (options.isWeek) {
            var weekofDay = []; if ($.cookie("lan") == "zh-cn" || $.cookie("lan") == "zh-tw") { weekofDay = ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"]; }
            else { weekofDay = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"]; }
            week = weekofDay[date.getDay()];
        }
        $(options.showObj).text($.convertDate(date, date.format(options.format)) + week); return $.convertDate(date, date.format(options.format)) + " " + week;
    }, "AjaxCommon": function (options) { options = jQuery.extend({ url: "", datas: "", asy: true, cache: false, toSuccess: function (json) { }, global: true, contentType: "application/json", type: "post", beforeSend: function (xhr) { }, complete: function (xhr) { }, dataType: "json", timeout: 60000 }, options); $.ajax({ beforeSend: options.beforeSend, complete: options.complete, contentType: options.contentType, type: options.type, dataType: options.dataType, url: options.url, timeout: options.timeout, cache: options.cache, data: "{" + options.datas.replaceFanXieGang() + "}", async: options.asy, global: options.global, success: function (json) { options.toSuccess(json); }, error: function (err) { $.toError(err); } }); }, "MsgTip": function (options) {
        options = $.extend({ objId: "", msg: "", delayTime: 2500, hideTime: 1000, left: "45%", top: "35%", msgId: "" }, options); $(options.objId).css({ "opacity": 1, "left": options.left, "top": options.top }); if ($(options.objId + ":not(:animated)")) {
            if (options.msgId != "") { $(options.objId).find(options.msgId).html(options.msg); }
            else { $(options.objId).html(options.msg); }
            $(options.objId).show().delay(options.delayTime).animate({ opacity: 0 }, options.hideTime, function () { $(options.objId).hide(); });
        }
    }, "SetOrGetLanguage": function (setLang, setLanguage, url) {
        var lan = ""; if (url == undefined) url = "/js/Global/"; if (setLang == "") {
            lan = $.cookie("lan");
            if (lan == undefined || lan == null || lan == "") { lan = "zh-cn"; $.cookie("lan", "zh-cn", { path: "/", expires: 10 }); }
            lan = $.cookie("lan") || window.navigator.language || window.navigator.browserLanguage;
        }
        else { lan = setLang; }
        lan = lan.toLowerCase(); switch (lan) { case "zh-cn": case "zh-tw": case "en-us": case "vi-vn": case "th-th": break; default: lan = "en-us"; break; }
        $.cookie("lan", lan, { path: "/", expires: 10 }); $.getScript(url + "lang-" + lan + ".js", setLanguage); return lan.toLowerCase();
    }, "convertDate": function (date, formatter) { var ds = eval("\"" + date + "\""); var i = ds.substring(6, 19); var dd = new Date(parseInt(i)); return dd.format(formatter); }, "cookie": function (name, value, options) {
        if (typeof value != 'undefined') {
            options = options || {}; if (value === null) { value = ''; options.expires = -1; }
            var expires = ''; if (options.expires && (typeof options.expires == 'number' || options.expires.toUTCString)) {
                var date; if (typeof options.expires == 'number') { date = new Date(); date.setTime(date.getTime() + (options.expires * 24 * 60 * 60 * 1000)); } else { date = options.expires; }
                expires = '; expires=' + date.toUTCString();
            }
            var path = options.path ? '; path=' + (options.path) : ''; var domain = options.domain ? '; domain=' + (options.domain) : ''; var secure = options.secure ? '; secure' : ''; document.cookie = [name, '=', encodeURIComponent(value), expires, path, domain, secure].join('');
        } else {
            var cookieValue = null; if (document.cookie && document.cookie != '') { var cookies = document.cookie.split(';'); for (var i = 0; i < cookies.length; i++) { var cookie = jQuery.trim(cookies[i]); if (cookie.substring(0, name.length + 1) == (name + '=')) { cookieValue = decodeURIComponent(cookie.substring(name.length + 1)); break; } } }
            return cookieValue;
        }
    }
    }); $.fn.extend({ "alterBgColor": function (options) {
        options = $.extend({ odd: "oddCss", even: "evenCss", isSelected: true, selected: "selectedCss", isOver: true, moveOver: "overCss", tdCss: "", istdClick: false }, options); return this.each(function () {
            $("tbody>tr:odd", this).addClass(options.odd); $("tbody>tr:even", this).addClass(options.even); var $curObj = $(this); if (options.isSelected) {
                if ($("tbody>tr", this).find(":checkbox").length == 0) {
                    if (options.istdClick) {
                        $("tbody>tr>td", this).click(function () {
                            if ($("tbody>tr>td").hasClass(options.tdCss)) { $("tbody>tr>td").removeClass(options.tdCss); }
                            $(this).addClass(options.tdCss); $(this).parent().addClass(options.selected).siblings().removeClass(options.selected); return false;
                        });
                    }
                    else { $("tbody>tr>td", this).click(function () { if ($(this).parent().find("td").length > 1) { $(this).parent().addClass(options.selected).siblings().removeClass(options.selected); } }); }
                }
                else { $("thead>tr>th>input[type=checkbox]", this).click(function () { $curObj.find("tbody>tr>td>input[type=checkbox]", this).attr("checked", this.checked); $curObj.find("tbody>tr")[this.checked ? "addClass" : "removeClass"](options.selected); }); $("tbody>tr>td>input[type=checkbox]", this).click(function () { var $ter = $("tbody>tr>td>input[type=checkbox]"); $curObj.find("thead>tr>th>input[type=checkbox]").attr("checked", $ter.length == $ter.filter(':checked').length); }); $("tbody>tr", this).click(function () { var hasSelected = $(this).hasClass(options.selected); $(this)[hasSelected ? "removeClass" : "addClass"](options.selected).find(":checkbox").attr("checked", !hasSelected); }); $('tbody>tr:has(:checked)', this).addClass(options.selected); }
            }
            if (options.isOver) { $("tbody>tr", this).hover(function () { $(this).addClass(options.moveOver); }, function () { $(this).removeClass(options.moveOver); }); }
        });
    }, "suoxiao": function (options) { options = $.extend({ toObj: this.id, feed: 500 }, options); var left = $(options.toObj).offset().left; var top = $(options.toObj).offset().top; var height = $(options.toObj).height(); var width = $(options.toObj).width(); $(this).animate({ top: top, left: left, height: height, width: width }, options.feed, function () { $(this).hide(); }); return this; }
    }); $.fn.paginate = function (options) { var opts = $.extend({}, $.fn.paginate.defaults, options); return this.each(function () { $this = $(this); var o = $.meta ? $.extend({}, opts, $this.data()) : opts; var selectedpage = o.start; $.fn.draw(o, $this, selectedpage); }); }; var outsidewidth_tmp = 0; var insidewidth = 0; var bName = navigator.appName; var bVer = navigator.appVersion; if (bVer.indexOf('MSIE') > 0)
        var ver = "ie"; $.fn.paginate.defaults = { count: 5, start: 12, display: 5, border: true, border_color: '#fff', text_color: '#8cc59d', background_color: 'black', border_hover_color: '#fff', text_hover_color: '#fff', background_hover_color: '#fff', rotate: true, images: true, mouse: 'slide', onChange: function (page) { SetPage(page - 1); return false; } }; $.fn.draw = function (o, obj, selectedpage) {
            if (o.display > o.count)
                o.display = o.count; $this.empty(); if (o.images) { var spreviousclass = 'jPag-sprevious-img'; var previousclass = 'jPag-previous-img'; var snextclass = 'jPag-snext-img'; var nextclass = 'jPag-next-img'; }
            else { var spreviousclass = 'jPag-sprevious'; var previousclass = 'jPag-previous'; var snextclass = 'jPag-snext'; var nextclass = 'jPag-next'; }
            var _first = $(document.createElement('a')).addClass('jPag-first').html(languages._L495); if (o.rotate) { if (o.images) var _rotleft = $(document.createElement('span')).addClass(spreviousclass); else var _rotleft = $(document.createElement('span')).addClass(spreviousclass).html('&laquo;'); }
            var _divwrapleft = $(document.createElement('div')).addClass('jPag-control-back'); _divwrapleft.append(_first).append(_rotleft); var _ulwrapdiv = $(document.createElement('div')).css('overflow', 'hidden'); var _ul = $(document.createElement('ul')).addClass('jPag-pages')
            var c = (o.display - 1) / 2; var first = selectedpage - c; var selobj; for (var i = 0; i < o.count; i++) {
                var val = i + 1; if (val == selectedpage) { var _obj = $(document.createElement('li')).html('<span class="jPag-current">' + val + '</span>'); selobj = _obj; _ul.append(_obj); }
                else { var _obj = $(document.createElement('li')).html('<a>' + val + '</a>'); _ul.append(_obj); }
            }
            _ulwrapdiv.append(_ul); if (o.rotate) { if (o.images) var _rotright = $(document.createElement('span')).addClass(snextclass); else var _rotright = $(document.createElement('span')).addClass(snextclass).html('&raquo;'); }
            var _last = $(document.createElement('a')).addClass('jPag-last').html(languages._L496); var _divwrapright = $(document.createElement('div')).addClass('jPag-control-front'); _divwrapright.append(_rotright).append(_last); $this.addClass('jPaginate').append(_divwrapleft).append(_ulwrapdiv).append(_divwrapright); if (!o.border) { if (o.background_color == 'none') var a_css = { 'color': o.text_color }; else var a_css = { 'color': o.text_color, 'background-color': o.background_color }; if (o.background_hover_color == 'none') var hover_css = { 'color': o.text_hover_color }; else var hover_css = { 'color': o.text_hover_color, 'background-color': o.background_hover_color }; }
            else { if (o.background_color == 'none') var a_css = { 'color': o.text_color, 'border': '1px solid ' + o.border_color }; else var a_css = { 'color': o.text_color, 'background-color': o.background_color, 'border': '1px solid ' + o.border_color }; if (o.background_hover_color == 'none') var hover_css = { 'color': o.text_hover_color, 'border': '1px solid ' + o.border_hover_color }; else var hover_css = { 'color': o.text_hover_color, 'background-color': o.background_hover_color, 'border': '1px solid ' + o.border_hover_color }; }
            $.fn.applystyle(o, $this, a_css, hover_css, _first, _ul, _ulwrapdiv, _divwrapright); var outsidewidth = outsidewidth_tmp - _first.parent().width() - 3; if (ver == 'ie') { _ulwrapdiv.css('width', outsidewidth + 58 + 'px'); _divwrapright.css('left', outsidewidth_tmp + 6 + 58 + 'px'); }
            else { _ulwrapdiv.css('width', outsidewidth + 'px'); _divwrapright.css('left', outsidewidth_tmp + 6 + 'px'); }
            if (o.rotate) {
                _rotright.hover(function () { thumbs_scroll_interval = setInterval(function () { var left = _ulwrapdiv.scrollLeft() + 1; _ulwrapdiv.scrollLeft(left); }, 20); }, function () { clearInterval(thumbs_scroll_interval); }); _rotleft.hover(function () { thumbs_scroll_interval = setInterval(function () { var left = _ulwrapdiv.scrollLeft() - 1; _ulwrapdiv.scrollLeft(left); }, 20); }, function () { clearInterval(thumbs_scroll_interval); }); if (o.mouse == 'press') { _rotright.mousedown(function () { thumbs_mouse_interval = setInterval(function () { var left = _ulwrapdiv.scrollLeft() + 5; _ulwrapdiv.scrollLeft(left); }, 20); }).mouseup(function () { clearInterval(thumbs_mouse_interval); }); _rotleft.mousedown(function () { thumbs_mouse_interval = setInterval(function () { var left = _ulwrapdiv.scrollLeft() - 5; _ulwrapdiv.scrollLeft(left); }, 20); }).mouseup(function () { clearInterval(thumbs_mouse_interval); }); }
                else { _rotleft.click(function (e) { var width = outsidewidth - 10; var left = _ulwrapdiv.scrollLeft() - width; _ulwrapdiv.animate({ scrollLeft: left + 'px' }); }); _rotright.click(function (e) { var width = outsidewidth - 10; var left = _ulwrapdiv.scrollLeft() + width; _ulwrapdiv.animate({ scrollLeft: left + 'px' }); }); }
            }
            _first.click(function (e) { _ulwrapdiv.animate({ scrollLeft: '0px' }); if (curpage > 0) { _ulwrapdiv.find('li').eq(curpage - 1).click(); } }); _last.click(function (e) { _ulwrapdiv.animate({ scrollLeft: insidewidth + 'px' }); if (curpage < o.count - 1) { _ulwrapdiv.find('li').eq(curpage + 1).click(); } }); _ulwrapdiv.find('li').click(function (e) {
                selobj.html('<a>' + selobj.find('.jPag-current').html() + '</a>'); var currval = $(this).find('a').html(); $(this).html('<span class="jPag-current">' + currval + '</span>'); selobj = $(this); $.fn.applystyle(o, $(this).parent().parent().parent(), a_css, hover_css, _first, _ul, _ulwrapdiv, _divwrapright); var left = (this.offsetLeft) / 2; var left2 = _ulwrapdiv.scrollLeft() + left; var tmp = left - (outsidewidth / 2); if (ver == 'ie')
                    _ulwrapdiv.animate({ scrollLeft: left + tmp - _first.parent().width() + 52 + 'px' }); else
                    _ulwrapdiv.animate({ scrollLeft: left + tmp - _first.parent().width() + 'px' }); o.onChange(currval);
            }); var last = _ulwrapdiv.find('li').eq(o.start - 1); last.attr('id', 'tmp'); var left = document.getElementById('tmp').offsetLeft / 2; last.removeAttr('id'); var tmp = left - (outsidewidth / 2); if (ver == 'ie') _ulwrapdiv.animate({ scrollLeft: left + tmp - _first.parent().width() + 52 + 'px' }); else _ulwrapdiv.animate({ scrollLeft: left + tmp - _first.parent().width() + 'px' });
        }
    $.fn.applystyle = function (o, obj, a_css, hover_css, _first, _ul, _ulwrapdiv, _divwrapright) {
        obj.find('a').css(a_css); obj.find('span.jPag-current').css(hover_css); obj.find('a').hover(function () { $(this).css(hover_css); }, function () { $(this).css(a_css); }); obj.css('padding-left', _first.parent().width() + 5 + 'px'); insidewidth = 0; obj.find('li').each(function (i, n) {
            if (i == (o.display - 1)) { outsidewidth_tmp = this.offsetLeft + this.offsetWidth; }
            insidewidth += this.offsetWidth;
        })
        _ul.css('width', insidewidth + 'px');
    }
})(jQuery); 
Date.prototype.format = function (format) {
    var o = { "M+": this.getMonth() + 1, "d+": this.getDate(), "h+": this.getHours(), "m+": this.getMinutes(), "s+": this.getSeconds(), "q+": Math.floor((this.getMonth() + 3) / 3), "S": this.getMilliseconds() }; if (/(y+)/.test(format)) { format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length)); }
    for (var k in o) { if (new RegExp("(" + k + ")").test(format)) { format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length)); } }
    return format;
}
String.prototype.replaceDanYinHao = function () { return this.replace(new RegExp(/'/g), "’"); }
String.prototype.replaceFanXieGang = function () { return this.replace(new RegExp(/\\/g), "\\\\"); }
var targetUrl = function (url) { var f = document.createElement("form"); f.action = url; f.target = "_blank"; f.method = "get"; document.body.appendChild(f); f.submit(); }
var MD5 = function (string) {
    function RotateLeft(lValue, iShiftBits) { return (lValue << iShiftBits) | (lValue >>> (32 - iShiftBits)); }
    function AddUnsigned(lX, lY) {
        var lX4, lY4, lX8, lY8, lResult; lX8 = (lX & 0x80000000); lY8 = (lY & 0x80000000); lX4 = (lX & 0x40000000); lY4 = (lY & 0x40000000); lResult = (lX & 0x3FFFFFFF) + (lY & 0x3FFFFFFF); if (lX4 & lY4) { return (lResult ^ 0x80000000 ^ lX8 ^ lY8); }
        if (lX4 | lY4) { if (lResult & 0x40000000) { return (lResult ^ 0xC0000000 ^ lX8 ^ lY8); } else { return (lResult ^ 0x40000000 ^ lX8 ^ lY8); } } else { return (lResult ^ lX8 ^ lY8); } 
    }
    function F(x, y, z) { return (x & y) | ((~x) & z); }
    function G(x, y, z) { return (x & z) | (y & (~z)); }
    function H(x, y, z) { return (x ^ y ^ z); }
    function I(x, y, z) { return (y ^ (x | (~z))); }
    function FF(a, b, c, d, x, s, ac) { a = AddUnsigned(a, AddUnsigned(AddUnsigned(F(b, c, d), x), ac)); return AddUnsigned(RotateLeft(a, s), b); }; function GG(a, b, c, d, x, s, ac) { a = AddUnsigned(a, AddUnsigned(AddUnsigned(G(b, c, d), x), ac)); return AddUnsigned(RotateLeft(a, s), b); }; function HH(a, b, c, d, x, s, ac) { a = AddUnsigned(a, AddUnsigned(AddUnsigned(H(b, c, d), x), ac)); return AddUnsigned(RotateLeft(a, s), b); }; function II(a, b, c, d, x, s, ac) { a = AddUnsigned(a, AddUnsigned(AddUnsigned(I(b, c, d), x), ac)); return AddUnsigned(RotateLeft(a, s), b); }; function ConvertToWordArray(string) {
        var lWordCount; var lMessageLength = string.length; var lNumberOfWords_temp1 = lMessageLength + 8; var lNumberOfWords_temp2 = (lNumberOfWords_temp1 - (lNumberOfWords_temp1 % 64)) / 64; var lNumberOfWords = (lNumberOfWords_temp2 + 1) * 16; var lWordArray = Array(lNumberOfWords - 1); var lBytePosition = 0; var lByteCount = 0; while (lByteCount < lMessageLength) { lWordCount = (lByteCount - (lByteCount % 4)) / 4; lBytePosition = (lByteCount % 4) * 8; lWordArray[lWordCount] = (lWordArray[lWordCount] | (string.charCodeAt(lByteCount) << lBytePosition)); lByteCount++; }
        lWordCount = (lByteCount - (lByteCount % 4)) / 4; lBytePosition = (lByteCount % 4) * 8; lWordArray[lWordCount] = lWordArray[lWordCount] | (0x80 << lBytePosition); lWordArray[lNumberOfWords - 2] = lMessageLength << 3; lWordArray[lNumberOfWords - 1] = lMessageLength >>> 29; return lWordArray;
    }; function WordToHex(lValue) {
        var WordToHexValue = "", WordToHexValue_temp = "", lByte, lCount; for (lCount = 0; lCount <= 3; lCount++) { lByte = (lValue >>> (lCount * 8)) & 255; WordToHexValue_temp = "0" + lByte.toString(16); WordToHexValue = WordToHexValue + WordToHexValue_temp.substr(WordToHexValue_temp.length - 2, 2); }
        return WordToHexValue;
    }; function Utf8Encode(string) {
        string = string.replace(/\r\n/g, "\n"); var utftext = ""; for (var n = 0; n < string.length; n++) {
            var c = string.charCodeAt(n); if (c < 128) { utftext += String.fromCharCode(c); }
            else if ((c > 127) && (c < 2048)) { utftext += String.fromCharCode((c >> 6) | 192); utftext += String.fromCharCode((c & 63) | 128); }
            else { utftext += String.fromCharCode((c >> 12) | 224); utftext += String.fromCharCode(((c >> 6) & 63) | 128); utftext += String.fromCharCode((c & 63) | 128); } 
        }
        return utftext;
    }; var x = Array(); var k, AA, BB, CC, DD, a, b, c, d; var S11 = 7, S12 = 12, S13 = 17, S14 = 22; var S21 = 5, S22 = 9, S23 = 14, S24 = 20; var S31 = 4, S32 = 11, S33 = 16, S34 = 23; var S41 = 6, S42 = 10, S43 = 15, S44 = 21; string = Utf8Encode(string); x = ConvertToWordArray(string); a = 0x67452301; b = 0xEFCDAB89; c = 0x98BADCFE; d = 0x10325476; for (k = 0; k < x.length; k += 16) { AA = a; BB = b; CC = c; DD = d; a = FF(a, b, c, d, x[k + 0], S11, 0xD76AA478); d = FF(d, a, b, c, x[k + 1], S12, 0xE8C7B756); c = FF(c, d, a, b, x[k + 2], S13, 0x242070DB); b = FF(b, c, d, a, x[k + 3], S14, 0xC1BDCEEE); a = FF(a, b, c, d, x[k + 4], S11, 0xF57C0FAF); d = FF(d, a, b, c, x[k + 5], S12, 0x4787C62A); c = FF(c, d, a, b, x[k + 6], S13, 0xA8304613); b = FF(b, c, d, a, x[k + 7], S14, 0xFD469501); a = FF(a, b, c, d, x[k + 8], S11, 0x698098D8); d = FF(d, a, b, c, x[k + 9], S12, 0x8B44F7AF); c = FF(c, d, a, b, x[k + 10], S13, 0xFFFF5BB1); b = FF(b, c, d, a, x[k + 11], S14, 0x895CD7BE); a = FF(a, b, c, d, x[k + 12], S11, 0x6B901122); d = FF(d, a, b, c, x[k + 13], S12, 0xFD987193); c = FF(c, d, a, b, x[k + 14], S13, 0xA679438E); b = FF(b, c, d, a, x[k + 15], S14, 0x49B40821); a = GG(a, b, c, d, x[k + 1], S21, 0xF61E2562); d = GG(d, a, b, c, x[k + 6], S22, 0xC040B340); c = GG(c, d, a, b, x[k + 11], S23, 0x265E5A51); b = GG(b, c, d, a, x[k + 0], S24, 0xE9B6C7AA); a = GG(a, b, c, d, x[k + 5], S21, 0xD62F105D); d = GG(d, a, b, c, x[k + 10], S22, 0x2441453); c = GG(c, d, a, b, x[k + 15], S23, 0xD8A1E681); b = GG(b, c, d, a, x[k + 4], S24, 0xE7D3FBC8); a = GG(a, b, c, d, x[k + 9], S21, 0x21E1CDE6); d = GG(d, a, b, c, x[k + 14], S22, 0xC33707D6); c = GG(c, d, a, b, x[k + 3], S23, 0xF4D50D87); b = GG(b, c, d, a, x[k + 8], S24, 0x455A14ED); a = GG(a, b, c, d, x[k + 13], S21, 0xA9E3E905); d = GG(d, a, b, c, x[k + 2], S22, 0xFCEFA3F8); c = GG(c, d, a, b, x[k + 7], S23, 0x676F02D9); b = GG(b, c, d, a, x[k + 12], S24, 0x8D2A4C8A); a = HH(a, b, c, d, x[k + 5], S31, 0xFFFA3942); d = HH(d, a, b, c, x[k + 8], S32, 0x8771F681); c = HH(c, d, a, b, x[k + 11], S33, 0x6D9D6122); b = HH(b, c, d, a, x[k + 14], S34, 0xFDE5380C); a = HH(a, b, c, d, x[k + 1], S31, 0xA4BEEA44); d = HH(d, a, b, c, x[k + 4], S32, 0x4BDECFA9); c = HH(c, d, a, b, x[k + 7], S33, 0xF6BB4B60); b = HH(b, c, d, a, x[k + 10], S34, 0xBEBFBC70); a = HH(a, b, c, d, x[k + 13], S31, 0x289B7EC6); d = HH(d, a, b, c, x[k + 0], S32, 0xEAA127FA); c = HH(c, d, a, b, x[k + 3], S33, 0xD4EF3085); b = HH(b, c, d, a, x[k + 6], S34, 0x4881D05); a = HH(a, b, c, d, x[k + 9], S31, 0xD9D4D039); d = HH(d, a, b, c, x[k + 12], S32, 0xE6DB99E5); c = HH(c, d, a, b, x[k + 15], S33, 0x1FA27CF8); b = HH(b, c, d, a, x[k + 2], S34, 0xC4AC5665); a = II(a, b, c, d, x[k + 0], S41, 0xF4292244); d = II(d, a, b, c, x[k + 7], S42, 0x432AFF97); c = II(c, d, a, b, x[k + 14], S43, 0xAB9423A7); b = II(b, c, d, a, x[k + 5], S44, 0xFC93A039); a = II(a, b, c, d, x[k + 12], S41, 0x655B59C3); d = II(d, a, b, c, x[k + 3], S42, 0x8F0CCC92); c = II(c, d, a, b, x[k + 10], S43, 0xFFEFF47D); b = II(b, c, d, a, x[k + 1], S44, 0x85845DD1); a = II(a, b, c, d, x[k + 8], S41, 0x6FA87E4F); d = II(d, a, b, c, x[k + 15], S42, 0xFE2CE6E0); c = II(c, d, a, b, x[k + 6], S43, 0xA3014314); b = II(b, c, d, a, x[k + 13], S44, 0x4E0811A1); a = II(a, b, c, d, x[k + 4], S41, 0xF7537E82); d = II(d, a, b, c, x[k + 11], S42, 0xBD3AF235); c = II(c, d, a, b, x[k + 2], S43, 0x2AD7D2BB); b = II(b, c, d, a, x[k + 9], S44, 0xEB86D391); a = AddUnsigned(a, AA); b = AddUnsigned(b, BB); c = AddUnsigned(c, CC); d = AddUnsigned(d, DD); }
    var temp = WordToHex(a) + WordToHex(b) + WordToHex(c) + WordToHex(d); return temp.toLowerCase();
}
function IframeAuto(obj) { var main = $(window.parent.document).find(obj); thisheight = $("body").children(".gbox").height(); main.height(thisheight + 30); }
var Sys = {}; var ua = navigator.userAgent.toLowerCase(); var s; (s = ua.match(/msie ([\d.]+)/)) ? Sys.ie = s[1] : (s = ua.match(/firefox\/([\d.]+)/)) ? Sys.firefox = s[1] : (s = ua.match(/chrome\/([\d.]+)/)) ? Sys.chrome = s[1] : (s = ua.match(/opera.([\d.]+)/)) ? Sys.opera = s[1] : (s = ua.match(/version\/([\d.]+).*safari/)) ? Sys.safari = s[1] : 0; function changeContent(url) { window.Main_Iframe.location = url; }
function correctPNG() {
    var arVersion = navigator.appVersion.split("MSIE")
    var version = parseFloat(arVersion[1])
    if ((version >= 5.5) && (document.body.filters)) {
        for (var j = 0; j < document.images.length; j++) {
            var img = document.images[j]
            var imgName = img.src.toUpperCase()
            if (imgName.substring(imgName.length - 3, imgName.length) == "PNG") {
                var imgID = (img.id) ? "id='" + img.id + "' " : ""
                var imgClass = (img.className) ? "class='" + img.className + "' " : ""
                var imgTitle = (img.title) ? "title='" + img.title + "' " : "title='" + img.alt + "' "
                var imgStyle = "display:inline-block;" + img.style.cssText
                if (img.align == "left") imgStyle = "float:left;" + imgStyle
                if (img.align == "right") imgStyle = "float:right;" + imgStyle
                if (img.parentElement.href) imgStyle = "cursor:hand;" + imgStyle
                var strNewHTML = "<span " + imgID + imgClass + imgTitle
+ " style=\"" + "width:" + img.width + "px; height:" + img.height + "px;" + imgStyle + ";"
+ "filter:progid:DXImageTransform.Microsoft.AlphaImageLoader"
+ "(src=\'" + img.src + "\', sizingMethod='scale');\"></span>"
                img.outerHTML = strNewHTML
                j = j - 1
            } 
        } 
    }
}

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
        case "username":
            Authentication = /^[0-9a-zA-Z_]{5,20}$/;
            break;
        case "password":
            Authentication = /^.{6,30}$/;
            break;
        case "number":
            Authentication = /^(0|[1-9][0-9]*)$/;
            break;
        case "decimal":
            Authentication = /\.\d{1,2}$/;
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
    if (length != 0 && jQuery(obj).val().toString().length > length) {
        jQuery(obj).parent().parent().find("#" + errarlbl).html("长度必须小于" + length + "&nbsp;&nbsp;&nbsp;");
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

function ShowTipDiv(timeout) {
    if (timeout == "") {
        timeout = 0;
    }
    if ($("#datagrid-mask").length == 0) {
        $("<div id=\"datagrid-mask\" style=\"background:#666666;position:absolute;left:0;top:0;\"></div>").css({ display: "none", width: $("body")[0].offsetWidth + 10, height: $("body").height() }).appendTo("body");
        $("<div id=\"datagrid-mask-msg\" style=\"position:absolute;\"></div>").html("<img src='/images/loading.gif'/>").appendTo("body").css({ display: "none", left: ($(window).width() - 16) / 2 + 'px', top: '278.5px' });
    }
    $("#datagrid-mask,#datagrid-mask-msg").delay(timeout).show(0, function () {
        $("#datagrid-mask").css("-moz-opacity", "0.4");
        $("#datagrid-mask").css("opacity", ".40");
        $("#datagrid-mask").css("filter", "alpha(opacity = 40)");
    });

}

function HideTipDiv() {
    if ($("#datagrid-mask").length > 0) {
        $("#datagrid-mask,#datagrid-mask-msg").stop();
        $("#datagrid-mask,#datagrid-mask-msg").stop();
        $("#datagrid-mask,#datagrid-mask-msg").hide();
    }
}