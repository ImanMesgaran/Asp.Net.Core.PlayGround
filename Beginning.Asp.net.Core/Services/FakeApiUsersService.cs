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

		public IEnumerable<User> Users { get; private set; }
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
			var response = await client.SendAsync(request);

			if (response.IsSuccessStatusCode)
			{
				using var responseStream = await response.Content.ReadAsStreamAsync();
				Users = await JsonSerializer
					.DeserializeAsync
						<IEnumerable<User>>(responseStream);
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
