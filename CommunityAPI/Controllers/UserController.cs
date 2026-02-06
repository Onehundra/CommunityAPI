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
        public async Task <IActionResult> CreateUserAsync([FromBody] CreateUserDto dto)
        {
            var user = new User
            {
                Username = dto.UserName,
                Password = dto.Password,
                Email = dto.Email
                
            };

            await _userService.CreateUserAsync(user);
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()

        {
            return Ok(_userService.GetAllUsersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound($"User With ID {id} Not Found..");

            return Ok(user);

        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto dto)
        {
            var user = await _userService.LoginAsync(dto.Username, dto.Password);

            if (user == null)
                return Unauthorized("Wrong input details");

            return Ok(user.Id);
        }
    }
}

