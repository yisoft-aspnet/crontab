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
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Yisoft.Crontab;

namespace Yisoft.AspNetCore.Crontab
{
	public class CrontabTaskService
	{
		private readonly CrontabTaskExecutor _executor;

		public CrontabTaskService(CrontabTaskOptions options, IServiceProvider serviceProvider)
		{
			if (options.TypeInstanceCreator == null)
			{
				options.TypeInstanceCreator = method =>
				{
					var classType = method.DeclaringType;

					return serviceProvider.GetRequiredService(classType);
				};
			}

			_executor = new CrontabTaskExecutor(options.TypeInstanceCreator);

			_executor.AddTasks(options.Tasks);
		}

		public IReadOnlyList<CrontabTask> Tasks => _executor.Tasks;

		public void Run() { _executor.Run(); }

		public void Stop() { _executor.Stop(); }
	}
}
