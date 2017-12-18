/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2015-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 创建人：Quber
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

var thisDefaultMainPage = '/MsSys/Main/Content',
    zTreePanel = 'zTreePanel',
    //菜单显示类型（1：树形，2：手风琴）
    moduleType = 2;

var ngApp = angular.module('ngApp', []);
ngApp.controller('mainCtrl', function ($scope, $timeout) {
    //初始化样式主题
    QBO.frm.getSetTheme('init');

    $scope.moduleType = moduleType;

    QBO.plu.ajax({
        url: '/MsSys/Main/GetModule'
    }, function (data) {
        $scope.moduleListzTree = data.ztreeModule;
        $scope.moduleListEasy = data.easyModule;

        $scope.initModuleTree('sys');
    });

    $scope.initModuleTree = function (type) {
        if ($scope.moduleType == 1) {
            QBO.plu.zt.init(zTreePanel, type === 'sys' ? $scope.moduleListzTree.sys : $scope.moduleListzTree.bus, { onClick: zTreeClick });
        } else {
            $scope.initModuleStr(type, $scope.moduleListEasy);
        }
    };

    $scope.initModuleStr = function (type, data) {
        var accPanelLength = $('#accModule').accordion('panels').length;
        for (var k = 0; k < accPanelLength ; k++) {
            $('#accModule').accordion('remove', 0);
        }

        var moduleData = type === 'sys' ? data.sys : data.bus;

        for (var i = 0; i < moduleData.length; i++) {
            var moduleList = '';

            for (var j = 0; j < moduleData[i].Sons.length; j++) {
                moduleList += '<a href="javascript:;" class="west-menu" data-src="' + moduleData[i].Sons[j].src
                    + '" data-id="' + moduleData[i].Sons[j].id
                    + '" data-icon="' + moduleData[i].Sons[j].iconName
                    + '"><i class="' + moduleData[i].Sons[j].iconName
                    + '"></i><span>' + moduleData[i].Sons[j].name
                    + '</span></a>';
            }

            $('#accModule').accordion('add', {
                iconCls: 'fa fa-cog',
                title: moduleData[i].name,
                content: moduleList,
                selected: i === 0
            });
        }
        $scope.initModuleFn();
    }

    $scope.initModuleFn = function () {
        $('.west-menu').on('click', function () {
            var thisObj = $(this),
                thisName = thisObj.find('span').text(),
                thisId = thisObj.data('id'),
                thisSrc = thisObj.data('src'),
                thisIcon = thisObj.data('icon');

            var thisUrlFh = thisSrc.indexOf('?') > -1 ? '&' : '?';
            //optPageType：（1：操作页面主页面，2：操作页面子页面）
            addEasyTab(thisName, thisSrc + thisUrlFh + 'moduleId=' + thisId + '&optPageType=1', thisIcon == null || thisIcon.length <= 0 ? 'icon-navibar' : thisIcon);

            $('.west-menu').not(thisName).removeClass('active');
            thisObj.addClass('active');
        });
    }

    //管理员信息
    QBO.frm.getUser(function (data) {
        $timeout(function () {
            $scope.userInfo = data;
        });
    });

    $scope.topRightFn = function (type) {
        if (type === 'home') {
            $('#main-center').tabs('select', 0);
        } else if (type === 'menuSys') {
            $scope.initModuleTree('sys');
        } else if (type === 'menuBus') {
            $scope.initModuleTree('bus');
        } else if (type === 'per') {

        } else if (type === 'exit') {
            QBO.dia.confirm('确定要退出本系统？', function () {
                location.href = '/MsSys/Login/LoginOut';
            });
        }
    };

    $scope.isFullScreen = false;
    $scope.tabBtnFn = function (type) {
        if (type === 'full') {
            //全屏显示
            $scope.isFullScreen = true;
            var de = document.documentElement;
            if (de.requestFullscreen) {
                de.requestFullscreen();
            } else if (de.mozRequestFullScreen) {
                de.mozRequestFullScreen();
            } else if (de.webkitRequestFullScreen) {
                de.webkitRequestFullScreen();
            }
        } else if (type === 'unfull') {
            //退出全屏
            $scope.isFullScreen = false;
            var de = document;
            if (de.exitFullscreen) {
                de.exitFullscreen();
            } else if (de.mozCancelFullScreen) {
                de.mozCancelFullScreen();
            } else if (de.webkitCancelFullScreen) {
                de.webkitCancelFullScreen();
            }
        }
        else if (type === 'refresh') {
            refreshCurTab();
        }
    };

    $scope.leftMenuFn = function (isOpen) {
        var treeObj = $.fn.zTree.getZTreeObj(zTreePanel);
        treeObj.expandAll(isOpen);
    };

    $('#systemDate').jclock({ withDate: true, withWeek: true });

    //显示个人下拉菜单
    $('#lbtnPerson').tooltip({
        content: $('<div></div>'),
        onUpdate: function (content) {
            content.panel({
                width: 100,
                border: false,
                href: '/MsSys/Main/Person'
            });
        },
        onShow: function () {
            var t = $(this);
            t.tooltip('tip').unbind().bind('mouseenter', function () { t.tooltip('show'); }).bind('mouseleave', function () { t.tooltip('hide'); });

            $('#lbtnPwd').unbind('click').on('click', function () {
                QBO.frm.openWin('/MsSys/Operator/UpdatePwd', { title: '修改密码', icon: 'key', width: 500, height: 270 });
            });
            $('#lbtnLock').unbind('click').on('click', function () {
                openCloseLockDialog(true);
                unlockScreen('set');
            });
            $('#lbtnExit').unbind('click').on('click', function () {
                QBO.dia.confirm('确定要退出本系统？', function () {
                    location.href = '/MsSys/Login/LoginOut';
                });
            });
        }
    }).hover(function () {
        $(this).find('.north-photo').addClass('fa-spin');
    }, function () {
        $(this).find('.north-photo').removeClass('fa-spin');
    });

    //显示主题下拉菜单
    $('#lbtnThemes').tooltip({
        content: $('<div></div>'),
        onUpdate: function (content) {
            content.panel({
                width: 100,
                border: false,
                href: '/MsSys/Main/Themes'
            });
        },
        onShow: function () {
            var t = $(this);
            t.tooltip('tip').unbind().bind('mouseenter', function () { t.tooltip('show'); }).bind('mouseleave', function () { t.tooltip('hide'); });

            //设置主题下拉图标样式
            $('.person-themes i').removeClass('fa-check-circle').addClass('fa-circle');
            QBO.plu.ajax({
                url: '/MsSys/Common/GetUserTheme'
            }, function (data) {
                $('a[data-themes="' + data.Data + '"] i').removeClass('fa-circle').addClass('fa-check-circle');
            });

            $('.person-themes').unbind('click').on('click', function () {
                var thisTheme = $(this),
                    thisThemeIcon = thisTheme.find('i'),
                    thisThemeName = thisTheme.data('themes');
                $('.person-themes i').removeClass('fa-check-circle').addClass('fa-circle');
                thisThemeIcon.removeClass('fa-circle').addClass('fa-check-circle');

                //初始化样式主题
                QBO.frm.getSetTheme('set', thisThemeName);

                //设置所有已经打开的tab面板页面的主题样式
                var allTabe = $('#main-center').tabs('tabs');
                for (var i = 0; i < allTabe.length; i++) {
                    var iframe = allTabe[i].find('iframe');
                    if (iframe[0].contentWindow.$) {
                        iframe[0].contentWindow.$('#linkThemes').attr('href', '/Content/Css/Themes/base.' + thisThemeName + '.css');
                    }
                }
            });
        }
    });
});

