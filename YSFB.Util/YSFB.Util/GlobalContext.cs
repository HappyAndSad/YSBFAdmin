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
	public class GlobalContext
	{
        /// <summary>
        /// Configured service provider.
        /// </summary>
        //public static IServiceProvider ServiceProvider { get; set; }

        //public static IConfiguration Configuration { get; set; }

        //public static IWebHostEnvironment HostingEnvironment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static SystemConfig SystemConfig { get; set; }

        public static string GetVersion()
        {
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            return version.Major + "." + version.Minor;
        }

    }
}

