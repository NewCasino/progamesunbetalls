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

    




})(jQuery);