$(function () {
    //初始化是否锁屏
    unlockScreen('get');

    closeEasyTab();
    closeEasyTabEvent();
});

function zTreeClick(e, treeId, treeNode) {
    //点击文字行展开或者关闭
    $.fn.zTree.getZTreeObj(zTreePanel).expandNode(treeNode);

    getUrlToTab(treeNode);
}
function getUrlToTab(treeNode) {
    //将zTree的URL地址添加到EasyTab上
    if (treeNode.src != undefined && treeNode.src != null && treeNode.src.length > 0) {
        var thisUrlFh = treeNode.src.indexOf('?') > -1 ? '&' : '?';
        //optPageType：（1：操作页面主页面，2：操作页面子页面）
        addEasyTab(treeNode.name, treeNode.src + thisUrlFh + 'moduleId=' + treeNode.id + '&optPageType=1', treeNode.iconName == null || treeNode.iconName.length <= 0 ? 'icon-navibar' : treeNode.iconName);
    }
}
//添加EasyTab
function addEasyTab(title, href, icon) {
    var tabObj = $('#main-center');
    if (tabObj.tabs('exists', title)) {
        tabObj.tabs('select', title);
    } else {
        tabObj.tabs('add', {
            title: title,
            closable: true,
            icon: icon,
            //tools: [{
            //    iconCls: 'icon-mini-refresh',
            //    handler: function () {
            //        //更新Tabs中的currTab对象的content属性值
            //        tabObj.tabs('update', {
            //            tab: tabObj.tabs('getSelected'),
            //            options: {
            //                content: addEasyTabIFrame(href)
            //            }
            //        });
            //    }
            //}],
            content: addEasyTabIFrame(href)
        });
    }
    closeEasyTab();
}

//返回Tab的iframe容器
function addEasyTabIFrame(url) {
    return '<iframe scrolling="yes" frameborder="0" src="' + (url ? url : thisDefaultMainPage) + '" class="sys-main-iframe"></iframe>';
}

//刷新当前tab页
function refreshCurTab() {
    //获取当前选中的Tab对象
    var currTab = $('#main-center').tabs('getSelected');
    //获取当前选中的Tab对象的src属性值
    var currentUrl = $(currTab.panel('options').content).attr('src');
    currentUrl = currentUrl == undefined || currentUrl.length <= 0 ? thisDefaultMainPage : currentUrl;
    //更新Tabs中的currTab对象的content属性值
    $('#main-center').tabs('update', {
        tab: currTab,
        options: {
            content: addEasyTabIFrame(currentUrl)
        }
    });
}

