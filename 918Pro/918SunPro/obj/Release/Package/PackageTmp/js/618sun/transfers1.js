$(function () {
    $('.money ul li').click(function () {

        var nub = $(this).index();
        $('.zx_zhifu').each(function () {
            if (nub != 0) {
                window.location.href = 'transfers.aspx';
                return false;
            }           

        })
    });

    var isBool = true
    $("#imgCode").click(function () {
        fnChangeCode();

    });
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
                $("#give_content1").append("<option value='无优惠' selected>不申请优惠</option>");
                if (result[1].Oval != '') {
                    arrys = result[1].Oval.split('/');
                    if (arrys.length > 0) {
                        for (var i = 0; i < arrys.length; i++) {
                            $("#give_content1").prepend("<option value=" + (i + 1) + ">" + arrys[i] + "</option>");
                        }
                    }

                }

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
    //-----------------在线支付业务逻辑开始---------------------------
    function fnChangeCode() {
        url = "/ValiCode.aspx?id=" + Math.random();
        $("#imgCode").attr("src", url); codeStatus = "no";
    }

    function checkYZM() {
        var $YZM = $("#yzm");
        var u_YZM = $YZM.val();
        if (u_YZM.length != 4 || u_YZM.match(/[^0-9a-zA-Z]/)) {
            $('#TipData').html("验证码输入有误！");
            $("#dialog2").dialog("open");
            isBool = false;
            return false;
        } else {
            jQuery.AjaxCommon({
                url: "/ServiceFile/LoginService.asmx/CheckCode", datas: "code:'" + u_YZM + "',typ:'0'", asy: false, toSuccess: function (json) {
                    if (!json.d) {
                        $('#TipData').html("请输入正确的验证码！");
                        $("#dialog2").dialog("open");
                        $("#yzm")[0].focus();
                        isBool = false;
                        return false;
                    } else {
                        isBool = true;

                    }

                }
            });
        }
    }

    $("#Amount").blur(function () {
        var val = Number(this.value);
        var moneyWind = 100;
        if (val < moneyWind) {
            this.value = moneyWind;
        }
        if (val > 3000) {
            this.value = 3000;
        }
    });
    $("#dialog2").dialog({
        autoOpen: false,
        width: 321,
        height: 270,
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
        width: 430,
        height: 350,
        modal: true,
        resizable: false,
        buttons: [
           {
               text: "立刻冲值",
               click: function () {
                   $(this).dialog("close");
                   InsertDataBill();


               }
           },
           {
               text: "取   消",
               click: function () {
                   $(this).dialog("close");
               }
           }
        ]
    });


    $("#gameAccount").blur(function () {
        $('#TipData').html("");
        jQuery.AjaxCommon({
            url: "/ServiceFile/UserService.asmx/IsExistUsername",
            datas: "username:'" + $('#gameAccount').val() + "'",
            beforeSend: function () {
                ShowTipDiv(1000);
            },
            complete: function () {
                HideTipDiv();
            },
            toSuccess: function (json) {
                if (!json.d) {
                    $('#TipData').html("" + $("#gameAccount").val() + "  游戏帐号不存在，请核实帐号是否无误！");
                    $("#dialog2").dialog("open");
                    return false;
                }

            }
        });
    });

    $('#J-submit').click(function () {
        $('#TipData').html("");
        $('#isNO,#gameNO,#gameMon').html('');
        checkYZM();
        if ($('#gameAccount').val() == '') {
            $('#TipData').html("请输入您要冲值得游戏帐号！");
            $("#dialog2").dialog("open");
            return false;
        } else if ($('#Amount').val() == '') {
            $('#TipData').html("请输入您要冲值得金额！");
            $("#dialog2").dialog("open");
            return false;
        } else if ($('#yzm').val() == '') {
            $('#TipData').html("请输入验证码！");
            $("#dialog2").dialog("open");
            return false;
        } else if (!isBool) {
            return false;
        } else {

            jQuery.AjaxCommon({
                url: "/ServiceFile/UserService.asmx/IsExistUsername", datas: "username:'" + $('#gameAccount').val() + "'", beforeSend: function () {

                },
                complete: function () {

                },
                toSuccess: function (json) {
                    if (json.d) {

                        $('#isNO').html($("#order_nos")[0].value);
                        $('#gameNO').html($('#gameAccount').val());
                        $('#gameMon').html($("#Amount").val());
                        $("#dialog3").dialog("open");

                    }
                    else {
                        $('#TipData').html("游戏帐号不存在，请核实帐号是否无误！");
                        $("#dialog2").dialog("open");
                        return false;
                    }

                }
            });
        }


    });


    function InsertDataBill() {

        var data = "Amount:'" + Number($("#Amount").val()) + "',";
        // debugger; 
        //(string Amount, string bank, string bankno, string type, string cardNo, string Names)
        data += "bank:'汇潮支付',";
        data += "bankno:'" + $("#order_nos")[0].value + "',";
        data += "type:1,";
        data += "cardNo:'" + $('#gameAccount').val() + "',"; //存入帐号
        data += "Names:'',";
        data += "UserName:'" + $('#gameAccount').val().replaceDanYinHao() + "',";
        data += "Tel:'" + $("#give_content1").find("option:selected").text()+"'";
        jQuery.AjaxCommon({
            url: "/ServiceFile/BankService.asmx/InsertBillNotice", datas: data, beforeSend: function () {
                ShowTipDiv(0);
                $('#J-submit').attr({ "disabled": "disabled" });

            },
            complete: function () {
                HideTipDiv();
                $('#J-submit').removeAttr("disabled"); //将按钮可用
            },
            toSuccess: function (json) {
                if (json.d) {

                    $("#myform").submit();
                }
                else {
                    $('#TipData').html("同一订单禁止重复提交，请刷新页面，重新提交存款申请！");
                    $("#dialog2").dialog("open");
                    return false;

                }

            }
        });
    }
    //-----------------在线支付业务逻辑结束---------------------------

    //-----------------网银转汇业务逻辑开始---------------------------
    $("#Amount2").blur(function () {
        var val = Number(this.value);
        var moneyWind = 100;
        if (val < moneyWind) {
            this.value = moneyWind;
        }
        if (val > 100000) {
            this.value = 100000;
        }
    });
    $("#dialog2").dialog({
        autoOpen: false,
        width: 341,
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
    $("#dialog4").dialog({
        autoOpen: false,
        width: 341,
        height: 230,
        modal: true,
        resizable: false,
        buttons: [
              {
                  text: "关  闭",
                  click: function () {
                      $('#TipData2').html("");
                      $(this).dialog("close");
                      window.location = "/index.html";
                  }
              }
        ]
    });

    $("#dialog8").dialog({
        autoOpen: false,
        width: 450,
        height: 260,
        modal: true,
        resizable: false,
        buttons: [
          {
              text: "提交申请",
              click: function () {
                  $(this).dialog("close");
                  InsertDataBill2();


              }
          },
          {
              text: "取   消",
              click: function () {
                  $(this).dialog("close");

              }
          }
        ]
    });


    $("#gameAccount2").blur(function () {
        $('#TipData').html("");
        jQuery.AjaxCommon({
            url: "/ServiceFile/UserService.asmx/IsExistUsername",
            datas: "username:'" + $('#gameAccount2').val() + "'",
            beforeSend: function () {
                ShowTipDiv(1000);
            },
            complete: function () {
                HideTipDiv();
            },
            toSuccess: function (json) {
                if (json.d) {


                }
                else {
                    $('#TipData').html("" + $("#gameAccount2").val() + "  游戏帐号不存在，请核实帐号是否无误！");
                    $("#dialog2").dialog("open");


                    return false;
                }

            }
        });
    });

    $('#J-submit2').click(function () {
        $('#TipData').html("");
        $('#isNO2,#gameNO2,#gameMon2').html('');
        if ($('#gameAccount2').val() == '') {
            $('#TipData').html("请输入您要冲值得游戏帐号！");
            $("#dialog2").dialog("open");
            return false;
        } else if ($('#Amount2').val() == '') {
            $('#TipData').html("请输入您要冲值得金额！");
            $("#dialog2").dialog("open");
            return false;
        }
        else {
            jQuery.AjaxCommon({
                url: "/ServiceFile/UserService.asmx/IsExistUsername", datas: "username:'" + $('#gameAccount2').val() + "'", beforeSend: function () {

                },
                complete: function () {

                },
                toSuccess: function (json) {
                    if (json.d) {

                        $('#gameNO2').html($('#gameAccount2').val().replaceDanYinHao());
                        $('#gameMon2').html($("#Amount2").val());
                        $("#dialog8").dialog("open");

                    }
                    else {
                        $('#TipData').html("游戏帐号不存在，请核实帐号是否无误！");
                        $("#dialog2").dialog("open");
                        return false;
                    }

                }
            });
        }


    });


    function InsertDataBill2() {
        var marks = $('#ckfs2 option:selected').text() + ',' + $('#yhhd2 option:selected').text();
        var data = "Amount:'" + Number($("#Amount2").val()) + "',";
        // debugger; 
        //(string Amount, string bank, string bankno, string type, string cardNo, string Names)
        data += "bank:'" + $('#bankcode2 option:selected').text() + "',";
        data += "bankno:'" + $('#bankcode2 option:selected').text() + "',";
        data += "type:1,";
        data += "cardNo:'" + $('#bankcode2 option:selected').val() + "',"; //存入帐号
        data += "Names:'',";
        data += "UserName:'" + $('#gameAccount2').val().replaceDanYinHao() + "',";
        data += "Tel:'',";
        data += "Mark:'" + marks + "'";
        jQuery.AjaxCommon({
            url: "/ServiceFile/BankService.asmx/InsertBillNotice2s", datas: data, beforeSend: function () {
                ShowTipDiv(0);
            },
            complete: function () {
                HideTipDiv();
            },
            toSuccess: function (json) {
                if (json.d) {

                    $('#TipData2').html("您的存款申请已提交成功,我们会马上处理，请稍等！<br/>登入会员中心，将查询出款时时状态.").css("color", "green").css("font-weight", "800");
                    $("#dialog4").dialog("open");
                }
                else {
                    alert('帐号异常，请联系在线客服');
                }

            }
        });
    }

    //-----------------网银转汇业务逻辑结束---------------------------
    //-----------------提款业务逻辑开始---------------------------
    var isBool4 = true;
    $("#imgCode3").click(function () {
        fnChangeCode3();

    });

    function fnChangeCode3() {
        url = "/ValiCode.aspx?id=" + Math.random();
        $("#imgCode3").attr("src", url); codeStatus = "no";
    }




    $('#bankcode4').change(function () {
        if ($(this).val() == '000') {
            $("#tr_bankname").css("display", "inline");
        } else {
            $("#tr_bankname").css("display", "none");

        }
        $('#bankname4').val('');
    });

    $("#dialog10").dialog({
        autoOpen: false,
        width: 401,
        height: 270,
        modal: true,
        resizable: false,
        buttons: [
                 {
                     text: "关  闭",
                     click: function () {

                         $('#TipData10').html("");
                         $(this).dialog("close");
                         return false;
                     }
                 }
        ]
    });
    $("#dialog11").dialog({
        autoOpen: false,
        width: 451,
        height: 270,
        modal: true,
        resizable: false,
        buttons: [
                 {
                     text: "关  闭",
                     click: function () {

                         $('#TipData11').html("");
                         $(this).dialog("close");
                         window.location = "/index.html";
                         return false;
                     }
                 }
        ]
    });
    function checkYZM4(e) {
        var $YZM = $("#yzm4");
        var u_YZM = $YZM.val();
        if (u_YZM.length != 4 || u_YZM.match(/[^0-9a-zA-Z]/)) {
            $('#TipData10').html("验证码输入有误！");
            e.preventDefault();
            isBool = false;
            $("#dialog10").dialog("open");
            return false;

        } else {

            jQuery.AjaxCommon({
                url: "/ServiceFile/LoginService.asmx/CheckCode", datas: "code:'" + u_YZM + "',typ:'1'", asy: false, toSuccess: function (json) {
                    if (!json.d) {
                        $('#TipData10').html("请输入正确的验证码！");
                        $("#dialog10").dialog("open");
                        $("#yzm4")[0].focus();
                        e.preventDefault();
                        isBool = false;
                        return false;
                    } else {
                        isBool = true;

                    }

                }
            });
        }
    }

    $("#btn-qk").unbind("click").bind("click", function (e) {

        $('#TipData10').html("");
        checkYZM4(e);

        if ($("#price4").val() == "") {
            $('#TipData10').html("请输入提款金额！");
            $("#dialog10").dialog("open");
            $("#price4")[0].focus();
            return false;
        }
        else if (parseFloat($("#price4").val()) < 100) {
            $('#TipData10').html("提款金额必需大于等于100！");
            $("#dialog10").dialog("open");


            $("#price4")[0].focus();
            return false;
        }
            //else if (parseFloat($("#price4").val()) > 100) {
            //    //debugger
            //    var reg = /^[0-9]*[1-9][0-9]*$/;
            //    if ($("#price4").val() != "" && !reg.test($("#price4").val())) {

            //        $('#TipData10').html("提款金额不能有小数 ,请取整！");
            //        $("#dialog10").dialog("open");

            //        $("#price4")[0].select();
            //        $("#price4")[0].focus();
            //        return false;
            //    }
            //}

        else if ($("#username4").val() == "") {

            $('#TipData10').html("请输入提款的游戏账号！");
            $("#dialog10").dialog("open");

            $("#username4")[0].focus();
            return false;
        }
        else if ($("#moneypassword4").val() == "") {

            $('#TipData10').html("请输入提款密码！");
            $("#dialog10").dialog("open");

            $("#moneypassword4")[0].focus();
            return false;
        }


        else if ($("#khname4").val() == "") {

            $('#TipData10').html("请输入提款的银行户名:！");
            $("#dialog10").dialog("open");

            $("#khname4")[0].focus();
            return false;
        }
        else if ($("#yhzh4").val() == "") {

            $('#TipData10').html("请输入提款的银行账号！");
            $("#dialog10").dialog("open");

            $("#yhzh4")[0].focus();
            return false;
        }



        else if ($('#yzm4').val() == '') {
            $('#TipData10').html("请输入验证码");
            $("#dialog10").dialog("open");


            $("#yzm4")[0].focus();
            return false;
        }

        else if (!isBool) {
            return false;
        }
        else {



            $.AjaxCommon({
                url: "/ServiceFile/BankService.asmx/InsertBillNotice1", datas: "userName:'" + $("#username4").val().replaceDanYinHao() + "',TCpassword:'" + $("#moneypassword4").val().replaceDanYinHao() + "',money:'" + $("#price4").val().replace(/\,/g, "") + "',bank:'" + $("#bankcode4").val().replaceDanYinHao() + "',bankaccount:'" + $("#khname4").val().replaceDanYinHao() + "',bankno:'',type:'2',cardNo:'" + $("#yhzh4").val().replaceDanYinHao() + "',bankTime:'',tel:'',payType:'',yzm:'" + $("#yzm4").val().replaceDanYinHao() + "'",
                beforeSend: function () {
                    ShowTipDiv(0);
                },
                complete: function () {
                    HideTipDiv();
                },
                toSuccess: function (json) {

                    if (json.d == "118") {
                        $('#TipData10').html("您是普通会员，每天只有三次提款机会！");
                        $("#dialog10").dialog("open");

                    }
                    else if (json.d == "119") {
                        $('#TipData10').html("您是黄金VIP，每天只有五次提款机会！");
                        $("#dialog10").dialog("open");

                    }
                    else if (json.d == "113") {
                        $('#TipData10').html("请确保您的游戏帐号或取款安全密码正确！");
                        $("#dialog10").dialog("open");


                    } else if (json.d == "-1") {

                        $('#TipData10').html("您的提款提交失败");
                        $("#dialog10").dialog("open");

                    }
                    else if (json.d == "1111") {
                        $('#TipData10').html("请输入银行户名");
                        $("#dialog10").dialog("open");


                    }
                    else if (json.d == "1112") {
                        $('#TipData10').html("银行户名与注册时姓名不一致，请输入正确的银行户名");
                        $("#dialog10").dialog("open");


                    }
                    else {

                        $('#TipData11').html("您的提款已提交成功,我们会马上处理，请稍等！<br/>如果您选择的开户银行是其它银行，请及时联系客服工作人员，谢谢！").css("color", "green").css("font-weight", "800");
                        $("#dialog11").dialog("open");

                    }
                }
            });
        }
    });
    //-----------------提款业务逻辑结束---------------------------


});

//var customURL = "http://f88.live800.com/live800/chatClient/chatbox.jsp?companyID=504420&configID=127905&jid=3308311799&operatorId=56512"; /*客服链接*/

//function openwin() {
//    window.open(customURL, '申博客服', 'height=570, width=750, toolbar=no, menubar=no, scrollbars=no, resizable=no, location=no, status=no');
//}