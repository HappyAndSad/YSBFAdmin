// ********************************************************
// DepartmentListParam.cs
// Date: 2023/6/26 09:53
// Author: HappyAndSad 
// OpenSource: MIT 
// Copyright (c) 2023
// ********************************************************
using System;
using System.Collections.Generic;

namespace YSFB.Model.Param
{
    /// <summary>
    /// 部门请求参数
    /// </summary>
    public class DepartmentListParam
    {
        /// <summary>
        /// 主键查询
        /// </summary>
        public List<string> Ids { get; set; } = new List<string>();
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; } = "";
    }
}

