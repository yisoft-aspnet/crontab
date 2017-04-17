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
using System.Linq;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Yisoft.AspNetCore.Crontab;
using Yisoft.Crontab;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
	public static class CrontabTaskIServiceCollectionExtensions
	{
		public static IServiceCollection AddCrontabTask(this IServiceCollection services, Action<CrontabTaskOptions> crontabTaskOptions = null)
		{
			var options = new CrontabTaskOptions();

			crontabTaskOptions?.Invoke(options);

			var taskScaner = new CrontabTaskScaner(options.MainAssembly, options.TypePrefix);
			var tasks = taskScaner.ScanTasks();

			if (tasks != null)
			{
				foreach (var item in tasks.Select(x => x.ClassType).Distinct())
				{
					services.TryAddSingleton(item);
				}
			}

			options.Tasks = tasks;

			services.TryAddSingleton(options);
			services.TryAddSingleton(taskScaner);
			services.TryAddSingleton<CrontabTaskService>();

			return services;
		}
	}
}
