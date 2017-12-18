
//******************************************************************************//
//*******************************特殊功能说明***********************************//
//						ctrl+.显示源代码								        //
//						ctrl+b显示当前控件id									//
//						alt+z撤销全部控件的更改									//
//						ctrl+z单步撤销控件的更改								//	
//						sift+z将当前控件的值清空								//
//******************************************************************************//

var global_msg = '';  //全局消息传递变量
var dismr = true;  //是否屏避 DataGrid 外的 mouserightclick
var dismrmsg = "";  //屏避mouseright时弹出的信息
var showpopupmenu;
var par = '';  //用于保存页面的参数信息.用在lq_le02.aspx及其相关页中.
var enterclick = 1;//保存回车键的击键次数
var foucscolor = "#ccff99";//控件获取焦点时的颜色。
var headcation = "请输入前段值";//提示框1的标题
var startcation = "请输入起始值";//提示框2的标题
var stepcation = "请输入步进值";//提示框3的标题

//**************************基本实现无限重做*************************************//
//**************************不要求，暂时放下*************************************//
var CurentValue = new Array(); //保存每一步的输入信息。                            //
var isnew = true;     //是否当前控件                                               //
var js = 0;//按键输入的计数器。                                                    //
var ctljs = 0;//ctrl+z键的计数器。                                                 // 
var oldctr = "";//前一个控件的id                                                   //
//*******************************************************************************//


//在打印原始记录的时候用
var Masterreturn;

function setmaster(obj) {
    Masterreturn = obj;
}
function setblank(obj)//输入控件id查找并显示。
{

    if (obj.id == "reportbot:_ctl5") {
        return;
    }

    setmaster(true);


    var hrss = obj.getElementsByTagName("INPUT")
    var j = 0;
    var returnvalue = false;
    obj.bgColor = "White";
    for (var i = 0; i < hrss.length; i++) {


        if ((hrss[i].name.indexOf("_ctl15") != -1) || (hrss[i].name.indexOf("_ctl9") != -1) || (hrss[i].name.indexOf("_ctl21") != -1) || (hrss[i].name.indexOf("_ctl26") != -1)) {
            continue;
        }
        if (hrss[i].type != "hidden") {
            hrss[i].title == "zone"
            hrss[i].value = "";
            //hrss[i].style.display="none"
            hrss[i].className = "";
        }
    }
    var hrss = obj.getElementsByTagName("textarea")
    //var j=0;
    var returnvalue = false;
    for (var i = 0; i < hrss.length; i++) {

        if ((hrss[i].name.indexOf("_ctl15") != -1) || (hrss[i].name.indexOf("_ctl9") != -1) || (hrss[i].name.indexOf("_ctl21") != -1) || (hrss[i].name.indexOf("_ctl26") != -1)) {
            continue;
        }
        if (hrss[i].id == "rrm11") {
            //alert(1)
        }
        hrss[i].value = "";
        hrss[i].className = "";
    }
}

showpopupmenu = true;
save = false;
var dissel;
acct = true;
dissel = true;
ValiDate = true;
FloatArr = new Array(8, 9, 13, 20, 37, 38, 39, 40, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 190, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 109, 110, 144, 229, 189)//浮点数
IntArr = new Array(8, 9, 13, 20, 37, 38, 39, 40, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 109, 14, 229, 189)//整数
Msg = new Array(8, 9, 13, 16, 17, 37, 38, 39, 40, 46, 20, 109, 144, 189)    //永远可用的键
//DateCk=new Array(8,9,13,37,38,39,40,20,144)    //日期可以使用的键

String.prototype.trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, "");
}
String.prototype.ltrim = function () {
    return this.replace(/(^\s*)/g, "");
}
String.prototype.rtrim = function () {
    return this.replace(/(\s*$)/g, "");
}

//定义报告是否只读
if (isReadOnly != "undefined")
    var isReadOnly = false;

//根据传入的日期字符串进行分析处理，合成我们所需的日期格式
//return isDate(str) ==true?str:false;
//如果传入的是日期，返回格式化后的日期{0:yyyy-MM-dd}，否则返回false;
function isDate(str) {
    var s = new String();
    var pattern = /年|月|日|\.|[/]/g;
    s = str.replace(pattern, "-");

    var ss = s.split("-");
    var year, month, day;
    if (ss.length < 3) {  //      alert("输入出错，输入格式为2004-4-5");   
        return false;
    }
    if (!(/^([0-9][0-9])$|^(19[0-9][0-9]|20[0-9][0-9])$/.test(ss[0]))) {// alert("年出错,请输入1900-2050之间的年数字");
        return false;
    }
    if (!(/^((0[1-9])|[1-9]|10|11|12)$/.test(ss[1]))) {//     alert("月份出错");
        return false;
    }
    year = parseInt(ss[0]);

    month = parseInt(ss[1]);
    if (ss[2] == "8" || ss[2] == "08" || ss[2] == "09" || ss[2] == "9") {
        day = "08";
    }
    else {
        if (isNaN(parseInt(ss[2])))
            return false;
        else
            day = parseInt(ss[2]);
    }
    var max;
    if (month == 2) {
        max = 28;
        if (((year % 10 == 0) && (year % 40 == 0)) || ((year % 10 != 0) && (year % 4 == 0))) //判断是否闰年
            max = 29;
    }
    else if ((month == 4) || (month == 6) || (max == 9) || (month == 11))
        max = 30;
    else
        max = 31;
    if (day < 1 || day > max) { //    alert("日期出错,请输入范围为1-"+max+"内的整数");
        return false;
    }
    return year + "-" + month + "-" + day;
}

