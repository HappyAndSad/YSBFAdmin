// ********************************************************
// MysqlDatabase.cs
// Date: 2023/6/16 22:43
// Author: HappyAndSad 
// Copyright (c) 2023 MIT 
// ********************************************************
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FreeSql;
using YSBF.Entity;
using YSFB.Data.Model;

namespace YSFB.Data.FS.Database
{
    /// <summary>
    /// Mysql数据库实现
    /// </summary>
	public class MysqlDatabase<TEntity,TKey> :IDataBase<TEntity,TKey> where TEntity: BaseEntity<TKey> where TKey:struct
    {
      
        #region 属性
        /// <summary>
        /// freesql
        /// </summary>
        public IFreeSql Orm => _resoleOrm?.Invoke() ?? throw new Exception(CoreStrings.S_BaseEntity_Initialization_Error);
        /// <summary>
        /// 数据库上下文
        /// </summary>
        public DbContext dbcontent => Orm.CreateDbContext();

        /// <summary>
        /// 底层ORM实现
        /// </summary>
        static Func<IFreeSql> _resoleOrm;
        /// <summary>
        /// 工作单元
        /// </summary>
        internal static Func<IUnitOfWork> _resolveUow;
        /// <summary>
        /// 实体队列
        /// </summary>
        static readonly ConcurrentQueue<ConfigEntityInfo> _configEntityQueues = new ConcurrentQueue<ConfigEntityInfo>();
        /// <summary>
        /// 实体配置锁
        /// </summary>
        static readonly object _configEntityLock = new object();
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">链接字符串</param>
        public MysqlDatabase(string connectionString)
        {
            var freeSql = new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.MySql, connectionString)
                .UseAutoSyncStructure(false) //自动迁移实体的结构到数据库
                .Build();
            Initialization(freeSql, freeSql.CreateUnitOfWork);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="resoleOrm"></param>
        /// <param name="resolveUow"></param>
        static void Initialization(IFreeSql resoleOrm, Func<IUnitOfWork> resolveUow) => Initialization(() => resoleOrm, resolveUow);
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="resoleOrm"></param>
        /// <param name="resolveUow"></param>
        static void Initialization(Func<IFreeSql> resoleOrm, Func<IUnitOfWork> resolveUow)
        {
            _resoleOrm = resoleOrm;
            _resolveUow = resolveUow;

            if (_configEntityQueues.Any())
            {
                lock (_configEntityLock)
                {
                    while (_configEntityQueues.TryDequeue(out var cei))
                    {
                        _resoleOrm.Invoke() .CodeFirst.ConfigEntity(cei.EntityType, cei.Fluent);

                    }
                }
            }
        }

        #region CURD
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task<int> Insert(TEntity entity)
        {
            return await Orm
                .Insert<TEntity>(entity)
                .WithTransaction(_resolveUow.Invoke()?.GetOrBeginTransaction(false))
                .ExecuteAffrowsAsync();
        }
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="entitys">实体列表</param>
        /// <returns></returns>
        public async Task<int> Insert(IEnumerable<TEntity> entitys)
        {
            return await Orm.Insert<TEntity>(entitys)
                .WithTransaction(_resolveUow.Invoke()?.GetOrBeginTransaction(false))
                .ExecuteAffrowsAsync();
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public async Task<int> Update(TEntity entity)
        {
            return await Orm.Insert<TEntity>(entity)
                 .WithTransaction(_resolveUow.Invoke()?.GetOrBeginTransaction(false))
                 .ExecuteAffrowsAsync();
        }
        /// <summary>
        /// 批量更新数据
        /// </summary>
        /// <param name="entitys">实体列表</param>
        /// <returns></returns>
        public async Task<int> Update(IEnumerable<TEntity> entitys)
        {
            return await Orm.Insert<TEntity>(entitys)
                .WithTransaction(_resolveUow.Invoke()?.GetOrBeginTransaction(false))
                .ExecuteAffrowsAsync();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="Id">主键</param>
        /// <returns></returns>
        public async Task<int> Delete(TKey Id)
        {
            return await Orm
                    .Queryable<TEntity>()
                    .Where(entity => entity.Id.Equals(Id))
                    .ToDelete()
                    .WithTransaction(_resolveUow.Invoke()?.GetOrBeginTransaction(false))
                    .ExecuteAffrowsAsync();
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="Ids">主键集合</param>
        /// <returns></returns>
        public async Task<int> Delete(IEnumerable<TKey> Ids)
        {
            var guidlist = new List<TKey>(Ids);
            return await Orm
                    .Queryable<TEntity>()
                    .Where(entity => guidlist.Contains(entity.Id))
                    .ToDelete()
                    .WithTransaction(_resolveUow.Invoke()?.GetOrBeginTransaction(false))
                    .ExecuteAffrowsAsync();

        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="condition">lambda表达式</param>
        /// <returns></returns>
        public async Task<int> Delete(Expression<Func<TEntity, bool>> condition)
        {
            return await Orm
                    .Queryable<TEntity>()
                    .Where(condition)
                    .ToDelete()
                    .WithTransaction(_resolveUow.Invoke()?.GetOrBeginTransaction(false))
                    .ExecuteAffrowsAsync();
        }

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="Id">主键</param>
        /// <returns></returns>
        public async Task<TEntity> FindById(TKey Id)
        {
            return await Orm
                   .Queryable<TEntity>()
                   .Where(entity => entity.Id.Equals(Id))
                   .FirstAsync<TEntity>();
        }
        /// <summary>
        /// 根据主键查询列表
        /// </summary>
        /// <param name="Ids">主键集合</param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> FindByIds(IEnumerable<TKey> Ids)
        {
            var guidlist = new List<TKey>(Ids);
            return await Orm
                    .Queryable<TEntity>()
                    .Where(entity => guidlist.Contains(entity.Id))
                    .ToListAsync();
        }
        /// <summary>
        /// 根据lambda表达式查询列表
        /// </summary>
        /// <param name="condition">lambda表达式</param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> FindList(Expression<Func<TEntity, bool>> condition)
        {
            return await Orm
                   .Queryable<TEntity>()
                   .Where(condition)
                   .ToListAsync();
        }
        /// <summary>
        /// 分页查询列表数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<(long total, IEnumerable<TEntity>)> FindList(int pageIndex, int pageSize)
        {
            var dataList = Orm.Queryable<TEntity>();
            return (await dataList.CountAsync(),
                    await dataList
                    .Offset(pageIndex * pageSize)
                    .Take(pageSize)
                    .OrderBy("CreateTime").ToListAsync()); ;
        }
        #endregion

    }
}

