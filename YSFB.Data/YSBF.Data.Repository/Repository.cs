using System;
using YSFB.Data;

namespace YSBF.Data.Repository
{
    ///<summary>
    ///创建人:HappyAndSad
    ///时 间:2023.06.14
    ///描 述:定义仓储模型中的数据标准操作接口
    ///<summary>
    public class Repository
    {
        #region 构造函数
        public IDataBase _db;
        public Repository(IDataBase idataBase)
        {
            this._db = idataBase;
        }
        #endregion

        
    }
}

