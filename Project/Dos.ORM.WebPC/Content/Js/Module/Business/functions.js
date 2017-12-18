
//本文件内包含的是有关试验数据的修约规则函数

/*1、四舍五入、奇进偶舍 GetDataOddIncreaseEvenDecrease(in_value,keepdigit)
  2、GetDataFiveRule(in_value,keepdigit)// 0.5单位修约，x<=0.25,0.0; 0.25<x<0.75,0.5; x>=0.75,1.0  
  
  3、GetAverage():          本函数有两种使用方式：求任意多数的平均数，将每个数当参数传入;你也可以传入一个数组，当然数组只能一个了，数组维数不管（这种方式主要是配合MakeValue(min)使用，MakeValue(min)返回的就是一个数组）。
  
  4、GetYD()                本函数是有关延度的计算
  5、GetZRD()               本函数是有关针入度的计算
  6、GetRHD(a,b,keepdigit)  本函数是有关软化点的计算
  7、Max()                  求最大值       //参数个数不限
  8、Min()                  求最小值    //参数个数不限
  9、lg()                   求lg的对数（以10为底的对数）
  10 GetS()                 // 求x1，x2……的平均值x的标准差, 参数为x1到xn,也可以是数组
  11 GetCv()                计算变异系数Cv,即偏差系数，参数也可以是数组
  12 GetNum(str)　　　　　　//将＂150*200*200＂这样的字符串转化成150*200*200的数字类型
  13 IsYear(year)           //判断是否为润年
  14 GetDay(y1,y2)          //计算两个年月日之间的差距
  15 Gauss(x,y)              //高斯列主元消去法求解线性方程组,返回该方程组的解，X[n][n]，Y[n]
  16 Newton(xs,min,max,step)  ///牛顿迭代求多项式的最大值，需要Gauss(x,y)，结合起来应用，xs多项式参数数组，min,max
							//传入最大值范围，step表示递增的刻度//////////////////
							
  17 CallXY(array_x,array_y,y)//参数array_x,array_y，为坐标点数组，X，Y，；Y为所求的坐标点Y，返回Y对应的X
  18 ChangeToNo(str_)  //将字符串转换成数字
  19 GetHpValue(wl,type)//土工和矿粉试验依据[砂类土][type=0]
                          //土工和矿粉试验依据[细粒土][type=1]
  20 GetTwoKeep(f_value,i_keep)//保留N有效数字
  21 GetEvenRule(f_value,i_keep)//i_keep=0,1,2
  22 GetSimulate_Line(arrayofx,arrayofy)//array_xy,数组（X，Y）//返回Y=A*X+B的系数
  23 IsBlank(Fvalue)//确定一个值是否空值，注意不能用"".
  24 DataFiveRule(in_value,keepdigit)
  25 StandardDeviation() //算标准差
  26 InterpolationMethod();//直线内插法
  27 xdpc();//相对偏差
  28 GetNEffective(in_value,i_keep)//保留三位有效数
*/


