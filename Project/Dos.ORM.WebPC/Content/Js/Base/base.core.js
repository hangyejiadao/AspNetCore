/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2015-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 创建人：Quber
 * 创建说明：公用js方法核心库
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
//扩展时间类型，格式化时间
Date.prototype.format = function (format) {
    if (!format) {
        format = "yyyy-MM-dd hh:mm:ss";
    }
    var o = {
        "M+": this.getMonth() + 1, //month
        "d+": this.getDate(),    //day
        "h+": this.getHours(),   //hour
        "m+": this.getMinutes(), //minute
        "s+": this.getSeconds(), //cond
        "q+": Math.floor((this.getMonth() + 3) / 3),  //quarter
        "S": this.getMilliseconds() //millisecond
    }
    if (/(y+)/.test(format)) format = format.replace(RegExp.$1,
    (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o) if (new RegExp("(" + k + ")").test(format))
        format = format.replace(RegExp.$1,
      RegExp.$1.length == 1 ? o[k] :
        ("00" + o[k]).substr(("" + o[k]).length));
    return format;
}

var QBC = {
    easyUi: {
        grid: {
            cmenu: null,//onHeaderContextMenu标题右键点击事件显示的右键菜单DOM对象
            animate: false,//treegrid展开时是否显示动画效果
            destroyMsg: {//edatagrid中销毁数据行时
                norecord: {
                    title: '提示',
                    msg: '请选择需要删除的数据！'
                },
                confirm: {
                    title: '确认信息',
                    msg: '确定要删除所选数据？'
                }
            },
            autoSave: false,//设置为true时，在点击表格外部的时候自动保存编辑的行
            showFooter: false,//定义是否显示行脚
            border: false,
            fit: true,
            fitColumns: true,//是否自适应表格宽度
            striped: true,//是否显示斑马线效果
            method: 'POST',
            loadMsg: '数据加载中，请稍后……',
            rownumbers: true, //是否显示行号
            singleSelect: true,//是否单选
            ctrlSelect: false,
            pagination: true,//是否显式分页
            pageSize: 30,//每页数量
            pageNumber: 1,//默认显示第几页
            isShowChkTg: false,//treegrid是否显示复选框
            pageList: [10, 15, 20, 30, 40, 50, 100, 500, 1000]//分页中下拉选项的数值
        }
    },
    zTree: {
        data: {
            key: {
                name: 'name'
            },
            simpleData: {
                enable: true,
                idKey: 'id',
                pIdKey: 'pId'
            }
        },
        check: {
            enable: false, //是否启用复选框或单选框
            chkStyle: 'checkbox', //checkbox或radio
            radioType: 'all', //all：针对所有的进行单选，level：针对同一级别的进行单选
            chkboxType: { "Y": "p", "N": "s" }
            /*
                Y：勾选后的动作
                N：取消勾选后的动作
                Y和N的值：p影响父级、s影响子级、ps影响父级和子级
            */
        },
        view: {
            fontCss: {},
            nameIsHTML: true,
            expandSpeed: "fast", //"slow", "normal", "fast", "",1000
            dblClickExpand: false,
            showTitle: false,
            showIcon: true,
            selectedMulti: true //是否允许同时选中多个节点
        },
        callback: {
            onClick: null, //点击事件
            onCheck: null //用于捕获checkbox/radio被勾选或取消勾选的事件回调函数
        }
    },
    uploadify: {
        width: 76, height: 26,
        fileObjName: 'fileDataObj',//文件对象名称，用于服务器端获取文件
        queueID: 'uploadfileQueue',//显示上传文件队列的元素id，可以简单用一个div显示
        swf: '/Content/Components/Uploadify/uploadify.swf',//[必须设置]swf的路径
        uploader: '/MsSys/Common/UploadImgMethod',//[必须设置]服务器端脚本文件路径
        //buttonImage: '/Content/Components/Uploadify/browse-btn.png',//上传按钮背景图片
        uploadLimit: 200,//最多上传文件数量
        queueSizeLimit: 200,//上传文件队列长度限制
        fileSizeLimit: '100MB',//上传文件大小限制，默认单位是KB，如：”10KB”
        auto: false,//表示在选择文件后是否自动上传
        multi: false,//是否支持多文件上传
        buttonClass: '',//上传按钮样式类型
        buttonText: '选择文件',//上传按钮显示文字
        fileTypeDesc: '',//文件类型说明，在选择文件时可以看到
        fileTypeExts: '*.gif; *.jpg; *.png',//指定允许上传的文件类型，如：”*.jpg;*.gif”
        formData: {},//指定上传文件附带的其他数据，用于服务器端获取这些数据，如：{“id”:”001”,”name”:”LiJin”}包含两个键值对
        method: 'POST',//和后台交互方式，也可以设置为get
        progressData: 'percentage',//设置文件上传时显示的数据，可以设为上传速度或者百分比，分别对应speed和percentage
        removeCompleted: true,//表示上传文件完成后是否删除队列中的对应元素
        removeTimeout: 2,//表示上传完成后多久删除队列中的进度条，单位为秒
        requeueErrors: false,//若设置为true，那么在上传过程中因为出错导致上传失败的文件将重新加入队列
        successTimeout: 20//表示文件上传完成后等待服务器响应的时间。超过该时间，那么将认为上传成功。单位为秒
    }
};

var QBO = {
    com: {//公用方法或事件
        getObj: function (obj, type, returnVal) {
            /*******************************************
            说明：检查是否为某对象，并返回
                    obj：检查对象
                    type：返回的类型（可为空，默认为json）
                    returnVal：返回值（如果obj为空对象，并且returnVal不为空对象，则返回）
            ********************************************/
            type = type == undefined || type.length <= 0 ? 'json' : type;
            switch (type) {
                case 'json':
                    obj = typeof (obj) == 'object' && Object.prototype.toString.call(obj).toLowerCase() === '[object object]' && !obj.length ? obj : {};
                    break;
                case 'str':
                case 'string':
                    obj = obj == undefined || typeof (obj) != 'string' ? returnVal == undefined ? '' : returnVal : obj;
                    break;
                case 'num':
                case 'int':
                    obj = obj == undefined || typeof (obj) != 'number' ? returnVal == undefined ? '' : returnVal : obj;
                    break;
                case 'bool':
                case 'boolean':
                    obj = obj == undefined || typeof (obj) != 'boolean' ? returnVal == undefined ? false : returnVal : obj;
                    break;
                case 'fn':
                case 'fun':
                    obj = obj == undefined || typeof (obj) != 'function' ? returnVal == undefined ? function () { } : returnVal : obj;
                    break;
                case 'arr':
                case 'array':
                    obj = typeof (obj) == 'object' && Object.prototype.toString.call(obj) === '[object Array]' ? obj : [];
                    break;
            }
            return obj;
        },
        getUrlVal: function (keyName) {
            /*******************************************
            说明：获取Url参数
                    keyName：Url参数名称
            ********************************************/
            var reg = new RegExp('(^|&)' + keyName + '=([^&]*)(&|$)', 'i');
            var r = window.location.search.substr(1).match(reg);
            return r != null ? unescape(r[2]) : '';
        },
        setCenter: function (selecter, width, height) {
            /*******************************************
            说明：将元素保持在页面中央
                    selecter：元素选择器（如：.my-class  #my-id）
                    width：元素宽度
                    height：元素高度
            ********************************************/
            //浏览器可见高度
            var seeClientW = document.documentElement.clientWidth;
            var seeClientH = document.documentElement.clientHeight;

            var leftPx = seeClientW <= width ? 0 : (seeClientW - width) / 2;
            var topPx = seeClientH <= height ? 0 : (seeClientH - height) / 2;
            $(selecter).css({ 'marginTop': topPx + 'px', 'left': leftPx + 'px' });

            $(window).resize(function () {
                seeClientW = document.documentElement.clientWidth;
                seeClientH = document.documentElement.clientHeight;

                leftPx = seeClientW <= width ? 0 : (seeClientW - width) / 2;
                topPx = seeClientH <= height ? 0 : (seeClientH - height) / 2;

                $(selecter).css({ 'marginTop': topPx + 'px', 'left': leftPx + 'px' });
            });
        },
        filterDate: function (value, long) {
            if (value == null || value == '') {
                return '-';
            }

            var dt;
            if (value instanceof Date) {
                dt = value;
            }
            else if (isNaN(dt)) {
                dt = new Date(value.toString());
            }
            else {
                dt = new Date(value);
            }

            if (dt <= new Date("1900-01-01")) {
                return '-';
            } else if (dt > new Date("2100-01-01")) {
                return '-';
            } else {
                return long ? dt.format("yyyy-MM-dd hh:mm:ss") : dt.format("yyyy-MM-dd");
            }

        },
        find: function (obj, key) {
            if (! typeof obj === 'object') return false;

            if (key in obj) return true;

            for (var k in obj)
                if (QBO.com.find(obj[k], key))
                    return true;

            return false;

        },
        getJsParam: function (jsName, paramName) {
            /*******************************************
            说明：获取js文件后的参数
                    jsName：js文件名称
                    paramName：要获取的参数名称（如果该参数没有传，则返回整个js参数的数组Json对象）
            ********************************************/

            var retJsonArr = [],
                retVal = '';

            var rName = new RegExp(jsName + "(\\?(.*))?$");
            var jss = document.getElementsByTagName('script');
            for (var i = 0; i < jss.length; i++) {
                var j = jss[i];
                if (j.src && j.src.match(rName)) {
                    var oo = j.src.match(rName)[2];
                    if (oo && (t = oo.match(/([^&=]+)=([^=&]+)/g))) {
                        for (var l = 0; l < t.length; l++) {
                            r = t[l];
                            var tt = r.match(/([^&=]+)=([^=&]+)/);
                            if (tt) {
                                retJsonArr.push({ key: tt[1], val: tt[2] });

                                if (paramName != undefined && paramName.length > 0 && paramName == tt[1]) {
                                    retVal = tt[2];
                                }
                            }
                        }
                    }
                }
            }

            return paramName != undefined && paramName.length > 0 ? retVal : retJsonArr;
        },

    },
    plu: {
        ajax: function (obj, sucCallback) {
            /*******************************************
            说明：添加、修改和删除等ajax请求
                    obj：{
                                chkLogin：检查是否登录（默认为true）
                                type：'POST',//请求方式GET或POST（可不填，默认为POST）
                                async： true,//是否为异步请求（可不填，默认为true）
                                isLoad：是否显示等待效果（加载层，可不填，默认为false）
                                loadType：加载层类型（可不填，默认为layer[1]，2为easyui加载层效果）
                                doType：'modify',//操作类型（可不填，默认提示文字为‘操作’，delete/del：删除、add/modify：保存、其他：操作）
                                url：'',//请求地址（必填）
                                data：{ PageIndex: 1, PageSize: 20 }//请求参数（可不填，根据请求方法而定）
                            }
                    sucCallback：请求成功后的回调函数
            ********************************************/
            obj.chkLogin = QBO.com.getObj(obj.chkLogin, 'bool', true);
            obj.type = QBO.com.getObj(obj.type, 'str', 'POST');
            obj.async = QBO.com.getObj(obj.async, 'bool', true);
            obj.isLoad = QBO.com.getObj(obj.isLoad, 'bool', false);
            obj.loadType = QBO.com.getObj(obj.loadType, 'num', 1);
            obj.data = QBO.com.getObj(obj.data);
            obj.doType = obj.doType === 'del' || obj.doType === 'delete' ? '删除' :
                obj.doType === 'add' || obj.doType === 'insert' || obj.doType === 'modify' || obj.doType === 'update' ? '保存' : '操作';

            if (obj.chkLogin) {
                QBO.frm.getUser(function () {
                    QBO.plu.ajaxPri(obj, sucCallback);
                });
            } else {
                QBO.plu.ajaxPri(obj, sucCallback);
            }
        },
        ajaxPri: function (obj, sucCallback) {
            /*******************************************
            说明：添加、修改和删除等ajax请求
                    obj：{
                                type：'POST',//请求方式GET或POST（可不填，默认为POST）
                                async： true,//是否为异步请求（可不填，默认为true）
                                isLoad：是否显示等待效果（加载层，可不填，默认为false）
                                loadType：加载层类型（可不填，默认为layer[1]，2为easyui加载层效果）
                                doType：'modify',//操作类型（可不填，默认提示文字为‘操作’，delete/del：删除、add/modify：保存、其他：操作）
                                url：'',//请求地址（必填）
                                data：{ PageIndex: 1, PageSize: 20 }//请求参数（可不填，根据请求方法而定）
                            }
                    sucCallback：请求成功后的回调函数
            ********************************************/
            obj.type = QBO.com.getObj(obj.type, 'str', 'POST');
            obj.async = QBO.com.getObj(obj.async, 'bool', true);
            obj.isLoad = QBO.com.getObj(obj.isLoad, 'bool', false);
            obj.loadType = QBO.com.getObj(obj.loadType, 'num', 1);
            obj.data = QBO.com.getObj(obj.data);
            obj.doType = obj.doType === 'del' || obj.doType === 'delete' ? '删除' :
                obj.doType === 'add' || obj.doType === 'insert' || obj.doType === 'modify' || obj.doType === 'update' ? '保存' : '操作';

            if (obj.url == undefined) {
                QBO.dia.tip('数据操作异常：请求地址为空，请检查！', 'error');
                console.log('数据操作异常：请求地址为空，请检查！' + JSON.stringify(params));
                return;
            }
            var loadIndex = 0;
            $.ajax({
                type: obj.type, async: obj.async, url: obj.url, data: obj.data,
                dataType: "json",
                traditional: true,//使用传统方法序列化数据
                //contentType: 'application/json',
                beforeSend: function () {
                    if (obj.isLoad) {
                        if (obj.loadType === 1) {
                            loadIndex = QBO.dia.load();
                        } else {
                            parent.$.messager.progress({ text: '数据' + obj.doType + '中，请稍后...' });
                        }
                    }
                },
                complete: function () {
                    if (obj.isLoad) {
                        if (obj.loadType === 1) {
                            QBO.dia.loadClose();
                        } else {
                            parent.$.messager.progress('close');
                        }
                    }
                },
                success: function (infoData) {
                    if (typeof (sucCallback) == 'function') {
                        sucCallback(infoData);
                    }
                },
                error: function (msg) {
                    //QBO.dia.tip('数据' + obj.doType + '失败，请稍后再试！', 'error');
                    //var errorObj = { status: msg.status, obj: obj };
                    //console.log('数据' + obj.doType + '失败，请稍后再试！' + JSON.stringify(errorObj));
                    return;
                }
            });
        },
        grid: {//EasyUI datagrid edatagrid treegrid
            init: function (dgObj, dgOpts, type) {
                /*******************************************
                说明：初始化datagrid
                        dgObj：表格对象（如：$('#dg')）
                        dgOpts：{keyId:'',idField:'',treeField:'',url:'',col:[],colFro:[],toolbar:'#toolBarMain'}
                            queryParams:{}查询参数
                            idField：树形数据主键字段（type=tg时传递）
                            treeField：树形数据显示名称（type=tg时传递）
                            singleSelect：是否单选
                            pagination：是否显示分页栏
                            keyId：数据主键Id
                            url：请求的服务地址
                            col：显示的数组列
                            colFro：显示的冻结数组列
                            toolbar：表格工具栏容器Id（可不填，默认为toolBarMain）
                            method：请求方式（默认为POST）

                            menuId：右键行menu区域的Id（默认为menu）
                            onRowContextMenu：右键行菜单事件

                            onLoadSuccess(data)：在数据加载成功后的回调函数
                            onClickRow：在用户点击一行的时候触发

                            //edatagrid
                            saveUrl：一个 URL，向服务器保存数据，并返回添加的行
                            updateUrl：一个 URL，向服务器更新数据，并返回更新的行
                            destroyUrl：一个 URL，向服务器传送 'id' 参数来销毁该行
                            onAdd：当添加一个新行时触发
                            onEdit：当编辑一行时触发
                            onBeforeSave：一行被保存之前触发，返回 false 则取消保存动作
                            onSave：当保存一行时触发
                            onDestroy：当销毁一行时触发
                            onError：当发生服务器错误时触发。
                                           服务器应返回一个 'isError' 属性设置为 true 的行，表示发生错误

                        type：dg：datagrid、edg：edatagrid、tg：treegrid（默认为dg）
                ********************************************/
                var thisQueryParams = QBO.com.getObj(dgOpts.queryParams);
                //此参数用于传递给MsSysController控制器的OnAuthorization方法，便于返回不同的数据对象
                thisQueryParams.requestObj = 'EasyUI-DG';
                //是否触发了点击列排序
                thisQueryParams.isSortCol = false;

                type = type == undefined || type.length <= 0 ? 'dg' : type;
                if (type === 'dg') {
                    dgObj.datagrid({
                        nowrap: dgOpts.nowrap == undefined || typeof (dgOpts.nowrap) != 'boolean' ? QBC.easyUi.grid.nowrap : dgOpts.nowrap,
                        border: QBC.easyUi.grid.border,
                        fit: QBC.easyUi.grid.fit,
                        //注意此处，如果设置了冻结的列，那么fitColumns就该设置为false，否则设置冻结列将失效
                        fitColumns: dgOpts.colFro && dgOpts.colFro != undefined && dgOpts.colFro.length > 0 ? false : QBC.easyUi.grid.fitColumns,
                        striped: QBC.easyUi.grid.striped,
                        method: dgOpts.method == undefined || typeof (dgOpts.method) != 'string' ? QBC.easyUi.grid.method : dgOpts.method,
                        loadMsg: QBC.easyUi.grid.loadMsg,
                        rownumbers: QBC.easyUi.grid.rownumbers,
                        singleSelect: dgOpts.singleSelect == undefined || typeof (dgOpts.singleSelect) != 'boolean' ? QBC.easyUi.grid.singleSelect : dgOpts.singleSelect,
                        ctrlSelect: QBC.easyUi.grid.ctrlSelect,
                        pagination: dgOpts.pagination == undefined || typeof (dgOpts.pagination) != 'boolean' ? QBC.easyUi.grid.pagination : dgOpts.pagination,
                        pageSize: dgOpts.pageSize == undefined || typeof (dgOpts.pageSize) != 'number' ? QBC.easyUi.grid.pageSize : dgOpts.pageSize,
                        pageNumber: QBC.easyUi.grid.pageNumber,
                        pageList: QBC.easyUi.grid.pageList,
                        queryParams: thisQueryParams,

                        toolbar: dgOpts.toolbar == null ? null : dgOpts.toolbar == undefined || dgOpts.toolbar.length <= 0 ? '#toolBarMain' : '#' + dgOpts.toolbar,
                        url: dgOpts.url,
                        frozenColumns: [dgOpts.colFro],//冻结在左侧的列
                        columns: [dgOpts.col],
                        //事件                       
                        onRowContextMenu: function (e, index, row) {
                            e.preventDefault();
                            //右键选中点击行
                            $(this).datagrid('selectRow', index);
                            //显示右键菜单
                            $('#' + (dgOpts.menuId != undefined && dgOpts.menuId.length > 0 ? dgOpts.menuId : 'menu')).menu('show', { left: e.pageX, top: e.pageY });

                            if (typeof (dgOpts.onRowContextMenu) == 'function') {
                                dgOpts.onRowContextMenu(e, index, row);
                            }
                        },
                        onHeaderContextMenu: function (e, field) {
                            //鼠标右键点击标题列显示隐藏“普通列”事件
                            e.preventDefault();
                            if (!QBC.easyUi.grid.cmenu) {
                                QBO.plu.grid.createColumnMenu(dgObj);
                            }
                            QBC.easyUi.grid.cmenu.menu('show', {
                                left: e.pageX,
                                top: e.pageY
                            });
                        },
                        onLoadSuccess: function (data) {
                            //此处的-340来自MsSysController控制器的OnAuthorization方法
                            if (data.total === -340) {
                                QBO.dia.msg('登录已过期，请重新登录！', {
                                    icon: 'error', shift: 6,
                                    endCallback: function () {
                                        parent.location.href = '/MsSys/Login';
                                    }
                                });
                            } else {
                                //在数据加载成功的时候触发
                                if (typeof (dgOpts.onLoadSuccess) == 'function') {
                                    dgOpts.onLoadSuccess(data);
                                }
                            }
                        },
                        onBeforeLoad: function (param) {
                            if (typeof (dgOpts.onBeforeLoad) == 'function') {
                                dgOpts.onBeforeLoad(param);
                            }
                        },
                        onClickRow: function (index, row) {
                            //在用户点击一行的时候触发
                            if (typeof (dgOpts.onClickRow) == 'function') {
                                dgOpts.onClickRow(index, row);
                            }
                        },
                        onBeforeSortColumn: function (sort, order) {
                            /*不能使用以下方式来修改是否触发了点击列排序的状态，否则会调用2次后台查询
                                var thisOpts = dgObj.datagrid('options');
                                var thisOptQueryParams = thisOpts.queryParams;
                                thisOptQueryParams.isSortCol = true;
                                dgObj.datagrid({ queryParams: thisOptQueryParams });
                            */

                            dgObj.datagrid('options').queryParams.isSortCol = true;
                        }
                    });
                    dgObj.datagrid('getPager').pagination({
                        beforePageText: '第',
                        afterPageText: '页&nbsp;共{pages}页',
                        displayMsg: '当前显示{from}-{to}条记录，共{total}条记录'
                    }).find('a.l-btn').tooltip({
                        content: function () {
                            var cc = $(this).find('span.l-btn-icon').attr('class').split(' ');
                            var name = cc[1].split('-')[1];
                            name = name === 'first' ? '首页' :
                                name === 'prev' ? '上一页' :
                                name === 'next' ? '下一页' :
                                name === 'last' ? '末页' : '刷新';
                            return name;
                        }
                    });
                }
                else if (type === 'edg') {
                    dgObj.edatagrid({
                        border: QBC.easyUi.grid.border,
                        destroyMsg: QBC.easyUi.grid.destroyMsg,
                        fit: QBC.easyUi.grid.fit,
                        //注意此处，如果设置了冻结的列，那么fitColumns就该设置为false，否则设置冻结列将失效
                        fitColumns: dgOpts.colFro && dgOpts.colFro != undefined && dgOpts.colFro.length > 0 ? false : QBC.easyUi.grid.fitColumns,
                        striped: QBC.easyUi.grid.striped,
                        method: dgOpts.method == undefined || typeof (dgOpts.method) != 'string' ? QBC.easyUi.grid.method : dgOpts.method,
                        loadMsg: QBC.easyUi.grid.loadMsg,
                        rownumbers: QBC.easyUi.grid.rownumbers,
                        singleSelect: dgOpts.singleSelect == undefined || typeof (dgOpts.singleSelect) != 'boolean' ? QBC.easyUi.grid.singleSelect : dgOpts.singleSelect,
                        ctrlSelect: QBC.easyUi.grid.ctrlSelect,
                        pagination: dgOpts.pagination == undefined || typeof (dgOpts.pagination) != 'boolean' ? QBC.easyUi.grid.pagination : dgOpts.pagination,
                        pageSize: dgOpts.pageSize == undefined || typeof (dgOpts.pageSize) != 'number' ? QBC.easyUi.grid.pageSize : dgOpts.pageSize,
                        pageNumber: QBC.easyUi.grid.pageNumber,
                        pageList: QBC.easyUi.grid.pageList,
                        queryParams: thisQueryParams,
                        showFooter: dgOpts.showFooter == undefined || typeof (dgOpts.showFooter) != 'boolean' ? QBC.easyUi.grid.showFooter : dgOpts.showFooter,
                        autoSave: dgOpts.autoSave == undefined || typeof (dgOpts.autoSave) != 'boolean' ? QBC.easyUi.grid.autoSave : dgOpts.autoSave,

                        toolbar: dgOpts.toolbar == undefined || dgOpts.toolbar.length <= 0 ? '#toolBarMain' : '#' + dgOpts.toolbar,
                        url: dgOpts.url,
                        frozenColumns: [dgOpts.colFro],//冻结在左侧的列
                        columns: [dgOpts.col],

                        saveUrl: dgOpts.saveUrl,
                        updateUrl: dgOpts.updateUrl,
                        destroyUrl: dgOpts.destroyUrl,

                        //事件
                        onRowContextMenu: function (e, index, row) {
                            e.preventDefault();
                            //右键选中点击行
                            $(this).datagrid('selectRow', index);
                            //显示右键菜单
                            $('#' + (dgOpts.menuId != undefined && dgOpts.menuId.length > 0 ? dgOpts.menuId : 'menu')).menu('show', { left: e.pageX, top: e.pageY });

                            if (typeof (dgOpts.onRowContextMenu) == 'function') {
                                dgOpts.onRowContextMenu(e, index, row);
                            }
                        },
                        onHeaderContextMenu: function (e, field) {
                            //鼠标右键点击标题列显示隐藏“普通列”事件
                            e.preventDefault();
                            if (!QBC.easyUi.grid.cmenu) {
                                QBO.plu.grid.createColumnMenu(dgObj);
                            }
                            QBC.easyUi.grid.cmenu.menu('show', {
                                left: e.pageX,
                                top: e.pageY
                            });
                        },
                        onLoadSuccess: function (data) {
                            //此处的-340来自MsSysController控制器的OnAuthorization方法
                            if (data.total === -340) {
                                QBO.dia.msg('登录已过期，请重新登录！', {
                                    icon: 'error', shift: 6,
                                    endCallback: function () {
                                        parent.location.href = '/MsSys/Login';
                                    }
                                });
                            } else {
                                //在数据加载成功的时候触发
                                if (typeof (dgOpts.onLoadSuccess) == 'function') {
                                    dgOpts.onLoadSuccess(data);
                                }
                            }
                        },
                        onClickRow: function (index, row) {
                            //在用户点击一行的时候触发
                            if (typeof (dgOpts.onClickRow) == 'function') {
                                dgOpts.onClickRow(index, row);
                            }
                        },
                        onBeforeSortColumn: function (sort, order) {
                            /*不能使用以下方式来修改是否触发了点击列排序的状态，否则会调用2次后台查询
                                var thisOpts = dgObj.datagrid('options');
                                var thisOptQueryParams = thisOpts.queryParams;
                                thisOptQueryParams.isSortCol = true;
                                dgObj.datagrid({ queryParams: thisOptQueryParams });
                            */

                            dgObj.datagrid('options').queryParams.isSortCol = true;
                        },
                        onAdd: function (index, row) {
                            //当添加一个新行时触发
                            if (typeof (dgOpts.onAdd) == 'function') {
                                dgOpts.onAdd(index, row);
                            }
                        },
                        onEdit: function (index, row) {
                            //当编辑一行时触发
                            if (typeof (dgOpts.onEdit) == 'function') {
                                dgOpts.onEdit(index, row);
                            }
                        },
                        onBeforeSave: function (index) {
                            //一行被保存之前触发，返回 false 则取消保存动作
                            if (typeof (dgOpts.onBeforeSave) == 'function') {
                                dgOpts.onBeforeSave(index);
                            }
                        },
                        onSave: function (index, row) {
                            //当保存一行时触发
                            if (typeof (dgOpts.onSave) == 'function') {
                                dgOpts.onSave(index, row);
                            }
                        },
                        onDestroy: function (index, row) {
                            //当销毁一行时触发
                            if (typeof (dgOpts.onDestroy) == 'function') {
                                dgOpts.onDestroy(index, row);
                            }
                        },
                        onError: function (index, row) {
                            //当发生服务器错误时触发
                            //服务器应返回一个 'isError' 属性设置为 true 的行，表示发生错误
                            if (typeof (dgOpts.onError) == 'function') {
                                dgOpts.onError(index, row);
                            }
                        }
                    });
                    dgObj.datagrid('getPager').pagination({
                        beforePageText: '第',
                        afterPageText: '页&nbsp;共{pages}页',
                        displayMsg: '当前显示{from}-{to}条记录，共{total}条记录'
                    }).find('a.l-btn').tooltip({
                        content: function () {
                            var cc = $(this).find('span.l-btn-icon').attr('class').split(' ');
                            var name = cc[1].split('-')[1];
                            name = name === 'first' ? '首页' :
                                name === 'prev' ? '上一页' :
                                name === 'next' ? '下一页' :
                                name === 'last' ? '末页' : '刷新';
                            return name;
                        }
                    });
                } else {
                    /*
                        说明：
                        如果想初始化勾选中treegrid的复选框，则需要在获取的后台数据实体中包含checked属性，为bool类型
                    */

                    dgObj.treegrid({
                        animate: QBC.easyUi.grid.animate,
                        border: QBC.easyUi.grid.border,
                        fit: QBC.easyUi.grid.fit,
                        //注意此处，如果设置了冻结的列，那么fitColumns就该设置为false，否则设置冻结列将失效
                        fitColumns: dgOpts.colFro && dgOpts.colFro != undefined && dgOpts.colFro.length > 0 ? false : QBC.easyUi.grid.fitColumns,
                        striped: QBC.easyUi.grid.striped,
                        method: dgOpts.method == undefined || typeof (dgOpts.method) != 'string' ? QBC.easyUi.grid.method : dgOpts.method,
                        loadMsg: QBC.easyUi.grid.loadMsg,
                        rownumbers: QBC.easyUi.grid.rownumbers,
                        singleSelect: dgOpts.singleSelect == undefined || typeof (dgOpts.singleSelect) != 'boolean' ? QBC.easyUi.grid.singleSelect : dgOpts.singleSelect,
                        ctrlSelect: QBC.easyUi.grid.ctrlSelect,
                        pagination: dgOpts.pagination == undefined || typeof (dgOpts.pagination) != 'boolean' ? QBC.easyUi.grid.pagination : dgOpts.pagination,
                        pageSize: dgOpts.pageSize == undefined || typeof (dgOpts.pageSize) != 'number' ? QBC.easyUi.grid.pageSize : dgOpts.pageSize,
                        pageNumber: QBC.easyUi.grid.pageNumber,
                        pageList: QBC.easyUi.grid.pageList,
                        queryParams: thisQueryParams,
                        checkbox: dgOpts.checkbox == undefined || typeof (dgOpts.checkbox) != 'boolean' ? QBC.easyUi.grid.isShowChkTg : dgOpts.checkbox,

                        toolbar: dgOpts.toolbar == undefined || dgOpts.toolbar.length <= 0 ? '#toolBarMain' : '#' + dgOpts.toolbar,
                        idField: dgOpts.idField,
                        treeField: dgOpts.treeField,
                        url: dgOpts.url,
                        frozenColumns: [dgOpts.colFro],//冻结在左侧的列
                        columns: [dgOpts.col],
                        //事件
                        onContextMenu: function (e, row) {
                            e.preventDefault();
                            //右键选中点击行
                            $(this).treegrid('select', row[$(this).treegrid('options').idField]);
                            //显示右键菜单
                            $('#' + (dgOpts.menuId != undefined && dgOpts.menuId.length > 0 ? dgOpts.menuId : 'menu')).menu('show', { left: e.pageX, top: e.pageY });

                            if (typeof (dgOpts.onRowContextMenu) == 'function') {
                                dgOpts.onRowContextMenu(e, row);
                            }
                        },
                        onHeaderContextMenu: function (e, field) {
                            //鼠标右键点击标题列显示隐藏“普通列”事件
                            e.preventDefault();
                            if (!QBC.easyUi.grid.cmenu) {
                                QBO.plu.grid.createColumnMenu(dgObj);
                            }
                            QBC.easyUi.grid.cmenu.menu('show', {
                                left: e.pageX,
                                top: e.pageY
                            });
                        },
                        onLoadSuccess: function (row, data) {
                            //此处的-340来自MsSysController控制器的OnAuthorization方法
                            if (data.total === -340) {
                                QBO.dia.msg('登录已过期，请重新登录！', {
                                    icon: 'error', shift: 6,
                                    endCallback: function () {
                                        parent.location.href = '/MsSys/Login';
                                    }
                                });
                            } else {
                                //在数据加载成功的时候触发
                                if (typeof (dgOpts.onLoadSuccess) == 'function') {
                                    dgOpts.onLoadSuccess(data);
                                }
                            }
                        },
                        onBeforeLoad: function (row, param) {
                            if (typeof (dgOpts.onBeforeLoad) == 'function') {
                                dgOpts.onBeforeLoad(row, param);
                            }
                        },
                        onClickRow: function (index, row) {
                            //在用户点击一行的时候触发
                            if (typeof (dgOpts.onClickRow) == 'function') {
                                dgOpts.onClickRow(index, row);
                            }
                        },
                        onBeforeSortColumn: function (sort, order) {
                            /*不能使用以下方式来修改是否触发了点击列排序的状态，否则会调用2次后台查询
                                var thisOpts = dgObj.datagrid('options');
                                var thisOptQueryParams = thisOpts.queryParams;
                                thisOptQueryParams.isSortCol = true;
                                dgObj.datagrid({ queryParams: thisOptQueryParams });
                            */

                            dgObj.datagrid('options').queryParams.isSortCol = true;
                        }
                    });
                    dgObj.treegrid('getPager').pagination({
                        beforePageText: '第',
                        afterPageText: '页&nbsp;共{pages}页',
                        displayMsg: '当前显示{from}-{to}条记录，共{total}条记录'
                    });
                }
            },
            get: function (dgObj, keyId, type) {
                /*******************************************
                说明：获取datagrid选中的数据
                        dgObj：表格对象（如：$('#dg')）
                        keyId：数据主键Id
                        type：dg：datagrid、edg：edatagrid、tg：treegrid（默认为dg）
                ********************************************/
                type = type == undefined || type.length <= 0 ? 'dg' : type;
                var retData = { str: '', arr: [], obj: [] };

                if (dgObj != null) {
                    retData.obj = type === 'dg' || type === 'edg' ?
                        dgObj.datagrid('getChecked') :
                        dgObj.treegrid('getCheckedNodes');
                    for (var i = 0; i < retData.obj.length; i++) {
                        retData.arr[i] = retData.obj[i][keyId];
                    }
                    retData.str = retData.arr.join(',');
                }

                return retData;
            },
            query: function (dgObj, obj, type) {
                /*******************************************
                说明：查询数据
                        dgObj：表格对象（如：$('#dg')）
                        obj：查询参数（json对象）
                        type：dg：datagrid、edg：edatagrid、tg：treegrid（默认为dg）
                ********************************************/
                type = type == undefined || type.length <= 0 ? 'dg' : type;

                var thisQueryParams = QBO.com.getObj(obj);
                //此参数用于传递给MsSysController控制器的OnAuthorization方法，便于返回不同的数据对象
                thisQueryParams.requestObj = 'EasyUI-DG';

                if (type === 'dg' || type === 'edg') {
                    dgObj.datagrid('load', obj);
                } else {
                    dgObj.treegrid('load', obj);
                }
            },
            queryUrl: function (dgObj, obj, url, type) {
                /*******************************************
                说明：查询数据
                        dgObj：表格对象（如：$('#dg')）
                        obj：查询参数（json对象）
                        type：dg：datagrid、edg：edatagrid、tg：treegrid（默认为dg）
                ********************************************/
                type = type == undefined || type.length <= 0 ? 'dg' : type;

                var thisQueryParams = QBO.com.getObj(obj);
                //此参数用于传递给MsSysController控制器的OnAuthorization方法，便于返回不同的数据对象
                thisQueryParams.requestObj = 'EasyUI-DG';

                if (type === 'dg' || type === 'edg') {
                    dgObj.datagrid({ 'load': obj, 'url': url });
                } else {
                    dgObj.treegrid({ 'load': obj, 'url': url });
                }
            },
            reload: function (dgObj, type) {
                /*******************************************
                说明：重新加载数据
                        dgObj：表格对象（如：$('#dg')）
                        type：dg：datagrid、edg：edatagrid、tg：treegrid（默认为dg）
                ********************************************/
                type = type == undefined || type.length <= 0 ? 'dg' : type;

                if (type === 'dg' || type === 'edg') {
                    dgObj.datagrid('reload');
                } else {
                    dgObj.treegrid('reload');
                }
            },
            createColumnMenu: function (dgObj, onHideCallBack) {
                /*******************************************
                说明：鼠标右键点击标题列显示隐藏“普通列”事件
                        dgObj：表格对象（如：$('#dg')）
                ********************************************/
                QBC.easyUi.grid.cmenu = $('<div/>').appendTo('body');
                QBC.easyUi.grid.cmenu.menu({
                    onClick: function (item) {
                        //console.log(JSON.stringify(item));
                        if (item.iconCls == 'icon-apply') {
                            dgObj.datagrid('hideColumn', item.name);
                            QBC.easyUi.grid.cmenu.menu('setIcon', {
                                target: item.target,
                                iconCls: 'icon-empty'
                            });
                        } else {
                            dgObj.datagrid('showColumn', item.name);
                            QBC.easyUi.grid.cmenu.menu('setIcon', {
                                target: item.target,
                                iconCls: 'icon-apply'
                            });
                        }

                        //点击显示隐藏回调事件
                        if (typeof (onHideCallBack) == 'function') {
                            onHideCallBack(item);
                        }
                    }
                });

                var fields = dgObj.datagrid('getColumnFields');
                //console.log(JSON.stringify(fields));
                for (var i = 0; i < fields.length; i++) {
                    var field = fields[i];
                    var col = dgObj.datagrid('getColumnOption', field);
                    //console.log(JSON.stringify(col));
                    //console.log(JSON.stringify(col.hidden));                   
                    var iconCls = (col.hidden ? 'icon-empty' : 'icon-apply');
                    QBC.easyUi.grid.cmenu.menu('appendItem', {
                        text: col.title,
                        name: field,
                        iconCls: iconCls
                    });

                }
            },
            clear: function (dgObj) {
                /*******************************************
                说明：清空表格数据
                        dgObj：表格对象（如：$('#dg')）
                ********************************************/
                dgObj.datagrid('loadData', { total: 0, rows: [] });
            },
            formatIf: function (value, row, index) {
                /*******************************************
                说明：格式化表格属性值为是或否（接受的类型有：boolean、number和string）
                        value：当前行某属性的值
                        row：当前行数据对象
                        index：当前行索引
                ********************************************/
                var retVal;
                if (typeof (value) === 'boolean' || typeof (value) === 'number' || typeof (value) === 'string') {
                    retVal = value === true || value === 1 || value === '1' || value === '是' ?
                        '<span class="eui-icon fa fa-check-circle">&nbsp;</span>' : '<span class="eui-icon fa fa-times-circle qb-color-red">&nbsp;</span>';
                } else {
                    retVal = value;
                }
                return retVal;
            },
            formatSex: function (value, row, index) {
                /*******************************************
                说明：格式化表格属性值为男或女（接受的类型有：boolean、number和string）
                        value：当前行某属性的值
                        row：当前行数据对象
                        index：当前行索引
                ********************************************/
                var retVal;
                if (typeof (value) === 'boolean' || typeof (value) === 'number' || typeof (value) === 'string') {
                    retVal = value === true || value === 1 || value === '男' ? '男' : '女';
                } else {
                    retVal = value;
                }
                return retVal;
            },
            formatShortDate: function (value, row, index) {
                /*******************************************
                说明：格式化表格属性值为男或女（接受的类型有：boolean、number和string）
                        value：当前行某属性的值
                        row：当前行数据对象
                        index：当前行索引
                ********************************************/
                if (value == null || value == '') {
                    return '';
                }
                var dt;
                if (value instanceof Date) {
                    dt = value;
                }
                else {
                    dt = new Date(value);
                    if (isNaN(dt)) {
                        value = value.replace(/\/Date\((-?\d+)\)\//, '$1'); //标红的这段是关键代码，将那个长字符串的日期值转换成正常的JS日期格式
                        dt = new Date();
                        dt.setTime(value);
                    }
                }

                return dt.format("yyyy-MM-dd");

            }
        },
        cbgrid: {
            init: function (cbObj, cbOpts) {
                /*******************************************
                说明：初始化combogrid
                        cbObj：输入框对象（如：$('#roleNames')）
                        obj：{}
                            panelWidth：下拉表格面板宽度，默认为450
                            panelHeight：下拉表格面板高度，默认为200
                            multiple：是否多选，默认为false，
                            editable：是否允许输入文本，默认为false，
                            idField：数据Id字段
                            textField：显示文本字段
                            url：获取服务端数据地址
                            method：请求方式，默认为POST（POST或GET）
                            value：设置默认值（数组，其中的值和idField字段的值保持一致）
                            col：显示的列配置
                ********************************************/
                cbOpts.panelWidth = QBO.com.getObj(cbOpts.panelWidth, 'int', 450);
                cbOpts.panelHeight = QBO.com.getObj(cbOpts.panelHeight, 'int', 200);
                cbOpts.multiple = QBO.com.getObj(cbOpts.multiple, 'bool', false);
                cbOpts.editable = QBO.com.getObj(cbOpts.editable, 'bool', false);
                cbOpts.idField = QBO.com.getObj(cbOpts.idField, 'str', '');
                cbOpts.textField = QBO.com.getObj(cbOpts.textField, 'str', '');
                cbOpts.url = QBO.com.getObj(cbOpts.url, 'str', '');
                cbOpts.method = QBO.com.getObj(cbOpts.method, 'str', 'POST');
                cbOpts.value = QBO.com.getObj(cbOpts.value, 'arr', []);
                cbOpts.col = QBO.com.getObj(cbOpts.col, 'arr', []);

                cbObj.combogrid({
                    panelWidth: cbOpts.panelWidth,
                    panelHeight: cbOpts.panelHeight,
                    multiple: cbOpts.multiple,
                    editable: cbOpts.editable,
                    idField: cbOpts.idField,
                    textField: cbOpts.textField,
                    url: cbOpts.url,
                    method: cbOpts.method,
                    value: cbOpts.value,
                    columns: [cbOpts.col],
                    fitColumns: true
                });
            },
            getVal: function (cbObj) {
                /*******************************************
                说明：获取combogrid的值（数组JSON对象）
                        cbObj：输入框对象（如：$('#roleNames')）
                ********************************************/
                return cbObj.combogrid('getValues');
            },
            setVal: function (cbObj, val) {
                /*******************************************
                说明：获取combogrid的值（数组JSON对象）
                        cbObj：输入框对象（如：$('#roleNames')）
                        val：设置的值
                ********************************************/
                return cbObj.combogrid('setValues', val);
            }
        },
        zt: {//zTree
            init: function (zTreeId, zTreeData, obj) {
                /*******************************************
                说明：初始化zTree
                        zTreeId：zTree容器Id
                        zTreeData：数据集和
                        obj：{check:true,isCheckbox:true,onClick:null,onCheck:null,fontCss:{},chkboxTypeY:'',chkboxTypeN:''}
                            keyName: 'MyName',//显示的字段名称，默认为name
                            keyId: 'ID',//显示的数据ID字段名称，默认为id
                            keyPid: 'ParentId',//显示的数据父ID字段名称，默认为pId
                            check：是否有复选框或单选框（可不填，默认为false）
                            isCheckbox：是否为checkbox，否则为radio（前提是check为true才起作用）
                            onClick：节点点击回调函数（返回三个参数event, treeId, treeNode）
                            onCheck：节点勾选回调函数（返回三个参数event, treeId, treeNode）
                            fontCss：节点样式（Json对象或function）
                            showIcon：是否显示节点图标（可不填，默认为true）
                            chkboxTypeY：勾选后的动作，p影响父级、s影响子级、ps影响父级和子级
                            chkboxTypeN：取消勾选后的动作，p影响父级、s影响子级、ps影响父级和子级
                ********************************************/
                obj.keyName = QBO.com.getObj(obj.keyName, 'str', 'name');
                obj.keyId = QBO.com.getObj(obj.keyId, 'str', 'id');
                obj.keyPid = QBO.com.getObj(obj.keyPid, 'str', 'pId');

                var chkboxType = {
                    "Y": obj.chkboxTypeY == undefined || (obj.chkboxTypeY !== 'p' && obj.chkboxTypeY !== 's' && obj.chkboxTypeY !== 'ps') ? "p" : obj.chkboxTypeY,
                    "N": obj.chkboxTypeN == undefined || (obj.chkboxTypeN !== 'p' && obj.chkboxTypeN !== 's' && obj.chkboxTypeN !== 'ps') ? "s" : obj.chkboxTypeN
                };
                var zTreeSetting = QBC.zTree;

                zTreeSetting.data.key.name = obj.keyName;
                zTreeSetting.data.simpleData.idKey = obj.keyId;
                zTreeSetting.data.simpleData.pIdKey = obj.keyPid;

                //设置影响级别
                zTreeSetting.check.chkboxType = chkboxType;
                zTreeSetting.check.enable = obj.check == undefined || !obj.check ? false : true;
                zTreeSetting.check.chkStyle = obj.isCheckbox == undefined || obj.isCheckbox ? 'checkbox' : 'radio';
                zTreeSetting.view.showIcon = obj.showIcon == undefined || typeof (obj.showIcon) != 'boolean' ? true : obj.showIcon;
                zTreeSetting.view.fontCss = obj.fontCss == undefined && typeof (obj.fontCss) != 'function' && typeof (obj.fontCss) != 'object' ? {} : obj.fontCss;
                zTreeSetting.view.selectedMulti = obj.check == undefined || !obj.check || zTreeSetting.check.chkStyle === 'radio' ? false : true;
                //设置节点点击事件
                zTreeSetting.callback.onClick = function (event, treeId, treeNode) {
                    QBO.plu.zt.doClick('onClick', event, treeId, treeNode, zTreeSetting);
                    if (typeof (obj.onClick) == 'function') { obj.onClick(event, treeId, treeNode); }
                };
                //设置节点勾选事件
                zTreeSetting.callback.onCheck = function (event, treeId, treeNode) {
                    QBO.plu.zt.doClick('onCheck', event, treeId, treeNode, zTreeSetting);
                    if (typeof (obj.onCheck) == 'function') { obj.onCheck(event, treeId, treeNode); }
                };
                //初始化zTree
                $.fn.zTree.init($("#" + zTreeId), zTreeSetting, zTreeData);
                //展开和设置节点勾选选中状态
                QBO.plu.zt.openChkedNode(zTreeData, zTreeId, zTreeSetting);
            },
            get: function (zTreeId, isGetChecked, isGetCheckedTrue) {
                /*******************************************
                说明：获取勾选或选中节点
                        zTreeId：zTree容器Id
                        isGetChecked：是否返回勾选的节点集合（可不填，true：是、false：返回选中的节点集合，默认为true）
                        isGetCheckedTrue：是否为勾选复选框或单选按钮的值（可不填，true：是、false：否，默认为true）
                ********************************************/
                var ret = { str: '', arr: [], obj: [] };
                if (zTreeId == undefined || zTreeId.length <= 0) {
                    console.log('error：获取zTree勾选节点时未传递Id');
                } else {
                    var ztreeKeyId = $.fn.zTree.getZTreeObj(zTreeId).setting.data.simpleData.idKey;

                    isGetChecked = isGetChecked == undefined || isGetChecked ? true : false;
                    isGetCheckedTrue = isGetCheckedTrue == undefined || isGetCheckedTrue ? true : false;
                    var treeObj = $.fn.zTree.getZTreeObj(zTreeId),
                        nodes = isGetChecked ? treeObj.getCheckedNodes(isGetCheckedTrue) : treeObj.getSelectedNodes();
                    for (var i = 0; i < nodes.length; i++) {
                        ret.arr[i] = nodes[i][ztreeKeyId];
                    }
                    ret.str = ret.arr.join(',');
                    ret.obj = nodes;
                }
                return ret;
            },
            checkAll: function (zTreeId, isCheck) {
                /*******************************************
                说明：全选或全取消
                        zTreeId：zTree容器Id
                        isCheck：是否为勾选所有节点（可不填，true：全选、false：取消全选，默认为true）
                ********************************************/
                isCheck = isCheck == undefined || isCheck ? true : false;
                var treeObj = $.fn.zTree.getZTreeObj(zTreeId);
                treeObj.checkAllNodes(isCheck);
            },
            doClick: function (clickType, event, treeId, treeNode, zTreeSetting) {
                /*******************************************
                说明：点击文字勾选中节点、点击勾选选中文字
                        clickType：事件类型（onClick、onCheck）
                        event：zTree节点事件
                        treeId：zTree容器Id
                        treeNode：节点对象
                        zTreeSetting：zTree初始化配置
                ********************************************/
                if (!zTreeSetting.check.enable) { return; }
                var treeObj = $.fn.zTree.getZTreeObj(treeId);
                if (clickType === 'onClick') { treeObj.checkNode(treeNode, null, true); }
                if (!treeNode.checked) { treeObj.cancelSelectedNode(); }
                else { if (clickType === 'onCheck') { treeObj.selectNode(treeNode); } }
            },
            openChkedNode: function (zTreeData, treeId, zTreeSetting) {
                /*******************************************
                说明：展开和设置节点勾选选中状态
                        zTreeData：zTree数据
                        treeId：zTree容器Id
                        zTreeSetting：zTree初始化配置
                ********************************************/
                var treeObj = $.fn.zTree.getZTreeObj(treeId);
                for (var i = 0; i < zTreeData.length; i++) {
                    var parentNode = treeObj.getNodeByParam('id', zTreeData[i].pId),
                        currentNode = treeObj.getNodeByParam('id', zTreeData[i].id);
                    if (parentNode != null && currentNode.checked) {
                        //当为checkbox类型时，设置checked属性为true的父节点为勾选状态
                        if (zTreeSetting.check.chkStyle === 'checkbox' && !parentNode.checked) { treeObj.checkNode(parentNode, null, true); }
                        //当为radio类型时，设置checked属性为true的节点文字为选中状态
                        if (zTreeSetting.check.chkStyle === 'radio' && currentNode.checked) { treeObj.selectNode(currentNode); }
                        //展开父节点
                        treeObj.expandNode(parentNode, true, false, true);
                    }
                }
            }
        },
        cookie: {//jQuery cookie
            set: function (key, val, opts) {
                /*******************************************
                说明：设置cookie
                        key：cookie key
                        val：cookie value
                        opts：附加属性对象，比如{ expires: 1 }
                ********************************************/
                if (key != undefined && val != undefined && key.length > 0) {
                    if (!opts) {
                        $.cookie(key, val);
                    } else {
                        $.cookie(key, val, opts);
                    }
                }
            },
            get: function (key) {
                /*******************************************
                说明：获取cookie
                        key：cookie key
                ********************************************/
                var thisVal = '';
                if (key != undefined && typeof (key) == 'string' && key.length > 0) {
                    thisVal = $.cookie(key);
                }
                return thisVal == undefined || thisVal == 'null' ? '' : thisVal;
            },
            del: function (key) {
                /*******************************************
                说明：删除cookie
                        key：cookie key
                ********************************************/
                if (key != undefined && typeof (key) == 'string' && key.length > 0) {
                    $.cookie(key, null);
                }
            }
        },
        ue: {//UEditor
            init: function (editorId) {
                /*******************************************
                说明：初始化并返回UEditor对象
                        editorId：UEditor Id（可不填，默认Id为editor）
                ********************************************/
                editorId = QBO.com.getObj(editorId, 'str', 'editor');

                var ueObj = UE.getEditor(editorId);
                return ueObj;
            },
            get: function (ueObj) {
                /*******************************************
                说明：获取UEditor值
                        ueObj：UEditor对象
                ********************************************/
                var con = ueObj.getContent();
                return con;
            },
            set: function (ueObj, content) {
                /*******************************************
                说明：设置UEditor值
                        ueObj：UEditor对象
                        content：设置的内容
                ********************************************/
                ueObj.setContent(content);
            },
            clear: function (ueObj) {
                /*******************************************
                说明：清除UEditor值
                        ueObj：UEditor对象
                ********************************************/
                ueObj.execCommand('cleardoc');
            }
        },
        fileUploadify: function (uploadObj, formData, settingObj) {
            /*******************************************
            说明：文件上传
                    uploadObj：上传控件file的jQuery对象
                    formData：提交到服务器参数
                    settingObj：配置参数
                        {uploadLimit:200,queueSizeLimit:200,auto:false,multi:false,fileSizeLimit:'100MB',fileTypeExts:'*.gif; *.jpg; *.png',method:'POST'}
            ********************************************/
            settingObj = QBO.com.getObj(settingObj);

            //是否为多文件上传
            var isMulti = settingObj.multi == undefined ? QBC.uploadify.multi : settingObj.multi;

            uploadObj.uploadify({
                width: QBC.uploadify.width, height: QBC.uploadify.height, fileObjName: QBC.uploadify.fileObjName, fileTypeDesc: QBC.uploadify.fileTypeDesc, progressData: QBC.uploadify.progressData, removeCompleted: QBC.uploadify.removeCompleted, removeTimeout: QBC.uploadify.removeTimeout, requeueErrors: QBC.uploadify.requeueErrors, successTimeout: QBC.uploadify.successTimeout, swf: QBC.uploadify.swf, uploader: QBC.uploadify.uploader, queueID: QBC.uploadify.queueID, buttonText: QBC.uploadify.buttonText,
                uploadLimit: settingObj.uploadLimit == undefined ? QBC.uploadify.uploadLimit : settingObj.uploadLimit,
                queueSizeLimit: settingObj.queueSizeLimit == undefined ? QBC.uploadify.queueSizeLimit : settingObj.queueSizeLimit,
                auto: settingObj.auto == undefined ? QBC.uploadify.auto : settingObj.auto,
                multi: settingObj.multi == undefined ? QBC.uploadify.multi : settingObj.multi,
                fileSizeLimit: settingObj.fileSizeLimit == undefined ? QBC.uploadify.fileSizeLimit : settingObj.fileSizeLimit,
                fileTypeExts: settingObj.fileTypeExts == undefined ? QBC.uploadify.fileTypeExts : settingObj.fileTypeExts,
                method: settingObj.method == undefined ? QBC.uploadify.method : settingObj.method,
                formData: formData,

                //重写事件
                overrideEvents: ['onFallback', 'onSelectError', 'onUploadSuccess'],
                //事件
                onFallback: function () {
                    //没有兼容的flash时触发
                    QBO.dia.tip('您未安装Flash控件，无法上传图片！请安装Flash控件后再试。', 'error');
                    return;
                },
                onQueueComplete: function (queueData) {
                    //当队列中的所有文件全部完成上传时触发
                    $('#lbtnUpload,#lbtnCancelUp').hide(500);
                    return;
                },
                onClearQueue: function (queueItemCount) {
                    //在调用cancel方法且传入参数*时触发→<a href="javascript:$('#uploadify').uploadify('cancel','*')">取消上传</a>
                    $('#lbtnUpload,#lbtnCancelUp').hide(500);
                    return;
                },
                onSelect: function (file) {
                    //选择文件后触发
                    $('#lbtnUpload,#lbtnCancelUp').show(500);
                },
                onSelectError: function (file, errorCode, errorMsg) {
                    //选择文件后出错时触发
                    switch (errorCode) {
                        case -100:
                            if (uploadObj.uploadify('settings', 'queueSizeLimit') > errorMsg)
                                QBO.dia.tip('上传的文件数量已经超出系统限制的' + errorMsg + '个文件！', 'error');
                            else
                                QBO.dia.tip('上传的文件队列数量已经超出系统限制的' + uploadObj.uploadify('settings', 'queueSizeLimit') + '个文件！', 'error');
                            break;
                        case -110:
                            QBO.dia.tip('文件 [' + file.name + '] 大小超出系统限制的' + uploadObj.uploadify('settings', 'fileSizeLimit') + '大小！', 'error');
                            break;
                        case -120:
                            QBO.dia.tip('文件 [' + file.name + '] 大小异常！', 'error');
                            break;
                        case -130:
                            QBO.dia.tip('文件 [' + file.name + '] 格式不正确！', 'error');
                            break;
                    }
                },
                onUploadSuccess: function (file, data, response) {
                    //每个文件上传成功后触发
                    //alert("id:" + file.id + " -索引:" + file.index + " -文件名称:" + file.name + " -文件大小:" + file.size + " -文件类型:" + file.type + " -创建日期:" + file.creationdate + " -修改日期:" + file.modificationdate + " -文件状态:" + file.filestatus + " –服务器端消息:" + data + " –是否上传成功:" + response);
                    data = JSON.parse(data);
                    var imgPanel = $('#upload-img-panel');

                    //单个文件上传成功后触发事件
                    if (data.status) {
                        //设置图片是否上传状态（0：否、1：是）
                        imgPanel.data('chk', 1);
                        if (!isMulti || (isMulti && QBC.uploadify.uploadLimit == 1)) {
                            //单个文件
                            $('#showImgDefault').attr('src', data.info);
                            imgPanel.data('path', data.info);
                            //console.log(imgPanel.data('path'));
                        } else {
                            //多个文件
                            var imgPath = imgPanel.data('path');
                            imgPath += imgPath.length <= 0 ? data.info : '|' + data.info;
                            //将默认图片隐藏
                            $('#showImgDefault').hide();
                            //将图片展示到图片显示区域
                            var thisImg = '<img src="' + data.info + '" alt="Quber" />';
                            imgPanel.append(thisImg);

                            //console.log('--------------------------------');
                            //console.log(imgPanel.data('path'));
                            imgPanel.data('path', imgPath);
                            //console.log(imgPanel.data('path'));
                        }
                    } else {
                        QBO.dia.tip(data.info, 'error');
                    }
                }
            });
        },
        ng: {//Angular
            http: function (obj, successCallback) {
                /*******************************************
                说明：上传文件方法
                        obj：{http:$http,method:'GET',url:'',params:{}}
                            http：Angular内置$http对象
                            method：请求方式（默认为GET）
                            url：服务请求地址
                            params：服务请求参数
                            data：在发送post请求时使用，作为消息体发送到服务器
                            isLoad：是否显示loading
                            isTopPath:false是否为顶部页面发出请求的
                            chkLogin： true,//请求数据之前是否检查已经登录（可不填，默认为true）
                        successCallback：请求成功后的回调函数
                ********************************************/
                obj = QBO.com.getObj(obj);
                obj.isTopPath = QBO.com.getObj(obj.isTopPath, 'bool', false);
                obj.chkLogin = QBO.com.getObj(obj.chkLogin, 'bool', true);
                obj.method = QBO.com.getObj(obj.method, 'string', 'GET');
                obj.isLoad = QBO.com.getObj(obj.isLoad, 'bool', false);
                obj.params = QBO.com.getObj(obj.params);
                obj.data = QBO.com.getObj(obj.data);

                if (obj.chkLogin) {
                    QBO.frm.getUser(function () {
                        QBO.plu.ng.httpPri(obj, successCallback);
                    });
                } else {
                    QBO.plu.ng.httpPri(obj, successCallback);
                }
            },
            httpPri: function (obj, successCallback) {
                if (obj.isLoad) {
                    QBO.dia.load();
                }

                obj.http({
                    method: obj.method,
                    url: obj.url,
                    params: obj.params,
                    data: obj.data,
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                }).success(function (data, status, headers, config) {
                    if (typeof (successCallback) == 'function') { successCallback(data); }
                    if (obj.isLoad) {
                        QBO.dia.loadClose();
                    }
                }).error(function (data, status, headers, config) {
                    if (obj.isLoad) {
                        QBO.dia.loadClose();
                    }
                });
            },
            postReg: function ($httpProvider) {
                /*******************************************
                说明：$http的post提交时，纠正消息体
                        参考：http://victorblog.com/2012/12/20/make-angularjs-http-service-behave-like-jquery-ajax/
                ********************************************/
                // Use x-www-form-urlencoded Content-Type
                $httpProvider.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
                /*
                 * The workhorse; converts an object to x-www-form-urlencoded serialization.
                 * @param {Object} obj
                 * @return {String}
                 */
                var param = function (obj) {
                    var query = '', name, value, fullSubName, subName, subValue, innerObj, i;

                    for (name in obj) {
                        value = obj[name];

                        if (value instanceof Array) {
                            for (i = 0; i < value.length; ++i) {
                                subValue = value[i];
                                fullSubName = name + '[' + i + ']';
                                innerObj = {};
                                innerObj[fullSubName] = subValue;
                                query += param(innerObj) + '&';
                            }
                        }
                        else if (value instanceof Object) {
                            for (subName in value) {
                                subValue = value[subName];
                                fullSubName = name + '[' + subName + ']';
                                innerObj = {};
                                innerObj[fullSubName] = subValue;
                                query += param(innerObj) + '&';
                            }
                        }
                        else if (value !== undefined && value !== null)
                            query += encodeURIComponent(name) + '=' + encodeURIComponent(value) + '&';
                    }

                    return query.length ? query.substr(0, query.length - 1) : query;
                };

                // Override $http service's default transformRequest
                $httpProvider.defaults.transformRequest = [function (data) {
                    return angular.isObject(data) && String(data) !== '[object File]' ? param(data) : data;
                }];
            },
            toHtml: function (ngApp) {
                /*******************************************
                说明：取消对Html的转义
                        ngApp：Angular初始化对象
                ********************************************/
                ngApp.filter("toHtml", function ($sce) {
                    return function (text) {
                        return $sce.trustAsHtml(text + '');
                    }
                });
            },
            listenRepeat: function (ngApp) {
                /*******************************************
                说明：监听ng-repeat完成事件
                        ngApp：Angular初始化对象
                ********************************************/
                ngApp.directive('repeatFinish', function () {
                    return {
                        link: function (scope, element, attr) {
                            //console.log(scope.$index)
                            //$last为true时，ng-repeat渲染完毕
                            if (scope.$last == true) {
                                scope.$eval(attr.repeatFinish);
                            }
                        }
                    }
                });
            },
            noCache: function ($httpProvider) {
                //禁用IE对数据请求的缓存

                // Initialize get if not there
                if (!$httpProvider.defaults.headers.get) {
                    $httpProvider.defaults.headers.get = {};
                }

                // Enables Request.IsAjaxRequest() in ASP.NET MVC
                $httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';

                //禁用IE对ajax的缓存
                $httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache';
                $httpProvider.defaults.headers.get['Pragma'] = 'no-cache';
            }
        }
    },
    frm: {
        getSetTheme: function (type, themeName) {
            /*******************************************
            说明：获取管理员信息
                    type：（init：初始化、set：设置主题）
                    themeName：设置的主题名称
            ********************************************/
            if (type == 'init') { //初始化
                var getTheme = QBO.plu.cookie.get('MsSysTheme');
                var oldTheme = !getTheme || getTheme.length <= 0 ? 'blue' : getTheme;

                ////设置cookie
                //QBO.plu.cookie.set('MsSysTheme', oldTheme, { expires: 1 });

                //设置样式主题
                $('#linkThemes').attr('href', '/Content/Css/Themes/base.' + oldTheme + '.css');
            } else {//设置主题
                ////设置cookie
                //QBO.plu.cookie.set('MsSysTheme', themeName, { expires: 1 });

                //改变样式主题
                $('#linkThemes').attr('href', '/Content/Css/Themes/base.' + themeName + '.css');

                //修改管理员个人配置数据
                QBO.plu.ajax({
                    url: '/MsSys/Operator/SetTheme',
                    data: { themeName: themeName }
                }, function (data) {
                    QBO.dia.msg(data.Msg, data.Result === 100 ? 'right' : 'error');
                });
            }
        },
        chkForm: function (formId) {
            /*******************************************
            说明：检查表单是否通过验证
                    formId：form表单Id
            ********************************************/
            formId = QBO.com.getObj(formId, 'string', 'thisForm');
            return $('#' + formId).isValid();
        },
        getUser: function (sucCallback, isLogin) {
            /*******************************************
            说明：获取管理员信息
                    sucCallback：请求成功后的回调函数
                    isLogin：当登录过期时，是否返回登录页面（默认为true）
            ********************************************/
            isLogin = QBO.com.getObj(isLogin, 'bool', true);
            QBO.plu.ajaxPri({
                isLoad: false,
                url: '/MsSys/Common/GetMsSysUser'
            }, function (data) {
                if (isLogin) {
                    if (data.Result === 100) {
                        if (typeof (sucCallback) == 'function') {
                            sucCallback(data.Data);
                        }
                    } else {
                        QBO.dia.msg(data.Msg,
                        {
                            icon: 'error',
                            shift: 6,
                            endCallback: function () {
                                parent.location.href = '/MsSys/Login/LoginOut';
                            }
                        });
                    }
                } else {
                    if (typeof (sucCallback) == 'function') {
                        sucCallback(data);
                    }
                }
            });
        },
        doPage: function (type, obj, dgType) {
            /*******************************************
            说明：添加、修改、查看和删除操作入口
                    type：add：添加、modify|update：修改、view：查看、delete|del：删除
                    obj：{url:'',title:'',icon:'th-large',width:400,height:200,dgObj:$('#gridId'),keyId:'Id',delCallback:function(){},cancelCallback:function(){}}
                        url：添加修改查看时的url窗体地址，删除时的请求地址
                        title：添加修改查看时的窗体标题
                        icon：窗体左上角图标名称（可不填，默认为th-large）
                        width：添加修改查看时的窗体宽度
                        height：添加修改查看时的窗体高度
                        dgObj：删除时的表格对象
                        keyId：删除数据的主键Id
                        delCallback：删除时的回调函数
                        cancelCallback：添加修改查看时窗体关闭后的回调函数
                    dgType：dg：datagrid、edg：edatagrid、tg：treegrid（默认为dg）
            ********************************************/
            dgType = dgType == undefined || dgType.length <= 0 ? 'dg' : dgType;
            obj.icon = QBO.com.getObj(obj.icon, 'str', 'th-large');
            obj.width = QBO.com.getObj(obj.width, 'num', 1000);
            obj.height = QBO.com.getObj(obj.height, 'num', 450);

            if (type === 'add' || type === 'modify' || type === 'update' || type === 'view') {
                var thisKeyId = type === 'add' ? $('#addKeyId').val() : QBO.plu.grid.get(obj.dgObj, obj.keyId).str;

                var urlOType = obj.url.indexOf('?') === -1 ? '?oType=' + type : '&oType=' + type;
                obj.url = obj.url + urlOType + '&keyId=' + thisKeyId
                    //optPageType：（1：操作页面主页面，2：操作页面子页面）
                    + '&optPageType=2';
            }

            if (type === 'add') {
                QBO.frm.openWin(obj.url, { title: obj.title, icon: obj.icon, width: obj.width, height: obj.height, cancelCallback: obj.cancelCallback });
                return;
            }
            var typeName = type === 'modify' || type === 'update' ? '修改' : type === 'view' ? '查看' : type === 'delete' || type === 'del' ? '删除' : '操作';
            if (QBO.plu.grid.get(obj.dgObj, obj.keyId).obj.length <= 0) {
                QBO.dia.msg('请勾选需要' + typeName + '的数据！', { shift: 6, icon: 'error', time: 2000 });
                return;
            }
            if (type === 'modify' || type === 'update' || type === 'view') {
                if (QBO.plu.grid.get(obj.dgObj, obj.keyId).obj.length > 1) {
                    QBO.dia.msg('只能' + typeName + '1条数据，当前已勾选<span style="color:#e4393c;">&nbsp;' + QBO.plu.grid.get(obj.dgObj, obj.keyId).obj.length + '&nbsp;</span>条！', { shift: 6, icon: 'error', time: 2500 });
                    return;
                }
                QBO.frm.openWin(obj.url, { title: obj.title, icon: obj.icon, width: obj.width, height: obj.height, cancelCallback: obj.cancelCallback });
            } else if (type === 'delete' || type === 'del') {
                QBO.dia.confirm('确定要删除勾选的数据？', function () {
                    QBO.plu.ajax({
                        doType: '删除', url: obj.url, data: mvcParamMatch({ list: QBO.plu.grid.get(obj.dgObj, obj.keyId).obj })
                    }, function (data) {
                        if (typeof (obj.delCallback) == 'function') {
                            obj.delCallback(data);
                        }
                        //定义提示信息和图标
                        var retTip = data.Result === 100 ? data.Msg != null && data.Msg != undefined && data.Msg.length > 0 ? data.Msg : '数据删除成功！' : '数据删除失败，请稍后再试！',
                            retIcon = data.Result === 100 ? 'right' : 'error';
                        QBO.dia.msg(retTip, {
                            icon: retIcon,
                            endCallback: function () {
                                if (data.Result === 100) {
                                    //刷新列表数据
                                    QBO.plu.grid.reload(obj.dgObj, dgType);
                                }
                            }
                        });
                    });
                });
            }
        },
        downFile: function (filePath, fileName) {
            /*******************************************
            说明：下载文件
                    filePath：下载的文件地址
                    fileName：下载的文件名称（包括后缀）
            ********************************************/
            var fileUrl = '/MsSys/Common/DownFile?filePath=' + filePath + '&fileName=' + fileName;

            if (typeof (QBO.frm.downFile.iframe) == "undefined") {
                var iframe = document.createElement("iframe");
                QBO.frm.downFile.iframe = iframe;
                document.body.appendChild(QBO.frm.downFile.iframe);
            }
            QBO.frm.downFile.iframe.src = fileUrl;
            QBO.frm.downFile.iframe.style.display = "none";
        },
        submit: function (formObj, obj) {
            /*******************************************
            说明：提交表单
                    formObj：form的jQuery对象
                    obj：{url:'',onSubmit:function(param){},success:function(data){},loadType:1}
                        chkLogin：检查是否登录（默认为true）
                        url：表单提交地址
                        onSubmit：表单提交前的回调函数，可传递额外的参数
                        success：表单提交成功过后的回调函数
                        isLoad：是否显示等待效果（加载层，可不填，默认为true）
                        loadType：加载层类型（可不填，默认为layer[1]，2为easyui加载层效果）
                        doType：easyui loading层加载时提示的操作类型，默认为操作
            ********************************************/
            obj.chkLogin = QBO.com.getObj(obj.chkLogin, 'bool', true);
            obj.isLoad = QBO.com.getObj(obj.isLoad, 'bool', false);
            obj.loadType = QBO.com.getObj(obj.loadType, 'num', 1);
            obj.doType = QBO.com.getObj(obj.doType, 'str', '操作');

            //验证表单是否正确
            var isRight = formObj.form('enableValidation').form('validate');
            if (!isRight) { return; }

            if (obj.chkLogin) {
                QBO.frm.getUser(function () {
                    QBO.frm.submitPri(formObj, obj);
                });
            } else {
                QBO.frm.submitPri(formObj, obj);
            }
        },
        submitPri: function (formObj, obj) {
            /*******************************************
            说明：提交表单
                    formObj：form的jQuery对象
                    obj：{url:'',onSubmit:function(param){},success:function(data){},loadType:1}
                        url：表单提交地址
                        onSubmit：表单提交前的回调函数，可传递额外的参数
                        success：表单提交成功过后的回调函数
                        isLoad：是否显示等待效果（加载层，可不填，默认为true）
                        loadType：加载层类型（可不填，默认为layer[1]，2为easyui加载层效果）
                        doType：easyui loading层加载时提示的操作类型，默认为操作
            ********************************************/
            obj.isLoad = QBO.com.getObj(obj.isLoad, 'bool', false);
            obj.loadType = QBO.com.getObj(obj.loadType, 'num', 1);
            obj.doType = QBO.com.getObj(obj.doType, 'str', '操作');

            //显示遮罩层
            var loadIndex = 0;
            if (obj.isLoad) {
                if (obj.loadType === 1) {
                    loadIndex = QBO.dia.load();
                } else {
                    parent.$.messager.progress({ text: '数据' + obj.doType + '中，请稍后...' });
                }
            }
            formObj.form('submit', {
                url: obj.url,
                onSubmit: function (param) {
                    //设置默认操作类型、数据Id（以便ResultLogFilter过滤器记录日志信息）
                    param.oType = QBO.com.getObj(QBO.com.getUrlVal('oType'), 'str', 'save');
                    param.keyId = param.keyId != undefined && param.keyId.length > 0 ? param.keyId :
                        QBO.com.getObj(QBO.com.getUrlVal('keyId'), 'str', '');

                    //增加额外参数
                    if (typeof (obj.onSubmit) == 'function') { obj.onSubmit(param); }

                    //验证表单是否正确
                    var isRight = formObj.form('enableValidation').form('validate');

                    if (!isRight) {
                        //关闭遮罩层
                        if (obj.isLoad) {
                            if (obj.loadType === 1) {
                                QBO.dia.loadClose();
                            } else {
                                parent.$.messager.progress('close');
                            }
                        }
                    }
                    return isRight;
                },
                success: function (data) {
                    data = $.parseJSON(data);
                    if (typeof (obj.success) == 'function') { obj.success(data); }

                    //关闭遮罩层
                    if (obj.isLoad) {
                        if (obj.loadType === 1) {
                            QBO.dia.loadClose();
                        } else {
                            parent.$.messager.progress('close');
                        }
                    }
                }
            });
        },
        init: {
            initFun: function () {
                /*******************************************
                说明：Form页面初始化函数
                ********************************************/
                QBO.frm.init.setFrmCss();
                QBO.frm.init.setFrmValid();
            },
            setFrmCss: function () {
                /*******************************************
                说明：设置表格样式
                ********************************************/
                var frmObj = $('.frm-tb'),
                    tdLineStyle = ['primary', 'success', 'info', 'warning', 'danger'];

                frmObj.each(function (i) {
                    var thisFrmTb = $(this),
                        thisFrmTbTbody = thisFrmTb.find('tbody'),
                        thisFrmTbTbodyTr = thisFrmTbTbody.find('tr');
                    //tr
                    thisFrmTbTbodyTr.each(function (iTr) {
                        var thisTrObj = $(this),
                            thisTrObjTd = thisTrObj.find('td');

                        if (!frmObj.hasClass('frm-tb-no-tdborder')) {
                            //设置偶数行tr的样式
                            if ((iTr + 1) % 2 === 0) {
                                thisTrObj.removeClass('even').addClass('even');
                            } else {
                                thisTrObj.removeClass('even');
                            }
                        }

                        //当前tr中td的数量
                        var thisTdCount = 0;
                        thisTrObjTd.each(function (iTd) {
                            thisTdCount++;
                        });

                        thisTrObjTd.each(function (iTd) {
                            var thisTdObj = $(this);
                            if ((iTd + 1) % 2 === 0) {
                                thisTdObj.removeClass('content').addClass('content');
                            } else {
                                thisTdObj.removeClass('title').addClass('title');
                            }

                            if (!frmObj.hasClass('frm-tb-no-tdborder')) {
                                if (iTd + 1 === 1 && (iTr + 1) % 2 === 0) {
                                    var lineIndex = Math.floor((Math.random() * tdLineStyle.length));
                                    thisTdObj.removeClass('line-' + tdLineStyle[lineIndex]).addClass('line-' + tdLineStyle[lineIndex]);
                                }
                            }
                        });

                    });
                });
            },
            setFrmValid: function () {
                /*******************************************
                说明：设置文本框失去焦点后进行验证
                ********************************************/
                $('.validatebox-text').bind('blur', function () {
                    $(this).validatebox('enableValidation').validatebox('validate');
                });
            }
        },
        getWin: function (type) {
            /*******************************************
            说明：获取操作窗体对象（Easyui Tab中当前操作的窗体）
                    type：不传递或则为空，则表示获取Easyui Tab中当前操作的窗体；
                              传递为lay时，则表示layer弹出多层（至少2层）窗体时，获取最顶层的下一层窗体对象
            ********************************************/
            var curWin = null;

            if (type === 'lay') {//lay
                var layObj = null,
                         times = [],
                         objs = parent.$('div[type=iframe]');

                objs.each(function (i) {
                    times[i] = $(this).attr('times');
                });

                if (times.length === 1) {
                    layObj = parent.$('#layui-layer' + times[0]);
                } else if (times.length > 1) {
                    layObj = parent.$('#layui-layer' + times[times.length - 2]);
                }

                if (layObj && layObj.find('iframe').length > 0) {
                    curWin = layObj.find('iframe')[0].contentWindow;
                }
            } else {//Easyui Tab
                //var curTab = parent.$('#main-center').tabs('getSelected');                
                var curTab = parent.$("div#tabs div.tab-content div.active");
                if (curTab && curTab.find('iframe').length > 0) {
                    curWin = curTab.find('iframe')[0].contentWindow;
                }
            }

            return curWin;
        },
        getTopWin: function () {
            /*******************************************
            说明：获取最顶层页面对象
            ********************************************/
            //return window.top;
            //if ((window !== null) && window.hasOwnProperty('self')) {
            var obj = window.self;
            while (true) {
                if (obj.document.getElementById(thisTopTag)) {
                    return obj;
                }
                obj = obj.window.parent;
            }
            //}
        },
        openWin: function (url, obj) {
            /*******************************************
            说明：弹出窗体
                    url：窗体页面地址
                    obj：{title:'',icon:'home',width:800,height:400,shift:0,cancelCallback:function(){}}
                        title：窗体标题（可不填，默认为空）
                        icon：窗体左上角图标名称（可不填，默认为th-large）
                        width：窗体宽度（可不填，默认为800px）
                        height：窗体高度（可不填，默认为400px）
                        shift：窗体出现的动画效果（可不填，默认为0）
                        isFull：是否全屏（默认为false）
            ********************************************/
            url = QBO.com.getObj(url, 'str');
            obj = QBO.com.getObj(obj);

            obj.title = QBO.com.getObj(obj.title, 'str', '&nbsp;');
            obj.icon = QBO.com.getObj(obj.icon, 'str', 'th-large');
            obj.width = QBO.com.getObj(obj.width, 'num', 800);
            obj.height = QBO.com.getObj(obj.height, 'num', 400);
            obj.shift = QBO.com.getObj(obj.shift, 'num', 0);
            obj.isFull = QBO.com.getObj(obj.isFull, 'bool', false);

            var thisIndex = parent.layer.open({
                type: 2, skin: 'layer-ext-moon', fix: true, maxmin: true, moveType: 1, scrollbar: false,
                title: obj.title, winIcon: obj.icon.length <= 0 ? 'th-large' : obj.icon, shift: obj.shift, content: url,
                area: [obj.width + 'px', obj.height + 'px'],
                cancel: function (index) {
                    if (typeof (obj.cancelCallback) == 'function') { obj.cancelCallback(); }
                }
            });
            if (obj.isFull) {
                parent.layer.full(thisIndex);
            }
        },
        closeWin: function (cancelCallback) {
            /*******************************************
            说明：关闭当前打开的窗体
                cancelCallback：关闭窗体后的回调函数
            ********************************************/
            if (typeof (cancelCallback) == 'function') { cancelCallback(); }

            var index = parent.layer.getFrameIndex(window.name);//获取窗口索引
            parent.layer.close(index);
        }
    },
    dia: {//对话框
        tip: function (content, obj) {
            /*******************************************
            说明：出现有确认按钮的消息提示框
                    content：消息内容
                    obj：{title:'',icon:'',yesCallback:function(){},endCallback:function(){}}
                        title：提示标题（可不填，默认为提示信息）
                        icon：图标（可不填，默认不显示[hide：不显示、info、right、error、question、lock、sad、smile、cloud]）
                        yesCallback：点击确定后的回调函数
                        endCallback：窗体销毁后的回调函数
            ********************************************/
            QBO.dia.tipPri('alert', content, obj);
        },
        confirm: function (content, yesCallback, cancelCallback) {
            var obj = {
                icon: 'question',
                yesCallback: yesCallback,
                cancelCallback: cancelCallback
            };

            QBO.dia.tipPri('confirm', content, obj);
        },
        tipPri: function (type, content, obj) {
            /*******************************************
            说明：出现的消息提示框
                    type：alert、confirm
                    content：消息内容
                    obj：{title:'',icon:'',yesCallback:function(){},cancelCallback:function(){}}
                        title：提示标题（可不填，默认为提示信息）
                        icon：图标（可不填，默认不显示[hide：不显示、info、right、error、question、lock、sad、smile、cloud]）
                        yesCallback：点击确定后的回调函数
                        cancelCallback：点击取消或关闭后的回调函数
            ********************************************/
            var thisIcon = obj;//如果obj为string类型，则表示icon的类型

            content = QBO.com.getObj(content, 'str');
            obj = QBO.com.getObj(obj);

            obj.title = QBO.com.getObj(obj.title, 'str', '提示信息');
            obj.icon = thisIcon != undefined && typeof (thisIcon) === 'string' && thisIcon.length > 0 ? thisIcon : QBO.com.getObj(obj.icon, 'str', 'hide');

            obj.icon = obj.icon === 'hide' ? -1 :
                obj.icon === 'info' ? 0 :
                obj.icon === 'right' ? 1 :
                obj.icon === 'error' ? 2 :
                obj.icon === 'question' ? 3 :
                obj.icon === 'lock' ? 4 :
                obj.icon === 'sad' ? 5 :
                obj.icon === 'smile' ? 6 : 7;

            if (type === 'alert') {
                parent.layer.alert(content, {
                    title: obj.title,
                    icon: obj.icon,
                    skin: 'layer-ext-moon', moveType: 1,
                    yes: function (index) {
                        if (typeof (obj.yesCallback) == 'function') { obj.yesCallback(); }
                        parent.layer.close(index);
                    },
                    cancel: function (index) {
                        if (typeof (obj.cancelCallback) == 'function') { obj.cancelCallback(); }
                    }
                });
            } else {
                parent.layer.confirm(content, {
                    title: obj.title,
                    icon: obj.icon,
                    skin: 'layer-ext-moon', moveType: 1
                }, function (index) {
                    if (typeof (obj.yesCallback) == 'function') { obj.yesCallback(); }
                    parent.layer.close(index);
                }, function (index) {
                    if (typeof (obj.cancelCallback) == 'function') { obj.cancelCallback(); }
                });
            }
        },
        msg: function (content, obj) {
            /*******************************************
            说明：出现的简单消息弹出层
                    content：消息内容
                    obj：{time:1500,endCallback:function(){},shift:0,icon:'right'}
                        time：窗体显示时间（默认1500毫秒）
                        endCallback：窗体显示完毕后的回调函数
                        shift：出现的动画方式：0-6可选择，默认0
                        icon：图标（可不填，默认不显示[hide：不显示、info、right、error、question、lock、sad、smile、cloud]）
            ********************************************/
            var thisIcon = obj;//如果obj为string类型，则表示icon的类型

            content = QBO.com.getObj(content, 'str');
            obj = QBO.com.getObj(obj);

            obj.time = QBO.com.getObj(obj.time, 'num', 1500);
            obj.shift = QBO.com.getObj(obj.shift, 'num', 0);
            obj.shift = QBO.com.getObj(obj.shift, 'num', 0);
            obj.icon = thisIcon != undefined && typeof (thisIcon) === 'string' && thisIcon.length > 0 ? thisIcon : QBO.com.getObj(obj.icon, 'str', 'hide');

            obj.icon = obj.icon === 'hide' ? -1 :
                obj.icon === 'info' ? 0 :
                obj.icon === 'right' ? 1 :
                obj.icon === 'error' ? 2 :
                obj.icon === 'question' ? 3 :
                obj.icon === 'lock' ? 4 :
                obj.icon === 'sad' ? 5 :
                obj.icon === 'smile' ? 6 : 7;

            parent.layer.msg(content, {
                offset: 'auto',//出现的位置（auto：水平垂直居中，'100px'：顶部100px，['100px','200px']：水平居左100px、顶部200px）
                shift: obj.shift, icon: obj.icon,
                time: obj.time,
                shade: [0.1, '#393D49']
            }, function () {
                if (typeof (obj.endCallback) == 'function') { obj.endCallback(); }
            });
        },
        load: function (icon) {
            /*******************************************
            说明：load加载层
                    icon：图标（可不填，默认为0，0或1可选择）
            ********************************************/
            var clientH = QBO.frm.getTopWin().document.body.clientHeight;
            clientH = clientH > 25 ? (clientH - 25) / 2 : 0;

            icon = QBO.com.getObj(icon, 'num', 0);
            var index = QBO.frm.getTopWin().layer.load(icon, {
                //content:'加载中...',
                shade: [0.1, '#000'],
                offset: clientH + 'px'
            });
            //icon = QBO.com.getObj(icon, 'num', 0);
            //var index = parent.layer.load(icon, {
            //    shade: [0.1, '#000']
            //});
            return index;
        },
        loadClose: function (index) {
            /*******************************************
            说明：关闭load加载层
                    index：加载曾的索引
            ********************************************/
            index = index == undefined ? QBO.dia.load() : index;
            QBO.frm.getTopWin().layer.close(index);
            //index = index == undefined ? 0 : index;
            //parent.layer.close(index);
        },
        notice: function (contentOrUrl, obj) {
            /*******************************************
            说明：右下角通知窗体
                    contentOrUrl：窗体内容或窗体地址
                    obj：{title:'',noticeType:1,width:300,height:200,time:5000,shift:2,endCallback:function(){}}
                        title：标题（可不填，默认为空）
                        noticeType：窗体类型（1：url地址--默认，2：文本内容）
                        width：窗体宽度（默认为300px）
                        height：窗体高度（默认为200px）
                        time：窗体显示时间（默认5000毫秒）
                        shift：出现的动画方式：0-6可选择，默认4
                        endCallback：窗体显示完毕后的回调函数
            ********************************************/
            obj = QBO.com.getObj(obj);
            contentOrUrl = QBO.com.getObj(contentOrUrl, 'str');

            if (contentOrUrl == undefined || contentOrUrl.length <= 0) {
                return;
            }

            obj.title = QBO.com.getObj(obj.title, 'str', '&nbsp;');
            obj.noticeType = QBO.com.getObj(obj.noticeType, 'num', 1);
            obj.width = QBO.com.getObj(obj.width, 'num', 300);
            obj.height = QBO.com.getObj(obj.height, 'num', 200);
            obj.time = QBO.com.getObj(obj.time, 'num', 5000);
            obj.shift = QBO.com.getObj(obj.shift, 'num', 2);

            parent.layer.open({
                type: obj.noticeType === 1 ? 2 : 1,
                title: obj.title,
                area: [obj.width + 'px', obj.height + 'px'],
                content: contentOrUrl,
                time: obj.time,
                shade: false,
                offset: 'rb',
                shift: obj.shift,
                end: function () {
                    if (typeof (obj.endCallback) == 'function') {
                        obj.endCallback();
                    }
                }
            });
        }
    }
};

//用于Mvc参数适配JavaScript闭包函数
var mvcParamMatch = (function () {
    var mvcParameterAdaptive = {};

    //验证是否为数组
    mvcParameterAdaptive.isArray = Function.isArray || function (o) {
        return typeof (o) === "object" && Object.prototype.toString.call(o) === "[object Array]";
    };

    //将数组转换为对象
    mvcParameterAdaptive.convertArrayToObject = function (arrName, array, saveOjb) {
        /*
            arrName：数组名
            array：待转换的数组
            saveObj：转换后存放的对象，不用输入
        */
        var obj = saveOjb || {};

        function func(name, arr) {
            for (var i in arr) {
                if (!mvcParameterAdaptive.isArray(arr[i]) && typeof (arr[i]) === 'object') {
                    for (var j in arr[i]) {
                        if (mvcParameterAdaptive.isArray(arr[i][j])) {
                            func(name + '[' + i + '].' + j, arr[i][j]);
                        } else if (typeof (arr[i][j]) === 'object') {
                            mvcParameterAdaptive.convertObject(name + '[' + i + '].' + j + '.', arr[i][j], obj);
                        } else {
                            obj[name + '[' + i + '].' + j] = arr[i][j];
                        }
                    }
                } else {
                    obj[name + '[' + i + ']'] = arr[i];
                }
            }
        }

        func(arrName, array);

        return obj;
    };

    //转换对象
    mvcParameterAdaptive.convertObject = function (objName, turnObj, saveOjb) {
        /*
            objName：对象名
            turnObj：待转换的对象
            saveObj：转换后存放的对象，不用输入
        */
        var obj = saveOjb || {};

        function func(name, tobj) {
            for (var i in tobj) {
                if (tobj.hasOwnProperty(i)) {
                    if (mvcParameterAdaptive.isArray(tobj[i])) {
                        mvcParameterAdaptive.convertArrayToObject(i, tobj[i], obj);
                    } else if (typeof (tobj[i]) === 'object') {
                        func(name + i + '.', tobj[i]);
                    } else {
                        obj[name + i] = tobj[i];
                    }
                }
            }
        }

        func(objName, turnObj);
        return obj;
    };

    return function (json, arrName) {
        arrName = arrName || '';
        if (typeof (json) !== 'object') {
            QBO.dia.tip('请传入json对象！', 'error');
            console.log('请传入json对象！json：' + json + ' - arrName：' + arrName);
            throw new Error('请传入json对象！');
        }
        if (mvcParameterAdaptive.isArray(json) && !arrName) {
            QBO.dia.tip('请传入json对象请指定数组名，对应Action中数组参数名称！', 'error');
            console.log('请传入json对象！json：' + json + ' - arrName：' + arrName);
            throw new Error('请指定数组名，对应Action中数组参数名称！');
        }

        if (mvcParameterAdaptive.isArray(json)) {
            return mvcParameterAdaptive.convertArrayToObject(arrName, json);
        }
        return mvcParameterAdaptive.convertObject('', json);
    };
})();

//图片跟随鼠标移动预览插件
//用法： $("span.eui-opt-acc").imgPreview();   标签上使用data-img来设置预览图片的地址
(function ($) {
    $.fn.imgPreview = function () {
        var xOffset = 10;
        var yOffset = 20;
        var w = $(window).width();
        $(this).each(function () {
            $(this).hover(function (e) {
                if (/.png$|.gif$|.jpg$|.bmp$/.test($(this).data("img"))) {
                    $("body").append("<div id='imgPreview'><div><img src='" + $(this).data('img') + "' /></div></div>");
                } else {
                    //$("body").append("<div id='imgPreview'><div><p>" + $(this).attr('title') + "</p></div></div>");
                }
                $("#imgPreview").css({
                    position: "absolute",
                    padding: "4px",
                    border: "1px solid #f3f3f3",
                    backgroundColor: "#eeeeee",
                    top: (e.pageY - yOffset) + "px",
                    zIndex: 1000,
                    boxShadow: '5px 5px 5px #dcdcdc'
                });
                $("#imgPreview > div").css({
                    padding: "0",
                    backgroundColor: "#fff",
                    border: "1px solid #ccc"
                });
                $("#imgPreview > div > p").css({
                    textAlign: "center",
                    fontSize: "12px",
                    padding: "8px 0 3px",
                    margin: "0"
                });
                if (e.pageX < w / 2) {
                    $("#imgPreview").css({
                        left: e.pageX + xOffset + "px",
                        right: "auto"
                    }).fadeIn("fast");
                } else {
                    $("#imgPreview").css("right", (w - e.pageX + yOffset) + "px").css("left", "auto").fadeIn("fast");
                }
            }, function () {
                $("#imgPreview").remove();
            }).mousemove(function (e) {
                $("#imgPreview").css("top", (e.pageY - xOffset) + "px");
                if (e.pageX < w / 2) {
                    $("#imgPreview").css("left", (e.pageX + yOffset) + "px").css("right", "auto");
                } else {
                    $("#imgPreview").css("right", (w - e.pageX + yOffset) + "px").css("left", "auto");
                }
            });
        });
    };
})(jQuery);

//初始化函数
$(function () {
    QBO.frm.init.initFun();
});

//顶部页面topTag标签Id名称
var thisTopTag = QBO.com.getJsParam('base.core.js', 'topTag').length <= 0 ? 'topTag' : QBO.com.getJsParam('base.core.js', 'topTag');
