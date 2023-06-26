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
	/// 实体基类
	/// </summary>
	/// <typeparam name="S">主键类型</typeparam>
	public abstract class BaseEntity<TKey> : BaseUpdateEntity where TKey:struct
    {
        /// <summary>
        /// 主键
        /// </summary>
        public virtual TKey Id { get; set; }
    }

    /// <summary>
    /// 包括 BaseCreator/BaseCreateTime/BaseIsDelete 的实体基类
    /// </summary>
    /// <typeparam name="S"></typeparam>
    public abstract class BaseCreateEntity
    {
        /// <summary>
        /// 创建用户
        /// </summary>
        public String BaseCreator { get; set; } = "";

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime BaseCreateTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [JsonIgnore]
        public Boolean BaseIsDelete { get; set; }
    }

    /// <summary>
    /// 包括 BaseModifier/BaseModifyTime/BaseVersion 的实体基类
    /// </summary>
    public abstract class BaseUpdateEntity:BaseCreateEntity
    {
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
        /// 数据更新版本，控制并发
        /// </summary>
        public int? BaseVersion { get; set; }
    }


}

