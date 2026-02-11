using CommunityAPI.Interfaces.Repositories;
using CommunityAPI.Interfaces.Services;
using CommunityAPI.Models;

namespace CommunityAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task CreateUserAsync(User user)
        {
            await _userRepo.AddUserAsync(user);
        }

        public async Task <List<User>> GetAllUsersAsync()
        {
            return await _userRepo.GetAllUsersAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepo.GetUserByIdAsync(id);
        }
        public async Task<User?> LoginAsync(string username, string password)
        {
            return await _userRepo.LoginAsync(username, password);
        }

    }
}
