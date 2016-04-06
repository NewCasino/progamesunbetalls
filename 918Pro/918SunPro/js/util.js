//设为首页
function SetHome(obj, url) {
    try {
        obj.style.behavior = 'url(#default#homepage)';
        obj.setHomePage(url);
    } catch (e) {
        if (window.netscape) {
            try {
                netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
            } catch (e) {
                alert("抱歉，此操作被浏览器拒绝！\n\n请在浏览器地址栏输入“about:config”并回车然后将[signed.applets.codebase_principal_support]设置为'true'");
            }
        } else {
            alert("抱歉，您所使用的浏览器无法完成此操作。\n\n您需要手动将【" + url + "】设置为首页。");
        }
    }
}

//收藏本站
function AddFavorite(title, url) {
    try {
        window.external.addFavorite(url, title);
    }
    catch (e) {
        try {
            window.sidebar.addPanel(title, url, "");
        }
        catch (e) {
            alert("抱歉，您所使用的浏览器无法完成此操作。\n\n加入收藏失败，请使用Ctrl+D进行添加");
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

var arg = GetRequest();
if (arg != undefined) {
    var u = arg["tid"];
    if (u != undefined) {
        $.cookie("tid", u, { expires: 90 });
    }
}

var agentid = $.cookie("tid");
if (agentid != null) {
    $("#agent").val(agentid);

}

$(document).ready(function () {

    var path = window.location.pathname;
    path = path.substring(0, path.lastIndexOf('/') + 1);
    var fileName = "templates";
    var $links = $(".ajaxLink");
    $.each($links, function () {
        if ($(this).hasClass('active')) {
            var URL = $(this).attr('href');
            URL = path + fileName + '/' + URL;
            getData(URL);
        };
    });

    setInterval(showTime, 1000);

    $("#meCenter").on('click', '.ajaxLink', function (event) {
        if ($(this).attr("data-style") == "left") {
            $(".ajaxLink[data-style=left]").removeClass('active');
            $(this).addClass('active');
        };
        var URL = $(this).attr('href');
        URL = path + fileName + '/' + URL;
        getData(URL);
        event.preventDefault();
    });
});

function getData(URL) {
    $("#hideBox").show();
    $.ajax({
        type: "GET",
        url: URL,
        data: '',
        dataType: "html",
        success: function (data) {
            $('#MACenterContent').empty();
            $('#MACenterContent').html(data);
        },
        complete: function () {
            $("#hideBox").hide();
        }
    });
}

function showTime() {
    var today = new Date();
    var weekday = new Array(7)
    weekday[0] = "星期一"
    weekday[1] = "星期二"
    weekday[2] = "星期三"
    weekday[3] = "星期四"
    weekday[4] = "星期五"
    weekday[5] = "星期六"
    weekday[6] = "星期日"
    var y = today.getFullYear() + "年";
    var month = today.getMonth() + "月";
    var td = today.getDate() + "日";
    var d = weekday[today.getDay()];
    var h = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();
    $('#timeText').html(y + month + td + d + h + ':' + m + ':' + s);
}

function mover(o) {
    o.style.backgroundPosition = '0 bottom';
}

function mout(o) {
    o.style.backgroundPosition = '0 top';
}

$(function () {
    var $kefuBox = $("#kefuBox");
    var boxR = $kefuBox.css("right");
    var winH = $(window).height() / 3;
    //$kefuBox.stop(true).animate({right: 0});
    //$kefuBox.stop(true).animate({top:winH},1000);

    $kefuBox.hover(
    function () {
        $kefuBox.stop(true).animate({ right: 0 });
    },
    function () {
        //$kefuBox.stop(true).animate({right: boxR});
        $kefuBox.stop(true).animate({ right: -190 });
    }
    );
});

var customURL = "http://f18.livechatvalue.com/chat/chatClient/chatbox.jsp?companyID=493978&jid=1206637488&"; /*客服链接*/
//var customURL = "http://kf1.learnsaas.com/chat/chatClient/chatbox.jsp?companyID=493978&configID=53149&jid=1206637488&skillId=3022"; /*客服链接*/

function openwin() {
    window.open(customURL, '申博客服', 'height=570, width=750, toolbar=no, menubar=no, scrollbars=no, resizable=no, location=no, status=no');
}

$(function () {
    $('.faqlist li h4').click(function () {
        $('.faqlist li p').not($(this).nextAll()).hide();
        $('.faqlist li h4 .switch_on').not($(this).children('.switch')).removeClass('switch_on');
        $(this).nextAll().toggle();
        $(this).children('.switch').toggleClass('switch_on');
    }).nextAll().hide();
});


