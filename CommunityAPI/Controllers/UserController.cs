using Microsoft.AspNetCore.Mvc;
using CommunityAPI.Data;
using CommunityAPI.Models;

namespace CommunityAPI.Controllers
{

    
        [ApiController]
        [Route("api/users")]
        public class UserController : ControllerBase
        {
            private readonly AppDbContext _db;
            public UserController(AppDbContext db)
            {
                _db = db;
            }

            [HttpPost]
            public IActionResult CreateUser()
            {
                var user = new User
                {
                    Username = "test",
                    Password = "test",
                    Email = "test@test.com"
                };

                _db.Users.Add(user);
                _db.SaveChanges();

                return Ok(user);
            }

            [HttpGet]
            public IActionResult GetUsers()
            {
                var users = _db.Users.ToList();
                return Ok(users);
            }
        }
}

