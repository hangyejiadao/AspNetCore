/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Common.Helpers
 * 类名称：TinyMapperHelper
 * 创建时间：2016-08-18 15:51:13
 * 创建人：Quber
 * 创建说明：对象映射帮助类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using Nelibur.ObjectMapper;
using Nelibur.ObjectMapper.Bindings;

namespace Dos.ORM.Common.Helpers
{
    /// <summary>
    /// 对象映射帮助类
    /// </summary>
    public static class TinyMapperHelper
    {
        /// <summary>
        /// 注册映射关系
        /// </summary>
        /// <typeparam name="TDtoS">数据实体</typeparam>
        /// <typeparam name="TDto">返回实体</typeparam>
        /// <param name="config"></param>
        /*
         * 
            Action<IBindingConfig<WP_WorkRoomInfo, WP_WorkRoomInfoDto>> config = m =>
            {
                m.Ignore(x => x.ID);//忽略ID字段
                m.Bind(x => x.Name, y => y.UserName);//将源类型和目标类型的字段对应绑定起来
                m.Bind(x => x.Age, y => y.Age);//将源类型和目标类型的字段对应绑定起来
            };
         * 
         */
        public static void CreateMap<TDtoS, TDto>(Action<IBindingConfig<TDtoS, TDto>> config = null)
        {
            if (config == null)
                TinyMapper.Bind<TDtoS, TDto>();
            else
                TinyMapper.Bind(config);
        }

        /// <summary>
        /// 将指定实体转换为另一实体
        /// 数据实体类型为class
        /// </summary>
        /// <typeparam name="TDtoS">数据实体</typeparam>
        /// <typeparam name="TDto">返回实体</typeparam>
        /// <param name="model">数据实体源</param>
        /// <returns></returns>
        public static TDto ToModelTiny<TDtoS, TDto>(this TDtoS model)
            where TDto : class,new()
            where TDtoS : class,new()
        {
            return TinyMapper.Map<TDto>(model);
        }

        /// <summary>
        /// 将指定实体集转换为另一实体集
        /// 数据实体类型为List
        /// </summary>
        /// <typeparam name="TDtoS">数据实体</typeparam>
        /// <typeparam name="TDto">返回实体</typeparam>
        /// <param name="model">数据实体源</param>
        /// <returns></returns>
        public static List<TDto> ToModelListTiny<TDtoS, TDto>(this List<TDtoS> model)
            where TDto : class,new()
            where TDtoS : class, new()
        {
            return TinyMapper.Map<List<TDtoS>, List<TDto>>(model);
        }

        /// <summary>
        /// 将指定实体集转换为另一实体集
        /// 数据实体类型为ListIQueryable
        /// </summary>
        /// <typeparam name="TDtoS">数据实体</typeparam>
        /// <typeparam name="TDto">返回实体</typeparam>
        /// <param name="model">数据实体源</param>
        /// <returns></returns>
        public static List<TDto> ToModelListTiny<TDtoS, TDto>(this IQueryable<TDtoS> model)
            where TDto : class,new()
            where TDtoS : class, new()
        {
            return TinyMapper.Map<List<TDtoS>, List<TDto>>(model.ToList());
        }
    }
}
