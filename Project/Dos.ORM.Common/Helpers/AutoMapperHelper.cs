/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2016-2088
 * 联系人邮箱：qubernet@163.com
 *****************************************************************************************************
 * 命名空间：Dos.ORM.Common.Helpers
 * 类名称：AutoMapperHelper
 * 创建时间：2016-08-18 16:28:47
 * 创建人：Quber
 * 创建说明：对象映射帮助类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace Dos.ORM.Common.Helpers
{
    /// <summary>
    /// 对象映射帮助类
    /// </summary>
    public static class AutoMapperHelper
    {
        /// <summary>
        /// 注册映射关系（无返回值）
        /// </summary>
        /// <typeparam name="TDtoS">数据实体</typeparam>
        /// <typeparam name="TDto">返回实体</typeparam>
        public static void CreateMapVoid<TDtoS, TDto>()
        {
            Mapper.CreateMap<TDtoS, TDto>();
        }

        /// <summary>
        /// 注册映射关系（有返回值）
        /// </summary>
        /// <typeparam name="TDtoS">数据实体</typeparam>
        /// <typeparam name="TDto">返回实体</typeparam>
        public static IMappingExpression<TDtoS, TDto> CreateMapTo<TDtoS, TDto>()
        {
            return Mapper.CreateMap<TDtoS, TDto>();
        }

        /// <summary>
        /// 将指定实体转换为另一实体
        /// 数据实体类型为class
        /// </summary>
        /// <typeparam name="TDtoS">数据实体</typeparam>
        /// <typeparam name="TDto">返回实体</typeparam>
        /// <param name="model">数据实体源</param>
        /// <returns></returns>
        public static TDto ToModel<TDtoS, TDto>(this TDtoS model)
            where TDto : class,new()
            where TDtoS : class,new()
        {
            return Mapper.Map<TDto>(model);
        }

        /// <summary>
        /// 将指定实体集转换为另一实体集
        /// 数据实体类型为List
        /// </summary>
        /// <typeparam name="TDtoS">数据实体</typeparam>
        /// <typeparam name="TDto">返回实体</typeparam>
        /// <param name="model">数据实体源</param>
        /// <returns></returns>
        public static List<TDto> ToModelList<TDtoS, TDto>(this List<TDtoS> model)
            where TDto : class,new()
            where TDtoS : class, new()
        {
            return Mapper.Map<List<TDtoS>, List<TDto>>(model);
        }

        /// <summary>
        /// 将指定实体集转换为另一实体集
        /// 数据实体类型为ListIQueryable
        /// </summary>
        /// <typeparam name="TDtoS">数据实体</typeparam>
        /// <typeparam name="TDto">返回实体</typeparam>
        /// <param name="model">数据实体源</param>
        /// <returns></returns>
        public static List<TDto> ToModelList<TDtoS, TDto>(this IQueryable<TDtoS> model)
            where TDto : class,new()
            where TDtoS : class, new()
        {
            return Mapper.Map<List<TDtoS>, List<TDto>>(model.ToList());
        }
    }
}
