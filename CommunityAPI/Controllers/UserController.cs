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
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDto dto)
        {
            var user = new User
            {
                Username = dto.UserName,
                Password = dto.Password,
                Email = dto.Email

            };

            await _userService.CreateUserAsync(user);

            var result = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };
            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()

        {
            var users = await _userService.GetAllUsersAsync();

            var result = users.Select(u => new UserDto
            {
                Id =u.Id,
                Username=u.Username,
                Email = u.Email
            });
            return Ok(result);
                
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound($"User With ID {id} Not Found..");

            var result = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto dto)
        {
            var user = await _userService.LoginAsync(dto.Username, dto.Password);

            if (user == null)
                return Unauthorized("Wrong input details");

            var result = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };

            return Ok(result);
        }
    }
}

