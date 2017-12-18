/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Common.Helpers
 * 类名称：DateHelper
 * 创建时间：2016-09-28 11:37:39
 * 创建人：Quber
 * 创建说明：日期时间帮助类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/

using System;
using System.Globalization;

namespace Dos.ORM.Common.Helpers
{
    /// <summary>
    /// 日期时间帮助类
    /// </summary>
    public static class DateHelper
    {
        #region 获取农历日期
        /// <summary>
        /// 针对中国的日历类，公历与中国传统农历纪年之间的相互转换，利用它可以计算天干地支等有关农历的信息
        /// </summary>
        private static readonly ChineseLunisolarCalendar CCalendar = new ChineseLunisolarCalendar();

        /// <summary>
        /// 根据公历获取农历日期
        /// </summary>
        /// <param name="datetime">公历日期</param>
        /// <returns></returns>
        public static string GetNlDate(DateTime datetime)
        {
            int lyear = CCalendar.GetYear(datetime);
            int lmonth = CCalendar.GetMonth(datetime);
            int lday = CCalendar.GetDayOfMonth(datetime);

            //获取闰月， 0 则表示没有闰月
            int leapMonth = CCalendar.GetLeapMonth(lyear);

            bool isleap = false;

            if (leapMonth > 0)
            {
                if (leapMonth == lmonth)
                {
                    //闰月
                    isleap = true;
                    lmonth--;
                }
                else if (lmonth > leapMonth)
                {
                    lmonth--;
                }
            }

            return string.Concat(GetLunisolarYear(lyear), "年", isleap ? "闰" : string.Empty, GetLunisolarMonth(lmonth), "月", GetLunisolarDay(lday));
        }

        #region 农历年
        /// <summary>
        /// 十天干
        /// </summary>
        private static readonly string[] Tiangan = { "甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸" };

        /// <summary>
        /// 十二地支
        /// </summary>
        private static readonly string[] Dizhi = { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };

        /// <summary>
        /// 十二生肖
        /// </summary>
        private static readonly string[] Shengxiao = { "鼠", "牛", "虎", "免", "龙", "蛇", "马", "羊", "猴", "鸡", "狗", "猪" };

        /// <summary>
        /// 返回农历天干地支年 
        /// </summary>
        /// <param name="year">农历年</param>
        /// <returns></returns>
        public static string GetLunisolarYear(int year)
        {
            if (year > 3)
            {
                int tgIndex = (year - 4) % 10;
                int dzIndex = (year - 4) % 12;

                return string.Concat(Tiangan[tgIndex], Dizhi[dzIndex], "[", Shengxiao[dzIndex], "]");
            }

            throw new ArgumentOutOfRangeException("无效的年份!");
        }
        #endregion

        #region 农历月
        /// <summary>
        /// 农历月
        /// </summary>
        private static readonly string[] Months = { "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "十二(腊)" };

        /// <summary>
        /// 返回农历月
        /// </summary>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public static string GetLunisolarMonth(int month)
        {
            if (month < 13 && month > 0)
            {
                return Months[month - 1];
            }

            throw new ArgumentOutOfRangeException("无效的月份!");
        }
        #endregion

        #region 农历日
        /// <summary>
        /// 
        /// </summary>
        private static readonly string[] Days1 = { "初", "十", "廿", "三" };

        /// <summary>
        /// 日
        /// </summary>
        private static readonly string[] Days = { "一", "二", "三", "四", "五", "六", "七", "八", "九", "十" };

        /// <summary>
        /// 返回农历日
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public static string GetLunisolarDay(int day)
        {
            if (day > 0 && day < 32)
            {
                if (day != 20 && day != 30)
                {
                    return string.Concat(Days1[(day - 1) / 10], Days[(day - 1) % 10]);
                }
                else
                {
                    return string.Concat(Days[(day - 1) / 10], Days1[1]);
                }
            }

            throw new ArgumentOutOfRangeException("无效的日!");
        }
        #endregion
        #endregion
    }
}
