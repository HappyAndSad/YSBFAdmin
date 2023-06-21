// ********************************************************
// BaseEntity.cs
// Date: 2023/6/16 19:47
// Author: HappyAndSad 
// Copyright (c) 2023 MIT 
// ********************************************************
using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace YSBF.Entity
{
	/// <summary>
	/// 根模型
	/// </summary>
	/// <typeparam name="S">主键类型</typeparam>
	public class BaseEntity<S> where S:struct
	{
        /// <summary>
        /// 主键
        /// </summary>
        [Description("创建时间")]
        public S Id { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public String BaseCreator { get; set; } = "";

        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public DateTime BaseCreateTime { get; set; }

        /// <summary>
        /// 更新用户
        /// </summary>
        public String BaseModifier { get; set; } = "";

		/// <summary>
		/// 修改时间
		/// </summary>
		[JsonExtensionData]
        public DateTime BaseModifyTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [JsonIgnore]
        public Boolean BaseIsDelete { get; set;}

        /// <summary>
        /// 数据更新版本，控制并发
        /// </summary>
        public int? BaseVersion { get; set; }
    }
}