function isIn(k, obj) {                             //值是否存在于某一个数组中
    if (obj == null)
        return false;
    for (i = 0; i < obj.length; i++) {
        if (k == obj[i])
            return true;
    }
    return false;
}

function IsExist(k, obj) {                          //测试在字符串中是否存在特殊字符。
    if (obj == null)
        return false;
    for (i = 0; i < obj.length; i++) {
        if (k == obj.charAt(i))
            return true
    }
    return false;
}


function dismrclick() {
    if (isReadOnly) {
        event.returnValue = false;
    }
}

function disselect()   //在获取焦点的时候将凡是值为'/'的全替换为''并且只能选取文本控件
{
    // var str = window.event.srcElement.tagName.toUpperCase();
    //var temp=window.location.href;  //只在综合报告中起作用. 因为在这里只读.
    //if(/(zh.aspx?)/.test(temp))
    //{	
    // return false
    // }

    var str = window.event.srcElement.tagName.toUpperCase();
    acct = true
    if (str == "INPUT" || str == "TEXTAREA") {
        var kk = event.srcElement
        if (kk.value == '/')
            kk.value = ''
        return true;
    }
    else
        return (!dissel)
}

function help() {
    //禁止调用ie帮助文件
    alert("帮助文件正在构造中...");
    event.returnValue = false;
}
function stopfavorite() {
    //禁止通过外部键收藏
    if (event.ctrlKey && event.keyCode == 66) {
        event.returnValue = false;
    }
}
function stopprint() {
    //禁止通过外部键进行打印
    if (event.ctrlKey && event.keyCode == 80) {
        event.returnValue = false;
    }
}
function stopnew() {
    //禁止通过外部键产生新窗口
    if (event.ctrlKey && event.keyCode == 78) {
        event.returnValue = false;
    }
}

function stopquit() {
    //禁止通过外部键退出系统
    if (event.ctrlKey && event.keyCode == 87) {
        event.returnValue = false;
    }
}
function stopbackspace() {
    //var str = window.event.srcElement.tagName.toUpperCase();
    //if (event.keyCode == 8) {
    //    if (str == "INPUT" || str == "TEXTAREA")//不在输入控件上返回。
    //    {
    //        event.returnValue = true;
    //    }
    //    else {
    //        event.returnValue = false;
    //    }
    //}
}
ctlcount = 0;
var ctlarry = new Array();
var ctlarryValue = new Array();
//撤消输入
function Undo() {
    if ((ctlcount - 1) < 0) {
        return false;
    }
    window.document.getElementById(ctlarry[ctlcount - 1]).setActive();
    window.document.getElementById(ctlarry[ctlcount - 1]).value = ctlarryValue[ctlcount - 1];
    ctlcount--;
}

//关闭提醒
$(function () {
    var url = window.location.href;
    $("input,textarea").keyup(function () {
        if (url.indexOf("zh.aspx") == -1) {
            if (!parent.window.IsChanged)
                parent.window.IsChanged = true;
        }
    })
})

