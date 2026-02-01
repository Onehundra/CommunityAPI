using Microsoft.AspNetCore.Mvc;
using CommunityAPI.Data;
using CommunityAPI.Models;
using CommunityAPI.Interfaces;

namespace CommunityAPI.Controllers
{

    
        [ApiController]
        [Route("api/users")]
        public class UserController : ControllerBase
        {
            private readonly IUserService _userService;

            public UserController(IUserService userService)
            {
                _userService = userService;
            }
            [HttpPost]
            public IActionResult CreateUser()
        {
            var user = new User
            {
                Username = "testuser",
                Password = "password123",
                Email = "test@gmail.com"
            };

            _userService.CreateUser(user);
            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetUsers()

        { 
            return Ok(_userService.GetAllUsers());
        }



    }
}

