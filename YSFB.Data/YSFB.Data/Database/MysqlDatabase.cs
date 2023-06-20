// ********************************************************
// MysqlDatabase.cs
// Date: 2023/6/16 22:43
// Author: HappyAndSad 
// Copyright (c) 2023 MIT 
// ********************************************************
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FreeSql;
using YSBF.Entity;

namespace YSFB.Data.FS.Database
{
    /// <summary>
    /// Mysql数据库实现
    /// </summary>
	public class MysqlDatabase<T,S> :IDataBase<T,S> where T: BaseEntity<S> where S:struct
    {

        #region 属性
        public IFreeSql freesql { get; set; }
        public DbContext dbcontent { get; set; }
        #endregion

        public MysqlDatabase(string connectionString)
		{
            freesql = new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.MySql, connectionString)
                .UseAutoSyncStructure(false) //自动迁移实体的结构到数据库
                .Build();
            dbcontent = freesql.CreateDbContext();
        }

        #region CURD
        public async Task<int> Insert(T entity)
        {
           return await freesql.Insert<T>(entity).ExecuteAffrowsAsync();
        }
        public async Task<int> Insert(IEnumerable<T> entitys)
        {
            return await freesql.Insert<T>(entitys).ExecuteAffrowsAsync();
        }

        public async Task<int> Update(T entity)
        {
            return await freesql.Insert<T>(entity).ExecuteAffrowsAsync();
        }
        public async Task<int> Update(IEnumerable<T> entitys)
        {
            return await freesql.Insert<T>(entitys).ExecuteAffrowsAsync();
        }

        public async Task<int> Delete(S ids)
        {
            return await freesql
                    .Queryable<T>()
                    .Where(entity => entity.Id == Ids)
                    .ToDelete()
                    .ExecuteAffrowsAsync();
        }
        public async Task<int> Delete(IEnumerable<S> ids)
        {
            var guidlist = new List<S>(guids);
            return await freesql
                    .Queryable<T>()
                    .Where(entity => guidlist.Contains(entity.Id))
                    .ToDelete()
                    .ExecuteAffrowsAsync();
          
        }
        public async Task<int> Delete(Expression<Func<T, bool>> condition)
        {
            return await freesql
                    .Queryable<T>()
                    .Where(condition)
                    .ToDelete()
                    .ExecuteAffrowsAsync();
        }

        public async Task<T> FindById(S ids)
        {
            return await freesql
                   .Queryable<T>()
                   .Where(entity => entity.Id == Ids)
                   .FirstAsync<T>();
        }
        public async Task<IEnumerable<T>> FindByIds(IEnumerable<S> ids)
        {
            var guidlist = new List<S>(guids);
            return await freesql
                    .Queryable<T>()
                    .Where(entity => guidlist.Contains(entity.Id))
                    .ToListAsync();
        }
        public async Task<IEnumerable<T>> FindList(Expression<Func<T, bool>> condition)
        {
            return await freesql
                   .Queryable<T>()
                   .Where(condition)
                   .ToListAsync();
        }

        public async Task<(long total, IEnumerable<T>)> FindList(int pageIndex, int pageSize)
        {
            var dataList = freesql.Queryable<T>();
            return (await dataList.CountAsync(),
                    await dataList.Offset(pageIndex*pageSize).Take(pageSize).OrderBy("CreateTime").ToListAsync()); ;
        }

        #endregion

    }
}

