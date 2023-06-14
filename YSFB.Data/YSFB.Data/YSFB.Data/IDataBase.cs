using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace YSFB.Data
{
	///<summary>
	///创建人:HappyAndSad
	///时 间:2023.06.14
	///描 述:定义数据模型的数据操作
	///<summary>
	public interface IDataBase
	{
        #region 属性

        ///// <summary>
        ///// 当前使用的数据访问对象
        ///// </summary>
        public Object db { get; set; }

        ///// <summary>
        ///// 事务对象
        ///// </summary>
        //public Object dbContextTransaction { get; set; }

        #endregion

        #region 方法

        #region 事务
        /// <summary>
        /// 开启事务
        /// </summary>
        /// <returns></returns>
        Task<IDataBase> BeginTrans();

		/// <summary>
		/// 提交事务
		/// </summary>
		/// <returns></returns>
		Task<int> CommitTrans();

		/// <summary>
		/// 回滚事务
		/// </summary>
		/// <returns></returns>
		Task RollbackTrans();

		/// <summary>
		/// 关闭
		/// </summary>
		/// <returns></returns>
		Task Close();
        #endregion

        #region 执行Sql语句
        Task<int> ExecuteBySql(string strSql);
        Task<int> ExecuteBySql(string strSql, params DbParameter[] dbParameter);
        Task<int> ExecuteByProc(string procName);
        Task<int> ExecuteByProc(string procName, DbParameter[] dbParameter);

        #endregion

        #endregion
    }
}