//getDataOddIncreaseEvenDecrease:原则上遵循四舍五入，但当取数为5时，且它的后面没有数字时，
//它的取舍要看前一位数的奇偶性，奇为进，偶舍，
//例如保留小数1位时：12.35，修约后为12.4；12.45修约后为12.4
//in_value为要修约的值，keepdigit为精确位数
//return 修约值
function GetDataOddIncreaseEvenDecrease(in_value, keepdigit) {
    var i;
    var tmp1, tmp2;
    var sxz;
    if (in_value.toString().indexOf("49999999") != -1) {
        in_value = in_value * 1 + 0.00001;
    }
    in_value = in_value * 1;
    keepdigit = keepdigit * 1;
    i = 1;
    tmp2 = in_value;

    if (Math.floor(in_value) * 1 == in_value * 1)    //即小数为0
    {
        switch (keepdigit) {
            case -7: sxz = in_value + '.000000000'; break;
            case -6: sxz = in_value + '.00000000'; break;
            case -5: sxz = in_value + '.0000000'; break;
            case -4: sxz = in_value + '.000000'; break;
            case -3: sxz = in_value + '.00000'; break;  //保留3位小数
            case -2: sxz = in_value + '.0000'; break;  //保留2位小数
            case -1: sxz = in_value + '.000'; break;  //保留1位小数
            case 1: sxz = in_value + '.00'; break;    //保留整数 
            case 2: sxz = in_value + '.0'; break;
            case 3: sxz = in_value; break;
            default: break;
        }
    }
    else
        switch (keepdigit) {
            case -7: sxz = (in_value * 1).toFixed(9); break;
            case -6: sxz = (in_value * 1).toFixed(8); break;
            case -5: sxz = (in_value * 1).toFixed(7); break;
            case -4: sxz = (in_value * 1).toFixed(6); break;
            case -3: sxz = (in_value * 1).toFixed(5); break;
            case -2: sxz = (in_value * 1).toFixed(4); break;
            case -1: sxz = (in_value * 1).toFixed(3); break;
            case 1: sxz = (in_value * 1).toFixed(2); break;
            case 2: sxz = (in_value * 1).toFixed(1); break;
            case 3: sxz = (in_value * 1); break;
            default: break;
        }
    if ((sxz * 1) > (tmp2 * 1))
        switch (keepdigit) {
            case -7: sxz = (sxz - 0.00000001).toFixed(9); break;
            case -6: sxz = (sxz - 0.00000001).toFixed(8); break;
            case -5: sxz = (sxz - 0.0000001).toFixed(7); break;
            case -4: sxz = (sxz - 0.000001).toFixed(6); break;
            case -3: sxz = (sxz - 0.00001).toFixed(5); break;
            case -2: sxz = (sxz - 0.0001).toFixed(4); break;
            case -1: sxz = (sxz - 0.001).toFixed(3); break;
            case 1: sxz = (sxz - 0.01).toFixed(2); break;
            case 2: sxz = (sxz - 0.1).toFixed(1); break;   //tmp2-0.1
            case 3: sxz = (sxz - 1).toFixed(0); break;
            default: break;
        }
    tmp2 = sxz + '1';
    sxz = tmp2.substr(0, tmp2.length - 1);

    if ((keepdigit == 3) || (keepdigit == -1) || (keepdigit == -2) || (keepdigit == -3) || (keepdigit == -4) || (keepdigit == -5) || (keepdigit == -6) || (keepdigit == -7)) {

        if (sxz.substr(sxz.length - 2, 2) == 50) {
            if ((sxz.substr(sxz.length - 3, 1) % 2) == 0) {
                tmp1 = sxz.substr(0, sxz.length - 2);
                if (in_value.toString().indexOf(sxz) != -1) {
                    if (in_value * 1 - sxz * 1 > 0) {
                        tmp1 = in_value;
                    }
                }
            }
            else {
                tmp1 = sxz.substr(0, sxz.length - 2);
                if (tmp1 < 0) i = -1;
                switch (keepdigit) {
                    case -7: tmp1 = (tmp1 * 1) + 0.0000001 * i; break;
                    case -6: tmp1 = (tmp1 * 1) + 0.000001 * i; break;
                    case -5: tmp1 = (tmp1 * 1) + 0.00001 * i; break;
                    case -4: tmp1 = (tmp1 * 1) + 0.0001 * i; break;
                    case -3: tmp1 = (tmp1 * 1) + 0.001 * i; break;
                    case -2: tmp1 = (tmp1 * 1) + 0.01 * i; break;
                    case -1: tmp1 = (tmp1 * 1) + 0.1 * i; break;
                    default: tmp1 = (tmp1 * 1) * 100 + 100 * i; break;
                }
            }
        }
        else if (sxz.substr(sxz.length - 2, 2) < 50) {
            tmp1 = sxz.substr(0, sxz.length - 2);
        }
        else if ((sxz.substr(sxz.length - 2, 2) > 50) || (sxz < in_value)) {
            tmp1 = sxz.substr(0, sxz.length - 2)
            if (tmp1 < 0) i = -1;
            switch (keepdigit) {
                case -7: tmp1 = (tmp1 * 1) + 0.0000001 * i; break;
                case -6: tmp1 = (tmp1 * 1) + 0.000001 * i; break;
                case -5: tmp1 = (tmp1 * 1) + 0.00001 * i; break;
                case -4: tmp1 = (tmp1 * 1) + 0.0001 * i; break;
                case -3: tmp1 = (tmp1 * 1) + 0.001 * i; break;
                case -2: tmp1 = (tmp1 * 1) + 0.01 * i; break;
                case -1: tmp1 = (tmp1 * 1) + 0.1 * i; break;
                default: tmp1 = (tmp1 * 1) * 100 + 100 * i; break;
            }
        }

    }
    if (keepdigit == 1)
        if ((sxz.substr(sxz.length - 2, 2) == 50))//&& (sxz * 1 == in_value)
            if ((sxz.substr(sxz.length - 4, 1) % 2) == 0)
                tmp1 = sxz.substr(0, sxz.length - 3)
            else {
                tmp1 = sxz.substr(0, sxz.length - 3)
                if (tmp1 < 0) i = -1;
                tmp1 = tmp1 * 1 + 1 * i
            }
        else if (sxz.substr(sxz.length - 2, 2) < 50)
            tmp1 = sxz.substr(0, sxz.length - 3)
        else if ((sxz.substr(sxz.length - 2, 2) > 50) || (sxz * 1 < in_value)) {
            tmp1 = sxz.substr(0, sxz.length - 3)
            if (tmp1 < 0) i = -1;
            tmp1 = tmp1 * 1 + 1 * i;
        }

    if (keepdigit == 2)
        if ((sxz.substr(sxz.length - 3, 3) == 5.0) && (sxz * 1 == in_value))
            if ((sxz.substr(sxz.length - 4, 1) % 2) == 0)
            { tmp1 = sxz.substr(0, sxz.length - 3) * 10; }
            else
            {
                tmp1 = sxz.substr(0, sxz.length - 3)
                if (tmp1 < 0) i = -1;
                tmp1 = tmp1 * 10 + 10 * i;
            }
        else if (sxz.substr(sxz.length - 3, 3) < 5.0)
            tmp1 = sxz.substr(0, sxz.length - 3) * 10;
        else if ((sxz.substr(sxz.length - 3, 3) > 5.0) || (sxz * 1 < in_value)) {
            tmp1 = sxz.substr(0, sxz.length - 3);
            if (tmp1 < 0) i = -1;
            tmp1 = tmp1 * 10 + 10 * i;
        }

    switch (keepdigit) {
        case -7: tmp2 = (tmp1 * 1).toFixed(7); break;
        case -6: tmp2 = (tmp1 * 1).toFixed(6); break;
        case -5: tmp2 = (tmp1 * 1).toFixed(5); break;
        case -4: tmp2 = (tmp1 * 1).toFixed(4); break;
        case -3: tmp2 = (tmp1 * 1).toFixed(3); break;
        case -2: tmp2 = (tmp1 * 1).toFixed(2); break;
        case -1: tmp2 = (tmp1 * 1).toFixed(1); break;
        default: tmp2 = (tmp1 * 1).toFixed(0); break;
    }
    return tmp2;

}
function IsYear(obj) {
    obj = parseInt(obj);                //可选：将year转换为数字类型
    var check4 = (0 == obj % 4);            //判断年份是否能被4整除
    var check100 = (0 == obj % 100);        //判断年份是否能被100整除
    var check400 = (0 == obj % 400);        //判断年份是否能被400整除
    //给出判断结果
    if ((check4 && !check100) || check400) return true;
    return false;
}
function gjhj(obj) {
    var temp = 0;
    var s = obj.substr(obj.length - 1, 1)
    if (s == 1) {
        temp = obj * 1 - 1 * 1;
    }
    if (s == 2) {
        temp = obj * 1 - 2 * 1;
    }
    if (s == 3) {
        temp = obj * 1 + 2 * 1;
    }
    if (s == 4) {
        temp = obj * 1 + 1 * 1;
    }
    if (s == 6) {
        temp = obj * 1 - 1 * 1;
    }
    if (s == 7) {
        temp = obj * 1 - 2 * 1;
    }
    if (s == 8) {
        temp = obj * 1 + 2 * 1;
    }
    if (s == 9) {
        temp = obj * 1 + 1 * 1;
    }
    return temp;
}

