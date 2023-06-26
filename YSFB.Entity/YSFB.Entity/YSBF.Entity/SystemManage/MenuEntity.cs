// ********************************************************
// MenuEntity.cs
// Date: 2023/6/20 10:29
// Author: HappyAndSad 
// OpenSource: MIT 
// Copyright (c) 2023
// ********************************************************
using System;
using Newtonsoft.Json;
using YSBF.Entity;

namespace YSFB.Entity.SystemManage
{
	/// <summary>
	/// 菜单
	/// </summary>
	public class MenuEntity:BaseEntity<Guid>
	{
        
        public Guid ParentId { get; set; }

        public string MenuName { get; set; }

        public string MenuIcon { get; set; }

        public string MenuUrl { get; set; }

        public string MenuTarget { get; set; }

        public int? MenuSort { get; set; }

        public int? MenuType { get; set; }

        public int? MenuStatus { get; set; }
        public string Authorize { get; set; }

        public string Remark { get; set; }
        
        public string ParentName { get; set; }
    }
}

