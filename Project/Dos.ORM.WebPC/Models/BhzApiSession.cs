using Dos.ORM.Common.Helpers;
using Dos.ORM.Model.Base;
using Dos.ORM.WebPC.App_Common.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dos.ORM.WebPC.Models
{
    public class T_BhzApiModel
    {
        public string TargetId { get; set; }

        public string ParentId { get; set; }
       
        public string BhzApi { get; set; }
       
    }

    public class BhzApiSession
    {
        /// <summary>
        /// 存储拌合站接口
        /// </summary>
        public static void Set()
        {
            var LoginUser = LoginUserAuth.Get();
            string url = string.Format(WebAPIHelper.GetBhzAPI + "/{0}", LoginUser.User.ID);
            var OperModel = HttpClientHelper.Get<OperateList<T_BhzApiModel>>(url);
            Set(OperModel.Data);
        }

        /// <summary> 
        /// 存储拌合站接口
        /// </summary>
        /// <param name="msUser">用户相关信息</param>
        public static void Set(List<T_BhzApiModel> model)
        {
            SessionHelper.Set("BHZ_API", model);
        }

        /// <summary>
        /// 获取拌合站接口
        /// </summary>
        /// <returns></returns>
        public static List<T_BhzApiModel> Get()
        {
            if (SessionHelper.Get("BHZ_API") == null)
            {
                Set();
            }

            var list = SessionHelper.Get("BHZ_API") as List<T_BhzApiModel>;
            return list;
        }

        /// <summary>
        /// 获取拌合站接口
        /// </summary>
        /// <param name="TargetId"></param>
        /// <returns></returns>
        public static T_BhzApiModel Get(string TargetId)
        {
            if (SessionHelper.Get("BHZ_API") == null)
            {
                Set();
            }    

            var list = SessionHelper.Get("BHZ_API") as List<T_BhzApiModel>;
            var model = list.SingleOrDefault(s => s.TargetId == TargetId);
            return model;
        }



        /// <summary>
        /// 清除管理员相关信息
        /// </summary>
        public static void Clear()
        {
            if (SessionHelper.Get("BHZ_API") != null)
            {
                SessionHelper.Delete("BHZ_API");
            }
        }
    }
}