// ********************************************************
// DepartmentEntity.cs
// Date: 2023/6/25 17:14
// Author: fb 
// OpenSource:  
// Copyright (c) 2023
// ********************************************************
using System;
using FreeSql.DataAnnotations;
using Newtonsoft.Json;
using YSBF.Entity;
using static System.Net.Mime.MediaTypeNames;


namespace YSFB.Entity.OrganizationManage
{
    /// <summary>
    /// 部门实体
    /// </summary>
    [Table(Name = "SysDepartment")]
    public class DepartmentEntity:BaseEntity<Guid>
	{
        /// <summary>
        /// 父部门Id(空表示是根部门)
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string? DepartmentName { get; set; }
        /// <summary>
        /// 部门电话
        /// </summary>
        public string? Telephone { get; set; }
        /// <summary>
        /// 部门传真
        /// </summary>
        public string? Fax { get; set; }
        /// <summary>
        /// 部门Email
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// 部门负责人Id
        /// </summary>
        public Guid? PrincipalId { get; set; }
        /// <summary>
        /// 部门排序
        /// </summary>
        public Guid? DepartmentSort { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
    }
}

