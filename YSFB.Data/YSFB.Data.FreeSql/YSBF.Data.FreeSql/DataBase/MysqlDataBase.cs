using System;
using System.Data.Common;
using System.Threading.Tasks;
using FreeSql;
using YSFB.Data;

namespace YSBF.Data.FS.DataBase
{
    ///<summary>
    ///创建人:HappyAndSad
    ///时 间: 2023.06.14
    ///描 述:使用FreeSql的MySql 实现数据库
    ///<summary>
    public class MysqlDataBase : IDataBase
    {

        public MysqlDataBase(string connString)
        {
            db = new FreeSql.FreeSqlBuilder()
                        .UseConnectionString(FreeSql.DataType.MySql, connString)
                        .UseAutoSyncStructure(false) //自动迁移实体的结构到数据库
                        .Build();
           //dbContext = freeSql.CreateDbContext();
        }

        #region 属性

        public object db { get; set; }
        

        #endregion

        public async Task<IDataBase> BeginTrans()
        {
                            
            return this;
        }

        public Task Close()
        {
            throw new NotImplementedException();
        }

        public Task<int> CommitTrans()
        {
            throw new NotImplementedException();
        }

        public Task<int> ExecuteByProc(string procName)
        {
            throw new NotImplementedException();
        }

        public Task<int> ExecuteByProc(string procName, DbParameter[] dbParameter)
        {
            throw new NotImplementedException();
        }

        public Task<int> ExecuteBySql(string strSql)
        {
            throw new NotImplementedException();
        }

        public Task<int> ExecuteBySql(string strSql, params DbParameter[] dbParameter)
        {
            throw new NotImplementedException();
        }

        public Task RollbackTrans()
        {
            throw new NotImplementedException();
        }
    }
}