//打印页面禁止输入
$(function () {
    //$("#ReportFormHeadSYG1_gcbw").focus().blur();

    var pageHref = window.location.href;
    if (pageHref.indexOf("isblank=1") == -1 && pageHref.indexOf("state=p") != -1) {
        $(":text,textarea").focus(function () {
            this.blur();
        })
    }

})
function getQueryString(queryStringName) {
    var returnValue = "";
    var URLString = new String(document.location);
    var serachLocation = -1;
    var queryStringLength = queryStringName.length;
    do {
        serachLocation = URLString.indexOf(queryStringName + "\=");
        if (serachLocation != -1) {
            if ((URLString.charAt(serachLocation - 1) == '?') || (URLString.charAt(serachLocation - 1) == '&')) {
                URLString = URLString.substr(serachLocation);
                break;
            }
            URLString = URLString.substr(serachLocation + queryStringLength + 1);
        }

    }
    while (serachLocation != -1)
    if (serachLocation != -1) {
        var seperatorLocation = URLString.indexOf("&");
        if (seperatorLocation == -1) {
            returnValue = URLString.substr(queryStringLength + 1);
        }
        else {
            returnValue = URLString.substring(queryStringLength + 1, seperatorLocation);
        }
    }
    return returnValue;
}
keepdot = true              //是否接受小数点的输入。
oldstr = ''                 //输入焦点是否离开。离开则可继续接受.的输入。
oldid = ""             //原先控件id
newid = ""             //新控件id
function diskeydown() {


    global_msg = '';
    save = true;
    //  stopfavorite();
    // stopnew();
    // stopquit();
    stopbackspace();
    // stopprint();

    // return false;


    if (event.ctrlKey && event.keyCode == 190) {//ctrl键+ . 显示网页源代码
        alert(window.location.href)
        showSource();
        return false;
    }
    if (event.altKey && event.keyCode == 90) {
        window.document.forms[0].reset();
    }
    if (event.ctrlKey && event.keyCode == 80) {
        alert("禁止此功能!")
        return false;
    }
    if (event.ctrlKey && event.keyCode == 90) {
        Undo();
        return false;
    }
    if (event.altKey && event.keyCode == 66) {

    }
    if (event.ctrlKey && event.keyCode == 83) {
        $("input,textarea").blur();
        var url = window.location.href;
        if (url.indexOf("zh.aspx") == -1) {
            event.preventDefault();
            $("#btnSave", parent.document).click();
        }
        else {
            alert("报告页面不能保存。");
        }
    }

    var code = event.keyCode;
    var input = event.srcElement;




    e = input.id;
    newid = input.id;
    var ss = event;


    if (isReadOnly) {  //isReadOnly文件stateStyle中定义该变量
        i++;
        if (i % 3 == 0) {
            if (!isIn(code, Msg)) {
                //alert("该状态下报告不能被编辑！");
            }
            i = 0;
        }
        //event.returnValue = false;
    }


    if (event.ctrlKey && event.keyCode == '66') {//ctrl键+B键显示控件id,为了方便脱离ide时候查看id
        alert(e);


        event.returnValue = false;
    }
    if (event.keyCode == '120') {//F9显示控件id,设置技术要求
        if (e == "") {
            alert("非法操作!已记录当前IP!")
            event.returnValue = false;
        }


        var syid = document.location.href.substring(document.location.href.indexOf("syid=") + 5);
        syid = syid.substring(0, syid.indexOf("&state"));
        var syid2 = getQueryString('syid2');
        var url = "../../sysmodule/YSJL_JSYQList.aspx?ct=" + e + "&syid=" + syid + "&rnd=" + Math.random() + "&syid2=" + syid2;
        parent.document.getElementById("ModalWindowFrame").src = url;
        //parent.$('#w').window({ maximizable: false, closable: false, draggable: false, collapsible: false, inline: false, shadow: false, maximized: false });
        parent.$('#w').window({ title: "设置技术要求", maximizable: false, closable: true, draggable: true, collapsible: false, minimizable: false, maximized: false, width: 900, height: 500, left: ($(document).width() - 800) / 2, top: ($(document).height() - 500) / 2 });

        parent.$('#w').window('open');
    }
    if (event.keyCode == '119') {//F8弹出导入窗口
        //if (e == "") {
        //    alert("非法操作!")
        //    return false;
        //}
        if (document.location.href.indexOf("zh.aspx") != -1) {
            alert("请切换到原始记录表!")
            return false;
        }
        var alowdaoru = false;
        $.ajaxSettings.async = false;
        $.getJSON(window.location.href + '&action=getorgansetting&rn' + Math.random(), function (data) {
            alowdaoru = data.IsCanImport;

        })

        if (alowdaoru == false) {
            alert("非法操作!无授权！")
            return false;
        }
        var cur_url = document.location.href.substring(0, document.location.href.indexOf("syid=") - 1);
        cur_url = cur_url.substring(cur_url.lastIndexOf("/") + 1);
        var syid = document.location.href.substring(document.location.href.indexOf("syid=") + 5);
        syid = syid.substring(0, syid.indexOf("&state"));

        var syid1 = document.location.href.substring(document.location.href.indexOf("syid1=") + 6);
        var url = "../ReportForm/Data_DaoRu.aspx?url=" + cur_url + "&syid=" + syid + "&syid1=" + syid1 + "&rnd=" + Math.random() + "";
        parent.KXO.frm.openWin(url, { title: '数据复制', width: 860, height: 560, isMaxmin: false });
        //parent.document.getElementById("ModalWindowFrame").src = url;
        ////parent.$('#w').window({ maximizable: false, closable: false, draggable: false, collapsible: false, inline: false, shadow: false, maximized: false });
        //parent.$('#w').window({ title: "数据复制", maximizable: false, closable: true, draggable: true, collapsible: false, minimizable: false, maximized: false, width: 500, height: 300, left: ($(document).width() - 800) / 2, top: ($(document).height() - 500) / 2 });

        //parent.$('#w').window('open');
    }
    if (event.shiftKey && event.keyCode == '90') {//ctrl键+B键显示控件id,为了方便脱离ide时候查看id
        input.value = '';
        event.returnValue = false;
    }
    if (event.ctrlKey && event.keyCode == '70') {//ctrl键+F键查找指定的控件id,为了方便脱离ide时候快速查找id
        var cid = window.prompt("请输入要查找的控件id，结果将以红色表示", "");
        try {
            FindControl(cid);
        }
        catch (e) { }
        event.keyCode = 0;
        return false;
    }




    //if (oldid != newid) {
    //    if (isIn(code, FloatArr))//是浮点数
    //    {
    //        if (!isIn(code, Msg))//但不能是特殊控制键。
    //        {
    //            //input.value="";
    //            //input.select();
    //        }
    //    }
    //    oldid = newid;
    //}
    //if (oldstr != input) {
    //    oldstr = input;
    //    isnew = true;
    //}
    //else {
    //    isnew = false;
    //}


    ////if (isnew!=true)
    ////{
    ////js=0;
    ////ctljs=0;
    ////CurentValue=null;
    ////isnew=false;
    //// }
    //if (isnew == true) {
    //    CurentValue[js] = input.value;
    //    js++;
    //    ctljs = js;
    //}
    //if (event.ctrlKey && event.keyCode == 90) {    //撤銷當前輸入(只針對當前控件)
    //    input.value = CurentValue[ctljs - 1];
    //    ctljs--;
    //}
    //var str = new String();
    //var inputValue = new String();
    //try {
    //    if (oldstr != (document.getElementById(input.id)))
    //        keepdot = true
    //} catch (e) { }
    //inputValue = input.value;
    //str = input.id;//获取事件源控件的名字
    //str.toLowerCase;

    //if ((input.tagName.toUpperCase() == "INPUT") || (input.tagName.toUpperCase() == "TEXTAREA")) {
    //    try {
    //        document.getElementById(input.id).focus();

    //    } catch (e) { }
    //}
    //if (code == "13") { //回车健转换为TAB键转到下一行。

    //    if ((input.id.indexOf("Button") != -1) || (input.id.indexOf("btn") != -1)) {
    //       input.click();
    //    }
    //    else {

    //        if (input.tagName.toUpperCase() == "INPUT") {
    //            getdate();
    //            event.cancel = true;
    //            event.keyCode = "9";

    //        }
    //        if (input.tagName.toUpperCase() == "TEXTAREA") {
    //            if (input.rows < enterclick) {
    //                getdate();
    //                enterclick = 2;
    //                event.keyCode = "9"
    //            }
    //            else {
    //                enterclick++;
    //            }
    //        }
    //    }
    //}
    //***********************************  只读控件 ***********************************************//
    //if ((str.substring(0, 1) == 'r') && (str.substring(0, 2) != 're')) {              //如果控件头为r表示此控件只读。
    //    if (!isIn(code, Msg)) {
    //        global_msg = '有底色区域是系统计算区，可自行修改！'
    //    }
    //    getdate();
    //    //event.keyCode="9";
    //}

    ////***********************************  只读控件结束 ***********************************************//
    ////***********************************  延度验证开始 ***********************************************//
    ////------------------------------命名规则： 如 y2ddd           y为首字母 2为位数，ddd为任意合法字符。//
    //if (str.substring(0, 1) == "y") {              //如果控件头为y表示为延度。少数地方用到。


    //}

    ////***********************************  延度验证结束 ***********************************************//
    //if (ValiDate == false)
    //    return;
    ////***********************************  整数验证开始  *****************************************//
    ///* if (str.substring(0,1)=='i'){              //如果控件头为i表示为整数。
    //     if (event.ctrlKey && event.keyCode==90)
    //     {
    //         return 
    //     }
    //     if ((code<48)||(code>57)){
    //         if (isIn(code,IntArr)||isIn(code,Msg)){
    //             if(isIn(code,IntArr))
    //             {
    //                 save=true;
    //             }
    //             return
    //         } 
    //         else{
    //                 global_msg='请输入整数！'
    //                 return false
    //             }
    //         }
    //  } */
    ////***********************************  整数验证结束  ****************************************//

    ////***********************************  日期验证开始  ****************************************//  
    //if (str.substring(0, 1) == 'd') {              //如果控件头为d表示为日期类型。

    //}
    ////************************************  日期验证结束  ****************************************//

    ////************************************  浮点数验证开始  ****************************************//

}
function diskeyup(id) {
    var str = window.event.srcElement.tagName.toUpperCase();
    if (str == "INPUT" || str == "TEXTAREA")//在获取焦点的时候如果控件值为"/"就置为空字符串，但综合报告和打印时候例外。
    {
        var kk = id;//event.srcElement
        keyupValue = kk.value;
        keyupId = kk.id;
        if (keyupId == foucsId) {
            if (keyupValue != foucsValue) {
                if ((keyupValue != null) && (keyupValue != "") && (keyupValue != "/")) {
                    changed = true;
                }
            }
        }
    }

}
//Function showSource
//Description:view source;
function showSource() {
    window.location = "view-source:" + window.location.href;
}
function getdate() {
    var input = event.srcElement;
    var str;
    var d;
    var k = 0;
    d = new Date();
    diskeyup(input);
    window.event.srcElement.style.backgroundColor = ""
    str = input.id;
    str.toLowerCase;
    if (input.tagName.toLowerCase() == "input") {
        if ((str.substring(0, 1) == "i") || (str.substring(0, 1) == "f")) {
            if (isNaN(input.value)) {
                global_msg = "输入数据不合法,将替换为\"/\"";
                input.value = "/";
            }
        }
    }
    if (str.substring(0, 1) != "r") {
        global_msg = "";
    }
    temp = input.value;
    if ((str.substring(0, 3) != "drp") && (str.substr(0, 1) == 'd')) {
        if (isDate(input.value))
            return
        else {
            if ((input.value) != '')
                global_msg = '您输入的不是合法的日期格式，将替换为当前日期！'
            //input.value=d.getFullYear()+'年'+(d.getMonth()+1)+'月'+d.getDate()+'日'
            //wuchen 修改为 2004-3-17 格式 为保证保存不出错

            input.value = d.getFullYear() + '-' + (d.getMonth() + 1) + '-' + d.getDate()
        }
    }
    if (((str.substr(0, 1)) == 'f') && (temp != '') && (temp != '/')) {
        /*j=str.substr(1,1);
		if (IsExist('.',temp)){             //有小数点
			k=temp.length-temp.indexOf(".")-1;
			switch (j-k){
				case 6:temp=temp+'000000';break;
				case 5:temp=temp+'00000';break;
				case 4:temp=temp+'0000';break;
				case 3:temp=temp+'000';break;  //保留3位小数
				case 2:temp=temp+'00';break;  //保留2位小数
				case 1:temp=temp+'0';break;  //保留1位小数   
				default:break; }
		}
		else
		{
		 if (temp!="/")
		  switch (j*1){                     //无小数点
				case 6:temp=temp+'.000000';break;
				case 5:temp=temp+'.00000';break;
				case 4:temp=temp+'.0000';break;
				case 3:temp=temp+'.000';break;  //保留3位小数
				case 2:temp=temp+'.00';break;  //保留2位小数
				case 1:temp=temp+'.0';break;  //保留1位小数   
				default:break; }
		}*/
        input.value = temp;
    }
}
var foucsId, foucsValue, keyupId, keyupValue;
var changed = false;
function beforedit() {


    //var str = window.event.srcElement.tagName.toUpperCase();
    //var temp = window.location.href;
    //if (isReadOnly) {
    //    return false;
    //}
    ////if (window.event.srcElement.id.toUpperCase().substring(0, 1) != "R") {
    ////    //if((!(/(Form\/xc\/)/.test(temp)))&&(!(/(lq_lh)/.test(temp))))//现场控件可能太多就不执行下面的代码了。//改写后不管了。
    ////    {
    ////        clearfoucscolor();
    ////    }
    ////    if (window.event.srcElement.id != null)//没有id
    ////    {
    ////        if (window.event.srcElement.id != "")//表头表尾。
    ////        {
    ////            window.event.srcElement.style.backgroundColor = foucscolor;//foucscolor
    ////        }
    ////    }
    ////}

    ////if (window.event.srcElement.id.toUpperCase().substring(0, 3) == "REP")//表头表尾恰好为repotyform开头．不爽呀！！！！！！！！！！！
    ////{
    ////    clearfoucscolor();
    ////    window.event.srcElement.style.backgroundColor = foucscolor;//foucscolor
    ////}
    //if (str.substring(0, 1) != "") {
    //    global_msg = "";
    //}
    //if ((str == "INPUT" || str == "TEXTAREA") && (!(/(zh.aspx?)/.test(temp))))//在获取焦点的时候如果控件值为"/"就置为空字符串，但综合报告和打印时候例外。
    //{
    //    var kk = event.srcElement;


    //    foucsId = window.event.srcElement.id;
    //    foucsValue = kk.value;
    //    if (kk.value == '/') {
    //        if (isReadOnly != true) {
    //            if (!opratedAbled == 0)
    //                kk.value = ''
    //        }
    //        else {
    //            window.event.srcElement.blur();
    //        }

    //    }
    //   kk.style.backgroundColor = foucscolor;

    //    alert(foucscolor);

    //    if (!isIn(foucsId, ctlarry)) {
    //        ctlarry[ctlcount] = foucsId;
    //        ctlarryValue[ctlcount] = foucsValue;
    //        ctlcount++;
    //    }
    //}
}



