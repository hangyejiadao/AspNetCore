/**
 * Website: http://git.oschina.net/hbbcs/bootStrap-addTabs
 *
 * Version : 1.0
 *
 * Created by joe on 2016-2-4.
 */

$.fn.addtabs = function (options) {

    obj = $(this);
    var screen_width = parseInt($(window).width());
    var iframe_heigth = $(window).height() - 116;//48+28
    if (screen_width < 999) {
        iframe_heigth = $(window).height() - 76;
    }

    Addtabs.options = $.extend({
        content: '', //直接指定所有页面TABS内容
        close: true, //是否可以关闭
        toggled: false,//是否收缩左边Sidebar
        monitor: 'body', //监视的区域
        iframeUse: true, //使用iframe还是ajax
        iframeHeight: iframe_heigth, //固定TAB中IFRAME高度,根据需要自己修改
        method: 'init',
        callback: function () { //关闭后回调函数
        }
    }, options || {});


    $(Addtabs.options.monitor).on('click', '[data-addtab]', function () {

        Addtabs.add({
            id: $(this).attr('data-addtab'),
            title: $(this).attr('title') ? $(this).attr('title') : $(this).html(),
            content: Addtabs.options.content ? Addtabs.options.content : $(this).attr('content'),
            url: $(this).attr('url'),
            toggled: $(this).attr('toggled') ? $(this).attr('toggled') : false,
            ajax: $(this).attr('ajax') ? true : false,
            close: true
        });

    });

    obj.on('click', '.close-tab', function () {
        var id = $(this).prev("a").attr("aria-controls");
        Addtabs.close(id);
    });

    //obj.on('mouseover', 'li', function () {
    //    $(this).find('.close-tab').show();
    //});

    //obj.on('mouseleave', 'li', function () {
    //    $(this).find('.close-tab').hide();
    //});

    $(window).resize(function () {
        iframe_heigth = $(window).height() - 116;//48+28
        if (screen_width < 999) {
            iframe_heigth = $(window).height() - 76;
        }
        Addtabs.options.iframeHeight = iframe_heigth;
        obj.find('iframe').each(function (e) {
            //$(this).attr('height', Addtabs.options.iframeHeight);            
            $(this).height(Addtabs.options.iframeHeight);
        });
    });

    $(document).ready(function () {
        Addtabs.drop();
    });

};

window.Addtabs = {
    options: {},
    add: function (opts) {

        var id = 'tab_' + opts.id;
        //obj.find('.active').removeClass('active');
        $('li[role = "presentation"].active').removeClass('active');
        $('div[role = "tabpanel"].active').removeClass('active');
        //如果TAB不存在，创建一个新的TAB
        if (!$("#" + id)[0]) {
            //创建新TAB的title
            var title = $('<li>', {
                'role': 'presentation',
                'id': 'tab_' + id
            }).append(
                $('<a>', {
                    'id': 'tab_href_' + id,
                    'href': '#' + id,
                    'toggled': opts.toggled,
                    'aria-controls': id,
                    'role': 'tab',
                    'data-toggle': 'tab'
                }).html(opts.title)
            );

            //是否允许关闭
            if (Addtabs.options.close && opts.close) {
                title.append(
                    $('<i>', { 'class': 'close-tab glyphicon glyphicon-remove' })
                );
            }

            $("<li class='list-tab'><a id='drop_tab_" + opts.id + "' tid='" + opts.id + "'  href='#' url='" + opts.url + "'>" + opts.title + "</a></li>")
              .appendTo($("#dropdown-menu"));

            $("#drop_tab_" + opts.id + "").click(function () {
                var id = $(this).attr("tid");
                $('#tabs').find('.active').removeClass('active');
                $("#tab_tab_" + id).addClass('active');
                $("#tab_" + id).addClass("active");
            });


            //创建新TAB的内容
            var content = $('<div>', {
                'class': 'tab-pane',
                'id': id,
                'role': 'tabpanel'
            });

            if (opts.url.indexOf('?') > -1) {
                opts.url = opts.url + "&theme=" + $('.theme-colors > ul > li.current').attr("data-style");
            }
            else {
                opts.url = opts.url + "?theme=" + $('.theme-colors > ul > li.current').attr("data-style");
            }

            //是否指定TAB内容
            if (opts.content) {
                content.append(opts.content);
            } else if (Addtabs.options.iframeUse && !opts.ajax) {//没有内容，使用IFRAME打开链接
                content.append(
                    $('<iframe>', {
                        'class': 'iframeClass',
                        'height': Addtabs.options.iframeHeight,
                        'frameborder': "no",
                        'border': "0",
                        'src': opts.url
                    })
                );
            } else {
                $.get(opts.url, function (data) {
                    content.append(data);
                });
            }
            //加入TABS
            obj.children('.nav-tabs').append(title);
            obj.children(".tab-content").append(content);
        }

        if (opts.toggled) {
            Layout.setSidebarToggler(true);
        }

        $('#tab_href_' + id).on('shown.bs.tab', function (e) {
            // 获取已激活的标签页的名称          
            var activeTab = $(e.target).attr("aria-controls");
            if (activeTab == "tab_home") {
                Layout.setSidebarToggler(false);
            }
            if (opts.toggled) {
                Layout.setSidebarToggler(true);
            }
        });

        //激活TAB
        $("#tab_" + id).addClass('active');
        $("#" + id).addClass("active");

    },
    close: function (id) {

        //如果关闭的是当前激活的TAB，激活他的前一个TAB
        if (obj.find("li.active").attr('id') == "tab_" + id) {
            $("#tab_" + id).prev().addClass('active');
            $("#" + id).prev().addClass('active');
            var activeTab = obj.find("li.active a");
            if (activeTab.attr('aria-controls') == "tab_home") {
                Layout.setSidebarToggler(false);
            }
            if (activeTab.attr('toggled') && activeTab.attr('toggled') == 'true') {
                Layout.setSidebarToggler(true);
            }
        }

        //关闭TAB
        $("#tab_" + id).remove();
        $("#" + id).remove();
        $("#drop_" + id).parent().remove();

        Addtabs.options.callback();

    },
    drop: function () {

        element = obj.find('.nav-tabs');
        //创建下拉标签
        var dropdown = $('<li>', {
            'class': 'dropdown pull-right tabdrop'
        }).append(
            $('<a>', {
                'class': 'dropdown-toggle',
                'data-toggle': 'dropdown',
                'href': '#'
            }).append(
                $('<i>', { 'class': "glyphicon glyphicon-align-justify" })
            ).append(
                $('<b>', { 'class': 'caret' })
            )
        ).append(
            $('<ul>', { 'class': "dropdown-menu", 'id': "dropdown-menu" })
        )
        //检测是否已增加
        dropdown.prependTo(element);

    },
    CloseAll: function () {
        obj.find("ul >li").not(".tabdrop").each(function () {
            var tab_id = ($(this).attr("id") + "").replace("tab_", "");
            if (tab_id != "undeine" && tab_id != "tab_home") {
                Addtabs.close(tab_id);
            }
        });
    }
}