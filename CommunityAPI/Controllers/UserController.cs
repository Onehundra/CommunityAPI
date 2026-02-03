using Microsoft.AspNetCore.Mvc;
using CommunityAPI.Models;
using CommunityAPI.Interfaces;
using CommunityAPI.DTOs;
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
        public IActionResult CreateUser([FromBody] CreateUserDto dto)
        {
            var user = new User
            {
                Username = dto.UserName,
                Password = dto.Password,
                Email = dto.Email
                
            };

            _userService.CreateUser(user);
            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetUsers()

        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
                return NotFound($"User With ID {id} Not Found..");

            return Ok(user);

        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = _userService.Login(dto.Username, dto.Password);

            if (user == null)
                return Unauthorized("Wrong input details");

            return Ok(user.Id);
        }
    }
}