//var combox =new Combox();
//    combox.add(item);
//    combox.add(item,value); 
//    combox.MaxHeight = 150;
//    combox.width=200;
//    combox.show();
//
//全局的div;而不再针对某个
var div = document.createElement("div");
div.id = "this_is_a_self_combox_div_";
//$(function () {


//    //修改成对所有的table都起作用

//    var tables = $(document).find("table");
// //   alert(tables.length);
//    var inputType = "text";

//    $.each(tables,function(n,myobj){
////        var tableId = "fromxml";
////        var tableId = "fromxml";


//        var rowInputs = [];
//  //    var trs = $("#" + tableId).find("tr");
//        var trs = $(myobj).find("tr");
//        var inputRowIndex = 0;
//        $.each(trs, function (i, obj) {
//            if ($(obj).find("th").length > 0) { //跳过表头
//                return true;
//            }
//            var rowArray = [];
//            var thisRowInputs;
//            if (!inputType) { //所有的input
//                thisRowInputs = $(obj).find("input:not(:disabled):not(:hidden):not([readonly])");
//            } else {
//                thisRowInputs = $(obj).find("input:not(:disabled):not(:hidden):not([readonly])[type=" + inputType + "]");
//            }
//            if (thisRowInputs.length == 0)
//                return true;

//            thisRowInputs.each(function (j) {
//                $(this).attr("_r_", inputRowIndex).attr("_c_", j);
//                rowArray.push({ "c": j, "input": this });

