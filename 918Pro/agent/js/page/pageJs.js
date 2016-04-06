/*----------------分页-------------------*/
//number:总页数
//infoCount:总记录数
//pageInfo:每页记录数
//pageWhere:当前页参数名
//pageInfoWhere:每页记录数参数名
function IsPage(number, infoCount, pageInfo, pageWhere, pageInfoWhere) {

    var pageA = "";
    for (var i = 0; i < (parseInt(number) >= 5 ? 5 : parseInt(number)); i++) {
        pageA += "<a ";
        if (i == 0) {
            pageA += "class=\"selected\"";
        }
        pageA += " style=\"cursor:hand\">" + (i + 1) + "</a>";
    }
    jQuery("#pageSpan").html(pageA);
    jQuery("#pageCount").text(number);
    jQuery("#infoCount").text(infoCount);
    
    /*------------------分页按钮的操作---------------------------*/
    jQuery("#pageSpan").find("a").click(function () {
        jQuery(this).attr("class", "selected").siblings().removeAttr("class");
        var id = 1;
        if (parseInt(jQuery("#pageCount").text()) > 5) {
            var selectID = 0;
            id = 1;
            jQuery.each(jQuery("#pageSpan>a"), function (i) {
                if (jQuery("#pageSpan>a:eq(" + i + ")").attr("class").toString() == "selected") {
                    id = parseInt(jQuery("#pageSpan>a:eq(" + i + ")").text());
                    selectID = i;
                }
            });
            if (jQuery("#pageSpan>a:eq(" + selectID + ")").text() == "1" || jQuery("#pageSpan>a:eq(" + selectID + ")").text() == jQuery("#pageCount").text()) {

            }
            else {
                var pd1 = 0;
                if (selectID < 2) {
                    if (parseInt(jQuery("#pageSpan>a:eq(0)").text()) + 2 > id && jQuery("#pageSpan>a:eq(0)").text() != "1") {
                        pd1 = 1;
                    }
                    if (pd1) {
                        if (jQuery("#pageSpan>a:eq(" + selectID + ")").text() != "2") {
                            jQuery.each(jQuery("#pageSpan>a"), function (i) {
                                jQuery("#pageSpan>a:eq(" + i + ")").text("" + (id + (i - 2)));
                            });
                            jQuery("#pageSpan>a:eq(2)").attr("class", "selected").siblings().removeAttr("class");
                        }
                        else {
                            jQuery.each(jQuery("#pageSpan>a"), function (i) {
                                jQuery("#pageSpan>a:eq(" + i + ")").text("" + (id + (i - 1)));
                            });
                            jQuery("#pageSpan>a:eq(1)").attr("class", "selected").siblings().removeAttr("class");
                        }
                    }
                }
                else if (selectID > 2) {
                    if (parseInt(jQuery("#pageSpan>a:eq(0)").text()) - 2 < id && jQuery("#pageSpan>a").last().text() != jQuery("#pageCount").text()) {
                        pd1 = 1;
                    }
                    if (pd1) {
                        if (jQuery("#pageSpan>a:eq(" + selectID + ")").text() != (parseInt(jQuery("#pageCount").text()) - 1).toString()) {
                            jQuery.each(jQuery("#pageSpan>a"), function (i) {
                                jQuery("#pageSpan>a:eq(" + i + ")").text("" + (id + (i - 2)));
                            });
                            jQuery("#pageSpan>a:eq(2)").attr("class", "selected").siblings().removeAttr("class");
                        }
                        else {
                            jQuery.each(jQuery("#pageSpan>a"), function (i) {
                                jQuery("#pageSpan>a:eq(" + i + ")").text("" + (id + (i - 3)));
                            });
                            jQuery("#pageSpan>a:eq(3)").attr("class", "selected").siblings().removeAttr("class");
                        }
                    }
                }
            }
        }
        else {
            jQuery.each(jQuery("#pageSpan>a"), function (i) {
                if (jQuery("#pageSpan>a:eq(" + i + ")").attr("class").toString() == "selected") {
                    id = parseInt(jQuery("#pageSpan>a:eq(" + i + ")").text());
                    selectID = i;
                }
            });
        }
        setDate(pageWhere + ":" + ((id - 1) * parseInt(pageInfo)) + "," + pageInfoWhere + ":" + pageInfo + "");
    });
    //第一页
    jQuery("#pageDiv").find("a:eq(0)").click(function () {
        jQuery("#pageSpan").find("a:eq(0)").attr("class", "selected").siblings().removeAttr("class");
        if (parseInt(jQuery("#pageCount").text()) > 5) {
            jQuery.each(jQuery("#pageSpan>a"), function (i) {
                if (i + 1 < parseInt(jQuery("#pageCount").text())) {
                    jQuery("#pageSpan>a:eq(" + i + ")").text("" + (i + 1));
                }
            });
        }
        setDate(pageWhere + ":0," + pageInfoWhere + ":" + pageInfo + "");
    });
    //最后一页
    jQuery("#pageDiv").find("a").last().click(function () {
        jQuery("#pageSpan").find("a").last().attr("class", "selected").siblings().removeAttr("class");
        if (parseInt(jQuery("#pageCount").text()) > 5) {
            jQuery.each(jQuery("#pageSpan>a"), function (i) {
                jQuery("#pageSpan>a:eq(" + i + ")").text("" + (parseInt(jQuery("#pageCount").text()) - (5 - (i + 1))));
            });
        }
        setDate(pageWhere + ":" + ((number - 1) * parseInt(pageInfo)) + "," + pageInfoWhere + ":" + pageInfo + "");
    });

    //上一页
    jQuery("#pageDiv").find("a:eq(1)").click(function () {
        var id = 0;
        var pd1 = 0;
        jQuery.each(jQuery("#pageSpan>a"), function (i) {
            if (jQuery("#pageSpan>a:eq(" + i + ")").attr("class").toString() == "selected") {
                if (jQuery("#pageSpan>a:eq(" + i + ")").text() != "1") {
                    id = parseInt(jQuery("#pageSpan>a:eq(" + (i - 1) + ")").text());
                    if (!(parseInt(jQuery("#pageSpan>a:eq(0)").text()) + 2 <= id && jQuery("#pageSpan>a:eq(0)").text() != "1" && jQuery("#pageSpan>a:eq(2)").text() != (parseInt(jQuery("#pageSpan>a:eq(0)").text()) + 2).toString())) {
                        pd1 = 1;
                    }
                    if (jQuery("#pageSpan>a:eq(0)").text() == "1") {
                        pd1 = 0;
                    }
                    if (!pd1) {
                        jQuery("#pageSpan>a:eq(" + (i - 1) + ")").attr("class", "selected").siblings().removeAttr("class");
                    }
                    else {
                        if (i <= 2) {
                            jQuery("#pageSpan>a:eq(" + i + ")").attr("class", "selected").siblings().removeAttr("class");
                        }
                        else {
                            jQuery("#pageSpan>a:eq(" + (i - 1) + ")").attr("class", "selected").siblings().removeAttr("class");
                            pd1 = 0;
                        }
                    }
                    return false;
                }
            }
        });
        if (parseInt(jQuery("#pageCount").text()) > 5) {
            if (pd1) {
                jQuery.each(jQuery("#pageSpan>a"), function (i) {
                    if (i + 1 < parseInt(jQuery("#pageCount").text())) {
                        jQuery("#pageSpan>a:eq(" + i + ")").text("" + (id + (i - 2)));
                    }
                });
            }
        }
        setDate(pageWhere + ":" + (id * parseInt(pageInfo)) + "," + pageInfoWhere + ":" + pageInfo + "");
    });
    //下一页
    jQuery("#pageDiv").find("a:eq(" + (jQuery("#pageDiv").find("a").length - 2) + ")").click(function () {
        var id = 0;
        var pd1 = 0;
        jQuery.each(jQuery("#pageSpan>a"), function (i) {
            if (jQuery("#pageSpan>a:eq(" + i + ")").attr("class") != "") {
                if (jQuery("#pageSpan>a:eq(" + i + ")").text() != jQuery("#pageCount").text()) {
                    id = parseInt(jQuery("#pageSpan>a:eq(" + (i + 1) + ")").text());
                    if (!(parseInt(jQuery("#pageSpan>a").last().text()) - 2 >= id && jQuery("#pageSpan>a").last().text() != jQuery("#pageCount").text() && jQuery("#pageSpan>a:eq(2)").text() != (parseInt(jQuery("#pageCount").text()) - 2).toString())) {
                        pd1 = 1;
                    }
                    if (jQuery("#pageSpan>a").last().text() == jQuery("#pageCount").text()) {
                        pd1 = 0;
                    }
                    if (!pd1) {
                        jQuery("#pageSpan>a:eq(" + (i + 1) + ")").attr("class", "selected").siblings().removeAttr("class");
                    }
                    else {
                        jQuery("#pageSpan>a:eq(" + i + ")").attr("class", "selected").siblings().removeAttr("class");
                    }
                    return false;
                }
            }
        });
        if (parseInt(jQuery("#pageCount").text()) > 5) {
            if (pd1) {
                jQuery.each(jQuery("#pageSpan>a"), function (i) {
                    if (i + 1 < parseInt(jQuery("#pageCount").text())) {
                        jQuery("#pageSpan>a:eq(" + i + ")").text("" + (id + (i - 2)));
                    }
                });
            }
        }
        setDate(pageWhere + ":" + (id * parseInt(pageInfo)) + "," + pageInfoWhere + ":" + pageInfo + "");
    });
    /*------------------分页按钮操作结束---------------------------*/
    setDate(pageWhere + ":0," + pageInfoWhere + ":" + pageInfo + "");

    //无数据时隐藏分页按钮
    if (infoCount == "0") {
        jQuery("#pageDiv").hide();
    }
    else {
        jQuery("#pageDiv").show();
    }

}
/*--------------分页结束-----------------*/