jQuery(function ($) {
    SetGlobal("");
    $("#selLanguage").change(function () {  //多语言选择
        SetGlobal(this.value);
    });
});
var languages = "", codeStatus = "no";
function SetGlobal(setLang) {

    setLang = $.SetOrGetLanguage(setLang, function () {
        languages = language;
      
        $("#sppassword").text(languages.密码);
        $("#spCode").text(languages.验证码);
        $("#btnlogin").val(languages.登录);
        document.title = "系统后台登录";
        $("#validatecode").attr({ "title": languages.点击换一张, "alt": languages.点击换一张 });
        $("#selLanguage").val(setLang);
    });




}
function CheckCode(code) {
    //
    $("#imgCodeTip").show();
    if (code.length != 4) {
        codeStatus = "no";
        $("#imgCodeTip").attr("src", "/images/Login/onError.gif");
        return;
    }
    var url = "/ServicesFile/LoginService.asmx/CheckCode";
    var data = "code:'" + code + "'";
    $.AjaxCommon(url, data, true, false, function (json) {
    
        if (json.d) {
            
            codeStatus = "yes";
            $("#imgCodeTip").attr("src", "/images/Login/onSuccess.gif");
        }
        else {
            codeStatus = "no";
            $("#imgCodeTip").attr("src", "/images/Login/onError.gif");
        }

    });
}
function CheckLogin() {    
   
    if ($.trim($("#txtusername").val()).length == 0) {
        $.MsgTip({ objId: "#divTip", msg: languages.用户名不能为空, left: 0, top: 0 });
        $("#txtusername").focus();
        return;
    }
    if ($.trim($("#txtpassword").val()).length == 0) {
        $.MsgTip({ objId: "#divTip", msg: languages.密码不能为空, left: 0, top: 0});
        $("#txtpassword").focus();
        return;
    }
    if ($.trim($("#txtCode").val()).length == 0) {
        $("#txtCode").focus();
        codeStatus = "no";
        $("#imgCodeTip").show().attr("src", "/images/Login/onError.gif");
        return;
    }

    if (codeStatus == "no") {
        $("#imgCodeTip").show().attr("src", "/images/Login/onError.gif");
        $("#txtCode").focus();
        $("#txtCode").select();
        return;
    }

        var url = "/ServicesFile/LoginService.asmx/CheckLogin";
        var data = "messageId:'" + $("#txtusername").val() + "',password:'" + $("#txtpassword").val() + "',language:'" + $("#selLanguage").val() + "'";
        $.AjaxCommon(url, data, true, false, function (json) {
            if (json.d) {
                window.location.replace("/Bootstrap/adminWeb/index.aspx");
                window.location.replace("/index.htm");
            }
            else {
                $.MsgTip({ objId: "#divTip", msg: languages.用户名或密码错误, left: 0, top: 0});

                $("#validatecode").attr("src", "ValiCode.aspx?id=" + Math.random());
                codeStatus = "no";
                $("#txtCode").val("");
                $("#imgCodeTip").show().attr("src", "/images/Login/onError.gif");
                $("#txtusername").focus();
                
            }
        });
    
}

jQuery(function ($) {
    $("#txtCode").keyup(function () {
        CheckCode(this.value);
    });
    $("body").keypress(function (e) {
        var currKey = 0, e = e || event;
        currKey = e.keyCode || e.which || e.charCode;
        if (currKey == 13) {
            CheckLogin();
        }
    });
    $("#btnlogin").click(function () {
        CheckLogin();
    }).hover(function () {
        $(this).addClass("btn_h");
    }, function () {
        $(this).removeClass("btn_h");
    });
});