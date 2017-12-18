/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Web.App_Start
 * 类名称：WebApiAuthHandler
 * 创建时间：2016-12-26 14:43:55
 * 创建人：Quber
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Dos.ORM.Common.Enums;
using Dos.ORM.Common.Helpers;
using Dos.ORM.Model.Base;

namespace Dos.ORM.Web
{
    /// <summary>
    /// 
    /// </summary>
    public class WebApiAuthHandler : DelegatingHandler
    {
        /// <summary>
        /// 重写SendAsync，以便返回自定义Json
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var isRight = true;
            var strMsg = "访问成功！";
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.MethodNotAllowed)
            {
                isRight = false;
                strMsg = "对不起，该服务不存在或禁止访问！";

                //TODO...添加日志
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                //类似服务器500错误

                isRight = false;
                strMsg = "访问出错，请稍后再试！";

                //TODO...添加日志
            }

            var retModel = new OperateModel
            {
                Result = isRight ? OperateRetType.Success : OperateRetType.Fail,
                Msg = strMsg,
                Data = isRight ? response.Content : null
            };

            response.Content = new StringContent(JsonHelper.ObjectToJson(retModel));
            return response;
        }

    }
}