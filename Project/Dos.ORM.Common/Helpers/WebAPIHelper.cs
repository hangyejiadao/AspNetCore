using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Dos.ORM.Common.Helpers
{
    public static class WebAPIHelper
    {

        private static string _url;
        static WebAPIHelper()
        {
            _url = WebConfigurationManager.AppSettings["WebApiUrl"].ToString();
        }
        

        #region 基本数据接口

        //修改密码
        public static string EditPwdAPI
        {
            get
            {
                return _url + "/cdkx/api/user/editpwd";
            }
        }

        //登录API
        public static string CheckLoginAPI
        {
            get
            {
                return _url + "/cdkx/api/user/login";
            }
        }

        //获取菜单API
        public static string GetSuperMenuAPI
        {
            get
            {
                return _url + "/cdkx/api/module/get/supermenus";
            }
        }

        //获取项目菜单
        public static string GetUserLabAPI
        {
            get
            {
                return _url + "/cdkx/api/module/get/userlab";
            }
        }

        //获取项目和模块
        public static string GetLabModuleAPI
        {
            get
            {
                return _url + "/cdkx/api/module/get/labmodule";
            }
        }

        #endregion


        #region 工地试验室信息管理系统

        //获取人员
        public static string GetTesterAPI
        {
            get
            {
                return _url + "/cdkx/api/tester/get/list1";
            }
        }

        //获取实验室信息
        public static string GetLabAPI
        {
            get
            {
                return _url + "/cdkx/api/lab/get/lab";
            }
        }


        //获取仪器设备
        public static string GetEqumentAPI
        {
            get
            {
                return _url + "/cdkx/api/equ/get/list1";
            }
        }

          //获取仪器设备
        public static string GetEqumentAPI1
        {
            get
            {
                return _url + "/cdkx/api/equ/get/pslist";
            }
        }


        
        
        //获取样品信息
        public static string GetSampleAPI
        {
            get
            {
                return _url + "/cdkx/api/sample/get/list1";
            }
        }

        //获取试验类型
        public static string GetSampleTypeAPI
        {
            get
            {
                return _url + "/cdkx/api/sampletype/get/list1";
            }
        }

        //获取试验类型
        public static string GetStatisticsTypeAPI
        {
            get
            {
                return _url + "/cdkx/api/sampletype/get/typelist";
            }
        }
        
        //获取合格报告信息
        public static string GetReport1API
        {
            get
            {
                return _url + "/cdkx/api/report/get/list1";
            }
        }


        //获取不合格报告信息
        public static string GetReport2API
        {
            get
            {
                return _url + "/cdkx/api/report/get/list2";
            }
        }

        //获取检测报告信息
        public static string GetReport3API
        {
            get
            {
                return _url + "/cdkx/api/report/get/list3";
            }
        }


        //获取环境设施
        public static string GetEquType1API
        {
            get
            {
                return _url + "/cdkx/api/equtype/get/list1";
            }
        }


        //获取环境设施
        public static string GetEquTypeAPI
        {
            get
            {
                return _url + "/cdkx/api/equtype/get/list";
            }
        }

        //获取环境设施
        public static string GetSubCttAPI
        {
            get
            {
                return _url + "/cdkx/api/subctt/get/list1";
            }
        }


        //获取类型年份查询统计报告 X坐标为月份 
        public static string GetRptItemAPI
        {
            get
            {
                return _url + "/cdkx/api/echarts/get/rptbyitem";
            }
        }



        //获取月份查询统计报告 X坐标为项目
        public static string GetRptMonthAPI
        {
            get
            {
                return _url + "/cdkx/api/echarts/get/rptbymonth";
            }
        }





        #endregion
        

        #region 试验机数据联网监控系统
        
        //访问动态数据库
        public static string GetAccessDbAPI
        {
            get
            {
                return _url + "/cdkx/api/module/get/accessdb";
            }
        }

        #endregion


        #region 拌合站接口


        //根据用户获取项目拌合站接口地址
        public static string GetBhzAPI
        {
            get
            {
                return _url + "/cdkx/api/module/get/bhzapi";
            }
        }

        #endregion


    }
}