//GetDataFiveRule:
//0.5单位修约，x<=0.25时,0.0; 0.25<x<0.75时0.5; x>=0.75时,1.0 
//5单位修约，x<=2.5时,0; 2.5<x<7.5时5; x>=7.5时,10 
//0.05单位修约，x<=0.025时,0.00; 0.25<x<0.75时0.05; x>=0.75时,0.10 
//例如保留小数1位时：12.25，修约后为12.0；12.35，修约后为12.5；12.75修约后为13.0
//in_value为要修约的值，keepdigit为精确位数
//return 修约值
function GetDataFiveRule(in_value, keepdigit) {
    var tmp1, tmp2;

    keepdigit = keepdigit * 1;

    tmp1 = in_value * 2;                                            //保留1位小数
    if (keepdigit == -1)
        tmp2 = GetDataOddIncreaseEvenDecrease(tmp1, 1);
    else if (keepdigit == -2)                                      //保留2位小数
        tmp2 = GetDataOddIncreaseEvenDecrease(tmp1, -1);
    else if (keepdigit == 1)                                      //保留整数
        tmp2 = GetDataOddIncreaseEvenDecrease(tmp1, 2);

    tmp1 = tmp2 / 2;
    if (keepdigit == -1)
        return (tmp1 * 1).toFixed(1);
    else if (keepdigit == -2)
        return (tmp1 * 1).toFixed(2);
    else if (keepdigit == 1)
        return (tmp1 * 1).toFixed(0);
}
//////////////////////////本函数为求和函数，可传入数组和任意参数/////////////////
function GetTotal() {
    /*
        var s;
        if(typeof(arguments[0]=="object"){
            arguments=arguments[0];
        }
        for(i=0;i<arguments.lengtn;i++){
        }
        */
}
//求标准差
function StandardDeviation() {
    var fltall = 0;//求和的值
    var x2 = 0;    //平方和
    var len = arguments.length;
    var m = 0;                             //保存不是数字的参数个数。

    if (typeof (arguments[0]) == 'object')  //传入是数组
    {
        arrayObj = new Array()
        arrayObj = arguments[0];
        for (i = 0; i < arrayObj.length; i++) {
            fltall = fltall * 1
            arrayObj[i] = arrayObj[i] * 1
            if (!isNaN(arrayObj[i] * 1)) {
                fltall = fltall * 1 + arrayObj[i] * 1;
                x2 = x2 * 1 + arrayObj[i] * 1;
            }
            else {
                m = m + 1;
            }
        }
        if (isNaN(fltall / arrayObj.length))
            return "/"
        else
            return Math.sqrt((x2 - fltall * fltall / (len - m)) / (arrayObj.length - m - 1))
    }
    else                                 //直接传值。
    {
        for (i = 0; i < len; i++) {
            if (!!arguments[i] && arguments[i] != "/") {
                fltall = fltall * 1 + arguments[i] * 1;
                x2 = x2 * 1 + arrayObj[i] * 1;
            }
            else
                m = m + 1;
        }
        if (isNaN(fltall / (len - m))) {
            return "";
        }
        else {
            return Math.sqrt((x2 - fltall * fltall / (len - m)) / (len - m - 1))
        }
    }
}
//本函数求任意多数的平均数，使用如：avg(a,b,c,d) 将求a,b,c,d的平均数。
function GetAverage() {

    var fltall = 0;
    var len = arguments.length;
    var m = 0;                             //保存不是数字的参数个数。

    if (typeof (arguments[0]) == 'object')  //传入是数组
    {
        arrayObj = new Array()
        arrayObj = arguments[0];
        for (i = 0; i < arrayObj.length; i++) {
            fltall = fltall * 1
            arrayObj[i] = arrayObj[i] * 1
            if (!isNaN(arrayObj[i] * 1)) {
                fltall = fltall + arrayObj[i];
            }
            else {
                m = m + 1;
            }
        }
        if ((fltall / arrayObj.length) != 'NaN')
            return fltall / (arrayObj.length - m);
        else
            return ""
    }
    else                                 //直接传值。
    {
        for (i = 0; i < len; i++) {
            if (!!arguments[i] && arguments[i] != "/")
                fltall = fltall * 1 + arguments[i] * 1;
            else
                m = m + 1;
        }
        if (isNaN(fltall / (len - m)))
            return "/";
        return fltall / (len - m);
    }
}

/*  本函数是有关延度的计算
  参数只能是">100"或为纯数字
  传递输入的延度参数值

  fltmax-fltmin<= fltavg*0.2，否则，“重试”
  延度值>100时，返回>100 ;
*/
function GetYD() {
    var fltall = 0;
    var array = new Array();
    var len = arguments.length;
    var j = 0;
    var k = 0;
    for (i = 0; i < len; i++) {
        if (!!arguments[i]) {
            array[j] = arguments[i];
            j++;
        }
        if (arguments[i].search(">") > -1 && (arguments[i] == arguments[0]))
            k++;
    }
    if (k == len)
        return arguments[0];
    var fltmax = 0;
    var fltmin = 0;
    var fltcz;
    var fltavg;
    var k = 0;
    /*
    for(i=0;i<len;i++){
      if(!(arguments[i]-0)&&arguments[i]!=""){
          k=1;
          break;
      }
    }
    if(k==1){
      global_msg="输入了不合法的字符！"
      return "/"
    }
    */
    fltavg = GetAverage(array);
    fltavg = GetDataOddIncreaseEvenDecrease(fltavg, 1);
    fltmax = Max(array);
    fltmin = Min(array);
    fltcz = fltmax * 1 - fltmin * 1;
    // global_msg=array[0];
    if (fltcz > fltavg * 0.2) {
        global_msg = "延度平行试验误差超规范[最大值与最小值超过平均值的20%]，请重试！"
        //return "/";
    }
    if (fltavg - 0 == 0)
        return "/"
    return fltavg;
}

/*本函数是有关针入度的计算
  传递输入的针入度值

  fltavg            fltmax-fltmin
  0-49                 2
  50-149               4
  150-249              12
  250-500              20
  当fltavg在上述范围时，fltmax-fltmin<= 规定值，否则，“重试” 
*/
function GetZRD() {
    var fltall = 0;
    var array = new Array();
    var len = arguments.length;
    var j = 0;
    for (i = 0; i < len; i++) {
        if (!!arguments[i]) {
            array[j] = arguments[i];
            j++;
        }
    }
    len = array.length;
    var fltmax = Max(array);
    var fltmin = Min(array);
    var fltcz;
    var fltavg;
    fltavg = GetAverage(array);
    fltcz = fltmax * 1 - fltmin * 1;
    if (fltavg - 0 == 0)
        return "/"
    fltavg = GetDataOddIncreaseEvenDecrease(fltavg, 1);
    if ((fltavg >= 0) && (fltavg < 50))
        if (fltcz > 2)
            global_msg = "针入度平行试验误差超规范要求[针入度大于等于0，小于50时，结果大于2]，请重试！";
    if ((fltavg >= 50) && (fltavg < 149))
        if (fltcz > 4)
            global_msg = "针入度平行试验误差超规范要求[针入度大于等于50，小于147时，结果大于4]，请重试！";
    if ((fltavg >= 150) && (fltavg < 249))
        if (fltcz > 12)
            global_msg = "针入度平行试验误差超规范要求[针入度大于等于150，小于249时，结果大于12]，请重试！";
    if ((fltavg >= 250) && (fltavg < 500))
        if (fltcz > 20)
            global_msg = "针入度平行试验误差超规范要求[针入度大于等于250，小于500时，结果大于20]，请重试！";
    if (fltavg > 500)
        global_msg = "针入度平行试验误差超规范要求[针入度大于500]，请重试";
    return fltavg;

}

