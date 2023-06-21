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
        /// <summary>
        /// freesql
        /// </summary>
        public IFreeSql freesql { get; set; }
        /// <summary>
        /// 数据库上下文
        /// </summary>
        public DbContext dbcontent { get; set; }
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">链接字符串</param>
        public MysqlDatabase(string connectionString)
        {
            freesql = new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.MySql, connectionString)
                .UseAutoSyncStructure(false) //自动迁移实体的结构到数据库
                .Build();
            dbcontent = freesql.CreateDbContext();
        }

        #region CURD
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task<int> Insert(T entity)
        {
            return await freesql.Insert<T>(entity).ExecuteAffrowsAsync();
        }
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="entitys">实体列表</param>
        /// <returns></returns>
        public async Task<int> Insert(IEnumerable<T> entitys)
        {
            return await freesql.Insert<T>(entitys).ExecuteAffrowsAsync();
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task<int> Update(T entity)
        {
            return await freesql.Insert<T>(entity).ExecuteAffrowsAsync();
        }
        /// <summary>
        /// 批量更新数据
        /// </summary>
        /// <param name="entitys">实体列表</param>
        /// <returns></returns>
        public async Task<int> Update(IEnumerable<T> entitys)
        {
            return await freesql.Insert<T>(entitys).ExecuteAffrowsAsync();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="Id">主键</param>
        /// <returns></returns>
        public async Task<int> Delete(S Id)
        {
            return await freesql
                    .Queryable<T>()
                    .Where(entity => entity.Id.Equals(Id))
                    .ToDelete()
                    .ExecuteAffrowsAsync();
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="Ids">主键集合</param>
        /// <returns></returns>
        public async Task<int> Delete(IEnumerable<S> Ids)
        {
            var guidlist = new List<S>(Ids);
            return await freesql
                    .Queryable<T>()
                    .Where(entity => guidlist.Contains(entity.Id))
                    .ToDelete()
                    .ExecuteAffrowsAsync();

        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="condition">lambda表达式</param>
        /// <returns></returns>
        public async Task<int> Delete(Expression<Func<T, bool>> condition)
        {
            return await freesql
                    .Queryable<T>()
                    .Where(condition)
                    .ToDelete()
                    .ExecuteAffrowsAsync();
        }

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="Id">主键</param>
        /// <returns></returns>
        public async Task<T> FindById(S Id)
        {
            return await freesql
                   .Queryable<T>()
                   .Where(entity => entity.Id.Equals(Id))
                   .FirstAsync<T>();
        }
        /// <summary>
        /// 根据主键查询列表
        /// </summary>
        /// <param name="Ids">主键集合</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> FindByIds(IEnumerable<S> Ids)
        {
            var guidlist = new List<S>(Ids);
            return await freesql
                    .Queryable<T>()
                    .Where(entity => guidlist.Contains(entity.Id))
                    .ToListAsync();
        }
        /// <summary>
        /// 根据lambda表达式查询列表
        /// </summary>
        /// <param name="condition">lambda表达式</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> FindList(Expression<Func<T, bool>> condition)
        {
            return await freesql
                   .Queryable<T>()
                   .Where(condition)
                   .ToListAsync();
        }
        /// <summary>
        /// 分页查询列表数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<(long total, IEnumerable<T>)> FindList(int pageIndex, int pageSize)
        {
            var dataList = freesql.Queryable<T>();
            return (await dataList.CountAsync(),
                    await dataList.Offset(pageIndex * pageSize).Take(pageSize).OrderBy("CreateTime").ToListAsync()); ;
        }
        #endregion

    }
}

