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
using YSBF.Entity;

namespace YSFB.Data.Repository
{
    /// <summary>
    /// 业务层实际调用的仓储
    /// </summary>
    /// <typeparam name="T">模型</typeparam>
    /// <typeparam name="S">主键</typeparam>
	public class Repository<T,S> where T : BaseEntity<S> where S:struct
	{
		private IDataBase<T,S> _db;
		public Repository(IDataBase<T,S> dataBase)
		{
			this._db = dataBase;
        }

        #region CURD
        public async Task<int> Insert(T entity)
        {
            return await _db.Insert(entity);
        }
        public async Task<int> Insert(IEnumerable<T> entitys)
        {
            return await _db.Insert(entitys);
        }

        public async Task<int> Update(T entity)
        {
            return await _db.Update(entity);

        }
        public async Task<int> Update(IEnumerable<T> entitys)
        {
            return await _db.Update(entitys);

        }

        public async Task<int> Delete(S Id)
        {
            var entity = await FindById(Id);
            if(entity == null)
            {
                return 0;
            }
            entity.IsDelete = true;
            return await Update(entity);

        }
        public async Task<int> Delete(IEnumerable<S> Ids)
        {
            var entitys = await FindByIds(Ids);
            if (!entitys.AsSelect().Any())
            {
                return 0;
            }
            foreach (var entity in entitys)
            {
                entity.IsDelete = true;
            }
            return await Update(entitys);
        }
        public async Task<int> Delete(Expression<Func<T, bool>> condition)
        {
            var entitys =await FindList(condition);
            if (!entitys.AsSelect().Any())
            {
                return 0;
            }
            foreach (var entity in entitys)
            {
                entity.IsDelete = true;
            }
            return await Update(entitys);
        }

        public async Task<T> FindById(S Id)
        {
            return await _db.FindById(Id);
        }
        public async Task<IEnumerable<T>> FindByIds(IEnumerable<S> Ids)
        {
            return await _db.FindByIds(Ids);
        }
        public async Task<IEnumerable<T>> FindList(Expression<Func<T, bool>> condition)
        {
            return await _db.FindList(condition);
        }
        #endregion


    }
}

