// ********************************************************
// RepositoryFactory.cs
// Date: 2023/6/16 22:39
// Author: HappyAndSad 
// Copyright (c) 2023 MIT 
// ********************************************************
using System;
using YSBF.Entity;
using YSFB.Data.FS.Database;
using YSFB.Util;

namespace YSFB.Data.Repository
{
    /// <summary>
    /// 仓储工厂
    /// </summary>
    /// <typeparam name="TEntity">实体模型</typeparam>
    /// <typeparam name="TKey">主键</typeparam>
	public class RepositoryFactory<TEntity,TKey> where TEntity:BaseEntity<TKey> where TKey:struct
    {
        /// <summary>
        /// 基础仓储库
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
		public Repository<TEntity,TKey> BaseRepository()
		{
            IDataBase<TEntity,TKey> database;
            string dbType = GlobalContext.SystemConfig.DBProvider;
            string dbConnectionString = GlobalContext.SystemConfig.DBConnectionString;
            switch (dbType)
            {
                case "MySql":
                    //DbHelper.DbType = DatabaseType.MySql;
                    database = new MysqlDatabase<TEntity,TKey>(dbConnectionString);
                    break;
                default:
                    throw new Exception("未找到数据库配置");
            }
            return new Repository<TEntity,TKey>(database);
        }
    }
}

