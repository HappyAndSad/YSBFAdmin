// ********************************************************
// DepartmentService.cs
// Date: 2023/6/26 09:41
// Author: HappyAndSad 
// OpenSource:MIT
// Copyright (c) 2023
// ********************************************************
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YSFB.Data.Repository;
using YSFB.Entity.OrganizationManage;
using YSFB.Model.Param;

namespace YSFB.Service.OrganizationManage
{
	/// <summary>
	/// 部门基础服务类
	/// </summary>
	public class DepartmentService: RepositoryFactory<DepartmentEntity,Guid>
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<List<DepartmentEntity>> GetList(DepartmentListParam param)
        {
            //var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(x=>param.Ids.Contains(x.Id.ToString()));
            return list.AsSelect().OrderBy(p => p.DepartmentSort).ToList();
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task SaveDepartment(DepartmentEntity entity)
        {
           if(entity.Id == Guid.Empty)
           {
                entity.Id = Guid.NewGuid();
                await this.BaseRepository().Insert(entity);
            }
            else
            {
                await this.BaseRepository().Update(entity);
            }
        }
        #endregion
    }
}

