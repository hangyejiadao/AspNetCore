if ($.fn.pagination) {
    $.fn.pagination.defaults.beforePageText = '第';
    $.fn.pagination.defaults.afterPageText = '共{pages}页';
    $.fn.pagination.defaults.displayMsg = '显示{from}到{to},共{total}记录';
}
if ($.fn.datagrid) {
    $.fn.datagrid.defaults.loadMsg = '正在处理，请稍待。。。';
}
if ($.fn.treegrid && $.fn.datagrid) {
    $.fn.treegrid.defaults.loadMsg = $.fn.datagrid.defaults.loadMsg;
}
if ($.messager) {
    $.messager.defaults.ok = '确定';
    $.messager.defaults.cancel = '取消';
}
$.map(['validatebox', 'textbox', 'passwordbox', 'filebox', 'searchbox',
		'combo', 'combobox', 'combogrid', 'combotree',
		'datebox', 'datetimebox', 'numberbox',
		'spinner', 'numberspinner', 'timespinner', 'datetimespinner'], function (plugin) {
		    if ($.fn[plugin]) {
		        $.fn[plugin].defaults.missingMessage = '必填';
		    }
		});
if ($.fn.validatebox) {
    $.fn.validatebox.defaults.rules.email.message = '请输入有效的电子邮件地址';
    $.fn.validatebox.defaults.rules.url.message = '请输入有效的URL地址';
    $.fn.validatebox.defaults.rules.length.message = '输入内容长度必须介于{0}和{1}之间';
    $.fn.validatebox.defaults.rules.remote.message = '请修正该字段';
}
if ($.fn.calendar) {
    $.fn.calendar.defaults.weeks = ['日', '一', '二', '三', '四', '五', '六'];
    $.fn.calendar.defaults.months = ['一月', '二月', '三月', '四月', '五月', '六月', '七月', '八月', '九月', '十月', '十一月', '十二月'];
}
if ($.fn.datebox) {
    $.fn.datebox.defaults.currentText = '今天';
    $.fn.datebox.defaults.closeText = '关闭';
    $.fn.datebox.defaults.okText = '确定';
    $.fn.datebox.defaults.formatter = function (date) {
        var y = date.getFullYear();
        var m = date.getMonth() + 1;
        var d = date.getDate();
        return y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
    };
    $.fn.datebox.defaults.parser = function (s) {
        if (!s) return new Date();
        var ss = s.split('-');
        var y = parseInt(ss[0], 10);
        var m = parseInt(ss[1], 10);
        var d = parseInt(ss[2], 10);
        if (!isNaN(y) && !isNaN(m) && !isNaN(d)) {
            return new Date(y, m - 1, d);
        } else {
            return new Date();
        }
    };
}
if ($.fn.datetimebox && $.fn.datebox) {
    $.extend($.fn.datetimebox.defaults, {
        currentText: $.fn.datebox.defaults.currentText,
        closeText: $.fn.datebox.defaults.closeText,
        okText: $.fn.datebox.defaults.okText
    });
}
if ($.fn.datetimespinner) {
    $.fn.datetimespinner.defaults.selections = [[0, 4], [5, 7], [8, 10], [11, 13], [14, 16], [17, 19]];
}

/*
quber：
    扩展验证
 */
