using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Beginning.Asp.net.Core.Models;
using Beginning.Asp.net.Core.Services;

namespace Beginning.Asp.net.Core.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public FakeApiUsersService _fakeApiUsersService;

		public IEnumerable<Models.FakeApi.User> Users { get; private set; }

		public HomeController(ILogger<HomeController> logger, 
			FakeApiUsersService fakeApiUsersService)
		{
			_fakeApiUsersService = fakeApiUsersService;
			_logger = logger;
		}

		public async Task<IActionResult> Index()
		{
			Users = await _fakeApiUsersService.GetUsers();
			return View(Users);
		}

		//public IActionResult Privacy()
		//{
		//	return View();
		//}

		
		public string Privacy()
		{
			var user = new User()
			{
				Id = 1,
				UserName = "Iman",
				Password = "123456A@"
			};

			var option = new JsonSerializerOptions()
			{
				WriteIndented = true
			};

			var json = JsonSerializer.Serialize(user, option);
			var jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(user, option);

			var deserialized = JsonSerializer.Deserialize<User>(json);
			var deserializedUtf8Bytes = JsonSerializer.Deserialize<User>(jsonUtf8Bytes);

			_logger.LogInformation(json);	
			_logger.LogDebug(json);

			return $"UTF8 serialized object:{json}   :   Deserialized object:{deserialized.UserName} {deserialized.Id} {deserialized.Password}";
		}
		

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
