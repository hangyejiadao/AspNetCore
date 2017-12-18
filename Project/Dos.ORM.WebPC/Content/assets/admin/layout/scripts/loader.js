/**
Demo script to handle the theme demo
**/
var Loader = function () {

    // Handle Theme Settings
    var handleTheme = function () {

        var panel = $('.theme-panel');

        if ($('body').hasClass('page-boxed') === false) {
            $('.layout-option', panel).val("fluid");
        }

        $('.sidebar-option', panel).val("default");
        $('.page-header-option', panel).val("fixed");
        $('.page-footer-option', panel).val("fixed");
        if ($('.sidebar-pos-option').attr("disabled") === false) {
            $('.sidebar-pos-option', panel).val(Metronic.isRTL() ? 'right' : 'left');
        }

        //handle theme layout
        var resetLayout = function () {
            $("body").
            removeClass("page-boxed").
            removeClass("page-footer-fixed").
            removeClass("page-sidebar-fixed").
            removeClass("page-header-fixed").
            removeClass("page-sidebar-reversed");

            $('.page-header > .page-header-inner').removeClass("container");

            if ($('.page-container').parent(".container").size() === 1) {
                $('.page-container').insertAfter('body > .clearfix');
            }

            $(".top-menu > .navbar-nav > li.dropdown").removeClass("dropdown-dark");

            $('body > .container').remove();
        };

        var lastSelectedLayout = '';

        var setLayout = function () {

            var layoutOption = $('.layout-option', panel).val();
            var sidebarOption = $('.sidebar-option', panel).val();
            var headerOption = $('.page-header-option', panel).val();
            var footerOption = $('.page-footer-option', panel).val();
            var sidebarPosOption = $('.sidebar-pos-option', panel).val();
            var sidebarStyleOption = $('.sidebar-style-option', panel).val();
            var sidebarMenuOption = $('.sidebar-menu-option', panel).val();
            var headerTopDropdownStyle = $('.page-header-top-dropdown-style-option', panel).val();

            if (sidebarOption == "fixed" && headerOption == "default") {
                alert('Default Header with Fixed Sidebar option is not supported. Proceed with Fixed Header with Fixed Sidebar.');
                $('.page-header-option', panel).val("fixed");
                $('.sidebar-option', panel).val("fixed");
                sidebarOption = 'fixed';
                headerOption = 'fixed';
            }

            resetLayout(); // reset layout to default state

            if (layoutOption === "boxed") {
                $("body").addClass("page-boxed");

                // set header
                $('.page-header > .page-header-inner').addClass("container");
                var cont = $('body > .clearfix').after('<div class="container"></div>');

                // set content
                $('.page-container').appendTo('body > .container');

                // set footer
                if (footerOption === 'fixed') {
                    $('.page-footer').html('<div class="container">' + $('.page-footer').html() + '</div>');
                } else {
                    $('.page-footer').appendTo('body > .container');
                }
            }

            if (lastSelectedLayout != layoutOption) {
                //layout changed, run responsive handler: 
                Metronic.runResizeHandlers();
            }
            lastSelectedLayout = layoutOption;

            //header
            if (headerOption === 'fixed') {
                $("body").addClass("page-header-fixed");
                $(".page-header").removeClass("navbar-static-top").addClass("navbar-fixed-top");
            } else {
                $("body").removeClass("page-header-fixed");
                $(".page-header").removeClass("navbar-fixed-top").addClass("navbar-static-top");
            }

            //sidebar
            if ($('body').hasClass('page-full-width') === false) {
                if (sidebarOption === 'fixed') {
                    $("body").addClass("page-sidebar-fixed");
                    $("page-sidebar-menu").addClass("page-sidebar-menu-fixed");
                    $("page-sidebar-menu").removeClass("page-sidebar-menu-default");
                    Layout.initFixedSidebarHoverEffect();
                } else {
                    $("body").removeClass("page-sidebar-fixed");
                    $("page-sidebar-menu").addClass("page-sidebar-menu-default");
                    $("page-sidebar-menu").removeClass("page-sidebar-menu-fixed");
                    $('.page-sidebar-menu').unbind('mouseenter').unbind('mouseleave');
                }
            }

            // top dropdown style
            if (headerTopDropdownStyle === 'dark') {
                $(".top-menu > .navbar-nav > li.dropdown").addClass("dropdown-dark");
            } else {
                $(".top-menu > .navbar-nav > li.dropdown").removeClass("dropdown-dark");
            }

            //footer 
            if (footerOption === 'fixed') {
                $("body").addClass("page-footer-fixed");
            } else {
                $("body").removeClass("page-footer-fixed");
            }

            //sidebar style
            if (sidebarStyleOption === 'light') {
                $(".page-sidebar-menu").addClass("page-sidebar-menu-light");
            } else {
                $(".page-sidebar-menu").removeClass("page-sidebar-menu-light");
            }

            //sidebar menu 
            if (sidebarMenuOption === 'hover') {
                if (sidebarOption == 'fixed') {
                    $('.sidebar-menu-option', panel).val("accordion");
                    alert("Hover Sidebar Menu is not compatible with Fixed Sidebar Mode. Select Default Sidebar Mode Instead.");
                } else {
                    $(".page-sidebar-menu").addClass("page-sidebar-menu-hover-submenu");
                }
            } else {
                $(".page-sidebar-menu").removeClass("page-sidebar-menu-hover-submenu");
            }

            //sidebar position
            if (Metronic.isRTL()) {
                if (sidebarPosOption === 'left') {
                    $("body").addClass("page-sidebar-reversed");
                    $('#frontend-link').tooltip('destroy').tooltip({
                        placement: 'right'
                    });
                } else {
                    $("body").removeClass("page-sidebar-reversed");
                    $('#frontend-link').tooltip('destroy').tooltip({
                        placement: 'left'
                    });
                }
            } else {
                if (sidebarPosOption === 'right') {
                    $("body").addClass("page-sidebar-reversed");
                    $('#frontend-link').tooltip('destroy').tooltip({
                        placement: 'left'
                    });
                } else {
                    $("body").removeClass("page-sidebar-reversed");
                    $('#frontend-link').tooltip('destroy').tooltip({
                        placement: 'right'
                    });
                }
            }

            Layout.fixContentHeight(); // fix content height            
            Layout.initFixedSidebar(); // reinitialize fixed sidebar
        };

        // handle theme colors
        var setColor = function (color) {
            var color_ = (Metronic.isRTL() ? color + '-rtl' : color);
            $('#style_color').attr("href", Layout.getLayoutCssPath() + 'themes/' + color_ + "/ui.css");
            if (color == 'light2') {
                $('.page-logo img').attr('src', Layout.getLayoutImgPath() + 'logo-invert.png');
            } else {
                $('.page-logo img').attr('src', Layout.getLayoutImgPath() + 'logo.png');
            }
            if ($.cookie) {
                $.cookie('style_color', color);
            }
        };

        $('.toggler-close', panel).click(function () {
            $('.theme-panel').hide();
        });

        $('.theme-colors > ul > li', panel).click(function () {
            var color = $(this).attr("data-style");
            setColor(color);
            $('ul > li', panel).removeClass("current");
            $(this).addClass("current");
            Addtabs.CloseAll();
        });

        $("#header_theme_bar").click(function () {
            $('.theme-panel').show();
        });

        // set default theme options:

        if ($("body").hasClass("page-boxed")) {
            $('.layout-option', panel).val("boxed");
        }

        if ($("body").hasClass("page-sidebar-fixed")) {
            $('.sidebar-option', panel).val("fixed");
        }

        if ($("body").hasClass("page-header-fixed")) {
            $('.page-header-option', panel).val("fixed");
        }

        if ($("body").hasClass("page-footer-fixed")) {
            $('.page-footer-option', panel).val("fixed");
        }

        if ($("body").hasClass("page-sidebar-reversed")) {
            $('.sidebar-pos-option', panel).val("right");
        }

        if ($(".page-sidebar-menu").hasClass("page-sidebar-menu-light")) {
            $('.sidebar-style-option', panel).val("light");
        }

        if ($(".page-sidebar-menu").hasClass("page-sidebar-menu-hover-submenu")) {
            $('.sidebar-menu-option', panel).val("hover");
        }

        var sidebarOption = $('.sidebar-option', panel).val();
        var headerOption = $('.page-header-option', panel).val();
        var footerOption = $('.page-footer-option', panel).val();
        var sidebarPosOption = $('.sidebar-pos-option', panel).val();
        var sidebarStyleOption = $('.sidebar-style-option', panel).val();
        var sidebarMenuOption = $('.sidebar-menu-option', panel).val();

        $('.layout-option, .page-header-option, .page-header-top-dropdown-style-option, .sidebar-option, .page-footer-option, .sidebar-pos-option, .sidebar-style-option, .sidebar-menu-option', panel).change(setLayout);

        setLayout();
    };

    // handle theme style
    var setThemeStyle = function (style) {

        var file = (style === 'rounded' ? 'components-rounded' : 'components');
        file = (Metronic.isRTL() ? file + '-rtl' : file);

        $('.theme-panel .layout-style-option').val(style);
        $('#style_components').attr("href", Metronic.getGlobalCssPath() + file + ".css");

        if ($.cookie) {
            $.cookie('layout-style-option', style);
        }

    };

    var setThemeColor = function (color) {

        $('ul > li', $('.theme-colors')).removeClass("current");
        $('.theme-colors > ul > li').each(function () {
            var _color = $(this).attr("data-style");
            if (_color == color)
                $(this).addClass("current");
        });

        $('#style_color').attr("href", '/Content/assets/admin/layout/css/themes/' + color + "/ui.css");
    };

    var loadSystemMenus = function () {
        $("#sys-sidebar-menu").empty();
        $.ajax({
            type: "post",
            url: "/Admin/menu_ajax_data",
            data: { type: 1, parent: "" },
            dataType: "json",
            success: function (zjson) {
                if (zjson.success) {
                    var zdata = zjson.data;
                    $("<li class='sidebar-toggler-wrapper'><div class='sidebar-toggler'></div></li>" +
                        "<li class='start active open'><a href='javascript:;'><i class='icon-home'></i>" +
                        "<span class='title'>首页</span><span class='selected'></span><span class='arrow open'></span>" +
                        "</a></li>").appendTo($("#sys-sidebar-menu"));

                    $.each(zdata, function (n, value) {
                        if (value.Pid == 0) {
                            if (value.Define == "subsidiary") {
                                $("<li class='heading'><h3 class='uppercase'>维护</h3></li>")
                          .appendTo($("#sys-sidebar-menu"));
                            }
                            else {
                                var li = "<li>";
                                if (value.Open == "dropdown-menu") {
                                    li = li + "<a href='javascript:;'><i class='" + value.Icon + "'></i><span class='title'>" + value.Name + "</span><span class='arrow '></span></a>";
                                    li = li + "<ul class='sub-menu'>";
                                    $.each(zdata, function (z, item) {
                                        if (item.Pid == value.ID) {
                                            //处理链接类型
                                            if (item.Open == "dropdown-menu") {
                                                li = li + "<li>";
                                                li = li + "<a href='javascript:;'><i class='" + value.Icon + "'></i><span class='title'>" + value.Name + "</span><span class='arrow '></span></a>";

                                                li = li + "<ul class='sub-menu'>";

                                                $.each(zdata, function (k, zitem) {
                                                    if (zitem.Pid == item.ID) {
                                                        li = li + "<li>";
                                                        if (zitem.Open == "openTab-menu") {
                                                            li = li + "<a href='javascript:;' data-addtab='" + zitem.TiName + "' url='" + zitem.UrlStr + "'>";
                                                        }

                                                        else {
                                                            li = li + "<a href='javascript:;'>";
                                                        }
                                                        //处理链接图标
                                                        if (zitem.Icon != "") {
                                                            li = li + "<i class='" + zitem.Icon + "'></i><span>" + zitem.Name + "</span>";
                                                        }
                                                        else {
                                                            li = li + "" + zitem.Name + "";
                                                        }
                                                        li = li + "</a></li>";
                                                    }
                                                });

                                                li = li + "</ul>";

                                                li = li + "</li>";
                                            }
                                            else {
                                                li = li + "<li>";
                                                if (item.Open == "openTab-menu") {
                                                    li = li + "<a href='javascript:;' data-addtab='" + item.TiName + "' url='" + item.UrlStr + "'>";
                                                }

                                                else {
                                                    li = li + "<a href='javascript:;'>";
                                                }
                                                //处理链接图标
                                                if (item.Icon != "") {
                                                    li = li + "<i class='" + item.Icon + "'></i><span>" + item.Name + "</span>";
                                                }
                                                else {
                                                    li = li + "" + item.Name + "";
                                                }
                                                li = li + "</a></li>";
                                            }

                                        }
                                    });
                                    li = li + "</ul>";
                                }
                                else {
                                    li = li + "<a href='javascript:;' data-addtab='" + value.TiName + "' url='" + value.UrlStr + "'><i class='" + value.Icon + "'></i><span class='title'>" + value.Name + "</span><span class='arrow '></span></a>";
                                }
                                li = li + "</li>";
                                $(li).appendTo($("#sys-sidebar-menu"));

                            }
                        }
                    });

                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
    }

    var confirmQuit = function () {
        $("#btnConfirmQuit").click(function () {
            $.confirm({
                keyboardEnabled: true,
                icon: 'fa fa-info-circle',
                title: '系统提示',
                content: '确认要退出系统吗?',
                confirmButton: '确定',
                cancelButton: '取消',
                //closeIcon: true, // hides the close icon.
                confirmButtonClass: 'btn btn-primary',
                cancelButtonClass: 'btn default',
                animation: 'rotate',
                closeAnimation: 'right',
                confirm: function () {
                    window.location = $("#btnConfirmQuit").attr("att-href");
                },
                opacity: 0.5
            });
        });
    }

    var renderCalendar = function () {

        $('#sys_calendar').fullCalendar({
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay'
            },
            //defaultDate: '2014-09-12',
            lang: 'zh-cn',
            buttonIcons: false, // show the prev/next text
            weekNumbers: true,
            editable: true,
            eventLimit: true, // allow "more" link when too many events
            events: []
        });

    }

    return {

        //main function to initiate the theme
        init: function () {
            // handles style customer tool
            handleTheme();

            // handle layout style change
            $('.theme-panel .layout-style-option').change(function () {
                setThemeStyle($(this).val());
            });

            // set layout style from cookie
            var _theme_style = $('.theme-panel .layout-style-option').val();
            if ($.cookie && typeof ($.cookie('layout-style-option')) != "undefined") {
                _theme_style = $.cookie('layout-style-option');
            }

            setThemeStyle(_theme_style);

            // set layout color from cookie
            var _style_color = $('.theme-colors > ul > li.current').attr("data-style");
            if ($.cookie && typeof ($.cookie('style_color')) != "undefined") {
                _style_color = $.cookie('style_color');
            }

            setThemeColor(_style_color);

            // load system menus
            //loadSystemMenus();

            // confirm quit button
            confirmQuit();

        }
    };

}();