$.extend($.fn.validatebox.defaults.rules, {
    confirmPass: {
        validator: function (value, param) {
            var pass = $(param[0]).passwordbox('getValue');
            return value == pass;
        },
        message: '密码不一致！'
    },
    unnormal: {//验证是否包含空格和非法字符
        validator: function (value) {
            return /.+/i.test(value);
        },
        message: '输入值不能为空和包含其他非法字符'
    },
    mobile: {
        validator: function (value, param) {
            return /^1[3-9]\d{9}$/.test($.trim(value));
        },
        message: '手机号码错误'
    },
    tel: {
        validator: function (value, param) {
            return /^(?:(?:0\d{2,3}[\- ]?[1-9]\d{6,7})|(?:[48]00[\- ]?[1-9]\d{6}))$/.test($.trim(value));
        },
        message: '电话号码错误'
    },
    fax: {
        validator: function (value, param) {
            return /^((\(\d{2,3}\))|(\d{3}\-))?(\(0\d{2,3}\)|0\d{2,3}-)?[1-9]\d{6,7}(\-\d{1,4})?$/i.test($.trim(value));
        },
        message: '传真号码错误'
    },
    email: {
        validator: function (value, param) {
            return /^[\w\+\-]+(\.[\w\+\-]+)*@[a-z\d\-]+(\.[a-z\d\-]+)*\.([a-z]{2,4})$/i.test($.trim(value));
        },
        message: '邮箱地址错误'
    },
    qq: {
        validator: function (value, param) {
            return /^[1-9]\d{4,}$/.test($.trim(value));
        },
        message: 'QQ号码错误'
    },
    date: {
        validator: function (value, param) {
            return /(([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3})-(((0[13578]|1[02])-(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)-(0[1-9]|[12][0-9]|30))|(02-(0[1-9]|[1][0-9]|2[0-8]))))|((([0-9]{2})(0[48]|[2468][048]|[13579][26])|((0[48]|[2468][048]|[3579][26])00))-02-29)/.test($.trim(value));
        },
        message: '日期格式错误'
    },
    number: {
        validator: function (value, param) {
            return /^(-?\d+)(\.\d+)?$/.test($.trim(value));
        },
        message: '请输入数字'
    },
    int: {
        validator: function (value, param) {
            return /^\d+$/.test($.trim(value));
        },
        message: '请输入大于或等于0的整数'
    },
    intX: {
        validator: function (value, param) {
            return /^((-\d+)|(0+))$/.test($.trim(value));
        },
        message: '请输入小于或等于0的整数'
    },
    intZ: {
        validator: function (value, param) {
            return /^\+?[1-9][0-9]*$/.test($.trim(value));
        },
        message: '请输入正整数'
    },
    intF: {
        validator: function (value, param) {
            return /^\-[1-9][0-9]*$/.test($.trim(value));
        },
        message: '请输入小于0的整数'
    },
    float: {
        validator: function (value, param) {
            return /^\d+(\.\d+)?$/.test($.trim(value));
        },
        message: '请输入大于或等于0的数字'
    },
    floatX: {
        validator: function (value, param) {
            return /^((-\d+(\.\d+)?)|(0+(\.0+)?))$/.test($.trim(value));
        },
        message: '请输入小于或等于0的数字'
    },
    floatZ: {
        validator: function (value, param) {
            return /^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/.test($.trim(value));
        },
        message: '请输入大于0的数字'
    },
    floatF: {
        validator: function (value, param) {
            return /^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$/.test($.trim(value));
        },
        message: '请输入小于0的数字'
    },
    zip: {
        validator: function (value, param) {
            return /^[0-9]\d{5}$/.test($.trim(value));
        },
        message: '邮政编码错误'
    },
    eng: {
        validator: function (value) {
            return /^[A-Za-z]+$/i.test($.trim(value));
        },
        message: '只能输入字母'
    },
    chs: {
        validator: function (value, param) {
            return /^[\u0391-\uFFE5]+$/.test($.trim(value));
        },
        message: '只能输入汉字'
    },
    ip: {
        validator: function (value) {
            return /\d+\.\d+\.\d+\.\d+/.test($.trim(value));
        },
        message: 'IP地址格式错误'
    },
    url: {
        validator: function (value) {
            return /((https|http|ftp|rtsp|igmp|file|rtspt|rtspu):\/\/)(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(:[0-9]{1,4})*(\/[a-zA-Z0-9\&%_\./-~-]*)?/.test($.trim(value));
        },
        message: 'URL地址错误'
    },
    range: {//非负整数
        validator: function (value, param) {
            if (/^\d+$/.test($.trim(value))) {
                return $.trim(value) >= param[0] && $.trim(value) <= param[1];
            } else {
                return false;
            }
        },
        message: '输入的数字在{0}到{1}之间'
    },
    rangeF: {//非负数字
        validator: function (value, param) {
            if (/^\d+(\.\d+)?$/.test($.trim(value))) {
                return $.trim(value) >= param[0] && $.trim(value) <= param[1];
            } else {
                return false;
            }
        },
        message: '输入的数字在{0}到{1}之间'
    },
    minLength: {
        validator: function (value, param) {
            return $.trim(value).length >= param[0];
        },
        message: '至少输入{0}个字'
    },
    maxLength: {
        validator: function (value, param) {
            return $.trim(value).length <= param[0];
        },
        message: '最多输入{0}个字'
    },
    select: {//下拉框验证
        validator: function (value, param) {
            if (($.trim(value).length <= 0 || $.trim(value) === 'all' || $.trim(value) === '请选择...' || $.trim(value) === '请选择…' || $.trim(value) === '请选择……') ||
                ($.trim(value).length > 0 && param != undefined && param.length > 0 && $.trim(value) === param[0])) {
                return false;
            } else {
                return true;
            }
        },
        message: '请选择'
    },
    idCode: {
        validator: function (value, param) {
            return /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/.test($.trim(value));
        },
        message: '身份证号错误'
    },
    equal: {//比较2个字段是否一致
        validator: function (value, param) {
            return $.trim(value) === $.trim($('#' + param[0]).val());
        },
        message: '两次输入不一至'
    },
    loginName: {
        validator: function (value, param) {
            return /^[a-zA-Z]\w{3,15}$/.test($.trim(value));
        },
        message: '请输入以字母开头的4-16数字、字母或下划线'
    },
    engOrNum: {//只能输入英文或数字
        validator: function (value) {
            return /^[A-Za-z0-9]+$/.test($.trim(value));
        },
        message: '请输入英文、数字、下划线或者空格'
    },
    carNo: {
        validator: function (value) {
            return /^[\u4E00-\u9FA5][\da-zA-Z]{6}$/.test(value);
        },
        message: '车牌号码无效'
    }
});

/*
quber：
    EasyUI radio扩展
 */
(function ($) {
    var STYLE = {
        radio: {
            cursor: "pointer",
            background: "transparent url('data:image/gif;base64,R0lGODlhDwAmANUAAP////z8/Pj4+Ovr6/v7++7u7uPj493d3ff39/Ly8vT09ICAgPX19a+vr+Li4urq6vn5+fr6+v39/dXV1efn5+bm5uTk5ODg4N7e3v7+/vHx8fDw8O3t7e/v74eHh+Hh4c3NzdfX1+np6eXl5cDAwNra2t/f38/Pz/Pz8/b29sbGxsHBwc7OzsLCwujo6NHR0by8vL29vcXFxb+/v7m5udPT09jY2MPDw7u7u7i4uNLS0uzs7AAAAAAAAAAAAAAAACH5BAAAAAAALAAAAAAPACYAAAb/QIBwSCwaj0VGSIbLzUAXQfFDap1KjktJVysMHTHQ4WKgPAqaymQDYJBYh4/FNSgkGIjBgRC6YRwjIjsddwIRAQ4cKi8GFSIcGygphgEBBRYwB2ZoCggQBJUBCBg0FHV3nqChBAcrFYQMlKGVAgYnJpKyswEJDwYTqbuhAwoQEw+qwgoDEgAbNhzCAQoiUkIaGAYdCAQCCQMD1kMEBSMmBxbEzUjs7e7v8EJKTE5Q4kJUVlhaXF5CYGLIbEqzps2bOHNO4dHDxw+gAgIyREBAKdGiRgUMNPDQwICqS5nMQGiwoGSDDJVGlaqTwUPJBR4AVGLlihABkiZRBqh1S1IELY0cDUio1OtXKgkZAGQYWomYMWTSpjFzBk0aNXHYtHHzBu4eAHLm0KmLR5ZIEAA7') no-repeat center top",
            verticalAlign: "middle",
            height: "19px",
            width: "18px",
            display: "block"
        },
        span: {
            "float": "left",
            display: "block",
            margin: "0px 4px",
            marginTop: "5px"
        },
        label: {
            marginTop: "4px",
            marginRight: "8px",
            display: "block",
            "float": "left",
            fontSize: "16px",
            cursor: "pointer"
        }
    };

    function rander(target) {
        var jqObj = $(target);
        jqObj.css('display', 'inline-block');
        var radios = jqObj.children('input[type=radio]');
        var checked;

        radios.each(function () {
            var jqRadio = $(this);
            var jqWrap = $('<span/>').css(STYLE.span);
            var jqLabel = $('<label/>').css(STYLE.label);
            var jqRadioA = $('<a/>').data('lable', jqLabel).addClass("RadioA").css(STYLE.radio).text(' ');
            var labelText = jqRadio.data('lable', jqLabel).attr('label');
            jqRadio.hide();
            jqRadio.after(jqLabel.text(labelText));
            jqRadio.wrap(jqWrap);
            jqRadio.before(jqRadioA);
            if (jqRadio.prop('checked')) {
                checked = jqRadioA;
            }

            jqLabel.click(function () {
                (function (rdo) {
                    rdo.prop('checked', true);
                    radios.each(function () {
                        var rd = $(this);
                        var y = 'top';
                        if (rd.prop('checked')) {
                            y = 'bottom';
                        }
                        rd.prev().css('background-position', 'center ' + y);
                    });
                })(jqRadio);
            });

            jqRadioA.click(function () {
                $(this).data('lable').click();
            });
        });
        checked.css('background-position', 'center bottom');
    }

    $.fn.radio = function (options, param) {
        if (typeof options == 'string') {
            return $.fn.radio.methods[options](this, param);
        }

        options = options || {};
        return this.each(function () {
            if (!$.data(this, 'radio')) {
                $.data(this, 'radio', {
                    options: $.extend({}, $.fn.radio.defaults, options)
                });
                rander(this);
            } else {
                var opt = $.data(this, 'radio').options;
                $.data(this, 'radio', {
                    options: $.extend({}, opt, options)
                });
            }
        });
    };

    $.fn.radio.methods = {
        getValue: function (jq) {
            var checked = jq.find('input:checked');
            var val = {};
            if (checked.length)
                val[checked[0].name] = checked[0].value;
            return val;
        },
        check: function (jq, val) {
            if (val && typeof val != 'object') {
                var ipt = jq.find('input[value=' + val + ']');
                ipt.prop('checked', false).data('lable').click();
            }
        }
    };

    $.fn.radio.defaults = {
        style: STYLE
    };

    if ($.parser && $.parser.plugins) {
        $.parser.plugins.push('radio');
    }

})(jQuery);

/*
quber：
    EasyUI checkbox扩展
 */
(function ($) {
    var STYLE = {
        checkbox: {
            cursor: "pointer",
            background: "transparent url('data:image/gif;base64,R0lGODlhDwAmAKIAAPr6+v///+vr68rKyvT09Pj4+ICAgAAAACH5BAAAAAAALAAAAAAPACYAAANuGLrc/mvISWcYJOutBS5gKIIeUQBoqgLlua7tC3+yGtfojes1L/sv4MyEywUEyKQyCWk6n1BoZSq5cK6Z1mgrtNFkhtx3ZQizxqkyIHAmqtTsdkENgKdiZfv9w9bviXFxXm4KP2g/R0uKAlGNDAkAOw==') no-repeat center top",
            verticalAlign: "middle",
            height: "19px",
            width: "18px",
            display: "block"
        },
        span: {
            "float": "left",
            display: "block",
            margin: "0px 4px",
            marginTop: "5px"
        },
        label: {
            marginTop: "4px",
            marginRight: "8px",
            display: "block",
            "float": "left",
            fontSize: "16px",
            cursor: "pointer"
        }
    };

    function rander(target) {
        var jqObj = $(target);
        jqObj.css('display', 'inline-block');
        var Checkboxs = jqObj.children('input[type=checkbox]');
        Checkboxs.each(function () {
            var jqCheckbox = $(this);
            var jqWrap = $('<span/>').css(STYLE.span);
            var jqLabel = $('<label/>').css(STYLE.label);
            var jqCheckboxA = $('<a/>').data('lable', jqLabel).css(STYLE.checkbox).text(' ');
            var labelText = jqCheckbox.data('lable', jqLabel).attr('label');
            jqCheckbox.hide();
            jqCheckbox.after(jqLabel.text(labelText));
            jqCheckbox.wrap(jqWrap);
            jqCheckbox.before(jqCheckboxA);
            if (jqCheckbox.prop('checked')) {
                jqCheckboxA.css('background-position', 'center bottom');
            }

            jqLabel.click(function () {
                (function (ck, cka) {
                    ck.prop('checked', !ck.prop('checked'));
                    var y = 'top';
                    if (ck.prop('checked')) {
                        y = 'bottom';
                    }
                    cka.css('background-position', 'center ' + y);
                })(jqCheckbox, jqCheckboxA);
            });

            jqCheckboxA.click(function () {
                $(this).data('lable').click();
            });
        });
    }

    $.fn.checkbox = function (options, param) {
        if (typeof options == 'string') {
            return $.fn.checkbox.methods[options](this, param);
        }

        options = options || {};
        return this.each(function () {
            if (!$.data(this, 'checkbox')) {
                $.data(this, 'checkbox', {
                    options: $.extend({}, $.fn.checkbox.defaults, options)
                });
                rander(this);
            } else {
                var opt = $.data(this, 'checkbox').options;
                $.data(this, 'checkbox', {
                    options: $.extend({}, opt, options)
                });
            }
        });
    };

    function check(jq, val, check) {
        var ipt = jq.find('input[value=' + val + ']');
        if (ipt.length) {
            ipt.prop('checked', check).each(function () {
                $(this).data('lable').click();
            });
        }
    }

    $.fn.checkbox.methods = {
        getValue: function (jq) {
            var checked = jq.find('input:checked');
            var val = {};
            checked.each(function () {
                var kv = val[this.name];
                if (!kv) {
                    val[this.name] = this.value;
                    return;
                }

                if (!kv.sort) {
                    val[this.name] = [kv];
                }
                val[this.name].push(this.value);
            });
            return val;
        },
        check: function (jq, vals) {
            if (vals && typeof vals != 'object') {
                check(jq, vals);
            } else if (vals.sort) {
                $.each(vals, function () {
                    check(jq, this);
                });
            }
        },
        unCheck: function (jq, vals) {
            if (vals && typeof vals != 'object') {
                check(jq, vals, true);
            } else if (vals.sort) {
                $.each(vals, function () {
                    check(jq, this, true);
                });
            }
        },
        checkAll: function (jq) {
            jq.find('input').prop('checked', false).each(function () {
                $(this).data('lable').click();
            });
        },
        unCheckAll: function (jq) {
            jq.find('input').prop('checked', true).each(function () {
                $(this).data('lable').click();
            });
        }
    };

    $.fn.checkbox.defaults = {
        style: STYLE
    };

    if ($.parser && $.parser.plugins) {
        $.parser.plugins.push('checkbox');
    }
})(jQuery);

/*
quber：
    EasyUI Layout center全屏扩展
    使用方法：
                    $("body").layout("full");
                    $("body").layout("unFull");
 */
$.extend($.fn.layout.methods, {
    full: function (jq) {
        return jq.each(function () {
            var layout = $(this);
            var center = layout.layout('panel', 'center');
            center.panel('maximize');
            center.parent().css('z-index', 10);

            $(window).on('resize.full', function () {
                layout.layout('unFull').layout('resize');
            });
        });
    },
    unFull: function (jq) {
        return jq.each(function () {
            var center = $(this).layout('panel', 'center');
            center.parent().css('z-index', 'inherit');
            center.panel('restore');
            $(window).off('resize.full');
        });
    }
});

/*
quber：
    EasyUI datagrid增加统计当前页中某列的最大值，最小值，平均值，总和
    使用方法：
    onLoadSuccess : function() {
        $('#dg').datagrid('statistics');
    }

    列属性中加入：sum: true, sumCol: 'Capacity', avg: true, avgCol: 'Capacity', max: true, maxCol: 'Capacity', min: true, minCol: 'Capacity'
    sumCol："合计"标题显示的列名称
    ……
 */
$.extend($.fn.datagrid.methods, {
    statistics: function (jq) {
        var opt = $(jq).datagrid('options').columns;
        var rows = $(jq).datagrid("getRows");

        var footer = new Array();
        footer['sum'] = "";
        footer['avg'] = "";
        footer['max'] = "";
        footer['min'] = "";

        var sumCol = '',
            avgCol = '',
            maxCol = '',
            minCol = '';

        for (var i = 0; i < opt[0].length; i++) {
            if (opt[0][i].sumCol) sumCol = opt[0][i].sumCol;
            if (opt[0][i].avgCol) avgCol = opt[0][i].avgCol;
            if (opt[0][i].maxCol) maxCol = opt[0][i].maxCol;
            if (opt[0][i].minCol) minCol = opt[0][i].minCol;

            if (opt[0][i].sum) {
                footer['sum'] = footer['sum'] + sum(opt[0][i].field) + ',';
            }
            if (opt[0][i].avg) {
                footer['avg'] = footer['avg'] + avg(opt[0][i].field) + ',';
            }
            if (opt[0][i].max) {
                footer['max'] = footer['max'] + max(opt[0][i].field) + ',';
            }
            if (opt[0][i].min) {
                footer['min'] = footer['min'] + min(opt[0][i].field) + ',';
            }
        }

        var footerObj = new Array();
        var tmp, obj;
        if (footer['sum'] != "") {
            tmp = '{' + footer['sum'].substring(0, footer['sum'].length - 1) + "}";
            obj = eval('(' + tmp + ')');
            if (sumCol.length > 0) obj[sumCol] = '合计';
            footerObj.push(obj);
        }

        if (footer['avg'] != "") {
            tmp = '{' + footer['avg'].substring(0, footer['avg'].length - 1) + "}";
            obj = eval('(' + tmp + ')');
            if (avgCol.length > 0) obj[avgCol] = '平均值';
            footerObj.push(obj);
        }

        if (footer['max'] != "") {
            tmp = '{' + footer['max'].substring(0, footer['max'].length - 1) + "}";
            obj = eval('(' + tmp + ')');
            if (maxCol.length > 0) obj[maxCol] = '最大值';
            footerObj.push(obj);
        }

        if (footer['min'] != "") {
            tmp = '{' + footer['min'].substring(0, footer['min'].length - 1) + "}";
            obj = eval('(' + tmp + ')');
            if (minCol.length > 0) obj[minCol] = '最小值';
            footerObj.push(obj);
        }

        if (footerObj.length > 0) {
            $(jq).datagrid('reloadFooter', footerObj);
        }

        function sum(filed) {
            var sumNum = 0;
            for (var i = 0; i < rows.length; i++) {
                sumNum += Number(rows[i][filed]);
            }
            return '"' + filed + '":"' + sumNum.toFixed(2) + '"';
        };

        function avg(filed) {
            var sumNum = 0;
            for (var i = 0; i < rows.length; i++) {
                sumNum += Number(rows[i][filed]);
            }
            return '"' + filed + '":"' + (sumNum / rows.length).toFixed(2) + '"';
        }

        function max(filed) {
            var max = 0;
            for (var i = 0; i < rows.length; i++) {
                if (i == 0) {
                    max = Number(rows[i][filed]);
                } else {
                    max = Math.max(max, Number(rows[i][filed]));
                }
            }
            return '"' + filed + '":"' + max + '"';
        }

        function min(filed) {
            var min = 0;
            for (var i = 0; i < rows.length; i++) {
                if (i == 0) {
                    min = Number(rows[i][filed]);
                } else {
                    min = Math.min(min, Number(rows[i][filed]));
                }
            }
            return '"' + filed + '":"' + min + '"';
        }
    }
});


///*
//quber：
//    EasyUI datagrid右键点击表头出现列复选框（隐藏或显示）扩展
// */
//var createGridHeaderContextMenu = function (e, field) {
//    e.preventDefault();
//    var grid = $(this);/* grid本身 */
//    var headerContextMenu = this.headerContextMenu;/* grid上的列头菜单对象 */
//    var okCls = 'tree-checkbox1';//选中
//    var emptyCls = 'tree-checkbox0';//取消
//    if (!headerContextMenu) {
//        var tmenu = $('<div style="width:120px;"></div>').appendTo('body');
//        var fields = grid.datagrid('getColumnFields');// 获取解冻列
//        var fieldsFrozen = grid.datagrid('getColumnFields', true);  // 获取冻结列
//        if (fieldsFrozen.length > 0) {//合并所有列
//            fieldsFrozen.push.apply(fieldsFrozen, fields);
//            fields = fieldsFrozen;
//        }

//        for (var i = 0; i < fields.length; i++) {
//            var fildOption = grid.datagrid('getColumnOption', fields[i]);
//            if (!fildOption.checkbox) {//排除复选框列
//                if (!fildOption.hidden) {
//                    $('<div iconCls="' + okCls + '" field="' + fields[i] + '"/>').html(fildOption.title).appendTo(tmenu);
//                } else {
//                    $('<div iconCls="' + emptyCls + '" field="' + fields[i] + '"/>').html(fildOption.title).appendTo(tmenu);
//                }
//            }
//        }
//        headerContextMenu = this.headerContextMenu = tmenu.menu({
//            onClick: function (item) {
//                var field = $(item.target).attr('field');
//                if (item.iconCls == okCls) {
//                    grid.datagrid('hideColumn', field);
//                    $(this).menu('setIcon', {
//                        target: item.target,
//                        iconCls: emptyCls
//                    });
//                } else {
//                    grid.datagrid('showColumn', field);
//                    $(this).menu('setIcon', {
//                        target: item.target,
//                        iconCls: okCls
//                    });
//                }
//            }
//        });
//    }
//    headerContextMenu.menu('show', {
//        left: e.pageX,
//        top: e.pageY
//    });
//};
//$.fn.datagrid.defaults.onHeaderContextMenu = createGridHeaderContextMenu;
//$.fn.treegrid.defaults.onHeaderContextMenu = createGridHeaderContextMenu;