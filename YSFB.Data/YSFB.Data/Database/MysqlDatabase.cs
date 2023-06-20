// ********************************************************
// MysqlDatabase.cs
// Date: 2023/6/16 22:43
// Author: HappyAndSad 
// Copyright (c) 2023 MIT 
// ********************************************************
using System;
namespace YSFB.Data.FS.Database
{
    /// <summary>
    /// Mysql数据库链接实现
    /// </summary>
	public class MysqlDatabase:IDataBase
	{

        #region 属性
        public IFreeSql fsql;
        #endregion


        public MysqlDatabase(string connectionString)
		{
            fsql = new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.Sqlite, connectionString)
                .UseAutoSyncStructure(true) //自动迁移实体的结构到数据库
                .Build();
        }

		
	}
}

