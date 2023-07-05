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
        public async Task<List<DepartmentEntity>> GetList(DepartmentListParam param)
        {
            //var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(param);
            return list.OrderBy(p => p.DepartmentSort).ToList();
        }
        #endregion
    }
}

