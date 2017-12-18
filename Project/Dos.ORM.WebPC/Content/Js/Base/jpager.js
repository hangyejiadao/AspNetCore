
/*******************************************************************************************/
// jquery.jpager.js - version 0.4
// A jQuery plugin for ajax pager
// 
// Copyright (c) 2012-2013, Cheung (http://blog.xcai.com/javascript/jquery-plugin-jpager)
// Licensed under the MIT License (MIT-LICENSE.txt)
// http://www.opensource.org/licenses/mit-license.php
// Created: 2013-7-9
//
/*******************************************************************************************/

$.fn.jpager = function (options) {

    // Setup default option values
    var defaults = {
        totalItems: 88, // 总记录数，从后台获取
        limit: 10, // 每页显示的数据条数
        links: 10, // 显示页码的个数
        currentPage: 1,
        showFirstLast: false, // 是否显示最后一页和第一页
        pageGo: function (page, offset, limit) { }
    };

    var options = $.extend(defaults, options);
    options.currentPage = parseInt(options.currentPage);
    // Construct the nav bar
    var firstHtml = !options.showFirstLast ? '' : '<li><a href="javascript:" class="first">首页</a></li>';
    var lastHtml = !options.showFirstLast ? '' : '<li><a href="javascript:" class="last">尾页</a></li>';
    var prevHtml = '<li><a href="javascript:" class="prev">上页</a></li>';
    var nextHtml = '<li><a href="javascript:" class="next">下页</a></li>';

    return this.each(function () {
        // Calculate the number of pages needed
        var totalPages = Math.ceil(options.totalItems / options.limit);
        if (options.currentPage < 1 || options.currentPage > totalPages) {
            options.currentPage = 1;
        }
        var $page_container = $(this);
        renderPages($page_container, totalPages, options.currentPage);
    });

    // 生成显示的html代码
    function renderPages(container, totalPages, pageIndex) {
        var pagesHtml = "";
        var pages = currentPages(totalPages, pageIndex);

        if (pages.length > 1) {
            pagesHtml += firstHtml;
            pagesHtml += prevHtml;
            for (var i = 0; i < pages.length; i++) {
                if (pageIndex == pages[i]) {
                    pagesHtml += '<li class="active"><a href="javascript:" data-page="' + pages[i] + '">' + pages[i] + '</a></li>';
                } else {
                    pagesHtml += '<li><a href="javascript:" data-page="' + pages[i] + '">' + pages[i] + '</a></li>';
                }
            }
            pagesHtml += nextHtml;
            pagesHtml += lastHtml;
            //新增代码
            //if (totalPages > pages.length) {
            //    pagesHtml += '<li><input id="txt_gopage" class="input" value="' + options.currentPage + '" /><a href="javascript:" class="c">GO</a></li>';
            //}
        }
        pagesHtml += "";
        container.empty();
        container.html(pagesHtml);

        var first = container.find('.first');
        var last = container.find('.last');
        var prev = container.find('.prev');
        var next = container.find('.next');

        first.attr("data-page", 1);
        last.attr("data-page", totalPages);
        prev.attr("data-page", pageIndex - 1);
        next.attr("data-page", pageIndex + 1);

        if (pageIndex == 1) {
            first.parent().addClass("disabled");
            prev.parent().addClass("disabled");
        }
        if (pageIndex == totalPages) {
            last.parent().addClass("disabled");
            next.parent().addClass("disabled");
        }
        
        container.find(".c").click(function () {
            var goIdx = document.getElementById("txt_gopage").value;
            if (goIdx<1) {
                alert("请输入大于0的页码！");
                return;
            }
            if (goIdx > totalPages) {
                alert("页码大于总页数了！");
                return;
            }
            if (goIdx == options.currentPage) {
                return
            }
            if (options.pageGo) {
                options.pageGo(goIdx, (goIdx - 1) * options.limit, options.limit);
            }
            options.currentPage = goIdx;
            renderPages(container, totalPages, goIdx);
        });
        container.find("a").each(function () {
            var pageLink = $(this);
            var goIdx = parseInt(pageLink.attr("data-page"));
            //如果是新增的
            if (goIdx) {
                pageLink.click(function () {
                    if (goIdx == options.currentPage) {
                        return
                    }
                    if (options.pageGo) {
                        options.pageGo(goIdx, (goIdx - 1) * options.limit, options.limit);
                    }
                    options.currentPage = goIdx;
                    renderPages(container, totalPages, goIdx);
                    return false;
                });
            }
        });
    }

    // 计算当前显示的页面，页码默认从1开始
    function currentPages(totalPages, pageIndex) {
        var links = options.links;
        var pages = new Array(totalPages < links ? totalPages : links); //[];

        if (totalPages > links) {
            var idx = Math.ceil(links / 2);
            if (pageIndex <= idx) {
                for (var i = 0; i < links; i++) {
                    pages[i] = i + 1;
                }
            } else if (totalPages - pageIndex >= idx) {
                for (var i = 0; i < links; i++) {
                    pages[i] = pageIndex + idx - links + i;
                }
            } else {
                for (var i = 0; i < links; i++) {
                    pages[i] = totalPages - links + i + 1;
                }
            }
        } else {
            for (var i = 0; i < totalPages; i++) {
                pages[i] = i + 1;
            }
        }
        return pages;
    }
};
