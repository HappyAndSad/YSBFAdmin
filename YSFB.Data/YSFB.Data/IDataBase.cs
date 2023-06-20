// ********************************************************
// IDataBase.cs
// Date: 2023/6/16 22:57
// Author: HappyAndSad 
// Copyright (c) 2023 MIT 
// ********************************************************
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FreeSql;
using YSBF.Entity;

namespace YSFB.Data
{
    /// <summary>
    /// 数据层方法基础实现定义
    /// </summary>
    /// <typeparam name="T">实体</typeparam>
    /// <typeparam name="S">主键类型</typeparam>
	public interface IDataBase<T,S> where T: BaseEntity<S> where S:struct
    {
		public IFreeSql freesql { get; set; }
		public DbContext dbcontent { get; set; }

		#region CURD
		Task<int> Insert(T entity);
        Task<int> Insert(IEnumerable<T> entitys);

        Task<int> Update(T entity);
        Task<int> Update(IEnumerable<T> entitys);

        Task<int> Delete(S Id);
        Task<int> Delete(IEnumerable<S> Ids);
        Task<int> Delete(Expression<Func<T, bool>> condition);


        Task<T> FindById(S Ids);
        Task<IEnumerable<T>> FindByIds(IEnumerable<S> Ids);
        Task<IEnumerable<T>> FindList(Expression<Func<T, bool>> condition);
        Task<(long total,IEnumerable<T>)> FindList(int pageIndex, int pageSize);
        #endregion

    }
}

