(function ($) {
    GetNotices();
    GetPro_setup();
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

    $('.money_t ul li').click(function () {

        var nub = $(this).index();
        $('.zx_zhifu_t').each(function () {
            if ($(this).index() - 1 == nub) {
                $(this).show();
            } else {
                $(this).hide();
            }

        })
    });

    $('#TipData').html("");
    $("#dialog4").dialog({
        autoOpen: false,
        width: 321,
        height: 230,
        modal: true,
        resizable: false,
        buttons: [
                    {
                        text: "关  闭",
                        click: function () {
                            $(this).dialog("close");
                        }
                    }
        ]
    });

    $("#LoinClick").click(function () {
        CheckSubmit();

    });

    function CheckSubmit() {
        $('#TipData').html("").css("color", "red").css("font-weight", "300");
        // debugger
        var msg = true;
        var txtMember = $("#username");

        var txtPass = $("#password");
        var txtCode = $("#code1");

        if ($.trim(txtMember.val()) == "") {
            $('#TipData').html("请输入您的会员账号！");
            $("#dialog4").dialog("open");
            txtMember.focus();
            msg = false;
            return false;

        }
        else {
            jQuery.AjaxCommon({
                url: "/ServiceFile/UserService.asmx/IsAgentUser", datas: "username:'" + $.trim(txtMember.val()).replaceDanYinHao() + "'", asy: false, toSuccess: function (json) {
                    if (json.d) {
                        $('#TipData').html("此帐号已注册，请您重新选择！");
                        $("#dialog4").dialog("open");
                        msg = false;
                        return false;
                    } else {
                        jQuery.AjaxCommon({
                            url: "/ServiceFile/UserService.asmx/IsExistUsername", datas: "username:'" + $.trim(txtMember.val()).replaceDanYinHao() + "'", asy: false,
                            beforeSend: function () {
                                ShowTipDiv(0);
                            },
                            complete: function () {
                                HideTipDiv();
                            },
                            toSuccess: function (json) {
                                if (json.d) {
                                    $('#TipData').html("此帐号已注册，请您重新选择！");
                                    $("#dialog4").dialog("open");
                                    msg = false;
                                    return false;

                                }

                            }
                        });

                    }
                }
            });

        }



        if ($.trim(txtPass.val()) == "") {
            $('#TipData').html("- 请输入您的账号密码！\n");
            $("#dialog4").dialog("open");

            txtPass.focus();
            msg = false;
            return false;
        }


        var txtPass1 = document.getElementById('password');
        var txtPass2 = document.getElementById('password2');
        var txtMail = document.getElementById('email1');
        var txtTel = document.getElementById('tell1');
        var _name = document.getElementById('_name');

        var Answers = document.getElementById('Answer');
        var txtqq = document.getElementById('txtqq');
        var txtCardNo = document.getElementById('txtCardNo');
        var txtName = document.getElementById('txtName');
        var txtBank = document.getElementById('txtBank');
        var Select1 = document.getElementById('Select1');


        if ($.trim(txtPass1.value) == "") {
            $('#TipData').html("- 请输入账户密码信息！\n");
            $("#dialog4").dialog("open");


            txtPass1.focus();
            msg = false;
            return false;
        }


        if (txtPass2.value == "") {
            $('#TipData').html("- 请输入确认密码信息！\n");
            $("#dialog4").dialog("open");


            txtPass2.focus();
            msg = false;
            return false;
        }
        if (txtPass2.value != txtPass1.value) {
            $('#TipData').html("- 两次输入的密码不一致！\n");
            $("#dialog4").dialog("open");


            txtPass2.focus();
            msg = false;
            return false;
        }
        if (_name.value == "") {
            $('#TipData').html("- 请输入您真实姓名，必須與提款時銀行戶名一致才能出款！\n");
            $("#dialog4").dialog("open");

            txtMail.focus();
            msg = false;
            return false;
        }
        if (Answers.value == "") {
            $('#TipData').html("- 请输入安全问题回答！\n");
            $("#dialog4").dialog("open");


            txtMail.focus();
            msg = false;
            return false;
        }
        if (txtCardNo.value == "") {
            $('#TipData').html("- 请输入您的银行账号\n");
            $("#dialog4").dialog("open");


            txtCardNo.focus();
            msg = false;
            return false;
        }

        if (txtBank.value == "") {
            $('#TipData').html("- 请输入您的开户银行名称\n");
            $("#dialog4").dialog("open");


            txtBank.focus();
            msg = false;
            return false;
        }
        if (txtTel.value == "") {
            $('#TipData').html("- 请输入电话号码信息！\n");
            $("#dialog4").dialog("open");


            txtTel.focus();
            msg = false;
            return false;
        }



        if (txtMail.value == "") {
            $('#TipData').html("- 请输入电子邮件信息！\n");
            $("#dialog4").dialog("open");

            txtMail.focus();
            msg = false;
            return false;
        }
        else {


            jQuery.AjaxCommon({
                url: "/ServiceFile/UserService.asmx/IsExistEmailAgent", datas: "mail:'" + txtMail.value.replaceDanYinHao() + "'", asy: false, toSuccess: function (json) {
                    if (json.d) {
                        $('#TipData').html("- 电子邮箱已存，请您重新输入！\n");
                        $("#dialog4").dialog("open");


                        msg = false;
                        return false;
                    }

                }
            });
        }

        if (txtqq.value == "") {
            $('#TipData').html("- 请输入您的QQ号码，方便与您沟通\n");
            $("#dialog4").dialog("open");

            txtqq.focus();
            msg = false;
            return false;
        }





        if (msg == true) {
            //debugger

            var data = "UserName:'" + $("#username").val().replaceDanYinHao() + "',"

            // var data = "";
            data += "Password:'" + $("#password").val().replaceDanYinHao() + "',";

            var nums = "8888";
            data += "nums:'" + nums + "',";

            data += "Name:'" + $("#_name").val().replaceDanYinHao() + "',";

            data += "question:'" + $("#question").val().replaceDanYinHao() + "',";
            data += "Answer:'" + $("#Answer").val().replaceDanYinHao() + "',";
            data += "CardNo:'" + $("#txtCardNo").val() + "',bankname:'" + $("#txtBank").val() + "',";

            data += "Tel:'" + $("#tell1").val() + "',";
            data += "Email:'" + $("#email1").val().replaceDanYinHao() + "',";
            data += "qq:'" + $("#txtqq").val().replaceDanYinHao() + "'";


            //  debugger
            jQuery.AjaxCommon({
                url: "/ServiceFile/AgnetService.asmx/AddUser", datas: data, toSuccess: function (json) {
                    if (json.d == "ok") {

                        $('#TipData').html("代理申请成功！</br>审核过程中我们的工作人员会跟您联系，请保持手机畅通及留意QQ留言，谢谢！").css("color", "green").css("font-weight", "800");
                        $("#dialog4").dialog("open");
                        window.location = "/index.html";
                    }
                    else if (json.d == "email") {
                        $('#TipData').html("邮箱重复，请换一个邮箱！");
                        $("#dialog4").dialog("open");


                    }
                    else {
                        $('#TipData').html("代理申请失败,请联系客服！");
                        $("#dialog4").dialog("open");

                    }

                }
            });
        }


    }

    $('#email1').blur(function () {
        $('#TipData').html("").css("color", "red").css("font-weight", "300");
        var reg = /^[a-zA-Z0-9_-]+(\.([a-zA-Z0-9_-])+)*@[a-zA-Z0-9_-]+[.][a-zA-Z0-9_-]+([.][a-zA-Z0-9_-]+)*$/;
        if (this.value != "" && !reg.test(this.value)) {
            this.select();
            $('#TipData').html("电子邮箱格式输入错误！");
            $("#dialog4").dialog("open");

            this.focus();
            return false;
        }
        else {
            $("#txtemail").html("");
        }
    });




})(jQuery);
//var customURL = "http://f88.live800.com/live800/chatClient/chatbox.jsp?companyID=504420&configID=127905&jid=3308311799&operatorId=56512"; /*客服链接*/

//function openwin() {
//    window.open(customURL, '申博客服', 'height=570, width=750, toolbar=no, menubar=no, scrollbars=no, resizable=no, location=no, status=no');
//}