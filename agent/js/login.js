jQuery(function ($) {
//debugger
    SetGlobal("");
    $("#selLanguage").change(function () {  //多语言选择
        SetGlobal(this.value);
    });
});
var languages = "", codeStatus = "no";
var lang;
function SetGlobal(setLang) {
    setLang = $.SetOrGetLanguage(setLang, function () {
    
        languages = language;
        $("#splanguage").html(languages.选择语言 + ":");
        $("#spusername").text(languages.用户名 + ":");
        $("#sppassword").text(languages.密码 + ":");
        $("#spCode").text(languages.验证码 + ":");
        $("#btnlogin").val(languages.登录);
        document.title = "E尊国际代理平台系统登录";
        $("#validatecode").attr({ "title": languages.点击换一张, "alt": languages.点击换一张 });
        $("#selLanguage").val(setLang);
        lang = setLang;
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
    
    var offset = $("#selLanguage").offset();
    if ($.trim($("#txtusername").val()).length == 0) {
        $.MsgTip({ objId: "#divTip", msg: languages.用户名不能为空, left: offset.left - 20, top: offset.top + 130 });
        $("#txtusername").focus();
        return;
    }
    if ($.trim($("#txtpassword").val()).length == 0) {
        $.MsgTip({ objId: "#divTip", msg: languages.密码不能为空, left: offset.left - 20, top: offset.top + 130 });
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
        var data = "messageId:'" + $("#txtusername").val() + "',password:'" + $("#txtpassword").val() + "',language:'"+$("#selLanguage").val()+"'";
        $.AjaxCommon(url, data, true, false, function (json) {
            if (json.d) {
                //alert(lang);
                /*
                switch (lang) {
                    case "zh-cn":
                        window.location.replace("/index.htm");
                        break;
                    case "zh-tw":

                        break
                    case "en-us":
                        window.location.replace("/en/index.htm");
                        break;
                }
                */
                window.location.replace("/index.htm");
            }
            else {
                $.MsgTip({ objId: "#divTip", msg: languages.用户名或密码错误, left: offset.left - 20, top: offset.top + 130 });

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