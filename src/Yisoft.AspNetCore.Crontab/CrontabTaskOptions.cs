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
using System.Reflection;
using Yisoft.Crontab;

namespace Yisoft.AspNetCore.Crontab
{
	public class CrontabTaskOptions
	{
		public Assembly MainAssembly { get; set; }

		public List<string> TypePrefix { get; set; }

		public Func<MethodInfo, object> TypeInstanceCreator { get; set; }

		internal IEnumerable<CrontabTask> Tasks { get; set; }
	}
}