//是否可以关闭EasyTab
function isCloseEasyTab(tabWhich) {
    return tabWhich.length > 0 && tabWhich !== "系统主页" || tabWhich > 0 ? true : false;
}

//关闭EasyTab
function closeEasyTab() {
    //双击关闭Tab选项卡
    $(".tabs-inner").dblclick(function () {
        var subTitle = $(this).children(".tabs-closable").text();
        if (isCloseEasyTab(subTitle)) {
            $('#main-center').tabs('close', subTitle);
        }
    });
    //为选项卡绑定右键
    $(".tabs-inner").bind('contextmenu', function (e) {
        $('#easyui-tabs-menu').menu('show', {
            left: e.pageX,
            top: e.pageY
        });
        var subTitle = $(this).children(".tabs-closable").text();
        $('#easyui-tabs-menu').data("currtab", subTitle);
        $('#main-center').tabs('select', subTitle);
        return false;
    });
}

//绑定右键关闭EasyTab事件
function closeEasyTabEvent() {
    //刷新当前
    $('#mm-tabrefresh').on('click', function () {
        refreshCurTab();
    });
    //关闭当前
    $('#mm-tabclose').on('click', function () {
        var tab = $('#main-center').tabs('getSelected');
        var index = $('#main-center').tabs('getTabIndex', tab);
        if (isCloseEasyTab(index)) {
            $('#main-center').tabs('close', index);
        }
    });
    //全部关闭
    $('#mm-tabcloseall').on('click', function () {
        $('.tabs-inner span').each(function (i, n) {
            var smallTitle = $(n).text();
            if (isCloseEasyTab(smallTitle)) {
                $('#main-center').tabs('close', smallTitle);
            }
        });
    });
    //关闭除当前之外的Tab
    $('#mm-tabcloseother').on('click', function () {
        var currTabTitle = $('#easyui-tabs-menu').data("currtab");
        $('.tabs-inner span').each(function (i, n) {
            var smallTitle = $(n).text();
            if (smallTitle !== currTabTitle && isCloseEasyTab(smallTitle)) {
                $('#main-center').tabs('close', smallTitle);
            }
        });
    });
    //关闭当前右侧的Tab
    $('#mm-tabcloseright').on('click', function () {
        var nextAll = $('.tabs-selected').nextAll();
        if (nextAll.length === 0) {
            //alert("右侧已经没有了！");
            return false;
        }
        nextAll.each(function (i, n) {
            var smallTitle = $('a:eq(0) span', $(n)).text();
            if (isCloseEasyTab(smallTitle)) {
                $('#main-center').tabs('close', smallTitle);
            }
        });
        return true;
    });
    //关闭当前左侧的Tab
    $('#mm-tabcloseleft').on('click', function () {
        var prevAll = $('.tabs-selected').prevAll();
        if (prevAll.length === 0) {
            //alert("左侧已经没有了！");
            return false;
        }
        prevAll.each(function (i, n) {
            var smallTitle = $('a:eq(0) span', $(n)).text();
            if (isCloseEasyTab(smallTitle)) {
                $('#main-center').tabs('close', smallTitle);
            }
        });
        return true;
    });
    //退出
    $("#mm-exit").on('click', function () {
        $('#easyui-tabs-menu').menu('hide');
    });
}

//关闭当前选中的tab，并设置tab选中项为第一项
function closeCurrentTab() {
    var tabObj = $('#main-center'),
         //获取当前选中tab对象
         tabSelected = tabObj.tabs('getSelected'),
         //获取当前选中tab的索引
         tabIndex = tabObj.tabs('getTabIndex', tabSelected);
    //关闭当前选中的tab，并将tab选中项设置为第一个
    tabObj.tabs('close', tabIndex).tabs('select', 0);
}

//解锁屏幕
function unlockScreen(lockType) {
    //get：初始化获取，set：设置锁屏，unlock：解锁
    lockType = lockType === undefined ? 'unlock' : lockType;

    //解锁密码
    var unlockPwd = lockType === 'unlock' ? $('#txtLock').passwordbox('getValue') : '';

    if (lockType === 'unlock' && unlockPwd.length <= 0) {
        QBO.dia.tip('请输入解锁密码！', 'error');
        return;
    }

    QBO.plu.ajax({
        url: '/MsSys/Main/GetSetLock',
        data: { lockType: lockType, unlockPwd: unlockPwd }
    }, function (data) {
        if (lockType === 'get') {
            openCloseLockDialog(data.Data);
        } else if (lockType === 'set') {
        } else if (lockType === 'unlock') {
            if (data.Result === 100) {
                QBO.dia.msg(data.Msg, {
                    icon: 'right',
                    endCallback: function () { openCloseLockDialog(false); }
                });
            } else {
                QBO.dia.tip(data.Msg, 'error');
            }
        }
    });
}
//关闭或打开锁屏对话框
function openCloseLockDialog(isOpen) {
    $('#diaLock').dialog({
        title: '系统已锁定',
        iconCls: 'fa fa-lock', width: 300, height: 124,
        closed: !isOpen, closable: false, modal: true
    });
}