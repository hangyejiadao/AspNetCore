/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2015-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 创建人：Quber
 * 创建说明：页面预加载效果
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

//获取浏览器页面可见高度和宽度
var _PageHeight = document.documentElement.clientHeight,
    _PageWidth = document.documentElement.clientWidth;
//计算loading框距离顶部和左部的距离（loading框的宽度为215px，高度为61px）
var _LoadingTop = _PageHeight > 61 ? (_PageHeight - 61) / 2 : 0,
    _LoadingLeft = _PageWidth > 276 ? (_PageWidth - 276) / 2 : 0;
//在页面未加载完毕之前显示的loading Html自定义内容
var _LoadingHtml = '<div id="qb-loading-panel" style="position:absolute;left:0;width:100%;height:' +
    _PageHeight + 'px;top:0;background:#fff;opacity:1;filter:alpha(opacity=100);z-index:999999999;"><div style="position: absolute; cursor1: wait; left: ' +
    _LoadingLeft + 'px; top:' +
    _LoadingTop + 'px; width: auto; height: 57px; line-height: 57px; padding-left: 18px; padding-right: 5px; border: 2px solid #E2E5E7;box-shadow: 1px 1px 20px rgba(0, 0, 0, .2);padding-right: 18px; color: #696969; font-family:\'Microsoft YaHei\';"><i class="fa fa-spinner fa-spin fa-3x fa-fw" style="font-size:18px;"></i>页面加载中，请等待...</div></div>';
//呈现loading效果
document.write(_LoadingHtml);

//window.onload = function () {
//    var loadingMask = document.getElementById('loadingDiv');
//    loadingMask.parentNode.removeChild(loadingMask);
//};

//监听加载状态改变
document.onreadystatechange = completeLoading;

//加载状态为complete时移除loading效果
function completeLoading() {
    if (document.readyState === "complete") {
        var loadingMask = document.getElementById('qb-loading-panel');
        loadingMask.parentNode.removeChild(loadingMask);
    }
}