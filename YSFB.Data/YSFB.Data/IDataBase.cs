// ********************************************************
// IDataBase.cs
// Date: 2023/6/16 22:57
// Author: HappyAndSad 
// Copyright (c) 2023 MIT 
// ********************************************************
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FreeSql;
using YSBF.Entity;

namespace YSFB.Data
{
    /// <summary>
    /// 数据层方法基础实现定义
    /// </summary>
    /// <typeparam name="TEntity">实体</typeparam>
    /// <typeparam name="TKey">主键类型</typeparam>
	public interface IDataBase<TEntity,TKey> where TEntity: BaseEntity<TKey> where TKey:struct
    {
        /// <summary>
        /// FreeSql对象
        /// </summary>
		public IFreeSql Orm { get;}
        /// <summary>
        /// 数据库上下文
        /// </summary>
		public DbContext dbcontent { get;}

		#region CURD
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
		Task<int> Insert(TEntity entity);
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="entitys">实体列表</param>
        /// <returns></returns>
        Task<int> Insert(IEnumerable<TEntity> entitys);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task<int> Update(TEntity entity);
        /// <summary>
        /// 批量更新数据
        /// </summary>
        /// <param name="entitys">实体列表</param>
        /// <returns></returns>
        Task<int> Update(IEnumerable<TEntity> entitys);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="Id">主键</param>
        /// <returns></returns>
        Task<int> Delete(TKey Id);
        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="Ids">主键集合</param>
        /// <returns></returns>
        Task<int> Delete(IEnumerable<TKey> Ids);
        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="condition">lambda表达式</param>
        /// <returns></returns>
        Task<int> Delete(Expression<Func<TEntity, bool>> condition);

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="Id">主键</param>
        /// <returns></returns>
        Task<TEntity> FindById(TKey Id);
        /// <summary>
        /// 根据主键查询列表
        /// </summary>
        /// <param name="Ids">主键集合</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> FindByIds(IEnumerable<TKey> Ids);
        /// <summary>
        /// 根据lambda表达式查询列表
        /// </summary>
        /// <param name="condition">lambda表达式</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> FindList(Expression<Func<TEntity, bool>> condition);
        /// <summary>
        /// 分页查询列表数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<(long total,IEnumerable<TEntity>)> FindList(int pageIndex, int pageSize);
        #endregion

    }
}

