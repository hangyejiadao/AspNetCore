using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Dos.ORM.Common.Helpers
{
    public static class SYJAPIHelper
    {  

        private static string _url;
        static SYJAPIHelper()
        {
            //_url = WebConfigurationManager.AppSettings["SyjApiUrl"].ToString();
        }

        #region 基本数据接口

        //获取强度等级
        public static string GetBhzQddjAPI
        {
            get
            {
                return   "/cdkx/api/bhz/get/qddjlist";
            }
        }

        //获取列设置
        public static string GetTabColByAPI
        {
            get
            {
                return   "/cdkx/api/bhz/get/tabcol";
            }
        }

        //保存列设置
        public static string GetTabColSaveAPI
        {
            get
            {
                return   "/cdkx/api/bhz/save/tabcol";
            }
        }

        #endregion


        #region 动态监控

        //获取主表接口
        public static string GetSyjZbAPI
        {
            get
            {
                return   "/cdkx/api/bhz/get/syjzb";
            }
        }

        #endregion


        #region 数据分析


        //混凝土质量波动图  
        public static string GetHNTFx1API
        {
            get
            {
                return   "/cdkx/api/bhz/get/hntfx1_data";
            }
        }


        #endregion


        #region 统计报表


        //统计报表-各试验数量统计
        public static string GetHNTRpt1API
        {
            get
            {
                return   "/cdkx/api/bhz/get/hntrpt1_data";
            }
        }
        public static string GetHNTRpt1EChart
        {
            get
            {
                return   "/cdkx/api/echarts/get/hntrpt1_echart";
            }
        }



        //统计报表-混凝土超标统计
        public static string GetSyjHNT2API
        {
            get
            {
                return   "/cdkx/api/bhz/get/hntrpt2_data";
            }
        }

        public static string GetHNTRpt2EChart
        {
            get
            {
                return   "/cdkx/api/echarts/get/hntrpt2_echart";
            }
        }


        //统计报表-混凝土强度统计
        public static string GetHNTRpt3API
        {
            get
            {
                return   "/cdkx/api/bhz/get/hntrpt3_data";
            }
        }

        public static string GetHNTRpt3EChart
        {
            get
            {
                return   "/cdkx/api/echarts/get/hntrpt3_echart";
            }
        }


        #endregion


        #region 系统设置-短信预警设置

        //短信预警配置-由对象获取人员
        public static string GetSmsEmpByIdAPI
        {
            get
            {
                return   "/cdkx/api/sys/get/smsempbyid";
            }
        }


        //短信预警配置-获取1
        public static string GetSmsOneAPI
        {
            get
            {
                return   "/cdkx/api/sys/get/smsone";
            }
        }
        //短信预警配置-获取2
        public static string GetSmsTwoAPI
        {
            get
            {
                return   "/cdkx/api/sys/get/smstwo";
            }
        }
        //短信预警配置-获取3
        public static string GetSmsThreeAPI
        {
            get
            {
                return   "/cdkx/api/sys/get/smsthree";
            }
        }


        //短信预警配置-保存1
        public static string GetSaveSmsOneAPI
        {
            get
            {
                return   "/cdkx/api/sys/save/smsone";
            }
        }

        //短信预警配置-保存2
        public static string GetSaveSmsTwoAPI
        {
            get
            {
                return   "/cdkx/api/sys/save/smstwo";
            }
        }

        //短信预警配置-保存3
        public static string GetSaveSmsThreeAPI
        {
            get
            {
                return   "/cdkx/api/sys/save/smsthree";
            }
        }

        #endregion


        #region 系统设置-报警参数设置

        //报警参数设置-获取已设置参数的试验室列表
        public static string GetParamLabsAPI
        {
            get
            {
                return   "/cdkx/api/sys/get/paramlabs";
            }
        }

        //报警参数设置-获取
        public static string GetParamByIdAPI
        {
            get
            {
                return   "/cdkx/api/sys/get/parambyid";
            }
        }

        //报警参数设置-保存
        public static string GetSaveParamAPI
        {
            get
            {
                return   "/cdkx/api/sys/save/param";
            }
        }


        #endregion


        #region 系统设置-人员对象设置

        //人员对象设置-列表
        public static string GetEmpListAPI
        {
            get
            {
                return   "/cdkx/api/sys/get/emplist";
            }
        }

        //对象查询列表-列表
        public static string GetObjectListAPI
        {
            get
            {
                return   "/cdkx/api/sys/get/objlist";
            }
        }

        //获取人员信息
        public static string GetEmpByIdAPI
        {
            get
            {
                return   "/cdkx/api/sys/get/empbyid";
            }
        }

        //保存人员信息
        public static string GetSaveEmpAPI
        {
            get
            {
                return   "/cdkx/api/sys/save/emp";
            }
        }

        //保存对象信息
        public static string GetSaveObjAPI
        {
            get
            {
                return   "/cdkx/api/sys/save/obj";
            }
        }

        //人员信息-删除
        public static string GetEmpDelAPI
        {
            get
            {
                return   "/cdkx/api/sys/del/emp";
            }
        }

        //对象信息-删除
        public static string GetObjDelAPI
        {
            get
            {
                return   "/cdkx/api/sys/del/obj";
            }
        }

        #endregion


        #region 系统设置-短信查询

        //发送短信-列表
        public static string GetSmsRcdListAPI
        {
            get
            {
                return   "/cdkx/api/sys/get/smsrcdlist";
            }
        }

        #endregion


        #region 系统设置-用户管理


        //用户管理-列表
        public static string GetUserListAPI
        {
            get
            {
                return   "/cdkx/api/sys/get/userlist";
            }
        }

        //用户管理-加载
        public static string GetUserByIdAPI
        {
            get
            {
                return   "/cdkx/api/sys/get/userbyid";
            }
        }

        //用户管理-保存
        public static string GetUserSaveAPI
        {
            get
            {
                return   "/cdkx/api/sys/save/usersave";
            }
        }

        //用户管理-删除
        public static string GetUserDelAPI
        {
            get
            {
                return   "/cdkx/api/sys/del/userdel";
            }
        }


        #endregion


        #region 系统设置-角色管理


        //角色管理-列表
        public static string GetRoleListAPI
        {
            get
            {
                return   "/cdkx/api/sys/get/rolelist";
            }
        }

        //角色管理-加载
        public static string GetRoleByIdAPI
        {
            get
            {
                return   "/cdkx/api/sys/get/rolebyid";
            }
        }

        //角色管理-保存
        public static string GetRoleSaveAPI
        {
            get
            {
                return   "/cdkx/api/sys/save/rolesave";
            }
        }

        //角色管理-删除
        public static string GetRoleDelAPI
        {
            get
            {
                return   "/cdkx/api/sys/del/roledel";
            }
        }

        #endregion


        #region 系统设置-项目标段


        //项目标段-列表
        public static string GetProLabAPI
        {
            get
            {
                return   "/cdkx/api/sys/get/prolablist";
            }
        }

        //项目标段-加载
        public static string GetProLabGetAPI
        {
            get
            {
                return   "/cdkx/api/sys/get/prolabget";
            }
        }

        //项目标段-保存
        public static string GetProLabSaveAPI
        {
            get
            {
                return   "/cdkx/api/sys/save/prolabsave";
            }
        }

        //项目标段-删除
        public static string GetProLabDelAPI
        {
            get
            {
                return   "/cdkx/api/sys/del/prolabdel";
            }
        }


        #endregion


        #region 动态监控-明细

        public static string GetDyData
        {
            get { return   "/cdkx/api/dtl/get/syjzb/"; }
        }

        #endregion




    }


}