//                $(this).keydown(function (evt)
//                {
//                    var r = $(this).attr("_r_");
//                    var c = $(this).attr("_c_");
//                    //   alert(evt.keyCode)
//                    var tRow
//                    // evt = $.event.fix(evt); //修正event事件
//                    //var evt = (evt) ? evt : ((window.event) ? window.event : "");
//                    if (evt.keyCode == 38) { //上

//                        if (r == 0)
//                            return;

//                        r--; //向上一行

//                        tRow = rowInputs[r];
//                        if (c > tRow.length - 1) {
//                            c = tRow.length - 1;
//                        }
//                        this.blur();
//                        $(rowInputs[r].data[c].input).focus();
//                    } else if (evt.keyCode == 40 || evt.keyCode ==13) { //下

//                        if (evt.keyCode == 13)
//                        {
//                            event.stopPropagation(); //取消冒泡
//                            event.preventDefault(); //取消浏览器默认行为
//                        }
//                        if (r == rowInputs.length - 1) { //已经是最后一行
//                            return;
//                        }

//                        r++;
//                        tRow = rowInputs[r];
//                        if (c > tRow.length - 1) {
//                            c = tRow.length - 1;
//                        }
//                        this.blur();
//                        $(rowInputs[r].data[c].input).focus();
//                    } else if (evt.keyCode == 37) { //左

