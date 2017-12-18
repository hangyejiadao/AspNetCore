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

var index = 0;
var selData = { TargetId: '', TargetName: '', ModuleId: '', ModuleName: '', ExtraData: {} };
var trees = {};

var ngApp = angular.module('ngApp', []);
ngApp.controller('mainCtrl', function ($scope, $http, $timeout) {
    initNgData($scope, $http);
    initNgEvent($scope, $http, $timeout);
});

//初始化ng数据
function initNgData($scope, $http) {
    //$scope.index = 0;
    //$scope.selData = { TargetId: '', TargetName: '', ModuleId: '', ModuleName: '', ExtraData: {} };
    $scope.modulePid = modulePid;
    $scope.isShowTree = true;    

    //项目实验室菜单  
    $scope.trees = [];
    $scope.menus = [];
    QBO.plu.ng.http({ http: $http, isLoad: false, chkLogin: false, url: '/MsSys/Main/GetLabModule', params: { ModulePid: $scope.modulePid } }, function (result) {

        //console.log( JSON.stringify(result))
        if (result.Result === 100) {
            $scope.code = result.Data.ModuleCode;
            $scope.trees = result.Data.Trees;
            $scope.menus = result.Data.Modules;          
            $scope.initTrees();
            $scope.initMenus();
        }
    });
}

//初始化ng事件
function initNgEvent($scope, $http, $timeout) {
   
    //设置显示在线时间
    //$('#systemDate').jclock({ withDate: true, withWeek: true });

    //顶部左侧显示隐藏项目按钮 
    $scope.showTreeList = function () {
        $scope.isShowTree = !$scope.isShowTree;
        $('#mainBody').layout($scope.isShowTree ? 'expand' : 'collapse', 'west');
    };

    //初始化左侧项目菜单
    $scope.initTrees = function () {              
        trees = angular.copy($scope.trees);      
        for (var i = 0; i < trees.length; i++) {
           
            var treeList = '';
            var children = trees[i].children;
            //console.log(children);
            for (var j = 0; j < children.length; j++) {                                   
                //初始化的时候，设置第一项选中的样式和项目Id
                var activeClass = '';
                if (i==0 && j == 0)
                {
                    activeClass = 'active';
                    var item = children[0];
                    selData.TargetId = item.id;
                    selData.TargetName = item.name;
                    selData.ExtraData = item.extraData;
                    
                }
                
                treeList += '<a href="javascript:;" class="west-menu ' + activeClass
                         + '" onclick="selectTreeItem(this,' + i + ','+j+')"><span>' + children[j].name + '</span></a>';


                //treeList += '<a href="javascript:;" class="west-menu ' + activeClass + '" data-id="' + children[j].id + '"><span>' + children[j].name + '</span></a>';


            }
            $('#accModule').accordion('add', {               
                title: trees[i].name,
                content: treeList,
                selected: i === 0
            });                    
        }

        //$scope.initTreeFn();
     
    };
  
    //设置左侧项目菜单的点击事件
    $scope.initTreeFn = function () {
        $('.west-menu').on('click', function () {
            var thisObj = $(this),                
                thisId = thisObj.data('id'),
                thisName = thisObj.find('span').text();

            var appElement = document.querySelector('[ng-controller=mainCtrl]');
            var $scope = angular.element(appElement).scope();
            selData.TargetId = thisId;
            selData.TargetName = thisName;
            $scope.$apply();

            $('.west-menu').not(thisName).removeClass('active');
            thisObj.addClass('active');
            
            ModuleQuery();
        });
    };

    //初始化Tab
    $scope.initMenus = function () {
        var menus = angular.copy($scope.menus);
        for (var i = 0; i < menus.length; i++) {
            
            var id = menus[i].id;
            var name = menus[i].name;
            var iconCls = menus[i].iconCls;
            var src = menus[i].src;

            var LoadApi = 0;//打开页面是否调用API获取数据 0否 1是

            if (i==0) {
                index = i;
                LoadApi = 1;
                selData.ModuleId = id;
                selData.ModuleName = name;
            }

            var title = "<span class='tt-inner' data-id='" + id + "'>"
                      + "  <img src='/Content/Css/Themes/Images/Design/Default/IconBig/" + iconCls + ".png' /><br>"
                      + "  <span class='tt-title'>" + name + "</span>"
                      + "</span>"
                       
            var content = '';
            if (src != null) {
                content = '<iframe scrolling="yes" frameborder="0" src="' + src + ((src.indexOf('?') === -1) ? '?' : '&') + 'TargetId=' + selData.TargetId + '&LoadApi=' + LoadApi + '" class="sys-main-iframe"></iframe>';
            }

            $('#main-center').tabs('add', {
                id: id,
                title: title,
                content: content,
                selected: false//index===j
            });

            $('#main-center').tabs({ selected: index });

        }
    };
       
    //主页顶部的“个人中心”、“信息”和“退出”事件
    $scope.topRightFn = function (type) {
        if (type === 'per') {

        }
        else if (type === 'msg') {

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

}

function selectTreeItem(thisObj,i, j)
{    
    var id = trees[i].children[j].id;
    var name = trees[i].children[j].name;
    var extraData = trees[i].children[j].extraData;
    
    var appElement = document.querySelector('[ng-controller=mainCtrl]');
    var $scope = angular.element(appElement).scope();
    selData.TargetId =id;
    selData.TargetName = name;
    selData.ExtraData = extraData;
    $scope.$apply();
    
    $('.west-menu').not(name).removeClass('active');
    $(thisObj).addClass('active');

    ModuleQuery();

}

//选择Tab事件
function selectTabItem(title, i) {    
    var thisObj = $(title),
        thisId = thisObj.data('id'),
        thisName = thisObj.find('span').text();

    if (index != i) {       
        index = i;
        selData.ModuleId = thisId;
        selData.ModuleName = thisName;
        ModuleQuery();
    }
}

//查询数据事件
function ModuleQuery()
{
    var frame = $(window.parent.document).contents().find(".sys-main-iframe")[index];

    if (frame != undefined && frame.contentWindow != undefined) {
        var Module_Method = frame.contentWindow.ModuleQuery;
        if (jQuery.isFunction(Module_Method)) {
            eval(Module_Method(selData));
        }
    }
   
}