/*本函数是有关软化点的计算
  传递输入的软化点参数值

  当fltavg<80时,fltcz<=1;或fltavg>=80时，fltcz<=2;否则“重试”
  fltavg要遵循0.5的修约
*/
function GetRHD(a, b, keepdigit) {
    var fltcz;
    var fltavg;
    keepdigit = keepdigit * 1;
    var total = 0;
    var j = 0;
    if (!!a) {
        total = total + a * 1;
        j++;
    }
    if (!!b) {
        total = total + b * 1;
        j++;
    }
    fltavg = total / j;
    fltavg = GetDataFiveRule(fltavg, keepdigit);
    fltcz = Math.abs(a * 1 - b * 1);
    if (fltavg - 0 <= 0)
        return "/"
    if (fltavg < 80)
        if (fltcz > 1)
            global_msg = "软化点平行试验误差超规范要求[软化点小于80时，结果大于了1]，重试！";
    if (fltavg >= 80)
        if (fltcz > 2)
            global_msg = "软化点平行试验误差超规范要求[软化点大于等于80时，结果大于了2]，重试！"
    return fltavg;
}
/////////////////////////////求最大值////////////////
/////////////////参数可以是数组，或者是任意多的参数
function Max() {
    if (typeof (arguments[0]) == "object") {
        arguments = arguments[0];
    }
    var temp = 0.0;
    var large = 0.0;
    var len = arguments.length;
    large = arguments[0];
    for (i = 0; i < len; i++) {
        temp = arguments[i] * 1;
        if ((temp >= large) && (!isNaN(temp)))
            large = temp;
    }
    return large;
}
//////////////////////////////求最小值////////////////
/////////////////参数可以是数组，或者是任意多的参数
function Min() {
    if (typeof (arguments[0]) == "object") {
        arguments = arguments[0];
    }
    var temp = 0.0;
    var min = 0.0;
    var len = arguments.length;
    min = arguments[0];
    for (i = 0; i < len; i++) {
        temp = arguments[i] * 1;
        if ((temp <= min) && (!isNaN(temp)))
            min = temp;
    }
    return min;
}
///算中间值
function Mid(a, b, c) {
    var max = Max(a, b, c);
    var min = Min(a, b, c);
    var mid;
    mid = a * 1 + b * 1 + c * 1 - max * 1 - min * 1;
    return mid;
}
///算中间值
///a,b,c分别代表三个值,d代表超差值，默认为0.15(15%),e代表保留位数,f代表试验名称
function AvgOrMid(a, b, c, d, e, f) {
    d = d * 1;
    var ret = GetAverage(a, b, c);
    var max = Max(a, b, c) * 1;
    var min = Min(a, b, c) * 1;
    var mid = a * 1 + b * 1 + c * 1 - max * 1 - min * 1;
    if (Math.abs(max - mid) > mid * d && Math.abs(min - mid) > mid * d) {

        global_msg = f + "最大值(" + max + ")与最小值(" + min + ")与中间值(" + mid + ")之差均超过中间值的15%(" + mid * d + ")，试验无效！";
        ret = "无效";
        return ret;
    }
    else if (Math.abs(max - mid) > mid * d || Math.abs(min - mid) > mid * d) {
        global_msg = f + "最大值(" + max + ")与最小值(" + min + ")其中一个值与中间值(" + mid + ")之差超过中间值的15%(" + mid * d + ")，取中间值为结果！";
        ret = mid;
    }

    return GetDataOddIncreaseEvenDecrease(ret, e);
}
//******************************************函数9**********************************************
//**************************************计算以10为底的对数**************************************
//说明：Math.log(x)计算logeX的值，Math.LN10就是常数loge10
//log10X=log10e*logeX
function lg(x) {
    return Math.LOG10E * Math.log(x);
}
function ex(x) {
    return Math.pow(10, x)
}

function FormatNumber(srcStr, nAfterDot) {
    var srcStr, nAfterDot;
    var resultStr, nTen;
    srcStr = "" + srcStr + "";
    strLen = srcStr.length;
    dotPos = srcStr.indexOf(".", 0);
    if (dotPos == -1) {
        resultStr = srcStr + ".";
        for (i = 0; i < nAfterDot; i++) {
            resultStr = resultStr + "0";
        }
        return resultStr;
    }
    else {
        if ((strLen - dotPos - 1) >= nAfterDot) {
            nAfter = dotPos + nAfterDot + 1;
            nTen = 1;
            for (j = 0; j < nAfterDot; j++) {
                nTen = nTen * 10;
            }
            resultStr = Math.round(parseFloat(srcStr) * nTen) / nTen;
            return resultStr;
        }
        else {
            resultStr = srcStr;
            for (i = 0; i < (nAfterDot - strLen + dotPos + 1) ; i++) {
                resultStr = resultStr + "0";
            }
            return resultStr;
        }
    }
}

//**********************************************函数10*****************************************************************
//*********************************计算标准差******************************************************************
//公式    ——————————————————————————————————————
////s=   /          2                  
////   |/    E(xi-x)/(N-1)
//E表示求和
// 增加可传入数组的功能，同时所传参数类型不为数字型，该参数不参与计算。1,1,1,,2
function GetS() {
    if (typeof (arguments[0]) == "object") {
        arguments = arguments[0];
    }
    var total = 0;//表示求和
    var len = arguments.length;//数组长度
    var x = 0;//平均值
    var s1 = 0;//求平方和
    var s;//标准差
    for (i = 0; i < len; i++) {
        //		if(isNaN(arguments[i])){
        //			len-=1;
        //			arguments =arguments.splice(i,1);
        //			continue;
        //		}
        total = total + arguments[i] * 1;
    }
    x = total / len;


    for (j = 0; j < len; j++) {
        s1 = s1 + (arguments[j] - x) * (arguments[j] - x);
    }
    s = Math.sqrt(s1 / (len - 1));
    if (!s)
        s = "";
    return s;
}

//*********************************计算变异系数Cv******************************************************************
/////////////////////////增加可传入数组的功能，同时所传参数类型不为数字型，该参数不参与计算。
//公式    ——————————————————————————————————————
////s=   /          2                  
////   |/    E(xi-x)/(N-1)
//E表示求和
// Cv=s*100/x平均
function GetCv() {
    if (typeof (arguments[0]) == "object") {
        arguments = arguments[0];
    }

    var total = 0;//表示求和
    var len = arguments.length;//数组长度
    var x = 0;//平均值
    var s1 = 0;//求平方和
    var s;//标准差
    var Cv = 0;

    for (i = 0; i < len; i++) {
        if (isNaN(arguments[i])) {
            len -= 1;
            continue;
        }
        total = total + arguments[i] * 1;
    }
    x = total / len;
    for (j = 0; j < len; j++) {
        s1 = s1 + (arguments[j] - x) * (arguments[j] - x);
    }
    s = Math.sqrt(s1 / (len - 1));
    Cv = s * 100 / x
    if (!Cv)
        Cv = "";
    return Cv;
}

