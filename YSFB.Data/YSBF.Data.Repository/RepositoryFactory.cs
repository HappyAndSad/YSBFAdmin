using System;

namespace YSBF.Data.Repository
{

    /// <summary>
    /// 仓储工厂,给业务层提供服务
    /// </summary>
    public class RepositoryFactory
    {
        public Repository BaseRepository()
        {
            return new Repository();
        }

    }
}