//                        if (r == 0 && c == 0)
//                        {  //第一行第一个,则不执行操作
//                            return;
//                        }
//                        if (c == 0) { //某行的第一个,则要跳到上一行的最后一个,此处保证了r大于0
//                            r--;
//                            tRow = rowInputs[r];
//                            c = tRow.length - 1;
//                        } else { //否则只需向左走一个
//                            c--;
//                        }
//                        this.blur();
//                        $(rowInputs[r].data[c].input).focus();
//                    } else if (evt.keyCode == 39) { //右

//                        tRow = rowInputs[r];
//                        if (r == rowInputs.length - 1 && c == tRow.length - 1) { //最后一个不执行操作
//                            return;
//                        }

//                        if (c == tRow.length - 1) { //当前行的最后一个,跳入下一行的第一个
//                            r++;
//                            c = 0;
//                        } else {
//                            c++;
//                        }
//                        this.blur();
//                        $(rowInputs[r].data[c].input).focus();
//                    }

//                    try{
//                        var val = $(rowInputs[r].data[c].input).val();
//                        // var val = rowInputs[r].data[c].input.value;
//                        if (val == "/") {  //如果是/,则自动去掉/
//                            //rowInputs[r].data[c].input.value = '';
//                            $(rowInputs[r].data[c].input).val('');

//                        }

//                    }
//                    catch (e) {
//                     //   alert(e.message);
//                    }





//                });
//            });

//            rowInputs.push({ "length": thisRowInputs.length, "rowindex": inputRowIndex, "data": rowArray });

//            inputRowIndex++;

//        });

//        //$('input:text:first').focus();

//        //var $inp = $('input:text');

//        //$inp.bind('keydown', function (e) {
//        //    var event = $.event.fix(e); //修正event事件
//        //    if (e.keyCode == "37" ||
//        //             e.keyCode == "38" ||
//        //             e.keyCode == "49" ||
//        //             e.keyCode == "40" ||
//        //             e.keyCode == "13"

//        //        ) {
//        //        new tabTableInput("fromxml", "text");
//        //    }
//        //    else {

//        //        diskeydown();
//        //        // alert(e.keyCode);
//        //    }
//        // });
//    })

//});


