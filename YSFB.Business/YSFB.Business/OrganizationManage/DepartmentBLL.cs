// ********************************************************
// DepartmentBLL.cs
// Date: 2023/7/6 16:45
// Author: HappyAndSad 
// OpenSource: MIT 
// Copyright (c) 2023
// ********************************************************
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YSFB.Entity.OrganizationManage;
using YSFB.Service.OrganizationManage;

namespace YSFB.Business.OrganizationManage
{
	/// <summary>
	/// 部门业务层
	/// </summary>
	public class DepartmentBLL
	{
		/// <summary>
		/// 部门服务
		/// </summary>
		private readonly DepartmentService departmentService = new();

		/// <summary>
		/// 保存部门
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public async Task SaveDepartment(DepartmentEntity entity)=>
			await departmentService.BaseRepository().Insert(entity);
        

		/// <summary>
		/// 删除部门
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		public async Task DelDepartment(List<Guid> guids)
			=> await departmentService.BaseRepository().Delete(guids);

		/// <summary>
		/// 按分页查询部门列表
		/// </summary>
		/// <param name="cpage"></param>
		/// <param name="size"></param>
		/// <returns></returns>
		public async Task<(long total,List<DepartmentEntity>)> GetDepartments(int cpage,int size)=>
            ((long total, List<DepartmentEntity>))await departmentService.BaseRepository().FindList(cpage, size);
    }
}

