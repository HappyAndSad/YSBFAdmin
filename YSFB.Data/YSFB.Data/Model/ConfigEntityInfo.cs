// ********************************************************
// ConfigEntityInfo.cs
// Date: 2023/6/25 14:19
// Author: fb 
// OpenSource:  
// Copyright (c) 2023
// ********************************************************
using System;
using FreeSql.DataAnnotations;

namespace YSFB.Data.Model
{
	public class ConfigEntityInfo
	{
        /// <summary>
        /// 实体类型
        /// </summary>
        public Type EntityType;
        /// <summary>
        /// 实体映射关系
        /// </summary>
        public Action<TableFluent> Fluent;
    }
}