//生成指定范围内的控件的值，以数组方式返回，可以作为其他函数的参数。
AllInput = new Array()
AllInput = document.getElementsByTagName('input');
//AllInput.sort()
function MakeValue(min, max) {
    temp = new String();
    var inputAll = new String()
    inputAll = '';
    var len = 0;
    for (i = 0; i < AllInput.length; i++) {
        temp = AllInput[i].id
        len = (temp.substr(temp.length - 2, 2)) * 1
        if ((len >= min) && (len <= max) && (temp.substr(temp.length - 4, 2) == 'yu')) {
            if (AllInput[i].value == '/')
                AllInput[i].value = '0.0'
            inputAll += AllInput[i].value + ','
        }
    };
    if (inputAll.substr(inputAll.length - 1, 1) == ',')
        inputAll = inputAll.substr(0, inputAll.length - 1)
    oo = inputAll.split(',')
    return oo
}
//求和，与求平均值的使用方式相同。
function SumAll() {
    var fltall = 0;
    var len = arguments.length;
    if (typeof (arguments[0]) == 'object') //数组方式
    {
        //arrayObj = new Array()
        //arrayObj=arguments[0];
        for (i = 0; i < arguments[0].length; i++) {
            fltall = fltall * 1
            arguments[0][i] = arguments[0][i] * 1
            if (!isNaN(arguments[0][i])) {
                fltall = fltall * 1 + arguments[0][i]
            }
        }
        if (fltall != 'NaN') {
            return fltall
        }
        else
            return ''
    }
    else                          //直接传值方式。
    {
        for (i = 0; i < len; i++) {
            if (!isNaN(arguments[i] * 1))
                fltall = fltall * 1 + arguments[i] * 1;
        }
        return fltall
    }
}
//用于判断传入的值是数字的个数.并不常用,仍然支持数组和直接传值两种方式.
function getIsNumCtl() {
    var len = arguments.length;
    var m = 0;                             //保存不是数字的参数个数。
    if (typeof (arguments[0]) == 'object')  //传入是数组
    {
        arrayObj = new Array()
        arrayObj = arguments[0];
        for (i = 0; i < arrayObj.length; i++) {
            arrayObj[i] = arrayObj[i] * 1
            if (!isNaN(arrayObj[i] * 1)) {
                m = m + 1;
            }
        }
        return m
    }
    else                                 //直接传值。
    {
        for (i = 0; i < len; i++) {
            if (!isNaN(arguments[i] * 1)) {
                m = m + 1;
            }
        }
        return m;
    }

}

//=======================================================================
//创建一个计算类
function math() {
    this.Sum = Sum;
    //this.MakeValue = MakeValue(min,max);


}
math.prototype.length = 9; //设置返回的值的最大长度
math.prototype.isOddIncrease = true; //是否需要奇进偶舍

function Sum() { //计算和
    var total = 0;//表示求和
    var len = arguments.length;//数组长度for(i=0;i<len;i++)
    for (i = 0; i < len; i++) {
        total = total + arguments[i];
    }
    return total
}
var m = new math();

//12.GetNum(str)
//针对２种类型"φ100×200"和"150×150×150"，当为１时，返回π＊d*d/4;当为２时，返回计算结果前２个数150*150
function GetNum(str) {
    var result;
    var r;
    var reg = /[×φ*]/g;
    try {
        r = str.split(reg);
        var x;
        if (str.substring(0, 1) == "φ") {
            x = r[1] - 0;
            result = (Math.PI * x * x) / 4;
        }
        else {
            result = r[0] - 0;
            x = r[1] - 0;
            result = result * x;

        }
    }
    catch (e) {
        return 0;
    }
    return result;
}
//13  GetDay(date1,date2)
//返回两个日期相差的天数2002-03-04
function GetDay(date1, date2) {
    var d1 = new Date();
    var d2 = new Date();
    var dt_array1 = new Array();
    var dt_array2 = new Array();
    dt_array1 = date1.split("-");
    dt_array2 = date2.split("-");
    d1.setFullYear(dt_array1[0], dt_array1[1] - 1, dt_array1[2]);
    d2.setFullYear(dt_array2[0], dt_array2[1] - 1, dt_array2[2]);
    var x;
    x = (d2 - d1) / (1000 * 60 * 60 * 24);

    if (!(x >= 0))
        global_msg = "该试验日期输入不合法[形如：2004-01-01，0000-00-00]";
    return x;
}

