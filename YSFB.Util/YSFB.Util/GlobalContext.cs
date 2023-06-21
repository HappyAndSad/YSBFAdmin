// ********************************************************
// GlobalContext.cs
// Date: 2023/6/19 09:49
// Author: HappyAndSad 
// Copyright (c) 2023 MIT 
// ********************************************************
using System;
using System.Reflection;
using YSFB.Util.Model;

namespace YSFB.Util
{
    /// <summary>
    /// 全局上下文
    /// </summary>
	public class GlobalContext
    {
        ///// <summary>
        ///// Configured service provider.
        ///// </summary>
        //public static IServiceProvider ServiceProvider { get; set; }

        //public static IConfiguration Configuration { get; set; }

        //public static IWebHostEnvironment HostingEnvironment { get; set; }

        /// <summary>
        /// 系统配置参数
        /// </summary>
        public static SystemConfig SystemConfig { get; set; } = new SystemConfig();
        /// <summary>
        /// 获取版本号
        /// </summary>
        /// <returns></returns>
        public static string GetVersion()
        {
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            return version.Major + "." + version.Minor;
        }

    }
}

