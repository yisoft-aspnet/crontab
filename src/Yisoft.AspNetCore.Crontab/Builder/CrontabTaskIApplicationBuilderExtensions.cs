//      )                             *     
//   ( /(        *   )       (      (  `    
//   )\()) (   ` )  /( (     )\     )\))(   
//  ((_)\  )\   ( )(_)))\ ((((_)(  ((_)()\  
// __ ((_)((_) (_(_())((_) )\ _ )\ (_()((_) 
// \ \ / / (_) |_   _|| __|(_)_\(_)|  \/  | 
//  \ V /  | | _ | |  | _|  / _ \  | |\/| | 
//   |_|   |_|(_)|_|  |___|/_/ \_\ |_|  |_| 
// 
// This file is subject to the terms and conditions defined in
// file 'License.txt', which is part of this source code package.
// 
// Copyright © Yi.TEAM. All rights reserved.
// -------------------------------------------------------------------------------

using System;
using Microsoft.Extensions.DependencyInjection;
using Yisoft.AspNetCore.Crontab;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder
{
	public static class CrontabTaskIApplicationBuilderExtensions
	{
		public static IApplicationBuilder UseCrontabTask(this IApplicationBuilder app)
		{
			if (app == null) throw new ArgumentNullException(nameof(app));

			var taskService = app.ApplicationServices.GetRequiredService<CrontabTaskService>();

			taskService.Run();

			return app;
		}
	}
}