///15////////////////////高斯列主元消去法求解线性方程组///////////
///////////////////////返回数组解////////////////////////////////////////////////
function Gauss(x, y) {
    var xs = new Array();
    ///////////////变量区域////////////i表示行，k表示列
    var i, j, k, tmp, ik, n, mik;
    n = x.length;
    ///*********************消元***********************//////
    for (k = 0; k < n; k++) {
        /////////////选列主元////////////////////
        mik = -1;
        for (i = k; i < n; i++) {
            if (Math.abs(x[i][k] * 1) > mik) {
                mik = Math.abs(x[i][k] * 1);
                ik = i;               ///当前列系数最大的行
            }
        }

        for (j = k; j < n; j++) {
            tmp = x[ik][j];
            x[ik][j] = x[k][j];
            x[k][j] = tmp;
        }
        tmp = y[k]; y[k] = y[ik]; y[ik] = tmp;        ///////////把当前行数据和最大列的系数对换
        ///////////////////////消元//////////////////////
        y[k] = y[k] * 1 / (x[k][k] * 1);
        for (i = n - 1; i >= k; i--) {
            x[k][i] = (x[k][i] / x[k][k]);
        }

        for (i = k + 1; i < n; i++) {
            y[i] = y[i] - x[i][k] * y[k];
            for (j = n - 1; j >= k; j--) {
                x[i][j] = x[i][j] - x[i][k] * x[k][j];
            }
        }
    }

    ///********************回代******************************///////////////////
    var s = 0;
    xs[n - 1] = y[n - 1];
    for (i = n - 2; i >= 0; i--) {
        s = y[i];
        for (j = i + 1; j < n; j++) {
            s = s - xs[j] * x[i][j];
        }
        xs[i] = s;
    }
    return xs;

}
/*16....牛顿迭代求多项式的最大值*/
////////////////////////////////////////////
function Newton(xs, min, max, step) {
    var n = xs.length;
    var s = 0;
    var tmp = 1;
    var y;
    var x;
    for (i = min; i + step < max; i = i + step) {
        ////////////////求多次方///////////////////
        for (j = 0; j < n; j++) {
            //for(k=j;k<n-1;k++){
            //	tmp=tmp*i;
            //}
            tmp = Math.pow(i, n - 1 - j)
            s = s + tmp * xs[j];
            tmp = 1;
        }
        if (i == min) {
            x = i;
            y = s;
            s = 0;
            continue;
        }

        if (s > y) {
            x = i;
            y = s;
        }

        //if(s<=y){
        //	break;
        //}
        s = 0;
    }
    return x + ";" + y;
}
///////////////////求过线段的点////////////////////////////////////
/////////-------------------参数array_x,array_y，为坐标点数组，X，Y，；Y为所求的坐标点Y，返回Y对应的X	
function CallXY(array_x, array_y, y) {
    var len = array_x.length;
    var x;
    var point1, point2;
    var min = -1;//-----------比Y小的最小数
    var max = -1;//------------比Y大的最小数
    var max_tmp;//----------存储第二大或者第二小的数字
    var point_i;
    if (len < 2)
        return x = "";
    for (i = 0; i < len; i++) {
        //////////----------求最小大点----------------
        if (array_y[i] * 1 >= y) {
            if (max == -1) {
                max = array_y[i] * 1 - y;
                point2 = i;
            }
            if (max > (array_y[i] * 1 - y)) {
                max = array_y[i] * 1 - y;
                point2 = i;
            }
        }
            /////////--------求最小小点------------------
        else {
            if (min == -1) {
                min = y - array_y[i] * 1;
                point1 = i
            }
            if (min > (array_y[i] * 1 - y)) {
                min = y - array_y[i] * 1;
                point1 = i;
            }
        }
    }
    if (!(point1 >= 0 && point2 >= 0)) {
        //------------大值部分-------------
        if (point2 >= 0) {
            point1 = point2;
            max = 0;
            for (i = 0; i < len; i++) {
                if (max == 0) {
                    max = array_y[i] * 1 - array_y[point1];
                    point2 = i;
                }
                if (max > (array_y[i] * 1 - array_y[point1]) && (array_y[i] * 1 - array_y[point1]) > 0) {
                    max = array_y[i] * 1 - array_y[point1];
                    point2 = i;
                }
            }

        }
        else {
            point2 = point1;
            min = 0;
            for (i = 0; i < len; i++) {
                if (min == 0) {
                    min = array_y[point2] * 1 - array_y[i] * 1;
                    point1 = i;
                }
                if (min > (array_y[point2] * 1 - array_y[i] * 1) && (array_y[point2] * 1 - array_y[i] * 1) > 0) {
                    min = array_y[point2] * 1 - array_y[i] * 1;
                    point1 = i;
                }
            }
        }
        //return x="";
    }
    //global_msg="第一个点"+point1+"第二个点"+point2;
    ////////-------------------------求出两个线段点后连线-------------------///
    x = array_x[point1] - (array_y[point1] - y) * (array_x[point2] - array_x[point1]) / (array_y[point2] - array_y[point1]);
    return x;

}
///--------------------18 ChangeToNo(str_)  //将字符串转换成数字
function ChangeToNo(str_) {
    if (str_ == "" || str == "/")
        return 0;
    if (str_ * 1 >= 0)
        return str_ * 1;
    else
        return 0;
}
//------------------END----------------------------------------------------
//-------------19 GetHpValue(wl)//土工和矿粉试验依据[砂类土][细粒土]------------------
function GetHpValue(wl, type) {
    wl = wl * 1;
    var hp
    if (type == 0)
        hp = 29.6 - 1.22 * wl + 0.017 * wl * wl - 0.0000744 * wl * wl * wl;
    else
        hp = wl / (0.524 * wl - 7.606);
    return hp;
}
//--------------------------20 GetTwoKeep(f_value,i_keep)-------------------
function GetTwoKeep(f_value, i_keep) {
    if (i_keep == 2) {
        if (f_value * 1 >= 100)
            return f_value;
        if (f_value * 1 >= 10)
            return GetDataOddIncreaseEvenDecrease(f_value * 1, 1);
        if (f_value * 1 >= 1)
            return GetDataOddIncreaseEvenDecrease(f_value * 1, -1);
        else
            return "";
    }
}
//////-------------------END-------------------------------	
//------------------21 末位修略到偶数-------------------------------
function GetEvenRule(f_value, i_keep) {
    var tmp_x;
    var i_end;
    f_value = f_value * 1 + 0.0000000001;
    //alert(f_value);
    f_value = f_value + "";
    global_msg += f_value + "|" + tmp_x + "|" + i_end;
    //------------有小数点的情况------------
    if (f_value.search(/\./) > -1) {
        switch (i_keep) {
            case 0:
                i_end = f_value.substring(f_value.search(/\./) - 1, f_value.search(/\./))
                tmp_x = f_value.substring(0, f_value.search(/\./) - 1)
                break;
            case 1:
                i_end = f_value.substring(f_value.search(/\./) + 1, f_value.search(/\./) + 2)
                tmp_x = f_value.substring(0, f_value.search(/\./) + 1)
                break;
            case 2:
                i_end = f_value.substring(f_value.search(/\./) + 2, f_value.search(/\./) + 3)
                tmp_x = f_value.substring(0, f_value.search(/\./) + 2)
                break;
        }
        i_end = i_end * 1;
        if (i_end == 1)
            i_end = 0;
        if (i_end == 3)
            i_end = 2;
        if (i_end == 5)
            i_end = 6;
        if (i_end == 7)
            i_end = 8;
        //var x=new Number();
        //x.toFixed 
        if (i_end == 9) {
            tmp_x = tmp_x * 1;
            switch (i_keep) {
                case 0: tmp_x = tmp_x * 1 + 10; break;
                case 1: tmp_x = (tmp_x) * 1 + 1.0; tmp_x = tmp_x.toFixed(1); break;
                case 2: tmp_x = tmp_x * 1 + 0.10; tmp_x = tmp_x.toFixed(2); break;

            }
            return tmp_x;
            i_end = 0;
        }
        tmp_x = tmp_x + "" + i_end;
        return tmp_x;
    }
    else {
        return "";
    }
}
//------------------------------------------------------END----------------------------------------
//--------------------22 GetSimulate_Line(arrayofx,arrayofy)//array_xy,数组（X，Y）//返回Y=A*X+B的系数----------
function GetSimulate_Line(arrayofx, arrayofy) {
    var len = arrayofy.length;
    if (len < 2)
        return "";
    var S_xx = 0, S_x = 0, S_xy = 0, S_y = 0, S_yy = 0, avg_x = 0, avg_y = 0;
    var xy_a = new Number();
    var xy_b = new Number();
    var xy_r = new Number();
    var tmp_x, tmp_y;
    var n = 0;
    //---------------------求X，Y的平房和，和的平房--------
    for (i = 0; i < len; i++) {
        tmp_x = arrayofx[i];
        tmp_y = arrayofy[i];
        if (!(tmp_x * 1 >= 0 && tmp_y * 1 >= 0))
            continue;
        S_xx = S_xx + tmp_x * tmp_x;
        S_x = S_x + tmp_x * 1;
        S_xy = S_xy + tmp_x * tmp_y;
        S_y = S_y + tmp_y * 1;
        S_yy = S_yy + tmp_y * tmp_y;
        //S_xy=tmp_x*tmp_y;
        n++;
    }
    //------------求平均值x,y
    avg_x = S_x / n;
    avg_y = S_y / n;
    //---------------
    if (n < 2)
        return "";
    var SXX = S_xx - S_x * S_x / n;
    var SYY = S_yy - S_y * S_y / n;
    var SXY = S_xy - S_x * S_y / n;
    xy_b = SXY / SXX;
    xy_a = avg_y - xy_b * avg_x;
    xy_r = SXY / (Math.sqrt(SXX * SYY));
    xy_a = xy_a.toFixed(4);
    xy_b = xy_b.toFixed(4);
    xy_r = xy_r.toFixed(6);
    return "Y=" + xy_b + "X+ " + xy_a + "（R=" + xy_r + "）";

}
function IsBlank(Fvalue) {
    if (Fvalue.length == 0) {
        return true;
    }
    else {
        return false;
    }
}
//精确到多少
function DataFiveRule(in_value, keepdigit) {
    if (isNaN(in_value)) {
        return "/";
    }
    else {
        return Math.round(in_value / keepdigit, 1) * keepdigit
    }
}
//直线内插法 已知y求x
function InterpolationMethod(x1, x2, y1, y2, y) {
    tmp = (y - y1) * (x2 - x1) / (y2 - y1) + x1 * 1;
    if (isNaN(tmp)) {
        return "/"
    }
    else {
        return tmp
    }
}
//直线内插法 已知x求y
function InterpolationMethod_y(x1, x2, y1, y2, x) {
    tmp = (x - x1) * (y1 - y2) / (x1 - x2) + y1 * 1;
    if (isNaN(tmp)) {
        return "/"
    }
    else {
        return tmp
    }
}
//相对偏差
function xdpc(ob1, ob2) {
    if ((isNaN(ob1)) && (isNaN(ob2))) {
        return (ob1 - ob2) / ob1
    }
    else {
        return "/";
    }
}
//得到小数位数
function GetXS(val) {
    var valindex = val.indexOf(".");//得到小数点所在的索引
    if (valindex == -1) {
        return -1;
    }
    else {
        return val.substring(valindex * 1 + 1, val.length).length;
    }
}
//保留三位有效数跟保留三位数不一样
function GetNEffective(in_value, i_keep) {
    if (in_value >= 0.0001 && in_value < 0.001) {
        return GetDataOddIncreaseEvenDecrease(in_value, -6);
    }
    else if (in_value >= 0.001 && in_value < 0.01) {
        return GetDataOddIncreaseEvenDecrease(in_value, -5);
    }
    else if (in_value >= 0.01 && in_value < 0.1) {
        return GetDataOddIncreaseEvenDecrease(in_value, -4);
    }
    else if (in_value >= 0.1 && in_value < 1) {
        return GetDataOddIncreaseEvenDecrease(in_value, -3);//0.3
    }
    else if (in_value >= 1 && in_value < 10) {
        return GetDataOddIncreaseEvenDecrease(in_value, -2);//3
    }
    else if (in_value >= 10 && in_value < 100) {
        return GetDataOddIncreaseEvenDecrease(in_value, -1);//30
    }
    else if (in_value >= 100 && in_value < 1000) {
        return GetDataOddIncreaseEvenDecrease(in_value, 1);//300
    }
}
//技术要求，试验结果，结果判定
function Resultsettings(jsyq, k1, k2) {
    $.getJSON(window.location.href + '&action=viewjsyq', function (data) {
        var s = "", ct = "";
        for (var i = 0; i < data.length; i++) {
            s = data[i].控件值 == "" ? "/" : data[i].控件值;

            ct = data[i].控件ID;
            $("#" + ct + "").val(s);

        }
        var r_jsyq, r_k1, r_k2;
        r_jsyq = $("#" + jsyq + "").val();
        r_k1 = $("#" + k1 + "").val();

        if (r_k1 == "/" || r_jsyq == "/") {
            r_k2 = "/";
        }
        else {
            r_k1 = r_k1 * 1;
            if (r_jsyq.indexOf("<") != -1 || r_jsyq.indexOf(">") != -1 || r_jsyq.indexOf("＜") != -1 || r_jsyq.indexOf("＞") != -1) {
                r_jsyq = r_jsyq.replace("＜", "<");
                r_jsyq = r_jsyq.replace("＞", ">");
                r_k2 = eval(r_k1 + r_jsyq) ? "合格" : "不合格";
            }
            else if (r_jsyq.indexOf("≥") != -1 || r_jsyq.indexOf("不小于") != -1 || r_jsyq.indexOf("≮") != -1) {
                var num = r_jsyq.replace("≥", "").replace("不小于", "").replace("≮", "") * 1;

                if (r_k1 > num || r_k1 == num) {
                    r_k2 = "合格";
                }
                else {
                    r_k2 = "不合格";
                }
            }
            else if (r_jsyq.indexOf("≤") != -1 || r_jsyq.indexOf("不大于") != -1 || r_jsyq.indexOf("≯") != -1) {
                var num = r_jsyq.replace("≤", "").replace("不大于", "").replace("≯", "") * 1;

                if (r_k1 < num || r_k1 == num) {
                    r_k2 = "合格";
                }
                else {
                    r_k2 = "不合格";
                }
            }
            else if (r_jsyq.indexOf("≠") != -1) {
                var num = r_jsyq.replace("≠", "") * 1;
                if (r_k1 != num) {
                    r_k2 = "合格";
                }
                else {
                    r_k2 = "不合格";
                }
            }
            else if (r_jsyq.indexOf("~") != -1 || r_jsyq.indexOf("-") != -1 || r_jsyq.indexOf("～") != -1) {
                var r1;
                var r2;
                if (r_jsyq.indexOf("~") != -1) {
                    r1 = r_jsyq.split("~")[0];
                    r2 = r_jsyq.split("~")[1];
                }
                else if (r_jsyq.indexOf("-") != -1) {
                    r1 = r_jsyq.split("-")[0];
                    r2 = r_jsyq.split("-")[1];
                }
                else if (r_jsyq.indexOf("～") != -1) {
                    r1 = r_jsyq.split("～")[0];
                    r2 = r_jsyq.split("～")[1];
                }
                if (r_k1 * 1 >= r1 * 1 && r_k1 <= r2 * 1) {
                    r_k2 = "合格";
                }
                else {
                    r_k2 = "不合格";
                }
            }
            else {
                if (r_k1 == r_jsyq * 1) {
                    r_k2 = "合格";
                }
                else {
                    r_k2 + "不合格";
                }
            }
        }
        $("#" + k2 + "").val(r_k2);

    });
}
///计算ta/n,用于评定
//n代表检测点数,bzn代表保证率
function tan(n, bzn) {

    var arr = new Array();
    var res1 = 0;
    if (n > 100) {
        if (bzn == "99") {
            res1 = GetDataOddIncreaseEvenDecrease(2.3265 / Math.sqrt(n), -3);
        }
        else if (bzn == "95") {
            res1 = GetDataOddIncreaseEvenDecrease(1.6449 / Math.sqrt(n), -3);
        }
        else if (bzn == "90") {
            res1 = GetDataOddIncreaseEvenDecrease(1.2815 / Math.sqrt(n), -3);
        }
    }
    else {
        if (bzn == "99") {
            arr = new Array("2-22.501", "3-4.021", "4-2.270", "5-1.676", "6-1.374", "7-1.188", "8-1.060", "9-0.966", "10-0.892", "11-0.833", "12-0.785", "13-0.744", "14-0.708", "15-0.678", "16-0.651", "17-0.626", "18-0.605", "19-0.586", "20-0.568", "21-0.552", "22-0.537", "23-0.523", "24-0.510", "25-0.498", "26-0.487", "27-0.477", "28-0.467", "29-0.458", "30-0.449", "40-0.383", "50-0.340", "60-0.308", "70-0.285", "80-0.266", "90-0.249", "100-0.236");
        }
        else if (bzn == "95") {
            arr = new Array("2-4.465", "3-1.686", "4-1.177", "5-0.953", "6-0.823", "7-0.734", "8-0.670", "9-0.620", "10-0.580", "11-0.546", "12-0.518", "13-0.494", "14-0.473", "15-0.455", "16-0.438", "17-0.423", "18-0.410", "19-0.398", "20-0.387", "21-0.376", "22-0.367", "23-0.358", "24-0.350", "25-0.342", "26-0.335", "27-0.328", "28-0.322", "29-0.316", "30-0.310", "40-0.266", "50-0.237", "60-0.216", "70-0.199", "80-0.186", "90-0.175", "100-0.166");
        }
        else if (bzn == "90") {
            arr = new Array("2-2.176", "3-1.089", "4-0.819", "5-0.686", "6-0.603", "7-0.544", "8-0.500", "9-0.466", "10-0.437", "11-0.414", "12-0.393", "13-0.376", "14-0.361", "15-0.347", "16-0.335", "17-0.324", "18-0.314", "19-0.305", "20-0.297", "21-0.289", "22-0.282", "23-0.275", "24-0.269", "25-0.264", "26-0.258", "27-0.253", "28-0.248", "29-0.244", "30-0.239", "40-0.206", "50-0.184", "60-0.167", "70-0.155", "80-0.145", "90-0.136", "100-0.129");
        }

        for (var i = 0; i < arr.length; i++) {
            var a = arr[i].split("-");

            if (a[0] == n) {
                res1 = a[1];
            }

        }

    }

    return res1;
}
//拌制方法
function jbfs_click() {
    var combox = new Combox();
    combox.add('机械拌合');
    combox.add('人工拌合');
    combox.add('机械+人工拌合');
    combox.show();
}
//保水性
function bsx_click() {
    var combox = new Combox();
    combox.add('多量');
    combox.add('少量');
    combox.add('无');
    combox.show();
}
//粘聚性
function njx_click() {
    var combox = new Combox();
    combox.add('良好');
    combox.add('不好');
    combox.show();
}
//养护条件
function yhtj_click() {
    var combox = new Combox();
    combox.add('自然养护');
    combox.add('标准养护');
    combox.show();
}
//棍度
function gd_click() {
    var combox = new Combox();
    combox.add('上');
    combox.add('中');
    combox.add('下');
    combox.show();
}
//含砂情况
function hsqk_click() {
    var combox = new Combox();
    combox.add('多');
    combox.add('中');
    combox.add('少');
    combox.show();
}

