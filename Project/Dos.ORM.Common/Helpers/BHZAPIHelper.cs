using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Dos.ORM.Common.Helpers
{
    public static class BHZAPIHelper
    {
        
        private static string _url;
        static BHZAPIHelper()
        {
            //_url = WebConfigurationManager.AppSettings["BhzApiUrl"].ToString();
        }

        #region 拌合站系统


        //拌合站/机列表-下拉
        public static string GetBhzBhjAPI
        {
            get
            {
                return  "/cdkx/api/bhz/get/bhzjlist";
            }
        }


        //获取强度等级
        public static string GetBhzQddjAPI
        {
            get
            {
                return  "/cdkx/api/bhz/get/qddjlist";
            }
        }

        //获取列设置
        public static string GetTabColByAPI
        {
            get
            {
                return  "/cdkx/api/bhz/get/tabcol";
            }
        }

        //保存列设置
        public static string GetTabColSaveAPI
        {
            get
            {
                return  "/cdkx/api/bhz/save/tabcol";
            }
        }


        //生产任务-用量偏差
        public static string GetBhzZbAPI
        {
            get
            {
                return  "/cdkx/api/bhz/get/zblist";
            }
        }


        //生产任务-用量偏差-明细表列 
        public static string GetBhzMxAPI
        {
            get
            {
                return  "/cdkx/api/bhz/get/mxlist";
            }
        }


        //生产任务-实际用量
        public static string GetBhzFlAPI
        {
            get
            {
                return  "/cdkx/api/bhz/get/fllist";
            }
        }


        //动态监控-实时监控
        public static string GetBhzMx1API
        {
            get
            {
                return  "/cdkx/api/bhz/get/mx1list";
            }
        }


        //动态监控-超标记录
        public static string GetBhzMx2API
        {
            get
            {
                return  "/cdkx/api/bhz/get/mx2list";
            }
        }


        //智能监测-拌合机联网状态/拌合机采集状态 
        public static string GetBhjStateAPI
        {
            get
            {
                return  "/cdkx/api/bhz/get/bhjstatelist";
            }
        }


        //智能监测-数据上传异常提醒 
        public static string GetBhjTipAPI
        {
            get
            {
                return  "/cdkx/api/bhz/get/bhjtiplist";
            }
        }


        //数据分析-产能分析  
        public static string GetEchartAnalyze1API
        {
            get
            {
                return  "/cdkx/api/echarts/get/analyze1";
            }
        }


        //数据分析-材料趋势分析  
        public static string GetEchartAnalyze2API
        {
            get
            {
                return  "/cdkx/api/echarts/get/analyze2";
            }
        }


        //统计报表-混凝土产量统计 
        public static string GetBhzRpt1API
        {
            get
            {
                return  "/cdkx/api/bhz/get/rpt1list";
            }
        }


        //统计报表-混凝土超标统计 
        public static string GetBhzRpt2API
        {
            get
            {
                return  "/cdkx/api/bhz/get/rpt2list";
            }
        }


        //统计报表-原材料消耗统计 
        public static string GetBhzRpt3API
        {
            get
            {
                return  "/cdkx/api/bhz/get/rpt3list";
            }
        }


        //统计报表-混凝土产量统计 
        public static string GetEchartRpt1API
        {
            get
            {
                return  "/cdkx/api/echarts/get/rpt1";
            }
        }


        //统计报表-原材料消耗统计 
        public static string GetEchartRpt3API
        {
            get
            {
                return  "/cdkx/api/echarts/get/rpt3";
            }
        }


        //获取拌合站超标  手机设置 参数设置
        public static string GetBhzSetAPI
        {
            get
            {
                return  "/cdkx/api/bhz/get/set";
            }
        }


        #endregion


        #region 系统设置


        //拌合站设置-列表
        public static string GetBhjListAPI
        {
            get
            {
                return  "/cdkx/api/sys/get/bhjlist";
            }
        }

        //拌合站设置-加载
        public static string GetBhjGetAPI
        {
            get
            {
                return  "/cdkx/api/sys/get/bhjget";
            }
        }

        //拌合站设置-保存
        public static string GetBhjSaveAPI
        {
            get
            {
                return  "/cdkx/api/sys/save/bhjsave";
            }
        }

        //拌合站设置-删除
        public static string GetBhjDelAPI
        {
            get
            {
                return  "/cdkx/api/sys/del/bhjdel";
            }
        }




        //报警参数设置-获取已设置参数的试验室列表
        public static string GetParamSetLabsAPI
        {
            get
            {
                return  "/cdkx/api/sys/get/paramsetlabs";
            }
        }

        //报警参数设置-获取
        public static string GetBhzParamAPI
        {
            get
            {
                return  "/cdkx/api/sys/get/param";
            }
        }

        //报警参数设置-保存
        public static string GetSaveParamAPI
        {
            get
            {
                return  "/cdkx/api/sys/save/param";
            }
        }


        //手机号配置-获取已设置参数1
        public static string GetSmsOneLabsAPI
        {
            get
            {
                return  "/cdkx/api/sys/get/smsonelabs";
            }
        }

        //手机号配置-获取已设置参数2
        public static string GetSmsTwoLabsAPI
        {
            get
            {
                return  "/cdkx/api/sys/get/smstwolabs";
            }
        }

        //手机号配置-获取已设置参数3
        public static string GetSmsThreeLabsAPI
        {
            get
            {
                return  "/cdkx/api/sys/get/smsthreelabs";
            }
        }

        //手机号配置-获取1
        public static string GetBhzSmsOneAPI
        {
            get
            {
                return  "/cdkx/api/sys/get/smsone";
            }
        }

        //手机号配置-获取2
        public static string GetBhzSmsTwoAPI
        {
            get
            {
                return  "/cdkx/api/sys/get/smstwo";
            }
        }

        //手机号配置-获取3
        public static string GetBhzSmsThreeAPI
        {
            get
            {
                return  "/cdkx/api/sys/get/smsthree";
            }
        }

        //手机号配置-保存1
        public static string GetSaveSmsOneAPI
        {
            get
            {
                return  "/cdkx/api/sys/save/smsone";
            }
        }

        //手机号配置-保存2
        public static string GetSaveSmsTwoAPI
        {
            get
            {
                return  "/cdkx/api/sys/save/smstwo";
            }
        }

        //手机号配置-保存3
        public static string GetSaveSmsThreeAPI
        {
            get
            {
                return  "/cdkx/api/sys/save/smsthree";
            }
        }


        //发送短信-列表
        public static string GetSmsRcdListAPI
        {
            get
            {
                return  "/cdkx/api/sys/get/smsrcdlist";
            }
        }


        //用户管理-列表
        public static string GetUserListAPI
        {
            get
            {
                return  "/cdkx/api/sys/get/userlist";
            }
        }

        //用户管理-加载
        public static string GetUserByIdAPI
        {
            get
            {
                return  "/cdkx/api/sys/get/userbyid";
            }
        }

        //用户管理-保存
        public static string GetUserSaveAPI
        {
            get
            {
                return  "/cdkx/api/sys/save/usersave";
            }
        }

        //用户管理-删除
        public static string GetUserDelAPI
        {
            get
            {
                return  "/cdkx/api/sys/del/userdel";
            }
        }



        //角色管理-列表
        public static string GetRoleListAPI
        {
            get
            {
                return  "/cdkx/api/sys/get/rolelist";
            }
        }

        //角色管理-加载
        public static string GetRoleByIdAPI
        {
            get
            {
                return  "/cdkx/api/sys/get/rolebyid";
            }
        }

        //角色管理-保存
        public static string GetRoleSaveAPI
        {
            get
            {
                return  "/cdkx/api/sys/save/rolesave";
            }
        }

        //角色管理-删除
        public static string GetRoleDelAPI
        {
            get
            {
                return  "/cdkx/api/sys/del/roledel";
            }
        }


        //上传异常设置-列表
        public static string GetExceptListAPI
        {
            get
            {
                return  "/cdkx/api/sys/get/exceptlist";
            }
        }

        //上传异常设置-加载
        public static string GetExceptByIdAPI
        {
            get
            {
                return  "/cdkx/api/sys/get/exceptbyid";
            }
        }

        //上传异常设置-保存
        public static string GetExceptSaveAPI
        {
            get
            {
                return  "/cdkx/api/sys/save/exceptsave";
            }
        }


        //项目标段-列表
        public static string GetProLabAPI
        {
            get
            {
                return  "/cdkx/api/sys/get/prolablist";
            }
        }

        //项目标段-加载
        public static string GetProLabGetAPI
        {
            get
            {
                return  "/cdkx/api/sys/get/prolabget";
            }
        }

        //项目标段-保存
        public static string GetProLabSaveAPI
        {
            get
            {
                return  "/cdkx/api/sys/save/prolabsave";
            }
        }

        //项目标段-删除
        public static string GetProLabDelAPI
        {
            get
            {
                return  "/cdkx/api/sys/del/prolabdel";
            }
        }


        #endregion



        #region 动态监控-明细

        public static string GetDyData
        {
            get { return _url + "/cdkx/api/dtl/get/syjzb/"; }
        }

        #endregion
    }


}
