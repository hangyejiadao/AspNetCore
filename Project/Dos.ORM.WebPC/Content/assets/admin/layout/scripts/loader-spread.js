var ScrolltoTop = function () {
    var offset = 20;
    var duration = 500;

    if (navigator.userAgent.match(/iPhone|iPad|iPod/i)) {  // ios supported
        $(window).bind("touchend touchcancel touchleave", function (e) {
            if ($(this).scrollTop() > offset) {
                $('.scroll-to-top').fadeIn(duration);
            } else {
                $('.scroll-to-top').fadeOut(duration);
            }
        });
    } else {  // general
        $(window).scroll(function () {
            if ($(this).scrollTop() > offset) {
                $('.scroll-to-top').fadeIn(duration);
            } else {
                $('.scroll-to-top').fadeOut(duration);
            }
        });
    }

    $('.scroll-to-top').click(function (e) {
        e.preventDefault();
        $('html, body').animate({ scrollTop: 0 }, duration);
        return false;
    });
};

var GotoHome = function () {
    $("#gotohome").click(function () {
        var homePage = parent.document.URL;
        parent.document.location = homePage.replace("/#", "/Admin/Index?SP5937765A2=NO").replace("#", "");
    });
}

var SetPostedFile = function (name) {
    $("#txtPostedFile").val(name);
}

var GetThemeSkin = function () {
    var system_theme = "blue";
    if ($('.theme-colors > ul > li.current', window.parent.document))
        system_theme = $('.theme-colors > ul > li.current', window.parent.document).attr("data-style");
    else
        alert("with no theme");
    return system_theme;
}

var GetRandom = function () {
    return Math.floor(Math.random() * 9999 + 1);
}

var NoticeShow = function (title, content) {
    $.alert({
        icon: 'fa fa-info-circle',
        title: title,
        content: content,
        confirmButton: '确定',
        //closeIcon: true, // hides the close icon.
        confirmButtonClass: 'btn btn-primary',
        animation: 'rotate',
        closeAnimation: 'right',
        opacity: 0.5
    });
}

var ConfirmShow = function (title, content, fn_confirm) {
    $.confirm({
        keyboardEnabled: true,
        icon: 'fa fa-info-circle',
        title: title,
        content: content,
        confirmButton: '确定',
        cancelButton: '取消',
        //closeIcon: true, // hides the close icon.
        confirmButtonClass: 'btn btn-primary',
        cancelButtonClass: 'btn default',
        animation: 'rotate',
        closeAnimation: 'right',
        confirm: fn_confirm,
        opacity: 0.5
    });
}

var stringIsComprise = function (strVal, val) {
    if (!isNullOrEmpty(strVal)) {
        var arr = strVal.split(',');
        for (var i = 0; i < arr.length; i++) {
            if (arr[i] == val) {
                return true;
            }
        }
    }
    return false;
}

var isNullOrEmpty = function (strVal) {
    if (strVal == '' || strVal == null || strVal == undefined) {
        return true;
    } else {
        return false;
    }
}

var loadOperations = function () {
    try {
        var SP_773D3D = $('#SP_773D3D').text();
        if (SP_773D3D != 1) {
            $(".vis-control-zn").hide();
            var SP_5413D3D = $("#SP_5413D3D").text();
            if (!isNullOrEmpty(SP_5413D3D)) {
                $(".vis-control-zn").each(function (index, item) {
                    if (stringIsComprise(SP_5413D3D, $(item).attr("att-id"))) {
                        $(item).show();
                    }
                });
            }
        }
    }
    catch (ex) {
        alert("error:" + ex);
    }
}

$(document).ready(function () {
    loadOperations();
});