function IsNumber(in_value) {
    var ret = true;
    var reg = /^-?\d+\.?\d*$/;   //判断字符串是否为数字     
    if (!reg.test(in_value)) {
        ret = false
    }
    return ret;
}
//土的含水率的超差提示
//ret-试验结果
//v1-含水率1,v2-含水率2
function hslcc(ret, v1, v2) {
    if (!isNaN(ret) && ret != "/") {
        if (ret * 1 <= 5 && Math.abs(v1 * 1 - v2 * 1) != 0.3) {
            global_msg = "当含水率5以下时，允许的平行差为0.3";
        }
        else if (ret * 1 > 5 && ret * 1 <= 40 && Math.abs(v1 * 1 - v2 * 1) > 1) {
            global_msg = "当含水率为40以下时，允许的平行差为≤1";
        }
        else if (ret > 40 && Math.abs(v1 * 1 - v2 * 1) > 2) {
            global_msg = "当含水率为40以上时，允许的平行差为≤2";
        }
    }
}
//无机结合料的含水率的超差提示
//ret-试验结果
//v1-含水率1,v2-含水率2
function wjhslcc(ret, v1, v2) {
    if (!isNaN(ret) && ret != "/") {
        if (ret * 1 <= 7 && Math.abs(v1 * 1 - v2 * 1) > 0.5) {
            global_msg = "当含水率7以下时，允许的平行差为≤0.5";
        }
        else if (ret * 1 > 7 && ret * 1 <= 40 && Math.abs(v1 * 1 - v2 * 1) > 1) {
            global_msg = "当含水率为40以下时，允许的平行差为≤1";
        }
        else if (ret > 40 && Math.abs(v1 * 1 - v2 * 1) > 2) {
            global_msg = "当含水率为40以上时，允许的平行差为≤2";
        }
    }
}