// ********************************************************
// BaseEntity.cs
// Date: 2023/6/16 19:47
// Author: HappyAndSad 
// Copyright (c) 2023 MIT 
// ********************************************************
using System;
using Newtonsoft.Json;

namespace YSBF.Entity
{
	/// <summary>
	/// 根模型
	/// </summary>
	/// <typeparam name="">主键类型</typeparam>
	public class BaseEntity<S> where S:struct
	{	
		/// <summary>
		/// 主键
		/// </summary>
		public S Id { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public String CreateUser { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新用户
        /// </summary>
        public String UpdateUser { get; set; }

		/// <summary>
		/// 更新时间
		/// </summary>
		[JsonExtensionData]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [JsonIgnore]
        public Boolean IsDelete { get; set;}
    }
}

