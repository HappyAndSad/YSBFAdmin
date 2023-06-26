// ********************************************************
// Repository.cs
// Date: 2023/6/16 22:38
// Author: HappyAndSad 
// Copyright (c) 2023 MIT 
// ********************************************************
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto;
using YSBF.Entity;

namespace YSFB.Data.Repository
{
    /// <summary>
    /// 业务层实际调用的仓储
    /// </summary>
    /// <typeparam name="TEntity">模型</typeparam>
    /// <typeparam name="TKey">主键</typeparam>
	public class Repository<TEntity,TKey> where TEntity : BaseEntity<TKey> where TKey:struct
	{
        /// <summary>
        /// 数据库实现对象
        /// </summary>
		private IDataBase<TEntity,TKey> _db;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataBase"></param>
		public Repository(IDataBase<TEntity,TKey> dataBase)
		{
            this._db = dataBase;
        }

        #region CURD
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task<int> Insert(TEntity entity)
        {
            return await _db.Update(entity);
        }
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="entitys">实体列表</param>
        /// <returns></returns>
        public async Task<int> Insert(IEnumerable<TEntity> entitys)
        {
            return await _db.Update(entitys);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task<int> Update(TEntity entity)
        {
            return await _db.Update(entity);
        }
        /// <summary>
        /// 批量更新数据
        /// </summary>
        /// <param name="entitys">实体列表</param>
        /// <returns></returns>
        public async Task<int> Update(IEnumerable<TEntity> entitys)
        {
            return await _db.Update(entitys);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="Id">主键</param>
        /// <returns></returns>
        public async Task<int> Delete(TKey Id)
        {
            return await _db.Delete(Id);
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="Ids">主键集合</param>
        /// <returns></returns>
        public async Task<int> Delete(IEnumerable<TKey> Ids)
        {
            return await _db.Delete(Ids);
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="condition">lambda表达式</param>
        /// <returns></returns>
        public async Task<int> Delete(Expression<Func<TEntity, bool>> condition)
        {
            return await _db.Delete(condition);
        }

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="Id">主键</param>
        /// <returns></returns>
        public async Task<TEntity> FindById(TKey Id)
        {
            return await _db.FindById(Id);
        }
        /// <summary>
        /// 根据主键查询列表
        /// </summary>
        /// <param name="Ids">主键集合</param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> FindByIds(IEnumerable<TKey> Ids)
        {
            return await _db.FindByIds(Ids);
        }
        /// <summary>
        /// 根据lambda表达式查询列表
        /// </summary>
        /// <param name="condition">lambda表达式</param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> FindList(Expression<Func<TEntity, bool>> condition)
        {
            return await _db.FindList(condition);
        }
        /// <summary>
        /// 分页查询列表数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<(long total, IEnumerable<TEntity>)> FindList(int pageIndex, int pageSize)
        {
            return await _db.FindList(pageIndex, pageSize);
        }
        #endregion


    }
}

