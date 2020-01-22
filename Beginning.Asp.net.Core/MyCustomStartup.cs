using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Beginning.Asp.net.Core
{
	public class MyCustomStartup
	{
		public void Configure(IApplicationBuilder app)
		{
			app.Run(async context => 
				await context
					.Response
					.WriteAsync("this is a custom startup class."));
		}
	}
}