$(function () {

    var scriptOnPage = ['sl_sb01.aspx', 'sl_sr01.aspx', 'sl_s901.aspx']
    var flag = true;
    for (var i = 0; i < scriptOnPage.length; i++) {
        if (window.location.href.indexOf(scriptOnPage[i]) != -1) {
            flag = false;
            break;
        }
    }
    if (flag) {
        var ips = new Array();
        var i = 0;
        $("tr").each(function () {
            var ip = $(this).find(":text:not(:disabled):not(:hidden):not([readonly]),textarea:not(:disabled):not(:hidden):not([readonly])");//find("input:not(:disabled):not(:hidden):not([readonly])[type=" + inputType + "]")
            var tr = $(this).find("tr");
            if (ip.length > 0 && tr.length == 0) {
                for (var j = 0; j < ip.length; j++) {
                    $(ip[j]).attr("_r_", i).attr("_c_", j);
                }
                ips.push(ip);
                i++;
            }
        })

        for (var i = 0; i < ips.length; i++) {
            for (var j = 0; j < ips[i].length; j++) {
                $(ips[i][j]).keydown(function (evt) {

                    var r = parseInt($(this).attr("_r_"));
                    var c = parseInt($(this).attr("_c_"));
                    if (evt.keyCode == 38)   //上
                    {
                        if (r == 0) return;  //第一行
                        else if (ips[r - 1].length > c) //上方行有足够的列
                        {
                            r--;
                        }
                        else   //上方行没有足够的列
                        {
                            r--;
                            c = ips[r].length - 1;
                        }
                        this.blur();               //放到外面会导致不能输入汉字
                        $(ips[r][c]).focus();
                        if (evt && evt.preventDefault)  //取消浏览器默认行为，否则select()起不到作用。
                            evt.preventDefault();
                        $(ips[r][c]).select();
                    }
                    else if (evt.keyCode == 40 || evt.keyCode == 13) //下
                    {
                        if (evt.keyCode == 13) {
                            evt.stopPropagation(); //取消冒泡
                            evt.preventDefault(); //取消浏览器默认回车键行为
                        }

                        if (r == ips.length - 1) return;  //最后一行
                        else if (ips[r + 1].length > c)  //下方行有足够的列
                        {
                            r++
                        }
                        else  //下方行没有足够的列
                        {
                            r++;
                            c = ips[r].length - 1;
                        }
                        this.blur();
                        $(ips[r][c]).focus();
                        if (evt && evt.preventDefault)
                            evt.preventDefault();
                        $(ips[r][c]).select();
                    }
                    else if (evt.keyCode == 37)  //左
                    {
                        if (r == 0) {
                            if (c == 0) return;  //第一行第一列
                            else       //第一行非第一列
                            {
                                c--;
                            }
                        }
                        else {
                            if (c == 0)  //非第一行第一列
                            {
                                r--;
                                c = ips[r].length - 1;
                            }
                            else   //非第一行非第一列
                            {
                                c--;
                            }
                        }
                        this.blur();
                        $(ips[r][c]).focus();
                        if (evt && evt.preventDefault)
                            evt.preventDefault();
                        $(ips[r][c]).select();
                    }
                    else if (evt.keyCode == 39)  //右
                    {
                        if (r == ips.length - 1) {
                            if (c == ips[r].length - 1) return;  //最后一行最后一列
                            else                        //最后一行非最后一列
                            {
                                c++
                            }
                        }
                        else {
                            if (c == ips[r].length - 1)  //非最后一行最后一列
                            {
                                r++;
                                c = 0;
                            }
                            else   //非最后一行非最后一列
                            {
                                c++
                            }
                        }
                        this.blur();
                        $(ips[r][c]).focus();
                        if (evt && evt.preventDefault)
                            evt.preventDefault();
                        $(ips[r][c]).select();
                    }



                    try {
                        var val = $(ips[r][c]).val();
                        if (val == "/") {
                            $(ips[r][c]).val('');

                        }
                    }
                    catch (e) {

                    }
                })
            }
        }
    }
})

function keydownEx(yid, nid, evt) {
    $("#" + yid).blur();
    $("#" + nid).focus();
    if (evt && evt.preventDefault)
        evt.preventDefault();
    $("#" + nid).select();
}

//下列代码对事件进行了绑定
$(function () {
    $(document).bind("mousedown", function (e) {
        if (e.srcElement != div) {
            div.style.display = "none";
        }
        //  beforedit(e);
    });

    $(document).bind("blur", function () {
        div.style.display = "none";
    });


    $(document).bind("keydown", diskeydown);
    $(document).bind("help", help);
})
var curInputId = '';
//$(document).bind("mousedown", function () {
//    div.style.display = "none"; beforedit();
//}).bind("blur", function () { div.style.display = "none"; })
//   .bind("keydown", diskeydown).bind("help", help);

