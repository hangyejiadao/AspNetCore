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

//这里是测试的静态数据，正式项目中需要调用接口服务获取


var ngApp = angular.module('ngApp', []);
ngApp.controller('mainCtrl', function ($scope, $http, $timeout) {
    initNgData($scope, $http);
    initNgEvent($scope, $http, $timeout);
});
//初始化ng数据
function initNgData($scope, $http) {    
    $scope.isShowMenu = true;
    $scope.selmenu = {};

    //菜单数据   
    $scope.menus = [];
    QBO.plu.ng.http({ http: $http, isLoad: false, chkLogin: false, url: '/MsSys/Main/GetModule' }, function (result) {
        //console.log(JSON.stringify(result.Data.Menus))
        if (result.Result === 100)
        {            
            $scope.menus = result.Data.Menus;
            $scope.selmenu = $scope.menus[0];
          
        }
    });

}

//初始化ng事件
function initNgEvent($scope, $http, $timeout) {
    
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

    //顶部左侧显示隐藏项目按钮   
    $scope.showMenuList = function () {
        $scope.isShowMenu = !$scope.isShowMenu;
        $('#mainBody').layout($scope.isShowMenu ? 'expand' : 'collapse', 'west');
    };

       
    //左侧项目点击事件
    $scope.selectMainMenu = function (item, event) {
        $scope.selmenu = item;
        $('.west-pro>.pro-info').removeClass('pro-info-active');       
        $(event.target).addClass('pro-info-active');
    };


    //右侧项目点击事件
    $scope.selectSubMenu = function (item, event) {
       
    };

    
}