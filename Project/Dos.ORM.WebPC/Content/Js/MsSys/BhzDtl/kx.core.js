/*****************************************************************************************************
 * 本代码版权归科信所有，All Rights Reserved (C) 2015-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 创建人：Quber
 * 创建说明：公用js方法核心库
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

var KXC = {
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
            chkboxType: { 'Y': 'p', 'N': 's' }
            /*
                Y：勾选后的动作
                N：取消勾选后的动作
                Y和N的值：p影响父级、s影响子级、ps影响父级和子级
            */
        },
        view: {
            fontCss: {},
            nameIsHTML: true,
            expandSpeed: 'fast', //"slow", "normal", "fast", "",1000
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
    easyUi: {
        grid: {
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
            pageSize: 15,//每页数量
            pageNumber: 1,//默认显示第几页
            pageList: [1, 5, 10, 15, 20, 30, 40, 50, 100, 500, 1000]//分页中下拉选项的数值
        }
    },
    uploadify: {
        width: 76, height: 26,
        fileObjName: 'fileDataObj',//文件对象名称，用于服务器端获取文件
        queueID: 'uploadfileQueue',//显示上传文件队列的元素id，可以简单用一个div显示
        swf: '../Plugins/Uploadify/uploadify.swf',//[必须设置]swf的路径
        uploader: '../Handler/UploadImgHandler.ashx',//[必须设置]服务器端脚本文件路径
        fileUploader: '../Handler/UploadFileHandler.ashx',//[必须设置]服务器端脚本文件路径
        fileUper: '../Handler/UploadFileConHandler.ashx',//[必须设置]服务器端脚本文件路径
        //buttonImage: '/Content/Plugins/Uploadify/browse-btn.png',//上传按钮背景图片
        uploadLimit: 200,//最多上传文件数量
        queueSizeLimit: 200,//上传文件队列长度限制
        fileSizeLimit: '100MB',//上传文件大小限制，默认单位是KB，如：”10KB”
        auto: false,//表示在选择文件后是否自动上传
        multi: false,//是否支持多文件上传
        buttonClass: '',//上传按钮样式类型
        buttonText: '选择文件',//上传按钮显示文字
        fileTypeDesc: '',//文件类型说明，在选择文件时可以看到
        fileTypeExts: '*.gif;*.jpg;*.jpeg;*.png;*.bmp;',//指定允许上传的文件类型，如：”*.jpg;*.gif”
        formData: {},//指定上传文件附带的其他数据，用于服务器端获取这些数据，如：{“id”:”001”,”name”:”LiJin”}包含两个键值对
        method: 'POST',//和后台交互方式，也可以设置为get
        progressData: 'percentage',//设置文件上传时显示的数据，可以设为上传速度或者百分比，分别对应speed和percentage
        removeCompleted: false,//表示上传文件完成后是否删除队列中的对应元素
        removeTimeout: 2,//表示上传完成后多久删除队列中的进度条，单位为秒
        requeueErrors: false,//若设置为true，那么在上传过程中因为出错导致上传失败的文件将重新加入队列
        successTimeout: 20//表示文件上传完成后等待服务器响应的时间。超过该时间，那么将认为上传成功。单位为秒
    }
};

