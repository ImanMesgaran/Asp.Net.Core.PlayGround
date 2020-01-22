using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Beginning.Asp.net.Core.Models.FakeApi;
using Microsoft.AspNetCore.Hosting;

namespace Beginning.Asp.net.Core.Services
{
	public class FakeApiUsersService
	{
		private readonly IHttpClientFactory _clientFactory;

		public IEnumerable<User> Users { get; private set; } = new List<User>();
		public bool GetUsersError { get; private set; }

		public FakeApiUsersService(
			IHttpClientFactory clientFactory)
		{
			_clientFactory = clientFactory;
		}

		public async Task<IEnumerable<User>> GetUsers()
		{
			var request = new HttpRequestMessage(
				HttpMethod.Get,
				"https://reqres.in/api/users?page=1");

			var client = _clientFactory.CreateClient();
			//var response = await client.SendAsync(request);
			var response = await client.GetAsync("https://reqres.in/api/users?page=1");

			 if (response.IsSuccessStatusCode)
			 { 
				 var r = await response.Content.ReadAsStringAsync();

				 using var responseStream = await response.Content.ReadAsStreamAsync();
				 var model= await JsonSerializer
					.DeserializeAsync
						<Users>(responseStream);

				 Users = Models.FakeApi.Users.FromJson(r).Data;
				 
				 //Users = model.Data ?? new List<User>();
			}
			else
			{
				GetUsersError = true;
				Users = Array.Empty<User>();
			}

			return Users;
		}

		
	}
}
