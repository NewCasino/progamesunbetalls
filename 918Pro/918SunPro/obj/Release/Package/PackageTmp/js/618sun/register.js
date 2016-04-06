(function ($) {
    //-----------------注册业务逻辑开始---------------------------
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

  
    GetNotices();
    GetPro_setup();
    function GetPro_setup() {
        var noticeHTML = "";
        var url = "/ServiceFile/UserService.asmx/GetPro_setup";
        var data = "";
        $.AjaxCommon({
            url: url, data: '', toSuccess: function (json) {
                var result = $.parseJSON(json.d);

                $('#pro_setup').attr('href', result[0].Oval);

            }
        });
    }
    function GetNotices() {
        var noticeHTML = "";
        var url = "/ServiceFile/UserService.asmx/GetNoticeBylan";
        var data = "";
        $.AjaxCommon({
            url: url, data: data, toSuccess: function (json) {
                var result = $.parseJSON(json.d);
                $.each(result, function (i) {
                    noticeHTML += "<span >" + result[i].Msgcn + "</span>　";
                });
                $("#demo2").html(noticeHTML);


            }
        });
    }

    $("#dialog2").dialog({
        autoOpen: false,
        width: 543,
        height: 230,
        modal: true,
        resizable: false,
        buttons: [
               {
                   text: "关  闭",
                   click: function () {
                       $('#TipData').html("");
                       $(this).dialog("close");
                   }
               }
        ]
    });

    $("#dialog3").dialog({
        autoOpen: false,
        width: 503,
        height: 330,
        modal: true,
        resizable: false,
        buttons: [
               {
                   text: "关  闭",
                   click: function () {
                       $('#TipData3').html("");
                       $(this).dialog("close");
                   }
               }
        ]
    });



    var flagOBJ = {
        userName_F: false,
        trueName_F: false,
        phone_F: false,
        QQ_F: false,
        email_F: false

    };

    $("#imgCode").click(function () {
        fnChangeCode();
    });

    function fnChangeCode() {
        url = "/ValiCode.aspx?id=" + Math.random();
        $("#imgCode").attr("src", url); codeStatus = "no";
    }


    $("#moreName").click(function () {
        checkUser($("#userb"));
    });
    $("#userb").blur(function () {
        var re1 = /^[A-Za-z0-9]+$/;
        if (!re1.test($("#userb").val())) {
            $("#userb").val('').focus();
        } else {
            checkUser($(this));
        }

    });

    $("#moreName").click(function () {
        checkUser($("#userb"));
    });


    $("#a6").blur(function () {
        checkQQ();

    });
    $("#user_cell").blur(function () {
        checkPhone();

    });

    $("#youxiang").blur(function () {
        checkEmail();
    });

    $("#a1").blur(function () {
        checkTrueName();

    });

    $("#yz").blur(function () {
        if ($("#yz").length < 1 || $("#yz").length > 4) {
            $('#TipData').css({ color: "red", 'font-size': "14px" }).html("<i></i>请输入正确的验证码!");
            $("#dialog2").dialog("open");
        }
    });

    function checkQQ() {
        var $name = $("#a6");
        var u_name = $name.val();
        var re1 = new RegExp("/^[0-9]{1,20}$/");
        if (u_name.length < 4) {
            $('#TipData').css({ color: "red", 'font-size': "14px" }).html("<i></i>请输入QQ");
            $("#dialog2").dialog("open");

            flagOBJ.QQ_F = false;
            return false;
        } else {
            flagOBJ.QQ_F = true;
            return;
        }
    }


    function checkPhone() {


        var $cell = $('#user_cell');
        var u_phone = $cell.val();
        if (u_phone == '') {
            $('#TipData').css({ color: "red", 'font-size': "14px" }).html("<i></i>请填写手机号码");
            $("#dialog2").dialog("open");
            flagOBJ.phone_F = false;
            return false;
        }
        else if (u_phone.search(/^14\d{9}$/) == -1 && u_phone.search(/^13\d{9}$/) == -1 && u_phone.search(/^15[0-35-9]\d{8}$/) == -1 && u_phone.search(/^18[0-35-9]\d{8}$/) == -1) {
            $('#TipData').css({ color: "red", 'font-size': "14px" }).html("<i></i>请填写真实有效的手机号码");
            $("#dialog2").dialog("open");
            flagOBJ.phone_F = false;
            return false;
        } else {
            flagOBJ.phone_F = true;
        }

    }

    function checkTrueName() {

        var $name = $("#a1");
        var u_name = $name.val();
        var re1 = new RegExp("[\u4e00-\u9fa5]");
        if (u_name.length < 2) {
            $('#TipData').css('color', 'red').html("<i></i>客户姓名不能少于两位");
            $("#dialog2").dialog("open");
            flagOBJ.trueName_F = false;
            return false;
        } else if (!re1.test(u_name)) {
            $('#TipData').css('color', 'red').html("<i></i>客户姓名请输入中文");
            $("#dialog2").dialog("open");
            flagOBJ.trueName_F = false;
            return false;
        } else {

            flagOBJ.trueName_F = true;
        }
    }

    //用户合法验证
    function checkUser(element) {

        var $user = element;
        var u_huiyuan = '618s' + $user.val();


        if (u_huiyuan.length < 6 || u_huiyuan.length > 12) {

            $('#TipData').html("用户名称不合法!<br/>请重新选择!(账户由618s加2-6位字母，数字组成（禁止汉字）");
            $("#dialog2").dialog("open");
            flagOBJ.userName_F = false;
            $("#userb").focus();

        } else {
            $('#J_eoor1').hide();
            jQuery.AjaxCommon({
                url: "/ServiceFile/UserService.asmx/IsExistUsername", datas: "username:'" + u_huiyuan + "'", asy: false,
                beforeSend: function () {
                    ShowTipDiv(0);
                },
                complete: function () {
                    HideTipDiv();
                },
                toSuccess: function (json) {
                    if (json.d) {

                        $('#TipData').html("<i></i>号码已存在,请使用新的号码注册<br/>请重新选择!(账户由618s加2-6位字母，数字组成（禁止汉字）");
                        $("#dialog2").dialog("open");
                        $("#userb").focus();
                        flagOBJ.userName_F = false;
                        return false;

                    } else {
                        $('#TipData').html("<i></i><span style='color:green'>恭喜你，此号码可以使用!</span>");
                        $("#dialog2").dialog("open");
                        flagOBJ.userName_F = true;

                    }

                }
            });

        }
    }

    function checkUser2(element) {

        var $user = element;
        var u_huiyuan = '618s' + $user.val();


        if (u_huiyuan.length < 6 || u_huiyuan.length > 12) {

            $('#TipData').html("用户名称不合法!<br/>请重新选择!(账户由618s加2-6位字母，数字组成（禁止汉字）");
            $("#dialog2").dialog("open");
            flagOBJ.userName_F = false;
            $("#userb").focus();

        } else {
            $('#J_eoor1').hide();
            jQuery.AjaxCommon({
                url: "/ServiceFile/UserService.asmx/IsExistUsername", datas: "username:'" + u_huiyuan + "'", asy: false,
                beforeSend: function () {
                    ShowTipDiv(0);
                },
                complete: function () {
                    HideTipDiv();
                },
                toSuccess: function (json) {
                    if (json.d) {

                        $('#TipData').html("<i></i>号码已存在,请使用新的号码注册<br/>请重新选择!(账户由618s加2-6位字母，数字组成（禁止汉字）");
                        $("#dialog2").dialog("open");
                        $("#userb").focus();
                        flagOBJ.userName_F = false;
                        return false;

                    } else {
                        flagOBJ.userName_F = true;

                    }

                }
            });

        }
    }
    function checkEmail() {
        var $email = $("#youxiang");
        var u_email = $email.val();
        var patten = new RegExp(/^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]+$/);
        if (!patten.test(u_email)) {
            $('#TipData').css({ color: "red", 'font-size': "14px" }).html("<i></i>请填写真实有效的Email");
            $("#dialog2").dialog("open");
            flagOBJ.email_F = false;
            return false;
        } else {
            jQuery.AjaxCommon({
                url: "/ServiceFile/UserService.asmx/IsExistEmail", datas: "mail:'" + u_email + "'", asy: false, toSuccess: function (json) {
                    if (json.d) {
                        $('#TipData').css({ color: "red", 'font-size': "14px" }).html("<i></i>Email已存在,请使用新的Email");
                        $("#dialog2").dialog("open");

                        flagOBJ.email_F = false;
                        return false;
                    } else {
                        flagOBJ.email_F = true;
                        return;
                    }
                }

            });

        }
    }




    function checkYZM() {
        var $YZM = $("#yzm");
        var u_YZM = $YZM.val();
        if (u_YZM.length != 4 || u_YZM.match(/[^0-9a-zA-Z]/)) {
            $('#TipData').css({ color: "red", 'font-size': "14px" }).html("<i></i>验证码输入有误");
            $("#dialog2").dialog("open");

            flagOBJ.yzm_F = false;
            return false;
        } else {

            jQuery.AjaxCommon({
                url: "/ServiceFile/LoginService.asmx/CheckCode", datas: "code:'" + u_YZM + "',typ:'0'", asy: false, toSuccess: function (json) {
                    if (json.d) {

                        flagOBJ.yzm_F = true;
                    }
                    else {
                        $('#TipData').css({ color: "red", 'font-size': "14px" }).html("<i></i>* 验证码输入有误");
                        $("#dialog2").dialog("open");

                        flagOBJ.yzm_F = false;
                        return false;
                    }
                }
            });
        }
    }


    function check() {
        $('#TipData').html("");
        checkUser2($("#userb"));
        checkPhone();
        checkEmail();
        checkTrueName();
        checkQQ();
        checkYZM();
        var falg = true;
        $.each(flagOBJ, function (n, value) {
            var key = n;
            var val = value;
            if (val == false) {

                falg = false;
                return false;
            }
        });
        return falg;
    }

    $("#btnSubmit").click(function () {
        var falg = check();
        $('#TipData').html("");
        if (!falg) {
            $('#TipData').html("您填写资料有误，请按要求输入!");
            $("#dialog2").dialog({
                autoOpen: true,
                width: 543,
                height: 284,
                modal: true,
                resizable: false,

                buttons: [

                {
                    text: "取   消",
                    click: function () {
                        $('#TipData').html("");
                        $(this).dialog("close");
                    }
                }
                ]
            });
            return false;
        }


        var usernames = "618s" + $("#userb").val().replaceDanYinHao();

        var data = "UserName:'" + usernames + "',"
        data += "Password:'aa112233',";
        var nums = $('#num1').val() + $('#num2').val() + $('#num3').val() + $('#num4').val();
        data += "TCpassword:'" + nums + "',";


        data += "Name:'" + $("#a1").val().replaceDanYinHao() + "',";
        data += "Birthday:'',";
        data += "Tel:'" + $("#user_cell").val() + "',";
        data += "Email:'" + $("#youxiang").val().replaceDanYinHao() + "',";
        data += "post:'" + $("#a6").val().replaceDanYinHao() + "',";



        data += "question:'n/a',";

        data += "Answer:'n/a',";

        data += "Agent:'" + $("#agent").val() + "',";

        data += "code:'" + $("#yzm").val() + "'";

        jQuery.AjaxCommon({
            url: "/ServiceFile/UserService.asmx/AddUser", datas: data,
            beforeSend: function () {
                ShowTipDiv(0);
            },
            complete: function () {
                HideTipDiv();
            },
            toSuccess: function (json) {
                if (json.d == "ok") {
                    $('#TipData3').html("<span style='font-size:19px; color:green;font-weight:900;text-align:center'>恭喜您，注册成功！请注意查收邮件！</span><br><br><span style='font-size:13px; color:black;align:right;font-weight:600'>游戏帐号五分钟内自动激活，请稍后。</span><span style='font-size:13px; color:black;align:right;font-weight:600'>请牢记以下信息！</span><br><br><span style='font-size:15px; color:red;align:right;font-weight:900'> 游戏帐号&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;：</span><span style='font-size:13px; color:black;align:right;font-weight:600'>" + usernames + "</span><br><span style='font-size:14px; color:red;align:right;font-weight:900'>初始游戏密码：</span><span style='font-size:13px; color:black;align:right;font-weight:600'>aa112233</span><br><span style='font-size:14px; color:red;align:right;font-weight:900'>取款密码&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;：</span><span style='font-size:13px; color:black;align:right;font-weight:600'>" + nums + "</span><br><br><span style='font-size:13px; color:black;align:right;font-weight:600'>温馨提示：为了您的帐号安全，进入游戏后请更改游戏密码。</span></span>");
                    $("#dialog3").dialog({
                        autoOpen: true,
                        width: 503,
                        height: 384,
                        modal: true,
                        resizable: false,

                        buttons: [

                        {
                            text: "返回首页",
                            click: function () {
                                window.location = "/index.html";
                            }
                        }
                        ]
                    });


                }
                else if (json.d == "1000") {
                    $('#TipData3').html("<span style='font-size:19px; color:green;font-weight:900;text-align:center'>恭喜您！注册成功，但您的邮箱收取邮件出现问题.请确保邮箱的有效性。</span><br><br><span style='font-size:13px; color:black;align:right;font-weight:600'>游戏帐号五分钟内自动激活，请稍后。</span><span style='font-size:13px; color:black;align:right;font-weight:600'>请牢记以下信息！</span><br><br><span style='font-size:15px; color:red;align:right;font-weight:900'> 游戏帐号&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;：</span><span style='font-size:13px; color:black;align:right;font-weight:600'>" + usernames + "</span><br><span style='font-size:14px; color:red;align:right;font-weight:900'>初始游戏密码：</span><span style='font-size:13px; color:black;align:right;font-weight:600'>aa112233</span><br><span style='font-size:14px; color:red;align:right;font-weight:900'>取款密码&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;：</span><span style='font-size:13px; color:black;align:right;font-weight:600'>" + nums + "</span><br><br><span style='font-size:13px; color:black;align:right;font-weight:600'>温馨提示：为了您的帐号安全，进入游戏后请更改游戏密码。</span></span>");
                    $("#dialog3").dialog({
                        autoOpen: true,
                        width: 503,
                        height: 384,
                        modal: true,
                        resizable: false,

                        buttons: [

                        {
                            text: "返回首页",
                            click: function () {
                                window.location = "/index.html";
                            }
                        }
                        ]
                    });

                   
                }
                else if (json.d == "err2") {
                    alert("查无此代理存在，请确认");
                }
                else if (json.d == "email") {
                    alert("邮箱重复，请换一个邮箱!");
                }
                else if (json.d == "err8") {
                    alert("账户名含有非法字符，请勿使用以下字符:' ,“,\,/,>,<,&,#,--,% ,?,$, SPACE,DOUBLE,BYTE,CHAR,TAB,NULL,LINE,FEED....");
                }
                else if (json.d == "err9") {
                    alert("账户名长度为6-15字符.");
                } else if (json.d == "err110") {
                    alert("请输入密码");
                }
                else if (json.d == "err111") {
                    alert("请输入您的姓名!");
                }
                else if (json.d == "err220") {
                    alert("用户名已注册，请重新输入!");
                }
                else if (json.d == "err112") {
                    alert("请输入您生日日期！");
                }
                else if (json.d == "err113") {
                    alert("请输入您手机号码！");
                }
                else if (json.d == "err114") {
                    alert("请输入您邮箱！");
                }
                else if (json.d == "err115") {
                    alert("请输入您QQ！");
                }
                else if (json.d == "err116") {
                    alert("请输入您安全问题！");
                }
                else if (json.d == "err440") {
                    $.cookie("tid", "618sun", { expires: 90 });
                    alert("此链接代理号不存在，请检查是存正确！如继续注册将在官网下");
                } else if (json.d == "err11198") {
                    alert("为了您得安全，密码不能为纯数字！请重新输入.");
                }
                else {
                    alert("会员注册失败" + "！");
                }

            }
        });




    });


})(jQuery);
//var customURL = "http://f88.live800.com/live800/chatClient/chatbox.jsp?companyID=504420&configID=127905&jid=3308311799&operatorId=56512"; /*客服链接*/

//function openwin() {
//    window.open(customURL, '申博客服', 'height=570, width=750, toolbar=no, menubar=no, scrollbars=no, resizable=no, location=no, status=no');
//}

//function canleB() {
//    window.location = "/index.html";
//}