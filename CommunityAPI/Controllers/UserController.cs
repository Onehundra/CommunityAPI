using Microsoft.AspNetCore.Mvc;
using CommunityAPI.Models;
using CommunityAPI.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using CommunityAPI.Interfaces.Services;
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


        [SwaggerOperation(
            Summary = "Creates new user",
            Description ="Creates a new user with username, password and email")]
        [SwaggerResponse(200,"User created")]
        [SwaggerResponse(400,"Wrong input")]
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



        [SwaggerOperation(
            Summary = "Gets all user",
            Description = "Returns a list with all the users")]
        [SwaggerResponse(200,"List with all users returned")]
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



        [SwaggerOperation(
            Summary = "Gets user via ID",
            Description ="Return the user with the chosen ID")]
        [SwaggerResponse(200,"User found")]
        [SwaggerResponse(404,"User not found")]
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



        [SwaggerOperation(
            Summary = "Logging in a user",
            Description = "Checks input details with database and returns the userID if the details are correct")]
        [SwaggerResponse(200,"Login succeeded")]
        [SwaggerResponse(403,"Wrong input details")]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto dto)
        {
            var user = await _userService.LoginAsync(dto.Username, dto.Password);

            if (user == null)
                return Unauthorized();

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