var KXO = {
    com: {//公用方法或事件
        arrGroup: function (array, size) {
            /*******************************************
            说明：将数组按几个对象分为一组
                array：数组对象
                size：分组大小
            ********************************************/
            var result = [];
            for (var x = 0; x < Math.ceil(array.length / size) ; x++) {
                var start = x * size;
                var end = start + size;
                result.push(array.slice(start, end));
            }
            return result;
        },
        trim: function (str) {
            /*******************************************
            说明：去除字符串前后的空格
                    str：字符串
            ********************************************/
            return str.replace(/^(\s|\u00A0)+/, '').replace(/(\s|\u00A0)+$/, '');
        },
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
        delJsonKey: function (jsonObj, delKeys) {
            /*******************************************
            说明：删除Json对象中指定的key
                    jsonObj：Json对象
                    delKeys：删除的key数组（如：['id','name','count']）
            ********************************************/
            for (var i = 0; i < delKeys.length; i++) {
                if (delKeys[i].length > 0)
                    delete jsonObj[delKeys[i]];
            }
            return jsonObj;
        },
        convertCurrency: function (money) {
            /*******************************************
            说明：将数字金额转换为大写的人民币汉字
                    money：数字金额
            ********************************************/
            //汉字的数字
            var cnNums = new Array('零', '壹', '贰', '叁', '肆', '伍', '陆', '柒', '捌', '玖');
            //基本单位
            var cnIntRadice = new Array('', '拾', '佰', '仟');
            //对应整数部分扩展单位
            var cnIntUnits = new Array('', '万', '亿', '兆');
            //对应小数部分单位
            var cnDecUnits = new Array('角', '分', '毫', '厘');
            //整数金额时后面跟的字符
            var cnInteger = '整';
            //整型完以后的单位
            var cnIntLast = '元';
            //最大处理的数字
            var maxNum = 999999999999999.9999;
            //金额整数部分
            var integerNum;
            //金额小数部分
            var decimalNum;
            //输出的中文金额字符串
            var chineseStr = '';
            //分离金额后用的数组，预定义
            var parts;

            if (money == '') { return ''; }

            money = parseFloat(money);
            if (money >= maxNum) {
                //超出最大处理数字
                return '';
            }
            if (money == 0) {
                chineseStr = cnNums[0] + cnIntLast + cnInteger;
                return chineseStr;
            }

            //转换为字符串
            money = money.toString();
            if (money.indexOf('.') == -1) {
                integerNum = money;
                decimalNum = '';
            } else {
                parts = money.split('.');
                integerNum = parts[0];
                decimalNum = parts[1].substr(0, 4);
            }

            //获取整型部分转换
            if (parseInt(integerNum, 10) > 0) {
                var zeroCount = 0;
                var IntLen = integerNum.length;
                for (var i = 0; i < IntLen; i++) {
                    var n = integerNum.substr(i, 1);
                    var p = IntLen - i - 1;
                    var q = p / 4;
                    var m = p % 4;
                    if (n == '0') {
                        zeroCount++;
                    } else {
                        if (zeroCount > 0) {
                            chineseStr += cnNums[0];
                        }
                        //归零
                        zeroCount = 0;
                        chineseStr += cnNums[parseInt(n)] + cnIntRadice[m];
                    }
                    if (m == 0 && zeroCount < 4) {
                        chineseStr += cnIntUnits[q];
                    }
                }
                chineseStr += cnIntLast;
            }

            //小数部分
            if (decimalNum != '') {
                var decLen = decimalNum.length;
                for (var i = 0; i < decLen; i++) {
                    var n = decimalNum.substr(i, 1);
                    if (n != '0') {
                        chineseStr += cnNums[Number(n)] + cnDecUnits[i];
                    }
                }
            }

            if (chineseStr == '') {
                chineseStr += cnNums[0] + cnIntLast + cnInteger;
            } else if (decimalNum == '') {
                chineseStr += cnInteger;
            }

            return chineseStr;
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
        toUtf8: function (str) {
            /*******************************************
            说明：将汉字转换为UTF-8
                    str：需要转换的字符串
            ********************************************/
            var out, i, c;

            out = '';
            var len = str.length;
            for (i = 0; i < len; i++) {
                c = str.charCodeAt(i);
                if ((c >= 0x0001) && (c <= 0x007F)) {
                    out += str.charAt(i);
                } else if (c > 0x07FF) {
                    out += String.fromCharCode(0xE0 | ((c >> 12) & 0x0F));
                    out += String.fromCharCode(0x80 | ((c >> 6) & 0x3F));
                    out += String.fromCharCode(0x80 | ((c >> 0) & 0x3F));
                } else {
                    out += String.fromCharCode(0xC0 | ((c >> 6) & 0x1F));
                    out += String.fromCharCode(0x80 | ((c >> 0) & 0x3F));
                }
            }
            return out;
        },
        toUtf16: function (str) {
            /*******************************************
            说明：将汉字转换为UTF-16
                    str：需要转换的字符串
            ********************************************/
            var out, i, c;
            var char2, char3;

            out = '';
            var len = str.length;
            i = 0;
            while (i < len) {
                c = str.charCodeAt(i++);
                switch (c >> 4) {
                    case 0: case 1: case 2: case 3: case 4: case 5: case 6: case 7:
                        // 0xxxxxxx
                        out += str.charAt(i - 1);
                        break;
                    case 12: case 13:
                        // 110x xxxx   10xx xxxx
                        char2 = str.charCodeAt(i++);
                        out += String.fromCharCode(((c & 0x1F) << 6) | (char2 & 0x3F));
                        break;
                    case 14:
                        // 1110 xxxx  10xx xxxx  10xx xxxx
                        char2 = str.charCodeAt(i++);
                        char3 = str.charCodeAt(i++);
                        out += String.fromCharCode(((c & 0x0F) << 12) |
                                       ((char2 & 0x3F) << 6) |
                                       ((char3 & 0x3F) << 0));
                        break;
                }
            }

            return out;
        },
        canvasToImg: function (canvasElem, fileName, imageType) {
            /*******************************************
            说明：将Canvas转换为图片
                    fileName：保存为图片的名称
                    imageType：图片格式（默认为png）
            ********************************************/
            var defalutImageType = 'png';
            //将canvas元素转化为image data
            var imageData = canvasElem.toDataURL(imageType || defalutImageType);
            var saveLink = document.createElementNS('http://www.w3.org/1999/xhtml', 'a');
            saveLink.href = imageData;
            saveLink.download = fileName;
            var event = document.createEvent('MouseEvents');
            event.initMouseEvent('click', true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);
            saveLink.dispatchEvent(event);
        },
        disableBroFor: function () {
            /*******************************************
            说明：禁用浏览器回退按钮
            ********************************************/
            try {
                var counter = 0;
                if (window.history && window.history.pushState) {
                    $(window).on('popstate', function () {
                        window.history.pushState('forward', null, '');
                        window.history.forward(1);
                        //console.log("第" + (++counter) + "次单击后退按钮。");
                    });
                }

                //在IE中必须得有这两行
                window.history.pushState('forward', null, '');
                window.history.forward(1);
            } catch (e) {

            }
        },
        convertUrlParam: function (str) {
            /*******************************************
            说明：对url参数中含有的特殊字符进行转码 
             +	   空格	/	 ?	  % 	& 	  =  	#
             %2B   %20	%2F	 %3F  %25	%26	  &3D	%23
            ********************************************/
            str = str.replace(/\%/g, "%26");
            str = str.replace(/\ /g, "%20");
            str = str.replace(/\+/g, "%2B");
            str = str.replace(/\//g, "%2F");
            str = str.replace(/\?/g, "%3F");
            str = str.replace(/\=/g, "%3D");
            str = str.replace(/\#/g, "%23");
            return str;
        }
    },
    plu: {//插件方法或事件
        ajax: function (obj, sucCallback) {
            /*******************************************
            说明：ajax请求封装
                    obj：{
                                type：'POST',//请求方式GET或POST（可不填，默认为POST）
                                chkLogin： true,//请求数据之前是否检查已经登录（可不填，默认为true）
                                chkLoginPathQz： ../../,//检测登录时的相对路径前缀
                                async： true,//是否为异步请求（可不填，默认为true）
                                isLoad：false,//是否显示等待效果（加载层，可不填，默认为true）
                                loadType：1,//加载层类型（可不填，默认为1[layer]，2为easyui加载层效果）
                                doType：'modify',//操作类型（可不填，默认提示文字为‘操作’，delete/del：删除、add/modify：保存、其他：操作）
                                url：'GetStaffData.ashx',//服务请求地址（必填，为相对路径）
                                data：{ PageIndex: 1, PageSize: 20 }//请求参数（可不填）
                            }
                    sucCallback：请求成功后的回调函数
            ********************************************/
            obj.type = KXO.com.getObj(obj.type, 'str', 'POST');
            obj.chkLogin = KXO.com.getObj(obj.chkLogin, 'bool', true);
            obj.chkLoginPathQz = KXO.com.getObj(obj.chkLoginPathQz, 'str', '../../');
            obj.async = KXO.com.getObj(obj.async, 'bool', true);
            obj.isLoad = KXO.com.getObj(obj.isLoad, 'bool', false);
            obj.loadType = KXO.com.getObj(obj.loadType, 'num', 1);
            obj.data = KXO.com.getObj(obj.data);
            obj.doType = obj.doType === 'del' || obj.doType === 'delete' ? '删除' :
                obj.doType === 'add' || obj.doType === 'insert' || obj.doType === 'modify' || obj.doType === 'update' ? '保存' : '操作';

            if (obj.chkLogin) {
                KXO.plu.ajaxPri({
                    url: obj.chkLoginPathQz + 'Content/Handler/Common.ashx',
                    chkLogin: false,
                    data: { action: 'GetUserInfo' }
                }, function (data) {
                    if (data.Result == 120) {
                        KXO.dia.msg(data.Msg, {
                            icon: 'error',
                            endCallback: function () {
                                //KXO.frm.getTopWin().window.location.href = '../../Login.aspx';
                            }
                        });

                        //跳转至登陆页
                        setTimeout(function () {
                            KXO.frm.getTopWin().window.location.href = '../../Login.aspx';
                        }, 1500);
                    } else {
                        KXO.plu.ajaxPri(obj, sucCallback);
                    }
                    //console.log(JSON.stringify(data));
                });
            } else {
                KXO.plu.ajaxPri(obj, sucCallback);
            }
        },
        ajaxPri: function (obj, sucCallback) {
            if (obj.url == undefined) {
                KXO.dia.tip('数据操作异常：请求地址为空，请检查！', 'error');
                //console.log('数据操作异常：请求地址为空，请检查！' + JSON.stringify(obj));
                return;
            }
            var loadIndex = 0;
            $.ajax({
                type: obj.type, async: obj.async, url: obj.url, data: obj.data,
                dataType: 'json',
                traditional: true,//使用传统方法序列化数据
                //contentType: 'application/json',
                beforeSend: function () {
                    if (obj.isLoad) {
                        if (obj.loadType === 1) {
                            loadIndex = KXO.dia.load();
                        } else {
                            parent.$.messager.progress({ text: '数据' + obj.doType + '中，请稍后...' });
                        }
                    }
                },
                complete: function () {
                    if (obj.isLoad) {
                        if (obj.loadType === 1) {
                            KXO.dia.loadClose(loadIndex);
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
                    //KXO.dia.tip('数据' + obj.doType + '失败，请稍后再试！', 'error');
                    //var errorObj = { status: msg.status, obj: obj };
                    //console.log('数据' + obj.doType + '失败，请稍后再试！' + JSON.stringify(errorObj));
                    return;
                }
            });
        },
        cookie: {//jQuery cookie
            set: function (key, val) {
                /*******************************************
                说明：设置cookie
                        key：cookie key
                        val：cookie value
                ********************************************/
                if (key != undefined && val != undefined && key.length > 0) {
                    $.cookie(key, val);
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
                editorId = KXO.com.getObj(editorId, 'str', 'editor');

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
        zt: {//zTree
            init: function (zTreeId, zTreeData, obj) {
                /*******************************************
                说明：初始化zTree
                        zTreeId：zTree容器Id
                        zTreeData：数据集和
                        obj：{check:true,isCheckbox:true,onClick:null,onCheck:null,fontCss:{},chkboxTypeY:'',chkboxTypeN:''}
                            check：是否有复选框或单选框（可不填，默认为false）
                            isCheckbox：是否为checkbox，否则为radio（前提是check为true才起作用）
                            onClick：节点点击回调函数（返回三个参数event, treeId, treeNode）
                            onCheck：节点勾选回调函数（返回三个参数event, treeId, treeNode）
                            fontCss：节点样式（Json对象或function）
                            keyName: '类型',//显示的字段名称，默认为name
                            keyId: '代码',//显示的数据ID字段名称，默认为id
                            keyPid: '专业代码',//显示的数据父ID字段名称，默认为pId
                            showIcon：是否显示节点图标（可不填，默认为true）
                            chkboxTypeY：勾选后的动作，p影响父级、s影响子级、ps影响父级和子级
                            chkboxTypeN：取消勾选后的动作，p影响父级、s影响子级、ps影响父级和子级
                            showTitle：是否显示title属性（默认为false）
                ********************************************/
                obj.keyName = KXO.com.getObj(obj.keyName, 'str', 'name');
                obj.keyId = KXO.com.getObj(obj.keyId, 'str', 'id');
                obj.keyPid = KXO.com.getObj(obj.keyPid, 'str', 'pId');

                var chkboxType = {
                    'Y': obj.chkboxTypeY == undefined || (obj.chkboxTypeY !== 'p' && obj.chkboxTypeY !== 's' && obj.chkboxTypeY !== 'ps') ? 'p' : obj.chkboxTypeY,
                    'N': obj.chkboxTypeN == undefined || (obj.chkboxTypeN !== 'p' && obj.chkboxTypeN !== 's' && obj.chkboxTypeN !== 'ps') ? 's' : obj.chkboxTypeN
                };
                var zTreeSetting = KXC.zTree;

                zTreeSetting.data.key.name = obj.keyName;
                zTreeSetting.data.simpleData.idKey = obj.keyId;
                zTreeSetting.data.simpleData.pIdKey = obj.keyPid;

                //设置影响级别
                zTreeSetting.check.chkboxType = chkboxType;
                zTreeSetting.check.enable = obj.check == undefined || !obj.check ? false : true;
                zTreeSetting.check.chkStyle = obj.isCheckbox == undefined || obj.isCheckbox ? 'checkbox' : 'radio';
                zTreeSetting.view.showIcon = obj.showIcon == undefined || typeof (obj.showIcon) != 'boolean' ? true : obj.showIcon;
                zTreeSetting.view.showTitle = obj.showTitle == undefined || typeof (obj.showTitle) != 'boolean' ? false : obj.showTitle;
                zTreeSetting.view.fontCss = obj.fontCss == undefined && typeof (obj.fontCss) != 'function' && typeof (obj.fontCss) != 'object' ? {} : obj.fontCss;
                zTreeSetting.view.selectedMulti = obj.check == undefined || !obj.check || zTreeSetting.check.chkStyle === 'radio' ? false : true;
                //设置节点点击事件
                zTreeSetting.callback.onClick = function (event, treeId, treeNode) {
                    KXO.plu.zt.doClick('onClick', event, treeId, treeNode, zTreeSetting);
                    if (typeof (obj.onClick) == 'function') { obj.onClick(event, treeId, treeNode); }
                    if (typeof (obj.onCheck) == 'function') { obj.onCheck(event, treeId, treeNode); }
                };
                //设置节点勾选事件
                zTreeSetting.callback.onCheck = function (event, treeId, treeNode) {
                    KXO.plu.zt.doClick('onCheck', event, treeId, treeNode, zTreeSetting);
                    if (typeof (obj.onCheck) == 'function') { obj.onCheck(event, treeId, treeNode); }
                };
                //初始化zTree
                $.fn.zTree.init($('#' + zTreeId), zTreeSetting, zTreeData);
                //展开和设置节点勾选选中状态
                KXO.plu.zt.openChkedNode(zTreeData, zTreeId, zTreeSetting);
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
                    //console.log('error：获取zTree勾选节点时未传递Id');
                } else {
                    isGetChecked = isGetChecked == undefined || isGetChecked ? true : false;
                    isGetCheckedTrue = isGetCheckedTrue == undefined || isGetCheckedTrue ? true : false;
                    var treeObj = $.fn.zTree.getZTreeObj(zTreeId),
                        nodes = isGetChecked ? treeObj.getCheckedNodes(isGetCheckedTrue) : treeObj.getSelectedNodes();
                    for (var i = 0; i < nodes.length; i++) {
                        ret.arr[i] = nodes[i].id;
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
                            isSimplePager：是否显示简单分页（默认为false）

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
                var thisQueryParams = KXO.com.getObj(dgOpts.queryParams);
                //此参数用于传递给MsSysController控制器的OnAuthorization方法，便于返回不同的数据对象
                thisQueryParams.requestObj = 'EasyUI-DG';

                dgOpts.isSimplePager = KXO.com.getObj(dgOpts.isSimplePager, 'bool', false);
                var simplePager = dgOpts.isSimplePager ? ['first', 'prev', 'links', 'next', 'last'] : [];

                type = type == undefined || type.length <= 0 ? 'dg' : type;
                if (type === 'dg') {
                    dgObj.datagrid({
                        border: KXC.easyUi.grid.border,
                        fit: false,//KXC.easyUi.grid.fit,
                        //注意此处，如果设置了冻结的列，那么fitColumns就该设置为false，否则设置冻结列将失效
                        fitColumns: dgOpts.colFro && dgOpts.colFro != undefined && dgOpts.colFro.length > 0 ? false : KXC.easyUi.grid.fitColumns,
                        striped: KXC.easyUi.grid.striped,
                        method: KXC.easyUi.grid.method,
                        loadMsg: KXC.easyUi.grid.loadMsg,
                        rownumbers: KXC.easyUi.grid.rownumbers,
                        singleSelect: dgOpts.singleSelect == undefined || typeof (dgOpts.singleSelect) != 'boolean' ? KXC.easyUi.grid.singleSelect : dgOpts.singleSelect,
                        ctrlSelect: KXC.easyUi.grid.ctrlSelect,
                        pagination: dgOpts.pagination == undefined || typeof (dgOpts.pagination) != 'boolean' ? KXC.easyUi.grid.pagination : dgOpts.pagination,
                        pageSize: dgOpts.pageSize == undefined || typeof (dgOpts.pageSize) != 'number' ? KXC.easyUi.grid.pageSize : dgOpts.pageSize,
                        pageNumber: KXC.easyUi.grid.pageNumber,
                        pageList: KXC.easyUi.grid.pageList,
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
                        onLoadSuccess: function (data) {
                            //此处的-340来自MsSysController控制器的OnAuthorization方法
                            if (data.total === -340) {
                                KXO.dia.msg('登录已过期，请重新登录！', {
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
                        }
                    });
                    dgObj.datagrid('getPager').pagination({
                        beforePageText: '第',
                        afterPageText: '页&nbsp;共{pages}页',
                        displayMsg: '当前显示{from}-{to}条记录，共{total}条记录',
                        layout: simplePager
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
                        border: KXC.easyUi.grid.border,
                        destroyMsg: KXC.easyUi.grid.destroyMsg,
                        fit: KXC.easyUi.grid.fit,
                        //注意此处，如果设置了冻结的列，那么fitColumns就该设置为false，否则设置冻结列将失效
                        fitColumns: dgOpts.colFro && dgOpts.colFro != undefined && dgOpts.colFro.length > 0 ? false : KXC.easyUi.grid.fitColumns,
                        striped: KXC.easyUi.grid.striped,
                        method: KXC.easyUi.grid.method,
                        loadMsg: KXC.easyUi.grid.loadMsg,
                        rownumbers: KXC.easyUi.grid.rownumbers,
                        singleSelect: dgOpts.singleSelect == undefined || typeof (dgOpts.singleSelect) != 'boolean' ? KXC.easyUi.grid.singleSelect : dgOpts.singleSelect,
                        ctrlSelect: KXC.easyUi.grid.ctrlSelect,
                        pagination: dgOpts.pagination == undefined || typeof (dgOpts.pagination) != 'boolean' ? KXC.easyUi.grid.pagination : dgOpts.pagination,
                        pageSize: dgOpts.pageSize == undefined || typeof (dgOpts.pageSize) != 'number' ? KXC.easyUi.grid.pageSize : dgOpts.pageSize,
                        pageNumber: KXC.easyUi.grid.pageNumber,
                        pageList: KXC.easyUi.grid.pageList,
                        queryParams: thisQueryParams,
                        showFooter: dgOpts.showFooter == undefined || typeof (dgOpts.showFooter) != 'boolean' ? KXC.easyUi.grid.showFooter : dgOpts.showFooter,
                        autoSave: dgOpts.autoSave == undefined || typeof (dgOpts.autoSave) != 'boolean' ? KXC.easyUi.grid.autoSave : dgOpts.autoSave,

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
                        onLoadSuccess: function (data) {
                            //此处的-340来自MsSysController控制器的OnAuthorization方法
                            if (data.total === -340) {
                                KXO.dia.msg('登录已过期，请重新登录！', {
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
                        displayMsg: '当前显示{from}-{to}条记录，共{total}条记录',
                        layout: simplePager
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
                    dgObj.treegrid({
                        animate: KXC.easyUi.grid.animate,
                        border: KXC.easyUi.grid.border,
                        fit: KXC.easyUi.grid.fit,
                        //注意此处，如果设置了冻结的列，那么fitColumns就该设置为false，否则设置冻结列将失效
                        fitColumns: dgOpts.colFro && dgOpts.colFro != undefined && dgOpts.colFro.length > 0 ? false : KXC.easyUi.grid.fitColumns,
                        striped: KXC.easyUi.grid.striped,
                        method: KXC.easyUi.grid.method,
                        loadMsg: KXC.easyUi.grid.loadMsg,
                        rownumbers: KXC.easyUi.grid.rownumbers,
                        singleSelect: dgOpts.singleSelect == undefined || typeof (dgOpts.singleSelect) != 'boolean' ? KXC.easyUi.grid.singleSelect : dgOpts.singleSelect,
                        ctrlSelect: KXC.easyUi.grid.ctrlSelect,
                        pagination: dgOpts.pagination == undefined || typeof (dgOpts.pagination) != 'boolean' ? KXC.easyUi.grid.pagination : dgOpts.pagination,
                        pageSize: dgOpts.pageSize == undefined || typeof (dgOpts.pageSize) != 'number' ? KXC.easyUi.grid.pageSize : dgOpts.pageSize,
                        pageNumber: KXC.easyUi.grid.pageNumber,
                        pageList: KXC.easyUi.grid.pageList,
                        queryParams: thisQueryParams,

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
                        onLoadSuccess: function (row, data) {
                            //此处的-340来自MsSysController控制器的OnAuthorization方法
                            if (data.total === -340) {
                                KXO.dia.msg('登录已过期，请重新登录！', {
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
                        }
                    });
                    dgObj.treegrid('getPager').pagination({
                        beforePageText: '第',
                        afterPageText: '页&nbsp;共{pages}页',
                        displayMsg: '当前显示{from}-{to}条记录，共{total}条记录',
                        layout: simplePager
                    });
                }
            },
            get: function (dgObj, keyId) {
                /*******************************************
                说明：获取datagrid选中的数据
                        dgObj：表格对象（如：$('#dg')）
                        keyId：数据主键Id
                ********************************************/
                var retData = { str: '', arr: [], obj: [] };

                if (dgObj != null) {
                    retData.obj = dgObj.datagrid('getChecked');
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

                var thisQueryParams = KXO.com.getObj(obj);
                //此参数用于传递给MsSysController控制器的OnAuthorization方法，便于返回不同的数据对象
                thisQueryParams.requestObj = 'EasyUI-DG';

                if (type === 'dg' || type === 'edg') {
                    dgObj.datagrid('load', obj);
                } else {
                    dgObj.treegrid('load', obj);
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
                        '<span class="eui-icon icon-apply">&nbsp;</span>' : '<span class="eui-icon icon-cancel">&nbsp;</span>';
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
            }
        },
        tab: {
            init: function (ngApp, obj) {
                /*******************************************
                说明：初始化tab标签
                        ngApp：angular初始化应用模块对象
                        obj：初始化配置
                            {
                                theme: 'default',//主题样式（default：默认、sample：简单样式、nav：导航样式）
                                radius: true,//是否显示圆角，默认为false
                                border: false,//是否显示面板边框，默认为true
                                initClick:function(){},//页面渲染完成后的初始化事件，类似jQuery的ready初始化函数
                                path:'../../',//相对页面的路径前缀
                                header: [
                                    //title：标签名称、isActive：是否为默认选中标签，此参数为false或者不设置，则默认为第一个标签选中、
                                    //isLoadIframe：当标签内容为iframe的时候，如果设置了该配置为true，表示点击该标签时，刷新该iframe中的内容、
                                    //event：点击标签时的点击事件
                                    { title: '人员信息' },
                                    { title: '设备信息' },
                                    { title: '合同信息', event: function () { console.log(888); } },
                                    { title: '文件信息', isActive: true, isLoadIframe: true, event: function () { console.log(888); } }
                                ]
                            }
                ********************************************/

                obj.header = KXO.com.getObj(obj.header, 'arr');
                obj.theme = KXO.com.getObj(obj.theme, 'str', 'default');
                obj.radius = KXO.com.getObj(obj.radius, 'bool', false);
                obj.border = KXO.com.getObj(obj.border, 'bool', true);
                obj.initClick = KXO.com.getObj(obj.initClick, 'fn');
                obj.path = KXO.com.getObj(obj.path, 'str', '../../');

                //定义外部指令kx-tab
                ngApp.directive('kxTab', function ($timeout) {
                    return {
                        restrict: 'E',
                        replace: true,
                        transclude: true,//设为true时，指明可将指令中的内容包含进去
                        scope: {},
                        templateUrl: obj.path + 'Content/NgTemplate/Form.Tab.html',
                        link: function (scope, element, attr) {
                            var thisHeaderPanel = element.find('.kx-tab-header'),
                                thisItemPanel = element.find('.kx-tab-panel');

                            //显示对应内容面板
                            $timeout(function () {
                                thisHeaderPanel.find('a:eq(' + scope.activeIndex + ')').addClass('active');
                            });
                            thisItemPanel.find('.item:eq(' + scope.activeIndex + ')').fadeIn();

                            //设置主题
                            if (scope.obj.theme == 'sample') {
                                element.removeClass('kx-tab-sample').removeClass('kx-tab-nav').addClass('kx-tab-sample');
                            } else if (scope.obj.theme == 'nav') {
                                element.removeClass('kx-tab-sample').removeClass('kx-tab-nav').addClass('kx-tab-nav');
                            }

                            //设置圆角
                            if (scope.obj.radius) {
                                element.removeClass('kx-tab-radius').addClass('kx-tab-radius');
                            }

                            //是否显示面板边框
                            scope.panelBorderStyle = {};
                            if (!scope.obj.border) {
                                scope.panelBorderStyle = { borderWidth: 0 };
                            }

                            //设置iframe的高度
                            thisItemPanel.find('.item').each(function (index) {
                                var thisPanel = $(this),
                                    thisIframe = thisPanel.find('iframe');
                                if (thisIframe.length > 0) {
                                    //设置面板iframe配置的高度
                                    if (scope.obj.header[index] && scope.obj.header[index].panelHeight && ((typeof (scope.obj.header[index].panelHeight) == 'number' || typeof (scope.obj.header[index].panelHeight) == 'string') && (scope.obj.header[index].panelHeight + '').length > 0)) {
                                        thisIframe.height(scope.obj.header[index].panelHeight);
                                    } else {
                                        //thisIframe.load(function () {
                                        var mainheight = thisIframe.contents().find("html").height() + 45;
                                        thisIframe.height(mainheight <= 702 ? 702 : mainheight);
                                        //});
                                    }
                                } else {
                                    //设置面板配置的高度
                                    if (scope.obj.header[index] && scope.obj.header[index].panelHeight && ((typeof (scope.obj.header[index].panelHeight) == 'number' || typeof (scope.obj.header[index].panelHeight) == 'string') && (scope.obj.header[index].panelHeight + '').length > 0)) {
                                        thisPanel.height(scope.obj.header[index].panelHeight);
                                    }
                                }
                            });
                        },
                        controller: function ($scope, $timeout) {
                            //监听页面渲染完成
                            $scope.$watch('$viewContentLoaded', function () {
                                if (typeof obj.initClick == 'function') {
                                    obj.initClick();
                                }
                            });

                            //所有配置
                            $scope.obj = obj;

                            //当前controller对象
                            var kxTabCtrl = this;

                            //获取选中项
                            $scope.activeIndex = 0;
                            for (var i = 0; i < $scope.obj.header.length; i++) {
                                if ($scope.obj.header[i].isActive) {
                                    $scope.activeIndex = i;
                                    break;
                                }
                            }

                            //点击事件
                            $scope.tabHeaderFn = function (index, event) {
                                //设置tab header选中状态
                                $(event.target).parent().find('a').removeClass('active');
                                $(event.target).addClass('active');

                                //显示对应内容面板
                                $(event.target).parent().next().find('.item').hide();
                                $(event.target).parent().next().find('.item:eq(' + index + ')').fadeIn();

                                //执行用户自定义事件
                                if ($scope.obj.header[index].event && typeof ($scope.obj.header[index].event) == 'function') {
                                    $scope.obj.header[index].event();
                                }

                                //如果其中一个面板为iframe，并且设置了isLoadIframe为true，则表示点击该标签刷新iframe
                                if ($scope.obj.header[index].isLoadIframe == null || $scope.obj.header[index].isLoadIframe == undefined ||
                                    $scope.obj.header[index].isLoadIframe) {
                                    var thisIframeSrc = $(event.target).parent().next().find('.item:eq(' + index + ') iframe').attr('src');

                                    $(event.target).parent().next().find('.item:eq(' + index + ') iframe').attr('src', thisIframeSrc);

                                    var thisIframeObj = $(event.target).parent().next().find('.item:eq(' + index + ') iframe'),
                                        thisIframeObjHeight = thisIframeObj.contents().find("html").height();

                                    thisIframeObj.css({ height: thisIframeObjHeight + 45 });
                                }
                            };
                        }
                    };
                });
                //定义内部指令tab-item
                ngApp.directive('tabItem', function () {
                    return {
                        restrict: 'E',
                        replace: true,
                        transclude: true,
                        require: '^kxTab',//将指令kxTab的控制器kxTabCtrl对象注入到link函数
                        scope: {},
                        template: '<div class="item" ng-style="itemStyle" ng-transclude></div>',
                        link: function (scope, element, attr, kxTabCtrl) {
                            scope.itemStyle = {
                                height: attr.height && (attr.height + '').length > 0 ? attr.height : 'auto',
                                overflow: attr.height && (attr.height + '').length > 0 ? 'hidden' : 'initial'
                            };

                            if ($(element).find('iframe').length > 0
                                && attr.height && (attr.height + '').length > 0) {
                                $(element).find('iframe').css({ height: attr.height });
                            }
                            //console.log($(element).find('iframe').length);
                        }
                    };
                });
            }
        },
        stree: {
            init: function (ngApp, obj) {
                /*******************************************
                说明：初始化下拉树标签
                        ngApp：angular初始化应用模块对象
                        tabCtrl：tab标签控制器名称
                        obj：初始化配置
                            {
                                //readonly: false,//是否设置文本框为只读状态，默认为true
                                //placeholder: '请选择项目...',//文本框的placeholder默认值，默认为空
                                firstItem: true,//是否显示第一项，默认为true
                                firstItemName: '',//显示第一项的名称，默认为“所有选项”
                                firstItemClick: function () { },//第一项的点击事件
                                showIcon: false,//是否显示图标，默认为true
                                url: 'GetDataForSelect.ashx',//异步获取数据时的url请求地址
                                urlData: { action: 'GetJcProListSTree' },//异步获取数据时传递的参数（json对象）
                                keyName: '类型',//显示的字段名称，默认为name
                                keyId: '代码',//显示的数据ID字段名称，默认为id
                                keyPid: '专业代码',//显示的数据父ID字段名称，默认为pId
                                width: 200,//文本框宽度，默认为120px
                                //height: 60,//文本框高度，默认为30px
                                //menuHeight: 150,//菜单区域高度，默认为自动，但最高不超过300px。如果设置了，并且为数字，那么菜单区域的高度和最大高度都为设置的高度。
                                minWidth: 150,//文本框最小宽度，默认为120px
                                selectType: 's',//选择的类型（all：所有数据、p：父节点、s：子节点），默认为所有
                                beforeClick: function (row) {//点击树形菜单之前的事件
                                },
                                onClick: function (row) {//点击树形菜单时的事件
                                    //console.log(row);
                                },
                                onSuccess: function () {//数据加载成功后
                                    
                                },
                                data: [//客户端初始化数据（当没有配置url参数时，可通过此参数初始化tree）
                                    //id：树节点主键Id值，pId：父节点Id值，name：数节点名称
                                    { id: 1, pId: 0, name: '目录1' },
                                    { id: 2, pId: 1, name: '目录1-1' }
                                ]
                            }
                ********************************************/

                obj.readonly = KXO.com.getObj(obj.readonly, 'bool', true);
                obj.placeholder = KXO.com.getObj(obj.placeholder, 'str', '');
                obj.firstItem = KXO.com.getObj(obj.firstItem, 'bool', true);
                obj.firstItemName = KXO.com.getObj(obj.firstItemName, 'str', '所有选项');
                obj.firstItemName = obj.firstItemName.length > 0 ? obj.firstItemName : '所有选项';
                obj.firstItemClick = KXO.com.getObj(obj.firstItemClick, 'fn');
                obj.showIcon = KXO.com.getObj(obj.showIcon, 'bool', true);
                obj.url = KXO.com.getObj(obj.url, 'str', '');
                obj.urlData = KXO.com.getObj(obj.urlData, 'json', {});
                obj.keyName = KXO.com.getObj(obj.keyName, 'str', 'name');
                obj.keyId = KXO.com.getObj(obj.keyId, 'str', 'id');
                obj.keyPid = KXO.com.getObj(obj.keyPid, 'str', 'pId');
                obj.data = KXO.com.getObj(obj.data, 'arr');
                obj.width = KXO.com.getObj(obj.width, 'int', 120);
                obj.height = KXO.com.getObj(obj.height, 'int', 30);
                obj.minWidth = KXO.com.getObj(obj.minWidth, 'int', 120);
                obj.selectType = KXO.com.getObj(obj.selectType, 'str', 'all');
                obj.beforeClick = KXO.com.getObj(obj.beforeClick, 'fn');
                obj.onClick = KXO.com.getObj(obj.onClick, 'fn');
                obj.onSuccess = KXO.com.getObj(obj.onSuccess, 'fn');

                ngApp.directive('kxStree', function ($timeout) {
                    return {
                        restrict: 'EA',
                        replace: true,
                        require: '?ngModel',//将控制器注入到该指令中，并作为链接函数的第四个函数
                        scope: {},
                        templateUrl: '../../Content/NgTemplate/Form.STree.html',
                        link: function (scope, element, attr, ngModel) {
                            //检查指令上是否设置了ng-model属性
                            if (!ngModel) return;

                            //此方法目的在于，初始化的时候，将控制器模型值同步到视图值
                            ngModel.$render = function () {
                                //定义该指令文本框的model
                                scope.thisSTreeModel = ngModel.$viewValue;
                            };

                            //所有配置
                            scope.allObj = obj;

                            //ztree基础配置
                            var sTreeSetting = {
                                view: {
                                    dblClickExpand: false,
                                    showIcon: obj.showIcon
                                },
                                data: {
                                    key: {
                                        name: obj.url.length > 0 ? obj.keyName : 'name'
                                    },
                                    simpleData: {
                                        enable: true,
                                        idKey: obj.url.length > 0 ? obj.keyId : 'id',
                                        pIdKey: obj.url.length > 0 ? obj.keyPid : 'pId'
                                    }
                                },
                                callback: {
                                    beforeExpand: null,
                                    beforeClick: null,
                                    onClick: null
                                }
                            };

                            //输入框和菜单对象
                            var thisInputObj = element.find('input.kx-stree-input'),
                                thisMenuObj = element.find('div.kx-stree-menu');

                            //文本框的最小宽度、高度
                            thisInputObj.css({ width: obj.width + 'px', minWidth: obj.minWidth + 'px' });
                            thisInputObj.css({ height: (obj.height - 2) + 'px', lineHeight: (obj.height - 2) + 'px' });
                            element.css({ height: (obj.height - 2) + 'px' });

                            //菜单区域高度，默认为自动，但最高不超过300px。如果设置了，并且为数字，那么菜单区域的高度和最大高度都为设置的高度。
                            if (obj.menuHeight != undefined && typeof (obj.menuHeight) == 'number') {
                                thisMenuObj.css({ height: obj.menuHeight, maxHeight: obj.menuHeight });
                            }

                            //文本框点击事件
                            scope.sTreeIsShow = false;
                            scope.inputToggleFn = function () {
                                scope.showMenuFn(thisMenuObj.is(':hidden'));
                            };
                            $('*').not(element).on('focus', function () {
                                scope.showMenuFn(false);
                            });

                            //第一项点击事件
                            scope.firstItemClick = function () {
                                if (typeof (obj.firstItemClick) == 'function') {
                                    obj.firstItemClick();
                                }

                                scope.thisSTreeModel = obj.firstItemName;
                                //改变该指令ng-model的值，会更新控制器对应的变量
                                ngModel.$setViewValue(scope.thisSTreeModel);

                                scope.showMenuFn(false);
                            };

                            scope.beforeClickFn = function (treeNode) {
                                if (typeof (obj.beforeClick) == 'function') {
                                    var beFnRet = obj.beforeClick(treeNode);

                                    return beFnRet == null || beFnRet == undefined || typeof (beFnRet) != 'boolean' ? true : beFnRet;
                                } else {
                                    return true;
                                }
                            };

                            scope.nodeIsExpand = false;
                            sTreeSetting.callback.beforeExpand = function (treeId, treeNode) {
                                //console.log(scope.nodeIsExpand);
                                //scope.showMenuFn(true);
                            };

                            //点击树形菜单之前的事件
                            sTreeSetting.callback.beforeClick = function (treeId, treeNode, clickFlag) {
                                if (obj.selectType == 'all') {
                                    scope.beforeClickFn(treeNode);
                                } else if (obj.selectType == 'p') {
                                    if (treeNode.isParent || treeNode.getParentNode() == null) {
                                        scope.beforeClickFn(treeNode);
                                    } else {
                                        //KXO.dia.msg('只能选择父级选项！');
                                        $.fn.zTree.getZTreeObj(treeId).expandNode(treeNode);
                                        return false;
                                    }
                                } else if (obj.selectType == 's') {
                                    if (treeNode.isParent) {
                                        //KXO.dia.msg('只能选择子级选项！');
                                        $.fn.zTree.getZTreeObj(treeId).expandNode(treeNode);
                                        return false;
                                    } else {
                                        scope.beforeClickFn(treeNode);
                                    }
                                }
                            };

                            //点击树形菜单时的事件
                            sTreeSetting.callback.onClick = function (e, treeId, treeNode) {
                                if (typeof (obj.onClick) == 'function') {
                                    obj.onClick(treeNode);
                                }

                                scope.thisSTreeModel = treeNode[sTreeSetting.data.key.name];
                                //改变该指令ng-model的值，会更新控制器对应的变量
                                ngModel.$setViewValue(scope.thisSTreeModel);

                                scope.showMenuFn(false);
                            };

                            //是否首次数据已加载
                            scope.isLoadData = false;
                            //首次加载的数据集合
                            scope.loadData = [];
                            //显示或隐藏下拉树
                            scope.showMenuFn = function (isShow) {
                                scope.sTreeIsShow = isShow;
                                if (isShow) {
                                    //初始化树
                                    if (obj.url.length > 0) {
                                        if (!scope.isLoadData) {
                                            KXO.plu.ajax({
                                                isLoad: false,
                                                url: obj.url,
                                                data: obj.urlData
                                            }, function (data) {
                                                scope.loadData = data;
                                                $.fn.zTree.init(element.find('ul.ztree'), sTreeSetting, data);
                                                scope.isLoadData = true;

                                                if (typeof (obj.onSuccess) == 'function') {
                                                    obj.onSuccess();
                                                }
                                            });
                                        } else {
                                            //$.fn.zTree.init(element.find('ul.ztree'), sTreeSetting, scope.loadData);
                                        }
                                    } else {
                                        $.fn.zTree.init(element.find('ul.ztree'), sTreeSetting, obj.data);
                                    }

                                    var thisInputObjOffset = thisInputObj.offset();
                                    thisMenuObj.css({ left: thisInputObjOffset.left + 'px', top: thisInputObjOffset.top + thisInputObj.outerHeight() + 'px', width: thisInputObj.width() + 20 }).fadeIn("fast");
                                } else {
                                    thisMenuObj.fadeOut("fast");
                                }
                            };
                        }
                    };
                });
            }
        },
        strees: {
            init: function (ngApp, obj) {
                /*******************************************
                说明：初始化下拉树标签（针对系统检测参数和专业的）
                        ngApp：angular初始化应用模块对象
                        tabCtrl：tab标签控制器名称
                        obj：初始化配置
                            {
                                defaultXmName:'',默认项目名称
                                defaultXmCode:'',默认项目代码
                                //readonly: false,//是否设置文本框为只读状态，默认为true
                                //placeholder: '请选择项目...',//文本框的placeholder默认值，默认为空
                                firstItem: true,//是否显示第一项，默认为true
                                firstItemName: '',//显示第一项的名称，默认为“所有选项”
                                firstItemClick: function () { },//第一项的点击事件
                                showIcon: false,//是否显示图标，默认为true
                                url: 'GetDataForSelect.ashx',//异步获取数据时的url请求地址
                                urlData: { action: 'GetJcProListSTree' },//异步获取数据时传递的参数（json对象）
                                keyName: '类型',//显示的字段名称，默认为name
                                keyId: '代码',//显示的数据ID字段名称，默认为id
                                keyPid: '专业代码',//显示的数据父ID字段名称，默认为pId
                                width: 200,//文本框宽度，默认为120px
                                //height: 60,//文本框高度，默认为30px
                                //menuHeight: 150,//菜单区域高度，默认为自动，但最高不超过300px。如果设置了，并且为数字，那么菜单区域的高度和最大高度都为设置的高度。
                                minWidth: 150,//文本框最小宽度，默认为120px
                                selectType: 's',//选择的类型（all：所有数据、p：父节点、s：子节点），默认为所有
                                beforeClick: function (row) {//点击树形菜单之前的事件
                                },
                                onClick: function (row) {//点击树形菜单时的事件
                                    //console.log(row);
                                },
                                onSuccess: function () {//数据加载成功后
                                    
                                },
                                proTypeChg: function (zyCode) {//专业改变后的回调函数
                                    
                                },
                                data: [//客户端初始化数据（当没有配置url参数时，可通过此参数初始化tree）
                                    //id：树节点主键Id值，pId：父节点Id值，name：数节点名称
                                    { id: 1, pId: 0, name: '目录1' },
                                    { id: 2, pId: 1, name: '目录1-1' }
                                ]
                            }
                ********************************************/
                obj.defaultXmName = KXO.com.getObj(obj.defaultXmName, 'str', '');
                obj.defaultXmCode = KXO.com.getObj(obj.defaultXmCode, 'str', '');
                obj.readonly = KXO.com.getObj(obj.readonly, 'bool', true);
                obj.placeholder = KXO.com.getObj(obj.placeholder, 'str', '');
                obj.firstItem = KXO.com.getObj(obj.firstItem, 'bool', true);
                obj.firstItemName = KXO.com.getObj(obj.firstItemName, 'str', '所有选项');
                obj.firstItemName = obj.firstItemName.length > 0 ? obj.firstItemName : '所有选项';
                obj.firstItemClick = KXO.com.getObj(obj.firstItemClick, 'fn');
                obj.showIcon = KXO.com.getObj(obj.showIcon, 'bool', true);
                obj.url = KXO.com.getObj(obj.url, 'str', '');
                obj.urlData = KXO.com.getObj(obj.urlData, 'json', {});
                obj.keyName = KXO.com.getObj(obj.keyName, 'str', 'name');
                obj.keyId = KXO.com.getObj(obj.keyId, 'str', 'id');
                obj.keyPid = KXO.com.getObj(obj.keyPid, 'str', 'pId');
                obj.data = KXO.com.getObj(obj.data, 'arr');
                obj.width = KXO.com.getObj(obj.width, 'int', 120);
                obj.height = KXO.com.getObj(obj.height, 'int', 30);
                obj.minWidth = KXO.com.getObj(obj.minWidth, 'int', 120);
                obj.selectType = KXO.com.getObj(obj.selectType, 'str', 'all');
                obj.beforeClick = KXO.com.getObj(obj.beforeClick, 'fn');
                obj.onClick = KXO.com.getObj(obj.onClick, 'fn');
                obj.onSuccess = KXO.com.getObj(obj.onSuccess, 'fn');
                obj.proTypeChg = KXO.com.getObj(obj.proTypeChg, 'fn');

                ngApp.directive('kxStrees', function ($http, $timeout) {
                    return {
                        restrict: 'EA',
                        replace: true,
                        require: '?ngModel',//将控制器注入到该指令中，并作为链接函数的第四个函数
                        scope: {},
                        templateUrl: '../../Content/NgTemplate/Form.STreeS.html',
                        link: function (scope, element, attr, ngModel) {
                            //检查指令上是否设置了ng-model属性
                            if (!ngModel) return;

                            //此方法目的在于，初始化的时候，将控制器模型值同步到视图值
                            ngModel.$render = function () {
                                //定义该指令文本框的model
                                scope.thisSTreeModel = obj.defaultXmName.length > 0 ? obj.defaultXmName : ngModel.$viewValue;
                                //scope.thisSTreeModel = ngModel.$viewValue;
                            };

                            //所有配置
                            scope.allObj = obj;

                            //ztree基础配置
                            var sTreeSetting = {
                                view: {
                                    dblClickExpand: false,
                                    showIcon: obj.showIcon
                                },
                                data: {
                                    key: {
                                        name: obj.url.length > 0 ? obj.keyName : 'name'
                                    },
                                    simpleData: {
                                        enable: true,
                                        idKey: obj.url.length > 0 ? obj.keyId : 'id',
                                        pIdKey: obj.url.length > 0 ? obj.keyPid : 'pId'
                                    }
                                },
                                callback: {
                                    beforeExpand: null,
                                    beforeClick: null,
                                    onClick: null
                                }
                            };

                            //输入框和菜单对象
                            var thisInputObj = element.find('input.kx-stree-input'),
                                thisMenuObj = element.find('div.kx-stree-menu');

                            //文本框的最小宽度、高度
                            thisInputObj.css({ width: obj.width + 'px', minWidth: obj.minWidth + 'px' });
                            thisInputObj.css({ height: (obj.height - 2) + 'px', lineHeight: (obj.height - 2) + 'px' });
                            element.css({ height: (obj.height - 2) + 'px' });

                            //菜单区域高度，默认为自动，但最高不超过300px。如果设置了，并且为数字，那么菜单区域的高度和最大高度都为设置的高度。
                            if (obj.menuHeight != undefined && typeof (obj.menuHeight) == 'number') {
                                thisMenuObj.css({ height: obj.menuHeight, maxHeight: obj.menuHeight });
                            }

                            //文本框点击事件
                            scope.sTreeIsShow = false;
                            scope.inputToggleFn = function () {
                                scope.showMenuFn(thisMenuObj.is(':hidden'));
                            };
                            //$('*').not(element).on('focus', function () {
                            //    scope.showMenuFn(false);
                            //});

                            //第一项点击事件
                            scope.firstItemClick = function () {
                                if (typeof (obj.firstItemClick) == 'function') {
                                    obj.firstItemClick();
                                }

                                scope.thisSTreeModel = obj.firstItemName;
                                //改变该指令ng-model的值，会更新控制器对应的变量
                                ngModel.$setViewValue(scope.thisSTreeModel);

                                scope.showMenuFn(false);
                            };

                            scope.beforeClickFn = function (treeNode) {
                                if (typeof (obj.beforeClick) == 'function') {
                                    var beFnRet = obj.beforeClick(treeNode);

                                    return beFnRet == null || beFnRet == undefined || typeof (beFnRet) != 'boolean' ? true : beFnRet;
                                } else {
                                    return true;
                                }
                            };

                            scope.nodeIsExpand = false;
                            sTreeSetting.callback.beforeExpand = function (treeId, treeNode) {
                                //console.log(scope.nodeIsExpand);
                                //scope.showMenuFn(true);
                            };

                            //点击树形菜单之前的事件
                            sTreeSetting.callback.beforeClick = function (treeId, treeNode, clickFlag) {
                                if (obj.selectType == 'all') {
                                    scope.beforeClickFn(treeNode);
                                } else if (obj.selectType == 'p') {
                                    if (treeNode.isParent || treeNode.getParentNode() == null) {
                                        scope.beforeClickFn(treeNode);
                                    } else {
                                        //KXO.dia.msg('只能选择父级选项！');
                                        $.fn.zTree.getZTreeObj(treeId).expandNode(treeNode);
                                        return false;
                                    }
                                } else if (obj.selectType == 's') {
                                    if (treeNode.isParent) {
                                        //KXO.dia.msg('只能选择子级选项！');   
                                        $.fn.zTree.getZTreeObj(treeId).expandNode(treeNode);
                                        return false;
                                    } else {
                                        scope.beforeClickFn(treeNode);
                                    }
                                }
                            };

                            //点击树形菜单时的事件
                            sTreeSetting.callback.onClick = function (e, treeId, treeNode) {
                                if (typeof (obj.onClick) == 'function') {
                                    obj.onClick(treeNode);
                                }

                                scope.thisSTreeModel = treeNode[sTreeSetting.data.key.name];
                                //改变该指令ng-model的值，会更新控制器对应的变量
                                ngModel.$setViewValue(scope.thisSTreeModel);

                                scope.showMenuFn(false);
                            };

                            //是否首次数据已加载
                            scope.isLoadData = false;
                            //首次加载的数据集合
                            scope.loadData = [];
                            //显示或隐藏下拉树
                            scope.showMenuFn = function (isShow) {
                                scope.sTreeIsShow = isShow;
                                if (isShow) {
                                    //初始化树
                                    if (obj.url.length > 0) {
                                        if (!scope.isLoadData) {

                                            //获取专业类型
                                            KXO.plu.ng.http({ http: $http, isLoad: false, url: '../Wt/GetDataForSelect.ashx', params: { action: 'GetProTypes', isGetAll: 1 } }, function (data) {
                                                scope.jcProTypes = data;
                                                scope.proTypeModel = data[0];
                                                //console.log(JSON.stringify(data));
                                                scope.proTypeChgFn();
                                            });

                                        } else {
                                            //$.fn.zTree.init(element.find('ul.ztree'), sTreeSetting, scope.loadData);
                                        }
                                    } else {
                                        $.fn.zTree.init(element.find('ul.ztree'), sTreeSetting, obj.data);
                                    }

                                    var thisInputObjOffset = thisInputObj.offset();
                                    thisMenuObj.css({ left: thisInputObjOffset.left + 'px', top: thisInputObjOffset.top + thisInputObj.outerHeight() + 'px', width: thisInputObj.width() + 20 }).fadeIn("fast");
                                } else {
                                    thisMenuObj.fadeOut("fast");
                                }
                            };
                            //专业类型改变事件
                            scope.proTypeChgFn = function () {
                                var zyType = scope.proTypeModel['代码'];

                                if (typeof (obj.proTypeChg) == 'function') {
                                    obj.proTypeChg(zyType);
                                }

                                KXO.plu.ajax({
                                    isLoad: false,
                                    url: obj.url,
                                    data: { action: obj.urlData.action, zyType: zyType }//Nolanhe @ 2017-03-23 由页面传入，因为有两页面只显示的检测项目
                                }, function (data) {
                                    scope.loadData = data;
                                    $.fn.zTree.init(element.find('ul.ztree'), sTreeSetting, data);
                                    scope.isLoadData = true;

                                    //根据默认项目代码设置默认显示项目
                                    if (obj.defaultXmCode && obj.defaultXmCode.length > 0) {
                                        for (var i = 0; i < data.length; i++) {
                                            if (data[i]['代码'] == obj.defaultXmCode) {
                                                scope.thisSTreeModel = data[i]['类型'];
                                                scope.$apply();
                                            }
                                        }
                                    }

                                    if (typeof (obj.onSuccess) == 'function') {
                                        obj.onSuccess();
                                    }
                                });
                            };
                        }
                    };
                });
            }
        },
        history: {
            init: function (ngApp, obj) {
                /*******************************************
                说明：初始化kx-history标签
                        ngApp：angular初始化应用模块对象
                        obj：初始化配置
                            {
                                width: 900,//内容面板宽度，默认为960px，最小不能小于300px
                                tip: '所有历史信息',//提示信息，默认为“所有内容”
                                url: '',//服务端获取数据的地址（注：返回的数据格式应该是JSON数组）
                                urlData: { keyName: 'quber' },//获取服务端数据时传递的参数（json对象）
                                timeCol: 'OprDate',//从服务端获取数据时，显示的时间列名称
                                textCol: 'Result',//从服务端获取数据时，显示的内容列名称
                                data: [//客户端静态数据（注：如果设置了url配置，则优先使用url所获取的数据）
                                    //time：显示的时间字段名称、text：显示的内容字段名称
                                    { time: '2016-8-13 13:41:35', text: '我是测试的内容信息，我是静态的内容信息，不是从服务器获取的哦！' },
                                ]
                            }
                ********************************************/

                obj.width = KXO.com.getObj(obj.width, 'int', 960);
                obj.width = obj.width <= 300 ? 300 : obj.width;
                obj.tip = KXO.com.getObj(obj.tip, 'str', '所有内容');
                obj.url = KXO.com.getObj(obj.url, 'str', '');
                obj.timeCol = KXO.com.getObj(obj.timeCol, 'str', '');
                obj.textCol = KXO.com.getObj(obj.textCol, 'str', '');
                obj.data = KXO.com.getObj(obj.data, 'arr', []);

                KXO.plu.ng.listenRepeat(ngApp);
                ngApp.directive('kxHistory', function ($timeout) {
                    return {
                        restrict: 'E',
                        replace: true,
                        //transclude: true,//设为true时，指明可将指令中的内容包含进去
                        scope: {},
                        templateUrl: '../../Content/NgTemplate/Form.History.html',
                        link: function (scope, element, attr) {
                            //DOM渲染完成后初始化事件
                            scope.historyItemFinish = function () {
                                var historyDate = element.find('.history-date'),
                                    historyDateA = historyDate.find("h2 a,ul li dl dt a"),
                                    historyHeight = element.height(),
                                    eleTop = [];

                                element.css({ height: 59 });

                                historyDate.find("ul").children(":not('h2:first')").each(function (idx) {
                                    eleTop.push($(this).position().top);
                                    $(this).css({ "margin-top": -eleTop[idx] }).children().hide();
                                }).animate({ "margin-top": 0 }, 500).children().fadeIn();

                                element.animate({ height: historyHeight + 104 }, 1500);

                                historyDateA.click(function () {
                                    $(this).parent().css({ position: 'relative' });
                                    $(this).parent().siblings().slideToggle();
                                    element.removeAttr('style');
                                    return false;
                                });
                            };
                        },
                        controller: function ($scope, $http) {
                            //监听页面渲染完成
                            $scope.$watch('$viewContentLoaded', function () {
                                if (typeof obj.initClick == 'function') {
                                    obj.initClick();
                                }
                            });

                            $scope.allObj = obj;

                            //数据类型（1：服务端数据，2：客户端静态数据）
                            $scope.dataType = obj.url && typeof (obj.url) == 'string' && obj.url.length > 0 ? 1 : 2;

                            if ($scope.dataType === 1) {
                                KXO.plu.ng.http({
                                    http: $http,
                                    url: obj.url,
                                    params: obj.urlData
                                }, function (data) {
                                    $scope.serverList = data;
                                });
                            }
                        }
                    };
                });
            }
        },
        gridView: {
            //列表和图标扩展
            init: function (obj) { //初始化
                /*******************************************
                说明：初始化视图表格
                        obj：初始化配置
                            {
                                path:'../../',//相对页面的路径前缀
                                btnCount:3,//列表按钮默认显示的个数（默认为3）
                                isShowCheck: false,//是否显示复选框
                                isShowSortPanel: true,//是否显示已选择的排序面板，默认为true
                                isShowQueryPanel: true,//是否显示已选择的条件面板，默认为true
                                isPop: false,//是否包含pop模块指令
                                isView: true,//是否显示左上角的切换图标（可不填，默认为false）
                                isSimPager: true,//是否同时显示简单分页按钮（可不填，默认为false）
                                isOrder: true,//是否显示序号列（可不填，默认为true）
                                isShowQue: true,//是否显示操作列旁边的“帮助”图标（可不填，默认为true）
                                isBtnHide: false,//列表模式时，是否隐藏所有的操作按钮（可不填，默认为false）
                                isShowOptCol: false,//是否显示操作列
                                rowCurIsPointer: false,//鼠标移动到行上时，样式是否为“手形”。当设置了单击和双击行事件后，鼠标样式自动改为“手形”
                                isShowCusSort: false,//是否显示自定义排序按钮（开关），默认为false
                                method: 'POST',//数据请求类型（可不填，默认为GET方式）
                                url: 'ViewData.ashx',//数据请求地址（必填）
                                data: { keyName: 'quber', count: 25 },//传递给后台服务的参数（json对象，可填）
                                pageSize: 26,//分页大小（可不填，默认为15）
                                titleCol: 'Name',//标题列名称（必填）
                                imgCol: 'Img',//图片列名称（必填）
                                extColPos: 'right',//扩展列显示的位置："left","right","top","bottom"
                                titleClick: function (row) {//标题点击事件
                                    //row为这一行的数据对象（json）
                                },
                                rowClick: function (row) {//行单击事件
                                    //row为这一行的数据对象（json）
                                },
                                rowDblClick: function (row) {//行双击事件
                                    //row为这一行的数据对象（json）
                                },
                                imgClick: function (row) {//图片点击事件
                                    //row为这一行的数据对象（json）
                                },
                                onBefore: function ($scope, $http) {//初始化前回调
                                    //$scope：服务对象
                                    //$http：服务对象
                                },
                                onSuccess: function (data, dataSort) {//初始化成功后回调
                                    //data：服务端原始数据
                                    //dataSort：根据col属性提供的列数据集合
                                },
                                col: [//显示的列集合
                                    //field：显示的数据列名称、title：列表的头部列名称、width：列宽度（可不填，类型为整形或字符串，如100或'100px'）
                                    //className：该字段附加的样式类名称、
                                    //formatter：自定义该字段的回调函数，value：该字段返回值、row：当前行数据
                                    //align：列内容对齐方式，默认为居中center，可选参数有：居左left、居中center、居右right
                                    //headerAlign：标题对齐方式，默认为居中center，可选参数有：居左left、居中center、居右right
                                    {
                                        field: 'Name', title: '名称<span style="color:#f00;">1001</span>', width: 200,
                                        sortable: true,
                                        formatter: function (value, row) {
                                            return '<span style="color:#f00;">' + value + '</span> - ' + row.Count;
                                        }
                                    },
                                    { field: 'Count', title: '数量', className: 'kx-red'}
                                ],
                                extCol: [//自定义扩展字段
                                    { field: 'Img', title: '图片地址' },
                                    { field: 'Suffix', title: '后缀' }
                                ],
                                optBtn: [//操作按钮集合
                                    //icon：图标名称（必填，可参照http://fontawesome.io/icons/）、title：提示内容（可不填）、event：事件函数（可不填，row：这一行的数据对象、event：事件对象）
                                    //isShow：是否显示该按钮，默认为显示、isShowText：是否显示按钮文字
                                    //type：按钮类型，用于权限控制（opt：操作、view：查看，默认为opt）
                                    { icon: 'wrench', title: '设置', event: function (row, event) { alert(row.Name); } },
                                    { 
                                        icon: 'pencil-square-o', title: '修改', event: function (row, event) { alert(row.Count); },
                                        isShow: function (row, event) { return row.IsStartTask; }
                                    }
                                ]
                            }
                ********************************************/
                obj = KXO.com.getObj(obj);
                obj.chkLogin = KXO.com.getObj(obj.chkLogin, 'bool', true);
                obj.path = KXO.com.getObj(obj.path, 'str', '../../');
                obj.btnCount = KXO.com.getObj(obj.btnCount, 'int', 6);
                obj.isShowCheck = KXO.com.getObj(obj.isShowCheck, 'bool', false);
                obj.isShowSortPanel = KXO.com.getObj(obj.isShowSortPanel, 'bool', true);
                obj.isShowQueryPanel = KXO.com.getObj(obj.isShowQueryPanel, 'bool', true);
                obj.isPop = KXO.com.getObj(obj.isPop, 'bool', false);
                obj.isView = KXO.com.getObj(obj.isView, 'bool', false);
                obj.isSimPager = KXO.com.getObj(obj.isSimPager, 'bool', false);
                obj.isOrder = KXO.com.getObj(obj.isOrder, 'bool', true);
                obj.isShowQue = KXO.com.getObj(obj.isShowQue, 'bool', true);
                obj.isBtnHide = KXO.com.getObj(obj.isBtnHide, 'bool', false);
                obj.isShowOptCol = KXO.com.getObj(obj.isShowOptCol, 'bool', true);
                obj.rowCurIsPointer = KXO.com.getObj(obj.rowCurIsPointer, 'bool', false);
                obj.isShowCusSort = KXO.com.getObj(obj.isShowCusSort, 'bool', false);
                obj.isShowCusQuery = KXO.com.getObj(obj.isShowCusQuery, 'bool', false);
                obj.extColPos = KXO.com.getObj(obj.extColPos, 'str', 'right');
                obj.method = KXO.com.getObj(obj.method, 'str', 'GET');
                obj.data = KXO.com.getObj(obj.data);
                obj.pageSize = KXO.com.getObj(obj.pageSize, 'int', 15);
                obj.titleClick = KXO.com.getObj(obj.titleClick, 'fn');
                obj.imgClick = KXO.com.getObj(obj.imgClick, 'fn');
                obj.col = KXO.com.getObj(obj.col, 'arr');
                obj.optBtn = KXO.com.getObj(obj.optBtn, 'arr');

                var dirModules = ['kx.pager', 'ngCookies'];
                if (obj.isPop) {
                    dirModules.push('kx.pop');
                }

                //初始化Angular对象
                var myNg = angular.module('ngApp', dirModules, KXO.plu.ng.postReg);

                myNg.directive('kxGrid', function () {
                    return {
                        restrict: 'EA',
                        replace: true,
                        templateUrl: obj.path + 'Content/NgTemplate/Grid.View.html',
                        link: function (sco, ele, attr) {
                            sco.$broadcast('sendChildGridAttr', attr);
                        }
                    };
                });
                myNg.directive('kxGridAttr', function () {
                    return {
                        restrict: 'A',
                        link: function (sco, ele, attr) {
                            //监听行遍历完行后
                            sco.$on('toRepeatRow', function (event, height, isAddSortConHeight) {
                                //设置“数据正在加载”面板行高样式
                                sco.dataLoadingStyle = { lineHeight: height + 'px' };
                                //设置自定义排序面板高度
                                sco.dataSortZdyStyle = { height: (height <= 340) ? 340 : height + 'px' };
                                //设置自定义查询面板高度
                                sco.dataQueryZdyStyle = { height: (height <= 440) ? 440 : height + 'px' };

                                sco.$emit('toKxSortCon', height);
                            });

                            sco.$on('sendChildGridAttr', function (event, data) {
                                angular.forEach(data, function (val, key, obj) {
                                    if (key != '$attr' && key != '$$element') {
                                        attr.$set(key, val);
                                    }
                                });
                            });
                        }
                    };
                });
                myNg.directive('repeatRow', function () {
                    return {
                        restrict: 'A',
                        link: function (sco, ele, attr) {
                            if (sco.$last) {
                                var height = (sco.$index + 1) * 37 + 114;

                                sco.$emit('toRepeatRow', height);

                                var obj = sco.allObj;
                                //初始化设置的列宽度总和、总共设置了几列宽度
                                var setWidthTotal = 0,
                                    setWidthCount = 0;
                                for (var i = 0; i < obj.col.length; i++) {
                                    if (obj.col[i]['width'] && obj.col[i]['width'] > 0) {
                                        setWidthTotal += obj.col[i]['width'];
                                        setWidthCount++;
                                    }
                                }
                                var defaultColWidth = sco.showColWidth;
                                if (setWidthCount > 0) {
                                    var thisGridWidth = $('.kx-frm-gd').width(),
                                        thisOrderWidth = $('.kx-col-order').width(),
                                        thisOptWidth = $('.kx-col-opt').width();

                                    defaultColWidth = (thisGridWidth - thisOrderWidth - thisOptWidth - setWidthTotal - 10) / (obj.col.length - setWidthCount);
                                    sco.showColWidth = defaultColWidth;
                                }
                                var thisShowColsWidth = {};
                                for (var i = 0; i < obj.col.length; i++) {
                                    thisShowColsWidth[obj.col[i]['field']] = obj.col[i]['width'] ? obj.col[i]['width'] : sco.showColWidth;
                                }
                                sco.$emit('toSetColHeight', defaultColWidth, thisShowColsWidth);
                            }
                        }
                    };
                });
                myNg.directive('repeatCol', function ($timeout) {
                    return {
                        restrict: 'A',
                        link: function (sco, ele, attr) {
                            //内容超出列宽时，增加title属性
                            //$timeout(function () {
                            //    $(ele).map(function () {
                            //        if (this.offsetWidth < this.scrollWidth) {
                            //            $(this).attr('title', $(this).text());
                            //        }
                            //    });
                            //}, 1);
                        }
                    };
                });
                //点击列标题排序指令
                myNg.directive('headerSort', function () {
                    return {
                        restrict: 'A',
                        link: function (sco, ele, attr) {
                            var headerSortObj = sco.$eval(attr.headerSortObj), //初始化配置col的json对象
                                sortIconObj = angular.element(ele.find('i')[0]); //当前标题列的排序图标对象

                            //所有标题类对象（除序号和操作列）
                            var allHeaderCols = document.getElementsByClassName('kx-col-header');

                            var curSortType = '';

                            //还原所有标题列的默认图标：fa-sort
                            sco.resetHeaderColSortIcon = function () {
                                angular.element(allHeaderCols).each(function () {
                                    angular.element(angular.element(this).find('i')[0]).not(sortIconObj).removeClass('fa-sort-asc fa-sort-desc').addClass('fa-sort');
                                });
                            };

                            //监听自定义排序确定事件
                            sco.$on('resetHeaderColSortIconOn', function (event, data) {
                                sco.resetHeaderColSortIcon();
                            });

                            ele.on('click', function () {
                                //是否配置列排序
                                if (headerSortObj.sortable) {
                                    if (sortIconObj.hasClass('fa-sort-asc') || sortIconObj.hasClass('fa-sort')) {
                                        //降序
                                        sortIconObj.removeClass('fa-sort fa-sort-asc').addClass('fa-sort-desc');
                                        curSortType = 'Desc';
                                    } else if (sortIconObj.hasClass('fa-sort-desc')) {
                                        //升序
                                        sortIconObj.removeClass('fa-sort-desc').addClass('fa-sort-asc');
                                        curSortType = 'Asc';
                                    }

                                    sco.resetHeaderColSortIcon();

                                    //设置排序方式和字段，并传递到服务端查询数据
                                    sco.pagerConfig.sortType = curSortType;
                                    sco.pagerConfig.sortCol = headerSortObj.field;
                                    sco.pagerConfig.sortCon = '';
                                    KXO.plu.gridView.query({});
                                }
                            });
                        }
                    };
                });

                //获取已选排序、条件区域高度
                myNg.directive('kxSortCon', function () {
                    return {
                        restrict: 'A',
                        link: function (sco, ele, attr) {
                            var sortConH = ele.height() + 10;

                            sco.$on('toKxSortCon', function (event, height, isAddSortConHeight) {
                                var sortHeight = parseInt((sco.dataSortZdyStyle.height + '').replace('px', '')) + sortConH;
                                sco.dataSortZdyStyle.height = sortHeight + 'px';

                                var conHeight = parseInt((sco.dataQueryZdyStyle.height + '').replace('px', '')) + sortConH;
                                sco.dataQueryZdyStyle.height = conHeight + 'px';
                            });
                        }
                    };
                });

                //设置已选自定义排序、查询名称
                myNg.directive('zdySortQuery', function () {
                    return {
                        restrict: 'A',
                        link: function (sco, ele, attr) {
                            ele.on('change', function () {
                                if (attr.issort == '1') {
                                    if (attr.zdySortQuery == 'col') {
                                        sco.zdySortCy[attr.index].ColText = ele.find('option:selected').text();
                                    } else if (attr.zdySortQuery == 'type') {
                                        sco.zdySortCy[attr.index].SortTypeText = ele.find('option:selected').text();
                                    }
                                } else {
                                    if (attr.zdySortQuery == 'col') {
                                        sco.zdyQueryCy[attr.index].ColText = ele.find('option:selected').text();
                                    } else if (attr.zdySortQuery == 'type') {
                                        sco.zdyQueryCy[attr.index].ConTypeText = ele.find('option:selected').text();
                                    }
                                }
                            });
                        }
                    };
                });

                //myNg.directive('checkClick', function () {
                //    return {
                //        restrict: 'A',
                //        link: function (sco, ele, attr) {
                //         var checkType = attr.checkType;
                //         sco.isSelectAll = false;
                //         sco.selectAll = false;

                //            ele.on('click', function () {
                //                if (checkType == 'all') {
                //                    if (ele.is(':checked')) {
                //                        console.log(attr.index);
                //                    }
                //                    sco.selectAll = true;
                //                    sco.$apply();
                //                } else {
                //                    if (ele.is(':checked')) {
                //                        console.log(attr.index);
                //                    }
                //                }
                //            });
                //        }
                //    };
                //});

                //myNg.directive('checkFn', function () {
                //    return {
                //        restrict: 'A',
                //        link: function (sco, ele, attr) {
                //            var chkAllObj = ele.find('.kx-head input[type=checkbox]'),
                //                chkOneObjs = ele.find('.kx-body input[type=checkbox]');

                //            chkOneObjs.on('click', function () {
                //                console.log($(this).attr('check-type'));
                //            });

                //            chkAllObj.on('click', function () {
                //                console.log($(this).attr('check-type'));
                //                //if (ele.is(':checked')) {
                //                //    console.log(attr.index);
                //                //}
                //            });
                //        }
                //    };
                //});

                KXO.plu.ng.toHtml(myNg);

                myNg.controller('pageController', function ($scope, $http, $cookieStore, $timeout) {

                    var cookieStyle = $cookieStore.get("cookieStyle"); //获取cookie中的样式风格
                    //console.log(cookieStyle);
                    if (cookieStyle) {
                        $scope.chooseStyle = "../common/common" + cookieStyle + ".css";
                    } else {
                        $scope.chooseStyle = "../common/common1.css";
                    }


                    //设置所有配置
                    $scope.allObj = obj;

                    //当设置了单击和双击行事件后，鼠标样式自动改为“手形”
                    if (obj.rowClick != undefined || obj.rowDblClick != undefined) {
                        $scope.allObj.rowCurIsPointer = true;
                    }

                    KXO.plu.gridView.event($scope, $cookieStore, obj, $timeout);
                    KXO.plu.gridView.data($scope, $http, $timeout, obj);
                });

                KXO.plu.gridView.dir(myNg);
                KXO.plu.gridView.pager();

                return myNg;
            },
            data: function ($scope, $http, $timeout, obj) { //获取分页数据
                KXO.plu.ajax({
                    isLoad: false,
                    chkLogin: false,//请求数据之前是否检查已经登录
                    url: '../../Content/Handler/Common.ashx',
                    data: { action: 'SetUserOptBtns', moduleId: KXO.com.getUrlVal('mId') }
                }, function (data) {
                    $scope.userBtnQx = data;
                    //console.log(JSON.stringify(data));
                });

                //数据是否已经加载完毕
                $scope.isLoaded = false;

                //基础配置
                $scope.pagerConfig = {
                    pageIndex: 1,
                    pageSize: obj.pageSize,
                    sortType: '', //排序方式：Desc、Asc
                    sortCol: '', //排序字段
                    sortCon: '', //自定义排序集合
                    queryCon: '' //自定义查询集合
                };

                $scope.getDataHttp = function (doParams, startTime) {
                    //KXO.dia.load();
                    $http({
                        method: obj.method,
                        url: obj.url,
                        params: doParams
                    }).success(function (data, status, headers, config) {
                        //还原勾选的数据
                        $scope.$emit('toChgChkItems', true);
                        //总条数
                        $scope.pagerConfig.totalCount = data.Data.Total;
                        if (data.Data.Total > 0) {
                            //当前页原始数据
                            $scope.dataList = data.Data.Rows;

                            //总页数
                            $scope.totalPage = Math.ceil(data.Data.Total / $scope.pagerConfig.pageSize);

                            //对从服务端获取到的分页数据按照配置的列进行排序
                            $scope.getDataListSort = function () {
                                //所有列数据集合、扩展列数据集合
                                var retData = [];
                                if ($scope.showColsName.length > 0) {
                                    for (var i = 0; i < data.Data.Rows.length; i++) {
                                        var dataSin = data.Data.Rows[i];
                                        var sinObj = {};
                                        for (var j = 0; j < $scope.showColsName.length; j++) {
                                            sinObj[$scope.showColsName[j]] = dataSin[$scope.showColsName[j]];
                                            delete dataSin[$scope.showColsName[j]];
                                        }

                                        for (var it in dataSin) {
                                            sinObj[it] = dataSin[it];
                                        }

                                        retData[i] = sinObj;
                                    }
                                } else {
                                    retData = data.Data.Rows;
                                }
                                return retData;
                            }

                            //当前页排序后数据
                            $scope.dataListSort = $scope.getDataListSort();
                        } else {
                            $scope.dataListSort = [];
                        }

                        if (typeof obj.onSuccess == 'function') {
                            obj.onSuccess(data, $scope.dataListSort);
                        }

                        var endTime = new Date();
                        var chaTime = startTime.getTime() - endTime.getTime();

                        $scope.isLoaded = true;

                        //KXO.dia.loadClose();
                        //$timeout(function () { $scope.isLoaded = true; }, chaTime > 500 ? 0 : 200);
                    }).error(function (data, status, headers, config) {
                        var endTime = new Date();
                        var chaTime = startTime.getTime() - endTime.getTime();

                        $scope.isLoaded = true;

                        //KXO.dia.loadClose();
                        //$timeout(function () { $scope.isLoaded = true; }, chaTime > 500 ? 0 : 200);
                    });
                };

                //获取数据
                $scope.getData = function (isSearchObj) {
                    if ($scope.pagerConfig.pageIndex == 0) {
                        $scope.pagerConfig.pageIndex = 1;
                        return;
                    }

                    var doParams = angular.extend({
                        pageIndex: $scope.pagerConfig.pageIndex,
                        pageSize: $scope.pagerConfig.pageSize,
                        sortType: $scope.pagerConfig.sortType,
                        sortCol: $scope.pagerConfig.sortCol,
                        sortCon: $scope.pagerConfig.sortCon,
                        queryCon: $scope.pagerConfig.queryCon
                    }, $scope.allObj.data);

                    //console.log(JSON.stringify(doParams))

                    //查询所用
                    if (typeof isSearchObj != 'number') {
                        doParams = angular.extend(doParams, isSearchObj);
                        //console.log(JSON.stringify(doParams))
                        //console.log($scope.pagerConfig.pageIndex)
                    }

                    var startTime = new Date();
                    $scope.isLoaded = false;

                    if (!obj.chkLogin) {
                        $scope.getDataHttp(doParams, startTime);
                    } else {
                        KXO.plu.ajaxPri({
                            url: '../../Content/Handler/Common.ashx',
                            chkLogin: false,
                            data: { action: 'GetUserInfo' }
                        }, function (data) {
                            if (data.Result == 120) {
                                KXO.dia.msg(data.Msg,
                                {
                                    icon: 'error',
                                    endCallback: function () {
                                        //KXO.frm.getTopWin().window.location.href = '../../Login.aspx';
                                    }
                                });

                                //跳转至登陆页
                                setTimeout(function () {
                                    KXO.frm.getTopWin().window.location.href = '../../Login.aspx';
                                }, 1500);
                            } else {
                                $scope.getDataHttp(doParams, startTime);
                            }
                        });

                    }
                };

                //图标模式下的分页事件
                $scope.iconPagerChg = function (isAdd) {
                    if (isAdd) {
                        if ($scope.pagerConfig.pageIndex < $scope.totalPage)
                            $scope.pagerConfig.pageIndex++;
                        else
                            KXO.dia.msg('已是最后一页！', { time: 1100, icon: 'info' });
                    } else {
                        if ($scope.pagerConfig.pageIndex > 1)
                            $scope.pagerConfig.pageIndex--;
                        else
                            KXO.dia.msg('已是第一页！', { time: 1100, icon: 'info' });
                    }
                }

                // 通过$watch、pageIndex和pageSize，当它们改变时重新获取数据
                if (typeof obj.onBefore != 'function') {
                    $scope.$watch('pagerConfig.pageIndex + pagerConfig.pageSize', $scope.getData);
                } else {
                    obj.onBefore($scope, $http);
                }
            },
            event: function ($scope, $cookieStore, obj, $timeout) { //事件处理
                //切换视图事件
                $scope.viewList = true; //默认是否为列表
                $scope.viewTitle = '切换为图标模式';
                //设置过期时间为一天
                var expireDate = new Date();
                expireDate.setDate(expireDate.getDate() + 1);

                var curUrl = document.URL;//之前为ckIsViewList固定
                $scope.viewChg = function (isList) {
                    $scope.viewList = !isList;
                    $scope.viewTitle = $scope.viewList ? '切换为图标模式' : '切换为列表模式';
                    //cookie记录展现的状态
                    $cookieStore.put(curUrl, $scope.viewList, { expires: expireDate });
                }
                //cookie记录展现的状态
                if ($cookieStore.get(curUrl) != undefined) {
                    $scope.viewList = $cookieStore.get(curUrl);
                } else {
                    $cookieStore.put(curUrl, $scope.viewList, { expires: expireDate });
                }

                //obj.col数组中每个列默认所占的宽（百分比）
                $scope.showColWidth = (obj.isShowOptCol ? 80 / obj.col.length : (80 / obj.col.length + 15 / obj.col.length)) + '%';

                var thisShowColsWidth = {},
                    thisShowColsName = [],
                    thisShowExtColsName = [];
                for (var i = 0; i < obj.col.length; i++) {
                    thisShowColsWidth[obj.col[i]['field']] = obj.col[i]['width'] ? obj.col[i]['width'] : $scope.showColWidth;
                    thisShowColsName[i] = obj.col[i]['field'];
                }
                if (obj.extCol != undefined) {
                    for (var i = 0; i < obj.extCol.length; i++) {
                        thisShowExtColsName[i] = obj.extCol[i]['field'];
                    }
                }
                //监听重新设置宽度
                $scope.$on('toSetColHeight', function (event, defaultColWidth, setHeightObj) {
                    $scope.showColWidth = defaultColWidth;
                    $scope.showDataColWidth = setHeightObj;
                });
                //obj.col数组中每个列在配置后所占的宽
                $scope.showDataColWidth = thisShowColsWidth;
                //初始化配置中所有显示的列名称数组
                $scope.showColsName = thisShowColsName;
                //初始化配置中所有显示的扩展列名称数组
                $scope.showExtColsName = thisShowExtColsName;
                //显示扩展字段的JSON集合
                $scope.extCols = {};

                //自定义单元格数据
                $scope.formatCell = function (value, row, formatterFn) {
                    value = value == null || value == undefined ? '' : value;
                    var retVal = value;

                    if (typeof formatterFn == 'function') {
                        var forMatVal = formatterFn(value, row);
                        if (forMatVal != undefined && forMatVal != null && forMatVal.length > 0) {
                            retVal = forMatVal;
                        }
                    }

                    //内容长度超过100将省略
                    return retVal.length > 100 ? retVal.substring(0, 100) + '...' : retVal;
                };

                //鼠标滑过row时显示扩展字段
                $scope.jydxsxValInputObj = null;
                $scope.mouseHoverRow = function (thisRowId, row, event) {
                    if ($scope.showExtColsName.length <= 0) {
                        return;
                    }

                    var curExtData = {};
                    for (var j = 0; j < $scope.allObj.extCol.length; j++) {
                        curExtData[$scope.allObj.extCol[j].title] = row[$scope.allObj.extCol[j].field];
                    }
                    $scope.extCols = curExtData;

                    $('#' + thisRowId).tooltip({
                        showDelay: 0,
                        position: obj.extColPos,
                        content: function () { return $('#extCellPanel'); },
                        onShow: function () {
                            var t = $(this);
                            t.tooltip('tip').focus().unbind().bind('blur', function () {
                                t.tooltip('hide');
                            });

                            if ($scope.viewList) {
                                t.tooltip('hide');
                            }
                        }
                    }).tooltip(!$scope.viewList ? 'show' : 'hide');
                };
                //鼠标离开行事件
                $scope.mouseLeaveRow = function (thisRowId, row, event) {
                };

                //检查哪些字段该显示
                $scope.chkCols = function (k) {
                    var result = false;

                    for (var i = 0; i < obj.col.length; i++) {
                        for (var item in obj.col[i]) {
                            if (item == 'field' && obj.col[i][item] === k) {
                                result = true;
                                break;
                            }
                        }
                    }

                    return result;
                }

                //按钮点击事件
                $scope.optClick = function (type, row, curKeyName, event) {
                    event.stopPropagation();
                    if (type === 'title' && typeof obj.titleClick == 'function' && obj.titleCol == curKeyName) {
                        obj.titleClick(row, $scope.userBtnQx);
                    } else if (type === 'img' && typeof obj.imgClick == 'function') {
                        obj.imgClick(row, $scope.userBtnQx);
                    } else if (type === 'opt') {
                    }
                }

                //Angular验证方法
                $scope.checkData = function (type, val) {
                    var result = false;

                    if (type == 'num') {
                        result = angular.isNumber(val);
                    } else if (type === 'arr') {
                        result = angular.isArray(val);
                    } else if (type === 'obj') {
                        result = angular.isObject(val);
                    } else if (type === 'str') {
                        result = angular.isString(val);
                    } else if (type === 'fun') {
                        result = angular.isFunction(val);
                    } else if (type === 'unde') {
                        result = angular.isUndefined(val);
                    }

                    return result;
                }

                //操作列的提示事件
                $scope.optQueFn = function (type, event) {
                    //帮助图标对象、提示区域div对象
                    var queIcon = $(event.target),
                        queIconTip = queIcon.next();
                    if (type === 'enter') {//鼠标滑过
                        var queIconOffset = queIcon.offset();
                        queIconTip.css({ left: (queIconOffset.left - (queIcon.next().width() / 2)) + 'px', top: (queIconOffset.top + queIcon.outerHeight() + 10) + 'px' }).fadeIn("fast");
                    } else {//鼠标离开
                        queIconTip.fadeOut("fast");
                    }
                };

                //全选、反选
                $scope.selectAllChked = false;
                $scope.selectAll = false;
                $scope.selectAllType = false;
                $scope.chkAllTitle = '全选';
                //已选择的数据行
                $scope.chkArrList = [];
                //全选、反选
                $scope.chkAll = function (isChkAll) {
                    $scope.selectAllChked = isChkAll;
                    $scope.selectAll = isChkAll;

                    $scope.chkAllTitle = $scope.selectAll ? '取消全选' : '全选';
                    if (isChkAll)
                        for (var i = 0; i < $scope.dataListSort.length; i++) {
                            $scope.chkArrList[i] = $scope.dataListSort[i];
                        }
                    else {
                        $scope.chkArrList = [];
                    }
                };
                //单行选择
                $scope.chkOne = function (row, isChkOne, event) {
                    event.stopPropagation();
                    if (isChkOne) {
                        if ($scope.chkArrList.indexOf(row) == -1) {
                            $scope.chkArrList.push(row);
                        }
                        $scope.selectAllChked = $scope.chkArrList.length == $scope.dataListSort.length;
                    } else {
                        $scope.selectAllType = true;
                        $scope.selectAllChked = false;
                        if ($scope.chkArrList.indexOf(row) != -1) {
                            $scope.chkArrList.splice($scope.chkArrList.indexOf(row), 1);
                        }
                    }
                    $scope.chkAllTitle = $scope.chkArrList.length == $scope.dataListSort.length ? '取消全选' : '全选';
                };
                //还原复选框等条件
                $scope.$on('toChgChkItems', function (event, data) {
                    $scope.selectAllChked = false;
                    $scope.selectAll = false;
                    $scope.chkArrList = [];
                });

                //行单击事件
                $scope.rowClickFn = function (row, event) {
                    event.stopPropagation();
                    if (typeof obj.rowClick == 'function') {
                        obj.rowClick(row);
                    }
                };
                //行双击事件
                $scope.rowDblClickFn = function (row, event) {
                    event.stopPropagation();
                    if (typeof obj.rowDblClick == 'function') {
                        obj.rowDblClick(row);
                    }
                };

                //列内容超出列宽时，显示完整数据
                $scope.mouseColHoverLeave = function (type, event) {
                    if (type == 'hover' && $(event.target)[0].offsetWidth < $(event.target)[0].scrollWidth) {
                        if (!$(event.target).hasClass('this-name-auto-show')) {
                            $(event.target).addClass('this-name-auto-show');
                        }
                    } else {
                        if ($(event.target).hasClass('this-name-auto-show')) {
                            $(event.target).removeClass('this-name-auto-show');
                        }
                    }
                };

                //列操作按钮超过3个时，显示“更多下拉按钮”
                $scope.showMoreBtn = function (event) {
                    var thisBtn = $(event.target),
                        thisInfo = thisBtn.next();

                    if (thisInfo.is(':hidden')) {
                        var thisBtnOffset = thisBtn.offset();
                        thisInfo.css({ left: thisBtnOffset.left - thisInfo.width(), top: thisBtnOffset.top - $(window).scrollTop() + 18 }).fadeIn("fast");
                    } else {
                        thisInfo.fadeOut(500);
                    }
                };
                //隐藏更多按钮面板（用于更多按钮点击的时候）
                $scope.hideMoreBtn = function (event) {
                    var thisBtn = $(event.target).parent().parent();
                    if (thisBtn.hasClass('opt-btn-more-panel')) {
                        thisBtn.fadeOut("fast");
                    }
                };


                //自定义排序、查询
                KXO.plu.gridView.extZdySort($scope);
                KXO.plu.gridView.extZdyQuery($scope);
            },
            query: function (queryObj, controllerName) {
                /*******************************************
                说明：查询数据
                        queryObj：查询参数（必填，JSON对象，如：{ keyName: 'quber1', count: 255 }）
                        controllerName：Angular控制器名称（可不填，默认为pageController）
                ********************************************/
                queryObj = KXO.com.getObj(queryObj);
                controllerName = KXO.com.getObj(controllerName, 'str', 'pageController');

                //通过controller来获取Angular应用
                var appElement = document.querySelector('[ng-controller=' + controllerName + ']');
                //获取$scope变量
                var $scope = angular.element(appElement).scope();

                $scope.getData(queryObj);
            },
            getChk: function (key) {
                /*******************************************
                说明：获取表格勾选的数据
                        key：数据字段名称。不传表示返回的整个数据行数组，传表示返回数据某字段以逗号分隔的字符串
                ********************************************/
                //通过controller来获取Angular应用
                var appElement = document.querySelector('[ng-controller=pageController]');
                //获取$scope变量
                var $scope = angular.element(appElement).scope();

                //数据行集合
                var retRows = $scope.chkArrList;

                if (key == undefined) {
                    return retRows;
                } else {
                    var keys = [];
                    for (var i = 0; i < retRows.length; i++) {
                        keys.push(retRows[i][key]);
                    }
                    return keys.join(',');
                }
            },
            reload: function (controllerName) {
                /*******************************************
                说明：刷新当前页数据
                        controllerName：Angular控制器名称（可不填，默认为pageController）
                ********************************************/
                controllerName = KXO.com.getObj(controllerName, 'str', 'pageController');
                //通过controller来获取Angular应用
                var appElement = document.querySelector('[ng-controller=' + controllerName + ']');
                //获取$scope变量
                var $scope = angular.element(appElement).scope();
                $scope.getData();
            },
            dir: function (thisNg) { //添加指令
                //图标模式时，鼠标滑过row显示操作按钮，离开时隐藏
                thisNg.directive('toggleIconOpt', function () {
                    return {
                        restrict: 'A',
                        scope: {
                            toggleIconOpt: '@'
                        },
                        link: function ($scope, $element) {
                            $element.on('mouseenter', function () {
                                $element.toggleClass($scope.toggleIconOpt);
                            });
                            $element.on('mouseleave', function () {
                                $element.toggleClass($scope.toggleIconOpt);
                            });
                        }
                    };
                });

                //图片不存在时，显示默认图片
                thisNg.directive('errSrc', function () {
                    return {
                        link: function (scope, element, attrs) {
                            element.bind('error', function () {
                                if (attrs.src != attrs.errSrc || attrs.src == null || attrs.src == 'null') {
                                    attrs.$set('src', attrs.errSrc);
                                }
                            });
                        }
                    }
                });
            },
            extZdySort: function ($scope) {
                //自定义排序
                $scope.isOpenZdyPanelSort = false;
                $scope.zdySortCy = [
                    //次要条件集合
                    { ColName: '', ColText: '', SortType: '', SortTypeText: '' } //主要条件
                ];
                $scope.zdySortOpenOrClose = function (type) {
                    if ($scope.zdySortCy.length == 0) {
                        $scope.zdySortCy = [
                            //次要条件集合
                            { ColName: '', ColText: '', SortType: '', SortTypeText: '' } //主要条件
                        ];
                    }

                    if (type == 'open') {
                        //$scope.zdySortCy = [
                        //    //次要条件集合
                        //    { ColName: '',ColText: '',  SortType: '', SortTypeText: '' } //主要条件
                        //];
                    }
                    if (type != 'toggle') {
                        $scope.isOpenZdyPanelSort = type == 'open';
                    } else {
                        //<kx-grid>外部控件调用时切换面板的显示和隐藏
                        $scope.isOpenZdyPanelSort = !$scope.isOpenZdyPanelSort;
                        $scope.isOpenZdyPanelQuery = false;//隐藏查询面板
                    }
                };
                $scope.zdySortAdd = function () {
                    //添加条件
                    $scope.zdySortCy.push({ ColName: '', ColText: '', SortType: '', SortTypeText: '' });
                };
                $scope.zdySortReply = function () {
                    //还原条件
                    $scope.zdySortCy = [
                        //次要条件集合
                        { ColName: '', ColText: '', SortType: '', SortTypeText: '' } //主要条件
                    ];
                };
                $scope.zdySortDelOrCopy = function (type, item) {
                    //删除或复制条件
                    if (type == 'del') {
                        var delIndex = $scope.zdySortCy.indexOf(item);
                        $scope.zdySortCy.splice(delIndex, 1);
                    } else {
                        $scope.zdySortCy.push({ ColName: item.ColName, ColText: item.ColText, SortType: item.SortType, SortTypeText: item.SortTypeText });
                    }
                };
                $scope.zdySortMbDel = function (index) {
                    $scope.zdySortCy.splice(index, 1);

                    $scope.pagerConfig.sortCon = JSON.stringify($scope.zdySortCy);
                    $scope.pagerConfig.sortType = '';
                    $scope.pagerConfig.sortCol = '';
                    KXO.plu.gridView.query({});
                    $scope.$broadcast('resetHeaderColSortIconOn');
                };
                $scope.zdySortSave = function () {
                    //保存条件
                    var isChkRight = true;
                    angular.forEach($scope.zdySortCy, function (obj, index, arr) {
                        if ((obj.ColName.length <= 0 || obj.ColText.length <= 0 || obj.SortType.length <= 0 || obj.SortTypeText.length <= 0) && isChkRight) {
                            isChkRight = false;
                        }
                    });
                    if (!isChkRight) {
                        KXO.dia.msg('所有排序列和排序方式都不能为空，请选择！', 'error');
                        return;
                    }

                    $scope.isOpenZdyPanelSort = false;

                    $scope.pagerConfig.sortCon = JSON.stringify($scope.zdySortCy);
                    $scope.pagerConfig.sortType = '';
                    $scope.pagerConfig.sortCol = '';
                    KXO.plu.gridView.query({});
                    $scope.$broadcast('resetHeaderColSortIconOn');
                };
            },
            extZdyQuery: function ($scope) {
                //自定义排序
                $scope.isOpenZdyPanelQuery = false;
                $scope.zdyQueryCy = [
                    //次要条件集合
                    { ColName: '', ColText: '', ConType: '', ConTypeText: '', ColVal: '' } //主要条件
                ];
                $scope.zdyQueryOpenOrClose = function (type) {
                    if ($scope.zdyQueryCy.length == 0) {
                        $scope.zdyQueryCy = [
                            //次要条件集合
                            { ColName: '', ColText: '', ConType: '', ConTypeText: '', ColVal: '' } //主要条件
                        ];
                    }

                    if (type == 'open') {
                        //$scope.zdyQueryCy = [
                        //    //次要条件集合
                        //    { ColName: '', ColText: '', ConType: '', ConTypeText: '',ColVal: '' } //主要条件
                        //];
                    }
                    if (type != 'toggle') {
                        $scope.isOpenZdyPanelQuery = type == 'open';
                    } else {
                        //<kx-grid>外部控件调用时切换面板的显示和隐藏
                        $scope.isOpenZdyPanelQuery = !$scope.isOpenZdyPanelQuery;
                        $scope.isOpenZdyPanelSort = false;//隐藏排序面板
                    }
                };
                $scope.zdyQueryAdd = function () {
                    //添加条件
                    $scope.zdyQueryCy.push({ ColName: '', ColText: '', ConType: '', ConTypeText: '', ColVal: '' });
                };
                $scope.zdyQueryReply = function () {
                    //还原条件
                    $scope.zdyQueryCy = [
                        //次要条件集合
                        { ColName: '', ColText: '', ConType: '', ConTypeText: '', ColVal: '' } //主要条件
                    ];

                    //还原数据列表
                    $scope.pagerConfig.queryCon = '[]';
                    KXO.plu.gridView.query({});
                };
                $scope.zdyQueryDelOrCopy = function (type, item) {
                    //删除或复制条件
                    if (type == 'del') {
                        var delIndex = $scope.zdyQueryCy.indexOf(item);
                        $scope.zdyQueryCy.splice(delIndex, 1);
                    } else {
                        $scope.zdyQueryCy.push({ ColName: item.ColName, ColText: item.ColText, ConType: item.ConType, ConTypeText: item.ConTypeText, ColVal: item.ColVal });
                    }
                };
                $scope.zdyQueryMbDel = function (index) {
                    $scope.zdyQueryCy.splice(index, 1);

                    $scope.pagerConfig.queryCon = JSON.stringify($scope.zdyQueryCy);
                    KXO.plu.gridView.query({});
                };
                $scope.zdyCusAddCon = function (addObj) {
                    if ($scope.zdyQueryCy.length == 1 && $scope.zdyQueryCy[0].ColName.length <= 0) {
                        $scope.zdyQueryCy[0] = addObj;
                    } else {
                        $scope.zdyQueryCy.push(addObj);
                    }

                    $scope.pagerConfig.queryCon = JSON.stringify($scope.zdyQueryCy);
                    KXO.plu.gridView.query({});
                };
                $scope.zdyQuerySave = function () {
                    //保存条件

                    var isChkRight = true;
                    angular.forEach($scope.zdyQueryCy, function (obj, index, arr) {
                        if ((obj.ColName.length <= 0 || obj.ColText.length <= 0 || obj.ConType.length <= 0 || obj.ConTypeText.length <= 0 || obj.ColVal.length <= 0) && isChkRight) {
                            isChkRight = false;
                        }
                    });
                    if (!isChkRight) {
                        KXO.dia.msg('所有查询列、查询条件和查询值都不能为空，请选择！', 'error');
                        return;
                    }

                    $scope.isOpenZdyPanelQuery = false;

                    $scope.pagerConfig.queryCon = JSON.stringify($scope.zdyQueryCy);
                    //console.log($scope.pagerConfig.queryCon)
                    KXO.plu.gridView.query({});
                };
            },
            pager: function () {//分页扩展
                angular.module('kx.pager', []).directive('kxPager', [function () {
                    return {
                        restrict: 'EA',
                        template: '<div class="page-list">' +
                            //'<ul class="pager" ng-show="config.totalCount > 0" style="display: inline-block;">' +
                            //'<li ng-class="{disabled: config.pageIndex == 1}" ng-click="prevPage()"><span>&laquo;</span></li>' +
                            //'<li ng-repeat="item in pageList track by $index" ng-class="{active: item == config.pageIndex, separate: item == \'...\'}" ' +
                            //'ng-click="changeCurrentPage(item)">' +
                            //'<span>{{ item }}</span>' +
                            //'</li>' +
                            //'<li ng-class="{disabled: config.pageIndex == config.numberOfPages}" ng-click="nextPage()"><span>&raquo;</span></li>' +
                            //'</ul>' +

                            '<ul class="page-btn" ng-show="config.totalCount > 0">' +
                            '<li ng-class="{disabled: config.pageIndex == config.numberOfPages}" ng-click="changeCurrentPage(1)" ng-show="config.pageIndex >1"><span><i class="fa fa-fast-backward"></i></span></li>' +
                            '<li ng-class="{disabled: config.pageIndex == 1}" ng-click="prevPage()"><span>上一页</span></li>' +

                            '<li ng-repeat="item in pageList track by $index" ng-class="{active: item == config.pageIndex, separate: item == \'...\'}" ng-click="changeCurrentPage(item)">' +
                                '<span>[{{ item }}]</span>' +
                            '</li>' +

                            '<li ng-class="{disabled: config.pageIndex == config.numberOfPages}" ng-click="nextPage()"><span>下一页</span></li>' +
                            '<li ng-class="{disabled: config.pageIndex == config.numberOfPages}" ng-click="changeCurrentPage(config.numberOfPages)" ng-show="config.pageIndex < config.numberOfPages"><span><i class="fa fa-fast-forward"></i></span></li>' +
                            '</ul>' +

                            '<div class="page-total" ng-show="config.totalCount > 0">' +
                            //有输入框和下拉列表
                            //'第<input type="text" ng-model="jumpPageNum" ng-keyup="jumpToPage($event)"/>页 ' +
                            '每页<select ng-model="config.pageSize" ng-options="option for option in config.perPageOptions " ng-change="changeItemsPerPage()"></select>条，' +
                            //'/共<strong>{{ config.totalCount }}</strong>条' +

                            '当前页：<span class="info-index">{{config.pageIndex}}</span> 总页数：<span class="info-pages">{{config.numberOfPages}}</span>    记录总数：<span class="info-total">{{config.totalCount}}</span>' +
                            '</div>' +

                            //'<div class="page-total" ng-show="config.totalCount > 0" style="display: inline-block;">' +
                            //'第<input type="text" ng-model="jumpPageNum"  ng-keyup="jumpToPage($event)"/>页 ' +
                            //'每页<select ng-model="config.pageSize" ng-options="option for option in config.perPageOptions " ng-change="changeItemsPerPage()"></select>' +
                            //'/共<strong>{{ config.totalCount }}</strong>条' +
                            //'</div>' +
                            //'<div class="no-items" ng-show="config.totalCount <= 0">暂无数据</div>' +
                            '</div>',
                        replace: true,
                        scope: {
                            config: '=',
                        },
                        link: function (scope, element, attrs) {
                            // 变更当前页
                            scope.changeCurrentPage = function (item) {
                                if (item == '...') {
                                    return;
                                } else {
                                    scope.$emit('toChgChkItems', true);
                                    scope.config.pageIndex = item;
                                }
                            };

                            // 定义分页的长度必须为奇数 (default:9)
                            scope.config.pagesLength = parseInt(scope.config.pagesLength) ? parseInt(scope.config.pagesLength) : 9;
                            if (scope.config.pagesLength % 2 === 0) {
                                // 如果不是奇数的时候处理一下
                                scope.config.pagesLength = scope.config.pagesLength - 1;
                            }

                            // config.erPageOptions
                            if (!scope.config.perPageOptions) {
                                scope.config.perPageOptions = [5, 10, 15, 20, 30, 50];
                            }

                            //pageList数组
                            function getPagination() {
                                // config.pageIndex
                                scope.config.pageIndex = parseInt(scope.config.pageIndex) ? parseInt(scope.config.pageIndex) : 1;
                                // config.totalCount
                                scope.config.totalCount = parseInt(scope.config.totalCount);

                                // config.pageSize (default:10)
                                // 先判断一下本地存储中有没有这个值
                                if (scope.config.rememberPerPage) {
                                    if (!parseInt(localStorage[scope.config.rememberPerPage])) {
                                        localStorage[scope.config.rememberPerPage] = parseInt(scope.config.pageSize) ? parseInt(scope.config.pageSize) : 10;
                                    }
                                    scope.config.pageSize = parseInt(localStorage[scope.config.rememberPerPage]);
                                } else {
                                    scope.config.pageSize = parseInt(scope.config.pageSize) ? parseInt(scope.config.pageSize) : 10;
                                }

                                // 总页数
                                scope.config.numberOfPages = Math.ceil(scope.config.totalCount / scope.config.pageSize);

                                // judge pageIndex > scope.numberOfPages
                                if (scope.config.pageIndex < 1) {
                                    scope.config.pageIndex = 1;
                                }

                                if (scope.config.pageIndex > scope.config.numberOfPages) {
                                    scope.config.pageIndex = scope.config.numberOfPages;
                                }

                                // jumpPageNum
                                scope.jumpPageNum = scope.config.pageIndex;

                                // 如果pageSize在不在perPageOptions数组中，就把pageSize加入这个数组中
                                var perPageOptionsLength = scope.config.perPageOptions.length;
                                // 定义状态
                                var perPageOptionsStatus;
                                for (var i = 0; i < perPageOptionsLength; i++) {
                                    if (scope.config.perPageOptions[i] == scope.config.pageSize) {
                                        perPageOptionsStatus = true;
                                    }
                                }
                                // 如果pageSize在不在perPageOptions数组中，就把pageSize加入这个数组中
                                if (!perPageOptionsStatus) {
                                    scope.config.perPageOptions.push(scope.config.pageSize);
                                }

                                // 对选项进行sort
                                scope.config.perPageOptions.sort(function (a, b) { return a - b });

                                scope.pageList = [];
                                if (scope.config.numberOfPages <= scope.config.pagesLength) {
                                    // 判断总页数如果小于等于分页的长度，若小于则直接显示
                                    for (i = 1; i <= scope.config.numberOfPages; i++) {
                                        scope.pageList.push(i);
                                    }
                                } else {
                                    // 总页数大于分页长度（此时分为三种情况：1.左边没有...2.右边没有...3.左右都有...）
                                    // 计算中心偏移量
                                    var offset = (scope.config.pagesLength - 1) / 2;
                                    if (scope.config.pageIndex <= offset) {
                                        // 左边没有...
                                        for (i = 1; i <= offset + 1; i++) {
                                            scope.pageList.push(i);
                                        }
                                        scope.pageList.push('...');
                                        scope.pageList.push(scope.config.numberOfPages);
                                    } else if (scope.config.pageIndex > scope.config.numberOfPages - offset) {
                                        scope.pageList.push(1);
                                        scope.pageList.push('...');
                                        for (i = offset + 1; i >= 1; i--) {
                                            scope.pageList.push(scope.config.numberOfPages - i);
                                        }
                                        scope.pageList.push(scope.config.numberOfPages);
                                    } else {
                                        // 最后一种情况，两边都有...
                                        scope.pageList.push(1);
                                        scope.pageList.push('...');

                                        for (i = Math.ceil(offset / 2) ; i >= 1; i--) {
                                            scope.pageList.push(scope.config.pageIndex - i);
                                        }
                                        scope.pageList.push(scope.config.pageIndex);
                                        for (i = 1; i <= offset / 2; i++) {
                                            scope.pageList.push(scope.config.pageIndex + i);
                                        }

                                        scope.pageList.push('...');
                                        scope.pageList.push(scope.config.numberOfPages);
                                    }
                                }

                                if (scope.config.onChange) {
                                    scope.config.onChange();
                                }
                                scope.$parent.config = scope.config;
                            }

                            // prevPage
                            scope.prevPage = function () {
                                if (scope.config.pageIndex > 1) {
                                    scope.$emit('toChgChkItems', true);
                                    scope.config.pageIndex -= 1;
                                }
                            };
                            // nextPage
                            scope.nextPage = function () {
                                if (scope.config.pageIndex < scope.config.numberOfPages) {
                                    scope.$emit('toChgChkItems', true);
                                    scope.config.pageIndex += 1;
                                }
                            };

                            // 跳转页
                            scope.jumpToPage = function () {
                                scope.jumpPageNum = scope.jumpPageNum.replace(/[^0-9]/g, '');
                                if (scope.jumpPageNum !== '') {
                                    scope.config.pageIndex = scope.jumpPageNum;
                                }
                            };

                            // 修改每页显示的条数
                            scope.changeItemsPerPage = function () {
                                // 清除本地存储的值方便重新设置
                                if (scope.config.rememberPerPage) {
                                    localStorage.removeItem(scope.config.rememberPerPage);
                                }
                            };

                            scope.$watch(function () {
                                var newValue = scope.config.pageIndex + ' ' + scope.config.totalCount + ' ';
                                // 如果直接watch perPage变化的时候，因为记住功能的原因，所以一开始可能调用两次。
                                //所以用了如下方式处理
                                if (scope.config.rememberPerPage) {
                                    // 由于记住的时候需要特别处理一下，不然可能造成反复请求
                                    // 之所以不监控localStorage[scope.config.rememberPerPage]是因为在删除的时候会undefind
                                    // 然后又一次请求
                                    if (localStorage[scope.config.rememberPerPage]) {
                                        newValue += localStorage[scope.config.rememberPerPage];
                                    } else {
                                        newValue += scope.config.pageSize;
                                    }
                                } else {
                                    newValue += scope.config.pageSize;
                                }
                                return newValue;
                            }, getPagination);
                        }
                    };
                }]);
            }
        },
        gridViewFile: {//列表和图标扩展
            init: function (obj, gridPanelId) {//初始化
                /*******************************************
                说明：初始化视图表格
                        obj：初始化配置
                            {
                                isView: true,//是否显示左上角的切换图标（可不填，默认为false）
                                isSimPager: true,//是否同时显示简单分页按钮（可不填，默认为false）
                                isOrder: true,//是否显示序号列（可不填，默认为true）
                                isBtnHide: false,//列表模式时，是否隐藏所有的操作按钮（可不填，默认为false）
                                method: 'POST',//数据请求类型（可不填，默认为GET方式）
                                url: 'ViewData.ashx',//数据请求地址（必填）
                                data: { keyName: 'quber', count: 25 },//传递给后台服务的参数（json对象，可填）
                                pageSize: 26,//分页大小（可不填，默认为15）
                                titleCol: 'Name',//标题列名称（必填）
                                imgCol: 'Img',//图片列名称（必填）
                                titleClick: function (row) {//标题点击事件
                                    //row为这一行的数据对象（json）
                                },
                                imgClick: function (row) {//图片点击事件
                                    //row为这一行的数据对象（json）
                                },
                                col: [//显示的列集合
                                    //field：显示的数据列名称、title：列表的头部列名称、width：列宽度（可不填，类型为整形或字符串，如100或'100px'）
                                    //formatter：自定义该字段的回调函数，value：该字段返回值、row：当前行数据
                                    {
                                        field: 'Name', title: '名称<span style="color:#f00;">1001</span>', width: 200,
                                        sortable: true,
                                        formatter: function (value, row) {
                                            return '<span style="color:#f00;">' + value + '</span> - ' + row.Count;
                                        }
                                    },
                                    { field: 'Count', title: '数量' }
                                ],
                                optBtn: [//操作按钮集合
                                    //icon：图标名称（必填，可参照http://fontawesome.io/icons/）、title：提示内容（可不填）、event：事件函数（可不填，row：这一行的数据对象、event：事件对象）
                                    { icon: 'wrench', title: '设置', event: function (row, event) { alert(row.Name); } },
                                    //isShow：是否显示该按钮，默认为显示
                                    { 
                                        icon: 'pencil-square-o', title: '修改', event: function (row, event) { alert(row.Count); },
                                        isShow: function (row, event) { return row.IsStartTask; }
                                    }
                                ]
                            }
                        gridPanelId：数据呈现的容器Id（可不填，默认为gridPanel）
                ********************************************/
                obj = KXO.com.getObj(obj);
                obj.isView = KXO.com.getObj(obj.isView, 'bool', false);
                obj.isSimPager = KXO.com.getObj(obj.isSimPager, 'bool', false);
                obj.isOrder = KXO.com.getObj(obj.isOrder, 'bool', true);
                obj.isBtnHide = KXO.com.getObj(obj.isBtnHide, 'bool', false);
                obj.method = KXO.com.getObj(obj.method, 'str', 'GET');
                obj.data = KXO.com.getObj(obj.data);
                obj.pageSize = KXO.com.getObj(obj.pageSize, 'int', 15);
                obj.titleClick = KXO.com.getObj(obj.titleClick, 'fn');
                obj.imgClick = KXO.com.getObj(obj.imgClick, 'fn');
                obj.col = KXO.com.getObj(obj.col, 'arr');
                obj.optBtn = KXO.com.getObj(obj.optBtn, 'arr');

                //初始化Angular对象
                var myNg = angular.module('ngApp', ['kx.pager', 'ngCookies']);

                myNg.directive('kxGridFile', function () {
                    return {
                        restrict: 'EA',
                        replace: true,
                        templateUrl: '../../Content/NgTemplate/Grid.View.File.html',
                        link: function (sco, ele, attr) {
                            sco.$broadcast('sendChildGridAttr', attr);
                        }
                    };
                });
                myNg.directive('kxGridAttr', function () {
                    return {
                        restrict: 'A',
                        link: function (sco, ele, attr) {
                            sco.$on('sendChildGridAttr', function (event, data) {
                                angular.forEach(data, function (val, key, obj) {
                                    if (key != '$attr' && key != '$$element') {
                                        attr.$set(key, val);
                                    }
                                });
                            });
                        }
                    };
                });

                KXO.plu.ng.toHtml(myNg);

                myNg.controller('pageController', function ($scope, $http, $cookieStore) {

                    //console.log($cookieStore);

                    //设置所有配置
                    $scope.allObj = obj;

                    KXO.plu.gridViewFile.event($scope, $cookieStore, obj);
                    KXO.plu.gridViewFile.data($scope, $http, obj);
                });

                KXO.plu.gridViewFile.dir(myNg);
                KXO.plu.gridViewFile.pager();

                return myNg;
            },
            data: function ($scope, $http, obj) {//获取分页数据
                KXO.plu.ajax({
                    isLoad: false,
                    url: '../../Content/Handler/Common.ashx',
                    data: { action: 'SetUserOptBtns', moduleId: KXO.com.getUrlVal('mId') }
                }, function (data) {
                    $scope.userBtnQx = data;
                    //console.log(JSON.stringify(data));
                });

                //基础配置
                $scope.pagerConfig = {
                    pageIndex: 1,
                    pageSize: obj.pageSize
                };

                //获取数据
                $scope.getData = function (isSearchObj, searchSuccessFn) {
                    if ($scope.pagerConfig.pageIndex == 0) {
                        $scope.pagerConfig.pageIndex = 1;
                        return;
                    }

                    var doParams = angular.extend({
                        pageIndex: $scope.pagerConfig.pageIndex,
                        pageSize: $scope.pagerConfig.pageSize
                    }, $scope.allObj.data);
                    //查询所用
                    if (typeof isSearchObj != 'number') {
                        doParams = angular.extend(doParams, isSearchObj);
                    }

                    KXO.plu.ajaxPri({
                        url: '../../Content/Handler/Common.ashx',
                        chkLogin: false,
                        data: { action: 'GetUserInfo' }
                    }, function (data) {
                        if (data.Result == 120) {
                            KXO.dia.msg(data.Msg, {
                                icon: 'error',
                                endCallback: function () {
                                    //KXO.frm.getTopWin().window.location.href = '../../Login.aspx';
                                }
                            });

                            //跳转至登陆页
                            setTimeout(function () {
                                KXO.frm.getTopWin().window.location.href = '../../Login.aspx';
                            }, 1500);
                        } else {
                            //KXO.dia.load();
                            $http({
                                method: obj.method,
                                url: obj.url,
                                params: doParams
                            }).success(function (data, status, headers, config) {
                                if (data.total > 0) {
                                    //总条数
                                    $scope.pagerConfig.totalCount = data.total;
                                    //当前页原始数据
                                    $scope.dataList = data.list;

                                    //总页数
                                    $scope.totalPage = Math.ceil(data.total / $scope.pagerConfig.pageSize);

                                    //对从服务端获取到的分页数据按照配置的列进行排序
                                    $scope.getDataListSort = function () {
                                        var retData = [];
                                        if ($scope.showColsName.length > 0) {
                                            for (var i = 0; i < data.list.length; i++) {
                                                var dataSin = data.list[i];
                                                var sinObj = {};
                                                for (var j = 0; j < $scope.showColsName.length; j++) {
                                                    sinObj[$scope.showColsName[j]] = dataSin[$scope.showColsName[j]];
                                                    delete dataSin[$scope.showColsName[j]];
                                                }

                                                for (var it in dataSin) {
                                                    sinObj[it] = dataSin[it];
                                                }

                                                retData[i] = sinObj;
                                            }
                                        } else {
                                            retData = data.list;
                                        }
                                        return retData;
                                    }

                                    //当前页排序后数据
                                    $scope.dataListSort = $scope.getDataListSort();
                                } else {
                                    //$scope.pagerConfig.totalCount = 0;
                                    $scope.dataListSort = [];
                                }

                                if (typeof obj.success == 'function') {
                                    obj.success(data);
                                }
                                if (typeof searchSuccessFn == 'function') {
                                    searchSuccessFn(data);
                                }
                                //查询后重新初始化右键事件
                                if (typeof isSearchObj != 'number') {
                                    initRightKey();
                                }

                                //KXO.dia.loadClose();
                            }).error(function (data, status, headers, config) {
                                //KXO.dia.loadClose();
                            });
                        }
                    });
                };

                //图标模式下的分页事件
                $scope.iconPagerChg = function (isAdd) {
                    if (isAdd) {
                        if ($scope.pagerConfig.pageIndex < $scope.totalPage)
                            $scope.pagerConfig.pageIndex++;
                        else
                            KXO.dia.msg('已是最后一页！', { time: 1100, icon: 'info' });
                    } else {
                        if ($scope.pagerConfig.pageIndex > 1)
                            $scope.pagerConfig.pageIndex--;
                        else
                            KXO.dia.msg('已是第一页！', { time: 1100, icon: 'info' });
                    }
                }

                // 通过$watch、pageIndex和pageSize，当它们改变时重新获取数据
                $scope.$watch('pagerConfig.pageIndex + pagerConfig.pageSize', $scope.getData);
            },
            event: function ($scope, $cookieStore, obj) {//事件处理
                //切换视图事件
                $scope.viewList = false;//默认是否为列表
                $scope.viewTitle = '切换为图标模式';
                //设置过期时间为一天
                var expireDate = new Date();
                expireDate.setDate(expireDate.getDate() + 1);
                $scope.viewChg = function (isList) {
                    $scope.viewList = !isList;
                    $scope.viewTitle = $scope.viewList ? '切换为图标模式' : '切换为列表模式';
                    //cookie记录展现的状态
                    $cookieStore.put('ckFileIsViewList', $scope.viewList, { expires: expireDate });
                }
                //cookie记录展现的状态
                if ($cookieStore.get('ckFileIsViewList') != undefined) {
                    $scope.viewList = $cookieStore.get('ckFileIsViewList');
                } else {
                    $cookieStore.put('ckFileIsViewList', $scope.viewList, { expires: expireDate });
                }

                //自定义单元格数据
                $scope.formatCell = function (value, row, formatterFn) {
                    value = value == null || value == undefined ? '' : value;
                    var retVal = value;

                    if (typeof formatterFn == 'function') {
                        var forMatVal = formatterFn(value, row);
                        if (forMatVal != undefined && forMatVal != null && forMatVal.length > 0) {
                            retVal = forMatVal;
                        }
                    }

                    if (value == '2') {
                        console.log(JSON.stringify(row));
                    }

                    return retVal == null || retVal == undefined || retVal == 'null' ? '' : retVal;
                };

                //记录当前文件夹层级数
                $scope.curFolderLevel = 0;//0代表所有文件
                var thisDefaultFolderObj = { FolderLevel: 0, FileInfoId: '', FileName: '所有文件' };
                //记录当前文件夹对象
                $scope.curFolderObj = thisDefaultFolderObj;
                //当前文件夹层级集合
                $scope.folderNavs = [
                    thisDefaultFolderObj
                ];

                //导航点击事件
                $scope.folderChg = function (row) {
                    $scope.curFolderLevel = row.FolderLevel;
                    $scope.curFolderObj = row;

                    var newFolderNavs = [];
                    for (var i = 0; i < $scope.folderNavs.length; i++) {
                        if ($scope.folderNavs[i].FolderLevel <= $scope.curFolderLevel) {
                            newFolderNavs[i] = $scope.folderNavs[i];
                        }
                    }
                    $scope.folderNavs = newFolderNavs;
                    $scope.getFolderPath();

                    if (typeof obj.folderNavClick == 'function') {
                        obj.folderNavClick(row);
                    }
                }
                //返回上一级
                $scope.folderPreChg = function () {
                    if ($scope.folderNavs.length >= 2) {
                        //移除数组最后一个元素
                        $scope.folderNavs.pop();
                        $scope.curFolderLevel = $scope.folderNavs[$scope.folderNavs.length - 1].FolderLevel;
                        $scope.curFolderObj = $scope.folderNavs[$scope.folderNavs.length - 1];
                        if (typeof obj.folderNavClick == 'function') {
                            obj.folderNavClick($scope.folderNavs[$scope.folderNavs.length - 1]);
                        }

                        $scope.getFolderPath();
                    }
                }
                //获取文件夹路径
                $scope.getFolderPath = function () {
                    var folderPathNames = [];
                    for (var j = 1; j < $scope.folderNavs.length; j++) {
                        folderPathNames[j - 1] = $scope.folderNavs[j].FileName;
                    }
                    $scope.folderPathStr = folderPathNames.join('/');
                }


                //全选反选
                $scope.chkAll = false;//默认是否为全选
                $scope.chkTitle = '全选';
                $scope.chkChg = function (isAll) {
                    $scope.chkAll = !isAll;
                    $scope.chkTitle = $scope.viewList ? '全选' : '反选';
                }

                //列内容超出列宽时，显示完整数据
                $scope.mouseColHoverLeave = function (type, event) {
                    if (type == 'hover' && $(event.target)[0].offsetWidth < $(event.target)[0].scrollWidth) {
                        if (!$(event.target).hasClass('this-name-auto-show')) {
                            $(event.target).addClass('this-name-auto-show');
                        }
                    } else {
                        if ($(event.target).hasClass('this-name-auto-show')) {
                            $(event.target).removeClass('this-name-auto-show');
                        }
                    }
                };

                //obj.col数组中每个列默认所占的宽（百分比）
                $scope.showColWidth = 80 / obj.col.length + '%';
                var thisShowColsWidth = {},
                    thisShowColsName = [];
                for (var i = 0; i < obj.col.length; i++) {
                    thisShowColsWidth[obj.col[i]['field']] = obj.col[i]['width'] ? obj.col[i]['width'] : $scope.showColWidth;
                    thisShowColsName[i] = obj.col[i]['field'];
                }
                //obj.col数组中每个列在配置后所占的宽
                $scope.showDataColWidth = thisShowColsWidth;
                //初始化配置中所有显示的列名称数组
                $scope.showColsName = thisShowColsName;

                //检查哪些字段该显示
                $scope.chkCols = function (k) {
                    var result = false;

                    for (var i = 0; i < obj.col.length; i++) {
                        for (var item in obj.col[i]) {
                            if (item == 'field' && obj.col[i][item] === k) {
                                result = true;
                                break;
                            }
                        }
                    }

                    return result;
                }

                //按钮点击事件
                $scope.optClick = function (type, row, fn) {
                    if (type === 'title' && typeof obj.titleClick == 'function') {
                        $scope.dbRowTItleEvent(row);
                        obj.titleClick(row);
                    }
                    else if (type === 'img' && typeof obj.imgClick == 'function') {
                        obj.imgClick(row);
                    }
                    else if (type === 'row-dbclick' && typeof obj.rowDbClick == 'function') {
                        $scope.dbRowTItleEvent(row);
                        obj.rowDbClick(row);
                    }
                    else if (type === 'opt') {
                    }
                }

                //双击或点击标题执行的方法
                $scope.dbRowTItleEvent = function (row) {
                    //双击文件夹时，改变导航
                    if (row.IsFolder) {
                        var isExistItem = false;
                        for (var i = 0; i < $scope.folderNavs.length; i++) {
                            if ($scope.folderNavs[i].FolderLevel == row.FolderLevel) {
                                isExistItem = true;
                                break;
                            }
                        }

                        if (!isExistItem) {
                            $scope.folderNavs[$scope.folderNavs.length] = row;
                            $scope.curFolderLevel = row.FolderLevel;
                            $scope.curFolderObj = row;

                            $scope.getFolderPath();
                        }
                    }
                }

                //Angular验证方法
                $scope.checkData = function (type, val) {
                    var result = false;

                    if (type == 'num') {
                        result = angular.isNumber(val);
                    }
                    else if (type === 'arr') {
                        result = angular.isArray(val);
                    }
                    else if (type === 'obj') {
                        result = angular.isObject(val);
                    }
                    else if (type === 'str') {
                        result = angular.isString(val);
                    }
                    else if (type === 'fun') {
                        result = angular.isFunction(val);
                    }
                    else if (type === 'unde') {
                        result = angular.isUndefined(val);
                    }

                    return result;
                }
            },
            query: function (queryObj, searchSuccessFn, controllerName) {
                /*******************************************
                说明：查询数据
                        queryObj：查询参数（必填，JSON对象，如：{ keyName: 'quber1', count: 255 }）
                        controllerName：Angular控制器名称（可不填，默认为pageController）
                ********************************************/
                queryObj = KXO.com.getObj(queryObj);
                controllerName = KXO.com.getObj(controllerName, 'str', 'pageController');

                //通过controller来获取Angular应用
                var appElement = document.querySelector('[ng-controller=' + controllerName + ']');
                //获取$scope变量
                var $scope = angular.element(appElement).scope();

                $scope.getData(queryObj, searchSuccessFn);
            },
            reload: function (controllerName) {
                /*******************************************
                说明：刷新当前页数据
                        controllerName：Angular控制器名称（可不填，默认为pageController）
                ********************************************/
                controllerName = KXO.com.getObj(controllerName, 'str', 'pageController');
                //通过controller来获取Angular应用
                var appElement = document.querySelector('[ng-controller=' + controllerName + ']');
                //获取$scope变量
                var $scope = angular.element(appElement).scope();
                $scope.getData();
            },
            dir: function (thisNg) {//添加指令
                //图标模式时，鼠标滑过row显示操作按钮，离开时隐藏
                thisNg.directive('toggleIconOpt', function () {
                    return {
                        restrict: 'A',
                        scope: {
                            toggleIconOpt: '@'
                        },
                        link: function ($scope, $element) {
                            $element.on('mouseenter', function () {
                                $element.toggleClass($scope.toggleIconOpt);
                            });
                            $element.on('mouseleave', function () {
                                $element.toggleClass($scope.toggleIconOpt);
                            });
                            $element.on('click', function () {
                                $element.toggleClass('kx-row-active');

                                //alert($element.hasClass('kx-row-active'));
                            });
                        }
                    };
                });

                //图片不存在时，显示默认图片
                thisNg.directive('errSrc', function () {
                    return {
                        link: function (scope, element, attrs) {
                            element.bind('error', function () {
                                if (attrs.src != attrs.errSrc) {
                                    attrs.$set('src', attrs.errSrc);
                                }
                            });
                        }
                    }
                });
            },
            pager: function () {//分页扩展
                angular.module('kx.pager', []).directive('kxPager', [function () {
                    return {
                        restrict: 'EA',
                        template: '<div class="page-list">' +
                            //'<ul class="pager" ng-show="config.totalCount > 0" style="display: inline-block;">' +
                            //'<li ng-class="{disabled: config.pageIndex == 1}" ng-click="prevPage()"><span>&laquo;</span></li>' +
                            //'<li ng-repeat="item in pageList track by $index" ng-class="{active: item == config.pageIndex, separate: item == \'...\'}" ' +
                            //'ng-click="changeCurrentPage(item)">' +
                            //'<span>{{ item }}</span>' +
                            //'</li>' +
                            //'<li ng-class="{disabled: config.pageIndex == config.numberOfPages}" ng-click="nextPage()"><span>&raquo;</span></li>' +
                            //'</ul>' +

                            '<ul class="page-btn" ng-show="config.totalCount > 0">' +
                            '<li ng-class="{disabled: config.pageIndex == config.numberOfPages}" ng-click="changeCurrentPage(1)" ng-show="config.pageIndex >1"><span><i class="fa fa-fast-backward"></i></span></li>' +
                            '<li ng-class="{disabled: config.pageIndex == 1}" ng-click="prevPage()"><span>上一页</span></li>' +

                            '<li ng-repeat="item in pageList track by $index" ng-class="{active: item == config.pageIndex, separate: item == \'...\'}" ng-click="changeCurrentPage(item)">' +
                                '<span>[{{ item }}]</span>' +
                            '</li>' +

                            '<li ng-class="{disabled: config.pageIndex == config.numberOfPages}" ng-click="nextPage()"><span>下一页</span></li>' +
                            '<li ng-class="{disabled: config.pageIndex == config.numberOfPages}" ng-click="changeCurrentPage(config.numberOfPages)" ng-show="config.pageIndex < config.numberOfPages"><span><i class="fa fa-fast-forward"></i></span></li>' +
                            '</ul>' +

                            '<div class="page-total" ng-show="config.totalCount > 0">' +
                            //有输入框和下拉列表
                            //'第<input type="text" ng-model="jumpPageNum" ng-keyup="jumpToPage($event)"/>页 ' +
                            //'每页<select ng-model="config.pageSize" ng-options="option for option in config.perPageOptions " ng-change="changeItemsPerPage()"></select>' +
                            //'/共<strong>{{ config.totalCount }}</strong>条' +

                            '当前页：<span class="info-index">{{config.pageIndex}}</span> 总页数：<span class="info-pages">{{config.numberOfPages}}</span>    记录总数：<span class="info-total">{{config.totalCount}}</span>' +
                            '</div>' +

                            //'<div class="page-total" ng-show="config.totalCount > 0" style="display: inline-block;">' +
                            //'第<input type="text" ng-model="jumpPageNum"  ng-keyup="jumpToPage($event)"/>页 ' +
                            //'每页<select ng-model="config.pageSize" ng-options="option for option in config.perPageOptions " ng-change="changeItemsPerPage()"></select>' +
                            //'/共<strong>{{ config.totalCount }}</strong>条' +
                            //'</div>' +
                            //'<div class="no-items" ng-show="config.totalCount <= 0">暂无数据</div>' +
                            '</div>',
                        replace: true,
                        scope: {
                            config: '='
                        },
                        link: function (scope, element, attrs) {
                            // 变更当前页
                            scope.changeCurrentPage = function (item) {
                                if (item == '...') {
                                    return;
                                } else {
                                    scope.config.pageIndex = item;
                                }
                            };

                            // 定义分页的长度必须为奇数 (default:9)
                            scope.config.pagesLength = parseInt(scope.config.pagesLength) ? parseInt(scope.config.pagesLength) : 9;
                            if (scope.config.pagesLength % 2 === 0) {
                                // 如果不是奇数的时候处理一下
                                scope.config.pagesLength = scope.config.pagesLength - 1;
                            }

                            // config.erPageOptions
                            if (!scope.config.perPageOptions) {
                                scope.config.perPageOptions = [5, 10, 15, 20, 30, 50];
                            }

                            //pageList数组
                            function getPagination() {
                                // config.pageIndex
                                scope.config.pageIndex = parseInt(scope.config.pageIndex) ? parseInt(scope.config.pageIndex) : 1;
                                // config.totalCount
                                scope.config.totalCount = parseInt(scope.config.totalCount);

                                // config.pageSize (default:10)
                                // 先判断一下本地存储中有没有这个值
                                if (scope.config.rememberPerPage) {
                                    if (!parseInt(localStorage[scope.config.rememberPerPage])) {
                                        localStorage[scope.config.rememberPerPage] = parseInt(scope.config.pageSize) ? parseInt(scope.config.pageSize) : 10;
                                    }
                                    scope.config.pageSize = parseInt(localStorage[scope.config.rememberPerPage]);
                                } else {
                                    scope.config.pageSize = parseInt(scope.config.pageSize) ? parseInt(scope.config.pageSize) : 10;
                                }

                                // 总页数
                                scope.config.numberOfPages = Math.ceil(scope.config.totalCount / scope.config.pageSize);

                                // judge pageIndex > scope.numberOfPages
                                if (scope.config.pageIndex < 1) {
                                    scope.config.pageIndex = 1;
                                }

                                if (scope.config.pageIndex > scope.config.numberOfPages) {
                                    scope.config.pageIndex = scope.config.numberOfPages;
                                }

                                // jumpPageNum
                                scope.jumpPageNum = scope.config.pageIndex;

                                // 如果pageSize在不在perPageOptions数组中，就把pageSize加入这个数组中
                                var perPageOptionsLength = scope.config.perPageOptions.length;
                                // 定义状态
                                var perPageOptionsStatus;
                                for (var i = 0; i < perPageOptionsLength; i++) {
                                    if (scope.config.perPageOptions[i] == scope.config.pageSize) {
                                        perPageOptionsStatus = true;
                                    }
                                }
                                // 如果pageSize在不在perPageOptions数组中，就把pageSize加入这个数组中
                                if (!perPageOptionsStatus) {
                                    scope.config.perPageOptions.push(scope.config.pageSize);
                                }

                                // 对选项进行sort
                                scope.config.perPageOptions.sort(function (a, b) { return a - b });

                                scope.pageList = [];
                                if (scope.config.numberOfPages <= scope.config.pagesLength) {
                                    // 判断总页数如果小于等于分页的长度，若小于则直接显示
                                    for (i = 1; i <= scope.config.numberOfPages; i++) {
                                        scope.pageList.push(i);
                                    }
                                } else {
                                    // 总页数大于分页长度（此时分为三种情况：1.左边没有...2.右边没有...3.左右都有...）
                                    // 计算中心偏移量
                                    var offset = (scope.config.pagesLength - 1) / 2;
                                    if (scope.config.pageIndex <= offset) {
                                        // 左边没有...
                                        for (i = 1; i <= offset + 1; i++) {
                                            scope.pageList.push(i);
                                        }
                                        scope.pageList.push('...');
                                        scope.pageList.push(scope.config.numberOfPages);
                                    } else if (scope.config.pageIndex > scope.config.numberOfPages - offset) {
                                        scope.pageList.push(1);
                                        scope.pageList.push('...');
                                        for (i = offset + 1; i >= 1; i--) {
                                            scope.pageList.push(scope.config.numberOfPages - i);
                                        }
                                        scope.pageList.push(scope.config.numberOfPages);
                                    } else {
                                        // 最后一种情况，两边都有...
                                        scope.pageList.push(1);
                                        scope.pageList.push('...');

                                        for (i = Math.ceil(offset / 2) ; i >= 1; i--) {
                                            scope.pageList.push(scope.config.pageIndex - i);
                                        }
                                        scope.pageList.push(scope.config.pageIndex);
                                        for (i = 1; i <= offset / 2; i++) {
                                            scope.pageList.push(scope.config.pageIndex + i);
                                        }

                                        scope.pageList.push('...');
                                        scope.pageList.push(scope.config.numberOfPages);
                                    }
                                }

                                if (scope.config.onChange) {
                                    scope.config.onChange();
                                }
                                scope.$parent.config = scope.config;
                            }

                            // prevPage
                            scope.prevPage = function () {
                                if (scope.config.pageIndex > 1) {
                                    scope.config.pageIndex -= 1;
                                }
                            };
                            // nextPage
                            scope.nextPage = function () {
                                if (scope.config.pageIndex < scope.config.numberOfPages) {
                                    scope.config.pageIndex += 1;
                                }
                            };

                            // 跳转页
                            scope.jumpToPage = function () {
                                scope.jumpPageNum = scope.jumpPageNum.replace(/[^0-9]/g, '');
                                if (scope.jumpPageNum !== '') {
                                    scope.config.pageIndex = scope.jumpPageNum;
                                }
                            };

                            // 修改每页显示的条数
                            scope.changeItemsPerPage = function () {
                                // 清除本地存储的值方便重新设置
                                if (scope.config.rememberPerPage) {
                                    localStorage.removeItem(scope.config.rememberPerPage);
                                }
                            };

                            scope.$watch(function () {
                                var newValue = scope.config.pageIndex + ' ' + scope.config.totalCount + ' ';
                                // 如果直接watch perPage变化的时候，因为记住功能的原因，所以一开始可能调用两次。
                                //所以用了如下方式处理
                                if (scope.config.rememberPerPage) {
                                    // 由于记住的时候需要特别处理一下，不然可能造成反复请求
                                    // 之所以不监控localStorage[scope.config.rememberPerPage]是因为在删除的时候会undefind
                                    // 然后又一次请求
                                    if (localStorage[scope.config.rememberPerPage]) {
                                        newValue += localStorage[scope.config.rememberPerPage];
                                    } else {
                                        newValue += scope.config.pageSize;
                                    }
                                } else {
                                    newValue += scope.config.pageSize;
                                }
                                return newValue;
                            }, getPagination);
                        }
                    };
                }]);
            }
        },
        popup: function () {
            //注册kx.popup组件
            var kxPopupM = angular.module('kx.pop', []);
            kxPopupM.directive('kxPop', function ($http, $timeout) {
                return {
                    restrict: 'AE',
                    replace: true,
                    templateUrl: '../../Content/NgTemplate/Form.Popup.html',
                    scope: {},
                    link: function (scope, element, attr) {
                        //提示面板对象
                        var popupPanelObj = angular.element('.kx-pop .popup');

                        //属性配置
                        var configObj = {
                            //是否第一次初始化
                            isInit: false,
                            url: attr.url,
                            action: attr.action,
                            colName: attr.colName,
                            width: attr.width && attr.width.length > 0 && !isNaN(parseInt(attr.width)) ? parseInt(attr.width) : 550,
                            //分页大小：1-100范围内
                            pageSize: attr.pageSize && attr.pageSize.length > 0 && !isNaN(parseInt(attr.pageSize)) ? parseInt(attr.pageSize) >= 1 && parseInt(attr.pageSize) <= 100 ? parseInt(attr.pageSize) : 10 : 10,
                            //触发事件：focus、click、hover
                            on: attr.on && attr.on.length > 0 && (attr.on.toLowerCase() == 'focus' || attr.on.toLowerCase() == 'click' || attr.on.toLowerCase() == 'hover') ? attr.on.toLowerCase() : 'focus',
                            //控制器监听标识，便于在控制器中接收选择的项
                            onSelect: attr.onSelect,
                            //选择列表出现的位置
                            position: attr.position && attr.position.length > 0 ? attr.position : 'bottom center'
                        };
                        scope.config = configObj;
                        //console.log(scope.config)

                        //是否显示加载
                        scope.popupIsLoading = true;
                        //文本框的值
                        scope.popupVal = '';
                        //是否为升序排列
                        scope.popupAsc = true;
                        //当前页数、分页大小、总页数
                        scope.popupPager = {
                            pageIndex: 1,
                            pageSize: configObj.pageSize,
                            pageCount: 0,
                            pageKey: '',
                            noData: {
                                isShow: false,
                                msg: '暂无数据'
                            }
                        };

                        //初始化popup
                        element.popup({
                            popup: popupPanelObj,
                            on: 'click',
                            position: configObj.position,
                            onVisible: function () {
                                if (!scope.config.isInit) {
                                    scope.popupGet();
                                    scope.config.isInit = true;
                                }
                            },
                            onHidden: function () {
                            }
                        });

                        //选项点击事件
                        scope.popupClick = function (row) {
                            scope.popupVal = row[scope.config.colName];
                            scope.$emit(configObj.onSelect, row);
                            element.popup('hide');
                        };

                        //获取分页数据事件
                        scope.popupGet = function (isSearch) {
                            scope.popupIsLoading = true;
                            //是否为搜索按钮调用
                            if (isSearch) {
                                scope.popupPager.pageIndex = 1;
                            }

                            KXO.plu.ng.http({ http: $http, isLoad: false, url: scope.config.url, params: { action: scope.config.action, pageIndex: scope.popupPager.pageIndex, pageSize: scope.popupPager.pageSize, pageCol: scope.config.colName, pageKey: scope.popupPager.pageKey } }, function (data) {
                                scope.popupPager.noData.isShow = data.Data.Total <= 0;
                                scope.popupList = data.Data;
                                //获取总页数
                                scope.popupPager.pageCount = Math.ceil(data.Data.Total / scope.popupPager.pageSize);

                                $timeout(function () {
                                    scope.popupIsLoading = false;
                                }, 100);
                            });
                        };

                        //对已填委托单位数据进行排序
                        scope.popupSortClick = function () {
                            scope.popupAsc = !scope.popupAsc;
                        };

                        //上一页、下一页事件
                        scope.popupPagerClick = function (type) {
                            var oldPageIndex = scope.popupPager.pageIndex;

                            scope.popupPager.pageIndex = type == 'prev' ?
                                (oldPageIndex - 1) == 0 ? 1 : oldPageIndex - 1 :
                                type == 'next' ? ((oldPageIndex + 1) < scope.popupPager.pageCount ? oldPageIndex + 1 : scope.popupPager.pageCount) :
                                type == 'frist' ? 1 : scope.popupPager.pageCount;

                            if (oldPageIndex != scope.popupPager.pageIndex) {
                                scope.popupPager.noData.isShow = false;
                                scope.popupPager.noData.msg = '';
                                scope.popupGet();
                            } else {
                                scope.popupPager.noData.isShow = true;
                                scope.popupPager.noData.msg = type == 'prev' ? '已经是第一页了' : '已经是最后一页了';
                                $timeout(function () {
                                    scope.popupPager.noData.isShow = false;
                                }, 1500);
                            }
                        };
                    }
                };
            });
        },
        select: function () {
            //注册kx.select组件
            var kxSelectM = angular.module('kx.select', []);
            kxSelectM.directive('kxSelectFinish', function () {
                return {
                    link: function (scope, element, attr) {
                        //console.log(scope.$index)
                        //$last为true时，ng-repeat渲染完毕
                        if (scope.$last == true) {
                            scope.$eval(attr.kxSelectFinish);
                        }
                    }
                }
            });
            kxSelectM.directive('kxSelect', function ($http, $timeout) {
                return {
                    restrict: 'AE',
                    replace: true,
                    templateUrl: '../../Content/NgTemplate/Form.Select.html',
                    scope: {
                        //url: '@'
                    },
                    link: function (scope, element, attr) {
                        scope.config = {
                            //是否第一次初始化
                            isInit: false,
                            defaultText: attr.defaultText && attr.defaultText.length > 0 ? attr.defaultText : '请选择...',
                            url: attr.url,
                            action: attr.action,
                            colName: attr.colName,
                            width: attr.width && attr.width.length > 0 && !isNaN(parseInt(attr.width)) ? parseInt(attr.width) : 200,
                            isNumber: attr.isNumber && attr.isNumber.length > 0 && attr.isNumber.toLowerCase() == 'true' ? scope.$eval(attr.isNumber.toLowerCase()) : false,
                            //控制器监听标识，便于在控制器中接收选择的项
                            onSelect: attr.onSelect,
                        };
                        //console.log(scope.config)

                        //初始化dropdown
                        element.dropdown({
                            onShow: function () { }
                        }).on('click', function () {
                            if (!scope.config.isInit) {
                                scope.selectGet();
                                scope.config.isInit = true;
                            }
                        });

                        //获取数据
                        scope.selectGet = function () {
                            KXO.plu.ng.http({ http: $http, isLoad: false, url: scope.config.url, params: { action: scope.config.action } }, function (data) {
                                scope.selectList = data;
                            });
                        };

                        //显示下拉
                        scope.selectShow = function () {
                            $timeout(function () {
                                element.dropdown('show');
                            }, 1);
                        };

                        //选择事件
                        scope.selectSelClick = function (row) {
                            scope.$emit(scope.config.onSelect, row);
                        };
                    }
                };
            });
        },
        setScroll: function (htmlObj) {
            /*******************************************
            说明：设置滚动条样式
                    htmlObj：设置对象（如：#pro、.pro）
            ********************************************/
            htmlObj = htmlObj == undefined || htmlObj.length <= 0 ? 'html,.easyui-layout .panel-body' : htmlObj;
            $(htmlObj).niceScroll({
                zindex: 9999999,
                cursorwidth: '6px',
                cursorborder: "0",
                cursorcolor: "#50B9FF",
                cursoropacitymax: 1,
                scrollspeed: 20
            });
        },
        fileUp: function (uploadObj, formData, settingObj) {
            /*******************************************
            说明：文件上传
                    uploadObj：上传控件file的jQuery对象
                    formData：提交到服务器参数
                    settingObj：配置参数
                        {uploadLimit:200,queueSizeLimit:200,auto:false,multi:false,fileSizeLimit:'100MB',fileTypeExts:'*.gif; *.jpg; *.png',method:'POST',removeCompleted:false,onUploadSuccess:function(){},onQueueComplete:function(){}}
            ********************************************/
            settingObj = KXO.com.getObj(settingObj);

            //是否为多文件上传
            var isMulti = settingObj.multi == undefined ? KXC.uploadify.multi : settingObj.multi;

            uploadObj.uploadify({
                width: KXC.uploadify.width, height: KXC.uploadify.height, fileObjName: KXC.uploadify.fileObjName, fileTypeDesc: KXC.uploadify.fileTypeDesc, progressData: KXC.uploadify.progressData, removeTimeout: KXC.uploadify.removeTimeout, requeueErrors: KXC.uploadify.requeueErrors, successTimeout: KXC.uploadify.successTimeout, swf: KXC.uploadify.swf, uploader: KXC.uploadify.fileUper, queueID: KXC.uploadify.queueID, buttonText: KXC.uploadify.buttonText,
                uploadLimit: settingObj.uploadLimit == undefined ? KXC.uploadify.uploadLimit : settingObj.uploadLimit,
                queueSizeLimit: settingObj.queueSizeLimit == undefined ? KXC.uploadify.queueSizeLimit : settingObj.queueSizeLimit,
                auto: settingObj.auto == undefined ? KXC.uploadify.auto : settingObj.auto,
                multi: isMulti,
                removeCompleted: settingObj.removeCompleted == undefined ? KXC.uploadify.removeCompleted : settingObj.removeCompleted,
                fileSizeLimit: settingObj.fileSizeLimit == undefined ? KXC.uploadify.fileSizeLimit : settingObj.fileSizeLimit,
                fileTypeExts: settingObj.fileTypeExts == undefined ? KXC.uploadify.fileTypeExts : settingObj.fileTypeExts,
                method: settingObj.method == undefined ? KXC.uploadify.method : settingObj.method,
                formData: formData,

                //重写事件
                overrideEvents: ['onFallback', 'onSelectError', 'onUploadSuccess'],
                //事件
                onFallback: function () {
                    //没有兼容的flash时触发
                    KXO.dia.tip('您未安装Flash控件，无法上传图片！请安装Flash控件后再试。', 'error');
                    return;
                },
                onQueueComplete: function (queueData) {
                    //当队列中的所有文件全部完成上传时触发
                    //$('#lbtnUpload,#lbtnCancelUp').hide(500);
                    if (typeof settingObj.onQueueComplete == 'function') {
                        settingObj.onQueueComplete();
                    }
                    return;
                },
                onClearQueue: function (queueItemCount) {
                    //在调用cancel方法且传入参数*时触发→<a href="javascript:$('#uploadify').uploadify('cancel','*')">取消上传</a>
                    //$('#lbtnUpload,#lbtnCancelUp').hide(500);
                    return;
                },
                onSelect: function (file) {
                    //选择文件后触发
                    //$('#lbtnUpload,#lbtnCancelUp').show(500);

                    //只能上传单个文件时，再次选择时移除上次选择的文件
                    if (!isMulti) {
                        var itemLength = $('.fileUploadify .uploadify-queue-item').length;
                        if (itemLength > 1) {
                            $('.fileUploadify .uploadify-queue-item').eq(0).remove();
                        }
                    }
                },
                onSelectError: function (file, errorCode, errorMsg) {
                    //选择文件后出错时触发
                    switch (errorCode) {
                        case -100:
                            if (uploadObj.uploadify('settings', 'queueSizeLimit') > errorMsg)
                                KXO.dia.tip('上传的文件数量已经超出系统限制的' + errorMsg + '个文件！', 'error');
                            else
                                KXO.dia.tip('上传的文件队列数量已经超出系统限制的' + uploadObj.uploadify('settings', 'queueSizeLimit') + '个文件！', 'error');
                            break;
                        case -110:
                            KXO.dia.tip('文件 [' + file.name + '] 大小超出系统限制的' + uploadObj.uploadify('settings', 'fileSizeLimit') + '大小！', 'error');
                            break;
                        case -120:
                            KXO.dia.tip('文件 [' + file.name + '] 大小异常！', 'error');
                            break;
                        case -130:
                            KXO.dia.tip('文件 [' + file.name + '] 格式不正确！', 'error');
                            break;
                    }
                },
                onUploadSuccess: function (file, data, response) {
                    //每个文件上传成功后触发
                    //alert("id:" + file.id + " -索引:" + file.index + " -文件名称:" + file.name + " -文件大小:" + file.size + " -文件类型:" + file.type + " -创建日期:" + file.creationdate + " -修改日期:" + file.modificationdate + " -文件状态:" + file.filestatus + " –服务器端消息:" + data + " –是否上传成功:" + response);
                    data = JSON.parse(data);

                    if (typeof settingObj.onUploadSuccess == 'function') {
                        settingObj.onUploadSuccess(data);
                    }

                    var fileNames = $('#fileNames'),
                        filePaths = $('#filePaths'),
                        filePathsCut = $('#filePathsCut'),
                        fileSuffix = $('#fileSuffix'),
                        fileIsImg = $('#fileIsImg'),
                        fileDataId = $('#fileDataId'),
                        fileDataName = $('#fileDataName'),
                        fileInfoIdHid = $('#fileInfoIdHid');

                    //文件上传成功后触发事件
                    if (data.status) {
                        //设置图片是否上传状态（0：否、1：是）
                        filePaths.data('chk', 1);
                        if (!isMulti || (isMulti && KXC.uploadify.uploadLimit == 1)) {
                            //单个文件
                            fileNames.val(data.name);
                            filePaths.val(data.info);
                            filePathsCut.val(data.cutinfo);
                            fileSuffix.val(data.suffix);
                            fileIsImg.val(data.isImg);
                            fileDataId.val(data.dataId);
                            fileDataName.val(data.dataName);
                            fileInfoIdHid.val(data.infoid);
                            //console.log(filePaths.data('path'));
                        } else {
                            //多个文件
                            var fileName = fileNames.val(),
                                filePath = filePaths.val(),
                                filePathCut = filePathsCut.val(),
                                thisSuffix = fileSuffix.val(),
                                thisFileIsImg = fileIsImg.val(),
                                thisDataId = fileDataId.val(),
                                thisDataName = fileDataName.val(),
                                thisInfoIdHid = fileInfoIdHid.val();
                            fileName += fileName.length <= 0 ? data.name : '|' + data.name;
                            filePath += filePath.length <= 0 ? data.info : '|' + data.info;
                            filePathCut += filePathCut.length <= 0 ? data.cutinfo : '|' + data.cutinfo;
                            thisSuffix += thisSuffix.length <= 0 ? data.suffix : '|' + data.suffix;
                            thisFileIsImg += thisFileIsImg.length <= 0 ? data.isImg : '|' + data.isImg;
                            thisDataId += thisDataId.length <= 0 ? data.dataId : '|' + data.dataId;
                            thisDataName += thisDataName.length <= 0 ? data.dataName : '|' + data.dataName;
                            thisInfoIdHid += thisInfoIdHid.length <= 0 ? data.infoid : '|' + data.infoid;

                            //console.log('--------------------------------');
                            //console.log(filePaths.data('path'));
                            fileNames.val(fileName);
                            filePaths.val(filePath);
                            filePathsCut.val(filePathCut);
                            fileSuffix.val(thisSuffix);
                            fileIsImg.val(thisFileIsImg);
                            fileDataId.val(thisDataId);
                            fileDataName.val(thisDataName);
                            fileInfoIdHid.val(thisInfoIdHid);
                            //console.log(filePaths.data('path'));
                        }
                    } else {
                        //KXO.dia.tip(data.info, 'error');
                    }
                }
            });
        },
        fileUploadify: function (uploadObj, formData, settingObj) {
            /*******************************************
            说明：文件上传
                    uploadObj：上传控件file的jQuery对象
                    formData：提交到服务器参数
                    settingObj：配置参数
                        {uploadLimit:200,queueSizeLimit:200,auto:false,multi:false,fileSizeLimit:'100MB',fileTypeExts:'*.gif; *.jpg; *.png',method:'POST',removeCompleted:false,onUploadSuccess:function(){},onQueueComplete:function(){}}
            ********************************************/
            settingObj = KXO.com.getObj(settingObj);

            //是否为多文件上传
            var isMulti = settingObj.multi == undefined ? KXC.uploadify.multi : settingObj.multi;

            uploadObj.uploadify({
                width: KXC.uploadify.width, height: KXC.uploadify.height, fileObjName: KXC.uploadify.fileObjName, fileTypeDesc: KXC.uploadify.fileTypeDesc, progressData: KXC.uploadify.progressData, removeTimeout: KXC.uploadify.removeTimeout, requeueErrors: KXC.uploadify.requeueErrors, successTimeout: KXC.uploadify.successTimeout, swf: KXC.uploadify.swf, uploader: KXC.uploadify.fileUploader, queueID: KXC.uploadify.queueID, buttonText: KXC.uploadify.buttonText,
                uploadLimit: settingObj.uploadLimit == undefined ? KXC.uploadify.uploadLimit : settingObj.uploadLimit,
                queueSizeLimit: settingObj.queueSizeLimit == undefined ? KXC.uploadify.queueSizeLimit : settingObj.queueSizeLimit,
                auto: settingObj.auto == undefined ? KXC.uploadify.auto : settingObj.auto,
                multi: isMulti,
                removeCompleted: settingObj.removeCompleted == undefined ? KXC.uploadify.removeCompleted : settingObj.removeCompleted,
                fileSizeLimit: settingObj.fileSizeLimit == undefined ? KXC.uploadify.fileSizeLimit : settingObj.fileSizeLimit,
                fileTypeExts: settingObj.fileTypeExts == undefined ? KXC.uploadify.fileTypeExts : settingObj.fileTypeExts,
                method: settingObj.method == undefined ? KXC.uploadify.method : settingObj.method,
                formData: formData,

                //重写事件
                overrideEvents: ['onFallback', 'onSelectError', 'onUploadSuccess'],
                //事件
                onFallback: function () {
                    //没有兼容的flash时触发
                    KXO.dia.tip('您未安装Flash控件，无法上传图片！请安装Flash控件后再试。', 'error');
                    return;
                },
                onQueueComplete: function (queueData) {
                    //当队列中的所有文件全部完成上传时触发
                    //$('#lbtnUpload,#lbtnCancelUp').hide(500);
                    if (typeof settingObj.onQueueComplete == 'function') {
                        settingObj.onQueueComplete();
                    }
                    return;
                },
                onClearQueue: function (queueItemCount) {
                    //在调用cancel方法且传入参数*时触发→<a href="javascript:$('#uploadify').uploadify('cancel','*')">取消上传</a>
                    //$('#lbtnUpload,#lbtnCancelUp').hide(500);
                    return;
                },
                onSelect: function (file) {
                    //选择文件后触发
                    //$('#lbtnUpload,#lbtnCancelUp').show(500);

                    //只能上传单个文件时，再次选择时移除上次选择的文件
                    if (!isMulti) {
                        var itemLength = $('.fileUploadify .uploadify-queue-item').length;
                        if (itemLength > 1) {
                            $('.fileUploadify .uploadify-queue-item').eq(0).remove();
                        }
                    }
                },
                onSelectError: function (file, errorCode, errorMsg) {
                    //选择文件后出错时触发
                    switch (errorCode) {
                        case -100:
                            if (uploadObj.uploadify('settings', 'queueSizeLimit') > errorMsg)
                                KXO.dia.tip('上传的文件数量已经超出系统限制的' + errorMsg + '个文件！', 'error');
                            else
                                KXO.dia.tip('上传的文件队列数量已经超出系统限制的' + uploadObj.uploadify('settings', 'queueSizeLimit') + '个文件！', 'error');
                            break;
                        case -110:
                            KXO.dia.tip('文件 [' + file.name + '] 大小超出系统限制的' + uploadObj.uploadify('settings', 'fileSizeLimit') + '大小！', 'error');
                            break;
                        case -120:
                            KXO.dia.tip('文件 [' + file.name + '] 大小异常！', 'error');
                            break;
                        case -130:
                            KXO.dia.tip('文件 [' + file.name + '] 格式不正确！', 'error');
                            break;
                    }
                },
                onUploadSuccess: function (file, data, response) {
                    //每个文件上传成功后触发
                    //alert("id:" + file.id + " -索引:" + file.index + " -文件名称:" + file.name + " -文件大小:" + file.size + " -文件类型:" + file.type + " -创建日期:" + file.creationdate + " -修改日期:" + file.modificationdate + " -文件状态:" + file.filestatus + " –服务器端消息:" + data + " –是否上传成功:" + response);
                    data = JSON.parse(data);

                    if (typeof settingObj.onUploadSuccess == 'function') {
                        settingObj.onUploadSuccess(data);
                    }

                    var fileNames = $('#fileNames'),
                        filePaths = $('#filePaths');

                    //文件上传成功后触发事件
                    if (data.status) {
                        //设置图片是否上传状态（0：否、1：是）
                        filePaths.data('chk', 1);
                        if (!isMulti || (isMulti && KXC.uploadify.uploadLimit == 1)) {
                            //单个文件
                            fileNames.val(data.name);
                            filePaths.val(data.info);
                            //console.log(filePaths.data('path'));
                        } else {
                            //多个文件
                            var fileName = fileNames.val(),
                                filePath = filePaths.val();
                            fileName += fileName.length <= 0 ? data.name : '|' + data.name;
                            filePath += filePath.length <= 0 ? data.info : '|' + data.info;

                            //console.log('--------------------------------');
                            //console.log(filePaths.data('path'));
                            fileNames.val(fileName);
                            filePaths.val(filePath);
                            //console.log(filePaths.data('path'));
                        }
                    } else {
                        //KXO.dia.tip(data.info, 'error');
                    }
                }
            });
        },
        imgUploadify: function (uploadObj, formData, settingObj) {
            /*******************************************
            说明：文件上传
                    uploadObj：上传控件file的jQuery对象
                    formData：提交到服务器参数
                    settingObj：配置参数
                        {uploadLimit:200,queueSizeLimit:200,auto:false,multi:false,fileSizeLimit:'100MB',fileTypeExts:'*.gif; *.jpg; *.png',method:'POST',removeCompleted:false,onUploadSuccess:function(){},onQueueComplete:function(){}}
            ********************************************/
            settingObj = KXO.com.getObj(settingObj);

            //是否为多文件上传
            var isMulti = settingObj.multi == undefined ? KXC.uploadify.multi : settingObj.multi;

            uploadObj.uploadify({
                width: KXC.uploadify.width, height: KXC.uploadify.height, fileObjName: KXC.uploadify.fileObjName, fileTypeDesc: KXC.uploadify.fileTypeDesc, progressData: KXC.uploadify.progressData, removeTimeout: KXC.uploadify.removeTimeout, requeueErrors: KXC.uploadify.requeueErrors, successTimeout: KXC.uploadify.successTimeout, swf: KXC.uploadify.swf, uploader: KXC.uploadify.uploader, queueID: KXC.uploadify.queueID, buttonText: KXC.uploadify.buttonText,
                uploadLimit: settingObj.uploadLimit == undefined ? KXC.uploadify.uploadLimit : settingObj.uploadLimit,
                queueSizeLimit: settingObj.queueSizeLimit == undefined ? KXC.uploadify.queueSizeLimit : settingObj.queueSizeLimit,
                auto: settingObj.auto == undefined ? KXC.uploadify.auto : settingObj.auto,
                multi: settingObj.multi == undefined ? KXC.uploadify.multi : settingObj.multi,
                removeCompleted: settingObj.removeCompleted == undefined ? KXC.uploadify.removeCompleted : settingObj.removeCompleted,
                fileSizeLimit: settingObj.fileSizeLimit == undefined ? KXC.uploadify.fileSizeLimit : settingObj.fileSizeLimit,
                fileTypeExts: settingObj.fileTypeExts == undefined ? KXC.uploadify.fileTypeExts : settingObj.fileTypeExts,
                method: settingObj.method == undefined ? KXC.uploadify.method : settingObj.method,
                formData: formData,

                //重写事件
                overrideEvents: ['onFallback', 'onSelectError', 'onUploadSuccess'],
                //事件
                onFallback: function () {
                    //没有兼容的flash时触发
                    KXO.dia.tip('您未安装Flash控件，无法上传图片！请安装Flash控件后再试。', 'error');
                    return;
                },
                onQueueComplete: function (queueData) {
                    //当队列中的所有文件全部完成上传时触发
                    //$('#lbtnUpload,#lbtnCancelUp').hide(500);
                    if (typeof settingObj.onQueueComplete == 'function') {
                        settingObj.onQueueComplete();
                    }
                    return;
                },
                onClearQueue: function (queueItemCount) {
                    //在调用cancel方法且传入参数*时触发→<a href="javascript:$('#uploadify').uploadify('cancel','*')">取消上传</a>
                    //$('#lbtnUpload,#lbtnCancelUp').hide(500);
                    return;
                },
                onSelect: function (file) {
                    //选择文件后触发
                    //$('#lbtnUpload,#lbtnCancelUp').show(500);

                    //只能上传单个文件时，再次选择时移除上次选择的文件
                    if (!isMulti) {
                        var itemLength = $('.fileUploadify .uploadify-queue-item').length;
                        if (itemLength > 1) {
                            $('.fileUploadify .uploadify-queue-item').eq(0).remove();
                        }
                    }
                },
                onSelectError: function (file, errorCode, errorMsg) {
                    //选择文件后出错时触发
                    switch (errorCode) {
                        case -100:
                            if (uploadObj.uploadify('settings', 'queueSizeLimit') > errorMsg)
                                KXO.dia.tip('上传的文件数量已经超出系统限制的' + errorMsg + '个文件！', 'error');
                            else
                                KXO.dia.tip('上传的文件队列数量已经超出系统限制的' + uploadObj.uploadify('settings', 'queueSizeLimit') + '个文件！', 'error');
                            break;
                        case -110:
                            KXO.dia.tip('文件 [' + file.name + '] 大小超出系统限制的' + uploadObj.uploadify('settings', 'fileSizeLimit') + '大小！', 'error');
                            break;
                        case -120:
                            KXO.dia.tip('文件 [' + file.name + '] 大小异常！', 'error');
                            break;
                        case -130:
                            KXO.dia.tip('文件 [' + file.name + '] 格式不正确！', 'error');
                            break;
                    }
                },
                onUploadSuccess: function (file, data, response) {
                    //每个文件上传成功后触发
                    //alert("id:" + file.id + " -索引:" + file.index + " -文件名称:" + file.name + " -文件大小:" + file.size + " -文件类型:" + file.type + " -创建日期:" + file.creationdate + " -修改日期:" + file.modificationdate + " -文件状态:" + file.filestatus + " –服务器端消息:" + data + " –是否上传成功:" + response);
                    data = JSON.parse(data);

                    if (typeof settingObj.onUploadSuccess == 'function') {
                        settingObj.onUploadSuccess(data);
                    }

                    var imgPanel = $('#upload-img-panel');

                    //单个文件上传成功后触发事件
                    if (data.status) {
                        var isCut = KXO.com.getObj(settingObj.isCut, 'bool', false);
                        var imgPathInfo = isCut ? data.cut : data.old;

                        //设置图片是否上传状态（0：否、1：是）
                        imgPanel.data('chk', 1);
                        if (!isMulti || (isMulti && KXC.uploadify.uploadLimit == 1)) {
                            //单个文件
                            $('#showImgDefault').attr('src', imgPathInfo);
                            imgPanel.data('path', imgPathInfo);
                            imgPanel.data('pathcut', data.cut);
                            imgPanel.data('name', data.name);
                            //console.log(imgPanel.data('path'));
                        } else {
                            //多个文件
                            var imgPath = imgPanel.data('path'),
                                imgPathCut = imgPanel.data('pathcut'),
                                imgName = imgPanel.data('name');
                            imgPath += imgPath.length <= 0 ? data.old : '|' + data.old;
                            if (isCut) {
                                imgPathCut += imgPathCut.length <= 0 ? data.cut : '|' + data.cut;
                            }
                            imgName += imgName.length <= 0 ? data.name : '|' + data.name;
                            //将默认图片隐藏
                            $('#showImgDefault').hide();
                            //将图片展示到图片显示区域
                            var thisImg = '<img src="' + imgPathInfo + '" alt="KX" />';
                            imgPanel.append(thisImg);

                            //console.log('--------------------------------');
                            //console.log(imgPanel.data('path'));
                            imgPanel.data('path', imgPath);
                            imgPanel.data('pathcut', imgPathCut);
                            imgPanel.data('name', imgName);
                            //console.log(imgPanel.data('path'));
                        }
                    } else {
                        KXO.dia.tip(data.info, 'error');
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
                obj = KXO.com.getObj(obj);
                obj.path = KXO.com.getObj(obj.path, 'str', '../../');
                obj.isTopPath = KXO.com.getObj(obj.isTopPath, 'bool', false);
                obj.chkLogin = KXO.com.getObj(obj.chkLogin, 'bool', true);
                obj.method = KXO.com.getObj(obj.method, 'string', 'GET');
                obj.isLoad = KXO.com.getObj(obj.isLoad, 'bool', false);
                obj.params = KXO.com.getObj(obj.params);
                obj.data = KXO.com.getObj(obj.data);

                if (obj.chkLogin) {
                    KXO.plu.ajaxPri({
                        url: (obj.isTopPath ? '' : obj.path) + 'Content/Handler/Common.ashx',
                        chkLogin: false,
                        data: { action: 'GetUserInfo' }
                    }, function (data) {
                        if (data.Result == 120) {
                            KXO.dia.msg(data.Msg, {
                                icon: 'error',
                                endCallback: function () {
                                    //KXO.frm.getTopWin().window.location.href = (obj.isTopPath ? '' : '../../')+'Login.aspx';
                                }
                            });

                            //跳转至登陆页
                            setTimeout(function () {
                                KXO.frm.getTopWin().window.location.href = (obj.isTopPath ? '' : '../../') + 'Login.aspx';
                            }, 1500);
                        } else {
                            KXO.plu.ng.httpPri(obj, successCallback);
                        }
                        //console.log(JSON.stringify(data));
                    });
                } else {
                    KXO.plu.ng.httpPri(obj, successCallback);
                }
            },
            httpPri: function (obj, successCallback) {
                if (obj.isLoad) {
                    KXO.dia.load();
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
                        KXO.dia.loadClose();
                    }
                }).error(function (data, status, headers, config) {
                    if (obj.isLoad) {
                        KXO.dia.loadClose();
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
            dirDate: function (ngApp, format) {
                /*******************************************
                说明：集成My97日期控件
                        ngApp：Angular初始化对象
                用法：只需要在DOM中增加date-picker属性即可
                ********************************************/
                format = KXO.com.getObj(format, 'str', 'yyyy-MM-dd');

                ngApp.directive('datePicker', function ($parse) {
                    return {
                        restrict: 'A',
                        require: 'ngModel',
                        scope: {
                            minDate: '@',
                            picked: '&picked'
                        },
                        link: function (scope, element, attr, ngModel) {
                            //如果输入框中有format属性，则以属性的format为主
                            if (attr.format && format.length > 0) {
                                format = attr.format;
                            }
                            element.val(ngModel.$viewValue);

                            function onPicking(dp) {
                                var date = dp.cal.getNewDateStr();
                                scope.$apply(function () {
                                    ngModel.$setViewValue(date);
                                });
                            }

                            element.on({
                                click: function () {
                                    WdatePicker({
                                        onpicking: onPicking,
                                        onpicked: function (obj) {
                                            var dateObj = { newDate: obj.cal.getNewDateStr(), oldDate: obj.cal.oldValue }

                                            if (attr.picked && attr.picked.length > 0) {
                                                var fn = $parse(scope.picked);
                                                fn(dateObj);
                                            }
                                            //console.log(dateObj)
                                        },
                                        dateFmt: format
                                    });
                                },
                                keyup: function () {
                                    ngModel.$setViewValue(element.val());
                                }
                            });
                        }
                    };
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
    frm: {//表单方法或事件
        upload: function (obj, type) {
            /*******************************************
            说明：上传文件方法
                    obj：{title:'上传文件',savePath:'',multi:true,suffix:'*.*'} =>上传文件参数
                            {title:'上传图片',savePath:'',multi:true,suffix:'*.gif;*.jpg;*.png;*.bmp;',isCut:true,width:100,height:100} =>上传图片参数
                        title：窗体标题（可不填，默认为“上传文件”）
                        savePath：文件或图片保存路径（相对路径）
                        multi：是否允许多选（可不填，默认为true）
                        suffix：允许上传的文件类型（可不填，默认为*.*或*.gif;*.jpg;*.png;*.bmp;）
                        isCut：是否生成缩略图（可不填，默认为true）
                        width：缩略图宽度（可不填，默认为100像素）
                        height：缩略图高度（可不填，默认为100像素）
                    type：img或file（可不填，默认为file）
            ********************************************/
            obj = KXO.com.getObj(obj);
            type = KXO.com.getObj(type, 'string', 'file');
            var uploadUrl = '',
                winIcon = 'picture-o';

            if (type == 'file') {
                winIcon = 'file-o';
                obj.title = KXO.com.getObj(obj.title, 'string', '上传文件');
                obj.multi = KXO.com.getObj(obj.multi, 'bool', true);
                obj.suffix = KXO.com.getObj(obj.suffix, 'string', '*.*');
                uploadUrl = 'Content/ComPage/FileUpload.aspx?savePath=' + obj.savePath + '&multi=' + (obj.multi ? 1 : 0) + '&suffix=' + obj.suffix;
            } else {
                obj.title = KXO.com.getObj(obj.title, 'string', '上传图片');
                obj.multi = KXO.com.getObj(obj.multi, 'bool', true);
                obj.suffix = KXO.com.getObj(obj.suffix, 'string', '*.gif;*.jpg;*.png;*.bmp;');
                obj.isCut = KXO.com.getObj(obj.isCut, 'bool', true);
                obj.width = KXO.com.getObj(obj.width, 'num', 100);
                obj.height = KXO.com.getObj(obj.height, 'num', 100);
                var curParams = obj.isCut ? '&isCut=' + (obj.isCut ? 1 : 0) + '&width=' + obj.width + '&height=' + obj.height : '';
                uploadUrl = 'Content/ComPage/ImgUpload.aspx?savePath=' + obj.savePath + '&multi=' + (obj.multi ? 1 : 0) + curParams + '&suffix=' + obj.suffix;
            }

            KXO.frm.openWin(uploadUrl, { title: obj.title, width: 1200, height: 550, icon: winIcon });
        },
        uploadFile: function (obj, type) {
            /*******************************************
            说明：上传文件方法
                    obj：{multi:true,dataId:'611179A3-B8FB-48B2-9100-ABF110E4B282',dataName:'UserName'} =>上传文件参数
                        multi：是否允许多选（可不填，默认为true）

                        isXcjc：是否为现场检测登记的文件，默认为false
                        xcjcType：添加（add）还是修改（update），默认为add
                        xcjcId：修改时的文件Id（File_Info表的主键Id）

                        dataId：模块数据Id（多个时使用逗号分隔）
                        dataName：模块数据字段名称

                        setFileType：调用父页面的setFile方法的方式（1：正常、2：父页面中iframe页面中的方法）

                    type：img或file（可不填，默认为file）
            ********************************************/
            obj = KXO.com.getObj(obj);
            obj.multi = KXO.com.getObj(obj.multi, 'bool', true);

            obj.isXcjc = KXO.com.getObj(obj.isXcjc, 'bool', false);
            obj.xcjcType = KXO.com.getObj(obj.xcjcType, 'str', 'add');
            obj.xcjcId = KXO.com.getObj(obj.xcjcId, 'str', '');

            obj.dataId = KXO.com.getObj(obj.dataId, 'str', '');
            obj.dataName = KXO.com.getObj(obj.dataName, 'str', '');

            obj.setFileType = KXO.com.getObj(obj.setFileType, 'int', 1);

            type = KXO.com.getObj(type, 'string', 'file');

            var winIcon = 'picture-o';

            if (type == 'file') {
                winIcon = 'file-o';
                obj.title = KXO.com.getObj(obj.title, 'string', '上传文件');
            } else {
                obj.title = KXO.com.getObj(obj.title, 'string', '上传图片');
            }
            var uploadUrl = '/Content/ComPage/FileUploadConNew.aspx?dataId=' + obj.dataId + '&dataName=' + obj.dataName + '&upType=' + type +
                '&multi=' + (obj.multi ? 1 : 0) +
                '&isXcjc=' + (obj.isXcjc ? 1 : 0) +
                '&xcjcType=' + obj.xcjcType +
                '&xcjcId=' + obj.xcjcId +
                '&setFileType=' + obj.setFileType;
            KXO.frm.openWin(uploadUrl, { title: obj.title, width: 860, height: 560, icon: winIcon }); //1200  550
        },
        downFileChk: function (name, suffix, path, chkLogin, pathArr) {
            /*******************************************
            说明：下载文件前检查
                    name：文件名称
                    suffix：文件后缀名
                    path：文件地址
                    chkLogin：是否检查登录
                    pathArr：['../','../../']
            ********************************************/
            chkLogin = KXO.com.getObj(chkLogin, 'bool', true);

            KXO.plu.ajax({
                url: (pathArr ? pathArr[0] : '../') + 'FileCon/GetData.ashx',
                chkLogin: chkLogin,
                data: { action: 'chkFileIsExist', filePath: path }
            }, function (data) {
                if (!data.result) {
                    KXO.dia.msg(data.msg, 'error');
                } else {
                    KXO.frm.downFile((pathArr ? pathArr[1] : '../../') + 'Content/Handler/DownFile.ashx?fileName=' + name + '.' + suffix + '&filePath=' + path);
                }
            });
        },
        downFileUnCk: function (name, path) {
            /*******************************************
            说明：下载文件前检查
                    name：文件名称                   
                    path：文件地址
            ********************************************/
            KXO.frm.downFile('../../Content/Handler/DownFile.ashx?fileName=' + name + '&filePath=' + path);
        },
        downFile: function (url) {
            /*******************************************
            说明：下载文件
                    url：下载文件请求地址
            ********************************************/
            if (typeof (KXO.frm.downFile.iframe) == "undefined") {
                var iframe = document.createElement("iframe");
                KXO.frm.downFile.iframe = iframe;
                document.body.appendChild(KXO.frm.downFile.iframe);
            }
            KXO.frm.downFile.iframe.src = url;
            KXO.frm.downFile.iframe.style.display = "none";
        },
        chkForm: function (formId) {
            /*******************************************
            说明：检查表单是否通过验证
                    formId：form表单Id
            ********************************************/
            formId = KXO.com.getObj(formId, 'string', 'thisForm');
            return $('#' + formId).isValid();
        },
        doPage: function (type, obj, dgType) {
            /*******************************************
            说明：添加、修改、查看和删除操作入口
                    type：add：添加、modify|update：修改、view：查看、delete|del：删除
                    obj：{url:'',title:'',width:400,height:200,dgObj:$('#gridId'),keyId:'Id',delCallback:function(){},cancelCallback:function(){}}
                        url：添加修改查看时的url窗体地址，删除时的请求地址
                        title：添加修改查看时的窗体标题
                        width：添加修改查看时的窗体宽度
                        height：添加修改查看时的窗体高度
                        dgObj：删除时的表格对象
                        keyId：删除数据的主键Id
                        delCallback：删除时的回调函数
                        cancelCallback：添加修改查看时窗体关闭后的回调函数
                    dgType：dg：datagrid、edg：edatagrid、tg：treegrid（默认为dg）
            ********************************************/
            dgType = dgType == undefined || dgType.length <= 0 ? 'dg' : dgType;
            obj.width = KXO.com.getObj(obj.width, 'num', 1000);
            obj.height = KXO.com.getObj(obj.height, 'num', 450);

            if (type === 'add' || type === 'modify' || type === 'update' || type === 'view') {
                var urlOType = obj.url.indexOf('?') === -1 ? '?oType=' + type : '&oType=' + type;
                obj.url = obj.url + urlOType + '&keyId=' + KXO.plu.grid.get(obj.dgObj, obj.keyId).str;
            }

            if (type === 'add') {
                KXO.frm.openWin(obj.url, { title: obj.title, width: obj.width, height: obj.height, cancelCallback: obj.cancelCallback });
                return;
            }
            var typeName = type === 'modify' || type === 'update' ? '修改' : type === 'view' ? '查看' : type === 'delete' || type === 'del' ? '删除' : '操作';
            if (KXO.plu.grid.get(obj.dgObj, obj.keyId).obj.length <= 0) {
                KXO.dia.msg('请勾选需要' + typeName + '的数据！', { shift: 6, icon: 'error', time: 2000 });
                return;
            }
            if (type === 'modify' || type === 'update' || type === 'view') {
                if (KXO.plu.grid.get(obj.dgObj, obj.keyId).obj.length > 1) {
                    KXO.dia.msg('只能' + typeName + '1条数据，当前已勾选<span style="color:#e4393c;">&nbsp;' + KXO.plu.grid.get(obj.dgObj, obj.keyId).obj.length + '&nbsp;</span>条！', { shift: 6, icon: 'error', time: 2500 });
                    return;
                }
                KXO.frm.openWin(obj.url, { title: obj.title, width: obj.width, height: obj.height, cancelCallback: obj.cancelCallback });
            } else if (type === 'delete' || type === 'del') {
                KXO.dia.confirm('确定要删除勾选的数据？', function () {
                    KXO.plu.ajax({
                        doType: '删除', url: obj.url, data: mvcParamMatch({ list: KXO.plu.grid.get(obj.dgObj, obj.keyId).obj })
                    }, function (data) {
                        if (typeof (obj.delCallback) == 'function') {
                            obj.delCallback(data);
                        }
                        //定义提示信息和图标
                        var retTip = data.Result === 100 ? data.Msg != null && data.Msg != undefined && data.Msg.length > 0 ? data.Msg : '数据删除成功！' : '数据删除失败，请稍后再试！',
                            retIcon = data.Result === 100 ? 'right' : 'error';
                        KXO.dia.msg(retTip, {
                            icon: retIcon,
                            endCallback: function () {
                                if (data.Result === 100) {
                                    //刷新列表数据
                                    KXO.plu.grid.reload(obj.dgObj, dgType);
                                }
                            }
                        });
                    });
                });
            }
        },
        submit: function (formObj, obj) {
            /*******************************************
            说明：提交表单
                    formObj：form的jQuery对象
                    obj：{url:'',onSubmit:function(param){},success:function(data){},loadType:1}
                        url：表单提交地址
                        onSubmit：表单提交前的回调函数，可传递额外的参数
                        success：表单提交成功过后的回调函数
                        isLoad：是否显示等待效果（加载层，可不填，默认为true）
                        loadType：加载层类型（可不填，默认为layer[1]，2为easyui加载层效果）
            ********************************************/
            obj.isLoad = KXO.com.getObj(obj.isLoad, 'bool', true);
            obj.loadType = KXO.com.getObj(obj.loadType, 'num', 1);

            //显示遮罩层
            var loadIndex = 0;
            if (obj.isLoad) {
                if (obj.loadType === 1) {
                    loadIndex = KXO.dia.load();
                } else {
                    parent.$.messager.progress({ text: '数据' + obj.doType + '中，请稍后...' });
                }
            }
            formObj.form('submit', {
                url: obj.url,
                onSubmit: function (param) {
                    //增加额外参数
                    if (typeof (obj.onSubmit) == 'function') { obj.onSubmit(param); }

                    //验证表单是否正确
                    var isRight = formObj.form('enableValidation').form('validate');

                    if (!isRight) {
                        //关闭遮罩层
                        if (obj.isLoad) {
                            if (obj.loadType === 1) {
                                KXO.dia.loadClose(loadIndex);
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
                            KXO.dia.loadClose(loadIndex);
                        } else {
                            parent.$.messager.progress('close');
                        }
                    }
                }
            });
        },
        getWin: function (type, layNo) {
            /*******************************************
            说明：获取操作窗体对象（Easyui Tab中当前操作的窗体）
                    type：不传递或则为空，则表示获取系统主页面name=ifm的iframe中当前操作的窗体；
                              传递为lay时，则表示layer弹出多层（至少2层）窗体时，获取最顶层的下一层窗体对象
                    layNo：当type为lay时layer的第几层
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

                //获取指定第几层
                if (layNo > 0 && layNo <= times.length) {
                    layObj = parent.$('#layui-layer' + times[layNo - 1]);
                }

                if (layObj && layObj.find('iframe').length > 0) {
                    curWin = layObj.find('iframe')[0].contentWindow;
                }
            } else {//当前编辑窗体对象
                curWin = KXO.frm.getTopWin().ifm;
            }

            return curWin;
        },
        openWin: function (url, obj) {
            /*******************************************
            说明：弹出窗体
                    url：窗体页面地址（相对路径，相对于web的根目录）
                    obj：{title:'',icon:'th-large',width:800,height:400,shift:0,cancelCallback:function(){}}
                        id：弹出窗体的唯一性
                        shade：即弹层外区域。默认是0.3透明度的黑色背景（'#000'）。如果你想定义别的颜色，可以shade: [0.8, '#393D49']；如果你不想显示遮罩，可以shade: 0
                        title：窗体标题（可不填，默认为空）
                        icon：窗体左上角图标样式类名称（可不填，默认为th-large）
                                  该图标样式类名称可http://fontawesome.io/icons/在此查看
                        width：窗体宽度（可不填，默认为800px）
                        height：窗体高度（可不填，默认为400px）
                        shift：窗体出现的动画方式：0-6可选择，默认0
                        isSample：是否以简单模式打开窗体（默认为false）
                        isFull：是否全屏（默认为false）
                        isMaxmin：是否显示最大最小化按钮（默认为false）
                        isClose：是否显示关闭按钮（默认为true）
                        shadeClose：是否点击阴影处关闭窗体（默认为false）
                        isCloseReturn：是否启用关闭右上角按钮，当cancelCallback返回bool类型并且为false时，点击关闭按钮不关闭窗体
                        cancelCallback：关闭窗体后的回调方法
                        sucCallback：窗体显示弹出后的回调函数
            ********************************************/
            url = KXO.com.getObj(url, 'str');
            obj = KXO.com.getObj(obj);

            var seeClientH = KXO.frm.getTopWin().document.documentElement.clientHeight,
                seeClientW = KXO.frm.getTopWin().document.documentElement.clientWidth;

            obj.id = KXO.com.getObj(obj.id, 'str', '');
            obj.title = KXO.com.getObj(obj.title, 'str', '&nbsp;');
            obj.icon = KXO.com.getObj(obj.icon, 'str', 'th-large');
            obj.width = KXO.com.getObj(obj.width, 'num', 800);
            obj.height = KXO.com.getObj(obj.height, 'num', 400);
            obj.shift = KXO.com.getObj(obj.shift, 'num', 0);
            obj.isSample = KXO.com.getObj(obj.isSample, 'bool', false);
            obj.isFull = KXO.com.getObj(obj.isFull, 'bool', false);
            obj.isMaxmin = KXO.com.getObj(obj.isMaxmin, 'bool', false);
            obj.isClose = KXO.com.getObj(obj.isClose, 'bool', true);
            obj.shadeClose = KXO.com.getObj(obj.shadeClose, 'bool', false);
            obj.isCloseReturn = KXO.com.getObj(obj.isCloseReturn, 'bool', false);

            var clientH = seeClientH > obj.height ? (seeClientH - obj.height) / 2 : 0;

            //实现最大化效果，这里没有调用layer.full方法来实现的原因在于浏览器打印取消后，最大化窗口会往下移
            var curAreaHeight = obj.isFull ? seeClientH - 0.1 : (obj.height >= seeClientH ? seeClientH : obj.height),
                curAreaWidth = obj.isFull ? seeClientW - 0.1 : obj.width;
            clientH = obj.isFull ? 0.1 : clientH;

            var thisINdex = KXO.frm.getTopWin().layer.open({
                id: obj.id,
                shade: obj.shade == undefined ? [0.3, '#000'] : obj.shade,
                offset: clientH + 'px',
                shadeClose: obj.shadeClose,
                type: 2, skin: 'layer-ext-moon', fix: true, maxmin: obj.isMaxmin, moveType: 1, winIcon: obj.icon,
                title: !obj.isSample ? obj.title : false, shift: obj.shift, content: url, closeBtn: obj.isClose ? (!obj.isSample ? 1 : 2) : 0,
                area: [curAreaWidth + 'px', curAreaHeight + 'px'],
                cancel: function (index) {
                    if (typeof (obj.cancelCallback) == 'function') {
                        //return false：不关闭窗体
                        if (obj.isCloseReturn) {
                            var ret = obj.cancelCallback();

                            if (typeof ret == 'boolean') {
                                return ret;
                            }
                        } else {
                            obj.cancelCallback();
                        }
                    }
                },

                //zIndex: KXO.frm.getTopWin().layer.zIndex,
                success: function (layerObj, index) {

                    //打开弹窗成功后的回调 layerObj 为弹窗节点                  
                    var style = localStorage.getItem("cookieStyle");
                    if (layerObj.find("iframe").contents().find("#styleID").length == 0) {
                        var linkEle = $("<link rel='stylesheet' id='styleID'>");
                        if (style) {
                            linkEle.attr("href", "../../common/common" + style + ".css");
                        } else {
                            linkEle.attr("href", "../../common/common.css");
                        }

                        linkEle.appendTo(layerObj.find("iframe").contents().find("head"));
                    } else {
                        layerObj.find("iframe").contents().find("#styleID").attr("href", "../../common/common" + style + ".css");
                        //$("#Iframe1").contents().find("iframe").contents().find("#styleID").attr("href", "../../common/common" + style + ".css");
                    }



                    if (typeof (obj.sucCallback) == 'function') {
                        obj.sucCallback(layerObj, index);
                    }

                    //此处的目的在于设置在弹出多窗口并且没有遮罩层时，点击底层的窗体置顶
                    //KXO.frm.getTopWin().layer.setTop(layerObj);
                }
            });
            //if (obj.isFull) {
            //    KXO.frm.getTopWin().layer.full(thisINdex);
            //}
        },
        closeWin: function (endCallback) {
            /*******************************************
            说明：关闭当前打开的窗体
                cancelCallback：关闭窗体后的回调函数
            ********************************************/
            if (typeof (endCallback) == 'function') { endCallback(); }

            var index = KXO.frm.getTopWin().layer.getFrameIndex(window.name);//获取窗口索引
            KXO.frm.getTopWin().layer.close(index);
        },
        closeWinAll: function (endCallback) {
            /*******************************************
            说明：关闭所有弹出窗体
                endCallback：关闭窗体后的回调函数
            ********************************************/
            if (typeof (endCallback) == 'function') { endCallback(); }

            /*
            layer.closeAll(); //疯狂模式，关闭所有层
            layer.closeAll('dialog'); //关闭信息框
            layer.closeAll('page'); //关闭所有页面层
            layer.closeAll('iframe'); //关闭所有的iframe层
            layer.closeAll('loading'); //关闭加载层
            layer.closeAll('tips'); //关闭所有的tips层    
            */

            KXO.frm.getTopWin().layer.closeAll('iframe');
        },
        init: {
            initFun: function (chkLoginQz) {
                /*******************************************
                说明：Form页面初始化函数
                    chkLoginQz：获取检查用户登录与否的服务请求地址（前缀，如:3代表../../../）
                ********************************************/
                KXO.frm.init.setFrmBtn(chkLoginQz);
                //KXO.frm.init.setFrmCss();
                KXO.frm.init.setFrmValid();
            },
            setFrmBtn: function (chkLoginQz) {
                $('a[btn-type="view"],input[btn-type="view"],a[btn-type="opt"],input[btn-type="opt"]').hide();

                var handlerQz = !chkLoginQz || chkLoginQz == undefined || chkLoginQz.length <= 0 || chkLoginQz == 2 ? '../../' :
                    chkLoginQz == 1 ? '../' :
                    chkLoginQz == 3 ? '../../../' :
                    chkLoginQz == 4 ? '../../../../' :
                    chkLoginQz == 5 ? '../../../../../' : '../../../../../../';

                var pathName = window.location.pathname.toLowerCase();

                if (pathName.indexOf('sysmainopt.aspx') == -1 &&
                    pathName.indexOf('sysmainoptcontent.aspx') == -1 &&
                    pathName.indexOf('sysmainoptsytx.aspx') == -1) {
                    KXO.plu.ajax({
                        isLoad: false,
                        chkLogin: false,//请求数据之前是否检查已经登录
                        chkLoginPathQz: handlerQz,
                        url: handlerQz + 'Content/Handler/Common.ashx',
                        data: { action: 'SetUserOptBtns', moduleId: KXO.com.getUrlVal('mId') }
                    }, function (data) {
                        if (!data.admin) {
                            if (!data.read) {
                                $('a[btn-type="view"],input[btn-type="view"]').remove();
                            }
                            if (!data.write) {
                                $('a[btn-type="opt"],input[btn-type="opt"]').remove();
                            }
                        }

                        $('a[btn-type="view"],input[btn-type="view"],a[btn-type="opt"],input[btn-type="opt"]').show();
                    });
                }
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

                        //设置偶数行tr的样式
                        if ((iTr + 1) % 2 === 0) {
                            thisTrObj.removeClass('even').addClass('even');
                        } else {
                            thisTrObj.removeClass('even');
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

                            if (iTd + 1 === 1 && (iTr + 1) % 2 === 0) {
                                var lineIndex = Math.floor((Math.random() * tdLineStyle.length));
                                thisTdObj.removeClass('line-' + tdLineStyle[lineIndex]).addClass('line-' + tdLineStyle[lineIndex]);
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
                    try {
                        $(this).validatebox('enableValidation').validatebox('validate');
                    } catch (e) {

                    }
                });
            }
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

        openTjtzWin: function (winType, isFull) {
            /*******************************************
            说明：打开统计、台账页面
            ********************************************/
            var openWinUrl = '',
                openWinTitle = '';
            if (winType == 'tj-ryjbxx') {
                openWinTitle = '人员基本信息统计';
                openWinUrl = 'Module/ECharts/BasicInfoStatistics.aspx?mId=1013&pId=1012';
            } else if (winType == 'tj-sbjbxx') {
                openWinTitle = '设备基本信息统计';
                openWinUrl = 'Module/ECharts/DeviceInfoStatistis.aspx?mId=1016&pId=1012';
            } else if (winType == 'tz-sbjbxx') {
                openWinTitle = '设备台账信息';
                openWinUrl = 'Module/Ledger/Equ_Ledger.aspx?mId=1041&pId=1034';
            } else if (winType == 'tj-ypjbxx') {
                openWinTitle = '样品基本信息统计';
                openWinUrl = 'Module/ECharts/WtYpInfoStatistics.aspx?mId=1065&pId=1012';
            } else if (winType == 'tz-ypjbxx') {
                openWinTitle = '样品台账信息';
                openWinUrl = 'Module/Ledger/YP_Ledger.aspx?mId=1038&pId=1034';
            } else if (winType == 'tj-wtjbxx') {
                openWinTitle = '委托任务信息统计';
                openWinUrl = 'Module/ECharts/WtRwInfoStatistics.aspx?mId=1030&pId=1012&layType=lay';
            } else if (winType == 'tj-wtjbxxdb') {
                openWinTitle = '委托任务对比统计';
                openWinUrl = 'Module/ECharts/WtRw_DeptStaffECharts.aspx?mId=1045&pId=1012';
            } else if (winType == 'tz-wtjbxx') {
                openWinTitle = '委托台账信息';
                openWinUrl = 'Module/Ledger/WT_Ledger.aspx?mId=1037&pId=1034';
            } else if (winType == 'tj-khtsjbxx') {
                openWinTitle = '客户投诉情况统计';
                openWinUrl = 'Module/ECharts/ComplaintStatistics.aspx?mId=1033&pId=1012';
            } else if (winType == 'tj-wtfyjbxx') {
                openWinTitle = '委托费用信息统计';
                openWinUrl = 'Module/ECharts/WtFeeInfoStatistics.aspx?mId=1064&pId=1012';
            } else if (winType == 'tz-wtfyjbxx') {
                openWinTitle = '委托费用台账信息';
                openWinUrl = 'Module/Ledger/Fee_Ledger.aspx?mId=1042&pId=1034';
            } else if (winType == 'tz-bgjbxx') {
                openWinTitle = '报告台账';
                openWinUrl = 'Module/Ledger/Report_Ledger.aspx?mId=1039&pId=1034';
            } else if (winType == 'tz-bgjbxxbhg') {
                openWinTitle = '不合格报告台账';
                openWinUrl = 'Module/Ledger/FailReport_Ledger.aspx?mId=1040&pId=1034';
            }

            KXO.frm.openWin(openWinUrl, { isFull: isFull, title: openWinTitle, width: 1460, height: 750 });
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
            KXO.dia.tipPri('alert', content, obj);
        },
        confirm: function (content, obj) {
            /*******************************************
            说明：出现确认消息提示框
                    content：消息内容
                    obj：{title:'',yesCallback:function(){},cancelCallback:function(){},endCallback:function(){}}
                        title：提示标题（可不填，默认为提示信息）
                        yesCallback：点击确定后的回调函数
                        cancelCallback：点击取消后的回调函数
                        endCallback：窗体销毁后的回调函数
            ********************************************/
            obj = KXO.com.getObj(obj);
            obj.icon = 'question';
            KXO.dia.tipPri('confirm', content, obj);
        },
        tipPri: function (type, content, obj) {
            /*******************************************
            说明：出现的消息提示框
                    type：alert、confirm
                    content：消息内容
                    obj：{title:'',icon:'',yesCallback:function(){},cancelCallback:function(){},endCallback:function(){}}
                        title：提示标题（可不填，默认为提示信息）
                        icon：图标（可不填，默认不显示[hide：不显示、info、right、error、question、lock、sad、smile、cloud]）
                        yesCallback：点击确定后的回调函数
                        cancelCallback：点击取消或关闭后的回调函数
                        endCallback：窗体销毁后的回调函数
            ********************************************/
            var thisIcon = obj;//如果obj为string类型，则表示icon的类型

            content = KXO.com.getObj(content, 'str');
            obj = KXO.com.getObj(obj);

            obj.title = KXO.com.getObj(obj.title, 'str', '提示信息');
            obj.icon = thisIcon != undefined && typeof (thisIcon) === 'string' && thisIcon.length > 0 ? thisIcon : KXO.com.getObj(obj.icon, 'str', 'hide');

            obj.icon = obj.icon === 'hide' ? -1 :
                obj.icon === 'info' ? 0 :
                obj.icon === 'right' ? 1 :
                obj.icon === 'error' ? 2 :
                obj.icon === 'question' ? 3 :
                obj.icon === 'lock' ? 4 :
                obj.icon === 'sad' ? 5 :
                obj.icon === 'smile' ? 6 : 7;

            var clientH = KXO.frm.getTopWin().document.body.clientHeight;
            clientH = clientH > 158 ? (clientH - 158) / 2 : 0;

            if (type === 'alert') {
                KXO.frm.getTopWin().layer.alert(content, {
                    title: obj.title,
                    icon: obj.icon,
                    skin: 'layer-ext-moon', moveType: 1,
                    yes: function (index) {
                        if (typeof (obj.yesCallback) == 'function') { obj.yesCallback(); }
                        KXO.frm.getTopWin().layer.close(index);
                    },
                    offset: clientH + 'px',
                    cancel: function (index) {
                        if (typeof (obj.cancelCallback) == 'function') { obj.cancelCallback(); }
                    },
                    end: function () {
                        if (typeof (obj.endCallback) == 'function') { obj.endCallback(); }
                    },
                    //zIndex: KXO.frm.getTopWin().layer.zIndex,
                    success: function (layerObj, index) {
                        //此处的目的在于设置在弹出多窗口并且没有遮罩层时，点击底层的窗体置顶
                        //KXO.frm.getTopWin().layer.setTop(layerObj);
                    }
                });
            } else {
                KXO.frm.getTopWin().layer.confirm(content, {
                    title: obj.title,
                    icon: obj.icon,
                    skin: 'layer-ext-moon', moveType: 1,
                    offset: clientH + 'px',
                    end: function () {
                        if (typeof (obj.endCallback) == 'function') { obj.endCallback(); }
                    },
                    //zIndex: KXO.frm.getTopWin().layer.zIndex,
                    success: function (layerObj, index) {
                        //此处的目的在于设置在弹出多窗口并且没有遮罩层时，点击底层的窗体置顶
                        //KXO.frm.getTopWin().layer.setTop(layerObj);
                    }
                }, function (index) {
                    KXO.frm.getTopWin().layer.close(index);
                    if (typeof (obj.yesCallback) == 'function') { obj.yesCallback(); }
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
                            如果为string类型，则表示显示的图标，可选的图标有info、right、error、question、lock、sad、smile、cloud
                        time：消息显示时间（默认1500毫秒）
                        zIndex：层级
                        endCallback：窗体显示完毕后的回调函数
                        shift：消息出现的动画方式：0-6可选择，默认0
                        icon：图标（可不填，默认不显示[hide：不显示、info、right、error、question、lock、sad、smile、cloud]）
            ********************************************/
            var thisIcon = obj == undefined ? 'info' : obj;//如果obj为string类型，则表示icon的类型

            content = KXO.com.getObj(content, 'str');
            obj = KXO.com.getObj(obj);

            obj.time = KXO.com.getObj(obj.time, 'num', 1500);
            obj.shift = KXO.com.getObj(obj.shift, 'num', 0);
            obj.zIndex = KXO.com.getObj(obj.zIndex, 'num', KXO.frm.getTopWin().layer.zIndex);
            obj.icon = typeof (thisIcon) === 'string' && thisIcon.length > 0 ? thisIcon : KXO.com.getObj(obj.icon, 'str', 'hide');

            obj.icon = obj.icon === 'hide' ? -1 :
                obj.icon === 'info' ? 0 :
                obj.icon === 'right' ? 1 :
                obj.icon === 'error' ? 2 :
                obj.icon === 'question' ? 3 :
                obj.icon === 'lock' ? 4 :
                obj.icon === 'sad' ? 5 :
                obj.icon === 'smile' ? 6 : 7;

            var clientH = KXO.frm.getTopWin().document.body.clientHeight;
            clientH = clientH > 158 ? (clientH - 158) / 2 : 0;

            KXO.frm.getTopWin().layer.msg(content, {
                offset: clientH + 'px',
                //offset: 'auto',//出现的位置（auto：水平垂直居中，'100px'：顶部100px，['100px','200px']：水平居左100px、顶部200px）
                shift: obj.shift, icon: obj.icon,
                time: obj.time,
                shade: [0.1, '#393D49'],
                zIndex: obj.zIndex,
                success: function (layerObj, index) {
                    //此处的目的在于设置在弹出多窗口并且没有遮罩层时，点击底层的窗体置顶
                    //KXO.frm.getTopWin().layer.setTop(layerObj);
                }
            }, function () {
                if (typeof (obj.endCallback) == 'function') { obj.endCallback(); }
            });
        },
        prompt: function (obj, callBack) {
            /*******************************************
            说明：输入对话框
                    obj：{title:'',name:'',value:'',isTip:true}
                        title：提示的标题
                        name：提示的名称
                        value：默认值
                        isTip：点击确认时，如果值为空，是否提示
                        formType：文本框类型 0（文本）默认1（密码）2（多行文本）
            ********************************************/
            obj = KXO.com.getObj(obj);
            obj.title = KXO.com.getObj(obj.title, 'str', '请输入');
            obj.name = KXO.com.getObj(obj.name, 'str', '');
            obj.value = KXO.com.getObj(obj.value, 'str', '');
            obj.isTip = KXO.com.getObj(obj.isView, 'bool', true);
            obj.formType = KXO.com.getObj(obj.formType, 'str', '0');

            KXO.frm.getTopWin().layer.prompt({
                title: obj.title,
                value: obj.value,
                formType: obj.formType //0（文本）默认1（密码）2（多行文本）
            }, function (value, index, elem) {
                if (value.length <= 0 && obj.isTip) {
                    KXO.dia.msg(obj.name + '不能为空！');
                } else if (value.length > 0) {
                    if (typeof callBack == 'function') {
                        callBack(value);
                    }
                    KXO.frm.getTopWin().layer.close(index);
                }
            });
        },
        load: function (icon) {
            /*******************************************
            说明：load加载层
                    icon：图标（可不填，默认为0，0或1可选择）
            ********************************************/
            var clientH = KXO.frm.getTopWin().document.body.clientHeight;
            clientH = clientH > 25 ? (clientH - 25) / 2 : 0;

            icon = KXO.com.getObj(icon, 'num', 0);
            var index = KXO.frm.getTopWin().layer.load(icon, {
                //content:'加载中...',
                shade: [0.1, '#000'],
                offset: clientH + 'px'
            });
            return index;
        },
        loadClose: function (index) {
            /*******************************************
            说明：关闭load加载层
                    index：加载层的索引
            ********************************************/
            index = index == undefined ? KXO.frm.getTopWin().layer.load() : index;
            KXO.frm.getTopWin().layer.close(index);
        },
        notice: function (contentOrUrl, obj) {
            /*******************************************
            说明：右下角通知窗体
                    contentOrUrl：窗体内容或窗体地址
                    obj：{id:'',title:'',type:1,width:300,height:200,time:5000,shift:2,sucCallback:function(layerObj, index){},,endCallback:function(){}}
                        id：弹出窗体的唯一性
                        title：标题（可不填，默认为空）
                        type：窗体类型（1：url地址--默认，2：文本内容）
                        width：窗体宽度（默认为300px）
                        height：窗体高度（默认为200px）
                        time：窗体显示时间（默认5000毫秒）
                        shift：出现的动画方式：0-6可选择，默认4
                        sucCallback：窗体显示弹出后的回调函数
                        endCallback：窗体显示完毕后的回调函数
                        icon：窗体左上角图标样式类名称（可不填，默认为info-circle）
                        isMaxmin：是否显示最大最小化按钮（默认为false）
                                  该图标样式类名称可http://fontawesome.io/icons/在此查看
            ********************************************/
            obj = KXO.com.getObj(obj);
            contentOrUrl = KXO.com.getObj(contentOrUrl, 'str');

            if (contentOrUrl == undefined || contentOrUrl.length <= 0) {
                return;
            }

            obj.id = KXO.com.getObj(obj.id, 'str', '');
            obj.title = KXO.com.getObj(obj.title, 'str', '&nbsp;');
            obj.type = KXO.com.getObj(obj.type, 'num', 1);
            obj.width = KXO.com.getObj(obj.width, 'num', 300);
            obj.height = KXO.com.getObj(obj.height, 'num', 200);
            obj.time = KXO.com.getObj(obj.time, 'num', 5000);
            obj.shift = KXO.com.getObj(obj.shift, 'num', 2);
            obj.icon = KXO.com.getObj(obj.icon, 'str', 'info-circle');
            obj.isMaxmin = KXO.com.getObj(obj.isMaxmin, 'bool', false);

            KXO.frm.getTopWin().layer.open({
                type: obj.type === 1 ? 2 : 1, winIcon: obj.icon,
                title: obj.title,
                area: [obj.width + 'px', obj.height + 'px'],
                content: contentOrUrl,
                time: obj.time,
                shade: false,
                offset: 'rb',
                shift: obj.shift,
                maxmin: obj.isMaxmin,
                id: obj.id,
                end: function () {
                    if (typeof (obj.endCallback) == 'function') {
                        obj.endCallback();
                    }
                },
                //zIndex: KXO.frm.getTopWin().layer.zIndex,
                success: function (layerObj, index) {
                    if (typeof (obj.sucCallback) == 'function') {
                        obj.sucCallback(layerObj, index);
                    }
                    //此处的目的在于设置在弹出多窗口并且没有遮罩层时，点击底层的窗体置顶
                    //KXO.frm.getTopWin().layer.setTop(layerObj);
                }
            });
        }
    }
};

//顶部页面topTag标签Id名称
var thisTopTag = KXO.com.getJsParam('kx.core.js', 'topTag').length <= 0 ? 'topTag' : KXO.com.getJsParam('kx.core.js', 'topTag');

$(function () {
    //是否为/Module/hwe/ReportForm下报告或记录页面批注功能所需
    var isForRptJl = (KXO.com.getUrlVal('syid') != undefined && KXO.com.getUrlVal('syid').length > 0);

    //排除不需要初始化的页面
    var noInitPage = ['login.aspx', 'sysauth.aspx', 'index.aspx'];
    var isInit = false;
    var curUrl = document.URL.toLowerCase();
    for (var i = 0; i < noInitPage.length; i++) {
        if (curUrl.indexOf(noInitPage[i]) > -1) {
            isInit = true;
            break;
        }
    }

    if (!isForRptJl && !isInit) {
        //获取检查用户登录与否的服务请求地址（前缀）
        var chkLoginQz = KXO.com.getJsParam('kx.core.js', 'chkLoginQz');

        KXO.frm.init.initFun(chkLoginQz);
    }

    //禁用浏览器回退按钮
    KXO.com.disableBroFor();
});
