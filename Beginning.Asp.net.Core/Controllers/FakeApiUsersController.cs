using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beginning.Asp.net.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beginning.Asp.net.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeApiUsersController : ControllerBase
    {
	    public FakeApiUsersService ApiUsersService { get; }
	    public FakeApiUsersController(FakeApiUsersService apiUsersService)
	    {
		    this.ApiUsersService = apiUsersService;
	    }

		[HttpGet]
	    public async Task<IEnumerable<Beginning.Asp.net.Core.Models.FakeApi.User>> Get()
	    {
		    return await ApiUsersService.GetUsers();
	    }
	}
}