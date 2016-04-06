var customURL = "http://f18.livechatvalue.com/chat/chatClient/chatbox.jsp?companyID=493978&jid=1206637488&";//客服链接
var host = "http://" + window.location.host + "/include/loginCont.php";//申博登陆返回地址
var gameUrl = "http://www.55psb.com/game.aspx?src=portal&langCd=zh-CN";//游戏登陆地址
//加载layer插件的扩展库
layer.config({
    extend: [
        'extend/layer.ext.js',
        'skin/myskin/style.css',
        'skin/myskin/login.css',
        'skin/myskin/agreement.css'
    ]
});
$(function () {
    //弹出新窗口
    $(".open-small-win").on('click', function (event) {
        var url = $(this).attr('href');
        var title = $(this).html();
        $.post(url, {}, function (str) {
            var smallWin = layer.open({
                title: title,
                area: ['80%', '80%'],
                type: 1,
                closeBtn: true, //不显示关闭按钮
                shift: 2,
                shadeClose: true, //开启遮罩关闭
                skin: 'layer-ext-myskin',
                content: str
            });
        });
        event.preventDefault();
    });

    function openLoading() {
        var loading = layer.load(1, {
            shade: [0.1, '#fff'] //0.1透明度的白色背景
        });
    }

    //绑定登陆事件
    $(".login-click").on('click',function(){
        showGameLayer();
    })

});
function openwin() {
    window.open(customURL, '申博客服', 'height=460, width=700, toolbar=no, menubar=no, scrollbars=no, resizable=no, location=no, status=no');
}

function openLayer() {
    layer.closeAll();
    var agreeLayer = layer.open({
        type: 1,
        title: '用户协议书',
        skin: 'agreement-class',
        area: ['900px', '550px'],
        icon: 1,
        shade: 0.8,
        closeBtn: false,
        btn: ['同意', '不同意'],
        yes: function (index, layero) {
            layer.close(agreeLayer);
            window.open('gameStart.html');
        }, cancel: function (index) {
            layer.close(agreeLayer);
        },
        shadeClose: true,
        content: $('#tncDetail')
    });
}

function openGame() {
    layer.closeAll();
    var gameLayer = layer.open({
        type: 2,
        title: '欢迎进入游戏',
        shadeClose: true,
        shade: false,
        maxmin: true,
        area: ['1150px', '650px'],
        content: gameUrl
    });
}

function showGameLayer() {
    var gameLoginLayer = layer.open({
        type: 1,
        title: false,
        shadeClose: true,
        skin: 'layui-layer-nobg', //没有背景色
        closeBtn: false,
        area: '400px',
        content: $('#_tgp_widget_overlay_')
    });
}
