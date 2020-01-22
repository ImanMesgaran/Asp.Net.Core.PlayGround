using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beginning.Asp.net.Core.Models.FakeApi;
using Beginning.Asp.net.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Beginning.Asp.net.Core.Views.Home
{
    public class IndexModel : PageModel
    {
	    public FakeApiUsersService _fakeApiUsersService;

        public IEnumerable<User> Users { get; private set; }

	    public IndexModel(
		    FakeApiUsersService fakeApiUsersService)
	    {
		    _fakeApiUsersService = fakeApiUsersService;
		    Users = new List<User>();
		}

        public void OnGet()
        {
	        //Users = await _fakeApiUsersService.GetUsers();
	   //     Users = new List<User>()
	   //     {
				//new User()
				//{
				//	FirstName = "fk"
				//}
	   //     };
        }
    }
}