//$(window).onblur = function () { div.style.display = "none";};
function Combox() {
    this.items = new Array();    //创建一个数组来保存数据列表

    this.object = null;//来保存触发本控件的对象



    this.left = 0; //左边距 
    this.top = 0; //上边距,24为对应控件的高度
    this.width = "150";
    this.height = "100";
    this.MaxHeight = 200;
    this.splitStr = "_~o~_";
    this.create = function () {
        //this.left = event.x - event.offsetX + document.body.scrollLeft;
        //this.top = event.y - event.offsetY + 18 + document.body.scrollTop; //$("#kxdropdownbtn").offset().top + $("#kxdropdownbtn")[0].clientHeight + 2

        //this.left = $(event.srcElement).offset().left;
        this.top = $(event.srcElement).offset().top + $(event.srcElement)[0].clientHeight + 2;
        this.height = 28 * this.items.length; //默认现实行数
        this.height = Math.min(this.MaxHeight, this.height);
        //if (this.width > $(event.srcElement).width()) {
        //    this.left = this.width - $(event.srcElement).width() - 8;
        //}
        //else {
        //    this.left = $(event.srcElement).width() - this.width + $(event.srcElement).offset().left+8;
        //}
        if (location.href.indexOf("syid") != -1) {//代表是在记录和报告中 @hxb 2016-12-02
            this.left = $(event.srcElement).offset().left - (this.width - $(event.srcElement).width());
            if (this.width > $(event.srcElement).offset().left) {
                this.left = $(event.srcElement).offset().left;
            }
        }
        else {
            this.left = $(event.srcElement).offset().left - (this.width - $(event.srcElement).width()) + 8;
        }
        //alert(this.left);
        var divcss = {
            position: 'absolute',
            background: 'white',
            overflow: 'auto',
            width: this.width,
            left: this.left,
            top: this.top,
            height: this.height,
            border: '1px solid black'
        };

        $("#" + div.id).css(divcss);
        div.style.zIndex = "1000001";







        var s = "<table width='100%'  cellpadding='3' cellspacing='0' border='0' id=_drpListTable>";
        var item = "";
        var s__value = "";
        for (i = 0; i < this.items.length; i++) {
            if (this.items[i].indexOf(this.splitStr) != -1) {
                item = (this.items[i].split(this.splitStr))[0];

                s__value = (this.items[i].split(this.splitStr))[1];
                if (s__value == "" || s__value == null || s__value == "undefined") {
                    s__value = item;
                }
            }
                //下面这个else本来可以没有的，很奇怪，如果不split取不到值
            else {
                item = this.items[i];
                s__value = this.items[i];
            }
            //alert(__value);
            var objectid = this.object.id.replace(":", "\\\\:");
            s += "<tr ><td   height='24' class=\"dropDownListColor\""
            + "width=100%  onmousedown='$(\"#" + objectid + "\").val(\"" + s__value + "\");$(\"#" + div.id + "\").hide();$(curInputId).focus();'>"
            + item + "</td></tr>";
        }
        s += "</table>";
        div.innerHTML = s;
        $("#" + div.id).show();
        if ($("#_drpListTable").height() < 300) $("#" + div.id).css({ "height": $("#_drpListTable").height() });
        else $("#" + div.id).css({ "height": "300px" });
    }
    this.show = function () {
        this.object = event.srcElement;
        document.body.appendChild(div);

        this.create();
    }


    this.add = function (item) {
        this.items[this.items.length] = item + this.splitStr + "";
    }

    this.add = function (item, value) {
        this.items[this.items.length] = item + this.splitStr + value;
    }
}



///////////////////////////////该函数对控件名以r开头的数据结果操作控制/////////
//////当结果给"NaN"时，替换为"/"  \\\///////////////////////
//var e="";  //在diskeydown()赋值。注意例外的时候设置title的属性。
function getx(e) {
    save = true;
    if (e.id == "") {
        e = event.srcElement;
    }
    //if(document.getElementById(e.id).value=="NaN"||(document.getElementById(e.id).value-0==0)){
    if (document.getElementById(e.id).value == "NaN") {
        ////////例外情况
        if (e.title == "zone" && e.value != "NaN")
            return false;
        //if (!IsBlank(document.getElementById(e.id).value))
        //{
        //return false;
        //}
        ////////////////
        //alert(Masterreturn)
        if (!Masterreturn) {
            document.getElementById(e.id).value = "/";
        }
    }
}

function readonly() {
    if (isReadOnly == false) {
        global_msg = "当前文本只读，不可编辑,如果您正处在检测报告页，您只可编辑报表头和表尾信息。"
        //alert(event.srcElement.id);
    }
    event.srcElement.blur();
}
var oldfoucs = "";
var newfoucs = "";
function clearfoucscolor()//保存前检查是否有数据类型不一致的数据，并提示用户位置和处理方式。
{
    var str = window.event.srcElement.tagName.toUpperCase();
    if ((str != "INPUT") && (str != "TEXTAREA")) {
        return
    }
    if (window.event.srcElement == null)
        return
    newfoucs = window.event.srcElement.id;
    if (newfoucs == "") {
        return
    }
    if (newfoucs == oldfoucs) {
        return
    }
    else {
        if (document.getElementById(oldfoucs) == null) {
            oldfoucs = newfoucs;
            return
        }
        else {
            document.getElementById(oldfoucs).style.backgroundColor = "";
            oldfoucs = newfoucs;
        }
    }
}



